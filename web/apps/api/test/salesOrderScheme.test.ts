import { describe, expect, it } from 'vitest';
import { orderSchemeOf, withSchemeRojmel } from '../src/modules/sales/salesOrderScheme.js';
import { orderAdvanceTotal, orderTenderOf } from '../src/modules/sales/salesOrderTender.js';

/** G206 (scheme): the advance sum (TR_SALE_ORD.cs:11368) and Order_Rojmel type 05 (Ac_Rojmel.cs:19). */
describe('Sales Order scheme tender', () => {
  const advanceRow = {
    LEDR_KEY: '01012024-2025S9600001' + '01',
    AC_CODE: 'PARTY',
    LD_CODE: 'CASH',
    CR_AMT: 4000,
    DR_AMT: 0,
    AC_NAME: 'Saved customer',
    IT_TYPE: 'A',
  };

  it('adds the typed scheme to the advance on a Sales Order only', () => {
    const tender = orderTenderOf({ advanceAmount: 3000, schemeAmount: '1000.255' });
    expect([tender.scheme, orderAdvanceTotal(tender)]).toEqual([1000.26, 4000.26]);
    const tour = orderTenderOf({ advanceAmount: 3000, schemeAmount: 1000 }, false);
    expect([tour.scheme, orderAdvanceTotal(tour)]).toEqual([0, 3000]);
  });

  it('refuses a negative or non-numeric scheme', () => {
    expect(() => orderSchemeOf(-1)).toThrow('schemeAmount must be a non-negative number');
    expect(() => orderSchemeOf('abc')).toThrow('schemeAmount must be a non-negative number');
    expect([orderSchemeOf(undefined), orderSchemeOf('')]).toEqual([0, 0]);
  });

  it('writes type 05 beside the advance row, debiting the scheme account against the party', () => {
    const rows = withSchemeRojmel([advanceRow], 'PARTY', 'Saved customer', 1000, 'SCHBONUS');
    expect(rows).toHaveLength(2);
    expect(rows[1]).toEqual({
      LEDR_KEY: '01012024-2025S9600001' + '05',
      AC_CODE: 'SCHBONUS',
      LD_CODE: 'PARTY',
      CR_AMT: 0,
      DR_AMT: 1000,
      AC_NAME: 'MADJ - Saved customer',
      IT_TYPE: 'A',
    });
    expect(rows[1]!.LEDR_KEY).toHaveLength(23);
  });

  it('writes nothing without a scheme (guard SCHM_AMT <> 0)', () => {
    expect(withSchemeRojmel([advanceRow], 'PARTY', 'Saved customer', 0, '')).toEqual([advanceRow]);
  });
});
