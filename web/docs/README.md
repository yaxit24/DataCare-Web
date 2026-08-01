# Documentation index

Nine documents. Read in this order depending on what you need.

## Start here

| If you want to…                         | Read                                                                                                  |
| --------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| understand **how the system is built**  | **`TECHNICAL-REFERENCE.md`** — architecture, tenancy, posting, schema traps                           |
| **verify, measure or test** anything    | **`VERIFICATION-REFERENCE.md`** — method, recipes, controls, gates, process rules                     |
| know **where a specific module stands** | **`MODULE-VERIFICATION-CATALOGUE.md`** — per-module authority, tables, verified/not, next measurement |
| know **the overall position**           | **`STATE-OF-PARITY.md`** — measured web-vs-desktop assessment                                         |
| know **what is left before go-live**    | **`MIGRATION-COMPLETION-PLAN.md`** — nine phases with evidence, tests and exit criteria               |
| see **the first real comparison**       | **`FIRST-REAL-COMPARISON.md`** — one voucher, triaged four ways                                       |

## Working documents

| Document                                                  | Purpose                                                                       |
| --------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `GAP-ANALYSIS-AND-PLAN.md`                                | running record of findings, corrections and **retractions** — the audit trail |
| `ROJMEL-HANDBOOK.md`                                      | the Rojmel workstream in depth: coverage table, routine classification, queue |
| `PLAN-ROJMEL-FINAL-THREE.md`                              | the remaining implementable Rojmel work                                       |
| `PLAN-RATECUT-ROJMEL.md` · `PLAN-SALESORDER-ROJMEL.md`    | executed plans, kept as worked examples of the format                         |
| `VALIDATION-PLAN.md`                                      | the 11 test layers, each stating what it can and cannot prove                 |
| `PARITY-WINDOWS-PROCEDURE.md` · `WINDOWS-AGENT-PROMPT.md` | the Windows-side capture procedure                                            |

## The three things worth knowing before anything else

**1. Nothing has been compared to the desktop yet.** `g5:parity` is RED and that is correct. Every parity
claim in these documents is parity **by construction** — rules derived from the desktop's data and source,
with real defects found that way — not parity **by comparison**. The harness is ready and `Live24` holds 190
real sales. This is the highest-value remaining task.

**2. The method matters more than any single finding.** Count the output, then the source columns, then read
the source for structure, then take directions from the data. Every step exists because skipping it produced
a documented error — including one confident _wrong_ conclusion that the desktop was inconsistent, caused by
averaging across row types.

**3. Every ranking rests on one company and one fiscal year.** The live/dead classifications are facts about
`Live24`. The priorities are inferences from a single sample. A second customer database is the cheapest way
to test them, and would also unblock the migration rehearsal.

## Corrections and retractions

`GAP-ANALYSIS-AND-PLAN.md` keeps these deliberately rather than editing history, because the pattern in the
mistakes is more useful than any individual fix. The significant ones:

- **"15 tables have no write path"** → the real number was **3**. A single-line grep missed multi-line object
  literals.
- **"`KR_DETL` is not written"** → false, recorded as _verified_. Same defective grep; it survived the
  headline correction for weeks because a retracted **method** leaves behind conclusions drawn with it.
- **"`OP_LDR` is written per voucher, the web has a gap"** → it is a **year-end snapshot** written by the
  import utility, read by one report. Not a posting target.
- **"`IT_TYPE` separates Stock from Amount"** → it is the **metal** (`G`/`S`/`O`/`A`).
- **"The cash-book Rojmel convention cannot be derived"** → it derives cleanly **per row type**; the
  aggregate percentage hid it.
- **"Schema readiness is 96.9%"** → **100%**. The gate measured against a contract extracted from decompiled
  DDL that over-claimed 19 tables and found 64% of real columns.
- **Three commits pushed on a red suite** → caused by putting `vitest run` and `git commit` in one shell
  block. Fixed as a mechanism, not an instruction.
