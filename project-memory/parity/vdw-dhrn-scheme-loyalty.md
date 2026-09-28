# Desktop ⇄ Web Parity — DHRN (pledge loan) · SCHEME + MEMBERSHIP · LOYALTY/POINTS

Read-only verification. Extends `vdw-sales.md` / `vdw-purchase-karigar.md` / `vdw-masters-reports.md`.

**Desktop truth** = mined behavior catalogs `catalogs/form-behavior/{TR_DHRN_ISU,TR_DHRN_REC,TR_DHRN_INTREC,MS_MEMB,TR_MEMB_ENT,TR_MEMB_ADJ,MS_POINT,BtmSchm,Module_Schm}.behavior.json` (decompiled desktop `gridColumns`/`inlineSql`/`calc`/`validations`/`keyboard`) + video-research KB (`851f2afc…`) for corroborating context.
**Web truth** = `web/apps/web/app/(app)/txn/{dhrn-issue,dhrn-receipt,dhrn-interest,scheme,membership}/page.tsx`, `web/apps/api/src/modules/dhrn/{dhrn,dhrnReceipt,dhrnKhata}.ts`, `web/apps/api/src/modules/membership/{scheme,membership}.ts`, `web/apps/api/src/modules/scheme/passbook.ts`, `web/apps/api/src/routes/txn.ts`, `web/apps/api/src/modules/masters/generated-formfields.ts`.

Legend: **Match** = desktop behavior reproduced · **Partial** = present but incomplete/differs · **Gap** = absent.

> ⚠️ **KB-coverage caveat (honest scoping).** The video-research playlists produced **no dedicated workflow chapter** for DHRN, scheme, membership, or loyalty — grepping `_kb/*.md` for `dhiran|dhrn|pledge|loan|scheme|schm|membership|memb|passbook|loyalty|point` returns only *peripheral* mentions: the persistent top menu `… Reports · Scheme · Dhiran · Exit` (`KB_transaction.md:8`, `KB_master.md:19`, `KB_karigar.md:15`); the seeded system account **`DHRN`** and account groups `03 SECURED LOAN, 04 UNSECURED LOAN, 15 LOANS AND ADVANCES ASSETS` (`KB_master.md:73,124,261`); the backup table list incl. **`POINT_MEMB, POINT_DATA`** (`KB_master.md:254`); the reminder-dashboard datasets **`Dhiran Rem · Schm Rem`** flagged as web gaps (`KB_other.md:554,607,620`); and the sales tender field **`Scheme Amt`** (`KB_transaction.md:76`, `KB_other.md:282`). Therefore the **primary desktop ground truth for these three modules is the mined behavior catalogs** (decompiled source), with the KB confirming only that the modules exist, their account model, and their tables. Every desktop claim below is cited to a specific catalog key.

---

# MODULE 1 · DHRN / PLEDGE-LOAN (TR_DHRN_ISU / REC / INTREC)

Desktop model (from catalogs): a **pawn/pledge loan** — the shop lends cash against pledged gold/silver ornaments. `TR_DHRN_ISU` issues the loan (pledged-item grid + principal + interest), `TR_DHRN_REC` repays principal+interest and releases packets, `TR_DHRN_INTREC` collects interest only. Web splits this into `/txn/dhrn-issue`, `/txn/dhrn-receipt`, `/txn/dhrn-interest` → `dhrn/dhrn.ts` (`issueDhrn`/`receiveDhrn`/`receiveDhrnInterest`).

## 1A · Issue — header fields (TR_DHRN_ISU)

| Desktop | Web (`dhrn-issue/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Party/borrower (`inlineSql` AC picker `AND A.AC_GR IN('01','03','04') / ='15'` — customer/loan groups) | `LookupPicker entity="accounts"` → `borrowerAc`/`borrowerName` | **Match** | catalog `inlineSql` "…FROM AC_MAST … AND A.AC_GR IN('01','03','04') … AND A.AC_GR = '15'"; page `<LookupPicker entity="accounts" … onPick={(r)=>setBorrowerName}` |
| `DHRN_AMT` (loan principal) | `Principal` → `principal` | **Match** | catalog header writes `DHRN_AMT`; page `<label>Principal</label>` → body `principal: Number(principal)` |
| `INT_PRC` interest %, `nMonthlyInt = nIntPrc/12` | `Annual Int %` → `intPrc` | **Partial** | catalog calc `nMonthlyInt.Text = nIntPrc/12.0`; page labels it "Annual Int %" but see rate-basis ambiguity in 1B |
| `cboIntMonth` (INT_MONTH term) | `Int Months` → `intMonths` | **Match** | catalog calc `nIntDays = cboIntMonth × 30`; page `intMonths` → `INT_MONTH` |
| `LOAN_TYPE` (A/G/S — amount/gold/silver) | `Loan Type` select A/G/S | **Match** | catalog `DHRN_REC` inlineSql `AND A.LOAN_TYPE = ' ? '`; page `<select><option value="A">…"G"…"S"`; `issueDhrn` `LOAN_TYPE: input.loanType ?? 'A'` |
| `PACKET_NO` (pledge packet id) | `Packet No` → `packetNo` | **Match** | catalog gridColumns `cPacketNo:1`, header `PACKET_NO`; page `packetNo`→`PACKET_NO` |
| `OTH_AMT` (other charges), `nRecAmt = nIntAmt + nOtherCharges` | `Other Charges` → `otherCharges` | **Match** | catalog calc `nRecAmt = nIntAmt + nOtherCharges`; `issueDhrn` `INT_REC_AMT: round2(intAmt + N(otherCharges)), OTH_AMT` |
| `TO_DATE` (maturity/due) + `VCH_DATE`+time+weekday | `To/Maturity Date` (date only) | **Partial** | catalog header `TO_DATE`; page `<input type="date">`; no time/weekday, and `fromDate` not exposed (defaults to now) |
| `DHRN_BILL` (Ref/bill no), Employe, VchDesc, image, `< >` nav, Print | — none | **Gap** | catalog `inlineSql` selects `A.DHRN_BILL As RefNoL`, `EMP_MAST`, `VCH_DESC`, `AC_IMAGE`/`IMAGE_DATA`; page has no ref-no/employee/remark/image/nav |

## 1B · Issue — pledged-item grid + fine/interest calc (TR_DHRN_ISU)

Desktop grid (`gridColumns`): `Sr·PacketNo·CustName·ItCode·ItName·Pcs·GrWt·OthWt·NetWt·Touch·WestPrc·Fine·Rate·ItAmt·NetAmt·ItType·RateType·ItDesc·OldGwt·OldNwt·OldTouch·OldWest·OldRate·DhrnNo·DhrnYrCd·DhrnDbCd·PacketRec`.
Web collateral grid: `Item·Desc·Pcs·Gross·Net Wt·Touch%·Fine·Rate·Amount`.

| Desktop calc | Web | Verdict | Evidence |
|---|---|---|---|
| `NetWt = GrWt − OthWt` (col8=col6−col7) | Gross & Net are **independent inputs**; no `OthWt` column | **Partial** | catalog calc `mSG[CRow,8] = (mSG[CRow,6] − mSG[CRow,7])`; page has `grossWt`+`netWt` inputs, no other-wt→net compute |
| `Fine = NetWt × (Touch + West%) / 100` (col11=col8×(col9+col10)/100) | `fine = (netWt × touch)/100` — **West% omitted** | **Partial** | catalog calc `mSG[CRow,11] = col8 × (col9 + col10)/100`; page `calc` `const fine = r2((n(l.netWt)*n(l.touch))/100)` — no west% |
| `ItAmt` 4 rate-types: pcs×rate · fine×rate · fine×rate/10 · fine×rate/1000 (`RateType` col16) | `amount = fine × rate` (per-gram only) | **Gap** | catalog calc four variants inc. `col13 = col5×col12`, `col13 = col11×(col12/10)`, `col11×(col12/1000)`; page `const amount = r2(fine * n(l.rate))` — single mode, no RateType col |
| **Interest (issue) = principal × INT_PRC/100 × (30×months)/MsIntYearDays** | `intAmt = accruedInterest(principal, intPrc, months×30, yearDays)` = principal×intPrc/100×(months×30)/360 | **Match** | catalog calc `nIntAmt = nDhrnAmt × nIntPrc/100 × (30×cboIntMonth)/DC_Main.MsIntYearDays`; `dhrn.ts` `accruedInterest()` = `outstandingPrincipal*(annualRatePct/100)*(days/yearDays)`, `DEFAULT_YEAR_DAYS=360` |
| Month interest display `nMonthlyInt = IntPrc/12` | `monthInt = monthlyInterest()` = principal×intPrc/100×30/360 | **Partial** | desktop divides annual by **12**; web uses a **30/360** day figure — numerically ≈ but not the `/12` formula; page preview text "principal × N%/yr × (M×30)/360" |
| `OldGwt/OldNwt/OldTouch/OldRate` (carry old pledge on renewal) | — none | **Gap** | catalog gridColumns `cOldGwt:18…cOldRate:22`; no renewal/old-pledge columns in page |
| Rate-type basis ambiguity: **INT_PRC annual vs per-month** | issue-preview treats `intPrc` as **annual** (×days/360); receipt auto-calc 'M' mode treats it as **per-month** (×months, no /12) | **Partial / to-verify** | `dhrn.ts` `monthlyTermInterest(principal, monthlyRatePct, months)` = `principal*(monthlyRatePct/100)*months` (comment: "INT_PRC is a per-month rate") vs `issueDhrn` annual day-count — internal inconsistency to reconcile vs desktop `CO_SET.DHRN_INT_TYPE`/`MsIntYearDays` |

## 1C · Issue — effects (tables / ledger / stock)

| Desktop write | Web (`issueDhrn`) | Verdict | Evidence |
|---|---|---|---|
| `DHRN_ISU_DATA` header, `ISU_REC='N'` (open flag) | writes `DHRN_ISU_DATA {… ISU_REC:'N', DHRN_AMT, INT_PRC, INT_MONTH, MONTH_INT_AMT, INT_AMT, GOLD_AMT/WT/NWT/DESC}` | **Match** | catalog `UPDATE DHRN_ISU_DATA Set ISU_REC='Y'…` (open='N'); `dhrn.ts` header `ISU_REC: 'N'` |
| `DHRN_ISU_DETL` pledged lines | writes `DHRN_ISU_DETL` from `collateral[]` | **Match** | catalog `SELECT … FROM DHRN_ISU_DETL`; `dhrn.ts` `detl = coll.map(...)` → `{ table:'DHRN_ISU_DETL', rows: detl }` |
| `DHRN_DATA` movement (OS-report source) | writes `DHRN_DATA` movement row per issue | **Match** | catalog `DELETE FROM DHRN_DATA…`; `dhrn.ts` `movement = {… ISU_NO:String(no), DHRN_AMT, INT_AMT}` |
| **Ledger `AC_DATA`**: Dr borrower/loan-asset · Cr cash (`DELETE_DATA` stamps `VCH_VAL_DR = DHRN_AMT`) | `buildDhrnIssueLedger`: **Dr loanAc / Cr cash**, `VCH_TYPE 'DISU'`; `loanAc` defaults to `borrowerAc` | **Match** | catalog issue `DELETE_DATA … DHRN_AMT,0,'A'` (Dr side); `dhrn.ts` `{AC_CODE:loanAc,DR_AMT:principal},{AC_CODE:cashAc,CR_AMT:principal}` |
| `ROJ_MEL_DATA` (day-book) | not in `issueDhrn` writes nor `deleteDhrn` tables | **Partial / to-verify** | catalog `DELETE FROM ROJ_MEL_DATA…` on delete; `deleteDhrn` tables = `[header, DHRN_ISU_DETL, DHRN_DATA, AC_DATA]` — rojmel may be derived, not persisted |
| `MAIN_STOCK` (pledged-metal stock movement) | — not written | **Gap** | catalog `DELETE FROM MAIN_STOCK…` on issue delete implies issue writes it; `dhrn.ts` writes no `MAIN_STOCK` |
| `TEMP_BOOK_DATA` / `REMARK_DATA` / `AC_IMAGE` | — none | **Gap** | catalog inlineSql for all three; not in web |
| Cash-out ledger by tender (bank/cheque) | issue funds from `cashAc` default `'CASH'` only | **Partial** | page sends no tender mode; `issueDhrn` `cashAc = input.cashAc ?? 'CASH'` |

## 1D · Receipt / repayment (TR_DHRN_REC → `/txn/dhrn-receipt`)

Desktop repayment is a **grid + rich settlement** screen: releases pledged packets, supports interest+principal+kasar+rate-cut+advance. Web is an amount-only form.

| Desktop feature | Web (`receiveDhrn` / `dhrn-receipt/page.tsx`) | Verdict | Evidence |
|---|---|---|---|
| Pick pledged loan by `ISU_NO` (helper lists open loans `HAVING SUM(DHRN_REC_AMT) < DHRN_AMT`) | `Issue Voucher No` input + `Check Outstanding` (`GET /dhrn/:isuNo/outstanding`) | **Partial** | catalog inlineSql `…HAVING SUM(B.DHRN_REC_AMT) < A.DHRN_AMT`; page manual `isuNo` input, no open-loan picker |
| Outstanding = principal − Σ receipts | `outstandingTx`: `DHRN_AMT − Σ DHRN_REC_AMT` | **Match** | `dhrn.ts` `outstandingTx` SQL `principal − sum(DHRN_REC_AMT)`; overpay guard `principalRepaid > before` |
| Principal repaid `nDhrnReceived = nPandingDhrn − nAdjDhiran` | `principalRepaid` (plain input) | **Partial** | catalog calc `nDhrnReceived = nPandingDhrn − nAdjDhiran`; web has no adjust/advance term |
| Interest `nIntRecAmt = nIntAmt + nPanIntAmt − nAdjInt` (+ pending interest) | `interest` override, else `computeDhrnInterestTx` (rate × elapsed) | **Partial** | catalog calc `nIntRecAmt = nIntAmt + nPanIntAmt − nAdjInt`; web has no pending-interest (`nPanIntAmt`) or interest-adjust |
| **Kasar** (interest rounding write-off) `nTotRec = … − nIntKasr` | — none | **Gap** | catalog calc `nTotRec = nIntRecAmt + nDhrnReceived − nIntKasr`; absent in `receiveDhrn` |
| **Rate-cut → fine gold** `nRcutAmt = nTotRec × nFineRate; nOsAmt = nRcutAmt − nPayAmt` | — none | **Gap** | catalog calc `nRcutAmt = nTotRec × nFineRate` (+`nPayAmt`,`nOsAmt`); web repayment is pure cash |
| **Advance / unchak** `UNCHAK_DHRN_REC` | — none | **Gap** | catalog inlineSql `SUM(UNCHAK_DHRN_REC) As AdvanceDhrnRec`; calc `nDhrnReceived = … + nUnchakDhrnRec`; absent |
| **Packet release** `UPDATE DHRN_ISU_DETL SET PACKET_REC='Y'` + `ISU_REC` toggle | — no packet/collateral release grid | **Gap** | catalog `UPDATE DHRN_ISU_DETL SET DHRN_ISU_DETL.PACKET_REC = 'Y'…`; web writes only `DHRN_REC_DATA` |
| **Re-issue / renewal** `OLD_ISU_YRCD/DBCD/NO`, `PACKET_RE_ISU` | — none | **Gap** | catalog inlineSql `SELECT OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ISU_NO FROM DHRN_ISU_DATA…`; absent |
| Ledger: Dr cash(P+I) / Cr loan(P) / Cr interest-income(I) | `buildDhrnReceiptLedger` exactly this, `VCH_TYPE 'DREC'` | **Match** | `dhrn.ts` `{cashAc,DR:P+I},{loanAc,CR:P},{intIncAc,CR:interest}` |
| Tender via bank/cheque | cash-only (`cashAc` default `'CASH'`, page sends none) | **Gap** | `receiveDhrn` `cashAc = input.cashAc ?? 'CASH'`; page body has no mode/bankAc |
| `DHRN_REC_DATA` + `DHRN_DATA` + `ROJ_MEL_DATA` + `MAIN_STOCK` written | writes `DHRN_REC_DATA` only (`DHRN_OS_AMT`) | **Partial** | catalog deletes all four; `receiveDhrn` writes `{table:'DHRN_REC_DATA'}` only (no DHRN_DATA movement on repayment) |

## 1E · Interest-only receipt (TR_DHRN_INTREC → `/txn/dhrn-interest`)

| Desktop | Web (`receiveDhrnInterest`) | Verdict | Evidence |
|---|---|---|---|
| Collect interest, principal unchanged | Dr cash / Cr `INTINC`; outstanding unchanged; `DHRN_REC_AMT:0` | **Match** | catalog `DELETE_DATA … INT_REC_AMT` (Cr); `dhrn.ts` interest-only ledger + `recHeader {DHRN_REC_AMT:0, INT_REC_AMT:interest}` + `DHRN_DATA` movement `INOUT 'I'` |
| Interest method **simple day-count**: `nPandingDhrn × IntPrc/100 / MsIntYearDays × nIntDays` | `accruedInterest` (day-count) when `CO_SET.DHRN_INT_TYPE='D'` | **Match** | catalog calc `nIntAmt = nPandingDhrn × nIntPrc/100 / DC_Main.MsIntYearDays × nIntDays`; `dhrn.ts` `accruedInterest` |
| Interest method **flat monthly**: `nMonthIntAmt × cboIntMonth` | `monthlyTermInterest` (per-month × months) when type `'M'` | **Partial** | catalog calc `nIntAmt = nMonthIntAmt × cboIntMonth`; web `monthlyTermInterest` differs on annual-vs-monthly basis (see 1B) |
| **Interest method COMPOUND**: `nPandingDhrn × (1+IntPrc/100)^nIntYear − nPandingDhrn`, prorated by months | — none | **Gap** | catalog calc `num11 = nPandingDhrn × Math.Pow(1.0 + nIntPrc/100, nIntYear) − nPandingDhrn; nIntAmt = num11/(nIntYear×12) × cboIntMonth`; web has no compound path |
| **Rate-cut** interest→fine `nRcutAmt = nIntAmt × nFineRate; nPayAmt`; `nIntMonth = round(days/30 − 0.51)+1` | — none | **Gap** | catalog calc `nRcutAmt = nIntAmt × nFineRate`, `nIntMonth = Math.Round(nPandingDays/30 − 0.51)+1`; absent |

## 1F · DHRN reports

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| Pledge/issue receipt (`DhrnIssue.rpt`) | `dhrnReceipt.ts` `dhrnIssueHtml` (DHRN_ISU_DATA+DETL, borrower, collateral, principal, int rate/month, due date, packet, words) → `GET /dhrn/issue-receipt` | **Match** | `txn.ts:406` `app.get('/dhrn/issue-receipt'…)`; page `View Pledge Receipt` opens it |
| Loan khata/ledger (`DhrnKhataVahi.rpt`) | `dhrnKhata.ts` `dhrnKhataHtml`: DHRN_DATA running loan+int accrued−repaid−int-paid → balance; `GET /dhrn/khata` | **Match** | `txn.ts:430`; `dhrnKhataHtml` `bal += loan + intAcc − repaid − intPaid` |
| `RP_DHRN_OS` / `RP_DHRN_LOAN` (outstanding & loan reports; catalogs exist) | `outstanding()` re-exported (`reports.ts:16` `dhrnOutstanding`); no dedicated OS/LOAN report page | **Partial** | catalog files `RP_DHRN_OS.behavior.json`/`RP_DHRN_LOAN.behavior.json` exist; web exposes the number, not the full aged OS report |

---

# MODULE 2 · SCHEME SAVINGS + MEMBERSHIP (AD_MAST / AD_MEMB / AD_DATA / AD_OS / AD_ADJ)

Desktop model: a **monthly gold/amount saving scheme**. `MS_MEMB` enrolls a member into a scheme (`AD_MEMB`, scheme master `AD_MAST`); `TR_MEMB_ENT` collects monthly installments (books **074 MBENT** entry / **075 MBOP** opening → `AD_DATA` + `AD_OS`); `TR_MEMB_ADJ` matures/redeems (book **076** → `AD_ADJ`). Web: `/txn/scheme` → `membership/scheme.ts` (`enrollScheme`/`schemeInstallment`/`schemeOpening`/`schemeMaturity`) + `scheme/passbook.ts`.

> Naming note: the **savings scheme** backend is `membership/scheme.ts`; the web `membership/membership.ts` is the **loyalty-points** module (Module 3). `BtmSchm`/`Module_Schm` catalogs are desktop **year-transfer / data-reset utilities** (they bulk-`INSERT/DELETE` `AD_*`, `DHRN_*`, `OP_DATA`, masters), not the installment form — so 2B/2C are verified against `TR_MEMB_ENT`/`TR_MEMB_ADJ`.

## 2A · Scheme master + member enrollment (MS_MEMB → `/scheme/enroll`)

| Desktop | Web (`enrollScheme`) | Verdict | Evidence |
|---|---|---|---|
| Scheme master `AD_MAST` (SCHM_CODE, SCHM_NAME, SCHM_AMT, SCHM_TYPE, SCHM_MONTH, SCHM_AC, BONUS_PRC) | required to pre-exist (`SELECT SCHM_NAME FROM AD_MAST … else 'scheme not found'`); **no web create form found** | **Partial / Gap** | catalog `MS_MEMB` inlineSql `SELECT SCHM_CODE,SCHM_NAME,SCHM_AMT … FROM AD_MAST`; `scheme.ts` reads AD_MAST but no `AD_MAST` config in `generated-formfields.ts` |
| Member row `AD_MEMB` (MEMB_CODE auto, MEMB_NAME, MEMB_AMT, AC link, mobile, city, gold wt, exp date, image) | writes `AD_MEMB {MEMB_CODE(auto 5-digit), MEMB_NAME, MEMB_AMT, JOIN_DATE}` | **Partial** | catalog `MS_MEMB` insert covers mobile/city/district/`ITM_GWT`/image; `scheme.ts` `INSERT INTO AD_MEMB(… MEMB_NAME, MEMB_AMT, JOIN_DATE …)` only |
| Member code auto-generate | `COALESCE(MAX(CAST(MEMB_CODE AS INT)),0)+1` padded 5 | **Match** | catalog calc `tAcCode.Text = Rshlp…CoCode + 1` fmt `00000`; `scheme.ts` `…MAX(CAST("MEMB_CODE" AS INTEGER))+1 … padStart(5,'0')` |
| Duplicate-member guard | rejects existing MEMB_CODE in scheme | **Match** | catalog validation "Enter Membaer Name and Scheme Detail"; `scheme.ts` `if (ex.length) throw … 'already enrolled'` |
| Member (customer) via `AC_MAST` picker | page `LookupPicker entity="accounts"` → membCode | **Match** | catalog inlineSql `SELECT … FROM AC_MAST … CAST(AC_CODE AS INT) > 99`; `scheme/page.tsx` `<LookupPicker entity="accounts" … onPick>` |

## 2B · Monthly installment (TR_MEMB_ENT → `/scheme/installment` + `/scheme/opening`)

Desktop grid (`gridColumns`): `Sr·MembCode·MembName·RecDate·WithUpi·RecAc·Rate·GrWt·Amount·EntryMod·ChqNo·BankName·MobileNo·MembAmt·UpiName` — a **multi-member collection grid** with **gold conversion**.

| Desktop | Web (`postMemberEntry`) | Verdict | Evidence |
|---|---|---|---|
| Books **074 MBENT** installment / **075 MBOP** opening (BOOK_NAME 'MEMB ENTRY'/'MEMB OPENING') | `MEMB_ENTRY={book:'074',vchType:'MBENT'}`, `MEMB_OPENING={book:'075',vchType:'MBOP'}`; `ENT_TYPE 'E'/'O'` | **Match** | catalog `INSERT INTO AD_DATA(… ENT_TYPE …)` + book tags; `scheme.ts` `MEMB_ENTRY/MEMB_OPENING`, `ENT_TYPE: tags.entType // 'E'…'O'` |
| Ledger: Dr cash/bank (money in) / Cr scheme-liability `AD_MAST.SCHM_AC` | `buildTransferLedger(key, vchType, recAc, liabAc)`; opening posts **no** ledger | **Match** | `scheme.ts` `liabAc = AD_MAST.SCHM_AC … ?? 'SCHEME'`; `ledger = isOpening ? [] : buildTransferLedger(...)` — matches TR_MEMB_ENT L4660 opening = AD_OS only |
| **Gold conversion** `GrWt = Amount / Rate`, `Amount = GrWt × Rate` at day rate `ToDayGlRate = FINE_GL_RATE/10` | — installment stored as **cash `MEMB_AMT` only**; no `ITM_GWT`/`ITM_RATE`, no RATE_MAST fetch | **Gap** | catalog calc `val[Row,7] = val[Row,8]/val[Row,6]` (GrWt=Amt/Rate) + `ToDayGlRate = FINE_GL_RATE/10.0`; `scheme.ts` `AD_DATA` row has `MEMB_AMT, TOT_AMT` — no gold leg |
| **Multi-member grid** (many members per voucher) | one member per submit | **Gap** | catalog gridColumns per-row MembCode/MembName…; `scheme/page.tsx` single `inst.membCode` |
| **UPI tender** (`UPI_DATA`, WithUpi/UpiType/UpiId cols) | `mode` cash/cheque/card/upi/bank but writes `REC_AC`+`CHQ_NO` only — **no `UPI_DATA` row** | **Partial** | catalog inlineSql `INSERT … UPI_DATA`, `SELECT UPI_TYPE,UPI_ID FROM UPI_DATA`; `scheme.ts` writes AD_DATA `REC_AC, CHQ_NO`; no UPI_DATA |
| Writes `AD_DATA` + `AD_OS` (accrue, SIGN '+', OS_TYPE 'A') | writes `AD_DATA` + `AD_OS {SIGN:'+', OS_TYPE:'A', ADJ_AMT}` | **Match** | catalog `SELECT … FROM AD_OS … SUM(CASE WHEN SIGN='+' …)`; `scheme.ts` `AD_OS {SIGN:'+', OS_TYPE:'A'}` |
| `RecDate` per installment (month code) + Employe mandatory | `vchDate`; no per-row month code, no employee | **Partial** | catalog calc `MSG[Row,3] = mid(vchDate)+"/"+month+"/"+year` (RecDate), validation "Please Select Employee Code"; page has neither |
| `ROJ_MEL_DATA` day-book | not persisted by web | **Partial / to-verify** | catalog `DELETE FROM ROJ_MEL_DATA…`; `deleteSchemeInstallment` tables = `['AD_DATA','AD_OS','AC_DATA']` |

## 2C · Maturity / redemption (TR_MEMB_ADJ → `/scheme/maturity`)

Desktop grid: `Sr·SchmCode·MembCode·MembName·GoldWt·GoldRate·GoldAmt·MembTot·Bonus·LessAmt·SBilNo·SBilAmt·MembAdjAmt·MembBal·PaidAc`.

| Desktop | Web (`schemeMaturity`) | Verdict | Evidence |
|---|---|---|---|
| Book **076 MBADJ** → `AD_ADJ` (INOUT 'O', SIGN '-') + `AD_OS` ('D'/'-') + reversed `AC_DATA` | exactly this: `MEMB_ADJUST={book:'076',vchType:'MBADJ'}`, `AD_ADJ {SIGN:'-',INOUT 'O',ENTRY 'A'}`, `AD_OS {OS_TYPE:'D',SIGN:'-'}` | **Match** | catalog `DELETE_DATA … FROM AD_ADJ`, `INSERT AD_OS`; `scheme.ts` `AD_ADJ`+`AD_OS` rows, `buildTransferLedger(key, 'MBADJ', liabAc, payAc)` (Dr liability/Cr cash) |
| `MembAdjAmt = MembTot + Bonus − LessAmt`; `MembBal = MembTot + Bonus − (AdjAmt + Less)` | `payout = amount + bonus − less` | **Match** | catalog calc `val[Row,12] = col7+col8−col9`; `scheme.ts` `payout = round2(amount + bonus − less)` (writes `MEMB_BONUS`,`MEMB_LESS`,`ADJ_AMT`) |
| **`GoldAmt = GoldWt × GoldRate`** (gold-scheme valuation) | — takes plain `amount`; `GOLD_WT:0, GOLD_RATE:0, GOLD_AMT:0` | **Gap** | catalog calc `val[Row,6] = val[Row,4] × val[Row,5]`; `scheme.ts` maturity writes zeroed gold fields |
| **Redeem into a SALES BILL** `SBILL_NO/SBILL_YRCD/SBILL_DBCD` (apply scheme to a purchase) | — none; payout is cash/bank only | **Gap** | catalog gridColumns `cSBilNo:10,cSBilAmt:11`, inlineSql `… A.SBILL_NO <> ''`; `scheme.ts` has no SBILL linkage |
| Update `AD_MEMB.EXP_DATE` on maturity | — not updated | **Gap** | catalog `UPDATE AD_MEMB SET EXP_DATE = ' ? '…`; absent in `schemeMaturity` |
| Payout tender mode (cash/cheque/card/upi/bank) | `mode` → `settlementAc` | **Match** | `scheme.ts` `payAc = settlementAc(mode, bankAc)`; page `PAY_MODES` select |

## 2D · Scheme passbook report

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| `SchmPassBook.rpt` (member+scheme, per-installment ledger, paid/plan, total, bonus%, maturity) | `passbook.ts` `schemePassbookHtml` (AD_MEMB+AD_MAST+AD_DATA running total, `paidCount/months`, `BONUS_PRC`, maturity value) → `GET /scheme/passbook` | **Match** | `txn.ts:418` `app.get('/scheme/passbook'…)`; `schemePassbookHtml` `running += amt`, `bonus = totalPaid*bonusPrc/100`, `Maturity Value = totalPaid+bonus` |
| Installment mode shown (Cash/Cheque/UPI) | derives mode from `WITH_UPI`/`CHQ_NO`/`REC_AC` | **Match** | `passbook.ts` `const mode = num(r.WITH_UPI)>0 || r.UPI_NAME ? 'UPI' : (r.CHQ_NO ? 'Cheque…' : (r.REC_AC ? 'Bank':'Cash'))` |

---

# MODULE 3 · LOYALTY / POINTS (MS_POINT + points accrual)

Desktop model: `MS_POINT` is the **loyalty rule master** — defines point rules and enrolls card members. Tables `POINT_MAST` (rule) + `POINT_MEMB` (card members). Web: rule master via generic CRUD (`POINT_MAST` config); enrollment + earn/redeem in `membership/membership.ts` (`/members`, `/members/points`) → `POINT_MEMB` + `POINT_DATA`.

## 3A · Point rule master (MS_POINT → `POINT_MAST` master config)

Desktop grid 1 (`gridColumns`): `Sr·PointType·SlValue·PointCount·FixPoint·1GmPoint`; validation requires ≥1 of `1gm/fix/slvalue/pointcount` non-zero.

| Desktop field | Web (`generated-formfields.ts POINT_MAST`) | Verdict | Evidence |
|---|---|---|---|
| `POINT_TYPE` | `{"col":"POINT_TYPE","label":"Point Type"}` | **Match** | catalog gridColumns `cPointType:1`; formfields `POINT_TYPE` |
| `SlValue → PointCount` (points per sale value) = `SL_AMT`/`SL_POINT` | `{"col":"SL_AMT",…}`, `{"col":"SL_POINT",…}` | **Match** | catalog `cSlValue:2,cPointCount:3`; formfields `SL_AMT`+`SL_POINT` |
| `FixPoint` (fixed points) | `{"col":"FIX_POINT",…"type":"number"}` | **Match** | catalog `cFixPoint:4`; formfields `FIX_POINT` |
| `1GmPoint` (points per gram) = `GRM_POINT` | `{"col":"GRM_POINT","label":"Grm Point"}` | **Match** | catalog `c1GmPoint:5`; formfields `GRM_POINT` |
| `POINT_AMT`/`MIN_POINT`/`CUR_IN_USE` | present | **Match** | formfields `POINT_AMT`,`MIN_POINT`,`CUR_IN_USE` |
| `POINT_MEMB` card members (CARD_NO, member details grid 2) | `enrollMember` writes `POINT_MEMB {MEMB_CODE, MEMB_NAME, MOBILE_NO, CARD_NO}` | **Match** | catalog grid2 `cAcCardNo:6,cAcMemb:9`; `membership.ts` `INSERT INTO POINT_MEMB(… MEMB_NAME, MOBILE_NO, CARD_NO)` |

## 3B · Enrollment + earn/redeem (POINT_MEMB / POINT_DATA → `/members`, `/members/points`)

| Desktop / model | Web (`membership.ts`) | Verdict | Evidence |
|---|---|---|---|
| Card member in `POINT_MEMB` (PK CO_CODE+POINT_CODE+MEMB_CODE) | `enrollMember` INSERT `POINT_MEMB`; dup guard | **Match** | `membership.ts` header + `INSERT INTO POINT_MEMB(tenant_id,CO_CODE,POINT_CODE,MEMB_CODE,…)`; page `/txn/membership` enroll form |
| Points balance **derived** from `POINT_DATA` ledger (Σ earn − Σ redeem) — `MEMB_POINT` is a flag | `balanceTx`: `Σ(INOUT 'I' TOT_POINT) − Σ(INOUT 'O' TOT_POINT)`; `listMembers` derives points | **Match** | `membership.ts` comment "MEMB_POINT is varchar(1) flag, NOT balance… derived from POINT_DATA"; `balanceTx` SQL `sum(CASE WHEN INOUT_TYPE='I' THEN TOT_POINT ELSE -TOT_POINT END)` |
| Earn/redeem writes `POINT_DATA` (INOUT I/O, TOT_POINT); no money ledger | `postPoints` INSERT `POINT_DATA {VCH_TYPE 'PERN'/'PRED', INOUT 'I'/'O', TOT_POINT}`, book `PNT`; redeem-overdraw guard; **no AC_DATA** | **Match** | `membership.ts` `inout = type==='redeem'?'O':'I'`, `INSERT INTO POINT_DATA(…)`, `if (inout==='O' && pts>cur) throw 'exceeds balance'` |

## 3C · Points **accrual** (rule → auto-points on sale)

| Desktop / model | Web | Verdict | Evidence |
|---|---|---|---|
| Accrual **rules** captured in `MS_POINT` (`SL_AMT→SL_POINT`, `GRM_POINT`/gm, `FIX_POINT`) intended to award points from a sale's value/weight | rule columns stored (`POINT_MAST`) but **no engine consumes them**; `postPoints` requires the operator to **key the point count manually** (`points` is a required input) | **Gap** | `membership.ts` `postPoints({points})` uses the supplied `pts` verbatim; no `SL_AMT/GRM_POINT/FIX_POINT` computation anywhere |
| Points earned **automatically on a Sales Invoice** | `sales/sales.ts` does **not** call `postPoints`/touch `POINT_*` (grep `POINT_DATA|earnPoints|awardPoints` across `apps/api/src` → only `membership.ts`, `generated-formfields.ts`, `backup.ts`) | **Gap** | grep result: no `POINT_*` reference in `sales/`; loyalty is a standalone manual screen, not wired into billing |
| Manual earn/redeem screen | `/txn/membership` earn/redeem form (points + optional bill amount) | **Web addition / Partial** | `membership/page.tsx` "Earn / Redeem Points" — richer manual control than desktop master, but not the rule-driven accrual |

> Caveat: `MS_POINT` catalog is a **master editor only** (no sale-time accrual code captured), and the KB has no loyalty workflow video, so the *exact desktop accrual trigger* (which screen applies `SL_AMT/GRM_POINT/FIX_POINT`) is not in the mined evidence. What is verifiable: the web keeps the same rule columns but implements **no rule-based computation and no billing hook** — points must be entered by hand.

---

# TOP 5 GAPS (priority for closing web parity)

1. **DHRN receipt/interest — rate-cut ("Rcut") to fine gold + kasar + advance + compound interest are all missing.** Desktop `TR_DHRN_REC`/`TR_DHRN_INTREC` compute `nRcutAmt = nTotRec × nFineRate` (settle a cash loan by converting to fine gold), `nTotRec = … − nIntKasr` (rounding), `UNCHAK_DHRN_REC` (advance), and a **compound** option `nPandingDhrn × (1+IntPrc/100)^nIntYear`. Web `receiveDhrn`/`receiveDhrnInterest` do only Dr-cash/Cr-loan(+interest-income) with no rate-cut, kasar, advance, or compounding. **Impact: gold-loan settlement and NBFC-style interest are not reproducible.**

2. **DHRN pledged-collateral release + renewal not implemented.** Desktop repayment flips `DHRN_ISU_DETL.PACKET_REC='Y'` / `DHRN_ISU_DATA.ISU_REC` to release ornaments, and supports re-issue via `OLD_ISU_NO`/`PACKET_RE_ISU`. Web `receiveDhrn` writes only `DHRN_REC_DATA` (no packet-release grid, no renewal). **Impact: cannot track which pledged items are still held vs redeemed.**

3. **Scheme installment gold-conversion + multi-member grid + UPI missing.** Desktop `TR_MEMB_ENT` converts each installment to grams at the day rate (`GrWt = Amount / (FINE_GL_RATE/10)`), collects **many members in one voucher**, and writes `UPI_DATA`. Web `schemeInstallment` stores a single member's cash `MEMB_AMT` with no gold weight, no grid, and no `UPI_DATA`. **Impact: gold-savings schemes (the common jeweller product) lose their gram accrual.**

4. **Scheme maturity cannot redeem into a sales bill or value gold.** Desktop `TR_MEMB_ADJ` computes `GoldAmt = GoldWt × GoldRate` and adjusts the matured balance against a **sales invoice** (`SBILL_NO`) plus updates `AD_MEMB.EXP_DATE`. Web `schemeMaturity` only pays cash/bank (`amount+bonus−less`) with zeroed gold fields and no bill linkage / expiry update. **Impact: the "save monthly, buy jewellery at maturity" flow is not supported.**

5. **Loyalty points accrual is not rule-driven and not wired to sales.** Desktop `MS_POINT` defines `SL_AMT→SL_POINT`, `GRM_POINT`/gm and `FIX_POINT`; web keeps these columns (`POINT_MAST`) but `postPoints` takes a **manually keyed** point count and `sales/sales.ts` never awards points (no `POINT_*` reference). **Impact: customers earn no automatic points on purchases.**

---

## Verified-Match highlights (parity that IS solid)
- DHRN **issue day-count interest** `principal × INT_PRC/100 × (months×30)/360` reproduced exactly (`accruedInterest`, `DEFAULT_YEAR_DAYS=360`).
- DHRN **issue ledger** Dr borrower-loan / Cr cash (`VCH_TYPE 'DISU'`) + `DHRN_ISU_DATA(ISU_REC='N')` + `DHRN_ISU_DETL` + `DHRN_DATA`; **outstanding** = principal − Σ receipts with overpay guard.
- DHRN **interest-only** flow: outstanding unchanged, Dr cash / Cr INTINC, `DHRN_REC_AMT:0`.
- Scheme **book tags 074 MBENT / 075 MBOP / 076 MBADJ** and the balanced installment (Dr cash / Cr `SCHM_AC`) vs mirror-image maturity (Dr `SCHM_AC` / Cr cash) with `AD_OS` '+'/'−' accrual/redemption.
- Scheme **passbook** (running total, bonus%, maturity value) and DHRN **pledge receipt** + **khata-vahi** reports.
- Loyalty **balance model** — derived from `POINT_DATA` (Σ 'I' − Σ 'O'), `MEMB_POINT` treated as a flag, no money ledger; point-rule master columns (`POINT_MAST`) map 1:1 to `MS_POINT`.

---
_Read-only verification — no code modified. Desktop evidence = behavior catalogs (decompiled) + KB context; web evidence = quoted source. Items marked to-verify need a live-DB or UI check to confirm._
