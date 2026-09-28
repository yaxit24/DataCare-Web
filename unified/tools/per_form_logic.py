#!/usr/bin/env python3
"""per_form_logic.py — mine per-form BUSINESS LOGIC from the decompiled C# forms (the logic the web
must reproduce): SQL write-ops (INSERT/UPDATE/DELETE table+columns), SELECT tables, F-key (F1..F12)
lookup handlers, validation message-boxes, calc formulas (weight/fine/labour/amount arithmetic),
Timers (background jobs), serial-port/hardware (weighing scale), and event-handler counts.

Output: project-memory/catalogs/form-logic/<FORM>.logic.json + form-logic-index.json
macOS-only (regex/AST over the already-decompiled .cs). Feeds the web port of each form's behaviour.
"""
import glob, json, os, re

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..'))
SRC = os.path.join(ROOT, 'extracted_code', 'DataCareNext', 'DataCareNext')
OUTDIR = os.path.join(ROOT, 'project-memory', 'catalogs', 'form-logic')
TABLES_TXT = os.path.join(ROOT, 'extraction_output', 'database_tables.txt')

KNOWN = {l.strip().upper() for l in open(TABLES_TXT)} if os.path.exists(TABLES_TXT) else set()

RE_INSERT = re.compile(r'INSERT\s+INTO\s+([A-Za-z_][A-Za-z0-9_]*)\s*\(([^)]*)\)', re.I)
RE_INSERT2 = re.compile(r'INSERT\s+INTO\s+([A-Za-z_][A-Za-z0-9_]*)', re.I)
RE_UPDATE = re.compile(r'UPDATE\s+([A-Za-z_][A-Za-z0-9_]*)\s+SET', re.I)
RE_DELETE = re.compile(r'DELETE\s+FROM\s+([A-Za-z_][A-Za-z0-9_]*)', re.I)
RE_FROM = re.compile(r'\bFROM\s+([A-Za-z_][A-Za-z0-9_]*)', re.I)
RE_FKEY = re.compile(r'KeyCode\s*==\s*(?:\(Keys\)\s*)?(?:Keys\.F(\d{1,2})|(11[2-9]|12[0-3]))')
RE_MSGBOX = re.compile(r'MessageBox\.Show\(|Interaction\.MsgBox\(')
RE_TIMER = re.compile(r'new\s+[\w.]*Timer\(|\.Tick\s*\+=')
RE_SERIAL = re.compile(r'SerialPort|System\.IO\.Ports|WeighingScale|weight.*scale', re.I)
RE_HANDLER = re.compile(r'\+=\s*new\s+[\w.]*(?:EventHandler|KeyEventHandler|KeyPressEventHandler|CancelEventHandler)\(')
RE_CALC = re.compile(r'\b(\w*(?:fine|nwt|gwt|net|amt|amount|wt|touch|labour|lbr|rate|west|wast|total|tax|round)\w*)\s*=\s*([^;{}\n]{3,90});', re.I)


def vknum(m):
    return f'F{m.group(1)}' if m.group(1) else f'F{int(m.group(2)) - 111}'


def parse(path):
    txt = open(path, encoding='utf-8', errors='ignore').read()
    ins = {}
    for m in RE_INSERT.finditer(txt):
        t = m.group(1).upper()
        if t in KNOWN:
            cols = [c.strip().strip('[]"') for c in m.group(2).split(',') if c.strip()]
            ins.setdefault(t, set()).update(c for c in cols if re.fullmatch(r'[A-Za-z_][A-Za-z0-9_]*', c))
    for m in RE_INSERT2.finditer(txt):
        t = m.group(1).upper()
        if t in KNOWN:
            ins.setdefault(t, set())
    upd = sorted({m.group(1).upper() for m in RE_UPDATE.finditer(txt) if m.group(1).upper() in KNOWN})
    dele = sorted({m.group(1).upper() for m in RE_DELETE.finditer(txt) if m.group(1).upper() in KNOWN})
    fromt = sorted({m.group(1).upper() for m in RE_FROM.finditer(txt) if m.group(1).upper() in KNOWN})
    fkeys = sorted({vknum(m) for m in RE_FKEY.finditer(txt)}, key=lambda s: int(s[1:]))
    tables = sorted(set(ins) | set(upd) | set(dele) | set(fromt))
    calc = []
    for m in RE_CALC.finditer(txt):
        expr = re.sub(r'\s+', ' ', m.group(2)).strip()
        if any(op in expr for op in '*/+-') and not expr.startswith('"'):
            calc.append(f'{m.group(1)} = {expr}')
    calc = sorted(set(calc))[:40]
    return {
        'form': os.path.basename(path)[:-3],
        'tables': tables,
        'writes': {'INSERT': {t: sorted(c) for t, c in ins.items()}, 'UPDATE': upd, 'DELETE': dele},
        'selectTables': fromt,
        'fKeys': fkeys,
        'messageBoxes': len(RE_MSGBOX.findall(txt)),
        'timers': len(RE_TIMER.findall(txt)),
        'serialPort': bool(RE_SERIAL.search(txt)),
        'handlers': len(RE_HANDLER.findall(txt)),
        'calcSample': calc,
        'loc': txt.count('\n') + 1,
    }


def main():
    os.makedirs(OUTDIR, exist_ok=True)
    index = []
    for f in sorted(glob.glob(os.path.join(SRC, '*.cs'))):
        s = parse(f)
        # keep forms that actually do something (write or read a table, or have handlers)
        if not (s['tables'] or s['writes']['INSERT'] or s['handlers']):
            continue
        json.dump(s, open(os.path.join(OUTDIR, s['form'] + '.logic.json'), 'w'), indent=1)
        index.append({'form': s['form'], 'loc': s['loc'], 'tables': len(s['tables']),
                      'inserts': len(s['writes']['INSERT']), 'updates': len(s['writes']['UPDATE']),
                      'deletes': len(s['writes']['DELETE']), 'fKeys': len(s['fKeys']),
                      'messageBoxes': s['messageBoxes'], 'timers': s['timers'], 'serialPort': s['serialPort'],
                      'handlers': s['handlers'], 'calc': len(s['calcSample'])})
    index.sort(key=lambda x: -(x['inserts'] + x['updates'] + x['deletes'] + x['handlers']))
    json.dump(index, open(os.path.join(OUTDIR, 'form-logic-index.json'), 'w'), indent=1)
    tot = lambda k: sum(i[k] for i in index)
    print(f'forms={len(index)}  writeOps(INS/UPD/DEL)={tot("inserts")}/{tot("updates")}/{tot("deletes")}  '
          f'handlers={tot("handlers")}  fKeyForms={sum(1 for i in index if i["fKeys"])}  '
          f'serialPortForms={sum(1 for i in index if i["serialPort"])}  timerForms={sum(1 for i in index if i["timers"])}')
    print(f'output_dir={OUTDIR}')
    for i in index[:8]:
        print(f"  {i['form']}: {i['loc']} LOC · tables {i['tables']} · INS {i['inserts']}/UPD {i['updates']}/DEL {i['deletes']} · {i['handlers']} handlers · {i['fKeys']} F-keys · {i['messageBoxes']} msgbox" + (' · SCALE' if i['serialPort'] else ''))


if __name__ == '__main__':
    main()
