# Two branches may add the same document-register rule; after a merge the second copy matches no file.
import json
p = 'docs/handbook/doc-register.json'
d = json.load(open(p)); seen = set(); out = []
for r in d['rules']:
    k = json.dumps(r.get('match'))
    if k in seen: continue
    seen.add(k); out.append(r)
if len(out) != len(d['rules']):
    d['rules'] = out; open(p, 'w').write(json.dumps(d, indent=2, ensure_ascii=False) + '\n'); print('register rules deduplicated')
