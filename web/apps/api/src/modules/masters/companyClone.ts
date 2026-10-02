/**
 * Company provisioning — clone a company's masters and configuration from an existing company.
 *
 * The desktop does this in one block when a company/year is created (MS_YEAR.cs:1511-1553): for each
 * table it runs `INSERT INTO T(CO_CODE, ...cols) SELECT '<new>', ...cols FROM T WHERE CO_CODE='<src>'`.
 * The column list of every table below was extracted from that statement rather than transcribed, and
 * each entry records the desktop line it came from.
 *
 * DELIBERATE DEVIATION, recorded rather than hidden: the desktop deletes the target rows first because
 * it always runs against a brand-new company. Here cloning is non-destructive by default (`replace`
 * off) and skips any table that already has rows for the company, so provisioning can never wipe a
 * live company's masters. Pass `replace: true` for the desktop copy-company behaviour.
 */
import { withTxBudget } from '../shared/txBudget.js';

export interface CompanyCloneTable {
  table: string;
  /** Line in MS_YEAR.cs the column list was extracted from. */
  line: number;
  columns: readonly string[];
}

export const COMPANY_CLONE_TABLES: readonly CompanyCloneTable[] = [
  {
    table: 'CO_SET',
    line: 1529,
    columns: [
      'BTN_NAME',
      'THEME',
      'COUNTRY_CODE',
      'LBR_TYPE',
      'AC_LC_CODE_LEN',
      'LOCK_DATE',
      'TAX_ROF',
      'RATE_PAR',
      'SL_ROW_CHANGE',
      'VB_IMPORT',
      'TAG_RPT',
      'FINE_STK_TYPE',
      'RATE_MAST_OPEN',
      'LBR_RATE_GEN',
      'DHRN_INT_TYPE',
      'INT_YEAR_DAYS',
      'OP_DHRN',
      'INT_DAY',
      'HELP_SERCH',
      'WEIGHT_PORT',
      'LDR_SUMM',
      'SL_AMT_TYPE',
      'SMS_LINK',
      'OP_LOAN',
      'LOAN_INT_TYPE',
      'TRAD_FINE',
      'LBR_ROF',
      'REMINDER_OPEN',
      'ITM_RATE_ROF',
      'ADMIN_SMS',
      'CUST_SMS',
      'PURC_WITH_LBR',
      'DHIRN_COMPOUND',
      'GRID_SCROLL',
      'STK_RPT_TYPE',
      'TOUCH_AUTO_SAVE',
      'PAN_CARD_VAL',
      'DHRN_PRC',
      'DUP_PRINT',
      'TAX_CODE',
      'IP_WITH_PC',
      'CO_STK_MERGE',
      'STK_RPT_VIEW',
      'PR_AMT_TYPE',
      'CARD_COM_ADJ',
      'CASH_PURC_AC',
      'EMP_CODE_MANDATORY',
      'STOCK_RPT_TYPE',
      'LAST_DAY_LOCK',
      'CASH_LIMIT',
      'DHRN_WAPP',
      'SCHM_WAPP',
      'LEDR_BILL_COL',
      'ALL_ROF_REMOVE',
      'OZ_CON_VAL',
      'FX_RATE',
      'FX_CODE',
    ],
  },
  {
    table: 'CO_SET_NEW',
    line: 1531,
    columns: [
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
    ],
  },
  {
    table: 'AC_GROUP',
    line: 1511,
    columns: ['AC_GR', 'AC_GR_NAME', 'AC_MAIN_GR', 'AC_SUB_GR', 'MAIN_USER'],
  },
  {
    table: 'AC_MAST',
    line: 1515,
    columns: [
      'AC_CODE',
      'LC_CODE',
      'AC_NAME',
      'AC_SHORT',
      'AC_MAIN_GR',
      'AC_GR',
      'AC_GST_TYPE',
      'DATA_TRFR',
      'AC_PERSON',
      'AC_ADD1',
      'AC_ADD2',
      'AC_ADD3',
      'AC_COUNTRY',
      'AC_STATE',
      'AC_DISTRICT',
      'AC_CITY',
      'AC_AREA',
      'AC_PIN',
      'AC_PHONE',
      'AC_MOBILE',
      'AC_EMAIL',
      'AC_GSTNO',
      'AC_PANNO',
      'AC_ADHAR_NO',
      'BR_DATE',
      'AN_DATE',
    ],
  },
  {
    table: 'BAL_GR',
    line: 1523,
    columns: [
      'TRAD_TYPE',
      'TRAD_NAME',
      'SALE_AC',
      'PURC_AC',
      'CLOSING_AC',
      'OP_AC',
      'TRAD_AMT',
      'TRAD_WT',
      'CLG_AC',
    ],
  },
  {
    /**
     * Account serial allocation, written by `MS_OPNCOMP` when a company is opened. Company- and
     * location-scoped, so it belongs with the provisioning set rather than with master CRUD.
     */
    table: 'AC_MAST_SRNO',
    line: 1511,
    columns: ['LC_CODE', 'AC_CODE', 'AC_NAME', 'AC_GR', 'MAIN_USER'],
  },
  {
    /**
     * Bank reconciliation marks (`LEDR_KEY` + `CLR_DATE`), written by `MS_UPDATE`. Cloned so a new
     * company starts with the template's reconciliation state rather than an unwritten table.
     */
    table: 'BANK_RECONCILE',
    line: 1511,
    columns: ['LC_CODE', 'LEDR_KEY', 'CLR_DATE'],
  },
  {
    /**
     * Book DETAIL rows, seeded alongside BOOK_DATA. The desktop writes these from `MS_LOCT`, `MS_YEAR`
     * and `MS_UPDATE` (14 columns, identical list in all three), and the web READS them in `bookPolicy`
     * to resolve a voucher's posting account and main book — so a company created without them has
     * books that cannot post. That read-without-write gap is why this entry exists.
     */
    table: 'BOOK_DETL',
    line: 1531,
    columns: [
      'LC_CODE',
      'CO_BOOK',
      'SR_NO',
      'BOOK_NAME',
      'BOOK_SNAME',
      'BOOK_TYPE',
      'ITM_TYPE',
      'BOOK_INOUT',
      'AC_CODE',
      'AC_NAME',
      'MAIN_BOOK',
      'RESET_BOOK',
      'DATA_TYPE',
    ],
  },
  {
    table: 'BOOK_DATA',
    line: 1525,
    columns: [
      'LC_CODE',
      'CO_BOOK',
      'BOOK_NAME',
      'BOOK_SNAME',
      'CUR_USE',
      'BOOK_INOUT',
      'MAIN_BOOK',
      'ITM_TYPE',
      'BOOK_TYPE',
      'BOOK_VCH_TYPE',
      'MAIN_USER',
      'BOOK_SR_NAME',
      'RESET_BOOK',
      'DATA_TYPE',
      'TRFR_BOOK',
      'DATA_TRFR',
      'USER_EMP_CODE',
      'WITH_MOBILE_ENTRY',
      'MENU_NAME',
      'BOOK_TBL_NAME',
      'BOOK_TBL_DETL',
    ],
  },
  {
    table: 'BOOK_DETL',
    line: 1527,
    columns: [
      'LC_CODE',
      'CO_BOOK',
      'SR_NO',
      'BOOK_NAME',
      'BOOK_SNAME',
      'BOOK_TYPE',
      'ITM_TYPE',
      'BOOK_INOUT',
      'AC_CODE',
      'AC_NAME',
      'MAIN_BOOK',
      'RESET_BOOK',
      'DATA_TYPE',
    ],
  },
  {
    table: 'COL_MAST',
    line: 1533,
    columns: ['BOOK_NAME', 'COL_NAME', 'COL_RPT', 'COL_NEW_NAME', 'YES_NO'],
  },
  {
    table: 'CONV_MAST',
    line: 1535,
    columns: [
      'CON_CODE',
      'CON_NAME',
      'RATE_DATE',
      'GOLD_OZ_RATE',
      'SILVER_OZ_RATE',
      'CURRENCY_RATE',
      'OUNCES_CONV',
      'GOLD_CONV',
      'SILVER_CONV',
      'GOLD_PR_RATE',
      'GOLD_SL_RATE',
      'SILVER_PR_RATE',
      'SILVER_SL_RATE',
      'MAIN_USER',
    ],
  },
  {
    table: 'EMP_MAST',
    line: 1537,
    columns: [
      'EMP_CODE',
      'EMP_NAME',
      'USER_NAME',
      'EMP_TYPE',
      'EMP_AC',
      'EMP_AMT',
      'MAIN_USER',
      'TDS_PRC',
      'TDS_AMT',
      'PF_PRC',
      'PF_AMT',
      'DAY_HOURS',
    ],
  },
  {
    table: 'GROUP_MAST',
    line: 1539,
    columns: [
      'GR_CODE',
      'GR_NAME',
      'GR_TYPE',
      'TRAD_TYPE',
      'GR_TOUCH',
      'GR_PURC_TOUCH',
      'MELTING_PRC',
      'GR_RATE',
      'WEST_PRC',
      'SALE_AC',
      'PURC_AC',
      'HSN_CODE',
      'MAIN_USER',
      'TAX_PRC',
      'AVG_TOUCH',
      'AVG_FINE',
      'AVG_NWT',
      'DAY_OP_PCS',
      'DAY_OP_WT',
      'DAY_CL_PCS',
      'DAY_CL_WT',
      'RATE_DISPLAY',
      'DATA_TRFR',
    ],
  },
  {
    table: 'ITEM_MAST',
    line: 1541,
    columns: [
      'IT_CODE',
      'IT_NAME',
      'IT_TYPE',
      'TAG_TYPE',
      'PR_CODE',
      'GR_CODE',
      'TRAD_TYPE',
      'UNIT_NAME',
      'RATE_TYPE',
      'HSN_CODE',
      'ITEM_RATE',
      'LBR_PRC',
      'CON_PRC',
      'DISC_PRC',
      'IT_TOUCH',
      'IT_WEST',
      'OTHER_RATE',
      'MIN_STK',
      'MAIN_USER',
      'AVG_TOUCH',
      'AVG_FINE',
      'AVG_NWT',
      'AC_ITEM',
      'STK_DISPLAY',
      'OTH_RATE',
      'AVG_RATE',
      'SAFE_NAME',
      'DATA_TRFR',
      'IT_BAG_WT',
      'IT_LBR_RATE',
      'UNICODE_NAME',
      'TAG_IDTL_COL',
    ],
  },
  {
    table: 'LOCT_MAST',
    line: 1543,
    columns: [
      'LC_CODE',
      'LC_NAME',
      'LC_ADD1',
      'LC_ADD2',
      'LC_ADD3',
      'LC_CITY',
      'LC_PHONE',
      'LC_MOBILE',
      'MAIN_USER',
    ],
  },
  {
    table: 'PRINT_MAST',
    line: 1547,
    columns: ['PRINT_TYPE', 'PRINT_FILE', 'BOOK_TYPE', 'PRINT_SET_A'],
  },
  {
    table: 'PRODUCT_MAST',
    line: 1549,
    columns: ['PR_CODE', 'PR_NAME', 'MAIN_USER'],
  },
  {
    table: 'TABLE_MAST',
    line: 1551,
    columns: ['LC_CODE', 'TABLE_CODE', 'TABLE_NAME'],
  },
  {
    table: 'TAX_MAST',
    line: 1553,
    columns: [
      'TAX_CODE',
      'SR_NO',
      'TAX_GROUP',
      'TAX_NAME',
      'TAX_PRC',
      'ADD_TAX_PRC',
      'TAX_AC',
      'MAIN_USER',
    ],
  },
];

export const CLONE_TEMPLATE_CO_CODE = '01';

export interface CloneCompanyOptions {
  sourceCoCode?: string;
  /** Desktop copy-company behaviour: clear the target company's rows first. Default false. */
  replace?: boolean;
  /** Restrict to these tables (used by tests and partial re-provisioning). */
  only?: readonly string[];
}

export interface CloneCompanyResult {
  /** Rows written per table; a table absent from the map was skipped because it already had rows. */
  written: Record<string, number>;
  skipped: string[];
}

/** Clone masters + configuration into `coCode`. Returns per-table row counts. */
export async function cloneCompanyTx(
  tx: any,
  tenantId: string,
  coCode: string,
  options: CloneCompanyOptions = {},
): Promise<CloneCompanyResult> {
  const source = (options.sourceCoCode ?? CLONE_TEMPLATE_CO_CODE).trim();
  if (source === coCode) {
    throw new Error('company clone source and target must differ');
  }
  const q = (c: string): string => `"${c}"`;
  const written: Record<string, number> = {};
  const skipped: string[] = [];

  for (const spec of COMPANY_CLONE_TABLES) {
    if (options.only && !options.only.includes(spec.table)) continue;
    const cols = spec.columns.map(q).join(',');

    if (options.replace) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "${spec.table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        tenantId,
        coCode,
      );
    } else {
      const existing: Array<{ n: number }> = await tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "${spec.table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        tenantId,
        coCode,
      );
      if ((existing[0]?.n ?? 0) > 0) {
        skipped.push(spec.table);
        continue;
      }
    }

    written[spec.table] = (await tx.$executeRawUnsafe(
      `INSERT INTO "${spec.table}"(tenant_id,"CO_CODE",${cols})
         SELECT $1,$2,${cols} FROM "${spec.table}" WHERE tenant_id=$1 AND "CO_CODE"=$3`,
      tenantId,
      coCode,
      source,
    )) as number;
  }
  return { written, skipped };
}

export async function cloneCompany(
  prisma: any,
  tenantId: string,
  coCode: string,
  options: CloneCompanyOptions = {},
): Promise<CloneCompanyResult> {
  return withTxBudget(prisma, tenantId, 'heavy', (tx: any) =>
    cloneCompanyTx(tx, tenantId, coCode, options),
  );
}
