import { describe, expect, it } from 'vitest';
import {
  estimatePdfHtml,
  printedTimestamp,
  REPORT_PDF_MAX_ROWS,
  ReportTooLargeForPdfError,
  reportPdfHtml,
  reportPdfSections,
} from '../src/modules/reports/reportPdf.js';

/** N54 / G32: report and estimate PDFs are built on the server from builder results, never from client HTML. */
const at = new Date('2026-10-01T15:45:00.000Z');

describe('server report PDF builder', () => {
  it('shows scalar fields as summary cards and every array field as a totalled table', () => {
    const html = reportPdfHtml({
      company: 'Asha Jewellers',
      title: 'Sales Register',
      coYear: '2026-2027',
      result: {
        count: 2,
        rows: [
          { VCH_NO: '00001', AC_NAME: 'Walk-in', TOT_AMT: 1000 },
          { VCH_NO: '00002', AC_NAME: 'Retail', TOT_AMT: 2500.5 },
        ],
        totals: { TOT_AMT: 3500.5 },
      },
      printedAt: at,
    });
    expect(html).toContain('<div class="co">Asha Jewellers<small>');
    expect(html).toContain('<h1>Sales Register</h1>');
    expect(html).toContain('<b>2026-2027</b>');
    expect(html).toContain('<div class="k">count</div><div class="v">2</div>');
    // VCH_NO reads as an identifier: right-aligned but never summed. TOT_AMT is totalled.
    expect(html).toContain('<td class="num">Total (2 rows)</td>');
    expect(html).toContain('<td class="num">3,500.5</td>');
    expect(html).not.toContain('>3,503<');
    // The nested `totals` object is not a section, as on the screen.
    expect(html.match(/<h2 class="section">/g)).toHaveLength(1);
  });

  it('escapes stored business text, so a party name cannot inject markup into the PDF', () => {
    const html = reportPdfHtml({
      company: '<b>Co</b>',
      title: 'Sales Register',
      coYear: '2026-2027',
      result: { rows: [{ AC_NAME: '<img src="http://169.254.169.254/latest" onerror=alert(1)>' }] },
      printedAt: at,
    });
    expect(html).not.toContain('<img');
    expect(html).not.toContain('<b>Co</b>');
    expect(html).toContain(
      '&lt;img src=&quot;http://169.254.169.254/latest&quot; onerror=alert(1)&gt;',
    );
  });

  it('prints a row-array result as one table (the client PDF showed nothing for these)', () => {
    expect(reportPdfSections([{ A: 1 }, { A: 2 }])).toEqual({
      scalars: [],
      arrays: [['Rows', [{ A: 1 }, { A: 2 }]]],
      rows: 2,
    });
  });

  it('refuses a report too large to print, pointing the user to Excel', () => {
    const rows = Array.from({ length: REPORT_PDF_MAX_ROWS + 1 }, (_, i) => ({ N: i }));
    expect(() =>
      reportPdfHtml({ company: 'C', title: 'T', coYear: '', result: { rows }, printedAt: at }),
    ).toThrow(ReportTooLargeForPdfError);
    expect(() =>
      reportPdfHtml({
        company: 'C',
        title: 'T',
        coYear: '',
        result: { rows: rows.slice(1) },
        printedAt: at,
      }),
    ).not.toThrow();
  });

  it('prints the timestamp in the business time zone (India by default)', () => {
    expect(printedTimestamp(at)).toMatch(/01 Oct 2026, 09:15\s?pm/i);
  });
});

describe('server estimate PDF builder', () => {
  it('builds the estimate letterhead, lines and totals from typed values, escaping the customer', () => {
    const html = estimatePdfHtml({
      company: 'Asha Jewellers',
      customer: 'Mrs <Shah>',
      printedAt: at,
      lines: [{ sr: 1, itCode: 'GOLD', metal: 27480, labour: 2000, net: 29480 }],
      totals: { taxable: 29480, tax: 884.4, total: 30364 },
    });
    expect(html).toContain('<h1>Asha Jewellers</h1>');
    expect(html).toContain('Mrs &lt;Shah&gt;');
    expect(html).toContain('<td>GOLD</td>');
    expect(html).toContain('<b>Total: 30364</b>');
    expect(html).toContain('1/10/2026');
    expect(html).not.toContain('<script');
  });
});
