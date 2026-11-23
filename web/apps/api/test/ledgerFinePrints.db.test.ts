import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-20 Ledger Report fine prints — the three new data routes over HTTP on the isolated database with
 * forced RLS. Expected figures are computed here from the seeded vouchers with the desktop formula, never
 * read back from the application (RP_LEDR.cs):
 *   money  = Sum(CR_AMT - DR_AMT)             opening VCH_DATE < from, closing VCH_DATE <= to (:8327/:8335)
 *   gold   = signed FINE_WT, "0.000"          (:8332, :8340)
 *   silver = signed FINE_WT, "0.00"           (:8333, :8341, D14)
 *   a zero-amount stock row keeps ITM_FINE    (:8256)
 *   OP_LDR never enters the print figures     (study Calculations B)
 *
 * WP-20 database/unit case index (cases.md) and where each is handled:
 *   account-ledger.output.jmaudr-print ........... jama-udhar data route + exports (this file)
 *   account-ledger.output.gold-figures ........... gold-fine data route (this file + ledgerFinePrints.test.ts)
 *   account-ledger.output.gold-rows .............. gold-fine data route (this file + ledgerFinePrints.test.ts)
 *   account-ledger.output.silver-print ........... silver-fine data route (this file + ledgerFinePrints.test.ts)
 *   account-ledger.scope.print-route-rights ...... export refusal + cross-tenant sentinel (this file)
 *   account-ledger.refuse.no-user-set-row ........ export refusal with no USER_SET row (this file)
 *   account-ledger.refuse.lc-code-empty .......... silver-fine location validation (this file)
 *   account-ledger.config.lite-ageing-hidden ..... ledgerFinePrints.test.ts (edition gate)
 *   account-ledger.filter.location-op-ldr ........ ageing union — WP-20 browser/implement worker
 *   account-ledger.filter.city-group-op-ldr ...... ageing union — WP-20 browser/implement worker
 *   account-ledger.filter.data-type-op-ldr ....... ageing union — WP-20 browser/implement worker
 *   account-ledger.filter.ac-type-op-ldr ......... ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.op-ldr-union ............ ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.book000-replaced ....... ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.book000-without-op-ldr . ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.silver-quirk ........... ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.fifo-carry ............. ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.null-date-dropped ...... ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.account-list-combined .. ageing union — WP-20 browser/implement worker
 *   account-ledger.ageing.future-dated ........... ageing union — WP-20 browser/implement worker
 *   account-ledger.drill.op-ldr-row-ownership .... ageing union — WP-20 browser/implement worker
 *   account-ledger.refuse.zoom-opening ........... ageing union — WP-20 browser/implement worker
 *   account-ledger.scope.rights .................. ageing union — WP-20 browser/implement worker
 *   account-ledger.scope.op-ldr-company .......... ageing union — WP-20 browser/implement worker
 *   account-ledger.scope.presence-location ....... ageing union — WP-20 browser/implement worker
 *   account-ledger.config.mfg-type-j ............. gold rows — WP-20 browser/implement worker
 *   account-ledger.output.in-out-print ........... no route in this packet — WP-20 browser/implement worker
 *   account-ledger.journey.op-ldr-to-print ....... full journey — WP-20 browser worker
 *   account-ledger.output.voucher-wise-row-shapes  BLOCKED (red.md): the four row shapes need a second study pass
 *   account-ledger.journey.desktop-comparison .... BLOCKED (red.md): needs a desktop runtime with OP_LDR rows
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'ledger-fine-prints-db';
const OTHER_TENANT = 'ledger-fine-prints-other';
const PASSWORD = 'Ledger-Fine-Prints!2026';
const SECRET = 'ledger-fine-prints-test-signing-secret-over-32-chars';
const LOGIN = 'fine-reader';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const FROM = '2024-04-01';
const TO = '2024-06-30';

(enabled ? describe : describe.skip)('RP_LEDR fine prints over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const get = (url: string) => app.inject({ method: 'GET', url, headers: { cookie } });
  const wipeTenant = async (tid: string) => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tid);
  };
  /** The two staging tables stay empty on the request path (decision D5). */
  const stagingCounts = async (): Promise<{ fine: number; ledr: number }> => {
    const fine = (await owner.$queryRawUnsafe(
      `SELECT COUNT(*)::int AS n FROM "FINE_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<{ n: number }>;
    const ledr = (await owner.$queryRawUnsafe(
      `SELECT COUNT(*)::int AS n FROM "LEDR_AC_DATA" WHERE tenant_id=$1`,
      tenantId,
    )) as Array<{ n: number }>;
    return { fine: fine[0]!.n, ledr: ledr[0]!.n };
  };

  const seedAccount = (tid: string, acCode: string, name: string) =>
    exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_CITY","AC_MOBILE","AC_TYPE")
       VALUES($1,'01','01',$2,$3,'DEBTOR','RAJKOT','9000000002','A')`,
      tid,
      acCode,
      name,
    );

  let ledrSeq = 0;
  const seedLeg = (
    tid: string,
    acCode: string,
    opts: {
      book?: string;
      bookName?: string;
      vchNo: string;
      date: string;
      cr?: number;
      dr?: number;
      itType?: 'G' | 'S';
      sign?: '+' | '-';
      fine?: number;
    },
  ) => {
    ledrSeq += 1;
    return exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE",
         "VCH_DATE","LEDR_KEY","BOOK_NAME","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT","ENTRY_TIME","DATA_TYPE")
       VALUES($1,'01','01',$2,$3,$4,'SAL',$5::date,$6,$7,$8,$9,$10,$11,$12,$13,$14::timestamp,'A')`,
      tid,
      YEAR,
      opts.book ?? 'SL',
      opts.vchNo,
      opts.date,
      `${tid}-K${ledrSeq}`,
      opts.bookName ?? 'SALES',
      acCode,
      opts.cr ?? 0,
      opts.dr ?? 0,
      opts.itType ?? null,
      opts.sign ?? null,
      opts.fine ?? null,
      `${opts.date} 09:00:00`,
    );
  };

  const seedOp = (
    tid: string,
    acCode: string,
    opts: { date: string; dr: number; drGold?: number; crGold?: number; coCode?: string },
  ) =>
    exec(
      `INSERT INTO "OP_LDR"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","DATA_TYPE","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","CR_GL_FINE","DR_GL_FINE")
       VALUES($1,$2,'01',$3,'000','OP0001','A',$4::date,$5,0,$6,$7,$8)`,
      tid,
      opts.coCode ?? '01',
      YEAR,
      opts.date,
      acCode,
      opts.dr,
      opts.crGold ?? 0,
      opts.drGold ?? 0,
    );

  const seedItem = (tid: string, itCode: string, itType: 'G' | 'S') =>
    exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES($1,'01',$2,$3,$4)`,
      tid,
      itCode,
      `${itType} item ${itCode}`,
      itType,
    );

  const seedStock = (
    tid: string,
    opts: {
      vchNo: string;
      book: string;
      bookName: string;
      date: string;
      itCode: string;
      fine: number;
      amount: number;
      sign: string;
    },
  ) =>
    exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","ITM_SIGN","ITM_FINE","ITM_AMT","DATA_TYPE")
       VALUES($1,'01','01',$2,$3,$4,1,1,$5::date,$6,'Z600',$7,$8,$9,$10,'A')`,
      tid,
      YEAR,
      opts.book,
      opts.vchNo,
      opts.date,
      opts.bookName,
      opts.itCode,
      opts.sign,
      opts.fine,
      opts.amount,
    );

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipeTenant(tenantId);
    await wipeTenant(OTHER_TENANT);
    await seedCompany(runtime, tenantId, '01');
    await seedAccount(tenantId, 'Z600', 'ZZ PRINT');

    // Opening and period legs for Z600. Opening is dated strictly before FROM (2024-04-01); a leg dated
    // on FROM would be in the period, not the opening (RP_LEDR.cs:8327 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt}}).
    await seedLeg(tenantId, 'Z600', {
      book: '000',
      bookName: 'OPENING',
      vchNo: '00001',
      date: '2024-03-31',
      cr: 100,
      itType: 'G',
      sign: '+',
      fine: 1.5,
    });
    await seedLeg(tenantId, 'Z600', {
      vchNo: '00002',
      date: '2024-05-10',
      dr: 40,
      itType: 'G',
      sign: '-',
      fine: 0.5,
    });
    await seedLeg(tenantId, 'Z600', {
      vchNo: '00003',
      date: '2024-06-15',
      cr: 60,
      itType: 'G',
      sign: '+',
      fine: 2.0,
    });
    // The second silver fine leg (S '-' 1.0) is on the same 2024-06-15 voucher in the case; AC_DATA
    // carries one IT_TYPE per leg, so seed it as its own leg with zero money.
    await seedLeg(tenantId, 'Z600', {
      vchNo: '00003',
      date: '2024-06-15',
      itType: 'S',
      sign: '-',
      fine: 1.0,
    });
    await seedLeg(tenantId, 'Z600', {
      book: '000',
      bookName: 'OPENING',
      vchNo: '00001',
      date: '2024-03-31',
      itType: 'S',
      sign: '+',
      fine: 2.256,
    });
    // The opening-ledger row must never change any print figure (9 values: DR_AMT 999).
    await seedOp(tenantId, 'Z600', { date: '2024-04-21', dr: 999, drGold: 1.0 });

    // Stock rows for the fine prints. A zero-amount opening-stock row keeps its ITM_FINE
    // (RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}}); the 2024-03-01 row is
    // outside the dates and must never be printed.
    await seedItem(tenantId, 'GRNG', 'G');
    await seedItem(tenantId, 'SRNG', 'S');
    await seedStock(tenantId, {
      vchNo: '00010',
      book: '000',
      bookName: 'TR_AC_OPBL',
      date: '2024-05-01',
      itCode: 'GRNG',
      fine: 1.25,
      amount: 0,
      sign: '-',
    });
    await seedStock(tenantId, {
      vchNo: '00011',
      book: 'SL',
      bookName: 'SALES',
      date: '2024-06-02',
      itCode: 'SRNG',
      fine: 3.5,
      amount: 250,
      sign: '-',
    });
    await seedStock(tenantId, {
      vchNo: '00012',
      book: 'SL',
      bookName: 'SALES',
      date: '2024-03-01',
      itCode: 'GRNG',
      fine: 9.999,
      amount: 0,
      sign: '-',
    });

    // Another tenant's sentinels with the same visible account code: never printed here.
    await seedCompany(runtime, OTHER_TENANT, '01');
    await seedAccount(OTHER_TENANT, 'Z600', 'OTHER PRINT');
    await seedLeg(OTHER_TENANT, 'Z600', { vchNo: '00001', date: '2024-05-01', cr: 99999 });
    await seedItem(OTHER_TENANT, 'GRNG', 'G');
    await seedStock(OTHER_TENANT, {
      vchNo: '00010',
      book: 'SL',
      bookName: 'SALES',
      date: '2024-05-01',
      itCode: 'GRNG',
      fine: 77.777,
      amount: 0,
      sign: '-',
    });
    await seedOp(OTHER_TENANT, 'Z600', { date: '2024-04-21', dr: 666 });

    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','N','N','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Report','Ledger Report','Y','N','N','Y')`,
      tenantId,
      LOGIN,
    );

    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipeTenant(tenantId);
      await wipeTenant(OTHER_TENANT);
    }
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  /** Recursively collect the scalars of a JSON response so assertions do not pin an invented shape. */
  const values = (value: unknown, out: unknown[] = []): unknown[] => {
    if (value == null) return out;
    if (Array.isArray(value)) {
      for (const item of value) values(item, out);
      return out;
    }
    if (typeof value === 'object') {
      for (const item of Object.values(value as Record<string, unknown>)) values(item, out);
      return out;
    }
    out.push(value);
    return out;
  };
  const hasText = (body: unknown, text: string): boolean => JSON.stringify(body).includes(text);
  const hasNumber = (body: unknown, expected: number): boolean =>
    values(body).some((v) => typeof v === 'number' && Math.abs(v - expected) < 1e-9);

  const query = `acCode=Z600&fromDate=${FROM}&toDate=${TO}`;
  const routes = [
    '/reports/account-ledger/jama-udhar',
    '/reports/account-ledger/gold-fine',
    '/reports/account-ledger/silver-fine',
  ];

  it('registers the three fine-print data routes and their export siblings', () => {
    const printed = app.printRoutes();
    for (const route of routes) {
      expect(printed, `${route} is not registered`).toContain(route);
      expect(printed, `${route}/export.pdf is not registered`).toContain(`${route}/export.pdf`);
      expect(printed, `${route}/export.xlsx is not registered`).toContain(`${route}/export.xlsx`);
    }
  });

  it('account-ledger.output.jmaudr-print: JmUdAmt figures ignore OP_LDR and write nothing', async () => {
    const before = await stagingCounts();
    const res = await get(`${routes[0]}?${query}`);
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    // Desktop: RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}
    expect(hasText(body, 'JmUdAmt')).toBe(true);
    // Desktop: RP_LEDR.cs:4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}}
    expect(hasText(body, 'OpBal = 100.00')).toBe(true);
    expect(hasText(body, 'ClBal = 120.00')).toBe(true);
    expect(hasNumber(body, 999)).toBe(false);
    expect(await stagingCounts()).toEqual(before);
  });

  it('account-ledger.output.gold-figures: JmUdFine opening/closing, parameters and title', async () => {
    const before = await stagingCounts();
    const res = await get(`${routes[1]}?${query}&dataType=A`);
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    // Desktop: RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}
    // Desktop: RP_LEDR.cs:8414 {{Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";}}
    expect(hasText(body, 'OpBal = 1.500')).toBe(true);
    expect(hasText(body, 'ClBal = 3.000')).toBe(true);
    expect(hasText(body, 'OpAmtBal = 100.00')).toBe(true);
    expect(hasText(body, 'ClAmtBal = 120.00')).toBe(true);
    // Desktop: RP_LEDR.cs:8366 {{Ledr With Gold Fine Report As On }}
    expect(hasText(body, 'Ledr With Gold Fine Report As On 30/06/2024')).toBe(true);
    expect(hasNumber(body, 999)).toBe(false);
    expect(await stagingCounts()).toEqual(before);
  });

  it('account-ledger.output.gold-rows: the zero-amount opening-stock fine is kept, old rows excluded', async () => {
    const res = await get(`${routes[1]}?${query}`);
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    // Desktop: RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}}
    expect(hasNumber(body, 1.25)).toBe(true);
    expect(hasNumber(body, 9.999)).toBe(false);
    expect(await stagingCounts()).toEqual({ fine: 0, ledr: 0 });
  });

  it('account-ledger.output.silver-print: JmUdFineSl rows and two-decimal balance', async () => {
    const before = await stagingCounts();
    const res = await get(`${routes[2]}?${query}&dataType=A`);
    expect(res.statusCode, res.body).toBe(200);
    const body = res.json();
    // Desktop: RP_LEDR.cs:9013 {{Hz Jama Udhar Silver Report}}
    expect(hasText(body, 'Hz Jama Udhar Silver Report')).toBe(true);
    // Desktop: RP_LEDR.cs:9019 {{DC_Main.RptName = "JmUdFineSl";}}
    expect(hasText(body, 'JmUdFineSl')).toBe(true);
    expect(hasNumber(body, 3.5)).toBe(true);
    // D14: silver balance is formatted "0.00", opening 2.256 -> 2.26, closing 1.256 -> 1.26.
    // Desktop: RP_LEDR.cs:8333 {{num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}
    expect(hasText(body, '2.26')).toBe(true);
    expect(hasText(body, '1.26')).toBe(true);
    expect(await stagingCounts()).toEqual(before);
  });

  it('each data route answers its PDF and XLSX siblings and writes nothing on the export path', async () => {
    const before = await stagingCounts();
    for (const route of routes) {
      const pdf = await get(`${route}/export.pdf?${query}`);
      expect(pdf.statusCode, `${route}/export.pdf ${pdf.body?.slice?.(0, 120)}`).toBe(200);
      expect(pdf.headers['content-type']).toContain('application/pdf');
      const xlsx = await get(`${route}/export.xlsx?${query}`);
      expect(xlsx.statusCode, `${route}/export.xlsx ${xlsx.body?.slice?.(0, 120)}`).toBe(200);
      expect(xlsx.headers['content-type']).toContain('spreadsheetml');
    }
    expect(await stagingCounts()).toEqual(before);
  });

  it('account-ledger.scope.print-route-rights: every export refuses with the exact desktop text', async () => {
    // Desktop: RP_LEDR.cs:8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}
    await exec(
      `UPDATE "LOGIN_MAST" SET "USER_PRINT"='N' WHERE tenant_id=$1 AND "LOGIN_NAME"=$2`,
      tenantId,
      LOGIN,
    );
    await exec(
      `UPDATE "USER_SET" SET "FRM_PRINT"='N' WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
      tenantId,
      LOGIN,
    );
    try {
      for (const route of routes) {
        for (const ext of ['export.pdf', 'export.xlsx']) {
          const res = await get(`${route}/${ext}?${query}`);
          expect(res.statusCode, `${route}/${ext} ${res.body}`).toBe(403);
          expect(hasText(res.json(), 'You Have No Print Rights.....')).toBe(true);
        }
      }
    } finally {
      await exec(
        `UPDATE "LOGIN_MAST" SET "USER_PRINT"='Y' WHERE tenant_id=$1 AND "LOGIN_NAME"=$2`,
        tenantId,
        LOGIN,
      );
      await exec(
        `UPDATE "USER_SET" SET "FRM_PRINT"='Y' WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
        tenantId,
        LOGIN,
      );
    }
  });

  it("account-ledger.scope.print-route-rights: another tenant's account never leaks into a print", async () => {
    for (const route of routes) {
      const res = await get(`${route}?acCode=Z900&fromDate=${FROM}&toDate=${TO}`);
      expect([200, 404], `${route} ${res.body}`).toContain(res.statusCode);
      if (res.statusCode === 200) {
        expect(hasNumber(res.json(), 99999)).toBe(false);
        expect(hasNumber(res.json(), 77.777)).toBe(false);
        expect(hasNumber(res.json(), 666)).toBe(false);
      }
    }
  });

  it('account-ledger.refuse.no-user-set-row: no USER_SET row refuses with the same text', async () => {
    // UserPrint has no initializer (RP_LEDR.cs:237 {{private string UserPrint;}}) and is assigned only
    // when a USER_SET row exists (RP_LEDR.cs:4153 {{if (dataTable.Rows.Count > 0)}}), so no row fails
    // the "Y" test (RP_LEDR.cs:3987 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}).
    await exec(
      `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Ledger Report'`,
      tenantId,
      LOGIN,
    );
    try {
      const res = await get(`${routes[1]}/export.pdf?${query}`);
      expect(res.statusCode, res.body).toBe(403);
      expect(hasText(res.json(), 'You Have No Print Rights.....')).toBe(true);
    } finally {
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Report','Ledger Report','Y','N','N','Y')`,
        tenantId,
        LOGIN,
      );
    }
  });

  it('account-ledger.refuse.lc-code-empty: silver with no location refuses with the exact text', async () => {
    // Desktop: RP_LEDR.cs:6125 {{Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);}}
    // Silver_Summ repeats it at RP_LEDR.cs:8667 {{Interaction.MsgBox((object)"Please Select Lc Code and Try...", (MsgBoxStyle)0, (object)null);}}
    const before = await stagingCounts();
    const res = await get(`${routes[2]}?${query}&location=`);
    expect(res.statusCode, res.body).toBe(400);
    expect(hasText(res.json(), 'Please Select Lc Code and Try...')).toBe(true);
    expect(await stagingCounts()).toEqual(before);
  });
});
