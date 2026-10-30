#!/usr/bin/env python3
"""Check a frozen feature matrix and run bundle, not the truth of browser observations."""
import argparse
import hashlib
import json
import re
from datetime import datetime
from pathlib import Path

GROUPS = {f'T{i:02}' for i in range(1, 19)}
STATUSES = {'passed', 'failed', 'blocked', 'untested', 'not-applicable'}
DESKTOP = {'matched', 'different', 'blocked', 'not-run'}


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def validate(matrix, run, matrix_hash, root):
    errors = []

    def require(condition, message):
        if not condition:
            errors.append(message)

    def nonempty(value):
        return isinstance(value, str) and bool(value.strip())

    require(run.get('matrixSha256') == matrix_hash, 'matrix identity mismatch')
    for key, width in [('candidate', 40), ('inputsHash', 64), ('fixtureHash', 64), ('settingsHash', 64)]:
        value = matrix.get(key)
        require(isinstance(value, str) and bool(re.fullmatch(r'[0-9a-f]{' + str(width) + '}', value)),
                f'invalid {key}')
        require(run.get(key) == value, f'{key} mismatch')
    require(nonempty(matrix.get('feature')), 'feature scope is required')
    require(run.get('businessResponseMocks') == 0 and type(run.get('businessResponseMocks')) is int,
            'business response mock count must be explicitly zero')
    try:
        times = [datetime.fromisoformat(run[k]) for k in ['startedAt', 'finishedAt']]
        require(all(t.tzinfo is not None for t in times) and times[0] <= times[1], 'invalid run times')
    except (KeyError, ValueError, TypeError):
        errors.append('timezone-qualified startedAt and finishedAt are required')

    def indexed(value, name):
        require(isinstance(value, list) and bool(value), f'{name} must be a nonempty array')
        result = {}
        for case in value if isinstance(value, list) else []:
            if not isinstance(case, dict) or not nonempty(case.get('id')):
                errors.append(f'invalid {name} case')
                continue
            require(case['id'] not in result, f'duplicate {name} case: {case["id"]}')
            result[case['id']] = case
        return result

    required = indexed(matrix.get('cases'), 'matrix')
    actual = indexed(run.get('cases'), 'run')
    require(set(required) == set(actual),
            f'case set mismatch: missing={sorted(set(required)-set(actual))}, unknown={sorted(set(actual)-set(required))}')
    require({c.get('group') for c in required.values()} == GROUPS, 'matrix must disposition every T01-T18 group')
    counts = {s: 0 for s in sorted(STATUSES)}
    desktop_matches = 0
    applicable = 0
    root = root.resolve()

    def artifacts(case_id, value, kinds):
        require(isinstance(value, dict), f'{case_id}: evidence must be an object')
        for kind in kinds:
            entry = value.get(kind) if isinstance(value, dict) else None
            if not isinstance(entry, dict):
                errors.append(f'{case_id}: missing {kind} evidence')
                continue
            path = entry.get('path')
            if not nonempty(path) or Path(path).is_absolute():
                errors.append(f'{case_id}: {kind} path must be relative to evidence root')
                continue
            resolved = (root / path).resolve()
            if not resolved.is_relative_to(root) or not resolved.is_file():
                errors.append(f'{case_id}: {kind} artifact missing or outside evidence root')
            elif digest(resolved) != entry.get('sha256'):
                errors.append(f'{case_id}: {kind} artifact hash mismatch')

    for case_id, case in required.items():
        result = actual.get(case_id, {})
        state = result.get('status')
        require(state in STATUSES, f'{case_id}: invalid status')
        if state in counts:
            counts[state] += 1
        require(type(case.get('applicable')) is bool, f'{case_id}: explicit applicability required')
        require(nonempty(case.get('source')), f'{case_id}: desktop/contract source required')
        if case.get('applicable') is False:
            require(nonempty(case.get('reason')), f'{case_id}: N/A needs a source-backed reason in the matrix')
            require(state == 'not-applicable', f'{case_id}: matrix N/A disposition changed')
            continue
        applicable += 1
        require(state != 'not-applicable', f'{case_id}: applicable case cannot become N/A')
        kinds = case.get('requiredEvidence', [])
        require(isinstance(kinds, list) and all(isinstance(x, str) for x in kinds)
                and {'browser', 'expected'}.issubset(kinds), f'{case_id}: browser and independent expected evidence required')
        if case.get('kind') in {'mutation', 'refusal'}:
            require('database' in kinds, f'{case_id}: persisted/no-change database proof required')
        if case.get('kind') == 'mutation':
            require('downstream' in kinds, f'{case_id}: downstream business proof required')
        if case.get('kind') == 'output':
            require('output' in kinds, f'{case_id}: rendered/exported output proof required')
        require(case.get('kind') in {'mutation', 'refusal', 'read-only', 'output'}, f'{case_id}: invalid kind')
        require(nonempty(result.get('observation')), f'{case_id}: observation or blocking reason required')
        if state in {'passed', 'failed'} and isinstance(kinds, list):
            artifacts(case_id, result.get('evidence'), kinds)
        if state == 'passed':
            require(result.get('driver') == 'browser', f'{case_id}: pass must be exercised through browser')
        if result.get('transportFault'):
            artifacts(case_id, result.get('evidence'), ['fault'])
        desktop = result.get('desktopStatus')
        require(desktop in DESKTOP, f'{case_id}: explicit desktop status required')
        if desktop == 'matched':
            require(result.get('desktopExecution') == 'original-windows', f'{case_id}: source-derived is not a desktop execution')
            artifacts(case_id, result.get('evidence'), ['desktop'])
            desktop_matches += 1
    require(applicable > 0, 'matrix must contain applicable cases')
    pct = lambda n: round(100 * n / applicable, 2) if applicable else 0
    summary = {
        'requiredCases': len(required), 'applicableCases': applicable, 'counts': counts,
        'executedCoveragePct': pct(counts['passed'] + counts['failed']),
        'browserBusinessPassPct': pct(counts['passed']),
        'desktopMatchPct': pct(desktop_matches),
        'bundleValid': not errors,
        'allRequiredBrowserCasesPassed': not errors and applicable > 0 and counts['passed'] == applicable,
        'limits': 'Artifact structure and hashes only; no browser execution, semantic evidence review, or product certification.',
        'errors': errors,
    }
    return summary


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('matrix', type=Path)
    parser.add_argument('run', type=Path)
    parser.add_argument('--evidence-root', required=True, type=Path)
    args = parser.parse_args()
    try:
        summary = validate(json.loads(args.matrix.read_text()), json.loads(args.run.read_text()),
                           digest(args.matrix), args.evidence_root)
        print(json.dumps(summary, indent=2))
        return 0 if summary['allRequiredBrowserCasesPassed'] else 1
    except (OSError, ValueError, TypeError, AttributeError) as error:
        print(json.dumps({'bundleValid': False, 'error': str(error)}))
        return 2


if __name__ == '__main__':
    raise SystemExit(main())
