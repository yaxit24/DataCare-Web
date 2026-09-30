# Implementation progress: evaluation defects D1–D6, 29 September 2026

This round fixes the running-app defects recorded in [PARITY-EVALUATION-2026-09-28.md](../PARITY-EVALUATION-2026-09-28.md) (§5a–§5c). The evaluation was merged to `main` after X15 ([document 44](44-implementation-progress-x15-2026-09-29.md)). These defects did not appear in the plan. Each of them broke a daily workflow or silently mispriced a sale.

The contract, desktop citations and hand vectors were written before the code: [evidence/implementation-2026-09-29-eval-defects/contract.md](evidence/implementation-2026-09-29-eval-defects/contract.md).

## What changed

| Defect | Desktop authority | Web change |
|---|---|---|
| **D1** Cash/Bank Received, Cash/Bank Payment, Card Rec and Contra could not be saved (HTTP 400) | Each menu fixes a book by MAIN_BOOK before the form opens (MDI_FORM.cs:8052-8111, `CurBookHelp`). Kasar posts to BOOK_DETL slot 2 (Ac_Ledr.cs:571-581). | The forms select a configured book filtered by MAIN_BOOK family and mode, and send it with the voucher date. `?mode=BANK` opens bank mode. The server refuses a book outside the family or the mode's layout, and resolves kasar from slot 2. Provisioned cash books get a kasar slot. |
| **D6** A blank SL_AMT_TYPE priced sales on fine weight (54,960 instead of 60,000) | Blank is N (MS_OPNCOMP.cs:881-884; Ac_Image.cs:6221). The line RtWith and item RATE_TYPE drive `CommPassTotal` (TR_SALE.cs:10716-10936). | A shared core `saleAmountBasis` is used by the writer and the browser preview. It honours per-line RtWith, P = pieces and RATE_TYPE 1/K/P. SL_DETL.RATE_WITH stores the effective value. Provisioning writes N/F. |
| **D2** GSTR-2 and GSTR-3B screens were empty | — | The slug sanitiser keeps digits. |
| **D3** Five report screens returned 404 (HUID, Item Stock Level, Bill Wise Profit, Physical Stock Verify, Stock Movement) | — | Literal screen routes call the export's own builder. Bill Wise Profit honours the date range. |
| **D4** Balance Sheet and GSTR-1 filters and exports returned 403 `form: unresolved` | — | Both slugs are mapped and exportable. `/reports/gstr1` is added. |
| **D5** Order Cancel opened on a 400 | TR_SL_ORD_ADJ (MDI_FORM.cs:8628-8639) | The page selects the order book and sends the scope. Void reads the saved version first. |
| **§5c** HTTP 500 on bad input | — | An unknown labour type or a missing tax rate is now a 400 validation error. |

The findings made while implementing are listed in the contract. Six were fixed in this change, including the descriptor-keyed settings lookup that disabled three UI-honoured settings and the Sales page listing non-sales books. Six remain open, each with an owning card.

## Verification

All results below were on disposable PostgreSQL (localhost:55433, `app_user`, forced RLS):

| Check | Result |
|---|---|
| `pnpm --filter @datacare/api test` | 279 files / 3,209 tests passed |
| `pnpm --filter @datacare/core test` | 28 files / 1,660 tests passed |
| `pnpm --filter @datacare/web test` | 39 files / 551 tests + 6 node checks passed |
| `pnpm --filter @datacare/web test:routes` | 125/125 routes (API mocked; not persistence evidence) |
| `pnpm typecheck:tests`, `pnpm lint`, `pnpm build`, Prettier | passed |
| Real-stack browser (`parity.real-stack.mjs`) | **21/21 journeys** passed, zero mocked requests. Includes the new `cash-receipt-payment` and `sale-amount-basis` journeys, which the release certificate now requires. |
| Deliberate failures | 15 mutations, one per changed path, 15 caught ([mutation-checks.json](evidence/implementation-2026-09-29-eval-defects/mutation-checks.json)) |

Route universe: 574 → 580. Report slugs: 83 → 85.

## Status

- **No card is closed.** This is engineering evidence on synthetic fixtures. The vectors have not been replayed on the Windows desktop, and the web adaptations have not been accepted by the business:
  - the book-family refusal;
  - the slot-1 = slot-2 kasar refusal;
  - re-saving a blank RATE_WITH as the company value.
- **Register:** the affected COMPLETION-REGISTER entries remain `implemented-unverified`. Their notes now cite this evidence.
- **Next queue item:** evaluation §4b, wholesale sale and rate cut. Today it writes no stock movement and no money leg for rate-cut fine (card X16).
