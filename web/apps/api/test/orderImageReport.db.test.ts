import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { bindReport } from '../src/modules/reports/reportBind.js';
import { loadReportSpec, renderReportLayout } from '../src/modules/reports/reportEngine.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenants = ['order-img-report-a', 'order-img-report-b'];
const base = { tenantId: tenants[0]!, coCode: '91', lcCode: '01', coYear: '2026-2027' };
const scopes = [base, { ...base, tenantId: tenants[1]! }, { ...base, coCode: '92' },
  { ...base, lcCode: '02' }, { ...base, coYear: '2027-2028' }];
const families = [
  { report: 'OrdVchImg', coBook: 'S91', orderFamily: 'SALES ORDER' as const, direction: 'O' },
  { report: 'TourOrdImg', coBook: 'T91', orderFamily: 'TOUR ORDER' as const, direction: 'I' },
];
const red = readFileSync(new URL('./fixtures/order-design-portrait.png', import.meta.url));
const blue = readFileSync(new URL('./fixtures/order-tag-landscape.jpg', import.meta.url));
const imageId = (coCode: string) => `${coCode}_CATALOG-BOOK-LONG_A1_DESIGN-0001`;
const companyMatchesBase = (s: typeof base) => s.tenantId === base.tenantId && s.coCode === base.coCode;
const tagMatchesBase = (s: typeof base) => companyMatchesBase(s) && s.lcCode === base.lcCode;

// These are real saved tag/design identities. No IMAGE_DATA print staging or bare-design fallback is seeded.
databaseDescribe('image report binding from saved scoped order identities', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const cleanup = async () => {
    for (const table of ['SL_PR_DETL', 'SL_ORD_IDTL', 'SL_ORD_DETL', 'SL_ORD_DATA', 'AC_DATA',
      'ENTITY_IMAGE', 'TAG_IMAGE_DATA', 'DESIGN_DETL', 'ITEM_MAST', 'BOOK_DATA', 'CO_SET_NEW', 'CO_MAST'])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`, ...tenants);
  };
  const image = async (s: typeof base, type: string, key: string, instance: number, bytes: Buffer) => {
    await owner.$executeRawUnsafe(`INSERT INTO "ENTITY_IMAGE"
      (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES")
      VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10)`,
      s.tenantId, s.coCode, type === 'DESIGN' ? '' : s.lcCode, type, key, instance,
      type === 'DESIGN' ? 'D' : 'T', bytes === red ? 'image/png' : 'image/jpeg', bytes.length, bytes);
    if (type === 'TAG')
      await owner.$executeRawUnsafe(`INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE")
        VALUES($1,$2,$3,$4,$5,'T')`, s.tenantId, s.coCode, s.lcCode, key, instance);
  };
  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433') throw new Error('Image report fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanup();
    const companies = new Set<string>(), branches = new Set<string>();
    for (const s of scopes) {
      const coKey = JSON.stringify([s.tenantId, s.coCode]);
      if (!companies.has(coKey)) {
        companies.add(coKey);
        await owner.$executeRawUnsafe('INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES($1,$2,$3)', s.tenantId, s.coCode, coKey);
        await owner.$executeRawUnsafe('INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","ORD_IMG_PRINT") VALUES($1,$2,\'Y\')', s.tenantId, s.coCode);
        await owner.$executeRawUnsafe(`INSERT INTO "DESIGN_DETL"(tenant_id,"CO_CODE","BOOK_NAME","PR_CODE","SR_NO","DESIGN_NO","DESIGN_IMG_ID")
          VALUES($1,$2,'CATALOG-BOOK-LONG','A1',1,'DESIGN-0001',$3)`, s.tenantId, s.coCode, imageId(s.coCode));
        await image(s, 'DESIGN', imageId(s.coCode), 0, companyMatchesBase(s) ? red : blue);
        for (const [code, name] of [['GOLD', 'Gold ring'], ['RUBY', 'Ruby component'], ['DIAM', 'Diamond component']])
          await owner.$executeRawUnsafe('INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES($1,$2,$3,$4)', s.tenantId, s.coCode, code, name);
      }
      const branch = JSON.stringify([s.tenantId, s.coCode, s.lcCode]);
      if (!branches.has(branch)) {
        branches.add(branch);
        await image(s, 'TAG', 'TAG-001', 1, tagMatchesBase(s) ? blue : red);
        await image(s, 'TAG', 'TAG-001', 2, tagMatchesBase(s) ? red : blue);
        for (const family of families)
          await owner.$executeRawUnsafe(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","CUR_USE")
            VALUES($1,$2,$3,$4,$5,$5,$6,'SL_ORD_DATA','Y')`, s.tenantId, s.coCode, s.lcCode, family.coBook, family.orderFamily, family.direction);
      }
      for (const family of families) {
        const key = [s.tenantId, s.coCode, s.lcCode, s.coYear, family.coBook];
        await owner.$executeRawUnsafe(`INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO",
          "VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","NET_AMT","TOT_AMT","TAX_AMT")
          VALUES($1,$2,$3,$4,$5,'00001','00001','2026-04-03','2026-04-03 12:00:00','PARTY',$6,600,600,0)`, ...key, `${family.report} ${s.tenantId}/${s.coCode}/${s.lcCode}/${s.coYear}`);
        for (const sr of [1, 2, 3])
          await owner.$executeRawUnsafe(`INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO","SR_NO", "IT_CODE",
            "TAG_NO","VCH_SRNO","DESIGN_NO","DESIGN_IMG_ID","ITM_PCS","ITM_GWT","ITM_NWT","NET_AMT")
            VALUES($1,$2,$3,$4,$5,'00001','00001',$6,'GOLD',$7,$8,'DESIGN-0001',$9,1,$6::numeric,$6::numeric,$10::numeric)`,
            ...key, sr, sr === 3 ? '' : 'TAG-001', sr === 3 ? 0 : sr, sr === 1 ? imageId(s.coCode) : 'N', sr * 100);
        for (const [isr, item, weight] of [[1, 'RUBY', '0.101'], [2, 'DIAM', '0.202']])
          await owner.$executeRawUnsafe(`INSERT INTO "SL_ORD_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","IT_PCS","IT_GWT")
            VALUES($1,$2,$3,$4,$5,'00001',1,$6,$7,1,$8::numeric)`, ...key, isr, item, weight);
      }
    }
  });
  afterAll(async () => { if (owner) await cleanup(); await runtime?.$disconnect(); await owner?.$disconnect(); });

  it.each(families)('binds $report images by actual saved scope and source precedence without fanout', async (family) => {
    for (const s of scopes) {
      const spec = loadReportSpec(family.report)!;
      const bound = await bindReport(runtime, spec, { ...s, ...family, vchNo: 1 });
      expect(bound?.header['SL_ORD_DATA.CO_YEAR']).toBe(s.coYear);
      expect(bound?.detailRows).toHaveLength(3);
      expect(bound?.parentChild?.groups.map((group) => group.children.length)).toEqual([2, 0, 0]);
      expect(bound?.orderImages?.['1']).toMatchObject({ state: 'present', bytes: family.orderFamily === 'SALES ORDER'
        ? companyMatchesBase(s) ? red : blue : tagMatchesBase(s) ? blue : red });
      expect(bound?.orderImages?.['2']).toMatchObject({ state: 'present', bytes: tagMatchesBase(s) ? red : blue });
      expect(bound?.orderImages?.['3']).toEqual({ state: 'absent' });
      const html = renderReportLayout(spec, bound!);
      expect(html.match(/<img /g)).toHaveLength(2);
      expect(html.match(/data-section="Section17"/g)).toHaveLength(3);
      expect(html.match(/data-field="\{SL_ORD_DETL.NET_AMT\}"[^>]*>100<\/div>/g)).toHaveLength(1);
      expect(html).toContain('class="order-object order-image-absent" data-parent="3"');
      expect(bound?.header['#RTotal0']).toBe('6');
    }
  });

  it('keeps custom images separate across complete saved year/book/branch/company/tenant identities', async () => {
    try {
      for (const s of scopes) {
        for (const family of families) {
          const key = JSON.stringify([s.coYear, family.coBook, '00001', 'DESIGN-0001']);
          const expected = tagMatchesBase(s) && s.coYear === base.coYear && family.coBook === 'S91' ? red : blue;
          await image(s, 'ORDER', key, 0, expected);
        }
      }
      for (const s of scopes) {
        for (const family of families) {
          const expected = tagMatchesBase(s) && s.coYear === base.coYear && family.coBook === 'S91' ? red : blue;
          const bound = await bindReport(runtime, loadReportSpec(family.report)!, { ...s, ...family, vchNo: 1 });
          expect(bound?.orderImages?.['3']).toMatchObject({ state: 'present', source: 'ORDER', bytes: expected });
          const html = renderReportLayout(loadReportSpec(family.report)!, bound!);
          expect(html.match(/<img /g)).toHaveLength(3);
          expect(html).toContain(`data:${expected === red ? 'image/png' : 'image/jpeg'};base64,${expected.toString('base64')}`);
        }
      }
    } finally {
      await owner.$executeRawUnsafe(`DELETE FROM "ENTITY_IMAGE" WHERE tenant_id IN ($1,$2) AND "ENTITY_TYPE"='ORDER'`, ...tenants);
    }
  });

  it('reports unavailable indexed bytes and malformed bytes explicitly', async () => {
    const scope = { ...base, ...families[1]!, vchNo: 1 };
    const select = `tenant_id=$1 AND "CO_CODE"='91' AND "LC_CODE"='01' AND "ENTITY_TYPE"='TAG' AND "ENTITY_KEY"='TAG-001' AND "INSTANCE"=2`;
    const snapshot = await owner.$queryRawUnsafe<any[]>(`DELETE FROM "ENTITY_IMAGE" WHERE ${select} RETURNING *`, base.tenantId);
    try {
      await expect(bindReport(runtime, loadReportSpec('TourOrdImg')!, scope)).rejects.toMatchObject({ reason: 'order-image:unavailable-image' });
    } finally {
      const saved = snapshot[0]!;
      await owner.$executeRawUnsafe(`INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES")
        VALUES($1,'91','01','TAG','TAG-001',2,'T',$2,$3,$4)`, base.tenantId, saved.MIME_TYPE, saved.IMAGE_SIZE, saved.IMAGE_BYTES);
    }
    try {
      // Correct PNG magic with no image payload: magic-only acceptance must not pass the resolver.
      await owner.$executeRawUnsafe(`UPDATE "ENTITY_IMAGE" SET "IMAGE_BYTES"=$2,"IMAGE_SIZE"=8,"MIME_TYPE"='image/png' WHERE ${select}`, base.tenantId, red.subarray(0, 8));
      await expect(bindReport(runtime, loadReportSpec('TourOrdImg')!, scope)).rejects.toMatchObject({ reason: 'order-image:invalid-image' });
    } finally {
      await owner.$executeRawUnsafe(`UPDATE "ENTITY_IMAGE" SET "IMAGE_BYTES"=$2,"IMAGE_SIZE"=$3,"MIME_TYPE"='image/png' WHERE ${select}`, base.tenantId, red, red.length);
    }
  });

  it('uses one snapshot for image bytes and the company image-selection flag', async () => {
    const scope = { ...base, ...families[1]!, vchNo: 1 };
    const change = async (bytes: Buffer, flag: string) => owner.$transaction(async (tx) => {
      await tx.$executeRawUnsafe(`UPDATE "ENTITY_IMAGE" SET "IMAGE_BYTES"=$2,"IMAGE_SIZE"=$3,"MIME_TYPE"=$4 WHERE tenant_id=$1 AND "CO_CODE"='91'
        AND "LC_CODE"='01' AND "ENTITY_TYPE"='TAG' AND "ENTITY_KEY"='TAG-001' AND "INSTANCE"=1`,
        base.tenantId, bytes, bytes.length, bytes === red ? 'image/png' : 'image/jpeg');
      await tx.$executeRawUnsafe('UPDATE "CO_SET_NEW" SET "ORD_IMG_PRINT"=$2 WHERE tenant_id=$1 AND "CO_CODE"=\'91\'', base.tenantId, flag);
    });
    let edited = false;
    const concurrent = { $transaction: (fn: (tx: any) => Promise<unknown>, options: any) => runtime.$transaction((tx) => fn(new Proxy(tx, {
      get(target, property) {
        if (property !== '$queryRawUnsafe') return Reflect.get(target, property);
        return async (sql: string, ...params: unknown[]) => {
          const rows = await target.$queryRawUnsafe(sql, ...params);
          if (!edited && sql.startsWith('SELECT *') && sql.includes(' FROM "SL_ORD_DATA"')) { edited = true; await change(red, 'N'); }
          return rows;
        };
      },
    })), options) };
    try {
      const old = await bindReport(concurrent, loadReportSpec('TourOrdImg')!, scope);
      expect(edited).toBe(true);
      expect(old?.orderImages?.['1']).toMatchObject({ state: 'present', bytes: blue });
      await expect(bindReport(runtime, loadReportSpec('TourOrdImg')!, scope))
        .rejects.toMatchObject({ report: 'TourOrdVch', reason: 'order-image-template-mismatch' });
      await change(red, 'Y');
      const current = await bindReport(runtime, loadReportSpec('TourOrdImg')!, scope);
      expect(current?.orderImages?.['1']).toMatchObject({ state: 'present', bytes: red });
    } finally { await change(blue, 'Y'); }
  });
});
