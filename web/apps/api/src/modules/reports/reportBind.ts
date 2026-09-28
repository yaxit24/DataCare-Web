import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTenant } from '@datacare/db';
import { stageTagStockPrintRowsTx } from '../stock/tagPrint.js';
import { resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { OrderImageError, resolveOrderImageTx } from '../images/orderImage.js';
import type { OrderReportImages } from './orderReportImages.js';
import {
  completeOrderFields,
  orderFormulaValues,
  orderParentFormulaValues,
  sumReportValues,
  type BoundSubreport,
  type OrderReportCopy,
} from './orderReportValues.js';
import type { RptSpec } from './reportEngine.js';
import {
  resolveReportBinding,
  UnsupportedReportBindingError,
  type ParentChildBands,
  type ReportRow,
} from './reportBindingContract.js';

export { UnsupportedReportBindingError } from './reportBindingContract.js';

const fmt = (v: unknown): string =>
  v == null ? '' : v instanceof Date ? v.toISOString().slice(0, 10) : String(v);
const flat = (prefix: string, row: Record<string, unknown> | undefined): ReportRow => {
  const out: ReportRow = {};
  for (const [key, value] of Object.entries(row ?? {})) {
    if (key !== '__item' && key !== '__voucherTime') out[`${prefix}.${key}`] = fmt(value);
  }
  return out;
};
const itemBinding = (alias: string, row: Record<string, unknown> | null) =>
  flat(alias, { IT_NAME: null, HSN_CODE: null, PR_CODE: null, GR_CODE: null, ...row });

export interface BindScope {
  tenantId: string;
  coCode: string;
  coBook: string;
  vchNo: string | number;
  lcCode: string;
  coYear: string;
  orderFamily?: 'SALES ORDER' | 'TOUR ORDER';
  copy?: OrderReportCopy;
  orderDataType?: string;
}

export interface BoundReport {
  header: ReportRow;
  /** Parent rows only. Child datasets never change parent cardinality or amounts. */
  detailRows: ReportRow[];
  datasets: Record<string, ReportRow[]>;
  parentChild?: ParentChildBands;
  subreports?: Record<string, BoundSubreport>;
  orderImages?: OrderReportImages;
  company: string;
}

export async function bindReport(
  prisma: any,
  spec: RptSpec,
  s: BindScope,
): Promise<BoundReport | null> {
  const contract = resolveReportBinding(spec);
  const headerTable = contract.header;
  return withTenant(
    prisma,
    s.tenantId,
    async (tx: any) => {
      const q = (sql: string, ...p: unknown[]): Promise<any[]> => tx.$queryRawUnsafe(sql, ...p);
      const refuse = (reason: string): never => {
        throw new UnsupportedReportBindingError(spec.report, reason);
      };
      if (contract.orderDocument) {
        if (
          !s.orderFamily ||
          (contract.orderDocument.family !== 'either' &&
            s.orderFamily !== contract.orderDocument.family)
        )
          return refuse('wrong-order-document-family');
        await resolveBookPolicyTx(tx, s, s.orderFamily, {
          requireExplicitMainBook: true,
          expectedTable: 'SL_ORD_DATA',
        });
      }
      if (headerTable === 'TAG_STOCK_PRINT') {
        // RP_PHY_STOCK.cs:1830-1838 stages BAR_DETL before reading this print table.
        await stageTagStockPrintRowsTx(tx, s.tenantId, {
          coCode: s.coCode,
          lcCode: s.lcCode,
          coYear: s.coYear,
        });
      }
      const key = [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook, formatVoucherNo(s.vchNo)];
      const scope = (alias = '') => {
        const a = alias ? `${alias}.` : '';
        return `${a}tenant_id=$1 AND ${a}"CO_CODE"=$2 AND ${a}"LC_CODE"=$3
        AND ${a}"CO_YEAR"=$4 AND ${a}"CO_BOOK"=$5 AND ${a}"VCH_NO"=$6`;
      };
      const orderBy =
        headerTable === contract.detail && contract.orderBy
          ? ` ORDER BY "${contract.orderBy}"`
          : '';
      // Prisma Date values retain only milliseconds; the ledger stores six fractional digits.
      // Keep the exact database timestamp in this same snapshot for the balance cutoff.
      const timestampColumn = contract.orderDocument ? ', "VCH_TIME"::text AS "__voucherTime"' : '';
      const headers = await q(
        `SELECT *${timestampColumn} FROM "${headerTable}" WHERE ${scope()}${orderBy}`,
        ...key,
      );
      const h = headers[0];
      if (!h) return null;
      if ((headerTable !== contract.detail || contract.orderDocument) && headers.length !== 1)
        return refuse('duplicate-voucher-header');
      // ITEM_MAST is company-owned. The child alias joins the CHILD IT_CODE, never the parent.
      const itemRows = (table: string, child: boolean) =>
        q(
          `SELECT d.*, row_to_json(i) AS "__item" FROM "${table}" d
        LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
        WHERE ${scope('d')} ORDER BY d."SR_NO"${child ? ',d."ISR_NO",d.row_id' : ''}`,
          ...key,
        );
      const det =
        headerTable === contract.detail ? headers : await itemRows(contract.detail, false);
      const children = contract.child ? await itemRows(contract.child, true) : [];
      const orderParents =
        contract.orderDocument && !contract.orderDocument.orderedItems
          ? await itemRows('SL_ORD_DETL', false)
          : det;
      if (contract.orderDocument && contract.orderDocument.orderedItems !== orderParents.length > 0)
        return refuse('wrong-order-document-shape');
      if (contract.orderDocument?.orderedItems) {
        const settings = await q(
          'SELECT "ORD_IMG_PRINT" FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2',
          s.tenantId,
          s.coCode,
        );
        const flags = new Set(
          settings.map(
            (row) =>
              String(row.ORD_IMG_PRINT ?? '')
                .trim()
                .toUpperCase() || 'N',
          ),
        );
        if (flags.size > 1) return refuse('ambiguous-order-image-setting');
        if (flags.has('Y') !== Boolean(contract.orderDocument.images)) {
          const selected = flags.has('Y')
            ? s.orderFamily === 'TOUR ORDER'
              ? 'TourOrdImg'
              : 'OrdVchImg'
            : s.orderFamily === 'TOUR ORDER'
              ? 'TourOrdVch'
              : 'OrderBill';
          throw new UnsupportedReportBindingError(selected, 'order-image-template-mismatch');
        }
      }
      const co =
        (
          await q(
            'SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2',
            s.tenantId,
            s.coCode,
          )
        )[0] ?? {};
      const partyRows = h.AC_CODE
        ? await q(
            'SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4',
            s.tenantId,
            s.coCode,
            s.lcCode,
            h.AC_CODE,
          )
        : [];
      if (partyRows.length > 1) return refuse('ambiguous-party');
      const party = partyRows[0] ?? {};
      const bookRows = await q(
        'SELECT * FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4',
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coBook,
      );
      if (bookRows.length > 1) return refuse('ambiguous-book');
      const locationRows = await q(
        'SELECT * FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3',
        s.tenantId,
        s.coCode,
        s.lcCode,
      );
      if (locationRows.length > 1) return refuse('ambiguous-location');
      const partyBindings = Object.assign(
        {},
        ...(contract.partyAliases ?? ['AC_MAST']).map((alias) => flat(alias, party)),
      );
      let header: ReportRow = {
        ...flat(headerTable, h),
        ...flat('CO_MAST', co),
        ...flat('BOOK_DATA', bookRows[0]),
        ...flat('LOCT_MAST', locationRows[0]),
        ...partyBindings,
      };
      const detailRows = det
        .map((d) => ({
          ...flat(contract.detail, d),
          ...itemBinding('ITEM_MAST', d.__item),
        }))
        .map((row) =>
          contract.orderDocument?.orderedItems ? orderParentFormulaValues(spec, row) : row,
        );
      const childRows = children.map((d) => ({
        ...flat(contract.child!, d),
        ...itemBinding('ITEM_MAST_IDTL', d.__item),
      }));
      const datasets = { [headerTable]: [flat(headerTable, h)], [contract.detail]: detailRows };
      let subreports: Record<string, BoundSubreport> | undefined;
      if (contract.orderDocument) {
        const received = await q(
          `SELECT * FROM "SL_PR_DETL" WHERE ${scope()} ORDER BY "SR_NO",row_id`,
          ...key,
        );
        if (
          new Set(received.map((row) => fmt(row.SR_NO))).size !== received.length ||
          received.some((row) => row.SR_NO == null)
        )
          return refuse('ambiguous-received-metal-serial');
        const receivedRows = received.map((row) => flat('SL_PR_DETL', row));
        const timestamp = h.__voucherTime;
        if (
          typeof timestamp !== 'string' ||
          !/^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}(?:\.\d{1,6})?$/.test(timestamp)
        )
          return refuse('missing-order-voucher-timestamp');
        const dataType = s.orderDataType ?? 'C';
        if (!/^[A-Z]$/.test(dataType)) return refuse('invalid-order-data-type');
        // DC_Main.MsAcBal: opening is before the voucher's timestamp, closing includes it.
        // Preserve same-day entries. Historical Date-only rows need source reimport; no clock is invented.
        const balances = await q(
          `SELECT
          COALESCE(SUM(CASE WHEN "ENTRY_TIME" < $6::timestamp THEN "CR_AMT"-"DR_AMT" END),0) AS opening,
          COALESCE(SUM(CASE WHEN "ENTRY_TIME" <= $6::timestamp THEN "CR_AMT"-"DR_AMT" END),0) AS closing
          FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "AC_CODE"=$5 AND ($7='C' OR "DATA_TYPE"=$7)`,
          s.tenantId,
          s.coCode,
          s.lcCode,
          s.coYear,
          h.AC_CODE ?? '',
          timestamp,
          dataType,
        );
        header = orderFormulaValues(
          spec,
          completeOrderFields(spec, header),
          detailRows,
          receivedRows,
          { opening: fmt(balances[0]?.opening) || '0', closing: fmt(balances[0]?.closing) || '0' },
          s.copy,
        );
        subreports = {
          OrdRec: {
            detailRows: receivedRows,
            header: {
              ...completeOrderFields(spec.subreports!.OrdRec!, {}),
              'Sum ({SL_PR_DETL.ITM_PCS})': sumReportValues(receivedRows, 'SL_PR_DETL.ITM_PCS'),
              'Sum ({SL_PR_DETL.ITM_NWT})': sumReportValues(receivedRows, 'SL_PR_DETL.ITM_NWT'),
            },
          },
        };
        datasets.SL_PR_DETL = receivedRows;
      }
      let parentChild: ParentChildBands | undefined;
      if (contract.child) {
        datasets[contract.child] = childRows;
        const groups = det.map((d, index) => ({
          key: fmt(d.SR_NO),
          parent: detailRows[index]!,
          children: [] as ReportRow[],
        }));
        const parentMap = new Map(groups.map((group) => [group.key, group]));
        if (parentMap.size !== groups.length || groups.some((group) => group.key === ''))
          return refuse('ambiguous-parent-serial');
        const childKeys = new Set<string>();
        children.forEach((child, index) => {
          const parent = parentMap.get(fmt(child.SR_NO));
          if (!parent) return refuse('orphan-child');
          const childKey = JSON.stringify([fmt(child.SR_NO), fmt(child.ISR_NO)]);
          if (child.ISR_NO == null || childKeys.has(childKey))
            return refuse('ambiguous-child-serial');
          childKeys.add(childKey);
          parent.children.push(childRows[index]!);
        });
        parentChild = {
          parentSections: contract.parentSections!,
          childSections: contract.childSections!,
          parentFooterSections: contract.parentFooterSections!,
          groups,
        };
      }
      let orderImages: OrderReportImages | undefined;
      if (contract.orderDocument?.images) {
        orderImages = {};
        for (const parent of det) {
          try {
            orderImages[fmt(parent.SR_NO)] = await resolveOrderImageTx(
              tx,
              s,
              s.orderFamily!,
              h,
              parent,
            );
          } catch (error) {
            if (error instanceof OrderImageError) return refuse(`order-image:${error.code}`);
            throw error;
          }
        }
      }
      return {
        header,
        detailRows,
        datasets,
        parentChild,
        subreports,
        orderImages,
        company: fmt(co.CO_NAME) || 'Company',
      };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}
