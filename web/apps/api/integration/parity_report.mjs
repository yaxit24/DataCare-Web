// PARITY HARNESS (Phase 0) — report gating tool.
// Validates each web report's headline totals against a direct SQL aggregation of the SAME
// imported desktop data (tenant 'default'). Diff must be ~0 to pass the phase gate.
// Run: node apps/api/integration/parity_report.mjs   (API must be up on :3000)
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';

const prisma = new PrismaClient();
const BASE = process.env.BASE || 'http://localhost:4000';
const NN = (c) => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;
let jar = '';
async function login() {
  const r = await fetch(`${BASE}/auth/login`, {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify({ coCode: '01', loginName: 'admin', password: 'Secret#1' }),
  });
  jar = (r.headers.get('set-cookie') || '').split(';')[0];
}
const api = async (path) => (await fetch(`${BASE}${path}`, { headers: { cookie: jar } })).json();
const sql1 = (q) =>
  withTenant(prisma, 'default', async (tx) => Number((await tx.$queryRawUnsafe(q))[0].v));
const near = (a, b, tol = 1) => Math.abs(Number(a) - Number(b)) <= tol;

// each check: report endpoint value vs direct-SQL expected
const CHECKS = [
  {
    name: 'sales-register total',
    got: async () => (await api('/reports/sales-register?coYear=2024')).totals.totAmt,
    exp: () =>
      sql1(
        `SELECT ${NN('sum(' + NN('"TOT_AMT"') + ')')} v FROM "SL_DATA" WHERE "CO_CODE"='01' AND "CO_YEAR"='2024' AND "CO_BOOK" NOT LIKE '%RT%'`,
      ),
  },
  {
    name: 'purchase-register total',
    got: async () => (await api('/reports/purchase-register?coYear=2024')).totals.totAmt,
    exp: () =>
      sql1(
        `SELECT ${NN('sum(' + NN('"TOT_AMT"') + ')')} v FROM "PR_DATA" WHERE "CO_CODE"='01' AND "CO_YEAR"='2024'`,
      ),
  },
  {
    name: 'stock-valuation netWt',
    got: async () => (await api('/reports/stock-valuation?coYear=2024')).totals.nwt,
    exp: () =>
      sql1(
        `SELECT round(${NN('sum(' + NN('"ITM_NWT"') + ')')},3) v FROM "BAR_DETL" b WHERE "CO_CODE"='01' AND NOT EXISTS (SELECT 1 FROM "MAIN_STOCK" m WHERE m."CO_CODE"::text=b."CO_CODE"::text AND m."TAG_NO"::text=b."TAG_NO"::text AND m."ITM_SIGN"::text='-')`,
      ),
  },
  {
    name: 'account-balances count',
    got: async () => (await api('/reports/account-balances?coYear=2024')).rows.length,
    exp: () => sql1(`SELECT count(DISTINCT "AC_CODE")::int v FROM "AC_DATA" WHERE "CO_CODE"='01'`),
  },
  {
    name: 'day-book entries',
    got: async () => (await api('/reports/day-book?coYear=2024')).rows.length,
    exp: () =>
      sql1(`SELECT count(*)::int v FROM "AC_DATA" WHERE "CO_CODE"='01' AND "CO_YEAR"='2024'`),
  },
];

await login();
let pass = 0,
  fail = 0;
for (const c of CHECKS) {
  try {
    const g = await c.got();
    const e = await c.exp();
    const ok = near(g, e, Math.max(1, Math.abs(e) * 0.001));
    console.log(`${ok ? 'PASS' : 'FAIL'}  ${c.name}: web=${g} sql=${e}`);
    ok ? pass++ : fail++;
  } catch (err) {
    console.log(`ERR   ${c.name}: ${String(err.message).slice(0, 80)}`);
    fail++;
  }
}
console.log(`\nREPORTS: ${pass} pass / ${fail} fail`);
console.log(fail === 0 ? 'REPORT_PARITY_OK' : 'REPORT_PARITY_REVIEW');
await prisma.$disconnect();
