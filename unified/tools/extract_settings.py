#!/usr/bin/env python3
"""
extract_settings.py — build the authoritative settings catalog for the web replica.
Keys = CO_SET columns (from the restored real schema); enriched with whether UT_SETTING_MAIN.cs
references each + the nearest UI caption. Produces project-memory/catalogs/settings-catalog.json.
macOS-only. Run: python3 unified/tools/extract_settings.py
"""
import json, re, os

SCHEMA = 'project-memory/catalogs/realdb-schema.json'
FORM = 'extracted_code/DataCareNext/DataCareNext/UT_SETTING_MAIN.cs'
OUT = 'project-memory/catalogs/settings-catalog.json'

cols = json.load(open(SCHEMA))['tables']['CO_SET']['columns']
text = open(FORM, encoding='utf-8', errors='replace').read()
lines = text.split('\n')

# index caption lines: line-no -> caption text
caps = [(i, m.group(1)) for i, ln in enumerate(lines) for m in [re.search(r'\.Text = "([^"]{3,40})"', ln)] if m]

def nearest_caption(key):
    # find first line referencing "KEY" then the closest .Text caption within +/-6 lines
    for i, ln in enumerate(lines):
        if f'"{key}"' in ln:
            best = None; bestd = 99
            for (ci, ctext) in caps:
                d = abs(ci - i)
                if d < bestd and d <= 6:
                    bestd = d; best = ctext
            return best
    return None

SKIP_CAP = {'E&xit', '&Delete', '&Cancel', '&Save', '&Print', 'SuperTabControl1', 'Setting Main'}
settings = []
ref = 0
for c in cols:
    key = c['col']
    if key in ('CO_CODE',):
        continue
    referenced = f'"{key}"' in text
    if referenced:
        ref += 1
    cap = nearest_caption(key) if referenced else None
    if cap in SKIP_CAP:
        cap = None
    settings.append({'key': key, 'type': c.get('type', ''), 'inForm': referenced, 'caption': cap})

out = {
    'source': 'CO_SET schema + UT_SETTING_MAIN.cs',
    'storageTable': 'CO_SET',
    'totalKeys': len(settings),
    'referencedInForm': ref,
    'settings': settings,
}
os.makedirs(os.path.dirname(OUT), exist_ok=True)
json.dump(out, open(OUT, 'w'), indent=1)
print(f'CO_SET setting keys={len(settings)}  referenced-in-form={ref}')
print('sample keys with captions:')
for s in [x for x in settings if x['caption']][:14]:
    print(f"  {s['key']:22} [{s['type']:12}] {s['caption']}")
print('keys without a captured caption:', ', '.join(s['key'] for s in settings if not s['caption'])[:200])
