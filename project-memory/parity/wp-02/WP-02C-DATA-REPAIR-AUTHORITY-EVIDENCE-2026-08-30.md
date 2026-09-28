# WP-02C data repair authority implementation evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package slice:** WP-02C — P0-03 Data Repair authority
**Status:** implemented and validated in the current working tree; no commit created
**Claim boundary:** this closes the **P0-03 engineering defect and its stated exit criteria**. It does **not** close P0-04 (literal posting accounts), the rest of WP-02, desktop parity of the repair operations' VALUES, or production readiness. One owner decision is assumed rather than recorded — see §5.

## 1. Defect replaced

The plan recorded P0-03 as _"Data Repair comments say admin-only, but its routes are absent from `ADMIN_ONLY`; handlers merely call `guard(..., 'delete')`, which trusts the already-resolved delegated form right."_ Reading the code confirmed the defect and showed it was worse than a comment mismatch:

- `guard(req, reply, 'delete')` does not check an action. It only re-reads the boolean marker the central hook set, so the `// admin-gate` comment beside it asserted something the call could not do.
- The four routes were mapped to `Utilities/Data Repair` but absent from `ADMIN_ONLY`.
- `POST /utilities/data-repair/:id/preview` and `.../apply` were classified `create` by `actionFor`, and `authorizeForm` grants `create` on `FRM_VIEW` alone.

Net effect: a non-administrator holding only **View** on `Utilities/Data Repair` could preview **and apply** operations that rewrite historical ledger, stock, serial and opening-balance rows — including `opening-balance`, `orphan-tag-refs`, `bar-idtl-serial` and `duplicate-cancelled-tag`. Beyond authority, a destructive apply required only a typed confirmation: no reason, no proof the operator was still present, and no proof the data was recoverable.

## 2. Policy now implemented

One explicit policy, in the registry rather than in a comment:

| Route                                     | Form                  | Action   | adminOnly | businessScope |
| ----------------------------------------- | --------------------- | -------- | --------- | ------------- |
| `GET /utilities/data-repair/operations`   | Utilities/Data Repair | `read`   | yes       | yes           |
| `POST /utilities/data-repair/:id/preview` | Utilities/Data Repair | `read`   | yes       | yes           |
| `POST /utilities/data-repair/:id/apply`   | Utilities/Data Repair | `delete` | yes       | yes           |
| `GET /utilities/data-repair/runs`         | Utilities/Data Repair | `read`   | yes       | yes           |

Two design points worth naming:

1. **Business scope is retained.** `NO_BUSINESS_SCOPE` previously inherited all of `ADMIN_ONLY`, so simply adding these routes would have **removed** company/location/year validation from them. A repair rewrites exactly one company's data, so `SCOPED_ADMIN_ONLY` is now subtracted from `NO_BUSINESS_SCOPE` and the requested scope is still validated against the session.
2. **Actions are classified for what they do.** Preview reads (the framework already asserts a preview writes nothing); apply is a `delete`. If the owner later delegates this console to a maintenance role instead of administrators, that role would need explicit Delete — not View.

## 3. Destructive-apply authority

Requirements are derived from the operation's own `risk` (`high`/`danger` — the same threshold that already demanded a typed confirmation) and enforced inside `applyRepair`, not in a route handler:

| Requirement           | Enforcement                                                                                          | Failure                                              |
| --------------------- | ---------------------------------------------------------------------------------------------------- | ---------------------------------------------------- |
| Typed confirmation    | unchanged                                                                                            | 400 `confirmation-required`                          |
| Written reason        | ≥ 12 characters after trimming, recorded on the run                                                  | 400 `reason-required`                                |
| Re-authentication     | operator's own password verified against `LOGIN_MAST` through the same migration path login uses     | **403** `reauthentication-required` / `-failed`      |
| Verified backup       | `company_backup_run` row matching tenant + company + checksum, generated within 24 h                 | 400 `backup-reference-required` / `-unknown` / `-stale` |

All four are checked **before** the advisory lock and before any write. `previewRepair` returns an `authority` object so the console asks for exactly what will be demanded, and the applied run row records `reason`, `backup_reference` and `reauthenticated_at`.

Making the backup reference verifiable required persistence, otherwise it would be a string the operator typed. Migration `20260830000000_data_repair_authority` adds:

- `company_backup_run` — append-only, RLS-forced, tenant-isolated ledger of produced backup documents (checksum, version, generatedAt, table/row counts, operator);
- `data_repair_run.backup_reference` and `.reauthenticated_at`.

`recordCompanyBackup` is called from `GET /backup` — deliberately **not** from `backupCompany`, because that function is also the comparison oracle for restore verification and the WP-02A tests: a snapshot that writes cannot prove that nothing else changed. Failing to record is fail-safe: an unrecorded backup simply cannot be named as cover for a repair.

## 4. Exit evidence

Required by the plan: _"Role matrix and negative tests; policy wording and code agree."_

Role matrix — `test/dataRepairAuthority.test.ts` (7 tests, mocked Prisma; the fixture throws if a handler reaches business data):

| Caller                                             | All four console routes |
| -------------------------------------------------- | ----------------------- |
| unauthenticated                                    | 401                     |
| non-admin, View on Utilities/Data Repair            | 403                     |
| non-admin, View + Edit + Delete + Print            | 403                     |
| administrator                                      | allowed, then still subject to §3 |

Business queries issued by refused requests: **0**.

Destructive authority — `test/dataRepair.db.test.ts` (real database, real rows): missing reason, 3-character reason, missing password, wrong password, missing backup reference, unknown checksum, **another tenant's real backup**, and an expired backup are each refused with the expected code; `OP_DATA` is still empty afterwards and no `applied` run exists. With every requirement satisfied the same reviewed change set applies and the run records reason, backup reference and re-authentication time. A separate test pins that a `medium` operation (`karigar-fine`) demands none of this, so routine repairs are not pushed out of reach.

Policy-vs-code agreement: `routePolicyFor` is asserted to return exactly `{kind:'form', form:'Utilities/Data Repair', action, adminOnly:true, businessScope:true}` for each route, plus a test contrasting `GET /admin/users` (`businessScope:false`) with the apply route (`businessScope:true`) so the scope distinction cannot silently regress.

Commands and results:

- `vitest run` (whole API suite): **147 files, 1215 tests, all passing.**
- `tsc -p apps/api/tsconfig.json --noEmit`, `tsc -p apps/api/tsconfig.test.json --noEmit`, `tsc -p apps/web/tsconfig.json --noEmit`: clean.
- `prisma migrate deploy`: applied `20260830000000_data_repair_authority`; verified 175 public tables, `company_backup_run` with `relrowsecurity`/`relforcerowsecurity` true, one tenant policy, one immutability trigger, both new `data_repair_run` columns, and `app_user` table + sequence grants.
- `prettier --check` on every changed file: clean.

Note on the environment: the local test database's session timezone is `Asia/Kolkata`, while the suite's timestamp assertions are written against UTC. A run without a UTC session produces ~27 unrelated clock failures. All results above were produced with `TZ=UTC` and `options=-c timezone=UTC` on both connections. This is a local environment property, not a code defect, but it means a bare `pnpm test` on this machine is not a trustworthy signal.

Second environment finding, relevant to WP-03: with the default four-way file parallelism the suite is **intermittently red on `40P01 deadlock detected`**, and the affected files move between runs (observed: `backupRestore.db.test.ts`, `entityImage.db.test.ts`, `rateCutSettlement.db.test.ts`). Cause is contention on the shared database — WP-02A's company replace takes write locks across ~160 tables in one transaction while other DB files write concurrently. `vitest run --no-file-parallelism` is **147 files / 1215 tests green** in 162 s versus 62 s parallel. This is pre-existing (the broad-replace test arrived with WP-02A) and is not a logic defect, but a release gate that must "fail on RED" cannot sit on a suite that is randomly red: WP-03 should either run the database files serially or give each worker its own database, as `vitest.config.ts` already suggests.

## 5. Owner decision assumed, not recorded

§8.1 decision 5 — _"Whether Data Repair is super-admin only or a separately delegated maintenance privilege"_ — is still undecided in WP-00. This slice implements **admin-only**, because that is what the existing code comments claimed and it is the fail-closed reading. If the owner chooses a delegated maintenance role, the change is small and localised: remove the four keys from `ADMIN_ONLY`, keep them in `SCOPED_ADMIN_ONLY`, and rely on the now-honest `read`/`delete` action classification. The authority requirements in §3 are independent of that decision and should survive it.

## 6. Incidental fixes made while validating

- `test/backupRestore.db.test.ts`: WP-02A's table counts move 174 → 175 total and 13 → 14 tenant-shared, reflecting the new excluded ledger; its cleanup routine now takes the documented `app.allow_repair_purge` opt-in so it can purge append-only ledgers.
- `test/transaction.integrity.db.test.ts`: `SL_DETL_RTN` and `TEMP_BOOK_DATA` were missing from the fixture's own cleanup list, so a run that failed mid-transaction left rows behind and the next run failed on a unique-key conflict inside `postVoucherTx` — a stale-fixture failure that reads exactly like a posting defect. Added.
- `src/modules/ops/migrationManifest.ts`: the new migration is registered with its content checksum, keeping the drift check and `opsInvariants` green.

## 7. Files

- `web/packages/db/prisma/migrations/20260830000000_data_repair_authority/migration.sql` (new)
- `web/apps/api/src/modules/utilities/dataRepair.ts`
- `web/apps/api/src/modules/rbac/routePolicy.ts`
- `web/apps/api/src/modules/ops/backup.ts`
- `web/apps/api/src/modules/ops/migrationManifest.ts`
- `web/apps/api/src/app.ts`
- `web/apps/api/src/routes/txn.ts`
- `web/apps/web/app/(app)/utilities/data-repair/page.tsx`
- `web/apps/api/test/dataRepairAuthority.test.ts` (new)
- `web/apps/api/test/dataRepair.db.test.ts`
- `web/apps/api/test/backupRestore.db.test.ts`
- `web/apps/api/test/transaction.integrity.db.test.ts`
