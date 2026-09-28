from pathlib import Path
import json, hashlib, datetime
out=Path('/tmp/datacare-return-clock-round13-vectors')
base=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
provenance={'documentIdentity':'saved-return:tenant-test/01/01/2024/R13/00017','documentVersion':'physical-observation-v1:revision-17'}
def envelope(raw):
    return {'raw':raw, 'provenance':dict(provenance)}
valid={'VCH_DATE':'2024-07-10','VCH_TIME':'2024-07-09T12:00:00.900000'}
cases=[]
def add(id,reason,input,expected):
    cases.append({'id':id,'reason':reason,'input':input,'expected':expected})
def ready(id,reason,date,time,cutoff):
    add(id,reason,envelope({'VCH_DATE':date,'VCH_TIME':time}),{'status':'ready','cutoffLocalSecond':cutoff,'diagnostics':[],'retainsRawAndProvenance':True})
def bad(id,reason,field,value,code=None):
    raw=dict(valid); raw[field]=value
    add(id,reason,envelope(raw),{'status':'unsupported','cutoffLocalSecond':None,'diagnostics':[{'code':code or ('unsupported-saved-date' if field=='VCH_DATE' else 'unsupported-saved-time'),'sourceField':field}],'retainsRawAndProvenance':True})
# These expected strings are independently literal; no date/parser/implementation computes them.
for args in [
('R01','Whole seconds remain exact','2024-07-10','2024-07-10T12:34:56','2024-07-10 12:34:56'),
('R02','Date comes from VCH_DATE when saved timestamp has prior day','2024-07-10','2024-07-09T12:00:00.900000','2024-07-10 12:00:00'),
('R03','Future timestamp date never replaces voucher date','2024-01-01','2025-12-31T23:59:59.999999','2024-01-01 23:59:59'),
('R04','Midnight fraction does not round or change saved date','2024-12-31','2024-12-31T23:59:59.999999','2024-12-31 23:59:59'),
('R05','Lower Gregorian boundary','0001-01-01','0001-01-01T00:00:00','0001-01-01 00:00:00'),
('R06','Upper Gregorian boundary with no rounding overflow','9999-12-31','9999-12-31T23:59:59.999999','9999-12-31 23:59:59'),
('R07','Timestamp day is independently valid even far from voucher day','9999-12-31','0001-01-01T00:00:00.000001','9999-12-31 00:00:00'),
('R08','Leap year divisible by four','2024-02-29','2024-02-29T01:02:03.000004','2024-02-29 01:02:03'),
('R09','Year divisible by 400 is leap','2000-02-29','2000-02-29T06:07:08','2000-02-29 06:07:08'),
('R10','Later 400-year leap boundary','2400-02-29','2400-02-29T09:10:11','2400-02-29 09:10:11'),
('R11','1900 February28 remains valid','1900-02-28','1900-02-28T12:13:14','1900-02-28 12:13:14'),
('R12','2100 February28 remains valid','2100-02-28','2100-02-28T15:16:17','2100-02-28 15:16:17'),
('R13','One fractional digit discarded','2024-07-10','2024-07-09T12:00:00.9','2024-07-10 12:00:00'),
('R14','Two fractional digits discarded','2024-07-10','2024-07-09T12:00:00.99','2024-07-10 12:00:00'),
('R15','Three fractional digits discarded','2024-07-10','2024-07-09T12:00:00.999','2024-07-10 12:00:00'),
('R16','Four fractional digits discarded','2024-07-10','2024-07-09T12:00:00.9999','2024-07-10 12:00:00'),
('R17','Five fractional digits discarded','2024-07-10','2024-07-09T12:00:00.99999','2024-07-10 12:00:00'),
('R18','Six fractional digits discarded','2024-07-10','2024-07-09T12:00:00.999999','2024-07-10 12:00:00'),
('R19','All-zero fraction retained raw','2024-07-10','2024-07-09T12:00:00.000000','2024-07-10 12:00:00'),
('R20','Clock at apparent DST gap is a local value without timezone conversion','2024-03-10','2024-03-10T02:30:00','2024-03-10 02:30:00'),
('R21','Clock at apparent DST overlap is not disambiguated with a timezone','2024-11-03','2024-11-03T01:30:00','2024-11-03 01:30:00'),
('R22','Gregorian lower-century valid leap year','0004-02-29','0004-02-29T23:00:01','0004-02-29 23:00:01'),
('R23','Negative UTC-offset-looking day mismatch has no implicit shift','2024-07-10','2024-07-11T00:00:00.000001','2024-07-10 00:00:00'),
('R24','Timestamp leap date valid while voucher date is ordinary','2023-03-01','2024-02-29T23:59:59.999999','2023-03-01 23:59:59')]: ready(*args)
for num,(value,reason) in enumerate([
('0000-01-01','Year zero refused'),('10000-01-01','Five-digit year refused'),('-0001-01-01','BC/negative year refused'),
('2023-02-29','Non-leap February29'),('1900-02-29','Century not divisible by400'),('2100-02-29','Future century not divisible by400'),
('2024-00-10','Month zero'),('2024-13-10','Month13'),('2024-01-00','Day zero'),('2024-01-32','Day32'),('2024-04-31','April31'),('2024-02-30','February30'),
('2024-7-10','Unpadded month'),('2024-07-1','Unpadded day'),('024-07-10','Three-digit year'),('2024-07-10T00:00:00','Date column cannot contain timestamp'),('2024-07-10 00:00:00','Date column SQL timestamp refused'),
('20240710','Compact date refused'),('07/10/2024','Locale date refused'),('10/07/2024','Ambiguous locale date refused'),('2024-07-10Z','Date offset suffix refused'),
(' 2024-07-10','No leading trim'),('2024-07-10 ','No trailing trim'),('2024-07-10\n','Terminal newline is not accepted by regex end anchor'),('2024-07-10\r','Carriage return refused'),('2024-07-10\u2028','Unicode line separator refused'),('\u00a02024-07-10','Unicode nonbreaking space refused'),
('infinity','Positive infinity refused'),('-infinity','Negative infinity refused'),('','Blank date not defaulted'),(' ','Space-only date not defaulted'),('２０２４-０７-１０','Fullwidth Unicode digits refused')],1): bad('D%02d'%num,reason,'VCH_DATE',value)
for num,(value,reason) in enumerate([
('0000-01-01T00:00:00','Timestamp year zero refused although day not used'),('10000-01-01T00:00:00','Timestamp year10000 refused'),('2023-02-29T12:00:00','Invalid timestamp leap day refused'),('1900-02-29T12:00:00','Invalid timestamp century leap day refused'),('2100-02-29T12:00:00','Invalid future timestamp century leap day refused'),
('2024-00-10T12:00:00','Timestamp month zero'),('2024-13-10T12:00:00','Timestamp month13'),('2024-07-00T12:00:00','Timestamp day zero'),('2024-07-32T12:00:00','Timestamp day32'),('2024-04-31T12:00:00','Timestamp April31'),
('2024-07-09T24:00:00','Hour24 not normalized into next day'),('2024-07-09T25:00:00','Hour25'),('2024-07-09T12:60:00','Minute60'),('2024-07-09T12:00:60','Second60 / leap-second normalization refused'),('2024-07-09T-1:00:00','Negative hour'),
('2024-07-09T1:02:03','Unpadded hour'),('2024-07-09T01:2:03','Unpadded minute'),('2024-07-09T01:02:3','Unpadded second'),('2024-7-09T01:02:03','Unpadded timestamp month'),('2024-07-9T01:02:03','Unpadded timestamp day'),
('2024-07-09 12:00:00','SQL-space timestamp is outside JSONB profile'),('2024-07-09t12:00:00','Lowercase separator refused'),('2024-07-09','Missing clock refused'),('12:00:00','Time-only fallback refused'),('2024-07-09T12:00','Missing seconds refused'),
('2024-07-09T12:00:00.','Empty fraction refused'),('2024-07-09T12:00:00.1234567','More than six fractional digits refused, not truncated'),('2024-07-09T12:00:00,123','Comma fraction refused'),('2024-07-09T12:00:00.1e2','Exponent fraction refused'),
('2024-07-09T12:00:00Z','UTC suffix refused'),('2024-07-09T12:00:00+05:30','Positive offset refused'),('2024-07-09T12:00:00-04:00','Negative offset refused'),('2024-07-09T12:00:00 UTC','Named zone refused'),
(' 2024-07-09T12:00:00','No leading trim'),('2024-07-09T12:00:00 ','No trailing trim'),('2024-07-09T12:00:00\n','Terminal newline refused'),('2024-07-09T12:00:00\r','Terminal carriage return refused'),('2024-07-09T12:00:00\u2028','Unicode line separator refused'),('2024-07-09T12:00:00\u0000','NUL refused'),
('infinity','Infinite timestamp refused'),('-infinity','Negative infinite timestamp refused'),('','Blank time never becomes midnight'),(' ','Space-only time never becomes midnight')],1): bad('T%02d'%num,reason,'VCH_TIME',value)
bad('N01','SQLNULL date is distinct from missing and blank','VCH_DATE',None,'null-saved-column')
bad('N02','SQLNULL time is distinct from missing and blank','VCH_TIME',None,'null-saved-column')
for id,raw,diagnostics,reason in [
('N03',{'VCH_TIME':valid['VCH_TIME']},[{'code':'missing-saved-column','sourceField':'VCH_DATE'}],'Missing own date key remains missing'),
('N04',{'VCH_DATE':valid['VCH_DATE']},[{'code':'missing-saved-column','sourceField':'VCH_TIME'}],'Missing own time key remains missing'),
('N05',{},[{'code':'missing-saved-column','sourceField':'VCH_DATE'},{'code':'missing-saved-column','sourceField':'VCH_TIME'}],'Both absent columns retained as empty raw'),
('N06',{'VCH_DATE':None,'VCH_TIME':None},[{'code':'null-saved-column','sourceField':'VCH_DATE'},{'code':'null-saved-column','sourceField':'VCH_TIME'}],'BothNULL have independent diagnoses'),
('N07',{'VCH_DATE':None},[{'code':'null-saved-column','sourceField':'VCH_DATE'},{'code':'missing-saved-column','sourceField':'VCH_TIME'}],'NULL and absent are not collapsed'),
('N08',{'VCH_DATE':'1900-02-29','VCH_TIME':'2024-07-09T24:00:00'},[{'code':'unsupported-saved-date','sourceField':'VCH_DATE'},{'code':'unsupported-saved-time','sourceField':'VCH_TIME'}],'Both malformed source fields diagnosed')]:
    add(id,reason,envelope(raw),{'status':'unsupported','cutoffLocalSecond':None,'diagnostics':diagnostics,'retainsRawAndProvenance':True})
invalids=[
(None,'Null input'),([], 'Array input'),({},'Missing raw and provenance'),
({'raw':dict(valid)},'Missing provenance'),({'provenance':dict(provenance)},'Missing raw'),
({'raw':None,'provenance':dict(provenance)},'Null raw envelope'),({'raw':[],'provenance':dict(provenance)},'Array raw envelope'),
({'raw':dict(valid),'provenance':None},'Null provenance'),({'raw':dict(valid),'provenance':[]},'Array provenance'),
({'raw':dict(valid),'provenance':dict(provenance),'representation':'jsonb'},'Extra wrapper key refused'),
(envelope({**valid,'CUT_OFF':'2024-07-10 12:00:00'}),'Client cutoff cannot supply a fallback'),
(envelope({**valid,'VCH_DATE':20240710}),'Numeric date is not coerced'),(envelope({**valid,'VCH_TIME':0}),'Numeric time is not coerced'),(envelope({**valid,'VCH_TIME':False}),'Boolean time is not coerced'),
({'raw':dict(valid),'provenance':{'documentIdentity':provenance['documentIdentity']}},'Missing document version'),
({'raw':dict(valid),'provenance':{**provenance,'clockStatus':'qualified'}},'Caller qualification cannot be supplied')]
for key in ['documentIdentity','documentVersion']:
    for value,why in [('', 'blank'),(' leading','leading space'),('trailing ','trailing space'),('line\nbreak','control character'),('é','nonASCII'),('x'*257,'over256'),(None,'NULL'),(42,'number')]:
        invalids.append(({'raw':dict(valid),'provenance':{**provenance,key:value}},key+' '+why))
for num,(input,reason) in enumerate(invalids,1):
    add('E%02d'%num,reason,input,{'status':'invalid-input','observation':None,'diagnosticCode':'invalid-input'})
fixture={
'formatVersion':1,
'fixtureId':'saved-sale-return-clock-independent-v1',
'implementationExport':'projectSavedSaleReturnClock',
'expectedVersion':'saved-sale-return-clock-v1',
'expectedProfile':'canonical-postgresql-jsonb-local-clock-v1',
'expectationMethod':'Literal source-derived cutoff strings and explicit approved-profile refusal cases, authored before implementation inspection. No date arithmetic library, adapter, reducer, compiler, DB, or browser generated an expected outcome.',
'expectedDiagnosticComparison':'Compare diagnostic code/sourceField as an unordered complete set; messages must be nonblank but literal prose is not part of this fixture.',
'rawObservationAssertions':'For every ready/unsupported result, raw and provenance deep-equal input, missing own raw keys remain absent, and returned data is deeply detached/frozen without mutating or freezing callers.',
'authorityLimits':['Opaque document provenance is retained, not authenticated.','This is a canonical current PostgreSQL JSONB profile; no Windows locale/SQL Server runtime equivalence is claimed.','No default date/time/midnight, timezone conversion, rounding, ledger query, live session authority, or bill-closing integration is introduced.'],
'sourceReferences':[
{'path':'unified/src/csharp/DataCareNext/TR_SALE_RTN.cs','lines':'10104-10106,10197','fact':'VCH_DATE supplies displayed day; VCH_TIME supplies formatted HH:mm:ss; concatenate for MsAcBal.'},
{'path':'unified/src/csharp/DataCareNext/DC_Main.cs','lines':'1463-1487','fact':'Ledger cutoff formatted to seconds; opening < and helper closing <= remain separate later-consumer semantics.'},
{'path':'web/packages/db/prisma/schema.prisma','lines':'5648-5649','fact':'Current SL_DATA VCH_DATE is @db.Date and VCH_TIME is @db.Timestamp(6).'}],
'cases':cases,
'nonJsonRuntimeCasesForLaterTests':[
{'id':'P01','construction':'getter on raw.VCH_DATE','expectation':'invalid-input, observation null, getter invocation count remains0'},
{'id':'P02','construction':'getter on provenance.documentVersion','expectation':'invalid-input, observation null, getter invocation count remains0'},
{'id':'P03','construction':'inherited raw.VCH_DATE on nonplain custom-prototype object','expectation':'invalid-input; inherited field cannot stand in for missing own observation'},
{'id':'P04','construction':'cycle in an otherwise malformed wrapper or raw value','expectation':'invalid-input without throwing'},
{'id':'P05','construction':'own symbol key at wrapper/raw/provenance','expectation':'invalid-input; exact plain data envelope cannot silently drop a key'},
{'id':'P06','construction':'nonenumerable extra own key at wrapper/raw/provenance','expectation':'invalid-input; exact plain data envelope cannot silently drop a key'},
{'id':'P07','construction':'NaN/Infinity as raw field or document provenance','expectation':'invalid-input without coercion'},
{'id':'P08','construction':'mutate caller raw/provenance after result; attempt to mutate nested returned data','expectation':'returned detached snapshot unchanged, all output containers frozen, caller containers were not frozen'},
{'id':'P09','construction':'same raw with different opaque document identities/versions','expectation':'same cutoff, each provenance retained exactly; no cross-call mutable state or authority claim'},
{'id':'P10','construction':'provenance values of exactly256 printable ASCII characters and internal printable spaces','expectation':'ready; only outer whitespace/nonprintable/overlimit are refused'}
]}
text=json.dumps(fixture,indent=2,ensure_ascii=True)+'\n'
p=out/'saved-sale-return-clock.v1.json';p.write_text(text)
refs=[]
for rel in ['unified/src/csharp/DataCareNext/TR_SALE_RTN.cs','unified/src/csharp/DataCareNext/DC_Main.cs','web/packages/db/prisma/schema.prisma','parity-plan-2026-09-10/evidence/implementation-2026-09-11-round12/x13-round12-handoff-and-remaining-acceptance.md']:
    f=base/rel; refs.append({'path':str(f),'sha256':hashlib.sha256(f.read_bytes()).hexdigest()})
authorship={'authoredAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'scope':'Temporary prospective Round13 artifact only; no workspace source/test/plan edits and no execution checks.','author':'/root/report_children','implementationInspected':False,'implementationStateAtFreeze':'Source owner explicitly reported no implementation yet and agreed to hold source implementation until fixture SHA signal.','fixture':{'path':str(p),'sha256':hashlib.sha256(p.read_bytes()).hexdigest(),'cases':len(cases),'ready':sum(x['expected']['status']=='ready' for x in cases),'unsupported':sum(x['expected']['status']=='unsupported' for x in cases),'invalidInput':sum(x['expected']['status']=='invalid-input' for x in cases),'prospectiveNonJsonRuntimeCases':10},'sources':refs,'commandsRunForValidation':[],'nonAcceptance':'No tests/compiler/database/browser/Windows runtime or auth/session integration credit.'}
(out/'vector-authorship.json').write_text(json.dumps(authorship,indent=2)+'\n')
print(json.dumps(authorship,indent=2))
