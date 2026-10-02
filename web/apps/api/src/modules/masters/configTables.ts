import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';

/**
 * The last group of desktop tables the web never wrote: small global configuration tables and two
 * report-staging tables.
 *
 * Each is here because the desktop writes it and the table exists in the restored production schema, so
 * "nothing reads it in the web today" is not sufficient reason to leave it unwritten — a report or screen
 * ported later would silently find it empty. Where a table is absent from the desktop's own schema
 * snapshot (`TAG_STOCK`, `MENU_DATA`, `APP_CHATMESSAGES`, `WEBHOOKINBOX`) it is waived instead, with
 * evidence, because the desktop code targets a table its own database does not have.
 */

const n = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
const t = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;
const d = (v: unknown): Date | null => {
  if (v == null || v === '') return null;
  const date = new Date(v as string);
  return Number.isNaN(date.getTime()) ? null : date;
};

// ---- WEIGHT_MAST -------------------------------------------------------------------------------

/**
 * `WEIGHT_MAST` — weight-slab to grid-column mapping, written by `MS_UPDATE`.
 *
 * Each row says "weights between LOW_WT and HIGH_WT belong in the column named COL_NAME", which is how
 * the desktop's stock reports lay weight bands across columns. Tenant-global: no company column.
 */
export const WEIGHT_MAST_COLUMNS = ['SR_NO', 'LOW_WT', 'HIGH_WT', 'COL_NAME'] as const;

export interface WeightSlab {
  srNo?: number;
  lowWt?: number;
  highWt?: number;
  colName?: string;
}

export async function setWeightSlabs(
  prisma: any,
  tenantId: string,
  slabs: WeightSlab[],
): Promise<number> {
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(`DELETE FROM "WEIGHT_MAST" WHERE tenant_id=$1`, tenantId);
    let written = 0;
    for (const [index, slab] of slabs.entries()) {
      // Bands must not overlap or the same weight would land in two columns.
      if (n(slab.highWt) < n(slab.lowWt)) {
        throw new Error(`setWeightSlabs: slab ${index + 1} has HIGH_WT below LOW_WT`);
      }
      await insertRowTx(tx, 'WEIGHT_MAST', tenantId, {
        SR_NO: slab.srNo ?? index + 1,
        LOW_WT: n(slab.lowWt),
        HIGH_WT: n(slab.highWt),
        COL_NAME: t(slab.colName, 20),
      });
      written += 1;
    }
    return written;
  });
}

// ---- USER_MAST ---------------------------------------------------------------------------------

/**
 * `USER_MAST` — a column-label mapping, written by `MS_UPDATE`.
 *
 * Despite the name this is not a user account table: its two columns map a physical table column
 * (`TBL_COL_NAME`) to the caption a shop wants shown for it (`COL_NAME`). Account records live in
 * `LOGIN_MAST`.
 */
export const USER_MAST_COLUMNS = ['TBL_COL_NAME', 'COL_NAME'] as const;

export interface ColumnLabel {
  tableColumn: string;
  label?: string;
}

export async function setColumnLabels(
  prisma: any,
  tenantId: string,
  labels: ColumnLabel[],
): Promise<number> {
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(`DELETE FROM "USER_MAST" WHERE tenant_id=$1`, tenantId);
    let written = 0;
    for (const label of labels) {
      const column = t(label.tableColumn, 20);
      if (!column) continue;
      await insertRowTx(tx, 'USER_MAST', tenantId, {
        TBL_COL_NAME: column,
        COL_NAME: t(label.label, 20),
      });
      written += 1;
    }
    return written;
  });
}

// ---- BOOK_IDTL ---------------------------------------------------------------------------------

/**
 * `BOOK_IDTL` — per-book account detail, written by `MS_USER`, `MS_AC_GROUP` and `MS_PRODUCT`.
 *
 * `AC_CODE`, `MAIN_BOOK` and `SR_NO` are NUMERIC here (unlike `BOOK_DETL`, where the same names are text)
 * — a real asymmetry in the restored schema, so values are written as numbers.
 */
export const BOOK_IDTL_COLUMNS = [
  'AC_CODE',
  'MAIN_BOOK',
  'SR_NO',
  'INOUT_TYPE',
  'AC_NAME',
  // SVR_PWD is a varchar(255) server-password slot the desktop carries on this row.
  'SVR_PWD',
] as const;

export interface BookAccountDetail {
  acCode?: number;
  mainBook?: number;
  srNo?: number;
  inoutType?: string;
  acName?: string;
  /** SVR_PWD — carried on the row by the desktop; never logged or returned by any read path. */
  serverPassword?: string;
}

export async function setBookAccountDetails(
  prisma: any,
  tenantId: string,
  rows: BookAccountDetail[],
): Promise<number> {
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(`DELETE FROM "BOOK_IDTL" WHERE tenant_id=$1`, tenantId);
    let written = 0;
    for (const [index, row] of rows.entries()) {
      await insertRowTx(tx, 'BOOK_IDTL', tenantId, {
        AC_CODE: n(row.acCode),
        MAIN_BOOK: n(row.mainBook),
        SR_NO: row.srNo ?? index + 1,
        INOUT_TYPE: t(row.inoutType, 1),
        AC_NAME: t(row.acName, 50),
        SVR_PWD: t(row.serverPassword, 255),
      });
      written += 1;
    }
    return written;
  });
}

// ---- ROJMEL_BAL --------------------------------------------------------------------------------

/**
 * `ROJMEL_BAL` — the closing cash carried by the day book, written by `RP_ROJMEL` per date.
 *
 * One row per company/location/date, so re-running a day closes over the previous value rather than
 * appending a second balance for the same day.
 */
export const ROJMEL_BAL_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'VCH_DATE',
  'CLOSING_CASH',
  'MAIN_USER',
] as const;

export async function setRojmelClosingCash(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
  vchDate: Date | string,
  closingCash: number,
  mainUser?: string,
): Promise<{ saved: true }> {
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "ROJMEL_BAL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "VCH_DATE"=$4::date`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      d(vchDate),
    );
    await insertRowTx(tx, 'ROJMEL_BAL', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      VCH_DATE: d(vchDate),
      CLOSING_CASH: n(closingCash),
      MAIN_USER: t(mainUser, 15),
    });
    return { saved: true as const };
  });
}

// ---- TAG_SUM_DATA ------------------------------------------------------------------------------

/**
 * `TAG_SUM_DATA` — per-tag movement summary staged by `Ac_Stock` and `RP_TAG`.
 *
 * The same clear-by-company then fill contract as the other staging tables.
 */
export const TAG_SUM_DATA_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'ISR_NO',
  'VCH_DATE',
  'IT_CODE',
  'TAG_NO',
  'VCH_SRNO',
  'IT_TYPE',
  'DATA_TYPE',
  'ITM_QTY',
  'ITM_PCS',
  'ITM_GWT',
  'ITM_NWT',
  'ITM_FINE',
  'DESIGN_NO',
  'ITM_LOT',
  'ITM_SIGN',
  'ITM_SIZE',
  'TBL_CODE',
  'TR_TYPE',
] as const;

export interface TagSummaryRow {
  vchNo?: string;
  srNo?: number;
  iSrNo?: number;
  vchDate?: Date | string | null;
  itCode?: string;
  tagNo?: string;
  vchSrno?: number;
  itType?: string;
  dataType?: string;
  qty?: number;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  fineWt?: number;
  designNo?: string;
  itemLot?: string;
  sign?: string;
  itmSize?: string;
  tblCode?: string;
  trType?: string;
  coBook?: string;
}

export async function stageTagSummaryTx(
  tx: any,
  scope: { tenantId: string; coCode: string; lcCode: string; coYear?: string; coBook?: string },
  rows: TagSummaryRow[],
): Promise<number> {
  await tx.$executeRawUnsafe(
    `DELETE FROM "TAG_SUM_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  let written = 0;
  for (const [index, row] of rows.entries()) {
    await insertRowTx(tx, 'TAG_SUM_DATA', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: t(scope.coYear, 10),
      CO_BOOK: t(row.coBook ?? scope.coBook, 3),
      VCH_NO: t(row.vchNo, 8),
      SR_NO: row.srNo ?? index + 1,
      ISR_NO: n(row.iSrNo),
      VCH_DATE: d(row.vchDate),
      IT_CODE: t(row.itCode, 5),
      TAG_NO: t(row.tagNo, 15),
      VCH_SRNO: n(row.vchSrno),
      IT_TYPE: t(row.itType, 1),
      DATA_TYPE: t(row.dataType, 1),
      ITM_QTY: n(row.qty),
      ITM_PCS: n(row.pcs),
      ITM_GWT: n(row.grossWt),
      ITM_NWT: n(row.netWt),
      ITM_FINE: n(row.fineWt),
      DESIGN_NO: t(row.designNo, 15),
      ITM_LOT: t(row.itemLot, 10),
      ITM_SIGN: t(row.sign, 1),
      ITM_SIZE: t(row.itmSize, 15),
      TBL_CODE: t(row.tblCode, 5),
      TR_TYPE: t(row.trType, 1),
    });
    written += 1;
  }
  return written;
}

// ---- OP_LDR ------------------------------------------------------------------------------------

/**
 * `OP_LDR` — opening ledger rows, written by the desktop's scheme bottom-sheet and import utility.
 *
 * Carries opening amounts alongside opening GOLD and SILVER fine weights, which is why it cannot be
 * folded into `OP_DATA`: a jewellery opening balance has a metal side as well as a money side.
 */
export const OP_LDR_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'DATA_TYPE',
  'VCH_DATE',
  'VCH_TYPE',
  'INOUT_TYPE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'AC_CODE',
  'CR_AMT',
  'DR_AMT',
  'CR_GL_FINE',
  'DR_GL_FINE',
  'CR_SL_FINE',
  'DR_SL_FINE',
] as const;

export interface OpeningLedgerRow {
  vchNo?: string;
  vchDate?: Date | string | null;
  vchType?: string;
  inoutType?: string;
  entryType?: string;
  bookName?: string;
  acCode?: string;
  crAmt?: number;
  drAmt?: number;
  crGoldFine?: number;
  drGoldFine?: number;
  crSilverFine?: number;
  drSilverFine?: number;
  dataType?: string;
  coBook?: string;
}

export async function setOpeningLedger(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string; coYear?: string; coBook?: string },
  rows: OpeningLedgerRow[],
): Promise<number> {
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_LDR" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_YEAR"=$3`,
      scope.tenantId,
      scope.coCode,
      scope.coYear ?? '',
    );
    let written = 0;
    for (const row of rows) {
      await insertRowTx(tx, 'OP_LDR', scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        CO_YEAR: t(scope.coYear, 10),
        CO_BOOK: t(row.coBook ?? scope.coBook, 3),
        VCH_NO: t(row.vchNo, 8),
        DATA_TYPE: t(row.dataType, 1),
        VCH_DATE: d(row.vchDate),
        VCH_TYPE: t(row.vchType, 6),
        INOUT_TYPE: t(row.inoutType, 1),
        ENTRY_TYPE: t(row.entryType, 1),
        BOOK_NAME: t(row.bookName, 20),
        AC_CODE: t(row.acCode, 8),
        CR_AMT: n(row.crAmt),
        DR_AMT: n(row.drAmt),
        CR_GL_FINE: n(row.crGoldFine),
        DR_GL_FINE: n(row.drGoldFine),
        CR_SL_FINE: n(row.crSilverFine),
        DR_SL_FINE: n(row.drSilverFine),
      });
      written += 1;
    }
    return written;
  });
}
