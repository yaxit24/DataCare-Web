import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { escLeavesWithNoFocus, SECOND_TENANT } from '../harness.mjs';

/**
 * Feature: Master → Employee (desktop MS_EMP, web /masters/employees).
 *
 * Desktop rules used for the expected values (MS_EMP.cs unless noted):
 * - The menu button 'Employee' opens MS_EMP directly; its caption is the USER_SET SUB_MENU (MDI_FORM.cs:7660-7669).
 * - The list is the company's EMP_MAST ordered by EMP_NAME (:1144), by EMP_CODE after a delete (:1579). A new entry
 *   has the next code ('001', else the highest + 1 as "000"), blank boxes, SEARCH RECORD and the cursor in the name
 *   (CLEAR_DATA :1241-1273). The user list is a blank entry and the company-01 login names (AddCboItem :1152-1177).
 * - Save (:1462-1550): an opened employee needs the edit right ("You Have No Rights....."); a blank code and name says
 *   "Enter Employee Detail"; the row is replaced with the code, name, account, Val(Amount), Val(Day Hour), the user or
 *   'ABC' when blank, and MainUser (the operator for a new entry :1253, the creator for an opened one :1293); then
 *   "Data Are Saved." and a new entry.
 * - Leaving the code refuses a code another employee has (:1350-1370); leaving the name, a name another code has
 *   (:1391-1411). Enter on a blank name: "Please Insert Employee Name ..." (:1372-1389). Typed keys are upper-cased and
 *   the apostrophe refused (:1319-1332).
 * - Delete (:1552-1584): "Please Select Employee For Delete." for a blank code; "Are You Sure To Delete This Record
 *   now?"; the default employee '001' is refused; then "Delete Success.".
 * - Keys: Enter on Amount and Day Hour shows Val as 0.00 (:1681-1724); Up and Down go to the list and Esc leaves
 *   (:1436-1446); in the list Enter or a double click opens the row, F1 goes to the search box, Backspace shortens it
 *   (:1600-1629). The account box takes a code found in AC_MAST, else lists groups 09, 10 and 45 without 00020 by group
 *   and name (:1631-1680).
 * Web rules that differ on purpose (gap G224): an opened employee carries its version (a stale save or delete is
 * refused with 409); Save refuses a blank name, an unknown account and an unlisted user; Save keeps EMP_TYPE, TDS and PF;
 * Print shows the list on screen (the EmpMast report layout is not in the repository).
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const C = (id, group, kind, source, run, extra = {}) => ({
  id: `employee-master.${id}`,
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

const API = '/masters/employee-master';
const SAVED = 'Data Are Saved.';
const CONFLICT =
  'This employee was changed by someone else after you opened it. Open it again before saving or deleting.';
/** Accounts for the account box: the help shows groups 09, 10 and 45 without 00020 (tEmpAc_KeyDown :1644). */
const ACCOUNTS = [
  ['EMQSAL', 'EMQ STAFF SALARY', '45'],
  ['EMQADV', 'EMQ STAFF ADVANCE', '10'],
  ['EMQCSH', 'EMQ COUNTER CASH', '09'],
  ['00020', 'EMQ EXCLUDED', '10'],
  ['EMQDEB', 'EMQ STAFF DEBTOR', '01'],
];
/** Daily Rate's groups, as its own module seeds them, for the journey through MS_RATE's employee box. */
const RATE_GROUPS = [
  ['R18', 'Rate Gold 18K', 'G', 75, 0, 76],
  ['R22', 'Rate Gold 22K', 'G', 91.6, 3, 92],
  ['RSV', 'Rate Silver 925', 'S', 92.5, 3, 90],
];

const path = (r) => new URL(r.url()).pathname;
const isApi = (r, method, p) => r.request().method() === method && path(r) === `/api${p}`;
const label = (page, text) => page.getByLabel(text, { exact: true });
const button = (page, name) => page.getByRole('button', { name, exact: true });
const focusedId = (page) => page.evaluate(() => document.activeElement?.id ?? '');
const message = (page, text) => page.getByText(text, { exact: true }).waitFor();
const exec = (ctx, sql, ...params) => ctx.owner.$executeRawUnsafe(sql, ctx.tenantId, ...params);

const employees = (ctx) =>
  ctx.rows(
    `SELECT "EMP_CODE" code,"EMP_NAME" name,coalesce("EMP_AC",'') ac,"EMP_AMT"::float amt,
            "DAY_HOURS"::float hours,"USER_NAME" "user",coalesce("MAIN_USER",'') main,"EMP_TYPE" "type",
            "TDS_PRC"::float tds,"TDS_AMT"::float tdsamt,"PF_PRC"::float pf,"PF_AMT"::float pfamt,row_id::text rid
       FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "EMP_CODE",row_id`,
  );
const without = (rows, key = 'rid') => rows.map(({ [key]: _drop, ...rest }) => rest);

/** Replace the company's employees with masters seeded for a case (fixtures seed masters, never the row under test). */
async function resetEmployees(ctx, seed = []) {
  await exec(ctx, `DELETE FROM "EMP_MAST" WHERE tenant_id=$1`);
  for (const e of seed)
    await exec(
      ctx,
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME","EMP_AC","EMP_AMT","DAY_HOURS","USER_NAME",
                              "MAIN_USER","EMP_TYPE","TDS_PRC","TDS_AMT","PF_PRC","PF_AMT")
       VALUES ($1,'01',$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13)`,
      e.code,
      e.name,
      e.ac ?? '',
      e.amt ?? 0,
      e.hours ?? 0,
      e.user ?? 'ABC',
      e.main ?? 'e2eseed',
      e.type ?? null,
      e.tds ?? 0,
      e.tdsAmt ?? 0,
      e.pf ?? 0,
      e.pfAmt ?? 0,
    );
}
async function withAccounts(ctx, run) {
  const added = [];
  for (const [code, name, group] of ACCOUNTS) {
    const inserted = await exec(
      ctx,
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
       SELECT $1::text,'01','01',$2::text,$3::text,$4::text
        WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "AC_CODE"=$2::text)`,
      code,
      name,
      group,
    );
    if (inserted) added.push(code);
  }
  try {
    return await run();
  } finally {
    // 00020 is the web's cash party (eBillWriter), so the case's accounts never outlive it.
    await exec(
      ctx,
      `DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "EMP_AC" = ANY($2::text[])`,
      added,
    );
    await exec(
      ctx,
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
      added,
    );
  }
}

async function openScreen(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', API)),
    page.goto('/masters/employees'),
  ]);
  await page.getByRole('heading', { name: 'Employee Master', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(() => document.activeElement?.id === 'employee-name');
  return response;
}
const listed = (page) =>
  page
    .getByTestId('employee-list')
    .locator('tr')
    .evaluateAll((rows) =>
      rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
    );
async function openEmployee(page, code, how = 'dblclick') {
  const row = page.getByTestId('employee-list').locator(`tr[data-code="${code}"]`);
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', `${API}/${code}`)),
    how === 'enter' ? row.press('Enter') : row.dblclick(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.waitForFunction((c) => {
    const box = document.querySelector('#employee-code');
    return box?.value === c && box.readOnly && document.activeElement?.id === 'employee-name';
  }, code);
  return response.json();
}
const entry = async (page) => ({
  code: await label(page, 'Employee Code').inputValue(),
  name: await label(page, 'Employee Name').inputValue(),
  account: await label(page, 'Account Code').inputValue(),
  accountName: await label(page, 'Account Name').inputValue(),
  user: await label(page, 'User Name').inputValue(),
  amount: await label(page, 'Amount').inputValue(),
  dayHours: await label(page, 'Day Hour').inputValue(),
  codeReadOnly: await label(page, 'Employee Code').evaluate((el) => el.readOnly),
});
/** Press Save (or run `trigger`) and wait for the employee write it sends. */
async function save(page, trigger = () => button(page, 'Save').click()) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) => ['POST', 'PUT'].includes(r.request().method()) && path(r).startsWith(`/api${API}`),
    ),
    trigger(),
  ]);
  return response;
}
/** A saved entry: "Data Are Saved." and a new entry with the cursor in the name (CLEAR_DATA). */
async function saved(page) {
  await message(page, SAVED);
  await page.waitForFunction(
    () =>
      document.activeElement?.id === 'employee-name' &&
      !document.querySelector('#employee-code')?.readOnly &&
      document.querySelector('#employee-name')?.value === '',
  );
}
/** Type into the account box and take the code with Enter (tEmpAc_KeyDown). */
async function pickAccount(page, code) {
  const box = label(page, 'Account Code');
  await box.fill(code);
  await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
  await box.press('Enter');
  await page.waitForFunction(() => document.activeElement?.id === 'employee-user');
}
const fullYear = () => {
  const now = new Date();
  return now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
};
const loginNames = async (ctx) =>
  (
    await ctx.rows(
      `SELECT "LOGIN_NAME" n FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND coalesce("LOGIN_NAME",'')<>''
        GROUP BY "LOGIN_NAME" ORDER BY "LOGIN_NAME"`,
    )
  ).map((r) => r.n);

export const employeeMaster = {
  feature: 'employee-master',
  title: 'Master → Employee (MS_EMP)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/masters/employees/page.tsx',
    'web/apps/web/lib/screenEscape.ts',
    'web/apps/api/src/modules/masters/employeeMaster.ts',
    'web/apps/api/src/routes/employeeMaster.ts',
    'web/packages/core/src/vbVal.ts',
    'web/apps/web/test/features/modules/employeeMaster.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.defaults',
      'T01',
      'read-only',
      'MDI_FORM.cs:7660-7669 opens MS_EMP; CLEAR_DATA (:1241-1273) next code, SEARCH RECORD, cursor in the name; the list ORDER BY EMP_NAME (:1144); AddCboItem (:1152-1177); the form spec layout and tab order',
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER' },
          { code: '002', name: 'ANIL SHAH' },
          { code: '007', name: 'BHAVIN' },
        ]);
        const { page } = await ctx.session();
        await openScreen(page);
        const first = await entry(page);
        assert.deepEqual(first, {
          code: '008',
          name: '',
          account: '',
          accountName: '',
          user: '',
          amount: '',
          dayHours: '',
          codeReadOnly: false,
        });
        assert.equal(await label(page, 'Employee Code').getAttribute('maxlength'), '3');
        assert.equal(await label(page, 'Search record').inputValue(), 'SEARCH RECORD');
        const headers = (
          await page
            .getByTestId('employee-list')
            .locator('xpath=..')
            .locator('thead th')
            .allInnerTexts()
        ).map((t) => t.trim());
        assert.deepEqual(headers, ['Code', 'Name']);
        assert.deepEqual(await listed(page), [
          ['002', 'ANIL SHAH'],
          ['007', 'BHAVIN'],
          ['001', 'COUNTER'],
        ]);
        const users = await label(page, 'User Name')
          .locator('option')
          .evaluateAll((o) => o.map((x) => x.value));
        assert.deepEqual(users, ['', ...(await loginNames(ctx))]);
        // Tab order (form spec): the six boxes, the buttons with Save first, the search box, the list. Print is drawn
        // first (BtnPrint x=827, BtnSave x=924) and the list on the left (DGV x=61).
        const order = await page.evaluate(() =>
          [
            ...document.querySelectorAll(
              'input:not([tabindex="-1"]),select,button,[data-testid="employee-list"] tr',
            ),
          ].map(
            (el) =>
              el.id ||
              el.getAttribute('aria-label') ||
              (el.tagName === 'TR' ? 'list' : el.textContent.trim()),
          ),
        );
        const boxes = [
          'employee-code',
          'employee-name',
          'Account Code',
          'employee-user',
          'employee-amount',
          'employee-day-hours',
        ];
        assert.deepEqual(
          order.filter((n) => boxes.includes(n)),
          boxes,
        );
        const buttons = ['Save', 'Print', 'Cancel', 'Delete', 'Exit'];
        assert.deepEqual(
          order.filter((n) => buttons.includes(n)),
          buttons,
          'Save comes first in the tab order',
        );
        assert.ok(
          order.indexOf('employee-day-hours') < order.indexOf('Save') &&
            order.indexOf('Exit') < order.indexOf('Search record') &&
            order.indexOf('Search record') < order.indexOf('list'),
          `boxes, buttons, search, list: ${order.join(' > ')}`,
        );
        const listBox = await page.getByTestId('employee-list').boundingBox();
        const codeBox = await label(page, 'Employee Code').boundingBox();
        assert.ok(listBox.x < codeBox.x, 'the list is drawn left of the boxes');
        const drawn = [];
        for (const name of buttons) drawn.push([name, (await button(page, name).boundingBox()).x]);
        assert.deepEqual(
          drawn.sort((a, b) => a[1] - b[1]).map(([n]) => n),
          ['Print', 'Save', 'Cancel', 'Delete', 'Exit'],
        );
        // A company without employees starts at '001'.
        await resetEmployees(ctx);
        await openScreen(page);
        assert.equal(await label(page, 'Employee Code').inputValue(), '001');
        assert.deepEqual(await listed(page), []);
        return {
          observation: `next code ${first.code}, cursor in the name, list by name, ${users.length} user choices, tab order ${order.join(' > ')}`,
          expected: {
            nextCode: '008',
            emptyCompany: '001',
            list: 'ANIL SHAH, BHAVIN, COUNTER',
            drawn: 'Print Save Cancel Delete Exit',
          },
        };
      },
    ),
    C(
      'field.every-field',
      'T02',
      'mutation',
      'BtnSave_Click (:1493-1516) stores CO_CODE, EMP_CODE, EMP_NAME, EMP_AC, EMP_AMT, DAY_HOURS, USER_NAME and MAIN_USER; DISPLAY_DATA (:1274-1299) shows them again',
      async (ctx) =>
        withAccounts(ctx, async () => {
          await resetEmployees(ctx, [{ code: '001', name: 'COUNTER' }]);
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Employee Name').fill('e2e ramesh');
          await label(page, 'Employee Name').press('Enter');
          await pickAccount(page, 'EMQSAL');
          assert.equal(await label(page, 'Account Name').inputValue(), 'EMQ STAFF SALARY');
          await label(page, 'User Name').selectOption(USERS.clerk.user);
          await label(page, 'User Name').press('Enter');
          await label(page, 'Amount').fill('12500.5');
          await label(page, 'Amount').press('Enter');
          await label(page, 'Day Hour').fill('8');
          await label(page, 'Day Hour').press('Enter');
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          const rows = without(await employees(ctx));
          const stored = rows.find((r) => r.code === '002');
          assert.deepEqual(stored, {
            code: '002',
            name: 'E2E RAMESH',
            ac: 'EMQSAL',
            amt: 12500.5,
            hours: 8,
            user: USERS.clerk.user,
            main: USERS.admin.user,
            type: null,
            tds: 0,
            tdsamt: 0,
            pf: 0,
            pfamt: 0,
          });
          const shown = (await openEmployee(page, '002'), await entry(page));
          assert.deepEqual(shown, {
            code: '002',
            name: 'E2E RAMESH',
            account: 'EMQSAL',
            accountName: 'EMQ STAFF SALARY',
            user: USERS.clerk.user,
            amount: '12500.50',
            dayHours: '8.00',
            codeReadOnly: true,
          });
          return {
            observation: `saved and reopened 002 with every box: ${JSON.stringify(shown)}`,
            expected: 'the typed values upper-cased, Val of the numbers, the operator as MAIN_USER',
            database: { rows },
            downstream: { reopened: shown },
          };
        }),
    ),
    C(
      'formula.val-and-next-code',
      'T03',
      'mutation',
      'tEmpAmt_KeyDown / nDayHour_KeyDown: Strings.Format(Val(box), "0.00") on Enter (:1681-1724); Save stores Conversion.Val of the box as it is (:1503-1504); CLEAR_DATA numbers from the highest code (:1260-1268)',
      async (ctx) => {
        await resetEmployees(ctx, [{ code: '001', name: 'COUNTER' }]);
        const { page } = await ctx.session();
        await openScreen(page);
        const shownAfterEnter = {};
        for (const [box, typed] of [
          ['Amount', '12.345'],
          ['Amount', ' 8 hrs'],
          ['Amount', 'ABC'],
          ['Amount', '1,250.75'],
          ['Day Hour', '7.5'],
        ]) {
          await label(page, box).fill(typed);
          await label(page, box).press('Enter');
          shownAfterEnter[`${box} ${typed}`] = await label(page, box).inputValue();
        }
        assert.deepEqual(shownAfterEnter, {
          'Amount 12.345': '12.35',
          'Amount  8 hrs': '8.00',
          'Amount ABC': '0.00',
          'Amount 1,250.75': '1.00',
          'Day Hour 7.5': '7.50',
        });
        // A code typed over the offered one, and an amount saved without Enter: Val of the raw text is stored.
        await label(page, 'Employee Code').fill('010');
        await label(page, 'Employee Name').fill('E2E TEN');
        await label(page, 'Amount').fill('7.125');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        await saved(page);
        const rows = without(await employees(ctx));
        assert.deepEqual(
          rows.map((r) => [r.code, r.name, r.amt, r.hours]),
          [
            ['001', 'COUNTER', 0, 0],
            ['010', 'E2E TEN', 7.125, 7.5],
          ],
        );
        const next = await label(page, 'Employee Code').inputValue();
        assert.equal(next, '011', 'the highest code + 1');
        await openEmployee(page, '010');
        assert.equal(
          await label(page, 'Amount').inputValue(),
          '7.13',
          'shown as 0.00 (DISPLAY_DATA)',
        );
        return {
          observation: `Enter showed ${JSON.stringify(shownAfterEnter)}; stored ${JSON.stringify(rows)}; next code ${next}`,
          expected: 'Val then 0.00 on Enter; Val of the raw box on Save; next code 011',
          database: { rows },
          downstream: { nextCode: next },
        };
      },
    ),
    C(
      'lookup.account-help',
      'T04',
      'read-only',
      "tEmpAc_KeyDown (:1631-1680): an AC_MAST code is taken whatever its group; otherwise the help lists AC_GR IN ('09','10','45') AND AC_CODE <> '00020' ORDER BY AC_GR, AC_NAME",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await resetEmployees(ctx, [{ code: '001', name: 'COUNTER' }]);
          const { page } = await ctx.session();
          await openScreen(page);
          const box = label(page, 'Account Code');
          await box.fill('EMQ');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          const help = page.locator('[data-lookup-open="true"] b');
          await help.first().waitFor();
          const offered = (await help.allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(
            offered,
            ['EMQCSH', 'EMQADV', 'EMQSAL'],
            'groups 09, 10, 45 by group; no 00020, no group 01',
          );
          await box.press('ArrowDown');
          await box.press('Enter');
          await page.waitForFunction(() => document.activeElement?.id === 'employee-user');
          const chosen = [await box.inputValue(), await label(page, 'Account Name').inputValue()];
          assert.deepEqual(chosen, ['EMQADV', 'EMQ STAFF ADVANCE']);
          // A typed code of another group is still taken (the exact AC_MAST read comes first).
          await pickAccount(page, 'EMQDEB');
          const typed = [await box.inputValue(), await label(page, 'Account Name').inputValue()];
          assert.deepEqual(typed, ['EMQDEB', 'EMQ STAFF DEBTOR']);
          // Changing the code clears the name until a code is taken again.
          await box.fill('EMQ');
          assert.equal(await label(page, 'Account Name').inputValue(), '');
          // A lower-case search opens the same help, and a lower-case code is taken as the master's code.
          await box.fill('');
          await page.keyboard.type('emq');
          await page.waitForFunction(
            () => document.querySelectorAll('[data-lookup-open="true"] b').length === 3,
          );
          const lower = (await help.allInnerTexts()).map((t) => t.trim());
          assert.deepEqual(lower, ['EMQCSH', 'EMQADV', 'EMQSAL']);
          await box.fill('emqsal');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await box.press('Enter');
          await page.waitForFunction(() => document.activeElement?.id === 'employee-user');
          assert.deepEqual(
            [await box.inputValue(), await label(page, 'Account Name').inputValue()],
            ['EMQSAL', 'EMQ STAFF SALARY'],
          );
          return {
            observation: `help for EMQ offered ${offered.join(', ')}; picked ${chosen.join(' ')}; typed ${typed.join(' ')}; lower-case help ${lower.join(', ')}`,
            expected: { help: ['EMQCSH', 'EMQADV', 'EMQSAL'], typedOtherGroup: 'EMQDEB' },
          };
        }),
    ),
    notApplicable(
      'children',
      'T05',
      'MS_EMP edits one EMP_MAST row; it has no child grid',
      'The Employee master has no child rows.',
    ),
    C(
      'required.refusals',
      'T06',
      'refusal',
      'tEmpName_KeyDown (:1381), BtnSave_Click (:1487-1491), tEmpCode_Validating (:1360), tEmpName_Validating (:1401); the web also refuses an unknown account and an unlisted user (G224)',
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER' },
          { code: '002', name: 'ANIL SHAH' },
        ]);
        const before = await employees(ctx);
        const { page, requests } = await ctx.session();
        await openScreen(page);
        await label(page, 'Employee Name').press('Enter');
        await message(page, 'Please Insert Employee Name ...');
        assert.equal(await focusedId(page), 'employee-name');
        await label(page, 'Employee Code').fill('');
        await button(page, 'Save').click();
        await message(page, 'Enter Employee Detail');
        await label(page, 'Employee Code').fill('002');
        await label(page, 'Employee Code').press('Tab');
        await message(
          page,
          "This Employee Code already Exist in  'ANIL SHAH'  Employee Name...Please Change Employee Code...",
        );
        // The cursor stays in the code (Validating cancels).
        await page.waitForFunction(() => document.activeElement?.id === 'employee-code');
        await label(page, 'Employee Code').fill('003');
        await label(page, 'Employee Name').fill("anil sh'ah");
        await label(page, 'Employee Name').press('Tab');
        await message(
          page,
          "This Employee Name already Exist in  '002'  Employee Code...Please Change Employee Name...",
        );
        await page.waitForFunction(() => document.activeElement?.id === 'employee-name');
        assert.equal(
          requests.filter((r) => ['POST', 'PUT'].includes(r.method)).length,
          0,
          'nothing was sent',
        );
        const direct = [];
        for (const [payload, text] of [
          [
            { code: '003', name: 'NEW HAND', account: 'ZZZZZ' },
            'account ZZZZZ is not in the account master',
          ],
          [
            { code: '003', name: 'NEW HAND', user: 'nobody' },
            'user nobody is not in the user list',
          ],
          [{ code: '003', name: '' }, 'Please Insert Employee Name ...'],
          [{ code: '003', name: 'N'.repeat(41) }, 'employee name must be at most 40 characters'],
        ]) {
          const response = await page.request.post(`/api${API}`, { data: payload });
          assert.equal(response.status(), 400, await response.text());
          assert.equal((await response.json()).message, text);
          direct.push(response.status());
        }
        const after = await employees(ctx);
        assert.deepEqual(after, before);
        return {
          observation: `four screen refusals with the desktop texts; direct posts answered ${direct.join(', ')}`,
          expected: 'the desktop texts, the cursor kept, 400 for the web refusals, no row written',
          database: { before, after },
        };
      },
    ),
    C(
      'create.footprint',
      'T07',
      'mutation',
      "BtnSave_Click (:1493-1520): one EMP_MAST row with the offered code, 'ABC' for a blank user and the operator as MAIN_USER; then a new entry with the next code and the list read again by name",
      async (ctx) => {
        await resetEmployees(ctx, [{ code: '001', name: 'ZED COUNTER' }]);
        const { page } = await ctx.session();
        await openScreen(page);
        assert.equal(await label(page, 'Employee Code').inputValue(), '002');
        await label(page, 'Employee Name').fill('e2e new hand');
        await label(page, 'Day Hour').fill('9');
        const response = await save(page);
        assert.equal(response.status(), 201, await response.text());
        assert.deepEqual(await response.json(), { code: '002' });
        await saved(page);
        const rows = without(await employees(ctx));
        assert.deepEqual(rows, [
          {
            code: '001',
            name: 'ZED COUNTER',
            ac: '',
            amt: 0,
            hours: 0,
            user: 'ABC',
            main: 'e2eseed',
            type: null,
            tds: 0,
            tdsamt: 0,
            pf: 0,
            pfamt: 0,
          },
          {
            code: '002',
            name: 'E2E NEW HAND',
            ac: '',
            amt: 0,
            hours: 9,
            user: 'ABC',
            main: USERS.admin.user,
            type: null,
            tds: 0,
            tdsamt: 0,
            pf: 0,
            pfamt: 0,
          },
        ]);
        const next = await label(page, 'Employee Code').inputValue();
        assert.equal(next, '003');
        assert.deepEqual(await listed(page), [
          ['002', 'E2E NEW HAND'],
          ['001', 'ZED COUNTER'],
        ]);
        // Downstream: the screens that pick an employee (Daily Rate, Sales) find the new one.
        const lookup = await (
          await page.request.get('/api/lookup/employees?q=E2E%20NEW&limit=20')
        ).json();
        assert.ok(
          lookup.some((r) => String(r.code) === '002'),
          `the employee lookup lists 002: ${JSON.stringify(lookup)}`,
        );
        return {
          observation: `created 002; next code ${next}; lookup returned ${lookup.length} row(s)`,
          expected: "one row: E2E NEW HAND, user 'ABC', day hours 9, MAIN_USER e2eadmin",
          database: { rows },
          downstream: { lookup },
        };
      },
    ),
    C(
      'reopen.unchanged-save',
      'T08',
      'mutation',
      "DISPLAY_DATA (:1274-1299) shows an imported employee (Format 0.00, cboUser drop-down list) and keeps its MAIN_USER; an unchanged Save stores Val of the shown boxes and 'ABC' again; the web keeps EMP_TYPE, TDS and PF (G224)",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await resetEmployees(ctx, [
            { code: '001', name: 'COUNTER' },
            {
              code: '004',
              name: 'IMPORTED HAND',
              ac: 'EMQSAL',
              amt: 1000.555,
              hours: 7.5,
              user: 'ABC',
              main: 'olduser',
              type: 'S',
              tds: 1.5,
              tdsAmt: 10,
              pf: 12,
              pfAmt: 120,
            },
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          await openEmployee(page, '004', 'enter');
          const shown = await entry(page);
          assert.deepEqual(shown, {
            code: '004',
            name: 'IMPORTED HAND',
            account: 'EMQSAL',
            accountName: 'EMQ STAFF SALARY',
            user: '',
            amount: '1000.56',
            dayHours: '7.50',
            codeReadOnly: true,
          });
          const response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await saved(page);
          const row = without(await employees(ctx)).find((r) => r.code === '004');
          assert.deepEqual(row, {
            code: '004',
            name: 'IMPORTED HAND',
            ac: 'EMQSAL',
            amt: 1000.56,
            hours: 7.5,
            user: 'ABC',
            main: 'olduser',
            type: 'S',
            tds: 1.5,
            tdsamt: 10,
            pf: 12,
            pfamt: 120,
          });
          return {
            observation: `shown ${JSON.stringify(shown)}; stored ${JSON.stringify(row)}`,
            expected:
              'amount 1000.56 (Val of the shown 0.00), user ABC, creator olduser, TDS/PF/type kept',
            database: { row },
            downstream: { shown },
          };
        }),
    ),
    C(
      'edit.one-field',
      'T09',
      'mutation',
      'An opened employee (EntryMode E) is replaced under its code; the other employees are not touched (BtnSave_Click deletes only its EMP_CODE, :1493-1497)',
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER', amt: 50 },
          { code: '002', name: 'ANIL SHAH', amt: 100, hours: 8, user: USERS.clerk.user },
        ]);
        const before = await employees(ctx);
        const { page } = await ctx.session();
        await openScreen(page);
        await openEmployee(page, '002');
        await label(page, 'Amount').fill('150');
        await label(page, 'Amount').press('Enter');
        const response = await save(page);
        assert.equal(response.status(), 200, await response.text());
        await saved(page);
        const after = await employees(ctx);
        assert.deepEqual(
          after.find((r) => r.code === '001'),
          before.find((r) => r.code === '001'),
          'the other employee keeps its row',
        );
        assert.deepEqual(without(after.filter((r) => r.code === '002')), [
          {
            code: '002',
            name: 'ANIL SHAH',
            ac: '',
            amt: 150,
            hours: 8,
            user: USERS.clerk.user,
            main: 'e2eseed',
            type: null,
            tds: 0,
            tdsamt: 0,
            pf: 0,
            pfamt: 0,
          },
        ]);
        return {
          observation: `002 amount ${before.find((r) => r.code === '002').amt} → 150; 001 unchanged`,
          expected: 'only the amount changes',
          database: { before, after },
          downstream: { list: await listed(page) },
        };
      },
    ),
    C(
      'delete.lifecycle',
      'T10',
      'mutation',
      'BtnDelete_Click (:1552-1584): blank code, the question, the default employee 001, "Delete Success." and the list read again ORDER BY EMP_CODE; MS_EMP deletes without looking at the rates that name the employee',
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'ZED COUNTER' },
          { code: '002', name: 'ALPHA HAND' },
          { code: '003', name: 'TEMP HAND' },
        ]);
        const rateDay = `${fullYear()}-09-20`;
        await exec(
          ctx,
          `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE","GR_RATE","EMP_CODE","MAIN_USER")
           VALUES ($1,'01','01',$2,$3::date,1,'R22',1,'003','e2eseed')`,
          `${fullYear()}-${fullYear() + 1}`,
          rateDay,
        );
        try {
          const { page } = await ctx.session();
          await openScreen(page);
          // A blank code: no question, the desktop text.
          await label(page, 'Employee Code').fill('');
          await button(page, 'Delete').click();
          await message(page, 'Please Select Employee For Delete.');
          await openEmployee(page, '003');
          // The question dismissed: nothing is deleted.
          page.removeAllListeners('dialog');
          let asked = '';
          page.once('dialog', (dialog) => {
            asked = dialog.message();
            void dialog.dismiss();
          });
          await button(page, 'Delete').click();
          await page.waitForTimeout(300);
          assert.equal(asked, 'Are You Sure To Delete This Record now?');
          assert.equal((await employees(ctx)).length, 3);
          page.on('dialog', (dialog) => void dialog.accept());
          const [gone] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/003`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(gone.status(), 200, await gone.text());
          await message(page, 'Delete Success.');
          await page.waitForFunction(
            () => document.querySelectorAll('[data-testid="employee-list"] tr').length === 2,
          );
          assert.deepEqual(
            await listed(page),
            [
              ['001', 'ZED COUNTER'],
              ['002', 'ALPHA HAND'],
            ],
            'read again by code',
          );
          await openEmployee(page, '001');
          await button(page, 'Delete').click();
          await message(page, 'You Cant Delete Record, This Empoyee Is Default Empoyee....');
          const rows = without(await employees(ctx));
          assert.deepEqual(
            rows.map((r) => r.code),
            ['001', '002'],
          );
          const rate = await ctx.rows(
            `SELECT "EMP_CODE" emp FROM "RATE_MAST" WHERE tenant_id=$1 AND "VCH_DATE"=$2::date`,
            rateDay,
          );
          assert.deepEqual(rate, [{ emp: '003' }]);
          return {
            observation: `asked "${asked}"; 003 deleted, 001 refused; the ${rateDay} rate still names 003`,
            expected: 'the desktop texts; 001 and 002 remain; rates keep the code',
            database: { rows },
            downstream: { rate },
          };
        } finally {
          await exec(
            ctx,
            `DELETE FROM "RATE_MAST" WHERE tenant_id=$1 AND "VCH_DATE"=$2::date`,
            rateDay,
          );
        }
      },
    ),
    C(
      'rights.view-only',
      'T11',
      'refusal',
      'MS_EMP_Load reads FRM_EDIT/FRM_DELETE/FRM_PRINT of SUB_MENU \'Employee\' (:1000-1007); Save of an opened employee, Delete and Print answer "You Have No Rights....." / "You Have No Print Rights....."; a new entry needs only the view right (:1478-1484)',
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER' },
          { code: '002', name: 'ANIL SHAH' },
        ]);
        await ctx.owner.$executeRawUnsafe(
          `DELETE FROM "EMP_MAST" WHERE tenant_id=$1`,
          SECOND_TENANT,
        );
        await ctx.owner.$executeRawUnsafe(
          `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME","USER_NAME") VALUES ($1,'01','002','SENTINEL HAND','ABC')`,
          SECOND_TENANT,
        );
        await exec(
          ctx,
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES ($1,'01','01',$2,'Master','Employee','Y','N','N','N')`,
          USERS.clerk.user,
        );
        try {
          const { page, requests } = await ctx.session(as(USERS.clerk.user));
          await openScreen(page);
          assert.deepEqual(
            await listed(page),
            [
              ['002', 'ANIL SHAH'],
              ['001', 'COUNTER'],
            ],
            'only this tenant',
          );
          const opened = await openEmployee(page, '002');
          await label(page, 'Employee Name').fill('ANIL CHANGED');
          await button(page, 'Save').click();
          await message(page, 'You Have No Rights.....');
          await button(page, 'Delete').click();
          await message(page, 'You Have No Rights.....');
          await button(page, 'Print').click();
          await message(page, 'You Have No Print Rights.....');
          assert.equal(requests.filter((r) => ['PUT', 'DELETE'].includes(r.method)).length, 0);
          assert.equal(requests.filter((r) => r.path === `/api${API}/print`).length, 0);
          const direct = [
            (
              await page.request.put(`/api${API}/002`, {
                data: { name: 'ANIL CHANGED', expectedVersion: opened.version },
              })
            ).status(),
            (
              await page.request.delete(`/api${API}/002?expectedVersion=${opened.version}`)
            ).status(),
            (await page.request.get(`/api${API}/print`)).status(),
          ];
          assert.deepEqual(direct, [403, 403, 403]);
          // A new entry needs only the view right.
          await button(page, 'Cancel').click();
          await page.waitForFunction(
            () => document.querySelector('#employee-code')?.value === '003',
          );
          await label(page, 'Employee Name').fill('CLERK HAND');
          const created = await save(page);
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          const rows = without(await employees(ctx));
          assert.deepEqual(
            rows.map((r) => [r.code, r.name, r.main]),
            [
              ['001', 'COUNTER', 'e2eseed'],
              ['002', 'ANIL SHAH', 'e2eseed'],
              ['003', 'CLERK HAND', USERS.clerk.user],
            ],
          );
          const sentinel = await ctx.owner.$queryRawUnsafe(
            `SELECT "EMP_CODE" code,"EMP_NAME" name FROM "EMP_MAST" WHERE tenant_id=$1`,
            SECOND_TENANT,
          );
          assert.deepEqual(sentinel, [{ code: '002', name: 'SENTINEL HAND' }]);
          // Without the rights row the screen is refused.
          const printer = await ctx.session(as(USERS.printViewer.user));
          const refused = await openScreen(printer.page);
          assert.equal(refused.status(), 403);
          await message(printer.page, 'You Have No Rights.....');
          return {
            observation: `clerk refused on screen; direct PUT/DELETE/print ${direct.join('/')}; clerk created 003; e2eprint refused ${refused.status()}`,
            expected: 'the desktop texts, 403s, a new entry allowed, the sentinel tenant untouched',
            database: { rows, sentinel },
          };
        } finally {
          await exec(
            ctx,
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 AND "SUB_MENU"='Employee'`,
            USERS.clerk.user,
          );
          await ctx.owner.$executeRawUnsafe(
            `DELETE FROM "EMP_MAST" WHERE tenant_id=$1`,
            SECOND_TENANT,
          );
        }
      },
    ),
    C(
      'concurrency.two-operators',
      'T12',
      'mutation',
      'Two operators open one employee: the first save wins and the second is refused with 409 (version token, G224) instead of silently replacing it (the desktop lets the later save win); two new entries with the same offered code: the second is refused with the code text under the company lock',
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER' },
          { code: '002', name: 'ANIL SHAH', amt: 100 },
        ]);
        const a = (await ctx.session()).page;
        const b = (await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`))).page;
        await openScreen(a);
        await openScreen(b);
        await openEmployee(a, '002');
        await openEmployee(b, '002');
        await label(a, 'Employee Name').fill('ANIL A');
        const first = await save(a);
        assert.equal(first.status(), 200, await first.text());
        await saved(a);
        await label(b, 'Amount').fill('999');
        const second = await save(b);
        assert.equal(second.status(), 409);
        await message(b, CONFLICT);
        let rows = without(await employees(ctx));
        assert.deepEqual(
          rows.filter((r) => r.code === '002').map((r) => [r.name, r.amt]),
          [['ANIL A', 100]],
        );
        // Both new entries were offered 003.
        await button(a, 'Cancel').click();
        await openScreen(b);
        assert.equal(await label(a, 'Employee Code').inputValue(), '003');
        assert.equal(await label(b, 'Employee Code').inputValue(), '003');
        await label(a, 'Employee Name').fill('NEW A');
        assert.equal((await save(a)).status(), 201);
        await saved(a);
        await label(b, 'Employee Name').fill('NEW B');
        const late = await save(b);
        assert.equal(late.status(), 400);
        await message(
          b,
          "This Employee Code already Exist in  'NEW A'  Employee Name...Please Change Employee Code...",
        );
        rows = without(await employees(ctx));
        assert.deepEqual(
          rows.map((r) => [r.code, r.name]),
          [
            ['001', 'COUNTER'],
            ['002', 'ANIL A'],
            ['003', 'NEW A'],
          ],
        );
        return {
          observation: `edit race: ${first.status()} then ${second.status()}; new-entry race: 201 then ${late.status()}`,
          expected: 'one result per race and a defined refusal',
          database: { rows },
          downstream: { secondStatus: second.status(), lateStatus: late.status() },
        };
      },
    ),
    C(
      'retry.replayed-save',
      'T13',
      'mutation',
      "A replayed edit carries a spent version and is refused (409); a replayed new entry has the same code and name, so it replaces the row with the same values (BtnSave_Click's DELETE + INSERT) and no second employee appears",
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER' },
          { code: '002', name: 'ANIL SHAH' },
        ]);
        const { page } = await ctx.session();
        await openScreen(page);
        await openEmployee(page, '002');
        await label(page, 'Amount').fill('250');
        const first = await save(page);
        assert.equal(first.status(), 200, await first.text());
        await saved(page);
        const replayEdit = (await page.request.fetch(first.request())).status();
        assert.equal(replayEdit, 409);
        await label(page, 'Employee Name').fill('E2E RETRY');
        const created = await save(page);
        assert.equal(created.status(), 201, await created.text());
        await saved(page);
        const replayCreate = (await page.request.fetch(created.request())).status();
        assert.equal(replayCreate, 201);
        const rows = without(await employees(ctx));
        assert.deepEqual(
          rows.map((r) => [r.code, r.name, r.amt]),
          [
            ['001', 'COUNTER', 0],
            ['002', 'ANIL SHAH', 250],
            ['003', 'E2E RETRY', 0],
          ],
        );
        return {
          observation: `replayed edit ${replayEdit}; replayed create ${replayCreate}; ${rows.length} employees`,
          expected: 'one row per employee; the edit replay refused',
          database: { rows },
          downstream: { replayEdit, replayCreate },
        };
      },
    ),
    C(
      'rollback.insert-fault',
      'T14',
      'mutation',
      "BtnSave_Click deletes the employee's row, then inserts the new one (:1493-1516); a fault on the insert must roll the delete back, leaving the employee and the other rows as they were",
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '001', name: 'COUNTER' },
          { code: '002', name: 'ANIL SHAH', amt: 100, tds: 2 },
        ]);
        const before = await employees(ctx);
        await ctx.owner.$executeRawUnsafe(
          `CREATE OR REPLACE FUNCTION e2e_employee_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
           BEGIN
             IF NEW."EMP_NAME" = 'E2E FAULT' THEN RAISE EXCEPTION 'e2e fault after the delete'; END IF;
             RETURN NEW;
           END $f$`,
        );
        await ctx.owner.$executeRawUnsafe(
          `CREATE TRIGGER e2e_employee_fault BEFORE INSERT ON "EMP_MAST" FOR EACH ROW EXECUTE FUNCTION e2e_employee_fault()`,
        );
        try {
          const { page } = await ctx.session();
          await openScreen(page);
          await openEmployee(page, '002');
          await label(page, 'Employee Name').fill('E2E FAULT');
          const failed = await save(page);
          assert.equal(failed.status(), 400, await failed.text());
          const afterEdit = await employees(ctx);
          assert.deepEqual(afterEdit, before, 'the delete was rolled back with the failed insert');
          await button(page, 'Cancel').click();
          await page.waitForFunction(
            () => document.querySelector('#employee-code')?.value === '003',
          );
          await label(page, 'Employee Name').fill('E2E FAULT');
          const failedNew = await save(page);
          assert.equal(failedNew.status(), 400, await failedNew.text());
          const after = await employees(ctx);
          assert.deepEqual(after, before);
          return {
            observation: `edit answered ${failed.status()}, new entry ${failedNew.status()}; rows unchanged, row ids included`,
            expected: 'no row lost, none added',
            database: { before, after },
            downstream: { editStatus: failed.status(), newStatus: failedNew.status() },
          };
        } finally {
          await ctx.owner.$executeRawUnsafe(
            `DROP TRIGGER IF EXISTS e2e_employee_fault ON "EMP_MAST"`,
          );
          await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_employee_fault()`);
        }
      },
    ),
    C(
      'history.company-wide',
      'T15',
      'mutation',
      'EMP_MAST has no year: MS_EMP reads and writes by CO_CODE only (:1144, :1493), so an employee saved in this year is the same row in the historic year; an account renamed while the employee is open is shown under its new name, as only EMP_AC is stored',
      async (ctx) =>
        withAccounts(ctx, async () => {
          await resetEmployees(ctx, [{ code: '001', name: 'COUNTER' }]);
          // Its own login: opening another year moves the server session, which the other cases' saved login shares.
          const { page } = await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#history`));
          await openScreen(page);
          await label(page, 'Employee Name').fill('E2E YEAR HAND');
          await label(page, 'Employee Name').press('Enter');
          await pickAccount(page, 'EMQSAL');
          await exec(
            ctx,
            `UPDATE "AC_MAST" SET "AC_NAME"='EMQ SALARY RENAMED' WHERE tenant_id=$1 AND "AC_CODE"='EMQSAL'`,
          );
          const response = await save(page);
          assert.equal(response.status(), 201, await response.text());
          await saved(page);
          // Open the company in the historic year.
          await page.goto('/select');
          await page.getByRole('heading', { name: 'Open Company', exact: true }).waitFor();
          const year = page.getByRole('combobox', { name: 'FINANCIAL YEAR' });
          await year.selectOption('2024-2025');
          await button(page, 'Open').click();
          await page.waitForURL('**/dashboard');
          const me = await (await page.request.get('/api/me')).json();
          assert.equal(me.coYear, '2024-2025');
          await openScreen(page);
          const list = await listed(page);
          assert.deepEqual(list, [
            ['001', 'COUNTER'],
            ['002', 'E2E YEAR HAND'],
          ]);
          assert.equal(await label(page, 'Employee Code').inputValue(), '003');
          await openEmployee(page, '002');
          const shown = await entry(page);
          assert.equal(shown.accountName, 'EMQ SALARY RENAMED');
          const rows = without(await employees(ctx));
          return {
            observation: `historic year lists ${JSON.stringify(list)} and offers 003; the account shows as "${shown.accountName}"`,
            expected: 'the same employees in every year; the account read by code',
            database: { rows },
            downstream: { historicYearList: list, shown },
          };
        }),
    ),
    C(
      'output.print',
      'T16',
      'output',
      "BtnPrint_Click (:1585-1599) prints the company's employees (EmpMast, {EMP_MAST.CO_CODE}); the report layout is not in the repository, so the web lists code, name, user, account, amount and day hours on screen (G224)",
      async (ctx) => {
        await resetEmployees(ctx, [
          { code: '002', name: 'ANIL SHAH', ac: '', amt: 15000, hours: 9, user: USERS.clerk.user },
          { code: '001', name: 'COUNTER', amt: 1000.555, hours: 7.5 },
        ]);
        const { page } = await ctx.session();
        await openScreen(page);
        const [response] = await Promise.all([
          page.waitForResponse((r) => isApi(r, 'GET', `${API}/print`)),
          button(page, 'Print').click(),
        ]);
        assert.equal(response.status(), 200);
        const sheet = page.getByTestId('employee-print');
        await sheet.waitFor();
        const headers = (await sheet.locator('thead th').allInnerTexts()).map((t) => t.trim());
        const body = await sheet
          .locator('tbody tr')
          .evaluateAll((rows) =>
            rows.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
          );
        assert.deepEqual(headers, [
          'Code',
          'Name',
          'User Name',
          'Account Code',
          'Amount',
          'Day Hour',
        ]);
        assert.deepEqual(body, [
          ['001', 'COUNTER', 'ABC', '', '1000.56', '7.50'],
          ['002', 'ANIL SHAH', USERS.clerk.user, '', '15000.00', '9.00'],
        ]);
        return {
          observation: `printed ${body.length} employees in code order`,
          expected: { headers, rows: body },
          output: { headers, rows: body },
        };
      },
    ),
    C(
      'keyboard.desktop-keys',
      'T17',
      'mutation',
      "MS_EMP_KeyPress (:1319-1332), the boxes' Enter keys (:1334-1389, :1631-1724), MS_EMP_KeyDown Esc and Up/Down (:1436-1446), DGV_KeyDown F1/Enter/Backspace (:1600-1622) and the &Save mnemonic",
      async (ctx) =>
        withAccounts(ctx, async () => {
          await resetEmployees(ctx, [
            { code: '001', name: 'COUNTER' },
            { code: '002', name: 'ANIL SHAH' },
            { code: '003', name: 'ANKIT JAIN' },
          ]);
          const { page } = await ctx.session();
          await openScreen(page);
          await page.keyboard.type("o'neil desai");
          assert.equal(
            await label(page, 'Employee Name').inputValue(),
            'ONEIL DESAI',
            'upper-cased, apostrophe refused',
          );
          await page.keyboard.press('Enter');
          assert.equal(
            await page.evaluate(() => document.activeElement?.getAttribute('aria-label')),
            'Account Code',
          );
          await page.keyboard.type('EMQADV');
          await page.waitForResponse((r) => path(r) === `/api${API}/accounts`);
          await page.keyboard.press('Enter');
          await page.waitForFunction(() => document.activeElement?.id === 'employee-user');
          await label(page, 'User Name').selectOption(USERS.clerk.user);
          await page.keyboard.press('Enter');
          assert.equal(await focusedId(page), 'employee-amount');
          await page.keyboard.type('500');
          await page.keyboard.press('Enter');
          assert.equal(await label(page, 'Amount').inputValue(), '500.00');
          assert.equal(await focusedId(page), 'employee-day-hours');
          await page.keyboard.type('8');
          await page.keyboard.press('Enter');
          assert.equal(await label(page, 'Day Hour').inputValue(), '8.00');
          assert.equal(
            await page.evaluate(() => document.activeElement?.textContent?.trim()),
            'Save',
          );
          const created = await save(page, () => page.keyboard.press('Enter'));
          assert.equal(created.status(), 201, await created.text());
          await saved(page);
          // Down from a box goes to the list; Down moves; Enter opens the row.
          await page.keyboard.press('ArrowDown');
          assert.equal(
            await page.evaluate(() => document.activeElement?.getAttribute('data-code')),
            '002',
          );
          await page.keyboard.press('ArrowDown');
          const [opened] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'GET', `${API}/003`)),
            page.keyboard.press('Enter'),
          ]);
          assert.equal(opened.status(), 200);
          await page.waitForFunction(() => document.activeElement?.id === 'employee-name');
          assert.equal(await label(page, 'Employee Code').inputValue(), '003');
          // Alt+S saves the opened employee.
          await label(page, 'Day Hour').fill('6');
          const altSaved = await save(page, () => page.keyboard.press('Alt+s'));
          assert.equal(altSaved.status(), 200, await altSaved.text());
          await saved(page);
          // F1 in the list goes to the search box; typing filters by name; Backspace in the list shortens it.
          await page.keyboard.press('ArrowDown');
          await page.keyboard.press('F1');
          assert.equal(
            await page.evaluate(() => document.activeElement?.getAttribute('aria-label')),
            'Search record',
          );
          assert.equal(await label(page, 'Search record').inputValue(), '');
          await page.keyboard.type('ank');
          assert.deepEqual(await listed(page), [['003', 'ANKIT JAIN']]);
          await page.keyboard.press('ArrowDown');
          await page.keyboard.press('Backspace');
          assert.equal(await label(page, 'Search record').inputValue(), 'AN');
          assert.deepEqual(await listed(page), [
            ['002', 'ANIL SHAH'],
            ['003', 'ANKIT JAIN'],
          ]);
          // F1 from the code box goes to the search box too; Esc leaves the screen.
          await label(page, 'Employee Code').focus();
          await page.keyboard.press('F1');
          assert.equal(
            await page.evaluate(() => document.activeElement?.getAttribute('aria-label')),
            'Search record',
          );
          await label(page, 'Employee Name').focus();
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/masters/employees'));
          const rows = without(await employees(ctx));
          assert.deepEqual(
            rows.map((r) => [r.code, r.name, r.ac, r.user, r.amt, r.hours]),
            [
              ['001', 'COUNTER', '', 'ABC', 0, 0],
              ['002', 'ANIL SHAH', '', 'ABC', 0, 0],
              ['003', 'ANKIT JAIN', '', 'ABC', 0, 6],
              ['004', 'ONEIL DESAI', 'EMQADV', USERS.clerk.user, 500, 8],
            ],
          );
          return {
            observation: `keyboard entry saved 004, list keys opened 003, Alt+S saved it, search and Esc worked; left for ${new URL(page.url()).pathname}`,
            expected: 'every desktop key as listed in the source',
            database: { rows },
            downstream: { leftTo: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'keyboard.esc-with-focus-on-the-page',
      'T17',
      'read-only',
      "MS_EMP sets KeyPreview (:968) and subscribes MS_EMP_KeyDown (:648), so the form sees Esc wherever the focus is; Esc closes the form (:1444-1446). A browser has a state the desktop form never has: focus on no control, after a click on the page background. Esc must close Employee Master there too, and a key aimed at the header Company box stays the header's (GB-02, the G239 pattern)",
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const left = await escLeavesWithNoFocus(page, {
          heading: 'Employee Master',
          path: '/masters/employees',
        });
        return {
          observation: `Esc with the focus on the page body left Employee Master for ${left.leftTo}`,
          expected: { focusOnBody: true, leaves: '/masters/employees' },
          downstream: left,
        };
      },
    ),
    C(
      'journey.employee-on-daily-rate',
      'T18',
      'mutation',
      "An employee created here is picked in Daily Rate's employee box (MS_RATE stores EMP_CODE, MS_RATE.cs:1867-1947); deleting the employee leaves the saved rates naming its code, as MS_EMP does not check them",
      async (ctx) => {
        await resetEmployees(ctx, [{ code: '001', name: 'COUNTER' }]);
        for (const [code, name, type, touch, tax, prTouch] of RATE_GROUPS)
          await exec(
            ctx,
            `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE","GR_TOUCH","TAX_PRC","GR_PURC_TOUCH")
             SELECT $1::text,'01',$2::text,$3::text,$4::text,$5::float8,$6::numeric,$7::float8
              WHERE NOT EXISTS (SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "GR_CODE"=$2::text)`,
            code,
            name,
            type,
            touch,
            tax,
            prTouch,
          );
        const day = `${fullYear()}-09-21`;
        await exec(ctx, `DELETE FROM "RATE_MAST" WHERE tenant_id=$1 AND "VCH_DATE"=$2::date`, day);
        try {
          const { page } = await ctx.session();
          await openScreen(page);
          await label(page, 'Employee Name').fill('E2E RATE CLERK');
          assert.equal((await save(page)).status(), 201);
          await saved(page);
          // Daily Rate: the day, the employee by code, the rates.
          await page.goto('/txn/daily-rate');
          await page.getByRole('heading', { name: 'Rate Master', exact: true }).waitFor();
          await label(page, 'Touch R22').waitFor();
          await Promise.all([
            page.waitForResponse((r) => r.url().includes(`/api/daily-rate?date=${day}`)),
            label(page, 'Vch Date').fill(day),
          ]);
          await label(page, 'Employee').fill('002');
          await label(page, 'Employee').press('Enter');
          await page.getByText('E2E RATE CLERK', { exact: true }).waitFor();
          await label(page, 'Gold Rate 10gm').fill('72000');
          await label(page, 'Silver Rate 1Kg').fill('85000');
          await label(page, 'Silver Rate 1Kg').press('Enter');
          const [rated] = await Promise.all([
            page.waitForResponse(
              (r) => r.request().method() === 'POST' && path(r) === '/api/daily-rate',
            ),
            page.locator('button[data-save-mnemonic]').click(),
          ]);
          assert.equal(rated.status(), 201, await rated.text());
          const rates = () =>
            ctx.rows(
              `SELECT "GR_CODE" gr, "EMP_CODE" emp FROM "RATE_MAST" WHERE tenant_id=$1 AND "VCH_DATE"=$2::date ORDER BY "SR_NO"`,
              day,
            );
          const before = await rates();
          assert.ok(
            before.length > 0 && before.every((r) => r.emp === '002'),
            JSON.stringify(before),
          );
          // Back in the Employee master: delete the employee.
          await openScreen(page);
          await openEmployee(page, '002');
          const [gone] = await Promise.all([
            page.waitForResponse((r) => isApi(r, 'DELETE', `${API}/002`)),
            button(page, 'Delete').click(),
          ]);
          assert.equal(gone.status(), 200);
          await message(page, 'Delete Success.');
          const after = await rates();
          assert.deepEqual(after, before, 'the rates still name 002');
          const rows = without(await employees(ctx));
          assert.deepEqual(
            rows.map((r) => r.code),
            ['001'],
          );
          return {
            observation: `rate day ${day} saved with employee 002 on ${before.length} group(s); the employee deleted; rates unchanged`,
            expected: 'EMP_CODE 002 on every rate row before and after the delete',
            database: { rows },
            downstream: { rates: after },
          };
        } finally {
          await exec(
            ctx,
            `DELETE FROM "RATE_MAST" WHERE tenant_id=$1 AND "VCH_DATE"=$2::date`,
            day,
          );
        }
      },
    ),
  ],
};
