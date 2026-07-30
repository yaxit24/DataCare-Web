import { withTenant } from '@datacare/db';
import { insertRowTx } from '../posting/posting.js';

/**
 * `TAG_DATA` — the tag-image transfer queue written by the desktop's `UT_AI_TRFR` utility.
 *
 * The desktop utility walks tags that have an image and stages one row per tag so another machine can
 * pick the images up: `CO_HDD` names the source drive/machine and `LOGIN_NAME` the operator who queued
 * it. `IMG_ID` links the row to the stored image.
 *
 * Ported because the table exists in the restored production schema and the desktop writes it. What is
 * deliberately NOT ported is the desktop's file-share copy step: the web keeps images in the database, so
 * the queue records intent and the image is already reachable without moving a file. That difference is
 * the same one behind the waived `Please Check Len Connection...You Cant Save Image...` message.
 */
export const TAG_DATA_COLUMNS = [
  'CO_HDD',
  'CO_CODE',
  'LC_CODE',
  'TAG_NO',
  'VCH_SRNO',
  'LOGIN_NAME',
  'SR_NO',
  'VCH_DATE',
  'PR_NAME',
  'ITM_GWT',
  'ITM_NWT',
  'IMG_ID',
] as const;

export interface TagImageTransferRow {
  tagNo: string;
  vchSrno?: number;
  srNo?: number;
  vchDate?: Date | string | null;
  /** `PR_NAME` — the product the tag belongs to, shown while transferring. */
  productName?: string;
  grossWt?: number;
  netWt?: number;
  /** `IMG_ID` — the stored image this row refers to. */
  imageId?: string;
}

export interface TagImageTransferScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  /** `CO_HDD` — the source machine/drive identifier the desktop stamps on every queued row. */
  sourceHdd?: string;
  /** `LOGIN_NAME` — the operator who queued the transfer. */
  loginName?: string;
}

const n = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
const t = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;

/**
 * Queue tag images for transfer, replacing any previous queue for the company.
 *
 * Replacing rather than appending matches the desktop: the utility builds the list it is about to
 * transfer, so a re-run should not re-queue rows from an earlier attempt.
 */
export async function queueTagImageTransfer(
  prisma: any,
  scope: TagImageTransferScope,
  rows: TagImageTransferRow[],
): Promise<number> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "TAG_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      scope.tenantId,
      scope.coCode,
    );
    let written = 0;
    for (const [index, row] of rows.entries()) {
      const tagNo = t(row.tagNo, 15);
      if (!tagNo) continue; // a queue entry without a tag identifies nothing
      await insertRowTx(tx, 'TAG_DATA', scope.tenantId, {
        CO_HDD: t(scope.sourceHdd, 255),
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        TAG_NO: tagNo,
        VCH_SRNO: n(row.vchSrno),
        LOGIN_NAME: t(scope.loginName, 255),
        SR_NO: row.srNo ?? index + 1,
        VCH_DATE: row.vchDate ? new Date(row.vchDate) : null,
        PR_NAME: t(row.productName, 40),
        ITM_GWT: n(row.grossWt),
        ITM_NWT: n(row.netWt),
        IMG_ID: t(row.imageId, 255),
      });
      written += 1;
    }
    return written;
  });
}
