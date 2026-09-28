#!/usr/bin/env python3
"""
gen_schema_gap_ddl.py — emit additive, idempotent DDL to make the web Postgres schema a complete
replica of the real desktop schema: create the 4 missing tables + add the 22 missing columns, using
the web conventions (tenant_id varchar(24) NOT NULL, row_id bigint via per-table sequence, numeric for
numbers, varchar(255) for strings, bytea for images) + RLS tenant_isolation. Output: /tmp/schema_gap.sql
"""
import json

gap = json.load(open('project-memory/catalogs/web-vs-real-schema-gap.json'))
real = json.load(open('project-memory/catalogs/realdb-schema-full.json'))['tables']

def pgtype(t, ln):
    t = t.lower()
    if t in ('int', 'bigint', 'smallint', 'tinyint', 'decimal', 'numeric', 'float', 'real', 'money', 'smallmoney'):
        return 'numeric'
    if t == 'date':
        return 'date'
    if t in ('datetime', 'datetime2', 'smalldatetime', 'datetimeoffset', 'time'):
        return 'timestamp'
    if t == 'bit':
        return 'boolean'
    if t in ('binary', 'varbinary', 'image', 'timestamp', 'rowversion'):
        return 'bytea'
    if t in ('text', 'ntext', 'xml'):
        return 'text'
    return 'varchar(255)'

lines = ['-- Additive schema-parity DDL (web -> desktop). Idempotent. Nullable additions preserve demo data.', 'BEGIN;', '']

# 1) missing tables
for t in gap['missingTables']:
    cols = real[t]['columns']
    pk = real[t].get('pk', [])
    seq = f'{t}_row_id_seq'
    lines.append(f'CREATE SEQUENCE IF NOT EXISTS "{seq}";')
    lines.append(f'CREATE TABLE IF NOT EXISTS "{t}" (')
    coldefs = ['  "tenant_id" varchar(24) NOT NULL',
               f'  "row_id" bigint NOT NULL DEFAULT nextval(\'"{seq}"\')']
    for c in cols:
        coldefs.append(f'  "{c["col"]}" {pgtype(c["type"], c["len"])}')
    coldefs.append('  PRIMARY KEY ("tenant_id","row_id")')
    lines.append(',\n'.join(coldefs))
    lines.append(');')
    lines.append(f'ALTER SEQUENCE "{seq}" OWNED BY "{t}"."row_id";')
    lines.append(f'ALTER TABLE "{t}" ENABLE ROW LEVEL SECURITY;')
    lines.append(f'DROP POLICY IF EXISTS tenant_isolation ON "{t}";')
    lines.append(f'CREATE POLICY tenant_isolation ON "{t}" USING (("tenant_id")::text = current_setting(\'app.tenant_id\', true));')
    # business unique index on the real PK (scoped by tenant) for upserts
    if pk:
        pkc = ','.join(f'"{c}"' for c in pk)
        lines.append(f'CREATE UNIQUE INDEX IF NOT EXISTS "{t}_bk_uq" ON "{t}" ("tenant_id",{pkc});')
    lines.append('')

# 2) missing columns on shared tables
realmap = {t: {c['col']: c for c in real[t]['columns']} for t in real}
for g in gap['columnGaps']:
    t = g['table']
    for col in g['missing']:
        c = realmap[t].get(col)
        if not c:
            continue
        lines.append(f'ALTER TABLE "{t}" ADD COLUMN IF NOT EXISTS "{col}" {pgtype(c["type"], c["len"])};')
    lines.append('')

lines.append('COMMIT;')
open('/tmp/schema_gap.sql', 'w').write('\n'.join(lines))
n_tables = len(gap['missingTables'])
n_cols = sum(len(g['missing']) for g in gap['columnGaps'])
print(f'DDL written: {n_tables} tables + {n_cols} columns → /tmp/schema_gap.sql ({len(lines)} lines)')
