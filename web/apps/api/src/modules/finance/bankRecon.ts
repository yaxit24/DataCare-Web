import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTenant } from '@datacare/db';

/**
 * Bank Reconciliation (desktop "Bank Reconciliation"): the bank's authoritative ledger is its AC_DATA
 * rows; a transaction is "cleared" when it carries a CLR_DATE. Book balance = Σ(DR−CR); cleared balance
 * = Σ(DR−CR) over rows with a CLR_DATE; uncleared (in-transit) = book − cleared. The screen lists the
 * bank's txns, lets the operator tick + date the cleared ones, and shows the cleared-vs-book "Bal Chk".
 */
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

export interface BankTxn {
  coBook: string;
  vchNo: string;
  vchType: string;
  vchDate: string | null;
  acName: string;
  chqNo: string;
  dr: number;
  cr: number;
  amtBal: number;
  clrDate: string | null;
}
export interface BankReconList {
  bankAc: string;
  bankName: string;
  openingBal: number;
  rows: BankTxn[];
  book: number;
  cleared: number;
  uncleared: number;
}

export async function bankReconList(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  bankAc: string,
  range?: { from?: string; to?: string },
): Promise<BankReconList> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const cond: string[] = [`a."CO_CODE"=$1`, `a."AC_CODE"=$2`];
    const params: unknown[] = [scope.coCode, bankAc];
    if (range?.from) {
      params.push(range.from);
      cond.push(`a."VCH_DATE"::date >= $${params.length}::date`);
    }
    if (range?.to) {
      params.push(range.to);
      cond.push(`a."VCH_DATE"::date <= $${params.length}::date`);
    }
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a."CO_BOOK" cob, a."VCH_NO" vch, coalesce(a."VCH_TYPE",'') vt, a."VCH_DATE"::text vd,
              coalesce(NULLIF(a."DR_AMT"::text,'')::numeric,0)::float dr, coalesce(NULLIF(a."CR_AMT"::text,'')::numeric,0)::float cr, a."CLR_DATE"::text clr,
              coalesce((SELECT ch."AC_NAME" FROM "CASH_DATA" ch WHERE ch."CO_CODE"=a."CO_CODE" AND ch."CO_BOOK"=a."CO_BOOK" AND ch."VCH_NO"=a."VCH_NO" LIMIT 1),
                       (SELECT py."AC_NAME" FROM "PAY_DATA" py WHERE py."CO_CODE"=a."CO_CODE" AND py."CO_BOOK"=a."CO_BOOK" AND py."VCH_NO"=a."VCH_NO" LIMIT 1), '') acname,
              coalesce((SELECT ch."CHQ_NO" FROM "CASH_DATA" ch WHERE ch."CO_CODE"=a."CO_CODE" AND ch."CO_BOOK"=a."CO_BOOK" AND ch."VCH_NO"=a."VCH_NO" LIMIT 1),
                       (SELECT py."CHQ_NO" FROM "PAY_DATA" py WHERE py."CO_CODE"=a."CO_CODE" AND py."CO_BOOK"=a."CO_BOOK" AND py."VCH_NO"=a."VCH_NO" LIMIT 1), '') chq
       FROM "AC_DATA" a WHERE ${cond.join(' AND ')} ORDER BY a."VCH_DATE" NULLS LAST, a."VCH_NO"`,
      ...params,
    );
    // Opening balance carried into the range: net of the bank's AC_DATA before the From date.
    let openingBal = 0;
    if (range?.from) {
      const pr: any[] = await tx.$queryRawUnsafe(
        `SELECT coalesce(sum(coalesce(NULLIF("DR_AMT"::text,'')::numeric,0)-coalesce(NULLIF("CR_AMT"::text,'')::numeric,0)),0)::float n FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 AND "VCH_DATE"::date < $3::date`,
        scope.coCode,
        bankAc,
        range.from,
      );
      openingBal = r2(Number(pr[0]?.n ?? 0));
    }
    const nameRow: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_NAME" nm FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      scope.coCode,
      bankAc,
    );
    const bankName = String(nameRow[0]?.nm ?? bankAc);
    let book = 0,
      cleared = 0,
      run = openingBal;
    const out: BankTxn[] = rows.map((r) => {
      const net = Number(r.dr) - Number(r.cr);
      book += net;
      run = r2(run + net);
      if (r.clr) cleared += net;
      return {
        coBook: String(r.cob ?? ''),
        vchNo: String(r.vch ?? ''),
        vchType: String(r.vt ?? ''),
        vchDate: r.vd ? String(r.vd).slice(0, 10) : null,
        acName: String(r.acname ?? ''),
        chqNo: String(r.chq ?? ''),
        dr: Number(r.dr),
        cr: Number(r.cr),
        amtBal: run,
        clrDate: r.clr ? String(r.clr).slice(0, 10) : null,
      };
    });
    book = r2(book + openingBal);
    cleared = r2(cleared + openingBal);
    return {
      bankAc,
      bankName,
      openingBal,
      rows: out,
      book,
      cleared,
      uncleared: r2(book - cleared),
    };
  });
}

export interface BankClearItem {
  coBook: string;
  vchNo: string;
  clrDate?: string | null;
}

/** Mark/unmark the bank's ledger rows of given vouchers as cleared (CLR_DATE = date, or null to un-clear). */
export async function bankReconClear(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  bankAc: string,
  items: BankClearItem[],
): Promise<{ updated: number }> {
  const clean = (items ?? []).filter((i) => i && i.coBook && i.vchNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    let updated = 0;
    for (const it of clean) {
      const clr = it.clrDate && String(it.clrDate).trim() ? String(it.clrDate).slice(0, 10) : null;
      const n: number = await tx.$executeRawUnsafe(
        `UPDATE "AC_DATA" SET "CLR_DATE" = $4::date WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$5`,
        scope.coCode,
        bankAc,
        it.coBook,
        clr,
        formatVoucherNo(it.vchNo),
      );
      updated += Number(n) || 0;
    }
    return { updated };
  });
}
