# Parity Gap — Reports / Masters / Frontend UX (verified against current source)

Date: 2026-07-27
Scope: (A) Report/Crystal fidelity, (B) Masters, (C) Frontend UX / keyboard parity.
Method: every claim cites current-source `file:line`. Prior parity docs NOT trusted.
Severity: BLOCKER / HIGH / MEDIUM / LOW. Labels: verified-parity / divergence / missing / unverifiable.

Desktop corpus: 255 `.rpt` (`unified/reports/*.rpt`, glob = 255), 33 `MS_*` master forms, 44 VB forms.
Web: `web/apps/api/src/modules/reports/*`, `.../masters/*`, `.../forms/formLayoutEngine.ts`,
`web/apps/web/app/(app)` + `components/*`.

---

## (A) REPORT / CRYSTAL FIDELITY

### A0. Two distinct report mechanisms exist
1. **Hand-written analytical dataset builders** (real SQL → `{rows, totals}`), one per REST endpoint.
2. **Generic `.rpt` layout renderer** — `reportEngine.ts` + `reportBind.ts` + 254 extracted
   `report-specs/*.spec.json` (glob = 254, vs 255 `.rpt`). This is the ONLY path that touches an
   individual named `.rpt`.

### A1. Real dataset builders: ~55, mapped to report *categories* not the 255 `.rpt` — divergence (MEDIUM)
Count of exported dataset builders (read-only SQL, `withTenant` + `NN()` numeric-cast pattern):
- `reports.ts`: salesRegister, purchaseRegister, dhrnOutstandingList, karigarBalances,
  accountBalances, stockValuation, oldGoldRegister, billOutstanding, gstr3b, salesByParty,
  salesByItem, balanceSheet, outstandingReport, monthlySales, dayBook (15) + re-exports
  trialBalance, accountLedger, gstr1, stockOnHand, dhrnOutstanding (5) — `reports.ts:12-16`.
- `reports2.ts`: cashBook, partyStatement, hsnSummary, schemeAdjustments, itemStockLedger (5).
- `reports3.ts`: monthlyPurchase, purchaseByParty, groupSummary, gstr2Purchase (4).
- `reports4.ts`: salesReturnRegister, karigarStatement, rateList, karigarLedger (4) + HTML renderer.
- `reports5.ts`: dailySalesSummary, topItems, employeeSales (3).
- `reports6.ts`: purchaseReturnRegister, contraRegister, areaOutstanding, itemGroupStock (4).
- `reports7.ts`: salesGstMonthly, billAging, stockByLocation, purchaseByItem (4).
- `reports8.ts`: trialBalanceFull, salesByGroup, cashDaySummary (3).
- `reports9.ts`: customerCrm, areaWiseSales, locationWiseSales (3).
- `reports10.ts`: purchaseByParty, monthlyPurchase, gstInputRegister (3; two names dup reports3).
- `voucherRegister.ts`: voucherRegister (1). `tagStock.ts`: tagStockReport + CSV (1).
- `statementDocs.ts`: trialBalance / gstr3b / balanceSheet / gstr2 formatted A4 docs (4).

≈ 55 distinct builders exposed as ~50 `/reports/*` GET routes (`routes/txn.ts:2338-2680`). These
reproduce the desktop's common **registers/summaries/statutory** reports well (sales/purchase
register, trial balance, day-book, GST, stock valuation, karigar, dhrn, ageing, contra…). They are
**not keyed to `.rpt` file names** and do not reproduce the 200+ layout-specific `.rpt` bills/vouchers.

Verdict: strong parity for analytical/register reporting; the long tail of per-voucher print
layouts (~200 `.rpt`) is served only by the generic renderer below.

### A2. `reportBind.ts` silently defaults unrecognized reports to SALES data — BLOCKER (confirmed)
`detectFamily()` scans the spec for a family table and, when none of SL/PR/KR is found,
**returns `'SL_DATA'`** — `reportBind.ts:47-50` (`return 'SL_DATA';` at line 49).
Only 3 families exist — `FAMILIES = { SL_DATA, PR_DATA, KR_DATA }` (`reportBind.ts:38-42`), and the
bind fallback repeats it: `const fam = FAMILIES[headerTable] ?? { detail: 'SL_DETL', … }`
(`reportBind.ts:68`). `bindReport` then queries `"<headerTable>"` header + `"<fam.detail>"` detail
(`reportBind.ts:72-90`).

Consequence: any `.rpt` whose data is NOT sales/purchase/karigar — i.e. account ledger, dhrn/pledge,
MFG, order, membership, scheme, rate, loan, cheque-print, etc. — is bound to `SL_DATA`/`SL_DETL`.
It returns the **wrong voucher** (a sales voucher with the same number) or 404 when that number is
absent in `SL_DATA` (`reportBind.ts:83` `if (!h) return null;`). This is a correctness landmine for
`/reports/render?name=…` on the majority of the 254 specs. Answer to the task question: **yes, an
unrecognized report silently defaults to sales data.**

### A3. Layout engine capability matrix — mostly missing (HIGH)
`renderReportLayout` (`reportEngine.ts:109-165`); object renderer `renderObject`
(`reportEngine.ts:78-92`):

| Crystal feature | Web support | Evidence |
|---|---|---|
| Positioned text/fields (twips→px) | YES | `reportEngine.ts:49` `T=/15`; `renderObject:78-92` |
| Lines / boxes | YES (plain border div) | `reportEngine.ts:84-85` |
| **Images / pictures / OLE / blob** | **NO** | only `TextObject/LineObject/BoxObject` handled; any other type falls to the FieldObject default (`reportEngine.ts:80-91`) — image objects render as empty/label |
| **Barcodes** | **NO** in reports | no barcode object; a Code39 encoder exists only for tag labels — `stock/tagPrint.ts` (`code39Svg`, tested `test/barcode.test.ts`), not wired to `.rpt` |
| **Subreports** | **NO** | no `Subreport` branch anywhere in `reportEngine.ts` |
| **Fonts (family/size/bold/italic/colour/align)** | **NO** | fixed CSS only (`reportEngine.ts:145-151`); spec font attrs never read |
| **Pagination / page N of M / page header-footer repeat** | **NO** | single continuous `.page` div (`reportEngine.ts:153-162`); no page breaks |
| **Grouping (group-by iteration)** | **NO** | Group bands only get a background (`reportEngine.ts:149`); only `Detail` repeats per row (`renderSection:104-106`); no group value iteration/headers/footers |
| **Running totals** | **NO** | evaluator has no aggregate; running-total fields resolve to a `[field]` placeholder |
| **Conditional suppression** | **NO** | section `.suppress` / suppression formula never evaluated — every section always renders (`renderReportLayout:154-161`) |

### A4. Crystal formula evaluator — minimal subset, ~5991 extracted formulas largely uncovered — HIGH
`crystalFormula.ts` self-documents "Not a full Crystal engine" (`crystalFormula.ts:1-8`). Supported:
single-level `if/then/else` (`evalCrystal:143-152`), string concat `+`, numeric `+ - *`
(`evalExpr:99-121`), comparisons `<> = > < >= <=` (`evalCond:123-141`), `ToText/Trim/CStr/TrimLeft/
TrimRight` (`stripFn:27-30`). Missing: aggregates (`Sum/Count/Maximum/RunningTotal`), division `/`,
boolean `and/or/not`, `Left/Right/Mid/InStr/UpperCase/…`, date functions, numeric formatting,
`Shared/Global` variables, `Select`, loops. Any parse failure **returns `''` silently**
(`evalCrystal:154`). Net: only the simplest address-concat / show-hide display formulas evaluate;
the large majority of the extracted formulas degrade to `''` or a `[field]` label placeholder.

### A5. PDF pipeline — verified-parity (LOW)
HTML→PDF via injected renderer; `PlaywrightPdfRenderer` (real) + `FakePdfRenderer` (tests)
(`render.ts`). Routes return 503 `pdf-renderer-unavailable` when Chromium is absent
(`routes/txn.ts:2528-2531`). Sound design; requires Chromium present in prod.

**Report verdict:** ~55 real analytical builders give good parity for registers/summaries/statutory
returns, but per-`.rpt` fidelity is LOW — the generic renderer reproduces geometry only, binds just
3 voucher families and **defaults everything else to sales (A2)**, and drops images, barcodes,
subreports, fonts, pagination, grouping, running-totals and suppression, with near-zero formula
coverage.

---

## (B) MASTERS

### B1. Dedicated vs generic — divergence
`MASTERS` registry = **33 route keys** (`masters/configs.ts` MASTERS map), all served by ONE generic
metadata-CRUD engine (`master.service.ts` createMaster/updateMaster/deleteMaster/listMaster,
`master.service.ts:196-320`). Keys: accounts, customers, items, rates, taxes, groups, employees,
books, products, locations, designs, diamonds, models, states, points, labour, touch, messages,
conversions, mfg, companies, years, addresses, gold-rate, schemes, counters, item-weights, styles,
print-formats, einvoice-gsp, franchise-accounts, ac-groups, trade (accounts+customers → AC_MAST).

**Frontend:** 1 generic screen `masters/[name]/page.tsx` serves all 33; **5 dedicated screens**:
`masters/party` (photo+family), `masters/auto-item`, `masters/opening-balance`,
`masters/labour-update`, `masters/year-create` (glob of `app/(app)/masters/*`).

**API special-behavior modules** bolted onto the generic engine (not full dedicated CRUD):
`party.ts` (AC_IMAGE photo + AC_KHATA_NO family), `autoItem.ts` (bulk IT_CODE=GR+PR),
`rate.ts`/`dailyRate.ts`, `year.ts` (create/close/reopen/carry-forward), `openingBalance.ts`,
`labourUpdate.ts`.

**Count: 5 dedicated master UIs vs 33 generic (metadata-CRUD).** Of the 33, only **5 have curated
rich `formFields`**: AC_MAST (Party), ITEM_MAST (Item) (`master.service.ts:352-470`), GROUP_MAST,
CO_MAST (Company), BAL_GR (trade) (`configs.ts`). The other 28 rely on the auto-generated
`generated-formfields.ts` (31 tables) or fall back to `requiredColumns`.

### B2. Auto-code rules missing on single-record New — divergence (MEDIUM)
Desktop MS_ACCT/MS_ITEM auto-generate the next AC_CODE/IT_CODE. Web generic CRUD requires the user
to type the key: AC_CODE/IT_CODE are required key columns validated as mandatory
(`findMissingRequired`, `master.service.ts:120-126`; keys shown with `*` and editable in
`masters/[name]/page.tsx`). No server auto-increment for the single New form. `autoItem.ts` covers
only the bulk group×product path, not the ordinary New-record flow.

### B3. Referential delete guards missing for most masters — HIGH
`deleteMaster` guards only against `config.references` (`buildDeleteGuards`,
`master.service.ts:186-193`; enforced `master.service.ts:300-312`). Only **4 configs declare
references**: AC_MAST→AC_DATA (`master.service.ts:325`), ITEM_MAST→SL_DETL
(`master.service.ts:472`), GROUP_MAST→ITEM_MAST, AC_GROUP→AC_MAST (`configs.ts`). The other ~28
masters (taxes, employees, books, products, locations, designs, diamonds, models, states, points,
labour, touch, messages, conversions, mfg, companies, years, addresses, gold-rate, schemes,
counters, item-weights, styles, print-formats, einvoice-gsp, franchise-accounts, rates) have
`references: []` ⇒ **no delete guard** (e.g. deleting a referenced TAX_MAST / EMP_MAST / BOOK_DATA
is unguarded). Guard is also single-table/single-level and matches only same-named key columns.

### B4. Left-list/right-editor + family/image grids — divergence (MEDIUM)
Desktop masters use a left list + right editor with tabbed dialogs. Web generic screen uses a top
table + inline New/Edit panels with tabbed field groups (`masters/[name]/page.tsx` `FieldGroups`).
Party photo + family/khata grid exist only on the dedicated `masters/party` screen (`party.ts`);
item weight/size sub-grids (ITM_WT_MAST) and design-image grids are exposed as separate generic
masters, not embedded editor grids. Tabbed grouping is a reasonable approximation but not the
desktop list/editor UX.

**Masters verdict:** functional generic CRUD covers all 33 registered tables; 5 dedicated screens.
Gaps: no single-record auto-code (B2), delete guards on only 4 of ~32 tables (B3), and
list/editor + embedded family/image grids largely absent (B4).

---

## (C) FRONTEND UX / KEYBOARD PARITY

### C1. Desktop keyboard contract (evidence)
Every VB form uses a `KeyPreview` KeyDown handler: **F2 = Save, F3 = Delete, F5 = Print,
Esc = Close** — identical block across 40+ forms (e.g. `MS_ACCT.vb:73-76`, `TR_SALE.vb:425-427`,
`MS_ITEM.vb:73-76`, `TR_PURC.vb:73-76`). Lookup fields use F1 list-of-values. No F6-F12 in the
standard handler.

### C2. Web has NO global F-key accelerators — missing (HIGH)
`KeyboardNav` (installed app-wide via `app/(app)/layout.tsx:63`) handles **only Enter=advance and
Ctrl/Cmd+Enter=submit** (`KeyboardNav.tsx:14-38`). There is **no document-level F2/F3/F5/Esc
handler** anywhere in `apps/web` (grep for `Keys.F`/`'F2'`/`'F5'` returns only `LookupPicker` F1).
`VoucherChrome` renders Save/Print/Delete/Exit as click buttons **not bound to F2/F3/F5**
(`VoucherChrome.tsx:139-190`). So the desktop's global Save/Delete/Print accelerators are absent.

### C3. What IS implemented
- **F1 list-of-values** on lookup inputs (`LookupPicker.tsx:88` `if (e.key === 'F1')`) — parity.
- **Grid keyboard**: Arrows move cells, Enter→next cell / append row, Escape→grid escape,
  Ctrl/Cmd+D delete row (`GridKeyboard.tsx:resolveGridKey:31-72`).
- **Esc-to-tender**: item-grid Escape focuses the cash/tender field on sales & repair vouchers
  (`app/(app)/txn/sales/page.tsx:120` `onEscape: () => cashRef.current?.focus()`; same in
  repair-*). Present on those flows, not global.
- Enter-to-advance field traversal (`focus.ts` + `KeyboardNav`).

### C4. Frontend tests — thin; no E2E/visual suite — divergence (MEDIUM)
`apps/web` has exactly **2 test files**: `test/gridKeyboard.test.ts` (unit for `resolveGridKey`) and
`test/browser.smoke.mjs` (a Playwright smoke that presses F1/Escape). **No `playwright.config`, no
dedicated E2E directory, no visual/snapshot tests** (glob for `*.e2e/*.spec/playwright.config`
matches only `node_modules`). Backend is well-covered: **52 test files in `apps/api/test`**
(incl. reportEngine, crystalFormula, render, formLayoutEngine, barcode, masters, reports, parity).
Frontend behavioral coverage is minimal.

**UX verdict:** F1-LOV, grid navigation and Esc-to-tender are implemented; the desktop's global
F2/F3/F5/Esc Save/Delete/Print/Close accelerators are **not** wired app-wide (only Enter/Ctrl+Enter).
Frontend automated coverage is thin (2 files; no E2E/visual).

---

## Ranked findings
- BLOCKER — A2: `reportBind.detectFamily` defaults unrecognized `.rpt` to `SL_DATA`/`SL_DETL`
  (`reportBind.ts:49,68`) → wrong data or 404 for all non-sales/purchase/karigar reports.
- HIGH — A3: layout engine drops images/barcodes/subreports/fonts/pagination/grouping/running-totals/
  suppression (`reportEngine.ts:78-165`).
- HIGH — A4: formula evaluator covers only a small subset; failures return `''` (`crystalFormula.ts`).
- HIGH — B3: referential delete guards on only 4 of ~32 master tables (`master.service.ts:186-193`,
  `configs.ts` references).
- HIGH — C2: no global F2/F3/F5/Esc keyboard accelerators (`KeyboardNav.tsx:14-38`).
- MEDIUM — A1 report-per-.rpt coverage; B2 single-record auto-code; B4 list/editor + family/image
  grids; C4 thin frontend tests / no E2E/visual.
- LOW — A5 PDF pipeline sound (needs Chromium).

Verified-parity: A1 register/summary/statutory datasets; C1/C3 F1-LOV, grid nav, Esc-to-tender.
Unverifiable without a running DB+Chromium: exact rendered output of bound `.rpt` PDFs.
