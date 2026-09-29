#!/bin/bash
# Fresh desktop-vs-web differential on Next23 / Next25 real vouchers (never previously compared: prior 70 cases were Live24).
set -u
cd /projects/sandbox/DataCare-Web/web/apps/api
source /projects/sandbox/work/env.sh
OUT=/projects/sandbox/work/diff
mkdir -p $OUT
export PARITY_MSSQL_HOST=127.0.0.1 PARITY_MSSQL_SERVER=127.0.0.1 PARITY_MSSQL_PORT=11433 PARITY_MSSQL_USER=sa PARITY_MSSQL_PASSWORD='ParityProbe#2026x' PARITY_MSSQL_ENCRYPT=false
export PARITY_PG_URL="$MIGRATE_DATABASE_URL" PARITY_PG_RUNTIME_URL="$DATABASE_URL" PARITY_STRICT=${PARITY_STRICT:-1}
run_db() {
  local DB=$1 TEN=$2 CASES=$3
  echo "################ $DB -> tenant $TEN"
  export PARITY_MSSQL_DATABASE=$DB PARITY_TENANT=$TEN PARITY_COMPANY=01 PARITY_OUT_DIR=$OUT/$DB
  mkdir -p $OUT/$DB
  # wipe the tenant so the run is reproducible
  psql -q -d datacare -U datacare -c "DO \$\$DECLARE r record; BEGIN FOR r IN SELECT c.relname FROM pg_class c JOIN pg_namespace n ON n.oid=c.relnamespace JOIN pg_attribute a ON a.attrelid=c.oid AND a.attname='tenant_id' WHERE n.nspname='public' AND c.relkind='r' LOOP EXECUTE format('DELETE FROM %I WHERE tenant_id=%L', r.relname, '$TEN'); END LOOP; END\$\$;"
  node integration/parity-import-masters.mjs > $OUT/$DB/import.log 2>&1; echo "import rc=$? $(tail -2 $OUT/$DB/import.log | tr '\n' ' ')"
  PARITY_CASES="$CASES" PARITY_CASE_MAP_OUT=$OUT/$DB/casemap.json node integration/parity-replay-generic.mjs > $OUT/$DB/replay.log 2>&1; echo "replay rc=$?"; cat $OUT/$DB/replay.log | tail -15
  [ -f $OUT/$DB/casemap.json ] || return
  DC=$(node -e "console.log(JSON.stringify(require('$OUT/$DB/casemap.json').desktopCases))")
  WC=$(node -e "console.log(JSON.stringify(require('$OUT/$DB/casemap.json').webCases))")
  PARITY_CASES="$DC" node integration/parity-extract-mssql.mjs > $OUT/$DB/xm.log 2>&1; echo "extract-mssql rc=$? $(tail -1 $OUT/$DB/xm.log)"
  PARITY_CASES="$WC" PARITY_LOCATION=00 node integration/parity-extract-pg.mjs > $OUT/$DB/xp.log 2>&1; echo "extract-pg rc=$? $(tail -1 $OUT/$DB/xp.log)"
  D=$(ls -t $OUT/$DB/desktop-*.json | head -1); W=$(ls -t $OUT/$DB/web-*.json | head -1)
  PARITY_OPERATOR=eval-$DB node integration/parity-compare.mjs $D $W > $OUT/$DB/compare.log 2>&1; echo "compare rc=$?"; tail -40 $OUT/$DB/compare.log
}
run_db Next23 eval-n23 '[{"caseId":"n23-sale-026-00001","book":"026","vchNo":"00001"},{"caseId":"n23-sale-026-00002","book":"026","vchNo":"00002"},{"caseId":"n23-est-032-00001","book":"032","vchNo":"00001"},{"caseId":"n23-purc-035-00001","book":"035","vchNo":"00001"},{"caseId":"n23-wh-034-00004","book":"034","vchNo":"00004"},{"caseId":"n23-wh-034-00005","book":"034","vchNo":"00005"},{"caseId":"n23-wh-034-00006","book":"034","vchNo":"00006"}]'
run_db Next25 eval-n25 '[{"caseId":"n25-purc-035-00001","book":"035","vchNo":"00001"},{"caseId":"n25-wh-034-00001","book":"034","vchNo":"00001"},{"caseId":"n25-wh-034-00002","book":"034","vchNo":"00002"}]'
