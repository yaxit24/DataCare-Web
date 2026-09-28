"""Expand independently entered source expectations, never import/run product code.

The loops below only fill complete grid shapes, copy baselines and serialize literal
expected numbers. They do not evaluate aggregate, tax, settlement or row formulas.
"""
from pathlib import Path
from copy import deepcopy as cp
from hashlib import sha256
import json

BASE = Path(__file__).resolve().parents[3]
HERE = Path(__file__).resolve().parent
OLD = HERE.parent / 'implementation-2026-09-11-round9'
SOURCE = BASE / 'extracted_code/DataCareNext/DataCareNext/TR_SALE_RTN.cs'
BASELINE = OLD / 'x13-replay-independent-journal-vectors.json'
assert sha256(BASELINE.read_bytes()).hexdigest() == '68c3744d2e2cdbf741723effeef853dc05c97222f47bd740ecdd126127f7d83d'
baseline = json.loads(BASELINE.read_text())
original = baseline['vectors'][0]['baseline']
CACHES = [45, 46, 47, 48, 49, 58, 66, 67]
ZERO = {9: '0', 10: '0.000', 11: '0.000', 12: '0.000', 15: '0.000', 18: '0.000', 20: '0.00', 24: '0.00', 27: '0.00', 42: '0.000', 28: '0.00', 36: '0.00', 38: '0.00', 35: '0.00'}

def row(ordinal, values, name=None):
    visible = {str(i): '' for i in range(71) if i not in CACHES}
    visible['0'] = str(ordinal)
    visible.update({str(k): v for k, v in values.items()})
    return {'ordinal': ordinal, 'state': {
        'rowIdentity': name or f'independent-row-{ordinal}',
        'raw': {'unchangedNull': None, 'clock': '2024-07-10 12:34:56.123456', 'exactRaw': '9999999999999999.99'},
        'visible': visible, 'caches': {str(i): '' for i in CACHES}, 'journal': []}}

def prior_totals():
    cells = {str(i): '' for i in range(71)}
    cells.update({'0': 'retained-zero-cell', '5': 'Previous label', '20': '77.70', '25': '55.55', '38': '80.00', '42': '9.999'})
    return {'cells': cells, 'totCrFine': '9.999', 'prOthAmtLess': '88.88'}

def totals(values=None, visited=True):
    cells = {str(i): '' for i in range(71)}
    cells.update({'0': 'retained-zero-cell', '5': 'Total :'})
    if visited:
        cells.update({str(k): v for k, v in ZERO.items()})
    cells.update({str(k): v for k, v in (values or {}).items()})
    return {'cells': cells, 'totCrFine': '0', 'prOthAmtLess': '0'}

aggregate = []
def agg(name, rows, expected, up_down=False, status='applied', note=''):
    aggregate.append({'id': name, 'source': 'TR_SALE_RTN:5162-5202', 'note': note,
      'rows': rows, 'previous': prior_totals(), 'upDown': up_down,
      'expected': {'status': status, 'state': expected}})

agg('pieces-positive-running-round', [row(1,{9:'0.6'}), row(2,{9:'0.6'})], totals({9:'2'}))
agg('pieces-small-running-round', [row(1,{9:'0.4'}), row(2,{9:'0.4'})], totals({9:'0'}))
agg('pieces-negative-running-round', [row(1,{9:'-0.6'}), row(2,{9:'-0.6'})], totals({9:'-2'}))
agg('all-fourteen-source-columns', [
 row(1,{9:'0.6',10:'1.234',11:'0.100',12:'1.134',15:'0.045',18:'0.777',20:'100.10',24:'10.23',27:'3.45',42:'0.006',28:'140.15',36:'113.78',38:'115.80',35:'160.10',25:'75.00',26:'99.00',37:'18.00'}),
 row(2,{9:'0.6',10:'0.766',11:'0.200',12:'0.566',15:'0.055',18:'0.223',20:'0.90',24:'0.77',27:'0.55',42:'0.004',28:'0.85',36:'2.22',38:'2.20',35:'0.90',25:'25.00',26:'1.00',37:'10.00'})],
 totals({9:'2',10:'2.000',11:'0.300',12:'1.700',15:'0.100',18:'1.000',20:'101.00',24:'11.00',27:'4.00',42:'0.010',28:'141.00',36:'116.00',38:'118.00',35:'161.00'}),
 note='Column42 participates;25/26/37 clear and never sum. TotCrFine remains0 despite fine1.000. Pure grid-boundary values do not grant source admission.')
agg('one-blank-grid-row', [row(1,{})], totals())
agg('no-grid-data-rows', [], totals(visited=False))
agg('updown-preserves-unread-invalid-text', [row(1,{9:'not-a-decimal',38:'120.00'})], prior_totals(), True, 'skipped',
    'Shape/order valid; guard skips numeric reads, clearing and counters. A numeric caller can separately bill retained38=80.')
agg('large-exact-cents', [row(1,{20:'99999999999999999999999999.01'}), row(2,{20:'0.02'})], totals({20:'99999999999999999999999999.03'}),
    note='Declared exact-decimal profile only; this does not assert Double preserves26 integer digits.')

def bill():
    m = [['']*6 for _ in range(9)]
    m[0] = ['', '', '', 'Payment    ', 'Received    ', '']
    for i,label in enumerate(['Net Amt : ','Sale Tax : ','Total Amt : ','Cheque Amt : ','Card Amt : ','Cash Amt : ','Kasar Amt : ','Os Amt : '],1):
        m[i][0]=label
    m[2][1],m[2][2],m[2][5]='Source tax','0.00','T01'
    m[4][1],m[4][2],m[4][5]='Bank name','CHQ001','BANK01'
    m[5][1],m[5][2],m[5][5]='Card name','REF002','CARD01'
    return {'matrix': m, 'oldNetAmt':'0.00','oldTaxPrc':'0.00',
      'outgoingRounded':'999.00','incomingRounded':'999.00',
      'closing':{'status':'resolved','amount':'-999','label':'999.00 : Dr Amt','color':'red'}}

def patch(previous, cells=(), **fields):
    out=cp(previous)
    for r,c,value in cells: out['matrix'][r][c]=value
    out.update(fields)
    return out

def closing(amount,label,color):
    return {'status':'resolved','amount':amount,'label':label,'color':color}

def context(tax=2,edit=False,opening='0'):
    return {'taxRoundingDecimals':tax,'editOpen':edit,
      'openingBalance':{'status':'resolved','amount':opening,'observationIdentity':'independent-ledger-snapshot'}}

bills=[]
def bcase(name,incoming,outgoing,previous,ctx,expected,recalculated,note=''):
    bills.append({'id':name,'source':'TR_SALE_RTN:16381-16458','note':note,'incomingTotal38':incoming,
      'outgoingTotal24':outgoing,'previous':previous,'context':ctx,
      'expected':{'status':'applied','state':expected,'taxRecalculated':recalculated}})

p=bill()
bcase('round-legs-before-difference','100.49','99.51',p,context(),
 patch(p,[(1,3,'0.00'),(3,3,'0.00'),(8,3,'0.00')],incomingRounded='100.00',outgoingRounded='100.00',closing=closing('0',': Amt','red')),False)
for name,value,rounded in [('whole-tie-even-low','100.50','100'),('whole-tie-even-high','101.50','102')]:
 p=bill()
 bcase(name,value,'0',p,context(),patch(p,[(1,3,rounded+'.00'),(2,3,'0.00'),(3,3,rounded+'.00'),(8,3,rounded+'.00')],oldNetAmt=rounded,oldTaxPrc='0',incomingRounded=rounded+'.00',outgoingRounded='0.00',closing=closing(rounded,rounded+'.00 : Cr Amt','blue')),True)
p=patch(bill(),[(2,2,'10.00'),(2,3,'7.00')],oldNetAmt='200.00',oldTaxPrc='10.00')
bcase('saved-full-incoming-cache-differs-from-payment','200','80',p,context(),patch(p,[(1,3,'120.00'),(2,3,'12.00'),(3,3,'132.00'),(8,3,'132.00')],oldNetAmt='120',oldTaxPrc='10',incomingRounded='200.00',outgoingRounded='80.00',closing=closing('132','132.00 : Cr Amt','blue')),True)
bcase('numeric-equal-cache-retains-manual-tax-and-text','200','0',p,context(),patch(p,[(1,3,'200.00'),(3,3,'207.00'),(8,3,'207.00')],incomingRounded='200.00',outgoingRounded='0.00',closing=closing('207','207.00 : Cr Amt','blue')),False)
p=patch(p,[(2,5,'CHANGED-TAX-CODE')])
bcase('tax-code-only-does-not-invalidate-cache','200','0',p,context(),patch(p,[(1,3,'200.00'),(3,3,'207.00'),(8,3,'207.00')],incomingRounded='200.00',outgoingRounded='0.00',closing=closing('207','207.00 : Cr Amt','blue')),False)
p=patch(bill(),[(2,2,'10.00'),(2,3,'7.00')],oldNetAmt='200.60',oldTaxPrc='10.00')
bcase('saved-open-whole-round-invalidates-tax-cache','200.60','0',p,context(),patch(p,[(1,3,'201.00'),(2,3,'20.10'),(3,3,'221.00'),(8,3,'221.00')],oldNetAmt='201',oldTaxPrc='10',incomingRounded='201.00',outgoingRounded='0.00',closing=closing('221','221.00 : Cr Amt','blue')),True)
p=patch(bill(),[(2,2,'10.00'),(2,3,'7.00'),(6,3,'10.00'),(6,4,'20.00')],oldNetAmt='120',oldTaxPrc='10')
phase_open=patch(p,[(1,4,'120.00'),(2,3,'0.00'),(3,3,'0.00'),(3,4,'120.00'),(8,3,'-10.00'),(8,4,'100.00')],oldNetAmt='0',incomingRounded='80.00',outgoingRounded='200.00',closing=closing('-105','105.00 : Dr Amt','red'))
bcase('editopen-calculates-both-os-before-clearing','80','200',p,context(edit=True,opening='5'),phase_open,True)
phase_closed=patch(phase_open,[(2,3,''),(3,3,''),(4,3,''),(5,3,''),(6,3,''),(7,3,''),(8,3,'')],closing=closing('-95','95.00 : Dr Amt','red'))
bcase('followup-closed-phase-clears-then-closes','80','200',phase_open,context(opening='5'),phase_closed,False)
p=patch(bill(),[(2,2,'10.00'),(2,3,'7.00'),(6,3,'9.00')],oldNetAmt='0',oldTaxPrc='10')
bcase('zero-difference-retains-manual-tax','0','0',p,context(),patch(p,[(1,3,'0.00'),(3,3,'7.00'),(8,3,'-2.00')],incomingRounded='0.00',outgoingRounded='0.00',closing=closing('-2','2.00 : Dr Amt','red')),False)
p=patch(bill(),[(2,2,'10.00'),(4,3,'10.00'),(5,3,'20.00'),(6,3,'30.00'),(7,3,'4.00'),(4,4,'9.00'),(5,4,'8.00'),(6,4,'7.00'),(7,4,'6.00')])
bcase('payment-tenders-and-positive-opening','150.55','20.21',p,context(opening='50'),patch(p,[(1,3,'131.00'),(2,3,'13.10'),(3,3,'144.00'),(8,3,'80.00'),(4,4,''),(5,4,''),(6,4,''),(7,4,'')],oldNetAmt='131',oldTaxPrc='10',incomingRounded='151.00',outgoingRounded='20.00',closing=closing('130','130.00 : Cr Amt','blue')),True)
p=patch(bill(),[(4,4,'10.00'),(6,4,'100.00'),(7,4,'5.00')])
bcase('received-tenders-negative-opening','100.24','250.49',p,context(opening='-50'),patch(p,[(1,4,'150.00'),(3,4,'150.00'),(8,4,'35.00')],incomingRounded='100.00',outgoingRounded='250.00',closing=closing('-85','85.00 : Dr Amt','red')),False)
for name,tax,tax_text in [('tax-round0','0','1.00'),('tax-round2','2','1.41')]:
 p=patch(bill(),[(2,2,'1.40')])
 bcase(name,'101','0',p,context(tax=int(tax)),patch(p,[(1,3,'101.00'),(2,3,tax_text),(3,3,'102.00'),(8,3,'102.00')],oldNetAmt='101',oldTaxPrc='1.4',incomingRounded='101.00',outgoingRounded='0.00',closing=closing('102','102.00 : Cr Amt','blue')),True,
    'Resolved policy only: TAX_ROF/ALL_ROF_REMOVE resolver is outside this pure module.')
p=bill()
ctx=context();ctx['openingBalance']={'status':'unavailable','reason':'No trusted ledger observation was supplied.'}
unknown={'status':'unavailable','amount':None,'label':None,'color':'red','reason':'No trusted ledger observation was supplied.'}
bcase('unknown-opening-keeps-bill-but-no-closing','50','0',p,ctx,patch(p,[(1,3,'50.00'),(2,3,'0.00'),(3,3,'50.00'),(8,3,'50.00')],oldNetAmt='50',oldTaxPrc='0',incomingRounded='50.00',outgoingRounded='0.00',closing=unknown),True)
p=patch(bill(),[(2,2,'1.00'),(2,3,'9.00')],oldNetAmt='250',oldTaxPrc='0')
bcase('bill-tax-explicit-half-even','250','0',p,context(tax=0),patch(p,[(1,3,'250.00'),(2,3,'2.00'),(3,3,'252.00'),(8,3,'252.00')],oldNetAmt='250',oldTaxPrc='1',incomingRounded='250.00',outgoingRounded='0.00',closing=closing('252','252.00 : Cr Amt','blue')),True)

jrow={'ordinal':1,'state':{'rowIdentity':'j1-source-row','raw':cp(original['raw']),'visible':cp(original['visible']),'caches':cp(original['caches']),'journal':[]}}
jtotals=totals({9:'1',10:'10.000',12:'10.000',18:'10.000',20:'100.00',24:'10.00',36:'110.00',38:'110.00'})
jbill=patch(bill(),[(1,3,'110.00'),(2,2,'10.00'),(2,3,'7.00'),(3,3,'117.00'),(8,3,'117.00')],oldNetAmt='110',oldTaxPrc='10',incomingRounded='110.00',outgoingRounded='0.00',closing=closing('117','117.00 : Cr Amt','blue'))
jinput={'raw':{'RTN_NET_AMT':'110','TAX_PRC':'10.00','TAX_AMT':'7.00','untouched':None,'VCH_TIME':'2024-07-10 12:34:56.123456'},'rows':[jrow],'totals':jtotals,'bill':jbill,'outgoingTotal24':'0.00'}
jctx={**context(),'upDown':False}
steps=[]
for text,other,net,tax,total in [('1','1.00','111.00','11.10','122.00'),('0','0.00','110.00','11.00','121.00')]:
    event={'kind':'leaveCell','rowIdentity':'j1-source-row','column':27,'text':text,'context':{'currentRow':1,'clearing':False,'editorVisible':True,'committedColumnWidth':1000}}
    vis=cp(original['visible']);vis.update({'27':other,'36':net,'38':net})
    expected_totals=cp(jtotals);expected_totals['cells'].update({'27':other,'36':net,'38':net})
    expected_bill=patch(jbill,[(1,3,net),(2,3,tax),(3,3,total),(8,3,total)],oldNetAmt={'111.00':'111','110.00':'110'}[net],incomingRounded=net,closing=closing({'122.00':'122','121.00':'121'}[total],total+' : Cr Amt','blue'))
    steps.append({'event':event,'expected':{'visible':vis,'caches':cp(original['caches']),'totals':expected_totals,'bill':expected_bill,'rowCalculated':True,'aggregateApplied':True,'billApplied':True,'taxRecalculated':True}})

fixture={'contract':'sale-return-incoming-aggregate-independent-v1',
 'authoring':'Literal expectations derived from primary source and frozen round9 review; only type declarations of the new module were read. No product implementation was inspected or executed to generate expectations. The generator only expands complete shapes/copies explicit baselines.',
 'profile':'Exact-decimal mathematical primary-form callback profile, not measured Double/Val/Format/locale parity. No SQL, ledger resolution, settings authority, admission, numeric or financial writes.',
 'sources':{'primary':{'path':'extracted_code/DataCareNext/DataCareNext/TR_SALE_RTN.cs','sha256':sha256(SOURCE.read_bytes()).hexdigest(),'locations':['5162-5202 incoming fold','16381-16458 bill phases','10101-10148 saved caches','10491-10504 outgoing/open phase','5157-5158 per-event callback order']},
 'baseline':{'path':str(BASELINE.relative_to(BASE)),'sha256':sha256(BASELINE.read_bytes()).hexdigest()}},
 'aggregateVectors':aggregate,'billVectors':bills,
 'compositeVectors':[{'id':'J1-equal-final-row-unequal-bill-cache-history','source':'TR_SALE_RTN:5070-5076,5157-5158,16398-16405','input':jinput,'rowPolicy':baseline['policy'],'context':jctx,'steps':steps,'finalOnlyIncorrectPaymentTotal':'117.00'}],
 'ledgerLimit':{'implemented':False,'source':'DC_Main:1463-1492 and TR_SALE_RTN:10106,10197,10226','savedRawTime':'2024-07-10 12:00:00.900000','sourceCutoff':'2024-07-10 12:00:00','openingPredicate':'same company/location/year/account, all books, ENTRY_TIME strictly before cutoff; MsDataType C unrestricted, others exact mode filter','sameScopeRows':[{'time':'2024-07-10 11:59:59.900000','book':'R10','dataType':'A','credit':'10','debit':'0'},{'time':'2024-07-10 11:59:59.800000','book':'OTHER','dataType':'B','credit':'7','debit':'0'},{'time':'2024-07-10 12:00:00','book':'R10','dataType':'A','credit':'20','debit':'0'},{'time':'2024-07-10 12:00:00.100000','book':'R10','dataType':'A','credit':'30','debit':'0'}],'expectedOpeningModeC':'17.00','expectedOpeningModeA':'10.00','expectedSourceHelperClosingModeC':'37.00','note':'Hand-derived prerequisite only. Pure core accepts an explicitly resolved observation or unavailable; it must not read a database or guess this balance.'}}
data=(json.dumps(fixture,indent=2,ensure_ascii=False)+'\n').encode()
for target in [HERE/'x13-aggregate-independent-vectors.json', BASE/'web/packages/core/test/fixtures/sale-return-incoming-aggregate.v1.json']:
    target.parent.mkdir(parents=True,exist_ok=True)
    if target.exists():
        raise RuntimeError(f'Refusing to overwrite existing frozen fixture: {target}')
    target.write_bytes(data)
print('aggregate',len(aggregate),'bill',len(bills),'composite',len(fixture['compositeVectors']))
print('sha256',sha256(data).hexdigest())
