import { describe, it, expect } from 'vitest';
import {
  loadReportSpec,
  renderReportLayout,
  listReportSpecs,
} from '../src/modules/reports/reportEngine.js';

describe('report layout engine (Crystal geometry → pixel-exact HTML)', () => {
  it('lists the extracted report specs', () => {
    expect(listReportSpecs().length).toBeGreaterThan(200);
  });
  it('renders SalesBillA4Gst with bands + absolutely-positioned objects + labels', () => {
    const spec = loadReportSpec('SalesBillA4Gst');
    expect(spec).toBeTruthy();
    const html = renderReportLayout(spec!, { company: 'DHAKAN JEWELLERS' });
    expect((html.match(/position:absolute/g) || []).length).toBeGreaterThan(100); // ~163 objects
    expect(html).toContain('data-kind="Detail"'); // Detail band present
    expect(html).toMatch(/\[IT_(AMT|PCS|GWT|RATE)\]/); // line-item field placeholders
    expect(html).toContain('class="ro tx"'); // TextObject labels
    expect(html).toMatch(/left:\d+px/); // twips→px coordinates
  });
  it('binds Detail rows when data supplied (repeats per row)', () => {
    const spec = loadReportSpec('SalesBillA4Gst')!;
    const html = renderReportLayout(spec, {
      detailRows: [{ 'SL_IDTL.IT_PCS': '2' }, { 'SL_IDTL.IT_PCS': '5' }],
    });
    expect(html).toContain('bound to real data');
  });
  it('unknown report → null', () => {
    expect(loadReportSpec('NoSuchReport')).toBeNull();
  });
});
