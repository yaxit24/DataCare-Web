import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import { loadReportSpec, renderReportLayout } from '../src/modules/reports/reportEngine.js';
import { resolveReportBinding } from '../src/modules/reports/reportBindingContract.js';
import { completeOrderFields, orderFormulaValues, orderParentFormulaValues } from '../src/modules/reports/orderReportValues.js';
import type { OrderReportImages } from '../src/modules/reports/orderReportImages.js';

const portrait = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
const landscape = readFileSync(new URL('./fixtures/order-tag-landscape.jpg', import.meta.url));

const prepare = (name: 'OrdVchImg' | 'TourOrdImg' = 'OrdVchImg', count = 2) => {
  const spec = loadReportSpec(name)!;
  const contract = resolveReportBinding(spec);
  const parents = Array.from({ length: count }, (_, index) => orderParentFormulaValues(spec, {
    'SL_ORD_DETL.SR_NO': String(index + 1), 'SL_ORD_DETL.TAG_NO': `TAG-${index + 1}`,
    'SL_ORD_DETL.DESIGN_NO': `DESIGN-${index + 1}`, 'ITEM_MAST.IT_NAME': `Parent ${index + 1}`,
    'SL_ORD_DETL.ITM_GWT': String(index + 1), 'SL_ORD_DETL.NET_AMT': String((index + 1) * 100),
    'SL_ORD_DETL.ITM_REMARK': index === 0 ? 'Keep the clasp wide' : '',
  }));
  const total = count * (count + 1) / 2 * 100;
  const header = orderFormulaValues(spec, completeOrderFields(spec, {
    'SL_ORD_DATA.CO_YEAR': '2026-2027', 'SL_ORD_DATA.CO_BOOK': 'Z09', 'SL_ORD_DATA.VCH_NO': '00001',
    'SL_ORD_DATA.AC_NAME': 'Image customer', 'SL_ORD_DATA.AC_CODE': 'PARTY',
    'SL_ORD_DATA.VCH_DATE': '2026-04-03', 'SL_ORD_DATA.DEL_DATE': '2026-04-09',
    'SL_ORD_DATA.NET_AMT': String(total), 'SL_ORD_DATA.TOT_AMT': String(total),
    'SL_ORD_DATA.TAX_AMT': '0', 'SL_ORD_DATA.ADV_AMT': '0', 'CO_MAST.CO_NAME': 'Image company',
    'BOOK_DATA.BOOK_NAME': name === 'TourOrdImg' ? 'Configured Tour Order' : 'Configured Sales Order',
  }), parents, [], { opening: '0', closing: '0' }, 'O');
  const orderImages: OrderReportImages = Object.fromEntries(parents.map((parent, index) => [parent['SL_ORD_DETL.SR_NO'],
    index === 1 ? { state: 'present', bytes: landscape, mimeType: 'image/jpeg', source: 'TAG' }
      : { state: 'present', bytes: portrait, mimeType: 'image/png', source: 'DESIGN' }]));
  return { spec, header, detailRows: parents, orderImages,
    parentChild: { parentSections: contract.parentSections!, childSections: contract.childSections!,
      parentFooterSections: contract.parentFooterSections!, groups: parents.map((parent, index) => ({
        key: String(index + 1), parent, children: index === 0 ? [
          { 'ITEM_MAST_IDTL.IT_NAME': 'Ruby component', 'SL_ORD_IDTL.IT_PCS': '1', 'SL_ORD_IDTL.IT_GWT': '0.101' },
          { 'ITEM_MAST_IDTL.IT_NAME': 'Diamond component', 'SL_ORD_IDTL.IT_PCS': '2', 'SL_ORD_IDTL.IT_GWT': '0.202' },
        ] : [],
      })) },
    subreports: { OrdRec: { detailRows: [], header: completeOrderFields(spec.subreports!.OrdRec!, {}) } },
  };
};

describe('explicit image order report contract', () => {
  it.each(['OrdVchImg', 'TourOrdImg'] as const)('recovers %s main image band and independent OrdRec', (name) => {
    const spec = loadReportSpec(name)!;
    expect([spec.sectionCount, spec.objectCount]).toEqual([16, 93]);
    expect(spec.imageBindingEvidence).toMatchObject({ section: 'Section17', object: 'Field22', field: 'IMAGE_DATA.TAG_IMAGE' });
    const section = spec.areas.flatMap((area) => area.sections).find((s) => s.name === 'Section17')!;
    expect(section.suppressed).toBe(false);
    expect(section.height).toBe(1680);
    expect(section.objects).toHaveLength(1);
    expect(section.objects[0]).toMatchObject({ type: 'BlobFieldObject', dataSource: '{IMAGE_DATA.TAG_IMAGE}', width: 2175, height: 1680 });
    expect(spec.subreports?.OrdRec).toBeDefined();
  });

  it.each(['OrdVchImg', 'TourOrdImg'] as const)('renders %s one correct image per parent without child fanout', (name) => {
    const data = prepare(name);
    const html = renderReportLayout(data.spec, data);
    expect(html.match(/<img /g)).toHaveLength(2);
    expect(html.match(new RegExp(portrait.toString('base64').replace(/[.*+?^${}()|[\]\\]/g, '\\$&'), 'g'))).toHaveLength(1);
    expect(html).toContain(`src="data:image/jpeg;base64,${landscape.toString('base64')}"`);
    expect(html).toContain('>Parent 1 Dsgn : DESIGN-1</div>');
    expect(html).not.toContain('TAG-1 - Parent 1'); // Both image variants use the design-only source formula.
    expect(html.match(/data-field="\{SL_ORD_DETL.NET_AMT\}"[^>]*>100<\/div>/g)).toHaveLength(1);
    expect(html.match(/data-field="\{SL_ORD_DETL.NET_AMT\}"[^>]*>200<\/div>/g)).toHaveLength(1);
    expect(html.indexOf('Diamond component')).toBeLessThan(html.indexOf('class="order-object order-image"'));
    expect(data.header['#RTotal0']).toBe('3');
  });

  it('keeps an ordinary absent image as a blank image band and retains its parent', () => {
    const data = prepare(); data.orderImages['2'] = { state: 'absent' };
    const html = renderReportLayout(data.spec, data);
    expect(html.match(/<img /g)).toHaveLength(1);
    expect(html).toContain('class="order-object order-image-absent" data-parent="2"');
    expect(html).toContain('>Parent 2 Dsgn : DESIGN-2</div>');
    expect(html.match(/data-section="Section17"[^>]*height:112px/g)).toHaveLength(2);
  });

  it('refuses missing image state, an orphan image, and malformed payloads instead of silently printing wrong output', () => {
    const data = prepare();
    expect(() => renderReportLayout(data.spec, { ...data, orderImages: undefined })).toThrow('missing-order-render-images');
    delete data.orderImages['2'];
    expect(() => renderReportLayout(data.spec, data)).toThrow('missing-order-parent-image-state:2');
    data.orderImages['2'] = { state: 'absent' }; data.orderImages['9'] = { state: 'absent' };
    expect(() => renderReportLayout(data.spec, data)).toThrow('orphan-order-render-image');
    delete data.orderImages['9'];
    data.orderImages['1'] = { state: 'present', bytes: Buffer.from('<html>invalid</html>'), mimeType: 'image/png', source: 'DESIGN' };
    expect(() => renderReportLayout(data.spec, data)).toThrow('invalid-order-render-image');
    data.orderImages['1'] = { state: 'present', bytes: portrait, mimeType: 'image/jpeg', source: 'DESIGN' };
    expect(() => renderReportLayout(data.spec, data)).toThrow('invalid-order-render-image');
  });

  it('keeps each image with its parent and components across a long document', () => {
    const data = prepare('TourOrdImg', 18);
    const html = renderReportLayout(data.spec, data);
    const pages = [...html.matchAll(/<article class="order-page"[\s\S]*?<\/article>/g)].map((match) => match[0]);
    expect(pages.length).toBeGreaterThan(3);
    expect(html.match(/<img /g)).toHaveLength(18);
    for (let key = 1; key <= 18; key++) {
      const owners = pages.filter((page) => page.includes(`>Parent ${key} Dsgn : DESIGN-${key}</div>`));
      expect(owners).toHaveLength(1);
      expect(owners[0]).toContain(`data-parent="${key}" alt="Parent ${key} Dsgn : DESIGN-${key}"`);
    }
    const oversized = prepare();
    oversized.parentChild.groups[0]!.children = Array.from({ length: 500 }, () => oversized.parentChild.groups[0]!.children[0]!);
    expect(() => renderReportLayout(oversized.spec, oversized)).toThrow('order-band-exceeds-page-capacity');
  });
});
