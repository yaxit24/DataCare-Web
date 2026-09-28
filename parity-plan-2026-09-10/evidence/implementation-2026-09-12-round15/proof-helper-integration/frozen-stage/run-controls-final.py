from pathlib import Path
import ast,datetime,hashlib,json,subprocess,os
p=Path('/tmp/datacare-round15-proof-helpers');s=p/'staged/parity-plan-2026-09-10'
files=sorted(x for x in s.iterdir() if x.is_file());inputs={str(x.relative_to(p)):hashlib.sha256(x.read_bytes()).hexdigest() for x in files};(p/'controls-final.inputs.json').write_text(json.dumps(inputs,indent=2)+'\n')
syntax=[]
for x in files:
 if x.suffix=='.py':compile(x.read_text(),str(x),'exec');syntax.append(str(x.relative_to(p)))
(p/'syntax-final.json').write_text(json.dumps({'status':'passed','files':syntax,'execution':'compile() syntax only, no module execution or bytecode write'},indent=2)+'\n')
start=datetime.datetime.now(datetime.timezone.utc).isoformat();argv=['python3','-B','test_checkpoint_recipe_round15.py']
with (p/'recipe-controls-final.txt').open('w') as log:r=subprocess.run(argv,cwd=s,stdout=log,stderr=subprocess.STDOUT,env={**os.environ,'PYTHONDONTWRITEBYTECODE':'1'})
changes=[name for name,sha in inputs.items() if hashlib.sha256((p/name).read_bytes()).hexdigest()!=sha]
(p/'controls-final.run.json').write_text(json.dumps({'argv':argv,'cwd':str(s),'startedAtUtc':start,'finishedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'exitCode':r.returncode,'log':'recipe-controls-final.txt','logSha256':hashlib.sha256((p/'recipe-controls-final.txt').read_bytes()).hexdigest(),'inputManifest':'controls-final.inputs.json','inputManifestSha256':hashlib.sha256((p/'controls-final.inputs.json').read_bytes()).hexdigest(),'changedInputs':changes,'limits':'20 synthetic recipe controls only; core0 placeholder is synthetic data, not execution evidence. No active validator/capture/application/DB/browser/compiler run.'},indent=2)+'\n')
print((p/'recipe-controls-final.txt').read_text());print('changedInputs',changes)
