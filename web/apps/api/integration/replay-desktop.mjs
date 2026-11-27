#!/usr/bin/env node
/**
 * DESKTOP REPLAY ORACLE — replay a real desktop year through the real web API and compare every row.
 *
 *   pnpm --filter @datacare/api build
 *   ORACLE_OUT_DIR=/somewhere/outside/the/repo ORACLE_MSSQL_PASSWORD_FILE=/path/to/pw \
 *   PARITY_TEST_PORT=55497 pnpm oracle:replay [--book SALES] [--limit N]
 *
 * 1. The desktop database (default Next24M on 127.0.0.1:14339) is read: books, vouchers of the selected families,
 *    and every row each voucher wrote in every CO_BOOK+VCH_NO table — the GOLDEN answer.
 * 2. A fresh tenant in the isolated parity PostgreSQL receives the desktop masters, openings, settings and every
 *    row that is NOT under replay (replay/web.mjs loadContext).
 * 3. The real Fastify app is started as the non-owner `app_user` under forced RLS and a replay login signs in over
 *    HTTP (POST /auth/login). Each desktop voucher, in date order (replay/lib.mjs replayOrder), is rebuilt into the
 *    request body its web page posts (replay/lib.mjs buildRequest) and POSTed to the same route the page uses.
 * 4. What the web wrote is read back and compared with the desktop rows by modules/parity/bundleDiff.ts after the
 *    normalisation in replay/lib.mjs normaliseCase.
 * 5. Bundles, the diff and a report go to ORACLE_OUT_DIR, which must be OUTSIDE the repository: the desktop rows are
 *    real business data. Standard output carries counts and codes only.
 *
 * Options: --book <family|book>[,...]   SALES, PURCHASE, CASH/BANK, CONTRA, FINE JV, SALES ORDER, WH SALES (and the family without a
 *                                        builder: RATE CUT) or a book code such as 026.
 *          --limit N                     at most N vouchers per family (the first N in replay order).
 */
import { randomBytes } from 'node:crypto';
import { mkdirSync, readFileSync, realpathSync, writeFileSync } from 'node:fs';
import { dirname, relative, resolve, sep } from 'node:path';
import { fileURLToPath } from 'node:url';
import { PrismaClient } from '@datacare/db';
import { connectDesktop } from './replay/desktop.mjs';
import { connectWeb } from './replay/web.mjs';
import {
  FAMILIES,
  withHiddenBookRows,
  REPLAYABLE,
  ReplayBuildError,
  buildRequest,
  familyOf,
  familyTallies,
  groupDifferences,
  normaliseCase,
  placeholderFor,
  replayOrder,
  selectBooks,
  shortReason,
} from './replay/lib.mjs';
import { writeReport } from './replay/report.mjs';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB = resolve(HERE, '../../..');
const REPO = resolve(WEB, '..');

function env(name, fallback) {
  const v = String(process.env[name] ?? '').trim();
  if (v) return v;
  if (fallback !== undefined) return fallback;
  throw new Error(`${name} is required`);
}

export function parseArgs(argv) {
  const out = { book: '', limit: 0 };
  for (let i = 0; i < argv.length; i += 1) {
    const a = argv[i];
    if (a === '--book') out.book = argv[++i] ?? '';
    else if (a.startsWith('--book=')) out.book = a.slice(7);
    else if (a === '--limit') out.limit = Number(argv[++i] ?? 0);
    else if (a.startsWith('--limit=')) out.limit = Number(a.slice(8));
    else throw new Error(`unknown argument: ${a}`);
  }
  if (!Number.isInteger(out.limit) || out.limit < 0)
    throw new Error('--limit must be a whole number');
  return out;
}

/** Refuse an output folder inside the repository: bundles hold real customer rows. */
function outDir() {
  const dir = resolve(env('ORACLE_OUT_DIR'));
  mkdirSync(dir, { recursive: true });
  const real = realpathSync(dir);
  const repo = realpathSync(REPO);
  if (real === repo || real.startsWith(repo + sep))
    throw new Error(
      'ORACLE_OUT_DIR must be outside the repository (the bundles hold real business data)',
    );
  return real;
}

function assertIsolated(url, name) {
  const u = new URL(url);
  if (u.hostname !== '127.0.0.1' || u.port === '5433')
    throw new Error(
      `${name} must point at the isolated parity database on 127.0.0.1 (not the app port 5433)`,
    );
}

/** Minimal cookie jar for the API's access/refresh cookies. */
function cookieJar() {
  const jar = new Map();
  return {
    take(res) {
      for (const c of res.headers.getSetCookie?.() ?? []) {
        const [pair] = c.split(';');
        const at = pair.indexOf('=');
        const k = pair.slice(0, at).trim();
        const v = pair.slice(at + 1).trim();
        if (v) jar.set(k, v);
        else jar.delete(k);
      }
    },
    header: () => [...jar].map(([k, v]) => `${k}=${v}`).join('; '),
  };
}

async function main() {
  const args = parseArgs(process.argv.slice(2));
  const out = outDir();
  const runtimeUrl = env('DATABASE_URL');
  const ownerUrl = env('MIGRATE_DATABASE_URL');
  assertIsolated(runtimeUrl, 'DATABASE_URL');
  assertIsolated(ownerUrl, 'MIGRATE_DATABASE_URL');
  const scope = {
    coCode: env('ORACLE_COMPANY', '01'),
    coYear: env('ORACLE_YEAR', '2024-2025'),
    lcCode: env('ORACLE_LOCATION', '00'),
  };
  const tenant = env('ORACLE_TENANT', 'replay-oracle');
  // Every row of this tenant is wiped before the load, so only a replay tenant may be named.
  if (!/^replay-[a-z0-9-]+$/.test(tenant)) throw new Error('ORACLE_TENANT must start with replay-');
  const apiPort = Number(env('ORACLE_API_PORT', env('PARITY_API_PORT', '4497')));
  const passwordFile = String(process.env.ORACLE_MSSQL_PASSWORD_FILE ?? '').trim();
  const desktop = await connectDesktop({
    host: env('ORACLE_MSSQL_HOST', '127.0.0.1'),
    port: Number(env('ORACLE_MSSQL_PORT', '14339')),
    database: env('ORACLE_MSSQL_DATABASE', 'Next24M'),
    user: env('ORACLE_MSSQL_USER', 'sa'),
    password: passwordFile
      ? readFileSync(passwordFile, 'utf8').trim()
      : env('ORACLE_MSSQL_PASSWORD'),
  });
  const web = await connectWeb(ownerUrl);
  const startedAt = new Date().toISOString();
  let app;
  try {
    /* ---- 1. desktop: books, vouchers, golden rows -------------------------------------------- */
    const books = await desktop.books(scope.coCode);
    const selected = selectBooks(books, args.book);
    if (!selected.length) throw new Error(`no book matches --book ${args.book}`);
    const bookInfo = new Map(selected.map((b) => [b.CO_BOOK, b]));
    // Books of families without a builder are reported as could-not-replay but stay in the context load, so the
    // vouchers that depend on them (a sale adjusting an order) still find them.
    const replayBooks = [...bookInfo.keys()].filter((b) =>
      REPLAYABLE.has(familyOf(bookInfo.get(b))),
    );
    const vouchers = [];
    for (const [family, f] of Object.entries(FAMILIES)) {
      const famBooks = selected.filter((b) => familyOf(b) === family).map((b) => b.CO_BOOK);
      if (!famBooks.length) continue;
      let list = replayOrder(
        (await desktop.vouchers(f.header, famBooks, scope)).map((v) => ({ ...v, family })),
      );
      if (args.limit) list = list.slice(0, args.limit);
      vouchers.push(...list);
    }
    const order = replayOrder(vouchers);
    const wanted = new Set(order.map((v) => `${v.book}|${v.vchNo}`));
    console.log(
      `desktop ${desktop.meta.size} tables; books ${replayBooks.join(',')}; ${order.length} voucher(s) to replay`,
    );

    const desktopVoucherTables = desktop.voucherTables().filter((t) => web.meta.has(t) || true);
    let desktopTempRows = [];
    const golden = new Map(); // "book|vch" -> { TABLE: rows[] }
    for (const t of desktopVoucherTables) {
      const rows = await desktop.rowsForBooks(desktop.meta.get(t).name, replayBooks, scope);
      if (t === 'TEMP_BOOK_DATA') {
        desktopTempRows = rows;
        continue;
      }
      for (const r of rows) {
        const k = `${String(r.CO_BOOK).trim()}|${String(r.VCH_NO).trim()}`;
        if (!wanted.has(k)) continue;
        const g = golden.get(k) ?? {};
        (g[t] ??= []).push(r);
        golden.set(k, g);
      }
    }
    // The tag a sale line issues, as the page's tag pick shows it (BAR_DETL is keyed by the tag's own voucher).
    const barCols = desktop.meta.get('BAR_DETL')?.columns.map((c) => c.name) ?? [];
    const tags = new Map();
    for (const r of barCols.length ? await desktop.allRows('BAR_DETL', barCols) : [])
      tags.set(`${String(r.TAG_NO).trim()}|${Number(r.VCH_SRNO ?? 0)}`, r);
    const ctx = {
      tag: (tagNo, vchSrno) =>
        tags.get(`${tagNo}|${Number(vchSrno ?? 0)}`) ??
        [...tags.values()].find((r) => String(r.TAG_NO).trim() === tagNo),
    };

    /* ---- 2. web: fresh tenant with the desktop world minus what is replayed ------------------ */
    const voucherTableSet = new Set(desktop.voucherTables());
    const replaySet = new Set(replayBooks);
    const exclude = (table, row) => {
      if (!voucherTableSet.has(table)) return false;
      const book = String(row.CO_BOOK ?? '').trim();
      if (!replaySet.has(book)) return false;
      if (row.CO_YEAR !== undefined && String(row.CO_YEAR).trim() !== scope.coYear) return false;
      // With --limit, the book's later vouchers stay out entirely: they are neither loaded nor replayed.
      return true;
    };
    const t0 = Date.now();
    const load = await web.loadContext(desktop, tenant, exclude);
    const loaded = load.reduce((n, s) => n + (s.inserted ?? 0), 0);
    const failed = load.reduce((n, s) => n + (s.failed ?? 0), 0);
    console.log(
      `context load: ${loaded} row(s) into ${load.filter((s) => s.inserted).length} table(s), ` +
        `${failed} refused, ${Math.round((Date.now() - t0) / 1000)}s`,
    );

    const reopened = await web.reopenBooks(tenant, scope.coCode, replayBooks);
    if (reopened.length)
      console.log(`reopened retired book(s) for the replay: ${reopened.join(',')}`);

    /* ---- 3. the real API, a real login ------------------------------------------------------- */
    const { buildApp } = await import('../dist/app.js');
    const { hashPassword } = await import('../dist/modules/auth/password.js');
    const { warmPostingMetadata } = await import('../dist/modules/posting/posting.js');
    const { diffBundles } = await import('../dist/modules/parity/bundleDiff.js');
    const loginName = 'ORACLE';
    const password = `Or-${randomBytes(18).toString('hex')}!`;
    await web.createLogin(tenant, {
      coCode: scope.coCode,
      loginName,
      hash: await hashPassword(password),
    });
    const runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    const [role] = await runtime.$queryRawUnsafe(
      `SELECT rolsuper, rolbypassrls FROM pg_roles WHERE rolname=current_user`,
    );
    if (role?.rolsuper || role?.rolbypassrls)
      throw new Error('DATABASE_URL must be the non-owner app_user');
    await warmPostingMetadata(runtime).catch(() => {});
    app = await buildApp({
      prisma: runtime,
      secret: randomBytes(32).toString('hex'),
      secureCookies: false,
      defaultTenantId: tenant,
      allowTenantHeader: false,
    });
    app.addHook('onClose', () => runtime.$disconnect());
    await app.listen({ port: apiPort, host: '127.0.0.1' });
    const origin = `http://127.0.0.1:${apiPort}`;
    const jar = cookieJar();
    const send = async (method, path, body) => {
      const res = await fetch(origin + path, {
        method,
        headers: { 'content-type': 'application/json', cookie: jar.header() },
        body: body === undefined ? undefined : JSON.stringify(body),
      });
      jar.take(res);
      const text = await res.text();
      let json;
      try {
        json = text ? JSON.parse(text) : null;
      } catch {
        json = { error: text.slice(0, 200) };
      }
      return { status: res.status, json };
    };
    const login = await send('POST', '/auth/login', {
      coCode: scope.coCode,
      loginName,
      password,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
    });
    if (login.status !== 200)
      throw new Error(`login refused: ${login.status} ${login.json?.error}`);
    console.log(
      `signed in over HTTP at ${origin} as ${loginName} (${scope.coCode}/${scope.lcCode}/${scope.coYear})`,
    );
    const call = async (method, path, body) => {
      let r = await send(method, path, body);
      if (r.status === 401) {
        await send('POST', '/auth/refresh', {});
        r = await send(method, path, body);
      }
      return r;
    };

    /* ---- 4. replay ---------------------------------------------------------------------------- */
    const lastWeb = new Map();
    const results = [];
    const t1 = Date.now();
    for (const v of order) {
      const info = bookInfo.get(v.book);
      const caseId = `${v.family}:${v.book}/${v.vchNo}`;
      const voucher = {
        ...v,
        mainBook: info.MAIN_BOOK,
        bookSname: info.BOOK_SNAME,
        tables: golden.get(`${v.book}|${v.vchNo}`) ?? {},
      };
      const names = new Set();
      for (const rows of Object.values(voucher.tables))
        for (const r of rows)
          for (const k of ['AC_NAME', 'IT_NAME', 'CHQ_PRINT_NAME'])
            if (r[k]) names.add(String(r[k]).trim());
      const scrub = (s) => {
        let t = String(s ?? '');
        for (const n of names) if (n.length > 2) t = t.split(n).join('<name>');
        return t;
      };
      const base = {
        caseId,
        family: v.family,
        book: v.book,
        desktopVchNo: v.vchNo,
        vchDate: String(v.vchDate).slice(0, 10),
      };
      if (!REPLAYABLE.has(v.family)) {
        results.push({
          ...base,
          status: 'NO_BUILDER',
          reason: `no request builder for the ${v.family} family`,
        });
        continue;
      }
      let request;
      try {
        request = buildRequest(voucher, ctx);
      } catch (e) {
        results.push({
          ...base,
          status: 'BUILD_FAILED',
          reason: scrub(e instanceof ReplayBuildError ? e.message : e?.message),
        });
        continue;
      }
      const last = lastWeb.get(v.book) ?? 0;
      const phTable = info.BOOK_TBL_NAME || FAMILIES[v.family].header;
      const attempt = async (force) => {
        const ph = placeholderFor(v.vchNo, last, force);
        const removePh = ph
          ? await web
              .placeholder(phTable, tenant, { ...scope, coBook: v.book }, ph)
              .catch(() => undefined)
          : undefined;
        const hd = (voucher.tables[FAMILIES[v.family].header] ?? [])[0]?.HD_VCH_NO;
        const removeHd = await web
          .hiddenPlaceholder(tenant, { ...scope, coBook: v.book }, hd)
          .catch(() => undefined);
        try {
          return await call(request.method, request.path, request.body);
        } finally {
          if (removePh) await removePh();
          if (removeHd) await removeHd();
        }
      };
      try {
        let r = await attempt(false);
        let numberingCollision;
        // The web's own MAX(VCH_NO)+1 reused a number it had already written: a numbering defect. Record it, then
        // place the number explicitly so the voucher is still compared.
        if (
          r.status >= 400 &&
          /duplicate key/i.test(`${r.json?.message ?? r.json?.detail ?? ''}`)
        ) {
          numberingCollision = scrub(`${r.status} ${r.json?.message ?? r.json?.detail ?? ''}`);
          r = await attempt(true);
        }
        if (r.status >= 200 && r.status < 300 && !r.json?.vchNo) {
          results.push({
            ...base,
            status: 'REFUSED',
            route: `${request.method} ${request.path}`,
            httpStatus: r.status,
            numberingCollision,
            reason: 'harness: the web response carried no vchNo, so its rows cannot be read back',
          });
        } else if (r.status >= 200 && r.status < 300) {
          const webVch = String(r.json?.vchNo ?? '').padStart(5, '0');
          lastWeb.set(v.book, Math.max(last, Number(webVch)));
          results.push({
            ...base,
            status: 'REPLAYED',
            route: `${request.method} ${request.path}`,
            webVchNo: webVch,
            numbering: webVch === v.vchNo ? 'same' : 'different',
            numberingCollision,
          });
        } else {
          results.push({
            ...base,
            status: 'REFUSED',
            route: `${request.method} ${request.path}`,
            httpStatus: r.status,
            numberingCollision,
            reason: scrub(
              `${r.status} ${r.json?.error ?? ''} ${r.json?.message ?? r.json?.detail ?? ''}`.trim(),
            ),
          });
        }
      } catch (e) {
        results.push({ ...base, status: 'HARNESS_ERROR', reason: scrub(e?.message) });
      }
    }
    const ok = results.filter((r) => r.status === 'REPLAYED').length;
    console.log(
      `replayed ${ok}/${results.length} voucher(s) in ${Math.round((Date.now() - t1) / 1000)}s`,
    );

    /* ---- 5. compare ---------------------------------------------------------------------------- */
    const desktopTables = new Set(desktop.meta.keys());
    const replayed = results.filter((r) => r.status === 'REPLAYED');
    let webTempRows = [];
    const webRows = new Map();
    for (const t of web.voucherTables()) {
      const rows = await web.rowsForBooks(t, tenant, replayBooks, scope);
      if (t === 'TEMP_BOOK_DATA') {
        webTempRows = rows;
        continue;
      }
      for (const r of rows) {
        const k = `${String(r.CO_BOOK).trim()}|${String(r.VCH_NO).trim()}`;
        const g = webRows.get(k) ?? {};
        (g[t.toUpperCase()] ??= []).push(r);
        webRows.set(k, g);
      }
    }
    const toTable = (columns, rows) => ({
      columns,
      rows: rows.map((r) => columns.map((c) => (r[c.name] === undefined ? null : r[c.name]))),
    });
    const mkCase = (side, r) => {
      const key = side === 'desktop' ? `${r.book}|${r.desktopVchNo}` : `${r.book}|${r.webVchNo}`;
      const src = withHiddenBookRows(
        side === 'desktop' ? (golden.get(key) ?? {}) : (webRows.get(key) ?? {}),
        FAMILIES[r.family].header,
        side === 'desktop' ? desktopTempRows : webTempRows,
      );
      const tables = {};
      for (const [t, rows] of Object.entries(src)) {
        const columns = side === 'desktop' ? desktop.meta.get(t).columns : web.cols(t);
        tables[t] = toTable(columns, rows);
      }
      return normaliseCase(
        {
          caseId: r.caseId,
          description: `${r.family} ${r.book}/${r.desktopVchNo} dated ${r.vchDate}`,
          voucher: {
            book: r.book,
            vchNo: side === 'desktop' ? r.desktopVchNo : r.webVchNo,
            coYear: scope.coYear,
          },
          tables,
        },
        desktopTables,
        side,
      );
    };
    const bundle = (side, cases, source) => ({
      kind: 'datacare.parity-bundle/1.0',
      side,
      capturedAt: new Date().toISOString(),
      source,
      scope,
      cases,
    });
    const desktopBundle = bundle(
      'desktop',
      replayed.map((r) => mkCase('desktop', r)),
      {
        engine: 'sqlserver',
        database: env('ORACLE_MSSQL_DATABASE', 'Next24M'),
        host: env('ORACLE_MSSQL_HOST', '127.0.0.1'),
        appVersion: await desktop.version(),
      },
    );
    const webBundle = bundle(
      'web',
      replayed.map((r) => mkCase('web', r)),
      {
        engine: 'postgres',
        database: new URL(runtimeUrl).pathname.slice(1),
      },
    );
    const diff = diffBundles(desktopBundle, webBundle);
    const familyByCase = new Map(results.map((r) => [r.caseId, r.family]));
    const groups = groupDifferences(diff, (id) => familyByCase.get(id) ?? '?');
    const tallies = familyTallies(results, diff);

    writeFileSync(resolve(out, 'desktop-bundle.json'), `${JSON.stringify(desktopBundle)}\n`);
    writeFileSync(resolve(out, 'web-bundle.json'), `${JSON.stringify(webBundle)}\n`);
    writeFileSync(resolve(out, 'diff.json'), `${JSON.stringify(diff, null, 1)}\n`);
    writeFileSync(resolve(out, 'results.json'), `${JSON.stringify(results, null, 1)}\n`);
    writeFileSync(resolve(out, 'context-load.json'), `${JSON.stringify(load, null, 1)}\n`);
    const summary = {
      kind: 'datacare.replay-oracle/1.0',
      startedAt,
      finishedAt: new Date().toISOString(),
      args,
      scope,
      desktop: desktopBundle.source,
      books: selected,
      totals: diff.totals,
      tallies,
      groups,
      refusals: Object.entries(
        results
          .filter((r) => r.status !== 'REPLAYED')
          .reduce((acc, r) => {
            const k = `${r.family} | ${r.status} | ${shortReason(r.reason)}`;
            acc[k] = (acc[k] ?? 0) + 1;
            return acc;
          }, {}),
      ).sort((a, b) => b[1] - a[1]),
      numberingDifferent: results.filter((r) => r.numbering === 'different').map((r) => r.caseId),
      numberingCollisions: Object.entries(
        results
          .filter((r) => r.numberingCollision)
          .reduce((acc, r) => {
            const k = `${r.family} | ${r.route} | book ${r.book} | ${shortReason(r.numberingCollision)}`;
            acc[k] = (acc[k] ?? 0) + 1;
            return acc;
          }, {}),
      ),
      load: { rows: loaded, refused: failed, reopenedBooks: reopened },
    };
    writeFileSync(resolve(out, 'summary.json'), `${JSON.stringify(summary, null, 1)}\n`);
    writeReport(resolve(out, 'REPORT.md'), summary);

    for (const [fam, t] of Object.entries(tallies))
      console.log(
        `  ${fam.padEnd(12)} vouchers ${t.vouchers}  replayed ${t.replayed}  matched ${t.matched}  differed ${t.differed}  could-not-replay ${t.couldNotReplay}`,
      );
    console.log(
      `fields compared ${diff.totals.fieldsCompared}, differences ${diff.totals.fieldDifferences}`,
    );
    console.log(
      `ORACLE_REPLAY_DONE report -> ${relative(process.cwd(), resolve(out, 'REPORT.md'))}`,
    );
  } finally {
    await app?.close().catch(() => {});
    await web.close().catch(() => {});
    await desktop.close().catch(() => {});
  }
}

const invoked = process.argv[1] ? resolve(process.argv[1]) : '';
if (invoked === fileURLToPath(import.meta.url)) {
  main().catch((e) => {
    console.error(`ORACLE_REPLAY_FAILED ${e instanceof Error ? e.message : String(e)}`);
    process.exit(1);
  });
}
