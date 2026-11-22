# Quality: how cheap sessions produce work the owner can trust

The rule of this layer: **a model's claim is never evidence**. Evidence is what a script measured, what a test
did, what a second reader found, and what CI ran. This file defines each check, who performs it and what the
architect does with the result.

## 1. Risk tiers

Set per work package in [PLAN.md](PLAN.md) section 9; a packet may raise it, never lower it.

| Tier | A change is this tier when it touches | Examples |
|---|---|---|
| A | A writer of money, weight, fine, tax or stock; year-end carry; idempotency; tenant scope or row-level security; sign-in, sessions, rights; backup and restore; a migration; anything a wrong result of which is silent | Sales, Purchase, Cash and Bank, Approval, Balance TrFr, Books, User Create, Data Backup |
| B | A read-only report or screen over those tables; a shared component or hook; test harness code | Tag Stock, Cash Bank report, the RP_ALL engine, `screenEscape.ts` |
| C | Documents, captions, a keyboard fix on one screen, records | A study, an Esc fix, a catalog row |

A diff is treated as tier A whatever its package says if it changes a file under
`web/apps/api/src/modules/**` that writes inside a transaction, a Prisma migration, `rbac/`, `auth/` or `ops/`.

## 2. The ladder

| # | Check | Run by | Applies to | Pass means |
|---|---|---|---|---|
| 1 | Path guard | Dispatcher | Every run | Only allowed paths changed |
| 2 | Content guard | Dispatcher | Every run | No skipped, focused or deleted test; no conflict marker; no hook bypass; no secret; baselines untouched or flagged |
| 3 | Citation check | Dispatcher | Study, cases, and any packet that lists it | Every desktop quote is at its cited line |
| 4 | Red then green | `tests` packet records red; `implement` packet's gates show green | Every behaviour change | The same test ids fail before and pass after |
| 5 | Repository gates | Packet gates, then CI | Every code change | The commands in `AGENTS.md` pass |
| 6 | Cross-model review | `review` packet on a different model family from the implementer | Tier A and B always; tier C when rung 1 to 5 needed a retry | Verdict APPROVE, or each finding fixed and re-reviewed |
| 7 | CI | GitHub | Every pull request | All jobs green on a branch that contains the newest `main` |
| 8 | Architect review | The architect, with the `dc-review` skill | Tier A always; tier B one pull request in three and every one whose review found a major issue; tier C by exception | Section 4 below |
| 9 | Desktop oracle | CI on Windows, or this Windows machine | Each formula family a menu uses | Golden vectors equal the desktop's own results |
| 10 | Owner | UAT | Before a menu is called production-ready | Sign-off |

## 3. What each role is trusted with

| Role | Trusted to | Not trusted to | Therefore |
|---|---|---|---|
| study | Read and locate | Summarise correctly from memory | Every statement carries a quote that a script checks |
| cases | Enumerate behaviours | Judge completeness | The architect approves the list; the coverage table shows each kind T01 to T18 |
| tests | Write assertions from cases | Know whether the test bites | The red list shows each one failing for the stated reason |
| implement, ui | Write code to a test | Leave tests alone; stay in scope | Tests are locked; the path guard is absolute |
| verify | Operate a browser and read results | Decide a failure is unimportant | Its document lists every case; "not ready" is the default |
| review | Find concrete defects | Be the last word on tier A | The architect also reviews tier A |
| records | Edit data files and regenerate | Decide a menu is done | It never sets `FULL` unless the packet says the architect approved |
| lead | Design and decompose | Merge its own design | Its design document is reviewed before its packets run |

## 4. The architect's review (rung 8)

Read in this order and stop at the first problem:

1. **The summary.** Verdict, attempts, changed files. More than one attempt, or a tier escalation, means read
   more below.
2. **The scope.** Do the changed files match what the packet asked? A surprising file is opened.
3. **The tests.** Open the test diff before the code. For each new assertion: where does the expected value come
   from? It must be computed from seeded inputs with the desktop formula, with the citation above it. An expected
   value that could have been copied from the application is a rejection.
4. **The money path.** For tier A, read every changed writer end to end: the transaction boundary, the scope
   columns in every statement, the account resolution, the rounding calls, the reversal on delete, the replay
   behaviour. Compare each rule with the cited desktop lines by opening them.
5. **The review findings.** Each finding is fixed, or rejected with a reason written in the pull request.
6. **What was not verified.** The pull request body lists it. An empty list on a tier-A change is suspicious.

Decide one of: merge-ready; back to a `fix` packet with the exact findings; back to the case list (a missing
case is the cause more often than a bad implementation); or stop and ask the owner.

## 5. Parity checklist for a menu (what L1 means in practice)

A menu is proposed as `FULL` only when every line holds, with the evidence named:

- Every mode the Lite operator can open is reachable from the navigation with the desktop caption (T01).
- Every field in the study's Screen section exists, in desktop tab order, with the desktop default (T01, T02).
- Every validation in the study's Rules section refuses with the desktop text and puts the focus where the
  desktop does (T06).
- Every formula in the Calculations section has a unit vector with a desktop-derived value (T03).
- Create, reopen with unchanged save, edit and delete each have a write-set database test listing every table and
  column, and a second-tenant check (T07 to T11).
- Two sessions racing on the same document give one valid result (T12); a replayed create posts once (T13); a
  failure at each table rolls everything back (T14).
- The related reports and the print agree with the document after each lifecycle step (T16).
- The whole journey works from the keyboard at 1366 by 768, including Esc with no control focused (T17).
- The document's downstream chain reconciles (T18).
- No case is failing, blocked or baselined. The three coverage numbers are stated.

## 6. Failure handling

| Signal | Action |
|---|---|
| A run fails guards or gates | Re-run once: `--attempts 2` puts the failed checks at the top of the prompt |
| It fails again | Escalate one tier: `--tier B` |
| Tier B fails | The architect reads the logs, and usually rewrites the packet: a failing packet is too large, too vague or missing a fact |
| A worker reports a locked test is wrong | The architect opens the cited desktop lines and decides; a correction is a new `tests` packet |
| A citation check fails | Never accept the document with the bad citations removed by hand; re-run the study |
| Review and implementer disagree | The desktop source decides; the architect opens the lines |
| The same package fails three packets in a row | Stop the lane; write what was tried in `docs/parity/AGENT-PROGRESS.md`; ask the owner if a decision is missing |
| A flaky browser case | It has a cause. A `fix` packet finds the race; retries and sleeps are rejected |

## 7. What is measured

From `<root>/state/ledger.jsonl` and the pull requests, reviewed weekly:

| Measure | Why |
|---|---|
| First-pass rate per role and model | Decides routing |
| Re-runs and escalations per package | Shows packets that are too large |
| Defects by the rung that caught them | A defect caught at rung 8 or later means a cheaper rung needs a new rule |
| Architect reading per merged package (files opened, minutes) | The scarce resource |
| Escapes: defects found after merge | Each one adds a case kind, a guard rule or a line to a role contract |

A defect that escapes is fixed twice: once in the product, once in the check that should have caught it.
