from pathlib import Path
import copy,hashlib,json
p=Path('/tmp/datacare-round15-save-guards')
version='saved-return-save-guards-v1'; profile='qualified-saved-incoming-zero-cash-non-e-v1'
guards=['entry-mode','new-entry-license','employee-required','defaulter','cash-limit','employee-required-repeat','cheque-bank','card-bank','new-entry-company-type','new-entry-clock','year-range','lock-date','ordinary-edit','voucher-number','counter-required','save-fold','amount-nonzero','profile']
base_outcomes=['passed','not-applicable','passed','passed','not-applicable','passed','passed','passed','not-applicable','not-applicable','passed','passed','passed','passed','passed','passed','passed','passed']
def q(value): return {'status':'qualified','revision':'source-observation-r1','binding':'observation-1','value':value}
m=[['']*6 for _ in range(9)]
m[0]=['','Sale Return','%','Payment','Received','Code']
m[1][3]='100.00';m[2][2]='0.00';m[2][3]='0.00';m[3][3]='100.00';m[8][3]='100.00'
for row in range(4,8):m[row][3]='0.00';m[row][4]='0.00'
base={'provenance':{'documentIdentity':'saved-return-1','documentVersion':'document-v1','observationId':'observation-1'},'observations':{
'entry':q({'mode':'E','voucherNo':'00017','savedVoucherNo':'00017','hiddenVoucherNo':'00017','savedHiddenVoucherNo':'00017','instance':'17','employeeCode':'001','userUpdate':'N'}),
'employeeRule':q('Y'),'defaulter':q({'cardinality':'one','accountCode':'00002','rawFlag':'N'}),'cashLimit':q('0'),
'bill':q({'phase':'post-events-before-save-fold','nAcCrAmt':'100.00','nAcDrAmt':'0.00','matrix':m}),
'period':q({'voucherDate':'2025-06-15','openingDate':'2025-04-01','closingDate':'2026-03-31','lockDate':'2025-06-14'}),
'userEdit':q('Y'),'counterRule':q('Y'),'incomingRows':q([{'rowIdentity':'row-1','ordinal':1,'itemCode':'GOLD','counterCode':'01'}]),
'saveFold':q({'phase':'save-fold-outgoing-then-incoming-no-bill','upDown':False,'incomingFine18':'0.000','incomingNet38':'100.00','outgoingTotal24':'0.00'}),
'beforeBill':q({'matrix':copy.deepcopy(m)}),'edition':q('L'),'book':q({'mainBook':'SALES RETURNE','bookInout':'I'}),'freshUpdate':q(True)}}
cases=[]
def add(id,description,changes=None,status='ready',guard='profile',code=None,outcomes=None):
 x=copy.deepcopy(base)
 for path,value in (changes or []):
  target=x
  for key in path[:-1]:target=target[key]
  target[path[-1]]=copy.deepcopy(value)
 states=list(base_outcomes)
 for name,outcome in (outcomes or {}).items():states[guards.index(name)]=outcome
 if status!='ready':states[guards.index(guard)]=status
 checks=[{'guard':g,'outcome':states[i]} for i,g in enumerate(guards[:guards.index(guard)+1])]
 expected={'version':version,'profile':profile,'canCommit':False,'status':status,'diagnostic':None if code is None else {'code':code,'guard':guard},'checks':checks,'observation':copy.deepcopy(x)}
 cases.append({'id':id,'description':description,'input':x,'expected':expected})
def v(group,*keys):return ['observations',group,'value',*keys]
def unavailable(group):return (['observations',group],{'status':'unavailable','revision':'unknown-r1','reason':'Provider not qualified'})
add('G01','Ordinary saved positive incoming guards satisfied; no commit authority.')
add('G02','Opening boundary inclusive.',[(v('period','voucherDate'),'2025-04-01'),(v('period','lockDate'),'2025-03-31')])
add('G03','Closing boundary inclusive.',[(v('period','voucherDate'),'2026-03-31')])
add('G04','Before opening rejects.',[(v('period','voucherDate'),'2025-03-31')],'source-rejected','year-range','voucher-outside-year')
add('G05','After closing rejects.',[(v('period','voucherDate'),'2026-04-01')],'source-rejected','year-range','voucher-outside-year')
add('G06','Equal lock rejects.',[(v('period','lockDate'),'2025-06-15')],'source-rejected','lock-date','voucher-locked')
add('G07','Later lock rejects.',[(v('period','lockDate'),'2025-06-16')],'source-rejected','lock-date','voucher-locked')
add('G08','Leap day2000 valid.',[(v('period','voucherDate'),'2000-02-29'),(v('period','openingDate'),'2000-01-01'),(v('period','closingDate'),'2000-12-31'),(v('period','lockDate'),'2000-02-28')])
add('G09','Nonleap1900 refuses qualification.',[(v('period','voucherDate'),'1900-02-29')],'unsupported','year-range','unsupported-date')
add('G10','Mandatory blank employee rejects before unavailable account/date.',[(v('entry','employeeCode'),''),unavailable('defaulter'),unavailable('period')],'source-rejected','employee-required','employee-required')
add('G11','Non-Y employee rule permits exact blank employee.',[(v('employeeRule'),'N'),(v('entry','employeeCode'),'')])
add('G12','NULL rule concat is empty, not Y.',[(v('employeeRule'),None),(v('entry','employeeCode'),'')])
add('G13','Lowercase y is not source Y.',[(v('employeeRule'),'y'),(v('entry','employeeCode'),'')])
add('G14','Space employee is nonblank to source but outside canonical profile.',[(v('entry','employeeCode'),' ')],'unsupported','profile','noncanonical-code')
add('G15','Defaulter receivedOS positive rejects, paymentOS irrelevant.',[(v('defaulter','rawFlag'),'Y'),(v('bill','matrix',8,4),'0.01')],'source-rejected','defaulter','defaulter-received-outstanding')
add('G16','Defaulter with receivedOS0 and paymentOS100 passes.',[(v('defaulter','rawFlag'),'Y')])
add('G17','NULL defaulter flag concat is empty.',[(v('defaulter','rawFlag'),None)])
add('G18','Lowercase y does not source-reject positive receivedOS; profile refuses it.',[(v('defaulter','rawFlag'),'y'),(v('bill','matrix',8,4),'1')],'unsupported','profile','nonzero-received-or-tender')
add('G19','Missing account cannot borrow desktop no-row flagN as admission.',[(v('defaulter','cardinality'),'none')],'unsupported','defaulter','account-observation-unqualified')
add('G20','Duplicate defaulter rows have unproved selection.',[(v('defaulter','cardinality'),'multiple')],'unsupported','defaulter','account-observation-unqualified')
add('G21','Positive cash limit needs exact all-year cash reader even newcash0.',[(v('cashLimit'),'100')],'unsupported','cash-limit','cash-ledger-observation-required')
add('G22','NULL cash setting is not zero.',[(v('cashLimit'),None)],'unsupported','cash-limit','unsupported-decimal')
add('G23','Blank cash setting is not zero.',[(v('cashLimit'),'')],'unsupported','cash-limit','unsupported-decimal')
add('G24','Negative limit skips source check but is outside namedzero profile.',[(v('cashLimit'),'-1')],'unsupported','profile','unsupported-cash-limit')
add('G25','Special00045 skips positive-limit source call; ordinaryprofile refuses.',[(v('cashLimit'),'100'),(v('defaulter','accountCode'),'00045')],'unsupported','profile','special-account')
add('G26','Zero config preserves signed/scale text.',[(v('cashLimit'),' -0.000 ')])
add('G27','Cheque sum nonzero and blank code rejects before invaliddate.',[(v('bill','matrix',4,3),'1'),(v('period','voucherDate'),'bad')],'source-rejected','cheque-bank','bank-account-required')
add('G28','Opposite cheque amounts cancel source sum; profile stillrefuses tenders.',[(v('bill','matrix',4,3),'1'),(v('bill','matrix',4,4),'-1')],'unsupported','profile','nonzero-received-or-tender')
add('G29','Card sum nonzero blank code rejects.',[(v('bill','matrix',5,4),'0.01')],'source-rejected','card-bank','card-account-required')
add('G30','Nonzero cheque with selected code passes source; profile refuses.',[(v('bill','matrix',4,3),'1'),(v('bill','matrix',4,5),'BANK')],'unsupported','profile','nonzero-received-or-tender')
add('G31','Ordinary edit denied when both flags nonY.',[(v('userEdit'),'N')],'source-rejected','ordinary-edit','source-edit-denied')
add('G32','StoredY bypasses source UserEdit but not finiteprofile or fresh authority.',[(v('entry','userUpdate'),'Y'),unavailable('userEdit')],'unsupported','profile','stored-update-override',{'ordinary-edit':'not-applicable'})
add('G33','Stored blank is nonY and source UserEditY permits, finiteprofile requiresN.',[(v('entry','userUpdate'),'')],'unsupported','profile','stored-update-override')
add('G34','Blank voucher source rejects before unavailable row scope.',[(v('entry','voucherNo'),''),unavailable('incomingRows')],'source-rejected','voucher-number','voucher-required')
add('G35','Mandatory counter includes every nonblank item.',[(v('incomingRows'),[{'rowIdentity':'row-1','ordinal':1,'itemCode':'GOLD','counterCode':'01'},{'rowIdentity':'row-2','ordinal':2,'itemCode':'SILVER','counterCode':''}])],'source-rejected','counter-required','counter-required')
add('G36','Blank trailing item does not require counter.',[(v('incomingRows'),[{'rowIdentity':'row-1','ordinal':1,'itemCode':'GOLD','counterCode':'01'},{'rowIdentity':'trailing','ordinal':2,'itemCode':'','counterCode':''}])])
add('G37','NULL counter rule concat is empty; counter blank allowed.',[(v('counterRule'),None),(v('incomingRows',0,'counterCode'),'')],outcomes={'counter-required':'not-applicable'})
add('G38','Amountsum and fine0 rejects.',[(v('bill','nAcCrAmt'),'0.00'),(v('saveFold','incomingNet38'),'0.00')],'source-rejected','amount-nonzero','item-value-required')
add('G39','Fine can change zeroamount predicate: no inferred registration.',[(v('bill','nAcCrAmt'),'0'),(v('saveFold','incomingFine18'),'1')],'unsupported','amount-nonzero','fine-branch-unqualified')
add('G40','Negative fine cancellation makes registration branch matter.',[(v('saveFold','incomingFine18'),'-100')],'unsupported','amount-nonzero','fine-branch-unqualified')
add('G41','Positive fine leaves both source predicates pass but finiteprofile refuses.',[(v('saveFold','incomingFine18'),'1')],'unsupported','profile','unsupported-fine')
add('G42','Savefold does not replace retained rounded credit by net.',[(v('saveFold','incomingNet38'),'100.49')])
add('G43','Changed phase refuses before evaluating amount.',[(v('saveFold','phase'),'invented-final-bill')],'unsupported','save-fold','unsupported-save-phase')
add('G44','Unknown edition later cannot mask lock rejection.',[(v('period','lockDate'),'2025-06-15'),unavailable('edition')],'source-rejected','lock-date','voucher-locked')
add('G45','EditionE requires source audit not implemented.',[(v('edition'),'E')],'unsupported','profile','edition-audit-required')
add('G46','Unknown edition is not guessed.',[unavailable('edition')],'unsupported','profile','observation-unavailable')
add('G47','All other reached source editions admitted as supplied facts only.',[(v('edition'),'A')])
add('G48','Wrong book family not normalized.',[(v('book','mainBook'),'SALES RETURN')],'unsupported','profile','unsupported-book')
add('G49','Outgoing book excluded.',[(v('book','bookInout'),'O')],'unsupported','profile','unsupported-book')
add('G50','FreshUpdate false cannot inherit source flags authority.',[(v('freshUpdate'),False)],'unsupported','profile','fresh-update-required')
add('G51','Unchanged voucher identity required.',[(v('entry','savedVoucherNo'),'00018')],'unsupported','profile','saved-identity-mismatch')
add('G52','Zero instance is not allocated.',[(v('entry','instance'),'0')],'unsupported','profile','unsupported-instance')
add('G53','Create mode is outside evaluator, no license authority invented.',[(v('entry','mode'),'A')],'unsupported','entry-mode','saved-edit-required')
add('G54','Unknown employee config blocks reached check.',[unavailable('employeeRule')],'unsupported','employee-required','observation-unavailable')
add('G55','Unknown source bill after first employee check blocks defaulter.',[unavailable('bill')],'unsupported','defaulter','observation-unavailable')
add('G56','Wrong consumed binding refuses.',[(['observations','cashLimit','binding'],'other-observation')],'unsupported','cash-limit','observation-binding-mismatch')
add('G57','Before-state tender cannot be hidden by poststate0.',[(v('beforeBill','matrix',6,3),'1')],'unsupported','profile','nonzero-received-or-tender')
add('G58','UpDown is outside finite Save-fold profile.',[(v('saveFold','upDown'),True)],'unsupported','profile','unsupported-updown')
add('G59','Negative receivedOS does not source-reject but profile refuses.',[(v('defaulter','rawFlag'),'Y'),(v('bill','matrix',8,4),'-1')],'unsupported','profile','nonzero-received-or-tender')
add('G60','Exact large integer guard values avoid Number loss.',[(v('bill','nAcCrAmt'),'999999999999999999999999999999999999'),(v('saveFold','incomingNet38'),'999999999999999999999999999999999999')])
add('G61','UI blank OS means0; SQLNULL OS remains unsupported.',[(v('bill','matrix',8,4),None)],'unsupported','defaulter','unsupported-decimal')
add('G62','Calendar maximum date valid.',[(v('period','voucherDate'),'9999-12-31'),(v('period','openingDate'),'9999-01-01'),(v('period','closingDate'),'9999-12-31'),(v('period','lockDate'),'9999-12-30')])
add('G63','Partial fractional credit is not a rounded source credit projection.',[(v('bill','nAcCrAmt'),'100.01')],'unsupported','profile','unsupported-return-totals')
add('G64','Required source phase cannot be invented.',[(v('bill','phase'),'saved-raw')],'unsupported','defaulter','unsupported-bill-phase')
fixture={'kind':'saved-return-save-guard-independent-v1','authorship':'Literal expected outcomes before any new evaluator source; not calculated by reducer/service. All canCommitfalse.','sourceReferences':['TR_SALE_RTN.cs:10614,12117-12407,13467-13567,16381-16458','DC_Main.cs:2149-2163,2258-2271','MS_OPNCOMP.cs:601-604,666,710-713,952'],'cases':cases}
f=p/'web/packages/core/test/fixtures/saleReturnSaveGuards.independent.json';f.write_text(json.dumps(fixture,indent=2)+'\n')
root=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
sources=['unified/src/csharp/DataCareNext/TR_SALE_RTN.cs','unified/src/csharp/DataCareNext/DC_Main.cs','unified/src/csharp/DataCareNext/MS_OPNCOMP.cs','web/packages/db/prisma/schema.prisma','parity-plan-2026-09-10/evidence/implementation-2026-09-12-round14/save-guards-independent-review/review.md','parity-plan-2026-09-10/41-implementation-checkpoint-round14.json']
freeze={'status':'frozen-before-new-evaluator-code','caseCount':len(cases),'fixture':{'path':str(f.relative_to(p)),'sha256':hashlib.sha256(f.read_bytes()).hexdigest()},'contractSha256':hashlib.sha256((p/'implementation-contract.md').read_bytes()).hexdigest(),'sourceFiles':[{'path':str(root/n),'sha256':hashlib.sha256((root/n).read_bytes()).hexdigest()} for n in sources]}
(p/'fixture-freeze.json').write_text(json.dumps(freeze,indent=2)+'\n'); print(json.dumps(freeze,indent=2))
