import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';
import {
  WHOLESALE_WORKFLOWS,
  blankLine,
  blankVoucher,
  editLine,
  fineRateCaption,
  isActiveLine,
  lineFromTag,
  lineWithItem,
  linePayload,
  previewVoucher,
  todayLocal,
  voucherFromSaved,
  voucherPayload,
  wholesaleSettings,
  type VoucherLine,
  type VoucherState,
} from '../lib/wholesaleVoucher';

/**
 * The shared TR_WH_SALE form (Wholesale Sale and Rate Cut). Expected figures are the desktop's, evaluated by hand
 * from TR_WH_SALE.cs and matched to the rows the API test replays (apps/api/test/wholesaleRateCutStock.db.test.ts:
 * the MKG00001 tag case, V2 034/5 and V3 034/6) — so the screen preview and the posted voucher are pinned to the
 * same numbers from two sides.
 */
const desktop = wholesaleSettings(null);

/** Rows as `/lookup/available-tags` returns them for the API test's fixtures. */
const tagRow = (overrides: Record<string, unknown>) => ({
  ambiguous: false,
  ITM_PCS: 1,
  ITM_OTH_WT: 0,
  ITM_GHT_PRC: 0,
  TBL_CODE: '001',
  DESIGN_NO: null,
  ITM_SIZE: '',
  LBR_TYPE: '',
  LBR_RATE: 0,
  LBR_AMT: 0,
  OTH_AMT: 0,
  ITM_RATE: 0,
  ITM_MRP: 0,
  KR_COST: 0,
  HM_ID: '',
  HM_ID_WT: 0,
  RATE_TYPE: 'G',
  IT_TYPE: 'G',
  source: 'BAR_DETL',
  ...overrides,
});
const MKG00001 = tagRow({
  code: 'MKG00001',
  name: 'LR916 · L RING 916',
  TAG_NO: 'MKG00001',
  VCH_SRNO: 100312000077,
  IT_CODE: 'LR916',
  IT_NAME: 'L RING 916',
  ITM_GWT: 10,
  ITM_NWT: 10,
  ITM_TOUCH: 92,
  ITM_WEST_PRC: 0,
  ITM_FINE: 9.5,
  KR_NAME: 'KJ',
  PR_CODE: 'LR',
  LBR_TYPE: 'N',
  LBR_RATE: 150,
  OTH_AMT: 300,
  ITM_MRP: 25000,
  KR_COST: 18000,
});
const CHG00002 = tagRow({
  code: 'CHG00002',
  VCH_SRNO: 100312000004,
  IT_CODE: 'CH916',
  IT_NAME: 'CHAIN 916',
  ITM_GWT: 12,
  ITM_NWT: 12,
  ITM_TOUCH: 92,
  ITM_WEST_PRC: 4,
  ITM_FINE: 11.52,
  ITM_SIZE: '3',
  KR_NAME: 'SJ',
  PR_CODE: 'CH',
  HM_ID: 'UY76UY',
  HM_ID_WT: 12,
});
const CHG00003 = tagRow({
  code: 'CHG00003',
  VCH_SRNO: 100312000005,
  IT_CODE: 'CH916',
  IT_NAME: 'CHAIN 916',
  ITM_GWT: 14,
  ITM_NWT: 14,
  ITM_TOUCH: 92,
  ITM_WEST_PRC: 4,
  ITM_FINE: 13.44,
  ITM_SIZE: '3',
  KR_NAME: 'KJ',
  PR_CODE: 'CH',
});

/** Type cells into a line the way the grid does, cascades included. */
const typed = (cells: Partial<Record<keyof VoucherLine, string>>, line = blankLine()) =>
  Object.entries(cells).reduce(
    (current, [field, value]) => editLine(current, field as never, value as string),
    line,
  );
const withLines = (issued: VoucherLine[], received: VoucherLine[] = []): VoucherState => ({
  ...blankVoucher('2023-06-01'),
  issued: [...issued, blankLine()],
  received: [...received, blankLine()],
});

describe('workflows: one TR_WH_SALE form, two book scopes', () => {
  it('posts each page to its own resource and offers only its own MAIN_BOOK', () => {
    expect(WHOLESALE_WORKFLOWS['wholesale-sale']).toMatchObject({
      endpoint: '/wholesale-sales',
      mainBook: 'WH SALES',
    });
    expect(WHOLESALE_WORKFLOWS['rate-cut']).toMatchObject({
      endpoint: '/rate-cut',
      mainBook: 'RATE CUT',
    });
  });

  it('mounts the shared form on both pages', () => {
    const page = (name: string) =>
      readFileSync(join(__dirname, '..', 'app', '(app)', 'txn', name, 'page.tsx'), 'utf8');
    expect(page('wholesale-sale')).toContain('<WholesaleVoucherForm workflow="wholesale-sale" />');
    expect(page('rate-cut')).toContain('<WholesaleVoucherForm workflow="rate-cut" />');
    const form = readFileSync(
      join(__dirname, '..', 'components', 'WholesaleVoucherForm.tsx'),
      'utf8',
    );
    // The book picker is scoped by MAIN_BOOK, with no hard-coded book code.
    expect(form).toContain('mainBooks={[cfg.mainBook]}');
    expect(form).not.toContain('preferred=');
    // Tags come from the availability-filtered picker, not the every-row `tags` master.
    expect(form).toContain('entity="available-tags"');
  });

  it('reads the company settings with the desktop blank defaults', () => {
    expect(desktop).toEqual({
      line: { labourIncludesGhat: true, companyLabourType: 'G' },
      ratePar: 'G',
    });
    const configured = wholesaleSettings({
      'CO_SET.LBR_TYPE': 'n',
      'CO_SET_NEW.LBR_WITH_GHT': 'N',
      'CO_SET.RATE_PAR': 'T',
    });
    expect(configured).toEqual({
      line: { labourIncludesGhat: false, companyLabourType: 'N' },
      ratePar: 'T',
    });
    expect([fineRateCaption('G'), fineRateCaption('T'), fineRateCaption('K')]).toEqual([
      '1gm Rate',
      '10gm Rate',
      'Kg Rate',
    ]);
  });

  it('dates a new voucher by the local calendar day', () => {
    expect(todayLocal(new Date(2026, 8, 29, 0, 30))).toBe('2026-09-29');
  });
});

describe('grid cells follow the desktop cascades', () => {
  it('derives net from gross − other, and ghat % and ghat weight replace each other', () => {
    const line = typed({ grossWt: '10.5', othWt: '0.5' });
    expect(line.netWt).toBe('10');
    expect(typed({ ghtWt: '0.8' }, typed({ ghtPct: '5' }, line))).toMatchObject({
      ghtPct: '',
      ghtWt: '0.8',
    });
    expect(typed({ ghtPct: '5' }, typed({ ghtWt: '0.8' }, line))).toMatchObject({
      ghtPct: '5',
      ghtWt: '',
    });
  });

  it('starts a picked line afresh when its tag number is retyped', () => {
    const picked = lineFromTag(MKG00001);
    const retyped = editLine(picked, 'tagNo', 'MKG0000');
    expect(retyped).toEqual({ ...blankLine(), tagNo: 'MKG0000' });
  });

  it('an item pick brings its name and rate type', () => {
    const line = lineWithItem(blankLine(), { code: 'LR916', name: 'L RING 916', RATE_TYPE: '1' });
    expect(line).toMatchObject({ itCode: 'LR916', itemName: 'L RING 916', rateType: '1' });
  });
});

describe('payload: what the screen sends is what it shows', () => {
  it('a loose row omits blank cells and leaves the labour basis to the company', () => {
    const line = typed({ itCode: 'LR916', netWt: '10', touch: '91.6', rate: '6000' });
    expect(linePayload(line, 'issue')).toEqual({
      itCode: 'LR916',
      netWt: 10,
      touch: 91.6,
      rate: 6000,
    });
    expect(isActiveLine(blankLine())).toBe(false);
  });

  it('a picked tag sends its instance, its stored fine and every figure, blanks as 0', () => {
    const payload = linePayload(lineFromTag(MKG00001), 'issue');
    expect(payload).toMatchObject({
      tagNo: 'MKG00001',
      vchSrno: 100312000077,
      itCode: 'LR916',
      grossWt: 10,
      netWt: 10,
      touch: 92,
      westPct: 0,
      ghtPct: 0,
      fine: 9.5,
      lbrType: 'N',
      lbrRate: 150,
      lbrAmt: 0,
      othAmt: 300,
      mrp: 25000,
      tagCost: 18000,
      rateType: 'G',
      karigarName: 'KJ',
      prCode: 'LR',
    });
  });

  it('a tag with a blank labour basis keeps it blank (Next23 034/4 saves "")', () => {
    expect(linePayload(lineFromTag(CHG00002), 'issue').lbrType).toBe('');
    expect(lineFromTag(tagRow({ code: 'X1', LBR_TYPE: 'Z' })).lbrTypeFromCompany).toBe(true);
  });

  it('drops the stored fine once weight or purity is edited, so the formula decides', () => {
    const edited = editLine(lineFromTag(CHG00002), 'grossWt', '12.5');
    const payload = linePayload(edited, 'issue');
    expect(payload.fine).toBeUndefined();
    expect(payload.netWt).toBe(12.5);
    // (12.5 + 0) × (92 + 4) / 100 = 12.000 (TR_WH_SALE.cs:9436-9660).
    expect(previewVoucher(withLines([edited]), desktop).issued.lines[0]?.fine).toBe(12);
  });

  it('labels the band as the desktop does: Received is SL_* (pay), Payment is PR_* (receivedPay)', () => {
    const state: VoucherState = {
      ...withLines([typed({ itCode: 'LR916', netWt: '10', touch: '91.6', rate: '6000' })]),
      receivedTender: { cheque: '1000', card: '', cash: '3517', kasar: '0.25' },
      paymentTender: { cheque: '', card: '', cash: '100', kasar: '' },
      bankAc: '00012',
      chqNo: '445566',
      cardAc: '',
    };
    const body = voucherPayload(state, { coBook: '034', coYear: '2023-2024', lcCode: '00' });
    expect(body.pay).toEqual({
      cash: 3517,
      chq: 1000,
      card: undefined,
      kasar: 0.25,
      bankAc: '00012',
      chqNo: '445566',
      cardAc: undefined,
    });
    expect(body.receivedPay).toEqual({
      cash: 100,
      chq: undefined,
      card: undefined,
      kasar: undefined,
    });
    // Only rows that carry something are sent; the grid's spare rows are not.
    expect(body.lines).toHaveLength(1);
    expect(body.receivedLines).toHaveLength(0);
  });
});

describe('preview: the API test’s desktop figures, reproduced on screen', () => {
  it('MKG00001 + a priced loose line: 9.500 to the party, Received net 56760', () => {
    const state = withLines([
      lineFromTag(MKG00001),
      typed({ itCode: 'LR916', netWt: '10', touch: '91.6', rate: '6000' }),
    ]);
    const { issued, band } = previewVoucher(state, desktop);
    // Stored fine 9.500 kept; net-wise labour with ghat Math.Round((10 + 0) × 150) = 1500; net 1500 + 300 + 0.
    expect(issued.lines[0]).toMatchObject({ fine: 9.5, labourAmount: 1500, netAmount: 1800 });
    // 10 × 91.6 % = 9.160 at 6000: Math.Round(54960) = 54960, sold for money.
    expect(issued.lines[1]).toMatchObject({ fine: 9.16, itemAmount: 54960, netAmount: 54960 });
    // SL_FINE counts only the unpriced line (:8344-8346); both leave stock.
    expect(issued.totals).toMatchObject({ fine: 9.5, handledFine: 18.66, netAmount: 56760 });
    expect(band).toMatchObject({ receivedNet: 56760, receivedOs: 56760, totFineDr: 9.5 });
  });

  it('V2 034/5: 24.000 received and 0.541 cut at 6500 derive Ac Amt Dr 3517, settled in cash', () => {
    const state: VoucherState = {
      ...withLines([], [typed({ itCode: '999', grossWt: '24', touch: '100' })]),
      receivedTender: { cheque: '', card: '', cash: '3517', kasar: '' },
    };
    state.header = { ...state.header, fineRate: '6500', settleCrFine: '0.541' };
    const { settlement, band, received } = previewVoucher(state, desktop);
    // Math.Round(0.541 × (6500 / 1)) = Math.Round(3516.5000000000005) = 3517 (TR_WH_SALE.cs:15420-15440).
    expect(settlement).toMatchObject({ fineRate: 6500, drAmt: 3517, crFine: 0.541 });
    expect(received.totals.fine).toBe(24);
    expect(band).toMatchObject({
      receivedNet: 3517,
      receivedOs: 0,
      totFineDr: 0,
      totFineCr: 24.541,
      osFine: -24.541,
    });
  });

  it('V3 034/6: two tags and 20.000 received, 4.960 cut at 6500: Tot fine Dr = Cr = 24.960', () => {
    const state = withLines(
      [lineFromTag(CHG00002), lineFromTag(CHG00003)],
      [typed({ itCode: '999', grossWt: '20', touch: '100' })],
    );
    state.header = { ...state.header, fineRate: '6500', settleCrFine: '4.96' };
    const { issued, settlement, band } = previewVoucher(state, desktop);
    expect(issued.lines.slice(0, 2).map((line) => line?.fine)).toEqual([11.52, 13.44]);
    expect(settlement.drAmt).toBe(32240);
    expect(band).toMatchObject({
      receivedNet: 32240,
      totFineDr: 24.96,
      totFineCr: 24.96,
      osFine: 0,
      diffAmount: 32240,
      diffSide: 'Rec',
    });
  });

  it('a new row takes the company labour basis, as the server applies it', () => {
    const line = typed({
      itCode: 'LR916',
      grossWt: '10.5',
      othWt: '0.5',
      touch: '91.6',
      lbrRate: '100',
    });
    expect(linePayload(line, 'issue').lbrType).toBeUndefined();
    const net = wholesaleSettings({ 'CO_SET.LBR_TYPE': 'N' });
    // Net-wise Math.Round(10 × 100) = 1000; the default gross-wise basis gives 10.5 × 100 = 1050.
    expect(previewVoucher(withLines([line]), net).issued.lines[0]?.labourAmount).toBe(1000);
    expect(previewVoucher(withLines([line]), desktop).issued.lines[0]?.labourAmount).toBe(1050);
  });
});

describe('reopen: a saved voucher comes back exactly as stored', () => {
  const saved = {
    voucherNo: '00001',
    vchDate: '2023-06-01',
    acCode: '000209',
    acName: 'SS',
    mobile: '9856525',
    itType: 'G',
    fineRate: 6500,
    convRate: 0,
    convPct: 0,
    settleDrAmt: 3517,
    settleCrAmt: 0,
    settleDrFine: 0,
    settleCrFine: 0.541,
    pay: { cash: 3517, chq: 0, card: 0, kasar: 0, billOs: 0, bankAc: '', chqNo: '', cardAc: '' },
    receivedPay: { cash: 0, chq: 0, card: 0, kasar: 0, billOs: 0 },
    lines: [
      {
        srNo: 1,
        vchSrno: 100312000004,
        tagNo: 'CHG00002',
        itCode: 'CH916',
        itemName: 'CHAIN 916',
        grossWt: 12,
        netWt: 12,
        ghtWt: 0,
        touch: 92,
        westPct: 4,
        fine: 11.52,
        lbrType: '',
        rateType: 'G',
        itemSize: '3',
        hallmarkId: 'UY76UY',
        hallmarkIdWt: 12,
        isuRef: { yrcd: '', dbcd: '', no: '', srno: 0 },
      },
    ],
    receivedLines: [
      {
        srNo: 1,
        vchSrno: 0,
        tagNo: 'N',
        itCode: '999',
        itemName: '999 GOLD',
        grossWt: 24,
        netWt: 24,
        ghtWt: 0.8,
        touch: 100,
        fine: 24.8,
        lbrType: 'G',
        rateType: 'G',
      },
    ],
  };

  it('fills header, band and rows, with a spare row under each grid', () => {
    const state = voucherFromSaved(saved);
    expect(state.header).toMatchObject({
      acCode: '000209',
      mobile: '9856525',
      fineRate: '6500',
      settleDrAmt: '3517',
      settleCrFine: '0.541',
    });
    expect(state.receivedTender.cash).toBe('3517');
    expect(state.issued).toHaveLength(2);
    expect(state.received).toHaveLength(2);
    expect(state.received[0]!.tagNo).toBe('');
  });

  it('re-sends the stored figures unchanged: fine, typed ghat weight, tag instance and settlement', () => {
    const body = voucherPayload(voucherFromSaved(saved), { coBook: '034' });
    expect(body).toMatchObject({ fineRate: 6500, settleDrAmt: 3517, settleCrFine: 0.541 });
    const [issued] = body.lines as Record<string, unknown>[];
    expect(issued).toMatchObject({
      tagNo: 'CHG00002',
      vchSrno: 100312000004,
      fine: 11.52,
      lbrType: '',
    });
    const [received] = body.receivedLines as Record<string, unknown>[];
    expect(received).toMatchObject({ itCode: '999', ghtWt: 0.8, fine: 24.8, lbrType: 'G' });
    expect(received).not.toHaveProperty('tagNo');
    const { band } = previewVoucher(voucherFromSaved(saved), desktop);
    expect(band).toMatchObject({ receivedNet: 3517, receivedOs: 0, totFineDr: 11.52 });
  });
});
