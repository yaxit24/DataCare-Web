# X11 continuation: ordinary Sales Design help search and grid commands

This is an evidence-only implementation handoff. Round4 implements saved Design source selection, exact source copies, linked preview, ordered calculation commits and accessible modal focus. It does not implement every shared MS_HELP search or grid command. Do not change frozen round2/3 evidence. Do not mark this continuation complete from the existing round4 picker tests.

All source paths below are relative to the extracted desktop root. The next implementation must pin their hashes and compare the alternate `unified/src/csharp_nextdm/DataCareNext` extraction before changing behavior. No desktop execution or business acceptance is claimed here.

## Configuration and calling context

1. `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs:658–683` queries `CO_SET WHERE CO_CODE=currentCompany`, then loads `HELP_SERCH` into `DC_Main.MsHelpSearch`. Lines788–792 default a blank loaded value to `S`. This is company configuration, not a browser-selected search mode, branch override or application-global default across companies. The decompiled missing-CO_SET path uses a questionable row-count guard before Rows[0]; do not infer that a missing row is equivalent to an existing blank value.
2. `UT_SETTING.cs:4272–4275` labels the four choices `Selected Col`, `Mobile Mathod`, `Whout Row Short`, `All Column`. Lines4347–4361 restore their selected value;4987–4989 save the first letter to company `CO_SET.HELP_SERCH` and update the desktop global. Preserve persisted S/M/W/A identity; spelling cleanup does not prove behavior.
3. `TR_SALE_ORD.cs:7307–7335` opens Design help on F1 in parent column4. It loads company/current-item-product designs, sets widths and `HelpSelect=1`, then shows MS_HELP. Source visible columns are DesignL, BookNameL, ProductL (RemarkL for DM043NEDM), SizeL, KrNameL, GrwtW, TouchR, WestPrcR, LbrPrcR, LbrRateR. DesignIdL at index10 is hidden. The current web adds its own action column; never treat that as a desktop search column.
4. `MS_HELP.cs:1026` initializes ColNumber=0;1053–1058 clears search and sets HelpClose=false;1235 allocates blank ColValue;1243–1258 selects the first result for HelpSelect=1 and resets HelpSelect. `MS_HELP_Activated:2379–2385` focuses the grid, conditionally restoring row0/current search column for S/M and nonempty search.
5. `MS_HELP.cs:1654–1729` has a higher-priority F1Search override before ordinary mode dispatch. The ordinary Sales Design call does not set this flag. `MS_HELP_Closed:2388–2392` resets it. Do not expose an arbitrary client override or assume every shared-help caller has the same flag lifecycle.

## Search branches that must be modelled separately

`MS_HELP.tSearchText_TextChanged` is decompiled as a switch/goto graph. Follow its IL labels, not textual statement order. Exact branch observations from the current extraction:

| Branch | Source evidence | Source effect / remaining proof |
| --- | --- | --- |
| S, L/M suffix | 1745–1779 | New DataView over the original source; selected-column text prefix `query%`. It is not multi-column contains search. |
| S, W suffix | 1792–1800 | Numeric range from Conversion.Val(query) through Val(query)+0.3, inclusive. Here suffix W means a weight column, independently of search mode W. |
| S, other numeric suffix | 1813–1817 | Selected column >= Conversion.Val(query), not numeric-string matching or equality. In this Design DTO this applies to Touch/West/Labour%/LabourRate with suffix R. |
| S, D suffix | 1782–1789 | Date/day-format branch. The Sales Design list has no D column, so keep this outside the bounded Design implementation rather than adding a generic date API. |
| M, L/M suffix | 1854–1889 | Selected-column contains `%query%`. |
| M, W/other suffix | 1892–1918 | Same inclusive weight band or numeric >= rule. |
| F1Search override | 1654–1729 | Contains text or the same weight/numeric rules before S/M/W/A dispatch. Requires caller-specific proof before use. |
| S/M successful result | 1829–1842 /1927–1939 | Rebind grid only when filtered DataView.Count >0; select row0 at ColNumber. Empty query restores original source and row0 (1844–1850 /1941–1947). |
| S/M no match | 1829–1833 /1927–1931 | Returns before rebinding. Source therefore appears to retain the previously displayed result set. This differs from an ordinary empty web search result. Record a real executable trace and a business decision before claiming an exact or intentionally changed no-match experience. |
| W mode | 1950–1990 | Does not filter the grid. Walks rows in the current column, case-insensitive StartsWith; selects the first match and returns. No-match leaves the grid/selection. |
| A mode | 1994–2013 plus IL_0a37–IL_0b00 at1597–1631/1695–1718 | Acts only for nonempty query length >2. Traverses rows and cells using StartsWith. A match selects that row/cell then advances to the next row. Source graph suggests the last matching row, first matching column within that row; hidden cells and exception-resume effects need IL/runtime confirmation. Do not substitute first overall match or literal multi-field filtering. |
| Unrecognized mode | IL_0b12 onward at1802–1828/1900–1925 | Current-column prefix navigation fallback. Blank CO_SET is already defaulted to S at company load. An unrecognized nonblank imported value needs explicit reconciliation or proven fallback; it is not a reason to silently choose M. |

The source uses DataView expression text, VB Conversion.Val, .ToLower and StartsWith. PostgreSQL collation, JS Number, a regular expression, or SQL LIKE are not proof of equivalent semantics. Quotes/wildcards/brackets, invalid numeric text, Unicode/case folding, decimal/binary edge values and empty search require explicit fixtures. Implement the observed business operation without reproducing unsafe dynamic SQL or executing arbitrary expressions. Document any literal-search preservation difference and obtain acceptance rather than describing it as exact source behavior.

## Grid and focus commands

| Command | Source | Required behavior / caution |
| --- | --- | --- |
| Left/Right | MS_HELP2162–2179 | Clear search; update ColNumber relative to current grid cell. Bounds use source column count, including hidden image index10. Determine actual hidden-column navigation from WinForms/IL/runtime before implementing a boundary rule. |
| Up/Down | 2183–2186 | Handler returns and leaves movement to the native DataGridView. Web must own an explicit active row and preserve it independently from Tab focus and pagination. |
| Backspace | 2188–2193 | Remove the last character from accumulated search when nonempty. Do not accidentally delete a Design parent, its components or the browser history. |
| Enter on current row | 2197–2223 | Copy every source cell of the current DataGridView row into ColValue and close. This must retain the exact saved source ref, not re-resolve by duplicate Design display name. |
| Enter when original result count is zero | 2200–2205 | Set HelpClose=true and close; caller returns unchanged. This tests original RsDg count, distinct from filtered no-match behavior. |
| Typing while grid-focused | 2279–2360 | Append key character except Backspace; keep grid focus; S/M select first result/current column after text processing. IME/composition, modifier keys and modern key event ordering need deliberate web handling. |
| Mouse/current cell | 2394–2400 | Clicking a non-final source column updates ColNumber. Double-click selection is a separate source handler around2038 onward; trace it fully before treating a generic row click as confirmation. |
| Escape / title close | 2236–2238 /2270–2273 | Close without setting HelpClose. Current web intentionally preserves the draft. See `x11-help-cancel-source-trace.json`: ordinary source Escape appears to reach the caller's empty-selection clear Design/imageN branch. Acceptance remains open; do not silently switch to destructive clearing. |
| F1 inside help | 2240–2255 | Sets MsCreat or MsSubCreat and optionally MsMobileSearchNo, then closes. There is no proved Design-create destination here. Sales Activated around10040–10047 consumes MsCreat by assigning account code/name. Trace activation/global lifecycle before implementing any nested create; never infer it should launch Design Book creation. |

## Bounded implementation sequence and ownership

1. Start with an immutable source packet: primary+alternate MS_HELP, MS_OPNCOMP, UT_SETTING, TR_SALE_ORD; named-method IL where control-flow or hidden-column behavior is unresolved. Record native traces for S/M no-match, W/A traversal, Escape/title close, hidden image boundary and nested F1. Existing round4 web screenshots are not native evidence.
2. Extend only the saved Design selector contract in `packages/core/src/salesOrderDesign.ts` and `apps/api/src/modules/sales/orderDesignSelection.ts` for server-resolved company search configuration and the known source-column descriptor. Coordinate exports and `txn.ts` route query mapping with root/API owner. Do not change generic shared lookup behavior or another order family incidentally.
3. Resolve CO_SET in the same authorized Sales snapshot as source list/configuration. Validate tenant/company and duplicate conflicting config; preserve the actual blank-existing-row→S rule separately from missing/ambiguous imported settings. Keep saved-source version/product checks and SHARE locks unchanged.
4. Add a pure help-state reducer with active source row key, source column, query, original result identity and displayed cohort. Keep immutable full source refs through paging, search and keyboard selection. Model filter modes and navigation-only modes independently. Never use action-column index or display Design number as identity.
5. Implement the source-supported S/M text and numeric semantics with explicit query/column validation; prove original-order/pagination behavior. If server pagination cannot reproduce the native full result universe for keyboard W/A, implement a server navigation contract before enabling those modes. Returning a match only from the current25 rows is incomplete.
6. Extend `SalesOrderDesignPicker.tsx` with grid active-descendant/roving focus and a visible selected-column indicator. Preserve the existing modal Tab trap, read-only photo preview, per-row return focus and immediate scope/item invalidation. Arrow navigation and typing must not send an order edit; only confirmed selection emits the already validated event.
7. Keep current safe Escape preservation until the recorded desktop/business decision; test and label it as a divergence. Keep nested F1 disabled/unimplemented until its actual Design context is proved. Do not synthesize MsCreat as a web create API.
8. Preserve round4 invariants through every command: invalid unrelated draft, parent/child IDs, existing-row marker, copied blank image versus N/null, no gross/components adoption, no calculation from selection, and later manual/labour edits remain ordered.
9. Run focused pure-state and DB/HTTP tests before the combined browser, using root's serialized isolated55433 DB slot. Use real configured modes, seeded rows outside the first page and actual API requests. Retain failed-run logs separately and inspect final screenshots.
10. Freeze a new evidence manifest with exact source/product hashes and unresolved acceptance items. A passing web journey closes only the implemented command/configuration cases, not complete MS_HELP or X11 parity.

## Required fixture and verification matrix

- Two companies with different HELP_SERCH modes, a blank existing setting row, missing row, invalid value and conflicting imported duplicate settings. Assert scope transitions cannot show/use the prior company's mode or result.
- Duplicate Design display names across albums and serials, noncontiguous serials, old serial null/non-null, zero/NULL source cells, and a valid source outside the first page. Confirm Enter selects exactly the active saved key and rejects a changed source version.
- L columns with prefix-only, infix-only, mixed case, whitespace, apostrophe, percent, underscore, brackets and non-ASCII cases. Separate S prefix from M contains, and record expression/locale differences honestly.
- GrwtW values immediately below q, at q, at q+0.3 and immediately above; negative q, zero, decimal strings, invalid/non-numeric text and binary midpoint vectors. R columns below/equal/above q. No artificial display rounding before comparison.
- S/M successful filter then a no-match query, backspace to a match, clear search, and Enter. Assert the decided visible-cohort behavior and exact selected source; do not equate original-empty with filtered-no-match.
- W mode first-match navigation without row removal; A queries length0/1/2/3, multiple matching rows/columns and hidden-image-only match. Keep these tests pending runtime/IL decisions where necessary rather than baking in a guessed result.
- Left/Right at both visible boundaries, Up/Down top/bottom, current-column mouse selection, text typing and Backspace while grid-focused, Enter and double-click confirmation, IME composition, Tab/Shift+Tab and return to the invoking Design input.
- Existing saved photo → blank-image source selected via keyboard, save/reopen exact empty string, absent preview and disabled stale saved-photo actions; new source selection preserves entered gross and component rows.
- Pending request + row deletion/reorder, scope/book/item switch, cancelled modal, delayed response, stale source, invalid numeric draft and denied Sales rights. No hidden order writes from navigation, no unhandled browser errors, and no permission borrowing from Design Book or Tag Print.

The unresolved branches above are explicit continuation requirements. Passing ordinary Sales selection tests and proving a source query field is used does not substitute for this matrix or production business acceptance.
