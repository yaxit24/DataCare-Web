import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { getCreditNote, listCreditNotes } from '../src/modules/einvoice/creditNote.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'credit-note-read-a';
const secondTenant = 'credit-note-read-b';
const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: '146' };
const variants = [
  scope,
  { ...scope, coBook: '147' },
  { ...scope, lcCode: '02' },
  { ...scope, coCode: '02' },
  { ...scope, coYear: '2025-2026' },
  { ...scope, tenantId: secondTenant },
];
const marker = (s: typeof scope) => Object.values(s).join('/');

(enabled ? describe : describe.skip)('E Credit Note complete scoped readers', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const clean = async () => {
    for (const table of ['SL_IDTL', 'SL_DETL', 'SL_DATA', 'E_DATA', 'BOOK_DATA'])
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        tenantId,
        secondTenant,
      );
  };
  beforeAll(async () => {
    for (const key of ['DATABASE_URL', 'MIGRATE_DATABASE_URL'])
      if (new URL(process.env[key] ?? 'invalid:').port !== '55433')
        throw new Error('Use the isolated database on55433.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean();
    const books = new Set<string>();
    for (const s of variants) {
      const bookKey = [s.tenantId, s.coCode, s.lcCode, s.coBook];
      if (!books.has(bookKey.join('/'))) {
        books.add(bookKey.join('/'));
        await owner.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
          VALUES($1,$2,$3,$4,'E CRNT','I','Y','SL_DATA')`,
          ...bookKey,
        );
      }
      const args = [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook];
      await owner.$executeRawUnsafe(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
        "VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","BILL_NO","NET_AMT","TOT_AMT","TAX_AMT","LDR_CODE")
        VALUES($1,$2,$3,$4,$5,'00001','2024-07-01','2024-07-01 15:16:17','PARTY',$6,'BILL%_1',0,0,NULL,$7)`,
        ...args,
        marker(s),
        s.coBook === '146' ? 'LEDGER001' : '',
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
        "SR_NO","OLD_SRNO","IT_CODE","ITM_REMARK","NET_AMT","HM_ID2","DESIGN_IMG_ID")
        VALUES($1,$2,$3,$4,$5,'00001',17,42,'GOLD','',0,'HALLMARK2','IMAGE42')`,
        ...args,
      );
      for (const [isr, name, weight] of [
        [3, 'Ruby', '0'],
        [9, 'Diamond', '0.123'],
      ] as const)
        await owner.$executeRawUnsafe(
          `INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
          "SR_NO","ISR_NO","IT_CODE","DM_NAME","IT_GWT") VALUES($1,$2,$3,$4,$5,'00001',42,$6,'STONE',$7,$8::numeric)`,
          ...args,
          isr,
          name,
          weight,
        );
      await owner.$executeRawUnsafe(
        `INSERT INTO "E_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IRN_NO","ACK_NO")
        VALUES($1,$2,$3,$4,$5,'00001',$6,'ACK')`,
        ...args,
        marker(s),
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
      VALUES($1,'01','01','SAL','SALES','O','Y','SL_DATA')`,
      tenantId,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_NAME")
      VALUES($1,'01','01','2024-2025','SAL','00001','SALE SENTINEL')`,
      tenantId,
    );
  });
  afterAll(async () => {
    if (owner) await clean();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('reads each company/branch/year/book/tenant independently, including original child identities', async () => {
    for (const s of variants) {
      const document = await getCreditNote(runtime, s, '1');
      expect(document!.header.AC_NAME).toBe(marker(s));
      expect(document!.header.VCH_DATE).toBe('2024-07-01');
      expect(document!.header.VCH_TIME).toBe('2024-07-01T15:16:17');
      expect(document!.header.NET_AMT).toBe(0);
      expect(document!.header.LDR_CODE).toBe(s.coBook === '146' ? 'LEDGER001' : '');
      expect(document!.header.TAX_AMT).toBeNull();
      expect(document!.lines[0]).toMatchObject({
        SR_NO: 17,
        OLD_SRNO: 42,
        ITM_REMARK: '',
        HM_ID2: 'HALLMARK2',
        DESIGN_IMG_ID: 'IMAGE42',
      });
      expect(
        document!.components.map((row) => [row.SR_NO, row.ISR_NO, row.parentSrNo, row.IT_GWT]),
      ).toEqual([
        [42, 3, 17, 0],
        [42, 9, 17, 0.123],
      ]);
      expect(document!.registration!.IRN_NO).toBe(marker(s));
      expect(document!.header).not.toHaveProperty('tenant_id');
      expect(document!.header).not.toHaveProperty('row_id');
    }
  });
  it('browses only the configured E CRNT family and searches wildcard characters literally', async () => {
    const result = await listCreditNotes(runtime, scope, { search: '%_', limit: 1 });
    expect(result.rows).toHaveLength(1);
    expect(result.rows[0]!.AC_NAME).toBe(marker(scope));
    expect(result.hasMore).toBe(false);
    expect((await listCreditNotes(runtime, scope, { offset: 1 })).rows).toHaveLength(0);
    expect((await listCreditNotes(runtime, scope, { search: 'SALE SENTINEL' })).rows).toHaveLength(
      0,
    );
    await expect(getCreditNote(runtime, { ...scope, coBook: 'SAL' }, '1')).rejects.toThrow(
      'active E Credit Note',
    );
    await expect(listCreditNotes(runtime, { ...scope, coYear: '' })).rejects.toThrow(
      'financial year',
    );
    await expect(listCreditNotes(runtime, scope, { limit: 101 })).rejects.toThrow('page');
    expect(await getCreditNote(runtime, scope, '999')).toBeNull();
  });
  it('refuses orphaned components without hiding them or joining across documents', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "SL_IDTL" SET "SR_NO"=999 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
      AND "CO_YEAR"='2024-2025' AND "CO_BOOK"='146' AND "ISR_NO"=9`,
      tenantId,
    );
    await expect(getCreditNote(runtime, scope, '1')).rejects.toThrow('no parent');
    await owner.$executeRawUnsafe(
      `UPDATE "SL_IDTL" SET "SR_NO"=42 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
      AND "CO_YEAR"='2024-2025' AND "CO_BOOK"='146' AND "ISR_NO"=9`,
      tenantId,
    );
  });
});
