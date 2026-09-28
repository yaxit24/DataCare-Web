import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  cancelTourOrder,
  createTourOrder,
  editTourOrder,
  getTourOrder,
  getTourOrderConfiguration,
  listTourOrders,
} from '../src/modules/sales/salesOrder.js';

const dbDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;

dbDescribe('Tour Order configured-book and complete editor round trip', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const runtime = new PrismaClient({
    datasources: { db: { url: process.env.DATABASE_URL ?? '' } },
  });
  const tenantId = 'tour-hydration-db';
  const scope = (coBook = '511', lcCode = '01', coYear = '2024-2025') => ({
    tenantId,
    coCode: '01',
    lcCode,
    coYear,
    coBook,
  });
  const tables = [
    'DELETE_DATA',
    'ROJ_MEL_DATA',
    'AC_DATA',
    'SL_ORD_IDTL',
    'SL_ORD_DETL',
    'SL_ORD_DATA',
    'SL_PR_DETL',
    'SL_ORD_ADJ',
    'UPI_DATA',
    'MAIN_STOCK',
    'TEMP_BOOK_DATA',
    'BOOK_DATA',
    'ITEM_MAST',
    'AC_MAST',
    'CO_SET_NEW',
    'CO_SET',
    'YEAR_MAST',
  ];
  const exec = (sql: string, ...params: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(sql, ...params));
  const query = (sql: string, ...params: unknown[]) => owner.$queryRawUnsafe<any[]>(sql, ...params);
  const clean = async () => {
    for (const table of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  beforeEach(async () => {
    await clean();
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,'01')`, tenantId);
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,'01','2024-2025','2024-04-01','2025-03-31'),($1,'01','2023-2024','2023-04-01','2024-03-31')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME") VALUES ($1,'01','01','510','Tour A','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA'),($1,'01','01','511','Tour B','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA'),($1,'01','01','Z09','Custom Tour','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA'),($1,'01','02','511','Branch Tour','TUROD','TOUR ORDER','I','Y','SL_ORD_DATA'),($1,'01','01','SOR','Sales Order','SORD','SALES ORDER','O','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','PARTY','Customer'),($1,'01','01','CASH','Cash'),($1,'01','01','CASH2','Second till')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,'01','GL','Gold','G'),($1,'01','DM','Diamond','D')`,
      tenantId,
    );
  });
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  const input = (book = '511') => ({
    scope: scope(book),
    mainUser: 'tour-editor',
    vchDate: '2024-07-10',
    billNo: 'TOUR/001',
    vchDesc: 'Tour ring specifications',
    acCode: 'PARTY',
    acName: 'Customer',
    advanceAmount: 123.45,
    cashAc: 'CASH2',
    taxRatePct: 3,
    taxCode: '03',
    address1: 'First road',
    address2: 'Second road',
    address3: 'Third road',
    city: 'Surat',
    mobile: '09876543210',
    empCode: 'EMP1',
    deliveryDate: '2024-07-20',
    functionDate: '2024-07-22',
    bankAc: 'BANK1',
    bankName: 'Bank name',
    chequeNo: '000076',
    cardAc: 'CARD1',
    cardAdj: 'Y',
    oldGoldFine: 1.12,
    oldGoldAmount: 100,
    oldSilverFine: 2.23,
    oldSilverAmount: 50,
    schemeAmount: 20,
    rateCutRate: 4.45,
    rateCutFine: 1.1,
    rateCutAmount: 4.9,
    adjustGold: 0.2,
    adjustSilver: 0.3,
    orderAdjustAmount: 5,
    upiAmount: 0,
    lines: [
      {
        itCode: 'GL',
        designNo: '00016',
        pcs: 2,
        grossWt: 3.5,
        netWt: 3.123,
        touch: 91.6,
        ghtWt: 0.103,
        westPct: 1.11,
        rate: 7000,
        making: 37.321,
        remark: 'Keep both stone specifications',
        tblCode: '002',
        itmColor: 'ROSE',
        itmSize: '17.5',
        bagWt: 0.1,
        lessWt: 0.377,
        ghtPct: 0.5,
        rateFix: 'Y',
        labourPct: 1.2,
        labourType: 'W',
        labourRate: 37.321,
        otherAmount: 2.12,
        mrp: 99999,
        orderDeliveryDate: '2024-07-18',
        karigarNetWt: 3.101,
        karigarTouch: 91.5,
        karigarWestPct: 0.11,
        karigarFine: 2.9,
        karigarName: 'KR01',
        tagCost: 19500,
        vchSrno: 7,
        oldSrNo: 19,
        rateType: 'W',
        itType: 'G',
        prCode: '01',
        oldTblCode: '001',
        tagStockLess: 'N',
        designImageId: 'design-00016-side',
        huid: 'AB0123',
        hallmarkId2: 'CD0123',
        hallmarkId3: 'EF0123',
        hallmarkId4: 'GH0123',
        hallmarkIdWt: 1.001,
        hallmarkId2Wt: 1.002,
        hallmarkId3Wt: 1.003,
        hallmarkId4Wt: 1.004,
        components: [
          {
            itCode: 'DM',
            itType: 'D',
            dmCode: '00001',
            dmName: 'Round',
            dmSize: '2mm',
            dmSfNo: '00003',
            dmColor: 'D',
            dmOrigin: 'India',
            dmRemark: 'First',
            dmLeb: 'LAB-1',
            pcs: 3,
            grossWt: 0.123,
            pcsWt: 0,
            conPct: 98,
            conWt: 0.121,
            rateType: 'W',
            rate: 30000,
            amount: 3690,
            lbrRate: 15,
            lbrAmount: 45,
            netAmount: 3735,
            karigarWt: 0.125,
            karigarLessPct: 1,
            karigarConPct: 97,
            karigarConWt: 0.12,
            karigarRate: 20000,
            karigarAmount: 2500,
            karigarLabourRate: 10,
            karigarLabourAmount: 30,
            karigarNetAmount: 2530,
          },
          {
            itCode: 'DM',
            itType: 'D',
            dmCode: '00002',
            dmName: 'Pear',
            pcs: 1,
            grossWt: 0.222,
            rateType: 'P',
            rate: 1000,
            amount: 1000,
            lbrRate: 0,
            lbrAmount: 0,
            netAmount: 1000,
          },
        ],
      },
    ],
  });
  async function businessSnapshot() {
    const result: Record<string, unknown> = {};
    for (const table of ['SL_ORD_DATA', 'SL_ORD_DETL', 'SL_ORD_IDTL', 'AC_DATA', 'ROJ_MEL_DATA']) {
      const rows = await query(
        `SELECT to_jsonb(r)-'row_id'-'LEDR_KEY' AS value FROM "${table}" r WHERE tenant_id=$1 AND "CO_BOOK"='511' ORDER BY (to_jsonb(r)-'row_id'-'LEDR_KEY')::text`,
        tenantId,
      );
      result[table] = rows.map((row) => row.value);
    }
    return result;
  }

  it('preserves an imported tag and exact instance through reopen and unchanged edit, and refuses unsupported identity transitions', async () => {
    await createTourOrder(runtime, input());
    await exec(`UPDATE "SL_ORD_DETL" SET "TAG_NO"='IMPORTED-TAG-7' WHERE tenant_id=$1`, tenantId);
    const before = await businessSnapshot();
    let document: any = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ tagNo: 'IMPORTED-TAG-7', vchSrno: 7 });
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    expect(await businessSnapshot()).toEqual(before);
    document = await getTourOrder(runtime, scope(), '00001');
    for (const change of [
      { tagNo: 'DIFFERENT-TAG' },
      { tagNo: 'N' },
      { tagNo: '' },
      { vchSrno: 8 },
      { srNo: 44 },
    ]) {
      const lines = document.lines.map((line: any) => ({ ...line, ...change }));
      await expect(
        editTourOrder(
          runtime,
          { ...document, lines, scope: scope(), expectedVersion: document.version },
          '00001',
        ),
      ).rejects.toMatchObject({ name: 'SaleValidationError' });
      expect(await businessSnapshot()).toEqual(before);
    }
    await expect(
      editTourOrder(
        runtime,
        { ...document, lines: [], scope: scope(), expectedVersion: document.version },
        '00001',
      ),
    ).rejects.toMatchObject({ name: 'SaleValidationError' });
    expect(await businessSnapshot()).toEqual(before);
    // Older complete-component clients may omit read-only identity fields. Omission is not tag deletion.
    const lines = document.lines.map(({ tagNo, vchSrno, ...line }: any) => line);
    await editTourOrder(
      runtime,
      { ...document, lines, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    expect(await businessSnapshot()).toEqual(before);
  });

  it('does not silently accept a new tag allocation through the ordinary order editor', async () => {
    const request = input();
    await expect(
      createTourOrder(runtime, {
        ...request,
        lines: request.lines.map((line) => ({ ...line, tagNo: 'NEW-TAG' })),
      }),
    ).rejects.toMatchObject({ name: 'SaleValidationError' });
    const rows = await query('SELECT * FROM "SL_ORD_DATA" WHERE tenant_id=$1', tenantId);
    expect(rows).toHaveLength(0);
  });

  it('hydrates all persisted input fields and multiple independent children; unchanged edit keeps business rows', async () => {
    await createTourOrder(runtime, input());
    // Imported desktop rows can retain non-contiguous parent and child serials.
    await exec(`UPDATE "SL_ORD_DETL" SET "SR_NO"=7 WHERE tenant_id=$1`, tenantId);
    await exec(
      `UPDATE "SL_ORD_IDTL" SET "SR_NO"=7,"ISR_NO"="ISR_NO"*10 WHERE tenant_id=$1`,
      tenantId,
    );
    const before = await businessSnapshot();
    const document: any = await getTourOrder(runtime, scope(), '00001');
    expect(document).toMatchObject({
      vchDesc: 'Tour ring specifications',
      bankAc: 'BANK1',
      chequeNo: '000076',
      cashAc: 'CASH2',
      deliveryDate: '2024-07-20',
      functionDate: '2024-07-22',
      empCode: 'EMP1',
      address3: 'Third road',
      oldGoldFine: 1.12,
      lines: [
        {
          designImageId: 'design-00016-side',
          huid: 'AB0123',
          oldSrNo: 19,
          ghtWt: 0.103,
          hallmarkId4Wt: 1.004,
          components: [
            { dmCode: '00001', lbrRate: 15, lbrAmount: 45, pcsWt: 0, karigarNetAmount: 2530 },
            { dmCode: '00002', pcs: 1, lbrRate: 0 },
          ],
        },
      ],
    });
    expect(document.version).toMatch(/^[a-f0-9]{64}$/);
    expect(document.lines[0].components).toHaveLength(2);
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    expect(await businessSnapshot()).toEqual(before);
    const saved: any = await getTourOrder(runtime, scope(), '00001');
    expect(saved.version).not.toEqual(document.version);
    await expect(
      editTourOrder(
        runtime,
        { ...document, scope: scope(), expectedVersion: document.version },
        '00001',
      ),
    ).rejects.toMatchObject({ name: 'SalesOrderConflictError' });
    await expect(
      cancelTourOrder(runtime, {
        scope: scope(),
        vchNo: '00001',
        expectedVersion: document.version,
      }),
    ).rejects.toMatchObject({ name: 'SalesOrderConflictError' });
    expect(await businessSnapshot()).toEqual(before);
    saved.lines[0].components[1].dmName = 'Oval';
    await editTourOrder(
      runtime,
      { ...saved, scope: scope(), expectedVersion: saved.version },
      '00001',
    );
    const changed: any = await getTourOrder(runtime, scope(), '00001');
    expect(changed.lines[0].components.map((child: any) => child.dmName)).toEqual([
      'Round',
      'Oval',
    ]);
    await cancelTourOrder(runtime, {
      scope: scope(),
      vchNo: '00001',
      expectedVersion: changed.version,
      deleteUser: 'tour-editor',
    });
    expect(await listTourOrders(runtime, scope())).toEqual([]);
  });

  it('isolates identical voucher numbers across configured books, locations and fiscal years', async () => {
    for (const book of ['510', '511', 'Z09']) await createTourOrder(runtime, input(book));
    await createTourOrder(runtime, { ...input(), scope: scope('511', '02') });
    await createTourOrder(runtime, {
      ...input(),
      vchDate: '2023-07-10',
      scope: scope('511', '01', '2023-2024'),
    });
    for (const book of ['510', '511', 'Z09'])
      expect(await listTourOrders(runtime, scope(book))).toMatchObject([{ vchNo: '00001', book }]);
    const doc: any = await getTourOrder(runtime, scope('Z09'), '00001');
    await cancelTourOrder(runtime, {
      scope: scope('Z09'),
      vchNo: '00001',
      expectedVersion: doc.version,
    });
    expect(await listTourOrders(runtime, scope('Z09'))).toEqual([]);
    for (const s of [
      scope('510'),
      scope('511'),
      scope('511', '02'),
      scope('511', '01', '2023-2024'),
    ])
      expect(await listTourOrders(runtime, s)).toHaveLength(1);
    await expect(createTourOrder(runtime, input('SOR'))).rejects.toThrow(
      'expected TOUR ORDER book',
    );
    await expect(getTourOrder(runtime, scope('SOR'), '00001')).rejects.toThrow(
      'expected TOUR ORDER book',
    );
  });

  it('allows one of two concurrent edits from the same snapshot and keeps both component rows', async () => {
    await createTourOrder(runtime, input());
    const doc: any = await getTourOrder(runtime, scope(), '00001');
    const outcomes = await Promise.allSettled(
      ['first', 'second'].map((vchDesc) =>
        editTourOrder(
          runtime,
          { ...doc, scope: scope(), expectedVersion: doc.version, vchDesc },
          '00001',
        ),
      ),
    );
    expect(outcomes.filter((value) => value.status === 'fulfilled')).toHaveLength(1);
    expect(outcomes.find((value) => value.status === 'rejected')).toMatchObject({
      reason: { name: 'SalesOrderConflictError' },
    });
    const saved: any = await getTourOrder(runtime, scope(), '00001');
    expect(saved.lines[0].components).toHaveLength(2);
  });

  it('includes ghat in per-gram labour by default, honours N, and rejects stale settings snapshots', async () => {
    expect(await getTourOrderConfiguration(runtime, scope())).toEqual({
      labourIncludesGhat: true,
      labourRateDecimals: 2,
    });
    await createTourOrder(runtime, input());
    const before: any = await getTourOrder(runtime, scope(), '00001');
    const labour = async (book: string) =>
      (
        await query(
          `SELECT "LBR_AMT"::float8 AS amount FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
          tenantId,
          book,
        )
      )[0].amount;
    expect(await labour('511')).toBe(120); // Math.Round((3.123 + 0.103) * 37.321, 0), source whole-rupee precision.
    await exec(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES ($1,'01','N')`,
      tenantId,
    );
    expect(await getTourOrderConfiguration(runtime, scope())).toEqual({
      labourIncludesGhat: false,
      labourRateDecimals: 2,
    });
    await expect(
      editTourOrder(
        runtime,
        { ...before, scope: scope(), expectedVersion: before.version },
        '00001',
      ),
    ).rejects.toMatchObject({ name: 'SalesOrderConflictError' });
    await createTourOrder(runtime, input('Z09'));
    expect(await labour('Z09')).toBe(117); // Math.Round(3.123 * 37.321, 0) when the company flag is N.
    const reopened: any = await getTourOrder(runtime, scope('Z09'), '00001');
    await editTourOrder(
      runtime,
      { ...reopened, scope: scope('Z09'), expectedVersion: reopened.version },
      '00001',
    );
    expect(await labour('Z09')).toBe(117);
  });

  it('refuses flattened legacy edits of multiple persisted components without changing any business row', async () => {
    await createTourOrder(runtime, input());
    await exec(`UPDATE "SL_ORD_DETL" SET "SR_NO"=17 WHERE tenant_id=$1`, tenantId);
    await exec(`UPDATE "SL_ORD_IDTL" SET "SR_NO"=17 WHERE tenant_id=$1`, tenantId);
    const loaded: any = await getTourOrder(runtime, scope(), '00001');
    const before = await businessSnapshot();
    const legacyLines = loaded.lines.map(({ components, srNo, ...line }: any) => line);
    await expect(
      editTourOrder(
        runtime,
        { ...loaded, lines: legacyLines, scope: scope(), expectedVersion: loaded.version },
        '00001',
      ),
    ).rejects.toThrow('submit complete component lists');
    await expect(
      editTourOrder(
        runtime,
        { ...loaded, lines: undefined, scope: scope(), expectedVersion: loaded.version },
        '00001',
      ),
    ).rejects.toThrow('submit complete component lists');
    expect(await businessSnapshot()).toEqual(before);
    expect((await getTourOrder(runtime, scope(), '00001')).version).toBe(loaded.version);
    // A current client can deliberately remove every component with an explicit empty collection.
    await editTourOrder(
      runtime,
      {
        ...loaded,
        lines: loaded.lines.map((line: any) => ({ ...line, components: [] })),
        scope: scope(),
        expectedVersion: loaded.version,
      },
      '00001',
    );
    const changed: any = await getTourOrder(runtime, scope(), '00001');
    expect(changed.lines[0].components).toEqual([]);
  });

  it('persists whole-rupee P/G/K/net labour with exact derived-rate and manual edit transitions', async () => {
    const request: any = input();
    request.lines = ['P', 'G', 'K', 'N'].map((labourType) => ({
      ...request.lines[0]!,
      labourType,
      pcs: 3,
      grossWt: 12,
      netWt: 10,
      ghtWt: 2,
      labourRate: labourType === 'K' ? 10250 : 10.25,
      labourPct: 0,
      making: undefined,
    }));
    await createTourOrder(runtime, request);
    let document: any = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines.map((line: any) => line.labourAmount)).toEqual([31, 123, 123, 123]);
    document.lines[0] = { ...document.lines[0], labourRate: 12.5, labourAction: 'rate' };
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 12.5, labourAmount: 38 });
    document.lines[0] = { ...document.lines[0], labourPct: 1.25, labourAction: 'percentage' };
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 87.5, labourAmount: 262 });
    document.lines[0] = { ...document.lines[0], labourAmount: 150.75, labourAction: 'amount' };
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 50.25, labourAmount: 150.75 });
    const before = await businessSnapshot();
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    expect(await businessSnapshot()).toEqual(before);
    expect(document.lines.every((line: any) => line.components.length === 2)).toBe(true);
  });

  it('replays rate-before-ghat and away/back changes, and rolls back mismatched computed payloads', async () => {
    const request: any = input();
    request.lines[0] = {
      ...request.lines[0],
      making: undefined,
      labourPct: 0,
      labourRate: 37.32,
      labourAmount: 117,
      labourEdits: [
        {
          action: 'rate',
          value: 37.321,
          basis: { labourType: 'N', pcs: 2, grossWt: 3.5, netWt: 3.123, ghatWt: 0, itemRate: 7000 },
        },
      ],
    };
    await createTourOrder(runtime, request);
    let document: any = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 37.32, labourAmount: 117, ghtWt: 0.103 });
    const basis = {
      labourType: 'N',
      pcs: 2,
      grossWt: 3.5,
      netWt: 3.123,
      ghatWt: 0.103,
      itemRate: 7000,
    };
    document.lines[0] = {
      ...document.lines[0],
      labourRate: 37.32,
      labourAmount: 120,
      labourEdits: [
        { action: 'rate', value: 40, basis },
        { action: 'rate', value: 37.32, basis },
      ],
    };
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 37.32, labourAmount: 120 });
    const before = await businessSnapshot();
    document.lines[0] = {
      ...document.lines[0],
      labourRate: 40,
      labourAmount: 1,
      labourEdits: [{ action: 'rate', value: 40, basis }],
    };
    await expect(
      editTourOrder(
        runtime,
        { ...document, scope: scope(), expectedVersion: document.version },
        '00001',
      ),
    ).rejects.toThrow('do not match');
    expect(await businessSnapshot()).toEqual(before);
  });

  it('preserves imported manual metal/labour/net values and voucher time on unchanged and child-only edits', async () => {
    await createTourOrder(runtime, { ...input(), vchTime: '15:42:31.123' });
    await exec(
      `UPDATE "SL_ORD_DETL" SET "ITM_FINE"=2.901,"ITM_AMT"=20301.37,"LBR_RATE"=37.32,"LBR_AMT"=120.41,"NET_AMT"=20499.77,"TOT_AMT"=20501.33 WHERE tenant_id=$1`,
      tenantId,
    );
    let document: any = await getTourOrder(runtime, scope(), '00001');
    expect(document.vchTime).toBe('15:42:31.123');
    const before = await businessSnapshot();
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    expect(await businessSnapshot()).toEqual(before);
    document = await getTourOrder(runtime, scope(), '00001');
    document.lines[0].components[1].dmName = 'Imported pear';
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    const changed: any = await getTourOrder(runtime, scope(), '00001');
    expect(changed.vchTime).toBe('15:42:31.123');
    expect(changed.lines[0]).toMatchObject({
      labourAmount: 120.41,
      labourRate: 37.32,
      itemAmount: 20301.37,
      lineNetAmount: 20499.77,
      lineTotalAmount: 20501.33,
    });
    await editTourOrder(
      runtime,
      { ...changed, vchTime: '16:05', scope: scope(), expectedVersion: changed.version },
      '00001',
    );
    const timed: any = await getTourOrder(runtime, scope(), '00001');
    expect(timed.vchTime).toBe('16:05:00.000');
    const afterTime = await businessSnapshot();
    await expect(
      editTourOrder(
        runtime,
        { ...timed, vchTime: '25:05', scope: scope(), expectedVersion: timed.version },
        '00001',
      ),
    ).rejects.toThrow('Order time');
    expect(await businessSnapshot()).toEqual(afterTime);
  });

  it('uses configured rate precision, ALL_ROF_REMOVE and rejects stale policy changes', async () => {
    await exec(`UPDATE "CO_SET" SET "LBR_ROF"=0 WHERE tenant_id=$1`, tenantId);
    const request: any = input();
    request.lines[0] = {
      ...request.lines[0]!,
      making: undefined,
      labourRate: undefined,
      labourPct: 1.23,
    };
    await createTourOrder(runtime, request);
    let document: any = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 86, labourAmount: 277 });
    expect(document.labourRateDecimals).toBe(0);
    await exec(`UPDATE "CO_SET" SET "ALL_ROF_REMOVE"='Y' WHERE tenant_id=$1`, tenantId);
    await expect(
      editTourOrder(
        runtime,
        { ...document, scope: scope(), expectedVersion: document.version },
        '00001',
      ),
    ).rejects.toMatchObject({ name: 'SalesOrderConflictError' });
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.labourRateDecimals).toBe(2);
    document.lines[0] = { ...document.lines[0], labourPct: 1.24, labourAction: 'percentage' };
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0]).toMatchObject({ labourRate: 86.8, labourAmount: 280 });
  });

  it('retains the previous write set when unsupported existing settlement rows would be lost', async () => {
    await createTourOrder(runtime, input());
    await exec(
      `INSERT INTO "SL_PR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO") VALUES ($1,'01','01','2024-2025','511','00001',1)`,
      tenantId,
    );
    const doc: any = await getTourOrder(runtime, scope(), '00001');
    expect(doc.editBlockedReason).toContain('metal');
    await expect(
      editTourOrder(runtime, { ...doc, scope: scope(), expectedVersion: doc.version }, '00001'),
    ).rejects.toThrow('metal');
    expect(await query(`SELECT * FROM "SL_PR_DETL" WHERE tenant_id=$1`, tenantId)).toHaveLength(1);
    expect(await listTourOrders(runtime, scope())).toHaveLength(1);
  });

  it('blocks the allocated source order while allowing the same number in another book, branch or year', async () => {
    const scopes = [scope(), scope('Z09'), scope('511', '02'), scope('511', '01', '2023-2024')];
    for (const current of scopes)
      await createTourOrder(runtime, {
        ...input(current.coBook),
        scope: current,
        vchDate: current.coYear === '2023-2024' ? '2023-07-10' : '2024-07-10',
      });
    // The settlement has its own identity. ORD_* points to the first source order only.
    await exec(
      `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ORD_NO","ORD_LC","ORD_YRCD","ORD_DBCD")
       VALUES ($1,'01','02','2024-2025','ADJ','90001',1,'00001','01','2024-2025','511')`,
      tenantId,
    );
    const allocated: any = await getTourOrder(runtime, scope(), '00001');
    const before = await businessSnapshot();
    await expect(
      editTourOrder(
        runtime,
        { ...allocated, scope: scope(), expectedVersion: allocated.version },
        '00001',
      ),
    ).rejects.toThrow('already been');
    await expect(
      cancelTourOrder(runtime, {
        scope: scope(),
        vchNo: '00001',
        expectedVersion: allocated.version,
      }),
    ).rejects.toThrow('already been');
    expect(await businessSnapshot()).toEqual(before);
    for (const current of scopes.slice(1)) {
      const document: any = await getTourOrder(runtime, current, '00001');
      await editTourOrder(
        runtime,
        {
          ...document,
          scope: current,
          expectedVersion: document.version,
          vchDesc: 'Independent scope edit',
        },
        '00001',
      );
      const changed: any = await getTourOrder(runtime, current, '00001');
      expect(changed.vchDesc).toBe('Independent scope edit');
      expect(changed.lines[0].components).toHaveLength(2);
      await cancelTourOrder(runtime, {
        scope: current,
        vchNo: '00001',
        expectedVersion: changed.version,
      });
      expect(await listTourOrders(runtime, current)).toEqual([]);
    }
    expect((await getTourOrder(runtime, scope(), '00001')).version).toBe(allocated.version);
    expect(await query(`SELECT "ORD_DBCD" FROM "SL_ORD_ADJ" WHERE tenant_id=$1`, tenantId)).toEqual(
      [{ ORD_DBCD: '511' }],
    );
  });

  it('treats missing legacy allocation dimensions conservatively but respects an explicit different source dimension', async () => {
    await createTourOrder(runtime, input());
    await exec(
      `INSERT INTO "SL_ORD_ADJ"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ORD_NO","ORD_LC","ORD_YRCD","ORD_DBCD")
       VALUES ($1,'01','02','2023-2024','ADJ','90001',1,'00001',NULL,'  ',NULL)`,
      tenantId,
    );
    let document: any = await getTourOrder(runtime, scope(), '00001');
    const before = await businessSnapshot();
    await expect(
      editTourOrder(
        runtime,
        { ...document, scope: scope(), expectedVersion: document.version },
        '00001',
      ),
    ).rejects.toThrow('already been');
    await expect(
      cancelTourOrder(runtime, {
        scope: scope(),
        vchNo: '00001',
        expectedVersion: document.version,
      }),
    ).rejects.toThrow('already been');
    expect(await businessSnapshot()).toEqual(before);
    // Missing branch/year cannot turn a known other book into a match for this order.
    await exec(`UPDATE "SL_ORD_ADJ" SET "ORD_DBCD"='Z09' WHERE tenant_id=$1`, tenantId);
    await editTourOrder(
      runtime,
      { ...document, scope: scope(), expectedVersion: document.version },
      '00001',
    );
    document = await getTourOrder(runtime, scope(), '00001');
    expect(document.lines[0].components).toHaveLength(2);
    await cancelTourOrder(runtime, {
      scope: scope(),
      vchNo: '00001',
      expectedVersion: document.version,
    });
    expect(await listTourOrders(runtime, scope())).toEqual([]);
    expect(await query(`SELECT "ORD_DBCD" FROM "SL_ORD_ADJ" WHERE tenant_id=$1`, tenantId)).toEqual(
      [{ ORD_DBCD: 'Z09' }],
    );
  });
});
