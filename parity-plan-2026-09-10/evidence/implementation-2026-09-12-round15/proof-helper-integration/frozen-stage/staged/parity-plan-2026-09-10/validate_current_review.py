"""Validate the current planning revision without changing app or database state."""
from pathlib import Path
import datetime
import hashlib
import json
import re
import sys

sys.dont_write_bytecode = True
from urllib.parse import unquote
from checkpoint_recipe_round15 import validate_latest_checkpoint

OUT = Path(__file__).resolve().parent
ROOT = OUT.parent
EVIDENCE = OUT / 'evidence/review-2026-09-11'
CURRENT_IMPLEMENTATION_EVIDENCE = OUT / 'evidence/implementation-2026-09-12-round15'
PRIOR_CHECKPOINT = '41-implementation-checkpoint-round14.json'
PRIOR_CHECKPOINT_SHA256 = '643bf89ad0ac50729c7feff06c28dfa6bf8cca7d6318e498397cd5c57bf9ebea'
LATEST_CHECKPOINT = '43-implementation-checkpoint-round15.json'
HISTORICAL_CHAIN = [
    (PRIOR_CHECKPOINT, PRIOR_CHECKPOINT_SHA256, 'priorCheckpointSha256'),
    ('39-implementation-checkpoint-round13.json', 'db25b3e107d6e67629f2d445cb2ee191ff9794220cb19dac8cfc7ac9edfababf', 'priorCheckpointSha256'),
    ('37-implementation-checkpoint-round12.json', '6ed9623310507f1a563bc98c4f9f130401e058543797d15745b7812b71a64098', 'priorCheckpointSha256'),
    ('35-implementation-checkpoint-round11.json', 'fd3ab768e85c7a0936ae06c72580e7d170b6adf32b74a105df880e43f806a489', 'priorCheckpointSha256'),
    ('33-implementation-checkpoint-round10.json', '7a61c80e3aa999b809ea792489b51fee9eee01555ff5898bdae328772e4749f7', 'priorCheckpointSha256'),
    ('31-implementation-checkpoint-round9.json', 'c46d7612fff5ac119323b4646b5860b3c406cd395aed4223ab03eea8068bdcc7', 'priorCheckpointSha256'),
    ('29-implementation-checkpoint-round8.json', '12c69feee320f35e691667d31b37f7ef5e438d56a255e242eaa365e427fc3249', 'priorCheckpointSha256'),
    ('27-implementation-checkpoint-round7.json', 'ee7f053e8b87e5fb360d957999a15f4abd9d431dc36548fa0956a6e5386cdea1', 'priorCheckpointSha256'),
    ('25-implementation-checkpoint-round6.json', '40885f09ce737106bbf1678b388ef5e56b30a22757759d35d062362a10af1e24', 'priorCheckpointSha256'),
    ('23-implementation-checkpoint-round5.json', '2f702b34c8e04aa7ad2704e7dc1c3d70846c5e0d35761b206b35a03e112a0498', 'priorCheckpointSha256'),
    ('21-implementation-checkpoint-round4.json', 'd17e66599d6bd5c20dd935a98c17cdae46afa260a1cebadb5569b3f7b33e01ac', 'priorCheckpointSha256'),
    ('19-implementation-checkpoint-round3.json', 'd351f2fa39c0b2c865044f45eca4738e8a178081be0c65623528e76c0554e0dd', 'priorCheckpointSha256'),
    ('17-implementation-checkpoint-round2.json', '9425e8888f06fce331cf15739809d007a75b32acef89c8aa0229802f286cee27', 'prior15sha256'),
    ('15-implementation-checkpoint.json', '56ab9bed15dd9515bcbcc8eb2a5639eb35d31ab392f61c204346240cf5cda811', None),
]


def file_digest(relative):
    """Only resolve evidence identities inside the extracted workspace."""
    if not isinstance(relative, str) or not relative or Path(relative).is_absolute():
        return None
    path = (ROOT / relative).resolve()
    if not path.is_relative_to(ROOT.resolve()) or not path.is_file():
        return None
    return hashlib.sha256(path.read_bytes()).hexdigest()


def historical_checkpoint_drift(checkpoint):
    """Informational only: a frozen checkpoint describes the files at its capture time."""
    drift = {'sourceFiles': [], 'verificationArtifacts': [], 'artifactFiles': []}
    for field in ('sourceFiles', 'artifactFiles'):
        for row in checkpoint.get(field, []):
            current = file_digest(row.get('path'))
            if current != row.get('sha256'):
                drift[field].append({'path': row.get('path'),
                                     'checkpointSha256': row.get('sha256'),
                                     'currentSha256': current})
    for row in checkpoint.get('verification', []):
        current = file_digest(row.get('log'))
        if current != row.get('logSha256'):
            drift['verificationArtifacts'].append({'path': row.get('log'),
                                                   'checkpointSha256': row.get('logSha256'),
                                                   'currentSha256': current})
    return drift


def validate_implementation_checkpoint(checkpoint, baseline, *, check_current_files=True):
    """Verify new implementation evidence separately from the immutable planning review."""
    errors = []
    if not isinstance(checkpoint, dict):
        return ['Implementation checkpoint must be an object']
    if checkpoint.get('kind') != 'datacare.parity-implementation-checkpoint/1.0':
        errors.append('Unknown implementation checkpoint kind')
    baseline_path = EVIDENCE / 'reviewed-source-hashes.json'
    if checkpoint.get('baseReviewSourceManifestSha256') != hashlib.sha256(baseline_path.read_bytes()).hexdigest():
        errors.append('Implementation checkpoint does not reference the frozen source review')
    if (checkpoint.get('status') != 'partial-implementation'
            or checkpoint.get('acceptedExecutionCards') != []
            or checkpoint.get('acceptedOriginalPackages') != []):
        errors.append('This partial checkpoint cannot claim full card acceptance')
    if checkpoint.get('verifiedMenus') != 0 or checkpoint.get('wholeProductImplementationPercentage') is not None:
        errors.append('This checkpoint cannot invent menu acceptance or an implementation percentage')
    rows = checkpoint.get('sourceFiles', [])
    if not isinstance(rows, list) or any(not isinstance(row, dict) for row in rows):
        return errors + ['Implementation sourceFiles must be a list of file identities']
    current_paths = {row.get('path') for row in rows}
    if len(rows) != len(current_paths):
        errors.append('Duplicate implementation source paths')
    if not {row['path'] for row in baseline['files']} <= current_paths:
        errors.append('Implementation checkpoint omitted reviewed source identities')
    for row in rows:
        if not isinstance(row.get('path'), str) or not re.fullmatch(r'[0-9a-f]{64}', str(row.get('sha256', ''))):
            errors.append('Invalid implementation source identity')
        elif check_current_files and file_digest(row['path']) != row['sha256']:
            errors.append(f"Implementation source changed after checkpoint: {row['path']}")
    if not checkpoint.get('verification'):
        errors.append('Implementation checkpoint requires verification outcomes')
    for run in checkpoint.get('verification', []):
        if not run.get('command') or run.get('status') not in ('passed', 'failed', 'blocked'):
            errors.append('Invalid implementation verification result')
        if not isinstance(run.get('log'), str) or not re.fullmatch(r'[0-9a-f]{64}', str(run.get('logSha256', ''))):
            errors.append('Invalid verification artifact identity')
        elif check_current_files and file_digest(run['log']) != run['logSha256']:
            errors.append(f"Missing or changed verification artifact: {run.get('log')}")
    for row in checkpoint.get('artifactFiles', []):
        if not isinstance(row.get('path'), str) or not re.fullmatch(r'[0-9a-f]{64}', str(row.get('sha256', ''))):
            errors.append('Invalid implementation artifact identity')
        elif check_current_files and file_digest(row['path']) != row['sha256']:
            errors.append(f"Missing or changed implementation artifact: {row['path']}")
    return errors


def validate_checkpoint_chain(latest, baseline, prior_bytes, *, validate_required_recipe=True):
    """Validate current evidence plus the immutable byte identity of its predecessor."""
    errors = validate_implementation_checkpoint(latest, baseline)
    if not isinstance(latest, dict):
        return errors
    if latest.get('priorCheckpoint') != PRIOR_CHECKPOINT:
        errors.append('Latest checkpoint must name the immutable prior checkpoint')
    if prior_bytes is None:
        return errors + ['Missing prior implementation checkpoint']
    if (latest.get('priorCheckpointSha256') != hashlib.sha256(prior_bytes).hexdigest()
            or hashlib.sha256(prior_bytes).hexdigest() != PRIOR_CHECKPOINT_SHA256):
        errors.append('Prior implementation checkpoint bytes changed')
    try:
        prior = json.loads(prior_bytes)
    except (ValueError, UnicodeDecodeError):
        return errors + ['Prior implementation checkpoint is invalid JSON']
    # The strict recipe belongs only to actual Round15, not historical predecessors.
    if validate_required_recipe:
        errors.extend(validate_latest_checkpoint(ROOT, latest))
    # Validate every immutable predecessor's bytes, metadata, link and source inclusion.
    # Historical source hashes describe their own capture time and may differ from today's tree.
    child = latest
    for index, (name, digest, link_field) in enumerate(HISTORICAL_CHAIN):
        data = prior_bytes if index == 0 else ((OUT / name).read_bytes() if (OUT / name).is_file() else None)
        if data is None or hashlib.sha256(data).hexdigest() != digest:
            errors.append(f'Historical checkpoint bytes changed or missing: {name}')
            break
        try:
            historical = json.loads(data)
        except (ValueError, UnicodeDecodeError):
            errors.append(f'Historical checkpoint is invalid JSON: {name}')
            break
        historical_errors = validate_implementation_checkpoint(historical, baseline, check_current_files=False)
        errors.extend(f'Historical checkpoint {name}: ' + error for error in historical_errors)
        if historical_errors:
            break
        historical_paths = {row.get('path') for row in historical.get('sourceFiles', [])}
        child_paths = {row.get('path') for row in child.get('sourceFiles', [])}
        if not historical_paths <= child_paths:
            errors.append(f'Checkpoint omitted prior implementation source identities: {name}')
        if index + 1 < len(HISTORICAL_CHAIN):
            next_name, next_digest, _ = HISTORICAL_CHAIN[index + 1]
            if historical.get('priorCheckpoint') != next_name or historical.get(link_field) != next_digest:
                errors.append(f'Historical checkpoint predecessor link changed: {name}')
        child = historical

    return errors


def checkpoint_negative_controls(checkpoint, baseline, prior_bytes=None, *, validate_required_recipe=True):
    """In-memory mutations exercise rejection without changing any historical evidence."""
    clone = lambda: json.loads(json.dumps(checkpoint))
    validate = ((lambda value: validate_checkpoint_chain(value, baseline, prior_bytes, validate_required_recipe=validate_required_recipe))
                if prior_bytes is not None else
                (lambda value: validate_implementation_checkpoint(value, baseline)))
    controls = []
    omitted, stale = clone(), clone()
    omitted['sourceFiles'] = []
    stale['sourceFiles'][0]['sha256'] = '0' * 64
    for label, bad in [('omitted-implementation-source', omitted), ('stale-implementation-source', stale)]:
        controls.append({'name': label, 'rejected': bool(validate(bad))})
    if prior_bytes is not None:
        omitted_prior = clone()
        baseline_paths = {row['path'] for row in baseline['files']}
        prior_paths = {row['path'] for row in json.loads(prior_bytes)['sourceFiles']}
        candidates = sorted(prior_paths - baseline_paths)
        # A preceding implementation checkpoint must contribute an identity beyond the review.
        if not candidates:
            controls.append({'name': 'omitted-prior-source', 'rejected': False})
        else:
            omitted_prior['sourceFiles'] = [row for row in omitted_prior['sourceFiles'] if row['path'] != candidates[0]]
            controls.append({'name': 'omitted-prior-source', 'rejected': bool(validate(omitted_prior))})
        controls.extend([
            {'name': 'missing-prior-checkpoint', 'rejected': bool(validate_checkpoint_chain(checkpoint, baseline, None, validate_required_recipe=validate_required_recipe))},
            {'name': 'tampered-prior-checkpoint', 'rejected': bool(validate_checkpoint_chain(checkpoint, baseline, prior_bytes + b'\n', validate_required_recipe=validate_required_recipe))},
        ])
        stale_log = clone()
        stale_log['verification'][0]['logSha256'] = '0' * 64
        controls.append({'name': 'stale-verification-artifact', 'rejected': bool(validate(stale_log))})
        stale_artifact = clone()
        if stale_artifact.get('artifactFiles'):
            stale_artifact['artifactFiles'][0]['sha256'] = '0' * 64
            controls.append({'name': 'stale-implementation-artifact', 'rejected': bool(validate(stale_artifact))})
    return controls


def self_test_checkpoint_chain():
    """Prove the chain controls before the root agent freezes the next checkpoint."""
    baseline = json.loads((EVIDENCE / 'reviewed-source-hashes.json').read_text())
    prior_bytes = (OUT / PRIOR_CHECKPOINT).read_bytes()
    synthetic = json.loads(prior_bytes)
    synthetic.update(priorCheckpoint=PRIOR_CHECKPOINT,
                     priorCheckpointSha256=hashlib.sha256(prior_bytes).hexdigest())
    for field in ('sourceFiles', 'artifactFiles'):
        for row in synthetic[field]:
            row['sha256'] = file_digest(row['path'])
    for run in synthetic['verification']:
        run['logSha256'] = file_digest(run['log'])
    # This synthetic43 tests only the historical chain; recipe-controls-recorded tests R15.
    errors = validate_checkpoint_chain(synthetic, baseline, prior_bytes, validate_required_recipe=False)
    controls = checkpoint_negative_controls(synthetic, baseline, prior_bytes, validate_required_recipe=False)
    errors.extend('Negative control failed: ' + row['name'] for row in controls if not row['rejected'])
    result = {'validatedAt': datetime.datetime.now(datetime.timezone.utc).isoformat(),
              'status': 'passed' if not errors else 'failed',
              'positiveControl': 'In-memory current checkpoint chained to unchanged prior bytes',
              'priorCheckpoint': PRIOR_CHECKPOINT, 'priorCheckpointSha256': hashlib.sha256(prior_bytes).hexdigest(),
              'negativeControls': controls, 'errors': errors,
              'limits': 'Validator self-test only. No checkpoint created or changed; no application acceptance.'}
    CURRENT_IMPLEMENTATION_EVIDENCE.mkdir(parents=True, exist_ok=True)
    (CURRENT_IMPLEMENTATION_EVIDENCE / 'checkpoint-chain-validation.json').write_text(json.dumps(result, indent=2) + '\n')
    print(json.dumps(result, indent=2))
    return 1 if errors else 0


def validate_backlog(work, backlog):
    errors = []
    packages = work.get('workItems', [])
    package_ids = {p['id'] for p in packages}
    tasks = backlog.get('tasks', [])
    task_ids = {t['id'] for t in tasks}
    if len(packages) != 83 or len(package_ids) != 83:
        errors.append('Expected all 83 original distinct package IDs')
    if len(tasks) != 34 or len(task_ids) != 34:
        errors.append('Expected 34 distinct current execution cards')
    coverage = {p for t in tasks for p in t.get('parents', [])}
    if coverage != package_ids:
        errors.append('Execution cards must cover exactly the original package set')
    for t in tasks:
        if not set(t.get('startAfter', [])) <= task_ids:
            errors.append(f"{t['id']}: unknown dependency")
        if t.get('status') != 'open':
            errors.append(f"{t['id']}: this review contains no new complete runtime acceptance")
        for field in ['currentFinding', 'existingFiles', 'implementationSteps',
                      'verificationCases', 'acceptance', 'requiredEvidence', 'closureRule']:
            if not t.get(field):
                errors.append(f"{t['id']}: missing {field}")
        for p in t.get('existingFiles', []):
            if not (ROOT / p).exists():
                errors.append(f"{t['id']}: named existing path does not exist: {p}")
    dependencies = {t['id']: t.get('startAfter', []) for t in tasks}
    finished = set()

    def visit(key, stack):
        if key in stack:
            errors.append('Execution dependency cycle: ' + ' -> '.join(stack + [key]))
            return
        if key in finished:
            return
        for child in dependencies.get(key, []):
            visit(child, stack + [key])
        finished.add(key)

    for key in task_ids:
        visit(key, [])
    for p in packages:
        expected = {t['id'] for t in tasks if p['id'] in t.get('parents', [])}
        if set(p.get('currentReview', {}).get('executionTasks', [])) != expected:
            errors.append(f"{p['id']}: current review task links do not match card parents")
        if p.get('status') != 'open' or not p.get('acceptance'):
            errors.append(f"{p['id']}: incorrect current status or missing original acceptance")
    if backlog.get('wholeProductImplementationPercentage') is not None:
        errors.append('No measured whole-product implementation percentage is available')
    return errors


def main():
    if '--self-test-checkpoint-chain' in sys.argv:
        return self_test_checkpoint_chain()
    errors = []
    work = json.loads((OUT / '07-work-items.json').read_text())
    backlog = json.loads((OUT / '13-execution-backlog.json').read_text())
    errors.extend(validate_backlog(work, backlog))
    for p in OUT.rglob('*.json'):
        try:
            json.loads(p.read_text())
        except Exception as exc:
            errors.append(f'{p.name}: invalid JSON: {exc}')

    # Test the meaningful planning coverage checks without modifying files or evidence.
    omitted = json.loads(json.dumps(backlog))
    omitted['tasks'] = [t for t in omitted['tasks'] if t['id'] != 'X11']
    duplicate = json.loads(json.dumps(backlog))
    duplicate['tasks'][-1] = duplicate['tasks'][0]
    cycle = json.loads(json.dumps(backlog))
    cycle['tasks'][0]['startAfter'] = ['X02']
    for label, bad in [('missing-card', omitted), ('duplicate-card', duplicate), ('dependency-cycle', cycle)]:
        if not validate_backlog(work, bad):
            errors.append(f'Negative control failed: {label}')

    # Check generated cards match the structured task definitions.
    import build_execution_addendum
    if build_execution_addendum.TASKS != backlog['tasks']:
        errors.append('Structured cards differ from build_execution_addendum.py definitions')
    plan = (OUT / '02-implementation-plan.md').read_text()
    sections = {m[1]: m[2].strip() for m in re.finditer(
        r'^### (P\d{2}-\d{2}) — [^\n]+\n(.*?)(?=^## |^### P\d|\Z)', plan, re.M | re.S)}
    for item in work['workItems']:
        if sections.get(item['id']) != item['implementationAndChecks']:
            errors.append(f"{item['id']}: markdown/structured implementation text differs")
    readable = (OUT / '12-execution-addendum.md').read_text()
    if set(re.findall(r'^### (X\d{2}) —', readable, re.M)) != {t['id'] for t in backlog['tasks']}:
        errors.append('Readable and structured execution card IDs differ')

    links = 0
    for p in OUT.glob('*.md'):
        content = p.read_text()
        for match in re.finditer(r'\]\((?:<([^>]+)>|([^\s)]+))\)', content):
            target = match[1] or match[2]
            if target.startswith(('http://', 'https://', '#')):
                continue
            links += 1
            path_part, _, anchor = target.partition('#')
            destination = p.parent / unquote(path_part)
            if not destination.exists():
                errors.append(f'{p.name}: missing local link: {target}')
            if anchor and destination.name == '12-execution-addendum.md':
                headings = re.findall(r'^#{1,6} (.+)$', destination.read_text(), re.M)
                slugs = {re.sub(r'[^\w-]', '', h.lower().replace(' ', '-')) for h in headings}
                if anchor not in slugs:
                    errors.append(f'{p.name}: missing execution-card anchor: {anchor}')
        expected_columns = None
        for lineno, line in enumerate(content.splitlines(), 1):
            if not line.startswith('|'):
                expected_columns = None
                continue
            columns = len(re.split(r'(?<!\\)\|', line)) - 2
            if expected_columns is None:
                expected_columns = columns
            elif columns != expected_columns:
                errors.append(f'{p.name}:{lineno}: malformed Markdown table')

    # Frozen source registers retain their historical identities; no inventory shrinkage.
    counts = {'form-register': 204, 'grid-requirements': 3508, 'control-requirements': 1599,
              'event-requirements': 5838, 'report-register': 275, 'table-register': 146,
              'additional-control-candidates': 916, 'supporting-source-register': 8}
    for name, expected in counts.items():
        rows = json.loads((OUT / 'evidence' / (name + '.json')).read_text())
        if len(rows) != expected or len({x['id'] for x in rows}) != expected:
            errors.append(f'{name}: frozen count/identity mismatch')
    anchors = re.findall(r'^\| ((?:SET|PUR|SAL|FLOW|FIN|STK|MFG|SCH|RPT|OPS)-\d+) \|',
                         (OUT / '03-verification-and-release.md').read_text(), re.M)
    if len(anchors) != 128 or len(set(anchors)) != 128:
        errors.append('Original 128 scenario anchors must remain intact')
    coverage = json.loads((OUT / '10-plan-coverage-obligations.json').read_text())
    if coverage['scenarioAnchors'] != anchors:
        errors.append('Planning scenario obligation register differs')

    summary = json.loads((EVIDENCE / 'summary.json').read_text())
    register = json.loads((ROOT / 'web/docs/COMPLETION-REGISTER.json').read_text())
    states = {}
    for item in register['items']:
        states[item['state']] = states.get(item['state'], 0) + 1
    if summary['menu'] != {'total': len(register['items']), 'states': states}:
        errors.append('Current register and review counts differ; recapture before changing progress claims')
    if summary['endToEndImplementationPercentage'] is not None:
        errors.append('Review incorrectly invents a whole-product percentage')

    current = json.loads((EVIDENCE / 'reviewed-source-hashes.json').read_text())
    checkpoint_path = OUT / LATEST_CHECKPOINT if (OUT / LATEST_CHECKPOINT).exists() else OUT / PRIOR_CHECKPOINT
    checkpoint = json.loads(checkpoint_path.read_text()) if checkpoint_path.exists() else None
    prior_bytes = None
    prior_drift = None
    implementation_controls = []
    if checkpoint:
        if checkpoint_path.name == LATEST_CHECKPOINT:
            prior_path = OUT / PRIOR_CHECKPOINT
            prior_bytes = prior_path.read_bytes() if prior_path.is_file() else None
            errors.extend(validate_checkpoint_chain(checkpoint, current, prior_bytes))
            if prior_bytes is not None:
                try:
                    prior_drift = historical_checkpoint_drift(json.loads(prior_bytes))
                except (ValueError, UnicodeDecodeError, AttributeError, TypeError):
                    errors.append('Unable to record prior checkpoint drift from malformed metadata')
        else:
            errors.extend(validate_implementation_checkpoint(checkpoint, current))
        # Mutation controls are meaningful only after a positive checkpoint validation.
        if not (validate_checkpoint_chain(checkpoint, current, prior_bytes)
                if checkpoint_path.name == LATEST_CHECKPOINT else
                validate_implementation_checkpoint(checkpoint, current)):
            implementation_controls = checkpoint_negative_controls(checkpoint, current, prior_bytes)
            errors.extend('Negative control failed: ' + row['name'] for row in implementation_controls if not row['rejected'])
    changed_current = []
    for item in current['files']:
        path = ROOT / item['path']
        if not path.exists() or hashlib.sha256(path.read_bytes()).hexdigest() != item['sha256']:
            changed_current.append(item['path'])
    if changed_current and not checkpoint:
        errors.append(f'Implementation changed after current review: {changed_current}')
    historical = json.loads((OUT / 'evidence/source-manifest.json').read_text())
    changed_historical = []
    for item in historical['files']:
        path = ROOT / item['path']
        if not path.exists() or hashlib.sha256(path.read_bytes()).hexdigest() != item['sha256']:
            changed_historical.append(item['path'])
            if item['path'].startswith('unified/'):
                errors.append(f'Desktop reference source changed: {item["path"]}')

    result = {'validatedAt': datetime.datetime.now(datetime.timezone.utc).isoformat(),
              'status': 'passed' if not errors else 'failed', 'workPackages': 83,
              'executionCards': 34, 'scenarioAnchors': len(anchors), 'localLinksChecked': links,
              'reviewedImplementationFilesUnchanged': len(current['files']) - len(changed_current),
              'implementationChangesSinceReview': changed_current,
              'implementationCheckpoint': checkpoint_path.name if checkpoint else None,
              'priorCheckpoint': PRIOR_CHECKPOINT if checkpoint_path.name == LATEST_CHECKPOINT else None,
              'priorCheckpointSha256': hashlib.sha256(prior_bytes).hexdigest() if prior_bytes is not None else None,
              'priorCheckpointCurrentFileDrift': prior_drift,
              'historicalSourceDrift': changed_historical,
              'negativeControls': ['missing-card', 'duplicate-card', 'dependency-cycle'] +
              [row['name'] for row in implementation_controls],
              'errors': errors,
              'limits': 'Documentation, planning coverage, links, counts and source-identity checks only. The latest checkpoint validates current files and the exact bytes of its predecessor. Historical source and artifact changes are informational drift, never rewritten. Not application, desktop, DB, browser or release certification.'}
    output = CURRENT_IMPLEMENTATION_EVIDENCE if checkpoint else EVIDENCE
    output.mkdir(parents=True, exist_ok=True)
    (output / 'document-validation.json').write_text(json.dumps(result, indent=2) + '\n')
    print(json.dumps({**result, 'historicalSourceDrift': len(changed_historical),
                      'priorCheckpointCurrentFileDrift': {key: len(rows) for key, rows in prior_drift.items()} if prior_drift else None}, indent=2))
    return 1 if errors else 0


if __name__ == '__main__':
    sys.exit(main())
