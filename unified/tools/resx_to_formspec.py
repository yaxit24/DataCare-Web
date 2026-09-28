#!/usr/bin/env python3
"""resx_to_formspec.py — WinForms .resx -> per-form control/layout manifest.

Many DataCareNext forms serialize their FULL control tree into the .resx as
  >>name.Name / >>name.Type / name.Location / name.Size / name.TabIndex /
  >>name.ZOrder / name.Text
We parse those into an ordered (by TabIndex) manifest per form:
  [{name, type, location, size, tabIndex, zOrder, text}, ...]
plus a summary count of controls by widget kind (TextBox/Combo/Grid/Button/Tab).

Output: project-memory/catalogs/layouts/<FORM>.layout.json  (+ index.json)
100% exact for the large "localizable" forms (MS_ACCT.resx etc.); partial for
forms whose layout lives in InitializeComponent (see initcomp_to_formspec.py).
"""
import glob, json, os, re
import xml.etree.ElementTree as ET

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..'))
RESX_DIRS = [
    os.path.join(ROOT, 'extracted_code', 'DataCareNext'),
    os.path.join(ROOT, 'extracted_code', 'NextDm'),
    os.path.join(ROOT, 'unified', 'resources', 'DataCareNext'),
    os.path.join(ROOT, 'unified', 'resources', 'NextDm'),
]
OUTDIR = os.path.join(ROOT, 'project-memory', 'catalogs', 'layouts')

WIDGET = [
    ('textbox', re.compile(r'TextBox', re.I)),
    ('combo', re.compile(r'Combo', re.I)),
    ('masked', re.compile(r'Mask', re.I)),
    ('grid', re.compile(r'Grid|FlexGrid', re.I)),
    ('button', re.compile(r'Button', re.I)),
    ('tab', re.compile(r'Tab(Control|Page)', re.I)),
    ('check', re.compile(r'Check', re.I)),
    ('label', re.compile(r'Label', re.I)),
    ('date', re.compile(r'DateTime|DatePicker', re.I)),
]


def kind(t):
    for k, rx in WIDGET:
        if rx.search(t or ''):
            return k
    return 'other'


def parse(resx):
    try:
        root = ET.parse(resx).getroot()
    except Exception:
        return None
    ctrls = {}
    for d in root.findall('data'):
        name = d.get('name')
        if not name or '.' not in name:
            continue
        val = (d.findtext('value') or '').strip()
        base, prop = name.split('.', 1)
        base = base.lstrip('>')
        ctrls.setdefault(base, {})[prop] = val
    out = []
    for k, v in ctrls.items():
        t = v.get('Type', '')
        if not t and 'Name' not in v and 'Location' not in v and 'TabIndex' not in v:
            continue
        out.append({
            'name': k, 'type': t, 'kind': kind(t),
            'location': v.get('Location', ''), 'size': v.get('Size', ''),
            'tabIndex': v.get('TabIndex', ''), 'zOrder': v.get('ZOrder', ''),
            'text': v.get('Text', ''),
        })
    out = [c for c in out if c['type'] or c['location'] or c['tabIndex']]
    out.sort(key=lambda c: int(c['tabIndex']) if c['tabIndex'].lstrip('-').isdigit() else 9999)
    return out


def main():
    os.makedirs(OUTDIR, exist_ok=True)
    seen, index = set(), []
    for d in RESX_DIRS:
        for f in sorted(glob.glob(os.path.join(d, '*.resx'))):
            form = os.path.basename(f)[:-5]
            if form in seen:
                continue
            spec = parse(f)
            if not spec:
                continue
            seen.add(form)
            counts = {}
            for c in spec:
                counts[c['kind']] = counts.get(c['kind'], 0) + 1
            json.dump({'form': form, 'controlCount': len(spec), 'byKind': counts,
                       'controls': spec},
                      open(os.path.join(OUTDIR, form + '.layout.json'), 'w'), indent=1)
            index.append({'form': form, 'controlCount': len(spec), 'byKind': counts})
    index.sort(key=lambda x: -x['controlCount'])
    json.dump(index, open(os.path.join(OUTDIR, 'index.json'), 'w'), indent=1)
    rich = [i for i in index if i['controlCount'] >= 15]
    print(f'forms_with_layout={len(index)} rich_forms(>=15 controls)={len(rich)} '
          f'total_controls={sum(i["controlCount"] for i in index)}')
    print(f'output_dir={OUTDIR}')
    for i in index[:8]:
        inputs = sum(i['byKind'].get(k, 0) for k in ('textbox', 'combo', 'masked', 'date', 'check'))
        print(f"  {i['form']}: {i['controlCount']} controls "
              f"({inputs} inputs, {i['byKind'].get('grid',0)} grids, "
              f"{i['byKind'].get('tab',0)} tabs, {i['byKind'].get('button',0)} buttons)")


if __name__ == '__main__':
    main()
