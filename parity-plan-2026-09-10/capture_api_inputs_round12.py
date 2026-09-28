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
out = plan / 'evidence/implementation-2026-09-11-round12'
out.mkdir(parents=True, exist_ok=True)
snapshot = out / f'api-input-snapshot-{args.label}.json'
digest = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()
external_files = [
    '.github/workflows/ci.yml', '.github/workflows/release-certification.yml',
    'web/.github/workflows/ci.yml', 'web/.github/workflows/release-certification.yml',
    'parity-plan-2026-09-10/evidence/report-register.json',
    'project-memory/parity/g5/parity-diff-latest.json',
    'project-memory/parity/restore-drill-result.json',
]
external_absences = ['project-memory/parity/reports/report-comparison-latest.json']
def external_observations():
    return [{'path': name,
             'state': 'present' if (root / name).is_file() else 'other' if (root / name).exists() else 'absent',
             'sha256': digest(root / name) if (root / name).is_file() else None}
            for name in external_files + external_absences]
def current_paths():
    prior = json.loads((plan / 'evidence/implementation-2026-09-11-round11/api-input-snapshot-final.json').read_text())
    paths = {root / row['path'] for row in prior['files']}
    for directory in [
        'web/apps/api/src', 'web/apps/api/test', 'web/apps/api/form-specs', 'web/apps/api/report-specs',
        'web/apps/web/app', 'web/apps/web/components', 'web/apps/web/lib', 'web/apps/web/test',
        'web/packages/core/src', 'web/packages/core/test', 'web/packages/core/dist',
        'web/packages/db/src', 'web/packages/db/test', 'web/packages/db/dist', 'web/packages/db/prisma',
        'web/scripts',
    ]:
        paths.update(path for path in (root / directory).rglob('*') if path.is_file()
                     and not any(part in {'node_modules', '__pycache__'} for part in path.parts)
                     and path.name != '.DS_Store')
    paths.update(root / name for name in ['web/apps/web/package.json', 'web/apps/web/next.config.mjs', 'web/apps/web/tsconfig.json', 'web/eslint.config.mjs', 'web/package.json', 'web/pnpm-lock.yaml'])
    paths.update(root / name for name in external_files if (root / name).is_file())
    paths.add(Path(__file__).resolve())
    return paths

if args.verify:
    captured = json.loads(snapshot.read_text())
    rows = captured['files']
    changed = [row['path'] for row in rows if not (root / row['path']).is_file()
               or digest(root / row['path']) != row['sha256']]
    added = sorted(str(path.relative_to(root)) for path in current_paths()
                   if str(path.relative_to(root)) not in {row['path'] for row in rows})
    before_external = {row['path']: row for row in captured['externalObservations']}
    after_external = {row['path']: row for row in external_observations()}
    external_changes = [name for name in sorted(before_external.keys() | after_external.keys())
                        if before_external.get(name) != after_external.get(name)]
    result = {'verifiedAtUtc': now(), 'capturedInputs': len(rows), 'changedInputs': changed, 'addedInputs': added,
              'changedExternalObservations': external_changes,
              'status': 'passed' if not changed and not added and not external_changes else 'failed',
              'snapshot': str(snapshot.relative_to(root)), 'snapshotSha256': digest(snapshot)}
    target = out / f'api-input-verification-{args.label}.json'
    assert not target.exists(), 'Refusing to overwrite verification evidence.'
    target.write_text(json.dumps(result, indent=2) + '\n')
    print(json.dumps(result, indent=2))
    raise SystemExit(1 if changed or added or external_changes else 0)

paths = current_paths()
assert not snapshot.exists(), 'Refusing to overwrite a captured input snapshot.'
assert all((root / name).is_file() for name in external_files), 'A required external test input is missing.'
assert all(not (root / name).exists() for name in external_absences), 'An expected missing test artifact is now present.'
result = {'capturedAtUtc': now(), 'phase': 'before complete isolated API regression',
          'scope': 'Union of prior inputs and all current API/core/db source, test, fixture, schema and configuration inputs, plus web app/components/lib/test, every workspace script and build configuration. Includes built core/db modules, script helpers, workflows, report register and retained/absent external evidence consumed by certification tests.',
          'externalObservations': external_observations(),
          'files': [{'path': str(path.relative_to(root)), 'sha256': digest(path)} for path in sorted(paths)]}
snapshot.write_text(json.dumps(result, indent=2) + '\n')
print(json.dumps({'snapshot': str(snapshot.relative_to(root)), 'inputs': len(paths)}, indent=2))
