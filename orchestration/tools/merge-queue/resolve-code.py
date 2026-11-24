#!/usr/bin/env python3
"""Resolve the two code conflicts every plan PR hits when main moves on.

routePolicy.test.ts: the route total is main's total plus this branch's own delta (ours - merge base); both
sides' comment lines are kept. migrationManifest.ts: keep main's entries, then ours. Any other conflict shape is
left untouched (exit 1) so the queue stops for a person.
"""
import re, subprocess, sys

ROUTES = 'web/apps/api/test/routePolicy.test.ts'
MANIFEST = 'web/apps/api/src/modules/ops/migrationManifest.ts'
BLOCK = re.compile(r'<<<<<<< [^\n]*\n(.*?)=======\n(.*?)>>>>>>> [^\n]*\n', re.S)
COUNT = re.compile(r'toHaveLength\((\d+)\)')


def total(text):
    m = COUNT.search(text)
    return int(m.group(1)) if m else None


def routes(path):
    base = subprocess.run(['git', 'show', f':1:{path}'], capture_output=True, text=True).stdout
    b = total(base)
    s = open(path).read()
    ok = True

    def fix(m):
        nonlocal ok
        ours, theirs = m.group(1), m.group(2)
        o, t = total(ours), total(theirs)
        if None in (o, t, b):
            ok = False
            return m.group(0)
        n = t + (o - b)
        notes = [l for l in ours.splitlines() if l.strip().startswith('//') and l not in theirs]
        body = theirs.replace(f'({t})', f'({n})').replace(f'toBe({t})', f'toBe({n})')
        lines = body.splitlines()
        at = next(i for i, l in enumerate(lines) if 'toHaveLength' in l)
        notes = [l.rstrip() + f' [{t} on main + {o - b} here = {n}]' if i == len(notes) - 1 else l
                 for i, l in enumerate(notes)]
        return '\n'.join(lines[:at] + notes + lines[at:]) + '\n'

    s = BLOCK.sub(fix, s)
    if ok and '<<<<<<<' not in s:
        open(path, 'w').write(s)
        print(f'resolved {path} by rule')
    return ok


def manifest(path):
    s = open(path).read()
    s2 = BLOCK.sub(lambda m: m.group(2) + '  },\n  {\n' + m.group(1), s)
    if '<<<<<<<' in s2:
        return False
    open(path, 'w').write(s2)
    print(f'resolved {path} by rule (main first, then ours)')
    return True


done = True
for f in sys.argv[1:]:
    if f == ROUTES:
        done &= routes(f)
    elif f == MANIFEST:
        done &= manifest(f)
sys.exit(0 if done else 1)
