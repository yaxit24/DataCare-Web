"""Capture full strict API compiler inputs without narrowing the project."""
from pathlib import Path
import datetime, hashlib, json, sys
plan=Path(__file__).resolve().parent;root=plan.parent
evidence=plan/'evidence/implementation-2026-09-11-round11'
sha=lambda p:hashlib.sha256(p.read_bytes()).hexdigest()
paths={root/r['path'] for r in json.loads((plan/'evidence/implementation-2026-09-11-round9/test-types-inputs-verified.json').read_text())['files']}
for prefix in ['web/apps/api/src','web/apps/api/test','web/apps/api/integration','web/packages/core/src','web/packages/core/dist','web/packages/db/src','web/packages/db/dist']:
    paths.update(p for p in (root/prefix).rglob('*') if p.is_file() and p.suffix in {'.ts','.json','.mjs','.js'} and p.name!='.DS_Store')
paths.add(Path(__file__).resolve())
files=[{'path':str(p.relative_to(root)),'sha256':sha(p)} for p in sorted(paths)]
label=sys.argv[2] if len(sys.argv)>2 else 'complete'
snapshot=evidence/f'test-types-inputs-{label}.json'
if sys.argv[1]=='before':
    assert not snapshot.exists()
    snapshot.write_text(json.dumps({'capturedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'scope':'Previous complete compiler inputs plus all current API src/test/integration and core/db source/dist; exact same tsconfig.test.json, no exclusions.','files':files},indent=2)+'\n')
    print(json.dumps({'inputs':len(files),'sha256':sha(snapshot)}))
else:
    before={r['path']:r['sha256'] for r in json.loads(snapshot.read_text())['files']};after={r['path']:r['sha256'] for r in files}
    changed=[p for p in sorted(before.keys()|after.keys()) if before.get(p)!=after.get(p)]
    output=evidence/f'test-types-verification-{label}.json';assert not output.exists()
    result={'status':'failed' if changed else 'passed','verifiedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'changedInputs':changed,'inputSnapshotSha256':sha(snapshot),'inputs':len(files)}
    output.write_text(json.dumps(result,indent=2)+'\n');print(json.dumps(result));sys.exit(bool(changed))
