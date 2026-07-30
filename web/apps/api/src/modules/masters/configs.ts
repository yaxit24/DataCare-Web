import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { type MasterConfig, AC_MAST_CONFIG, ITEM_MAST_CONFIG } from './master.service.js';

export const RATE_MAST_CONFIG: MasterConfig = {
  table: 'RATE_MAST',
  keyColumns: ['CO_CODE', 'LC_CODE', 'VCH_DATE', 'SR_NO'],
  requiredColumns: ['CO_CODE', 'LC_CODE', 'VCH_DATE', 'SR_NO', 'GR_CODE'],
  references: [],
};
export const TAX_MAST_CONFIG: MasterConfig = {
  table: 'TAX_MAST',
  keyColumns: ['CO_CODE', 'TAX_CODE'],
  requiredColumns: ['CO_CODE', 'TAX_CODE', 'TAX_NAME'],
  columnMessages: { TAX_NAME: DESKTOP_MESSAGES.TAX_NAME_REQUIRED },
  references: [],
};
export const GROUP_MAST_CONFIG: MasterConfig = {
  // Desktop-evidence exclusions: desktop_editable_columns.py found no control binding
  // for these, so the desktop never lets an operator type them.
  nonFormColumns: {
    AVG_FINE: 'maintained by posting or day-close, never typed on MS_GROUP',
    AVG_NWT: 'maintained by posting or day-close, never typed on MS_GROUP',
    AVG_RATE: 'maintained by posting or day-close, never typed on MS_GROUP',
    AVG_TOUCH: 'maintained by posting or day-close, never typed on MS_GROUP',
    DAY_CL_PCS: 'maintained by posting or day-close, never typed on MS_GROUP',
    DAY_CL_WT: 'maintained by posting or day-close, never typed on MS_GROUP',
    DAY_OP_PCS: 'maintained by posting or day-close, never typed on MS_GROUP',
    DAY_OP_WT: 'maintained by posting or day-close, never typed on MS_GROUP',
    GR_RATE: 'maintained by posting or day-close, never typed on MS_GROUP',
    OP_FINE: 'maintained by posting or day-close, never typed on MS_GROUP',
    OP_TOUCH: 'maintained by posting or day-close, never typed on MS_GROUP',
    PCS_RATE: 'maintained by posting or day-close, never typed on MS_GROUP',
    TOT_PCS: 'maintained by posting or day-close, never typed on MS_GROUP',
  },
  table: 'GROUP_MAST',
  keyColumns: ['CO_CODE', 'GR_CODE'],
  requiredColumns: ['CO_CODE', 'GR_CODE', 'GR_NAME'],
  deleteSelectionMessage: DESKTOP_MESSAGES.GROUP_SELECT_FOR_DELETE,
  // MS_AC_GROUP.cs reports the blank name in these exact words.
  columnMessages: { GR_NAME: DESKTOP_MESSAGES.GROUP_NAME_REQUIRED },
  references: ['ITEM_MAST'], // an item references its group via CO_CODE+GR_CODE
  // Item Group Master (desktop MS_GROUP) — drives ledger posting (Sale/Purc A/c) + metal valuation.
  formFields: [
    { col: 'CO_CODE', label: 'Company' },
    { col: 'GR_CODE', label: 'Group Code' },
    { col: 'GR_NAME', label: 'Group Name' },
    {
      col: 'GR_TYPE',
      label: 'Item Type',
      type: 'select',
      options: [
        { value: 'G', label: 'Gold' },
        { value: 'S', label: 'Silver' },
      ],
    },
    { col: 'GR_TOUCH', label: 'Rate Touch %', type: 'number' },
    { col: 'GR_PURC_TOUCH', label: 'Purchase Touch %', type: 'number' },
    { col: 'MELTING_PRC', label: 'Melting %', type: 'number' },
    { col: 'WEST_PRC', label: 'Wastage %', type: 'number' },
    { col: 'SALE_AC', label: 'Sales A/c', type: 'lookup', entity: 'accounts' },
    { col: 'PURC_AC', label: 'Purchase A/c', type: 'lookup', entity: 'accounts' },
    { col: 'HSN_CODE', label: 'HSN Code' },
    { col: 'TAX_PRC', label: 'Tax %', type: 'number' },
    { col: 'RATE_DISPLAY', label: 'Rate Display (Y/N)' },
  ],
};
export const EMP_MAST_CONFIG: MasterConfig = {
  table: 'EMP_MAST',
  keyColumns: ['CO_CODE', 'EMP_CODE'],
  requiredColumns: ['CO_CODE', 'EMP_CODE', 'EMP_NAME'],
  columnMessages: { EMP_NAME: DESKTOP_MESSAGES.EMPLOYEE_NAME_REQUIRED },
  deleteSelectionMessage: DESKTOP_MESSAGES.EMPLOYEE_SELECT_FOR_DELETE,
  references: [],
};
export const BOOK_DATA_CONFIG: MasterConfig = {
  table: 'BOOK_DATA',
  keyColumns: ['CO_CODE', 'LC_CODE', 'CO_BOOK'],
  requiredColumns: ['CO_CODE', 'LC_CODE', 'CO_BOOK', 'BOOK_NAME', 'BOOK_SNAME'],
  columnMessages: { BOOK_SNAME: DESKTOP_MESSAGES.BOOK_SHORT_NAME_REQUIRED },
  references: [],
};

// ---- Phase C additional masters (derived from desktop MS_* forms + live schema) ----
export const PRODUCT_MAST_CONFIG: MasterConfig = {
  table: 'PRODUCT_MAST',
  keyColumns: ['CO_CODE', 'PR_CODE'],
  requiredColumns: ['CO_CODE', 'PR_CODE', 'PR_NAME'],
  columnMessages: {
    PR_NAME: DESKTOP_MESSAGES.PRODUCT_NAME_REQUIRED,
    PR_CODE: DESKTOP_MESSAGES.PRODUCT_CODE_REQUIRED,
  },
  deleteSelectionMessage: DESKTOP_MESSAGES.PRODUCT_SELECT_FOR_DELETE,
  // MS_PRODUCT.cs: `Len(tPrCode.Text) = 1` — a one-character code is rejected; a blank code falls to
  // the PR_CODE presence guard above, which is why this is not written as "length <> 2".
  columnRules: [
    {
      column: 'PR_CODE',
      message: DESKTOP_MESSAGES.PRODUCT_CODE_TWO_DIGITS,
      invalid: (value: string) => value.length === 1,
    },
  ],
  references: [],
};
export const LOCT_MAST_CONFIG: MasterConfig = {
  table: 'LOCT_MAST',
  keyColumns: ['CO_CODE', 'LC_CODE'],
  requiredColumns: ['CO_CODE', 'LC_CODE', 'LC_NAME'],
  deleteSelectionMessage: DESKTOP_MESSAGES.LOCATION_SELECT_FOR_DELETE,
  references: [],
};
export const DESIGN_MAST_CONFIG: MasterConfig = {
  table: 'DESIGN_MAST',
  keyColumns: ['CO_CODE', 'DESIGN_NO'],
  requiredColumns: ['CO_CODE', 'DESIGN_NO'],
  columnMessages: { DESIGN_NO: DESKTOP_MESSAGES.DESIGN_NAME_REQUIRED },
  duplicateMessage: DESKTOP_MESSAGES.DESIGN_NAME_DUPLICATE,
  references: [],
};
export const DM_MAST_CONFIG: MasterConfig = {
  table: 'DM_MAST',
  keyColumns: ['CO_CODE', 'DM_CODE'],
  requiredColumns: ['CO_CODE', 'DM_CODE', 'DM_NAME'],
  columnMessages: { DM_NAME: DESKTOP_MESSAGES.DM_NAME_REQUIRED },
  deleteSelectionMessage: DESKTOP_MESSAGES.DM_SELECT_FOR_DELETE,
  references: [],
};
export const MODEL_MAST_CONFIG: MasterConfig = {
  table: 'MODEL_MAST',
  keyColumns: ['CO_CODE', 'MODEL_NAME'],
  requiredColumns: ['CO_CODE', 'MODEL_NAME'],
  columnMessages: { MODEL_NAME: DESKTOP_MESSAGES.MODEL_NAME_REQUIRED },
  deleteSelectionMessage: DESKTOP_MESSAGES.STYLE_SELECT_FOR_DELETE,
  duplicateMessage: DESKTOP_MESSAGES.STYLE_NAME_DUPLICATE,
  references: [],
};
export const STATE_MAST_CONFIG: MasterConfig = {
  table: 'STATE_MAST',
  keyColumns: ['STATE_CODE'],
  requiredColumns: ['STATE_CODE', 'STATE_NAME'],
  references: [],
};
export const POINT_MAST_CONFIG: MasterConfig = {
  table: 'POINT_MAST',
  keyColumns: ['CO_CODE', 'POINT_CODE', 'SR_NO'],
  requiredColumns: ['CO_CODE', 'POINT_CODE', 'SR_NO', 'POINT_NAME'],
  references: [],
};
export const LBR_MAST_CONFIG: MasterConfig = {
  table: 'LBR_MAST',
  keyColumns: ['CO_CODE', 'LBR_CODE'],
  requiredColumns: ['CO_CODE', 'LBR_CODE'],
  references: [],
};
export const TOUCH_MAST_CONFIG: MasterConfig = {
  table: 'TOUCH_MAST',
  keyColumns: ['CO_CODE', 'LC_CODE', 'AC_CODE', 'AC_IT_CODE'],
  requiredColumns: ['CO_CODE', 'LC_CODE', 'AC_CODE', 'AC_IT_CODE'],
  references: [],
};
export const MSG_MAST_CONFIG: MasterConfig = {
  table: 'MSG_MAST',
  keyColumns: ['CO_CODE', 'MSG_TYPE', 'MSG_TYPING'],
  requiredColumns: ['CO_CODE', 'MSG_TYPE', 'MSG_TYPING'],
  references: [],
};
export const CONV_MAST_CONFIG: MasterConfig = {
  table: 'CONV_MAST',
  keyColumns: ['CO_CODE', 'CON_CODE'],
  requiredColumns: ['CO_CODE', 'CON_CODE', 'CON_NAME'],
  references: [],
};
export const MFG_MAST_CONFIG: MasterConfig = {
  table: 'MFG_MAST',
  keyColumns: ['CO_CODE', 'SM_MAIN_CODE'],
  requiredColumns: ['CO_CODE', 'SM_MAIN_CODE'],
  // MS_MFG_MAST.cs: `DC_Main.Tbl.Rows.Count > 10` — once eleven manufacturing transactions exist the
  // process chain is frozen, because editing it would invalidate them.
  saveGuards: [
    {
      table: 'MFG_DATA',
      maxRows: 10,
      message: DESKTOP_MESSAGES.MFG_MASTER_LOCKED_BY_TRANSACTIONS,
    },
  ],
  references: [],
};

/** Phase 1 additional masters (more MS_* desktop forms). */
export const CO_MAST_CONFIG: MasterConfig = {
  // Desktop-evidence exclusions: desktop_editable_columns.py found no control binding
  // for these, so the desktop never lets an operator type them.
  nonFormColumns: {
    RAZOR_PAY_LIVE: 'not bound to any MS_COMPANY control',
  },
  table: 'CO_MAST',
  keyColumns: ['CO_CODE'],
  requiredColumns: ['CO_CODE', 'CO_NAME'],
  deleteSelectionMessage: DESKTOP_MESSAGES.COMPANY_SELECT_FOR_DELETE,
  columnMessages: {
    CO_CODE: DESKTOP_MESSAGES.CO_CODE_REQUIRED,
    CO_NAME: DESKTOP_MESSAGES.CO_NAME_REQUIRED,
  },
  references: [],
  formFields: [
    { col: 'CO_CODE', label: 'Company Code' },
    { col: 'CO_NAME', label: 'Company Name' },
    { col: 'CO_SNAME', label: 'Short Name' },
    {
      col: 'WORK_TYPE',
      label: 'Work Type',
      type: 'select',
      options: [
        { value: 'R', label: 'Retail' },
        { value: 'W', label: 'Wholesale' },
        { value: 'M', label: 'Manufacturing' },
      ],
    },
    {
      col: 'METAL_TYPE',
      label: 'Metal Type',
      type: 'select',
      options: [
        { value: 'G', label: 'Gold' },
        { value: 'S', label: 'Silver' },
        { value: 'B', label: 'Both' },
      ],
    },
    { col: 'CO_ADD1', label: 'Address 1' },
    { col: 'CO_ADD2', label: 'Address 2' },
    { col: 'CO_ADD3', label: 'Address 3' },
    { col: 'CO_CITY', label: 'City' },
    { col: 'CO_PIN', label: 'PIN' },
    { col: 'CO_COUNTRY', label: 'Country' },
    {
      col: 'CO_STATE_CODE',
      label: 'State',
      type: 'lookup',
      entity: 'states',
      fill: [{ col: 'CO_STATE', from: 'STATE_NAME' }],
    },
    { col: 'CO_STATE', label: 'State Name' },
    { col: 'CO_PHONE', label: 'Phone' },
    { col: 'CO_MOBILE', label: 'Mobile' },
    { col: 'CO_MAIL', label: 'Email' },
    { col: 'CO_GST_NO', label: 'GSTIN' },
    { col: 'CO_PAN_NO', label: 'PAN' },
    { col: 'CO_LSTNO', label: 'LST No' },
    { col: 'CO_CSTNO', label: 'CST No' },
    { col: 'CO_JUD', label: 'Jurisdiction' },
    { col: 'BANK_NAME', label: 'Bank Name' },
    { col: 'BANK_AREA', label: 'Bank Branch' },
    { col: 'BANK_AC_NO', label: 'Bank A/c No' },
    { col: 'BANK_RTGS_NO', label: 'IFSC / RTGS' },
  ],
};
export const YEAR_MAST_CONFIG: MasterConfig = {
  table: 'YEAR_MAST',
  keyColumns: ['CO_CODE', 'CO_YEAR'],
  requiredColumns: ['CO_CODE', 'CO_YEAR'],
  references: [],
};
export const ADD_MAST_CONFIG: MasterConfig = {
  // Desktop-evidence exclusions: desktop_editable_columns.py found no control binding
  // for these, so the desktop never lets an operator type them.
  nonFormColumns: {
    AN_DATE: 'birthday/anniversary is maintained on the account master, not MS_ADD_MAST',
    BR_DATE: 'birthday/anniversary is maintained on the account master, not MS_ADD_MAST',
    L_BR_DATE: 'birthday/anniversary is maintained on the account master, not MS_ADD_MAST',
  },
  table: 'ADD_MAST',
  keyColumns: ['CO_CODE', 'AC_CODE'],
  requiredColumns: ['CO_CODE', 'AC_CODE', 'AC_NAME'],
  // MS_ADD_MAST.cs guards a blank code OR name with this single message.
  columnMessages: {
    AC_CODE: DESKTOP_MESSAGES.CUSTOMER_NAME_REQUIRED,
    AC_NAME: DESKTOP_MESSAGES.CUSTOMER_NAME_REQUIRED,
  },
  references: [],
  // The desktop stamps these on every master row; listing them makes the generic CRUD accept them.
  formFields: [
    { col: 'MAIN_USER', label: 'User' },
    { col: 'DATA_TRFR', label: 'Data Transfer' },
  ],
};
export const DG_GOLD_MAST_CONFIG: MasterConfig = {
  table: 'DG_GOLD_MAST',
  keyColumns: ['CO_CODE', 'COUNTRY_CODE'],
  requiredColumns: ['CO_CODE', 'COUNTRY_CODE'],
  references: [],
  // The desktop stamps these on every master row; listing them makes the generic CRUD accept them.
  formFields: [
    { col: 'BANK_AC_CODE', label: 'Bank A/c' },
    { col: 'MAIN_USER', label: 'User' },
  ],
};
export const AD_MAST_CONFIG: MasterConfig = {
  // Desktop-evidence exclusions: desktop_editable_columns.py found no control binding
  // for these, so the desktop never lets an operator type them.
  nonFormColumns: {
    ADD_USER: 'provenance stamped by the server, never typed',
  },
  table: 'AD_MAST',
  keyColumns: ['CO_CODE', 'SCHM_CODE'],
  requiredColumns: ['CO_CODE', 'SCHM_CODE', 'SCHM_NAME'],
  // MS_PRODUCT.cs with CurMast='Scheme' words these two guards this way.
  columnMessages: {
    SCHM_NAME: DESKTOP_MESSAGES.SCHEME_NAME_REQUIRED,
    SCHM_CODE: DESKTOP_MESSAGES.SCHEME_CODE_REQUIRED,
  },
  references: [],
  // The desktop stamps these on every master row; listing them makes the generic CRUD accept them.
  formFields: [
    { col: 'MAIN_USER', label: 'User' },
    { col: 'DATA_TRFR', label: 'Data Transfer' },
  ],
};
export const TABLE_MAST_CONFIG: MasterConfig = {
  table: 'TABLE_MAST',
  keyColumns: ['CO_CODE', 'TABLE_CODE'],
  requiredColumns: ['CO_CODE', 'TABLE_CODE', 'TABLE_NAME'],
  columnMessages: {
    TABLE_NAME: DESKTOP_MESSAGES.TABLE_NAME_REQUIRED,
    TABLE_CODE: DESKTOP_MESSAGES.TABLE_CODE_REQUIRED,
  },
  references: [],
  // The desktop stamps these on every counter/table master row.
  formFields: [
    { col: 'MAIN_USER', label: 'User' },
    { col: 'DATA_TRFR', label: 'Data Transfer' },
  ],
};
export const ITM_WT_MAST_CONFIG: MasterConfig = {
  table: 'ITM_WT_MAST',
  keyColumns: ['CO_CODE', 'IT_CODE', 'SR_NO'],
  requiredColumns: ['CO_CODE', 'IT_CODE', 'SR_NO'],
  references: [],
};
export const COL_MAST_CONFIG: MasterConfig = {
  table: 'COL_MAST',
  keyColumns: ['CO_CODE', 'COL_NAME'],
  requiredColumns: ['CO_CODE', 'COL_NAME'],
  references: [],
};
export const PRINT_MAST_CONFIG: MasterConfig = {
  table: 'PRINT_MAST',
  keyColumns: ['CO_CODE', 'PRINT_TYPE'],
  requiredColumns: ['CO_CODE', 'PRINT_TYPE'],
  references: [],
};
export const E_MAST_CONFIG: MasterConfig = {
  table: 'E_MAST',
  keyColumns: ['CO_CODE'],
  requiredColumns: ['CO_CODE'],
  references: [],
};
export const FAN_AC_MAST_CONFIG: MasterConfig = {
  table: 'FAN_AC_MAST',
  keyColumns: ['CO_CODE', 'FAN_AC_CODE'],
  requiredColumns: ['CO_CODE', 'FAN_AC_CODE'],
  references: [],
};

/** Account-group master (desktop MS_AC_GROUP). An account references its account-group via CO_CODE+AC_GR. */
export const AC_GROUP_CONFIG: MasterConfig = {
  table: 'AC_GROUP',
  keyColumns: ['CO_CODE', 'AC_GR'],
  requiredColumns: ['CO_CODE', 'AC_GR', 'AC_GR_NAME'],
  references: ['AC_MAST'],
};

/** Route-name → master config (Req 8). `customers` = accounts (AC_MAST) filtered by AC_TYPE. */
export const BAL_GR_CONFIG: MasterConfig = {
  table: 'BAL_GR',
  keyColumns: ['CO_CODE', 'TRAD_TYPE'],
  requiredColumns: ['CO_CODE', 'TRAD_TYPE', 'TRAD_NAME'],
  columnMessages: { TRAD_NAME: DESKTOP_MESSAGES.TRADE_NAME_REQUIRED },
  references: [],
  formFields: [
    { col: 'TRAD_TYPE', label: 'Trade Type', group: 'General' },
    { col: 'TRAD_NAME', label: 'Trade Name', group: 'General' },
    {
      col: 'IT_TYPE',
      label: 'Item Type',
      type: 'select',
      options: [
        { value: 'G', label: 'Gold' },
        { value: 'S', label: 'Silver' },
        { value: 'D', label: 'Diamond' },
        { value: 'O', label: 'Other' },
      ],
      group: 'General',
    },
    { col: 'SALE_AC', label: 'Sales A/c', type: 'lookup', entity: 'accounts', group: 'Accounts' },
    {
      col: 'PURC_AC',
      label: 'Purchase A/c',
      type: 'lookup',
      entity: 'accounts',
      group: 'Accounts',
    },
    {
      col: 'CLOSING_AC',
      label: 'Closing A/c',
      type: 'lookup',
      entity: 'accounts',
      group: 'Accounts',
    },
    { col: 'OP_AC', label: 'Opening A/c', type: 'lookup', entity: 'accounts', group: 'Accounts' },
    { col: 'CLG_AC', label: 'Clearing A/c', type: 'lookup', entity: 'accounts', group: 'Accounts' },
    { col: 'TRAD_WT', label: 'Opening Weight', type: 'number', group: 'Opening' },
    { col: 'TRAD_AMT', label: 'Opening Amount', type: 'number', group: 'Opening' },
    { col: 'OP_TOUCH', label: 'Opening Touch %', type: 'number', group: 'Opening' },
    { col: 'OP_FINE', label: 'Opening Fine', type: 'number', group: 'Opening' },
    { col: 'AVG_TOUCH', label: 'Avg Touch %', type: 'number', group: 'Averages' },
    { col: 'AVG_FINE', label: 'Avg Fine', type: 'number', group: 'Averages' },
    { col: 'AVG_NWT', label: 'Avg Net Wt', type: 'number', group: 'Averages' },
    { col: 'AVG_AMT', label: 'Avg Amount', type: 'number', group: 'Averages' },
    { col: 'AVG_RATE', label: 'Avg Rate', type: 'number', group: 'Averages' },
  ],
};

/**
 * Item City master — the third mode of the multi-purpose `MS_STYLE` form (`CurMast = 'Item City'`).
 * Its guard wording was already wired via `columnMessages`; this config is what makes the table writable,
 * closing a table the desktop maintains but the web never wrote.
 */
export const ITM_CITY_CONFIG: MasterConfig = {
  table: 'ITM_CITY',
  keyColumns: ['CO_CODE', 'ITM_CITY'],
  requiredColumns: ['CO_CODE', 'ITM_CITY'],
  columnMessages: { ITM_CITY: DESKTOP_MESSAGES.ITEM_CITY_NAME_REQUIRED },
  duplicateMessage: DESKTOP_MESSAGES.ITEM_CITY_NAME_DUPLICATE,
  references: [],
  formFields: [
    { col: 'CO_CODE', label: 'Company' },
    { col: 'ITM_CITY', label: 'Item City' },
    { col: 'MAIN_USER', label: 'User' },
  ],
};

export const MASTERS: Record<string, MasterConfig> = {
  'item-cities': ITM_CITY_CONFIG,
  accounts: AC_MAST_CONFIG,
  customers: AC_MAST_CONFIG,
  items: ITEM_MAST_CONFIG,
  rates: RATE_MAST_CONFIG,
  taxes: TAX_MAST_CONFIG,
  groups: GROUP_MAST_CONFIG,
  employees: EMP_MAST_CONFIG,
  books: BOOK_DATA_CONFIG,
  products: PRODUCT_MAST_CONFIG,
  locations: LOCT_MAST_CONFIG,
  designs: DESIGN_MAST_CONFIG,
  diamonds: DM_MAST_CONFIG,
  models: MODEL_MAST_CONFIG,
  states: STATE_MAST_CONFIG,
  points: POINT_MAST_CONFIG,
  labour: LBR_MAST_CONFIG,
  touch: TOUCH_MAST_CONFIG,
  messages: MSG_MAST_CONFIG,
  conversions: CONV_MAST_CONFIG,
  mfg: MFG_MAST_CONFIG,
  companies: CO_MAST_CONFIG,
  years: YEAR_MAST_CONFIG,
  addresses: ADD_MAST_CONFIG,
  'gold-rate': DG_GOLD_MAST_CONFIG,
  schemes: AD_MAST_CONFIG,
  counters: TABLE_MAST_CONFIG,
  'item-weights': ITM_WT_MAST_CONFIG,
  styles: COL_MAST_CONFIG,
  'print-formats': PRINT_MAST_CONFIG,
  'einvoice-gsp': E_MAST_CONFIG,
  'franchise-accounts': FAN_AC_MAST_CONFIG,
  'ac-groups': AC_GROUP_CONFIG,
  trade: BAL_GR_CONFIG,
};
