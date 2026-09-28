"""Capture/verify exact core check inputs without overwriting earlier evidence."""
from pathlib import Path
import datetime
import hashlib
import json
import sys

root = Path(__file__).resolve().parent.parent
evidence = root / 'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round12'
sha = lambda p: hashlib.sha256(p.read_bytes()).hexdigest()
paths = set()
for prefix in ['web/packages/core/src', 'web/packages/core/test']:
    paths.update(p for p in (root / prefix).rglob('*') if p.is_file())
paths.update(root / name for name in [
    'web/package.json', 'web/pnpm-lock.yaml', 'web/tsconfig.base.json',
    'web/packages/core/package.json', 'web/packages/core/tsconfig.json',
    'web/packages/core/containment.mjs', 'web/packages/core/containment.d.mts',
])
files = [{'path': str(p.relative_to(root)), 'sha256': sha(p)} for p in sorted(paths)]
mode = sys.argv[1]
snapshot = evidence / 'core-input-snapshot-complete.json'
if mode == 'before':
    assert not snapshot.exists(), 'Refusing to replace captured check inputs'
    snapshot.write_text(json.dumps({'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
                                    'files': files}, indent=2) + '\n')
    print(json.dumps({'inputs': len(files), 'sha256': sha(snapshot)}))
elif mode == 'after':
    output = evidence / 'core-input-verification-complete.json'
    assert not output.exists(), 'Refusing to replace prior verification'
    previous = json.loads(snapshot.read_text())['files']
    before = {row['path']: row['sha256'] for row in previous}
    after = {row['path']: row['sha256'] for row in files}
    changes = [key for key in sorted(before.keys() | after.keys()) if before.get(key) != after.get(key)]
    result = {'verifiedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
              'status': 'passed' if not changes else 'failed', 'inputs': len(files),
              'inputSnapshotSha256': sha(snapshot), 'changedInputs': changes}
    output.write_text(json.dumps(result, indent=2) + '\n')
    print(json.dumps(result))
    sys.exit(bool(changes))
else:
    raise ValueError('Expected before or after')
