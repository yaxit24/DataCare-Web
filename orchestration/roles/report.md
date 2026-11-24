When you are finished, or cannot continue, write the file `.orch/report.md` in this worktree. It is the only
thing the supervisor reads from you, so it must stand alone. Use exactly this layout:

```
STATUS: DONE
```

or `STATUS: PARTIAL` (some of the "Done when" list does not hold) or `STATUS: BLOCKED` (you could not start or
continue; nothing useful to check). The status line is the first line of the file.

Then these sections, in this order. Write "none" under a section that is empty.

- `## What I did`: three to eight sentences. Name each file you created or changed and why.
- `## Done when`: copy each line of the packet's "Done when" list and mark it `yes` or `no` with one reason.
- `## Evidence`: each command you ran and the last five lines it printed, in a code block.
- `## Not done or not verified`: each item with the reason.
- `## Found but out of scope`: problems you saw and did not touch, each with a file and line.
- `## Questions for the supervisor`: only questions whose answer changes the work.

Do not write a summary anywhere else, and do not end the session before this file exists.
