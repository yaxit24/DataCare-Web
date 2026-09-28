from pathlib import Path
import json,hashlib
s=Path('/tmp/datacare-session-serializable-command-staged');r=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted/web')
q={'fixtureSha256':'719f298df0a0f1e18b0c10f7fabc57933b682f0916f6140cd26ac0724ff68486','authoredBeforeNewImplementation':True,'corrections':[{'id':'S26','scenario':'company-forbidden','originalExpected':{'code':'company-forbidden','statusCode':403},'expected':{'code':'company-unavailable','statusCode':409},'source':'apps/api/src/modules/auth/businessScope.ts:15-24,65','reason':'companyTx uses company-unavailable with default ScopeError409 for allowed=false; preserve existing decision. All other frozen expected outcomes unchanged.'}]}
qp=s/'web/apps/api/test/fixtures/sessionSerializableCommand.qualifications.json';qp.write_text(json.dumps(q,indent=2)+'\n')
print('qualification',hashlib.sha256(qp.read_bytes()).hexdigest())
src=(r/'apps/api/src/modules/auth/sessionContextReadSnapshot.ts').read_text()
src=src.replace('SESSION_CONTEXT_READ_SNAPSHOT_VERSION','SESSION_CONTEXT_SERIALIZABLE_COMMAND_VERSION').replace('session-read-repeatable-snapshot-v1','session-serializable-return-update-v1').replace('SessionReadSnapshot','SessionSerializableCommand').replace('StoredReadSnapshotSession','StoredSerializableCommandSession').replace('withSessionContextReadSnapshot','withSessionContextSerializableCommand').replace('invalid-read-snapshot-policy','invalid-serializable-command-policy').replace('preview-snapshot-conflict','session-command-conflict')
src=src.replace("readonly form: string;\n",'').replace("public readonly action?: 'read'","public readonly action?: 'update'")
src=src.replace('function copyIdentity(input: unknown)', 'function readIdentity(input: unknown)')
a=src.index('function copyPolicy(');b=src.index('\ninterface Stored',a)
src=src[:a]+'''function copyIdentity(input: unknown): SessionSerializableCommandIdentity {
  try {
    return readIdentity(input);
  } catch (error) {
    if (error instanceof SessionSerializableCommandError) throw error;
    return fail('session-invalid', 401);
  }
}
function copyPolicy(input: unknown): SessionSerializableCommandPolicy {
  try {
    const raw = ownData(input, ['scope']);
    const scope = ownData(raw.scope, ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook']);
    if (Object.values(scope).some((value) => typeof value !== 'string' || !value))
      return fail('scope-incomplete', 409);
    for (const [key, max] of [['tenantId', 24], ['coCode', 2], ['lcCode', 2], ['coYear', 9], ['coBook', 3]] as const) {
      if ((scope[key] as string).length > max) return fail('invalid-serializable-command-policy', 500);
    }
    return Object.freeze({ scope: Object.freeze({
      tenantId: scope.tenantId as string,
      coCode: scope.coCode as string,
      lcCode: scope.lcCode as string,
      coYear: scope.coYear as string,
      coBook: scope.coBook as string,
    }) });
  } catch (error) {
    if (error instanceof SessionSerializableCommandError) throw error;
    return fail('invalid-serializable-command-policy', 500);
  }
}
''' +src[b:]
a=src.index('/**\n * One RepeatableRead');b=src.index('export async function',a)
src=src[:a]+'''/**
 * Separately versioned Serializable admission for a future finite saved Return update.
 * First application-row lock is the exact session FOR SHARE, held through callback/commit.
 * Tenant setup can establish the snapshot before that lock: a committed UPDATE winner can
 * cause serialization refusal. Authority/observations are as of the snapshot, not latest-at-response.
 * The callback owns only its separately approved business plan; no nested transaction, external
 * effect, auth/session write, lock upgrade or LOGIN_MAST lock is permitted. This Tx type is not
 * a DML sandbox. Final full context/live SQL defines a final-statement boundary, not exact COMMIT
 * time. Expected conflicts refuse once without retry. No route or financial adopter is enabled.
 */
''' +src[b:]
src=src.replace("'repeatable read'","'serializable'").replace("'RepeatableRead'","'Serializable'").replace('form: policy.form,','form: \'Sales/Sales Return\',').replace("action: 'read'","action: 'update'").replace("error.form, 'read'","error.form, 'update'")
(s/'web/apps/api/src/modules/auth/sessionContextSerializableCommand.ts').write_text(src)
