import { createHash } from 'node:crypto';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { applyRepair, previewRepair } from '../src/modules/utilities/dataRepair.js';
import {
  ACCOUNT_REFRESH_VERIFIED,
  type AccountCheck,
} from '../src/modules/utilities/accountRefresh.js';
import {
  editPayment,
  editReceipt,
  postPayment,
  postPaymentLines,
  postReceipt,
  postReceiptLines,
} from '../src/modules/finance/cashBank.js';
import { postBatchReceipt } from '../src/modules/finance/batchReceipt.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import '../src/modules/utilities/dataRepairOps.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Data Refresh > Account check-and-repair, Cash/Bank family (preview-only until the desktop replay check; the tests
 * after the first add it to ACCOUNT_REFRESH_VERIFIED to prove the apply) (owner decision 2026-11-27; MS_UPDATE.cs:2470-2476,
 * Cash_Ledr / Bank_Ledr Ac_Ledr.cs:565-610, Cash_Rojmel / Bank_Rojmel Ac_Rojmel.cs:179-219). Synthetic data only.
 *
 * Every receipt and payment saved through the TR_CASH writer (cash and bank books, the generic web books, single and
 * grid, card / UPI with the plan flag on and off, edited) must preview clean: that is what puts `cash-bank` on the
 * ACCOUNT_REFRESH_VERIFIED allowlist. A damaged voucher is flagged alone and repaired to the writer's rows; vouchers
 * the family cannot explain (another screen's CASH_DATA, legacy PAY_DATA payments, ambiguous damaged vouchers) are
 * reported and never changed.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const T = 'acct-refresh-cb-db';
const OTHER = 'acct-refresh-cb-other-db';
const CO = '01';
const LC = '01';
const y = new Date().getMonth() + 1 >= 4 ? new Date().getFullYear() : new Date().getFullYear() - 1;
const YEAR = `${y}-${y + 1}`;
const OPERATOR = 'cb-admin';
const PASSWORD = 'Account-Refresh-Cb-1!';
const OP = 'data-refresh-account-cash-bank';
const ACCOUNTS = [
  ['CBPARTY1', 'Cb Party One'],
  ['CBPARTY2', 'Cb Party Two'],
  ['CBPARTY3', 'Cb Party Three'],
  ['CBBANK', 'Cb Bank'],
  ['CBBANK2', 'Cb Second Bank'],
  ['CBCHG', 'Cb Bank Charges'],
  ['CBKSR2', 'Cb Special Write Off'],
];
/** Desktop TR_CASH books: code, MAIN_BOOK, in/out, BOOK_DETL slots 1-3. */
const BOOKS: Array<[string, string, string, string[]]> = [
  ['CRC', 'CASH REC', 'I', ['CASH', 'KASAR']],
  ['CPY', 'CASH PAY', 'O', ['CASH', 'KASAR']],
  ['BRC', 'BANK REC', 'I', ['CBBANK', 'KASAR', 'CBCHG']],
  ['BPY', 'BANK PAY', 'O', ['CBBANK', 'KASAR', 'CBCHG']],
];

type Ref = { coBook: string; vchNo: string; label: string };

d('Data Refresh Account check-and-repair (Cash/Bank)', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient();
  const scope = (tenantId = T) => ({ tenantId, coCode: CO, lcCode: LC, coYear: YEAR });
  const book = (coBook: string, tenantId = T) => ({ ...scope(tenantId), coBook });
  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, T, (tx: any) => tx.$executeRawUnsafe(sql, ...p));
  const query = <R = any>(sql: string, ...p: unknown[]): Promise<R[]> =>
    withTenant(owner, T, (tx: any) => tx.$queryRawUnsafe(sql, ...p));
  const no = (n: number | string) => String(n).padStart(5, '0');

  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const tenant of [T, OTHER])
      await withTenant(owner, tenant, async (tx: any) => {
        await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
        for (const { table_name } of tables)
          await tx.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
      });
  };

  const seedTenant = async (tenant: string) => {
    await seedCompany(runtime, tenant, CO);
    await withTenant(owner, tenant, async (tx: any) => {
      for (const [code, name] of ACCOUNTS)
        await tx.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
           VALUES ($1,$2,$3,$4,$5,'10')`,
          tenant,
          CO,
          LC,
          code,
          name,
        );
      for (const [code, main, inout, slots] of BOOKS) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
           VALUES ($1,$2,$3,$4,$5,$4,$6,$7,'Y','CASH_DATA')`,
          tenant,
          CO,
          LC,
          code,
          `${main} book`,
          main,
          inout,
        );
        for (const [index, ac] of slots.entries())
          await tx.$executeRawUnsafe(
            `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
             VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9)`,
            tenant,
            CO,
            LC,
            code,
            index + 1,
            ac,
            `${main} book`,
            main,
            inout,
          );
      }
    });
  };

  /** A voucher's posting rows without row identity, in a stable order. */
  const postings = async (coBook: string, vchNo: string, tenant = T) => {
    const out: Record<string, unknown[]> = {};
    for (const table of ['AC_DATA', 'ROJ_MEL_DATA', 'TAX_DATA'])
      out[table] = await withTenant(owner, tenant, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT to_jsonb(t) - 'row_id' AS r FROM "${table}" t
            WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
            ORDER BY to_jsonb(t)::text`,
          tenant,
          CO,
          LC,
          YEAR,
          coBook,
          vchNo,
        ),
      );
    return out;
  };
  const keysOf = (coBook: string, vchNo: string, table = 'AC_DATA', extra = '') =>
    query<{ key: string }>(
      `SELECT "LEDR_KEY" key FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ${extra} ORDER BY "LEDR_KEY"`,
      T,
      coBook,
      vchNo,
    );

  const preview = (tenant = T) => previewRepair(runtime, OP, scope(tenant), OPERATOR);
  type Page = Pick<AccountCheck, 'summary' | 'vouchers'> & { total: number };
  const detailOf = (p: { detail?: unknown }) => p.detail as Page;
  const listed = (p: { detail?: unknown }) =>
    detailOf(p).vouchers.map((v) => [v.coBook, v.vchNo, v.status]);

  const backup = async () => {
    const checksum = createHash('sha256')
      .update(`${T}:${Date.now()}:${Math.random()}`)
      .digest('hex');
    await exec(
      `INSERT INTO "company_backup_run"(tenant_id,co_code,checksum,document_version,generated_at,table_count,row_count,operator)
       VALUES ($1,$2,$3,1,now(),1,0,$4)`,
      T,
      CO,
      checksum,
      OPERATOR,
    );
    return checksum;
  };
  const apply = async (previewHash: string) =>
    applyRepair(runtime, OP, scope(), {
      previewHash,
      operator: OPERATOR,
      confirmation: `${OP} ${CO}`,
      reason: 'repair cash and bank postings after a fault',
      operatorPassword: PASSWORD,
      backupReference: await backup(),
    });

  const fx: Record<string, Ref> = {};
  /** Vouchers the family reports as unverified by design: another screen's CASH_DATA and a legacy PAY_DATA payment. */
  const foreign: Ref[] = [];
  const add = (label: string, coBook: string, vchNo: number | string) => {
    fx[label] = { coBook, vchNo: no(vchNo), label };
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    await wipe();
    await seedTenant(T);
    await seedTenant(OTHER);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,'ADMIN')`,
      T,
      CO,
      OPERATOR,
      await hashPassword(PASSWORD),
    );
    const base = { mainUser: OPERATOR };
    // Cash book receipt and payment, with kasar and narration.
    add(
      'cashReceipt',
      'CRC',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('CRC'),
          partyAc: 'CBPARTY1',
          partyName: 'Cb Party One',
          amount: 500,
          kasar: 5,
          mode: 'cash',
          itDesc: 'Counter receipt',
          vchDate: `${y}-05-02`,
        })
      ).vchNo,
    );
    add(
      'cashPayment',
      'CPY',
      (
        await postPayment(runtime, {
          ...base,
          scope: book('CPY'),
          partyAc: 'CBPARTY2',
          amount: 320.4,
          kasar: 1.6,
          mode: 'cash',
          itDesc: 'Petty payout',
          vchDate: `${y}-05-03`,
        })
      ).vchNo,
    );
    // Bank book receipt by cheque, cleared later, with charges and kasar; bank payment cleared the same day.
    add(
      'bankReceipt',
      'BRC',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('BRC'),
          partyAc: 'CBPARTY1',
          amount: 1200,
          kasar: 3,
          bankCharges: 12.5,
          mode: 'cheque',
          chqNo: '445566',
          clrDate: `${y}-05-09`,
          itDesc: 'Cheque deposit',
          vchDate: `${y}-05-04`,
        })
      ).vchNo,
    );
    add(
      'bankPayment',
      'BPY',
      (
        await postPayment(runtime, {
          ...base,
          scope: book('BPY'),
          partyAc: 'CBPARTY3',
          amount: 800,
          bankCharges: 4,
          mode: 'bank',
          vchDate: `${y}-05-05`,
        })
      ).vchNo,
    );
    // Grids: a bank receipt of three lines (one kasar-only) and a cash payment of two.
    add(
      'bankReceiptGrid',
      'BRC',
      (
        await postReceiptLines(runtime, {
          ...base,
          scope: book('BRC'),
          mode: 'cheque',
          chqNo: '7788',
          vchDate: `${y}-05-06`,
          lines: [
            { partyAc: 'CBPARTY1', amount: 100, itDesc: 'First' },
            { partyAc: 'CBPARTY2', amount: 250.25, kasar: 0.75, clrDate: `${y}-05-08` },
            { partyAc: 'CBPARTY3', amount: 0, kasar: 9 },
          ],
        })
      ).vchNo,
    );
    add(
      'cashPaymentGrid',
      'CPY',
      (
        await postPaymentLines(runtime, {
          ...base,
          scope: book('CPY'),
          mode: 'cash',
          vchDate: `${y}-05-07`,
          lines: [
            { partyAc: 'CBPARTY1', amount: 60, itDesc: 'x'.repeat(170) },
            { partyAc: 'CBPARTY2', amount: 40, kasar: 2 },
          ],
        })
      ).vchNo,
    );
    // Generic web books: a cash receipt settled to slot 1, a bank payment and a cash receipt settled to a named
    // account (the two layouts CASH_DATA cannot tell apart), card and UPI receipts with the plan flag on.
    add(
      'genericCash',
      'RCT',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('RCT'),
          partyAc: 'CBPARTY2',
          amount: 75,
          mode: 'cash',
          vchDate: `${y}-05-10`,
        })
      ).vchNo,
    );
    add(
      'genericBank',
      'PAY',
      (
        await postPayment(runtime, {
          ...base,
          scope: book('PAY'),
          partyAc: 'CBPARTY1',
          amount: 410,
          mode: 'bank',
          bankAc: 'CBBANK',
          vchDate: `${y}-05-11`,
        })
      ).vchNo,
    );
    add(
      'genericCashNamed',
      'RCT',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('RCT'),
          partyAc: 'CBPARTY3',
          amount: 33,
          kasar: 1,
          mode: 'cash',
          bankAc: 'CBBANK2',
          vchDate: `${y}-05-12`,
        })
      ).vchNo,
    );
    add(
      'card',
      'RCT',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('RCT'),
          partyAc: 'CBPARTY1',
          amount: 999,
          mode: 'card',
          bankAc: 'CBBANK',
          cardCommissionPct: 2,
          bankName: 'Card Bank',
          vchDate: `${y}-05-13`,
        })
      ).vchNo,
    );
    add(
      'upi',
      'BRC',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('BRC'),
          partyAc: 'CBPARTY2',
          amount: 150,
          mode: 'upi',
          upiId: 'cb@upi',
          vchDate: `${y}-05-14`,
        })
      ).vchNo,
    );
    // An explicit kasar account (API only; the desktop always posts slot 2).
    add(
      'explicitKasar',
      'CRC',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('CRC'),
          partyAc: 'CBPARTY3',
          amount: 90,
          kasar: 10,
          kasarAc: 'CBKSR2',
          mode: 'cash',
          vchDate: `${y}-05-15`,
        })
      ).vchNo,
    );
    // Edited vouchers: a bank receipt re-dated and re-priced, a cash payment re-pointed.
    const editedBank = await postReceipt(runtime, {
      ...base,
      scope: book('BRC'),
      partyAc: 'CBPARTY1',
      amount: 50,
      mode: 'bank',
      vchDate: `${y}-05-16`,
    });
    await editReceipt(
      runtime,
      {
        ...base,
        scope: book('BRC'),
        partyAc: 'CBPARTY2',
        amount: 61.5,
        kasar: 0.5,
        mode: 'bank',
        clrDate: `${y}-05-20`,
        vchDate: `${y}-05-17`,
      },
      editedBank.vchNo,
    );
    add('editedBank', 'BRC', editedBank.vchNo);
    const editedCash = await postPayment(runtime, {
      ...base,
      scope: book('CPY'),
      partyAc: 'CBPARTY1',
      amount: 20,
      mode: 'cash',
      vchDate: `${y}-05-18`,
    });
    await editPayment(
      runtime,
      {
        ...base,
        scope: book('CPY'),
        partyAc: 'CBPARTY3',
        amount: 27,
        kasar: 3,
        mode: 'cash',
        vchDate: `${y}-05-18`,
      },
      editedCash.vchNo,
    );
    add('editedCash', 'CPY', editedCash.vchNo);
    // The card / UPI plan flag off: the form is desktop TR_CASH again; a cheque receipt saves, and the card and UPI
    // vouchers saved while it was on still check clean.
    await exec(
      `INSERT INTO tenant_feature(tenant_id,feature,enabled) VALUES ($1,'cashBankCardUpi',false)`,
      T,
    );
    await expect(
      postReceipt(runtime, {
        ...base,
        scope: book('RCT'),
        partyAc: 'CBPARTY1',
        amount: 10,
        mode: 'upi',
        bankAc: 'CBBANK',
        vchDate: `${y}-05-19`,
      }),
    ).rejects.toThrow(/not enabled/);
    add(
      'flagOff',
      'RCT',
      (
        await postReceipt(runtime, {
          ...base,
          scope: book('RCT'),
          partyAc: 'CBPARTY2',
          amount: 210,
          mode: 'cheque',
          chqNo: '9911',
          bankAc: 'CBBANK',
          vchDate: `${y}-05-19`,
        })
      ).vchNo,
    );
    // Another screen's CASH_DATA in the same generic book: Batch Receipt posts by its own rules.
    const batch = await postBatchReceipt(runtime, {
      scope: book('RCT'),
      vchDate: `${y}-05-21`,
      lines: [{ partyAc: 'CBPARTY1', amount: 40, mode: 'cash' }],
    } as never);
    foreign.push({ coBook: 'RCT', vchNo: no(batch.vchNo), label: 'batch' });
    // A payment the web saved in PAY_DATA before payments moved to CASH_DATA.
    await exec(
      `INSERT INTO "PAY_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","NET_AMT")
       VALUES ($1,$2,$3,$4,'PAY','09001',$5::date,'CBPARTY1',70)`,
      T,
      CO,
      LC,
      YEAR,
      `${y}-05-22`,
    );
    for (const [leg, ac, dr, cr] of [
      ['1', 'CBPARTY1', 70, 0],
      ['2', 'CASH', 0, 70],
    ] as const)
      await exec(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","AC_CODE","DR_AMT","CR_AMT")
         VALUES ($1,$2,$3,$4,'PAY','09001',$5,$6::date,$7,$8,$9)`,
        T,
        CO,
        LC,
        YEAR,
        `${CO}${LC}${YEAR}PAY09001 legacy${leg}`,
        `${y}-05-22`,
        ac,
        dr,
        cr,
      );
    foreign.push({ coBook: 'PAY', vchNo: '09001', label: 'legacy' });
    // A kasar account the API named that is also the party: its kasar legs cannot be told apart from the party's.
    const kasarIsParty = await postReceipt(runtime, {
      ...base,
      scope: book('CRC'),
      partyAc: 'CBPARTY2',
      amount: 44,
      kasar: 4,
      kasarAc: 'CBPARTY2',
      mode: 'cash',
      vchDate: `${y}-05-23`,
    });
    foreign.push({ coBook: 'CRC', vchNo: no(kasarIsParty.vchNo), label: 'kasarIsParty' });
    // The second tenant's sentinel voucher, damaged so that a scope leak would repair it.
    const sentinel = await postReceipt(runtime, {
      ...base,
      scope: book('CRC', OTHER),
      partyAc: 'CBPARTY1',
      amount: 600,
      mode: 'cash',
      vchDate: `${y}-05-02`,
    });
    await withTenant(owner, OTHER, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "AC_DATA" SET "CR_AMT"=1 WHERE tenant_id=$1 AND "CO_BOOK"='CRC' AND "VCH_NO"=$2 AND "CR_AMT"<>0`,
        OTHER,
        no(sentinel.vchNo),
      ),
    );
  }, 180_000);

  afterAll(async () => {
    if (RUN) await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  /** Only the by-design unverified vouchers remain listed. */
  const expectClean = async () => {
    const p = await preview();
    expect(listed(p)).toEqual(
      expect.arrayContaining(foreign.map((f) => [f.coBook, f.vchNo, 'unverified'])),
    );
    expect(detailOf(p).vouchers).toHaveLength(foreign.length);
    expect(p.clean).toBe(true);
    return p;
  };

  it('save-then-check: every cash/bank voucher saved by the writer previews clean', async () => {
    const p = await preview();
    const detail = detailOf(p);
    expect(
      detail.vouchers.filter(
        (v) => !foreign.some((f) => f.vchNo === v.vchNo && f.coBook === v.coBook),
      ),
      JSON.stringify(detail.vouchers).slice(0, 3000),
    ).toEqual([]);
    expect(detail.summary).toMatchObject({
      match: Object.keys(fx).length,
      unverified: foreign.length,
      differs: 0,
      missing: 0,
    });
    expect(p.clean).toBe(true);
    expect(p.diffs).toEqual([]);
    // On the allowlist since the real desktop replay checked clean (data-refresh.md).
    expect(ACCOUNT_REFRESH_VERIFIED.has('cash-bank')).toBe(true);
    expect(p.applyAvailable).toBe(true);
    const reasons = Object.fromEntries(
      detail.vouchers.map((v) => [`${v.coBook}/${v.vchNo}`, v.reason ?? '']),
    );
    expect(reasons[`RCT/${foreign[0]!.vchNo}`]).toMatch(/not written by the receipt\/payment form/);
    expect(reasons['PAY/09001']).toMatch(/PAY_DATA/);
    expect(reasons[`CRC/${foreign[2]!.vchNo}`]).toMatch(/kasar account cannot be told apart/);
  });

  it('treats text padded with spaces, as the desktop stores it, as equal', async () => {
    const { cashReceipt } = fx;
    const pad = (sql: string) =>
      exec(
        `UPDATE "${sql}" SET "IT_DESC"='  '||"IT_DESC"||'   ' WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "IT_DESC"<>''`,
        T,
        cashReceipt!.coBook,
        cashReceipt!.vchNo,
      );
    await pad('AC_DATA');
    await pad('ROJ_MEL_DATA');
    await expectClean();
    for (const table of ['AC_DATA', 'ROJ_MEL_DATA'])
      await exec(
        `UPDATE "${table}" SET "IT_DESC"=btrim("IT_DESC") WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
        T,
        cashReceipt!.coBook,
        cashReceipt!.vchNo,
      );
  });

  it('flags only the damaged vouchers, repairs them to the writer rows and keeps CLR_DATE', async () => {
    const { cashReceipt, bankReceipt, bankReceiptGrid, bankPayment, card, cashPayment } = fx;
    const targets = [cashReceipt!, bankReceipt!, bankReceiptGrid!, card!];
    const writer = new Map<string, Record<string, unknown[]>>();
    for (const r of [...targets, bankPayment!, cashPayment!])
      writer.set(r.label, await postings(r.coBook, r.vchNo));
    // Drop a ledger leg, change an amount, add a stray day-book row, delete a card voucher's day book.
    const [dropped] = await keysOf(cashReceipt!.coBook, cashReceipt!.vchNo);
    await exec(`DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY"=$2`, T, dropped!.key);
    const [changed] = await keysOf(
      bankReceipt!.coBook,
      bankReceipt!.vchNo,
      'AC_DATA',
      `AND "DR_AMT"<>0`,
    );
    await exec(
      `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+1 WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      changed!.key,
    );
    // A clearing mark on every leg of the damaged bank receipt (bank reconciliation): carried by LEDR_KEY.
    await exec(
      `UPDATE "AC_DATA" SET "CLR_DATE"=$3::date WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$4`,
      T,
      bankReceipt!.coBook,
      `${y}-09-30`,
      bankReceipt!.vchNo,
    );
    const strayKey = `${CO}${LC}${YEAR}BRC${bankReceiptGrid!.vchNo}99         9`;
    await exec(
      `INSERT INTO "ROJ_MEL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","AC_CODE","DR_AMT","CR_AMT")
       VALUES ($1,$2,$3,$4,'BRC',$5,$6,$7::date,'CBPARTY1',5,0)`,
      T,
      CO,
      LC,
      YEAR,
      bankReceiptGrid!.vchNo,
      strayKey,
      `${y}-05-06`,
    );
    await exec(
      `DELETE FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      T,
      card!.coBook,
      card!.vchNo,
    );

    const p = await preview();
    const damaged = detailOf(p).vouchers.filter((v) => v.status !== 'unverified');
    expect(damaged.map((v) => [v.coBook, v.vchNo, v.status])).toEqual(
      [
        [bankReceipt!.coBook, bankReceipt!.vchNo, 'differs'],
        [bankReceiptGrid!.coBook, bankReceiptGrid!.vchNo, 'differs'],
        [cashReceipt!.coBook, cashReceipt!.vchNo, 'differs'],
        [card!.coBook, card!.vchNo, 'differs'],
      ].sort((a, b) => a[0]!.localeCompare(b[0]!) || a[1]!.localeCompare(b[1]!)),
    );
    const tableOf = (r: Ref, table: string) =>
      damaged
        .find((v) => v.vchNo === r.vchNo && v.coBook === r.coBook)!
        .tables.find((t) => t.table === table)!;
    expect(tableOf(cashReceipt!, 'AC_DATA')).toMatchObject({
      onlyExpected: [dropped!.key],
      onlyStored: [],
      changed: [],
    });
    expect(tableOf(bankReceipt!, 'AC_DATA').changed).toEqual([
      expect.objectContaining({ key: changed!.key, col: 'DR_AMT' }),
    ]);
    expect(tableOf(bankReceiptGrid!, 'ROJ_MEL_DATA')).toMatchObject({
      onlyStored: [strayKey],
      onlyExpected: [],
    });
    expect(tableOf(card!, 'ROJ_MEL_DATA').onlyExpected.length).toBeGreaterThan(0);
    const sentinelBefore = await postings('CRC', '00001', OTHER);

    const applied = await apply(p.previewHash);
    expect(applied.deduplicated).toBe(false);
    for (const r of [cashReceipt!, bankReceiptGrid!, card!, bankPayment!, cashPayment!])
      expect(await postings(r.coBook, r.vchNo), r.label).toEqual(writer.get(r.label));
    const clr = `${y}-09-30`;
    expect((await postings(bankReceipt!.coBook, bankReceipt!.vchNo)).AC_DATA).toEqual(
      (writer.get('bankReceipt')!.AC_DATA as Array<{ r: Record<string, unknown> }>).map((row) => ({
        r: { ...row.r, CLR_DATE: clr },
      })),
    );
    expect(await postings('CRC', '00001', OTHER)).toEqual(sentinelBefore);

    // Idempotent: the same hash replays, the next preview is clean, a stale hash is refused.
    expect((await apply(p.previewHash)).deduplicated).toBe(true);
    await expectClean();
    await expect(apply('0'.repeat(64))).rejects.toMatchObject({ code: 'stale-preview' });
    const runs = await query<{ before_rows: Array<{ vchNo: string; coBook: string }> }>(
      `SELECT before_rows FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id=$2 AND state='applied'`,
      T,
      OP,
    );
    expect(runs).toHaveLength(1);
    expect(runs[0]!.before_rows).toHaveLength(4);
  });

  it('warns that a clearing mark on a leg the voucher no longer posts will be dropped', async () => {
    const r = fx.bankPayment!;
    const [leg] = await keysOf(r.coBook, r.vchNo);
    const strayKey = `${leg!.key}X`;
    await exec(
      `UPDATE "AC_DATA" SET "LEDR_KEY"=$3,"CLR_DATE"=$4::date WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      leg!.key,
      strayKey,
      `${y}-10-01`,
    );
    const p = await preview();
    const entry = detailOf(p).vouchers.find((v) => v.coBook === r.coBook && v.vchNo === r.vchNo)!;
    expect(entry.status).toBe('differs');
    expect(entry.warnings).toEqual([
      `bank clearing mark ${y}-10-01 on ${strayKey} will be dropped`,
    ]);
    expect(p.samples.join('\n')).toMatch(/will be dropped/);
    await apply(p.previewHash);
    const [run] = await query<{ before_rows: Array<{ vchNo: string; warnings?: string[] }> }>(
      `SELECT before_rows FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id=$2 AND state='applied'
        ORDER BY row_id DESC LIMIT 1`,
      T,
      OP,
    );
    expect(run!.before_rows.find((b) => b.vchNo === r.vchNo)!.warnings).toEqual(entry.warnings);
    expect(
      await query(`SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY"=$2`, T, strayKey),
    ).toEqual([]);
    await expectClean();
  });

  it('never changes a voucher in a locked period', async () => {
    const r = fx.cashPayment!;
    await exec(
      `UPDATE "AC_DATA" SET "CR_AMT"="CR_AMT"+2 WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "CR_AMT"<>0`,
      T,
      r.coBook,
      r.vchNo,
    );
    const damaged = await postings(r.coBook, r.vchNo);
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1`, T, `${y}-05-03`);
    try {
      const p = await preview();
      expect(listed(p)).toContainEqual([r.coBook, r.vchNo, 'locked']);
      expect(p.diffs).toEqual([]);
      await apply(p.previewHash);
      expect(await postings(r.coBook, r.vchNo)).toEqual(damaged);
    } finally {
      await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1`, T);
    }
    await apply((await preview()).previewHash);
    await expectClean();
  });

  it('leaves a damaged voucher whose layout CASH_DATA does not record unverified and unchanged', async () => {
    for (const r of [fx.genericBank!, fx.genericCashNamed!, fx.explicitKasar!]) {
      const [leg] = await keysOf(r.coBook, r.vchNo, 'AC_DATA', `AND "DR_AMT"<>0`);
      await exec(
        `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+7 WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
        T,
        leg!.key,
      );
    }
    const before = {
      bank: await postings(fx.genericBank!.coBook, fx.genericBank!.vchNo),
      cash: await postings(fx.genericCashNamed!.coBook, fx.genericCashNamed!.vchNo),
    };
    const p = await preview();
    const entry = (r: Ref) =>
      detailOf(p).vouchers.find((v) => v.coBook === r.coBook && v.vchNo === r.vchNo)!;
    for (const r of [fx.genericBank!, fx.genericCashNamed!]) {
      expect(entry(r).status, r.label).toBe('unverified');
      expect(entry(r).reason).toMatch(/match none of them/);
    }
    // The explicit kasar account is offered as a second candidate, so this damaged voucher is not repaired either.
    expect(entry(fx.explicitKasar!).status).toBe('unverified');
    expect(p.diffs).toEqual([]);
    await apply(p.previewHash);
    expect(await postings(fx.genericBank!.coBook, fx.genericBank!.vchNo)).toEqual(before.bank);
    expect(await postings(fx.genericCashNamed!.coBook, fx.genericCashNamed!.vchNo)).toEqual(
      before.cash,
    );
  });

  const slot = (coBook: string, srNo: number, ac: string) =>
    exec(
      `UPDATE "BOOK_DETL" SET "AC_CODE"=$4 WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=$3`,
      T,
      coBook,
      srNo,
      ac,
    );
  const entryOf = (p: { detail?: unknown }, r: Ref) =>
    detailOf(p).vouchers.find((v) => v.coBook === r.coBook && v.vchNo === r.vchNo);

  it('reports a voucher whose book settings changed since save as unverified and never re-posts it', async () => {
    const cash = fx.cashReceipt!;
    const grid = fx.bankReceiptGrid!;
    const named = fx.flagOff!;
    const before = {
      cash: await postings(cash.coBook, cash.vchNo),
      grid: await postings(grid.coBook, grid.vchNo),
      named: await postings(named.coBook, named.vchNo),
    };
    // (a) RCT's slot 1 becomes the bank account a cheque receipt kept in REC_AC_CODE.
    await slot('RCT', 1, 'CBBANK');
    // (b) CRC's cash account and BRC's short name change after their vouchers were saved.
    await slot('CRC', 1, 'CBBANK2');
    await exec(
      `UPDATE "BOOK_DATA" SET "BOOK_SNAME"='BRX' WHERE tenant_id=$1 AND "CO_BOOK"='BRC'`,
      T,
    );
    // The grid voucher is also damaged: still reported, never re-posted into today's settings.
    const [leg] = await keysOf(grid.coBook, grid.vchNo, 'AC_DATA', `AND "DR_AMT"<>0`);
    await exec(
      `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+3 WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      leg!.key,
    );
    const gridDamaged = await postings(grid.coBook, grid.vchNo);
    try {
      const p = await preview();
      expect(entryOf(p, named)).toMatchObject({ status: 'unverified' });
      expect(entryOf(p, named)!.reason).toMatch(/book configuration changed since save/);
      expect(entryOf(p, cash)).toMatchObject({ status: 'unverified' });
      expect(entryOf(p, cash)!.reason).toMatch(
        /book configuration changed since save \(settlement CASH -> CBBANK2\)$/,
      );
      expect(entryOf(p, grid)!.status).toBe('unverified');
      expect(entryOf(p, grid)!.reason).toMatch(/short name BRC -> BRX.*also differ/);
      expect(p.samples.join('\n')).toMatch(/book configuration changed since save/);
      expect(p.diffs).toEqual([]);
      expect(detailOf(p).summary.differs).toBe(0);
      await apply(p.previewHash);
      expect(await postings(cash.coBook, cash.vchNo)).toEqual(before.cash);
      expect(await postings(named.coBook, named.vchNo)).toEqual(before.named);
      expect(await postings(grid.coBook, grid.vchNo)).toEqual(gridDamaged);
    } finally {
      await slot('RCT', 1, 'CASH');
      await slot('CRC', 1, 'CASH');
      await exec(
        `UPDATE "BOOK_DATA" SET "BOOK_SNAME"='BRC' WHERE tenant_id=$1 AND "CO_BOOK"='BRC'`,
        T,
      );
    }
    // Settings restored, the damaged grid voucher is repaired again like any other.
    const p = await preview();
    expect(entryOf(p, grid)!.status).toBe('differs');
    expect(entryOf(p, cash)).toBeUndefined();
    await apply(p.previewHash);
    expect(await postings(grid.coBook, grid.vchNo)).toEqual(before.grid);
  });
});
