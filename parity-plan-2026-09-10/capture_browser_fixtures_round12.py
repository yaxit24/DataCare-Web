"""Capture retained browser acceptance fixtures without changing qualified application inputs."""
from pathlib import Path
import datetime
import hashlib
import json
import shutil

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
FROZEN = Path('/tmp/datacare-round12-verification')
OUT = PLAN / 'evidence/implementation-2026-09-11-round12'
sha = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
manifest = OUT / 'isolated-workspace-inputs-qualified.json'
manifest_sha = '52177ad18ac7717c709ccb4b74cdbc325158c5984c9cbc466c7e31c927e9857d'
assert sha(manifest) == manifest_sha
base = json.loads(manifest.read_text())
assert all(sha(FROZEN / row['path']) == row['sha256'] for row in base['files'])
failed = OUT / 'isolated-browser.run.json'
assert json.loads(failed.read_text())['exitCode'] == 1
output = OUT / 'isolated-browser-fixtures.json'
assert not output.exists()
paths = {
    'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/browser-required-checks.json':
        'f48f8062ea01b0bb94dea90fcb6156c5e41e787ea99d2bf7e22462ab09ba08ef',
    'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round11/bill-browser-required-checks.json':
        '2aac326a8124c6baec42f2cad8969337d8c497fb1a836d0edb914e8e38ea997e',
}
rows = []
for name, digest in sorted(paths.items()):
    source, target = ROOT / name, FROZEN / name
    assert sha(source) == digest
    assert not target.exists() or sha(target) == digest
    target.parent.mkdir(parents=True, exist_ok=True)
    shutil.copy2(source, target)
    assert sha(source) == sha(target) == digest
    rows.append({'path': name, 'sha256': digest})
assert all(sha(FROZEN / row['path']) == row['sha256'] for row in base['files'])
record = {
    'kind': 'datacare.frozen-browser-reference-supplement/1.0',
    'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
    'sourceRoot': str(ROOT), 'verificationRoot': str(FROZEN),
    'qualifiedManifestSha256': manifest_sha,
    'changedQualifiedInputs': [], 'files': rows,
    'failedRun': {'path': str(failed.relative_to(ROOT)), 'sha256': sha(failed)},
    'reason': 'The first frozen browser run stopped during import because its original bill acceptance-check JSON was outside the API reference audit. The original row and bill acceptance fixtures are copied exactly; no application, harness, test, expected check or threshold is changed.',
    'audit': {
        'scope': 'Static review of filesystem reads and local imports in apps/web/test/*.mjs, parity-test-env.mjs and their local input paths.',
        'missingRuntimeRead': rows[0]['path'],
        'additionalAcceptanceControl': rows[1]['path'],
        'alreadyCaptured': ['API image fixtures', 'bill independent JSON vector', 'local journey imports', 'test DB compose and setup SQL'],
        'generatedBuildInputs': ['web/apps/api/dist', 'web/apps/web/.next'],
        'excludedSecretInput': 'Disposable .env.parity-test; no values recorded.',
        'limits': 'Static local dependency review, not a system-call trace or original desktop acceptance.',
    },
}
with output.open('x') as stream:
    stream.write(json.dumps(record, indent=2) + '\n')
print(json.dumps({'path': str(output.relative_to(ROOT)), 'sha256': sha(output), 'fixtures': len(rows)}))
