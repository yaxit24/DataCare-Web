import { describe, expect, it } from 'vitest';
import {
  renderTagLabels,
  subTagPrintLine,
  tagLabelFile,
  tagLabelLines,
  type PrintableTag,
} from '../src/modules/stock/tagPrint.js';

/**
 * Tag label text rules, taken from the desktop label files, not from the web's own output.
 *
 * QrPrint10, BarPrint10, BarPrint13 and GhatTagPrnt (extraction_output/rpt_xml/*.xml, report specs under
 * web/apps/api/report-specs/) are the files UT_TAG_PRINT lists for PRINT_TYPE 'TAG' (UT_TAG_PRINT.cs:4930). Their
 * data formulas are identical in all four files:
 *
 *   ItmWt    = 'G.' + totext(TAG_PRINT_DATA.ITM_GWT, 3)
 *   OtherAmt = 'N.' + totext(TAG_PRINT_DATA.ITM_NWT, 3)
 *   Labour   = if ITM_MRP <> 0 then 'MRP: ' & totext(ITM_MRP, '0')
 *              else if LBR_RATE <> 0 then 'LP: ' & totext(LBR_RATE, '0')
 *              else if LBR_AMT <> 0 then 'LF: ' & totext(LBR_AMT, '0')        (no final else: an empty line)
 *   TagNo    = '*' + TAG_NO + '*'                                              (the Code 39 start/stop characters)
 *
 * Crystal's totext(x, n) rounds half away from zero to n decimals and always shows n decimals. The values below
 * are worked by hand from those formulas. The desktop shows the same text on a printed label: the tutorial
 * keyframe of the preview reads "G.14.300 / N.14.300 / LP: 600" (project-memory/video-research, VzkTOy9vGL0 kf_004).
 *
 * The PRINT_MAST file choice, the SubTagPrint sub-report (BarPrint10.xml:72), BarPrint13's `L.` line and the `*tag*` text
 * are covered by N249 / G261 below. The web's SVG encoder adds the Code 39 start and stop characters itself.
 */
const tag = (over: Partial<PrintableTag> = {}): PrintableTag => ({
  tagNo: 'CHG00004',
  itCode: 'G22',
  designNo: 'D1',
  tblCode: null,
  netWt: 14.3,
  grossWt: 14.3,
  touch: 91.6,
  mrp: 0,
  rate: 0,
  hmId: null,
  pcs: 1,
  lbrRate: 0,
  lbrAmt: 0,
  ...over,
});

describe('tag label text rules (QrPrint10 / BarPrint10 / BarPrint13 / GhatTagPrnt formulas)', () => {
  it('prints gross and net weight with the G. and N. prefixes at exactly three decimals', () => {
    const l = tagLabelLines(tag());
    expect(l.gross).toBe('G.14.300');
    expect(l.net).toBe('N.14.300');
  });

  it('pads and rounds the weights half away from zero at three decimals', () => {
    // 10.5 -> 10.500 ; 9.9996 -> 10.000 ; 0.0005 -> 0.001 (half away from zero) ; 0 -> 0.000
    expect(tagLabelLines(tag({ grossWt: 10.5 })).gross).toBe('G.10.500');
    expect(tagLabelLines(tag({ grossWt: 9.9996 })).gross).toBe('G.10.000');
    expect(tagLabelLines(tag({ netWt: 0.0005 })).net).toBe('N.0.001');
    expect(tagLabelLines(tag({ netWt: 0 })).net).toBe('N.0.000');
  });

  it('labour line: MRP wins over LP and LF, LP wins over LF, none prints an empty line', () => {
    expect(tagLabelLines(tag({ mrp: 55000, lbrRate: 600, lbrAmt: 90 })).labour).toBe('MRP: 55000');
    expect(tagLabelLines(tag({ mrp: 0, lbrRate: 600, lbrAmt: 90 })).labour).toBe('LP: 600');
    expect(tagLabelLines(tag({ mrp: 0, lbrRate: 0, lbrAmt: 90 })).labour).toBe('LF: 90');
    expect(tagLabelLines(tag({ mrp: 0, lbrRate: 0, lbrAmt: 0 })).labour).toBe('');
  });

  it("labour amounts use totext(x,'0'): no thousands separator, whole number, half away from zero", () => {
    // Crystal totext(55000,'0') is "55000" (the web used Indian grouping "55,000" with a rupee sign)
    expect(tagLabelLines(tag({ mrp: 1234567 })).labour).toBe('MRP: 1234567');
    expect(tagLabelLines(tag({ lbrRate: 599.5 })).labour).toBe('LP: 600');
    expect(tagLabelLines(tag({ lbrRate: 600.49 })).labour).toBe('LP: 600');
    expect(tagLabelLines(tag({ lbrAmt: 0.5 })).labour).toBe('LF: 1');
  });

  it('the zero test is on the raw value, so a small amount still prints its line (Crystal compares before totext)', () => {
    // LBR_RATE <> 0 is true for 0.4, then totext(0.4,'0') is "0": the label shows "LP: 0", not an empty line.
    expect(tagLabelLines(tag({ lbrRate: 0.4 })).labour).toBe('LP: 0');
    expect(tagLabelLines(tag({ mrp: 0.4, lbrRate: 600 })).labour).toBe('MRP: 0');
    expect(tagLabelLines(tag({ lbrAmt: 0.4 })).labour).toBe('LF: 0');
  });

  it('prints the barcode text as *TAG_NO* (@TagNo) and keeps the scannable barcode', () => {
    expect(tagLabelLines(tag({ tagNo: 'TP0001' })).barcodeText).toBe('*TP0001*');
    const html = renderTagLabels([tag({ tagNo: 'CHG00004' })], 0, 'BarPrint10');
    expect(html).toContain('<svg');
    expect(html).toContain('<div class="bcnum">*CHG00004*</div>');
  });

  it('less weight is gross minus net at three decimals (BarPrint13.xml:217)', () => {
    expect(tagLabelLines(tag({ grossWt: 10.5, netWt: 10 })).less).toBe('L.0.500');
    expect(tagLabelLines(tag({ grossWt: 10.505, netWt: 10 })).less).toBe('L.0.505');
    expect(tagLabelLines(tag({ grossWt: 10, netWt: 10 })).less).toBe('L.0.000');
  });

  it('the SubTagPrint line is IT_CODE / totext(IT_AMT,0) (BarPrint10.xml:72)', () => {
    expect(subTagPrintLine('GLD1', 1234.5)).toBe('GLD1 / 1235');
    expect(subTagPrintLine('GLD2', 99.4)).toBe('GLD2 / 99');
    expect(subTagPrintLine('GLD3', 10)).toBe('GLD3 / 10');
    expect(subTagPrintLine('GLD4', null)).toBe('GLD4 / 0');
  });

  it('resolves the PRINT_MAST name to the Crystal file, ignoring case and .rpt, BarPrint10 for any other name', () => {
    expect(tagLabelFile('QrPrint10').qr).toBe(true);
    expect(tagLabelFile('barprint13.RPT')).toMatchObject({ subReport: null, lessWt: true });
    expect(tagLabelFile('GhatTagPrnt').subReport).toBe('voucher');
    expect(tagLabelFile('BarPrint10').subReport).toBe('tag');
    expect(tagLabelFile('Company Own').name).toBe('BarPrint10');
    expect(tagLabelFile(undefined).name).toBe('BarPrint10');
  });

  it('each file places its own fields', () => {
    const full = tag({
      tagNo: 'TP0001',
      grossWt: 10.5,
      netWt: 10,
      mrp: 55000,
      krName: 'KARI-1',
      shopName: 'E2E SHOP',
      grCode: 'E1',
      subLines: ['GLD1 / 1235'],
      qrSvg: '<svg id="qr"></svg>',
    });
    const q = renderTagLabels([full], 0, 'QrPrint10');
    expect(q).toContain('id="qr"');
    expect(q).toContain('GLD1 / 1235');
    expect(q).not.toContain('*TP0001*');
    expect(q).not.toContain('L.0.500');
    const b10 = renderTagLabels([full], 0, 'BarPrint10');
    expect(b10).toContain('*TP0001*');
    expect(b10).toContain('GLD1 / 1235');
    expect(b10).not.toContain('L.0.500');
    expect(b10).not.toContain('id="qr"');
    const b13 = renderTagLabels([full], 0, 'BarPrint13');
    expect(b13).toContain('L.0.500');
    expect(b13).toContain('*TP0001*');
    expect(b13).not.toContain('GLD1');
    const g = renderTagLabels([full], 0, 'GhatTagPrnt');
    expect(g).toContain('GLD1 / 1235');
    expect(g).toContain('*TP0001*');
    for (const html of [q, b10, b13, g])
      for (const t of ['G.10.500', 'N.10.000', 'MRP: 55000', 'KARI-1', 'E2E SHOP', 'E1', 'TP0001'])
        expect(html).toContain(t);
  });
  it('renders those lines in the label sheet', () => {
    const html = renderTagLabels([tag({ lbrRate: 600 })]);
    expect(html).toContain('G.14.300');
    expect(html).toContain('N.14.300');
    expect(html).toContain('LP: 600');
    expect(html).not.toContain('MRP');
    expect(html).toContain('CHG00004');
  });

  it('does not print the old web-only wording', () => {
    const html = renderTagLabels([tag({ mrp: 55000 })]);
    expect(html).not.toContain('Net 14.3 g');
    expect(html).not.toContain('Gr 14.3 g');
    expect(html).not.toContain('₹');
    expect(html).toContain('MRP: 55000');
  });

  it('prints no hallmark id line: none of the four label files places HM_ID (N249, was a web addition)', () => {
    expect(renderTagLabels([tag({ hmId: 'AB12CD' })])).not.toContain('HUID');
    expect(renderTagLabels([tag({ hmId: 'AB12CD' })])).not.toContain('AB12CD');
  });

  it('escapes markup in every printed value', () => {
    const html = renderTagLabels([tag({ tagNo: 'A<B', designNo: '<i>x</i>' })]);
    expect(html).not.toContain('<i>x</i>');
    expect(html).toContain('A&lt;B');
  });
});
