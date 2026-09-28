from pathlib import Path
import json,re,hashlib
R=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted'); O=Path('/tmp/datacare-round14-browser-retention')
def read(n):return (R/n).read_text()
def strings(n,key):
 s=read(n);m=re.search(r'\b'+re.escape(key)+r'[^=]*= Object\.freeze\(\[(.*?)\]\)',s,re.S);assert m,key
 body=m[1];out=re.findall(r"'([^'\n]*)'",body);assert re.sub(r"'[^'\n]*'",'',body).strip(' \n\r\t,')==''
 return out
release='web/apps/api/src/modules/ops/releaseCertification.ts'
runner='web/apps/web/test/parity.real-stack.mjs'
context='web/apps/web/test/session-context.journey.mjs'; life='web/apps/web/test/session-context-lifecycle.journey.mjs'
labreq='web/apps/web/test/fixtures/labour-preview-lifecycle.required.json'
baseReq='parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-labour-preview-browser/browser-required-checks.json'
base=json.loads(read(baseReq));print('baseline required keys',list(base))
s=read(runner);m=re.search(r'result\.journeys = \[(.*?)\]\.map',s,re.S);assert m
mapping=dict(re.findall(r"\['([^']+)', result\.([A-Za-z0-9]+)\]",m[1]));ids=strings(release,'REQUIRED_REAL_BROWSER_JOURNEY_IDS');assert list(mapping)==ids and len(ids)==17
sources=[release,runner,'web/apps/web/test/parity-real-stack-evidence.mjs',context,life,'web/apps/web/test/session-context.real-stack.additive.mjs','web/apps/web/test/session-context-response-observation.mjs','web/apps/web/test/labour-preview-lifecycle.journey.mjs','web/apps/web/test/labour-preview-lifecycle.real-stack.mjs','web/apps/web/test/sales-return-labour-replay.journey.mjs',labreq,baseReq,'web/apps/api/test/fixtures/saleReturnLabourReplay.independent.json']
contracts={'kind':'round14-three-browser-retention-contract/v1','baselineIds':ids,'baselineDetailKeys':mapping,'baselineLabourChecks':base['requiredChecks'] if 'requiredChecks' in base else base['checks'],'contextChecks':strings(context,'sessionContextRequiredChecks'),'contextLifecycleChecks':strings(life,'sessionContextLifecycleRequiredChecks'),'labourLifecycleChecks':json.loads(read(labreq))['requiredChecks'],'fixtureSha256':hashlib.sha256((R/sources[-1]).read_bytes()).hexdigest(),'sources':[{'path':n,'sha256':hashlib.sha256((R/n).read_bytes()).hexdigest()} for n in sources]}
assert len(contracts['baselineLabourChecks'])==12 and len(contracts['contextChecks'])==12 and len(contracts['contextLifecycleChecks'])==2 and len(contracts['labourLifecycleChecks'])==5
(O/'contract.json').write_text(json.dumps(contracts,indent=2)+'\n')
