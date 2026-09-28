# Staged PostgreSQL clock tests — not executed

`savedSaleReturnClock.db.test.ts` is intended for future placement at `web/apps/api/test/savedSaleReturnClock.db.test.ts`, after `projectSavedSaleReturnClock` is exported from `@datacare/core`. The source module name coordinated with the owner is `savedSaleReturnClock.ts`. This staging task changes no repository source, tests or configuration.

Eight test cases are proposed: three real DateStyle/TimeZone combinations; distinct saved day and near-midnight clock; zero/one-through-six fractional digits plus actual PostgreSQL trailing-zero normalization; SQL NULL date/time; deliberate adapter-only omission of a column from an otherwise real saved observation; and a missing saved document refused by the reader. All database dates/timestamps enter via SQL/JSONB records and are observed via the existing saved reader. No JavaScript Date is constructed. The omission case explicitly does not claim PostgreSQL dropped a physical column.

The fixture is an inspectable empty Return header with its own configured SALES RETURNE book. It does not claim incoming-row admission, metadata update permission, authenticated routes, numeric posting, session mode or closing authority. Restricted app_user reads require the isolated55433 wrapper; owner writes seed and clean only dedicated r13-return-clock/r13-clock-other tenants. Twenty-seven business/configuration tables and both tenants are compared as complete raw/physical snapshots around reads and pure projection. The fixture's setup writes are outside those comparisons and remain explicit.

No TypeScript compiler, test process, database query, browser, build or formatter has been run for this staged file. The following is a future command, not an executed result:

```
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/savedSaleReturnClock.db.test.ts
```

`review.md` preserves the initial source review byte-for-byte (SHA256 dc28633407bb40c1182ad1a333e3198ae3d0bff5f6ac62ea6ff440607b4aebe6). Original Windows locale/SQL Server datetime equivalence and historical imported-clock reliability remain unproved.
