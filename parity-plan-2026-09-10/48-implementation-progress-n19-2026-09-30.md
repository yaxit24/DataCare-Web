# Implementation progress: N19 tag split, 30 September 2026

This round implements master-plan slice N19 (card X20 Tag Split; `docs/master-parity-plan-2026-09-29/02-execution-plan.md`). The desktop menu "Tag Split" opens `TR_TAG_SPLIT` on a book whose `MAIN_BOOK` is `TAG SPLIT` (MDI_FORM.cs:8686). One or more parent tags are consumed and one or more child tags are created, conserving the metal. Before this round the web had a placeholder `splitTag` writer under WP-01 containment (503), with no tag identity, no child creation, no ledger, no lifecycle and no screen. It follows [document 47](47-implementation-progress-n18-2026-09-29.md) and is stacked on the N18 tip.

The contract, desktop citations and vectors were written before the code: [evidence/implementation-2026-09-30-n19/contract.md](evidence/implementation-2026-09-30-n19/contract.md) (K1–K15, V1–V10, adaptations A1–A10). No desktop `TR_TAG_SPLIT` rows were ever captured, so the expected rows are derived from the source, not replayed.

## What changed

| Area | Desktop authority | Web change |
|---|---|---|
| Book and mode | `CurBookHelp("TAG SPLIT")` | New writer `modules/stock/tagSplit.ts`, accepting only an in-use `TAG SPLIT` book. Its absorbing-ledger slots (5 labour, 6/7 gold DR/CR, 8/9 silver DR/CR) are read through the shared posting-account kernel (`resolveBookSlotRowsTx`), not an inline `BOOK_DETL` read. Provisioning adds `TSP` (`TGSPL`). The legacy contained `splitTag` and its route are removed. |
| Parent identity and locks | Tag entry, `CommPassTotal_Pr` | Each parent resolves one live instance through the shared `issueTagTx` resolver — the same one a sale uses — keyed on company, location and the resolved serial, judged on a net balance. A number with two live instances is refused; a duplicate parent is refused; a tag at another location is refused. All parents are locked in sorted order before any is resolved, so opposite-order writers wait instead of deadlocking; a deadlock returns 409, not 500. |
| Child creation | `NewTagNo`, `CommPassTotal_Pr` (6338–6704) | Each child is a freshly allocated, sellable tag: `nextTagNoTx` reserves its serial race-safely (the tag advisory lock plus `SRNO_MAST FOR UPDATE`) with the child item's `PR_CODE` prefix, and it is written as a real `BAR_DETL` row with a `MAIN_STOCK` `+` leg, exactly as a purchased tag. Its arithmetic is the new `@datacare/core` `tagSplitLine.ts` (net from gross less the less-weights, ghat folded into the purity fine, item amount by `RATE_TYPE`, labour by `LBR_TYPE`, tag cost and MRP). |
| Register and stones | `BtnSave_Click` (9960–10770) | `LBR_DATA` (ENTRY_TYPE `C`), `LBR_ISU_DETL` (parents, `O`), `LBR_ISU_IDTL` (parent stones), `LBR_REC_DETL` (children, `O`), `BAR_DATA`/`BAR_DETL` (children, `I`) and `BAR_IDTL` (child stones) are written with the exact desktop column set, plus the `TEMP_BOOK_DATA` hidden number. The parent's own stones come from its `BAR_IDTL`. The source parent tag, its stones and its image are never modified. |
| Stock, ledger, day book, diamonds | `Tag_Split_Stk`, `Tag_Split_Ledr`, `Tag_Split_Rojmel`, `Dm_Tag_Split_Detl` | `MAIN_STOCK` sends the parent out (`-`, O) and each child in (`+`, I), conserving the fine. When an absorbing account takes a weight difference, `AC_DATA` posts the gold/silver DR/CR fine legs (even mirror legs gated on `TRAD_FINE`), `ROJ_MEL_DATA` posts the day-book pair, and the diamond register moves `OTH_DETL_POSTING` stones OUT (parent) and IN (child). |
| Conservation | "Please Insert diff Wt in Received Grid…" | The children must add up to the parent net weight within tolerance, unless an absorbing account is set to take the residual. The screen shows a live Parent net / Children net / Short-or-Surplus banner and refuses a short save before anything is sent. |
| Image lineage | `Mobile_image_Save` | The parent's `TAG` `ENTITY_IMAGE` is copied to each child instance; the parent's own image row is untouched. |
| Lifecycle | `DISPLAY_DATA`, `BtnDelete_Click` | Read, list, the next number and a non-consuming parent preview. An edit keeps its hidden number, clock and original author, releases the old children, gives the parent back and re-consumes it. Delete writes a `DELETE_DATA` row per parent line, reverses the whole write set in one transaction and gives the parent back, and refuses once a child has moved on (sold or split again). |
| Screen | `TR_TAG_SPLIT` grids, stone grid, picture box | New `TagSplitForm` with a read-only parent grid, an editable child grid whose cells run the same core arithmetic the API writes with, an editable stone sub-grid, the conservation banner, the parent-tag image panel, and `<` `>`, an F1 voucher list, reopen, update, delete and cancel. |

Findings made while implementing and fixed here:

- `createTagTx` was writing an `IT_CODE` column that `TAG_STOCK` does not have, aborting every save. The redundant reservation was removed: `nextTagNoTx` already reserves the child serial race-safely, and a split child lives as a `BAR_DETL` tag by its stock balance, not a `TAG_STOCK` row.
- `childBarDetlRow` wrote `ITM_SIGN`, `stoneRow` wrote `HD_VCH_NO` into `BAR_IDTL`, and `diamondRows` wrote `TBL_CODE` into `DM_DATA` — three columns the target tables do not have. Each was removed after auditing every builder's emitted columns against the schema.
- `getTagSplit` ordered `LBR_DATA` by a non-existent `row_id`; the composite primary key already makes the header unique.
- The moved-on guard used a signed balance, so a child that was created (`+1`) and later sold (`−1`) netted to zero and looked untouched. It now counts consuming legs outside the split's own voucher.
- The diamond register never posted a parent stone: the item lookup for the `OTH_DETL_POSTING` flag covered only the children's typed stones, not the parents' loaded stones. It now covers both. This was caught by the real-browser journey and is now also asserted in the database lifecycle test.

## Verification

All results below were on disposable PostgreSQL (localhost:55433, `app_user`, forced RLS):

| Check | Result |
|---|---|
| `pnpm --filter @datacare/api test` | 288 files / 3,304 tests passed (the one non-passing file, `parity-real-stack-evidence.test.mjs`, is a `node:test` file vitest cannot parse; it is unchanged since the baseline and predates N18). |
| `pnpm --filter @datacare/core test` | 32 files / 1,736 tests passed |
| `pnpm --filter @datacare/web test` | 40 files / 594 tests passed (same pre-existing `node:test` file) |
| `pnpm --filter @datacare/web test:routes` | 125/125 routes rendered (API mocked; not persistence evidence) |
| `pnpm typecheck`, `typecheck:tests`, `lint`, `prettier --check .` | passed |
| N19 database tests | Lifecycle, 11 tests: it compares every column of every written row and diffs the whole tenant before and after, covering V1–V9, the write-set rollback, the save race, the not-in-use book guard and a delete refused under a period lock. Also: routes on the provisioned `TSP` book (7, one a real deadlock returned as 409, plus the edit round-trip and the wrong/not-in-use book refusals), identity (6, including location isolation, a sold-and-returned parent, an ambiguous number and the freshly minted child identity), and the row model (11). |
| Real-stack browser (`parity.real-stack.mjs`) | The new `tag-split` journey passed on the real Next production build against the real Fastify API and PostgreSQL, zero mocked requests ([real-stack-result.json](evidence/implementation-2026-09-30-n19/real-stack-result.json)). It is now required by the release certificate (24 journeys). It drives the screen alone — parent pick with its photograph, the child grid and its live conservation banner, the short-split refusal, save, reopen, list, delete — and reads every stored row back (`LBR_*`, `BAR_*`, `MAIN_STOCK`, `DM_DATA`, `TEMP_BOOK_DATA`), with the source parent, its stone and its photograph fingerprinted unchanged. |
| Deliberate failures | 27 mutations across the writer, row model, shared resolver, 409 mapping, provisioning, rights, core arithmetic and the screen model. All 27 were caught ([mutation-checks.json](evidence/implementation-2026-09-30-n19/mutation-checks.json)). The first run caught 15; each survivor exposed a missing test, now added. |
| Gates | `settings:parity` 128/128, `report-baselines` 254 unchanged, `parity:measure --reuse` ratchet OK, `check-completion-register` REGISTER_OK (198). Contained operations 6 → 3; blocked routes 9 → 3. Operator surface 2,677 → 3,621 fields; reachable API fields 2,042 → 2,376; enforced validation messages 598 → 898; runnable report workflows 46 → 79. |
| Gates failing before this round | `depth:parity` still breaches one ceiling: API fields no screen supplies, 98 > 96 — unchanged by N19, which only adds a screen and raises reachability. `depth:deadcells` still reports 32 dead `sale-return` columns, unchanged and owned by a different card; Tag Split has none. |
| `validate_current_review.py` | Status unchanged: no new problem kind (0 problems, as before this round); historical source and artifact drift is listed but informational. |

Route universe: 592 → 596.

## Status

- **No card is closed.** X20 is released from containment; merging is the release decision. It stays open until the vectors are replayed on the Windows desktop, which has no captured `TR_TAG_SPLIT` rows yet, and until the business accepts the adaptations:
  - child tag numbers allocated server-side (`nextTagNoTx`) rather than the desktop's minute-resolution `VCH_SRNO` string;
  - the serial required for an ambiguous parent number;
  - the refusal of an empty parent or child line;
  - the conservation guard and the absorbing account taking any residual;
  - a `DELETE_DATA` row written on delete (the desktop writes none) and the refusal to edit or delete a voucher whose child has moved on (the desktop lacks this check);
  - the parent's photograph copied to each child.
- **Register:** Tag Split moves from `contained` to `implemented-unverified`; its evidence now cites this round.
- **Open in N19** (see the contract's Open items): the print report; `COL_MAST` column overrides; the description and design help lists; splitting a `TAG_STOCK`-only parent (only `BAR_DETL` parents are supported); and per-voucher user rights, licence and company-type checks.
