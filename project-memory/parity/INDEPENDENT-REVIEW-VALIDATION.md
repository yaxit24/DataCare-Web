# Independent Adversarial Review and Validation

**Review date:** 2026-07-26  
**Scope:** extraction baseline, desktop evidence model, current web audit, parity matrix/generator, production roadmap and release gates.  
**Product decision:** **NO-GO for real-business production or transactional pilot; synthetic demo only under the documented restrictions.**

## 1. Review method

Three independent reviewers were run without modifying files:

1. **Artifact auditor:** recomputed frozen counts, normalized form assets, report/binder totals, JSON/CSV consistency, gate states, evidence paths and roadmap graph.
2. **Critical-finding auditor:** re-opened current source for C1–C5 and H1/H2/H3/H4/H5/H7/H9 plus schema/audit/RLS drift and actively looked for stale/overstated claims.
3. **Plan auditor:** checked work-package ownership, dependency closure/order, release safety, exact-replica scope, six gates, module/report/device/migration/operations coverage and autonomous-loop stop criteria.

After four minor plan traceability corrections, a fourth independent reviewer re-parsed the roadmap and verified each correction and the complete DAG.

## 2. Independent results

### 2.1 Artifact/count audit — PASS

Recomputed exactly:

- 204 canonical forms: 33 master, 61 transaction, 45 report, 22 utility, 43 other;
- 146 desktop tables and 5,254 columns;
- 255 supplied RPT binaries plus 20 code-referenced absent obligations;
- 57 settings;
- 247 API routes: 16 in `app.ts`, 231 in `routes/txn.ts`;
- 720 matrix units: 204 forms + 146 tables + 275 reports + 57 settings + 13 shortcuts + 25 invariants;
- 253 complete report layouts, one partial, one unavailable;
- binder classification: 32 sales, 22 purchase, 8 karigar, **193 unsafe sales-default**;
- 175 web form-layout files normalize to **163 distinct desktop form IDs** because 12 namespaced layout files duplicate initcomp forms; 163/204 = 79.9%;
- all 720 units remain `desktop_compared=not_started` and `production_certified=not_started`.

The reviewer confirmed:

- JSON and CSV both contain exactly 720 units;
- all six gates are present on every unit;
- report, form-mapping and category counts sum correctly;
- all key cited paths exist;
- generator evidence paths are valid;
- the 48-package roadmap is closed, acyclic and wave-ordered;
- all matrix dependency IDs and blocker classes have plan ownership.

### 2.2 Critical source-finding audit — confirmed

The reviewer found **no stale or overstated critical claim**. Direct source confirmation:

- **C1:** `sales.ts`, `purchase.ts`, `salesReturn.ts`, `purchaseReturn.ts` generate `MAIN_STOCK` only after filtering for `tagNo`; loose lines do not move inventory although `onHandNet()` treats `MAIN_STOCK` as truth.
- **C2:** `deleteSale()` uses optional `tagRestores`; `deletePurchase()` uses optional `tagRemovals`; `VoucherList.remove()` sends no body while promising ledger + stock reversal.
- **C3:** numbering advisory lock includes tenant/company/location/year/book while `SRNO_MAST` read/update uses only company/location; no year/book columns or unique scope key; tests cover only `scopeKey()` strings.
- **C4:** shared `fineWt` applies `(net+ght)×(touch+west)/100`; purchase test locks that behavior despite a contradictory title/comment, while the sales frontend previews `net×touch/100` and sends no ghat/wastage.
- **C5:** `scopeOf()`/`readScope()` accept body/query overrides; context selection validates a year globally and can mint arbitrary company context; location can default to company; generic masters do not enforce active company scope.
- **H1:** `USER_SET` affects `/me`/navigation; API `assertRight()` checks only global flags and lacks a form parameter; no rows fail open.
- **H2:** `postVoucherTx()` checks lock date; `reverseVoucherTx()` does not; missing/schema/parse errors fail open.
- **H3:** imported `BAR_DETL` availability is check-then-act with no lock/unique consumption constraint.
- **H7/H9:** report binder recognizes only SL/PR/KR then defaults to sales; fake renderer emits a content-free PDF; report routes catch renderer errors and return fake success; production Docker does not install/copy Chromium.
- **H4/H5/schema:** base migration has no RLS; four raw parity tables lack FORCE and Prisma models; 22 columns are migration-only; `audit_log` is absent from migrations/`rls.sql`; audit writes swallow errors.

The reviewer also confirmed the C1 wording is correctly scoped: tagged lines do move stock, and opening/lot/adjust paths can post loose stock; the defect is the core sale/purchase/return transaction family.

### 2.3 Plan audit — four minor corrections, no safety flaw

The initial plan audit found no cycle, missing hard prerequisite, unsafe pilot rule, invented business formula or count inflation. It requested four traceability corrections:

1. Add dedicated form `TR_FN_INOUT` to `DOMAIN-INVENTORY` alongside `TR_INOUT`.
2. Align transactional-pilot wording between JSON and Markdown to C1–C5 plus H1–H6/H9.
3. Give stale report assets their own `H8-stale-report-assets` ownership tag under `REPORT-EVIDENCE-RECOVERY`.
4. Pin existing open dependency ranges in W0 rather than deferring them to final security certification.

All four were applied to:

- `project-memory/parity/PRODUCTION-WORK-PACKAGES.json`
- `project-memory/parity/PRODUCTION-DELIVERY-PLAN.md`

### 2.4 Correction re-review — PASS

The independent follow-up verified:

- `TR_FN_INOUT` appears in both JSON inventory scope and readable §7.5;
- JSON and Markdown both require C1–C5 and H1–H6/H9 for transactional-pilot entry;
- `REPORT-EVIDENCE-RECOVERY` uniquely owns `H8-stale-report-assets`, and Markdown states it;
- `CI-QUALITY-GATES` W0 scope/acceptance pins existing and future dependency versions;
- JSON parses with 48 unique nodes, no dangling dependencies and a complete topological ordering of all 48 nodes.

## 3. Final executable validation

Executed from `unified/` after corrections:

### Extraction and manifest

- `python3 -m unittest discover -s tools/tests -p 'test_*.py'`
  - **28/28 passed**.
- `python3 tools/verify_manifest.py`
  - **830 present artifacts checked**;
  - **0 missing**;
  - **0 canonical-layout failures**.
- Python compilation passed for:
  - `unified/tools/rpt_xml_to_spec.py`
  - `project-memory/parity/build_parity_matrix.py`

### Matrix regeneration and structure

`python3 project-memory/parity/build_parity_matrix.py` regenerated successfully and asserted:

- 204 forms;
- 146 tables;
- 275 report obligations;
- 57 settings;
- 13 shortcuts;
- 25 invariants;
- 720 CSV/JSON rows;
- 247 API routes;
- four raw-migration-only tables: `COUNTRY_MAST`, `IMAGE_DATA`, `LBR_ISU_IDTL`, `OP_DETL`.

Additional validation proved:

- CSV has 720 rows and 19 fields;
- JSON/CSV unit-type counts match exactly;
- all 720 G5/G6 cells remain honestly not started;
- all cited gate-evidence paths exist (**0 missing**);
- form layout metrics are 175 files / 163 normalized IDs / 79.9%;
- report binder counts are exactly 8 KR + 22 PR + 32 SL + 193 unsafe default = 255.

### Roadmap validation

- 48 unique work-package IDs;
- 125 dependency edges;
- zero missing dependency targets;
- no cycles;
- no dependency points to a later wave;
- all four independent-review corrections present;
- all 48 package IDs appear in the readable plan.

### Recovered report validation

- `SalesQuotation.spec.json` parses with `status=partial`;
- 30 sections, 155 objects, 34 formulas;
- report index parses with 254 entries and marks SalesQuotation partial.

## 4. Previously executed web validation retained as current evidence

No web source was changed during the documentation/matrix/plan work. Current-source validation already executed in this audit remains:

- workspace typecheck: pass;
- uncached API tests: 38 files, 181 tests, pass;
- all tested package assertions: 206 pass; frontend/reports have no tests;
- production build: pass, Next generated 87 pages;
- Prisma validation: pass;
- real local Playwright PDF smoke: 8,628-byte `%PDF-` output;
- format check: **fail on 704 files**;
- lint: exits 0 but runs **zero tasks**.

The passing build/unit checks do not override the confirmed data-integrity/security/report findings.

## 5. External validation still blocked

These were not fabricated or run against unsafe resources:

- live integration/RLS/concurrency tests: project Compose database on expected port 5433 is not running; unrelated PostgreSQL on 5432 was not mutated;
- exact `TagStkIdtlRpt` and full `SalesQuotation`: require compatible Windows Crystal runtime/reader;
- 20 missing RPTs: require another complete installation;
- desktop row/keyboard/screenshot/PDF comparisons: require runnable desktop plus sanitized representative data;
- scale/camera/scanner/printer certification: requires declared shop hardware/OS/browser/media;
- provider certification: requires approved sandboxes/credentials;
- load/RPO/RTO/cutover certification: requires business volume and recovery objectives plus representative customer data.

## 6. Independent conclusion

The audit and planning deliverables are internally consistent, reproducible and appropriately conservative after the four corrections. The critical web defects are independently confirmed in current source. The matrix does not convert engineering breadth into false parity, and the production roadmap uses those defects and zero-G5 baseline as release vetoes.

**Deliverable review status: PASS. Product production status: NO-GO.**
