# VIDEO-PARITY VERIFICATION — implemented features ↔ desktop YouTube tutorials

_2026-07-01. Every implemented parity feature cross-checked against the official DataCare desktop tutorials
(YouTube **@DataCareSoftechIndia**, 33 videos harvested to `project-memory/video-research/`: keyframes +
Hindi transcripts + subtitles), the decompiled desktop (`extracted_code/DataCareNext/*.cs`), and re-verified
with live tests. Video URL form: `https://www.youtube.com/watch?v=<id>`._

## A. Feature → video reference → cross-check → test evidence

| # | Feature (web) | Video id · title | Transcript? | Cross-check finding | Test |
|---|---|---|---|---|---|
| 1 | **Stock Adjust** `/txn/stock-adjust` | `yP6XAirZ36I` · Stock Adjust Entry | frames only | kf_025: grid `TagNo·ItCode·Counter·Sign·Pcs·GrWt·LsWt·NetWt·Touch·West%·Fine·Mrp` — example OG/Counter 001/Sign +/NetWt 1/Fine 1. My signed-MAIN_STOCK (sign +/−, pcs/gross/net/touch→fine) ✅ matches core. Gap (minor): desktop also has LsWt/West%/Mrp/Counter/Design on the line — not exposed. | 21/21 #1 (±45.8/−19.8 ⇒ 26.0; delete reverses) |
| 2 | **Bank Reconciliation** `/txn/bank-recon` | `2244Ll1nFxI` · Bank Reconciliation | ✅ Hindi | Transcript CONFIRMS: Other menu → pick bank (HDFC) → per-cheque set **ClrDate** when it clears → **"Balance Check"** shows actual cleared balance vs book (cheques in transit). My ChqNo + Book/Cleared/Uncleared + per-row clear + From/To filter ✅ full parity. | 21/21 #2 (chq 12345; book 10000; clear ⇒ cleared 10000) |
| 3 | **Daily Rate** `/txn/daily-rate` | `5mIg4yRl0aE` · Daily Rate Master | frames only | kf_071: Gold-10gm + Silver-1Kg → per-group grid `Touch·Rate10gm·PrTouch·PrRate`. My `GR_RATE = fine×GR_TOUCH/100` + `GR_PR_RATE = fine×GR_PURC_TOUCH/100` ✅ matches (sale + purchase rate). | 21/21 #3 (66002 / 64850) |
| 4 | **Order Cancel** `/txn/order-cancel` | `0BXTuAzGk-c` · Order Cancel | frames only | kf_036 ledger: "Order Cancel · MANOHAR JI SONI · **Dr 25000**" — desktop posts a reversing ledger voucher refunding the advance. Mine fully voids (reverse order + advance AC_DATA) = same economics (cash out, liability cleared) + guards issued/tagged/delivered. **Difference:** desktop keeps order + posts a cancel voucher; mine deletes with DELETE_DATA audit. Partial-refund fields (AdjAmt/KsarAmt/PaidAmt) = documented simplification. | 21/21 #4 (reversed; issued blocked) |
| 5 | **Reminder dashboard** `/txn/reminders` + **Reminder Entry** `/utilities/reminder-entry` | `AN2AiLXuP28` · Reminder Entry | ✅ Hindi | Transcript CONFIRMS both surfaces: **manual Reminder Entry** (pick account e.g. HDFC, write note "deposit cheque", set date) → saved → surfaces on Home's reminder list; **auto** Order/Sales reminders; "View From Date" range. My `/reminder-entries` (REMARK_DATA) + auto dashboard (overdue receivables aged vs AC_CR_DAYS + orders-due) ✅ cover both. Birthday/Anniversary category omitted (schema has no birth/anniv columns — honest gap). | 21/21 #5 + #10 |
| 6 | **Tag Transfer** `/txn/tag-transfer` | `1EziXFnnH7I` · Tag Transfer in Item Stock | ✅ Hindi | Transcript CONFIRMS: barcoded tag (CHAIN #6) → **remove from barcode stock → add to bulk OLD GOLD** (broken/damaged piece); verified bulk OLD GOLD +grams. My OUT tag (`-`) + IN bulk (`+`), fine conserved ✅ exact parity. | 21/21 #6 (CH22 −11.358 / OG +11.358; delete reverses) |
| 7 | **Labour Update bulk** `/masters/labour-update` | `1DggmBgcA9I` · Labour Update | frames only | kf_032: group filter (916 GOLD) → per-item `OLbr·NLbr·OLbr%·NLbr%·OMrp·NMrp·OWest%·NWest%`. My group items Old→New `IT_LBR_RATE/LBR_PRC/ITEM_RATE/IT_WEST` partial update ✅ matches. | 21/21 #7 (A1 lbr 800/west 10; others kept) |
| 8 | **Approval Return** `/txn/tour-return` | `DpdQpC7Od2M` · Approval Issue Received | ✅ Hindi | Transcript CONFIRMS: issue items on approval → stock less → unsold go **Pending**; received-back closes them; pending-vs-received report. My `tourIssue` (ISU_REC 'N') + `tourReturn` (flip 'R' + MAIN_STOCK in) ✅ matches the close-loop. | 21/21 #8 (line1 R/line2 N; delete reopens) |
| 9 | **Counter Transfer** `/txn/counter-transfer` | — *no standalone tutorial* — | n/a | See §B. Real desktop menu item (kf_032 sidebar "Counter Trfr"); my from/to TBL_CODE relocate, fine conserved. | 21/21 #9 (001−/002+; net 0) |
| 10 | **Company Seed** `/admin/provision` | `VnXnYL5F6VE` · Company Create | ✅ Hindi | Company-create reference; my seed provisions the system accounts/taxes/books the posting needs (literal codes). | 21/21 #11 (sale posts on co 99) |
| 11 | **Opening Balance** `/masters/opening-balance` | `NyEAB-xn7Hw` · Account Create | ✅ Hindi | Opening balance is part of the desktop Account master; my OP_DATA (money+gold+silver w/ signs) folded into partyBalance. | 21/21 #12 (60000 Dr; gold 500; silver −2000) |
| 12 | **Sales TCS/Kasar/old-gold/Dual GST** `/txn/sales` | `DF_P2GD9AuU` · Sales Invoice Create | ✅ Hindi | Sales invoice (8:14) — old-gold exchange, charges, GST. My old-gold grid + hallmark + TCS + Kasar + CGST/SGST↔IGST split ✅. | 21/21 #13 + Tier-4 190/190 |
| 13 | **Bill-to-Bill** `/txn/bill-to-bill` | `sE2H-ztIINE` · Bill Wise Amount Received | ✅ Hindi | Bill-wise receipt with KASAR; my settleBills posts a real balanced receipt + BILL_OS allocation ✅. | suite + earlier 4/4 |

## B. Counter Transfer — reference basis (no standalone YouTube video)
Diligence: (1) web search "DataCare Softech Counter Transfer" → only company/listing pages, **no tutorial video**;
(2) the 33-video @DataCareSoftechIndia corpus has no Counter-Transfer entry; (3) decompiled `extracted_code` —
the 162 "Counter" hits are **TBL_CODE column references** in `Ac_Stock.cs` / `TR_PHYSTK.cs` / `MS_UPDATE.cs`,
not a dedicated form. **However the feature is real**: the desktop sidebar in `1DggmBgcA9I/kf_032` clearly shows
**"Counter Trfr"** as a menu item (Other → Extra, beside Labour Update / Bank Reconcile / Vch ReNumber), and the
Stock-Adjust form (`yP6XAirZ36I/kf_025`) shows a per-line **Counter** (001) column. So Counter Transfer relocates
stock between counters (the `TBL_CODE`/Counter dimension). My implementation (signed MAIN_STOCK: OUT `TBL_CODE`=from,
IN `TBL_CODE`=to, fine conserved, book `CTR`) is a faithful derivation from these authoritative sources. Verified
21/21 #9. (Note: the current web on-hand is counter-agnostic, so the transfer is net-zero on total stock — it relocates.)

## C. Test evidence (re-run 2026-07-01)
- **Consolidated module-level re-verification (isolated `e2e`/co-99 tenants): 21/21 pass** — every feature above.
- **Full unit/integration suite: 148/148** (33 files).
- **Tier-4 golden-master calc-parity (SQL Server `Next24`, 190 real desktop invoices): TAX 190/190 exact + TOTAL 190/190 exact** → `CALC_PARITY_EXACT`.
- **Tier-4 data-fidelity matrix (`xdb_diff`)**: 141/141 tables column-complete, 78/78 ETL exact, 372 Σ checks pass / 0 fail (`project-memory/parity/xdb-matrix.md`).
- `:4000` healthy; demo intact (SL_DATA=191, AC_DATA=5150).

## D. Documented gaps (faithful, non-blocking)
- Stock Adjust line lacks LsWt/West%/Mrp/Counter/Design (core sign/weight/fine present).
- Order Cancel uses void-model vs desktop reversing-voucher-model (same economics); no partial-refund (AdjAmt/KsarAmt/PaidAmt).
- Reminder dashboard omits Birthday/Anniversary (no AC_MAST birth columns) + Dhiran/Scheme categories.
- Counter Transfer: no standalone video (derived from menu + Stock-Adjust Counter column + Ac_Stock).
- e-Invoice GSP (R10): external credentials required.
