/**
 * Web side of the replay oracle: the isolated parity PostgreSQL (scripts/parity-test-env.mjs).
 *
 *  * `loadContext` copies the desktop masters, openings and every row that is NOT under replay into a fresh tenant —
 *    the world the replayed vouchers were entered into. It is the web-schema load of unified/tools/etl_mssql_to_pg.py
 *    (same rule: the intersection of the two column sets, coerced to the destination column type, tenant_id
 *    injected), done in Node because the Python ETL's live adapter is a stub and needs drivers this machine lacks.
 *  * `placeholder` moves the web's MAX(VCH_NO)+1 onto the desktop's number.
 *  * `rowsForBooks` reads back what the web wrote, for the bundle.
 *
 * It uses the migration OWNER connection, which bypasses RLS, and therefore filters by tenant_id on every statement.
 * The replay itself goes through the API as `app_user`.
 */
import { PrismaClient } from '@datacare/db';

const IDENT = /^[A-Za-z_][A-Za-z0-9_]*$/;
const qpg = (v) => {
  if (!IDENT.test(v)) throw new Error(`unsafe identifier: ${v}`);
  return `"${v}"`;
};

/**
 * Desktop tables never copied: credentials and rights (a dedicated replay login is created instead), images, and
 * the machine registry.
 */
export const SKIP_LOAD = new Set(['LOGIN_MAST', 'USER_MAST', 'USER_SET', 'IMAGE_DATA', 'HDD_MAST']);

function castFor(type) {
  const t = String(type ?? '').toLowerCase();
  if (t === 'date') return '::date';
  if (t.startsWith('timestamp'))
    return `::${t === 'timestamp with time zone' ? 'timestamptz' : 'timestamp'}`;
  if (t === 'boolean') return '::boolean';
  if (t === 'bigint') return '::bigint';
  if (t === 'integer' || t === 'smallint') return '::integer';
  if (t === 'numeric' || t === 'double precision' || t === 'real')
    return `::${t === 'numeric' ? 'numeric' : 'float8'}`;
  return '::text';
}

function coerce(value, type) {
  if (value === undefined || value === null) return null;
  const t = String(type).toLowerCase();
  if (value instanceof Date) return value.toISOString();
  if (typeof value === 'bigint') return value.toString();
  if (Buffer.isBuffer(value)) return null;
  if (typeof value === 'boolean') return t === 'boolean' ? value : value ? '1' : '0';
  if (value === '' && t !== 'text' && !t.startsWith('character')) return null;
  if (t === 'boolean') {
    const s = String(value).trim().toUpperCase();
    return ['1', 'Y', 'YES', 'T', 'TRUE'].includes(s);
  }
  if (t === 'bigint' || t === 'integer' || t === 'smallint') {
    const n = Number(value);
    return Number.isFinite(n) ? String(Math.round(n)) : null;
  }
  if (t === 'numeric' || t === 'double precision' || t === 'real') {
    const n = Number(value);
    return Number.isFinite(n) ? String(n) : null;
  }
  return String(value);
}

export async function connectWeb(ownerUrl) {
  const prisma = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
  const metaRows = await prisma.$queryRawUnsafe(
    `SELECT table_name AS t, column_name AS c, data_type AS ty, numeric_scale AS sc
       FROM information_schema.columns WHERE table_schema='public'
      ORDER BY table_name, ordinal_position`,
  );
  const meta = new Map();
  for (const r of metaRows) {
    const t = String(r.t);
    if (!meta.has(t)) meta.set(t, []);
    meta.get(t).push({
      name: String(r.c),
      type: String(r.ty).toLowerCase(),
      scale: r.sc == null ? null : Number(r.sc),
    });
  }
  const cols = (table) => meta.get(table) ?? [];
  const has = (table, col) => cols(table).some((c) => c.name === col);

  async function wipe(tenant) {
    for (const t of meta.keys()) {
      if (!has(t, 'tenant_id')) continue;
      await prisma.$executeRawUnsafe(`DELETE FROM ${qpg(t)} WHERE tenant_id=$1`, tenant);
    }
  }

  /** Insert plain row objects into a web table under `tenant`; returns { inserted, failed, firstError }. */
  async function insertRows(table, tenant, columns, rows) {
    const types = new Map(cols(table).map((c) => [c.name, c.type]));
    const insertCols = ['tenant_id', ...columns];
    const tuple = (row, params) =>
      `(${insertCols
        .map((c) => {
          params.push(c === 'tenant_id' ? tenant : coerce(row[c], types.get(c)));
          return `$${params.length}${c === 'tenant_id' ? '' : castFor(types.get(c))}`;
        })
        .join(',')})`;
    const sqlHead = `INSERT INTO ${qpg(table)} (${insertCols.map(qpg).join(',')}) VALUES `;
    let inserted = 0;
    let failed = 0;
    let firstError;
    const BATCH = Math.max(1, Math.floor(30000 / insertCols.length));
    for (let i = 0; i < rows.length; i += BATCH) {
      const chunk = rows.slice(i, i + BATCH);
      const params = [];
      const values = chunk.map((r) => tuple(r, params)).join(',');
      try {
        inserted += await prisma.$executeRawUnsafe(
          `${sqlHead}${values} ON CONFLICT DO NOTHING`,
          ...params,
        );
      } catch {
        // Find the offending rows one by one; the error text names the column, never the value.
        for (const r of chunk) {
          const p = [];
          try {
            inserted += await prisma.$executeRawUnsafe(
              `${sqlHead}${tuple(r, p)} ON CONFLICT DO NOTHING`,
              ...p,
            );
          } catch (e) {
            failed += 1;
            firstError ??= String(e?.message ?? e)
              .split('\n')
              .filter((l) => /code|message|error/i.test(l))
              .join(' ')
              .slice(0, 300);
          }
        }
      }
    }
    return { inserted, failed, firstError };
  }

  return {
    prisma,
    meta,
    has,
    cols,
    wipe,
    insertRows,
    /**
     * Copy the desktop world into `tenant`. `exclude(table, row)` returns true for a row the replay will create.
     */
    async loadContext(desktop, tenant, exclude) {
      await wipe(tenant);
      const summary = [];
      for (const [upper, d] of desktop.meta) {
        if (SKIP_LOAD.has(upper)) continue;
        const table = meta.has(upper) ? upper : null;
        if (!table || !has(table, 'tenant_id')) {
          summary.push({ table: upper, status: 'not-in-web-schema' });
          continue;
        }
        const webCols = new Set(cols(table).map((c) => c.name));
        const shared = d.columns
          .map((c) => c.name)
          .filter((c) => webCols.has(c) && c !== 'tenant_id' && c !== 'row_id')
          .filter((c) => !['bytea'].includes(cols(table).find((x) => x.name === c)?.type));
        const missing = d.columns.map((c) => c.name).filter((c) => !webCols.has(c));
        if (!shared.length) {
          summary.push({ table, status: 'no-shared-columns' });
          continue;
        }
        const all = await desktop.allRows(d.name, shared);
        const rows = all.filter((r) => !exclude(table, r));
        const res = await insertRows(table, tenant, shared, rows);
        summary.push({
          table,
          status: res.failed ? 'loaded-with-failures' : 'loaded',
          desktopRows: all.length,
          excludedForReplay: all.length - rows.length,
          inserted: res.inserted,
          conflicts: rows.length - res.inserted - res.failed,
          failed: res.failed,
          firstError: res.firstError,
          desktopOnlyColumns: missing.length ? missing : undefined,
        });
      }
      return summary;
    },
    /**
     * BOOK_DATA holds the book's state at the END of the year. A book the shop retired later (CUR_USE 'N') was in
     * use when its vouchers were entered, and the web refuses a voucher in a retired book (`book-unavailable`,
     * auth/businessScope.ts validateBook), so the replay reopens exactly the books it replays and reports which.
     */
    async reopenBooks(tenant, coCode, books) {
      const rows = await prisma.$queryRawUnsafe(
        `UPDATE "BOOK_DATA" SET "CUR_USE"='Y'
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK" = ANY($3::text[]) AND UPPER(COALESCE("CUR_USE",'Y'))='N'
          RETURNING "CO_BOOK"`,
        tenant,
        coCode,
        books,
      );
      return [...new Set(rows.map((r) => String(r.CO_BOOK)))].sort();
    },
    /** A throwaway row at `vchNo` so the web's next number is vchNo+1; returns a function that removes it. */
    async placeholder(table, tenant, scope, vchNo) {
      const extra = has(table, 'SR_NO') ? ',"SR_NO"' : '';
      const extraV = has(table, 'SR_NO') ? ',9999' : '';
      await prisma.$executeRawUnsafe(
        `INSERT INTO ${qpg(table)}(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO"${extra})
         VALUES ($1,$2,$3,$4,$5,$6${extraV})`,
        tenant,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        vchNo,
      );
      return () =>
        prisma.$executeRawUnsafe(
          `DELETE FROM ${qpg(table)} WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
          tenant,
          scope.coCode,
          scope.coYear,
          scope.coBook,
          vchNo,
        );
    },
    /** Web tables carrying CO_BOOK and VCH_NO (the same discovery rule as parity-extract-pg.mjs). */
    voucherTables() {
      return [...meta.keys()].filter(
        (t) => has(t, 'CO_BOOK') && has(t, 'VCH_NO') && has(t, 'tenant_id'),
      );
    },
    async rowsForBooks(table, tenant, books, { coCode, coYear }) {
      const params = [tenant, books];
      let where = `tenant_id=$1 AND "CO_BOOK"::text = ANY($2::text[])`;
      if (has(table, 'CO_CODE')) {
        params.push(coCode);
        where += ` AND "CO_CODE"=$${params.length}`;
      }
      if (has(table, 'CO_YEAR')) {
        params.push(coYear);
        where += ` AND "CO_YEAR"=$${params.length}`;
      }
      const rows = await prisma.$queryRawUnsafe(
        `SELECT * FROM ${qpg(table)} WHERE ${where}`,
        ...params,
      );
      return rows.map((r) =>
        Object.fromEntries(
          Object.entries(r).map(([k, v]) => {
            if (v instanceof Date) return [k, v.toISOString()];
            if (typeof v === 'bigint') return [k, v.toString()];
            if (v && typeof v === 'object' && typeof v.toFixed === 'function')
              return [k, String(v)];
            return [k, v];
          }),
        ),
      );
    },
    async createLogin(tenant, { coCode, loginName, hash }) {
      const columns = ['CO_CODE', 'LOGIN_NAME', 'LOGIN_PWD', 'LOGIN_CATG'];
      const values = [coCode, loginName, hash, 'ADMIN'];
      for (const [c, v] of [
        ['USER_UPDATE', 'Y'],
        ['USER_DELETE', 'Y'],
        ['USER_PRINT', 'Y'],
        ['PASSWORD_RESET_REQUIRED', 'N'],
        ['LOGIN_ACTIVE', 'Y'],
      ])
        if (has('LOGIN_MAST', c)) {
          columns.push(c);
          values.push(v);
        }
      await prisma.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,${columns.map(qpg).join(',')})
         VALUES ($1,${values.map((_, i) => `$${i + 2}`).join(',')})`,
        tenant,
        ...values,
      );
    },
    close: () => prisma.$disconnect(),
  };
}
