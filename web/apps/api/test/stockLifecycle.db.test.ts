import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import {
  deleteItemLot,
  deleteItemOpening,
  deleteTagOpening,
  editItemLot,
  editItemOpening,
  editTagOpening,
  getItemLot,
  getItemOpening,
  getTagOpening,
  itemLot,
  itemOpening,
  StockVoucherValidationError,
  tagOpening,
} from '../src/modules/stock/stock.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'stock-lifecycle-db';
const CO = '91';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const NEXT_DAY = '2024-04-11';
const MAIN_USER = 'stock-user';

type Family = 'tag-opening' | 'item-opening' | 'item-lot';
type FamilyCase = {
  family: Family;
  book: string;
  configuredName: string;
  configuredType: string;
  detailTable: string;
  create: (runtime: PrismaClient, scope: VoucherScope) => Promise<{ vchNo: number }>;
  get: (runtime: PrismaClient, scope: VoucherScope, voucherNo: string) => Promise<any>;
  edit: (
    runtime: PrismaClient,
    scope: VoucherScope,
    voucherNo: string,
    date?: string,
  ) => Promise<unknown>;
  remove: (runtime: PrismaClient, scope: VoucherScope, voucherNo: string) => Promise<unknown>;
  expectedEditedItem: string;
  seedConsumption: (
    owner: PrismaClient,
    scope: VoucherScope,
    voucherNo: string,
    view: any,
  ) => Promise<void>;
  expectedDeleteRows: number;
};

const cases: FamilyCase[] = [
  {
    family: 'tag-opening',
    book: 'TOP',
    configuredName: 'Configured Tag Opening',
    configuredType: 'TGOP',
    detailTable: 'BAR_DETL',
    create: (runtime, scope) =>
      tagOpening(runtime, {
        scope,
        mainUser: MAIN_USER,
        vchDate: DAY,
        lines: [
          {
            tagNo: 'OPEN-TAG-1',
            itCode: 'GOLD1',
            pcs: 1,
            grossWt: 10,
            netWt: 10,
            touch: 90,
            rate: 500,
            tblCode: '001',
          },
        ],
      }),
    get: getTagOpening,
    edit: (runtime, scope, voucherNo, date = NEXT_DAY) =>
      editTagOpening(
        runtime,
        {
          scope,
          mainUser: 'ignored-editor',
          vchDate: date,
          lines: [
            {
              tagNo: 'OPEN-TAG-1',
              vchSrno: 999,
              itCode: 'GOLD2',
              pcs: 2,
              grossWt: 12,
              netWt: 11,
              touch: 92,
              rate: 600,
              tblCode: '002',
            },
          ],
        },
        voucherNo,
      ),
    remove: (runtime, scope, voucherNo) =>
      deleteTagOpening(runtime, { scope, vchNo: voucherNo, deleteUser: 'deleter' }),
    expectedEditedItem: 'GOLD2',
    seedConsumption: async (owner, scope, _voucherNo, view) => {
      const line = view.lines[0]!;
      await owner.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(
           tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
         VALUES ($1,$2,$3,$4,'SAL','90001',1,'2024-05-01'::date,$5,$6,$7,'-',2,12,11,10.12)`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        line.itCode,
        line.tagNo,
        line.vchSrno,
      );
    },
    expectedDeleteRows: 1,
  },
  {
    family: 'item-opening',
    book: 'IOP',
    configuredName: 'Configured Item Opening',
    configuredType: 'IOPN',
    detailTable: 'ITM_OPBL',
    create: (runtime, scope) =>
      itemOpening(runtime, {
        scope,
        mainUser: MAIN_USER,
        vchDate: DAY,
        lines: [{ itCode: 'GOLD1', pcs: 2, grossWt: 20, netWt: 20, touch: 90, rate: 500 }],
      }),
    get: getItemOpening,
    edit: (runtime, scope, voucherNo, date = NEXT_DAY) =>
      editItemOpening(
        runtime,
        {
          scope,
          mainUser: 'ignored-editor',
          vchDate: date,
          lines: [{ itCode: 'GOLD2', pcs: 3, grossWt: 24, netWt: 22, touch: 92, rate: 600 }],
        },
        voucherNo,
      ),
    remove: (runtime, scope, voucherNo) =>
      deleteItemOpening(runtime, { scope, vchNo: voucherNo, deleteUser: 'deleter' }),
    expectedEditedItem: 'GOLD2',
    seedConsumption: async (owner, scope) => {
      await owner.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(
           tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
         VALUES ($1,$2,$3,$4,'SAL','90002',1,'2024-05-01'::date,'GOLD2','N','-',4,25,23,21.16)`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
      );
    },
    expectedDeleteRows: 0,
  },
  {
    family: 'item-lot',
    book: 'ILT',
    configuredName: 'Configured Item Lot',
    configuredType: 'ILOT',
    detailTable: 'ITM_LOT_DETL',
    create: (runtime, scope) =>
      itemLot(runtime, {
        scope,
        mainUser: MAIN_USER,
        vchDate: DAY,
        acCode: 'PARTY1',
        lines: [
          {
            itCode: 'GOLD1',
            lotNo: 'LOT-ONE',
            pcs: 2,
            grossWt: 20,
            netWt: 20,
            touch: 90,
            rate: 500,
            making: 10,
          },
        ],
      }),
    get: getItemLot,
    edit: (runtime, scope, voucherNo, date = NEXT_DAY) =>
      editItemLot(
        runtime,
        {
          scope,
          mainUser: 'ignored-editor',
          vchDate: date,
          acCode: 'PARTY2',
          lines: [
            {
              itCode: 'GOLD2',
              lotNo: 'LOT-TWO',
              itType: 'S' as const,
              pcs: 3,
              grossWt: 24,
              netWt: 22,
              touch: 92,
              rate: 600,
              making: 12,
            },
          ],
        },
        voucherNo,
      ),
    remove: (runtime, scope, voucherNo) =>
      deleteItemLot(runtime, { scope, vchNo: voucherNo, deleteUser: 'deleter' }),
    expectedEditedItem: 'GOLD2',
    seedConsumption: async (owner, scope) => {
      await owner.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(
           tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "IT_CODE","TAG_NO","ITM_LOT","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
         VALUES ($1,$2,$3,$4,'SAL','90003',1,'2024-05-01'::date,'GOLD2','N','LOT-TWO','-',4,25,23,21.16),
                ($1,$2,$3,$4,'ADJ','90004',1,'2024-05-01'::date,'GOLD2','N','LOT-OTHER','+',100,100,100,92)`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
      );
    },
    expectedDeleteRows: 0,
  },
];

databaseDescribe('database-backed tag/stock voucher lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'BAR_IDTL',
      'BAR_DETL',
      'ITM_LOT_DETL',
      'ITM_OPBL',
      'MAIN_STOCK',
      'BAR_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'ITEM_MAST',
      'BOOK_DATA',
      'YEAR_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
      TENANT,
      CO,
      YEAR,
    );
    for (const row of cases) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(
           tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
           "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
         VALUES ($1,$2,$3,$4,$5,$6,$7,'I','Y','BAR_DATA')`,
        TENANT,
        CO,
        LC,
        row.book,
        row.configuredName,
        row.configuredType,
        row.family.toUpperCase(),
      );
      // Hidden numbering must be independent from main numbering and scoped without fiscal year.
      await owner.$executeRawUnsafe(
        `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
         VALUES ($1,$2,$3,$4,'00007','historic hidden seed')`,
        TENANT,
        CO,
        LC,
        row.book,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES
       ($1,$2,'GOLD1','Gold One','G'),($1,$2,'GOLD2','Gold Two','G')`,
      TENANT,
      CO,
    );
  };

  const state = async (row: FamilyCase, voucherNo: string): Promise<Record<string, unknown>> => {
    const result = (await owner.$queryRawUnsafe(
      `SELECT
        (SELECT count(*)::int FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) headers,
        (SELECT count(*)::int FROM "${row.detailTable}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) details,
        (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) stock,
        (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00008') temp,
        (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) audits`,
      TENANT,
      row.book,
      voucherNo,
    )) as Array<Record<string, unknown>>;
    return result[0]!;
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('persists item-opening desktop fine without ghat weight in detail and stock', async () => {
    const scope: VoucherScope = {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      coBook: 'IOP',
    };
    const created = await itemOpening(runtime, {
      scope,
      mainUser: MAIN_USER,
      vchDate: DAY,
      lines: [
        {
          itCode: 'GOLD1',
          pcs: 1,
          grossWt: 12,
          netWt: 10,
          ghtWt: 5,
          touch: 90,
          westPct: 2,
        },
      ],
    });
    const voucherNo = String(created.vchNo).padStart(5, '0');
    const rows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT "ITM_FINE"::float FROM "ITM_OPBL"
           WHERE tenant_id=$1 AND "CO_BOOK"='IOP' AND "VCH_NO"=$2) detail_fine,
         (SELECT "ITM_FINE"::float FROM "MAIN_STOCK"
           WHERE tenant_id=$1 AND "CO_BOOK"='IOP' AND "VCH_NO"=$2) stock_fine`,
      TENANT,
      voucherNo,
    )) as Array<Record<string, unknown>>;

    // TR_ITM_OPBL.cs:949-955: 10 × (90 + 2) / 100 = 9.2; the 5g ghat is ignored.
    expect(rows[0]).toEqual({ detail_fine: 9.2, stock_fine: 9.2 });
  });

  it.each(cases)(
    '$family creates, reads, edits, lock-checks, consumption-checks and deletes atomically',
    async (row) => {
      const scope: VoucherScope = {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        coBook: row.book,
      };
      const created = await row.create(runtime, scope);
      expect(created.vchNo).toBe(1);
      const voucherNo = String(created.vchNo).padStart(5, '0');

      const persisted = (await owner.$queryRawUnsafe(
        `SELECT "VCH_NO","HD_VCH_NO","MAIN_USER","VCH_DATE"::text,
                to_char("VCH_TIME",'HH24:MI:SS.MS') clock
           FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        TENANT,
        row.book,
        voucherNo,
      )) as Array<Record<string, unknown>>;
      expect(persisted).toHaveLength(1);
      expect(persisted[0]).toMatchObject({
        VCH_NO: '00001',
        HD_VCH_NO: '00008',
        MAIN_USER,
        VCH_DATE: DAY,
      });
      expect(String(persisted[0]!.clock)).toMatch(/^\d{2}:\d{2}:\d{2}\.\d{3}$/);
      expect(await state(row, voucherNo)).toMatchObject({
        headers: 1,
        details: 1,
        stock: expect.any(Number),
        temp: 1,
        audits: 0,
      });

      const opened = await row.get(runtime, scope, voucherNo);
      expect(opened).toMatchObject({
        voucherNo: '00001',
        hiddenVoucherNo: '00008',
        mainUser: MAIN_USER,
        vchDate: DAY,
        lines: [{ itCode: 'GOLD1' }],
      });

      await row.edit(runtime, scope, voucherNo);
      const edited = await row.get(runtime, scope, voucherNo);
      expect(edited).toMatchObject({
        voucherNo: '00001',
        hiddenVoucherNo: '00008',
        mainUser: MAIN_USER,
        vchDate: NEXT_DAY,
        lines: [
          {
            itCode: row.expectedEditedItem,
            ...(row.family === 'tag-opening' ? { vchSrno: 1 } : {}),
            ...(row.family === 'item-lot' ? { itType: 'G' } : {}),
          },
        ],
      });
      const identityAfterEdit = (await owner.$queryRawUnsafe(
        `SELECT "HD_VCH_NO","MAIN_USER","VCH_DATE"::text,
                to_char("VCH_TIME",'HH24:MI:SS.MS') clock
           FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        TENANT,
        row.book,
        voucherNo,
      )) as Array<Record<string, unknown>>;
      expect(identityAfterEdit[0]).toMatchObject({
        HD_VCH_NO: '00008',
        MAIN_USER,
        VCH_DATE: NEXT_DAY,
        clock: persisted[0]!.clock,
      });
      expect(await state(row, voucherNo)).toMatchObject({
        headers: 1,
        details: 1,
        temp: 1,
        audits: 0,
      });
      const stockRows = (await owner.$queryRawUnsafe(
        `SELECT "IT_CODE" FROM "MAIN_STOCK"
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "ITM_SIGN"='+'`,
        TENANT,
        row.book,
        voucherNo,
      )) as Array<Record<string, unknown>>;
      expect(stockRows.map((value) => value.IT_CODE)).toContain(row.expectedEditedItem);
      expect(stockRows.map((value) => value.IT_CODE)).not.toContain('GOLD1');

      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
        NEXT_DAY,
        TENANT,
        CO,
      );
      const beforeLockedEdit = await row.get(runtime, scope, voucherNo);
      await expect(row.edit(runtime, scope, voucherNo, '2024-04-12')).rejects.toBeInstanceOf(
        PeriodLockValidationError,
      );
      expect(await row.get(runtime, scope, voucherNo)).toEqual(beforeLockedEdit);
      expect(await state(row, voucherNo)).toMatchObject({
        headers: 1,
        details: 1,
        temp: 1,
        audits: 0,
      });
      await owner.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        TENANT,
        CO,
      );

      await row.seedConsumption(owner, scope, voucherNo, edited);
      const beforeConsumedEdit = await row.get(runtime, scope, voucherNo);
      await expect(row.edit(runtime, scope, voucherNo, '2024-04-12')).rejects.toBeInstanceOf(
        StockVoucherValidationError,
      );
      expect(await row.get(runtime, scope, voucherNo)).toEqual(beforeConsumedEdit);
      expect(await state(row, voucherNo)).toMatchObject({
        headers: 1,
        details: 1,
        temp: 1,
        audits: 0,
      });
      await owner.$executeRawUnsafe(
        `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAL'`,
        TENANT,
      );

      if (row.family === 'tag-opening') {
        await owner.$executeRawUnsafe(
          `UPDATE "BAR_DETL" SET "AC_CODE"='DETAILAC' WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          TENANT,
          row.book,
          voucherNo,
        );
      }
      await expect(row.remove(runtime, scope, voucherNo)).resolves.toEqual({ reversed: true });
      const afterDelete = await state(row, voucherNo);
      expect(afterDelete).toMatchObject({
        headers: 0,
        details: 0,
        stock: 0,
        temp: 0,
        audits: row.expectedDeleteRows,
      });
      const audits = (await owner.$queryRawUnsafe(
        `SELECT "SR_NO","VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","FINE_TYPE","VCH_VAL_DR","VCH_VAL_CR","VCH_FINE_DR"::float "VCH_FINE_DR",
                "VCH_FINE_CR"::float "VCH_FINE_CR","HD_VCH_NO","MAIN_USER","DELETE_USER","VCH_DESC"
           FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
           ORDER BY "SR_NO"`,
        TENANT,
        row.book,
        voucherNo,
      )) as Array<Record<string, unknown>>;
      if (row.family === 'tag-opening') {
        expect(audits).toHaveLength(1);
        expect(audits[0]).toMatchObject({
          SR_NO: 1,
          VCH_TYPE: row.configuredType,
          BOOK_NAME: row.configuredName,
          AC_CODE: 'DETAILAC',
          AC_NAME: '',
          FINE_TYPE: 'G',
          VCH_VAL_DR: 0,
          VCH_VAL_CR: 0,
          VCH_FINE_DR: 0,
          VCH_FINE_CR: 11,
          HD_VCH_NO: '00008',
          MAIN_USER,
          DELETE_USER: 'deleter',
          VCH_DESC: 'ItCode/GOLD2 TagNo/OPEN-TAG-1',
        });
      } else {
        expect(audits).toEqual([]);
      }
    },
    30_000,
  );

  // Depth gate (Phase B): the desktop tag grid persists 43 further BAR_DETL columns
  // (TR_TAG_OPBL.cs:9294-9400 and 10925-11130). Asserting the FULL set, not a sample, so a
  // dropped column fails here instead of surfacing as a blank tag reprint in production.
  it('persists every desktop tag-grid column on BAR_DETL', async () => {
    const scope: VoucherScope = {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      coBook: 'TOP',
    };
    const created = await tagOpening(runtime, {
      scope,
      mainUser: MAIN_USER,
      vchDate: DAY,
      lines: [
        {
          tagNo: 'DEPTH-TAG-1',
          itCode: 'GOLD1',
          pcs: 1,
          grossWt: 10,
          netWt: 10,
          touch: 90,
          rate: 500,
          tblCode: '001',
          itmStyle: 'STYLE-A',
          itmColor: 'ROSE',
          itmMargin: 12.5,
          lbrCode: 'LBR7',
          slType: 'R',
          empIsu: 'Y',
          designImageId: 'IMG-45',
          mainMarginPct: 8.25,
          mainMrp: 74_500,
          hallmarkId2: 'HM2',
          hallmarkId3: 'HM3',
          hallmarkId4: 'HM4',
          hallmarkIdWt: 1.1,
          hallmarkId2Wt: 2.2,
          hallmarkId3Wt: 3.3,
          hallmarkId4Wt: 4.4,
          karigarLbrRate: 55,
          karigarLbrAmt: 550,
          karigarOthAmt: 60,
          karigarOthRate: 6,
          karigarOthFine: 0.6,
          karigarTotFine: 9.9,
          karigarGwtTouch: 91.5,
          karigarCost: 1_250,
          karigarName: 'KARX',
          karigarWaxWt: 0.35,
          jdtJdtWt: 5.5,
          jdtGhtWt: 0.5,
          jdtKunWt: 1.5,
          jdtKunTouch: 92.5,
          jdtKunNet: 1.38,
          jdtWaxWt: 0.25,
          ordNo: 'ORD-77',
          ordSrno: 3,
          ordYrcd: YEAR,
          ordDbcd: 'SOR',
          ordAc: 'CUST1',
          ordLcCode: LC,
          sfNo: 'SF-12',
          mfgNo: 'MFG-88',
          mfgYrcd: YEAR,
          mfgDbcd: 'MFG',
          mfgSrno: 2,
        },
      ],
    });

    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT * FROM "BAR_DETL" WHERE tenant_id=$1 AND "MAIN_MRP"=$2`,
      TENANT,
      74_500,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;

    const expected: Record<string, unknown> = {
      ITM_STYLE: 'STYLE-A',
      ITM_COLOR: 'ROSE',
      LBR_CODE: 'LBR7',
      SL_TYPE: 'R',
      EMP_ISU: 'Y',
      DESIGN_IMG_ID: 'IMG-45',
      HM_ID2: 'HM2',
      HM_ID3: 'HM3',
      HM_ID4: 'HM4',
      KR_NAME: 'KARX',
      ORD_NO: 'ORD-77',
      ORD_YRCD: YEAR,
      ORD_DBCD: 'SOR',
      ORD_AC: 'CUST1',
      ORD_LC_CODE: LC,
      SF_NO: 'SF-12',
      MFG_NO: 'MFG-88',
      MFG_YRCD: YEAR,
      MFG_DBCD: 'MFG',
    };
    for (const [column, value] of Object.entries(expected)) {
      expect(String(row[column] ?? '').trim(), `BAR_DETL.${column}`).toBe(String(value));
    }

    const numeric: Record<string, number> = {
      ITM_MARGIN: 12.5,
      MAIN_MARGIN_PRC: 8.25,
      MAIN_MRP: 74_500,
      HM_ID_WT: 1.1,
      HM_ID2_WT: 2.2,
      HM_ID3_WT: 3.3,
      HM_ID4_WT: 4.4,
      KR_LBR_RATE: 55,
      KR_LBR_AMT: 550,
      KR_OTH_AMT: 60,
      KR_OTH_RATE: 6,
      KR_OTH_FINE: 0.6,
      KR_TOT_FINE: 9.9,
      KR_GWT_TOUCH: 91.5,
      KR_COST: 1_250,
      KR_WAX_WT: 0.35,
      JDT_JDT_WT: 5.5,
      JDT_GHT_WT: 0.5,
      JDT_KUN_WT: 1.5,
      JDT_KUN_TOUCH: 92.5,
      JDT_KUN_NET: 1.38,
      JDT_WAX_WT: 0.25,
      ORD_SRNO: 3,
      MFG_SRNO: 2,
    };
    for (const [column, value] of Object.entries(numeric)) {
      expect(Number(row[column] ?? 0), `BAR_DETL.${column}`).toBeCloseTo(value, 2);
    }

    // Every asserted column must exist on the row object; a renamed column must fail loudly.
    for (const column of [...Object.keys(expected), ...Object.keys(numeric)]) {
      expect(Object.prototype.hasOwnProperty.call(row, column), `column ${column} present`).toBe(
        true,
      );
    }
  }, 30_000);
});
