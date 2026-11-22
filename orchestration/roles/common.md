These rules apply to every worker session. They are short on purpose: follow each one literally.

1. **Your packet is your whole job.** Do what section 3 asks and nothing else. If you notice another problem, write
   it under "Found but out of scope" in your report. Do not fix it.
2. **Stay in this worktree and on this branch.** Never run `git commit`, `git push`, `git checkout`, `git switch`,
   `git reset`, `git clean`, `git stash` or any `gh` command. The dispatcher commits and pushes. Leave your changes
   as ordinary edits in the working tree.
3. **Change only the paths section 4 allows.** A change anywhere else fails the run, even a one-line fix.
4. **The desktop source is the authority for business behaviour.** It is in `unified/src/csharp/DataCareNext/`.
   It is read-only. Expected values in tests and documents come from the desktop rule, never from what the web
   application prints today.
5. **Cite with a quote.** Every statement about what the desktop does carries a citation in exactly this form:
   `FORM.cs:123 {{text copied from that line}}` or `FORM.cs:120-128 {{text copied from one of those lines}}`.
   Copy the quote from the file; do not retype it from memory. A script checks every quote against the cited lines.
6. **Never invent.** If a file, a template, a decision or a fact is missing, write `MISSING: <what>` and, if you
   cannot continue without it, stop with a blocked report. A guessed line number, column name or message text is
   worse than no answer.
7. **Never weaken a test.** Do not skip, focus, delete or loosen a test, and do not add entries to
   `baseline.json` to make a run green. A failing test is a finding: report it.
8. **Do not port desktop weaknesses.** No SQL built by joining strings, no plaintext secrets, no unscoped delete,
   no partial write, no hidden backdoor. Reproduce the business result, the message texts and the keyboard flow.
9. **Data and secrets.** Never open `.env` files, database files or parity capture files. Never print a name, a
   phone number, an address or a row of data. Tests run only on the isolated database started by
   `web/scripts/parity-test-env.mjs`.
10. **Read by range.** A desktop form can be 30,000 lines. Open its form index under `.orch/index/` first, then
    read only the line ranges you need. Do not print whole files.
11. **Evidence before claims.** Say a command passed only if you ran it in this session, and paste its last lines.
    If a command cannot run here (Docker is not running, a dependency is missing), say so. Do not claim success.
12. **Same error three times: stop.** Write what you tried and the exact error in your report and stop as
    `PARTIAL` or `BLOCKED`. Do not keep guessing.
13. **Write in plain, complete sentences.** Another model with no memory of this session will read your output.
