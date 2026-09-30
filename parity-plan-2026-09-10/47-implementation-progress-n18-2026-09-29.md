# Implementation progress: N18 tag cancel and tag transfer, 29 September 2026

This round implements master-plan slice N18 (cards X19 Tag Cancel and X18 Tag Transfer; `docs/master-parity-plan-2026-09-29/02-execution-plan.md` on the `docs/master-parity-plan-2026-09-29` branch). Both desktop menus open one form, `TR_TAG_CAN`, on a book of their own `MAIN_BOOK`: "Tag Cancel" on `TAG CANCEL` books, "Tag Transfer" on `TAG TRFR` books (MDI_FORM.cs:8585-8595, 8663-8673). Before this round the web had two unrelated writers, both contained (503), with wrong book stamps, no tag identity or locking, no stones, no diamond register, no lifecycle and a provisioned Tag Transfer book no desktop routine recognises. It follows [document 46](46-implementation-progress-x16-2026-09-29.md).

The contract, desktop citations and vectors were written before the code: [evidence/implementation-2026-09-29-n18/contract.md](evidence/implementation-2026-09-29-n18/contract.md) (K1–K16, V1–V12, T1–T4, adaptations A1–A13). No desktop `BAR_CAN_*` rows were ever captured, so the expected rows are derived from the source, not replayed.

## What changed

| Area | Desktop authority | Web change |
|---|---|---|
| One form, two menus | `CurBookHelp("TAG CANCEL")` / `("TAG TRFR")` | One writer, `modules/stock/tagCancel.ts`, with the mode taken from the route. Each menu keeps its own right and accepts only its own in-use book. The legacy `tagOps.tagCancel` and `stock.tagTransfer` are deleted. Provisioning adds `TGC` (TGCAN) and `TTR` (TAGTR). A guarded data migration moves web-provisioned `TAG TRANSFER` books to `TAG TRFR`. |
| Tag identity and locks | Tag entry, :3859-4090 | Every line resolves one live instance through the shared resolver. A number with two live instances and no serial is refused. "Duplicate Tag No" is refused. All tags are locked in sorted order before any is resolved, so opposite-order writers wait instead of deadlocking. A deadlock or serialisation failure returns 409, not 500. |
| Row arithmetic | `CommPassTotal`, `CommPassTotal_Idtl`, `MSG_TOT_FILL` | New `@datacare/core` `tagCancelLine.ts`, carrying the hidden recompute baseline. The screen runs it on each cell it leaves. The server replays an API caller's cells in column order and then stores the given cells. Read-only and other-mode cells are refused. The Transfer grid's hidden labour and other amount are still computed, as on the desktop. |
| Register and stones | `BtnSave_Click`, :4942-5330 | `BAR_CAN_DATA`, `BAR_CAN_DETL` and `BAR_CAN_IDTL` are written with exactly the desktop column set. The tag's own stones come from the first `BAR_DETL` row of the instance. The `TEMP_BOOK_DATA` hidden number is written. The tag's `KR_NET_WT` two-place quirk is kept. The source tag, its stones and its image are never modified. |
| Stock and diamonds | `Tag_Can_Stk`, `Dm_Tag_Cancel_Detl` (Ac_Stock.cs:48-58, 824-828) | Every line writes `MAIN_STOCK` insert 1 (`-`, O). Transfer also writes insert 2: `+`, I, `TAG_NO` 'N', `TBL_CODE` 001, the same measures and no money, so the metal moves to the loose item unchanged. Cancel posts `OTH_DETL_POSTING` stones to `DM_DATA`. |
| Lifecycle | `DISPLAY_DATA`, `BtnDelete_Click`, `BtnF1_Click` | Read, list, the next number and a tag preview. An edit keeps its number, clock, user and each kept line's `OLD_SRNO`, gives back dropped tags and re-reserves kept ones. Delete writes the desktop `DELETE_DATA` row per line, removes the whole write set in one transaction and gives every tag back, including a lossy restore of a web `TAG_STOCK` tag. |
| Screens | `TR_TAG_CAN` grids, stone grid, picture box | One `TagCancelForm` serves both pages. It shows the desktop columns per mode, with ItCode, Counter, Pcs and KrCode read-only on a tag row, and a totals row. Tags can be picked or typed. The stone grid is editable. The panel shows the tag's own photograph. A new row copies the previous transfer item (`CommPassAdd`). Ctrl+D removes a row. The form also offers `<` `>`, an F1 voucher list, reopen, update, delete and cancel. |

Findings made while implementing and fixed here:

- The Transfer grid refused its own recomputed hidden labour after a weight edit.
- A tag pick raced the typed-number resolution, which reported "ambiguous" after a correct pick.
- A stale transfer-item lookup could blank a picked item's name.
- The main grid's cell labels collided with the stone grid's.
- The `Tag Cancel` register entry named `UT_TAG_PRINT`; the menu opens `TR_TAG_CAN`.
- The data migration would have silently updated nothing under a migration role that row-level security filters. It now refuses to run under such a role.

## Verification

All results below were on disposable PostgreSQL (localhost:55433, `app_user`, forced RLS):

| Check | Result |
|---|---|
| `pnpm --filter @datacare/api test` | 284 files / 3,270 tests passed |
| `pnpm --filter @datacare/core test` | 31 files / 1,723 tests passed |
| `pnpm --filter @datacare/web test` | 39 files / 583 tests + 6 node checks passed |
| `pnpm --filter @datacare/web test:routes`, `test:browser` | 125/125 routes (API mocked; not persistence evidence); mocked smoke passed |
| `pnpm typecheck:tests`, `pnpm lint`, `pnpm build`, `prettier --check .` | passed |
| N18 database tests | Lifecycle, 22 tests. It compares every column of every written row and diffs the whole tenant before and after, including V1–V12, T1–T4, the sale race, sorted locks and edit numbering. Also: identity (10), HTTP on provisioned books (5, one a real deadlock returned as 409), row model (17), migration (2). |
| Real-stack browser (`parity.real-stack.mjs`) | **23/23 journeys** passed, zero mocked requests ([real-stack-result.json](evidence/implementation-2026-09-29-n18/real-stack-result.json)). The new `tag-cancel-transfer` journey is now required by the release certificate. It drives both pages through the screen alone and reads every stored row back: picked and typed tags, the three entry refusals, the serial pick, a loose line, save, Ctrl+D/stone/touch edit, reopen, list, delete, and a transfer with a gross edit and the carried transfer item. The source tags, stones and photograph are fingerprinted unchanged. |
| Deliberate failures | 60 mutations across the writer, row model, shared resolver, 409 mapping, provisioning, rights, core arithmetic and the screen model. All 60 were caught ([mutation-checks.json](evidence/implementation-2026-09-29-n18/mutation-checks.json)). The first run caught 54; each of the six survivors exposed a missing test, now added. |
| Gates | `settings:parity` 128/128, `report-baselines` 254 unchanged, `parity:measure --reuse` ratchet OK, `check-completion-register` REGISTER_OK (198). Contained operations 6 → 4; blocked routes 9 → 5; kernel rounding bypasses 128 → 126. |
| Gates failing before this round | `depth:parity` still breaches one ceiling: API fields no screen supplies, 98 > 96. It was 101 on the X16 tip, and N18 removed 3. `depth:deadcells` still reports 32 dead `sale-return` columns, unchanged. |
| `validate_current_review.py` | Status unchanged: it fails on the round-14 checkpoint's source identities, with every later source change listed (199 → 214 with N18), and on seven historical links. No new error kind; the 1,547 local links, including this document's, resolve. |

Route universe: 584 → 592.

## Status

- **No card is closed.** X18 and X19 are released from containment; merging is the release decision. Both stay open until the vectors are replayed on the Windows desktop, which has no captured `BAR_CAN_*` rows yet, and until the business accepts the adaptations:
  - the serial required for an ambiguous number;
  - the refusal of an empty tag line or voucher;
  - stones taken only from the first `BAR_DETL` row;
  - the transfer item being required;
  - the tag's photograph shown instead of the design image;
  - the lossy `TAG_STOCK` restore.
- **Plan wording:** J14 step 2 asks for a transfer "to another counter/location". The desktop's `TAG TRFR` mode moves a tag's metal to a loose item. A counter move is the separate Counter Transfer form. N18 implements the desktop behaviour.
- **Register:** Tag Cancel and Tag Transfer remain `implemented-unverified`; their evidence now cites this round.
- **Open in N18:**
  - print (`TagCanBill.rpt`) and the `COL_MAST` column overrides;
  - `EMP_AS_USER` and the description and design help lists;
  - the `STOCK ADJUST` and `TAG ADJ` modes of the same form;
  - lifecycle labels in reports and physical stock;
  - the per-voucher user rights, licence and company-type checks.

  See the contract's Open items.
