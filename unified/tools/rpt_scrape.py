#!/usr/bin/env python3
"""rpt_scrape.py — per-report structure extractor for Crystal .rpt binaries.

Runs on macOS with NO Crystal runtime. A .rpt is an OLE2 compound file; the
report's table and field names are stored inside the "Contents" stream as
**latin-1 ASCII** identifier tokens (NOT UTF-16, and NOT dotted TABLE.FIELD).
We therefore:
  - decode latin-1, pull UPPER_SNAKE identifier runs,
  - classify tokens that intersect the known DB-table list as `tables`,
  - treat the remaining column-shaped identifiers as `fields`.
Output: extraction_output/rpt_specs.json  (list of per-report specs)

This upgrades the flat all_rpt_fields.txt (one alphabetical union of column
names) into a per-report {tables, fields} spec — enough to build the correct
SQL + column set for each of the 255 reports.
"""
import glob, json, os, re

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..'))
REPORT_DIRS = [os.path.join(ROOT, 'unified', 'reports'), os.path.join(ROOT, 'Report')]
OUT = os.path.join(ROOT, 'extraction_output', 'rpt_specs.json')
TABLES_TXT = os.path.join(ROOT, 'extraction_output', 'database_tables.txt')

IDENT_RE = re.compile(r'[A-Z][A-Z0-9_]{2,}')
RUN_RE = re.compile(r'[\x20-\x7e]{3,}')


def load_tables():
    if os.path.exists(TABLES_TXT):
        return {l.strip().upper() for l in open(TABLES_TXT) if l.strip()}
    return set()


KNOWN = load_tables()
# tokens that are structural noise, not columns
NOISE = {'AND', 'NOT', 'NULL', 'THE', 'FOR', 'SUM', 'ABS', 'INT', 'STR', 'VAL'}


def scrape(path):
    raw = open(path, 'rb').read()
    text = raw.decode('latin-1', 'ignore')
    idents = set()
    for run in RUN_RE.findall(text):
        idents.update(IDENT_RE.findall(run))
    tables = sorted(idents & KNOWN)
    # fields = column-shaped tokens: contain '_' or len>=4, minus tables/noise
    fields = sorted(t for t in idents - set(tables) - NOISE
                    if ('_' in t or len(t) >= 4))
    return {
        'report': os.path.basename(path)[:-4],
        'sizeKB': round(len(raw) / 1024, 1),
        'tableCount': len(tables),
        'tables': tables,
        'fieldCount': len(fields),
        'fields': fields,
    }


def main():
    seen, specs = set(), []
    for d in REPORT_DIRS:
        for f in sorted(glob.glob(os.path.join(d, '*.rpt'))):
            name = os.path.basename(f)
            if name in seen:
                continue
            seen.add(name)
            try:
                specs.append(scrape(f))
            except Exception as e:  # noqa
                specs.append({'report': name[:-4], 'error': str(e)})
    os.makedirs(os.path.dirname(OUT), exist_ok=True)
    json.dump(specs, open(OUT, 'w'), indent=1)
    ok = [s for s in specs if 'error' not in s]
    with_t = [s for s in ok if s.get('tableCount', 0) > 0]
    with_f = [s for s in ok if s.get('fieldCount', 0) > 0]
    tot_f = sum(s.get('fieldCount', 0) for s in ok)
    print(f'reports_scraped={len(ok)} with_tables={len(with_t)} with_fields={len(with_f)} '
          f'total_field_refs={tot_f} avg_fields={tot_f / max(len(with_f),1):.1f}')
    print(f'known_tables={len(KNOWN)}  output={OUT}')
    for s in sorted(ok, key=lambda x: -x.get('fieldCount', 0))[:6]:
        print(f"  {s['report']}: {s['tableCount']} tables {s['tables'][:6]}"
              f"{'…' if s['tableCount']>6 else ''} · {s['fieldCount']} fields")


if __name__ == '__main__':
    main()
