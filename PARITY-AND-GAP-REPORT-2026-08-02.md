# DataCareNext — Desktop vs Web Parity and Gap Report

**Date:** 2026-08-02 · **Scope:** `imodule-extracted` (desktop decompiled source + `web/` monorepo)
**Method:** independent re-measurement. Every number below was produced by a command run during this
audit against live systems — the desktop SQL Server (`dc-mssql`, databases `Live24`/`Next23-25`/`NextMain`)
and the web Postgres. **No figure is quoted from existing project documentation.** Where my measurement
disagrees with the docs, both are shown.

**Verdict: NOT production-ready.** The foundations are genuinely strong — the database schema is a
verified complete superset and 99.3% of real ledger activity maps to an implemented voucher family. But
there are **three defects that silently write wrong data** and **one that puts the business in legal
jeopardy**, and the parity claim itself rests on a single voucher comparison that fails.

---

## 1. What is genuinely solid (verified true)

These claims were independently confirmed and should be trusted.

| Claim | Verification | Result |
| --- | --- | --- |
| Web schema is a complete superset of desktop | Name-by-name diff of `sys.tables`/`sys.columns` (Live24) against `information_schema` (web) | **TRUE — 0 missing tables, 0 missing columns.** Desktop 145 tables / 5231 columns; web 174 / 6100 |
| 22 voucher families with real activity | `AC_DATA` joined `BOOK_DATA` grouped by `MAIN_BOOK` | **Exact match.** rojmel=3179, WH SALES=38, 1567 distinct vouchers, SL_DATA=190, PR_DATA=74 |
| Report layout baselines pinned | `pnpm report-baselines` | **OK — 254 layouts unchanged** |
| Settings coverage | `pnpm settings:parity` | **OK — 128/128** (35 marked `unknown`) |
| Typecheck | `pnpm typecheck --force` (cache defeated) | **10/10 pass, EXIT=0** |
| Route wiring integrity | Extracted every `get/post/put/del('/path')` from pages and matched against 297 registered routes | **All UI-called paths resolve.** The one apparent miss (`/masters/customers`) resolves via generic `/masters/:name` + `configs.ts:444` |

**Correction to the docs:** `STATE-OF-PARITY.md` says "204 desktop forms". There are 204 `.cs` files but only
**162 are UI forms** (61 `TR_`, 45 `RP_`, 33 `MS_`, 22 `UT_`, 1 MDI shell). The other 42 are support classes
(e-invoice DTOs `Cls*`, `Module_*`, `DcClass`, `Translator`, etc.). Form-count ratios built on 204 are wrong.

---

## 2. Coverage matrix — 161 classified desktop UI forms

(162 UI forms less the `MDI_FORM` application shell, which has no single web counterpart — the web
equivalent is the navigation layout plus `lib/nav.ts`.)

| Category | Total | Covered | Partial | Absent | **Shell (writes wrong data)** |
| --- | --- | --- | --- | --- | --- |
| `TR_` transactions | 61 | 34 | 21 | 3 | **3** |
| `RP_` report launchers | 45 | 1 | 30 | 14 | 0 |
| `MS_` masters | 33 | 26 | 5 | 2 | 0 |
| `UT_` utilities | 22 | 11 | 7 | 4 | 0 |
| **Total** | **161** | **72** | **63** | **23** | **3** |

"Covered" means module + route + page exist and are endpoint-consistent. It is **not** a claim of behavioural
parity except for the 3 forms with an approved contract.

---

## 3. Critical defects

### C1 — Fake e-invoice IRNs are written onto real invoices (legal exposure)

The single most serious finding.

`apps/api/src/modules/einvoice/einvoice.ts:489-502`:

```ts
if (env.GSP_ASPID && env.GSP_PASSWORD && env.GSP_GSTIN && env.GSP_USER && env.GSP_EINV_PWD) {
  return { transport: new CharteredInfoIrnTransport({...}), mode: ... };
}
return { transport: new FakeIrnTransport(), mode: 'fake' };   // ← no NODE_ENV / production guard
```

If **any one** of the five GSP credentials is missing, the system silently substitutes a fake IRN generator.
`FakeIrnTransport` (`einvoice.ts:186-205`) returns a **64-character IRN** (real NIC IRNs are 64 chars), a
12-digit `AckNo`, a QR string and `Status: 'ACT'`. It is deterministic from invoice identity, so it is stable
across retries and **indistinguishable from a government-issued IRN**.

`submitIrn` then persists it regardless of mode:
`UPDATE "SL_DATA" SET "IRN_NO"=$1, "ACK_NO"=$2, "ACK_DATE"=$3 …` plus an `INSERT INTO "E_DATA"`.

Three compounding factors make this reachable in production, not just in tests:

1. `docker-compose.yml:51-56` defaults **all five credentials to empty** (`${GSP_ASPID:-}`).
2. `deploy/.env.example:27-29` documents the **wrong variable names** — `GSP_BASE_URL`, `GSP_CLIENT_ID`,
   `GSP_CLIENT_SECRET` — none of which the code reads. An operator following the deployment guide will set
   variables that have no effect and land in fake mode.
3. `sandbox: env.GSP_SANDBOX !== '0'` — sandbox is the default. Even with correct credentials, forgetting
   `GSP_SANDBOX=0` produces sandbox IRNs that are not legally valid either.

**Business impact:** the shop issues invoices carrying invalid IRNs while believing it is e-invoicing
compliant. Under Indian GST e-invoicing rules an invoice without a valid IRN is not valid tax
documentation — exposure to ITC denial for customers, penalties, and potentially every affected invoice
needing reissue.

**Fix:** fail closed. Refuse to start, or refuse the `/einvoice/irn` route, when `NODE_ENV=production` and
mode is `fake`. Correct `deploy/.env.example`. Require `GSP_SANDBOX` to be set explicitly with no default.

### C2 — Wholesale sale silently posts as a retail sale

`apps/web/app/(app)/txn/wholesale-sale/page.tsx:98` — the entire API interaction of a 306-line form:

```ts
setResult(await post('/sales', body));
```

There is no `wholesaleSale.ts` module and no `POST /sales/wholesale-sale` route. Only the *return* side
exists (`wholesaleSaleReturn.ts`, 51 KB, routes at `txn.ts:3359-3413`).

This is not a cosmetic gap. Desktop `TR_WH_SALE` has a **different write set** from `TR_SALE` — its contract
(`project-memory/contracts/TR_WH_SALE.contract.md`) shows a third *purchase* grid (`mSG_PR[*]`) writing
`PR_FINE`, `PR_LBR_AMT`, `PR_NET_AMT`, `PR_TOT_AMT`, `PR_OTH_AMT`, `SILVER_FINE`, `BAG_WT` — columns the
retail path does not populate. Retail sale instead has an old-gold grid the wholesale form lacks.

The contract is `draft` with **6 unenforced validations and 30 of 30 computed fields carrying no golden
vector**. `Live24` holds 38 real wholesale ledger rows, so this family is in active business use.

**Business impact:** a wholesale voucher entered on the web is stored as a retail sale — wrong book, wrong
voucher type, missing fine-weight and silver columns. Wholesale outstanding, fine-metal position and the
wholesale reports will all be wrong, with no error shown to the operator.

### C3 — Job-work vouchers silently post as karigar vouchers

`apps/web/app/(app)/txn/jobwork-issue/page.tsx` (whole file):

```tsx
return <KarigarForm mode="issue" label="Job-work" />;
```

`apps/web/components/KarigarForm.tsx:116-117`:

```ts
const ep = mode === 'issue' ? '/karigar/issue' : '/karigar/receive';   // endpoint ignores `label`
const title = mode === 'issue' ? `${label} Issue — metal OUT` : `${label} Receive — metal IN`;
```

`label` changes **only the heading**. The endpoint is hardcoded to the karigar pipeline.

Correct job-work routes exist and are fully implemented — `txn.ts:2277` `POST /mfg/jobwork-issue`,
`txn.ts:2320` `POST /mfg/jobwork-receive`, each with GET/PUT/DELETE and an explicit comment
`// Desktop jobwork issue (TR_JDT_REC)`. **They are unreachable from the UI.**

Affects desktop `TR_JDT_REC` and `TR_MFG_KR_ISU_REC` — distinct voucher families with their own books and
numbering. Job-work metal movement is recorded against karigar accounts instead.

### C4 — Two tables are RLS-locked: two features broken, CI is red

Replicating the CI database setup exactly (fresh DB → `prisma migrate deploy` → `rls.sql` →
`setup_roles.sql`), the project's own verification script fails:

```
$ psql "$DATABASE_DSN" -f packages/db/test/verify_runtime.sql
ERROR: tenant policy coverage incomplete: 170 of 172 tables have read/write policy
```

The two tables:

| Table | RLS enabled | RLS forced | Read policies | Write policies |
| --- | --- | --- | --- | --- |
| `ENTITY_IMAGE` | true | true | **0** | **0** |
| `data_repair_run` | true | true | **0** | **0** |

In Postgres, RLS forced with zero policies means **default deny**. Confirmed as `app_user`:

- `SELECT count(*) FROM "ENTITY_IMAGE"` → `0` (silently empty, no error)
- `INSERT INTO "ENTITY_IMAGE"…` → `ERROR: new row violates row-level security policy`

Both tables are used by live code: `apps/api/src/modules/images/entityImage.ts` and
`apps/api/src/modules/utilities/dataRepair.ts`. So **entity images (party/item photos) and the data-repair
console are broken at runtime** — writes hard-fail, reads return empty.

This is the fail-safe direction (no data leak) but it is a functional outage. Both migrations date from
30 July (`20260730030000_entity_image_store`, `20260730010000_data_repair_console`), so this has been broken
for ~3 days. The CI comment at `.github/workflows/ci.yml` notes this exact class of bug previously shipped
with `message_attempt_log` — it has recurred.

### C5 — Admin settings authorisation is weaker than desktop

Desktop dispatches three separately-permissioned forms — `Setting`, `Setting Main`, and `Admin Setting`,
the last explicitly blocked for ordinary users (`MDI_FORM.cs:7519-7534`) — each reading `USER_SET`
independently.

The web exposes all of it through one `GET/POST /settings` under a single `Utilities/Settings` right
(`routePolicy.ts:119-125`), whose aliases include `Admin Setting` and `Setting Main`
(`formCatalog.ts:261`). It is **not** in `ADMIN_ONLY`.

Any user granted the equivalent of either non-admin desktop right can write **every** setting, including
admin-only ones. Separately, the singular desktop name `Setting` is not aliased at all, so a migrated
`USER_SET` row denies rather than maps.

### C6 — GST returns are not desktop-equivalent and not filing-complete

Desktop builds returns from `TAX_DATA` (`RP_GST.cs:1776,2015,2173`). The web builds them from
`SL_DATA`/`SL_DETL` (`gst.ts:179,201`) and `PR_DATA` (`reports3.ts:125-138`) — a different source of truth.

Verified specifics:

- **GSTR-1 ignores the date range.** `scopeSql` consumes only company/location/year (`gst.ts:131-151`), so
  a period selection does not filter the return.
- **GSTR-2 is a single aggregate row** (`reports3.ts:125`), not invoice-level.
- **GSTR-3B is outward-only** — no inward supplies or ITC (`reports.ts:456`).
- **HSN is proxied from `IT_CODE`** (`gst.ts:8`) rather than a real HSN master.
- Desktop fields absent from web GSTR-1: invoice date, reverse charge, e-commerce GSTIN, cess
  (`RP_GST.cs:2264-2291`).
- No GST portal submission path. All GST tests are synthetic pure-function cases (`gst.test.ts:25-94`);
  **no output has ever been compared to desktop.**

---

## 4. The parity claim itself is unproven

This is the heart of the matter. `pnpm g5:parity` is **RED (EXIT=1)** — correctly so.

```
G5_RED parity-diff-2026-08-02T04-47-39-914Z.json does not certify parity
  matched=false (99 field differences)
  cases never entered on the web: purc-035-00004
```

**Exactly one voucher has ever been compared field-by-field** — purchase `035/00001` — out of **1567
vouchers in `Live24`**. That is 0.06% of the population. And it **does not match**:

| Metric | Value |
| --- | --- |
| Tables compared | 6 (+1 desktop-only, +2 web-only) |
| Fields compared | 354 |
| **Field differences** | **99** |
| Rows web wrote that desktop did not | **3** (`BILL_OS_DATA`, `LOT_DETL`, `ROJ_MEL_DATA`) |
| Rows desktop wrote that web did not | 1 (`OP_LDR`) |

Breakdown of the 99 differences:

| Pattern | Count | Assessment |
| --- | --- | --- |
| desktop `0`/`''` → web `NULL` | 58 | Systematic. Web omits column defaults the desktop writes. Affects `SUM`/`AVG`/`COUNT` and report display |
| involves an empty string on one side | 30 | Same class — representation, not arithmetic |
| desktop `NULL` → web has a value | 5 | Web invents values, e.g. `CLR_DATE` set to `2024-04-01` where desktop is NULL |
| desktop value → web empty | 3 | Web drops values, e.g. `LDR_NAME` |
| **genuine numeric mismatch** | **1** | **`PR_DATA.PARTY_FINE`: desktop `0.000`, web `1.000`** |

The `PARTY_FINE` difference is a real arithmetic defect on a fine-metal column — the core quantity in a
bullion business.

### Corroborated posting defect: purchase Rojmel over-post

Two independent methods found the same bug:

1. **Unit test** (currently failing): `database-backed purchase voucher lifecycle > writes no party Rojmel
   row when the purchase is paid in full` → `expected [...] to have a length of 1 but got 2`.
2. **Real desktop diff**: `ROJ_MEL_DATA: desktopRows=1 webRows=2`, extra web row
   `LEDR_KEY=01002024-20250350000102`.

The web writes a spurious party day-book row on a fully-paid purchase. The Rojmel is the shop's primary
daily report, so this is directly visible to the business.

---

## 5. Quality gates — what actually holds

Measured by running each gate:

| Gate | Exit | Reality |
| --- | --- | --- |
| `g5:parity` | **1 — RED** | Correct. 1 voucher compared, 99 differences |
| `register:check` | 0 | **Vacuous.** All **198/198 menu items are `unclassified`**. Passes only because `--strict` is not used |
| `schema:readiness` | 0 | **SKIP** — "no MIGRATE_DATABASE_URL". Never ran |
| `type:parity` | 0 | **SKIP** — "no MSSQL_TYPES dump supplied". Its own output says "this is a SKIP, not a pass" |
| `settings:parity` | 0 | Real pass, 128/128 |
| `docs:refs` | 0 | Real pass, but only **1 verifiable claim** across 22 documents |
| `report-baselines` | 0 | Real pass — 254 layouts unchanged (parsing only, see §6) |

So of seven gates: one genuinely red, two never executed, one vacuous, three meaningful.

### The test suite's green is misleading

| Configuration | Result |
| --- | --- |
| As a developer runs it (no env vars) | **775 passed, 328 skipped — EXIT=0** |
| Clean DB, host TZ (IST) | 53 failed |
| Clean DB + `TZ=UTC` | 22 failed |
| **Exact CI config** (clean DB + `rls.sql` + `app_user` + `TZ=UTC`) | **30 failed, 1073 passed — EXIT=1** |

Two process defects here:

1. **328 of 1103 tests (30%) silently skip** without `RUN_DB_INTEGRITY_TESTS=1`, and the suite still exits 0.
   Every posting-behaviour test is in that skipped set.
2. **Tests are timezone-dependent.** 31 failures were purely `TZ` (differences of exactly 5h30m, e.g.
   `01:16:00.168` vs `06:46:00.168`). CI sets no `TZ` and passes only because runners are UTC. Any developer
   in IST — i.e. the whole team — sees spurious failures.

Of the 30 real CI-condition failures, **29 trace to the two missing RLS policies (C4)** and 1 is the purchase
Rojmel defect. So C4 is a single root cause with a large blast radius.

### No ESLint exists

There is no `.eslintrc*` or `eslint.config.*` anywhere in the repo. `pnpm lint` runs
`scripts/lint-workspace.mjs` — a custom secret-scanner plus `tsc`. Consequently
`react-hooks/exhaustive-deps` never runs, and an entire class of React bugs is undetected — including the
one below.

---

## 6. Reports — the weakest area

| Measure | Value |
| --- | --- |
| Desktop Crystal templates | 254 |
| Templates with a pinned layout baseline | 254 |
| **Templates with proved data equality to desktop** | **0** |
| Templates matching a recognised web binder family | 106 |
| **Templates with no binder family** | **148** |
| Desktop `RP_` launchers covered / partial / absent | **1 / 30 / 14** |

Two things must not be conflated. A pinned layout baseline proves the Crystal template was **parsed**. It
does not prove the web can produce the report. On the strict "same data" test the count is **zero**.

Worse, unrecognised templates **default to `SL_DATA`** (`reportBind.ts:52-55`). For the 148 templates with no
binder family, that means a report renders successfully with the wrong data rather than failing.

### Report filters are broken by a stale closure

`apps/web/app/(app)/reports/[report]/page.tsx:291-309`:

```ts
const run = useCallback(async () => {
  const ep = endpointFor(slug, coYear, acCode, fromDate, toDate, {
    ...filters, lotNo, tagNo,
    ...(slug === 'tag-estimate' ? { direction } : {}),
  });
  …
}, [slug, coYear, acCode]);       // ← fromDate, toDate, filters, lotNo, tagNo, direction all missing
```

The Run button binds this memoised callback directly (`onClick={run}`, line 428). Changing a date or filter
does not recreate the callback, so **Run submits stale filter values**. For statutory reports this means a
user can select a GST period and silently receive a different period's data. This is precisely the bug
ESLint would have caught.

---

## 7. Absent functionality

**Transactions (3):** `TR_SALE_RTN_UAE` (UAE sales return), `TR_SL_PR_ITEM` (item-wise sale/purchase),
`TR_TOUR_ORD` (tour order).

**Utilities (4)** — all substantial:
- `UT_IMPORT` — legacy "Old Software Import" plus wholesale/retail/loan/scheme/estimate repair
  (`UT_IMPORT.cs:1991-2607`). **This is the data-migration path; without it, existing customers cannot be
  onboarded.**
- `UT_EXPORT` — branch replication / data transfer (`UT_EXPORT.cs:650-830`), not CSV export.
- `UT_CUST_ENTRY` — CRM customer capture writing `CUST_DATA`/`CUST_DETL`.
- `UT_AI_TRFR` — FTP tag-image transfer.

**Masters (2):** `MS_DESIGN_BOOK` — backend and RBAC policy exist (`txn.ts:3657-3667`) but **no page**;
`MS_TASTING` — appears orphaned in the desktop too.

**Statutory:** UAE VAT reporting entirely absent (desktop `TaxSummUae`, `RP_TAX.cs:2355-2391`). HUID
statutory register absent — `/reports/tag-stock` omits `HM_ID`/`HM_ID2-4` (`tagStock.ts:13-32`). TCS/TDS is
captured on transactions but there is no register, challan, certificate or 26Q/27EQ return.

---

## 8. Behaviour-contract debt

Only **3 of 11** contracts are approved.

| Contract | Status | Unenforced validations | Computed fields with no golden vector |
| --- | --- | --- | --- |
| TR_SALE, TR_PURC, TR_MLT_PRO | **approved** | 0 | 0 |
| TR_TAG_OPBL | draft | 8 | 33 |
| TR_SALE_ORD | draft | 6 | 30 |
| **TR_WH_SALE** | draft | 6 | 30 |
| TR_TOUR_SALE | draft | 5 | 35 |
| TR_MEMB_ENT | draft | 3 | 4 |
| TR_SALE_RTN | draft | 1 | 25 |
| TR_DHRN_REC | draft | 1 | 7 |
| TR_KR_ISU | draft | 0 | 20 |
| **Total** | 3 / 8 | **30** | **184** |

184 formulas persist a value with no test proving the value is correct. The remaining 50 `TR_` forms have no
contract at all.

---

## 9. Other significant gaps

**RBAC migration will not work as-is.** Authorisation accepts only canonical names plus declared aliases
(`formCatalog.ts:298-305`). At least 26 legacy desktop right names have no alias — `Product`, `Counter`,
`Scheme Mast`, `Location`, `Design`, `Style`, `Item City`, `Address`, `Diamond`, `Point Mast`, `Employee`,
`Tax`, `Group`, `AutoItem`, `Labour`, `Item Touch`, `Labour Disc`, `ItStk Limit`, `Dm Size`, `Mfg Mast`,
`Pwd Update`, `Bank Reconcile`, `Vch ReNumber`, `Whatsapp`, `Sms`, `Setting`. Existing `USER_SET` rows will
deny rather than map — every user loses their permissions on cutover.

**Further authorisation collapses:** WhatsApp and SMS share one right despite separate desktop rights;
`MS_WINDOW_SET` (admin tile mutation) shares a right with `UT_WINDOW`; Hallmark Sale posts `/sales` governed
by the generic Sales Invoice right; Hallmark Purchase and Card/UPI likewise.

**No integration or device has ever been exercised for real.** WhatsApp, SMS, weighing scale, barcode
scanner, webcam, printer, e-invoice GSP, live metal rates — all have production-capable code, all tested
only with injected fakes. `integrationWireContract.test.ts:18-26` states outright that live credentials are
unavailable.

**Backup is not at parity.** The web `/backup` page downloads logical company JSON
(`backup/page.tsx:9-36`) with no restore UI; desktop performs physical `.Bak` backup/restore/attach/detach.

**Single-sample risk.** Every priority here derives from one company and one fiscal year. `Live24` is
scheme-heavy and its six dhrn/loan routines are dead; a pawnbroker would invert the ranking entirely.

---

## 10. Prioritised remediation plan

### Blockers — must fix before any production use

1. **C1 — Make fake IRN impossible in production.** Refuse to boot or refuse the route when
   `NODE_ENV=production` and mode is `fake`. Fix `deploy/.env.example` variable names. Remove the
   `GSP_SANDBOX` default. *Highest priority: legal exposure.*
2. **C4 — Add RLS policies for `ENTITY_IMAGE` and `data_repair_run`.** Unblocks 29 tests and two broken
   features; makes CI green. Smallest fix with the largest effect — do it first.
3. **C2 — Implement wholesale sale, or disable the form.** Until the module exists, remove the page from
   navigation so it cannot silently create retail sales.
4. **C3 — Point job-work pages at `/mfg/jobwork-*`.** The backend already exists; parameterise the endpoint
   in `KarigarForm.tsx:116` instead of hardcoding it.
5. **C5 — Add `/settings` to `ADMIN_ONLY`** and split the three desktop settings rights.

### High — before customer cutover

6. **Resolve the 99-field diff and get one voucher to match.** Start with the 58 zero-vs-NULL cases (likely
   one systematic default-value fix), then `PARTY_FINE`, then the 3 extra rows. Until one voucher matches,
   there is no measured parity.
7. **Fix the purchase Rojmel over-post** — a test is already failing on it.
8. **Scale the comparison** past one voucher. 1567 exist; target the 22 families.
9. **Fix the report stale closure** and **add ESLint** with `react-hooks` rules.
10. **Build `UT_IMPORT`** — without it no existing customer can be migrated.
11. **Correct GST to read `TAX_DATA`**, honour the date range, and validate against desktop output.
12. **Write the RBAC alias migration** with a test proving every legacy `USER_SET` row resolves.

### Medium

13. Make DB tests fail (not skip) when the database is unreachable; pin `TZ` in `vitest.config`.
14. Classify the 198 register items and switch `register:check` to `--strict`.
15. Wire up `schema:readiness` and `type:parity` so they run instead of skipping.
16. Close the 8 draft contracts — 30 validations, 184 golden vectors.
17. Report coverage: 14 absent launchers; make unrecognised templates fail instead of defaulting to
    `SL_DATA`.
18. UAE VAT, HUID register, TCS/TDS returns.
19. Exercise each integration once against a real device/credential and record the evidence.
20. Obtain a second customer database to test the single-sample assumption.

---

## 11. Bottom line

The migration is **substantially further along than a form count suggests** — the data model is exactly
right, and the hard parts (Rojmel derivation, GST rounding, tag identity, settlement) have had real,
measured work done on them.

But it is not ready for a real business, for one reason above all: **three forms accept input and write it
to the wrong place without telling anyone**, and **one manufactures legal tax identifiers when
misconfigured**. Those four defects are worse than missing features, because a missing feature is visible
and wrong data is not.

The good news is that the two highest-severity items are small fixes — an environment guard and two RLS
policies. The larger task is the one the project has been circling for weeks: **compare real vouchers to
the desktop and make them match.** One voucher has been compared and it failed on 99 fields. Until that
number is zero for a representative set, "parity" remains an intention rather than a measurement.

---

### Appendix — reproducing these measurements

```bash
cd /Users/yakshitsavaliya/Desktop/imodule-extracted/web

# Desktop DB access
SQL() { docker exec dc-mssql /opt/mssql-tools18/bin/sqlcmd \
          -S localhost -U sa -P 'ParityProbe#2026x' -C -W -s'|' -h -1 "$@"; }
SQL -d Live24 -Q "SET NOCOUNT ON; SELECT count(*) FROM ROJ_MEL_DATA"     # 3179

# Test suite under exact CI conditions  -> 30 failed / 1073 passed
psql 'postgresql://postgres@127.0.0.1:55433/postgres' -c "CREATE DATABASE parity_ci;"
export TZ=UTC RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1 APP_DB_PASSWORD=ci-app-password-1234
export DATABASE_URL='postgresql://postgres@127.0.0.1:55433/parity_ci?schema=public'
pnpm --filter @datacare/db exec prisma migrate deploy --schema prisma/schema.prisma
psql 'postgresql://postgres@127.0.0.1:55433/parity_ci' -f packages/db/prisma/rls.sql
psql 'postgresql://postgres@127.0.0.1:55433/parity_ci' -v app_password="$APP_DB_PASSWORD" \
     -f packages/db/setup_roles.sql
psql 'postgresql://app_user:ci-app-password-1234@127.0.0.1:55433/parity_ci' \
     -f packages/db/test/verify_runtime.sql          # ERROR: 170 of 172
export DATABASE_URL='postgresql://app_user:ci-app-password-1234@127.0.0.1:55433/parity_ci?schema=public'
pnpm --filter @datacare/api test

# Gates
for g in register:check settings:parity schema:readiness g5:parity \
         type:parity docs:refs report-baselines; do pnpm run "$g"; done
```

**Data handling note:** `Live24` is real customer data. All measurements here are counts and structure only;
no customer names appear in this report.
