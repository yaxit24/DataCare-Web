import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import { blank, hydrateTourOrder, tourOrderPayload } from '../lib/tourOrderForm';
const bytes = readFileSync(new URL('./fixtures/tourExactValues.independent.json', import.meta.url));
const fixture = JSON.parse(bytes.toString());
const saved = () => structuredClone(fixture.original);
const row = (editor: ReturnType<typeof hydrateTourOrder>, srNo = '7') =>
  editor.rows.find((line: { srNo?: string }) => line.srNo === srNo)!;
const payload = (editor: ReturnType<typeof hydrateTourOrder>, original: Record<string, any>) =>
  tourOrderPayload(editor.f, editor.header, editor.rows, original.version, original) as Record<
    string,
    any
  >;
const child = (output: Record<string, any>, srNo = 7, isrNo = 3) =>
  output.lines
    .find((line: any) => line.srNo === srNo)
    .components.find((part: any) => part.isrNo === isrNo);

describe('saved Tour exact input-shaped values', () => {
  it('pins16 independent preimplementation cases unchanged', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '4531bd17b90cd2c7700db743bb36b1981486d08fcc1c37511ac41efb4ea8917a',
    );
    expect(fixture.cases).toHaveLength(16);
  });
  it('shows exact huge scalars, blank NULL cells, true zeros and leading-zero codes without load events', () => {
    const editor = hydrateTourOrder(saved());
    expect(editor.header).toMatchObject({ mobile: '', address1: '', schemeAmount: '0' });
    expect(row(editor)).toMatchObject({
      mrp: '999999999999999.99',
      bagWt: '',
      otherAmount: '0',
      labourEdits: [],
      labourAction: '',
    });
    expect(row(editor, '19')).toMatchObject({ mrp: '0', bagWt: '0' });
    expect(row(editor).components).toMatchObject([
      { isrNo: '3', rate: '', pcs: '0', dmCode: '00012', karigarRate: '999999999999998.99' },
      { isrNo: '13', rate: '0', lbrRate: '', karigarRate: '999999999999997.99' },
    ]);
  });
  it('restores independently pinned exact scalar types for unchanged complete rows and children', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    const before = structuredClone({ original, editor });
    const result = payload(editor, original);
    expect(result).toMatchObject(fixture.cases.find((value: any) => value.id === 'E02').expected);
    expect({ original, editor }).toEqual(before);
    expect(result.expectedVersion).toBe(original.version);
    expect(result.lines[0]).not.toHaveProperty('itemAmount');
    expect(result.lines[0]).not.toHaveProperty('lineNetAmount');
  });
  it('an advance-only change preserves all parent and child wire values and forwards exact editor text', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    const before = payload(editor, original);
    editor.f.advanceAmount = '40';
    const result = payload(editor, original);
    expect(result.advanceAmount).toBe('40');
    expect(result.lines).toEqual(before.lines);
    expect(result.mobile).toBeNull();
    expect(result.schemeAmount).toBe(0);
  });
  it.each(['999999999999998.99', '25.50'])(
    'changed MRP %s reaches the existing writer unrounded',
    (value) => {
      const original = saved(),
        editor = hydrateTourOrder(original);
      row(editor).mrp = value;
      expect(payload(editor, original).lines[0].mrp).toBe(value);
    },
  );
  it('an unsupported changed child decimal is preserved for server refusal rather than rounded', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    row(editor).components[0]!.karigarRate = '999999999999996.99';
    expect(child(payload(editor, original)).karigarRate).toBe('999999999999996.99');
  });
  it('reordering parents and children preserves attachment by parent SR and child ISR', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    editor.rows.reverse();
    row(editor).components.reverse();
    const result = payload(editor, original);
    expect(result.lines.map((line: any) => line.srNo)).toEqual([19, 7]);
    expect(result.lines[1].components.map((part: any) => [part.isrNo, part.karigarRate])).toEqual([
      [13, '999999999999997.99'],
      [3, '999999999999998.99'],
    ]);
    expect(result.lines[0].components).toEqual([]);
  });
  it('explicit component removal remains removal and does not restore a deleted child', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    row(editor).components.splice(0, 1);
    expect(payload(editor, original).lines[0].components).toHaveLength(1);
    expect(child(payload(editor, original), 7, 13).karigarRate).toBe('999999999999997.99');
  });
  it('never copies arbitrary original table state, authority or readonly calculated fields', () => {
    const original = saved();
    Object.assign(original, {
      raw: { dangerous: true },
      ledger: [{ amount: 1 }],
      identity: 'foreign',
      tenantId: 'foreign',
    });
    Object.assign(original.lines[0], {
      row_id: '999',
      raw: { secret: 1 },
      scope: { coBook: 'BAD' },
    });
    Object.assign(original.lines[0].components[0], { row_id: '998', raw: { secret: 2 } });
    const result = payload(hydrateTourOrder(original), original);
    for (const key of ['raw', 'ledger', 'identity', 'tenantId', 'coCode', 'coBook'])
      expect(result).not.toHaveProperty(key);
    for (const value of [result.lines[0], child(result)])
      for (const key of ['row_id', 'raw', 'scope']) expect(value).not.toHaveProperty(key);
  });
  it('a mismatched retained version refuses before any baseline restoration', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    expect(() =>
      tourOrderPayload(editor.f, editor.header, editor.rows, 'b'.repeat(64), original),
    ).toThrow('snapshot no longer matches');
  });
  it.each(['NaN', 'Infinity'])('preserves existing finite number refusal for %s', (value) => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    row(editor).mrp = value;
    expect(() => payload(editor, original)).toThrow('valid number');
  });
  it('ordinary changed text leaves exact unrelated scalars and existing labour journal unchanged', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    row(editor).remark = 'New remark';
    const result = payload(editor, original);
    expect(result.lines[0].remark).toBe('New remark');
    expect(result.lines[0].mrp).toBe('999999999999999.99');
    expect(result.lines[0].labourEdits).toEqual([]);
    expect(child(result).rate).toBeNull();
    expect(child(result, 7, 13).rate).toBe(0);
  });
  it('a new parent/child without saved IDs cannot borrow raw scalars from an old visual position', () => {
    const original = saved(),
      editor = hydrateTourOrder(original);
    editor.rows = [
      {
        ...blank(),
        itCode: 'NEW',
        grossWt: '1',
        netWt: '1',
        touch: '100',
        rate: '2',
        components: [{ itCode: 'STN2', pcs: '1' }],
      },
    ];
    const result = payload(editor, original);
    expect(result.lines[0].mrp).toBeUndefined();
    expect(result.lines[0].components[0].karigarRate).toBeUndefined();
    expect(result.lines[0].srNo).toBeUndefined();
    expect(result.lines[0].components[0].isrNo).toBeUndefined();
  });
  it.each(['parent', 'child'] as const)(
    'ambiguous saved %s identity is not silently matched by the first row',
    (kind) => {
      const original = saved(),
        editor = hydrateTourOrder(original);
      if (kind === 'parent') original.lines.push(structuredClone(original.lines[0]));
      else original.lines[0].components.push(structuredClone(original.lines[0].components[0]));
      expect(() => payload(editor, original)).toThrow('identity is ambiguous');
    },
  );
  it('the four-argument path used by Sales and new Tour remains numerically compatible', () => {
    const editor = hydrateTourOrder(saved());
    const result = tourOrderPayload(editor.f, editor.header, editor.rows, 'a'.repeat(64)) as Record<
      string,
      any
    >;
    expect(result.advanceAmount).toBe(25);
    expect(result.lines[0].mrp).toBe(Number('999999999999999.99'));
    expect(result.mobile).toBeUndefined();
  });
  it('Tour page retains a detached document and supplies it only with the selected saved form', () => {
    const source = readFileSync(
      new URL('../app/(app)/txn/tour-order/page.tsx', import.meta.url),
      'utf8',
    );
    expect(source).toContain('original: structuredClone(document)');
    expect(source).toMatch(
      /tourOrderPayload\([\s\S]*?selected\?\.version,[\s\S]*?selected\?\.original/,
    );
    expect(source).toContain('setSelected(null)');
  });
});
