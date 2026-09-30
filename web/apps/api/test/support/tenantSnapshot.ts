/**
 * Whole-tenant snapshot and diff, for "complete database diff" evidence.
 *
 * `footprint.ts` answers WHICH voucher tables received rows. That cannot see a write to a table with no VCH_NO (a
 * TAG_STOCK row removed, a TAG_IMAGE_DATA row touched), and it cannot see an UPDATE of a row that already existed —
 * for example a writer that quietly edits the source tag it cancels. This helper reads every row of every table
 * that carries `tenant_id`, before and after, and reports the exact rows added and removed per table; a modified row
 * shows as one removed and one added. An assertion over it therefore covers the whole database, not a list of
 * tables its author thought of.
 *
 * Pass an OWNER client (RLS is not forced for the owner), or a tenant-scoped transaction.
 */

interface RawClient {
  $queryRawUnsafe: (sql: string, ...params: unknown[]) => Promise<unknown>;
}

export type TenantSnapshot = Map<string, string[]>;

export interface TenantDiff {
  added: Record<string, Array<Record<string, unknown>>>;
  removed: Record<string, Array<Record<string, unknown>>>;
}

const serialize = (row: Record<string, unknown>): string =>
  JSON.stringify(row, (_key, value) => (typeof value === 'bigint' ? value.toString() : value));

export async function tenantTables(client: RawClient): Promise<string[]> {
  const rows = (await client.$queryRawUnsafe(
    `SELECT table_name AS name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id'
      GROUP BY table_name ORDER BY table_name`,
  )) as Array<{ name: string }>;
  return rows.map((row) => String(row.name));
}

export async function snapshotTenant(
  client: RawClient,
  tenantId: string,
  tables?: readonly string[],
): Promise<TenantSnapshot> {
  const names = tables ?? (await tenantTables(client));
  const out: TenantSnapshot = new Map();
  for (const table of names) {
    const rows = (await client.$queryRawUnsafe(
      `SELECT * FROM "${table}" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<Record<string, unknown>>;
    out.set(table, rows.map(serialize).sort());
  }
  return out;
}

/** Rows added and removed between two snapshots, per table; tables with no change are omitted. */
export function diffTenant(before: TenantSnapshot, after: TenantSnapshot): TenantDiff {
  const added: TenantDiff['added'] = {};
  const removed: TenantDiff['removed'] = {};
  const tables = new Set([...before.keys(), ...after.keys()]);
  for (const table of tables) {
    const was = [...(before.get(table) ?? [])];
    const now = [...(after.get(table) ?? [])];
    const remaining = new Map<string, number>();
    for (const row of was) remaining.set(row, (remaining.get(row) ?? 0) + 1);
    const plus: string[] = [];
    for (const row of now) {
      const left = remaining.get(row) ?? 0;
      if (left > 0) remaining.set(row, left - 1);
      else plus.push(row);
    }
    const minus: string[] = [];
    for (const [row, left] of remaining) for (let i = 0; i < left; i += 1) minus.push(row);
    if (plus.length) added[table] = plus.map((row) => JSON.parse(row));
    if (minus.length) removed[table] = minus.map((row) => JSON.parse(row));
  }
  return { added, removed };
}

/** `{ TABLE: rowCount }` for a diff side, for compact assertions. */
export const countsOf = (side: TenantDiff['added']): Record<string, number> =>
  Object.fromEntries(Object.entries(side).map(([table, rows]) => [table, rows.length]));
