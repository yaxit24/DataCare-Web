import { assertSavedVoucherTx } from '../vouchers/lifecycle.js';

/** One rate-cut family voucher (RATE_CUT_DATA serves wholesale, rate cut, quotation, tour and bullion books). */
export type RateCutVoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/**
 * WP-10: a PUT only edits a saved voucher. RATE_CUT_DATA has no unique key on the voucher number, so a PUT that
 * created at the typed URL number (outside the `nextVoucherNoTx` lock) could duplicate a number a concurrent POST
 * was taking. An unused number answers `404 voucher-not-found`; a new voucher is a POST.
 */
export async function assertSavedRateCutTx(
  tx: any,
  tenantId: string,
  key: RateCutVoucherKey,
): Promise<void> {
  await assertSavedVoucherTx(
    tx,
    'RATE_CUT_DATA',
    {
      tenantId,
      coCode: key.CO_CODE,
      lcCode: key.LC_CODE,
      coYear: key.CO_YEAR,
      coBook: key.CO_BOOK,
    },
    key.VCH_NO,
  );
}

/** The stored header of one voucher, locked for the rewrite or delete that follows. */
export async function persistedHeaderTx(
  tx: any,
  tenantId: string,
  key: RateCutVoucherKey,
): Promise<Record<string, unknown> | undefined> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "VCH_DATE","VCH_TIME",to_char("VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK","MAIN_USER",
            "AC_CODE","AC_NAME","SL_NET_AMT"::float8 AS sl_net,"PR_NET_AMT"::float8 AS pr_net,
            "IT_TYPE","TOT_FINE_DR"::float8 AS tot_fine_dr,"TOT_FINE_CR"::float8 AS tot_fine_cr,
            "HD_VCH_NO","VCH_DESC"
       FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
      ORDER BY row_id LIMIT 1 FOR UPDATE`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  return rows[0];
}
