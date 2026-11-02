import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Party (desktop MS_ACCT, web /masters/party).
 *
 * Desktop rules used for the expected values (MS_ACCT.cs unless noted):
 * - The menu button 'Party' opens MS_ACCT directly (MDI_FORM.cs:7600-7609). At location 01 the list is the company's
 *   codes below 100 and the location's codes from 200 (MS_ACCT_Load :5944-5958); CLEAR_DATA (:6134-6355) offers the
 *   next code (the location's second character and five digits, 00201 first; AC_LC_CODE_LEN blank is 1) read-only with
 *   the cursor in the name, the company's state, type A, GST Local, Cr openings and today's Last Visit.
 * - Save (:7650-7962): an opened party needs the edit right; "Enter Party Name and Account group Detail"; the code's
 *   row of the location is replaced by every box upper-cased but the email (:6606-6619, :5050), Val() of the numbers,
 *   Y/N flags, a date box that is not a date as NULL, MAIN_USER, DATA_TRFR 'N' and VISIT_TRAN 'AC'; a new entry's
 *   opening writes OP_DATA (book 000, voucher 00000, DATA_TRFR 'Y') and the AcOp_Ledr legs; AC_MAST_SRNO gets the
 *   code's row; "Data Are Saved.".
 * - Keys (:6704-9640): Enter moves on in tab order with the group, mobile, short-name, GST, main-account and reference
 *   checks; Silver's Cr/Dr goes to Mobile No2 and Khata No to Save; F1 helps; Ctrl+E unlocks the code; Esc leaves.
 * - Delete (:7963-8025): in use outside the opening voucher, software default accounts, the question, the rows gone.
 * Web rules that differ on purpose (gap G235): one transaction; version tokens; the opening is read-only on an opened
 * party; Print lists the accounts on screen.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `party-master.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});

const API = '/masters/party-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This party was changed by someone else after you opened it. Open it again before saving or deleting.';
const QUESTION = 'Are You Sure To Delete This Account now?';
/** Seeded parties use 199901-199909: their last five digits are above 80000, so they never move the next code. */
const CASE_CODES = ['199901', '199902', '199903', '199904', '199905'];
const GROUP = { code: 'P9', name: 'E2EP DEBTORS', sub: 'E2EP ASSETS', main: 'A' };

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.id ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const waitFocus = (page, want) =>
  page.waitForFunction(
    (w) =>
      (document.activeElement?.getAttribute('aria-label') ||
        document.activeElement?.id ||
        document.activeElement?.textContent?.trim()) === w,
    want,
  );
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

const partyRows = (ctx, code) =>
  ctx.rows(
    `SELECT "LC_CODE" lc,"AC_CODE" code,"AC_NAME" name,"AC_GR" grp,"AC_MAIN_GR" main_gr,"AC_TYPE" typ,"AC_MOBILE" mobile,
            "AC_PHONE" phone,"AC_PERSON" person,"AC_SHORT" short,"AC_ADD1" a1,"AC_ADD2" a2,"AC_ADD3" a3,"AC_CITY" city,
            "AC_PIN" pin,"AC_AREA" area,"AC_GSTNO" gst,"AC_GST_TYPE" gst_type,"AC_PANNO" pan,"LCS_NO" lcs,"AC_STATE" state,
            "AC_DISTRICT" district,"MAIN_AC_CODE" main_ac,"AC_REF_CODE" ref,"AC_REF_NAME" ref_name,"AC_MOBILE2" mobile2,
            "AC_PHONE2" phone2,"AC_ADHAR_NO" aadhaar,"PASSPORT_NO" passport,"AC_COUNTRY" country,"BANK_NAME" bank,
            "BANK_AREA" bank_area,"BANK_AC_NO" bank_ac,"BANK_RTGS_NO" rtgs,"AC_EMAIL" email,"AC_KHATA_NO" khata,
            "AC_CR_DAYS" cr_days,"AC_INT_PRC" int_prc,"DPC_PRC" dpc,"WITH_TDS_TAX" tds,"AC_WITH_MEMB_COM" memb,
            "AC_SHARE_HOLDER_COM" share,"DEFAULTER_AC" defaulter,"BR_DATE" br,"AN_DATE" an,
            to_char("L_BR_DATE",'YYYY-MM-DD') lbr,"LAST_VISIT" visit,"LAST_DATE" ldr,"MAIN_USER" main,"DATA_TRFR" trfr,
            "VISIT_TRAN" visit_tran,row_id::text rid
       FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2 ORDER BY row_id`,
    code,
  );
const partyByName = async (ctx, name) =>
  (
    await ctx.rows(
      `SELECT "AC_CODE" code FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_NAME"=$2 ORDER BY row_id`,
      name,
    )
  ).map((r) => String(r.code));
const snapshot = (ctx) =>
  ctx.rows(
    `SELECT (SELECT jsonb_agg(to_jsonb(a) - 'row_id' ORDER BY a."LC_CODE",a."AC_CODE") FROM "AC_MAST" a WHERE tenant_id=$1) m,
            (SELECT jsonb_agg(to_jsonb(s) - 'row_id' ORDER BY s."AC_CODE") FROM "AC_MAST_SRNO" s WHERE tenant_id=$1) s,
            (SELECT count(*)::int FROM "OP_DATA" WHERE tenant_id=$1) o,
            (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) d`,
  );
/** MS_ACCT_Load's list at location 01: codes below 100 of the company, the location's codes from 200, by code. */
const dbList = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "AC_CODE" code,"AC_NAME" name,"AC_MOBILE" mobile,"LC_CODE" lc FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    )
  )
    .map((r) => ({
      code: String(r.code ?? '').trim(),
      name: String(r.name ?? '').trim(),
      mobile: String(r.mobile ?? '').trim(),
      lc: String(r.lc ?? '').trim(),
    }))
    .filter((r) =>
      /^\d+$/.test(r.code)
        ? Number(r.code) < 100 || (r.lc === '01' && Number(r.code) >= 200)
        : r.lc === '01',
    )
    .sort((a, b) => (a.code < b.code ? -1 : a.code > b.code ? 1 : 0))
    .map((r) => [r.code, r.name, r.mobile]);
/** CLEAR_DATA's next code at location 01 (LEN 6 AND SUBSTRING(AC_CODE,2,5) < 80000). */
async function expectedNext(ctx) {
  const rows = await ctx.rows(
    `SELECT "AC_CODE" c FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'
     UNION SELECT "AC_CODE" FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'`,
  );
  const mids = rows
    .map((r) => String(r.c ?? ''))
    .filter((c) => c.length === 6 && /^\d{5}$/.test(c.slice(1)) && Number(c.slice(1)) < 80000)
    .map((c) => c.slice(1))
    .sort();
  const top = mids[mids.length - 1];
  return top ? `1${String(Number(top) + 1).padStart(5, '0')}` : '100201';
}
async function cleanCase(ctx) {
  const made = (
    await ctx.rows(
      `SELECT "AC_CODE" c FROM "AC_MAST" WHERE tenant_id=$1 AND ("AC_NAME" LIKE 'E2EP %' OR "AC_CODE" = ANY($2::text[]))
       UNION SELECT "AC_CODE" FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "AC_NAME" LIKE 'E2EP %'`,
      CASE_CODES,
    )
  ).map((r) => String(r.c));
  const codes = [...new Set([...made, ...CASE_CODES])];
  for (const table of ['AC_MAST', 'AC_MAST_SRNO', 'OP_DATA', 'AC_DATA', 'AC_IMAGE'])
    await exec(
      ctx,
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
      codes,
    );
  await exec(ctx, `DELETE FROM "AC_GROUP" WHERE tenant_id=$1 AND "AC_GR"=$2`, GROUP.code);
  await exec(ctx, `DELETE FROM "ADD_MAST" WHERE tenant_id=$1 AND "AC_NAME" LIKE 'E2EP %'`);
}
async function seedParty(ctx, code, name, extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_MAIN_GR","AC_TYPE","AC_MOBILE",
       "AC_CITY","AC_SHORT","AC_GST_TYPE","MAIN_USER","DATA_TRFR","VISIT_TRAN")
     VALUES ($1,'01',$2,$3,$4,$5,'A','A',$6,$7,$8,'L',$9,'N','AC')`,
    extra.lc ?? '01',
    code,
    name,
    extra.group ?? GROUP.code,
    extra.mobile ?? '',
    extra.city ?? 'E2EP CITY',
    extra.short ?? '',
    extra.main ?? 'DESKUSER',
  );
}
async function withCase(ctx, run) {
  await cleanCase(ctx);
  await exec(
    ctx,
    `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR","AC_GR_NAME","AC_SUB_GR","AC_MAIN_GR") VALUES ($1,'01',$2,$3,$4,$5)`,
    GROUP.code,
    GROUP.name,
    GROUP.sub,
    GROUP.main,
  );
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/party'),
  ]);
  await page.getByRole('heading', { name: 'Party Master', exact: true }).waitFor();
  if (response.status() === 200) await waitFocus(page, 'Ac Name');
  return response;
}
const listed = (page) =>
  page
    .getByTestId('party-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openParty(page, code, how = 'enter') {
  const row = page.getByTestId('party-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#party-code');
    return box?.value === c && document.activeElement?.getAttribute('aria-label') === 'Ac Name';
  }, code);
  return response.json();
}
const OTHER_TAB = new Set([
  'Mobile No2',
  'Phone No2',
  'Adhar No',
  'Passport No',
  'Country',
  'Bank Name',
  'Branch Name',
  'Bank AcNo',
  'ISFC Code',
  'Email',
  'Cr Day',
  'Month Int %',
  'Dpc %',
  'Khata No',
  'This Ac Set With Tds Tax',
  'Member For Commission',
  'Shareholder Commission',
]);
const SELECTS = new Set(['Ac Type', 'Gst Type', 'Amount Cr/Dr', 'Gold Cr/Dr', 'Silver Cr/Dr']);
async function fill(page, values) {
  for (const [box, value] of Object.entries(values)) {
    const tab = OTHER_TAB.has(box) ? 'Other Detail' : 'Company Detail';
    if (!['Amount', 'Gold', 'Silver', 'Amount Cr/Dr', 'Gold Cr/Dr', 'Silver Cr/Dr'].includes(box))
      await page.getByRole('tab', { name: tab, exact: true }).click();
    if (SELECTS.has(box)) await label(page, box).selectOption(value);
    else if (typeof value === 'boolean') await label(page, box).setChecked(value);
    else await label(page, box).fill(value);
  }
  await page.getByRole('tab', { name: 'Company Detail', exact: true }).click();
}
async function setCode(page, code) {
  await page.keyboard.press('Control+e');
  await page.waitForFunction(() => !document.querySelector('#party-code')?.readOnly);
  await page.locator('#party-code').fill(code);
}
async function save(page, trigger = () => button(page, 'Save').click()) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        ['POST', 'PUT'].includes(r.request().method()) &&
        path(r).startsWith(`/api${API}`) &&
        !path(r).endsWith('/photo'),
    ),
    trigger(),
  ]);
  return response;
}
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.getAttribute('aria-label') === 'Ac Name' &&
      document.querySelector('[aria-label="Ac Name"]')?.value === '',
  );
}
async function cancel(page) {
  await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    button(page, 'Cancel').click(),
  ]);
  await page.waitForFunction(
    () =>
      document.activeElement?.getAttribute('aria-label') === 'Ac Name' &&
      document.querySelector('[aria-label="Ac Name"]')?.value === '',
  );
}
function answerQuestions(page, answer = true) {
  const questions = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    questions.push(dialog.message());
    void (answer ? dialog.accept() : dialog.dismiss());
  });
  return questions;
}
const today = () => {
  const d = new Date();
  return `${String(d.getDate()).padStart(2, '0')}/${String(d.getMonth() + 1).padStart(2, '0')}/${d.getFullYear()}`;
};
const FULL = {
  'Ac Name': 'e2ep ramesh shah',
  'Ac Group': GROUP.code,
  'Ac Type': 'C',
  'Mobile No': '9811111111',
  'Phone No': '0261-2345678',
  'Con Person': 'suresh',
  'Ac Short': 'e2rs',
  Address1: '12 ring road',
  Address2: 'near market',
  Address3: 'block b',
  City: 'surat',
  'Pin Code': '395002',
  'City Area': 'adajan',
  'Gst No': '27abcde1234f1z5',
  'Gst Type': 'I',
  'Pan No': 'abcde1234f',
  'Lcs No': 'lcs-77',
  State: 'maharashtra',
  District: 'surat',
  'Birth Date': '15/08/1990',
  'Anv Dt': '31/02/2020',
  'L Birth Dt': '01/01/1960',
  'Mobile No2': '9822222222',
  'Phone No2': '0261-1111111',
  'Adhar No': '123412341234',
  'Passport No': 'p1234567',
  Country: 'india',
  'Bank Name': 'state bank',
  'Branch Name': 'athwa',
  'Bank AcNo': '00112233',
  'ISFC Code': 'sbin0001234',
  Email: 'Ramesh@Example.com',
  'Cr Day': '30',
  'Month Int %': '1.5',
  'Dpc %': '2.25',
  'Khata No': 'k-12',
  'This Ac Set With Tds Tax': true,
  'Member For Commission': true,
};

export const partyMaster = {
  feature: 'party-master',
  title: 'Master → Party (MS_ACCT)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/party/page.tsx',
    'web/apps/api/src/modules/masters/partyMaster.ts',
    'web/apps/api/src/routes/partyMaster.ts',
    'web/apps/web/test/features/modules/partyMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings:
      'catalogue defaults (AC_LC_CODE_LEN blank = 1, VB_IMPORT N); T06 turns BRANCH_ALL_AC_SHOW on and off again',
  },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      "MDI_FORM.cs:7600-7609 opens MS_ACCT; MS_ACCT_Load's list at location 01 (:5944-5958); CLEAR_DATA (:6134-6355): the next code read-only, the cursor in the name, the company's state, type A, GST Local, Cr openings, today's Last Visit; the three tabs and Company Detail's boxes in tab order",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199902', 'E2EP BETA', { mobile: '9800000002' });
          await seedParty(ctx, '199901', 'E2EP ALPHA');
          await seedParty(ctx, '199903', 'E2EP OTHER LOCATION', { lc: '02' });
          const { page } = await ctx.session();
          await openScreen(page);
          const codeBox = page.locator('#party-code');
          assert.equal(await codeBox.evaluate((el) => el.readOnly), true);
          assert.equal(await codeBox.inputValue(), await expectedNext(ctx));
          assert.equal(
            await label(page, 'Search name or mobile').inputValue(),
            'SEARCH  NAME - MOBILE',
          );
          assert.equal(await page.getByTestId('party-cust-detail').inputValue(), 'SEARCH RECORD');
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          assert.ok(!list.some(([c]) => c === '199903'), "another location's party is not listed");
          const [co] = await ctx.rows(
            `SELECT coalesce("CO_STATE",'') s FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          );
          assert.equal(await label(page, 'State').inputValue(), co.s);
          assert.equal(await label(page, 'Ac Type').inputValue(), 'A');
          assert.equal(await label(page, 'Gst Type').inputValue(), 'L');
          assert.equal(await label(page, 'Last Visit').inputValue(), today());
          for (const sign of ['Amount Cr/Dr', 'Gold Cr/Dr', 'Silver Cr/Dr'])
            assert.equal(await label(page, sign).inputValue(), 'C');
          const tabs = (await page.getByRole('tab').allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(tabs, ['Company Detail', 'Other Detail', 'Family Detl']);
          // Save is the main action (the surface crawl presses the first `primary` button); the selected tab is not.
          const primaries = (await page.locator('main button.primary').allInnerTexts()).map((t) =>
            t.trim(),
          );
          assert.deepEqual(primaries, ['Save']);
          const order = await page.evaluate(() =>
            [
              ...document.querySelectorAll(
                '[role="tabpanel"]:not([hidden]) input, [role="tabpanel"]:not([hidden]) select',
              ),
            ]
              .filter((el) => el.tabIndex >= 0)
              .map((el) => el.getAttribute('aria-label') || el.id),
          );
          assert.deepEqual(order, [
            'party-code',
            'Ac Name',
            'Ac Group',
            'Ac Type',
            'Mobile No',
            'Phone No',
            'Con Person',
            'Ac Short',
            'Address1',
            'Address2',
            'Address3',
            'City',
            'Pin Code',
            'City Area',
            'Gst No',
            'Gst Type',
            'Pan No',
            'Lcs No',
            'State',
            'District',
            'Main Ac',
            'Birth Date',
            'Anv Dt',
            'L Birth Dt',
            'Ref By',
            'Ref Name',
          ]);
          await page.getByRole('tab', { name: 'Other Detail', exact: true }).click();
          for (const box of [
            'Mobile No2',
            'Adhar No',
            'Bank Name',
            'Email',
            'Khata No',
            'This Ac Set With Tds Tax',
          ])
            assert.ok(await label(page, box).isVisible(), box);
          // The admin panel, the defaulter box and the limits are for the Advance and Enterprise types only.
          assert.equal(await page.getByText('This Ac Set As Defaulter').count(), 0);
          return {
            observation: `next code ${await codeBox.inputValue()}, ${list.length} listed, tabs ${tabs.join('/')}`,
            expected: { tabs, order },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:7745-7840) writes every box of both tabs (the dates as text for BR_DATE/AN_DATE/LAST_VISIT and a date for L_BR_DATE, Val() of the numbers, Y/N flags, type C, GST I), MAIN_USER, DATA_TRFR N, VISIT_TRAN AC and the AC_MAST_SRNO row; DISPLAY_DATA (:6356-6587) shows them again',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await setCode(page, '199904');
          await fill(page, FULL);
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const [row] = await partyRows(ctx, '199904');
          const { rid, ...stored } = row;
          assert.deepEqual(stored, {
            lc: '01',
            code: '199904',
            name: 'E2EP RAMESH SHAH',
            grp: GROUP.code,
            main_gr: GROUP.main,
            typ: 'C',
            mobile: '9811111111',
            phone: '0261-2345678',
            person: 'SURESH',
            short: 'E2RS',
            a1: '12 RING ROAD',
            a2: 'NEAR MARKET',
            a3: 'BLOCK B',
            city: 'SURAT',
            pin: '395002',
            area: 'ADAJAN',
            gst: '27ABCDE1234F1Z5',
            gst_type: 'I',
            pan: 'ABCDE1234F',
            lcs: 'LCS-77',
            state: 'MAHARASHTRA',
            district: 'SURAT',
            main_ac: '',
            ref: '',
            ref_name: '',
            mobile2: '9822222222',
            phone2: '0261-1111111',
            aadhaar: '123412341234',
            passport: 'P1234567',
            country: 'INDIA',
            bank: 'STATE BANK',
            bank_area: 'ATHWA',
            bank_ac: '00112233',
            rtgs: 'SBIN0001234',
            email: 'ramesh@example.com',
            khata: 'K-12',
            cr_days: 30,
            int_prc: 1.5,
            dpc: 2.25,
            tds: 'Y',
            memb: 'Y',
            share: 'N',
            defaulter: 'N',
            br: '15/08/1990',
            an: null,
            lbr: '1960-01-01',
            visit: today(),
            ldr: null,
            main: USERS.admin.user,
            trfr: 'N',
            visit_tran: 'AC',
          });
          const serial = await ctx.rows(
            `SELECT "LC_CODE" lc,"AC_NAME" name,"AC_GR" grp,"MAIN_USER" u FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "AC_CODE"='199904'`,
          );
          assert.deepEqual(serial, [
            { lc: '01', name: 'E2EP RAMESH SHAH', grp: GROUP.code, u: USERS.admin.user },
          ]);
          await openParty(page, '199904');
          assert.equal(await label(page, 'City').inputValue(), 'SURAT');
          assert.equal(
            await page.getByLabel('Ac Group Name', { exact: true }).inputValue(),
            GROUP.name,
          );
          assert.equal(await label(page, 'Gst Type').inputValue(), 'I');
          await page.getByRole('tab', { name: 'Other Detail', exact: true }).click();
          assert.equal(await label(page, 'Dpc %').inputValue(), '2.25');
          assert.equal(await label(page, 'Email').inputValue(), 'ramesh@example.com');
          assert.equal(await label(page, 'Member For Commission').isChecked(), true);
          return {
            observation:
              'every box stored as the desktop writes it; 31/02/2020 and the blank ledger date NULL',
            expected: stored,
            database: { row, serial },
            downstream: { reopened: true },
          };
        }),
    ),
    C(
      'field.typing-and-formats',
      'T03',
      'mutation',
      'MS_ACCT_KeyPress (:6606-6619) upper-cases every key and refuses the apostrophe, tEmail lower-cases (:5050); IsDate decides each date box (:7801-7805); Enter formats the opening (0.00, 0.000) and the percentages (0.00) (:7573, :8071-8146, :9059)',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Ac Name').focus();
          await page.keyboard.type("e2ep o'neil");
          assert.equal(await label(page, 'Ac Name').inputValue(), 'E2EP ONEIL');
          await fill(page, {
            'Ac Group': GROUP.code,
            'Birth Date': '29/02/2024',
            'Anv Dt': '29/02/2023',
            Email: "A.B'@X.IN",
          });
          await label(page, 'Amount').fill('1500.5');
          await label(page, 'Amount').press('Enter');
          await waitFocus(page, 'Amount Cr/Dr');
          assert.equal(await label(page, 'Amount').inputValue(), '1500.50');
          await label(page, 'Gold').fill('2');
          await label(page, 'Gold').press('Enter');
          assert.equal(await label(page, 'Gold').inputValue(), '2.000');
          await page.getByRole('tab', { name: 'Other Detail', exact: true }).click();
          await label(page, 'Month Int %').fill('1.5');
          await label(page, 'Month Int %').press('Enter');
          await waitFocus(page, 'Dpc %');
          assert.equal(await label(page, 'Month Int %').inputValue(), '1.50');
          const code = await page.locator('#party-code').inputValue();
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const [row] = await partyRows(ctx, code);
          assert.deepEqual(
            [row.name, row.email, row.br, row.an, row.int_prc],
            ['E2EP ONEIL', 'a.b@x.in', '29/02/2024', null, 1.5],
          );
          const [op] = await ctx.rows(
            `SELECT "OP_AMT"::float amt,"FINE_BAL"::float gold FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
            code,
          );
          assert.deepEqual(op, { amt: 1500.5, gold: 2 });
          return {
            observation:
              '29/02/2024 kept, 29/02/2023 NULL, the email lower-cased, 1500.50 / 2.000 / 1.50 formatted',
            expected: { br: '29/02/2024', an: null },
            database: { row, op },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'lookup.helps-and-lists',
      'T04',
      'read-only',
      "F1 on the name opens the help of the location's parties by name (:6766-6799) and a pick opens the party; the group code's Enter opens the AC_GROUP help for an unknown code and fills the name and main group (:7030-7069); the search box keeps the names that contain its text or the mobiles that start with it (:6647-6690); typing a new name keeps the names that start with it (:7280-7470)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP ZETA', { mobile: '9800000011' });
          await seedParty(ctx, '199902', 'E2EP ALPHA', { mobile: '9700000012' });
          await seedParty(ctx, '199903', 'E2EP ALPHA OTHER', { lc: '02' });
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('F1');
          const help = page.getByTestId('party-help');
          await help.waitFor();
          await waitFocus(page, 'Help search');
          const helpCodes = (
            await help.locator('tr').evaluateAll((rows) => rows.map((tr) => tr.dataset.code))
          ).filter((c) => c.startsWith('1999'));
          assert.deepEqual(helpCodes, ['199902', '199901'], 'by name, this location only');
          await page.keyboard.type('zeta');
          await page.waitForFunction(
            () => document.querySelectorAll('[data-testid="party-help"] tr').length === 1,
          );
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/199901`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(
            () => document.querySelector('#party-code')?.value === '199901',
          );
          await cancel(page);
          await label(page, 'Ac Group').fill('zz');
          await label(page, 'Ac Group').press('Enter');
          await help.waitFor();
          // MS_HELP's search box has the cursor and filters the first column (MS_HELP.cs:1687).
          await waitFocus(page, 'Help search');
          await page.keyboard.type(GROUP.code);
          await page.waitForFunction(
            (code) =>
              [...document.querySelectorAll('[data-testid="party-help"] tr')].some(
                (tr) => tr.dataset.code === code,
              ),
            GROUP.code,
          );
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Ac Group');
          assert.equal(await label(page, 'Ac Group').inputValue(), GROUP.code);
          assert.equal(
            await page.getByLabel('Ac Group Name', { exact: true }).inputValue(),
            GROUP.name,
          );
          assert.equal(await label(page, 'Main Group').inputValue(), GROUP.main);
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Ac Type');
          await label(page, 'Search name or mobile').fill('ALPHA');
          let shown = (await listed(page)).map((r) => r[0]).filter((c) => c.startsWith('1999'));
          assert.deepEqual(shown, ['199902']);
          await label(page, 'Search name or mobile').fill('97000');
          shown = (await listed(page)).map((r) => r[0]);
          assert.deepEqual(shown, ['199902']);
          await label(page, 'Ac Name').fill('e2ep z');
          shown = (await listed(page)).map((r) => r[0]);
          assert.deepEqual(shown, ['199901']);
          return {
            observation: `help ${helpCodes.join(',')}; group ${GROUP.code} picked; the search and the name filtered the list`,
            expected: { help: ['199902', '199901'] },
          };
        }),
    ),
    C(
      'children.opening-legs',
      'T05',
      'mutation',
      "A new party's opening (:7856-7905): one OP_DATA row in book 000, voucher 00000, with the three heads and their C/D signs, DATA_TYPE A, DATA_TRFR Y, and one AC_DATA leg per non-zero head (Ac_Ledr.AcOp_Ledr: 02 amount Dr, 03 gold Cr, 06 silver Dr); an opened party shows the opening read-only",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await fill(page, { 'Ac Name': 'e2ep opening party', 'Ac Group': GROUP.code });
          await label(page, 'Amount').fill('1000');
          await label(page, 'Amount Cr/Dr').selectOption('D');
          await label(page, 'Gold').fill('1.5');
          await label(page, 'Silver').fill('2');
          await label(page, 'Silver Cr/Dr').selectOption('D');
          const code = await page.locator('#party-code').inputValue();
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const op = await ctx.rows(
            `SELECT "CO_BOOK" b,"VCH_NO" v,"OP_AMT"::float amt,"OP_SIGN" s,"FINE_BAL"::float g,"FINE_SIGN" gs,
                    "SL_FINE_BAL"::float sl,"SL_FINE_SIGN" ss,"DATA_TYPE" t,"DATA_TRFR" trfr FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
            code,
          );
          assert.deepEqual(op, [
            {
              b: '000',
              v: '00000',
              amt: 1000,
              s: 'D',
              g: 1.5,
              gs: 'C',
              sl: 2,
              ss: 'D',
              t: 'A',
              trfr: 'Y',
            },
          ]);
          const legs = await ctx.rows(
            `SELECT right("LEDR_KEY",2) k,"DR_AMT"::float dr,"CR_AMT"::float cr,"IT_TYPE" it,"SIGN" sign,"FINE_WT"::float fine
               FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 AND "CO_BOOK"='000' ORDER BY "LEDR_KEY"`,
            code,
          );
          assert.deepEqual(legs, [
            { k: '02', dr: 1000, cr: 0, it: 'A', sign: '', fine: 0 },
            { k: '03', dr: 0, cr: 0, it: 'G', sign: '+', fine: 1.5 },
            { k: '06', dr: 0, cr: 0, it: 'S', sign: '-', fine: 2 },
          ]);
          await openParty(page, code);
          assert.equal(await label(page, 'Amount').inputValue(), '1000.00');
          assert.equal(await label(page, 'Amount').evaluate((el) => el.readOnly), true);
          assert.equal(await label(page, 'Silver Cr/Dr').inputValue(), 'D');
          return {
            observation: `${code}: OP_DATA and the legs 02/03/06; reopened read-only`,
            expected: { legs: ['02', '03', '06'] },
            database: { op, legs },
            downstream: { reopened: '1000.00' },
          };
        }),
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Enter on a blank name (:6800-6810); Save without a group (:7737-7742); leaving a name another code has (:7624-7648); Enter on a mobile, second mobile or short name another account has (:6893-6956, :7230-7278); a five-character code without Ctrl+E (:7716-7721); with BRANCH_ALL_AC_SHOW the mobile is required (:7671-7676); nothing written',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP TAKEN', { mobile: '9800000001', short: 'TKN' });
          const before = await snapshot(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('Enter');
          await message(page, 'Please Insert Party Name ...');
          await label(page, 'Ac Name').fill('e2ep new');
          await button(page, 'Save').click();
          await message(page, 'Enter Party Name and Account group Detail');
          await label(page, 'Ac Name').fill('e2ep taken');
          await label(page, 'Ac Group').focus();
          await message(
            page,
            "This Ac Name already Exist in  '199901'  Ac Code... Please Change Account Name...",
          );
          await label(page, 'Ac Name').fill('e2ep new');
          await label(page, 'Mobile No').fill('9800000001');
          await label(page, 'Mobile No').press('Enter');
          await message(page, 'This Mobile No = E2EP TAKEN  With this Account .....');
          assert.equal(await focusedId(page), 'Mobile No');
          await label(page, 'Ac Short').fill('tkn');
          await label(page, 'Ac Short').press('Enter');
          await message(page, 'This Short Name = E2EP TAKEN  With this Account .....');
          await page.getByRole('tab', { name: 'Other Detail', exact: true }).click();
          await label(page, 'Mobile No2').fill('9800000001');
          await label(page, 'Mobile No2').press('Enter');
          await message(page, 'This Short Name = E2EP TAKEN  With this Account .....');
          assert.equal(await focusedId(page), 'Mobile No2');
          await page.getByRole('tab', { name: 'Company Detail', exact: true }).click();
          await label(page, 'Mobile No').fill('');
          await label(page, 'Ac Short').fill('');
          await label(page, 'Ac Group').fill(GROUP.code);
          // Ctrl+E and a five-character code at location 01 (:7724-7728).
          await setCode(page, '19990');
          const refused = await save(page);
          assert.equal(refused.status(), 400);
          await message(page, ' You Change Software Default Account With Main Location....');
          // An opened five-character account saved without Ctrl+E (:7716-7721): the seeded SALES account.
          await cancel(page);
          await openParty(page, 'SALES');
          const locked = await save(page);
          assert.equal(locked.status(), 400);
          await message(page, " You Can't Change Software Default Account....");
          await exec(
            ctx,
            `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","BRANCH_ALL_AC_SHOW") VALUES ($1,'01','Y')`,
          );
          try {
            await cancel(page);
            await fill(page, { 'Ac Name': 'e2ep branch', 'Ac Group': GROUP.code });
            const branch = await save(page);
            assert.equal(branch.status(), 400);
            await message(
              page,
              'Please Insert Mobile No Because This Ac With Multi Branch Acconut so Mobile No Is Mandatory....',
            );
          } finally {
            await exec(ctx, `DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`);
          }
          const writes = requests
            .filter((r) => ['POST', 'PUT', 'DELETE'].includes(r.method))
            .map((r) => [r.method, r.status]);
          // No group, an unlocked default code, a locked default account and the branch mobile: all refused.
          assert.deepEqual(writes, [
            ['POST', 400],
            ['POST', 400],
            ['PUT', 400],
            ['POST', 400],
          ]);
          assert.deepEqual(await snapshot(ctx), before);
          return {
            observation: 'every refusal shown with the desktop text; nothing written',
            expected: 'no AC_MAST, AC_MAST_SRNO, OP_DATA or AC_DATA row changed',
            database: { before },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'A new party without an opening writes one AC_MAST row and one AC_MAST_SRNO row of the location and nothing else (:7745-7962); the next entry offers the next code',
      async (ctx) =>
        withCase(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "AC_MAST" WHERE tenant_id=$1) m,
                        (SELECT count(*)::int FROM "AC_MAST_SRNO" WHERE tenant_id=$1) s,
                        (SELECT count(*)::int FROM "OP_DATA" WHERE tenant_id=$1) o,
                        (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1) d`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          const offered = await page.locator('#party-code').inputValue();
          assert.equal(offered, await expectedNext(ctx));
          await fill(page, { 'Ac Name': 'e2ep footprint', 'Ac Group': GROUP.code });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const after = await counts();
          assert.deepEqual(after, { ...before, m: before.m + 1, s: before.s + 1 });
          assert.deepEqual(await partyByName(ctx, 'E2EP FOOTPRINT'), [offered]);
          const nextCode = await page.locator('#party-code').inputValue();
          assert.equal(nextCode, await expectedNext(ctx));
          assert.equal(Number(nextCode.slice(1)), Number(offered.slice(1)) + 1);
          return {
            observation: `saved ${offered}; the next entry offers ${nextCode}`,
            expected: 'one AC_MAST and one AC_MAST_SRNO row, the next number',
            database: { before, after },
            downstream: { nextCode },
          };
        }),
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      "DISPLAY_DATA then Save with nothing changed writes the same boxes back; MAIN_USER stays the stored user (:6496); the desktop writes each box's text, so a NULL text box comes back empty and a NULL number as 0",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP REOPEN', {
            main: 'DESKUSER',
            mobile: '9800000002',
            city: 'NAVSARI',
          });
          const [before] = await partyRows(ctx, '199901');
          const { page } = await ctx.session();
          await openScreen(page);
          await openParty(page, '199901');
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const [after] = await partyRows(ctx, '199901');
          const norm = ({ rid, ...r }) =>
            Object.fromEntries(
              Object.entries(r).map(([k, v]) => [
                k,
                ['cr_days', 'int_prc', 'dpc'].includes(k)
                  ? Number(v ?? 0)
                  : ['tds', 'memb', 'share', 'defaulter'].includes(k)
                    ? (v ?? 'N')
                    : (v ?? ''),
              ]),
            );
          // LAST_VISIT: the box shows the stored text, blank here, and IsDate("") writes NULL.
          assert.deepEqual(norm(after), norm(before));
          assert.equal(after.main, 'DESKUSER');
          return {
            observation: `the row was replaced (${before.rid} → ${after.rid}) with the same boxes, MAIN_USER ${after.main}`,
            expected: { main: 'DESKUSER' },
            database: { before, after },
            downstream: { same: true },
          };
        }),
    ),
    C(
      'edit.boxes',
      'T09',
      'mutation',
      'An opened party saves its changed boxes on both tabs (:7745-7840) and leaves its opening alone (the save writes the opening only for a new entry, :7856)',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP EDIT');
          const { page } = await ctx.session();
          const year = (await (await page.request.get('/api/me')).json()).coYear;
          await exec(
            ctx,
            `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN","DATA_TYPE")
             VALUES ($1,'01','01',$2,'000','00000','199901',700,'C','A')`,
            year,
          );
          await openScreen(page);
          await openParty(page, '199901', 'dblclick');
          assert.equal(await label(page, 'Amount').inputValue(), '700.00');
          await fill(page, {
            City: 'vapi',
            'Pin Code': '396191',
            'Phone No2': '0260-222222',
            'Khata No': 'k-99',
          });
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const [row] = await partyRows(ctx, '199901');
          assert.deepEqual(
            [row.city, row.pin, row.phone2, row.khata, row.main],
            ['VAPI', '396191', '0260-222222', 'K-99', 'DESKUSER'],
          );
          const op = await ctx.rows(
            `SELECT "OP_AMT"::float amt FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"='199901'`,
          );
          assert.deepEqual(op, [{ amt: 700 }]);
          return {
            observation: 'city, pin, second phone and khata saved; the opening kept',
            expected: { city: 'VAPI' },
            database: { row, op },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:7963-8025): a party with AC_DATA rows outside the opening voucher is in use; the question comes first; No keeps it; Yes deletes AC_MAST_SRNO, AC_MAST and the year\'s book-000 OP_DATA and AC_DATA rows; "Delete Success."',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP DELETE');
          await seedParty(ctx, '199902', 'E2EP IN USE');
          const { page } = await ctx.session();
          const year = (await (await page.request.get('/api/me')).json()).coYear;
          await exec(
            ctx,
            `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN","DATA_TYPE")
             VALUES ($1,'01','01',$2,'000','00000','199901',500,'D','A')`,
            year,
          );
          await exec(
            ctx,
            `INSERT INTO "AC_MAST_SRNO"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','199901','E2EP DELETE')`,
          );
          await exec(
            ctx,
            `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","DR_AMT")
             VALUES ($1,'01','01',$2,'011','00007','199902',100)`,
            year,
          );
          let questions = answerQuestions(page, true);
          await openScreen(page);
          await openParty(page, '199902');
          await button(page, 'Delete').click();
          await message(page, "You Can't Delete Record This Party Code Use in Transection....");
          assert.equal((await partyRows(ctx, '199902')).length, 1);
          await cancel(page);
          questions = answerQuestions(page, false);
          await openParty(page, '199901');
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.deepEqual(questions, [QUESTION]);
          assert.equal((await partyRows(ctx, '199901')).length, 1, 'No keeps it');
          questions = answerQuestions(page, true);
          const [removed] = await Promise.all([
            page.waitForResponse(
              (r) =>
                isApi(r, 'DELETE', `${API}/199901`) && !new URL(r.url()).searchParams.has('dryRun'),
            ),
            button(page, 'Delete').click(),
          ]);
          assert.equal(removed.status(), 200, await removed.text());
          await message(page, 'Delete Success.');
          const left = await ctx.rows(
            `SELECT (SELECT count(*)::int FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"='199901') m,
                    (SELECT count(*)::int FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "AC_CODE"='199901') s,
                    (SELECT count(*)::int FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"='199901') o`,
          );
          assert.deepEqual(left, [{ m: 0, s: 0, o: 0 }]);
          assert.ok(!(await listed(page)).some(([c]) => c === '199901'));
          return {
            observation:
              'the used party refused; No kept the other; Yes deleted it with its opening and serial rows',
            expected: 'the rows gone',
            database: { left },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_ACCT_Load reads the user\'s USER_SET row of SUB_MENU \'Party\': Save of an opened party, Delete and Print answer "You Have No Rights....." / "You Have No Print Rights....." (:7652-7656, :7965-7969, :8659-8663); a new party needs only the view right',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP RIGHTS');
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','199901','SENTINEL')`,
            SECOND_TENANT,
          );
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','Party','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            const opened = await openParty(page, '199901');
            await fill(page, { City: 'changed' });
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
            const direct = [
              (
                await page.request.put(`/api${API}/199901`, {
                  data: { name: 'X', group: GROUP.code, expectedVersion: opened.version },
                })
              ).status(),
              (
                await page.request.delete(`/api${API}/199901?expectedVersion=${opened.version}`)
              ).status(),
              (await page.request.get(`/api${API}/print`)).status(),
            ];
            assert.deepEqual(direct, [403, 403, 403]);
            await cancel(page);
            await fill(page, { 'Ac Name': 'e2ep clerk party', 'Ac Group': GROUP.code });
            const created = await save(page);
            assert.equal(created.status(), 201, await created.text());
            await saved(page);
            const rows = await ctx.rows(
              `SELECT "AC_NAME" name,"MAIN_USER" main FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_NAME" IN ('E2EP RIGHTS','E2EP CLERK PARTY') ORDER BY 1`,
            );
            assert.deepEqual(rows, [
              { name: 'E2EP CLERK PARTY', main: USERS.clerk.user },
              { name: 'E2EP RIGHTS', main: 'DESKUSER' },
            ]);
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "AC_NAME" name FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"='199901'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            return {
              observation: `clerk refused on screen; direct ${direct.join('/')}; clerk created a party`,
              expected:
                'the desktop texts, 403s, a new party allowed, the sentinel tenant untouched',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Party'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"='199901'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one party: the first save wins and the second is refused with 409 (version token, G235) where the desktop lets the later save win',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP RACE');
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await openParty(a, '199901');
          await openParty(b, '199901');
          await fill(a, { City: 'city a' });
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await saved(a);
          await fill(b, { City: 'city b' });
          const second = await save(b);
          assert.equal(second.status(), 409);
          await message(b, CONFLICT);
          const [row] = await partyRows(ctx, '199901');
          assert.equal(row.city, 'CITY A');
          return {
            observation: `edit race ${first.status()} then ${second.status()}`,
            expected: 'the first save stands',
            database: { row },
            downstream: { second: second.status() },
          };
        }),
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      "A replayed edit carries a spent version and is refused (409); a replayed new party finds its code taken, would take the next code (:7740-7760), and is refused because its name is now another code's (tAcName_Validating) — no second party appears",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP RETRY');
          const { page } = await ctx.session();
          await openScreen(page);
          await openParty(page, '199901');
          await fill(page, { 'Pin Code': '111111' });
          const first = await save(page);
          assert.equal(first.status(), 200);
          await saved(page);
          const replayEdit = (await page.request.fetch(first.request())).status();
          assert.equal(replayEdit, 409);
          await fill(page, { 'Ac Name': 'e2ep retry new', 'Ac Group': GROUP.code });
          const created = await save(page);
          assert.equal(created.status(), 201);
          await saved(page);
          const replay = await page.request.fetch(created.request());
          assert.equal(replay.status(), 400);
          assert.match(
            (await replay.json()).message,
            /^This Ac Name already Exist in {2}'\d+' {2}Ac Code/,
          );
          const codes = await partyByName(ctx, 'E2EP RETRY NEW');
          assert.equal(codes.length, 1);
          return {
            observation: `replayed edit ${replayEdit}; replayed create ${replay.status()}; one party ${codes[0]}`,
            expected: 'both replays refused, one row',
            database: { codes },
            downstream: { replayEdit, replayCreate: replay.status() },
          };
        }),
    ),
    C(
      'rollback.insert-fault',
      'T14',
      'mutation',
      "BtnSave_Click deletes the code's row before it inserts the new one (:7745-7748) and writes the opening after its commit (:7856-7905); a fault on the insert or on the opening must leave every row as it was (the desktop would lose the party or keep it without its opening)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP FAULT BASE');
          const before = await snapshot(ctx);
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_party_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF TG_TABLE_NAME = 'AC_MAST' AND NEW."AC_CITY" = 'E2EFAULT' THEN RAISE EXCEPTION 'e2e fault after the delete'; END IF;
               IF TG_TABLE_NAME = 'OP_DATA' AND NEW."OP_AMT" = 4242 THEN RAISE EXCEPTION 'e2e fault on the opening'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_party_fault BEFORE INSERT ON "AC_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_party_fault()`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_party_fault BEFORE INSERT ON "OP_DATA" FOR EACH ROW EXECUTE FUNCTION e2e_party_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await openParty(page, '199901');
            await fill(page, { City: 'e2efault' });
            const failed = await save(page);
            assert.ok(failed.status() >= 400, await failed.text());
            await cancel(page);
            await fill(page, { 'Ac Name': 'e2ep fault new', 'Ac Group': GROUP.code });
            await label(page, 'Amount').fill('4242');
            const failedNew = await save(page);
            assert.ok(failedNew.status() >= 400, await failedNew.text());
            assert.deepEqual(await snapshot(ctx), before);
            return {
              observation: `the edit answered ${failed.status()} and the new party with an opening ${failedNew.status()}; every row as before`,
              expected: 'no row lost, no party without its opening',
              database: { before },
              downstream: { statuses: [failed.status(), failedNew.status()] },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_party_fault ON "AC_MAST"`,
            );
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_party_fault ON "OP_DATA"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_party_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      "AC_MAST has no year: MS_ACCT reads and writes by CO_CODE, LC_CODE and AC_CODE, so a party saved in this year is listed in the historic year; its opening is the year's (OP_DATA by CO_YEAR), so the historic year shows none",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session(
            as(USERS.admin.user, `${USERS.admin.user}#party-history`),
          );
          await openScreen(page);
          await setCode(page, '199905');
          await fill(page, { 'Ac Name': 'e2ep year party', 'Ac Group': GROUP.code });
          await label(page, 'Amount').fill('300');
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          await page.getByRole('combobox', { name: 'FINANCIAL YEAR' }).selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          await openScreen(page);
          const list = await listed(page);
          assert.ok(list.some(([c, n]) => c === '199905' && n === 'E2EP YEAR PARTY'));
          await openParty(page, '199905');
          assert.equal(await label(page, 'Amount').inputValue(), '');
          return {
            observation: `the historic year lists 199905 among ${list.length}, without this year's opening`,
            expected: 'the same parties in every year, the opening per year',
            database: { rows: await partyRows(ctx, '199905') },
            downstream: { historicYearList: list.length },
          };
        }),
    ),
    C(
      'output.print',
      'T16',
      'output',
      "BtnPrint_Click (:8657-8668) opens the AcMast report of the accounts; the layout is not in the repository, so the web lists the screen's accounts by code with their group, address, city, mobile and GST number (G235)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedParty(ctx, '199901', 'E2EP PRINT', { mobile: '9800000003', city: 'SURAT' });
          const { page } = await ctx.session();
          await openScreen(page);
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/print`)),
            button(page, 'Print').click(),
          ]);
          assert.equal(response.status(), 200);
          const sheet = page.getByTestId('party-print');
          await sheet.waitFor();
          const body = await sheet
            .locator('tbody tr')
            .evaluateAll((rows) =>
              rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
            );
          assert.deepEqual(
            body.map((r) => r[0]),
            (await dbList(ctx)).map(([c]) => c),
          );
          assert.deepEqual(
            body.find((r) => r[0] === '199901'),
            ['199901', 'E2EP PRINT', GROUP.code, '', 'SURAT', '9800000003', ''],
          );
          return {
            observation: `printed ${body.length} accounts`,
            expected: 'the listed accounts by code',
            output: { rows: body },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      "The boxes' Enter keys in tab order with the group code (:7030-7069), the GST state (:6978-7018), the opening formats and Silver's jump to Mobile No2 (:8071-8160), Khata No to Save (:8468-8477), Ctrl+E (:6735-6745), the list's Enter (:6704-6733), Esc and the &Save mnemonic",
      async (ctx) =>
        withCase(ctx, async () => {
          await exec(ctx, `DELETE FROM "STATE_MAST" WHERE tenant_id=$1 AND "STATE_CODE"='27'`);
          await exec(
            ctx,
            `INSERT INTO "STATE_MAST"(tenant_id,"STATE_CODE","STATE_NAME") VALUES ($1,'27','MAHARASHTRA')`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('Control+e');
          await waitFocus(page, 'party-code');
          await page.locator('#party-code').fill('199903');
          await page.keyboard.press('Enter');
          await waitFocus(page, 'Ac Name');
          const steps = [
            ['e2ep keyed party', 'Ac Group'],
            [GROUP.code, 'Ac Type'],
            ['', 'Mobile No'],
            ['9833333333', 'Phone No'],
            ['', 'Con Person'],
            ['', 'Ac Short'],
            ['', 'Address1'],
            ['', 'Address2'],
            ['', 'Address3'],
            ['', 'City'],
            ['', 'Pin Code'],
            ['', 'City Area'],
            ['', 'Gst No'],
            ['27AAAAA0000A1Z5', 'Gst Type'],
            ['', 'Pan No'],
            ['', 'Lcs No'],
            ['', 'State'],
            ['', 'District'],
            ['', 'Main Ac'],
            ['', 'Birth Date'],
            ['15081990', 'Anv Dt'],
            ['', 'L Birth Dt'],
            ['', 'Ref By'],
            ['', 'Amount'],
            ['250', 'Amount Cr/Dr'],
            ['', 'Gold'],
            ['', 'Gold Cr/Dr'],
            ['', 'Silver'],
            ['', 'Silver Cr/Dr'],
            ['', 'Mobile No2'],
            ['', 'Phone No2'],
            ['', 'Adhar No'],
            ['', 'Passport No'],
            ['', 'Country'],
            ['', 'Bank Name'],
            ['', 'Branch Name'],
            ['', 'Bank AcNo'],
            ['', 'ISFC Code'],
            ['', 'Email'],
            ['', 'Cr Day'],
            ['', 'Month Int %'],
            ['', 'Dpc %'],
            ['', 'Khata No'],
            ['', 'Save'],
          ];
          for (const [text, want] of steps) {
            if (text) await page.keyboard.type(text);
            await page.keyboard.press('Enter');
            await waitFocus(page, want);
          }
          assert.equal(await label(page, 'State').inputValue(), 'MAHARASHTRA');
          assert.equal(await label(page, 'Gst Type').inputValue(), 'I');
          assert.equal(await label(page, 'Amount').inputValue(), '250.00');
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          await page.getByTestId('party-list').locator('tr[data-code="199903"]').focus();
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/199903`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await waitFocus(page, 'Ac Name');
          await label(page, 'Pin Code').fill('395009');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/party'));
          const [row] = await partyRows(ctx, '199903');
          assert.deepEqual(
            [row.name, row.grp, row.main_gr, row.mobile, row.gst_type, row.state, row.pin, row.br],
            [
              'E2EP KEYED PARTY',
              GROUP.code,
              GROUP.main,
              '9833333333',
              'I',
              'MAHARASHTRA',
              '395009',
              '15/08/1990',
            ],
          );
          return {
            observation:
              'keyed in with Ctrl+E and Enter through both tabs and the opening, saved with Enter, reopened and saved with Alt+S, Esc left',
            expected: 'the desktop keys',
            database: { row },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.party-opening-and-address',
      'T18',
      'mutation',
      "The D button copies an Address master entry into a new party (BtnAdd_Click :8501-8530); the party's opening written here is the one the Party Opening menu reads and edits (TR_AC_OPBL reads OP_DATA of book 000, TR_AC_OPBL.cs:2540-2560), and its legs stand in the ledger",
      async (ctx) =>
        withCase(ctx, async () => {
          await exec(
            ctx,
            `INSERT INTO "ADD_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_ADD1","AC_CITY","AC_MOBILE","BR_DATE")
             VALUES ($1,'01','01','019991','E2EP ADDRESS BOOK','5 STATION ROAD','VAPI','9811100000','10/10/1985')`,
          );
          const { page } = await ctx.session();
          await openScreen(page);
          await button(page, 'Copy an address').click();
          const help = page.getByTestId('party-help');
          await help.waitFor();
          await waitFocus(page, 'Help search');
          await page.keyboard.type('E2EP ADD');
          await page.waitForFunction(
            () => document.querySelectorAll('[data-testid="party-help"] tr').length === 1,
          );
          await Promise.all([
            page.waitForResponse((r) => path(r) === `/api${API}/copy/address`),
            page.keyboard.press('Enter'),
          ]);
          await page.waitForFunction(
            () => document.querySelector('[aria-label="Ac Name"]')?.value === 'E2EP ADDRESS BOOK',
          );
          assert.equal(await label(page, 'Address1').inputValue(), '5 STATION ROAD');
          assert.equal(await label(page, 'Birth Date').inputValue(), '10/10/1985');
          await fill(page, { 'Ac Group': GROUP.code });
          await label(page, 'Amount').fill('1250');
          await label(page, 'Gold').fill('3.25');
          await label(page, 'Gold Cr/Dr').selectOption('D');
          const code = await page.locator('#party-code').inputValue();
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const opening = await (await page.request.get(`/api/ac-opbl/${code}`)).json();
          assert.equal(Number(opening.amount), 1250);
          assert.equal(opening.sign, 'C');
          assert.equal(Number(opening.gold), 3.25);
          assert.equal(opening.goldSign, 'D');
          const [row] = await partyRows(ctx, code);
          assert.deepEqual(
            [row.a1, row.city, row.mobile, row.br],
            ['5 STATION ROAD', 'VAPI', '9811100000', '10/10/1985'],
          );
          const legs = await ctx.rows(
            `SELECT right("LEDR_KEY",2) k FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 AND "CO_BOOK"='000' ORDER BY 1`,
            code,
          );
          assert.deepEqual(
            legs.map((l) => l.k),
            ['01', '04'],
          );
          return {
            observation: `${code} copied from the address book; Party Opening reads 1250 Cr and 3.250 gold Dr; legs 01/04`,
            expected: 'one opening shared by both menus',
            database: { row, legs },
            downstream: { partyOpening: opening },
          };
        }),
    ),
  ],
};
