# X13 original-sale selection: source contract and bounded read slice

This contract was traced before implementation on 2026-09-11. It defines original-sale voucher/candidate reads only. A returned source reference is an immutable observation, **not an incoming Return row, an admission identity or permission to post**. No numeric writer, existing Return mutation, original-sale mutation or stock/ledger effect belongs in this slice. Round6 evidence and the prior round7 calculation contract/vectors remain frozen.

Paths and line numbers below refer to the recovered primary `unified/src/csharp/DataCareNext` and current `web` source. They establish source control flow, not an executable desktop session.

## Desktop actions are different operations

| Action | Exact source | Observed contract |
| --- | --- | --- |
| Choose original sale | `TR_SALE_RTN.cs:16710–16738` | `BtnIsuNo_Click` lists `SL_DATA` joined to same-company/location `BOOK_DATA`, MAIN_BOOK exactly `SALES`, across source years/books. Displays voucher/date/customer/book/`TOT_AMT`; hidden source year/book are copied to `tIsuYrCd`/`tIsuDbCd`. Identity is VCH_NO, not the printed BILL_NO. No source date/current-customer filter appears. |
| Enter original voucher | `16521–16554` | Looks for any existing `SL_DATA` with matching current company/location plus ISU_YRCD/ISU_DBCD/ISU_NO across Return years/books. If found, copies that Return's customer, refuses whole-voucher reimport and directs the operator to single-item selection. Otherwise reads original header/parents, copies original customer and asks whether to import all tags. |
| Import all | `16561–16701` | Iterates all source parents, assigns new visible rows, copies source OLD_SRNO into incoming51, generates incoming40, replaces the Return child buffer, and runs aggregate totals. It does **not** call `CommPassTotal_Pr` for every copied row. Original children are read for the full voucher and retain source SR_NO in child-buffer23. |
| Single-item F1 | `3880–3907` | Runs only on incoming item column1 with blank editor and selected original voucher/book. Shows original `SL_DETL` tags not present in incoming rows of linked Returns. The help row contains source IT_CODE/VCH_SRNO, but follow-up parent read filters by tag only and takes Rows[0]. Source VCH_SRNO is not copied to incoming40. |
| Apply F1 row | `3911–3973`, `3988–4026` | Copies source parent values, resets incoming51 to current visual row, carries image/hallmark data, assigns approval/employee issue N, reads source children by tag, rebinds child-buffer23 to the incoming row, then invokes `CommPassTotal_Pr` at4023. It seeds caches45–49/58/67, not66. The calculation contract covers that separate event. |
| Cancel help | `MS_HELP.cs:1058,1235,2200–2219,2236–2238`; Return `3895–3898,4028–4032,16725–16737` | Help initializes HelpClose=false and a new ColValue array. Enter copies the selected cells. Escape closes without setting HelpClose. Empty single-item selection can clear the incoming item cell; voucher help leaves existing source fields alone if no selected date. Do not infer a universal no-change cancel contract from HelpClose alone. A future web cancel preserving the draft must be identified as deliberate loss protection. |

Whole import differs materially from F1 beyond the trigger: default whole import copies KR_TOUCH/KR_WEST_PRC/KR_FINE, with a registration-specific ITM_* exception (`16581–16596`); F1 copies ITM_* unconditionally (`3931–3935`). Whole import with positive source TAX_PRC copies NET_AMT into both36/38 without assigning37/67 there (`16614–16624`). Whole import copies extra hallmark values and image from **Rows[0]** for every parent (`16633–16642`), unlike row-specific F1. These are source-known differences/anomalies; a read endpoint must preserve each raw parent and never implement those copy rules silently.

## Identity and child ownership

The original Sales writer supplies the crucial parent-child relation:

- `TR_SALE.cs:15385–15386` writes parent SL_DETL.SR_NO from visible0, and OLD_SRNO from hidden57. Saved load restores hidden57 from OLD_SRNO (`14507–14515`).
- Child save matches buffer23 to parent57 (`15565–15579`), writes **SL_IDTL.SR_NO = parent OLD_SRNO**, plus parent tag and VCH_SRNO (`15594–15597`). Saved child load retains SL_IDTL.SR_NO in buffer23 (`14670–14677`). A blanket child.SR_NO=parent.SR_NO join is incorrect when SR and OLD differ.
- Return whole import preserves original OLD_SRNO into incoming51 and source child SR_NO into buffer23 (`16564,16671`); Return child display matches those values (`16760–16765`). Single-item F1 instead assigns both to the new incoming visual row (`3913,3994`).
- Return creation initializes incoming40 independently (`3782–3801`); whole import generates it (`16644`); save generates only when zero and persists that value (`14482–14497`). Incoming parent SR_NO/OLD_SRNO/TAG_SRNO are independently written at `14307–14311,14513`.
- Return child persistence goes to **BAR_IDTL** (`13166–13179`), finds the incoming parent by51 (`13719–13726`), and writes its new Return scope, incoming51, tag, incoming40 and child ISR (`13730–13786`). Source SL_IDTL is not that new BAR_IDTL identity.

The DTO must therefore preserve original header scope; source parent physical locator/SR/OLD/VCH_SRNO/TAG_SRNO/item/tag; source child locator/SR/ISR/VCH_SRNO/item/tag; and any prior Return's separate scope/incoming identities. Never rename original VCH_SRNO to admittedVchSrno or infer incoming OLD from source SR.

Attach source children only under the same full source scope and an unambiguous parent OLD_SRNO. Use nonblank real tag and finite instance corroboration to detect conflicts. Desktop untagged parent may store `N` while the child stores blank (Sales `15388–15398,15595`), so retain both raw values and recognize this narrowly described untagged spelling difference; do not use it to join all untagged children. Duplicate old keys, missing/nonfinite ownership keys, conflicting tag/instance and duplicate child business identities remain visible in `unresolvedComponents`; no arbitrary first parent, array-position match or tag-only fallback. A child can only belong to one resolved parent. Read every source child, including zero-valued and unresolved rows; do not apply the source writer's nonzero filter to reading.

Current web Sales can itself produce incompatible child pointers: `sales.ts:1077–1082` numbers all parents, while `1214–1226` filters tagged rows **before** numbering child SR_NO. A tagged second parent after an untagged first may therefore have a child SR_NO of1. This read slice reports the contradiction and preserves the row; it must not silently repair that writer or attach by tag alone.

## Current web gaps

`sale-return/page.tsx:250–315,425–439` has a manual Orig Book (default SAL), Orig Bill No and whole import button, with no original-year selection, source voucher browse, single-item F1 or protected source reference. It sends `coBook=origBook`, but `/sales-returns/import` reads `qs.book ?? 'SAL'` (`txn.ts:1163–1170`); selected original book is ignored. The request lacks explicit company/location/year. The page copies all items, defaults zero pieces to1, discards raw null/blank/precision and children, and converts every labour shape into net-weight labour. There is no request-generation guard on the import response. Create payload (`341–375`) omits origBook, source year/location and immutable parent identities.

`salesReturn.ts:585–639` reads one header with LIMIT1, uses current scope year and default SAL, calls five-digit `formatVoucherNo`, converts saved decimals to float/default zero, and returns a small parent projection. It has no configured Sales-family check, source-child read, prior-Return candidate exclusion, ambiguity diagnostic or source version. `numbering.ts:28–35` rejects source voucher numbers above99999 even though desktop original voucher text and SL_DATA.VCH_NO support8 characters (`TR_SALE_RTN:2794`, schema5642).

Existing tagged writer `salesReturn.ts:143–229` selects by tag/item in the **current** year, checks BAR/stock evidence and reuses the original sold VCH_SRNO. That differs from the desktop's separately generated incoming40. It is not an admission primitive for the new source reader. Existing Return header ISU_* writing similarly uses current location/year (`401–405`). Do not connect this new DTO to the legacy create/write path as a shortcut.

## Accepted service and route boundary

Root owns authenticated routes/RBAC and HTTP tests. Service owner adds `apps/api/src/modules/sales/saleReturnSource.ts` and dedicated service DB tests. No existing writer/UI change is included.

```ts
listSaleReturnSourceVouchers(prisma, target: SavedSaleReturnScope, query: {
  sourceYear?: string; sourceBook?: string; search?: string;
  offset?: number | string; limit?: number | string;
}): Promise<SourceVoucherList>

getSaleReturnSourceItems(prisma, target: SavedSaleReturnScope, query: {
  sourceYear: string; sourceBook: string; sourceVchNo: string;
}): Promise<SourceItems>
```

Routes are GET `/sales-returns/source-vouchers` and GET `/sales-returns/source-items`, both owned by Sales/Sales Return **view** rights. Every request supplies target `coCode/lcCode/coYear/coBook`, resolved with authenticated tenant authority. Source fields use only `sourceYear/sourceBook/sourceVchNo`; never the existing `book` alias, which central scope enforcement treats as the target book. No client source company/branch or tenant override is accepted. Source company/location equal the selected target company/location, as in the primary desktop flow. Historical configured source years are allowed.

Validate current target configured Return book and source YEAR_MAST; the source book must resolve exactly once to active MAIN_BOOK SALES, expected SL_DATA and outward family in this company/location. Root explicitly chose active source books for this bounded slice. Desktop voucher browse lacks CUR_USE/YEAR_MAST filtering, so archived/missing-config historical sources remain a documented read-parity limitation, rather than being silently assigned another book/year. Resolve optional list filters; without them, browse matching configured Sales books/years in the current company/location. Do not impose the current customer or current fiscal date as a source filter; selection supplies the saved original customer for later explicit operator consideration.

Reject missing, unknown, array or wrong-typed query values; accept bounded canonical integer pagination only (offset>=0, limit1–100; defaults0/25). Search is bounded literal text over saved voucher, BILL_NO, saved customer and book name. Stable deterministic sorting/pagination must not collapse repeated voucher numbers from different books/years. Source voucher input is a nonblank numeric string of1–8 digits: try exact persisted key first; only if absent may short1–5 digits use five-digit padding. Never normalize two coexisting keys `1` and `00001` into the same record. Do not change the shared writer numbering contract.

Use `SaleReturnSourceError(statusCode,code,message)`:400 invalid-input,404 not-found,422 configuration/unsupported-state. Reads use a consistent RepeatableRead observation, parameterized values and fixed table projections. GET must not allocate a voucher/HD number, create defaults, acquire a write reservation, mutate tag/stock, calculate totals or call existing Return import/create/update functions. Set `Cache-Control:no-store` at the route.

## DTO, resolution and eligibility

`Raw = Record<string,string|null>` is projected in PostgreSQL before JSON numeric/date coercion, following `savedSaleReturn.ts:157–171`. Preserve complete source business columns and six fractional timestamp digits. Stored floating columns are returned as their current PostgreSQL text; this cannot recover precision already lost before this read. Physical row_id is excluded from raw; a scoped opaque recordId identifies an observed row. Source SL_DATA/SL_DETL/SL_IDTL have row_id keys and **no unique full business key** (schema5637–6003), so duplicate rows must be detected explicitly.

Stable response structures:

```ts
type SourceScope = {coCode:string;lcCode:string;coYear:string;coBook:string;voucherNo:string};
type Availability = {
  status:'available'|'returned'|'ambiguous'|'unsupported'; reason:string|null;
};
type SourceVoucherList = {
  scope: SavedSaleReturnScope;
  rows: Array<{source:SourceScope;raw:Raw;
    display:{customer:string;date:string;bookName:string;billAmount:string|null};
    availability:Availability}>;
  offset:number;limit:number;hasMore:boolean;
};
type SourceItems = {
  scope:SavedSaleReturnScope; source:SourceScope; version:string;
  header:{raw:Raw;display:{customer:string;date:string;bookName:string;billAmount:string|null}};
  lines:Array<{
    sourceRef:SourceScope & {recordId:string;version:string;srNo:string|null;
      oldSrNo:string|null;vchSrno:string|null;tagSrNo:string|null;itCode:string|null;tagNo:string|null};
    raw:Raw;display:{itemName:string|null;itemNameReason:string|null};
    components:Array<{identity:{recordId:string;srNo:string|null;isrNo:string|null;
      vchSrno:string|null;tagNo:string|null;itCode:string|null};raw:Raw}>;
    availability:Availability;canSelect:boolean;
  }>;
  unresolvedComponents:Array<{identity:ComponentIdentity;raw:Raw;reason:string}>;
  linkedReturns:Array<{source:SourceScope;headerRaw:Raw;linesRaw:Raw[]}>;
  capabilities:{canApplyIncoming:false;reason:string};
};
```

`available`/`canSelect` mean an unambiguous source candidate can be selected for **read-only inspection/future preview**. They never mean returnable stock or permitted financial mutation. Header list availability describes whether whole-voucher source import has known linked Returns, without enabling import. Include excluded/unresolved rows and reasons in the detail response so the operator can understand them. Missing/duplicate master matches produce explicit display diagnostics, with separate raw values retained; no arbitrary joined master may multiply/replace parents. A duplicate source header prevents constructing a unique document and returns422 instead of LIMIT1.

Prior-Return evidence follows the source's actual reference shape: same tenant/company/location, exact ISU_YRCD/sourceYear + ISU_DBCD/sourceBook + ISU_NO/sourceVoucher, across Return years/books. Preserve complete linked header and incoming rows. Known different ISU_LC_CODE does not belong to this original location; NULL/blank ISU_LC_CODE under the otherwise exact reference remains conservatively ambiguous. Header linkage alone blocks whole-voucher import; matching nonblank tag linkage blocks that single-item candidate. Missing/duplicate linked headers/companions or ambiguous tag reuse return an explicit reason, not a balance guess. This is source-selection eligibility, not proof of consumption. Partial/absent original year/book/voucher references cannot be assigned to a source by tag alone and remain a wider historical-provenance gap.

Desktop's `NOT IN` subquery at3882 is tag-level, ignores source VCH_SRNO, and a NULL joined tag can make every candidate comparison unknown. The new reader must **not** hide all source rows because of SQL NULL poisoning. Surface the incomplete link as ambiguity; do not assert a remaining tag eligible when evidence is unresolved. Repeated same tag across source rows is also ambiguous despite distinct SR/instance, because desktop follow-up selects by tag and takes Rows[0]. Blank/null source tags cannot pass the desktop's nonempty selection check; `N` is a literal source sentinel, not a unique tag identity. These anomalies require explicit later acceptance before a numeric/admission writer.

Source version is a SHA-256 observation over exact target/source scope, all raw/physical source header/parents/children, linked Return evidence, and the master/book/year inputs used for display and availability. Include physical revisions/locators to invalidate delete/recreate and A→B→A changes. Canonical ordering must be independent of query row order. A version is neither authorization nor a trusted payload: any later preview/writer must re-resolve the full source reference from the database and compare the observation, never trust echoed raw values or cached availability. This slice has no such writer endpoint.

## Focused verification to implement

Use an isolated tenant on disposable55433 and serialized DB slots. Dedicated service tests plus root authenticated route tests should establish:

1. Two configured Sales books, two historical years and identical voucher numbers remain separate; target Return book is independently validated. Other tenant/company/location and non-Sales books never supply candidates.
2. Historical configured year succeeds; missing/duplicate year, inactive/ambiguous/wrong-family source book, bad target family and absent source header fail explicitly. Missing/array/unknown/nonstring query keys and malformed/canonical pagination fail400. View-only Return operator can read; lacking own Return view cannot borrow Sales/another form rights.
3. Exact imported6–8 digit source keys work; coexistence of1/00001 chooses exact; short fallback only when exact absent. Printed BILL_NO is display/search data, not voucher identity.
4. Parent SR17/42, OLD31/58 and instances301/580; child SR31/58 with noncontiguous ISR3/9; exact OLD ownership despite deliberately different visible SR. Zero/null/blank/whitespace/large decimal/full timestamp, hidden hallmark/image/karigar/tax and all child fields survive raw projection.
5. Duplicate parent OLD/business keys, conflicting child tag/instance, duplicate ISR and orphan child remain visible as ambiguity/unresolved records. Untagged N parent/blank child is only accepted under unique old-key ownership; it never joins all N rows. Regression for the existing web filtered-tag child misindex must refuse guessed ownership.
6. Linked Return in another current year/book blocks matching source tag and whole import; unrelated known source year/book/voucher/location does not. Incomplete NULL/blank location and orphan linked header/tag produce visible ambiguity. NULL `NOT IN` evidence never silently empties the source list. Repeated source tag/instance candidates do not select Rows[0].
7. Known item name, missing/duplicate master and raw-null descriptions are separately represented without source rewriting. Master changes alter the observation where they affect the DTO/eligibility.
8. Source header/parent/child update, child insertion/removal, linked Return update/insertion, book/year/master change and delete/recreate/ABA change the version; unchanged consistent read is stable. Scope differs even for identical raw rows.
9. Complete before/after DB snapshot verifies **zero writes** to original/Return headers, parents, children, BAR/stock, finance, counters and sequences. No calculator/posting/admission helper is called. DTO always has canApplyIncoming:false.

These tests are prospective until the new implementation's recorded results exist. A later operator selector requires an independent scoped dialog/read surface, stale-request and cancel tests, explicit source read-only messaging and real-browser verification. It must not feed this observation to the legacy whole-import writer. Original-sale selection, incoming calculation, admission/tag ownership, companion propagation, reversal, financial posting and operator/business acceptance remain separate gates.

## Inspected source hashes

These hashes pin the pre-implementation inspection; later source changes require a new implementation evidence record.

| Path relative to imodule-extracted | SHA-256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/TR_SALE.cs` | `b122837a890d99c370ec60e309b59a5207b65556493ce29f62ca6584e428d690` |
| `unified/src/csharp/DataCareNext/MS_HELP.cs` | `350899da0ffc4d237602f22ed23ef5054374d2f2073558c5fb060a0e583022cf` |
| `web/apps/web/app/(app)/txn/sale-return/page.tsx` | `3c8f6e46d9c175793321b852d3adbf434a4214cdd566afad0d1fc979079bb29b` |
| `web/apps/api/src/modules/sales/salesReturn.ts` | `612ddcd8f3b0cb8f0368435495125c8b50ed2f8cd03adad11f1cef12cf1d2a70` |
| `web/apps/api/src/modules/sales/sales.ts` | `f9edc60fb957d5efc708bc321b1fd905ff186f1d87519728b874a8af79b62f12` |
| `web/apps/api/src/modules/sales/savedSaleReturn.ts` | `05c2218ad69b0c0cd8cf1a4e542816a9fcae5c48057ed8c1b27dc1596ba94a06` |
| `web/apps/api/src/routes/txn.ts` | `28c676868b9a123bd00ce888a636d5873f6bbe085c190125441b810275f43044` |
| `web/apps/api/src/modules/rbac/routePolicy.ts` | `5f8d0ab65432b94b092006d3689af9a54a731d2746de3f54aada7446cc15073e` |
| `web/packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
