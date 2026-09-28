# X13 next prerequisite: authoritative incoming Return configuration

Date: 2026-09-11. Read-only preparation by `design_components`, while root runs round7 regression. **No configuration endpoint, resolver, migration, numeric UI save, or replay integration is implemented by this artifact.** Existing source, tests, core review, and earlier evidence remain frozen.

This contract concerns the primary `TR_SALE_RTN.MSG_PR` grid and the pure `saleReturnIncoming.ts` reducer. It excludes the outgoing `MSG`, UAE form, bill aggregates, stock admission, and financial writer. Source references are relative to the extracted project root unless prefixed `web/`.

## 1. Correct source tables and identity

`DC_Main.RsClDetl` is a DataTable variable, **not a table named COL_DETL**. `DC_Main.cs:1686–1692` loads it with `SELECT * FROM COL_MAST WHERE CO_CODE = activeCompany AND BOOK_NAME NOT IN ('TAG_IDTL')`; the separate `RsClIdtl` loads `TAG_IDTL`. A search of the primary C# source found no `COL_DETL` table reference. Earlier use of that name in planning must not become a migration or query.

`TR_SALE_RTN.cs:3739–3755` filters the loaded company snapshot by literal `BOOK_NAME='SALES RETURNE'` and the grid's **original source heading**, then reads row zero. It does not filter by the operator's configured book display name, voucher number, financial year, branch, or caption after renaming. The same company's two configured Return books share this column family. Their request/replay identities must still remain distinct.

The physical web storage is already present:

| Model/source | Relevant fields and identity |
| --- | --- |
| `packages/db/prisma/schema.prisma:1215–1227`, `COL_MAST` | `tenant_id`, synthetic `row_id`, nullable `CO_CODE` varchar(2), `BOOK_NAME` text, `COL_NAME` text, `COL_NEW_NAME`, `COL_RPT`, `YES_NO` varchar(255). No business-key uniqueness. There is **no persisted column width or column number**. |
| Schema `CO_SET:1368–1439` | Synthetic row ID; nullable company code; `SL_AMT_TYPE`, `LBR_RATE_GEN`, `ALL_ROF_REMOVE` nullable varchar(255); `LBR_ROF` nullable Float; `LBR_TYPE` varchar(1). Duplicate company rows are possible. |
| Schema `CO_SET_NEW:1441–1516` | Composite primary key tenant/company; nullable `LBR_WITH_GHT` varchar(1). Row absence remains possible. |
| Schema `BOOK_DATA:1014–1044` | Synthetic row ID; company/branch/book, `MAIN_BOOK`, direction, table names, activity flags. Resolve exactly one active configured Return book. |
| Schema `HDD_MAST:2692–2699` | Tenant-scoped synthetic rows and `REF_NO`; needed only if the exact software-edition-dependent Style visibility is resolved. Never return registration values in the operator DTO. |

Desktop settings update columns by **CO_CODE + BOOK_NAME + COL_NAME** (`UT_SETTING.cs:4887`) and refresh `RsClDetl` (`4891`). The web generic `COL_MAST_CONFIG` currently keys only `CO_CODE + COL_NAME` (`apps/api/src/modules/masters/configs.ts:338–343`), omitting the family. Correcting that CRUD identity is a separate prerequisite before using it to manage Return configuration; do not silently change the generic master during implementation of this read endpoint.

## 2. Exact company initialization and final overrides

All line calculation inputs below are company settings, not client choices or stored comparison caches. `MS_OPNCOMP.cs:655` loads column configuration, then `657–659` selects company `CO_SET` without an ORDER BY. It reads row zero despite a `Rows.Count >= 0` condition. Missing rows therefore have **no proved successful desktop fallback**. The web must not describe an invented missing-row default as desktop behavior.

| Source field | Initial assignment | Source blank/default step | Final effective rule for this kernel |
| --- | --- | --- | --- |
| `CO_SET.SL_AMT_TYPE` | `MS_OPNCOMP:686` -> `MsSlAmtType` | `881–883`: empty string -> `N` | Primary Return `4915–4931`: `F` is Fine/width-dependent; `G` is gross; every other value follows net + ghat. `P` is a real settings option but does **not** independently switch this primary amount basis to pieces. Row `RATE_TYPE` column 44 selects the later pieces/rate branch. |
| `CO_SET.LBR_ROF` | `691`: `Conversions.ToInteger(value + "")` -> `MsLbrRof` | `817–819`: if converted integer > 3, assign 0. No explicit negative or missing-value default here. | After both settings tables have been loaded, `1297–1303` forces labour precision to **2** when `ALL_ROF_REMOVE` is exactly `Y`. Otherwise keep the converted/clamped integer. |
| `CO_SET.LBR_RATE_GEN` | `675` -> `MsLbrGen` | `757–759`: empty -> `N` | Primary Return `4996`: generation enabled only by exact `Y` and nonzero labour amount; it is not a uniform recalculation rule. |
| `CO_SET.ALL_ROF_REMOVE` | `717` -> `MsAllRofRemove` | `929–931`: empty -> `N` | `1297–1303`: exact `Y` overrides labour, item-rate, bill-total, and tax precision to 2. It does not remove every rounding operation in this row reducer; the explicit whole-unit sites stay whole-unit. |
| `CO_SET_NEW.LBR_WITH_GHT` | Table read `948–950`, assignment `1006` -> `MsLbrWithGht` | `1224–1226`: empty -> `Y` | N labour basis excludes ghat only for exact `N`; all other source strings follow the include-ghat branch. K still uses its own source formulas. |
| `CO_SET.LBR_TYPE` | `664` -> `MsLbrType` | `733–735`: empty -> `G` | New-row default only: `TR_SALE_RTN:3786` copies it to column 22. Saved/source rows use their own copied or saved `LBR_TYPE`; never replace their value from current company defaults. |

The extracted schema DDL independently defines `LBR_ROF FLOAT NOT NULL DEFAULT 0` (`unified/database/schema/01_Schema.sql:1262–1263`), `ALL_ROF_REMOVE ... DEFAULT 'N'` (`1199–1200`), and `LBR_WITH_GHT ... DEFAULT 'Y'` (`1397–1398`). `LBR_RATE_GEN` (`1259–1260`) and `SL_AMT_TYPE` (`1298–1299`) are nullable one-character source additions. A stored numeric zero is therefore a supported desktop-origin value; it must not be changed to the existing web default 2.

Implement the order explicitly: read/coerce the stored labour precision, apply `>3 -> 0`, load/default the other flags, then apply final `ALL_ROF_REMOVE=Y -> 2`. For supported integers, `4/N -> 0`, `4/Y -> 2`, `0/N -> 0`, and `0/Y -> 2`. A converted negative integer survives the first comparison; final Y would override it to 2, while without Y the later source Math.Round digit argument is unsupported. Do not reject the negative/Y case before applying a valid final override. Fractional, non-finite, overflowing, NULL, and malformed precision conversions require explicit containment or measured VB conversion evidence; this contract does not guess their runtime result.

`UT_SETTING.cs:4280–4283` offers integer 0/1/2/3 precision, and `5014` writes `Val(cbolbrrof.Text)`. It offers No/Yes rate generation (`4264–4265`, save `4951`). `UT_SETTING_MAIN.cs:8526–8538` recognizes N/G/F/P amount types and writes the first character at `9472`; ghat setting reads at `8654` and writes at `9354`. The proposed first supported configuration profile accepts those canonical values and exact empty-string defaults. It must preserve raw values and diagnose noncanonical case/whitespace/unknown values rather than silently uppercasing or trimming them into a different source branch. Unknown source strings have literal fallback branches, but accepting that imported domain should be an explicit later policy decision, not an accidental enum normalization.

## 3. Column width and caption precedence

The original-assembly [IL evidence](x13-calculation-il-review-excerpts.txt) proves the decompiler's overloaded single-index expressions: `MSG_PR_LeaveCell` IL_0038 is `get_ColWidth(activeColumn)`; `CommPassTotal_Pr` IL_0661 is `get_ColWidth(18)`. Assignments such as a width followed by `7` in the C# source are separate width/alignment setters. Do not interpret the alignment number as the final width.

Apply `MSG_PR_CLEAR` in this exact order:

1. Create 71 columns and the static headings/nominal widths in `TR_SALE_RTN:3565–3734`.
2. Style column 6 receives heading `Style` and nominal width 1200 only when `MsSoftType` is A or E (`3595–3604`); otherwise its width is zero and this branch does not assign the Style heading. Other hidden columns 40–70 start at width zero and have no configured source heading assigned here.
3. For columns **1 through 70**, match the current original heading against company `COL_MAST` with literal family `SALES RETURNE` (`3742–3747`). No match preserves the baseline. If a match's `YES_NO` is exact `N`, set width to zero (`3749–3751`). The configuration code never sets a positive width, so `YES_NO=Y` cannot reveal a source-hidden column. Independently replace its heading with `COL_NEW_NAME` (`3753`), even if width became zero. Blank label is not evidence of absent configuration.
4. After all overrides, force column 0 to `round(325*ColCon)` and column 1 to `round(300*ColCon)` (`3758–3759`). Thus `RecCode` may be renamed but cannot remain hidden by `YES_NO=N`; Sr is not visited by the override loop at all.
5. Copy widths/alignment to the total grid (`3763–3776`); this is presentation propagation, not another calculation policy.

`COL_RPT` is stored alongside these settings but is not read by this initialization or the checked primary calculation handlers. Do not graft Design Book's repeat policy into this Return reducer.

**Width is not stored in COL_MAST.** `ColCon = 1 + (PcW-MainPcW)/MainPcW` at `TR_SALE_RTN:9585–9587`; desktop normally sets `MainPcW=1366` and obtains the primary screen width (`MS_OPNCOMP:383–388`), with a special-registration path and other login initialization outside this bounded resolver. The row arithmetic only needs the distinction zero/nonzero. A future server should publish both nominal source width and a resolved `widthState: 'zero'|'nonzero'|'unresolved'`, and adapt that predicate to the kernel without accepting browser CSS width.

For the pure kernel's existing numeric width parameters, a documented server adapter may supply 0 or the positive nominal width at a canonical source scale of 1, because only equality to zero is read. Call this `widthMode: 'source-zero-predicate'`; do not label it the measured desktop pixel/twip width. A pathological/unresolved desktop scale that could round positive widths to zero remains outside that supported adapter profile. Browser zoom, responsive hiding, or resizing must never change this calculation predicate.

Software edition is not a company setting. `MS_OPNCOMP:612–652` derives `MsSoftType` from a nonblank HDD registration row and the existing registration flow, then the Return Style branch tests A/E. The first resolver may leave Style's width state unresolved if authoritative edition resolution is unavailable, while still resolving Fine and ordinary calculation fields. Any event that needs an unresolved column is rejected. Do not accept edition or column-6 visibility from the browser or infer it from another form's cost mode.

### Static column IDs and mappings

Use the immutable source ID `x13.primary-incoming.cNN` for events, with NN the zero-padded source column below. Keep numeric source index and storage field in the server-owned catalog. These IDs must never derive from `COL_NEW_NAME`, ordinal position in a filtered web table, or translated headings. Mapping to a source storage column is **not** authority to edit that column.

The table below records source nominal width before the screen scale. Width 0/1 shows the final forced values. Headings and widths come from `3565–3703`; storage mappings from the incoming writer `14307–14478`.

| Stable ID | Column / original heading | Nominal width | Storage field | Leave kind | Source heading / writer line |
| --- | --- | --- | --- | --- | --- |
| `x13.primary-incoming.c00` | 0 / `Sr` | 325 | `SR_NO` | text | 3579 / 14307 |
| `x13.primary-incoming.c01` | 1 / `RecCode` | 300 | `IT_CODE` | admission | 3582 / 14315 |
| `x13.primary-incoming.c02` | 2 / `TagNo` | 1100 | `TAG_NO` | text | 3585 / 14334 |
| `x13.primary-incoming.c03` | 3 / `Receive Item` | 2200 | `ITM_REMARK` | text | 3588 / 14319 |
| `x13.primary-incoming.c04` | 4 / `Counter` | 900 | `TBL_CODE` | text | 3591 / 14338 |
| `x13.primary-incoming.c05` | 5 / `Design` | 1300 | `DESIGN_NO` | text | 3594 / 14342 |
| `x13.primary-incoming.c06` | 6 / `Style` | 1200 for A/E; otherwise 0 | `ITM_STYLE` | text | 3599 / 14346 |
| `x13.primary-incoming.c07` | 7 / `Size` | 800 | `ITM_SIZE` | text | 3607 / 14350 |
| `x13.primary-incoming.c08` | 8 / `HmId` | 900 | `HM_ID` | text | 3610 / 14354 |
| `x13.primary-incoming.c09` | 9 / `Pcs` | 700 | `ITM_PCS` | integer | 3613 / 14358 |
| `x13.primary-incoming.c10` | 10 / `GrWt` | 1100 | `ITM_GWT` | decimal3 | 3616 / 14362 |
| `x13.primary-incoming.c11` | 11 / `OthWt` | 900 | `ITM_OTH_WT` | decimal3 | 3619 / 14366 |
| `x13.primary-incoming.c12` | 12 / `NetWt` | 1100 | `ITM_NWT` | decimal3 | 3622 / 14370 |
| `x13.primary-incoming.c13` | 13 / `LCode` | 800 | `LBR_CODE` | text | 3646 / 14402 |
| `x13.primary-incoming.c14` | 14 / `Ght%` | 900 | `ITM_GHT_PRC` | decimal2 | 3625 / 14374 |
| `x13.primary-incoming.c15` | 15 / `GhtWt` | 900 | `ITM_GHT_WT` | decimal3 | 3628 / 14378 |
| `x13.primary-incoming.c16` | 16 / `Touch` | 750 | `ITM_TOUCH` | decimal2 | 3631 / 14382 |
| `x13.primary-incoming.c17` | 17 / `West%` | 800 | `ITM_WEST_PRC` | decimal2 | 3634 / 14386 |
| `x13.primary-incoming.c18` | 18 / `Fine` | 1000 | `ITM_FINE` | decimal3 | 3637 / 14390 |
| `x13.primary-incoming.c19` | 19 / `Rate` | 1000 | `ITM_RATE` | decimal2 | 3640 / 14394 |
| `x13.primary-incoming.c20` | 20 / `ItAmt` | 1100 | `ITM_AMT` | decimal2 | 3643 / 14398 |
| `x13.primary-incoming.c21` | 21 / `Lbr%` | 800 | `LBR_PRC` | decimal2 | 3649 / 14406 |
| `x13.primary-incoming.c22` | 22 / `Ltype` | 750 | `LBR_TYPE` | text | 3652 / 14410 |
| `x13.primary-incoming.c23` | 23 / `LRate` | 900 | `LBR_RATE` | decimal2 | 3655 / 14414 |
| `x13.primary-incoming.c24` | 24 / `LAmt` | 1000 | `LBR_AMT` | decimal2 | 3658 / 14418 |
| `x13.primary-incoming.c25` | 25 / `LDisc%` | 850 | `DISC_PRC` | decimal2 | 3661 / 14422 |
| `x13.primary-incoming.c26` | 26 / `LDiscAmt` | 950 | `DISC_AMT` | decimal2 | 3664 / 14426 |
| `x13.primary-incoming.c27` | 27 / `OthAmt` | 1000 | `OTH_AMT` | decimal2 | 3667 / 14430 |
| `x13.primary-incoming.c28` | 28 / `RtnMrp` | 1100 | `ITM_MRP` | decimal2 | 3670 / 14434 |
| `x13.primary-incoming.c29` | 29 / `TgLCode` | 800 | `TAG_LBR_CODE` | text | 3673 / 14438 |
| `x13.primary-incoming.c30` | 30 / `Tag%` | 900 | `TAG_LBR_PRC` | decimal2 | 3676 / 14442 |
| `x13.primary-incoming.c31` | 31 / `TagLRate` | 1000 | `TAG_LBR_RATE` | decimal2 | 3679 / 14446 |
| `x13.primary-incoming.c32` | 32 / `TagLAmt` | 1000 | `TAG_LBR_AMT` | decimal2 | 3682 / 14450 |
| `x13.primary-incoming.c33` | 33 / `TagOtAmt` | 1000 | `TAG_OTH_AMT` | decimal2 | 3685 / 14454 |
| `x13.primary-incoming.c34` | 34 / `TagCost` | 1000 | `TAG_COST` | decimal2 | 3688 / 14458 |
| `x13.primary-incoming.c35` | 35 / `TagMrp` | 1000 | `TAG_MRP` | decimal2 | 3691 / 14462 |
| `x13.primary-incoming.c36` | 36 / `TotAmt` | 1100 | `TOT_AMT` | decimal2 | 3694 / 14466 |
| `x13.primary-incoming.c37` | 37 / `TaxPrc` | 900 | `TAX_PRC` | decimal2 | 3697 / 14470 |
| `x13.primary-incoming.c38` | 38 / `NetAmt` | 1200 | `NET_AMT` | decimal2 | 3700 / 14474 |
| `x13.primary-incoming.c39` | 39 / `KrCode` | 900 | `KR_NAME` | text | 3703 / 14478 |


Columns 40–70 remain separate hidden identity/cache/raw slots: 40 VCH_SRNO; 43 IT_TYPE; 44 RATE_TYPE; 45/46/47/48/49/58/66/67 comparison caches; 50 APR_ISU; 51 OLD_SRNO; 52 PR_CODE; 53 its comparison value; 54 TAG_TYPE; 55 its comparison value; 56 TAG_SRNO; 57 edit/new marker; 59–61 HM_ID2/3/4; 62–65 their four HUID weights including HM_ID_WT; 68 EMP_ISU; 69 DESIGN_IMG_ID; 70 DATA_TYPE. Primary 41/42 have hidden numeric leave cases but no proved editable business heading in this initialization; do not confuse them with outgoing-grid gross/net caches. Preserve all raw slots and do not expose them as ordinary commit targets. Writer mappings are `14481–14584`; saved read and cache assignments are `10362–10438`.

Column visibility alone is not edit permission. `MSG_PR_EnterCell:4456–4488` includes hidden-column navigation and even clears the first hidden cell it enters; exact navigation/loss behavior is not implemented by this configuration endpoint. New/source admission, per-field authority, numeric commit exposure, and source Enter/KeyDown behavior must be proved separately before any writer/UI enablement. Preserve the existing loss-prevention boundary meanwhile.

## 4. Runtime defaults versus provisioning

No matching active-company column row means the source baseline above, not a runtime lookup of company `00`. The desktop updater contains separate provisioning: `MS_UPDATE:8612` reads company-00 templates, `8777–8781` tests company/family/column existence, and `5531–5541` inserts missing rows with template visibility, original-name caption, and repeat N. This is an update workflow, not `OpenTable_ColMast` fallback.

Other updater branches explicitly insert hidden incoming Touch, West%, Fine, Ght%, and GhtWt rows for the active company (`MS_UPDATE:21995–22011`). Therefore a real imported company can legitimately have hidden Fine even though the form's unconfigured baseline is positive. The configuration resolver must read actual imported rows; do not seed/hide them as a side effect of GET and do not hardcode every company's Fine visibility from updater history.

`COL_MAST` and `CO_SET` allow duplicate business rows in the current schema, and the desktop selects row zero without a stable order. Exact desktop selection of conflicting rows is therefore unproved. Future server handling must be deterministic and conservative:

- Require exactly one matching company CO_SET and one CO_SET_NEW for the strict replay profile. Missing/duplicate rows produce a diagnostic and no replay capability; do not borrow another company or use shared web defaults. A separately accepted missing-CO_SET_NEW compatibility profile, if needed, must be named, versioned, and tested as a web policy rather than desktop evidence.
- Require at most one relevant column row for each family/original-name key. Even byte-identical duplicates retain ambiguous physical identity; block the strict replay profile until reconciled. Do not use `LIMIT 1` or deduplicate on the effective output.
- Preserve NULL and empty raw labels/flags distinctly. A supported blank-string new caption may remain blank in source display, while an accessible business fallback label is a separate UI concern. Direct `Conversions.ToString` of NULL caption has no runtime acceptance proof here; classify it explicitly rather than silently merging NULL and empty.
- Do not let renamed-caption collisions change event mapping. Detect malformed/blank keys, duplicate aliases, and noncanonical case/spacing that could collide under desktop DataView/SQL collation. `DC_Main.OpenRecordSetDc:1232–1239` creates a DataTable and fills it without an explicit case/culture policy. This read-only trace has not executed collation edge cases; use canonical exact source keys and flag ambiguous imports for reconciliation.
- Unrelated families or unknown extra original names may be retained as diagnostics/raw provenance; they never become dynamic event IDs. A blank heading match potentially touches many hidden columns and is not a safe extension point.

## 5. Existing web resolvers: reuse boundaries

| Current implementation | What can be reused / what must remain separate |
| --- | --- |
| `shared/bookPolicy.ts:61–112`, `savedSaleReturn.ts:186–191` | Reuse configured full-scope validation with workflow `SALES RETURN`, `requireExplicitMainBook:true`, expected header table `SL_DATA`. Do this in the same snapshot as the configuration read. The literal source column family remains SALES RETURNE regardless of custom book name. |
| `shared/settingsBehavior.ts:283–397,462–540` | It already reads company settings and rejects duplicate CO_SET. It intentionally retains blank SL_AMT_TYPE as an empty web sentinel, normalizes enums, and treats missing CO_SET_NEW as blank flags. These are documented existing-web semantics; not a drop-in authoritative Return configuration contract. |
| `shared/roundingPolicy.ts:36–108`, `roundingPolicyLoader.ts:21–77` | Loader checks duplicate counts, but generic policy intentionally defaults absent precision to 2 and rejects >3 rather than applying source >3 ->0. It also resolves unrelated tax/item/purchase/bill settings and provides Number-valued rounding. Do not use those rounding functions or default behavior in this decimal Return kernel. |
| `sales/salesOrder.ts:341–370` | Its local labour resolver already applies >3 ->0 and final ALL_ROF_REMOVE Y ->2, but preserves a documented missing-value web2dp default and normalized flags. It lacks Return amount type, rate generation, column state, and complete policy version. Do not import the private Order resolver. |
| `masters/designBook.ts:154–208` | Useful structural example of company column reading and configuration versioning, but it resolves DESIGN DETL/TAG_IDTL, accepts identical duplicate settings, hashes effective output, and includes different software behavior. Do not reuse its family, repeat interpretation, duplicate policy, or hash as Return evidence. |
| `settings/settingsInventory.ts`, `settingsCatalog.ts` | Existing authoritative storage-name inventory is reusable. The LBR_ROF catalog label misleadingly includes Y/N although its options are digits; fix that label only in a separately authorized settings UI task. No new database field is needed for the five policy inputs. |

Keep the first implementation bounded to a new `apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts`, local pure configuration/catalog tests, scoped API/service tests, and a root-integrated GET route. Do not change shared resolver semantics or enable numeric save to make these tests pass.

## 6. Proposed API and replay contract

Proposed read endpoint: `GET /sales-returns/incoming-calculation-configuration?coCode=...&lcCode=...&coYear=...&coBook=...`, with mandatory explicit selected scope and authenticated tenant. Use fresh owning Sales Return view rights, not generic Settings or Sales authority; publish capability without granting edit rights. Read with the existing tenant-scoped `RepeatableRead` pattern and a no-cache response. Return configuration ambiguity as a structured read-only observation, or a consistent 422 diagnostic; choose one envelope before implementation and test it. Invalid request scope is 400 and own-form denial is 403.

Suggested DTO (field names are a proposal, not currently installed API):

```ts
type IncomingCalculationConfiguration = {
  scope: { coCode: string; lcCode: string; coYear: string; coBook: string };
  form: 'TR_SALE_RTN'; grid: 'MSG_PR'; columnFamily: 'SALES RETURNE';
  contractVersion: 'x13-primary-incoming-config-v1';
  version: string; // opaque server-generated source-observation token
  policy: null | {
    saleAmountType: string;
    labourRoundingDecimals: number;
    labourIncludesGhat: boolean;
    generateLabourRate: boolean;
    fineColumnWidth: number; // 0 or server-resolved positive nominal value
  };
  newRowDefaults: { labourType: string | null }; // never overwrite a saved/source row
  widthMode: 'source-zero-predicate';
  columns: Array<{
    id: string; sourceColumn: number; sourceName: string | null;
    storageField: string | null; nominalWidth: number;
    widthState: 'zero' | 'nonzero' | 'unresolved';
    label: string | null; originalLabel: string | null;
    configured: boolean; forcedVisible: boolean;
    commitKind: 'text' | 'integer' | 'decimal2' | 'decimal3' | 'admission' | 'none';
    // commitKind describes LeaveCell only; it is not write authorization.
  }>;
  rawSettings: Record<string, string | null>; // whitelist only the six table.field inputs
  diagnostics: Array<{ code: string; fieldId?: string; message: string }>;
  capabilities: { canCalculate: boolean; canSaveNumeric: false };
};
```

Version the selected complete scope, contract/catalog hash, exact raw whitelisted settings, their row identities and physical revision markers, relevant company/family column rows (including absence/duplicates), relevant book configuration, and authoritative edition observation if used. Keep registration values out of the DTO. Hash sorted, typed, exact strings/NULL and explicit row counts, not just derived booleans/labels. A physical update A->B->A must invalidate a stale observation; changed then restored values cannot reuse an old replay token. Existing `xmin/ctid` snapshot conventions can be used within the supported database lifecycle, but durable tokens across restore/rewrite need a configuration revision contract; do not promise indefinite ABA protection from an effective-value hash.

Future numeric replay must resolve the configuration again **inside the same locked/serializable transaction as the saved document/source and final write**, compare this token, then reconstruct the reducer policy and hidden caches from trusted saved/source state. No request supplies effective policy, widths, cached columns 45/46/47/48/49/58/66/67, or a complete precomputed cell map as authority. An event submits only validated stable field ID, original editor text, order, complete row identity, document/source version, and configuration observation token. The server maps field ID to source column and obtains the committed-column width from its catalog. Client focus/clearing context may be useful for UI diagnostics but cannot make a hidden/unsupported field writable. Reject unknown fields and mismatched scope before touching data.

Configuration rows require suitable locking, and row locks alone do not protect the absence of a COL_MAST row from concurrent insertion. Use the repository's serializable pattern plus explicit conflict handling, or a shared lock protocol adopted by **all** relevant settings writers; do not claim a lock on the existing rows solves phantom configuration changes. A stale or changed configuration returns a recoverable 409 with no financial/stock/metadata writes and no automatic replay. Explicit reload preserves/reconciles the operator's draft under the future UI contract.

## 7. Required verification before accepting the next slice

1. Pure settings precedence table: stored LBR_ROF 0/1/2/3, >3, ALL_ROF_REMOVE N/Y, 4/N=0, 4/Y=2, 0/Y=2; negative/Y final override and negative/non-Y unsupported; fraction/non-finite/NULL/missing/overflow cases with explicit diagnostics. No silent web2dp default.
2. Empty-string defaults N/G/Y/N by the correct source field; canonical N/G/F/P amount types; P follows primary net+ghat basis unless row RATE_TYPE is P. Unknown/case/whitespace imported values preserve raw text and follow the declared containment profile.
3. Empty column configuration retains source baseline; explicit Fine N sets zero and changes F basis; Fine Y/blank flag preserves baseline; label-only rename does not change basis. Reuse all eight frozen width vectors by supplying resolved policy.
4. Company-00 template exists but active-company row absent: no runtime fallback or GET mutation. Explicit migrated hidden Fine row takes precedence over baseline. Another company/tenant/family's Fine is irrelevant.
5. RecCode N is forced positive after overrides, Sr is excluded from override lookup, and Style source-hidden remains hidden even with YES_NO Y. Unresolved edition rejects Style-specific events without inventing other widths.
6. Duplicate CO_SET or duplicate family/column rows, including identical duplicates, yield no replay capability; malformed/blank names and case/collation collisions are diagnosed. Same caption on two legitimate source fields preserves different stable IDs.
7. Saved and source LBR_TYPE are unchanged by `newRowDefaults`; hidden raw fields, NULL values, decimal text, identities, and comparison caches cannot be supplied as configuration overrides.
8. Full-scope real HTTP tests: exact configured Return book succeeds; wrong family/table/inactive/missing/duplicate book fails; omitted or stale selected company/branch/year/book fails; view-only user may inspect configuration but gains no numeric-write capability; unrelated form rights cannot authorize the route.
9. Snapshot tests: coherent settings+columns+book read; token changes on relevant row update, delete, insertion, label change, and A->B->A; same read yields stable token; another tenant cannot affect it. Explicitly test a previously absent Fine override inserted between observation and future replay.
10. Future replay tests, **not acceptance criteria for enabling a writer in this read-only slice**: stale settings token, modified document/source, attempted client width/cache/policy injection, hidden column event, row identity mismatch, and interleaved setting mutation all leave the complete database write set unchanged.
11. Frontend integration later must retain stable source field IDs through renamed headings, responsive hiding, sorting and row reorder. Browser CSS resize/zoom cannot change server calculation. Configuration response A->B->A races require an epoch guard, and no failed read enables an old token.
12. Preserve whole prior core suite, frozen35+8 expectations, 33 independent review cases, metadata-only Return tests, and source-read contracts. Run focused source/service/HTTP checks first, then root-coordinated complete regression. New read behavior is a prerequisite only; do not raise numeric-workflow parity claims until source copy, aggregates, admission and writer evidence exist.

## 8. Explicit unresolved or separate decisions

Exact desktop CInt/DBNull/culture behavior for malformed settings; DataView/SQL collation of imported aliases; software-edition and unusual desktop scale resolution; hidden-cell entry clearing; complete Return repeat/navigation policy; schema default-versus-import reconciliation; generic COL_MAST CRUD business identity; durable configuration revisions across restore; and production business acceptance remain separate tasks. None was modified or accepted by this read-only contract.

## 9. Read-only source snapshot

SHA-256 of the files inspected for this contract. This new preparation artifact is pinned externally; it changes none of these inputs. No database, browser, network call, or product/test edit was made for this task.

| Path (extracted root, or this evidence directory) | SHA-256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `unified/src/csharp/DataCareNext/MS_UPDATE.cs` | `943525d918df85170ee3a4733bdf81cdc1d5b7e61b5efed27add7bc2883d8cb7` |
| `unified/src/csharp/DataCareNext/UT_SETTING.cs` | `a47be9b0e2b7754511e8d0aeab135c8352c58f9f417101e550b23ccbc78c30ad` |
| `unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs` | `76116b14149afc1c6a5b93562c9aa9877979c43bdf6372e1d8fe1e6296aec4c5` |
| `unified/database/schema/01_Schema.sql` | `1eb684c7e2bec72a330a9038a2da72ffea669b3ae7ef50b85b34e0e3126efa0d` |
| `web/packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
| `web/packages/core/src/saleReturnIncoming.ts` | `bbc5df6568da23a75804866ab31c789b9be9850e79681d8193a82e1e3430c805` |
| `web/apps/api/src/modules/shared/bookPolicy.ts` | `e5a9a6c75f2c4ccb66f7c2504253876ca9b9b3687e5003de8bf4c9362c03ed74` |
| `web/apps/api/src/modules/shared/settingsBehavior.ts` | `fb6fb19777b888dfd6ade3cbcc3f5ccf809ad265d018296c6b14bb1d1732bc16` |
| `web/apps/api/src/modules/shared/roundingPolicy.ts` | `835a7253b5061dc8206117684c69499a0a294cfadd3fb17de7d04cd83dbea650` |
| `web/apps/api/src/modules/shared/roundingPolicyLoader.ts` | `9cb5cb855e9d918b1a186d64f2fb0e9f3a77d8a2b6340db2766784c4c7436f3b` |
| `web/apps/api/src/modules/sales/salesOrder.ts` | `556d87d9eb73974f4a06eec64a0f6a6fe0096b90e59b14522176021ea10fc8d9` |
| `web/apps/api/src/modules/sales/savedSaleReturn.ts` | `05c2218ad69b0c0cd8cf1a4e542816a9fcae5c48057ed8c1b27dc1596ba94a06` |
| `web/apps/api/src/modules/masters/designBook.ts` | `9ad5c8f700d97d2749dccc6c145181f697cbe099128b0267b086ba3adca54e40` |
| `web/apps/api/src/modules/masters/configs.ts` | `22f58dd4e0bfe76f2001d5dfd9532c89fb1a3ef8a9fb25a27c280639270cd60d` |
| `web/apps/api/src/modules/settings/settingsInventory.ts` | `44883f74107a9aa32e78599d06f688ea2c08814da6d1b6ce7f1658aaf2f5eae3` |
| `web/apps/api/src/modules/settings/settingsCatalog.ts` | `84dc19721f0e3822b3fe3d7a77f451e83ac8b2285fd6eeef3065fd695adb8b12` |
| `x13-calculation-il-review-excerpts.txt` | `8c60e56122820e7fc18cb35aed07188f5016f185ed1d219f7661566facf09144` |
| `x13-calculation-contract-independent-review.md` | `e2a7c2704d0c7290d7007f1a6be2e33a99a7dbebabfcd3cff90d0f8323699835` |
| `x13-calculation-implementation-review.md` | `351a80bfb55f4c7413cc8e287677e690a37cdbb68f7905402d6bd003a9028490` |

