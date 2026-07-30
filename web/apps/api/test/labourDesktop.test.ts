import { describe, expect, it } from 'vitest';
import {
  desktopLabourAmount,
  desktopLabourRateFromPercent,
  DESKTOP_LABOUR_TYPES,
  type DesktopLabourType,
} from '../src/modules/shared/labourDesktop.js';

/**
 * Golden vectors for the desktop labour model.
 *
 * WHY THIS FILE EXISTS
 * --------------------
 * The web modelled labour as `per_gram | per_piece | percentage | fixed`. The desktop models something
 * different: `LBR_TYPE` selects the **basis** the rate is multiplied by, and a percentage is a separate input
 * that DERIVES the rate. Confirmed from `CO_SET.LBR_TYPE`'s own option list and from the write-set bindings of
 * the grid columns:
 *
 *   G  "Gorss Wise"  ITM_GWT (col 12) x LBR_RATE                      TR_SALE.cs:11104
 *   N  "Net Wise"    ITM_NWT (col 14) x LBR_RATE                      TR_SALE.cs:11119
 *   K  "Kg Wise"     (ITM_NWT + ITM_GHT_WT) x LBR_RATE / 1000         TR_SALE.cs:11108
 *   P  "Pcs Wise"    ITM_PCS (col 11) x LBR_RATE                      TR_SALE.cs:11127
 *
 *   and when MsLbrWithGht <> 'N' the weight bases include ITM_GHT_WT   TR_SALE.cs:11112,11100,11123
 *
 *   LBR_RATE derived from a percentage:
 *     LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof)       TR_SALE.cs:11021
 *
 * Grid columns resolved from the write set, not assumed:
 *   11=ITM_PCS  12=ITM_GWT  13=ITM_OTH_WT  14=ITM_NWT  17=ITM_GHT_WT  22=ITM_RATE
 *   24=LBR_PRC  25=LBR_TYPE  26=LBR_RATE   27=LBR_AMT
 *
 * The mismatch that prompted this: the web mapped `per_gram` to `G`, but `G` is GROSS weight — per-gram on net
 * weight is `N`. It mapped `fixed` to `N`, which the desktop reads as net-weight-times-rate. It emitted `'%'`,
 * which is not a value `LBR_TYPE` ever holds. And `K` had no representation at all.
 *
 * `LBR_TYPE` is persisted and read back when a voucher is reopened, so a wrong code does not merely mislabel —
 * it changes the amount the desktop recomputes.
 */
describe('GV-LBR: desktop labour type is a weight basis, not a pricing mode', () => {
  it('GV-LBR-001 exposes exactly the four types CO_SET.LBR_TYPE offers', () => {
    // 'Gorss Wise' is the desktop's own misspelling and is preserved elsewhere; the codes are what matter.
    expect([...DESKTOP_LABOUR_TYPES]).toEqual(['G', 'N', 'K', 'P']);
  });

  it('GV-LBR-002 G multiplies GROSS weight by the rate (TR_SALE.cs:11104)', () => {
    // Gross 10.500, net 10.000 — a real line where the two differ, so a G/N confusion is visible.
    expect(
      desktopLabourAmount('G', { grossWt: 10.5, netWt: 10, pcs: 1, ghatWt: 0, rate: 100 }),
    ).toBe(1050);
  });

  it('GV-LBR-003 N multiplies NET weight by the rate (TR_SALE.cs:11119)', () => {
    expect(
      desktopLabourAmount('N', { grossWt: 10.5, netWt: 10, pcs: 1, ghatWt: 0, rate: 100 }),
    ).toBe(1000);
  });

  it('GV-LBR-004 G and N differ whenever gross and net differ', () => {
    // The web mapped per_gram to G and fixed to N. If the two codes were interchangeable the mix-up would be
    // harmless; this vector exists to show it is not.
    const line = { grossWt: 10.5, netWt: 10, pcs: 1, ghatWt: 0, rate: 100 };
    expect(desktopLabourAmount('G', line)).not.toBe(desktopLabourAmount('N', line));
  });

  it('GV-LBR-005 P multiplies PIECES by the rate (TR_SALE.cs:11127)', () => {
    expect(
      desktopLabourAmount('P', { grossWt: 10.5, netWt: 10, pcs: 3, ghatWt: 0, rate: 100 }),
    ).toBe(300);
  });

  it('GV-LBR-006 K divides the rate by 1000, because it is quoted per kilogram (TR_SALE.cs:11108)', () => {
    // 10.000 g at 100000 per kg = 1000. Dropping the /1000 inflates the charge a thousandfold, which is the
    // single most damaging arithmetic error available on this form.
    expect(
      desktopLabourAmount('K', { grossWt: 10.5, netWt: 10, pcs: 1, ghatWt: 0, rate: 100000 }),
    ).toBe(1000);
  });

  it('GV-LBR-007 K includes ghat weight in its basis', () => {
    // (10.000 + 2.000) g at 100000 per kg = 1200.
    expect(
      desktopLabourAmount('K', { grossWt: 10.5, netWt: 10, pcs: 1, ghatWt: 2, rate: 100000 }),
    ).toBe(1200);
  });

  it('GV-LBR-008 withGhat adds ghat weight to the net basis (TR_SALE.cs:11112,11100)', () => {
    // MsLbrWithGht <> 'N' -> (ITM_NWT + ITM_GHT_WT) x LBR_RATE.
    const line = { grossWt: 10.5, netWt: 10, pcs: 1, ghatWt: 2, rate: 100 };
    expect(desktopLabourAmount('N', line, { withGhat: false })).toBe(1000);
    expect(desktopLabourAmount('N', line, { withGhat: true })).toBe(1200);
  });

  it('GV-LBR-009 rounds the amount half-to-even, as .NET Math.Round does', () => {
    // Math.Round(x, digits) with no MidpointRounding argument is banker's rounding.
    // 0.125 x 100 = 12.5 -> 12 at zero decimals, not 13.
    expect(
      desktopLabourAmount(
        'N',
        { grossWt: 0, netWt: 0.125, pcs: 0, ghatWt: 0, rate: 100 },
        { decimals: 0 },
      ),
    ).toBe(12);
    // And 0.175 x 100 = 17.5 -> 18, the other side of the tie.
    expect(
      desktopLabourAmount(
        'N',
        { grossWt: 0, netWt: 0.175, pcs: 0, ghatWt: 0, rate: 100 },
        { decimals: 0 },
      ),
    ).toBe(18);
  });

  it('GV-LBR-010 a zero rate yields zero, not a fallback', () => {
    // The desktop clears col 26/27 when the rate is blank (TR_SALE.cs:11043,11047); it does not substitute.
    expect(desktopLabourAmount('N', { grossWt: 10, netWt: 10, pcs: 1, ghatWt: 0, rate: 0 })).toBe(
      0,
    );
  });
});

describe('GV-LBRPRC: labour rate derived from a percentage', () => {
  it('GV-LBRPRC-001 derives the RATE from the item rate (TR_SALE.cs:11021)', () => {
    // LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof).
    // 6200 x 12 / 100 = 744.
    expect(desktopLabourRateFromPercent(6200, 12, 2)).toBe(744);
  });

  it('GV-LBRPRC-002 rounds to the company LBR_ROF decimal count, not a constant', () => {
    // 6250 x 12.5 / 100 = 781.25 exactly, which sits on a midpoint at 1 decimal - so this vector doubles
    // as a banker's-rounding check on the derived rate.
    expect(desktopLabourRateFromPercent(6250, 12.5, 2)).toBe(781.25);
    // Neighbours are 781.2 and 781.3, and 2 is the even one. Half-UP would answer 781.3, so this is exactly
    // where .NET Math.Round parts company with the intuitive result.
    expect(desktopLabourRateFromPercent(6250, 12.5, 1)).toBe(781.2);
    // At 0 decimals 781.25 is not a midpoint, so it resolves to 781.
    expect(desktopLabourRateFromPercent(6250, 12.5, 0)).toBe(781);
  });

  it('GV-LBRPRC-003 a zero percentage leaves the rate at zero', () => {
    // TR_SALE.cs:11032 returns early when LBR_PRC is 0, leaving the operator's own rate untouched.
    expect(desktopLabourRateFromPercent(6200, 0, 2)).toBe(0);
  });

  it('GV-LBRPRC-004 feeds the derived rate into the amount, so a percentage line is basis-driven', () => {
    // This is the chain the web was missing entirely: percentage -> rate -> amount.
    // 6200 x 12 / 100 = 744, then net 10.000 x 744 = 7440.
    const rate = desktopLabourRateFromPercent(6200, 12, 2);
    expect(desktopLabourAmount('N', { grossWt: 10, netWt: 10, pcs: 1, ghatWt: 0, rate })).toBe(
      7440,
    );
  });

  it('GV-LBRPRC-005 is NOT the same as applying the percentage to the metal amount', () => {
    // The web computed percentage labour as metalAmount x pct / 100. For a 91.6-touch line that is
    // (10 x 0.916 x 6200) x 0.12 = 6815.04, against the desktop's 7440 — a 624.96 difference on one line.
    const metalAmount = 10 * 0.916 * 6200;
    const webStyle = Math.round(metalAmount * 12) / 100;
    const rate = desktopLabourRateFromPercent(6200, 12, 2);
    const desktop = desktopLabourAmount('N', { grossWt: 10, netWt: 10, pcs: 1, ghatWt: 0, rate });
    expect(desktop).toBe(7440);
    expect(Math.abs(desktop - webStyle)).toBeGreaterThan(600);
  });
});

describe('GV-LBR type codes', () => {
  it('GV-LBR-011 rejects a code the desktop never writes', () => {
    // '%' was emitted by the web. LBR_TYPE is varchar(1) and CO_SET.LBR_TYPE offers only G/N/K/P, so '%'
    // is a value the desktop cannot interpret when it reopens the voucher.
    expect(DESKTOP_LABOUR_TYPES).not.toContain('%' as DesktopLabourType);
    expect(() =>
      desktopLabourAmount('%' as DesktopLabourType, {
        grossWt: 1,
        netWt: 1,
        pcs: 1,
        ghatWt: 0,
        rate: 1,
      }),
    ).toThrow(/unknown labour type/i);
  });
});
