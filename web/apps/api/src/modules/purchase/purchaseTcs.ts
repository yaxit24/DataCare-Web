import { roundHalfEven } from '@datacare/core';

/**
 * Purchase TCS and the book item type that picks the expense account. Kept out of `purchase.ts` (size ceiling).
 */

const text = (value: unknown): string => String(value ?? '').trim();

/**
 * TR_PURC.cs:15061-15095: TCS = Math.Round((net before discount + tax) × TCS% / 100, 0), half-even, and the bill total
 * adds it before its own rounding (a whole-rupee addition can change a half-even tie). The ledger keeps the pre-TCS
 * total and round-off; three places cover a 2- or 3-decimal bill rounding and drop the float noise of the sum.
 */
export function purchaseTcsTotals(
  totals: { net: number; tax: number; taxable: number; total: number; roundOff: number },
  tcsPct: number,
  roundBillTotal: (value: number) => number,
): { tcs: number; billWithTcs: number; total: number; roundOff: number } {
  const tcs = roundHalfEven(((totals.net + totals.tax) * tcsPct) / 100, 0);
  const billWithTcs = roundBillTotal(totals.taxable + totals.tax + tcs);
  return {
    tcs,
    billWithTcs,
    total: billWithTcs - tcs,
    roundOff: roundHalfEven(totals.roundOff + billWithTcs - tcs - totals.total, 3),
  };
}

/** Ac_Ledr.cs:434: the TCS code's TAX_MAST row with SR_NO 0 gives the TCS account; '' when there is none. */
export async function purchaseTcsAccountTx(
  tx: { $queryRawUnsafe: (...args: any[]) => Promise<any> },
  tenantId: string,
  coCode: string,
  tcsCode: string,
): Promise<string> {
  const rows: Array<{ ac: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "TAX_AC" ac FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"::text=$3::text
      AND coalesce("SR_NO",0)=0 ORDER BY row_id LIMIT 1`,
    tenantId,
    coCode,
    tcsCode,
  );
  return text(rows[0]?.ac);
}

/** BOOK_DATA.ITM_TYPE of the voucher's book: 'A' posts per item group, any other type to slot 1 (Ac_Ledr.cs:410-421). */
export async function purchaseBookItemTypeTx(
  tx: { $queryRawUnsafe: (...args: any[]) => Promise<any> },
  tenantId: string,
  scope: { coCode: string; lcCode: string; coBook?: string },
): Promise<string> {
  const rows: Array<{ ITM_TYPE: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "ITM_TYPE" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
    tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  return text(rows[0]?.ITM_TYPE).toUpperCase();
}
