import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import {
  getMfgLot,
  getMfgLotSettings,
  listMfgLots,
  listMfgLotSources,
} from '../src/modules/manufacturing/mfgLot.js';
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'lot-read-round3-a',
  secondTenant = 'lot-read-round3-b';
const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'I01' };
const variants = [
  scope,
  { ...scope, lcCode: '02' },
  { ...scope, coCode: '02' },
  { ...scope, coYear: '2025-2026' },
  { ...scope, tenantId: secondTenant },
];
const key = (s: typeof scope) => Object.values(s).join('/');
(enabled ? describe : describe.skip)(
  'configured lot manufacturing read and source profiles',
  () => {
    let owner: PrismaClient, runtime: PrismaClient;
    const clean = async () => {
      for (const table of [
        'MAIN_STOCK',
        'MFG_ISU_REC',
        'MFG_IDTL',
        'MFG_DETL',
        'MFG_DATA',
        'MFG_MAST',
        'BOOK_DATA',
        'AC_MAST',
        'ITEM_MAST',
      ])
        await owner.$executeRawUnsafe(
          `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
          tenantId,
          secondTenant,
        );
    };
    beforeAll(async () => {
      for (const name of ['DATABASE_URL', 'MIGRATE_DATABASE_URL'])
        if (new URL(process.env[name] ?? 'invalid:').port !== '55433')
          throw new Error('Use disposable55433 only.');
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await clean();
      const cols: any[] = await owner.$queryRawUnsafe(
        `SELECT column_name FROM information_schema.columns WHERE table_schema='public' AND table_name='MFG_IDTL' AND column_name='ITM_LOT'`,
      );
      expect(cols).toHaveLength(1);
      const books = new Set<string>(),
        stages = new Set<string>();
      for (const s of variants) {
        for (const [book, family, direction, code] of [
          ['I01', 'MFG STNG ISU', 'O', '11'],
          ['R01', 'MFG STNG REC', 'I', '12'],
          ['I02', 'MFG STNG ISU', 'O', '13'],
          ['R02', 'MFG STNG REC', 'I', '14'],
          ['POL', 'MFG POLISH ISU', 'O', '15'],
        ] as const) {
          const bkey = [s.tenantId, s.coCode, s.lcCode, book];
          if (!books.has(bkey.join('/'))) {
            books.add(bkey.join('/'));
            await owner.$executeRawUnsafe(
              `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_NAME","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")VALUES($1,$2,$3,$4,$5,$6,$7,'Y','MFG_DATA')`,
              ...bkey,
              family,
              `Custom ${book}`,
              direction,
            );
          }
          const skey = [s.tenantId, s.coCode, book];
          if (!stages.has(skey.join('/'))) {
            stages.add(skey.join('/'));
            await owner.$executeRawUnsafe(
              `INSERT INTO "MFG_MAST"(tenant_id,"CO_CODE","SM_MAIN_CODE","CO_BOOK","ENTRY_TYPE","LAST_TRAN","NEXT_TRAN","IN_OUT","STK_ISU","STK_REC")VALUES($1,$2,$3,$4,'S','S','P',$5,'Y','N')`,
              s.tenantId,
              s.coCode,
              code,
              book,
              direction,
            );
          }
        }
        const a = [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook];
        await owner.$executeRawUnsafe(
          `INSERT INTO "MFG_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","VCH_TIME","AC_CODE","BILL_NO","VCH_DESC","NET_AMT","TAX_AMT","CASH_AMT","CHQ_NO")VALUES($1,$2,$3,$4,$5,'00001','2024-07-01','2024-07-01 12:13:14.123456','KARIGAR','REF%_1',$6,9999999999999999.99,NULL,0,'')`,
          ...a,
          key(s),
        );
        await owner.$executeRawUnsafe(
          `INSERT INTO "MFG_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","IT_CODE","ISU_IT_CODE","TAG_NO","LOT_NO","REP_YRCD","REP_DBCD","REP_NO","REP_SRNO","REP_AC_CODE","ITM_REMARK","ITM_GWT","ITM_NWT","ITM_GHT_WT","ORD_NO")VALUES($1,$2,$3,$4,$5,'00001',17,42,'GOLD','METAL','TAG-17','PARENTLOT','2023-2024','SRC','00077',92,'SOURCEAC','',3.456,3.123,0,'0000099')`,
          ...a,
        );
        for (const [isr, weight] of [
          [3, '0'],
          [9, '0.123'],
        ] as const) {
          await owner.$executeRawUnsafe(
            `INSERT INTO "MFG_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_SRNO","IT_CODE","IT_GWT","RTN_GWT","BROK_WT")VALUES($1,$2,$3,$4,$5,'00001',17,$6,0,'STONE',$7::numeric,NULL,0)`,
            ...a,
            isr,
            weight,
          );
          await owner.$executeRawUnsafe(
            `UPDATE "MFG_IDTL" SET "ITM_LOT"=$7 WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "ISR_NO"=$6`,
            ...a,
            isr,
            `CHILD${isr}`,
          );
        }
        // Stock material groups combine signed movements across source years, preserving contributors.
        for (const [year, book, no, sign, pcs, gwt, nwt] of [
          ['2023-2024', 'PUR', '00011', '+', 5, 10, 9],
          ['2024-2025', 'I01', '00012', '-', 2, 3, 2.7],
        ] as const)
          await owner.$executeRawUnsafe(
            `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","AC_CODE","IT_CODE","ITM_LOT","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")VALUES($1,$2,$3,$4,$5,$6,17,3,'2024-06-01','STOCKAC','METAL','SAME-LOT','N',$7,$8,$9,$10)`,
            s.tenantId,
            s.coCode,
            s.lcCode,
            year,
            book,
            no,
            sign,
            pcs,
            gwt,
            nwt,
          );
      }
      // Receipt candidates use explicit historical issue identity, never active-year or lot-label alone.
      for (const sourceBook of ['I01', 'I02'])
        for (const sourceYear of ['2022-2023', '2023-2024']) {
          for (const [book, no, sign, pcs, gwt, nwt] of [
            [sourceBook, '00077', '-', 10, 10.5, 10],
            ['R01', sourceBook === 'I01' ? '00081' : '00082', '+', 6, 6.4, 6.1],
          ] as const) {
            await owner.$executeRawUnsafe(
              `INSERT INTO "MFG_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","IT_CODE","ISU_IT_CODE")VALUES($1,'01','01',$2,$3,$4,17,42,'GOLD','METAL')`,
              tenantId,
              sourceYear,
              book,
              no,
            );
            await owner.$executeRawUnsafe(
              `INSERT INTO "MFG_ISU_REC"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","AC_CODE","KR_AC_CODE","IT_CODE","ITM_LOT","LOT_NO","IR_TYPE","ITM_SIGN","IR_PCS","IR_WT","ITM_GWT","ITM_NWT","RTN_CHOL","ITM_LOSS","IR_LC","IR_YRCD","IR_DBCD","IR_NO","IR_SRNO","IR_AC")VALUES($1,'01','01',$2,$3,$4,17,1,'2024-06-01','KARIGAR','KARIGAR','METAL','SAME-LOT','WORK-TAG','S',$5,$6,$7,$7,$8,0.7,0.2,'01',$2,$9,'00077',42,'KARIGAR')`,
              tenantId,
              sourceYear,
              book,
              no,
              sign,
              pcs,
              gwt,
              nwt,
              sourceBook,
            );
          }
        }
    });
    afterAll(async () => {
      if (owner) await clean();
      await runtime?.$disconnect();
      await owner?.$disconnect();
    });
    it('retains exact saved values and separate parent/source/component identities in every scope', async () => {
      for (const s of variants) {
        const doc = await getMfgLot(runtime, s, 'issue', '1');
        expect(doc!.header.VCH_DESC).toBe(key(s));
        expect(doc!.header.NET_AMT).toBe('9999999999999999.99');
        expect(doc!.header.TAX_AMT).toBeNull();
        expect(doc!.header.CASH_AMT).toBe('0.00');
        expect(doc!.header.CHQ_NO).toBe('');
        expect(doc!.header.VCH_TIME).toBe('2024-07-01T12:13:14.123456');
        expect(doc!.header).not.toHaveProperty('tenant_id');
        expect(doc!.lines[0]).toMatchObject({
          SR_NO: '17',
          OLD_SRNO: '42',
          REP_SRNO: '92',
          LOT_NO: 'PARENTLOT',
          TAG_NO: 'TAG-17',
          ITM_NWT: '3.123',
          ORD_NO: '0000099',
        });
        expect(doc!.components.map((c) => [c.SR_NO, c.ISR_NO, c.VCH_SRNO, c.IT_GWT])).toEqual([
          ['17', '3', '0', '0.000'],
          ['17', '9', '0', '0.123'],
        ]);
        expect(doc!.components.map((c) => c.ITM_LOT)).toEqual(['CHILD3', 'CHILD9']);
        expect(doc!.settings.writes).toBe(false);
        expect(doc!.version).toMatch(/^[a-f0-9]{64}$/);
        expect((await getMfgLot(runtime, s, 'issue', '1'))!.version).toBe(doc!.version);
      }
    });
    it('resolves exact imported keys before numeric padding and preserves six/eight-character references', async () => {
      for (const no of ['1', '123456', 'ABC12345'])
        await owner.$executeRawUnsafe(
          `INSERT INTO "MFG_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DESC") VALUES($1,'01','01','2024-2025','I01',$2,$3)`,
          tenantId,
          no,
          `Exact ${no}`,
        );
      try {
        for (const no of ['1', '123456', 'ABC12345']) {
          const document = await getMfgLot(runtime, scope, 'issue', no);
          expect(document!.header.VCH_NO).toBe(no);
          expect(document!.header.VCH_DESC).toBe(`Exact ${no}`);
          expect(document!.lines).toEqual([]);
        }
        expect((await getMfgLot(runtime, scope, 'issue', '00001'))!.components).toHaveLength(2);
        for (const invalid of ['', '123456789', 'A\nB', '\u00001'])
          await expect(getMfgLot(runtime, scope, 'issue', invalid)).rejects.toThrow(
            'saved voucher reference',
          );
      } finally {
        await owner.$executeRawUnsafe(
          `DELETE FROM "MFG_DATA" WHERE tenant_id=$1 AND "VCH_NO" IN ('1','123456','ABC12345')`,
          tenantId,
        );
      }
      expect((await getMfgLot(runtime, scope, 'issue', '1'))!.header.VCH_NO).toBe('00001');
    });
    it('shows scoped current names separately without changing raw saved values or version on master rename', async () => {
      for (const [tenant, company, branch, code, name] of [
        [tenantId, '01', '01', 'KARIGAR', 'Selected branch karigar'],
        [tenantId, '01', '', 'KARIGAR', 'Company fallback karigar'],
        [tenantId, '01', '02', 'KARIGAR', 'OTHER BRANCH SENTINEL'],
        [tenantId, '01', '02', 'SOURCEAC', 'UNRELATED SOURCE SENTINEL'],
        [tenantId, '01', null, 'STOCKAC', 'Company stock account'],
        [tenantId, '02', '01', 'KARIGAR', 'OTHER COMPANY SENTINEL'],
        [secondTenant, '01', '01', 'KARIGAR', 'OTHER TENANT SENTINEL'],
      ])
        await owner.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")VALUES($1,$2,$3,$4,$5)`,
          tenant,
          company,
          branch,
          code,
          name,
        );
      for (const [tenant, company, code, name] of [
        [tenantId, '01', 'GOLD', 'Current gold item'],
        [tenantId, '01', 'METAL', 'Current metal item'],
        [tenantId, '01', 'STONE', 'Current stone component'],
        [tenantId, '02', 'GOLD', 'OTHER COMPANY ITEM SENTINEL'],
        [secondTenant, '01', 'GOLD', 'OTHER TENANT ITEM SENTINEL'],
      ])
        await owner.$executeRawUnsafe(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME")VALUES($1,$2,$3,$4)`,
          tenant,
          company,
          code,
          name,
        );
      try {
        const saved = (await getMfgLot(runtime, scope, 'issue', '1'))!;
        expect(saved.displayLabels).toMatchObject({
          accounts: { KARIGAR: 'Selected branch karigar', SOURCEAC: null },
          items: {
            GOLD: 'Current gold item',
            METAL: 'Current metal item',
            STONE: 'Current stone component',
          },
        });
        expect(saved.header.AC_CODE).toBe('KARIGAR');
        expect(saved.header).not.toHaveProperty('AC_NAME');
        expect(saved.lines[0]!.IT_CODE).toBe('GOLD');
        expect(saved.lines[0]).not.toHaveProperty('IT_NAME');
        expect(
          (await getMfgLot(runtime, { ...scope, lcCode: '02' }, 'issue', '1'))!.displayLabels
            .accounts.KARIGAR,
        ).toBe('OTHER BRANCH SENTINEL');
        expect((await listMfgLots(runtime, scope, 'issue')).displayLabels.accounts.KARIGAR).toBe(
          'Selected branch karigar',
        );
        const stock = await listMfgLotSources(runtime, scope, 'issue');
        expect(stock.displayLabels).toMatchObject({
          accounts: { STOCKAC: 'Company stock account' },
          items: { METAL: 'Current metal item' },
        });
        const receipt = await listMfgLotSources(runtime, { ...scope, coBook: 'R01' }, 'receive', {
          acCode: 'KARIGAR',
          sourceBook: 'I01',
        });
        expect(receipt.displayLabels.accounts.KARIGAR).toBe('Selected branch karigar');
        await owner.$executeRawUnsafe(
          `UPDATE "AC_MAST" SET "AC_NAME"='Renamed karigar' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "AC_CODE"='KARIGAR'`,
          tenantId,
        );
        await owner.$executeRawUnsafe(
          `UPDATE "ITEM_MAST" SET "IT_NAME"='Renamed gold item' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"='GOLD'`,
          tenantId,
        );
        const renamed = (await getMfgLot(runtime, scope, 'issue', '1'))!;
        expect(renamed.displayLabels.accounts.KARIGAR).toBe('Renamed karigar');
        expect(renamed.displayLabels.items.GOLD).toBe('Renamed gold item');
        const { displayLabels: oldLabels, ...originalSnapshot } = saved;
        const { displayLabels: newLabels, ...renamedSnapshot } = renamed;
        expect(newLabels).not.toEqual(oldLabels);
        expect(renamedSnapshot).toEqual(originalSnapshot);
        await owner.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")VALUES($1,'01','01','KARIGAR','Conflicting current name')`,
          tenantId,
        );
        expect(
          (await getMfgLot(runtime, scope, 'issue', '1'))!.displayLabels.accounts.KARIGAR,
        ).toBeNull();
      } finally {
        for (const table of ['AC_MAST', 'ITEM_MAST'])
          await owner.$executeRawUnsafe(
            `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
            tenantId,
            secondTenant,
          );
      }
    });
    it('browses one exact book/year and treats operator search wildcards literally', async () => {
      const page = await listMfgLots(runtime, scope, 'issue', { search: '%_', limit: 1 });
      expect(page.rows).toHaveLength(1);
      expect(page.rows[0]!.VCH_DESC).toBe(key(scope));
      expect(page.hasMore).toBe(false);
      expect((await listMfgLots(runtime, scope, 'issue', { offset: 1 })).rows).toHaveLength(0);
      expect(await getMfgLot(runtime, scope, 'issue', '999')).toBeNull();
      await expect(listMfgLots(runtime, scope, 'issue', { limit: 101 })).rejects.toThrow('page');
      await expect(getMfgLot(runtime, { ...scope, coBook: 'R01' }, 'issue', '1')).rejects.toThrow(
        'Setting issue',
      );
      await expect(getMfgLot(runtime, { ...scope, coBook: 'POL' }, 'issue', '1')).rejects.toThrow(
        'Setting issue',
      );
    });
    it('exposes stock gross availability with historical contributors, isolated by branch/company/tenant', async () => {
      const result = await listMfgLotSources(runtime, scope, 'issue', { search: 'SAME-LOT' });
      expect(result.rows).toHaveLength(1);
      const source: any = result.rows[0];
      // Two active-year fixtures share this physical scope; source-year changes do not clone inventory identity.
      expect(source.remainingWeight).toBe('14.000');
      expect(source.remainingNetWeight).toBe('12.600');
      expect(source.remainingPieces).toBe('6.000');
      expect(source.availabilityBasis).toBe('gross-weight');
      expect(source.identity).toMatchObject({
        coCode: '01',
        lcCode: '01',
        materialLot: 'SAME-LOT',
        itemCode: 'METAL',
      });
      expect(source.contributors).toHaveLength(4);
      expect(new Set(source.contributors.map((r: any) => r.stockRowId)).size).toBe(4);
      expect(source.sourceDate).toBe('2024-06-01');
      expect(new Set(source.contributors.map((r: any) => r.CO_YEAR))).toEqual(
        new Set(['2023-2024', '2024-2025']),
      );
      expect(source.contributors.every((r: any) => r.CO_CODE === '01' && r.LC_CODE === '01')).toBe(
        true,
      );
      const other = await listMfgLotSources(runtime, { ...scope, lcCode: '02' }, 'issue');
      expect(other.rows[0]).toMatchObject({ remainingWeight: '7.000', remainingPieces: '3.000' });
    });
    it('keeps repeated receipt material labels separate by source book/year/old row and uses pieces, not loss-adjusted weight', async () => {
      const receive = { ...scope, coBook: 'R01' };
      const sources = await listMfgLotSources(runtime, receive, 'receive', {
        acCode: 'KARIGAR',
        sourceBook: 'I01',
      });
      expect(sources.rows).toHaveLength(2);
      for (const source of sources.rows as any[]) {
        expect(source).toMatchObject({
          sourceBook: 'I01',
          sourceVoucher: '00077',
          sourceOldSrNo: '42',
          sourceAccount: 'KARIGAR',
          materialLot: 'SAME-LOT',
          remainingPieces: '4.000',
          remainingWeight: '4.100',
          remainingNetWeight: '3.900',
          availabilityBasis: 'pieces',
          advisory: true,
        });
        expect(source.contributors).toHaveLength(2);
        expect(source.contributors.map((r: any) => r.ISR_NO)).toEqual(['1', '1']);
      }
      expect(new Set(sources.rows.map((r: any) => r.sourceYear))).toEqual(
        new Set(['2022-2023', '2023-2024']),
      );
      expect(new Set(sources.rows.map((r) => r.key)).size).toBe(2);
      const second = await listMfgLotSources(runtime, receive, 'receive', {
        acCode: 'KARIGAR',
        sourceBook: 'I02',
      });
      expect(second.rows).toHaveLength(2);
      expect(second.rows.every((r: any) => r.sourceBook === 'I02')).toBe(true);
      expect(
        (
          await listMfgLotSources(runtime, receive, 'receive', {
            acCode: 'OTHER',
            sourceBook: 'I01',
          })
        ).rows,
      ).toHaveLength(0);
      await expect(
        listMfgLotSources(runtime, receive, 'receive', { acCode: 'KARIGAR', sourceBook: 'POL' }),
      ).rejects.toThrow('source book');
      await expect(
        listMfgLotSources(runtime, receive, 'receive', { acCode: 'KARIGAR' }),
      ).rejects.toThrow('source book');
      await expect(
        listMfgLotSources(runtime, receive, 'receive', {
          sourceKind: 'stock-material',
          acCode: 'KARIGAR',
          sourceBook: 'I01',
        }),
      ).rejects.toThrow('source kind');
    });
    it('retains saved reads but disables source selection for missing or ambiguous stage configuration', async () => {
      await owner.$executeRawUnsafe(
        `INSERT INTO "MFG_MAST"(tenant_id,"CO_CODE","SM_MAIN_CODE","CO_BOOK","ENTRY_TYPE")VALUES($1,'01','99','I01','S')`,
        tenantId,
      );
      try {
        const config = await getMfgLotSettings(runtime, scope, 'issue');
        expect(config.sourceSelection).toBe(false);
        expect(config.stage).toBeNull();
        expect(config.stages).toHaveLength(2);
        expect(await getMfgLot(runtime, scope, 'issue', '1')).not.toBeNull();
        await expect(listMfgLotSources(runtime, scope, 'issue')).rejects.toThrow('unambiguous');
      } finally {
        await owner.$executeRawUnsafe(
          `DELETE FROM "MFG_MAST" WHERE tenant_id=$1 AND "SM_MAIN_CODE"='99'`,
          tenantId,
        );
      }
    });
    it('does not silently attach an orphan component to OLD_SRNO or a neighbouring document', async () => {
      await owner.$executeRawUnsafe(
        `UPDATE "MFG_IDTL" SET "SR_NO"=42 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"='2024-2025' AND "CO_BOOK"='I01' AND "ISR_NO"=9`,
        tenantId,
      );
      try {
        await expect(getMfgLot(runtime, scope, 'issue', '1')).rejects.toThrow('exact parent');
      } finally {
        await owner.$executeRawUnsafe(
          `UPDATE "MFG_IDTL" SET "SR_NO"=17 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"='2024-2025' AND "CO_BOOK"='I01' AND "ISR_NO"=9`,
          tenantId,
        );
      }
    });
  },
);
