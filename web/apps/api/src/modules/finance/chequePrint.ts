/** Cheque printing (desktop cheque-print): amount-in-words (Indian system) + a print-ready cheque HTML. */

const ONES = [
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
const TENS = ['', '', 'Twenty', 'Thirty', 'Forty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety'];

function twoDigits(n: number): string {
  if (n < 20) return ONES[n]!;
  return (TENS[Math.floor(n / 10)]! + (n % 10 ? ' ' + ONES[n % 10]! : '')).trim();
}
function threeDigits(n: number): string {
  const h = Math.floor(n / 100);
  const r = n % 100;
  return [h ? ONES[h]! + ' Hundred' : '', r ? twoDigits(r) : ''].filter(Boolean).join(' ');
}

/** Indian-system amount in words (crore/lakh/thousand) for rupees + paise. */
export function amountInWords(amount: number): string {
  const rupees = Math.floor(Math.round(amount * 100) / 100);
  const paise = Math.round((amount - rupees) * 100);
  if (rupees === 0 && paise === 0) return 'Zero Rupees Only';
  const parts: string[] = [];
  const crore = Math.floor(rupees / 10000000);
  const lakh = Math.floor((rupees % 10000000) / 100000);
  const thousand = Math.floor((rupees % 100000) / 1000);
  const rest = rupees % 1000;
  if (crore) parts.push(twoDigits(crore) + ' Crore');
  if (lakh) parts.push(twoDigits(lakh) + ' Lakh');
  if (thousand) parts.push(twoDigits(thousand) + ' Thousand');
  if (rest) parts.push(threeDigits(rest));
  let words = parts.join(' ').trim() + ' Rupees';
  if (paise) words += ' and ' + twoDigits(paise) + ' Paise';
  return words + ' Only';
}

const esc = (s: unknown): string =>
  String(s ?? '').replace(
    /[&<>"]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c] as string,
  );

export interface ChequeInput {
  payee: string;
  amount: number;
  date?: string;
  chqNo?: string;
  acPayee?: boolean;
  autoPrint?: boolean;
}
export function renderCheque(input: ChequeInput): string {
  const d = input.date ? new Date(input.date) : new Date();
  const dd = String(d.getDate()).padStart(2, '0');
  const mm = String(d.getMonth() + 1).padStart(2, '0');
  const yyyy = String(d.getFullYear());
  const amt = Number(input.amount || 0);
  return `<!doctype html><html><head><meta charset="utf-8"><title>Cheque — ${esc(input.payee)}</title>
    <style>*{box-sizing:border-box;font-family:Arial,sans-serif}body{margin:12px}
      .chq{width:640px;height:280px;border:1px solid #888;border-radius:6px;padding:18px;position:relative;font-size:14px}
      .date{position:absolute;top:14px;right:18px;letter-spacing:6px;font-family:monospace}
      .payee{margin-top:44px}.line{border-bottom:1px dotted #888;min-height:20px;padding:2px 4px}
      .words{margin-top:8px}.amtbox{position:absolute;right:18px;bottom:80px;border:1px solid #333;padding:6px 12px;font-weight:700}
      .acp{position:absolute;top:14px;left:18px;font-weight:700;text-decoration:underline}
      @media print{.noprint{display:none}}</style></head><body>
    <div class="noprint" style="margin-bottom:8px"><button onclick="window.print()">Print</button></div>
    <div class="chq">
      ${input.acPayee ? '<div class="acp">A/c Payee Only</div>' : ''}
      <div class="date">${dd}${mm}${yyyy}</div>
      <div class="payee">Pay <span class="line" style="display:inline-block;min-width:420px">${esc(input.payee)}</span></div>
      <div class="words">Rupees <span class="line" style="display:inline-block;min-width:520px">${esc(amountInWords(amt))}</span></div>
      <div class="amtbox">₹ ${amt.toLocaleString('en-IN', { minimumFractionDigits: 2 })}</div>
      ${input.chqNo ? `<div style="position:absolute;bottom:14px;left:18px;font-family:monospace">Chq: ${esc(input.chqNo)}</div>` : ''}
    </div>
      ${input.autoPrint ? '<script>window.addEventListener("load",function(){setTimeout(function(){window.print();},50);});</script>' : ''}</body></html>`;
}
