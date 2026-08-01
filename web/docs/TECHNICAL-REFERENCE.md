# DataCareNext web — technical reference

**What this is.** The architecture, conventions and hard-won schema facts of the web application. Read this
to understand _how the system is built_. For _how to verify it_, see `VERIFICATION-REFERENCE.md`.

**Last verified against the tree:** 2026-08-01.

---

## 1. Shape of the system

A pnpm monorepo. Desktop Windows Forms + Crystal Reports + SQL Server → web with **behavioural parity**:
the stack changes, the behaviour must not.

```
web/
  apps/api/          Fastify + Prisma. 31 module directories, ~434 TS files
  apps/web/          Next.js app router. 101 pages
  packages/core/     pure calculation (billTotals, rounding, labour) — BUILT separately
  packages/db/       Prisma client + withTenant
  scripts/           9 gate scripts
  docs/              this and its siblings
```

| Measure                         | Value             | Command                                                     |
| ------------------------------- | ----------------- | ----------------------------------------------------------- |
| API tests                       | 1054 in 124 files | `(cd apps/api && npx vitest run)`                           |
| DB-backed tests                 | 47                | `ls apps/api/test/*.db.test.ts \| wc -l`                    |
| Lint surface                    | 502 source files  | `pnpm lint`                                                 |
| Policed route strings           | 383               | pinned twice in `apps/api/test/routePolicy.test.ts`         |
| `route()` policy entries        | 140               | `grep -c "route(" apps/api/src/modules/rbac/routePolicy.ts` |
| Report slugs                    | 48                | `REPORT_BUILDERS` in `routes/txn.ts`                        |
| Build targets                   | 7                 | `pnpm build`                                                |
| Desktop menu items to reproduce | 198               | `NextMain.MENU_DATA`, 13 tabs — the authoritative surface   |
| Classified in the register      | 0 of 198          | `pnpm register:check`                                       |

**`packages/core` is built separately.** Vitest transpiles `apps/api/src` on the fly but **not** that
package. A change there needs `pnpm --filter @datacare/core build` or tests silently run against the old
output. A control once "passed" twice against deliberately broken code for this reason.

---

## 2. Multi-tenancy and row-level security

Every business table carries `tenant_id varchar(24)`. **172 tenant-scoped tables have RLS enabled _and_
forced, each with a policy**, asserted on a freshly provisioned database rather than the working one
(`pnpm fresh:provision`).

```ts
await withTenant(prisma, tenantId, async (tx) => {
  /* all statements here */
});
insertRowTx(tx, 'TABLE', tenantId, row); // tenant is a SEPARATE argument, not a row field
```

### The two faces of the RLS trap

Both produce **plausible wrong answers rather than errors**, and both have cost real time:

| Client               | Outside a tenant context   | Symptom                                             |
| -------------------- | -------------------------- | --------------------------------------------------- |
| `app_user` (runtime) | RLS filters everything out | **zero rows, no error**; `DELETE` is a silent no-op |
| `postgres` (owner)   | RLS is **bypassed**        | **every tenant's rows**, silently                   |

The owner case is the less familiar one and it is worse. A year-end test passed the owner client to a module
that computes per-account closings; `withTenant` set a context the owner ignored, the query summed every
tenant's `AC_DATA`, and an account seeded with 1,000 reported an opening balance of **637,842.82**.

**Rule: pass the runtime client to the code under test; use the owner only for setup and inspection.**
When a count is unexpectedly zero _or_ absurdly large, suspect the client before the code.

`tenant_id` is `varchar(24)` — tests use short kebab tenants, never UUIDs.

---

## 3. Voucher posting

One transaction per voucher. `postVoucherTx` takes a ledger and a set of writes:

```ts
await postVoucherTx(tx, tenantId, {
  ledger: { table: 'AC_DATA', lines: ledger },
  bookName,
  writes: [{ table: 'SL_DATA', rows: [header] } /* … */],
});
```

**`postVoucherTx` does NOT add voucher key columns.** Spread `...key` onto every row yourself, or you write
orphans with NULL `CO_BOOK`/`VCH_NO` that no report can find.

**Edit = delete the write set + rewrite.** Zero `DELETE_DATA` rows; `MAIN_USER`, `HD_VCH_NO` and
time-of-day are preserved. Every module keeps a `WRITE_TABLES` list that is both its write set and its
reversal set — **a table added to one must be added to the other**, or the next post collides on the
primary key.

**Settings, rounding, fine, rate-basis and labour policies load server-side per transaction**, never from a
request body.

### `BOOK_DETL` is a per-book account SLOT table

Not one account per book — a numbered slot per purpose, and **the numbering differs per book**:

| Slot | Book 026         | Book 064               | Book 020 |
| ---- | ---------------- | ---------------------- | -------- |
| 1    | `00003` sale     | `00003` sale           | `00001`  |
| 2    | `00001` cash     | `00008` purchase       | `00020`  |
| 3    | `00057` kasar    | `00001`                | —        |
| 5    | `00076` discount | `00042` purchase kasar | —        |
| 12   | —                | `00098` kasar fine     | —        |

Always `resolveBookAccountTx(tx, scope, bookPolicy, slotNo)` — `shared/bookPolicy.ts:97`. Hardcoding a slot
number from one book breaks on another; that produced a wrong contra account across an entire plan draft.

---

## 4. The Rojmel (day book) subsystem

`ROJ_MEL_DATA` is a second projection of every voucher showing **metal beside money**, which `AC_DATA`
cannot because it has no weight columns. The desktop binds it to `F11`.

All builders live in `shared/rojmel.ts` (1159 lines, 8 builders), every rule carrying its evidence.

| Builder                | Families                                        |
| ---------------------- | ----------------------------------------------- |
| `buildSaleRojmel`      | sale, estimate, purchase (inward), sales return |
| `buildMoneyRojmel`     | scheme instalment                               |
| `buildCashRojmel`      | cash receipt and payment                        |
| `buildJournalRojmel`   | contra                                          |
| `buildRateCutRojmel`   | rate cut                                        |
| `buildOrderRojmel`     | sales order                                     |
| `buildSchemeAdjRojmel` | scheme maturity / advance adjust                |
| `buildFineJvRojmel`    | fine JV                                         |

**Coverage: 3085 of 3179 real rows — 97%.**

### `LEDR_KEY` is the entire primary key

```
CO_CODE(2) LC_CODE(2) CO_YEAR(9) CO_BOOK(3) VCH_NO(5) TYPE(2) [lineNo right-aligned in 10]
```

Real 33-char example, reproduced byte-for-byte by a unit test:
`'01002024-20250270000101         1'` — nine spaces before the `1`.

```sql
ROJ_MEL_DATA_pkey (tenant_id, LEDR_KEY)
```

**Consequences.** A row type appearing more than once per voucher **must** carry a line number, or two rows
collide with `23505`. And `ROJ_MEL_DATA` must be in every DB test cleanup list. **This bit four times**
before a sweep added it to 20 files.

### Column semantics, all measured

| Column     | Meaning                                                                                     |
| ---------- | ------------------------------------------------------------------------------------------- |
| `IT_TYPE`  | the **metal** — `G` gold, `S` silver, `O` other, `A` a money row. _Not_ a stock/amount flag |
| `SIGN`     | `-` metal out, `+` metal in, blank on `A` rows                                              |
| `LD_CODE`  | the **contra** account                                                                      |
| `AC_NAME`  | denormalised to the **party's** name on every row, even tax and sales rows                  |
| `ITM_FINE` | fine weight. **`RP_ROJMEL`'s gold/silver summaries filter on this, not `ITM_GWT`**          |

### Two account-order conventions coexist

Fine/metal rows name the **party** in `AC_CODE`; amount rows are the **reverse**. Getting this backwards
misfiles every row.

### A money row can carry weight, deliberately

Old metal taken in part-exchange has `IT_TYPE 'A'` **and** populated weights — so the day book shows metal
taken in exchange **without counting it as a metal sale**. The report's buckets key on `IT_TYPE`, so
labelling it `'G'` would double-count the shop's gold.

### Two desktop oddities reproduced on purpose

**Fine double-counted on an overpaid purchase.** When `PR_BILL_OS < 0`, rate cut writes the fine on both
types `01` and `13` — verified on both occurrences. Very likely a desktop defect; reproduced because parity
with the desktop's report output is the requirement, and a test pins it. **Changing it needs an owner
decision.**

**Round-off keeps its sign in `DR_AMT`** rather than an absolute value, because a report summing `DR_AMT`
depends on it.

---

## 5. Schema facts that have caused real defects

Types were read from `information_schema`, never assumed.

⚠️ **Correction, and it changes how the rest of this section reads.** These varchar-where-you-expect-numeric
columns were described here as schema facts to work around, with the implication that they mirror the desktop.
**They do not.** Measured against the real database, **226 of 5231 shared columns (4.3%) are numeric on the
desktop and text in Postgres, and the direction is entirely one-way — 226 desktop-numeric to web-text, zero
the reverse.** `BAL_GR.AVG_FINE` is `float` on the desktop. `RATE_CUT_DATA.CONV_RATE` is `float`.
`YEAR_MAST.OP_DATE` is `datetime`. So the `VAL()` cast in `closingStock.ts` is compensating for a migration
defect, not reproducing desktop behaviour.

`pnpm schema:readiness` reports 100% while this is true, because its contract
(`DESKTOP-REAL-SCHEMA.json`) is a list of column **names** with no type information — it measures presence and
has never compared a type. `pnpm type:parity` now measures types, with the 226 baselined so a new one fails.

| Fact                                                                                                                      | Consequence                                                                                                                                  |
| ------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| `BAL_GR.AVG_FINE/AVG_AMT/AVG_RATE/AVG_NWT/TRAD_AMT/AVG_TOUCH` are **varchar** while `PCS_RATE/TOT_PCS/OP_AMT` are numeric | `closingStock.ts` needs a `VAL()` regex cast                                                                                                 |
| `MAIN_STOCK.ITM_NWT/ITM_PCS/ITM_MRP` numeric; `AC_DATA.DR_AMT/CR_AMT` the opposite convention                             | cannot share a coalesce                                                                                                                      |
| `YEAR_MAST.OP_DATE` **varchar** holding ISO dates, can be `''`                                                            | guard before `::date`                                                                                                                        |
| `RATE_CUT_DATA.CONV_RATE/CONV_PRC` varchar while `DR_AMT/CR_AMT/DR_FINE/CR_FINE/FINE_RATE` numeric                        | `42804` if coalesced together                                                                                                                |
| `SL_DATA.CGST_TAX/SGST_TAX` **double precision, no scale**; `TAX_AMT` and all `SL_DETL` money `numeric(_,2)`              | the unrounded intra-state halves live in the former; a 2-dp column truncates finer precision, so a rounding test on `TAX_AMT` can never fail |
| `ITEM_MAST.IT_CODE` is **varchar(5)**                                                                                     | `'SILVER'` fails `22001`                                                                                                                     |
| `AC_MAST.AC_CODE` is **varchar(8)**                                                                                       | `'GOLDPARTY'` fails `22001`; the group column is `AC_GR`, **not** `GR_CODE`                                                                  |
| `BAR_DETL.KR_NAME` is **varchar(5)**                                                                                      | a karigar **code**, not a name                                                                                                               |
| `SRNO_MAST` unique on `(tenant_id, CO_CODE, LC_CODE)`                                                                     | a counter, not a per-tag registry                                                                                                            |
| `AC_DATA` has **no `SR_NO`**; `PR_DATA` has **no `SR_NO`**                                                                | `scoped()` in `dataRepairOps.ts` needs `{ year: false }` for `BOOK_DATA`, `BOOK_DETL`, `BANK_RECONCILE`                                      |

**Always slice text to the real width, fixtures included.**

---

## 6. Routing and authorisation

**Route policy is static analysis of literal `app.<verb>('/path'` strings.** Never register routes in loops
or template literals — they become invisible to it.

A new route needs three things:

1. `route(<form>, ['VERB /path'])` in `routePolicy.ts`
2. the form in `formCatalog.ts`'s **`FORM_CATALOG` array** (the map further down is an _alias_ map, not the
   form list)
3. the pinned count bumped in **both** assertions in `routePolicy.test.ts`

An unmatched path returns **404 `not-found`**; a _registered_ route without a policy **hard-500s**, which is
what forces every route into the policy.

**Adding an API input field needs four places:** row type, blank-row factory, extended panel, request
payload. `routeInputForwarding.test.ts` catches the omission statically — it was written after a route
forwarded 6 of 14 documented inputs, leaving four desktop columns unreachable.

A shared report filter is **refused (400)** unless the report's registered binding honours it — a global
`preHandler` on `/reports/*` that strips `.csv`/`.xlsx`/`.pdf` so exports cannot bypass it.

---

## 7. Year-end and opening balances

Two **different models**, agreeing on the figure that matters.

**Desktop.** `OP_LDR` holds prior-year **detail** — 7011 rows over 117 accounts on the real database, 2566
for one account, carrying real `VCH_TYPE`s and books. Written only by `UT_IMPORT.cs` and `BtmSchm.cs` (two
insert sites in the whole source), **not** per voucher. `RP_LEDR.cs` reads it ten times, summing
`DR_AMT`/`CR_AMT` and gold/silver fine per account.

**Web.** `ops/yearEnd.ts` carries the **net**: `ΣDR − ΣCR` per account as one `AC_DATA` leg,
`CO_BOOK '000'`, `VCH_TYPE 'ACOP'`, balanced by account sign, idempotent. Book **999** is excluded — the
injected closing-stock balancing figure, mirroring the desktop's `AND A.CO_BOOK <> '999'`.

The opening _figure_ must agree, since summing detail gives the net. **What the web cannot do is drill from
an opening balance into last year's transactions.** `OP_LDR` is also unbalanced on its own
(86,510,920.77 Dr against 87,615,844.46 Cr, 117 of 918 accounts), so it is a partial copy rather than a
ledger — the web's model is not merely a lossy version of it.

---

## 8. Reports

48 registered report slugs, 254 pinned layout baselines, CSV and XLSX export for every report with formula
injection neutralised (a leading `= + - @` is defused, and XLSX writes every value as a string cell).

`REPORT_FILTER_BINDINGS` in `reportFilters.ts` is the single source read by both the builders and
`/reports/:report/filters` — never register a binding without applying it.

`rojmelReport.ts` reads `ROJ_MEL_DATA` and reproduces `RP_ROJMEL`'s summary structure: gold and silver fine
split by direction, plus money totals. Those summaries were structurally dead until a family populated
`ITM_FINE`, because every earlier family left it zero.

**The desktop's per-voucher narration is deliberately not reproduced** — it reaches into `CASH_DATA`,
`CARD_DATA`, `AD_DATA` + `AD_MEMB` and `KR_DATA`, and inventing it would be inventing content.

---

## 9. Environment

```bash
export PATH=/opt/homebrew/opt/postgresql@16/bin:$PATH
export DATABASE_URL='postgresql://app_user:imgValidationSecret2026x@127.0.0.1:55433/datacare?schema=public'
export MIGRATE_DATABASE_URL='postgresql://postgres@127.0.0.1:55433/datacare?schema=public'
export RUN_DB_INTEGRITY_TESTS=1 RUN_DB_SECURITY_TESTS=1
```

Port **55433** only. Do not pass `?schema=public` to `psql`. `timeout` does not exist on macOS.

Running locally:

```bash
DATABASE_URL=… PORT=4000 JWT_SECRET='local-run-secret-please-change-me-32chars' \
  APP_TENANT_ID=default SEED_DEMO=1 DEMO_PASSWORD='DemoRun#2026' node apps/api/dist/server.js
API_ORIGIN='http://127.0.0.1:4000' pnpm --filter @datacare/web exec next start -p 4001
```

Login: company `01`, user `admin`. `pkill -f "next-server"` before `pnpm build --force` — stale servers hold
the build directory.

The demo seed calls `seedCompany`, so it provisions books **with their `BOOK_DETL` account rows** plus a
group, two items and a customer. It previously hand-rolled a thinner subset and a sale failed with
`book SAL account row 1 is missing`; `seedCompleteness.db.test.ts` now gates that.

---

## 10. Migrations

Historical migrations are **immutable**; new ones are additive only. `EXPECTED_MIGRATIONS` pins names and
checksums — it was once stale by four, and rolled-back rows are excluded from the health check because a
`Map` keyed by name made the verdict order-dependent.

`pnpm fresh:provision` provisions a scratch database from the chain, asserts RLS forced with a policy on
every `tenant_id` table, diffs against the working database, and drops the scratch. It refuses to run if the
scratch name equals the target.

It exists because `message_attempt_log` shipped with `tenant_id`, no RLS and no policy — created by a
migration _after_ the blanket security pass, invisible on a long-lived database that had acquired RLS
through unrelated history. Two queries then filtered on `idempotency_key` alone and relied on RLS, so the
same key across tenants returned **another tenant's** delivery status and overwrote their row.
