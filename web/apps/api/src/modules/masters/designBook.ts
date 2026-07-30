import { withTenant } from '@datacare/db';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';

/**
 * Design Book (`DESIGN_DETL`) — the desktop's per-product catalogue of designs, one row per design
 * line on a numbered page of a design book.
 *
 * Desktop write set from `MS_DESIGN_BOOK.cs:5790` (34 columns, all present in the restored schema).
 * The desktop keys a line by `CO_CODE + BOOK_NAME + PR_CODE + SR_NO` and deletes by that key plus
 * `OLD_SRNO` when a line is removed (`:4652`, `:4795`).
 *
 * This is a master, not a voucher: rows are not part of any voucher write set and are therefore never
 * reversed by a voucher delete.
 */
export class DesignBookError extends Error {
  constructor(message: string) {
    super(message);
    // Name ends in 'ValidationError' so the route adapter maps it to HTTP 400.
    this.name = 'DesignBookValidationError';
  }
}

export interface DesignBookLine {
  srNo?: number;
  oldSrNo?: number;
  pageNo?: string;
  designNo: string;
  grCode?: string;
  itmSize?: string;
  dieNo?: string;
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  netWt?: number;
  touch?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  amount?: number;
  labourType?: string;
  labourPct?: number;
  labourRate?: number;
  labourAmount?: number;
  otherAmount?: number;
  tagCost?: number;
  mrp?: number;
  ghatPct?: number;
  ghatWt?: number;
  netAmount?: number;
  rateType?: string;
  itType?: string;
  karigarName?: string;
}

export interface DesignBookInput {
  scope: { tenantId: string; coCode: string };
  /** Design book name — part of the desktop key. */
  bookName: string;
  /** Product code the book belongs to — part of the desktop key. */
  prCode: string;
  vchDate?: Date | string;
  mainUser?: string;
  lines: DesignBookLine[];
}

const n = (v: unknown): number => (v == null ? 0 : Number(v));
/** Widths are the REAL ones from `information_schema` (PAGE_NO is `text`); guessed widths cause 22001. */
const t = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;

/**
 * Replace the design lines of one book+product, mirroring the desktop's delete-by-key then insert.
 * Returns the number of lines written.
 */
export async function saveDesignBook(prisma: any, input: DesignBookInput): Promise<number> {
  const bookName = String(input.bookName ?? '').trim();
  const prCode = String(input.prCode ?? '').trim();
  // MS_DESIGN_BOOK.cs reports a missing book selection in these exact words.
  if (!bookName) throw new DesignBookError(DESKTOP_MESSAGES.BOOK_DETAIL_FIRST);
  if (!prCode) throw new DesignBookError('product code is required');
  if (!input.lines?.length) throw new DesignBookError('at least one design line is required');
  for (const line of input.lines) {
    if (!String(line.designNo ?? '').trim()) {
      // MS_DESIGN_BOOK.cs guards an empty design number before saving.
      throw new DesignBookError(DESKTOP_MESSAGES.DESIGN_NO_REQUIRED);
    }
  }

  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const tenantId = input.scope.tenantId;

  return withTenant(prisma, tenantId, async (tx: any) => {
    // MS_DESIGN_BOOK.cs:4795 deletes the book's lines by CO_CODE + PR_CODE + BOOK_NAME before rewrite.
    await tx.$executeRawUnsafe(
      `DELETE FROM "DESIGN_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3 AND "BOOK_NAME"=$4`,
      tenantId,
      input.scope.coCode,
      prCode,
      bookName,
    );

    let written = 0;
    for (const [index, line] of input.lines.entries()) {
      const srNo = line.srNo ?? index + 1;
      await insertRowTx(tx, 'DESIGN_DETL', tenantId, {
        CO_CODE: input.scope.coCode,
        BOOK_NAME: t(bookName, 20),
        PR_CODE: t(prCode, 2),
        SR_NO: srNo,
        OLD_SRNO: line.oldSrNo ?? srNo,
        PAGE_NO: t(line.pageNo, 50),
        VCH_DATE: vchDate,
        GR_CODE: t(line.grCode, 3),
        DESIGN_NO: t(line.designNo, 15),
        ITM_SIZE: t(line.itmSize, 15),
        DIE_NO: t(line.dieNo, 10),
        ITM_PCS: n(line.pcs),
        ITM_GWT: n(line.grossWt),
        ITM_OTH_WT: n(line.otherWt),
        ITM_NWT: n(line.netWt),
        ITM_TOUCH: n(line.touch),
        ITM_WEST_PRC: n(line.westPct),
        ITM_FINE: n(line.fineWt),
        ITM_RATE: n(line.rate),
        ITM_AMT: n(line.amount),
        LBR_TYPE: t(line.labourType, 1),
        LBR_PRC: n(line.labourPct),
        LBR_RATE: n(line.labourRate),
        LBR_AMT: n(line.labourAmount),
        OTH_AMT: n(line.otherAmount),
        TAG_COST: n(line.tagCost),
        ITM_MRP: n(line.mrp),
        GHT_PRC: n(line.ghatPct),
        ITM_GHT: n(line.ghatWt),
        NET_AMT: n(line.netAmount),
        RATE_TYPE: t(line.rateType, 1),
        IT_TYPE: t(line.itType, 1),
        KR_NAME: t(line.karigarName, 5),
        MAIN_USER: t(input.mainUser, 15),
      });
      written += 1;
    }
    return written;
  });
}

export async function listDesignBook(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  bookName: string,
  prCode: string,
): Promise<Record<string, unknown>[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT * FROM "DESIGN_DETL"
        WHERE "CO_CODE"=$1 AND "PR_CODE"=$2 AND "BOOK_NAME"=$3 ORDER BY "SR_NO"`,
      scope.coCode,
      prCode,
      bookName,
    ),
  );
}
