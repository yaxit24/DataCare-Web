import { withTxBudget } from '../shared/txBudget.js';
import { applyFilters } from './reportFilters.js';
import type { ReportScope } from './reports.js';

const text = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};

const str = (v: unknown): string => String(v ?? '').trim();

const dateText = (v: unknown): string | null => {
  if (v instanceof Date) return v.toISOString().slice(0, 10);
  const s = text(v);
  return s ? s.slice(0, 10) : null;
};

const boolFlag = (v: unknown, fallback = true): boolean => {
  const s = str(v).toLowerCase();
  if (!s) return fallback;
  return !['0', 'false', 'n', 'no', 'all'].includes(s);
};

const todayIso = (): string => new Date().toISOString().slice(0, 10);

function entryDateRange(s: ReportScope): { fromDate: string; toDate: string } {
  const fromDate = s.fromDate ?? todayIso();
  const toDate = s.toDate ?? fromDate;
  if (fromDate > toDate) {
    const err = new Error('fromDate must be before or equal to toDate');
    err.name = 'ReportValidationError';
    throw err;
  }
  return { fromDate, toDate };
}

export interface EntryCheckOptions {
  /** Desktop checkbox `Only Panding Chk`; default checked. */
  pendingOnly?: boolean | string;
  /** Desktop `cboUser`. */
  userName?: string;
}

export interface EntryCheckRow {
  srNo: number;
  coBook: string | null;
  bookName: string | null;
  mainBook: string | null;
  acName: string | null;
  vchNo: string | null;
  vchDate: string | null;
  editDate: string | null;
  userName: string | null;
  editUser: string | null;
  acCode: string | null;
  entryCheck: string | null;
}

export interface EntryCheckDetailOptions {
  coBook: string;
  vchNo: string;
}

export interface EntryCheckDetailRow extends EntryCheckRow {
  entryTime: string | null;
  field: string | null;
  oldValue: string | null;
  newValue: string | null;
}

export interface EntryCheckMarkRow {
  coBook?: string | null;
  vchNo?: string | null;
  editDate?: string | null;
}

function requireCode(value: unknown, name: string, max: number): string {
  const s = str(value).slice(0, max);
  if (!s) {
    const err = new Error(`${name} is required`);
    err.name = 'ReportValidationError';
    throw err;
  }
  return s;
}

/**
 * Desktop `RP_USER.EntryCheckSumm`.
 *
 * The desktop groups `USER_DATA` by book/voucher/edit date and filters by user, book, account and the
 * pending-only checkbox. The web keeps those semantics, while scoping to the active financial year when the
 * web session provides one so the mark-checked action updates exactly the rows shown.
 */
export async function entryCheckReport(
  prisma: any,
  s: ReportScope,
  options: EntryCheckOptions = {},
): Promise<{ rows: EntryCheckRow[] }> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { fromDate, toDate } = entryDateRange(s);
    const params: unknown[] = [s.tenantId, s.coCode, s.lcCode, fromDate, toDate];
    const where = [
      'a.tenant_id=$1',
      'a."CO_CODE"::text=$2',
      'a."LC_CODE"::text=$3',
      'a."EDIT_DATE" >= $4::date',
      'a."EDIT_DATE" <= $5::date',
    ];
    if (s.coYear) {
      params.push(s.coYear);
      where.push(`a."CO_YEAR"::text=$${params.length}`);
    }
    if (boolFlag(options.pendingOnly, true)) {
      where.push(`coalesce(a."ENTRY_CHECK"::text,'') <> 'Y'`);
    }
    const userName = str(options.userName).slice(0, 30);
    if (userName) {
      params.push(userName);
      where.push(`a."USER_NAME"::text=$${params.length}`);
    }
    const filterSql = applyFilters('entry-check', s.filters, params);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY a."EDIT_DATE",a."CO_BOOK",a."VCH_NO") AS "srNo",
              a."CO_BOOK" AS "coBook",b."BOOK_NAME" AS "bookName",b."MAIN_BOOK" AS "mainBook",
              c."AC_NAME" AS "acName",a."VCH_NO" AS "vchNo",a."VCH_DATE"::text AS "vchDate",
              a."EDIT_DATE"::text AS "editDate",a."USER_NAME" AS "userName",a."NEW_USER" AS "editUser",
              a."AC_CODE" AS "acCode",a."ENTRY_CHECK" AS "entryCheck"
         FROM "USER_DATA" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"::text=a."CO_CODE"::text
          AND b."LC_CODE"::text=a."LC_CODE"::text AND b."CO_BOOK"::text=a."CO_BOOK"::text
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id AND c."CO_CODE"::text=a."CO_CODE"::text
          AND c."AC_CODE"::text=a."AC_CODE"::text
        WHERE ${where.join(' AND ')}${filterSql}
        GROUP BY a."CO_BOOK",b."BOOK_NAME",b."MAIN_BOOK",c."AC_NAME",a."VCH_NO",a."VCH_DATE",
                 a."EDIT_DATE",a."USER_NAME",a."NEW_USER",a."AC_CODE",a."ENTRY_CHECK"
        ORDER BY a."EDIT_DATE",a."CO_BOOK",a."VCH_NO"`,
      ...params,
    );
    return {
      rows: rows.map((r) => ({
        srNo: Number(r.srNo ?? 0),
        coBook: text(r.coBook),
        bookName: text(r.bookName),
        mainBook: text(r.mainBook),
        acName: text(r.acName),
        vchNo: text(r.vchNo),
        vchDate: dateText(r.vchDate),
        editDate: dateText(r.editDate),
        userName: text(r.userName),
        editUser: text(r.editUser),
        acCode: text(r.acCode),
        entryCheck: text(r.entryCheck),
      })),
    };
  });
}

/** Desktop double-click detail grid from `RP_USER.DGV_DoubleClick`. */
export async function entryCheckDetailReport(
  prisma: any,
  s: ReportScope,
  options: EntryCheckDetailOptions,
): Promise<{ rows: EntryCheckDetailRow[] }> {
  const coBook = requireCode(options.coBook, 'coBook', 8);
  const vchNo = requireCode(options.vchNo, 'vchNo', 12);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { fromDate, toDate } = entryDateRange(s);
    const params: unknown[] = [s.tenantId, s.coCode, s.lcCode, coBook, vchNo, fromDate, toDate];
    const where = [
      'a.tenant_id=$1',
      'a."CO_CODE"::text=$2',
      'a."LC_CODE"::text=$3',
      'a."CO_BOOK"::text=$4',
      'a."VCH_NO"::text=$5',
      'a."EDIT_DATE" >= $6::date',
      'a."EDIT_DATE" <= $7::date',
    ];
    if (s.coYear) {
      params.push(s.coYear);
      where.push(`a."CO_YEAR"::text=$${params.length}`);
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY a."EDIT_DATE" DESC,a.row_id DESC) AS "srNo",
              a."CO_BOOK" AS "coBook",b."BOOK_NAME" AS "bookName",b."MAIN_BOOK" AS "mainBook",
              c."AC_NAME" AS "acName",a."VCH_NO" AS "vchNo",a."VCH_DATE"::text AS "vchDate",
              a."EDIT_DATE"::text AS "editDate",a."USER_NAME" AS "userName",a."NEW_USER" AS "editUser",
              a."AC_CODE" AS "acCode",a."ENTRY_CHECK" AS "entryCheck",
              to_char(a."ENTRY_TIME",'YYYY-MM-DD HH24:MI:SS') AS "entryTime",
              a."COL_TYPE" AS "field",a."OLD_VAL" AS "oldValue",a."NEW_VAL" AS "newValue"
         FROM "USER_DATA" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"::text=a."CO_CODE"::text
          AND b."LC_CODE"::text=a."LC_CODE"::text AND b."CO_BOOK"::text=a."CO_BOOK"::text
         LEFT JOIN "AC_MAST" c
           ON c.tenant_id=a.tenant_id AND c."CO_CODE"::text=a."CO_CODE"::text
          AND c."AC_CODE"::text=a."AC_CODE"::text
        WHERE ${where.join(' AND ')}
        ORDER BY a."EDIT_DATE" DESC,a.row_id DESC`,
      ...params,
    );
    return {
      rows: rows.map((r) => ({
        srNo: Number(r.srNo ?? 0),
        coBook: text(r.coBook),
        bookName: text(r.bookName),
        mainBook: text(r.mainBook),
        acName: text(r.acName),
        vchNo: text(r.vchNo),
        vchDate: dateText(r.vchDate),
        editDate: dateText(r.editDate),
        userName: text(r.userName),
        editUser: text(r.editUser),
        acCode: text(r.acCode),
        entryCheck: text(r.entryCheck),
        entryTime: text(r.entryTime),
        field: text(r.field),
        oldValue: text(r.oldValue),
        newValue: text(r.newValue),
      })),
    };
  });
}

/** Desktop `BtnSave`: every checked summary row updates matching USER_DATA records to ENTRY_CHECK='Y'. */
export async function markEntryChecked(
  prisma: any,
  s: ReportScope,
  rows: EntryCheckMarkRow[],
): Promise<{ updated: number }> {
  if (!s.coYear) {
    const err = new Error('coYear is required');
    err.name = 'ReportValidationError';
    throw err;
  }
  const normalized = rows
    .map((row) => ({
      coBook: str(row.coBook).slice(0, 8),
      vchNo: str(row.vchNo).slice(0, 12),
      editDate: str(row.editDate).slice(0, 10),
    }))
    .filter((row) => row.coBook && row.vchNo && /^\d{4}-\d{2}-\d{2}$/.test(row.editDate));
  if (!normalized.length) {
    const err = new Error('at least one row with coBook, vchNo and editDate is required');
    err.name = 'ReportValidationError';
    throw err;
  }

  return withTxBudget(prisma, s.tenantId, 'voucher', async (tx: any) => {
    let updated = 0;
    for (const row of normalized) {
      const count = await tx.$executeRawUnsafe(
        `UPDATE "USER_DATA"
            SET "ENTRY_CHECK"='Y'
          WHERE tenant_id=$1 AND "CO_CODE"::text=$2 AND "LC_CODE"::text=$3 AND "CO_YEAR"::text=$4
            AND "CO_BOOK"::text=$5 AND "VCH_NO"::text=$6 AND "EDIT_DATE"=$7::date`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        row.coBook,
        row.vchNo,
        row.editDate,
      );
      updated += Number(count ?? 0);
    }
    return { updated };
  });
}

export interface UserWorkReportOptions {
  /** Desktop `cboUser`. */
  userName?: string;
  /** Desktop item checklist, represented as comma-separated item codes on the web. */
  itemCodes?: string | string[];
}

export interface UserWorkReportRow {
  srNo: number;
  user: string | null;
  book: string | null;
  vchDate: string | null;
  vchNo: string | null;
  acName: string | null;
  itCode: string | null;
  pcs: number | null;
  gWt: number | null;
  nWt: number | null;
  ghtPercent: number | null;
  fine: number | null;
  rate: number | null;
  itemAmount: number | null;
  labourRate: number | null;
  labourAmount: number | null;
  otherAmount: number | null;
  drAmount: number | null;
  crAmount: number | null;
  drFine: number | null;
  crFine: number | null;
  drSilver: number | null;
  crSilver: number | null;
  tax: number | null;
  cash: number | null;
  bank: number | null;
  upiAmount: number | null;
  card: number | null;
  orderAdjust: number | null;
  oldGoldAmount: number | null;
  oldSilverAmount: number | null;
  schemeAdjust: number | null;
  kasar: number | null;
  cashPaid: number | null;
  mobile: string | null;
  acCode: string | null;
  coBook: string | null;
  mainBook: string | null;
}

const numberOrNull = (v: unknown): number | null => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) && Math.abs(n) > 0.0000001 ? n : null;
};

function parseItemCodes(v: string | string[] | undefined): string[] {
  const raw = Array.isArray(v) ? v : String(v ?? '').split(',');
  return raw
    .map((x) => String(x).replace(/["']/g, '').trim().slice(0, 12))
    .filter(Boolean)
    .slice(0, 100);
}

/**
 * Desktop `RP_USER` / User Report mode (`DGV_ITM_FILL`).
 *
 * The desktop writes a temporary `TAG_STOCK_PRINT` list from `AC_DATA` and `MAIN_STOCK`, then enriches each
 * voucher with account balances, sale payment splits, scheme receipts, UPI totals, cash receipt splits and
 * stock item lines. This builder composes the same source rows directly so the report stays read-only.
 */
export async function userWorkReport(
  prisma: any,
  s: ReportScope,
  options: UserWorkReportOptions = {},
): Promise<{ rows: UserWorkReportRow[] }> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const { fromDate, toDate } = entryDateRange(s);
    const itemCodes = parseItemCodes(options.itemCodes);
    const params: unknown[] = [s.tenantId, s.coCode, s.lcCode, fromDate, toDate];
    const scopeWhere = (alias: string): string[] => [
      `${alias}.tenant_id=$1`,
      `${alias}."CO_CODE"::text=$2`,
      `${alias}."LC_CODE"::text=$3`,
      `${alias}."VCH_DATE" >= $4::date`,
      `${alias}."VCH_DATE" <= $5::date`,
    ];
    const yearWhere = (alias: string): string => {
      if (!s.coYear) return '';
      params.push(s.coYear);
      return ` AND ${alias}."CO_YEAR"::text=$${params.length}`;
    };
    const acYear = yearWhere('a');
    const stockYear = yearWhere('d');
    let itemSql = '';
    if (itemCodes.length) {
      params.push(itemCodes);
      itemSql = ` AND d."IT_CODE"::text = ANY($${params.length}::text[])`;
    }
    const seedParts: string[] = [];
    if (!itemCodes.length) {
      seedParts.push(
        `SELECT a."CO_CODE",a."LC_CODE",a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."VCH_DATE",
                c."MAIN_BOOK" AS "mainBook",c."BOOK_SNAME" AS "book",a."MAIN_USER" AS "mainUser",
                a."PARTY_AC_CODE" AS "AC_CODE"
           FROM "AC_DATA" a
           LEFT JOIN "BOOK_DATA" c
             ON c.tenant_id=a.tenant_id AND c."CO_CODE"::text=a."CO_CODE"::text
            AND c."LC_CODE"::text=a."LC_CODE"::text AND c."CO_BOOK"::text=a."CO_BOOK"::text
          WHERE ${scopeWhere('a').join(' AND ')}${acYear}
            AND coalesce(a."PARTY_AC_CODE"::text,'') <> ''
          GROUP BY a."CO_CODE",a."LC_CODE",a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."VCH_DATE",
                   c."MAIN_BOOK",c."BOOK_SNAME",a."MAIN_USER",a."PARTY_AC_CODE"`,
      );
    }
    seedParts.push(
      `SELECT d."CO_CODE",d."LC_CODE",d."CO_YEAR",d."CO_BOOK",d."VCH_NO",d."VCH_DATE",
              f."MAIN_BOOK" AS "mainBook",f."BOOK_SNAME" AS "book",d."MAIN_USER" AS "mainUser",
              d."AC_CODE" AS "AC_CODE"
         FROM "MAIN_STOCK" d
         LEFT JOIN "BOOK_DATA" f
           ON f.tenant_id=d.tenant_id AND f."CO_CODE"::text=d."CO_CODE"::text
          AND f."LC_CODE"::text=d."LC_CODE"::text AND f."CO_BOOK"::text=d."CO_BOOK"::text
        WHERE ${scopeWhere('d').join(' AND ')}${stockYear}${itemSql}
        GROUP BY d."CO_CODE",d."LC_CODE",d."CO_YEAR",d."CO_BOOK",d."VCH_NO",d."VCH_DATE",
                 f."MAIN_BOOK",f."BOOK_SNAME",d."MAIN_USER",d."AC_CODE"`,
    );

    const userName = str(options.userName).slice(0, 30);
    const outerWhere = ['true'];
    if (userName) {
      params.push(userName);
      outerWhere.push(`v."mainUser"::text=$${params.length}`);
    }
    const filterSql = applyFilters('user-report', s.filters, params);

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `WITH voucher_seed AS (
         ${seedParts.join('\nUNION ALL\n')}
       ), vouchers AS (
         SELECT DISTINCT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","mainBook","book","mainUser","AC_CODE"
           FROM voucher_seed
       ), stock_lines AS (
         SELECT v."CO_CODE" AS "keyCoCode",v."LC_CODE" AS "keyLcCode",v."CO_YEAR" AS "keyCoYear",
                v."CO_BOOK" AS "keyCoBook",v."VCH_NO" AS "keyVchNo",v."AC_CODE" AS "voucherAcCode",
                st."SR_NO",st.row_id,st."MAIN_USER" AS "stockMainUser",st."VCH_TYPE" AS "stockVchType",
                st."VCH_DATE" AS "stockVchDate",st."IT_CODE",st."ITM_PCS",
                st."ITM_GWT",st."ITM_NWT",st."GHT_PRC",st."ITM_FINE",st."ITM_RATE",st."ITM_AMT",
                st."LBR_RATE",st."LBR_AMT",st."OTH_AMT",st."AC_CODE" AS "stockAcCode",
                row_number() OVER (
                  PARTITION BY v."CO_CODE",v."LC_CODE",v."CO_YEAR",v."CO_BOOK",v."VCH_NO",v."AC_CODE"
                  ORDER BY st."SR_NO" NULLS LAST,st.row_id
                ) AS "stockOrd"
           FROM vouchers v
           JOIN "MAIN_STOCK" st
             ON st.tenant_id=$1 AND st."CO_CODE"::text=v."CO_CODE"::text AND st."LC_CODE"::text=v."LC_CODE"::text
            AND st."CO_YEAR"::text=v."CO_YEAR"::text AND st."CO_BOOK"::text=v."CO_BOOK"::text
            AND st."VCH_NO"::text=v."VCH_NO"::text
          ${itemCodes.length ? `WHERE st."IT_CODE"::text = ANY($${params.indexOf(itemCodes) + 1}::text[])` : ''}
       ), ac_totals AS (
         SELECT a."CO_CODE",a."LC_CODE",a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."AC_CODE",
                sum(coalesce(a."DR_AMT",0)) AS "drAmount",sum(coalesce(a."CR_AMT",0)) AS "crAmount",
                sum(CASE WHEN a."IT_TYPE"='G' AND a."SIGN"='-' THEN coalesce(a."FINE_WT",0) ELSE 0 END) AS "drFine",
                sum(CASE WHEN a."IT_TYPE"='G' AND a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE 0 END) AS "crFine",
                sum(CASE WHEN a."IT_TYPE"='S' AND a."SIGN"='-' THEN coalesce(a."FINE_WT",0) ELSE 0 END) AS "drSilver",
                sum(CASE WHEN a."IT_TYPE"='S' AND a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE 0 END) AS "crSilver"
           FROM "AC_DATA" a
          WHERE a.tenant_id=$1 AND a."CO_CODE"::text=$2 AND a."LC_CODE"::text=$3
            ${s.coYear ? 'AND a."CO_YEAR"::text=$6' : ''}
          GROUP BY a."CO_CODE",a."LC_CODE",a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."AC_CODE"
       ), sales AS (
         SELECT sl."CO_CODE",sl."LC_CODE",sl."CO_YEAR",sl."CO_BOOK",sl."VCH_NO",
                sum(coalesce(sl."TAX_AMT",0)) AS "tax",sum(coalesce(sl."CASH_AMT",0)) AS "cash",
                sum(coalesce(sl."CHQ_AMT",0)) AS "bank",sum(coalesce(sl."UPI_AMT",0)) AS "upiAmount",
                sum(coalesce(sl."CARD_AMT",0)) AS "card",sum(coalesce(sl."ADV_AMT",0)) AS "orderAdjust",
                sum(coalesce(sl."OLD_GL_AMT",0)) AS "oldGoldAmount",sum(coalesce(sl."OLD_SL_AMT",0)) AS "oldSilverAmount",
                sum(coalesce(sl."SCHM_AMT",0)) AS "schemeAdjust",
                sum(coalesce(sl."KASAR_AMT",0)+coalesce(sl."DISC_AMT",0)) AS "kasar",
                sum(coalesce(sl."CASH_PAID",0)) AS "cashPaid"
           FROM "SL_DATA" sl
          WHERE sl.tenant_id=$1 AND sl."CO_CODE"::text=$2 AND sl."LC_CODE"::text=$3
            ${s.coYear ? 'AND sl."CO_YEAR"::text=$6' : ''}
          GROUP BY sl."CO_CODE",sl."LC_CODE",sl."CO_YEAR",sl."CO_BOOK",sl."VCH_NO"
       ), scheme_cash AS (
         SELECT ad."CO_CODE",ad."LC_CODE",ad."CO_YEAR",ad."CO_BOOK",ad."VCH_NO",
                sum(CASE WHEN ad."REC_AC"='00001' THEN coalesce(ad."MEMB_AMT",0) ELSE 0 END) AS "cash",
                sum(CASE WHEN coalesce(ad."REC_AC"::text,'') <> '00001' THEN coalesce(ad."MEMB_AMT",0) ELSE 0 END) AS "bank"
           FROM "AD_DATA" ad
          WHERE ad.tenant_id=$1 AND ad."CO_CODE"::text=$2 AND ad."LC_CODE"::text=$3
            ${s.coYear ? 'AND ad."CO_YEAR"::text=$6' : ''}
            AND coalesce(ad."WITH_UPI"::text,'') <> 'Y'
          GROUP BY ad."CO_CODE",ad."LC_CODE",ad."CO_YEAR",ad."CO_BOOK",ad."VCH_NO"
       ), scheme_upi AS (
         SELECT up."CO_CODE",up."LC_CODE",up."CO_YEAR",up."CO_BOOK",up."VCH_NO",sum(coalesce(up."UPI_AMT",0)) AS "upiAmount"
           FROM "UPI_DATA" up
          WHERE up.tenant_id=$1 AND up."CO_CODE"::text=$2 AND up."LC_CODE"::text=$3
            ${s.coYear ? 'AND up."CO_YEAR"::text=$6' : ''}
          GROUP BY up."CO_CODE",up."LC_CODE",up."CO_YEAR",up."CO_BOOK",up."VCH_NO"
       ), bill_cash AS (
         SELECT cd."CO_CODE",cd."LC_CODE",cd."CO_YEAR",cd."CO_BOOK",cd."VCH_NO",
                sum(CASE WHEN cd."REC_AC_CODE"='00001' THEN coalesce(cd."REC_AMT",0) ELSE 0 END) AS "cash",
                sum(CASE WHEN coalesce(cd."REC_AC_CODE"::text,'') <> '00001' THEN coalesce(cd."REC_AMT",0) ELSE 0 END) AS "bank"
           FROM "CASH_DATA" cd
          WHERE cd.tenant_id=$1 AND cd."CO_CODE"::text=$2 AND cd."LC_CODE"::text=$3
            ${s.coYear ? 'AND cd."CO_YEAR"::text=$6' : ''}
          GROUP BY cd."CO_CODE",cd."LC_CODE",cd."CO_YEAR",cd."CO_BOOK",cd."VCH_NO"
       ), expanded AS (
         SELECT v.*,ac."AC_NAME",ac."AC_MOBILE",st.*,coalesce(st."stockOrd",1) AS "lineOrd",
                CASE WHEN st."stockOrd" IS NULL OR st."stockOrd"=1 THEN true ELSE false END AS "firstLine",
                at."drAmount",at."crAmount",at."drFine",at."crFine",at."drSilver",at."crSilver",
                sa."tax" AS "saleTax",sa."cash" AS "saleCash",sa."bank" AS "saleBank",sa."upiAmount" AS "saleUpi",
                sa."card" AS "saleCard",sa."orderAdjust" AS "saleOrderAdjust",sa."oldGoldAmount" AS "saleOldGold",
                sa."oldSilverAmount" AS "saleOldSilver",sa."schemeAdjust" AS "saleScheme",sa."kasar" AS "saleKasar",
                sa."cashPaid" AS "saleCashPaid",sc."cash" AS "schemeCash",sc."bank" AS "schemeBank",
                su."upiAmount" AS "schemeUpi",bc."cash" AS "billCash",bc."bank" AS "billBank"
           FROM vouchers v
           LEFT JOIN "AC_MAST" ac
             ON ac.tenant_id=$1 AND ac."CO_CODE"::text=v."CO_CODE"::text AND ac."AC_CODE"::text=v."AC_CODE"::text
           LEFT JOIN stock_lines st
             ON st."keyCoCode"::text=v."CO_CODE"::text AND st."keyLcCode"::text=v."LC_CODE"::text
            AND st."keyCoYear"::text=v."CO_YEAR"::text AND st."keyCoBook"::text=v."CO_BOOK"::text
            AND st."keyVchNo"::text=v."VCH_NO"::text AND st."voucherAcCode"::text=v."AC_CODE"::text
           LEFT JOIN ac_totals at
             ON at."CO_CODE"::text=v."CO_CODE"::text AND at."LC_CODE"::text=v."LC_CODE"::text
            AND at."CO_YEAR"::text=v."CO_YEAR"::text AND at."CO_BOOK"::text=v."CO_BOOK"::text
            AND at."VCH_NO"::text=v."VCH_NO"::text AND at."AC_CODE"::text=v."AC_CODE"::text
           LEFT JOIN sales sa
             ON sa."CO_CODE"::text=v."CO_CODE"::text AND sa."LC_CODE"::text=v."LC_CODE"::text
            AND sa."CO_YEAR"::text=v."CO_YEAR"::text AND sa."CO_BOOK"::text=v."CO_BOOK"::text
            AND sa."VCH_NO"::text=v."VCH_NO"::text
           LEFT JOIN scheme_cash sc
             ON sc."CO_CODE"::text=v."CO_CODE"::text AND sc."LC_CODE"::text=v."LC_CODE"::text
            AND sc."CO_YEAR"::text=v."CO_YEAR"::text AND sc."CO_BOOK"::text=v."CO_BOOK"::text
            AND sc."VCH_NO"::text=v."VCH_NO"::text
           LEFT JOIN scheme_upi su
             ON su."CO_CODE"::text=v."CO_CODE"::text AND su."LC_CODE"::text=v."LC_CODE"::text
            AND su."CO_YEAR"::text=v."CO_YEAR"::text AND su."CO_BOOK"::text=v."CO_BOOK"::text
            AND su."VCH_NO"::text=v."VCH_NO"::text
           LEFT JOIN bill_cash bc
             ON bc."CO_CODE"::text=v."CO_CODE"::text AND bc."LC_CODE"::text=v."LC_CODE"::text
            AND bc."CO_YEAR"::text=v."CO_YEAR"::text AND bc."CO_BOOK"::text=v."CO_BOOK"::text
            AND bc."VCH_NO"::text=v."VCH_NO"::text
          WHERE ${outerWhere.join(' AND ')}${filterSql}
       )
       SELECT row_number() OVER (ORDER BY "mainUser","VCH_DATE","CO_BOOK","VCH_NO","lineOrd") AS "srNo",
              coalesce("stockMainUser","mainUser") AS "user",coalesce("stockVchType","book") AS "book",
              coalesce("stockVchDate",expanded."VCH_DATE")::text AS "vchDate",expanded."VCH_NO" AS "vchNo",
              "AC_NAME" AS "acName","IT_CODE" AS "itCode","ITM_PCS" AS "pcs","ITM_GWT" AS "gWt",
              "ITM_NWT" AS "nWt","GHT_PRC" AS "ghtPercent","ITM_FINE" AS "fine","ITM_RATE" AS "rate",
              "ITM_AMT" AS "itemAmount","LBR_RATE" AS "labourRate","LBR_AMT" AS "labourAmount",
              "OTH_AMT" AS "otherAmount",
              CASE WHEN "firstLine" THEN "drAmount" ELSE 0 END AS "drAmount",
              CASE WHEN "firstLine" THEN "crAmount" ELSE 0 END AS "crAmount",
              CASE WHEN "firstLine" THEN "drFine" ELSE 0 END AS "drFine",
              CASE WHEN "firstLine" THEN "crFine" ELSE 0 END AS "crFine",
              CASE WHEN "firstLine" THEN "drSilver" ELSE 0 END AS "drSilver",
              CASE WHEN "firstLine" THEN "crSilver" ELSE 0 END AS "crSilver",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleTax" ELSE 0 END AS "tax",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleCash"
                   WHEN "firstLine" AND "mainBook"='MEMB ENTRY' THEN "schemeCash"
                   WHEN "firstLine" AND "mainBook"='BILL REC' THEN "billCash" ELSE 0 END AS "cash",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleBank"
                   WHEN "firstLine" AND "mainBook"='MEMB ENTRY' THEN "schemeBank"
                   WHEN "firstLine" AND "mainBook"='BILL REC' THEN "billBank" ELSE 0 END AS "bank",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleUpi"
                   WHEN "firstLine" AND "mainBook"='MEMB ENTRY' THEN "schemeUpi" ELSE 0 END AS "upiAmount",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleCard" ELSE 0 END AS "card",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleOrderAdjust" ELSE 0 END AS "orderAdjust",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleOldGold" ELSE 0 END AS "oldGoldAmount",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleOldSilver" ELSE 0 END AS "oldSilverAmount",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleScheme" ELSE 0 END AS "schemeAdjust",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleKasar" ELSE 0 END AS "kasar",
              CASE WHEN "firstLine" AND "mainBook"='SALES' THEN "saleCashPaid" ELSE 0 END AS "cashPaid",
              "AC_MOBILE" AS "mobile",coalesce("stockAcCode","AC_CODE") AS "acCode","CO_BOOK" AS "coBook",
              "mainBook" AS "mainBook"
         FROM expanded
        ORDER BY "mainUser","VCH_DATE","CO_BOOK","VCH_NO","lineOrd"`,
      ...params,
    );

    return {
      rows: rows.map((r) => ({
        srNo: Number(r.srNo ?? 0),
        user: text(r.user),
        book: text(r.book),
        vchDate: dateText(r.vchDate),
        vchNo: text(r.vchNo),
        acName: text(r.acName),
        itCode: text(r.itCode),
        pcs: numberOrNull(r.pcs),
        gWt: numberOrNull(r.gWt),
        nWt: numberOrNull(r.nWt),
        ghtPercent: numberOrNull(r.ghtPercent),
        fine: numberOrNull(r.fine),
        rate: numberOrNull(r.rate),
        itemAmount: numberOrNull(r.itemAmount),
        labourRate: numberOrNull(r.labourRate),
        labourAmount: numberOrNull(r.labourAmount),
        otherAmount: numberOrNull(r.otherAmount),
        drAmount: numberOrNull(r.drAmount),
        crAmount: numberOrNull(r.crAmount),
        drFine: numberOrNull(r.drFine),
        crFine: numberOrNull(r.crFine),
        drSilver: numberOrNull(r.drSilver),
        crSilver: numberOrNull(r.crSilver),
        tax: numberOrNull(r.tax),
        cash: numberOrNull(r.cash),
        bank: numberOrNull(r.bank),
        upiAmount: numberOrNull(r.upiAmount),
        card: numberOrNull(r.card),
        orderAdjust: numberOrNull(r.orderAdjust),
        oldGoldAmount: numberOrNull(r.oldGoldAmount),
        oldSilverAmount: numberOrNull(r.oldSilverAmount),
        schemeAdjust: numberOrNull(r.schemeAdjust),
        kasar: numberOrNull(r.kasar),
        cashPaid: numberOrNull(r.cashPaid),
        mobile: text(r.mobile),
        acCode: text(r.acCode),
        coBook: text(r.coBook),
        mainBook: text(r.mainBook),
      })),
    };
  });
}
