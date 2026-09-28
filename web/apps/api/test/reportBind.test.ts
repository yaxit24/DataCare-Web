import { describe, expect, it } from 'vitest';
import { bindReport, UnsupportedReportBindingError } from '../src/modules/reports/reportBind.js';
import type { RptSpec } from '../src/modules/reports/reportEngine.js';
import { loadReportSpec, renderReportLayout } from '../src/modules/reports/reportEngine.js';
import {
  REPORT_BINDING_CONTRACTS,
  resolveReportBinding,
} from '../src/modules/reports/reportBindingContract.js';

describe('report binding registry', () => {
  it.each(Object.keys(REPORT_BINDING_CONTRACTS))(
    'validates the extracted band/dataset contract for %s',
    (name) => {
      const spec = loadReportSpec(name)!;
      expect(spec).toBeTruthy();
      expect(resolveReportBinding(spec)).toBe(REPORT_BINDING_CONTRACTS[name]);
    },
  );

  it('does not infer a family from an unregistered template containing sales fields', () => {
    const spec = { ...loadReportSpec('SalesBillHz')!, report: 'UnknownSalesLayout' };
    expect(() => resolveReportBinding(spec)).toThrow('unregistered-template');
  });

  it('refuses a second business dataset instead of choosing the first matching family', () => {
    const spec = structuredClone(loadReportSpec('SalesBillHz')!);
    spec.formulas.push({
      name: 'UnexpectedPurchase',
      ref: '{@UnexpectedPurchase}',
      type: '',
      text: '{PR_DATA.NET_AMT}',
    });
    expect(() => resolveReportBinding(spec)).toThrow('unbound-table:PR_DATA');
  });

  it('refuses unbound subreports and incomplete group metadata', () => {
    const spec = structuredClone(loadReportSpec('SalesBillHz')!);
    spec.areas[0]!.sections[0]!.objects.push({
      name: 'MissingChildReport',
      type: 'SubreportObject',
      left: 0,
      top: 0,
      width: 100,
      height: 10,
    });
    expect(() => resolveReportBinding(spec)).toThrow('unsupported-object:SubreportObject');
    expect(() => resolveReportBinding(loadReportSpec('SalesQuotation')!)).toThrow(
      'unregistered-template',
    );
    expect(() => resolveReportBinding(loadReportSpec('SalesBillA4_WithImage')!)).toThrow(
      'unregistered-template',
    );
  });

  it('rejects parent amounts referenced by a component band, including through a formula', () => {
    const spec = structuredClone(loadReportSpec('SalesBillHz')!);
    spec.formulas.push({
      name: 'ParentMoney',
      ref: '{@ParentMoney}',
      type: '',
      text: '{SL_DETL.NET_AMT}',
    });
    spec.areas
      .flatMap((area) => area.sections)
      .find((section) => section.kind === 'Detail')!.objects[0]!.dataSource = '{@ParentMoney}';
    expect(() => resolveReportBinding(spec)).toThrow('parent-reference-in-child-band');
  });

  it('does not manufacture a component when an explicitly bound dataset is empty', () => {
    const spec = loadReportSpec('SalesBillHz')!;
    const html = renderReportLayout(spec, {
      header: { 'SL_DATA.AC_NAME': 'Buyer' },
      detailRows: [{ 'SL_DETL.NET_AMT': '43210.17' }],
      parentChild: {
        parentSections: ['Section9'],
        childSections: ['Section5'],
        parentFooterSections: ['Section10'],
        groups: [{ key: '1', parent: { 'SL_DETL.NET_AMT': '43210.17' }, children: [] }],
      },
    });
    expect(html).toContain('>43210.17<');
    expect(html).not.toContain('data-kind="Detail"');
    expect(html).not.toContain('[IT_NET_AMT]');
  });

  it('refuses an unsupported spec instead of falling back to sales data', async () => {
    const spec: RptSpec = {
      report: 'UnmappedLayout',
      areas: [],
      formulas: [],
      sectionCount: 0,
      objectCount: 0,
      formulaCount: 0,
    };

    await expect(
      bindReport({}, spec, {
        tenantId: 'tenant-a',
        coCode: '01',
        lcCode: '01',
        coYear: '2026-2027',
        coBook: 'SAL',
        vchNo: '00001',
      }),
    ).rejects.toBeInstanceOf(UnsupportedReportBindingError);
  });
});
