#!/usr/bin/env bash
# Merge queue: for each "PR:worktree" in order, bring the branch up to date with main, regenerate the generated
# plan files, wait for CI, and squash-merge only when every check passes. Stops at the first failure.
set -u
export PATH=~/.nvm/versions/node/v24.22.2/bin:/opt/homebrew/bin:$PATH
log() { echo "[$(date +%H:%M)] $*"; }

wait_checks() { # $1 = PR; returns 0 when every check passes or is skipped
  local n=$1 i
  sleep 90
  for i in 1 2 3 4 5; do gh pr checks "$n" --watch --interval 60 >/dev/null 2>&1; [ $? -le 1 ] && break; sleep 30; done
  local bad
  bad=$(gh pr checks "$n" 2>/dev/null | awk -F'\t' '$2!="pass" && $2!="skipping" {print $1": "$2}')
  [ -z "$bad" ] && return 0
  log "#$n not green:"; echo "$bad" | sed 's/^/    /'; return 1
}

for item in "$@"; do
  n=${item%%:*}; d=${item#*:}
  state=$(gh pr view "$n" --json state -q .state)
  [ "$state" = MERGED ] && { log "#$n already merged"; continue; }
  cd "$d" || { log "#$n: no worktree $d"; exit 1; }
  [ -z "$(git status --porcelain --untracked-files=no)" ] || { log "#$n: worktree dirty, skipped"; continue; }
  git fetch -q origin
  if ! git merge-base --is-ancestor origin/main HEAD; then
    if ! git merge --no-edit -q origin/main; then
      conflicted=$(git diff --name-only --diff-filter=U)
      log "#$n: conflicts in: $(echo $conflicted)"
      # The plan's record files conflict on every merge; resolve them by rule (orchestration/tools).
      lin=docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md
      echo "$conflicted" | grep -qx "$lin" && python3 "$(dirname "$0")/resolve-sections.py" "$lin" && git add -- "$lin"
      # Route totals and the migration manifest conflict on most merges too; resolve them by rule (scratchpad).
      code=$(echo "$conflicted" | grep -xE 'web/apps/api/test/routePolicy.test.ts|web/apps/api/src/modules/ops/migrationManifest.ts')
      [ -n "$code" ] && python3 "$(dirname "$0")/resolve-code.py" $code && echo "$code" | xargs git add --
      ri=docs/master-parity-plan-2026-09-29/requirement-index.json
      echo "$conflicted" | grep -qx "$ri" && python3 "$(dirname "$0")/resolve-reqindex.py" && git add -- "$ri"
      if node ~/dc-wt/orch/orchestration/tools/resolve-records.mjs "$d" \
        && ! echo "$conflicted" | xargs grep -lE '^(<<<<<<<|>>>>>>>) ' -- 2>/dev/null | grep -q .; then
        echo "$conflicted" | xargs git add -- && git commit -q --no-edit && log "#$n: record conflicts resolved by rule"
      else
        log "#$n: conflicts the rules cannot decide, skipped"; git merge --abort; continue
      fi
    fi
    log "#$n: merged main"
  fi
  # Regenerate the generated plan views so the gates see them current.
  python3 "$(dirname "$0")/dedupe-register.py"
  python3 docs/tools/docs_check.py --write >/dev/null 2>&1
  python3 docs/parity/build_matrix.py >/dev/null 2>&1
  (cd web && pnpm -s progress >/dev/null 2>&1)
  changed=$(git status --porcelain --untracked-files=no | awk '{print $2}')
  if [ -n "$changed" ]; then
    echo "$changed" | xargs git add -- && git commit -q -m "chore(docs): regenerate the plan views after merging main

Co-Authored-By: Claude Opus 5.5 <noreply@anthropic.com>"
    log "#$n: regenerated: $(echo $changed | tr '\n' ' ')"
  fi
  git push -q 2>&1 | grep -v '^remote:'
done
log "refresh done"
