# Company master

## Scope and authority

Company → Company opens desktop form `MS_COMPANY` (`unified/src/csharp/DataCareNext/MDI_FORM.cs:7411-7420`). The
menu caption also drives view authorization through `USER_SET` (`MDI_FORM.cs:7032-7049`). The web route is
`/masters/companies`.

This page records the source-study-approved first milestone. It does not claim the complete desktop form, accepted
parity, or a verified desktop match.

## Desktop behavior

- Load, defaults, list, and open are in `unified/src/csharp/DataCareNext/MS_COMPANY.cs:5704-6001`. The form lists
  companies, chooses the next code for a new record, and opens an existing `CO_MAST` identity for edit.
- Save is in `MS_COMPANY.cs:6022-6227`. It writes the company identity and, for a new company, opens `MS_YEAR` rather
  than leaving an identity-only company ready for use.
- Company delete is in `MS_COMPANY.cs:6254-6418`. The desktop issues a long sequence of table deletes. That mechanism
  is neither scoped nor atomic enough for a hosted multi-tenant service and is not ported.
- Keyboard, state help, focus, and validation handlers are in `MS_COMPANY.cs:6428-6745,7211-7276`.
- Print selects `Company.RPT` in `MS_COMPANY.cs:6776-6790`. The extracted report
  `extraction_output/rpt_xml/Company.xml:99-305` orders company code, name, address lines, state, and city.
- First-year creation is in `unified/src/csharp/DataCareNext/MS_YEAR.cs:1170-1400`. The new-company master copy is
  `MS_YEAR.cs:1504-1595`.

The operator study in `project-memory/video-research/_kb/KB_master.md:45-75` shows the list, state selection, Save →
Year Create hand-off, relaunch, company selection, and first work in the new company. It is supporting evidence; the
source above remains authoritative.

## Exact desktop messages frozen for later stages

- Required company identity: `Enter Company Detail`
- Blank code on Enter: `Please Insert Co Code ...`
- Blank name on Enter: `Please Insert Co Name ...`
- Duplicate code: `This Company Code already Exist in  '<name>'  Company Name...Please Change Company Code...`
- Duplicate name: `This Company Name already Exist in  '<code>'  Company Code...Please Change Company Name...`
- Saved: `Data Are Saved.`
- No edit/delete rights: `You Have No Rights.....`
- No print rights: `You Have No Print Rights.....`
- Lite refusal: `You Cant Creat New Company For DataCare Next Lite Version`
- Basic limit: `You Cant Creat More Then 2 New Company For DataCare Next Basic Version...`
- Blank delete selection: `Please Select Company Code For Delete.`
- Default-company delete refusal: `You cant Delete Defoult company...`
- Desktop destructive confirmation: `All Record From This Company Will Delete Permanently ?`

`MS_COMPANY.cs:6484-6745` moves through GST and PAN without a source-defined malformed-value refusal. The web must not
invent one as desktop parity. The wider UI expectation and the current `CO_MAST.CO_GST_NO` schema width remain an
explicit blocked 16–30-character discrepancy for a later decision.

## First-year copied families

`MS_YEAR.NewCompParmCreat` copies these 17 table families from a selected company or constrained company `01`
defaults (`MS_YEAR.cs:1504-1595`):

1. `AC_GROUP`
2. `AC_MAST`
3. `BAL_GR`
4. `BOOK_DATA`
5. `BOOK_DETL`
6. `CO_SET`
7. `CO_SET_NEW`
8. `COL_MAST`
9. `CONV_MAST`
10. `EMP_MAST`
11. `GROUP_MAST`
12. `ITEM_MAST`
13. `LOCT_MAST`
14. `PRINT_MAST`
15. `PRODUCT_MAST`
16. `TABLE_MAST`
17. `TAX_MAST`

`YEAR_MAST` and the new `CO_MAST` identity are additional parts of the overall create workflow, not members of this
17-family copy list.

## Milestone 1: generic containment and read-only surface

N58 remains **planned** in the execution backlog. This milestone adds containment code and executable evidence; it does not complete G38 or G39.

- `CO_MAST_CONFIG.dedicatedWriter` blocks generic create, update, and delete before the generic master service starts
  a business transaction. Generic CSV import delegates each row to the same blocked create function, so it creates
  zero business rows. The normal authenticated request audit still records each rejected request.
- Business-scope protection runs before the generic writer. A cross-company POST, such as creating code `02` while
  scoped to company `01`, returns HTTP `409` with `{"error":"scope-mismatch"}`. Same-company PUT and DELETE reach
  dedicated containment and return HTTP `400` with
  `{"error":"dedicated-writer","message":"Company uses a dedicated workflow for identity and provisioning; generic create, update, delete, and CSV import are unavailable."}`.
- CSV import keeps the existing aggregate response semantics for a blocked row: HTTP `200`, `created: 0`, `failed: 1`,
  and the generic row error. A later dedicated-route milestone may standardize that response without changing broad
  master behavior.
- `/masters/companies` is a static dedicated page that shadows the generic `[name]` editor. It uses authenticated,
  tenant-scoped `GET /context/companies` and displays only Code and Name plus the current session company identity.
- The page has search and roving keyboard row selection. Filtering selects the first visible company, keeps one
  visible row in the Tab order, and clears the read-only details when no company matches. It has no New, Edit,
  Delete, or CSV action and does not display credentials or placeholder identity fields.
- The service unit test asserts that the generic writer transaction never opens. The HTTP/database test snapshots
  every tenant-scoped table around the combined POST/PUT/DELETE/import containment requests: every non-audit table
  is unchanged, while the four expected `audit_log` rows record the scope-first POST `409`, two same-scope `400`
  dedicated refusals, and the `200` import result.
  Feature cases call their four-table checks “representative dependent rows,” not a complete-tenant snapshot.
- The executable T02 case is baselined under G38 because `/masters/companies` still lacks the desktop New action and
  editable identity fields. The generated progress page therefore reports one open Company case rather than green.

The safe list is implemented by `web/apps/api/src/modules/auth/businessScope.ts:193-211`. Executable T11 evidence
seeds a second same-tenant company and a foreign-tenant `CO_MAST` sentinel with owner-only fixture SQL, then removes
both in `finally`. The admin sees both same-tenant companies and never the foreign sentinel; the existing restricted
user assigned only to company `01` sees only `01`. The current company code comes from the server-authenticated
business scope.

## Why Company delete stays blocked

The desktop cascade at `MS_COMPANY.cs:6254-6418` deletes many business tables through separate statements. Porting it
would risk partial deletion, tenant escape, orphaned rows, and unrecoverable loss. Decision D25 requires Phase 1 to
preserve business results without copying desktop weaknesses, and G80 identifies destructive desktop operations that
need managed hosted replacements (`docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md:93,258`).

Milestone 1 therefore blocks same-scope generic deletion with the dedicated-writer response used by other requests
that reach containment. Cross-company requests can be refused earlier by business-scope protection. A future route may
use a different method/status only after the owner accepts a safe-delete contract. No delete cascade is implemented
here.

## Remaining stages under N58, G38, and G39

1. Add the complete source-backed identity form with state and source-company lookups, exact validation/edition
   messages, conditional fields, rights, a version token, and idempotent create.
2. Create `CO_MAST`, first `YEAR_MAST`, and all 17 copied families atomically from a hash-pinned template or explicit
   source-company snapshot. Prove tenant isolation and rollback after every stage.
3. Use the desktop identity conventions tracked by G39: location `00`, three-digit numeric books, five-digit account
   chart, and compatible ledger keys. Do not silently change existing companies.
4. Prove lossless reopen/no-op, edit without reseeding, downstream company headers, and login/select/new-company
   journey through a real voucher.
5. Implement semantic `Company.RPT` print and the complete keyboard flow.
6. Resolve the GST length discrepancy, default-login source question, and a safe hosted-company deletion decision.
7. Run dependency-backed unit/API tests, the zero-mock browser module, visual comparison, and original desktop-runtime
   comparison. Desktop-match coverage remains 0% until that last comparison exists.
