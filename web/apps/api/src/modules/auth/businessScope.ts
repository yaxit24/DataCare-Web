import { withTenant, type Tx } from '@datacare/db';
import type { FastifyRequest } from 'fastify';

export interface BusinessScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
  coBook?: string;
}

export class ScopeError extends Error {
  constructor(
    public code:
      | 'company-unavailable'
      | 'location-unavailable'
      | 'year-unavailable'
      | 'book-unavailable'
      | 'scope-mismatch'
      | 'scope-incomplete',
    public statusCode: number = 409,
  ) {
    super(code);
    this.name = 'ScopeError';
  }
}

const text = (value: unknown): string | undefined => {
  if (typeof value !== 'string' && typeof value !== 'number') return undefined;
  const out = String(value).trim();
  return out || undefined;
};

interface CompanyRow {
  CO_CODE?: string | null;
  CO_NAME?: string | null;
  LC_CODE?: string | null;
  allowed?: boolean;
}
interface LocationRow {
  LC_CODE?: string | null;
  LC_NAME?: string | null;
}
interface YearRow {
  year?: string | null;
}

async function companyTx(
  tx: Tx,
  coCode: string,
  access?: { loginName: string; isAdmin: boolean },
): Promise<CompanyRow> {
  const rows = await tx.$queryRawUnsafe<CompanyRow[]>(
    `SELECT c."CO_CODE",c."CO_NAME",c."LC_CODE",
              ($3::boolean OR EXISTS(
                SELECT 1 FROM "LOGIN_MAST" l
                 WHERE l."CO_CODE"=c."CO_CODE" AND l."LOGIN_NAME"=$2
              )) AS allowed
         FROM "CO_MAST" c WHERE c."CO_CODE"=$1 LIMIT 1`,
    coCode,
    access?.loginName ?? '',
    access?.isAdmin ?? true,
  );
  const row = rows[0];
  if (!row?.CO_CODE || row.allowed === false) throw new ScopeError('company-unavailable');
  return row;
}

async function locationTx(
  tx: Tx,
  coCode: string,
  requested: string | undefined,
  companyDefault: string | undefined,
): Promise<string> {
  const rows = await tx.$queryRawUnsafe<LocationRow[]>(
    `SELECT "LC_CODE","LC_NAME" FROM "LOCT_MAST"
        WHERE "CO_CODE"=$1 AND "LC_CODE" IS NOT NULL AND "LC_CODE"<>''
        ORDER BY CASE WHEN "LC_CODE"=$2 THEN 0 WHEN "LC_CODE"=$3 THEN 1 ELSE 2 END,"LC_CODE"`,
    coCode,
    requested ?? '',
    companyDefault ?? '',
  );
  if (requested) {
    const exact = rows.find((row) => String(row.LC_CODE ?? '') === requested);
    if (!exact) throw new ScopeError('location-unavailable');
    return requested;
  }
  const selected = text(rows[0]?.LC_CODE) ?? companyDefault;
  if (!selected) throw new ScopeError('location-unavailable');
  return selected;
}

async function yearTx(tx: Tx, coCode: string, requested?: string): Promise<string | undefined> {
  const rows = await tx.$queryRawUnsafe<YearRow[]>(
    `SELECT COALESCE(NULLIF(TRIM("CO_YEAR"),''),LEFT("OP_DATE",4)) AS year
         FROM "YEAR_MAST"
        WHERE "CO_CODE"=$1
          AND COALESCE(NULLIF(TRIM("CO_YEAR"),''),LEFT("OP_DATE",4)) IS NOT NULL
        ORDER BY CASE WHEN COALESCE(NULLIF(TRIM("CO_YEAR"),''),LEFT("OP_DATE",4))=$2
                      THEN 0 ELSE 1 END,
                 COALESCE(NULLIF(TRIM("CO_YEAR"),''),LEFT("OP_DATE",4)) DESC`,
    coCode,
    requested ?? '',
  );
  if (requested) {
    if (!rows.some((row) => text(row.year) === requested)) throw new ScopeError('year-unavailable');
    return requested;
  }
  return text(rows[0]?.year);
}

interface LoginScopeInput {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

interface SelectedScopeInput extends LoginScopeInput {
  loginName: string;
  isAdmin: boolean;
}

interface StoredScopeInput extends SelectedScopeInput {
  lcCode: string;
}

/**
 * Validate a persisted scope without selecting a new default. The caller owns the transaction
 * and must already bind input.tenantId through withTenant. SQL NULL year must be projected
 * to undefined by the caller; a present invalid/empty year is refused.
 */
export async function validateStoredScopeTx(
  tx: Tx,
  input: StoredScopeInput,
): Promise<BusinessScope> {
  if (typeof input.coCode !== 'string' || input.coCode.length === 0) {
    throw new ScopeError('company-unavailable');
  }
  if (typeof input.lcCode !== 'string' || input.lcCode.length === 0) {
    throw new ScopeError('location-unavailable');
  }
  if (
    input.coYear !== undefined &&
    (typeof input.coYear !== 'string' || input.coYear.length === 0)
  ) {
    throw new ScopeError('year-unavailable');
  }
  await companyTx(tx, input.coCode, { loginName: input.loginName, isAdmin: input.isAdmin });
  const lcCode = await locationTx(tx, input.coCode, input.lcCode, undefined);
  const coYear =
    input.coYear === undefined ? undefined : await yearTx(tx, input.coCode, input.coYear);
  return { tenantId: input.tenantId, coCode: input.coCode, lcCode, coYear };
}

/** The caller owns the transaction and must already bind input.tenantId through withTenant. */
export async function resolveLoginScopeTx(tx: Tx, input: LoginScopeInput): Promise<BusinessScope> {
  const co = await companyTx(tx, input.coCode);
  const lcCode = await locationTx(tx, input.coCode, input.lcCode, text(co.LC_CODE));
  const coYear = await yearTx(tx, input.coCode, input.coYear);
  return { tenantId: input.tenantId, coCode: input.coCode, lcCode, coYear };
}

export async function resolveLoginScope(
  prisma: any,
  input: LoginScopeInput,
): Promise<BusinessScope> {
  return withTenant(prisma, input.tenantId, (tx) => resolveLoginScopeTx(tx, input));
}

/** The caller owns the transaction and must already bind input.tenantId through withTenant. */
export async function resolveSelectedScopeTx(
  tx: Tx,
  input: SelectedScopeInput,
): Promise<BusinessScope> {
  const co = await companyTx(tx, input.coCode, {
    loginName: input.loginName,
    isAdmin: input.isAdmin,
  });
  const lcCode = await locationTx(tx, input.coCode, input.lcCode, text(co.LC_CODE));
  const coYear = await yearTx(tx, input.coCode, input.coYear);
  if (!coYear) throw new ScopeError('year-unavailable');
  return { tenantId: input.tenantId, coCode: input.coCode, lcCode, coYear };
}

export async function resolveSelectedScope(
  prisma: any,
  input: SelectedScopeInput,
): Promise<BusinessScope> {
  return withTenant(prisma, input.tenantId, (tx) => resolveSelectedScopeTx(tx, input));
}

export async function listScopeCompanies(
  prisma: any,
  input: { tenantId: string; loginName: string; isAdmin: boolean },
): Promise<Array<{ CO_CODE: string; CO_NAME: string | null }>> {
  return withTenant(prisma, input.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT c."CO_CODE",c."CO_NAME" FROM "CO_MAST" c
        WHERE $2::boolean OR EXISTS(
          SELECT 1 FROM "LOGIN_MAST" l
           WHERE l."CO_CODE"=c."CO_CODE" AND l."LOGIN_NAME"=$1
        )
        ORDER BY c."CO_CODE"`,
      input.loginName,
      input.isAdmin,
    ),
  );
}

export async function listScopeLocations(
  prisma: any,
  input: { tenantId: string; coCode: string },
): Promise<Array<{ LC_CODE: string; LC_NAME: string | null }>> {
  return withTenant(prisma, input.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "LC_CODE","LC_NAME" FROM "LOCT_MAST"
        WHERE "CO_CODE"=$1 AND "LC_CODE" IS NOT NULL ORDER BY "LC_CODE"`,
      input.coCode,
    ),
  );
}

export async function listScopeYears(
  prisma: any,
  input: { tenantId: string; coCode: string },
): Promise<Array<{ year: string }>> {
  return withTenant(prisma, input.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT DISTINCT COALESCE(NULLIF(TRIM("CO_YEAR"),''),LEFT("OP_DATE",4)) AS year
         FROM "YEAR_MAST" WHERE "CO_CODE"=$1
          AND COALESCE(NULLIF(TRIM("CO_YEAR"),''),LEFT("OP_DATE",4)) IS NOT NULL
        ORDER BY 1`,
      input.coCode,
    ),
  );
}

export async function listScopeBooks(
  prisma: any,
  input: { tenantId: string; coCode: string; lcCode: string },
): Promise<
  Array<{
    CO_BOOK: string;
    BOOK_NAME: string | null;
    BOOK_SNAME: string | null;
    MAIN_BOOK: string | null;
  }>
> {
  return withTenant(prisma, input.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK" FROM "BOOK_DATA"
        WHERE "CO_CODE"=$1 AND ("LC_CODE"=$2 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND "CO_BOOK" IS NOT NULL AND COALESCE(UPPER("CUR_USE"),'Y')<>'N'
        ORDER BY "CO_BOOK"`,
      input.coCode,
      input.lcCode,
    ),
  );
}

async function validateBook(prisma: any, scope: BusinessScope, coBook: string): Promise<void> {
  const rows: unknown[] = await withTenant(prisma, scope.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT 1 FROM "BOOK_DATA"
        WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2
          AND ("LC_CODE"=$3 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND COALESCE(UPPER("CUR_USE"),'Y')<>'N' LIMIT 1`,
      scope.coCode,
      coBook,
      scope.lcCode,
    ),
  );
  if (!rows.length) throw new ScopeError('book-unavailable');
}

const record = (value: unknown): Record<string, unknown> =>
  value && typeof value === 'object' && !Array.isArray(value)
    ? (value as Record<string, unknown>)
    : {};

const distinct = (values: Array<string | undefined>): string[] => [
  ...new Set(values.filter(Boolean) as string[]),
];

/**
 * Reject client attempts to replace company/location/year. A request may select a book only after
 * the server proves it is active for the authenticated company/location. The resulting scope is
 * attached to the request and is the only scope consumed by route adapters.
 */
export async function enforceRequestScope(
  prisma: any,
  req: FastifyRequest,
  session: BusinessScope,
): Promise<BusinessScope> {
  if (!session.coCode || !session.lcCode || !session.coYear)
    throw new ScopeError('scope-incomplete');
  const body = record(req.body);
  const query = record(req.query);
  const candidates = (lower: string, upper: string): string[] =>
    distinct([text(body[lower]), text(body[upper]), text(query[lower]), text(query[upper])]);

  const companies = candidates('coCode', 'CO_CODE');
  const locations = candidates('lcCode', 'LC_CODE');
  const years = candidates('coYear', 'CO_YEAR');
  if (companies.some((value) => value !== session.coCode)) throw new ScopeError('scope-mismatch');
  if (locations.some((value) => value !== session.lcCode)) throw new ScopeError('scope-mismatch');
  if (years.some((value) => value !== session.coYear)) throw new ScopeError('scope-mismatch');

  const books = distinct([...candidates('coBook', 'CO_BOOK'), text(body.book), text(query.book)]);
  if (books.length > 1) throw new ScopeError('scope-mismatch');
  const coBook = books[0];
  const out: BusinessScope = { ...session, coBook };
  if (coBook) await validateBook(prisma, out, coBook);
  return out;
}
