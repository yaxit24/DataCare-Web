# WP-03 release certification implementation evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package:** WP-03 — P0-07 release certification must fail on RED, SKIP, stale, synthetic, unclassified or missing evidence
**Status:** implemented and validated in the current working tree; no commit created
**Claim boundary:** this builds the gate and proves it refuses. It does **not** make any refused gate green — G5 is still red, the register is still unclassified, no report comparison exists, and the restore drill is still contained. Making those green is WP-04 onward.

## 1. What was actually wrong

An audit of all 16 files under `web/scripts/`, both workflows and the package manifests established that **every** parity gate could pass without proving its claim:

| Mechanism                                | Evidence                                                                                     |
| ---------------------------------------- | -------------------------------------------------------------------------------------------- |
| Controlling gate cannot fail the build   | `ci.yml` runs `pnpm g5:parity` under `continue-on-error: true`; retained result is `matched: false` |
| Gates exit 0 having measured nothing     | `SCHEMA_READINESS_SKIP`, `FRESH_PROVISION_SKIP`, and `TYPE_PARITY_SKIP` via **three** separate paths — including a dump file that is readable but empty |
| Gates not invoked at all                 | `check-completion-register`, `check-type-parity`, `restore-drill`, `check-doc-references`      |
| Default mode accepts the unproven        | `pnpm register:check` is non-strict, which explicitly accepts all 198 menu entries being `unclassified` |
| Gates can approve themselves             | `--write` on `check-type-parity`, `check-settings-parity`, `report-baselines` rewrites the baseline being compared |
| Evidence cannot be attributed            | no artefact under `project-memory/parity/` carries a release commit or input hash             |
| Required evidence does not exist         | `project-memory/parity/reports/` holds only `.gitkeep` and `README.md`                        |

There was no release workflow of any kind. The closest thing was the "Parity gates" block inside the developer `quality` job, which omits strict register, type parity, report comparison and restore drill.

## 2. What was built

**`apps/api/src/modules/ops/releaseCertification.ts`** — the decision logic, as pure functions, plus `RELEASE_GATES`, the 13-gate required-evidence manifest derived from P0-07's own wording.

Refusal reasons are distinct and named, because "failed" is not actionable: `failed`, `skipped`, `missing`, `red`, `stale`, `synthetic`, `self-approved`, `unconfigured`.

Rules worth stating explicitly:

- **Skip detection matches the shape**, `/\b[A-Z][A-Z0-9_]*_SKIP\b/`, not the three known literals, so a gate that adopts the same convention next month is caught the day it is written. `TYPE_PARITY_OK` and the word "skipped" in prose do not trigger it.
- **Provenance is checked before positivity.** A fabricated artefact almost always claims success, so if the desktop side of a comparison lacks a Microsoft SQL Server banner it is reported `synthetic` rather than allowed to assert `matched: true`.
- **RED beats stale.** Evidence that is both negative and old is reported `red`, because the operator has to fix the comparison, not the clock.
- **Evidence must name the commit.** An artefact without a matching `releaseSha` is `stale`, whatever its timestamp. No existing artefact carries one, which is exactly why a stale capture could previously be promoted by renaming a file.
- **Future-dated evidence is not evidence** (5-minute clock-skew tolerance).
- **The freshness window is required input, never defaulted.** It is an owner decision (plan §8.1 item 11 / §11.2), and a certifier that picks its own window is deciding a business question it was not asked.
- **There is no override.** No `--force`, no allowlist, no environment variable that converts a refusal into a pass.

**`scripts/release-certify.mjs`** — the runner. It only observes: runs each command, captures exit code and output, reads each artefact, hands everything to `certify`. It refuses an unconfigured run in 0.118s *before* executing any gate, because a green gate cannot change that verdict. It writes the record on refusal as well as on success, since a refusal is the evidence for a no-go decision.

**`.github/workflows/release-certification.yml`** — a separate, environment-gated workflow (manual dispatch plus `v*` tags) with zero tolerated failures, which asserts that the certified commit is the checked-out commit and passes real inputs where the developer workflow passes none.

**`ci.yml`** — unchanged in behaviour, with a header stating why its single tolerance exists and pointing at the release workflow, so nobody "fixes" the separation P0-07 requires.

## 3. Exit evidence

The plan's criterion is negative: _"Protected release job cannot succeed on RED, SKIP, stale, synthetic, or missing evidence."_ Each word has its own test.

`test/releaseCertification.test.ts` — 29 tests:

| Refusal proved                                              | How                                                                       |
| ----------------------------------------------------------- | ------------------------------------------------------------------------- |
| `unconfigured`                                              | 5 malformed commit values, 5 malformed windows                            |
| `failed`, `missing` (never ran)                             | non-zero exit; gate absent from observations                               |
| `skipped`                                                   | all three real tokens plus an invented one; stdout and stderr; negative cases that must NOT trip |
| `self-approved`                                             | `--write` in the invoked command                                          |
| `red`, `synthetic`, `stale`                                 | outside window, undated, unparseable, future-dated, wrong commit, unbound  |
| Ordering                                                    | red-and-stale reports `red`; synthetic-and-positive reports `synthetic`    |
| Aggregate                                                   | one bad gate fails the run; an unobserved gate fails; every reason retained |
| Manifest completeness                                       | every gate P0-07 names is present, register is `--strict`, no gate uses `--write`, every gate explains itself |
| Workflow separation                                         | release workflow has zero `continue-on-error`/`\|\| true`, requires the window as input, hardcodes no window; developer CI's tolerance count is pinned at 1 and must still be the desktop comparison |
| **The repository's real evidence**                          | the retained `parity-diff-latest.json` evaluates to `red`; the report comparison to `missing`; the retained restore-drill result to `stale` |

**A real end-to-end run** against this commit, which is the substantive proof:

```
commit           41a7ba4e2bd529be25f80144c97bb647b6795781
freshness window 24h

  lint                   PASS
  test                   PASS
  build                  PASS
  format                 PASS
  completion-register    FAILED    exited 1
  schema-readiness       PASS
  type-parity            SKIPPED   exited 0 but reported TYPE_PARITY_SKIP
  fresh-provision        PASS
  settings-parity        PASS
  report-baselines       PASS
  g5-desktop-comparison  FAILED    exited 1
  report-comparison      MISSING   project-memory/parity/reports/report-comparison-latest.json
  restore-drill          FAILED    exited 1

passed=8 failed=3 skipped=1 missing=1
RELEASE_NOT_CERTIFIED
```

Record retained at `project-memory/parity/release/certification-41a7ba4e…-2026-08-30T05-26-03-863Z.json`.

Every refusal is a gap the plan already documents: the register's 198 unclassified entries, no real SQL Server type dump, G5 `matched: false`, zero report comparisons (P1-06), and the restore drill blocked by WP-01 containment. **WP-03's exit criterion is that this stays red until the evidence exists**, so a refusal here is the gate working, not the gate failing.

Other commands: `tsc` clean for api source, api tests and web; `prettier --check` clean; full suite **150 files / 1252 tests passing**.

## 4. A blocker the gate surfaced

`restore-drill` refuses with WP-01's containment payload, whose own `exitGate` reads: _"P0-01 engineering gate passed in WP-02A; release still requires migrate-deploy confirmation, a green /ready probe, an authorized controlled drill, and an explicit containment-policy change."_

So the release cannot certify the restore drill until someone makes a reviewed change to `web/packages/core/containment.mjs` on the strength of WP-02A's evidence. That is the containment design working as intended — re-enablement is a deliberate policy act, not a side effect — but it is a sequencing dependency that was not visible before this gate existed, and it belongs on the WP-00 decision list beside §8.1.

## 5. Determinism made a prerequisite, and fixed

A gate that must fail on RED is worthless if the suite is red at random. Measured on the reference machine with the previous four-way file parallelism, three consecutive full runs produced **0, then 1, then 3** failures, all `40P01 deadlock detected`, and the victim moved between runs (`backupRestore.db`, `entityImage.db`, `rateCutSettlement.db`). The cause is real contention: WP-02A's company restore takes write locks across ~160 tables in one transaction while other database files write concurrently.

`vitest.config.ts` now sets `fileParallelism: false`. The suite is green on the plain `pnpm test` command, and the trade is stated in the config: 119s serial against 62s parallel. Retrying would have hidden a genuine deadlock; ordering removes it. The way to get the time back is per-worker databases, not re-enabling parallelism.

Second environment finding, unresolved and not a code defect: this machine's test database has `timezone = Asia/Kolkata` while the suite's timestamp assertions are written against UTC, so a run without a UTC session produces ~27 false clock failures. Every result above was produced with `TZ=UTC` and `options=-c timezone=UTC`. CI containers are UTC so this does not affect the pipeline, but it makes a bare local `pnpm test` an untrustworthy signal and should be pinned in the local database setup.

## 6. What this does not do

- It does not verify that any gate's *own* logic is sound. `check-schema-readiness` still proves only column NAMES; `report-baselines` still proves only that the web did not change relative to itself. The certifier requires those gates to run and to be fresh — it cannot make a weak gate strong. Strengthening them is WP-13 and the §11.1.1 comparator manifest.
- It does not implement the signed comparator manifest of §11.1.1, nor add `releaseSha`/input hashes to the *producers*. Consequently every existing artefact fails attribution today, which is the correct fail-closed outcome but means producers must be updated before those gates can ever pass.
- It does not certify security, hardware, load or migration (WP-14B/WP-15); those gates are not in `RELEASE_GATES` yet and must be added as they land, or the manifest will quietly under-specify a release.

## 7. Files

- `web/apps/api/src/modules/ops/releaseCertification.ts` (new)
- `web/scripts/release-certify.mjs` (new)
- `web/.github/workflows/release-certification.yml` (new)
- `web/apps/api/test/releaseCertification.test.ts` (new)
- `web/.github/workflows/ci.yml` (header only; behaviour unchanged)
- `web/apps/api/vitest.config.ts`
- `web/package.json`
