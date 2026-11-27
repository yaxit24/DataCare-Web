import type { SourceReader } from './dataImportSource.js';
import type { ImportIssue, LiteContext } from './dataImportLite.js';
import {
  cmpText,
  dayBefore,
  eq,
  fnv,
  isoDay,
  isoOf,
  mid,
  notBlank,
  rowsOf,
  str,
  val,
} from './dataImportAccess.js';

// ---- Step 4: Lite_BarData (UT_IMPORT.cs:8447-8692) ----------------------------------------------------------------

const GROUP_COLUMNS = [
  'DESIGN',
  'ITM_SIZE',
  'ITM_PCS',
  'ITM_GWT',
  'ITM_NWT',
  'LBR_AMT',
  'OTH_AMT',
  'CO_BOOK',
  'VCH_NO',
  'VCH_DATE',
  'VCH_TYPE',
  'BOOK_NAME',
  'CUST_AC',
  'AC_CODE',
  'MRP',
  'NET_COST',
  'KR_NAME',
] as const;

export function liteBarData(
  src: SourceReader,
  ctx: LiteContext,
  errors: ImportIssue[],
): {
  barData: Record<string, unknown>[];
  barDetl: Record<string, unknown>[];
  barIdtl: Record<string, unknown>[];
} {
  const itemType = new Map<string, unknown>();
  for (const b of rowsOf(src, 'ITEM_MAST'))
    if (eq(b.CO_CODE, ctx.coCode) && !itemType.has(str(b.IT_CODE).toUpperCase()))
      itemType.set(str(b.IT_CODE).toUpperCase(), b.IT_TYPE);
  const typeOf = (code: unknown) => itemType.get(str(code).toUpperCase()) ?? null;
  const books = rowsOf(src, 'BOOK_DATA').filter((b) => eq(b.CO_CODE, ctx.coCode));
  const detlAll = rowsOf(src, 'BAR_DETL').filter((c) => eq(c.CO_CODE, ctx.coCode));
  const idtlAll = rowsOf(src, 'BAR_IDTL').filter((c) => eq(c.CO_CODE, ctx.coCode));
  // :8462 MAIN_TAG_DATA of the company and year with a tag and an item
  const tagRows = rowsOf(src, 'MAIN_TAG_DATA').filter(
    (a) =>
      eq(a.CO_CODE, ctx.coCode) &&
      eq(a.CO_YEAR, ctx.coYear) &&
      notBlank(a.TAG_NO) &&
      notBlank(a.IT_CODE),
  );
  // Indexes by the join keys, so each tag looks up its rows instead of scanning the tables (Access joins on them).
  const up = (v: unknown) => str(v).toUpperCase();
  const group = <T>(rows: T[], key: (row: T) => string) => {
    const map = new Map<string, T[]>();
    for (const row of rows) {
      const k = key(row);
      const list = map.get(k);
      if (list) list.push(row);
      else map.set(k, [row]);
    }
    return map;
  };
  const tagsByItem = group(tagRows, (a) => up(a.IT_CODE));
  const detlByTag = group(
    detlAll.map((d, i) => ({ d, i })),
    ({ d }) => (d.TAG_NO === null || d.TAG_NO === undefined ? '\u0000' : up(d.TAG_NO)),
  );
  const idtlByTag = group(
    idtlAll.map((r, i) => ({ r, i })),
    ({ r }) => (r.TAG_NO === null || r.TAG_NO === undefined ? '\u0000' : up(r.TAG_NO)),
  );
  const bookByCode = new Map<string, (typeof books)[number]>();
  for (const b of books) if (!bookByCode.has(up(b.CO_BOOK))) bookByCode.set(up(b.CO_BOOK), b);
  // GROUP BY A.IT_CODE, B.IT_TYPE ORDER BY B.IT_TYPE, A.IT_CODE
  const itemCodes = new Map<string, unknown>();
  for (const a of tagRows)
    if (!itemCodes.has(str(a.IT_CODE).toUpperCase()))
      itemCodes.set(str(a.IT_CODE).toUpperCase(), a.IT_CODE);
  const items = [...itemCodes.values()].sort(
    (x, y) => cmpText(typeOf(x), typeOf(y)) || cmpText(x, y),
  );
  const opDay = dayBefore(ctx.opDate); // MOp_dt.AddDays(-1)
  const barData: Record<string, unknown>[] = [];
  const barDetl: Record<string, unknown>[] = [];
  const barIdtl: Record<string, unknown>[] = [];
  let text = '00000';
  for (const item of items) {
    text = String(val(text) + 1).padStart(5, '0'); // :8478 one voucher per item
    // :8479-8481 MAIN_TAG_DATA INNER JOIN BAR_DETL (CO_CODE, TAG_NO, IT_CODE), grouped by the tag and 17 detail
    // columns, ordered by TAG_NO: one imported tag per distinct combination.
    const seen = new Set<string>();
    const tags: Array<{ tagNo: unknown; tagNwt: unknown }> = [];
    for (const a of tagsByItem.get(up(item)) ?? []) {
      for (const { d: c } of (detlByTag.get(up(a.TAG_NO)) ?? []).filter(({ d }) =>
        eq(d.IT_CODE, a.IT_CODE),
      )) {
        const key = JSON.stringify([
          str(a.TAG_NO).toUpperCase(),
          ...GROUP_COLUMNS.map((col) => (c[col] === null ? null : str(c[col]).toUpperCase())),
        ]);
        if (seen.has(key)) continue;
        seen.add(key);
        tags.push({ tagNo: a.TAG_NO, tagNwt: c.ITM_NWT });
      }
    }
    tags.sort((x, y) => cmpText(x.tagNo, y.tagNo));
    let num = 0;
    for (const tag of tags) {
      num += 1;
      // :8492 the tag's BAR_DETL rows of the year, latest VCH_DATE first; row 0 is copied
      const detl = (detlByTag.get(up(tag.tagNo)) ?? [])
        .filter(({ d }) => eq(d.CO_YEAR, ctx.coYear))
        .sort((x, y) => cmpText(isoDay(y.d.VCH_DATE), isoDay(x.d.VCH_DATE)) || x.i - y.i);
      const d = detl[0]?.d;
      if (!d) {
        errors.push({
          step: 'Lite_BarData',
          table: 'BAR_DETL',
          key: str(tag.tagNo),
          reason: `Tag ${str(tag.tagNo)} has no BAR_DETL row in year ${ctx.coYear}.`,
        });
        continue;
      }
      const book = bookByCode.get(up(d.CO_BOOK));
      const vchSrno = Number(`1${text}${num}`); // :8644 1 & text & num
      barDetl.push({
        // :8506 INSERT INTO BAR_DETL(...) VALUES, column by column
        CO_CODE: str(d.CO_CODE) || ctx.coCode,
        LC_CODE: ctx.lcCode,
        CO_YEAR: ctx.coYear,
        CO_BOOK: '000',
        VCH_NO: text,
        SR_NO: num,
        OLD_SRNO: num,
        VCH_DATE: opDay,
        STK_DATE: isoOf(opDay),
        VCH_TIME: opDay,
        VCH_TYPE: str(book?.BOOK_SNAME),
        INOUT_TYPE: 'I',
        ENTRY_TYPE: 'O',
        BOOK_NAME: str(book?.MAIN_BOOK),
        AC_CODE: str(d.AC_CODE),
        IT_CODE: str(d.IT_CODE),
        TAG_NO: str(d.TAG_NO),
        LOT_NO: '',
        DESIGN_NO: mid(d.DESIGN, 15),
        TBL_CODE: '001',
        ITM_SIZE: str(d.ITM_SIZE),
        ITM_PCS: fnv(d.ITM_PCS),
        BAG_WT: 0,
        ITM_GWT: fnv(d.ITM_GWT),
        ITM_OTH_WT: fnv(d.ITM_GWT) - fnv(d.ITM_NWT),
        ITM_NWT: fnv(d.ITM_NWT),
        ITM_GHT_PRC: 0,
        ITM_GHT_WT: fnv(d.ITM_GHAT),
        ITM_TOUCH: fnv(d.ITM_TOUCH),
        ITM_WEST_PRC: fnv(d.ITM_WEST),
        ITM_FINE: fnv(d.ITM_FINE),
        LBR_PRC: fnv(d.LBR_PRC),
        LBR_RATE: fnv(d.LBR_RATE),
        LBR_TYPE: '',
        LBR_AMT: fnv(d.LBR_AMT),
        OTH_AMT: fnv(d.OTH_AMT),
        ITM_RATE: fnv(d.ITM_RAT),
        ITM_AMT: fnv(d.ITM_AMT),
        TAG_COST: fnv(d.NET_COST),
        ITM_MARGIN: 0,
        ITM_MRP: fnv(d.MRP),
        ITM_REMARK: '',
        SF_NO: '',
        KR_NAME: str(d.KR_NAME),
        KR_OTH_WT: 0,
        KR_NET_WT: fnv(d.KR_ITM_NWT),
        KR_GHT_PRC: 0,
        KR_GHT_WT: fnv(d.KR_ITM_GHAT),
        KR_TOUCH: fnv(d.KR_ITM_TOUCH),
        KR_WEST_PRC: fnv(d.KR_ITM_WEST),
        KR_FINE: fnv(d.ITM_FINE), // :8604-8607: the Lite import writes ITM_FINE here (Wh_BarData writes KR_FINE)
        KR_LBR_RATE: fnv(d.KR_LBR_RATE),
        KR_LBR_AMT: fnv(d.KR_LBR_AMT),
        KR_OTH_AMT: 0,
        KR_COST: fnv(d.NET_COST),
        TAG_SRNO: num,
        VCH_SRNO: vchSrno,
        RATE_TYPE: str(d.RATE_TYPE),
        IT_TYPE: str(d.IT_TYPE),
        TAG_TYPE: str(d.IT_TYPE), // :8644: TAG_TYPE takes IT_TYPE
        PR_CODE: str(d.PR_CODE),
        APR_ISU: 'N',
        ORD_NO: '',
        ORD_SRNO: 0,
        ORD_YRCD: '',
        ORD_DBCD: '',
        ORD_AC: '',
        MAIN_USER: ctx.user,
        ADD_USER: ctx.user,
        DATA_TRFR: 'N',
        DATA_TYPE: 'A', // not in the desktop INSERT (:8506); the desktop column default BAR_DETL.DATA_TYPE ('A')
      });
      // :8496 BAR_IDTL of the tag whose TAG_NWT equals the grouped row's net weight, by ISR_NO
      const tagNwt = tag.tagNwt === null || tag.tagNwt === undefined ? null : val(tag.tagNwt);
      const idtl = (idtlByTag.get(up(tag.tagNo)) ?? [])
        .filter(({ r }) => tagNwt !== null && r.TAG_NWT !== null && val(r.TAG_NWT) === tagNwt)
        .sort((x, y) => fnv(x.r.ISR_NO) - fnv(y.r.ISR_NO) || x.i - y.i)
        .map(({ r }) => r);
      idtl.forEach((r, k) =>
        barIdtl.push({
          // :8649 INSERT INTO BAR_IDTL(...) VALUES
          CO_CODE: ctx.coCode,
          LC_CODE: ctx.lcCode,
          CO_YEAR: ctx.coYear,
          CO_BOOK: '000',
          VCH_NO: text,
          SR_NO: num,
          ISR_NO: k + 1,
          VCH_DATE: opDay,
          VCH_TYPE: str(book?.BOOK_SNAME),
          INOUT_TYPE: 'I',
          ENTRY_TYPE: 'O',
          BOOK_NAME: str(book?.MAIN_BOOK),
          AC_CODE: str(d.AC_CODE),
          TAG_NO: str(d.TAG_NO),
          VCH_SRNO: vchSrno,
          IT_CODE: str(r.IT_CODE),
          IT_TYPE: str(typeOf(r.IT_CODE)),
          DM_CODE: '',
          DM_SIZE: '',
          DM_SFNO: '',
          DM_LEB: '',
          IT_PCS: fnv(r.ITM_PCS),
          IT_PCS_WT: 0,
          KR_WT: fnv(r.PR_WT),
          KR_LESS_PRC: 0,
          IT_GWT: fnv(r.ITM_GWT),
          IT_CON_PRC: fnv(r.CON_PRC),
          IT_CON_WT: fnv(r.CON_WT),
          IT_RATE_TYPE: str(r.RATE_TYPE),
          IT_RATE: fnv(r.ITM_RATE),
          IT_AMT: fnv(r.IT_AMT),
          IT_LBR_RATE: fnv(r.LBR_RATE),
          IT_LBR_AMT: fnv(r.LBR_AMT),
          IT_NET_AMT: fnv(r.ITM_AMT),
          KR_CON_PRC: 0,
          KR_CON_WT: fnv(r.PR_CON_WT),
          KR_RATE: fnv(r.PR_RATE),
          KR_AMT: fnv(r.PR_AMT),
          KR_LBR_RATE: fnv(r.PR_LBR_RATE),
          KR_LBR_AMT: fnv(r.PR_LBR_AMT),
          KR_NET_AMT: fnv(r.PR_NET_AMT),
          MAIN_USER: ctx.user,
        }),
      );
    }
    // :8682-8686 one BAR_DATA header per item that produced a tag
    if (num > 0)
      barData.push({
        CO_CODE: ctx.coCode,
        LC_CODE: ctx.lcCode,
        CO_YEAR: ctx.coYear,
        CO_BOOK: '000',
        VCH_NO: text,
        VCH_DATE: opDay,
        VCH_TIME: opDay,
        AC_CODE: '',
        CUST_AC: '',
        OP_STK: 'Y',
        STK_IT_CODE: '',
        EMP_CODE: '',
        VCH_DESC: '',
        HD_VCH_NO: text,
        MAIN_USER: ctx.user,
        DATA_TRFR: 'N',
      });
  }
  return { barData, barDetl, barIdtl };
}
