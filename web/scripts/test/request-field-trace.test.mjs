import { test } from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import {
  requestFieldMappings,
  writerFieldReads,
  writerImportedCalls,
  traceNestedField,
} from '../lib/request-field-trace.mjs';

const pageSource = `function submit(){const body={lines:lines.map(l=>{const sourceRef=l.issueYear.trim()?{yrcd:l.issueYear.trim(),srno:l.issueSrno.trim()?Number(l.issueSrno):undefined}:undefined;return {isuRef:sourceRef};})};return post('/sale',body);}`;
const routeSource = `import {postSale} from '../modules/sales/writer.js'; const body=req=>req.body??{}; const input=(req,b)=>({lines:b.lines??[]}); app.post('/sale', auth, req=>{const b=body(req);return postSale(db,input(req,b));});`;
const writerSource = `interface Line {issueYear?:string; unused?:number} function rows(input){return input.lines.map(l=>{const ref=l.isuRef??{};return {ISU_YRCD:ref.yrcd??null,ISU_SRNO:ref.srno??null};});} export function postSale(db,input){return db.write(rows(input));}`;
const trace = (overrides = {}) =>
  traceNestedField({
    pageSource,
    routeSource,
    writerSources: [{ source: writerSource, file: 'writer.ts' }],
    writerRelativePath: 'sales/writer.ts',
    field: 'issueYear',
    ...overrides,
  });

test('conditional local aliases retain nested JSON path through actual route input helper and row column', () => {
  const result = trace();
  assert.equal(result.traces.length, 1);
  assert.deepEqual(result.traces[0].path, ['lines', '[]', 'isuRef', 'yrcd']);
  assert.deepEqual(result.traces[0].forwarding.path, ['lines', '[]', 'isuRef', 'yrcd']);
  assert.equal(result.traces[0].read.column, 'ISU_YRCD');
  assert.equal(result.traces[0].forwarding.writer, 'postSale');
  assert.equal(trace({ field: 'issueSrno' }).traces[0].read.column, 'ISU_SRNO');
});
test('interfaces, comments, unused aliases and uncalled functions do not count as consumed fields', () => {
  const source = `interface I {dead:string}; // row.dead
  function abandoned(row){return row.dead;}
  export function save(row){const ignored=row.dead; const ignoredObject={VALUE:row.dead}; return {VALUE:row.live};}`;
  const fields = writerFieldReads(source).reads.map((r) => r.field);
  assert.ok(fields.includes('live'));
  assert.ok(!fields.includes('dead'));
});
test('an unused request mapping or a condition-only field is not a sent value', () => {
  assert.deepEqual(
    requestFieldMappings(
      `function submit(){const unused={value:row.dead}; return post('/sale',{value:row.flag?row.live:0});}`,
      ['dead', 'flag', 'live'],
    ).mappings.map((m) => m.field),
    ['live'],
  );
});
test('a later static assignment replacing a request value removes the old provenance', () => {
  assert.deepEqual(
    requestFieldMappings(`function submit(){return post('/sale',{value:row.dead,value:0});}`, [
      'dead',
    ]).mappings,
    [],
  );
});
test('a route dropping lines, a wrong endpoint or a different imported writer cannot establish a trace', () => {
  assert.equal(
    trace({ routeSource: routeSource.replace('lines:b.lines??[]', 'lines:[]') }).traces.length,
    0,
  );
  assert.equal(
    trace({ routeSource: routeSource.replace("app.post('/sale'", "app.post('/other'") }).traces
      .length,
    0,
  );
  assert.equal(
    trace({ routeSource: routeSource.replace('sales/writer.js', 'sales/other.js') }).traces.length,
    0,
  );
});
test('request helper body must forward the request, and imported writer aliases retain export identity', () => {
  assert.equal(
    trace({ routeSource: routeSource.replace('const b=body(req)', 'const b=unrelated.body') })
      .traces.length,
    0,
  );
  assert.equal(
    trace({ routeSource: routeSource.replace('req=>req.body??{}', 'req=>({})') }).traces.length,
    0,
  );
  const alias = trace({
    routeSource: routeSource
      .replace('{postSale}', '{postSale as create}')
      .replace('return postSale(', 'return create('),
  });
  assert.equal(alias.traces[0].forwarding.writer, 'postSale');
});
test('same leaf under another collection is not the requested nested input', () => {
  assert.equal(
    trace({
      writerSources: [
        {
          source: writerSource.replace('input.lines.map', 'input.receivedLines.map'),
          file: 'writer.ts',
        },
      ],
    }).traces.length,
    0,
  );
});
test('changing the writer nested property breaks the trace even if an inert interface retains it', () => {
  assert.equal(
    trace({
      writerSources: [
        {
          source: writerSource.replace('ref.yrcd??null', 'ref.otherYear??null'),
          file: 'writer.ts',
        },
      ],
    }).traces.length,
    0,
  );
});
test('an unrelated exported reader cannot satisfy the actual route writer consumption', () => {
  assert.equal(
    trace({
      writerSources: [
        {
          source: `${writerSource.replace('ref.yrcd??null', 'ref.otherYear??null')} export function otherRead(input){return input.lines.map(l=>({ISU_YRCD:l.isuRef.yrcd}));}`,
          file: 'writer.ts',
        },
      ],
    }).traces.length,
    0,
  );
});
test('called named imports retain export identity without credit from unrelated sibling writers', () => {
  const source = `import {advance as adjust, unused} from './orders.js';
    function abandoned(row){return unused(row);}
    export function save(row){return adjust(row);}`;
  const calls = writerImportedCalls(source).calls;
  assert.deepEqual(
    calls.map(({ module, imported, local }) => ({ module, imported, local })),
    [{ module: './orders.js', imported: 'advance', local: 'adjust' }],
  );
  const sibling = `export function advance(row){return {AMT:row.amount};}
    export function createOrder(row){return {TYPE:row.itType,OLD:row.oldSrNo};}`;
  const fields = writerFieldReads(
    sibling,
    'orders.ts',
    calls.map((call) => call.imported),
  ).reads.map((read) => read.field);
  assert.ok(fields.includes('amount'));
  assert.ok(!fields.includes('itType'));
  assert.ok(!fields.includes('oldSrNo'));
});
test('imported callees obey entry point and lexical scope, without guessing opaque dispatch', () => {
  const source = `import {live, dead} from './helpers.js';
    import * as namespace from './namespace.js';
    export function save(row){const dead=(value)=>value; dead(row); return live(row);}
    export function other(row){return dead(row);}
    export function dynamic(row){return namespace[choose](row);}`;
  assert.deepEqual(
    writerImportedCalls(source, 'writer.ts', ['save']).calls.map((call) => call.imported),
    ['live'],
  );
  assert.deepEqual(writerImportedCalls(source, 'writer.ts', ['dynamic']).calls, []);
});
test('ordinary Sales advance imports cannot borrow Sales Order parent identity reads', () => {
  const root = resolve(import.meta.dirname, '../..');
  const sales = readFileSync(resolve(root, 'apps/api/src/modules/sales/sales.ts'), 'utf8');
  const orders = readFileSync(resolve(root, 'apps/api/src/modules/sales/salesOrder.ts'), 'utf8');
  const entryPoints = writerImportedCalls(sales)
    .calls.filter((call) => call.module === './salesOrder.js')
    .map((call) => call.imported);
  assert.deepEqual(entryPoints.sort(), ['adjustOrderIntoSaleTx', 'orderAdvanceAvailableTx']);
  const fields = writerFieldReads(orders, 'salesOrder.ts', entryPoints).reads.map(
    (read) => read.field,
  );
  assert.ok(!fields.includes('oldSrNo'));
  assert.ok(!fields.includes('itType'));
});
test('dynamic nested output keys remain explicit unsupported evidence rather than successful mappings', () => {
  const result = trace({
    pageSource: pageSource.replace('yrcd:l.issueYear.trim()', '[runtimeKey]:l.issueYear.trim()'),
  });
  assert.equal(result.traces.length, 0);
  assert.ok(result.unsupported.some((item) => item.reason.includes('Computed object key')));
});
test('dynamic endpoints are explicitly unsupported rather than guessed from the page writer map', () => {
  const result = requestFieldMappings(
    `function submit(){return post(endpoint,{value:row.live});}`,
    ['live'],
  );
  assert.deepEqual(result.mappings, []);
  assert.ok(result.unsupported.some((item) => item.reason.includes('Dynamic request endpoint')));
});
test('dynamic writer input keys are unsupported, while static string keys remain traceable', () => {
  const dynamic = writerFieldReads(`export function save(row){return {X:row[runtimeKey]};}`);
  assert.equal(dynamic.reads.length, 0);
  assert.ok(dynamic.unsupported.some((item) => item.reason.includes('Dynamic property key')));
  assert.equal(
    writerFieldReads(`export function save(row){return {X:row['live']};}`).reads[0].field,
    'live',
  );
});
test('lexically shadowed aliases do not borrow another function input mapping', () => {
  assert.equal(
    trace({
      writerSources: [
        {
          source: `function unused(input){const ref=input.lines;return ref.isuRef.yrcd;} export function save(input){const ref={yrcd:0};return {ISU_YRCD:ref.yrcd};}`,
          file: 'writer.ts',
        },
      ],
    }).traces.length,
    0,
  );
});
test('four real wholesale aliases each reach the registered route and issued row column', () => {
  const root = resolve(import.meta.dirname, '../..');
  const options = {
    pageSource: readFileSync(
      resolve(root, 'apps/web/app/(app)/txn/wholesale-sale/page.tsx'),
      'utf8',
    ),
    routeSource: readFileSync(resolve(root, 'apps/api/src/routes/txn.ts'), 'utf8'),
    writerSources: [
      {
        source: readFileSync(resolve(root, 'apps/api/src/modules/sales/rateCut.ts'), 'utf8'),
        file: 'rateCut.ts',
      },
    ],
    writerRelativePath: 'sales/rateCut.ts',
  };
  for (const [field, column] of [
    ['issueYear', 'ISU_YRCD'],
    ['issueBook', 'ISU_DBCD'],
    ['issueNo', 'ISU_NO'],
    ['issueSrno', 'ISU_SRNO'],
  ]) {
    const result = traceNestedField({ ...options, field });
    assert.ok(
      result.traces.some((item) => item.read.column === column),
      `${field} -> ${column}`,
    );
    assert.ok(result.traces.every((item) => item.read.path[0] === 'lines'));
  }
});
