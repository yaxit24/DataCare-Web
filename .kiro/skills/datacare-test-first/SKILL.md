---
name: datacare-test-first
description: Write the test before the code for any DataCare change, derive the expected values from the desktop (never from the web's own output), watch the test fail, then write the least code that passes. Use whenever implementing a feature, fixing a bug or changing a calculation, writer, route or screen.
---

# Test first

Adapted for DataCare from the Superpowers `test-driven-development` skill
(github.com/obra/superpowers, MIT; see `.kiro/skills/third-party/README.md`).

## The rule

No production change without a failing test first. If you wrote code before its test, delete it and start from the
test. The point is to watch the test fail for the right reason, so you know it tests what you think.

Exceptions, and only after telling the user: throwaway spikes you will delete, and pure configuration.

## Red → green → refactor

1. **Red.** Write the smallest test that captures the next piece of behaviour. Run it. Confirm it fails, and that the
   failure message is the one you expected (not an import error or a typo).
2. **Green.** Write the least code that makes it pass. No extra fields, abstractions or "while I'm here" changes.
3. **Refactor.** Clean up with the test still green.
4. Commit the behaviour, then take the next piece.

## DataCare rules on top of that

- **Expected values come from the desktop, never from the web.** Derive them from the decompiled source (cite
  `unified/src/csharp/DataCareNext/<FORM>.cs:<line>`) or a captured desktop row kept as an
  `web/apps/api/test/fixtures/*.independent.json` fixture. Pasting the web's current output as the expectation tests
  nothing. Use the `datacare-desktop-authority` skill to find the values.
- **Pick the right tier** (see `docs/handbook/web/testing.md`):
  - a calculation → kernel vectors in `web/packages/core/test/`;
  - a writer or posting rule → a complete write-set database test (use the `datacare-write-set-test` skill);
  - a route → schema and route-policy tests, and the exact route-universe count if routes changed;
  - a screen → a zero-mock journey plus the `datacare-e2e-visual` protocol.
- **Prove the test can fail.** Break the code deliberately (drop one ledger leg, flip one sign), see the test fail,
  then revert. Say so in the pull request.
- **Never loosen a test to make it pass.** A comparator, tolerance or required-case list only changes with a
  reviewed, source-backed correction, and the original failing result is kept (`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` §3).
- A trivial one-liner needs no test; non-trivial logic always leaves at least one runnable check behind.

## Red flags — stop and write the test first

- "I'll add the test after I confirm the fix works."
- "This is too simple to test." (Simple code still has a desktop-defined expected value.)
- Keeping pre-test code "as reference" instead of deleting it.
- Expected values copied from the running web app.
