#!/usr/bin/env python3
"""menu-catalog.jsonl: in each conflict block take, per row id, the side that changed it from the merge base.
Exits 1 if both sides changed the same row or the blocks list different ids."""
import json, re, subprocess, sys
p = 'docs/handbook/menu-catalog.jsonl'
base = {json.loads(l)['id']: l for l in subprocess.run(['git', 'show', ':1:' + p], capture_output=True, text=True).stdout.splitlines() if l.strip()}
B = re.compile(r'<<<<<<< [^\n]*\n(.*?)=======\n(.*?)>>>>>>> [^\n]*\n', re.S)
def fix(m):
    oi = {json.loads(l)['id']: l for l in m.group(1).splitlines() if l.strip()}
    ti = {json.loads(l)['id']: l for l in m.group(2).splitlines() if l.strip()}
    out = []
    for k in list(dict.fromkeys(list(ti) + list(oi))):
        o, t, b = oi.get(k), ti.get(k), base.get(k)
        if o is not None and t is not None and o != b and t != b and o != t:
            sys.exit(f'both sides changed {k}')
        out.append(o if (o is not None and o != b) else t if t is not None else o)
    return '\n'.join(out) + '\n'
s = B.sub(fix, open(p).read())
if '<<<<<<<' in s: sys.exit(1)
open(p, 'w').write(s); print('resolved menu-catalog.jsonl per row')
