"""Complete source-entered BAR targets, before implementation. No TS execution."""
from pathlib import Path
from copy import deepcopy
import json,hashlib
P=Path(__file__).parent
T=P/'web/packages/core/test/fixtures/saleReturnNBarCompanions.independent.json'
assert not (P/'web/packages/core/src/saleReturnNBarCompanions.ts').exists() and not T.exists()
T.parent.mkdir(parents=True,exist_ok=True)
prior=Path('/tmp/datacare-return-save-map-staged/web/packages/core/test/fixtures/saleReturnIncomingSave.independent.json')
assert hashlib.sha256(prior.read_bytes()).hexdigest()=='b6aae6e4add413b768f306703d16072999ac00a48ba779515b83346de4aeed50'
V=deepcopy(json.loads(prior.read_text())['cases'][0]['input']['visible'])
TOTAL={str(i):'' for i in range(71)}
TOTAL.update({'5':'Total :','9':'1','10':'10.000','11':'0.000','12':'10.000','15':'0.000',
 '18':'10.000','20':'100.00','24':'10.00','27':'0.00','28':'0.00','35':'0.00',
 '36':'110.00','38':'110.00','42':'0.000'})
C={'CO_CODE':'01','LC_CODE':'01','CO_YEAR':'2024-2025','CO_BOOK':'R11','VCH_NO':'00017',
 'VCH_DATE':'2024-07-10','STK_DATE':'10/07/2024','HD_VCH_NO':'HD-17','AC_CODE':'CUST',
 'VCH_TYPE':'SR','INOUT_TYPE':'I','BOOK_NAME':'SALES RETURNE','VCH_TIME':'2024-07-10T12:13:14.123456',
 'EMP_CODE':'E1','VCH_DESC':'','MAIN_USER':'original user'}
#12 complete header targets, independently transcribed from13080–13124.
H={'CO_CODE':'01','LC_CODE':'01','CO_YEAR':'2024-2025','CO_BOOK':'R11','VCH_NO':'00017',
 'VCH_DATE':'2024-07-10','STK_IT_CODE':'','VCH_TIME':'2024-07-10T12:13:14.123456',
 'EMP_CODE':'E1','VCH_DESC':'','DATA_TRFR':'N','MAIN_USER':'original user'}
#70 final targets from74 ordered13908–14225 assignments. Not generated from code.
D={'CO_CODE':'01','LC_CODE':'01','CO_YEAR':'2024-2025','CO_BOOK':'R11','VCH_NO':'00017',
 'VCH_DATE':'2024-07-10','STK_DATE':'10/07/2024','HD_VCH_NO':'HD-17','AC_CODE':'CUST',
 'VCH_TYPE':'SR','INOUT_TYPE':'I','ENTRY_TYPE':'P','BOOK_NAME':'SALES RETURNE',
 'SR_NO':'1','OLD_SRNO':'31','IT_CODE':'GOLD','TAG_NO':'N','TBL_CODE':'001','DESIGN_NO':' D-raw ',
 'ITM_STYLE':'Style','ITM_SIZE':'','HM_ID':'H1','ITM_PCS':'1','ITM_GWT':'10','ITM_OTH_WT':'0',
 'ITM_NWT':'10','ITM_GHT_PRC':'0','ITM_GHT_WT':'0','ITM_TOUCH':'100','ITM_WEST_PRC':'0',
 'ITM_FINE':'10','KR_GHT_WT':'0','KR_TOUCH':'100','KR_WEST_PRC':'0','KR_FINE':'10',
 'ITM_RATE':'0','ITM_AMT':'0','LBR_TYPE':'N','LBR_CODE':'AA','LBR_PRC':'0','LBR_RATE':'0',
 'LBR_AMT':'0','OTH_AMT':'0','KR_COST':'0','TAG_COST':'0','ITM_MRP':'0','KR_NAME':'KR',
 'RATE_TYPE':'N','IT_TYPE':'G','VCH_TIME':'2024-07-10T12:13:14.123456','PR_CODE':'P1',
 'TAG_TYPE':'A','KR_LBR_RATE':'0','KR_LBR_AMT':'0','KR_OTH_AMT':'0','TAG_SRNO':'123',
 'VCH_SRNO':'500001','APR_ISU':'N','EMP_ISU':'N','DESIGN_IMG_ID':'','HM_ID2':'',
 'HM_ID3':'H3','HM_ID4':'H4','HM_ID_WT':'0','HM_ID2_WT':'0','HM_ID3_WT':'0',
 'HM_ID4_WT':'0','DATA_TYPE':'A','DATA_TRFR':'N','MAIN_USER':'original user'}
assert len(C)==16 and len(H)==12 and len(D)==70 and len(V)==63 and len(TOTAL)==71
HR={**H,'tenant_id':'bar-fixture','row_id':'7001','AC_CODE':None,'CUST_AC':None,
 'OP_STK':None,'HD_VCH_NO':None,'OLD_VCH_NO':None,'NEW_VCH_NO':None,
 'USER_UPDATE':None,'USER_DELETE':None,'LOT_NO':None,'FUTURE_HEADER':'raw\nheader'}
DR={**D,'tenant_id':'bar-fixture','row_id':'7002','ITM_PCS':'1.000','ITM_GWT':'10.000',
 'ITM_NWT':'10.000','LBR_RATE':'0.00','LBR_AMT':'0.00','ITM_RATE':'0.00','ITM_AMT':'0.00',
 'OTH_AMT':'0.00','TAG_COST':'0.00','ITM_REMARK':None,'BAG_WT':None,'ITM_MARGIN':None,
 'FUTURE_PARENT':'raw\nparent','ORD_NO':None,'SL_TYPE':None}
BASE={'rowIdentity':'a'*64,'tenantId':'bar-fixture','context':{'status':'qualified','observationIdentity':'b'*64,'values':C},
 'before':{'visible':V,'incomingTotals':TOTAL},'after':{'visible':deepcopy(V),'incomingTotals':deepcopy(TOTAL)},
 'observed':{'barData':[{'rowId':'7001','version':'c'*64,'raw':HR}],
             'barDetl':[{'rowId':'7002','version':'d'*64,'raw':DR}]}}
def phase(header=True,parent=True,h=None,d=None):return {'predicates':{'barData':header,'barDetl':parent},
 'barData':({**H,**(h or {})} if header else None),'barDetl':({**D,**(d or {})} if parent else None)}
cases=[]
def add(id,note,edit=None,before=None,after=None,code=None):
 x=deepcopy(BASE)
 if edit:edit(x)
 cases.append({'id':id,'note':note,'input':x,'expected':{'status':'unsupported' if code else 'matched',
 'before':before if before is not None else phase(),'after':after if after is not None else phase(),
 'diagnosticCode':code,'observed':deepcopy(x['observed']),'canCommit':False}})
add('B01','Full82-target unchanged Option A N companion')
def other(x,text,net):
 x['after']['visible'].update({'27':text,'36':net,'38':net});x['after']['incomingTotals'].update({'27':text,'36':net,'38':net})
add('B02','Other0→1 changes no BAR target',lambda x:other(x,'1.00','111.00'))
add('B03','Other-11 drops only BAR_DATA despite positive99 row',lambda x:other(x,'-11.00','99.00'),after=phase(False,True),code='companion-membership-change')
add('B04','Other-121 drops only parent:1+10-11=0',lambda x:other(x,'-121.00','-11.00'),after=phase(True,False),code='companion-membership-change')
def tag(x,t):
 for k in ['before','after']:x[k]['visible']['2']=t
add('B05','Blank tag excludes parent before inner N default',lambda x:tag(x,''),before=phase(True,False),after=phase(True,False),code='unsupported-n-tag-profile')
add('B06','Literal0 is nonblank; source includes but Option A refuses non-N',lambda x:tag(x,'0'),before=phase(d={'TAG_NO':'0'}),after=phase(d={'TAG_NO':'0'}),code='unsupported-n-tag-profile')
def blank_mode(x):
 for k in ['before','after']:x[k]['visible']['70']=''
add('B07','Blank row DATA_TYPE assigns A; no session mode inferred',blank_mode)
add('B08','Changed tag Other c33 changes BAR OTH and must refuse',lambda x:x['after']['visible'].update({'33':'1.00'}),after=phase(d={'OTH_AMT':'1'}),code='companion-value-change')
add('B09','Changed normal labour c23 is not BAR tag rate c31',lambda x:x['after']['visible'].update({'23':'9.00'}))
add('B10','Mapped header NULL is not equivalent to source blank',lambda x:x['observed']['barData'][0]['raw'].update({'VCH_DESC':None}),code='observation-value-mismatch')
add('B11','Final TAG_SRNO c56 overrides temporary zero',lambda x:x['observed']['barDetl'][0]['raw'].update({'TAG_SRNO':'0'}),code='observation-value-mismatch')
def duplicate(x):
 y=deepcopy(x['observed']['barDetl'][0]);y['rowId']='7003';y['raw']['row_id']='7003';x['observed']['barDetl'].append(y)
add('B12','Duplicate physical parent is not silently selected',duplicate,code='observed-membership-mismatch')
add('B13','Missing header is not repaired',lambda x:x['observed'].update({'barData':[]}),code='observed-membership-mismatch')
def rounded(x):
 for k in ['before','after']:
  x[k]['visible'].update({'9':'1.4','27':'-11.00'});x[k]['incomingTotals']['27']='-11.00'
add('B14','Header uses rounded aggregatePCS1 not rowPCS1.4',rounded,before=phase(False,True,d={'ITM_PCS':'1.4'}),after=phase(False,True,d={'ITM_PCS':'1.4'}),code='unsupported-companion-membership')
def mrp(x):
 other(x,'-11.00','99.00');x['after']['visible']['28']='0.01';x['after']['incomingTotals']['28']='0.01'
add('B15','Nonzero aggregate MRP independently keeps header included',mrp)
add('B16','Wrong observed company cannot match retained scope',lambda x:x['observed']['barDetl'][0]['raw'].update({'CO_CODE':'02'}),code='observation-identity-mismatch')
add('B17','Own raw row_id must agree with descriptor identity',lambda x:x['observed']['barDetl'][0]['raw'].update({'row_id':'999'}),code='observation-identity-mismatch')
add('B18','Unowned raw header account NULL is preserved; no global maintenance',lambda x:x['observed']['barData'][0]['raw'].update({'FUTURE_NULL':None}))
add('B19','Mapped numeric NULL is not a zero default',lambda x:x['observed']['barDetl'][0]['raw'].update({'KR_COST':None}),code='observation-value-mismatch')
add('B20','Changed c34 feeds both cost columns',lambda x:x['after']['visible'].update({'34':'5.00'}),after=phase(d={'KR_COST':'5','TAG_COST':'5'}),code='companion-value-change')
add('B21','Changed c54 feeds TAG_TYPE; c55 does not',lambda x:x['after']['visible'].update({'54':'B','55':'A'}),after=phase(d={'TAG_TYPE':'B'}),code='companion-value-change')
add('B22','Source-zero BAR rates never copy incoming metal values',lambda x:x['after']['visible'].update({'19':'999.00','20':'9999.00'}))
out={'kind':'independent-full-n-bar-companion-literals-v1','authorship':'Frozen before implementation. Complete12/70 expected source targets entered independently; copies/explicit overrides only, no calculator or new module execution. Supplied maps are not proof of c27 replay or write admission.','cases':cases}
T.write_text(json.dumps(out,indent=2)+'\n');(P/'fixture-authorship.json').write_text(json.dumps({'implementationExisted':False,'executedRuntime':False,'cases':len(cases),'headerTargets':12,'parentTargets':70,'orderedParentAssignments':74,'fixtureSha256':hashlib.sha256(T.read_bytes()).hexdigest()},indent=2)+'\n')
print(hashlib.sha256(T.read_bytes()).hexdigest())
