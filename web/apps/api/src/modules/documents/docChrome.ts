/** Shared A4 print-document chrome for faithful customer/vendor/karigar-facing
 *  documents (GST tax invoice, purchase bill, karigar issue voucher…), mirroring
 *  the desktop Crystal bills (company GSTIN header, bill-to w/ GSTIN + state,
 *  line table, tax split, bank/UPI footer, signatory). One shell, many documents. */

export const esc = (s: any): string =>
  String(s ?? '').replace(
    /[&<>]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;' })[c] as string,
  );
export const num = (v: any): number => Number(v ?? 0) || 0;
export const money = (v: any): string =>
  num(v).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
export const wt = (v: any): string =>
  num(v).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 });

/** Indian rupees in words (paise ignored). */
export function rupeesInWords(amount: number): string {
  const a = Math.floor(Math.abs(amount));
  if (a === 0) return 'Zero Rupees';
  const ones = [
    '',
    'One',
    'Two',
    'Three',
    'Four',
    'Five',
    'Six',
    'Seven',
    'Eight',
    'Nine',
    'Ten',
    'Eleven',
    'Twelve',
    'Thirteen',
    'Fourteen',
    'Fifteen',
    'Sixteen',
    'Seventeen',
    'Eighteen',
    'Nineteen',
  ];
  const tens = [
    '',
    '',
    'Twenty',
    'Thirty',
    'Forty',
    'Fifty',
    'Sixty',
    'Seventy',
    'Eighty',
    'Ninety',
  ];
  const two = (n: number): string =>
    n < 20
      ? (ones[n] ?? '')
      : `${tens[Math.floor(n / 10)] ?? ''}${n % 10 ? ' ' + (ones[n % 10] ?? '') : ''}`;
  const three = (n: number): string =>
    n >= 100
      ? `${ones[Math.floor(n / 100)] ?? ''} Hundred${n % 100 ? ' ' + two(n % 100) : ''}`
      : two(n);
  let n = a;
  const parts: string[] = [];
  const crore = Math.floor(n / 10000000);
  n %= 10000000;
  const lakh = Math.floor(n / 100000);
  n %= 100000;
  const thousand = Math.floor(n / 1000);
  n %= 1000;
  if (crore) parts.push(`${three(crore)} Crore`);
  if (lakh) parts.push(`${two(lakh)} Lakh`);
  if (thousand) parts.push(`${two(thousand)} Thousand`);
  if (n) parts.push(three(n));
  return `${parts.join(' ')} Rupees`;
}

export const DOC_CSS = `
  *{box-sizing:border-box} body{font:12px 'Segoe UI',Arial,sans-serif;color:#111;margin:0;padding:0;background:#f5f5f5;}
  .page{width:210mm;min-height:290mm;margin:10px auto;background:#fff;padding:12mm 10mm;box-shadow:0 1px 6px rgba(0,0,0,.15);}
  .co-hdr{display:flex;justify-content:space-between;align-items:flex-start;border-bottom:2px solid #0b5cab;padding-bottom:10px;}
  .co-name{font-size:22px;font-weight:800;color:#0b5cab;letter-spacing:.3px;} .co-sub{font-size:10.5px;color:#333;line-height:1.5;margin-top:2px;}
  .co-reg{font-size:10.5px;text-align:right;line-height:1.6;} .co-reg b{color:#0b5cab;}
  .doc-title{text-align:center;font-size:15px;font-weight:700;letter-spacing:2px;margin:8px 0 2px;color:#111;text-transform:uppercase;}
  .copy{font-size:10px;font-weight:700;color:#b45309;border:1px dashed #b45309;padding:1px 7px;border-radius:3px;margin-left:8px;vertical-align:middle;}
  .parties{display:flex;gap:10px;margin:8px 0;}
  .party{flex:1;border:1px solid #cbd5e1;border-radius:4px;padding:7px 9px;} .party .cap{font-size:9.5px;color:#64748b;text-transform:uppercase;letter-spacing:.5px;}
  .party .nm{font-weight:700;font-size:13px;margin:1px 0;} .party .ln{font-size:10.5px;color:#333;line-height:1.5;}
  .meta{width:36%;} .meta table{width:100%;border-collapse:collapse;} .meta td{border:1px solid #cbd5e1;padding:3px 7px;font-size:10.5px;} .meta td.k{background:#f1f5f9;font-weight:600;width:45%;}
  table.items{border-collapse:collapse;width:100%;margin-top:8px;} table.items th,table.items td{border:1px solid #94a3b8;padding:4px 6px;font-size:10.5px;}
  table.items th{background:#0b5cab;color:#fff;text-align:center;font-weight:600;} table.items td.r{text-align:right;font-variant-numeric:tabular-nums;} table.items td.c{text-align:center;}
  table.items tfoot td{font-weight:700;background:#eef3f9;}
  .hu{color:#64748b;font-size:8.5px;display:block;}
  .lower{display:flex;gap:10px;margin-top:8px;} .hsn{flex:1;} .hsn table{border-collapse:collapse;width:100%;} .hsn th,.hsn td{border:1px solid #94a3b8;padding:3px 6px;font-size:9.5px;text-align:right;} .hsn th{background:#eef3f9;text-align:center;}
  .tot{width:42%;} .tot table{width:100%;border-collapse:collapse;} .tot td{padding:3px 8px;font-size:11px;} .tot td.r{text-align:right;font-variant-numeric:tabular-nums;} .tot tr.sub td{border-top:1px solid #cbd5e1;} .tot tr.grand td{border-top:2px solid #0b5cab;border-bottom:2px solid #0b5cab;font-weight:800;font-size:13px;color:#0b5cab;}
  .words{margin-top:8px;font-size:11px;} .words b{font-style:italic;}
  .foot{display:flex;justify-content:space-between;margin-top:16px;border-top:1px dashed #94a3b8;padding-top:8px;font-size:10px;color:#333;}
  .foot .bank{line-height:1.6;} .foot .sign{text-align:right;min-width:180px;} .foot .sign .for{font-weight:700;margin-bottom:34px;}
  .decl{margin-top:10px;font-size:9px;color:#64748b;font-style:italic;border-top:1px dotted #cbd5e1;padding-top:5px;}
  @media print{body{background:#fff;} .page{box-shadow:none;margin:0;width:auto;} .noprint{display:none!important;}}
`;

export interface DocParty {
  cap: string;
  name?: string;
  addr?: string[];
  gstin?: string;
  state?: string;
  extra?: string[];
}
export interface DocMeta {
  k: string;
  v: string;
}

function companyBlock(company: any, fallbackName: string): string {
  const c = company ?? {};
  const addr = [c.CO_ADD1, c.CO_ADD2, c.CO_ADD3, [c.CO_CITY, c.CO_PIN].filter(Boolean).join(' ')]
    .filter(Boolean)
    .map(esc)
    .join(', ');
  const contact = [
    c.CO_PHONE && `Ph: ${c.CO_PHONE}`,
    c.CO_MOBILE && `Mob: ${c.CO_MOBILE}`,
    c.CO_MAIL,
  ]
    .filter(Boolean)
    .map(esc)
    .join(' · ');
  const reg = [
    c.CO_GST_NO && `<b>GSTIN:</b> ${esc(c.CO_GST_NO)}`,
    c.CO_PAN_NO && `<b>PAN:</b> ${esc(c.CO_PAN_NO)}`,
    c.CO_STATE &&
      `<b>State:</b> ${esc(c.CO_STATE)}${c.CO_STATE_CODE ? ` (${esc(c.CO_STATE_CODE)})` : ''}`,
  ]
    .filter(Boolean)
    .join('<br/>');
  return `<div class="co-hdr">
    <div><div class="co-name">${esc(c.CO_NAME ?? fallbackName)}</div><div class="co-sub">${addr}${contact ? `<br/>${contact}` : ''}</div></div>
    <div class="co-reg">${reg || ''}</div>
  </div>`;
}

function partyBox(p?: DocParty): string {
  if (!p) return '';
  const ln = (p.addr ?? [])
    .filter(Boolean)
    .map((l) => `<div class="ln">${esc(l)}</div>`)
    .join('');
  const extra = (p.extra ?? [])
    .filter(Boolean)
    .map((l) => `<div class="ln">${esc(l)}</div>`)
    .join('');
  return (
    `<div class="party"><div class="cap">${esc(p.cap)}</div><div class="nm">${esc(p.name ?? '')}</div>${ln}` +
    `${p.gstin ? `<div class="ln"><b>GSTIN:</b> ${esc(p.gstin)}</div>` : ''}${p.state ? `<div class="ln"><b>State:</b> ${esc(p.state)}</div>` : ''}${extra}</div>`
  );
}

/** Full A4 document shell: company header + title + parties/meta + body + footer. */
export function docShell(opts: {
  title: string;
  copy?: string;
  company?: any;
  fallbackName?: string;
  billTo?: DocParty;
  shipTo?: DocParty;
  meta?: DocMeta[];
  body: string;
  footer?: string;
}): string {
  const metaRows = (opts.meta ?? [])
    .map((m) => `<tr><td class="k">${esc(m.k)}</td><td>${esc(m.v)}</td></tr>`)
    .join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>${esc(opts.title)}</title><style>${DOC_CSS}</style></head><body>
    <div class="noprint" style="max-width:210mm;margin:8px auto 0;"><button onclick="window.print()">🖨 Print</button></div>
    <div class="page">
      ${companyBlock(opts.company, opts.fallbackName ?? 'COMPANY')}
      <div class="doc-title">${esc(opts.title)}${opts.copy ? `<span class="copy">${esc(opts.copy)}</span>` : ''}</div>
      <div class="parties">
        ${partyBox(opts.billTo)}
        ${opts.shipTo ? partyBox(opts.shipTo) : ''}
        <div class="meta"><table>${metaRows}</table></div>
      </div>
      ${opts.body}
      ${opts.footer ?? ''}
    </div>
  </body></html>`;
}

/** Shared GST metal-bill body (line table w/ HSN + weights + making + taxable, HSN-wise tax summary,
 *  intra CGST+SGST vs inter IGST, hallmark/TCS/round-off, grand total, amount in words). Header-driven
 *  so sales (SL_DATA) and purchase (PR_DATA) render identically. Lines must carry HSN_CODE. */
export function gstBillBody(header: any, lines: any[]): string {
  const h = header;
  const inter = num(h.IGST_TAX) > 0;
  let sPcs = 0,
    sGwt = 0,
    sNwt = 0,
    sMaking = 0,
    sTaxable = 0;
  const hsn: Record<string, { taxable: number; cgst: number; sgst: number; igst: number }> = {};
  const rows = lines
    .map((l, i) => {
      // A caller may supply the persisted taxable value (E CRNT stores it in SL_DETL.NET_AMT, which
      // also includes other charges and MRP pricing); otherwise it is derived as before.
      const taxable =
        l.PRINT_TAXABLE != null
          ? num(l.PRINT_TAXABLE)
          : num(l.ITM_AMT) + num(l.LBR_AMT) + num(l.GHT_AMT) + num(l.HM_AMT);
      sPcs += num(l.ITM_PCS);
      sGwt += num(l.ITM_GWT);
      sNwt += num(l.ITM_NWT);
      sMaking += num(l.LBR_AMT);
      sTaxable += taxable;
      const key = String(l.HSN_CODE ?? '').trim() || '—';
      const e = (hsn[key] ??= { taxable: 0, cgst: 0, sgst: 0, igst: 0 });
      e.taxable += taxable;
      e.cgst += num(l.ITM_CGST_AMT);
      e.sgst += num(l.ITM_SGST_AMT);
      e.igst += num(l.ITM_IGST_AMT);
      const desc =
        esc(l.IT_CODE) +
        (l.DESIGN_NO
          ? `<span class="hu">Design: ${esc(l.DESIGN_NO)}${l.ITM_SIZE ? ' · Size ' + esc(l.ITM_SIZE) : ''}</span>`
          : '') +
        (l.HM_ID ? `<span class="hu">HUID: ${esc(l.HM_ID)}</span>` : '') +
        (l.IT_DESC || l.ITM_REMARK
          ? `<span class="hu">${esc(l.IT_DESC ?? l.ITM_REMARK)}</span>`
          : '');
      return (
        `<tr><td class="c">${i + 1}</td><td>${desc}</td><td class="c">${esc(key)}</td>` +
        `<td class="r">${num(l.ITM_PCS) || ''}</td><td class="r">${wt(l.ITM_GWT)}</td><td class="r">${wt(l.ITM_NWT)}</td>` +
        `<td class="r">${money(l.ITM_RATE)}</td><td class="r">${money(l.LBR_AMT)}</td><td class="r">${money(taxable)}</td></tr>`
      );
    })
    .join('');
  const itemsTable = `<table class="items"><thead><tr>
      <th>#</th><th style="width:34%">Description</th><th>HSN</th><th>Pcs</th><th>Gross Wt</th><th>Net Wt</th><th>Rate</th><th>Making</th><th>Taxable</th>
    </tr></thead><tbody>${rows || '<tr><td colspan="9" class="c">No line items</td></tr>'}</tbody>
    <tfoot><tr><td class="c" colspan="3">Total</td><td class="r">${sPcs || ''}</td><td class="r">${wt(sGwt)}</td><td class="r">${wt(sNwt)}</td><td></td><td class="r">${money(sMaking)}</td><td class="r">${money(sTaxable)}</td></tr></tfoot></table>`;
  const hsnRows = Object.entries(hsn)
    .map(
      ([code, e]) =>
        `<tr><td>${esc(code)}</td><td>${money(e.taxable)}</td>` +
        (inter
          ? `<td>${money(e.igst)}</td>`
          : `<td>${money(e.cgst)}</td><td>${money(e.sgst)}</td>`) +
        `<td>${money(inter ? e.igst : e.cgst + e.sgst)}</td></tr>`,
    )
    .join('');
  const hsnTable =
    `<div class="hsn"><table><thead><tr><th>HSN</th><th>Taxable</th>` +
    (inter ? `<th>IGST</th>` : `<th>CGST</th><th>SGST</th>`) +
    `<th>Tax</th></tr></thead>` +
    `<tbody>${hsnRows || `<tr><td colspan="${inter ? 4 : 5}">—</td></tr>`}</tbody></table></div>`;
  const t: string[] = [`<tr><td>Taxable Value</td><td class="r">${money(h.NET_AMT)}</td></tr>`];
  if (num(h.DISC_AMT) > 0)
    t.push(`<tr><td>Discount</td><td class="r">-${money(h.DISC_AMT)}</td></tr>`);
  if (inter) t.push(`<tr class="sub"><td>IGST</td><td class="r">${money(h.IGST_TAX)}</td></tr>`);
  else {
    t.push(`<tr class="sub"><td>CGST</td><td class="r">${money(h.CGST_TAX)}</td></tr>`);
    t.push(`<tr><td>SGST</td><td class="r">${money(h.SGST_TAX)}</td></tr>`);
  }
  if (num(h.HM_TAX_AMT) > 0)
    t.push(
      `<tr><td>Hallmark Tax${num(h.HM_TAX_PRC) ? ` (${num(h.HM_TAX_PRC)}%)` : ''}</td><td class="r">${money(h.HM_TAX_AMT)}</td></tr>`,
    );
  if (num(h.TCS_AMT) > 0) t.push(`<tr><td>TCS</td><td class="r">${money(h.TCS_AMT)}</td></tr>`);
  if (num(h.ROF_AMT)) t.push(`<tr><td>Round Off</td><td class="r">${money(h.ROF_AMT)}</td></tr>`);
  t.push(`<tr class="grand"><td>Grand Total</td><td class="r">₹ ${money(h.TOT_AMT)}</td></tr>`);
  return (
    `${itemsTable}<div class="lower">${hsnTable}<div class="tot"><table>${t.join('')}</table></div></div>` +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(num(h.TOT_AMT)))} only.</div>`
  );
}

/** Shared bank + declaration + signatory footer. */
export function billFooter(company: any, fallbackName = 'Company', declaration?: string): string {
  const c = company ?? {};
  const bank = c.BANK_NAME
    ? `<div class="bank"><b>Bank Details</b><br/>${esc(c.BANK_NAME)}${c.BANK_AREA ? ', ' + esc(c.BANK_AREA) : ''}<br/>A/c: ${esc(c.BANK_AC_NO ?? '')}${c.BANK_RTGS_NO ? ` · IFSC: ${esc(c.BANK_RTGS_NO)}` : ''}</div>`
    : `<div class="bank"></div>`;
  return (
    `<div class="foot">${bank}<div class="sign"><div class="for">For ${esc(c.CO_NAME ?? fallbackName)}</div><div>Authorised Signatory</div></div></div>` +
    `<div class="decl">${esc(declaration ?? 'Certified that the particulars given above are true and correct. Subject to local jurisdiction. E.&O.E.')}</div>`
  );
}
