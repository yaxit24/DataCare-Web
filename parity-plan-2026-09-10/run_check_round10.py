"""Record a local check's exact argv, output and actual exit status once."""
from pathlib import Path
import datetime
import json
import re
import subprocess
import sys

root = Path(__file__).resolve().parent.parent
evidence = root / 'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10'
name, *command = sys.argv[1:]
assert re.fullmatch(r'[a-z0-9-]+', name) and command
log = evidence / (name + '.txt')
metadata = evidence / (name + '.run.json')
assert not log.exists() and not metadata.exists(), 'Refusing to overwrite check evidence'
now = lambda: datetime.datetime.now(datetime.timezone.utc).isoformat()
started = now()
with log.open('w') as stream:
    result = subprocess.run(command, cwd=root / 'web', stdout=stream, stderr=subprocess.STDOUT)
record = {'command': command, 'cwd': 'web', 'startedAtUtc': started, 'finishedAtUtc': now(),
          'exitCode': result.returncode, 'status': 'passed' if result.returncode == 0 else 'failed',
          'log': str(log.relative_to(root))}
metadata.write_text(json.dumps(record, indent=2) + '\n')
print(json.dumps(record))
sys.exit(result.returncode)
