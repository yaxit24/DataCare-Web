// Tier-2 live Sale Return numeric update end-to-end (card X13, steps 8-9).
//
// Run (CI, against the postgres service):
//   DATABASE_URL=postgresql://app_user:app@127.0.0.1:5433/datacare \
//   MIGRATE_DATABASE_URL=postgresql://datacare:datacare@127.0.0.1:5433/datacare \
//   node apps/api/integration/sale-return-update.live.mjs
//
// Follows the sales.live.mjs pattern: it seeds a source sale + saved Return in a DEDICATED
// NON-DEFAULT tenant ('e2e', as project-memory/HANDOFF.md documents) so the demo data and the
// login stay untouched, performs the numeric Return update through the same coordinator the
// strict HTTP endpoint invokes (updateSaleReturnNumeric), and then asserts that:
//   - exactly the NINE expected rows changed (line, header, two account, stock, two Rojmel,
//     two tax), each family observed;
//   - the AC_DATA and ROJ_MEL_DATA trial balances stay tied after the write;
//   - a same-value event is admitted but persists nothing (whole-plan no-op);
//   - a stale document version maps to a 409 version-conflict.
//
// AUTHORED-FOR-CI: this sandbox has NO working PostgreSQL (podman/crun cannot run the postgres
// container; the host port is unreachable), so this file is verified in-sandbox ONLY by
// `node --check` (valid ESM) and the API typecheck. It runs for real in GitHub Actions CI,
// which provides postgres:16-alpine.
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { updateSaleReturnNumeric } from '../dist/modules/sales/saleReturnNumericUpdate.js';
import { getSavedSaleReturnIncoming } from '../dist/modules/sales/savedSaleReturn.js';

// A dedicated non-default tenant keeps the seeded company/year and the login demo data untouched.
const T = 'e2e';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'R11';
const VCH = '00017';
const HD = '00017';
const PARTY = 'CUST';
const SALE = 'SALE';
const ITEM = 'GOLD';
const MAIN_USER = 'x13-e2e-owner';

const scope = { tenantId: T, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const actor = { mainUser: MAIN_USER, auditUser: MAIN_USER, auditTime: '2024-07-10T13:00:00' };

const prisma = new PrismaClient();

let pass = 0;
let fail = 0;
const check = (name, condition) => {
  if (condition) {
    pass += 1;
    console.log('  ok  ' + name);
  } else {
    fail += 1;
    console.log('  FAIL ' + name);
  }
};
const named = async (fn) => {
  try {
    await fn();
    return 'NONE';
  } catch (error) {
    return error;
  }
};

const TABLES = [
  'SL_DATA',
  'SL_DETL_RTN',
  'SL_DETL',
  'SL_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
  'TEMP_BOOK_DATA',
  'BOOK_DATA',
  'BOOK_DETL',
  'ITEM_MAST',
  'GROUP_MAST',
  'AC_MAST',
  'TAX_MAST',
  'EMP_MAST',
  'YEAR_MAST',
  'CO_MAST',
  'CO_SET',
];

const key = (extra = {}) => ({
  tenant_id: T,
  CO_CODE: CO,
  LC_CODE: LC,
  CO_YEAR: YEAR,
  CO_BOOK: BOOK,
  VCH_NO: VCH,
  ...extra,
});

const insert = async (table, values) =>
  withTenant(prisma, T, (tx) => {
    const columns = Object.keys(values)
      .map((column) => `"${column}"`)
      .join(',');
    return tx.$executeRawUnsafe(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  });

async function cleanup() {
  await withTenant(prisma, T, async (tx) => {
    for (const table of TABLES)
      await tx.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, T);
  });
}

async function seedMasters() {
  await insert('CO_MAST', { tenant_id: T, CO_CODE: CO, CO_NAME: 'X13 E2E Co', CO_SNAME: 'IN' });
  await insert('CO_SET', {
    tenant_id: T,
    CO_CODE: CO,
    LOCK_DATE: null,
    EMP_CODE_MANDATORY: 'N',
    CASH_LIMIT: 0,
  });
  await insert('YEAR_MAST', { tenant_id: T, CO_CODE: CO, CO_YEAR: YEAR, OP_DATE: '2024-04-01' });
  await insert('BOOK_DATA', {
    tenant_id: T,
    CO_CODE: CO,
    LC_CODE: LC,
    CO_BOOK: BOOK,
    MAIN_BOOK: 'SALES RETURNE',
    BOOK_NAME: 'Sales Return',
    BOOK_SNAME: 'SR',
    BOOK_TYPE: 'T',
    BOOK_INOUT: 'I',
    CUR_USE: 'Y',
    BOOK_TBL_NAME: 'SL_DATA',
    DATA_TYPE: 'B',
  });
  await insert('BOOK_DETL', {
    tenant_id: T,
    CO_CODE: CO,
    LC_CODE: LC,
    CO_BOOK: BOOK,
    MAIN_BOOK: 'SALES RETURNE',
    BOOK_INOUT: 'I',
    BOOK_TYPE: 'T',
    BOOK_SNAME: 'RT',
    DATA_TYPE: 'C',
    SR_NO: 1,
    AC_CODE: 'BOOKAC',
  });
  await insert('ITEM_MAST', { tenant_id: T, CO_CODE: CO, IT_CODE: ITEM, GR_CODE: 'G1' });
  await insert('GROUP_MAST', { tenant_id: T, CO_CODE: CO, GR_CODE: 'G1', SALE_AC: SALE });
  await insert('AC_MAST', {
    tenant_id: T,
    CO_CODE: CO,
    LC_CODE: LC,
    AC_CODE: PARTY,
    AC_NAME: 'Customer',
    AC_GST_TYPE: 'N',
  });
  for (const [sr, group] of [
    [1, 'C'],
    [2, 'S'],
  ])
    await insert('TAX_MAST', {
      tenant_id: T,
      CO_CODE: CO,
      TAX_CODE: '00',
      SR_NO: sr,
      TAX_GROUP: group,
      TAX_PRC: 0,
    });
  await insert('EMP_MAST', { tenant_id: T, CO_CODE: CO, EMP_CODE: '001', EMP_NAME: 'Emp' });
}

async function seedDocument() {
  await insert(
    'SL_DATA',
    key({
      VCH_DATE: '2024-07-10',
      VCH_TIME: '2024-07-10T12:34:56',
      HD_VCH_NO: HD,
      AC_CODE: PARTY,
      AC_NAME: ' Customer ',
      EMP_CODE: '001',
      VCH_DESC: null,
      MAIN_USER,
      TAX_CODE: '00',
      AC_GST_TYPE: 'N',
      RATE_UNFIX: 'N',
      USER_UPDATE: 'N',
      RTN_NET_AMT: 110,
      RTN_TOT_AMT: 110,
      RTN_BILL_OS: 110,
    }),
  );
  await insert(
    'SL_DETL_RTN',
    key({
      SR_NO: 1,
      OLD_SRNO: 1,
      VCH_DATE: '2024-07-10',
      VCH_TIME: '2024-07-10T12:34:56',
      VCH_TYPE: 'SR',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'P',
      BOOK_NAME: 'SALES RETURN',
      AC_CODE: PARTY,
      IT_CODE: ITEM,
      TAG_NO: 'N',
      TBL_CODE: '001',
      ITM_PCS: '1.000',
      ITM_GWT: '10.000',
      ITM_NWT: '10.000',
      ITM_TOUCH: '100.000',
      ITM_WEST_PRC: '0.0000',
      ITM_FINE: '10.000',
      ITM_RATE: '10.00',
      ITM_AMT: '100.00',
      LBR_TYPE: 'N',
      LBR_RATE: '1.00',
      LBR_AMT: '10.00',
      OTH_AMT: '0.00',
      ITM_MRP: '0.00',
      TOT_AMT: '110.00',
      TAX_PRC: '0.0000',
      NET_AMT: '110.00',
      RATE_TYPE: 'N',
      IT_TYPE: 'G',
      HD_VCH_NO: HD,
      MAIN_USER,
      VCH_SRNO: 123,
      TAG_TYPE: 'A',
      EMP_CODE: '001',
      APR_ISU: 'N',
      EMP_ISU: 'N',
      DATA_TYPE: 'A',
    }),
  );
  // Seven existing financial effect rows: two account, two Rojmel, one stock, two tax.
  await insert(
    'AC_DATA',
    key({
      VCH_TYPE: 'SR',
      VCH_DATE: '2024-07-10',
      LEDR_KEY: '01012024-2025R110001701         1',
      BOOK_NAME: 'SALES RETURNE',
      AC_CODE: PARTY,
      LD_CODE: SALE,
      CR_AMT: '110.00',
      DR_AMT: '0.00',
      IT_TYPE: 'A',
      ENTRY_TIME: '2024-07-10T12:34:56',
      HD_VCH_NO: HD,
      DATA_TYPE: 'B',
      DATA_TRFR: 'N',
      MAIN_USER,
      PARTY_AC_CODE: PARTY,
    }),
  );
  await insert(
    'AC_DATA',
    key({
      VCH_TYPE: 'SR',
      VCH_DATE: '2024-07-10',
      LEDR_KEY: '01012024-2025R110001702         1',
      BOOK_NAME: 'SALES RETURNE',
      AC_CODE: SALE,
      LD_CODE: PARTY,
      CR_AMT: '0.00',
      DR_AMT: '110.00',
      IT_TYPE: 'A',
      ENTRY_TIME: '2024-07-10T12:34:56',
      HD_VCH_NO: HD,
      DATA_TYPE: 'B',
      DATA_TRFR: 'N',
      MAIN_USER,
    }),
  );
  await insert(
    'ROJ_MEL_DATA',
    key({
      LEDR_KEY: '01012024-2025R110001701',
      VCH_DATE: '2024-07-10',
      VCH_TYPE: 'RT',
      BOOK_NAME: 'SALES RETURNE',
      AC_CODE: PARTY,
      LD_CODE: 'BOOKAC',
      CR_AMT: '110.00',
      DR_AMT: '0.00',
      AC_NAME: '',
      IT_TYPE: 'A',
      DATA_TYPE: 'C',
    }),
  );
  await insert(
    'ROJ_MEL_DATA',
    key({
      LEDR_KEY: '01012024-2025R110001702',
      VCH_DATE: '2024-07-10',
      VCH_TYPE: 'RT',
      BOOK_NAME: 'SALES RETURNE',
      AC_CODE: PARTY,
      LD_CODE: 'BOOKAC',
      CR_AMT: '0.00',
      DR_AMT: '110.00',
      AC_NAME: 'RTN -  Customer ',
      IT_TYPE: 'A',
      DATA_TYPE: 'C',
    }),
  );
  await insert(
    'MAIN_STOCK',
    key({
      SR_NO: 2,
      ISR_NO: 1,
      VCH_SRNO: 123,
      VCH_DATE: '2024-07-10',
      STK_DATE: '2024-07-10',
      VCH_TYPE: 'SR',
      BOOK_NAME: 'SALES RETURNE',
      AC_CODE: PARTY,
      IT_CODE: ITEM,
      TAG_NO: 'N',
      TBL_CODE: '001',
      TR_TYPE: 'I',
      ITM_SIGN: '+',
      ITM_QTY: '1.000',
      ITM_PCS: '1.000',
      ITM_GWT: '10.000',
      ITM_NWT: '10.000',
      ITM_TOUCH: '100.000',
      ITM_WEST: '0.000',
      ITM_FINE: '10.000',
      ITM_RATE: '10.00',
      ITM_AMT: '100.00',
      LBR_RATE: '1.00',
      LBR_AMT: '10.00',
      OTH_AMT: '0.00',
      ITM_MRP: '0.00',
      NET_AMT: '110.00',
      EMP_CODE: '001',
      ENTRY_TIME: '2024-07-10',
      MAIN_USER,
      DATA_TYPE: 'A',
      ITM_DISC: '0',
    }),
  );
  for (const [sr, group] of [
    [1, 'C'],
    [2, 'S'],
  ])
    await insert(
      'TAX_DATA',
      key({
        SR_NO: sr,
        BOOK_NAME: 'SALES RETURNE',
        TRAN_TYPE: 'S',
        VCH_DATE: '2024-07-10',
        AC_CODE: PARTY,
        TAX_CODE: '00',
        TAX_TYPE: group,
        TAX_PRC: '0.0000',
        NET_AMT: '110.00',
        TAX_AMT: '0.000',
        DISC_AMT: '0.00',
        TOT_AMT: '110.00',
        TAX_SIGN: '-',
        PARTY_NAME: ' Customer ',
        R_CHARG: 'N',
        ISR_NO: 0,
        ZERO_RATED_AMT: '0',
      }),
    );
  // Both N BAR companions (header + parent).
  await insert(
    'BAR_DATA',
    key({
      VCH_DATE: '2024-07-10',
      VCH_TIME: '2024-07-10T12:34:56',
      EMP_CODE: '001',
      VCH_DESC: '',
      MAIN_USER,
      STK_IT_CODE: '',
      DATA_TRFR: 'N',
    }),
  );
  await insert(
    'BAR_DETL',
    key({
      VCH_DATE: '2024-07-10',
      VCH_TIME: '2024-07-10T12:34:56',
      STK_DATE: '2024-07-10',
      HD_VCH_NO: HD,
      AC_CODE: PARTY,
      VCH_TYPE: 'SR',
      INOUT_TYPE: 'I',
      BOOK_NAME: 'SALES RETURNE',
      MAIN_USER,
      ENTRY_TYPE: 'P',
      DATA_TRFR: 'N',
      SR_NO: 1,
      OLD_SRNO: 1,
      IT_CODE: ITEM,
      TAG_NO: 'N',
      VCH_SRNO: 123,
      ITM_NWT: '10.000',
      ITM_FINE: '10.000',
      DATA_TYPE: 'A',
    }),
  );
  await insert('TEMP_BOOK_DATA', {
    tenant_id: T,
    CO_CODE: CO,
    LC_CODE: LC,
    CO_BOOK: BOOK,
    VCH_NO: HD,
    BOOK_NAME: 'SALES RETURNE',
  });
}

const ledgerBalanced = async (table) => {
  const [sums] = await prisma.$queryRawUnsafe(
    `SELECT SUM("CR_AMT")::text cr, SUM("DR_AMT")::text dr FROM "${table}" t
       WHERE tenant_id=$1 AND t."VCH_NO"=$2`,
    T,
    VCH,
  );
  return Number(sums?.cr ?? 0) === Number(sums?.dr ?? 0);
};

async function main() {
  await cleanup();
  await seedMasters();
  await seedDocument();

  // Read the fresh saved version exactly as the HTTP endpoint does before a write.
  const saved = await getSavedSaleReturnIncoming(prisma, scope, VCH);

  // Perform the numeric Return update through the coordinator the strict endpoint invokes.
  const result = await updateSaleReturnNumeric(prisma, scope, VCH, {
    version: saved.version,
    otherAmount: '1',
    actor,
  });
  check('committed the numeric update', result.committed === true);
  check('the update is not a no-op', result.noOp === false);

  const changedFamilies = new Set(result.changes.map((c) => `${c.table}:${c.column}`));
  const expectedFamilies = new Set([
    'SL_DETL_RTN:OTH_AMT',
    'SL_DETL_RTN:TOT_AMT',
    'SL_DETL_RTN:NET_AMT',
    'SL_DATA:RTN_NET_AMT',
    'SL_DATA:RTN_TOT_AMT',
    'SL_DATA:RTN_BILL_OS',
    'AC_DATA:CR_AMT',
    'AC_DATA:DR_AMT',
    'MAIN_STOCK:OTH_AMT',
    'MAIN_STOCK:NET_AMT',
    'ROJ_MEL_DATA:CR_AMT',
    'ROJ_MEL_DATA:DR_AMT',
    'TAX_DATA:NET_AMT',
    'TAX_DATA:TOT_AMT',
  ]);
  check(
    'exactly the expected changed columns',
    changedFamilies.size === expectedFamilies.size &&
      [...expectedFamilies].every((entry) => changedFamilies.has(entry)),
  );
  check(
    'nine distinct physical rows changed',
    new Set(result.changes.map((c) => `${c.table}:${c.physicalIdentity}`)).size === 9,
  );

  const [header] = await prisma.$queryRawUnsafe(
    `SELECT "RTN_NET_AMT"::text n,"RTN_TOT_AMT"::text t,"RTN_BILL_OS"::text o FROM "SL_DATA" t
       WHERE tenant_id=$1 AND t."VCH_NO"=$2`,
    T,
    VCH,
  );
  check('header persisted the whole-unit 111', header?.n === '111' && header?.t === '111' && header?.o === '111');

  // Trial balance still balances after the write.
  check('AC_DATA trial balance tied', await ledgerBalanced('AC_DATA'));
  check('ROJ_MEL_DATA trial balance tied', await ledgerBalanced('ROJ_MEL_DATA'));

  // A same-value event is admitted but persists nothing.
  const afterFirst = await getSavedSaleReturnIncoming(prisma, scope, VCH);
  const noop = await updateSaleReturnNumeric(prisma, scope, VCH, {
    version: afterFirst.version,
    otherAmount: '0',
    actor,
  });
  check('same-value event is a no-op', noop.committed === true && noop.noOp === true && noop.changes.length === 0);

  // A stale document version maps to a 409 version-conflict.
  const staleError = await named(() =>
    updateSaleReturnNumeric(prisma, scope, VCH, { version: saved.version, otherAmount: '2', actor }),
  );
  check(
    'stale version -> 409 version-conflict',
    staleError !== 'NONE' && staleError.statusCode === 409 && staleError.code === 'version-conflict',
  );

  await cleanup();
  await prisma.$disconnect();
  console.log(`\nSALE_RETURN_UPDATE_E2E pass=${pass} fail=${fail}`);
  if (fail > 0) process.exit(1);
  console.log('SALE_RETURN_UPDATE_E2E_PASS');
}

main().catch((error) => {
  console.error(error);
  process.exit(1);
});
