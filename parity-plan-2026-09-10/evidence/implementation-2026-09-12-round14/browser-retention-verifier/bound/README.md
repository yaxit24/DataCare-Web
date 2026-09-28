# Bound browser retention revision

Staged only; do not execute until root confirms all three new runs are complete.

This revision changes only six default label/folder literals from `qualified` to `bound`. The complete verification assertions and contract bytes are unchanged. Original verifier, failure log, and missing-binding diagnostic remain preserved in Round14 `browser-retention-verifier`.

Run `python3 verify_retain_browsers.py` first, then `python3 verify_retain_browsers.py --retain` only if it passes. Default labels are browser-bound, browser-context-bound and browser-labour-bound. The corresponding three bound folders must match the recorded commands exactly. Retention remains exclusive, never overwriting a prior destination.

`revision.patch` and `revision.json` describe the bounded correction. Syntax parsed only; no future results read and no retention performed.
