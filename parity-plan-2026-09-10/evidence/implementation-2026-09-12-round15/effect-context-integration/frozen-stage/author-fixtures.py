import json, copy, hashlib, pathlib, datetime
p=pathlib.Path('/tmp/datacare-round15-effect-context')
base={'header':{'VCH_DATE':'2026-09-12','VCH_TIME':'2026-09-12T13:04:05'},'incoming':{'CO_CODE':'01','LC_CODE':'01','CO_YEAR':'2026-2027','CO_BOOK':'R15','VCH_NO':'00001','SR_NO':'1','VCH_DATE':'2026-09-12','VCH_TIME':'2026-09-12T13:04:05'},'storageText':{'stockDateText':'2026-09-12','stockDiscountText':'0','taxZeroRatedText':'0'},'provenance':{'documentIdentity':'document-1','documentVersion':'document-version-1','rowIdentity':'incoming-1','observationIdentity':'observed-effects-1'}}
values={'acEntryTime':'2026-09-12T13:04:05','stockEntryDate':'2026-09-12','stockDateText':'2026-09-12','customerLedgerKey':'01012026-2027R150000101         1','saleLedgerKey':'01012026-2027R150000102         1','stockDiscountText':'0','taxZeroRatedText':'0'}
cases=[]
def ready(id,note,changes=(),output=None):
 b=copy.deepcopy(base)
 for section,key,value in changes:b[section][key]=value
 cases.append({'id':id,'note':note,'input':b,'expected':{'status':'ready','values':copy.deepcopy(values if output is None else output)}})
def refuse(id,note,section,key,value,code,field=None,delete=False):
 b=copy.deepcopy(base)
 if delete:del b[section][key]
 else:b[section][key]=value
 cases.append({'id':id,'note':note,'input':b,'expected':{'status':'unsupported','diagnostic':{'code':code,'field':field or section+'.'+key}}})
ready('C01','Finite source SR1: SQL STR defaults to length10, so nine literal spaces precede1; role01/02 source concatenation has no segment padding.')
ready('C02','All-zero fractional aliases denote the same saved-open whole second; original raw strings stay untouched.', [('header','VCH_TIME','2026-09-12T13:04:05.000000'),('incoming','VCH_TIME','2026-09-12T13:04:05.0')])
for id,day,time,note in [('C03','2000-02-29','00:00:00','Leap-century midnight local clock; no timezone conversion.'),('C04','2026-11-01','01:30:00','DST-looking local clock is not resolved to a timezone/instant.'),('C05','2026-09-12','23:59:59','Last whole second; no next-day rounding.')]:
 out={**values,'acEntryTime':day+'T'+time,'stockEntryDate':day,'stockDateText':day}
 ready(id,note,[('header','VCH_DATE',day),('header','VCH_TIME',day+'T'+time),('incoming','VCH_DATE',day),('incoming','VCH_TIME',day+'T'+time),('storageText','stockDateText',day)],out)
ready('C06','Single-character company/location/book are not padded or truncated; year10 fits current schema. This is an observation profile, not auth-year acceptance.', [('incoming','CO_CODE','A'),('incoming','LC_CODE','B'),('incoming','CO_YEAR','1234567890'),('incoming','CO_BOOK','R'),('incoming','VCH_NO','99999')],{**values,'customerLedgerKey':'AB1234567890R9999901         1','saleLedgerKey':'AB1234567890R9999902         1'})
for i,val in enumerate(['0','2','01','1.0','+1','-1','1e0','1 ',' 1','9999999999','10000000000','9007199254740993','NaN','1\n',None]):
 refuse('S'+str(i+1).zfill(2),'Finite SR1 profile refuses without Number, rounding, trimming or SQL STR overflow emulation.','incoming','SR_NO',val,'null-observation' if val is None else 'unsupported-serial')
refuse('S16','Absent serial remains absent; no default.', 'incoming','SR_NO',None,'missing-observation',delete=True)
for id,section,key,value,code in [
 ('D01','header','VCH_DATE',None,'null-observation'),('D02','incoming','VCH_DATE',None,'null-observation'),
 ('D03','header','VCH_DATE','1900-02-29','unsupported-clock'),('D04','incoming','VCH_TIME','2026-02-30T13:04:05','unsupported-clock'),
 ('D05','header','VCH_TIME','2026-09-12T13:04:05.000001','fractional-clock'),('D06','incoming','VCH_TIME','2026-09-12T13:04:05.999999','fractional-clock'),
 ('D07','header','VCH_TIME','2026-09-11T13:04:05','incoherent-clock'),('D08','incoming','VCH_DATE','2026-09-11','incoherent-clock'),
 ('D09','incoming','VCH_TIME','2026-09-12T13:04:06','incoherent-clock'),('D10','header','VCH_TIME','2026-09-12 13:04:05','unsupported-clock'),
 ('D11','header','VCH_TIME','2026-09-12T13:04:05Z','unsupported-clock'),('D12','header','VCH_TIME','2026-09-12T24:00:00','unsupported-clock'),
 ('D13','header','VCH_TIME','2026-09-12T13:04:05\n','unsupported-clock'),('D14','header','VCH_TIME','2026-09-12T13:04:05.0000000','unsupported-clock'),
 ('D15','header','VCH_DATE','0000-01-01','unsupported-clock'),('D16','header','VCH_DATE','2026-9-12','unsupported-clock'),
 ('D17','header','VCH_TIME',None,'null-observation')]:refuse(id,'Exact canonical PG clock and source saved-open coherence boundary.',section,key,value,code)
refuse('D18','Missing clock is not NULL or default midnight.','header','VCH_TIME',None,'missing-observation',delete=True)
for id,key,val in [('K01','CO_CODE','AAA'),('K02','LC_CODE','AAA'),('K03','CO_YEAR','12345678901'),('K04','CO_BOOK','AAAA'),('K05','VCH_NO','000001'),('K06','CO_BOOK','r15'),('K07','CO_CODE','0 '),('K08','CO_BOOK','R\n'),('K09','CO_YEAR','2026/2027'),('K10','CO_CODE',''),('K11','VCH_NO','1'),('K12','CO_CODE','０１')]:
 refuse(id,'No lossy concatenation normalization; strict bounded observed identity profile.','incoming',key,val,'unsupported-identity')
for id,key,val in [('T01','stockDateText','09/12/2026'),('T02','stockDateText','2026-09-11'),('T03','stockDiscountText','0.00'),('T04','taxZeroRatedText','0.0'),('T05','stockDateText',None),('T06','taxZeroRatedText',''),('T07','stockDiscountText','0\n')]:
 refuse(id,'Supplied exact current-storage witness qualification; no coercion or Windows-format inference.','storageText',key,val,'null-observation' if val is None else 'unsupported-storage-text')
refuse('T08','No fabricated zero for missing target observation.','storageText','taxZeroRatedText',None,'missing-observation',delete=True)
fixture={'version':'saved-return-effect-context-independent-v1','authorship':'All expected literals authored from cited source/schema and named conservative profile before implementation; no qualifier/calculator execution. Raw inputs fully expanded. Unsupported values intentionally exceed first-profile support rather than emulate general SQL STR.','cases':cases}
f=p/'web/packages/core/test/fixtures/saleReturnEffectContext.independent.json';f.write_text(json.dumps(fixture,indent=2)+'\n')
root=pathlib.Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
refs=[('unified/src/csharp/DataCareNext/TR_SALE_RTN.cs',[10104,10106,12607,12885,13100,13108,13928,13932,14115,14279,14557]),('unified/src/csharp/DataCareNext/Ac_Ledr.cs',[1324,1326]),('unified/src/csharp/DataCareNext/Ac_Stock.cs',[247]),('unified/src/csharp/DataCareNext/Ac_Rojmel.cs',[586,588]),('unified/src/csharp/DataCareNext/Ac_Tax.cs',[]),('web/packages/db/prisma/schema.prisma',[10,20,35,768,769,804,805,806,3866,3867,3898,3906,5609,5610,5655,5656,5874,5876,5880,6664]),('web/packages/core/src/savedSaleReturnClock.ts',[1,4]),('web/packages/core/src/saleReturnNBarCompanions.ts',[1,4]),('parity-plan-2026-09-10/evidence/implementation-2026-09-12-round14/return-save-effects-analysis/effects-contract.md',[23,32,33,72,86])]
source=[]
for path,lines in refs:
 q=root/path
 if q.exists():source.append({'path':str(q),'sha256':hashlib.sha256(q.read_bytes()).hexdigest(),'criticalLines':lines})
(p/'source-inputs.json').write_text(json.dumps({'references':source,'documentation':[{'url':'https://learn.microsoft.com/en-us/sql/t-sql/functions/str-transact-sql?view=sql-server-ver17','use':'STR default length10/decimal0 and right justification; finite exact integer1 has no rounding. No SQL Server harness executed.'}]},indent=2)+'\n')
(p/'fixture-freeze.json').write_text(json.dumps({'frozenAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'fixture':str(f.relative_to(p)),'sha256':hashlib.sha256(f.read_bytes()).hexdigest(),'cases':len(cases),'ready':sum(c['expected']['status']=='ready' for c in cases),'sourceSha256':hashlib.sha256((p/'source-inputs.json').read_bytes()).hexdigest(),'implementationPresent':False},indent=2)+'\n')
print((p/'fixture-freeze.json').read_text())
