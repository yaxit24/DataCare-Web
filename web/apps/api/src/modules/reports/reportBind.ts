import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTenant } from '@datacare/db';
import { stageTagStockPrintRowsTx } from '../stock/tagPrint.js';

/**
 * Report data binder — resolves a Crystal report's {TABLE.FIELD} refs to real web-DB values.
 * Detects the report's primary table, queries its header/detail rows plus company/party data, and
 * bridges the desktop SL/PR/KR detail aliases (IT_* columns) to the current detail tables (ITM_*).
 * Single-table cash, tag-stock and ledger layouts use their own table as both header and detail.
 */
const fmt = (v: unknown): string =>
  v == null ? '' : v instanceof Date ? String(v).slice(0, 10) : String(v);
const flat = (prefix: string, row: Record<string, unknown> | undefined): Record<string, string> => {
  const o: Record<string, string> = {};
  for (const k in row || {}) o[`${prefix}.${k}`] = fmt((row as any)[k]);
  return o;
};
const DETAIL_ALIAS: Record<string, string> = {
  IT_PCS: 'ITM_PCS',
  IT_GWT: 'ITM_GWT',
  IT_NWT: 'ITM_NWT',
  IT_RATE: 'ITM_RATE',
  IT_AMT: 'ITM_AMT',
  IT_TOUCH: 'ITM_TOUCH',
  IT_FINE: 'ITM_FINE',
  IT_CODE: 'IT_CODE',
  IT_NAME: 'IT_CODE',
  LBR_AMT: 'LBR_AMT',
  IT_MRP: 'ITM_MRP',
  DESIGN_NO: 'DESIGN_NO',
  ITM_SIZE: 'ITM_SIZE',
  HM_ID: 'HM_ID',
  NET_AMT: 'NET_AMT',
  ITM_PCS: 'ITM_PCS',
  ITM_GWT: 'ITM_GWT',
  ITM_NWT: 'ITM_NWT',
  ITM_RATE: 'ITM_RATE',
  ITM_AMT: 'ITM_AMT',
};
type Family = { detail: string; alias: string[]; orderBy?: string; partyAliases?: string[] };

const FAMILIES: Record<string, Family> = {
  SL_DATA: { detail: 'SL_DETL', alias: ['SL_IDTL', 'ITEM_MAST_IDTL'], orderBy: 'SR_NO' },
  PR_DATA: { detail: 'PR_DETL', alias: ['PR_IDTL', 'ITEM_MAST_IDTL'], orderBy: 'SR_NO' },
  KR_DATA: { detail: 'KR_DETL', alias: ['KR_IDTL', 'ITEM_MAST_IDTL'], orderBy: 'SR_NO' },
  CASH_DATA: { detail: 'CASH_DATA', alias: [], orderBy: 'SR_NO' },
  TAG_STOCK_PRINT: { detail: 'TAG_STOCK_PRINT', alias: [], orderBy: 'SR_NO' },
  AC_DATA: { detail: 'AC_DATA', alias: [], partyAliases: ['AC_MAST', 'AC_MAST_LEDR'] },
};

/** Scan the spec's data sources/formulas for its primary database table. */
function detectFamily(spec: any): string {
  const txt = JSON.stringify(spec);
  for (const table of Object.keys(FAMILIES)) if (txt.includes(table)) return table;
  return 'SL_DATA';
}

export interface BindScope {
  tenantId: string;
  coCode: string;
  coBook: string;
  vchNo: string | number;
  /** Optional narrowing for report staging tables (TAG_STOCK_PRINT). */
  lcCode?: string;
  coYear?: string;
}

export async function bindReport(
  prisma: any,
  spec: any,
  s: BindScope,
): Promise<{
  header: Record<string, string>;
  detailRows: Record<string, string>[];
  company: string;
} | null> {
  const headerTable = detectFamily(spec);
  const fam = FAMILIES[headerTable] ?? FAMILIES.SL_DATA!;
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const q = (sql: string, ...p: unknown[]) => tx.$queryRawUnsafe(sql, ...p);
    // TAG_STOCK_PRINT is a report staging table, not a voucher table: the desktop clears and
    // repopulates it from BAR_DETL at report time (RP_PHY_STOCK.cs:1830-1838, RP_HUID) and only
    // then reads it. Staging here reproduces that order, so the report never binds stale rows.
    if (headerTable === 'TAG_STOCK_PRINT') {
      await stageTagStockPrintRowsTx(tx, s.tenantId, {
        coCode: s.coCode,
        lcCode: s.lcCode,
        coYear: s.coYear,
      });
    }
    const h = (
      await q(
        `SELECT * FROM "${headerTable}" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
        s.coCode,
        s.coBook,
        formatVoucherNo(s.vchNo),
      )
    )[0];
    if (!h) return null;
    const orderBy = fam.orderBy ? ` ORDER BY "${fam.orderBy}"` : '';
    const det: any[] = await q(
      `SELECT * FROM "${fam.detail}" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3${orderBy}`,
      s.coCode,
      s.coBook,
      formatVoucherNo(s.vchNo),
    );
    const co = (await q(`SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`, s.coCode))[0] || {};
    const party = h.AC_CODE
      ? (
          await q(
            `SELECT * FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
            s.coCode,
            h.AC_CODE,
          )
        )[0] || {}
      : {};
    const partyBindings = Object.assign(
      {},
      ...(fam.partyAliases ?? ['AC_MAST']).map((alias) => flat(alias, party)),
    );
    const header = { ...flat(headerTable, h), ...flat('CO_MAST', co), ...partyBindings };
    const detailRows = det.map((d) => {
      const row = flat(fam.detail, d);
      for (const [crystal, web] of Object.entries(DETAIL_ALIAS)) {
        const v = fmt(d[web]);
        for (const a of fam.alias) row[`${a}.${crystal}`] = v;
      }
      return row;
    });
    return { header, detailRows, company: fmt(co.CO_NAME) || 'Company' };
  });
}
