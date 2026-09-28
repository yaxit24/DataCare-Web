"""Capture/verify complete build inputs, preserving prior evidence."""
from pathlib import Path
import datetime, hashlib, json, sys
plan=Path(__file__).resolve().parent
root=plan.parent
evidence=plan/'evidence/implementation-2026-09-11-round11'
sha=lambda p:hashlib.sha256(p.read_bytes()).hexdigest()
prior=json.loads((plan/'evidence/implementation-2026-09-11-round10/build-source-inputs-final.json').read_text())
paths={root/r['path'] for r in prior['files']}
for prefix in ['web/apps/api/src','web/apps/web/app','web/apps/web/components','web/apps/web/lib','web/packages/core/src','web/packages/db/src']:
    paths.update(p for p in (root/prefix).rglob('*') if p.is_file() and p.name!='.DS_Store')
paths.add(Path(__file__).resolve())
files=[{'path':str(p.relative_to(root)),'sha256':sha(p)} for p in sorted(paths)]
label=sys.argv[2] if len(sys.argv)>2 else 'complete'
snapshot=evidence/f'build-source-inputs-{label}.json'
if sys.argv[1]=='before':
    assert not snapshot.exists()
    snapshot.write_text(json.dumps({'capturedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'scope':'Union of previous complete977 build inputs and all current API/web/core/db production source plus this capture script.','files':files},indent=2)+'\n')
    print(json.dumps({'inputs':len(files),'sha256':sha(snapshot)}))
else:
    before={r['path']:r['sha256'] for r in json.loads(snapshot.read_text())['files']}
    after={r['path']:r['sha256'] for r in files}
    changed=[p for p in sorted(before.keys()|after.keys()) if before.get(p)!=after.get(p)]
    result={'verifiedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'status':'failed' if changed else 'passed','changedInputs':changed,'inputSnapshotSha256':sha(snapshot),'inputs':len(files)}
    output=evidence/f'build-source-verification-{label}.json'
    assert not output.exists()
    output.write_text(json.dumps(result,indent=2)+'\n')
    print(json.dumps(result));sys.exit(bool(changed))
