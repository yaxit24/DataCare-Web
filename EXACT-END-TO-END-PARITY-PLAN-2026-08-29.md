# Exact end-to-end parity plan — DataCareNext/iModule desktop to web

**Date:** 2026-08-29  
**Repository:** `imodule-extracted`  
**Desktop source:** `unified/src/csharp/DataCareNext`  
**Web application:** `web/`  
**Status:** plan only; current web application is **not certified for exact parity or production cutover**

## Executive verdict

The web application is a substantial implementation, not a prototype. It has a Next.js frontend, Fastify API,
PostgreSQL/Prisma data layer with RLS, broad voucher posting, many lifecycle readers/reversals, shared
calculation code, report rendering, device adapters, and a real SQL Server-to-Postgres parity harness. Its schema
can represent the desktop database: the retained audit found all **145 desktop tables and 5,231 desktop columns**
in the web schema.

That does **not** establish behavioral parity. The controlling retained comparison is still red:

- latest real G5 comparison: **0 of 66 cases matched**;
- **3,787 field differences**, **210 missing rows**, and **210 extra rows** over 23,574 compared fields;
- cases cover 51 purchases and 15 wholesale vouchers only, versus a retained footprint of **1,567 vouchers
  across 40 books**; the 94-table voucher-scoped census has a **44-table observed union** for those vouchers;
- the authoritative `NextMain.MENU_DATA` catalog has **198 named entries across 13 tabs**; the retained register
  marks 192 visible and 6 hidden, and all 198 remain unclassified;
- **0 reports** have a retained real desktop-vs-web data comparison, and no report has proved desktop layout
  equality;
- the latest retained real comparison is dated **2026-08-02**, so it must be rerun before any release decision.

There are also present-tense release blockers independent of feature parity: unsafe logical restore behavior,
generic report authorization tied to the wrong report rights, ambiguous Data Repair authority, literal posting
account fallbacks, non-blocking parity gates, and exposed tag operations that can create incomplete lineage.

The requested “complete text tag change” is interpreted primarily as a **complete tech-stack change** from the
Windows/C#/WinForms/SQL Server/Crystal application to the browser/Next.js/Fastify/PostgreSQL implementation.
Because jewellery tags are also a core business object, this plan separately covers the complete tag, text,
label, barcode, QR, HUID, image, stock, sale, and return lifecycle.

## 1. What “exact parity” means

Exact parity is not “a page exists,” “the API returns 200,” “the schema has the column,” or “unit tests pass.” A
desktop function is complete only when all four states below are independently satisfied.

| State                       | Required proof                                                                                                                                                                                                                                                                          |
| --------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Present**                 | A reachable web page/route/service exists for the desktop menu action.                                                                                                                                                                                                                  |
| **Functionally usable**     | An authorized operator can complete the full create/open/edit/delete/print or report workflow, including validation, locks, error recovery, keyboard/scanner behavior, and downstream effects.                                                                                          |
| **Desktop-verified parity** | Under the signed canonical comparison contract, the same inputs produce the same persisted write set, calculations, control totals, report rows, and material output; exact matches and approved divergences are reported separately, with no unexplained missing/extra rows or fields. |
| **Production-proven**       | The behavior is demonstrated with production-like migrated data, target hardware, real external credentials, concurrency/load, backup/restore, monitoring, and a rehearsed rollback.                                                                                                    |

A capability must not be called “done” merely because it satisfies an earlier column.

### 1.1 Authoritative denominators and visibility profile

The classification denominator is **198 named runtime `MENU_DATA` catalog entries across 13 tabs**. The current
`COMPLETION-REGISTER.json` marks **192 as visible** and **6 as hidden**: Main Menu, Fine Sales, Dm Size, Lot
Opening, E-Excel, and Reminder Rpt. All 198 are currently `unclassified`.

Visibility is a release-profile measurement, not a permanent synonym for catalog membership: settings, company,
build, rights, and dispatch conditions can change what an operator sees. Every release must publish a frozen
scope profile recording each catalog entry's visibility predicate, evaluated visibility, disposition, evidence
timestamp, and manifest hash. All 198 entries remain in the classification population; any claim about the
operator-visible denominator must cite that frozen profile.

Secondary views are useful but answer different questions:

- 204 decompiled C# files include support classes and are not a feature count;
- `FEATURE-GAP-AUDIT.json` audits 163 forms including the MDI shell, or 162 audited business forms excluding the shell; this is an audit denominator, not every direct `Form` subclass;
- 52 voucher families in `FUNCTIONAL-PARITY-MATRIX.json` measure posting lifecycle;
- 145 desktop database tables measure overall data shape;
- the footprint census inventories 94 voucher-scoped tables, while the retained 1,567 vouchers across 40 books
  touch a 44-table union;
- 254 web report baselines measure deterministic rendering, not desktop equality.

Every release claim must state its denominator, visibility profile, and evidence timestamp.

## 2. Source-of-truth hierarchy and evidence freshness

When sources disagree, use this order:

1. **Observed desktop behavior and real data:** retained SQL Server bundles, G5 diffs, real report exports, and
   operator-observed/video workflows.
2. **Canonical desktop implementation:** `unified/src/csharp/DataCareNext`, report extracts, behavior catalogs,
   and `NextMain.MENU_DATA` dispatch evidence.
3. **Approved behavior contracts:** `project-memory/contracts/*.contract.md`; drafts are research, not approval.
4. **Current web code and executable tests:** `web/apps/**`, `web/packages/**`, and database/browser tests.
5. **Plans and handoff documents:** useful history only. Several older documents describe features as missing
   even though current code now contains them.

The latest retained real G5 artifact is
`project-memory/parity/g5/parity-diff-latest.json`, compared at
`2026-08-02T17:10:44.204Z`. It is valid historical evidence but was captured **27 calendar dates earlier
(about 26.6 days before this plan)**. A fresh capture and comparison are mandatory before implementation
prioritization is frozen and again before cutover.

## 3. Current implementation scorecard

| Area                       | Present                                                   | Functionally usable                        | Desktop-verified                                                                                       | Production-proven                      | Current verdict                                  |
| -------------------------- | --------------------------------------------------------- | ------------------------------------------ | ------------------------------------------------------------------------------------------------------ | -------------------------------------- | ------------------------------------------------ |
| Schema/data capacity       | Yes                                                       | Broadly                                    | Names: 145/145 tables, 5,231/5,231 columns; committed type baseline is 0, but live type proof can SKIP | No                                     | Strong foundation, not behavior proof            |
| Auth, sessions, RLS        | Yes                                                       | Broadly                                    | Web security tests, not desktop rights parity for every form                                           | No live audit                          | Retain as safe web improvement                   |
| Voucher creation           | 52/52 structural families                                 | Broad                                      | G5 red                                                                                                 | No                                     | Presence is high; semantics are not certified    |
| Voucher open               | 33/52                                                     | Incomplete                                 | No full-family proof                                                                                   | No                                     | Operator lifecycle gap                           |
| Voucher edit               | 23/52                                                     | Incomplete                                 | No full-family proof                                                                                   | No                                     | Operator lifecycle gap                           |
| Voucher delete/reversal    | 47/52                                                     | Broad but uneven                           | Audit/write-set equality unproved                                                                      | No                                     | Must verify persisted reversal and `DELETE_DATA` |
| Period/consumption locks   | 16/52                                                     | Incomplete                                 | No full matrix                                                                                         | No                                     | Unsafe correction risk                           |
| Automated structural tests | 45/52                                                     | Useful                                     | Not a desktop oracle                                                                                   | CI only                                | Necessary, insufficient                          |
| Tag opening                | Yes, full CRUD                                            | Partly                                     | Draft contract; edit loses rich fields                                                                 | No                                     | Partial                                          |
| Tag sale/return            | Yes                                                       | Strong exact-instance behavior             | Tested in web; not full desktop G5                                                                     | No                                     | Strongest tag segment                            |
| Tag split                  | Page/API exist                                            | No exact lineage                           | No                                                                                                     | No                                     | Unsafe partial implementation                    |
| Tag weight difference      | Page/API exist                                            | Simplified net adjustment                  | Explicitly diverges from desktop                                                                       | No                                     | Unsafe partial implementation                    |
| Tag cancel                 | Page/API exist                                            | Partial                                    | No open/edit or exact identity proof                                                                   | No                                     | Partial                                          |
| Tag transfer               | Page/API exist                                            | Partial                                    | No exact identity/open/edit proof                                                                      | No                                     | Partial                                          |
| Physical stock             | Full CRUD + reconcile                                     | Substantial                                | Desktop reset/counter behavior unproved                                                                | No hardware run                        | Partial                                          |
| Tag print                  | List/select/Code39 HTML                                   | Basic labels                               | No desktop template/output equality                                                                    | No printer proof                       | Partial                                          |
| Reports                    | Many routes/pages; 254 web baselines                      | Broad but with filter/heading/auth defects | **0 retained real data comparisons; 0 layout proofs**                                                  | No                                     | Major parity block                               |
| Contracts                  | 11 retained                                               | 3 approved                                 | 8 drafts contain 30 unenforced rules and 184 blank vectors                                             | No                                     | Major evidence block                             |
| Completion register        | 198 entries                                               | Register executes                          | 198 unclassified                                                                                       | No                                     | No completion claim possible                     |
| Backup/restore             | Route and module exist                                    | Unsafe for multi-company tenant            | No trustworthy drill for current logic                                                                 | No                                     | P0 blocker                                       |
| Devices/integrations       | Browser scanner input, WebSerial scale, camera, providers | Simulated/limited                          | No complete desktop device comparison                                                                  | No target-device/live-credential proof | P2 block                                         |

The retained structural lifecycle counts are measured at 2026-08-02:

```text
                 all 52 families       19 active families
CREATE                 52/52                  19/19
OPEN                   33/52                  17/19
EDIT                   23/52                   7/19
DELETE                 47/52                  19/19
LOCK                   16/52                   7/19
TESTED                 45/52                  19/19
```

“Active” is based on the retained reference dataset. Zero-volume families still require a desktop-derived
golden case or an explicit owner-approved exclusion.

## 4. Desktop invariants that the web must reproduce

### 4.1 Scope and identity

Runtime scope is company + location + fiscal year + book. A voucher is normally identified by:

```text
CO_CODE + LC_CODE + CO_YEAR + CO_BOOK + VCH_NO
```

Hidden voucher numbers, serial masters, persisted wall-clock values, original source references, and row serials
are part of the behavior. A URL ID or tenant ID is not an acceptable substitute for the desktop business key.

### 4.2 Rights and operator workflow

- `USER_SET` governs view, create/save, edit, delete, and print behavior.
- Forms are keyboard-first: Enter/Escape, F-keys, Ctrl+F-keys, row movement, and current-cell behavior matter.
- Barcode scanners act as keyboard input; duplicate and ambiguous scans must produce desktop-equivalent outcomes.
- Date, fiscal-year, close-date, rights, consumed-source, and downstream-use checks must execute before mutation.

### 4.3 Voucher truth is an atomic write set

A voucher is not one header row. Depending on family, desktop truth includes:

- header and detail tables;
- `AC_DATA` money/metal ledger legs;
- signed `MAIN_STOCK` movements;
- family-specific `ROJ_MEL_DATA` day-book rows;
- tax, outstanding, tender, order, scheme, manufacturing, image, and remark satellites;
- source flags and links;
- `TEMP_BOOK_DATA`/hidden identities;
- `USER_DATA` where applicable;
- `DELETE_DATA` and source restoration on reversal.

The transaction must either commit the entire set or commit nothing. `ROJ_MEL_DATA` is a domain-specific
money-and-metal day book, not a generic copy of `AC_DATA`.

### 4.4 Data conventions are behavior

Blank, zero, and NULL are not interchangeable. Neither are numeric and text column types. They affect joins,
`COUNT`, `AVG`, sorting, report formulas, and output formatting. The current committed
`web/scripts/type-parity-baseline.json` records **0** numeric-on-desktop/text-in-Postgres columns. That baseline
is not fresh release certification unless a real SQL Server type dump and live Postgres database are supplied;
the current gate can still emit `TYPE_PARITY_SKIP` and exit 0. Release certification must reject SKIP and must
fail on every new or unresolved mismatch rather than hide it by casting.

### 4.5 Exact report behavior

Parity includes query source, filters, sorting, grouping, formulas, page/section behavior, headings, copy type,
printer dimensions, barcode/QR encoding, and control totals. A deterministic web screenshot or checksum only
proves the web did not change relative to itself.

## 5. What should be retained from the web architecture

The objective is behavioral compatibility, not a literal port of desktop weaknesses. Keep these web-native
improvements when they do not change business semantics:

- secure password hashing, signed/expiring sessions, and fail-closed authentication;
- tenant isolation and forced PostgreSQL RLS;
- parameterized/validated data access and atomic database transactions;
- immutable audit events, request IDs, observability, and structured errors;
- optimistic or explicit concurrency controls where the desktop assumed one operator;
- job-scoped report/tag-print staging instead of global scratch-table deletion;
- database/object storage for images instead of a Windows share, while preserving desktop identity/indexes;
- browser WebSerial/camera APIs or a signed local bridge for unsupported hardware;
- fail-closed external-provider configuration and explicit sandbox/production modes;
- responsive UI and accessible visible alternatives to F-key shortcuts.

These are compatible improvements only if desktop calculations, write sets, rights outcomes, and operator-visible
results remain the same or the divergence is explicitly approved.

## 6. Prioritized gap register

### 6.1 P0 — release blockers and data-safety defects

| ID    | Gap and direct evidence                                                                                                                                                                                                                                                                                                                                         | Risk                                                                                   | Required action                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                | Exit evidence                                                                                                                                                                                                                                                                    |
| ----- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P0-01 | `ops/backup.ts` backs up only 53 allowlisted tables versus 170 Prisma models. Restore `clear` deletes every RLS-visible tenant row in each allowlisted table, not one company; thrown insert errors are swallowed and omitted from the result, while `ON CONFLICT DO NOTHING` no-ops are still counted as restored; binary values export as `"[binary]"`.       | Cross-company loss, incomplete backup, and false-success restore                       | Replace with a schema-derived, versioned manifest; include every tenant/company table and binary; require an explicit company key; validate document version/checksums; restore into staging; fail atomically on every rejected or no-op row; produce count/key/hash reconciliation. Until fixed, disable logical restore outside disposable environments.                                                                                                                                                     | Two-company destructive test proves restoring company 01 cannot change company 02; all manifest counts, keys, hashes, and image bytes match; a corrupt/conflicting row causes full rollback, non-zero status, and no false restored count.                                       |
| P0-02 | Generic XLSX route inherits **Sales Register** rights; generic CSV and filter routes inherit **Tag Estimate** rights regardless of requested slug (`routePolicy.ts`).                                                                                                                                                                                           | Unauthorized report disclosure or incorrect denial                                     | Resolve requested slug to its own desktop/report form before authorization. Do not authorize a generic route until slug validation and form mapping succeed.                                                                                                                                                                                                                                                                                                                                                   | Matrix test for every report slug and view/print right; cross-report negative tests return 403.                                                                                                                                                                                  |
| P0-03 | Data Repair comments say admin-only, but its routes are absent from `ADMIN_ONLY`; handlers merely call `guard(..., 'delete')`, which trusts the already-resolved delegated form right.                                                                                                                                                                          | Historical ledger/stock rewrite by an unintended delegate                              | Owner decides admin-only versus separately delegated maintenance role. Implement one explicit policy and require re-authentication, reason, preview hash, backup reference for destructive operations, and immutable audit.                                                                                                                                                                                                                                                                                    | Role matrix and negative tests; policy wording and code agree.                                                                                                                                                                                                                   |
| P0-04 | Literal `CASH`, `KASAR`, `ROUNDOFF`, `LABOUR`, `STKADJ`, and `WTDIFF` fallbacks remain across finance, sales, purchase, manufacturing, and tag modules.                                                                                                                                                                                                         | Valid-looking vouchers posted to wrong/nonexistent accounts                            | Resolve every posting account from `BOOK_DETL`, company settings, group/item configuration, or an owner-approved mapping. Fail before numbering/writes when absent or ambiguous.                                                                                                                                                                                                                                                                                                                               | Static rule rejects posting literals in production paths; database tests prove missing configuration rolls back with no serial consumption or rows.                                                                                                                              |
| P0-05 | Split, weight-difference, cancel, and transfer routes are operator-visible while their identity/write sets are incomplete.                                                                                                                                                                                                                                      | Orphan/duplicate tags, incorrect stock, unrecoverable lineage                          | Feature-flag or disable unsafe mutations until their P1 acceptance tests pass. Read-only inspection can remain.                                                                                                                                                                                                                                                                                                                                                                                                | Route-policy/feature-gate tests prove blocked status; re-enable only with signed evidence bundle.                                                                                                                                                                                |
| P0-06 | Tag Opening reopen returns only basic fields; edit deletes/recreates the full set, blanking rich desktop fields. Images are keyed with `imageRow + 1` rather than persisted `VCH_SRNO`; secondary hallmark IDs are numerically coerced in the page although server fields are strings.                                                                          | Silent data loss on edit and image/HUID misassociation                                 | Make create/get/update contracts symmetrical for every `BAR_DETL`/`BAR_IDTL` field; key images on exact persisted identity; preserve alphanumeric hallmark values; add read-before-write diff and consumed-tag lock.                                                                                                                                                                                                                                                                                           | Create rich tag → reopen → save unchanged is equivalent under the canonical comparison contract and retains the exact image identity; binary equality is required only for fields classified `binary-exact`, and no other column changes except explicitly allowed audit fields. |
| P0-07 | Main CI marks G5 `continue-on-error`; strict completion register and type parity are not main-job gates. Schema/type scripts can report SKIP with exit 0.                                                                                                                                                                                                       | Red or absent evidence can ship as green                                               | Separate developer CI from release certification. Release workflow must require fresh G5, `register:check --strict`, type parity with real inputs, schema readiness with live DB, report comparisons, restore drill, and no SKIP result.                                                                                                                                                                                                                                                                       | Protected release job cannot succeed on RED, SKIP, stale, synthetic, or missing evidence.                                                                                                                                                                                        |
| P0-08 | `web/apps/api/integration/cutover.mjs` uses a hard-coded partial table list, extracts source tables without company/year predicates, replaces all rows visible for the target tenant one table at a time, validates mainly numeric sums, and can report `passed` when tables are source-missing, target-missing, have no common columns, or are resume-skipped. | Cross-company/year mixing or deletion, incomplete migration, and a false green cutover | Disable production load mode. Generate a signed schema/mapping manifest in which every table declares ownership scope (`global`, company, company+location, company+year, image/external) and extraction predicates. Missing tables/columns, skips, rejected/truncated values, duplicate keys, row/key/binary mismatches, or unexplained differences must fail top-level status. Load an empty shadow target, reconcile, then promote atomically; never destructively replace an active tenant table-by-table. | Two-company/two-year destructive-isolation tests prove no out-of-scope read/delete; all required rows, keys, values, binaries, and hashes reconcile under one run ID; every missing/unmapped/skipped case exits non-zero; two clean shadow-load rehearsals match.                |

### 6.2 P1 — business-semantic parity

| ID    | Gap                                                                                                                                                                                                                                             | Required outcome                                                                                                                                                                                                                                            |
| ----- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P1-01 | G5 remains 0/66. Difference concentration: `PR_DETL` 1,257; `PR_DATA` 929; `MAIN_STOCK` 658 plus 22 missing rows; `RATE_CUT_ISU` 315; `RATE_CUT_DATA` 269; `ROJ_MEL_DATA` 236 plus 68 missing/38 extra; `AC_DATA` 101 plus 60 missing/32 extra. | Resolve differences from persisted desktop evidence, not patches to expected output. First make all 66 match; then replay all 1,567 real vouchers in dependency order and create desktop-derived fixtures for configured zero-volume families.              |
| P1-02 | Lifecycle is incomplete: 19/52 cannot open, 29/52 cannot edit, 5/52 cannot delete, and only 16/52 have structural lock evidence.                                                                                                                | Every in-scope menu action must support the desktop lifecycle, including reprint, period/right checks, downstream-consumption locks, exact edit preservation, reversal satellites, source-flag restoration, and delete audit.                               |
| P1-03 | Pure rate cut rejects empty lines, while 25/25 retained real rate-cut vouchers are header-only.                                                                                                                                                 | Owner approves header settlement semantics; post line-less vouchers from `FINE_RATE`, fine debit/credit, and money settlement with exact ledger/Rojmel/header rows. Wholesale detail vouchers remain a separate tested branch.                              |
| P1-04 | Tag lifecycle is not a coherent state machine; several modules operate on tag number alone or omit `VCH_SRNO`.                                                                                                                                  | Introduce one exact `TagIdentity`, a desktop-derived canonical transition model, and one availability/locking service used by opening, purchase, karigar, transfer, split, weight change, cancel, physical count, sale, return, reports, print, and images. |
| P1-05 | Report screen and exports can disagree: Excel serialization omits shared filters, lot, tag, and direction; heading selects the first company rather than current `coCode`.                                                                      | One canonical report request object must feed screen, CSV, XLSX, HTML/PDF, staging, and comparison. Company is selected by exact scope.                                                                                                                     |
| P1-06 | 254 report baselines prove only deterministic web rendering; `project-memory/parity/reports` contains no real comparison artifact.                                                                                                              | Compare each in-scope desktop report’s data/control totals and required layout/output against the same scope and filters. No report is “verified” without retained desktop evidence.                                                                        |
| P1-07 | Only 3/11 contracts are approved. Eight drafts contain 30 `NOT ENFORCED` validations and 184 blank golden-vector cells.                                                                                                                         | Complete contracts for all active/high-risk forms, then all in-scope forms. Every rule is implemented, tested, or signed as a divergence; every formula has a golden vector.                                                                                |
| P1-08 | Static write-column coverage is 98.9%, but four desktop-written tables lack web writes and static presence does not prove values/order.                                                                                                         | Close missing tables only from actual write-set evidence; assert ordered, atomic write sets and exact field values in replay tests.                                                                                                                         |
| P1-09 | Standalone HUID/statutory/report scope is incomplete or unclassified. HUID capture/labels exist, but a desktop-equivalent HUID register was not found; UAE VAT and dedicated TCS/TDS outputs were not found in current web code.                | Classify each of the 198 menu items. Build and prove required India/UAE/HUID/TCS/TDS outputs or obtain an explicit scope exclusion with business/legal owner sign-off.                                                                                      |
| P1-10 | Rights are not yet certified desktop-equivalent for every form/action.                                                                                                                                                                          | Generate a route/action policy from the approved menu/form map and test every role × action. Security hardening may be stricter only with owner approval and a workable operator role.                                                                      |

### 6.3 P2 — operator fidelity and production proof

| ID    | Gap                                                                                                                                                                       | Required outcome                                                                                                                                                                                                        |
| ----- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P2-01 | About 3,333/4,555 desktop controls are represented (73.2%). A narrower 496-field audit reports 100% capturable but excludes no-page families and is not behavioral proof. | Complete field/order/visibility/readonly/branch mapping by menu action; prioritize active forms and current-row behavior rather than raw widget count.                                                                  |
| P2-02 | Shared F-key/grid helpers exist, but per-form keyboard, focus, scanner, duplicate-scan, escape, and confirmation behavior is not certified.                               | Browser tests and operator UAT reproduce each approved form contract on the shop’s keyboard/scanner workflow.                                                                                                           |
| P2-03 | Scale and camera support exist; physical stock and tag images are not target-hardware certified.                                                                          | Test each supported scale profile, negative-sign decision, scanner, camera, label printer, QR/barcode scan-back, browser, and fallback bridge on real devices.                                                          |
| P2-04 | External integrations are not live-proven.                                                                                                                                | Run sandbox and production-readiness tests for e-invoice, notifications/WhatsApp, rates, and any bank/GSP integration using owner-provided credentials; fail closed when unavailable.                                   |
| P2-05 | Multi-user scratch-table and serial behavior is not fully safe.                                                                                                           | Concurrency tests cover voucher numbering, tag allocation, double sale, split/cancel races, report staging, print jobs, and image updates.                                                                              |
| P2-06 | No production performance/error-budget proof.                                                                                                                             | Establish representative dataset and concurrency profiles; meet owner-approved p95/p99 latency, throughput, timeout, and zero-partial-write criteria.                                                                   |
| P2-07 | Migration, disaster recovery, pilot, and rollback/forward recovery are not certified.                                                                                     | Complete two-company/multi-year migration rehearsals, immutable backups, point-in-time recovery, restore drills, accounting reconciliation, read-only parallel validation, cutover, and the selected recovery strategy. |

## 7. Complete jewellery tag lifecycle parity matrix

A tag’s identity is not `TAG_NO` alone. The compatibility identity must preserve at least tenant, company,
location, `TAG_NO`, `VCH_SRNO`, and item/source lineage. Voucher keys and image identity remain attached.

| Lifecycle stage                  | Desktop-required behavior                                                                                                                                                            | Current web state                                                                                                                                                                                                | Exact-parity work and proof                                                                                                                                                                                                          |
| -------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Identity allocation              | Allocate from `SRNO_MAST.TAG_SRNO`; preserve serial and generated/manual tag rules.                                                                                                  | Implemented in Tag Opening, purchase, and karigar paths.                                                                                                                                                         | Centralize allocator/lock; prove rollback does not leak or duplicate identities and manual tag still receives the correct serial.                                                                                                    |
| Opening (`TR_TAG_OPBL`)          | `BAR_DATA` + rich `BAR_DETL` + `BAR_IDTL` + signed `MAIN_STOCK` IN; optional loose-stock relief; no money ledger; full rights/date/open/edit/delete behavior.                        | Strong create/full CRUD, but reopen omits rich fields and images use row index. Draft contract has 8 unenforced validations and 33 blank vectors.                                                                | Symmetric DTO, every grid/sub-grid field, exact image key, print branch, validations, locks, unchanged round-trip, desktop DB diff.                                                                                                  |
| Purchase tagging                 | Inline/manual/generated tag, full purchase lineage, `BAR_DETL`/`BAR_IDTL`, signed stock, voucher satellites; “Only Tag Entry” behavior where configured.                             | Tag creation and exact serial allocation exist; purchase lifecycle is broad and tested. Full desktop field/output parity remains red in G5.                                                                      | Separate and test normal purchase, only-tag, stone/HUID, edit, delete, consumed-tag lock, and image paths against desktop cases.                                                                                                     |
| Karigar receipt tagging          | Finished ornament becomes exact tag identity with source job/karigar detail and stock.                                                                                               | `BAR_DETL` and `MAIN_STOCK` tag creation exists. Full detail/image/write-set parity is not certified.                                                                                                            | Map `BAR_IDTL`/stone/job/order fields and source flags; compare karigar receipt → tag → sale chain.                                                                                                                                  |
| Print/reprint (`UT_TAG_PRINT`)   | Select live on-hand instances; template selection; barcode/QR; HUID, labour, MRP and configured updates; label skip; exact printer output.                                           | Basic list/select and Code39 HTML; staging endpoint and label-skip support exist. UI selects by tag number only, bypasses staging, has no desktop template/update lifecycle, and staging clears all tenant rows. | Add immutable print-job ID and exact tag identity; copy desktop template parameters; QR/barcode scan-back; HUID/labour/MRP update rules; normal Tag Print role; concurrent jobs cannot interfere; compare output dimensions/content. |
| Transfer (`TR_INOUT`)            | Exact tag OUT plus target bulk/item IN, metal conservation, no money ledger, full voucher lifecycle and identity.                                                                    | Creates/deletes `MAIN_STOCK`; no open/edit; no exact `VCH_SRNO`; source lookup can choose by tag only.                                                                                                           | Resolve/lock exact live instance, persist serial on both relevant legs, implement open/edit/delete/locks/audit and compare conserved pieces/gross/net/fine.                                                                          |
| Split (`TR_TAG_SPLIT`)           | Consume exact parent; allocate child serials; create child `BAR_DETL`/`BAR_IDTL`; copy/adjust detail and images; preserve parent/child lineage; enforce desktop rounding/absorption. | Only parent OUT/child IN `MAIN_STOCK`; child tags must be manually supplied and UI even looks them up as existing tags; no barcode detail, serial, image, open/edit, or lock.                                    | Rebuild around parent snapshot + child allocation. Atomic parent consume, child detail/sub-detail/image creation, lineage table/audit, rounding decision, open/edit/delete, concurrent-sale lock, and desktop diff.                  |
| Weight change (`TR_TAG_WT_DIFF`) | Full old/new tag fields, possible new identity, delete/recreate detail, images, stock, optional accounting, Rojmel, karigar and serial cleanup branches.                             | Source explicitly calls its model a simplified net-difference implementation; writes `MAIN_STOCK` and `AC_DATA` only; no detail/image/Rojmel replacement or open/edit.                                           | Replace with desktop branch matrix. Preserve old snapshot and `NEW_VCH_SRNO`; update/copy images; exact `BAR_DETL`/`BAR_IDTL`, stock, ledger/Rojmel and karigar rows; fail closed on account config.                                 |
| Cancel (`TR_TAG_CAN`)            | Exact live identity; rich cancel header/detail/sub-detail; signed stock OUT; generally no money ledger; open/edit/delete, rights/date and downstream checks.                         | Backend writes `BAR_CAN_*`, but UI omits bag/lot/transfer/stone data; `VCH_SRNO` is not preserved correctly; availability checks any historical OUT by tag; no open/edit.                                        | Use net exact-instance availability, copy persisted source rather than trust typed weights, preserve `VCH_SRNO`, expose full UI/sub-grid, implement open/edit/locks/audit and compare.                                               |
| Physical stock (`TR_PHYSTK`)     | Scan exact identities, reject duplicates visibly, reset/count/counter branches, persisted voucher lifecycle and classifications.                                                     | Full CRUD, exact-instance list/reconcile, paging and count evidence. Repeated UI scan is silently idempotent; image row is never selected; desktop reset/counter movement branches are unproved.                 | Implement approved reset/counter semantics, duplicate message, current-row image identity, scanner focus, reopen/edit/delete locks, and desktop count/classification comparison.                                                     |
| Sale                             | Validate exact live instance; atomically issue signed stock OUT; reject ambiguity and concurrent double sale; copy tag costing/detail.                                               | Strong: `issueTagTx` locks exact identity, sale rows carry `VCH_SRNO`, and database tests cover concurrent double issue.                                                                                         | Include in dependency-ordered G5, verify all desktop copied fields, rights, returns, edits/deletes, report and image consequences.                                                                                                   |
| Sale return                      | Validate original sale/customer/scope; preserve configured old/new tag behavior and exact lineage; re-admit once.                                                                    | Strong exact original-sale validation and signed stock IN. It restores the same identity; configured old/new behavior is not established.                                                                        | Owner decides old/new identity rule per setting. Test return once, duplicate return, resale, return edit/delete, image and print behavior against desktop.                                                                           |
| Images                           | Identity follows tag through create, split/change, sale/return and deletion rules.                                                                                                   | Secure database image storage and `TAG_IMAGE_DATA` index exist. Split/weight/cancel do not migrate lineage; several pages pass row index instead of serial.                                                      | One image-lineage service keyed on exact tag identity; explicit copy/move/retain/delete rules per operation; migration preserves bytes and index; end-to-end image checks.                                                           |

### 7.1 Tag invariants

These invariants become database constraints, transactional assertions, and replay checks where feasible:

1. A live tag identity is unambiguous for company/location/tag/serial/item.
2. A serial is allocated once; rollback cannot expose a partially created identity.
3. Signed on-hand balance per exact identity is only 0 or 1 unless a documented desktop branch permits otherwise.
4. Sale, transfer, split, weight replacement, and cancel serialize on the same identity lock.
5. Parent split OUT equals children IN for owner-approved pieces/gross/net/fine tolerances or posts the exact
   desktop absorption branch.
6. Tag transfer conserves the desktop measures between tag OUT and target IN.
7. A sold tag cannot be sold, split, transferred, changed, or cancelled concurrently.
8. A return must reference one original issue and can re-admit it only once.
9. Every `MAIN_STOCK` tag movement can join to its provenance and, where required, `BAR_DETL`/`BAR_IDTL`.
10. Images, HUIDs, sub-details, source voucher, and order/manufacturing links survive the approved lineage rules.
11. Delete/edit restores the complete prior state or fails before any mutation.
12. Concurrent print jobs and reports never share mutable staging rows.

### 7.2 Canonical tag transition model

Derive and approve a versioned state/transition table from desktop code, persisted rows, and observed workflows
for one exact `TagIdentity`; `TAG_NO` alone is never a key. For every state and transition record the persisted
state derivation, pre-state, exact identity, rights/date/configuration guards, deterministic locks, complete
ordered write/accounting/Rojmel set, image/HUID/lineage behavior, post-state, downstream legal transitions,
reversal rules, and terminality. Print status, physical-count observation, image/HUID presence, and report
inclusion must be classified explicitly as state or orthogonal facets. Generate tests for every approved edge
and prove every other edge fails atomically under concurrency. Do not invent fixed state names or terminal
semantics until desktop evidence and owner decisions establish them.

## 8. Compatibility decisions: reproduce, improve, or decide

| Category                                                                                                                                                                              | Treatment                                                                                                                      |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| Business keys, calculations, rounding, signs, write sets, joins, rights outcomes, lifecycle, keyboard/scanner flow, reports, labels, and tag lineage                                  | **Must reproduce** unless an explicit divergence is approved.                                                                  |
| Password/session security, RLS, atomic transactions, audit detail, request IDs, observability, object storage, job-scoped staging, provider fail-closed behavior, browser device APIs | **May improve safely** if business/output semantics remain unchanged.                                                          |
| Known desktop defects, historical unbalanced rows, ambiguous calculations, unsafe global scratch deletion                                                                             | **Do not copy silently.** Measure, document user-visible consequence, obtain owner/accountant decision, and test the decision. |

### 8.1 Owner decisions required before affected work is accepted

1. Header-only pure rate-cut posting and exact ledger/Rojmel derivation.
2. Old-tag versus new-tag identity on sale return and each relevant company setting.
3. Split conservation tolerance, rounding order, and any absorbing account/item branch.
4. Scale negative-sign behavior: preserve desktop sign dropping or correct it with operator warning.
5. Whether Data Repair is super-admin only or a separately delegated maintenance privilege.
6. Which desktop defects/historical imbalances must be reproduced, corrected prospectively, or migrated as-is.
7. Report priority and acceptable pixel/position tolerance where Crystal and browser fonts/printers differ.
8. HUID, TCS/TDS, UAE VAT, tour, dhiran, prior-year, and unused/configured family scope.
9. Supported browsers, scanners, scales, cameras, label printers, paper/label templates, and local bridge policy.
10. Whether disconnected browser operation is a new product requirement.
11. Canonical comparator mappings, exact/binary/tolerance rules, approved-divergence review/expiry, and evidence
    freshness.
12. Source-system and migration boundaries, including global/company/location/year ownership for every table.
13. Numeric RPO/RTO, maximum write-freeze/downtime and abort threshold, point of no return, and post-write
    rollback versus forward-recovery strategy.
14. Go/no-go/abort authority and quorum, pilot scope and stop/promote rules, and hypercare thresholds/exit.
15. Performance SLOs, representative data volume, peak concurrency, and error budget.
16. Security risk-acceptance authority and evidence, audit, log, backup, and customer-data retention periods.

The desktop is “offline” because it uses local/LAN SQL Server. No true offline synchronization queue was found
as a desktop behavior. A PWA queue, conflict resolver, and bidirectional sync protocol are **new scope**, not
parity, unless the owner explicitly requires them.

## 9. Target compatibility architecture

Do not continue implementing each form as unrelated page logic. Introduce shared compatibility primitives and
make every workflow use them.

### 9.1 Core types/services

```text
BusinessScope       tenant + company + location + fiscal year + book
VoucherIdentity     scope + VCH_NO + hidden number + persisted clock/user
TagIdentity         company + location + TAG_NO + VCH_SRNO + item + provenance
FormAction          view/create/update/delete/print with USER_SET-compatible outcome
PostingPlan         ordered header/detail/ledger/stock/Rojmel/satellite writes
ReversalPlan        persisted-state-derived deletion, source restoration and DELETE_DATA
ReportRequest       exact scope + dates + all shared/special filters + format + copy/template
PrintJob            immutable job id + exact tag instances + template + printer parameters
EvidenceBundle      input, desktop output, web output, diff, versions, operator and timestamp
```

### 9.2 Posting flow

1. Resolve authenticated `BusinessScope`; reject missing/ambiguous company/location/year/book.
2. Resolve form right and action.
3. Resolve book classification and every required account/configuration; no posting literals.
4. Validate fiscal/close dates and source/downstream locks.
5. Lock voucher/tag/source identities in deterministic order.
6. Compute a pure `PostingPlan` using exact decimal/rounding/default conventions.
7. Validate ledger balance, stock/metal conservation, uniqueness, and required satellites.
8. Execute the complete ordered write set in one transaction.
9. Read back persisted state and assert invariant/control totals.
10. Emit audit/evidence metadata only after commit.

Edit and delete must be derived from the persisted prior write set, never from a new client payload alone.

### 9.3 Migration architecture

Use a repeatable SQL Server extract → immutable raw archive → canonical staging model → validated transform →
empty shadow Postgres load → reconciliation → atomic promotion pipeline. Preserve original keys and maintain an
explicit source-to-target key map. Every table has an ownership scope and extraction predicate. Missing,
unmapped, skipped, truncated, duplicated, or non-reconciling data fails the run. Do not make the live desktop
database and the web database writable masters at the same time without a designed sync protocol. The current
`web/apps/api/integration/cutover.mjs` production load path **must be disabled** until P0-08 passes; current source has no production-disable guard and defaults to load mode unless `--dry-run` is supplied.

### 9.4 Frozen report and output inventory

Publish a versioned manifest mapping every report-capable menu action, form mode, and report button to its
desktop query/procedure, `.rpt` template, copy type, filters/parameters, company/language variant, page/media
geometry, barcode/QR/HUID behavior, and web screen/CSV/XLSX/PDF/print slug. Form, template, slug, variant, and
254 web-baseline counts are distinct measures and must be reconciled rather than substituted for one another.
Freeze the inventory count and content hash at scope approval. A row leaves scope only through a signed
exclusion naming its business/legal consequence. WP-13 passes only when every in-scope row has same-request
data/detail/control-total evidence and each required output variant has retained geometry/visual/scan evidence.

## 10. Ordered implementation work packages

| WP     | Priority | Work                                                                                                                                                                                                                                                                     | Dependencies                                                                     | Exit criterion                                                                                                                                                                          |
| ------ | -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| WP-00  | P0       | Freeze scope and record every §8.1 business, accounting, comparator, migration, recovery, report, hardware, security, performance, pilot, and retention decision.                                                                                                        | None                                                                             | Every decision has a named accountable owner, due date, selected value, evidence/decision-record link, and explicit blocked-work list; undecided values do not pass.                    |
| WP-01  | P0       | Immediately disable logical restore, production migration load, and every mutation known to lose or invent state, including Tag Split, Tag Weight Difference, Tag Cancel/Transfer, and Tag Opening update; preserve read-only inspection and publish an operator notice. | None                                                                             | Negative route/feature-gate tests prove blocking.                                                                                                                                       |
| WP-02  | P0       | Repair backup/restore, generic report authorization, Data Repair authority, posting-account resolution.                                                                                                                                                                  | WP-00                                                                            | All P0-01 through P0-04 acceptance evidence green.                                                                                                                                      |
| WP-03  | P0       | Make release certification fail on RED, SKIP, stale, synthetic, unclassified, or missing evidence.                                                                                                                                                                       | None                                                                             | Protected release workflow remains red until every downstream evidence gate is complete and fresh.                                                                                      |
| WP-04  | P1       | Classify all 198 menu entries: exact web surface, state, scope, dependency, contract, test, evidence.                                                                                                                                                                    | WP-03                                                                            | `pnpm register:check --strict` passes; zero unclassified.                                                                                                                               |
| WP-05  | P1       | Complete source contracts and decisioned divergences, prioritizing active/high-risk families without reducing final scope.                                                                                                                                               | WP-04                                                                            | Every in-scope menu action has an approved contract; every validation/vector cell is implemented and tested or covered by a signed divergence; zero blank or `NOT ENFORCED` cells pass. |
| WP-06  | P1       | Compatibility kernel: scope, rights, book/account resolution, serials, dates/locks, decimal/rounding, defaults, posting/reversal plans.                                                                                                                                  | WP-02, WP-05                                                                     | Shared conformance suite is used by every in-scope posting family; no module-local posting fallback.                                                                                    |
| WP-07  | P1       | Exact tag identity/availability/locking/image kernel and desktop-derived transition model.                                                                                                                                                                               | WP-06                                                                            | Tag invariants 1–12 and every approved §7.2 edge are enforced/tested under concurrency; all other edges fail atomically.                                                                |
| WP-08  | P1       | Tag Opening, purchase tagging, karigar tagging round-trip completion.                                                                                                                                                                                                    | **[dependencies cell destroyed by an editing error on 2026-08-30 — see §17.10]** | **[exit-criterion cell destroyed by the same error — see §17.10]**                                                                                                                      |
| WP-09  | P1       | Rebuild split, weight difference, cancel, and transfer; add full lifecycle.                                                                                                                                                                                              | WP-07, owner decisions                                                           | Every branch matches desktop DB diff; routes can be safely re-enabled.                                                                                                                  |
| WP-10  | P1       | Rebuild Tag Print and complete Physical Stock; job-scoped staging and real templates/devices.                                                                                                                                                                            | WP-07                                                                            | Concurrent label jobs isolated; scan-back and physical-stock desktop scenarios pass.                                                                                                    |
| WP-11A | P1       | Clear the current 66 G5 purchase/wholesale cases.                                                                                                                                                                                                                        | WP-06                                                                            | 66/66 cases match under the signed comparator manifest with zero unexplained differences, missing rows, or extra rows.                                                                  |
| WP-12  | P1       | Complete lifecycle/locks for all in-scope zero-volume and active families; header-only rate cut.                                                                                                                                                                         | WP-05, WP-06                                                                     | Family matrix is 100% for required actions; desktop-derived zero-volume scenarios pass.                                                                                                 |
| WP-11B | P1       | Replay all 1,567 retained vouchers in dependency order after the owning tag and lifecycle work is complete.                                                                                                                                                              | WP-08, WP-09, WP-10, WP-11A, WP-12                                               | 1,567/1,567 retained vouchers have zero unexplained differences, missing rows, or extra rows under the signed comparator manifest.                                                      |
| WP-13  | P1       | Reports/statutory parity: frozen §9.4 inventory, canonical request, per-slug rights, data comparison, Crystal layout/output, and HUID/GST/TCS/TDS/UAE decisions.                                                                                                         | WP-04, WP-06                                                                     | Every in-scope manifest row has same-request detail/control-total proof and every required output variant has approved layout/geometry/visual/scan evidence.                            |
| WP-14A | P1       | Build the immutable, scope-safe extract/staging/shadow-load and reconciliation framework.                                                                                                                                                                                | WP-03, WP-04, WP-06                                                              | Repeatable two-company/two-year shadow loads are complete, non-destructive, completeness-failing, and hash-reconciled.                                                                  |
| WP-14B | P2       | Complete release migration, accounting reconciliation, DR, restore, promotion, and selected recovery rehearsals.                                                                                                                                                         | WP-08, WP-09, WP-10, WP-11A, WP-11B, WP-12, WP-13, WP-14A                        | Two clean full rehearsals produce identical signed results within RPO/RTO, including zero lost/duplicate/partial events.                                                                |
| WP-15  | P2       | Security certification, hardware/integrations, concurrency/load, operator UAT, pilot, cutover, and hypercare.                                                                                                                                                            | WP-14B and all release gates                                                     | Approval references one release evidence bundle and immutable cutover run ID; all §11/§12 production gates pass.                                                                        |

Work packages are gates, not calendar promises. WP-01 and WP-03 start immediately and do not wait for business
decisions. Schedule dependent P1/P2 work only after WP-00 records selected values, scope, capacity, hardware,
and decision evidence.

## 11. Validation and certification model

### 11.1 Required evidence layers

1. **Pure vectors:** exact formulas, rounding order, defaults, validation messages, identity transitions.
2. **Restricted-role DB tests:** complete write/reversal plans under RLS and real migrations.
3. **API lifecycle tests:** create → open → unchanged edit → changed edit → print → delete, including locks.
4. **Browser tests:** focus/tab/F-key/grid/scanner/error recovery and all visible conditional branches.
5. **Concurrency tests:** same voucher serial, same tag, print/report staging, edit/delete races.
6. **Desktop differential tests:** same input and configuration, field-by-field database and report comparison.
7. **Migration/production tests:** real volume, two companies, multiple years, devices, providers, backup/restore,
   monitoring, rollback.

### 11.1.1 Canonical comparison contract

Retain a signed, versioned comparator manifest that freezes the catalog/scope profile, union table set, row
keys/order, compared columns, SQL Server/PostgreSQL type mappings, decimal scales/rounding, date/time-zone
handling, case/whitespace treatment, NULL/blank/zero semantics, binary rules, web-only and desktop-only data,
approved transformations, and every allowed divergence with owner, reason, user-visible consequence, test, and
review/expiry date. The differ fails on every unclassified table, row, or column and reports exact matches
separately from approved divergences.

A gate passes only with zero unexplained differences, zero unclassified missing/extra rows or columns, and zero
silent exclusions under that manifest. “100% matched” means every required comparison is exact or explicitly
approved; byte equality applies only to fields classified `binary-exact`.

### 11.2 Full-application exact-parity acceptance

All conditions are mandatory unless an owner-signed scope exclusion names the user-visible consequence.

- **Scope:** 198/198 catalog entries classified with zero `unclassified`; the frozen release profile records
  all 198 visibility predicates/results and hash. Every evaluated-visible entry is verified or mapped; every
  hidden, excluded, or dead entry has evidence and an owner-signed business/legal consequence.
- **Contracts:** every in-scope menu action, including zero-volume/configured actions, has an approved behavior
  contract covering reachability, fields/defaults, validations/messages, rights, applicable lifecycle/report
  actions, locks, settings branches, ordered write/reversal sets, accounting/stock/tag effects, and golden
  vectors. Active/high-risk status controls order only; no blank or `NOT ENFORCED` cell can pass.
- **Lifecycle:** every required family supports view/create/open/edit/delete/print and desktop-equivalent locks,
  or its approved contract states why an action does not apply.
- **Real vouchers:** all 1,567 retained vouchers across 40 books replay in dependency order. Under the signed
  comparator manifest there are zero unexplained field differences, zero unclassified missing/extra rows or
  columns, and zero silent exclusions; exact matches and approved divergences are reported separately. The
  manifest distinguishes the 94-table voucher-scoped census from the retained vouchers' 44-table observed union.
- **Zero-volume scope:** at least one desktop-derived golden scenario per configured in-scope family/branch not
  represented in the retained voucher set.
- **Schema/types:** all required tables/columns/types/default/nullability/keys agree or have a signed migration
  compatibility decision; type/schema gates actually run and do not SKIP.
- **Reports:** every row of the frozen §9.4 manifest matches desktop detail rows, sort/grouping, formulas, and
  control totals for the same request; each required screen/CSV/XLSX/PDF/print/template/copy variant passes its
  approved geometry/visual/scan evidence. Form, template, slug, variant, and baseline counts are reconciled.
- **Rights:** every menu/form action has positive and negative role tests for view/create/update/delete/print;
  no generic route authorizes via an unrelated form.
- **Atomicity:** fault injection at each write-set stage leaves zero partial voucher/tag/report state and does
  not leak a business serial.
- **Migration and accounting reconciliation:** for every migrated company, location, fiscal year, book, and
  approved control date, reconcile row/key detail and a signed control pack: opening/closing trial balance by
  account; general ledger and party/subledger movement; balance sheet and P&L; cash/bank and Rojmel money/metal
  totals; bill-wise outstanding/aging; applicable GST/TCS/TDS/e-invoice/HUID controls; stock pieces/quantity/
  gross/net/fine/value by item/metal/location; exact live tag identities/status; in-scope karigar, scheme/member,
  and dhiran balances; opening/prior-year carry-forward; voucher/tag/hidden serial maxima; users/rights;
  images/binaries; and the approved historical-imbalance set. Detail populations must reconcile so offsetting
  errors cannot pass. Tolerance is zero after canonicalization unless a signed control-specific decision records
  value, reason, consequence, and owner. Business-accounting and technical-migration owners sign the same pack.
- **DR:** encrypted backup, point-in-time recovery, logical/company restore, and full restore meet agreed RPO/RTO;
  restored results pass the same reconciliation.
- **Performance/concurrency:** owner-approved p95/p99 and throughput targets pass at peak operator concurrency;
  no duplicate voucher/tag or cross-job staging interference.
- **Production integrations:** real-provider readiness passes with production-equivalent configuration;
  unavailable providers fail closed, and queued/in-flight external effects have defined cutover/recovery handling.
- **Hardware support matrix:** freeze and sign supported OS/browser/workstation combinations; scale model/firmware/
  driver/adapter/serial framing/capacity/precision/calibration; scanner/camera model and mode; printer model/
  driver/DPI/media; required templates; and WebSerial/WebUSB/local-bridge path. Certify 100% of matrix rows on
  target-site physical devices, including reconnect, permission denial, malformed/stale/out-of-range readings,
  fallback, output dimensions/readability, barcode/QR scan-back, concurrency, and recovery. Unsupported
  combinations are blocked or explicitly declared.
- **Security certification:** from the release commit generate a signed SBOM; run secret/history, SAST,
  dependency/license, container, and IaC scans; verify deployed TLS/headers; test CSRF/CORS/origin, session
  expiry/revocation, authentication lockout/reset, trusted-proxy/distributed rate limits, tenant/RLS isolation,
  per-action RBAC, audit failure, file/image/PDF handling, backup encryption/restore authorization, log/PII
  retention/redaction, key rotation, and incident response; and complete an authorized independent penetration
  test on a production-equivalent deployment. Release requires zero unresolved exploitable critical/high
  findings; accepted lower risks require owner, compensating control, ticket, due date, and remediation retest.
- **Freshness:** final evidence is generated from the release commit and production-equivalent migrations within
  the owner-approved freshness window.

### 11.3 Tag-specific certification suite

Use branching scenarios rather than one impossible linear sequence after a terminal action:

1. Create equivalent tags through opening, purchase, only-tag entry, and karigar receipt.
2. Reopen and save unchanged; compare all details/sub-details/images and serials.
3. Print/reprint the same exact instances with each required template, QR/barcode/HUID branch, and label skip;
   scan every output back to the expected identity.
4. Transfer one tag to bulk and prove pieces/gross/net/fine conservation, lifecycle, and reversal.
5. Split one parent into children; prove serial allocation, full copied/adjusted details, images, lineage,
   conservation, and parent unavailability.
6. Run every weight-change branch: same/new identity, increase/decrease, image behavior, accounting/Rojmel,
   karigar and absorption.
7. Cancel an eligible tag with stones/bag/lot/transfer fields; prove exact cancel register, stock and reversal.
8. Physical-count available tags using scan, duplicate scan, reset and counter branches; compare classifications.
9. Sell an exact instance; concurrently attempt a second sale/split/cancel and prove only one commits.
10. Return against the original sale under each approved old/new-tag setting; reject wrong customer, duplicate
    return, and ambiguous identity; then resell and test return edit/delete locks.
11. Repeat critical scenarios with two users, two companies, two locations, and reused tag text with different
    `VCH_SRNO` values.
12. For every stage, compare desktop/web table names, row keys, row counts, every material column, NULL/blank/zero,
    serial state, reports, and printed output under §11.1.1. Every required comparison must be classified, with
    zero unexplained differences and zero silent exclusions; report exact matches and approved divergences
    separately, and require bytes only where the manifest says `binary-exact`.

## 12. Migration, pilot, and cutover

### 12.1 Rehearsal sequence

1. Freeze source schema/version inventory and hash raw SQL Server databases, reports, images, and configuration.
2. Extract immutable raw data without transforming it.
3. Run profiling: duplicates, orphan keys, invalid dates/numbers, unbalanced vouchers, reused tag numbers,
   missing images/accounts, serial maxima, and historical desktop anomalies.
4. Transform through versioned mappings; never repair silently. Every repair has source key, rule, owner decision,
   before/after value, and audit record.
5. Load a clean production-equivalent Postgres database through normal migration/roles/RLS setup.
6. Run reconciliation controls and all parity suites.
7. Conduct operator UAT by business cycle, not by isolated page.
8. Repeat from scratch; two consecutive rehearsals must produce the same signed result.

### 12.2 Cutover sequence

1. Open one immutable cutover run ID and confirm current release evidence, approved run sheet, sign-off quorum,
   maximum downtime, and no-go checklist.
2. Drain active desktop transactions plus report, print, message, and external-provider jobs; define treatment of
   every in-flight request and block new sessions.
3. Enforce desktop read-only at the database/application boundary; record final voucher/tag/hidden serial maxima,
   source transaction watermark, and proof that no later write occurred.
4. Create and verify the final desktop backup plus an independent immutable copy.
5. Extract and load an idempotent delta with explicit inclusive-lower/exclusive-upper bounds into the shadow
   target. Do not dual-write without a designed protocol.
6. Run the signed accounting/data reconciliation pack and owner/accountant control reports.
7. Smoke test login/scope, opening balances, sale/purchase, tag lookup/print/sale/return, Rojmel, tax, reports,
   users/rights, integrations, security controls, and backup.
8. Obtain business, accounting, technical, security, and operations sign-off before opening web writes; record
   the point of no return.
9. Keep desktop read-only for the approved retention period; monitor and reconcile daily during hypercare.

### 12.2.1 Cutover control record

Every cutover uses one immutable run ID and approved run sheet. For each step record command/version, operator,
approver, start/end UTC, expected/actual duration, artifact URI/hash, pass rule, abort rule, and rollback or
forward-recovery action. Freeze the maximum downtime, evidence freshness, DNS/cache plan, smoke dataset, delta
watermarks, and sign-off quorum. Missing evidence, an exceeded downtime/abort threshold, any post-watermark
source write, or a failed mandatory checkpoint is an automatic no-go.

### 12.3 Rollback boundary and transaction disposition

Record a point of no return. Before web writes are enabled, rollback discards the target attempt and reopens the
unchanged desktop source; no business event may exist only in the web. After web writes begin, rollback to the
desktop is allowed only when a rehearsed automated web-to-desktop delta process captures and reconciles every
committed voucher, serial, tag transition, image, audit reference, job, and provider result within the approved
RPO. Otherwise post-write rollback is prohibited: stop writes, preserve database/log/evidence, invoke incident
response, and execute the approved forward-recovery plan.

The decision record fixes the rollback window, numeric RPO/RTO, point-of-no-return authority, in-flight
request/job/provider treatment, and selected recovery strategy. A representative-volume timed rehearsal must
prove zero lost, duplicated, or partial events. “Continue and fix later” is never acceptable for silent
accounting, stock, authorization, migration-scope, or tag-lineage errors.

## 13. Required people, access, and inputs

- Product/business owner able to approve scope and divergences.
- Senior counter operator for keyboard, scanner, tag, print, return, and correction UAT.
- Accountant/CA or designated accounting owner for ledger, Rojmel, rate-cut, tax, TCS/TDS, and historical
  imbalance decisions.
- Desktop subject-matter engineer with decompiled-source/SQL/report knowledge.
- Web/API/database engineers and independent QA/parity reviewer.
- Operations/security owner for RLS, authorization, secrets, monitoring, backup/restore, and cutover.
- Access to the authoritative desktop build, real SQL Server datasets, Crystal runtime/export capability,
  all required label/report templates, and image stores.
- Target scanners, scales, cameras, label/document printers, labels/paper, supported browsers/workstations.
- Sandbox and production-readiness credentials for every external provider.
- Sanitized production-scale staging data or approved secure local environment; no project/customer data sent
  to third parties.

## 14. Definition of done and current no-go conditions

### Definition of done

The web can replace the desktop only when every §11.2 condition passes from the release commit, the tag suite
passes, migration and the selected rollback/forward-recovery strategy have been rehearsed twice, and business,
accounting, technical, security, and operations owners sign the same evidence bundle and cutover run sheet.
“Implemented-unverified” is not done.

### Current no-go conditions

Any one is sufficient to block production cutover; all are currently present:

- logical backup/restore can clear another company in the tenant, omit most tables, lose binaries, swallow
  rejected rows, and count conflict/no-op inserts as restored;
- report authorization is not resolved per requested slug;
- Data Repair authority is inconsistent between comments and policy;
- literal posting account fallbacks remain;
- unsafe partial tag mutation routes are exposed;
- Tag Opening can lose rich fields/images/HUID identity on edit;
- G5 is 0/66 and stale relative to this plan;
- 198/198 menu entries are unclassified;
- 8 contracts remain draft;
- report desktop comparison count is zero;
- release CI can tolerate G5 failure or measurement SKIP;
- header-only rate cut is unpostable;
- the current cutover loader is unscoped/incomplete and can pass missing, unmapped, or skipped tables;
- the frozen report/output and target-hardware manifests do not yet exist;
- release security certification and an independent production-equivalent penetration test are incomplete;
- migration, live devices/integrations, concurrency, restore, cutover controls, and the selected recovery strategy
  are not production-proven.

## 15. Immediate next actions

1. Feature-flag Tag Split, Tag Weight Difference, Tag Cancel/Transfer, Tag Opening update, logical restore, and
   production migration load until their safety gates pass.
2. Fix backup/restore, cutover-loader scope/completeness, and authorization boundaries before adding more parity
   surface.
3. Make release certification fail on RED, SKIP, stale, or unclassified evidence.
4. Rerun the real desktop/web G5 pipeline from current code and publish fresh totals.
5. Hold the owner/accountant decision workshop for §8.1.
6. Classify the 198 menu entries and turn each retained draft contract into executable acceptance criteria.
7. Implement the exact `TagIdentity`/posting/reversal kernels before rebuilding individual tag pages.
8. Clear the 66 current G5 cases, then, after WP-08 through WP-12 owning work passes, expand in dependency order to the full 1,567-voucher footprint.
9. Start real report CSV/control-total comparison in parallel once per-slug authorization and request
   serialization are corrected.

## 16. Evidence references

### Desktop behavior

- `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs`
- `unified/src/csharp/DataCareNext/TR_TAG_SPLIT.cs`
- `unified/src/csharp/DataCareNext/TR_TAG_CAN.cs`
- `unified/src/csharp/DataCareNext/TR_TAG_WT_DIFF.cs`
- `unified/src/csharp/DataCareNext/TR_INOUT.cs`
- `unified/src/csharp/DataCareNext/TR_PHYSTK.cs`
- `unified/src/csharp/DataCareNext/UT_TAG_PRINT.cs`
- `unified/src/csharp/DataCareNext/Ac_Stock.cs`
- `unified/src/csharp/DataCareNext/Ac_Image.cs`
- `project-memory/catalogs/form-behavior/`
- `project-memory/video-research/_kb/`
- `project-memory/contracts/`

### Current web implementation

- `web/apps/api/src/modules/stock/stock.ts`
- `web/apps/api/src/modules/stock/stockVoucherLifecycle.ts`
- `web/apps/api/src/modules/stock/tagSplit.ts`
- `web/apps/api/src/modules/stock/tagOps.ts`
- `web/apps/api/src/modules/stock/tagPrint.ts`
- `web/apps/api/src/modules/stock/physicalStock.ts`
- `web/apps/api/src/modules/images/entityImage.ts`
- `web/apps/api/src/modules/sales/sales.ts`
- `web/apps/api/src/modules/sales/salesReturn.ts`
- `web/apps/api/src/modules/purchase/purchase.ts`
- `web/apps/api/src/modules/manufacturing/karigar.ts`
- `web/apps/api/src/modules/ops/backup.ts`
- `web/apps/api/integration/cutover.mjs`
- `web/apps/api/src/modules/rbac/routePolicy.ts`
- `web/apps/api/src/modules/utilities/dataRepair.ts`
- `web/apps/api/src/modules/sales/rateCut.ts`
- `web/apps/web/app/(app)/txn/tag-opening/page.tsx`
- `web/apps/web/app/(app)/txn/tag-split/page.tsx`
- `web/apps/web/app/(app)/txn/tag-cancel/page.tsx`
- `web/apps/web/app/(app)/txn/tag-weight-diff/page.tsx`
- `web/apps/web/app/(app)/txn/tag-transfer/page.tsx`
- `web/apps/web/app/(app)/txn/tag-print/page.tsx`
- `web/apps/web/app/(app)/txn/physical-stock/page.tsx`
- `web/apps/web/app/(app)/reports/[report]/page.tsx`
- `web/apps/web/components/FormKeys.tsx`
- `web/apps/web/components/GridKeyboard.tsx`
- `web/apps/web/components/ScaleCapture.tsx`
- `web/apps/web/components/EntityImagePanel.tsx`
- `web/.github/workflows/ci.yml`

### Retained measurements

- `project-memory/parity/FUNCTIONAL-PARITY-MATRIX.json`
- `project-memory/parity/FEATURE-GAP-AUDIT.json`
- `project-memory/parity/DESKTOP-FOOTPRINT-CENSUS.json`
- `project-memory/parity/DESKTOP-REAL-SCHEMA.json`
- `project-memory/parity/g5/parity-diff-latest.json`
- `project-memory/parity/REPORT-BASELINES.json`
- `project-memory/parity/reports/README.md`
- `project-memory/parity/VALIDATION-AUDIT.json`
- `project-memory/parity/CALC-AUDIT.json`
- `project-memory/parity/DEEP-COLUMN-AUDIT-SUMMARY.json`
- `project-memory/parity/UI-FIELD-AUDIT.json`
- `web/docs/COMPLETION-REGISTER.json`
- `web/scripts/check-g5-parity.mjs`
- `web/scripts/check-completion-register.mjs`
- `web/scripts/check-schema-readiness.mjs`
- `web/scripts/check-type-parity.mjs`
- `web/scripts/type-parity-baseline.json`
- `PARITY-AND-GAP-REPORT-2026-08-02.md`
- `FIXES-AND-SCALED-COMPARISON-2026-08-02.md`

This plan supersedes older presence-only or stale gap statements when they conflict with current code or the
latest retained machine-readable evidence. It does not itself certify parity; it defines the work and proof
required to earn that certification.

---

## 17. Execution status — 2026-08-30

The measurements in §1 to §16 are the **2026-08-29 baseline** and are left unedited so the denominators they
publish stay citable. This section records what has been executed against them, what those executions
re-measured, and what the next increment is. Where a figure below contradicts the baseline, the figure below is
the measured one and the baseline is stale.

### 17.1 Work package status

| WP            | Subject                            | Status                                                                                                                                             | Evidence                                                                                                                                                                        |
| ------------- | ---------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| WP-00         | Owner decision register (§8.1)     | **not started — blocks 6 downstream items**                                                                                                        | —                                                                                                                                                                               |
| WP-01         | Contain unsafe operations          | **done**                                                                                                                                           | `project-memory/parity/wp-01/WP-01-CONTAINMENT-EVIDENCE-2026-08-29.md`                                                                                                          |
| WP-02A        | P0-01 backup/restore               | **done**                                                                                                                                           | `wp-02/WP-02A-BACKUP-RESTORE-EVIDENCE-2026-08-29.md`                                                                                                                            |
| WP-02B        | P0-02 generic report authorization | **done**, independently audited                                                                                                                    | `wp-02/WP-02B-REPORT-AUTHORIZATION-EVIDENCE-2026-08-29.md`                                                                                                                      |
| WP-02C        | P0-03 Data Repair authority        | **done**, one owner decision assumed                                                                                                               | `wp-02/WP-02C-DATA-REPAIR-AUTHORITY-EVIDENCE-2026-08-30.md`                                                                                                                     |
| WP-02D        | P0-04 posting accounts             | **first slice done**; 68 literals remain in 15 files, ratcheted                                                                                    | `wp-02/WP-02D-POSTING-ACCOUNTS-EVIDENCE-2026-08-30.md`                                                                                                                          |
| WP-03         | P0-07 release certification        | **done**; gate red by design                                                                                                                       | `wp-03/WP-03-RELEASE-CERTIFICATION-EVIDENCE-2026-08-30.md`                                                                                                                      |
| WP-04         | Classify 198 menu entries          | **done** — 0 unclassified                                                                                                                          | `wp-04/WP-04-COMPLETION-REGISTER-EVIDENCE-2026-08-30.md`                                                                                                                        |
| WP-05         | Contracts                          | **enforcement done**, authoring open; 8 drafts, approval is an owner act                                                                           | `wp-05/WP-05-CONTRACT-INTEGRITY-EVIDENCE-2026-08-30.md`                                                                                                                         |
| WP-06         | Compatibility kernel               | **adoption measured and ratcheted**; 108 rounding + 5 book-account bypasses remain                                                                 | `wp-06/WP-06-KERNEL-CONFORMANCE-EVIDENCE-2026-08-30.md`                                                                                                                         |
| WP-07         | Tag identity kernel                | **4 of 12 invariants data-checked**; two of the four were selecting the untagged sentinel as a tag until WP-08d; §7.2 transition model not started | `wp-07/WP-07-TAG-INVARIANTS-EVIDENCE-2026-08-30.md`                                                                                                                             |
| WP-08         | Tag/purchase/karigar round-trips   | **5 of 5 done** (a–e)                                                                                                                              | `wp-08/WP-08-TAG-OPENING-ROUNDTRIP-EVIDENCE-2026-08-30.md`, `wp-08/WP-08D-KARIGAR-TAG-STOCK-EVIDENCE-2026-08-30.md`, `wp-08/WP-08E-KARIGAR-TAGGED-ISSUE-EVIDENCE-2026-08-30.md` |
| WP-09 → WP-15 | —                                  | not started                                                                                                                                        | —                                                                                                                                                                               |

### 17.2 Baseline figures this work corrected

| §     | Baseline said                                                            | Measured                                           | Note                                                                                                                                                                        |
| ----- | ------------------------------------------------------------------------ | -------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P1-07 | 30 `NOT ENFORCED` validations                                            | **28**                                             | two rows were stale; current code throws the verbatim message                                                                                                               |
| P1-07 | 184 blank golden-vector cells                                            | 184 confirmed                                      | 99 have an exact precedent in an approved contract; none applied, because the audits record cell identity but not the desktop expression                                    |
| P1-07 | 8 drafts contain "184 blank vectors **and** 37 blank test cells"         | blank tests are **0**                              | all 37 are `WAIVED`/`UI-LEVEL` rows carrying a reason, which is the contracts' own discipline; the figure came from a parser that could not tell the two table shapes apart |
| P1-07 | (implied) 283 validation rows                                            | **37** validation rows, 248 computed cells         | the earlier count included computed rows                                                                                                                                    |
| §1.1  | 198 catalog entries, all unclassified                                    | 145 `implemented-unverified`, **53 `absent`**      | the six original states could not express "visible on desktop, absent from the web"; a seventh was required                                                                 |
| P0-04 | six literals named                                                       | **20** account literals in the same fallback shape | fixing only the named six would have left the defect under other names                                                                                                      |
| §7    | karigar receipt tagging creates `BAR_DETL` **and** `MAIN_STOCK` tag rows | only `BAR_DETL` did                                | `stockRows` named neither `TAG_NO` nor `VCH_SRNO`; corrected in WP-08d                                                                                                      |
| §7.1  | (implied) untagged stock carries an empty `TAG_NO`                       | the sentinel is the literal **`'N'`**              | `Ac_Stock.cs:54` converts `''`→`'N'` and every untagged insert hardcodes it; loose stock is read back with `TAG_NO = 'N'`                                                   |

### 17.3 Defects found that the baseline did not record

1. **Purchase reopen-and-save lost money.** `LBR_AMT` 2372.22 → 0 with `TOT_AMT`/`NET_AMT` falling by the same, because `LBR_TYPE` cannot represent the web's `percentage`/`fixed` modes. On a route WP-01 does not contain. **Fixed.**
2. **Purchase reopen-and-save moved the tag identity.** `VCH_SRNO` 1 → 2. **Fixed**, with a consume-once guard so the fix could not mint duplicate identities.
3. **Karigar-created tags had no serial identity, and an edit destroyed the tag record entirely.**
   `receiveKarigar`'s `BAR_DETL` builder never named `VCH_SRNO`, and `karigarWriteSet` includes `BAR_DETL`
   while only the create path had a builder — so `editKarigar` deleted the barcode row and never wrote it
   back, leaving the physical ornament unsellable because `issueTagTx` resolves availability from `TAG_STOCK`
   or `BAR_DETL`. No test anywhere used `mode: 'receive'`, which is how both survived. **Fixed** (WP-08c).
4. **108 module-local rounding helpers round negative midpoints toward `+∞`** instead of away from zero, so every one disagrees with both desktop mechanisms on any negative tie. Measured, ratcheted, not migrated.
5. **Two of the three "approved" contracts carry no resolvable `FORM.cs:LINE` citation.** Recorded as debt for the contract owner rather than as a gate failure.
6. **The test suite was intermittently red under file parallelism** (`40P01 deadlock detected`, victim moving between runs). A gate that must fail on RED cannot sit on a randomly red suite. **Fixed** by serialising files.
7. **`labourCharge` throws `TypeError` on an unrecognised labour type** — a 500 where a validation error belongs.
8. **Karigar stock movements named no tag, so the ornament appeared in no stock view at all.** `stockRows`
   omitted `TAG_NO` and `VCH_SRNO`, and a row carrying neither a tag nor the `'N'` sentinel matches neither the
   tagged views nor the desktop's loose views (`TAG_NO = 'N'`). The received ornament was in stock and invisible
   everywhere. **Fixed** (WP-08d).
9. **WP-07's own INV-2 and INV-3 reported false violations on loose stock.** Both selected tagged rows with
   `TAG_NO <> ''`, which the untagged sentinel `'N'` passes, so every loose movement in a company collapsed into
   one fabricated identity whose signed net is the entire loose balance. It survived because WP-07's fixtures
   seed only tagged rows — the checks had never met realistic data. **Fixed** (WP-08d) with a single shared
   `IS_TAGGED` predicate.
10. **Karigar issue never recorded the tag it sent out.** The `-` movement was untagged, so an issued
    ornament's signed on-hand never fell: it looked permanently held while physically sitting with the karigar,
    and remained offerable for sale. `KR_DETL` also wrote a null where the desktop writes the `'N'` sentinel, and
    hardcoded `VCH_SRNO = 0` under a citation to TR_PURC's block that the karigar form overrides at
    `TR_KR_ISU.cs:5150`. **Fixed** (WP-08e).
11. **One tag could be issued twice on a single karigar voucher**, posting two `-` movements for one ornament and
    driving its signed on-hand to -1 — an invariant violation manufactured by the voucher itself. The desktop
    refuses it at `TR_KR_ISU.cs:3352`. **Fixed** (WP-08e).

### 17.4 §14 no-go conditions — current state

Cleared: report authorization resolved per slug; Data Repair authority consistent; release CI can no longer tolerate RED/SKIP/stale/unclassified; 198/198 classified.

Still present: G5 is 0/66 and stale; 8 contracts remain draft; report desktop-comparison count is zero; literal posting fallbacks remain (68); unsafe partial tag mutations remain contained rather than fixed; Tag Opening can still lose image identity; header-only rate cut unpostable; cutover loader unscoped; frozen report/hardware manifests absent; security certification and penetration test incomplete; migration, devices, concurrency, restore and recovery not production-proven.

Added by this work: **53 menu entries have no web surface**, and **karigar tags have no identity** (17.3 item 3).

### 17.5 WP-08c, karigar tag identity — DONE 2026-08-30

Both defects behind the coverage gap are fixed, and the gap itself is closed: a tagged karigar receive now has
a lifecycle test.

- A shared `resolveKarigarTagIdentitiesTx` allocates a serial for **every** tagged line, including one whose
  tag number the operator typed — the rule purchase already follows. The map of persisted serials is
  **consumed as it is read**, so two lines naming one tag cannot share a serial.
- `karigarBarcodeRows` was extracted so the EDIT path rebuilds the barcode rows the delete removes;
  `persistedKarigarTagSrnosTx` reads the serials before the delete so each tag keeps its identity.

Evidence: a tagged receive round-trips create → reopen → save unchanged with every persisted `BAR_DETL` column
identical, a non-zero `VCH_SRNO` that does not move, and WP-07's tag invariants reporting zero violations over
the same tenant. Full suite 155 files / 1310 tests.

### 17.6 WP-08d, karigar tag stock movements — DONE 2026-08-30

Evidence: `project-memory/parity/wp-08/WP-08D-KARIGAR-TAG-STOCK-EVIDENCE-2026-08-30.md`.

**Desktop answer.** A tagged `+` movement _is_ written, so this was parity rather than an addition.
`Ac_Stock.cs:28` posts it from `BAR_DETL` selecting `A.TAG_NO, A.VCH_SRNO` for
`MAIN_BOOK IN ('OPSTK','JDTR TAG','MFG TAG')` with `ITM_SIGN '+'`, `ITM_QTY 1`. All MAIN_STOCK posting in the
desktop goes through that one shared helper, whose insert names 49 columns.

**Two defects fixed.**

1. _Karigar movements named no tag._ `stockRows` wrote neither column. Worse than §17.6 predicted: a row with
   neither a tag nor the `'N'` sentinel matches neither tagged views nor loose views, so the ornament appeared in
   **no** stock view. Now carries `TAG_NO`/`VCH_SRNO` from the WP-08c resolver, `'N'`/`0` when untagged.

2. _WP-07's own scans mistook loose stock for a tag._ INV-2 and INV-3 selected `TAG_NO <> ''` in six places, and
   the desktop's untagged sentinel is the literal `'N'` (`Ac_Stock.cs:54`, hardcoded at `:15, :17, :32, :42,
:44, :56`; read back with `TAG_NO = 'N'` at `TR_KR_ISU.cs:6961`). Every loose movement collapsed into one
   fabricated identity whose signed net is the whole loose balance, so INV-3 reported violations for untagged
   stock and INV-2 reported reused serials for untagged barcode rows. WP-07's fixtures seed only tagged rows,
   which is why this shipped. Replaced by one shared `IS_TAGGED` predicate.

**Baseline corrections.** §7's tag matrix claimed karigar receipt creates `BAR_DETL` _and_ `MAIN_STOCK` tag
rows; only `BAR_DETL` did. §17.6's impact statement understated the defect as tag-level invisibility.

**Exit criterion met.** INV-3 now examines the karigar tag (`examined > 0`, previously vacuous) and reports
signed on-hand exactly 1 while held, with zero violations. Both fixes are mutation-tested: reverting either
fails the intended assertion.

### 17.7 WP-08e, karigar issue of an existing tagged ornament — DONE 2026-08-30

Evidence: `project-memory/parity/wp-08/WP-08E-KARIGAR-TAGGED-ISSUE-EVIDENCE-2026-08-30.md`.

**Desktop answer.** The path is real and the identity is persisted. `TR_KR_ISU.cs:3318` resolves availability
from `MAIN_STOCK` grouped by `(TAG_NO, VCH_SRNO)` with `HAVING SUM(CASE WHEN ITM_SIGN='+' THEN VCH_SRNO ELSE
-VCH_SRNO END) > 0` and `B.EMP_ISU <> 'Y'`; the save routine writes `TAG_NO` with the `'N'` sentinel
(`:5109`/`:5113`) and `VCH_SRNO` from grid column 40 (`:5150`). An unavailable typed tag never reaches the
detail row because `:3320` diverts to the availability lookup, and `:3352` refuses duplicates outright. No
live-tag table is involved: `TR_KR_ISU.cs` names `TAG_STOCK` zero times.

**Three defects fixed.**

1. _Karigar issue had no tag handling at all._ The `-` movement was untagged, so an issued ornament's signed
   on-hand never fell — it looked permanently held while sitting with the karigar, and remained offerable for
   sale. Now resolved through the reused availability rule, refusing unavailable and ambiguous tags before any
   movement is written.
2. _`KR_DETL` diverged on the two tag columns._ `TAG_NO` was null where the desktop writes `'N'`, and
   `VCH_SRNO` was hardcoded `0` under a citation to **TR_PURC's** shared block — but the karigar form overrides
   it at `:5150`. Citing the wrong form is how it survived.
3. _A tag could be issued twice on one voucher_, posting two `-` movements for one ornament and driving its
   signed on-hand to -1 by itself. Refused, as the desktop does.

Also extracted `resolveLiveTagIdentityTx` from `issueTagTx` so a caller can learn a tag's serial without
reserving it, leaving sales and purchase-return behaviour untouched.

**Exit criterion met.** Signed on-hand moves 1 → 0 → 1 across receipt → issue → receipt, entirely through real
module calls; zero invariant violations while the tag is out; re-issue and duplicate-issue both refused. Both
fixes are mutation-tested.

**Corrections.** Two `DELETE_DATA` description expectations asserted the shape of invalid data — tags that never
existed in stock. The desktop builds that string from the stored column (`:5315`), so untagged lines read
`TagNo / N`.

### 17.8 Next increment — WP-08f, is `TAG_STOCK` or the signed sum authoritative?

**The finding that scopes it.** WP-08e deliberately resolves a tag WITHOUT consuming its `TAG_STOCK` row, because
consuming creates a reversal obligation that `deleteKarigar` cannot currently meet (`sales.ts:885` pairs
`issueTagTx` with `restoreTagTx` at `:2318`/`:2428`; karigar has no restore). That leaves a real inconsistency
for tags that DO have a `TAG_STOCK` row — those created by tag-opening or purchase rather than by a karigar:

- `resolveLiveTagIdentityTx` checks `TAG_STOCK` **first** and returns on a hit, without consulting the signed sum
- so after such a tag is issued to a karigar, its signed on-hand is 0 but its `TAG_STOCK` row still exists
- `issueTagTx` would find that row and a sale could still sell an ornament that is out with the karigar

**Why it was not done with WP-08e.** The two sources of truth disagree and the desktop cannot arbitrate, because
the desktop has no `TAG_STOCK` at all — it is a web-side addition. Choosing which wins changes the meaning of the
live-tag table for **every** module that reads it (sales, purchase return, stock transfer, physical stock), so it
is a cross-module semantic decision, not a karigar fix.

**Scope.** Decide the authority rule, then make it hold everywhere. The two candidates are (a) `TAG_STOCK`
remains authoritative and every issuing path consumes it with a matching restore on delete and edit — which
requires adding that restore to `deleteKarigar`/`editKarigar` and auditing the other issuing paths for the same
gap; or (b) the signed `MAIN_STOCK` sum is authoritative and `resolveLiveTagIdentityTx` verifies it even on a
`TAG_STOCK` hit, making the table a cache rather than a ledger. Exit evidence either way: a tag issued to a
karigar cannot be sold while it is out, proved by a test that attempts the sale and is refused, plus INV-1
still holding on the live-identity table.

### 17.9 Oracle measurement — 2026-08-30, and what it changes

Full analysis: `PARITY-GAP-ANALYSIS-2026-08-30.md`.
Execution plan derived from it: `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md` — four parity dimensions
(database, workflow, form, report), a measured baseline for each, a per-form priority order for all 61
transaction forms, and a per-family definition of done. On that definition **zero of 61 transaction
families are complete today**, including the three worked on this month.

The project's own comparison harness was run against the retained real-desktop bundle (66 vouchers from the live
company database) for the first time in a month:

```
cases 66 · casesMatched 0 · fieldsCompared 23,574 · fieldDifferences 3,787
rowsMissing 210 · rowsExtra 210 · tablesDesktopOnly 53 · tablesWebOnly 105
```

**36% of that gap is already closed and nobody knew.** Re-classifying every difference against the committed
`desktopColumnDefaults.ts` shows 1,354 of 3,787 would not recur today; the web-side bundle predates that fix
because the extractor reads existing rows rather than re-posting them. The remaining **2,433 differences sit in
126 columns across 8 tables**, and the tell-tale is that each differs in 77–78 of 78 cases — a column wrong in
_every_ case is a builder that never writes it, which is exactly the WP-08d finding generalised.

Two corrections to how this plan has been prioritised:

1. **The blank/NULL representation problem is solved**, and solved properly — measured per column from the real
   database (49 tables, 1,894 columns defaulted, 249 deliberately NULL) after a type rule was tried and proven to
   over-reach. §17 should not schedule convention work.
2. **Hand-replaying families is the slow path.** It found 11 real defects, but they are instances of two
   systematic patterns the oracle enumerates across all families in seconds. ~57 families remain at roughly one
   per session.

Also found: `G5-HARNESS.md` documents `apps/api/integration/g5-compare.mjs` as "the single CI entry point" and
**that file does not exist**; the local database retains 1 of the 66 parity vouchers, so the measurement cannot
currently be refreshed.

The next increments are therefore WP-09 (restore the oracle loop and ratchet it in CI) and WP-10 (column
completeness per writer, 126 columns, `MAIN_STOCK` first at 658 differences), replacing §17.8 as the head of the
queue. §17.8's `TAG_STOCK` authority question remains open and unchanged, but it is a correctness question
affecting one table, not a parity-count question.

### 17.10 Plan integrity note — two baseline cells lost 2026-08-30

While updating the §17.1 status table I ran a regex that matched `| WP-08 …` and replaced the **first** match in
the document. The first match was not in §17.1 but in the §5 work-package table, part of the 2026-08-29 baseline
that this section promises to leave unedited. The row's Priority, Description, Dependencies and Exit-criterion
cells were overwritten.

Recovered verbatim: `P1`, and the description
"Tag Opening, purchase tagging, karigar tagging round-trip completion."

**Not recovered:** the Dependencies and Exit-criterion cells. The document is untracked by git, no backup or
second copy exists on this machine, the only APFS snapshots are OS-update ones, and the text is not restated
anywhere else in the plan. Those two cells are marked in place rather than refilled, because inventing a
plausible dependency list and exit criterion would put fabricated content into the baseline that everything
else cites — the one thing the baseline must never contain.

By pattern, neighbouring rows make `WP-07` the likely dependency, and §17's own WP-08 work suggests the exit
criterion concerned lossless reopen/save for the three tagging families. **Neither is recorded as fact.** If the
owner holds an earlier copy of this file, restoring those two cells from it is a five-second fix.

Process change taken: table edits in this document are now done by locating the row within its section, never by
first-match replacement across the whole file.
