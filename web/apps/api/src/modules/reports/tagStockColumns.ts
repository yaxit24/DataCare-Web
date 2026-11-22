/**
 * Tag Stock (desktop RP_TAG) grid columns per mode. One definition feeds the screen, the CSV and the Excel
 * export, so the three can never disagree. Headers are the desktop column names; the order is the order of the
 * visible columns after DGV_FILL hides CoCode, Book, BookName, AcCode and Remark (RP_TAG.cs:4825-4840).
 */
import { round } from '@datacare/core';

export type TagStockTab = 'in' | 'out' | 'stock' | 'mrp' | 'apr' | 'all';
export type TagStockView = 'tag' | 'item' | 'product';
/** int = plain count, wt = {0:n3}, amt = {0:n0}, text and date are left as stored. */
export type TagStockColumnKind = 'text' | 'date' | 'int' | 'wt' | 'amt';
export interface TagStockColumn {
  key: string;
  header: string;
  kind: TagStockColumnKind;
  /** Summed in the footer (RP_TAG.cs:4916-4976 Summary.Add). */
  total?: boolean;
}

const c = (
  key: string,
  header: string,
  kind: TagStockColumnKind = 'text',
  total = false,
): TagStockColumn => ({
  key,
  header,
  kind,
  ...(total ? { total } : {}),
});
const COL = {
  lcCode: c('lcCode', 'LcCode'),
  vchType: c('vchType', 'VchTyp'),
  vchNo: c('vchNo', 'VchNo'),
  vchDate: c('vchDate', 'VchDate', 'date'),
  day: c('day', 'Day', 'int'),
  tagNo: c('tagNo', 'TagNo'),
  itCode: c('itCode', 'ItCode'),
  counter: c('counter', 'Counter'),
  design: c('design', 'Design'),
  style: c('style', 'Style'),
  size: c('size', 'Size'),
  qty: c('qty', 'Qty', 'int', true),
  pcs: c('pcs', 'Pcs', 'int', true),
  grossWt: c('grossWt', 'Grwt', 'wt', true),
  netWt: c('netWt', 'NetWt', 'wt', true),
  lbrRate: c('lbrRate', 'LbrRate', 'amt'),
  lbrPrc: c('lbrPrc', 'Lbrprc', 'wt'),
  lbrAmt: c('lbrAmt', 'LbrAmt', 'amt', true),
  othAmt: c('othAmt', 'OthAmt', 'amt', true),
  prCost: c('prCost', 'PrCost', 'amt', true),
  mrp: c('mrp', 'Mrp', 'amt', true),
  krName: c('krName', 'KrName'),
  tagId: c('tagId', 'TagId', 'int'),
  safeName: c('safeName', 'SafeName'),
  sign: c('sign', 'Sign'),
  empIsu: c('empIsu', 'EmpIsu'),
  partyName: c('partyName', 'PartyName'),
  empName: c('empName', 'EmpName'),
};

export function tagStockColumns(
  tab: TagStockTab,
  view: TagStockView = 'tag',
  aprKind: 'party' | 'employee' = 'party',
): TagStockColumn[] {
  if (view === 'item') return [c('name', 'Item'), COL.qty, COL.pcs, COL.grossWt, COL.netWt];
  if (view === 'product') return [c('name', 'Product'), COL.qty, COL.pcs, COL.grossWt, COL.netWt];
  const k = COL;
  if (tab === 'stock' || tab === 'mrp')
    return [
      k.lcCode,
      k.vchType,
      k.vchNo,
      k.vchDate,
      k.day,
      k.tagNo,
      k.itCode,
      k.counter,
      k.design,
      k.style,
      k.size,
      k.qty,
      k.pcs,
      k.grossWt,
      k.netWt,
      k.lbrRate,
      k.lbrPrc,
      k.lbrAmt,
      k.othAmt,
      k.prCost,
      k.mrp,
      k.krName,
      k.tagId,
      k.safeName,
    ];
  if (tab === 'in')
    return [
      k.vchType,
      k.vchNo,
      k.vchDate,
      k.day,
      k.tagNo,
      k.itCode,
      k.counter,
      k.design,
      k.style,
      k.size,
      k.qty,
      k.pcs,
      k.grossWt,
      k.netWt,
      k.lbrPrc,
      k.lbrRate,
      k.lbrAmt,
      k.othAmt,
      k.prCost,
      k.mrp,
      k.krName,
      k.tagId,
      k.safeName,
    ];
  if (tab === 'out')
    return [
      k.vchType,
      k.vchNo,
      k.vchDate,
      k.day,
      k.tagNo,
      k.itCode,
      k.counter,
      k.design,
      k.style,
      k.size,
      k.qty,
      k.pcs,
      k.grossWt,
      k.netWt,
      k.lbrRate,
      k.lbrPrc,
      k.lbrAmt,
      k.othAmt,
      k.prCost,
      k.mrp,
      k.krName,
      k.tagId,
      k.safeName,
    ];
  if (tab === 'apr')
    return [
      k.vchType,
      k.vchNo,
      k.vchDate,
      k.tagNo,
      k.itCode,
      aprKind === 'employee' ? k.empName : k.partyName,
      k.design,
      k.style,
      k.counter,
      k.size,
      k.qty,
      k.pcs,
      k.grossWt,
      k.netWt,
      k.lbrRate,
      k.lbrPrc,
      k.lbrAmt,
      k.othAmt,
      k.prCost,
      k.mrp,
      k.krName,
      k.tagId,
    ];
  return [
    k.vchType,
    k.vchNo,
    k.vchDate,
    k.tagNo,
    k.itCode,
    k.counter,
    k.design,
    k.size,
    k.qty,
    k.pcs,
    k.grossWt,
    k.netWt,
    k.lbrRate,
    k.lbrPrc,
    k.lbrAmt,
    k.othAmt,
    k.mrp,
    k.krName,
    k.tagId,
    k.sign,
    k.empIsu,
    k.safeName,
  ];
}

/** Rounds a footer figure the way the grid shows it (weights n3, amounts n2 so no cent is lost). */
export const r3 = (n: number): number => round(n, 3);
export const r2 = (n: number): number => round(n, 2);

const csvCell = (v: unknown): string => {
  const s = String(v ?? '');
  return /[",\r\n]/.test(s) ? '"' + s.replace(/"/g, '""') + '"' : s;
};

/** CSV of the grid: the same columns and rows as the screen, then one TOTAL row of the footer sums. */
export function tagStockCsv(rep: {
  columns: TagStockColumn[];
  rows: Array<Record<string, unknown>>;
  totals: Record<string, number>;
}): string {
  const lines = [rep.columns.map((col) => csvCell(col.header)).join(',')];
  for (const row of rep.rows) lines.push(rep.columns.map((col) => csvCell(row[col.key])).join(','));
  let labelled = false;
  lines.push(
    rep.columns
      .map((col) => {
        if (col.total) return csvCell(rep.totals[col.key] ?? 0);
        if (!labelled) {
          labelled = true;
          return 'TOTAL';
        }
        return '';
      })
      .join(','),
  );
  return lines.join('\n');
}
