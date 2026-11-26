# WP-35 browser handoff

Status: authored and statically checked; no browser or database run was permitted in this worker.
No behavioral red/green result or desktop-runtime match is claimed.

## Run command (R1)

From `web/`, on Claude's isolated stack:

```sh
FEATURE_E2E_MODULES=fine-jv,party-opening,item-opening,company-open,settings PARITY_TEST_PORT=55635 node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs
```

Use unused API/web ports and build the web against that API origin as required by the testing handbook.
Run the complete selected modules, including their existing cases. R1 applies to every executable row below.

## Frozen cases

The imported modules contain all 26 exact case IDs from cases.md, each with a desktop citation in `source`.
22 are executable but unexecuted, three blocked, one N/A. Applicable executed coverage, browser pass coverage,
and independent desktop-match coverage for this residual matrix are all 0/25 (0%).
Blocked cases remain in the denominator. This is a scoped residual matrix, not whole-feature certification.

| Case ID                                              | Status                 | Command / reason                                                                                  |
| ---------------------------------------------------- | ---------------------- | ------------------------------------------------------------------------------------------------- |
| `fine-jv.concurrency.stale-second-save`              | executable, unexecuted | R1; unexecuted                                                                                    |
| `fine-jv.retry.idempotent-replay`                    | blocked                | WP-04 batch B (agent/wp04-idem-lite) must merge first                                             |
| `fine-jv.rollback.save`                              | executable, unexecuted | R1; unexecuted                                                                                    |
| `fine-jv.rollback.edit`                              | executable, unexecuted | R1; unexecuted                                                                                    |
| `fine-jv.rollback.delete`                            | executable, unexecuted | R1; unexecuted                                                                                    |
| `fine-jv.downstream-report`                          | executable, unexecuted | R1; unexecuted                                                                                    |
| `party-opening.concurrency.last-save-wins`           | executable, unexecuted | R1; unexecuted                                                                                    |
| `party-opening.rollback.save`                        | executable, unexecuted | R1; unexecuted                                                                                    |
| `party-opening.config.data-type-a-only`              | executable, unexecuted | R1; unexecuted                                                                                    |
| `party-opening.config.ab-merge`                      | N/A                    | A/B Merge is Advance/Enterprise only; outside Lite.                                               |
| `party-opening.keyboard.esc-and-keys`                | executable, unexecuted | R1; unexecuted                                                                                    |
| `item-opening.rollback.save`                         | executable, unexecuted | R1; unexecuted                                                                                    |
| `item-opening.rollback.delete`                       | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.branches.year-choice-carried`          | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.refusals.stale-choice-refused`         | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.reopen.year-newest-default`            | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.rights.location-scope`                 | blocked                | Requires second location, non-A user and home-location fixtures; catalogue has only one location. |
| `company-open.retry.replayed-selection`              | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.rollback.fault`                        | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.settings.last-day-lock`                | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.settings.settings-in-force`            | blocked                | G174: requires a second company with different settings in the fixture catalogue.                 |
| `company-open.keyboard.tab-and-enter`                | executable, unexecuted | R1; unexecuted                                                                                    |
| `company-open.journey.open-then-dashboard`           | executable, unexecuted | R1; unexecuted                                                                                    |
| `settings.concurrency.two-admins.different-settings` | executable, unexecuted | R1; unexecuted                                                                                    |
| `settings.concurrency.two-admins.same-setting`       | executable, unexecuted | R1; unexecuted                                                                                    |
| `settings.rollback.second-table-fault`               | executable, unexecuted | R1; unexecuted                                                                                    |

## Old → new IDs

- `fine-jv.concurrency.pending` → `fine-jv.concurrency.stale-second-save`.
- `fine-jv.retry.pending` → `fine-jv.retry.idempotent-replay` (packet D-35-1 retains the WP-04 block).
- `fine-jv.rollback.pending` → `fine-jv.rollback.save`, `.edit`, `.delete`.
- `fine-jv.downstream-report.pending` → `fine-jv.downstream-report`.
- `party-opening.concurrency.pending` → `party-opening.concurrency.last-save-wins`.
- `party-opening.rollback.pending` → `party-opening.rollback.save`.
- `party-opening.config.pending` → `party-opening.config.data-type-a-only` and `.ab-merge` (N/A).
  `party-opening.keyboard.esc-and-keys` is additive; existing Alt+S coverage is retained.
- `item-opening.rollback.pending` → `item-opening.rollback.save` and `.delete`.
- Company `branches/refusals/reopen/rights/retry/rollback/keyboard/journey.pending` → their correspondingly
  prefixed frozen IDs in the table; `settings.pending` → both `company-open.settings.*` rows.
- Company `calculations/lines/settlement/unchanged-save/edit/delete/output.pending` →
  matching `.not-applicable` IDs with the cases.md T03/T05/T06/T08/T09/T10/T16 reasons.
- `settings.concurrency.two-admins` → `.different-settings` and `.same-setting`.
- `settings.rollback.n-a` → `settings.rollback.second-table-fault`.

## Implementation details and expected failures

- `rollbackMatrix.fixedVoucherNo` skips integer numbering and preserves the caller's literal key
  (`00000`, `G`, or the existing Fine JV number); it accepts 200/201 for replacements.
  Existing callers still require 201 and prove the next number was not consumed.
- Fine JV and Item Opening measure the tables changed by a real UI save before faulting that exact set.
  Empty optional detail tables are not falsely described as exercised. Party Opening explicitly creates two bills
  so OP_DATA, OP_DETL and AC_DATA all participate. Every failed matrix attempt compares the tenant fingerprint;
  the existing pending-write probe and exact-table-set assertion remain enabled.
- Delete faults and settings/context faults use scoped real database triggers, removed in `finally`.
  No business response is mocked. Settings tests load both sessions before either admin saves.
- Precision correction to cases.md: typing 12.3456 in Fine JV leaves the cell as 12.346.
  The desktop authority is `unified/src/csharp/DataCareNext/TR_CONTRA.cs:1689-1692`
  (`Strings.Format(..., "0.000")`), before :2787-2788 stores it. The new browser assertion therefore uses
  12.346, matching the existing green three-decimal case; no production arithmetic changed.
- Static inspection predicts failures for newest-year order (ascending web list), Fine JV ledger-to-voucher
  drill-down (detail rows have no navigation handler), and the last-day-lock response assertion
  (`app.ts` omits the internal `selected.lastDayLock` object). These assertions remain executable.
  Their production files are outside this packet's allow-list. No runtime failure is claimed.
- Open Company and Party Opening keyboard cases retain the frozen assertions; runtime results are pending.
- The selected browser run may also reveal 5xx/console behavior under injected faults. No exceptions were added
  to the harness's console checks to hide such failures.

## Static verification

Packet gate: all five `node --check` calls, `node --check faults.mjs`, targeted ESLint, and targeted Prettier
check completed with exit 0. Prettier: `All matched files use Prettier code style!`.
Imported all five modules and checked the 26 frozen IDs and their desktop citations: 26/26 matched.
No browser evidence bundle was generated; its validator cannot establish an unexecuted run.
