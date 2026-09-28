from pathlib import Path
from decimal import Decimal
import json,re,hashlib
root=Path('/tmp/datacare-return-bar-companion-review');stage=Path('/tmp/datacare-return-bar-companion-staged')
a=json.loads((root/'source-assignment-comparison.json').read_text());fpath=stage/'web/packages/core/test/fixtures/saleReturnNBarCompanions.independent.json';fixture=json.loads(fpath.read_text())
def val(s):
 x=Decimal(s.strip() or '0');return '0' if x==0 else format(x,'f').rstrip('0').rstrip('.') if '.' in format(x,'f') else format(x,'f')
ctx={'DC_Main.MCo_code':'CO_CODE','DC_Main.MLc_code':'LC_CODE','DC_Main.MCo_year':'CO_YEAR','DC_Main.MCo_Book':'CO_BOOK','tVchNo.Text':'VCH_NO','tHdVchNo.Text':'HD_VCH_NO','tAcCode.Text':'AC_CODE','FormBookSname':'VCH_TYPE','FormBookInOut':'INOUT_TYPE','FormMainBook':'BOOK_NAME','tEmpCode.Text':'EMP_CODE','tVchDesc.Text':'VCH_DESC','MainUser':'MAIN_USER'}
def project(c,phase):
 v=phase['visible'];tot=phase['incomingTotals'];pred={'barData':Decimal(val(tot['28']))!=0 or sum(Decimal(val(tot[k])) for k in ['9','12','27'])!=0,'barDetl':sum(Decimal(val(v[k])) for k in ['9','12','38'])!=0 and v['2']!=''}
 out={'predicates':pred}
 for table in ['barData','barDetl']:
  if not pred[table]:out[table]=None;continue
  fields={}
  for item in a['tables'][table]['assignments']:
   key=item['field'];e=item['expression'];m=re.fullmatch(r'Conversion.Val\(val2\[DC_Main.i, (\d+)\]\)',e);t=re.fullmatch(r'val2\[DC_Main.i, (\d+)\]',e)
   if key in ['VCH_DATE','STK_DATE']:fields[key]=c[key] # Target representation is externally supplied, not independently qualified here.
   elif key=='VCH_TIME':fields[key]=c['VCH_TIME']
   elif key=='TAG_NO':fields[key]=v['2'] or 'N'
   elif key=='DATA_TYPE':fields[key]=v['70'] or 'A'
   elif m:fields[key]=val(v[m.group(1)])
   elif t:fields[key]=v[t.group(1)]
   elif e in ctx:fields[key]=c[ctx[e]]
   elif e=='0':fields[key]='0'
   elif e.startswith('"') and e.endswith('"'):fields[key]=e[1:-1]
   else:raise RuntimeError((key,e))
  out[table]=fields
 return out
results=[]
for case in fixture['cases']:
 for phase in ['before','after']:
  got=project(case['input']['context']['values'],case['input'][phase]);expected=case['expected'][phase]
  assert got==expected,(case['id'],phase,{k:(got[k],expected[k]) for k in got if got[k]!=expected[k]})
  results.append({'id':case['id'],'phase':phase,'allPredicatesAndCompleteTargetsAgree':True})
(root/'independent-literal-comparison.json').write_text(json.dumps({'fixtureSha256':hashlib.sha256(fpath.read_bytes()).hexdigest(),'comparison':'Independent read of primary assignment expressions and exact small-number literals; no new TypeScript mapper was read/executed; qualified context representations taken as supplied, not established by comparison. Status/diagnostic precedence not inferred from this expression check.','phases':results},indent=2)+'\n')
print('22 cases /44 phases: both predicates and all complete target maps agree')
