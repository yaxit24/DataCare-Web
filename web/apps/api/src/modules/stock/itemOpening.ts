import {
  isItemOpeningType,
  itemOpeningRowSaved,
  round,
  toIsoDate,
  type ItemOpeningRow,
  type ItemOpeningTypeCode,
} from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { assertVoucherVersionTx, versionKeyOf, voucherVersionTx } from '../vouchers/version.js';

/**
 * Item Opening (desktop TR_ITM_OPBL, menu Master → Item Opening; MDI_FORM.cs:7690-7699 opens the form directly, with
 * no book help). The opening stock of loose (non-tag) items, one grid per metal type.
 *
 * The desktop keeps one opening per metal type in book '000', with the type letter as VCH_NO (TR_ITM_OPBL.cs:1414-1441):
 * - Enter on the metal type lists every item of that type (ITEM_MAST, ordered IT_TYPE, GR_CODE, IT_NAME) and fills each
 *   row from the item's ITM_OPBL row (DISPLAY_DATA, :1269-1370).
 * - Save deletes the type's ITM_OPBL rows and writes one row per grid row whose gross weight plus pieces is not zero,
 *   SR_NO = the grid row (so the numbers keep their gaps), then rewrites the stock rows (Ac_Stock.Itm_Opbl_Stk,
 *   Ac_Stock.cs:11-21) and the other-detail rows (Ac_Stock.Dm_Itm_Opbl_Detl, :734-741), and answers "Data Are Saved.".
 * - Delete removes the stock, other-detail and opening rows of the type (BtnDelete_Click, :1492-1517).
 *
 * Stock rows are dated the day before the year opens, VCH_TYPE 'ITOBL', BOOK_NAME 'ITM OPBL', AC_CODE '00000', with the
 * karigar columns copied from the item columns; there is no ledger effect and no BAR_DATA header.
 *
 * The type's rows carry a version token (N51, D17): the read returns `version`, and a save or delete must send it back
 * as `expectedVersion`, so two operators who opened the same type cannot overwrite each other. The desktop has no such
 * check: the later save wins.
 *
 * Two deliberate differences from the desktop, both recorded on the gap:
 * - DISPLAY_DATA reads ITM_OPBL with no year or book filter (:1286) and takes the first row, so an item's opening
 *   from another year can fill this year's grid and be saved into it. The web reads this year's book '000' rows.
 * - The desktop's stock and other-detail deletes cover every row of book '000' with the letter as voucher number; book
 *   '000' also holds Tag Opening's TAGOP rows (numeric voucher numbers), so the web deletes only the ITOBL rows.
 */
export const ITEM_OPENING_BOOK = '000';
const VCH_TYPE = 'ITOBL';
const STOCK_BOOK_NAME = 'ITM OPBL';
const OPENING_AC_CODE = '00000';
/** The desktop data type for a single-book company (MsDataType 'A'); the A/B split is an Advance-edition feature. */
const DATA_TYPE = 'A';
/** The rows a save or delete of one type replaces; the version token is computed over them. */
const WRITE_SET = ['ITM_OPBL', 'MAIN_STOCK', 'DM_DATA'] as const;

export class ItemOpeningValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ItemOpeningValidationError';
  }
}

export interface ItemOpeningScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

/** One grid row: the item and its opening (every value 0 when the item has none). */
export interface ItemOpeningGridRow extends ItemOpeningRow {
  srNo: number;
  itCode: string;
  itName: string;
  rateType: string;
  itType: string;
  /** True when the row came from a saved ITM_OPBL row. */
  saved: boolean;
}

export interface ItemOpeningGrid {
  type: ItemOpeningTypeCode;
  /** The stock date: the day before the year opens. Null when the year has no opening date. */
  stockDate: string | null;
  rows: ItemOpeningGridRow[];
  /** The version token of the type's rows (N51); send it back as `expectedVersion`. */
  version: string;
}

/**
 * One grid row of a save: the cell values as the grid holds them. The desktop saves the cells (Conversion.Val of each
 * column, TR_ITM_OPBL.cs:1424-1440) without recomputing them: CommPassTotal runs as a cell is left (:887-925), so a row
 * reloaded and saved unchanged keeps its stored fine and amounts. The screen computes the cells with core's
 * itemOpeningRow; the server stores them in the grid's formats.
 */
export interface ItemOpeningSaveLine {
  itCode?: string;
  pcs?: number | string | null;
  grossWt?: number | string | null;
  netWt?: number | string | null;
  touch?: number | string | null;
  westPct?: number | string | null;
  fineWt?: number | string | null;
  rate?: number | string | null;
  amount?: number | string | null;
  lbrType?: string | null;
  lbrRate?: number | string | null;
  lbrAmt?: number | string | null;
  othAmt?: number | string | null;
  netAmt?: number | string | null;
}

export interface SaveItemOpeningInput {
  scope: ItemOpeningScope;
  type: string;
  /** The grid in row order; a row's position (1-based) becomes its SR_NO. */
  rows: ItemOpeningSaveLine[];
  /** The `version` returned when the grid was read. */
  expectedVersion: string;
  mainUser?: string;
}

const scopeOf = (s: ItemOpeningScope) => ({
  coCode: s.coCode,
  lcCode: s.lcCode ?? '01',
  coYear: s.coYear ?? '',
});
const text = (v: unknown) => String(v ?? '').trim();

/** Conversion.Val of a cell held in its grid format (MSG_LeaveCell, TR_ITM_OPBL.cs:887-925). */
function cell(value: unknown, places: number): number {
  const parsed = typeof value === 'number' ? value : Number(text(value) || 0);
  if (!Number.isFinite(parsed))
    throw new ItemOpeningValidationError(`not a number: ${text(value).slice(0, 20)}`);
  return round(parsed, places);
}

/** The cells of one grid row as the desktop saves them. */
export function itemOpeningCells(line: ItemOpeningSaveLine): ItemOpeningRow {
  return {
    pcs: cell(line.pcs, 0),
    grossWt: cell(line.grossWt, 3),
    netWt: cell(line.netWt, 3),
    touch: cell(line.touch, 2),
    westPct: cell(line.westPct, 2),
    fineWt: cell(line.fineWt, 3),
    rate: cell(line.rate, 2),
    amount: cell(line.amount, 2),
    lbrType: text(line.lbrType).slice(0, 1).toUpperCase(),
    lbrRate: cell(line.lbrRate, 2),
    lbrAmt: cell(line.lbrAmt, 2),
    othAmt: cell(line.othAmt, 2),
    netAmt: cell(line.netAmt, 2),
  };
}

function typeOf(raw: unknown): ItemOpeningTypeCode {
  const type = text(raw).slice(0, 1).toUpperCase();
  if (!isItemOpeningType(type))
    throw new ItemOpeningValidationError(DESKTOP_MESSAGES.ITEM_OPENING_METAL_TYPE_REQUIRED);
  return type;
}

const versionKey = (scope: ItemOpeningScope, type: string) => {
  const { coCode, lcCode, coYear } = scopeOf(scope);
  return versionKeyOf(
    { tenantId: scope.tenantId, coCode, lcCode, coYear, coBook: ITEM_OPENING_BOOK },
    type,
  );
};

/**
 * Serialise saves and deletes of one company/location/year/type, so two cannot interleave their delete and insert,
 * then refuse a stale version before anything changes.
 */
async function lockTx(
  tx: any,
  scope: ItemOpeningScope,
  type: string,
  expectedVersion: string,
): Promise<void> {
  const { coCode, lcCode, coYear } = scopeOf(scope);
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `item-opening:${scope.tenantId}:${coCode}:${lcCode}:${coYear}:${type}`,
  );
  await assertVoucherVersionTx(tx, WRITE_SET, versionKey(scope, type), expectedVersion);
}

/** The day before the year opens (MOp_dt.AddDays(-1)), or null when the year has no opening date. */
async function stockDateTx(tx: any, scope: ItemOpeningScope): Promise<Date | null> {
  const { coCode, coYear } = scopeOf(scope);
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "OP_DATE"::text AS op FROM "YEAR_MAST" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 LIMIT 1`,
    coCode,
    coYear,
  );
  const iso = toIsoDate(rows[0]?.op);
  if (!iso) return null;
  const d = new Date(`${iso}T00:00:00.000Z`);
  d.setUTCDate(d.getUTCDate() - 1);
  return d;
}

const isoDay = (d: Date | null) => (d ? toIsoDate(d) : null);

async function itemsTx(tx: any, coCode: string, type: string) {
  return (await tx.$queryRawUnsafe(
    `SELECT "IT_CODE" code, "IT_NAME" name, "IT_TYPE" it, "RATE_TYPE" rt, "OTH_DETL_POSTING" oth
       FROM "ITEM_MAST" WHERE "CO_CODE"=$1 AND "IT_TYPE"=$2
      ORDER BY "IT_TYPE", "GR_CODE", "IT_NAME", "IT_CODE"`,
    coCode,
    type,
  )) as Array<{ code: string; name: string; it: string; rt: string | null; oth: string | null }>;
}

/** Read the grid for one metal type (DISPLAY_DATA, TR_ITM_OPBL.cs:1269-1370). */
export async function getItemOpening(
  prisma: any,
  scope: ItemOpeningScope,
  typeRaw: string,
): Promise<ItemOpeningGrid> {
  const type = typeOf(typeRaw);
  const { coCode, lcCode, coYear } = scopeOf(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const items = await itemsTx(tx, coCode, type);
    const saved: any[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT ON ("IT_CODE") "IT_CODE" code, coalesce("ITM_PCS",0)::float pcs, coalesce("ITM_GWT",0)::float gwt,
              coalesce("ITM_NWT",0)::float nwt, coalesce("ITM_TOUCH",0)::float touch,
              coalesce("ITM_WEST_PRC",0)::float west, coalesce("ITM_FINE",0)::float fine,
              coalesce("ITM_RATE",0)::float rate, coalesce("ITM_AMT",0)::float amt, coalesce("LBR_TYPE",'') lt,
              coalesce("LBR_RATE",0)::float lr, coalesce("LBR_AMT",0)::float la, coalesce("OTH_AMT",0)::float oa,
              coalesce("NET_AMT",0)::float na
         FROM "ITM_OPBL"
        WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4 AND "DATA_TYPE"=$5
        ORDER BY "IT_CODE", "SR_NO", row_id`,
      coCode,
      lcCode,
      coYear,
      ITEM_OPENING_BOOK,
      DATA_TYPE,
    );
    const byCode = new Map(saved.map((r) => [String(r.code), r]));
    const rows = items.map((item, index): ItemOpeningGridRow => {
      const r = byCode.get(String(item.code));
      return {
        srNo: index + 1,
        itCode: String(item.code),
        itName: String(item.name ?? ''),
        rateType: text(item.rt),
        itType: text(item.it),
        saved: Boolean(r),
        // A saved row shows as stored: the grid reloads the columns, it does not recompute them.
        pcs: r ? Number(r.pcs) : 0,
        grossWt: r ? Number(r.gwt) : 0,
        netWt: r ? Number(r.nwt) : 0,
        touch: r ? Number(r.touch) : 0,
        westPct: r ? Number(r.west) : 0,
        fineWt: r ? Number(r.fine) : 0,
        rate: r ? Number(r.rate) : 0,
        amount: r ? Number(r.amt) : 0,
        lbrType: r ? text(r.lt) : '',
        lbrRate: r ? Number(r.lr) : 0,
        lbrAmt: r ? Number(r.la) : 0,
        othAmt: r ? Number(r.oa) : 0,
        netAmt: r ? Number(r.na) : 0,
      };
    });
    return {
      type,
      stockDate: isoDay(await stockDateTx(tx, scope)),
      rows,
      version: await voucherVersionTx(tx, WRITE_SET, versionKey(scope, type)),
    };
  });
}

async function deleteTypeTx(tx: any, scope: ItemOpeningScope, type: string): Promise<number> {
  const { coCode, lcCode, coYear } = scopeOf(scope);
  const where = `"CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`;
  const args = [coCode, lcCode, coYear, ITEM_OPENING_BOOK, type];
  await tx.$executeRawUnsafe(
    `DELETE FROM "MAIN_STOCK" WHERE ${where} AND "VCH_TYPE"='${VCH_TYPE}'`,
    ...args,
  );
  await tx.$executeRawUnsafe(
    `DELETE FROM "DM_DATA" WHERE ${where} AND "BOOK_NAME"='${VCH_TYPE}'`,
    ...args,
  );
  return Number(await tx.$executeRawUnsafe(`DELETE FROM "ITM_OPBL" WHERE ${where}`, ...args));
}

/** Save the grid of one metal type (BtnSave_Click, TR_ITM_OPBL.cs:1380-1490). */
export async function saveItemOpening(
  prisma: any,
  input: SaveItemOpeningInput,
): Promise<ItemOpeningGrid> {
  const type = typeOf(input.type);
  if (!Array.isArray(input.rows)) throw new ItemOpeningValidationError('rows must be a list');
  const { coCode, lcCode, coYear } = scopeOf(input.scope);
  const mainUser = input.mainUser ?? 'system';
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, input.scope, type, input.expectedVersion);
    const items = new Map((await itemsTx(tx, coCode, type)).map((i) => [String(i.code), i]));
    const lines: Array<{ srNo: number; itCode: string; row: ItemOpeningRow; oth: boolean }> = [];
    input.rows.forEach((line, index) => {
      const itCode = text(line?.itCode).toUpperCase();
      const row = itemOpeningCells(line ?? {});
      if (!itemOpeningRowSaved(row)) return;
      // The desktop saves such a row with a blank IT_CODE (TR_ITM_OPBL.cs:1420-1424); the web refuses it instead of
      // writing stock for no item.
      if (!itCode) throw new ItemOpeningValidationError(`row ${index + 1}: item code is required`);
      const item = items.get(itCode);
      if (!item)
        throw new ItemOpeningValidationError(
          `item ${itCode} is not a ${type} item in this company`,
        );
      lines.push({
        srNo: index + 1,
        itCode,
        row,
        oth: text(item.oth).toUpperCase() === 'Y',
      });
    });
    const stockDate = lines.length ? await stockDateTx(tx, input.scope) : null;
    if (lines.length && !stockDate)
      throw new ItemOpeningValidationError(
        `year ${coYear || '(none)'} has no opening date; open the company year first`,
      );
    await deleteTypeTx(tx, input.scope, type);
    const key = {
      CO_CODE: coCode,
      LC_CODE: lcCode,
      CO_YEAR: coYear,
      CO_BOOK: ITEM_OPENING_BOOK,
      VCH_NO: type,
    };
    for (const { srNo, itCode, row } of lines) {
      await insertRowTx(tx, 'ITM_OPBL', input.scope.tenantId, {
        ...key,
        SR_NO: srNo,
        IT_CODE: itCode,
        ITM_PCS: row.pcs,
        ITM_GWT: row.grossWt,
        ITM_NWT: row.netWt,
        ITM_TOUCH: row.touch,
        ITM_WEST_PRC: row.westPct,
        ITM_FINE: row.fineWt,
        ITM_RATE: row.rate,
        ITM_AMT: row.amount,
        LBR_TYPE: row.lbrType,
        LBR_RATE: row.lbrRate,
        LBR_AMT: row.lbrAmt,
        OTH_AMT: row.othAmt,
        NET_AMT: row.netAmt,
        MAIN_USER: mainUser,
        DATA_TYPE,
        // The save leaves DATA_TRFR to the column default 'Y' (MS_UPDATE.cs:21658); the migrated rows all hold 'Y'.
        DATA_TRFR: 'Y',
      });
    }
    for (const { srNo, itCode, row, oth } of lines) {
      // Ac_Stock.Itm_Opbl_Stk (Ac_Stock.cs:11-21). The decompiled source writes SR_NO 1 and ISR_NO = A.SR_NO; the
      // desktop's own rows (72 in the migrated data) carry SR_NO = A.SR_NO and ISR_NO 1, and the web follows the data.
      await insertRowTx(tx, 'MAIN_STOCK', input.scope.tenantId, {
        ...key,
        SR_NO: srNo,
        ISR_NO: 1,
        VCH_DATE: stockDate,
        STK_DATE: isoDay(stockDate),
        VCH_TYPE,
        BOOK_NAME: STOCK_BOOK_NAME,
        AC_CODE: OPENING_AC_CODE,
        IT_CODE: itCode,
        TAG_NO: 'N',
        VCH_SRNO: 0,
        TBL_CODE: '',
        TR_TYPE: 'P',
        ITM_SIGN: '+',
        ITM_QTY: row.pcs,
        ITM_PCS: row.pcs,
        ITM_GWT: row.grossWt,
        ITM_NWT: row.netWt,
        ITM_TOUCH: row.touch,
        ITM_WEST: 0,
        ITM_FINE: row.fineWt,
        ITM_RATE: row.rate,
        ITM_AMT: row.amount,
        LBR_RATE: 0,
        LBR_AMT: row.lbrAmt,
        OTH_AMT: row.othAmt,
        ITM_MRP: 0,
        NET_AMT: row.netAmt,
        KR_NWT: row.netWt,
        KR_TOUCH: row.touch,
        KR_WEST: 0,
        KR_FINE: row.fineWt,
        KR_LBR_AMT: row.lbrAmt,
        KR_OTH_AMT: row.othAmt,
        KR_COST: row.netAmt,
        EMP_CODE: '',
        ENTRY_TIME: stockDate,
        MAIN_USER: mainUser,
        DATA_TYPE,
        DESIGN_NO: '',
        ITM_SIZE: '',
        ITM_DESC: '',
        GHT_PRC: 0,
      });
      if (!oth) continue;
      // Ac_Stock.Dm_Itm_Opbl_Detl (Ac_Stock.cs:734-741): only items posting other details (OTH_DETL_POSTING 'Y').
      await insertRowTx(tx, 'DM_DATA', input.scope.tenantId, {
        ...key,
        MAIN_SRNO: 1,
        SR_NO: srNo,
        ISR_NO: 1,
        VCH_DATE: stockDate,
        ENTRY_TYPE: 'L',
        BOOK_NAME: VCH_TYPE,
        AC_CODE: OPENING_AC_CODE,
        IT_CODE: itCode,
        DM_CODE: itCode,
        DM_ORIGIN: '',
        DM_REMARK: '',
        DM_SIZE: '',
        DM_COLOR: '',
        DM_LOT_NO: '',
        DM_PCS: row.pcs,
        DM_WT: row.grossWt,
        DM_SIGN: '+',
        DM_RATE: row.rate,
        DM_AMT: row.amount,
        EMP_CODE: '',
        TAG_NO: 'N',
        VCH_SRNO: 0,
        MAIN_IT_CODE: '',
        INOUT_TYPE: 'P',
        TBL_CODE: '',
      });
    }
  });
  return getItemOpening(prisma, input.scope, type);
}

/** Delete the opening of one metal type (BtnDelete_Click, TR_ITM_OPBL.cs:1492-1517). */
export async function deleteItemOpening(
  prisma: any,
  scope: ItemOpeningScope,
  typeRaw: string,
  expectedVersion: string,
): Promise<{ type: ItemOpeningTypeCode; deleted: number }> {
  const type = text(typeRaw).slice(0, 1).toUpperCase();
  if (!isItemOpeningType(type))
    throw new ItemOpeningValidationError(DESKTOP_MESSAGES.ITEM_SELECT_FOR_DELETE);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope, type, expectedVersion);
    return { type, deleted: await deleteTypeTx(tx, scope, type) };
  });
}
