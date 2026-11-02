import { PrismaClient } from '@datacare/db';
import { afterAll, afterEach, beforeEach, describe, expect, it } from 'vitest';
import { deleteTagCancel, saveTagCancel } from '../src/modules/stock/tagCancel.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

/**
 * Tag Cancel T14 fault matrix.
 *
 * The desktop save writes the register, detail, component and stock rows as one operation
 * (TR_TAG_CAN.cs:4950-5290); delete writes its audit and removes that complete set
 * (:5331-5362). The web strengthens that desktop result by wrapping every stage in one
 * transaction. Each trigger below fails only this fixture tenant and is removed in finally.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-cancel-fault-matrix';
const FOREIGN_TENANT = 'tag-cancel-fault-foreign';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-06-10';
const BOOK = 'TGC';
const RICH_TAG = 'TCF-RICH';
const WEB_TAG = 'TCF-WEB';
const RICH_SRNO = 880000001;
const WEB_SRNO = 880000002;
const FN = 'tc_fault_matrix_fault';
const TRIGGER = 'tc_fault_matrix_fault';
const D = (value: string) => new Date(`${value}T00:00:00.000Z`);

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const TABLES = [
  'TAG_STOCK',
  'TEMP_BOOK_DATA',
  'BAR_CAN_DATA',
  'BAR_CAN_DETL',
  'BAR_CAN_IDTL',
  'MAIN_STOCK',
  'DM_DATA',
  'DELETE_DATA',
] as const;
type FaultTable = (typeof TABLES)[number];
type FaultStage = {
  name: string;
  table: FaultTable;
  operation: 'INSERT' | 'DELETE';
  column?: string;
  value?: string;
};

const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
const query = <T>(sql: string, ...params: unknown[]) =>
  owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
const insert = async (table: string, row: Record<string, unknown>, tenantId = TENANT) => {
  const columns = Object.keys(row);
  await exec(
    `INSERT INTO "${table}"(tenant_id,${columns.map((column) => `"${column}"`).join(',')})
     VALUES ($1,${columns.map((_, index) => `$${index + 2}`).join(',')})`,
    tenantId,
    ...columns.map((column) => row[column]),
  );
};
const scope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};
const createInput = (description = 'FAULT MATRIX') => ({
  scope,
  vchDate: DAY,
  vchDesc: description,
  mainUser: 'fault-user',
  lines: [
    { tagNo: RICH_TAG, vchSrno: RICH_SRNO },
    { tagNo: WEB_TAG, vchSrno: WEB_SRNO, itCode: 'RNG' },
  ],
});
const editInput = () => ({
  ...createInput('FAULT MATRIX EDITED'),
  lines: [
    { tagNo: RICH_TAG, vchSrno: RICH_SRNO, oldSrNo: 1 },
    { tagNo: WEB_TAG, vchSrno: WEB_SRNO, itCode: 'RNG', oldSrNo: 2 },
  ],
});

async function wipe(): Promise<void> {
  const tables = await query<Array<{ table_name: string }>>(
    `SELECT DISTINCT table_name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id'`,
  );
  for (const { table_name } of tables) {
    await exec(`DELETE FROM "${table_name}" WHERE tenant_id = ANY($1::text[])`, [
      TENANT,
      FOREIGN_TENANT,
    ]);
  }
}

async function seed(): Promise<void> {
  await insert('CO_SET', { CO_CODE: CO });
  await insert('YEAR_MAST', {
    CO_CODE: CO,
    CO_YEAR: YEAR,
    OP_DATE: D('2024-04-01'),
    CL_DATE: D('2025-03-31'),
  });
  await insert('BOOK_DATA', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_BOOK: BOOK,
    BOOK_NAME: 'Tag Cancel',
    BOOK_SNAME: 'TGCAN',
    MAIN_BOOK: 'TAG CANCEL',
    BOOK_INOUT: 'O',
    CUR_USE: 'Y',
    BOOK_TBL_NAME: 'BAR_CAN_DATA',
  });
  await insert('ITEM_MAST', {
    CO_CODE: CO,
    IT_CODE: 'RNG',
    IT_NAME: 'FAULT RING',
    IT_TYPE: 'G',
    PR_CODE: 'RG',
    RATE_TYPE: 'G',
    OTH_DETL_POSTING: 'N',
  });
  await insert('ITEM_MAST', {
    CO_CODE: CO,
    IT_CODE: 'DIA',
    IT_NAME: 'FAULT DIAMOND',
    IT_TYPE: 'D',
    PR_CODE: 'DM',
    RATE_TYPE: 'W',
    OTH_DETL_POSTING: 'Y',
  });
  await insert('BAR_DETL', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_YEAR: YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: '09001',
    SR_NO: 1,
    OLD_SRNO: 1,
    VCH_DATE: D(DAY),
    BOOK_NAME: 'TAG OPENING',
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    TAG_NO: RICH_TAG,
    VCH_SRNO: RICH_SRNO,
    IT_CODE: 'RNG',
    ITM_PCS: 1,
    ITM_GWT: 10.5,
    ITM_NWT: 10,
    ITM_TOUCH: 91.6,
    ITM_FINE: 9.16,
    KR_NET_WT: 10,
    KR_TOUCH: 91.6,
    KR_FINE: 9.16,
    TBL_CODE: '001',
    PR_CODE: 'RG',
    IT_TYPE: 'G',
    EMP_ISU: 'N',
  });
  await insert('BAR_IDTL', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_YEAR: YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: '09001',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D(DAY),
    BOOK_NAME: 'TAG OPENING',
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    TAG_NO: RICH_TAG,
    VCH_SRNO: RICH_SRNO,
    IT_CODE: 'DIA',
    IT_TYPE: 'D',
    IT_PCS: 2,
    IT_GWT: 0.4,
    KR_WT: 0.4,
    IT_CON_PRC: 0,
    IT_CON_WT: 0.4,
    IT_RATE_TYPE: 'W',
    IT_RATE: 100,
    IT_AMT: 40,
    IT_LBR_RATE: 0,
    IT_LBR_AMT: 0,
    IT_NET_AMT: 40,
    KR_CON_WT: 0.4,
  });
  await insert('MAIN_STOCK', {
    CO_CODE: CO,
    LC_CODE: LC,
    CO_YEAR: YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: '09001',
    SR_NO: 1,
    ISR_NO: 1,
    VCH_DATE: D(DAY),
    IT_CODE: 'RNG',
    TAG_NO: RICH_TAG,
    VCH_SRNO: RICH_SRNO,
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: 1,
    ITM_PCS: 1,
    ITM_GWT: 10.5,
    ITM_NWT: 10,
    ITM_FINE: 9.16,
  });
  await insert('TAG_STOCK', {
    CO_CODE: CO,
    LC_CODE: LC,
    TAG_NO: WEB_TAG,
    VCH_SRNO: WEB_SRNO,
    IT_TYPE: 'G',
    DESIGN_NO: 'WEB-DESIGN',
    ITM_SIZE: '8',
    ITM_PCS: 1,
    ITM_GWT: 5.2,
    ITM_NWT: 5,
    ITM_MRP: 25000,
    STK_TYPE: 'R',
  });
  // Same-tenant company/location and foreign-tenant sentinels are outside the voucher scope.
  for (const [tenantId, coCode, lcCode, tagNo] of [
    [TENANT, '99', '99', 'TCF-SCOPE'],
    [FOREIGN_TENANT, CO, LC, 'TCF-FOREIGN'],
  ]) {
    await insert(
      'MAIN_STOCK',
      {
        CO_CODE: coCode,
        LC_CODE: lcCode,
        CO_YEAR: YEAR,
        CO_BOOK: 'SNT',
        VCH_NO: '99999',
        SR_NO: 1,
        ISR_NO: 1,
        VCH_DATE: D(DAY),
        IT_CODE: 'RNG',
        TAG_NO: tagNo,
        VCH_SRNO: 999,
        TR_TYPE: 'P',
        ITM_SIGN: '+',
        ITM_QTY: 1,
        ITM_PCS: 1,
        ITM_GWT: 1,
        ITM_NWT: 1,
      },
      tenantId,
    );
  }
}

const sourceRows = () =>
  query<Array<{ table_name: string; row: unknown }>>(
    `SELECT 'BAR_DETL' table_name,to_jsonb(b) row FROM "BAR_DETL" b
       WHERE tenant_id=$1 AND "TAG_NO"=$2
     UNION ALL
     SELECT 'BAR_IDTL',to_jsonb(i) FROM "BAR_IDTL" i
       WHERE tenant_id=$1 AND "TAG_NO"=$2
     UNION ALL
     SELECT 'TAG_STOCK',to_jsonb(s) FROM "TAG_STOCK" s
       WHERE tenant_id=$1 AND "TAG_NO"=$3
     ORDER BY table_name`,
    TENANT,
    RICH_TAG,
    WEB_TAG,
  );
const sentinels = () =>
  query<Array<{ tenant_id: string; co: string; lc: string; tag: string; sign: string }>>(
    `SELECT tenant_id,"CO_CODE" co,"LC_CODE" lc,"TAG_NO" tag,"ITM_SIGN" sign
       FROM "MAIN_STOCK" WHERE (tenant_id=$1 AND "TAG_NO"='TCF-SCOPE')
          OR (tenant_id=$2 AND "TAG_NO"='TCF-FOREIGN') ORDER BY tenant_id`,
    TENANT,
    FOREIGN_TENANT,
  );

const sqlLiteral = (value: string) => `'${value.replaceAll("'", "''")}'`;
async function clearFaults(): Promise<void> {
  for (const table of TABLES) await exec(`DROP TRIGGER IF EXISTS "${TRIGGER}" ON "${table}"`);
  await exec(`DROP FUNCTION IF EXISTS "${FN}"()`);
}
async function installFault(stage: FaultStage): Promise<void> {
  await exec(`CREATE FUNCTION "${FN}"() RETURNS trigger LANGUAGE plpgsql AS $fault$
    DECLARE payload jsonb;
    BEGIN
      payload := CASE WHEN TG_OP='DELETE' THEN to_jsonb(OLD) ELSE to_jsonb(NEW) END;
      IF payload->>'tenant_id'=${sqlLiteral(TENANT)}
         AND (TG_ARGV[0]='' OR payload->>TG_ARGV[0]=TG_ARGV[1]) THEN
        RAISE EXCEPTION 'tag cancel injected fault: %', TG_ARGV[2];
      END IF;
      IF TG_OP='DELETE' THEN RETURN OLD; END IF;
      RETURN NEW;
    END $fault$`);
  await exec(
    `CREATE TRIGGER "${TRIGGER}" AFTER ${stage.operation} ON "${stage.table}"
       FOR EACH ROW EXECUTE FUNCTION "${FN}"(${sqlLiteral(stage.column ?? '')},${sqlLiteral(stage.value ?? '')},${sqlLiteral(stage.name)})`,
  );
}

async function expectRollback(stage: FaultStage, operation: () => Promise<unknown>): Promise<void> {
  const before = await snapshotTenant(owner, TENANT);
  const sourcesBefore = await sourceRows();
  const sentinelsBefore = await sentinels();
  await installFault(stage);
  try {
    await expect(operation()).rejects.toThrow(/tag cancel injected fault/);
  } finally {
    await clearFaults();
  }
  expect(diffTenant(before, await snapshotTenant(owner, TENANT)), stage.name).toEqual({
    added: {},
    removed: {},
  });
  expect(await sourceRows(), `${stage.name}: complete source rows`).toEqual(sourcesBefore);
  expect(await sentinels(), `${stage.name}: scope and tenant sentinels`).toEqual(sentinelsBefore);
}

const CREATE_STAGES: FaultStage[] = [
  { name: 'source TAG_STOCK delete', table: 'TAG_STOCK', operation: 'DELETE' },
  { name: 'TEMP_BOOK_DATA insert', table: 'TEMP_BOOK_DATA', operation: 'INSERT' },
  { name: 'BAR_CAN_DATA insert', table: 'BAR_CAN_DATA', operation: 'INSERT' },
  {
    name: 'first BAR_CAN_DETL insert',
    table: 'BAR_CAN_DETL',
    operation: 'INSERT',
    column: 'SR_NO',
    value: '1',
  },
  {
    name: 'second BAR_CAN_DETL insert',
    table: 'BAR_CAN_DETL',
    operation: 'INSERT',
    column: 'SR_NO',
    value: '2',
  },
  { name: 'BAR_CAN_IDTL insert with component', table: 'BAR_CAN_IDTL', operation: 'INSERT' },
  {
    name: 'MAIN_STOCK insert',
    table: 'MAIN_STOCK',
    operation: 'INSERT',
    column: 'CO_BOOK',
    value: BOOK,
  },
  { name: 'DM_DATA insert for OTH_DETL_POSTING', table: 'DM_DATA', operation: 'INSERT' },
];
const EDIT_STAGES: FaultStage[] = [
  { name: 'edit delete BAR_CAN_IDTL', table: 'BAR_CAN_IDTL', operation: 'DELETE' },
  {
    name: 'edit delete second BAR_CAN_DETL',
    table: 'BAR_CAN_DETL',
    operation: 'DELETE',
    column: 'SR_NO',
    value: '2',
  },
  { name: 'edit delete BAR_CAN_DATA', table: 'BAR_CAN_DATA', operation: 'DELETE' },
  { name: 'edit delete DM_DATA', table: 'DM_DATA', operation: 'DELETE' },
  {
    name: 'edit delete MAIN_STOCK',
    table: 'MAIN_STOCK',
    operation: 'DELETE',
    column: 'CO_BOOK',
    value: BOOK,
  },
  { name: 'edit delete TEMP_BOOK_DATA', table: 'TEMP_BOOK_DATA', operation: 'DELETE' },
  { name: 'edit source TAG_STOCK restore', table: 'TAG_STOCK', operation: 'INSERT' },
  {
    name: 'edit source TAG_STOCK re-consume',
    table: 'TAG_STOCK',
    operation: 'DELETE',
    column: 'TAG_NO',
    value: WEB_TAG,
  },
  { name: 'edit rebuild TEMP_BOOK_DATA', table: 'TEMP_BOOK_DATA', operation: 'INSERT' },
  { name: 'edit rebuild BAR_CAN_DATA', table: 'BAR_CAN_DATA', operation: 'INSERT' },
  {
    name: 'edit rebuild second BAR_CAN_DETL',
    table: 'BAR_CAN_DETL',
    operation: 'INSERT',
    column: 'SR_NO',
    value: '2',
  },
  { name: 'edit rebuild BAR_CAN_IDTL', table: 'BAR_CAN_IDTL', operation: 'INSERT' },
  {
    name: 'edit rebuild MAIN_STOCK',
    table: 'MAIN_STOCK',
    operation: 'INSERT',
    column: 'CO_BOOK',
    value: BOOK,
  },
  { name: 'edit rebuild DM_DATA', table: 'DM_DATA', operation: 'INSERT' },
];
const DELETE_STAGES: FaultStage[] = [
  {
    name: 'delete second DELETE_DATA audit',
    table: 'DELETE_DATA',
    operation: 'INSERT',
    column: 'SR_NO',
    value: '2',
  },
  { name: 'delete BAR_CAN_IDTL register component', table: 'BAR_CAN_IDTL', operation: 'DELETE' },
  {
    name: 'delete second BAR_CAN_DETL detail',
    table: 'BAR_CAN_DETL',
    operation: 'DELETE',
    column: 'SR_NO',
    value: '2',
  },
  { name: 'delete BAR_CAN_DATA register', table: 'BAR_CAN_DATA', operation: 'DELETE' },
  { name: 'delete DM_DATA', table: 'DM_DATA', operation: 'DELETE' },
  {
    name: 'delete MAIN_STOCK',
    table: 'MAIN_STOCK',
    operation: 'DELETE',
    column: 'CO_BOOK',
    value: BOOK,
  },
  { name: 'delete TEMP_BOOK_DATA', table: 'TEMP_BOOK_DATA', operation: 'DELETE' },
  { name: 'delete source TAG_STOCK restore', table: 'TAG_STOCK', operation: 'INSERT' },
];

const databaseDescribe = RUN ? describe : describe.skip;
databaseDescribe('Tag Cancel T14 transaction fault matrix', () => {
  beforeEach(async () => {
    await clearFaults();
    await wipe();
    await seed();
  });
  afterEach(clearFaults);
  afterAll(async () => {
    await clearFaults();
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it.each(CREATE_STAGES)('create rolls back after $name and retries on 00001', async (stage) => {
    await expectRollback(stage, () => saveTagCancel(runtime, 'cancel', createInput()));
    const retried = await saveTagCancel(runtime, 'cancel', createInput());
    expect(retried).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      lines: 2,
      stones: 1,
      stockRows: 2,
      diamondRows: 1,
    });
  });

  it.each(EDIT_STAGES)(
    'edit rolls back after $name and retries without renumbering',
    async (stage) => {
      const created = await saveTagCancel(runtime, 'cancel', createInput());
      expect(created).toMatchObject({ voucherNo: '00001', hiddenVoucherNo: '00001' });
      await expectRollback(stage, () => saveTagCancel(runtime, 'cancel', editInput(), '00001'));
      const retried = await saveTagCancel(runtime, 'cancel', editInput(), '00001');
      expect(retried).toMatchObject({ voucherNo: '00001', hiddenVoucherNo: '00001', lines: 2 });
      expect(
        await query(`SELECT "VCH_NO" FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, TENANT),
      ).toEqual([{ VCH_NO: '00001' }]);
    },
  );

  it.each(DELETE_STAGES)('delete rolls back after $name and then succeeds', async (stage) => {
    await saveTagCancel(runtime, 'cancel', createInput());
    await expectRollback(stage, () =>
      deleteTagCancel(runtime, 'cancel', scope, '00001', 'fault-user'),
    );
    await expect(
      deleteTagCancel(runtime, 'cancel', scope, '00001', 'fault-user'),
    ).resolves.toMatchObject({
      reversed: true,
      vchNo: 1,
      lines: 2,
      restoredTags: 1,
    });
    expect(await sourceRows()).toHaveLength(3);
    expect(
      await query(`SELECT 1 FROM "BAR_CAN_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`, TENANT, BOOK),
    ).toEqual([]);
  });
});
