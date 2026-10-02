// Line-level computation parity: for every REAL SL_DETL line, check the desktop's stored values
// satisfy the web engine's formulas — fine = NWT×TOUCH/100, metal = fine×rate, net = metal+labour+other.
// Run: DATABASE_URL=<app_user> node apps/api/integration/line_parity.live.mjs
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';

const prisma = new PrismaClient();
const n = (v) => Number(v ?? 0) || 0;
const r2 = (x) => Math.round((x + 1e-9) * 100) / 100;
const r3 = (x) => Math.round((x + 1e-9) * 1000) / 1000;

const rows = await withTenant(prisma, 'default', (tx) =>
  tx.$queryRawUnsafe(
    `SELECT "ITM_NWT","ITM_TOUCH","ITM_FINE","ITM_RATE","ITM_AMT","LBR_AMT","OTH_AMT","NET_AMT" FROM "SL_DETL" WHERE "CO_CODE"='01'`,
  ),
);

let tot = 0,
  fineOK = 0,
  metalOK = 0,
  netOK = 0,
  hasFine = 0,
  hasMetal = 0;
const samples = [];
for (const r of rows) {
  tot++;
  const nwt = n(r.ITM_NWT),
    touch = n(r.ITM_TOUCH),
    fine = n(r.ITM_FINE),
    rate = n(r.ITM_RATE),
    amt = n(r.ITM_AMT),
    lbr = n(r.LBR_AMT),
    oth = n(r.OTH_AMT),
    net = n(r.NET_AMT);
  if (nwt > 0 && touch > 0) {
    hasFine++;
    if (Math.abs(r3((nwt * touch) / 100) - fine) < 0.01) fineOK++;
  }
  if (fine > 0 && rate > 0) {
    hasMetal++;
    if (Math.abs(r2(fine * rate) - amt) < 0.5) metalOK++;
  }
  if (Math.abs(r2(amt + lbr + oth) - net) < 0.5) netOK++;
  if (samples.length < 4 && net > 0)
    samples.push({ nwt, touch, fine, rate, amt, lbr, net, webNet: r2(amt + lbr + oth) });
}
console.log(`SL_DETL lines = ${tot}`);
console.log(
  `fine = NWT×TOUCH/100 : ${fineOK}/${hasFine} (${hasFine ? Math.round((100 * fineOK) / hasFine) : 0}%)`,
);
console.log(
  `metal = fine×rate     : ${metalOK}/${hasMetal} (${hasMetal ? Math.round((100 * metalOK) / hasMetal) : 0}%)`,
);
console.log(`net = metal+labour+oth: ${netOK}/${tot} (${Math.round((100 * netOK) / tot)}%)`);
console.log('samples: ' + JSON.stringify(samples));
await prisma.$disconnect();
const ok = netOK >= tot * 0.9;
console.log(ok ? 'LINE_PARITY_OK' : 'LINE_PARITY_REVIEW');
