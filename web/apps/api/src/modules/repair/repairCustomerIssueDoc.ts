import { withTenant } from '@datacare/db';
import { billFooter, docShell, esc, money, num, wt, type DocMeta } from '../documents/docChrome.js';
import { getCustomerRepairIssue, type CustomerRepairIssueView } from './repairCustomerIssue.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export async function customerRepairIssueDocumentData(
  prisma: any,
  scope: VoucherScope,
  vchNo: string | number,
): Promise<{ issue: CustomerRepairIssueView; company: any; party: any } | null> {
  const issue = await getCustomerRepairIssue(prisma, scope, vchNo);
  if (!issue) return null;
  const context = await withTenant(prisma, scope.tenantId, async (tx: any) => {
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

/** Engineering print binding for desktop ReparingCustIsu; Crystal pixel comparison remains open. */
export function customerRepairIssueHtml(
  issue: CustomerRepairIssueView,
  context: { company?: any; party?: any; copy?: string } = {},
): string {
  let pieces = 0;
  let gross = 0;
  let fine = 0;
  let labour = 0;
  const rows = issue.lines
    .map((line) => {
      pieces += num(line.pieces);
      gross += num(line.grossWt);
      fine += num(line.fineWt);
      labour += num(line.labourAmount);
      const item = `${esc(line.itemName || line.itCode)}${line.itmSize ? `<span class="hu">Size: ${esc(line.itmSize)}</span>` : ''}${line.description ? `<span class="hu">${esc(line.description)}</span>` : ''}`;
      const source = `${esc(line.voucherNo)}/${line.srNo}<span class="hu">${esc(line.vchDate)}</span>`;
      const karigar = line.karigarReceiptNo
        ? `${esc(line.karigarName || line.karigarCode)}<span class="hu">Kr. receipt ${esc(line.karigarReceiptNo)}</span>`
        : '—';
      return `<tr><td class="c">${line.issueSrNo}</td><td>${source}</td><td>${karigar}</td><td>${item}</td><td class="r">${num(line.pieces) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.addWt)}</td><td class="r">${wt(line.fineWt)}</td><td class="r">${money(line.itemAmount)}</td><td class="r">${money(line.labourAmount)}</td><td class="r">${money(line.netAmount)}</td></tr>`;
    })
    .join('');
  const table = `<table class="items"><thead><tr><th>#</th><th>Customer repair</th><th>Karigar</th><th style="width:22%">Repair item / description</th><th>Pcs</th><th>Gross</th><th>Add Wt</th><th>Fine</th><th>Item Amt</th><th>Labour</th><th>Net Amt</th></tr></thead><tbody>${rows || '<tr><td colspan="11" class="c">No repair items</td></tr>'}</tbody><tfoot><tr><td colspan="4" class="c">Total delivered</td><td class="r">${pieces || ''}</td><td class="r">${wt(gross)}</td><td></td><td class="r">${wt(fine)}</td><td></td><td class="r">${money(labour)}</td><td class="r">${money(issue.totals.netAmount)}</td></tr></tfoot></table>`;

  const settlement = `<div class="lower"><div class="hsn"><b>Narration</b><div>${esc(issue.description || '—')}</div></div><div class="tot"><table><tr><td>Net Amount</td><td class="r">${money(issue.totals.netAmount)}</td></tr><tr><td>Discount${issue.discountPct ? ` (${num(issue.discountPct)}% on labour)` : ''}</td><td class="r">${money(issue.totals.discountAmount)}</td></tr><tr><td>Tax${issue.taxPct ? ` (${num(issue.taxPct)}%)` : ''}</td><td class="r">${money(issue.totals.taxAmount)}</td></tr><tr class="sub"><td>Total</td><td class="r">${money(issue.totals.totalAmount)}</td></tr><tr><td>Cheque Received</td><td class="r">${money(issue.chequeAmount)}</td></tr><tr><td>Card Received</td><td class="r">${money(issue.cardAmount)}</td></tr><tr><td>Cash Received</td><td class="r">${money(issue.cashAmount)}</td></tr><tr><td>Kasar</td><td class="r">${money(issue.kasarAmount)}</td></tr><tr class="grand"><td>Outstanding</td><td class="r">${money(issue.totals.outstandingAmount)}</td></tr></table></div></div>`;

  const party = context.party ?? {};
  const meta: DocMeta[] = [
    { k: 'Voucher No', v: issue.voucherNo },
    { k: 'Date', v: issue.vchDate },
    { k: 'Reference', v: issue.billNo || '—' },
    { k: 'Employee', v: issue.employeeCode || '—' },
  ];
  return docShell({
    title: 'Repairing Delivered — Customer Issue',
    copy: context.copy,
    company: context.company,
    billTo: {
      cap: 'Delivered To',
      name: issue.acName || issue.acCode,
      addr: [
        party.AC_ADD1,
        party.AC_ADD2,
        party.AC_CITY,
        party.AC_MOBILE && `Mob: ${party.AC_MOBILE}`,
      ].filter(Boolean),
      gstin: party.AC_GSTNO || undefined,
      state: party.AC_STATE || undefined,
    },
    meta,
    body: table + settlement,
    footer: billFooter(
      context.company,
      undefined,
      'Repaired items delivered to the customer as listed above. Please verify weights on delivery.',
    ),
  });
}
