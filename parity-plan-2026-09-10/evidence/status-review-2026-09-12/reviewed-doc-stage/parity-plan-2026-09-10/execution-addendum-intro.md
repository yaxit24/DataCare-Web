# Detailed implementation continuation — 12 September 2026

This is the operational continuation of [02-implementation-plan.md](02-implementation-plan.md), based on [the historical completion-review baseline](11-current-completion-review.md). It contains **34 execution cards mapped to all 83 original packages**. The matching structured backlog is [13-execution-backlog.json](13-execution-backlog.json). These cards retain the original package acceptance and expand it; they do not reduce it to a shorter checklist.

Current implementation is paused for status review. [Document42](42-implementation-progress-round15.md) records the Round15 in-progress work, all34 remaining-gap areas and the complete next-write sequence. Only core26files/1613tests and strict compilation of the five new core test files have passed in the Round15 recipe; the other16 checks have not run and checkpoint43 is not sealed. The latest sealed evidence remains [checkpoint41](41-implementation-checkpoint-round14.json) with [document40](40-implementation-progress-round14.md), unchanged and limited to its earlier inputs. Historical progress remains in [round13 in document38](38-implementation-progress-round13.md), [round 12 in document 36](36-implementation-progress-round12.md), [round 11 in document 34](34-implementation-progress-round11.md), [round 10 in document 32](32-implementation-progress-round10.md), [round 9 in document 30](30-implementation-progress-round9.md), [round 8 in document 28](28-implementation-progress-round8.md), [round 7 in document 26](26-implementation-progress-round7.md), [round 6 in document 24](24-implementation-progress-round6.md), [round 5 in document 22](22-implementation-progress-round5.md), [round 4 in document 20](20-implementation-progress-round4.md), [round 3 in document 18](18-implementation-progress-round3.md), [round 2 in document 16](16-implementation-progress-round2.md) and [round 1 in document 14](14-implementation-progress-2026-09-11.md). Read the current source contracts, verification instructions and remaining descendants before repeating a slice. Each affected structured card also carries an `implementationProgress` entry; its original acceptance and open status remain authoritative.

All cards are open because their full acceptance is incomplete. Many have substantial existing code. A less experienced implementer should read the named files and tests first, preserve working changes, and implement only the missing contract. Do not copy another family's page/writer merely because its label or fields look similar.

## How to execute one card

1. Read its parents in document 02, applicable scenarios and FORM-01–FORM-18 in document 03, the desktop source/mode register, and its existing files. Follow invoked helpers and configuration branches beyond the named form.
2. Write explicit leaf requirement IDs for the selected vertical slice. Record source hash, source lines and caller/constructor/MAIN_BOOK/role/settings/state conditions. Classify which parts already work, which are partial, and which need observation. A TODO is an open requirement, never a passing disposition.
3. Write the expected input, prompts, intermediate values, output and allowed/forbidden table effects **before editing implementation**. Use independent desktop/source vectors. If the outcome is unknown, prepare the capture/fixture and retain the dependency; do not invent a jewelry business rule.
4. Start with one complete mode and meaningful fixture. Trace UI -> actual request -> route adapter -> domain -> tables -> reader -> reopen -> print/report. Add schema changes only where required; deploy/version the migration and update the migration manifest where applicable.
5. Implement the smallest complete path, reuse shared policies with their documented semantics, and wire its UI/error/recovery behavior. Include source selection and read/edit/reversal, not just create. Maintain original IDs, decimal precision and customer/business scope.
6. Execute focused tests and a real-browser journey using the isolated database. Compare stored business rows independently; a response echo or substring test does not establish persistence. Verify one deliberate failure in each changed path using a temporary local test mutation or controlled fault fixture, then restore the implementation.
7. Run the desktop differential and affected documents/reports. Classify any difference, fix its cause and rerun dependent cases. Do not rewrite expected outputs from the new implementation or raise a regression ceiling to erase a defect.
8. Attach the evidence manifest, update the leaf and parent progress records, and leave unsatisfied steps open. Only close the card when its original parent acceptance and cross-module requirements also hold. A code commit or passing mock test is an implementation event, not acceptance.

## Execution order and concrete first slices

Begin X01–X04 to establish scope, measurements, fixtures and trustworthy contracts. X34's CI/evidence infrastructure can start as soon as those definitions exist; its final release acceptance waits for all product evidence. Existing useful domain code need not be frozen while desktop observation is being prepared.

The first implementation queue after the relevant contracts is:

1. Reuse the source/evidence already captured through round 5. Do not reimplement the completed order/report-child, Design component/lifecycle/repeat, Sales/Tour base lifecycle or generic/repair image token slices; read each current progress contract and its remaining descendants.
2. X13/X02: preserve metadata, row, bill and labour previews, session/browser controls and six guarded Sales/Tour mutations. [Document42](42-implementation-progress-round15.md) records the new pure c27 replay/storage/effect/guard composition, the paused verification status and the full nine-step continuation. [Document40](40-implementation-progress-round14.md) and [checkpoint41](41-implementation-checkpoint-round14.json) remain the sealed predecessor. Follow the frozen [finite numeric-write contract](evidence/implementation-2026-09-12-round13/return-next-write-contract/implementation-contract.md), mandatory [stock erratum](evidence/implementation-2026-09-12-round13/return-next-write-contract-review/review.md) and [complete source-effect inventory](evidence/implementation-2026-09-12-round14/return-save-effects-analysis/effects-contract.md). The common literal and221-field seven-row planner still require trusted full raw/physical observation, actual16-field N BAR context, complete retained/absent BAR/temp/remark/DM/OS/child/audit and external-reference ownership, cash/edition authority, fresh normal Update admission and one exact Serializable write with rollback/conflict/recovery proof before endpoint/UI Save. TEMP_BOOK_DATA identity excludes year; cash LedrCash dependencies span years/dates/modes; MAIN_STOCK.SR_NO=2 and ISR_NO comes from incoming SR_NO. Book/row data types remain distinct. Preserve the ISO/text0 adaptation and unproved Windows/storage/provider limits. Revalidate every prefix and zero/omitted/received/BAR-membership transitions. The generic writer, supplied qualifiers and current preview tokens grant no numeric authority. Remaining financial adoption, known mode/ledger/closing, source/tag/child, outgoing/editions, settlement/reversal, reports and desktop/business/production acceptance remain open. The round4/x13-sale-return-33-next-contract.md classification still governs all33 incoming, outgoing, hidden/reference and UAE findings. Implementation remains paused pending the user’s next direction.
3. X11: implement shared help keyboard/search/create behavior from round4/x11-shared-help-next-contract.md and its source hashes. Preserve exact selection identity and event/cached-calculation rules; resolve desktop cancellation differences through independent observation/business acceptance.
4. X14/X17: extend the existing saved-order and repair lifecycles through settlement, reservations, partial delivery, conversion, custody, cancellation/refund and dependent reversals. Preserve nested identities and raw imported values; the basic saved-photo or editor contract does not prove these descendants.
5. X15: implement the dedicated E CRNT entry/write/edit/delete lifecycle and full reports, retaining the saved-document reader and IRN adapter. Do not route credit-note writes through ordinary Sale Return merely because fields overlap.
6. X23: implement explicit Setting lot issue then partial receipt from the existing configured reader/source selectors; prove contention, material conservation, edit/reversal and reports from exact source write sets.
7. X18–X21: finish each contained tag operation with its individual release requirements. X05/X25: reconcile inherited image identity/rights mappings, historical files/MOB_IMAGE, remaining reports and actual devices; preserve the new asynchronous/session/concurrency barriers.
8. Extend the reference method through X07–X10, X12, X16, X22, X24, X26–X29; run X06 comparisons progressively with each family. Complete X30–X32 migration, recovery and variant closure, then X33 all-product acceptance and X34 certification. Discovery and reference environment preparation start earlier, as the original dependencies require.

This ordering is a risk-based implementation queue, not a claim that the first six slices are the only remaining gaps. Every card and original requirement remains mandatory. Start dependencies specify prerequisite contracts/infrastructure; cross-module acceptance still waits for completed dependent behavior.

## Required fixture packs

Create deterministic sanitized packs with stable IDs, seed code, hashes, setup permissions and cleanup. Proposed names below are **deliverables to create**, not existing fixtures. All test databases must be disposable and explicitly identified; running application/customer data is not a fixture.

| Pack | Required contents | Independent checks |
| --- | --- | --- |
| FX-SCOPE | Two tenants; tenant A with two companies, two branches and two fiscal years; deliberately repeated book/voucher/tag/account codes; restricted and permitted roles | Full key sets and untouched sentinel rows in every other scope, including documents and images |
| FX-CONFIG | Two unrelated chart-of-account/book configurations; TOUR ORDER 510, 511 and another configured code; E CRNT 146 plus a second valid series; different rates, rounding, stock and settlement policies | No hard-coded business code assumption; defaults/allowed modes resolve from configuration |
| FX-RICH | Two parent rows, at least two children per applicable child set, distinct HUIDs with leading letters/zeros, distinct source serials and images; unequal weights/rates/customer/karigar amounts | Complete values through payload, DB, reader, unchanged save, single-child edit/removal and parent reorder |
| FX-NUMERIC | Signed midpoint values, zero and omitted overrides, per-piece/per-weight bases, fractional/maximum supported decimals, gold/silver/other, leap-day/month/year date boundaries | Expected values derived from source/desktop vectors at each specified scale, never guessed or rounded with one global tolerance |
| FX-DEPENDENCY | Partially returned sale/purchase, split outstanding allocations, partially consumed order/lot/booking, tag history, unfinished WIP, scheme redemption and active pledge | Remaining quantities/money/fine and valid state transitions; concurrent consume and rollback |
| FX-HISTORY | Two representative sanitized business histories with old years, active/canceled documents, attachments, source references and changed historical settings | Migration keys/values/hashes plus permitted real business continuation using historical and current rules correctly |
| FX-OUTPUT | One-line and multi-page documents, multiple children, long Unicode text, large/negative values, copies, labels, photos, QR/barcodes and printer configurations | Dataset equality first, desktop PDF/image review second, actual physical output where required |
| FX-FAILURE | Lost response after commit, stale edit, canceled lookup, expired session, partial transaction failure, duplicate provider attempt, service/device disconnect and interrupted restore | One accepted effect, no partial rows or lost draft, explicit recovery/status, unchanged unrelated data |

Use deliberately different numbers to reveal swapped mappings. For example, different valid parent weights and child rates are better than filling every numeric field with 1. Validate that the fixture itself obeys the selected desktop mode; do not invent expected totals for an unmeasured formula. Store sensitive raw captures only in the approved ignored evidence area; the public plan contains IDs/hashes and redacted summaries.

## Universal acceptance for each applicable field and action

The original 18-case form matrix and 128 scenario anchors remain required. Expand them for every applicable book, setting, role and branch. For a normal transaction slice, evidence must include:

- New create with rich header, all applicable line/child/tender sets and source references.
- Saved open and unchanged save with equality of **all** persisted business columns and identities, including hidden values; explain allowed audit changes.
- One upstream edit, one override, child insertion/removal/reorder and a saved reopen; assert both immediate calculations and final values.
- Partial consumption/settlement/return, duplicate attempt, exceeded availability and dependent-source edit/delete behavior.
- Permitted cancellation/reversal and exact restoration of stock/money/fine/outstanding/source state.
- Wrong scope/role/period, invalid input, stale version and concurrent contention with zero partial side effects.
- Lost response/retry/session recovery and any required offline behavior.
- Document preview/print/copies and related reports/exports matching the persisted state and independently captured desktop outcome.

For masters, reports, jobs, devices and utilities use their corresponding lifecycle instead of inventing meaningless voucher transitions. Record a reviewed, source-backed not-applicable reason for each nonapplicable universal case. An empty case result does not count as that reason.

## Common evidence contract

Each X-card manifest must link six evidence groups: (1) source/mode contract and hashes; (2) field/action/path matrix; (3) frozen required case IDs; (4) executed tests and complete business-state comparisons; (5) applicable desktop, real-browser, report/device outputs; (6) classified differences and current descendant/parent statuses.

Record task/requirement/case IDs, source/configuration/fixture identity, exact app revision and dirty-tree digest during development, schema/lock/template/build hashes, UTC capture time, local business timezone, runner/test mode, expected and observed outcomes, artifact paths and reviewers. A release needs a reviewed clean candidate and matching deployed image identity. Synthetic and mocked evidence must identify itself and cannot satisfy independent desktop, live device/provider or real-browser/database requirements.

Suggested new leaf record shape:

```json
{
  "id": "REQ-TR_SL_EBILL-ECRNT-edit-line-amount",
  "parents": ["P05-01", "X15"],
  "desktop": {"source": "TR_SL_EBILL.cs", "hash": "to-capture", "mode": "E CRNT"},
  "preconditions": ["saved draft with no locked downstream dependency"],
  "contract": "Source-cited field, trigger, rounding, validation and effect specification",
  "webPath": {"page": "to-verify", "request": "to-verify", "writer": "to-verify", "reader": "to-verify"},
  "expectedCases": ["CASE-ECRNT-EDIT-01", "CASE-ECRNT-REOPEN-01"],
  "implementationState": "unassessed",
  "availabilityState": "partial",
  "engineeringEvidence": [],
  "desktopEvidence": [],
  "businessAcceptance": null,
  "productionAcceptance": null
}
```

The placeholders above are intentionally incomplete examples and must fail any completion gate. Review the actual desktop editing restrictions before adopting the example precondition. Generate real expected case sets from contracts, not from the list of tests that happens to pass.

## Commands and verification discipline

From `imodule-extracted/web`, current commands useful during implementation are:

```sh
pnpm --filter @datacare/api build
pnpm --filter @datacare/api typecheck
pnpm --filter @datacare/web typecheck
node scripts/check-contracts.mjs
node scripts/check-completion-register.mjs --strict
node scripts/check-dead-cells.mjs
node scripts/check-depth.mjs --audit
```

After X03 has provisioned and positively identified the disposable database, inject its `DATABASE_URL` and `MIGRATE_DATABASE_URL` securely, then run the relevant focused suite followed by the required full release suite:

```sh
RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1 pnpm --filter @datacare/api test
pnpm --filter @datacare/web test
pnpm --filter @datacare/core test
pnpm --filter @datacare/web build
pnpm --filter @datacare/web test:browser
pnpm --filter @datacare/web test:routes
node scripts/check-completion-register.mjs --strict --release
node scripts/check-g5-parity.mjs
node scripts/release-certify.mjs --plan
```

`test:browser` and `test:routes` use compatibility mocks. The separately implemented `pnpm test:parity:browser` runs production Next/Fastify against isolated PostgreSQL with zero mocked HTTP requests; round6 checkpoint25 records13 journeys. It is engineering evidence for those fixtures, not independent desktop or whole-product acceptance. Use `node scripts/parity-test-env.mjs -- COMMAND` to run commands in the disposable environment; without `-- COMMAND` it only provisions. API tests require the proper database; never add excludes, set `ALLOW_SKIP_DB_TESTS=1`, remove assertions or change guard ports simply to make the release command green. All 55433-only suites must execute on the verified disposable target.

`--strict --release` and G5 currently fail, correctly. `--plan` only lists release requirements; it is not certification. A `parity-measure --reuse` pass merely checks retained data. Actual release certification needs candidate/evidence configuration, all required environments, and X34's stronger contract. Do not invoke destructive restore/cutover or real provider/customer communication merely to make a review gate pass.

For documentation changes run `python3 parity-plan-2026-09-10/validate_current_review.py` from the repository root after generation. This verifies planning consistency and links; it cannot certify application behavior.
