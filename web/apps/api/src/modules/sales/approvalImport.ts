import { roundHalfEven, toIsoDate, type LabourType } from '@datacare/core';
import { legacyLabourModeFor } from '../shared/labourDesktop.js';
import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo } from '../vouchers/numbering.js';
import { STONE_COLUMNS } from './saleResiduals.js';
import { SaleValidationError, type SaleInput, type SaleLineInput } from './sales.js';

/**
 * Sales Invoice "Apr No" import (TR_SALE.cs). The desktop offers the open Approval Isu vouchers behind the "A" button
 * (btnIsuNo, "Approval Help", TR_SALE.cs:5449-5450), and Enter in the read-only Apr No box (tIsuNo_KeyDown,
 * :19669-20560) loads every still-open line of the chosen voucher into the bill after "All Approval Tag In This
 * Voucher Import?" (:20050). Nothing is written until the sale is saved; the save then closes the source lines
 * (APR_DETL.ISU_REC = 'Y', :16112) in the same transaction (approvalSaleReferences.ts).
 */

type Scope = { tenantId: string; coCode: string; lcCode: string };
type Row = Record<string, any>;
const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => Number(value ?? 0) || 0;

/**
 * The desktop's MsSysDate: the working date the rate view was loaded for at login (MS_OPNCOMP.cs:1366-1386,
 * MDI_FORM.cs:14297-14302), i.e. today, never the voucher date. The web has no separate session system date, so it
 * is the server's today in the shop's zone (as the Stock Report's system date, stockReport/index.ts todayIso).
 */
export function systemDateIso(now: Date = new Date()): string {
  const zone = process.env.PRINT_TIME_ZONE?.trim() || 'Asia/Kolkata';
  try {
    return new Intl.DateTimeFormat('en-CA', { timeZone: zone }).format(now);
  } catch {
    return now.toISOString().slice(0, 10);
  }
}

/** One row of the Apr No help: VchNoL, VchDateL, PartyNameL, TagQtyM, YearL, BookL (TR_SALE.cs:20565). */
export interface SaleApprovalHelpRow {
  vchNo: string;
  vchDate: string;
  partyName: string;
  tagQty: number;
  year: string;
  book: string;
}

/**
 * btnIsuNo_Click (TR_SALE.cs:20562-20590): every APR ISU voucher of the session location with at least one line whose
 * ISU_REC is 'N', grouped by voucher, date, party, year and book, ordered by VCH_NO. No year filter: an approval
 * issued last year can be billed this year (the import reads its own CO_YEAR, :20008).
 */
export async function saleApprovalHelp(prisma: any, scope: Scope): Promise<SaleApprovalHelpRow[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Row[] = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO" vch_no,a."VCH_DATE" vch_date,a."CO_YEAR" co_year,a."CO_BOOK" co_book,
              (SELECT c."AC_NAME" FROM "AC_MAST" c WHERE c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE"
                  AND c."AC_CODE"=a."AC_CODE"
                ORDER BY CASE WHEN c."LC_CODE"=a."LC_CODE" THEN 0 ELSE 1 END,c.row_id LIMIT 1) party,
              count(*)::int tag_qty
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE"
          AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
          AND upper(btrim(d."MAIN_BOOK"))='APR ISU' AND a."ISU_REC"='N'
        GROUP BY a.tenant_id,a."CO_CODE",a."LC_CODE",a."VCH_NO",a."VCH_DATE",a."AC_CODE",a."CO_YEAR",a."CO_BOOK"
        ORDER BY a."VCH_NO",a."CO_YEAR",a."CO_BOOK"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    return rows.map((row) => ({
      vchNo: text(row.vch_no),
      vchDate: toIsoDate(row.vch_date),
      partyName: text(row.party),
      tagQty: num(row.tag_qty),
      year: text(row.co_year),
      book: text(row.co_book),
    }));
  });
}

/** The approval lines as Sales Invoice lines: the request shape of POST /sales, plus the item name for display. */
export interface SaleApprovalImport {
  found: boolean;
  acCode: string;
  acName: string;
  /** AC_MAST.AC_GST_TYPE of the approval party, so the screen keeps its GST split in step (L = local). */
  acGstType: string;
  issueNo: string;
  issueYear: string;
  issueBook: string;
  lines: Array<Record<string, unknown>>;
}

/**
 * The rate column of an imported line (TR_SALE.cs:20290-20330). Only a line with no rate and no MRP is priced, and only
 * from today's RATE_MAST row of the item's group (DC_Main.RtView, MS_OPNCOMP.cs:1373): RATE_TYPE G is GR_RATE / 10 at
 * two places, K is GR_RATE / 10 at none, 1 is GR_RATE at none (.NET Math.Round, half to even). Any other rate type
 * leaves the rate blank; a group without a rate that day blanks it.
 */
export function approvalImportRate(
  rateType: string,
  mrp: number,
  groupRate: number | undefined,
): number | undefined {
  if (mrp !== 0) return undefined;
  if (groupRate === undefined) return undefined;
  if (rateType === 'G') return roundHalfEven(groupRate / 10, 2);
  if (rateType === 'K') return roundHalfEven(groupRate / 10, 0);
  if (rateType === '1') return roundHalfEven(groupRate, 0);
  return undefined;
}

/**
 * tIsuNo_KeyDown (TR_SALE.cs:20008-20050, :20120-20520): the open lines (ISU_REC = 'N') of one approval voucher, with
 * the party (AC_CODE, AC_NAME) the bill adopts. Each line copies the tag (blank for 'N'), item, counter, design, size,
 * HUID, bag/gross/less/net/ghat weights, touch, wastage, labour, other amount, MRP, rate type, karigar figures, item
 * type, product, tag instance (VCH_SRNO) and the source key (ISU_NO = VCH_NO, ISU_YRCD = CO_YEAR, ISU_DBCD = CO_BOOK,
 * ISU_SRNO = OLD_SRNO, :20280-20290). Its stone rows are the approval's APR_IDTL rows of SR_NO = OLD_SRNO (:20411).
 * `found: false` is the desktop's "no open line" branch, which reopens the help (:20020-20023).
 */
export async function saleApprovalImport(
  prisma: any,
  scope: Scope,
  query: { year: string; book: string; vchNo: string },
): Promise<SaleApprovalImport> {
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(query.vchNo);
  } catch {
    throw new SaleValidationError(`invalid approval voucher number: ${text(query.vchNo)}`);
  }
  const year = text(query.year);
  const book = text(query.book);
  const rateDate = systemDateIso();
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const details: Row[] = await tx.$queryRawUnsafe(
      `SELECT a.*,i."IT_NAME" it_name,i."GR_CODE" rate_gr
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE"
          AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN LATERAL (SELECT m."IT_NAME",m."GR_CODE" FROM "ITEM_MAST" m
                             WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."IT_CODE"=a."IT_CODE"
                             LIMIT 1) i ON true
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4
          AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6 AND a."ISU_REC"='N'
          AND upper(btrim(d."MAIN_BOOK"))='APR ISU'
        ORDER BY a."SR_NO",a.row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      year,
      book,
      voucherNo,
    );
    const empty = {
      acCode: '',
      acName: '',
      acGstType: '',
      issueNo: voucherNo,
      issueYear: year,
      issueBook: book,
    };
    if (!details.length) return { found: false, ...empty, lines: [] };
    const acCode = text(details[0]!.AC_CODE);
    const [party]: Row[] = await tx.$queryRawUnsafe(
      `SELECT "AC_NAME","AC_GST_TYPE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        ORDER BY CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END,row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      acCode,
      scope.lcCode,
    );
    const rates: Row[] = await tx.$queryRawUnsafe(
      `SELECT "GR_CODE" gr,"GR_RATE"::float8 rate FROM "RATE_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "VCH_DATE"::date=$4::date
        ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      rateDate,
    );
    const groupRate = (group: string) => rates.find((r) => text(r.gr) === group)?.rate as number;
    const stones: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "APR_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO",row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      year,
      book,
      voucherNo,
    );
    // The sale stamps its own user on its stone rows; the approval's audit columns stay behind.
    const carried = STONE_COLUMNS.filter(
      (column) => !['MAIN_USER', 'OLD_VCH_NO', 'NEW_VCH_NO'].includes(column),
    );
    const lines = details.map((row) => {
      const oldSrNo = num(row.OLD_SRNO);
      const tag = text(row.TAG_NO);
      const rateType = text(row.RATE_TYPE);
      const mrp = num(row.ITM_MRP);
      const rate = approvalImportRate(rateType, mrp, groupRate(text(row.rate_gr)));
      return {
        itCode: text(row.IT_CODE),
        itName: text(row.it_name),
        tagNo: tag === 'N' ? '' : tag,
        vchSrno: num(row.VCH_SRNO),
        tblCode: text(row.TBL_CODE),
        designNo: text(row.DESIGN_NO),
        itmSize: text(row.ITM_SIZE),
        huid: text(row.HM_ID),
        bagWt: num(row.BAG_WT),
        pcs: num(row.ITM_PCS),
        grossWt: num(row.ITM_GWT),
        tagGrossWt: num(row.ITM_GWT),
        lessWt: num(row.ITM_OTH_WT),
        netWt: num(row.ITM_NWT),
        tagNetWt: num(row.ITM_NWT),
        ghtWt: num(row.ITM_GHT_WT),
        touch: num(row.ITM_TOUCH),
        westPct: num(row.ITM_WEST_PRC),
        labourPct: num(row.LBR_PRC),
        labourType: legacyLabourModeFor(row.LBR_TYPE) as LabourType | undefined,
        labourRate: num(row.LBR_RATE),
        labourFixed: text(row.LBR_TYPE) === 'N' ? num(row.LBR_AMT) : undefined,
        otherAmount: num(row.OTH_AMT),
        mrp,
        rateType,
        ...(rate === undefined ? {} : { rate }),
        karigarNetWt: num(row.KR_NET_WT),
        karigarTouch: num(row.KR_TOUCH),
        karigarWestPct: num(row.KR_WEST_PRC),
        karigarFine: num(row.KR_FINE),
        karigarName: text(row.KR_NAME),
        metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
        prCode: text(row.PR_CODE),
        isuNo: voucherNo,
        isuYrcd: text(row.CO_YEAR),
        isuDbcd: text(row.CO_BOOK),
        isuSrno: oldSrNo,
        stones: stones
          .filter((stone) => num(stone.SR_NO) === oldSrNo)
          .map((stone) => Object.fromEntries(carried.map((c) => [c, stone[c] ?? null]))),
      };
    });
    return {
      found: true,
      ...empty,
      acCode,
      acName: text(party?.AC_NAME),
      acGstType: text(party?.AC_GST_TYPE),
      lines,
    };
  });
}

/** The source fields of an imported line, which an override may not change (approvalSaleReferences.ts checks them). */
const SOURCE_FIELDS = ['itCode', 'tagNo', 'vchSrno', 'pcs', 'grossWt', 'netWt'] as const;

/**
 * POST /tour/:vchNo/bill: the Sales Invoice import answered "Yes" and saved in one request. The bill takes every open
 * line of the approval and its party (TR_SALE.cs:20042-20050), the header's Apr No / year / book (:15310-15313), and is
 * written by createSale, whose single transaction re-locks each source line and closes it (:16112); a refusal there
 * writes nothing. `lines`, when sent, may only adjust the imported lines by position (a rate typed after the import).
 */
export async function approvalSaleBill(
  prisma: any,
  input: SaleInput,
  rawVoucherNo: string,
  body: Record<string, any>,
): Promise<{ input: SaleInput; lines: SaleLineInput[] }> {
  const scope = input.scope;
  const issueYear = text(body.issueYear) || text(scope.coYear);
  let issueBook = text(body.issueBook);
  if (!issueBook) {
    const books: Row[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT DISTINCT "CO_BOOK" book FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
            AND upper(btrim("MAIN_BOOK"))='APR ISU' ORDER BY 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
      ),
    );
    if (books.length !== 1)
      throw new SaleValidationError(
        'approval bill requires issueBook: the APR ISU book is not unique',
      );
    issueBook = text(books[0]!.book);
  }
  const imported = await saleApprovalImport(prisma, scope, {
    year: issueYear,
    book: issueBook,
    vchNo: rawVoucherNo,
  });
  if (!imported.found)
    throw new SaleValidationError(
      `approval voucher has no open line: ${issueYear}/${issueBook}/${imported.issueNo}`,
    );
  const overrides: unknown = body.lines;
  if (overrides !== undefined && !Array.isArray(overrides))
    throw new SaleValidationError('approval bill lines must be an array');
  if (Array.isArray(overrides) && overrides.length > imported.lines.length)
    throw new SaleValidationError('approval bill lines exceed the open approval lines');
  const lines = imported.lines.map((line, index) => {
    const { itName: _name, ...source } = line;
    const merged: Record<string, unknown> = { ...source, ...((overrides as any[])?.[index] ?? {}) };
    for (const field of [...SOURCE_FIELDS, 'isuNo', 'isuYrcd', 'isuDbcd', 'isuSrno'])
      merged[field] = source[field];
    return merged as unknown as SaleLineInput;
  });
  return {
    input: {
      ...input,
      acCode: imported.acCode,
      acName: input.acName || imported.acName,
      issueNo: imported.issueNo,
      issueYear,
      issueBook,
    },
    lines,
  };
}
