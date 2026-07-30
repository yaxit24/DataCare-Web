/**
 * The authoritative settings inventory: every persisted column of CO_SET and CO_SET_NEW.
 *
 * Generated from information_schema, NOT from the display catalog. That separation is the point: the
 * previous surface exposed 55 curated CO_SET keys and could not reach CO_SET_NEW at all, so a catalog-
 * derived denominator would have reported itself as complete. The parity gate divides by THIS list.
 *
 * Excludes tenant_id and row_id (storage bookkeeping). CO_CODE is retained because it is part of the
 * row identity and must never be offered as an editable setting — `SETTING_IDENTITY_COLUMNS` marks it.
 */
export type SettingTable = 'CO_SET' | 'CO_SET_NEW';

export interface SettingColumn {
  key: string;
  table: SettingTable;
  /** Storage shape from information_schema — drives the typed control and the write cast. */
  storage: 'text' | 'number' | 'date';
  /** Real character maximum for text columns; 0 when not applicable. */
  maxLength: number;
}

/** Columns that identify the row rather than configure behaviour. Never editable. */
export const SETTING_IDENTITY_COLUMNS = new Set(['CO_CODE']);

export const SETTING_COLUMNS: readonly SettingColumn[] = [
  // --- CO_SET (60 columns) ---
  { key: 'THEME', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'TAG_RPT', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'FINE_STK_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'RATE_MAST_OPEN', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LBR_RATE_GEN', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'VB_IMPORT', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'SL_ROW_CHANGE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'DHRN_INT_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'INT_YEAR_DAYS', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'OP_DHRN', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'INT_DAY', table: 'CO_SET', storage: 'text', maxLength: 1 },
  { key: 'HELP_SERCH', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'WEIGHT_PORT', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LDR_SUMM', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'SL_AMT_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'SMS_LINK', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'OP_LOAN', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LOAN_INT_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'TRAD_FINE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LBR_ROF', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'REMINDER_OPEN', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'ITM_RATE_ROF', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'ADMIN_SMS', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'CUST_SMS', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'PURC_WITH_LBR', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'DHIRN_COMPOUND', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'GRID_SCROLL', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'STK_RPT_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'TOUCH_AUTO_SAVE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'PAN_CARD_VAL', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'DHRN_PRC', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'DUP_PRINT', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'TAX_CODE', table: 'CO_SET', storage: 'text', maxLength: 2 },
  { key: 'IP_WITH_PC', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'CO_STK_MERGE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'STK_RPT_VIEW', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'PR_AMT_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'CARD_COM_ADJ', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'CASH_PURC_AC', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'EMP_CODE_MANDATORY', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'STOCK_RPT_TYPE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LAST_DAY_LOCK', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'CASH_LIMIT', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'DHRN_WAPP', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'SCHM_WAPP', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LEDR_BILL_COL', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'ALL_ROF_REMOVE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'CO_CODE', table: 'CO_SET', storage: 'text', maxLength: 2 },
  { key: 'BTN_NAME', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'COUNTRY_CODE', table: 'CO_SET', storage: 'text', maxLength: 4 },
  { key: 'LBR_TYPE', table: 'CO_SET', storage: 'text', maxLength: 1 },
  { key: 'AC_LC_CODE_LEN', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'LOCK_DATE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'TAX_ROF', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'RATE_PAR', table: 'CO_SET', storage: 'text', maxLength: 1 },
  { key: 'OZ_CON_VAL', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'FX_RATE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'FX_CODE', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'COUNTRY_ID', table: 'CO_SET', storage: 'text', maxLength: 255 },
  { key: 'MFG_ONE_FORM', table: 'CO_SET', storage: 'text', maxLength: 1 },
  // --- CO_SET_NEW (70 columns) ---
  { key: 'CO_CODE', table: 'CO_SET_NEW', storage: 'text', maxLength: 2 },
  { key: 'COUNTER_STK', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'APR_IMG_PRINT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'BILL_PROFIT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'BRANCH_ALL_AC_SHOW', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'COUNTRY_ID', table: 'CO_SET_NEW', storage: 'text', maxLength: 3 },
  { key: 'CUR_DAY_POSTING', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'DEFAULT_REMINDER', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'DESIGN_HELP', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'DHRN_IMG_PRINT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'EMP_AS_USER', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'ESTMATE_BANK_LOCK', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'ESTMATE_TAX', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'FONT_CHANGE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'FONT_NAME', table: 'CO_SET_NEW', storage: 'text', maxLength: 25 },
  { key: 'FONT_SIZE', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'FONT_STYLE_TYPE', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'F_DISC_DATE', table: 'CO_SET_NEW', storage: 'date', maxLength: 0 },
  { key: 'GRID_ROW_HIGHT', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'ITM_FINE_LOCK', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'ITM_WITH_LOT_STK', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'KR_DESIGN_IMG_PRINT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'LBR_WITH_GHT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'LEN_IMG_PATH', table: 'CO_SET_NEW', storage: 'text', maxLength: 250 },
  { key: 'MAIN_FONT_CHANGE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'MOBILE_HELP', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'NEGATIVE_STK_SALE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OLD_GOLD_TYPE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OLD_PURC_TOUCH', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OPBL_TRFR_BTN', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'ORD_IMG_PRINT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'ORD_TAG_STK_LESS', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OS_BILL_ORNA_ISU', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OS_BILL_SMS', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OS_FINE_INT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'OTH_ITM_WT_REMOVE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'PRINT_FORM_BTN', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'PROFIT_RPT_TYPE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'PR_RATE_ROF', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'PR_TDS_TAX', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'PURC_LOT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'PURC_WITH_HMTAX', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'QR_CODE_GEN', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'RPT_TOT_SHOW', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SALES_WITH_HMTAX', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SILVER_THREE_DIGIT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SL_BILL_IMG', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SL_MRP_TAX_REVERC', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SL_NWT_LOCK', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SL_TAG_WT_DIFF', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'SL_TDS_TAX', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'STK_LMIT_WITH_DESIGN', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'TAG_AUTO_PRINT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'TAG_ENTRY_DESIGN_GEN', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'TAG_VCH_AUTO_SAVE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'TILE_MENU', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'TOT_AMT_ROF', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'TOT_FINE_STK_TYPE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'T_DISC_DATE', table: 'CO_SET_NEW', storage: 'date', maxLength: 0 },
  { key: 'USER_KR_TOUCH_HIDE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'VCH_DESC_HELP_LENT', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'WAPP_DELAY', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'WAPP_IMG_GWT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'WAPP_SL_PRINT', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'WAP_DELAY', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'WEB_IMAGE', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'WEB_PATH', table: 'CO_SET_NEW', storage: 'text', maxLength: 50 },
  { key: 'WH_BILL_IMG', table: 'CO_SET_NEW', storage: 'text', maxLength: 1 },
  { key: 'YEAR_GOLD_SL', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
  { key: 'YEAR_SILVER_SL', table: 'CO_SET_NEW', storage: 'number', maxLength: 0 },
] as const;

/** Exact per-table counts, asserted by settingsInventory.test.ts so the denominator cannot drift. */
export const SETTING_COLUMN_COUNTS = { CO_SET: 60, CO_SET_NEW: 70, total: 130 } as const;

/** Configurable settings = every column except row identity. */
export const CONFIGURABLE_SETTINGS: readonly SettingColumn[] = SETTING_COLUMNS.filter(
  (c) => !SETTING_IDENTITY_COLUMNS.has(c.key),
);
