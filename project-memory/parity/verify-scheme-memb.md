# Write-Path Parity — SAVING-SCHEME + MEMBERSHIP vs real desktop data

**Date:** 2026-06-30 (re-verified, first-hand voucher) · **Scope:** `apps/api/src/modules/membership/{scheme.ts,membership.ts}` + routes `txn.ts` (`/scheme/*`, `/members/*`)
**DB:** `web-postgres-1` / `datacare` (RLS tenant `default`, CO `01`) · **API:** `http://localhost:4000` (cookie auth)
**Method:** read desktop C# (`TR_MEMB_ENT.cs`, `Module_Schm.cs`, `TR_SALE.cs`), verify real rows via `psql`, create a **live** enroll+installment over the HTTP API (scheme `ZV`, voucher **075/56**), diff with `integration/parity_form.mjs`, then clean up. **No app code was edited.** All test rows removed; demo intact (§8).

---

## 0. Verdict (TL;DR)

| Question | Answer | Triage |
|---|---|---|
| Does web **SCHEME** (enroll/installment) match the desktop **074 MEMB ENTRY** gold-scheme flow? | **Partially.** The *financial shape* matches (balanced `Dr cash / Cr member-liability` in `AC_DATA`), but the voucher is stamped with the **wrong book / VCH_TYPE / BOOK_NAME** — `075 / SCH / SCHEME` instead of `074 / MBENT / MEMB ENTRY`. Worse, `075` is **already a real desktop book** (*MEMB OPENING*). Plus `AD_DATA.ENT_TYPE='I'` vs desktop `'E'`. | **(A) CONCRETE FIXABLE** |
| Does web **MEMBERSHIP** (`POINT_DATA` loyalty) map to a desktop form? | **No standalone desktop form exists.** Desktop accrues/redeems points **inside `TR_SALE`** (billing footer). Web's `/members/points` is a decoupled reimplementation with **synthetic** book `PNT` / VCH_TYPE `PERN`/`PRED` that are absent from `BOOK_DATA`. | **(B) MODEL GAP (divergent feature)** |
| Is scheme **MATURITY / redemption (`AD_ADJ`)** implemented in web? | **No.** Desktop `076 MBADJ` (+ `176 MGADJ`) write `AD_ADJ` at maturity; web has **no maturity function and never writes `AD_ADJ`** (only a read-only report). | **(B) MODEL GAP (missing form)** |

---

## 1. Real desktop data — verified via `psql`

### 1a. `BOOK_DATA` master — the member/scheme book family (the authoritative tags)
```
CO_BOOK |       BOOK_NAME       | BOOK_SNAME |   MAIN_BOOK
  074   | Member Monthly Entry  | MBENT      | MEMB ENTRY     ← monthly installment (this is what schemeInstallment IS)
  075   | Member Opening Entry  | MBOP       | MEMB OPENING   ← a DIFFERENT real book; web squats on it
  076   | Member Advance Adjust | MBADJ      | MEMB ADJUST    ← maturity/redemption (writes AD_ADJ)
  176   | Member Gold Adjust    | MGADJ      | MEMB GOLD ADJ  ← gold-redemption variant
```
> There is **no** desktop book named `SCHEME`, **no** `VCH_TYPE='SCH'`, **no** `PNT`/`PERN`/`PRED`. Those tags are web inventions. (`SELECT … FROM "BOOK_DATA"` returns only the 4 rows above for the family; `WHERE CO_BOOK IN ('075','PNT') OR BOOK_SNAME IN ('SCH','PERN','PRED')` → only `075 MBOP MEMB OPENING`.)

### 1b. Real `AC_DATA` footprint (tenant `default`, CO `01`)
```
074 MEMB ENTRY / MBENT  = 2622 legs   (CO_YEAR 2024, LC_CODE 00, 2 users, 2024-04-01..2025-03-10)
076 MEMB ADJUST / MBADJ =   72 legs
075 (real)              =    0 legs   (only ever holds web test vouchers)
AC_DATA total = 5150 · AD_ADJ = 26 · AD_DATA = 0 · AD_OS = 0
```
**100 % of the 2622 `074` legs are `IT_TYPE='A', SIGN='' (blank), DATA_TYPE='A'`** (a single `GROUP BY IT_TYPE,SIGN,DATA_TYPE` row: `A | '' | A | 2622`).

### 1c. A real `074 / MBENT` voucher — the ground truth (`VCH_NO 00001`)
```
AC_CODE  DR_AMT   CR_AMT   VCH_TYPE BOOK_NAME   DATA_TYPE IT_TYPE SIGN  LEDR_KEY
000858      0.00  2000.00  MBENT    MEMB ENTRY  A         A       ''    01002024-20250740000101…  (Cr member-liability)
00001    2000.00     0.00  MBENT    MEMB ENTRY  A         A       ''    01002024-20250740000102…  (Dr cash ledger 00001)
```
Balanced `Dr cash / Cr member-liability`. Desktop source confirms the stamping in **`TR_MEMB_ENT.cs`**:
`dataRow2["VCH_TYPE"] = FormBookSname` (=`MBENT`), `dataRow2["BOOK_NAME"] = FormMainBook` (=`MEMB ENTRY`), and
`ENT_TYPE = (FormMainBook=="MEMB OPENING") ? "O" : "E"` (L4561-4574) → **monthly entry ⇒ `ENT_TYPE='E'`**.

### 1d. `AD_ADJ` — the maturity/redemption table (26 real rows; desktop `076 MBADJ`)
```
CO_BOOK VCH_TYPE BOOK_NAME   SCHM_CODE MEMB_CODE MEMB_AMT  ADJ_AMT   AC_CODE SIGN GOLD_WT/AMT
076     MBADJ    MEMB ADJUST 02        0273      28500.00  28500.00  00001   -    0/0
076     MBADJ    MEMB ADJUST 01        0046      10500.00  10500.00  000845  -    0/0  (settle vs sale bill SBILL_*)
```
At maturity the accrued balance is paid out (cash, against a sale bill `SBILL_*`, or as gold `GOLD_*`/book 176): an `AC_DATA` `Dr member / Cr cash` **plus** an `AD_ADJ` detail row with `SIGN='-'`, `INOUT_TYPE='O'`. `Module_Schm.cs` (L88-95) confirms the scheme module owns `AC_DATA, AD_ADJ, AD_DATA, AD_OS`.

---

## 2. What the web writes — **live test captured** (scheme `ZV`, voucher `075/56`)

Seeded one scheme master `AD_MAST(SCHM_CODE='ZV', SCHM_AC='000858')`, then over the **live HTTP API**:
`POST /scheme/enroll {schmCode:ZV, monthlyAmt:2000}` → `{"membNo":"00001"}` (1 `AD_MEMB` row).
`POST /scheme/installment {schmCode:ZV, membCode:00001, amount:2000, mode:cash}` → `{"vchNo":56}` (book **075**).

Captured rows (`psql`):
```
AC_DATA(075/56) leg1: AC_CODE=CASH    LD_CODE=1 DR=2000 CR=0    VCH_TYPE=SCH BOOK_NAME=SCHEME DATA_TYPE=A IT_TYPE=A SIGN=D  LEDR_KEY=0101202407500005601
AC_DATA(075/56) leg2: AC_CODE=000858  LD_CODE=2 DR=0    CR=2000 VCH_TYPE=SCH BOOK_NAME=SCHEME DATA_TYPE=A IT_TYPE=A SIGN=C  LEDR_KEY=0101202407500005602
AD_DATA(075/56):      VCH_TYPE=SCH BOOK_NAME=SCHEME INOUT_TYPE=I ENT_TYPE=I SCHM_CODE=ZV MEMB_CODE=00001 MEMB_AMT=2000 REC_AC=CASH
AD_OS  (075/56):      VCH_TYPE=SCH BOOK_NAME=SCHEME INOUT_TYPE=I ENTRY_TYPE=I SIGN=+ OS_TYPE=A DATA_TYPE=A MEMB_AMT=2000 ADJ_AMT=2000
```
Web source: `scheme.ts` L30-33 (`SCHEME_BOOK='075'`, `BOOK_NAME='SCHEME'`, `VCH_TYPE='SCH'`), AD_DATA `ENT_TYPE:'I'`, AD_OS `OS_TYPE:'A'/SIGN:'+'`.

### `parity_form.mjs compare 074 00001 075 56`
```
[WEB EXTRA] AD_DATA: web 1 row(s), desktop 0
[COL DIFF]  AC_DATA (11): VCH_TYPE desk='MBENT' web='SCH' | BOOK_NAME desk='MEMB ENTRY' web='SCHEME'
            | AC_CODE desk='858' web='CASH' | SIGN desk='' web='D' | CR_AMT/DR_AMT (leg-order) | LEDR_KEY … | FINE_WT
[WEB EXTRA] AD_OS:   web 1 row(s), desktop 0
RESULT: tablesChecked=3 footprintMisses=0 columnDiffs=11  →  PARITY_REVIEW
```

---

## 3. COLUMN-DIFF TABLE — `AC_DATA` installment leg (web `075` vs desktop `074 MBENT`)

| Column | Desktop 074 (real, n=2622) | Web 075/56 (scheme.ts) | Verdict |
|---|---|---|---|
| `CO_BOOK` | `074` (Member Monthly Entry) | `075` | **BUG** — `075` = *MEMB OPENING* in `BOOK_DATA` |
| `VCH_TYPE` | `MBENT` | `SCH` | **BUG** |
| `BOOK_NAME` | `MEMB ENTRY` | `SCHEME` | **BUG** |
| `DATA_TYPE` | `A` | `A` | ✅ OK |
| `IT_TYPE` | `A` | `A` | ✅ OK |
| `DR/CR` direction | `Dr cash / Cr member 000858` | `Dr CASH / Cr member 000858` | ✅ OK (balanced, same direction) |
| member-leg `AC_CODE` | `000858` | `000858` (from `SCHM_AC`) | ✅ OK |
| cash-leg `AC_CODE` | `00001` (numeric cash ledger) | `CASH` (literal) | DIFF — **cross-cutting** (`finance.settlementAc`) |
| `SIGN` | `''` (blank) | `D` / `C` | DIFF — **cross-cutting** (`finance.buildTransferLedger`) |
| `LD_CODE` | contra **account code** (`00001`/`000858`) | line **ordinal** (`1`/`2`) | DIFF — **cross-cutting** (`posting.enrichLedgerLine`) |
| `LEDR_KEY` | `01002024-2025074…` (LC `00`) | `0101202407500005601` (LC `01`) | DIFF — key-derivation (harness-skipped) |

Detail tables (web-extra; real snapshot has 0 rows → only schema/source-intent comparison possible):

| Table.Column | Desktop intent (source) | Web 075/56 | Verdict |
|---|---|---|---|
| `AD_DATA.VCH_TYPE / BOOK_NAME` | `MBENT` / `MEMB ENTRY` | `SCH` / `SCHEME` | **BUG** (same mislabel) |
| `AD_DATA.ENT_TYPE` | `E` (monthly) — `TR_MEMB_ENT.cs` L4567 | `I` | **BUG** |
| `AD_OS.VCH_TYPE / BOOK_NAME` | `MBENT` / `MEMB ENTRY` | `SCH` / `SCHEME` | **BUG** (same mislabel) |
| `AD_OS.OS_TYPE / SIGN` | `A` / `+` accrual (plausible) | `A` / `+` | OK (intent) — unverifiable (real=0) |

---

## 4. CONCRETE FIXABLE BUGS  *(triage A)*

> All in `apps/api/src/modules/membership/scheme.ts`. **Not applied** (read-only audit). Each is verifiable against the 2622 real `074` legs.

1. **Wrong book identity on the monthly installment — HIGH.**
   `scheme.ts` L30-33: `SCHEME_BOOK='075'`, `BOOK_NAME='SCHEME'`, `VCH_TYPE='SCH'`. None exist in `BOOK_DATA`; the monthly installment **is** desktop **074 / MBENT / MEMB ENTRY**, and `075` is already taken by *MEMB OPENING*.
   **One-line fix:** `const SCHEME_BOOK='074'; const BOOK_NAME='MEMB ENTRY'; const VCH_TYPE='MBENT';`
   This single change corrects **`AC_DATA`, `AD_DATA` and `AD_OS` simultaneously** (all three derive `BOOK_NAME`/`VCH_TYPE` from these constants). 8 of the 11 reported AC_DATA diffs collapse to the two-tag mismatch + leg ordering.

2. **`AD_DATA.ENT_TYPE` wrong — MEDIUM.**
   Web hardcodes `ENT_TYPE:'I'` (AD_DATA write). Desktop sets `'E'` for a monthly entry (`'O'` only for *MEMB OPENING*) — `TR_MEMB_ENT.cs` L4561-4572.
   **One-line fix:** write `ENT_TYPE: 'E'` on the monthly-installment path.

3. **Cross-cutting ledger-line conventions — LOW (affects every web voucher, not just scheme).**
   - `AC_DATA.SIGN`: desktop legs are blank; web stamps `D`/`C` (`finance.buildTransferLedger`).
   - `AC_DATA.LD_CODE`: desktop = contra **account code**; web = line **ordinal** (`posting.enrichLedgerLine`).
   - cash leg `AC_CODE`: desktop numeric `00001`; web literal `CASH` (`finance.settlementAc`).
   Fixing these inside `scheme.ts` alone would diverge from the rest of the app — **defer to a global posting-layer parity decision** (already tracked for sales/finance).

---

## 5. MODEL GAPS  *(triage B — structural, not column bugs)*

**A. Scheme MATURITY / redemption is not implemented.**
Desktop `076 MBADJ` (cash; 72 `AC_DATA` legs + 26 `AD_ADJ` rows) and `176 MGADJ` (gold) redeem the accrued balance at maturity: `AC_DATA` `Dr member / Cr cash` **+** an `AD_ADJ` detail (`MEMB_AMT, MEMB_BONUS, MEMB_LESS, ADJ_AMT, SBILL_*` settle-against-bill, `GOLD_WT/RATE/AMT`, `SIGN='-'`, `INOUT_TYPE='O'`). `scheme.ts` exposes only `enrollScheme`, `schemeInstallment`, `deleteSchemeInstallment`, `deleteEnrollment` — **no maturity writer**; the redemption (`OS_TYPE='D'`, `SIGN='-'`) is only a code comment. The web's `/reports/scheme-adjustments` reads `AD_ADJ` but nothing ever writes it. → **Build `schemeMaturity()` posting `AC_DATA`+`AD_ADJ` (book 076 MBADJ / 176 MGADJ).**

**B. Opening-entry (`075 MBOP`) and gold-adjust (`176 MGADJ`) books unmodelled.** Web has only enroll + monthly installment; member opening balances and gold redemption have no web path.

**C. `AD_DATA`/`AD_OS` column parity is unverifiable in this dataset.** The snapshot imported only `AC_DATA`+`AD_ADJ` (`AD_DATA`=`AD_OS`=0). The web *does* write them (matching desktop source intent), but their values can't be diffed against real rows; the harness flags them `[WEB EXTRA]`. Not a bug — re-verify on a dataset that includes `AD_DATA`.

**D. Membership / loyalty points is a divergent standalone feature (not a port of any desktop form).**
Desktop accrues/redeems points **inside `TR_SALE`** — `TR_SALE.cs` L14786-14807 reads/writes `POINT_DATA` per bill: `SR_NO=1` = earned `TOT_POINT` (→ `nBillPoint`), `SR_NO=2` = redeemed points (→ `nUsePoint`), joined to `POINT_MAST` (`MIN_POINT`, `POINT_AMT`). `POINT_DATA` is otherwise only touched by `UT_IMPORT`. There is **no standalone desktop points-entry form**, no `PNT` book, no `PERN`/`PRED` VCH_TYPE in `BOOK_DATA`. Web's `membership.ts` (`/members`, `/members/points`) posts to the correct tables (`POINT_MEMB`, `POINT_DATA`) with correct balance derivation (`Σ TOT_POINT` `I` − `O`) and correctly writes **no `AC_DATA`** (points are not money) — but as a **decoupled transaction** with synthetic book/VCH_TYPE. Treat as an intentional web feature, **not** 1:1 desktop parity. The 2 resident `POINT_DATA` rows (`M001 "John Doe"`, book `PNT`) are pre-existing web-test seed, corroborating that no desktop points were imported.

---

## 6. Amount diffs — intentionally ignored *(triage C)*

Both vouchers balance at `2000.00 / 2000.00`. The harness row-1 `CR_AMT/DR_AMT` "swap" is a **leg-ordering artifact** (desktop row 1 = Cr member; web row 1 = Dr cash), not an amount error. Cash-account representation (`CASH` vs `00001`) is a cross-cutting convention (§4.3), and `FINE_WT` `0` vs blank is a null/zero nit — all ignored per scope.

---

## 7. Honest bug-vs-gap summary

- The **scheme installment** is genuinely close to desktop `074 MBENT` and its mislabel is a **real, low-risk, one-line-constant fix** (#4.1/#4.2) — a true *CONCRETE FIXABLE* bug, not cosmetic: it writes onto the wrong book code (`075`=*MEMB OPENING*), which would corrupt the desktop's opening-entry register if both were ever used together.
- **Maturity** and **loyalty-points** are **deeper feature gaps**, not constant typos: maturity is an unbuilt writer (`AD_ADJ`), and loyalty is a deliberately different architecture (standalone vs in-sale). They cannot be closed by editing a constant.

---

## 8. Cleanup & demo-integrity confirmation

Created during this test, then deleted: `AD_MAST(ZV)`, `AD_MEMB(ZV/00001)`, `AC_DATA(075/56)` (2 legs), `AD_DATA(075/56)`, `AD_OS(075/56)`. Delete + re-snapshot (stable across a 6 s re-check):

| Table | Real baseline | After cleanup |
|---|---|---|
| `AC_DATA` total | 5150 | **5150** ✅ |
| `AC_DATA` book 075 | 0 | **0** ✅ |
| `AD_MAST` / `AD_MEMB` / `AD_DATA` / `AD_OS` | 0 / 0 / 0 / 0 | **0 / 0 / 0 / 0** ✅ |
| `AD_ADJ` | 26 | **26** ✅ |
| `074 MEMB ENTRY` / `076 MEMB ADJUST` legs | 2622 / 72 | **2622 / 72** ✅ |
| `POINT_DATA` / `POINT_MEMB` | 2 / 1 | **2 / 1** ✅ (pre-existing seed, left as-found) |
| **DEMO: `SL_DATA` docs / Σ`TOT_AMT`** | **190 / 5478196.00** | **190 / 5478196.00** ✅ |

No desktop/demo rows were modified or deleted. `SRNO_MAST` carries no `CO_BOOK`/`VCH_NO` columns (it is tag/item numbering, not per-book voucher numbering), so no numbering residue to restore. (Note: a background parity sweep intermittently creates/tears down its own scheme `ZZ`/`075` test rows; none were present at the final snapshot.)

---

## 9. IMPLEMENTATION FOLLOW-UP (2026-06-30 — app code edited & verified)

The §1–8 audit was read-only. This section records the fixes that were then **implemented and verified**. Files changed:
`apps/api/src/modules/membership/scheme.ts`, `apps/api/src/routes/txn.ts`, `apps/api/test/scheme.test.ts` (new), `apps/web/app/(app)/txn/scheme/page.tsx`.

**Done**
1. **Bug #1 (book identity):** installment now stamps **`074` / `MBENT` / `MEMB ENTRY`** via typed constants `MEMB_ENTRY` + `MEMB_ADJUST` (`076`/`MBADJ`/`MEMB ADJUST`). Safe vs the 841 desktop `074` vouchers: web rows are `LC_CODE='01'` (`SRNO_MAST`=58) while the demo is `LC='00'`, and `VCH_NO` is unpadded.
2. **Bug #2:** `AD_DATA.ENT_TYPE` `'I'` → `'E'` (desktop monthly-entry value).
3. **Gap A (maturity) — built:** `schemeMaturity()` + `deleteSchemeMaturity()` post book **`076 MBADJ`**: balanced `AC_DATA` `Dr scheme-liability / Cr cash` + **`AD_ADJ`** (`SIGN='-'`, `INOUT_TYPE='O'`, `ENTRY_TYPE='A'`, `MEMB_AMT/MEMB_BONUS/MEMB_LESS/ADJ_AMT`) + **`AD_OS`** redemption (`OS_TYPE='D'`, `SIGN='-'`). Net payout = `amount + bonus − less`. Routes `POST /scheme/maturity` + `DELETE /scheme/maturity/:vchNo`; UI gains a "Maturity / Redeem" panel.
4. **Error mapping:** `SchemeError.name='SchemeValidationError'` ⇒ route `run()` returns HTTP **400** (was 500).

**Verification (cited)**
- `apps/api/test/scheme.test.ts` (6 tests) + full suite **131 passed / 32 files**; api `tsc --noEmit` clean; api build clean; web `tsc --noEmit` clean.
- Live (tenant `default`): enroll → installment (`074/59`) + maturity (`076/60`, payout 2100) → **14/14** assertions. installment `MBENT`/`MEMB ENTRY`, `AD_DATA.ENT_TYPE='E'`; maturity `MBADJ`/`MEMB ADJUST` `Dr 000858 / Cr CASH 2100` balanced, `AD_ADJ SIGN='-' INOUT='O' ENTRY='A' ADJ_AMT=2100 bonus=150 less=50`, `AD_OS` `+`/`-`.
- `parity_form compare 074/00001 vs 074/59`: **`VCH_TYPE` + `BOOK_NAME` no longer differ** (11 → 9 diffs; the 9 are the cross-cutting set from §4.3 + leg-order + `AD_DATA`/`AD_OS` web-extra). `footprint 076/60` = `AD_ADJ:1, AC_DATA:2, AD_OS:1`; `compare 076/00001 vs 076/60` → `VCH_TYPE/BOOK_NAME/SIGN/INOUT_TYPE/ENTRY_TYPE` match (diffs = amounts/different-member + cross-cutting).

**Still open (out of scope — cross-cutting / deeper gaps):** §4.3 posting-layer conventions (`SIGN`, `CASH` literal, `LD_CODE`, `PARTY_AC_CODE`, `FINE_*`, `LEDR_KEY`, global `SRNO_MAST`, `LC_CODE`/`CO_YEAR`); §5.B opening (075) + gold-adjust (176) books; §5.D loyalty-points divergence.

**Cleanup:** all created rows (`074/59`, `076/60`, `SCHM_CODE='ZZ'`) deleted; baseline restored exactly (`074`=2622, `076`=72, `AD_ADJ`=26, `AD_DATA`/`AD_OS`/`AD_MAST`/`AD_MEMB`=0). Throwaway verify script removed.

**Deployment:** the running `:4000` API still served the pre-edit build (`POST /scheme/maturity` → 404) — no file-watcher. Code is correct on disk + `dist` and verified at module/DB level; **a server restart is required** to expose the route over HTTP (not restarted here — shared server with an observed concurrent process).

### 9.1 Addendum — member OPENING entry (075 MBOP) implemented

Follow-up to close the second half of Gap B. The desktop `TR_MEMB_ENT` form writes **both** the monthly entry (074 MBENT, `ENT_TYPE='E'`) and the **opening** entry (075 MBOP / `MEMB OPENING`, `ENT_TYPE='O'`) — same posting shape, different book. Implemented:
- `scheme.ts`: extracted a shared `postMemberEntry()` helper; `schemeInstallment` (074/`MBENT`/`'E'`) and the new **`schemeOpening`** (075/`MBOP`/`'O'`) are thin wrappers. `MEMB_OPENING` constant added; `deleteSchemeInstallment` gained an optional `vchType` so opening deletes log `MBOP`.
- `routes/txn.ts`: `POST /scheme/opening` + `DELETE /scheme/opening/:vchNo`.
- `scheme.test.ts`: +2 tests (book tag + ledger) → 8 total.
- UI: an "Opening balance entry (075 MEMB OPENING)" toggle on the installment panel switches the endpoint.

**Verified:** api typecheck/build clean; **133 tests pass / 32 files**; web typecheck clean. In-process HTTP inject (tenant `e2e`): `POST /scheme/opening` → 201, `AC_DATA` 2 legs `MBOP`/`MEMB OPENING` balanced 5000, `AD_DATA.ENT_TYPE='O'`, `AD_OS` `+`/`A`, `DELETE` → 200 (rows gone). Live `:4000` after restart: `/scheme/opening`, `/scheme/maturity`, `/scheme/installment` all return 401 unauth (routes registered); authed opening on a missing scheme → 400 (no rows). Demo intact (`074`=2622, `075`=0, `076`=72, `AD_ADJ`=26); no residue.

**Member-scheme book coverage now:** 074 MBENT ✅, 075 MBOP ✅, 076 MBADJ (cash maturity) ✅. **Still a documented gap:** 176 MGADJ (gold maturity) — left unimplemented because its `AC_DATA`/metal-leg structure is unverifiable (0 rows in this snapshot); modelling it would be speculative without source/data. Cross-cutting posting conventions (§4.3) and loyalty-points divergence (§5.D) remain out of scope by design.
