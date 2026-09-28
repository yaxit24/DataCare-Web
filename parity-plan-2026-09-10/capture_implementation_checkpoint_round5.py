from pathlib import Path
import datetime,hashlib,json,re,subprocess,sys
root=Path(__file__).resolve().parent.parent
plan=root/'parity-plan-2026-09-10'
evidence=plan/'evidence/implementation-2026-09-11-round5'
web=root/'web'
browser_dir=web/sys.argv[1]
browser_log=sys.argv[2]
web_log=sys.argv[3]
build_log=sys.argv[4]
lint_log=sys.argv[5]
sha=lambda p: hashlib.sha256(p.read_bytes()).hexdigest()
identity=lambda p: {'path':str(p.relative_to(root)),'sha256':sha(p)}
prior_path=plan/'21-implementation-checkpoint-round4.json'
assert sha(prior_path)=='d17e66599d6bd5c20dd935a98c17cdae46afa260a1cebadb5569b3f7b33e01ac'
prior=json.loads(prior_path.read_text())
baseline_path=plan/'evidence/review-2026-09-11/reviewed-source-hashes.json'
baseline=json.loads(baseline_path.read_text())
assert json.loads((browser_dir/'result.json').read_text())['status']=='passed'
api_text=(evidence/'api-full-complete.txt').read_text()
api_files = re.search(r'Test Files\s+(\d+) passed \((\d+)\)',api_text)
api_tests = re.search(r'Tests\s+(\d+) passed \((\d+)\)',api_text)
assert api_files and api_tests and api_files[1]==api_files[2] and api_tests[1]==api_tests[2]
assert 'skipped' not in api_text
assert 'PARITY_REAL_STACK_PASSED' in (evidence/browser_log).read_text()
paths={root/r['path'] for r in prior['sourceFiles']} | {root/r['path'] for r in baseline['files']}
prefixes=['web/apps/api/src','web/apps/api/test','web/apps/web/app','web/apps/web/components','web/apps/web/lib','web/apps/web/test','web/packages/core/src','web/packages/core/test','web/packages/db/prisma','web/scripts']
for prefix in prefixes:
 paths.update(p for p in (root/prefix).rglob('*') if p.is_file() and p.suffix in {'.ts','.tsx','.js','.mjs','.py','.prisma','.sql'} and not any(x in p.parts for x in ['node_modules','__pycache__']))
paths.update(plan/name for name in ['validate_plan.py','validate_current_review.py','build_execution_addendum.py','execution-addendum-intro.md','capture_implementation_checkpoint_round5.py'])
paths.update(root/'unified/src/csharp/DataCareNext'/name for name in ['MS_DESIGN_BOOK.cs','TR_MFG_WITH_LOT.cs','MDI_FORM.cs','MS_UPDATE.cs','DC_Main.cs','Ac_Image.cs','MS_OPNCOMP.cs'])
paths.update(p for p in (web/'apps/api/report-specs').rglob('*.json'))
paths.add(web/'pnpm-lock.yaml')
for pattern in ['package.json','apps/*/package.json','packages/*/package.json']:
 paths.update(web.glob(pattern))
api_inputs=json.loads((evidence/'api-input-snapshot-complete.json').read_text())['files']
assert len(api_inputs)>491
for row in api_inputs: assert sha(root/row['path'])==row['sha256'],row['path']
paths.update(root/row['path'] for row in api_inputs)
scoped_api=json.loads((web/'docs/parity-evidence/X05-X25-image-cas-api-run-round5-2026-09-11.json').read_text())
for row in scoped_api['inputs']:
 p=(web/row['path']).resolve()
 assert p.is_relative_to(root) and sha(p)==row['sha256'],row['path']
 paths.add(p)
paths.add(root/'DataCareNext.exe')
paths.update(root/'unified/src'/variant/'DataCareNext'/name for variant in ['csharp','csharp_nextdm'] for name in ['MS_HELP.cs','TR_SALE_ORD.cs','MS_OPNCOMP.cs','UT_SETTING.cs','TR_SALE_RTN.cs','TR_SALE_RTN_UAE.cs'])
source_files=[identity(p) for p in sorted(paths)]
verification=[]
def run(name,command,status,log,details=None,exit_code=None):
 p=evidence/log
 assert p.is_file() and p.stat().st_size>0,log
 verification.append({'name':name,'command':command,'status':status,'exitCode':exit_code if exit_code is not None else (0 if status=='passed' else 1),'log':str(p.relative_to(root)),'logSha256':sha(p),'details':details or {}})
run('Final full API regression','pnpm test:parity:api','passed','api-full-complete.txt',{'files':int(api_files[1]),'tests':int(api_tests[1]),'skipped':0})
run('Final real browser integration','PARITY_ARTIFACT_DIR='+str(browser_dir.relative_to(web))+' pnpm test:parity:browser','passed',browser_log,{'mockedRequests':0,'result':str((browser_dir/'result.json').relative_to(root)),'boundary':'Synthetic isolated real-stack journeys; no full desktop or provider acceptance.'})
run('Frontend tests','pnpm --filter @datacare/web test','passed',web_log)
run('Core tests','pnpm --filter @datacare/core test','passed','core-tests.txt',{'limits':'See pinned core log for exact counts.'})
run('Production build','API_ORIGIN=http://127.0.0.1:4410 pnpm build','passed',build_log,{'targets':7})
run('Workspace lint and application types','pnpm lint','passed',lint_log,{'limits':'Configured ESLint covers its registered surfaces; API correctness also uses compiler and full regression. Targeted API ESLint exploratory run was ignored and is not credited.'})
run('Strict API test types','pnpm typecheck:tests','passed','test-types.txt')
run('Legacy mocked browser compatibility','pnpm test:browser','passed','browser-smoke-complete.txt',{'boundary':'Compatibility regression only; not real-stack parity evidence.'})
run('Static measurement fixtures','node --test scripts/test/ui-descriptors.test.mjs scripts/test/request-field-trace.test.mjs','passed','scanner-tests.txt',{'tests':31,'legacyBudgetsChanged':False})
run('Completion register','pnpm register:check','passed','register.txt',{'menus':198,'implementedUnverified':198,'accepted':0})
run('Documentation references','pnpm docs:refs','passed','document-references-frozen.txt')
run('Checkpoint chain positive and negative controls','python3 parity-plan-2026-09-10/validate_plan.py --self-test-checkpoint-chain','passed','checkpoint-chain-tests.txt',{'negativeControls':7})
run('Kernel adoption gate','node scripts/check-kernel-conformance.mjs','failed','kernel-gate.txt',{'roundingHelpers':127,'ceiling':108,'newRegression':False,'disposition':'Existing unresolved rounding/source classification debt; no ceiling raised.'})
run('Depth gate','node scripts/check-depth.mjs','failed','depth-gate.txt',{'unreachableFields':102,'ceiling':96,'newRegression':False,'disposition':'Existing measured internal server-only field requireDesignSelection; explicit diagnosis retained, no frontend control added and no ceiling raised. Existing unreachable-field debt remains.'})
run('Dead-cell detector','node scripts/check-dead-cells.mjs','failed','dead-cells.txt',{'checked':708,'actualRegistryPages':21,'mappings':23,'findings':33,'boundary':'Tightened callee tracing exposes unresolved Sale Return controls previously credited from unrelated exports. Four derived Sales/Quotation controls were corrected. No budget raised; static consumption is not full runtime parity.'})
artifacts={p for p in evidence.rglob('*') if p.is_file() and p.name not in {'document-validation.json','document-validation-complete.txt'}}
artifacts.update(p for d in (web/'test-results').glob('parity-real-stack-round5*') for p in d.rglob('*') if p.is_file())
artifacts.update(p for p in (web/'docs/parity-evidence').glob('*round5*') if p.is_file())
artifacts.update(plan/name for name in ['02-implementation-plan.md','07-work-items.json','12-execution-addendum.md','13-execution-backlog.json','22-implementation-progress-round5.md','README.md'])
previous_by_path={r['path']:r['sha256'] for r in prior['sourceFiles']}
checkpoint={
 'kind':'datacare.parity-implementation-checkpoint/1.0',
 'capturedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),
 'displayTimezone':'Asia/Kolkata','status':'partial-implementation',
 'gitHead':subprocess.check_output(['git','rev-parse','HEAD'],cwd=root,text=True).strip(),
 'workingTree':'Existing dirty working tree preserved; disposable Docker test database only; no commit, deployment or release certification.',
 'baseReviewSourceManifestSha256':sha(baseline_path),
 'priorCheckpoint':prior_path.name,'priorCheckpointSha256':sha(prior_path),
 'progressDocument':'22-implementation-progress-round5.md',
 'wholeProductImplementationPercentage':None,'verifiedMenus':0,'acceptedExecutionCards':[],'acceptedOriginalPackages':[],
 'implementedSlices':['X05/X25 generic Design/tag/master image state tokens and atomic stale-client rejection','X05/X25 original repair image state, revisions and source-book readers','X05/X25 shared UI scope/chooser/camera guards and explicit reload/retry','X05 repair receipt saved image serial hydration and post-save authoritative read'],
 'sourceFiles':source_files,
 'changedPriorSourceFiles':[{'path':r['path'],'beforeSha256':previous_by_path[r['path']],'afterSha256':r['sha256']} for r in source_files if r['path'] in previous_by_path and previous_by_path[r['path']]!=r['sha256']],
 'verification':verification,'artifactFiles':[identity(p) for p in sorted(artifacts)],
 'requiredOpenAcceptance':['All remaining requirements of34 execution cards and83 packages','Independent executable desktop/schema/history evidence and acceptance of documented source differences','Full E Credit Note writes/provider mutation lifecycle; full order settlement/delivery/conversion/reversal','Explicit lot manufacturing and every remaining contained tag/other workflow','Historical image provenance, inherited generic image identity/rights mapping, actual camera/printer behavior; remaining79 contained templates and exact Crystal output','Remaining rounding/depth/dead-cell gates (127 helpers,102 unreachable fields,33 unresolved Sale Return fields) and complete runtime field tracing, historical timestamp recovery and migration continuation','Operational recovery, devices, supported variants, full-product business acceptance and release certification'],
 'limits':'No functional-parity percentage is inferred from code/test/menu/static-field counts. Focused synthetic checks overlap the authoritative full suite. Failed exploratory runs are retained with corrections recorded in the progress document; red release gates remain red. No whole execution-card, package, menu, desktop, business, provider, device or production acceptance is claimed.'
}
output=plan/'23-implementation-checkpoint-round5.json'
assert not output.exists(),'Refusing to overwrite an existing checkpoint'
output.write_text(json.dumps(checkpoint,indent=2,ensure_ascii=False)+'\n')
print(json.dumps({'checkpoint':str(output),'sources':len(source_files),'artifacts':len(artifacts),'verification':len(verification)},indent=2))
