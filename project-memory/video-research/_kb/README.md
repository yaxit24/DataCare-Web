# DataCareNext Desktop — Video Knowledge Base (for exact web replica)

_Built 2026-07-01 from the official DataCare Softech India YouTube tutorials. Purpose: a precise,
image-grounded reference of every desktop screen (forms, fields, grid columns, workflow, DB/ledger
effects, cross-module links) so the web rebuild replicates the desktop exactly._

## How this KB was produced (method)
1. **Corpus:** 4 official playlists (`@DataCareSoftechIndia`) → **30 tutorial videos** across master / transaction / other / karigar.
2. **Audio → text (NEW):** each video's audio was downloaded (`yt-dlp`, Chrome-cookie auth to bypass bot-blocking), split into ≤30 s chunks, and transcribed with **Sarvam AI STT** (`saarika:v2.5`, `hi-IN`) → clean Hindi transcripts. This replaced the garbled YouTube auto-captions. **30/30 transcribed, ~282,000 chars.** (`<key>/<id>/transcript.sarvam.txt`)
3. **Visual:** scene-change **keyframes** (`<key>/<id>/keyframes/kf_*.jpg`, ~1,000 frames) were read as images to capture exact on-screen field labels, grid column headers, sub-grids, and effects.
4. **Synthesis:** transcript + keyframes fused into per-video KB entries (4 sub-agents, one per playlist), each: screen + menu path · header fields · grid/sub-grid columns · step workflow · DB tables + Dr/Cr + signed-stock effects · cross-module links · web route + parity verdict.

## Knowledge-base documents
| Doc | Playlist | Videos | Covers |
|---|---|---|---|
| [`_kb/KB_master.md`](KB_master.md) | master | 6 | Company create, User create + rights, Account/Party master (+opening balance), Item + Item-Group master, Barcoding/Tag opening, Backup |
| [`_kb/KB_transaction.md`](KB_transaction.md) | transaction | 12 | Sales Invoice (old-gold/HM/TCS/GST/tender), Cash & Bank Rec/Pay, Sales Return, Sales Order, Purchase + Return, Contra, Approval Issue/Receive, Labour Invoice, Other Expenses, Bill-to-Bill |
| [`_kb/KB_other.md`](KB_other.md) | other | 10 | Daily Rate, Tag Cancel/Print, Stock Adjust, Physical Stock, Order Cancel, Tag Transfer, Tag Weight Change, Labour Update, Bank Reconciliation, Reminder Entry |
| [`_kb/KB_karigar.md`](KB_karigar.md) | karigar | 2 | Karigar Metal Issue, Karigar Ornament Received (fine-weight + wastage/labour accounting) |

Each doc opens with a summary table (video → desktop screen → menu path → desktop `.cs` form → web route → web API module → parity verdict) and then a detailed section per video citing specific `kf_NNN` keyframes and quoting key Hindi phrases with English gloss.

## Video → web-page → implementation → test map
The desktop screens map to the web rebuild as follows (parity re-verified this session — see `SPEC-RECONCILIATION.md` §5/§6 and `VIDEO-PARITY-VERIFICATION.md`):

- **Masters:** accounts/customers/items/groups/taxes/rates/employees/books → `/masters/*` (+ Opening Balance, Labour Update, Provision Company). Barcoding → `/txn/tag-opening`.
- **Sales:** Invoice `/txn/sales` (old-gold grid + hallmark + TCS + Kasar + CGST/SGST↔IGST split), Sales Order `/txn/sales-order`, Order Cancel `/txn/order-cancel`, Return `/txn/sale-return`, Hallmark `/txn/hallmark-sale`.
- **Purchase/Finance:** `/txn/purchase`, `/txn/purchase-return`, `/txn/receipt`, `/txn/payment`, `/txn/contra`, Bill-to-Bill `/txn/bill-to-bill`, Bank Reconciliation `/txn/bank-recon`.
- **Inventory:** Stock Adjust `/txn/stock-adjust`, Tag Transfer `/txn/tag-transfer`, Counter Transfer `/txn/counter-transfer`, Physical Stock `/txn/physical-stock`.
- **Karigar/Mfg:** `/txn/karigar-issue`, `/txn/karigar-receive`, Labour Invoice `/txn/labour-sale`, Approval `/txn/tour` + Return `/txn/tour-return`.
- **Utilities:** Daily Rate `/txn/daily-rate`, Reminders `/txn/reminders` + Reminder Entry `/utilities/reminder-entry`, e-Invoice `/utilities/e-invoice`, Voucher Renumber, Backup.

**Test evidence (re-run 2026-07-01):** unit/integration suite **151/151**; consolidated 13-feature module re-verification **21/21**; Tier-4 golden-master calc-parity **190/190 real desktop invoices exact**; data-fidelity matrix **141/141 tables column-complete, 372 Σ pass/0 fail**.

## Parity backlog surfaced by the KB (UI-depth gaps to close for exact replica)
The data/posting layer is faithful; the main gaps are **UI richness** vs the desktop's dense grids:
- **Sales invoice UI:** confirm the charges sub-grid (HM/RD), old-gold exchange grid, and full tender panel (Cheque/Card/Order/Old-Gold/Scheme/Kasar/Os) render every desktop label; per-bill Lbr% override; item photo.
- **Barcoding/Tag opening:** auto-generated barcode numbers + QR/label print + rich tag fields (Counter/Design/Size/LType/KrCode) + Tag Stock Report (In/Out/Stock/Mrp/Apr-Pending/All tabs) + Auto-Item bulk generator.
- **Karigar receive (biggest mfg gap):** stone sub-grid + barcoding-of-received-pieces + per-line labour + labour-payable settlement; the richer `/mfg/*` API already exists server-side but isn't wired to the page.
- **Masters:** full company-detail form; per-form rights matrix UI.
- **Cross-cutting:** print templates (Orig/Dup/Trip), live party-balance + rate ticker on every txn screen (partially done).
- **e-Invoice:** code-complete; needs a commercial GSP account (env creds) to go live.

## Files
- `sarvam_transcribe.sh` — the reusable audio→Sarvam transcription pipeline (chunked, cookie-auth, retry/backoff).
- `INDEX.md` — video → web-page map + playlist listing.
- `<key>/<id>/transcript.sarvam.txt` — clean Sarvam Hindi transcript per video.
- `<key>/<id>/keyframes/kf_*.jpg` — scene-change screenshots per video.
- `_modules/*.md` — earlier per-module UX-parity notes (superseded/augmented by `_kb/*`).
