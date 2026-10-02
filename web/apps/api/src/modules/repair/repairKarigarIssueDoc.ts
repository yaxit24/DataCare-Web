import { withTxBudget } from '../shared/txBudget.js';
import { billFooter, docShell, esc, money, num, wt, type DocMeta } from '../documents/docChrome.js';
import { getKarigarRepairIssue, type KarigarRepairIssueView } from './repairKarigarIssue.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export async function karigarRepairIssueDocumentData(
  prisma: any,
  scope: VoucherScope,
  vchNo: string | number,
): Promise<{ issue: KarigarRepairIssueView; company: any; party: any } | null> {
  const issue = await getKarigarRepairIssue(prisma, scope, vchNo);
  if (!issue) return null;
  const context = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const companies: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
    );
    const parties: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      issue.acCode,
    );
    return { company: companies[0] ?? null, party: parties[0] ?? null };
  });
  return { issue, ...context };
}

/** Engineering binding for desktop ReparingRec data; objective Crystal pixel parity remains open. */
export function karigarRepairIssueHtml(
  issue: KarigarRepairIssueView,
  context: { company?: any; party?: any; copy?: string } = {},
): string {
  let pieces = 0;
  let gross = 0;
  let net = 0;
  let fine = 0;
  const rows = issue.lines
    .map((line) => {
      pieces += num(line.pieces);
      gross += num(line.grossWt);
      net += num(line.netWt);
      fine += num(line.fineWt);
      const item = `${esc(line.itemName || line.itCode)}${line.itmSize ? `<span class="hu">Size: ${esc(line.itmSize)}</span>` : ''}${line.description ? `<span class="hu">${esc(line.description)}</span>` : ''}`;
      return `<tr><td class="c">${line.issueSrNo}</td><td>${esc(line.voucherNo)}/${line.srNo}<span class="hu">${esc(line.vchDate)}</span></td><td>${esc(line.customerName || line.customerCode)}</td><td>${item}</td><td class="r">${num(line.pieces) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.netWt)}</td><td class="r">${num(line.touch) || ''}</td><td class="r">${wt(line.fineWt)}</td></tr>`;
    })
    .join('');
  const table = `<table class="items"><thead><tr><th>#</th><th>Customer repair</th><th>Customer</th><th style="width:28%">Repair item / description</th><th>Pcs</th><th>Gross</th><th>Net</th><th>Touch%</th><th>Fine</th></tr></thead><tbody>${rows || '<tr><td colspan="9" class="c">No repair items</td></tr>'}</tbody><tfoot><tr><td colspan="4" class="c">Total issued</td><td class="r">${pieces || ''}</td><td class="r">${wt(gross)}</td><td class="r">${wt(net)}</td><td></td><td class="r">${wt(fine)}</td></tr></tfoot></table>`;

  const paid = num(issue.chequeAmount) + num(issue.cardAmount) + num(issue.cashAmount);
  const settlement = `<div class="lower"><div class="hsn"><b>Narration</b><div>${esc(issue.description || '—')}</div></div><div class="tot"><table><tr><td>Cheque Paid</td><td class="r">${money(issue.chequeAmount)}</td></tr><tr><td>Card Paid</td><td class="r">${money(issue.cardAmount)}</td></tr><tr><td>Cash Paid</td><td class="r">${money(issue.cashAmount)}</td></tr><tr class="grand"><td>Advance Paid</td><td class="r">${money(paid)}</td></tr></table></div></div>`;

  const party = context.party ?? {};
  const meta: DocMeta[] = [
    { k: 'Voucher No', v: issue.voucherNo },
    { k: 'Date', v: issue.vchDate },
    { k: 'Reference', v: issue.billNo || '—' },
    { k: 'Employee', v: issue.employeeCode || '—' },
  ];
  return docShell({
    title: 'Repairing Issued — Karigar',
    copy: context.copy,
    company: context.company,
    billTo: {
      cap: 'Issued To',
      name: issue.acName || issue.acCode,
      addr: [
        party.AC_ADD1,
        party.AC_ADD2,
        party.AC_CITY,
        party.AC_MOBILE && `Mob: ${party.AC_MOBILE}`,
      ].filter(Boolean),
    },
    meta,
    body: table + settlement,
    footer: billFooter(
      context.company,
      undefined,
      'Customer repair items issued to the karigar as listed above.',
    ),
  });
}
