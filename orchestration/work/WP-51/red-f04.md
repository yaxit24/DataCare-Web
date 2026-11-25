# WP-51 F-04 red-test evidence

Status: execution blocked by missing workspace dependencies. Four tests exist, but no behavioral red result is claimed.

The expected security behavior comes from WP-51.f04.tests, not a desktop business rule. Each test builds and closes a fresh app with stub Prisma, leaves `trustProxy` unspecified, and uses no database. Each exhaustion sequence asserts that attempts one through ten are not 429.

| Test ID | Contract | Observed result |
| --- | --- | --- |
| F04-1 | Attempt eleven for `a` at `10.0.0.1` through proxy `127.0.0.1` returns 429. | Not executed. |
| F04-2 | After exhausting that bucket, `b` at `10.0.0.2` through the same proxy is not 429. | Not executed. |
| F04-3 | After exhausting that bucket, `a` at `10.0.0.3` through the same proxy is not 429. | Not executed. |
| F04-4 | Untrusted peer `203.0.113.9` rotating forged forwarded addresses receives 429 on attempt eleven. | Not executed. |

Command run from `web/` before implementation:

```text
$ pnpm --filter @datacare/api exec vitest run test/loginRateLimit.test.ts
undefined
/Users/yakshitsavaliya/dc-wt/orchwt/wp51-login-rate-limit/web/apps/api:
ERR_PNPM_RECURSIVE_EXEC_FIRST_FAIL Command "vitest" not found
```

An offline lockfile install was attempted without changing manifests, but the pnpm store lacks `tarn-3.1.0.tgz` and returned `ERR_PNPM_NO_OFFLINE_TARBALL`. The supervisor must provision dependencies and rerun the red test and gates.
