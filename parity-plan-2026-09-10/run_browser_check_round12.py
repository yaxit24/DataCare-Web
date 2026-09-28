"""Run one frozen browser check with its separately pinned acceptance-reference inputs."""
from pathlib import Path
import datetime
import hashlib
import json
import re
import subprocess
import sys

PLAN = Path(__file__).resolve().parent
ROOT = PLAN.parent
OUT = PLAN / 'evidence/implementation-2026-09-11-round12'
FROZEN = Path('/tmp/datacare-round12-verification')
sha = lambda path: hashlib.sha256(path.read_bytes()).hexdigest()
name, *command = sys.argv[1:]
assert re.fullmatch(r'[a-z0-9-]+', name) and command
manifest = OUT / 'isolated-workspace-inputs-qualified.json'
supplement = OUT / 'isolated-browser-fixtures.json'
inputs = json.loads(manifest.read_text())['files'] + json.loads(supplement.read_text())['files']
assert all(sha(FROZEN / row['path']) == row['sha256'] for row in inputs)
manifest_sha, supplement_sha = sha(manifest), sha(supplement)
log, metadata = OUT / (name + '.txt'), OUT / (name + '.run.json')
assert not log.exists() and not metadata.exists()
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()
started = now()
with log.open('w') as stream:
    result = subprocess.run(command, cwd=FROZEN / 'web', stdout=stream, stderr=subprocess.STDOUT)
changed = [row['path'] for row in inputs if not (FROZEN / row['path']).is_file() or sha(FROZEN / row['path']) != row['sha256']]
record = {
    'command': command, 'cwd': str(FROZEN / 'web'),
    'startedAtUtc': started, 'finishedAtUtc': now(), 'exitCode': result.returncode,
    'status': 'passed' if result.returncode == 0 else 'failed', 'log': str(log.relative_to(ROOT)),
    'isolatedInputManifest': str(manifest.relative_to(ROOT)),
    'isolatedInputManifestSha256': manifest_sha,
    'supplementalBrowserFixtureManifest': str(supplement.relative_to(ROOT)),
    'supplementalBrowserFixtureManifestSha256': supplement_sha,
    'changedFrozenInputs': changed,
}
metadata.write_text(json.dumps(record, indent=2) + '\n')
print(json.dumps(record))
assert sha(manifest) == manifest_sha and sha(supplement) == supplement_sha and not changed
sys.exit(result.returncode)
