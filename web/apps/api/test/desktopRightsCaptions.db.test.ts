import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { canonicalFormsForRight } from '../src/modules/rbac/formCatalog.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N212 / G225: the desktop checks a user's rights by the menu button's caption — MDI_FORM sets MsUserRightForm =
 * MsSideBtn and reads USER_SET WHERE LC_CODE, USER_NAME and SUB_MENU = the caption (MDI_FORM.cs:7034-7046, :7111-7116,
 * :7264-7269); each form then reads FRM_EDIT, FRM_DELETE and FRM_PRINT of that row (for example TR_AC_OPBL.cs:2020-2030).
 * A migrated or desktop-written rights row therefore names the caption: Tax, Product, Group, Party Opening, Sales Report.
 * Each Lite caption must reach the web forms of the menu's own screen, and nothing else. Captions are the case labels of
 * the MDI_FORM dispatch (Address :7610, Product :7620, Group :7630, AutoItem :7640, Tax :7670, Party Opening :7680,
 * Purchase Rtn :7893, Approval Isu :8300, Approval Rtn :8312, Fine Jv Entry :8360, Tag Stock :8891, Sales Report :8901,
 * Purchase Rpt :8911, Cash Bank :8941, Gst Report :8951).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'desktop-rights-captions';
const PASSWORD = 'Desktop-Rights-Captions!2026';
const SECRET = 'desktop-rights-captions-test-signing-secret-thirty';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const FROM = `${startYear}-04-01`;
const TO = `${startYear + 1}-03-31`;

/** Each Lite caption with a read its screen makes, and a read of another menu it must not reach. */
const CAPTIONS: Array<{ caption: string; reads: string[]; foreign: string }> = [
  { caption: 'Tax', reads: ['/masters/taxes'], foreign: '/masters/products' },
  { caption: 'Product', reads: ['/masters/products'], foreign: '/masters/taxes' },
  { caption: 'Group', reads: ['/masters/groups'], foreign: '/masters/items' },
  { caption: 'Address', reads: ['/masters/addresses'], foreign: '/masters/groups' },
  { caption: 'Party Opening', reads: ['/ac-opbl', '/ac-opbl/WALKIN'], foreign: '/masters/taxes' },
  {
    caption: 'Sales Report',
    reads: [
      `/reports/sales-register?fromDate=${FROM}&toDate=${TO}`,
      `/reports/sales-by-party?fromDate=${FROM}&toDate=${TO}`,
    ],
    foreign: `/reports/purchase-register?fromDate=${FROM}&toDate=${TO}`,
  },
  {
    caption: 'Purchase Rpt',
    reads: [`/reports/purchase-register?fromDate=${FROM}&toDate=${TO}`],
    foreign: `/reports/sales-register?fromDate=${FROM}&toDate=${TO}`,
  },
  {
    caption: 'Cash Bank',
    reads: [`/reports/cash-book?fromDate=${FROM}&toDate=${TO}`],
    foreign: `/reports/sales-register?fromDate=${FROM}&toDate=${TO}`,
  },
  {
    caption: 'Gst Report',
    reads: [
      `/reports/gstr3b?fromDate=${FROM}&toDate=${TO}`,
      `/reports/hsn-summary?fromDate=${FROM}&toDate=${TO}`,
    ],
    foreign: `/reports/cash-book?fromDate=${FROM}&toDate=${TO}`,
  },
  { caption: 'Tag Stock', reads: ['/reports/tag-stock'], foreign: '/masters/taxes' },
];

/** The web forms each Lite caption must reach (the forms guarding the menu's screen). */
const REACHES: Record<string, string[]> = {
  Address: ['Masters/Addresses'],
  Product: ['Masters/Products'],
  Group: ['Masters/Item Groups'],
  AutoItem: ['Masters/Auto Item'],
  Tax: ['Masters/Taxes'],
  'Party Opening': ['Cash / Bank/Account Opening Bal'],
  Party: ['Masters/Accounts', 'Masters/Customers', 'Masters/Opening Balance'],
  'Purchase Rtn': ['Purchase/Purchase Return'],
  'Approval Isu': ['Sales/Tour / Approval Sale'],
  'Approval Rtn': ['Sales/Approval Return'],
  'Fine Jv Entry': ['Cash / Bank/Fine JV (metal transfer)'],
  'Tag Stock': ['Reports/Tag-Stock Report'],
  'Sales Report': [
    'Reports/Sales Register',
    'Reports/Sales by Party',
    'Reports/Sales by Item',
    'Reports/Sales by Group',
  ],
  'Purchase Rpt': [
    'Reports/Purchase Register',
    'Reports/Purchase by Party',
    'Reports/Purchase by Item',
  ],
  'Cash Bank': ['Reports/Cash / Bank Book'],
  'Gst Report': [
    'Reports/GST Report',
    'Reports/GSTR-1',
    'Reports/GSTR-2 (Purchase)',
    'Reports/GSTR-3B',
    'Reports/HSN Tax Summary',
  ],
};

describe('N212 each Lite caption resolves to the forms of its own screen', () => {
  for (const [caption, forms] of Object.entries(REACHES))
    it(`'${caption}' reaches ${forms.join(', ')}`, () => {
      expect(canonicalFormsForRight(caption)).toEqual(expect.arrayContaining(forms));
    });

  it('a caption reaches no form of another menu', () => {
    expect(
      canonicalFormsForRight('Sales Report').some((f) => f.startsWith('Reports/Purchase')),
    ).toBe(false);
    expect(canonicalFormsForRight('Purchase Rpt').some((f) => f.startsWith('Reports/Sales'))).toBe(
      false,
    );
    expect(canonicalFormsForRight('Tax')).toEqual(['Masters/Taxes']);
    expect(canonicalFormsForRight('Party Opening')).toEqual(
      expect.not.arrayContaining(['Masters/Accounts', 'Masters/Customers']),
    );
  });
});

(enabled ? describe : describe.skip)('N212 desktop USER_SET captions through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const userOf = (caption: string) =>
    `cap${caption.toLowerCase().replace(/[^a-z]/g, '')}`.slice(0, 15);
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const cookies = new Map<string, string>();
  const login = async (user: string): Promise<string> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  const get = (user: string, url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: cookies.get(user) ?? '' } });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    const passwordHash = await hashPassword(PASSWORD);
    // One view-only user per caption, with the rights row the desktop's MS_USER writes: SUB_MENU = the caption.
    for (const { caption } of [...CAPTIONS, { caption: 'Party Opening' }].filter(
      (c, i, all) => all.findIndex((x) => x.caption === c.caption) === i,
    )) {
      const user = userOf(caption);
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES ($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenantId,
        user,
        passwordHash,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES ($1,'01','01',$2,'Desktop',$3,'Y','N','N','N')`,
        tenantId,
        user,
        caption,
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const { caption } of CAPTIONS) cookies.set(userOf(caption), await login(userOf(caption)));
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  for (const { caption, reads, foreign } of CAPTIONS)
    it(`a '${caption}' rights row opens its screen and nothing else`, async () => {
      const user = userOf(caption);
      for (const url of reads) {
        const response = await get(user, url);
        expect(response.statusCode, `${caption} ${url}: ${response.body.slice(0, 200)}`).toBe(200);
      }
      const other = await get(user, foreign);
      expect(other.statusCode, `${caption} must not read ${foreign}`).toBe(403);
    });

  it("a view-only 'Party Opening' row saves a new opening but not a change to one (TR_AC_OPBL.cs:2647-2650)", async () => {
    const user = userOf('Party Opening');
    const save = (amount: number) =>
      app.inject({
        method: 'POST',
        url: '/ac-opbl',
        headers: { cookie: cookies.get(user) ?? '' },
        payload: {
          acCode: 'WALKIN',
          amount,
          sign: 'D',
          gold: 0,
          goldSign: 'C',
          silver: 0,
          silverSign: 'C',
        },
      });
    const opening = () =>
      owner.$queryRawUnsafe(
        `SELECT "OP_AMT"::float amt FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"='WALKIN'`,
        tenantId,
      ) as Promise<Array<{ amt: number }>>;
    let response = await save(1500);
    expect(response.statusCode, response.body).toBe(200);
    expect(await opening()).toEqual([{ amt: 1500 }]);
    response = await save(2500);
    expect(response.statusCode).toBe(403);
    expect(response.json()).toMatchObject({ message: 'You Have No Rights.....' });
    expect(await opening()).toEqual([{ amt: 1500 }]);
    // With the edit right the change is saved.
    await exec(
      `UPDATE "USER_SET" SET "FRM_EDIT"='Y' WHERE tenant_id=$1 AND "USER_NAME"=$2`,
      tenantId,
      user,
    );
    response = await save(2500);
    expect(response.statusCode, response.body).toBe(200);
    expect(await opening()).toEqual([{ amt: 2500 }]);
  });

  it("a view-only 'Party Opening' row cannot delete an opening (TR_AC_OPBL.cs:2862-2864)", async () => {
    const user = userOf('Party Opening');
    const response = await app.inject({
      method: 'DELETE',
      url: '/ac-opbl/WALKIN',
      headers: { cookie: cookies.get(user) ?? '' },
    });
    expect(response.statusCode).toBe(403);
  });
});
