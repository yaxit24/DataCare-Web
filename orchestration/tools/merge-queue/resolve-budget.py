#!/usr/bin/env python3
"""size-budget.json: both sides changed a ceiling; the budget is shrink-only, so take the lower number."""
import re, sys
p = 'web/parity/size-budget.json'
B = re.compile(r'<<<<<<< [^\n]*\n(.*?)=======\n(.*?)>>>>>>> [^\n]*\n', re.S)
N = re.compile(r'^(\s*"[^"]+":\s*)(\d+)(,?)$')
def fix(m):
    o, t = m.group(1).splitlines(), m.group(2).splitlines()
    if len(o) != len(t): sys.exit('shape differs')
    out = []
    for a, b in zip(o, t):
        ma, mb = N.match(a), N.match(b)
        if not ma or not mb or ma.group(1) != mb.group(1): sys.exit('not a ceiling line: ' + a)
        out.append(f'{ma.group(1)}{min(int(ma.group(2)), int(mb.group(2)))}{ma.group(3)}')
    return '\n'.join(out) + '\n'
s = B.sub(fix, open(p).read())
if '<<<<<<<' in s: sys.exit(1)
open(p, 'w').write(s); print('resolved size-budget.json (lower ceiling)')
