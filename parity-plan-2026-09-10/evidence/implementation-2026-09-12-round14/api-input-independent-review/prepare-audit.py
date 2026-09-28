from pathlib import Path
import json,hashlib,datetime,re
ROOT=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
OUT=Path('/tmp/datacare-round14-api-input-review')
BASE='parity-plan-2026-09-10/evidence/implementation-2026-09-12-round14/browser-context-final.inputs.json'
baseline=json.loads((ROOT/BASE).read_text())['files']
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def save(n,x): (OUT/n).write_text(json.dumps(x,indent=2)+'\n')
def ref(n):
 p=ROOT/n
 return {'path':n,'present':p.is_file(),'sha256':sha(p) if p.is_file() else None,'capturedInObserved1883':n in baseline,'sameAsObserved1883':baseline.get(n)==sha(p) if p.is_file() and n in baseline else None}
extra=[]
def group(id,paths,consumers,kind='direct-api'):
 extra.append({'id':id,'kind':kind,'paths':[ref(n) for n in paths],'consumers':consumers})
pagepaths=[f'web/apps/web/app/(app)/txn/{x}/page.tsx' for x in ['jobwork-issue','jobwork-receive','karigar-issue','karigar-receive','wholesale-sale']]
group('page-endpoint-family',pagepaths+['web/apps/web/components/KarigarForm.tsx'],['web/apps/api/test/pageEndpointFamily.test.ts:24-26,38-60,81-84'])
register=json.loads((ROOT/'web/docs/COMPLETION-REGISTER.json').read_text())
pages=sorted({x['webSurface']['surface'] for x in register['items'] if x.get('webSurface',{} ) and x['webSurface']['kind']=='page'})
group('completion-register-and-dynamic-page-existence',['web/docs/COMPLETION-REGISTER.json']+pages,['web/apps/api/test/completionRegister.test.ts:30-31,72-75,115-125'])
group('deployment-literals',['web/deploy/.env.example','web/deploy/docker-compose.prod.yml','web/docker-compose.yml'],['web/apps/api/test/einvoiceProductionGuard.test.ts:103-105,117-119,130-131'])
group('release-current-repository-observations',['parity-plan-2026-09-10/evidence/report-register.json','project-memory/parity/PARITY-RATCHET.json','web/apps/web/test/parity.real-stack.mjs','.github/workflows/ci.yml','.github/workflows/release-certification.yml','web/.github/workflows/ci.yml','web/.github/workflows/release-certification.yml','web/scripts/release-certify.mjs','project-memory/parity/g5/parity-diff-latest.json','project-memory/parity/restore-drill-result.json','project-memory/parity/reports/report-comparison-latest.json'],['web/apps/api/test/releaseCertification.test.ts:327-329,510-512,693-701,1088-1118,1183-1205,1258-1322','web/apps/api/src/modules/ops/releaseCertification.ts:1256,1365,1451'])
membership=[]
for prefix,pattern in [('project-memory/contracts','*.contract.md'),('unified/src/csharp/DataCareNext','*.cs')]:
 paths=sorted(str(p.relative_to(ROOT)) for p in (ROOT/prefix).glob(pattern) if p.is_file())
 membership.append({'directory':prefix,'pattern':pattern,'count':len(paths),'paths':[ref(n) for n in paths],'consumer':'web/apps/api/test/contractIntegrity.test.ts:28-41','capture':'capture_implementation_checkpoint_round12_isolated.py:29-32,125-128 includes current directory membership'})
extra_prefixes=['web/apps/web/app/','web/apps/web/components/','web/docs/COMPLETION-REGISTER.json','web/deploy/.env.example','web/deploy/docker-compose.prod.yml','web/docker-compose.yml','project-memory/contracts/','unified/src/csharp/DataCareNext/']
group('runner-toolchain-config',['web/package.json','web/pnpm-lock.yaml','web/pnpm-workspace.yaml','web/tsconfig.base.json','web/turbo.json','web/docker-compose.parity-test.yml','web/apps/api/package.json','web/apps/api/vitest.config.ts','web/apps/api/tsconfig.json','web/apps/api/tsconfig.test.json','web/packages/db/package.json','web/packages/core/package.json','parity-plan-2026-09-10/capture_implementation_checkpoint_round12_isolated.py','parity-plan-2026-09-10/run_check_round14.py','parity-plan-2026-09-10/capture_implementation_checkpoint_round14.py'],['web/scripts/parity-test-env.mjs:40-49,76-98,132-135','web/apps/api/vitest.config.ts:34','web/package.json:11-15,38'],kind='runner-and-module-resolution')
secret=['web/.env.parity-test','web/packages/db/.env','web/.env','web/packages/db/prisma/.env','web/apps/api/.env']
save('environment-input-observations.json',{'kind':'private-local-environment-input-identities/v1','observedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'qualification':'Only path/presence/SHA; no values were emitted or copied. Keep contents OUT of public sourceFiles/source archive. Before/after identities must be recorded separately by the run helper.','files':[ref(n) for n in secret],'consumers':{'web/.env.parity-test':'Direct wrapper read/create: web/scripts/parity-test-env.mjs:12-29; fixed isolated DSNs override inherited DSNs at32-39.','web/packages/db/.env':'Generated Prisma client relativeEnvPaths.schemaEnvPath at index.js:6895-6897 and warnEnvConflicts:6945-6947. Also CLI discovery candidate.','web/.env':'Prisma CLI/discovery and compose working-directory candidate. This audit does not claim Vitest directly imports it.','absent-candidates':'web/packages/db/prisma/.env and web/apps/api/.env are absent local discovery candidates; record absence, not a fabricated read.'}})
fs_tests=[]
for p in sorted((ROOT/'web/apps/api/test').rglob('*')):
 if p.suffix not in ['.ts','.js','.mjs','.cjs']:continue
 txt=p.read_text()
 if re.search(r'readFile|readdir|existsSync|accessSync|statSync|lstatSync|realpathSync|createReadStream|readlink',txt): fs_tests.append(ref(str(p.relative_to(ROOT))))
save('audit.json',{'kind':'round14-api-external-input-static-audit/v1','observedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'status':'source-review-only-no-test-execution','observedManifest':ref(BASE),'groups':extra,'directoryMembership':membership,'additionalRequiredCurrentPrefixes':extra_prefixes,'expectedAbsences':['project-memory/parity/reports/report-comparison-latest.json'],'environmentIdentityRecord':'environment-input-observations.json','fsReaderTestInventory':fs_tests,'limits':['Static source review, not runtime filesystem instrumentation or an exhaustive installed-toolchain image.','Generated temporary test directories and injected Git/filesystem doubles are fixture outputs, not preexisting repository inputs.','Standalone verification CLIs have separate conditional input requirements in verification-only-inputs.json.']})
verify=[
 {'script':'web/scripts/check-depth.mjs:36-38,50,63-67','inputs':['web/parity/depth-parity-baseline.json','project-memory/parity/richness_desktop.py','project-memory/parity/richness_web.py','project-memory/parity/settings_parity.py','project-memory/parity/gap_manifest.py','unified/src/csharp/DataCareNext/*.cs','web/apps/web/{app,components,lib}/**','web/scripts/lib/ui-descriptors.mjs'],'qualification':'Standalone measurement, not invoked by API suite. DataCareNext mode is explicit; NextDm alternate tree only if that other mode is requested.'},
 {'script':'web/scripts/check-settings-parity.mjs:25,27,83-84','inputs':['web/parity/settings-baseline.json','web/apps/api/dist/modules/settings/settingsInventory.js','web/apps/api/dist/modules/settings/settingsCatalog.js'],'qualification':'Standalone dynamic dist imports. Capture actual imported dist bytes when this CLI runs; source-only hashes do not substitute.'},
 {'script':'web/scripts/check-schema-readiness.mjs:50-69','inputs':['project-memory/parity/DESKTOP-REAL-SCHEMA.json','project-memory/parity/DESKTOP-INIT-SCHEMA.json','web/parity/schema-readiness-baseline.json'],'qualification':'Standalone schema gate and live DB; not imported by API tests.'},
 {'script':'web/scripts/check-type-parity.mjs:55-61,200-218,329','inputs':['project-memory/parity/DESKTOP-REAL-SCHEMA.json','web/scripts/type-parity-baseline.json','exact process.env.MSSQL_TYPES path when supplied'],'qualification':'API typeParityInput.test.mjs uses literal synthetic schema/dump text; guarded CLI does not execute on import. For a CLI run record unset MSSQL_TYPES or hash the supplied exact path (even outside repository), not a guessed default.'},
 {'script':'web/scripts/check-doc-references.mjs:40,72-89,109-141','inputs':['web/docs/**/*.md','all resolved citation candidates under web and repository using PREFIXES; include preceding absent alternatives if lookup precedence matters'],'qualification':'Standalone documentation gate. Current1883 does not include every docs/parity-evidence file. Do not call that gate current-source-qualified from API coverage.'},
 {'script':'web/scripts/check-completion-register.mjs:70,112,144','inputs':['web/docs/COMPLETION-REGISTER.json','every non-null item.evidence resolved relative to web'],'qualification':'Separate from API completionRegister test, which checks webSurface page existence and does not read evidence documents.'},
 {'script':'web/scripts/lib/release-candidate-identity.mjs:167-185; web/scripts/lib/release-template-bundle-identity.mjs:391-403','inputs':['web/pnpm-lock.yaml','candidate Git commit/tree and full selected schema/template blob membership','exact worktree selected files'],'qualification':'API tests use literal virtual trees or test-created temp files, with injected Git. Standalone release CLI requires actual Git/worktree identities.'},
 {'script':'web/scripts/release-certify.mjs:260-265','inputs':['every RELEASE_GATES evidence.path for gates actually run, including web/test-results/parity-real-stack/result.json'],'qualification':'API releaseCertification only reads G5/report/restore retained files plus listed producer/workflow source; other in-test artefacts are supplied objects. Do not infer API reads all release outputs.'}
]
save('verification-only-inputs.json',{'kind':'conditional-standalone-cli-inputs/v1','entries':verify,'notDirectApiInputs':['web/deploy/backup.sh','project-memory/catalogs/realdb-schema-full.json (reportContract comment only; no read in that test)','unified/src/csharp_nextdm/DataCareNext (not selected by the current check-depth DataCareNext invocation)']})
refs=set([BASE])
for g in extra:
 for p in g['paths']:
  if p['present']:refs.add(p['path'])
for m in membership:
 refs.update(p['path'] for p in m['paths'])
refs.update(p['path'] for p in fs_tests)
refs.update(['web/apps/api/src/modules/ops/releaseCertification.ts','web/apps/api/test/typeParityInput.test.mjs','web/apps/api/test/releaseCandidateIdentity.test.mjs','web/apps/api/test/releaseCandidateExpectedIdentity.test.mjs','web/apps/api/test/releaseTemplateBundleIdentity.test.mjs','web/apps/api/test/security.test.ts','web/apps/api/test/metrics.test.ts','web/apps/api/test/globalSetup.ts','web/apps/api/src/modules/forms/formLayoutEngine.ts','web/apps/api/src/modules/reports/reportEngine.ts','web/apps/api/src/modules/reports/render.ts'])
refs.update(str(p.relative_to(ROOT)) for p in (ROOT/'web/scripts').rglob('*') if p.is_file() and p.suffix in ['.mjs','.js','.py','.swift'])
refs.update('project-memory/parity/'+n for n in ['richness_desktop.py','richness_web.py','settings_parity.py','gap_manifest.py'])
client='web/node_modules/.pnpm/@prisma+client@6.19.3_prisma@6.19.3_typescript@5.9.3__typescript@5.9.3/node_modules/.prisma/client/index.js'
refs.add(client)
save('review-inputs.json',{'kind':'reviewed-local-source-identities/v1','files':[ref(n) for n in sorted(refs)],'secretContentsExcluded':True})
