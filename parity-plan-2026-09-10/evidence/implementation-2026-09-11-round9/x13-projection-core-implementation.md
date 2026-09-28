# Round9 — saved incoming Return projection

This bounded change supplies trusted saved-row projection for the prospective read-only replay service. It does not admit new source rows, execute a numeric save, change financial or stock rows, or establish executable desktop/business acceptance. The existing Round7 reducer and money source are unchanged.

The current verified stage passed **11 core test files / 264 tests / zero skips**, including **53 new projection tests**, plus the core build and strict compilation of the projection test file. Thirty-two inputs were captured before these commands and rehashed unchanged afterward. `x13-projection-core-run.json` pins inputs, source references, commands and every credited log. Wider API/UI/DB/browser integration is owned by the root checkpoint, not credited by this core note.

## Source and implemented contract

Primary source is `extracted_code/DataCareNext/DataCareNext/TR_SALE_RTN.cs`, saved load at 10353–10438. Its `SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE` joins item masters by company/item, while the saved table already owns the last two column names. Until duplicate-name DataAdapter binding is established, the projection requires exactly one master and exact, non-NULL agreement between saved/master `RATE_TYPE` and `IT_TYPE`. It never chooses the current master's type over the saved type. The original `DC_Main.cs:1232–1239` DataAdapter path and schema evidence remain prerequisites for broadening this restriction.

`projectSavedSaleReturnIncoming({rowIdentity, ordinal, raw, itemMasters})` returns either a frozen ready state or a frozen unsupported result with field diagnostics. Inputs are server observations. Raw fields are exact strings or NULL; the returned state retains a detached, frozen complete raw record, including unknown fields and six-digit fractional clock text. Scope, row eligibility, physical revision observations and authorization belong to the API. The ordinal is only the displayed row number, not the saved identity.

All mapped source fields must be present. Any unproved numeric NULL, malformed decimal or decimal outside the initial profile refuses the whole projection; the separate saved raw reader remains usable. This is an initial web rollout boundary, not a claim that the desktop rejects those records. Numeric inputs use a local Decimal context and the existing exact string formatter: at most 36 significant digits, at most 18 fractional places, absolute value below 10^36. No business decimal passes through JavaScript Number, and global Decimal settings remain unchanged.

Case/trim aliases discovered among company/item candidates also refuse projection, even when an exact candidate exists. The API must query these relevant aliases and include their raw/physical observations in the composite replay token. Checking only exact SQL equality and omitting aliases would defeat this containment. This conservative alias check is not a proof of the entire SQL Server collation equivalence relation.

## Saved projection map

The table states source-column indexes, not editable field admission. All 71 cells start cleared. Raw values stay separate from the formatted display.

| Source cells | Saved fields / projection |
| --- | --- |
| 0 | Display ordinal, source 10359; persisted `SR_NO` remains raw |
| 1–8 | `IT_CODE`, `TAG_NO`, description, `TBL_CODE`, `DESIGN_NO`, `ITM_STYLE`, `ITM_SIZE`, `HM_ID` |
| 3 | Nonempty `ITM_REMARK`; otherwise master `IT_NAME`; raw NULL/blank retained independently (10362–10368) |
| 9 | Validated `ITM_PCS` text unchanged; source `Conversions.ToString`, not integer format (10376) |
| 10–12 | `ITM_GWT`, `ITM_OTH_WT`, `ITM_NWT`, three decimal places |
| 13–18 | `LBR_CODE`; `ITM_GHT_PRC` two places; `ITM_GHT_WT` three; `ITM_TOUCH` and `ITM_WEST_PRC` two; `ITM_FINE` three |
| 19–28 | `ITM_RATE`, `ITM_AMT`, `LBR_PRC`, text `LBR_TYPE`, `LBR_RATE`, `LBR_AMT`, `DISC_PRC`, `DISC_AMT`, `OTH_AMT`, `ITM_MRP`; numeric fields two places |
| 29 | `TAG_LBR_CODE`, falling back to `LBR_CODE` only for the projected blank display (10400–10403) |
| 30–38 | `TAG_LBR_PRC`, `TAG_LBR_RATE`, `TAG_LBR_AMT`, `TAG_OTH_AMT`, `TAG_COST`, `TAG_MRP`, `TOT_AMT`, `TAX_PRC`, `NET_AMT`; two places |
| 39–44 | Text `KR_NAME`, text `VCH_SRNO`, cleared 41/42, text `IT_TYPE`, text `RATE_TYPE` |
| 45/46/47/48/49 | Comparison caches seeded from already formatted cells 10/12/16/17/19 |
| 50/51 | Text `APR_ISU`; `OLD_SRNO` formatted with zero places; exact identity remains raw |
| 52/53 | Both copy the same persisted `PR_CODE` |
| 54/55 | Both copy the same persisted `TAG_TYPE` |
| 56/57 | `TAG_SRNO` formatted with zero places; literal saved-row marker `E` |
| 58 | Comparison cache seeded from formatted labour rate cell 23 |
| 59–61 | Text `HM_ID2`, `HM_ID3`, `HM_ID4` |
| 62–65 | `HM_ID_WT`, `HM_ID2_WT`, `HM_ID3_WT`, `HM_ID4_WT`; three places |
| 66/67 | Comparison caches seeded from formatted cells 21/37 |
| 68–70 | Text `EMP_ISU`, `DESIGN_IMG_ID`, `DATA_TYPE` |

Exactly eight comparison caches are initialized. Source cells 41/42 are neither populated by this saved loop nor consumed by the primary row calculator; no labour-amount cache is invented there. The saved loop ends with `MSG_PR_TOT_FILL` at 10447, not per-row `CommPassTotal_Pr`, so hydration emits no event and does not reprice even visibly inconsistent manual totals.

`projectSaleReturnIncomingEditorText(state)` returns a separate frozen field-ID map for the twelve preview editors: source columns 19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37 and 38. EnterCell at 4538–4541 / 4561–4575 formats these editor strings to two places. For example, a manual-total result may display labour percentage at three places (5115); reopening its editor produces two-place text without changing the current display, raw data, caches or journal. Blank visible amounts produce `0.00` editor text without committing a zero. This helper does not truncate large values to the source ten-character typing limit; event validation and capability gating are separate API/UI responsibilities.

## Verification and observed correction

The portable JSON fixture is authored directly from primary saved-load assignments. Its expected all-71-cell map and exact eight-cache map are fixed strings, SHA-pinned by the test, rather than generated by the projection implementation. This is source-derived expectation evidence; it is not an independently executed desktop fixture.

The 53 cases cover full mapping, raw NULL/blank/unknown-field and microsecond preservation, ordinal versus noncontiguous persisted/hidden identity, fractional pieces, formatting before cache initialization, nonempty whitespace fallback behavior, huge exact decimals with global Decimal precision set to seven, whole-row NULL/malformed/precision containment, missing/duplicate/type-conflicting masters, discovered case/trim aliases, malformed trusted inputs, and two-place editor re-entry without state changes.

The first focused run passed 49 tests before alias containment. The subsequent 264-test stage and build passed, but strict test compilation exposed inferred optional-undefined properties in the four alias fixture objects. The fix was a fixture generic type annotation only. The original logs and before/after snapshot remain under `*-first` and `*-final`; the current corrected stage uses `*-verified`. No assertion was removed, no test was skipped, and no ceiling changed. There is no core lint credit: no applicable core lint run is claimed.

## Remaining boundaries

Mathematical Decimal formatting is not measured VB Double/Format/culture or DBNull equivalence. The unresolved duplicate-column/type binding, full database collation, unsupported numeric NULLs and malformed/extreme values remain explicit constraints. F1/source admission, LCode/TgLCode transitions, gross editor entry, hidden/new-row/tag/component events, bill aggregation, stock/ledger effects, numeric persistence and production/business acceptance remain open. The API must construct projection inputs and trusted width policy in one consistent snapshot and must never accept client raw cells, caches or policy as authority.
