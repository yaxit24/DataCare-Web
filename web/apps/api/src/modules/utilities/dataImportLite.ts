import type { SourceReader, SourceRow, SourceTable } from './dataImportSource.js';
import {
  cmpText,
  ddmmyyyy,
  eq,
  fmtRound,
  fnv,
  isoDay,
  mid,
  n,
  notBlank,
  rowsOf,
  signed,
  str,
  sum,
} from './dataImportAccess.js';
import { liteBarData } from './dataImportLiteTags.js';

export { fmtRound, fnv, str, val } from './dataImportAccess.js';

/**
 * The five steps of the desktop "Lite Soft" import (UT_IMPORT.cs:8413-8445 BtnLite_Click) as pure functions from the
 * source tables to the rows the web writes. Each function cites the desktop lines it reproduces column by column. The
 * desktop reads the file with Access SQL; the joins, filters, groupings and orders of those statements are reproduced
 * here over plain rows, so the result does not depend on a database engine.
 *
 * Deliberate differences (documented in docs/handbook/web/data-import.md):
 *  - the desktop blanks an address line that contains an apostrophe (UT_IMPORT.cs:8722-8752) only so its string-built
 *    INSERT does not break; parameterised SQL keeps the address as it is;
 *  - where the desktop would stop on a NULL (Conversions.ToString(DBNull) at :8771 AC_MOBILE2 and :4314 PR_CODE, or an
 *    unquoted NULL number in :4268 GROUP_MAST) the web writes the Fnv value ('' or 0) instead of crashing half-way;
 *  - the installer system accounts 00001-00100 have named codes in the web chart (seedCompany.ts SYSTEM_ACCOUNTS), so an
 *    opening or a group ledger that names one is moved to the web code of the same role (INSTALLER_ACCOUNTS) and one
 *    the web chart has no account for is listed as a warning and not written.
 */

export interface LiteContext {
  coCode: string;
  lcCode: string;
  coYear: string;
  /** YEAR_MAST.CL_DATE of the session year, ISO (DC_Main.MCl_dt). */
  clDate: string;
  /** YEAR_MAST.OP_DATE of the session year before the import, ISO (DC_Main.MOp_dt). */
  opDate: string;
  /** The signed-in user (DC_Main.MCo_User). */
  user: string;
}

export interface ImportIssue {
  step: LiteStep;
  table: string;
  /** 1-based row of the source table, when one row is at fault. */
  row?: number;
  key?: string;
  reason: string;
}

export type LiteStep = 'Lite_AcMast' | 'Wh_Item' | 'WH_AcOpbl' | 'Lite_BarData' | 'WH_ItOpbl';

export interface OpeningHeadsRow {
  acCode: string;
  sourceAcCode: string;
  amount: number;
  sign: 'C' | 'D';
  gold: number;
  goldSign: 'C' | 'D';
  silver: number;
  silverSign: 'C' | 'D';
}

export interface LitePlan {
  accounts: Record<string, unknown>[];
  accountSrno: Record<string, unknown> | null;
  products: Record<string, unknown>[];
  groups: Record<string, unknown>[];
  tables: Record<string, unknown>[];
  items: Record<string, unknown>[];
  openings: OpeningHeadsRow[];
  barData: Record<string, unknown>[];
  barDetl: Record<string, unknown>[];
  barIdtl: Record<string, unknown>[];
  itemOpenings: Record<string, unknown>[];
  errors: ImportIssue[];
  warnings: ImportIssue[];
}

/**
 * Installer account code (the desktop's fixed chart 00001-00100, kept by Lite_AcMast's `AC_CODE >= '00101'` delete) to
 * the web account of the same role. From seedCompany.ts SYSTEM_ACCOUNTS (its comment names CASH 00001, CAPITAL 00002,
 * LBRINC 00041, WALKIN 00045, LBREXP 00056, KASAR 00057, INTINC 00061, BANK 00075, DISCOUNT 00076, OTHCHRG 00077,
 * CARDCOMM 00078, HMCHRG 00097, FINEKSR 00098, ORDADV 00020) and desktopTemplateMasters.ts DESKTOP_ACCOUNT_ROLES
 * (00003-00012).
 */
export const INSTALLER_ACCOUNTS: Readonly<Record<string, string>> = {
  '00001': 'CASH',
  '00002': 'CAPITAL',
  '00003': 'SALES',
  '00004': 'SLVSALE',
  '00005': 'OG',
  '00006': 'OS',
  '00007': 'OTHSALE',
  '00008': 'PURCHASE',
  '00009': 'SLVPURC',
  '00010': 'OLDGOLD',
  '00011': 'OLDSLVPR',
  '00012': 'OTHPURC',
  '00020': 'ORDADV',
  '00041': 'LBRINC',
  '00045': 'WALKIN',
  '00056': 'LBREXP',
  '00057': 'KASAR',
  '00061': 'INTINC',
  '00075': 'BANK',
  '00076': 'DISCOUNT',
  '00077': 'OTHCHRG',
  '00078': 'CARDCOMM',
  '00097': 'HMCHRG',
  '00098': 'FINEKSR',
};

/** The tables each step needs; a missing table or column stops the import before anything is written. */
export const STEP_TABLES: Record<LiteStep, SourceTable[]> = {
  Lite_AcMast: ['AC_MAST', 'AREA_MAST'],
  Wh_Item: ['PRODUCT_MAST', 'GROUP_MAST', 'TABLE_MAST', 'ITEM_MAST'],
  WH_AcOpbl: ['AC_DATA', 'AC_MAST'],
  Lite_BarData: ['MAIN_TAG_DATA', 'BAR_DETL', 'BAR_IDTL', 'BOOK_DATA', 'ITEM_MAST'],
  WH_ItOpbl: ['MAIN_STOCK', 'ITEM_MAST'],
};

export function sourceProblems(src: SourceReader): ImportIssue[] {
  const out: ImportIssue[] = [];
  const seen = new Set<string>();
  for (const [step, tables] of Object.entries(STEP_TABLES) as [LiteStep, SourceTable[]][])
    for (const table of tables) {
      if (seen.has(table)) continue;
      seen.add(table);
      if (src.rows(table) === null)
        out.push({ step, table, reason: `The file has no table ${table}.` });
      else
        for (const column of src.missingColumns(table))
          out.push({ step, table, reason: `Table ${table} of the file has no column ${column}.` });
    }
  return out;
}

// ---- Step 1: Lite_AcMast (UT_IMPORT.cs:8694-8780) -----------------------------------------------------------------

export function liteAcMast(
  src: SourceReader,
  ctx: LiteContext,
): {
  accounts: Record<string, unknown>[];
  accountSrno: Record<string, unknown> | null;
} {
  // :8697 SELECT A.*, B.AREA_NAME FROM AC_MAST A LEFT JOIN AREA_MAST B ON CO_CODE AND A.AC_AREA = B.AREA_CODE
  //       WHERE A.CO_CODE = company AND AC_CODE > '00100'
  const areas = rowsOf(src, 'AREA_MAST');
  const joined: Array<{ a: SourceRow; areaName: unknown }> = [];
  for (const a of rowsOf(src, 'AC_MAST')) {
    if (!eq(a.CO_CODE, ctx.coCode) || !(notBlank(a.AC_CODE) && cmpText(a.AC_CODE, '00100') > 0))
      continue;
    const matches = areas.filter((b) => eq(b.CO_CODE, a.CO_CODE) && eq(b.AREA_CODE, a.AC_AREA));
    if (!matches.length) joined.push({ a, areaName: null });
    for (const b of matches) joined.push({ a, areaName: b.AREA_NAME });
  }
  const dateText = (v: unknown): string | null => {
    const iso = isoDay(v);
    return iso ? ddmmyyyy(iso) : null; // :8754-8761, :8766 IIf(IsDBNull, Null, date)
  };
  const accounts = joined.map(({ a, areaName }) => ({
    // :8766 INSERT INTO AC_MAST(...) VALUES, column by column
    CO_CODE: ctx.coCode,
    AC_CODE: str(a.AC_CODE),
    LC_CODE: ctx.lcCode, // the desktop's main location '00'; the web company's own location
    AC_NAME: str(a.AC_NAME),
    AC_SHORT: '',
    AC_MAIN_GR: str(a.AC_MAIN_GR),
    AC_GR: mid(a.AC_GR, 2),
    AC_PERSON: '',
    AC_ADD1: str(a.AC_ADD1),
    AC_ADD2: str(a.AC_ADD2),
    AC_ADD3: str(a.AC_ADD3),
    AC_COUNTRY: '',
    AC_STATE: str(a.AC_STATE),
    AC_DISTRICT: '',
    AC_CITY: str(a.AC_CITY),
    AC_AREA: mid(areaName, 25),
    AC_PIN: str(a.AC_PIN),
    AC_PHONE: mid(a.AC_PHONE, 11),
    AC_PHONE2: '',
    AC_MOBILE: mid(a.AC_MOBILE, 11),
    AC_MOBILE2: mid(a.AC_MOBILE2, 11),
    AC_EMAIL: str(a.AC_EMAIL),
    AC_GSTNO: str(a.GST_NO),
    AC_GST_TYPE: str(a.TAX_TYPE),
    AC_PANNO: mid(a.AC_PANNO, 10),
    AC_REF_CODE: '',
    AC_KHATA_NO: '',
    BR_DATE: dateText(a.BR_DATE),
    L_BR_DATE: null,
    AN_DATE: dateText(a.AN_DATE),
    AC_CR_DAYS: 0,
    AC_INT_PRC: 0,
    DPC_PRC: 0,
    BANK_NAME: '',
    BANK_AREA: '',
    BANK_AC_NO: '',
    BANK_RTGS_NO: '',
    BANK_DETL: '',
    AC_TYPE: '',
    LAST_DATE: '01/01/2010',
    DATA_TRFR: 'N',
    MAIN_USER: 'ABC',
  }));
  // :8770-8774: after the last account, AC_MAST_SRNO holds that account (the next-code counter).
  const last = joined.at(-1)?.a;
  const accountSrno = last
    ? {
        CO_CODE: ctx.coCode,
        AC_CODE: str(last.AC_CODE),
        LC_CODE: ctx.lcCode,
        AC_NAME: str(last.AC_NAME),
        AC_GR: mid(last.AC_GR, 2),
      }
    : null;
  return { accounts, accountSrno };
}

// ---- Step 2: Wh_Item, Lite branches (UT_IMPORT.cs:4241-4328) ------------------------------------------------------

/** A group's ledger: an installer system code moves to the web code of its role; any other code is kept. */
function ledgerCode(code: unknown, where: string, warnings: ImportIssue[], row: number): string {
  const c = str(code);
  if (!c || cmpText(c, '00100') > 0) return c;
  const mapped = INSTALLER_ACCOUNTS[c];
  if (mapped) return mapped;
  warnings.push({
    step: 'Wh_Item',
    table: 'GROUP_MAST',
    row,
    key: where,
    reason: `Ledger ${c} is an installer account the web chart does not have; it is left blank.`,
  });
  return '';
}

export function whItem(
  src: SourceReader,
  ctx: LiteContext,
  errors: ImportIssue[],
  warnings: ImportIssue[],
): {
  products: Record<string, unknown>[];
  groups: Record<string, unknown>[];
  tables: Record<string, unknown>[];
  items: Record<string, unknown>[];
} {
  const mine = (t: SourceTable) =>
    rowsOf(src, t)
      .map((row, i) => ({ row, i: i + 1 }))
      .filter(({ row }) => eq(row.CO_CODE, ctx.coCode));
  // :4248-4255 PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER)
  const products = mine('PRODUCT_MAST').map(({ row }) => ({
    CO_CODE: ctx.coCode,
    PR_CODE: str(row.PR_CODE),
    PR_NAME: str(row.PR_NAME),
    MAIN_USER: ctx.user,
  }));
  // :4262-4271 (Lite): TRAD_TYPE '', GR_PURC_TOUCH 0, WEST_PRC 0, TAX_PRC/AVG_* 0
  const groups = mine('GROUP_MAST').map(({ row, i }) => ({
    CO_CODE: ctx.coCode,
    GR_CODE: str(row.GR_CODE),
    GR_NAME: str(row.GR_NAME),
    GR_TYPE: str(row.GR_TYPE),
    TRAD_TYPE: '',
    GR_TOUCH: fnv(row.GR_TOUCH),
    GR_PURC_TOUCH: 0,
    MELTING_PRC: fnv(row.MELTING_PRC),
    GR_RATE: fnv(row.GR_RATE),
    WEST_PRC: 0,
    SALE_AC: ledgerCode(row.SALE_AC, `${str(row.GR_CODE)} SALE_AC`, warnings, i),
    PURC_AC: ledgerCode(row.PURC_AC, `${str(row.GR_CODE)} PURC_AC`, warnings, i),
    HSN_CODE: str(row.HSN_CODE),
    MAIN_USER: ctx.user,
    TAX_PRC: 0,
    AVG_TOUCH: 0,
    AVG_FINE: 0,
    AVG_NWT: 0,
  }));
  // :4288-4296 TABLE_MAST(CO_CODE, LC_CODE = the session location, TABLE_CODE, TABLE_NAME, MAIN_USER)
  const tables = mine('TABLE_MAST').map(({ row }) => ({
    CO_CODE: ctx.coCode,
    LC_CODE: ctx.lcCode,
    TABLE_CODE: str(row.TABLE_CODE),
    TABLE_NAME: str(row.TABLE_NAME),
    MAIN_USER: ctx.user,
  }));
  // :4298-4308 (Lite) ITEM_MAST: PR_CODE Mid 2, TRAD_TYPE '', the rates and averages 0, AC_ITEM = IT_CODE,
  // STK_DISPLAY 'Y', SAFE_NAME 'MAIN'
  const seen = new Set<string>();
  const items: Record<string, unknown>[] = [];
  for (const { row, i } of mine('ITEM_MAST')) {
    const code = str(row.IT_CODE);
    if (!code) {
      errors.push({ step: 'Wh_Item', table: 'ITEM_MAST', row: i, reason: 'Item has no code.' });
      continue;
    }
    if (seen.has(code.toUpperCase())) {
      errors.push({
        step: 'Wh_Item',
        table: 'ITEM_MAST',
        row: i,
        key: code,
        reason: `Item code ${code} is in the file twice.`,
      });
      continue;
    }
    seen.add(code.toUpperCase());
    items.push({
      CO_CODE: ctx.coCode,
      IT_CODE: code,
      IT_NAME: str(row.IT_NAME),
      IT_TYPE: str(row.IT_TYPE),
      TAG_TYPE: str(row.TAG_TYPE),
      PR_CODE: mid(row.PR_CODE, 2),
      GR_CODE: str(row.GR_CODE),
      TRAD_TYPE: '',
      UNIT_NAME: str(row.UNIT_NAME),
      RATE_TYPE: str(row.RATE_TYPE),
      HSN_CODE: str(row.HSN_CODE),
      ITEM_RATE: fnv(row.ITEM_RATE),
      LBR_PRC: 0,
      CON_PRC: 0,
      DISC_PRC: 0,
      IT_TOUCH: 0,
      IT_WEST: 0,
      OTHER_RATE: 0,
      MIN_STK: 0,
      AVG_TOUCH: 0,
      AVG_FINE: 0,
      AVG_NWT: 0,
      AC_ITEM: code,
      MAIN_USER: ctx.user,
      STK_DISPLAY: 'Y',
      SAFE_NAME: 'MAIN',
    });
  }
  return { products, groups, tables, items };
}

// ---- Step 3: WH_AcOpbl (UT_IMPORT.cs:4330-4363) -------------------------------------------------------------------

export function whAcOpbl(
  src: SourceReader,
  ctx: LiteContext,
  importedCodes: Set<string>,
  warnings: ImportIssue[],
): OpeningHeadsRow[] {
  // :4333 SELECT A.AC_CODE, B.AC_NAME, format(Sum(CR_AMT-DR_AMT),'0.00') Amount,
  //   format(SUM(iif(IT_TYPE='G', iif(SIGN='+',FINE_WT,-FINE_WT),0)),'0.000') GoldWt, ... SilverWt
  //   FROM AC_DATA A LEFT JOIN AC_MAST B WHERE A.CO_CODE = company AND VCH_DATE <= closing date
  //   GROUP BY A.AC_CODE ... HAVING Amount + Gold + Silver (unformatted) <> 0 ORDER BY B.AC_NAME
  const names = new Map<string, unknown>();
  for (const b of rowsOf(src, 'AC_MAST'))
    if (eq(b.CO_CODE, ctx.coCode) && !names.has(str(b.AC_CODE).toUpperCase()))
      names.set(str(b.AC_CODE).toUpperCase(), b.AC_NAME);
  const groups = new Map<
    string,
    { code: unknown; amt: Array<number | null>; g: Array<number | null>; s: Array<number | null> }
  >();
  for (const a of rowsOf(src, 'AC_DATA')) {
    if (!eq(a.CO_CODE, ctx.coCode)) continue;
    const day = isoDay(a.VCH_DATE);
    if (!day || day > ctx.clDate) continue;
    const key =
      a.AC_CODE === null || a.AC_CODE === undefined ? '\u0000' : str(a.AC_CODE).toUpperCase();
    const g = groups.get(key) ?? { code: a.AC_CODE, amt: [], g: [], s: [] };
    const cr = n(a.CR_AMT);
    const dr = n(a.DR_AMT);
    g.amt.push(cr === null || dr === null ? null : cr - dr);
    g.g.push(eq(a.IT_TYPE, 'G') ? signed(a.SIGN, a.FINE_WT) : 0);
    g.s.push(eq(a.IT_TYPE, 'S') ? signed(a.SIGN, a.FINE_WT) : 0);
    groups.set(key, g);
  }
  const ordered = [...groups.values()]
    .map((g) => ({ ...g, name: names.get(str(g.code).toUpperCase()) ?? null }))
    .sort((x, y) => cmpText(x.name, y.name));
  const out: OpeningHeadsRow[] = [];
  for (const g of ordered) {
    const amt = sum(g.amt);
    const gold = sum(g.g);
    const silver = sum(g.s);
    if (amt === null || gold === null || silver === null || amt + gold + silver === 0) continue;
    const a = fmtRound(amt, 2);
    const gw = fmtRound(gold, 3);
    const sw = fmtRound(silver, 3);
    // :4348: a party is written only when |Amount| + |Gold| + |Silver| <> 0
    if (Math.abs(a) + Math.abs(gw) + Math.abs(sw) === 0) continue;
    const source = str(g.code);
    let acCode = source;
    if (cmpText(source, '00100') <= 0) {
      const mapped = INSTALLER_ACCOUNTS[source];
      if (!mapped) {
        warnings.push({
          step: 'WH_AcOpbl',
          table: 'OP_DATA',
          key: source,
          reason: `The opening of installer account ${source} (${str(g.name)}) has no web account of the same role and is not imported.`,
        });
        continue;
      }
      acCode = mapped;
    } else if (!importedCodes.has(source.toUpperCase()))
      warnings.push({
        step: 'WH_AcOpbl',
        table: 'OP_DATA',
        key: source,
        reason: `Account ${source} has an opening but is not in the file's account master; the opening is imported as the desktop does.`,
      });
    // :4350 OP_AMT |Amount|, OP_SIGN IIf(Amount > 0,'C','D') (a zero head is 'D'), same for gold and silver
    out.push({
      acCode,
      sourceAcCode: source,
      amount: Math.abs(a),
      sign: a > 0 ? 'C' : 'D',
      gold: Math.abs(gw),
      goldSign: gw > 0 ? 'C' : 'D',
      silver: Math.abs(sw),
      silverSign: sw > 0 ? 'C' : 'D',
    });
  }
  return out;
}

// ---- Step 5: WH_ItOpbl (UT_IMPORT.cs:3887-3965) -------------------------------------------------------------------

export function whItOpbl(src: SourceReader, ctx: LiteContext): Record<string, unknown>[] {
  const itemsByCode = new Map<string, SourceRow>();
  for (const b of rowsOf(src, 'ITEM_MAST'))
    if (eq(b.CO_CODE, ctx.coCode) && !itemsByCode.has(str(b.IT_CODE).toUpperCase()))
      itemsByCode.set(str(b.IT_CODE).toUpperCase(), b);
  // :3890 MAIN_STOCK of the company and year up to the closing date, loose stock only (TAG_NO '' or NULL), grouped by
  // item; ClPcs/ClWt/ClWtGr are the signed sums of pieces, net and gross, ItAmt the signed pieces x ITEM_RATE.
  const groups = new Map<
    string,
    {
      code: unknown;
      b: SourceRow | undefined;
      pcs: Array<number | null>;
      nwt: Array<number | null>;
      gwt: Array<number | null>;
      amt: Array<number | null>;
    }
  >();
  for (const a of rowsOf(src, 'MAIN_STOCK')) {
    if (!eq(a.CO_CODE, ctx.coCode) || !eq(a.CO_YEAR, ctx.coYear) || !notBlank(a.IT_CODE)) continue;
    const day = isoDay(a.VCH_DATE);
    if (!day || day > ctx.clDate) continue;
    if (a.TAG_NO !== null && a.TAG_NO !== undefined && str(a.TAG_NO) !== '') continue;
    const key = str(a.IT_CODE).toUpperCase();
    const b = itemsByCode.get(key);
    const g = groups.get(key) ?? { code: a.IT_CODE, b, pcs: [], nwt: [], gwt: [], amt: [] };
    g.pcs.push(signed(a.SIGN, a.ITM_PCS));
    g.nwt.push(signed(a.SIGN, a.ITM_NWT));
    g.gwt.push(signed(a.SIGN, a.ITM_GWT));
    const pcs = n(a.ITM_PCS);
    const rate = n(b?.ITEM_RATE);
    g.amt.push(pcs === null || rate === null ? null : signed(a.SIGN, pcs * rate));
    groups.set(key, g);
  }
  // ORDER BY B.GR_CODE, A.IT_CODE
  const ordered = [...groups.values()].sort(
    (x, y) => cmpText(x.b?.GR_CODE ?? null, y.b?.GR_CODE ?? null) || cmpText(x.code, y.code),
  );
  const out: Record<string, unknown>[] = [];
  ordered.forEach((g, m) => {
    const clPcs = fnv(sum(g.pcs));
    const clWt = fnv(sum(g.nwt));
    const clWtGr = fnv(sum(g.gwt));
    const itAmt = fnv(sum(g.amt));
    const avgTouch = fnv(g.b?.AVG_TOUCH);
    // :3909-3921 fine = Format(ClWt * AVG_TOUCH / 100, "0.000") when both are non-zero
    const fine = clWt !== 0 && avgTouch !== 0 ? fmtRound((clWt * avgTouch) / 100, 3) : 0;
    // :3925 written when ClWtGr + ClWt + ClPcs <> 0 (a plain sum, not of absolute values)
    if (clWtGr + clWt + clPcs === 0) return;
    out.push({
      // :3927 INSERT INTO ITM_OPBL(...) VALUES, column by column
      CO_CODE: ctx.coCode,
      LC_CODE: ctx.lcCode,
      CO_YEAR: ctx.coYear,
      CO_BOOK: '000',
      IT_CODE: mid(g.code, 5),
      VCH_NO: str(g.b?.IT_TYPE), // the desktop writes the item type into VCH_NO
      SR_NO: m + 1, // the row's place among all grouped items, skipped ones included
      ITM_PCS: clPcs,
      ITM_GWT: clWtGr,
      ITM_NWT: clWt,
      ITM_TOUCH: avgTouch,
      ITM_FINE: fine,
      ITM_RATE: 0,
      ITM_AMT: itAmt,
      LBR_AMT: 0,
      OTH_AMT: 0,
      NET_AMT: itAmt,
      DM_WT: 0,
      DM_RATE: 0,
      DM_AMT: 0,
      MAIN_USER: ctx.user,
      LBR_RATE: 0,
      DATA_TYPE: 'A',
    });
  });
  return out;
}

/** All five steps, in the desktop's order (UT_IMPORT.cs:8432-8437). */
export function planLiteImport(src: SourceReader, ctx: LiteContext): LitePlan {
  const errors: ImportIssue[] = sourceProblems(src);
  const warnings: ImportIssue[] = [];
  const empty: LitePlan = {
    accounts: [],
    accountSrno: null,
    products: [],
    groups: [],
    tables: [],
    items: [],
    openings: [],
    barData: [],
    barDetl: [],
    barIdtl: [],
    itemOpenings: [],
    errors,
    warnings,
  };
  if (errors.length) return empty;
  const { accounts, accountSrno } = liteAcMast(src, ctx);
  const item = whItem(src, ctx, errors, warnings);
  const openings = whAcOpbl(
    src,
    ctx,
    new Set(accounts.map((a) => str(a.AC_CODE).toUpperCase())),
    warnings,
  );
  const bar = liteBarData(src, ctx, errors);
  const itemOpenings = whItOpbl(src, ctx);
  return {
    accounts,
    accountSrno,
    ...item,
    openings,
    ...bar,
    itemOpenings,
    errors,
    warnings,
  };
}
