#!/usr/bin/env bash
# One dispatcher run: $1 packet, $2 runner, $3 model, $4 branch dir to push.
export PATH=~/.opencode/bin:~/.nvm/versions/node/v24.22.2/bin:/opt/homebrew/bin:$PATH
export DATACARE_WT_ROOT=~/dc-wt/orchwt DATACARE_STATE_ROOT=~/dc-wt/orch-state
cd ~/dc-wt/orch
echo "=== $1 on $2/$3 $(date +%H:%M)"
node orchestration/bin/orch.mjs run $( [ -f "$1" ] && echo "$1" || echo orchestration/packets/$1.md) --runner $2 --model $3 --attempts 2 --commit --accept-partial ${FORCE:+--force} 2>&1 | grep -vE '^\s*$' | tail -10
git -C ~/dc-wt/orchwt/$4 push -q -u origin HEAD 2>&1 | grep -v '^remote:'
echo "=== end $1 $(date +%H:%M)"
