from pathlib import Path
import copy,hashlib,json
p=Path('/tmp/datacare-round15-save-guards')
f=p/'web/packages/core/test/fixtures/saleReturnSaveGuards.independent.json'
original=json.loads(f.read_text()); base=original['cases'][0]
amended=copy.deepcopy(next(c for c in original['cases'] if c['id']=='G41'))
amended['expected']['status']='ready'; amended['expected']['diagnostic']=None
amended['expected']['checks'][-1]['outcome']='passed'
new=[]
for id,credit,net,fine,status,code in [('F01','110.00','110.00','10.000','ready',None),('F02','111.00','111.00','10.000','ready',None),('F03','110.00','110.49','10.000','ready',None),('F04','110.00','110.00','-110.000','unsupported','fine-branch-unqualified'),('F05','110.00','110.00','-1.000','ready',None),('F06','0.00','0.00','0.000','source-rejected','item-value-required'),('F07','0.00','0.00','10.000','unsupported','fine-branch-unqualified')]:
 c=copy.deepcopy(base);c['id']=id;c['description']='Registration-independent amount predicate amendment; exact source branch sums, no registration authority.'
 values=c['input']['observations']
 values['bill']['value']['nAcCrAmt']=credit
 values['saveFold']['value'].update(incomingNet38=net,incomingFine18=fine)
 for b in ['bill','beforeBill']:
  for row in [1,3,8]:values[b]['value']['matrix'][row][3]=credit
 c['expected']['observation']=copy.deepcopy(c['input']); c['expected']['status']=status
 if status!='ready':
  c['expected']['checks']=c['expected']['checks'][:-1]; c['expected']['checks'][-1]['outcome']=status
  c['expected']['diagnostic']={'code':code,'guard':'amount-nonzero'}
 new.append(c)
amendment={'kind':'saved-return-save-guard-fine-amendment-v1','originalFixtureSha256':hashlib.sha256(f.read_bytes()).hexdigest(),'source':'TR_SALE_RTN12386-12403: candidate sums are credit+debit, or credit+debit+incomingFine18. Both nonzero proves this rejection false independently of registration.','qualification':'Guard result only; not financial fine-ledger admission or coherent whole-poststate acceptance. Negative fine F05 deliberately tests this predicate, not a released negative-weight writer.','replacements':[{'caseId':'G41','oldExpected':next(c['expected'] for c in original['cases'] if c['id']=='G41'),'newExpected':amended['expected']}],'additionalCases':new}
out=p/'web/packages/core/test/fixtures/saleReturnSaveGuards.fine-amendment.json';out.write_text(json.dumps(amendment,indent=2)+'\n')
freeze={'status':'literal-amendment-frozen-before-code-change','originalFixtureSha256':amendment['originalFixtureSha256'],'amendmentSha256':hashlib.sha256(out.read_bytes()).hexdigest(),'beforeSourceSha256':hashlib.sha256((p/'history/saleReturnSaveGuards.pre-fine-amendment.ts').read_bytes()).hexdigest(),'sourceChanged':False,'caseCount':7,'replacementCount':1}
(p/'fine-amendment-freeze.json').write_text(json.dumps(freeze,indent=2)+'\n');print(json.dumps(freeze,indent=2))
