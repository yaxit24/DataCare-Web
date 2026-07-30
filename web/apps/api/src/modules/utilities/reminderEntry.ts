import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';

/**
 * Manual Reminder Entry (desktop "Reminder Entry"): an ad-hoc reminder — pick an account, write a
 * description and set a reminder date. Stored in REMARK_DATA (book 'REM'). Complements the auto-derived
 * reminder dashboard (overdue receivables / orders due) with operator-entered notes.
 */
export interface ReminderEntryInput {
  scope: VoucherScope;
  acCode?: string;
  acName?: string;
  remark: string;
  remindDate?: Date | string;
  entDate?: Date | string;
}
export interface ReminderEntry {
  vchNo: string;
  entDate: string | null;
  remDate: string | null;
  acCode: string;
  acName: string;
  mobile: string;
  remark: string;
}

export async function createReminderEntry(
  prisma: any,
  input: ReminderEntryInput,
): Promise<{ vchNo: number }> {
  if (!input.remark || !String(input.remark).trim())
    throw new Error('a reminder description is required');
  const tenantId = input.scope.tenantId;
  const remDate = input.remindDate ? new Date(input.remindDate) : new Date();
  const entIso = (input.entDate ? new Date(input.entDate) : new Date()).toISOString().slice(0, 10); // entry date → spare MAIN_BOOK (no ENT_DATE column)
  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, { ...input.scope, coBook: 'REM' });
    await tx.$executeRawUnsafe(
      `INSERT INTO "REMARK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","MAIN_BOOK","AC_CODE","AC_NAME","VCH_REMARK") VALUES ($1,$2,$3,$4,'REM',$5,1,$6,$7,$8,$9,$10)`,
      tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      input.scope.coYear ?? '',
      formatVoucherNo(vchNo),
      remDate,
      entIso,
      input.acCode ?? null,
      input.acName ?? null,
      String(input.remark).trim(),
    );
    return { vchNo };
  });
}

export async function listReminderEntries(
  prisma: any,
  scope: { tenantId: string; coCode: string },
): Promise<ReminderEntry[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT r."VCH_NO" v, r."VCH_DATE"::text rd, coalesce(r."MAIN_BOOK",'') ed, coalesce(r."AC_CODE",'') ac, coalesce(r."AC_NAME",'') nm, coalesce(r."VCH_REMARK",'') rk,
              coalesce((SELECT m."AC_MOBILE" FROM "AC_MAST" m WHERE m."CO_CODE"=r."CO_CODE" AND m."AC_CODE"=r."AC_CODE" LIMIT 1),'') mob
       FROM "REMARK_DATA" r WHERE r."CO_CODE"=$1 AND r."CO_BOOK"='REM' ORDER BY r."VCH_DATE" DESC NULLS LAST, r."VCH_NO" DESC LIMIT 300`,
      scope.coCode,
    );
    return rows.map((r) => ({
      vchNo: String(r.v),
      entDate: r.ed ? String(r.ed).slice(0, 10) : null,
      remDate: r.rd ? String(r.rd).slice(0, 10) : null,
      acCode: String(r.ac),
      acName: String(r.nm),
      mobile: String(r.mob),
      remark: String(r.rk),
    }));
  });
}

export async function deleteReminderEntry(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
  vchNo: string | number,
): Promise<{ reversed: true }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "REMARK_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"='REM' AND "VCH_NO"=$2`,
      scope.coCode,
      formatVoucherNo(vchNo),
    );
    return { reversed: true };
  });
}
