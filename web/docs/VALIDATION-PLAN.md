# Validation plan: proving the web application behaves like the desktop

Goal: take the web replacement from "extensively tested against the decompiled source" to "demonstrably
equivalent to the running desktop application, and safe to run a real jewellery business on".

This plan is written against measured facts, not impressions. Every number below was taken from the repository
on 2026-07-30 and the command that produces it is named, so any claim here can be re-checked.

---

## Where we actually are

| Measure | Value | How it is produced |
|---|---|---|
| API tests | **907** across 119 files (74 unit, 45 database-backed) | `cd apps/api && npx vitest run` |
| Web tests | 18 across 3 files, plus 1 browser smoke suite | `pnpm test`, `pnpm test:browser` |
| Lint | 491 files, 0 violations | `pnpm lint` |
| Build | 7 packages | `pnpm build` |
| Routes | 371 | static analysis, pinned twice in `routePolicy.test.ts` |
| Schema | 170 tables, 15 migrations, forced RLS on 173/173 tenant tables | `pnpm schema:readiness`, `/ops/invariants` |
| Configuration | 128/128 keys typed and reachable | `pnpm settings:parity` |
| Desktop-declared schema | 155/155 tables, 3241/3343 columns (96.9%) | `pnpm schema:readiness` |
| Report layouts | 254 baselines unchanged | `node scripts/report-baselines.mjs` |
| Control coverage vs desktop | **73.2%** (3333 / 4555) | `feature_gap_audit.py` |
| Desktop comparison | **none has ever been run** | `pnpm g5:parity` → RED |

Control coverage by family:

| Family | Forms | Controls | Present | |
|---|---|---|---|---|
| Transactions | 61 | 2278 | 1858 | 81.6% |
| Masters | 33 | 670 | 523 | 78.1% |
| Reports | 45 | 1049 | 633 | 60.3% |
| Utilities | 22 | 514 | 295 | 57.4% |

### The most useful thing this measurement says

**Only 5 desktop forms have no web route at all, and all 5 are already formally waived** — the two UAE variants,
`MS_TASTING`, `UT_WEB_CAM`, `MS_HELP`. There is no unrouted, unwaived business form.

So this is *not* a build-out problem. It is a **fidelity and verification problem** across 54 routed forms that
sit below 70% control coverage. That distinction sets the shape of everything below: the work is proving and
completing behaviour on screens that already exist, not creating screens.

### Two foundation defects found while preparing this plan

**Four gates are not wired into CI.** `settings:parity`, `schema:readiness`, `g5:parity` and `report-baselines`
exist and pass, but `.github/workflows/ci.yml` never invokes them. A gate that only runs when someone remembers
is a checklist item, not a gate — and every regression claim in this plan depends on them running unattended.

**CI still calls the harness I proved defective.** Line 192 runs `g5-compare.mjs`, which has six demonstrated
defects that each made the comparison unable to fail (dates always equal, 3-decimal rounding, NULL equal to
blank, sum-only numeric checks, case folding, and the table set taken as the intersection of both schemas so a
missing write was discarded). Line 196 then checks for the old `latest.json` artifact. If that job ever went
green it would mean nothing.

Both are small and unambiguous. They are Phase 0 and should be done before anything else in this plan is
trusted.

---

## Phase 0 — Make the gates real (half a day)

1. Add `settings:parity`, `schema:readiness`, `report-baselines` to the main CI job.
2. Repoint the G5 job at `parity-extract-mssql.mjs` → `parity-compare.mjs` → `check-g5-parity.mjs`, and delete
   `g5-compare.mjs` so the defective path cannot be invoked again.
3. Make the G5 job's absence of credentials produce an explicit **skipped-with-reason**, never a pass.

**Evidence:** a CI run where each gate appears with its own line of output. **Fails if:** any gate is absent, or
the G5 job reports success without a desktop capture.

---

## Phase 1 — Establish the desktop baseline (the centrepiece)

Everything else in this plan is calibration. This is measurement. Until it exists, the honest statement about
the web application is "it matches what we read in the decompiled source", which is not the same claim.

The harness is built and its own correctness is established: 24 unit tests, and an end-to-end proof on a real
voucher where a shifted date, one rupee, a fourth decimal, a dropped table and a dropped row were each caught
while identical bundles passed. What is missing is the **input** — one session on the Windows box.

### 1.1 First capture (1 session)

Five cases, chosen because between them they exercise metal arithmetic, tax splitting, the ledger, and
settlement:

| caseId | Exercises |
|---|---|
| `sale-cash-single-line` | fine weight from touch, making charge, CGST/SGST split, cash leg |
| `sale-credit-old-gold` | old-gold valuation, party ledger, credit posting |
| `purchase-basic` | purchase posting, input tax |
| `sale-return` | reversal semantics against a specific bill |
| `rate-cut` | money↔metal settlement, `RATE_PAR` basis |

Procedure: `web/docs/PARITY-WINDOWS-PROCEDURE.md`. Agent prompt: `web/docs/WINDOWS-AGENT-PROMPT.md`.

**Evidence:** a `parity-diff-*.json` artifact carrying a real `Microsoft SQL Server @@VERSION` banner.
**Fails if:** any field differs, any row is missing, any table is desktop-only, or a case was entered on one
side only.

### 1.2 Interpret the first difference correctly

Expect differences on the first run. Diagnose in this order — the first two are far more common than a defect:

1. **Different input.** Same date? Same rate? Same touch?
2. **Different configuration.** Rounding, labour type and rate basis come from `CO_SET`/`CO_SET_NEW`. If the
   desktop company is configured differently, the two *should* disagree. Capture the desktop's settings screens
   as part of the session.
3. **Real divergence.** The artifact names the field and both values, which locates the desktop source line.

### 1.3 Widen to the full transaction surface (4–6 sessions)

Then extend case-by-case across the 61 `TR_*` forms, prioritised by money at risk:

- **Tier A** (must be exact): sale, sale return, purchase, purchase return, rate cut, cash/bank, journal,
  opening balances, tag opening. These move money and metal and post to the ledger.
- **Tier B**: manufacturing issue/receive, karigar, melting, repair, tag split/weight-diff, physical stock.
- **Tier C**: membership/scheme, dhrn loans, VP/Angadia, tour, bullion.

**Target:** every Tier A form has at least three cases — a simple one, one with old gold or a discount, and one
edited after saving (edit is where write-set defects hide).

---

## Phase 2 — Layered testing, and what each layer can and cannot prove

Each layer answers a question the others cannot. Stating the limit of each is what stops a green suite from
being mistaken for correctness.

### L1 — Arithmetic golden vectors
**Method:** input → expected output pairs transcribed from desktop source, with the source line cited.
**Current:** 27 distinct vector ids across settlement (20), bill profit (13), purchase lines, old gold,
rounding.
**Gap:** thin relative to the arithmetic surface. Fine weight, wastage, labour by four types, tax rounding modes
and the five `RP_EMP` commission modes have no explicit vector set.
**Proves:** a formula matches the source. **Cannot prove:** that the formula is reached, or that its inputs are
loaded correctly.
**Target:** ≥120 vectors, every one citing a file and line.

### L2 — Write-set equivalence (database-backed)
**Method:** post a voucher through the real service, then assert the exact rows in every table it touches,
including that a delete leaves zero `DELETE_DATA` rows and an edit preserves `MAIN_USER` and time-of-day.
**Current:** 45 database-backed files; all 11 major voucher families have a lifecycle test.
**Proves:** the web writes what we believe it should. **Cannot prove:** that belief matches the desktop.
**Target:** every Tier A form has create / read-back / edit / delete asserted, plus a negative control per
family proving the test fails when a table is dropped from the write set.

### L3 — Cross-application comparison (Phase 1)
**Proves:** the web writes what the desktop writes. This is the only layer that can.
**Limit:** only for the cases actually entered. Coverage is exactly the case list, so the case list is the
claim.

### L4 — Report data parity
**Method:** Crystal exports to CSV; the web exports CSV/XLSX. Compare **rows and totals**, not pixels.
**Current:** 254 layout baselines detect regressions in the web's own renderer only. Reports are the weakest
family at 60.3%, and `RP_ALL` — a launcher whose 72 buttons *are* the report families — sits at 23/91.
**Not claimed anywhere:** Crystal pixel parity. It should not be inferred from the baselines.
**Target:** for the 20 most-used reports, a data-level comparison per report with matching control totals
(count, sum of amount, sum of fine weight). Extend the bundle differ to accept CSV pairs so the same
row-pairing and precision rules apply.

### L5 — Workflow, keyboard and UI behaviour
**Method:** browser suite driving real pages.
**Current:** one smoke suite covering auth, scope, global F-keys, all Ctrl chords, tag images, sales lifecycle,
keyboard grids, the four repair stages, physical stock, dashboard, logout.
**Gap:** a shop operator works almost entirely by keyboard. Per-form tab order, Enter-to-advance, F-key
behaviour *inside* a grid, and the exact focus target after save are only partly covered.
**Target:** for every Tier A form, an assertion of the focus sequence a real operator uses, derived from the
desktop's tab indices.

### L6 — Configuration matrix
**Method:** the same voucher under different `CO_SET`/`CO_SET_NEW` values.
**Why it matters more than it looks:** rounding mode, labour type, rate basis and balance-sheet type change
persisted values. A suite that only tests defaults tests one shop.
**Current:** rate basis is parameterised over G/T/K; rounding and labour type are covered in places.
**Target:** a matrix over the ~19 enum settings that demonstrably change a write, each with its desktop source
citation, and a negative control proving the test notices when the setting is ignored.

### L7 — Security and tenancy
**Method:** database-level isolation tests under the restricted role, plus route policy static analysis.
**Current:** forced RLS on 173/173 tenant tables; audit log append-only; every route carries an authorization
policy or the request 500s; a registry-wide assertion that any table with `tenant_id` has forced RLS and a
policy.
**Recent finding worth remembering:** `message_attempt_log` was created *after* the blanket RLS migration and
therefore escaped it. On a fresh deployment it had no RLS, and two queries filtered on `idempotency_key` alone
— a colliding key gave a cross-tenant read *and* write. Found only by provisioning a fresh database and diffing
against the working one.
**Target:** make "provision a fresh database from the migration chain and diff it against the running one" a
recurring gate, not a one-off. That is what caught this.

### L8 — Performance and scale
**Current:** a load profile script exists; no stated targets.
**Method:** seed a realistic year — 50k sale lines, 20k tags, 200k ledger rows — and measure the operations a
counter actually waits on.
**Target (to be agreed with the shop, these are proposals):** save a sale ≤ 800 ms p95; tag lookup ≤ 150 ms p95;
day book for a month ≤ 3 s; trial balance for a year ≤ 5 s; balance sheet ≤ 8 s. Fail the gate on regression
beyond 20%.

### L9 — Legacy migration rehearsal
**Blocked:** needs a real, sanitised customer database.
**Method when unblocked:** export → quarantine → preflight → staging → reconcile, with **monetary and
metal-weight control totals per table, per book and per account**, and exact-decimal mapping (scaled integers,
never IEEE-754 floats).
**Gate:** `migration-readiness` stays red until a signed rehearsal against real data exists. A rehearsal against
synthetic data earns no credit — the same rule that keeps `g5:parity` honest.

### L10 — Hardware and external integrations
**Blocked:** scale, scanner, webcam, printer (no device); WhatsApp/SMS/GSP (no credentials).
**Built:** interfaces, protocol parsing, readiness probes.
**Method when unblocked:** a conformance run per device that records raw I/O to an artifact, so a claim of "the
scale works" is backed by the bytes it sent. For messaging, one live send per channel with the provider's
message id retained.
**Rule:** never fabricate a reading or a connection. A device absent is reported as absent.

### L11 — Operator acceptance
**Method:** the shop's own staff run a full day's trading on the web app with the desktop as the reference,
entering everything twice for a week.
**Why it is not optional:** it is the only layer that surfaces the things nobody wrote down — the sequence a
particular counter uses, the report a particular owner reads every morning, the keyboard habit that makes the
difference between usable and unusable.
**Evidence:** a signed daily reconciliation — closing cash, closing metal by group, and voucher counts matching
between the two systems.

---

## Phase 3 — Close the fidelity gap on the 54 weak forms

Priority is absolute absent-control count weighted by business risk, not percentage:

| Form | Present | Absent | Nature of the gap |
|---|---|---|---|
| `RP_ALL` | 23/91 | 68 | a launcher; its buttons **are** the absent report families |
| `UT_SETTING_MAIN` | 55/113 | 58 | settings-screen grids and buttons (all 128 config values are already reachable) |
| `UT_IMPORT` | 13/42 | 29 | legacy import — overlaps L9 |
| `TR_SALE` | 54/80 | 26 | **Tier A, highest risk on this list** |
| `UT_WHATSAPP` | 22/45 | 23 | blocked on credentials |
| `UT_SETTING` | 37/59 | 22 | as `UT_SETTING_MAIN` |
| `RP_OS` | 22/43 | 21 | outstanding report variants |
| `RP_CUST_CRM`, `RP_TAG_ESTMATE`, `RP_TAG` | | 18/18/17 | report filter panels |

Order of work: **`TR_SALE` first** (it moves money and is Tier A), then the report families behind `RP_ALL`,
then the settings surfaces, then the credential-blocked ones last since they cannot be finished anyway.

---

## Definition of production ready

All of the following green, in CI, unattended:

| Gate | Status today |
|---|---|
| `pnpm lint`, `pnpm build`, `pnpm test`, `pnpm test:browser` | green, in CI |
| `pnpm settings:parity` | green, **not in CI** |
| `pnpm schema:readiness` | green, **not in CI** |
| `report-baselines` | green, **not in CI** |
| `pnpm g5:parity` — Tier A forms, ≥3 cases each | **RED** |
| report data parity — top 20 reports | not built |
| performance gate against agreed targets | not built |
| `migration-readiness` — signed rehearsal on real data | **blocked** |
| device conformance artifacts | **blocked** |
| live send per messaging channel | **blocked** |
| 5 consecutive clean operator reconciliation days | not started |

Plus: a written waiver, signed, for anything deliberately not achieved — as already exists for the UAE variants.

---

## Sequencing

```
Phase 0  gates into CI, delete the defective harness          half a day
Phase 1  first desktop capture + interpret                    1 session      <- unblocks everything
Phase 2  L1/L2/L6 deepening in parallel with Phase 1 widening 2-3 weeks
Phase 1' Tier A/B/C capture rounds                            4-6 sessions
Phase 3  TR_SALE, then report families                        3-4 weeks
L4       report data parity                                   1-2 weeks
L8       performance targets and gate                          1 week
L11      operator acceptance                                   1-2 weeks, in parallel
L9/L10   migration and hardware                                on unblock
```

The critical path runs through Phase 1. Nothing downstream can be certified without it, and it costs one
session on a machine that already exists.

## What blocks what, and what unblocks it

| Blocked | Needs | Who |
|---|---|---|
| desktop comparison | one session on the Windows box | already possible — nothing outstanding |
| report data parity | Crystal CSV exports from the desktop | same session |
| legacy migration | one sanitised customer database | owner |
| hardware conformance | physical scale, scanner, printer | owner |
| messaging | WhatsApp/SMS/GSP credentials | owner |
| performance targets | agreement on acceptable numbers | owner |
| operator acceptance | a week of the shop's time | owner |

## Standing rules for this work

These exist because each one has already caught something real:

- **A gate must be demonstrated failing before it is trusted.** Every gate here has an inverted control.
- **No gate may lower its own denominator.** Denominators come from the desktop or the schema, never from the
  web's own catalogue. An earlier "100% field coverage" claim was measured against the fields the web already
  accepted, which made every unimplemented control invisible.
- **Positive attestation, not absence of a marker.** The G5 gate first rejected artifacts *containing* the word
  "synthetic"; the provenance field was being dropped, so it certified synthetic data as real. It now requires a
  genuine SQL Server banner. Absence tests fail open.
- **A proof of the instrument is not evidence about the applications.** Synthetic bundles are deleted after use.
- **Never weaken a test to make it pass.** Fix the defect at the root.
- **Report what could not be verified.** An honest blocker beats a partial result presented as complete.
