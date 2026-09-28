# Video-Parity Synthesis — desktop UX → web implementation backlog
_From the DataCare Softech India tutorial corpus (30 videos / 1069 keyframes / transcripts). Per-module detail in `_modules/{A_sales, B_purchase_finance, C_masters_setup, D_karigar_other}.md`. This file is the cross-module synthesis + prioritized backlog. The web's DATA + POSTING layer is faithful (verified separately, all ledgers balance); the gaps below are almost entirely **UI/UX richness + a few whole screens** the desktop has that the web doesn't surface yet._

## Corpus
- `INDEX.md` — every video → web page. `process_video.sh` — reusable pipeline (subs + low-res → scene keyframes → delete video).
- `<playlist>/<id>/` = `transcript.txt` + `keyframes/kf_*.jpg` (1280w). Playlists: transaction(12), master(6), karigar(2), other(10).

## Reconciliation — gaps the agents flagged that are ALREADY (partly) built
- **Masters UPDATE path**: an agent flagged "no update". In fact `PUT /masters/:name` + `updateMaster` + the Edit form were built + verified (R8, 6/6). ✅ The *real* masters gap is **field richness** (below), not the update path.
- **Per-form RBAC**: the `USER_SET` per-form layer (resolveAllowedForms + `/me allowedForms` + nav filter) was built + verified (6/6). ✅ Remaining = the **{Edit/Delete/Print}-per-form granularity + an admin matrix UI** (web currently does per-form VIEW + 3 global action flags).

## Cross-cutting UX gaps (recur on most transaction screens) — P1
1. **Live gold/silver rate ticker** (footer: Fine Gold/Fine Silver/Rate Date) — drives every metal rate; absent on all web forms.
2. **Live party balance on select** (Dr/Cr amount + Gold + Silver) — desktop shows it the moment a party is picked.
3. **Charges sub-grid** (HM Hall-Mark + RD Rhodium → OthAmt) on sale/purchase item rows.
4. **Old-gold / old-silver exchange grid** (multi-row metal-in) on sale, sales-order advance, labour-invoice.
5. **Full totals panel**: Net/Disc/Tax/**TCS**/**ROF**/Total/Cheque/Card/Order/OldGold/OldSilver/**Scheme**/Cash/**Kasar**/**OS** — web shows a subset.
6. **Dual GST** (metal Sale-Tax % + Labour-Tax %) on sale + labour invoice; web uses a single tax%.
7. **Multi-line tender grid + Kasar** on Cash/Bank receipt+payment; web is one-party/one-amount.
8. **Print template selector** + Crystal-style outputs (Original/Duplicate/Triplicate; Gold Tax Invoice w/ HSN/Other-Charg/Taxable-Value).
9. **Barcoding/QR-916 label print** + auto TagNo (CHG00001) + 12-digit Tag-Id; **Tag Stock Report** (In/Out/Stock/Mrp/All + Excel).
10. Header chrome: Employe, Vch Desc/It Desc narration, weekday+time, Print/Delete/nav, item photo, F-key/scanner keyboard flow.

## Desktop screens with NO web equivalent — build-from-scratch backlog
| Screen | Module | Note |
|---|---|---|
| **Company provisioning seed** | setup | ⛔ **BLOCKER** — desktop "Create Company" seeds chart-of-accounts/groups/books/taxes/settings; a new web company seeds nothing ⇒ non-functional (no system accounts for `buildSaleLedger`). |
| Bank Reconciliation | finance/other | ClrDate per txn + cleared-vs-book "Bal Chk". |
| Order Cancel | sales | cancel SO + refund/adjust advance (ledger reversal). |
| Stock Adjust Entry (voucher) | inventory | ±sign manual stock-correction voucher (web physical-stock is read-only reconcile). |
| Tag Transfer in Item Stock | inventory | barcode tag → bulk/old-gold un-tag (web item-lot is the opposite). |
| Daily Rate entry | masters | Gold-10gm/Silver-1Kg → per-group rate derivation (web rates = raw CRUD). |
| Labour Update (bulk) | masters | group-wise Old→New Labour/%/MRP/West editor. |
| Reminder dashboard/voucher | utilities | multi-category (Order/Sales/Dhiran/Scheme/Birthday/Item-In-Out); web is send-only. |
| Auto Item bulk generator | masters | MS_AUTO_ITEM. |
| Approval Return / close-loop | sales | web tour is issue-only — no return/convert-to-sale via Apr No. |
| Karigar Repair / Design-Issue books | mfg | only Issue+Receive built. |

## Per-module deep gaps (top items; full detail in `_modules/*.md`)
- **Sales**: Apr-No link, SO advance-adjust grid, charges sub-grid, old-gold grid, Design/Size/LsWt cols, per-line Lbr%/LbrRate, TCS/ROF/Scheme/Kasar/OS in UI, print selector.
- **Sales Return**: original-invoice import ([S] picker auto-pulls sold lines) + refund-vs-credit settlement.
- **Labour Invoice**: order linkage + old-gold-received (advance gold) + dual GST + metal reconciliation (Dr/Cr fine, Diff).
- **Purchase**: pay-now split (Chq/Card/Cash/Kasar/Os), OthWt/West%/Ltype/LRate, stone+karigar sub-grids, barcoding stock-IN (tag generation, not just lookup).
- **Other Expenses**: HSN-driven per-line tax + **RCM (reverse-charge)** + payment split (web is flat supplier+single-tax).
- **Bill-Wise Received**: dual grid (tender + open-bill allocation) and it must **post a real receipt** (cash/bank legs) — web only edits BILL_OS.
- **Contra**: n-leg (one main vs many counters) + **Fine JV** metal transfer (web is 2-account money-only).
- **Masters**: expose full field sets — Account (Group/GSTIN/PAN/address/Cr-days/Int%/bank/**opening Dr-Cr + Gold/Silver**), Item/Group (Touch/Wastage/Making/**Sale-A-c+Purchase-A-c posting links**/HSN), auto item-code.
- **Karigar**: full tag/labour/stone/barcoding grids + settle the labour "Cr Amt" payable + tag pieces into stock on receive.

## Prioritized roadmap
- **P0 (blocker):** Company provisioning seed (system accounts/groups/books/taxes/settings) — without it a new web company can't post.
- **P1 (high-value UX, broad):** live-rate ticker + party-balance; charges sub-grid + old-gold grid + full totals panel + dual GST on sale/labour/purchase; multi-line tender+Kasar on receipts; bill-wise real receipt posting; barcoding tag-gen + QR label print; masters full field sets + opening balances.
- **P2 (missing screens):** Bank Reconciliation, Order Cancel, Stock Adjust voucher, Tag Transfer, Approval return/close-loop, Daily Rate entry, Labour Update bulk, Reminder dashboard, per-form Edit/Delete/Print matrix UI, print-template selector.

> Method note: each gap is evidence-cited to `kf_NNN` frames + narration in the per-module files, so implementation can open the exact desktop screenshot while building the web form.
