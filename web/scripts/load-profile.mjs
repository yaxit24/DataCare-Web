import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';
import process from 'node:process';

const here = new URL('.', import.meta.url);
const apiRequire = createRequire(new URL('../apps/api/package.json', here));

export function percentile(values, quantile) {
  if (!Array.isArray(values) || values.length === 0) return 0;
  if (!Number.isFinite(quantile) || quantile < 0 || quantile > 1) {
    throw new RangeError('quantile must be between 0 and 1');
  }
  const ordered = values.map(Number).sort((left, right) => left - right);
  const rank = Math.max(0, Math.ceil(quantile * ordered.length) - 1);
  return ordered[rank];
}

export function summarizeResults(results) {
  const operations = {};
  for (const result of results) {
    const bucket = (operations[result.operation] ??= []);
    bucket.push(result);
  }
  return Object.fromEntries(
    Object.entries(operations)
      .sort(([left], [right]) => left.localeCompare(right))
      .map(([operation, rows]) => {
        const durations = rows.map((row) => row.durationMs);
        return [
          operation,
          {
            requests: rows.length,
            errors: rows.filter((row) => !row.ok).length,
            p50Ms: Number(percentile(durations, 0.5).toFixed(3)),
            p95Ms: Number(percentile(durations, 0.95).toFixed(3)),
            p99Ms: Number(percentile(durations, 0.99).toFixed(3)),
          },
        ];
      }),
  );
}

const requiredEnv = (name) => {
  const value = process.env[name]?.trim();
  if (!value) throw new Error(`${name} is required`);
  return value;
};

const positiveInt = (name, fallback) => {
  const value = Number(process.env[name] ?? fallback);
  if (!Number.isInteger(value) || value < 1) throw new Error(`${name} must be a positive integer`);
  return value;
};

const quoteIdentifier = (value) => `"${String(value).replaceAll('"', '""')}"`;

async function clearTenant(owner, tenantId) {
  const tables = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id'
      ORDER BY table_name`,
  );
  await owner.$transaction(async (tx) => {
    await tx.$executeRawUnsafe('SET LOCAL session_replication_role = replica');
    for (const { table_name: table } of tables) {
      await tx.$executeRawUnsafe(
        `DELETE FROM ${quoteIdentifier(table)} WHERE tenant_id=$1`,
        tenantId,
      );
    }
  });
}

async function seed(owner, hashPassword, fixture) {
  await clearTenant(owner, fixture.tenantId);
  const passwordHash = await hashPassword(fixture.password);
  await owner.$executeRawUnsafe(
    `INSERT INTO "CO_MAST" (tenant_id,"CO_CODE","CO_NAME","LC_CODE")
     VALUES ($1,$2,'G6 Load Profile Shop',$3)`,
    fixture.tenantId,
    fixture.coCode,
    fixture.lcCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "LOCT_MAST" (tenant_id,"CO_CODE","LC_CODE","LC_NAME")
     VALUES ($1,$2,$3,'Main Counter')`,
    fixture.tenantId,
    fixture.coCode,
    fixture.lcCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "YEAR_MAST" (tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,$4::date,$5::date)`,
    fixture.tenantId,
    fixture.coCode,
    fixture.coYear,
    fixture.fromDate,
    fixture.toDate,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "LOGIN_MAST" (
       tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
       "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED"
     ) VALUES ($1,$2,$3,$4,'ADMIN','Y','Y','Y','N')`,
    fixture.tenantId,
    fixture.coCode,
    fixture.loginName,
    passwordHash,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "CO_SET" (tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
    fixture.tenantId,
    fixture.coCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "AC_MAST" (tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
     VALUES ($1,$2,$3,'LOADCUST','Load Profile Customer','L')`,
    fixture.tenantId,
    fixture.coCode,
    fixture.lcCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "TAX_MAST" (
       tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC"
     ) VALUES ($1,$2,'10',1,'GST','GST 3%',3,'GSTLED')`,
    fixture.tenantId,
    fixture.coCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "GROUP_MAST" (tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
     VALUES ($1,$2,'LDG','Load Gold','SALEAC')`,
    fixture.tenantId,
    fixture.coCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "ITEM_MAST" (tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'LOADI','Load Item','G','LDG')`,
    fixture.tenantId,
    fixture.coCode,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "BOOK_DATA" (
       tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME"
     ) VALUES ($1,$2,$3,$4,'Load Sales','LSAL','SALES','O','Y','SL_DATA')`,
    fixture.tenantId,
    fixture.coCode,
    fixture.lcCode,
    fixture.coBook,
  );
  await owner.$executeRawUnsafe(
    `INSERT INTO "BOOK_DETL" (
       tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT"
     ) VALUES ($1,$2,$3,$4,1,'CTRL','SALES','O'),
              ($1,$2,$3,$4,2,'CASH','SALES','O'),
              ($1,$2,$3,$4,3,'ROUND','SALES','O')`,
    fixture.tenantId,
    fixture.coCode,
    fixture.lcCode,
    fixture.coBook,
  );
}

function cookieHeader(response) {
  const setCookie = response.headers.getSetCookie?.() ?? [];
  return setCookie.map((value) => value.split(';', 1)[0]).join('; ');
}

async function request(baseUrl, cookie, operation, path, init = {}) {
  const started = performance.now();
  try {
    const response = await fetch(`${baseUrl}${path}`, {
      ...init,
      headers: {
        ...(init.body ? { 'content-type': 'application/json' } : {}),
        ...(cookie ? { cookie } : {}),
        ...(init.headers ?? {}),
      },
    });
    const body = await response.text();
    return {
      operation,
      durationMs: performance.now() - started,
      ok: response.ok,
      status: response.status,
      body,
    };
  } catch (error) {
    return {
      operation,
      durationMs: performance.now() - started,
      ok: false,
      status: 0,
      body: error instanceof Error ? error.message : String(error),
    };
  }
}

async function runPool(count, concurrency, work) {
  const rows = new Array(count);
  let cursor = 0;
  await Promise.all(
    Array.from({ length: Math.min(count, concurrency) }, async () => {
      while (true) {
        const index = cursor++;
        if (index >= count) return;
        rows[index] = await work(index);
      }
    }),
  );
  return rows;
}

async function appUserConnections(owner) {
  const rows = await owner.$queryRawUnsafe(
    `SELECT count(*)::int AS connections,
            count(*) FILTER (WHERE state='active')::int AS active
       FROM pg_stat_activity
      WHERE datname=current_database() AND usename='app_user'`,
  );
  return {
    connections: Number(rows[0]?.connections ?? 0),
    active: Number(rows[0]?.active ?? 0),
  };
}

function parseMetric(text, name) {
  const match = text.match(new RegExp(`^${name}\\s+(\\d+(?:\\.\\d+)?)$`, 'm'));
  return match ? Number(match[1]) : null;
}

export async function runLoadProfile() {
  const runtimeUrl = requiredEnv('DATABASE_URL');
  const ownerUrl = requiredEnv('MIGRATE_DATABASE_URL');
  const fixture = {
    tenantId: process.env.LOAD_PROFILE_TENANT?.trim() || 'g6-load-profile',
    coCode: '01',
    lcCode: '01',
    coYear: '2025-2026',
    coBook: 'SAL',
    fromDate: '2025-04-01',
    toDate: '2026-03-31',
    loginName: process.env.LOAD_PROFILE_LOGIN?.trim() || 'load-admin',
    password: requiredEnv('LOAD_PROFILE_PASSWORD'),
  };
  const jwtSigningKey = requiredEnv('LOAD_PROFILE_JWT_SECRET');
  const profile = {
    voucherCreate: {
      requests: positiveInt('LOAD_CREATE_REQUESTS', 24),
      concurrency: positiveInt('LOAD_CREATE_CONCURRENCY', 4),
    },
    voucherRead: {
      requests: positiveInt('LOAD_READ_REQUESTS', 60),
      concurrency: positiveInt('LOAD_READ_CONCURRENCY', 12),
    },
    reportRender: {
      requests: positiveInt('LOAD_REPORT_REQUESTS', 30),
      concurrency: positiveInt('LOAD_REPORT_CONCURRENCY', 6),
    },
  };

  const { PrismaClient } = apiRequire('@prisma/client');
  const owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
  const runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  const [{ buildApp }, { hashPassword }] = await Promise.all([
    import('../apps/api/dist/app.js'),
    import('../apps/api/dist/modules/auth/password.js'),
  ]);
  let app;
  try {
    await seed(owner, hashPassword, fixture);
    app = await buildApp({
      prisma: runtime,
      secret: jwtSigningKey,
      secureCookies: false,
      defaultTenantId: fixture.tenantId,
      allowTenantHeader: false,
      rendererProbe: async () => ({ available: true, engine: 'playwright-chromium' }),
    });
    const address = await app.listen({ host: '127.0.0.1', port: 0 });
    const login = await fetch(`${address}/auth/login`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify({
        coCode: fixture.coCode,
        lcCode: fixture.lcCode,
        coYear: fixture.coYear,
        loginName: fixture.loginName,
        password: fixture.password,
      }),
    });
    if (!login.ok) throw new Error(`load login failed (${login.status}): ${await login.text()}`);
    const cookie = cookieHeader(login);
    if (!cookie) throw new Error('load login did not return cookies');

    const saleBody = {
      coBook: fixture.coBook,
      acCode: 'LOADCUST',
      acName: 'Load Profile Customer',
      vchDate: '2025-07-28',
      taxRatePct: 3,
      taxCode: '10',
      interState: false,
      lines: [
        {
          itCode: 'LOADI',
          pcs: 1,
          grossWt: 1,
          netWt: 1,
          touch: 91.6,
          metalAmount: 1000,
        },
      ],
    };
    const warm = await request(address, cookie, 'warmup', '/sales', {
      method: 'POST',
      body: JSON.stringify(saleBody),
    });
    if (!warm.ok) throw new Error(`warm-up voucher failed (${warm.status}): ${warm.body}`);
    const warmVoucher = JSON.parse(warm.body).vchNo;

    const baseline = await appUserConnections(owner);
    const samples = [baseline];
    const sampleTimer = setInterval(() => {
      void appUserConnections(owner).then((sample) => samples.push(sample));
    }, 10);
    const started = performance.now();
    const [creates, reads, reports] = await Promise.all([
      runPool(profile.voucherCreate.requests, profile.voucherCreate.concurrency, () =>
        request(address, cookie, 'voucher_create', '/sales', {
          method: 'POST',
          body: JSON.stringify(saleBody),
        }),
      ),
      runPool(profile.voucherRead.requests, profile.voucherRead.concurrency, () =>
        request(address, cookie, 'voucher_read', `/sales/${warmVoucher}?coBook=${fixture.coBook}`),
      ),
      runPool(profile.reportRender.requests, profile.reportRender.concurrency, () =>
        request(
          address,
          cookie,
          'report_render',
          `/reports/sales-register?fromDate=${fixture.fromDate}&toDate=${fixture.toDate}`,
        ),
      ),
    ]);
    const elapsedMs = performance.now() - started;
    clearInterval(sampleTimer);
    await new Promise((resolve) => setTimeout(resolve, 25));
    const finalConnections = await appUserConnections(owner);
    samples.push(finalConnections);

    const results = [...creates, ...reads, ...reports];
    const operations = summarizeResults(results);
    const errors = results.filter((result) => !result.ok);
    const metricsResponse = await request(address, cookie, 'metrics', '/ops/metrics');
    const database = {
      baselineConnections: baseline.connections,
      peakConnections: Math.max(...samples.map((sample) => sample.connections)),
      peakActiveConnections: Math.max(...samples.map((sample) => sample.active)),
      finalConnections: finalConnections.connections,
      apiMetricConnections: metricsResponse.ok
        ? parseMetric(metricsResponse.body, 'datacare_db_pool_connections')
        : null,
      apiMetricActiveConnections: metricsResponse.ok
        ? parseMetric(metricsResponse.body, 'datacare_db_pool_active_connections')
        : null,
      samples: samples.length,
    };
    const output = {
      measuredAt: new Date().toISOString(),
      target: `compiled Fastify API over loopback HTTP and PostgreSQL 127.0.0.1:${process.env.PARITY_TEST_PORT?.trim() || '55433'}`,
      profile,
      requests: results.length,
      concurrency: Object.fromEntries(
        Object.entries(profile).map(([key, value]) => [key, value.concurrency]),
      ),
      elapsedMs: Number(elapsedMs.toFixed(3)),
      throughputRequestsPerSecond: Number((results.length / (elapsedMs / 1000)).toFixed(3)),
      errors: errors.length,
      operations,
      database,
      errorDetails: errors.slice(0, 10).map((result) => ({
        operation: result.operation,
        status: result.status,
        body: result.body.slice(0, 200),
      })),
    };
    console.log(JSON.stringify(output, null, 2));
    if (errors.length) process.exitCode = 1;
    return output;
  } finally {
    if (app) await app.close();
    await runtime.$disconnect();
    await owner.$disconnect();
  }
}

if (
  process.argv[1] &&
  fileURLToPath(import.meta.url) === fileURLToPath(new URL(`file://${process.argv[1]}`))
) {
  runLoadProfile().catch((error) => {
    console.error(error instanceof Error ? error.stack : error);
    process.exitCode = 1;
  });
}
