# Test Strategy Packs

These packs help choose the right test mix for a project or module.

Use `skills/test-strategy-selection/SKILL.md` together with `templates/project-test-strategy-template.md`.

Typical usage:
- CRUD-heavy admin system -> CRUD-heavy business app pack + role and permission pack
- workflow system -> workflow-driven pack + integration-heavy pack
- financial or inventory logic -> mutation integrity pack
- mobile field app -> mobile offline/online pack + role/permission pack when relevant
