from pathlib import Path
import hashlib,json,difflib
p=Path('/tmp/datacare-return-labour-browser-final-review');base=Path('/tmp/datacare-return-labour-preview-browser');rel=Path('web/apps/web/test/sales-return-labour-replay.journey.mjs')
s=(base/rel).read_text();(p/'journey-before.mjs').write_text(s)
for name in ['runner.patch','browser-required-checks.json']:(p/name).write_bytes((base/name).read_bytes())
s=s.replace('22cdfb8963c39dd50e3c41d1277d5d7549f3a65fb507598e1d8013deadc258bc','8c2e2ba9a985a1e57e353bcbf742e8b350fac47cd34e6cf96f7cb283adbeb78b',1)
s=s.replace('  const confirm = () => checks.push(required.checks[checks.length]);', '''  const confirm = (id) => {
    assert.equal(id, required.checks[checks.length], 'a named required checkpoint must be next');
    checks.push(id);
  };''')
ids=json.loads((base/'browser-required-checks.json').read_text())['checks']
assert s.count('    confirm();')==12
for id in ids:s=s.replace('    confirm();',f"    confirm('{id}');",1)
needle='''    assert((response.headers()['cache-control'] || '').includes('no-store'));
    return body;'''
repl='''    assert((response.headers()['cache-control'] || '').includes('no-store'));
    const query = [...new URL(response.url()).searchParams];
    assert.equal(query.length, 4, 'exact full scope, without duplicate or extra query keys');
    assert.deepEqual(Object.fromEntries(query), scope);
    return body;'''
assert needle in s;s=s.replace(needle,repl)
needle='''  const display = (value) =>'''
extra='''  const assertContext = (response, context) => {
    assert.deepEqual(Object.keys(context).sort(), ['coCode', 'coYear', 'contextEpoch', 'lcCode', 'sessionId']);
    assert.deepEqual({coCode: context.coCode, lcCode: context.lcCode, coYear: context.coYear}, {coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear});
    assert.match(context.sessionId, /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/);
    assert.match(context.contextEpoch, /^[1-9][0-9]*$/);
    const headers = response.request().headers();
    assert.equal(headers['x-session-context-id'], context.sessionId);
    assert.equal(headers['x-session-context-epoch'], context.contextEpoch);
  };
  const assertJournal = async (events, target = page) => {
    await el('status', target).filter({hasText: new RegExp('^' + events.length + ' field changes previewed in order\\\\.')}).waitFor();
    assert.equal(await el('events', target).locator('li').count(), events.length);
  };
'''
assert needle in s;s=s.replace(needle,extra+needle)
# All14 actual rendered totals; full matrix/caches still compared to the frozen input.
s=s.replace('for (const col of [20, 24, 27, 38])','for (const col of [9, 10, 11, 12, 15, 18, 20, 24, 27, 42, 28, 36, 38, 35])')
needle='''    const data = await result(response);
    await el('entry', target).waitFor();'''
repl='''    const data = await result(response);
    assertContext(response, data.context);
    assert.equal(data.rows.length, 1);
    assert.match(data.rows[0].initialPrefixVersion, /^[a-f0-9]{64}$/);
    const initialRow = data.billReplay.rowReplay.rows[0];
    assert.deepEqual({visible: initialRow.visible, caches: initialRow.caches, editorTextByField: initialRow.editorTextByField}, fixture.expected.initial);
    await el('entry', target).waitFor();
    await assertJournal([], target);'''
assert needle in s;s=s.replace(needle,repl)
needle='''    const data = await result(response, status);
    assert.deepEqual(response.request().postDataJSON(),'''
repl='''    const data = await result(response, status);
    assertContext(response, state.context);
    if(status === 200) assert.deepEqual(data.context, state.context);
    assert.deepEqual(response.request().postDataJSON(),'''
assert needle in s;s=s.replace(needle,repl)
s=s.replace("      await el('candidate').waitFor();\n    } else await el('error').waitFor();", "      for(const absent of ['prefix','preview','events','phase','effects']) assert.equal(Object.hasOwn(data, absent), false, 'lookup is observation only');\n      await el('candidate').filter({hasText: 'Checked code ' + code + ' '}).waitFor();\n    } else await el('error').filter({hasText: data.message}).waitFor();\n    await assertJournal(old.events);")
needle='''    assert.equal(data.baseVersion, old.baseVersion);
    assert.equal(data.rowIdentity, old.rowIdentity);'''
repl='''    assertContext(response, state.context);
    assert.deepEqual(data.context, state.context);
    assert.equal(data.baseVersion, old.baseVersion);
    assert.equal(data.rowIdentity, old.rowIdentity);
    assert.notEqual(data.prefix.prefixVersion, old.prefixVersion);
    assert.equal(data.effects.aggregateApplied, true);
    assert.equal(data.effects.billApplied, true);'''
assert needle in s;s=s.replace(needle,repl)
s=s.replace('''    current = data.prefix;
    await screen('preview', golden.phase);''','''    current = data.prefix;
    await assertJournal(current.events);
    await screen('preview', golden.phase);''')
# Verify rendered raw fields follow exact actual saved JSONB values, not numeric coercion.
needle="    await screenRow(fixture.expected.initial);\n"
repl="    await screenRow(fixture.expected.initial);\n    for (const key of ['RTN_NET_AMT','NET_AMT','TAX_AMT','RTN_TOT_AMT','TOT_AMT','RTN_BILL_OS','BILL_OS']) await visible('saved-' + key, state.billReplay.savedHeader[key]);\n"
assert needle in s;s=s.replace(needle,repl,1)
# Same-value branches must await a rendered new journal, not only unchanged numerical cells.
needle='''      const data = await result(response);
      const submitted = response.request().postDataJSON();'''
repl='''      const data = await result(response);
      assertContext(response, state.context);
      assert.deepEqual(data.context, state.context);
      const submitted = response.request().postDataJSON();
      assert.equal(data.baseVersion, old.baseVersion);
      assert.equal(data.rowIdentity, old.rowIdentity);
      assert.notEqual(data.prefix.prefixVersion, old.prefixVersion);
      assert.deepEqual(data.acceptedEvent, {event: submitted.event, status: 'applied'});
      assert.equal(data.effects.billApplied, true);
      for (const capability of ['canSaveNumeric','canPreviewClosing','canApplySource']) assert.equal(data.capabilities[capability], false);'''
assert needle in s;s=s.replace(needle,repl)
s=s.replace('''      current = data.prefix;
      await screen('preview', fixture.expected.prefixes['same-aa'].phase);''','''      current = data.prefix;
      await assertJournal(current.events);
      await screen('preview', fixture.expected.prefixes['same-aa'].phase);''')
# View-only proof from the actual saved DTO rather than clean-form disabled state alone.
s=s.replace('''    await load(limited);
    const limitedBefore''','''    const limitedSaved = await load(limited);
    assert.equal(limitedSaved.canUpdate, false, 'actual saved DTO carries no own-form Update right');
    const limitedBefore''')
s=s.replace('''    const limitedObservation = await result(limitedCheckResponse);
    const limitedBase''','''    const limitedObservation = await result(limitedCheckResponse);
    assertContext(limitedCheckResponse, limitedState.context);
    assert.deepEqual(limitedObservation.context, limitedState.context);
    await assertJournal([], limited);
    const limitedBase''')
s=s.replace('''    const limitedResult = await result(limitedAppendResponse);
    assert.deepEqual''','''    const limitedResult = await result(limitedAppendResponse);
    assertContext(limitedAppendResponse, limitedState.context);
    assert.deepEqual(limitedResult.context, limitedState.context);
    assert.deepEqual(limitedResult.acceptedEvent, {event: limitedEvent, status: 'applied'});
    assert.equal(limitedResult.effects.billApplied, true);
    assert.deepEqual''')
s=s.replace("    assert.equal(limitedResult.capabilities.canSaveNumeric, false);", "    for (const capability of ['canSaveNumeric','canPreviewClosing','canApplySource']) assert.equal(limitedResult.capabilities[capability], false);\n    await assertJournal([limitedEvent], limited);")
(p/'staged'/rel).write_text(s)
# No change to the runner patch needed; its previous16 entries and prior fixture lifecycle are retained.
assert len(ids)==12
print('staged',len(s.splitlines()),'lines with12 named checkpoints')
