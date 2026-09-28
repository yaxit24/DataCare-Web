import pathlib,hashlib,json,subprocess,datetime
p=pathlib.Path('/tmp/datacare-round15-effect-context'); cwd=p/'web/packages/core'
files=[q for q in cwd.rglob('*') if q.is_file() and q.suffix in ['.ts','.json']]
inputs=[{'path':str(q.relative_to(p)),'sha256':hashlib.sha256(q.read_bytes()).hexdigest()} for q in files]
(p/'focused-final.inputs.json').write_text(json.dumps({'inputs':inputs},indent=2)+'\n')
commands=[('focused-final',['/Users/yakshitsavaliya/Desktop/imodule-extracted/web/packages/core/node_modules/.bin/vitest','run','--config','vitest.config.ts']),('types-final',['/Users/yakshitsavaliya/Desktop/imodule-extracted/web/node_modules/.bin/tsc','--noEmit','--strict','--noUncheckedIndexedAccess','--isolatedModules','--skipLibCheck','--target','ES2022','--module','ESNext','--moduleResolution','Bundler','--types','node','src/saleReturnEffectContext.ts','src/savedSaleReturnClock.ts','test/saleReturnEffectContext.test.ts'])]
runs=[]
for label,argv in commands:
 start=datetime.datetime.now(datetime.timezone.utc).isoformat()
 with (p/(label+'.txt')).open('w') as log:r=subprocess.run(argv,cwd=cwd,stdout=log,stderr=subprocess.STDOUT)
 runs.append({'label':label,'argv':argv,'cwd':str(cwd),'startedAtUtc':start,'finishedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'exitCode':r.returncode,'logSha256':hashlib.sha256((p/(label+'.txt')).read_bytes()).hexdigest()})
 print(label,r.returncode,(p/(label+'.txt')).read_text()[-3000:])
changed=[i['path'] for i in inputs if hashlib.sha256((p/i['path']).read_bytes()).hexdigest()!=i['sha256']]
(p/'focused-final.run.json').write_text(json.dumps({'runs':runs,'changedInputs':changed,'inputCount':len(inputs),'limits':'Staged new pure qualifier/test + unchanged copied clock only. No active source, DB, browser or global build.'},indent=2)+'\n')
