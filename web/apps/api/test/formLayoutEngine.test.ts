import { describe, it, expect } from 'vitest';
import {
  loadFormLayout,
  renderFormLayout,
  listFormLayouts,
} from '../src/modules/forms/formLayoutEngine.js';

describe('form layout engine (desktop WinForms → pixel-positioned HTML)', () => {
  it('lists the extracted form layouts', () => {
    expect(listFormLayouts().length).toBeGreaterThan(150);
  });
  it('renders TR_SALE pixel-positioned with its 8 grids (incl. old-gold + order-adjust)', () => {
    const spec = loadFormLayout('TR_SALE');
    expect(spec).toBeTruthy();
    const html = renderFormLayout(spec);
    expect((html.match(/position:absolute/g) || []).length).toBeGreaterThan(120); // ~141 controls
    expect(html).toContain('MSG_OLD'); // old-gold exchange grid
    expect(html).toContain('MSG_ORD'); // order-advance adjust grid
    expect(html).toContain('class="c grd"'); // grids rendered
    expect(html).toMatch(/left:\d+px/); // pixel coordinates
    expect(html).toContain('TR_SALE');
  });
  it('unknown form → null', () => {
    expect(loadFormLayout('NoSuchForm')).toBeNull();
  });
});
