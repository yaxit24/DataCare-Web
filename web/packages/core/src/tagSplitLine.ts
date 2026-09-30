/**
 * TR_TAG_SPLIT child-row arithmetic (`CommPassTotal_Pr`, TR_TAG_SPLIT.cs:6338-6704), the stone arithmetic
 * (`CommPassTotal_Rtn_Idtl`, :4758-4886) and the conservation balance (`BILL_TOTAL`, :12200-12256).
 *
 * The Tag Split form consumes one or more PARENT tags (their metal is read verbatim from BAR_DETL and never
 * recomputed) and creates one or more CHILD tags whose cells the operator types. This module is the child grid's
 * pure arithmetic, run identically on the screen (each cell commit) and on the server (once per line), so what the
 * operator sees is what is saved. Weights use `Strings.Format` half-up; money uses `Math.Round` half-to-even, in the
 * desktop operand order.
 *
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md (K5-K7).
 */
import { round, roundHalfEven } from './money.js';

const n = (value: unknown): number => {
  const x = Number(String(value ?? '').trim() || 0);
  return Number.isFinite(x) ? x : 0;
};
const code = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
const f3 = (x: number): number => round(x, 3);
const f2 = (x: number): number => round(x, 2);
const r0 = (x: number): number => roundHalfEven(x, 0);

/** The company settings the split arithmetic reads (MS_OPNCOMP.cs). */
export interface TagSplitSettings {
  /** `LBR_WITH_GHT` (blank → true): 'N' labour is on net; otherwise on net + ghat. */
  labourIncludesGhat: boolean;
}

/** A child grid row's numeric cells (the desktop MSG_PR columns the operator types and the grid computes). */
export interface TagSplitChildCells {
  pcs: number;
  grossWt: number;
  lessWt: number;
  netWt: number;
  ghtPct: number;
  ghtWt: number;
  touch: number;
  westPct: number;
  fine: number;
  krOthWt: number;
  krNetWt: number;
  krGhtWt: number;
  krTouch: number;
  krWestPct: number;
  krFine: number;
  lbrType: string;
  lbrRate: number;
  lbrAmt: number;
  othAmt: number;
  krLbrRate: number;
  krLbrAmt: number;
  krOthAmt: number;
  rateType: string;
  rate: number;
  amount: number;
  krCost: number;
  tagCost: number;
  margin: number;
  mrp: number;
}

/**
 * `CommPassTotal_Pr` (TR_TAG_SPLIT.cs:6338-6704): recompute a child row from its typed cells. Unlike the cancel
 * form, the child grid recomputes fully on each leave (the operator builds the row from zero), so there is no hidden
 * "changed since last compute" baseline — every derived cell is re-derived from the current inputs.
 */
export function tagSplitChild(
  input: TagSplitChildCells,
  settings: TagSplitSettings,
): TagSplitChildCells {
  const c: TagSplitChildCells = { ...input };
  // 1. Net and karigar net from gross and the less weights (:6360).
  c.netWt = f3(n(c.grossWt) - n(c.lessWt));
  c.krNetWt = f3(n(c.grossWt) - n(c.krOthWt));
  // 2. Ghat weight from net and Ght% (:6402).
  c.ghtWt = f3((n(c.netWt) * n(c.ghtPct)) / 100);
  const krGhtWt = n(c.krGhtWt);
  // 3. Fine from (net + ghat) x (touch + wastage) / 100, or net + ghat with no purity (:6420).
  const purity = n(c.touch) + n(c.westPct);
  c.fine =
    purity !== 0 ? f3((n(c.netWt) + n(c.ghtWt)) * (purity / 100)) : f3(n(c.netWt) + n(c.ghtWt));
  const krPurity = n(c.krTouch) + n(c.krWestPct);
  c.krFine =
    krPurity !== 0 ? f3((n(c.krNetWt) + krGhtWt) * (krPurity / 100)) : f3(n(c.krNetWt) + krGhtWt);
  // 4. Item amount by RATE_TYPE (:6520).
  const rate = n(c.rate);
  const fine = n(c.fine);
  if (rate !== 0) {
    switch (code(c.rateType)) {
      case 'P':
        c.amount = r0(n(c.pcs) * rate);
        break;
      case '1':
        c.amount = r0(fine * (rate / 10));
        break;
      case 'K':
        c.amount = r0(fine * (rate / 1000));
        break;
      default:
        c.amount = r0(fine * rate);
    }
  }
  // 5. Labour by LBR_TYPE and LBR_WITH_GHT (:6560).
  c.lbrAmt = labour(code(c.lbrType), n(c.lbrRate), c, settings);
  c.krLbrAmt = labour(code(c.lbrType), n(c.krLbrRate), c, settings, true);
  // 6. Tag cost and MRP/margin (:6660).
  c.tagCost = f2(n(c.krLbrAmt) + n(c.krOthAmt) + n(c.amount));
  c.krCost = c.tagCost;
  c.mrp = f2(r0(n(c.tagCost) * (1 + n(c.margin) / 100)));
  return c;
}

function labour(
  type: string,
  rate: number,
  c: TagSplitChildCells,
  settings: TagSplitSettings,
  karigar = false,
): number {
  if (rate === 0) return karigar ? n(c.krLbrAmt) : n(c.lbrAmt);
  const net = karigar ? n(c.krNetWt) : n(c.netWt);
  const ght = karigar ? n(c.krGhtWt) : n(c.ghtWt);
  switch (type) {
    case 'P':
      return r0(n(c.pcs) * rate);
    case 'N':
      return settings.labourIncludesGhat ? r0((net + ght) * rate) : r0(net * rate);
    case 'K':
      return r0((net + ght) * (rate / 1000));
    default:
      return r0(n(c.grossWt) * rate);
  }
}

/** One child stone row (`MSG_RTN_IDTL`). */
export interface TagSplitStoneCells {
  pcs: number;
  pcsWt: number;
  karigarWt: number;
  karigarActPct: number;
  weight: number;
  karigarLessPct: number;
  conPct: number;
  rateType: string;
  rate: number;
  amount: number;
  karigarRate: number;
  karigarAmount: number;
  lbrRate: number;
  lbrAmount: number;
  netAmount: number;
  conWt: number;
  karigarConWt: number;
}

/**
 * `CommPassTotal_Rtn_Idtl` (TR_TAG_SPLIT.cs:4758-4886): one stone row. Weight = pcs x pcsWt (or from the karigar
 * weight); ConWt = weight x Con%, KrConWt = karigarWt x Con%; item amount by P/W; labour = pcs x labour rate; net =
 * amount + labour. Cells the formula does not reach keep their value.
 */
export function tagSplitStone(input: TagSplitStoneCells): TagSplitStoneCells {
  const s: TagSplitStoneCells = { ...input };
  if (n(s.karigarWt) !== 0) {
    s.weight = f3(n(s.pcs) * n(s.pcsWt) || n(s.weight));
    if (n(s.karigarActPct) !== 0)
      s.karigarWt = f3(n(s.pcs) * n(s.pcsWt) * (n(s.karigarActPct) / 100));
  } else {
    s.weight = f3(n(s.pcs) * n(s.pcsWt) || n(s.weight));
  }
  const base = n(s.pcs) * n(s.pcsWt);
  if (base !== 0) s.weight = f3(base);
  s.conWt = n(s.weight) !== 0 && n(s.conPct) !== 0 ? f3(n(s.weight) * n(s.conPct)) : 0;
  s.karigarConWt = n(s.karigarWt) !== 0 && n(s.conPct) !== 0 ? f3(n(s.karigarWt) * n(s.conPct)) : 0;
  const rate = n(s.rate);
  const perPiece = code(s.rateType);
  if (perPiece === '') {
    if (n(s.weight) === 0 && n(s.pcs) !== 0 && rate !== 0) s.amount = f2(rate * n(s.pcs));
    else if (n(s.weight) !== 0 && rate !== 0) s.amount = f2(rate * n(s.weight));
  } else if (perPiece === 'P' && roundHalfEven(rate, 0) !== 0) {
    s.amount = f2(rate * n(s.pcs));
  } else if (rate !== 0) {
    s.amount = f2(rate * n(s.weight));
  }
  if (n(s.lbrRate) !== 0) s.lbrAmount = f2(n(s.lbrRate) * n(s.pcs));
  if (n(s.amount) + n(s.lbrAmount) !== 0) s.netAmount = f2(n(s.amount) + n(s.lbrAmount));
  return s;
}

/**
 * The effect of a child's stones on the child row (`CommPassTotal_Rtn_Idtl` aggregate, :4896-4910): a non-zero
 * Σ ConWt becomes the less weight and net = gross − Σ; a non-zero Σ KrConWt becomes KrOthWt and karigar net =
 * gross − Σ; a non-zero Σ NetAmt becomes the other amount; a non-zero Σ KrAmt becomes KrOthAmt. A zero sum leaves the
 * cell alone (removing every stone does not clear it), matching the desktop.
 */
export function tagSplitStoneEffect(
  row: {
    grossWt: number;
    lessWt: number;
    netWt: number;
    krOthWt: number;
    krNetWt: number;
    othAmt: number;
    krOthAmt: number;
  },
  stones: ReadonlyArray<
    Pick<TagSplitStoneCells, 'conWt' | 'karigarConWt' | 'netAmount' | 'karigarAmount'>
  >,
): {
  lessWt: number;
  netWt: number;
  krOthWt: number;
  krNetWt: number;
  othAmt: number;
  krOthAmt: number;
} {
  let conWt = 0;
  let krConWt = 0;
  let netAmount = 0;
  let krAmount = 0;
  for (const s of stones) {
    conWt += n(s.conWt);
    krConWt += n(s.karigarConWt);
    netAmount += n(s.netAmount);
    krAmount += n(s.karigarAmount);
  }
  const out = {
    lessWt: n(row.lessWt),
    netWt: n(row.netWt),
    krOthWt: n(row.krOthWt),
    krNetWt: n(row.krNetWt),
    othAmt: n(row.othAmt),
    krOthAmt: n(row.krOthAmt),
  };
  if (conWt !== 0) {
    out.lessWt = f3(conWt);
    out.netWt = f3(n(row.grossWt) - conWt);
  }
  if (krConWt !== 0) {
    out.krOthWt = f3(krConWt);
    out.krNetWt = f3(n(row.grossWt) - krConWt);
  }
  if (netAmount !== 0) out.othAmt = f2(netAmount);
  if (krAmount !== 0) out.krOthAmt = f2(krAmount);
  return out;
}

/** `MSG_PR_TOT_FILL` (:6707-6772): the child grid totals, signed by each row's ITM_SIGN. */
export interface TagSplitTotals {
  pcs: number;
  grossWt: number;
  lessWt: number;
  netWt: number;
  ghtWt: number;
  fine: number;
  lbrAmt: number;
  othAmt: number;
  amount: number;
  mrp: number;
  krNetWt: number;
  krFine: number;
}

export function tagSplitTotals(
  rows: ReadonlyArray<Partial<TagSplitChildCells> & { sign?: string }>,
): TagSplitTotals {
  const t: TagSplitTotals = {
    pcs: 0,
    grossWt: 0,
    lessWt: 0,
    netWt: 0,
    ghtWt: 0,
    fine: 0,
    lbrAmt: 0,
    othAmt: 0,
    amount: 0,
    mrp: 0,
    krNetWt: 0,
    krFine: 0,
  };
  for (const row of rows) {
    const s = code(row.sign) === '' ? 1 : code(row.sign) === '+' ? 1 : -1;
    t.pcs += s * n(row.pcs);
    t.grossWt += s * n(row.grossWt);
    t.lessWt += s * n(row.lessWt);
    t.netWt += s * n(row.netWt);
    t.ghtWt += s * n(row.ghtWt);
    t.fine += s * n(row.fine);
    t.lbrAmt += s * n(row.lbrAmt);
    t.othAmt += s * n(row.othAmt);
    t.amount += s * n(row.amount);
    t.mrp += s * n(row.mrp);
    t.krNetWt += s * n(row.krNetWt);
    t.krFine += s * n(row.krFine);
  }
  return {
    pcs: t.pcs,
    grossWt: f3(t.grossWt),
    lessWt: f3(t.lessWt),
    netWt: f3(t.netWt),
    ghtWt: f3(t.ghtWt),
    fine: f3(t.fine),
    lbrAmt: f2(t.lbrAmt),
    othAmt: f2(t.othAmt),
    amount: f2(t.amount),
    mrp: f3(t.mrp),
    krNetWt: f3(t.krNetWt),
    krFine: f3(t.krFine),
  };
}

export interface TagSplitBalance {
  /** Parent net exceeds child net (short/issued): the difference goes to the debit side. */
  drWt: number;
  /** Child net exceeds parent net (surplus/received): the difference goes to the credit side. */
  crWt: number;
  drFine: number;
  crFine: number;
}

/**
 * `BILL_TOTAL` (TR_TAG_SPLIT.cs:12200-12256): the conservation balance between the parent net total and the child
 * net total, and its fine at the operator's touch. A zero difference is exact conservation.
 */
export function tagSplitBalance(input: {
  parentNet: number;
  childNet: number;
  drTouch: number;
  crTouch: number;
}): TagSplitBalance {
  const parent = n(input.parentNet);
  const child = n(input.childNet);
  const drWt = parent > child ? f3(parent - child) : 0;
  const crWt = child > parent ? f3(child - parent) : 0;
  const drTouch = n(input.drTouch);
  const crTouch = n(input.crTouch);
  return {
    drWt,
    crWt,
    drFine: drWt !== 0 && drTouch !== 0 ? f3(drWt * (drTouch / 100)) : f3(drWt),
    crFine: crWt !== 0 && crTouch !== 0 ? f3(crWt * (crTouch / 100)) : f3(crWt),
  };
}

/** Conservation holds when the parent and child net totals are equal within the given tolerance (K7.2). */
export function tagSplitConserves(parentNet: number, childNet: number, tolerance = 0.001): boolean {
  return Math.abs(f3(n(parentNet)) - f3(n(childNet))) <= tolerance;
}
