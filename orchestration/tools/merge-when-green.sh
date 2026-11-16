#!/usr/bin/env bash
# Wait for a pull request's CI, then squash-merge it only if every condition of the merge protocol holds
# (docs/parity/LITE-MASTER-PLAN.md step S11). No model is involved. Usage: merge-when-green.sh <pr> <worktree>
set -u
pr="$1"; wt="$2"
cd "$wt" || exit 1
head_sha=$(git rev-parse HEAD)
title=$(gh pr view "$pr" --json title --jq .title)

gh pr checks "$pr" --watch --interval 30 >/dev/null 2>&1
rc=$?
echo "--- checks (exit $rc)"
gh pr checks "$pr" 2>&1 | cut -f1,2 | head -12
if [ "$rc" -ne 0 ]; then echo "RESULT: not merged, CI is not green"; exit 2; fi

read -r oid mergeable state < <(gh pr view "$pr" --json headRefOid,mergeable,state --jq '[.headRefOid,.mergeable,.state]|@tsv')
if [ "$state" != "OPEN" ]; then echo "RESULT: not merged, pull request is $state"; exit 3; fi
if [ "$oid" != "$head_sha" ]; then echo "RESULT: not merged, the remote head ($oid) is not the commit that was checked ($head_sha)"; exit 3; fi
if [ "$mergeable" != "MERGEABLE" ]; then echo "RESULT: not merged, GitHub reports $mergeable"; exit 3; fi
git fetch -q origin main
if ! git merge-base --is-ancestor origin/main HEAD; then echo "RESULT: not merged, main moved: merge origin/main into the branch and let CI run again"; exit 4; fi

if gh pr merge "$pr" --squash --subject "$title (#$pr)"; then
  echo "RESULT: merged #$pr"
  base=$(dirname "$(git rev-parse --path-format=absolute --git-common-dir)")
  git -C "$base" pull -q --ff-only origin main && echo "base clone now at: $(git -C "$base" log -1 --oneline | cut -c1-110)"
else
  echo "RESULT: merge command failed"; exit 5
fi
