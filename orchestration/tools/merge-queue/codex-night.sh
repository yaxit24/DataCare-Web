#!/usr/bin/env bash
# At 22:27 (Codex reset) run the planner's queue on Codex until its limit hits again; Claude verify packets on Sonnet.
export PATH=~/.opencode/bin:~/.nvm/versions/node/v24.22.2/bin:/opt/homebrew/bin:$PATH
export DATACARE_WT_ROOT=~/dc-wt/orchwt DATACARE_STATE_ROOT=~/dc-wt/orch-state
until [ "$(date +%H%M)" -ge 2227 ]; do sleep 60; done
cd ~/dc-wt/orchwt/specs-batch
mkdir -p ~/dc-wt/orch-state/queue-logs
for id in WP-35.implement WP-32.implement WP-35.browser WP-32.implement-print \
          WP-32.browser WP-32.ui WP-35.verify WP-51.f04.tests \
          WP-51.f04.implement WP-04.idem-a.tests WP-04.idem-a.implement WP-04.idem-b.tests WP-04.idem-b.implement; do
  last=$(grep "\"packet\":\"$id\"" ~/dc-wt/orch-state/ledger.jsonl 2>/dev/null | tail -1 | grep -oE '"verdict":"[a-z]+"' | cut -d'"' -f4)
  if [ "$last" = pass ] || [ "$last" = partial ]; then echo "skip $id ($last)"; continue; fi
  case $id in *.verify) r=(--runner claude --model sonnet);; *) r=(--runner codex --model gpt-6-astra);; esac
  echo "=== $(date '+%T') $id ${r[*]}"
  node orchestration/bin/orch.mjs run "orchestration/packets/$id.md" --attempts 2 --commit --accept-partial "${r[@]}" > ~/dc-wt/orch-state/queue-logs/$id.log 2>&1
  echo "    -> $(grep -m1 -E '^# (PASS|PARTIAL|FAIL|BLOCKED)' ~/dc-wt/orch-state/queue-logs/$id.log || tail -1 ~/dc-wt/orch-state/queue-logs/$id.log)"
  b=$(grep -m1 '"branch"' orchestration/packets/$id.md | cut -d'"' -f4); [ -n "$b" ] && git -C ~/dc-wt/orchwt/${b#agent/} push -q -u origin HEAD 2>&1 | grep -v '^remote:'
  grep -q 'usage limit' ~/dc-wt/orch-state/runs/*-$id/worker-*.log 2>/dev/null && { echo "codex limit reached, stop"; break; }
done
echo "=== done $(date +%T)"
