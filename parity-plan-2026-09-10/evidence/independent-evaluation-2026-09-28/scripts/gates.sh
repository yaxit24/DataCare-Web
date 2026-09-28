#!/bin/bash
cd /projects/sandbox/DataCare-Web/web
source /projects/sandbox/work/env.sh
L=/projects/sandbox/work/logs/gates
mkdir -p $L
run() { local name=$1; shift; "$@" > $L/$name.log 2>&1; local rc=$?; echo "== $name rc=$rc :: $(tail -3 $L/$name.log | tr '\n' ' ' | cut -c1-400)"; }
run lint-workspace node scripts/lint-workspace.mjs
run eslint npx eslint .
run typecheck-tests env NODE_OPTIONS=--max-old-space-size=6144 pnpm typecheck:tests
run format-check pnpm format:check
run docs-refs node scripts/check-doc-references.mjs
run register-check node scripts/check-completion-register.mjs
run settings-parity node scripts/check-settings-parity.mjs
run schema-readiness node scripts/check-schema-readiness.mjs
run fresh-provision node scripts/check-fresh-provision.mjs
run report-baselines node scripts/report-baselines.mjs
run g5-parity node scripts/check-g5-parity.mjs
run depth-parity node scripts/check-depth.mjs
run dead-cells node scripts/check-dead-cells.mjs
run kernel-conformance node scripts/check-kernel-conformance.mjs
run contracts node scripts/check-contracts.mjs
run parity-measure node scripts/parity-measure.mjs
run route-coverage pnpm --filter @datacare/web test:routes
