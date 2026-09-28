from pathlib import Path
import json,hashlib,datetime
out=Path('/tmp/datacare-session-context-next/context-vectors')
cases=[]
def add(id,operation,reason,input,accepted,value=None):
 e={'accepted':accepted}
 if accepted:e['value']=value
 cases.append({'id':id,'operation':operation,'reason':reason,'input':input,'expected':e})
for id,value in [('E01','1'),('E02','10'),('E03','9007199254740993'),('E04','9223372036854775806'),('E05','9223372036854775807')]:
 add(id,'epoch','Canonical positive PostgreSQL BIGINT text retained exactly',value,True,value)
for i,(value,why) in enumerate([
('0','No zero generation'),('-1','No negative generation'),('+1','No plus prefix'),('01','No leading zero'),('1.0','No decimal coercion'),('1e3','No exponent coercion'),(' 1','No leading trim'),('1 ','No trailing trim'),('1\n','No terminal newline'),('1\u2028','No Unicode line terminator'),('１','No Unicode digits'),('9223372036854775808','One above PostgreSQL BIGINT max'),('999999999999999999999999999999999999','Oversized integer text'),('','No empty value'),(None,'NULL not epoch1'),(1,'Number not canonical text'),(True,'Boolean not numeric generation'),({},'Object not numeric generation')],6):
 add('E%02d'%i,'epoch',why,value,False)
for id,value,accepted,result,why in [
('N01','1',True,'2','First successor'),('N02','9007199254740993',True,'9007199254740994','Successor beyond JS safe integer remains exact'),('N03','9223372036854775806',True,'9223372036854775807','Last valid successor'),('N04','9223372036854775807',False,None,'Overflow refuses, never wraps/resets'),('N05','0',False,None,'Successor validates input before incrementing')]:
 add(id,'successor',why,value,accepted,result)
ledger={'version':'server-session-ledger-context-v1','status':'unknown','mode':None,'reason':'vendor-authority-unresolved'}
for i,reason in enumerate(['vendor-authority-unresolved','legacy-session-uninitialized','scope-incomplete'],1):
 value={**ledger,'reason':reason};add('L%02d'%i,'ledgerContext','Explicit unknown observation reason retained',value,True,value)
ledgerBad=[
({k:v for k,v in ledger.items() if k!='version'},'Missing version'),
({k:v for k,v in ledger.items() if k!='status'},'Missing status'),
({k:v for k,v in ledger.items() if k!='mode'},'Missing mode differs from requiredNULL'),
({k:v for k,v in ledger.items() if k!='reason'},'Missing reason'),
({**ledger,'version':'server-session-ledger-context-v2'},'Unknown semantic version'),
({**ledger,'status':'resolved','mode':'A'},'Known mode is outside initial schema/profile'),
({**ledger,'mode':'A'},'Unknown status cannot carry known mode'),
({**ledger,'mode':''},'Blank mode is notNULL'),
({**ledger,'reason':' vendor-authority-unresolved'},'Reason is not trimmed'),
({**ledger,'reason':'vendor-authority-unresolved\n'},'Reason terminal newline refused'),
({**ledger,'reason':None},'NULL reason unsupported'),
({**ledger,'reason':'other'},'Unrecognized reason'),
({**ledger,'contextEpoch':'1'},'No extra client scope/generation inside stored observation'),
(None,'NULL envelope'),([], 'Array envelope')]
for i,(value,why) in enumerate(ledgerBad,4):add('L%02d'%i,'ledgerContext',why,value,False)
for i,value in enumerate([
'12345678-1234-4234-8234-123456789abc',
'12345678-1234-4234-9234-123456789abc',
'12345678-1234-4234-a234-123456789abc',
'12345678-1234-4234-b234-123456789abc'],1):
 add('U%02d'%i,'selectionId','Canonical lowercase UUIDv4 with RFC4122 variant retained',value,True,value)
for i,(value,why) in enumerate([
('12345678-1234-4234-8234-123456789ABC','Uppercase hex refused rather than normalized'),
('12345678-1234-1234-8234-123456789abc','UUIDv1 outside selected initial transport profile'),
('12345678-1234-5234-8234-123456789abc','UUIDv5 outside selected initial transport profile'),
('12345678-1234-8234-8234-123456789abc','UUIDv8 outside selected initial transport profile'),
('00000000-0000-0000-0000-000000000000','Nil UUID lacks required version/variant'),
('12345678-1234-4234-7234-123456789abc','Variant below8 refused'),
('12345678-1234-4234-c234-123456789abc','Variant aboveb refused'),
('12345678123442348234123456789abc','No omitted hyphen normalization'),
('{12345678-1234-4234-8234-123456789abc}','No brace stripping'),
(' 12345678-1234-4234-8234-123456789abc','No leading trim'),
('12345678-1234-4234-8234-123456789abc\n','Terminal newline refused'),
(None,'NULL not generated automatically'),
(123,'Number not operation identity')],5):add('U%02d'%i,'selectionId',why,value,False)
f={'kind':'session-context-canonical-dto-independent-v1','profileDecisions':{'epoch':'Canonical ASCII positive decimal text1..9223372036854775807; exact successors with overflow refusal.','ledgerContext':'Exactly version/status/mode/reason: server-session-ledger-context-v1 / unknown / NULL / one of the three declared reasons. No known mode or extra keys.','selectionId':'Canonical lowercase UUIDv4 only; hyphenated8-4-4-4-12 hex, version4, RFC4122 variant8/9/a/b. This is the chosen initial web transport profile matching crypto.randomUUID, not a desktop rule or a grant of idempotency/session authority.'},'expectedValues':'Independent literal values; no proposed parser, BigInt arithmetic implementation, compiler or DB generated expected outcomes. Operation labels are semantic adapter labels, not prescribed export names. Accepted epoch/successor expected.value is canonical text regardless internal parser representation.','cases':cases,'requiredEnvelopeChecksNotRepresentableInJson':['Own property getters must not be invoked.','Inherited/custom-prototype fields, symbol keys, nonenumerable extra keys and cycles refuse without throwing or coercing.','Accepted ledger output should be detached/frozen; caller object must remain unmutated and unfrozen.','Missing/undefined input is refusal, never generation1 or default unknown mode.'],'scopeLimits':['Pure parsing and immutable observations only.','No schema/JWT/session/permission/ledger mode authority or closing integration is implemented by these cases.','No UUID version broadening or silent ID generation in a parser.','No Number conversions for epoch comparison or successor arithmetic.']}
p=out/'session-context-dto-independent.v1.json';p.write_text(json.dumps(f,indent=2)+'\n')
contract=Path('/tmp/datacare-session-context-next/implementation-contract.md')
a={'authoredAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'implementationInspected':False,'authority':'Root explicitly selected lowercase UUIDv4 and RFC4122 variant8/9/a/b before freeze. Other values derive from the staged implementation contract.','contract':{'path':str(contract),'sha256':hashlib.sha256(contract.read_bytes()).hexdigest()},'fixture':{'path':str(p),'sha256':hashlib.sha256(p.read_bytes()).hexdigest(),'cases':len(cases),'counts':{op:sum(c['operation']==op for c in cases) for op in ['epoch','successor','ledgerContext','selectionId']}},'workspaceMutations':False,'testsCompilerDbRun':False}
(out/'vector-authorship.json').write_text(json.dumps(a,indent=2)+'\n');print(json.dumps(a,indent=2))
