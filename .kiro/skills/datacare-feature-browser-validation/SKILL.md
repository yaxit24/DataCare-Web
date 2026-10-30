---
name: datacare-feature-browser-validation
description: Validate a DataCare feature by operating its real browser workflow, checking persisted business effects and downstream reports, and comparing desktop behavior. Use for feature verification, completion reviews, or changed workflows; code review and page rendering alone do not satisfy it.
---

# Validate the feature as an operator

Target: a menu, workflow, slice or declared set of edition/book/setting modes. Apply this skill before claiming
that a feature works end to end. It complements desktop authority, write-set tests and visual verification;
it does not grant release acceptance or permission to use customer data.

## Define what must work before running it

Read `docs/master-parity-plan-2026-09-29/04-verification-playbook.md` (T01–T18 and the applicable J01–J28),
`docs/handbook/web/testing.md`, the target menu-catalog rows and slice contracts. Use
`datacare-desktop-authority` to establish expected calculations, transitions, write sets, modes and refusals.
Capture source references and independently computed expected values before observing the web result.

Build a **feature-specific required-case matrix**, not a generic happy-path checklist. Expand every applicable
T group into cases for the actual books, roles, settings, numeric boundaries, line/child variants and downstream
states. Cover every distinct desktop branch; use a documented equivalence class only when the same behavior
and constraints truly apply. Include every previously reported defect. Use distinct non-default field values.

- Cover create → close/reopen → unchanged save → changed save → print/report → downstream use → allowed
  delete/cancel/reverse. Read-only features instead cover their filters, totals, drilldowns and outputs.
- Include lookup cancellation/stale response, multiple/dissimilar child rows, tax/labour/rounding branches,
  mixed payment and partial allocation when supported, and empty/invalid/maximum inputs.
- Include two independently authenticated sessions with the same voucher loaded: first save, stale second
  save and stale delete. Reject lost updates; also test two users claiming the same stock/source.
- Exercise duplicate submission and a lost acknowledgement after commit; recover the single durable result.
- Test period/rights/scope restrictions, changed settings, imported/historical records, failures during writes,
  and unchanged sentinels in other tenant/company/location/year/book scopes.
- Verify report/export/print after creation, edit, downstream consumption and reversal, not only the editor.

Keep the matrix fixed during the run. A failure cannot be removed, relabelled N/A or turned into a weaker test
to improve the percentage. A true N/A needs desktop/contract evidence and a reason recorded **before** execution.
“All cases” means the declared source-backed required set, not every mathematically possible input. Report its
boundaries explicitly. Missing desktop behavior or an undecided rule is blocked, not an assumed pass.

## Execute through the real screen

Use the isolated stack in testing handbook §2, a unique Compose project and unused DB/API/web ports. Check active
sessions before selecting ports or building; never replace another session's build or test against customer data.
Pin candidate commit (and dirty patch hash if necessary), fixture/settings/lock/schema/template identities, runtime,
locale, browser and execution times. Build the web with the matching API origin.

Use the available browser-control tool for agent-driven verification; follow its API and isolation rules.
For retained automated journeys use the repository's real-stack harness. Start from real login and menu
navigation. Select company/location/year/book and verify the displayed context. Use actual controls and keyboard
interactions for the operation under test. Do not seed the target voucher in SQL, call its writer directly or
use page-evaluated fetch requests as a substitute for operating it. Setup fixtures may seed independent masters
and sentinels; also include a fresh-business setup case through supported UI when provisioning is in scope.

For **each case**:

1. Record initial state and the independent expected outcome; execute ordered browser actions.
2. Check visible intermediate totals, lookup identities, focus and messages; capture sanitized screenshots and
   browser trace/network evidence of the actual requests and responses, including deliberate refusals.
3. Read persisted results through the isolated database observer; compare the complete affected write set,
   identifiers and untouched sentinels. A toast, HTTP 200, balanced total or self-consistent reopen is insufficient.
4. Close and reopen in a new navigation/session where relevant; compare all values, child ownership, images,
   precision, NULL/blank distinctions and identifiers. Save unchanged and compare the full before/after footprint.
5. Continue through the relevant downstream screen/report and assert balances, stock/fine, allocations,
   outstanding, audit and printed data. Check intended no-change effects after refusals and rollback.
6. Perform the same defined case against an isolated original Windows desktop deployment when available.
   Separate source-derived expected behavior from independently captured Windows execution. Never dump customer
   rows; use sanitized fixtures and the approved aggregate/private evidence rules.

Do not intercept or synthesize business responses. Declared transport fault injection for retry/rollback cases
is allowed and must retain the actual server/DB outcome; it is not a normal zero-interception pass. Device fakes
are permitted by D29 for engineering tests only: record the fake and leave physical/provider acceptance pending.
If a browser/desktop/device is unavailable, continue independent cases and record blocked coverage. Never infer
browser success from API tests or desktop equality from a green CI job whose comparison steps skipped.

## Measure, retain and report

Read [the evidence contract](references/evidence-contract.md) before recording results. Run its validator against
the frozen matrix and evidence bundle. This checks exact case IDs, identities and artifact hashes; it does **not**
execute the browser or judge whether artifacts prove their claims. Review the artifacts, not just the validator.

Report separately:

- Executed coverage = (passed + failed applicable browser cases) / all applicable required cases.
- Browser/business pass coverage = passed applicable cases / all applicable required cases.
- Desktop-match coverage = cases with independently executed matching desktop evidence / applicable cases.
- Failed, blocked, untested and justified N/A counts, with case IDs and concrete defects.

Blocked/untested cases remain in the denominator. N/A cannot hide an unsupported feature. Do not average these
numbers, turn field/page/test counts into functional percentages, or claim a whole tier from a selected subset.
A 100% browser result is scoped to this matrix; desktop match, physical devices and product acceptance remain
separate. No undocumented desktop comparison may be promoted from source-derived to runtime-confirmed.

Save sanitized matrix, run record, observations and hashes under the feature's approved private evidence folder
or ignored test-results directory; commit only sanitized summaries/fixtures allowed by repository policy. Link the
bundle and command results in the PR and existing backlog evidence fields. Record failures as gaps; keep slice
statuses within the existing plan vocabulary and parent acceptances open. On fixes, preserve the failed run and
rerun the failing case plus its affected lifecycle/dependencies on the new candidate. Do not reuse old evidence
as proof for a changed candidate.
