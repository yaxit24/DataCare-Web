from pathlib import Path
import datetime,hashlib,json,subprocess
p=Path('/tmp/datacare-round15-save-guards'); root=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
paths=['web/packages/core/src/saleReturnSaveGuards.ts','web/packages/core/test/saleReturnSaveGuards.test.ts','web/packages/core/test/fixtures/saleReturnSaveGuards.independent.json','web/packages/core/test/fixtures/saleReturnSaveGuards.fine-amendment.json','web/vitest.config.mts','web/package.json','web/packages/core/package.json']
sha=lambda x:hashlib.sha256(x.read_bytes()).hexdigest()
capture=lambda:{x:sha(p/x) for x in paths}
before=capture(); (p/'final-inputs.json').write_text(json.dumps({'capturedAt':datetime.datetime.now(datetime.timezone.utc).isoformat(),'files':before},indent=2)+'\n')
runs=[]
for label,command in [('focused-final',['node',str(root/'web/node_modules/vitest/vitest.mjs'),'run','--config','vitest.config.mts']),('types-final',[str(root/'web/node_modules/.bin/tsc'),'--noEmit','--strict','--noUncheckedIndexedAccess','--isolatedModules','--target','ES2022','--module','NodeNext','--moduleResolution','NodeNext','--skipLibCheck','--esModuleInterop','packages/core/test/saleReturnSaveGuards.test.ts'])]:
 log=p/(label+'.txt');start=datetime.datetime.now(datetime.timezone.utc).isoformat()
 with log.open('w') as f:r=subprocess.run(command,cwd=p/'web',stdout=f,stderr=subprocess.STDOUT)
 runs.append({'label':label,'command':command,'cwd':str(p/'web'),'startedAt':start,'finishedAt':datetime.datetime.now(datetime.timezone.utc).isoformat(),'exitCode':r.returncode,'log':log.name,'logSha256':sha(log)})
 if r.returncode:break
after=capture();result={'runs':runs,'inputs':before,'afterInputs':after,'unchanged':before==after,'limits':'Staged pure core tests and strict test compilation only. No app, DB, routes, writer or authority integration.'}
(p/'final-focused.run.json').write_text(json.dumps(result,indent=2)+'\n'); print(json.dumps({'runs':[(r['label'],r['exitCode']) for r in runs],'unchanged':before==after}))
raise SystemExit(0 if len(runs)==2 and all(r['exitCode']==0 for r in runs) and before==after else 1)
