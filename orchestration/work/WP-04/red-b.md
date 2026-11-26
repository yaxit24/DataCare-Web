# WP-04 idempotency batch B — red evidence

Added nine cases in `idempotency.liteBatchB.db.test.ts`: replay, changed-body key reuse, and a same-key race for Fine Jv, Party Opening, and Tag Opening. The Tag Opening cases also assert one `BAR_DATA` tag number; Party Opening measures its one `OP_DATA` row plus its `AC_DATA` legs.

The packet's red command is:

```sh
PARITY_TEST_PORT=55604 node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/idempotency.liteBatchB.db.test.ts test/idempotencyRoutePolicy.test.ts
```

It was not run before implementation because this worker may not run Docker. The red condition was the three absent guarded-route declarations and page senders; implementation now follows the locked test contract.
