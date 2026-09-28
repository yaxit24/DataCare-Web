"""Seal Round11 only after actual final checks; never overwrite a checkpoint.

This helper performs no test, DB, browser, build or deployment action. Root owns
its execution after the final run. --check-only validates without writing35.
"""
from pathlib import Path
import argparse
import datetime
import hashlib
import json
import re
import shlex
import subprocess

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
WEB = ROOT / 'web'
EVIDENCE = PLAN / 'evidence/implementation-2026-09-11-round11'
PRIOR_SHA = '7a61c80e3aa999b809ea792489b51fee9eee01555ff5898bdae328772e4749f7'
ROW_CHECKS_SHA = 'f48f8062ea01b0bb94dea90fcb6156c5e41e787ea99d2bf7e22462ab09ba08ef'
BILL_CHECKS_SHA = '2aac326a8124c6baec42f2cad8969337d8c497fb1a836d0edb914e8e38ea997e'
BILL_GOLDEN_SHA = '1d0cecba70ed751c64a14b506f18468a49778987dda285b0a0abbb37b7b48410'
JOURNEYS = [
    'designBook', 'designCalculations', 'designRepeat', 'genericImageConflict',
    'repairImageConflict', 'salesReturnSaved', 'tourOrder', 'creditNote',
    'salesOrderDesign', 'salesOrder', 'orderImages', 'imageConflict', 'mfgLot',
    'columnSettings', 'salesReturnReplay', 'salesReturnBillReplay',
]


def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def identity(path):
    return {'path': str(path.relative_to(ROOT)), 'sha256': sha(path)}


def read_json(path):
    return json.loads(path.read_text())


def local_path(relative):
    assert isinstance(relative, str) and not Path(relative).is_absolute(), relative
    path = (ROOT / relative).resolve()
    assert path.is_relative_to(ROOT) and path.is_file(), relative
    return path


def stamp(value):
    return datetime.datetime.fromisoformat(value.replace('Z', '+00:00'))


def check_run(label, title, expected=0):
    metadata_path = EVIDENCE / (label + '.run.json')
    meta = read_json(metadata_path)
    assert meta['exitCode'] == expected, (label, meta['exitCode'])
    assert meta['status'] == ('passed' if expected == 0 else 'failed'), label
    assert stamp(meta['startedAtUtc']) <= stamp(meta['finishedAtUtc']), label
    log = local_path(meta['log'])
    # A successful tsc --noEmit invocation is intentionally silent. Its actual
    # exit status, exact argv and unchanged full-project inputs are the proof.
    assert log.stat().st_size > 0 or (label == 'test-types' and expected == 0), label
    command = meta['command']
    assert isinstance(command, list) and command and all(isinstance(x, str) for x in command)
    return {
        'name': title, 'command': shlex.join(command), 'status': meta['status'],
        'exitCode': meta['exitCode'], 'log': str(log.relative_to(ROOT)),
        'logSha256': sha(log), 'invocation': identity(metadata_path),
    }, meta, log.read_text()


def verified_snapshot(snapshot_name, verification_name, run_meta):
    snapshot_path = EVIDENCE / snapshot_name
    verification_path = EVIDENCE / verification_name
    before = read_json(snapshot_path)
    after = read_json(verification_path)
    assert after['status'] == 'passed' and after['changedInputs'] == [], verification_name
    if 'addedInputs' in after:
        assert after['addedInputs'] == [], verification_name
    digest = after.get('inputSnapshotSha256', after.get('snapshotSha256'))
    assert digest == sha(snapshot_path), verification_name
    assert stamp(before['capturedAtUtc']) <= stamp(run_meta['startedAtUtc']), snapshot_name
    assert stamp(run_meta['finishedAtUtc']) <= stamp(after['verifiedAtUtc']), verification_name
    rows = before['files']
    assert rows and len({r['path'] for r in rows}) == len(rows), snapshot_name
    for row in rows:
        assert sha(local_path(row['path'])) == row['sha256'], row['path']
    return rows, {
        'snapshot': identity(snapshot_path), 'verification': identity(verification_path),
        'inputs': len(rows), 'changedInputs': [], 'addedInputs': after.get('addedInputs', []),
    }


def vitest_totals(text):
    # Require the complete successful summary, not a single focused test line.
    clean = re.sub(r'\x1b\[[0-9;]*m', '', text)
    files = re.search(r'Test Files\s+(\d+) passed \((\d+)\)', clean)
    tests = re.search(r'Tests\s+(\d+) passed \((\d+)\)', clean)
    assert files and tests and files[1] == files[2] and tests[1] == tests[2]
    assert not re.search(r'\b(?:[1-9]\d*)\s+(?:failed|skipped|todo)\b', clean, re.I)
    return {'files': int(files[1]), 'tests': int(tests[1]), 'skipped': 0}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--api-label', default='api-full-final')
    parser.add_argument('--api-input-label', default='final')
    parser.add_argument('--browser-label', default='browser-real-final')
    parser.add_argument('--browser-dir', default='test-results/parity-real-stack-round11-final')
    parser.add_argument('--docs-label', default='document-references-final')
    parser.add_argument('--check-only', action='store_true')
    args = parser.parse_args()
    for label in [args.api_label, args.api_input_label, args.browser_label, args.docs_label]:
        assert re.fullmatch(r'[a-z0-9-]+', label), label
    output = PLAN / '35-implementation-checkpoint-round11.json'
    assert not output.exists(), 'Refusing to overwrite an immutable checkpoint'

    prior_path = PLAN / '33-implementation-checkpoint-round10.json'
    assert sha(prior_path) == PRIOR_SHA
    prior = read_json(prior_path)
    baseline_path = PLAN / 'evidence/review-2026-09-11/reviewed-source-hashes.json'
    verification = []
    runs = {}
    checks = [
        (args.api_label, 'Final full isolated API regression', 0),
        (args.browser_label, 'Final real browser integration', 0),
        ('core-tests', 'Complete core regression', 0),
        ('web-tests', 'Complete web unit regression', 0),
        ('build', 'Production workspace build', 0),
        ('lint', 'Workspace lint and application types', 0),
        ('test-types', 'Complete strict API test compiler', 0),
        ('browser-smoke', 'Legacy mocked browser compatibility', 0),
        ('scanner-tests', 'Static measurement regression fixtures', 0),
        ('register', 'Completion register', 0),
        (args.docs_label, 'Documentation references', 0),
        ('checkpoint-chain', 'Checkpoint chain positive and negative controls', 0),
        ('kernel-gate', 'Existing rounding adoption gate', 1),
        ('depth-gate', 'Existing depth gate', 1),
        ('dead-cells', 'Existing Return dead-cell gate', 1),
    ]
    for label, title, expected in checks:
        result, meta, text = check_run(label, title, expected)
        verification.append(result)
        runs[label] = {'result': result, 'meta': meta, 'text': text}

    # Broad final API inputs include the final browser fixtures. Historical
    # "complete" and "verified" stages are retained, never relaxed by an allowlist.
    api_rows, api_proof = verified_snapshot(
        'api-input-snapshot-' + args.api_input_label + '.json',
        'api-input-verification-' + args.api_input_label + '.json',
        runs[args.api_label]['meta'])
    core_rows, core_proof = verified_snapshot(
        'core-input-snapshot-complete.json', 'core-input-verification-complete.json',
        runs['core-tests']['meta'])
    build_rows, build_proof = verified_snapshot(
        'build-source-inputs-complete.json', 'build-source-verification-complete.json',
        runs['build']['meta'])
    type_rows, type_proof = verified_snapshot(
        'test-types-inputs-complete.json', 'test-types-verification-complete.json',
        runs['test-types']['meta'])
    counts = {label: vitest_totals(runs[label]['text'])
              for label in [args.api_label, 'core-tests', 'web-tests']}
    assert counts[args.api_label] == {'files': 237, 'tests': 2159, 'skipped': 0}
    assert counts['core-tests'] == {'files': 14, 'tests': 499, 'skipped': 0}
    assert counts['web-tests'] == {'files': 27, 'tests': 294, 'skipped': 0}
    for label, totals in counts.items():
        runs[label]['result']['details'] = totals
    runs[args.api_label]['result']['details']['inputProof'] = api_proof
    runs['core-tests']['result']['details']['inputProof'] = core_proof
    assert re.search(r'Tasks:\s+7 successful, 7 total', runs['build']['text'])
    assert re.search(r'Tasks:\s+10 successful, 10 total', runs['lint']['text'])
    runs['build']['result']['details'] = {'targets': 7, 'inputProof': build_proof}
    runs['test-types']['result']['details'] = {
        'sameCompleteProject': True, 'inputProof': type_proof,
        'limits': 'Complete tsconfig.test.json; no test exclusions or narrowed compiler project.',
    }
    assert re.search(r'\b127 bypasses', runs['kernel-gate']['text'])
    assert re.search(r'96\s*->\s*102', runs['depth-gate']['text'])
    assert 'DEAD CELLS: 33' in runs['dead-cells']['text']
    runs['kernel-gate']['result']['details'] = {'roundingHelpers': 127, 'ceiling': 108, 'thresholdChanged': False}
    runs['depth-gate']['result']['details'] = {'unreachableFields': 102, 'ceiling': 96, 'thresholdChanged': False}
    runs['dead-cells']['result']['details'] = {
        'findings': 33, 'thresholdChanged': False,
        'limits': 'Unresolved Return fields include unsupported scanner syntax; no runtime consumption or full field acceptance inferred.',
    }
    runs['browser-smoke']['result']['details'] = {'limits': 'Mocked compatibility only; no real-stack or desktop acceptance credit.'}

    browser_dir = (WEB / args.browser_dir).resolve()
    assert browser_dir.is_relative_to(WEB / 'test-results'), args.browser_dir
    assert browser_dir.name.startswith('parity-real-stack-round11'), args.browser_dir
    browser_path = browser_dir / 'result.json'
    browser = read_json(browser_path)
    assert browser['status'] == 'passed' and browser['mockedRequests'] == 0
    assert not browser.get('error') and not browser.get('errors')
    actual_journeys = {key for key, value in browser.items()
                       if isinstance(value, dict) and isinstance(value.get('checks'), list)}
    assert actual_journeys == set(JOURNEYS) and len(JOURNEYS) == 16
    for name in JOURNEYS:
        assert browser[name]['checks'], name
        assert browser[name].get('status', 'passed') == 'passed', name
    assert len(browser['columnSettings']['checks']) == 15
    row_checks_path = PLAN / 'evidence/implementation-2026-09-11-round9/browser-required-checks.json'
    bill_checks_path = EVIDENCE / 'bill-browser-required-checks.json'
    assert sha(row_checks_path) == ROW_CHECKS_SHA
    assert sha(bill_checks_path) == BILL_CHECKS_SHA
    assert browser['salesReturnReplay']['checks'] == read_json(row_checks_path)['checks']
    bill_required = read_json(bill_checks_path)
    assert bill_required['independentVectorSha256'] == BILL_GOLDEN_SHA
    assert len(bill_required['checks']) == 15
    assert browser['salesReturnBillReplay']['checks'] == bill_required['checks']
    assert sha(WEB / 'apps/api/test/fixtures/saleReturnBillReplay.independent.json') == BILL_GOLDEN_SHA
    assert 'PARITY_REAL_STACK_PASSED' in runs[args.browser_label]['text']
    assert 'PARITY_ARTIFACT_DIR=' + args.browser_dir in runs[args.browser_label]['meta']['command']
    runs[args.browser_label]['result']['details'] = {
        'journeys': 16, 'journeyNames': JOURNEYS, 'mockedRequests': 0,
        'result': identity(browser_path), 'retainedV1RequiredChecks': identity(row_checks_path),
        'newBillRequiredChecks': identity(bill_checks_path),
        'limits': 'Synthetic isolated real-stack journeys; no independent Windows, provider, physical-device or complete business acceptance.',
    }

    historical_initial = EVIDENCE / 'api-input-verification-complete.json'
    first = read_json(historical_initial)
    assert first['status'] == 'failed'
    assert first['changedInputs'] == ['web/apps/web/test/sales-return-bill-replay.journey.mjs']
    assert first['addedInputs'] == []
    assert first['snapshotSha256'] == sha(EVIDENCE / 'api-input-snapshot-complete.json')

    paths = {local_path(row['path']) for row in prior['sourceFiles']}
    for rows in [api_rows, core_rows, build_rows, type_rows]:
        paths.update(local_path(row['path']) for row in rows)
    paths.update(PLAN / name for name in [
        'capture_api_inputs_round11.py', 'capture_build_inputs_round11.py',
        'capture_core_inputs_round11.py', 'capture_test_types_round11.py',
        'capture_implementation_checkpoint_round11.py', 'run_check_round11.py',
        'build_execution_addendum.py', 'execution-addendum-intro.md',
        'validate_plan.py', 'validate_current_review.py',
    ])
    sources = [identity(path) for path in sorted(paths)]
    old = {row['path']: row['sha256'] for row in prior['sourceFiles']}
    changes = [
        {'path': row['path'], 'beforeSha256': old[row['path']], 'afterSha256': row['sha256']}
        for row in sources if row['path'] in old and old[row['path']] != row['sha256']
    ]
    # This round adds a projection and index exports; prior pure kernels remain frozen.
    for row in prior['sourceFiles']:
        if row['path'].startswith('web/packages/core/src/') and not row['path'].endswith('/index.ts'):
            assert sha(local_path(row['path'])) == row['sha256'], row['path']

    artifacts = {path for path in EVIDENCE.rglob('*') if path.is_file()
                 and path.name not in {'.DS_Store', 'document-validation.json', 'document-validation-complete.txt'}}
    artifacts.update(path for directory in (WEB / 'test-results').glob('parity-real-stack-round11*')
                     for path in directory.rglob('*') if path.is_file() and path.name != '.DS_Store')
    artifacts.update(path for path in (WEB / 'docs/parity-evidence').glob('*round11*') if path.is_file())
    artifacts.update(PLAN / name for name in [
        '02-implementation-plan.md', '07-work-items.json', '12-execution-addendum.md',
        '13-execution-backlog.json', '34-implementation-progress-round11.md', 'README.md',
    ])
    artifacts.update(WEB / 'docs' / name for name in ['HANDOFF.md', 'STATE-OF-PARITY.md', 'TECHNICAL-REFERENCE.md'])
    artifacts.update([row_checks_path, prior_path])
    artifacts.update(PLAN / 'evidence/implementation-2026-09-11-round10' / name
                     for name in ['document-validation.json', 'document-validation-complete.txt'])
    assert all(path.is_file() for path in artifacts)

    checkpoint = {
        'kind': 'datacare.parity-implementation-checkpoint/1.0',
        'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
        'displayTimezone': 'Asia/Kolkata', 'status': 'partial-implementation',
        'gitHead': subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=ROOT, text=True).strip(),
        'workingTree': 'Existing dirty working tree preserved; isolated synthetic test data only; no commit, deployment or release certification.',
        'baseReviewSourceManifestSha256': sha(baseline_path),
        'priorCheckpoint': prior_path.name, 'priorCheckpointSha256': sha(prior_path),
        'progressDocument': '34-implementation-progress-round11.md',
        'wholeProductImplementationPercentage': None, 'verifiedMenus': 0,
        'acceptedExecutionCards': [], 'acceptedOriginalPackages': [],
        'implementedSlices': [
            'Exact saved incoming Return header-to-bill projection with immutable raw values and no load calculation',
            'Separate trusted same-snapshot saved bill preview with full incoming aggregation, loaded/opened/event phases and per-event callbacks',
            'Qualified tax settings and physical master-label observations bound to a separate stale-input token; unavailable ledger closing retained',
            'Guarded separate bill preview UI with explicit journals, draft recovery and exclusive metadata/row-preview ownership',
        ],
        'sourceFiles': sources, 'changedPriorSourceFiles': changes,
        'verification': verification, 'artifactFiles': [identity(path) for path in sorted(artifacts)],
        'historicalStageDisposition': {
            'initialBroadInputDrift': identity(historical_initial),
            'reason': 'Initial broad capture detected a browser-fixture edit. Initial and corrected stages remain historical; final full API and browser use the final broad snapshot without a drift allowlist.',
        },
        'requiredOpenAcceptance': [
            'All original acceptance of34 execution cards and83 packages; no menu or package is closed',
            'Trusted versioned session MsDataType authority and source-qualified cross-book customer opening/closing, with exact date/time and NULL/group/helper semantics',
            'Complete source selection/application, incoming item/tag/component admission, remaining cell/keyboard/header events, outgoing exchange and UAE/other supported variants',
            'Atomic numeric stock/financial writers, settlement/refund/allocation, dependency transitions, retries, full reversal and report reconciliation',
            'Independent Windows binary/locale/ActiveX observations and acceptance of documented mathematical/profile/UI differences',
            'All remaining order/credit/repair/manufacturing/tag/image/report/migration/device/provider descendants in the original plan',
            'Unchanged rounding/depth/dead-cell release gates127/102/33 and complete input-to-persistence-to-reload-to-report field proof',
            'Full-product business acceptance, migration/recovery rehearsals, operational verification and release certification',
        ],
        'limits': 'Bounded saved incoming read-only preview, not financial mutation authority. Closing remains unavailable, not zero. Focused checks overlap the full suites; failed/superseded stages remain preserved. No functional percentage, complete desktop parity, business or production acceptance follows from these results.',
    }
    summary = {
        'checkpoint': str(output.relative_to(ROOT)), 'sources': len(sources),
        'artifacts': len(artifacts), 'verification': len(verification),
        'api': counts[args.api_label], 'core': counts['core-tests'],
        'web': counts['web-tests'], 'browserJourneys': 16,
    }
    if args.check_only:
        summary['status'] = 'validated-not-written'
    else:
        # Exclusive creation guards against a concurrent seal after validation.
        with output.open('x') as stream:
            stream.write(json.dumps(checkpoint, indent=2, ensure_ascii=False) + '\n')
        summary['sha256'] = sha(output)
    print(json.dumps(summary, indent=2))


if __name__ == '__main__':
    main()
