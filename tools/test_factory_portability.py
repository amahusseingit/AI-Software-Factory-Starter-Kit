"""Real CLI and Git-checkout regressions; fixtures never count as approval."""
import hashlib
import json
import os
from pathlib import Path
import subprocess
import sys
import tempfile
import unittest

from validate_factory import source_matches

ROOT = Path(__file__).resolve().parents[1]


class PortabilityTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        (self.root / "governance").mkdir()
        (self.root / "archive").mkdir()
        (self.root / "governance/gate-contract.json").write_bytes(
            (ROOT / "governance/gate-contract.json").read_bytes())
        for name in ("protocol.md", "security-policy.md"):
            (self.root / "governance" / name).write_bytes("# Canonical — ✓\n".encode("utf-8"))
        for name in ("AGENTS.md", "ORCHESTRATOR.md", "governance/approval-gates.md"):
            (self.root / name).write_text("See protocol.md and security-policy.md", encoding="utf-8")
        self.original = "# Original — ✓\nsecond line\n".encode("utf-8")
        self.source = self.root / "archive/source.md"
        self.source.write_bytes(self.original)
        self.digest = hashlib.sha256(self.original).hexdigest()
        (self.root / "SOURCE_MANIFEST.json").write_text(json.dumps({"sources": [
            {"path": "archive/source.md", "sha256": self.digest}]}), encoding="utf-8")

    def git(self, *args):
        return subprocess.run(["git", "-C", str(self.root), *args], check=True,
                              capture_output=True).stdout

    def commit_source(self):
        self.git("init", "-q")
        self.git("-c", "core.autocrlf=false", "add", "archive/source.md")
        self.git("-c", "user.name=Synthetic Test", "-c", "user.email=test@example.invalid",
                 "-c", "commit.gpgsign=false", "commit", "-qm", "Synthetic fixture")

    def cli(self):
        env = dict(os.environ, PYTHONUTF8="0", PYTHONIOENCODING="utf-8")
        return subprocess.run([sys.executable, "-B", "-X", "utf8=0",
                               str(ROOT / "tools/validate_factory.py"), "--root", str(self.root)],
                              env=env, capture_output=True, text=True, encoding="utf-8")

    def test_unicode_cli_without_utf8_mode(self):
        result = self.cli()
        self.assertEqual(result.returncode, 0, result.stdout + result.stderr)
        self.assertEqual(json.loads(result.stdout)["decision"], "PASS")

    def test_crlf_checkout_requires_matching_committed_blob(self):
        self.commit_source()
        self.source.write_bytes(self.original.replace(b"\n", b"\r\n"))
        self.assertTrue(source_matches(self.root, "archive/source.md", self.digest))
        result = self.cli()
        self.assertEqual(result.returncode, 0, result.stdout)
        self.assertEqual(self.source.read_bytes(), self.original.replace(b"\n", b"\r\n"))

    def test_changed_content_in_crlf_checkout_is_blocked(self):
        self.commit_source()
        self.source.write_bytes(self.original.replace(b"\n", b"\r\n") + b"tampered\r\n")
        result = self.cli()
        self.assertEqual(result.returncode, 1, result.stdout)
        self.assertIn("hash mismatch", result.stdout)

    def test_crlf_export_without_git_is_blocked(self):
        self.source.write_bytes(self.original.replace(b"\n", b"\r\n"))
        self.assertFalse(source_matches(self.root, "archive/source.md", self.digest))

    def test_manifest_cannot_hide_changed_blob(self):
        self.commit_source()
        self.assertFalse(source_matches(self.root, "archive/source.md", "0" * 64))

    def test_path_escape_is_blocked(self):
        manifest = self.root / "SOURCE_MANIFEST.json"
        manifest.write_text(json.dumps({"sources": [{"path": "../outside", "sha256": self.digest}]}),
                            encoding="utf-8")
        result = self.cli()
        self.assertEqual(result.returncode, 1)
        self.assertIn("path escapes repository", result.stdout)

    def test_unknown_decision_is_blocked_by_real_cli(self):
        path = self.root / "governance/gate-contract.json"
        contract = json.loads(path.read_text(encoding="utf-8"))
        contract["decisions"].append("GO")
        path.write_text(json.dumps(contract), encoding="utf-8")
        self.assertEqual(self.cli().returncode, 1)

    def test_partial_codex_adapter_install_is_blocked(self):
        adapter = self.root / "skills/codex-factory-adapter/SKILL.md"
        adapter.parent.mkdir(parents=True)
        adapter.write_text("# Adapter", encoding="utf-8")
        result = self.cli()
        self.assertEqual(result.returncode, 1)
        self.assertIn("missing Codex adapter dependency", result.stdout)

    def test_missing_command_skill_is_blocked(self):
        adapter = self.root / "skills/codex-factory-adapter/SKILL.md"
        adapter.parent.mkdir(parents=True)
        adapter.write_text("# Adapter", encoding="utf-8")
        for name in (".agents/skills/factory/SKILL.md", "roles/README.md",
                     "templates/role-plan-template.md", "templates/role-handoff-template.md"):
            path = self.root / name
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_text("# Dependency", encoding="utf-8")
        (self.root / "commands").mkdir()
        (self.root / "commands/BUILD.md").write_text("skills/missing/SKILL.md", encoding="utf-8")
        result = self.cli()
        self.assertEqual(result.returncode, 1)
        self.assertIn("missing command skill", result.stdout)

    def runner(self):
        return subprocess.run([sys.executable, "-B", str(ROOT / "tools/run_factory_tests.py"),
                               "--root", str(self.root)], capture_output=True, text=True)

    def test_partial_mandatory_suite_is_blocked(self):
        directory = self.root / "tools"
        directory.mkdir()
        (directory / "test_factory_portability.py").write_text(
            "import unittest\nclass Synthetic(unittest.TestCase):\n def test_one(self): pass\n",
            encoding="utf-8")
        result = self.runner()
        self.assertEqual(result.returncode, 1)
        self.assertIn("missing mandatory test suites", result.stdout)

    def test_empty_mandatory_modules_are_blocked(self):
        directory = self.root / "tools"
        directory.mkdir()
        for name in ("gates", "branches", "portability"):
            (directory / ("test_factory_" + name + ".py")).write_text("# Empty module", encoding="utf-8")
        result = self.runner()
        self.assertEqual(result.returncode, 1)
        self.assertIn("empty mandatory test suites", result.stdout)

    def test_legacy_crlf_checkout_stages_original_archive_bytes(self):
        self.commit_source()
        self.source.write_bytes(self.original.replace(b"\n", b"\r\n"))
        (self.root / ".gitattributes").write_bytes((ROOT / ".gitattributes").read_bytes())
        # Change metadata/content away and back to avoid a cached clean stat result.
        self.source.write_bytes(b"temporary")
        self.source.write_bytes(self.original.replace(b"\n", b"\r\n"))
        self.git("-c", "core.autocrlf=true", "add", "-A")
        self.assertEqual(self.git("show", ":archive/source.md"), self.original)
        self.assertEqual(self.git("diff", "--cached", "--name-only", "--", "archive"), b"")
        self.git("-c", "user.name=Synthetic Test", "-c", "user.email=test@example.invalid",
                 "-c", "commit.gpgsign=false", "commit", "-qm", "Synthetic upgrade")
        self.assertEqual(self.cli().returncode, 0)


if __name__ == "__main__":
    unittest.main()
