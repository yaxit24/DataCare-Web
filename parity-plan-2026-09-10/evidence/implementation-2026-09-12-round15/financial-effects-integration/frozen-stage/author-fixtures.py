"""Literal authorship only. Never imports/executes new planner or any reducer.
Complete schema shapes are copied; every financial expected value below is
entered from the seven primary SELECT lists before implementation exists.
"""
from pathlib import Path
from copy import deepcopy as copy
import json,hashlib,datetime
S=Path(__file__).parent; root=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
assert not (S/'web/packages/core/src/saleReturnFinancialEffects.ts').exists()
output=S/'web/packages/core/test/fixtures/saleReturnFinancialEffects.independent.json'
assert not output.exists()
schema=json.loads((S/'target-storage-index.json').read_text())['tables']
old=json.loads(Path('/tmp/datacare-return-save-map-staged/web/packages/core/test/fixtures/saleReturnIncomingSave.independent.json').read_text())['cases'][0]['input']['raw']
scope={'CO_CODE':'01','LC_CODE':'01','CO_YEAR':'2024-2025','CO_BOOK':'R11','VCH_NO':'00017'}
tenant='effects-fixture'; basekey='01012024-2025R1100017'; key1=basekey+'01'+'         1';key2=basekey+'02'+'         1'
incoming={k:None for k in schema['SL_DETL_RTN']['fields']};incoming.update(old);incoming.update(scope);incoming.update(tenant_id=tenant,SR_NO='1',OLD_SRNO='1',VCH_SRNO='123',TAG_SRNO='1',VCH_DATE='2024-07-10',VCH_TIME='2024-07-10T12:34:56',HD_VCH_NO='00017',AC_CODE='CUST',EMP_CODE='001',MAIN_USER='fixture',ENTRY_TYPE='P',INOUT_TYPE='I',IT_CODE='GOLD',DATA_TYPE='A',TAG_NO='N',ITM_SIZE=None)
header={k:None for k in schema['SL_DATA']['fields']};header.update(scope);header.update(tenant_id=tenant,VCH_DATE='2024-07-10',VCH_TIME='2024-07-10T12:34:56',AC_CODE='CUST',AC_NAME=' Customer ',VCH_DESC=None,TAX_CODE='00',RATE_UNFIX='N',USER_UPDATE='N',RTN_NET_AMT='110',RTN_TOT_AMT='110',RTN_BILL_OS='110')
zeros='NET_AMT TOT_AMT BILL_OS TAX_AMT CHQ_AMT CARD_AMT CASH_AMT KASAR_AMT RTN_CHQ_AMT RTN_CARD_AMT RTN_CASH_AMT RTN_KASAR_AMT HM_AMT HM_TAX_AMT DISC_AMT'.split()
for k in zeros: assert k in header;header[k]='0'
book={'CO_CODE':'01','LC_CODE':'01','CO_BOOK':'R11','MAIN_BOOK':'SALES RETURNE','BOOK_INOUT':'I','BOOK_TYPE':'T','BOOK_TBL_NAME':'SL_DATA','BOOK_SNAME':'SR','DATA_TYPE':'B'}
detail={'CO_CODE':'01','LC_CODE':'01','CO_BOOK':'R11','MAIN_BOOK':'SALES RETURNE','BOOK_INOUT':'I','BOOK_TYPE':'T','BOOK_SNAME':'RT','DATA_TYPE':'C','SR_NO':'1','AC_CODE':'BOOKAC'}
context={'status':'qualified','observationIdentity':'c'*64,'companyShortName':'IN','openingDate':'2024-04-01','book':[book],'bookDetail':[detail],'item':[{'CO_CODE':'01','IT_CODE':'GOLD','GR_CODE':'G1'}],'group':[{'CO_CODE':'01','GR_CODE':'G1','SALE_AC':'SALE'}],'account':[{'CO_CODE':'01','AC_CODE':'CUST','AC_GST_TYPE':'N'}],'taxes':[{'CO_CODE':'01','TAX_CODE':'00','SR_NO':'1','TAX_GROUP':'C','TAX_PRC':'0.0000'},{'CO_CODE':'01','TAX_CODE':'00','SR_NO':'2','TAX_GROUP':'S','TAX_PRC':'0.0000'}],'storage':{'status':'qualified','observationIdentity':'d'*64,'values':{'acEntryTime':'2024-07-10T12:34:56','stockEntryDate':'2024-07-10','stockDateText':'2024-07-10','customerLedgerKey':key1,'saleLedgerKey':key2,'stockDiscountText':'0','taxZeroRatedText':'0'}}}
# Independently entered complete SELECT targets. Numeric strings follow target
# precision; untouched observations may retain a numerically equal text scale.
ac={**scope,'VCH_TYPE':'SR','VCH_DATE':'2024-07-10','LEDR_KEY':key1,'BOOK_NAME':'SALES RETURNE','BILL_NO':'','BILL_DATE':None,'CHQ_NO':'','AC_CODE':'CUST','LD_CODE':'SALE','CR_AMT':'110.00','DR_AMT':'0.00','IT_TYPE':'A','SIGN':'','FINE_WT':'0.000','IT_DESC':'','ENTRY_TIME':'2024-07-10T12:34:56','HD_VCH_NO':'00017','CLR_DATE':None,'DATA_TYPE':'B','DATA_TRFR':'N','MAIN_USER':'fixture','FINE_RATE':'0.000','PARTY_AC_CODE':'CUST','LDR_NAME':''}
sale=copy(ac);sale.update(LEDR_KEY=key2,AC_CODE='SALE',LD_CODE='CUST',CR_AMT='0.00',DR_AMT='110.00',PARTY_AC_CODE='')
roj={**scope,'LEDR_KEY':basekey+'01','VCH_DATE':'2024-07-10','VCH_TYPE':'RT','BOOK_NAME':'SALES RETURNE','AC_CODE':'CUST','LD_CODE':'BOOKAC','CR_AMT':'110.00','DR_AMT':'0.00','AC_NAME':'','IT_TYPE':'A','SIGN':'','ITM_PCS':'0.000','ITM_GWT':'0.000','ITM_NWT':'0.000','ITM_TOUCH':'0.000','ITM_WEST':'0.000','ITM_FINE':'0.000','ITM_RATE':'0.00','ITM_AMT':'0.00','LBR_RATE':'0.00','LBR_AMT':'0.00','OTH_AMT':'0.00','NET_AMT':'0.00','IT_DESC':None,'IT_CODE':'','MEMB_CODE':'','SCHM_CODE':'','REF_NO':'','DATA_TYPE':'C'}
summary=copy(roj);summary.update(LEDR_KEY=basekey+'02',CR_AMT='0.00',DR_AMT='110.00',AC_NAME='RTN -  Customer ')
stock={**scope,'SR_NO':'2','ISR_NO':'1','VCH_DATE':'2024-07-10','STK_DATE':'2024-07-10','VCH_TYPE':'SR','BOOK_NAME':'SALES RETURNE','AC_CODE':'CUST','IT_CODE':'GOLD','TAG_NO':'N','VCH_SRNO':'123','TBL_CODE':incoming['TBL_CODE'],'TR_TYPE':'I','ITM_SIGN':'+','ITM_QTY':'1.000','ITM_PCS':'1.000','ITM_GWT':'10.000','ITM_NWT':'10.000','ITM_TOUCH':'100.000','ITM_WEST':'0.000','ITM_FINE':'10.000','ITM_RATE':'10.00','ITM_AMT':'100.00','LBR_RATE':'1.00','LBR_AMT':'10.00','OTH_AMT':'0.00','ITM_MRP':'0.00','NET_AMT':'110.00','KR_NWT':'10','KR_TOUCH':'100.000','KR_WEST':'0','KR_FINE':'10.000','KR_LBR_AMT':'0.00','KR_OTH_AMT':'0','KR_COST':incoming['TAG_COST'],'EMP_CODE':'001','ENTRY_TIME':'2024-07-10','MAIN_USER':'fixture','DATA_TYPE':'A','DESIGN_NO':incoming['DESIGN_NO'],'ITM_SIZE':None,'ITM_DESC':'','GHT_PRC':'0.0000','ITM_LOT':'','ITM_DISC':'0'}
# TAG_COST is source0 in this fixture; a separate vector preserves an unowned
# approximate Float raw scalar that is not among these SELECT targets.
assert incoming['TAG_COST']=='0.00';stock['KR_COST']='0'
tax={**scope,'SR_NO':'1','BOOK_NAME':'SALES RETURNE','TRAN_TYPE':'S','VCH_DATE':'2024-07-10','AC_CODE':'CUST','TAX_CODE':'00','TAX_TYPE':'C','TAX_PRC':'0.0000','NET_AMT':'110.00','TAX_AMT':'0.000','DISC_AMT':'0.00','TOT_AMT':'110.00','TAX_SIGN':'-','PARTY_NAME':' Customer ','R_CHARG':'N','ISR_NO':'0','TAX_FREE_AMT':'0','ZERO_RATED_AMT':'0'}
tax2=copy(tax);tax2.update(SR_NO='2',TAX_TYPE='S')
roles=['incoming-customer-ledger','incoming-sale-account-ledger','return-outstanding-rojmel','return-taxbook-summary-rojmel','incoming-stock','return-tax-sr1','return-tax-sr2']
tables=['AC_DATA','AC_DATA','ROJ_MEL_DATA','ROJ_MEL_DATA','MAIN_STOCK','TAX_DATA','TAX_DATA'];groups=['acData','acData','rojMel','rojMel','mainStock','taxData','taxData'];maps=[ac,sale,roj,summary,stock,tax,tax2]
assert [len(m) for m in maps]==[29,29,34,34,49,23,23] and sum(map(len,maps))==221
expectedBefore={r:m for r,m in zip(roles,maps)};expectedAfter=copy(expectedBefore)
patches=[{'CR_AMT':'111.00'},{'DR_AMT':'111.00'},{'CR_AMT':'111.00'},{'DR_AMT':'111.00'},{'OTH_AMT':'1.00','NET_AMT':'111.00'},{'NET_AMT':'111.00','TOT_AMT':'111.00'},{'NET_AMT':'111.00','TOT_AMT':'111.00'}]
for r,p in zip(roles,patches):expectedAfter[r].update(p)
observed={g:[] for g in groups}
for i,(role,table,group,m) in enumerate(zip(roles,tables,groups,maps)):
 raw={k:None for k in schema[table]['fields']};raw.update(m);raw['tenant_id']=tenant
 if 'row_id' in raw:raw['row_id']=str(901+i);physical=raw['row_id']
 else:physical=raw['LEDR_KEY']
 if table=='MAIN_STOCK':raw.update(GRID_SCROLL=' 007 ',OTH_FINE='0.000',ITM_COLOR=None)
 if table=='TAX_DATA':raw.update(BILL_NO=None,BILL_DATE=None,BILL_DBCD='',VCH_SRNO=None)
 observed[group].append({'physicalIdentity':physical,'version':str(i+1)*64,'raw':raw})
after={'incoming':copy(incoming),'header':copy(header)};after['incoming'].update(OTH_AMT='1.00',TOT_AMT='111.00',NET_AMT='111.00');after['header'].update(RTN_NET_AMT='111',RTN_TOT_AMT='111',RTN_BILL_OS='111')
base={'tenantId':tenant,'rowIdentity':'a'*64,'documentVersion':'b'*64,'context':context,'before':{'incoming':incoming,'header':header},'after':after,'observed':observed}
cases=[]
def ready(id,note,inp=base,b=expectedBefore,a=expectedAfter,p=patches):cases.append({'id':id,'note':note,'input':copy(inp),'expected':{'status':'ready','before':copy(b),'after':copy(a),'patches':{r:copy(v) for r,v in zip(roles,p)}}})
def refused(id,note,change,code):
 v=copy(base);change(v);cases.append({'id':id,'note':note,'input':v,'expected':{'status':'unsupported','diagnosticCode':code,'candidatePlan':None}})
ready('F01','Complete 221-field Other0→1. Distinct book B/detail C/row A and SR/RT names; physical/rawNULL retained.')
v=copy(base);v['after']=copy(v['before']);ready('F02','No effect: all seven patches empty; source phase still fully checked.',v,expectedBefore,expectedBefore,[{}]*7)
v=copy(base);v['after']['incoming'].update(OTH_AMT='0.49',TOT_AMT='110.49',NET_AMT='110.49');v['after']['header']=copy(header);a=copy(expectedBefore);p=[{'CR_AMT':'110.49'},{'DR_AMT':'110.49'},{},{},{'OTH_AMT':'0.49','NET_AMT':'110.49'},{},{}]
for r,q in zip(roles,p):a[r].update(q)
ready('F03','Fractional row110.49 while whole-unit header110: only AC and stock amounts change.',v,expectedBefore,a,p)
v=copy(base)
for phase in ['before','after']:v[phase]['header']['VCH_DESC']='';v[phase]['incoming']['future_raw_field']=' raw \u03b2 '
for o in v['observed']['rojMel']:o['raw']['IT_DESC']=''
v['observed']['mainStock'][0]['raw']['future_float_text']='0.10000000000000001';v['observed']['acData'][0]['raw']['FINE_RATE']='0.0000'
b=copy(expectedBefore);a=copy(expectedAfter)
for r in roles[2:4]:b[r]['IT_DESC']='';a[r]['IT_DESC']=''
ready('F04','Empty versus NULL description; opaque future raw scalar and numerically equal unowned scale retained.',v,b,a)
v=copy(base)
for g in v['observed']:v['observed'][g].reverse()
ready('F05','Observed order is not authority: exact source roles selected by key/identity.',v)
refused('F06','Missing existing stock row',lambda v:v['observed']['mainStock'].clear(),'observed-membership-mismatch')
refused('F07','Extra same-scope AC row',lambda v:v['observed']['acData'].append(copy(v['observed']['acData'][0])),'observed-membership-mismatch')
refused('F08','Old source-owned customer amount mismatch',lambda v:v['observed']['acData'][0]['raw'].__setitem__('CR_AMT','109.00'),'observation-value-mismatch')
refused('F09','Unowned incoming labour change is not a c27 plan',lambda v:v['after']['incoming'].__setitem__('LBR_AMT','11.00'),'unowned-source-change')
refused('F10','Header NULL description changed to empty',lambda v:v['after']['header'].__setitem__('VCH_DESC',''),'unowned-source-change')
refused('F11','Target numeric18,2 overflow',lambda v:v['after']['incoming'].__setitem__('NET_AMT','10000000000000000.00'),'unsupported-storage')
refused('F12','Target fractional cents cannot silently round',lambda v:v['after']['incoming'].__setitem__('OTH_AMT','0.001'),'unsupported-storage')
refused('F13','Nonzero header tax would introduce unsupported effects',lambda v:v['before']['header'].__setitem__('TAX_AMT','2.00'),'unsupported-profile')
refused('F14','SQL NULL rate-unfixed predicate cannot become N',lambda v:v['before']['header'].__setitem__('RATE_UNFIX',None),'unsupported-profile')
refused('F15','Incoming N changed to tagged stock',lambda v:v['after']['incoming'].__setitem__('TAG_NO','TAG'),'unsupported-profile')
refused('F16','Tax NULL GST does not satisfy ordinary branch',lambda v:v['context']['account'][0].__setitem__('AC_GST_TYPE',None),'unsupported-context')
refused('F17','Duplicate qualifying tax master',lambda v:v['context']['taxes'].append(copy(v['context']['taxes'][0])),'unsupported-context')
refused('F18','Canonical family does not normalize a space',lambda v:v['context']['book'][0].__setitem__('MAIN_BOOK','SALES RETURNE '),'unsupported-context')
refused('F19','Header date before opening',lambda v:v['context'].__setitem__('openingDate','2025-04-01'),'unsupported-context')
refused('F20','Unavailable target/storage qualifier',lambda v:v['context'].__setitem__('storage',{'status':'unavailable','reason':'No target witness.'}),'context-unavailable')
refused('F21','Lost physical identity',lambda v:v['observed']['taxData'][0].__setitem__('physicalIdentity','999'),'observation-identity-mismatch')
refused('F22','Wrong tenant physical row',lambda v:v['observed']['rojMel'][0]['raw'].__setitem__('tenant_id','other'),'observation-identity-mismatch')
refused('F23','Missing current-schema unowned raw field',lambda v:v['observed']['mainStock'][0]['raw'].pop('ITM_COLOR'),'missing-raw-field')
refused('F24','Zero header return membership unsupported',lambda v:v['after']['header'].__setitem__('RTN_BILL_OS','0'),'unsupported-profile')
refused('F25','Changed stock source tag valuation is outside owned patch',lambda v:v['after']['incoming'].__setitem__('TAG_COST','1.00'),'unowned-source-change')
refused('F26','Missing selected account',lambda v:v['context']['account'].clear(),'unsupported-context')
refused('F27','Duplicate physical rows with distinct role values',lambda v:v['observed']['acData'][1].update(physicalIdentity='901',raw={**v['observed']['acData'][1]['raw'],'row_id':'901'}),'observation-identity-mismatch')
refused('F28','Source row instance cannot allocate',lambda v:v['before']['incoming'].__setitem__('VCH_SRNO','0'),'unsupported-profile')
refused('F29','New envelope key is not accepted',lambda v:v.__setitem__('canCommit',True),'invalid-input')
refused('F30','Unknown raw extension key cannot disappear',lambda v:v['before']['incoming'].__setitem__('future_raw_field',None),'unowned-source-change')
# Freeze full input and complete literal output maps before the planner is created.
output.write_text(json.dumps({'kind':'independent-complete-seven-financial-effect-literals-v1','authorship':'Before new implementation; all221 expected fields entered from primary SELECT lists. Copying/scenario overrides execute no planner/reducer. Mathematical supplied-observation fixtures, no DB/Windows/full-save credit.','roles':roles,'tables':tables,'cases':cases},indent=2,ensure_ascii=False)+'\n')
(S/'fixture-authorship.json').write_text(json.dumps({'authoredAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'implementationExists':False,'caseCount':len(cases),'fullSuccessfulPhaseMaps':10,'sourceEntriesPerPhase':221,'fixtureSha256':hashlib.sha256(output.read_bytes()).hexdigest(),'notes':['No root or peer new implementation inspected or executed to derive expectations.','F03 independently distinguishes row fractional amounts from rounded header effects.','Opaque raw extension preservation follows explicit parent boundary; selected canonical context remains a caller precondition.']},indent=2)+'\n')
print('FIXTURE',len(cases),hashlib.sha256(output.read_bytes()).hexdigest())
