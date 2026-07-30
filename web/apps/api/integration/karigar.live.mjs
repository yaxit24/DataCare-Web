// Tier-2 live karigar metal flow (Task 24) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/karigar.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  issueKarigar,
  receiveKarigar,
  karigarMetalBalance,
  deleteKarigar,
  KarigarValidationError,
} from '../dist/modules/manufacturing/karigar.js';

const prisma = new PrismaClient();
const T = 'e2e';
const scope = { tenantId: T, coCode: '01', lcCode: '01', coYear: '2024' };
const KAR = 'KARI';
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const named = async (fn) => {
  try {
    await fn();
    return 'NONE';
  } catch (e) {
    return e.name;
  }
};
const cnt = (tx, t, vch) =>
  tx
    .$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "${t}" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(vch),
      '01',
    )
    .then((r) => r[0].n);
const bal = (tx, vch) =>
  tx
    .$queryRawUnsafe(
      `SELECT coalesce(sum("DR_AMT"),0)::float AS dr, coalesce(sum("CR_AMT"),0)::float AS cr FROM "AC_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2`,
      String(vch),
      '01',
    )
    .then((r) => r[0]);

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const t of ['KR_DATA', 'KR_DETL', 'AC_DATA', 'DELETE_DATA', 'SRNO_MAST']) {
      await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE "CO_CODE"=$1`, '01');
    }
  });
}

async function main() {
  await cleanup();

  // validation
  check(
    'no lines -> KarigarValidationError',
    (await named(() =>
      issueKarigar(prisma, { scope: { ...scope, coBook: 'KIS' }, karigarAc: KAR, lines: [] }),
    )) === 'KarigarValidationError',
  );

  // issue 100g @ 92% touch -> 92 fine OUT
  const isu = await issueKarigar(prisma, {
    scope: { ...scope, coBook: 'KIS' },
    karigarAc: KAR,
    karigarName: 'Karigar A',
    lines: [{ itCode: 'I1', netWt: 100, touch: 92 }],
  });
  check('issue fine = 92', isu.fineIssued === 92);
  const [ic, idl] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'KR_DATA', isu.vchNo),
    await cnt(tx, 'KR_DETL', isu.vchNo),
  ]);
  check('issue KR_DATA(1)+KR_DETL(1)', ic === 1 && idl === 1);
  check('balance after issue = 92', (await karigarMetalBalance(prisma, scope, KAR)) === 92);

  // receive 100g @ 90% touch + 2% wastage -> 92 fine IN (fully accounts for the issue), labour 500
  const rec = await receiveKarigar(prisma, {
    scope: { ...scope, coBook: 'KRC' },
    karigarAc: KAR,
    lines: [{ itCode: 'I1', netWt: 100, touch: 90, westPct: 2 }],
    labourAmt: 500,
  });
  check('receive fine (with 2% wastage) = 92', rec.fineReceived === 92);
  const [rc, rb] = await withTenant(prisma, T, async (tx) => [
    await cnt(tx, 'KR_DETL', rec.vchNo),
    await bal(tx, rec.vchNo),
  ]);
  check('receive KR_DETL(1)', rc === 1);
  check('labour AC_DATA balanced (dr=cr=500)', rb.dr === 500 && rb.cr === 500);
  check(
    'balance after receive = 0 (wastage accounts for the gap)',
    (await karigarMetalBalance(prisma, scope, KAR)) === 0,
  );

  // a second issue of 50g @ 80% -> 40 fine; balance 40
  const isu2 = await issueKarigar(prisma, {
    scope: { ...scope, coBook: 'KIS' },
    karigarAc: KAR,
    lines: [{ itCode: 'I2', netWt: 50, touch: 80 }],
  });
  check('balance after 2nd issue = 40', (await karigarMetalBalance(prisma, scope, KAR)) === 40);

  // delete the receipt -> received drops to 0 -> balance = 92 (issue1) + 40 (issue2) = 132
  await deleteKarigar(prisma, {
    scope: { ...scope, coBook: 'KRC' },
    vchNo: rec.vchNo,
    book: 'KRC',
    vchType: 'KREC',
    deleteUser: 'admin',
  });
  const [balAfterDel, del] = await withTenant(prisma, T, async (tx) => [
    await karigarMetalBalance(prisma, scope, KAR),
    await cnt(tx, 'DELETE_DATA', rec.vchNo),
  ]);
  check('after delete receipt, balance = 132', balAfterDel === 132);
  check('wrote DELETE_DATA(>=1)', del >= 1);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nKARIGAR_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('KARIGAR_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
