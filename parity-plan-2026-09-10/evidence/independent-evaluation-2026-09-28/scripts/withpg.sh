#!/bin/bash
# Usage: withpg.sh <command...>  — starts Postgres for the duration of the command.
W=/projects/sandbox/work
rm -f $W/pgdata/postmaster.pid
su postgres -s /bin/bash -c "pg_ctl -D $W/pgdata -o '-c listen_addresses=127.0.0.1' -w -l $W/pgdata/server.log start" >/dev/null || { echo PG_START_FAIL; tail $W/pgdata/server.log; exit 1; }
export PGHOST=127.0.0.1 PGPORT=55433 PGUSER=postgres
bash -c "$*"
rc=$?
su postgres -s /bin/bash -c "pg_ctl -D $W/pgdata -m fast -w stop" >/dev/null
exit $rc
