import { formatDesktopDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { esc, money, num } from '../documents/docChrome.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

/**
 * OrderCancelVch (TR_SL_ORD_ADJ.BtnPrint_Click, TR_SL_ORD_ADJ.cs:3794-3849; report-specs/OrderCancelVch.spec.json),
 * printed for SL_ORD_ADJ's company, location, year, book and voucher. The report groups on `{@VchGroup}` = year + book
 * + voucher + SR_NO, so every grid row prints as its own receipt:
 *
 * - group header: `{@RptTitle}` = BOOK_DATA.BOOK_NAME in a box; the company block (LOCT_MAST's when
 *   CO_MAST.REP_ADD_TYPE is 'L') beside `{@InVoiceType}` ('ORIGINAL' on a preview, the copy label when printed),
 *   'Vch Date :', 'Vch No :' and an empty 'Chq No :'; then 'Party Name :' SL_ORD_ADJ.AC_NAME with 'Amt Bal :'
 *   `{@OpAmt}` `{@OpAmtCrDr}` and the AC_MAST address lines and mobile;
 * - detail: 'Rs :' PAID_AMT, then `{@WordRuppes}` = "Ruppes : " + ucase(ToWords(PAID_AMT, 0)) when PAID_AMT <> 0;
 * - group footer: 'Net Due Amount :' `{@ClAmt}` `{@CrDrType}`, 'Vch Desc :' IT_DESC;
 * - page footer: 'For : ' + CO_NAME, 'Party signature.', 'signature.'.
 *
 * `{@OpAmt}` and `{@ClAmt}` are the template's own formulas, the constant 0, and BtnPrint passes no value for them,
 * so they print 0.00 with 'Dr' (OpAmtCrDr: > 0 is Cr) and 'Cr' (CrDrType: < 0 is Dr), as the template says.
 */
export class OrderCancelPrintNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'order-cancel-not-found';
  constructor(voucherNo: string) {
    super(`order cancel voucher not found: ${voucherNo}`);
    this.name = 'OrderCancelPrintNotFoundError';
  }
}

type Row = Record<string, any>;
const text = (value: unknown): string => String(value ?? '').trim();
const joined = (...parts: unknown[]) => parts.map(text).join(' , ');

const ONES = [
  '',
  'one',
  'two',
  'three',
  'four',
  'five',
  'six',
  'seven',
  'eight',
  'nine',
  'ten',
  'eleven',
  'twelve',
  'thirteen',
  'fourteen',
  'fifteen',
  'sixteen',
  'seventeen',
  'eighteen',
  'nineteen',
];
const TENS = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

/** Crystal `ToWords(x, 0)`: the whole number in English words, thousand/million grouping. */
export function crystalToWords(value: number): string {
  const n = Math.floor(Math.abs(value));
  if (n === 0) return 'zero';
  const below100 = (k: number) =>
    k < 20 ? ONES[k]! : `${TENS[Math.floor(k / 10)]}${k % 10 ? `-${ONES[k % 10]}` : ''}`;
  const below1000 = (k: number) =>
    k >= 100
      ? `${ONES[Math.floor(k / 100)]} hundred${k % 100 ? ` ${below100(k % 100)}` : ''}`
      : below100(k);
  const scales: Array<[number, string]> = [
    [1e9, 'billion'],
    [1e6, 'million'],
    [1e3, 'thousand'],
  ];
  let rest = n;
  const parts: string[] = [];
  for (const [size, name] of scales) {
    const count = Math.floor(rest / size);
    if (count) parts.push(`${below1000(count)} ${name}`);
    rest %= size;
  }
  if (rest) parts.push(below1000(rest));
  return parts.join(' ');
}

export async function orderCancelVoucherHtml(
  prisma: any,
  scope: VoucherScope & { coYear?: string; coBook?: string },
  rawVoucherNo: string | number,
  copy?: string,
): Promise<string> {
  const voucherNo = formatVoucherNo(rawVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Row[] = await tx.$queryRawUnsafe(
      `SELECT a."SR_NO",a."VCH_DATE",a."VCH_NO",a."AC_CODE",a."AC_NAME",a."IT_DESC",
              coalesce(NULLIF(a."PAID_AMT"::text,'')::numeric,0)::float paid
         FROM "SL_ORD_ADJ" a
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
        ORDER BY a."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length) throw new OrderCancelPrintNotFoundError(voucherNo);
    const [book]: Row[] = await tx.$queryRawUnsafe(
      `SELECT coalesce("BOOK_NAME",'') name FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
    );
    const [company]: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
    );
    const [location]: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    const parties = new Map<string, Row | undefined>();
    for (const code of new Set(rows.map((r) => text(r.AC_CODE)).filter(Boolean)))
      parties.set(
        code,
        (
          (await tx.$queryRawUnsafe(
            `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
              ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END, row_id LIMIT 1`,
            scope.tenantId,
            scope.coCode,
            code,
            scope.lcCode,
          )) as Row[]
        )[0],
      );
    const useLocation = text(company?.REP_ADD_TYPE).toUpperCase() === 'L' && location;
    const co = useLocation
      ? {
          name: text(location.LC_NAME),
          add1: text(location.LC_ADD1),
          add2: joined(location.LC_ADD2, location.LC_ADD3),
          city: `${text(location.LC_CITY)} Mo : ${text(location.LC_MOBILE)} Ph : ${text(location.LC_PHONE)}`,
        }
      : {
          name: text(company?.CO_NAME),
          add1: text(company?.CO_ADD1),
          add2: joined(company?.CO_ADD2, company?.CO_ADD3),
          city: `${text(company?.CO_CITY)} Mo : ${text(company?.CO_MOBILE)} Ph : ${text(company?.CO_PHONE)}`,
        };
    const title = text(book?.name) || 'Order Cancel';
    const mobile = (p: Row | undefined) =>
      text(p?.AC_MOBILE)
        ? `Mo : ${text(p?.AC_MOBILE)}`
        : text(p?.AC_PHONE)
          ? `Ph : ${text(p?.AC_MOBILE)}`
          : `Mo : ${text(p?.AC_MOBILE2)}`;
    const receipts = rows
      .map((r) => {
        const party = parties.get(text(r.AC_CODE));
        const paid = num(r.paid);
        const words = paid !== 0 ? `Ruppes : ${crystalToWords(paid).toUpperCase()}` : '';
        return (
          `<section class="rcpt" data-sr="${num(r.SR_NO)}">` +
          `<h1>${esc(title)}</h1>` +
          `<div class="hd"><div class="co"><div class="nm">${esc(co.name)}</div><div>${esc(co.add1)}</div>` +
          `<div>${esc(co.add2)}</div><div>${esc(co.city)}</div></div>` +
          `<div class="vch"><div><b>${esc(copy || 'ORIGINAL')}</b></div>` +
          `<div>Vch Date : ${esc(formatDesktopDate(r.VCH_DATE))}</div>` +
          `<div>Vch No : ${esc(text(r.VCH_NO))}</div><div>Chq No :</div></div></div>` +
          `<div class="party"><div class="pl"><b>Party Name :</b> ${esc(text(r.AC_NAME))}</div>` +
          `<div class="bal">Amt Bal : ${money(0)} Dr</div></div>` +
          `<div class="ind">${esc(joined(party?.AC_ADD1, party?.AC_ADD2))}</div>` +
          `<div class="ind">${esc(joined(party?.AC_ADD3, party?.AC_CITY))}</div>` +
          `<div class="ind">${esc(mobile(party))}</div>` +
          `<div class="amt">Rs : <b>${money(paid)}</b></div>` +
          `<div class="words">${esc(words)}</div>` +
          `<div class="ft"><div>Net Due Amount : ${money(0)} Cr</div>` +
          `<div>Vch Desc : ${esc(text(r.IT_DESC))}</div></div>` +
          `<div class="sig"><div>Party signature.</div><div><div><b>For : ${esc(text(company?.CO_NAME))}</b></div>` +
          `<div style="margin-top:28px;text-align:right">signature.</div></div></div>` +
          `</section>`
        );
      })
      .join('');
    return (
      `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>` +
      `body{font-family:Arial,sans-serif;font-size:11px;color:#111;margin:24px}` +
      `h1{font-size:15px;margin:0 0 6px;text-align:center;border:1px solid #333;padding:4px}` +
      `.rcpt{border:1px solid #333;padding:8px;margin-bottom:18px;page-break-inside:avoid}` +
      `.hd{display:flex;justify-content:space-between;border-bottom:1px solid #333;padding-bottom:6px}` +
      `.co .nm{font-weight:700;font-size:13px}.party{display:flex;justify-content:space-between;margin-top:8px}` +
      `.ind{padding-left:92px}.amt{margin-top:10px;font-size:13px}.words{margin-top:4px}` +
      `.ft{margin-top:10px;border-top:1px solid #333;padding-top:4px}.sig{display:flex;justify-content:space-between;margin-top:30px}` +
      `@page{@top-right{content:counter(page)}}</style></head><body>${receipts}</body></html>`
    );
  });
}
