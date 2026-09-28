# KB — KARIGAR module (manufacturing / metal issue ↔ ornament receive)

> Golden master = **DataCareNext** desktop (1280w tutorial keyframes + Sarvam Hindi narration).
> Web target = `web/apps/web/app/(app)/txn/karigar-*` → shared `components/KarigarForm.tsx` → API
> `web/apps/api/src/modules/manufacturing/karigar.ts` (routes in `src/routes/txn.ts`).
> Desktop code cross-refs: `extracted_code/DataCareNext/DataCareNext/{TR_MFG_KR_ISU_REC,Ac_Tax,Ac_Stock,MS_UPDATE,RP_LEDR}.cs`.
> This KB owns **2 videos** (playlist key = `karigar`). Frame cites `kf_NNN` are that video's `keyframes/kf_NNN.jpg`.
> Scope: this file documents the desktop screens EXACTLY (field labels + grid columns drive the web forms), the
> issue↔receive **fine-weight accounting**, and the desktop→web parity gaps.

Karigar = a **party account in group `10` KARIGAR SUNDRY CR** (kf_023@Gd0TSp2OoXA: `Ac Group [10] KARIGAR SUNDRY CR`),
created on-the-fly with **F1** from the transaction's `Party` field. In the tutorials the karigar is
`000209 · MANOJ KARIGAR`.

Persistent chrome on every karigar screen: top menu `07/07/2021 · Home · Company · Master · Tran 1 · Tran 2 · Other · Karigar · Reports · Scheme · Dhiran · Exit`; status bar `Orange · Live Rate · Fine Gold : 49368 · Fine Silver : 69917 · Rate Date : 18-04-2021 · Service End`; top-right live party balance `NNN.NNN : Dr/Cr Gold` / `: Cr Amt` / `: Silvr`. **Karigar menu** (left rail): `Kr Issue · Kr Received · Kr Design Isu · Cust Repar · Kr Repar Isu · Kr Repar Rec · Cust Repar Isu` (web builds only Issue + Receive).

---

## Summary table

| # | Video ID | Screen (title) | Menu path | Web route → page | Core fine math (verified) | Stock leg (`MAIN_STOCK`) | Fine/metal ledger | Money leg (`AC_DATA`) | Parity |
|---|----------|----------------|-----------|------------------|---------------------------|--------------------------|-------------------|-----------------------|--------|
| 1 | `Gd0TSp2OoXA` | **Karigar Issue** | Karigar → Kr Issue | `/txn/karigar-issue` → `KarigarForm(mode=issue)` · `POST /karigar/issue` | `fine = NetWt × Touch / 100` → `100 × 100/100 = 100.000` | 999 GOLD **OUT** `TR_TYPE 'O' / sign '−'` −100.000 (Cl 300→200, kf_035) | karigar **Dr Gold 100.000** (kf_038) | none (money totals = 0) | **gap** — 3-col toy vs 16-col grid; no `Dr Gold` shown; no party lookup / totals panel |
| 2 | `CO9Ro-ZeeE8` | **Karigar Receipt** | Karigar → Kr Received | `/txn/karigar-receive` → `KarigarForm(mode=receive)` · `POST /karigar/receive` | `fine = NetWt × (Touch + West%) / 100` → `65 × (92+0)/100 = 59.800` | GOLD ORNAMENTS **IN** `TR_TYPE 'I' / sign '+'` +5 pcs / +65.000 / fine 59.800 (KREC, kf_037/039) | karigar Dr Gold reduced by 59.800 ⇒ **40.200** left (kf_035) | labour **Cr Amt 6,825** = LAmt 6500 + 5% GST 325 (Dr LABOUR / Cr karigar, kf_035) | **gap** — no GhtWt/Ltype/stone/barcode sub-grids; no labour-payable settlement; no GST/print |

**The loop (why it matters):** issue posts `Dr Gold` (karigar owes fine); receive posts `Cr Gold` for the accountable fine of the returned ornaments and books **labour as a separate money `Cr Amt`**. Metal balance = `Σ fine issued − Σ fine received`. **Wastage closes the loop**: because receive fine uses `(Touch + West%)`, a karigar who returns metal at a lower touch but within an agreed wastage % nets to a **zero** gold balance (web test: issue `100g@92%`=92 fine, receive `100g@90%`+2% west=92 fine ⇒ balance 0). In these tutorials West%=0, so 100 issued − 59.8 received = **40.200 Dr Gold still outstanding** (kf_035@CO9Ro).

---

# VIDEO 1 — KARIGAR METAL ISSUE

- **ID:** `Gd0TSp2OoXA` · playlist `karigar` · title *"Karigar Metal Issue"*
- **Transcript:** `project-memory/video-research/karigar/Gd0TSp2OoXA/transcript.sarvam.txt`
- **Keyframes:** `…/Gd0TSp2OoXA/keyframes/kf_*.jpg` (read: kf_006, 015, 019, 023, 027, 031, 033, 035, 038, 040)

## 1. Screen title + menu path
**Title:** `Karigar Issue` (form tab `Kr Issue 1`).
**Menu path:** `Karigar → Kr Issue`.
Narration: *"फर्स्ट यहां पे कारीगर मेनू में जाना है … कारीगर मेनू में यहां पे ऑप्शन आ जाएगा के आर इशू"* ("first go to the Karigar menu … in the Karigar menu you get the option **Kr Issue**").

## 2. Header fields + grid columns
**Header (kf_019, kf_031):**
`Vch No` [00001] + **`F1`** · `Vch Date` [07/07/2021] + time [21:10:25] + weekday [Wednesday] · `Ref No` · `Party` [000209 | MANOJ KARIGAR] (F-lookup, create via **F1**). Top-right live balance labels: `: Amt` · `: Gold` · `: Silvr`.

**Main grid (16 columns, kf_019/kf_031):**
`Sr · TagNo · ItCode · ItName · Counter · Pcs · GrWt · OthWt · NetWt · Touch · West% · Fine · ConIt · Con% · ConWt · TotWt`.
Filled row (kf_031): `1 · — · 999 · 999 GOLD · — · Pcs 0 · GrWt 100.000 · OthWt 0.000 · NetWt 100.000 · Touch 100.00 · West% 0.00 · Fine 100.000 · — · — · — · TotWt 100.000`. (`ConIt/Con%/ConWt` = optional metal-conversion leg, unused here.)

**Footer / totals panel (kf_031):** left = image-attach box · `Employe` · `Bank` · `Vch Desc`; nav `< >`. Right totals: `Net Amt · Disc Amt · Tax Amt · Rof Amt · Total Amt · Cheque Amt · Card Amt · Cash Amt · Kasar Amt · Os Amt` (all blank for a pure metal issue). **Live balance in red: `100.000 : Dr Gold`.** Buttons: `Print · Save · Cancel · Delete · Exit`.

## 3. Step-by-step operator workflow
1. **Check stock first** via the in-screen Stock Report shortcut (kf_015, tab `Stock Report 2`). Filters: `Gross Wise Weight` ☐ · `Date 01/04/2021–07/07/2021` · `Item Gold` · `Stock All` · tabs `Group·Product·Item·Design·Safe·Table·Trading`. Grid: `Sr · Item Name · OpPcs · OpWt · PrPcs · PrWt · InPcs · InWt · OuPcs · OuWt · SlPcs · SlWt · ClPcs · ClWt`. `999 GOLD` shows **OpWt 300.000 → ClWt 300.000** (no txns yet). Narration: *"300 ग्राम हमने यहां पे डाला था ओपनिंग … क्लोजिंग में उतना ही स्टॉक"* ("we put 300g as opening … same stock in closing").
2. In **Kr Issue**, `Enter Enter Enter` to reach `Party`; type name → **DataCare Help** party popup (`AcName · AcCode · Group · Address · Mobile`, kf_019).
3. Karigar absent → press **F1** → **Party Master** opens (kf_023). Set `Ac Name` = MANOJ KARIGAR, `Ac Group` = **10 KARIGAR SUNDRY CR** (auto), optional `Opning Balance` Amount/Gold/Silver Dr-Cr → **Save** → returns with `Party 000209 MANOJ KARIGAR`.
4. `Enter Enter` → **item** DataCare Help popup (`ItemName · ItCode · Group`, kf_027) → pick `999 GOLD (999 · FINE GOLD)`.
5. Enter `NetWt` = **100** (`GrWt` mirrors to 100.000), `Touch` = **100** → `Fine` auto = **100.000**. Narration: *"100 ग्राम मेटल फाइन गोल्ड हमने उनको दिया … टच डाल सकते हैं आप 100 … 100 ग्राम फाइन उसका हो जाएगा"*.
6. `Enter` → **Save**; then **View** to print the receipt (kf_033).
7. Verify **Stock** (kf_035) and **Ledger** (kf_038) as below.

## 4. Effects — tables + stock/ledger impact
**Fine formula (issue side):** `Fine = NetWt × Touch / 100 = 100 × 100/100 = 100.000` (web `fineWeight`; desktop uses `ITM_FINE`).

- **`MAIN_STOCK`** — one metal-OUT row: `999 GOLD`, `TR_TYPE 'O'`, `ITM_SIGN '−'`, `ITM_QTY/ITM_NWT 100.000`, `ITM_TOUCH 100`, `ITM_FINE 100.000`, `BOOK_NAME 'KARIGAR'`. Verified: Stock Report after (kf_035) shows `999 GOLD OuWt 100.000 → ClWt 200.000` (300 − 100). Narration: *"300 ग्राम … में से 100 ग्राम आउट हो गया तो 200 ग्राम … स्टॉक बच गया"*.
- **Fine/metal ledger** — karigar posted **`Dr Gold 100.000`**. Verified in Ledr Report (kf_038): `MANOJ KARIGAR · DrGold 100.000` (DrAmt/CrAmt blank). Narration: *"100 ग्राम जो गोल्ड है वो … उनके पास से लेना रहेगा — ये डेबिट आ जाएगा उनके अकाउंट में"* ("this gold is receivable from him — it becomes a debit in his account"). Desktop persists this in **`FINE_DATA`** (`…ITM_FINE, DR_AMT, CR_AMT, TR_TYPE, ITM_SIGN…`, per `RP_LEDR.cs`); web maps it to an **`AC_DATA`** metal leg `IT_TYPE 'G' / SIGN '−' / FINE_WT 100`.
- **Header tables** — desktop writes `MFG_ISU_REC` (+`MFG_DETL`) with `INOUT_TYPE`, `IT_TYPE`, `ITM_SIGN` (per `Ac_Tax.cs`). Web writes simplified `KR_DATA` (header) + `KR_DETL` (`INOUT_TYPE = 'O'`).
- **Money:** none — receipt (kf_033) prints `Total Amount 0.00`, `Closing Gold : 100.000 Dr`, other balances blank.

## 5. Cross-module connections
- **Party / Account Master** (group 10 KARIGAR SUNDRY CR) — the karigar account; created inline via F1 (kf_023).
- **Item / Product Master** — the issued metal item `999 / 999 GOLD (FINE GOLD)` (kf_027); its opening came from **Item Opening / Stock opening** (narration points to a separate opening-balance video).
- **Stock Report** (`RP_STOCK`) — pre/post verification (kf_015/035).
- **Ledger Report** (`RP_LEDR`) + **Karigar/MFG Ledger** report — shows `Dr Gold` (kf_038).
- **Feeds → Karigar Receipt** (Video 2): the `Dr Gold` opened here is what the receipt clears.

## 6. Web parity mapping
- **Route/page:** `web/apps/web/app/(app)/txn/karigar-issue/page.tsx` → `components/KarigarForm.tsx` `mode="issue"` → **`POST /karigar/issue`** (`routes/txn.ts` L278) → `issueKarigar()` (`modules/manufacturing/karigar.ts`). Returns `{ vchNo, fineIssued }`. Posts `KR_DATA` + `KR_DETL(INOUT 'O')` + `MAIN_STOCK(TR_TYPE 'O'/'−')` + `AC_DATA(IT_TYPE 'G'/SIGN '−'/FINE_WT)`. Fine math verified in `test/karigar.test.ts` (`fineWeight(100,92)=92`).
- **Parity: GAP (data faithful, UI thin).** The posting/fine math matches; the **form** does not:
  - Grid is **3 cols** (`Item · Net Wt · Touch %`) vs desktop **16** — missing `TagNo · Counter · Pcs · GrWt · OthWt · West% · Fine(shown) · ConIt/Con%/ConWt · TotWt`.
  - `karigarAc` is a **raw text box**, not a group-10 LookupPicker with **F1 create-party**.
  - **No live `: Dr Gold`** balance (only a manual "Check balance" button hitting `GET /karigar/:ac/balance`).
  - **No header** (Vch No/Date/weekday/time, Ref No, Bank, Vch Desc, Employe, image) and **no totals/payment panel** (can't pay a labour advance on issue).
  - **No Print (Original/Dup/Trip) / Delete / `< >` nav**; no Design-Issue book variant.
- **Note:** a richer API pipeline exists — `POST /mfg/issue` → `issueMfg()` (`modules/manufacturing/mfg.ts`, writes `MFG_DETL` with `KR_CODE/IR_TYPE`, closer to desktop `MFG_ISU_REC`) — but the `karigar-issue` **page** is wired to the simplified `karigar.ts`, not `mfg.ts`.

---

# VIDEO 2 — KARIGAR ORNAMENT RECEIVED

- **ID:** `CO9Ro-ZeeE8` · playlist `karigar` · title *"Karigar Ornament Received"*
- **Transcript:** `project-memory/video-research/karigar/CO9Ro-ZeeE8/transcript.sarvam.txt`
- **Keyframes:** `…/CO9Ro-ZeeE8/keyframes/kf_*.jpg` (read: kf_007, 012, 016, 020, 024, 028, 032, 035, 037, 039)

## 1. Screen title + menu path
**Title:** `Karigar Receipt` (form tab `Kr Received 1`).
**Menu path:** `Karigar → Kr Received`.
Narration: *"कारीगर से हम ऑर्नामेंट किस तरह से रिसीव ले सकते हैं … कारीगर में रिसीवड"* ("how we receive ornaments from the karigar … Kr Received"). Depends on Video 1: *"मनोज जी को 100 ग्राम फाइन गोल्ड इशू किया था"* (recap kf_007 shows the earlier issue: 999 GOLD 100.000, live `100.000 : Dr Gold`).

## 2. Header fields + grid columns (THREE grids)
**Header (kf_012):** `Vch No` [00001] + **`F1`** · `Vch Date` [28/07/2021] + time [12:30:48] + weekday · `Ref No` · `Party` [000209 | MANOJ KARIGAR] · **`Item Wt`** (two boxes, running item weight). Top-right live: **`100.000 : Dr Gold`** (red) · `: Amt` · `: Silvr`.

**Grid A — ornament received (main line, kf_012/024):**
`Sr · ItCode · ItName · Pcs · GrWt · OthWt · NetWt · GhtWt · Touch · West% · Fine · Ltype · LRate · LAmt · TotAmt · TaxPrc · NetAmt`.
Filled (kf_024): `1 · ORG · GOLD ORNAMETNS · Pcs 5 · GrWt 65.000 · OthWt 0.000 · NetWt 65.000 · GhtWt 0.000 · Touch 92.00 · West% 0.00 · Fine 59.800 · Ltype N · LRate 100.00 · LAmt 6500.00 · TotAmt 6500.00 · TaxPrc — · NetAmt 6500`.
(`GhtWt` = ghat/loss weight; `Ltype` = labour type N/per-gm/per-pc/%/fixed; `LRate·LAmt` = making rate/amount; `TaxPrc` = per-line GST%.)

**Grid B — barcoding / tagging sub-grid (kf_012/024):**
`Sr · ItCode · TagNo · Counter · Design · Size · HmId · Pcs · GrWt · LsWt · NetWt · Lbr% · LbrRate · LbrAmt · OthAmt · PrCost · Mrp · Image · KrCod`.
The received pieces are **tagged into barcode stock here** (auto TagNo, design, size, HUID `HmId`, MRP, making). Narration: *"बारकोडिंग क्रिएट करने का ऑप्शन आ जाएगा … यहां पे बारकोड भी बना सकते हैं"* — or defer via *"अदर में ओनली टैग एंट्री"* (Other → Only Tag Entry).

**Grid C — stone / diamond sub-grid (kf_016/020/024):**
`Sr · ItCode · ItName · Pcs · KrWt · Weight · Con% · P/W · Rate · ItAmt · NetAmt`.
For describing stone/diamond content of the "less weight" — narration: *"इसमें स्टोन है, डायमंड है, वो कितना है? … वो डिस्क्राइब करना है तो यहां पे नीचे डाल सकते हैं"* ("if it has stone/diamond, describe it in the box below"). If nothing, `Enter Enter` skips it, or the loss goes directly into `OthWt` on Grid A: *"डायरेक्टली ऊपर भी डाल सकते हैं यहां पे अदर वेट में"*.

**Totals panel (kf_024/028):** `Net Amt · Disc Amt · Tax Amt · Tcs Amt · Rof Amt · Total Amt · Cheque Amt · Card Amt · Cash Amt · Kasar Amt · Os Amt`. Live: **`6500.00 : Cr Amt`** (labour payable) + **`100.000 : Dr Gold`**. Left: image box + camera/photo/scissors icons; `Employe · Bank · Vch Desc`. Buttons `Print · Save · Cancel · Delete · Exit`; nav `< >`.

## 3. Step-by-step operator workflow
1. **Kr Received** → `Enter Enter Enter` → `Party` → select **MANOJ KARIGAR** (000209). On select, the **opening `100.000 : Dr Gold`** appears top-right (kf_012). Narration: *"उनका बैलेंस आ जाएगा राइट हैंड साइड पे … 100 ग्राम डीआर गोल्ड मतलब हमें उनके पास से इतना गोल्ड फाइन लेना है"*.
2. `Enter` → pick item **GOLD ORNAMENTS (ORG)** — *"रिटर्न गोल्ड ऑर्नामेंट्स"*.
3. `Pcs` = **5** (*"पांच पीस बनवाए"*), `Enter`.
4. `GrWt`/`NetWt` = **65** (*"65 ग्राम … वेट डाल दिया"*, kf_016), `Enter`.
5. On Enter a **less-weight box** opens (Grid C / stone) — enter stone/diamond weight to describe, or `Enter Enter` to skip (loss can instead go to `OthWt` on Grid A).
6. `Touch` = **92** → `Fine` auto = **59.800** (kf_024). Narration: *"टच वेस्टेज जो भी है आपका 92 … इसका मेटल का फाइन हो जाएगा 59800"* (i.e. 59.800).
7. `Enter Enter Enter` → **making charges**: `Ltype`/`LRate` (e.g. 100/gm) → `LAmt 6500` (*"मेकिंग चार्जेस … 200 300 पर ग्राम"*, mechanic = rate × weight).
8. `Enter Enter` to 2nd row → **Escape** → **barcoding** option (Grid B) to tag the received pieces (or skip → Other → Only Tag Entry).
9. **Escape** → cursor to right totals → enter **GST manually** in `Tax Amt`/`Tcs Amt` (*"मैनुअली जीएसटी 3% या … 5% … सिलेक्ट कर सकते हैं"*, e.g. 5% on making = 325).
10. Pay karigar now via `Cheque/Card/Cash` **or** leave in his account → `Os` (*"पेमेंट … चेक से … नहीं तो उनके अकाउंट में क्रेडिट हो जाएगा"*).
11. **Save** → **Original / Duplicate / Triplicate** print dialog (kf_032, `☑ Original` + `View/Print/Exit`) → **Exit**.
12. Verify **Ledger** (kf_035), **Stock In** (kf_037/039).

## 4. Effects — tables + stock/ledger impact
**Fine formula (receipt side, wastage folded in):** `Fine = NetWt × (Touch + West%) / 100`. Desktop `MS_UPDATE.cs` (L2691): `num = ITM_NWT × (ITM_TOUCH + ITM_WEST_PRC) / 100.0`. Here `65 × (92+0)/100 = 59.800`.

- **`MAIN_STOCK`** — one metal-IN row: `GOLD ORNAMENTS`, `TR_TYPE 'I'`, `ITM_SIGN '+'`, `ITM_PCS 5`, `ITM_NWT/GWT 65.000`, `ITM_TOUCH 92`, `ITM_FINE 59.800`, `BOOK_NAME 'KARIGAR'`. Desktop also stamps the **karigar-cost columns** `KR_NWT · KR_TOUCH · KR_WEST · KR_FINE · KR_LBR_AMT · KR_OTH_AMT · KR_COST` (per `Ac_Stock.cs`) so the piece carries its making cost into stock. Verified: KREC drill-down (kf_037) `KREC · MANOJ KARIGAR · GOLD ORNAMETNS · Pcs 5 · GrWt 65.000 · NetWt 65.000 · Fine 59.800 · Sign +`; group Stock Report (kf_039) `GOLD ORNAMENTS InPcs 5 / InWt 65.000`. Narration: *"जो आइटम … परचेस की वो हमारे स्टॉक में इन हो जाएगी … गोल्ड ऑर्नामेंट के हिसाब से प्लस हो गया"*.
- **Fine/metal ledger** — karigar **`Cr Gold 59.800`** (reduces the `Dr Gold`). Balance = `100.000 − 59.800 = 40.200 Dr Gold`. Verified Ledr Report (kf_035): `MANOJ KARIGAR · DrGold 40.200`. Desktop `FINE_DATA`; web `AC_DATA` metal leg `IT_TYPE 'G' / SIGN '+' / FINE_WT 59.800`.
- **Money ledger (`AC_DATA` / `ROJ_MEL_DATA`)** — **labour payable**: `Dr LABOUR / Cr MANOJ KARIGAR`. Verified (kf_035): `MANOJ KARIGAR · CrAmt 6,825.00` = `LAmt 6500 + 5% GST 325`. Since no cash/cheque paid, it sits as `Os`/`Cr Amt` (kf_024 live `6500.00 : Cr Amt`). Narration: *"मेटल बैलेंस भी आ जाएगा, गोल्ड अमाउंट बैलेंस भी आ जाएगा"*.
- **Header tables** — desktop `MFG_ISU_REC`(+`MFG_DETL`) `INOUT_TYPE` receipt; web `KR_DATA` + `KR_DETL(INOUT 'I')`.
- **Barcode/tag** — if Grid B used, pieces post to `BAR_DETL` / `TAG_PRINT_DATA` (barcode stock +); a later categorize/tag then moves `GOLD ORNAMENTS` bulk → barcode. Narration: *"कैटेगराइज करके बारकोडिंग करेंगे तो गोल्ड ऑर्नामेंट स्टॉक में से कम हो जाएगा और बारकोड प्लस हो जाएगा"*.

## 5. Cross-module connections
- **← Karigar Issue** (Video 1) — supplies the `Dr Gold` this receipt clears (issued − received).
- **Party Master** (group 10) — the karigar; live Dr/Cr Gold + Amount balances.
- **Item Master** — received item `ORG / GOLD ORNAMENTS`; **Labour Type Master** (`MS_LBR_TYPE`) drives `Ltype/LRate`; **Tax Master** (`MS_TAX`) the GST (`TaxPrc/Tax Amt/Tcs`).
- **Barcoding / Only Tag Entry** (Other → Only Tag Entry, `UT_TAG_PRINT`) — tags received pieces (Grid B), feeds **Tag Stock**/QR-916 label.
- **Cash/Bank** — if labour paid now (`Cheque/Card/Cash` → `RojMel`/`AC_DATA`).
- **Reports** — Stock Report (kf_037/039), Ledr Report (kf_035), Karigar/MFG Ledger, `karigar-statement`.

## 6. Web parity mapping
- **Route/page:** `web/apps/web/app/(app)/txn/karigar-receive/page.tsx` → `KarigarForm mode="receive"` → **`POST /karigar/receive`** (`routes/txn.ts` L283) → `receiveKarigar()`. Returns `{ vchNo, fineReceived }`. Posts `KR_DATA` + `KR_DETL(INOUT 'I')` + `MAIN_STOCK(TR_TYPE 'I'/'+')` + `AC_DATA` legs: labour `Dr LABOUR / Cr karigar` (if `labourAmt>0`) **and** metal `IT_TYPE 'G'/SIGN '+'/FINE_WT`. Fine math verified `test/karigar.test.ts` (`fineWithWastage(100,90,2)=92`; `balance(92,90)=2`). Balance via `GET /karigar/:ac/balance` (`karigarMetalBalance`).
- **Parity: GAP (biggest mfg gap).** Posting math faithful, but the receive UI is a **4-col toy** (`Item · Net Wt · Touch % · Wastage %` + one header `Labour Amount`) vs the desktop's three rich grids:
  - **Grid A missing** `Pcs · GrWt · OthWt · GhtWt · per-line Ltype/LRate/LAmt · TaxPrc/NetAmt` — web has no gross, no pieces, no ghat, no per-line labour, no labour-type model.
  - **No stone/diamond sub-grid (Grid C)** and **no barcoding/tagging sub-grid (Grid B)** — web **cannot tag received pieces into barcode stock** (pairs with the barcoding gap in Module B).
  - **No totals panel** (`Net/Tax/Tcs/Rof/Total/Cheque/Card/Cash/Kasar/Os`), **no `Cr Amt` labour-payable settlement**, **no GST/TCS**.
  - **No Original/Duplicate/Triplicate print**, no live `Dr Gold`/`Cr Amt`, no `Item Wt`/Employe/Bank/Vch Desc header.
  - **To-verify:** confirm posting both clears karigar `Dr Gold` by fine received **and** books labour `Cr Amt` (the API returns only `fineReceived`; the labour Dr/Cr + `MAIN_STOCK` in-legs exist in `receiveKarigar` but are not surfaced in the UI result).
- **Note:** the fuller `POST /mfg/receive` → `receiveMfg()` (`mfg.ts`, mirrors desktop `MFG_ISU_REC` incl. `KR_CODE`) and `POST /karigar/design-issue` (book `DIS`) exist in the API but are **not** wired to this page.

---

## Evidence index (frames read)
- **Karigar Issue** `Gd0TSp2OoXA`: kf_006 (home menu + `ToDays Rate`), kf_015 (Stock Report, 999 GOLD Op 300), kf_019 (Issue form + party Help popup + 16-col grid), kf_023 (Party Master, Ac Group 10 KARIGAR SUNDRY CR, 000209), kf_027 (item Help popup, 999 FINE GOLD), kf_031 (filled line 100.000 + red `100.000 : Dr Gold`), kf_033 (receipt ORIGINAL, `Closing Gold 100.000 Dr`), kf_035 (Stock after: OuWt 100 → ClWt 200), kf_038 (Ledr `MANOJ KARIGAR DrGold 100.000`), kf_040 (end card).
- **Karigar Receipt** `CO9Ro-ZeeE8`: kf_007 (issue recap `100.000 : Dr Gold`), kf_012 (empty Receipt, 3 grids + `Item Wt` + `Tcs`), kf_016 (Pcs 5 / GrWt 65), kf_020 (touch cell active), kf_024 (Touch 92 → Fine 59.800, LAmt 6500, `6500.00 : Cr Amt` + `100.000 : Dr Gold`), kf_028 (totals/GST entry, Total 6500), kf_032 (Original/Duplicate/Triplicate print dialog), kf_035 (Ledr `CrAmt 6,825.00` + `DrGold 40.200`), kf_037 (KREC stock-in, Fine 59.800, Sign +), kf_039 (Stock: GOLD ORNAMENTS InWt 65.000).

## Desktop↔web cross-refs
- Desktop forms: `TR_MFG_KR_ISU_REC.cs` (Kr Issue/Received UI + grid load `ITM_TOUCH`/`ITM_WEST_PRC` cols 24/25), `TR_KR_ISU.cs`; posting `Ac_Tax.cs` (`INSERT INTO MFG_ISU_REC(… INOUT_TYPE, IT_TYPE, ITM_SIGN, ITM_TOUCH, ITM_WEST, ITM_FINE, KDM_WT, ADD_WT, LESS_WT, RTN_CHOL, RTN_KDM, RTN_GHIS, ITM_GHAT, MINO_WT, ITM_LOSS, LBR_…)`), `Ac_Stock.cs` (`INSERT INTO MAIN_STOCK(… TR_TYPE, ITM_SIGN, ITM_FINE, KR_NWT, KR_TOUCH, KR_WEST, KR_FINE, KR_LBR_AMT, KR_OTH_AMT, KR_COST …)`), `MS_UPDATE.cs` L2691 (fine = NWT×(TOUCH+WEST)/100), `RP_LEDR.cs` (`FINE_DATA` Dr/Cr metal sub-ledger).
- Web: `modules/manufacturing/karigar.ts` (`fineWeight`, `fineWithWastage`, `karigarBalance`, `INOUT_ISSUE='O'`, `INOUT_RECEIPT='I'`, `issueKarigar`, `receiveKarigar`, `deleteKarigar`), `routes/txn.ts` L277-303 (`/karigar/issue|receive`, `/karigar/:ac/balance`, `/mfg/*`, `/karigar/design-issue`), `components/KarigarForm.tsx`, `test/karigar.test.ts`, `modules/reports/reports.ts` `karigarBalances`, `modules/reports/reports4.ts` `karigarStatement`, `modules/parity/golden.ts` (fine parity harness).
