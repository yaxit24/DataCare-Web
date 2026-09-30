import { round, roundHalfEven } from './money.js';

/**
 * TR_TAG_CAN grid arithmetic (Tag Cancel / Tag Transfer), shared by the writer (apps/api `stock/tagCancel.ts`) and the
 * screen (`apps/web/lib/tagCancelVoucher.ts`), so the row the operator sees is the row that is saved.
 *
 * Desktop source: TR_TAG_CAN.cs (sha256/16 04e7ae5842f63116) — `CommPassTotal` 3107-3680 (the main grid, column
 * numbers below are that grid's), `CommPassTotal_Idtl` 2279-2424 (the stone grid and its effect on the row) and
 * `MSG_TOT_FILL` 2762-2810 (the totals row).
 *
 * The desktop recomputes a row whenever the operator leaves a numeric cell. It does not recompute blindly: it compares
 * gross, net, touch and wastage (and the karigar net, touch and wastage) with the value each had the last time the row
 * was computed — hidden columns 56, 57, 60, 61, 62, 63 and 64 — and only a CHANGED input re-derives what depends on it.
 * A stored or typed fine therefore survives until net, touch or wastage changes. `tagCancelRecompute` takes that
 * baseline and returns the updated one, so a caller that runs it on every cell commit reproduces the desktop's event
 * order exactly, and a caller that runs it once (the API) gets the result of editing the cells in one go.
 *
 * Rounding follows the two desktop mechanisms (money.ts): `Strings.Format(x, "0.000"/"0.00")` is half-up and
 * `Math.Round(x, 0)` is half-to-even, in the desktop's operand order.
 */

/** Company settings the grid reads. */
export interface TagCancelSettings {
  /**
   * `CO_SET_NEW.LBR_WITH_GHT` (`MsLbrWithGht`, blank is 'Y', MS_OPNCOMP.cs:1224-1226). Net-wise labour ('N') is on the
   * net weight alone only when this is 'N'; otherwise on net + ghat (TR_TAG_CAN.cs `CommPassTotal`, labour 'N').
   */
  labourIncludesGhat: boolean;
}

/** The cells of one grid row that `CommPassTotal` reads or writes (column numbers are TR_TAG_CAN's `MSG`). */
export interface TagCancelCells {
  /** Col 1 is filled: a tag line. A loose line copies its own figures into the karigar block. */
  tagged: boolean;
  /** Col 10. */
  pcs: number;
  /** Col 11 GrWt. */
  grossWt: number;
  /** Col 12 LsWt. */
  lessWt: number;
  /** Col 13 NetWt. */
  netWt: number;
  /** Col 15 GhtWt — typed; the Ght% column (14) never drives it on this form. */
  ghtWt: number;
  /** Col 16 Touch. */
  touch: number;
  /** Col 17 West%. */
  westPct: number;
  /** Col 18 Fine. */
  fine: number;
  /** Col 23 LType: P pieces, N net, K per kg, anything else gross. */
  lbrType: string;
  /** Col 24 LbrRate. */
  lbrRate: number;
  /** Col 25 LbrAmt — typed when there is no labour rate. */
  lbrAmt: number;
  /** Col 29 KrOthWt (from the stones' karigar conversion weight). */
  krOthWt: number;
  /** Col 30 KrNwt. */
  krNetWt: number;
  /** Col 32 KrGht. */
  krGhtWt: number;
  /** Col 33 KrTouch. */
  krTouch: number;
  /** Col 34 KrWst%. */
  krWestPct: number;
  /** Col 35 KrFine. */
  krFine: number;
  /** Col 41 ItRate. */
  rate: number;
  /** Col 42 ItAmt. */
  amount: number;
  /** Col 48 RATE_TYPE: P per piece, 1 per 10 g, K per kg, anything else per gram. */
  rateType: string;
}

/**
 * The values each input had when the row was last computed: cols 56 (gross), 57 (net), 60 (touch), 61 (wastage),
 * 62 (karigar net), 63 (karigar touch) and 64 (karigar wastage).
 *
 * A tag fill sets 56/57/60/61 to the tag's figures (TR_TAG_CAN.cs:4028-4043) and a reopened voucher sets them to the
 * saved ones (`DISPLAY_DATA`), but NOTHING ever sets 62/63/64 on load — so the first recompute of any row re-derives
 * its karigar fine. `baselineFromCells` reproduces exactly that.
 */
export interface TagCancelBaseline {
  grossWt: number;
  netWt: number;
  touch: number;
  westPct: number;
  krNetWt: number;
  krTouch: number;
  krWestPct: number;
}

export interface TagCancelRecomputed {
  cells: TagCancelCells;
  baseline: TagCancelBaseline;
}

/** One stone row (`MSG_IDTL`, TR_TAG_CAN.cs:1865-1953). */
export interface TagCancelStoneCells {
  /** Col 3. */
  pcs: number;
  /** Col 4 Weight (IT_GWT). */
  grossWt: number;
  /** Col 5 KrWt. */
  karigarWt: number;
  /** Col 6 Con%. */
  conPct: number;
  /** Col 7 P/W: blank, P per piece, anything else per weight. */
  rateType: string;
  /** Col 8. */
  rate: number;
  /** Col 9 ItAmt. */
  amount: number;
  /** Col 10. */
  lbrRate: number;
  /** Col 11 LbrAmt. */
  lbrAmount: number;
  /** Col 12 NetAmt. */
  netAmount: number;
  /** Col 13 ConWt (hidden). */
  conWt: number;
  /** Col 14 KrConWt (hidden). */
  karigarConWt: number;
}

/** `MSG_TOT_FILL` (TR_TAG_CAN.cs:2762-2810): the totals row. */
export interface TagCancelTotals {
  pcs: number;
  bagWt: number;
  grossWt: number;
  lessWt: number;
  netWt: number;
  ghtWt: number;
  fine: number;
  amount: number;
  lbrAmt: number;
  othAmt: number;
  mrp: number;
  krNetWt: number;
  krFine: number;
}

/** The figures a totals row and the save's row filter read. */
export interface TagCancelTotalsRow {
  pcs?: number;
  bagWt?: number;
  grossWt?: number;
  lessWt?: number;
  netWt?: number;
  ghtWt?: number;
  fine?: number;
  amount?: number;
  lbrAmt?: number;
  othAmt?: number;
  mrp?: number;
  krNetWt?: number;
  krFine?: number;
}

const n = (value: unknown): number => {
  const x = Number(value ?? 0);
  return Number.isFinite(x) ? x : 0;
};
const code = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);

/** `Strings.Format(x, "0.000")` — weights and fine. */
const f3 = (x: number): number => round(x, 3);
/** `Strings.Format(x, "0.00")` — percentages and money cells. */
const f2 = (x: number): number => round(x, 2);
/** `Math.Round(x, 0)` — banker's rounding to whole rupees. */
const r0 = (x: number): number => roundHalfEven(x, 0);

/**
 * The baseline a freshly loaded row carries: its own gross, net, touch and wastage, and ZERO for the karigar block,
 * which neither the tag fill nor `DISPLAY_DATA` ever sets. A new row (`CommPassAdd`) is all zeros.
 */
export function baselineFromCells(
  cells: Pick<TagCancelCells, 'grossWt' | 'netWt' | 'touch' | 'westPct'> | null,
): TagCancelBaseline {
  return {
    grossWt: cells ? f3(n(cells.grossWt)) : 0,
    netWt: cells ? f3(n(cells.netWt)) : 0,
    touch: cells ? f2(n(cells.touch)) : 0,
    westPct: cells ? f2(n(cells.westPct)) : 0,
    krNetWt: 0,
    krTouch: 0,
    krWestPct: 0,
  };
}

/**
 * `CommPassTotal`, TR_TAG_CAN.cs:3107-3680, step for step.
 *
 *  1. Gross changed (col 11 ≠ 56): record it, net = gross − less, and karigar net = gross − KrOthWt when both karigar
 *     cells are non-zero. Then, whenever less and gross are both non-zero, net = gross − less (unconditionally).
 *  2. Net changed (13 ≠ 57): record it; with a purity (touch + wastage ≠ 0) and a net, fine = (net + ghat) ×
 *     (touch + wastage) / 100, otherwise fine = net. Touch changed (16 ≠ 60) or wastage changed (17 ≠ 61): record it
 *     and, with a purity and a net, re-derive the fine the same way.
 *  3. No purity: fine = net + ghat. A zero fine with a purity: re-derived.
 *  4. Loose line: the karigar block copies net, touch, wastage and fine. Tag line: karigar net = gross − KrOthWt when
 *     both are non-zero, and the karigar fine follows the same changed-input rule on cols 30/33/34 against 62/63/64,
 *     or = karigar net + karigar ghat with no karigar purity.
 *  5. Item amount (col 42), when rate and fine are non-zero, by RATE_TYPE: P pcs × rate, 1 fine × (rate / 10),
 *     K fine × (rate / 1000), else fine × rate — `Math.Round(…, 0)`.
 *  6. Labour (col 25), when the labour rate is non-zero, by LType: P pcs × rate; N net × rate when LBR_WITH_GHT is
 *     'N', else (net + ghat) × rate; K (net + ghat) × (rate / 1000); anything else gross × rate — `Math.Round(…, 0)`.
 */
export function tagCancelRecompute(
  input: TagCancelCells,
  prior: TagCancelBaseline,
  settings: TagCancelSettings,
): TagCancelRecomputed {
  const c: TagCancelCells = { ...input };
  const b: TagCancelBaseline = { ...prior };
  const changed3 = (value: number, last: number) => f3(n(value)) !== f3(n(last));
  const changed2 = (value: number, last: number) => f2(n(value)) !== f2(n(last));
  const purity = () => n(c.touch) + n(c.westPct);
  const purityFine = () => f3(((n(c.netWt) + n(c.ghtWt)) * (n(c.touch) + n(c.westPct))) / 100);

  // 1. Gross (IL_0015 … IL_01f1).
  if (changed3(c.grossWt, b.grossWt)) {
    b.grossWt = f3(n(c.grossWt));
    c.netWt = f3(n(c.grossWt) - n(c.lessWt));
    if (n(c.krOthWt) !== 0 && n(c.krNetWt) !== 0) c.krNetWt = f3(n(c.grossWt) - n(c.krOthWt));
  }
  if (n(c.lessWt) !== 0 && n(c.grossWt) !== 0) c.netWt = f3(n(c.grossWt) - n(c.lessWt));

  // 2. Net, touch, wastage (IL_01f1 … IL_0603).
  if (changed3(c.netWt, b.netWt)) {
    b.netWt = f3(n(c.netWt));
    c.fine = purity() !== 0 && n(c.netWt) !== 0 ? purityFine() : f3(n(c.netWt));
  }
  if (changed2(c.touch, b.touch)) {
    b.touch = f2(n(c.touch));
    if (purity() !== 0 && n(c.netWt) !== 0) c.fine = purityFine();
  }
  if (changed2(c.westPct, b.westPct)) {
    b.westPct = f2(n(c.westPct));
    if (purity() !== 0 && n(c.netWt) !== 0) c.fine = purityFine();
  }

  // 3. No purity, or a lost fine (IL_0603 … IL_0761).
  if (purity() === 0) c.fine = f3(n(c.netWt) + n(c.ghtWt));
  if (n(c.fine) === 0 && purity() !== 0) c.fine = purityFine();

  // 4. The karigar block (IL_0761 … IL_0d8d).
  if (!c.tagged) {
    c.krNetWt = f3(n(c.netWt));
    c.krTouch = f2(n(c.touch));
    c.krWestPct = f2(n(c.westPct));
    c.krFine = f3(n(c.fine));
  } else {
    const krPurity = () => n(c.krTouch) + n(c.krWestPct);
    const krPurityFine = () =>
      f3(((n(c.krNetWt) + n(c.krGhtWt)) * (n(c.krTouch) + n(c.krWestPct))) / 100);
    if (n(c.krOthWt) !== 0 && n(c.grossWt) !== 0) c.krNetWt = f3(n(c.grossWt) - n(c.krOthWt));
    if (changed3(c.krNetWt, b.krNetWt)) {
      b.krNetWt = f3(n(c.krNetWt));
      c.krFine = krPurity() !== 0 && n(c.krNetWt) !== 0 ? krPurityFine() : f3(n(c.krNetWt));
    }
    if (changed2(c.krTouch, b.krTouch)) {
      b.krTouch = f2(n(c.krTouch));
      if (krPurity() !== 0 && n(c.krNetWt) !== 0) c.krFine = krPurityFine();
    }
    if (changed2(c.krWestPct, b.krWestPct)) {
      b.krWestPct = f2(n(c.krWestPct));
      if (krPurity() !== 0 && n(c.krNetWt) !== 0) c.krFine = krPurityFine();
    }
    if (krPurity() === 0) c.krFine = f3(n(c.krNetWt) + n(c.krGhtWt));
  }

  // 5. Item amount (IL_0d8d … IL_0f86).
  const rate = n(c.rate);
  const fine = n(c.fine);
  if (rate !== 0 && fine !== 0) {
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

  // 6. Labour (IL_0f86 … IL_11ea).
  const lbrRate = n(c.lbrRate);
  if (lbrRate !== 0) {
    switch (code(c.lbrType)) {
      case 'P':
        c.lbrAmt = r0(n(c.pcs) * lbrRate);
        break;
      case 'N':
        c.lbrAmt = settings.labourIncludesGhat
          ? r0((n(c.netWt) + n(c.ghtWt)) * lbrRate)
          : r0(n(c.netWt) * lbrRate);
        break;
      case 'K':
        c.lbrAmt = r0((n(c.netWt) + n(c.ghtWt)) * (lbrRate / 1000));
        break;
      default:
        c.lbrAmt = r0(n(c.grossWt) * lbrRate);
    }
  }
  return { cells: c, baseline: b };
}

/**
 * One stone row, `CommPassTotal_Idtl` TR_TAG_CAN.cs:2279-2330:
 * - weight and karigar weight fill each other when one of them is 0;
 * - ConWt = weight × Con% and KrConWt = KrWt × Con% (0.000) when both factors are non-zero, else 0;
 * - item amount by P/W — blank: pcs × rate when there is no weight, weight × rate when there is; P: pcs × rate (when the
 *   rate rounds to a non-zero whole number, the desktop's `((0 - isP) & (long)Math.Round(rate)) != 0`); anything else:
 *   weight × rate — "0.00";
 * - labour = pcs × labour rate when there is a labour rate; net = item amount + labour when that is non-zero.
 * Cells the formula does not reach keep their value, as the grid does.
 */
export function tagCancelStone(input: TagCancelStoneCells): TagCancelStoneCells {
  const s: TagCancelStoneCells = { ...input };
  if (n(s.karigarWt) !== 0 && n(s.grossWt) === 0) s.grossWt = f3(n(s.karigarWt));
  if (n(s.grossWt) !== 0 && n(s.karigarWt) === 0) s.karigarWt = f3(n(s.grossWt));
  s.conWt = n(s.grossWt) !== 0 && n(s.conPct) !== 0 ? f3(n(s.grossWt) * n(s.conPct)) : 0;
  s.karigarConWt = n(s.karigarWt) !== 0 && n(s.conPct) !== 0 ? f3(n(s.karigarWt) * n(s.conPct)) : 0;
  const rate = n(s.rate);
  const perPiece = code(s.rateType);
  if (perPiece === '') {
    if (n(s.grossWt) === 0 && n(s.pcs) !== 0 && rate !== 0) s.amount = f2(rate * n(s.pcs));
    else if (n(s.grossWt) !== 0 && rate !== 0) s.amount = f2(rate * n(s.grossWt));
  } else if (perPiece === 'P' && roundHalfEven(rate, 0) !== 0) {
    s.amount = f2(rate * n(s.pcs));
  } else if (rate !== 0) {
    s.amount = f2(rate * n(s.grossWt));
  }
  if (n(s.lbrRate) !== 0) s.lbrAmount = f2(n(s.lbrRate) * n(s.pcs));
  if (n(s.amount) + n(s.lbrAmount) !== 0) s.netAmount = f2(n(s.amount) + n(s.lbrAmount));
  return s;
}

/**
 * What a row's stones do to the row, `CommPassTotal_Idtl` TR_TAG_CAN.cs:2330-2370: a non-zero Σ ConWt becomes the
 * less weight and net = gross − Σ; a non-zero Σ KrConWt becomes KrOthWt and karigar net = gross − Σ; a non-zero
 * Σ NetAmt becomes the other amount. A zero sum leaves the cell alone — removing every stone does not clear it.
 */
export function tagCancelStoneEffect(
  row: {
    grossWt: number;
    lessWt: number;
    netWt: number;
    krOthWt: number;
    krNetWt: number;
    othAmt: number;
  },
  stones: ReadonlyArray<Pick<TagCancelStoneCells, 'conWt' | 'karigarConWt' | 'netAmount'>>,
): { lessWt: number; netWt: number; krOthWt: number; krNetWt: number; othAmt: number } {
  let conWt = 0;
  let karigarConWt = 0;
  let netAmount = 0;
  for (const stone of stones) {
    conWt += n(stone.conWt);
    karigarConWt += n(stone.karigarConWt);
    netAmount += n(stone.netAmount);
  }
  const out = {
    lessWt: n(row.lessWt),
    netWt: n(row.netWt),
    krOthWt: n(row.krOthWt),
    krNetWt: n(row.krNetWt),
    othAmt: n(row.othAmt),
  };
  if (conWt !== 0) {
    out.lessWt = f3(conWt);
    out.netWt = f3(n(row.grossWt) - out.lessWt);
  }
  if (karigarConWt !== 0) {
    out.krOthWt = f3(karigarConWt);
    out.krNetWt = f3(n(row.grossWt) - out.krOthWt);
  }
  if (netAmount !== 0) out.othAmt = f2(netAmount);
  if (conWt !== 0) out.netWt = f3(n(row.grossWt) - conWt);
  return out;
}

/**
 * `MSG_TOT_FILL`: each total is re-formatted after every addition, as the desktop accumulates into the cell text.
 * MRP is summed with three decimals (the desktop's own format for col 27's total).
 */
export function tagCancelTotals(rows: ReadonlyArray<TagCancelTotalsRow>): TagCancelTotals {
  const t: TagCancelTotals = {
    pcs: 0,
    bagWt: 0,
    grossWt: 0,
    lessWt: 0,
    netWt: 0,
    ghtWt: 0,
    fine: 0,
    amount: 0,
    lbrAmt: 0,
    othAmt: 0,
    mrp: 0,
    krNetWt: 0,
    krFine: 0,
  };
  for (const row of rows) {
    t.pcs = round(t.pcs + n(row.pcs), 0);
    t.bagWt = f3(t.bagWt + n(row.bagWt));
    t.grossWt = f3(t.grossWt + n(row.grossWt));
    t.lessWt = f3(t.lessWt + n(row.lessWt));
    t.netWt = f3(t.netWt + n(row.netWt));
    t.ghtWt = f3(t.ghtWt + n(row.ghtWt));
    t.fine = f3(t.fine + n(row.fine));
    t.amount = f2(t.amount + n(row.amount));
    t.lbrAmt = f2(t.lbrAmt + n(row.lbrAmt));
    t.othAmt = f2(t.othAmt + n(row.othAmt));
    t.mrp = f3(t.mrp + n(row.mrp));
    t.krNetWt = f3(t.krNetWt + n(row.krNetWt));
    t.krFine = f3(t.krFine + n(row.krFine));
  }
  return t;
}

/**
 * The save's row filter, TR_TAG_CAN.cs:5099: a row is written when it names an item and a tag and carries an MRP, or
 * when pieces + gross + net + labour + other amount is non-zero. Anything else is skipped by the desktop.
 */
export function tagCancelLineQualifies(row: {
  itCode?: string;
  tagNo?: string;
  mrp?: number;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  lbrAmt?: number;
  othAmt?: number;
}): boolean {
  const named = String(row.itCode ?? '').trim() !== '' && String(row.tagNo ?? '').trim() !== '';
  if (named && n(row.mrp) !== 0) return true;
  return n(row.pcs) + n(row.grossWt) + n(row.netWt) + n(row.lbrAmt) + n(row.othAmt) !== 0;
}
