/**
 * AC_GROUP rows shipped in the desktop installer year database (Next24.BAK).
 *
 * These are provisioning data, not a migration: seedCompany calls seedDesktopAccountGroups only in the call
 * that inserts the company's CO_MAST row, so an existing tenant's chart is never rewritten. MS_YEAR.cs:1504-1595 uses company 01 as the same source
 * when the desktop creates another company.
 */
export const DESKTOP_ACCOUNT_GROUPS = [
  ['00', 'CAPITAL ACCOUNT', '1', 'SOURCES OF FUNDS'],
  ['01', 'PROPRITOR CAPITAL ACCOUNT', '1', 'SOURCES OF FUNDS'],
  ['02', 'C.C. ACCOUNT', '1', 'SECURED LOANS'],
  ['03', 'SECURED LOAN', '1', 'SECURED LOANS'],
  ['04', 'UNSECURED LOAN', '1', 'LOANS FUNDS'],
  ['05', 'VEPARI', '1', 'CURRENT LIABILITIES'],
  ['06', 'SUNDRY CREDITORS LABOUR', '1', 'CURRENT LIABILITIES'],
  ['07', 'DEPOSIT - LIABILITIES', '1', 'CURRENT LIABILITIES'],
  ['10', 'KARIGAR SUNDRY CR', '1', 'CURRENT LIABILITIES'],
  ['11', 'PROVISION', '1', 'PROVISION AND OTHERS'],
  ['12', 'TAX LIABLITIES', '1', 'PROVISION AND OTHERS'],
  ['13', 'FIXED ASSETS', '2', 'APPLICATION OF FUNDS'],
  ['14', 'INVESTMENT', '2', 'INVESTMENTS'],
  ['15', 'LOANS AND ADVANCES ASSETS', '2', 'LOANS AND ADVANCES'],
  ['16', 'DEPOSITS - ASSETS', '2', 'LOANS AND ADVANCES'],
  ['17', 'CLOSING STOCK ASSETS', '2', 'CURRENT ASSETS'],
  ['18', 'CURRENT ASSETS', '2', 'CURRENT ASSETS'],
  ['19', 'SUNDRY D/R - CARDS', '2', 'CURRENT ASSETS'],
  ['20', 'SUNDRY DEBTORS', '2', 'CURRENT ASSETS'],
  ['21', 'CASH ON HAND A/C', '2', 'CASH AND BANK BALANCES'],
  ['22', 'BANK CURRENT A/C', '2', 'CASH AND BANK BALANCES'],
  ['23', 'BANK SAVINGS A/C.', '2', 'CASH AND BANK BALANCES'],
  ['24', 'SALES : (TRADING)', '3', 'SALES AND SERVICES'],
  ['25', 'SALES', '3', 'SALES AND SERVICES'],
  ['27', 'CLOSING STOCK TRADING A/C', '3', 'INCREASE/(DECREASE) IN STOCK'],
  ['28', 'OPENING STOCK', '4', 'PURCHASE AND OTHER EXPENSES'],
  ['29', 'PURCHASE : (TRADING)', '4', 'PURCHASE AND OTHER EXPENSES'],
  ['30', 'PURCHASE', '4', 'PURCHASE AND OTHER EXPENSES'],
  ['35', 'PROFIT/LOSS A/C', '4', 'PURCHASE AND OTHER EXPENSES'],
  ['40', 'INDIRECT INCOME', '5', 'INDIRECT INCOME'],
  ['41', 'DIRECT INCOME.', '5', 'SALES AND SERVICES'],
  ['45', 'ADMINISTRATIVE - EXPS', '6', 'EXPENSES'],
  ['46', 'EXPENSES : (DIRECT)', '6', 'PURCHASE AND OTHER EXPENSES'],
  ['47', 'EXPENSES (INDIRECT)', '6', 'EXPENSES'],
  ['50', 'INTEREST', '6', 'EXPENSES'],
] as const;

type Absent = (table: string, where: string, ...parameters: unknown[]) => Promise<boolean>;

/** Insert only missing rows so this path is safe for provisioning retries and never rewrites a company. */
export async function seedDesktopAccountGroups(
  tx: any,
  absent: Absent,
  tenantId: string,
  coCode: string,
): Promise<void> {
  for (const [code, name, mainGroup, subGroup] of DESKTOP_ACCOUNT_GROUPS) {
    if (await absent('AC_GROUP', '"CO_CODE"=$2 AND "AC_GR"=$3', coCode, code)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_GROUP"(tenant_id,"CO_CODE","AC_GR","AC_GR_NAME","AC_MAIN_GR","AC_SUB_GR","MAIN_USER","USER_SHOW_GROUP")
         VALUES ($1,$2,$3,$4,$5,$6,NULL,'Y')`,
        tenantId,
        coCode,
        code,
        name,
        mainGroup,
        subGroup,
      );
    }
  }
}
