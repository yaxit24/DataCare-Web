import json, sys, collections
# Summarise parity-compare artifacts: per case, per table, list differing columns + row presence.
out = []
agg = collections.Counter()
for f in sys.argv[1:]:
    d = json.load(open(f))
    out.append(f"=== {d['desktop'].get('database')}  totals={d['totals']}")
    for c in d['cases']:
        out.append(f"-- {c['caseId']}  desktop {c['desktopVoucher']}  web {c['webVoucher']}  "
                   f"fields={c['totals']['fieldsCompared']} diffs={c['totals']['fieldDifferences']} "
                   f"missingRows={c['totals']['rowsMissing']} extraRows={c['totals']['rowsExtra']}")
        for t in c['tables']:
            tag = t['presentOn']
            if tag == 'desktop':
                out.append(f"   {t['table']:18} WEB NEVER WROTE ({t['desktopRows']} desktop rows)")
                agg[('never-wrote', t['table'])] += 1
                continue
            if tag == 'web':
                out.append(f"   {t['table']:18} WEB-ONLY ({t['webRows']} rows)")
                agg[('web-only', t['table'])] += 1
                continue
            cols = collections.OrderedDict()
            for x in t['differences']:
                cols.setdefault(x['column'], []).append(f"{x['desktop']!s}->{x['web']!s}")
                agg[('field', t['table'] + '.' + x['column'])] += 1
            if cols or t['missingRows'] or t['extraRows'] or t['missingColumns']:
                s = f"   {t['table']:18} rows d{t['desktopRows']}/w{t['webRows']}"
                if t['missingRows']: s += f" missing={len(t['missingRows'])}"
                if t['extraRows']: s += f" extra={len(t['extraRows'])}"
                if t['missingColumns']: s += f" schemaMissingCols={t['missingColumns']}"
                out.append(s)
                for k, v in cols.items():
                    out.append(f"      {k}: {'; '.join(v[:3])}{' ...' if len(v) > 3 else ''}")
print('\n'.join(out))
print('\n=== aggregate (class, table/column): occurrences')
for k, v in sorted(agg.items(), key=lambda kv: (-kv[1], kv[0])):
    print(f"{v:3}  {k[0]:12} {k[1]}")
