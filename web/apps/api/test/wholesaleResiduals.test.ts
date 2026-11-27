import { describe, expect, it } from 'vitest';
import { buildWholesaleRojmel } from '../src/modules/shared/rojmelWholesale.js';
import { buildRateCutLedger } from '../src/modules/sales/rateCut.js';
import { planWholesaleDetails, kasarFine } from '../src/modules/sales/wholesaleDetailRows.js';

/** Ac_Rojmel.cs:221-310 and Ac_Ledr.cs:685-705, evaluated by hand. */
const ctx = {
  scope: { coCode: '01', lcCode: '01', coYear: '2026-2027' },
  key: { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2026-2027', CO_BOOK: 'WHS', VCH_NO: '00007' },
  coBook: 'WHS',
  vchNo: '00007',
  vchDate: '2026-06-15',
  vchType: 'WSALE',
  bookName: 'WH SALES',
  partyName: 'Cust',
  partyCode: 'P1',
};
const base = {
  slots: { 1: 'S1', 2: 'S2', 4: 'S4', 5: 'S5', 6: 'S6', 7: 'S7', 8: 'S8', 12: 'S12' } as Record<
    number,
    string
  >,
  cardAc: 'CRD',
  saleChequeAmount: 0,
  saleCardAmount: 0,
  saleKasarAmount: 0,
  purchaseCardAmount: 0,
  purchaseLabourAmount: 0,
  headerName: 'Cust',
  masterName: 'Customer Master',
  vchDesc: 'desc',
  bankAc: 'BNK',
  fineRate: 6500,
  drFine: 0,
  crFine: 0,
  purchaseBillOs: 0,
  saleBillOs: 0,
  purchaseAmount: 0,
  saleAmount: 0,
  ksrFineDr: 0,
  ksrFineCr: 0,
  purchaseChequeAmount: 0,
  purchaseKasarAmount: 0,
  labourAmount: 0,
  issued: [],
  received: [],
};

describe('buildWholesaleRojmel (Wh_Sales_Rojmel)', () => {
  it('kasar rows 07/08: key, name, sign and ITM_FINE with every money column 0', () => {
    const rows = buildWholesaleRojmel(ctx as any, { ...base, ksrFineDr: 0.5, ksrFineCr: 0.25 });
    expect(
      rows.map((r) => [
        r.LEDR_KEY.slice(-2),
        r.AC_NAME,
        r.SIGN,
        r.ITM_FINE,
        r.AC_CODE,
        r.LD_CODE,
        r.DR_AMT,
        r.CR_AMT,
        r.IT_DESC,
      ]),
    ).toEqual([
      ['07', 'KSR - Customer Master', '-', 0.5, 'P1', 'S12', 0, 0, 'desc'],
      ['08', 'KSR - Customer Master', '+', 0.25, 'P1', 'S12', 0, 0, 'desc'],
    ]);
  });
  it('line rows 05/06 carry the line number in the key, the master name, and are written only when fine and no ItAmt', () => {
    const line = (srNo: number, fine: number, itemAmount: number) => ({
      srNo,
      itType: 'G',
      pcs: 1,
      grossWt: 10,
      netWt: 9.5,
      touch: 91.6,
      westPct: 0,
      fine,
      itemAmount,
      remark: 'R',
      itCode: 'I1',
    });
    const rows = buildWholesaleRojmel(ctx as any, {
      ...base,
      issued: [line(1, 8.7, 0), line(2, 4, 100)],
      received: [line(1, 2, 0)],
    });
    expect(rows.map((r) => [r.LEDR_KEY.slice(-12), r.AC_NAME, r.SIGN, r.LD_CODE])).toEqual([
      ['05         1', 'Customer Master', '-', 'S1'],
      ['06         1', 'Customer Master', '+', 'S2'],
    ]);
  });
  it('14, 27 and 13 follow the source: Cr ABS(SL_BILL_OS) on slot 8, Cr labour on slot 6, Dr ABS(PR_BILL_OS)', () => {
    const rows = buildWholesaleRojmel(ctx as any, {
      ...base,
      saleBillOs: -40,
      purchaseBillOs: -9,
      labourAmount: 2375,
    });
    const byType: Record<string, any> = Object.fromEntries(
      rows.map((r) => [r.LEDR_KEY.slice(-2), r]),
    );
    expect([
      byType['14'].AC_CODE,
      byType['14'].LD_CODE,
      byType['14'].CR_AMT,
      byType['14'].AC_NAME,
    ]).toEqual(['P1', 'S8', 40, 'WSALE - Cust']);
    expect([
      byType['27'].AC_CODE,
      byType['27'].LD_CODE,
      byType['27'].CR_AMT,
      byType['27'].AC_NAME,
    ]).toEqual(['S6', 'P1', 2375, 'LBR - Cust']);
    expect([byType['13'].DR_AMT, byType['13'].ITM_FINE, byType['13'].SIGN]).toEqual([9, 0, '']);
  });
  it('01 to 04 and 22/26 keep the source directions', () => {
    const rows = buildWholesaleRojmel(ctx as any, {
      ...base,
      drFine: 2,
      crFine: 3,
      purchaseBillOs: 5,
      saleBillOs: 7,
      purchaseAmount: 100,
      saleAmount: 200,
      purchaseChequeAmount: 50,
      purchaseKasarAmount: 4,
    });
    const t: Record<string, any> = Object.fromEntries(rows.map((r) => [r.LEDR_KEY.slice(-2), r]));
    expect([t['01'].CR_AMT, t['01'].SIGN, t['01'].ITM_FINE, t['01'].ITM_RATE]).toEqual([
      5,
      '-',
      2,
      6500,
    ]);
    expect([t['02'].AC_CODE, t['02'].DR_AMT]).toEqual(['S2', 100]);
    expect([t['03'].DR_AMT, t['03'].SIGN, t['03'].ITM_FINE]).toEqual([7, '+', 3]);
    expect([t['04'].AC_CODE, t['04'].CR_AMT]).toEqual(['S1', 200]);
    expect([t['22'].AC_CODE, t['22'].CR_AMT, t['22'].AC_NAME]).toEqual(['BNK', 50, '']);
    expect([t['26'].AC_CODE, t['26'].CR_AMT, t['26'].AC_NAME]).toEqual(['S5', 4, 'KSR - Cust']);
  });
});

describe('Wh_Sales_Rojmel sale-side tender, purchase labour and blank slots', () => {
  it('21 cheque, 23 card, 25 kasar are Dr rows; 24 purchase card is Cr; 28 purchase labour is Dr', () => {
    const rows = buildWholesaleRojmel(ctx as any, {
      ...base,
      saleChequeAmount: 2000,
      saleCardAmount: 1000,
      saleKasarAmount: 40,
      purchaseCardAmount: 70,
      purchaseLabourAmount: 55,
    });
    const t: Record<string, any> = Object.fromEntries(rows.map((r) => [r.LEDR_KEY.slice(-2), r]));
    expect([
      t['21'].AC_CODE,
      t['21'].LD_CODE,
      t['21'].DR_AMT,
      t['21'].CR_AMT,
      t['21'].AC_NAME,
    ]).toEqual(['BNK', 'P1', 2000, 0, '']);
    expect([t['23'].AC_CODE, t['23'].DR_AMT, t['23'].AC_NAME]).toEqual(['CRD', 1000, '']);
    expect([t['24'].AC_CODE, t['24'].CR_AMT, t['24'].DR_AMT]).toEqual(['CRD', 70, 0]);
    expect([t['25'].AC_CODE, t['25'].DR_AMT, t['25'].AC_NAME]).toEqual(['S4', 40, 'KSR - Cust']);
    expect([t['28'].AC_CODE, t['28'].DR_AMT, t['28'].AC_NAME]).toEqual(['S7', 55, 'LBR - Cust']);
  });
  it('a slot row with a blank account still writes its row; a missing slot row writes none', () => {
    const slots = { 1: '', 2: '', 12: '', 6: '' } as Record<number, string>;
    const line = {
      srNo: 1,
      itType: 'G',
      pcs: 1,
      grossWt: 1,
      netWt: 1,
      touch: 90,
      westPct: 0,
      fine: 0.9,
      itemAmount: 0,
      remark: '',
      itCode: 'I',
    };
    const rows = buildWholesaleRojmel(ctx as any, {
      ...base,
      bankAc: '',
      slots,
      ksrFineDr: 0.5,
      labourAmount: 10,
      issued: [line],
    });
    expect(rows.map((r) => r.LEDR_KEY.slice(21, 23)).sort()).toEqual(['05', '07', '27']);
    expect(rows.every((r) => ['', 'P1'].includes(String(r.LD_CODE)) || r.LD_CODE === '')).toBe(
      true,
    );
    expect(
      buildWholesaleRojmel(ctx as any, {
        ...base,
        slots: {},
        ksrFineDr: 0.5,
        labourAmount: 10,
        issued: [line],
      }),
    ).toEqual([]);
  });
});

describe('Wh_Sales_Ledr fine kasar legs 27/28/33/34', () => {
  const figures: any = {
    itType: 'G',
    fineRate: 0,
    drAmt: 0,
    crAmt: 0,
    drFine: 0,
    crFine: 0,
    slFine: 0,
    prFine: 0,
    slItmAmt: 0,
    prItmAmt: 0,
    slLbrAmt: 0,
    slOthAmt: 0,
    prLbrAmt: 0,
    prOthAmt: 0,
    slChqAmt: 0,
    slCardAmt: 0,
    slCashAmt: 0,
    slKasarAmt: 0,
    prChqAmt: 0,
    prCardAmt: 0,
    prCashAmt: 0,
    prKasarAmt: 0,
    ksrFineDr: 0.5,
    ksrFineCr: 0.25,
  };
  const legs = buildRateCutLedger(
    { CO_CODE: '01', LC_CODE: '01', CO_YEAR: 'Y', CO_BOOK: 'WHS', VCH_NO: '00001' } as any,
    {
      customer: 'P1',
      figures,
      accounts: { fineKasarAc: 'S12' },
      bankAc: '',
      cardAc: '',
      receivedBankAc: '',
      receivedCardAc: '',
      tradeFine: false,
      vchDate: new Date('2026-06-15'),
      vchType: 'WSALE',
      bookName: 'WH SALES',
      coBook: 'WHS',
    } as any,
  );
  it('party + / slot 12 - for Cr 0.25 (27/28) and party - / slot 12 + for Dr 0.5 (33/34), money 0', () => {
    expect(
      legs.map((l: any) => [l.legType, l.AC_CODE, l.SIGN, l.FINE_WT, l.DR_AMT, l.CR_AMT]),
    ).toEqual([
      [27, 'P1', '+', 0.25, 0, 0],
      [28, 'S12', '-', 0.25, 0, 0],
      [33, 'P1', '-', 0.5, 0, 0],
      [34, 'S12', '+', 0.5, 0, 0],
    ]);
  });
});

describe('planWholesaleDetails', () => {
  const tx = { $queryRawUnsafe: async () => [{ t: 'G' }] };
  it('rolls the rows into the line (OthWt .5, NetWt 4.5, OthAmt 1263) and resolves the item type', async () => {
    const lines = [
      {
        grossWt: 5,
        details: [
          { itCode: 'DST', pcs: 2, pcsWt: 1.5, conPct: 0.1, rate: 101, discPct: 5, lbrRate: 237.5 },
          { pcs: 2, grossWt: 2, conPct: 0.1, netAmt: 500 },
        ],
      },
    ];
    const plan = await planWholesaleDetails(tx, 't', '01', lines);
    expect(plan.patch(lines[0], 0)).toMatchObject({ othWt: 0.5, netWt: 4.5, othAmt: 1263 });
    expect(plan.rows.get(1)![0]).toMatchObject({ netAmt: 763, itType: 'G' });
  });
  it('refuses negatives and rows on a tagged line; kasar is 3 places', async () => {
    await expect(planWholesaleDetails(tx, 't', '01', [{ details: [{ pcs: -1 }] }])).rejects.toThrow(
      /negative/,
    );
    await expect(
      planWholesaleDetails(tx, 't', '01', [{ tagNo: 'T1', details: [{ pcs: 1 }] }]),
    ).rejects.toThrow(/tagged line/);
    expect(kasarFine('0.12345', 'k')).toBe(0.123);
    expect(() => kasarFine(-1, 'k')).toThrow(/negative/);
  });
});

// Ac_Rojmel.cs:239-261: silver uses slots 9/8, types 09-12 and 17-20.
describe('silver wholesale day book', () => {
  it('uses silver accounts, empty amount names, and silver fine kasar keys', () => {
    const rows = buildWholesaleRojmel(
      ctx as any,
      {
        ...base,
        itType: 'S',
        slots: { ...base.slots, 9: 'S9' },
        drFine: 2,
        crFine: 3,
        purchaseBillOs: 5,
        saleBillOs: 7,
        purchaseAmount: 100,
        saleAmount: 200,
        ksrFineDr: 0.5,
        ksrFineCr: 0.25,
      } as any,
    );
    expect(
      rows.map((r) => [
        r.LEDR_KEY.slice(-2),
        r.AC_CODE,
        r.LD_CODE,
        r.AC_NAME,
        r.IT_TYPE,
        r.DR_AMT,
        r.CR_AMT,
        r.ITM_FINE,
      ]),
    ).toEqual([
      ['09', 'P1', 'S9', 'WSALE - Cust', 'S', 0, 5, 2],
      ['10', 'S9', 'P1', '', 'A', 100, 0, 0],
      ['11', 'P1', 'S8', 'WSALE - Cust', 'S', 7, 0, 3],
      ['12', 'S8', 'P1', '', 'A', 0, 200, 0],
      ['19', 'P1', 'S12', 'KSR - Customer Master', 'S', 0, 0, 0.5],
      ['20', 'P1', 'S12', 'KSR - Customer Master', 'S', 0, 0, 0.25],
    ]);
  });
});

// TR_WH_SALE.cs:7326: even an editor cannot remove stored detail rows without UserDelete.
describe('wholesale detail deletion authorization', () => {
  it('rejects fewer stored rows before the voucher is reversed', async () => {
    const { assertNoDetailDeletion } = await import('../src/modules/sales/wholesaleDetailRows.js');
    const tx = { $queryRawUnsafe: async () => [{ sr: 1, count: 2 }] };
    await expect(
      assertNoDetailDeletion(
        tx,
        { tenantId: 't', CO_CODE: '01', LC_CODE: '01', CO_YEAR: 'Y', CO_BOOK: 'WHS', VCH_NO: '1' },
        [{ details: [] }],
      ),
    ).rejects.toThrow('You Have No Rights.....');
    await expect(
      assertNoDetailDeletion(
        tx,
        { tenantId: 't', CO_CODE: '01', LC_CODE: '01', CO_YEAR: 'Y', CO_BOOK: 'WHS', VCH_NO: '1' },
        [{ details: [{ pcs: 1 }, { pcs: 2 }] }],
      ),
    ).resolves.toBeUndefined();
  });
});

// Ac_Rojmel.cs:251-257,279-293: independent desktop vectors for the remaining WH SALES families.
describe('wholesale supplementary rojmel families', () => {
  it('keeps silver receive on slot 8, clears its description, and writes embedded silver independently of line metal', () => {
    const line = {
      srNo: 2,
      itType: 'S',
      pcs: 1,
      grossWt: 10,
      netWt: 9,
      touch: 92.5,
      westPct: 1,
      fine: 8.325,
      itemAmount: 0,
      remark: 'remark',
      itCode: 'SLV',
      silverFine: 0.3,
    };
    const rows = buildWholesaleRojmel(ctx as any, { ...base, issued: [line], received: [line] });
    expect(
      rows.map((r) => [
        r.LEDR_KEY.slice(-12),
        r.IT_TYPE,
        r.LD_CODE,
        r.SIGN,
        r.ITM_GWT,
        r.ITM_NWT,
        r.ITM_FINE,
        r.IT_DESC,
      ]),
    ).toEqual([
      ['15         2', 'S', 'S8', '-', 10, 9, 8.325, 'remark'],
      ['16         2', 'S', 'S8', '-', 0.3, 0.3, 0.3, 'remark'],
      ['17         2', 'S', 'S8', '+', 10, 9, 8.325, ''],
      ['18         2', 'S', 'S8', '+', 0.3, 0.3, 0.3, ''],
    ]);
  });
  it.each(['G', 'S'] as const)(
    'writes interest and silver conversion rows for a %s header',
    (itType) => {
      const rows = buildWholesaleRojmel(ctx as any, {
        ...base,
        itType,
        slots: { ...base.slots, 9: 'S9' },
        interestFine: 0.125,
        interestAccount: 'INT',
        silverFineCr: 2,
        silverFineDr: 3,
        silverAmountDr: 200,
        silverAmountCr: 300,
        silverFineRate: 100,
      });
      expect(
        rows.map((r) => [
          r.LEDR_KEY.slice(-2),
          r.AC_CODE,
          r.LD_CODE,
          r.AC_NAME,
          r.IT_TYPE,
          r.SIGN,
          r.ITM_FINE,
          r.ITM_RATE,
          r.DR_AMT,
          r.CR_AMT,
        ]),
      ).toEqual([
        [
          itType === 'G' ? '29' : '30',
          'P1',
          'INT',
          'INT - Customer Master',
          itType,
          '-',
          0.125,
          0,
          0,
          0,
        ],
        ['33', 'P1', 'S8', 'WSALE - Cust', itType, '+', 2, 100, 0, 0],
        ['34', 'S8', 'P1', '', 'A', '', 0, 0, 0, 200],
        ['35', 'P1', 'S9', 'WSALE - Cust', itType, '-', 3, 100, 0, 0],
        ['36', 'S9', 'P1', '', 'A', '', 0, 0, 300, 0],
      ]);
      expect(
        buildWholesaleRojmel(ctx as any, {
          ...base,
          slots: {},
          interestFine: 1,
          interestAccount: 'INT',
          silverFineCr: 2,
          silverAmountCr: 3,
        }),
      ).toEqual([]);
    },
  );
  it('requires slot 1 for purchase cheque just as sale cheque does (:265)', () => {
    expect(
      buildWholesaleRojmel(ctx as any, { ...base, slots: {}, purchaseChequeAmount: 100 }),
    ).toEqual([]);
  });
});
