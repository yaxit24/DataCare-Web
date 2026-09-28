"""Validate this documentation package; never run application/database mutations."""
from pathlib import Path
import datetime
import hashlib
import json
import re
import sys

sys.dont_write_bytecode = True

# The original snapshot checks remain available verbatim in --historical mode.
# Current progress is no longer represented by all 83 packages being "planned";
# validate the reviewed continuation and the latest chained implementation snapshot.
# --self-test-checkpoint-chain exercises in-memory rejection controls before checkpoint19
# exists. Current modes write only round3 evidence and preserve checkpoints15/17.
if '--historical' not in sys.argv:
    from validate_current_review import main
    raise SystemExit(main())

OUT = Path(__file__).resolve().parent
ROOT = OUT.parent
errors = []
for path in OUT.rglob('*.json'):
    try:
        json.loads(path.read_text())
    except Exception as exc:
        errors.append(f'{path.name}: invalid JSON: {exc}')
links = 0
for path in OUT.rglob('*.md'):
    text = path.read_text()
    for match in re.finditer(r'\]\((?:<([^>]+)>|([^\s)]+))\)', text):
        target = match[1] or match[2]
        if target.startswith(('https://', 'http://', '#')):
            continue
        links += 1
        if not (path.parent / target.split('#')[0]).exists():
            errors.append(f'{path.name}: missing local link {target}')
    expected = None
    for number, line in enumerate(text.splitlines(), 1):
        if not line.startswith('|'):
            expected = None
            continue
        columns = len(re.split(r'(?<!\\)\|', line)) - 2
        if expected is None:
            expected = columns
        elif columns != expected:
            errors.append(f'{path.name}:{number}: table has {columns} columns, expected {expected}')

expected_counts = {'form-register': 204, 'grid-requirements': 3508,
                   'control-requirements': 1599, 'event-requirements': 5838,
                   'report-register': 275, 'table-register': 146}
for name, count in expected_counts.items():
    rows = json.loads((OUT/'evidence'/f'{name}.json').read_text())
    if len(rows) != count:
        errors.append(f'{name}: expected {count}, got {len(rows)}')
    if len({row['id'] for row in rows}) != len(rows):
        errors.append(f'{name}: duplicate requirement IDs')

work = json.loads((OUT/'07-work-items.json').read_text())
if len(work['workItems']) != 83:
    errors.append('Expected 83 work packages')
for item in work['workItems']:
    if not item['acceptance']:
        errors.append(f"{item['id']}: missing acceptance clause")
    if item['status'] != 'planned':
        errors.append(f"{item['id']}: planning output unexpectedly marks implementation status")
deps = work['phaseDependencies']
def visit(phase, stack):
    if phase in stack:
        errors.append('Phase dependency cycle: ' + ' -> '.join(stack+[phase]))
        return
    for dependency in deps.get(phase, []):
        if dependency not in deps:
            errors.append(f'Unknown phase {dependency}')
        else:
            visit(dependency, stack+[phase])
for phase in deps:
    visit(phase, [])

scenarios = re.findall(r'^\| ((?:SET|PUR|SAL|FLOW|FIN|STK|MFG|SCH|RPT|OPS)-\d+) \|',
                       (OUT/'03-verification-and-release.md').read_text(), re.M)
if len(scenarios) != 128 or len(set(scenarios)) != 128:
    errors.append('Expected 128 distinct business scenario anchors in this planning revision')

# These are frozen documentation revision checks, not runtime parity thresholds.
# The release harness specified in the plan must discover/expand the full universe.
coverage = json.loads((OUT/'10-plan-coverage-obligations.json').read_text())
work_ids = {x['id'] for x in work['workItems']}
covered_work = set()
gate_ids = {f'R{i:02}' for i in range(15)}
groups = {x.split('-')[0] for x in scenarios}
if coverage['scenarioAnchors'] != scenarios:
    errors.append('Coverage scenario list differs from authored scenario catalog')
if len(coverage['coverage']) != 23 or len({x['id'] for x in coverage['coverage']}) != 23:
    errors.append('Expected 23 unique planning coverage domains')
for item in coverage['coverage']:
    covered_work.update(item['workItems'])
    for field, valid in [('workItems', work_ids), ('scenarioGroups', groups), ('releaseGates', gate_ids)]:
        unknown = set(item[field]) - valid
        if unknown:
            errors.append(f"{item['id']}: unknown {field}: {sorted(unknown)}")
    if item['status'] != 'planned-verification-required' or item['evidence']:
        errors.append(f"{item['id']}: unexpected runtime completion claim")
if covered_work != work_ids:
    errors.append('Planning coverage must account for all authored work items')
contract = work.get('completionContract', {})
if contract.get('fixedTaskCountIsCompletionCeiling') is not False or contract.get('runtimeEnforced') is not False:
    errors.append('Work-item completion specification missing or misrepresented as implemented')

additional = json.loads((OUT/'evidence/additional-control-candidates.json').read_text())
support = json.loads((OUT/'evidence/supporting-source-register.json').read_text())
if len(additional) != 916 or len({x['id'] for x in additional}) != 916:
    errors.append('Expected 916 distinct supplementary declaration candidates')
if len({x['form'] for x in additional}) != 143 or len(support) != 8:
    errors.append('Supplemental source coverage counts differ from measured revision')
original_controls = json.loads((OUT/'evidence/control-requirements.json').read_text())
if {(x['form'], x['control']) for x in original_controls} & {(x['form'], x['control']) for x in additional}:
    errors.append('Supplementary controls duplicate original declaration identities')
hashes = {}
for item in additional + support:
    path = ROOT/item.get('source', item.get('path'))
    if path not in hashes:
        hashes[path] = hashlib.sha256(path.read_bytes()).hexdigest() if path.exists() else None
    if hashes[path] != item.get('sourceSha256', item.get('sha256')):
        errors.append(f"Supplement source changed: {path.relative_to(ROOT)}")
    if item['status'] != 'unverified':
        errors.append(f"{item['id']}: supplemental inventory is not a runtime certificate")
    if 'sourceLine' in item:
        lines = path.read_text().splitlines()
        if item['control'] not in lines[item['sourceLine']-1]:
            errors.append(f"{item['id']}: invalid declaration source line")

source = json.loads((OUT/'evidence/source-manifest.json').read_text())
changed = []
for item in source['files']:
    path = ROOT/item['path']
    if not path.exists() or hashlib.sha256(path.read_bytes()).hexdigest() != item['sha256']:
        changed.append(item['path'])
if changed:
    errors.append(f'Reviewed source changed after snapshot: {changed}')

result = {'validatedAt': datetime.datetime.now(datetime.timezone.utc).isoformat(),
          'status': 'passed' if not errors else 'failed', 'localLinksChecked': links,
          'workPackages':len(work['workItems']), 'scenarioAnchors':len(scenarios),
          'planningCoverageDomains':len(coverage['coverage']),
          'supplementalControlCandidates':len(additional),
          'supportingSourceFiles':len(support),
          'registerCounts':expected_counts, 'reviewedSourceFilesUnchanged':len(source['files'])-len(changed),
          'errors': errors,
          'limits':'Documentation/schema/link and source-preservation checks only; not implementation or runtime certification.'}
(OUT/'evidence/document-validation.json').write_text(json.dumps(result,indent=2)+'\n')
print(json.dumps(result,indent=2))
raise SystemExit(1 if errors else 0)
