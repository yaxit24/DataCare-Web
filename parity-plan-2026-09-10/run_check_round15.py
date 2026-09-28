"""Record one continuation check and all declared workspace input changes without overwriting history."""
from pathlib import Path
from round14_runtime_inputs import runtime_inputs
import datetime
import hashlib
import importlib.util
import json
import re
import subprocess
import sys

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
OUT = PLAN / 'evidence/implementation-2026-09-12-round15'
name, *command = sys.argv[1:]
assert re.fullmatch(r'[a-z0-9-]+', name) and command
spec = importlib.util.spec_from_file_location('input_universe', PLAN / 'capture_implementation_checkpoint_round12_isolated.py')
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)
prior = json.loads((PLAN / '41-implementation-checkpoint-round14.json').read_text())
seeds = {row['path'] for row in prior['sourceFiles']}
seeds.update(prior.get('observedAbsentInputs', []))
seeds.add('project-memory/parity/reports/report-comparison-latest.json')
seeds.add('web/apps/api/dist/modules/ops/kernelConformance.js')
seeds.add('parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-labour-preview-browser/browser-required-checks.json')
seeds.update(str(path.relative_to(ROOT)) for path in (ROOT / 'web/docs').rglob('*') if path.is_file() and path.suffix in {'.md', '.json'})
# Measurement executables are inputs too; keep earlier run manifests unchanged.
seeds.update(str(path.relative_to(ROOT)) for path in (ROOT / 'project-memory/parity').glob('*.py'))
seeds.update(str((PLAN / name).relative_to(ROOT)) for name in [
    'capture_implementation_checkpoint_round14.py', 'run_check_round14.py',
    'validate_current_review.py', 'build_execution_addendum.py',
    'execution-addendum-intro.md', 'round14_runtime_inputs.py',
        'checkpoint_recipe_round14.py', 'test_checkpoint_recipe_round14.py',
    'run_check_round15.py', 'capture_implementation_checkpoint_round15.py',
    'checkpoint_recipe_round15.py', 'test_checkpoint_recipe_round15.py',
])
sha = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()

def capture():
    return {name: sha(ROOT / name) if (ROOT / name).is_file() else None
            for name in sorted(module.universe(ROOT, seeds))}

log, metadata, inputs = [OUT / (name + suffix) for suffix in ['.txt', '.run.json', '.inputs.json']]
assert not any(path.exists() for path in [log, metadata, inputs])
def private_capture():
    # Credentials are hash-only provenance, never archived as source bytes.
    return {name: sha(ROOT / name) if (ROOT / name).is_file() else None
            for name in ['web/.env.parity-test', 'web/.env', 'web/packages/db/.env', 'web/packages/db/prisma/.env', 'web/apps/api/.env']}

before = capture()
private_before = private_capture()
runtime_before = runtime_inputs(ROOT)
inputs.write_text(json.dumps({'capturedAtUtc': now(), 'sourceRoot': str(ROOT), 'files': before, 'privateInputFiles': private_before, 'runtimeInputFiles': runtime_before}, indent=2) + '\n')
started = now()
with log.open('w') as stream:
    result = subprocess.run(command, cwd=ROOT / 'web', stdout=stream, stderr=subprocess.STDOUT)
after = capture()
private_after = private_capture()
runtime_after = runtime_inputs(ROOT)
changed_runtime = [{'path': path, 'beforeSha256': runtime_before.get(path), 'afterSha256': runtime_after.get(path)}
                   for path in sorted(set(runtime_before) | set(runtime_after))
                   if runtime_before.get(path) != runtime_after.get(path)]
changed_private = [{'path': path, 'beforeSha256': private_before.get(path), 'afterSha256': private_after.get(path)}
                   for path in sorted(set(private_before) | set(private_after))
                   if private_before.get(path) != private_after.get(path)]
changed = [{'path': path, 'beforeSha256': before.get(path), 'afterSha256': after.get(path)}
           for path in sorted(set(before) | set(after)) if before.get(path) != after.get(path)]
record = {
    'command': command, 'cwd': 'web', 'startedAtUtc': started, 'finishedAtUtc': now(),
    'exitCode': result.returncode, 'status': 'passed' if result.returncode == 0 else 'failed',
    'log': str(log.relative_to(ROOT)), 'logSha256': sha(log),
    'inputManifest': str(inputs.relative_to(ROOT)), 'inputManifestSha256': sha(inputs),
    'inputCount': len(before), 'changedInputs': changed, 'changedPrivateInputs': changed_private, 'changedRuntimeInputs': changed_runtime,
    'qualification': 'unchanged-declared-inputs' if not changed and not changed_private and not changed_runtime else 'concurrent-input-drift-requires-explicit-scope-review',
    'limits': 'Only the recorded command and its assertions; no original desktop, production, complete session lifecycle or whole-menu acceptance is inferred.',
}
metadata.write_text(json.dumps(record, indent=2) + '\n')
print(json.dumps(record))
sys.exit(result.returncode)
