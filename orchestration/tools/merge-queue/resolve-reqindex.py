#!/usr/bin/env python3
"""Resolve requirement-index.json when both sides rebaselined the same source register.

Takes main's copy (stage 3); for each register whose rebaseline differs on our side (stage 2), stacks ours on top of
main's: sha256 = sha of the merged register file, fromSha256 = main's sha, previous = main's rebaselined block.
Exits 1 on any other difference so the queue stops for a person.
"""
import datetime, hashlib, json, subprocess, sys
F = 'docs/master-parity-plan-2026-09-29/requirement-index.json'
show = lambda st: json.loads(subprocess.run(['git', 'show', f':{st}:{F}'], capture_output=True, text=True, check=True).stdout)
base, ours, theirs = show(1), show(2), show(3)
if [k for k in ours if k != 'sourceRegisters' and ours[k] != theirs[k] and ours[k] != base.get(k)]:
    sys.exit('top-level difference beyond sourceRegisters')
bp = {r['path']: r for r in base['sourceRegisters']}
op = {r['path']: r for r in ours['sourceRegisters']}
for t in theirs['sourceRegisters']:
    o, b = op.get(t['path']), bp.get(t['path'])
    if o is None or o == t or o == b:
        continue
    if o.get('rebaselined') == (b or {}).get('rebaselined'):
        sys.exit(f"{t['path']}: differs without a rebaseline of ours")
    mine = dict(o['rebaselined'])
    mine['previous'] = t.get('rebaselined')
    mine['fromSha256'] = t['sha256']
    mine['date'] = datetime.date.today().isoformat()
    t['rebaselined'] = {k: mine[k] for k in ('date', 'fromSha256', 'slice', 'reason', 'previous') if k in mine}
    t['sha256'] = hashlib.sha256(open(t['path'], 'rb').read()).hexdigest()
    t['count'] = o.get('count', t.get('count'))
    print(f"stacked our rebaseline of {t['path']} on main's")
open(F, 'w').write(json.dumps(theirs, indent=2, ensure_ascii=False) + '\n')
