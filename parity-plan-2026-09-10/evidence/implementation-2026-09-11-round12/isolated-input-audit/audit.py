from pathlib import Path
import json,hashlib,datetime,re
active=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
frozen=Path('/tmp/datacare-round12-verification')
out=Path('/tmp/datacare-isolated-input-audit')
manifestPath=active/'parity-plan-2026-09-10/evidence/implementation-2026-09-11-round12/isolated-workspace-inputs.json'
m=json.loads(manifestPath.read_text());captured={x['path']:x['sha256'] for x in m['files']}
def sha(p): return hashlib.sha256(p.read_bytes()).hexdigest()
def details(rel):
 a=active/rel; f=frozen/rel
 return {'path':rel,'captured':rel in captured,'capturedSha256':captured.get(rel),'activeExists':a.is_file(),'activeSha256':sha(a) if a.is_file() else None,'frozenExists':f.is_file(),'frozenSha256':sha(f) if f.is_file() else None,'activeBytes':a.stat().st_size if a.is_file() else None}
groups=[]
def fileset(name,rels,why):
 groups.append({'name':name,'rationale':why,'files':[details(rel) for rel in sorted(set(rels))]})
def globset(name,directory,pattern,why,recursive=False):
 a=active/directory;f=frozen/directory
 get=lambda root: sorted(str(p.relative_to(root)) for p in (root/directory).glob(pattern) if p.is_file())
 ar=get(active);fr=get(frozen)
 fileset(name,ar,why)
 groups[-1]['directory']=directory;groups[-1]['pattern']=pattern
 groups[-1]['activeMemberCount']=len(ar);groups[-1]['frozenMemberCount']=len(fr)
 groups[-1]['onlyActiveMembers']=sorted(set(ar)-set(fr));groups[-1]['onlyFrozenMembers']=sorted(set(fr)-set(ar))
globset('desktop primary C# source enumeration','unified/src/csharp/DataCareNext','*.cs','contractIntegrity.test.ts:37-42 enumerates all top-level .cs files and counts their lines;18 selected source files cannot stand in for the204-file directory.')
globset('behavior contract directory','project-memory/contracts','*.contract.md','contractIntegrity.test.ts:31-34 enumerates, sorts and reads every top-level .contract.md; directory membership is part of the input.')
fileset('release/completion reference data',[
'project-memory/parity/PARITY-RATCHET.json','project-memory/parity/g5/parity-diff-latest.json','project-memory/parity/restore-drill-result.json','parity-plan-2026-09-10/evidence/report-register.json','web/docs/COMPLETION-REGISTER.json'],
'Frozen releaseCertification.test.ts:270,393,707-760 and completionRegister.test.ts:30 use current retained references; absence handling is an assertion input, not an excuse to bypass a read.')
fileset('deployment files',['web/deploy/.env.example','web/deploy/docker-compose.prod.yml','web/docker-compose.yml'],
'einvoiceProductionGuard.test.ts:102-132 reads these exact files. .env.example was omitted and a stale Git-baseline copy remained; capture bytes without emitting any environment contents.')
fileset('release workflow text',['.github/workflows/ci.yml','.github/workflows/release-certification.yml','web/.github/workflows/ci.yml','web/.github/workflows/release-certification.yml'],
'releaseCertification.test.ts:609-695 reads both active root and historical nested CI/release workflow copies and compares semantics.')
fileset('web source read by API assertions',['web/apps/web/test/parity.real-stack.mjs','web/apps/web/components/KarigarForm.tsx']+['web/apps/web/app/(app)/txn/'+x+'/page.tsx' for x in ['jobwork-issue','jobwork-receive','karigar-issue','karigar-receive','wholesale-sale']],
'releaseCertification.test.ts:448 reads the actual journey producer. pageEndpointFamily.test.ts:24-26,30-94 reads the shared component and five transaction pages.')
register=json.loads((frozen/'web/docs/COMPLETION-REGISTER.json').read_text())
pagepaths=[x['webSurface']['surface'] for x in register['items'] if x.get('webSurface') and x['webSurface']['kind']=='page']
fileset('completion-register declared page existence',pagepaths,
'completionRegister.test.ts:72-75 tests existsSync/statSync for every declared page surface; exact page claims and filesystem presence must be reproducible.')
globset('API source scanned as data','web/apps/api/src','**/*.ts','postingAccountLiterals.test.ts recursively reads API TypeScript; kernelConformance.test.ts does the same; routePolicy/routeInputForwarding also read specific API source files.')
globset('core source scanned as data','web/packages/core/src','**/*.ts','kernelConformance.test.ts:35-54 scans every core TypeScript source, independently of compiled imports; preserve frozen membership, not unrelated new active files.')
globset('report specification data','web/apps/api/report-specs','*.json','reportContract.test.ts:252-293 reads all .spec.json plus schema; reportEngine loads named .spec.json and report-layouts-index.json or falls back to directory enumeration.')
globset('form specification data','web/apps/api/form-specs','*.json','formLayoutEngine.ts:24-61 loads name variants and enumerates all JSON files when called by the API; include all captured176 spec files and preserve membership.')
fileset('schema and cross-package literal fixtures',['web/packages/db/prisma/schema.prisma','web/packages/core/test/fixtures/saleReturnIncoming.independent.json','web/packages/core/test/fixtures/saleReturnIncoming.widths.json'],
'reportContract.test.ts reads Prisma schema; saleReturnIncomingConfiguration.review.test.ts:30-39 hashes/reads both core golden files directly.')
fileset('script modules imported by tests',['web/scripts/lib/release-certification-record.mjs','web/scripts/lib/release-candidate-identity.mjs','web/scripts/load-profile.mjs','web/scripts/secret-scanner.mjs','web/apps/api/package.json'],
'Test imports exercise script helper functions. load-profile creates require relative to API package.json. secret-scanner uses TypeScript package dependency. Release identity uses synthetic files/injected Git, not live source checkout files.')
# API-local fixtures are already captured; retain their complete membership because direct imports and readFile both occur.
globset('API-local fixture data and helpers','web/apps/api/test/fixtures','**/*','Direct readFile/new URL and JSON imports in image, configuration, source, replay and ledger tests; complete fixture membership remains captured.')
unique={x['path']:x for g in groups for x in g['files']}
missing=[x for x in unique.values() if not x['captured'] and x['activeExists']]
existingChanged=[x for x in unique.values() if x['captured'] and x['activeExists'] and x['activeSha256']!=x['capturedSha256']]
frozenMismatch=[x for x in unique.values() if x['captured'] and x['frozenSha256']!=x['capturedSha256']]
# Any stale baseline members in scanned frozen directories must be listed, not silently treated as captured.
uncapturedFrozenMembers=[]
for g in groups:
 if 'directory' in g:
  for p in (frozen/g['directory']).glob(g['pattern']):
   if p.is_file():
    rel=str(p.relative_to(frozen))
    if rel not in captured: uncapturedFrozenMembers.append(rel)
# Read-only compare active vs frozen test bytes; preserve frozen assertions.
testDiff=[]
for f in (frozen/'web/apps/api/test').rglob('*'):
 if not f.is_file() or f.suffix not in ['.ts','.mjs']:continue
 rel=str(f.relative_to(frozen));a=active/rel
 if a.is_file() and sha(a)!=sha(f):testDiff.append({'path':rel,'frozenSha256':sha(f),'activeSha256':sha(a)})
add={'kind':'isolated-api-external-reference-additions/v1','baselineManifest':{'path':str(manifestPath),'sha256':sha(manifestPath),'files':len(captured)},'files':[{'path':x['path'],'sha256':x['activeSha256'],'bytes':x['activeBytes']} for x in sorted(missing,key=lambda x:x['path'])],'preserveCapturedFilesByteForByte':True,'externalAbsences':['project-memory/parity/reports/report-comparison-latest.json']}
(out/'recommended-reference-additions.json').write_text(json.dumps(add,indent=2)+'\n')
report={'kind':'read-only-api-filesystem-input-audit/v1','capturedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'activeRoot':str(active),'frozenRoot':str(frozen),'baselineManifest':add['baselineManifest'],'groups':groups,'recommendedAdditionalFileCount':len(missing),'recommendedAdditionalBytes':sum(x['activeBytes'] for x in missing),'alreadyCapturedReferenceActiveDrift':existingChanged,'capturedReferenceFrozenMismatch':frozenMismatch,'uncapturedFrozenDirectoryMembers':sorted(set(uncapturedFrozenMembers)),'activeFrozenApiTestSourceDrift':testDiff,'preservedExternalAbsences':add['externalAbsences'],'notExecuted':['No tests','No compiler','No database','No repository mutation'],'limitations':['Static source/import and current directory membership audit, not system-call tracing.','Node modules/generated Prisma/current built package outputs remain governed by the dependency/build capture, not duplicated into this external-reference appendix.','Frozen assertions are authoritative; active existsSync-based bypasses are not adopted.']}
(out/'audit.json').write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps({'recommendedAdditionalFiles':len(missing),'recommendedAdditionalBytes':report['recommendedAdditionalBytes'],'outsideDesktopAdditions':[x['path'] for x in missing if not x['path'].startswith('unified/')],'capturedReferenceFrozenMismatch':frozenMismatch,'alreadyCapturedReferenceActiveDrift':[x['path'] for x in existingChanged],'uncapturedFrozenDirectoryMembers':sorted(set(uncapturedFrozenMembers)),'apiTestDrift':testDiff,'groups':[{k:v for k,v in g.items() if k in ['name','activeMemberCount','frozenMemberCount','onlyFrozenMembers']} for g in groups],'hashes':{x.name:sha(x) for x in [out/'recommended-reference-additions.json',out/'audit.json']}},indent=2))
