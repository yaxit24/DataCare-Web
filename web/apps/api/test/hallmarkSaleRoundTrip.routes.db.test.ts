import { PrismaClient } from '@prisma/client';
import {
  hallmarkHeaderFromView,
  hallmarkLineFromView,
  hallmarkOldGoldFromView,
  hallmarkSaleCommand,
} from '@datacare/core';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * N40 / G45 over HTTP and the real database. A hallmark sale saved with distinct values in every field the
 * screen can carry is reopened through `GET /sales/:vchNo`. It is then saved unchanged through the screen's
 * own view → editor → command mapping (`@datacare/core` hallmarkSaleForm) with `PUT /sales/:vchNo`.
 * Every row of every voucher table must be identical afterwards, apart from the row ids of rebuilt rows.
 *
 * Before the fix, the screen restored about 13 line fields and no hidden header fields. That save blanked
 * HUID 2–4 and their weights, the line discount, descriptors and the salesperson, and moved the voucher to
 * today's date.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'hallmark-roundtrip-db';
const PASSWORD = 'Hallmark-Roundtrip!2026';
const SECRET = 'hallmark-roundtrip-test-signing-secret-over-thirty-two';
const LOGIN = 'manager';
const BOOK = 'SL';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
// A past date inside the fiscal year, so an edit that silently re-dated the voucher to today would show.
const DAY = `${startYear}-05-17`;

const canonical = (value: unknown): unknown => {
  if (value === null || value === undefined) return null;
  if (typeof value === 'bigint') return Number(value);
  if (typeof value === 'object' && value !== null && 'toNumber' in (value as object))
    return Number((value as { toNumber: () => number }).toNumber());
  if (value instanceof Date) return value.toISOString();
  if (typeof value === 'number') return Math.round(value * 1e6) / 1e6;
  if (typeof value === 'string') return value.trim();
  return value;
};

/** Human-readable differences between two write sets: tables gained or lost, and changed columns. */
function differences(
  before: Record<string, Array<Record<string, unknown>>>,
  after: Record<string, Array<Record<string, unknown>>>,
): string[] {
  const out: string[] = [];
  for (const table of new Set([...Object.keys(before), ...Object.keys(after)])) {
    const a = before[table] ?? [];
    const b = after[table] ?? [];
    if (a.length !== b.length) {
      out.push(`${table}: ${a.length} row(s) before, ${b.length} after`);
      continue;
    }
    a.forEach((row, i) => {
      for (const column of new Set([...Object.keys(row), ...Object.keys(b[i] ?? {})]))
        if (JSON.stringify(row[column]) !== JSON.stringify(b[i]?.[column]))
          out.push(
            `${table}[${i}].${column}: ${JSON.stringify(row[column])} -> ${JSON.stringify(b[i]?.[column])}`,
          );
    });
  }
  return out;
}

(enabled ? describe : describe.skip)(
  'hallmark sale: an unchanged reopen and save changes nothing',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let cookie = '';
    let voucherTables: string[] = [];
    const wipe = async () => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${row.table_name}" WHERE tenant_id=$1`,
          tenantId,
        );
    };
    const request = (method: 'GET' | 'POST' | 'PUT', url: string, payload?: unknown) =>
      app.inject({
        method,
        url,
        headers: { cookie },
        ...(payload === undefined ? {} : { payload: payload as any }),
      });
    /** Every row of every voucher table for this voucher, canonicalised, without row ids. */
    const writeSet = async (vchNo: string) => {
      const out: Record<string, Array<Record<string, unknown>>> = {};
      for (const table of voucherTables) {
        // An edit records who edited what (USER_DATA), as the desktop does. That is the edit's own trail,
        // not part of the voucher's write set.
        if (table === 'USER_DATA') continue;
        const rows = (await owner.$queryRawUnsafe(
          `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
          tenantId,
          YEAR,
          BOOK,
          vchNo,
        )) as Array<Record<string, unknown>>;
        if (!rows.length) continue;
        out[table] = rows
          .map((row) =>
            Object.fromEntries(
              Object.entries(row)
                .filter(([column]) => column !== 'row_id')
                .map(([column, value]) => [column, canonical(value)]),
            ),
          )
          .sort((a, b) => JSON.stringify(a).localeCompare(JSON.stringify(b)));
      }
      return out;
    };

    beforeAll(async () => {
      for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
        if (!url || new URL(url).port !== '55433')
          throw new Error('hallmark round-trip fixtures require isolated database 55433');
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE") VALUES ($1,'01','01','CUST07','Asha Jewellers','10','L')`,
        tenantId,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES ($1,'01','G01','Gold','SALES')`,
        tenantId,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01','GOLD','Gold','G','G01')`,
        tenantId,
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
        tenantId,
        LOGIN,
        await hashPassword(PASSWORD),
      );
      const tables = (await owner.$queryRawUnsafe(
        `SELECT table_name AS name FROM information_schema.columns
        WHERE table_schema='public' AND column_name IN ('tenant_id','CO_YEAR','CO_BOOK','VCH_NO')
        GROUP BY table_name HAVING count(DISTINCT column_name)=4 ORDER BY 1`,
      )) as Array<{ name: string }>;
      voucherTables = tables.map((t) => t.name);
      expect(voucherTables.length).toBeGreaterThan(40);
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
      });
      expect(login.statusCode, login.body).toBe(200);
      const value = login.headers['set-cookie'];
      cookie = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    });
    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('keeps every header, line and old-metal value through the screen mapping', async () => {
      const created = await request('POST', '/sales', {
        coBook: BOOK,
        coYear: YEAR,
        lcCode: '01',
        vchDate: DAY,
        billNo: 'B-881',
        acCode: 'CUST07',
        acName: 'Asha Jewellers',
        taxRatePct: 3,
        interState: false,
        discountAmount: 150,
        hallmarkAmount: 245,
        cashAmt: 20000,
        empCode: 'E09',
        description: 'Wedding order',
        address1: 'Ring Road',
        city: 'Surat',
        mobile: '9800000000',
        oldGold: [{ itCode: 'OG', netWt: 5.3, touch: 84, rate: 5800, amount: 25821.6 }],
        lines: [
          {
            itCode: 'GOLD',
            pcs: 2,
            grossWt: 10.511,
            netWt: 9.822,
            touch: 91.6,
            ghtWt: 0.133,
            westPct: 1.25,
            rate: 6123,
            labourType: 'per_gram',
            labourRate: 455,
            otherAmount: 117,
            discountPct: 2.5,
            discountAmount: 311,
            ghatAmount: 823,
            mrp: 71234,
            designNo: 'DSN-41',
            itmSize: '18',
            style: 'Antique',
            itemLot: 'LOT-9',
            remark: 'Bridal set',
            bagWt: 0.051,
            tagGrossWt: 10.611,
            tagNetWt: 9.922,
            karigarName: 'KRRAJ',
            karigarNetWt: 9.701,
            karigarTouch: 92.1,
            karigarWestPct: 0.75,
            karigarFine: 9.007,
            huid: 'HUID01',
            hallmarkId2: 'HUID02',
            hallmarkId3: 'HUID03',
            hallmarkId4: 'HUID04',
            hallmarkIdWt: 2.101,
            hallmarkId2Wt: 2.202,
            hallmarkId3Wt: 2.303,
            hallmarkId4Wt: 2.404,
          },
          {
            itCode: 'GOLD',
            pcs: 1,
            grossWt: 4.1,
            netWt: 4,
            touch: 91.6,
            rate: 6123,
            huid: 'HUIDB1',
          },
        ],
      });
      expect(created.statusCode, created.body).toBe(201);
      const vchNo = String(created.json().vchNo).padStart(5, '0');
      const before = await writeSet(vchNo);
      expect(Object.keys(before)).toEqual(
        expect.arrayContaining(['SL_DATA', 'SL_DETL', 'AC_DATA']),
      );

      // Reopen as the screen does, then save without touching anything.
      const loadedResponse = await request(
        'GET',
        `/sales/${vchNo}?coBook=${BOOK}&coYear=${YEAR}&lcCode=01`,
      );
      expect(loadedResponse.statusCode, loadedResponse.body).toBe(200);
      const view = loadedResponse.json() as Record<string, unknown>;
      const header = hallmarkHeaderFromView(view);
      const oldGold = hallmarkOldGoldFromView(view);
      const lines = ((view.lines as Array<Record<string, unknown>>) ?? []).map(
        hallmarkLineFromView,
      );
      const command = hallmarkSaleCommand({
        scope: { coBook: BOOK, coYear: YEAR, lcCode: '01' },
        header,
        oldGold,
        lines,
        loaded: { view, header, oldGold },
      });
      const saved = await request('PUT', `/sales/${vchNo}`, command);
      expect(saved.statusCode, saved.body).toBe(200);

      const after = await writeSet(vchNo);
      expect(differences(before, after)).toEqual([]);
      expect(after).toEqual(before);
      const [detail] = after.SL_DETL ?? [];
      expect(detail).toBeDefined();
      const huidLine = (after.SL_DETL ?? []).find((row) => row.HM_ID === 'HUID01');
      expect(huidLine).toMatchObject({
        HM_ID2: 'HUID02',
        HM_ID3: 'HUID03',
        HM_ID4: 'HUID04',
        HM_ID4_WT: 2.404,
        DISC_AMT: 311,
        ITM_REMARK: 'Bridal set',
      });
      expect(String(after.SL_DATA?.[0]?.VCH_DATE)).toContain(DAY);
    });
  },
);
