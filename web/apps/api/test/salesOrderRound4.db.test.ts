import { PrismaClient } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSalesOrder,
  editSalesOrder,
  getSalesOrder,
  cancelSalesOrder,
} from '../src/modules/sales/salesOrder.js';
import { listSalesOrderDesigns } from '../src/modules/sales/orderDesignSelection.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('Sales ordinary saved state and ordered design source replay', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenantId = 'sales-round4-state';
  const scope = (coBook = 'S91') => ({
    tenantId,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
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
    'DESIGN_DETL',
    'PRODUCT_MAST',
    'ITEM_MAST',
    'AC_MAST',
    'CO_SET',
    'CO_SET_NEW',
    'YEAR_MAST',
  ];
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const query = (statement: string, ...values: unknown[]) =>
    owner.$queryRawUnsafe<any[]>(statement, ...values);
  const clean = async () => {
    for (const table of tables) await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  beforeEach(async () => {
    await clean();
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES($1,'01',NULL)`,
      tenantId,
    );
    await sql(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01','2024-2025','2024-04-01','2025-03-31')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01','S91','SALES ORDER','O','SORD','Sales One','Y','SL_ORD_DATA'),($1,'01','01','S92','SALES ORDER','O','SORD','Sales Two','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','Saved customer'),($1,'01','01','CASH','Cash')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE") VALUES($1,'01','GL','Gold','01'),($1,'01','DM','Diamond','02')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,'01','01','Gold product')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","PR_CODE","BOOK_NAME","SR_NO","OLD_SRNO","DESIGN_NO","ITM_SIZE","KR_NAME","ITM_TOUCH","ITM_WEST_PRC","LBR_PRC","LBR_RATE","ITM_GWT","DESIGN_IMG_ID") VALUES($1,'01','01','BOOK-A',17,7,'DESIGN-A','18','KR1',90,2,0,20,999,'01_BOOK-A_01_DESIGN-A')`,
      tenantId,
    );
  });
  afterAll(async () => {
    await clean();
    await runtime.$disconnect();
    await owner.$disconnect();
  });
  const input = (coBook = 'S91') => ({
    scope: scope(coBook),
    vchDate: '2024-07-10',
    vchTime: '12:34:56.123456',
    mainUser: 'original-user',
    acCode: 'PARTY',
    acName: 'Saved customer',
    taxRatePct: 0,
    advanceAmount: 100,
    cashAc: 'CASH',
    lines: [
      {
        srNo: 7,
        itCode: 'GL',
        designNo: 'CUSTOM',
        designImageId: 'N',
        pcs: 1,
        grossWt: 2.1,
        netWt: 2,
        touch: 100,
        rate: 100,
        labourAmount: 0,
        labourRate: 0,
        labourPct: 0,
        components: [
          {
            isrNo: 3,
            itCode: 'DM',
            dmName: 'Round exact',
            pcs: 1,
            grossWt: 0.123,
            amount: 11.11,
            lbrAmount: 1.01,
            netAmount: 12.12,
          },
          {
            isrNo: 13,
            itCode: 'DM',
            dmName: 'Oval exact',
            pcs: 2,
            grossWt: 0.456,
            amount: 22.22,
            lbrAmount: 2.02,
            netAmount: 24.24,
          },
        ],
      },
    ],
  });
  const loaded = async (book = 'S91', no = 1) =>
    getSalesOrder(runtime, scope(book), no) as Promise<any>;
  const replacement = (doc: any) => ({
    ...doc,
    scope: scope(doc.coBook),
    expectedVersion: doc.version,
    mainUser: 'new-user',
  });
  const snapshot = async (book = 'S91') => {
    const out: Record<string, string[]> = {};
    for (const table of ['SL_ORD_DATA', 'SL_ORD_DETL', 'SL_ORD_IDTL', 'AC_DATA', 'ROJ_MEL_DATA']) {
      const rows = await query(
        `SELECT (to_jsonb(t)-'row_id'-'tenant_id')::text AS value FROM "${table}" t WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY (to_jsonb(t)-'row_id'-'tenant_id')::text`,
        tenantId,
        book,
      );
      out[table] = rows.map((row) => row.value);
    }
    return out;
  };
  it('preserves complete imported business rows, six-digit clock, nullable values and exact large decimals on unchanged edit', async () => {
    await createSalesOrder(runtime, input());
    await createSalesOrder(runtime, input('S92'));
    await sql(
      `UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL,"ENTRY_TIME"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='S91'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_DETL" SET "BAG_WT"=NULL,"ITM_MRP"=999999999999999.99,"LOT_NO"='IMPORTED-LOT',"TAG_GEN"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='S91'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_IDTL" SET "KR_RATE"=NULL,"TAG_NO"='IMPORTED-CHILD' WHERE tenant_id=$1 AND "CO_BOOK"='S91' AND "ISR_NO"=3`,
      tenantId,
    );
    const doc = await loaded();
    expect(doc.vchTime).toBe('12:34:56.123456');
    expect(doc.mobile).toBeNull();
    expect(doc.lines[0].bagWt).toBeNull();
    expect(doc.lines[0].mrp).toBe('999999999999999.99');
    expect(doc.lines[0].components[0].karigarRate).toBeNull();
    expect(doc.lines[0].components.map((row: any) => row.isrNo)).toEqual([3, 13]);
    const before = await snapshot(),
      other = await snapshot('S92');
    await editSalesOrder(runtime, replacement(doc), 1);
    expect(await snapshot()).toEqual(before);
    expect(await snapshot('S92')).toEqual(other);
    expect((await loaded()).version).not.toBe(doc.version);
  });
  it('distinguishes explicit zero/blank dirty edits from unchanged null and changes only the selected child cell', async () => {
    await createSalesOrder(runtime, input());
    await sql(`UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL WHERE tenant_id=$1`, tenantId);
    await sql(
      `UPDATE "SL_ORD_DETL" SET "BAG_WT"=NULL,"ITM_MRP"=999999999999999.99 WHERE tenant_id=$1`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_IDTL" SET "KR_RATE"=NULL WHERE tenant_id=$1 AND "ISR_NO"=3`,
      tenantId,
    );
    const doc = await loaded(),
      before = await snapshot();
    doc.mobile = '';
    doc.dirtyFields = ['mobile'];
    doc.lines[0].bagWt = 0;
    doc.lines[0].mrp = 1234.56;
    doc.lines[0].dirtyFields = ['bagWt', 'mrp'];
    doc.lines[0].components[0].karigarRate = 0;
    doc.lines[0].components[0].dirtyFields = ['karigarRate'];
    await editSalesOrder(runtime, replacement(doc), 1);
    const after = await snapshot();
    expect(after.SL_ORD_DATA!.map((value) => JSON.parse(value))).toEqual(
      before.SL_ORD_DATA!.map((value) => ({ ...JSON.parse(value), MOBILE: '' })),
    );
    expect(after.SL_ORD_DETL!.map((value) => JSON.parse(value))).toEqual(
      before.SL_ORD_DETL!.map((value) => ({ ...JSON.parse(value), BAG_WT: 0, ITM_MRP: 1234.56 })),
    );
    const beforeChildren = before.SL_ORD_IDTL!.map((value) => JSON.parse(value));
    const afterChildren = after.SL_ORD_IDTL!.map((value) => JSON.parse(value));
    expect(afterChildren).toEqual(
      beforeChildren.map((row) => (row.ISR_NO === 3 ? { ...row, KR_RATE: 0 } : row)),
    );
    expect(after.AC_DATA).toEqual(before.AC_DATA);
    expect(after.ROJ_MEL_DATA).toEqual(before.ROJ_MEL_DATA);
  });
  it('validates malformed dates before mutation and preserves omitted saved date/clock on edit', async () => {
    for (const vchDate of ['2024-02-30', '2024-13-01', 'not-a-date', ''])
      await expect(createSalesOrder(runtime, { ...input(), vchDate })).rejects.toThrow(
        /date|required/,
      );
    expect(await query(`SELECT 1 FROM "SL_ORD_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
    await createSalesOrder(runtime, input());
    const doc = await loaded(),
      before = await snapshot();
    await expect(
      editSalesOrder(runtime, { ...replacement(doc), deliveryDate: '2024-02-30' }, 1),
    ).rejects.toThrow(/deliveryDate/);
    expect(await snapshot()).toEqual(before);
    await editSalesOrder(
      runtime,
      { ...replacement(doc), vchDate: undefined, vchTime: undefined },
      1,
    );
    expect(await snapshot()).toEqual(before);
  });
  it('keeps F1-only cached totals and applies copied labour/fine only at the later actual trigger', async () => {
    const selection = (await listSalesOrderDesigns(runtime, scope(), { itCode: 'GL' })).rows[0]!;
    const initial: any[] = [
      { kind: 'field', field: 'itCode', value: 'GL' },
      { kind: 'field', field: 'touch', value: 100 },
      { kind: 'field', field: 'netWt', value: 2 },
      { kind: 'field', field: 'rate', value: 100 },
      { kind: 'design', source: selection.source },
    ];
    const line: any = {
      srNo: 7,
      itCode: 'GL',
      designNo: 'DESIGN-A',
      itmSize: '18',
      karigarName: 'KR1',
      designImageId: selection.designImageId,
      pcs: 0,
      grossWt: 0,
      netWt: 2,
      ghtWt: 0,
      rate: 100,
      touch: 90,
      westPct: 2,
      labourPct: 0,
      labourRate: 20,
      labourAmount: 0,
      labourType: '',
      otherAmount: 0,
      orderEdits: initial,
      components: [],
    };
    await createSalesOrder(runtime, {
      ...input(),
      requireDesignSelection: true,
      advanceAmount: 0,
      lines: [line],
    });
    const first = await loaded();
    expect(first.lines[0]).toMatchObject({
      fineWeight: 2,
      itemAmount: 200,
      labourAmount: 0,
      lineNetAmount: 200,
      labourRate: 20,
    });
    await createSalesOrder(runtime, {
      ...input('S92'),
      requireDesignSelection: true,
      advanceAmount: 0,
      lines: [
        {
          ...line,
          labourAmount: 40,
          orderEdits: [
            ...initial,
            {
              kind: 'labour',
              edit: {
                action: 'rate',
                value: 20,
                basis: { labourType: '', pcs: 0, grossWt: 0, netWt: 2, ghatWt: 0, itemRate: 100 },
              },
            },
          ],
        },
      ],
    });
    const second = await loaded('S92');
    // The copied touch and wastage apply at this later trigger: the fine weight is now 1.84. The company's
    // SL_AMT_TYPE is blank, which the desktop reads as N, so the metal is priced on net + ghat, 2 × 100 = 200,
    // not on the fine weight (TR_SALE_ORD.cs:6571-6627; N196, G205).
    expect(second.lines[0]).toMatchObject({
      fineWeight: 1.84,
      itemAmount: 200,
      labourAmount: 40,
      lineNetAmount: 240,
    });
  });
  // N196 (G205): TR_SALE_ORD prices the metal on SL_AMT_TYPE in whole rupees and rounds tax and total to rupees
  // (TR_SALE_ORD.cs:6571-6672, :11340-11342). Net 10, touch 91.6, rate 6,123.45, labour 237.5 /g, tax 3%.
  it.each([
    ['N', { metal: 61234, net: 63609, tax: 1908, total: 65517 }],
    ['F', { metal: 56091, net: 58466, tax: 1754, total: 60220 }],
  ])('prices an order line on SL_AMT_TYPE %s in whole rupees', async (amountType, expected) => {
    await sql(`UPDATE "CO_SET" SET "SL_AMT_TYPE"=$2 WHERE tenant_id=$1`, tenantId, amountType);
    await createSalesOrder(runtime, {
      ...input(),
      taxRatePct: 3,
      advanceAmount: 0,
      lines: [
        {
          srNo: 1,
          itCode: 'GL',
          designImageId: 'N',
          pcs: 1,
          grossWt: 10.25,
          netWt: 10,
          ghtWt: 0,
          touch: 91.6,
          westPct: 0,
          rate: 6123.45,
          labourRate: 237.5,
          labourType: '',
          otherAmount: 0,
        },
      ],
    } as any);
    const [line] = await query(
      `SELECT "ITM_AMT"::float metal,"LBR_AMT"::float labour,"NET_AMT"::float net FROM "SL_ORD_DETL" WHERE tenant_id=$1`,
      tenantId,
    );
    const [header] = await query(
      `SELECT "NET_AMT"::float net,"TAX_AMT"::float tax,"TOT_AMT"::float total FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(line).toEqual({ metal: expected.metal, labour: 2375, net: expected.net });
    expect(header).toEqual({ net: expected.net, tax: expected.tax, total: expected.total });
  });
  // N197 (G206): cash, cheque and card tenders as TR_SALE_ORD stores them (:9131-9150, ADV_AMT the sum, :11368) and
  // Order_Ledr / Order_Rojmel post them (Ac_Ledr.cs:28-47, Ac_Rojmel.cs:11-16).
  it('stores and posts cash, cheque and card tenders, and refuses a cheque without its bank', async () => {
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','BANKX','Bank X')`,
      tenantId,
    );
    const tendered = {
      ...input(),
      advanceAmount: 300,
      chequeAmount: 200,
      bankAc: 'BANKX',
      chequeNo: '654321',
      cardAmount: 100,
      cardAc: 'BANKX',
    };
    await expect(createSalesOrder(runtime, { ...tendered, bankAc: '' } as any)).rejects.toThrow(
      'Please Select Bank Account',
    );
    await createSalesOrder(runtime, tendered as any);
    const [header] = await query(
      `SELECT "CASH_AMT"::float cash,"CHQ_AMT"::float chq,"CARD_AMT"::float card,"ADV_AMT"::float adv FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    const legs = await query(
      `SELECT right("LEDR_KEY",2) leg,"AC_CODE" ac,"LD_CODE" ld,"DR_AMT"::float dr,"CR_AMT"::float cr,"CHQ_NO" chq,"PARTY_AC_CODE" party FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    const day = await query(
      `SELECT right("LEDR_KEY",2) leg,"AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    expect(header).toEqual({ cash: 300, chq: 200, card: 100, adv: 600 });
    expect(legs.map((l) => [l.leg, l.ac, l.ld, l.dr, l.cr, l.chq || '', l.party])).toEqual([
      ['01', 'PARTY', 'CASH', 0, 300, '', 'PARTY'],
      ['02', 'CASH', 'PARTY', 300, 0, '', 'PARTY'],
      ['03', 'PARTY', 'BANKX', 0, 200, '654321', 'PARTY'],
      ['04', 'BANKX', 'PARTY', 200, 0, '654321', 'PARTY'],
      ['05', 'PARTY', 'BANKX', 0, 100, '654321', 'PARTY'],
      ['06', 'BANKX', 'PARTY', 100, 0, '654321', 'PARTY'],
    ]);
    expect(day.map((r) => [r.leg, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'PARTY', 0, 600],
      ['02', 'BANKX', 200, 0],
      ['03', 'BANKX', 100, 0],
    ]);
    const reopened = await loaded();
    expect(
      [reopened.advanceAmount, reopened.chequeAmount, reopened.cardAmount].map(Number),
    ).toEqual([300, 200, 100]);
  });
  it('rejects stale Design sources and forged journal values without any order writes', async () => {
    const selection = (await listSalesOrderDesigns(runtime, scope(), { itCode: 'GL' })).rows[0]!;
    const raw: any = {
      ...input(),
      requireDesignSelection: true,
      lines: [{ ...input().lines[0], designImageId: selection.designImageId }],
    };
    await expect(createSalesOrder(runtime, raw)).rejects.toThrow(/source selection/);
    raw.lines[0].orderEdits = [
      { kind: 'field', field: 'itCode', value: 'GL' },
      { kind: 'design', source: selection.source },
    ];
    await expect(createSalesOrder(runtime, raw)).rejects.toThrow(/does not match/);
    await sql(`UPDATE "DESIGN_DETL" SET "ITM_SIZE"='19' WHERE tenant_id=$1`, tenantId);
    await expect(createSalesOrder(runtime, raw)).rejects.toThrow(/changed/);
    expect(await query(`SELECT 1 FROM "SL_ORD_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
  });
  it('honours an explicit zero journal commit while retaining other unchanged nullable cells', async () => {
    await createSalesOrder(runtime, input());
    await sql(`UPDATE "SL_ORD_DETL" SET "OTH_AMT"=NULL,"BAG_WT"=NULL WHERE tenant_id=$1`, tenantId);
    const doc = await loaded();
    doc.lines[0].otherAmount = 0;
    doc.lines[0].orderEdits = [{ kind: 'field', field: 'otherAmount', value: 0 }];
    await editSalesOrder(runtime, replacement(doc), 1);
    const row = (
      await query(
        `SELECT "OTH_AMT"::text AS amount,"BAG_WT" AS bag FROM "SL_ORD_DETL" WHERE tenant_id=$1`,
        tenantId,
      )
    )[0];
    expect(row.amount).toBe('0.00');
    expect(row.bag).toBeNull();
  });
  it('maps unsupported new Design decimal precision to domain validation with no partial write', async () => {
    await sql(
      `UPDATE "DESIGN_DETL" SET "LBR_RATE"=999999999999999.99 WHERE tenant_id=$1`,
      tenantId,
    );
    const selected = (await listSalesOrderDesigns(runtime, scope(), { itCode: 'GL' })).rows[0]!;
    const line: any = {
      ...input().lines[0],
      designImageId: selected.designImageId,
      orderEdits: [
        { kind: 'field', field: 'itCode', value: 'GL' },
        { kind: 'design', source: selected.source },
      ],
    };
    await expect(
      createSalesOrder(runtime, { ...input(), requireDesignSelection: true, lines: [line] }),
    ).rejects.toMatchObject({ name: 'SaleValidationError' });
    expect(await query(`SELECT 1 FROM "SL_ORD_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
  });
  it.each([null, ''])(
    'copies source text %j as explicit blank on new/existing F1 and keeps no-event null distinct',
    async (sourceText) => {
      await sql(
        `UPDATE "DESIGN_DETL" SET "DESIGN_IMG_ID"=$2,"ITM_SIZE"=$2,"KR_NAME"=$2 WHERE tenant_id=$1`,
        tenantId,
        sourceText,
      );
      const selected = (await listSalesOrderDesigns(runtime, scope(), { itCode: 'GL' })).rows[0]!;
      const copiedCells = async () =>
        (
          await query(
            `SELECT "DESIGN_NO","ITM_SIZE","KR_NAME","DESIGN_IMG_ID" FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='S91'`,
            tenantId,
          )
        )[0];
      await createSalesOrder(runtime, {
        ...input(),
        advanceAmount: 0,
        requireDesignSelection: true,
        lines: [
          {
            srNo: 7,
            itCode: 'GL',
            designNo: 'DESIGN-A',
            // Older JSON serializers omit blank cells. The resolved replay still owns their value.
            itmSize: undefined,
            karigarName: undefined,
            designImageId: undefined,
            netWt: 1,
            rate: 100,
            touch: 90,
            westPct: 2,
            labourRate: 20,
            components: [],
            orderEdits: [
              { kind: 'field', field: 'itCode', value: 'GL' },
              { kind: 'field', field: 'touch', value: 100 },
              { kind: 'field', field: 'netWt', value: 1 },
              { kind: 'field', field: 'rate', value: 100 },
              { kind: 'design', source: selected.source },
            ],
          },
        ],
      });
      expect(await copiedCells()).toEqual({
        DESIGN_NO: 'DESIGN-A',
        ITM_SIZE: '',
        KR_NAME: '',
        DESIGN_IMG_ID: '',
      });
      await sql(
        `UPDATE "SL_ORD_DETL" SET "DESIGN_NO"='OLD',"DESIGN_IMG_ID"='OLD-LINK',"ITM_SIZE"='OLD-SIZE',"KR_NAME"='OLD' WHERE tenant_id=$1`,
        tenantId,
      );
      const saved = await loaded();
      saved.lines[0] = {
        ...saved.lines[0],
        designNo: 'DESIGN-A',
        itmSize: undefined,
        karigarName: undefined,
        designImageId: undefined,
        orderEdits: [{ kind: 'design', source: selected.source }],
      };
      await editSalesOrder(runtime, { ...replacement(saved), requireDesignSelection: true }, 1);
      expect(await copiedCells()).toEqual({
        DESIGN_NO: 'DESIGN-A',
        ITM_SIZE: '',
        KR_NAME: '',
        DESIGN_IMG_ID: '',
      });

      await sql(
        `UPDATE "SL_ORD_DETL" SET "DESIGN_NO"=NULL,"DESIGN_IMG_ID"=NULL,"ITM_SIZE"=NULL,"KR_NAME"=NULL WHERE tenant_id=$1`,
        tenantId,
      );
      const unchanged = await loaded();
      const before = await snapshot();
      await editSalesOrder(runtime, { ...replacement(unchanged), requireDesignSelection: true }, 1);
      expect(await snapshot()).toEqual(before);
      expect(await copiedCells()).toEqual({
        DESIGN_NO: null,
        ITM_SIZE: null,
        KR_NAME: null,
        DESIGN_IMG_ID: null,
      });

      const cleared = await loaded();
      cleared.lines[0] = {
        ...cleared.lines[0],
        designNo: '',
        designImageId: 'N',
        orderEdits: [{ kind: 'clearDesign' }],
      };
      await editSalesOrder(runtime, { ...replacement(cleared), requireDesignSelection: true }, 1);
      expect(await copiedCells()).toEqual({
        DESIGN_NO: '',
        ITM_SIZE: null,
        KR_NAME: null,
        DESIGN_IMG_ID: 'N',
      });
    },
  );
  it('contains tag-removal transitions while allowing unchanged saved tag ownership', async () => {
    await createSalesOrder(runtime, input());
    await sql(
      `UPDATE "SL_ORD_DETL" SET "TAG_NO"='SAVED-TAG',"VCH_SRNO"=7 WHERE tenant_id=$1`,
      tenantId,
    );
    const doc = await loaded(),
      before = await snapshot();
    await expect(
      cancelSalesOrder(runtime, { scope: scope(), vchNo: 1, expectedVersion: doc.version }),
    ).rejects.toThrow(/tagged order/);
    await expect(editSalesOrder(runtime, { ...replacement(doc), lines: [] }, 1)).rejects.toThrow(
      /tagged order item/,
    );
    expect(await snapshot()).toEqual(before);
  });

  // N59/G164: the order advance debits the book's slot-1 account, never the literal 'CASH'.
  it('refuses an order advance when the book has no configured settlement account, and still honours an explicit one', async () => {
    // Book S91 carries no BOOK_DETL slot 1. An advance with NO cashAc must be refused (fail-closed),
    // not posted to a non-existent 'CASH' ledger — and nothing is left behind.
    await expect(
      createSalesOrder(runtime, { ...input(), cashAc: undefined, advanceAmount: 100 }),
    ).rejects.toThrow();
    const orphan = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "SL_ORD_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as { n: number }[];
    expect(orphan[0]!.n).toBe(0);

    // An explicit account still wins (posts the advance Dr leg to that account).
    await createSalesOrder(runtime, { ...input(), cashAc: 'CASH', advanceAmount: 100 });
    const legs = (await owner.$queryRawUnsafe(
      `SELECT "AC_CODE" ac, "DR_AMT"::float dr FROM "AC_DATA" WHERE tenant_id=$1 AND "DR_AMT"::float=100`,
      tenantId,
    )) as { ac: string; dr: number }[];
    expect(legs.find((l) => l.ac === 'CASH')).toBeTruthy();
  });
});
