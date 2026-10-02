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
    '12-lineage-verification-2026-10-01.md','13-phase1-delivery-plan.md','14-phase2-saas-plan.md',
    'desktop-form-reference.json','previous-package-reconciliation.json','execution-backlog.json',
    'requirement-index.json','evidence/verification-observations.json',
    'evidence/previous-plan-validation.json','evidence/source-comparison.json',
    'evidence/audit-2026-10-01/observations.json','lineage-register.json','phase2-backlog.json',
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
# implementation plan) continues from G20 and document 12 (lineage verification) from G69. Together they must form
# one contiguous sequence.
gap_ids=[]
for register_doc in ('10-gap-register-2026-10-01.md','11-audit-implementation-plan-2026-10-01.md',
                     '12-lineage-verification-2026-10-01.md'):
    gap_ids+=re.findall(r'^\| (G\d{2}) \|',(here/register_doc).read_text(),re.M)
check(gap_ids==[f'G{i:02}' for i in range(1,len(gap_ids)+1)] and len(gap_ids)>=92, 'Gap register identities incomplete')
# Decisions D01-D14 (document 08), D15-D22 (document 11) and D23 onward (document 12) form one sequence.
decision_ids=[]
for decision_doc in ('08-decisions-and-delivery.md','11-audit-implementation-plan-2026-10-01.md',
                     '12-lineage-verification-2026-10-01.md'):
    decision_ids+=re.findall(r'^\| (D\d{2}) \|',(here/decision_doc).read_text(),re.M)
check(decision_ids==[f'D{i:02}' for i in range(1,len(decision_ids)+1)] and len(decision_ids)>=29,
      'Decision identities incomplete')
cited=set()
for p in slices.values():
    for gap in re.findall(r'G\d{2}',p.get('gapIds','')):
        cited.add(gap)
        check(gap in gap_ids, 'Slice cites an unknown gap: '+p['id']+' '+gap)
check(len(slices)>=89, 'Expected at least 89 ordered slices (document 12 adds N83-N89)')
# Phase 2 (document 14) owns the SaaS gaps through SP slices in phase2-backlog.json.
phase2=load(here/'phase2-backlog.json')
sp={s['id']:s for s in phase2['slices']}
check(sorted(sp)==[f'SP{i:02}' for i in range(1,len(sp)+1)] and len(sp)>=24, 'Phase 2 slice identities incomplete')
milestones={m['id'] for m in phase2['milestones']}
check(milestones=={f'M{i}' for i in range(8)}, 'Phase 2 milestones must be M0-M7')
for s in sp.values():
    check(s['status'] in allowed_status, 'Invented Phase 2 acceptance or unknown status: '+s['id'])
    check(s['milestone'] in milestones, 'Phase 2 slice with unknown milestone: '+s['id'])
    check(bool(s.get('steps')) and bool(s.get('doneWhen')), 'Phase 2 slice without steps or done-when: '+s['id'])
    if s['status']!='planned':
        check(bool(s.get('evidence')) and all((repo/e).exists() for e in s['evidence']),
              'Phase 2 slice status without existing evidence: '+s['id'])
    for gap in re.findall(r'G\d{2}',s.get('gapIds','')):
        cited.add(gap)
        check(gap in gap_ids, 'Phase 2 slice cites an unknown gap: '+s['id']+' '+gap)
    for dep in s['startAfter']:
        check(dep in sp or dep in slices, 'Phase 2 slice depends on an unknown slice: '+s['id']+' '+dep)
def visit_sp(identity, trail):
    if identity in trail:
        errors.append('Phase 2 dependency cycle: '+' -> '.join(trail+[identity])); return
    for dep in sp[identity]['startAfter']:
        if dep in sp: visit_sp(dep,trail+[identity])
for identity in sp: visit_sp(identity,[])
# Decision D28: Phase 2 waits for Phase 1. Every Phase 2 slice reaches SP01 through its dependencies, SP01 waits for
# N30 (certify and roll out Phase 1), and no Phase 2 slice leaves 'planned' while a Phase 1 slice it depends on,
# directly or through other Phase 2 slices, is not yet implemented-unverified.
def sp_reach(identity, seen):
    for dep in sp[identity]['startAfter']:
        if dep not in seen:
            seen.add(dep)
            if dep in sp: sp_reach(dep, seen)
    return seen
check('N30' in sp.get('SP01',{}).get('startAfter',[]), 'Phase 2 gate (D28): SP01 must start after N30')
for identity in sp:
    reach=sp_reach(identity,set())
    if identity!='SP01':
        check('SP01' in reach, 'Phase 2 gate (D28): slice does not depend on SP01: '+identity)
    if sp[identity]['status']!='planned':
        for dep in sorted(reach):
            if dep in slices:
                check(slices[dep]['status']=='implemented-unverified',
                      'Phase 2 gate (D28): '+identity+' started before Phase 1 slice '+dep+' is implemented')
for gap in gap_ids:
    if int(gap[1:])>=20:
        check(gap in cited, 'Audit gap is not assigned to any slice: '+gap)
check(all(int(p['id'][1:])<=30 or p.get('gapIds') for p in slices.values()), 'Amendment slice without a gap reference')
# Lineage register (document 12): every earlier item has a disposition and owners that exist in this plan.
known_ids=set(slices)|set(sp)|set(gap_ids)|set(decision_ids)|set(backlog['releaseGates'])
known_ids|={p['id'] for p in backlog['priorPackages']}|{p['id'] for p in backlog['priorCards']}
known_ids|=set(re.findall(r'^### (J\d{2}) — ',(here/'04-verification-playbook.md').read_text(),re.M))
lineage=load(here/'lineage-register.json')
dispositions=set(lineage['dispositions'])
check(dispositions=={'closed','carried','new-gap','superseded','decision'}, 'Unexpected lineage dispositions')
lineage_counts=Counter()
for source in lineage['sources']:
    check((repo/source['path']).exists(), 'Lineage source does not exist: '+source['path'])
    seen=set()
    for item in source['items']:
        label=source['path']+' '+item['id']
        check(item['id'] not in seen, 'Duplicate lineage item: '+label); seen.add(item['id'])
        check(item['disposition'] in dispositions, 'Unknown lineage disposition: '+label)
        lineage_counts[item['disposition']]+=1
        for owner in item.get('owners',[]):
            check(owner in known_ids, 'Lineage owner does not exist in the plan: '+label+' '+owner)
        for path in item.get('evidence',[]):
            check((repo/path).exists(), 'Lineage evidence path missing: '+label+' '+path)
        if item['disposition']=='closed':
            check(bool(item.get('evidence')), 'Closed lineage item without evidence: '+label)
        elif item['disposition']=='new-gap':
            check(any(re.fullmatch(r'G\d{2}',o) and int(o[1:])>=69 for o in item.get('owners',[])),
                  'New-gap lineage item without a document 12 gap: '+label)
        else:
            check(bool(item.get('owners')), 'Open lineage item without an owner: '+label)
summary=re.search(r'<!-- lineage-counts: (.+?) -->',(here/'12-lineage-verification-2026-10-01.md').read_text())
check(bool(summary), 'Document 12 lacks the lineage-counts summary')
if summary:
    stated=dict(pair.split('=') for pair in summary.group(1).split())
    actual={'sources':len(lineage['sources']),'items':sum(lineage_counts.values()),**lineage_counts}
    check(all(int(stated.get(k,-1))==v for k,v in actual.items()) and set(stated)==set(actual),
          'Document 12 lineage counts differ from lineage-register.json: stated '+str(stated)+' actual '+str(dict(actual)))
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
 'decisionIds':len(decision_ids),'phase2Slices':len(sp),'lineageItems':sum(lineage_counts.values()),
 'auditEvidenceArtefacts':len(audit['artefacts']),'apiModules':len(module_names),
 'businessJourneys':len(journeys),'checkedLocalMarkdownLinks':link_count},'errors':errors},indent=2))
sys.exit(1 if errors else 0)
