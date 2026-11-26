import { describe, expect, it } from 'vitest';
import { tagStockPrintHtml, tagStockPrintTitle } from '../src/modules/reports/tagStockPrint.js';
import {
  applyHuidSearch,
  huidTagTotals,
  type HuidTagRow,
} from '../src/modules/reports/huidTagReport.js';
import { printResultOf } from '../src/routes/huidReport.js';

describe('inventory report output contracts', () => {
  it('RP_TAG:8847/8851 chooses the product or item summary template and dated title', () => {
    for (const [kind, template] of [
      ['summ-product', 'TagStkSummRpt'],
      ['summ-item', 'TagStkItemSumRpt'],
    ] as const) {
      expect(
        tagStockPrintTitle({
          kind,
          view: 'tag',
          lcCode: '01',
          fromDate: '2026-04-01',
          toDate: '2026-05-31',
        }),
      ).toEqual({
        title: 'Branch - 01 Tag Wise Stock Summary As on Date 01/04/2026 To 31/05/2026',
        template,
      });
    }
  });
  it('escapes stored text in printed rows, headings and template metadata', () => {
    const html = tagStockPrintHtml({
      company: '<script>x</script>',
      title: 'A&B',
      template: '" onload="x',
      columns: [
        { key: 'tag', header: '<Tag>', kind: 'text' },
        { key: 'gross', header: 'Grwt', kind: 'wt', total: true },
      ],
      rows: [{ tag: '<img src=x>', gross: 1.25 }],
      totals: { gross: 1.25 },
    });
    expect(html).not.toContain('<script>');
    expect(html).not.toContain('<img');
    expect(html).toContain('&lt;Tag&gt;');
    expect(html).toContain('A&amp;B');
    expect(html.match(/1\.250/g)).toHaveLength(2);
  });
  it('RP_HUID:1669-1689 searches the first matching HUID slot, never a tag prefix', () => {
    const rows = [
      { tagNo: 'JT001', huId: 'HU0001', huId2: 'HU0002' },
      { tagNo: 'JT002', huId: 'HU0002' },
    ] as HuidTagRow[];
    expect(applyHuidSearch(rows, 'JT')).toEqual([]);
    expect(applyHuidSearch(rows, 'HU0002')).toEqual([rows[1]]);
  });
  it('RP_HUID:2068-2096 sums stored thousandths without floating-point drift', () => {
    const rows = ['0.100', '0.200', '-0.001'].map((n) => ({
      pcs: '1.000',
      grwt: n,
      netWt: n,
      huWt: n,
      huWt2: '',
      huWt3: '',
      huWt4: '',
    })) as HuidTagRow[];
    expect(huidTagTotals(rows)).toEqual({
      qty: 3,
      pcs: '3.000',
      grwt: '0.299',
      netWt: '0.299',
      huWt: '0.299',
      huWt2: '0.000',
      huWt3: '0.000',
      huWt4: '0.000',
    });
  });
  it('TagHuIdRpt.xml:312-380 prints product > group sections by code and tag, each with its weight sums', () => {
    const row = (
      tagNo: string,
      prCode: string,
      grCode: string,
      grwt: string,
      vchDate = '2026-05-01',
    ) =>
      ({
        tagNo,
        prCode,
        grCode,
        vchDate,
        pcs: '1.000',
        grwt,
        netWt: grwt,
        huWt: '0.100',
        huWt2: '',
        huWt3: '',
        huWt4: '',
      }) as HuidTagRow;
    const printed = printResultOf({
      view: 'stock',
      from: '2026-04-01',
      to: '2026-05-31',
      rows: [
        row('T3', 'P2', 'G1', '3.000'),
        row('T2', 'P1', 'G2', '2.000'),
        row('T9', 'P1', 'G1', '9.000'),
        row('T1', 'P1', 'G1', '1.000'),
        // RP_HUID.cs:2219: the print selects VCH_DATE <= To, so a later voucher is not printed.
        row('T0', 'P1', 'G1', '5.000', '2026-06-01'),
      ],
    } as never);
    expect(Object.keys(printed).filter((k) => k.startsWith('Product'))).toEqual([
      'Product P1 / Group G1',
      'Product P1 / Group G2',
      'Product P1 total',
      'Product P2 / Group G1',
      'Product P2 total',
    ]);
    const g11 = printed['Product P1 / Group G1'] as Array<Record<string, unknown>>;
    expect(g11.map((r) => r.tagNo)).toEqual(['T1', 'T9', 'Group total']);
    expect(g11[2]).toMatchObject({ pcs: '2.000', grwt: '10.000', netWt: '10.000', huWt: '0.200' });
    expect((printed['Product P1 total'] as Array<Record<string, unknown>>)[0]).toMatchObject({
      tagNo: 'Product total',
      pcs: '3.000',
      grwt: '12.000',
    });
    expect(printed.totals).toMatchObject({ qty: 4, pcs: '4.000', grwt: '15.000', huWt: '0.400' });
  });
});
