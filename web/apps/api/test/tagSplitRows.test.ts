import { describe, expect, it } from 'vitest';
import {
  barDataRow,
  childBarDetlRow,
  childReceiveRow,
  childStoneRows,
  deleteAuditRows,
  diamondRows,
  headerRow,
  ledgerRows,
  parentCellsFromBarDetl,
  parentDetailRow,
  parentStoneRows,
  resolveChild,
  rojmelRows,
  stockRows,
  stoneFromTag,
  stonesFromInput,
  tempBookRow,
  type TagSplitItem,
  type TagSplitWriteChild,
  type TagSplitWriteContext,
  type TagSplitWriteParent,
} from '../src/modules/stock/tagSplitRows.js';

/**
 * The TR_TAG_SPLIT row model without a database. Expected values are worked from the desktop statements quoted in
 * tagSplitRows.ts (BtnSave_Click 9960-10770), Ac_Stock.cs (Tag_Split_Stk 403-413, Dm_Tag_Split_Detl 841-847) and
 * Ac_Ledr.cs (Tag_Split_Ledr 1953-1982).
 */
const settings = { labourIncludesGhat: true };

const RNG: TagSplitItem = {
  itCode: 'RNG',
  itName: 'Ring 22K',
  itType: 'G',
  prCode: 'RG',
  tagType: 'R',
  rateType: '',
  postsDiamonds: false,
};
const RNGH: TagSplitItem = { ...RNG, itCode: 'RNGH', itName: 'Half Ring', prCode: 'RH' };
const DIA: TagSplitItem = {
  itCode: 'DIA',
  itName: 'Diamond',
  itType: 'D',
  prCode: 'DM',
  tagType: 'D',
  rateType: 'W',
  postsDiamonds: true,
};

/** A parent tag's BAR_DETL row (net 10.000, a diamond stone). */
const PARENT_BAR = {
  TAG_NO: 'SPL00001',
  VCH_SRNO: 100200000001,
  IT_CODE: 'RNG',
  TBL_CODE: '001',
  DESIGN_NO: 'D-1',
  ITM_SIZE: '12',
  ITM_PCS: '1.000',
  ITM_GWT: 10,
  ITM_OTH_WT: 0,
  ITM_NWT: 10,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 0,
  ITM_FINE: 9.16,
  KR_NET_WT: 10,
  KR_TOUCH: 91.6,
  KR_FINE: 9.16,
  RATE_TYPE: '',
  IT_TYPE: 'G',
  TAG_TYPE: 'R',
  PR_CODE: 'RG',
  DATA_TYPE: 'A',
  DESIGN_IMG_ID: 'IMG-1',
};

const ctx = (over: Partial<TagSplitWriteContext> = {}): TagSplitWriteContext => ({
  key: { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025', CO_BOOK: 'TSP', VCH_NO: '00001' },
  book: {
    name: 'Tag Split',
    shortName: 'TGSPL',
    mainBook: 'TAG SPLIT',
    inout: 'O',
    dataType: 'A',
    slots: { 5: 'LBREXP', 6: 'PURCHASE', 7: 'SALES', 8: 'PURCHASE', 9: 'SALES' },
  },
  hiddenVoucherNo: '00001',
  vchDate: new Date('2024-06-10T00:00:00.000Z'),
  vchTime: new Date('2024-06-10T10:11:12.000Z'),
  mainUser: 'operator',
  empCode: '001',
  vchDesc: 'SPLIT',
  acCode: '',
  itType: 'G',
  balance: { drWt: 0, crWt: 0, drFine: 0, crFine: 0, crLbr: 0 },
  ...over,
});

const parent = (): TagSplitWriteParent => ({
  cells: parentCellsFromBarDetl(PARENT_BAR),
  srNo: 1,
  oldSrNo: 1,
  stones: [
    stoneFromTag(
      { IT_CODE: 'DIA', IT_TYPE: 'D', IT_PCS: 10, IT_GWT: 0.5, IT_AMT: 1000, IT_NET_AMT: 1200 },
      1,
    ),
  ],
});

const child = (
  item: TagSplitItem,
  netWt: number,
  tagNo: string,
  srNo: number,
): TagSplitWriteChild => ({
  cells: resolveChild({
    input: { itCode: item.itCode, grossWt: netWt, touch: 91.6 },
    item,
    identity: { tagNo, vchSrno: srNo + 900000000, tagSrno: srNo },
    companyLabourType: 'G',
    stones: [],
    settings,
  }),
  srNo: srNo + 1,
  oldSrNo: srNo,
  stones: [],
});

describe('parent fill (K3)', () => {
  it('loads the parent verbatim from BAR_DETL with a two-place karigar net', () => {
    const cells = parentCellsFromBarDetl({ ...PARENT_BAR, KR_NET_WT: 9.905 });
    expect(cells).toMatchObject({
      tagNo: 'SPL00001',
      vchSrno: 100200000001,
      itCode: 'RNG',
      netWt: 10,
      fine: 9.16,
      krNetWt: 9.91,
      prCode: 'RG',
      tagType: 'R',
      dataType: 'A',
    });
  });

  it('takes the karigar touch/wastage/fine when the tag has no touch', () => {
    const cells = parentCellsFromBarDetl({
      ...PARENT_BAR,
      ITM_TOUCH: 0,
      ITM_WEST_PRC: 0,
      ITM_FINE: 0,
      KR_TOUCH: 90,
      KR_FINE: 9,
    });
    expect([cells.touch, cells.fine]).toEqual([90, 9]);
  });
});

describe('child resolution (K4/K5)', () => {
  it('runs a child through CommPassTotal_Pr and stamps its allocated identity', () => {
    const c = resolveChild({
      input: { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
      item: RNGH,
      identity: { tagNo: 'RH000005', vchSrno: 900000005, tagSrno: 5 },
      companyLabourType: 'G',
      stones: [],
      settings,
    });
    expect(c).toMatchObject({
      tagNo: 'RH000005',
      vchSrno: 900000005,
      tagSrno: 5,
      netWt: 6,
      fine: 5.496,
      prCode: 'RH',
    });
  });

  it('applies child stones to the child row', () => {
    const stones = stonesFromInput(
      [{ itCode: 'DIA', pcs: 5, pcsWt: 0.1, conPct: 1, rateType: 'W', rate: 2000, lbrRate: 20 }],
      new Map([['DIA', DIA]]),
    );
    const c = resolveChild({
      input: { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
      item: RNGH,
      identity: { tagNo: 'RH000005', vchSrno: 900000005, tagSrno: 5 },
      companyLabourType: 'G',
      stones,
      settings,
    });
    // stone weight 0.5, conWt 0.5 -> less 0.5, net 5.5; net amount 2000x0.5 + 20x5 = 1100 -> OthAmt.
    expect([c.lessWt, c.netWt, c.othAmt]).toEqual([0.5, 5.5, 1100]);
  });
});

describe('the desktop rows', () => {
  it('stamps the book on the header, temp book and detail rows', () => {
    expect(headerRow(ctx())).toMatchObject({
      VCH_TYPE: 'TGSPL',
      BOOK_NAME: 'TAG SPLIT',
      ENTRY_TYPE: 'C',
      HD_VCH_NO: '00001',
      USER_UPDATE: 'N',
    });
    expect(tempBookRow(ctx())).toMatchObject({ VCH_NO: '00001', BOOK_NAME: 'Tag Split' });
    expect(barDataRow(ctx())).toMatchObject({ VCH_NO: '00001', HD_VCH_NO: '00001' });
    expect(parentDetailRow(ctx(), parent())).toMatchObject({
      ENTRY_TYPE: 'O',
      TAG_NO: 'SPL00001',
      VCH_SRNO: 100200000001,
      ITM_NWT: 10,
      ITM_FINE: 9.16,
    });
    const rec = childReceiveRow(ctx(), child(RNGH, 6, 'RH000005', 5));
    expect(rec).toMatchObject({
      ENTRY_TYPE: 'O',
      IT_CODE: 'RNGH',
      TAG_NO: 'RH000005',
      ITM_SIGN: '+',
      TAG_SRNO: 5,
    });
    expect(childBarDetlRow(ctx(), child(RNGH, 6, 'RH000005', 5))).toMatchObject({
      ENTRY_TYPE: 'I',
      TAG_NO: 'RH000005',
    });
  });

  it('builds Tag_Split_Stk: parent SR_NO 1 out, children SR_NO 2 in, fine conserved', () => {
    const p = parent();
    const c1 = child(RNGH, 6, 'RH000005', 5);
    const c2 = child(RNGH, 4, 'RH000006', 6);
    const rows = stockRows(ctx(), [p], [c1, c2]);
    expect(
      rows.map((r) => [r.SR_NO, r.ISR_NO, r.TAG_NO, r.TR_TYPE, r.ITM_SIGN, r.ITM_FINE]),
    ).toEqual([
      [1, 1, 'SPL00001', 'O', '-', 9.16],
      [2, 6, 'RH000005', 'I', '+', 5.496],
      [2, 7, 'RH000006', 'I', '+', 3.664],
    ]);
    // The parent out fine equals the sum of the child in fines (conservation).
    expect(9.16).toBeCloseTo(5.496 + 3.664, 3);
    // Parent carries NET_AMT and no MRP; a child carries MRP and NET_AMT 0.
    expect([rows[0]!.NET_AMT, rows[0]!.ITM_MRP]).toEqual([0, 0]);
    expect(rows[1]!.NET_AMT).toBe(0);
  });

  it('posts DM_DATA OUT for a parent stone and IN for a child stone, only for OTH_DETL_POSTING items', () => {
    const p = parent();
    const c = child(RNGH, 6, 'RH000005', 5);
    c.stones = stonesFromInput(
      [{ itCode: 'DIA', pcs: 2, pcsWt: 0.05, rateType: 'W', rate: 2000 }],
      new Map([['DIA', DIA]]),
    );
    const rows = diamondRows(ctx(), [p], [c], new Map([['DIA', DIA]]));
    expect(rows.map((r) => [r.MAIN_SRNO, r.DM_SIGN, r.INOUT_TYPE, r.MAIN_IT_CODE])).toEqual([
      [1, '-', 'O', 'RNG'],
      [2, '+', 'I', 'RNGH'],
    ]);
  });

  it('posts the absorption ledger only with an account and a fine difference, gating the mirror on TRAD_FINE', () => {
    const withAcct = ctx({
      acCode: 'SPLITAC',
      balance: { drWt: 1, crWt: 0, drFine: 0.916, crFine: 0, crLbr: 0 },
    });
    const noMirror = ledgerRows(withAcct, false);
    expect(
      noMirror.map((r) => [String(r.LEDR_KEY).slice(-4), r.AC_CODE, r.FINE_WT, r.SIGN]),
    ).toEqual([['03NN', 'SPLITAC', 0.916, '-']]);
    const withMirror = ledgerRows(withAcct, true);
    expect(withMirror.map((r) => String(r.LEDR_KEY).slice(-4))).toEqual(['03NN', '04NN']);
    // No account -> no legs.
    expect(
      ledgerRows(ctx({ balance: { drWt: 1, crWt: 0, drFine: 0.916, crFine: 0, crLbr: 0 } }), true),
    ).toEqual([]);
  });

  it('posts the labour ledger and rojmel legs', () => {
    const withLbr = ctx({
      acCode: 'SPLITAC',
      balance: { drWt: 0, crWt: 0, drFine: 0, crFine: 0, crLbr: 500 },
    });
    expect(
      ledgerRows(withLbr, false).map((r) => [
        String(r.LEDR_KEY).slice(-4),
        r.AC_CODE,
        r.CR_AMT,
        r.DR_AMT,
      ]),
    ).toEqual([
      ['01NN', 'SPLITAC', 500, 0],
      ['02NN', 'LBREXP', 0, 500],
    ]);
    const roj = rojmelRows(withLbr, 'Split Party', 'Split Party');
    expect(roj.map((r) => [String(r.LEDR_KEY).slice(-2), r.AC_CODE, r.DR_AMT])).toEqual([
      ['05', 'LBREXP', 500],
    ]);
  });

  it('writes one DELETE_DATA row per parent with the net weight as the credit fine', () => {
    const detail = parentDetailRow(ctx(), parent());
    const rows = deleteAuditRows(
      ctx().book,
      [detail],
      'operator',
      new Date('2024-06-11T00:00:00Z'),
    );
    expect(rows).toHaveLength(1);
    expect(rows[0]).toMatchObject({
      VCH_TYPE: 'TGSPL',
      BOOK_NAME: 'Tag Split',
      FINE_TYPE: 'G',
      VCH_FINE_CR: 10,
      DELETE_USER: 'operator',
      VCH_DESC: 'ItCode/RNG TagNo/SPL00001',
    });
  });

  it('saves only stones with pieces, weight or value', () => {
    const p = parent();
    expect(parentStoneRows(ctx(), p)).toHaveLength(1);
    const c = child(RNGH, 6, 'RH000005', 5);
    expect(childStoneRows(ctx(), c)).toHaveLength(0);
  });
});
