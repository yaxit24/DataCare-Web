from pathlib import Path
import json,hashlib,datetime
out=Path('/tmp/datacare-session-context-next/independent-review')
root=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
base={'tenantId':'tx-fixture','coCode':'02'}
selected={**base,'loginName':'operator','isAdmin':False}
principal={**base,'loginName':'operator','loginCoCode':'01'}
def q(table,params,rows):return {'table':table,'params':params,'rows':rows}
def company(access=True,default='02'):
 return {'CO_CODE':'02','CO_NAME':'Fixture company','LC_CODE':default,'allowed':access}
def cq(operation,row=None,admin=False):
 return q('CO_MAST',['02','' if operation=='login' else 'operator',True if operation=='login' else admin],[] if row is None else [row])
def lq(rows=None,requested='',default='02'):
 return q('LOCT_MAST',['02',requested,default],rows if rows is not None else [{'LC_CODE':'02','LC_NAME':'Default branch'}])
def yq(rows=None,requested=''):
 return q('YEAR_MAST',['02',requested],rows if rows is not None else [{'year':'2024-2025'}])
cases=[]
def c(id,reason,operation,input,queries,value=None,error=None):
 ex={'value':value} if error is None else {'errorCode':error,'errorName':'ScopeError'}
 cases.append({'id':id,'reason':reason,'operation':operation,'input':input,'queries':queries,'expected':ex})
def scope(lc='02',year='2024-2025'):return {'tenantId':'tx-fixture','coCode':'02','lcCode':lc,'coYear':year}
c('S01','Missing company refuses before location/year','login',base,[cq('login')],error='company-unavailable')
c('S02','Ordinary selected company requires exact login membership','selected',selected,[cq('selected',company(False))],error='company-unavailable')
c('S03','Ordinary selected company with membership resolves all three queries','selected',selected,[cq('selected',company()),lq(),yq()],scope())
c('S04','Admin bypass is an explicit company-query parameter','selected',{**selected,'isAdmin':True},[cq('selected',company(),True),lq(),yq()],scope())
c('S05','Login resolver company query uses existing unconditional access path','login',base,[cq('login',company()),lq(),yq()],scope())
c('S06','Requested branch wins over company default','login',{**base,'lcCode':'07'},[cq('login',company()),lq([{'LC_CODE':'07'},{'LC_CODE':'02'}],requested='07'),yq()],scope('07'))
c('S07','Missing requested branch refuses before querying year','login',{**base,'lcCode':'99'},[cq('login',company()),lq([{'LC_CODE':'02'}],requested='99')],error='location-unavailable')
c('S08','Company default is supplied to SQL ordering; first returned row is used','login',base,[cq('login',company(default='07')),lq([{'LC_CODE':'07'},{'LC_CODE':'02'}],default='07'),yq()],scope('07'))
c('S09','Empty location master retains existing trimmed company-default fallback','login',base,[cq('login',company(default=' 07 ')),lq([],default='07'),yq()],scope('07'))
c('S10','Missing both location rows and company default refuses','login',base,[cq('login',company(default=None)),lq([],default='')],error='location-unavailable')
c('S11','With no company default SQL-ordered first branch is selected','login',base,[cq('login',company(default=None)),lq([{'LC_CODE':'01'},{'LC_CODE':'03'}],default=''),yq()],scope('01'))
c('S12','Requested historical year is exact and does not become latest','selected',{**selected,'coYear':'2020-2021'},[cq('selected',company()),lq(),yq([{'year':'2020-2021'},{'year':'2024-2025'}],requested='2020-2021')],scope(year='2020-2021'))
c('S13','Explicit unavailable year refuses even at login','login',{**base,'coYear':'1999-2000'},[cq('login',company()),lq(),yq([{'year':'2024-2025'}],requested='1999-2000')],error='year-unavailable')
c('S14','Login with no year retains incomplete scope without invented year','login',base,[cq('login',company()),lq(),yq([])],{'tenantId':'tx-fixture','coCode':'02','lcCode':'02'})
cases[-1]['expected']['ownUndefinedKeys']=['coYear']
c('S15','Selection with no year remains unavailable','selected',selected,[cq('selected',company()),lq(),yq([])],error='year-unavailable')
c('S16','Default year comes from first descending SQL observation','login',base,[cq('login',company()),lq(),yq([{'year':'2025-2026'},{'year':'2024-2025'}])],scope(year='2025-2026'))
c('S17','Requested branch is not silently trimmed','login',{**base,'lcCode':' 02 '},[cq('login',company()),lq([{'LC_CODE':'02'}],requested=' 02 ')],error='location-unavailable')
c('S18','Requested year is not silently trimmed','login',{**base,'coYear':' 2024-2025 '},[cq('login',company()),lq(),yq([{'year':'2024-2025'}],requested=' 2024-2025 ')],error='year-unavailable')
c('S19','Empty-string requested branch/year follow current default path','login',{**base,'lcCode':'','coYear':''},[cq('login',company()),lq(),yq()],scope())
c('S20','Year output is trimmed; OP_DATE-derived four-digit observation is retained','login',base,[cq('login',company()),lq(),yq([{'year':' 2024 '}])],scope(year='2024'))
def row(co='02',role='U',update='N',delete='N',print='N',reset='N'):
 return {'CO_CODE':co,'LOGIN_NAME':'operator','LOGIN_PWD':'fixture-not-authenticated','LOGIN_CATG':role,'USER_UPDATE':update,'USER_DELETE':delete,'USER_PRINT':print,'PASSWORD_RESET_REQUIRED':reset}
def pcase(id,reason,rows,role='U',owner='02',admin=False,rights=None,reset=False,error=False):
 ex={'errorName':'PrincipalUnavailableError','errorMessage':'principal-unavailable'} if error else {'value':{'loginName':'operator','loginCoCode':owner,'role':role,'isAdmin':admin,'rights':rights or {'userUpdate':False,'userDelete':False,'userPrint':False},'passwordResetRequired':reset}}
 cases.append({'id':id,'reason':reason,'operation':'principal','input':principal,'queries':[q('LOGIN_MAST',['operator','02','01'],rows)],'expected':ex})
pcase('P01','Selected company credential owns effective rights even when login-company credential is admin',[row(update='Y',print='1',reset='y'),row(co='01',role='A')],rights={'userUpdate':True,'userDelete':False,'userPrint':True},reset=True)
pcase('P02','Absent selected credential falls back to immutable-login-company lookup',[row(co='01',role='A',update='N',delete='N',print='N')],role='A',owner='01',admin=True,rights={'userUpdate':True,'userDelete':True,'userPrint':True})
pcase('P03','No principal rows refuses',[ ],error=True)
pcase('P04','Lowercase a-prefix is admin and grants all global rights',[row(role='assistant',update=None,delete=None,print=None)],role='assistant',admin=True,rights={'userUpdate':True,'userDelete':True,'userPrint':True})
pcase('P05','Leading-space admin role is not trimmed into admin',[row(role=' Admin')],role=' Admin')
pcase('P06','Global rights accept exactly Y/1/lowercase true',[row(update='Y',delete='1',print='true')],rights={'userUpdate':True,'userDelete':True,'userPrint':True})
pcase('P07','Global rights do not inherit forced-reset uppercase normalization',[row(update='y',delete='TRUE',print=' Y ',reset='true')],reset=True)
pcase('P08','Forced-reset flag does not trim spaces',[row(reset=' TRUE ')])
pcase('P09','NULL role remains empty and global NULL flags remain false',[row(role=None,update=None,delete=None,print=None,reset=None)],role='')
pcase('P10','Missing principal company is refused',[{**row(),'CO_CODE':None}],error=True)
pcase('P11','Missing principal name is refused',[{**row(),'LOGIN_NAME':''}],error=True)
fixture={'version':1,'kind':'batch1-tx-extraction-current-behavior-independent','authoredBeforeStagedImplementationInspection':True,'sourceOfExpectedDecisions':'Current original web businessScope.ts/authorization.ts/rightsOf/isAdminRole; this is an extraction regression contract, not new desktop parity or auth-session integration evidence.','queryRowsMeaning':'Literal results are in the order produced by the existing SQL. A fake query queue must not emulate SQL sorting/membership. Separately compare SQL semantics and bindings to the original source.','undefinedEncoding':'expected.ownUndefinedKeys names own output properties whose values must be undefined; omitted JSON keys are not evidence that the JS result omits these properties.','cases':cases,'transactionInvariants':[{'id':'TX01','expected':'Each public login/selected/principal wrapper opens exactly one withTenant callback with input.tenantId; all its domain queries use that callback tx.'},{'id':'TX02','expected':'Direct Tx helpers open zero transactions and do not call set_config, $transaction, withTenant or set isolation; caller must already bind tenant and choose transaction isolation.'},{'id':'TX03','expected':'An original query rejection propagates as the same error without reclassification, swallowing, fallback query or partial successful return.'},{'id':'TX04','expected':'Company refusal stops before location/year; location refusal stops before year; principal absence remains PrincipalUnavailableError.'},{'id':'TX05','expected':'No new row-lock clause, writes, LOGIN/USER_SET semantics, input coercion, last-day-lock invocation, token/session/epoch/ledger integration is added.'},{'id':'TX06','expected':'One default withTenant transaction is not a RepeatableRead guarantee and is not atomic with later separate auth/session/last-lock calls.'}]}
f=out/'batch1-independent-decisions.json';f.write_text(json.dumps(fixture,indent=2)+'\n')
refs=[]
for rel in ['web/apps/api/src/modules/auth/businessScope.ts','web/apps/api/src/modules/rbac/authorization.ts','web/apps/api/src/modules/auth/auth.service.ts','web/apps/api/src/modules/rbac/users.ts','web/packages/db/src/tenant.ts']:
 p=root/rel;refs.append({'path':rel,'sha256':hashlib.sha256(p.read_bytes()).hexdigest()})
a={'authoredAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'implementationInspected':False,'caseCount':len(cases),'transactionInvariants':6,'fixture':{'path':str(f),'sha256':hashlib.sha256(f.read_bytes()).hexdigest()},'sources':refs,'testsCompilerDatabaseRun':False,'workspaceMutation':False}
(out/'batch1-vector-authorship.json').write_text(json.dumps(a,indent=2)+'\n')
print(json.dumps(a,indent=2))
