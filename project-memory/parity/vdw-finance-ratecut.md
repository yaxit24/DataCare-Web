# Desktop ⇄ Web Parity — FINANCE · RATE-CUT · BULLION/FINE · ESTIMATE/APPROVAL

Read-only verification. Extends `vdw-sales.md` / `vdw-purchase-karigar.md` / `vdw-masters-reports.md`.

**Desktop truth** = video-research KB (`851f2afc…`: `KB_transaction.md §2/§4/§9/§12`, `KB_other.md §9`) + mined catalogs `catalogs/form-behavior/{TR_CASH,TR_CONTRA,TR_EMP_JV,TR_LEDR_ADJ,TR_BILL_TO,TR_FINE_SL_PR,TR_PR_SL_HEDG,TR_BUL_BOOKING,TR_FN_INOUT,TR_APR_ISU}.behavior.json` (gridColumns / inlineSql / calc / validations / keyboard).
**Web truth** = `web/apps/web/app/(app)/txn/{receipt,payment,contra,journal,employee-jv,fine-jv,ledger-adjust,bill-to-bill,bank-recon,rate-cut,bullion,fine-sale,fine-inout,estimate}/page.tsx` + `web/apps/web/components/PaymentForm.tsx` + `web/apps/api/src/modules/{finance/*,posting/posting.ts,sales/rateCut.ts,bullion/*,inout/fineInout.ts,tour/tour.ts}`.

Legend: **Match** = desktop behavior reproduced · **Partial** = present but incomplete/differs · **Gap** = absent. Every verdict quotes real evidence on both sides.

---

## 0 · Posting backbone (applies to every voucher below)

| Desktop behavior | Web implementation | Verdict | Evidence |
|---|---|---|---|
| Double-entry must balance (`TR_CONTRA` validation: *"You Cant Save This Voucher Becouse Cr Value and Dr Value is not same"* when `MSG_TOT[0,5] != MSG_TOT[0,6]`) | `assertBalanced()` — `ledgerBalance` sums CR vs DR (round2), throws `UnbalancedError` when `cr !== dr`; run inside every `postVoucherTx` | **Match** | `posting.ts` `export function assertBalanced(lines){const b=ledgerBalance(lines); if(!b.balanced) throw new UnbalancedError(...)}`; `postVoucherTx` calls it first line |
| Voucher no = `MAX(VCH_NO)+1` per `CO_CODE·LC_CODE·CO_YEAR·CO_BOOK` (`TR_CASH` `Select MAX(VCH_NO) … From CASH_DATA …`) | `nextVoucherNoTx(tx, scope)` inside the same tenant transaction | **Match** | `finance.ts` `const vchNo = await nextVoucherNoTx(tx, input.scope)` |
| Delete → `INSERT INTO DELETE_DATA(...)` audit + `DELETE FROM {header,AC_DATA,ROJ_MEL_DATA,...}` (all catalogs) | `reverseVoucherTx({tables, key, deleteLog:{table:'DELETE_DATA', row}})` | **Match** | `posting.ts` `reverseVoucherTx` deletes each table by key then inserts the `DELETE_DATA` row |
| Ledger line stamps `LEDR_KEY`, `IT_TYPE`, `DATA_TYPE='A'`, `BOOK_NAME`, `LD_CODE` (`Ac_Ledr`) | `enrichLedgerLine()` fills `LEDR_KEY / IT_TYPE 'A' / DATA_TYPE 'A' / LD_CODE / BOOK_NAME` when null | **Match** | `posting.ts` `function enrichLedgerLine(line, srno, bookName)` |
| Period / year lock (`"Voucher Date Not In Current Year"`, `MCo_OpDate/MCo_ClDate`) | `assertPeriodOpen()` reads `CO_SET.LOCK_DATE`, throws `PeriodLockValidationError` | **Partial** | web keys off `CO_SET.LOCK_DATE` (opt-in, single lock date); desktop guards against the company **open/close** year window — different mechanism, same intent |
| Employee mandatory (`MsEmpCodeMendetry` → *"Please Select Employee Code and Try"*) | Employee `LookupPicker` present on receipt/payment; **not enforced** as mandatory | **Partial** | `PaymentForm.tsx` `<LookupPicker entity="employees" value={empCode}…/>` but no required-guard |

---

## 1 · Cash / Bank Receipt — desktop `TR_CASH` (CASH_DATA) · KB §2/§4 → web `/txn/receipt` (`finance.ts postReceipt` + `PaymentForm`)

Desktop grid cols (`TR_CASH.gridColumns`): `SrNo·AcCode·AcName·ChqNo·ClDate·RecAmt·BankCharg·KasarAmt·ItDesc·ChqPrintName·BankName·MobileNo`. VCH_TYPE `CREC`(cash)/`BREC`(bank), book `RCT`. KB §2.4: *"Dr Cash/Bank (Σ rec) · Dr KASAR (Σ kasar) · Cr party"*.

| Desktop field / leg | Web | Verdict | Evidence |
|---|---|---|---|
| Party + name | `partyAc`+`partyName` (`LookupPicker entity="accounts"`) | **Match** | `PaymentForm.tsx` `<LookupPicker entity="accounts" value={partyAc} onPick={(r)=>setPartyName(...)}/>` |
| `RecAmt` (Amount) | `amount` | **Match** | `postReceipt` `REC_AMT: input.amount` |
| `KasarAmt` write-off | `kasar` → Dr KASAR leg | **Match** | `finance.ts` `if(kasar>0) ledger.push({AC_CODE: input.kasarAc??'KASAR', DR_AMT:kasar,...})` |
| Leg **Dr Cash/Bank / Cr party** | `Dr recAc (+Dr KASAR) / Cr party(amount+kasar)` | **Match** | `ledger=[{AC_CODE:recAc,DR_AMT:amount}, …, {AC_CODE:partyAc,CR_AMT:amount+kasar}]`; VCH_TYPE `mode==='cash'?'CREC':'BREC'`, book `'RCT'` |
| multi-line grid (`Sr·AcCode·Amount·Kasar`, many parties per voucher, KB §2.2) | Multi-line toggle → `postReceiptLines` (one Dr total + Cr per party, `PAY_DETL`) | **Match** | `PaymentForm.tsx` `multi` grid; `finance.ts postReceiptLines` writes `CASH_DATA` + `PAY_DETL` |
| `ChqNo` | `chqNo` (header) | **Match** | `postReceipt` `CHQ_NO: input.chqNo` |
| Card / UPI tender detail (desktop `TR_CARD_REC`/`TR_UPI_REC`, `CARD_DATA`/`UPI_DATA`) | card `cardCommissionPct`+`bankName`→`CARD_DATA`; upi `upiId`→`UPI_DATA` | **Match** | `PaymentForm.tsx` card/upi branches; `finance.ts` `if(mode==='card'){writes.push({table:'CARD_DATA',…CARD_COM_AMT…})}` |
| **`BankCharg`** (per-line bank charges leg) | — none | **Gap** | desktop `TR_CASH.gridColumns.cBankCharg=6`; no bank-charge field/leg in `postReceipt`/`PaymentForm` |
| **`ClDate`** (cheque clearing date at entry) | — none (cleared later in bank-recon) | **Gap** | desktop `cClDate=4`; web sets `CLR_DATE` only via `/bank-recon/clear` |
| `ChqPrintName` / cheque-print | — none on receipt path | **Gap** | desktop `cChqPrintName=11`; web has `finance/chequePrint.ts` but not wired to receipt entry |
| Cash-limit ceiling (`TR_CASH`: *"You Can Not Receive More Then Cash Limit"*, no PAN escape) | `assertCashReceiptCeiling(amount, priorCash, limit)` — blocks, no PAN override | **Match** | `finance.ts` cash branch: `const prior=await partyCashReceivedTx(...); assertCashReceiptCeiling(input.amount, prior, limit)` |

## 2 · Cash / Bank Payment — desktop `TR_CASH`/PAY_DATA · KB §2 → web `/txn/payment` (`finance.ts postPayment`)

| Desktop leg (KB appendix) | Web | Verdict | Evidence |
|---|---|---|---|
| Cash Payment **Dr party/expense / Cr CASH**; header `PAY_DATA`, detail `PAY_DETL`, VCH_TYPE `CPAY`/`BPAY` book `PAY` | `Dr party(amount+kasar) / Cr payAc + Cr KASAR`; `PAY_DATA` (+`PAY_DETL` in multi) | **Match** | `postPayment` `ledger=[{AC_CODE:partyAc,DR_AMT:amount+kasar},{AC_CODE:payAc,CR_AMT:amount}]`; `if(kasar>0) Cr KASAR`; book `'PAY'`, VCH_TYPE `mode==='cash'?'CPAY':'BPAY'` |
| Kasar = discount received (Cr KASAR) | `Cr KASAR` on payment | **Match** | `postPayment` `if(kasar>0) ledger.push({AC_CODE:kasarAc,CR_AMT:kasar})` |
| PAN gate on large cash (sales PAN field) | `assertCashLimit(mode,amount,pan)` on payment | **Match** | `postPayment` `assertCashLimit(mode, input.amount, input.pan, input.cashLimit)` |
| Multi expense-head grid (KB §2.2: one voucher paying `OFFICE EXP 3000` + `PETROL 2000`) | Multi-line → `postPaymentLines` (Dr per party / Cr cash total) | **Match** | `finance.ts postPaymentLines` + `PaymentForm` multi grid |

## 3 · Contra — desktop `TR_CONTRA` (CONTRA_DATA) → web `/txn/contra` (`finance.ts postContra`) + `/txn/journal` (`journal.ts`)

Desktop `TR_CONTRA` = **multi-line** grid `Sr·CrDrType·AcCode·AcName·ItDesc·CrAmt·DrAmt` (`gridColumns`), balance-guarded (`ΣCr==ΣDr`), header `CONTRA_DATA` (+`CR_FINE`/`DR_FINE` metal columns) + `AC_DATA`.

| Desktop capability | Web | Verdict | Evidence |
|---|---|---|---|
| Balanced transfer (2 accounts) → `CONTRA_DATA` + `AC_DATA` | `/txn/contra` posts `Dr toAc / Cr fromAc`, writes `CONTRA_DATA` + `AC_DATA` (VCH_TYPE `'JV'`, book `'CON'`) | **Match** (2-leg) | `contra/page.tsx` `post('/contra',{toAc:drAc, fromAc:crAc, amount})`; `finance.ts postContra` `writes:[{table:'CONTRA_DATA',rows:[{AC_CODE:toAc, LD_CODE:fromAc, DR_AMT:amount, CR_AMT:amount}]}]` |
| **N-line** contra (3+ accounts, arbitrary Cr/Dr mix) | `/txn/contra` is a **fixed two rows** (one Dr, one Cr) | **Partial** | `contra/page.tsx` renders exactly `<tr>Dr…</tr><tr>Cr…</tr>`; `equal = |drAmt-crAmt|<0.005` — cannot express 3+ legs |
| Multi-line balanced JV (arbitrary Dr/Cr lines, `ΣDr==ΣCr`, ≥2) | `/txn/journal` — add/remove lines, live balance, `validLines>=2` | **Match** (as JV) | `journal/page.tsx` grid + `canSubmit = balanced && validLines.length>=2`; `journal.ts postJournal` `if(rawLines.length<2) throw…; assertBalanced(ledger)` |
| JV writes header table | `/txn/journal` writes **AC_DATA only** (no `CONTRA_DATA` header) | **Partial** | `journal.ts` `postVoucherTx(tx,…,{ledger:{table:'AC_DATA',lines:ledger}, bookName:'JOURNAL'})` — no header/detail row |
| Contra metal legs (`CR_FINE`/`DR_FINE`, `IT_TYPE`) | — money only | **Gap** | `TR_CONTRA.inlineSql` groups `sum(CR_FINE)/sum(DR_FINE)`; `postContra` writes only `DR_AMT`/`CR_AMT` |

*Note:* the desktop's multi-line balanced grid is best matched by the web **Journal** page, while the web **Contra** page is the narrower cash↔bank two-leg transfer. Neither web page reproduces contra's metal (fine) legs.

## 4 · Employee Salary JV — desktop `TR_EMP_JV` (EMP_DATA) → web `/txn/employee-jv` (`employeeJv.ts`)

Desktop grid (`TR_EMP_JV.gridColumns` + calc): `EmpSalary·DayHours·TotHours·Days·EmpAmt·TdsPrc·TdsAmt·PfPrc·PfAmt·EmpLdr·CrDr·EmpDiff·PayAmt·PaidAc·ChqNo·BankName`. Calc: `EmpAmt = round(salary/30 × days)` (or `/monthHours × totHours`); `TdsAmt = EmpAmt×Tds%/100`; `PfAmt = EmpAmt×Pf%/100`; `EmpDiff = EmpAmt − EmpLdr − TdsAmt − PfAmt`.

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Ledger: Dr employee / Cr net cash-bank / Cr TDS / Cr PF; header `EMP_DATA` | same legs + `EMP_DATA` (`SALARY_AMT/PAID_AMT/TDS_AMT/PF_AMT`) | **Match** | `employeeJv.ts` `Dr empAc salary; if(net>0) Cr paidAc net; if(tds>0) Cr TDS; if(pf>0) Cr PF`; `writes:[{table:'EMP_DATA',rows:[{MONTHLY_SALARY,SALARY_AMT,PAID_AMT:net,TDS_AMT,PF_AMT}]}]` |
| `net = EmpAmt − Tds − Pf` | `net = salary − tds − pf` | **Match** | `employeeJv.ts` `const net = round2(salary - tds - pf)` |
| **Attendance-based gross** (`EmpAmt = salary/30 × Days`; `DayHours/TotHours`) | takes `salaryAmt` directly (no days/hours) | **Gap** | `TR_EMP_JV.calc` `val[Row,7]=Round(val[Row,3]/val[Row,21]*val[Row,5])`; web `salaryAmt` is the gross, no attendance inputs on `employee-jv/page.tsx` |
| **%-driven** TDS/PF (`TdsPrc→TdsAmt`, `PfPrc→PfAmt`) | `tdsAmt`/`pfAmt` entered as **₹ amounts** | **Partial** | page fields `TDS ₹`, `PF ₹`; no `%` inputs (`TR_EMP_JV.calc` `val[Row,9]=val[Row,7]*val[Row,8]/100`) |
| **`EmpLdr`** advance/loan netting into `EmpDiff` | — none | **Gap** | desktop `EmpDiff = EmpAmt − EmpLdr − Tds − Pf`; web has no prior-advance leg |
| `PaidAc` + `ChqNo`/`BankName` (bank pay split) | single `paidAc` + `chqNo` | **Partial** | page `Paid from (cash/bank)` + `Cheque No`; no bank-name/mode split |

## 5 · Fine JV — desktop "Fine Jv Entry" (Tran 2; contra-with-fine) → web `/txn/fine-jv` (`fineJv.ts`)

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Pure **metal-weight** transfer between parties, no money | 2 contra legs, `DR_AMT=CR_AMT=0`, `FINE_WT` only | **Match** | `fineJv.ts` `lines=[{AC_CODE:toAc,LD_CODE:fromAc,SIGN:'+',FINE_WT},{AC_CODE:fromAc,LD_CODE:toAc,SIGN:'-',FINE_WT}]`, `DR_AMT:0,CR_AMT:0` |
| Metal G/S | `metal:'G'|'S'` → `IT_TYPE` | **Match** | `fine-jv/page.tsx` `<select metal>`; `fineJv.ts` `IT_TYPE: metal` |
| Multi-line / multi-party fine JV | single from→to pair only | **Partial** | `fine-jv/page.tsx` has one `fromAc`/`toAc`; no line grid (desktop Fine JV is grid-based like contra) |
| Writes a header table (desktop Fine JV persists to a JV/contra header) | `AC_DATA` only (book `FJV`) | **Partial** | `fineJv.ts` `postVoucherTx(...,{ledger:{table:'AC_DATA',lines}})` — no header row |

## 6 · Ledger Adjust — desktop `TR_LEDR_ADJ` (LDR_ADJ_DATA) → web `/txn/ledger-adjust` (`ledgerAdjust.ts`)

Desktop grid: `CrAmt·DrAmt·DiffAmt·ItType(G/S)·CrFine·DrFine·DiffFine·ItDesc`. Calc back-solves from the account's opening: `DiffAmt = |CustOpAmt| − Cr/DrAmt`; `DiffFine = |CustOpGold/Silver| − Cr/DrFine`. Validation *"Please Select Item Type G or S"*.

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Money adjustment vs an account, contra to KASAR; `LDR_ADJ_DATA` + `AC_DATA` | Dr/Cr `acCode` by `amount` contra `adjAc` (default KASAR); `LDR_ADJ_DATA`(`DIFF_AMT`)+`AC_DATA` | **Match** (money) | `ledgerAdjust.ts` `drAc = dir==='debit'?acCode:adjAc … ledger=[Dr,Cr]`; `writes:[{table:'LDR_ADJ_DATA',rows:[{DIFF_AMT:amount,…}]}]` |
| **Metal (fine) adjustment** `CrFine/DrFine/DiffFine` + `ItType G/S` | hardcoded `CR_FINE:0, DR_FINE:0, DIFF_FINE:0`; no metal | **Gap** | `ledgerAdjust.ts` row literal `CR_FINE:0, DR_FINE:0, DIFF_FINE:0`; `ledger-adjust/page.tsx` has no metal/ItType field |
| Diff auto-computed from **account opening** (`CustOpAmt/Gold/Silver`) | operator enters `amount` + `direction` | **Partial** | `TR_LEDR_ADJ.calc` `mSG[Row,3]=Abs(CustOpAmt)−mSG[Row,2]`; web `direction: 'debit'|'credit'`, explicit `amount` |

## 7 · Bill-to-Bill — desktop `TR_BILL_TO` (BILL_OS_DATA) · KB §12 → web `/txn/bill-to-bill` (`billToBill.ts`)

Desktop = 3 grids: tender (`RecAc·ChqNo·RecAmt·KasarAmt`), bill-allocation (`BillNo·Book·BillAmt·RecAdjAmt·RecAmt·KasarAmt·DiffAmt`), and an **ornament-issue** grid (`UrItCode·UrItName·Pcs·GrWt·NetWt·Touch·Fine·RateType·Rate·NetAmt` → `SL_PR_DETL`+`MAIN_STOCK`, sets `SL_DATA.ORNA_ISU='Y'`).

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Open-bill list, `openBal = BILL_AMT − REC_AMT − KASAR_AMT`, not year-filtered (KB §12.4) | `listOpenBills` same formula, filtered by `CO_CODE·AC_CODE` only | **Match** | `billToBill.ts` `OPEN_BAL_SQL = (BILL_AMT − REC_AMT − KASAR_AMT)`; comment *"NOT filtered by CO_YEAR"* |
| Per-bill `RecAmt`+`KasarAmt` allocation; overpay rejected (KB §12.4) | `settleBills` increments `REC_AMT/KASAR_AMT`, throws on `applied > openBal+EPS` | **Match** | `billToBill.ts` `if(applied>openBal+EPS) throw…'overpay on bill'`; `UPDATE BILL_OS_DATA SET REC_AMT=…+$6, KASAR_AMT=…+$7, NEW_VCH_NO=$8` |
| Posted receipt **Dr Cash/Bank + Dr KASAR / Cr party**, links `NEW_VCH_NO` (KB §12.4) | same legs + `CASH_DATA`, `NEW_VCH_NO` stamped | **Match** | `settleBills` `ledger=[{cashAc DR totalRec},{kasarAc DR totalKasar},{acCode CR totalRec+totalKasar}]`; `writes:[{table:'CASH_DATA',…REC_AMT,KASAR_AMT}]` |
| Mixed cash+bank tender in one voucher (KB §12.6 to-verify) | tender grid, `Σ tenders == totalRec` guard | **Match** | `bill-to-bill/page.tsx` tender table; `billToBill.ts` `if(Math.abs(tenderSum-totalRec)>EPS) throw…` |
| **Ornament / metal issue against the receipt** (`SL_PR_DETL`+`MAIN_STOCK`, `ORNA_ISU='Y'`) | — none | **Gap** | `TR_BILL_TO.inlineSql` `UPDATE SL_DATA SET ORNA_ISU='Y'…` + `SL_PR_DETL` reads; web `settleBills` writes no `SL_PR_DETL`/`MAIN_STOCK` |

## 8 · Bank Reconciliation — desktop `UT_BANK` · KB(other) §9 → web `/txn/bank-recon` (`bankRecon.ts`)

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Cleared = row carries `CLR_DATE`; book = Σ(Dr−Cr); cleared = Σ over `CLR_DATE` rows; **Bal Chk** (KB §9.4) | `book / cleared / uncleared` tiles; per-row `amtBal` running balance | **Match** | `bankRecon.ts` `if(r.clr) cleared+=net; … uncleared:r2(book-cleared)`; page tiles `Book/Cleared/Uncleared` |
| Grid `BookType·AcName·VchNo·VchDate·ChqNo·ClrDate·DrAmt·CrAmt·AmtBal` | same columns incl. running `Balance` | **Match** | `bank-recon/page.tsx` `<th>…Chq No…Balance…Cleared…Clr Date</th>`; `bankRecon.ts` pulls `AC_NAME/CHQ_NO` from `CASH_DATA`/`PAY_DATA` |
| Clear a cheque: `F1` on ClrDate → today; sets `AC_DATA.CLR_DATE` | checkbox → `POST /bank-recon/clear` sets `CLR_DATE` | **Match** | `bankRecon.ts` `bankReconClear` `UPDATE "AC_DATA" SET "CLR_DATE"=$4::date…`; page `onChange={(e)=>toggle(t,e.target.checked)}` |
| From/To auto month range | `monthStart()`/`today()` defaults | **Match** | `bank-recon/page.tsx` `useState(monthStart())` / `useState(today())` |
| `F1 = today` convenience on the clear-date cell | checkbox stamps today; no editable per-row date-pick | **Partial** | page `clrDate: on ? today() : null` — no arbitrary clear-date entry |

---

## 9 · RATE CUT — desktop `TR_FINE_SL_PR` / `TR_PR_SL_HEDG` (CUT_DATA/CUT_DETL/CUT_STK_DETL) → web `/txn/rate-cut` (`sales/rateCut.ts`) **and** `/txn/fine-sale` (`bullion/fineSalePurchase.ts`)

**Core desktop model:** "rate cut" = fix the price on metal bought/issued **unfixed**. `TR_FINE_SL_PR` lists open purchase fine (`PR_DETL … WHERE ITM_AMT=0 AND WITH_STOCK='Y' AND ITM_FINE > FINE_CUT_FINE`, `BalFineW = ITM_FINE − FINE_CUT_FINE`), and on save **accumulates** the fixed fine onto the source line (`UPDATE PR_DETL SET FINE_CUT_FINE = FINE_CUT_FINE + STK_FINE, FINE_CUT_NWT/GWT/PCS …`) and reduces `MAIN_STOCK`. Guard: *"Please Enter Less Value form Item Fine"* (`cut ≤ open`). Writes `CUT_DATA`+`CUT_DETL`+`CUT_STK_DETL`+`TAX_DATA`+`MAIN_STOCK`+`AC_DATA`.

**The web splits this desktop form across TWO routes:**

### 9a · `/txn/rate-cut` (`rateCut.ts`) — value + metal + settlement

| Desktop behavior | Web | Verdict | Evidence |
|---|---|---|---|
| Fine = `(net+ght)×(touch+west)/100` (`col15`) | `fine(net,ght,touch,west)` identical | **Match** | `rateCut.ts` `export function fine(...){const pct=touch+west; return round3(pct===0?base:(base*pct)/100)}` |
| Item value by rate basis: per-g / per-10g(`/10`) / per-kg(`/1000`) / per-piece | `itmAmt(fine,rate,rateType,pcs)` same four branches | **Match** | `rateCut.ts` `case '1': /10; case 'K': /1000; case 'P': pcs×rate; default fine×rate` (page `RateType` select Per Gram/10g/Kg/Piece) |
| Net = tax-inclusive back-out `totAmt/(tax+100)×100` (`col26`) | `netAmt(tot,taxPct)` same | **Match** | `rateCut.ts` `netAmt(){return taxPct===0?tot:round0((tot/(tax+100))*100)}` |
| Ledger: value (Dr customer / Cr gold), fixed **fine OUT** on customer, cash/chq/card in, kasar | `buildRateCutLedger` — value leg + metal `SIGN '-' FINE_WT` leg + cash/chq/card + kasar; balances | **Match** (legs) | `rateCut.ts` worked example `ΣDR=ΣCR=30780`; metal leg `{AC_CODE:customer, IT_TYPE:itType, SIGN:'-', FINE_WT:totalFine, DR_AMT:0, CR_AMT:0}` |
| **Draw down the source unfixed lot** (`UPDATE PR_DETL/RATE_CUT_ISU SET FINE_CUT_FINE += …`) | writes `FINE_CUT_FINE` onto its **own** `RATE_CUT_ISU` row only; **no update of the source `PR_DETL`** | **Gap** | `rateCut.ts buildLineRows` sets `FINE_CUT_FINE:c.fine` on the new row; header comment *"PHASE-2 TODO: … MAIN_STOCK … deferred"*; no `UPDATE PR_DETL` in this module |
| Operator **picks the open lot to fix** (desktop lists `PR_DETL` with open fine) | UI has no open-lot picker — operator types net/touch/rate manually | **Gap** | `rate-cut/page.tsx` line grid = free `netWt/touch/rate` inputs; `isuRef` in `RateCutInput` is never populated by the page |
| Cheque/Card tender + Tax/TCS/TDS/Labour/Other (desktop `mSG2_TOTAL` panel) | page exposes **Cash + Kasar only** | **Partial** | `rate-cut/page.tsx` Settlement = `Cash`,`Kasar` inputs only (API supports `chq`/`card` but no UI); no tax/tcs/tds/labour/ght fields |
| Table footprint `CUT_DATA/CUT_DETL/CUT_STK_DETL` + `MAIN_STOCK`+`TAX_DATA` | writes `RATE_CUT_DATA`+`RATE_CUT_ISU`+`AC_DATA` only | **Partial** | `rateCut.ts` `writes:[{table:'RATE_CUT_DATA'},{table:'RATE_CUT_ISU'}]`; different table set from desktop `CUT_*`; MAIN_STOCK/TAX deferred |
| Account config from `BOOK_DETL` SR1/3/4/6/11 | defaulted (`SALEGOLD/CASH/KASAR/LABOUR/OTHER`) | **Partial** | `rateCut.ts` honest caveat: *"BOOK_DETL is EMPTY for book 064 … Accounts are configurable inputs with sensible defaults"* |

### 9b · `/txn/fine-sale` PURC side (`fineSalePurchase.ts`) — the *true* rate-cut drawdown

| Desktop behavior | Web | Verdict | Evidence |
|---|---|---|---|
| Fix open fine on an existing purchase line, guarded `cut ≤ open` | `cuts[]` validated against `PR_DETL` open balance | **Match** | `fineSalePurchase.ts` `const open=r3(itf−fcf); if(cut.fine>open+1e-6) throw…'exceeds open balance'` |
| `UPDATE PR_DETL SET FINE_CUT_FINE += …NWT/GWT/PCS` + `CUT_STK_DETL` link | exact | **Match** | `fineSalePurchase.ts` `UPDATE "PR_DETL" SET "FINE_CUT_FINE"=(…+$5)…` + `writes:[{table:'CUT_STK_DETL', rows:[{SL_NO,SL_DBCD,SL_SRNO,STK_FINE…}]}]` |
| Delete restores the open balance | `deleteFineSalePurchase` reads `CUT_STK_DETL`, subtracts back | **Match** | `fineSalePurchase.ts` `UPDATE "PR_DETL" SET "FINE_CUT_FINE"=greatest(…−$5,0)…` |

*Finding:* the genuine desktop rate-cut fixing (source-line `FINE_CUT_*` drawdown + `CUT_*` tables) lives in **`fine-sale` (PURC + cuts)**, not in `/txn/rate-cut`. `/txn/rate-cut` books the value+metal+settlement but leaves the source unfixed lot untouched (parity **Gap** for the fixing loop).

---

## 10 · FINE SALE / FINE PURCHASE — desktop `TR_FINE_SL_PR` → web `/txn/fine-sale` (`fineSalePurchase.ts`)

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Pure-metal trade priced on fine; `fine = net×touch/100`, `metal = fine×rate` | `fineLineCalc` same | **Match** | `fineSalePurchase.ts` `fine=r3(net*touch/100); metal=r2(fine*fineRate); tax=r2(metal*taxPct/100); net=metal+tax` |
| SALE: **Dr party/cash (net) / Cr fine-sales + Cr GST**, metal OUT `-`; PURC: **Dr fine-purc + Dr input-GST / Cr supplier**, metal IN `+` | exact | **Match** | `fineSalePurchase.ts` sale/purc ledger branches + `{IT_TYPE:itType, SIGN:isSale?'-':'+', FINE_WT:totFine}` |
| GST split CGST/SGST (intra) or IGST (inter); `CGST=SGST=tax/2` | `cgst=sgst=tax/2` or `igst=tax`; `TAX_DATA` rows | **Match** | `fineSalePurchase.ts` `cgst=inter?0:r2(totTax/2)…`; page `Inter-state` select; `TAX_DATA` CGST/SGST/IGST rows |
| Writes `CUT_DATA`+`CUT_DETL`+`TAX_DATA`+`MAIN_STOCK` | same tables | **Match** | `fineSalePurchase.ts` `writes:[{CUT_DATA},{CUT_DETL},{CUT_STK_DETL?},{TAX_DATA?},{MAIN_STOCK}]` |
| TCS / TDS / Kasar / Labour on the `mSG2_TOTAL` panel | — not in web fine-sale | **Partial** | `TR_FINE_SL_PR.calc` computes `Tcs2/Tds2/Kasar2/Rof2`; `fine-sale/page.tsx` has `Tax %` + inter-state only |

---

## 11 · BULLION BOOKING — desktop `TR_BUL_BOOKING` (BUL_DATA) → web `/txn/bullion` (`bullion.ts`)

Desktop grid: `AcCode·ItCode·ItmGwt·McxRate·Premium·ItmRate·ItmAmt·AmtType·Tax·TotAmt·AdjWt·RateType`. Calc: `ItmRate = round(McxRate + Premium)`; `ItmAmt = round(Gwt × ItmRate)` (or `/10`, `/1000` per basis); `TotAmt = ItmAmt + ItmAmt×Tax/100`. Validation: *"Please Insert Transection Type C = Cash or B = Bank"*; *"Please First Select Booking Location"* (for BUL LC SALE inter-branch).

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Booking party + fine wt + rate → value; header `BUL_DATA` + balanced `AC_DATA` | `bullionBooking` — Dr party / Cr bullion-payable; `BUL_DATA` | **Match** (core) | `bullion.ts` `buildBookingLedger` `[{party DR amount},{payableAc CR amount}]`; `writes:[{table:'BUL_DATA', rows:[{MCX_RATE:rate, ITM_RATE:rate, ITM_AMT:amount, ADJ_WT:0}]}]` |
| Advance received now (Dr cash / Cr party) | `advanceAmt` → Dr cash / Cr party | **Match** | `bullion.ts` `if(advance>0){lines.push({cashAc DR advance},{party CR advance})}`; page `Advance ₹` + `Balance due` preview |
| `amount = Gwt × ItmRate` where **`ItmRate = McxRate + Premium`** | `amount = fineWt × rate` — **rate entered directly, no premium** | **Partial** | `bullion/page.tsx` fields `Fine Wt`,`Rate`,`Advance` only; `bullion.ts` `PRM_AMT:0`; desktop `TR_BUL_BOOKING.calc` `val[Row,8]=Round(val[Row,6]+val[Row,7])` (mcx+premium) |
| Tax on booking (`TotAmt = ItmAmt + ItmAmt×Tax/100`) | `TAX_PRC:0`, `TOT_AMT = amount` (no tax) | **Gap** | `bullion.ts` header `TAX_PRC:0, TOT_AMT:amount`; no tax field on page |
| **RateType** basis (per-g / per-10g / per-kg) | not selectable (`amount` override only) | **Gap** | `TR_BUL_BOOKING.calc` `/10.0`, `/1000.0` branches + `cRateType=18`; page has no rate-basis selector |
| `AmtType` C(cash)/B(bank) settlement type | `AMT_TYPE:'C'` fixed default | **Partial** | `bullion.ts` `AMT_TYPE: input.amtType ?? 'C'`; page never sets it |
| Booking **Location** (inter-branch `BUL LC SALE`, `tToLcCode`) | — none | **Gap** | desktop validation *"Please First Select Booking Location"*; web has no location/branch selector |
| Draw-down settlement against booking via `AdjWt` (`TR_BUL_SALE`) | `ADJ_WT:0`; no draw-down voucher wired | **Gap** | `bullion.ts` `ADJ_WT:0` comment *"nothing settled/sold yet"`; no bullion-sale route reduces it |

---

## 12 · ESTIMATE / APPROVAL — desktop `TR_APR_ISU` (APR_DATA) → web `/txn/estimate` **and** `/txn/tour`

Desktop `TR_APR_ISU` = **Approval Issue**: issues tagged stock on approval → `APR_DATA`/`APR_DETL`/`APR_IDTL` + `MAIN_STOCK` OUT, **no money** (KB §9.4). Can **import from Sales Orders** (`SL_ORD_DETL`), tracks `ADJ_GWT/ADJ_NWT`, and feeds Sales / Wh-Sales / Rate-Cut via `ISU_REC` + `ISU_NO` (`RATE_CUT_ISU … BOOK_NAME='WH SALES'`). Billed later through the Sales screen's **`Apr No`** field (KB §9.3).

| Desktop capability | Web | Verdict | Evidence |
|---|---|---|---|
| Approval **issue** of tagged stock → `APR_DATA`/`APR_DETL` + `MAIN_STOCK` OUT, no ledger | `/txn/tour` (`tour.ts tourIssue`) → `APR_DATA`+`APR_DETL`+`MAIN_STOCK` (`TR_TYPE 'O', ITM_SIGN '-'`), empty `AC_DATA` | **Match** (issue) | `tour.ts` docstring *"persists into … APR_DATA/APR_DETL/APR_IDTL … MAIN_STOCK out-movement … NO money ledger"*; `postVoucherTx(...,{ledger:{table:'AC_DATA',lines:[]}, writes:[{APR_DATA},{APR_DETL},{MAIN_STOCK}]})` |
| `APR_IDTL` sub-items + design/karigar/diamond sub-grids | tour writes header+detail only | **Partial** | `tour.ts` writes no `APR_IDTL`; `TR_APR_ISU.gridColumns` has `Dm*`, `Kr*`, design columns |
| **Import from Sales Order** (`SL_ORD_DETL`, sets `DESIGN_ISU='Y'`) | — none | **Gap** | `TR_APR_ISU.inlineSql` `Select … From SL_ORD_DETL …` + `UPDATE SL_ORD_DETL SET DESIGN_ISU='Y'`; tour has no order import |
| Feeds Sales via **`Apr No`** import (bill the kept item) | Sales page has no Apr No (per `vdw-sales.md` (a): **Gap**) | **Gap** | grep: no `APR`/`aprNo` reference in `sales/sales.ts`; `vdw-sales.md` row *"`Apr No` … none → Gap"* |
| **Estimate / quotation** (proforma price sheet) | `/txn/estimate` — compute-only calculator + PDF | **n/a (new)** | `estimate/page.tsx` comment *"compute-only preview — POST /estimate saves no voucher and writes no ledger"`; no `estimate.ts` module (grep: 0 matches) |
| Estimate → **convert to Sale** | — none (recompute in `/txn/sales` manually) | **Gap** | `estimate/page.tsx` only `downloadPdf(html,'estimate')`; no persisted estimate id, no "convert" action into `/txn/sales` |

*Mapping caveat:* the task labels `TR_APR_ISU` as "estimate", but the desktop `TR_APR_ISU` is **Approval Issue** (stock-custody), whose web analog is **`/txn/tour`**. The web **`/txn/estimate`** is a separate quotation calculator with no desktop `TR_APR_ISU` footprint (closest desktop artefact = the `RP_TAG_ESTMATE` estimate report). Both the approval→sale (`Apr No`) and estimate→sale conversions are **Gaps**.

---

## 13 · FINE IN/OUT — web `/txn/fine-inout` (`inout/fineInout.ts`) vs desktop catalog `TR_FN_INOUT`

**Critical mismatch.** The mined catalog `TR_FN_INOUT.behavior.json` is the desktop **Franchise / inter-branch transfer** form: it writes `FAN_DATA`/`FAN_DETL`/`FAN_IDTL`, transfers **barcoded tags** (`BAR_DETL`/`BAR_IDTL`), posts `AC_DATA`+`TAX_DATA`, has a *"Transfer Franchise"* target (`tToLcCode`), and even **copies `ITEM_MAST` across companies** (`INSERT INTO ITEM_MAST … FROM ITEM_MAST WHERE CO_CODE='01'`). Validations: *"Please Select Transfer Franchise"*, *"You Cant Insert New Entry In Inword Voucher"*, *"You Cant Delete InWord Voucher"* (`FormMainBook='FAN PURC'`).

| Desktop `TR_FN_INOUT` (Franchise transfer) | Web `/txn/fine-inout` | Verdict | Evidence |
|---|---|---|---|
| Franchise/branch transfer of **tagged** stock (`FAN_DATA`, `BAR_DETL`) with GST + money ledger | pure **loose-fine** metal move; `INOUT_DATA`+`INOUT_DETL`+`MAIN_STOCK`, **no money** | **Gap** (scope mismatch) | `fineInout.ts` docstring *"pure inventory movement: NO money ledger (AC_DATA is posted empty)"*; `writes:[{INOUT_DATA},{INOUT_DETL},{MAIN_STOCK}]` — none of `FAN_DATA/BAR_DETL/TAX_DATA` |
| IN (`FAN PURC`, inward) / OUT (`FAN SALE`) with franchise account | `direction IN/OUT` → `TR_TYPE 'I'/'O'`, `ITM_SIGN '+'/'-'`, `VCH_TYPE 'FNIN'/'FNOUT'` | **Partial** | `fine-inout/page.tsx` `Direction IN/OUT`; correct signed `MAIN_STOCK`, but on a loose-item basis, not the franchise tag transfer |
| `TAX_DATA` (GST on transfer), cross-company `ITEM_MAST` copy, `FAN_IDTL` | — none | **Gap** | `fineInout.ts` writes none of these |
| Counter-party **metal ledger** leg (fine Dr/Cr to the branch/refinery party) | `AC_DATA` empty even when `partyAc` given | **Gap** | `fineInout.ts` `ledger:{table:'AC_DATA', lines:[]}` — the `partyAc` never gets a fine leg |

*Finding:* `/txn/fine-inout` is a **new, simplified loose-metal in/out** feature; it does **not** reproduce the desktop `TR_FN_INOUT` franchise/branch transfer. If parity to `TR_FN_INOUT` is intended, this is a major Gap; if it is a standalone utility, there is no exact desktop analog in the catalog (the nearest tag-level moves are `TR_INOUT`/`TAG TRFR`).

---

## TOP-5 GAPS (highest business impact)

1. **Rate-cut fixing loop is not closed on `/txn/rate-cut`.** The desktop `TR_FINE_SL_PR` rate-cut *fixes previously-unfixed purchase metal* by drawing down `PR_DETL.FINE_CUT_FINE` (`UPDATE PR_DETL SET FINE_CUT_FINE += STK_FINE …`) and reducing `MAIN_STOCK`. `/txn/rate-cut` (`rateCut.ts`) books value+metal+settlement into `RATE_CUT_DATA/RATE_CUT_ISU` but **never updates the source lot or stock** (`"PHASE-2 TODO … deferred"`), and the page has **no open-lot picker** (operator retypes net/touch/rate). The correct drawdown exists only on `/txn/fine-sale` PURC (`cuts[]`). *Impact: unfixed-metal balances never clear via the rate-cut screen; double-fixing possible.*

2. **Bullion booking drops premium, tax and rate-basis.** Desktop `TR_BUL_BOOKING` computes `ItmRate = McxRate + Premium`, `TotAmt = ItmAmt + Tax`, supports per-g/10g/kg `RateType`, `AmtType` C/B and a booking **location** (`BUL LC SALE`). Web `bullion.ts` takes a single `rate`, sets `PRM_AMT:0`, `TAX_PRC:0`, fixes `AMT_TYPE:'C'`, and has no location/rate-basis. *Impact: booked value & MCX-premium audit trail wrong for real bullion desks.*

3. **Estimate & Approval cannot convert to a Sale.** `/txn/estimate` is compute-only (no persisted estimate, no ledger, PDF only) and `/txn/tour` (approval issue) writes `APR_DATA` but the Sales screen has **no `Apr No` import** (`vdw-sales.md` Gap; no `APR` reference in `sales.ts`). Desktop bills the kept approval item via Sales `Apr No`, and estimates seed the invoice. *Impact: the estimate/approval → invoice workflow is broken end-to-end.*

4. **`/txn/fine-inout` ≠ desktop `TR_FN_INOUT` (Franchise transfer).** The catalog `TR_FN_INOUT` is the tagged **franchise/branch transfer** (`FAN_DATA`, `BAR_DETL`, `TAX_DATA`, cross-company `ITEM_MAST` copy, money ledger). The web route is a pure loose-fine movement (`INOUT_DATA`, empty `AC_DATA`). *Impact: no web equivalent of inter-branch/franchise stock transfer; and fine in/out to a party posts no metal ledger leg to that party.*

5. **Metal (fine) legs missing from Contra & Ledger-Adjust; Employee-JV lacks attendance/%-deductions.** Desktop `TR_CONTRA` (`CR_FINE/DR_FINE`) and `TR_LEDR_ADJ` (`CrFine/DrFine/DiffFine`+`ItType G/S`) adjust **gold/silver** balances; the web `postContra`/`postLedgerAdjust` are money-only (`CR_FINE:0,DR_FINE:0,DIFF_FINE:0`). `TR_EMP_JV` derives gross from attendance (`salary/30×days`) and %-based TDS/PF plus `EmpLdr` advance netting; web `employeeJv.ts` takes flat ₹ amounts with no attendance/%/advance. Web Contra is also only a 2-leg transfer (no N-line contra). *Impact: metal-side ledger adjustments and payroll computation not reproducible.*

---

### Verdict tally (my modules)

| Workflow | Verdict |
|---|---|
| Cash/Bank Receipt (legs, kasar, cash-ceiling, card/upi) | **Match** (Gaps: BankCharg, ClDate, chq-print) |
| Cash/Bank Payment (legs, PAN gate, multi-line) | **Match** |
| Contra (2-leg transfer) | **Partial** (no N-line, no metal legs) |
| Journal Voucher (multi-line balanced) | **Match** (AC_DATA only, no header) |
| Employee JV (legs + EMP_DATA) | **Partial** (no attendance/%/EmpLdr) |
| Fine JV (metal transfer) | **Match** (single-pair; no grid/header) |
| Ledger Adjust (money) | **Partial** (no metal/fine, no opening auto-diff) |
| Bill-to-Bill (open bills, alloc, tender, receipt post) | **Match** (Gap: ornament-issue grid) |
| Bank Reconciliation | **Match** |
| Rate Cut `/txn/rate-cut` | **Partial** (Gap: source-lot drawdown, tender/tax UI) |
| Fine Sale/Purchase + rate-cut fixing `/txn/fine-sale` | **Match** (Partial: no TCS/TDS/kasar/labour) |
| Bullion Booking | **Partial** (Gaps: premium, tax, rate-basis, location, adj-wt) |
| Estimate / Approval → Sale | **Partial/Gap** (issue matches via /txn/tour; conversion absent) |
| Fine In/Out vs TR_FN_INOUT | **Gap** (scope mismatch: loose-fine vs franchise transfer) |

*Read-only verification — no code was modified.*
