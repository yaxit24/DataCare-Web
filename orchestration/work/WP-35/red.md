# WP-35.tests red evidence

Result: PARTIAL. The tests are written, but no behavioral red run was possible.

MISSING: database-layer case IDs in cases.md. All 26 frozen cases are labeled `Layer: browser`.
The test names below implement section 3 of this worker packet (D-35-2, called D2 in cases.md),
including the database counterpart of `fine-jv.concurrency.stale-second-save`.
The stale “blocked, D2” gap-map entry at cases.md:37 disagrees with the executable case at :87.

## Execution command and failure

Run from `web/` (command R1):

```sh
PARITY_TEST_PORT=55637 PARITY_TEST_STATE_DIR=/private/tmp/wp35-parity-state node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api exec vitest run test/fineJvVersion.db.test.ts
```

The wrapper exited 1 before migrations or Vitest started:

```text
permission denied while trying to connect to the docker API at unix:///Users/yakshitsavaliya/.docker/run/docker.sock
permission denied while trying to connect to the docker API at unix:///Users/yakshitsavaliya/.docker/run/docker.sock
PARITY_TEST_FAILED docker exited 1
permission denied while trying to connect to the docker API at unix:///Users/yakshitsavaliya/.docker/run/docker.sock
```

Each test below was included in R1. Every test is **unexecuted**, not proven red, green or skipped.
There are no assertion failure lines to report; the shared startup failure above applies to each.

| Test ID | Command | Result / failing lines |
|---|---|---|
| `fine-jv.version.get` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.missing` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.empty` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.short` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.uppercase` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.non-hex` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.too-long` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.put.stale` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.missing` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.empty` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.short` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.uppercase` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.non-hex` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.too-long` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.delete.stale` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.current-save` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.concurrency.stale-second-save` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.stale-delete-after-save` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |
| `fine-jv.version.tenant-scope` | R1 | Unexecuted: Docker socket permission denied; `PARITY_TEST_FAILED docker exited 1`. |

## Assertions and provenance

The token format, required input, conflict status and canonical hashing are D17 requirements
(document 11, line 128). The canonical-token assertion uses `voucherVersionTx` with the existing
Fine JV writer's `WRITE_TABLES`: CONTRA_DATA, AC_DATA and ROJ_MEL_DATA. No new version algorithm is invented.
Refusal snapshots additionally cover REMARK_DATA, TEMP_BOOK_DATA, APR_IDTL and DELETE_DATA, including row IDs.
Two real authenticated operators select context, load the same voucher, and attempt successive edits.
A separate tenant attempts GET, PUT and DELETE and must see no voucher and change neither tenant.

Fine values are seeded constants, not expectations read back from the application.
The counter row uses its Cr fine: TR_CONTRA.cs:2787 {{dataRow2["CR_FINE"] = Conversion.Val(mSG[DC_Main.i, 5]);}}.
The mirror carries that value as Dr fine: TR_CONTRA.cs:2846 {{dataRow2["DR_FINE"] = Conversion.Val(mSG[DC_Main.i, 5]);}}.
MISSING: `.orch/index/TR_CONTRA.md`; only the exact study-cited and adjacent assertion ranges were inspected.

## Static gate — attempt 2

The attempt-1 module-resolution failures were caused by absent workspace package build outputs.
Built the existing packages without changing source files:

```sh
pnpm --filter @datacare/db build && pnpm --filter @datacare/core build && pnpm --filter @datacare/types build
```

Exit 0. Last five lines:

```text
> tsc -p tsconfig.json


> @datacare/types@0.0.0 build /Users/yakshitsavaliya/dc-wt/orchwt/wp35-blocked-residuals/web/packages/types
> tsc -p tsconfig.json
```

Then ran the required gate from `web/`:

```sh
pnpm typecheck:tests && pnpm exec eslint apps/api/test/fineJvVersion.db.test.ts && pnpm exec prettier --check apps/api/test/fineJvVersion.db.test.ts
```

Exit 0. Last five lines:

```text
✖ 1 problem (0 errors, 1 warning)

Checking formatting...
All matched files use Prettier code style!
```

Typechecking and formatting passed. ESLint reported `File ignored because no matching configuration was supplied`,
so its successful exit is not evidence of lint coverage. Build outputs are ignored files; a fresh worktree must
build these workspace packages before the gate. The test source needed no change for the reported errors.

R1 was rerun in attempt 2 and again exited 1 with the Docker socket permission error shown above.
No assertions executed. No application files or existing tests were changed. No mutation was attempted because
this packet forbids production edits and the isolated database could not start.

## Browser handoff

All browser cases remain for WP-35.browser. Blocked cases receive no test in this packet.

| Case | Disposition |
|---|---|
| `fine-jv.concurrency.stale-second-save` | for WP-35.browser |
| `fine-jv.retry.idempotent-replay` | for WP-35.browser |
| `fine-jv.rollback.save` | for WP-35.browser |
| `fine-jv.rollback.edit` | for WP-35.browser |
| `fine-jv.rollback.delete` | for WP-35.browser |
| `fine-jv.downstream-report` | for WP-35.browser |
| `party-opening.concurrency.last-save-wins` | for WP-35.browser |
| `party-opening.rollback.save` | for WP-35.browser; blocked: `faults.mjs:64 rollbackMatrix` assumes a numeric voucher number; needs a skip-number-check option. |
| `party-opening.config.data-type-a-only` | for WP-35.browser |
| `party-opening.config.ab-merge` | for WP-35.browser; N/A (Lite scope) |
| `party-opening.keyboard.esc-and-keys` | for WP-35.browser |
| `item-opening.rollback.save` | for WP-35.browser; blocked: `faults.mjs:64 rollbackMatrix` casts the metal-letter voucher number to int; needs a number-check override. |
| `item-opening.rollback.delete` | for WP-35.browser; blocked: same number-check harness gap as the save case. |
| `company-open.branches.year-choice-carried` | for WP-35.browser |
| `company-open.refusals.stale-choice-refused` | for WP-35.browser |
| `company-open.reopen.year-newest-default` | for WP-35.browser |
| `company-open.rights.location-scope` | for WP-35.browser; blocked: needs another location and a restricted user with a home location. |
| `company-open.retry.replayed-selection` | for WP-35.browser |
| `company-open.rollback.fault` | for WP-35.browser |
| `company-open.settings.last-day-lock` | for WP-35.browser |
| `company-open.settings.settings-in-force` | for WP-35.browser; blocked: G174; needs a second company with different settings. |
| `company-open.keyboard.tab-and-enter` | for WP-35.browser |
| `company-open.journey.open-then-dashboard` | for WP-35.browser |
| `settings.concurrency.two-admins.different-settings` | for WP-35.browser |
| `settings.concurrency.two-admins.same-setting` | for WP-35.browser |
| `settings.rollback.second-table-fault` | for WP-35.browser |
