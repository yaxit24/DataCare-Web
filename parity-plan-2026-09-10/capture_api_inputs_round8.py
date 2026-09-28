"""Capture before running, then verify exactly those API inputs without rewriting evidence."""
from pathlib import Path
import argparse
import datetime
import hashlib
import json

parser = argparse.ArgumentParser()
parser.add_argument('label')
parser.add_argument('--verify', action='store_true')
args = parser.parse_args()
if not args.label or any(c not in 'abcdefghijklmnopqrstuvwxyz0123456789-' for c in args.label):
    parser.error('Use a lowercase evidence label.')
plan = Path(__file__).resolve().parent
root = plan.parent
out = plan / 'evidence/implementation-2026-09-11-round8'
out.mkdir(parents=True, exist_ok=True)
snapshot = out / f'api-input-snapshot-{args.label}.json'
digest = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()
def current_paths():
    prior = json.loads((plan / 'evidence/implementation-2026-09-11-round7/api-input-snapshot-complete.json').read_text())
    paths = {root / row['path'] for row in prior['files']}
    for directory in [
        'web/apps/api/src', 'web/apps/api/test', 'web/apps/api/form-specs', 'web/apps/api/report-specs',
        'web/apps/web/app', 'web/apps/web/components', 'web/apps/web/lib', 'web/apps/web/test',
        'web/packages/core/src', 'web/packages/core/test', 'web/packages/core/dist',
        'web/packages/db/src', 'web/packages/db/test', 'web/packages/db/dist', 'web/packages/db/prisma',
    ]:
        paths.update(path for path in (root / directory).rglob('*') if path.is_file()
                     and not any(part in {'node_modules', '__pycache__'} for part in path.parts)
                     and path.name != '.DS_Store')
    paths.update(root / name for name in ['web/apps/web/package.json', 'web/apps/web/next.config.mjs', 'web/apps/web/tsconfig.json', 'web/eslint.config.mjs', 'web/package.json', 'web/pnpm-lock.yaml'])
    paths.add(Path(__file__).resolve())
    return paths

if args.verify:
    rows = json.loads(snapshot.read_text())['files']
    changed = [row['path'] for row in rows if not (root / row['path']).is_file()
               or digest(root / row['path']) != row['sha256']]
    added = sorted(str(path.relative_to(root)) for path in current_paths()
                   if str(path.relative_to(root)) not in {row['path'] for row in rows})
    result = {'verifiedAtUtc': now(), 'capturedInputs': len(rows), 'changedInputs': changed, 'addedInputs': added,
              'status': 'passed' if not changed and not added else 'failed',
              'snapshot': str(snapshot.relative_to(root)), 'snapshotSha256': digest(snapshot)}
    target = out / f'api-input-verification-{args.label}.json'
    assert not target.exists(), 'Refusing to overwrite verification evidence.'
    target.write_text(json.dumps(result, indent=2) + '\n')
    print(json.dumps(result, indent=2))
    raise SystemExit(1 if changed or added else 0)

paths = current_paths()
assert not snapshot.exists(), 'Refusing to overwrite a captured input snapshot.'
result = {'capturedAtUtc': now(), 'phase': 'before complete isolated API regression',
          'scope': 'Union of prior inputs and all current API/core/db source, test, fixture, schema and configuration inputs, plus web app/components/lib/test and build configuration. Includes built core/db modules consumed by API tests.',
          'files': [{'path': str(path.relative_to(root)), 'sha256': digest(path)} for path in sorted(paths)]}
snapshot.write_text(json.dumps(result, indent=2) + '\n')
print(json.dumps({'snapshot': str(snapshot.relative_to(root)), 'inputs': len(paths)}, indent=2))
