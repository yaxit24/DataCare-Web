import { readFileSync } from 'node:fs';
import { join } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  TAG_CANCEL_MODES,
  blankHeader,
  blankRow,
  changeRow,
  commitCell,
  commitStone,
  duplicateTag,
  gridTotals,
  isActiveRow,
  linePayload,
  neighbourVoucher,
  rowFromSaved,
  rowFromSource,
  setCell,
  tagCancelSettings,
  unresolvedTag,
  voucherPayload,
  withSpareRow,
  type GridRow,
  type TagSourceView,
} from '../lib/tagCancelVoucher';

/**
 * The shared TR_TAG_CAN form (Tag Cancel and Tag Transfer). Expected figures are the desktop's, worked by hand from
 * TR_TAG_CAN.cs `CommPassTotal` / `CommPassTotal_Idtl` and pinned to the same numbers the API test replays
 * (apps/api/test/tagCancelLifecycle.db.test.ts, tag RNG00001), so screen and writer agree from two sides.
 */
const settings = tagCancelSettings(null);

/** RNG00001 as `GET /stock/tag-cancel/source` returns it. */
const SOURCE: TagSourceView = {
  tagNo: 'RNG00001',
  vchSrno: 100100000001,
  source: 'BAR_DETL',
  itName: 'Ring 22K',
  line: {
    tagNo: 'RNG00001',
    vchSrno: 100100000001,
    itCode: 'RNG',
    tblCode: '001',
    designNo: 'D-101',
    itmSize: '12',
    lotNo: '',
    itmLot: '',
    bagWt: 0.05,
    pcs: 1,
    grossWt: 10.5,
    lessWt: 0.5,
    netWt: 10,
    ghtPct: 0,
    ghtWt: 0,
    touch: 91.6,
    westPct: 2,
    fine: 9.36,
    lbrPct: 0,
    lbrType: 'N',
    lbrRate: 150,
    lbrAmt: 1500,
    othAmt: 1200,
    rate: 0,
    amount: 0,
    mrp: 0,
    krNetWt: 9.91,
    krTouch: 90,
    krWestPct: 1.5,
    krFine: 9.15,
    krName: 'KJ',
    rateType: '',
    itType: 'G',
    prCode: 'RG',
    designImageId: 'IMG-101',
    trfrItCode: '',
  },
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
  ],
};

const tagRow = (mode: 'cancel' | 'transfer' = 'cancel'): GridRow =>
  rowFromSource(SOURCE, blankRow(settings, mode), settings, mode);

describe('settings', () => {
  it('reads the company labour basis and LBR_WITH_GHT with the desktop blank defaults', () => {
    expect(tagCancelSettings(null)).toEqual({ labourIncludesGhat: true, companyLabourType: 'G' });
    expect(tagCancelSettings({ LBR_TYPE: 'n', LBR_WITH_GHT: 'N' })).toEqual({
      labourIncludesGhat: false,
      companyLabourType: 'N',
    });
  });
});

describe('rows', () => {
  it('starts a new row as CommPassAdd does, copying the transfer item in Tag Transfer', () => {
    const first = {
      ...blankRow({ companyLabourType: 'N' }, 'transfer'),
      trfrItCode: 'OG',
      trfrItName: 'Old Gold',
    };
    const next = blankRow({ companyLabourType: 'N' }, 'transfer', first);
    expect([next.lbrType, next.designImageId, next.trfrItCode, next.trfrItName]).toEqual([
      'N',
      'N',
      'OG',
      'Old Gold',
    ]);
    expect(blankRow(settings, 'cancel', first).trfrItCode).toBe('');
  });

  it('fills a tag row with the grid formats and keeps the row’s place and transfer item', () => {
    const current = { ...blankRow(settings, 'transfer'), oldSrNo: '4', trfrItCode: 'OG' };
    const row = rowFromSource(SOURCE, current, settings, 'transfer');
    expect(row).toMatchObject({
      id: current.id,
      oldSrNo: '4',
      trfrItCode: 'OG',
      tagNo: 'RNG00001',
      filledTag: 'RNG00001',
      fromTag: true,
      vchSrno: '100100000001',
      grossWt: '10.500',
      touch: '91.60',
      fine: '9.360',
      lbrAmt: '1500.00',
      itName: 'Ring 22K',
    });
    expect(row.stones[0]).toMatchObject({ itCode: 'DIA', conPct: '1.000', netAmount: '1200.00' });
    // The tag fill records the loaded inputs; nothing records the karigar block.
    expect(row.baseline).toEqual({
      grossWt: 10.5,
      netWt: 10,
      touch: 91.6,
      westPct: 2,
      krNetWt: 0,
      krTouch: 0,
      krWestPct: 0,
    });
  });

  it('keeps a spare row under the last one typed', () => {
    const rows = withSpareRow([tagRow()], settings, 'cancel');
    expect(rows).toHaveLength(2);
    expect(isActiveRow(rows[1]!)).toBe(false);
    expect(withSpareRow(rows, settings, 'cancel')).toHaveLength(2);
  });

  it('gives a spare row put to use the previous row’s transfer item (CommPassAdd, :2830)', () => {
    // The spare row exists before row 1's transfer item is chosen, so the copy happens when the spare is first used.
    let rows = withSpareRow([tagRow('transfer')], settings, 'transfer');
    expect(rows[1]!.trfrItCode).toBe('');
    rows = changeRow(
      rows,
      0,
      (row) => ({ ...row, trfrItCode: 'OG', trfrItName: 'Old Gold' }),
      'transfer',
    );
    const filled = changeRow(
      rows,
      1,
      (row) => rowFromSource({ ...SOURCE, tagNo: 'RNG00002' }, row, settings, 'transfer'),
      'transfer',
    );
    expect([filled[1]!.trfrItCode, filled[1]!.trfrItName]).toEqual(['OG', 'Old Gold']);
    // A transfer item of the row's own is kept; Tag Cancel never copies one.
    const own = changeRow(rows, 1, (row) => ({ ...row, trfrItCode: 'OS' }), 'transfer');
    expect(changeRow(own, 1, (row) => ({ ...row, itCode: 'OS' }), 'transfer')[1]!.trfrItCode).toBe(
      'OS',
    );
    const cancel = changeRow(
      [{ ...tagRow(), trfrItCode: 'OG' }, blankRow(settings, 'cancel')],
      1,
      (row) => ({ ...row, itCode: 'OG' }),
      'cancel',
    );
    expect(cancel[1]!.trfrItCode).toBe('');
  });

  it('reopens a saved loose line as DISPLAY_DATA does', () => {
    const row = rowFromSaved(
      {
        srNo: 3,
        oldSrNo: 3,
        tagNo: '',
        itCode: 'OG',
        itName: 'Old Gold',
        grossWt: 2,
        netWt: 2,
        touch: 75,
        fine: 1.5,
        krNetWt: 2,
        krTouch: 75,
        krFine: 1.5,
        lbrType: 'G',
        stones: [],
      },
      settings,
      'cancel',
    );
    expect(row).toMatchObject({
      oldSrNo: '3',
      fromTag: false,
      filledTag: '',
      itCode: 'OG',
      fine: '1.500',
    });
    expect(unresolvedTag(row)).toBe(false);
  });
});

describe('cell events (MSG_LeaveCell → CommPassTotal)', () => {
  it('recomputes net, fine, labour and the karigar fine on leaving the gross weight', () => {
    const typed = setCell(tagRow(), 'grossWt', '10.7');
    const row = commitCell(typed, 'grossWt', settings);
    expect([row.grossWt, row.netWt, row.fine, row.lbrAmt, row.krFine]).toEqual([
      '10.700',
      '10.200',
      '9.547',
      '1530.00',
      '9.068',
    ]);
  });

  it('follows the operator’s order: a fine typed after the touch stands', () => {
    let row = commitCell(setCell(tagRow(), 'touch', '92'), 'touch', settings);
    expect(row.fine).toBe('9.400');
    row = commitCell(setCell(row, 'fine', '9.5'), 'fine', settings);
    expect(row.fine).toBe('9.500');
  });

  it('only stores the pieces (col 10) and formats them as a whole number', () => {
    const loose = { ...blankRow(settings, 'cancel'), itCode: 'OG' };
    const row = commitCell(setCell(loose, 'pcs', '2.4'), 'pcs', settings);
    expect(row.pcs).toBe('2');
    expect(row.fine).toBe('');
  });

  it('runs a loose row from zeros, the karigar block copying the item figures', () => {
    let row = { ...blankRow(settings, 'cancel'), itCode: 'OG' };
    row = commitCell(setCell(row, 'grossWt', '2'), 'grossWt', settings);
    row = commitCell(setCell(row, 'touch', '75'), 'touch', settings);
    expect([row.netWt, row.fine, row.krNetWt, row.krTouch, row.krFine]).toEqual([
      '2.000',
      '1.500',
      '2',
      '75',
      '1.5',
    ]);
  });

  it('upper-cases typed text and drops the apostrophe', () => {
    expect(setCell(blankRow(settings, 'cancel'), 'designNo', "d-9'x").designNo).toBe('D-9X');
    expect(setCell(blankRow(settings, 'cancel'), 'tagNo', 'rng01').tagNo).toBe('RNG01');
  });
});

describe('stones (CommPassTotal_Idtl)', () => {
  it('recomputes the stone and applies the stone sums to the row, without recomputing its fine', () => {
    const base = tagRow();
    const row = commitStone(
      {
        ...base,
        stones: [
          {
            itCode: 'dia',
            pcs: '5',
            grossWt: '0.25',
            conPct: '1',
            rateType: 'W',
            rate: '2000',
            lbrRate: '20',
          },
        ],
      },
      0,
    );
    expect(row.stones[0]).toMatchObject({
      itCode: 'DIA',
      karigarWt: '0.250',
      conWt: '0.250',
      amount: '500.00',
      lbrAmount: '100.00',
      netAmount: '600.00',
    });
    expect([row.lessWt, row.netWt, row.othAmt, row.fine, row.stonesEdited]).toEqual([
      '0.250',
      '10.250',
      '600.00',
      '9.360',
      true,
    ]);
    // The next main-grid cell the operator leaves recomputes the fine from the new net.
    expect(commitCell(row, 'lessWt', settings).fine).toBe('9.594');
  });
});

describe('payload', () => {
  it('sends every editable column of both grids (no dead cell)', () => {
    const form = readFileSync(join(process.cwd(), 'components/TagCancelForm.tsx'), 'utf8');
    const editable = [
      ...form.matchAll(
        /\{ label: '[^']+', kind: '(?:tag|item|text|number|transferItem)', field: '(\w+)'/g,
      ),
    ].map((match) => match[1]!);
    expect(editable).toHaveLength(20);
    const cancel = linePayload(tagRow(), 'cancel');
    const transfer = linePayload({ ...tagRow('transfer'), trfrItCode: 'OG' }, 'transfer');
    for (const field of editable) expect(field in cancel || field in transfer, field).toBe(true);
    // Ght% and TrfrItmName are display-only; nothing else is left out.
    expect(form).toContain("{ label: 'Ght%', kind: 'display', field: 'ghtPct'");
    expect(form).toContain("{ label: 'TrfrItmName', kind: 'transferName', field: 'trfrItName'");
  });

  it('sends every cell of the row, the tag it was filled from, and stones only when edited', () => {
    const line = linePayload(tagRow(), 'cancel');
    expect(line).toMatchObject({
      tagNo: 'RNG00001',
      vchSrno: 100100000001,
      itCode: 'RNG',
      grossWt: 10.5,
      fine: 9.36,
      krNetWt: 9.91,
      krFine: 9.15,
      lbrAmt: 1500,
      othAmt: 1200,
    });
    expect(line).not.toHaveProperty('stones');
    expect(line).not.toHaveProperty('trfrItCode');
    const edited = commitStone(
      { ...tagRow(), stones: [{ itCode: 'DIA', pcs: '1', grossWt: '0.1' }] },
      0,
    );
    expect(linePayload(edited, 'cancel').stones).toEqual([
      expect.objectContaining({ itCode: 'DIA', pcs: 1, grossWt: 0.1, karigarWt: 0.1 }),
    ]);
    expect(linePayload({ ...tagRow('transfer'), trfrItCode: 'OG' }, 'transfer').trfrItCode).toBe(
      'OG',
    );
  });

  it('never sends a retyped, unresolved tag with the old serial', () => {
    const retyped = setCell(tagRow(), 'tagNo', 'RNG00009');
    expect(unresolvedTag(retyped)).toBe(true);
    // The payload still names the tag the cells came from; the form refuses to save until it is resolved.
    expect(linePayload(retyped, 'cancel').tagNo).toBe('RNG00001');
  });

  it('builds the voucher body from the header and the used rows only', () => {
    const rows = withSpareRow([tagRow()], settings, 'cancel');
    const body = voucherPayload(
      { ...blankHeader('2024-06-10'), empCode: '001', vchDesc: "damaged'" },
      rows,
      'cancel',
      { coBook: 'TGC', coYear: '2024-2025', lcCode: '01' },
    );
    expect(body).toMatchObject({
      coBook: 'TGC',
      vchDate: '2024-06-10',
      empCode: '001',
      vchDesc: 'DAMAGED',
    });
    expect(body.lines).toHaveLength(1);
  });
});

describe('the grid around the rows', () => {
  it('refuses a tag already on another row ("Duplicate Tag No")', () => {
    const rows = [tagRow(), blankRow(settings, 'cancel')];
    expect(duplicateTag(rows, 1, 'rng00001')).toBe(true);
    expect(duplicateTag(rows, 0, 'RNG00001')).toBe(false);
  });

  it('totals the rows as MSG_TOT_FILL does', () => {
    let loose = { ...blankRow(settings, 'cancel'), itCode: 'OG' };
    loose = commitCell(setCell(loose, 'grossWt', '2'), 'grossWt', settings);
    loose = commitCell(setCell(loose, 'touch', '75'), 'touch', settings);
    expect(gridTotals([tagRow(), loose])).toMatchObject({
      pcs: 1,
      grossWt: 12.5,
      lessWt: 0.5,
      netWt: 12,
      fine: 10.86,
      lbrAmt: 1500,
      othAmt: 1200,
    });
  });

  it('steps to the neighbouring saved voucher, skipping gaps', () => {
    const numbers = ['00001', '00003', '00007'];
    expect(neighbourVoucher(numbers, '00003', 'previous')).toBe('00001');
    expect(neighbourVoucher(numbers, '00003', 'next')).toBe('00007');
    expect(neighbourVoucher(numbers, '00008', 'previous')).toBe('00007');
    expect(neighbourVoucher(numbers, '00007', 'next')).toBeNull();
  });

  it('mounts one form for both menus, each on its own resource and MAIN_BOOK', () => {
    expect(TAG_CANCEL_MODES.cancel).toMatchObject({
      endpoint: '/stock/tag-cancel',
      mainBook: 'TAG CANCEL',
    });
    expect(TAG_CANCEL_MODES.transfer).toMatchObject({
      endpoint: '/stock/tag-transfer',
      mainBook: 'TAG TRFR',
    });
    const form = readFileSync(join(process.cwd(), 'components/TagCancelForm.tsx'), 'utf8');
    // The desktop grids' visible columns, in order (MSG_CLEAR).
    for (const label of [
      'TagNo',
      'ItCode',
      'Counter',
      'Design',
      'Size',
      'BagWt',
      'Pcs',
      'GrWt',
      'LsWt',
      'NetWt',
      'Ght%',
      'GhtWt',
      'Touch',
      'West%',
      'Fine',
      'LbrRate',
      'LbrAmt',
      'OthAmt',
      'Mrp',
      'KrCode',
      'TrfrItm',
      'TrfrItmName',
    ]) {
      expect(form, label).toContain(`label: '${label}'`);
    }
    expect(form).toContain('mainBooks={[cfg.mainBook]}');
    expect(form).toContain('<SubDetailGrid');
  });
});
