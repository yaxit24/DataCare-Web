# Round12 audited API failure triage — failed stage retained

This is a read-only source and completed-log review. It makes no product change, timeout change, test waiver, recovery claim, or acceptance claim. The separate full rerun is outside this note.

## Observed result

`api-full-audited.txt` finished with **237 passed / 2 failed files; 2225 passed / 2 failed tests (239 files, 2227 tests)**, exit 1, duration 614.11s. Its recorded invocation was `pnpm test:parity:api`, started 2026-09-11T16:47:04.834160+00:00 and finished 16:58:05.370464+00:00. Failure details are log lines558–607; summary 609–617.

- Sales `persists the complete desktop Sales-family column sets under the restricted role` fails during `createSale` at test 505. The stack is `writeSaleTx` 1888 → `postVoucherTx` 515 → `columnsOf` 432, whose pending SQL is the existing `information_schema.columns` lookup. Prisma explicitly reports **5133ms elapsed against the existing 5000ms interactive-transaction timeout**. This establishes transaction expiry; it does not identify which earlier statement or scheduling delay consumed the time.
- Rate Cut `an edit replaces the Rojmel rows rather than colliding on LEDR_KEY` fails at test 359, inside `postVoucherTx` 617's ledger insert, called by `writeRateCut` 1469 within the transaction beginning 1322. Prisma reports **transaction not found**, which names multiple possible causes and does not itself establish expiry, a disconnect, or a ledger identity collision. No SQL unique-constraint assertion is reported.
- The Rate Cut test title overstates the operation being performed: lines 346–369 call `postRateCut` twice without a saved voucher number and expect the Rojmel count to double. `postRateCut` 1509–1511 invokes the create path; the separate `editRateCut` function starts 1513. The failed operation is the **second create**, before the final count assertion. This note does not credit this test as an actual edit/replacement lifecycle proof.

## Reachability and unchanged inputs

Both writers call the existing `withTenant` wrapper without per-call transaction options. The wrapper 17–26 returns the awaited callback from one Prisma interactive transaction; it does not change the default deadline. The failures are transaction errors, not Vitest's 30000ms test deadline. Existing file parallelism is disabled.

The new `observeDesktopAccountBalanceTx` has no import or call from any API production module in the inspected source tree; it is an internal reader currently exercised by its dedicated tests. The new session-mode module is re-exported through the core barrel, so ordinary core imports can load its declarations, but neither failing path invokes its bootstrap or transition functions. The module has no database, network, timer or process import and no top-level ledger operation. No new mode resolution or account-balance query lies on either failing transaction path.

The following current files are byte-identical to their source entries in frozen checkpoint 35. This is an exact file comparison, not a claim that every host/process/dependency condition was identical.

| File | Relevant source location | Current and checkpoint 35 SHA256 | Equal |
|---|---|---|---|
| `web/apps/api/src/modules/sales/sales.ts` | 1988–2007; writeSaleTx→postVoucherTx1888 | `f9edc60fb957d5efc708bc321b1fd905ff186f1d87519728b874a8af79b62f12` | Yes |
| `web/apps/api/src/modules/sales/rateCut.ts` | 1322–1500; postRateCut1509–1511 | `a4814f32fc5ab3aada7aeb1085891f096ddb5dfa3cf09b95fc1d85597f116512` | Yes |
| `web/apps/api/src/modules/posting/posting.ts` | columnsOf429–439; postVoucherTx510–617 | `31cb38b11b25cdfdaaf796ae2d4305888b6f61f71704fde9e97424bacb6df44e` | Yes |
| `web/packages/db/src/tenant.ts` | 17–26 | `1f158835529c4b5c1692c05e377b00c6b14a9bba3b72b2e43a12ff3687fc0a32` | Yes |
| `web/apps/api/test/sales.lifecycle.db.test.ts` | 493–505 | `db0e85dd2550645a6c42ac8d91cd052f38010d43f78939d95b7e561ec3415b81` | Yes |
| `web/apps/api/test/rateCutSettlement.db.test.ts` | 346–369 | `c038e94d6cc35fd92c2ad10efdbfdc8a782754f5305149665af7b5ace5b6c98a` | Yes |
| `web/apps/api/vitest.config.ts` | fileParallelism:false; testTimeout30000; hookTimeout30000 | `8a33367566ecf1e5188c717d8248ce0de817f3faecd3c38d2fb23164520893ba` | Yes |

## Attribution limits and next verification

The earlier round12 `api-full-final.txt` passed these same files in 2554ms and2385ms respectively (file totals), while this failed stage took 19087ms and25814ms. That earlier run's dependency capture was incomplete and cannot replace the required qualified rerun; it is only a historical timing observation. The much larger times, explicit Sales expiry, unchanged writer code and ordinary SQL failure locations are consistent with resource sensitivity. They do **not** prove an environment-only cause or eliminate an existing production latency risk.

The parent observed Docker CPU activity near the failures (isolated database 83.75%, unrelated normal web 122.65%) and temporarily changed only the isolated database CPU shares 0→2048. These are parent-reported operational observations, not an independent causal experiment; the adjustment does not prove either failure fixed. No customer database, transaction deadline, assertions or retries were changed in this triage. A complete rerun on freshly captured inputs is still required. If the problem repeats, statement/transaction timing and database/Prisma lifecycle evidence are needed before assigning a specific cause.

## Pinned evidence

- `parity-plan-2026-09-10/35-implementation-checkpoint-round11.json` — SHA256 `fd3ab768e85c7a0936ae06c72580e7d170b6adf32b74a105df880e43f806a489`.
- `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round12/api-full-audited.txt` — SHA256 `7c06e88af37da5bb92af97977066ca721fc6a142cf47a994cfd542ccf4b150eb`.
- `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round12/api-full-audited.run.json` — SHA256 `1e7c9191e89d91b5cf09e3f69b95e76d1c5e9d901c5d548f5f7b466b2fd5b3e3`.
- `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round12/api-full-final.txt` — SHA256 `329b2d6d8d95e039cc882dd06b041ee6386df4da728c5da7858f60ffd6d7cb33`.
- `web/apps/api/src/modules/shared/desktopAccountBalance.ts` — SHA256 `375629060abeb7454079996c19f61dcc3f8dbdff095616358257e1fa9ce4a2bd`.
- `web/packages/core/src/sessionLedgerMode.ts` — SHA256 `651c63fcc715b995d924d79ddb756d8fca504fcee4ae8cf9c64b4ad883844493`.
- `web/packages/core/src/index.ts` — SHA256 `989a56004a29613b71e9ed6162717d6490ab5bbacb7a72c95a028ba1f02445cc`.
