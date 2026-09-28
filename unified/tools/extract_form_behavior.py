#!/usr/bin/env python3
"""
extract_form_behavior.py — mine the *behavior* of every decompiled WinForms form so the web
replica can reproduce it. For each form .cs it extracts, into catalogs/form-behavior/<FORM>.behavior.json:

  gridColumns  : the grid schema from `private const int cXxx = N;` (name -> column index)
  inlineSql    : reconstructed SQL query templates (concatenated literals joined by ? for interpolated vars)
  keyboard     : VK-code handlers mapped to key names (F1..F12, Enter, Esc, arrows, Ctrl/Shift/Alt combos)
  calc         : weight/fine/amount/touch/rate/labour arithmetic assignments (the jewellery math)
  validations  : MessageBox guard messages + the nearest preceding condition

macOS-only tooling (regex over C# already on disk). Run: python3 unified/tools/extract_form_behavior.py
"""
import json, os, re, glob

SRC = 'extracted_code/DataCareNext/DataCareNext'
OUT = 'project-memory/catalogs/form-behavior'
os.makedirs(OUT, exist_ok=True)

VK = {8:'Backspace',9:'Tab',13:'Enter',16:'Shift',17:'Ctrl',18:'Alt',19:'Pause',20:'CapsLock',
      27:'Esc',32:'Space',33:'PageUp',34:'PageDown',35:'End',36:'Home',37:'Left',38:'Up',39:'Right',
      40:'Down',45:'Insert',46:'Delete',
      112:'F1',113:'F2',114:'F3',115:'F4',116:'F5',117:'F6',118:'F7',119:'F8',120:'F9',121:'F10',122:'F11',123:'F12'}
for n in range(48,58): VK[n]=chr(n)          # 0-9
for n in range(65,91): VK[n]=chr(n)          # A-Z

RE_GRIDCOL = re.compile(r'private\s+const\s+int\s+(c\w+)\s*=\s*(\d+)\s*;')
RE_STRLIT  = re.compile(r'"((?:[^"\\]|\\.)*)"')
RE_SQLKW   = re.compile(r'\b(SELECT|INSERT\s+INTO|UPDATE|DELETE\s+FROM)\b', re.I)
RE_KEY     = re.compile(r'\(int\)e\.KeyCode\s*==\s*(\d+)')
RE_KEYS    = re.compile(r'Keys\.([A-Z][A-Za-z0-9]+)')
RE_MSGBOX  = re.compile(r'(?:MessageBox|Interaction|MyProject[\w.]*)\.(?:Show|MsgBox)\s*\(\s*(?:\(object\)\s*)?"((?:[^"\\]|\\.)*)"')
RE_CALC    = re.compile(r'^[^\n=]*\b(\w*(?:NWT|GWT|FINE|AMT|AMOUNT|TOUCH|RATE|_WT|LBR|WAST|WEST|MAKING|GHT|GST|TAX|QTY|PCS|NET|GROSS)\w*)\b[^\n=]*=[^\n=][^\n;]*[-+*/][^\n;]*;', re.I)

def reconstruct_sql(text):
    """find SQL statements + reconstruct the template by joining string literals with ? for vars."""
    out = []
    for m in RE_SQLKW.finditer(text):
        # find the enclosing statement: back to previous ; { } and forward to next ;
        start = max(text.rfind(';', 0, m.start()), text.rfind('{', 0, m.start()), text.rfind('}', 0, m.start())) + 1
        end = text.find(';', m.end())
        if end == -1 or end - start > 6000:
            continue
        stmt = text[start:end]
        lits = RE_STRLIT.findall(stmt)
        if not lits:
            continue
        sql = ' ? '.join(lits)
        sql = re.sub(r'\s+', ' ', sql).strip()
        sql = re.sub(r'(\s*\?\s*)+', ' ? ', sql)
        if RE_SQLKW.search(sql) and len(sql) > 20:
            out.append(sql)
    # dedup preserving order
    seen, uniq = set(), []
    for s in out:
        k = s[:120]
        if k not in seen:
            seen.add(k); uniq.append(s)
    return uniq[:50]

def keyboard_map(text):
    keys = {}
    for m in RE_KEY.finditer(text):
        code = int(m.group(1))
        name = VK.get(code, f'VK_{code}')
        ctx = text[m.end():m.end()+80]
        mods = []
        if re.search(r'e\.Control', ctx) or 'e.Control' in text[m.start()-40:m.start()]: mods.append('Ctrl')
        combo = ('Ctrl+' if 'Ctrl' in mods else '') + name
        keys[combo] = keys.get(combo, 0) + 1
    return keys

def validations(text):
    out = []
    lines = text.split('\n')
    for i, ln in enumerate(lines):
        m = RE_MSGBOX.search(ln)
        if not m:
            continue
        msg = m.group(1).strip()
        if not msg or len(msg) < 3:
            continue
        cond = ''
        for j in range(i, max(i-6, -1), -1):
            cm = re.search(r'if\s*\((.+?)\)\s*$|if\s*\((.+)\)\s*\{?', lines[j])
            if cm:
                cond = (cm.group(1) or cm.group(2) or '').strip()[:160]
                break
        out.append({'message': msg[:200], 'when': cond})
    # dedup by message
    seen, uniq = set(), []
    for v in out:
        if v['message'] not in seen:
            seen.add(v['message']); uniq.append(v)
    return uniq[:80]

def calc_exprs(text):
    out = []
    for ln in text.split('\n'):
        s = ln.strip()
        if 'Conversion.Val(' not in s or '=' not in s or s.startswith('//'):
            continue
        rhs = s.split('=', 1)[1]
        if not re.search(r'[-+*/]', rhs):
            continue
        # exclude UI-layout arithmetic, column-width setup, and SQL string building
        if re.search(r'\.(Height|Width|Location|Size|CellHeight|Top|Left)\b|ColCon|RsQry|\b(SELECT|INSERT|UPDATE|DELETE)\b', s):
            continue
        s = re.sub(r'\s+', ' ', s)
        if 18 < len(s) < 320:
            out.append(s)
    seen, uniq = set(), []
    for s in out:
        if s not in seen:
            seen.add(s); uniq.append(s)
    return uniq[:70]

def main():
    files = sorted(glob.glob(f'{SRC}/*.cs'))
    index = []
    for f in files:
        form = os.path.basename(f)[:-3]
        text = open(f, encoding='utf-8', errors='replace').read()
        grid = {name: int(idx) for name, idx in RE_GRIDCOL.findall(text)}
        grid_sorted = dict(sorted(grid.items(), key=lambda kv: kv[1]))
        sql = reconstruct_sql(text)
        kb = keyboard_map(text)
        cal = calc_exprs(text)
        val = validations(text)
        rec = {'form': form, 'loc': text.count('\n')+1,
               'gridColumns': grid_sorted, 'inlineSql': sql, 'keyboard': kb, 'calc': cal, 'validations': val}
        json.dump(rec, open(f'{OUT}/{form}.behavior.json','w'), indent=1)
        index.append({'form': form, 'gridCols': len(grid_sorted), 'sql': len(sql), 'keys': len(kb), 'calc': len(cal), 'validations': len(val)})
    index.sort(key=lambda r: -(r['sql']+r['calc']+r['validations']+r['gridCols']))
    json.dump({'forms': len(index), 'index': index}, open(f'{OUT}/_index.json','w'), indent=1)
    tot = {k: sum(r[k] for r in index) for k in ('gridCols','sql','keys','calc','validations')}
    print(f'forms={len(index)}  totals={tot}')
    print('top 8 by behavior richness:')
    for r in index[:8]:
        print(f"  {r['form']:20} grid={r['gridCols']:3} sql={r['sql']:3} keys={r['keys']:2} calc={r['calc']:3} valid={r['validations']:3}")

if __name__ == '__main__':
    main()
