import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { orderData, orderHtml } from '../src/modules/sales/orderDoc.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;

databaseDescribe('order confirmation full desktop document identity', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
  });
  const runtime = new PrismaClient();
  const tenant = 'order-document-parity';
  const foreignTenant = 'order-document-other';
  const base = {
    tenantId: tenant,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'Z09',
    vchNo: 1,
  };
  const dimensions = [
    base,
    { ...base, tenantId: foreignTenant },
    { ...base, coCode: '02' },
    { ...base, lcCode: '02' },
    { ...base, coYear: '2025-2026' },
    { ...base, coBook: '510' },
  ];
  async function cleanup() {
    for (const table of ['SL_ORD_DETL', 'SL_ORD_DATA', 'AC_MAST', 'CO_MAST', 'BOOK_DATA']) {
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        tenant,
        foreignTenant,
      );
    }
  }
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    await cleanup();
    const seenBooks = new Set<string>();
    for (const [index, s] of dimensions.entries()) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "SL_ORD_DATA" (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","AC_NAME","VCH_DATE","DEL_DATE","TOT_AMT")
         VALUES ($1,$2,$3,$4,$5,'00001','PARTY',$6,'2024-04-03','2024-04-09',125.75)`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        s.coBook,
        `Header ${index}`,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "SL_ORD_DETL" (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","ITM_REMARK","NET_AMT")
         VALUES ($1,$2,$3,$4,$5,'00001',1,'GOLD',$6,125.75)`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        s.coBook,
        `Line ${index}`,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "CO_MAST" (tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,$3) ON CONFLICT DO NOTHING`,
        s.tenantId,
        s.coCode,
        `Company ${s.tenantId}/${s.coCode}`,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST" (tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
         VALUES ($1,$2,$3,'PARTY',$4) ON CONFLICT DO NOTHING`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        `Party ${s.tenantId}/${s.coCode}/${s.lcCode}`,
      );
      const bookKey = JSON.stringify([s.tenantId, s.coCode, s.lcCode, s.coBook]);
      if (!seenBooks.has(bookKey)) {
        seenBooks.add(bookKey);
        await owner.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","CUR_USE")
           VALUES ($1,$2,$3,$4,$5,$6,'SL_ORD_DATA','Y')`,
          s.tenantId,
          s.coCode,
          s.lcCode,
          s.coBook,
          s.coBook === '510' ? 'TOUR ORDER' : 'SALES ORDER',
          s.coBook === '510' ? 'I' : 'O',
        );
      }
    }
  });
  afterAll(async () => {
    await cleanup();
    await runtime.$disconnect();
    await owner.$disconnect();
  });

  it('returns only the requested header, lines, company and branch-specific party for repeated numbers', async () => {
    for (const [index, s] of dimensions.entries()) {
      const document = await orderData(runtime, s);
      expect(document?.header.AC_NAME).toBe(`Header ${index}`);
      expect(document?.lines.map((line) => line.ITM_REMARK)).toEqual([`Line ${index}`]);
      expect(document?.company.CO_NAME).toBe(`Company ${s.tenantId}/${s.coCode}`);
      expect(document?.party.AC_NAME).toBe(`Party ${s.tenantId}/${s.coCode}/${s.lcCode}`);
    }
    expect(await orderData(runtime, { ...base, lcCode: '99' })).toBeNull();
    expect(await orderData(runtime, { ...base, vchNo: 2 })).toBeNull();
  });

  it('refuses incomplete identity before querying the database', async () => {
    for (const field of Object.keys(base)) {
      await expect(orderData({}, { ...base, [field]: '' })).rejects.toThrow(`requires ${field}`);
    }
  });

  it('requires the route-selected active book family without hard-coding the sales book code', async () => {
    expect((await orderData(runtime, { ...base, family: 'SALES ORDER' }))?.header.CO_BOOK).toBe(
      'Z09',
    );
    expect(
      (await orderData(runtime, { ...base, coBook: '510', family: 'TOUR ORDER' }))?.header.CO_BOOK,
    ).toBe('510');
    await expect(orderData(runtime, { ...base, family: 'TOUR ORDER' })).rejects.toThrow(
      'expected TOUR ORDER',
    );
    await expect(
      orderData(runtime, { ...base, coBook: '510', family: 'SALES ORDER' }),
    ).rejects.toThrow('expected SALES ORDER');
  });

  it('refuses inactive, unclassified, wrong-table and duplicate order book configurations', async () => {
    const where = 'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4';
    const key = [base.tenantId, base.coCode, base.lcCode, base.coBook];
    try {
      await owner.$executeRawUnsafe(`UPDATE "BOOK_DATA" SET "CUR_USE"='N' WHERE ${where}`, ...key);
      await expect(orderData(runtime, { ...base, family: 'SALES ORDER' })).rejects.toThrow(
        'book not found',
      );
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "CUR_USE"='Y',"MAIN_BOOK"='' WHERE ${where}`,
        ...key,
      );
      await expect(orderData(runtime, { ...base, family: 'SALES ORDER' })).rejects.toThrow(
        'no configured workflow family',
      );
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "MAIN_BOOK"='SALES ORDER',"BOOK_TBL_NAME"='SL_DATA' WHERE ${where}`,
        ...key,
      );
      await expect(orderData(runtime, { ...base, family: 'SALES ORDER' })).rejects.toThrow(
        'expected SL_ORD_DATA',
      );
    } finally {
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "CUR_USE"='Y',"MAIN_BOOK"='SALES ORDER',"BOOK_TBL_NAME"='SL_ORD_DATA' WHERE ${where}`,
        ...key,
      );
    }
    const duplicate = await owner.$queryRawUnsafe<{ row_id: bigint }[]>(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT") VALUES ($1,$2,$3,$4,'SALES ORDER','O') RETURNING row_id`,
      ...key,
    );
    try {
      await expect(orderData(runtime, { ...base, family: 'SALES ORDER' })).rejects.toThrow(
        'book configuration is ambiguous',
      );
    } finally {
      await owner.$executeRawUnsafe(
        'DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND row_id=$2',
        base.tenantId,
        duplicate[0]!.row_id,
      );
    }
  });

  it('prints actual database dates as calendar dates', async () => {
    const document = (await orderData(runtime, { ...base, family: 'SALES ORDER' }))!;
    expect(document.header.VCH_DATE).toBeInstanceOf(Date);
    const html = orderHtml(document.header, document.lines, document);
    expect(html).toContain('03/04/2024'); // N56 (D19): the print shows dd/MM/yyyy
    expect(html).toContain('09/04/2024');
    expect(html).not.toContain('Wed Apr');
    expect(html).not.toContain('Tue Apr');
  });

  it('keeps header and lines in one snapshot across an intervening committed edit', async () => {
    const where =
      'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6';
    const key = [base.tenantId, base.coCode, base.lcCode, base.coYear, base.coBook, '00001'];
    const change = (amount: string) =>
      owner.$transaction(async (tx) => {
        await tx.$executeRawUnsafe(
          `UPDATE "SL_ORD_DATA" SET "TOT_AMT"=$7::numeric WHERE ${where}`,
          ...key,
          amount,
        );
        await tx.$executeRawUnsafe(
          `UPDATE "SL_ORD_DETL" SET "NET_AMT"=$7::numeric WHERE ${where}`,
          ...key,
          amount,
        );
      });
    let editCommitted = false;
    const concurrentRuntime = {
      $transaction: (fn: (tx: any) => Promise<unknown>, options: any) =>
        runtime.$transaction(
          (tx) =>
            fn(
              new Proxy(tx, {
                get(target, property) {
                  if (property !== '$queryRawUnsafe') return Reflect.get(target, property);
                  return async (sql: string, ...args: unknown[]) => {
                    const rows = await target.$queryRawUnsafe(sql, ...args);
                    if (!editCommitted && sql.startsWith('SELECT * FROM "SL_ORD_DATA"')) {
                      editCommitted = true;
                      await change('987.65');
                    }
                    return rows;
                  };
                },
              }),
            ),
          options,
        ),
    };
    try {
      const document = (await orderData(concurrentRuntime, { ...base, family: 'SALES ORDER' }))!;
      expect(editCommitted).toBe(true);
      expect(String(document.header.TOT_AMT)).toBe('125.75');
      expect(String(document.lines[0].NET_AMT)).toBe('125.75');
      const updated = (await orderData(runtime, { ...base, family: 'SALES ORDER' }))!;
      expect(String(updated.header.TOT_AMT)).toBe('987.65');
      expect(String(updated.lines[0].NET_AMT)).toBe('987.65');
    } finally {
      await change('125.75');
    }
  });
});
