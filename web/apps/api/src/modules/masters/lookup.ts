import { withTenant } from '@datacare/db';

/** Lookup sources: master table + code/name columns for type-ahead pickers (LookupPicker UI). */
const SOURCES: Record<string, { table: string; code: string; name: string; extra?: string[] }> = {
  accounts: {
    table: 'AC_MAST',
    code: 'AC_CODE',
    name: 'AC_NAME',
    extra: ['AC_GST_TYPE', 'AC_CITY', 'AC_MOBILE', 'AC_STATE'],
  },
  customers: {
    table: 'AC_MAST',
    code: 'AC_CODE',
    name: 'AC_NAME',
    extra: ['AC_GST_TYPE', 'AC_CITY', 'AC_MOBILE', 'AC_STATE'],
  },
  items: { table: 'ITEM_MAST', code: 'IT_CODE', name: 'IT_NAME', extra: ['IT_TYPE'] },
  groups: { table: 'GROUP_MAST', code: 'GR_CODE', name: 'GR_NAME' },
  'ac-groups': { table: 'AC_GROUP', code: 'AC_GR', name: 'AC_GR_NAME', extra: ['AC_MAIN_GR'] },
  products: { table: 'PRODUCT_MAST', code: 'PR_CODE', name: 'PR_NAME' },
  employees: { table: 'EMP_MAST', code: 'EMP_CODE', name: 'EMP_NAME' },
  designs: { table: 'DESIGN_MAST', code: 'DESIGN_NO', name: 'DESIGN_NO' },
  tags: {
    table: 'BAR_DETL',
    code: 'TAG_NO',
    name: 'IT_CODE',
    extra: ['ITM_NWT', 'ITM_GWT', 'ITM_TOUCH', 'ITM_FINE', 'ITM_RATE', 'ITM_MRP'],
  },
  states: { table: 'STATE_MAST', code: 'STATE_CODE', name: 'STATE_NAME', extra: ['STATE_SHORT'] },
  books: {
    table: 'BOOK_DATA',
    code: 'CO_BOOK',
    name: 'BOOK_NAME',
    extra: ['BOOK_TYPE', 'BOOK_INOUT', 'BOOK_VCH_TYPE'],
  },
};

const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';

/** Search a master by code or name (case-insensitive, prefix-weighted), scoped to the company. */
export async function lookup(
  prisma: any,
  tenantId: string,
  entity: string,
  term: string,
  coCode: string,
  limit = 20,
): Promise<Record<string, unknown>[]> {
  const s = SOURCES[entity];
  if (!s) return [];
  const n = Math.min(Number(limit) || 20, 50);
  const t = `%${(term || '').trim()}%`;
  const cols = [s.code, s.name, ...(s.extra ?? [])].filter((c, i, a) => a.indexOf(c) === i);
  const sel = cols.map((c) => `${q(c)}`).join(',');
  // company filter only if the table has CO_CODE
  return withTenant(prisma, tenantId, async (tx: any) => {
    const hasCo =
      (
        await tx.$queryRawUnsafe(
          `SELECT count(*)::int n FROM information_schema.columns WHERE table_name=$1 AND column_name='CO_CODE'`,
          s.table,
        )
      )[0].n > 0;
    const coClause = hasCo ? `${q('CO_CODE')}=$3 AND ` : '';
    const params: unknown[] = hasCo ? [t, t, coCode] : [t, t];
    const rows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT ${sel} FROM ${q(s.table)} WHERE ${coClause}(${q(s.code)}::text ILIKE $1 OR ${q(s.name)}::text ILIKE $2)
       ORDER BY ${q(s.code)} LIMIT ${n}`,
      ...params,
    );
    return rows.map((r) => ({
      code: r[s.code],
      name: r[s.name],
      ...Object.fromEntries((s.extra ?? []).map((e) => [e, r[e]])),
    }));
  });
}

export const LOOKUP_ENTITIES = Object.keys(SOURCES);
