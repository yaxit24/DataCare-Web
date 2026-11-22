/**
 * The family slot templates of Company → Books (desktop MS_BOOK). The desktop builds a book's slot grid from BOOK_IDTL,
 * the template table of every MAIN_BOOK family (MS_BOOK.cs:2936 for the family Enter, :2541 for a reopen). The rows
 * below are the BOOK_IDTL inserts of the desktop's MS_UPDATE.cs patches (the latest insert of each family and slot),
 * which the supervisor's decision D1 of WP-21 makes the slot authority: each slot's number, direction (INOUT_TYPE),
 * default account and description.
 *
 * MISSING, recorded on G252: the installed baseline BOOK_IDTL rows of SALES, SALES RETURNE, PURCHASE slots 1 to 4,
 * PURC RETURN, CASH/BANK REC/PAY, SALES ORDER, ORDER CANCEL, CONTRA, JOURNAL and the stock families. booksMaster.ts
 * takes the slots of those families from the company's own books of the family instead.
 */
export interface BookTemplateSlot {
  srNo: number;
  inout: 'I' | 'O';
  /** The desktop default account code (the template's AC_CODE). */
  acCode: string;
  /** The template's AC_NAME, shown in the grid's Account Desc column. */
  desc: string;
}

const rows = (
  inout: 'I' | 'O',
  slots: Array<[number, string, string]>,
): BookTemplateSlot[] => slots.map(([srNo, acCode, desc]) => ({ srNo, inout, acCode, desc }));

export const BOOK_TEMPLATES: Readonly<Record<string, readonly BookTemplateSlot[]>> = {
  // MS_UPDATE.cs:7328-7348
  'ITEM SALES': rows('O', [
    [1, '00003', 'SALES GOLD A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00041', 'LABOUR INCOM. A/C'],
    [4, '00057', 'KASAR JAVK A/C'],
    [5, '00076', 'DISCOUNT A/C'],
    [6, '00020', 'ORDER ADVANCE'],
  ]),
  // MS_UPDATE.cs:7360-7376
  'ITEM PURC': rows('O', [
    [1, '00008', 'PURCHASE A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00056', 'LABOUR EXP A/C'],
    [4, '00042', 'KASAR AVAK A/C'],
    [5, '00076', 'DISCOUNT A/C'],
  ]),
  // MS_UPDATE.cs:18593-18633
  'E INVOICE': rows('O', [
    [1, '00003', 'SALES GOLD A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00057', 'KASAR JAVK A/C'],
    [4, '00020', 'ORDER ADVANCE'],
    [5, '00076', 'DISCOUNT A/C'],
    [6, '00041', 'LABOUR INCOM. A/C'],
  ]),
  // MS_UPDATE.cs:21415-21427
  'CON PUR': rows('I', [
    [1, '00008', 'PURCHASE GOLD A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00042', 'KASAR AVAK A/C.'],
    [4, '00056', 'LABOUR EXP A/C'],
  ]),
  // MS_UPDATE.cs:22852-22868
  'OTH EXP': rows('O', [
    [1, '00008', 'PURCHASE A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00042', 'KASAR AVAK A/C'],
  ]),
  // MS_UPDATE.cs:22876-22892
  'OTH INC': rows('I', [
    [1, '00099', 'SALES A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00057', 'KASAR JAVK A/C'],
  ]),
  // MS_UPDATE.cs:23749-23761 (slots 8 to 11 only; the earlier slots are baseline, MISSING)
  'LABOUR WORK': rows('I', [
    [8, '00004', 'SALES SILVER A/C'],
    [9, '00009', 'PURCHASE SILVER A/C'],
    [10, '00005', 'SALES OLD GOLD A/C'],
    [11, '00006', 'SALES OLD SILVER A/C'],
  ]),
  // MS_UPDATE.cs:25022 (slot 5 only)
  PURCHASE: rows('I', [[5, '00076', 'DISCOUNT A/C']]),
  // MS_UPDATE.cs:27519-27543
  'E CRNT': rows('I', [
    [1, '00003', 'SALES GOLD A/C'],
    [2, '00001', 'CASH ON HAND'],
    [3, '00042', 'KASAR AVAK A/C'],
    [4, '00076', 'DISCOUNT A/C'],
  ]),
  // MS_UPDATE.cs:27567-27583
  'OTH COMM': rows('O', [
    [1, '00001', 'CASH ON HAND'],
    [2, '00044', 'COMMISION INCOM A/C'],
    [3, '00057', 'KASAR JAVK A/C'],
  ]),
  // MS_UPDATE.cs:28164-28188
  'WH RTN': rows('I', [
    [1, '00003', 'SALES GOLD A/C'],
    [2, '00004', 'SALES SILVER A/C'],
    [3, '00001', 'CASH ON HAND'],
    [4, '00041', 'LABOUR INCOM. A/C'],
    [5, '00042', 'KASAR AVAK A/C'],
    [6, '00077', 'OTHER CHARGES A/C'],
    [7, '00098', 'FINE KASAR'],
  ]),
  // MS_UPDATE.cs:28472-28480
  'LD ADJUST': rows('I', [
    [1, '00042', 'KASAR AVAK A/C.'],
    [2, '00057', 'KASAR JAVK A/C'],
    [3, '00098', 'FINE KASAR'],
  ]),
  // MS_UPDATE.cs:28696-28716
  'FINE PURC': rows('O', [
    [1, '00001', 'CASH ON HAND'],
    [2, '00008', 'PURCHASE A/C'],
    [3, '00009', 'PURCHASE SILVER A/C'],
    [4, '00057', 'KASAR AVAK A/C'],
    [5, '00076', 'DISCOUNT A/C'],
    [6, '00056', 'LABOUR EXP A/C'],
  ]),
  // MS_UPDATE.cs:28728-28748
  'FINE SALE': rows('O', [
    [1, '00001', 'CASH ON HAND'],
    [2, '00003', 'SALES GOLD A/C'],
    [3, '00004', 'SALES SILVER A/C'],
    [4, '00057', 'KASAR JAVK A/C'],
    [5, '00076', 'DISCOUNT A/C'],
    [6, '00041', 'LABOUR INCOME A/C'],
  ]),
  // MS_UPDATE.cs:30221 (slot 5 only)
  'TAG PURCHASE': rows('I', [[5, '00076', 'DISCOUNT A/C']]),
  // MS_UPDATE.cs:30265
  'AMT IN': rows('I', [[1, '00057', 'KASAR JAVK A/C']]),
  // MS_UPDATE.cs:30269
  'AMT OUT': rows('O', [[1, '00042', 'KASAR AVAK A/C']]),
  // MS_UPDATE.cs:31433-31477
  'TOUR SALES': rows('O', [
    [1, '00003', 'SALES GOLD A/C'],
    [2, '00008', 'PURCHASE GOLD A/C'],
    [3, '00001', 'CASH ON HAND'],
    [4, '00057', 'KASAR JAVK A/C'],
    [5, '00042', 'KASAR AVAK A/C'],
    [6, '00041', 'LABOUR INCOME A/C'],
    [7, '00056', 'LABOUR EXP A/C'],
    [8, '00004', 'SALES SILVER A/C'],
    [9, '00009', 'PURCHASE SILVER A/C'],
    [10, '00061', 'INTEREST INCOME A/C'],
    [11, '00077', 'OTHER CHARGES A/C'],
    [12, '00098', 'FINE KASAR'],
  ]),
  // MS_UPDATE.cs:31827
  'TOUR ORDER': rows('I', [[1, '00001', 'CASH ON HAND']]),
  // MS_UPDATE.cs:32078-32110
  'TAG SPLIT': rows('O', [
    [1, '00001', 'CASH ON HAND'],
    [2, '00057', 'KASAR JAVK A/C'],
    [3, '00042', 'KASAR AVAK A/C'],
    [4, '00041', 'LABOUR INCOME A/C'],
    [5, '00056', 'LABOUR EXP A/C'],
    [6, '00003', 'SALES GOLD A/C'],
    [7, '00008', 'PURCHASE GOLD A/C'],
    [8, '00004', 'SALES SILVER A/C'],
    [9, '00009', 'PURCHASE SILVER A/C'],
  ]),
};

/**
 * Web adaptation: a web-provisioned company's chart has the literal system accounts of `seedCompany.ts`, not the
 * desktop's numbered chart. A template default whose desktop code the company does not have takes the provisioned
 * account of the same role (the roles seedCompany.ts names for them); a company without either gets a blank slot, which
 * the operator fills (a blank slot is allowed, D5).
 */
export const DESKTOP_DEFAULT_ACCOUNT_ROLES: Readonly<Record<string, string>> = {
  '00001': 'CASH',
  '00003': 'SALES',
  '00004': 'SLVSALE',
  '00005': 'OG',
  '00006': 'OS',
  '00008': 'PURCHASE',
  '00009': 'SLVPURC',
  '00020': 'ORDADV',
  '00041': 'LBRINC',
  '00042': 'KASAR',
  '00056': 'LBREXP',
  '00057': 'KASAR',
  '00061': 'INTINC',
  '00076': 'DISCOUNT',
  '00077': 'OTHCHRG',
  '00098': 'FINEKSR',
  '00099': 'SALES',
};
