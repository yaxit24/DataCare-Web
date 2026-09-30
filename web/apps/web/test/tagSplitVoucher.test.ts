import { readFileSync } from 'node:fs';
import { join } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  blankChild,
  blankHeader,
  childPayload,
  childTotals,
  commitChildCell,
  conserves,
  duplicateParent,
  isActiveChild,
  neighbourVoucher,
  parentFromSource,
  parentNetTotal,
  parentPayload,
  setChildCell,
  splitBalance,
  tagSplitSettings,
  voucherPayload,
  withSpareChild,
  type ChildRow,
  type ParentRow,
  type TagSourceView,
} from '../lib/tagSplitVoucher';
import { blankParent } from '../lib/tagSplitVoucher';

/**
 * The Tag Split form's pure half. Expected figures are the desktop's, pinned to the same numbers the API test
 * replays (apps/api/test/tagSplitRows.test.ts, tag SPL00001), so screen and writer agree from two sides.
 */
const settings = tagSplitSettings(null);

const SOURCE: TagSourceView = {
  tagNo: 'SPL00001',
  vchSrno: 100200000001,
  source: 'BAR_DETL',
  itName: 'Ring 22K',
  line: {
    itCode: 'RNG',
    tblCode: '001',
    designNo: 'D-1',
    itmSize: '12',
    pcs: 1,
    grossWt: 10,
    lessWt: 0,
    netWt: 10,
    touch: 91.6,
    westPct: 0,
    fine: 9.16,
    krNetWt: 10,
    krFine: 9.16,
    krName: '',
    itType: 'G',
    prCode: 'RG',
  },
  stones: [
    { itCode: 'DIA', itName: 'Diamond', pcs: 10, grossWt: 0.5, netAmount: 1200, itType: 'D' },
  ],
};

const parent = (): ParentRow => parentFromSource(SOURCE, blankParent());

const child = (patch: Partial<ChildRow> = {}): ChildRow => ({ ...blankChild(settings), ...patch });

describe('settings', () => {
  it('reads the company labour basis and LBR_WITH_GHT with the desktop blank defaults', () => {
    expect(tagSplitSettings(null)).toEqual({ labourIncludesGhat: true, companyLabourType: 'G' });
  });
});

describe('parent fill', () => {
  it('fills a parent verbatim from the tag and carries its stones', () => {
    const row = parent();
    expect(row).toMatchObject({
      tagNo: 'SPL00001',
      vchSrno: '100200000001',
      fromTag: true,
      filledTag: 'SPL00001',
      itCode: 'RNG',
      netWt: '10.000',
      fine: '9.160',
      itName: 'Ring 22K',
    });
    expect(row.stones[0]).toMatchObject({ itCode: 'DIA', netAmount: '1200.00' });
    expect(parentNetTotal([row])).toBe(10);
  });

  it('refuses a parent tag already on another row', () => {
    const rows = [parent(), blankParent()];
    expect(duplicateParent(rows, 1, 'spl00001')).toBe(true);
    expect(duplicateParent(rows, 0, 'SPL00001')).toBe(false);
  });
});

describe('child rows (CommPassTotal_Pr)', () => {
  it('recomputes net and fine on leaving the gross weight', () => {
    let c = child({ itCode: 'RNGH' });
    c = commitChildCell(setChildCell(c, 'grossWt', '6'), 'grossWt', settings);
    c = commitChildCell(setChildCell(c, 'touch', '91.6'), 'touch', settings);
    expect([c.netWt, c.fine]).toEqual(['6.000', '5.496']);
  });

  it('keeps a spare child under the last one used', () => {
    const used = commitChildCell(
      setChildCell(child({ itCode: 'RNGH' }), 'grossWt', '6'),
      'grossWt',
      settings,
    );
    const rows = withSpareChild([used], settings);
    expect(rows).toHaveLength(2);
    expect(isActiveChild(rows[1]!)).toBe(false);
  });

  it('totals the children and reports conservation against the parent', () => {
    const a = commitChildCell(
      setChildCell(child({ itCode: 'RNGH' }), 'grossWt', '6'),
      'grossWt',
      settings,
    );
    const b = commitChildCell(
      setChildCell(child({ itCode: 'RNGH' }), 'grossWt', '4'),
      'grossWt',
      settings,
    );
    expect(childTotals([a, b]).netWt).toBe(10);
    expect(conserves([parent()], [a, b])).toBe(true);
    const short = commitChildCell(
      setChildCell(child({ itCode: 'RNGH' }), 'grossWt', '3'),
      'grossWt',
      settings,
    );
    expect(conserves([parent()], [a, short])).toBe(false);
    // A 1.000 shortfall shows on the debit side at the operator's touch.
    const balance = splitBalance([parent()], [a, short], 91.6, 0);
    expect([balance.drWt, balance.drFine]).toEqual([1, 0.916]);
  });
});

describe('payload', () => {
  it('sends the parents by identity and every child cell; stones only when edited', () => {
    const p = parentPayload(parent());
    expect(p).toEqual({
      tagNo: 'SPL00001',
      vchSrno: 100200000001,
      itCode: 'RNG',
      oldSrNo: undefined,
    });
    const c = childPayload(
      commitChildCell(setChildCell(child({ itCode: 'RNGH' }), 'grossWt', '6'), 'grossWt', settings),
    );
    expect(c).toMatchObject({ itCode: 'RNGH', grossWt: 6, netWt: 6, sign: '+' });
    expect(c).not.toHaveProperty('stones');
  });

  it('builds the voucher body from the header, parents and used children only', () => {
    const used = commitChildCell(
      setChildCell(child({ itCode: 'RNGH' }), 'grossWt', '10'),
      'grossWt',
      settings,
    );
    const rows = withSpareChild([used], settings);
    const body = voucherPayload(
      { ...blankHeader('2024-06-10'), empCode: '001', acCode: 'SPLITAC', vchDesc: "worn'" },
      [parent()],
      rows,
      { coBook: 'TSP', coYear: '2024-2025', lcCode: '01' },
    );
    expect(body).toMatchObject({
      coBook: 'TSP',
      vchDate: '2024-06-10',
      empCode: '001',
      acCode: 'SPLITAC',
      vchDesc: 'WORN',
      itType: 'G',
    });
    expect(body.parents).toHaveLength(1);
    expect(body.children).toHaveLength(1);
  });
});

describe('the grid around the rows', () => {
  it('steps to the neighbouring saved voucher, skipping gaps', () => {
    const numbers = ['00001', '00003', '00007'];
    expect(neighbourVoucher(numbers, '00003', 'previous')).toBe('00001');
    expect(neighbourVoucher(numbers, '00003', 'next')).toBe('00007');
  });

  it('mounts a form with the desktop parent and child columns', () => {
    const form = readFileSync(join(process.cwd(), 'components/TagSplitForm.tsx'), 'utf8');
    for (const label of ['TagNo', 'ItCode', 'GrWt', 'NetWt', 'Touch', 'Fine']) {
      expect(form, label).toContain(`label: '${label}'`);
    }
    expect(form).toContain('mainBooks={[');
    expect(form).toContain('<SubDetailGrid');
  });
});
