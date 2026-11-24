import type { VoucherScope } from '../vouchers/numbering.js';
import { completeFinanceScope } from './lifecycle.js';

/**
 * Bank clearing marks of a contra voucher (WP-31, decision D8).
 *
 * A cleared bank leg carries its clearing date twice: `AC_DATA.CLR_DATE` and a `BANK_RECONCILE` row keyed by the
 * leg's `LEDR_KEY` (the table the desktop keeps beside the ledger; Data Repair rebuilds it from the ledger).
 * TR_CONTRA deletes and rewrites the AC_DATA legs on every save (TR_CONTRA.cs:2884) and on delete (:2965), and never
 * touches BANK_RECONCILE, so in the desktop a deleted voucher leaves its marks behind and a later voucher that takes
 * the same number (MAX+1, TR_CONTRA.cs:2393) starts out "cleared". The hosted service must not do that:
 *   - edit keeps a mark only for a leg whose key, account and amounts are unchanged;
 *   - delete removes every mark of the voucher's keys.
 * All of it runs inside the caller's transaction.
 */
export interface ClearingMark {
  key: string;
  acCode: string;
  dr: number;
  cr: number;
  clrDate: string;
}

const NUM = (column: string): string => `coalesce(NULLIF(${column}::text,'')::numeric,0)::float8`;

const where = `a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6`;
const params = (scope: VoucherScope, voucherNo: string) => {
  const s = completeFinanceScope(scope);
  return [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook, voucherNo];
};

/** The cleared legs of a voucher, with the clearing date from either store. */
export async function captureClearingTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
): Promise<ClearingMark[]> {
  const rows: Array<{ key: string; ac: string; dr: number; cr: number; clr: string }> =
    await tx.$queryRawUnsafe(
      `SELECT a."LEDR_KEY" "key", btrim(a."AC_CODE") ac, ${NUM('a."DR_AMT"')} dr, ${NUM('a."CR_AMT"')} cr,
              to_char(coalesce(a."CLR_DATE", r."CLR_DATE"),'YYYY-MM-DD') clr
         FROM "AC_DATA" a
         LEFT JOIN "BANK_RECONCILE" r ON r.tenant_id=a.tenant_id AND r."LEDR_KEY"=a."LEDR_KEY"
        WHERE ${where} AND coalesce(a."CLR_DATE", r."CLR_DATE") IS NOT NULL`,
      ...params(scope, voucherNo),
    );
  return rows.map((r) => ({
    key: r.key,
    acCode: r.ac,
    dr: Number(r.dr),
    cr: Number(r.cr),
    clrDate: r.clr,
  }));
}

/** Remove the BANK_RECONCILE rows of the voucher's current legs (call before its AC_DATA rows are deleted). */
export async function dropClearingTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
): Promise<void> {
  await tx.$executeRawUnsafe(
    `DELETE FROM "BANK_RECONCILE" r USING "AC_DATA" a
      WHERE r.tenant_id=a.tenant_id AND r."LEDR_KEY"=a."LEDR_KEY" AND ${where}`,
    ...params(scope, voucherNo),
  );
}

/** Put back the marks whose leg was rewritten with the same key, account and amounts. Returns how many survived. */
export async function restoreClearingTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
  marks: ClearingMark[],
): Promise<number> {
  if (!marks.length) return 0;
  const s = completeFinanceScope(scope);
  const now: Array<{ key: string; ac: string; dr: number; cr: number }> = await tx.$queryRawUnsafe(
    `SELECT a."LEDR_KEY" "key", btrim(a."AC_CODE") ac, ${NUM('a."DR_AMT"')} dr, ${NUM('a."CR_AMT"')} cr
       FROM "AC_DATA" a WHERE ${where}`,
    ...params(scope, voucherNo),
  );
  let kept = 0;
  for (const mark of marks) {
    const same = now.find(
      (n) =>
        n.key === mark.key &&
        n.ac === mark.acCode &&
        Math.abs(Number(n.dr) - mark.dr) < 0.005 &&
        Math.abs(Number(n.cr) - mark.cr) < 0.005,
    );
    if (!same) continue;
    await tx.$executeRawUnsafe(
      `UPDATE "AC_DATA" SET "CLR_DATE"=$3::date WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      s.tenantId,
      mark.key,
      mark.clrDate,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE") VALUES ($1,$2,$3,$4,$5::date)`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      mark.key,
      mark.clrDate,
    );
    kept += 1;
  }
  return kept;
}
