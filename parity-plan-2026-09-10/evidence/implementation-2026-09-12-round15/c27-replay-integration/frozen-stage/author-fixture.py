"""Independent full literal phases: no TS reducer import or execution."""
from pathlib import Path
from decimal import Decimal, ROUND_HALF_UP, ROUND_HALF_EVEN
import copy, hashlib, json, re
ROOT=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
HERE=Path(__file__).resolve().parent
schema=ROOT/'web/packages/db/prisma/schema.prisma'
ancestor=ROOT/'web/packages/core/test/fixtures/saleReturnIncomingSave.independent.json'
source=ROOT/'extracted_code/DataCareNext/DataCareNext/TR_SALE_RTN.cs'
base=json.loads(ancestor.read_text())['cases'][0]['input']
def fields(model):
    block=schema.read_text().split('model '+model+' {',1)[1].split('\n}',1)[0]
    return {m[1]:m[2] for line in block.splitlines() if (m:=re.match(r'\s+(\w+)\s+(String|Decimal|Float|DateTime)\??\s',line)) and m[1]!='tenantId'}
line={k:None for k in fields('SL_DETL_RTN')}
line.update(base['raw']); line.pop('tenant_id')
line.update(OLD_SRNO='1',VCH_TIME='2024-07-10T12:13:14',BOOK_NAME='SALES RETURNE',EMP_CODE='E1')
header={k:('0.00' if t=='Decimal' else '0' if t=='Float' else '' if t=='String' else None) for k,t in fields('SL_DATA').items()}
header.update(CO_CODE='01',LC_CODE='01',CO_YEAR='2024-2025',CO_BOOK='R11',VCH_NO='00017',VCH_DATE='2024-07-10',VCH_TIME='2024-07-10T12:13:14',HD_VCH_NO='HD-17',AC_CODE='CUST',AC_NAME='Current customer',EMP_CODE='E1',MAIN_USER='original user',USER_UPDATE='N',USER_DELETE='N',AC_GST_TYPE='N',TAX_CODE='01',RTN_NET_AMT='110',RTN_TOT_AMT='110',RTN_BILL_OS='110',IRN_NO=None,UNOWNED_NULL=None,UNOWNED_TEXT='  preserved\nપાઠ  ')
visible=copy.deepcopy(base['visible']);visible.update({'51':'1','53':'P1','55':'A','57':'E'})
caches={str(k):visible[str(v)] for k,v in {45:10,46:12,47:16,48:17,49:19,58:23,66:21,67:37}.items()}
labels={'taxName':'Zero split tax','bankAccountName':None,'cardAccountName':None}
opening={'status':'unavailable','reason':'Customer balance requires a resolved ledger mode.'}
closing={**opening,'amount':None,'label':None,'color':'unknown'}
policy={'saleAmountType':'N','labourRoundingDecimals':2,'labourIncludesGhat':False,'generateLabourRate':False,'fineColumnWidth':100}
context={'taxRoundingDecimals':2,'editOpen':False,'upDown':False,'openingBalance':opening}
inp={'observationIdentity':'b'*64,'rowIdentity':'a'*64,'rawHeader':header,'rawIncoming':line,'itemMasters':[{'CO_CODE':'01','IT_CODE':'GOLD','IT_NAME':'Current master name','RATE_TYPE':'N','IT_TYPE':'G'}],'labels':labels,'rowPolicy':policy,'taxRoundingDecimals':2,'c27ColumnWidth':100,'events':[]}
matrix=[['','','','Payment    ','Received    ',''],['Net Amt : ','','','','',''],['Sale Tax : ','Zero split tax','0.00','0.00','','01'],['Total Amt : ','','','110.00','0.00',''],['Cheque Amt : ','','','0.00','0.00',''],['Card Amt : ','','','0.00','0.00',''],['Cash Amt : ','','','0.00','0.00',''],['Kasar Amt : ','','','0.00','0.00',''],['Os Amt : ','','','110.00','0.00','']]
row={'rowIdentity':'a'*64,'raw':line,'visible':visible,'caches':caches,'journal':[]}
blank={'cells':{str(i):'' for i in range(71)},'totCrFine':'0','prOthAmtLess':'0'}
loaded={'row':copy.deepcopy(row),'incomingTotals':copy.deepcopy(blank),'bill':{'matrix':copy.deepcopy(matrix),'oldNetAmt':'110','oldTaxPrc':'0','outgoingRounded':'0.00','incomingRounded':'110.00','closing':copy.deepcopy(closing)}}
def fixed(x,places): return format(Decimal(x).quantize(Decimal(1).scaleb(-places),rounding=ROUND_HALF_UP),'f')
def totals(v):
    x=copy.deepcopy(blank);x['cells']['5']='Total :'
    for c,p in [(9,0),(10,3),(11,3),(12,3),(15,3),(18,3),(20,2),(24,2),(27,2),(42,3),(28,2),(36,2),(38,2),(35,2)]:x['cells'][str(c)]=fixed(v[str(c)] or '0',p)
    return x
opened=copy.deepcopy(loaded);opened['incomingTotals']=totals(visible)
opened['bill']['matrix'][1][3]='110.00'
for i in range(2,9):opened['bill']['matrix'][i][4]=''
def next_phase(prior,text):
    x=copy.deepcopy(prior);v=x['row']['visible'];other=Decimal(fixed(text.strip() or '0',2));net=Decimal('110')+other
    v['27']=fixed(other,2);v['36']=fixed(net,2);v['38']=fixed(net,2)
    event={'kind':'leaveCell','rowIdentity':'a'*64,'column':27,'text':text,'context':{'currentRow':1,'clearing':False,'editorVisible':True,'committedColumnWidth':100}}
    x['row']['journal'].append({'event':event,'calculated':True,'policy':copy.deepcopy(policy)})
    x['incomingTotals']=totals(v)
    b=x['bill'];m=b['matrix'];rnd=net.quantize(Decimal(1),rounding=ROUND_HALF_EVEN);payment=max(rnd,Decimal(0));received=max(-rnd,Decimal(0))
    m[1][3]=fixed(payment,2) if rnd>=0 else '';m[1][4]=fixed(received,2) if rnd<0 else ''
    b['incomingRounded']=fixed(rnd,2);b['outgoingRounded']='0.00'
    if payment!=Decimal(b['oldNetAmt']):b['oldNetAmt']=str(int(payment));b['oldTaxPrc']='0';m[2][3]='0.00'
    m[3][3]=fixed(payment,2);m[3][4]=fixed(received,2);m[8][3]=fixed(payment,2);m[8][4]=fixed(received,2)
    for i in range(2,9):m[i][4 if rnd>=0 else 3]=''
    return x
cases=[]
for cid,texts,status,code in [
 ('C01',[],'ready',None),('C02',['1'],'ready',None),('C03',['0'],'ready',None),('C04',['1','0'],'ready',None),('C05',['1','2'],'ready',None),
 ('C06',['-11'],'unsupported','bar-header-membership'),('C07',['-110'],'unsupported','nonpositive-return'),('C08',['-120'],'unsupported','row-save-projection'),('C09',['-200'],'unsupported','row-save-projection'),
 ('C10',['0.49'],'ready',None),('C11',['0.50'],'ready',None),('C12',['1.50'],'ready',None),('C13',[' 1 '],'ready',None),('C14',['1.005'],'ready',None),('C15',['-109.51'],'unsupported','nonpositive-return'),('C16',['1','oops','2'],'unsupported','event-calculation')]:
    item=copy.deepcopy(inp);item['events']=texts;prefix=[];state=copy.deepcopy(opened)
    for t in texts:
        if t=='oops':break
        state=next_phase(state,t);prefix.append(copy.deepcopy(state))
    patches={}
    for field,c in [('OTH_AMT','27'),('TOT_AMT','36'),('NET_AMT','38')]:
        if Decimal(line[field])!=Decimal(state['row']['visible'][c]):patches[field]=state['row']['visible'][c]
    hp={}
    for field,value in [('RTN_NET_AMT',state['bill']['incomingRounded']),('RTN_TOT_AMT',state['bill']['matrix'][3][3] or '0'),('RTN_BILL_OS',state['bill']['matrix'][8][3] or '0')]:
        if Decimal(header[field])!=Decimal(value):hp[field]=str(Decimal(value).normalize())
    cases.append({'id':cid,'input':item,'expected':{'status':status,'code':code,'loaded':loaded,'opened':opened,'prefixes':prefix,'final':state,'linePatch':patches if status=='ready' else None,'headerPatch':hp if status=='ready' else None}})
fixture={'version':'saved-other-amount-replay-independent-v1','authorship':'Authored before implementation. Complete literal phases use manually specified source maps and Decimal arithmetic; no product code was imported/executed to make expectations. Complete current-schema raw fixture values are explicit author choices, not fallback data for a real company. Guard/master/effect authority is outside this calculation fixture.','sourceInputs':[{'path':str(p.relative_to(ROOT)),'sha256':hashlib.sha256(p.read_bytes()).hexdigest()} for p in [source,schema,ancestor]],'cases':cases}
out=HERE/'staged/web/packages/core/test/fixtures/saleReturnOtherAmountReplay.independent.json'
out.write_text(json.dumps(fixture,indent=2,ensure_ascii=False)+'\n')
freeze={'fixtureSha256':hashlib.sha256(out.read_bytes()).hexdigest(),'cases':len(cases),'implementationAbsent':not (HERE/'staged/web/packages/core/src/saleReturnOtherAmountReplay.ts').exists(),'sourceInputs':fixture['sourceInputs']}
assert freeze['implementationAbsent']
(HERE/'fixture-freeze.json').write_text(json.dumps(freeze,indent=2)+'\n')
print(json.dumps(freeze))
