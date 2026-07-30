#!/usr/bin/env python3
"""Deep desktop↔web coverage analysis. For each of the 204 desktop forms, parse the tables it
writes/manages (from the catalog .md, which lists INSERT/UPDATE + DELETE/reversed = the tables the
form owns), then check whether the web actually WRITES those tables. Emits a coverage matrix."""
import os, re, glob, json

FORMS_DIR = 'project-memory/catalogs/forms'
WEB_SRC = 'web/apps/api/src'
# cross-cutting tables every voucher touches — not a form's identity
GENERIC = {'DELETE_DATA','USER_DATA','TEMP_BOOK_DATA','REMARK_DATA','SRNO_MAST','ROJ_MEL_DATA','USER_SET','TAG_SET','RATE_CUT_ISU_REC','AUDIT_LOG'}

# 1) tables the WEB writes (INSERT/UPDATE raw SQL + posting `table:'X'` + masters configs)
web_w = set()
for f in glob.glob(WEB_SRC+'/**/*.ts', recursive=True):
    s = open(f, encoding='utf-8', errors='ignore').read()
    web_w |= set(re.findall(r'INSERT INTO "([A-Z_][A-Z0-9_]+)"', s))
    web_w |= set(re.findall(r'UPDATE "([A-Z_][A-Z0-9_]+)"', s))
    web_w |= set(re.findall(r"table:\s*'([A-Z_][A-Z0-9_]+)'", s))
    web_w |= set(re.findall(r"tables:\s*\[([^\]]+)\]", s) and re.findall(r"'([A-Z_][A-Z0-9_]+)'", s) or [])

def parse(md):
    t = open(md, encoding='utf-8', errors='ignore').read()
    mod = re.search(r'\*\*Module:\*\* (\w+)', t)
    ins = re.search(r'\*\*INSERT:\*\* (.+)', t)
    upd = re.search(r'\*\*UPDATE:\*\* (.+)', t)
    dels = re.search(r'\*\*DELETE:\*\* (.+)', t)
    owned = set()
    for m in (ins, upd, dels):
        if m:
            owned |= {x for x in re.findall(r'[A-Z_][A-Z0-9_]+', m.group(1)) if x not in ('INSERT','UPDATE','DELETE')}
    return (mod.group(1) if mod else '?'), owned

rows = []
for md in sorted(glob.glob(FORMS_DIR+'/*.md')):
    name = os.path.basename(md)[:-3]
    if name == 'README': continue
    module, owned = parse(md)
    core = owned - GENERIC
    covered = core & web_w
    pct = round(100*len(covered)/len(core)) if core else (100 if name.startswith(('Cls','Module','DC','MDI','Auth','IRN','Policy','Data','Translator','Olocker','Error')) else 0)
    rows.append({'name':name,'module':module,'core':sorted(core),'covered':sorted(covered),'pct':pct})

by_mod = {}
for r in rows:
    by_mod.setdefault(r['module'], []).append(r)

print(f"FORMS={len(rows)}  web_writes_tables={len(web_w)}")
for mod in sorted(by_mod):
    rs = by_mod[mod]
    full = sum(1 for r in rs if r['pct']==100 and r['core'])
    partial = sum(1 for r in rs if 0<r['pct']<100)
    none = sum(1 for r in rs if r['pct']==0)
    nodata = sum(1 for r in rs if not r['core'])
    print(f"  {mod:12} n={len(rs):3}  fullData={full:3} partial={partial:3} none={none:3} (no-core-table={nodata})")

# forms with REAL data tables that the web does NOT cover at all (pct 0, has core tables)
missing = [r for r in rows if r['pct']==0 and r['core']]
print(f"\nFORMS WITH UNCOVERED DATA TABLES: {len(missing)}")
for r in sorted(missing, key=lambda x:(x['module'],x['name'])):
    print(f"  [{r['module']}] {r['name']}: {','.join(r['core'][:6])}")
