#!/bin/bash
# Usage: withmssql.sh <command...> — runs SQL Server (persistent data dir) for the duration of the command.
W=/projects/sandbox/work
mkdir -p $W/mssqldata && chmod 777 $W/mssqldata $W/dcdb
podman rm -f dc-mssql >/dev/null 2>&1
podman run -d --name dc-mssql -e ACCEPT_EULA=Y -e 'MSSQL_SA_PASSWORD=ParityProbe#2026x' \
  -p 11433:1433 -v $W/mssqldata:/var/opt/mssql:Z -v $W/dcdb:/dcdb:Z \
  mcr.microsoft.com/mssql/server:2022-latest >/dev/null 2>$W/logs/mssql-run.err || { cat $W/logs/mssql-run.err; exit 1; }
for i in $(seq 1 60); do
  podman exec dc-mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'ParityProbe#2026x' -C -Q "select 1" >/dev/null 2>&1 && break
  sleep 2
done
for i in $(seq 1 60); do
  n=$(podman exec dc-mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P 'ParityProbe#2026x' -C -h -1 -W -Q "SET NOCOUNT ON; select count(*) from sys.databases where state_desc='ONLINE' and name like 'Next%'" 2>/dev/null | tr -d '[:space:]')
  [ "$n" = "5" ] && break
  sleep 2
done
sleep 3
export SQLCMD="podman exec -i dc-mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P ParityProbe#2026x -C -W -s| -h -1"
bash -c "$*"
rc=$?
podman stop -t 10 dc-mssql >/dev/null 2>&1; podman rm -f dc-mssql >/dev/null 2>&1
iptables -t nat -F NETAVARK-HOSTPORT-DNAT 2>/dev/null
exit $rc
