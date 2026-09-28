# Fixes, test hardening, and scaled desktop comparison — 2026-08-02

Follow-up to `PARITY-AND-GAP-REPORT-2026-08-02.md`. Every figure here was produced by a command in this
session against the live desktop SQL Server (`Live24`, `Next23/24/25`) and a freshly provisioned Postgres.

**Headline**

| | Before | After |
| --- | --- | --- |
| API test suite (CI conditions) | 30 failed / 1073 passed | **0 failed / 1151 passed** |
| Tests silently skipped by default | **328** (suite still exited 0) | **0** — the run now fails instead |
| `verify_runtime.sql` (tenant isolation) | `ERROR: 170 of 172` | **EXIT=0, 172/172** |
| ESLint | did not exist | **added; 0 findings** |
| Vouchers ever replayed through the web | **1** | **66** |
| Vouchers ever diffed field-by-field | **1** | **66** |
| Field differences across those vouchers | 8199 (first run) | **4349 — 47% fewer** |
| Voucher families with a working replay path | 4 hand-written | generic driver + **3 families**, additive |

---

## 1. The four critical defects

### C1 — Fake e-invoice IRNs (legal exposure)

`irnTransportFromEnv` now **fails closed**. Runtime-proved:

```
production, no creds        -> REFUSED: EInvoiceConfigError: refusing to issue a fake IRN in production…
production, creds no flag   -> REFUSED: EInvoiceConfigError: GSP_SANDBOX must be set explicitly…
production, creds + flag=0  -> transport mode: chartered-info-prod
development, no creds       -> transport mode: fake-development
readiness reports:          blocked-production-no-credentials
```

Also fixed, all of which independently caused the fake path in production:

- `deploy/.env.example` documented `GSP_BASE_URL`/`GSP_CLIENT_ID`/`GSP_CLIENT_SECRET` — **read by nothing**.
  Replaced with the five names the code reads plus `GSP_SANDBOX`, and the "leave blank to use Fake" guidance
  removed (it was actively instructing operators into the unsafe mode).
- `deploy/docker-compose.prod.yml` **never forwarded any GSP variable**, so setting them had no effect.
- `GSP_SANDBOX` no longer defaults, in either compose file. A complete production credential set with the flag
  forgotten used to produce sandbox IRNs, which are not legally valid either.
- The readiness endpoint now uses `gspStatus()`, so it reports the blocked state instead of throwing.

10 new tests in `einvoiceProductionGuard.test.ts`, including assertions over the compose and env-example files
so the deployment defects cannot silently return.

### C2 — Wholesale sale posted as retail sale

The page posted `/sales`. The correct target was established from data, not naming:

- `BOOK_DATA` for `MAIN_BOOK='WH SALES'` has **`BOOK_TBL_NAME = 'RATE_CUT_DATA'`** (book 034, `WSALE`, in use).
- Real voucher 034/00001 writes `RATE_CUT_DATA` 1, `RATE_CUT_ISU` 1, `AC_DATA` 4, `ROJ_MEL_DATA` 1,
  `MAIN_STOCK` 1 — the rate-cut family, which `postRateCut` already implements.

So wholesale sale needed **routing**, not a new engine. The page now posts `/rate-cut`.

The old form model was also wrong, measured across all 15 real wholesale vouchers:

| Field the old form had | Reality |
| --- | --- |
| GST 3% default | `TAX_PRC = 0` on **all 15** |
| "Discount amount" | **no discount column exists** in `RATE_CUT_DATA` |
| — | `SL_FINE`/`TOT_FINE_DR` set on **14 of 15** — it is a fine-metal settlement voucher |

Invented fields removed; `itType`, `convPct`, wastage, rate-type and settlement surfaced instead.

Separately, `POST /rate-cut` was **silently dropping** fields `RateCutInput` declares and every real voucher
populates — `HD_VCH_NO` 15/15, `EMP_CODE` 15/15, `CONV_PRC` 15/15, plus the settlement legs. Now forwarded.

### C3 — Job-work posted as karigar

`KarigarForm.tsx:116` hardcoded `/karigar/*`; `label="Job-work"` only changed the heading. Correct target
established from the desktop: `TR_JDT_REC.cs` writes **MFG_DETL (13), MFG_DATA (9), MFG_IDTL (5)** — the
manufacturing family — and `mfg.ts` cites `TR_JDT_REC.cs:5634/6134-6140/6432`.

Added a `family: 'karigar' | 'jobwork'` prop; job-work pages now reach `/mfg/jobwork-issue|receive`
(`txn.ts:2277,2320`), which existed and was unreachable. Line payload is mapped to `MfgLine`, with the
KR-only grid columns deliberately omitted rather than sent and ignored.

`pageEndpointFamily.test.ts` pins each page to its own endpoint. It was **proved failing first** on the
wholesale case before that fix landed.

### C4 — Two tables RLS-locked

The root cause was not "missing policies". `rls.sql` **drops every policy named `tenant_isolation`** and then
recreates only its own hardcoded list of 170. `ENTITY_IMAGE` and `data_repair_run` create that policy in
their own migrations — `rls.sql` dropped it and never restored it, leaving both forced-with-no-policy
(Postgres default-deny: reads silently empty, writes hard-fail).

`rls.sql` is now **self-maintaining**: it enumerates `tenant_id` columns from the catalogue, so a new tenant
table is protected the moment it exists. It ends with a guard that raises if any tenant table is left
forced-without-policy.

```
NOTICE:  rls.sql: protected 172 tenant table(s)
verify_runtime.sql EXIT=0          (was: ERROR tenant policy coverage incomplete: 170 of 172)
```

This one fix resolved **29 of the 30** test failures.

---

## 2. Test suite hardening

### It no longer passes while skipping a third of itself

53 files gated on `RUN_DB_INTEGRITY_TESTS`. A developer running `pnpm test` got
`775 passed | 328 skipped, EXIT=0` — every posting, RLS and write-set assertion silently absent.

`test/globalSetup.ts` now decides once. All four branches proved:

| Situation | Behaviour |
| --- | --- |
| Database reachable | **auto-enables** both flags — cannot be missed by forgetting a variable |
| No `DATABASE_URL` | **fails** with instructions |
| `DATABASE_URL` set but unreachable | **fails**, naming the connection error |
| `ALLOW_SKIP_DB_TESTS=1` | warns loudly, proceeds |

### Timezone pinned

31 failures were purely an IST/UTC 5h30m offset (`01:16:00.168` vs `06:46:00.168`; `2024-03-31` vs
`2024-04-01`). CI sets no `TZ` and passes only because runners are UTC. `TZ=UTC` is now pinned in
`vitest.config.ts` and defaulted in global setup, so a developer in India gets CI's result.

### ESLint added — and it immediately paid for itself

There was no ESLint anywhere; `pnpm lint` was a custom secret-scanner plus `tsc`. Added `eslint@10.8.0`,
`eslint-plugin-react-hooks@7.1.1`, `typescript-eslint@8.65.0`, exact-pinned per the project's own rule, scoped
to `react-hooks` rules only as errors.

First run found the defect from the audit report:

```
reports/[report]/page.tsx
  309:6  error  React Hook useCallback has missing dependencies:
                'direction', 'filters', 'fromDate', 'lotNo', 'tagNo', and 'toDate'
```

Fixed correctly rather than by suppression: `run` now declares complete dependencies, and the auto-run effect
uses a ref so it still triggers only on report/year change instead of firing on every keystroke. A second
finding in `BookSelect.tsx` was fixed with `useMemo` so the rule is satisfied honestly.

`pnpm lint` now runs `lint-workspace.mjs && eslint . && turbo typecheck`. CI's existing lint step picks it up
with no workflow change.

### One assertion was wrong, not one behaviour

`purchase.lifecycle.db.test.ts` "writes no party Rojmel row when the purchase is paid in full" asserted
`toHaveLength(1)` while the test itself sets `taxRatePct: 3`, so a tax row is correct. Desktop reference —
Live24 purchase 035/00017, `TAX_PRC 3`:

```
ac=00008  it=ORG  dr=22949      metal line 1
ac=00008  it=ORG  dr=16343      metal line 2
ac=00085  it=''   dr=1178.76    TAX account, blank IT_CODE
ac=000636 it=''   cr=40471      party (that voucher is not fully settled)
```

Taxed purchases average **4.20** Rojmel rows (min 3); tax-free **1.75** (min 1). The web was right. The test
now asserts the real property — no `SUPP` party row at `BILL_OS = 0` — plus the metal+tax shape.

---

## 3. Scaling the comparison from one voucher to sixty-six

### Why only one voucher had ever been compared

Three of the harness's four pieces were already generic. The fourth, the **replay**, was hand-written per
voucher: most of each `parity-replay-*.mjs` is a `seed()` that types out masters by hand and a payload with
literal amounts. Cost was a bespoke fixture per case — and a mistyped fixture produces a difference that
looks like a web defect. The purchase replay documents that happening: a hand-typed `BOOK_SNAME` of `'PURC'`
produced a `VCH_TYPE` difference that was an artifact of the fixture.

### Three new tools

**`desktop-footprint-census.mjs`** — the parity target specification, measured across the whole database:
**40 books, 1567 vouchers, 44 distinct voucher-scoped tables**, with per-table rows-per-voucher statistics
and which columns are actually populated per book. Written to
`project-memory/parity/DESKTOP-FOOTPRINT-CENSUS.json`. Counts and column names only — no customer values.

**`parity-import-masters.mjs`** — copies the **real** masters out of the desktop database instead of hand-typing
them: 3006 rows across 17 master tables. Reported `IMPORT_OK` with no schema notes, independently
re-confirming the superset claim (no desktop master column lacks a web counterpart). This is the piece that
removed the per-case fixture cost.

**`parity-replay-generic.mjs`** — reconstructs the API payload from the desktop's own header and detail rows.
Only **input-side** columns are taken (party, date, item, weights, touch, rate, tender); every derived figure
— fine, amounts, tax, rounding, ledger legs, Rojmel, stock — is left to the web, because those are what the
comparison must test. Taking a desktop-derived total would make its comparison vacuous.

### Result

```
replayed 66/91 case(s)
```

All 51 purchases (books 035/036/037/038/041) and all 15 wholesale vouchers (book 034) replayed — including
`purc-035-00004`, which the previous harness reported as *"cases never entered on the web"*, and the wholesale
family, which had no posting path at all before C2.

### The comparison now runs on real evidence, and the differences are down 47%

Both sides were captured and diffed for all 66. The gate is no longer pinned to a single stale artifact.

| Stage | Field differences | Missing rows | Tables web never wrote |
| --- | --- | --- | --- |
| First 66-voucher diff | **8199** | 276 | 108 |
| after CLR_DATE fix (D1) | 8080 | 276 | 108 |
| after OP_LDR exclusion (D2) | 8080 | **212** | **53** |
| after type-based defaulting | 5023 | 212 | 53 |
| **after measured default spec (D3)** | **4349** | 212 | 53 |

**8199 → 4349 field differences: a 47% reduction**, from three evidence-backed changes.

#### D1 — CLR_DATE was stamped on every family

`enrichLedgerLine` set `CLR_DATE` from the row date on every ledger leg. Measured over all 5150 real AC_DATA
rows, the desktop sets it on exactly 345, and the partition is perfectly clean:

```
BANK PAY   130 of 130   (100%)
BANK REC    98 of  98   (100%)
OPSTK      117 of 117   (100%)
20 other families    0        (PURCHASE 0/143, SALES 0/1020, CASH PAY 0/360, CONTRA 0/74, …)
```

130 + 98 + 117 = 345, so nothing else contributes a row. A clearance date belongs to a bank instrument. The
web disagreed with the desktop on 4805 of 5150 ledger rows (93%). Pinned by `clearanceDateBooks.test.ts`.
The pre-existing purchase test asserted the wrong behaviour and was corrected with the evidence recorded.

#### D2 — OP_LDR was polluting every case

Both extractors discover their table set from the schema — every table with `CO_BOOK` and `VCH_NO` — which is
right, because a table the desktop writes and the web does not should surface. `OP_LDR` breaks the assumption
behind that discovery rather than being a missing write:

- 7011 rows across 35 books, all under one `CO_YEAR`;
- in book 035 it holds **77 distinct `VCH_NO` where `PR_DATA` holds 29, and 50 of those 77 do not exist in
  `PR_DATA` at all**;
- its `VCH_DATE` values fall in the **prior** year while the year under comparison is 2024-2025.

It is the year-end/opening ledger snapshot written by the import utility and read by one report. Matching it
on `(book, vchNo)` pulled unrelated prior-year rows into every case, manufacturing 55 "the web never wrote
this table" findings and 64 missing rows of pure noise. Now excluded symmetrically on both sides, overridable
via `PARITY_EXCLUDE_TABLES`.

#### D3 — the web wrote NULL where the desktop writes 0 or ''

The desktop's data layer writes a **complete** row: unused numeric columns get 0, character columns get ''.
The web built each INSERT from only the columns a caller supplied, so everything else became NULL. That single
difference in convention was **5239 of 8080 differences — 65% of everything** — across 135 columns of 8 tables.

Not cosmetic: `SUM` ignores NULL but `COUNT(col)` and `AVG(col)` do not, so a report that averages a weight or
counts populated lines answers differently against NULL than against 0.

**Defaulting by type alone was tried first and the comparison rejected it.** Filling every numeric with 0 and
every character with '' removed 3057 differences but **introduced 828 new ones** across 17 columns the desktop
genuinely leaves NULL (`PR_DETL.CONSI_NO/CONSI_YRCD/CONSI_DBCD`, `PR_DETL.HM_ID2/3/4`, `ITM_COLOR`,
`PR_DATA.HM_TAX_CODE`, `RATE_CUT_DATA.VP_AMT_TYPE/AC_ANGDIYA/TDS_CODE`, …).

A hand-maintained exclusion list would be incomplete by construction — it could only hold columns some
comparison happened to surface. So the specification is **measured** instead, by
`derive-column-defaults.mjs`, which counts NULLs per column over every row of every voucher-scoped table:

| Outcome | Columns |
| --- | --- |
| never NULL, numeric or character → default it | **1894** |
| ever NULL → leave NULL, the desktop uses NULL there | 249 |
| no rows to judge from → leave NULL | 1408 |

Voucher keys (`CO_CODE`, `CO_BOOK`, `VCH_NO`, `AC_CODE`, `LEDR_KEY`, `SR_NO`, …) are never defaulted:
silently supplying `''` for a key would turn "the caller forgot the book" into an orphan row the reports
cannot find, which is worse than a failed insert.

The distinction is per **table**, not per column name — `PR_DETL.ITM_LOT` is never NULL and is defaulted,
`MAIN_STOCK.ITM_LOT` is sometimes NULL and is not. The 828 over-reach differences went to **zero**.

### What the remaining 4349 differences are

| Count | Class |
| --- | --- |
| 1508 | desktop zero/empty → web NULL — columns the spec left out because that table also holds NULLs |
| 1441 | desktop VALUE → web zero — the web does not compute the value at all |
| **618** | **real value mismatch** — the highest-severity bucket |
| 349 | desktop zero → web VALUE |
| 341 | desktop VALUE → web NULL |
| 92 | desktop NULL → web VALUE |

The 618 real mismatches concentrate in a short list, which is where the next work belongs:

```
68  MAIN_STOCK.ITM_QTY      45  MAIN_STOCK.ITM_FINE     32  ROJ_MEL_DATA.LEDR_KEY
48  AC_DATA.FINE_WT         45  PR_DETL.ITM_FINE        27  MAIN_STOCK.SR_NO
23  PR_DATA.PARTY_FINE      23  ROJ_MEL_DATA.LD_CODE    18  AC_DATA.LEDR_KEY / LD_CODE
16  AC_DATA.VCH_TYPE / BOOK_NAME                        14  RATE_CUT_ISU.VCH_TYPE / BOOK_NAME
```

`ITM_FINE`, `FINE_WT` and `PARTY_FINE` are fine-metal quantities — the core measure in a bullion business —
so those are the ones to take first.

### Scaling immediately found three more real defects

Each was invisible to the existing tests because those construct settings by hand, so they only ever
exercised values someone had already decided were valid.

**S1 — `CO_SET.CASH_LIMIT must be positive`.** `CASH_LIMIT = 0` in **every** `CO_SET` row of all four customer
databases, while those shops post cash freely (Live24: 133 CASH PAY, 56 CASH REC). 0 means "no ceiling". The
loader threw, so `resolveSettingsBehavior` failed for every real installation. The pre-existing test
"CASH_LIMIT zero disables only the cash ceiling" passed `cashLimit: 0` straight to the consumer, bypassing the
loader — it proved the consumer, never the producer. **Fixed.**

**S2 — `CO_SET.FINE_STK_TYPE is invalid: F`.** The enum listed `A/N/G`, taken from the values one *report*
accepts (`RP_STOCK_FINE.cs:2963-2977`). The desktop **stores and defaults to `F`**
(`MS_OPNCOMP.cs:765-767`), and `F` is present in all four databases (Live24 F,F · Next23 F,A · Next24 F,F ·
Next25 F,A,A). Widening is behaviour-neutral: `fineStockValue` special-cases only `A` and `G`. **Fixed.**
A test that listed `F` as its example of an *invalid* value was corrected to use `X`.

Both are pinned by `settingsRealValues.test.ts`, which asserts against values taken from real installations.

**S3 — rate-cut rejects the desktop's own voucher shape. NOT FIXED — needs your decision.**

Book 064 (`RATE CUT`, 25 vouchers) has **zero rows in every detail table**:

```
RATE_CUT_ISU: 0    RATE_CUT_REC: 0    RATE_CUT_ISU_REC: 0    SL_DETL: 0
```

The value is carried entirely in the header — `FINE_RATE`, `TOT_FINE_DR`, `CR_AMT`:

```
vch=00001  fine_rate=7578     tot_dr=36.200   cr_amt=274324
vch=00002  fine_rate=7490     tot_dr=42.240   cr_amt=316378
vch=00003  fine_rate=7360.38  tot_dr=7.914    cr_amt=58250
```

That is semantically what "cut the rate" means: price metal already issued, with no new item lines. But
`rateCut.ts:585` throws `rate-cut requires at least one line`, so **the web cannot post 25 of 25 real
rate-cut vouchers**.

I have not changed this. Allowing header-only rate-cut alters posting semantics for money and metal, and the
ledger/Rojmel legs for a line-less voucher need to be derived from the header settlement rather than from
lines. That is a design decision about your accounting, not a mechanical fix. Note the wholesale book (034)
is unaffected — it does carry `RATE_CUT_ISU` lines and replays cleanly.

---

## 4. Verification

All measured this session, clean database, `TZ=UTC`, exact CI role setup (`app_user` under forced RLS):

```
API tests            138 files / 1151 tests / 0 failures      EXIT=0
typecheck            10/10 tasks                              EXIT=0
pnpm lint            lint-workspace + eslint + typecheck       EXIT=0
format:check         all matched files clean                   EXIT=0
verify_runtime.sql   172/172 tenant tables policed             EXIT=0
register:check       REGISTER_OK                               EXIT=0
settings:parity      SETTINGS_PARITY_OK 128/128                EXIT=0
docs:refs            DOC_REFS_OK                               EXIT=0
report-baselines     REPORT_BASELINES_OK 254 unchanged         EXIT=0
g5:parity            G5_RED — 66 cases, 4349 differences       EXIT=1   <- correctly red, on real evidence
```

`g5:parity` is red because the vouchers genuinely do not match yet. The difference from before is what it is
red *about*: it was pinned to one stale artifact of a single voucher, and now reports a measured 66-voucher
comparison that is re-runnable end to end.

`docs:refs` caught stale pinned claims twice during this work (test count 134 → 137 → 138) — the gate behaving
exactly as intended.

---

## 5. What remains

**Needs a decision from you**

1. **S3 header-only rate-cut** — 25 of 25 real vouchers unpostable. Design question about how the ledger and
   Rojmel legs derive from header settlement when there are no lines.

**The next measurable work, in value order**

2. **618 real value mismatches**, concentrated in fine-metal quantities: `MAIN_STOCK.ITM_QTY` (68),
   `AC_DATA.FINE_WT` (48), `MAIN_STOCK.ITM_FINE` (45), `PR_DETL.ITM_FINE` (45), `PR_DATA.PARTY_FINE` (23),
   plus key/classification columns `LEDR_KEY`, `LD_CODE`, `VCH_TYPE`, `BOOK_NAME`. Fine weight is the core
   measure in a bullion business, so this is the bucket that matters most.
3. **1441 "desktop VALUE → web zero"** — columns the web does not compute at all, led by `PR_DETL.OLD_SRNO`,
   `RATE_TYPE`, `WITH_STOCK`, `IT_DESC`, `PR_CODE`, `APR_ISU`, `EMP_ISU` and `MAIN_STOCK.ISR_NO/KR_*`.
4. **212 missing rows and 53 desktop-only tables**, led by `ROJ_MEL_DATA` (68 missing), `AC_DATA` (62),
   `MAIN_STOCK` (22), `PR_IDTL` (20); and the web over-writing `LOT_DETL` (78) and `BILL_OS_DATA` (51).
5. Add family builders for the remaining families. The registry is additive — `MEMB ENTRY` (841 vouchers) and
   `CASH PAY/REC` (189) are the largest by volume.
6. Sales replay needs vouchers applied in **dependency order**: a tagged sale requires the tag to exist, so
   the voucher that created it must be replayed first. This is why `sale-032-00001` failed with
   `tag not available for issue`, which is a harness ordering gap, not a web defect.

**Still open from the audit report**

7. GST returns read `SL_DATA`/`PR_DATA` where the desktop reads `TAX_DATA`; GSTR-1 ignores the date range.
8. 198 of 198 register items unclassified; `schema:readiness` and `type:parity` still skip rather than run.
9. UAE VAT, HUID register and TCS/TDS statutory outputs absent.
10. No integration or device has ever been exercised against a real credential.
