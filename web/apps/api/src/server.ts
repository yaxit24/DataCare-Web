import { PrismaClient } from '@prisma/client';
import { readFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { withTenant } from '@datacare/db';
import { buildApp } from './app.js';
import { hashPassword } from './modules/auth/password.js';
import { resolveRuntimeConfig, type RuntimeConfig } from './modules/ops/runtimeConfig.js';

/** Dev-only convenience: ensure a demo company + admin login exist so you can log in immediately. */
async function seedDemo(prisma: PrismaClient, config: RuntimeConfig) {
  if (!config.seedDemo || !config.demoPassword) return;
  const pwd = await hashPassword(config.demoPassword);
  await withTenant(prisma, config.demoTenant, async (tx) => {
    await tx.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG")
       SELECT $1,'01','admin',$2,'ADMIN' WHERE NOT EXISTS (SELECT 1 FROM "LOGIN_MAST" WHERE "CO_CODE"='01' AND "LOGIN_NAME"='admin')`,
      config.demoTenant,
      pwd,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") SELECT $1,'01','Demo Jeweller' WHERE NOT EXISTS (SELECT 1 FROM "CO_MAST" WHERE "CO_CODE"='01')`,
      config.demoTenant,
    );
    // YEAR_MAST must carry CO_CODE: businessScope.year() filters by company, so a company-less row
    // resolves to no fiscal year and every business endpoint then answers 'scope-incomplete'.
    await tx.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       SELECT $1,'01','2024-2025','2024-04-01','2025-03-31'
        WHERE NOT EXISTS (SELECT 1 FROM "YEAR_MAST" WHERE "CO_CODE"='01' AND "CO_YEAR"='2024-2025')`,
      config.demoTenant,
    );
    // A location is mandatory: resolveLoginScope() cannot resolve a scope without one, and the
    // resulting ScopeError surfaces to the client as 'invalid-credentials', which looks like a
    // wrong password. Without this row the seeded demo account can never sign in.
    await tx.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")
       SELECT $1,'01','01','Main Counter'
        WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE "CO_CODE"='01' AND "LC_CODE"='01')`,
      config.demoTenant,
    );
    // CO_SET is mandatory: modules/shared/settingsBehavior.ts fails closed unless exactly one
    // company settings row exists, so without this every business endpoint errors. All flags are
    // left blank on purpose, which the loader maps to the documented default behavior.
    await tx.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE")
       SELECT $1,'01' WHERE NOT EXISTS (SELECT 1 FROM "CO_SET" WHERE "CO_CODE"='01')`,
      config.demoTenant,
    );
    // One active book, so a voucher screen has something selectable out of the box.
    await tx.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
                               "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       SELECT $1,'01','01','SAL','Sales','SALE','SALES','O','Y','SL_DATA'
        WHERE NOT EXISTS (SELECT 1 FROM "BOOK_DATA" WHERE "CO_CODE"='01' AND "CO_BOOK"='SAL')`,
      config.demoTenant,
    );
  });
  console.log(`[seed] demo ready -> tenant=${config.demoTenant}  CO=01  login=admin`);
}

async function main() {
  const config = resolveRuntimeConfig();
  const prisma = new PrismaClient();
  const app = await buildApp({
    prisma,
    secret: config.jwtSecret,
    logger: config.logger,
    secureCookies: config.secureCookies,
    defaultTenantId: config.tenantId,
    allowTenantHeader: !config.isProduction,
  });
  if (!config.isProduction) {
    const harness = resolve(dirname(fileURLToPath(import.meta.url)), '../../web/test-harness.html');
    app.get('/', async (_req, reply) =>
      reply.type('text/html').send(readFileSync(harness, 'utf8')),
    );
    await seedDemo(prisma, config).catch((error) => console.warn('[seed] skipped:', error.message));
  }
  await app.listen({ port: config.port, host: '0.0.0.0' });
  console.log(
    `[datacare-api] http://localhost:${config.port}  ${
      config.isProduction ? '' : '(visual test harness at /)'
    }`,
  );
}

main().catch((error) => {
  console.error(error);
  process.exit(1);
});
