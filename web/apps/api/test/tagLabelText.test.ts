import { describe, expect, it } from 'vitest';
import {
  renderTagLabels,
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
 * Not covered here, on purpose: the shop name, the purity group and the karigar name sit at different places on
 * different label files, and the web does not model the PRINT_MAST file choice. TagNo is '*' + TAG_NO + '*' for a barcode
 * font; the web's SVG encoder adds the start and stop characters itself.
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

  it('the barcode still encodes the tag number (Code 39 adds the * start and stop characters itself)', () => {
    // The desktop TagNo formula wraps the number in asterisks only so its barcode font prints them; the web's SVG
    // encoder (code39Svg) adds the start/stop pair, so the label must not print or encode a second pair.
    const html = renderTagLabels([tag({ tagNo: 'CHG00004' })]);
    expect(html).toContain('<svg');
    expect(html).toContain('<div class="bcnum">CHG00004</div>');
    expect(html).not.toContain('*CHG00004*');
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

  it('keeps the hallmark id: BarPrint13, GhatTagPrnt and ItmLotPrint print HM_ID and a hallmarked piece must show it', () => {
    expect(renderTagLabels([tag({ hmId: 'AB12CD' })])).toContain('HUID: AB12CD');
  });

  it('escapes markup in every printed value', () => {
    const html = renderTagLabels([tag({ tagNo: 'A<B', designNo: '<i>x</i>' })]);
    expect(html).not.toContain('<i>x</i>');
    expect(html).toContain('A&lt;B');
  });
});
