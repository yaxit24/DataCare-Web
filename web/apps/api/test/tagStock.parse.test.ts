import { describe, expect, it } from 'vitest';
import { parseTagStockQuery, TagStockValidationError } from '../src/modules/reports/tagStock.js';
import { tagStockCsv } from '../src/modules/reports/tagStockColumns.js';

describe('Tag Stock query parser', () => {
  it('refuses a selector it does not support instead of returning the unfiltered report', () => {
    expect(() => parseTagStockQuery({ tab: 'stock', acCode: 'X' })).toThrow(
      TagStockValidationError,
    );
    expect(() => parseTagStockQuery({ city: 'Surat' })).toThrow(/city/);
  });
  it('accepts every selector the screen sends', () => {
    const q = {
      tab: 'in',
      view: 'tag',
      fromDate: '2026-04-01',
      toDate: '2026-04-07',
      sysDate: '2026-05-31',
      lcCode: '',
      itType: 'G',
      itCode: 'GR',
      prCode: 'P1',
      grCode: 'G1',
      tagNo: 'A1',
      size: '7',
      bookCode: 'TOP',
      aprKind: 'party',
      search: 'A',
    };
    expect(parseTagStockQuery(q).tab).toBe('in');
  });
});

describe('Tag Stock CSV', () => {
  it('quotes a value that would be a spreadsheet formula', () => {
    const csv = tagStockCsv({
      columns: [{ key: 'design', header: 'Design', kind: 'text' }],
      rows: [{ design: '=1+1' }, { design: '@x' }, { design: '-5' }, { design: '+7' }],
      totals: {},
    });
    const lines = csv.split('\n');
    expect(lines.slice(1, 5)).toEqual([`"'=1+1"`, `"'@x"`, `"'-5"`, `"'+7"`]);
  });
});
