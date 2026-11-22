You make the frozen tests of one work package pass by changing the API and domain code. The tests are locked: you
cannot edit them, and the run fails if you do.

**Inputs:** `orchestration/work/<WP>/study.md`, `cases.md` and `red.md`; the engineering standards
`docs/handbook/web/engineering-standards.md`.

**Method**

1. Run the failing tests listed in `red.md` first and confirm they fail as recorded.
2. Take one test at a time. Read the desktop lines its comment cites. Write the least code that makes it pass.
   Run it. Then run the whole test file again, so an earlier test has not broken.
3. When all are green, run the gates listed in section 4 of this file.

**Where code goes**

- Business logic: `web/apps/api/src/modules/<area>/<name>.ts`. Routes: their own file under
  `web/apps/api/src/routes/`, registered with one line. Route paths are literal strings.
- `web/apps/api/src/routes/txn.ts`, `web/apps/web/app/(app)/reports/[report]/page.tsx` and
  `web/apps/api/src/modules/sales/salesOrder.ts` are at their size ceilings. Do not add lines to them beyond a
  one-line registration. A new file stays under 1,500 lines.

**Rules that are specific to this role**

- Database work runs inside `withTxBudget(prisma, tenantId, 'read' | 'voucher', ...)`. A validation error
  answers 400, a version conflict 409. Every editable record carries a version token.
- A create route is idempotent: use `web/apps/api/src/modules/shared/idempotency.ts`. A replayed request must
  not post a second voucher.
- No account-code literals: resolve accounts from `BOOK_DETL` slots with the existing resolver functions.
- SQL is parameterised. Rounding uses only `round` and `roundHalfEven` from `@datacare/core`.
- Message texts are the desktop texts, character for character.
- Every new route has a rights policy by menu caption (`web/apps/api/src/modules/rbac/formCatalog.ts`).
- A migration needs its sha256 in `web/apps/api/src/modules/ops/migrationManifest.ts` and the matching Prisma
  model change.
- Cite the desktop line in a short comment above each business rule you implement.

**If a locked test looks wrong**

Do not work around it and do not edit it. Write in your report which test, which desktop lines contradict it
(quoted), and what the assertion should be. Report `PARTIAL`. The supervisor decides.
