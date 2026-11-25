# WP-04 idempotency batch A — red evidence

The following tests were added before the implementation:

- `Sales Order (/sales-orders): a replayed create answers the first response byte for byte and posts one voucher`
- `Sales Order (/sales-orders): the same key with a different body is 409 idempotency-key-reused and writes nothing`
- `Sales Order (/sales-orders): two identical requests racing with one key post one voucher`
- `Approval Isu (/tour/issue): a replayed create answers the first response byte for byte and posts one voucher`
- `Approval Isu (/tour/issue): the same key with a different body is 409 idempotency-key-reused and writes nothing`
- `Approval Isu (/tour/issue): two identical requests racing with one key post one voucher`
- `Approval Rtn (/tour/return): a replayed create answers the first response byte for byte and posts one voucher`
- `Approval Rtn (/tour/return): the same key with a different body is 409 idempotency-key-reused and writes nothing`
- `Approval Rtn (/tour/return): two identical requests racing with one key post one voucher`

Red command requested by the packet:

```sh
PARITY_TEST_PORT=55603 node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/idempotency.liteBatchA.db.test.ts test/idempotencyRoutePolicy.test.ts
```

Result: not run. This worktree has no installed `vitest` binary (`pnpm --filter @datacare/api exec vitest ...` exits with `Command "vitest" not found`), and this worker is not permitted to install dependencies or run Docker. Before implementation, the policy test's intended red failure was the missing `/sales-orders`, `/tour/issue`, and `/tour/return` entries in `IDEMPOTENT_CREATE_ROUTES`.
