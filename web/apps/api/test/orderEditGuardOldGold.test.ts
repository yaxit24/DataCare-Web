import { describe, expect, it } from 'vitest';
import { unsupportedOrderEdit } from '../src/modules/sales/orderLifecyclePolicy.js';

/**
 * The saved OLD_GL is the old gold fine plus RCUT_FINE (TR_SALE_ORD.cs:9143). An edit can only rebuild the
 * rate-cut share, so any other OLD_GL without old-metal grid rows blocks the edit.
 */
describe('Sales Order edit guard and OLD_GL', () => {
  const header = (OLD_GL: number, RCUT_FINE: number) => ({
    SL_ORD_DATA: [{ OLD_GL, RCUT_FINE, OLD_GL_AMT: 0, OLD_SL: 0, OLD_SL_AMT: 0 }],
  });

  it('allows an edit when OLD_GL is only the rate-cut fine', () => {
    expect(unsupportedOrderEdit(header(5, 5), true)).toBeUndefined();
    expect(unsupportedOrderEdit(header(0, 0), true)).toBeUndefined();
  });

  it('blocks typed old gold beyond the rate-cut fine', () => {
    expect(unsupportedOrderEdit(header(8, 5), true)).toBeDefined();
  });

  it('blocks a row saved before OLD_GL included RCUT_FINE, so its typed old gold is not lost', () => {
    // Old writer: typed old gold 3 g saved alone beside RCUT_FINE 5 g.
    expect(unsupportedOrderEdit(header(3, 5), true)).toBeDefined();
  });
});
