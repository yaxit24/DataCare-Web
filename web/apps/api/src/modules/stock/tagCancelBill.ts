import { formatDesktopDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { esc, money, num, wt } from '../documents/docChrome.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

/**
 * TagCanBill (TR_TAG_CAN.BtnPrint_Click, TR_TAG_CAN.cs:5386-5440; report-specs/TagCanBill.spec.json), printed for
 * BAR_CAN_DATA's company, location, year, book and voucher:
 *
 * - page header: `{@RptTitle}` = BOOK_DATA.BOOK_NAME, `{@CurPag}`, `{@InVoiceType}` ('ORIGINAL' on a preview, the
 *   copy label when printed), the company block — LOCT_MAST's when CO_MAST.REP_ADD_TYPE is 'L' — with Vch Date and
 *   Vch No, then 'Party :' with the AC_MAST name, address and mobile;
 * - columns SNO / Item Name / Pcs. / Gr Wt. / Net Wt / Rate / Item Amt / Oth Amt / Net Amount;
 * - one group row per BAR_CAN_DETL line (`{@ItemName}` = TAG_NO + ' - ' + IT_NAME when the line has a tag), then its
 *   BAR_CAN_IDTL stone rows (item name, pcs, gross, rate, amount, net amount);
 * - 'Total :' with the summed Pcs, Gr Wt, Net Wt, Item Amt and Oth Amt; 'Vch Desc :'; 'For : ' + CO_NAME,
 *   'Party signature.' and 'signature.'.
 *
 * The extracted spec carries no numeric formats: weights print as 0.000 and amounts as 0.00.
 */
export class TagCancelBillNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'tag-cancel-not-found';
  constructor(voucherNo: string) {
    super(`tag cancel voucher not found: ${voucherNo}`);
    this.name = 'TagCancelBillNotFoundError';
  }
}

type Row = Record<string, any>;
const text = (value: unknown): string => String(value ?? '').trim();
const joined = (...parts: unknown[]) => parts.map(text).filter(Boolean).join(' , ');

export async function tagCancelBillHtml(
  prisma: any,
  scope: VoucherScope & { coYear?: string; coBook?: string },
  rawVoucherNo: string | number,
  copy?: string,
): Promise<string> {
  const voucherNo = formatVoucherNo(rawVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const key = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
    const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
    const dWhere = `d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6`;
    const headers: Row[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE","VCH_NO","AC_CODE","VCH_DESC" FROM "BAR_CAN_DATA" WHERE ${where} ORDER BY row_id LIMIT 1`,
      ...key,
    );
    const head = headers[0];
    if (!head) throw new TagCancelBillNotFoundError(voucherNo);
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
    const party: Row | undefined = text(head.AC_CODE)
      ? (
          (await tx.$queryRawUnsafe(
            `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
              ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END, row_id LIMIT 1`,
            scope.tenantId,
            scope.coCode,
            text(head.AC_CODE),
            scope.lcCode,
          )) as Row[]
        )[0]
      : undefined;
    const itemName = `(SELECT m."IT_NAME" FROM "ITEM_MAST" m WHERE m.tenant_id=d.tenant_id AND m."CO_CODE"=d."CO_CODE"
                        AND m."IT_CODE"=d."IT_CODE" LIMIT 1)`;
    const lines: Row[] = await tx.$queryRawUnsafe(
      `SELECT d."SR_NO",coalesce(d."TAG_NO",'') tag,coalesce(${itemName},'') name,coalesce(d."ITM_PCS",0)::float pcs,
              coalesce(d."ITM_GWT",0)::float gwt,coalesce(d."ITM_NWT",0)::float nwt,coalesce(d."ITM_RATE",0)::float rate,
              coalesce(d."ITM_AMT",0)::float amt,coalesce(d."OTH_AMT",0)::float oth
         FROM "BAR_CAN_DETL" d WHERE ${dWhere}
        ORDER BY d."SR_NO"`,
      ...key,
    );
    const stones: Row[] = await tx.$queryRawUnsafe(
      `SELECT d."SR_NO",coalesce(${itemName},'') name,coalesce(d."IT_PCS",0)::float pcs,coalesce(d."IT_GWT",0)::float gwt,
              coalesce(d."IT_RATE",0)::float rate,coalesce(d."IT_AMT",0)::float amt,coalesce(d."IT_NET_AMT",0)::float net
         FROM "BAR_CAN_IDTL" d WHERE ${dWhere}
        ORDER BY d."SR_NO",d."ISR_NO"`,
      ...key,
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
    const title = text(book?.name) || 'Tag Cancel';
    const totals = { pcs: 0, gwt: 0, nwt: 0, amt: 0, oth: 0 };
    const body = lines
      .map((line) => {
        totals.pcs += num(line.pcs);
        totals.gwt += num(line.gwt);
        totals.nwt += num(line.nwt);
        totals.amt += num(line.amt);
        totals.oth += num(line.oth);
        const name = text(line.tag) ? `${text(line.tag)} - ${text(line.name)}` : text(line.name);
        const own = stones.filter((s) => num(s.SR_NO) === num(line.SR_NO));
        return (
          `<tr class="grp"><td>${num(line.SR_NO)}</td><td>${esc(name)}</td><td class="r">${num(line.pcs)}</td>` +
          `<td class="r">${wt(line.gwt)}</td><td class="r">${wt(line.nwt)}</td><td class="r">${money(line.rate)}</td>` +
          `<td class="r">${money(line.amt)}</td><td class="r">${money(line.oth)}</td><td></td></tr>` +
          own
            .map(
              (s) =>
                `<tr><td></td><td class="sub">${esc(text(s.name))}</td><td class="r">${num(s.pcs)}</td>` +
                `<td class="r">${wt(s.gwt)}</td><td></td><td class="r">${money(s.rate)}</td>` +
                `<td class="r">${money(s.amt)}</td><td></td><td class="r">${money(s.net)}</td></tr>`,
            )
            .join('')
        );
      })
      .join('');
    const partyBlock = party
      ? `<div><b>Party :</b> ${esc(text(party.AC_NAME))}</div>` +
        `<div class="ind">${esc(joined(party.AC_ADD1, party.AC_ADD2))}</div>` +
        `<div class="ind">${esc(joined(party.AC_ADD3, party.AC_CITY))}</div>` +
        `<div class="ind">Mo : ${esc(text(party.AC_MOBILE))}</div>`
      : `<div><b>Party :</b></div>`;
    return (
      `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>` +
      `body{font-family:Arial,sans-serif;font-size:11px;color:#111;margin:24px}h1{font-size:15px;margin:0 0 6px;text-align:center}` +
      `.hd{display:flex;justify-content:space-between;border:1px solid #333;padding:6px 8px}.co .nm{font-weight:700;font-size:13px}` +
      `.ind{padding-left:58px}.party{margin:8px 0}table{border-collapse:collapse;width:100%}` +
      `th,td{padding:3px 6px;text-align:left}th{border-top:1px solid #333;border-bottom:1px solid #333}` +
      `td.r,th.r{text-align:right}tr.grp td{border-top:1px solid #ccc}td.sub{padding-left:22px;color:#444}` +
      `tfoot td{border-top:1px solid #333;font-weight:700}.ft{margin-top:14px}.sig{display:flex;justify-content:space-between;margin-top:34px}` +
      `@page{@top-right{content:counter(page)}}</style></head><body>` +
      `<h1>${esc(title)}</h1>` +
      `<div class="hd"><div class="co"><div class="nm">${esc(co.name)}</div><div>${esc(co.add1)}</div>` +
      `<div>${esc(co.add2)}</div><div>${esc(co.city)}</div></div>` +
      `<div><div><b>${esc(copy || 'ORIGINAL')}</b></div><div>Vch Date : ${esc(formatDesktopDate(head.VCH_DATE))}</div>` +
      `<div>Vch No : ${esc(text(head.VCH_NO))}</div></div></div>` +
      `<div class="party">${partyBlock}</div>` +
      `<table><thead><tr><th>SNO</th><th>Item Name</th><th class="r">Pcs.</th><th class="r">Gr Wt.</th>` +
      `<th class="r">Net Wt</th><th class="r">Rate</th><th class="r">Item Amt</th><th class="r">Oth Amt</th>` +
      `<th class="r">Net Amount</th></tr></thead><tbody>${body}</tbody>` +
      `<tfoot><tr><td></td><td>Total :</td><td class="r">${totals.pcs}</td><td class="r">${wt(totals.gwt)}</td>` +
      `<td class="r">${wt(totals.nwt)}</td><td></td><td class="r">${money(totals.amt)}</td>` +
      `<td class="r">${money(totals.oth)}</td><td></td></tr></tfoot></table>` +
      `<div class="ft"><b>Vch Desc :</b> ${esc(text(head.VCH_DESC))}</div>` +
      `<div class="sig"><div>Party signature.</div><div><div><b>For : ${esc(text(company?.CO_NAME))}</b></div>` +
      `<div style="margin-top:28px;text-align:right">signature.</div></div></div></body></html>`
    );
  });
}
