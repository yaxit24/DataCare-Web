#!/usr/bin/env python3
"""Read-only integrity validation for this planning package, not product certification.

Run from any directory: python3 docs/master-parity-plan-2026-09-29/validate_plan.py
Requires the complete repository checkout. Prints JSON; does not modify any file.
"""
from pathlib import Path
from collections import Counter
import hashlib
import json
import re
import sys
from urllib.parse import unquote

here = Path(__file__).resolve().parent
repo = here.parent.parent
errors = []
def load(path):
    return json.loads(path.read_text())
def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()
def check(condition, message):
    if not condition:
        errors.append(message)
def pointer(document, value):
    for part in value.split('/')[1:]:
        part = part.replace('~1', '/').replace('~0', '~')
        document = document[int(part)] if isinstance(document, list) else document[part]
    return document

required = ['README.md'] + [
    '01-current-assessment.md','02-execution-plan.md','03-shared-contracts.md',
    '04-verification-playbook.md','05-desktop-reference.md','06-module-detail.md',
    '07-previous-plan-reconciliation.md','08-decisions-and-delivery.md','09-surface-register.md',
    '10-gap-register-2026-10-01.md','11-audit-implementation-plan-2026-10-01.md',
    'desktop-form-reference.json','previous-package-reconciliation.json','execution-backlog.json',
    'requirement-index.json','evidence/verification-observations.json',
    'evidence/previous-plan-validation.json','evidence/source-comparison.json',
    'evidence/audit-2026-10-01/observations.json',
]
for name in required:
    check((here/name).is_file() and (here/name).stat().st_size>0, 'Missing/empty deliverable: '+name)

register = load(here/'requirement-index.json')
records = register['records']
check(len(records)==register['recordCount'], 'Requirement record count mismatch')
check(len({r['id'] for r in records})==len(records), 'Duplicate new requirement record identity')
source_docs={}
for source in register['sourceRegisters']:
    path=repo/source['path']
    check(path.is_file(), 'Missing source register: '+source['path'])
    if not path.is_file(): continue
    check(digest(path)==source['sha256'], 'Source register changed: '+source['path'])
    source_docs[source['path']]=load(path)
    rows=pointer(source_docs[source['path']],source['arrayPointer']) if source['arrayPointer'] else source_docs[source['path']]
    check(len(rows)==source['count'], 'Source register count mismatch: '+source['path'])
    found=[r for r in records if r['sourceRegister']==source['path']]
    expected={source['arrayPointer']+'/'+str(i) for i in range(len(rows))}
    check({r['jsonPointer'] for r in found}==expected and len(found)==len(rows), 'Lost/duplicated original row: '+source['path'])
for record in records:
    original=pointer(source_docs[record['sourceRegister']],record['jsonPointer'])
    oid=original.get('id') or original.get('key') or f"{original['tab']}/{original['menu']}"
    check(oid==record['originalId'], 'Original identity changed: '+record['id'])
    check(record['acceptance']=='unverified', 'Planning index invents acceptance: '+record['id'])
    if record.get('desktopSource'):
        check((repo/record['desktopSource']).is_file(), 'Missing desktop source: '+record['desktopSource'])

desktop=load(here/'desktop-form-reference.json')
check(len(desktop['sourceUnits'])==204, 'Unexpected primary source index count')
for unit in desktop['sourceUnits']:
    path=repo/unit['source']
    check(path.is_file() and digest(path)==unit['sourceSha256'], 'Desktop source identity changed: '+unit['source'])
    lines=path.read_text().splitlines()
    for anchor in unit['methodAnchors']:
        check(1<=anchor['line']<=len(lines), 'Out-of-range method source anchor: '+unit['source'])

backlog=load(here/'execution-backlog.json')
old=repo/'parity-plan-2026-09-10'
old_packages=load(old/'07-work-items.json')['workItems']
old_cards=load(old/'13-execution-backlog.json')['tasks']
check({p['id'] for p in backlog['priorPackages']}=={p['id'] for p in old_packages}, 'Missing original package IDs')
check({p['id'] for p in backlog['priorCards']}=={p['id'] for p in old_cards}, 'Missing original card IDs')
check(all(p['acceptance']=='open' for p in backlog['priorPackages']), 'Invented parent acceptance')
check(all(p['status']=='open' for p in backlog['priorCards']), 'Invented prior card closure')
slices={p['id']:p for p in backlog['newSlices']}
# N01-N30 are the original ordered slices; the 1 October 2026 amendment (document 10) adds N31-N46.
check(sorted(slices)==[f'N{i:02}' for i in range(1,len(slices)+1)], 'Slice identities are not a contiguous N01.. sequence')
check(len(slices)>=46, 'Expected at least 46 ordered slices (N01-N30 plus amendment N31-N46)')
allowed_status={'planned','in-progress','implemented-unverified'}
check(all(p['status'] in allowed_status for p in slices.values()), 'Invented slice acceptance or unknown slice status')
for p in slices.values():
    if p['status']!='planned':
        evidence=p.get('evidence') or []
        check(bool(evidence), 'Slice status without evidence: '+p['id'])
        for item in evidence:
            check((repo/item).exists(), 'Missing slice evidence path: '+p['id']+' '+item)
# Gap identities continue across the registers: document 10 holds G01-G19, document 11 (the 1 October audit
# implementation plan) continues from G20. Together they must form one contiguous sequence.
gap_ids=[]
for register_doc in ('10-gap-register-2026-10-01.md','11-audit-implementation-plan-2026-10-01.md'):
    gap_ids+=re.findall(r'^\| (G\d{2}) \|',(here/register_doc).read_text(),re.M)
check(gap_ids==[f'G{i:02}' for i in range(1,len(gap_ids)+1)] and len(gap_ids)>=66, 'Gap register identities incomplete')
cited=set()
for p in slices.values():
    for gap in re.findall(r'G\d{2}',p.get('gapIds','')):
        cited.add(gap)
        check(gap in gap_ids, 'Slice cites an unknown gap: '+p['id']+' '+gap)
check(len(slices)>=82, 'Expected at least 82 ordered slices (document 11 adds N47-N82)')
for gap in gap_ids:
    if int(gap[1:])>=20:
        check(gap in cited, 'Audit gap is not assigned to any slice: '+gap)
check(all(int(p['id'][1:])<=30 or p.get('gapIds') for p in slices.values()), 'Amendment slice without a gap reference')
def visit(identity, trail):
    if identity in trail:
        errors.append('Slice start dependency cycle: '+' -> '.join(trail+[identity])); return
    if identity not in slices:
        errors.append('Unknown slice dependency: '+identity); return
    for dep in slices[identity]['startAfter']:
        visit(dep,trail+[identity])
for identity in slices: visit(identity,[])
check(backlog['releaseGates']==[f'R{i:02}' for i in range(15)], 'Retained release gate identities incomplete')
reconciliation=load(here/'previous-package-reconciliation.json')
check({p['id'] for p in reconciliation['packages']}=={p['id'] for p in old_packages}, 'Incomplete reconciliation')

module_text=(here/'06-module-detail.md').read_text()
module_names={p.name for p in (repo/'web/apps/api/src/modules').iterdir() if p.is_dir()}
covered=set(re.findall(r'^### ([a-z]+)$',module_text,re.M))
check(module_names<=covered, 'API module appendix misses: '+','.join(sorted(module_names-covered)))
journeys=re.findall(r'^### (J\d{2}) — ',(here/'04-verification-playbook.md').read_text(),re.M)
check(journeys==[f'J{i:02}' for i in range(1,29)], 'Journey sequence incomplete')

# Check actual Markdown links in the package, not source-path abbreviations in prose.
link_count=0
for path in here.glob('*.md'):
    for target in re.findall(r'(?<!!)\[[^\]]+\]\(([^)]+)\)',path.read_text()):
        target=unquote(target.strip('<>').split('#',1)[0])
        if not target or '://' in target: continue
        link_count+=1
        check((path.parent/target).exists(), f'Broken local link in {path.name}: {target}')
observations=load(here/'evidence/verification-observations.json')
for observation in observations['checks']:
    if observation.get('log'):
        path=here/'evidence'/observation['log']
        check(path.is_file() and digest(path)==observation['logSha256'], 'Test log hash mismatch: '+observation['log'])
audit_dir=here/'evidence/audit-2026-10-01'
audit=load(audit_dir/'observations.json')
for artefact in audit['artefacts']:
    path=audit_dir/artefact['path']
    check(path.is_file() and digest(path)==artefact['sha256'], 'Audit evidence hash mismatch: '+artefact['path'])

print(json.dumps({'status':'pass' if not errors else 'fail',
 'meaning':'Planning structure, retained-record coverage, source identities and log integrity only; no runtime/full-product certification.',
 'counts':{'indexedRawRecords':len(records),'sourceRegisters':len(register['sourceRegisters']),
 'primarySources':len(desktop['sourceUnits']),'priorPackages':len(backlog['priorPackages']),
 'priorCards':len(backlog['priorCards']),'newSlices':len(slices),'gapIds':len(gap_ids),
 'auditEvidenceArtefacts':len(audit['artefacts']),'apiModules':len(module_names),
 'businessJourneys':len(journeys),'checkedLocalMarkdownLinks':link_count},'errors':errors},indent=2))
sys.exit(1 if errors else 0)
