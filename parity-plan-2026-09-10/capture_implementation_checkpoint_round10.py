"""Seal the pure-core continuation; do not borrow API/browser pass credit."""
from pathlib import Path
import datetime
import hashlib
import json
import re
import subprocess

plan = Path(__file__).resolve().parent
root = plan.parent
evidence = plan / 'evidence/implementation-2026-09-11-round10'
sha = lambda p: hashlib.sha256(p.read_bytes()).hexdigest()
identity = lambda p: {'path': str(p.relative_to(root)), 'sha256': sha(p)}
prior_path = plan / '31-implementation-checkpoint-round9.json'
assert sha(prior_path) == 'c46d7612fff5ac119323b4646b5860b3c406cd395aed4223ab03eea8068bdcc7'
prior = json.loads(prior_path.read_text())
baseline_path = plan / 'evidence/review-2026-09-11/reviewed-source-hashes.json'
before = json.loads((evidence / 'core-input-snapshot-complete.json').read_text())
after = json.loads((evidence / 'core-input-verification-complete.json').read_text())
assert after['status'] == 'passed' and after['changedInputs'] == []
assert after['inputSnapshotSha256'] == sha(evidence / 'core-input-snapshot-complete.json')
for row in before['files']:
    assert sha(root / row['path']) == row['sha256'], row['path']
for row in json.loads((evidence / 'build-source-inputs-final.json').read_text())['files']:
    assert sha(root / row['path']) == row['sha256'], row['path']
build_verified = json.loads((evidence / 'build-source-verification-final.json').read_text())
assert build_verified['status'] == 'passed' and build_verified['changedInputs'] == []
assert build_verified['inputSnapshotSha256'] == sha(evidence / 'build-source-inputs-final.json')
paths = {root / row['path'] for row in prior['sourceFiles']}
paths.update(root / row['path'] for row in before['files'])
for prefix in ['web/packages/core/src', 'web/packages/core/test', 'web/packages/core/dist']:
    paths.update(p for p in (root / prefix).rglob('*') if p.is_file())
paths.update(plan / name for name in [
    'capture_core_inputs_round10.py', 'run_check_round10.py',
    'capture_implementation_checkpoint_round10.py', 'build_execution_addendum.py',
    'execution-addendum-intro.md', 'validate_current_review.py',
])
sources = [identity(p) for p in sorted(paths)]
old = {row['path']: row['sha256'] for row in prior['sourceFiles']}
changes = [{'path': row['path'], 'beforeSha256': old[row['path']], 'afterSha256': row['sha256']}
           for row in sources if row['path'] in old and old[row['path']] != row['sha256']]
unchanged_prefixes = ['web/apps/api/src/', 'web/apps/api/test/', 'web/apps/web/app/',
                     'web/apps/web/components/', 'web/apps/web/lib/', 'web/apps/web/test/',
                     'web/packages/db/prisma/']
assert not [row for row in changes if any(row['path'].startswith(p) for p in unchanged_prefixes)]
for prefix in unchanged_prefixes:
    for path in (root / prefix).rglob('*'):
        if path.is_file() and path.suffix in {'.ts', '.tsx', '.js', '.mjs', '.py', '.prisma', '.sql'}:
            assert str(path.relative_to(root)) in old, 'Unexpected new API/UI/schema input: ' + str(path)
for name in ['saleReturnIncoming.ts', 'saleReturnIncomingProjection.ts', 'money.ts']:
    key = 'web/packages/core/src/' + name
    assert sha(root / key) == old[key], key
verification = []
checks = [
    ('core-tests-verified', 'Complete core regression', 0),
    ('core-test-types', 'Strict new aggregate and tax-policy test types', 0),
    ('build-final', 'Production workspace build', 0),
    ('lint', 'Workspace lint and application types', 0),
    ('web-tests', 'Unchanged web unit regression', 0),
    ('document-references', 'Documentation references', 0),
    ('register', 'Completion register', 0),
    ('checkpoint-chain', 'Checkpoint chain positive and negative controls', 0),
    ('kernel-gate', 'Existing rounding adoption gate', 1),
    ('depth-gate', 'Existing depth gate', 1),
    ('dead-cells', 'Existing Return dead-cell gate', 1),
]
for name, label, expected in checks:
    meta = json.loads((evidence / (name + '.run.json')).read_text())
    assert meta['exitCode'] == expected, name
    log = root / meta['log']
    assert log.is_file()
    verification.append({'name': label, 'command': ' '.join(meta['command']),
                         'status': meta['status'], 'exitCode': meta['exitCode'],
                         'log': meta['log'], 'logSha256': sha(log),
                         'invocation': identity(evidence / (name + '.run.json'))})
text = (evidence / 'core-tests-verified.txt').read_text()
files = re.search(r'Test Files\s+(\d+) passed \((\d+)\)', text)
tests = re.search(r'Tests\s+(\d+) passed \((\d+)\)', text)
assert files and tests and files[1] == files[2] and tests[1] == tests[2] and 'skipped' not in text
assert int(files[1]) == 13 and int(tests[1]) > 264
verification[0]['details'] = {'files': int(files[1]), 'tests': int(tests[1]), 'skipped': 0}
assert '127' in (evidence / 'kernel-gate.txt').read_text()
assert '102' in (evidence / 'depth-gate.txt').read_text()
assert 'DEAD CELLS: 33' in (evidence / 'dead-cells.txt').read_text()
artifacts = {p for p in evidence.rglob('*') if p.is_file() and p.name not in {
    'document-validation.json', 'document-validation-complete.txt'}}
artifacts.update(plan / name for name in ['02-implementation-plan.md', '07-work-items.json',
    '12-execution-addendum.md', '13-execution-backlog.json', '32-implementation-progress-round10.md', 'README.md'])
artifacts.update(root / 'web/docs' / name for name in ['TECHNICAL-REFERENCE.md', 'HANDOFF.md', 'STATE-OF-PARITY.md'])
artifacts.update(plan / 'evidence/implementation-2026-09-11-round9' / name for name in [
    'document-validation.json', 'document-validation-complete.txt'])
checkpoint = {
    'kind': 'datacare.parity-implementation-checkpoint/1.0',
    'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
    'displayTimezone': 'Asia/Kolkata', 'status': 'partial-implementation',
    'gitHead': subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=root, text=True).strip(),
    'workingTree': 'Existing dirty working tree preserved; no DB/service changes, commit, deployment or release certification.',
    'baseReviewSourceManifestSha256': sha(baseline_path),
    'priorCheckpoint': prior_path.name, 'priorCheckpointSha256': sha(prior_path),
    'progressDocument': '32-implementation-progress-round10.md',
    'wholeProductImplementationPercentage': None, 'verifiedMenus': 0,
    'acceptedExecutionCards': [], 'acceptedOriginalPackages': [],
    'implementedSlices': [
        'Pure primary incoming running aggregate and stateful bill callback under a bounded exact-decimal profile',
        'Ordered row/aggregate/bill event composition with immutable observations and atomic transient rejection',
        'Pure qualified company-open tax precision resolver under current nullable Int32 storage profile',
    ],
    'sourceFiles': sources, 'changedPriorSourceFiles': changes,
    'verification': verification, 'artifactFiles': [identity(p) for p in sorted(artifacts)],
    'historicalVerificationNotRerun': {
        'checkpoint': prior_path.name, 'apiFiles': 235, 'apiTests': 2115, 'browserJourneys': 15,
        'limits': 'API source, routes and operator UI are unchanged. Prior API/browser/complete API test compiler passes belong to checkpoint31; this pure prerequisite has no HTTP/browser acceptance.'},
    'requiredOpenAcceptance': [
        'Saved-header projection and trusted same-snapshot aggregate API/UI integration; unresolved authoritative session ledger mode and opening/closing',
        *prior['requiredOpenAcceptance'],
    ],
    'limits': 'Pure prerequisite only, not operator-enabled. No Windows binary/locale/ActiveX or full form acceptance. Existing row/money/projection implementations unchanged. All release failures remain open without threshold changes; no functional percentage follows from test counts.',
}
output = plan / '33-implementation-checkpoint-round10.json'
assert not output.exists(), 'Refusing to overwrite an immutable checkpoint'
output.write_text(json.dumps(checkpoint, indent=2) + '\n')
print(json.dumps({'checkpoint': str(output), 'sha256': sha(output), 'sources': len(sources),
                  'artifacts': len(artifacts), 'verification': len(verification),
                  'coreFiles': int(files[1]), 'coreTests': int(tests[1])}))
