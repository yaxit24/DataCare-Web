---
name: dc-packet
description: Write a DataCare-Web work packet that a cheap model can finish without asking questions — choose the role and scope, find the desktop line ranges with a form index, name the files to read and the example to copy, set the allowed paths, gates and limits, then validate and dry-run it. Use whenever a work package or a failed run must be turned into one or more packets for the orchestration dispatcher.
---

# Write a work packet

The format is in `orchestration/PACKETS.md`; start from `orchestration/packets/_template.md`. A packet is good
when a model that has never seen the project can finish it in under an hour and a script can tell whether it did.

## Steps

1. **Read the work package card** in `docs/parity/LITE-MASTER-PLAN.md` section 5 and the menu prompt it names in
   `docs/agent-prompts/lite/`. Take the facts; do not paste the prompt.
2. **Locate, cheaply.** For each desktop form:

   ```bash
   node orchestration/bin/orch.mjs outline <FORM>.cs --out <scratch>/<FORM>.index.md
   ```

   Search the index (members, message texts, tables) for the line ranges that matter. Read the index, not the
   form. For web files, search by menu caption and table name, or ask the `dc-scout` subagent.
3. **Choose the role and split.** One role and one output per packet. Sizes are in `orchestration/PACKETS.md`
   section 3; the usual chain is in section 4. A form over about 6,000 lines in scope gets one study packet per
   mode or branch.
4. **Write the header.** `allow` is as narrow as the output: a study writes one folder; an implementer gets the
   module directory and the route file, not `web/**`. Add `deny` for the nearest file it must not grow (the
   files at their size ceiling). Gates: a citation check for documents; for code, the single test file first,
   then lint and type check; the full suites are left to CI.
5. **Write the brief.** Goal, Facts you need, What to cover or Steps, Out of scope, Done when. Put in every fact
   you already know: line ranges, table names, the web file, the test to copy, the command to run. State the
   nearest wrong turn.
6. **Validate and look at the size.**

   ```bash
   node orchestration/bin/orch.mjs check orchestration/packets/<file>.md
   node orchestration/bin/orch.mjs run   orchestration/packets/<file>.md --dry-run
   ```

   The dry run prints the approximate tokens of the context pack. Over about 15,000, cut `inline` and `skills`.

## Checklist before dispatch

- The title states an outcome.
- Every file the worker must read is named; nothing says "find".
- "Done when" has no line that needs judgment to check.
- The branch is the package's branch, shared by all its packets.
- `dependsOn` names the packets whose output this one reads.
- For `implement` and `ui`: the tests exist on the branch and are red (`red.md`).
- For `review`: the tier's first ready candidate is a different model family from the one that wrote the diff;
  otherwise pass `--runner` or `--tier`.
- Risk tier A: the packet names the invariant that must hold (closing equals opening, one voucher per replay,
  both sides balance) and the test that proves it.

## After a failed run

Read the failed checks in the summary. Then change the packet, not just the attempt count:

| The failure | The packet lacked |
|---|---|
| Changed files outside the allow list | A file the task really needs: add it, or split the task |
| Citation errors | Line ranges: give them, and lower the scope |
| Tests still red | A fact about the desktop rule: add the cited lines to `inline` |
| Ran out of time | Size: split by mode, by layer or by module |
| `BLOCKED` with a question | The answer: write it under "Facts you need" |
