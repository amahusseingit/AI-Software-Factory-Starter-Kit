#!/usr/bin/env python3
"""Fail-closed entry point for all required Factory synthetic test suites."""
import argparse
from pathlib import Path
import sys
import unittest

REQUIRED = ("test_factory_gates", "test_factory_branches", "test_factory_portability")


def cases(suite):
    for item in suite:
        if isinstance(item, unittest.TestSuite):
            yield from cases(item)
        else:
            yield item


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--root", type=Path, default=Path(__file__).resolve().parents[1])
    args = parser.parse_args()
    directory = args.root.resolve() / "tools"
    missing = [name for name in REQUIRED if not (directory / (name + ".py")).is_file()]
    if missing:
        print("BLOCKED: missing mandatory test suites: " + ", ".join(missing))
        return 1
    loader = unittest.TestLoader()
    suite = loader.discover(str(directory), pattern="test_factory*.py")
    ids = [case.id() for case in cases(suite)]
    empty = [name for name in REQUIRED if not any(i.startswith(name + ".") for i in ids)]
    if loader.errors or empty:
        print("BLOCKED: unimportable or empty mandatory test suites: " + ", ".join(empty))
        for error in loader.errors:
            print(error)
        return 1
    result = unittest.TextTestRunner(verbosity=2).run(suite)
    return 0 if result.wasSuccessful() else 1


if __name__ == "__main__":
    raise SystemExit(main())
