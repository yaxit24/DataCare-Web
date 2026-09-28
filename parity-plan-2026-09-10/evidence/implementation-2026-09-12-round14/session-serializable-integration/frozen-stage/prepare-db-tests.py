from pathlib import Path
s=Path('/tmp/datacare-session-serializable-command-staged');r=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted/web')
x=(r/'apps/api/test/sessionContextReadSnapshot.db.test.ts').read_text()
x=x.replace('SessionReadSnapshot','SessionSerializableCommand').replace('sessionContextReadSnapshot','sessionContextSerializableCommand').replace('withSessionContextReadSnapshot','withSessionContextSerializableCommand').replace('preview-snapshot-conflict','session-command-conflict')
x=x.replace('read-snapshot-db','serial-command-db').replace('read-snapshot-foreign','serial-command-foreign').replace('before-preview','before-command').replace('read-result','command-result').replace("form: 'Sales/Sales Return',\n  ",'')
x=x.replace('Real RR snapshots and lock schedules on scoped master/session fixtures. HTTP/full Return table coverage belongs to the API owner.','Real Serializable snapshots, callback DML rollback and SSI schedules. Marker writes are synthetic transaction proof, not Return financial acceptance; no route is added.')
x=x.replace("session read snapshot schedules on isolated PostgreSQL","Serializable Return command schedules on isolated PostgreSQL")
x=x.replace("'repeatable read'","'serializable'").replace("action).toBe('read')","action).toBe('update')").replace("action: 'read'","action: 'update'")
x=x.replace("'Sales Return','Y','N'","'Sales Return','Y','Y'")
x=x.replace('D01 reads with View-only authority','D01 admits fixed Return update authority')
x=x.replace('D03 selection UPDATE winner causes RR serialization refusal','D03 selection UPDATE winner causes Serializable serialization refusal')
x=x.replace('D11 committed View revocation','D11 committed Edit revocation').replace('D12 rights are as of the snapshot; a later View change affects the next read','D12 rights are as of the snapshot; a later Edit change affects the next command')
x=x.replace('SET "FRM_VIEW"=\'N\',"FRM_EDIT"=\'Y\'','SET "FRM_VIEW"=\'Y\',"FRM_EDIT"=\'N\'')
x=x.replace('SET "FRM_VIEW"=\'N\'','SET "FRM_EDIT"=\'N\'').replace('SELECT "FRM_VIEW" FROM "USER_SET"','SELECT "FRM_EDIT" FROM "USER_SET"').replace("[{ FRM_VIEW: 'Y' }]","[{ FRM_EDIT: 'Y' }]")
x=x.replace('D13 deliberate prohibited callback write is rolled back with its injected failure','D13 callback marker DML is rolled back with its injected failure')
x=x.replace('before-command\',\n        entered.release()', 'before-command\',\n        entered.release()')
# A real callback DML helper remains test-only. The coordinator itself emits no DML.
pos=x.index('  const marker = async () =>')
x=x[:pos]+'''  const writeMarker = (tx: Tx, name: string, code = 'PARTY') => tx.$executeRawUnsafe(
    `UPDATE "AC_MAST" SET "AC_NAME"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$3`, tenantId, name, code,
  );
''' +x[pos:]
# D02 proves the successful callback business effect survives before lifecycle selection proceeds.
a=x.index("  it('D02");b=x.index("  it('D03",a)
part=x[a:b].replace("name !== 'auth_session'","!['auth_session','AC_MAST'].includes(name)")
part=part.replace('        entered.release();','        await writeMarker(tx, \'command-committed\');\n        entered.release();',1)
part=part.replace("expect((await read).value).toBe('before-command');","expect((await read).value).toBe('command-committed');\n      expect(await marker()).toBe('command-committed');")
x=x[:a]+part+x[b:]
# D09 proves expiry rolls back a successful marker write.
a=x.index("  it('D09");b=x.index("  it('D10",a)
part=x[a:b].replace('      const value = await readMarker(tx);','      await writeMarker(tx, \'must-rollback-on-expiry\');\n      const value = await readMarker(tx);')
x=x[:a]+part+x[b:]
pos=x.rfind('\n});')
x=x[:pos]+'''
  it('D15 real SSI write-skew cycle commits exactly one command and never retries either callback', async () => {
    await sql(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PEER','before-peer')`,tenantId);
    const beforeStable = await snapshot(tables.filter((name) => name !== 'AC_MAST'));
    const enteredA = barrier(), enteredB = barrier(), release = barrier();
    const makeWork = (code:string, entered:ReturnType<typeof barrier>) => vi.fn(async (tx:Tx) => {
      const rows = await tx.$queryRawUnsafe<Array<{code:string;name:string}>>(`SELECT "AC_CODE" AS code,"AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE" IN ('PARTY','PEER') ORDER BY "AC_CODE"`,tenantId);
      expect(rows).toEqual([{code:'PARTY',name:'before-command'},{code:'PEER',name:'before-peer'}]);
      entered.release();
      await release.promise;
      expect(await writeMarker(tx, `winner-${code}`, code)).toBe(1);
      return code;
    });
    const workA = makeWork('PARTY',enteredA), workB = makeWork('PEER',enteredB);
    const a = settled(withSessionContextSerializableCommand(runtime,identity,policy,workA));
    const b = settled(withSessionContextSerializableCommand(runtime,identity,policy,workB));
    try {
      await Promise.all([waitForGate(enteredA.promise,a),waitForGate(enteredB.promise,b)]);
      release.release();
      const outcomes = await Promise.all([a,b]);
      expect(outcomes.filter((entry) => entry.error === undefined)).toHaveLength(1);
      expect(outcomes.find((entry) => entry.error !== undefined)?.error).toMatchObject({code:'session-command-conflict',statusCode:409});
      expect(workA).toHaveBeenCalledTimes(1); expect(workB).toHaveBeenCalledTimes(1);
      const winner = outcomes.find((entry) => entry.error === undefined)!.value;
      expect(await owner.$queryRawUnsafe(`SELECT "AC_CODE" AS code,"AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "AC_CODE"`,tenantId)).toEqual([
        {code:'PARTY',name:winner === 'PARTY' ? 'winner-PARTY' : 'before-command'},
        {code:'PEER',name:winner === 'PEER' ? 'winner-PEER' : 'before-peer'},
      ]);
      expect(await snapshot(tables.filter((name) => name !== 'AC_MAST'))).toEqual(beforeStable);
      expect(await owner.$queryRawUnsafe(`SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1`,foreignTenant)).toEqual([{AC_NAME:'foreign-sentinel'}]);
    } finally {
      release.release(); await Promise.all([a,b]);
    }
  });
  it('D16 real concurrent same-row change is preserved while the stale snapshot update refuses409', async () => {
    const beforeStable = await snapshot(tables.filter((name) => name !== 'AC_MAST'));
    const work = vi.fn(async (tx:Tx) => {
      expect(await readMarker(tx)).toBe('before-command');
      await sql(`UPDATE "AC_MAST" SET "AC_NAME"='external-winner' WHERE tenant_id=$1 AND "AC_CODE"='PARTY'`,tenantId);
      await writeMarker(tx,'stale-must-not-commit');
      return 'unexpected';
    });
    await expect(withSessionContextSerializableCommand(runtime,identity,policy,work)).rejects.toMatchObject({code:'session-command-conflict',statusCode:409});
    expect(work).toHaveBeenCalledTimes(1);
    expect(await marker()).toBe('external-winner');
    expect(await snapshot(tables.filter((name) => name !== 'AC_MAST'))).toEqual(beforeStable);
    expect(await owner.$queryRawUnsafe(`SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1`,foreignTenant)).toEqual([{AC_NAME:'foreign-sentinel'}]);
  });
  it('D17 final ledger check rolls back prohibited same-Tx authority mutation and marker DML', async () => {
    const before = await snapshot();
    await expect(withSessionContextSerializableCommand(runtime,identity,policy,async (tx) => {
      await writeMarker(tx,'must-rollback');
      await tx.$executeRawUnsafe(`UPDATE auth_session SET ledger_context=$3::jsonb WHERE tenant_id=$1 AND session_id=$2`,tenantId,sid,JSON.stringify({...ledger,reason:'legacy-session-uninitialized'}));
      return 'discarded';
    })).rejects.toMatchObject({code:'context-stale',statusCode:409});
    expect(await snapshot()).toEqual(before);
  });
''' +x[pos:]
# Never let a premature actor failure hang the lock-wait gate. Existing helper times out too.
x=x.replace('await waitForLock(actorName);','await waitForGate(waitForLock(actorName), '+ 'selection);',1)
# Remaining generic actor schedule has operationPromise, source deliberately keeps natural DB expiry polling.
x=x.replace('await waitForLock(actorName);','await waitForGate(waitForLock(actorName), operationPromise);')
x=x.replace('await waitForLock(readName);','await waitForGate(waitForLock(readName), read);')
(s/'web/apps/api/test/sessionContextSerializableCommand.db.test.ts').write_text(x)
