"""Verify completed Round14 browser records; --retain copies allowlisted public artifacts.

No browser, database, product code, or subprocess is executed. Run only after the
owner confirms all three runs are complete. Default mode writes nothing.
"""
from pathlib import Path
import argparse
import datetime as dt
import hashlib
import json
import re

STAGE = Path(__file__).resolve().parent
PLAN = 'parity-plan-2026-09-10'
ROUND = PLAN + '/evidence/implementation-2026-09-12-round14'
SHA = re.compile(r'[0-9a-f]{64}')
PRIVATE = {'web/.env.parity-test', 'web/.env', 'web/packages/db/.env',
           'web/packages/db/prisma/.env', 'web/apps/api/.env'}


def require(condition, message):
    if not condition:
        raise ValueError(message)


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def load(path):
    return json.loads(path.read_text())


def path_at(root, name):
    path = root / name
    require(not Path(name).is_absolute() and '..' not in Path(name).parts, name)
    require(path.resolve().is_relative_to(root.resolve()) and not path.is_symlink(), name)
    return path


def identity(root, path):
    require(path.is_file() and not path.is_symlink(), str(path))
    return {'path': str(path.relative_to(root)), 'sha256': digest(path)}


def clock(value):
    result = dt.datetime.fromisoformat(value.replace('Z', '+00:00'))
    require(result.tzinfo is not None, 'Unqualified time')
    return result


def strings(value, expected, label):
    require(value == expected and len(set(value)) == len(value), label)


def zero_indicators(value, label):
    if isinstance(value, list):
        for child in value:
            zero_indicators(child, label)
    elif isinstance(value, dict):
        for key, child in value.items():
            if re.search('mock|intercept', key, re.I):
                if re.search('mock', key, re.I) and re.search('request|response', key, re.I):
                    require(type(child) is int and child == 0, label + '.' + key)
                else:
                    require((type(child) is int and child == 0) or child is False or
                            (isinstance(child, list) and not child), label + '.' + key)
            else:
                zero_indicators(child, label + '.' + key)


def faults(detail, expected, kind, label, count_field=False):
    require(detail['status'] == 'passed', label + ' status')
    require(type(detail['syntheticBusinessResponses']) is int and
            detail['syntheticBusinessResponses'] == 0, label + ' synthetic')
    require(detail['cleanupErrors'] == [], label + ' cleanup')
    rows = detail['transportFaultInjections']
    require(len(rows) == len(expected), label + ' fault count')
    for row, (name, resolution) in zip(rows, expected):
        require(row['name'] == name and row['kind'] == kind and
                row['upstreamStatus'] == 200 and row['resolution'] == resolution,
                label + ' fault identity/resolution')
        require(SHA.fullmatch(row['upstreamBodySha256']) is not None, label + ' upstream hash')
        if kind == 'actual-upstream-response-hold':
            require(SHA.fullmatch(row['requestBodySha256']) is not None, label + ' request hash')
    if count_field:
        require(detail['interceptionRegistrations'] == len(expected), label + ' registrations')


def verify_result(kind, data, contract):
    require(data['status'] == 'passed' and 'error' not in data, kind + ' result status')
    if kind == 'baseline':
        strings([row['journeyId'] for row in data['journeys']], contract['baselineIds'], '17 exact IDs')
        require(all(row['status'] == 'passed' for row in data['journeys']), 'baseline statuses')
        for key in ['mockedRequests', 'mockedResponses', 'interceptionIndicators']:
            require(type(data[key]) is int and data[key] == 0, key)
        zero_indicators(data, 'baseline')
        for key in contract['baselineDetailKeys'].values():
            detail = data[key]
            require(detail.get('status', 'passed') == 'passed', key + ' status')
            require(isinstance(detail['checks'], list) and detail['checks'] and
                    all(isinstance(s, str) and s.strip() for s in detail['checks']), key + ' checks')
        labour = data['salesReturnLabourReplay']
        strings(labour['checks'], contract['baselineLabourChecks'], 'baseline labour12')
        require(len(labour['snapshots']) == 4, 'baseline labour snapshots')
        for row in labour['snapshots']:
            require(row['tables'] == 29 and SHA.fullmatch(row['beforeSha256']) is not None and
                    row['beforeSha256'] == row['afterSha256'], 'baseline labour no-write snapshots')
        return {'baselineJourneys': 17, 'labourChecks': 12, 'mockedRequests': 0,
                'mockedResponses': 0, 'interceptionIndicators': 0,
                'cleanupQualification': 'Completed exit-zero run required; result precedes outer cleanup.'}
    if kind == 'context':
        a, b = data['sessionContext'], data['sessionContextLifecycle']
        strings(a['checks'], contract['contextChecks'], 'context12')
        strings(b['checks'], contract['contextLifecycleChecks'], 'context additive2')
        strings(data['requiredChecks'], contract['contextChecks'] + contract['contextLifecycleChecks'], 'context14')
        faults(a, [('same-scope-open', 'deliver-unchanged'),
                   ('late-component-defaults-after-ABA', 'deliver-unchanged'),
                   ('committed-selection-response-lost', 'abort-after-commit')],
               'real-upstream-response-hold', 'context', True)
        faults(b, [('selection-departure-success', 'deliver-unchanged'),
                   ('selection-departure-drop', 'abort-after-commit')],
               'real-upstream-response-hold', 'context additive', True)
        require(data['actualInterceptionRegistrations'] == 5, 'context registrations')
        return {'sessionLifecycleChecks': 14, 'sessionActualResponseFaults': 5,
                'syntheticBusinessResponses': 0, 'journeyCleanupErrors': [],
                'cleanupQualification': 'Completed exit-zero run required; result precedes outer cleanup.'}
    detail = data['labourPreviewLifecycle']
    strings(data['requiredChecks'], contract['labourLifecycleChecks'], 'labour required5')
    strings(detail['checks'], contract['labourLifecycleChecks'], 'labour completed5')
    faults(detail, [('U04-lookup-draft-replaced', 'deliver-unchanged'),
                    ('U05-lookup-close-reopen', 'deliver-unchanged'),
                    ('U06-lookup-route-departure', 'deliver-unchanged'),
                    ('U12-append-reply-lost', 'abort-after-successful-upstream-read')],
           'actual-upstream-response-hold', 'labour')
    require(data['actualInterceptionRegistrations'] == 4 and data['cleanupErrors'] == [], 'labour cleanup/faults')
    require(data['fixtureSha256'] == contract['fixtureSha256'], 'labour fixture identity')
    require(detail['observedPreSessionContextRefusals'] == 1 and
            detail['previewAuditRows'] == detail['previewPosts'] - 1 and
            detail['businessSnapshotTables'] == 35, 'labour audit/snapshot accounting')
    return {'labourLifecycleChecks': 5, 'labourActualResponseFaults': 4,
            'syntheticBusinessResponses': 0, 'cleanupErrors': []}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--root', type=Path, default=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted'))
    parser.add_argument('--baseline-label', default='browser-bound')
    parser.add_argument('--context-label', default='browser-context-bound')
    parser.add_argument('--labour-label', default='browser-labour-bound')
    parser.add_argument('--retain', action='store_true')
    args = parser.parse_args()
    root, contract = args.root.resolve(), load(STAGE / 'contract.json')
    for ref in contract['sources']:
        require(digest(path_at(root, ref['path'])) == ref['sha256'], 'Frozen contract source changed: ' + ref['path'])
    specifications = [
        ('baseline', args.baseline_label, 'parity-real-stack-round14-bound', 'PARITY_ARTIFACT_DIR', 'parity.real-stack.mjs'),
        ('context', args.context_label, 'session-context-round14-bound', 'SESSION_CONTEXT_ARTIFACT_DIR', 'session-context.real-stack.additive.mjs'),
        ('labour', args.labour_label, 'labour-preview-lifecycle-round14-bound', 'LABOUR_PREVIEW_ARTIFACT_DIR', 'labour-preview-lifecycle.real-stack.mjs'),
    ]
    runs, files = [], []
    for kind, label, folder, variable, runner in specifications:
        require(re.fullmatch('[a-z0-9-]+', label) is not None, 'Invalid label')
        run_path = path_at(root, ROUND + '/' + label + '.run.json')
        run = load(run_path)
        require(run['status'] == 'passed' and run['exitCode'] == 0 and run['cwd'] == 'web', label + ' completed run')
        for key in ['changedInputs', 'changedPrivateInputs', 'changedRuntimeInputs']:
            require(run[key] == [], label + ' ' + key)
        require(run['command'] == ['env', variable + '=test-results/' + folder, 'node',
                'scripts/parity-test-env.mjs', '--', 'node', 'apps/web/test/' + runner], label + ' command')
        log, manifest = path_at(root, run['log']), path_at(root, run['inputManifest'])
        require(digest(log) == run['logSha256'] and digest(manifest) == run['inputManifestSha256'], label + ' evidence hashes')
        inputs = load(manifest)
        require(set(inputs['privateInputFiles']) == PRIVATE, label + ' private input shape')
        require(inputs['runtimeInputFiles'], label + ' runtime inputs')
        for ref in contract['sources']:
            require(inputs['files'].get(ref['path']) == ref['sha256'], label + ' source binding: ' + ref['path'])
        folder_path = path_at(root, 'web/test-results/' + folder)
        result_path = folder_path / 'result.json'
        data = load(result_path)
        require(clock(run['startedAtUtc']) <= clock(data['startedAt']) <= clock(data['finishedAt'])
                <= clock(run['finishedAtUtc']), label + ' result time binding')
        checks = verify_result(kind, data, contract)
        public, excluded = [], []
        for path in sorted(folder_path.iterdir()):
            require(path.is_file() and not path.is_symlink(), 'Unexpected artifact entry: ' + str(path))
            ref = identity(root, path)
            if path.suffix == '.png' or path.name in {'result.json', 'next-server.log'}:
                files.append((path, folder, ref)); public.append(ref)
            else:
                excluded.append(ref)
        require(any(ref['path'].endswith('.png') for ref in public), label + ' screenshots missing')
        runs.append({'kind': kind, 'run': identity(root, run_path), 'log': identity(root, log),
                     'inputManifest': identity(root, manifest), 'result': identity(root, result_path),
                     'verification': checks, 'publicArtifacts': public, 'excludedArtifacts': excluded})
    destination = root / ROUND / 'verified-browser-artifacts'
    qualification = root / ROUND / 'retained-browser-artifacts-qualification.json'
    output = {'kind': 'round14-browser-artifact-retention/v1', 'status': 'verified',
              'retained': args.retain, 'verifiedAtUtc': dt.datetime.now(dt.timezone.utc).isoformat(),
              'contractSha256': digest(STAGE / 'contract.json'),
              'verifierSha256': digest(Path(__file__)), 'sources': contract['sources'], 'runs': runs,
              'copiedFiles': [], 'qualification': 'Exact result/check/fault identities and completed run records verified. No full desktop, hardware or production acceptance. Baseline zero interception and explicit fault suites remain separate.'}
    if args.retain:
        require(not destination.exists() and not qualification.exists(), 'Retention destination already exists; never overwrite history')
        destination.mkdir()
        for path, folder, ref in files:
            require(digest(path) == ref['sha256'], 'Artifact changed before copy')
            target = destination / folder / path.name
            target.parent.mkdir(exist_ok=True)
            with target.open('xb') as stream:
                stream.write(path.read_bytes())
            require(digest(path) == ref['sha256'] == digest(target), 'Artifact copy mismatch')
            output['copiedFiles'].append(identity(root, target))
        for record in runs:
            for key in ['run', 'log', 'inputManifest', 'result']:
                ref = record[key]
                require(digest(path_at(root, ref['path'])) == ref['sha256'], 'Run evidence changed during retention')
            all_refs = record['publicArtifacts'] + record['excludedArtifacts']
            expected_names = {Path(ref['path']).name for ref in all_refs}
            source_folder = path_at(root, record['result']['path']).parent
            require({p.name for p in source_folder.iterdir()} == expected_names, 'Artifact membership changed')
            for ref in all_refs:
                require(digest(path_at(root, ref['path'])) == ref['sha256'], 'Artifact changed during retention')
        for ref in contract['sources']:
            require(digest(path_at(root, ref['path'])) == ref['sha256'], 'Contract source changed during retention')
        with qualification.open('x') as stream:
            json.dump(output, stream, indent=2); stream.write('\n')
    print(json.dumps({'status': 'retained' if args.retain else 'verified-read-only',
                      'baselineJourneys': 17, 'contextChecks': 14, 'contextTransportFaults': 5,
                      'labourChecks': 5, 'labourTransportFaults': 4,
                      'publicArtifacts': len(files),
                      'qualification': str(qualification) if args.retain else None,
                      'qualificationSha256': digest(qualification) if args.retain else None}, indent=2))


if __name__ == '__main__':
    main()
