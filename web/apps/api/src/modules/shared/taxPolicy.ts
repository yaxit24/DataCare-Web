import type { VoucherScope } from '../vouchers/numbering.js';

export class TransactionTaxValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TransactionTaxValidationError';
  }
}

export interface ResolvedTaxPolicy {
  interState: boolean;
  accountGstType: string;
  taxCode: string;
  taxGroup: string;
  taxAc: string | null;
  taxPct: number;
}

/** Desktop Ac_Tax derives geography from AC_MAST.AC_GST_TYPE='I' and tax identity/account from
 * TAX_MAST. Missing or conflicting persisted data fails before any voucher write. */
export async function resolveTaxPolicyTx(
  tx: any,
  scope: VoucherScope,
  args: { acCode: string; taxPct: number; taxCode?: string; srNo?: number },
): Promise<ResolvedTaxPolicy> {
  const accounts: Array<{ gst_type: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "AC_GST_TYPE" AS gst_type FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        AND ("LC_CODE" IS NULL OR btrim("LC_CODE"::text)='' OR "LC_CODE"::text=$4)
      ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END,row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    args.acCode,
    scope.lcCode,
  );
  if (accounts.length === 0) {
    throw new TransactionTaxValidationError(`account not found for tax policy: ${args.acCode}`);
  }
  const gstTypes = new Set(
    accounts.map((row) =>
      String(row.gst_type ?? '')
        .trim()
        .toUpperCase(),
    ),
  );
  if (gstTypes.size > 1) {
    throw new TransactionTaxValidationError(`conflicting GST types for account: ${args.acCode}`);
  }
  const accountGstType = [...gstTypes][0] ?? '';
  const interState = accountGstType === 'I';
  const pct = Number(args.taxPct ?? 0);

  const params: unknown[] = [scope.tenantId, scope.coCode];
  let selector: string;
  if (args.taxCode?.trim()) {
    params.push(args.taxCode.trim());
    selector = `"TAX_CODE"::text=$${params.length}`;
  } else {
    params.push(pct);
    selector = `coalesce("TAX_PRC",0)::numeric=$${params.length}::numeric`;
  }
  let rowSelector = '';
  if (args.srNo != null) {
    params.push(args.srNo);
    rowSelector = `AND coalesce("SR_NO",0)::numeric=$${params.length}::numeric`;
  } else if (args.taxCode?.trim()) {
    // Selecting BY CODE pins the PARENT row, SR_NO 0. The rows at SR_NO 1..n are not alternative
    // configurations of the code - they are its component breakdown (SGST / CGST / IGST), and comparing the
    // parent against a component is comparing a total to one of its parts.
    //
    // Without this the web could not post a sale against ANY real GST tax master. Measured on the real
    // customer database: every one of the five GST codes has its parent colliding with its IGST row on
    // percentage with a different account - 10 at 3%, 11 at 5%, 12 at 12%, 13 at 18%, 14 at 28% - and each
    // also has SGST and CGST colliding at the half rate. So the conflict check fired on all of them and the
    // first attempt to replay a real desktop voucher failed with "tax code has conflicting configuration: 10".
    //
    // The desktop pins the parent the same way: its tax queries carry `AND D.SR_NO = 0`, in the sale
    // (Ac_Rojmel.Sales_Rojmel type 05), the TCS row, and the rate-cut tax rows.
    rowSelector = `AND coalesce("SR_NO",0)::numeric=0`;
  }
  const taxes: Array<{
    tax_code: unknown;
    tax_group: unknown;
    tax_ac: unknown;
    tax_pct: unknown;
  }> = await tx.$queryRawUnsafe(
    `SELECT "TAX_CODE" AS tax_code,"TAX_GROUP" AS tax_group,"TAX_AC" AS tax_ac,
            coalesce("TAX_PRC",0) AS tax_pct
       FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND ${selector} ${rowSelector}
      ORDER BY coalesce("SR_NO",0),row_id LIMIT 2`,
    ...params,
  );
  if (taxes.length === 0) {
    throw new TransactionTaxValidationError(
      args.taxCode?.trim()
        ? `tax code is not configured: ${args.taxCode.trim()}`
        : `tax rate is not configured: ${pct}`,
    );
  }
  // The conflict check still matters on the percentage-only path: two different tax CODES sharing a rate
  // with different accounts is a genuine ambiguity the caller must resolve. What it must not do is treat a
  // code's own component rows as rivals.
  const identities = new Set(
    taxes.map((row) =>
      [row.tax_code, row.tax_group, row.tax_ac, Number(row.tax_pct)].map(String).join('|'),
    ),
  );
  if (identities.size > 1) {
    throw new TransactionTaxValidationError(
      args.taxCode?.trim()
        ? `tax code has conflicting configuration: ${args.taxCode.trim()}`
        : `tax rate maps to multiple configurations: ${pct}`,
    );
  }
  const tax = taxes[0];
  return {
    interState,
    accountGstType,
    taxCode: String(tax?.tax_code ?? ''),
    taxGroup: String(tax?.tax_group ?? ''),
    taxAc: String(tax?.tax_ac ?? '').trim() || null,
    taxPct: Number(tax?.tax_pct ?? 0),
  };
}
