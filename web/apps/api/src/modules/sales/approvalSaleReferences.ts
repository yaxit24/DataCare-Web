import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

export interface ApprovalSaleReferenceLine {
  itCode: string;
  isuNo?: string;
  isuYrcd?: string;
  isuDbcd?: string;
  isuSrno?: number;
}

export interface LockedApprovalSaleSource {
  rowId: bigint;
  line: number;
  reference: string;
}

type CompleteSaleScope = VoucherScope & { coYear: string; coBook: string };
type ValidationError = new (message: string) => Error;
const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => Number(value ?? 0) || 0;

/**
 * Lock and validate every Approval Isu source before a sale writes anything.
 * TR_SALE.cs:20008 admits only open APR_DETL rows and :20042-20045 adopts their party.
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
      if (!year || !book || !no || srNo <= 0 || !Number.isFinite(srNo)) {
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
    const rows: Array<{ row_id: bigint; AC_CODE: unknown; IT_CODE: unknown }> =
      await tx.$queryRawUnsafe(
        `SELECT a.row_id,a."AC_CODE",a."IT_CODE" FROM "APR_DETL" a
          JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
           AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
         WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
           AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
           AND a."SR_NO"::numeric=$7::numeric AND coalesce(a."ISU_REC",'N')='N'
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
    locked.push({ rowId: source.row_id, line: ref.index + 1, reference });
  }
  return locked;
}

/**
 * Apply order and approval consumption after SL_DETL exists. Every approval close targets a row
 * locked above; an affected-count mismatch rolls the whole sale back.
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
  }
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "APR_ISU"='N',"APP_TRFR"='Y' FROM "SL_DETL" s
      WHERE b.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND b."CO_CODE"=s."CO_CODE" AND b."LC_CODE"=s."LC_CODE"
        AND b."TAG_NO"=s."TAG_NO" AND coalesce(b."VCH_SRNO",0)=coalesce(s."VCH_SRNO",0)`,
    ...params,
  );
}
