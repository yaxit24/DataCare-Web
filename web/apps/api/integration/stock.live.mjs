// Tier-2 live tag/stock lifecycle (Task 18) as app_user.
// Run: DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare node apps/api/integration/stock.live.mjs
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  createTag,
  issueTag,
  restoreTag,
  tagAvailable,
  onHand,
  TagNotAvailableError,
  TagExistsError,
} from '../dist/modules/stock/stock.js';

const prisma = new PrismaClient();
const T = 'e2e';
const tag = (n) => ({
  CO_CODE: '01',
  LC_CODE: '01',
  TAG_NO: n,
  ITM_PCS: 1,
  ITM_GWT: 10,
  ITM_NWT: 9.5,
  STK_TYPE: 'R',
});
let pass = 0,
  fail = 0;
const check = (n, c) => {
  c ? (pass++, console.log('  ok  ' + n)) : (fail++, console.log('  FAIL ' + n));
};
const named = async (fn, name) => {
  try {
    await fn();
    return 'NONE';
  } catch (e) {
    return e.name;
  }
};

async function cleanup() {
  await withTenant(prisma, T, (tx) =>
    tx.$executeRawUnsafe(`DELETE FROM "TAG_STOCK" WHERE "CO_CODE"=$1`, '01'),
  );
}

async function main() {
  await cleanup();

  await createTag(prisma, T, tag('T1'));
  check('created T1 -> available', (await tagAvailable(prisma, T, tag('T1'))) === true);

  const dupErr = await named(() => createTag(prisma, T, tag('T1')), 'create-dup');
  check('double-create -> TagExistsError', dupErr === 'TagExistsError');

  await issueTag(prisma, T, tag('T1'));
  check('issued T1 -> unavailable', (await tagAvailable(prisma, T, tag('T1'))) === false);

  const reissue = await named(() => issueTag(prisma, T, tag('T1')), 'reissue');
  check('double-issue -> TagNotAvailableError', reissue === 'TagNotAvailableError');

  await restoreTag(prisma, T, tag('T1'));
  check('restored T1 -> available', (await tagAvailable(prisma, T, tag('T1'))) === true);

  const oh = await onHand(prisma, T, { CO_CODE: '01', LC_CODE: '01' });
  check('on-hand reflects tag (pcs>=1, nwt>=9.5)', oh.pcs >= 1 && oh.nwt >= 9.5);

  // concurrent double-issue: exactly one wins
  await createTag(prisma, T, tag('T2'));
  const results = await Promise.allSettled([
    issueTag(prisma, T, tag('T2')),
    issueTag(prisma, T, tag('T2')),
  ]);
  const ok = results.filter((r) => r.status === 'fulfilled').length;
  const rej = results.filter(
    (r) => r.status === 'rejected' && r.reason?.name === 'TagNotAvailableError',
  ).length;
  check('concurrent issue -> exactly 1 success', ok === 1);
  check('concurrent issue -> exactly 1 rejected', rej === 1);

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nSTOCK_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('STOCK_E2E_PASS');
}
main().catch((e) => {
  console.error(e);
  process.exit(1);
});
