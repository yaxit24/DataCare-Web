/**
 * Desktop validation messages, verbatim.
 *
 * Operators recognise the desktop's wording — including its typos — so a guard that blocks the same
 * condition with different words is a support cost, not parity. Every string here is copied
 * character-for-character from the decompiled source with its `file:line`, and the surrounding
 * comment records the exact condition the desktop tests.
 *
 * Do not "fix" the spelling: `Slelect`, `Plese` and the trailing dot runs are desktop text.
 */
export const DESKTOP_MESSAGES = {
  /**
   * TR_SALE.cs / TR_PURC.cs and ~30 further forms.
   * Desktop condition: the tag being entered already exists in stock for the company/location.
   */
  DUPLICATE_TAG: 'Duplicate Tag No',

  /**
   * TR_SALE.cs — settlement grid row 6.
   * Desktop condition: `Val(MSG2_TOTAL[6,3]) != 0 AND MSG2_TOTAL[6,4] = ''`
   * i.e. a cheque amount was entered without choosing the bank account it clears through.
   */
  CHEQUE_WITHOUT_BANK: 'Please Select Bank Account And Try Because Chq Rec Amt <> 0......',

  /**
   * TR_SALE.cs — settlement grid row 7.
   * Desktop condition: `Val(MSG2_TOTAL[7,3]) != 0 AND MSG2_TOTAL[7,4] = '' AND CardCommAdj = 'N'`
   * i.e. a card amount without a card bank account, unless card commission adjustment is on.
   */
  CARD_WITHOUT_BANK: 'Please Select Card Bank Account And Try Because Card Amt <> 0......',

  /**
   * TR_SALE.cs — desktop condition: `MsDefaulterAc = 'Y' AND Val(MSG2_TOTAL[15,3]) > 0`
   * i.e. the party is flagged a defaulter (AC_MAST.DEFAULTER_AC) and the bill leaves an outstanding
   * balance. Cash-cleared bills are allowed; credit to a defaulter is not.
   */
  PARTY_IN_DEFAULTER_LIST:
    'You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...',

  /**
   * TR_SALE.cs — desktop condition: old-gold rate type is neither 'N' nor 'F'.
   * The desktop spelling of "Select" is wrong here; it is reproduced as-is.
   */
  OLD_GOLD_RATE_TYPE: 'Please Slelect Rate type = N - Net Wise Or F - Fine Wise',

  /**
   * TR_SALE.cs — desktop condition: two rows of the order-pick grid carry the same
   * `ISU_DBCD + ORD_NO` at different row indices, i.e. the same order line was picked twice.
   */
  DUPLICATE_ORDER: 'Duplicate Order No',

  /**
   * TR_SALE.cs — desktop condition: `Val(MSG2_TOTAL[0,3]) == 0`, the settlement grid's net-amount
   * row is zero, i.e. the bill carries no value at all.
   */
  ITEM_VALUE_ZERO: 'Please Insert Item Value Nat Amount  = 0 and try',

  /** MS_ACCT.cs — desktop condition: `tAcName.Text = ''`. */
  PARTY_NAME_REQUIRED: 'Please Insert Party Name ...',

  /** MS_AC_GROUP.cs — desktop condition: `tGrName.Text = ''`. */
  GROUP_NAME_REQUIRED: 'Please Insert Group Name ...',

  /** MS_DESIGN_BOOK.cs — desktop condition: `tVchNo.Text = ''`, i.e. no book detail chosen yet. */
  BOOK_DETAIL_FIRST: 'Error Found : Please Enter Book Detail First...',

  /**
   * TR_PURC.cs — desktop condition: `MsCntrStk = 'Y'` AND a row carries an item code with a blank
   * counter (`MSG[1,3] <> '' AND MSG[M,4] = ''`). Only fires when counter-wise stock is enabled, so it
   * must never be enforced unconditionally.
   */
  TAG_COUNTER_MANDATORY: 'Please Insert Tag Entry Counter Code and Try Because It is Mandatory...',

  /** TR_PURC.cs — desktop condition: `tHmId2 <> '' AND Val(nHmWt2) = 0`. Same shape for IDs 3 and 4. */
  HALLMARK_ID2_WEIGHT: 'Please Insert HmId2 Weight and try...',
  HALLMARK_ID3_WEIGHT: 'Please Insert HmId3 Weight and try...',
  HALLMARK_ID4_WEIGHT: 'Please Insert HmId4 Weight and try...',

  /** UT_WAPP_WITH_API.cs — desktop condition: `Val(nToRow) < Val(nFromRow)`. */
  ROW_RANGE_INVALID: 'You Cant Set From Row > To row Please change it...',

  /** Shared across masters and lookups when a query returns nothing. */
  NO_RECORD_FOUND: 'No Record Found....',

  /** MS_DESIGN_BOOK.cs — a design line with no design number. */
  DESIGN_NO_REQUIRED: 'Please Insert Design No and Try..',

  /** Shared master guard for a repeated business key. */
  DUPLICATE_ENTRY: 'Duplicate Entry...',

  // ---- Master field guards -------------------------------------------------------------------
  // MS_PRODUCT and MS_STYLE are multi-purpose desktop forms: one form serves several masters chosen
  // by `CurMast` ("Product"/"Counter"/"Scheme" and "Design"/"Style"/"Item City"), so each master has
  // its own wording. In the web those are separate MasterConfigs, which is where the wording attaches.

  /** MS_PRODUCT.cs, CurMast='Product' — blank product name. */
  PRODUCT_NAME_REQUIRED: 'Please Insert Product Name ...',
  /** MS_PRODUCT.cs, CurMast='Product' — blank product code. */
  PRODUCT_CODE_REQUIRED: 'Enter Product Code.',
  /** MS_PRODUCT.cs — `Len(tPrCode.Text) <> 2`. */
  PRODUCT_CODE_TWO_DIGITS: 'Please Insert Product Code 2 Digit...',
  /** MS_PRODUCT.cs — delete pressed with no product selected. */
  PRODUCT_SELECT_FOR_DELETE: 'Please Select Product For Delete.',

  /** MS_PRODUCT.cs, CurMast='Counter' — blank counter/table name. */
  TABLE_NAME_REQUIRED: 'Please Insert Table Name ...',
  /** MS_PRODUCT.cs, CurMast='Counter' — blank counter/table code. */
  TABLE_CODE_REQUIRED: 'Enter Table Code.',

  /** MS_PRODUCT.cs, CurMast='Scheme' — blank scheme name. */
  SCHEME_NAME_REQUIRED: 'Please Insert Scheme Name ...',
  /** MS_PRODUCT.cs, CurMast='Scheme' — blank scheme code. */
  SCHEME_CODE_REQUIRED: 'Enter Scheme Code.',

  /** MS_STYLE.cs, CurMast='Style' — blank style/model name. */
  MODEL_NAME_REQUIRED: 'Please Insert Model Name ...',
  /** MS_STYLE.cs, CurMast='Style' — duplicate style name. */
  STYLE_NAME_DUPLICATE: 'This Style Name already Exist Please Change It...',
  /** MS_STYLE.cs — delete pressed with no style selected. */
  STYLE_SELECT_FOR_DELETE: 'Please Select Style For Delete.',

  /** MS_STYLE.cs, CurMast='Design' — blank design name. */
  DESIGN_NAME_REQUIRED: 'Please Insert Design Name ...',
  /** MS_STYLE.cs, CurMast='Design' — duplicate design name. */
  DESIGN_NAME_DUPLICATE: 'This Design Name already Exist Please Change It...',

  /** MS_ITEM.cs — blank item name (`tItName`). */
  ITEM_NAME_REQUIRED: 'Please Insert Item Name',
  /** MS_ITEM.cs — delete pressed with no item selected. */
  ITEM_SELECT_FOR_DELETE: 'Please Select Item For Delete.',

  /** MS_ACCT.cs — delete pressed with no account selected. */
  ACCOUNT_SELECT_FOR_DELETE: 'Please Select AcCode For Delete.',
  /** MS_AC_GROUP.cs — delete pressed with no group selected. */
  GROUP_SELECT_FOR_DELETE: 'Please Select Group For Delete.',
  /** MS_DM.cs — delete pressed with no diamond code selected. */
  DM_SELECT_FOR_DELETE: 'Please Select Dm Code For Delete.',

  /** MS_USER.cs — blank user name (`tUserName`). */
  USER_NAME_REQUIRED: 'Please Enter User Name.',
  /** MS_USER.cs — duplicate user name. */
  USER_NAME_DUPLICATE: 'This User Name already Exist.Please Change User Name...',
  /** MS_USER.cs — delete pressed with no user selected. */
  USER_SELECT_FOR_DELETE: 'Please Select User For Delete.',

  /** MS_COMPANY.cs — blank company code. */
  CO_CODE_REQUIRED: 'Please Insert Co Code ...',
  /** MS_COMPANY.cs — blank company name. */
  CO_NAME_REQUIRED: 'Please Insert Co Name ...',

  /** MS_USER.cs — desktop condition: `tOldPasword.Text = ''` on the change-password tab. */
  OLD_PASSWORD_REQUIRED: 'Please Insert Old Password',

  /**
   * UT_WAPP_WITH_API.cs — the else branch taken when the daily-rate query returns no row for the date,
   * i.e. `RATE_MAST` has nothing for that day, so nothing can be quoted or messaged.
   */
  DAILY_RATE_MISSING: 'Please Insert Daily Rate in Rate Master......',

  /** Module_Save.cs — else branch when the party has no e-mail address to send the bill to. */
  PARTY_EMAIL_MISSING: 'Please Insert e Mail id in Party Master then Try...',

  /** Module_Save.cs — else branch when the company's own mail id / API credentials are not configured. */
  COMPANY_MAIL_NOT_CONFIGURED: 'Please Update Company Mail Id and Api Then Try...',

  /** MS_MFG_MAST.cs — desktop condition: `DC_Main.Tbl.Rows.Count > 10` transactions already in MFG_DATA. */
  MFG_MASTER_LOCKED_BY_TRANSACTIONS:
    'You Cant Save Mfg Master Because More Then 10 Transection in MFG_DATA First Delete It and Try...',

  /** MS_DM.cs — blank diamond name. */
  DM_NAME_REQUIRED: 'Please Insert Diamond Name ...',
  /** MS_EMP.cs — blank employee name. */
  EMPLOYEE_NAME_REQUIRED: 'Please Insert Employee Name ...',
  /** MS_EMP.cs — delete pressed with no employee selected. */
  EMPLOYEE_SELECT_FOR_DELETE: 'Please Select Employee For Delete.',
  /** MS_TAX.cs — blank tax name. */
  TAX_NAME_REQUIRED: 'Please Insert Tax Name ...',
  /** MS_TAX.cs — delete pressed with no tax code selected. */
  TAX_SELECT_FOR_DELETE: 'Please Select Tax Code For Delete.',
  /** MS_BOOK.cs — blank book short name (BOOK_SNAME drives voucher prefixes and audit rows). */
  BOOK_SHORT_NAME_REQUIRED: 'Please Insert Book Short Name',
  /** MS_TRADE.cs — blank trading/balance-group name. */
  TRADE_NAME_REQUIRED: 'Please Insert Trading Name...',
  /** MS_LOCT.cs — delete pressed with no location selected. */
  LOCATION_SELECT_FOR_DELETE: 'Please Select Location Code For Delete.',
  /** MS_COMPANY.cs — delete pressed with no company selected. */
  COMPANY_SELECT_FOR_DELETE: 'Please Select Company Code For Delete.',
  /** MS_STYLE.cs, CurMast='Item City' — blank item city name. */
  ITEM_CITY_NAME_REQUIRED: 'Please Insert Item City Name ...',
  /** MS_STYLE.cs, CurMast='Item City' — duplicate city name. */
  ITEM_CITY_NAME_DUPLICATE: 'This Item City Name already Exist Please Change It...',

  /**
   * TR_PURC.cs, guarded by the form's `ItCodeLock` flag: once a purchase line has produced a TAG the
   * item code is frozen, because the tag already carries that item in stock. The desktop tells the
   * operator to move the stock with a tag transfer and generate a new tag instead.
   */
  ITEM_CODE_LOCKED_IN_EDIT:
    'You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag...',

  /**
   * TR_TAG_SPLIT.cs — desktop condition: `tAcCode.Text = '' AND Val(nCrWt) <> Val(nDrWt)`, i.e. the
   * received weights do not add back to the issued weight and no account was given to absorb the
   * difference.
   */
  SPLIT_WEIGHT_DIFFERENCE: 'Please Insert diff Wt in Received Grid and Try....',

  /** MS_ADD_MAST.cs — desktop condition: `tAcCode.Text = '' OR tAcName.Text = ''`. */
  CUSTOMER_NAME_REQUIRED: 'Please Select Customer name and try....',

  /** UT_SMS.cs — desktop condition: `tMsg.Text = ''`, nothing to send. */
  MESSAGE_BODY_REQUIRED: 'Please First Type Massage and Try...',

  /** MS_AUTO_ITEM.cs — desktop condition: the entered flag is neither `Y` nor `N`. */
  YES_OR_NO_REQUIRED: 'Please Enter Y or N and Try Again...',

  /**
   * TR_INOUT.cs — desktop condition: the form's MAIN_BOOK is `STOCK ADJUST` and the entry sign is
   * neither `+` nor `-`. Only stock-adjust books carry a free-form sign; other books derive it.
   */
  ITEM_SIGN_REQUIRED: 'Please Insert Item Sign + or - then Try',

  /** TR_TOUR_SALE.cs — a negative wastage percentage cannot be adjusted. */
  NEGATIVE_WEST_NOT_ALLOWED: 'You Cant Adjust Negative West % Please Change West %...',

  /**
   * TR_PURC.cs — desktop condition:
   *   `Val(MSG_PR_TOT[0,35]) + (Val(MSG_PR_TOT[0,9]) + Val(MSG_PR_TOT[0,12]) + Val(MSG_PR_TOT[0,44])) = 0`
   * i.e. the footer totals for labour amount, pieces, gross weight AND net amount are all zero, so the
   * voucher carries no content at all.
   */
  PARTY_ENTRY_REQUIRED: 'Please Insert Party Entry And Try.....',

  /** TR_CONTRA.cs:2694 — desktop condition: the grid's Cr total differs from its Dr total. */
  CONTRA_DR_CR_NOT_SAME: 'You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....',

  /** TR_AC_OPBL.cs:2682 — desktop condition: Save with no party code. */
  OPENING_PARTY_REQUIRED: 'Please Enter Party First...',

  /** TR_AC_OPBL.cs:2868 — desktop condition: Delete with no party code. */
  OPENING_ACCOUNT_REQUIRED: 'Please Select Account Details.',

  /** TR_AC_OPBL.cs:2668 — desktop condition: a bill row without a voucher number. */
  OPENING_BILL_VCH_REQUIRED: 'Please Insert Vch No and Try...',

  /** TR_AC_OPBL.cs:2674 — desktop condition: a bill row with no gold fine, silver fine or amount. */
  OPENING_BILL_VALUE_REQUIRED: 'Please Insert Gold fine or Silver fine or Net Amount and try...',

  /** TR_AC_OPBL.cs:3106 — desktop condition: a bill row's item type is not G, S or A. */
  OPENING_BILL_TYPE_REQUIRED: 'Please insert ItmType  G = Gold S = Silver Or A = Amount and try',

  /** TR_AC_OPBL.cs:3114 — desktop condition: a bill row's Cr/Dr is not C or D. */
  OPENING_BILL_SIGN_REQUIRED: 'Please Enter C or D and Try Again...',

  /** TR_TAG_OPBL.cs:8562 — desktop condition: a tag number already in another grid row. */
  TAG_DUPLICATE: 'Duplicate Tag No',

  /** TR_TAG_OPBL.cs:10815 — desktop condition: Only Tag Entry (TAG GEN) saved without the stock item code. */
  TAG_GEN_STOCK_ITEM_REQUIRED: 'Stock item code Insert First...',

  /** TR_TAG_OPBL.cs:11383 — desktop condition: delete while a tag of the voucher is in a sale (two spaces as stored). */
  TAG_OPENING_DELETE_SOLD: 'You Cant Delete This Voucher Because  Tag Use in Sales Transection....',
} as const;

export type DesktopMessageKey = keyof typeof DESKTOP_MESSAGES;
