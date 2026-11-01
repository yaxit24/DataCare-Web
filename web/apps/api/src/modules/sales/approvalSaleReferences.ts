import type { ResolvedTagIdentity } from '../stock/stock.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

export interface ApprovalSaleReferenceLine {
  itCode: string;
  tagNo?: string;
  vchSrno?: number;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  isuNo?: string;
  isuYrcd?: string;
  isuDbcd?: string;
  isuSrno?: number;
}

export interface LockedApprovalSaleSource {
  rowId: bigint;
  barRowId?: bigint;
  line: number;
  reference: string;
  tagIdentity?: ResolvedTagIdentity;
}

type CompleteSaleScope = VoucherScope & { coYear: string; coBook: string };
type ValidationError = new (message: string) => Error;
const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => Number(value ?? 0) || 0;
const tag = (value: unknown): string => {
  const normalized = text(value);
  return normalized && normalized.toUpperCase() !== 'N' ? normalized : 'N';
};

/**
 * Lock and validate every Approval Isu source before a sale writes anything.
 * TR_SALE.cs:20008 admits only open APR_DETL rows; :20130-20169 copies the source tag,
 * instance, item and quantities; :20399-20411 carries OLD_SRNO as the durable reference.
 */
export async function lockApprovalSaleReferencesTx(
  tx: any,
  scope: CompleteSaleScope,
  partyAc: string,
  lines: ApprovalSaleReferenceLine[],
  ErrorType: ValidationError,
): Promise<LockedApprovalSaleSource[]> {
  const references = lines
    .map((line, index) => {
      const year = text(line.isuYrcd);
      const book = text(line.isuDbcd);
      const no = text(line.isuNo);
      const srNo = num(line.isuSrno);
      const any = !!year || !!book || !!no || srNo !== 0;
      if (!any) return null;
      if (!year || !book || !no || !Number.isSafeInteger(srNo) || srNo <= 0) {
        throw new ErrorType(
          `approval reference on sale line ${index + 1} requires isuYrcd, isuDbcd, isuNo and isuSrno`,
        );
      }
      let voucherNo: string;
      try {
        voucherNo = formatVoucherNo(no);
      } catch {
        throw new ErrorType(`approval reference on sale line ${index + 1} is invalid`);
      }
      return { line, index, year, book, voucherNo, srNo };
    })
    .filter((value): value is NonNullable<typeof value> => value !== null)
    .sort(
      (a, b) =>
        a.year.localeCompare(b.year) ||
        a.book.localeCompare(b.book) ||
        a.voucherNo.localeCompare(b.voucherNo) ||
        a.srNo - b.srNo,
    );
  const seen = new Set<string>();
  const locked: LockedApprovalSaleSource[] = [];
  for (const ref of references) {
    const reference = `${ref.year}/${ref.book}/${ref.voucherNo}/${ref.srNo}`;
    if (seen.has(reference)) {
      throw new ErrorType(`approval reference is duplicated in this sale: ${reference}`);
    }
    seen.add(reference);
    const rows: Array<{
      row_id: bigint;
      AC_CODE: unknown;
      IT_CODE: unknown;
      TAG_NO: unknown;
      VCH_SRNO: unknown;
      ITM_PCS: unknown;
      ITM_GWT: unknown;
      ITM_NWT: unknown;
    }> = await tx.$queryRawUnsafe(
      `SELECT a.row_id,a."AC_CODE",a."IT_CODE",a."TAG_NO",a."VCH_SRNO",
              a."ITM_PCS",a."ITM_GWT",a."ITM_NWT"
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
          AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
          AND a."OLD_SRNO"::numeric=$7::numeric AND coalesce(a."ISU_REC",'N')='N'
          AND upper(btrim(b."MAIN_BOOK"))='APR ISU'
        ORDER BY a.row_id FOR UPDATE OF a`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      ref.year,
      ref.book,
      ref.voucherNo,
      ref.srNo,
    );
    if (rows.length !== 1) {
      throw new ErrorType(`approval reference is unavailable or ambiguous: ${reference}`);
    }
    const source = rows[0]!;
    if (text(source.AC_CODE) !== text(partyAc)) {
      throw new ErrorType(`approval reference party does not match the sale: ${reference}`);
    }
    if (text(source.IT_CODE) !== text(ref.line.itCode)) {
      throw new ErrorType(`approval reference item does not match sale line ${ref.index + 1}`);
    }
    if (tag(source.TAG_NO) !== tag(ref.line.tagNo)) {
      throw new ErrorType(`approval reference tag does not match sale line ${ref.index + 1}`);
    }
    if (num(source.VCH_SRNO) !== num(ref.line.vchSrno)) {
      throw new ErrorType(
        `approval reference tag instance does not match sale line ${ref.index + 1}`,
      );
    }
    if (
      num(source.ITM_PCS) !== num(ref.line.pcs) ||
      num(source.ITM_GWT) !== num(ref.line.grossWt) ||
      num(source.ITM_NWT) !== num(ref.line.netWt)
    ) {
      throw new ErrorType(`approval reference quantity does not match sale line ${ref.index + 1}`);
    }

    let barRowId: bigint | undefined;
    let tagIdentity: ResolvedTagIdentity | undefined;
    const sourceTag = tag(source.TAG_NO);
    if (sourceTag !== 'N') {
      const bars: Array<Record<string, unknown> & { row_id: bigint }> = await tx.$queryRawUnsafe(
        `SELECT * FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
            AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric
            AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')
            ORDER BY row_id FOR UPDATE`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        sourceTag,
        num(source.VCH_SRNO),
        text(source.IT_CODE),
      );
      if (bars.length !== 1) {
        throw new ErrorType(`approval reference BAR instance is unavailable: ${reference}`);
      }
      const bar = bars[0]!;
      barRowId = bar.row_id;
      tagIdentity = {
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        TAG_NO: sourceTag,
        VCH_SRNO: num(source.VCH_SRNO),
        IT_CODE: text(source.IT_CODE),
        source: 'BAR_DETL',
        stock: bar,
      };
    }
    locked.push({
      rowId: source.row_id,
      ...(barRowId === undefined ? {} : { barRowId }),
      line: ref.index + 1,
      reference,
      ...(tagIdentity === undefined ? {} : { tagIdentity }),
    });
  }
  return locked;
}

/**
 * Apply order and approval consumption after SL_DETL exists. Every approval and BAR close targets
 * rows locked above; an affected-count mismatch rolls the whole sale back.
 */
export async function consumeSaleReferencesTx(
  tx: any,
  scope: CompleteSaleScope,
  voucherNo: string,
  sources: LockedApprovalSaleSource[],
  ErrorType: ValidationError,
): Promise<void> {
  const params = [
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  ];
  await tx.$executeRawUnsafe(
    `UPDATE "SL_ORD_DETL" o SET "TAG_SALE"='Y' FROM "SL_DETL" s
      WHERE o.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND o."CO_CODE"=s."CO_CODE" AND o."VCH_NO"=s."ORD_NO"
        AND o."CO_YEAR"=s."ORD_YRCD" AND o."CO_BOOK"=s."ORD_DBCD"
        AND coalesce(o."OLD_SRNO",0)=coalesce(s."ORD_SRNO",0)`,
    ...params,
  );
  for (const source of sources) {
    const affected = await tx.$executeRawUnsafe(
      `UPDATE "APR_DETL" SET "ISU_REC"='Y'
        WHERE tenant_id=$1 AND row_id=$2 AND coalesce("ISU_REC",'N')='N'`,
      scope.tenantId,
      source.rowId,
    );
    if (affected !== 1) {
      throw new ErrorType(
        `approval reference changed while saving sale line ${source.line}: ${source.reference}`,
      );
    }
    if (source.barRowId !== undefined && source.tagIdentity) {
      const barAffected = await tx.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "APR_ISU"='N',"APP_TRFR"='Y'
          WHERE tenant_id=$1 AND row_id=$2 AND "CO_CODE"=$3 AND "LC_CODE"=$4
            AND "TAG_NO"=$5 AND coalesce("VCH_SRNO",0)::numeric=$6::numeric
            AND coalesce("IT_CODE"::text,'')=coalesce($7::text,'')`,
        scope.tenantId,
        source.barRowId,
        source.tagIdentity.CO_CODE,
        source.tagIdentity.LC_CODE,
        source.tagIdentity.TAG_NO,
        source.tagIdentity.VCH_SRNO,
        source.tagIdentity.IT_CODE,
      );
      if (barAffected !== 1) {
        throw new ErrorType(
          `approval reference BAR instance changed while saving sale line ${source.line}: ${source.reference}`,
        );
      }
    }
  }
  // TR_SALE.cs:16113 marks ordinary sold tags too. Keep that path separate: approval-referenced
  // rows above update only their locked BAR row, while live-stock rows follow the saved sale identity.
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "APR_ISU"='N',"APP_TRFR"='Y' FROM "SL_DETL" s
      WHERE b.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND nullif(btrim(coalesce(s."ISU_NO"::text,'')),'') IS NULL
        AND nullif(btrim(coalesce(s."TAG_NO"::text,'')),'') IS NOT NULL
        AND s."TAG_NO"::text<>'N'
        AND b."CO_CODE"=s."CO_CODE" AND b."LC_CODE"=s."LC_CODE"
        AND b."TAG_NO"=s."TAG_NO" AND coalesce(b."VCH_SRNO",0)=coalesce(s."VCH_SRNO",0)
        AND coalesce(b."IT_CODE"::text,'')=coalesce(s."IT_CODE"::text,'')`,
    ...params,
  );
}
