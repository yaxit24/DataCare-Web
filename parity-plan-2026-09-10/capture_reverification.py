"""Reproduce supplementary source candidates; never modify application code or frozen original scans."""
from pathlib import Path
import json,re,hashlib,importlib.util,datetime
OUT=Path(__file__).resolve().parent; ROOT=OUT.parent; E=OUT/'evidence'
p=ROOT/'project-memory/parity/richness_desktop.py'
spec=importlib.util.spec_from_file_location('desktop_richness',p);m=importlib.util.module_from_spec(spec);spec.loader.exec_module(m)
old=json.loads((E/'control-requirements.json').read_text());old_ids={(x['form'],x['control']) for x in old}
pat=re.compile(r'^\s*(?:private|public|internal|protected)\s+(?:(?:virtual|static|readonly|new|override|sealed)\s+)+(?P<type>[\w.]+)\s+(?P<name>_?\w+)\s*;\s*$',re.M)
rows=[]
for p in sorted((ROOT/'unified/src/csharp/DataCareNext').glob('*.cs')):
 t=p.read_text()
 for x in pat.finditer(t):
  if x['type'].split('.')[-1] not in m.INPUT_TYPES or (p.stem,x['name']) in old_ids:continue
  pos=x.start()+len(x[0])-len(x[0].lstrip())
  rows.append({'id':f"ADD-{p.stem}-CONTROL-{x['name'].lstrip('_')}",'form':p.stem,'control':x['name'],'type':x['type'],'source':str(p.relative_to(ROOT)),'sourceLine':t[:pos].count('\n')+1,'sourceSha256':hashlib.sha256(t.encode()).hexdigest(),'status':'unverified','reason':'Input declaration with modifiers missed by the retained simple declaration regex','visibilityRule':None,'webPath':None,'tests':[]})
support=[]
for p in sorted((ROOT/'unified/src/csharp').rglob('*.cs')):
 if p.parent.name=='DataCareNext':continue
 support.append({'id':'SUP-'+str(p.relative_to(ROOT/'unified/src/csharp')).replace('/','-'),'path':str(p.relative_to(ROOT)),'sha256':hashlib.sha256(p.read_bytes()).hexdigest(),'status':'unverified','requiredDisposition':'Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence','workItems':['P00-01','P00-05','P13-02']})
grid=json.loads((E/'grid-requirements.json').read_text())
summary={'reviewedAt':datetime.datetime.now(datetime.timezone.utc).isoformat(),'kind':'plan-reverification-source-evidence','implementationCertified':False,'originalControlCandidates':len(old),'additionalModifierControlCandidates':len(rows),'affectedPrimaryUnits':len({x['form'] for x in rows}),'combinedInputDeclarationCandidates':len(old)+len(rows),'primaryNamespaceUnits':204,'fullPrimaryTreeCsFiles':len(list((ROOT/'unified/src/csharp').rglob('*.cs'))),'supportingCsFilesOutside204':len(support),'namedGridCandidatesWithNoLiteralLine':sum(not x['sourceLineCandidates'] for x in grid),'authoredContractFiles':len(list((ROOT/'project-memory/contracts').glob('*.contract.md'))),'originalScanner':{'path':'project-memory/parity/richness_desktop.py','sha256':hashlib.sha256((ROOT/'project-memory/parity/richness_desktop.py').read_bytes()).hexdigest(),'declarationPattern':m.DECL.pattern},'limits':'Additional source declaration candidates, not newly proven business fields or a corrected parity percentage. Runtime visibility, semantic identity, remaining parser omissions and every caller still require reconciliation. Original evidence is retained unchanged.'}
for name,data in [('additional-control-candidates.json',rows),('supporting-source-register.json',support),('reverification-source-check.json',summary)]: (E/name).write_text(json.dumps(data,indent=2)+'\n')
md=['# Additional source obligations found during re-verification','','The first register is a useful seed, but its declaration regex misses modifiers. This supplement records **916 additional input declarations in 143 primary source units**, without changing the frozen 1,599-record scan. Together they contain 2,515 input declaration candidates; that is still not an exhaustive semantic field inventory or a parity percentage. Hidden/computed/duplicate controls must be classified, not indiscriminately exposed in the web.','','Use these records alongside [the original form register](04-form-register.md), [source-check evidence](evidence/reverification-source-check.json), [additional control JSON](evidence/additional-control-candidates.json) and [supporting source JSON](evidence/supporting-source-register.json). Every record remains unverified. P00-01/P00-03/P00-05 must merge them into the canonical versioned requirement universe before completion can be judged.','','## Source files outside the 204-unit namespace register','','The complete primary C# tree contains 212 files. These eight support files need explicit disposition; compiler-generated code does not automatically mean irrelevant behaviour. `MyApplication.cs` selects the login form and saves settings on exit.','','| File | Obligation |','| --- | --- |']
for x in support:md.append(f"| [{x['path']}](../{x['path']}) | {x['requiredDisposition']} |")
md += ['','## Additional input declarations by form','','Full line references and stable candidate IDs are in the JSON companion. The declaration count is not the number of user-editable business fields.','','| Source unit | Additional declarations | Control names |','| --- | ---: | --- |']
for form in sorted({x['form'] for x in rows}):
 group=[x for x in rows if x['form']==form]
 md.append(f"| [{form}](../unified/src/csharp/DataCareNext/{form}.cs) | {len(group)} | "+', '.join('`'+x['control']+'`' for x in group)+' |')
md += ['','## Remaining coverage limits','','43 named-grid requirement records still lack a direct literal source-line match. Event-name extraction does not establish each handler’s internal decisions, dynamically selected actions, non-void/async helpers or complete write sets. Resource-driven controls, inherited components, SQL routines, templates and external services require source/runtime reconciliation. Passing this supplement’s structural checks does not discharge those obligations.','']
(OUT/'09-additional-source-register.md').write_text('\n'.join(md)+'\n')
print(json.dumps(summary,indent=2))
