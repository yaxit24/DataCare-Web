import { describe, expect, it } from 'vitest';
import { buildWholesaleRojmel } from '../src/modules/shared/rojmelWholesale.js';
import { buildRateCutLedger } from '../src/modules/sales/rateCut.js';
import { planWholesaleDetails, kasarFine } from '../src/modules/sales/wholesaleDetailRows.js';

/** Ac_Rojmel.cs:221-310 and Ac_Ledr.cs:685-705, evaluated by hand. */
const ctx = {
  scope: { coCode: '01', lcCode: '01', coYear: '2026-2027' },
  key: { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2026-2027', CO_BOOK: 'WHS', VCH_NO: '00007' },
  coBook: 'WHS', vchNo: '00007', vchDate: '2026-06-15', vchType: 'WSALE', bookName: 'WH SALES',
  partyName: 'Cust', partyCode: 'P1',
};
const base = {
  slots: { sale: 'S1', purchase: 'S2', purchaseKasar: 'S5', labour: 'S6', silverSale: 'S8', fineKasar: 'S12' },
  headerName: 'Cust', masterName: 'Customer Master', vchDesc: 'desc', bankAc: 'BNK', fineRate: 6500,
  drFine: 0, crFine: 0, purchaseBillOs: 0, saleBillOs: 0, purchaseAmount: 0, saleAmount: 0, ksrFineDr: 0, ksrFineCr: 0,
  purchaseChequeAmount: 0, purchaseKasarAmount: 0, labourAmount: 0, issued: [], received: [],
};

describe('buildWholesaleRojmel (Wh_Sales_Rojmel)', () => {
  it('kasar rows 07/08: key, name, sign and ITM_FINE with every money column 0', () => {
    const rows = buildWholesaleRojmel(ctx as any, { ...base, ksrFineDr: 0.5, ksrFineCr: 0.25 });
    expect(rows.map((r) => [r.LEDR_KEY.slice(-2), r.AC_NAME, r.SIGN, r.ITM_FINE, r.AC_CODE, r.LD_CODE, r.DR_AMT, r.CR_AMT, r.IT_DESC]))
      .toEqual([
        ['07', 'KSR - Customer Master', '-', 0.5, 'P1', 'S12', 0, 0, 'desc'],
        ['08', 'KSR - Customer Master', '+', 0.25, 'P1', 'S12', 0, 0, 'desc'],
      ]);
  });
  it('line rows 05/06 carry the line number in the key, the master name, and are written only when fine and no ItAmt', () => {
    const line = (srNo: number, fine: number, itemAmount: number) => ({
      srNo, itType: 'G', pcs: 1, grossWt: 10, netWt: 9.5, touch: 91.6, westPct: 0, fine, itemAmount, remark: 'R', itCode: 'I1',
    });
    const rows = buildWholesaleRojmel(ctx as any, { ...base, issued: [line(1, 8.7, 0), line(2, 4, 100)], received: [line(1, 2, 0)] });
    expect(rows.map((r) => [r.LEDR_KEY.slice(-12), r.AC_NAME, r.SIGN, r.LD_CODE])).toEqual([
      ['05         1', 'Customer Master', '-', 'S1'],
      ['06         1', 'Customer Master', '+', 'S2'],
    ]);
  });
  it('14, 27 and 13 follow the source: Cr ABS(SL_BILL_OS) on slot 8, Cr labour on slot 6, Dr ABS(PR_BILL_OS)', () => {
    const rows = buildWholesaleRojmel(ctx as any, { ...base, saleBillOs: -40, purchaseBillOs: -9, labourAmount: 2375 });
    const byType: Record<string, any> = Object.fromEntries(rows.map((r) => [r.LEDR_KEY.slice(-2), r]));
    expect([byType['14'].AC_CODE, byType['14'].LD_CODE, byType['14'].CR_AMT, byType['14'].AC_NAME]).toEqual(['P1', 'S8', 40, 'WSALE - Cust']);
    expect([byType['27'].AC_CODE, byType['27'].LD_CODE, byType['27'].CR_AMT, byType['27'].AC_NAME]).toEqual(['S6', 'P1', 2375, 'LBR - Cust']);
    expect([byType['13'].DR_AMT, byType['13'].ITM_FINE, byType['13'].SIGN]).toEqual([9, 0, '']);
  });
  it('01 to 04 and 22/26 keep the source directions', () => {
    const rows = buildWholesaleRojmel(ctx as any, {
      ...base, drFine: 2, crFine: 3, purchaseBillOs: 5, saleBillOs: 7, purchaseAmount: 100, saleAmount: 200,
      purchaseChequeAmount: 50, purchaseKasarAmount: 4,
    });
    const t: Record<string, any> = Object.fromEntries(rows.map((r) => [r.LEDR_KEY.slice(-2), r]));
    expect([t['01'].CR_AMT, t['01'].SIGN, t['01'].ITM_FINE, t['01'].ITM_RATE]).toEqual([5, '-', 2, 6500]);
    expect([t['02'].AC_CODE, t['02'].DR_AMT]).toEqual(['S2', 100]);
    expect([t['03'].DR_AMT, t['03'].SIGN, t['03'].ITM_FINE]).toEqual([7, '+', 3]);
    expect([t['04'].AC_CODE, t['04'].CR_AMT]).toEqual(['S1', 200]);
    expect([t['22'].AC_CODE, t['22'].CR_AMT, t['22'].AC_NAME]).toEqual(['BNK', 50, '']);
    expect([t['26'].AC_CODE, t['26'].CR_AMT, t['26'].AC_NAME]).toEqual(['S5', 4, 'KSR - Cust']);
  });
});

describe('Wh_Sales_Ledr fine kasar legs 27/28/33/34', () => {
  const figures: any = {
    itType: 'G', fineRate: 0, drAmt: 0, crAmt: 0, drFine: 0, crFine: 0, slFine: 0, prFine: 0, slItmAmt: 0, prItmAmt: 0,
    slLbrAmt: 0, slOthAmt: 0, prLbrAmt: 0, prOthAmt: 0, slChqAmt: 0, slCardAmt: 0, slCashAmt: 0, slKasarAmt: 0,
    prChqAmt: 0, prCardAmt: 0, prCashAmt: 0, prKasarAmt: 0, ksrFineDr: 0.5, ksrFineCr: 0.25,
  };
  const legs = buildRateCutLedger(
    { CO_CODE: '01', LC_CODE: '01', CO_YEAR: 'Y', CO_BOOK: 'WHS', VCH_NO: '00001' } as any,
    {
      customer: 'P1', figures, accounts: { fineKasarAc: 'S12' }, bankAc: '', cardAc: '', receivedBankAc: '',
      receivedCardAc: '', tradeFine: false, vchDate: new Date('2026-06-15'), vchType: 'WSALE', bookName: 'WH SALES', coBook: 'WHS',
    } as any,
  );
  it('party + / slot 12 - for Cr 0.25 (27/28) and party - / slot 12 + for Dr 0.5 (33/34), money 0', () => {
    expect(legs.map((l: any) => [l.legType, l.AC_CODE, l.SIGN, l.FINE_WT, l.DR_AMT, l.CR_AMT])).toEqual([
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
    const lines = [{ grossWt: 5, details: [
      { itCode: 'DST', pcs: 2, pcsWt: 1.5, conPct: 0.1, rate: 101, discPct: 5, lbrRate: 237.5 },
      { pcs: 2, grossWt: 2, conPct: 0.1, netAmt: 500 },
    ] }];
    const plan = await planWholesaleDetails(tx, 't', '01', lines);
    expect(plan.patch(lines[0], 0)).toMatchObject({ othWt: 0.5, netWt: 4.5, othAmt: 1263 });
    expect(plan.rows.get(1)![0]).toMatchObject({ netAmt: 763, itType: 'G' });
  });
  it('refuses negatives and rows on a tagged line; kasar is 3 places', async () => {
    await expect(planWholesaleDetails(tx, 't', '01', [{ details: [{ pcs: -1 }] }])).rejects.toThrow(/negative/);
    await expect(planWholesaleDetails(tx, 't', '01', [{ tagNo: 'T1', details: [{ pcs: 1 }] }])).rejects.toThrow(/tagged line/);
    expect(kasarFine('0.12345', 'k')).toBe(0.123);
    expect(() => kasarFine(-1, 'k')).toThrow(/negative/);
  });
});
