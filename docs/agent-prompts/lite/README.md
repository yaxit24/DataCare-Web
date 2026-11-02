# DataCare-Web — Lite edition: agent prompt pack

Built 2 Nov 2026 against `origin/main` (re-run `python3 docs/agent-prompts/lite/build.py` after a fetch). Purpose: independent agents each take one Lite menu that has no
browser feature module yet, and drive it to "done" (desktop behaviour, frozen case list, run through the real screen).

## How to launch one agent

```bash
cd ~/DataCare-Web && kiro-cli chat --agent datacare
# then paste (or ask it to read) ONE file:
#   docs/agent-prompts/lite/launch/NN-<slug>.FULL.md
```

`launch/*.FULL.md` = `00-GENERIC.md` + (`00b-REPORT-ADDENDUM.md` for report menus) + the menu prompt, in one file.
`build.py` regenerates the menu prompts and the launch files from the live catalog (`python3 docs/agent-prompts/lite/build.py`) if `main` moves.

## State of the 23 menus (verified 2 Nov)

The progress page on `main` now shows Lite: 49 menus, 27 with a module, 24 with a module and no open defect, 0 done.
**Of your 23, three are not fresh builds:**

| Menu | Real state | Prompt |
|---|---|---|
| Approval Isu + Approval Rtn | **Already built, never pushed.** 24 commits in local worktree `~/dc-wt/lite-approval` (66 files, +12.6k lines, 2 feature modules, 2,229 lines of lifecycle tests). Uses N211/G224, now taken. Cherry-pick tested: first commit conflicts only in record/registration files. | 12 — *land it* |
| Stock Adjust | Open PR #197 by another session (N221/G234), updated 02:18 | 20 — *audit only* |
| Ledger Report | Open PR #195 (since 1 Nov 20:49). Claims **N219/G232, already used by Auto Item on main** | 21 — *audit only* |
| Tag Cancel | Module green already (coverage-map fix landed in #189). Only residual cases remain | 22 — *small finish, after #197* |

So there are **19 build/land prompts + 3 audit/finish prompts**. Approval Isu and Rtn share one agent (one form, one
writer, one branch). That is why 23 menus give 22 prompts.

## Dispatch table

| # | Menu | Form (desktop lines) | Type | Wave | Needs first |
|---|---|---|---|---|---|
| 12 | Approval Isu + Rtn | `TR_APR_ISU` (8,294) | **Land existing** | 1 | — (start first; others consume it) |
| 01 | Sales Report | `RP_ALL` sales branch | Report, **builds shared RP_ALL engine** | 1 | — |
| 04 | Tag Stock | `RP_TAG` (10,813) | Report | 1 | — |
| 09 | Party | `MS_ACCT` (9,651) | Master | 1 | — |
| 10 | Tag Print | `UT_TAG_PRINT` (6,267) | Utility + print | 1 | — |
| 11 | Order Cancel | `TR_SL_ORD_ADJ` (4,169) | Voucher | 1 | — |
| 21 | *Audit* Ledger Report | PR #195 | Audit | 1 (cheap, read-mostly) | — |
| 02 | Purchase Rpt | `RP_ALL` purchase branch | Report | 2 | 01 merged |
| 03 | Approval Rpt | `RP_ALL` approval branch | Report | 2 | 01 and 12 merged |
| 06 | Cash Bank | `RP_CASH_BANK` (4,813) | Report | 2 | — |
| 08 | HuId Report | `RP_HUID` (2,731) | Report | 2 | — |
| 20 | *Audit* Stock Adjust | PR #197 | Audit | 2 | #197 ready |
| 05 | Stock Report | `RP_STOCK` (6,407) | Report, new route | 3 | 04 merged (shared catalog row) |
| 07 | Gst Report | `RP_GST` (3,944) | Report (statutory) | 3 | — |
| 13 | Books | `MS_BOOK` (3,122) | Master, wide blast radius | 3 | — |
| 14 | Year Create | `MS_YEAR` (1,596) | Company utility | 3 | — |
| 16 | Company | `MS_COMPANY` (7,615) | Admin screen | 3 | coordinate with 14 on shared copy logic |
| 15 | Balance TrFr | `BtmSchm` (5,638) | Company utility, money-critical | 4 | 14 merged |
| 17 | Data Refresh | `MS_UPDATE` (33,074; operators see 6 buttons) | Utility, **scope decided**: 4 small repairs first, 2 giant ones classified | 3 | — |
| 22 | Tag Cancel (close) | `TR_TAG_CAN` | Small finish | 4 | #197 merged |
| 18 | Data Backup | `UT_BKP` (1,298) | **Scope decided**: Backup only (desktop hides Restore) | 3 | — |
| 19 | Data Import | `UT_IMPORT` (14,466; Lite path ≈535) | **Scope decided**: "Lite Soft" import only, atomic; lowest priority | 5 | everything else |

## Resource plan — read this before launching many agents

This Mac has **8 GB RAM and 8 cores**. A browser stack (Postgres container + production Next build + API + Chromium)
costs roughly 2–3 GB while building and ~1.5 GB running. The generic prompt therefore makes agents take one of **three
stack slots** (`~/.cache/datacare-stack-slots/slot-N`, ports 55501–55503 / 4611–4632) before building or running.
Reading, desktop study, case writing and coding need no slot, so you can run **6–7 agents at once**: only three of them
can be inside a browser run at any moment. Do not raise the slot count beyond 3 on this machine. Running 20 agents at
once will just thrash.

Existing stacks on the machine (not touched): web Postgres `5433`, the maintainer's `4410/4411`, `55433`, `55800`.

## Conflict map — where parallel PRs will collide

| Shared file | Who touches it | Handling |
|---|---|---|
| `docs/master-parity-plan-2026-09-29/execution-backlog.json`, `12-lineage-verification-2026-10-01.md` | every agent | N/G ids must be **contiguous** (`validate_plan.py`). Agents allocate ids **last**, after rebase. Two open PRs already collided on N219/G232. **Merge one PR at a time**; the next one rebases and renumbers. |
| `menu-catalog.jsonl` / `.md`, `standard-progress.md`, `coverage-map.json`, `run-features.mjs` | every agent | generated or line-oriented; agents regenerate (`docs_check.py --write`, `pnpm progress`), never hand-merge |
| `apps/api/src/routes/txn.ts` (8,360 lines, **at its size ceiling**) | all that add routes | one-line registration only; real routes go in new files |
| `reports/[report]/page.tsx` (1,742, **at ceiling**) | report agents | forbidden to grow; each report gets its own route directory (PR #195 is the model) |
| `modules/sales/salesOrder.ts` (2,372, at ceiling) | 11 | new code in a new file |
| `components/TagCancelForm.tsx`, `tagCancel.mjs`, `salesInvoice.mjs` | 12, 20, 22, #197 | 12 edits all three; 22 starts after #197 merges |
| `size-budget.json`, `kernel-conformance-baseline.json`, `depth-parity-baseline.json` | 12 and any new file over the cap | ceilings only fall; resolve by re-deriving (`--audit`) |
| `ops/seedCompany.ts` | 14, 16 | whoever merges first extracts the shared 17-table copy |
| `lib/nav.ts`, catalog rows of Stock Report / Tag Stock | 04, 05 | 05 starts after 04 merges |
| Shared RP_ALL engine | 01 creates; 02, 03 reuse | 02 and 03 wait for 01 |

**Suggested merge order:** 12 → 01 → 04 → (09, 10, 11, 06, 08 in any order) → 02 → 03 → 05 → 07 → 13 → 14 → 16 → 15 → 17 → 18 → 22 → 19.
CI on GitHub may be disabled by a billing failure (HANDOFF, 28 Oct): the local gate output quoted in each PR is the
evidence, so read it.

## Coordinator duties (you, or one agent you designate)

1. After each merge, tell waiting agents to rebase. Regenerating `standard-progress.md` is each agent's job, but check
   that the Lite row ("Module with no open defect") rises by the number of menus merged.
2. Watch for id collisions at PR time: `grep -o '"N[0-9]*"' execution-backlog.json | sort | uniq -d`.
3. Reject any PR that: marks a row `FULL` without all cases passing; claims desktop match; edits `containment.mjs`;
   lifts a baseline entry without the fixing change; uses `Browser-Test-Exempt`; has no quoted gate output.
4. Only Company delete (16) and physical-printer acceptance (10) still need you. Agents stop and ask there.

## Decisions already made (you delegated them on 2 Nov; the prompts carry them, agents do not re-ask)

Reasoned from the desktop source, with your goal in mind: the web should match what a Lite operator sees and does, with
the same depth, and ship quickly.

| Menu | Decision | Evidence in the desktop source |
|---|---|---|
| **Data Backup (18)** | Parity is **Backup only**. No restore, no Dattach. The restore containment is **not** touched. | `UT_BKP.cs:859` sets `BtnRestore.Visible = false` and nothing ever sets it true, so a Lite operator has never been able to restore here. `btnAttach` shows only when a SQL Server data path is configured and quits the app (SQL Server specific). |
| **Data Refresh (17)** | Build the **6 buttons an operator sees**: Account, Stock, Approval Adj, Image Data first (≈500 desktop lines), then classify Field Update and Old Field (≈27.7k lines) into apply / provably no-op on web data / migration-loader. No hidden `Ctrl+O` tools. Every repair is preview-first, one transaction, audited. | The other 12 buttons are `Visible = false` (`MS_UPDATE.cs:1535-1986`) and revealed only by `Ctrl+O` (`:2275-2301`); Mfg/Scheme only for those company types. |
| **Data Import (19)** | Build only the **"Lite Soft"** importer (5 steps, ≈535 lines), atomic, with preview, and **refuse a company that already has data** (the desktop silently deletes the tag tables). Reader is a pure-JS `.mdb` library, never a shell. Licence-state writes (`REF_NO`, `TRY_DATE`) are not ported. All other ~34 buttons (Wh, Retail, Plus, Chudi …) are other products' vendor-run migrations: not built. Done last. | `UT_IMPORT.cs:8413-8445`; the form is titled "Old Softwar Import" (`:3187`); the importers read Access `.mdb` files of the vendor's earlier products. |

What this costs you, stated plainly:
- **Restore is not a screen in the web**, same as the desktop. Recovery stays an IT procedure (DR runbook).
- **Importing from Retail/Wh/Plus Soft is not covered.** If you have customers coming from those, tell me and each becomes a small slice.
- **No real Lite Soft `.mdb` exists in the repo**, so one Data Import case is *blocked* until you supply a sanitized or synthetic sample. It stays in the denominator rather than being faked.

Still yours: **Company delete (16)**, because the desktop's cascade delete is unsafe in a hosted multi-tenant system and
no decision exists for a guarded equivalent. The agent builds everything else and records delete as blocked.
Physical label printers (10) stay pending acceptance (D29), as before.

## What I did and did not verify

Verified against `origin/main` by reading it: the catalog rows, desktop handler line numbers, existing web files and
their sizes, the open PRs, the unpushed Approval branch (and a trial cherry-pick), the harness env names, that every
command and path the generic prompt names exists, the size ceilings, the id-contiguity rule.
Not verified: I did not run any feature module, build or test; the per-menu "case emphasis" is guidance derived from the
catalog and form structure, not a substitute for each agent's own source-backed study; whether the Lite edition hides
specific buttons in `MS_UPDATE`, `BtmSchm`, `UT_IMPORT`, `MS_ACCT` and `RP_CASH_BANK` is left to the agents to settle
from the source (the prompts say so); templates `TagHuIdRpt` and `PartyMast` may not be in the repository.

## Not covered by this pack (known open defects with other owners)

Contra register (G37), Sales Order tender modes (G206), Wh Sales follow-up (PR #198), and the 65 Basic and Standard
menus (29 + 36) that have no module. I can write the Basic tier next.
