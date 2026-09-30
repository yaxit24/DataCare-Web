// Reproduce the createSale TypeError on desktop voucher Next23 026/00002 with a full stack trace.
import { PrismaClient } from '@prisma/client';
const { createSale } = await import('/projects/sandbox/DataCare-Web/web/apps/api/dist/modules/sales/sales.js');
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
const scope = { tenantId: process.env.T || 'eval2-n23', coCode: '01', lcCode: '00', coYear: '2023-2024', coBook: '026' };
const base = { scope, acCode: process.env.AC || '000211', vchDate: new Date('2024-03-15'), interState: false, taxCode: '10', taxRatePct: 3, mainUser: 'probe' };
const variants = {
  twoLinesLabour: [
    { itCode: 'CH916', metal: 'G', pcs: 1, grossWt: 25, netWt: 25, touch: 0, rate: 5800, metalAmount: 145000, labourType: 'F', labourFixed: 12500 },
    { itCode: 'GR916', metal: 'G', pcs: 1, grossWt: 3, netWt: 3, touch: 0, rate: 5800, metalAmount: 17400, labourType: 'F', labourFixed: 1500 },
  ],
  oneLineNoLabour: [{ itCode: 'CH916', metal: 'G', pcs: 1, grossWt: 25, netWt: 25, touch: 0, rate: 5800, metalAmount: 145000 }],
  oneLineLabour: [{ itCode: 'CH916', metal: 'G', pcs: 1, grossWt: 25, netWt: 25, touch: 0, rate: 5800, metalAmount: 145000, labourType: 'F', labourFixed: 12500 }],
};
for (const [name, lines] of Object.entries(variants)) {
  try {
    const out = await createSale(runtime, base, lines);
    console.log(name, 'OK vch', out?.vchNo);
  } catch (e) {
    console.log(name, 'ERR', e?.message);
    console.log(String(e?.stack).split('\n').slice(0, 8).join('\n'));
  }
}
await runtime.$disconnect();
