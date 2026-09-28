"""Copy one stable input revision into the dedicated verification worktree.

The worktree and cloned dependencies must already exist. Test-only credentials
are copied privately and excluded from the source archive and public manifest.
This does not run tests or change the active source files or Docker services.
"""
from pathlib import Path
import datetime
import hashlib
import json
import shutil
import subprocess
import tarfile

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
TARGET = Path('/tmp/datacare-round12-verification')
OUT = PLAN / 'evidence/implementation-2026-09-11-round12'
MANIFEST = OUT / 'isolated-workspace-inputs.json'
ARCHIVE = OUT / 'isolated-workspace-inputs.tar.gz'
assert not MANIFEST.exists() and not ARCHIVE.exists(), 'Immutable capture already exists'
assert (TARGET / '.git').is_file() and (TARGET / 'web/node_modules/.pnpm').is_dir()
digest = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()

def inputs():
    paths = set()
    for name in [
        '35-implementation-checkpoint-round11.json',
        'evidence/implementation-2026-09-11-round12/api-input-snapshot-typed.json',
        'evidence/implementation-2026-09-11-round12/build-source-inputs-complete.json',
        'evidence/implementation-2026-09-11-round12/test-types-inputs-final.json',
    ]:
        value = json.loads((PLAN / name).read_text())
        paths.update(ROOT / row['path'] for row in value.get('files', value.get('sourceFiles', [])))
    for directory in [
        'web/apps/api/src', 'web/apps/api/test', 'web/apps/api/form-specs', 'web/apps/api/report-specs',
        'web/apps/web/app', 'web/apps/web/components', 'web/apps/web/lib', 'web/apps/web/test',
        'web/packages/core/src', 'web/packages/core/test', 'web/packages/core/dist',
        'web/packages/db/src', 'web/packages/db/test', 'web/packages/db/dist', 'web/packages/db/prisma',
        'web/scripts',
    ]:
        paths.update(p for p in (ROOT / directory).rglob('*') if p.is_file()
                     and not any(part in {'node_modules', '__pycache__'} for part in p.parts)
                     and p.name != '.DS_Store')
    paths.update(PLAN / name for name in [
        'freeze_verification_workspace_round12.py', 'run_frozen_check_round12.py',
        'build_execution_addendum.py', 'execution-addendum-intro.md',
    ])
    return sorted(paths)

started = datetime.datetime.now(datetime.timezone.utc).isoformat()
head = subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=ROOT, text=True).strip()
assert subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=TARGET, text=True).strip() == head
paths = inputs()
rows = []
for path in paths:
    relative = path.relative_to(ROOT)
    assert path.is_file() and not path.is_symlink(), relative
    data = path.read_bytes()
    target = TARGET / relative
    target.parent.mkdir(parents=True, exist_ok=True)
    target.write_bytes(data)
    shutil.copymode(path, target)
    rows.append({'path': str(relative), 'sha256': hashlib.sha256(data).hexdigest()})
changed = [row['path'] for row in rows if digest(ROOT / row['path']) != row['sha256']]
assert not changed and paths == inputs(), ('Source changed during copy; retry without sealing', changed)
absent = 'project-memory/parity/reports/report-comparison-latest.json'
assert not (ROOT / absent).exists() and not (TARGET / absent).exists()
credential = ROOT / 'web/.env.parity-test'
assert credential.is_file()
shutil.copyfile(credential, TARGET / 'web/.env.parity-test')
(TARGET / 'web/.env.parity-test').chmod(0o600)
with tarfile.open(ARCHIVE, 'x:gz') as archive:
    for row in rows:
        archive.add(TARGET / row['path'], arcname=row['path'], recursive=False)
result = {
    'kind': 'datacare.isolated-verification-inputs/1.0',
    'startedAtUtc': started,
    'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
    'sourceRoot': str(ROOT), 'verificationRoot': str(TARGET), 'baseGitHead': head,
    'files': rows, 'externalAbsences': [absent],
    'archive': {'path': str(ARCHIVE.relative_to(ROOT)), 'sha256': digest(ARCHIVE)},
    'dependencySetup': 'APFS-cloned existing node_modules; relative workspace links resolve inside the separate worktree. No install or lockfile change.',
    'runtimeCredentialHandling': 'Existing disposable parity DB credentials copied with mode0600; no credentials in archive, manifest or logs.',
    'changedDuringCopy': [],
    'limits': 'A stable verification revision. Subsequent active-workspace edits must be reported separately; these results cannot certify untested later edits.',
}
MANIFEST.write_text(json.dumps(result, indent=2) + '\n')
print(json.dumps({'manifest': str(MANIFEST.relative_to(ROOT)), 'inputs': len(rows),
                  'archiveSha256': result['archive']['sha256'], 'verificationRoot': str(TARGET)}))
