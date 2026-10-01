---
name: datacare-debug
description: Find the root cause of a DataCare bug, test failure or wrong value before proposing any fix, using the desktop as the oracle and the real stack as the evidence. Use for any failing test, wrong write set, 500, mismatched report or unexpected behaviour.
---

# Systematic debugging

Adapted for DataCare from the Superpowers `systematic-debugging` skill
(github.com/obra/superpowers, MIT; see `.kiro/skills/third-party/README.md`).

## The rule

No fix before the root cause is understood. A symptom fix is not a fix. Work the phases in order; do not skip to a
change because it "looks obvious" or because you are in a hurry.

## Phase 1 — find the root cause

1. **Read the whole error.** Stack trace, line numbers, the failing assertion's expected and actual values. For a
   write-set test, read which table and column differ.
2. **Reproduce it reliably.** The exact slice, fixture, book and settings. If you cannot reproduce it, gather more
   evidence; do not guess.
3. **Check what changed.** `git log` and `git diff` on the files involved; a merged change from another session
   (`git log origin/main`); a dependency or migration.
4. **Trace the data across the layers** — screen → `web/apps/web/lib/api.ts` → route → writer → `withTenant` → SQL.
   Find where the value first goes wrong. Fix it at the source, not at the symptom: if the function is shared
   (`web/apps/api/src/modules/shared/` or `web/packages/core/`), fix it once there, not in one caller.
5. **Compare with the desktop.** If a value or write set is wrong, the desktop source is the oracle: open the form's
   save routine and posting helpers (the `datacare-desktop-authority` skill), and compare field by field. The web may
   be wrong, or the test's expected value may be wrong — decide which with evidence, never by loosening the test.

## Phase 2 — one hypothesis at a time

State it plainly: "the amount is wrong because the labour branch uses net instead of net+ghat
(`TR_SALE.cs:11082`)." Make the smallest change that tests it. One variable at a time.

## Phase 3 — fix and prove

Add or keep a failing test that captures the root cause (`datacare-test-first`), make the single fix, run the full
gate for that tier, and confirm nothing else broke. Clean up any temporary logging.

## When fixes keep failing

After three failed fixes, stop. The problem is probably the approach, not the detail: a shared posting assumption, a
missing book slot, a wrong leg code, or a kernel bypass. Say so and discuss the approach with the user before a
fourth attempt. Do not stack fixes.

## Red flags — stop and return to Phase 1

- "Quick fix now, understand it later."
- Changing several things at once to see what works.
- Proposing a fix before tracing where the value comes from.
- Loosening a comparator or tolerance to make the test green.
- A second or third fix that each reveals a new problem elsewhere.
