import { formatDesktopDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { esc, money, num, wt } from '../documents/docChrome.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

/**
 * AprBill (TR_APR_ISU.cs:6712-6772; report-specs/AprBill.spec.json).
 *
 * The extracted A4 portrait layout binds APR_DATA → APR_DETL → APR_IDTL, with the configured book
 * name as title, company/location address, Vch Date/No, party block, SNO / Item Name / Pcs. / Gr Wt.
 * / Net Wt / Rate / Item Amt / Oth Amt / Net Amount, component rows, totals, Vch Desc and signatures.
 */
export class ApprovalBillNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'approval-not-found';
  constructor(voucherNo: string) {
    super(`approval voucher not found: ${voucherNo}`);
    this.name = 'ApprovalBillNotFoundError';
  }
}

type Row = Record<string, any>;
const text = (value: unknown): string => String(value ?? '').trim();
const joined = (...values: unknown[]) => values.map(text).filter(Boolean).join(' , ');

export async function approvalBillHtml(
  prisma: any,
  scope: VoucherScope & { coYear?: string; coBook?: string },
  rawVoucherNo: number | string,
  copy?: string,
): Promise<string> {
  const voucherNo = formatVoucherNo(rawVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const key = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
    const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
    const [head]: Row[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE","VCH_NO","AC_CODE","VCH_DESC" FROM "APR_DATA" WHERE ${where}
        ORDER BY row_id LIMIT 1`,
      ...key,
    );
    if (!head) throw new ApprovalBillNotFoundError(voucherNo);
    const [book]: Row[] = await tx.$queryRawUnsafe(
      `SELECT coalesce("BOOK_NAME",'') name FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
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
      `SELECT * FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    const [party]: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        ORDER BY CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END,row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      text(head.AC_CODE),
      scope.lcCode,
    );
    const lines: Row[] = await tx.$queryRawUnsafe(
      `SELECT d."SR_NO",coalesce(d."TAG_NO",'') tag,coalesce(i."IT_NAME",'') name,
              coalesce(d."ITM_PCS",0)::float pcs,coalesce(d."ITM_GWT",0)::float gwt,
              coalesce(d."ITM_NWT",0)::float nwt,coalesce(d."ITM_RATE",0)::float rate,
              coalesce(d."ITM_AMT",0)::float amount,coalesce(d."OTH_AMT",0)::float other,
              coalesce(d."NET_AMT",0)::float net
         FROM "APR_DETL" d LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id
          AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
          AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO",d.row_id`,
      ...key,
    );
    const stones: Row[] = await tx.$queryRawUnsafe(
      `SELECT d."SR_NO",coalesce(i."IT_NAME",d."DM_NAME",'') name,
              coalesce(d."IT_PCS",0)::float pcs,coalesce(d."IT_GWT",0)::float gwt,
              coalesce(d."IT_RATE",0)::float rate,coalesce(d."IT_AMT",0)::float amount,
              coalesce(d."IT_NET_AMT",0)::float net
         FROM "APR_IDTL" d LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id
          AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
          AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO",d."ISR_NO",d.row_id`,
      ...key,
    );
    const useLocation = text(company?.REP_ADD_TYPE).toUpperCase() === 'L' && location;
    const address = useLocation
      ? {
          name: text(location.LC_NAME),
          line1: text(location.LC_ADD1),
          line2: joined(location.LC_ADD2, location.LC_ADD3),
          city: `${text(location.LC_CITY)} Mo : ${text(location.LC_MOBILE)} Ph : ${text(location.LC_PHONE)}`,
        }
      : {
          name: text(company?.CO_NAME),
          line1: text(company?.CO_ADD1),
          line2: joined(company?.CO_ADD2, company?.CO_ADD3),
          city: `${text(company?.CO_CITY)} Mo : ${text(company?.CO_MOBILE)} Ph : ${text(company?.CO_PHONE)}`,
        };
    const totals = { pcs: 0, gross: 0, net: 0, amount: 0, other: 0, total: 0 };
    const body = lines
      .map((line) => {
        totals.pcs += num(line.pcs);
        totals.gross += num(line.gwt);
        totals.net += num(line.nwt);
        totals.amount += num(line.amount);
        totals.other += num(line.other);
        totals.total += num(line.net);
        const tag = text(line.tag);
        const name = tag ? `${tag} - ${text(line.name)}` : text(line.name);
        const components = stones
          .filter((stone) => num(stone.SR_NO) === num(line.SR_NO))
          .map(
            (stone) =>
              `<tr><td></td><td class="sub">${esc(text(stone.name))}</td>` +
              `<td class="r">${num(stone.pcs)}</td><td class="r">${wt(stone.gwt)}</td><td></td>` +
              `<td class="r">${money(stone.rate)}</td><td class="r">${money(stone.amount)}</td>` +
              `<td></td><td class="r">${money(stone.net)}</td></tr>`,
          )
          .join('');
        return (
          `<tr class="grp"><td>${num(line.SR_NO)}</td><td>${esc(name)}</td>` +
          `<td class="r">${num(line.pcs)}</td><td class="r">${wt(line.gwt)}</td>` +
          `<td class="r">${wt(line.nwt)}</td><td class="r">${money(line.rate)}</td>` +
          `<td class="r">${money(line.amount)}</td><td class="r">${money(line.other)}</td>` +
          `<td class="r">${money(line.net)}</td></tr>${components}`
        );
      })
      .join('');
    const title = text(book?.name) || 'Approval';
    return (
      `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>` +
      `body{font-family:Arial,sans-serif;font-size:11px;color:#111;margin:24px}h1{text-align:center;font-size:15px}` +
      `.hd{display:flex;justify-content:space-between;border:1px solid #333;padding:6px 8px}.nm{font-weight:700;font-size:13px}` +
      `.party{margin:8px 0}.ind{padding-left:58px}table{border-collapse:collapse;width:100%}` +
      `th,td{padding:3px 6px;text-align:left}th{border-top:1px solid #333;border-bottom:1px solid #333}` +
      `.r{text-align:right}tr.grp td{border-top:1px solid #ccc}.sub{padding-left:22px;color:#444}` +
      `tfoot td{border-top:1px solid #333;font-weight:700}.sig{display:flex;justify-content:space-between;margin-top:34px}` +
      `@page{@top-right{content:counter(page)}}</style></head><body><h1>${esc(title)}</h1>` +
      `<div class="hd"><div><div class="nm">${esc(address.name)}</div><div>${esc(address.line1)}</div>` +
      `<div>${esc(address.line2)}</div><div>${esc(address.city)}</div></div>` +
      `<div><b>${esc(copy || 'ORIGINAL')}</b><div>Vch Date : ${esc(formatDesktopDate(head.VCH_DATE))}</div>` +
      `<div>Vch No : ${esc(text(head.VCH_NO))}</div></div></div>` +
      `<div class="party"><b>Party :</b> ${esc(text(party?.AC_NAME))}` +
      `<div class="ind">${esc(joined(party?.AC_ADD1, party?.AC_ADD2))}</div>` +
      `<div class="ind">${esc(joined(party?.AC_ADD3, party?.AC_CITY))}</div>` +
      `<div class="ind">Mo : ${esc(text(party?.AC_MOBILE))}</div></div>` +
      `<table><thead><tr><th>SNO</th><th>Item Name</th><th class="r">Pcs.</th><th class="r">Gr Wt.</th>` +
      `<th class="r">Net Wt</th><th class="r">Rate</th><th class="r">Item Amt</th>` +
      `<th class="r">Oth Amt</th><th class="r">Net Amount</th></tr></thead><tbody>${body}</tbody>` +
      `<tfoot><tr><td></td><td>Total :</td><td class="r">${totals.pcs}</td><td class="r">${wt(totals.gross)}</td>` +
      `<td class="r">${wt(totals.net)}</td><td></td><td class="r">${money(totals.amount)}</td>` +
      `<td class="r">${money(totals.other)}</td><td class="r">${money(totals.total)}</td></tr></tfoot></table>` +
      `<div><b>Vch Desc :</b> ${esc(text(head.VCH_DESC))}</div>` +
      `<div class="sig"><div>Party signature.</div><div><b>For : ${esc(text(company?.CO_NAME))}</b>` +
      `<div style="margin-top:28px;text-align:right">signature.</div></div></div></body></html>`
    );
  });
}
