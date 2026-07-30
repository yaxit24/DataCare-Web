import { DESKTOP_MESSAGES } from './desktopMessages.js';

/**
 * Counter-wise stock (`DC_Main.MsCntrStk`), loaded from `CO_SET_NEW.COUNTER_STK`.
 *
 * When the setting is `'Y'`, `TR_PURC.cs:12868` refuses to save a tag row that carries an item code
 * with a blank counter. When it is anything else the rule does not exist, so it must never be enforced
 * unconditionally — an installation that does not use counters would be unable to save a purchase.
 *
 * `MS_OPNCOMP.cs` defaults the flag to `'N'` when the column is blank, so absence means "not enforced".
 * As with every other policy, the value is read server-side per transaction and never taken from the
 * request body.
 */
export class CounterStockValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'CounterStockValidationError';
  }
}

export interface CounterStockPolicy {
  /** True only when the company setting is exactly 'Y'. */
  enforced: boolean;
}

export function resolveCounterStockPolicy(raw: unknown): CounterStockPolicy {
  const value = String(raw ?? '')
    .trim()
    .slice(0, 1)
    .toUpperCase();
  // MS_OPNCOMP.cs: blank becomes 'N'.
  return { enforced: value === 'Y' };
}

export async function resolveCounterStockPolicyTx(
  tx: any,
  scope: { tenantId: string; coCode: string },
): Promise<CounterStockPolicy> {
  const rows: Array<{ counter_stk: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "COUNTER_STK" AS counter_stk FROM "CO_SET_NEW"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  return resolveCounterStockPolicy(rows[0]?.counter_stk);
}

/**
 * Enforce the desktop's counter rule over a set of tag rows.
 *
 * Desktop condition (`TR_PURC.cs:12868`): with counter-wise stock on, any row whose item code is set
 * must carry a counter code. The desktop reads the item code of the FIRST row (`MSG[1,3]`) as the
 * "grid has items" test and then checks each row's counter, so a grid with no items is not blocked.
 */
export function assertCounterCodes(
  policy: CounterStockPolicy,
  lines: Array<{ itCode?: unknown; tblCode?: unknown }>,
): void {
  if (!policy.enforced) return;
  const hasItems = lines.some((l) => String(l.itCode ?? '').trim() !== '');
  if (!hasItems) return;
  for (const line of lines) {
    if (String(line.itCode ?? '').trim() === '') continue;
    if (String(line.tblCode ?? '').trim() === '') {
      throw new CounterStockValidationError(DESKTOP_MESSAGES.TAG_COUNTER_MANDATORY);
    }
  }
}

/**
 * Hallmark ID weights (`TR_PURC.cs`): an ID that is filled in must carry a non-zero weight.
 * Desktop condition per slot: `tHmId<n> <> '' AND Val(nHmWt<n>) = 0`.
 */
export interface HallmarkWeightLine {
  hallmarkId2?: unknown;
  hallmarkId2Wt?: unknown;
  hallmarkId3?: unknown;
  hallmarkId3Wt?: unknown;
  hallmarkId4?: unknown;
  hallmarkId4Wt?: unknown;
}

export function assertHallmarkWeights(
  line: HallmarkWeightLine,
  messages: {
    id2: string;
    id3: string;
    id4: string;
  } = {
    id2: DESKTOP_MESSAGES.HALLMARK_ID2_WEIGHT,
    id3: DESKTOP_MESSAGES.HALLMARK_ID3_WEIGHT,
    id4: DESKTOP_MESSAGES.HALLMARK_ID4_WEIGHT,
  },
): void {
  const values = line as Record<string, unknown>;
  const pairs: Array<[string, string, string]> = [
    ['hallmarkId2', 'hallmarkId2Wt', messages.id2],
    ['hallmarkId3', 'hallmarkId3Wt', messages.id3],
    ['hallmarkId4', 'hallmarkId4Wt', messages.id4],
  ];
  for (const [idKey, wtKey, message] of pairs) {
    const id = String(values[idKey] ?? '').trim();
    if (!id) continue;
    if (Number(values[wtKey] ?? 0) === 0) throw new CounterStockValidationError(message);
  }
}

/**
 * Stock-adjust entry sign (`TR_INOUT.cs`).
 *
 * Desktop condition: the form's MAIN_BOOK is `STOCK ADJUST` **and** the entry text is neither `+` nor
 * `-`. Only stock-adjust books expose a free-form sign; every other book derives the sign from the
 * voucher type, so the guard must stay gated on the book rather than applied everywhere.
 */
export function assertItemSign(mainBook: unknown, sign: unknown): void {
  if (
    String(mainBook ?? '')
      .trim()
      .toUpperCase() !== 'STOCK ADJUST'
  )
    return;
  const value = String(sign ?? '').trim();
  if (value !== '+' && value !== '-') {
    throw new CounterStockValidationError(DESKTOP_MESSAGES.ITEM_SIGN_REQUIRED);
  }
}

/** TR_TOUR_SALE.cs: a negative wastage percentage cannot be adjusted. */
export function assertWestPct(westPct: unknown): void {
  if (Number(westPct ?? 0) < 0) {
    throw new CounterStockValidationError(DESKTOP_MESSAGES.NEGATIVE_WEST_NOT_ALLOWED);
  }
}
