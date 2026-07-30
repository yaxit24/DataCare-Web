import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

export class RepairWorkflowValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'RepairWorkflowValidationError';
  }
}

export interface RepairWorkflowBookPolicy {
  coBook: string;
  vchType: string;
  mainBook: string;
  inout: string;
  dataType: string;
}

export interface RepairWorkflowBookAccount {
  acCode: string;
  vchType: string;
  dataType: string;
}

export interface RepairWorkflowParty {
  acCode: string;
  acName: string;
  gstType: string;
}

export const repairNumber = (value: unknown): number =>
  value == null || value === '' ? 0 : Number(value);

export function repairNonNegative(value: unknown, label: string): number {
  const parsed = repairNumber(value);
  if (!Number.isFinite(parsed) || parsed < 0) {
    throw new RepairWorkflowValidationError(`${label} must be a non-negative number`);
  }
  return parsed;
}

export function assertCompleteRepairScope(
  scope: VoucherScope,
): asserts scope is VoucherScope & { coYear: string; coBook: string } {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new RepairWorkflowValidationError(
      'repair workflow requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

export async function resolveRepairWorkflowBookTx(
  tx: any,
  scope: VoucherScope,
  expectedMainBook: string,
): Promise<RepairWorkflowBookPolicy> {
  assertCompleteRepairScope(scope);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "CO_BOOK","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE","BOOK_TBL_NAME",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce(nullif(upper(btrim("CUR_USE"::text)),''),'Y') <> 'N'
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.coBook,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new RepairWorkflowValidationError(
      rows.length
        ? `repair book configuration is ambiguous: ${scope.coBook}`
        : `repair book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = String(row.MAIN_BOOK ?? '')
    .trim()
    .toUpperCase();
  const expected = expectedMainBook.trim().toUpperCase();
  if (mainBook !== expected) {
    throw new RepairWorkflowValidationError(
      `book ${scope.coBook} is ${mainBook || 'unclassified'}, expected ${expected}`,
    );
  }
  const table = String(row.BOOK_TBL_NAME ?? '')
    .trim()
    .toUpperCase();
  if (table && table !== 'REP_DATA') {
    throw new RepairWorkflowValidationError(
      `book ${scope.coBook} writes ${table}, expected REP_DATA`,
    );
  }
  const inout = String(row.BOOK_INOUT ?? '')
    .trim()
    .toUpperCase();
  if (!inout || inout.length !== 1) {
    throw new RepairWorkflowValidationError(`book ${scope.coBook} has no one-character BOOK_INOUT`);
  }
  return {
    coBook: String(row.CO_BOOK ?? scope.coBook).trim(),
    vchType: String(row.BOOK_SNAME ?? '').trim() || String(scope.coBook),
    mainBook,
    inout,
    dataType: String(row.DATA_TYPE ?? '').trim() || 'A',
  };
}

export async function resolveRepairWorkflowBookAccountTx(
  tx: any,
  scope: VoucherScope & { coBook?: string },
  policy: RepairWorkflowBookPolicy,
): Promise<RepairWorkflowBookAccount> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "AC_CODE","BOOK_SNAME","DATA_TYPE",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce("SR_NO",0)::numeric=1::numeric
          AND upper(btrim(coalesce("MAIN_BOOK"::text,'')))=$5
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    policy.coBook,
    scope.lcCode,
    policy.mainBook,
  );
  const acCode = rows.length === 1 ? String(rows[0]?.AC_CODE ?? '').trim() : '';
  if (rows.length !== 1 || !acCode) {
    throw new RepairWorkflowValidationError(
      `book ${policy.coBook} cash/control account row 1 is ${rows.length ? 'ambiguous or blank' : 'missing'}`,
    );
  }
  return {
    acCode,
    vchType: String(rows[0]?.BOOK_SNAME ?? '').trim() || policy.vchType,
    dataType: String(rows[0]?.DATA_TYPE ?? '').trim() || policy.dataType,
  };
}

export async function resolveRepairWorkflowPartyTx(
  tx: any,
  scope: VoucherScope,
  acCodeInput: string,
  suppliedName?: string,
): Promise<RepairWorkflowParty> {
  const acCode = String(acCodeInput ?? '').trim();
  if (!acCode) throw new RepairWorkflowValidationError('party account is required');
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "AC_CODE","AC_NAME","AC_GST_TYPE",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL OR btrim(coalesce("LC_CODE"::text,''))='')
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    acCode,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new RepairWorkflowValidationError(
      rows.length ? `party account is ambiguous: ${acCode}` : `party account not found: ${acCode}`,
    );
  }
  const databaseName = String(rows[0]?.AC_NAME ?? '').trim();
  return {
    acCode,
    acName:
      acCode === '00050' && String(suppliedName ?? '').trim()
        ? String(suppliedName).trim()
        : databaseName,
    gstType: String(rows[0]?.AC_GST_TYPE ?? '').trim() || 'L',
  };
}

export async function assertRepairWorkflowAccountTx(
  tx: any,
  scope: VoucherScope,
  acCodeInput: string,
  label: string,
): Promise<void> {
  const acCode = String(acCodeInput ?? '').trim();
  if (!acCode) throw new RepairWorkflowValidationError(`${label} account is required`);
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL OR btrim(coalesce("LC_CODE"::text,''))='')
      LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    acCode,
    scope.lcCode,
  );
  if (rows.length !== 1)
    throw new RepairWorkflowValidationError(`${label} account not found or ambiguous: ${acCode}`);
}

export async function nextRepairHeaderVoucherNoTx(
  tx: any,
  scope: VoucherScope & { coBook: string },
): Promise<string> {
  const key = `repair-header|${scope.tenantId}|${scope.coCode}|${scope.lcCode}|${scope.coBook}`;
  await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key);
  const rows: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(max(CASE WHEN "VCH_NO"::text ~ '^[0-9]+$' THEN "VCH_NO"::text::bigint END),0)::bigint AS n
       FROM "TEMP_BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  return formatVoucherNo(Number(rows[0]?.n ?? 0) + 1);
}

export function repairVoucherKey(
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Record<string, string> {
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
}

export async function existingRepairHeaderTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<Record<string, unknown> | null> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "REP_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return rows[0] ?? null;
}

export async function assertRepairVoucherUnlinkedTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<void> {
  const rows: Array<{ linked: unknown }> = await tx.$queryRawUnsafe(
    `SELECT count(*)::int AS linked FROM "REP_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND (upper(coalesce("REP_ADJ",'N'))='Y' OR upper(coalesce("ISU_ADJ",'N'))='Y')`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (Number(rows[0]?.linked ?? 0) > 0) {
    throw new RepairWorkflowValidationError('repair voucher is linked to a later workflow stage');
  }
}

export async function deleteRepairVoucherRowsTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<void> {
  const args = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
  for (const table of [
    'REMARK_DATA',
    'TAX_DATA',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'REP_DETL',
    'REP_DATA',
  ]) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...args,
    );
  }
}

export function repairDateOnly(value: unknown): string {
  if (!value) return '';
  if (value instanceof Date) return value.toISOString().slice(0, 10);
  return String(value).slice(0, 10);
}
