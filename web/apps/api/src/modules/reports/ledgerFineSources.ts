import { notCarriedOpening } from '../shared/carriedOpening.js';

/**
 * The row sources of the Ledger Report Gold and Silver prints (WP-20). The desktop fills FINE_DATA with one INSERT
 * per source (BtnGold_Click RP_LEDR.cs:8256-8319, BtnSilver_Click RP_LEDR.cs:8900-8934) and Crystal then selects
 * the account's rows inside the dates. The web runs the same sources as one read-only UNION ALL; the outer
 * selection repeats the Crystal formula (RP_LEDR.cs:8343 {{CurFormula = "{FINE_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FINE_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FINE_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {FINE_DATA.VCH_DATE} >= #"}}).
 *
 * Not ported, by desktop configuration: the jewellery-manufacturing sources (GHAT REC, JDTR, FTNG/CHEDIYA/PARA)
 * run only when MsMfgType is "J" (RP_LEDR.cs:8290 {{if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)}}),
 * and MsMfgType is set only for three named registration serials (MS_OPNCOMP.cs:4911 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "VK080NAVK", false) == 0)}});
 * the SALES RETURNE detail and OUTWORD/INWORD sources are likewise gated on single registration serials
 * (RP_LEDR.cs:8305 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0)}},
 * RP_LEDR.cs:8310 {{if (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) == 0)}}).
 *
 * Numeric conditions read a missing value as 0, the desktop column default.
 * Placeholders: $1 company, $2 account. Every source returns the same columns in the same order.
 */

interface Cols {
  sec: number;
  isr: string;
  coBook: string;
  vchNo: string;
  book: string;
  date: string;
  lc: string;
  label?: string;
  ld?: string;
  it?: string;
  desc?: string;
  tag?: string;
  pcs?: string;
  gwt?: string;
  nwt?: string;
  touch?: string;
  west?: string;
  fine?: string;
  rate?: string;
  amt?: string;
  cr?: string;
  dr?: string;
  sign: string;
  dataType: string;
}

const q = (s: string): string => `'${s.replace(/'/g, "''")}'`;
const list = (xs: readonly string[]): string => xs.map(q).join(',');

function select(c: Cols, from: string, where: string): string {
  const t = (v: string | undefined): string => `(${v ?? "''"})::text`;
  const n = (v: string | undefined): string => `coalesce((${v ?? '0'})::float8,0)`;
  return `SELECT ${c.sec}::int AS sec, ${c.isr}::text AS isr, ${t(c.coBook)} AS co_book, ${t(c.vchNo)} AS vch_no,
    ${t(c.book)} AS book_name, (${c.date})::date AS vch_date, ${t(c.lc)} AS lc_code, ${t(c.label)} AS ac_label,
    ${t(c.ld)} AS ld_code, ${t(c.it)} AS it_code, ${t(c.desc)} AS it_desc, ${t(c.tag)} AS tag_no,
    ${n(c.pcs)} AS pcs, ${n(c.gwt)} AS gwt, ${n(c.nwt)} AS nwt, ${n(c.touch)} AS touch, ${n(c.west)} AS west,
    ${n(c.fine)} AS fine, ${n(c.rate)} AS rate, ${n(c.amt)} AS amt, ${n(c.cr)} AS cr, ${n(c.dr)} AS dr,
    ${t(c.sign)} AS sign, ${t(c.dataType)} AS data_type
    FROM ${from} WHERE ${where}`;
}

const ITEM = (a: string, col = 'IT_CODE') =>
  `LEFT JOIN "ITEM_MAST" b ON b."CO_CODE"=${a}."CO_CODE" AND b."IT_CODE"=${a}."${col}"`;
const BOOK = (a: string, alias = 'c') =>
  `LEFT JOIN "BOOK_DATA" ${alias} ON ${alias}."CO_CODE"=${a}."CO_CODE" AND ${alias}."LC_CODE"=${a}."LC_CODE" AND ${alias}."CO_BOOK"=${a}."CO_BOOK"`;
const OWN = (a: string) => `${a}."CO_CODE"=$1 AND ${a}."AC_CODE"=$2`;

/** A detail line of a voucher table, keeping a zero-amount line's fine (RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}}). */
function detailLine(sec: number, table: string, mainBook: string, itType: 'G' | 'S'): string {
  return select(
    {
      sec,
      isr: 'a."SR_NO"',
      coBook: 'a."CO_BOOK"',
      vchNo: 'a."VCH_NO"',
      book: 'c."MAIN_BOOK"',
      date: 'a."VCH_DATE"',
      lc: 'a."LC_CODE"',
      it: 'a."IT_CODE"',
      desc: 'a."IT_DESC"',
      tag: 'a."TAG_NO"',
      pcs: 'a."ITM_PCS"',
      gwt: 'a."ITM_GWT"',
      nwt: 'a."ITM_NWT"',
      touch: 'a."ITM_TOUCH"',
      west: 'a."ITM_WEST_PRC"',
      fine: 'a."ITM_FINE"',
      rate: 'a."ITM_RATE"',
      amt: 'a."ITM_AMT"',
      sign: "'+'",
      dataType: 'c."DATA_TYPE"',
    },
    `"${table}" a ${ITEM('a')} ${BOOK('a')}`,
    `${OWN('a')} AND coalesce(a."ITM_AMT",0)=0 AND coalesce(a."ITM_FINE",0)<>0 AND b."IT_TYPE"='${itType}' AND c."MAIN_BOOK"=${q(mainBook)}`,
  );
}

/** The purchase/karigar "other fine" line (RP_LEDR.cs:8260 {{'OTH FINE',TAG_NO,0,ITM_OTH_FINE,ITM_OTH_FINE,100,0,ITM_OTH_FINE}}). */
function otherFine(sec: number, table: string, mainBook: string): string {
  return select(
    {
      sec,
      isr: 'a."SR_NO"',
      coBook: 'a."CO_BOOK"',
      vchNo: 'a."VCH_NO"',
      book: 'c."MAIN_BOOK"',
      date: 'a."VCH_DATE"',
      lc: 'a."LC_CODE"',
      desc: "'OTH FINE'",
      tag: 'a."TAG_NO"',
      gwt: 'a."ITM_OTH_FINE"',
      nwt: 'a."ITM_OTH_FINE"',
      touch: '100',
      fine: 'a."ITM_OTH_FINE"',
      rate: 'a."ITM_OTH_RATE"',
      sign: "'+'",
      dataType: 'c."DATA_TYPE"',
    },
    `"${table}" a ${ITEM('a')} ${BOOK('a')}`,
    `${OWN('a')} AND coalesce(a."ITM_OTH_FINE",0)<>0 AND b."IT_TYPE"='G' AND c."MAIN_BOOK"=${q(mainBook)}`,
  );
}

/** The silver fine carried on a purchase line (RP_LEDR.cs:8904 {{'FSL','',TAG_NO,0,SILVER_FINE,SILVER_FINE,100,0,CASE WHEN ITM_AMT = 0 THEN SILVER_FINE ELSE 0 END}}). */
function purchaseSilverFine(sec: number, mainBook: string): string {
  // The desktop reads PR_DETL for the KARIGAR RECEIPT arm too (RP_LEDR.cs:8908 {{FROM (PR_DETL AS A}}); kept.
  return select(
    {
      sec,
      isr: 'a."SR_NO"',
      coBook: 'a."CO_BOOK"',
      vchNo: 'a."VCH_NO"',
      book: 'c."MAIN_BOOK"',
      date: 'a."VCH_DATE"',
      lc: 'a."LC_CODE"',
      it: "'FSL'",
      tag: 'a."TAG_NO"',
      gwt: 'a."SILVER_FINE"',
      nwt: 'a."SILVER_FINE"',
      touch: '100',
      fine: 'a."SILVER_FINE"',
      sign: "'+'",
      dataType: 'c."DATA_TYPE"',
    },
    `"PR_DETL" a ${ITEM('a')} ${BOOK('a')}`,
    `${OWN('a')} AND coalesce(a."ITM_AMT",0)=0 AND coalesce(a."SILVER_FINE",0)<>0 AND c."MAIN_BOOK"=${q(mainBook)}`,
  );
}

/** One AC_DATA arm. Carried year-end openings are left out, as every multi-year ledger reader does. */
function leg(sec: number, isr: string, cols: Partial<Cols>, where: string): string {
  return select(
    {
      sec,
      isr,
      coBook: 'd."CO_BOOK"',
      vchNo: 'd."VCH_NO"',
      book: 'd."BOOK_NAME"',
      date: 'd."VCH_DATE"',
      lc: 'd."LC_CODE"',
      ld: 'd."LD_CODE"',
      sign: 'd."SIGN"',
      dataType: 'd."DATA_TYPE"',
      ...cols,
    },
    `"AC_DATA" d`,
    `${OWN('d')} AND ${notCarriedOpening('d')} AND ${where}`,
  );
}

const FINE_LEG = { fine: 'd."FINE_WT"' };
const FINE_RATE_LEG = { fine: 'd."FINE_WT"', rate: 'd."FINE_RATE"' };
// The money of a metal leg: credit only on an issue, debit only on a receipt.
// RP_LEDR.cs:8268 {{CASE WHEN SIGN = '-' THEN CR_AMT ELSE 0 END,CASE WHEN SIGN = '+' THEN DR_AMT ELSE 0 END}}
const METAL_MONEY = {
  label: "'RATE CUT'",
  rate: 'd."FINE_RATE"',
  cr: `CASE WHEN d."SIGN"='-' THEN d."CR_AMT" ELSE 0 END`,
  dr: `CASE WHEN d."SIGN"='+' THEN d."DR_AMT" ELSE 0 END`,
};

/** A stock row of the account's own sales-side books (RP_LEDR.cs:8256 {{FROM MAIN_STOCK AS A}}). */
function mainStock(itType: 'G' | 'S', books: readonly string[]): string {
  return select(
    {
      sec: 1,
      isr: 'a."ISR_NO"',
      coBook: 'a."CO_BOOK"',
      vchNo: 'a."VCH_NO"',
      book: 'a."BOOK_NAME"',
      date: 'a."VCH_DATE"',
      lc: 'a."LC_CODE"',
      it: 'a."IT_CODE"',
      desc: 'a."ITM_DESC"',
      tag: 'a."TAG_NO"',
      pcs: 'a."ITM_PCS"',
      gwt: 'a."ITM_GWT"',
      nwt: 'a."ITM_NWT"',
      touch: 'a."ITM_TOUCH"',
      west: 'a."ITM_WEST"',
      fine: 'a."ITM_FINE"',
      rate: 'a."ITM_RATE"',
      amt: 'a."ITM_AMT"',
      sign: 'a."ITM_SIGN"',
      dataType: 'a."DATA_TYPE"',
    },
    `"MAIN_STOCK" a ${ITEM('a')}`,
    `${OWN('a')} AND coalesce(a."ITM_AMT",0)=0 AND coalesce(a."ITM_FINE",0)<>0 AND b."IT_TYPE"='${itType}' AND coalesce(a."SR_NO",0)<>7 AND a."BOOK_NAME" IN (${list(books)})`,
  );
}

/** Fine purchase/sale cut stock, always data type B (RP_LEDR.cs:8317 {{A.STK_FINE, 0,0,0,0,0,0,0,0,'F','-','','B'}}). */
function cutStock(sec: number, itType: 'G' | 'S'): string {
  return select(
    {
      sec,
      isr: 'a."SR_NO"',
      coBook: 'a."CO_BOOK"',
      vchNo: 'a."VCH_NO"',
      book: 'c."MAIN_BOOK"',
      date: 'a."VCH_DATE"',
      lc: 'a."LC_CODE"',
      it: 'a."IT_CODE"',
      tag: 'a."TAG_NO"',
      pcs: 'a."STK_PCS"',
      gwt: 'a."STK_GWT"',
      nwt: 'a."STK_NWT"',
      touch: 'a."ITM_TOUCH"',
      west: 'a."ITM_WEST_PRC"',
      fine: 'a."STK_FINE"',
      sign: "'-'",
      dataType: "'B'",
    },
    `"CUT_STK_DETL" a ${BOOK('a')} ${ITEM('a')}`,
    `${OWN('a')} AND coalesce(a."STK_FINE",0)<>0 AND a."AC_CODE"<>'' AND b."IT_TYPE"='${itType}' AND c."MAIN_BOOK" IN ('FINE PURC','FINE SALE')`,
  );
}

/** Wholesale returns received by rate cut (RP_LEDR.cs:8319 {{FROM (RATE_CUT_REC AS A}}). */
function rateCutReceipt(sec: number, itType: 'G' | 'S'): string {
  return select(
    {
      sec,
      isr: 'a."SR_NO"',
      coBook: 'a."CO_BOOK"',
      vchNo: 'a."VCH_NO"',
      book: 'c."MAIN_BOOK"',
      date: 'a."VCH_DATE"',
      lc: 'a."LC_CODE"',
      it: 'a."IT_CODE"',
      tag: 'a."TAG_NO"',
      pcs: 'a."ITM_PCS"',
      gwt: 'a."ITM_GWT"',
      nwt: 'a."ITM_NWT"',
      touch: 'a."ITM_TOUCH"',
      west: 'a."ITM_WEST_PRC"',
      fine: 'a."ITM_FINE"',
      sign: "'+'",
      dataType: 'c."DATA_TYPE"',
    },
    `"RATE_CUT_REC" a ${BOOK('a')} ${ITEM('a')}`,
    `${OWN('a')} AND coalesce(a."ITM_AMT",0)=0 AND coalesce(a."ITM_FINE",0)<>0 AND b."IT_TYPE"='${itType}' AND a."AC_CODE"<>'' AND c."MAIN_BOOK" IN ('WH RTN')`,
  );
}

// RP_LEDR.cs:8256 {{BOOK_NAME IN ('TR_AC_OPBL','SALES ORDER','SALES','SALES RETURNE','WH SALES','RATE CUT','KARIGAR ISSUE','DHIRAN ISSUE','INTREST RECIVED','DHIRAN RECEIVED','PURC RETURN','TOUR SALES')}}
const GOLD_STOCK_BOOKS = [
  'TR_AC_OPBL',
  'SALES ORDER',
  'SALES',
  'SALES RETURNE',
  'WH SALES',
  'RATE CUT',
  'KARIGAR ISSUE',
  'DHIRAN ISSUE',
  'INTREST RECIVED',
  'DHIRAN RECEIVED',
  'PURC RETURN',
  'TOUR SALES',
];
// RP_LEDR.cs:8900 {{BOOK_NAME IN ('SALES ORDER','SALES','WH SALES','RATE CUT','KARIGAR ISSUE')}}
const SILVER_STOCK_BOOKS = ['SALES ORDER', 'SALES', 'WH SALES', 'RATE CUT', 'KARIGAR ISSUE'];
// RP_LEDR.cs:8288 {{BOOK_NAME IN ('MTL ISU','GHAT ISU','MFG GHAT REC'}}
const MFG_BOOKS = [
  'MTL ISU',
  'GHAT ISU',
  'MFG GHAT REC',
  'MFG FILE ISU',
  'MFG FILE REC',
  'MFG PREP ISU',
  'MFG PREP REC',
  'MFG NAKSHI ISU',
  'MFG NAKSHI REC',
  'MFG STNG ISU',
  'MFG STNG REC',
  'MFG MINO ISU',
  'MFG MINO REC',
  'MFG FILE2 ISU',
  'MFG FILE2 REC',
  'MFG POLISH ISU',
  'MFG POLISH REC',
];

/** BtnGold_Click, RP_LEDR.cs:8256-8303 and 8319, in desktop order (the SR_NO literal is `sec`). */
export const GOLD_SOURCES: readonly string[] = [
  mainStock('G', GOLD_STOCK_BOOKS),
  detailLine(2, 'PR_DETL', 'PURCHASE', 'G'),
  otherFine(3, 'PR_DETL', 'PURCHASE'),
  detailLine(4, 'KR_DETL', 'KARIGAR RECEIPT', 'G'),
  otherFine(5, 'KR_DETL', 'KARIGAR RECEIPT'),
  // RP_LEDR.cs:8266 {{AND IT_TYPE <> 'S' AND AC_CODE = '}} ... {{AND CR_AMT+DR_AMT <> 0 AND FINE_WT <> 0}}
  leg(
    6,
    "'600'",
    { label: "'RATE CUT'", ...FINE_RATE_LEG },
    `d."IT_TYPE"<>'S' AND coalesce(d."CR_AMT",0)+coalesce(d."DR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    7,
    "'700'",
    METAL_MONEY,
    `coalesce(d."CR_AMT",0)+coalesce(d."DR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)<>0`,
  ),
  // RP_LEDR.cs:8270 {{AND LD_CODE = '00098' AND FINE_WT <> 0}}
  leg(
    8,
    "'800'",
    FINE_RATE_LEG,
    `d."IT_TYPE"<>'S' AND d."BOOK_NAME"<>'FINE JV' AND d."LD_CODE"='00098' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    9,
    "'900'",
    FINE_LEG,
    `d."IT_TYPE"='G' AND d."BOOK_NAME"='FINE JV' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  // RP_LEDR.cs:8274 {{AND DR_AMT <> 0 AND FINE_WT = 0}}, RP_LEDR.cs:8276 {{AND CR_AMT <> 0 AND FINE_WT = 0}}
  leg(
    10,
    "'901'",
    { desc: 'substring(d."IT_DESC",1,50)', dr: 'd."DR_AMT"', sign: "'-'" },
    `coalesce(d."DR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)=0`,
  ),
  leg(
    11,
    "'902'",
    { desc: 'substring(d."IT_DESC",1,50)', cr: 'd."CR_AMT"', sign: "'+'" },
    `coalesce(d."CR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)=0`,
  ),
  leg(
    12,
    "'903'",
    FINE_LEG,
    `d."IT_TYPE"='G' AND coalesce(d."FINE_WT",0)<>0 AND d."BOOK_NAME"='TR_AC_OPBL'`,
  ),
  // RP_LEDR.cs:8280 {{FROM RATE_CUT_ISU}}
  select(
    {
      sec: 13,
      isr: 'r."SR_NO"',
      coBook: 'r."CO_BOOK"',
      vchNo: 'r."VCH_NO"',
      book: 'r."BOOK_NAME"',
      date: 'r."VCH_DATE"',
      lc: 'r."LC_CODE"',
      ld: "'00003'",
      it: "'999'",
      fine: 'r."ITM_OTH_FINE"',
      rate: 'r."ITM_OTH_RATE"',
      sign: "'-'",
      dataType: "'A'",
    },
    `"RATE_CUT_ISU" r`,
    `${OWN('r')} AND r."IT_TYPE"<>'S' AND coalesce(r."ITM_OTH_FINE",0)<>0`,
  ),
  leg(
    14,
    "'904'",
    { label: "'INT FINE'", ld: "'00061'", ...FINE_LEG },
    `d."IT_TYPE"='G' AND d."LD_CODE"='00061' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    15,
    "'905'",
    FINE_LEG,
    `d."IT_TYPE"='G' AND d."BOOK_NAME"='LABOUR WORK' AND coalesce(d."FINE_WT",0)<>0 AND coalesce(d."CR_AMT",0)+coalesce(d."DR_AMT",0)=0`,
  ),
  leg(
    16,
    "'907'",
    FINE_LEG,
    `d."IT_TYPE"='G' AND d."SIGN"='-' AND d."BOOK_NAME"='INTREST RECIVED' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    16,
    "'907'",
    FINE_LEG,
    `d."IT_TYPE"='G' AND d."BOOK_NAME" IN (${list(MFG_BOOKS)}) AND coalesce(d."FINE_WT",0)<>0`,
  ),
  // RP_LEDR.cs:8301 {{AND DR_FINE <> 0 AND AC_CODE <> '' AND A.IT_TYPE = 'G' AND C.MAIN_BOOK IN ('TAG WT CHANGE','TAG SPLIT')}}
  ...(['DR', 'CR'] as const).map((side) =>
    select(
      {
        sec: side === 'DR' ? 20 : 21,
        isr: "'1'",
        coBook: 'a."CO_BOOK"',
        vchNo: 'a."VCH_NO"',
        book: 'c."MAIN_BOOK"',
        date: 'a."VCH_DATE"',
        lc: 'a."LC_CODE"',
        it: "'OG'",
        desc: "'OLD_GOLD'",
        gwt: `a."${side}_WT"`,
        nwt: `a."${side}_WT"`,
        touch: `a."${side}_TOUCH"`,
        fine: `a."${side}_FINE"`,
        sign: side === 'DR' ? "'-'" : "'+'",
        dataType: 'c."DATA_TYPE"',
      },
      `"LBR_DATA" a ${BOOK('a')}`,
      `${OWN('a')} AND a."${side}_FINE"<>0 AND a."AC_CODE"<>'' AND a."IT_TYPE"='G' AND c."MAIN_BOOK" IN ('TAG WT CHANGE','TAG SPLIT')`,
    ),
  ),
  cutStock(25, 'G'),
  rateCutReceipt(26, 'G'),
];

/** BtnSilver_Click, RP_LEDR.cs:8900-8934, in desktop order. */
export const SILVER_SOURCES: readonly string[] = [
  mainStock('S', SILVER_STOCK_BOOKS),
  detailLine(2, 'PR_DETL', 'PURCHASE', 'S'),
  purchaseSilverFine(3, 'PURCHASE'),
  detailLine(4, 'KR_DETL', 'KARIGAR RECEIPT', 'S'),
  purchaseSilverFine(3, 'KARIGAR RECEIPT'),
  // RP_LEDR.cs:8910 {{A.SILVER_FINE_DR <> 0}}, RP_LEDR.cs:8912 {{A.SILVER_FINE_CR <> 0}}
  ...(['DR', 'CR'] as const).map((side) =>
    select(
      {
        sec: side === 'DR' ? 5 : 6,
        isr: "'0'",
        coBook: 'a."CO_BOOK"',
        vchNo: 'a."VCH_NO"',
        book: 'c."MAIN_BOOK"',
        date: 'a."VCH_DATE"',
        lc: 'a."LC_CODE"',
        ld: side === 'DR' ? "'00004'" : "'00009'",
        fine: `a."SILVER_FINE_${side}"`,
        sign: side === 'DR' ? "'-'" : "'+'",
        dataType: 'c."DATA_TYPE"',
      },
      `"RATE_CUT_DATA" a ${BOOK('a')}`,
      `${OWN('a')} AND a."SILVER_FINE_${side}"<>0`,
    ),
  ),
  // RP_LEDR.cs:8914 {{AND IT_TYPE <> 'G' AND AC_CODE = '}} ... {{AND CR_AMT+DR_AMT <> 0 AND FINE_WT <> 0}}
  leg(
    7,
    'right(d."LEDR_KEY",1)',
    FINE_RATE_LEG,
    `d."IT_TYPE"<>'G' AND coalesce(d."CR_AMT",0)+coalesce(d."DR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    8,
    'right(d."LEDR_KEY",1)',
    { ...METAL_MONEY, label: "''" },
    `coalesce(d."CR_AMT",0)+coalesce(d."DR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    9,
    'right(d."LEDR_KEY",1)',
    FINE_RATE_LEG,
    `d."IT_TYPE"<>'G' AND d."BOOK_NAME"<>'FINE JV' AND d."LD_CODE"='00098' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    10,
    'right(d."LEDR_KEY",1)',
    FINE_LEG,
    `d."IT_TYPE"='S' AND d."BOOK_NAME"='FINE JV' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  // The silver money legs carry no narration (RP_LEDR.cs:8922 {{AC_CODE,'',LD_CODE,'','','',0,0,0,0,0,0}}).
  leg(
    11,
    'right(d."LEDR_KEY",1)',
    { dr: 'd."DR_AMT"', sign: "'-'" },
    `coalesce(d."DR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)=0`,
  ),
  leg(
    12,
    'right(d."LEDR_KEY",1)',
    { cr: 'd."CR_AMT"', sign: "'+'" },
    `coalesce(d."CR_AMT",0)<>0 AND coalesce(d."FINE_WT",0)=0`,
  ),
  leg(
    13,
    'right(d."LEDR_KEY",1)',
    { it: "'FSL'", desc: "'FINE SILVER'", ...FINE_LEG },
    `d."IT_TYPE"='S' AND coalesce(d."FINE_WT",0)<>0 AND d."BOOK_NAME"='TR_AC_OPBL'`,
  ),
  leg(
    14,
    'right(d."LEDR_KEY",2)',
    { label: "'INT FINE'", ld: "'00061'", ...FINE_LEG },
    `d."IT_TYPE"='S' AND d."LD_CODE"='00061' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  leg(
    15,
    'right(d."LEDR_KEY",2)',
    FINE_LEG,
    `d."IT_TYPE"='S' AND d."BOOK_NAME"='LABOUR WORK' AND coalesce(d."FINE_WT",0)<>0`,
  ),
  cutStock(16, 'S'),
  rateCutReceipt(17, 'S'),
];

/** The Jama/Udhar print reads the account's AC_DATA legs directly (RP_LEDR.cs:4017 {{CurFormula = "{AC_DATA.CO_CODE} = '"}}). */
export const JAMA_UDHAR_SOURCES: readonly string[] = [
  leg(
    0,
    "''",
    {
      desc: 'substring(d."IT_DESC",1,50)',
      cr: 'd."CR_AMT"',
      dr: 'd."DR_AMT"',
      fine: 'd."FINE_WT"',
    },
    'true',
  ),
];
