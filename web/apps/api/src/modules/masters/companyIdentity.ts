import { withTxBudget } from '../shared/txBudget.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';
import { cloneCompanyTx } from './companyClone.js';
import { resolveYearDates } from './year.js';

// MS_COMPANY.cs:5882-5980 and :6074-6189. Hidden integration credentials are deliberately not exposed.
export const COMPANY_FIELDS: Record<string, number> = {
  CO_CODE: 2,
  CO_NAME: 50,
  CO_ADD1: 50,
  CO_ADD2: 50,
  CO_ADD3: 50,
  CO_COUNTRY: 25,
  CO_STATE_CODE: 2,
  CO_STATE: 25,
  CO_CITY: 25,
  CO_PIN: 10,
  CO_PHONE: 15,
  CO_PHONE2: 15,
  CO_MOBILE: 15,
  CO_MOBILE2: 15,
  CO_MAIL: 50,
  CO_JUD: 30,
  CO_CSTNO: 30,
  CO_GST_NO: 15,
  CO_PAN_NO: 30,
  DHIRAN_NO: 30,
  BANK_NAME: 50,
  BANK_AREA: 40,
  BANK_AC_NO: 30,
  BANK_RTGS_NO: 30,
  CO_TYPE: 1,
  REP_ADD_TYPE: 1,
  WORK_TYPE: 1,
  METAL_TYPE: 1,
};
export class CompanyIdentityError extends Error {
  constructor(
    message: string,
    public statusCode = 400,
  ) {
    super(message);
  }
}
export function normalizeCompanyIdentity(input: Record<string, unknown>) {
  const row: Record<string, string> = {};
  for (const [key, max] of Object.entries(COMPANY_FIELDS)) {
    let value = String(input[key] ?? '')
      .trim()
      .toUpperCase();
    if (key === 'CO_STATE') value = value.slice(0, 25); // desktop Strings.Mid
    if (value.length > max) throw new CompanyIdentityError(`${key} is at most ${max} characters`);
    row[key] = value;
  }
  if (!row.CO_CODE || !row.CO_NAME) throw new CompanyIdentityError('Enter Company Detail');
  for (const [key, choices] of Object.entries({
    REP_ADD_TYPE: 'CLB',
    WORK_TYPE: 'RW',
    METAL_TYPE: 'GSO',
  })) {
    row[key] ||= choices[0]!;
    if (!choices.includes(row[key]!)) throw new CompanyIdentityError(`Invalid ${key}`);
  }
  return row;
}
const lock = (tx: any, tenant: string) =>
  tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', `company-identity:${tenant}`);
const columns = Object.keys(COMPANY_FIELDS)
  .map((k) => `"${k}"`)
  .join(',');
async function readTx(tx: any, tenant: string, code: string) {
  const [row] = await tx.$queryRawUnsafe(
    `SELECT ${columns} FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND deleted_at IS NULL`,
    tenant,
    code,
  );
  return row ? { ...row, version: versionOf(row) } : null;
}
export function getCompanyIdentity(prisma: any, tenant: string, code: string) {
  return withTxBudget(prisma, tenant, 'read', (tx) => readTx(tx, tenant, code));
}
export async function saveCompanyIdentity(
  prisma: any,
  tenant: string,
  user: string,
  input: Record<string, any>,
  edit: boolean,
  edition?: string,
) {
  const row = normalizeCompanyIdentity(input);
  if (edition === 'L' && row.CO_CODE !== '01')
    throw new CompanyIdentityError('You Cant Creat New Company For DataCare Next Lite Version');
  return withTxBudget(prisma, tenant, 'heavy', async (tx: any) => {
    await lock(tx, tenant);
    const current = await readTx(tx, tenant, row.CO_CODE!);
    if (edit) {
      if (!current || requiredVersion(input.expectedVersion) !== current.version)
        throw new CompanyIdentityError(
          'Company changed. Open it again before saving or deleting.',
          409,
        );
    } else {
      const existing = await tx.$queryRawUnsafe(
        'SELECT "CO_NAME" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2',
        tenant,
        row.CO_CODE,
      );
      if (existing.length)
        throw new CompanyIdentityError(
          `This Company Code already Exist in  '${existing[0].CO_NAME}'  Company Name...Please Change Company Code...`,
          409,
        );
      const [{ n }] = await tx.$queryRawUnsafe(
        'SELECT count(*)::int n FROM "CO_MAST" WHERE tenant_id=$1 AND deleted_at IS NULL',
        tenant,
      );
      if (edition === 'B' && n >= 2)
        throw new CompanyIdentityError(
          'You Cant Creat More Then 2 New Company For DataCare Next Basic Version...',
        );
    }
    const duplicateName = await tx.$queryRawUnsafe(
      'SELECT "CO_CODE" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"<>$2 AND upper("CO_NAME")=$3 AND deleted_at IS NULL',
      tenant,
      row.CO_CODE,
      row.CO_NAME,
    );
    if (duplicateName.length)
      throw new CompanyIdentityError(
        `This Company Name already Exist in  '${duplicateName[0].CO_CODE}'  Company Code...Please Change Company Name...`,
        409,
      );
    const keys = Object.keys(row);
    if (edit) {
      await tx.$executeRawUnsafe(
        `UPDATE "CO_MAST" SET ${keys
          .filter((k) => k !== 'CO_CODE')
          .map((k, i) => `"${k}"=$${i + 3}`)
          .join(',')} WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        tenant,
        row.CO_CODE,
        ...keys
          .filter((k) => k !== 'CO_CODE')
          .map((k) => (row[k] === normalizeCompanyIdentity(current)[k] ? current[k] : row[k])),
      );
    } else {
      const dates = resolveYearDates(input.firstYear ?? {});
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_MAST"(tenant_id,${columns},"LC_CODE","MAIN_USER") VALUES ($1,${keys.map((_, i) => `$${i + 2}`).join(',')},'00',$${keys.length + 2})`,
        tenant,
        ...keys.map((k) => row[k]),
        user,
      );
      const source = String(input.sourceCoCode || '01');
      if (source !== row.CO_CODE) {
        if (!(await readTx(tx, tenant, source)))
          throw new CompanyIdentityError('Source company is unavailable');
        await cloneCompanyTx(tx, tenant, row.CO_CODE!, {
          sourceCoCode: source,
          desktopDefaults: !input.sourceCoCode,
          importAllParties: input.importAllParties !== false,
        });
      }
      await tx.$executeRawUnsafe(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE","YEAR_MONTH","OLD_METHOD","MAIN_USER") VALUES ($1,$2,$3,$4,$5::date,$6,'Y',$7)`,
        tenant,
        row.CO_CODE,
        input.firstYear.coYear,
        dates.opDate,
        dates.clDate,
        dates.yearMonth,
        user,
      );
    }
    // MS_COMPANY.cs:6183-6191: A/B companies use transfer books; only the
    // OPBL_TRFR_BTN=N branch clears reset flags for the desktop book families.
    if (row.CO_TYPE === 'A' || row.CO_TYPE === 'B') {
      await tx.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "TRFR_BOOK"='Y', "RESET_BOOK"=CASE
           WHEN ("MAIN_BOOK" IN ('000','015') OR "BOOK_TYPE"='T') AND EXISTS (
             SELECT 1 FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "OPBL_TRFR_BTN"='N'
           ) THEN 'N' ELSE "RESET_BOOK" END
         WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        tenant,
        row.CO_CODE,
      );
    }
    return readTx(tx, tenant, row.CO_CODE!);
  });
}
export function deleteCompanyIdentity(prisma: any, tenant: string, code: string, version: unknown) {
  if (code === '01') throw new CompanyIdentityError('You cant Delete Defoult company...');
  if (!code) throw new CompanyIdentityError('Please Select Company Code For Delete.');
  return withTxBudget(prisma, tenant, 'voucher', async (tx: any) => {
    await lock(tx, tenant);
    const current = await readTx(tx, tenant, code);
    if (!current || requiredVersion(version) !== current.version)
      throw new CompanyIdentityError(
        'Company changed. Open it again before saving or deleting.',
        409,
      );
    await tx.$executeRawUnsafe(
      'UPDATE "CO_MAST" SET deleted_at=clock_timestamp() WHERE tenant_id=$1 AND "CO_CODE"=$2',
      tenant,
      code,
    );
    return { message: 'Delete Success.' };
  });
}
