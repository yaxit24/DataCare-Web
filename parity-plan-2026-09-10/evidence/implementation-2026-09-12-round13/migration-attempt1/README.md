# Session context migration proposal — staged, unexecuted

This directory contains a proposed additive SQL migration, a minimal Prisma model patch, and a disposable-database verification harness. None has been applied to a database or the repository. Prisma generation/validation, the compiler, and the harness have not run. The host `psql` executable was located by inventory only.

`migration.sql` is a complete transaction and must execute unchanged, including `BEGIN` and `COMMIT`. It requires the existing authoritative `public.auth_session` baseline. It does not create a missing base table, repair a weaker baseline, alter legacy types, or reset a runtime schema.

## Five fields and admission rules

| Field | SQL / Prisma | Existing SQL NULL | Existing non-NULL |
|---|---|---|---|
| context_epoch | bigint / BigInt; default1, required | Backfill1 | Preserve only positive values in the native signed-bigint domain |
| ledger_context | jsonb / Json; required | Backfill exact unknown object with reason legacy-session-uninitialized | Preserve only the exact four-key unknown envelope with one of three approved reasons |
| last_context_selection_id | varchar36 / optional String | Leave NULL | Canonical lowercase UUIDv4, RFC variant8/9/a/b |
| last_context_request_sha256 | char64 / optional String | Leave NULL | Exactly64 lowercase hexadecimal characters |
| last_context_from_epoch | bigint / optional BigInt | Leave NULL | Positive and strictly below current context_epoch |

The three receipt fields must be all NULL or all present. A receipt without an existing current epoch is refused. The exact unknown envelope is `{version:'server-session-ledger-context-v1',status:'unknown',mode:null,reason}`; approved reasons are `vendor-authority-unresolved`, `legacy-session-uninitialized`, and `scope-incomplete`. Extra keys, JSON null, a known mode, a wrong version, or wrong JSON types are refused. Fresh inserts default to vendor-authority-unresolved; no known mode is inferred.

The Prisma patch matches these native types, required/optional fields, and defaults. Checks remain migration-owned and are not represented by Prisma field types. No legacy field, index, or relation is changed in that patch. `schema-baseline.json` pins the full active schema and original AuthSession model; recheck it before integration.

## Compatibility and rollback

The migration takes an exclusive table lock before catalog validation and uses a role with complete tenant visibility. It requires the historical ordinary-table layout, composite tenant/session primary key, enabled and forced RLS, canonical tenant policy, and exact validated expiry check. It rejects inheritance/partition relationships, any noninternal trigger, and rewrite rules; it does not disable or drop these unknown behaviors. This contains backfill side effects instead of assuming triggers cannot alter legacy values.

A temporary typed reference supplies PostgreSQL-normalized type/default/check/policy definitions. Existing columns must match native type, width/precision, collation, and compatible nullability. Existing new-field defaults may be absent or exactly match that reference. No existing default expression is evaluated to guess compatibility. New receipt columns must remain nullable and have no default. Equivalent but differently expressed manual defaults/checks may be rejected by this deliberately strict profile and require explicit review.

Only SQL-NULL epoch/ledger fields are updated. Non-NULL values are never overwritten. Invalid rows or incompatible named constraints abort the whole transaction; no partially added column or backfill may remain. Existing exact but unvalidated **new** checks can be validated; an unvalidated historical expiry constraint is an unqualified baseline and is refused. The original PK, indexes, expiry constraint, RLS flags, policies, owner, ACLs, session identity/scope/expiry/refresh/revocation values remain untouched.

The fixture qualifies the canonical historical baseline and the named partial-schema variations. Additional existing CHECKs, policies, indexes, extension functions, or custom columns are preserved but are not exhaustively reviewed by this proposal. In particular, the trigger/rule refusal does not prove that an arbitrary function embedded in an additional CHECK has no side effect. Such custom schemas require separate review before adoption; the clean-baseline test result must not be generalized to them.

Backfilling new fields necessarily changes the physical versions of affected session rows. Success must preserve all legacy raw values and schema/permission metadata; it must not assert unchanged xmin/ctid for those rows. The harness also compares every already non-NULL new-field value by complete tenant/session identity. A failed transaction and a no-op second application must preserve the complete before/after snapshot, including xmin/ctid. Raw scalar observations remain SQL text, preserving maximum BIGINT values; a separate flag distinguishes SQL-NULL ledger_context from stored JSON null.

Native bigint/jsonb/char storage cannot prove how earlier input was spelled. In particular, bigint loses leading-zero spelling, jsonb cannot reveal duplicate input keys, and an upstream explicit char cast may already have truncated text. This migration performs no lossy conversion and validates what is actually stored; strict request parsing remains the separate DTO layer's responsibility.

## Proposed acceptance checklist

- Canonical legacy rows across two tenants (including the same session UUID), active/revoked/expired/no-year states: backfill unknown/epoch1 only; retain every legacy value and permission. Current SQL schemas have AuthSession.co_year and YEAR_MAST.CO_YEAR both varchar9.
- Compatible partial columns and valid non-NULL values: preserve a nondefault epoch, all three unknown reasons, and coherent receipts; exercise signed-bigint maximum/current and maximum-minus-one receipt.
- SQL-NULL ledger value is backfilled; JSON null, wrong JSON types, extra keys, known mode, wrong version/reason, zero or negative epochs are refused.
- Partial receipt tuples, missing current epoch, zero/negative/equal/future fromEpoch, uppercase/non-v4/bad-variant UUID, malformed/padded/non-lowercase hash are refused without any migration residue.
- Missing/altered legacy columns, wrong PK, disabled/unforced/missing/wrong tenant policy, missing/weakened/unvalidated expiry check, user triggers/rules or inheritance are refused without repairing them.
- Existing incompatible numeric/domain/text widths, collations, generated/identity columns, noncanonical defaults, stricter receipt nullability, and weaker same-named checks are refused. No narrowing cast or normalization may make them pass.
- A failure discovered after additive DDL must roll back columns, checks and row versions. Execute the complete SQL file through a separate psql connection and compare after it exits; an outer test rollback is not a substitute.
- Reapply the exact complete migration after a successful case and require a complete unchanged snapshot. Confirm each new check is validated and all five expected columns exist.
- Read as the actual non-owner app_user with each fixture tenant; rows from the other tenant remain hidden despite shared session UUID. Unset tenant sees none. Compare original table/column ACL, PK, indexes, expiry and policy metadata.

These are proposed cases, not passed acceptance. The independent fixture/checks are separate inputs; their expected results must be frozen before execution and credited only from an actual completed run.

## Disposable harness and future command

`verify-disposable.mjs` uses only Node built-ins and host psql. It requires the wrapper-provided owner/app URLs to identify localhost:55433, database datacare, and users datacare/app_user. Passwords travel through child environment variables, not command arguments or evidence. Inherited PG routing variables are removed. Only the owner connection performs CREATE/COMMENT/DROP DATABASE in datacare; no runtime public.auth_session DDL/DML is issued there.

Every case creates a separate `datacare_context_migration_<24hex>` database from template0 and records a unique ownership comment. Baseline/setup/migration/snapshots and app_user checks operate only in that owned database. Cleanup requires the generated name plus matching owner/comment and runs in finally; unknown databases are never adopted or removed. Cleanup errors make the run fail. A process killed outside JavaScript cleanup can leave an owned database; its exact name/comment must be reviewed before manual removal.

The independent baseline and cases are under `independent/`. `inputs.json` pins their hashes and the migration bytes. The harness passes the frozen migration Buffer directly to psql without removing its transaction statements or rewriting public identifiers. Failure snapshots include rows/physical versions, columns/defaults, constraints, indexes, RLS/policies/ACLs, triggers/rules/inheritance. Success additionally runs independent state checks, real app_user RLS checks and full-file idempotence. It rechecks all three input hashes after each case.

After root approval and an exclusive lease, from the web workspace:

```sh
node scripts/parity-test-env.mjs -- node /tmp/datacare-session-context-next/migration-staged/verify-disposable.mjs
```

This command has not run. The wrapper itself performs its established isolated setup before passing the URLs; the harness then creates only its own additional databases. Final execution produces `verification-result.json`; staging alone must never create a passed result.

Schema deployment must be coordinated with all epoch-aware writers/readers. Old writers can still update scope without incrementing an epoch; defaults alone do not provide CAS, token rejection, atomic selection, receipt recovery, or known balances. This proposal remains separate from those runtime batches.
