import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { tenantFingerprint, changedTables } from '../faults.mjs';

/**
 * Feature: Company → User Create (desktop MS_USER, 5,312 lines; web /admin/users).
 *
 * Every expected value is the desktop's (MS_USER.cs): the texts "User Are Created." (:1942), "Please Enter User Name."
 * (:1965), "This User Name already Exist.Please Change User Name..." (:2141), "Password Not Match" (:2211), "Please Insert
 * Old Password" (:2235), "Old Password Doesn't Match" (:2241), "Please Select User For Delete.", "Are You Sure To Delete
 * This User now?", "Delete Success." (:2080-2088); the LOGIN_MAST row with the first letter of the user type and
 * MAIN_USER (:1981-1997); USER_SET for location '00' and the operator's location, all four rights 'Y' (:2012-2040); the
 * KeyPress, Enter and Esc keys (:1786-1810, :2153-2263); the Lite edition hiding the rights grid (:1489-1495).
 * Web decisions (document 12 §4): D34 password rule, D35 delete = deactivate with every session revoked, D36 Lite rights.
 * The company keeps an administrator (G178/N169).
 *
 * Users made by a case carry the case's own name (prefix Q) and are removed by that case, so a rerun starts clean.
 */
const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
const login = (user, password, slot = user) => ({ user, password, slot });

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `users.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : ['browser', 'expected'],
  run,
  ...extra,
});

const T = Object.freeze({
  CREATED: 'User Are Created.',
  NAME_REQUIRED: 'Please Enter User Name.',
  NAME_EXISTS: 'This User Name already Exist.Please Change User Name...',
  PASSWORD_MISMATCH: 'Password Not Match',
  OLD_PASSWORD_REQUIRED: 'Please Insert Old Password',
  OLD_PASSWORD_WRONG: "Old Password Doesn't Match",
  SELECT_FOR_DELETE: 'Please Select User For Delete.',
  DELETE_CONFIRM: 'Are You Sure To Delete This User now?',
  DELETED: 'Delete Success.',
  NO_RIGHTS: 'You Have No Rights.....',
});

const isApi = (r, method, path) =>
  r.request().method() === method && new URL(r.url()).pathname === `/api${path}`;

async function openUsers(page) {
  const [response] = await Promise.all([
    page.waitForResponse((r) => isApi(r, 'GET', '/admin/users')),
    page.goto('/admin/users'),
  ]);
  await page.getByRole('heading', { name: 'User Create', exact: true }).waitFor();
  if (response.status() === 200)
    await page.waitForFunction(() => document.activeElement?.id === 'user-name');
  return response;
}
const box = (page, label) => page.getByLabel(label, { exact: true });
const shown = (page, text) => page.locator('main .msg', { hasText: text }).first().waitFor();
const msgText = async (page) =>
  (await page.locator('main .msg').first().innerText()).replace(/\s+/g, ' ').trim();
const focused = (page) => page.evaluate(() => document.activeElement?.id ?? '');

/** Type the name and leave the box (Tab), as an operator does. */
async function typeName(page, name) {
  await box(page, 'Create New User').fill(name);
  await box(page, 'Create New User').press('Tab');
}
async function fillPasswords(page, password, confirm = password) {
  await box(page, 'New Password').fill(password);
  await box(page, 'Confirm Password').fill(confirm);
  await box(page, 'Confirm Password').press('Tab');
}
async function save(page) {
  const response = page.waitForResponse(
    (r) =>
      r.request().method() === 'POST' && new URL(r.url()).pathname.startsWith('/api/admin/users'),
  );
  await page.getByRole('button', { name: 'Save', exact: true }).click();
  return response;
}
/** The whole add-mode flow through the screen. */
async function createThroughScreen(page, name, password, type = 'User') {
  await typeName(page, name);
  await fillPasswords(page, password);
  await box(page, 'User Type').selectOption(type);
  const response = await save(page);
  assert.equal(response.status(), 201, await response.text());
  await shown(page, T.CREATED);
}
/** Edit mode: pick the user in User Name (DISPLAY_DATA sets EntryMode 'E'), then type the name. */
async function pickAndType(page, name) {
  await box(page, 'User Name').selectOption(name);
  await typeName(page, name);
}

const loginRow = async (ctx, name) =>
  (
    await ctx.rows(
      `SELECT "row_id"::text "rowId","CO_CODE" co,"LOGIN_NAME" name,"LOGIN_PWD" pwd,"LOGIN_CATG" catg,
              "MAIN_USER" "mainUser","USER_UPDATE"||"USER_DELETE"||"USER_PRINT" flags,
              "PASSWORD_RESET_REQUIRED" reset,"LOGIN_ACTIVE" active,"DEACTIVATED_BY" "deactivatedBy",
              "PASSWORD_CHANGED_AT"::text "changedAt"
         FROM "LOGIN_MAST" WHERE tenant_id=$1 AND upper("LOGIN_NAME")=upper($2)`,
      name,
    )
  )[0];
const userSet = (ctx, name) =>
  ctx.rows(
    `SELECT "LC_CODE" lc, count(*)::int n,
            bool_and("FRM_VIEW"='Y' AND "FRM_EDIT"='Y' AND "FRM_DELETE"='Y' AND "FRM_PRINT"='Y') "allY"
       FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"=$2 GROUP BY "LC_CODE" ORDER BY "LC_CODE"`,
    name,
  );
const openSessions = async (ctx, name) =>
  (
    await ctx.rows(
      `SELECT count(*) FILTER (WHERE revoked_at IS NULL)::int open, count(*)::int n
         FROM auth_session WHERE tenant_id=$1 AND login_name=$2`,
      name,
    )
  )[0];
async function cleanup(ctx, ...names) {
  for (const [table, column] of [
    ['USER_SET', '"USER_NAME"'],
    ['auth_session', 'login_name'],
    ['LOGIN_MAST', '"LOGIN_NAME"'],
  ])
    await ctx.owner.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND ${column} = ANY($2::text[])`,
      ctx.tenantId,
      names,
    );
}
async function withUsers(ctx, names, run) {
  await cleanup(ctx, ...names);
  try {
    return await run();
  } finally {
    await cleanup(ctx, ...names);
  }
}
/** Answer the next confirm() with `answer`, collecting its text (the harness default accepts every dialog). */
function answerDialogs(page, answer) {
  const questions = [];
  page.removeAllListeners('dialog');
  page.on('dialog', (dialog) => {
    questions.push(dialog.message());
    void (answer() ? dialog.accept() : dialog.dismiss());
  });
  return questions;
}
const catalogueSize = async () =>
  (await import('../../../../api/dist/modules/rbac/formCatalog.js')).FORM_CATALOG.length;

export const usersRights = {
  feature: 'users',
  title: 'Company → User Create (MS_USER)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/admin/users/page.tsx',
    'web/apps/web/components/UserRightsGrid.tsx',
    'web/apps/web/lib/userCreate.ts',
    'web/apps/api/src/modules/rbac/users.ts',
    'web/apps/api/src/modules/rbac/userMaster.ts',
    'web/apps/api/src/routes/userMaster.ts',
    'web/apps/api/src/modules/auth/password.ts',
    'web/apps/web/test/features/modules/usersRights.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: { companySettings: 'catalogue defaults; no setting is changed' },
  cases: [
    C(
      'entry.desktop-form',
      'T01',
      'read-only',
      'MDI_FORM.cs:7451-7458 opens MS_USER from Company → User Create; the form (:1056-1298) has Create New User, Old Password, New Password, Confirm Password, User Type (User first, :1497-1500) in tab order 0-4, the User Name box of users, and Save, Print, Cancel, Delete, Exit; the cursor starts in the name (:1503)',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/dashboard');
        const company = page.locator('nav.sidebar > div', {
          has: page.locator('.group', { hasText: /^Company$/ }),
        });
        await Promise.all([
          page.waitForResponse((r) => isApi(r, 'GET', '/admin/users')),
          company.getByRole('link', { name: 'User Create', exact: true }).click(),
        ]);
        await page.getByRole('heading', { name: 'User Create', exact: true }).waitFor();
        await page.waitForFunction(() => document.activeElement?.id === 'user-name');
        const order = await page.evaluate(() =>
          Array.from(document.querySelectorAll('main label[for^="user-"]')).map((l) =>
            l.textContent?.trim(),
          ),
        );
        assert.deepEqual(order.slice(0, 6), [
          'Create New User',
          'Old Password',
          'New Password',
          'Confirm Password',
          'User Type',
          'User Name',
        ]);
        assert.equal(await box(page, 'User Type').inputValue(), 'User');
        const buttons = (await page.locator('main .toolbar button').allInnerTexts()).map((t) =>
          t.trim(),
        );
        assert.deepEqual(buttons, ['Save', 'Print', 'Cancel', 'Delete', 'Exit']);
        const primaries = (await page.locator('main button.primary').allInnerTexts()).map((t) =>
          t.trim(),
        );
        assert.deepEqual(primaries, ['Save']);
        await ctx.shot(page, 'user-create');
        return {
          observation: `opened from Company → User Create; boxes ${order.slice(0, 5).join(', ')}; cursor in Create New User; type User`,
          expected: { order, type: 'User', buttons },
        };
      },
    ),
    C(
      'fields.typed-upper-and-admin-type',
      'T02',
      'mutation',
      "MS_USER_KeyPress upper-cases typed keys and refuses the apostrophe (:1786-1799); tUserName.MaxLength 15 (:1087); Save stores Strings.Mid(cboUserTyp.Text,1,1) = 'A' for Admin (:1981)",
      async (ctx) =>
        withUsers(ctx, ['QT02ADMIN'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          await box(page, 'Create New User').fill("qt02'admin-and-more");
          const typed = await box(page, 'Create New User').inputValue();
          assert.equal(typed, 'QT02ADMIN-AND-M');
          await box(page, 'Create New User').fill('qt02admin');
          assert.equal(await box(page, 'Create New User').inputValue(), 'QT02ADMIN');
          await createThroughScreen(page, 'QT02ADMIN', 'moti-mahal-22', 'Admin');
          const row = await loginRow(ctx, 'QT02ADMIN');
          assert.equal(row.name, 'QT02ADMIN');
          assert.equal(row.catg, 'A');
          // Downstream: the new administrator opens an administrator screen.
          const admin = await ctx.session(login('QT02ADMIN', 'moti-mahal-22'));
          const response = await openUsers(admin.page);
          assert.equal(response.status(), 200);
          return {
            observation: `typed "qt02'admin-and-more" showed ${typed}; saved Admin as LOGIN_CATG ${row.catg}; the new admin opened User Create`,
            expected: { typed: 'QT02ADMIN-AND-M', catg: 'A' },
            database: { name: row.name, catg: row.catg },
            downstream: { adminListStatus: response.status() },
          };
        }),
    ),
    C(
      'password-rule.d34',
      'T03',
      'mutation',
      'D34 (document 12 §4): the desktop accepts any password (:1981); the web refuses fewer than 8 characters, a common password and one made from the login name or company code, with no composition rule, and writes nothing',
      async (ctx) =>
        withUsers(ctx, ['QT03NEW'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          const refusals = [
            ['tulsiba', 'Password must have at least 8 characters.'],
            ['Password123', 'This password is too common. Please choose another.'],
            ['qt03new-2026', 'Password may not be made from the user name.'],
            ['01010101', 'Password may not be made from the company code.'],
          ];
          const seen = [];
          for (const [password, text] of refusals) {
            await typeName(page, 'QT03NEW');
            await fillPasswords(page, password);
            const response = await save(page);
            assert.equal(response.status(), 400);
            await shown(page, text);
            seen.push(await msgText(page));
            assert.equal(await loginRow(ctx, 'QT03NEW'), undefined, `${password} wrote a row`);
          }
          // Eight lower-case letters: no composition rule.
          await page.getByRole('button', { name: 'Cancel', exact: true }).click();
          await createThroughScreen(page, 'QT03NEW', 'tulsibag');
          const row = await loginRow(ctx, 'QT03NEW');
          assert.match(row.pwd, /^\$argon2id\$/);
          return {
            observation: `refused: ${seen.join(' | ')}; "tulsibag" accepted`,
            expected: refusals.map(([, text]) => text),
            database: { refusedRows: 0, acceptedRow: row.name },
            downstream: { hash: 'argon2id' },
          };
        }),
    ),
    C(
      'lookup.user-list-and-edit-mode',
      'T04',
      'read-only',
      "AddCboItem (:1507-1532): a blank entry, then the company's login names in name order; a deleted login (D35) is not listed; tUserName_LostFocus (:2478-2498) on an existing name selects its type, Admin for LOGIN_CATG 'A…'",
      async (ctx) =>
        withUsers(ctx, ['QT04GONE'], async () => {
          // A deleted login is a master row seeded as the desktop would leave it after Delete in the web (inactive).
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","LOGIN_ACTIVE")
             VALUES ($1,'01','QT04GONE','x','U','N')`,
            ctx.tenantId,
          );
          const { page } = await ctx.session();
          await openUsers(page);
          const options = await box(page, 'User Name')
            .locator('option')
            .evaluateAll((o) => o.map((x) => x.textContent ?? ''));
          const expected = (
            await ctx.rows(
              `SELECT "LOGIN_NAME" n FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_ACTIVE"='Y' ORDER BY "LOGIN_NAME"`,
            )
          ).map((r) => r.n);
          assert.deepEqual(options, ['', ...expected]);
          assert.ok(!options.includes('QT04GONE'));
          await pickAndType(page, USERS.admin.user);
          assert.equal(await box(page, 'User Type').inputValue(), 'Admin');
          assert.equal(await page.locator('main .msg').count(), 0, 'no refusal in edit mode');
          return {
            observation: `User Name lists ['', ${expected.join(', ')}]; ${USERS.admin.user} selected Admin`,
            expected: { options: ['', ...expected], type: 'Admin' },
          };
        }),
    ),
    C(
      'rights-rows.seeded-all-y',
      'T05',
      'mutation',
      "Save of a new user inserts USER_SET for every menu with FRM_VIEW/EDIT/DELETE/PRINT 'Y', for LC_CODE '00' and the operator's location (:2012-2040, D36)",
      async (ctx) =>
        withUsers(ctx, ['QT05RIGHTS'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          await createThroughScreen(page, 'QT05RIGHTS', 'chandi-bazar');
          const rows = await userSet(ctx, 'QT05RIGHTS');
          const n = await catalogueSize();
          assert.deepEqual(rows, [
            { lc: '00', n, allY: true },
            { lc: '01', n, allY: true },
          ]);
          return {
            observation: `USER_SET: ${rows.map((r) => `${r.lc}=${r.n} all Y`).join(', ')}`,
            expected: { '00': n, '01': n, allY: true },
            database: rows,
            downstream: { menus: n },
          };
        }),
    ),
    C(
      'required.blank-name',
      'T06',
      'refusal',
      'BtnSave_Click: a blank Create New User says "Please Enter User Name." and puts the cursor in the name (:1960-1970); nothing is written',
      async (ctx) => {
        const { page } = await ctx.session();
        await openUsers(page);
        const before = await tenantFingerprint(ctx);
        await fillPasswords(page, 'tulsibag');
        await page.getByRole('button', { name: 'Save', exact: true }).click();
        await shown(page, T.NAME_REQUIRED);
        await page.waitForFunction(() => document.activeElement?.id === 'user-name');
        const after = await tenantFingerprint(ctx);
        assert.deepEqual(changedTables(before, after), []);
        return {
          observation: `"${await msgText(page)}", cursor in the name, nothing written`,
          expected: { message: T.NAME_REQUIRED },
          database: { changedTables: [] },
        };
      },
    ),
    C(
      'required.duplicate-name',
      'T06',
      'refusal',
      'tUserName_Validating (:2131-2150): in add mode an existing name says "This User Name already Exist.Please Change User Name...", keeps the cursor and selects the text; the refusal also stops Save',
      async (ctx) => {
        const { page } = await ctx.session();
        await openUsers(page);
        const before = await tenantFingerprint(ctx);
        await typeName(page, USERS.clerk.user);
        await shown(page, T.NAME_EXISTS);
        await page.waitForFunction(() => document.activeElement?.id === 'user-name');
        const selected = await page.evaluate(() => {
          const el = document.activeElement;
          return el instanceof HTMLInputElement
            ? el.value.slice(el.selectionStart ?? 0, el.selectionEnd ?? 0)
            : '';
        });
        assert.equal(selected, USERS.clerk.user.toUpperCase());
        await fillPasswords(page, 'tulsibag');
        await page.getByRole('button', { name: 'Save', exact: true }).click();
        await shown(page, T.NAME_EXISTS);
        assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
        return {
          observation: `"${await msgText(page)}"; name selected; Save refused; nothing written`,
          expected: { message: T.NAME_EXISTS },
          database: { changedTables: [] },
        };
      },
    ),
    C(
      'required.confirm-mismatch',
      'T06',
      'refusal',
      'tConPasword_Validating (:2205-2220): leaving Confirm Password different from New Password says "Password Not Match", clears it and returns the cursor; nothing is written',
      async (ctx) =>
        withUsers(ctx, ['QT06CONF'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          const before = await tenantFingerprint(ctx);
          await typeName(page, 'QT06CONF');
          await fillPasswords(page, 'tulsibag', 'tulsibah');
          await shown(page, T.PASSWORD_MISMATCH);
          await page.waitForFunction(() => document.activeElement?.id === 'user-confirmPassword');
          assert.equal(await box(page, 'Confirm Password').inputValue(), '');
          await page.getByRole('button', { name: 'Save', exact: true }).click();
          await shown(page, T.PASSWORD_MISMATCH);
          assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
          return {
            observation: `"${await msgText(page)}"; Confirm cleared and focused; nothing written`,
            expected: { message: T.PASSWORD_MISMATCH },
            database: { changedTables: [] },
          };
        }),
    ),
    C(
      'create.write-set',
      'T07',
      'mutation',
      "Save in add mode (:1820-2065): LOGIN_MAST (CO_CODE '01', LOGIN_NAME, LOGIN_CATG 'U', MAIN_USER = operator), USER_SET; \"User Are Created.\"; the form is cleared (:2095-2117); web: the password is an Argon2id hash, the login is active",
      async (ctx) =>
        withUsers(ctx, ['QT07RAMESH'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          const before = await tenantFingerprint(ctx);
          await createThroughScreen(page, 'QT07RAMESH', 'kesar-bagh-7');
          const after = await tenantFingerprint(ctx);
          assert.deepEqual(changedTables(before, after).sort(), ['LOGIN_MAST', 'USER_SET']);
          const row = await loginRow(ctx, 'QT07RAMESH');
          assert.equal(row.co, '01');
          assert.equal(row.catg, 'U');
          assert.equal(row.mainUser, USERS.admin.user);
          assert.equal(row.flags, 'YYY');
          assert.equal(row.reset, 'N');
          assert.equal(row.active, 'Y');
          assert.match(row.pwd, /^\$argon2id\$/);
          assert.equal(await box(page, 'Create New User').inputValue(), '');
          assert.equal(await box(page, 'User Type').inputValue(), 'User');
          const listed = await box(page, 'User Name')
            .locator('option')
            .evaluateAll((o) => o.map((x) => x.textContent));
          assert.ok(listed.includes('QT07RAMESH'));
          // Downstream: the new user signs in with the password typed.
          const user = await ctx.session(login('QT07RAMESH', 'kesar-bagh-7'));
          assert.match(new URL(user.page.url()).pathname, /^\/dashboard/);
          return {
            observation: `"User Are Created."; LOGIN_MAST co ${row.co} catg ${row.catg} main ${row.mainUser} active ${row.active}; form cleared; the user signed in`,
            expected: { catg: 'U', mainUser: USERS.admin.user, tables: ['LOGIN_MAST', 'USER_SET'] },
            database: { ...row, pwd: 'argon2id' },
            downstream: { signedIn: true, listed: true },
          };
        }),
    ),
    C(
      'unchanged.reopen-save',
      'T08',
      'mutation',
      'Edit mode Save of an existing user with the right old password and the same type answers "User Are Created." (:1942); web: a blank New Password keeps the password (the desktop would store a blank one), so the footprint is unchanged',
      async (ctx) =>
        withUsers(ctx, ['QT08SAME'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          await createThroughScreen(page, 'QT08SAME', 'heera-moti-8');
          const before = await tenantFingerprint(ctx);
          await pickAndType(page, 'QT08SAME');
          await box(page, 'Old Password').fill('heera-moti-8');
          const response = await save(page);
          assert.equal(response.status(), 200);
          await shown(page, T.CREATED);
          assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
          return {
            observation: '"User Are Created." and every tenant table unchanged',
            expected: { message: T.CREATED, changedTables: [] },
            database: { changedTables: [] },
            downstream: { status: response.status() },
          };
        }),
    ),
    C(
      'edit.change-password',
      'T09',
      'mutation',
      'tOldPasword_Validating (:2222-2253): leaving Old Password blank says "Please Insert Old Password"; a different one "Old Password Doesn\'t Match" (web: at Save); the right one lets Save store the new password',
      async (ctx) =>
        withUsers(ctx, ['QT09EDIT'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          await createThroughScreen(page, 'QT09EDIT', 'panna-gali-9');
          const first = await loginRow(ctx, 'QT09EDIT');
          await pickAndType(page, 'QT09EDIT');
          await box(page, 'Old Password').press('Tab');
          await shown(page, T.OLD_PASSWORD_REQUIRED);
          await page.waitForFunction(() => document.activeElement?.id === 'user-oldPassword');
          await box(page, 'Old Password').fill('panna-gali-0');
          await fillPasswords(page, 'zaveri-bazar-9');
          let response = await save(page);
          assert.equal(response.status(), 400);
          await shown(page, T.OLD_PASSWORD_WRONG);
          assert.equal(
            (await loginRow(ctx, 'QT09EDIT')).pwd,
            first.pwd,
            'wrong old password changed nothing',
          );
          await box(page, 'Old Password').fill('panna-gali-9');
          await fillPasswords(page, 'zaveri-bazar-9');
          response = await save(page);
          assert.equal(response.status(), 200, await response.text());
          await shown(page, T.CREATED);
          const after = await loginRow(ctx, 'QT09EDIT');
          assert.notEqual(after.pwd, first.pwd);
          assert.equal(after.rowId, first.rowId);
          const user = await ctx.session(login('QT09EDIT', 'zaveri-bazar-9'));
          assert.match(new URL(user.page.url()).pathname, /^\/dashboard/);
          return {
            observation: `blank → "${T.OLD_PASSWORD_REQUIRED}"; wrong → "${T.OLD_PASSWORD_WRONG}" (no change); right → "${T.CREATED}", new hash, signs in with the new password`,
            expected: [T.OLD_PASSWORD_REQUIRED, T.OLD_PASSWORD_WRONG, T.CREATED],
            database: { sameRow: true, hashChanged: true },
            downstream: { signedInWithNewPassword: true },
          };
        }),
    ),
    C(
      'delete.deactivate-and-revoke',
      'T10',
      'mutation',
      'BtnDelete_Click (:2067-2093): blank name → "Please Select User For Delete."; "Are You Sure To Delete This User now?" (No keeps the user); Yes → "Delete Success."; D35: the login is kept inactive, every session revoked, the deleted user\'s open screen is refused on its next request',
      async (ctx) =>
        withUsers(ctx, ['QT10GONE'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          await createThroughScreen(page, 'QT10GONE', 'sona-chandi-10');
          const victim = await ctx.session(login('QT10GONE', 'sona-chandi-10'));
          assert.equal((await openSessions(ctx, 'QT10GONE')).open >= 1, true);

          await page.getByRole('button', { name: 'Delete', exact: true }).click();
          await shown(page, T.SELECT_FOR_DELETE);
          let accept = false;
          const questions = answerDialogs(page, () => accept);
          await pickAndType(page, 'QT10GONE');
          await page.getByRole('button', { name: 'Delete', exact: true }).click();
          await page.waitForTimeout(300);
          assert.equal((await loginRow(ctx, 'QT10GONE')).active, 'Y', 'No keeps the user');
          accept = true;
          const response = page.waitForResponse((r) => isApi(r, 'DELETE', '/admin/users/QT10GONE'));
          await page.getByRole('button', { name: 'Delete', exact: true }).click();
          assert.equal((await response).status(), 200);
          await shown(page, T.DELETED);
          assert.deepEqual(questions, [T.DELETE_CONFIRM, T.DELETE_CONFIRM]);

          const row = await loginRow(ctx, 'QT10GONE');
          assert.equal(row.active, 'N');
          assert.equal(row.deactivatedBy, USERS.admin.user);
          const sessions = await openSessions(ctx, 'QT10GONE');
          assert.equal(sessions.open, 0);
          const rights = await userSet(ctx, 'QT10GONE');
          assert.equal(rights.length, 2, 'USER_SET rows stay');
          const options = await box(page, 'User Name')
            .locator('option')
            .evaluateAll((o) => o.map((x) => x.textContent));
          assert.ok(!options.includes('QT10GONE'));
          // The deleted user's still-open browser: the next request is refused and the screen goes to the login.
          await victim.page.goto('/dashboard');
          await victim.page.waitForURL('**/login', { timeout: 20_000 });
          return {
            observation: `blank → "${T.SELECT_FOR_DELETE}"; No kept the user; Yes → "${T.DELETED}"; LOGIN_ACTIVE N, ${sessions.n} session(s) all revoked; the open session was sent to the login`,
            expected: {
              questions: [T.DELETE_CONFIRM, T.DELETE_CONFIRM],
              active: 'N',
              openSessions: 0,
            },
            database: {
              row: { active: row.active, deactivatedBy: row.deactivatedBy },
              sessions,
              rights,
            },
            downstream: { victimRedirectedToLogin: true, listed: false },
          };
        }),
    ),
    C(
      'delete.last-admin-refused',
      'T10',
      'refusal',
      'N169/G178: the company keeps an administrator; Delete of its only administrator is refused and nothing changes',
      async (ctx) => {
        const admins = await ctx.rows(
          `SELECT "LOGIN_NAME" n FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_ACTIVE"='Y' AND upper("LOGIN_CATG") LIKE 'A%'`,
        );
        assert.deepEqual(
          admins.map((r) => r.n),
          [USERS.admin.user],
          'precondition: the catalogue admin is the only administrator',
        );
        const { page } = await ctx.session();
        await openUsers(page);
        const before = await tenantFingerprint(ctx);
        await pickAndType(page, USERS.admin.user);
        const response = page.waitForResponse((r) => r.request().method() === 'DELETE');
        await page.getByRole('button', { name: 'Delete', exact: true }).click();
        assert.equal((await response).status(), 400);
        await shown(page, 'at least one administrator');
        assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
        return {
          observation: `"${await msgText(page)}"; nothing changed`,
          expected: { status: 400, changedTables: [] },
          database: { changedTables: [] },
        };
      },
    ),
    C(
      'rights.clerk-refused',
      'T11',
      'refusal',
      'MDI_FORM.cs:7028-7050 refuses a screen without the View right with "You Have No Rights....."; the web keeps User Create to administrators (a USER login is refused by every route) and nothing is written',
      async (ctx) => {
        const { page } = await ctx.session(as(USERS.clerk.user));
        const before = await tenantFingerprint(ctx);
        const response = await openUsers(page);
        assert.equal(response.status(), 403);
        await shown(page, T.NO_RIGHTS);
        const statuses = await page.evaluate(async () => {
          const call = (method, url, body) =>
            fetch(url, {
              method,
              credentials: 'include',
              headers: body ? { 'content-type': 'application/json' } : {},
              body: body ? JSON.stringify(body) : undefined,
            }).then((r) => r.status);
          return [
            await call('POST', '/api/admin/users', {
              loginName: 'QT11X',
              password: 'kesarbagh',
              confirmPassword: 'kesarbagh',
              userType: 'Admin',
            }),
            await call('POST', '/api/admin/users/e2eadmin/update', {
              oldPassword: 'x',
              userType: 'User',
            }),
            await call('DELETE', '/api/admin/users/e2eadmin'),
          ];
        });
        assert.deepEqual(statuses, [403, 403, 403]);
        assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
        return {
          observation: `the clerk saw "${T.NO_RIGHTS}"; create, edit and delete answered ${statuses.join('/')}`,
          expected: { list: 403, writes: [403, 403, 403] },
          database: { changedTables: [] },
        };
      },
    ),
    C(
      'concurrency.same-name-two-admins',
      'T12',
      'mutation',
      'Two operators type the same new name: both pass the name check (it does not exist yet, :2131-2150); the first Save creates it, the second is refused with "This User Name already Exist.Please Change User Name..." and one login exists',
      async (ctx) =>
        withUsers(ctx, ['QT12SAME'], async () => {
          const a = await ctx.session();
          const b = await ctx.session(as(USERS.admin.user, `${USERS.admin.user}#2`));
          await openUsers(a.page);
          await openUsers(b.page);
          await typeName(a.page, 'QT12SAME');
          await typeName(b.page, 'QT12SAME');
          await fillPasswords(a.page, 'kundan-kari-12');
          await fillPasswords(b.page, 'meena-kari-12');
          const first = await save(a.page);
          assert.equal(first.status(), 201);
          const second = await save(b.page);
          assert.equal(second.status(), 409);
          await shown(b.page, T.NAME_EXISTS);
          const count = await ctx.rows(
            `SELECT count(*)::int n FROM "LOGIN_MAST" WHERE tenant_id=$1 AND upper("LOGIN_NAME")='QT12SAME'`,
          );
          assert.equal(count[0].n, 1);
          return {
            observation: `first Save 201, second 409 "${T.NAME_EXISTS}"; one LOGIN_MAST row`,
            expected: { statuses: [201, 409], rows: 1 },
            database: { rows: count[0].n },
            downstream: { secondMessage: T.NAME_EXISTS },
          };
        }),
    ),
    C(
      'retry.replayed-create',
      'T13',
      'mutation',
      'A Save whose answer was lost is sent again: the name now exists (:2131-2150), so the replay is refused and there is still one login and one set of rights',
      async (ctx) =>
        withUsers(ctx, ['QT13ONCE'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          const sent = page.waitForRequest(
            (r) => r.method() === 'POST' && new URL(r.url()).pathname === '/api/admin/users',
          );
          await createThroughScreen(page, 'QT13ONCE', 'nath-bali-13');
          const body = (await sent).postData();
          const before = await tenantFingerprint(ctx);
          const replay = await page.evaluate(
            (payload) =>
              fetch('/api/admin/users', {
                method: 'POST',
                credentials: 'include',
                headers: { 'content-type': 'application/json' },
                body: payload,
              }).then(async (r) => ({ status: r.status, body: await r.json() })),
            body,
          );
          assert.equal(replay.status, 409);
          assert.equal(replay.body.message, T.NAME_EXISTS);
          assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
          const n = await catalogueSize();
          assert.deepEqual(await userSet(ctx, 'QT13ONCE'), [
            { lc: '00', n, allY: true },
            { lc: '01', n, allY: true },
          ]);
          return {
            observation: `the replayed Save answered ${replay.status} "${replay.body.message}"; nothing changed`,
            expected: { status: 409, rows: 1 },
            database: { changedTables: [] },
            downstream: { userSetSets: 2 },
          };
        }),
    ),
    C(
      'rollback.user-set-fault',
      'T14',
      'mutation',
      'The desktop writes LOGIN_MAST and USER_SET one statement at a time (:1981-2040), so a failure leaves a login without rights; the web writes both in one transaction: a fault on USER_SET leaves every table as it was, then the same Save succeeds',
      async (ctx) =>
        withUsers(ctx, ['QT14FAULT'], async () => {
          const fn = 'wp06_user_set_fault';
          await ctx.owner.$executeRawUnsafe(
            `CREATE OR REPLACE FUNCTION ${fn}() RETURNS trigger LANGUAGE plpgsql AS $$
             BEGIN
               IF NEW.tenant_id = '${ctx.tenantId}' AND NEW."USER_NAME" = 'QT14FAULT' THEN
                 RAISE EXCEPTION 'wp06 injected USER_SET fault';
               END IF;
               RETURN NEW;
             END $$`,
          );
          await ctx.owner.$executeRawUnsafe(
            `CREATE TRIGGER ${fn} BEFORE INSERT ON "USER_SET" FOR EACH ROW EXECUTE FUNCTION ${fn}()`,
          );
          let faulted;
          try {
            const { page } = await ctx.session();
            await openUsers(page);
            const before = await tenantFingerprint(ctx);
            await typeName(page, 'QT14FAULT');
            await fillPasswords(page, 'jhumka-bali-14');
            faulted = await save(page);
            assert.ok(faulted.status() >= 400, `fault answered ${faulted.status()}`);
            assert.deepEqual(changedTables(before, await tenantFingerprint(ctx)), []);
            await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS ${fn} ON "USER_SET"`);
            const again = await save(page);
            assert.equal(again.status(), 201);
            await shown(page, T.CREATED);
            assert.equal((await userSet(ctx, 'QT14FAULT')).length, 2);
            return {
              observation: `fault on USER_SET answered ${faulted.status()} and left every table unchanged; the same Save then created the user`,
              expected: { changedTablesOnFault: [], thenCreated: true },
              database: { changedTablesOnFault: [] },
              downstream: { userSetSets: 2 },
            };
          } finally {
            await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS ${fn} ON "USER_SET"`);
            await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS ${fn}()`);
          }
        }),
    ),
    C(
      'edition.lite-hides-rights',
      'T15',
      'read-only',
      "D36 / MS_USER.cs:1489-1495: with MsSoftType 'L' the rights grid (DGV) and the Update User Right button are hidden; the feature stack runs the Lite default (no edition gate, D33)",
      async (ctx) => {
        const { page } = await ctx.session();
        await openUsers(page);
        await box(page, 'User Name').selectOption(USERS.clerk.user);
        await page.waitForTimeout(300);
        assert.equal(await page.getByRole('button', { name: 'Update User Right' }).count(), 0);
        assert.equal(await page.getByTestId('user-rights-grid').count(), 0);
        assert.equal(await page.getByRole('columnheader', { name: 'Sub Menu' }).count(), 0);
        return {
          observation: 'no rights grid and no Update User Right button after picking a user',
          expected: { grid: 0, button: 0 },
        };
      },
    ),
    C(
      'history.desktop-plaintext-forced-reset',
      'T15',
      'mutation',
      'D34: a desktop-era login keeps its plain-text LOGIN_PWD (:1981) until it signs in; the web then stores a hash, forces a password change, and the change follows D34',
      async (ctx) =>
        withUsers(ctx, ['QT15OLD'], async () => {
          await ctx.owner.$executeRawUnsafe(
            `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED")
             VALUES ($1,'01','QT15OLD','12345','U','N')`,
            ctx.tenantId,
          );
          const context = await ctx.stack.browser.newContext({
            baseURL: ctx.stack.target.webOrigin,
            viewport: { width: 1366, height: 768 },
          });
          try {
            const page = await context.newPage();
            await page.goto('/login');
            await page.getByLabel('User', { exact: true }).fill('QT15OLD');
            await page.getByLabel('Password', { exact: true }).fill('12345');
            await page.getByRole('button', { name: 'Sign In', exact: true }).click();
            await page.waitForURL('**/password-change', { timeout: 20_000 });
            const migrated = await loginRow(ctx, 'QT15OLD');
            assert.match(migrated.pwd, /^\$argon2id\$/);
            assert.equal(migrated.reset, 'Y');
            const fields = page.locator('input[type=password]');
            await fields.nth(0).fill('12345');
            await fields.nth(1).fill('qt15old99');
            await fields.nth(2).fill('qt15old99');
            await page.getByRole('button', { name: /change/i }).click();
            await page.getByText('Password may not be made from the user name.').waitFor();
            await fields.nth(1).fill('nayi-chabi-15');
            await fields.nth(2).fill('nayi-chabi-15');
            await page.getByRole('button', { name: /change/i }).click();
            await page.waitForURL('**/select', { timeout: 20_000 });
            const changed = await loginRow(ctx, 'QT15OLD');
            assert.equal(changed.reset, 'N');
            return {
              observation:
                'plain-text login signed in, was hashed and sent to Change Password; a name-based password was refused (D34), a good one accepted',
              expected: { hashed: true, forcedChange: true, d34Refusal: 'login-name' },
              database: { resetAfterLogin: migrated.reset, resetAfterChange: changed.reset },
              downstream: { landedOn: '/select' },
            };
          } finally {
            await context.close();
          }
        }),
    ),
    C(
      'output.print-no-report',
      'T16',
      'read-only',
      'BtnPrint_Click (:1811-1818) only refuses a user without the Print right ("You Have No Print Rights....."); with the right it prints nothing: MS_USER has no report and no Crystal template exists for it',
      async (ctx) => {
        const s = await ctx.session();
        await openUsers(s.page);
        const before = s.requests.length;
        await s.page.getByRole('button', { name: 'Print', exact: true }).click();
        await s.page.waitForTimeout(500);
        assert.equal(s.requests.length, before, 'Print sends no request');
        assert.equal(await s.page.locator('main .msg').count(), 0);
        return {
          observation: 'Print sent no request and showed nothing, as the desktop prints nothing',
          expected: { requests: 0, message: null },
        };
      },
    ),
    C(
      'keyboard.enter-walk-and-esc',
      'T17',
      'mutation',
      'Enter is Tab on every box (SendKeys {tab}, :2153-2203, :2256-2263), not on a blank name (:2199); Enter on User Type reaches Save (TabIndex 5); Esc closes the screen (:1801-1810)',
      async (ctx) =>
        withUsers(ctx, ['QT17KEYS'], async () => {
          const { page } = await ctx.session();
          await page.setViewportSize({ width: 1366, height: 768 });
          await openUsers(page);
          await page.keyboard.press('Enter');
          assert.equal(await focused(page), 'user-name', 'Enter on a blank name stays');
          await page.keyboard.type('qt17keys');
          await page.keyboard.press('Enter');
          assert.equal(await focused(page), 'user-oldPassword');
          await page.keyboard.press('Enter');
          assert.equal(await focused(page), 'user-newPassword');
          await page.keyboard.type('pagdi-wala-17');
          await page.keyboard.press('Enter');
          assert.equal(await focused(page), 'user-confirmPassword');
          await page.keyboard.type('pagdi-wala-17');
          await page.keyboard.press('Enter');
          assert.equal(await focused(page), 'user-userType');
          await page.keyboard.press('Enter');
          assert.equal(await page.evaluate(() => document.activeElement?.textContent), 'Save');
          const response = page.waitForResponse((r) => isApi(r, 'POST', '/admin/users'));
          await page.keyboard.press('Enter');
          assert.equal((await response).status(), 201);
          await shown(page, T.CREATED);
          const row = await loginRow(ctx, 'QT17KEYS');
          assert.equal(row.name, 'QT17KEYS');
          await page.keyboard.press('Escape');
          await page.waitForURL((url) => !url.pathname.startsWith('/admin/users'));
          return {
            observation: `Enter walked name → old → new → confirm → type → Save; Enter saved ${row.name}; Esc left the screen for ${new URL(page.url()).pathname}`,
            expected: [
              'user-name',
              'user-oldPassword',
              'user-newPassword',
              'user-confirmPassword',
              'user-userType',
              'Save',
            ],
            database: { name: row.name },
            downstream: { left: new URL(page.url()).pathname },
          };
        }),
    ),
    C(
      'journey.delete-then-recreate',
      'T18',
      'mutation',
      'A created user works with the all-Y rights (:2012-2040); Delete (D35) ends their session; saving the name again creates it anew (the desktop re-inserts the deleted rows; the web reactivates the same login) with the new password',
      async (ctx) =>
        withUsers(ctx, ['QT18JOURNEY'], async () => {
          const { page } = await ctx.session();
          await openUsers(page);
          await createThroughScreen(page, 'QT18JOURNEY', 'mangal-sutra-18');
          const first = await loginRow(ctx, 'QT18JOURNEY');
          const user = await ctx.session(login('QT18JOURNEY', 'mangal-sutra-18'));
          const [opened] = await Promise.all([
            user.page.waitForResponse((r) => isApi(r, 'GET', '/masters/address-master')),
            user.page.goto('/masters/addresses'),
          ]);
          assert.equal(
            opened.status(),
            200,
            'the new user opens a master screen with the seeded rights',
          );

          await pickAndType(page, 'QT18JOURNEY');
          await page.getByRole('button', { name: 'Delete', exact: true }).click();
          await shown(page, T.DELETED);
          await user.page.goto('/dashboard');
          await user.page.waitForURL('**/login', { timeout: 20_000 });

          await createThroughScreen(page, 'QT18JOURNEY', 'nayi-shuruat-18');
          const again = await loginRow(ctx, 'QT18JOURNEY');
          assert.equal(again.rowId, first.rowId, 'the same login is reactivated');
          assert.equal(again.active, 'Y');
          const back = await ctx.session(login('QT18JOURNEY', 'nayi-shuruat-18', 'QT18JOURNEY#2'));
          assert.match(new URL(back.page.url()).pathname, /^\/dashboard/);
          return {
            observation:
              'created → worked on Address Master → deleted (session ended) → saved again → signed in with the new password',
            expected: { reactivatedSameRow: true, signedInAgain: true },
            database: { rowId: again.rowId, active: again.active },
            downstream: {
              addressMaster: opened.status(),
              afterDelete: '/login',
              afterRecreate: '/dashboard',
            },
          };
        }),
    ),
  ],
};
