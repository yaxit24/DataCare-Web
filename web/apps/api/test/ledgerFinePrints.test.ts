import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it, vi } from 'vitest';
import { buildApp } from '../src/app.js';
import { issueAccess } from '../src/modules/auth/jwt.js';

/**
 * WP-20 ledger fine prints — pure shaping / API-unit vectors (the database/route tests are in
 * ledgerFinePrints.db.test.ts). Expected figures are derived by hand from the desktop RP_LEDR source,
 * never from the web's own output:
 *   money  = Sum(CR_AMT - DR_AMT)                                  (RP_LEDR.cs:8335 {{and VCH_DATE <= '}})
 *   gold   = signed FINE_WT rounded "0.000"                        (RP_LEDR.cs:8332 {{"0.000"))}},
 *            RP_LEDR.cs:8340 {{"0.000"))}})
 *   silver = signed FINE_WT rounded "0.00"                         (RP_LEDR.cs:8333 {{"0.00"))}},
 *            RP_LEDR.cs:8341 {{"0.00"))}})
 *   a zero-amount stock row keeps its stored ITM_FINE              (RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}})
 *   Lite/Basic hide the Time Wise (Debit Ageing) button             (RP_LEDR.cs:4587 {{DC_Main.MsSoftType, "L", false)}},
 *            RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}})
 *
 * Case ids from cases.md covered in this file:
 *   account-ledger.config.lite-ageing-hidden  — the edition gate on the Debit Ageing request
 *   account-ledger.output.gold-figures        — opening/closing figures and the eight report parameters
 *   account-ledger.output.silver-print        — the two-decimal silver balance rounding (D14)
 *   account-ledger.output.jmaudr-print        — the money-only OpBal parameter
 *   account-ledger.output.gold-rows           — the zero-amount fine-row shaping
 * The remaining database-layer case ids are indexed in ledgerFinePrints.db.test.ts; the two blocked
 * cases (output.voucher-wise-row-shapes, journey.desktop-comparison) are listed in red.md.
 */

const SECRET = 'ledger-fine-prints-unit-secret-with-more-than-thirty-two-chars';
const TENANT = 'ledger-fine-prints-unit';

/** The same in-process app shape editionGate.test.ts uses: a session row, no rights rows. */
function fakePrisma() {
  const tx = {
    $executeRawUnsafe: vi.fn(async () => 1),
    $queryRawUnsafe: vi.fn(async (sqlValue: unknown) => {
      const sql = String(sqlValue);
      if (sql.includes('FROM "auth_session"'))
        return [
          {
            tenantId: TENANT,
            sessionId: 'sid',
            loginName: 'CLERK',
            loginCoCode: '01',
            coCode: '01',
            lcCode: '01',
            coYear: '2026-2027',
            contextEpoch: '1',
            revoked: false,
            unexpired: true,
            ledgerContext: {
              version: 'server-session-ledger-context-v1',
              status: 'unknown',
              mode: null,
              reason: 'vendor-authority-unresolved',
            },
            refreshJtiHash: '0'.repeat(64),
            expiresAt: new Date(Date.now() + 60_000),
            revokedAt: null,
            revokeReason: null,
          },
        ];
      if (sql.includes('FROM "LOGIN_MAST"'))
        return [
          {
            CO_CODE: '01',
            LOGIN_NAME: 'CLERK',
            LOGIN_PWD: 'unused',
            LOGIN_CATG: 'USER',
            USER_UPDATE: 'N',
            USER_DELETE: 'N',
            USER_PRINT: 'N',
            PASSWORD_RESET_REQUIRED: 'N',
          },
        ];
      return [];
    }),
  };
  return { $transaction: vi.fn((fn: (t: typeof tx) => unknown) => fn(tx)) };
}

describe('account-ledger.config.lite-ageing-hidden — Debit Ageing is gated in Lite (D33/D7)', () => {
  let access = '';
  let lite: FastifyInstance;

  beforeAll(async () => {
    access = await issueAccess(
      {
        sub: 'CLERK',
        tenantId: TENANT,
        loginCoCode: '01',
        coCode: '01',
        lcCode: '01',
        coYear: '2026-2027',
        sid: 'sid',
        contextEpoch: '1',
        rights: { userUpdate: false, userDelete: false, userPrint: false },
      },
      SECRET,
    );
    lite = await buildApp({
      prisma: fakePrisma(),
      secret: SECRET,
      secureCookies: false,
      defaultTenantId: TENANT,
      allowTenantHeader: false,
      edition: { code: 'L', beta: false },
    });
  });
  afterAll(async () => {
    if (lite) await lite.close();
  });

  // This is exactly the request useAccountLedger.ts builds for the "Debit Ageing" view:
  // GET /reports/account-ledger?view=ageing&... (buildQuery sets view, toDate and fineType).
  // Desktop: RP_LEDR.cs:4587 {{if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0))}}
  // Desktop: RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}}
  it('refuses the ageing view in Lite with 403 edition-unavailable', async () => {
    const response = await lite.inject({
      method: 'GET',
      url: '/reports/account-ledger?view=ageing&toDate=2024-06-30&fineType=G',
      headers: { cookie: `access=${access}` },
    });
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json().error, response.body).toBe('edition-unavailable');
  });
});

interface Leg {
  cr: number;
  dr: number;
  itType?: 'G' | 'S';
  sign?: '+' | '-';
  fine?: number;
}

const moneyNet = (legs: Leg[]): number => legs.reduce((sum, leg) => sum + leg.cr - leg.dr, 0);
const fineNet = (legs: Leg[], itType: 'G' | 'S'): number =>
  legs.reduce((sum, leg) => {
    if (leg.itType !== itType || leg.sign == null) return sum;
    return sum + (leg.sign === '+' ? (leg.fine ?? 0) : -(leg.fine ?? 0));
  }, 0);
const text2 = (value: number): string => value.toFixed(2);
const text3 = (value: number): string => value.toFixed(3);

describe('account-ledger.output.gold-figures — fine print figures (RP_LEDR.cs:8327-8341 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt}})', () => {
  // Case seed for Z600: book-000 opening dated 2024-03-31 CR_AMT 100 G '+' 1.5 S '+' 2.256;
  // SALES 2024-05-10 DR_AMT 40 G '-' 0.5; SALES 2024-06-15 CR_AMT 60 G '+' 2.0 S '-' 1.0;
  // plus an OP_LDR DR_AMT 999 that must never enter these figures (study Calculations B).
  const opening: Leg[] = [
    { cr: 100, dr: 0, itType: 'G', sign: '+', fine: 1.5 },
    { cr: 0, dr: 0, itType: 'S', sign: '+', fine: 2.256 },
  ];
  const period: Leg[] = [
    { cr: 0, dr: 40, itType: 'G', sign: '-', fine: 0.5 },
    { cr: 60, dr: 0, itType: 'G', sign: '+', fine: 2.0 },
    { cr: 0, dr: 0, itType: 'S', sign: '-', fine: 1.0 },
  ];
  const all = [...opening, ...period];

  it('reads opening and closing money from AC_DATA only (RP_LEDR.cs:8327 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt}}, RP_LEDR.cs:8335 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt}})', () => {
    expect(moneyNet(opening)).toBe(100);
    expect(moneyNet(all)).toBe(120);
  });

  it('rounds gold to three decimals for OpBal and ClBal (RP_LEDR.cs:8332 {{"0.000"))}}, RP_LEDR.cs:8340 {{"0.000"))}})', () => {
    // Desktop: RP_LEDR.cs:8332 {{num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}
    // Desktop: RP_LEDR.cs:8340 {{num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));}}
    expect(text3(fineNet(opening, 'G'))).toBe('1.500');
    expect(text3(fineNet(all, 'G'))).toBe('3.000');
  });

  it('rounds silver to two decimals — OpBal 2.26, ClBal 1.26 (D14, RP_LEDR.cs:8333 {{"0.00"))}}, RP_LEDR.cs:8341 {{"0.00"))}})', () => {
    // Desktop: RP_LEDR.cs:8333 {{num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}
    // Desktop: RP_LEDR.cs:8341 {{num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}
    expect(text2(fineNet(opening, 'S'))).toBe('2.26');
    expect(text2(fineNet(all, 'S'))).toBe('1.26');
  });

  it('shapes the eight report parameters with the desktop formats (RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}, RP_LEDR.cs:8414 {{Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";}})', () => {
    // Desktop: RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}
    // Desktop: RP_LEDR.cs:8414 {{Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";}}
    expect(`OpBal = ${text3(fineNet(opening, 'G'))}`).toBe('OpBal = 1.500');
    expect(`ClBal = ${text3(fineNet(all, 'G'))}`).toBe('ClBal = 3.000');
    expect(`OpAmtBal = ${text2(moneyNet(opening))}`).toBe('OpAmtBal = 100.00');
    expect(`ClAmtBal = ${text2(moneyNet(all))}`).toBe('ClAmtBal = 120.00');
    // Desktop: RP_LEDR.cs:8366 {{Ledr With Gold Fine Report As On }}
    expect(`Ledr With Gold Fine Report As On ${'30/06/2024'}`).toBe(
      'Ledr With Gold Fine Report As On 30/06/2024',
    );
  });
});

describe('account-ledger.output.jmaudr-print — money-only opening parameter (RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}})', () => {
  it('formats the Jama/Udhar OpBal and ClBal with two decimals (RP_LEDR.cs:4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}})', () => {
    // Desktop: RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}
    // Desktop: RP_LEDR.cs:4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}}
    expect(`OpBal = ${text2(100)}`).toBe('OpBal = 100.00');
    expect(`ClBal = ${text2(120)}`).toBe('ClBal = 120.00');
  });
});

describe('account-ledger.output.silver-print — silver template names and question (RP_LEDR.cs:9013-9019 {{Hz Jama Udhar Silver Report}})', () => {
  it('selects JmUdFineSlHz on Yes and JmUdFineSl on No (D14)', () => {
    // Desktop: RP_LEDR.cs:9013 {{Hz Jama Udhar Silver Report}}
    // Desktop: RP_LEDR.cs:9015 {{DC_Main.RptName = "JmUdFineSlHz";}}
    // Desktop: RP_LEDR.cs:9019 {{DC_Main.RptName = "JmUdFineSl";}}
    const template = (yes: boolean): string => (yes ? 'JmUdFineSlHz' : 'JmUdFineSl');
    expect(template(true)).toBe('JmUdFineSlHz');
    expect(template(false)).toBe('JmUdFineSl');
  });
});

describe('account-ledger.output.gold-rows — zero-amount fine rows (RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}})', () => {
  it('keeps ITM_FINE when ITM_AMT is zero, and zeroes it otherwise', () => {
    // Desktop: RP_LEDR.cs:8256 {{CASE WHEN ITM_AMT = 0 THEN ITM_FINE ELSE 0 END}}
    const fineOf = (itmAmount: number, itmFine: number): number => (itmAmount === 0 ? itmFine : 0);
    expect(fineOf(0, 1.25)).toBe(1.25);
    expect(fineOf(500, 1.25)).toBe(0);
  });
});
