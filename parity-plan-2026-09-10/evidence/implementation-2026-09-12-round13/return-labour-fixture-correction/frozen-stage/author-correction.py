from pathlib import Path
import hashlib,json,difflib,copy
S=Path('/tmp/datacare-return-labour-preview-api-correction');O=Path('/tmp/datacare-return-labour-preview-api');R=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def write(rel,text):p=S/rel;p.parent.mkdir(parents=True,exist_ok=True);p.write_text(text);return p
rel=Path('web/apps/api/test/fixtures/saleReturnLabourReplay.independent.json')
p=O/rel;assert sha(p)=='22cdfb8963c39dd50e3c41d1277d5d7549f3a65fb507598e1d8013deadc258bc'
a=json.loads(p.read_text());b=copy.deepcopy(a)
paths=[['expected','initial','visible','9']]+[['expected','prefixes',n,'preview','visible','9'] for n in ['bb','bb-aa','bb-other','bb-other-aa','same-aa','same-ta','fixed','zero']]
changes=[]
for parts in paths:
 x=b
 for key in parts[:-1]:x=x[key]
 assert x[parts[-1]]=='1';x[parts[-1]]='1.000'
 changes.append({'path':parts,'before':'1','after':'1.000'})
p2=write(rel,json.dumps(b,indent=2)+'\n');newhash=sha(p2)
def differences(x,y,path=[]):
 if type(x)!=type(y):return [{'path':path,'before':x,'after':y}]
 if isinstance(x,dict):
  assert x.keys()==y.keys()
  return [d for k in x for d in differences(x[k],y[k],path+[k])]
 if isinstance(x,list):
  assert len(x)==len(y)
  return [d for k in range(len(x)) for d in differences(x[k],y[k],path+[k])]
 return [] if x==y else [{'path':path,'before':x,'after':y}]
actual=differences(a,b);assert sorted(actual,key=lambda x:x['path'])==sorted(changes,key=lambda x:x['path'])
proof={'kind':'additive-postgresql-storage-shape-fixture-qualification','originalPath':str(p),'originalSha256':sha(p),'correctedPath':str(p2),'correctedSha256':newhash,'exhaustiveJsonDifferences':actual,'onlyExpectedVisiblePiecesChanged':True,'rawInputsUnchanged':a['header']==b['header'] and a['rows']==b['rows'] and a['masters']==b['masters'],'allOtherJsonValuesUnchanged':True,'source':['TR_SALE_RTN.cs:10376 direct Conversions.ToString(ITM_PCS), no Format0','schema.prisma:5888 SL_DETL_RTN.ITM_PCS numeric(12,3)','savedSaleReturn.ts:158-160 jsonb_each_text before driver conversion','saleReturnIncomingProjection.ts:273-274 validated PCS text preserved'],'qualification':'Original top-level authorship/status/sourcePins remain historical unchanged metadata of the pre-code literal fixture. This separate qualification dates and owns only these nine post-storage text corrections; all arithmetic was frozen before implementation.'}
write('fixture-diff-proof.json',json.dumps(proof,indent=2)+'\n')
rel2=Path('web/apps/api/test/saleReturnLabourReplay.test.ts');test=(O/rel2).read_text();assert test.count(sha(p))==1;write(rel2,test.replace(sha(p),newhash))
rel3=Path('web/apps/api/test/saleReturnLabourReplay.routes.db.test.ts');test=(O/rel3).read_text();assert test.count('  const completed = new Map<string, () => void>();')==1
test=test.replace('  const completed = new Map<string, () => void>();','  const completed = new Map<string, () => void>();\n  let caseAddress = 0;')
needle='      url: "/auth/login",\n';assert test.count(needle)==1
test=test.replace(needle,needle+'      // Each isolated test represents a different client; retain the real 10/minute login limiter.\n      remoteAddress: `127.0.1.${caseAddress}`,\n')
needle='  beforeEach(async () => {\n';assert test.count(needle)==1
test=test.replace(needle,needle+'    caseAddress += 1;\n')
needle='    for (const pair of [\n      null,\n';assert test.count(needle)==1
test=test.replace(needle,'    const pairs: Array<Record<string, string> | null> = [\n      null,\n')
needle='    ]) {\n      const r = await inject(\n';assert test.count(needle)==1
test=test.replace(needle,'    ];\n    for (const pair of pairs) {\n      const r = await inject(\n')
write(rel3,test)
patch=[]
for rel in [rel,rel2,rel3]:
 patch.extend(difflib.unified_diff((O/rel).read_text().splitlines(True),(S/rel).read_text().splitlines(True),fromfile='a/'+str(rel),tofile='b/'+str(rel)))
write('fixture-correction.patch',''.join(patch))
print(json.dumps({'correctedFixtureSha256':newhash,'differences':len(actual),'unitSha256':sha(S/rel2),'httpSha256':sha(S/rel3),'patchSha256':sha(S/'fixture-correction.patch')}))
