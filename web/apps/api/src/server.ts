import { PrismaClient } from '@prisma/client';
import { readFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { withTxBudget } from './modules/shared/txBudget.js';
import { buildApp } from './app.js';
import { hashPassword } from './modules/auth/password.js';
import { resolveRuntimeConfig, type RuntimeConfig } from './modules/ops/runtimeConfig.js';
import { seedCompany } from './modules/ops/seedCompany.js';
import { warmPostingMetadata } from './modules/posting/posting.js';

/** Dev-only convenience: ensure a demo company + admin login exist so you can log in immediately. */
async function seedDemo(prisma: PrismaClient, config: RuntimeConfig) {
  if (!config.seedDemo || !config.demoPassword) return;
  const pwd = await hashPassword(config.demoPassword);

  /**
   * Provision the company through the same path a real one uses.
   *
   * This used to hand-roll CO_MAST / YEAR_MAST / LOCT_MAST / CO_SET / BOOK_DATA and stop there, which
   * made the demo unable to post its primary transaction: a sale failed with
   * `book SAL account row 1 is missing`, because `resolveBookAccountTx` reads BOOK_DETL for the control
   * account and fails closed rather than inventing one. `seedCompany` already solved exactly that for
   * provisioned companies — the comment at seedCompany.ts:54 records the same bug being found by
   * running the application — so the demo now reuses it instead of keeping a thinner parallel copy that
   * can drift.
   *
   * It is idempotent (each insert is guarded by an existence check) and brings the full book set with
   * BOOK_DETL rows, the standard accounts, tax codes and SRNO_MAST counters.
   */
  await seedCompany(prisma, config.demoTenant, '01', { coName: 'Demo Jeweller', lcCode: '01' });

  await withTxBudget(prisma, config.demoTenant, 'heavy', async (tx) => {
    await tx.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG")
       SELECT $1,'01','admin',$2,'ADMIN' WHERE NOT EXISTS (SELECT 1 FROM "LOGIN_MAST" WHERE "CO_CODE"='01' AND "LOGIN_NAME"='admin')`,
      config.demoTenant,
      pwd,
    );
    // seedCompany opens the fiscal year around today. The demo also keeps 2024-2025 so any data seeded
    // against that year stays reachable from the year selector.
    await tx.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       SELECT $1,'01','2024-2025','2024-04-01','2025-03-31'
        WHERE NOT EXISTS (SELECT 1 FROM "YEAR_MAST" WHERE "CO_CODE"='01' AND "CO_YEAR"='2024-2025')`,
      config.demoTenant,
    );

    // Trading masters, so the demo can actually sell something. Item codes are clipped to the real
    // width: ITEM_MAST.IT_CODE is varchar(5), so 'SILVER' fails with 22001. A sale needs an item whose group
    // carries a SALE_AC (income account) and a party to bill; seedCompany provisions neither, because a
    // real company enters its own. Without these the demo stops at
    // `account not found for tax policy` or an unmapped income account.
    // A desktop item group names both income and expense heads. With only SALE_AC, the demo's first
    // purchase failed with "missing GROUP_MAST.PURC_AC for item GOLD" (PARITY-EVALUATION-2026-09-28 §5b).
    await tx.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       SELECT $1,'01','01','GOLD JEWELLERY','SALES','PURCHASE'
        WHERE NOT EXISTS (SELECT 1 FROM "GROUP_MAST" WHERE "CO_CODE"='01' AND "GR_CODE"='01')`,
      config.demoTenant,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       SELECT $1,'01','GOLD','GOLD ORNAMENT','G','01'
        WHERE NOT EXISTS (SELECT 1 FROM "ITEM_MAST" WHERE "CO_CODE"='01' AND "IT_CODE"='GOLD')`,
      config.demoTenant,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       SELECT $1,'01','SILVR','SILVER ORNAMENT','S','01'
        WHERE NOT EXISTS (SELECT 1 FROM "ITEM_MAST" WHERE "CO_CODE"='01' AND "IT_CODE"='SILVR')`,
      config.demoTenant,
    );
    // A local (intra-state) customer, so GST splits into CGST/SGST as it would in the shop.
    await tx.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       SELECT $1,'01','01','CUST01','DEMO CUSTOMER','L','30'
        WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE "CO_CODE"='01' AND "AC_CODE"='CUST01')`,
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
  // One catalog query now, so no posting or numbering transaction queries information_schema (N53). If the
  // database is not reachable yet, start anyway as before: the first posting then loads the catalog once.
  await warmPostingMetadata(prisma).then(
    (tables) => console.log(`[datacare-api] schema catalog warmed: ${tables} tables`),
    (error) => console.warn('[datacare-api] schema catalog not warmed:', error.message),
  );
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
