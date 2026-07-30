import { roundHalfEven } from '@datacare/core';
import { insertRowTx } from '../posting/posting.js';
import { withTenant } from '@datacare/db';
import { barTagAvailableSql } from '../shared/stockSql.js';

/**
 * Tag Print (desktop tag-label reprint): list in-stock barcoded tags (BAR_DETL, not sold) and render a
 * print-ready label sheet with a REAL scannable Code39 barcode (desktop BarPrint/RtlHuidPrint parity) +
 * HUID, item/design, weights, touch, MRP. Read-only.
 */

/**
 * Desktop label-print staging columns, transcribed from the desktop statement itself
 * (TR_TAG_OPBL.cs:9190) rather than by hand:
 *   DELETE FROM TAG_PRINT_DATA
 *   INSERT INTO TAG_PRINT_DATA(...58 columns...) SELECT ...same... FROM BAR_DETL WHERE <voucher> AND SR_NO = L
 * The same statement appears in UT_TAG_PRINT, TR_TAG_SPLIT, TR_PHYSTK, TR_TAG_WT_DIFF and TR_ITM_LOT,
 * so this is the one shared writer for all of them. Crystal then reads `SELECT * FROM TAG_PRINT_DATA`.
 */
export const TAG_PRINT_STAGING_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'OLD_SRNO',
  'VCH_DATE',
  'STK_DATE',
  'VCH_TIME',
  'VCH_TYPE',
  'INOUT_TYPE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'AC_CODE',
  'IT_CODE',
  'TAG_NO',
  'LOT_NO',
  'DESIGN_NO',
  'TBL_CODE',
  'ITM_SIZE',
  'ITM_PCS',
  'BAG_WT',
  'ITM_GWT',
  'ITM_OTH_WT',
  'ITM_NWT',
  'ITM_GHT_PRC',
  'ITM_GHT_WT',
  'ITM_TOUCH',
  'ITM_WEST_PRC',
  'ITM_FINE',
  'LBR_PRC',
  'LBR_RATE',
  'LBR_TYPE',
  'LBR_AMT',
  'OTH_AMT',
  'ITM_RATE',
  'ITM_AMT',
  'TAG_COST',
  'ITM_MARGIN',
  'ITM_MRP',
  'ITM_REMARK',
  'SF_NO',
  'KR_NAME',
  'VCH_SRNO',
  'RATE_TYPE',
  'IT_TYPE',
  'TAG_TYPE',
  'PR_CODE',
  'HM_ID',
  'HM_ID2',
  'HM_ID3',
  'HM_ID4',
  'HM_ID_WT',
  'HM_ID2_WT',
  'HM_ID3_WT',
  'HM_ID4_WT',
  'ITM_STYLE',
  'ITM_COLOR', // TR_ITM_LOT variant of the same staging copy
  'LBR_CODE',
] as const;

export interface TagPrintStageScope {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}

/**
 * Tag-stock report staging (`TAG_STOCK_PRINT`), the table Crystal reads for the tag-stock and HUID
 * reports. Desktop stages it per report run:
 *   RP_PHY_STOCK.cs:1830  DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '<co>'
 *   RP_PHY_STOCK.cs:1838  INSERT INTO TAG_STOCK_PRINT(...23 cols...)
 *                         SELECT CO_CODE,...,VCH_SRNO,'+',DESIGN_NO,ITM_SIZE,TBL_CODE,1,
 *                                ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,'A' FROM BAR_DETL WHERE ...
 *   RP_HUID.cs            the same identity set plus HM_ID..HM_ID4_WT
 * `ITM_SIGN` is the literal '+', `ITM_QTY` the literal 1 and `DATA_TYPE` the literal 'A'; everything
 * else is copied straight from BAR_DETL. This writer stages the union of the two BAR_DETL-sourced
 * statements, so a report binding either shape finds its columns populated. The MAIN_STOCK-sourced
 * (RP_ROJMEL) and LEDR_AC_DATA-sourced variants are deliberately NOT covered here — they stage
 * different columns from different tables and need their own writers.
 */
const TAG_STOCK_PRINT_COPIED_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'VCH_DATE',
  'VCH_TYPE',
  'INOUT_TYPE',
  'BOOK_NAME',
  'IT_CODE',
  'TAG_NO',
  'VCH_SRNO',
  'DESIGN_NO',
  'ITM_SIZE',
  'TBL_CODE',
  'ITM_PCS',
  'ITM_GWT',
  'ITM_NWT',
  'ITM_FINE',
  'HM_ID',
  'HM_ID2',
  'HM_ID3',
  'HM_ID4',
  'HM_ID_WT',
  'HM_ID2_WT',
  'HM_ID3_WT',
  'HM_ID4_WT',
  // Also present on BAR_DETL and copied by the same statement.
  'AC_CODE',
  'OTH_AMT',
  'MAIN_USER',
] as const;

/**
 * Columns the tag-stock print table carries for the OTHER two desktop staging variants.
 *
 * `RP_ROJMEL` stages the day-book shape (`DR_*`/`CR_*` money and metal columns) and `RP_TAG` stages the
 * stone-type weight breakdown (`MM_WT` diamond, `SN_WT` stone, `WX_WT` wax) plus the item description and
 * ghat percentage. They come from different source tables than BAR_DETL, so they are staged by their own
 * writer rather than being faked into the BAR_DETL copy — a zero in a money column would print as a real
 * zero on a day-book report.
 */
export const TAG_STOCK_PRINT_ROJMEL_COLUMNS = [
  'DR_AMT',
  'CR_AMT',
  'DR_GOLD',
  'CR_GOLD',
  'DR_SILVER',
  'CR_SILVER',
  'IT_DESC',
  'GHT_PRC',
  'MM_WT',
  'SN_WT',
  'WX_WT',
] as const;

/** Literal columns the desktop statement supplies rather than copying (RP_PHY_STOCK.cs:1838). */
export const TAG_STOCK_PRINT_LITERALS = { ITM_SIGN: '+', ITM_QTY: 1, DATA_TYPE: 'A' } as const;

export const TAG_STOCK_PRINT_COLUMNS = [
  ...TAG_STOCK_PRINT_COPIED_COLUMNS,
  ...(Object.keys(TAG_STOCK_PRINT_LITERALS) as Array<keyof typeof TAG_STOCK_PRINT_LITERALS>),
] as const;

export async function stageTagStockPrintRowsTx(
  tx: any,
  tenantId: string,
  scope: { coCode: string; lcCode?: string; coYear?: string },
): Promise<number> {
  const q = (c: string): string => `"${c}"`;
  const copied = TAG_STOCK_PRINT_COPIED_COLUMNS.map(q).join(',');

  // Desktop scopes this delete by company (RP_PHY_STOCK.cs:1830); forced RLS adds the tenant bound.
  await tx.$executeRawUnsafe(
    `DELETE FROM "TAG_STOCK_PRINT" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    tenantId,
    scope.coCode,
  );

  const filters = ['tenant_id=$1', '"CO_CODE"=$2'];
  const params: unknown[] = [tenantId, scope.coCode];
  if (scope.lcCode) {
    filters.push(`"LC_CODE"=$${params.length + 1}`);
    params.push(scope.lcCode);
  }
  if (scope.coYear) {
    filters.push(`"CO_YEAR"=$${params.length + 1}`);
    params.push(scope.coYear);
  }

  return (await tx.$executeRawUnsafe(
    `INSERT INTO "TAG_STOCK_PRINT"(tenant_id,${copied},"ITM_SIGN","ITM_QTY","DATA_TYPE")
       SELECT $1,${copied},'+',1,'A' FROM "BAR_DETL" WHERE ${filters.join(' AND ')}`,
    ...params,
  )) as number;
}

/**
 * Stage label rows for one voucher, reproducing the desktop clear-then-copy sequence.
 *
 * Desktop runs an unqualified `DELETE FROM TAG_PRINT_DATA` because it is a single-company,
 * single-session client. Here the delete is tenant-scoped: forced RLS makes a cross-tenant delete
 * impossible, so the statement can only clear the caller's own staging rows. Within one tenant the
 * behaviour remains desktop's last-writer-wins, which is a real concurrency limitation recorded in
 * project-memory/contracts/TR_TAG_OPBL.contract.md rather than silently "improved" here.
 */
export async function stageTagPrintRowsTx(
  tx: any,
  tenantId: string,
  scope: TagPrintStageScope,
  voucherNo: string,
  srNos?: readonly number[],
  /**
   * Blank labels to leave before the first real one, so a part-used sticker sheet can be reused.
   *
   * Eleven `TR_*` forms plus `UT_TAG_PRINT` expose this (`nLableSkip`), and none of it existed in the web —
   * an operator had to waste the remainder of every sheet. The desktop prepends N placeholder rows with
   * `IT_CODE='00'` and `VCH_SRNO=0` BEFORE copying the real labels (`TR_TAG_OPBL.cs:11485-11492`), so the
   * report simply prints them as empty stickers.
   *
   * The count is `Math.Round(Conversion.Val(...))` in .NET, i.e. banker's rounding — 2.5 skips 2, not 3.
   */
  labelSkip?: number,
): Promise<number> {
  const q = (c: string): string => `"${c}"`;
  const cols = TAG_PRINT_STAGING_COLUMNS.map(q).join(',');

  await tx.$executeRawUnsafe(`DELETE FROM "TAG_PRINT_DATA" WHERE tenant_id=$1`, tenantId);

  // Placeholder rows first: the desktop inserts them before the real labels so they print at the top.
  const skip = Math.max(0, roundHalfEven(Number(labelSkip) || 0, 0));
  for (let i = 1; i <= skip; i += 1) {
    await tx.$executeRawUnsafe(
      `INSERT INTO "TAG_PRINT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
         "SR_NO","IT_CODE","VCH_SRNO") VALUES ($1,$2,$3,$4,$5,$6,$7,'00',0)`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
      i,
    );
  }

  const params: unknown[] = [
    tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  ];
  let filter = '';
  if (srNos && srNos.length) {
    filter = ` AND "SR_NO" = ANY($7::int[])`;
    params.push(srNos.map((n) => Number(n)));
  }

  return (await tx.$executeRawUnsafe(
    `INSERT INTO "TAG_PRINT_DATA"(tenant_id,${cols})
       SELECT $1,${cols}
         FROM "BAR_DETL"
        WHERE tenant_id=$1
          AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6${filter}`,
    ...params,
  )) as number;
}

export interface PrintableTag {
  tagNo: string;
  itCode: string;
  designNo: string | null;
  tblCode: string | null;
  netWt: number;
  grossWt: number;
  touch: number;
  mrp: number;
  rate: number;
  hmId: string | null;
  pcs: number;
}

export async function listPrintableTags(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  filters?: { tblCode?: string; itCode?: string; tagFrom?: string; tagTo?: string },
): Promise<PrintableTag[]> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const cl: string[] = [];
    if (filters?.tblCode) {
      params.push(filters.tblCode);
      cl.push(`b."TBL_CODE"::text=$${params.length}`);
    }
    if (filters?.itCode) {
      params.push(filters.itCode);
      cl.push(`b."IT_CODE"::text=$${params.length}`);
    }
    if (filters?.tagFrom) {
      params.push(filters.tagFrom);
      cl.push(`b."TAG_NO"::text>=$${params.length}`);
    }
    if (filters?.tagTo) {
      params.push(filters.tagTo);
      cl.push(`b."TAG_NO"::text<=$${params.length}`);
    }
    const extra = cl.length ? ' AND ' + cl.join(' AND ') : '';
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO" tag,b."IT_CODE" it,b."DESIGN_NO" dn,b."TBL_CODE" tc,b."HM_ID" hm,
              coalesce(NULLIF(b."ITM_PCS"::text,'')::numeric,0)::float pcs,
              coalesce(NULLIF(b."ITM_NWT"::text,'')::numeric,0)::float nwt,
              coalesce(NULLIF(b."ITM_GWT"::text,'')::numeric,0)::float gwt,
              coalesce(NULLIF(b."ITM_TOUCH"::text,'')::numeric,0)::float touch,
              coalesce(NULLIF(b."ITM_MRP"::text,'')::numeric,0)::float mrp,
              coalesce(NULLIF(b."ITM_RATE"::text,'')::numeric,0)::float rate
         FROM "BAR_DETL" b WHERE b."CO_CODE"::text=$1 AND b."LC_CODE"::text=$2${extra}
           AND ${barTagAvailableSql('b')}
         ORDER BY b."TAG_NO",coalesce(b."VCH_SRNO",0) LIMIT 2000`,
      ...params,
    );
    return rows.map((r) => ({
      tagNo: String(r.tag),
      itCode: String(r.it ?? ''),
      designNo: r.dn ?? null,
      tblCode: r.tc ?? null,
      netWt: Number(r.nwt),
      grossWt: Number(r.gwt),
      touch: Number(r.touch),
      mrp: Number(r.mrp),
      rate: Number(r.rate),
      hmId: r.hm ?? null,
      pcs: Number(r.pcs),
    }));
  });
}

const esc = (s: unknown): string =>
  String(s ?? '').replace(
    /[&<>"]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c] as string,
  );

/** Code39 element patterns (9 elements/char: bar,space,… ; 'w'=wide 'n'=narrow). Scannable by any reader. */
const CODE39: Record<string, string> = {
  '0': 'nnnwwnwnn',
  '1': 'wnnwnnnnw',
  '2': 'nnwwnnnnw',
  '3': 'wnwwnnnnn',
  '4': 'nnnwwnnnw',
  '5': 'wnnwwnnnn',
  '6': 'nnwwwnnnn',
  '7': 'nnnwnnwnw',
  '8': 'wnnwnnwnn',
  '9': 'nnwwnnwnn',
  A: 'wnnnnwnnw',
  B: 'nnwnnwnnw',
  C: 'wnwnnwnnn',
  D: 'nnnnwwnnw',
  E: 'wnnnwwnnn',
  F: 'nnwnwwnnn',
  G: 'nnnnnwwnw',
  H: 'wnnnnwwnn',
  I: 'nnwnnwwnn',
  J: 'nnnnwwwnn',
  K: 'wnnnnnnww',
  L: 'nnwnnnnww',
  M: 'wnwnnnnwn',
  N: 'nnnnwnnww',
  O: 'wnnnwnnwn',
  P: 'nnwnwnnwn',
  Q: 'nnnnnnwww',
  R: 'wnnnnnwwn',
  S: 'nnwnnnwwn',
  T: 'nnnnwnwwn',
  U: 'wwnnnnnnw',
  V: 'nwwnnnnnw',
  W: 'wwwnnnnnn',
  X: 'nwnnwnnnw',
  Y: 'wwnnwnnnn',
  Z: 'nwwnwnnnn',
  '-': 'nwnnnnwnw',
  '.': 'wwnnnnwnn',
  ' ': 'nwwnnnwnn',
  '*': 'nwnnwnwnn',
  $: 'nwnwnwnnn',
  '/': 'nwnwnnnwn',
  '+': 'nwnnnwnwn',
  '%': 'nnnwnwnwn',
};

/** Render a scannable Code39 barcode for `data` as inline SVG (no dependency). */
export function code39Svg(data: string, opts: { height?: number; narrow?: number } = {}): string {
  const N = opts.narrow ?? 2,
    W = N * 3,
    H = opts.height ?? 30;
  const text =
    '*' +
    String(data)
      .toUpperCase()
      .replace(/[^0-9A-Z\-. $/+%]/g, '') +
    '*';
  let x = 0;
  const rects: string[] = [];
  for (const ch of text) {
    const pat = CODE39[ch];
    if (!pat) continue;
    for (let i = 0; i < 9; i++) {
      const w = pat[i] === 'w' ? W : N;
      if (i % 2 === 0) rects.push(`<rect x="${x}" y="0" width="${w}" height="${H}"/>`); // even index = bar
      x += w;
    }
    x += N; // inter-character narrow gap
  }
  return `<svg xmlns="http://www.w3.org/2000/svg" width="${x}" height="${H}" viewBox="0 0 ${x} ${H}" fill="#000" preserveAspectRatio="none" style="width:100%;height:${H}px">${rects.join('')}</svg>`;
}

/** Render a print-ready HTML sheet of jewellery tag labels (real Code39 barcode + HUID + item/wt/mrp). */
export function renderTagLabels(tags: PrintableTag[], labelSkip = 0): string {
  // Blank stickers before the first real label, so a part-used sheet can be reused. Eleven TR_* forms plus
  // UT_TAG_PRINT expose this as `nLableSkip`; the desktop stages placeholder rows with IT_CODE='00'
  // (TR_TAG_OPBL.cs:11485-11492). The count uses .NET banker's rounding, so 2.5 skips 2, not 3.
  const skip = Math.max(0, roundHalfEven(Number(labelSkip) || 0, 0));
  const blanks = Array.from(
    { length: skip },
    () => '<div class="lbl blank" aria-hidden="true"></div>',
  ).join('');
  const cells = tags
    .map(
      (t) => `
    <div class="lbl">
      <div class="bcode">${code39Svg(t.tagNo, { height: 26 })}</div>
      <div class="bcnum">${esc(t.tagNo)}</div>
      <div class="row"><b>${esc(t.itCode)}</b>${t.designNo ? ' · ' + esc(t.designNo) : ''}${t.pcs > 1 ? ' · ' + t.pcs + ' pc' : ''}</div>
      <div class="row">Net ${t.netWt} g · Gr ${t.grossWt} g${t.touch ? ' · ' + t.touch + '%' : ''}</div>
      ${t.mrp ? `<div class="row">MRP ₹${t.mrp.toLocaleString('en-IN')}</div>` : ''}
      ${t.hmId ? `<div class="row huid">HUID: ${esc(t.hmId)}</div>` : ''}
    </div>`,
    )
    .join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>Tag Labels (${tags.length})</title>
    <style>
      *{box-sizing:border-box;font-family:Arial,Helvetica,sans-serif}
      body{margin:8px}
      .sheet{display:flex;flex-wrap:wrap;gap:6px}
      .lbl{width:150px;border:1px solid #999;border-radius:4px;padding:6px 8px;font-size:11px}
      .bcode{height:26px;margin:1px 0}
      .bcnum{font-weight:700;font-size:12px;letter-spacing:1px;text-align:center;margin-bottom:2px}
      .row{line-height:1.35}
      .huid{font-size:9px;color:#444;letter-spacing:.3px}
      @media print{.noprint{display:none}}
    </style></head><body>
    <div class="noprint" style="margin-bottom:8px"><button onclick="window.print()">Print</button> ${tags.length} label(s)</div>
    <div class="sheet">${blanks}${cells || (skip ? '' : '<i>no tags</i>')}</div>
    </body></html>`;
}

export interface RojmelPrintRow {
  vchNo?: string;
  srNo?: number;
  vchDate?: Date | string | null;
  vchType?: string;
  bookName?: string;
  acCode?: string;
  itCode?: string;
  itDesc?: string;
  drAmt?: number;
  crAmt?: number;
  drGold?: number;
  crGold?: number;
  drSilver?: number;
  crSilver?: number;
  ghatPct?: number;
  /** Stone-type weight breakdown: diamond, stone, wax. */
  diamondWt?: number;
  stoneWt?: number;
  waxWt?: number;
  mainUser?: string;
}

/**
 * Stage the day-book / stone-breakdown shape of `TAG_STOCK_PRINT`.
 *
 * `RP_ROJMEL` and `RP_TAG` fill the same physical table from different sources than `RP_PHY_STOCK`, with
 * the money (`DR_*`/`CR_*`) and stone-weight columns instead of the BAR_DETL tag identity. Kept as a
 * separate writer so a caller stages one shape or the other deliberately — merging them would put zeros
 * in money columns that a day-book report would print as real values.
 *
 * Appends rather than clearing: a report run stages its rows through `stageTagStockPrintTx` first (which
 * clears by company) and then adds these, matching the desktop's two-statement sequence.
 */
export async function stageRojmelPrintTx(
  tx: any,
  tenantId: string,
  scope: { coCode: string; lcCode?: string; coYear?: string; coBook?: string },
  rows: RojmelPrintRow[],
): Promise<number> {
  const n = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
  const t = (v: unknown, len: number): string | null =>
    String(v ?? '')
      .trim()
      .slice(0, len) || null;
  let written = 0;
  for (const [index, row] of rows.entries()) {
    await insertRowTx(tx, 'TAG_STOCK_PRINT', tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode ?? null,
      CO_YEAR: scope.coYear ?? null,
      CO_BOOK: scope.coBook ?? null,
      VCH_NO: t(row.vchNo, 8),
      SR_NO: row.srNo ?? index + 1,
      VCH_DATE: row.vchDate ? new Date(row.vchDate) : null,
      VCH_TYPE: t(row.vchType, 6),
      BOOK_NAME: t(row.bookName, 20),
      AC_CODE: t(row.acCode, 10),
      IT_CODE: t(row.itCode, 6),
      IT_DESC: t(row.itDesc, 255),
      DR_AMT: n(row.drAmt),
      CR_AMT: n(row.crAmt),
      DR_GOLD: n(row.drGold),
      CR_GOLD: n(row.crGold),
      DR_SILVER: n(row.drSilver),
      CR_SILVER: n(row.crSilver),
      GHT_PRC: n(row.ghatPct),
      MM_WT: n(row.diamondWt),
      SN_WT: n(row.stoneWt),
      WX_WT: n(row.waxWt),
      MAIN_USER: t(row.mainUser, 15),
      ...TAG_STOCK_PRINT_LITERALS,
    });
    written += 1;
  }
  return written;
}
