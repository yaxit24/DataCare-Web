"""Run a check against the augmented, unchanged-source verification revision."""
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
TARGET = Path('/tmp/datacare-round12-verification')
name, *command = sys.argv[1:]
assert re.fullmatch(r'[a-z0-9-]+', name) and command
manifest = OUT / 'isolated-workspace-inputs-qualified.json'
assert manifest.is_file()
log = OUT / (name + '.txt')
metadata = OUT / (name + '.run.json')
assert not log.exists() and not metadata.exists(), 'Refusing to overwrite check evidence'
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()
started = now()
with log.open('w') as stream:
    result = subprocess.run(command, cwd=TARGET / 'web', stdout=stream, stderr=subprocess.STDOUT)
record = {'command': command, 'cwd': str(TARGET / 'web'),
          'startedAtUtc': started, 'finishedAtUtc': now(), 'exitCode': result.returncode,
          'status': 'passed' if result.returncode == 0 else 'failed',
          'log': str(log.relative_to(ROOT)),
          'isolatedInputManifest': str(manifest.relative_to(ROOT)),
          'isolatedInputManifestSha256': hashlib.sha256(manifest.read_bytes()).hexdigest()}
metadata.write_text(json.dumps(record, indent=2) + '\n')
print(json.dumps(record))
sys.exit(result.returncode)
