# Test evidence

What was actually executed in this session, and what was not. Every number below was read from a terminal, a CI log or a `run.json` file on 2 November 2026.
Nothing here is a claim about the Windows desktop: **desktop-match coverage is 0%** for every item, because no case has ever run on the original desktop.
A scenario that is not listed as executed was not executed. A blocked case is not a pass.

Run files live in `web/test-results/feature-e2e/<module>/run.json` (not committed). The compact counts are committed in `docs/parity/run-snapshot.json`.

## 1. Environment and reference material

| Item | Finding |
|---|---|
| Machine | one 8 GB Mac shared by several sessions; at the time of the runs swap was about 6.7 of 8 GB used and the data volume had about 11 GiB free (98% full) |
| Runtime | Node 24.22.2 (the CI version), pnpm 9.15.4, Docker 29.9.2 with disposable Postgres 16 per run |
| Stack | the same zero-mock stack as CI: production Next build, real Fastify API as `app_user` under forced row-level security, migrated Postgres, headless Chromium |
| Isolation | own Compose project `dc-parity-coord`, own ports 55501 / 4611 / 4612, own stack slot; no shared database was touched; containers, volumes and ports were checked clear afterwards |
| Desktop source | `unified/src/csharp/DataCareNext/*.cs`, 204 decompiled C# files: **available** |
| Desktop video keyframes | 1,069 JPG files under `project-memory/video-research`: **available** |
| Report templates | 254 extracted report XML specs under `extraction_output/rpt_xml`: **available**; the `.rpt` files themselves are LFS pointers |
| Desktop binaries, `.rpt`, `NextMain.BAK` | **not available**: Git LFS pointers of about 130 bytes (for example `NextDm.exe` is 133 bytes) |
| Desktop runtime / screenshots to diff | **none exist**, so screenshot comparison with the desktop could not be done |
| Browser tools | Playwright (inside the repo harness) used; the shared Chrome on port 9222 and the MCP servers were not used |

## 2. The defect fixed (PR #218)

| Step | Command | Result |
|---|---|---|
| New case on the unfixed build | `FEATURE_E2E_CASES=tag-print.keyboard.esc-with-focus-on-the-page,tag-print.keyboard.desktop-keys` | `FAIL ... page.waitForURL: Timeout 10000ms exceeded`; the old case passed on the idle machine |
| Same on the fixed build | same | both `PASS` |
| Whole `tag-print` module, fixed | `FEATURE_E2E_MODULES=tag-print` | 18 applicable: 18 passed |
| Stress replay, fixed page | scratch script, not committed: Book, Vch No, Print with Enter, Esc, 8 times at 8x CPU throttling | focus on `BODY` before Esc in 6 of 8; **8 of 8 passed** |
| Stress replay, unfixed page | the same script after stashing only the page change | focus on `BODY` in 6 of 8; **2 of 8 failed** (iterations 6 and 8) |
| Final merged tree `2d75b0cb` | `FEATURE_E2E_MODULES=tag-print,gst-report` | tag-print 18/18; gst-report 57 passed, 0 failed, 13 blocked of 70 |

The stress script copied the module and added a probe; it was deleted afterwards. The CI failure signature (`page.waitForURL: Timeout 30000ms exceeded`) maps to exactly one line of the module.
The failed CI run's evidence bundle contained a screenshot with the page still on Tag Print and the Print button focused, and its request log was identical to the passing run's; the log could not tell the two explanations apart, so the cause rests on the throttled replay.

## 3. CI history used to size the flake (2 Nov, from `gh run` logs)

26 recent real-stack runs were read; 24 executed the Tag Print module. `tag-print.keyboard.desktop-keys` failed in 7 of those 24 (main after #210 and #213, and branches `feat/lite-data-refresh`, `agent/03-approval-report`, `feat/lite-gst-report`, `feat/lite-unblock-cases`, `feat/lite-tag-cancel-close`) and passed in 17.
It then failed again on main after #209 (`128cead9`), when #212 had already changed Esc from `router.back()` to `router.replace('/dashboard')`, so #212's test-side repair did not cure it. #216 (a three-attempt retry) merged afterwards.

## 4. Full feature suite

Command: `node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs` (all modules). Candidate `a2231cc7` (the fix merged with `main` at #215). Duration 7 min 44 s. Verdict `FEATURE_E2E_PASSED`.
Then `tag-print` and `gst-report` again on `2d75b0cb`. Counts are in `run-snapshot.json`; totals over 32 modules:

| Cases | Applicable | Passed | Failed (all baselined) | Blocked | Not applicable | Untested |
|---:|---:|---:|---:|---:|---:|---:|
| 743 | 703 | 596 | 3 | 104 | 40 | 0 |

Failed and baselined: `company-master.fields.complete-round-trip` (G38), `sales-order.create.scheme-tender` (G206), `data-backup.config.nextmain-allowlist` (G64/N80). No new failure.
Of the 104 blocked cases, **78 are `.pending` placeholders** (planned, not yet written) and 26 are explicitly named blocked cases (for example `data-backup.output.physical-save-confirmation` and `settings.concurrency.two-admins`); I did not audit each one's reason. The largest unwritten blocks in Lite menus are `company-master` (18 pending of 28 cases) and `users` (15 of 18); `gst-report` has 13 and `company-open` (a Basic menu) 16.

**Coverage, reported separately** (as the evidence contract requires), over the 703 applicable cases: **executed 599 (passed plus failed) = 85.2%**, **browser pass 596 = 84.8%**, **desktop match 0%**. The three numbers are not averaged.

**Scenario classes (T01-T18).** The module sources declare a group per case. 589 of the 743 cases parse to a group; the other 154 use a factory shape the parser does not read, so this table is partial:

| Group | Passed | Failed | Blocked | N/A |
|---|---:|---:|---:|---:|
| T01 entry/defaults | 32 | 0 | 0 | 0 |
| T02 field route | 35 | 2 | 1 | 3 |
| T03 formula | 28 | 0 | 1 | 2 |
| T04 lookup | 37 | 0 | 0 | 0 |
| T05 children | 26 | 0 | 1 | 5 |
| T06 required/invalid | 37 | 0 | 2 | 4 |
| T07 create | 33 | 0 | 1 | 1 |
| T08 reopen/no-op | 29 | 0 | 1 | 1 |
| T09 edit | 26 | 0 | 2 | 2 |
| T10 delete/cancel | 27 | 0 | 1 | 2 |
| T11 scope/rights | 36 | 0 | 0 | 0 |
| T12 concurrency | 24 | 0 | 2 | 1 |
| T13 retry | 25 | 0 | 1 | 1 |
| T14 rollback | 18 | 0 | 5 | 1 |
| T15 config/history | 26 | 1 | 3 | 1 |
| T16 report/output | 36 | 0 | 1 | 0 |
| T17 keyboard | 36 | 0 | 1 | 0 |
| T18 journey | 27 | 0 | 1 | 0 |
| unmapped | 58 | 0 | 80 | 16 |

The weakest mapped group is **T14 rollback** (18 passed, 5 blocked). The unmapped row is mostly pending placeholders in `users`, `company-open` and `gst-report`.

## 5. Static gates on the pushed head (`2d75b0cb`, before the last merge of `main`)

`pnpm format:check`, `pnpm lint`, forced uncached `turbo run typecheck`, `pnpm typecheck:tests`, `pnpm --filter @datacare/web test` (63 files, 722 tests, plus 9 node:test cases), `test:routes` (138 routes), `check-browser-test-coverage`, `size:budget`, `check-kernel-conformance`, `docs:refs`, `register:check`, `generate-edition-table --check`, `progress:check`, `depth:parity`, `depth:deadcells`, `settings:parity`, `runtime:check`, `git diff --check`, `validate_plan.py`, `docs_check.py`: **20 of 20 exit 0**.
After the final merge of `main` (`b8bf5185`) I re-ran only `docs_check --write`, `pnpm progress` and `progress:check`, and `validate_plan.py` (all clean); CI runs the rest.

## 6. Browser console and network, measured

Across 599 cases that recorded browser data: **7,404 recorded `/api` requests, 0 console errors, 0 responses of class 5xx.** 7,230 were 2xx. The 174 responses of class 4xx are refusal cases doing their job: 400 (96), 403 (41), 404 (18), 409 (14), 401 (5).
Limits: the harness records `/api` calls and Playwright console errors only; it does not record warnings, failed asset loads or page-level `fetch` of other origins. All 32 modules report `businessResponseMocks: 0` and `requestInterceptions: 0`.

## 7. Scenario classes the task listed (A-N): executed or not

| Class | Executed in this session? | Where |
|---|---|---|
| A happy path | yes, through the existing modules | §4 |
| B invalid input | yes (T06) | §4 |
| C boundary values | partly (inside T06 and T03 cases); no separate boundary sweep | §4 |
| D empty / null state | partly (T01 defaults, empty lists) | §4 |
| E duplicate / conflicting records | yes (T12, T13) | §4 |
| F cancellation / rollback | yes, but **T14 is the weakest group** | §4 |
| G permission / authorization | yes (T11: 36 passed, 0 blocked) | §4 |
| H cross-module integration | yes (T18 journeys) | §4 |
| I legacy-data compatibility | **no** (no legacy database; the SQL Server backup is an LFS pointer) | n/a |
| J refresh and session recovery | partly (reopen cases); no dedicated expiry run | §4 |
| K network / backend failure | partly (fault-injection triggers in T14); **no Docker service-kill / restart run** | §4 |
| L concurrent / repeated submissions | yes (T12, T13) | §4 |
| M import, export, report output | partly (T16: 36 passed, 1 blocked) | §4 |
| N regression of existing features | yes: the full suite ran on the merged candidate | §4 |

## 8. Not executed

- Any comparison with the Windows desktop (no runtime, no screenshots).
- Docker service failure and recovery, restart persistence, production-volume behaviour. Only disposable databases were used.
- Mobile / responsive layouts (the screens are desktop-first at 1366x768).
- The 3,789-test API database suite (the API and core packages are unchanged in #218; CI runs it).
- Role matrices beyond the existing modules' T11 cases.
- Performance and load. The only timing evidence is the 7 min 44 s suite and the throttled replay.
- The Esc behaviour of the nine other wrapper-handler screens (GB-02).
