"""Expand literal baselines/patches only. No reducer imports or arithmetic oracle.
Every expected amount below was independently calculated from primary source.
Refuses to overwrite the frozen fixture; no product files are read or written.
"""
import copy
import json
from pathlib import Path

HERE = Path(__file__).parent
OUT = HERE / 'labour-compose-independent.v1.json'
assert not OUT.exists(), 'Preserve frozen fixture bytes'
clone = copy.deepcopy
CACHE = ['45', '46', '47', '48', '49', '58', '66', '67']
COLS = ['9', '10', '11', '12', '15', '18', '20', '24', '27', '42', '28', '36', '38', '35']
SCOPE = {'tenantId': 'compose-literal', 'coCode': '01'}
POLICY = {'saleAmountType': 'N', 'labourRoundingDecimals': 2, 'labourIncludesGhat': False,
          'generateLabourRate': False, 'fineColumnWidth': 100}
CONTEXT = {'taxRoundingDecimals': 2, 'editOpen': False, 'upDown': False,
           'openingBalance': {'status': 'unavailable', 'reason': 'trusted-opening-unavailable'}}
ROW_ID = 'saved-return-2024-R13-00017-SR17-OLD31'

def prior_event(row_id):
    return {'kind': 'leaveCell', 'rowIdentity': row_id, 'column': 3, 'text': 'Retained description',
            'context': {'currentRow': 1 if row_id == ROW_ID else 2, 'clearing': False,
                        'editorVisible': True, 'committedColumnWidth': 100}}

visible = {str(c): '' for c in range(71) if str(c) not in CACHE}
visible.update({'0': '1', '1': 'IT001', '3': 'Retained description', '9': '1',
                '10': '10.000', '11': '0.000', '12': '10.000', '13': 'AA', '14': '0.00',
                '15': '0.000', '16': '100.00', '17': '0.00', '18': '10.000', '19': '10.00',
                '20': '100.00', '21': '0.00', '22': 'N', '23': '1.00', '24': '10.00',
                '25': '0.00', '26': '0.00', '27': '0.00', '28': '0.00', '29': 'TA',
                '30': '0.00', '31': '0.00', '32': '0.00', '33': '0.00', '34': '0.00',
                '35': '0.00', '36': '110.00', '37': '0.00', '38': '110.00', '40': '17',
                '41': '777.00', '42': '0.000', '43': 'P', '44': 'I', '51': '31', '69': 'raw-photo-key'})
caches = {'45': '10.000', '46': '10.000', '47': '100.00', '48': '0.00',
          '49': '10.00', '58': '1.00', '66': '0.00', '67': '0.00'}
row = {'ordinal': 1, 'state': {'rowIdentity': ROW_ID,
       'raw': {'tenant_id': SCOPE['tenantId'], 'CO_CODE': '01', 'CO_YEAR': '2024-2025',
               'CO_BOOK': 'R13', 'VCH_NO': '00017', 'SR_NO': '17', 'OLD_SRNO': '31',
               'TAG_LBR_CODE': None, 'LBR_CODE': 'AA', 'EXACT_IMPORT': '9007199254740993.123456'},
       'visible': visible, 'caches': caches,
       'journal': [{'event': prior_event(ROW_ID), 'calculated': False, 'policy': clone(POLICY)}]}}
matrix = [['' for _ in range(6)] for _ in range(9)]
matrix[0][3] = 'Payment    '; matrix[0][4] = 'Received    '
for i, label in enumerate(['Net Amt : ', 'Sale Tax : ', 'Total Amt : ', 'Cheque Amt : ',
                           'Card Amt : ', 'Cash Amt : ', 'Kasar Amt : ', 'Os Amt : '], 1):
    matrix[i][0] = label
matrix[1][3] = '110.00'; matrix[2][2] = '10.00'; matrix[2][3] = '7.00'
matrix[3][3] = '117.00'; matrix[8][3] = '117.00'
matrix[4][1] = 'Saved bank label'; matrix[4][5] = '001234'

def totals(values, counters=('0', '0')):
    assert len(values) == 14
    cells = {str(c): '' for c in range(71)}
    cells['0'] = 'retained-total-c0'; cells['5'] = 'Total :'
    cells.update(dict(zip(COLS, values)))
    return {'cells': cells, 'totCrFine': counters[0], 'prOthAmtLess': counters[1]}

T110 = ['1','10.000','0.000','10.000','0.000','10.000','100.00','10.00','0.00','0.000','0.00','110.00','110.00','0.00']
BASE = {'version': 'primary-incoming-aggregate-decimal-v1',
        'raw': {'tenant_id': SCOPE['tenantId'], 'CO_CODE': '01', 'CO_YEAR': '2024-2025',
                'CO_BOOK': 'R13', 'VCH_NO': '00017', 'VCH_TIME': '2024-07-10T12:34:56.123456',
                'RTN_NET_AMT': '110.0000', 'TAX_AMT': '7.0000', 'IMPORTED_NULL': None},
        'rows': [row], 'totals': totals(T110, ('7.125', '3.50')),
        'bill': {'matrix': matrix, 'oldNetAmt': '110.0000', 'oldTaxPrc': '10.0',
                 'outgoingRounded': '0.00', 'incomingRounded': '110.00',
                 'closing': {'status': 'unavailable', 'amount': None, 'label': None,
                             'color': 'red', 'reason': 'trusted-opening-unavailable'}},
        'outgoingTotal24': '0.00',
        'journal': [{'event': prior_event(ROW_ID), 'rowPolicy': clone(POLICY), 'context': clone(CONTEXT),
                     'rowCalculated': False, 'aggregateApplied': False, 'billApplied': False,
                     'taxRecalculated': False}]}

def command(state=BASE, field=13, code='BB', category='01 labour', value='2', row_id=ROW_ID):
    return {'state': clone(state), 'scope': clone(SCOPE), 'rowIdentity': row_id, 'field': field,
            'editorText': code, 'expectedObservationVersion': 'a'*64,
            'observation': {'version': 'incoming-labour-master-observation-v1', 'scope': clone(SCOPE),
                'enteredCode': code, 'complete': True, 'observationVersion': 'a'*64,
                'masters': [{'raw': {'tenant_id': SCOPE['tenantId'], 'CO_CODE': '01', 'LBR_CODE': code,
                                     'LBR_CATG': category, 'LBR_VAL': value, 'UNUSED': None},
                             'revision': '101', 'locator': '(42,7)'}]},
            'rowPolicy': clone(POLICY), 'context': clone(CONTEXT)}

def event_for(cmd):
    return {'kind': 'calculateAfterCopy', 'rowIdentity': cmd['rowIdentity'], 'activeColumn': cmd['field'],
            'editorText': cmd['editorText'], 'cause': 'labourCodeSelection' if cmd['field'] == 13 else 'tagLabourCodeSelection'}

def payment_bill(prior, net, tax, total, old_net, old_tax, outgoing='0.00'):
    result = clone(prior)
    m = result['matrix']; m[1][3] = net; m[1][4] = ''; m[2][3] = tax; m[3][3] = total; m[8][3] = total
    for r in range(2,9): m[r][4] = ''
    result.update(oldNetAmt=old_net, oldTaxPrc=old_tax, incomingRounded=net, outgoingRounded=outgoing)
    return result

def expected(cmd, patch, cache_patch, total_values, bill, tax_recalculated, aggregate=True):
    result = clone(cmd['state']); e = event_for(cmd)
    selected = next(r['state'] for r in result['rows'] if r['state']['rowIdentity'] == cmd['rowIdentity'])
    selected['visible'].update(patch); selected['caches'].update(cache_patch)
    selected['journal'].append({'event': clone(e), 'calculated': True, 'policy': clone(cmd['rowPolicy'])})
    if aggregate: result['totals'] = totals(total_values)
    result['bill'] = clone(bill)
    result['journal'].append({'event': e, 'rowPolicy': clone(cmd['rowPolicy']), 'context': clone(cmd['context']),
                              'rowCalculated': True, 'aggregateApplied': aggregate, 'billApplied': True,
                              'taxRecalculated': tax_recalculated})
    return result

cases=[]
def ready(id, note, cmd, patch, cache_patch, ts, bill, tax, aggregate=True):
    result=expected(cmd,patch,cache_patch,ts,bill,tax,aggregate)
    cases.append({'id': id, 'note': note, 'input': cmd,
                  'expected': {'outcome': 'applied', 'state': result, 'aggregateApplied': aggregate,
                               'billApplied': True, 'taxRecalculated': tax,
                               'rowJournalAdded': 1, 'aggregateJournalAdded': 1}})
    return result
def refused(id,note,cmd,origin,code,outcome='rejected'):
    cases.append({'id':id,'note':note,'input':cmd,'expected':{'outcome':outcome,
                  'diagnosticOrigin':origin,'dependencyCode':code,'state':clone(cmd['state']),
                  'rowJournalAdded':0,'aggregateJournalAdded':0}})

CLEAR={'21':'','14':'','17':'','28':''}
T120=['1','10.000','0.000','10.000','0.000','10.000','100.00','20.00','0.00','0.000','0.00','120.00','120.00','0.00']
P120={**CLEAR,'13':'BB','23':'2.00','24':'20.00','36':'120.00','38':'120.00'}
C120={'58':'2.00','67':'0'}
B120=payment_bill(BASE['bill'],'120.00','12.00','132.00','120','10')
first=ready('L01','Changed incoming rate:10×2=20 labour;100+20=120; bill tax12/total132.',command(),P120,C120,T120,B120,True)
ready('L02','Same code still calculates; unchanged numeric bill caches retain exact text and manual tax7.',command(code='AA',value='1'),{}, {},T110,BASE['bill'],False)
ready('L03','Tag20% gives rate2 and tag labour20, but incoming total stays110.',command(field=29,code='TB',category='02 percent',value='20'),
      {'29':'TB','30':'20.00','31':'2.00','32':'20.00','35':''},{},T110,BASE['bill'],False)
ready('L04','Same tag code category04 has no destination but still invokes row/fold/bill.',command(field=29,code='TA',category='04 west',value='99'),{}, {},T110,BASE['bill'],False)
T100=['1','10.000','0.000','10.000','0.000','10.000','100.00','0.00','0.00','0.000','0.00','100.00','100.00','0.00']
ready('L05','Copied fixed labour5 is overwritten to0 because cleared rate0 differs retained cache1.',command(category='03 fixed',value='5'),
      {**CLEAR,'13':'BB','23':'','24':'0.00','36':'100.00','38':'100.00'},{'58':'0.00','67':'0'},T100,
      payment_bill(BASE['bill'],'100.00','10.00','110.00','100','10'),True)
same_cache=clone(BASE);same_cache['rows'][0]['state']['caches']['58']='0.00'
T105=['1','10.000','0.000','10.000','0.000','10.000','100.00','5.00','0.00','0.000','0.00','105.00','105.00','0.00']
ready('L06','With old rate cache0 and generationfalse, copied fixed5 survives; bill115.5 rounds half-even116.',command(same_cache,category='03 fixed',value='5'),
      {**CLEAR,'13':'BB','23':'','24':'5.00','36':'105.00','38':'105.00'},{},T105,
      payment_bill(BASE['bill'],'105.00','10.50','116.00','105','10'),True)
ready('L07','Incoming category06 forces K;10×1001/1000=10.01 rounds labour to10, manual bill tax remains7.',command(category='06 kilogram',value='1001'),
      {**CLEAR,'13':'BB','22':'K','23':'1001.00','24':'10.00'},{'58':'1001.00','67':'0'},T110,BASE['bill'],False)
TGHAT=['1','10.000','0.000','10.000','1.000','10.000','110.00','0.00','0.00','0.000','0.00','110.00','110.00','0.00']
ready('L08','Category05 sets ghat10%; loss1 precedes default net+loss metal110; unchanged fine caches leave fine10.',command(category='05 ghat',value='10'),
      {**CLEAR,'13':'BB','14':'10.00','15':'1.000','23':'','24':'0.00','20':'110.00'},{'58':'0.00','67':'0'},TGHAT,BASE['bill'],False)
up=command();up['context']['upDown']=True
ready('L09','UpDown keeps all old totals/counters; BILL_TOTAL still runs on retained110, manual tax7.',up,P120,C120,None,BASE['bill'],False,False)
negative=command();negative['state']['outgoingTotal24']='200.00'
received=clone(BASE['bill']);received['matrix'][1][3]='';received['matrix'][1][4]='80.00'
for r in range(2,9): received['matrix'][r][3]=''
received['matrix'][3][4]='80.00';received['matrix'][8][4]='80.00'
received.update(oldNetAmt='0',oldTaxPrc='10',incomingRounded='120.00',outgoingRounded='200.00')
ready('L10','Explicit synthetic outgoing200 gives received80; inactive payment cells clear after calculations.',negative,P120,C120,T120,received,True)
back=command(first,code='AA',value='1')
ready('L11','Second prefix returns rate to1/total110, but bill cache changed at prior prefix: tax11,total121, not manual7/117.',back,
      {**CLEAR,'13':'AA','23':'1.00','24':'10.00','36':'110.00','38':'110.00'},{'58':'1.00','67':'0'},T110,
      payment_bill(first['bill'],'110.00','11.00','121.00','110','10'),True)
row2=clone(row);rid2='saved-return-2024-R13-00017-SR42-OLD58';row2['ordinal']=2;row2['state']['rowIdentity']=rid2
row2['state']['raw'].update(SR_NO='42',OLD_SRNO='58');row2['state']['visible'].update({'0':'2','10':'2.000','12':'2.000','18':'2.000','20':'20.00','24':'2.00','36':'22.00','38':'22.00','40':'42','51':'58'})
row2['state']['caches'].update({'45':'2.000','46':'2.000'})
row2['state']['journal']=[{'event':prior_event(rid2),'calculated':False,'policy':clone(POLICY)}]
two=clone(BASE);two['rows'].append(row2)
two['totals']=totals(['2','12.000','0.000','12.000','0.000','12.000','120.00','12.00','0.00','0.000','0.00','132.00','132.00','0.00'])
two['bill']=payment_bill(BASE['bill'],'132.00','7.00','139.00','132.0000','10.0')
ready('L12','Select opaque SR42 row despite ordinal2; row17 unchanged. Labour14 total134 bill13.40 total147.',command(two,row_id=rid2),
      {**CLEAR,'13':'BB','23':'2.00','24':'4.00','36':'24.00','38':'24.00'},C120,
      ['2','12.000','0.000','12.000','0.000','12.000','120.00','14.00','0.00','0.000','0.00','134.00','134.00','0.00'],
      payment_bill(two['bill'],'134.00','13.40','147.00','134','10'),True)
ready('L13','Copy Format-style2dp of2.005 is2.01; later10×2.01 rounds whole labour20.',command(value='2.005'),
      {**P120,'23':'2.01'},{'58':'2.01','67':'0'},T120,B120,True)

r=command();r['expectedObservationVersion']='b'*64
refused('R01','Master observation mismatch restores exact pre-copy complete state.',r,'copy','observation-conflict')
r=command();r['observation']['masters']=[]
refused('R02','Missing master opens help in source: no copy, calculator or journal.',r,'copy','labour-lookup-required','lookup-required')
r=command();r['rowPolicy'].update(saleAmountType='F',fineColumnWidth=None)
refused('R03','Copy would clear six values, but row missing-width refusal must restore all six and code/cache/journals.',r,'calculation','row-calculation-rejected')
zero=clone(BASE);zero['rows'][0]['state']['visible'].update({'10':'0.000','12':'0.000','18':'0.000','23':'0.00'})
zero['rows'][0]['state']['caches'].update({'45':'0.000','46':'0.000','58':'0.00'})
r=command(zero,code='AA',category='03 fixed',value='5');r['rowPolicy']['generateLabourRate']=True
refused('R04','Same-code fixed5 with unchanged zero rate cache and net0 reaches inverse division zero after copy.',r,'calculation','row-calculation-rejected')
bad_sibling=clone(two);bad_sibling['rows'][1]['state']['visible']['42']='not-decimal'
r=command(bad_sibling)
refused('R05','Selected row calculates; sibling fold c42 fails. Restore both rows, totals, bill and both journals.',r,'calculation','invalid-decimal')
r=command();r['state']['bill']['matrix'][2][2]='not-decimal'
refused('R06','Row and fold succeed; bill tax parse fails. Pre-copy labour/code/cache state must survive.',r,'calculation','invalid-decimal')
r=command();r['state']['outgoingTotal24']='NaN'
refused('R07','Unknown outgoing decimal at bill boundary must not publish the earlier copy/fold.',r,'calculation','invalid-decimal')
r=command();alias=clone(r['observation']['masters'][0]);alias['raw']['LBR_CODE']='bb';alias['locator']='(42,8)';r['observation']['masters'].append(alias)
refused('R08','Exact/case alias collision is refused before copy.',r,'copy','ambiguous-labour-master')
r=command();r['rowIdentity']='unrelated-row'
refused('R09','No ordinal or first-row fallback when selected opaque identity is missing.',r,'input','row-identity-conflict')
r=command();r['context']['upDown']=None
refused('R10','Unsupported phase context cannot leave a successful copy or append an event.',r,'calculation','invalid-context')

payload={'kind':'atomic-incoming-labour-compose-independent-v1','status':'frozen-literal-preimplementation',
         'authorship':'Source-derived literal expectations; existing dependency implementations were read for interfaces, but no new composition implementation exists or was executed. Generator expands shapes/copies literal patches only; no arithmetic reducer is used.',
         'profile':'Exact-decimal mathematical existing core profile; no Windows runtime, authority, DB, HTTP, UI or write credit.',
         'baseline':BASE,'cases':cases,
         'runtimeBoundaryCases':['Getter command must not execute; preserve valid separately recoverable prior state.',
             'Cycles/custom prototypes/sparse arrays/nonfinite envelope values refuse without caller mutation.',
             'Mutation attempts against success/rejection outputs cannot mutate caller inputs.',
             'Exact complete old row and aggregate journal prefixes survive every downstream refusal.',
             'Invalid context/observation does not become permission merely because hashes match.'],
         'sourceRanges':['TR_SALE_RTN:4248–4319','TR_SALE_RTN:4322–4380','TR_SALE_RTN:4866–5158','TR_SALE_RTN:5162–5202','TR_SALE_RTN:16381–16458']}
OUT.write_text(json.dumps(payload,indent=2)+'\n')
print(f'Wrote {len(cases)} literal cases, not executed')
