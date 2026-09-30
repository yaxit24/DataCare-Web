import { dateWhere } from './reports.js';
import { withTenant } from '@datacare/db';
import type { ReportScope, ListReport } from './reports.js';
import { applyFilters } from './reportFilters.js';

/**
 * Phase 11 (cont.) — sales-return, karigar and rate-list report datasets, built in the exact style
 * of reports.ts / reports2.ts / reports3.ts: withTenant() supplies the e2e-safe tenant context, NN()
 * casts the desktop's text-typed amount columns to numeric, every dataset is scoped by
 * WHERE "CO_CODE"=$1 and returns the uniform ListReport { rows, totals } shape. All queries are
 * read-only — no mutations.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const round3 = (x: number): number => Math.round((x + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => Number(v ?? 0);

/** Desktop amount columns are text; coalesce empty/non-numeric to 0 before casting to numeric. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/**
 * Sales-return register — one row per sales-return voucher.
 *
 * Adaptation (verified against the live schema): SL_DATA holds NO returns in this dataset — there is
 * no CO_BOOK='SRT' header, SL_DATA has no VCH_TYPE column at all, and every RTN_* amount is zero.
 * Sales returns are stored as SL_DETL_RTN lines, keyed CO_BOOK='SRT' / VCH_TYPE='SRTN'. We therefore
 * build the register from SL_DETL_RTN, aggregated to one row per return voucher, and resolve the
 * party name from AC_MAST (SL_DETL_RTN carries only AC_CODE, no AC_NAME). SL_DETL_RTN's return-tax
 * column is RTN_IT_TAX_AMT (there is no TAX_AMT), and total falls back to taxable+tax when the line's
 * TOT_AMT is blank. Scoped by CO_CODE and the optional CO_YEAR.
 *
 * Desktop-shaped returns (TR_SALE_RTN on a configured book such as R11, VCH_TYPE 'SR') carry neither
 * the web 'SRT' book nor 'SRTN'. The desktop SaleRtnReport selects them by the voucher header:
 * `{SL_DATA.RTN_NET_AMT} <> 0` in the company/year/date window (RP_ALL.cs, SaleRtnReport branch). A
 * voucher is therefore also included when its exact-key SL_DATA header has a non-zero RTN_NET_AMT.
 */
export async function salesReturnRegister(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const yr = s.coYear ? ' AND r."CO_YEAR"=$2' : '';
    const params: unknown[] = s.coYear ? [s.coCode, s.coYear] : [s.coCode];
    // Voucher-date window; appended after params so the positional indices are right.
    const dt = dateWhere(s, 'r."VCH_DATE"', params);
    // Shared RP_ALL panel dimensions. `m` is a real LEFT JOIN here, so party geography is available.
    const fl = applyFilters('sales-return-register', s.filters, params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT max(r."VCH_DATE") AS date, r."CO_BOOK"||'/'||r."VCH_NO" AS voucher,
              max(coalesce(m."AC_NAME", NULLIF(r."AC_CODE"::text,''))) AS party,
              sum(${NN('r."NET_AMT"')}) AS taxable,
              sum(${NN('r."RTN_IT_TAX_AMT"')}) AS tax,
              sum(CASE WHEN ${NN('r."TOT_AMT"')} <> 0 THEN ${NN('r."TOT_AMT"')}
                       ELSE ${NN('r."NET_AMT"')} + ${NN('r."RTN_IT_TAX_AMT"')} END) AS total
       FROM "SL_DETL_RTN" r
       LEFT JOIN "AC_MAST" m ON m."AC_CODE"::text=r."AC_CODE"::text AND m."CO_CODE"::text=r."CO_CODE"::text
       WHERE r."CO_CODE"=$1${yr}${dt}${fl} AND (r."CO_BOOK"='SRT' OR r."VCH_TYPE"='SRTN'
         OR EXISTS (SELECT 1 FROM "SL_DATA" h
                     WHERE h.tenant_id=r.tenant_id AND h."CO_CODE"=r."CO_CODE" AND h."LC_CODE"=r."LC_CODE"
                       AND h."CO_YEAR"=r."CO_YEAR" AND h."CO_BOOK"=r."CO_BOOK" AND h."VCH_NO"=r."VCH_NO"
                       AND ${NN('h."RTN_NET_AMT"')} <> 0))
       GROUP BY r."CO_BOOK", r."VCH_NO" ORDER BY date, voucher`,
      ...params,
    );
    const out = rows.map((r) => ({
      date: r.date ?? null,
      voucher: String(r.voucher ?? ''),
      party: r.party ?? null,
      taxable: round2(num(r.taxable)),
      tax: round2(num(r.tax)),
      total: round2(num(r.total)),
    }));
    return {
      rows: out,
      totals: { count: out.length, total: round2(out.reduce((t, r) => t + r.total, 0)) },
    };
  });
}

/**
 * Karigar (goldsmith) statement (KR_DETL grouped by AC_CODE): fine issued to the karigar
 * (INOUT_TYPE 'O', Σ ITM_FINE), fine received back (INOUT_TYPE 'I', Σ ITM_FINE), the metal balance
 * still with the karigar (issued − received), and the net outstanding pieces (issued pcs − received
 * pcs). Mirrors karigarBalances in reports.ts, adding the received column and net pcs. balanceFine
 * is the company-wide sum of per-karigar balances.
 */
export async function karigarStatement(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" AS "acCode",
              sum(CASE WHEN "INOUT_TYPE"='O' THEN ${NN('"ITM_FINE"')} ELSE 0 END) AS issued,
              sum(CASE WHEN "INOUT_TYPE"='I' THEN ${NN('"ITM_FINE"')} ELSE 0 END) AS received,
              sum(CASE WHEN "INOUT_TYPE"='O' THEN ${NN('"ITM_PCS"')}
                       WHEN "INOUT_TYPE"='I' THEN -${NN('"ITM_PCS"')} ELSE 0 END) AS pcs
       FROM "KR_DETL" WHERE "CO_CODE"=$1 GROUP BY "AC_CODE" ORDER BY "AC_CODE"`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      issued: round3(num(r.issued)),
      received: round3(num(r.received)),
      balance: round3(num(r.issued) - num(r.received)),
      pcs: round3(num(r.pcs)),
    }));
    return {
      rows: out,
      totals: { karigars: out.length, balanceFine: round3(out.reduce((t, r) => t + r.balance, 0)) },
    };
  });
}

/**
 * Rate list (RATE_MAST): the latest rate per metal/purity group. DISTINCT ON keeps a single row per
 * GR_CODE — the one with the most recent VCH_DATE (SR_NO breaks any same-day tie) — exposing the
 * group's touch (GR_TOUCH), per-unit rate (GR_RATE), fine-gold rate (FINE_GL_RATE) and that latest
 * date. Scoped by CO_CODE; totals reports the group count.
 */
export async function rateList(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT ON (r."GR_CODE") r."GR_CODE" AS "group", r."GR_TOUCH" AS touch,
              r."GR_RATE" AS rate, r."FINE_GL_RATE" AS "fineGold", r."VCH_DATE" AS date
       FROM "RATE_MAST" r WHERE r."CO_CODE"=$1
       ORDER BY r."GR_CODE", r."VCH_DATE" DESC NULLS LAST, r."SR_NO" DESC`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      group: r.group,
      touch: round3(num(r.touch)),
      rate: round2(num(r.rate)),
      fineGold: round3(num(r.fineGold)),
      date: r.date ?? null,
    }));
    return { rows: out, totals: { groups: out.length } };
  });
}

/**
 * Karigar / MFG metal ledger (per karigar): chronological KR_DETL movements — issue (INOUT 'O',
 * fine OUT to the karigar) and receipt (INOUT 'I', fine IN) — with a running fine balance (issued −
 * received = fine the karigar still holds). Read-only; scoped by CO_CODE + AC_CODE.
 */
export async function karigarLedger(
  prisma: any,
  s: ReportScope,
  karigarAc: string,
): Promise<ListReport & { karigarAc: string }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" vch, "VCH_DATE"::text vd, coalesce("VCH_TYPE",'') vt, coalesce("INOUT_TYPE",'') io, coalesce("IT_CODE",'') it, ${NN('"ITM_NWT"')} nwt, ${NN('"ITM_FINE"')} fine
         FROM "KR_DETL" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 ORDER BY "VCH_DATE" NULLS LAST, "VCH_NO"`,
      s.coCode,
      karigarAc,
    );
    let bal = 0,
      iss = 0,
      rcv = 0;
    const out = rows.map((r) => {
      const f = num(r.fine);
      const isIssue = String(r.io) === 'O';
      bal = round3(bal + (isIssue ? f : -f));
      if (isIssue) iss = round3(iss + f);
      else rcv = round3(rcv + f);
      return {
        vchNo: String(r.vch ?? ''),
        vchDate: r.vd ? String(r.vd).slice(0, 10) : null,
        vchType: String(r.vt ?? ''),
        direction: isIssue ? 'Issue' : 'Receive',
        itCode: String(r.it ?? ''),
        netWt: round3(num(r.nwt)),
        issuedFine: isIssue ? round3(f) : 0,
        receivedFine: isIssue ? 0 : round3(f),
        balanceFine: bal,
      };
    });
    return {
      karigarAc,
      rows: out,
      totals: { issued: iss, received: rcv, balanceFine: round3(iss - rcv) },
    };
  });
}

/** Print-ready HTML of a karigar metal ledger (statement). */
export function renderKarigarLedgerHtml(
  karigarAc: string,
  rep: ListReport & { karigarAc?: string },
  // G09: neutral default; the route passes the active company's CO_NAME. Never a specific shop.
  company = 'Karigar Ledger',
): string {
  const esc = (v: unknown) =>
    String(v ?? '').replace(
      /[&<>"]/g,
      (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c] as string,
    );
  const t = rep.totals as any;
  const body = (rep.rows as any[])
    .map(
      (x) =>
        `<tr><td>${esc(x.vchNo)}</td><td>${esc(x.vchDate ?? '')}</td><td>${esc(x.direction)}</td><td>${esc(x.itCode)}</td><td class="r">${x.netWt || ''}</td><td class="r">${x.issuedFine || ''}</td><td class="r">${x.receivedFine || ''}</td><td class="r">${x.balanceFine}</td></tr>`,
    )
    .join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>Karigar Ledger — ${esc(karigarAc)}</title>
    <style>body{font:12px Arial,sans-serif;color:#111;padding:20px}h2{color:#0b5cab;margin:0 0 4px}
      table{border-collapse:collapse;width:100%;margin-top:8px}th,td{border:1px solid #bbb;padding:5px 7px;font-size:11px;text-align:left}th{background:#eef3f9}td.r,th.r{text-align:right;font-variant-numeric:tabular-nums}
      tfoot td{font-weight:700;border-top:2px solid #333}@media print{.noprint{display:none}}</style></head><body>
    <div class="noprint" style="margin-bottom:8px"><button onclick="window.print()">Print</button></div>
    <h2>${esc(company)}</h2><div>Karigar Metal Ledger — <b>${esc(karigarAc)}</b></div>
    <table><thead><tr><th>Vch</th><th>Date</th><th>Type</th><th>Item</th><th class="r">Net Wt</th><th class="r">Issued Fine</th><th class="r">Received Fine</th><th class="r">Balance Fine</th></tr></thead>
      <tbody>${body || '<tr><td colspan="8">No movements</td></tr>'}</tbody>
      <tfoot><tr><td colspan="5">Totals</td><td class="r">${t?.issued ?? 0}</td><td class="r">${t?.received ?? 0}</td><td class="r">${t?.balanceFine ?? 0}</td></tr></tfoot>
    </table></body></html>`;
}
