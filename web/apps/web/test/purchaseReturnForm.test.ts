import { describe, expect, it } from 'vitest';
import {
  blank,
  changedLineFields,
  lineCommand,
  lineFromPurchase,
  lineFromView,
  linePreview,
  setLineCell,
  updateLine,
} from '../lib/purchaseReturnForm';

/**
 * A line of `GET /purchase-returns/:vchNo` for a per-gram tagged line and an untagged line with the return-only
 * columns. Values follow the desktop rules: fine = (net + ghat) x touch / 100 = 5 x 80 / 100 = 4, metal =
 * 4 x 1500 = 6000, per-gram labour = 5 x 40 = 200, net = 6200 (+ other 0).
 */
const taggedView = {
  srNo: 1,
  itCode: 'GOLD',
  metal: 'G',
  tagNo: 'TGR1',
  vchSrno: 1,
  pcs: 1,
  grossWt: 5.2,
  netWt: 5,
  touch: 80,
  ghtWt: 0,
  westPct: 0,
  fineWt: 4,
  otherFineWt: 0,
  silverFineWt: 0,
  rate: 1500,
  metalAmount: 6000,
  labourType: 'per_gram',
  labourPct: 0,
  labourRate: 40,
  labourFixed: 200,
  labourAmount: 200,
  otherAmount: 0,
  netAmount: 6200,
  huid: '',
  designNo: '',
  tblCode: '',
  rateType: 'F',
  stones: [],
};
const untaggedView = {
  srNo: 2,
  itCode: 'GOLD',
  metal: '',
  tagNo: '',
  vchSrno: 0,
  pcs: 2,
  grossWt: 2.5,
  netWt: 2.5,
  touch: 80,
  fineWt: 2,
  rate: 1900,
  metalAmount: 3800,
  labourAmount: 0,
  otherAmount: 25,
  netAmount: 3825,
  lotNo: 'LT1',
  commissionAmount: 12.5,
  prCode: 'PC',
  stones: [],
};

describe('purchase return form: reopen and save', () => {
  it('sends an unchanged loaded line back as loaded, without read-only or blank fields', () => {
    const line = lineFromView(taggedView);
    expect(changedLineFields(line)).toEqual([]);
    const {
      srNo: _sr,
      netAmount: _net,
      stones: _stones,
      huid: _h,
      designNo: _d,
      tblCode: _t,
      ...kept
    } = taggedView;
    expect(lineCommand(line)).toEqual(kept);
  });

  it('keeps the fields the grid never shows (metal code, rate type, other amount, return columns)', () => {
    const command = lineCommand(lineFromView(untaggedView));
    expect(command).toMatchObject({
      otherAmount: 25,
      lotNo: 'LT1',
      commissionAmount: 12.5,
      prCode: 'PC',
      fineWt: 2,
      metalAmount: 3800,
    });
    // A blank tag is omitted so the writer stores the desktop "N"; a blank metal code stays blank.
    expect(command).not.toHaveProperty('tagNo');
    expect(command).not.toHaveProperty('metal');
  });

  it('a changed net weight drops the loaded fine, metal and per-gram labour so the server derives them', () => {
    const line = setLineCell(lineFromView(taggedView), 'netWt', '6');
    expect(line.fineWt).toBe('');
    expect(line.metalAmount).toBe('');
    const command = lineCommand(line);
    expect(command.netWt).toBe(6);
    expect(command).not.toHaveProperty('fineWt');
    expect(command).not.toHaveProperty('metalAmount');
    expect(command).not.toHaveProperty('labourAmount');
    expect(command).toMatchObject({ labourType: 'per_gram', labourRate: 40, tagNo: 'TGR1' });
    // 6 x 80 / 100 = 4.8 fine, x 1500 = 7200 metal, 6 x 40 = 240 labour.
    expect(linePreview(line, true)).toEqual({ fine: 4.8, metal: 7200, labour: 240, net: 7440 });
  });

  it('a changed rate drops only the metal amount', () => {
    const line = setLineCell(lineFromView(taggedView), 'rate', '1600');
    expect(line.fineWt).toBe('4');
    expect(line.metalAmount).toBe('');
    const command = lineCommand(line);
    expect(command).toMatchObject({ rate: 1600, fineWt: 4, labourAmount: 200 });
    expect(command).not.toHaveProperty('metalAmount');
    expect(linePreview(line, true)).toEqual({ fine: 4, metal: 6400, labour: 200, net: 6600 });
  });

  it('a typed fine override is sent and re-derives the metal amount', () => {
    const line = setLineCell(lineFromView(taggedView), 'fineWt', '4.5');
    const command = lineCommand(line);
    expect(command.fineWt).toBe(4.5);
    expect(command).not.toHaveProperty('metalAmount');
    expect(linePreview(line, true).metal).toBe(6750);
  });

  it('clearing the making rate removes per-gram labour, changing it re-derives labour', () => {
    const cleared = lineCommand(setLineCell(lineFromView(taggedView), 'making', ''));
    expect(cleared).not.toHaveProperty('labourType');
    expect(cleared).not.toHaveProperty('labourRate');
    expect(cleared).not.toHaveProperty('labourAmount');
    const changed = lineCommand(setLineCell(lineFromView(taggedView), 'making', '50'));
    expect(changed).toMatchObject({ labourType: 'per_gram', labourRate: 50 });
    expect(changed).not.toHaveProperty('labourAmount');
  });

  it('keeps a labour amount with no derivable basis when weights change', () => {
    const view = { ...untaggedView, labourType: undefined, labourAmount: 75 };
    const command = lineCommand(setLineCell(lineFromView(view), 'netWt', '3'));
    expect(command.labourAmount).toBe(75);
  });

  it('a different tag drops the loaded tag serial', () => {
    const command = lineCommand(setLineCell(lineFromView(taggedView), 'tagNo', 'TGR2'));
    expect(command.tagNo).toBe('TGR2');
    expect(command).not.toHaveProperty('vchSrno');
  });

  it('a tag pick on a loaded line blanks the invalidated loaded cells but keeps a typed override', () => {
    const picked = updateLine(lineFromView(taggedView), { tagNo: 'TGR2', netWt: '6', fineWt: '5' });
    expect(picked.fineWt).toBe('5');
    expect(picked.metalAmount).toBe('');
  });
});

describe('purchase return form: new lines', () => {
  it('omits blank cells and sends per-gram making as labour', () => {
    const line = {
      ...blank(),
      itCode: 'GOLD',
      netWt: '2',
      touch: '91.6',
      rate: '6000',
      making: '300',
      designNo: 'D1',
      bagWt: '0.5',
    };
    expect(lineCommand(line)).toEqual({
      itCode: 'GOLD',
      tagNo: undefined,
      vchSrno: undefined,
      pcs: 1,
      grossWt: 0,
      netWt: 2,
      touch: 91.6,
      rate: 6000,
      labourType: 'per_gram',
      labourRate: 300,
      designNo: 'D1',
      bagWt: 0.5,
    });
    // fine 2 x 91.6 / 100 = 1.832, metal 1.832 x 6000 = 10992, labour 2 x 300 = 600.
    expect(linePreview(line, true)).toEqual({ fine: 1.832, metal: 10992, labour: 600, net: 11592 });
  });

  it('imports an original purchase line as a new line with its tag instance', () => {
    const line = lineFromPurchase({
      itCode: 'GOLD',
      tagNo: 'TGR1',
      vchSrno: 1,
      pcs: 1,
      grossWt: 5.2,
      netWt: 5,
      touch: 80,
      rate: 1500,
      labourType: 'per_gram',
      labourRate: 40,
    });
    expect(line.loaded).toBeUndefined();
    expect(lineCommand(line)).toMatchObject({
      tagNo: 'TGR1',
      vchSrno: 1,
      netWt: 5,
      labourType: 'per_gram',
      labourRate: 40,
    });
  });
});
