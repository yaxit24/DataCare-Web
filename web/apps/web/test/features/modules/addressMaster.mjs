import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Address (desktop MS_ADD_MAST, web /masters/addresses).
 *
 * Desktop rules used for the expected values (MS_ADD_MAST.cs unless noted):
 * - The menu button 'Address' opens MS_ADD_MAST directly (MDI_FORM.cs:7610-7619). The list is the location's ADD_MAST
 *   rows by AC_CODE (:3119-3396); CLEAR_DATA (:3454-3547) offers the next code read-only with the cursor in the name;
 *   the Company Detail tab holds the boxes in tab order, Other Detail the second mobile and phone.
 * - Save (:4411-4515): an opened address needs the edit right; "Please Select Customer name and try...."; the code's row
 *   of the location is replaced by every box upper-cased (:3604-3617), a date box that is not a date as NULL, MAIN_USER
 *   (the user for a new address, the stored one for an opened one) and DATA_TRFR 'N'; "Data Are Saved.".
 * - Keys: F1 on the name and the F1 button open the help (:3740-3775); typing a name lists up to 99 of the company's
 *   addresses whose name starts with it (:4171-4294); Enter on a blank name says "Please Insert Party Name ..."; Enter on
 *   the mobile of a new entry refuses a mobile the company has (:3867-3887); Enter moves on and on L Birth Date goes to
 *   Save; Ctrl+E unlocks the code (:3721-3738); Esc leaves.
 * - Leaving the name refuses a name another code has (:4389-4409).
 * - Delete (:4517-4544): "Please Select AcCode For Delete.", "Are You Sure To Delete This Account now?", the address and
 *   its book-000 OP_DATA and AC_DATA rows of the year deleted, "Delete Success.".
 * Web rules that differ on purpose (gap G230): the next code is the location prefix and four digits; one transaction;
 * version tokens; Print lists the addresses on screen.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `address-master.${id}`,
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
const notApplicable = (name, group, source, reason) => ({
  ...C(`${name}.not-applicable`, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const API = '/masters/address-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This address was changed by someone else after you opened it. Open it again before saving or deleting.';
const QUESTION = 'Are You Sure To Delete This Account now?';
/** The cases use the location's codes 019901-019909 and their own names. */
const CASE_CODES = ['019901', '019902', '019903', '019904', '019905'];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) =>
  page.evaluate(
    () =>
      document.activeElement?.getAttribute('aria-label') ||
      document.activeElement?.id ||
      document.activeElement?.dataset?.code ||
      document.activeElement?.textContent?.trim() ||
      '',
  );
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

const addressRows = (ctx, code) =>
  ctx.rows(
    `SELECT "LC_CODE" lc,"AC_CODE" code,"AC_NAME" name,"AC_GR" grp,"AC_MOBILE" mobile,"AC_PHONE" phone,"AC_PERSON" person,
            "AC_ADD1" a1,"AC_ADD2" a2,"AC_ADD3" a3,"AC_CITY" city,"AC_PIN" pin,"AC_AREA" area,"AC_COUNTRY" country,
            "AC_STATE" state,"AC_DISTRICT" district,"AC_EMAIL" email,"AC_MOBILE2" mobile2,"AC_PHONE2" phone2,
            "BR_DATE" br,"AN_DATE" an,to_char("L_BR_DATE",'YYYY-MM-DD') lbr,"MAIN_USER" main,"DATA_TRFR" trfr,row_id::text rid
       FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2 ORDER BY row_id`,
    code,
  );
const allAddresses = (ctx) =>
  ctx.rows(
    `SELECT to_jsonb(a) AS r FROM "ADD_MAST" a WHERE tenant_id=$1 ORDER BY "AC_CODE",row_id`,
  );
const dbList = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "AC_CODE" code,"AC_NAME" name FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' ORDER BY "AC_CODE",row_id`,
    )
  ).map((r) => [String(r.code ?? '').trim(), String(r.name ?? '').trim()]);
async function cleanCase(ctx) {
  await exec(
    ctx,
    `DELETE FROM "ADD_MAST" WHERE tenant_id=$1 AND ("AC_CODE" = ANY($2::text[]) OR "AC_NAME" LIKE 'E2E %')`,
    CASE_CODES,
  );
  await exec(
    ctx,
    `DELETE FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
    CASE_CODES,
  );
}
async function seedAddress(ctx, code, name, extra = {}) {
  await exec(
    ctx,
    `INSERT INTO "ADD_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE","AC_CITY","MAIN_USER","DATA_TRFR")
     VALUES ($1,'01',$2,$3,$4,$5,$6,$7,'N')`,
    extra.lc ?? '01',
    code,
    name,
    extra.mobile ?? null,
    extra.city ?? 'E2E CITY',
    extra.main ?? 'DESKUSER',
  );
}
async function withCase(ctx, run) {
  await cleanCase(ctx);
  try {
    return await run();
  } finally {
    await cleanCase(ctx);
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/addresses'),
  ]);
  await page.getByRole('heading', { name: 'Address Master', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(
      () => document.activeElement?.getAttribute('aria-label') === 'Ac Name',
    );
  return response;
}
const listed = (page) =>
  page
    .getByTestId('address-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openAddress(page, code, how = 'enter') {
  const row = page.getByTestId('address-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#address-code');
    return box?.value === c && document.activeElement?.getAttribute('aria-label') === 'Ac Name';
  }, code);
  return response.json();
}
const BOXES = {
  name: 'Ac Name',
  group: 'Ac Group',
  mobile: 'Mobile No',
  phone: 'Phone No',
  person: 'Con Person',
  address1: 'Address1',
  address2: 'Address2',
  address3: 'Address3',
  city: 'City',
  pin: 'Pin Code',
  area: 'City Area',
  country: 'Country',
  state: 'State',
  district: 'District',
  email: 'Email',
  birthDate: 'Birth Date',
  anniversary: 'Anv Date',
  lBirthDate: 'L Birth Date',
};
async function fill(page, values) {
  for (const [key, value] of Object.entries(values)) {
    if (key === 'mobile2' || key === 'phone2') {
      await page.getByRole('tab', { name: 'Other Detail', exact: true }).click();
      await label(page, key === 'mobile2' ? 'Mobile No2' : 'Phone No2').fill(value);
      await page.getByRole('tab', { name: 'Company Detail', exact: true }).click();
    } else await label(page, BOXES[key]).fill(value);
  }
}
async function setCode(page, code) {
  await page.keyboard.press('Control+e');
  await page.waitForFunction(() => !document.querySelector('#address-code')?.readOnly);
  await page.locator('#address-code').fill(code);
}
async function save(page, trigger = () => button(page, 'Save').click()) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => ['POST', 'PUT'].includes(r.request().method()) && path(r).startsWith(`/api${API}`),
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
const FULL = {
  name: 'e2e ramesh shah',
  group: 'e2e customer',
  mobile: '9811111111',
  phone: '0261-2345678',
  person: 'suresh',
  address1: '12 ring road',
  address2: 'near market',
  address3: 'block b',
  city: 'surat',
  pin: '395002',
  area: 'adajan',
  country: 'india',
  state: 'gujarat',
  district: 'surat',
  email: 'ramesh@example.com',
  birthDate: '15/08/1990',
  anniversary: '31/02/2020',
  lBirthDate: '01/01/1960',
  mobile2: '9822222222',
  phone2: '0261-1111111',
};

export const addressMaster = {
  feature: 'address-master',
  title: 'Master → Address (MS_ADD_MAST)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/addresses/page.tsx',
    'web/apps/api/src/modules/masters/addressMaster.ts',
    'web/apps/api/src/routes/addressMaster.ts',
    'web/apps/web/test/features/modules/addressMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7610-7619 opens MS_ADD_MAST; CLEAR_DATA (:3454-3547) the next code read-only, cursor in the name, SEARCH RECORD; the list of the location by code; the Company Detail tab in the form spec tab order, Other Detail with the second mobile and phone',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019902', 'E2E BETA');
          await seedAddress(ctx, '019901', 'E2E ALPHA');
          const { page } = await ctx.session();
          await openScreen(page);
          const codeBox = page.locator('#address-code');
          assert.equal(await codeBox.evaluate((el) => el.readOnly), true);
          assert.match(await codeBox.inputValue(), /^01\d{4}$/);
          assert.equal(await label(page, 'Search record').inputValue(), 'SEARCH RECORD');
          const list = await listed(page);
          assert.deepEqual(list, await dbList(ctx));
          const tabs = (await page.getByRole('tab').allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(tabs, ['Company Detail', 'Other Detail', 'Family Detl']);
          // Save is the main action (the surface crawl presses the first `primary` button); the selected tab is not.
          const primaries = (await page.locator('main button.primary').allInnerTexts()).map((t) =>
            t.trim(),
          );
          assert.deepEqual(primaries, ['Save']);
          assert.equal(
            await page
              .getByRole('tab', { name: 'Company Detail', exact: true })
              .getAttribute('aria-selected'),
            'true',
          );
          const order = await page.evaluate(() =>
            [...document.querySelectorAll('main input,main button')]
              .filter((el) => !el.closest('nav') && el.tabIndex >= 0 && el.offsetParent !== null)
              .map((el) => el.getAttribute('aria-label') || el.id || el.textContent.trim()),
          );
          assert.deepEqual(order.slice(0, 25), [
            'address-code',
            'Ac Name',
            'Ac Group',
            'Mobile No',
            'Phone No',
            'Con Person',
            'Address1',
            'Address2',
            'Address3',
            'City',
            'Pin Code',
            'City Area',
            'Country',
            'State',
            'District',
            'Email',
            'Birth Date',
            'Anv Date',
            'L Birth Date',
            'Save',
            'Print',
            'Cancel',
            'Delete',
            'Exit',
            'Search record',
          ]);
          await page.getByRole('tab', { name: 'Other Detail', exact: true }).click();
          assert.ok(await label(page, 'Mobile No2').isVisible());
          assert.ok(await label(page, 'Phone No2').isVisible());
          return {
            observation: `next code ${await codeBox.inputValue()}, ${list.length} addresses of the location, tabs ${tabs.join('/')}`,
            expected: { tabs },
          };
        }),
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:4441-4467) writes every box of both tabs, the dates as the masked text (BR_DATE, AN_DATE) and a date (L_BR_DATE), MAIN_USER and DATA_TRFR N; DISPLAY_DATA (:3549-3583) shows them again',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await setCode(page, '019901');
          await fill(page, FULL);
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const [row] = await addressRows(ctx, '019901');
          const { rid, ...stored } = row;
          assert.deepEqual(stored, {
            lc: '01',
            code: '019901',
            name: 'E2E RAMESH SHAH',
            grp: 'E2E CUSTOMER',
            mobile: '9811111111',
            phone: '0261-2345678',
            person: 'SURESH',
            a1: '12 RING ROAD',
            a2: 'NEAR MARKET',
            a3: 'BLOCK B',
            city: 'SURAT',
            pin: '395002',
            area: 'ADAJAN',
            country: 'INDIA',
            state: 'GUJARAT',
            district: 'SURAT',
            email: 'RAMESH@EXAMPLE.COM',
            mobile2: '9822222222',
            phone2: '0261-1111111',
            br: '15/08/1990',
            an: null,
            lbr: '1960-01-01',
            main: USERS.admin.user,
            trfr: 'N',
          });
          await openAddress(page, '019901');
          assert.equal(await label(page, 'City').inputValue(), 'SURAT');
          assert.equal(await label(page, 'Birth Date').inputValue(), '15/08/1990');
          assert.equal(await label(page, 'L Birth Date').inputValue(), '01/01/1960');
          return {
            observation: 'every box stored upper-cased; 31/02/2020 is not a date and stored NULL',
            expected: stored,
            database: { row },
            downstream: { reopened: true },
          };
        }),
    ),
    C(
      'field.typing-and-dates',
      'T03',
      'mutation',
      'MS_ADD_MAST_KeyPress (:3604-3617) upper-cases every key (the email too) and refuses the apostrophe; Information.IsDate decides each date box (:4459-4461)',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await setCode(page, '019902');
          await label(page, 'Ac Name').focus();
          await page.keyboard.type("e2e o'neil");
          assert.equal(await label(page, 'Ac Name').inputValue(), 'E2E ONEIL');
          await fill(page, {
            email: 'a.b@x.in',
            birthDate: '29/02/2024',
            anniversary: '29/02/2023',
          });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const [row] = await addressRows(ctx, '019902');
          assert.deepEqual(
            [row.name, row.email, row.br, row.an],
            ['E2E ONEIL', 'A.B@X.IN', '29/02/2024', null],
          );
          return {
            observation: '29/02/2024 kept, 29/02/2023 stored NULL, the email upper-cased',
            expected: { br: '29/02/2024', an: null },
            database: { row },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'field.ctrl-e-focuses-code-at-once',
      'T03',
      'read-only',
      'Ctrl+E (MS_ADD_MAST_KeyDown, :3721-3738) unlocks the code box and puts the cursor in it in one step; the web must not leave a gap in which the box is editable but the cursor is elsewhere (a late timer then stole the cursor from the name being typed)',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await page.evaluate(() => {
            const box = document.querySelector('#address-code');
            window.__codeFocusWhenEditable = [];
            new MutationObserver(() => {
              if (!box.readOnly)
                window.__codeFocusWhenEditable.push(document.activeElement === box);
            }).observe(box, { attributes: true, attributeFilter: ['readonly'] });
          });
          await page.keyboard.press('Control+e');
          await page.waitForFunction(() => !document.querySelector('#address-code')?.readOnly);
          // A timer (the old code) fires after this wait; give it its chance before looking.
          await page.waitForTimeout(250);
          const seen = await page.evaluate(() => window.__codeFocusWhenEditable);
          assert.deepEqual(
            seen,
            [true],
            'the code box has the cursor in the commit that unlocks it',
          );
          assert.equal(await focusedId(page), 'address-code');
          return {
            observation: 'the code box had the cursor the moment it became editable',
            expected: { codeFocusWhenEditable: [true] },
            database: {},
            downstream: { focused: 'address-code' },
          };
        }),
    ),
    C(
      'lookup.help-and-name-list',
      'T04',
      'read-only',
      "F1 on the name (and the F1 button) opens the help of the location's addresses by name (:3740-3775, BtnF1_Click); typing a name lists up to 99 of the company's addresses whose name starts with it, other locations included (:4171-4294); the search box keeps the names that start with its text (:3641-3665)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E ZETA');
          await seedAddress(ctx, '019902', 'E2E ALPHA');
          await seedAddress(ctx, '029903', 'E2E ALPHA OTHER', { lc: '02' });
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('F1');
          const help = page.getByTestId('address-help');
          await help.waitFor();
          const helpRows = (
            await help.locator('tr').evaluateAll((rows) => rows.map((tr) => tr.dataset.code))
          ).filter((c) => c.startsWith('0199'));
          assert.deepEqual(helpRows, ['019902', '019901'], 'by name, this location only');
          await page.keyboard.press('Escape');
          await page.waitForFunction(() => !document.querySelector('[data-testid="address-help"]'));
          await label(page, 'Ac Name').focus();
          // Every key asks again; answers for shorter text are dropped, so wait for the answer to the whole text
          // (attached before typing) and for the other location's row.
          const typedAnswer = page.waitForResponse(
            (r) =>
              path(r) === `/api${API}/names` &&
              (new URL(r.url()).searchParams.get('q') ?? '').toUpperCase() === 'E2E ALP',
          );
          await page.keyboard.type('e2e alp');
          await typedAnswer;
          await page.waitForFunction(() => {
            const rows = [...document.querySelectorAll('[data-testid="address-list"] tr')];
            return rows.length === 2 && rows.some((tr) => tr.textContent.includes('029903'));
          });
          const typedList = await listed(page);
          assert.deepEqual(
            typedList.map((r) => r[0]).sort(),
            ['019902', '029903'],
            'the company, other locations included',
          );
          return {
            observation: `help ${helpRows.join(',')}; typing listed ${typedList.map((r) => r[0]).join(',')}`,
            expected: { help: ['019902', '019901'] },
          };
        }),
    ),
    notApplicable(
      'children',
      'T05',
      'MS_ADD_MAST has no child grid; the Family Detl tab holds no box in the form spec',
      'MS_ADD_MAST writes one ADD_MAST row per address; it has no child rows',
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'Save (:4436-4440) refuses a blank name with "Please Select Customer name and try...."; Enter on a blank name says "Please Insert Party Name ..."; leaving the name taken by another code (:4389-4409); Enter on a mobile the company has (:3867-3887); nothing written',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E TAKEN', { mobile: '9800000001' });
          const before = await allAddresses(ctx);
          const { page, requests } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('Enter');
          await message(page, 'Please Insert Party Name ...');
          await button(page, 'Save').click();
          await message(page, 'Please Select Customer name and try....');
          await label(page, 'Ac Name').fill('e2e taken');
          await label(page, 'Ac Group').focus();
          await message(
            page,
            "This Ac Name already Exist in  '019901'  Ac Code... Please Change Account Name...",
          );
          await label(page, 'Ac Name').fill('e2e new');
          await label(page, 'Mobile No').fill('9800000001');
          await label(page, 'Mobile No').press('Enter');
          await message(page, 'This Mobile No = E2E TAKEN  With this Account .....');
          assert.equal(await focusedId(page), 'Mobile No');
          assert.equal(requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length, 0);
          assert.deepEqual(await allAddresses(ctx), before);
          return {
            observation: 'every refusal shown with the desktop text; nothing sent',
            expected: 'no ADD_MAST row changed',
            database: { rows: before.length },
          };
        }),
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      'A new address writes one ADD_MAST row of the location (:4441-4467) and no other table changes; the next entry offers the next code',
      async (ctx) =>
        withCase(ctx, async () => {
          const counts = async () =>
            (
              await ctx.rows(
                `SELECT (SELECT count(*)::int FROM "ADD_MAST" WHERE tenant_id=$1) a,
                        (SELECT count(*)::int FROM "AC_MAST" WHERE tenant_id=$1) m,
                        (SELECT count(*)::int FROM "OP_DATA" WHERE tenant_id=$1) o`,
              )
            )[0];
          const before = await counts();
          const { page } = await ctx.session();
          await openScreen(page);
          const offered = await page.locator('#address-code').inputValue();
          await fill(page, { name: 'e2e footprint' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          const after = await counts();
          assert.deepEqual(after, { ...before, a: before.a + 1 });
          const [row] = await addressRows(ctx, offered);
          assert.equal(row.name, 'E2E FOOTPRINT');
          const nextCode = await page.locator('#address-code').inputValue();
          assert.equal(Number(nextCode.slice(2)), Number(offered.slice(2)) + 1);
          await exec(ctx, `DELETE FROM "ADD_MAST" WHERE tenant_id=$1 AND "AC_CODE"=$2`, offered);
          return {
            observation: `saved ${offered}; the next entry offers ${nextCode}`,
            expected: 'one row, the next number',
            database: { before, after },
            downstream: { nextCode },
          };
        }),
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      'DISPLAY_DATA then Save with nothing changed replaces the row with the same boxes; MAIN_USER stays the stored user (:3577)',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E REOPEN', {
            main: 'DESKUSER',
            mobile: '9800000002',
          });
          const [before] = await addressRows(ctx, '019901');
          const { page } = await ctx.session();
          await openScreen(page);
          await openAddress(page, '019901');
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const [after] = await addressRows(ctx, '019901');
          // The desktop writes each box's text, so a NULL box comes back as an empty one (:4444-4466).
          const norm = ({ rid, ...r }) =>
            Object.fromEntries(Object.entries(r).map(([k, v]) => [k, v ?? '']));
          assert.deepEqual(norm(after), norm(before));
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
      'An opened address saves its changed boxes on both tabs (:4441-4467)',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E EDIT');
          const { page } = await ctx.session();
          await openScreen(page);
          await openAddress(page, '019901', 'dblclick');
          await fill(page, { city: 'navsari', pin: '396445', phone2: '02637-222222' });
          assert.equal((await save(page)).status(), 200);
          await saved(page);
          const [row] = await addressRows(ctx, '019901');
          assert.deepEqual(
            [row.city, row.pin, row.phone2, row.main],
            ['NAVSARI', '396445', '02637-222222', 'DESKUSER'],
          );
          return {
            observation: 'city, pin and the second phone saved',
            expected: { city: 'NAVSARI' },
            database: { row },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:4517-4544): a blank code is refused; the question comes first; Yes deletes the address with its book-000 OP_DATA row of the year; No keeps it',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E DELETE');
          const { page } = await ctx.session();
          const year = (await (await page.request.get('/api/me')).json()).coYear;
          await exec(
            ctx,
            `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN")
             VALUES ($1,'01','01',$2,'000','00001','019901',500,'D')`,
            year,
          );
          let questions = answerQuestions(page, false);
          await openScreen(page);
          await openAddress(page, '019901');
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.deepEqual(questions, [QUESTION]);
          assert.equal((await addressRows(ctx, '019901')).length, 1, 'No keeps it');
          questions = answerQuestions(page, true);
          const [removed] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/019901`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(removed.status(), 200, await removed.text());
          await message(page, 'Delete Success.');
          const opening = await ctx.rows(
            `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"='019901'`,
          );
          assert.deepEqual(await addressRows(ctx, '019901'), []);
          assert.equal(opening[0].n, 0);
          return {
            observation: 'No kept the address; Yes deleted it and its opening row',
            expected: 'the address and its OP_DATA row gone',
            database: { opening },
            downstream: { list: await listed(page) },
          };
        }),
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_ADD_MAST_Load reads FRM_EDIT/FRM_DELETE/FRM_PRINT of the user\'s rights row (:3119-3135): Save of an opened address, Delete and Print answer "You Have No Rights....." / "You Have No Print Rights....."; a new address needs only the view right',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E RIGHTS');
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "ADD_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,'01','01','019901','SENTINEL')`,
            SECOND_TENANT,
          );
          await exec(
            ctx,
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
             VALUES ($1,'01','01',$2,'Master','Address','Y','N','N','N')`,
            USERS.clerk.user,
          );
          try {
            const { page, requests } = await ctx.session(as(USERS.clerk.user));
            await openScreen(page);
            const opened = await openAddress(page, '019901');
            await fill(page, { city: 'changed' });
            await button(page, 'Save').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Delete').click();
            await message(page, 'You Have No Rights.....');
            await button(page, 'Print').click();
            await message(page, 'You Have No Print Rights.....');
            assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
            const direct = [
              (
                await page.request.put(`/api${API}/019901`, {
                  data: { name: 'X', expectedVersion: opened.version },
                })
              ).status(),
              (
                await page.request.delete(`/api${API}/019901?expectedVersion=${opened.version}`)
              ).status(),
              (await page.request.get(`/api${API}/print`)).status(),
            ];
            assert.deepEqual(direct, [403, 403, 403]);
            await cancel(page);
            await fill(page, { name: 'e2e clerk address' });
            const created = await save(page);
            assert.equal(created.status(), 201, await created.text());
            await saved(page);
            const rows = await ctx.rows(
              `SELECT "AC_NAME" name,"MAIN_USER" main FROM "ADD_MAST" WHERE tenant_id=$1 AND "AC_NAME" IN ('E2E RIGHTS','E2E CLERK ADDRESS') ORDER BY 1`,
            );
            assert.deepEqual(rows, [
              { name: 'E2E CLERK ADDRESS', main: USERS.clerk.user },
              { name: 'E2E RIGHTS', main: 'DESKUSER' },
            ]);
            const sentinel = await ctx.owner.$queryRawUnsafe(
              `SELECT "AC_NAME" name FROM "ADD_MAST" WHERE tenant_id=$1 AND "AC_CODE"='019901'`,
              SECOND_TENANT,
            );
            assert.deepEqual(sentinel, [{ name: 'SENTINEL' }]);
            return {
              observation: `clerk refused on screen; direct ${direct.join('/')}; clerk created an address`,
              expected:
                'the desktop texts, 403s, a new address allowed, the sentinel tenant untouched',
              database: { rows, sentinel },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Address'`,
              USERS.clerk.user,
            );
            await ctx.owner.$executeRawUnsafe(
              `DELETE FROM "ADD_MAST" WHERE tenant_id=$1 AND "AC_CODE"='019901'`,
              SECOND_TENANT,
            );
          }
        }),
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one address: the first save wins and the second is refused with 409 (version token, G230) where the desktop lets the later save win',
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E RACE');
          const a = (await ctx.session()).page;
          const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
          await openScreen(a);
          await openScreen(b);
          await openAddress(a, '019901');
          await openAddress(b, '019901');
          await fill(a, { city: 'city a' });
          const first = await save(a);
          assert.equal(first.status(), 200, await first.text());
          await saved(a);
          await fill(b, { city: 'city b' });
          const second = await save(b);
          assert.equal(second.status(), 409);
          await message(b, CONFLICT);
          const [row] = await addressRows(ctx, '019901');
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
      "A replayed edit carries a spent version and is refused (409); a replayed new address has the same code, so it replaces the same row (BtnSave_Click's DELETE + INSERT) and no second row appears",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E RETRY');
          const { page } = await ctx.session();
          await openScreen(page);
          await openAddress(page, '019901');
          await fill(page, { pin: '111111' });
          const first = await save(page);
          assert.equal(first.status(), 200);
          await saved(page);
          const replayEdit = (await page.request.fetch(first.request())).status();
          assert.equal(replayEdit, 409);
          await setCode(page, '019902');
          await fill(page, { name: 'e2e retry new' });
          const created = await save(page);
          assert.equal(created.status(), 201);
          await saved(page);
          const replayCreate = (await page.request.fetch(created.request())).status();
          assert.equal(replayCreate, 201);
          const rows = await addressRows(ctx, '019902');
          assert.equal(rows.length, 1);
          return {
            observation: `replayed edit ${replayEdit}; replayed create ${replayCreate}; one row`,
            expected: 'the edit replay refused, one row',
            database: { rows },
            downstream: { replayEdit, replayCreate },
          };
        }),
    ),
    C(
      'rollback.insert-fault',
      'T14',
      'mutation',
      "BtnSave_Click deletes the code's row before it inserts the new one (:4441-4443); a fault on the insert must roll the delete back (the desktop would leave the address deleted)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E FAULT BASE');
          const before = await allAddresses(ctx);
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION e2e_address_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
             BEGIN
               IF NEW."AC_CITY" = 'E2EFAULT' THEN RAISE EXCEPTION 'e2e fault after the delete'; END IF;
               RETURN NEW;
             END $f$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER e2e_address_fault BEFORE INSERT ON "ADD_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_address_fault()`,
          );
          try {
            const { page } = await ctx.session();
            await openScreen(page);
            await openAddress(page, '019901');
            await fill(page, { city: 'e2efault' });
            const failed = await save(page);
            assert.equal(failed.status(), 400, await failed.text());
            assert.deepEqual(await allAddresses(ctx), before);
            return {
              observation: `the save answered ${failed.status()}; every ADD_MAST row is as before`,
              expected: 'no row lost',
              database: { rows: before.length },
              downstream: { status: failed.status() },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(
              `DROP TRIGGER IF EXISTS e2e_address_fault ON "ADD_MAST"`,
            );
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_address_fault()`);
          }
        }),
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'ADD_MAST has no year: MS_ADD_MAST reads and writes by CO_CODE, LC_CODE and AC_CODE (:3119-3396, :4441), so an address saved in this year is listed in the historic year too',
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session(
            as(USERS.admin.user, `${USERS.admin.user}#address-history`),
          );
          await openScreen(page);
          await setCode(page, '019901');
          await fill(page, { name: 'e2e year address' });
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          await page.getByRole('combobox', { name: 'FINANCIAL YEAR' }).selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          await openScreen(page);
          const list = await listed(page);
          assert.ok(list.some(([c, n]) => c === '019901' && n === 'E2E YEAR ADDRESS'));
          return {
            observation: `the historic year lists 019901 among ${list.length}`,
            expected: 'the same addresses in every year',
            database: { rows: await addressRows(ctx, '019901') },
            downstream: { historicYearList: list },
          };
        }),
    ),
    C(
      'output.print',
      'T16',
      'output',
      "BtnPrint_Click (:3675-3689) prints the location's addresses (PartyMast, {ADD_MAST.CO_CODE} and LC_CODE); the layout is not in the repository, so the web lists them on screen by code (G230)",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '019901', 'E2E PRINT', { mobile: '9800000003', city: 'SURAT' });
          const { page } = await ctx.session();
          await openScreen(page);
          const [response] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/print`)),
            button(page, 'Print').click(),
          ]);
          assert.equal(response.status(), 200);
          const sheet = page.getByTestId('address-print');
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
            body.find((r) => r[0] === '019901'),
            ['019901', 'E2E PRINT', '', 'SURAT', '', '9800000003', ''],
          );
          return {
            observation: `printed ${body.length} addresses`,
            expected: 'the location by code',
            output: { rows: body },
          };
        }),
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      "The boxes' Enter keys (:3740-3937, :4296-4325), Ctrl+E (:3721-3738), the list keys (:3690-3719), Esc and the &Save mnemonic",
      async (ctx) =>
        withCase(ctx, async () => {
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.press('Control+e');
          await page.waitForFunction(() => document.activeElement?.id === 'address-code');
          await page.locator('#address-code').fill('019903');
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'Ac Name');
          const steps = [
            ['e2e keyed address', 'Ac Group'],
            ['e2e group', 'Mobile No'],
            ['9833333333', 'Phone No'],
            ['', 'Con Person'],
            ['', 'Address1'],
            ['', 'Address2'],
            ['', 'Address3'],
            ['', 'City'],
            ['', 'Pin Code'],
            ['', 'City Area'],
            ['', 'Country'],
            ['', 'State'],
            ['', 'District'],
            ['', 'Email'],
            ['', 'Birth Date'],
            ['15081990', 'Anv Date'],
            ['', 'L Birth Date'],
            ['', 'Save'],
          ];
          for (const [text, focus] of steps) {
            if (text) await page.keyboard.type(text);
            await page.keyboard.press('Enter');
            await page.waitForFunction(
              (want) =>
                (document.activeElement?.getAttribute('aria-label') ||
                  document.activeElement?.textContent?.trim()) === want,
              focus,
            );
          }
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          await page.getByTestId('address-list').locator('tr[data-code="019903"]').focus();
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/019903`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(
            () => document.activeElement?.getAttribute('aria-label') === 'Ac Name',
          );
          await label(page, 'Pin Code').fill('395009');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/addresses'));
          const [row] = await addressRows(ctx, '019903');
          assert.deepEqual(
            [row.name, row.grp, row.mobile, row.pin, row.br],
            ['E2E KEYED ADDRESS', 'E2E GROUP', '9833333333', '395009', '15/08/1990'],
          );
          return {
            observation:
              'keyed in with Ctrl+E and Enter through every box, saved with Enter, reopened and saved with Alt+S, Esc left',
            expected: 'the desktop keys',
            database: { row },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.address-across-locations',
      'T18',
      'mutation',
      "DISPLAY_DATA reads an address of the company whatever its location (:3551) and Save writes the row of the operator's location (:4441-4446): an address of location 02 opened from the name list and saved is written for location 01 too, and location 02's row is left as it was",
      async (ctx) =>
        withCase(ctx, async () => {
          await seedAddress(ctx, '029904', 'E2E LOCATION TWO', { lc: '02', city: 'MUMBAI' });
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Ac Name').focus();
          await page.keyboard.type('e2e location t');
          await page.waitForFunction(() =>
            [...document.querySelectorAll('[data-testid="address-list"] tr')].some(
              (tr) => tr.dataset.code === '029904',
            ),
          );
          await openAddress(page, '029904');
          assert.equal(await label(page, 'City').inputValue(), 'MUMBAI');
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const rows = await addressRows(ctx, '029904');
          assert.deepEqual(
            rows.map((r) => [r.lc, r.name, r.city]),
            [
              ['02', 'E2E LOCATION TWO', 'MUMBAI'],
              ['01', 'E2E LOCATION TWO', 'MUMBAI'],
            ],
          );
          return {
            observation:
              'the location-02 address was saved as a location-01 row as well; location 02 kept its row',
            expected: 'the desktop keys of read and write',
            database: { rows },
            downstream: { list: await listed(page) },
          };
        }),
    ),
  ],
};
