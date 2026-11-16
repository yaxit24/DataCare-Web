# Orchestration plan: building the Lite web application with a team of AI sessions

Written 16 November 2026. This is the plan for **how** the remaining work is carried out. **What** remains is
already ordered in [`docs/parity/LITE-MASTER-PLAN.md`](../docs/parity/LITE-MASTER-PLAN.md) (the work packages
WP-00 to WP-56); this plan does not repeat or reorder it.

Companion documents: [architecture](ARCHITECTURE.md), [quality](QUALITY.md), [packets](PACKETS.md),
[worker tools and providers](RUNNERS.md), [machine setup](SETUP.md).

---

## 1. The plan on one page

**Goal.** The Lite edition of the DataCareNext desktop jewellery ERP (49 menus) runs as a web application that an
operator who knows the desktop can use without relearning: the same fields, keys, messages, prints and business
results, served safely to many shops.

**Constraint.** The strong models (Claude Opus, Sonnet, Fable) are a limited subscription. The desktop source is
vast: single forms run from 1,500 to 33,000 lines. Most of the work is reading, typing and running tests, which a
cheap model does well when it is told exactly what to read and how it will be checked.

**Design.** Three levels of sessions and one script:

| Level | Who | Does | Never does |
|---|---|---|---|
| Architect | One Claude Code session on the strongest model | Chooses the next work package, splits it into packets, reviews evidence, decides merges, keeps the plan true | Reads a whole desktop form, types routine code, runs long test suites by hand |
| Lead | Claude sessions on a model chosen per task (Sonnet by default, Opus for the hardest) | Designs a shared engine, decomposes a large package, implements changes to money and stock that span writers, repairs what a bulk worker could not, reviews as a second reader | Bulk reading, routine screens, record keeping |
| Worker | Cheap model sessions in any tool (OpenCode, Codex, Claude Code pointed at another provider) | Desktop study, case lists, tests, routine implementation, screens, records | Decides scope, commits, pushes, edits tests it must pass |
| Dispatcher | `orchestration/bin/orch.mjs`, a Node script with no model in it | Starts one session per packet in its own git worktree, assembles its context, checks what it changed, runs the gates, records the result | Judges quality beyond its scripts |

**Quality comes from checks, not from model strength.** A worker's output is accepted only after, in order:
scripts confirm it stayed in scope and its desktop citations are real; the tests written before the code pass; the
repository's gates and CI pass; a different model reviews it; and, for changes that can corrupt money, stock,
tenant isolation or sign-in, the architect reviews it. Section 5 and [QUALITY.md](QUALITY.md) give the ladder.

**The worker side is replaceable.** No document, packet or role names a model or a vendor. One file,
`orchestration/config/routing.json`, maps three tiers (A, B, C) to tools and models, and
`orchestration/config/providers.json` records which plans exist, their terms and whether a key is present.
Changing provider is an edit to those two files.

**State on 16 November 2026.** Section 12 lists what is built, verified and still open.

---

## 2. What "done" means

Unchanged from the master plan, section 1:

| Level | Meaning for a menu | Set by |
|---|---|---|
| L1 web-complete | Every mode the Lite operator sees, its lifecycle, print and rights; no failing, blocked or baselined case; write-set database tests for its writers | The architect proposes; the owner or coordinator merges the catalog change |
| L2 desktop-verified | L1 plus every formula the menu uses matched against the desktop's own code on .NET Framework 4.8 | Automatic when its golden-vector suite is green |
| L3 production-ready | L2 for all 49 menus plus the go-live gates (security, backup, restore, cutover, performance, UAT) | The owner, after UAT |

Three numbers are reported for every menu and never averaged: cases executed, cases passed in the browser, and
desktop-match coverage. A screen that renders is not evidence of anything.

"Same as the desktop" has four parts, and each has its own check:

| Part | What must match | How it is proven |
|---|---|---|
| Function | Business results: amounts, weights, fine, tax, postings, stock, balances | Unit vectors, write-set database tests, the desktop oracle (L2) |
| Workflow | Modes, lifecycle (create, reopen, edit, delete), validations, message texts verbatim | Browser cases T01 to T16 against the frozen case list |
| Keyboard and layout | Field order, tab order, Enter flow, function keys, Esc, focus after a message, 1366 by 768 | Browser cases T17, the verify role's keyboard walk |
| Output | Prints against the Crystal templates, exports, report totals and drill-down | Browser cases T16, template comparison |

---

## 3. Principles

1. **The desktop source is the authority.** Every rule cites `FORM.cs:line` with the quoted source text, and a
   script verifies the quote. Expected values in tests come from the desktop rule.
2. **Checks before trust.** Nothing a worker says is believed. Scripts read the worktree; gates run; a second
   model reads the diff. The architect reads results, not transcripts.
3. **Tests are written first and then locked.** One session writes failing tests from the frozen case list; a
   different session implements against them and cannot edit them.
4. **Small packets.** One role, one output, a named list of files to read, a list of paths it may change. A
   packet a bulk model cannot finish in about an hour is split.
5. **The dispatcher assembles context.** A worker never has to discover rules, skills or files. Two different
   tools on two different models receive the same instructions.
6. **Everything durable is in git.** Packets, study notes, case lists, verification records, claims and status
   are files in the repository, so any session on any machine can continue.
7. **Spend the strong model where a mistake is expensive.** Decomposition, the case list's approval, review of
   high-risk diffs, and diagnosis after two failures. Nothing else.
8. **Measure, then route.** Every run is logged with its tool, model, duration and verdict. Routing changes
   follow the measured pass rates, not impressions.

---

## 4. The pipeline for one work package

A work package from the master plan becomes a chain of packets. Each row is one session.

| Stage | Role | Default tier | Reads | Produces | Accepted when |
|---|---|---|---|---|---|
| P0 Plan | architect (or a `lead` packet for XL packages) | A | The WP card, the catalog row, the claims file | The packets for this WP, the risk tier, the claim | The architect has written it |
| P1 Study | `study` | C | Form index, the desktop form by range, the web files | `orchestration/work/<WP>/study.md` | Citation check passes with every citation quoted; the architect skims the Gaps section |
| P2 Cases | `cases` | C | The study, the verification playbook | `orchestration/work/<WP>/cases.md` (frozen T01 to T18 list) | The architect approves it: this is the contract (10 minutes of reading) |
| P3 Red tests | `tests` | C | Cases, study, neighbouring tests | Unit, database and browser tests; `red.md` | Tests fail on current code for the stated reason; type check passes |
| P4 Implement | `implement` | C (B for risk A) | Study, cases, red tests | API and domain code | Locked tests pass; module gates pass |
| P5 Screen | `ui` | C | Study (screen, keyboard, rules), cases | The page and its components | Browser cases T01 and T17 pass |
| P6 Verify | `verify` | B | Cases; the running stack | `orchestration/work/<WP>/verify.md` with the three numbers | No failing or blocked case, or each one explained |
| P7 Review | `review`, a different model family from P4 | B | The diff, study, cases | Findings and a verdict | Verdict is APPROVE, or findings are fixed by a `fix` packet |
| P8 Records | `records` | C | verify.md, the packet | Catalog row, backlog, gap rows, regenerated views | `validate_plan.py` and `docs_check.py` pass |
| P9 Merge | architect | A | Result summaries, CI, and for risk A the diff itself | The pull request, the merge decision | CI green; the review depth for the risk tier is done |

Rules of the chain:

- P1 and P2 need no Docker and no build: they run anywhere, in parallel, for several packages at once. They are
  where the cheap models save the most.
- P3 to P6 need the test stack. One browser stack runs at a time on a 16 GB machine (section 8).
- A stage that fails its checks is re-run once with the failures listed in its prompt. A second failure
  escalates one tier (`--tier B`). A third stops the package for the architect's diagnosis.
- Reports use the same chain with the report addendum (`docs/agent-prompts/lite/00b-REPORT-ADDENDUM.md`); P4 is
  a read-only resolver and P5 its own route directory.
- A small defect (the WP-09 kind) collapses P1 to P3 into one `tests` packet and P4 to P5 into one `fix` packet.

---

## 5. Quality ladder

Cheapest check first. A rung is skipped only where the table says so. Detail in [QUALITY.md](QUALITY.md).

| Rung | Check | Cost | Catches |
|---|---|---|---|
| 1 | Path guard: changes only inside the packet's allow list; tests locked for implementers; desktop source, CI and this machinery always locked | Free | Scope creep, edited tests, touched authority |
| 2 | Content guard: skipped or focused tests, deleted tests, conflict markers, hook bypass, secrets, baseline growth | Free | Test weakening, sloppy merges |
| 3 | Citation check: every quoted desktop line exists and contains the quote | Free | Invented behaviour and line numbers |
| 4 | Red then green: new tests fail before the change and pass after | Local compute | Tests that prove nothing; code that does nothing |
| 5 | Repository gates: lint, type checks, format, size budget, kernel conformance, route policies, plan and docs validators | Local compute | Standards violations, unscoped routes, rounding bypasses |
| 6 | Cross-model review by a different model family | Tier B tokens | Wrong logic that passes weak tests |
| 7 | CI: full database suite and the real-stack browser run | Free on GitHub | Interactions between modules, timing |
| 8 | Architect review of the diff | Tier A tokens | What scripts cannot see. Always for risk A; one in three for risk B; on a failed rung for risk C |
| 9 | Desktop oracle: golden vectors compiled from the desktop's own code | CI or this Windows machine | Arithmetic that differs from the desktop |
| 10 | Owner: UAT on a cutover tenant | Human | Everything else |

Risk tiers decide rungs 6 and 8: **A** for anything that writes money, weight, stock, year-end balances,
tenant scope, sign-in, backups or migrations; **B** for reports and screens over those tables and for shared
components; **C** for study documents, captions, keyboard fixes and records. The tier is set per work package in
section 9 and may only be raised by a packet, never lowered.

---

## 6. Context and documents

**What a worker receives.** One file, `.orch/prompt.md`, built by the dispatcher: the rules for every worker,
its role contract, the task, the enforced scope, the list of files to read first, inlined excerpts with line
numbers, the project skills that apply (from `.kiro/skills/`), and the report layout. For every desktop form the
packet names, the dispatcher also writes a **form index**: members with line ranges, message texts, captions,
tables written and read. A worker opens ranges, not files.

**What is durable, and where.**

| Thing | Where | Written by |
|---|---|---|
| Order of work, done levels | `docs/parity/LITE-MASTER-PLAN.md` | Architect (State cells), owner (decisions) |
| Status of slices and menus | `docs/master-parity-plan-2026-09-29/execution-backlog.json`, `docs/handbook/menu-catalog.jsonl` | `records` packets |
| Claims: who holds which package | `docs/parity/AGENT-PROGRESS.md` | Architect, in the branch's first commit |
| Packets | `orchestration/packets/<WP>.<stage>.md` | Architect or a lead |
| Study, cases, red list, verification | `orchestration/work/<WP>/` on the package's branch | Workers |
| Routing, tools, providers | `orchestration/config/` | Architect, on the owner's decision |
| Run records (prompt, log, result, summary), ledger | `<root>/state/` on each machine, outside the repository | Dispatcher |
| Provider keys | `<root>/state/providers.env`, never in git | The person who owns the keys |
| Handoff between days | `project-memory/HANDOFF.md` (two dated lines per merged package) | `records` packets |

**What the architect reads.** A run's `summary.md` (about 30 lines), the worker's `report.md`, the Gaps section of
a study, the case list, and diffs chosen by risk. It does not read worker logs unless a run failed twice.

**Handoff between sessions and machines.** A new architect session reads `CLAUDE.md`, loads the `dc-architect`
skill, runs `orch status --prs` and reads the claims file. Nothing else is needed: the previous session's memory
is not part of the system.

---

## 7. Models, tools and cost

**Three tiers**, defined in `orchestration/config/routing.json`:

| Tier | For | Today (16 Nov) | Intended |
|---|---|---|---|
| A | Architect work and risk-A review | `claude` with Opus, high effort | Same |
| B | Leads, cross-review, verify, fix | `claude` with Sonnet; `codex` as the different-family reviewer once signed in | Same, with Codex doing the cross-review |
| C | Study, cases, tests, routine implementation, screens, records | `claude` with Haiku (fallback, so the pipeline works before a decision) | A cheap provider through `opencode`, chosen by the bake-off in section 11 |

**Claude sessions, three ways**, cheapest first:

1. **In-session subagents** (`.claude/agents/dc-reviewer.md` on Sonnet, `dc-scout.md` on Haiku): for a
   second read of a diff or a lookup, with no process to manage.
2. **Headless sessions through the dispatcher** (`orch run` with tier A or B): for lead packets that need a
   worktree, guards and a ledger entry.
3. **An interactive lane lead**: a second Claude Code session in its own terminal or herdr pane, started in a
   package's worktree with the `dc-lead` skill, when a whole lane needs continuous judgment.

**Budget rules for the architect.**

- Work at the lowest model and effort that the step needs: Opus or Fable at high effort for decomposition and
  risk-A review; Sonnet for routine supervision turns.
- Launch workers as background commands. The architect is woken when a run ends and reads one summary.
- Never paste a file into the conversation that a packet can point to by path and line range.
- Review by exception: read a diff when the risk tier, a failed rung or a reviewer's finding calls for it.

**Measured, weekly.** From `state/ledger.jsonl`: first-pass rate per role and model, minutes per run, re-runs,
escalations, and defects by the rung that caught them. A model whose first-pass rate for a role stays under about
70 percent after ten packets is replaced for that role or the packets for that role are made smaller.

---

## 8. Concurrency, lanes and the merge queue

**This machine** (16 GB RAM, 8 cores, 292 GB free on D:): one browser stack at a time, plus up to three sessions
that only read, write or run database tests. Model calls are remote, so sessions are light; builds and browsers
are not. The full real-stack suite runs on GitHub CI.

**Lanes.** A lane is one work package moving through section 4. Up to three lanes are open at once, chosen so they
do not share files (the conflict map in `docs/agent-prompts/lite/README.md` lists the shared files):

| Lane | Typical content | Needs the stack |
|---|---|---|
| 1 | A voucher or master package (phases 1, 3, 4 of the master plan) | Yes, from P3 |
| 2 | A report package (phase 2) | Yes, from P3 |
| 3 | Study and cases for the next two packages; desktop oracle families (WP-41) | No |

**Merge queue.** One pull request with plan ids merges at a time. The `records` packet runs after the branch has
merged the newest `origin/main`, takes ids last, and regenerates the generated files. The architect opens the pull
request and watches CI. Who presses merge is the owner's decision (section 13).

**Other machines.** The Mac-side sessions use the same claims file and branch names. A package claimed there is
not taken here.

---

## 9. Work packages: risk tier and who leads

The order and dependencies are the master plan's. This table adds the risk tier and the staffing.

| WP | Menu or item | Risk | Staffing note |
|---|---|---|---|
| WP-01 | Approval Isu, Approval Rtn (PR #228 merged; follow-ups) | A | Lead for the blocked cases; cross-review required |
| WP-02 | Order Cancel (PR #238 open) | A | Review by the architect before merge |
| WP-04 | Idempotent voucher creates, remaining routes | A | One `implement` packet per module, each with a replay test |
| WP-05 | Cash and bank vouchers (PR #237 open) | A | Review by the architect before merge |
| WP-06 | User Create (PR #234 open) | A | Sign-in and sessions: review by the architect |
| WP-07 | Company | A | Lead designs the versioned writer and purge job |
| WP-08 | Data Backup | A | Secrets handling: lead writes the allowlist, architect reviews |
| WP-09 | Esc on nine screens (merged) | C | Done |
| WP-10 | Next-number race audit | B | One `tests` packet per voucher form, then `fix` |
| WP-11 | Sales Report and the shared RP_ALL engine (PR #236 draft) | B | Lead owns the engine design; workers add branches |
| WP-12 to WP-14 | Purchase, Approval, Order reports | B | Bulk workers on the engine |
| WP-15, WP-16 | Tag Stock, Stock Report | B | Study first: 10,813 and 6,407 lines |
| WP-17 | Cash Bank report | B | Bulk workers |
| WP-18 | HuId Report | B | Bulk workers; the pilot package (section 11) |
| WP-19 | Gst Report, 13 blocked cases | A | Statutory figures and a migration: lead |
| WP-20 | Ledger Report residuals | B | Bulk workers |
| WP-21 | Books | A | Wide blast radius: full suite on CI before merge |
| WP-22 | Year Create | B | Small; second pilot package |
| WP-23 | Balance TrFr | A | Lead; closing equals opening proven per account and item |
| WP-24 | Data Refresh part 2 | A | Lead classifies; workers implement the small repairs |
| WP-25 | Data Import | A | Last; synthetic `.mdb` |
| WP-26 to WP-31 | Sales, Sales Return, Purchase, Purchase Rtn, Wh Sales, Contra residuals | A | One lane at a time; cross-review and architect review |
| WP-32, WP-33, WP-35 | Tag Opening, Daily Rate, remaining blocked cases | B | Bulk workers |
| WP-34, WP-36 | Tag Print label files, master residuals | C | Bulk workers |
| WP-40, WP-41 | Desktop oracle harness and formula families | B | This Windows machine has the .NET Framework 4.8 compiler: vectors can be produced locally as well as on CI |
| WP-42, WP-43 | Report oracle, desktop automation | A | Owner's agreement first |
| WP-50 to WP-56 | Release, security, operations, cutover, performance, edition gate, UAT | A | Architect and owner; workers prepare evidence only |

---

## 10. Security and data

- `SECURITY-NOTICE.md` requires separate authorisation before source goes to a third-party AI service. The owner
  decides which providers are authorised (section 13); only those appear in `routing.json`.
- Worker worktrees come from a clone that never downloads Git LFS content: databases, archives and executables
  are pointer files there. The reference copy with real binaries stays in a separate clone.
- Workers are told never to open `.env` files, database files or parity captures, and the tool configurations
  deny it where the tool supports rules. Tests run only on the isolated database.
- Keys live in `<root>/state/providers.env`, outside every repository. Documents and logs name variables, never
  values.
- Workers cannot commit or push; the dispatcher commits, and only the architect pushes and opens pull requests.
  `main` is never pushed to.
- A plan whose terms forbid unattended use (the Alibaba Coding Plan today) is marked `automation: no` in the
  catalog and is used only by a person at a terminal.
- On 16 November 2026 the GitHub repository was public, which contradicts `SECURITY-NOTICE.md`. This is the
  owner's decision to make; it is listed first in section 13.

---

## 11. Rollout

| Phase | Content | Exit |
|---|---|---|
| 0 Setup | Dispatcher, roles, skills, configuration, machine setup, this plan | `orch doctor` passes; the dispatcher's tests pass; one real packet run end to end |
| 1 Pilot | WP-18 study, cases and tests; WP-22 end to end; a cross-review of one open pull request compared with the architect's own review | Three packages' worth of ledger rows; a list of what the guards missed |
| 2 Bake-off | The same three packets run on each candidate tier-C provider | A chosen tier-C provider written into `routing.json`, with its measured pass rate and cost |
| 3 One lane | One work package from P0 to merge with the chosen provider, the architect watching every rung | A merged pull request whose evidence the owner accepts |
| 4 Three lanes | Section 8 in full; weekly routing review | Master plan phases 1 to 4 complete: all 49 menus L1 |
| 5 Proof and go-live | Desktop oracle families (L2), then the production gates (L3) | The master plan's section 7 gates, owner sign-off |

**The bake-off (phase 2).** Three fixed packets: a study of a 2,700-line form, a `tests` packet and an
`implement` packet of about 300 lines. Each candidate runs them twice. Recorded: verdict, minutes, re-runs,
citation errors, and cost from the provider's own usage page. The choice is the cheapest candidate with at least
five passes in six.

---

## 12. State on 16 November 2026

**Built and verified on this machine**

- The dispatcher (`orchestration/bin/orch.mjs`) with thirteen automated tests, including end-to-end runs against
  a scripted worker: scope violations, invented citations, weakened tests, changed line endings and missing
  reports are all refused.
- **One real packet, end to end.** A Haiku session studied the HuId Report form (`RP_HUID.cs`, 2,731 lines) in
  12.3 minutes on the first attempt: 415 lines, 29 gaps, 250 citations, every one verified against the desktop
  source by its quote. The record is in [`work/README.md`](work/README.md).
- The form index on real desktop forms (`RP_HUID.cs`, `MS_UPDATE.cs`).
- Role contracts for ten roles; packet format; routing, tool and provider configuration.
- Claude Code supervisor skills and two subagents. OpenCode loads the worker agent definition with its deny
  rules (`opencode debug agents`).
- A second clone on drive D with LFS downloads skipped, and the tools: Node 24, pnpm, git, GitHub CLI, Python
  3.12, OpenCode 2.3.0, Codex CLI 0.169.0. `pnpm install` works on native Windows; the Python plan and
  documentation gates pass.

**Not yet done**

- No cheap provider is connected, so tier C falls back to Claude Haiku. The OpenCode and Codex command lines are
  written from each tool's own help output and have not run a real packet.
- Only the `study` role has run with a real model. The other roles have contracts and no run yet.
- Docker cannot start until WSL 2 is installed (an administrator step, see [SETUP.md](SETUP.md)); until then
  database and browser tests run only on CI. Stages P3 to P6 are therefore unproven on this machine.
- One repository gate, `pnpm docs:refs`, cannot pass on native Windows because it runs POSIX shell snippets;
  [SETUP.md](SETUP.md) section 5 lists what was measured. Full local gates on Windows need an Ubuntu WSL
  distribution.
- herdr is not installed.

---

## 13. Decisions for the owner

| # | Decision | Default until decided |
|---|---|---|
| 1 | Repository visibility: public today, private required by `SECURITY-NOTICE.md` | Nothing is changed by any session |
| 2 | Which third-party providers may receive source code | Only Claude (the fallback) runs packets |
| 3 | The tier-C provider: OpenCode Go, DeepSeek, OpenRouter, or another | Decided by the bake-off once keys exist |
| 4 | Who merges green pull requests: the owner, or the architect session | The owner; sessions never merge |
| 5 | Study notes and case lists are committed under `orchestration/work/` (this replaces the private notes file of the master plan's runbook step S3) | Committed, as this plan describes |
| 6 | WSL 2 and Docker on this laptop, with their disks on drive D | Not installed until someone runs the administrator step |

---

## 14. Where this layer changes an existing rule

- `AGENTS.md` tells a session to start through `kiro-cli` and pick the next slice. A dispatched worker does
  neither: its packet is its whole job. The section "Dispatched worker sessions" in `AGENTS.md` says so.
- The master plan has one session carry a package from study to pull request. Here the package is a chain of
  packets by different sessions, and the claim, the pull request and the merge belong to the architect.
- The master plan keeps study notes outside the repository. Here they are committed with the package (decision 5).

Everything else in `AGENTS.md`, the master plan and the handbooks applies unchanged.
