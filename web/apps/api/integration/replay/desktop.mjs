/**
 * Desktop side of the replay oracle: READ-ONLY access to the desktop SQL Server database.
 *
 * Nothing here writes to SQL Server and nothing here prints row values: the rows are handed to the loader, the
 * request builders and the bundle writer, which keep them outside the repository.
 */
import sql from 'mssql';

const IDENT = /^[A-Za-z_][A-Za-z0-9_]*$/;
export const qms = (v) => {
  if (!IDENT.test(v)) throw new Error(`unsafe SQL identifier: ${v}`);
  return `[${v}]`;
};
/** The desktop database mixes Latin1_General_CI_AS and SQL_Latin1_General_CP1_CI_AS columns. */
const C = 'COLLATE DATABASE_DEFAULT';

/** Plain JSON-able value: dates as ISO strings, bigint as string. */
export function plain(v) {
  if (v instanceof Date) return v.toISOString();
  if (typeof v === 'bigint') return v.toString();
  if (Buffer.isBuffer(v)) return null;
  return v;
}

export async function connectDesktop({ host, port, database, user, password }) {
  const pool = await new sql.ConnectionPool({
    server: host,
    port,
    database,
    user,
    password,
    options: { encrypt: false, trustServerCertificate: true, useUTC: true },
    requestTimeout: 240000,
  }).connect();

  /** Columns per table with type and scale, in ordinal order (the bundle format of parity-extract-mssql.mjs). */
  const metaRows = (
    await pool.request().query(`
      SELECT c.TABLE_NAME AS t, c.COLUMN_NAME AS c, c.DATA_TYPE AS ty, c.NUMERIC_SCALE AS sc
        FROM INFORMATION_SCHEMA.COLUMNS c JOIN INFORMATION_SCHEMA.TABLES x
          ON x.TABLE_NAME=c.TABLE_NAME AND x.TABLE_SCHEMA=c.TABLE_SCHEMA AND x.TABLE_TYPE='BASE TABLE'
       WHERE c.TABLE_SCHEMA='dbo' ORDER BY c.TABLE_NAME, c.ORDINAL_POSITION`)
  ).recordset;
  const meta = new Map();
  for (const r of metaRows) {
    const t = String(r.t).toUpperCase();
    if (!meta.has(t)) meta.set(t, { name: String(r.t), columns: [] });
    meta.get(t).columns.push({
      name: String(r.c),
      type: String(r.ty).toLowerCase(),
      scale: r.sc == null ? null : Number(r.sc),
    });
  }
  const has = (table, col) =>
    meta.get(table.toUpperCase())?.columns.some((c) => c.name.toUpperCase() === col) ?? false;

  return {
    meta,
    has,
    /** Every table carrying CO_BOOK and VCH_NO, from the desktop's own schema. */
    voucherTables() {
      return [...meta.keys()].filter((t) => has(t, 'CO_BOOK') && has(t, 'VCH_NO'));
    },
    async version() {
      const r = await pool.request().query('SELECT @@VERSION AS v');
      return String(r.recordset[0]?.v ?? '').split('\n')[0];
    },
    async books(coCode) {
      const r = await pool
        .request()
        .input('co', sql.NVarChar(10), coCode)
        .query(
          `SELECT CO_BOOK, MAIN_BOOK, BOOK_SNAME, BOOK_TBL_NAME, LC_CODE FROM BOOK_DATA WHERE CO_CODE=@co ORDER BY CO_BOOK`,
        );
      return r.recordset.map((b) => ({
        CO_BOOK: String(b.CO_BOOK ?? '').trim(),
        MAIN_BOOK: String(b.MAIN_BOOK ?? '').trim(),
        BOOK_SNAME: String(b.BOOK_SNAME ?? '').trim(),
        BOOK_TBL_NAME: String(b.BOOK_TBL_NAME ?? '').trim(),
        LC_CODE: String(b.LC_CODE ?? '').trim(),
      }));
    },
    /** Distinct vouchers of the given books in one header table: book, number, date and the entry clock. */
    async vouchers(header, books, { coCode, coYear }) {
      if (!books.length) return [];
      const req = pool
        .request()
        .input('co', sql.NVarChar(10), coCode)
        .input('yr', sql.NVarChar(20), coYear);
      const names = books.map((b, i) => {
        req.input(`b${i}`, sql.NVarChar(10), b);
        return `@b${i}`;
      });
      const r = await req.query(
        `SELECT CO_BOOK, VCH_NO, MIN(VCH_DATE) AS VCH_DATE, MIN(VCH_TIME) AS VCH_TIME
           FROM ${qms(header)}
          WHERE CO_CODE=@co AND CO_YEAR=@yr AND CO_BOOK IN (${names.join(',')})
          GROUP BY CO_BOOK, VCH_NO`,
      );
      return r.recordset.map((v) => ({
        book: String(v.CO_BOOK).trim(),
        vchNo: String(v.VCH_NO).trim(),
        vchDate: plain(v.VCH_DATE),
        vchTime: plain(v.VCH_TIME),
      }));
    },
    /**
     * All rows of `table` for the given books (and year, where the table has CO_YEAR), as plain objects. Used for
     * both the request rebuild and the golden bundle, so one query per table serves the whole run.
     */
    async rowsForBooks(table, books, { coCode, coYear }) {
      if (!books.length) return [];
      const req = pool.request().input('co', sql.NVarChar(10), coCode);
      const names = books.map((b, i) => {
        req.input(`b${i}`, sql.NVarChar(10), b);
        return `@b${i}`;
      });
      let where = `CO_BOOK IN (${names.join(',')})`;
      if (has(table, 'CO_CODE')) where += ' AND CO_CODE=@co';
      if (has(table, 'CO_YEAR')) {
        req.input('yr', sql.NVarChar(20), coYear);
        where += ' AND CO_YEAR=@yr';
      }
      const r = await req.query(`SELECT * FROM dbo.${qms(table)} WHERE ${where}`);
      return r.recordset.map((row) =>
        Object.fromEntries(Object.entries(row).map(([k, v]) => [k, plain(v)])),
      );
    },
    /** Whole table, for the masters/context load. */
    async allRows(table, columns) {
      const r = await pool
        .request()
        .query(`SELECT ${columns.map(qms).join(',')} FROM dbo.${qms(table)}`);
      return r.recordset;
    },
    /** URD purchases (book 043 style) that point at a sale through SL_BILL_DBCD / SL_BILL_NO. */
    async urdLinks({ coCode, coYear }) {
      const r = await pool
        .request()
        .input('co', sql.NVarChar(10), coCode)
        .input('yr', sql.NVarChar(20), coYear)
        .query(
          `SELECT CO_BOOK, VCH_NO, SL_BILL_DBCD, SL_BILL_NO FROM PR_DATA
            WHERE CO_CODE=@co AND CO_YEAR=@yr AND ISNULL(SL_BILL_NO,'') ${C} <> ''`,
        );
      return r.recordset.map((x) => ({
        book: String(x.CO_BOOK).trim(),
        vchNo: String(x.VCH_NO).trim(),
        saleBook: String(x.SL_BILL_DBCD ?? '').trim(),
        saleVchNo: String(x.SL_BILL_NO ?? '').trim(),
      }));
    },
    close: () => pool.close(),
  };
}
