import { RateCutValidationError, round3 } from './rateCut.js';

/**
 * Booked bullion weight for the TR_WH_SALE engine (Bullion Sale, Rate Cut): moved out of rateCut.ts unchanged to keep
 * that file under its size ceiling. `RateCutValidationError` is used only when a draw-down is refused, never while the
 * modules load, so the import cycle with rateCut.ts is harmless.
 */

/**
 * Consume or release booked bullion weight on `BUL_DATA.ADJ_WT`.
 *
 * A bullion booking locks a metal rate for a quantity. Availability is `ITM_GWT - ADJ_WT`, which is
 * exactly how the desktop offers bookings for selection: `AND A.ITM_GWT-A.ADJ_WT > 0`
 * (`TR_BUL_SALE.cs:4508` and `:7410`). A rate cut against a booking must therefore INCREASE
 * `ADJ_WT`, and reversing one must decrease it.
 *
 * The web wrote the link columns on `RATE_CUT_ISU` but never updated `BUL_DATA`, so a booking was
 * never consumed: `ITM_GWT - ADJ_WT` stayed at its full quantity and the same locked-rate booking
 * could be drawn down again and again with no guard. For a bullion desk that is over-delivery at a
 * stale rate, not a display glitch.
 *
 * Statements mirrored:
 *   save         `TR_BUL_SALE.cs:9101`  ADJ_WT = ADJ_WT + (B.ITM_GWT + B.ADJ_WT)
 *   edit/delete  `TR_BUL_SALE.cs:8816`, `:9202`  ADJ_WT = ADJ_WT - (B.ITM_GWT + B.ADJ_WT)
 *
 * Join, verbatim from those statements: `BUL_DATA.CO_YEAR = B.ISU_YRCD`,
 * `CO_BOOK = B.ISU_DBCD`, `VCH_NO = B.ISU_NO`, `OLD_SRNO = B.ISU_SRNO`, plus company and location.
 * Rows whose `ISU_NO` is null are unlinked rate cuts and correctly match nothing.
 *
 * `sign` is +1 to consume and -1 to release, so both directions share one definition and cannot
 * drift apart — the asymmetry between a save and its reversal is exactly how orphaned adjustments
 * appear.
 */
export async function applyBookingDrawDownTx(
  tx: any,
  tenantId: string,
  key: Record<string, unknown>,
  sign: 1 | -1,
): Promise<void> {
  for (const table of ['RATE_CUT_ISU', 'RATE_CUT_REC'] as const) {
    await lockAndValidateBookingDrawDownForTableTx(tx, tenantId, key, sign, table);
    await applyBookingDrawDownForTableTx(tx, tenantId, key, sign, table);
  }
}

interface BookingDrawDownRow {
  line_sr: string;
  yrcd: string | null;
  dbcd: string | null;
  no: string | null;
  srno: number | null;
  draw_wt: number;
}

interface LockedBookingDrawDownRow extends BookingDrawDownRow {
  booking_wt: number;
  adjusted_wt: number;
}

const bookingLineKey = (row: BookingDrawDownRow): string =>
  [row.line_sr, row.yrcd ?? '', row.dbcd ?? '', row.no ?? '', String(row.srno ?? '')].join(
    '\u0000',
  );

const bookingSourceKey = (row: BookingDrawDownRow): string =>
  [row.yrcd ?? '', row.dbcd ?? '', row.no ?? '', String(row.srno ?? '')].join(' / ');

async function lockAndValidateBookingDrawDownForTableTx(
  tx: any,
  tenantId: string,
  key: Record<string, unknown>,
  sign: 1 | -1,
  table: 'RATE_CUT_ISU' | 'RATE_CUT_REC',
): Promise<void> {
  if (sign < 0) return;
  const linkedRows = (await tx.$queryRawUnsafe(
    `SELECT b."SR_NO"::text AS line_sr,b."ISU_YRCD" AS yrcd,b."ISU_DBCD" AS dbcd,
            b."ISU_NO" AS no,b."ISU_SRNO"::float8 AS srno,
            (coalesce(b."ITM_GWT",0) + coalesce(b."ADJ_WT",0))::float8 AS draw_wt
       FROM "${table}" AS b
      WHERE b.tenant_id = $1
        AND b."CO_CODE" = $2
        AND b."LC_CODE" = $3
        AND b."CO_YEAR" = $4
        AND b."CO_BOOK" = $5
        AND b."VCH_NO" = $6
        AND coalesce(b."ISU_NO",'') <> ''`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  )) as BookingDrawDownRow[];
  if (!linkedRows.length) return;

  const lockedRows = (await tx.$queryRawUnsafe(
    `SELECT b."SR_NO"::text AS line_sr,b."ISU_YRCD" AS yrcd,b."ISU_DBCD" AS dbcd,
            b."ISU_NO" AS no,b."ISU_SRNO"::float8 AS srno,
            (coalesce(b."ITM_GWT",0) + coalesce(b."ADJ_WT",0))::float8 AS draw_wt,
            coalesce(a."ITM_GWT",0)::float8 AS booking_wt,
            coalesce(a."ADJ_WT",0)::float8 AS adjusted_wt
       FROM "BUL_DATA" AS a
       JOIN "${table}" AS b
         ON a.tenant_id = b.tenant_id
        AND a."CO_CODE" = b."CO_CODE"
        AND a."LC_CODE" = b."LC_CODE"
        AND a."CO_YEAR" = b."ISU_YRCD"
        AND a."CO_BOOK" = b."ISU_DBCD"
        AND a."VCH_NO" = b."ISU_NO"
        AND a."OLD_SRNO" = b."ISU_SRNO"
      WHERE b.tenant_id = $1
        AND b."CO_CODE" = $2
        AND b."LC_CODE" = $3
        AND b."CO_YEAR" = $4
        AND b."CO_BOOK" = $5
        AND b."VCH_NO" = $6
        AND coalesce(b."ISU_NO",'') <> ''
      FOR UPDATE OF a`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  )) as LockedBookingDrawDownRow[];

  const matchedLines = new Set(lockedRows.map((row) => bookingLineKey(row)));
  const missing = linkedRows.find((row) => !matchedLines.has(bookingLineKey(row)));
  if (missing) {
    throw new RateCutValidationError(
      `${table} line ${missing.line_sr} references missing bullion booking ${bookingSourceKey(missing)}`,
    );
  }

  const bySource = new Map<
    string,
    { requested: number; bookingWt: number; adjustedWt: number; ref: string }
  >();
  for (const row of lockedRows) {
    const sourceKey = bookingSourceKey(row);
    const group = bySource.get(sourceKey) ?? {
      requested: 0,
      bookingWt: Number(row.booking_wt ?? 0),
      adjustedWt: Number(row.adjusted_wt ?? 0),
      ref: sourceKey,
    };
    group.requested = round3(group.requested + Number(row.draw_wt ?? 0));
    bySource.set(sourceKey, group);
  }

  for (const group of bySource.values()) {
    if (group.requested <= 0) continue;
    const available = round3(group.bookingWt - group.adjustedWt);
    if (group.requested - available > 0.0005) {
      throw new RateCutValidationError(
        `bullion booking ${group.ref} has only ${available.toFixed(3)} weight available; requested ${group.requested.toFixed(3)}`,
      );
    }
  }
}

async function applyBookingDrawDownForTableTx(
  tx: any,
  tenantId: string,
  key: Record<string, unknown>,
  sign: 1 | -1,
  table: 'RATE_CUT_ISU' | 'RATE_CUT_REC',
): Promise<void> {
  await tx.$executeRawUnsafe(
    `UPDATE "BUL_DATA" AS a
        SET "ADJ_WT" = coalesce(a."ADJ_WT",0) + $7 * (coalesce(b."ITM_GWT",0) + coalesce(b."ADJ_WT",0))
       FROM "${table}" AS b
      WHERE a.tenant_id = b.tenant_id
        AND a."CO_CODE"  = b."CO_CODE"
        AND a."LC_CODE"  = b."LC_CODE"
        AND a."CO_YEAR"  = b."ISU_YRCD"
        AND a."CO_BOOK"  = b."ISU_DBCD"
        AND a."VCH_NO"   = b."ISU_NO"
        AND a."OLD_SRNO" = b."ISU_SRNO"
        AND b.tenant_id = $1
        AND b."CO_CODE"  = $2
        AND b."LC_CODE"  = $3
        AND b."CO_YEAR"  = $4
        AND b."CO_BOOK"  = $5
        AND b."VCH_NO"   = $6`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
    sign,
  );
}
