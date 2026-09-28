#!/bin/bash
# Usage (inside withpg.sh): withapp.sh <command...>
# Boots the built API (:4410, dev mode with demo seed) and Next (:4411), runs the command, tears down.
W=/projects/sandbox/work
WEB=/projects/sandbox/DataCare-Web/web
source $W/env.sh
mkdir -p $W/logs
export NODE_ENV=development PORT=4410 APP_TENANT_ID=${E2E_TENANT:-e2e} DEMO_TENANT=${E2E_TENANT:-e2e} SEED_DEMO=1 \
  DEMO_PASSWORD='E2e-Demo-Passw0rd!2026' JWT_SECRET=0123456789abcdef0123456789abcdef0123456789abcdef
(cd $WEB/apps/api && exec node dist/server.js) > $W/logs/api.log 2>&1 &
API_PID=$!
(cd $WEB/apps/web && PORT=4411 exec npx next start -p 4411 -H 127.0.0.1) > $W/logs/web.log 2>&1 &
WEB_PID=$!
for i in $(seq 1 60); do curl -sf http://127.0.0.1:4410/health >/dev/null && curl -sf -o /dev/null http://127.0.0.1:4411/login && break; sleep 1; done
curl -s http://127.0.0.1:4410/health; echo
bash -c "$*"
rc=$?
kill $API_PID $WEB_PID 2>/dev/null; sleep 1; pkill -f "next start -p 4411" 2>/dev/null; pkill -f "dist/server.js" 2>/dev/null
exit $rc
