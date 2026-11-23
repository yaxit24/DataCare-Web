import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * WP-26 (N243, G255), decision D6: the Sales Invoice print choice of TR_SALE. The desktop prints a Crystal file
 * named by `PRINT_MAST`; the web prints HTML/PDF, so each file name maps to a named web template, and a name with
 * no web template prints with the default template and says so. The order is the desktop's
 * (`BtnPrint_Click`, TR_SALE.cs:16482-16495): HUID box, then book 099, then the chosen file. The per-installation
 * `VK050NEVK`/`HM249NEHP` branches are not ported.
 */
export interface SaleTemplate {
  /** The web template id. */
  template: 'tax-invoice' | 'huid' | 'quotation';
  /** Document title the template prints. */
  title: string;
}

/** Crystal file name -> web template. Names compare case-insensitively (Windows file names). */
const TEMPLATES: Record<string, SaleTemplate> = {
  salesbilla4: { template: 'tax-invoice', title: 'Tax Invoice' },
  salesbillgst: { template: 'tax-invoice', title: 'Tax Invoice' },
  salebilla4gst: { template: 'tax-invoice', title: 'Tax Invoice' },
  rtlhuidprint: { template: 'huid', title: 'Tax Invoice (HUID)' },
  salesquotation: { template: 'quotation', title: 'Quotation' },
};
const DEFAULT: SaleTemplate = { template: 'tax-invoice', title: 'Tax Invoice' };

export interface SaleTemplateChoice extends SaleTemplate {
  /** The desktop report name (`rptName`). */
  file: string;
  /** True when the file has no web template and the default one prints. */
  isDefault: boolean;
  /** `OpAmt`/`ClAmt` are passed for every template but the HUID one (TR_SALE.cs:16503-16507). */
  passBalances: boolean;
}

export function chooseSaleTemplate(input: {
  huid?: boolean;
  coBook: string;
  file?: string;
}): SaleTemplateChoice {
  const file = input.huid
    ? 'RtlHuidPrint' // TR_SALE.cs:16484
    : String(input.coBook ?? '').trim() === '099'
      ? 'SalesQuotation' // TR_SALE.cs:16489
      : String(input.file ?? '').trim(); // TR_SALE.cs:16494
  const known = TEMPLATES[file.toLowerCase()];
  return { file, ...(known ?? DEFAULT), isDefault: !known, passBalances: !input.huid };
}

/** TR_SALE.cs:16439 */
export const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';

async function bookTypeTx(
  tx: any,
  scope: VoucherScope,
): Promise<{ mainBook: string; bookType: string }> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "MAIN_BOOK"::text AS m, coalesce("BOOK_TYPE"::text,'') AS t FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  return { mainBook: String(rows[0]?.m ?? '').trim(), bookType: String(rows[0]?.t ?? '').trim() };
}

const FILES_SQL = `SELECT "PRINT_FILE"::text AS f, coalesce("PRINT_SET_A"::text,'') AS s FROM "PRINT_MAST"
  WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3 AND coalesce("BOOK_TYPE",'')=$4 ORDER BY "PRINT_FILE"`;

/**
 * The print-file list of the sale book (TR_SALE.cs:13933): `PRINT_MAST` rows of the company for the book's main
 * book and book type, ordered by file name, a blank entry first, the `PRINT_SET_A = 'Y'` file selected. With no
 * row for the company the list is company "01"'s (same tenant only).
 */
export async function salePrintFiles(
  prisma: any,
  scope: VoucherScope,
): Promise<{ files: string[]; selected: string; fromCompany: string }> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const book = await bookTypeTx(tx, scope);
    let fromCompany = scope.coCode;
    let rows: any[] = await tx.$queryRawUnsafe(
      FILES_SQL,
      scope.tenantId,
      scope.coCode,
      book.mainBook,
      book.bookType,
    );
    if (!rows.length && scope.coCode !== '01') {
      fromCompany = '01';
      rows = await tx.$queryRawUnsafe(
        FILES_SQL,
        scope.tenantId,
        '01',
        book.mainBook,
        book.bookType,
      );
    }
    const files = rows.map((r) => String(r.f ?? '').trim());
    const selected = String(rows.find((r) => String(r.s).trim() === 'Y')?.f ?? '').trim();
    return { files: ['', ...files], selected, fromCompany };
  });
}

/**
 * "Set" (`btnTagSet_Click`, TR_SALE.cs:20618-20624): the chosen file becomes the book's default. Both updates run in
 * one transaction (the desktop runs two separate statements). An unknown file name is refused.
 */
export async function setSalePrintDefault(
  prisma: any,
  scope: VoucherScope,
  file: string,
): Promise<{ message: string }> {
  const name = String(file ?? '').trim();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const book = await bookTypeTx(tx, scope);
    const args = [scope.tenantId, scope.coCode, book.mainBook, book.bookType];
    const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3 AND coalesce("BOOK_TYPE",'')=$4`;
    const hit: any[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "PRINT_MAST" WHERE ${where} AND "PRINT_FILE"=$5`,
      ...args,
      name,
    );
    if (!name || !hit.length) {
      const error = new Error(`print file not found: ${name}`);
      error.name = 'SaleValidationError';
      throw error;
    }
    await tx.$executeRawUnsafe(`UPDATE "PRINT_MAST" SET "PRINT_SET_A"='N' WHERE ${where}`, ...args);
    await tx.$executeRawUnsafe(
      `UPDATE "PRINT_MAST" SET "PRINT_SET_A"='Y' WHERE ${where} AND "PRINT_FILE"=$5`,
      ...args,
      name,
    );
    return { message: 'Print Report Default Set' }; // TR_SALE.cs:20625
  });
}

/**
 * `OpAmt`/`ClAmt` (TR_SALE.cs:16259-16261, `DC_Main.MsAcBal`, DC_Main.cs:1463-1486): the party's `Sum(CR_AMT - DR_AMT)`
 * in `AC_DATA` of the company, location and year before (`<`) and up to (`<=`) the voucher time, two decimals.
 * A debit balance is therefore negative, exactly as the desktop passes it to the report.
 */
export async function salePartyBalancesTx(
  tx: any,
  scope: VoucherScope,
  acCode: string,
  at: Date,
): Promise<{ opAmt: number; clAmt: number }> {
  const sum = async (op: '<' | '<=') => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(coalesce("CR_AMT",0) - coalesce("DR_AMT",0)),0)::float AS a FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "AC_CODE"=$5
          AND coalesce("ENTRY_TIME","VCH_DATE"::timestamp) ${op} $6::timestamp`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      acCode,
      at,
    );
    return round(Number(rows[0]?.a ?? 0), 2);
  };
  return { opAmt: await sum('<'), clAmt: await sum('<=') };
}

/** The `OpAmt = ` / `ClAmt = ` formula texts (TR_SALE.cs:16505-16506). */
export const balanceFormulas = (b: { opAmt: number; clAmt: number }): string[] => [
  `OpAmt = ${b.opAmt.toFixed(2)}`,
  `ClAmt = ${b.clAmt.toFixed(2)}`,
];
