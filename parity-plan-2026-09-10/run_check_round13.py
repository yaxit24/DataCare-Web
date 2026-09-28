"""Record one continuation check and all declared workspace input changes without overwriting history."""
from pathlib import Path
import datetime
import hashlib
import importlib.util
import json
import re
import subprocess
import sys

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
OUT = PLAN / 'evidence/implementation-2026-09-12-round13'
name, *command = sys.argv[1:]
assert re.fullmatch(r'[a-z0-9-]+', name) and command
spec = importlib.util.spec_from_file_location('input_universe', PLAN / 'capture_implementation_checkpoint_round12_isolated.py')
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)
prior = json.loads((PLAN / '37-implementation-checkpoint-round12.json').read_text())
seeds = {row['path'] for row in prior['sourceFiles']}
# Measurement executables are inputs too; keep earlier run manifests unchanged.
seeds.update(str(path.relative_to(ROOT)) for path in (ROOT / 'project-memory/parity').glob('*.py'))
seeds.update(str((PLAN / name).relative_to(ROOT)) for name in [
    'capture_implementation_checkpoint_round13.py', 'run_check_round13.py',
    'validate_current_review.py', 'build_execution_addendum.py',
    'execution-addendum-intro.md',
])
sha = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()

def capture():
    return {name: sha(ROOT / name) if (ROOT / name).is_file() else None
            for name in sorted(module.universe(ROOT, seeds))}

log, metadata, inputs = [OUT / (name + suffix) for suffix in ['.txt', '.run.json', '.inputs.json']]
assert not any(path.exists() for path in [log, metadata, inputs])
before = capture()
inputs.write_text(json.dumps({'capturedAtUtc': now(), 'sourceRoot': str(ROOT), 'files': before}, indent=2) + '\n')
started = now()
with log.open('w') as stream:
    result = subprocess.run(command, cwd=ROOT / 'web', stdout=stream, stderr=subprocess.STDOUT)
after = capture()
changed = [{'path': path, 'beforeSha256': before.get(path), 'afterSha256': after.get(path)}
           for path in sorted(set(before) | set(after)) if before.get(path) != after.get(path)]
record = {
    'command': command, 'cwd': 'web', 'startedAtUtc': started, 'finishedAtUtc': now(),
    'exitCode': result.returncode, 'status': 'passed' if result.returncode == 0 else 'failed',
    'log': str(log.relative_to(ROOT)), 'logSha256': sha(log),
    'inputManifest': str(inputs.relative_to(ROOT)), 'inputManifestSha256': sha(inputs),
    'inputCount': len(before), 'changedInputs': changed,
    'qualification': 'unchanged-declared-inputs' if not changed else 'concurrent-input-drift-requires-explicit-scope-review',
    'limits': 'Only the recorded command and its assertions; no original desktop, production, complete session lifecycle or whole-menu acceptance is inferred.',
}
metadata.write_text(json.dumps(record, indent=2) + '\n')
print(json.dumps(record))
sys.exit(result.returncode)
