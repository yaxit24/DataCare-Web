import { describe, expect, it } from 'vitest';
import {
  applyLineInput,
  cellsFromBarDetl,
  cellsFromSaved,
  deleteAuditRows,
  detailRow,
  diamondRows,
  looseCells,
  replayBaseline,
  stockRows,
  stoneRows,
  stonesFromInput,
  type TagCancelItem,
  type TagCancelWriteContext,
  type TagCancelWriteLine,
} from '../src/modules/stock/tagCancelRows.js';

/**
 * The TR_TAG_CAN row model without a database: the tag fill (K3), the edit replay (K4) and the desktop rows
 * (K6-K8, K11). Expected values are worked from TR_TAG_CAN.cs and Ac_Stock.cs as quoted in `tagCancelRows.ts`.
 */

const settings = { labourIncludesGhat: true };
const TAG = {
  TAG_NO: 'RNG00001',
  VCH_SRNO: 100100000001,
  IT_CODE: 'RNG',
  TBL_CODE: '001',
  DESIGN_NO: 'D-101 ',
  ITM_SIZE: '12',
  BAG_WT: 0.05,
  ITM_PCS: '1.000',
  ITM_GWT: 10.5,
  ITM_OTH_WT: 0.5,
  ITM_NWT: 10,
  ITM_GHT_PRC: 1.25,
  ITM_GHT_WT: 0,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 2,
  ITM_FINE: 9.36,
  LBR_PRC: 0,
  LBR_TYPE: 'N',
  LBR_RATE: 150,
  LBR_AMT: 1500,
  OTH_AMT: 1200,
  ITM_RATE: 0,
  ITM_AMT: 0,
  ITM_MRP: 0,
  KR_NAME: 'KJ',
  KR_NET_WT: 9.905,
  KR_TOUCH: 90,
  KR_WEST_PRC: 1.5,
  KR_FINE: 9.15,
  RATE_TYPE: null,
  IT_TYPE: 'G',
  PR_CODE: 'RG',
  DESIGN_IMG_ID: 'IMG-101',
};
const OG: TagCancelItem = {
  itCode: 'OG',
  itName: 'Old Gold',
  itType: 'G',
  prCode: 'OG',
  rateType: '',
  postsDiamonds: false,
};
const DIA: TagCancelItem = {
  itCode: 'DIA',
  itName: 'Diamond',
  itType: 'D',
  prCode: 'DM',
  rateType: 'W',
  postsDiamonds: true,
};

const ctx = (mode: 'cancel' | 'transfer'): TagCancelWriteContext => ({
  mode,
  key: { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025', CO_BOOK: 'TGC', VCH_NO: '00001' },
  book: {
    name: 'Tag Cancel',
    shortName: mode === 'cancel' ? 'TGCAN' : 'TAGTR',
    mainBook: mode === 'cancel' ? 'TAG CANCEL' : 'TAG TRFR',
    inout: 'O',
    dataType: 'A',
  },
  hiddenVoucherNo: '00004',
  vchDate: new Date('2024-06-10T00:00:00.000Z'),
  vchTime: new Date('2024-06-10T10:11:12.000Z'),
  mainUser: 'operator',
  empCode: '001',
  vchDesc: 'DAMAGED',
});

describe('the tag fill (K3)', () => {
  it('loads the grid with the desktop formats, verbatim text and a two-place karigar net', () => {
    const cells = cellsFromBarDetl(TAG);
    expect(cells).toMatchObject({
      tagNo: 'RNG00001',
      vchSrno: 100100000001,
      designNo: 'D-101 ',
      lotNo: '',
      itmLot: '',
      pcs: 1,
      ghtPct: 1.25,
      touch: 91.6,
      fine: 9.36,
      krNetWt: 9.91,
      krFine: 9.15,
      rateType: '',
      designImageId: 'IMG-101',
    });
  });

  it('takes the karigar touch, wastage and fine when the tag has no touch (:4043-4050)', () => {
    const cells = cellsFromBarDetl({ ...TAG, ITM_TOUCH: 0, ITM_WEST_PRC: 0, ITM_FINE: 0 });
    expect([cells.touch, cells.westPct, cells.fine]).toEqual([90, 1.5, 9.15]);
  });

  it('starts a loose row on the company labour basis with Image N (CommPassAdd)', () => {
    expect(looseCells(OG, 'N')).toMatchObject({
      itCode: 'OG',
      tagNo: '',
      lbrType: 'N',
      prCode: 'OG',
      itType: 'G',
      designImageId: 'N',
    });
  });

  it('reopens a saved loose line with a blank tag number (DISPLAY_DATA maps N to blank)', () => {
    expect(cellsFromSaved({ TAG_NO: 'N', IT_CODE: 'OG', KR_NET_WT: 2.004 })).toMatchObject({
      tagNo: '',
      krNetWt: 2.004,
    });
  });
});

describe('the operator edits replayed through CommPassTotal (K4)', () => {
  const tagged = (input: Record<string, unknown>, mode: 'cancel' | 'transfer' = 'cancel') => {
    const base = cellsFromBarDetl(TAG);
    return applyLineInput({
      mode,
      row: 1,
      tagged: true,
      base,
      baseline: replayBaseline(base),
      input,
      stones: [],
      stonesGiven: false,
      settings,
    });
  };

  it('keeps an untouched tag exactly, and an unchanged cell is not an edit', () => {
    const base = cellsFromBarDetl(TAG);
    expect(tagged({})).toEqual(base);
    expect(tagged({ grossWt: 10.5, touch: 91.6, fine: 9.36 })).toEqual(base);
  });

  it('replays given cells in column order, as typed', () => {
    const loose = looseCells(OG, 'G');
    const cells = applyLineInput({
      mode: 'cancel',
      row: 1,
      tagged: false,
      base: loose,
      baseline: replayBaseline(null),
      input: { grossWt: 2, netWt: 1.8, touch: 75 },
      stones: [],
      stonesGiven: false,
      settings,
    });
    // GrWt 2 -> net 2; NetWt 1.8 typed; Touch 75 -> fine 1.8 x 75 / 100 = 1.35; the karigar block copies it.
    expect([cells.netWt, cells.fine, cells.krNetWt, cells.krFine]).toEqual([1.8, 1.35, 1.8, 1.35]);
  });

  it('stores a cell the caller gives as given, over the recomputed value', () => {
    // The screen sends every cell of the row it shows, so a typed fine after a touch change is kept.
    const cells = tagged({ touch: 92, fine: 9.5 });
    expect([cells.touch, cells.fine]).toEqual([92, 9.5]);
  });

  it('refuses the read-only cells of a tag line and the other mode’s columns', () => {
    expect(() => tagged({ pcs: 2 })).toThrow('row 1: Pcs comes from the tag');
    expect(() => tagged({ tblCode: '009' })).toThrow('row 1: Counter comes from the tag');
    expect(() => tagged({ krName: 'ZZ' })).toThrow('row 1: KrCode comes from the tag');
    expect(() => tagged({ mrp: 1 }, 'transfer')).toThrow('row 1: Mrp is not a Tag Transfer column');
    expect(() => tagged({ lbrRate: 1 }, 'transfer')).toThrow(
      'row 1: LbrRate is not a Tag Transfer column',
    );
    expect(() => tagged({ ghtWt: 1 }, 'transfer')).toThrow(
      'row 1: GhtWt is not a Tag Transfer column',
    );
    expect(() => tagged({ trfrItCode: 'OG' })).toThrow('row 1: TrfrItm is a Tag Transfer column');
    // The tag's own values in a hidden column are not an edit.
    expect(() => tagged({ othAmt: 1200, lbrRate: 150, mrp: 0 }, 'transfer')).not.toThrow();
  });

  it('recomputes the Transfer grid’s hidden labour amount on a weight edit and takes the screen’s value', () => {
    // LbrAmt (col 25) is hidden on the Tag Transfer grid but CommPassTotal still computes it: GrWt 11 -> net 10.5,
    // labour N 150 x (10.5 + 0 ght) = 1575. The screen sends what it computed; an API caller may leave it out.
    expect(tagged({ grossWt: 11 }, 'transfer')).toMatchObject({ netWt: 10.5, lbrAmt: 1575 });
    expect(tagged({ grossWt: 11, lbrAmt: 1575, othAmt: 1200 }, 'transfer')).toMatchObject({
      netWt: 10.5,
      lbrAmt: 1575,
      othAmt: 1200,
    });
  });

  it('upper-cases typed text and drops the apostrophe, as the form does', () => {
    expect(tagged({ designNo: "d-9'x" }).designNo).toBe('D-9X');
  });

  it('consumes every cell the screen sends: a new value is stored or refused, never ignored (no dead cell)', () => {
    // The cells TagCancelForm's linePayload sends besides the tag identity, oldSrNo, stones and TrfrItm (tagCancel.ts).
    const numeric = [
      'bagWt',
      'pcs',
      'grossWt',
      'lessWt',
      'netWt',
      'ghtWt',
      'touch',
      'westPct',
      'fine',
      'lbrRate',
      'lbrAmt',
      'othAmt',
      'mrp',
      'amount',
      'krNetWt',
      'krTouch',
      'krWestPct',
      'krFine',
    ] as const;
    const loose = (input: Record<string, unknown>) =>
      applyLineInput({
        mode: 'cancel',
        row: 1,
        tagged: false,
        base: looseCells(OG, 'G'),
        baseline: replayBaseline(null),
        input,
        stones: [],
        stonesGiven: false,
        settings,
      });
    for (const field of numeric) {
      for (const [line, run] of [
        ['tag', (input: Record<string, unknown>) => tagged(input)],
        ['loose', loose],
      ] as const) {
        let stored: unknown;
        try {
          stored = run({ [field]: 3 })[field];
        } catch (error) {
          expect(String(error), `${line} ${field}`).toMatch(/^TagCancelValidationError: row 1: /);
          continue;
        }
        expect(stored, `${line} ${field}`).toBe(3);
      }
    }
    expect(loose({ tblCode: '009', krName: 'zz', designNo: 'd1', itmSize: 's' })).toMatchObject({
      tblCode: '009',
      krName: 'ZZ',
      designNo: 'D1',
      itmSize: 'S',
    });
    expect(tagged({ designNo: 'D-202', itmSize: '14' })).toMatchObject({
      designNo: 'D-202',
      itmSize: '14',
    });
  });

  it('applies edited stones to the row after the gross weight', () => {
    const base = cellsFromBarDetl(TAG);
    const stones = stonesFromInput(
      [{ itCode: 'DIA', pcs: 5, grossWt: 0.25, conPct: 1, rateType: 'W', rate: 2000, lbrRate: 20 }],
      new Map([['DIA', DIA]]),
    );
    expect(stones).toEqual([
      expect.objectContaining({
        isrNo: 1,
        itCode: 'DIA',
        amount: 500,
        lbrAmount: 100,
        netAmount: 600,
        conWt: 0.25,
        karigarWt: 0.25,
        itType: 'D',
      }),
    ]);
    const cells = applyLineInput({
      mode: 'cancel',
      row: 1,
      tagged: true,
      base,
      baseline: replayBaseline(base),
      input: {},
      stones,
      stonesGiven: true,
      settings,
    });
    expect([cells.lessWt, cells.netWt, cells.othAmt, cells.fine, cells.lbrAmt]).toEqual([
      0.25, 10.25, 600, 9.594, 1538,
    ]);
  });
});

describe('the desktop rows', () => {
  const line = (mode: 'cancel' | 'transfer'): TagCancelWriteLine => ({
    cells: { ...cellsFromBarDetl(TAG), trfrItCode: mode === 'transfer' ? 'OG' : '' },
    srNo: 2,
    oldSrNo: 5,
    stones: [
      {
        isrNo: 1,
        itCode: 'DIA',
        itName: 'Diamond',
        pcs: 10,
        grossWt: 0.5,
        karigarWt: 0.5,
        conPct: 1,
        rateType: 'W',
        rate: 2000,
        amount: 1000,
        lbrRate: 20,
        lbrAmount: 200,
        netAmount: 1200,
        conWt: 0.5,
        karigarConWt: 0.5,
        itType: 'D',
      },
      {
        isrNo: 2,
        itCode: 'DIA',
        itName: 'Diamond',
        pcs: 0,
        grossWt: 0,
        karigarWt: 0,
        conPct: 0,
        rateType: '',
        rate: 0,
        amount: 0,
        lbrRate: 0,
        lbrAmount: 0,
        netAmount: 0,
        conWt: 0,
        karigarConWt: 0,
        itType: 'D',
      },
    ],
  });

  it('writes TRFR_IT_CODE only in transfer mode, and stamps the book on every line', () => {
    const cancel = detailRow(ctx('cancel'), line('cancel'));
    expect(cancel).not.toHaveProperty('TRFR_IT_CODE');
    expect(cancel).toMatchObject({
      SR_NO: 2,
      OLD_SRNO: 5,
      VCH_TYPE: 'TGCAN',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'T',
      BOOK_NAME: 'TAG CANCEL',
      ITM_SIGN: '-',
      AC_CODE: '',
      HD_VCH_NO: '00004',
      KR_NET_WT: 9.91,
    });
    expect(detailRow(ctx('transfer'), line('transfer'))).toMatchObject({ TRFR_IT_CODE: 'OG' });
  });

  it('builds Tag_Can_Stk insert 1 for every line and insert 2 for a transfer item', () => {
    const cancelStock = stockRows(ctx('cancel'), [detailRow(ctx('cancel'), line('cancel'))]);
    expect(cancelStock).toHaveLength(1);
    expect(cancelStock[0]).toMatchObject({
      ISR_NO: 1,
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      NET_AMT: 0,
      KR_COST: 0,
    });
    const transfer = stockRows(ctx('transfer'), [detailRow(ctx('transfer'), line('transfer'))]);
    expect(
      transfer.map((r) => [
        r.ISR_NO,
        r.IT_CODE,
        r.TAG_NO,
        r.VCH_SRNO,
        r.TBL_CODE,
        r.TR_TYPE,
        r.ITM_SIGN,
      ]),
    ).toEqual([
      [1, 'RNG', 'RNG00001', 100100000001, '001', 'O', '-'],
      [2, 'OG', 'N', 0, '001', 'I', '+'],
    ]);
    // Conservation: the + row carries the - row's measures and none of its money.
    const [out, into] = transfer;
    for (const column of [
      'ITM_PCS',
      'ITM_GWT',
      'ITM_NWT',
      'ITM_TOUCH',
      'ITM_WEST',
      'ITM_FINE',
      'KR_NWT',
      'KR_FINE',
    ]) {
      expect(into![column], column).toBe(out![column]);
    }
    for (const column of ['ITM_RATE', 'ITM_AMT', 'LBR_RATE', 'LBR_AMT', 'OTH_AMT', 'ITM_MRP']) {
      expect(into![column], column).toBe(0);
    }
  });

  it('saves only the stones with pieces, weight or value (:5200), under the parent line OLD_SRNO', () => {
    const rows = stoneRows(ctx('cancel'), line('cancel'));
    expect(rows).toHaveLength(1);
    expect(rows[0]).toMatchObject({
      SR_NO: 5,
      ISR_NO: 1,
      TAG_NO: 'RNG00001',
      VCH_SRNO: 100100000001,
      IT_CODE: 'DIA',
      IT_PCS: 10,
      IT_NET_AMT: 1200,
      VCH_TYPE: 'TGCAN',
      BOOK_NAME: 'TAG CANCEL',
      ENTRY_TYPE: 'T',
      AC_CODE: '',
    });
  });

  it('posts DM_DATA for OTH_DETL_POSTING stones with a value, in cancel mode only', () => {
    const items = new Map([['DIA', DIA]]);
    const rows = diamondRows(ctx('cancel'), [line('cancel')], items);
    expect(rows).toEqual([
      expect.objectContaining({
        MAIN_SRNO: 1,
        SR_NO: 5,
        ISR_NO: 1,
        BOOK_NAME: 'TGCAN',
        DM_SIGN: '-',
        DM_PCS: 10,
        DM_WT: 0.5,
        MAIN_IT_CODE: 'RNG',
        INOUT_TYPE: 'O',
      }),
    ]);
    expect(diamondRows(ctx('transfer'), [line('transfer')], items)).toEqual([]);
  });

  it('writes one DELETE_DATA row per line, with the net weight as the fine and a 20-character book', () => {
    const rows = deleteAuditRows(
      {
        name: 'Tag Cancel Main Counter Book',
        shortName: 'TGCAN',
        mainBook: 'TAG CANCEL',
        inout: 'O',
        dataType: 'A',
      },
      [
        {
          CO_CODE: '01',
          SR_NO: 1,
          IT_CODE: 'OG',
          TAG_NO: 'N',
          IT_TYPE: 'G',
          ITM_NWT: '2.000',
          MAIN_USER: 'a',
        },
      ],
      'b',
      new Date('2024-07-01T00:00:00.000Z'),
    );
    expect(rows[0]).toMatchObject({
      BOOK_NAME: 'Tag Cancel Main Coun',
      VCH_TYPE: 'TGCAN',
      AC_NAME: '',
      FINE_TYPE: 'G',
      VCH_FINE_CR: 2,
      VCH_FINE_DR: 0,
      MAIN_USER: 'a',
      DELETE_USER: 'b',
      VCH_DESC: 'ItCode/OG TagNo/N',
    });
  });
});
