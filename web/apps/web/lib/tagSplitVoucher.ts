/**
 * TR_TAG_SPLIT — the pure half of the Tag Split form: parent rows (read-only, filled from the tag), child rows the
 * operator builds, the request payload and the reopen mapping, so it can be tested without a browser. Every computed
 * child cell runs the SAME `@datacare/core` arithmetic the API writes with (`tagSplitChild`, `tagSplitStone`,
 * `tagSplitStoneEffect`, `tagSplitTotals`, `tagSplitBalance`, `tagSplitConserves`), so what the operator sees is what
 * is saved.
 *
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md (K3-K7, K14).
 */
import {
  decimalCellText,
  tagSplitBalance,
  tagSplitChild,
  tagSplitConserves,
  tagSplitStone,
  tagSplitStoneEffect,
  tagSplitTotals,
  type TagSplitBalance,
  type TagSplitChildCells,
  type TagSplitSettings,
  type TagSplitTotals,
} from '@datacare/core';
import { companyFlag, companySetting, type CompanySettingValues } from './companySettings';

export interface TagSplitScreenSettings extends TagSplitSettings {
  companyLabourType: string;
}

export function tagSplitSettings(values: CompanySettingValues | null): TagSplitScreenSettings {
  const labourType = String(companySetting(values, 'LBR_TYPE') ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  return {
    labourIncludesGhat: companyFlag(values, 'LBR_WITH_GHT', 'Y'),
    companyLabourType: ['G', 'N', 'K', 'P'].includes(labourType) ? labourType : 'G',
  };
}

const n = (value: unknown): number => {
  const x = Number(String(value ?? '').trim() || 0);
  return Number.isFinite(x) ? x : 0;
};
const cellText = (value: unknown, decimals: number): string => decimalCellText(n(value), decimals);
export const showCell = (value: string, decimals: number): string =>
  String(value ?? '').trim() === '' ? '' : cellText(value, decimals);
export const typedText = (value: string): string => value.replace(/'/g, '').toUpperCase();

export function todayLocal(now = new Date()): string {
  const pad = (value: number) => String(value).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
}

let nextId = 1;
const rowId = () => nextId++;

// ---- parent rows (read-only, filled from the tag) ---------------------------------------------------

export interface ParentRow {
  id: number;
  oldSrNo: string;
  tagNo: string;
  vchSrno: string;
  /** The row is filled from a live tag. */
  fromTag: boolean;
  filledTag: string;
  itCode: string;
  itName: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  lessWt: string;
  netWt: string;
  touch: string;
  westPct: string;
  fine: string;
  krNetWt: string;
  krFine: string;
  krName: string;
  itType: string;
  prCode: string;
  stones: StoneDraft[];
}

export interface StoneDraft {
  itCode?: string;
  itName?: string;
  pcs?: string;
  grossWt?: string;
  karigarWt?: string;
  conPct?: string;
  rateType?: string;
  rate?: string;
  amount?: string;
  lbrRate?: string;
  lbrAmount?: string;
  netAmount?: string;
  itType?: string;
}

export interface TagSourceView {
  tagNo: string;
  vchSrno: number;
  source: 'BAR_DETL' | 'TAG_STOCK';
  itName: string;
  line: Record<string, unknown>;
  stones: Array<Record<string, unknown>>;
}

export function blankParent(): ParentRow {
  return {
    id: rowId(),
    oldSrNo: '',
    tagNo: '',
    vchSrno: '',
    fromTag: false,
    filledTag: '',
    itCode: '',
    itName: '',
    tblCode: '',
    designNo: '',
    itmSize: '',
    pcs: '',
    grossWt: '',
    lessWt: '',
    netWt: '',
    touch: '',
    westPct: '',
    fine: '',
    krNetWt: '',
    krFine: '',
    krName: '',
    itType: '',
    prCode: '',
    stones: [],
  };
}

const stoneFromApi = (stone: Record<string, unknown>): StoneDraft => ({
  itCode: String(stone.itCode ?? ''),
  itName: String(stone.itName ?? ''),
  pcs: String(n(stone.pcs)),
  grossWt: cellText(stone.grossWt, 3),
  karigarWt: cellText(stone.karigarWt, 3),
  conPct: cellText(stone.conPct, 3),
  rateType: String(stone.rateType ?? ''),
  rate: cellText(stone.rate, 2),
  amount: cellText(stone.amount, 2),
  lbrRate: cellText(stone.lbrRate, 2),
  lbrAmount: cellText(stone.lbrAmount, 2),
  netAmount: cellText(stone.netAmount, 2),
  itType: String(stone.itType ?? ''),
});

/** Fill a parent row from the tag source (`GET …/source`). */
export function parentFromSource(source: TagSourceView, current: ParentRow): ParentRow {
  const c = source.line;
  const text = (field: string) => String(c[field] ?? '');
  return {
    ...blankParent(),
    id: current.id,
    oldSrNo: current.oldSrNo,
    tagNo: source.tagNo,
    vchSrno: String(source.vchSrno),
    fromTag: true,
    filledTag: source.tagNo,
    itCode: text('itCode'),
    itName: source.itName,
    tblCode: text('tblCode'),
    designNo: text('designNo'),
    itmSize: text('itmSize'),
    pcs: String(n(c.pcs)),
    grossWt: cellText(c.grossWt, 3),
    lessWt: cellText(c.lessWt, 3),
    netWt: cellText(c.netWt, 3),
    touch: cellText(c.touch, 2),
    westPct: cellText(c.westPct, 2),
    fine: cellText(c.fine, 3),
    krNetWt: cellText(c.krNetWt, 3),
    krFine: cellText(c.krFine, 3),
    krName: text('krName'),
    itType: text('itType'),
    prCode: text('prCode'),
    stones: source.stones.map(stoneFromApi),
  };
}

/** A saved parent line, as the reader returns it. */
export function parentFromSaved(line: Record<string, unknown>): ParentRow {
  return {
    ...parentFromSource(
      {
        tagNo: String(line.tagNo ?? ''),
        vchSrno: n(line.vchSrno),
        source: 'BAR_DETL',
        itName: String(line.itName ?? ''),
        line,
        stones: Array.isArray(line.stones) ? (line.stones as Array<Record<string, unknown>>) : [],
      },
      blankParent(),
    ),
    oldSrNo: String(n(line.oldSrNo)),
  };
}

// ---- child rows (the operator builds them) ----------------------------------------------------------

export interface ChildRow {
  id: number;
  oldSrNo: string;
  /** The allocated tag number, shown after save/reopen (blank while typing a new voucher). */
  tagNo: string;
  vchSrno: string;
  itCode: string;
  itName: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  sign: string;
  pcs: string;
  grossWt: string;
  lessWt: string;
  netWt: string;
  ghtPct: string;
  ghtWt: string;
  touch: string;
  westPct: string;
  fine: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  rate: string;
  amount: string;
  mrp: string;
  krName: string;
  krNetWt: string;
  krTouch: string;
  krWestPct: string;
  krFine: string;
  lbrType: string;
  rateType: string;
  itType: string;
  prCode: string;
  stones: StoneDraft[];
  stonesEdited: boolean;
}

export function blankChild(settings: Pick<TagSplitScreenSettings, 'companyLabourType'>): ChildRow {
  return {
    id: rowId(),
    oldSrNo: '',
    tagNo: '',
    vchSrno: '',
    itCode: '',
    itName: '',
    tblCode: '',
    designNo: '',
    itmSize: '',
    sign: '+',
    pcs: '1',
    grossWt: '',
    lessWt: '',
    netWt: '',
    ghtPct: '',
    ghtWt: '',
    touch: '',
    westPct: '',
    fine: '',
    lbrRate: '',
    lbrAmt: '',
    othAmt: '',
    rate: '',
    amount: '',
    mrp: '',
    krName: '',
    krNetWt: '',
    krTouch: '',
    krWestPct: '',
    krFine: '',
    lbrType: settings.companyLabourType,
    rateType: '',
    itType: '',
    prCode: '',
    stones: [],
    stonesEdited: false,
  };
}

export function isActiveChild(row: ChildRow): boolean {
  if (row.itCode.trim() || row.oldSrNo) return true;
  return n(row.grossWt) + n(row.netWt) + n(row.mrp) + n(row.othAmt) !== 0;
}

/** Keep a spare child row under the last one used. */
export function withSpareChild(
  rows: ChildRow[],
  settings: Pick<TagSplitScreenSettings, 'companyLabourType'>,
): ChildRow[] {
  const last = rows[rows.length - 1];
  if (!last) return [blankChild(settings)];
  return isActiveChild(last) ? [...rows, blankChild(settings)] : rows;
}

const CHILD_DECIMALS: Record<string, number> = {
  pcs: 0,
  grossWt: 3,
  lessWt: 3,
  netWt: 3,
  ghtPct: 2,
  ghtWt: 3,
  touch: 2,
  westPct: 2,
  fine: 3,
  lbrRate: 2,
  lbrAmt: 2,
  othAmt: 2,
  rate: 2,
  amount: 2,
  mrp: 2,
};
export type ChildNumericCell = keyof typeof CHILD_DECIMALS;
export type ChildTextCell = 'tblCode' | 'designNo' | 'itmSize' | 'krName' | 'sign';

export function setChildCell(
  row: ChildRow,
  field: ChildNumericCell | ChildTextCell,
  value: string,
): ChildRow {
  return { ...row, [field]: field in CHILD_DECIMALS ? value : typedText(value) };
}

const toChildCells = (row: ChildRow): TagSplitChildCells => ({
  pcs: n(row.pcs),
  grossWt: n(row.grossWt),
  lessWt: n(row.lessWt),
  netWt: n(row.netWt),
  ghtPct: n(row.ghtPct),
  ghtWt: n(row.ghtWt),
  touch: n(row.touch),
  westPct: n(row.westPct),
  fine: n(row.fine),
  krOthWt: 0,
  krNetWt: n(row.krNetWt),
  krGhtWt: 0,
  krTouch: n(row.krTouch),
  krWestPct: n(row.krWestPct),
  krFine: n(row.krFine),
  lbrType: row.lbrType,
  lbrRate: n(row.lbrRate),
  lbrAmt: n(row.lbrAmt),
  othAmt: n(row.othAmt),
  krLbrRate: 0,
  krLbrAmt: 0,
  krOthAmt: 0,
  rateType: row.rateType,
  rate: n(row.rate),
  amount: n(row.amount),
  krCost: 0,
  tagCost: 0,
  margin: 0,
  mrp: n(row.mrp),
});

function applyChildCells(row: ChildRow, cells: TagSplitChildCells): ChildRow {
  return {
    ...row,
    netWt: cellText(cells.netWt, 3),
    ghtWt: cellText(cells.ghtWt, 3),
    fine: cellText(cells.fine, 3),
    lbrAmt: cellText(cells.lbrAmt, 2),
    amount: cellText(cells.amount, 2),
    mrp: cellText(cells.mrp, 2),
    krNetWt: cellText(cells.krNetWt, 3),
    krFine: cellText(cells.krFine, 3),
  };
}

const stoneCells = (stone: StoneDraft) => ({
  pcs: n(stone.pcs),
  pcsWt: 0,
  karigarWt: n(stone.karigarWt),
  karigarActPct: 0,
  weight: n(stone.grossWt),
  karigarLessPct: 0,
  conPct: n(stone.conPct),
  rateType: String(stone.rateType ?? '')
    .trim()
    .toUpperCase(),
  rate: n(stone.rate),
  amount: n(stone.amount),
  karigarRate: 0,
  karigarAmount: 0,
  lbrRate: n(stone.lbrRate),
  lbrAmount: n(stone.lbrAmount),
  netAmount: n(stone.netAmount),
  conWt: 0,
  karigarConWt: 0,
});

function applyStones(row: ChildRow): ChildRow {
  const effect = tagSplitStoneEffect(
    {
      grossWt: n(row.grossWt),
      lessWt: n(row.lessWt),
      netWt: n(row.netWt),
      krOthWt: 0,
      krNetWt: n(row.krNetWt),
      othAmt: n(row.othAmt),
      krOthAmt: 0,
    },
    row.stones.map((s) => {
      const c = tagSplitStone(stoneCells(s));
      return {
        conWt: c.conWt,
        karigarConWt: c.karigarConWt,
        netAmount: c.netAmount,
        karigarAmount: 0,
      };
    }),
  );
  return {
    ...row,
    lessWt: cellText(effect.lessWt, 3),
    netWt: cellText(effect.netWt, 3),
    othAmt: cellText(effect.othAmt, 2),
  };
}

/** Leaving a child numeric cell (`MSG_PR_LeaveCell` → CommPassTotal_Pr), like the desktop, whether or not it changed. */
export function commitChildCell(
  row: ChildRow,
  field: ChildNumericCell,
  settings: TagSplitSettings,
): ChildRow {
  const formatted = {
    ...row,
    [field]: cellText((row as unknown as Record<string, unknown>)[field], CHILD_DECIMALS[field]!),
  } as ChildRow;
  if (field === 'pcs') return formatted;
  const withStones = field === 'lessWt' && row.stones.length ? applyStones(formatted) : formatted;
  return applyChildCells(withStones, tagSplitChild(toChildCells(withStones), settings));
}

/** Leaving a stone cell recomputes it and applies the stone sums to the child row. */
export function commitChildStone(
  row: ChildRow,
  index: number,
  settings: TagSplitSettings,
): ChildRow {
  const stone = row.stones[index];
  if (!stone) return row;
  const computed = tagSplitStone(stoneCells(stone));
  const stones = row.stones.map((current, i) =>
    i === index
      ? {
          ...current,
          itCode: typedText(String(current.itCode ?? '')),
          grossWt: cellText(computed.weight, 3),
          karigarWt: cellText(computed.karigarWt, 3),
          amount: cellText(computed.amount, 2),
          lbrAmount: cellText(computed.lbrAmount, 2),
          netAmount: cellText(computed.netAmount, 2),
        }
      : current,
  );
  const applied = applyStones({ ...row, stones, stonesEdited: true });
  return applyChildCells(applied, tagSplitChild(toChildCells(applied), settings));
}

export function childFromSaved(
  line: Record<string, unknown>,
  settings: Pick<TagSplitScreenSettings, 'companyLabourType'>,
): ChildRow {
  const text = (field: string) => String(line[field] ?? '');
  return {
    ...blankChild(settings),
    oldSrNo: String(n(line.oldSrNo)),
    tagNo: text('tagNo'),
    vchSrno: n(line.vchSrno) ? String(n(line.vchSrno)) : '',
    itCode: text('itCode'),
    itName: text('itName'),
    tblCode: text('tblCode'),
    designNo: text('designNo'),
    itmSize: text('itmSize'),
    sign: text('sign') || '+',
    pcs: String(n(line.pcs)),
    grossWt: cellText(line.grossWt, 3),
    lessWt: cellText(line.lessWt, 3),
    netWt: cellText(line.netWt, 3),
    ghtWt: cellText(line.ghtWt, 3),
    touch: cellText(line.touch, 2),
    westPct: cellText(line.westPct, 2),
    fine: cellText(line.fine, 3),
    lbrRate: cellText(line.lbrRate, 2),
    lbrAmt: cellText(line.lbrAmt, 2),
    othAmt: cellText(line.othAmt, 2),
    rate: cellText(line.rate, 2),
    amount: cellText(line.amount, 2),
    mrp: cellText(line.mrp, 2),
    krName: text('krName'),
    krNetWt: cellText(line.krNetWt, 3),
    krTouch: cellText(line.krTouch, 2),
    krWestPct: cellText(line.krWestPct, 2),
    krFine: cellText(line.krFine, 3),
    stones: Array.isArray(line.stones)
      ? (line.stones as Array<Record<string, unknown>>).map(stoneFromApi)
      : [],
  };
}

// ---- totals, balance and conservation ---------------------------------------------------------------

export function parentNetTotal(rows: readonly ParentRow[]): number {
  return Number(
    rows
      .filter((r) => r.fromTag)
      .reduce((s, r) => s + n(r.netWt), 0)
      .toFixed(3),
  );
}

export function childTotals(rows: readonly ChildRow[]): TagSplitTotals {
  return tagSplitTotals(
    rows.filter(isActiveChild).map((r) => ({
      sign: r.sign,
      pcs: n(r.pcs),
      grossWt: n(r.grossWt),
      lessWt: n(r.lessWt),
      netWt: n(r.netWt),
      ghtWt: n(r.ghtWt),
      fine: n(r.fine),
      lbrAmt: n(r.lbrAmt),
      othAmt: n(r.othAmt),
      amount: n(r.amount),
      mrp: n(r.mrp),
      krNetWt: n(r.krNetWt),
      krFine: n(r.krFine),
    })),
  );
}

export function splitBalance(
  parents: readonly ParentRow[],
  children: readonly ChildRow[],
  drTouch: number,
  crTouch: number,
): TagSplitBalance {
  return tagSplitBalance({
    parentNet: parentNetTotal(parents),
    childNet: childTotals(children).netWt,
    drTouch,
    crTouch,
  });
}

export function conserves(parents: readonly ParentRow[], children: readonly ChildRow[]): boolean {
  return tagSplitConserves(parentNetTotal(parents), childTotals(children).netWt);
}

// ---- payload ----------------------------------------------------------------------------------------

const filledStone = (stone: StoneDraft): boolean =>
  Object.entries(stone).some(([k, v]) => k !== 'itName' && String(v ?? '').trim() !== '');

export function parentPayload(row: ParentRow): Record<string, unknown> {
  return {
    tagNo: row.filledTag,
    vchSrno: row.vchSrno ? n(row.vchSrno) : undefined,
    itCode: row.itCode.trim() || undefined,
    oldSrNo: row.oldSrNo ? n(row.oldSrNo) : undefined,
  };
}

export function childPayload(row: ChildRow): Record<string, unknown> {
  const line: Record<string, unknown> = {
    itCode: row.itCode.trim(),
    oldSrNo: row.oldSrNo ? n(row.oldSrNo) : undefined,
    tblCode: row.tblCode,
    designNo: row.designNo,
    itmSize: row.itmSize,
    sign: row.sign || '+',
    pcs: n(row.pcs),
    grossWt: n(row.grossWt),
    lessWt: n(row.lessWt),
    netWt: n(row.netWt),
    ghtPct: n(row.ghtPct),
    ghtWt: n(row.ghtWt),
    touch: n(row.touch),
    westPct: n(row.westPct),
    fine: n(row.fine),
    lbrRate: n(row.lbrRate),
    lbrAmt: n(row.lbrAmt),
    othAmt: n(row.othAmt),
    rate: n(row.rate),
    amount: n(row.amount),
    mrp: n(row.mrp),
    krName: row.krName,
  };
  if (row.stonesEdited) {
    line.stones = row.stones.filter(filledStone).map((stone) => ({
      itCode: String(stone.itCode ?? '').trim() || undefined,
      pcs: n(stone.pcs),
      grossWt: n(stone.grossWt),
      karigarWt: n(stone.karigarWt),
      conPct: n(stone.conPct),
      rateType: String(stone.rateType ?? '').trim(),
      rate: n(stone.rate),
      amount: n(stone.amount),
      lbrRate: n(stone.lbrRate),
      lbrAmount: n(stone.lbrAmount),
      netAmount: n(stone.netAmount),
      itType: String(stone.itType ?? '').trim() || undefined,
    }));
  }
  return line;
}

export interface SplitHeaderDraft {
  vchDate: string;
  empCode: string;
  empName: string;
  acCode: string;
  acName: string;
  vchDesc: string;
  drTouch: string;
  crTouch: string;
  crLbr: string;
}

export const blankHeader = (vchDate = todayLocal()): SplitHeaderDraft => ({
  vchDate,
  empCode: '',
  empName: '',
  acCode: '',
  acName: '',
  vchDesc: '',
  drTouch: '',
  crTouch: '',
  crLbr: '',
});

export function voucherPayload(
  header: SplitHeaderDraft,
  parents: readonly ParentRow[],
  children: readonly ChildRow[],
  scope: { coBook: string; coYear?: string; lcCode?: string },
): Record<string, unknown> {
  return {
    coBook: scope.coBook,
    coYear: scope.coYear,
    lcCode: scope.lcCode,
    vchDate: header.vchDate,
    empCode: header.empCode.trim(),
    acCode: header.acCode.trim(),
    itType: parents.find((p) => p.fromTag)?.itType || 'G',
    drTouch: n(header.drTouch),
    crTouch: n(header.crTouch),
    crLbr: n(header.crLbr),
    vchDesc: typedText(header.vchDesc).trim(),
    parents: parents.filter((p) => p.fromTag).map(parentPayload),
    children: children.filter(isActiveChild).map(childPayload),
  };
}

/** "Duplicate Tag No": the parent number is on another parent row already. */
export function duplicateParent(rows: readonly ParentRow[], index: number, tagNo: string): boolean {
  const wanted = typedText(tagNo).trim();
  return (
    wanted !== '' &&
    rows.some((row, i) => i !== index && row.fromTag && row.tagNo.trim().toUpperCase() === wanted)
  );
}

export function neighbourVoucher(
  numbers: readonly string[],
  current: string,
  direction: 'previous' | 'next',
): string | null {
  const here = n(current);
  const sorted = numbers.map((value) => n(value)).sort((a, b) => a - b);
  const found =
    direction === 'previous'
      ? [...sorted].reverse().find((value) => value < here)
      : sorted.find((value) => value > here);
  return found == null ? null : String(found).padStart(5, '0');
}
