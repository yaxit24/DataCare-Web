import { describe, expect, it } from 'vitest';
import {
  blank,
  blankOrderHeader,
  hydrateTourOrder,
  tourOrderPayload,
  tourOrderQuery,
  commitTourOrderLabour,
  setTourOrderCell,
  tourOrderLineNet,
} from '../lib/tourOrderForm';

describe('Tour Order editor values and scope', () => {
  const stored = {
    voucherNo: '00017',
    version: 'snapshot-1',
    acCode: '000015',
    acName: 'Tour party',
    vchDate: '2024-07-10',
    taxRatePct: 3,
    advanceAmount: 12.34,
    cashAc: 'CASH2',
    billNo: 'TOUR/17',
    vchDesc: 'ring details',
    address3: 'Third road',
    mobile: '09876543210',
    deliveryDate: '2024-07-20',
    functionDate: '2024-07-22',
    oldGoldFine: 1.001,
    schemeAmount: 0,
    chequeNo: '000082',
    lines: [
      {
        itCode: '00002',
        tagNo: 'IMPORTED-TAG-6',
        designNo: '000007',
        netWt: 3.123,
        touch: 91.6,
        rate: 7000,
        making: 37.320845341018256,
        ghtWt: 0.1,
        oldSrNo: 12,
        vchSrno: 6,
        designImageId: 'ring-profile',
        huid: 'AB0123',
        hallmarkId4Wt: 1.003,
        orderDeliveryDate: '2024-07-18',
        components: [
          {
            itCode: 'DM',
            isrNo: 10,
            dmCode: '00011',
            pcs: 0,
            grossWt: 0.123,
            lbrRate: 0,
            lbrAmount: 0,
            karigarNetAmount: 0,
          },
          {
            itCode: 'DM',
            dmCode: '00012',
            pcs: 2,
            grossWt: 0.234,
            dmName: 'Pear',
            lbrRate: 10,
            lbrAmount: 20,
          },
        ],
      },
    ],
  };

  it('preserves textual identifiers, full precision, explicit zeroes, dates, images, advance and all children', () => {
    const editor = hydrateTourOrder(stored);
    const payload = tourOrderPayload(editor.f, editor.header, editor.rows, stored.version);
    expect(payload).toMatchObject({
      acCode: '000015',
      advanceAmount: 12.34,
      cashAc: 'CASH2',
      expectedVersion: stored.version,
      billNo: 'TOUR/17',
      vchDesc: 'ring details',
      address3: 'Third road',
      deliveryDate: '2024-07-20',
      oldGoldFine: 1.001,
      schemeAmount: 0,
      chequeNo: '000082',
      lines: [
        {
          itCode: '00002',
          tagNo: 'IMPORTED-TAG-6',
          designNo: '000007',
          making: 37.320845341018256,
          oldSrNo: 12,
          vchSrno: 6,
          designImageId: 'ring-profile',
          huid: 'AB0123',
          hallmarkId4Wt: 1.003,
          components: [
            {
              isrNo: 10,
              dmCode: '00011',
              pcs: 0,
              grossWt: 0.123,
              lbrRate: 0,
              lbrAmount: 0,
              karigarNetAmount: 0,
            },
            { dmCode: '00012', pcs: 2, lbrRate: 10, lbrAmount: 20 },
          ],
        },
      ],
    });
    expect(editor.rows[0].components[0].pcs).toBe('0');
    expect(editor.rows[0].components).toHaveLength(2);
  });

  it('retains an intentional empty component set and does not recreate the old synthetic stone', () => {
    const editor = hydrateTourOrder(stored);
    editor.rows[0].components = [];
    expect(
      (tourOrderPayload(editor.f, editor.header, editor.rows).lines as any[])[0].components,
    ).toEqual([]);
  });

  it('refuses invalid monetary, line, and child values instead of dropping them', () => {
    const editor = hydrateTourOrder(stored);
    expect(() =>
      tourOrderPayload({ ...editor.f, advanceAmount: 'NaN' }, editor.header, editor.rows),
    ).toThrow('Advance must be a valid number');
    expect(() =>
      tourOrderPayload(editor.f, editor.header, [{ ...editor.rows[0], netWt: 'bad' }]),
    ).toThrow('netWt must be a valid number');
    editor.rows[0].components[1].lbrAmount = 'Infinity';
    expect(() => tourOrderPayload(editor.f, editor.header, editor.rows)).toThrow(
      'lbrAmount must be a valid number',
    );
  });

  it('requires parent and component item identities and drops a completely blank trailing parent', () => {
    const editor = hydrateTourOrder(stored);
    expect(
      tourOrderPayload(editor.f, editor.header, [...editor.rows, blank()]).lines as any[],
    ).toHaveLength(1);
    editor.rows[0].components[1].itCode = '';
    expect(() => tourOrderPayload(editor.f, editor.header, editor.rows)).toThrow(
      'component 2: item is required',
    );
    expect(() => tourOrderPayload(blankOrderHeader(), {}, [blank()])).toThrow(
      'Customer is required',
    );
  });

  it('encodes the actual company/location/year/book without a default-book substitution', () => {
    const query = new URLSearchParams(
      tourOrderQuery({ coCode: '02', lcCode: '03', coYear: '2024-2025' }, 'Z09'),
    );
    expect(Object.fromEntries(query)).toEqual({
      coCode: '02',
      lcCode: '03',
      coYear: '2024-2025',
      coBook: 'Z09',
    });
  });
});

describe('Tour Order labour committed edits and previews', () => {
  const policy = { includesGhat: true, rateDecimals: 2 };
  const original = {
    ...blank(),
    itCode: 'GOLD',
    labourType: 'P',
    pcs: '3',
    grossWt: '12',
    netWt: '10',
    ghtWt: '2',
    rate: '7000',
    touch: '100',
    labourRate: '10.25',
    labourPct: '0',
    labourAmount: '77.37',
    itemAmount: '84000',
    lineNetAmount: '84077.37',
    lineTotalAmount: '84077.37',
  };
  it('uses the same whole-rupee source rate/percentage and manual-amount transitions', () => {
    const rate = commitTourOrderLabour(
      original,
      { ...original, labourRate: '12.5' },
      'labourRate',
      policy,
    );
    expect(rate).toMatchObject({ labourAction: 'rate', labourAmount: '38' });
    expect(tourOrderLineNet(rate, policy)).toBe(84038);
    const pct = commitTourOrderLabour(rate, { ...rate, labourPct: '1.25' }, 'labourPct', policy);
    expect(pct).toMatchObject({
      labourAction: 'percentage',
      labourRate: '87.5',
      labourAmount: '262',
    });
    const manual = commitTourOrderLabour(
      pct,
      { ...pct, labourAmount: '150.75' },
      'labourAmount',
      policy,
    );
    expect(manual).toMatchObject({
      labourAction: 'amount',
      labourRate: '50.25',
      labourAmount: '150.75',
    });
    expect(tourOrderLineNet(manual, policy)).toBe(84150.75);
  });
  it('does not reprice unchanged/manual values or basis-only edits', () => {
    expect(commitTourOrderLabour(original, original, 'labourRate', policy)).toEqual(original);
    expect(
      commitTourOrderLabour(original, { ...original, labourType: 'G' }, 'labourType', policy)
        .labourAmount,
    ).toBe('77.37');
    expect(tourOrderLineNet(setTourOrderCell(original, 'remark', 'Different child'), policy)).toBe(
      84077.37,
    );
  });
  it('clears and rederives metal preview when its input changes while preserving manual labour', () => {
    const changed = setTourOrderCell(original, 'rate', '1000');
    expect(changed.labourAmount).toBe('77.37');
    expect(tourOrderLineNet(changed, policy)).toBe(12077.37);
  });
});
