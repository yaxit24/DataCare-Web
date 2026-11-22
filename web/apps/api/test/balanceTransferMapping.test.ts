/**
 * Balance TrFr: the Tag Stock, Sales Order and Approval row mappings (unit layer of orchestration/work/WP-23/cases.md).
 * The expected columns are the desktop insert value lists, read column by column from BtmSchm.cs (cited per case).
 */
import { describe, expect, it } from 'vitest';
import {
  approvalLineRow,
  approvalStoneRow,
  approvalTagRow,
  fnv,
  orderHeaderRow,
  orderLineRow,
  tagCarryRow,
  tagHeaderRow,
  tagStoneRow,
  tagVoucherNumbers,
} from '../src/modules/ops/balanceTransferMapping.js';

const ctx = {
  coCode: '01',
  lcCode: '01',
  toYear: '2026-2027',
  stockDate: '2026-03-31',
  mainUser: 'TESTER',
};

/** A source tag row with a distinct value in every column of the BtmSchm.cs:2378 list. */
const tagSource = {
  CO_CODE: '01',
  LC_CODE: '01',
  CO_YEAR: '2025-2026',
  CO_BOOK: 'TGO',
  VCH_NO: '00042',
  SR_NO: 7,
  VCH_DATE: '2025-08-01',
  STK_DATE: '2025-08-02',
  VCH_TYPE: 'TAGOP',
  BOOK_NAME: 'TAG OPBL',
  AC_CODE: '00099',
  IT_CODE: 'I4',
  TAG_NO: 'T001',
  DESIGN_NO: 'D-1',
  TBL_CODE: 'TB1',
  ITM_SIZE: '18',
  ITM_PCS: 1,
  BAG_WT: 0.01,
  ITM_GWT: 5,
  ITM_OTH_WT: 0.2,
  ITM_NWT: 4.8,
  ITM_GHT_PRC: 1.5,
  ITM_GHT_WT: 0.07,
  ITM_TOUCH: 91.6,
  ITM_WEST_PRC: 2,
  ITM_FINE: 4.397,
  LBR_PRC: 3,
  LBR_RATE: 400,
  LBR_TYPE: 'G',
  LBR_AMT: 2000,
  OTH_AMT: 150,
  ITM_RATE: 6000,
  ITM_AMT: 26382,
  TAG_COST: 25000,
  ITM_MARGIN: null,
  ITM_MRP: 30000,
  ITM_REMARK: 'RING',
  SF_NO: 'SF9',
  KR_NAME: 'KARIGAR',
  KR_OTH_WT: 0.1,
  KR_NET_WT: 4.7,
  KR_GHT_PRC: 1,
  KR_GHT_WT: 0.05,
  KR_TOUCH: 92,
  KR_WEST_PRC: 1,
  KR_FINE: 4.371,
  KR_LBR_RATE: 300,
  KR_LBR_AMT: 1500,
  KR_OTH_AMT: null,
  KR_COST: 24000,
  TAG_SRNO: 3,
  VCH_SRNO: 2,
  RATE_TYPE: 'W',
  IT_TYPE: 'G',
  TAG_TYPE: 'N',
  PR_CODE: 'PR1',
  APR_ISU: 'Y',
  ORD_NO: '00005',
  ORD_SRNO: 1,
  ORD_YRCD: '2025-2026',
  ORD_DBCD: 'SOR',
  ORD_AC: '00500',
  MAIN_USER: 'OLDUSER',
  ADD_USER: 'OLDUSER',
  DATA_TRFR: 'Y',
  HD_VCH_NO: '00099',
  OLD_VCH_NO: 'O1',
  NEW_VCH_NO: 'N1',
  HM_ID: 'H1',
  HM_ID2: 'H2',
  HM_ID3: 'H3',
  HM_ID4: 'H4',
  HM_ID_WT: 1,
  HM_ID2_WT: 2,
  HM_ID3_WT: 3,
  HM_ID4_WT: 4,
  DATA_TYPE: 'A',
  APP_TRFR: 'N',
  ITM_COLOR: 'YELLOW',
  MAIN_MARGIN_PRC: 12,
  MAIN_MRP: 31000,
  JDT_JDT_WT: 0.3,
  JDT_GHT_WT: 0.4,
  JDT_KUN_WT: 0.5,
  JDT_WAX_WT: 0.6,
  KR_WAX_WT: 0.7,
  JDT_KUN_TOUCH: 99,
  JDT_KUN_NET: 0.8,
  EMP_ISU: 'E1',
  LBR_CODE: 'L1',
  DESIGN_IMG_ID: 'IMG1',
  SL_TYPE: 'S',
  KR_OTH_RATE: 10,
  KR_OTH_FINE: 0.2,
  KR_TOT_FINE: 4.5,
  KR_GWT_TOUCH: 90,
  ITM_STYLE: 'ST',
  ORD_LC_CODE: '01',
  MFG_YRCD: 'MY',
  MFG_DBCD: 'MB',
  MFG_NO: 'MN',
  MFG_SRNO: 9,
  TAG_COST_EXTRA_NOT_IN_LIST: 'x',
};

describe('Tag Stock mapping (Rtl_BarData, BtmSchm.cs:2319-2640)', () => {
  it('balance-transfer.tag.columns.mapping: every column copied except the listed changes', () => {
    const out = tagCarryRow(tagSource, ctx, '00001', 1);
    const changed: Record<string, unknown> = {
      CO_YEAR: '2026-2027',
      CO_BOOK: '000',
      VCH_NO: '00001',
      SR_NO: 1,
      OLD_SRNO: 1,
      VCH_DATE: '2026-03-31',
      VCH_TIME: '2025-08-02',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      LOT_NO: '',
      APR_ISU: 'N',
      MAIN_USER: 'TESTER',
      ADD_USER: 'TESTER',
      DATA_TRFR: 'N',
      HD_VCH_NO: '00001',
      ITM_MARGIN: 0,
      KR_OTH_AMT: 0,
    };
    for (const [col, value] of Object.entries(out)) {
      const expected = col in changed ? changed[col] : (tagSource as Record<string, unknown>)[col];
      expect(value, col).toEqual(expected);
    }
    // 107 columns in the desktop list (BtmSchm.cs:2378): nothing more, nothing less.
    expect(Object.keys(out)).toHaveLength(107);
    expect(out).not.toHaveProperty('TAG_COST_EXTRA_NOT_IN_LIST');
  });

  it('balance-transfer.tag.columns.null-to-zero: NULL ITM_MARGIN, KR_OTH_AMT and TAG_COST carry 0 (Fnv, :2381)', () => {
    const out = tagCarryRow({ ...tagSource, TAG_COST: null }, ctx, '00001', 1);
    expect([out.ITM_MARGIN, out.KR_OTH_AMT, out.TAG_COST]).toEqual([0, 0, 0]);
    expect(fnv('')).toBe(0);
    expect(fnv('12.5 KG')).toBe(12.5);
  });

  it('balance-transfer.tag.children.stone-rows-follow-tag (mapping layer): ISR_NO renumbered 1.. per tag, parent voucher and SR_NO', () => {
    const stones = [{ ISR_NO: 4 }, { ISR_NO: 9 }].map((s, i) =>
      tagStoneRow({ ...s, TAG_NO: 'T010', VCH_SRNO: 1, IT_PCS: 2 }, ctx, '00001', 1, i),
    );
    expect(stones.map((s) => [s.TAG_NO, s.VCH_NO, s.SR_NO, s.ISR_NO, s.CO_BOOK])).toEqual([
      ['T010', '00001', 1, 1, '000'],
      ['T010', '00001', 1, 2, '000'],
    ]);
    expect(Object.keys(stones[0]!)).toHaveLength(51);
  });

  it('the item header is book 000 on the opening day, OP_STK Y (BtmSchm.cs:2627)', () => {
    expect(tagHeaderRow(ctx, '00002')).toEqual({
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: '2026-2027',
      CO_BOOK: '000',
      VCH_NO: '00002',
      VCH_DATE: '2026-03-31',
      AC_CODE: '',
      CUST_AC: '',
      OP_STK: 'Y',
      VCH_TIME: '2026-03-31',
    });
  });

  it('voucher numbers: 00001 up per item; they skip past the first existing book-000 voucher (:2369-2371)', () => {
    expect(tagVoucherNumbers(2, [])).toEqual(['00001', '00002']);
    // The desktop moves on only when its counter meets the first existing voucher: an existing 00007 is not
    // reached by two items (cases.md rerun.tag-counter-continues-after-other-vouchers expects 00008; see Q8 note).
    expect(tagVoucherNumbers(2, ['00007'])).toEqual(['00001', '00002']);
    expect(tagVoucherNumbers(2, ['00001', '00004'])).toEqual(['00005', '00006']);
  });
});

describe('Sales Order mapping (Rtl_Order, BtmSchm.cs:3016-3335)', () => {
  const header = {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2025-2026',
    CO_BOOK: 'SOR',
    VCH_NO: '00007',
    VCH_DATE: '2025-09-01',
    AC_CODE: '00500',
    ADV_AMT: 500,
    ORD_ADJ_AMT: 0,
    NET_AMT: 10000,
    TOT_AMT: null,
    ADJ_GOLD: 9,
  };
  it('balance-transfer.order.columns.header-mapping: own keys kept, adjusted-so-far in the adjustment columns', () => {
    const out = orderHeaderRow(
      header,
      { adjAmount: '5000.00', adjGold: 0.5, adjSilver: null },
      '01',
    );
    expect(out).toMatchObject({
      CO_YEAR: '2025-2026',
      CO_BOOK: 'SOR',
      VCH_NO: '00007',
      AC_CODE: '00500',
      ADV_AMT: 500,
      ORD_ADJ_AMT: 5000,
      ADJ_GOLD: 0.5,
      ADJ_SILVER: 0,
      NET_AMT: 10000,
      TOT_AMT: 0,
      VCH_TIME: '2025-09-01',
      ENTRY_TIME: '2025-09-01',
      SL_BILL_TYPE: '',
      OLD_VCH_NO: '',
      NEW_VCH_NO: '',
    });
    expect(Object.keys(out)).toHaveLength(53);
  });

  it('balance-transfer.order.columns.detail-mapping: copied columns, book columns and constants (:3137)', () => {
    const line = {
      CO_YEAR: '2025-2026',
      CO_BOOK: 'SOR',
      VCH_NO: '00007',
      SR_NO: 2,
      VCH_DATE: '2025-09-01',
      BOOK_SNAME: 'SORD',
      BOOK_INOUT: 'O',
      MAIN_BOOK: 'SALES ORDER',
      DESIGN_NO: 'A-VERY-LONG-DESIGN-NUMBER',
      ITM_PCS: null,
      ITM_NWT: 9.5,
      TAG_SALE: 'N',
      ITM_TOUCH: 91.6,
    };
    const out = orderLineRow(line, ctx);
    expect(out).toMatchObject({
      CO_CODE: '01',
      CO_YEAR: '2025-2026',
      CO_BOOK: 'SOR',
      VCH_NO: '00007',
      SR_NO: 2,
      OLD_SRNO: 2,
      VCH_TIME: '2025-09-01',
      VCH_TYPE: 'SORD',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'O',
      BOOK_NAME: 'SALES ORDER',
      DESIGN_NO: 'A-VERY-LONG-DES',
      ITM_PCS: 0,
      ITM_NWT: 9.5,
      ITM_TOUCH: 0,
      ITM_FINE: 0,
      KR_NAME: '',
      RATE_TYPE: '',
      IT_TYPE: '',
      HD_VCH_NO: '00007',
      DATA_TRFR: 'N',
      TAG_SALE: 'N',
    });
    expect(Object.keys(out)).toHaveLength(77);
  });

  it('balance-transfer.order.children.lines-and-stones (mapping layer): each line keeps its order key and SR_NO', () => {
    const lines = [
      { VCH_NO: '00001', SR_NO: 1 },
      { VCH_NO: '00001', SR_NO: 2 },
      { VCH_NO: '00004', SR_NO: 1 },
    ].map((l) => orderLineRow({ ...l, CO_YEAR: '2025-2026', CO_BOOK: 'SOR' }, ctx));
    expect(lines.map((l) => [l.CO_YEAR, l.VCH_NO, l.SR_NO, l.HD_VCH_NO])).toEqual([
      ['2025-2026', '00001', 1, '00001'],
      ['2025-2026', '00001', 2, '00001'],
      ['2025-2026', '00004', 1, '00004'],
    ]);
  });
});

describe('Approval mapping (Rtl_Approval, BtmSchm.cs:4135-4650)', () => {
  const line = {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2025-2026',
    CO_BOOK: 'AIS',
    VCH_NO: '00003',
    SR_NO: 1,
    OLD_SRNO: 1,
    TAG_NO: 'T030',
    ITM_PCS: null,
    ITM_GWT: 6,
    ITM_NWT: 5.5,
    ISU_REC: 'N',
    IGNORED_COLUMN: 'x',
  };
  it('balance-transfer.approval.columns.apr-detl-mapping: a verbatim copy, ORNA_REC_DATE NULL (:4154)', () => {
    const out = approvalLineRow(line);
    expect(out).toMatchObject({
      CO_YEAR: '2025-2026',
      CO_BOOK: 'AIS',
      VCH_NO: '00003',
      SR_NO: 1,
      OLD_SRNO: 1,
      TAG_NO: 'T030',
      ITM_PCS: 0,
      ITM_GWT: 6,
      ISU_REC: 'N',
      ORNA_REC_DATE: null,
    });
    expect(Object.keys(out)).toHaveLength(76);
    expect(out).not.toHaveProperty('IGNORED_COLUMN');
  });

  it('balance-transfer.approval.children.stones-follow-line: stone rows keep their line key and ISR_NO (:4291)', () => {
    const stones = [1, 2].map((isr) =>
      approvalStoneRow(
        { CO_YEAR: '2025-2026', CO_BOOK: 'AIS', VCH_NO: '00003', SR_NO: 1, ISR_NO: isr },
        ctx,
      ),
    );
    expect(stones.map((s) => [s.VCH_NO, s.SR_NO, s.ISR_NO])).toEqual([
      ['00003', 1, 1],
      ['00003', 1, 2],
    ]);
    expect(Object.keys(stones[0]!)).toHaveLength(46);
  });

  it('balance-transfer.approval.columns.tag-line-book-218: book 218, voucher 00001, APRTG / APR TAG, the opening day', () => {
    const out = approvalTagRow({ ...tagSource, TAG_NO: 'T030' }, ctx, 0);
    expect(out).toMatchObject({
      CO_YEAR: '2026-2027',
      CO_BOOK: '218',
      VCH_NO: '00001',
      SR_NO: 0,
      OLD_SRNO: 0,
      VCH_DATE: '2026-03-31',
      VCH_TYPE: 'APRTG',
      BOOK_NAME: 'APR TAG',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      TAG_NO: 'T030',
      ITM_OTH_WT: 5 - 4.8,
      TAG_SRNO: 1,
      APR_ISU: 'Y',
      ORD_NO: '',
      ORD_SRNO: 0,
      HD_VCH_NO: '00099',
      ITM_FINE: 4.397,
    });
    expect(Object.keys(out)).toHaveLength(96);
  });
});
