# Option A: pure N BAR companion projection and matcher

Proposed new core file `saleReturnNBarCompanions.ts`; export `matchSaleReturnNBarCompanions(unknown)` and `SALE_RETURN_N_BAR_COMPANIONS_VERSION='primary-incoming-n-bar-companions-v1'`. Stage only. `matched` means this bounded supplied-observation comparison succeeded, never Save permission: every result has `canCommit:false` and unresolved admission requirements.

Exact input:

```
{rowIdentity, tenantId, context,
 before:{visible,incomingTotals}, after:{visible,incomingTotals},
 observed:{barData:[{rowId,version,raw}],barDetl:[{rowId,version,raw}]}}
```

rowIdentity/version/observationIdentity are exact64 lowercase hex strings. They bind only retained supplied observations; the function does not derive or authenticate them. Tenant is canonical printable text, at most24 characters. Each visible map has exactly63 source keys0–70 without caches45/46/47/48/49/58/66/67, each totals map all71 keys. Values are bounded strings, not NULL. No reducer, fold, bill calculation, event journal, lookup, SQL or write is run.

Context is either `{status:'unavailable',reason}` or `{status:'qualified',observationIdentity,values}`. Values has exactly these16 string keys: CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,STK_DATE,HD_VCH_NO,AC_CODE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,VCH_TIME,EMP_CODE,VCH_DESC,MAIN_USER. All are separately qualified target values supplied by an eventual trusted server adapter. The word qualified is a caller precondition, not authority established by a flag or hash. Missing/unavailable context refuses. No user/date/time/provider default is invented. Source mVchDate.Text targets both a date and BAR_DETL.STK_DATE varchar; their potentially different supplied representations stay separate. VCH_TIME is an explicit timestamp target string. This function does not synthesize Windows locale text or prove equivalence between those representations.

Primary predicates are distinct:

- BAR_DETL at TR_SALE_RTN13901: `Val(row9)+Val(row12)+Val(row38) != 0 AND row2 != ''`. N and literal0 are nonblank; blank excludes the parent before the inner blank→N assignment can run. Do not strip or reinterpret N as absence.
- BAR_DATA at13072: `Val(totals28) != 0 OR Val(totals9)+Val(totals12)+Val(totals27) != 0`. Consume the actual separately supplied full aggregate map; do not replace its rounded values with row values.

Parent13908–14225 has74 ordered assignments but70 distinct final target fields. Two TAG_NO alternatives collapse; two VCH_SRNO branches collapse only for nonzero existing instances; TAG_SRNO's temporary0 at14139 is overwritten by c56 at14162; DATA_TYPE blank→A alternatives collapse. Header13080–13124 has12 distinct assignments. Exact complete literal target maps are frozen before code. Parent ITM_RATE/ITM_AMT and KR_LBR_RATE/KR_LBR_AMT/KR_OTH_AMT are0. Parent labour code/rate/amount/Other are c29/c31/c32/c33, costs c34, MRP c35; c27 and incoming row NET_AMT do not directly populate BAR values.

Output retains detached observed row IDs/versions/full raw strings and NULLs, caller context and before/after projections/predicates, differences, diagnostics and requirements. Unsupported phases may have null projections where they cannot be soundly evaluated; complete phases remain inspectable. If a source predicate is false its corresponding target map is null, not a fabricated empty row. A zero instance reports unsupported allocation and never invents a clock/identity. Every refusal keeps candidate mutation authority false; no patch or DML is produced.

Option A matched requires canonical saved N parent, display/source SR1, nonzero stable instance, full context scope/voucher/tenant match, one BAR_DATA and one BAR_DETL observation, both source predicates true before and after, and every mapped target unchanged between phases. Existing observations must match all82 source target values. Numeric fields compare exact bounded mathematical values while retaining original storage spelling; text/NULL/date strings compare exactly. A missing/NULL mapped numeric or missing/NULL mismatching source text refuses. Unknown raw fields remain untouched and observable. Identity rowId must equal raw row_id; raw tenant_id must match tenant. No normalization or Float rewrite follows numerical equality. The current schema's date/varchar/Float representations require separate authority before a writer; this matcher preserves existing raw rows only.

An Other0→1 poststate can keep both companions unchanged. Other=-11 with totalsPCS1/NWT10/MRP0 excludes the header while a row NET99 still includes the N parent; a positive credit bill does not rescue this membership change. Other=-121 with rowPCS1/NWT10/NET-11 excludes the parent while header predicate remains true. Any membership change, absent/duplicate/mismatched observation, non-N tag, renumber/allocation, changed mapped weight/tag/code/metadata or unresolved context is unsupported. Before/after maps are caller observations, not proof of a valid c27 calculation or whole-document admission.

Plain-data boundaries reject extra envelope/phase/context keys, symbols, accessors, custom prototypes, holes and nonstring nested values. Arrays are bounded to8 observations each; each raw map at most1024 fields with bounded string/NULL cells. All returned nested records/arrays are detached and frozen; caller input remains untouched. Numeric Val profile is ASCII plain decimal/blank→0, at most36 significant digits/18 decimal places/absolute value below1e36, private Decimal precision100; no Number conversion or exponent/culture/prefix guessing.

Mandatory external requirements remain trusted replay and full poststate admission; fresh session/Update/document/master/config/Save guards; complete effects/children/references and membership versions; target representation qualification; one Serializable atomic writer. Old metadata/row/bill/labour preview guards remain unchanged. Stock SR_NO2/ISR_NO=incoming SR_NO, USER_UPDATE authority, edition audit and known closing remain separate unresolved prerequisites.
