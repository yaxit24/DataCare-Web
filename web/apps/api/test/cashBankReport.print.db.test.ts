import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { CO_YEAR, seedA, seedSecondTenant, seedSentinels, unseedSentinels, wipe } from './support/cashBankSeed.js';

/** Cash Bank report print (desktop RP_CASH_BANK, layout AcLedger) over HTTP, isolated database, forced RLS.
 * Expected figures are worked out from seed A with the desktop formula and cited above each assertion; the response is
 * never used to derive them. Until WP-17.print lands, these tests answer 404.
 * Not asserted here (blocked in cases.md, so no test): cash-bank-report.print.opening-with-book (owner decision: whether the
 * print opening follows the Book filter); cash-bank-report.print.balance-zero-side (owner decision: the side of a zero
 * balance); cash-bank-report.print.balance-column-format (the printed number format of the Balance field was not read). */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'cash-bank-print-db';
const OTHER = 'cash-bank-print-other';
const PASSWORD = 'Cash-Bank-Print!2026';
const SECRET = 'cash-bank-print-test-signing-secret-over-32-chars';
const PERIOD = 'fromDate=2026-11-01&toDate=2026-11-30&acCode=00001';
const USERS = { reader: 'cashprint-reader', viewer: 'cashprint-viewer' };
type Who = keyof typeof USERS;

/** The print's text with tags removed, entities decoded, whitespace collapsed and thousands separators removed. */
const plainText = (html: string): string => html
  .replace(/<[^>]*>/g, ' ')
  .replace(/&lt;/g, '<').replace(/&gt;/g, '>').replace(/&amp;/g, '&')
  .replace(/\s+/g, ' ').replace(/,/g, '')
  .trim();
/** The text that follows a caption, for a fixed number of characters. The print's layout is not decided, so the
 * window is wide enough for the caption's value and narrow enough to stay near it. */
const after = (text: string, caption: string, width = 160): string => {
  const at = text.indexOf(caption);
  expect(at, `caption "${caption}" is in the print`).toBeGreaterThanOrEqual(0);
  return text.slice(at, at + caption.length + width);
};
const numbersIn = (text: string): number[] => (text.match(/-?\d+(?:\.\d+)?/g) ?? []).map(Number);

(enabled ? describe : describe.skip)('Cash Bank report print (RP_CASH_BANK, AcLedger)', () => {
  let owner: PrismaClient, runtime: PrismaClient, app: FastifyInstance;
  const cookies: Record<Who, string> = { reader: '', viewer: '' };
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const get = (url: string, who: Who = 'reader') => app.inject({ method: 'GET', url, headers: { cookie: cookies[who] } });
  const printHtml = async (query = PERIOD, who: Who = 'reader'): Promise<string> => {
    const res = await get(`/reports/cash-bank/print?${query}`, who);
    expect(res.statusCode, res.body).toBe(200);
    expect(String(res.headers['content-type'])).toMatch(/text\/html/);
    return res.body;
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    for (const t of [TENANT, OTHER]) await wipe(owner, t);
    await seedCompany(runtime, TENANT, '01');
    await seedA(owner, TENANT);
    await seedCompany(runtime, OTHER, '01');
    await seedSecondTenant(owner, OTHER);
    // reader: view and print; viewer: view only. Same users and rows as cashBankReport.db.test.ts (its setup is not exported).
    const print: Record<Who, string> = { reader: 'Y', viewer: 'N' };
    const hash = await hashPassword(PASSWORD);
    for (const who of Object.keys(USERS) as Who[]) {
      await exec(`INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`, TENANT, USERS[who], hash, print[who]);
      await exec(`INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01',$2,'Report','Reports/Cash / Bank Book','Y','N','N',$3)`, TENANT, USERS[who], print[who]);
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const who of Object.keys(USERS) as Who[]) {
      const res = await app.inject({ method: 'POST', url: '/auth/login', headers: { 'x-tenant-id': TENANT }, payload: { coCode: '01', lcCode: '01', coYear: CO_YEAR, loginName: USERS[who], password: PASSWORD } });
      expect(res.statusCode, res.body).toBe(200);
      cookies[who] = [res.headers['set-cookie'] ?? ''].flat().map((part) => part.split(';', 1)[0]).join('; ');
    }
  });

  afterAll(async () => {
    await app?.close();
    if (owner) for (const t of [TENANT, OTHER]) await wipe(owner, t);
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('cash-bank-report.print.template-regions: the print carries the AcLedger headings and captions', async () => {
    // extraction_output/rpt_xml/AcLedger.xml:452 {{<Text>Debit Rs</Text>}} extraction_output/rpt_xml/AcLedger.xml:465 {{<Text>Credit Rs</Text>}}
    // extraction_output/rpt_xml/AcLedger.xml:478 {{<Text>Ac Name</Text>}} extraction_output/rpt_xml/AcLedger.xml:511 {{<Text>Balance</Text>}}
    // extraction_output/rpt_xml/AcLedger.xml:581 {{<Text>Opening Balance :</Text>}} extraction_output/rpt_xml/AcLedger.xml:836 {{<Text>Transaction Total :</Text>}}
    // extraction_output/rpt_xml/AcLedger.xml:917 {{<Text>Closing Balance :</Text>}}
    const text = plainText(await printHtml());
    for (const heading of ['Debit Rs', 'Credit Rs', 'Ac Name']) expect(text).toContain(heading);
    // "Balance" alone also matches the captions "Opening Balance :" and "Closing Balance :", so the heading is matched without them.
    expect(text).toMatch(/(?<!Opening |Closing )\bBalance\b/);
    for (const caption of ['Opening Balance :', 'Transaction Total :', 'Closing Balance :']) expect(text).toContain(caption);
  });

  it('cash-bank-report.print.title-parameter: the title is the From and To dates of the period', async () => {
    // RP_CASH_BANK.cs:3563 {{DC_Main.MsRptTitelStr = "'Cash and Bank Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";}}
    // extraction_output/rpt_xml/AcLedger.xml:349 {{"TRIAL BALANCE AS ON DATE"}} is the template default that the parameter replaces.
    expect(plainText(await printHtml())).toContain('Cash and Bank Report From 01/11/2026 To 30/11/2026');
  });

  it('cash-bank-report.print.opening-amount-unfiltered: the opening is -7500.00 with no Book given', async () => {
    // RP_CASH_BANK.cs:3541 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE}}
    // RP_CASH_BANK.cs:3545 {{num8 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));}}
    // RP_CASH_BANK.cs:3583 {{Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num8, "0.00")) ?? "";}}
    // extraction_output/rpt_xml/AcLedger.xml:285 {{NumberVar AcBal := {@AcOpAmt} ;}}
    // Seed A: CR 2500 - DR 10000 before 01/11/2026 = -7500. The sign shown on the page is not asserted, only the value.
    const text = plainText(await printHtml());
    expect(numbersIn(after(text, 'Opening Balance :'))).toContain(-7500);
  });

  it('cash-bank-report.print.totals-and-closing: Transaction Total Dr 13500.00 and Cr 2500.00; Closing Balance 11000.00 Dr', async () => {
    // extraction_output/rpt_xml/AcLedger.xml:323 {{if {@AcOpAmt} &lt; 0 then}} extraction_output/rpt_xml/AcLedger.xml:307 {{if {@AcOpAmt} &gt; 0 then}}
    // The opening is below zero, so Dr total = abs(-7500) + 6000 = 13500 (the opening is included), and the Cr total = 2500.
    // extraction_output/rpt_xml/AcLedger.xml:350 {{if {@AcBalance} &lt; 0 then}} gives the side: the closing is -11000, so the side is Dr.
    const raw = await printHtml();
    const text = plainText(raw);
    const totals = numbersIn(after(text, 'Transaction Total :'));
    expect(totals).toEqual(expect.arrayContaining([13500, 2500]));
    const closing = after(text, 'Closing Balance :');
    expect(numbersIn(closing)).toContain(11000);
    expect(closing).toMatch(/\bDr\b/);
    // The other tenant's line (DR 4444, voucher 3) must not reach this tenant's print.
    expect(numbersIn(text)).not.toContain(4444);
    expect(raw).not.toContain('4444');
  });

  it('cash-bank-report.scope.year-sentinel (print): the print leaves out the 2025-26 line', async () => {
    // Supervisor decision, 16 November 2026: the session's company year is applied on the print too (design.md section 1).
    // RP_CASH_BANK.cs:3547 {{{AC_DATA.CO_YEAR} = '}} The sentinel is DR 333 on 06/11/2026 in year 2025-26; the print must show seed A's figures only.
    await seedSentinels(owner, TENANT, 'year');
    try {
      const text = plainText(await printHtml());
      expect(numbersIn(text)).not.toContain(333);
      expect(numbersIn(after(text, 'Opening Balance :'))).toContain(-7500);
      expect(numbersIn(after(text, 'Transaction Total :'))).toEqual(expect.arrayContaining([13500, 2500]));
      expect(numbersIn(after(text, 'Closing Balance :'))).toContain(11000);
    } finally {
      await unseedSentinels(owner, TENANT, 'year');
    }
  });

  it('cash-bank-report.rights.print-html-and-exports-need-print-right: the viewer is refused on print and the three exports; the reader gets the print', async () => {
    // RP_CASH_BANK.cs:2389 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}
    // RP_CASH_BANK.cs:2540 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}
    // The viewer has FRM_VIEW Y and FRM_PRINT N; the reader has both Y.
    for (const path of ['/reports/cash-bank/print', '/reports/cash-bank/export.pdf', '/reports/cash-bank/export.xlsx', '/reports/cash-bank/export.csv']) {
      const res = await get(`${path}?${PERIOD}`, 'viewer');
      expect(res.statusCode, path).toBe(403);
      expect(res.body, path).toContain('You Have No Print Rights.....');
    }
    await printHtml(PERIOD, 'reader');
  });
});
