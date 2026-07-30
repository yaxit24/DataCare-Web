import { describe, expect, it } from 'vitest';
import { unzipSync, strFromU8 } from 'fflate';
import {
  inferSheet,
  looksLikeFormula,
  renderXlsx,
  safeFileName,
  safeSheetName,
  XLSX_CONTENT_TYPE,
} from '../src/modules/reports/xlsx.js';

/**
 * XLSX writer contract.
 *
 * 38 desktop forms offer an Excel export and the web had none, so this is new shared infrastructure rather
 * than a port. The assertions therefore check the actual OOXML container and cell XML — not merely that a
 * Buffer came back — because "it downloaded" is exactly the kind of evidence that hides a broken file.
 *
 * `fflate` is used only here, to unzip and read the parts. No spreadsheet PARSER is added to production:
 * the application writes workbooks and never reads them.
 */
const unzip = (buf: Buffer): Record<string, string> => {
  const files = unzipSync(new Uint8Array(buf));
  return Object.fromEntries(Object.entries(files).map(([k, v]) => [k, strFromU8(v)]));
};

describe('xlsx writer', () => {
  const sheet = {
    name: 'Cash Book',
    columns: [
      { header: 'Voucher', key: 'vch', type: 'text' as const },
      { header: 'Amount', key: 'amt', type: 'number' as const, format: '0.00' },
      { header: 'Weight', key: 'wt', type: 'number' as const, format: '0.000' },
    ],
    rows: [
      { vch: 'SL/00001', amt: 1250.25, wt: 9.4 },
      { vch: 'SL/00002', amt: -300.5, wt: 0 },
    ],
    totals: { vch: 'Total', amt: 949.75, wt: 9.4 },
  };

  it('produces a real OOXML package', async () => {
    const r = await renderXlsx([sheet], 'cash book');
    // ZIP local file header.
    expect(r.buffer.subarray(0, 4).toString('binary')).toBe('PK\u0003\u0004');
    expect(r.contentType).toBe(XLSX_CONTENT_TYPE);
    expect(r.fileName).toBe('cash_book.xlsx');
    const parts = unzip(r.buffer);
    expect(Object.keys(parts)).toContain('[Content_Types].xml');
    expect(Object.keys(parts)).toContain('xl/workbook.xml');
    expect(Object.keys(parts).some((p) => /^xl\/worksheets\/sheet\d+\.xml$/.test(p))).toBe(true);
  });

  it('names the sheet and writes the header and every row', async () => {
    const r = await renderXlsx([sheet], 'x');
    const parts = unzip(r.buffer);
    expect(parts['xl/workbook.xml']).toContain('Cash Book');
    const ws = Object.entries(parts).find(([k]) => /worksheets\/sheet1\.xml$/.test(k))?.[1] ?? '';
    // 1 header + 2 data rows + 1 totals row.
    expect((ws.match(/<row /g) ?? []).length).toBe(4);
    const all = Object.values(parts).join('');
    expect(all).toContain('SL/00001');
    expect(all).toContain('Voucher');
  });

  it('writes numbers as numeric cells with their format', async () => {
    const r = await renderXlsx([sheet], 'x');
    const parts = unzip(r.buffer);
    const ws = Object.entries(parts).find(([k]) => /worksheets\/sheet1\.xml$/.test(k))?.[1] ?? '';
    // The exact seeded amount must be present as a number, not as text.
    expect(ws).toContain('<v>1250.25</v>');
    expect(ws).toContain('<v>-300.5</v>');
    expect(parts['xl/styles.xml']).toContain('0.000'); // metal-weight format survives
  });

  it('never emits a formula cell, even for formula-looking data', async () => {
    // A remark beginning with = + - @ is ordinary business text and must stay text.
    const dangerous = {
      name: 'Injection',
      columns: [{ header: 'Note', key: 'note', type: 'text' as const }],
      rows: [{ note: '=2+2' }, { note: '+cmd|calc' }, { note: '-1+2' }, { note: '@SUM(A1:A2)' }],
    };
    const r = await renderXlsx([dangerous], 'inj');
    const parts = unzip(r.buffer);
    const all = Object.values(parts).join('');
    // No formula element anywhere in the workbook.
    expect(all).not.toMatch(/<f[ >]/);
    // The literal text is preserved so no data is lost by the protection.
    const strings = (parts['xl/sharedStrings.xml'] ?? '') + all;
    expect(strings).toContain('2+2');
    expect(strings).toContain('SUM(A1:A2)');
    // And the helper agrees these are the risky shapes.
    for (const n of ['=2+2', '+cmd|calc', '-1+2', '@SUM(A1:A2)']) {
      expect(looksLikeFormula(n), n).toBe(true);
    }
    expect(looksLikeFormula('SL/00001')).toBe(false);
  });

  it('changing a source value changes the workbook bytes', async () => {
    // Guards against a writer that silently drops data: the amount must actually reach the file.
    const a = await renderXlsx([sheet], 'x');
    const b = await renderXlsx(
      [{ ...sheet, rows: [{ vch: 'SL/00001', amt: 1250.26, wt: 9.4 }, sheet.rows[1]] }],
      'x',
    );
    const wsA = Object.entries(unzip(a.buffer)).find(([k]) =>
      /worksheets\/sheet1\.xml$/.test(k),
    )?.[1];
    const wsB = Object.entries(unzip(b.buffer)).find(([k]) =>
      /worksheets\/sheet1\.xml$/.test(k),
    )?.[1];
    expect(wsA).toContain('1250.25');
    expect(wsB).toContain('1250.26');
    expect(wsA).not.toBe(wsB);
  });

  it('writes a valid workbook for an empty result', async () => {
    const r = await renderXlsx(
      [{ name: 'Empty', columns: [{ header: 'A', key: 'a' }], rows: [] }],
      'empty',
    );
    expect(r.buffer.subarray(0, 2).toString('binary')).toBe('PK');
    const ws = Object.entries(unzip(r.buffer)).find(([k]) =>
      /worksheets\/sheet1\.xml$/.test(k),
    )?.[1];
    expect((ws?.match(/<row /g) ?? []).length).toBe(1); // header only
  });

  it('handles multiple sheets and de-duplicates their names', async () => {
    const r = await renderXlsx(
      [
        { name: 'Report', columns: [{ header: 'A', key: 'a' }], rows: [{ a: 1 }] },
        { name: 'Report', columns: [{ header: 'B', key: 'b' }], rows: [{ b: 2 }] },
      ],
      'multi',
    );
    const parts = unzip(r.buffer);
    expect(parts['xl/workbook.xml']).toContain('Report');
    expect(parts['xl/workbook.xml']).toContain('Report (2)');
  });

  it('sanitises sheet names and filenames', () => {
    const taken = new Set<string>();
    expect(safeSheetName('A/B:C?D*E[F]', taken)).toBe('A B C D E F');
    expect(safeSheetName('x'.repeat(50), taken)).toHaveLength(31);
    expect(safeFileName('../../etc/passwd')).toBe('etc_passwd');
    expect(safeFileName('report 2026/03')).toBe('report_2026_03');
    expect(safeFileName('')).toBe('export');
  });

  it('infers numeric columns but leaves mixed data as text', () => {
    const s = inferSheet('S', [
      { amt: '100', code: 'A1' },
      { amt: '200.5', code: 'B2' },
    ]);
    expect(s.columns.find((c) => c.key === 'amt')?.type).toBe('number');
    expect(s.columns.find((c) => c.key === 'code')?.type).toBe('text');
  });

  it('writes a non-numeric value in a numeric column as text rather than zero', async () => {
    const r = await renderXlsx(
      [
        {
          name: 'S',
          columns: [{ header: 'N', key: 'n', type: 'number' as const }],
          rows: [{ n: 'n/a' }],
        },
      ],
      'x',
    );
    const parts = unzip(r.buffer);
    const all = Object.values(parts).join('');
    expect(all).toContain('n/a'); // preserved, not silently turned into 0
    // Assert the CELL TYPE, not a substring: `t="s"` is a shared-string cell, so the value was written as
    // text. A numeric cell carries no `t` attribute, and `<v>0</v>` alone proves nothing because that is
    // also how a shared-string INDEX of 0 appears.
    const ws = Object.entries(parts).find(([k]) => /worksheets\/sheet1\.xml$/.test(k))?.[1] ?? '';
    const dataCell = ws.match(/<c r="A2"[^>]*>/)?.[0] ?? '';
    expect(dataCell).toContain('t="s"');
  });
});
