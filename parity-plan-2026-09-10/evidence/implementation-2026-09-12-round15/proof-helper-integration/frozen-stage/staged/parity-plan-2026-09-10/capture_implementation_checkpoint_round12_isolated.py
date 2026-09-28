"""Check the isolated Round12 evidence; default is read-only and never runs checks.

Root supplies final observed API totals and the immutable audited qualification.
--seal is an explicit final operation and creates checkpoint37 exclusively.
No test, compiler, browser, DB, extraction, installation or deployment runs here.
"""
from pathlib import Path, PurePosixPath
import argparse
import datetime
import hashlib
import json
import re
import shlex
import subprocess
import tarfile

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
FROZEN = Path('/tmp/datacare-round12-verification')
EVIDENCE = PLAN / 'evidence/implementation-2026-09-11-round12'
BASE_NAME = 'isolated-workspace-inputs.json'
BASE_SHA = '598de0a6f696babb3ecc147bf552c6f933682b64e379382fed943c5d6c7fc245'
BASE_ARCHIVE_SHA = 'e5b192b4530d0cf9aba0340acddbc5e50b80639ba24f2cd41d1858c97f5f516a'
PRIOR_SHA = 'fd3ab768e85c7a0936ae06c72580e7d170b6adf32b74a105df880e43f806a489'
ROW_CHECKS_SHA = 'f48f8062ea01b0bb94dea90fcb6156c5e41e787ea99d2bf7e22462ab09ba08ef'
BILL_CHECKS_SHA = '2aac326a8124c6baec42f2cad8969337d8c497fb1a836d0edb914e8e38ea997e'
BILL_GOLDEN_SHA = '1d0cecba70ed751c64a14b506f18468a49778987dda285b0a0abbb37b7b48410'
REFERENCE_RECOMMENDATION_SHA = '6c982a86008b80f34ea6f4099395265c89835caf7eeafce1cb175799a8a75f84'
REFERENCE_DIRECTORIES = {
    'unified/src/csharp/DataCareNext': '*.cs',
    'project-memory/contracts': '*.contract.md',
}
JOURNEYS = [
    'designBook', 'designCalculations', 'designRepeat', 'genericImageConflict',
    'repairImageConflict', 'salesReturnSaved', 'tourOrder', 'creditNote',
    'salesOrderDesign', 'salesOrder', 'orderImages', 'imageConflict', 'mfgLot',
    'columnSettings', 'salesReturnReplay', 'salesReturnBillReplay',
]
# Same recursive input universe as the source capture. Seeded files outside
# these directories remain included through the manifest, including workflows.
INPUT_DIRECTORIES = [
    'web/apps/api/src', 'web/apps/api/test', 'web/apps/api/form-specs', 'web/apps/api/report-specs',
    'web/apps/web/app', 'web/apps/web/components', 'web/apps/web/lib', 'web/apps/web/test',
    'web/packages/core/src', 'web/packages/core/test', 'web/packages/core/dist',
    'web/packages/db/src', 'web/packages/db/test', 'web/packages/db/dist', 'web/packages/db/prisma',
    'web/scripts',
]
PROTECTED = [
    'web/packages/core/src/sessionLedgerMode.ts',
    'web/packages/core/src/savedSaleReturnClock.ts',
    'web/packages/core/src/index.ts',
    'web/packages/core/test/sessionLedgerMode.test.ts',
    'web/packages/core/test/savedSaleReturnClock.test.ts',
    'web/packages/core/test/fixtures/session-ledger-mode.v1.json',
    'web/packages/core/test/fixtures/saved-sale-return-clock.v1.json',
    'web/apps/api/src/modules/shared/desktopAccountBalance.ts',
    'web/apps/api/test/desktopAccountBalance.db.test.ts',
    'web/apps/api/test/savedSaleReturnClock.db.test.ts',
    'web/apps/api/test/fixtures/desktopAccountBalance.independent.json',
]


def require(condition, message):
    if not condition:
        raise ValueError(message)


def sha(path):
    digest = hashlib.sha256()
    with path.open('rb') as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b''):
            digest.update(block)
    return digest.hexdigest()


def relative(value):
    require(isinstance(value, str) and value and '\\' not in value, 'Invalid relative path')
    path = PurePosixPath(value)
    require(not path.is_absolute() and '..' not in path.parts and str(path) == value,
            'Noncanonical relative path: ' + value)
    return value


def path_at(root, value, must_exist=True):
    path = root / relative(value)
    require(path.resolve().is_relative_to(root.resolve()), 'Path leaves declared root: ' + value)
    if must_exist:
        require(path.is_file() and not path.is_symlink(), 'Missing/nonregular input: ' + value)
    return path


def read_json(path):
    return json.loads(path.read_text())


def identity(path):
    return {'path': str(path.relative_to(ROOT)), 'sha256': sha(path)}


def stamp(value):
    result = datetime.datetime.fromisoformat(value.replace('Z', '+00:00'))
    require(result.tzinfo is not None, 'A timezone-qualified evidence timestamp is required')
    return result


def row_map(rows):
    require(isinstance(rows, list) and rows, 'Missing input identities')
    result = {}
    for row in rows:
        name = relative(row['path'])
        require(name not in result and re.fullmatch(r'[0-9a-f]{64}', row['sha256']),
                'Duplicate or malformed input identity: ' + name)
        result[name] = row['sha256']
    return result


def universe(root, names):
    result = set(names)
    for directory in INPUT_DIRECTORIES:
        for path in (root / directory).rglob('*'):
            if path.is_file() and path.name != '.DS_Store' and not any(
                    part in {'node_modules', '__pycache__'} for part in path.parts):
                result.add(str(path.relative_to(root)))
    # Qualification includes complete directory membership, not merely the
    # selected reference files that existed in the original incomplete capture.
    for directory, pattern in REFERENCE_DIRECTORIES.items():
        result.update(str(path.relative_to(root)) for path in (root / directory).glob(pattern)
                      if path.is_file())
    return result


def verify_archive(path, expected_sha, rows):
    require(sha(path) == expected_sha, 'Pinned source archive changed')
    members = {}
    with tarfile.open(path, 'r:gz') as archive:
        for member in archive:
            name = relative(member.name)
            require(member.isfile() and name not in members and name in rows,
                    'Unexpected archive member: ' + name)
            stream = archive.extractfile(member)
            require(stream is not None, 'Unreadable archive member: ' + name)
            digest = hashlib.sha256()
            for block in iter(lambda: stream.read(1024 * 1024), b''):
                digest.update(block)
            members[name] = digest.hexdigest()
    require(members == rows, 'Source archive member bytes differ from the pinned manifest')


def revision(name, expected_sha, archive_sha):
    manifest_path = EVIDENCE / name
    require(manifest_path.parent == EVIDENCE and sha(manifest_path) == expected_sha,
            'Input manifest does not match its approved identity')
    value = read_json(manifest_path)
    require(value['verificationRoot'] == str(FROZEN) and value['sourceRoot'] == str(ROOT),
            'Unexpected verification or active workspace root')
    require(value.get('changedDuringCopy') == [], 'Capture changed while copying')
    rows = row_map(value['files'])
    require(value['archive']['sha256'] == archive_sha, 'Unexpected archive identity')
    archive_path = path_at(ROOT, value['archive']['path'])
    verify_archive(archive_path, archive_sha, rows)
    for file, digest in rows.items():
        require(sha(path_at(FROZEN, file)) == digest, 'Frozen source changed: ' + file)
    return {'manifest': identity(manifest_path), 'archive': identity(archive_path),
            'data': value, 'rows': rows}


def command_without_env(command):
    require(isinstance(command, list) and command and all(isinstance(x, str) for x in command),
            'Malformed recorded command')
    result = command[:]
    if result[0] == 'env':
        result.pop(0)
        while result and re.match(r'^[A-Za-z_][A-Za-z0-9_]*=', result[0]):
            result.pop(0)
    return result


def read_run(label, title, expected, revisions=None):
    require(re.fullmatch(r'[a-z0-9-]+', label), 'Invalid evidence label')
    metadata_path = EVIDENCE / (label + '.run.json')
    meta = read_json(metadata_path)
    require(meta['exitCode'] == expected and meta['status'] == ('passed' if expected == 0 else 'failed'),
            'Required check did not have its expected disposition: ' + label)
    started, finished = stamp(meta['startedAtUtc']), stamp(meta['finishedAtUtc'])
    require(started <= finished, 'Reversed check timestamps: ' + label)
    command = command_without_env(meta['command'])
    log = path_at(ROOT, meta['log'])
    require(log.stat().st_size > 0 or label == 'isolated-types', 'Unexpected empty check log')
    record = {'name': title, 'command': shlex.join(meta['command']), 'cwd': meta['cwd'],
              'status': meta['status'], 'exitCode': expected, 'log': str(log.relative_to(ROOT)),
              'logSha256': sha(log), 'invocation': identity(metadata_path)}
    if revisions is not None:
        digest = meta.get('isolatedInputManifestSha256')
        require(digest in revisions and meta['cwd'] == str(FROZEN / 'web'),
                'Run is not bound to an approved isolated revision: ' + label)
        observed = revisions[digest]
        require(meta['isolatedInputManifest'] == observed['manifest']['path'],
                'Recorded input manifest path mismatch: ' + label)
        require(stamp(observed['data']['capturedAtUtc']) <= started,
                'Run predates its input capture: ' + label)
        record['verifiedRevision'] = observed['manifest']
        record['sourceAttribution'] = 'This exact frozen revision only; active drift is not certified.'
    else:
        require(meta['cwd'] in {'web', str(ROOT / 'web')}, 'Unexpected ancillary check root')
        record['sourceAttribution'] = 'Separately executed active documentation/static check; not frozen application regression credit.'
    return {'record': record, 'meta': meta, 'command': command, 'text': log.read_text()}


def totals(text):
    clean = re.sub(r'\x1b\[[0-9;]*m', '', text)
    files = re.findall(r'Test Files\s+(\d+) passed \((\d+)\)', clean)
    tests = re.findall(r'Tests\s+(\d+) passed \((\d+)\)', clean)
    require(len(files) == 1 and len(tests) == 1, 'Expected one complete Vitest summary')
    require(files[0][0] == files[0][1] and tests[0][0] == tests[0][1], 'Incomplete test summary')
    require(not re.search(r'\b[1-9]\d*\s+(?:failed|skipped|todo)\b', clean, re.I),
            'A successful test summary must not hide failures or skipped tests')
    return {'files': int(files[0][0]), 'tests': int(tests[0][0]), 'skipped': 0}


def active_drift(rows):
    changed, added = [], []
    for name in sorted(universe(ROOT, rows)):
        path = path_at(ROOT, name, False)
        current = sha(path) if path.is_file() and not path.is_symlink() else None
        if name in rows and current != rows[name]:
            changed.append({'path': name, 'frozenSha256': rows[name], 'currentSha256': current})
        elif name not in rows:
            added.append({'path': name, 'currentSha256': current})
    return changed, added


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--qualified-manifest', default='isolated-workspace-inputs-qualified.json')
    parser.add_argument('--qualified-manifest-sha256', required=True)
    parser.add_argument('--qualified-archive-sha256', required=True)
    parser.add_argument('--qualification', default='isolated-input-qualification.json')
    parser.add_argument('--qualification-sha256', required=True)
    parser.add_argument('--expected-api-files', required=True, type=int)
    parser.add_argument('--expected-api-tests', required=True, type=int)
    parser.add_argument('--api-label', default='isolated-api-qualified')
    parser.add_argument('--browser-label', default='isolated-browser-qualified')
    parser.add_argument('--browser-fixtures', default='isolated-browser-fixtures.json')
    parser.add_argument('--browser-fixtures-sha256', required=True)
    parser.add_argument('--browser-dir', required=True)
    parser.add_argument('--docs-label', default='document-references-combined')
    parser.add_argument('--scanner-label', default='scanner-tests')
    parser.add_argument('--register-label', default='register')
    parser.add_argument('--chain-label', default='checkpoint-chain')
    parser.add_argument('--kernel-label', default='kernel-gate')
    parser.add_argument('--depth-label', default='depth-gate')
    parser.add_argument('--dead-cell-label', default='dead-cells')
    parser.add_argument('--verification', default='isolated-workspace-verification.json')
    parser.add_argument('--check-only', action='store_true')
    parser.add_argument('--print-candidate', action='store_true')
    parser.add_argument('--seal', action='store_true')
    args = parser.parse_args()
    require(not (args.check_only and args.seal), 'Choose check-only or explicit seal')
    require(args.expected_api_files > 0 and args.expected_api_tests > 0, 'Actual final API counts are required')
    output = PLAN / '37-implementation-checkpoint-round12.json'
    require(not output.exists(), 'Refusing to overwrite immutable checkpoint37')
    prior_path = PLAN / '35-implementation-checkpoint-round11.json'
    require(sha(prior_path) == PRIOR_SHA, 'Prior checkpoint35 changed')
    prior = read_json(prior_path)
    base = revision(BASE_NAME, BASE_SHA, BASE_ARCHIVE_SHA)
    require(len(base['rows']) == 1546, 'Original isolated input count changed')
    qualified = revision(args.qualified_manifest, args.qualified_manifest_sha256,
                         args.qualified_archive_sha256)
    require(all(qualified['rows'].get(name) == digest for name, digest in base['rows'].items()),
            'Qualification changed or removed an original application/reference input')
    additions = [{'path': name, 'sha256': digest} for name, digest in sorted(qualified['rows'].items())
                 if name not in base['rows']]
    require(len(additions) == 188 and len(qualified['rows']) == 1734,
            'The reviewed supplemental input universe changed')
    require(not any(row['path'].startswith(('web/apps/', 'web/packages/', 'web/scripts/')) for row in additions),
            'Qualification may not introduce application, package, script or test changes')
    qualification_path = EVIDENCE / args.qualification
    require(qualification_path.parent == EVIDENCE and sha(qualification_path) == args.qualification_sha256,
            'Qualification record identity mismatch')
    qualification = read_json(qualification_path)
    require(qualification['baseManifestSha256'] == BASE_SHA and
            qualification['qualifiedManifestSha256'] == args.qualified_manifest_sha256 and
            qualification['changedBaseInputs'] == [] and
            sorted(qualification['addedInputs'], key=lambda row: row['path']) == additions and
            isinstance(qualification['reason'], str) and qualification['reason'].strip(),
            'Supplemental inputs differ from the reviewed explicit qualification')
    require(qualification.get('auditReferences'), 'The external-input audit must be pinned')
    for row in qualification['auditReferences']:
        require(sha(path_at(ROOT, row['path'])) == row['sha256'], 'Qualified external-input audit changed')
    recommendation = EVIDENCE / 'isolated-input-audit/recommended-reference-additions.json'
    require(sha(recommendation) == REFERENCE_RECOMMENDATION_SHA,
            'Independent external-reference recommendation changed')
    recommended = [{key: row[key] for key in ('path', 'sha256')}
                   for row in read_json(recommendation)['files']]
    require(recommended == additions, 'Qualification differs from independently audited additions')
    require(qualified['data']['baseCapture'] == base['manifest'], 'Qualified base linkage changed')
    inline = qualified['data']['qualification']
    require(inline['priorFrozenInputsUnchanged'] is True and inline['applicationSourceOrAssertionChanges'] == [] and
            inline['addedInputs'] == [row['path'] for row in additions] and
            inline['sourceDirectoryMembership'] == qualification['sourceDirectoryMembership'] and
            inline['replacedUncapturedGitBaselineFiles'] == qualification['replacedUncapturedGitBaselineFiles'],
            'Qualified manifest and separate audit disagree')
    require(set(qualification['sourceDirectoryMembership']) == set(REFERENCE_DIRECTORIES),
            'Qualified source-directory universe changed')
    for directory, pattern in REFERENCE_DIRECTORIES.items():
        membership = qualification['sourceDirectoryMembership'][directory]
        require(membership['pattern'] == pattern and membership['members'] ==
                sorted(path.name for path in (FROZEN / directory).glob(pattern) if path.is_file()),
                'Frozen qualified directory membership changed: ' + directory)
    require(stamp(base['data']['capturedAtUtc']) <= stamp(qualified['data']['capturedAtUtc']),
            'Qualification predates original capture')
    revisions = {BASE_SHA: base, args.qualified_manifest_sha256: qualified}
    rows = qualified['rows']
    browser_fixtures_path = EVIDENCE / args.browser_fixtures
    require(browser_fixtures_path.parent == EVIDENCE and
            sha(browser_fixtures_path) == args.browser_fixtures_sha256,
            'Supplemental browser fixture manifest identity mismatch')
    browser_fixtures = read_json(browser_fixtures_path)
    require(browser_fixtures['kind'] == 'datacare.frozen-browser-reference-supplement/1.0' and
            browser_fixtures['sourceRoot'] == str(ROOT) and browser_fixtures['verificationRoot'] == str(FROZEN) and
            browser_fixtures['qualifiedManifestSha256'] == args.qualified_manifest_sha256 and
            browser_fixtures['changedQualifiedInputs'] == [], 'Browser fixture capture changed the qualified revision')
    browser_rows = row_map(browser_fixtures['files'])
    require(browser_rows == {
        'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/browser-required-checks.json': ROW_CHECKS_SHA,
        'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round11/bill-browser-required-checks.json': BILL_CHECKS_SHA,
    } and not set(browser_rows).intersection(rows), 'Only the two original pinned browser fixtures may be supplemented')
    require(stamp(qualified['data']['capturedAtUtc']) <= stamp(browser_fixtures['capturedAtUtc']),
            'Browser fixture supplement predates qualified revision')
    for name, digest in browser_rows.items():
        require(sha(path_at(FROZEN, name)) == digest and sha(path_at(ROOT, name)) == digest,
                'An original supplemental browser fixture changed: ' + name)
    require(universe(FROZEN, rows) == set(rows), 'Uncaptured inputs exist in the frozen source universe')
    for name in PROTECTED:
        require(name in base['rows'] and sha(path_at(ROOT, name)) == rows[name],
                'Round12 implementation/test/index drifted in the active workspace: ' + name)
    for row in prior['sourceFiles']:
        if row['path'].startswith('web/packages/core/src/') and not row['path'].endswith('/index.ts'):
            require(base['rows'].get(row['path']) == row['sha256'],
                    'A pre-existing pure kernel changed in the verified revision: ' + row['path'])

    runs = {}
    for label, title in [
        ('isolated-core', 'Complete frozen core regression'),
        ('isolated-web', 'Complete frozen web unit regression'),
        ('isolated-build', 'Frozen production build'),
        (args.api_label, 'Complete qualified frozen API regression'),
        ('isolated-types', 'Complete frozen strict API test compiler'),
        ('isolated-lint', 'Frozen workspace lint and application types'),
        (args.browser_label, 'Frozen real-browser integration with original acceptance fixtures'),
        ('isolated-smoke', 'Frozen mocked compatibility smoke'),
    ]:
        runs[label] = read_run(label, title, 0, revisions)
    require(runs[args.api_label]['meta']['isolatedInputManifestSha256'] == args.qualified_manifest_sha256,
            'Final API regression must use the qualified reference universe')
    for label in ['isolated-core', 'isolated-web', 'isolated-build', 'isolated-types']:
        require(runs[label]['meta']['isolatedInputManifestSha256'] == BASE_SHA and
                stamp(runs[label]['meta']['finishedAtUtc']) <= stamp(qualified['data']['capturedAtUtc']),
                'Base revision check overlapped or was relabeled after qualification: ' + label)
    for label in ['isolated-lint', args.browser_label, 'isolated-smoke']:
        require(runs[label]['meta']['isolatedInputManifestSha256'] == args.qualified_manifest_sha256,
                'Later check must identify the qualified reference universe: ' + label)
    initial_api = read_run('isolated-api', 'Historical failed base API reference run', 1, revisions)
    require(initial_api['meta']['isolatedInputManifestSha256'] == BASE_SHA and
            stamp(initial_api['meta']['finishedAtUtc']) <= stamp(qualified['data']['capturedAtUtc']) and
            inline['failedRun'] == initial_api['record']['invocation'],
            'Initial reference-input failure was not preserved before qualification')
    initial_browser = read_run('isolated-browser', 'Historical failed isolated browser fixture import', 1, revisions)
    require(initial_browser['meta']['isolatedInputManifestSha256'] == args.qualified_manifest_sha256 and
            stamp(initial_browser['meta']['finishedAtUtc']) <= stamp(browser_fixtures['capturedAtUtc']) and
            browser_fixtures['failedRun'] == initial_browser['record']['invocation'] and
            'ENOENT' in initial_browser['text'] and 'bill-browser-required-checks.json' in initial_browser['text'],
            'The original missing browser-reference failure must remain explicit')
    for label in [args.browser_label, 'isolated-smoke']:
        meta = runs[label]['meta']
        require(meta['supplementalBrowserFixtureManifest'] == str(browser_fixtures_path.relative_to(ROOT)) and
                meta['supplementalBrowserFixtureManifestSha256'] == args.browser_fixtures_sha256 and
                meta['changedFrozenInputs'] == [] and
                stamp(browser_fixtures['capturedAtUtc']) <= stamp(meta['startedAtUtc']),
                'Browser/compatibility run is not bound to the unchanged pinned fixture supplement: ' + label)
        runs[label]['record']['verifiedBrowserFixtureManifest'] = identity(browser_fixtures_path)
    require(runs['isolated-core']['command'] == ['pnpm', '--filter', '@datacare/core', 'test'], 'Core suite narrowed')
    require(runs['isolated-web']['command'] == ['pnpm', '--filter', '@datacare/web', 'test'], 'Web suite narrowed')
    require(runs[args.api_label]['command'] ==
            ['node', 'scripts/parity-test-env.mjs', '--', 'pnpm', '--filter', '@datacare/api', 'test'],
            'API suite command differs from the complete isolated wrapper invocation')
    require(runs['isolated-types']['command'] ==
            ['pnpm', '--filter', '@datacare/api', 'exec', 'tsc', '-p', 'tsconfig.test.json', '--noEmit'],
            'Strict test compilation must use the unchanged complete project')
    require(runs['isolated-build']['command'] == ['pnpm', 'build'], 'Build target changed')
    require(runs['isolated-lint']['command'] == ['pnpm', 'lint'], 'Lint target changed')
    require(runs[args.browser_label]['command'] == ['pnpm', 'test:parity:browser'], 'Real-browser command changed')
    require(runs['isolated-smoke']['command'] == ['pnpm', 'test:browser'], 'Compatibility command changed')
    counts = {label: totals(runs[label]['text']) for label in ['isolated-core', 'isolated-web', args.api_label]}
    require(counts['isolated-core'] == {'files': 16, 'tests': 762, 'skipped': 0}, 'Unexpected full core count')
    require(counts['isolated-web'] == {'files': 27, 'tests': 294, 'skipped': 0}, 'Unexpected full web count')
    require(counts[args.api_label] == {'files': args.expected_api_files, 'tests': args.expected_api_tests, 'skipped': 0},
            'Final observed API counts differ from approved full summary')
    require(re.search(r'Tasks:\s+7 successful, 7 total', runs['isolated-build']['text']), 'Incomplete production build')
    require(re.search(r'Tasks:\s+10 successful, 10 total', runs['isolated-lint']['text']), 'Incomplete lint/types')
    for label, result in counts.items():
        runs[label]['record']['details'] = result

    for label, title, expected in [
        (args.scanner_label, 'Independent static measurement fixtures', 0),
        (args.register_label, 'Active completion register', 0),
        (args.docs_label, 'Current documentation references', 0),
        (args.chain_label, 'Checkpoint chain controls', 0),
        (args.kernel_label, 'Unchanged rounding adoption gate', 1),
        (args.depth_label, 'Current depth gate (corrected observed count)', 1),
        (args.dead_cell_label, 'Unchanged Return dead-cell gate', 1),
    ]:
        require(label not in runs, 'A verification label cannot stand for two checks')
        runs[label] = read_run(label, title, expected)
    require(re.search(r'\b127 bypasses', runs[args.kernel_label]['text']), 'Rounding gate count changed')
    require(re.search(r'96\s*->\s*104', runs[args.depth_label]['text']), 'Depth gate count changed')
    require('DEAD CELLS: 33' in runs[args.dead_cell_label]['text'], 'Dead-cell count changed')

    verification_path = EVIDENCE / args.verification
    require(verification_path.parent == EVIDENCE, 'Invalid readback record path')
    after = read_json(verification_path)
    require(after['inputManifestSha256'] == args.qualified_manifest_sha256 and
            after['verificationRoot'] == str(FROZEN) and after['frozenInputCount'] == len(rows) and
            after['changedFrozenInputs'] == [] and after['addedFrozenInputs'] == [] and
            after['supplementalBrowserFixtureManifestSha256'] == args.browser_fixtures_sha256 and
            after['changedBrowserFixtureInputs'] == [],
            'Final frozen source readback failed')
    finished = [stamp(run['meta']['finishedAtUtc']) for run in runs.values()
                if run['meta'].get('isolatedInputManifestSha256')]
    require(max(finished) <= stamp(after['verifiedAtUtc']), 'Source readback predates a frozen run finish')
    changed, added = active_drift(rows)
    require(after['changedActiveInputs'] == changed and after['addedActiveInputs'] == added,
            'Active input divergence changed after its complete explicit readback')
    absences = []
    for name in sorted(set(base['data'].get('externalAbsences', [])) | set(qualified['data'].get('externalAbsences', []))):
        frozen_exists = path_at(FROZEN, name, False).exists()
        active_exists = path_at(ROOT, name, False).exists()
        require(not frozen_exists, 'A declared absent frozen dependency appeared: ' + name)
        absences.append({'path': name, 'frozenExists': frozen_exists, 'activeExists': active_exists})
    require(after['externalAbsenceObservations'] == absences, 'External-absence observation changed')

    browser_relative = relative(args.browser_dir)
    require(browser_relative.startswith('test-results/parity-real-stack-round12'), 'Unexpected browser artifact directory')
    browser_path = path_at(FROZEN, 'web/' + browser_relative + '/result.json')
    browser = read_json(browser_path)
    require(browser['status'] == 'passed' and browser['mockedRequests'] == 0 and
            not browser.get('error') and not browser.get('errors'), 'Real browser did not pass without mocks')
    actual = {key for key, value in browser.items() if isinstance(value, dict) and isinstance(value.get('checks'), list)}
    require(actual == set(JOURNEYS), 'Browser journey set changed')
    for name in JOURNEYS:
        require(browser[name]['checks'] and browser[name].get('status', 'passed') == 'passed', 'Journey failed: ' + name)
    previous_browsers = [run['details']['result'] for run in prior['verification']
                        if run.get('details', {}).get('journeys') == 16]
    require(len(previous_browsers) == 1, 'Prior checkpoint must identify one complete16-journey result')
    previous_browser_path = path_at(ROOT, previous_browsers[0]['path'])
    require(sha(previous_browser_path) == previous_browsers[0]['sha256'], 'Frozen prior browser result changed')
    previous_browser = read_json(previous_browser_path)
    for name in JOURNEYS:
        require(browser[name]['checks'] == previous_browser[name]['checks'],
                'A required prior journey assertion was changed or omitted: ' + name)
    require(len(browser['columnSettings']['checks']) == 15, 'Column settings checks changed')
    row_checks_path = PLAN / 'evidence/implementation-2026-09-11-round9/browser-required-checks.json'
    bill_checks_path = PLAN / 'evidence/implementation-2026-09-11-round11/bill-browser-required-checks.json'
    require(sha(row_checks_path) == ROW_CHECKS_SHA and sha(bill_checks_path) == BILL_CHECKS_SHA,
            'Original required browser checks changed')
    require(browser['salesReturnReplay']['checks'] == read_json(row_checks_path)['checks'], 'Row preview checks changed')
    bill_required = read_json(bill_checks_path)
    require(bill_required['independentVectorSha256'] == BILL_GOLDEN_SHA and len(bill_required['checks']) == 15 and
            browser['salesReturnBillReplay']['checks'] == bill_required['checks'], 'Bill preview checks changed')
    require(sha(path_at(FROZEN, 'web/apps/api/test/fixtures/saleReturnBillReplay.independent.json')) == BILL_GOLDEN_SHA,
            'Bill independent fixture changed')
    require('PARITY_REAL_STACK_PASSED' in runs[args.browser_label]['text'] and
            'PARITY_ARTIFACT_DIR=' + browser_relative in runs[args.browser_label]['meta']['command'],
            'Browser output is not bound to the recorded artifact directory')
    browser_artifacts = []
    for path in browser_path.parent.rglob('*'):
        if path.is_file() and path.name != '.DS_Store':
            destination = path_at(ROOT, str(path.relative_to(FROZEN)))
            require(sha(destination) == sha(path), 'Root must preserve the exact frozen browser artifact copy')
            browser_artifacts.append(destination)
    browser_copy = ROOT / browser_path.relative_to(FROZEN)
    runs[args.browser_label]['record']['details'] = {
        'journeys': 16, 'journeyNames': JOURNEYS, 'mockedRequests': 0,
        'result': identity(browser_copy), 'originalFrozenResultPath': str(browser_path),
        'limits': 'Synthetic real-stack observations of the frozen revision only; no complete desktop or business acceptance.',
    }

    tasks = read_json(PLAN / '13-execution-backlog.json')['tasks']
    packages = read_json(PLAN / '07-work-items.json')['workItems']
    register = read_json(ROOT / 'web/docs/COMPLETION-REGISTER.json')['items']
    require(len(tasks) == 34 and all(row['status'] == 'open' for row in tasks), 'Original cards must stay open')
    require(len(packages) == 83 and all(row['status'] == 'open' for row in packages), 'Original packages must stay open')
    require(len(register) == 198 and all(row.get('state') == 'implemented-unverified' for row in register),
            'No original menu verification may be inferred')
    source_names = universe(ROOT, rows) | set(browser_rows) | {row['path'] for row in prior['sourceFiles']}
    observed_rows = {**rows, **browser_rows}
    source_names.add(str(Path(__file__).resolve().relative_to(ROOT)))
    source_names.update('parity-plan-2026-09-10/' + name for name in [
        'freeze_verification_workspace_round12.py', 'run_frozen_check_round12.py',
        'qualify_verification_workspace_round12.py',
        'run_qualified_check_round12.py',
        'capture_browser_fixtures_round12.py', 'run_browser_check_round12.py',
        'capture_implementation_checkpoint_round12.py', 'validate_plan.py', 'validate_current_review.py',
    ])
    sources = []
    for name in sorted(source_names):
        # Existing chain validators require current byte identities. A deleted
        # prior file is reported above but cannot silently disappear from37.
        path = path_at(ROOT, name)
        current = sha(path)
        sources.append({'path': name, 'sha256': current, 'frozenSha256': observed_rows.get(name),
                        'verificationAttribution': 'same-frozen-content' if observed_rows.get(name) == current
                        else 'active-capture-only-not-covered-by-frozen-checks'})
    old = {row['path']: row['sha256'] for row in prior['sourceFiles']}
    changes = [{'path': row['path'], 'beforeSha256': old[row['path']], 'afterSha256': row['sha256']}
               for row in sources if row['path'] in old and old[row['path']] != row['sha256']]
    # These two outputs are generated by the final validator after sealing, so
    # including their prior bytes would create a circular checkpoint dependency.
    artifacts = {path for path in EVIDENCE.rglob('*') if path.is_file() and path.name not in
                 {'.DS_Store', 'document-validation.json', 'document-validation-complete.txt'}}
    artifacts.update(browser_artifacts)
    artifacts.update([prior_path, row_checks_path, bill_checks_path, previous_browser_path])
    artifacts.update(PLAN / name for name in [
        '02-implementation-plan.md', '07-work-items.json', '12-execution-addendum.md',
        '13-execution-backlog.json', '36-implementation-progress-round12.md', 'README.md',
    ])
    artifacts.update(ROOT / 'web/docs' / name for name in ['HANDOFF.md', 'STATE-OF-PARITY.md', 'TECHNICAL-REFERENCE.md'])
    checkpoint = {
        'kind': 'datacare.parity-implementation-checkpoint/1.0',
        'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
        'displayTimezone': 'Asia/Kolkata', 'status': 'partial-implementation',
        'gitHead': subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=ROOT, text=True).strip(),
        'workingTree': 'Active work is preserved. Tests certify named isolated revisions only; every observed active divergence is explicitly unverified by those runs.',
        'baseReviewSourceManifestSha256': sha(PLAN / 'evidence/review-2026-09-11/reviewed-source-hashes.json'),
        'priorCheckpoint': prior_path.name, 'priorCheckpointSha256': PRIOR_SHA,
        'progressDocument': '36-implementation-progress-round12.md',
        'wholeProductImplementationPercentage': None, 'verifiedMenus': 0,
        'acceptedExecutionCards': [], 'acceptedOriginalPackages': [],
        'implementedSlices': [
            'Pure session ledger-mode bootstrap and canonical semantic transitions with explicit unresolved authority',
            'Pure saved Return JSONB date/clock projection with preserved raw provenance and fractional truncation',
            'Internal snapshot-bound cross-book account-balance observation preserving source SQL NULL/CASE/time boundaries',
        ],
        'verifiedFrozenRevisions': [{key: value for key, value in item.items() if key in {'manifest', 'archive'}}
                                    for item in [base, qualified]],
        'supplementalInputQualification': identity(qualification_path),
        'supplementalBrowserFixtureManifest': identity(browser_fixtures_path),
        'verifiedBrowserFixtureFiles': [{'path': name, 'sha256': digest} for name, digest in sorted(browser_rows.items())],
        'verifiedFrozenSourceFiles': [{'path': name, 'sha256': digest} for name, digest in sorted(rows.items())],
        'frozenSourceReadback': identity(verification_path),
        'activeWorkspaceDivergence': {
            'status': 'not-covered-by-frozen-checks' if changed or added or any(x['activeExists'] for x in absences) else 'same-recorded-input-content',
            'changedInputs': changed, 'addedInputs': added, 'externalAbsences': absences,
            'scope': 'Complete declared verification-input universe, including every frozen seed and recursively discovered source/test input. Current helper/docs outside this universe are capture-only.',
            'limits': 'No drift allowlist. Separate supplemental checks must identify their own exact revision and cannot retroactively certify a changed active application.',
        },
        'sourceFiles': sources, 'changedPriorSourceFiles': changes,
        'verification': [run['record'] for run in runs.values()],
        'artifactFiles': [identity(path) for path in sorted(artifacts)],
        'historicalStageDisposition': {
            'reason': 'All pre-isolation shared-workspace attempts and the initial isolated API reference-input failures and isolated browser fixture-import failure are retained as historical. Base core/web/build/types remain bound to the original1546-input revision. Only a complete successful qualified API run certifies the audited supplemental reference universe. No filename or zero exit alone substitutes for the full summary and input proof.',
            'initialIsolatedApi': initial_api['record'],
            'initialIsolatedBrowser': initial_browser['record'],
        },
        'requiredOpenAcceptance': [
            'All34 original execution cards,83 packages and198 menu entries remain unverified/open.',
            'Trusted live session mode/context authority, original clock/import/runtime qualifications and same-transaction balance/preview integration remain open.',
            'Complete incoming/source/tag/component admission, outgoing/variant behavior, numeric stock/financial writers, settlement/refund/reversal and reporting remain open.',
            'Existing rounding/depth/dead-cell gates remain red at127/104/33 without threshold changes; Round11 depth102 remains historical.',
            'Independent desktop/device/provider, migration/recovery, business and production release acceptance remains open.',
        ],
        'limits': 'Frozen tests do not certify active later edits. Pure prerequisites do not establish authenticated session, numeric-write or known closing authority, complete parity or a percentage.',
    }
    # Close the capture window before either printing a candidate or exclusive
    # creation; repeated byte identity is not a claim of durable filesystem CAS.
    for name, digest in rows.items():
        require(sha(path_at(FROZEN, name)) == digest, 'Frozen input changed during checkpoint preparation')
    for name, digest in browser_rows.items():
        require(sha(path_at(FROZEN, name)) == digest and sha(path_at(ROOT, name)) == digest,
                'Supplemental browser fixture changed during checkpoint preparation')
    for row in sources:
        require(sha(path_at(ROOT, row['path'])) == row['sha256'], 'Active capture changed during preparation')
    require(universe(FROZEN, rows) == set(rows) and active_drift(rows) == (changed, added),
            'Input universe changed during checkpoint preparation')
    if args.seal:
        with output.open('x') as stream:
            stream.write(json.dumps(checkpoint, indent=2, ensure_ascii=False) + '\n')
    summary = {'status': 'sealed' if args.seal else 'validated-not-written',
               'checkpoint': str(output.relative_to(ROOT)), 'frozenInputs': len(rows),
               'activeChanged': len(changed), 'activeAdded': len(added),
               'api': counts[args.api_label], 'core': counts['isolated-core'], 'web': counts['isolated-web'],
               'browserJourneys': 16, 'supplementalBrowserFixtures': len(browser_rows)}
    if args.seal:
        summary['sha256'] = sha(output)
    print(json.dumps(checkpoint if args.print_candidate else summary, indent=2, ensure_ascii=False))


if __name__ == '__main__':
    main()
