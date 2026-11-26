import { formatDesktopDate, round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import {
  docShell,
  esc,
  num,
  money,
  rupeesInWords,
  billFooter,
  type DocMeta,
} from '../documents/docChrome.js';
import {
  documentCompanyTx,
  documentPartyTx,
  requireVoucherDocumentScope,
  voucherKeyParams,
  voucherKeyWhere,
  type VoucherDocumentScope,
} from '../documents/voucherDocument.js';

/** Receipt / Payment voucher documents. Both live in CASH_DATA, one row per grid line (TR_CASH.cs:3005-3069); a
 *  payment the web saved in PAY_DATA before that, and an Other Expenses voucher, keep their per-party
 *  allocations in PAY_DETL (AC_CODE, IT_NAME, NET/TOT, IT_REMARK).
 *  Mirrors desktop CashBankBill.rpt (receipt) / PaymentVch.rpt (payment): received-from/paid-to party,
 *  on-account allocation table, mode/tender (cash/cheque/bank), amount in words, signatory. */
export type VoucherKind = 'receipt' | 'payment';
export type FinanceVoucherScope = VoucherDocumentScope;

export async function financeVoucherData(
  prisma: any,
  kind: VoucherKind,
  scope: FinanceVoucherScope,
): Promise<{ header: any; lines: any[]; company: any; party: any } | null> {
  const s = requireVoucherDocumentScope(scope);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params = voucherKeyParams(s);
    // TR_CASH prints every CASH_DATA row of the voucher in SR_NO order, receipts AND payments, through
    // CashBankBill(.Ac).RPT (TR_CASH.cs:3151, :3288, :3327-3333): a multi-line voucher is one row per grid line
    // (:2995-3060), so the header carries the summed amount and kasar and each row becomes an allocation line.
    // A payment book holds payments only; a CASH_DATA row flagged as received money is never a payment's header.
    let h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CASH_DATA" WHERE ${voucherKeyWhere()}${
        kind === 'payment' ? ` AND coalesce("INOUT_TYPE",'') <> 'I'` : ''
      } ORDER BY "SR_NO" NULLS FIRST`,
      ...params,
    );
    // A payment the web saved in PAY_DATA before payments moved to CASH_DATA, and the Other Expenses / Other
    // Income vouchers (TR_OTH_PURC prints PaymentVch.RPT from PAY_DATA), keep printing from there.
    const fromCashData = h.length > 0;
    if (!fromCashData && kind === 'payment')
      h = await tx.$queryRawUnsafe(
        `SELECT * FROM "PAY_DATA" WHERE ${voucherKeyWhere()} LIMIT 1`,
        ...params,
      );
    if (!h.length) return null;
    // Older web multi-line receipts kept one aggregate CASH_DATA row plus PAY_DETL lines; those still print from
    // PAY_DETL. A voucher written as TR_CASH writes it has none.
    const detail: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "PAY_DETL" WHERE ${voucherKeyWhere()} ORDER BY "SR_NO"`,
      ...params,
    );
    const sum = (col: string) =>
      round(
        h.reduce((t, r) => t + num(r[col]), 0),
        2,
      );
    let header = h[0];
    if (fromCashData) {
      const amount = sum('REC_AMT');
      // Cash or bank: the book's own layout (BANK REC / BANK PAY are the bank forms, TR_CASH.cs:3073); a generic
      // book is a bank movement when it names a settlement account other than its slot 1.
      const book: any[] = await tx.$queryRawUnsafe(
        `SELECT upper(btrim(coalesce("MAIN_BOOK"::text,''))) m FROM "BOOK_DATA"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coBook,
      );
      const main = String(book[0]?.m ?? '');
      const slotOne = await resolveBookSlotAccountTx(tx, s, 'cash-settlement', 1).catch(() => '');
      const named = String(h[0].REC_AC_CODE ?? '').trim();
      const bank = main.startsWith('BANK')
        ? true
        : main.startsWith('CASH')
          ? false
          : named !== '' && named !== slotOne;
      header = {
        ...h[0],
        REC_AMT: amount,
        KASAR_AMT: sum('KASAR_AMT'),
        // The page's view model: the print reads the amount, the mode and the settlement account from these.
        NET_AMT: amount,
        TOT_AMT: amount,
        VCH_TYPE: `${bank ? 'B' : 'C'}${kind === 'receipt' ? 'REC' : 'PAY'}`,
        CASH_AMT: bank ? 0 : amount,
        BANK_AC: bank ? named || slotOne : null,
      };
    } else if (kind === 'receipt' && h.length > 1) {
      header = { ...h[0], REC_AMT: sum('REC_AMT'), KASAR_AMT: sum('KASAR_AMT') };
    }
    const lines =
      detail.length || !fromCashData || h.length < 2
        ? detail
        : h.map((r) => ({
            AC_CODE: r.AC_CODE,
            IT_NAME: r.AC_NAME ?? r.AC_CODE,
            IT_REMARK: r.IT_DESC,
            NET_AMT: num(r.REC_AMT),
            KASAR_AMT: num(r.KASAR_AMT),
          }));
    const company = await documentCompanyTx(tx, s);
    const party = await documentPartyTx(tx, s, header.AC_CODE);
    return { header, lines, company, party };
  });
}

export interface FinanceVoucherCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
}

export function financeVoucherHtml(
  kind: VoucherKind,
  header: any,
  lines: any[],
  ctx: FinanceVoucherCtx = {},
): string {
  const h = header;
  const p = ctx.party ?? {};
  const isReceipt = kind === 'receipt';
  const cashMode = isReceipt
    ? String(h.VCH_TYPE ?? '').toUpperCase() === 'CREC' || num(h.CASH_AMT) > 0
    : String(h.VCH_TYPE ?? '').toUpperCase() === 'CPAY' || num(h.CASH_AMT) > 0;
  const amount = isReceipt ? num(h.REC_AMT) : num(h.TOT_AMT) || num(h.NET_AMT);
  const kasar = num(h.KASAR_AMT);
  const net = isReceipt ? amount + kasar : num(h.NET_AMT) || amount;

  // party allocation rows (PAY_DETL); fall back to header party if none
  const partyRows = (
    lines.length
      ? lines
      : [
          {
            AC_CODE: h.AC_CODE,
            IT_NAME: h.AC_NAME,
            NET_AMT: amount,
            IT_REMARK: h.IT_DESC ?? h.VCH_DESC,
          },
        ]
  )
    .map(
      (l, i) =>
        `<tr><td class="c">${i + 1}</td><td>${esc(l.IT_NAME ?? l.AC_CODE ?? '')}</td>` +
        `<td>${esc(l.IT_REMARK ?? '')}</td><td class="r">${money(l.NET_AMT ?? l.TOT_AMT)}</td></tr>`,
    )
    .join('');
  const partyNames = (
    lines.length ? lines.map((l) => l.IT_NAME ?? l.AC_CODE) : [p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE]
  )
    .filter(Boolean)
    .join(', ');

  const allocTable =
    `<div class="vinfo" style="margin:6px 0;font-size:12px"><b>${isReceipt ? 'Received with thanks from' : 'Paid to'}:</b> ${esc(partyNames)}</div>` +
    `<table class="items"><thead><tr><th>#</th><th style="width:42%">Account</th><th>On Account Of</th><th class="r">Amount</th></tr></thead>` +
    `<tbody>${partyRows}</tbody>` +
    `<tfoot><tr><td class="c" colspan="3">Total</td><td class="r">${money(net)}</td></tr></tfoot></table>`;

  // mode of payment
  const modeParts: string[] = [];
  if (cashMode) modeParts.push('Cash');
  else {
    modeParts.push(
      h.BANK_NAME
        ? `Bank: ${esc(h.BANK_NAME)}`
        : isReceipt
          ? 'Bank'
          : h.BANK_AC
            ? `Bank A/c ${esc(h.BANK_AC)}`
            : 'Bank',
    );
    if (h.CHQ_NO) modeParts.push(`Cheque No: ${esc(h.CHQ_NO)}`);
  }
  const narration = h.IT_DESC ?? h.VCH_DESC ?? '';
  const modeBox =
    `<div class="hsn"><div style="border:1px solid #94a3b8;border-radius:4px;padding:6px 8px;font-size:11px">` +
    `<b>Mode of Payment:</b> ${modeParts.join(' · ')}${narration ? `<br/><b>Narration:</b> ${esc(narration)}` : ''}</div></div>`;
  const t: string[] = [`<tr><td>Amount</td><td class="r">${money(amount)}</td></tr>`];
  if (kasar > 0)
    t.push(
      `<tr><td>${isReceipt ? 'Kasar (allowed)' : 'Kasar'}</td><td class="r">${money(kasar)}</td></tr>`,
    );
  t.push(
    `<tr class="grand"><td>${isReceipt ? 'Net Received' : 'Net Paid'}</td><td class="r">₹ ${money(net)}</td></tr>`,
  );
  const totals =
    `<div class="lower">${modeBox}<div class="tot"><table>${t.join('')}</table></div></div>` +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(net))} only.</div>`;

  const vchDate = formatDesktopDate(h.VCH_DATE); // N56 (D19): dd/MM/yyyy, always with the year
  const meta: DocMeta[] = [
    { k: 'Voucher No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
    { k: 'Type', v: cashMode ? 'Cash' : 'Bank' },
  ];
  return docShell({
    title: isReceipt ? 'Receipt Voucher' : 'Payment Voucher',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: isReceipt ? 'Received From' : 'Paid To',
      name: p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE,
      addr: [p.AC_ADD1, p.AC_CITY, p.AC_MOBILE && `Mob: ${p.AC_MOBILE}`].filter(Boolean),
    },
    meta,
    body: allocTable + totals,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      isReceipt
        ? 'Received subject to realisation of cheque. E.&O.E.'
        : 'Payment made as per particulars above. E.&O.E.',
    ),
  });
}
