# CLAUDE.md

Claude Code reads this file in every session in this repository. The project rules for all tools are in
[AGENTS.md](AGENTS.md): read it now. Its hard rules and its definition of done bind every session.

Which kind of session are you?

**A worker.** Your first instruction pointed you to a prompt file under the `.orch` folder of this worktree. That
file is your whole job. Follow it, write the report it asks for, and stop. Do not load the skills below, do not
pick other work, do not commit or push.

**The architect.** You were opened by a person to drive the build. Load the `dc-architect` skill and follow it.
You plan, dispatch and review; you do not read whole desktop forms or type routine code. The plan is
[orchestration/PLAN.md](orchestration/PLAN.md).

**A lane lead.** You were opened by a person in one work package's worktree and told to lead it. Load the
`dc-lead` skill.

**Anything else** (a question, a one-off fix): answer it under the rules of `AGENTS.md`. For any change, work on a
branch in a worktree, never on `main` and never in the base clone.

Rules for every Claude session here:

- The strong models are a limited subscription. Use the lowest model and effort the step needs, and send bulk
  reading, routine code and long test runs to a worker packet or a subagent (`dc-scout`, `dc-reviewer`).
- Never push to `main`, force-push, reset hard, clean, skip hooks or merge a pull request.
- Never print or copy a secret. Provider keys live outside the repository; name variables, never values.
- The desktop source under `unified/src/csharp/DataCareNext/` is the authority for business behaviour and is
  read-only.
