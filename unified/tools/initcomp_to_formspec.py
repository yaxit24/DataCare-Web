#!/usr/bin/env python3
"""initcomp_to_formspec.py — mine WinForms layout that lives in InitializeComponent() C# code
(not in .resx). ~164 flagship forms (TR_SALE, TR_PURC, TR_TAG_OPBL, masters…) keep their entire
control tree as code: `this.X = new Type()`, `this.X.Location = new Point(x,y)`, `.Size`,
`.TabIndex`, `.Text`, and `this.Parent.Controls.Add(this.X)` for the container/tab hierarchy.

Emits, per form: ordered control list (name/type/kind/location/size/tabIndex/text), section/tab
containers (from Controls.Add), grids + their column counts, and by-kind tallies — the same shape
as resx_to_formspec.py so both feed one React/report codegen. macOS-only, no Windows dependency.

Output: project-memory/catalogs/layouts/<FORM>.initcomp.json  + initcomp-index.json
"""
import glob, json, os, re

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..'))
SRC = os.path.join(ROOT, 'extracted_code', 'DataCareNext', 'DataCareNext')
OUTDIR = os.path.join(ROOT, 'project-memory', 'catalogs', 'layouts')

RE_NEW = re.compile(r'(\w+)\s*=\s*new\s+([\w.]+)\(')  # ILSpy: `name = new Type();` (no this.)
RE_LOC = re.compile(r'\(\(Control\)(\w+)\)\.Location\s*=\s*new\s+[\w.]*Point\((-?\d+),\s*(-?\d+)\)')
RE_SIZE = re.compile(r'\(\(Control\)(\w+)\)\.Size\s*=\s*new\s+[\w.]*Size\((-?\d+),\s*(-?\d+)\)')
RE_TAB = re.compile(r'\(\(Control\)(\w+)\)\.TabIndex\s*=\s*(\d+)')
RE_TEXT = re.compile(r'(?:^|[\s(])(\w+)\.Text\s*=\s*"((?:[^"\\]|\\.){0,80})"', re.M)
RE_ADD = re.compile(r'\(\(Control\)(\w+)\)\.Controls\.Add\(\(Control\)\(object\)(\w+)\)')

WIDGET = [
    ('grid', re.compile(r'Grid|FlexGrid', re.I)),
    ('tab', re.compile(r'Tab(Control|Page|Item)|XtraTabControl|SuperTab', re.I)),
    ('combo', re.compile(r'Combo', re.I)),
    ('masked', re.compile(r'Mask', re.I)),
    ('date', re.compile(r'DateTime|DatePicker|DateEdit', re.I)),
    ('check', re.compile(r'Check', re.I)),
    ('radio', re.compile(r'Radio|Option', re.I)),
    ('button', re.compile(r'Button', re.I)),
    ('textbox', re.compile(r'TextBox|TextEdit|TextBoxX', re.I)),
    ('label', re.compile(r'Label', re.I)),
    ('panel', re.compile(r'Panel|GroupBox|GroupControl|GroupPanel', re.I)),
]


def kind(t):
    for k, rx in WIDGET:
        if rx.search(t or ''):
            return k
    return 'other'


def parse(path):
    txt = open(path, encoding='utf-8', errors='ignore').read()
    if 'InitializeComponent' not in txt:
        return None
    ctrls = {}

    def C(name):
        return ctrls.setdefault(name, {'name': name, 'type': '', 'location': '', 'size': '', 'tabIndex': '', 'text': ''})
    for m in RE_NEW.finditer(txt):
        C(m.group(1))['type'] = m.group(2)
    for m in RE_LOC.finditer(txt):
        C(m.group(1))['location'] = f'{m.group(2)},{m.group(3)}'
    for m in RE_SIZE.finditer(txt):
        C(m.group(1))['size'] = f'{m.group(2)},{m.group(3)}'
    for m in RE_TAB.finditer(txt):
        C(m.group(1))['tabIndex'] = m.group(2)
    for m in RE_TEXT.finditer(txt):
        c = C(m.group(1))
        if not c['text']:
            c['text'] = m.group(2)
    # container hierarchy
    children = {}
    for m in RE_ADD.finditer(txt):
        children.setdefault(m.group(1), []).append(m.group(2))
    # keep only real visual controls (have a type + at least one layout/text prop)
    out = []
    for c in ctrls.values():
        if not c['type']:
            continue
        if not (c['location'] or c['size'] or c['tabIndex'] or c['text']):
            continue
        c['kind'] = kind(c['type'])
        out.append(c)
    out.sort(key=lambda c: int(c['tabIndex']) if c['tabIndex'].isdigit() else 9999)
    kinds = {}
    for c in out:
        kinds[c['kind']] = kinds.get(c['kind'], 0) + 1
    grids = [c['name'] for c in out if c['kind'] == 'grid']
    tabs = [c['name'] for c in out if c['kind'] == 'tab']
    # grid column hint: count DataGridView*/GridColumn/C1.*Column/ColumnHeader `new` in the file
    gridCols = len(re.findall(r'new\s+[\w.]*(?:DataGridView\w*Column|GridColumn|C1\.\w+Column|ColumnHeader)\(', txt))
    return {'form': os.path.basename(path)[:-3], 'controlCount': len(out), 'byKind': kinds,
            'grids': grids, 'tabs': tabs, 'gridColumns': gridCols,
            'containers': {k: v for k, v in children.items() if len(v) > 1},
            'controls': out}


def main():
    os.makedirs(OUTDIR, exist_ok=True)
    index = []
    for f in sorted(glob.glob(os.path.join(SRC, '*.cs'))):
        spec = parse(f)
        if not spec or spec['controlCount'] == 0:
            continue
        json.dump(spec, open(os.path.join(OUTDIR, spec['form'] + '.initcomp.json'), 'w'), indent=1)
        index.append({'form': spec['form'], 'controlCount': spec['controlCount'], 'byKind': spec['byKind'],
                      'grids': len(spec['grids']), 'tabs': len(spec['tabs']), 'gridColumns': spec['gridColumns']})
    index.sort(key=lambda x: -x['controlCount'])
    json.dump(index, open(os.path.join(OUTDIR, 'initcomp-index.json'), 'w'), indent=1)
    rich = [i for i in index if i['controlCount'] >= 15]
    print(f'forms_parsed={len(index)} rich(>=15 controls)={len(rich)} '
          f'total_controls={sum(i["controlCount"] for i in index)}')
    print(f'output_dir={OUTDIR}')
    for i in index[:10]:
        inp = sum(i['byKind'].get(k, 0) for k in ('textbox', 'combo', 'masked', 'date', 'check', 'radio'))
        print(f"  {i['form']}: {i['controlCount']} controls ({inp} inputs, {i['byKind'].get('grid',0)} grids/"
              f"{i['gridColumns']} cols, {i['byKind'].get('tab',0)} tabs, {i['byKind'].get('button',0)} buttons)")


if __name__ == '__main__':
    main()
