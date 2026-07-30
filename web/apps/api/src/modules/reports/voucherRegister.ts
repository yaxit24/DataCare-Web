import { withTenant } from '@datacare/db';
import type { ReportScope, ListReport } from './reports.js';

/**
 * Phase 12 — Voucher Register (read-only). One row per voucher across every book, built from AC_DATA
 * (the universal posting ledger) in the exact style of reports.ts / reports2-4.ts: withTenant()
 * supplies the e2e-safe tenant context, NN() casts the desktop's text-typed amount columns to
 * numeric, and the dataset returns the uniform ListReport { rows, totals } shape. No mutations.
 *
 * A voucher is the (CO_BOOK, VCH_NO, VCH_TYPE, VCH_DATE) tuple; its many ledger legs are folded into
 * one row carrying the Dr/Cr footings and the leg count. Scoped by CO_CODE (always) plus the optional
 * CO_YEAR, CO_BOOK (the `book` filter) and a VCH_DATE range. Newest first, capped at 500 rows so the
 * browser stays responsive; totals are footed over the returned (capped) set. Verified live against
 * CO_CODE='01' (1567 vouchers / 5150 legs; capped Dr≈Cr 17,272,741.41 vs 17,272,740.05).
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

export async function voucherRegister(
  prisma: any,
  s: ReportScope & { book?: string; fromDate?: string; toDate?: string },
): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    // Build the scope filter positionally: CO_CODE is always $1; the rest are appended only when set.
    const parts = ['"CO_CODE"=$1'];
    const params: unknown[] = [s.coCode];
    let i = 2;
    if (s.coYear) {
      parts.push(`"CO_YEAR"=$${i++}`);
      params.push(s.coYear);
    }
    if (s.book) {
      parts.push(`"CO_BOOK"=$${i++}`);
      params.push(s.book);
    }
    if (s.fromDate) {
      parts.push(`"VCH_DATE">=$${i++}`);
      params.push(new Date(s.fromDate));
    }
    if (s.toDate) {
      parts.push(`"VCH_DATE"<=$${i++}`);
      params.push(new Date(s.toDate));
    }

    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE" AS date, "CO_BOOK" AS book, "VCH_NO" AS voucher, "VCH_TYPE" AS type,
              sum(${NN('"DR_AMT"')}) AS debit, sum(${NN('"CR_AMT"')}) AS credit, count(*)::int AS legs
       FROM "AC_DATA" WHERE ${parts.join(' AND ')}
       GROUP BY "CO_BOOK", "VCH_NO", "VCH_TYPE", "VCH_DATE"
       ORDER BY "VCH_DATE" DESC, "CO_BOOK", "VCH_NO"
       LIMIT 500`,
      ...params,
    );
    const out = rows.map((r) => ({
      date: r.date ?? null,
      book: r.book ?? null,
      voucher: String(r.voucher ?? ''),
      type: r.type ?? null,
      debit: round2(num(r.debit)),
      credit: round2(num(r.credit)),
      legs: Number(r.legs),
    }));
    return {
      rows: out,
      totals: {
        vouchers: out.length,
        debit: round2(out.reduce((t, r) => t + r.debit, 0)),
        credit: round2(out.reduce((t, r) => t + r.credit, 0)),
      },
    };
  });
}
