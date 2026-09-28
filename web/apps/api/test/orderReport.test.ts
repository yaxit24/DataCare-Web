import { describe, expect, it } from 'vitest';
import { loadReportSpec, renderReportLayout } from '../src/modules/reports/reportEngine.js';
import {
  resolveReportBinding,
  type ReportRow,
} from '../src/modules/reports/reportBindingContract.js';
import {
  completeOrderFields,
  orderFormulaValues,
  orderParentFormulaValues,
  orderWholeAmountWords,
  sumReportValues,
  suppressOrderField,
} from '../src/modules/reports/orderReportValues.js';

const prepare = (name = 'TourOrdVch', count = 2, overrides: ReportRow = {}) => {
  const spec = loadReportSpec(name)!;
  const contract = resolveReportBinding(spec);
  const parents = Array.from({ length: name === 'OrderVch' ? 0 : count }, (_, index) =>
    orderParentFormulaValues(spec, {
      'SL_ORD_DETL.SR_NO': String(index + 1),
      'SL_ORD_DETL.TAG_NO': index ? '' : 'TAG-001',
      'SL_ORD_DETL.DESIGN_NO': `DESIGN-${index}`,
      'ITEM_MAST.IT_NAME': `Parent ${index}`,
      'SL_ORD_DETL.ITM_GWT': index ? '2.2' : '1.1',
      'SL_ORD_DETL.NET_AMT': index ? '975.31' : '0',
      'SL_ORD_DETL.ITM_REMARK': index ? 'Keep clasp wide' : '',
    }),
  );
  const received = [
    {
      'SL_PR_DETL.IT_DESC': 'Received gold',
      'SL_PR_DETL.ITM_PCS': '2',
      'SL_PR_DETL.ITM_NWT': '1.1',
    },
    {
      'SL_PR_DETL.IT_DESC': 'Received silver',
      'SL_PR_DETL.ITM_PCS': '3',
      'SL_PR_DETL.ITM_NWT': '2.2',
    },
  ];
  const header = orderFormulaValues(
    spec,
    completeOrderFields(spec, {
      'SL_ORD_DATA.CO_YEAR': '2026-2027',
      'SL_ORD_DATA.CO_BOOK': 'Z09',
      'SL_ORD_DATA.VCH_NO': '00001',
      'SL_ORD_DATA.AC_NAME': 'Customer <one>',
      'SL_ORD_DATA.AC_CODE': 'PARTY',
      'SL_ORD_DATA.VCH_DATE': '2026-04-03',
      'SL_ORD_DATA.DEL_DATE': '2026-04-09',
      'SL_ORD_DATA.TOT_AMT': '1200',
      'SL_ORD_DATA.ADV_AMT': '105',
      'SL_ORD_DATA.CASH_AMT': '105',
      'SL_ORD_DATA.TAX_PRC': '3',
      'SL_ORD_DATA.TAX_AMT': '0',
      'CO_MAST.CO_NAME': 'Company',
      'CO_MAST.REP_ADD_TYPE': 'L',
      'LOCT_MAST.LC_NAME': 'Branch <name>',
      'LOCT_MAST.LC_CITY': 'Branch city',
      'LOCT_MAST.LC_MOBILE': '12345',
      'LOCT_MAST.LC_PHONE': '67890',
      ...overrides,
    }),
    parents,
    received,
    { opening: '-100.25', closing: '4.75' },
    'CUSTOMER',
  );
  return {
    spec,
    header,
    detailRows: parents,
    ...(contract.child
      ? {
          parentChild: {
            parentSections: contract.parentSections!,
            childSections: contract.childSections!,
            parentFooterSections: contract.parentFooterSections!,
            groups: parents.map((parent, index) => ({
              key: String(index + 1),
              parent,
              children:
                index === 0
                  ? [
                      {
                        'ITEM_MAST_IDTL.IT_NAME': 'Ruby component',
                        'SL_ORD_IDTL.IT_PCS': '1',
                        'SL_ORD_IDTL.IT_GWT': '0.101',
                      },
                      {
                        'ITEM_MAST_IDTL.IT_NAME': 'Diamond component',
                        'SL_ORD_IDTL.IT_PCS': '2',
                        'SL_ORD_IDTL.IT_GWT': '0',
                      },
                    ]
                  : [],
            })),
          },
        }
      : {}),
    subreports: {
      OrdRec: {
        detailRows: received,
        header: {
          ...completeOrderFields(spec.subreports!.OrdRec!, {}),
          'Sum ({SL_PR_DETL.ITM_PCS})': '5',
          'Sum ({SL_PR_DETL.ITM_NWT})': '3.3',
        },
      },
    },
  };
};

describe('recovered order document contract', () => {
  it.each([
    ['OrderVch', 58],
    ['OrderBill', 93],
    ['TourOrdVch', 92],
  ])('preserves %s main report and independent OrdRec', (name, objects) => {
    const spec = loadReportSpec(String(name))!;
    expect(spec.objectCount).toBe(objects);
    expect(spec.areas.some((area) => area.kind === 'PageHeader')).toBe(true);
    expect(spec.subreports?.OrdRec?.areas.some((area) => area.kind === 'Detail')).toBe(true);
    expect(spec.formulas.find((formula) => formula.name === 'CoCity')!.text).toContain(
      '{CO_MAST.CO_PHONE}',
    );
  });

  it.each(['OrderVch', 'OrderBill', 'TourOrdVch'])(
    'renders %s with real main fields, received rows and source formulas',
    (name) => {
      const data = prepare(name);
      const html = renderReportLayout(data.spec, data);
      expect(html).toContain('Customer &lt;one&gt;');
      expect(html).toContain('Branch &lt;name&gt;');
      expect(html).toContain('Branch city   Mo : 12345  Ph : 67890');
      expect(html).toContain('CUSTOMER COPY');
      expect(html).toContain(name === 'OrderVch' ? 'ONE HUNDRED FIVE' : 'ONE THOUSAND TWO HUNDRED');
      expect(html.match(/>Received gold</g)).toHaveLength(1);
      expect(html.match(/>Received silver</g)).toHaveLength(1);
      expect(html).toContain('data-field="Sum ({SL_PR_DETL.ITM_NWT})"');
      expect(html.replace(/<[^>]+>/g, '')).not.toMatch(/\[IT_|ToWords|PageNumber|undefined/);
    },
  );

  it('renders distinct children between their parent and footer without duplicating parent totals', () => {
    const data = prepare();
    const html = renderReportLayout(data.spec, data);
    expect(html.indexOf('TAG-001 - Parent 0')).toBeLessThan(html.indexOf('Ruby component'));
    expect(html.indexOf('Diamond component')).toBeLessThan(
      html.indexOf('Parent 1 Dsgn : DESIGN-1'),
    );
    expect(html.match(/>975\.31</g)).toHaveLength(1);
    expect(data.header['#RTotal0']).toBe('3.3');
    expect(html).not.toContain('data-section="Section17"');
    expect(html).not.toContain('Tax :'); // zero-tax sections are suppressed, including their labels.
    expect(html.match(/data-kind="Detail"/g)).toHaveLength(4); // 2 components + 2 received-metal rows.
  });

  it.each([
    ['OrderBill', 'Parent 0 Dsgn : DESIGN-0', 'TAG-001 - Parent 0'],
    ['TourOrdVch', 'TAG-001 - Parent 0', 'Parent 0 Dsgn : DESIGN-0'],
  ])(
    'prints %s source item-name formula when both tag and design are present',
    (name, expected, absent) => {
      const data = prepare(name);
      expect(data.detailRows[0]?.['SL_ORD_DETL.TAG_NO']).toBe('TAG-001');
      expect(data.detailRows[0]?.['SL_ORD_DETL.DESIGN_NO']).toBe('DESIGN-0');
      expect(data.detailRows[0]?.['@ItemName']).toBe(expected);
      const html = renderReportLayout(data.spec, data);
      expect(html).toContain(`>${expected}</div>`);
      expect(html).not.toContain(`>${absent}</div>`);
      expect(html).toContain('>Parent 1 Dsgn : DESIGN-1</div>');
    },
  );

  it('retains NULL/zero distinction and suppresses walk-in ledger fields exactly where the XML does', () => {
    const data = prepare('OrderBill', 2, { 'SL_ORD_DATA.AC_CODE': '00020' });
    const html = renderReportLayout(data.spec, data);
    expect(html).not.toContain('Ledger Opening Bal');
    expect(html).not.toContain('>-100.25<');
    expect(html).toMatch(/data-field="\{SL_ORD_DETL.NET_AMT\}"[^>]*>0</);
    expect(completeOrderFields(data.spec, {})['SL_ORD_DETL.NET_AMT']).toBe('');
  });

  it('paginates long documents with sequential page numbers and each line/component appearing once', () => {
    const data = prepare('TourOrdVch', 60);
    const html = renderReportLayout(data.spec, data);
    const pages = [...html.matchAll(/<article class="order-page" data-page="(\d+)"/g)].map(
      (match) => Number(match[1]),
    );
    expect(pages.length).toBeGreaterThan(2);
    expect(pages).toEqual(Array.from({ length: pages.length }, (_, index) => index + 1));
    for (let index = 0; index < 60; index++) {
      expect(
        html.match(
          new RegExp(
            index ? `>Parent ${index} Dsgn : DESIGN-${index}<` : '>TAG-001 - Parent 0<',
            'g',
          ),
        ),
      ).toHaveLength(1);
    }
    expect(html.match(/>Ruby component</g)).toHaveLength(1);
    expect(html).not.toContain('__ORDER_PAGE_NUMBER__');
  });

  it('fails explicitly if a recovered template changes or a required dataset/field is absent', () => {
    const data = prepare();
    const changed = structuredClone(data.spec);
    changed.formulas[0]!.text += ' + 123';
    expect(() => resolveReportBinding(changed)).toThrow('altered-order-report-spec');
    expect(() => renderReportLayout(data.spec, { header: data.header })).toThrow(
      'missing-order-render-datasets',
    );
    delete data.header['@CoCity'];
    expect(() => renderReportLayout(data.spec, data)).toThrow('missing-order-field:{@CoCity}');
  });

  it('uses decimal sums and whole-number words rather than floating-point or rupees/paise formatting', () => {
    expect(sumReportValues([{ x: '0.1' }, { x: '0.2' }, { x: '' }], 'x')).toBe('0.3');
    expect(orderWholeAmountWords('125.5')).toBe('ONE HUNDRED TWENTY-SIX');
    expect(orderWholeAmountWords('-1.5')).toBe('MINUS TWO');
    expect(orderWholeAmountWords('0')).toBe('ZERO');
    expect(suppressOrderField("{x} = ''", { x: '' })).toBe(true);
    expect(suppressOrderField('{x} = 0', { x: '0.00' })).toBe(true);
    expect(() => suppressOrderField('anything unknown', {})).toThrow(
      'Unsupported order suppression',
    );
  });

  it('keeps an explicitly unbound preview available and rejects inherited copy names', () => {
    const spec = loadReportSpec('OrderVch')!;
    expect(renderReportLayout(spec, {})).toContain('data placeholder');
    expect(() =>
      orderFormulaValues(spec, {}, [], [], { opening: '0', closing: '0' }, 'toString' as never),
    ).toThrow('invalid-order-copy');
    const zero = orderFormulaValues(spec, completeOrderFields(spec, {}), [], [], {
      opening: '0',
      closing: '0',
    });
    expect(zero['@OpAmtCrDr']).toBe('Dr');
    expect(zero['@ClAmtCrDr']).toBe('Dr'); // XML is `if amount > 0 then Cr else Dr`, including zero.
  });
});
