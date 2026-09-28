# Checkpoint capture helper review

The first root `--check-only` invocation refused the successful strict compiler run because the capture helper required every log to contain output. `tsc --noEmit` legitimately produced an empty log; its retained actual invocation has exitCode0, the complete `tsconfig.test.json` command, and581 unchanged inputs.

The helper now permits an empty log only for the named successful `test-types` check. Every other log still requires content; exit status, actual argv, timestamps, input hashes and the full-project compilation proof remain required. No compiler/test output, fixture, expected result, product source or prior manifest was changed. The next dry validation passed with1513 source identities and15 actual verification records. The following separately recorded preflight and final seal use this corrected helper.
