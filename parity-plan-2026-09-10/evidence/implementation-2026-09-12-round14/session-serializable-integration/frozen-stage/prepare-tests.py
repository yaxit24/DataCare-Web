from pathlib import Path
s=Path('/tmp/datacare-session-serializable-command-staged');r=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted/web')
p=r/'apps/api/test/sessionContextReadSnapshot.test.ts'
x=p.read_text().replace('SessionReadSnapshot','SessionSerializableCommand').replace('sessionContextReadSnapshot','sessionContextSerializableCommand').replace('withSessionContextReadSnapshot','withSessionContextSerializableCommand').replace('SESSION_CONTEXT_READ_SNAPSHOT_VERSION','SESSION_CONTEXT_SERIALIZABLE_COMMAND_VERSION').replace('sessionReadSnapshot.independent','sessionSerializableCommand.independent').replace('session-read-repeatable-snapshot-v1','session-serializable-return-update-v1').replace('invalid-read-snapshot-policy','invalid-serializable-command-policy').replace('preview-snapshot-conflict','session-command-conflict').replace("'repeatable read'","'serializable'").replace("'RepeatableRead'","'Serializable'")
x=x.replace('separate session read snapshot contract','separate Serializable fixed Return update contract').replace('independent30 outcomes and14 schedules','independent36 outcomes and17 schedules').replace('toHaveLength(30)','toHaveLength(36)').replace('toHaveLength(14)','toHaveLength(17)').replace('45c0faa998fc1463cd08f9218487fc5c84ac3ba93b2c641f1fb45ead9aa71bad','719f298df0a0f1e18b0c10f7fabc57933b682f0916f6140cd26ac0724ff68486')
x=x.replace("const identity = fixture.identity;",'''const qualificationsBytes = readFileSync(new URL('./fixtures/sessionSerializableCommand.qualifications.json', import.meta.url));
const qualification = JSON.parse(qualificationsBytes.toString()) as { corrections: Array<{id:string; expected:{code:string;statusCode:number}}> };
const identity = fixture.identity;''')
x=x.replace("async ({ scenario, expected }) => {","async ({ id, scenario, expected: originalExpected }) => {\n      const expected = qualification.corrections.find((entry) => entry.id === id)?.expected ?? originalExpected;")
x=x.replace("FRM_EDIT: 'N'", "FRM_EDIT: 'Y'")
x=x.replace("case 'wrong-tenant':",'''case 'mutable-form':
          fixedPolicy = { ...policy, form: 'Master/Account' } as Mutable<SessionSerializableCommandPolicy>;
          break;
        case 'admin-override':
          fixedPolicy = { ...policy, adminOnly: true } as Mutable<SessionSerializableCommandPolicy>;
          break;
        case 'repeatable-isolation':
          changeRow(sequence, 0, { isolation: 'repeatable read' });
          break;
        case 'update-denied':
          changeRow(sequence, 7, { FRM_VIEW: 'Y', FRM_EDIT: 'N' });
          break;
        case 'year-unavailable':
          sequence[6]!.rows = [];
          break;
        case 'company-forbidden':
          changeRow(sequence, 4, { allowed: false });
          break;
        case 'wrong-tenant':''')
x=x.replace("fixedPolicy.form = 'Master/Account';","fixedPolicy.scope.coBook = 'Z99';")
x=x.replace("kind === 'identity' ? 'loginName' : kind === 'policy' ? 'form' : 'coCode'","kind === 'identity' ? 'loginName' : kind === 'policy' ? 'scope' : 'coCode'")
x=x.replace("action: 'read'","action: 'update'").replace("authorization.action).toBe('read')","authorization.action).toBe('update')").replace('runs one RR transaction','runs one Serializable transaction').replace("'read-result'","'command-result'")
# Verify exact pre-code qualification, not a general runtime normalization adapter.
pos=x.index("  it.each(fixture.unitCases)")
x=x[:pos]+'''  it('pins the single pre-code source qualification and leaves every other literal unchanged', () => {
    expect(createHash('sha256').update(qualificationsBytes).digest('hex')).toBe('1a84a5c10a5d7029af031b28a6f3707531305403b3fe76b6e721f5185d550795');
    expect(qualification.corrections).toHaveLength(1);
    expect(qualification.corrections[0]).toMatchObject({id:'S26', expected:{code:'company-unavailable',statusCode:409}});
  });
''' +x[pos:]
x=x.replace("if (scenario === 'view-denied') {","if (scenario === 'view-denied' || scenario === 'update-denied') {")
# Extra strict-envelope tests are independent and small; not used to derive fixture outputs.
pos=x.rfind('\n});')
x=x[:pos]+'''
  it.each(['identity', 'policy', 'scope'] as const)('contains a revoked reflection proxy in %s without SQL', async (kind) => {
    const revoked = Proxy.revocable({}, {}); revoked.revoke();
    const db = scripted([]);
    const supplied = kind === 'identity' ? revoked.proxy : identity;
    const suppliedPolicy = kind === 'policy' ? revoked.proxy : kind === 'scope' ? {scope:revoked.proxy} : policy;
    await expect(withSessionContextSerializableCommand(db.prisma, supplied, suppliedPolicy as SessionSerializableCommandPolicy, async () => undefined)).rejects.toMatchObject({code:kind === 'identity' ? 'session-invalid' : 'invalid-serializable-command-policy'});
    expect(db.transaction).not.toHaveBeenCalled();
  });
  it.each(['tenantId','coCode','lcCode','coYear','coBook'] as const)('bounds policy %s text without truncation', async (field) => {
    const db = scripted([]);
    await expect(withSessionContextSerializableCommand(db.prisma, identity, {scope:{...policy.scope,[field]:'x'.repeat(256)}}, async () => undefined)).rejects.toMatchObject({code:'invalid-serializable-command-policy',statusCode:500});
    expect(db.transaction).not.toHaveBeenCalled();
  });
  it('admin still binds, locks and validates scope; fixed update does not query USER_SET', async () => {
    const sequence = steps();
    changeRow(sequence,3,{LOGIN_CATG:'ADMIN'});
    sequence.splice(7,1);
    const db = scripted(sequence);
    await withSessionContextSerializableCommand(db.prisma,identity,policy,async (_tx,admitted) => {
      expect(admitted.principal.isAdmin).toBe(true);
      expect(admitted.authorization).toMatchObject({form:'Sales/Sales Return',action:'update'});
    });
    expect(db.pending).toHaveLength(0);
    expect(db.trace).toContain('FOR SHARE');
    expect(db.trace).toContain('FROM "CO_MAST"');
    expect(db.trace).not.toContain('FROM "USER_SET"');
  });
''' +x[pos:]
(s/'web/apps/api/test/sessionContextSerializableCommand.test.ts').write_text(x)
