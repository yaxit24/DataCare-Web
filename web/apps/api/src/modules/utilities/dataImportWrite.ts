import { DESKTOP_COLUMN_DEFAULTS } from '../posting/desktopColumnDefaults.js';
import { openingLegDateTx, openingLegs } from '../finance/partyOpening.js';
import type { OpeningHeadsRow } from './dataImportLite.js';

/**
 * The writers of Old Software Import (dataImport.ts): multi-row inserts with the desktop column defaults, the
 * MAIN_STOCK rows the desktop's stock refresh builds from the imported rows, and the party openings as the Party
 * Opening writer (partyOpening.ts writePartyOpeningTx) writes them, batched.
 */
const q = (id: string) => `"${id.replace(/[^A-Za-z0-9_]/g, '')}"`;

/** Multi-row INSERT with the desktop column defaults (posting.ts insertRowTx semantics), in chunks. */
export async function insertRowsTx(
  tx: any,
  table: string,
  tenantId: string,
  rows: Record<string, unknown>[],
): Promise<void> {
  if (!rows.length) return;
  const defaults = DESKTOP_COLUMN_DEFAULTS[table] ?? {};
  const full = rows.map((row) => {
    const out: Record<string, unknown> = { ...defaults, ...row };
    for (const [col, fallback] of Object.entries(defaults))
      if (out[col] === null) out[col] = fallback;
    return out;
  });
  const cols = [...new Set(full.flatMap((r) => Object.keys(r)))];
  const per = Math.max(1, Math.floor(30_000 / (cols.length + 1)));
  for (let start = 0; start < full.length; start += per) {
    const chunk = full.slice(start, start + per);
    const params: unknown[] = [];
    const values = chunk.map((row) => {
      params.push(tenantId);
      const marks = [`$${params.length}`];
      for (const c of cols) {
        params.push(c in row ? row[c] : (defaults[c] ?? null));
        marks.push(`$${params.length}`);
      }
      return `(${marks.join(',')})`;
    });
    await tx.$executeRawUnsafe(
      `INSERT INTO ${q(table)}(tenant_id,${cols.map(q).join(',')}) VALUES ${values.join(',')}`,
      ...params,
    );
  }
}

export async function deleteCompanyTx(
  tx: any,
  s: { tenantId: string; coCode: string },
  table: string,
  where = '',
  ...extra: unknown[]
) {
  await tx.$executeRawUnsafe(
    `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2${where}`,
    s.tenantId,
    s.coCode,
    ...extra,
  );
}

export const dayBefore = (isoDate: string): Date => {
  const d = new Date(`${isoDate}T00:00:00.000Z`);
  d.setUTCDate(d.getUTCDate() - 1);
  return d;
};

/** Tag_Opbl_Stk (Ac_Stock.cs:22-26): an opening-book tag is one purchase-in MAIN_STOCK row, 'TAGOP' / 'TAG OPBL'. */
export function tagOpeningStock(detl: Record<string, any>): Record<string, unknown> {
  return {
    CO_CODE: detl.CO_CODE,
    LC_CODE: detl.LC_CODE,
    CO_YEAR: detl.CO_YEAR,
    CO_BOOK: detl.CO_BOOK,
    VCH_NO: detl.VCH_NO,
    SR_NO: detl.SR_NO,
    ISR_NO: 1,
    VCH_DATE: detl.VCH_DATE,
    STK_DATE: detl.STK_DATE,
    VCH_TYPE: 'TAGOP',
    BOOK_NAME: 'TAG OPBL',
    AC_CODE: '',
    IT_CODE: detl.IT_CODE,
    TAG_NO: detl.TAG_NO,
    VCH_SRNO: detl.VCH_SRNO,
    TBL_CODE: detl.TBL_CODE,
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: 1,
    ITM_PCS: detl.ITM_PCS,
    ITM_GWT: detl.ITM_GWT,
    ITM_NWT: detl.ITM_NWT,
    ITM_TOUCH: detl.ITM_TOUCH,
    ITM_WEST: detl.ITM_WEST_PRC,
    ITM_FINE: detl.ITM_FINE,
    ITM_RATE: detl.ITM_RATE,
    ITM_AMT: detl.ITM_AMT,
    LBR_RATE: detl.LBR_RATE,
    LBR_AMT: detl.LBR_AMT,
    OTH_AMT: detl.OTH_AMT,
    ITM_MRP: detl.ITM_MRP,
    NET_AMT: 0,
    KR_NWT: detl.KR_NET_WT,
    KR_TOUCH: detl.KR_TOUCH,
    KR_WEST: detl.KR_WEST_PRC,
    KR_FINE: detl.KR_FINE,
    KR_LBR_AMT: detl.KR_LBR_AMT,
    KR_OTH_AMT: detl.KR_OTH_AMT,
    KR_COST: detl.KR_COST,
    EMP_CODE: '',
    ENTRY_TIME: detl.VCH_TIME,
    MAIN_USER: detl.MAIN_USER,
    DATA_TYPE: detl.DATA_TYPE,
    DESIGN_NO: detl.DESIGN_NO,
    ITM_SIZE: detl.ITM_SIZE,
    ITM_DESC: '',
    GHT_PRC: detl.ITM_GHT_PRC,
    ITM_LOT: '',
    ITM_DISC: '0',
  };
}

/** Itm_Opbl_Stk (Ac_Stock.cs:11-20): an item opening is one 'ITOBL' / 'ITM OPBL' MAIN_STOCK row, dated MOp_dt - 1. */
export function itemOpeningStock(row: Record<string, any>, date: Date): Record<string, unknown> {
  return {
    CO_CODE: row.CO_CODE,
    LC_CODE: row.LC_CODE,
    CO_YEAR: row.CO_YEAR,
    CO_BOOK: row.CO_BOOK,
    VCH_NO: row.VCH_NO,
    SR_NO: 1,
    ISR_NO: row.SR_NO,
    VCH_DATE: date,
    STK_DATE: date.toISOString().slice(0, 10),
    VCH_TYPE: 'ITOBL',
    BOOK_NAME: 'ITM OPBL',
    AC_CODE: '00000',
    IT_CODE: row.IT_CODE,
    TAG_NO: 'N',
    VCH_SRNO: 0,
    TBL_CODE: '',
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: row.ITM_PCS,
    ITM_PCS: row.ITM_PCS,
    ITM_GWT: row.ITM_GWT,
    ITM_NWT: row.ITM_NWT,
    ITM_TOUCH: row.ITM_TOUCH,
    ITM_WEST: 0,
    ITM_FINE: row.ITM_FINE,
    ITM_RATE: row.ITM_RATE,
    ITM_AMT: row.ITM_AMT,
    LBR_RATE: 0,
    LBR_AMT: row.LBR_AMT,
    OTH_AMT: row.OTH_AMT,
    ITM_MRP: 0,
    NET_AMT: row.NET_AMT,
    KR_NWT: row.ITM_NWT,
    KR_TOUCH: row.ITM_TOUCH,
    KR_WEST: 0,
    KR_FINE: row.ITM_FINE,
    KR_LBR_AMT: row.LBR_AMT,
    KR_OTH_AMT: row.OTH_AMT,
    KR_COST: row.NET_AMT,
    EMP_CODE: '',
    ENTRY_TIME: date,
    MAIN_USER: row.MAIN_USER,
    DATA_TYPE: row.DATA_TYPE,
    DESIGN_NO: '',
    ITM_SIZE: '',
    ITM_DESC: '',
    GHT_PRC: 0,
    ITM_LOT: '',
    ITM_DISC: '0',
  };
}

/** The books whose tags Tag_Opbl_Stk turns into 'TAGOP' stock rows (Ac_Stock.cs:24, joined on CO_BOOK). */
export const TAG_OPENING_BOOKS = ['OPSTK', 'JDTR TAG', 'MFG TAG'] as const;

/**
 * Whether the imported tags (book '000') are opening stock for Tag_Opbl_Stk. The desktop joins BAR_DETL.CO_BOOK to the
 * company's BOOK_DATA; the installer's book '000' is "Opening Stock", MAIN_BOOK 'OPSTK' (NextMain/Next24 BOOK_DATA), so
 * the imported tags are posted. A web company has no book '000' unless one was made; when it has one, its MAIN_BOOK
 * decides as on the desktop.
 */
export async function importedTagsAreStockTx(
  tx: any,
  s: { tenantId: string; coCode: string; lcCode: string },
): Promise<boolean> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "MAIN_BOOK" mb FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"='000' LIMIT 1`,
    s.tenantId,
    s.coCode,
    s.lcCode,
  );
  if (!rows.length) return true; // the installer's book 000 (OPSTK)
  return (TAG_OPENING_BOOKS as readonly string[]).includes(String(rows[0].mb ?? '').toUpperCase());
}

/**
 * WH_AcOpbl's OP_DATA rows and AcOp_Ledr's legs, batched. Row for row what writePartyOpeningTx writes for a party with
 * no previous opening (the import runs only on a company without openings): owner = the importer, DATA_TRFR 'N',
 * data type 'A' (UT_IMPORT.cs:4350 writes DATA_TYPE 'A'), legs dated the day before the year's opening date
 * (dataImport.db.test.ts compares the two writers).
 */
export async function writeOpeningsTx(
  tx: any,
  s: { tenantId: string; coCode: string; lcCode: string; coYear: string },
  openings: OpeningHeadsRow[],
  mainUser: string,
): Promise<void> {
  if (!openings.length) return;
  const scope = { ...s, dataType: 'A' };
  const legDate = await openingLegDateTx(tx, scope);
  const heads = (o: OpeningHeadsRow) => ({
    amount: o.amount,
    sign: o.sign,
    gold: o.gold,
    goldSign: o.goldSign,
    silver: o.silver,
    silverSign: o.silverSign,
  });
  await insertRowsTx(
    tx,
    'OP_DATA',
    s.tenantId,
    openings.map((o) => ({
      CO_CODE: s.coCode,
      LC_CODE: s.lcCode,
      CO_YEAR: s.coYear,
      CO_BOOK: '000',
      VCH_NO: '00000',
      AC_CODE: o.acCode,
      OP_AMT: o.amount,
      OP_SIGN: o.sign,
      FINE_BAL: o.gold,
      FINE_SIGN: o.goldSign,
      SL_FINE_BAL: o.silver,
      SL_FINE_SIGN: o.silverSign,
      DATA_TYPE: 'A',
      DATA_TRFR: 'N',
      MAIN_USER: mainUser,
    })),
  );
  await insertRowsTx(
    tx,
    'AC_DATA',
    s.tenantId,
    openings.flatMap((o) => openingLegs(scope, o.acCode, heads(o), legDate, mainUser)),
  );
}
