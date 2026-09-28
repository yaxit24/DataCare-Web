"""Capture source-only parity measurements into a NEW directory.

Usage: python3 capture_measurements.py --output /absolute/path/to/new-snapshot
Does not rewrite prior evidence, application code or the project's existing baselines.
"""
from pathlib import Path
import argparse
import contextlib
import datetime
import hashlib
import importlib.util
import json
import subprocess

ROOT = Path(__file__).resolve().parent.parent
SCRIPTS = ROOT / 'project-memory/parity'
parser = argparse.ArgumentParser()
parser.add_argument('--output', required=True, type=Path)
args = parser.parse_args()
out = args.output.resolve()
out.mkdir(parents=True, exist_ok=False)
manifest = []
for script, name, extra in [
    ('richness_desktop.py', 'DESKTOP-RICHNESS.json', ['DataCareNext']),
    ('richness_desktop.py', 'DESKTOP-RICHNESS-NEXTDM.json', ['NextDm']),
    ('richness_web.py', 'WEB-RICHNESS.json', []),
    ('settings_parity.py', 'SETTINGS-PARITY.json', []),
    ('gap_manifest.py', 'GAP-MANIFEST.json', []),
]:
    result = subprocess.run(['python3', str(SCRIPTS/script), *extra], text=True, capture_output=True, check=True)
    json.loads(result.stdout)
    (out/name).write_text(result.stdout)
    manifest.append({'script': script, 'arguments': extra, 'sha256': hashlib.sha256((SCRIPTS/script).read_bytes()).hexdigest()})
for script, name in [('settings_effect.py','SETTINGS-EFFECT.json'),
                     ('triage_unreachable.py','UNREACHABLE-TRIAGE.json'),
                     ('richness_join.py','RICHNESS-JOIN.json')]:
    spec = importlib.util.spec_from_file_location(script[:-3], SCRIPTS/script)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    if script == 'settings_effect.py':
        module.PARITY = str(out/'SETTINGS-PARITY.json')
    elif script == 'triage_unreachable.py':
        module.HERE = str(out)
    else:
        module.load = lambda name: json.loads(((SCRIPTS if name == 'DESKTOP-WEB-PARITY-MATRIX.json' else out)/name).read_text())
    with (out/name).open('w') as stream, contextlib.redirect_stdout(stream):
        module.main()
    manifest.append({'script':script,'sha256':hashlib.sha256((SCRIPTS/script).read_bytes()).hexdigest(),
                     'dependencyOverride':'fresh snapshot JSON supplied in memory; original source/baselines unchanged'})
(out/'measurement-method.json').write_text(json.dumps({
    'capturedAt':datetime.datetime.now(datetime.timezone.utc).isoformat(),
    'root':str(ROOT),'scripts':manifest,
    'mappingSha256':hashlib.sha256((SCRIPTS/'DESKTOP-WEB-PARITY-MATRIX.json').read_bytes()).hexdigest(),
    'note':'Heuristic counts and inherited mapping, not runtime certification.'},indent=2)+'\n')
print(out)
