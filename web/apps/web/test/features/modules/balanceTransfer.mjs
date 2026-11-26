import assert from 'node:assert/strict';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { escLeavesWithNoFocus } from '../harness.mjs';
import {
  as,
  C,
  notApplicable,
  PATH,
  CONFIRM,
  COMPLETE,
  NO_YEAR,
  LITE,
  NON_LITE,
  PARTY,
  ITEM,
  button,
  exec,
  sessionYear,
  withNextYears,
  openScreen,
  runDataset,
  seedParty,
  dropParty,
} from './balanceTransferShared.mjs';
import { nextYearCases } from './balanceTransferNextYear.mjs';
import { faultCases } from './balanceTransferFaults.mjs';

/**
 * Feature: Company → Balance TrFr (desktop BtmSchm, web /company/balance-transfer). Case ids follow the frozen list
 * orchestration/work/WP-23/cases.md; the database layer of the carry rules is api/test/balanceTransfer*.test.ts.
 *
 * Desktop rules used for the expected values (BtmSchm.cs unless noted):
 * - MDI_FORM.cs:7431-7433 opens the form directly; title = the menu caption (:1947); "Transfer Year" (:1391) holds the
 *   first YEAR_MAST year after the current one (:2085-2105); with none: "There Are Not Found New Year Please Creat New
 *   Year And Try...." (:2142).
 * - Lite buttons Ac Balance (TabIndex 1), Item Stock (2), Tag Stock (3), Sales Order (1155), Approval (1159); the other
 *   fourteen are hidden or belong to menus outside Lite (study, button table).
 * - Each asks "Are You Sure To Data Transfer to Next Year ?" (:2729), No returns (:2729 `!= 6`), and ends with
 *   "Process Are Complete...." (:2755). Esc closes (:2692-2695).
 * - Ac Balance: parties, to the closing date, per AC_CODE and DATA_TYPE, Cr-positive, OP_DATA book 000 / 00000,
 *   DATA_TRFR 'Y' (:2786-2801). Item Stock: untagged MAIN_STOCK, fine = net × AVG_TOUCH / 100 (:2933-2994).
 * Web differences on purpose (gap G248): the Transfer Year is not typed; with no later year the buttons are disabled;
 * Cancel keeps the Transfer Year; Tag Stock, Sales Order and Approval are refused pending owner decisions Q1/Q8.
 */
export const balanceTransfer = {
  feature: 'balance-transfer',
  title: 'Company → Balance TrFr (BtmSchm)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/company/balance-transfer/page.tsx',
    'web/apps/web/lib/screenEscape.ts',
    'web/apps/api/src/modules/ops/balanceTransfer.ts',
    'web/apps/api/src/modules/ops/balanceTransferRules.ts',
    'web/apps/api/src/routes/balanceTransfer.ts',
    'web/apps/web/test/features/modules/balanceTransfer.mjs',
    'web/apps/web/test/features/modules/balanceTransferShared.mjs',
    'web/apps/web/test/features/modules/balanceTransferNextYear.mjs',
    'web/apps/web/test/features/modules/balanceTransferFaults.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    companySettings: 'catalogue defaults; the Transfer Year rows of YEAR_MAST are seeded per case',
  },
  cases: [
    C(
      'entry.five-lite-buttons',
      'T01',
      'read-only',
      'BtmSchm.cs:1373, :1310, :1341 TabIndex 1-3; study button table (five Lite datasets); gap 20',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async () => {
          await openScreen(page);
          const names = await page
            .getByTestId('balance-transfer-buttons')
            .getByRole('button')
            .allInnerTexts();
          assert.deepEqual(names, LITE);
          // The page itself, not the application menu (which lists Year Create under Company).
          const screen = page.getByTestId('balance-transfer-screen');
          for (const link of [
            'Year Create',
            'Year-End Close',
            'Pledge / Dhiran',
            'Loan Issue',
            'MFG Issue',
          ])
            assert.equal(await screen.getByRole('link', { name: link }).count(), 0, `${link} link`);
          for (const absent of ['Delete', 'Print'])
            assert.equal(
              await screen.getByRole('button', { name: absent, exact: true }).count(),
              0,
              `${absent} is not offered`,
            );
          return { observation: `buttons ${names.join(', ')}`, expected: LITE.join(', ') };
        });
      },
    ),
    C(
      'entry.non-lite-absent',
      'T01',
      'read-only',
      'BtmSchm.cs:1641, :1891 hide Jadtar and Mfg; the other buttons belong to menus outside Lite (study)',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        const text = await page.locator('main').innerText();
        const found = NON_LITE.filter((name) => text.includes(name));
        assert.deepEqual(found, []);
        return { observation: 'no non-Lite button text on the page', expected: 'none of 14' };
      },
    ),
    C(
      'entry.title-and-caption',
      'T01',
      'read-only',
      'BtmSchm.cs:1947 lblBook.Text = CurProcess; :1391 Transfer Year',
      async (ctx) => {
        const { page } = await ctx.session();
        await openScreen(page);
        await page.getByLabel('Transfer Year', { exact: true }).waitFor();
        return { observation: 'heading Balance TrFr, label Transfer Year', expected: 'same' };
      },
    ),
    C(
      'entry.default-target-year',
      'T01',
      'read-only',
      "BtmSchm.cs:2091 AND CO_YEAR > MCo_year ORDER BY CO_YEAR; :2102 tYearCode = the first row's CO_YEAR",
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 2, async ({ next }) => {
          await openScreen(page);
          const shown = await page.getByLabel('Transfer Year', { exact: true }).inputValue();
          assert.equal(shown, next[0].year);
          return { observation: `Transfer Year ${shown}`, expected: next[0].year };
        });
      },
    ),
    C(
      'entry.initial-focus',
      'T01',
      'read-only',
      'BtmSchm.cs:1373 BtnAcBalence TabIndex 1',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async () => {
          await openScreen(page);
          await page.waitForFunction(() => document.activeElement?.textContent === 'Ac Balance');
          return { observation: 'focus on Ac Balance', expected: 'Ac Balance' };
        });
      },
    ),
    C(
      'field.target-year-not-free-text',
      'T02',
      'refusal',
      'BtmSchm.cs:2129 writers read whatever tYearCode holds (study Q2); the web computes the year (deliberate)',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ next }) => {
          await openScreen(page);
          const box = page.getByLabel('Transfer Year', { exact: true });
          assert.equal(await box.getAttribute('readonly'), '');
          const before = await ctx.rows(
            `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_YEAR"='2099-2100'`,
          );
          const refused = await page.request.post('/api/balance-transfer/ac-balance', {
            data: { toYear: '2099-2100' },
          });
          assert.equal(refused.status(), 400, await refused.text());
          const after = await ctx.rows(
            `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_YEAR" IN ('2099-2100',$2)`,
            next[0].year,
          );
          assert.equal(after[0].n, 0);
          return {
            observation: `read-only box; API ${refused.status()}`,
            expected: 'not editable; 400; nothing written',
            database: { before: before[0].n, after: after[0].n },
          };
        });
      },
    ),
    C(
      'invalid.no-next-year-message',
      'T06',
      'refusal',
      'BtmSchm.cs:2142 the no-year message; weakness 8 (buttons stay live on the desktop: deliberate difference)',
      async (ctx) => {
        const { page } = await ctx.session();
        const later = await ctx.rows(
          `SELECT count(*)::int n FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "CO_YEAR" > $2`,
          await sessionYear(page),
        );
        assert.equal(later[0].n, 0, 'the catalogue has no later year');
        await openScreen(page);
        await page.getByText(NO_YEAR, { exact: true }).waitFor();
        for (const label of LITE) assert.equal(await button(page, label).isDisabled(), true, label);
        return {
          observation: 'message shown, five buttons disabled',
          expected: NO_YEAR,
          database: { laterYears: later[0].n },
        };
      },
    ),
    C(
      'invalid.cancel-does-not-blank-year',
      'T06',
      'read-only',
      'BtmSchm.cs:2641-2652 CLEAR_DATA blanks tYearCode (weakness 8); the web keeps it',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ next }) => {
          await openScreen(page);
          await button(page, 'Cancel').click();
          assert.equal(
            await page.getByLabel('Transfer Year', { exact: true }).inputValue(),
            next[0].year,
          );
          return { observation: 'Transfer Year kept after Cancel', expected: next[0].year };
        });
      },
    ),
    C(
      'invalid.confirm-no-aborts',
      'T06',
      'refusal',
      'BtmSchm.cs:2729 (MsgBoxStyle)4 ... != 6 returns',
      async (ctx) => {
        const { page, requests } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ next }) => {
          await openScreen(page);
          const sent = () =>
            requests.filter(
              (r) => r.method === 'POST' && /balance-transfer\//.test(r.path ?? r.url ?? ''),
            ).length;
          const before = sent();
          const texts = [];
          for (const label of LITE) texts.push(...(await runDataset(page, label, false)).dialogs);
          assert.deepEqual(
            texts,
            LITE.map(() => CONFIRM),
          );
          assert.equal(sent(), before, 'no request is sent');
          const rows = await ctx.rows(
            `SELECT count(*)::int n FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2`,
            next[0].year,
          );
          assert.equal(rows[0].n, 0);
          assert.equal(await page.getByText(COMPLETE, { exact: true }).count(), 0);
          return {
            observation: `five confirmations answered No`,
            expected: 'no request, no row, no completion',
            database: { opData: rows[0].n },
          };
        });
      },
    ),
    C(
      'ac.create.footprint',
      'T07',
      'mutation',
      'BtmSchm.cs:2786 parties to the closing date per AC_CODE/DATA_TYPE; :2801 OP_DATA 000/00000, DATA_TRFR Y; :2755',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
          await seedParty(ctx, current, clDate);
          try {
            await openScreen(page);
            const { dialogs, response } = await runDataset(page, 'Ac Balance');
            assert.equal(response.status(), 200, await response.text());
            assert.deepEqual(dialogs, [CONFIRM]);
            await page.getByText(COMPLETE, { exact: true }).waitFor();
            const rows = await ctx.rows(
              `SELECT "CO_YEAR" yr,"CO_BOOK" book,"VCH_NO" vch,"OP_AMT"::float amt,"OP_SIGN" sg,"FINE_BAL"::float g,
                      "FINE_SIGN" gs,"SL_FINE_BAL"::float s,"SL_FINE_SIGN" ss,"DATA_TYPE" dt,"DATA_TRFR" tr
                 FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
              PARTY.code,
            );
            // 5000.00 − 1200.50 − 300.25 = 3499.25 Cr; the voucher after the closing date is left out.
            assert.deepEqual(rows, [
              {
                yr: next[0].year,
                book: '000',
                vch: '00000',
                amt: 3499.25,
                sg: 'C',
                g: 0,
                gs: 'D',
                s: 0,
                ss: 'D',
                dt: 'A',
                tr: 'Y',
              },
            ]);
            const legs = await ctx.rows(
              `SELECT coalesce(sum(coalesce("CR_AMT",0)-coalesce("DR_AMT",0)),0)::float net, count(*)::int n
                 FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"='000'`,
              PARTY.code,
              next[0].year,
            );
            assert.deepEqual(legs, [{ net: 3499.25, n: 1 }]);
            return {
              observation: `OP_DATA ${JSON.stringify(rows[0])}`,
              expected: '3499.25 C in the Transfer Year, one opening leg',
              database: { opData: rows, legs },
              downstream: { ledgerOpening: legs[0] },
            };
          } finally {
            await dropParty(ctx);
          }
        });
      },
    ),
    C(
      'rerun.ac-balance-replaces',
      'T09',
      'mutation',
      'BtmSchm.cs:2764 DELETE FROM OP_DATA then rewrite; target year only (D4)',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ current, clDate }) => {
          await seedParty(ctx, current, clDate);
          try {
            await openScreen(page);
            await runDataset(page, 'Ac Balance');
            await page.getByText(COMPLETE, { exact: true }).waitFor();
            await exec(
              ctx,
              `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","DATA_TYPE","VCH_TYPE","LEDR_KEY")
               VALUES ($1,'01','01',$2,'JV','BT5',$3::date,$4,0,249.25,'A','A','JV','E2E-BT-5')`,
              current,
              clDate,
              PARTY.code,
            );
            await openScreen(page);
            const { response } = await runDataset(page, 'Ac Balance');
            assert.equal(response.status(), 200, await response.text());
            const rows = await ctx.rows(
              `SELECT "OP_AMT"::float amt,"OP_SIGN" sg FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
              PARTY.code,
            );
            assert.deepEqual(rows, [{ amt: 3250, sg: 'C' }]);
            return {
              observation: JSON.stringify(rows),
              expected: '3499.25 − 249.25 = 3250.00 C, one row',
              database: rows,
              downstream: { rows: rows.length },
            };
          } finally {
            await dropParty(ctx);
          }
        });
      },
    ),
    C(
      'item.create.footprint',
      'T07',
      'mutation',
      'BtmSchm.cs:2933 untagged MAIN_STOCK to the closing date; :2960 fine = net × touch / 100; :2966 ITM_OPBL',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ current, clDate, next }) => {
          await exec(
            ctx,
            `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","ITEM_RATE","AVG_TOUCH")
             VALUES ($1,'01',$2,$3,'G','E1',50,91.6)`,
            ITEM.code,
            ITEM.name,
          );
          try {
            for (const [no, sign, pcs, gwt, nwt] of [
              ['BT1', '+', 10, 100.5, 98.25],
              ['BT2', '-', 4, 40.2, 39.3],
            ])
              await exec(
                ctx,
                `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","TAG_NO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
                 VALUES ($1,'01','01',$2,'PUR',$3,$4::date,$5,'N',$6,$7,$8,$9)`,
                current,
                no,
                clDate,
                ITEM.code,
                sign,
                pcs,
                gwt,
                nwt,
              );
            await openScreen(page);
            const { response } = await runDataset(page, 'Item Stock');
            assert.equal(response.status(), 200, await response.text());
            await page.getByText(COMPLETE, { exact: true }).waitFor();
            const rows = await ctx.rows(
              `SELECT "CO_YEAR" yr,"CO_BOOK" book,"VCH_NO" vch,"ITM_PCS"::float pcs,"ITM_GWT"::float gwt,
                      "ITM_NWT"::float nwt,"ITM_TOUCH"::float touch,"ITM_FINE"::float fine,"ITM_AMT"::float amt,
                      "NET_AMT"::float net,"DATA_TRFR" tr,"DATA_TYPE" dt
                 FROM "ITM_OPBL" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEM.code,
            );
            // 10 − 4 = 6 pcs; 60.300 / 58.950; fine 58.950 × 91.600 / 100 = 53.998; 6 × 50.00 = 300.00.
            assert.deepEqual(rows, [
              {
                yr: next[0].year,
                book: '000',
                vch: 'G',
                pcs: 6,
                gwt: 60.3,
                nwt: 58.95,
                touch: 91.6,
                fine: 53.998,
                amt: 300,
                net: 300,
                tr: 'Y',
                dt: 'A',
              },
            ]);
            return {
              observation: JSON.stringify(rows[0]),
              expected: '6 pcs, 60.300 / 58.950, fine 53.998, 300.00',
              database: rows,
              downstream: { itemOpeningReads: 'ITM_OPBL' },
            };
          } finally {
            await exec(
              ctx,
              `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEM.code,
            );
            await exec(
              ctx,
              `DELETE FROM "ITM_OPBL" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEM.code,
            );
            await exec(
              ctx,
              `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"=$2`,
              ITEM.code,
            );
          }
        });
      },
    ),
    C(
      'implicit-datasets.count-and-write-nothing',
      'T07',
      'mutation',
      'BtmSchm.cs:2169, :3003, :4116; Q1/Q8 decided 2026-11-22 by the architect (owner may override): in the one-database web tags, open orders and open approvals already continue into the next year, so these buttons count and write nothing',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ next }) => {
          const onHand = async () =>
            (
              await ctx.rows(
                `SELECT count(*)::int n FROM "BAR_DETL" b WHERE b.tenant_id=$1
                    AND coalesce((SELECT sum(CASE WHEN m."ITM_SIGN"='+' THEN coalesce(m."VCH_SRNO",1) ELSE -coalesce(m."VCH_SRNO",1) END)
                                    FROM "MAIN_STOCK" m WHERE m.tenant_id=b.tenant_id AND m."CO_CODE"=b."CO_CODE" AND m."LC_CODE"=b."LC_CODE"
                                     AND m."TAG_NO"=b."TAG_NO" AND coalesce(m."VCH_SRNO",0)=coalesce(b."VCH_SRNO",0)
                                     AND coalesce(m."IT_CODE",'')=coalesce(b."IT_CODE",'')),0) > 0`,
              )
            )[0].n;
          const before = await onHand();
          await openScreen(page);
          const seen = [];
          for (const label of ['Tag Stock', 'Sales Order', 'Approval']) {
            const { dialogs, response } = await runDataset(page, label);
            assert.deepEqual(dialogs, [CONFIRM]);
            assert.equal(response.status(), 200, await response.text());
            const body = await response.json();
            assert.equal(body.rows, 0);
            assert.equal(typeof body.open, 'number');
            await page.getByText(COMPLETE, { exact: true }).waitFor();
            seen.push(`${label} open ${body.open}`);
          }
          const rows = await ctx.rows(
            `SELECT (SELECT count(*) FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_YEAR"=$2)::int
                  + (SELECT count(*) FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2)::int
                  + (SELECT count(*) FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_YEAR"=$2)::int n`,
            next[0].year,
          );
          assert.equal(rows[0].n, 0);
          assert.equal(await onHand(), before, 'the tag stock is unchanged');
          return {
            observation: seen.join('; '),
            expected: 'Process Are Complete...., nothing written, tag stock unchanged',
            database: { rowsInTransferYear: rows[0].n },
            downstream: { tagOnHand: before },
          };
        });
      },
    ),
    C(
      'ac.rule.having-offset-money-vs-gold',
      'T03',
      'mutation',
      'BtmSchm.cs:2786 HAVING drops 50.00 Cr + 50.000 gold Dr; Q2 decided 2026-11-22 by the architect (owner may override): the web carries both',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async ({ current, clDate }) => {
          await exec(
            ctx,
            `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MAIN_GR") VALUES ($1,'01','01',$2,$3,'1')`,
            PARTY.code,
            PARTY.name,
          );
          try {
            await exec(
              ctx,
              `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT","DATA_TYPE","VCH_TYPE","LEDR_KEY")
               VALUES ($1,'01','01',$2,'JV','BT8',$3::date,$4,50,0,'A','',0,'A','JV','E2E-BT-8'),
                      ($1,'01','01',$2,'JV','BT9',$3::date,$4,0,0,'G','-',50,'A','JV','E2E-BT-9')`,
              current,
              clDate,
              PARTY.code,
            );
            await openScreen(page);
            const { response } = await runDataset(page, 'Ac Balance');
            assert.equal(response.status(), 200, await response.text());
            const rows = await ctx.rows(
              `SELECT "OP_AMT"::float amt,"OP_SIGN" sg,"FINE_BAL"::float g,"FINE_SIGN" gs FROM "OP_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2`,
              PARTY.code,
            );
            assert.deepEqual(rows, [{ amt: 50, sg: 'C', g: 50, gs: 'D' }]);
            return {
              observation: JSON.stringify(rows),
              expected: '50.00 C and gold 50.000 D carried',
              database: rows,
              downstream: { rows: rows.length },
            };
          } finally {
            await dropParty(ctx);
          }
        });
      },
    ),
    C(
      'keyboard.confirmation-text-verbatim',
      'T17',
      'read-only',
      'BtmSchm.cs:2729 confirmation; :2755 completion',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async () => {
          await openScreen(page);
          const { dialogs, response } = await runDataset(page, 'Item Stock');
          assert.equal(response.status(), 200, await response.text());
          assert.deepEqual(dialogs, [CONFIRM]);
          await page.getByText(COMPLETE, { exact: true }).waitFor();
          return {
            observation: `${dialogs[0]} / ${COMPLETE}`,
            expected: `${CONFIRM} / ${COMPLETE}`,
          };
        });
      },
    ),
    C(
      'keyboard.tab-order-and-enter',
      'T17',
      'read-only',
      'BtmSchm.cs:1373, :1310, :1341, :1421, :1546 tab order; Enter on a button opens the confirmation (:2926)',
      async (ctx) => {
        const { page } = await ctx.session();
        return withNextYears(ctx, page, 1, async () => {
          await openScreen(page);
          await page.waitForFunction(() => document.activeElement?.textContent === 'Ac Balance');
          const order = ['Ac Balance'];
          for (let i = 0; i < 6; i += 1) {
            await page.keyboard.press('Tab');
            order.push(await page.evaluate(() => document.activeElement?.textContent ?? ''));
          }
          assert.deepEqual(order, [...LITE, 'Exit', 'Cancel']);
          await button(page, 'Item Stock').focus();
          const dialogs = [];
          page.removeAllListeners('dialog');
          page.on('dialog', (d) => {
            dialogs.push(d.message());
            void d.dismiss();
          });
          await page.keyboard.press('Enter');
          await page.waitForTimeout(500);
          page.removeAllListeners('dialog');
          page.on('dialog', (d) => void d.accept());
          assert.deepEqual(dialogs, [CONFIRM]);
          return {
            observation: order.join(' → '),
            expected: [...LITE, 'Exit', 'Cancel'].join(' → '),
          };
        });
      },
    ),
    C(
      'keyboard.esc-closes',
      'T17',
      'read-only',
      'BtmSchm.cs:2692-2695 KeyCode 27 → Close (:2662)',
      async (ctx) => {
        const { page } = await ctx.session();
        await page.goto('/dashboard');
        await openScreen(page);
        const left = await escLeavesWithNoFocus(page, { heading: 'Balance TrFr', path: PATH });
        return { observation: `left to ${left.leftTo}`, expected: 'the page closes' };
      },
    ),
    notApplicable(
      'children',
      'T05',
      'BtmSchm has no grid; the stone rows the desktop copies follow the tag and approval carries, which are implicit in the web (Q1/Q8 decided 2026-11-22)',
      'no child rows are written by the web carry',
    ),
    notApplicable(
      'delete',
      'T10',
      'BtmSchm.cs:2720-2723 BtnDelete_Click has an empty body',
      'the desktop form deletes nothing; a re-run replaces (rerun.ac-balance-replaces)',
    ),
    notApplicable(
      'lookup',
      'T04',
      'study §Screen: the form has no lookup control',
      'BtmSchm has no lookup, search or dependent selector',
    ),
    notApplicable(
      'print',
      'T16',
      'BtmSchm.cs:2699-2701 empty BtnPrint_Click; 0 report templates',
      'the desktop form prints nothing',
    ),
    notApplicable(
      'master.ac-mast-copy',
      'T07',
      'BtmSchm.cs:2840 copies missing AC_MAST / item masters into the next-year database',
      'the web keeps one database across years (D7); the masters already exist',
    ),
    ...nextYearCases,
    ...faultCases,
  ],
};
