# Packet queue (23 November 2026)

Run order for the cheap-model dispatcher. The order follows the owner's priority from
`ROADMAP-2026-11-23.md`. First come the desktop Lite parity chains. Then come the two integrity items that break
normal use: the F-04 login lockout and the WP-04 replay batches. Each record step runs last in its chain.

Every packet file is in `orchestration/packets/` and passes `orch.mjs check`.

`dependsOn` is enforced by the dispatcher through the ledger, which lives in `~/dc-wt/orch-state/ledger.jsonl`. A
packet whose dependency has not passed (or partially passed) is refused. The loop then moves on, so a failed step
only stops its own chain.

The `WP-20.study`, `WP-32.study` and `WP-35.study` packets are already in the ledger as `partial`. Their cases
packets can run now.

## Order

**Suggested model** is a preference. By default the dispatcher picks from the role's tier in
`config/routing.json`: tier C is Qwen4 Max, then Kimi, then Codex; tier B is Claude Sonnet first, then Kimi and the
others. Set `FORCE_MODEL=1` in the loop to force the suggested model; a forced model gets no fallback when its
quota runs out.

| # | Packet | Role | Suggested model | dependsOn | Branch | Port |
|---|---|---|---|---|---|---|
| 1 | WP-11.browser | tests | Kimi K2.7 Code | — | agent/wp11-sales-report-screen | — |
| 2 | WP-35.cases | cases | Qwen4 Max | WP-35.study (partial, done) | agent/wp35-blocked-residuals | — | (already started outside the loop on 2026-11-23 17:26; not in the loop list)
| 3 | WP-20.cases | cases | Qwen4 Max | WP-20.study (partial, done) | agent/wp20-ledger-residuals | — | (already started outside the loop on 2026-11-23 17:26; not in the loop list)
| 4 | WP-32.cases | cases | Qwen4 Max | WP-32.study (partial, done) | agent/wp32-tag-opening-residuals | — | (already started outside the loop on 2026-11-23 17:26; not in the loop list)
| 5 | WP-55.tests | tests | Kimi K2.7 Code | — | agent/wp55-lite-edition-gate | — |
| 6 | WP-41.f2.study | study | Codex gpt-6-astra (exact quotes) | — | agent/wp41-f2-tax-hsn | — |
| 7 | WP-11.ui | ui | Kimi K2.7 Code | WP-11.browser | agent/wp11-sales-report-screen | 55611 / 4711-4712 |
| 8 | WP-35.tests | tests | Kimi K2.7 Code | WP-35.cases | agent/wp35-blocked-residuals | (55637 in brief) |
| 9 | WP-35.implement | implement | Kimi K2.7 Code | WP-35.tests | agent/wp35-blocked-residuals | 55635 |
| 10 | WP-32.tests | tests | Kimi K2.7 Code | WP-32.cases | agent/wp32-tag-opening-residuals | (55634 in brief) |
| 11 | WP-32.implement | implement | Kimi K2.7 Code | WP-32.tests | agent/wp32-tag-opening-residuals | 55632 |
| 12 | WP-51.f04.tests | tests | Kimi K2.7 Code | — | agent/wp51-login-rate-limit | — |
| 13 | WP-51.f04.implement | implement | Kimi K2.7 Code | WP-51.f04.tests | agent/wp51-login-rate-limit | — |
| 14 | WP-20.tests | tests | Kimi K2.7 Code | WP-20.cases | agent/wp20-ledger-residuals | (55623 in brief) |
| 15 | WP-20.implement | implement | Kimi K2.7 Code | WP-20.tests | agent/wp20-ledger-residuals | 55620 |
| 16 | WP-35.browser | tests | Kimi K2.7 Code | WP-35.implement | agent/wp35-blocked-residuals | — |
| 17 | WP-32.implement-print | implement | Kimi K2.7 Code | WP-32.implement | agent/wp32-tag-opening-residuals | 55633 |
| 18 | WP-32.browser | tests | Kimi K2.7 Code | WP-32.implement-print | agent/wp32-tag-opening-residuals | — |
| 19 | WP-32.ui | ui | Kimi K2.7 Code | WP-32.browser | agent/wp32-tag-opening-residuals | 55631 / 4731-4732 |
| 20 | WP-20.browser | tests | Kimi K2.7 Code | WP-20.implement | agent/wp20-ledger-residuals | — |
| 21 | WP-20.ui | ui | Kimi K2.7 Code | WP-20.browser | agent/wp20-ledger-residuals | 55621 / 4721-4722 |
| 22 | WP-11.verify | verify | Claude (tier B) | WP-11.ui | agent/wp11-sales-report-screen | 55612 / 4713-4714 |
| 23 | WP-35.verify | verify | Claude (tier B) | WP-35.browser | agent/wp35-blocked-residuals | 55636 / 4735-4736 |
| 24 | WP-20.verify | verify | Claude (tier B) | WP-20.ui | agent/wp20-ledger-residuals | 55622 / 4723-4724 |
| 25 | WP-04.idem-a.tests | tests | Kimi K2.7 Code | — | agent/wp04-idem-lite | (55603 in brief) |
| 26 | WP-04.idem-a.implement | implement | Kimi K2.7 Code | WP-04.idem-a.tests | agent/wp04-idem-lite | 55601 |
| 27 | WP-04.idem-b.tests | tests | Kimi K2.7 Code | WP-04.idem-a.implement | agent/wp04-idem-lite | (55604 in brief) |
| 28 | WP-04.idem-b.implement | implement | Kimi K2.7 Code | WP-04.idem-b.tests | agent/wp04-idem-lite | 55602 |
| 29 | WP-11.records | records | Hy4 Flash | WP-11.verify | agent/wp11-sales-report-screen | — |
| 30 | WP-35.records | records | Hy4 Flash | WP-35.verify | agent/wp35-blocked-residuals | — |
| 31 | WP-04.idem.records | records | Hy4 Flash | WP-04.idem-b.implement | agent/wp04-idem-lite | — |

**Supervisor steps inside the queue.**
- Before each `*.records` packet: merge `origin/main` into that branch. Records take N and G ids as max + 1.
- After each verify packet: Claude reviews the branch and opens the PR. Risk A, Claude in depth: WP-35, WP-32, WP-20,
  WP-04, WP-51, WP-41.
- WP-32 has no verify or records packet yet. Write them after `WP-32.ui` passes.
- WP-20 records waits for its study pass 2, which covers the summaries and the In Out prints.
- Push a branch with `node orchestration/bin/orch.mjs push orchestration/packets/<packet>.md`.

**Parallelism.**
- Different branches can run at the same time. Run at most three sessions, and only one browser or `ui` / `verify`
  run at a time (8 GB machine).
- The ports above do not collide.
- Each new branch creates a worktree under `~/dc-wt/orchwt/` (1-2 GB). The dispatcher refuses below 4 GB free.

## The loop

Run it with bash (not zsh) from `~/dc-wt/orchwt/specs-batch`, after the supervisor has committed these packet files. Without that
commit, the packets still read from this directory.

```bash
cd ~/dc-wt/orchwt/specs-batch
export PATH=~/.opencode/bin:~/.nvm/versions/node/v24.22.2/bin:$PATH
export DATACARE_WT_ROOT=~/dc-wt/orchwt DATACARE_STATE_ROOT=~/dc-wt/orch-state
FORCE_MODEL=${FORCE_MODEL:-0}

# id | runner | model   (runner/model are used only when FORCE_MODEL=1)
QUEUE='
WP-11.browser|opencode|opencode-go/kimi-k2.7-code
WP-55.tests|opencode|opencode-go/kimi-k2.7-code
WP-41.f2.study|codex|gpt-6-astra
WP-11.ui|opencode|opencode-go/kimi-k2.7-code
WP-35.tests|opencode|opencode-go/kimi-k2.7-code
WP-35.implement|opencode|opencode-go/kimi-k2.7-code
WP-32.tests|opencode|opencode-go/kimi-k2.7-code
WP-32.implement|opencode|opencode-go/kimi-k2.7-code
WP-51.f04.tests|opencode|opencode-go/kimi-k2.7-code
WP-51.f04.implement|opencode|opencode-go/kimi-k2.7-code
WP-20.tests|opencode|opencode-go/kimi-k2.7-code
WP-20.implement|opencode|opencode-go/kimi-k2.7-code
WP-35.browser|opencode|opencode-go/kimi-k2.7-code
WP-32.implement-print|opencode|opencode-go/kimi-k2.7-code
WP-32.browser|opencode|opencode-go/kimi-k2.7-code
WP-32.ui|opencode|opencode-go/kimi-k2.7-code
WP-20.browser|opencode|opencode-go/kimi-k2.7-code
WP-20.ui|opencode|opencode-go/kimi-k2.7-code
WP-11.verify|claude|sonnet
WP-35.verify|claude|sonnet
WP-20.verify|claude|sonnet
WP-04.idem-a.tests|opencode|opencode-go/kimi-k2.7-code
WP-04.idem-a.implement|opencode|opencode-go/kimi-k2.7-code
WP-04.idem-b.tests|opencode|opencode-go/kimi-k2.7-code
WP-04.idem-b.implement|opencode|opencode-go/kimi-k2.7-code
'
# Records packets are run by hand after the supervisor merges origin/main into the branch:
#   WP-11.records, WP-35.records, WP-04.idem.records  (suggested: --runner opencode --model openrouter/tencent/hy4-flash)

mkdir -p ~/dc-wt/orch-state/queue-logs
echo "$QUEUE" | while IFS='|' read -r id runner model; do
  [ -z "$id" ] && continue
  last=$(grep "\"packet\":\"$id\"" ~/dc-wt/orch-state/ledger.jsonl | tail -1 | grep -oE '"verdict":"[a-z]+"' | cut -d'"' -f4)
  if [ "$last" = pass ] || [ "$last" = partial ]; then echo "skip $id ($last)"; continue; fi
  extra=()
  [ "$FORCE_MODEL" = 1 ] && extra=(--runner "$runner" --model "$model")
  echo "=== $(date '+%F %T') $id"
  node orchestration/bin/orch.mjs run "orchestration/packets/$id.md" --attempts 2 --commit --accept-partial "${extra[@]}" \
    > ~/dc-wt/orch-state/queue-logs/$id.log 2>&1
  echo "    exit $? -> $(grep -m1 -E '^# (PASS|PARTIAL|FAIL|BLOCKED)' ~/dc-wt/orch-state/queue-logs/$id.log || tail -1 ~/dc-wt/orch-state/queue-logs/$id.log)"
done
```

- The loop can be re-run at any time. It skips packets that have already passed or partly passed.
- A packet whose dependency failed exits with `has not passed on this machine`, and the loop moves to the next one.
- Read `~/dc-wt/orch-state/queue-logs/<id>.log` and the run's `summary.md` for each result.
- `partial` means the worker could not run a database or browser test here. CI must run those tests on the PR before
  anyone trusts them.
