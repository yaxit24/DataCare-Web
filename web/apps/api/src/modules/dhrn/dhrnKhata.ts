import { formatDesktopDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import {
  docShell,
  esc,
  num,
  money,
  rupeesInWords,
  billFooter,
  type DocMeta,
} from '../documents/docChrome.js';

/** Dhrn Khata-Vahi — per-borrower running loan+interest ledger from DHRN_DATA movement rows.
 *  Mirrors desktop DhrnKhataVahi.rpt: each issue advances principal + accrues interest; each receipt
 *  repays principal / interest; a running outstanding balance is carried down. */
export interface DhrnKhataScope {
  tenantId: string;
  coCode: string;
  coYear?: string;
  acCode: string;
}
const dt = (v: any): string => formatDesktopDate(v); // N56 (D19): dd/MM/yyyy

export async function dhrnKhataData(
  prisma: any,
  s: DhrnKhataScope,
): Promise<{ rows: any[]; party: any; company: any }> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const yr = s.coYear ? ' AND "CO_YEAR"=$3' : '';
    const params = s.coYear ? [s.coCode, s.acCode, s.coYear] : [s.coCode, s.acCode];
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "DHRN_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2${yr} ORDER BY "VCH_DATE", "VCH_NO", "SR_NO"`,
      ...params,
    );
    const party: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      s.coCode,
      s.acCode,
    );
    const co: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`,
      s.coCode,
    );
    return { rows, party: party[0] ?? null, company: co[0] ?? null };
  });
}

export interface DhrnKhataCtx {
  company?: any;
  period?: string;
  fallbackName?: string;
}

export function dhrnKhataHtml(rows: any[], party: any, ctx: DhrnKhataCtx = {}): string {
  const p = party ?? {};
  let bal = 0,
    sLoan = 0,
    sIntAcc = 0,
    sRepaid = 0,
    sIntPaid = 0;
  const body = rows
    .map((r) => {
      const loan = num(r.DHRN_AMT),
        intAcc = num(r.INT_AMT),
        repaid = num(r.DHRN_REC_AMT),
        intPaid = num(r.INT_REC_AMT);
      bal += loan + intAcc - repaid - intPaid;
      sLoan += loan;
      sIntAcc += intAcc;
      sRepaid += repaid;
      sIntPaid += intPaid;
      const isIssue =
        String(r.VCH_TYPE ?? '')
          .toUpperCase()
          .includes('ISU') ||
        String(r.INOUT_TYPE ?? '') === 'O' ||
        loan > 0;
      const particulars = `${isIssue ? 'Loan Issue' : 'Repayment'}${r.ISU_NO ? ` · ISU ${esc(r.ISU_NO)}` : ''}${num(r.INT_PRC) ? ` @ ${num(r.INT_PRC)}%` : ''}${r.REMARKS ? ` · ${esc(r.REMARKS)}` : ''}`;
      return (
        `<tr><td class="c">${esc(dt(r.VCH_DATE))}</td><td>${particulars}</td>` +
        `<td class="r">${loan ? money(loan) : ''}</td><td class="r">${intAcc ? money(intAcc) : ''}</td>` +
        `<td class="r">${repaid ? money(repaid) : ''}</td><td class="r">${intPaid ? money(intPaid) : ''}</td>` +
        `<td class="r">${money(bal)}</td></tr>`
      );
    })
    .join('');
  const table =
    `<table class="items"><thead><tr><th>Date</th><th style="width:30%">Particulars</th><th>Loan</th><th>Int Accrued</th><th>Repaid</th><th>Int Paid</th><th>Balance</th></tr></thead>` +
    `<tbody>${body || '<tr><td colspan="7" class="c">No pledge activity</td></tr>'}</tbody>` +
    `<tfoot><tr><td class="c" colspan="2">Total</td><td class="r">${money(sLoan)}</td><td class="r">${money(sIntAcc)}</td><td class="r">${money(sRepaid)}</td><td class="r">${money(sIntPaid)}</td><td class="r">${money(bal)}</td></tr></tfoot></table>`;
  const summary =
    `<div class="lower"><div class="hsn"></div><div class="tot"><table>` +
    `<tr><td>Principal Outstanding</td><td class="r">${money(sLoan - sRepaid)}</td></tr>` +
    `<tr class="sub"><td>Interest Outstanding</td><td class="r">${money(sIntAcc - sIntPaid)}</td></tr>` +
    `<tr class="grand"><td>Balance Due</td><td class="r">₹ ${money(bal)}</td></tr></table></div></div>` +
    `<div class="words"><b>Balance in words:</b> ${esc(rupeesInWords(bal))} only.</div>`;

  const meta: DocMeta[] = [
    { k: 'Account', v: String(p.AC_CODE ?? '') },
    { k: 'Period', v: ctx.period ?? '' },
    { k: 'Entries', v: String(rows.length) },
  ];
  return docShell({
    title: 'Dhrn Khata-Vahi (Loan Ledger)',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Borrower',
      name: p.AC_NAME ?? p.AC_CODE,
      addr: [p.AC_ADD1, p.AC_CITY, p.AC_MOBILE && `Mob: ${p.AC_MOBILE}`].filter(Boolean),
    },
    meta,
    body: table + summary,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Running loan + interest ledger as per books. Interest accrues per pledge terms. E.&O.E.',
    ),
  });
}
