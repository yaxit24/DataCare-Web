import { withTxBudget } from '../shared/txBudget.js';

/**
 * Company settings provisioning — `CO_SET_NEW`, the second company-configuration surface.
 *
 * Desktop (MS_YEAR.cs:1530-1531 and 1569-1570) provisions it by cloning an existing company:
 *   DELETE FROM CO_SET_NEW WHERE CO_CODE = '<new>'
 *   INSERT INTO CO_SET_NEW (CO_CODE, ...68 columns...)
 *     SELECT '<new>', ...same... FROM CO_SET_NEW WHERE CO_CODE = '<MsOldCoCode>'   -- copy-company
 *                                                    ... WHERE CO_CODE = '01'      -- template
 * The same block also clones CO_SET, BOOK_DATA, BOOK_DETL and BAL_GR, so this is company
 * provisioning rather than a settings editor.
 *
 * DELIBERATE DEVIATION, recorded rather than hidden: the desktop DELETE is unconditional because it
 * runs while creating a company. The web has no create-company endpoint yet, so this runs from year
 * creation and therefore only provisions when the company has NO CO_SET_NEW row. Cloning
 * unconditionally there would wipe a live company's configuration every time a new year is opened.
 * When a create-company workflow is added, it should call this with `replace: true`.
 */
export const CO_SET_NEW_COLUMNS = [
  'COUNTER_STK',
  'ESTMATE_BANK_LOCK',
  'OLD_PURC_TOUCH',
  'NEGATIVE_STK_SALE',
  'SL_NWT_LOCK',
  'WH_BILL_IMG',
  'PROFIT_RPT_TYPE',
  'WEB_IMAGE',
  'WEB_PATH',
  'QR_CODE_GEN',
  'OS_BILL_SMS',
  'SL_BILL_IMG',
  'TOT_FINE_STK_TYPE',
  'OPBL_TRFR_BTN',
  'TAG_VCH_AUTO_SAVE',
  'DESIGN_HELP',
  'SALES_WITH_HMTAX',
  'TILE_MENU',
  'PR_RATE_ROF',
  'LEN_IMG_PATH',
  'SL_TDS_TAX',
  'PR_TDS_TAX',
  'OS_FINE_INT',
  'PURC_WITH_HMTAX',
  'SL_TAG_WT_DIFF',
  'WAPP_DELAY',
  'COUNTRY_ID',
  'WAPP_SL_PRINT',
  'BILL_PROFIT',
  'OLD_GOLD_TYPE',
  'TAG_ENTRY_DESIGN_GEN',
  'ORD_IMG_PRINT',
  'OS_BILL_ORNA_ISU',
  'PURC_LOT',
  'MOBILE_HELP',
  'PRINT_FORM_BTN',
  'FONT_CHANGE',
  'FONT_SIZE',
  'FONT_NAME',
  'FONT_STYLE_TYPE',
  'GRID_ROW_HIGHT',
  'TOT_AMT_ROF',
  'ESTMATE_TAX',
  'TAG_AUTO_PRINT',
  'RPT_TOT_SHOW',
  'DEFAULT_REMINDER',
  'VCH_DESC_HELP_LENT',
  'ORD_TAG_STK_LESS',
  'BRANCH_ALL_AC_SHOW',
  'SL_MRP_TAX_REVERC',
  'EMP_AS_USER',
  'WAPP_IMG_GWT',
  'YEAR_GOLD_SL',
  'YEAR_SILVER_SL',
  'F_DISC_DATE',
  'T_DISC_DATE',
  'DHRN_IMG_PRINT',
  'LBR_WITH_GHT',
  'APR_IMG_PRINT',
  'OTH_ITM_WT_REMOVE',
  'SILVER_THREE_DIGIT',
  'KR_DESIGN_IMG_PRINT',
  'ITM_WITH_LOT_STK',
  'USER_KR_TOUCH_HIDE',
  'CUR_DAY_POSTING',
  'MAIN_FONT_CHANGE',
  'STK_LMIT_WITH_DESIGN',
  'ITM_FINE_LOCK',
] as const;

export const CO_SET_NEW_TEMPLATE_CO_CODE = '01';

export interface ProvisionCompanySettingsOptions {
  /** Company to copy configuration from; desktop uses MsOldCoCode, else the '01' template. */
  sourceCoCode?: string;
  /** Clear existing rows first (desktop copy-company behaviour). Default false: provision only. */
  replace?: boolean;
}

/**
 * Ensure `CO_SET_NEW` exists for a company by cloning the desktop column set.
 * Returns the number of rows written (0 when a row already exists, or when the source has none).
 */
export async function provisionCompanySettingsTx(
  tx: any,
  tenantId: string,
  coCode: string,
  options: ProvisionCompanySettingsOptions = {},
): Promise<number> {
  const source = (options.sourceCoCode ?? CO_SET_NEW_TEMPLATE_CO_CODE).trim();
  const q = (c: string): string => `"${c}"`;
  const cols = CO_SET_NEW_COLUMNS.map(q).join(',');

  if (options.replace) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenantId,
      coCode,
    );
  } else {
    const existing: Array<{ n: number }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenantId,
      coCode,
    );
    if ((existing[0]?.n ?? 0) > 0) return 0;
  }

  // Cloning the source company's own values; no value is synthesised here. When the source has no
  // row the INSERT..SELECT writes nothing, exactly as the desktop statement does.
  return (await tx.$executeRawUnsafe(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE",${cols})
       SELECT $1::text,$2::text,${cols} FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$3`,
    tenantId,
    coCode,
    source,
  )) as number;
}

/** Convenience wrapper for callers outside a transaction. */
export async function provisionCompanySettings(
  prisma: any,
  tenantId: string,
  coCode: string,
  options: ProvisionCompanySettingsOptions = {},
): Promise<number> {
  return withTxBudget(prisma, tenantId, 'heavy', (tx: any) =>
    provisionCompanySettingsTx(tx, tenantId, coCode, options),
  );
}
