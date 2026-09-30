# Implementation progress: X16 wholesale sale and rate cut, 29 September 2026

This round implements queue item X16 (doc 12; master-plan slice N17 / W06–W08): the desktop form `TR_WH_SALE`, which serves both "Wh Sales" (F6, WH SALES books) and "Rate Cut" (Ctrl+F6, RATE CUT books). [PARITY-EVALUATION-2026-09-28.md](../PARITY-EVALUATION-2026-09-28.md) §4b found that the web wholesale sale moved no stock, a sold tag could be sold again, a rate cut never turned the cut fine into rupees, and every ledger key was a code no desktop routine writes. It follows [document 45](45-implementation-progress-eval-defects-2026-09-29.md).

The contract, desktop citations and hand vectors were written before the code and extended as the grid was derived: [evidence/implementation-2026-09-29-x16/contract.md](evidence/implementation-2026-09-29-x16/contract.md) (C1–C15, V1–V6, W1–W14).

## What changed

| Area | Desktop authority | Web change |
|---|---|---|
| Book scope and rights | `CurBookHelp("WH SALES")` / `("RATE CUT")`, each behind its own right (MDI_FORM.cs:14188-14210, 16107-16121) | `/wholesale-sales` (new right `Sales/Wholesale Sale`) accepts only WH SALES books; `/rate-cut` only RATE CUT books. Ctrl+F6 now opens the Rate Cut page. Provisioning adds books WHS and RTC with the twelve desktop slots. |
| Stock and tags | `Wh_Sale_Stk` (Ac_Stock.cs:146-176) | Issued lines post `MAIN_STOCK` SR_NO 1 'S' '-' with the tag identity; received lines SR_NO 2 'P' '+'. Tags are reserved per instance inside the transaction, refused when sold or duplicated, and released on edit and delete. The wholesale return decides "sold" by the tag's latest movement. |
| Ledger | `Wh_Sales_Ledr` legs 01-52 (Ac_Ledr.cs:613-778) | Every leg keyed by its desktop code; gold/silver twins; TRAD_FINE mirrors; kasar by sign; party only on party legs; a missing slot is refused. |
| Settlement | `BILL_TOTAL` (TR_WH_SALE.cs:15369-15667) | The header rate reaches the engine (it never did, so DR_AMT stayed 0). `FINE_RATE` is the header rate only. The band (net, Os, tot fine, Pay/Rec) is one core function, `wholesaleBand`: net rounds half-to-even as `Math.Round` does, and tender keeps its paise (`Strings.Format "0.00"`; 1000.50 used to post 1001). |
| Grid arithmetic | `CommPassTotal` / `CommPassTotal_Pr` (:9160-9860, :6857-7040) | New `@datacare/core` `wholesaleLine.ts`: fine with less weight, hallmark fine and less touch; rate from conversion; labour by basis (`LBR_WITH_GHT`, `LBR_TYPE`); other charges into fine; receive-grid tax back-out; typed receive ghat weight; `SL_FINE` counts only unpriced lines. A new row's labour is computed on the company basis. |
| Tag and party defaults | :10641-10736, :14621-14623 | A tag brings weights, stored fine, labour, other charges, rate, MRP and cost; the party brings name and mobile. `/lookup/available-tags` offers only issuable tags, per instance, with ambiguous instances labelled by serial. |
| Screens | TR_WH_SALE layout (`MSG`, `MSG_PR`, `MSG2_TOTAL`) | One shared form on both pages (contract C11): desktop column order and cascades, the two-column rate-cut band beside the settlement band, the desktop's Payment (PR_*) / Received (SL_*) labels — the old Rate Cut page had them inverted — and reopen, update, delete, new. Every computed cell is the posting arithmetic run on the payload the form sends. The wholesale page used to post to `/rate-cut` (now refused for its book) with its own preview. |

Findings made while implementing and fixed here: the stored-fine rule, the priced-line double count in `SL_FINE`, the FINE_RATE line fallback, the gross-wise labour on net-wise companies, the lost receive ghat weight on edit, whole-rupee tender, half-up band net, and the inverted band labels. The rest are listed as open items in the contract.

## Verification

All results below were on disposable PostgreSQL (localhost:55433, `app_user`, forced RLS):

| Check | Result |
|---|---|
| `pnpm --filter @datacare/api test` | 280 files / 3,221 tests passed |
| `pnpm --filter @datacare/core test` | 30 files / 1,699 tests passed |
| `pnpm --filter @datacare/web test` | 38 files / 562 tests + 6 node checks passed |
| `pnpm --filter @datacare/web test:routes` | 125/125 routes (API mocked; not persistence evidence) |
| `pnpm typecheck:tests`, `pnpm lint`, `pnpm build`, Prettier | passed |
| Real-stack browser (`parity.real-stack.mjs`) | **22/22 journeys** passed, zero mocked requests ([real-stack-result.json](evidence/implementation-2026-09-29-x16/real-stack-result.json)). The new `wholesale-rate-cut` journey, now required by the release certificate, drives both pages: picked and typed tags, a received line, a derived cut, the band, save, edit (the dropped tag returns to stock), reopen, delete (audit, both tags released) and a header-only rate cut; every stored row is read back independently. |
| Deliberate failures | 53 mutations across the writer, core arithmetic, band, picker, guards and provisioning, 53 caught ([mutation-checks.json](evidence/implementation-2026-09-29-x16/mutation-checks.json)) |
| `node scripts/check-completion-register.mjs` | REGISTER_OK, 198 entries |
| `validate_current_review.py` | Status unchanged from before this round: it fails on the round-14 checkpoint's source identities (every later source change is listed, 155 → 199 with D1–D6 and X16) and on seven historical links. No new error kind; the 1,542 local links, including this document's, resolve. |

Route universe: 580 → 584.

## Status

- **No card is closed.** This is engineering evidence on synthetic fixtures and captured desktop rows. The vectors have not been replayed on the Windows desktop, and these web adaptations have not been accepted by the business:
  - the `RATE CUT` fallback for a book with no `BOOK_DATA` row;
  - the S3 fallback for a cheque or card without an account;
  - one bank and one card account per voucher.
- **Register:** Wh Sales, Rate Cut and Wh Quotation remain `implemented-unverified`; their notes now cite this evidence.
- **Open in X16:** Rojmel alignment (types 05/06/14/27, the `WSALE - ` name prefix), tag stones into `SL_IDTL`/`DM_DATA`, legs 07/14/27/28/33/34/53-68, `MAIN_STOCK` SR_NO 4-7, approval and order flag resets (X17), negative-stock refusal, `TEMP_BOOK_DATA`, the unmodelled grid and band columns, and TR_BUL_SALE's own grid (contract, Open items).
