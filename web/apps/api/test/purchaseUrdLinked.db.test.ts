import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createPurchase,
  deletePurchase,
  editPurchase,
  getPurchase,
} from '../src/modules/purchase/purchase.js';
import {
  getUrdBookSettingsTx,
  isUrdPurchaseBookTx,
  resolveUrdPurchaseBookTx,
  saveUrdBookSettingsTx,
  UrdBookValidationError,
} from '../src/modules/purchase/urdBook.js';
import {
  deleteLinkedPurchaseTx,
  deleteLinkedPurchasesForSaleTx,
  findLinkedPurchasesTx,
  writeLinkedPurchaseTx,
  type LinkedPurchaseInput,
} from '../src/modules/purchase/linkedPurchase.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Linked old-gold (URD) purchase, PR1 (owner decision 2B): the URD book resolver, the per-company setting, and the
 * linked purchase writer that a sale will call inside its own transaction. Synthetic data only.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'urd-linked-purchase-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const base = { tenantId: TENANT, coCode: CO, lcCode: LC };
const scopeOf = (coBook: string): VoucherScope => ({ ...base, coYear: YEAR, coBook });
const GOLD_MISSING =
  "Create a Gold URD Purchase book in Books / Series (code 043 or a name starting 'Gold URD'), or choose one in Settings";
const SILVER_MISSING =
  "Create a Silver URD Purchase book in Books / Series (code 044 or a name starting 'Silver URD'), or choose one in Settings";
const SALE = { saleBillNo: '00012', saleBillLc: LC, saleBillYear: YEAR, saleBillBook: 'SAL' };

const header = (overrides: Record<string, unknown> = {}) => ({
  mainUser: 'urd-test',
  acCode: 'OLDP',
  vchDate: DAY,
  taxRatePct: 0,
  interState: false,
  ...overrides,
});
const goldLines = (amount = 5000) => [
  {
    itCode: 'OLDG',
    pcs: 1,
    grossWt: 10,
    netWt: 10,
    touch: 90,
    metalAmount: amount,
    metal: 'G' as const,
  },
];
const linkedInput = (amount = 5000): LinkedPurchaseInput =>
  ({ ...header(), lines: goldLines(amount) }) as LinkedPurchaseInput;

const PURCHASE_TABLES = [
  'PR_DATA',
  'PR_DETL',
  'PR_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'SL_PR_DETL',
  'ITM_LOT_DETL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'LOT_DETL',
  'REMARK_DATA',
];

databaseDescribe('linked old-gold (URD) purchase', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const inTx = <T>(fn: (tx: any) => Promise<T>): Promise<T> =>
    withTenant(runtime, TENANT, fn as any) as Promise<T>;

  const cleanup = async () => {
    for (const table of [
      ...PURCHASE_TABLES,
      'DELETE_DATA',
      'USER_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'CO_SET',
      'CO_SET_NEW',
      'company_urd_book',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  /** BOOK_DATA rows: [code, name, sname, mainBook, curUse]. */
  const books = async (rows: Array<[string, string, string, string, string]>) => {
    await owner.$executeRawUnsafe(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1`, TENANT);
    await owner.$executeRawUnsafe(`DELETE FROM "BOOK_DETL" WHERE tenant_id=$1`, TENANT);
    for (const [code, name, sname, mainBook, curUse] of rows) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
           "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","ITM_TYPE","BOOK_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6,$7,'I',$8,'PR_DATA','G','T')`,
        TENANT,
        CO,
        LC,
        code,
        name,
        sname,
        mainBook,
        curUse,
      );
      for (const [srNo, ac] of [
        [1, 'CTRL'],
        [2, 'CASH'],
        [3, 'ROUND'],
      ] as const) {
        await owner.$executeRawUnsafe(
          `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
           VALUES ($1,$2,$3,$4,$5,$6,$7,'I')`,
          TENANT,
          CO,
          LC,
          code,
          srNo,
          ac,
          mainBook,
        );
      }
    }
  };
  const desktopBooks = () =>
    books([
      ['PUR', 'Purchase', 'PUR', 'PURCHASE', 'Y'],
      ['043', 'Gold URD Purchase', 'GLURD', 'PURCHASE', 'Y'],
      ['044', 'Silver URD Purchase', 'SLURD', 'PURCHASE', 'Y'],
    ]);

  const seed = async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES ($1,$2)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'OLDP','Synthetic Old Gold Seller','L')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC','PURCAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'OLDG','Old Gold','G','G01')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,0,0)`,
      TENANT,
      CO,
      LC,
    );
    await desktopBooks();
  };

  const counts = async (coBook: string, vchNo: string) => {
    const out: Record<string, number> = {};
    for (const table of [...PURCHASE_TABLES, 'DELETE_DATA']) {
      const [row] = await owner.$queryRawUnsafe<any[]>(
        `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        TENANT,
        coBook,
        vchNo,
      );
      if (Number(row?.n ?? 0) > 0) out[table] = Number(row.n);
    }
    return out;
  };
  const ledger = (coBook: string, vchNo: string) =>
    owner.$queryRawUnsafe<any[]>(
      `SELECT btrim("AC_CODE") ac, coalesce("DR_AMT",0)::float dr, coalesce("CR_AMT",0)::float cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY 1,2,3`,
      TENANT,
      coBook,
      vchNo,
    );
  const partyRojmel = async (coBook: string, vchNo: string) =>
    Number(
      (
        await owner.$queryRawUnsafe<any[]>(
          `SELECT count(*)::int n FROM "ROJ_MEL_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND btrim("AC_CODE")='OLDP'`,
          TENANT,
          coBook,
          vchNo,
        )
      )[0].n,
    );

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('requires MIGRATE_DATABASE_URL and DATABASE_URL');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });
  beforeEach(async () => {
    await cleanup();
    await seed();
  });
  afterAll(async () => {
    if (owner) await cleanup();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  describe('resolveUrdPurchaseBookTx', () => {
    it('resolves the desktop books 043 / 044 (TR_SALE.cs:18756-18842)', async () => {
      const gold = await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'));
      const silver = await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'S'));
      expect(gold).toMatchObject({ coBook: '043', source: 'desktop-code' });
      expect(silver).toMatchObject({ coBook: '044', source: 'desktop-code' });
    });

    it('resolves a web company by BOOK_DATA name or short name under another code', async () => {
      await books([
        ['PR', 'Purchase', 'PR', 'PURCHASE', 'Y'],
        ['728', 'Gold URD Purchase', 'GURD', 'PURCHASE', 'Y'],
        ['729', 'Old Silver', 'SLURD', 'PURCHASE', ''],
      ]);
      expect(await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).toMatchObject({
        coBook: '728',
        source: 'name',
      });
      expect(await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'S'))).toMatchObject({
        coBook: '729',
        source: 'name',
      });
    });

    it('ignores 043 when it is not an active PURCHASE book', async () => {
      await books([
        ['043', 'Gold URD Purchase', 'GLURD', 'SALES', 'Y'],
        ['044', 'Silver URD Purchase', 'SLURD', 'PURCHASE', 'N'],
      ]);
      for (const metal of ['G', 'S'] as const) {
        await expect(inTx((tx) => resolveUrdPurchaseBookTx(tx, base, metal))).rejects.toThrow(
          metal === 'G' ? GOLD_MISSING : SILVER_MISSING,
        );
      }
    });

    it('lets the company setting override 043, and refuses a setting that is not a purchase book', async () => {
      await books([
        ['PUR', 'Purchase', 'PUR', 'PURCHASE', 'Y'],
        ['043', 'Gold URD Purchase', 'GLURD', 'PURCHASE', 'Y'],
        ['SAL', 'Sales', 'SAL', 'SALES', 'Y'],
      ]);
      await inTx((tx) => saveUrdBookSettingsTx(tx, base, { goldBook: 'PUR' }, 'urd-test'));
      expect(await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).toMatchObject({
        coBook: 'PUR',
        source: 'setting',
      });
      await expect(
        inTx((tx) => saveUrdBookSettingsTx(tx, base, { goldBook: 'SAL' }, 'urd-test')),
      ).rejects.toBeInstanceOf(UrdBookValidationError);
      await expect(
        inTx((tx) =>
          saveUrdBookSettingsTx(tx, base, { goldBook: 'PUR', silverBook: 'PUR' }, 'urd-test'),
        ),
      ).rejects.toThrow('must differ');
      // A stored book that later stops being a purchase book here falls back to 043, and says why.
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "CUR_USE"='N' WHERE tenant_id=$1 AND "CO_BOOK"='PUR'`,
        TENANT,
      );
      expect(await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).toMatchObject({
        coBook: '043',
        source: 'desktop-code',
        settingIgnored: `book PUR chosen in Settings is not an active Purchase book at location ${LC}`,
      });
      // Clearing the setting falls back to 043.
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "CUR_USE"='Y' WHERE tenant_id=$1 AND "CO_BOOK"='PUR'`,
        TENANT,
      );
      await inTx((tx) => saveUrdBookSettingsTx(tx, base, { goldBook: '' }, 'urd-test'));
      const view = await inTx((tx) => getUrdBookSettingsTx(tx, base));
      expect(view.values).toEqual({ goldBook: null, silverBook: null });
      expect(view.resolved.gold).toMatchObject({ coBook: '043' });
      expect(view.resolved.silver).toEqual({ error: SILVER_MISSING });
      expect(view.lcCode).toBe(LC);
      expect(view.books.map((b) => b.coBook)).toEqual(['043', 'PUR']);
    });

    it('refuses none and several candidates for each metal', async () => {
      await books([['PR', 'Purchase', 'PR', 'PURCHASE', 'Y']]);
      await expect(inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).rejects.toThrow(
        GOLD_MISSING,
      );
      await books([
        ['701', 'Gold URD Purchase', 'X', 'PURCHASE', 'Y'],
        ['702', 'Old gold', 'GLURD', 'PURCHASE', 'Y'],
        ['703', 'Silver URD Purchase', 'X', 'PURCHASE', 'Y'],
        ['704', 'Silver URD Purchase 2', 'X', 'PURCHASE', 'Y'],
      ]);
      await expect(inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).rejects.toThrow(
        'Several Purchase books qualify as the Gold URD Purchase book (701, 702): keep only one in use, or choose one in Settings',
      );
      await expect(inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'S'))).rejects.toThrow(
        'Several Purchase books qualify as the Silver URD Purchase book (703, 704): keep only one in use, or choose one in Settings',
      );
      expect(await inTx((tx) => isUrdPurchaseBookTx(tx, base, '701'))).toBeNull();
    });

    it('a setting naming a book of another location falls back at this one (per-company setting, per-location books)', async () => {
      await books([
        ['PUR', 'Purchase', 'PUR', 'PURCHASE', 'Y'],
        ['728', 'Gold URD Purchase', 'GURD', 'PURCHASE', 'Y'],
      ]);
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","CUR_USE")
         VALUES ($1,$2,'02','L2G','Branch old gold','L2G','PURCHASE','Y')`,
        TENANT,
        CO,
      );
      // The choice is saved for the company: L2G exists only at location 02, which is enough.
      await inTx((tx) => saveUrdBookSettingsTx(tx, base, { goldBook: 'L2G' }, 'urd-test'));
      expect(
        await inTx((tx) => resolveUrdPurchaseBookTx(tx, { ...base, lcCode: '02' }, 'G')),
      ).toMatchObject({ coBook: 'L2G', source: 'setting' });
      // At location 01 the rule falls through to the book named Gold URD, and the Settings view says why.
      expect(await inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).toMatchObject({
        coBook: '728',
        source: 'name',
        settingIgnored: `book L2G chosen in Settings is not an active Purchase book at location ${LC}`,
      });
      const view = await inTx((tx) => getUrdBookSettingsTx(tx, base));
      expect(view.books.map((b) => b.coBook)).toEqual(['728', 'L2G', 'PUR']);
      expect(view.resolved.gold).toMatchObject({
        coBook: '728',
        settingIgnored: expect.any(String),
      });
      // With no fallback either, the refusal names the ignored setting first.
      await books([['PUR', 'Purchase', 'PUR', 'PURCHASE', 'Y']]);
      await expect(inTx((tx) => resolveUrdPurchaseBookTx(tx, base, 'G'))).rejects.toThrow(
        `Gold URD Purchase book L2G chosen in Settings is not an active Purchase book at location ${LC}. ${GOLD_MISSING}`,
      );
    });

    it('isUrdPurchaseBookTx follows the same rule', async () => {
      expect(await inTx((tx) => isUrdPurchaseBookTx(tx, base, '043'))).toBe('G');
      expect(await inTx((tx) => isUrdPurchaseBookTx(tx, base, '044'))).toBe('S');
      expect(await inTx((tx) => isUrdPurchaseBookTx(tx, base, 'PUR'))).toBeNull();
    });
  });

  describe('writeLinkedPurchaseTx', () => {
    it('creates through the normal path with SL_BILL_* set; the ledger matches a standalone purchase and the party Rojmel row is dropped', async () => {
      const standalone = await createPurchase(
        runtime,
        { ...header(), scope: scopeOf('043') } as any,
        goldLines(),
      );
      const linked = await inTx((tx) =>
        writeLinkedPurchaseTx(tx, scopeOf('043'), linkedInput(), SALE, { allowLinkedEdit: false }),
      );
      expect(linked).toMatchObject({ created: true, metal: 'G', vchNo: standalone.vchNo + 1 });
      const vchNo = String(linked.vchNo).padStart(5, '0');
      const standaloneNo = String(standalone.vchNo).padStart(5, '0');

      const [pr] = await owner.$queryRawUnsafe<any[]>(
        `SELECT btrim("SL_BILL_NO") no,btrim("SL_BILL_LC") lc,btrim("SL_BILL_YRCD") yr,btrim("SL_BILL_DBCD") book,
                "TOT_AMT"::float tot,"BILL_OS"::float os
           FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043' AND "VCH_NO"=$2`,
        TENANT,
        vchNo,
      );
      expect(pr).toEqual({ no: '00012', lc: LC, yr: YEAR, book: 'SAL', tot: 5000, os: 5000 });
      const [detl] = await owner.$queryRawUnsafe<any[]>(
        `SELECT btrim("SL_BILL_NO") no,btrim("SL_BILL_DBCD") book FROM "PR_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"='043' AND "VCH_NO"=$2`,
        TENANT,
        vchNo,
      );
      expect(detl).toEqual({ no: '00012', book: 'SAL' });

      // Same rows and ledger as the standalone purchase of the same content (Purc_Ledr, Ac_Ledr.cs:374+), less the
      // one party Rojmel row checked below.
      const standaloneCounts = await counts('043', standaloneNo);
      expect(await counts('043', vchNo)).toEqual({
        ...standaloneCounts,
        ROJ_MEL_DATA: standaloneCounts.ROJ_MEL_DATA! - 1,
      });
      expect(await ledger('043', vchNo)).toEqual(await ledger('043', standaloneNo));
      // Purc_Rojmel row 13 is suppressed for a purchase booked against a sale (Ac_Rojmel.cs:156).
      expect(await partyRojmel('043', standaloneNo)).toBe(1);
      expect(await partyRojmel('043', vchNo)).toBe(0);

      const found = await inTx((tx) =>
        findLinkedPurchasesTx(tx, { tenantId: TENANT, coCode: CO, ...SALE }),
      );
      expect(found).toEqual([{ lcCode: LC, coYear: YEAR, coBook: '043', vchNo }]);
      // Exact key only: another sale year or book finds nothing.
      expect(
        await inTx((tx) =>
          findLinkedPurchasesTx(tx, {
            tenantId: TENANT,
            coCode: CO,
            ...SALE,
            saleBillYear: '2023-2024',
          }),
        ),
      ).toEqual([]);
    });

    it('edits the linked purchase only with allowLinkedEdit; standalone edit and delete name the sale', async () => {
      const created = await inTx((tx) =>
        writeLinkedPurchaseTx(tx, scopeOf('043'), linkedInput(), SALE, { allowLinkedEdit: true }),
      );
      const vchNo = String(created.vchNo).padStart(5, '0');
      await expect(
        inTx((tx) =>
          writeLinkedPurchaseTx(tx, scopeOf('043'), linkedInput(6000), SALE, {
            allowLinkedEdit: false,
          }),
        ),
      ).rejects.toThrow('Linked with sale SAL/00012; open that sale');

      const edited = await inTx((tx) =>
        writeLinkedPurchaseTx(tx, scopeOf('043'), linkedInput(6000), SALE, {
          allowLinkedEdit: true,
        }),
      );
      expect(edited).toMatchObject({ created: false, vchNo: created.vchNo });
      const [pr] = await owner.$queryRawUnsafe<any[]>(
        `SELECT "TOT_AMT"::float tot,btrim("SL_BILL_NO") no FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043' AND "VCH_NO"=$2`,
        TENANT,
        vchNo,
      );
      expect(pr).toEqual({ tot: 6000, no: '00012' });

      const version = String((await getPurchase(runtime, scopeOf('043'), vchNo)).version);
      await expect(
        editPurchase(
          runtime,
          { ...header(), scope: scopeOf('043') } as any,
          goldLines(7000),
          vchNo,
          version,
        ),
      ).rejects.toThrow('Linked with sale SAL/00012; open that sale');
      await expect(
        deletePurchase(runtime, { scope: scopeOf('043'), vchNo, expectedVersion: version }),
      ).rejects.toThrow('Linked with sale SAL/00012; open that sale');
      // A different sale key does not unlock it either.
      await expect(
        inTx((tx) =>
          deleteLinkedPurchaseTx(
            tx,
            { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: '043', vchNo },
            { ...SALE, saleBillNo: '00013' },
          ),
        ),
      ).rejects.toThrow('Linked with sale SAL/00012; open that sale');
    });

    it('the public create and edit cannot forge or change a sale link (the cascade trusts SL_BILL_*)', async () => {
      const link = async (book: string, no: string) =>
        (
          await owner.$queryRawUnsafe<any[]>(
            `SELECT btrim(coalesce("SL_BILL_NO",'')) no,btrim(coalesce("SL_BILL_DBCD",'')) book
               FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
            TENANT,
            book,
            no,
          )
        )[0];
      // Create on an ordinary book and on the URD book with a forged link: neither stores it.
      for (const book of ['PUR', '043']) {
        const saved = await createPurchase(
          runtime,
          { ...header(), ...SALE, scope: scopeOf(book) } as any,
          goldLines(),
        );
        const no = String(saved.vchNo).padStart(5, '0');
        expect(await link(book, no)).toEqual({ no: '', book: '' });
        // An edit cannot add one either.
        const version = String((await getPurchase(runtime, scopeOf(book), no)).version);
        await editPurchase(
          runtime,
          { ...header(), ...SALE, scope: scopeOf(book) } as any,
          goldLines(5100),
          no,
          version,
        );
        expect(await link(book, no)).toEqual({ no: '', book: '' });
        expect(
          await inTx((tx) => findLinkedPurchasesTx(tx, { tenantId: TENANT, coCode: CO, ...SALE })),
        ).toEqual([]);
      }
      // The linked path's edit keeps the stored link whatever the input carries.
      const linked = await inTx((tx) =>
        writeLinkedPurchaseTx(tx, scopeOf('043'), linkedInput(), SALE, { allowLinkedEdit: false }),
      );
      const no = String(linked.vchNo).padStart(5, '0');
      await inTx((tx) =>
        writeLinkedPurchaseTx(
          tx,
          scopeOf('043'),
          { ...linkedInput(5200), saleBillNo: '99999', saleBillBook: 'XXX' } as any,
          SALE,
          { allowLinkedEdit: true },
        ),
      );
      expect(await link('043', no)).toEqual({ no: '00012', book: 'SAL' });
    });

    it('refuses an ordinary purchase book', async () => {
      await expect(
        inTx((tx) =>
          writeLinkedPurchaseTx(tx, scopeOf('PUR'), linkedInput(), SALE, { allowLinkedEdit: true }),
        ),
      ).rejects.toThrow('book PUR is not the Gold or Silver URD Purchase book');
    });

    it('deleteLinkedPurchaseTx removes every table the normal delete removes', async () => {
      const standalone = await createPurchase(
        runtime,
        { ...header(), scope: scopeOf('043') } as any,
        goldLines(),
      );
      const standaloneNo = String(standalone.vchNo).padStart(5, '0');
      const linked = await inTx((tx) =>
        writeLinkedPurchaseTx(tx, scopeOf('043'), linkedInput(), SALE, { allowLinkedEdit: false }),
      );
      const vchNo = String(linked.vchNo).padStart(5, '0');
      const before = await counts('043', vchNo);
      expect(Object.keys(before)).toEqual(
        expect.arrayContaining(['PR_DATA', 'PR_DETL', 'MAIN_STOCK', 'AC_DATA', 'ROJ_MEL_DATA']),
      );
      const hidden = async (no: string) =>
        (
          await owner.$queryRawUnsafe<any[]>(
            `SELECT "HD_VCH_NO" hd FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043' AND "VCH_NO"=$2`,
            TENANT,
            no,
          )
        )[0].hd;
      const standaloneHidden = await hidden(standaloneNo);
      const linkedHidden = await hidden(vchNo);

      await deletePurchase(runtime, {
        scope: scopeOf('043'),
        vchNo: standaloneNo,
        expectedVersion: String((await getPurchase(runtime, scopeOf('043'), standaloneNo)).version),
      });
      const removed = await inTx((tx) =>
        deleteLinkedPurchasesForSaleTx(tx, { tenantId: TENANT, coCode: CO, ...SALE }, 'urd-test'),
      );
      expect(removed).toEqual([{ lcCode: LC, coYear: YEAR, coBook: '043', vchNo }]);

      // Both deletes leave only their DELETE_DATA audit (1 header + 1 line), and drop the hidden-number row.
      expect(await counts('043', vchNo)).toEqual({ DELETE_DATA: 2 });
      expect(await counts('043', standaloneNo)).toEqual({ DELETE_DATA: 2 });
      const [temp] = await owner.$queryRawUnsafe<any[]>(
        `SELECT count(*)::int n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043' AND "VCH_NO" IN ($2,$3)`,
        TENANT,
        String(standaloneHidden),
        String(linkedHidden),
      );
      expect(temp.n).toBe(0);
    });
  });
});
