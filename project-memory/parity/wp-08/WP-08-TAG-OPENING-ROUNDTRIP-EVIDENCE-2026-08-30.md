# WP-08 / P0-06 tag opening round-trip evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package:** WP-08 — tag opening round-trip completion (closes the reopen/edit half of P0-06)
**Status:** implemented and validated in the current working tree; no commit created
**Claim boundary:** this closes the **field-loss half of P0-06** and its stated exit evidence. It does **not** address the image-identity half (`imageRow + 1` keying), the page-level numeric coercion, or purchase/karigar tagging, and it does **not** lift WP-01's containment of tag-opening update.

## 1. The defect, measured

Three facts composed into silent data loss:

1. `writeTagOpeningTx` accepts **65 fields per tag line** — the full desktop grid, every field cited to a `TR_TAG_OPBL.cs` line.
2. `getTagOpening` returned **22** of them.
3. `editTagOpening` deletes the entire write set and rebuilds it from its input, which is exactly what the desktop does (`TR_TAG_OPBL.cs:10852-10866`).

So reopening a tag and pressing save without touching anything wiped the difference. Not an error, not a warning, and nothing in the response to suggest the fields ever existed.

**Quantified by replaying the pre-fix reader against a real database:** of 109 `BAR_DETL` columns, an unchanged save changed **43**:

| Group | Columns wiped |
| --- | --- |
| Hallmark | `HM_ID2`, `HM_ID3`, `HM_ID4`, `HM_ID_WT`, `HM_ID2_WT`, `HM_ID3_WT`, `HM_ID4_WT` |
| Karigar cost | `KR_LBR_RATE`, `KR_LBR_AMT`, `KR_OTH_AMT`, `KR_OTH_RATE`, `KR_OTH_FINE`, `KR_TOT_FINE`, `KR_GWT_TOUCH`, `KR_COST`, `KR_NAME`, `KR_WAX_WT` |
| JDT weights | `JDT_JDT_WT`, `JDT_GHT_WT`, `JDT_KUN_WT`, `JDT_KUN_TOUCH`, `JDT_KUN_NET`, `JDT_WAX_WT` |
| Order lineage | `ORD_NO`, `ORD_SRNO`, `ORD_YRCD`, `ORD_DBCD`, `ORD_AC`, `ORD_LC_CODE`, `SF_NO` |
| Manufacturing lineage | `MFG_NO`, `MFG_YRCD`, `MFG_DBCD`, `MFG_SRNO` |
| Grid attributes | `ITM_STYLE`, `ITM_COLOR`, `ITM_MARGIN`, `LBR_CODE`, `SL_TYPE`, `EMP_ISU`, `DESIGN_IMG_ID`, `MAIN_MARGIN_PRC`, `MAIN_MRP` |

The operator-visible consequence is concrete: a hallmarked ornament loses its HUIDs, so no HUID register or label can be produced for it afterwards. The order and manufacturing columns are the **source lineage** that plan §7.1 invariant 10 requires to survive, so this defect was also breaking that invariant on the one tag path that is not contained.

## 2. The fix

`getTagOpening` now returns every field the writer accepts, in the writer's order so the two can be read side by side, with a comment stating that the lists must stay symmetrical and naming the test that fails if they drift.

Hallmark ids are read with `text()`, not `n()`. A HUID is alphanumeric, so reading one as a number destroys every id containing a letter — P0-06 records the page doing exactly that, and the server side must not repeat it.

`BAR_IDTL` needed no change: the sub-detail row is **derived** from the line's pieces and gross weight rather than supplied, so it reconstructs identically once the line round-trips. Worth stating explicitly, because the obvious reading of "edit deletes BAR_IDTL" suggests stone data is lost, and it is not — for this voucher family.

## 3. Exit evidence

P0-06 asks for: *"Create rich tag → reopen → save unchanged is equivalent under the canonical comparison contract and retains the exact image identity."*

`test/tagOpeningRoundTrip.db.test.ts` — 4 tests against a real database:

| Test | Asserts |
| --- | --- |
| reopen loses nothing | every one of the 65 input fields returns with its value intact |
| hallmark ids stay text | `hallmarkId2/3/4` are strings containing letters after the round trip |
| the entire persisted row survives | **zero** of the 109 `BAR_DETL` columns change across create → reopen → save unchanged |
| identity and stock survive | tag identity unchanged, and signed on-hand is exactly 1 — a re-save that deletes and re-inserts the movement must not admit the ornament twice (plan §7.1 invariants 1 and 3) |

The third test is shaped to resist rot: it does not assert a list of field names, which would pass while the list drifted. It reads the **full persisted row** before and after and demands equality on every column, so a field added to the writer and forgotten in the reader fails without anyone editing the test.

Test values are deliberately non-zero and non-empty, because a field defaulting to `0` or `''` would round-trip by accident and hide the loss.

**Discrimination proved, not assumed.** A probe outside the repository replayed the pre-fix 22-field reader against the same fixture and reported `columns CHANGED by an unchanged save through the OLD reader: 43`, listing exactly the 43 the fix restores. Without that, a passing test would be indistinguishable from a vacuous one.

Commands: full suite **155 files / 1308 tests passing**; `tsc` clean for api source, api tests and web; `prettier --check` clean.

## 4. Why the module was driven directly

WP-01 contains `PUT /stock/tag-opening/:vchNo` — the route returns 503 `PARITY_CONTAINMENT`. The test therefore calls `tagOpening`/`getTagOpening`/`editTagOpening` directly. That is not a way around the containment: producing this evidence is what the containment rule's own exit gate asks for, and the route stays blocked until the rest of P0-06 is closed and someone makes a reviewed policy change.

## 6. Purchase tagging — the same defect class, on a LIVE route

Applying the same method to purchase found a worse instance, because `PUT /purchases/:vchNo` is **not** contained by WP-01 and is therefore reachable in production today.

`PurchaseLineInput` accepts 45 fields per line; `getPurchase` returned 24. An unchanged save altered **12 persisted columns**, measured:

| Severity | Columns | Before → after |
| --- | --- | --- |
| **Money** | `LBR_AMT` | 2372.22 → **0** |
| **Money** | `TOT_AMT`, `NET_AMT` | 70191.42 → **67819.20** (down by exactly the lost labour) |
| **Identity** | `VCH_SRNO` | 1 → **2** |
| Descriptive | `DESIGN_NO`, `TBL_CODE`, `IT_DESC` | value → null |
| Descriptive | `BAG_WT`, `ITM_OTH_WT`, `ITM_MRP`, `ITM_OTH_RATE`, `COMM_PRC` | value → 0 |

### The money loss, and why it was not a missing inverse

The reader recovered the labour type with `legacyLabourModeFor`, which maps only `N`→per_gram and `P`→per_piece. The real cause is one level deeper: `desktopLabourTypeFor` collapses the web's `percentage` and `fixed` modes to the **company default** code, so `LBR_TYPE` cannot represent them at all. The mode is therefore genuinely unrecoverable, `line.labourType` came back `undefined`, and `computeLine` fell through to a labour charge of **0** — silently reducing the voucher total.

The fix does not invent a labour mode the desktop column cannot hold. It accepts an explicit `labourAmount` on the line, exactly as `metalAmount` already works for metal, and honours it over any computed charge. The amount *is* persisted in `LBR_AMT` and the reader already returned it; it simply had nowhere to go.

### The lesson that cost two iterations

Adding the eight descriptive fields to the reader's **mapping** changed nothing, because the **SELECT** never fetched those columns — `row.DESIGN_NO` was `undefined`, and `text(undefined)` is `''`. Both halves must change together. The same two-part shape caused the original tag-opening defect, which is why both fixes now carry a comment saying so.

### Fixed here

Money loss, all eight descriptive fields, **and the tag identity**. `PR_DETL` and `BAR_DETL` now round-trip byte-for-byte: the round-trip assertion is `changed === []` with no exclusions.

### The identity fix, and the trap inside it

`assertPurchaseTagsUnconsumedTx` already read **and locked** the persisted `TAG_NO`/`VCH_SRNO` pairs — everything the writer needs — and returned `void`. It now returns them, and `writePurchaseTx` keeps each tag's serial instead of allocating a fresh one, mirroring how tag opening threads `ctx.persistedTagSrnos`.

The naive form of that fix would have been worse than the defect. Reusing a persisted serial *by tag number* means two input lines naming the same tag both claim it, minting a **duplicate identity** — and `BAR_DETL` has no uniqueness constraint to catch it (WP-07 measured exactly that: only `row_id`). Purchase has no duplicate-tag guard, so this was reachable.

So the map is **consumed as it is read**: the first line claiming a tag takes the persisted serial, and any further line falls through to a fresh allocation exactly as before. No new rejection, no duplicate identities, and the reopen case fixed.

Verification is not just the round trip. The test now runs WP-07's data invariants over the same tenant afterwards — INV-2 scans for a serial handed out twice, INV-3 for an ornament admitted twice — and asserts zero violations with a non-zero `examined` count. The full suite (155 files, 1309 tests) confirms no other family's serial allocation regressed.

## 7. Karigar tagging — two defects behind one coverage gap, both fixed

Research found something worse than the missing serial I expected, and a reason it had survived: **no test
anywhere used `mode: 'receive'`**, so the entire karigar tag-creation path was uncovered. `karigarDayBook.db.test.ts`
never sets `tag`/`tagNo`; `mfgLifecycle.db.test.ts` covers karigar *issue*.

**Defect 1 — an edit destroyed the tag record.** `karigarWriteSet` includes `BAR_DETL` and `editKarigar`
deletes the whole write set, but only the CREATE path had a `barDetl` builder. The barcode row was never
written back, so after an edit the physical ornament existed with no tag record at all — and `issueTagTx`
resolves availability from `TAG_STOCK` or `BAR_DETL`, so it became **unsellable**. Plan §7.1 invariant 11 —
"delete/edit restores the complete prior state or fails before any mutation" — violated outright, on
`PUT /karigar/receive/:vchNo`, which WP-01 does not contain.

**Defect 2 — no serial identity.** The `BAR_DETL` builder never named `VCH_SRNO`, and the tag loop called
`nextTagNoTx` only for an untyped tag and kept just `t.tagNo`, discarding `t.srno`. A column that is never
named cannot be persisted, so every karigar tag carried the default. Plan §7 requires the identity to preserve
the serial, and `issueTagTx` resolves an exact instance on `(CO, LC, TAG_NO, VCH_SRNO)`.

### The fix

- `resolveKarigarTagIdentitiesTx` allocates a serial for **every** tagged line, including one whose tag number
  the operator typed — the rule purchase already follows deliberately. A typed tag number is kept; only the
  serial comes from the allocator.
- `karigarBarcodeRows` was extracted from the create path so the EDIT path can rebuild what the delete removes.
- `persistedKarigarTagSrnosTx` reads the persisted serials `FOR UPDATE` before the delete, and the resolver
  **consumes the map as it is read** — the same guard as the purchase fix, so two lines naming one tag fall
  through to separate allocations instead of sharing a serial.

### Exit evidence

`test/mfgLifecycle.db.test.ts` — a tagged receive, created with every descriptive field populated, then
reopened and saved unchanged:

| Asserted | Result |
| --- | --- |
| a tagged receipt creates a barcode record | 1 row |
| that record carries a serial identity | `VCH_SRNO > 0` |
| an edit does not destroy it | still 1 row |
| every persisted `BAR_DETL` column is unchanged | `changed === []` |
| WP-07 tag invariants over the same tenant | zero violations |

The invariant check matters specifically here: allocating a serial where none existed could have created a
duplicate identity, and `BAR_DETL` has no uniqueness constraint to catch it — INV-2 is the only thing that
would notice.

Full suite **155 files / 1310 tests passing**; `tsc` clean for api source, api tests and web; `prettier` clean.

### Located but out of scope: karigar tag stock movements

`stockRows` — shared by karigar issue and receive — writes neither `TAG_NO` nor `VCH_SRNO`, so a
karigar-received ornament's stock movement is **untagged** and invisible to every tag-level stock view.
WP-07's INV-3 filters on `TAG_NO <> ''` and cannot see it; §7.1 invariant 9 is satisfied only vacuously.

This corrects the baseline: §7's matrix states "`BAR_DETL` and `MAIN_STOCK` tag creation exists" for karigar
receipt. `BAR_DETL` tag creation exists; `MAIN_STOCK` tag creation does not.

Not fixed here because adding tag columns to `stockRows` changes what on-hand computes and what `issueTagTx`
treats as available, across three call sites and both directions. That is a change in stock *semantics*, and it
needs the desktop write set for karigar receipt read from `TR_KR_ISU.cs` first. Recorded as the next increment
in the plan's §17.6.

## 8. What remains in P0-06 and WP-08

- **Karigar tag stock movements** — located above, next increment.
- **Image identity.** Images are keyed on `imageRow + 1` rather than the persisted `VCH_SRNO`. Untouched here; it needs the image-lineage service that plan §7 assigns to the tag kernel, and it is the second half of P0-06's exit evidence ("retains the exact image identity").
- **Page-level coercion.** The server now preserves alphanumeric hallmark ids; the Next.js page still coerces them numerically. A server that cannot be corrupted by its own client is the important half, but the page must follow.
- **Read-before-write diff.** `assertTagOpeningUnconsumedTx` already blocks an edit after a generated tag is consumed (`TR_TAG_OPBL.cs:11373-11381`); the diff P0-06 also asks for is not implemented.
- **An unrelated robustness gap found in passing:** `labourCharge` switches on `LabourType` without a default, so an unrecognised value leaves its accumulator undefined and throws `TypeError: Cannot read properties of undefined (reading 'toNumber')` — a 500 where a validation error belongs.

## 9. Files

- `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts` — `getTagOpening` made symmetrical with the writer
- `web/apps/api/src/modules/purchase/purchase.ts` — explicit `labourAmount` honoured; eight descriptive columns selected and mapped; persisted tag serials returned by the consumption guard and reused by the writer
- `web/apps/api/src/modules/manufacturing/karigar.ts` — shared tag-identity resolver and barcode builder; edit rebuilds the barcode rows and keeps each serial
- `web/apps/api/test/tagOpeningRoundTrip.db.test.ts` (new)
- `web/apps/api/test/purchase.lifecycle.db.test.ts` — purchase round-trip plus WP-07 invariant verification
- `web/apps/api/test/mfgLifecycle.db.test.ts` — first tagged karigar receive coverage, with round-trip and invariant verification
