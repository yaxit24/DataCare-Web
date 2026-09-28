"""Add audited runtime reference inputs without rewriting the base capture."""
from pathlib import Path
import datetime
import hashlib
import json
import tarfile

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
OUT = PLAN / 'evidence/implementation-2026-09-11-round12'
TARGET = Path('/tmp/datacare-round12-verification')
digest = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
base_path = OUT / 'isolated-workspace-inputs.json'
assert digest(base_path) == '598de0a6f696babb3ecc147bf552c6f933682b64e379382fed943c5d6c7fc245'
base = json.loads(base_path.read_text())
run_path = OUT / 'isolated-api.run.json'
run = json.loads(run_path.read_text())
assert run['exitCode'] != 0 and 'PARITY-RATCHET.json' in (ROOT / run['log']).read_text()
assert (OUT / 'isolated-types.run.json').is_file(), 'Wait for the base-revision compiler before adding reference inputs'
recommendation_path = OUT / 'isolated-input-audit/recommended-reference-additions.json'
assert digest(recommendation_path) == '6c982a86008b80f34ea6f4099395265c89835caf7eeafce1cb175799a8a75f84'
recommended = [{k: row[k] for k in ('path', 'sha256')} for row in json.loads(recommendation_path.read_text())['files']]
manifest = OUT / 'isolated-workspace-inputs-qualified.json'
archive_path = OUT / 'isolated-workspace-inputs-qualified.tar.gz'
assert not manifest.exists() and not archive_path.exists()
for row in base['files']:
    assert digest(TARGET / row['path']) == row['sha256'], row['path']
assert digest(ROOT / base['archive']['path']) == base['archive']['sha256']
base_rows = {row['path']: row for row in base['files']}
extra = {ROOT / 'project-memory/parity/PARITY-RATCHET.json', ROOT / 'web/deploy/.env.example'}
directory_inputs = {
    'unified/src/csharp/DataCareNext': '*.cs',
    'project-memory/contracts': '*.contract.md',
}
memberships = {}
for directory, pattern in directory_inputs.items():
    found = sorted((ROOT / directory).glob(pattern))
    memberships[directory] = {'pattern': pattern, 'members': [p.name for p in found]}
    extra.update(found)
assert digest(ROOT / 'project-memory/parity/PARITY-RATCHET.json') == '0656b24e6183a34731947d096c43b8f2209f5bd6a30742f932a0c019592ab0a3'
added = []
replaced_uncaptured = []
for source in sorted(extra):
    relative = str(source.relative_to(ROOT))
    data = source.read_bytes()
    sha256 = hashlib.sha256(data).hexdigest()
    if relative in base_rows:
        assert sha256 == base_rows[relative]['sha256'], relative
        continue
    target = TARGET / relative
    if target.exists():
        replaced_uncaptured.append({'path': relative, 'priorUncapturedSha256': digest(target), 'qualifiedSha256': sha256})
    target.parent.mkdir(parents=True, exist_ok=True)
    target.write_bytes(data)
    assert digest(source) == sha256
    added.append({'path': relative, 'sha256': sha256})
for directory, observation in memberships.items():
    assert sorted(p.name for p in (TARGET / directory).glob(observation['pattern'])) == observation['members'], directory
    assert sorted(p.name for p in (ROOT / directory).glob(observation['pattern'])) == observation['members'], directory
for row in base['files']:
    assert digest(TARGET / row['path']) == row['sha256'], row['path']
rows = sorted(base['files'] + added, key=lambda row: row['path'])
assert added == recommended and len(added) == 188
with tarfile.open(archive_path, 'x:gz') as archive:
    for row in rows:
        archive.add(TARGET / row['path'], arcname=row['path'], recursive=False)
result = {
    **base,
    'kind': 'datacare.isolated-verification-inputs/1.0',
    'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
    'files': rows,
    'archive': {'path': str(archive_path.relative_to(ROOT)), 'sha256': digest(archive_path)},
    'baseCapture': {'path': str(base_path.relative_to(ROOT)), 'sha256': digest(base_path)},
    'qualification': {
        'reason': 'Three initial isolated API failures exposed omitted desktop citation sources, the current deployment example and the retained parity-ratchet register. Restore exact active reference inputs without changing application code or assertions.',
        'addedInputs': [row['path'] for row in added], 'priorFrozenInputsUnchanged': True,
        'sourceDirectoryMembership': memberships,
        'replacedUncapturedGitBaselineFiles': replaced_uncaptured,
        'failedRun': {'path': str(run_path.relative_to(ROOT)), 'sha256': digest(run_path)},
        'applicationSourceOrAssertionChanges': [],
    },
}
manifest.write_text(json.dumps(result, indent=2) + '\n')
audit = OUT / 'isolated-input-qualification.json'
assert not audit.exists()
audit.write_text(json.dumps({
    'baseManifestSha256': digest(base_path), 'qualifiedManifestSha256': digest(manifest),
    'addedInputs': added, 'changedBaseInputs': [],
    'reason': result['qualification']['reason'],
    'auditReferences': [{'path': str(p.relative_to(ROOT)), 'sha256': digest(p)} for p in [
        run_path, recommendation_path, OUT / 'isolated-input-audit/audit.json',
    ]],
    'sourceDirectoryMembership': memberships,
    'replacedUncapturedGitBaselineFiles': replaced_uncaptured,
}, indent=2) + '\n')
print(json.dumps({'manifest': str(manifest.relative_to(ROOT)), 'sha256': digest(manifest),
                  'inputs': len(rows), 'archiveSha256': result['archive']['sha256']}))
