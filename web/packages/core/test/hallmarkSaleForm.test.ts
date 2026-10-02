import { describe, expect, it } from 'vitest';
import {
  blankHallmarkLine,
  changedLineFields,
  hallmarkHeaderFromView,
  hallmarkLineCommand,
  hallmarkLineFromView,
  hallmarkOldGold,
  hallmarkOldGoldFromView,
  hallmarkSaleCommand,
  type HallmarkLine,
  type LoadedHallmarkSale,
} from '../src/hallmarkSaleForm.js';

/**
 * N40 / G45: a reopened hallmark sale saved unchanged must send back exactly what `GET /sales/:vchNo`
 * returned. Every value is distinct, so a mapping that crosses two fields cannot pass by coincidence.
 */
const viewLine = (): Record<string, unknown> => ({
  srNo: 1,
  itCode: 'HMGOLD',
  metal: 'G',
  tagNo: 'HT0001',
  vchSrno: 7,
  pcs: 2,
  grossWt: 10.511,
  netWt: 9.822,
  touch: 91.6,
  ghtWt: 0.133,
  westPct: 1.25,
  fineWt: 9.218,
  rate: 6123,
  metalAmount: 56443,
  labourType: 'per_gram',
  labourPct: 0,
  labourRate: 455,
  labourFixed: 4529,
  otherAmount: 117,
  netAmount: 61089,
  designNo: 'DSN-41',
  itmSize: '18',
  lessWt: 0.689,
  tblCode: 'C2',
  mrp: 71234,
  huid: 'HUID01',
  ordNo: '00031',
  ordYrcd: '2024-2025',
  ordDbcd: 'ORD',
  ordSrno: 3,
  isuNo: '00045',
  isuYrcd: '2023-2024',
  isuDbcd: 'ISU',
  isuSrno: 4,
  bagWt: 0.051,
  tagGrossWt: 10.611,
  tagNetWt: 9.922,
  ghtPct: 1.35,
  style: 'Antique',
  itemLot: 'LOT-9',
  remark: 'Bridal set',
  discountPct: 2.5,
  discountAmount: 311,
  ghatAmount: 823,
  rateWith: 'F',
  rateType: 'G',
  tagCost: 50211,
  karigarNetWt: 9.701,
  karigarTouch: 92.1,
  karigarWestPct: 0.75,
  karigarFine: 9.007,
  karigarName: 'KR-RAJ',
  employeeCode: 'E07',
  prCode: 'PR-77',
  orderTagStockAdd: 'Y',
  designImageId: 'IMG-5',
  hallmarkId2: 'HUID02',
  hallmarkId3: 'HUID03',
  hallmarkId4: 'HUID04',
  hallmarkIdWt: 2.101,
  hallmarkId2Wt: 2.202,
  hallmarkId3Wt: 2.303,
  hallmarkId4Wt: 2.404,
});

const view = (): Record<string, unknown> => ({
  voucherNo: '00012',
  hiddenVoucherNo: '00099',
  mainUser: 'clerk',
  vchDate: '2024-06-15',
  billNo: 'B-881',
  acCode: 'CUST07',
  acName: 'Asha Jewellers',
  taxCode: 'G3',
  taxRatePct: 3,
  interState: false,
  discountAmount: 150,
  discountPct: 0.5,
  rateUnfix: false,
  cashAmt: 20000,
  cardAmt: 15000,
  upiAmt: 9000,
  chequeAmt: 7000,
  hallmarkAmount: 245,
  hallmarkTaxAmount: 7.35,
  tcsPct: 0.1,
  tcsAmount: 61,
  tcsCode: 'TCS1',
  tdsCode: 'TDS2',
  tdsPct: 0.2,
  tdsAmount: 33,
  kasarAmount: 4,
  oldGoldAmount: 25821.6,
  billOutstanding: 999,
  crDays: 15,
  empCode: 'E09',
  description: 'Wedding order',
  address1: 'Line 1',
  address2: 'Line 2',
  address3: 'Line 3',
  city: 'Surat',
  mobile: '9800000000',
  bankAc: 'HDFC01',
  cardAc: 'CARD01',
  chequeNo: 'CHQ-5521',
  bankName: 'HDFC',
  cardCommissionAmount: 18,
  cashPaid: 21000,
  currentAdjustmentAmount: 12,
  schemeAc: 'SCH01',
  schemeAmount: 500,
  pointValue: 40,
  issueNo: '00003',
  issueYear: '2024-2025',
  issueBook: 'APR',
  ornamentIssued: true,
  orderRef: { ordNo: '00031', adjustAmt: 1000 },
  totals: { net: 1, total: 2 },
  lines: [viewLine()],
  oldGold: [
    {
      metal: 'G',
      itCode: 'OG',
      description: 'Old chain',
      pcs: 1,
      grossWt: 5.5,
      otherWt: 0.2,
      netWt: 5.3,
      touch: 84,
      fineWt: 4.452,
      conversionPct: 0,
      conversionWt: 0,
      rate: 5800,
      rateType: 'G',
      amount: 25810,
    },
  ],
});

const scope = { coBook: 'HSL', coYear: '2024-2025', lcCode: '01' };

function loadedEditor(v: Record<string, unknown>) {
  const header = hallmarkHeaderFromView(v);
  const oldGold = hallmarkOldGoldFromView(v);
  const loaded: LoadedHallmarkSale = { view: v, header, oldGold };
  const lines = ((v.lines as Array<Record<string, unknown>>) ?? []).map(hallmarkLineFromView);
  return { header, oldGold, loaded, lines };
}

/** The request line for an unchanged loaded line: the view line minus its read-only fields. */
const expectedLine = (line: Record<string, unknown>) => {
  const { srNo: _srNo, netAmount: _netAmount, ...rest } = line;
  return rest;
};

describe('hallmark sale lossless reopen (G45)', () => {
  it('an unchanged save sends back every loaded header, line and old-metal value exactly', () => {
    const v = view();
    const { header, oldGold, loaded, lines } = loadedEditor(v);
    const command = hallmarkSaleCommand({ scope, header, oldGold, lines, loaded });
    const {
      voucherNo: _voucherNo,
      hiddenVoucherNo: _hidden,
      mainUser: _mainUser,
      hallmarkTaxAmount: _hmTax,
      oldGoldAmount: _ogAmount,
      billOutstanding: _billOs,
      totals: _totals,
      lines: viewLines,
      // Resolved from the tax rate on save, never passed back (see VIEW_HEADER_PASSTHROUGH).
      taxCode: _taxCode,
      ...headerPassthrough
    } = v;
    const { oldGold: viewOldGold, ...headerFields } = headerPassthrough as Record<string, unknown>;
    expect(command).toEqual({
      ...scope,
      ...headerFields,
      // The one gold row carries the stored header total (25821.6), not its detail valuation (25810),
      // so the header and ledger are posted exactly as before (G83).
      oldGold: (viewOldGold as Array<Record<string, unknown>>).map((row) => ({
        ...row,
        amount: 25821.6,
      })),
      lines: (viewLines as Array<Record<string, unknown>>).map(expectedLine),
    });
    // The fields the old screen dropped are all present.
    const [line] = command.lines as Array<Record<string, unknown>>;
    expect(line).toMatchObject({
      hallmarkId2: 'HUID02',
      hallmarkId3: 'HUID03',
      hallmarkId4: 'HUID04',
      hallmarkId4Wt: 2.404,
      ordNo: '00031',
      isuDbcd: 'ISU',
      discountAmount: 311,
      vchSrno: 7,
      remark: 'Bridal set',
    });
    expect(command.vchDate).toBe('2024-06-15');
    expect(command.empCode).toBe('E09');
  });

  it('an edited input overlays only that field and lets the server derive fine and metal again', () => {
    const { header, oldGold, loaded, lines } = loadedEditor(view());
    const edited: HallmarkLine[] = lines.map((line) => ({ ...line, netWt: '9.9' }));
    expect(changedLineFields(edited[0]!)).toEqual(['netWt']);
    const [line] = hallmarkSaleCommand({ scope, header, oldGold, lines: edited, loaded })
      .lines as Array<Record<string, unknown>>;
    const { fineWt: _fine, metalAmount: _metal, ...preserved } = expectedLine(viewLine());
    expect(line).toEqual({ ...preserved, netWt: 9.9 });
  });

  it('a typed fine weight on an edited line is kept as the operator override', () => {
    const { lines } = loadedEditor(view());
    const line = { ...lines[0]!, netWt: '9.9', fineWt: '9.5' };
    expect(hallmarkLineCommand(line)).toMatchObject({ netWt: 9.9, fineWt: 9.5 });
    expect(hallmarkLineCommand(line)).not.toHaveProperty('metalAmount');
  });

  it('a cleared field is omitted, so the server stores its default', () => {
    const { lines } = loadedEditor(view());
    const command = hallmarkLineCommand({ ...lines[0]!, hallmarkId3: '', remark: '' });
    expect(command).not.toHaveProperty('hallmarkId3');
    expect(command).not.toHaveProperty('remark');
    expect(command).toMatchObject({ hallmarkId2: 'HUID02', hallmarkId4: 'HUID04', fineWt: 9.218 });
  });

  it('a changed per-gram making rate replaces the loaded labour rate only', () => {
    const { lines } = loadedEditor(view());
    expect(lines[0]!.making).toBe('455');
    const command = hallmarkLineCommand({ ...lines[0]!, making: '500' });
    expect(command).toMatchObject({ labourType: 'per_gram', labourRate: 500, fineWt: 9.218 });
  });

  it('a header edit changes only that header field', () => {
    const v = view();
    const { header, oldGold, loaded, lines } = loadedEditor(v);
    const command = hallmarkSaleCommand({
      scope,
      header: { ...header, cashAmt: '25000' },
      oldGold,
      lines,
      loaded,
    });
    const unchanged = hallmarkSaleCommand({ scope, header, oldGold, lines, loaded });
    expect(command).toEqual({ ...unchanged, cashAmt: 25000 });
  });

  it('previews the old-metal amount the writer stores, not net x touch x rate to the paisa (G83)', () => {
    // 5.3 g at 84 touch: fine 4.452 (three decimals, TR_SALE.cs:7905), Math.Round(4.452 x 5800, 0) = 25822.
    // The screen used to show 25821.60.
    expect(hallmarkOldGold.value('5.3', '84', '5800')).toBe(25822);
    expect(hallmarkOldGold.value('6', '84', '5800')).toBe(29232);
    expect(hallmarkOldGold.value('', '', '')).toBe(0);
    // The same helper object reads a loaded row.
    expect(hallmarkOldGold.fromView(view())).toEqual(hallmarkOldGoldFromView(view()));
  });

  it('an edited old-metal row keeps its other loaded fields and recomputes its amount', () => {
    const { header, oldGold, loaded, lines } = loadedEditor(view());
    const command = hallmarkSaleCommand({
      scope,
      header,
      oldGold: { ...oldGold, netWt: '6' },
      lines,
      loaded,
    });
    expect(command.oldGold).toEqual([
      expect.objectContaining({
        itCode: 'OG',
        description: 'Old chain',
        grossWt: 5.5,
        netWt: 6,
        touch: 84,
        rate: 5800,
        amount: 29232,
      }),
    ]);
  });

  it('a new voucher is built from the editor alone, exactly as before', () => {
    const line: HallmarkLine = {
      ...blankHallmarkLine(),
      itCode: 'GOLD',
      netWt: '5',
      touch: '91.6',
      rate: '6000',
      making: '400',
      hallmarkId2: 'H2',
      fineWt: '',
    };
    const command = hallmarkSaleCommand({
      scope,
      header: {
        acCode: 'WALKIN',
        acName: '',
        taxRatePct: '3',
        discountAmount: '',
        interState: false,
        hallmarkAmount: '45',
        cashAmt: '1000',
        cardAmt: '',
        upiAmt: '',
        chequeAmt: '',
      },
      oldGold: { netWt: '', touch: '', rate: '' },
      lines: [line, blankHallmarkLine()],
    });
    expect(command).toEqual({
      ...scope,
      acCode: 'WALKIN',
      acName: undefined,
      taxRatePct: 3,
      interState: false,
      discountAmount: undefined,
      hallmarkAmount: 45,
      cashAmt: 1000,
      cardAmt: undefined,
      upiAmt: undefined,
      chequeAmt: undefined,
      oldGold: undefined,
      lines: [
        {
          itCode: 'GOLD',
          tagNo: undefined,
          pcs: 1,
          grossWt: 0,
          netWt: 5,
          touch: 91.6,
          rate: 6000,
          huid: undefined,
          labourType: 'per_gram',
          labourRate: 400,
          hallmarkId2: 'H2',
        },
      ],
    });
  });
});
