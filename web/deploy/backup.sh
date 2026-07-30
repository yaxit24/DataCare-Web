#!/usr/bin/env bash
# Daily logical backup of the DataCareNext Postgres DB (right-sized: pg_dump + retention).
# Schedule via cron: 0 1 * * *  /app/deploy/backup.sh >> /var/log/datacare-backup.log 2>&1
set -euo pipefail

BACKUP_DIR="${BACKUP_DIR:-/var/backups/datacare}"
RETENTION_DAYS="${RETENTION_DAYS:-14}"
PGHOST="${PGHOST:-postgres}"
PGUSER="${PGUSER:-datacare}"
PGDATABASE="${PGDATABASE:-datacare}"
STAMP="$(date +%Y%m%d-%H%M%S)"
OUT="${BACKUP_DIR}/datacare-${STAMP}.dump"

mkdir -p "${BACKUP_DIR}"
echo "[backup] ${STAMP} -> ${OUT}"
# custom format (-Fc) = compressed + selective restore
pg_dump -h "${PGHOST}" -U "${PGUSER}" -d "${PGDATABASE}" -Fc -f "${OUT}"
echo "[backup] size: $(du -h "${OUT}" | cut -f1)"

# prune old backups
find "${BACKUP_DIR}" -name 'datacare-*.dump' -mtime "+${RETENTION_DAYS}" -delete || true
echo "[backup] done; retained last ${RETENTION_DAYS} days"

# Restore (manual):
#   pg_restore -h "$PGHOST" -U "$PGUSER" -d datacare --clean --if-exists "<dump-file>"
# Off-host copy (recommended): sync ${BACKUP_DIR} to object storage (S3/B2) — deferred lever (ADR-0002).
