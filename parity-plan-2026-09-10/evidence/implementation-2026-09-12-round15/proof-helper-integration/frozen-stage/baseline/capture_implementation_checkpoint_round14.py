"""Capture a partial implementation checkpoint; default is validation only.

This records current source bytes and exact run identities. It never upgrades a
historical run to current-source coverage or certifies complete desktop parity.
"""
from pathlib import Path
from round14_runtime_inputs import runtime_inputs
from checkpoint_recipe_round14 import validate_required_runs
import argparse
import datetime
import hashlib
import importlib.util
import io
import json
import re
import subprocess
import tarfile


PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
OUT = PLAN / 'evidence/implementation-2026-09-12-round14'
PRIOR = PLAN / '39-implementation-checkpoint-round13.json'
PRIOR_SHA = 'db25b3e107d6e67629f2d445cb2ee191ff9794220cb19dac8cfc7ac9edfababf'


def digest(data):
    return hashlib.sha256(data).hexdigest()


def identity(path):
    return {'path': str(path.relative_to(ROOT)), 'sha256': digest(path.read_bytes())}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--write', action='store_true')
    args = parser.parse_args()
    assert digest(PRIOR.read_bytes()) == PRIOR_SHA, 'Historical checkpoint changed'
    prior = json.loads(PRIOR.read_text())
    spec = importlib.util.spec_from_file_location(
        'universe', PLAN / 'capture_implementation_checkpoint_round12_isolated.py')
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    seeds = {row['path'] for row in prior['sourceFiles']}
    seeds.update(prior.get('observedAbsentInputs', []))
    seeds.add('project-memory/parity/reports/report-comparison-latest.json')
    seeds.add('web/apps/api/dist/modules/ops/kernelConformance.js')
    seeds.add('parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-labour-preview-browser/browser-required-checks.json')
    seeds.update(str(path.relative_to(ROOT)) for path in (ROOT / 'web/docs').rglob('*') if path.is_file() and path.suffix in {'.md', '.json'})
    seeds.update(str(path.relative_to(ROOT)) for path in (ROOT / 'project-memory/parity').glob('*.py'))
    seeds.update(str((PLAN / name).relative_to(ROOT)) for name in [
        'capture_implementation_checkpoint_round14.py', 'run_check_round14.py',
        'validate_current_review.py', 'build_execution_addendum.py',
        'execution-addendum-intro.md', 'round14_runtime_inputs.py',
        'checkpoint_recipe_round14.py', 'test_checkpoint_recipe_round14.py',
    ])
    names = sorted(module.universe(ROOT, seeds))
    sources = []
    absent = []
    for name in names:
        path = ROOT / name
        assert path.resolve().is_relative_to(ROOT.resolve()), name
        if not path.exists():
            absent.append(name)
            continue
        assert path.is_file() and not path.is_symlink(), name
        sources.append(identity(path))
    assert {row['path'] for row in prior['sourceFiles']} <= {row['path'] for row in sources}
    current = {row['path']: row['sha256'] for row in sources}
    private_current = {name: digest((ROOT / name).read_bytes()) if (ROOT / name).is_file() else None
                       for name in ['web/.env.parity-test', 'web/.env', 'web/packages/db/.env', 'web/packages/db/prisma/.env', 'web/apps/api/.env']}
    assert not set(private_current) & set(names), 'Private bytes cannot enter source archive'
    runtime_current = runtime_inputs(ROOT)
    verification = []
    for path in sorted(OUT.glob('*.run.json')):
        run = json.loads(path.read_text())
        assert digest((ROOT / run['log']).read_bytes()) == run['logSha256'], path
        manifest = ROOT / run['inputManifest']
        assert digest(manifest.read_bytes()) == run['inputManifestSha256'], path
        original = json.loads(manifest.read_text())['files']
        run['label'] = path.stem.removesuffix('.run')
        run['record'] = identity(path)
        run['currentCaptureDifferences'] = [
            {'path': name, 'runInputSha256': original.get(name), 'currentSha256': current.get(name)}
            for name in sorted(set(original) | set(current))
            if original.get(name) != current.get(name)
        ]
        private_original = json.loads(manifest.read_text()).get('privateInputFiles', {})
        run['currentPrivateCaptureDifferences'] = [
            {'path': name, 'runInputSha256': private_original.get(name), 'currentSha256': private_current.get(name)}
            for name in sorted(set(private_original) | set(private_current))
            if private_original.get(name) != private_current.get(name)
        ]
        runtime_original = json.loads(manifest.read_text()).get('runtimeInputFiles', {})
        run['currentRuntimeCaptureDifferences'] = [
            {'path': name, 'runInputSha256': runtime_original.get(name), 'currentSha256': runtime_current.get(name)}
            for name in sorted(set(runtime_original) | set(runtime_current))
            if runtime_original.get(name) != runtime_current.get(name)
        ]
        verification.append(run)
    assert verification, 'No recorded verification'
    recipe_path = OUT / 'checkpoint-required-checks.json'
    recipe = json.loads(recipe_path.read_text())
    recipe_errors = validate_required_runs(
        ROOT, recipe, verification, current | dict.fromkeys(absent), private_current, runtime_current)
    if recipe_errors:
        raise ValueError('\n'.join(recipe_errors))
    by_label = {row['label']: row for row in verification}
    for requirement in recipe['checks']:
        run = by_label[requirement['label']]
        assert run['status'] == requirement['status'], requirement
        assert run['exitCode'] == requirement['requiredExitCode'], requirement
        assert run['cwd'] == requirement['requiredCwd'], requirement
        assert (run['exitCode'] == 0) == (run['status'] == 'passed'), requirement
        assert run['command'] == requirement['command'], requirement
        assert not run['changedInputs'], requirement
        if 'scripts/parity-test-env.mjs' in run['command']:
            assert run.get('changedPrivateInputs') == [], requirement
            assert not run['currentPrivateCaptureDifferences'], requirement
        if requirement.get('requireCurrentWebTestMembership'):
            original = json.loads((ROOT / run['inputManifest']).read_text())['files']
            def runnable_web_test(name):
                return (name.startswith('web/apps/web/test/')
                        and re.search(r'\.(?:test|spec)\.[cm]?[jt]sx?$', name) is not None)
            assert {name for name in original if runnable_web_test(name)} == {
                name for name in current if runnable_web_test(name)}, requirement
        for difference in run['currentCaptureDifferences']:
            assert not any(difference['path'].startswith(prefix)
                           for prefix in requirement.get('requireCurrentPrefixes', [])), (
                               requirement['label'], 'A required input changed after the run', difference)
        text = (ROOT / run['log']).read_text()
        for literal in requirement.get('requiredText', []):
            assert literal in text, (requirement['label'], literal)
    output = PLAN / '41-implementation-checkpoint-round14.json'
    archive = OUT / 'current-source-snapshot.tar.gz'
    archive_record = None
    if args.write:
        assert not output.exists() and not archive.exists(), 'Capture is immutable'
        with archive.open('xb') as stream:
            with tarfile.open(fileobj=stream, mode='w:gz') as tar:
                for row in sources:
                    data = (ROOT / row['path']).read_bytes()
                    assert digest(data) == row['sha256'], row['path']
                    info = tarfile.TarInfo(row['path'])
                    info.size = len(data)
                    info.mode = 0o644
                    info.mtime = 0
                    tar.addfile(info, io.BytesIO(data))
        with tarfile.open(archive, 'r:gz') as tar:
            assert [entry.name for entry in tar] == [row['path'] for row in sources]
            for row in sources:
                assert digest(tar.extractfile(row['path']).read()) == row['sha256']
        archive_record = identity(archive)
    for row in sources:
        assert digest((ROOT / row['path']).read_bytes()) == row['sha256'], row['path']
    artifact_paths = {path for path in OUT.rglob('*') if path.is_file()
                      and path.name not in {'document-validation.json', 'document-validation-complete.txt'}}
    artifact_paths.update(PLAN / name for name in [
        '02-implementation-plan.md', '07-work-items.json', '12-execution-addendum.md',
        '13-execution-backlog.json', '40-implementation-progress-round14.md', 'README.md',
    ])
    artifact_paths.update(ROOT / 'web/docs' / name for name in [
        'HANDOFF.md', 'STATE-OF-PARITY.md', 'TECHNICAL-REFERENCE.md'])
    artifact_paths.add(PRIOR)
    checkpoint = {
        'kind': 'datacare.parity-implementation-checkpoint/1.0',
        'capturedAtUtc': datetime.datetime.now(datetime.timezone.utc).isoformat(),
        'displayTimezone': 'Asia/Kolkata', 'status': 'partial-implementation',
        'gitHead': subprocess.check_output(['git', 'rev-parse', 'HEAD'], cwd=ROOT, text=True).strip(),
        'workingTree': 'Existing changes preserved; isolated synthetic test data; no commit or deployment.',
        'baseReviewSourceManifestSha256': digest((PLAN / 'evidence/review-2026-09-11/reviewed-source-hashes.json').read_bytes()),
        'priorCheckpoint': PRIOR.name, 'priorCheckpointSha256': PRIOR_SHA,
        'progressDocument': '40-implementation-progress-round14.md',
        'wholeProductImplementationPercentage': None, 'verifiedMenus': 0,
        'acceptedExecutionCards': [], 'acceptedOriginalPackages': [],
        'implementedSlices': recipe['implementedSlices'],
        'sourceFiles': sources, 'observedAbsentInputs': absent,
        'privateInputFiles': private_current, 'runtimeInputFiles': runtime_current,
        'runtimeInputQualification': 'Built API and Next runtime membership and hash provenance only; cache/trace and installed dependency bytes excluded. Dependency versions are pinned by lockfile. Runtime files are not archived as source except the explicitly pinned standalone compiled kernelConformance.js gate module.',
        'privateInputQualification': 'Hash-only test credential provenance; private bytes excluded from sources/artifacts/archive.',
        'currentSourceArchive': archive_record,
        'archiveQualification': 'Current source bytes only. Earlier run manifests identify their then-current inputs; this archive does not reconstruct overwritten historical source revisions.',
        'verification': verification,
        'requiredCheckRecipe': identity(recipe_path),
        'artifactFiles': [identity(path) for path in sorted(artifact_paths)],
        'requiredOpenAcceptance': recipe['requiredOpenAcceptance'],
        'limits': 'Partial implementation only. Run counts overlap. Per-run differences remain explicit. No Windows, full business, hardware, complete menu or production certification follows.',
    }
    # Recheck public, private and built-runtime identities immediately before publication.
    for row in sources:
        assert digest((ROOT / row['path']).read_bytes()) == row['sha256'], row['path']
    assert private_current == {name: digest((ROOT / name).read_bytes()) if (ROOT / name).is_file() else None
                               for name in private_current}, 'Private input changed during capture'
    assert runtime_current == runtime_inputs(ROOT), 'Runtime input changed during capture'
    final_names = set(module.universe(ROOT, seeds))
    final_names.update(str(path.relative_to(ROOT)) for path in (ROOT / 'web/docs').rglob('*') if path.is_file() and path.suffix in {'.md', '.json'})
    final_names.update(str(path.relative_to(ROOT)) for path in (ROOT / 'project-memory/parity').glob('*.py'))
    assert set(names) == final_names, 'Public input membership changed during capture'
    for row in checkpoint['artifactFiles']:
        assert digest((ROOT / row['path']).read_bytes()) == row['sha256'], row['path']
    if args.write:
        with output.open('x') as stream:
            stream.write(json.dumps(checkpoint, indent=2) + '\n')
    print(json.dumps({'status': 'captured' if args.write else 'validated-not-written',
                      'sourceFiles': len(sources), 'verificationRuns': len(verification),
                      'artifactFiles': len(artifact_paths),
                      'checkpointSha256': digest(output.read_bytes()) if args.write else None}, indent=2))


if __name__ == '__main__':
    main()
