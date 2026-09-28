import { test } from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, mkdirSync, writeFileSync, rmSync, readFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { descriptorScanner } from '../lib/ui-descriptors.mjs';

function fixture(files, check) {
  const root = mkdtempSync(join(tmpdir(), 'parity-descriptors-'));
  try {
    for (const [name, source] of Object.entries(files)) {
      mkdirSync(dirname(join(root, name)), { recursive: true });
      writeFileSync(join(root, name), source);
    }
    check(descriptorScanner(root).analyzePage(join(root, 'page.tsx')));
  } finally {
    rmSync(root, { recursive: true, force: true });
  }
}
const tuples =
  "export const fields: Array<[string,string]> = [['weight','Weight'], ['rate','Rate']]; export const unused = [['lost','Unused']];";
const mapped =
  '{cols.map(([key,label]) => <label>{label}<input value={row[key]} onChange={update}/></label>)}';

test('imported typed .ts tuple alias contributes only descriptors used in returned JSX', () => {
  fixture(
    {
      'page.tsx': `import {fields as cols,unused} from './fields'; export default function Page(){return <div>${mapped}</div>}`,
      'fields.ts': tuples,
    },
    (result) => {
      assert.deepEqual(
        result.fields.map((field) => field.key),
        ['weight', 'rate'],
      );
      assert.ok(
        result.fields.every(
          (field) =>
            field.file === 'fields.ts' &&
            field.input &&
            !field.grid &&
            field.access === 'editable-candidate',
        ),
      );
      assert.equal(result.uses[0].unsupported.length, 0);
    },
  );
});
test('unused imports, type-only imports and uncalled helper JSX do not become surface', () => {
  fixture(
    {
      'page.tsx': `import {fields as cols} from './fields'; import type {unused} from './fields'; function Hidden(){return <div>${mapped}</div>} export default function Page(){return <p>Nothing</p>}`,
      'fields.ts': tuples,
    },
    (result) => assert.deepEqual(result.fields, []),
  );
});
test('removing only the rendered map removes the imported candidates', () => {
  fixture(
    {
      'page.tsx':
        "import {fields as cols} from './fields'; export default function Page(){const pending=cols.map(([key,label])=><input value={row[key]}/>);return <div/>}",
      'fields.ts': tuples,
    },
    (result) => assert.deepEqual(result.fields, []),
  );
});
test('object descriptors recognize labels after key/column and classify identities', () => {
  fixture(
    {
      'page.tsx':
        "import {cols} from './fields'; export default function Page(){return <table><tr>{cols.map(c=><th>{c.label}</th>)}</tr><tr>{cols.map(c=><td><input value={row[c.key]} readOnly={c.identity}/></td>)}</tr></table>}",
      'fields.ts':
        "export const cols = [{key:'sr',column:'SR',identity:true,label:'Serial'}, {key:'weight',column:'WT',label:'Weight'}] satisfies Column[];",
    },
    (result) => {
      assert.equal(result.fields.length, 2);
      assert.ok(result.fields.every((field) => field.grid && field.input));
      assert.equal(result.fields[0].access, 'identity');
    },
  );
});
test('factory literal selector and conditional flatMap retain provenance, not current visibility claims', () => {
  fixture(
    {
      'page.tsx':
        "import {configured} from './fields'; export default function Page(){const cols=configured(config,true);return <tr>{cols.map(c=><th>{c.label}</th>)}</tr>}",
      'fields.ts':
        "const parent=[{key:'parent',label:'Parent'}];const children=[{key:'child',label:'Child'}];export function configured(config,child=false){const columns=child?children:parent;return columns.flatMap(column=>{const setting=config?.[column.key];if(setting?.hidden)return [];return [{...column,label:setting?.label||column.label}];});}",
    },
    (result) => {
      assert.deepEqual(
        result.fields.map((field) => field.key),
        ['child'],
      );
      assert.equal(result.fields[0].conditional, true);
      assert.match(result.uses[0].conditions[0], /Runtime flatMap/);
    },
  );
});
test('unknown selector reports both conditional branches; unconditional empty filter counts none', () => {
  fixture(
    {
      'page.tsx':
        "import {fields as left} from './fields';export default function Page(){const cols=flag?left:[['other','Other']];const empty=left.filter(()=>false);return <div>{cols.map(([key,label])=><input value={row[key]}/>)}{empty.map(([key,label])=><input value={row[key]}/>)}</div>}",
      'fields.ts': tuples,
    },
    (result) => {
      assert.deepEqual(
        result.fields.map((field) => field.key),
        ['weight', 'rate', 'other'],
      );
      assert.ok(result.fields.every((field) => field.conditional));
      assert.equal(result.uses[1].fields.length, 0);
    },
  );
});
test('false JSX condition is excluded and unknown runtime condition is recorded', () => {
  fixture(
    {
      'page.tsx': `import {fields as cols} from './fields';export default function Page(){return <div>{false && cols.map(([key])=><input value={row[key]}/>)}{enabled && cols.map(([key])=><input value={row[key]}/>)}</div>}`,
      'fields.ts': tuples,
    },
    (result) => {
      assert.equal(result.uses.length, 1);
      assert.equal(result.fields.length, 2);
      assert.ok(result.fields.every((field) => field.conditional));
    },
  );
});
test('unsupported dynamic factories remain explicit and do not invent fields', () => {
  fixture(
    {
      'page.tsx':
        'export default function Page(){const cols=fromServer();return <tr>{cols.map(c=><th>{c.label}</th>)}</tr>}',
    },
    (result) => {
      assert.deepEqual(result.fields, []);
      assert.match(result.uses[0].unsupported[0], /Unsupported descriptor expression/);
    },
  );
});
test('a flatMap that rewrites field identity is unsupported, not credited as original inputs', () => {
  fixture(
    {
      'page.tsx':
        "import {fields as source} from './fields';export default function Page(){const cols=source.flatMap(column=>[{...column,key:'changed'}]);return <tr>{cols.map(c=><th>{c.label}</th>)}</tr>}",
      'fields.ts': "export const fields=[{key:'original',label:'Original'}];",
    },
    (result) => {
      assert.deepEqual(result.fields, []);
      assert.match(result.uses[0].unsupported[0], /Unsupported descriptor expression/);
    },
  );
});
test('read-only mapped controls remain display-only and a type-only binding stays unresolved', () => {
  fixture(
    {
      'page.tsx':
        "import {fields as cols} from './fields';import type {unused} from './fields';export default function Page(){return <div>{cols.map(([key])=><input value={row[key]} readOnly/>)}{unused.map(c=><th>{c.label}</th>)}</div>}",
      'fields.ts': tuples,
    },
    (result) => {
      assert.ok(result.fields.every((field) => field.access === 'display-only'));
      assert.equal(result.fields.length, 2);
      assert.match(result.uses[1].unsupported[0], /Unresolved binding unused/);
    },
  );
});
test('same-named unused descriptor on another file cannot satisfy the rendered unknown binding', () => {
  fixture(
    {
      'page.tsx':
        "import {fields as elsewhere} from './fields';export default function Page(){return <tr>{missing.map(c=><th>{c.label}</th>)}</tr>}",
      'fields.ts': tuples,
    },
    (result) => {
      assert.deepEqual(result.fields, []);
      assert.match(result.uses[0].unsupported[0], /Unresolved binding missing/);
    },
  );
});
test('real Design/Tour imported fields are traced without changing wholesale nested mapping', () => {
  const root = resolve(dirname(fileURLToPath(import.meta.url)), '../..');
  const scanner = descriptorScanner(root);
  const design = scanner.analyzePage(join(root, 'apps/web/app/(app)/masters/design-book/page.tsx'));
  const tour = scanner.analyzePage(join(root, 'apps/web/app/(app)/txn/tour-order/page.tsx'));
  assert.equal(design.fields.length, 48);
  assert.equal(design.fields.filter((field) => field.identity).length, 3);
  assert.ok(
    design.fields.every(
      (field) => field.file === 'apps/web/lib/designBookDraft.ts' && field.conditional,
    ),
  );
  assert.equal(
    tour.fields.filter((field) => field.file === 'apps/web/lib/tourOrderForm.ts').length,
    68,
  );
  const page = readFileSync(join(root, 'apps/web/app/(app)/txn/wholesale-sale/page.tsx'), 'utf8');
  const writer = readFileSync(join(root, 'apps/api/src/modules/sales/rateCut.ts'), 'utf8');
  // Preservation tripwire only, not an end-to-end tracer: X02's nested route/reader controls remain open.
  for (const key of ['issueYear', 'issueBook', 'issueNo', 'issueSrno'])
    assert.ok(page.includes(`l.${key}`));
  assert.match(page, /isuRef:\s*sourceRef/);
  assert.match(writer, /const ref = l\.isuRef \?\? \{\}/);
  for (const [column, key] of [
    ['ISU_YRCD', 'yrcd'],
    ['ISU_DBCD', 'dbcd'],
    ['ISU_NO', 'no'],
    ['ISU_SRNO', 'srno'],
  ])
    assert.ok(writer.includes(`${column}: ref.${key}`));
});

// These two pages once advertised editable inputs that their shared ordinary writer discards.
// Exercise the actual descriptor consumer; merely retaining a name in a type cannot pass this test.
for (const slug of ['sales', 'sales-quotation']) {
  test(`${slug} exposes supported values without editable server-owned identity columns`, () => {
    const root = resolve(dirname(fileURLToPath(import.meta.url)), '../..');
    const page = join(root, 'apps/web/app/(app)/txn', slug, 'page.tsx');
    const result = descriptorScanner(root).analyzePage(page);
    const editable = result.fields.filter((field) => field.access === 'editable-candidate');
    assert.ok(editable.some((field) => field.key === 'otherWt'));
    assert.ok(editable.some((field) => field.key === 'metal'));
    assert.ok(!editable.some((field) => ['oldSrNo', 'itType'].includes(field.key)));
    const source = readFileSync(page, 'utf8');
    assert.doesNotMatch(source, /(?:oldSrNo|itType):\s*(?:n\()?l\./);
    assert.match(source, /vchSrno:\s*l\.vchSrno/);
    assert.match(source, /ordSrno:\s*l\.ordSrno/);
  });
}
