import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { type BookWorkflow, workflowPolicy } from '../shared/bookPolicy.js';

/**
 * Company provisioning seed. A brand-new web company needs the system accounts that the posting engine
 * references by LITERAL code (CASH/SALES/PURCHASE/GST/…), plus standard taxes, voucher books, the
 * numbering counter and a settings row, so it can post immediately and show proper ledger names. We
 * seed exactly the literal codes the web posting uses (sales.ts/purchase.ts/finance.ts/… fallbacks) —
 * NOT a numeric chart — so no posting default changes and the existing test suite is untouched.
 * Idempotent: every row is insert-if-absent, so re-provisioning is safe.
 */

/** System accounts keyed by the literal AC_CODE the posting falls back to. */
const SYSTEM_ACCOUNTS: { code: string; name: string; gr: string }[] = [
  { code: 'CASH', name: 'CASH ON HAND', gr: '01' },
  { code: 'BANK', name: 'BANK A/C', gr: '02' },
  { code: 'SALES', name: 'SALES A/C', gr: '20' },
  { code: 'PURCHASE', name: 'PURCHASE A/C', gr: '21' },
  { code: 'GST', name: 'GST OUTPUT (PAYABLE)', gr: '30' },
  { code: 'GSTINPUT', name: 'GST INPUT CREDIT', gr: '30' },
  { code: 'ROUNDOFF', name: 'ROUND OFF', gr: '31' },
  { code: 'KASAR', name: 'KASAR / WRITE-OFF', gr: '31' },
  { code: 'TCS', name: 'TCS PAYABLE', gr: '30' },
  { code: 'HMCHRG', name: 'HALLMARK CHARGES', gr: '22' },
  { code: 'OLDGOLD', name: 'OLD GOLD EXCHANGE', gr: '21' },
  { code: 'OG', name: 'OLD GOLD', gr: '21' },
  { code: 'OS', name: 'OLD SILVER', gr: '21' },
  { code: 'INTINC', name: 'INTEREST INCOME', gr: '23' },
  { code: 'BULLION', name: 'BULLION TRADING', gr: '20' },
  { code: 'FINESALE', name: 'FINE METAL SALE', gr: '20' },
  { code: 'FINEPURC', name: 'FINE METAL PURCHASE', gr: '21' },
  { code: 'DHRN', name: 'DHIRAN / LOAN', gr: '21' },
  { code: 'CAPITAL', name: 'CAPITAL A/C', gr: '25' },
  // The wholesale / rate-cut slots (`Wh_Sales_Ledr`): labour income and expense, the silver twins of the sale
  // and purchase controls, other charges and fine kasar — the roles of 00041/00056/00004/00009/00077/00098 on
  // the real books 034/064.
  { code: 'LBRINC', name: 'LABOUR INCOME A/C', gr: '23' },
  { code: 'LBREXP', name: 'LABOUR EXPENSE A/C', gr: '22' },
  { code: 'SLVSALE', name: 'SALES SILVER A/C', gr: '20' },
  { code: 'SLVPURC', name: 'PURCHASE SILVER A/C', gr: '21' },
  { code: 'OTHCHRG', name: 'OTHER CHARGES A/C', gr: '23' },
  { code: 'FINEKSR', name: 'FINE KASAR A/C', gr: '31' },
  // Stock In/Out (TR_INOUT) posts the signed metal rows against the branch account the location carries
  // (`MS_LOCT.cs:3458` binds `LOCT_MAST.AC_CODE`; `stockInout.ts:344-355` reads it). A current-asset
  // stock-in-hand control holds the branch's inter-location metal (N91/G105).
  { code: 'BRANCH', name: 'BRANCH STOCK IN HAND', gr: '01' },
];

/**
 * BOOK_DETL of a TR_WH_SALE book, in the desktop's slot order (Ac_Ledr.cs:613-778 joins `B.SR_NO = n`; the real
 * books 034/064 carry all twelve): 1 sale gold, 2 purchase gold, 3 cash, 4 kasar, 5 purchase kasar, 6 labour
 * income, 7 labour expense, 8 sale silver, 9 purchase silver, 10 interest, 11 other charges, 12 fine kasar.
 */
const WHOLESALE_SLOTS: Array<{ srNo: number; acCode: string }> = [
  { srNo: 1, acCode: 'SALES' },
  { srNo: 2, acCode: 'PURCHASE' },
  { srNo: 3, acCode: 'CASH' },
  { srNo: 4, acCode: 'KASAR' },
  { srNo: 5, acCode: 'KASAR' },
  { srNo: 6, acCode: 'LBRINC' },
  { srNo: 7, acCode: 'LBREXP' },
  { srNo: 8, acCode: 'SLVSALE' },
  { srNo: 9, acCode: 'SLVPURC' },
  { srNo: 10, acCode: 'INTINC' },
  { srNo: 11, acCode: 'OTHCHRG' },
  { srNo: 12, acCode: 'FINEKSR' },
];

/**
 * Standard GST/TCS taxes. `prc` is the TOTAL rate.
 *
 * TAX_MAST is a parent + component shape, exactly as the desktop writes it and as the resolver reads it
 * (G82). The resolver pins the code by its PARENT row `SR_NO = 0` (`shared/taxPolicy.ts`, matching the desktop
 * `AND D.SR_NO = 0`), and the per-component split is read from `SR_NO = 1` SGST, `SR_NO = 2` CGST, `SR_NO = 3`
 * IGST (`Ac_Tax.cs`: `C.SR_NO = 1/2/3`, `TAX_AMT/2`, `TAX_AMT/2`, full). A GST code therefore needs four rows;
 * TAX FREE and TCS are a single parent row. Provisioning a code at `SR_NO = 1` only — as this seed did before
 * G82 — leaves it with no parent, so every save that NAMES the code failed with
 * "tax code is not configured" on every web-provisioned company.
 *
 * `isGst` marks the codes that get the three component rows.
 *
 * `TAX_AC` is deliberately left unset, exactly as this seed always left it. Choosing the tax ledger account is a
 * provisioning-convention question (gaps G38 and G40, decision D15, slices N58 and N59), not part of G82: the
 * desktop posts sale AND purchase tax to the one `TAX_MAST.TAX_AC` of the parent row (`Ac_Ledr.cs` Sales_Ledr and
 * Purc_Ledr join `D.SR_NO = 0` and post `D.TAX_AC`), while the web writers fall back to `'GST'` for sales and
 * `'GSTINPUT'` for purchases when `TAX_AC` is empty (`sales.ts:787`, `purchase.ts:718`). Writing `'GST'` here
 * would silently move every web-provisioned company's purchase input tax onto the output account, so G82 adds
 * the parent and component rows and changes no posted account.
 */
const TAXES: { code: string; name: string; prc: number; isGst?: boolean }[] = [
  { code: '00', name: 'TAX FREE', prc: 0 },
  { code: '10', name: 'GST 3%', prc: 3, isGst: true },
  { code: '11', name: 'GST 5%', prc: 5, isGst: true },
  { code: '12', name: 'GST 12%', prc: 12, isGst: true },
  { code: '13', name: 'GST 18%', prc: 18, isGst: true },
  { code: '14', name: 'GST 28%', prc: 28, isGst: true },
  { code: '20', name: 'TCS 0.1%', prc: 0.1 },
];

/** The desktop component layout for a GST code: SR_NO 1 SGST (half), 2 CGST (half), 3 IGST (full). */
function gstComponents(prc: number): Array<{ srNo: number; group: string; prc: number }> {
  const half = round(prc / 2, 4);
  return [
    { srNo: 1, group: 'SGST', prc: half },
    { srNo: 2, group: 'CGST', prc: half },
    { srNo: 3, group: 'IGST', prc },
  ];
}

/** Voucher books the web writes (CO_BOOK literals) → friendly names. */
/**
 * Books a new company starts with.
 *
 * Each carries the `MAIN_BOOK`, direction and posting account that `bookPolicy` needs, because a book
 * without them cannot post: `resolveBookAccountTx` reads `BOOK_DETL` for the contra/control account and
 * fails closed rather than inventing one. Provisioning previously created only `BOOK_DATA`, so a freshly
 * provisioned company hit `book <X> account row 1 is missing` on its first voucher — found by running the
 * application, not by any test.
 */
const BOOKS: {
  book: string;
  name: string;
  /** When set, MAIN_BOOK and direction come from `workflowPolicy` so they can never drift out of step. */
  workflow?: BookWorkflow;
  mainBook?: string;
  inout?: string;
  acCode: string;
  /** BOOK_DETL slots when they differ from the sale-book layout (1 control, 2 cash, 3 round-off). */
  slots?: Array<{ srNo: number; acCode: string }>;
  /** BOOK_SNAME (the VCH_TYPE) when it is the desktop's, not the book code. */
  shortName?: string;
  /** BOOK_TBL_NAME, for the families that route by it. */
  table?: string;
}[] = [
  { book: 'SL', name: 'Sales', workflow: 'SALES', acCode: 'SALES' },
  { book: 'PR', name: 'Purchase', workflow: 'PURCHASE', acCode: 'PURCHASE' },
  // Desktop TR_PURC_HM 'Tag Wise Purc' book (MDI_FORM.cs:8540) — a TAG PURCHASE book posts through the
  // same Purc_* routines as PURCHASE, so a fresh company can use the hallmark-purchase screen (G02).
  {
    book: 'TPR',
    name: 'Hallmark Purchase',
    mainBook: 'TAG PURCHASE',
    inout: 'I',
    acCode: 'PURCHASE',
  },
  // Desktop TR_OTH_PURC books: 375 OTINC 'OTH INC' (I) and 355 OTEXP 'OTH EXP' (O). Without them a fresh
  // company opened Other Income / Other Expenses to "No active books" (G03/G17, provisioning gap).
  {
    book: 'OIN',
    name: 'Other Income',
    mainBook: 'OTH INC',
    inout: 'I',
    acCode: 'INTINC',
    shortName: 'OTINC',
    slots: [{ srNo: 1, acCode: 'INTINC' }],
  },
  {
    book: 'OEX',
    name: 'Other Expenses',
    mainBook: 'OTH EXP',
    inout: 'O',
    acCode: 'OTHCHRG',
    shortName: 'OTEXP',
    slots: [{ srNo: 1, acCode: 'OTHCHRG' }],
  },
  { book: 'SRT', name: 'Sales Return', workflow: 'SALES RETURN', acCode: 'SALES' },
  { book: 'PRT', name: 'Purchase Return', workflow: 'PURCHASE RETURN', acCode: 'PURCHASE' },
  // Cash books: slot 1 is the cash account and slot 2 the kasar write-off account
  // (Ac_Ledr.cs:567-581, legs 01-08 join BOOK_DETL SR_NO 1 and SR_NO 2). The sale-book layout put CASH
  // in slot 2 as well, which would post a write-off to cash.
  {
    book: 'RCT',
    name: 'Receipt',
    mainBook: 'RECEIPT',
    inout: 'I',
    acCode: 'CASH',
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'KASAR' },
    ],
  },
  {
    book: 'PAY',
    name: 'Payment',
    mainBook: 'PAYMENT',
    inout: 'O',
    acCode: 'CASH',
    slots: [
      { srNo: 1, acCode: 'CASH' },
      { srNo: 2, acCode: 'KASAR' },
    ],
  },
  { book: 'SOR', name: 'Sales Order', mainBook: 'SALES ORDER', inout: 'O', acCode: 'SALES' },
  { book: 'TUR', name: 'Approval Issue', mainBook: 'APPROVAL ISSUE', inout: 'O', acCode: 'OS' },
  { book: 'TRR', name: 'Approval Return', mainBook: 'APPROVAL RETURN', inout: 'I', acCode: 'OS' },
  { book: 'SAJ', name: 'Stock Adjust', mainBook: 'STOCK ADJUST', inout: 'I', acCode: 'KASAR' },
  // Desktop TR_INOUT branch transfer: Stock In opens on MAIN_BOOK 'INWORD' and Stock Out on 'OUTWORD'
  // (MDI_FORM.cs:8159/8136; the signed metal posts against the branch account on LOCT_MAST, not a book slot).
  // Without them `StockInoutForm`'s book list is empty and Save stays disabled (N91/G105).
  {
    book: 'SIN',
    name: 'Stock In',
    mainBook: 'INWORD',
    inout: 'I',
    acCode: 'BRANCH',
    shortName: 'STKIN',
  },
  {
    book: 'SOT',
    name: 'Stock Out',
    mainBook: 'OUTWORD',
    inout: 'O',
    acCode: 'BRANCH',
    shortName: 'STKOT',
  },
  // Desktop TR_TAG_CAN serves both menus on its own MAIN_BOOK (MDI_FORM.cs:8586 "TAG CANCEL", :8664 "TAG TRFR"),
  // numbered from BAR_CAN_DATA (MS_UPDATE.cs:7825). The desktop's own short names are TGCAN and TAGTR
  // (`project-memory/parity/verify-stock-tags.md` §0). 'TAG TRANSFER', provisioned before, is no desktop MAIN_BOOK.
  {
    book: 'TGC',
    name: 'Tag Cancel',
    mainBook: 'TAG CANCEL',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'TGCAN',
    table: 'BAR_CAN_DATA',
  },
  {
    book: 'TTR',
    name: 'Tag Transfer',
    mainBook: 'TAG TRFR',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'TAGTR',
    table: 'BAR_CAN_DATA',
  },
  // Desktop TR_TAG_SPLIT on a TAG SPLIT book (MDI_FORM.cs:8686 "Tag Split"), short name TGSPL, numbered from
  // LBR_DATA (its header table). Ac_Ledr.Tag_Split_Ledr (Ac_Ledr.cs:1953-1982) posts the absorbing legs from
  // BOOK_DETL slots 5 (labour), 6/7 (gold DR/CR fine) and 8/9 (silver DR/CR fine); provisioning wires them so a
  // split with a difference and an absorbing account can post.
  {
    book: 'TSP',
    name: 'Tag Split',
    mainBook: 'TAG SPLIT',
    inout: 'O',
    acCode: 'KASAR',
    shortName: 'TGSPL',
    table: 'LBR_DATA',
    slots: [
      { srNo: 5, acCode: 'LBREXP' },
      { srNo: 6, acCode: 'PURCHASE' },
      { srNo: 7, acCode: 'SALES' },
      { srNo: 8, acCode: 'PURCHASE' },
      { srNo: 9, acCode: 'SALES' },
    ],
  },
  { book: 'ILT', name: 'Item Lot', mainBook: 'ITEM LOT', inout: 'I', acCode: 'PURCHASE' },
  // Desktop TR_KR_ISU karigar books (MDI_FORM.cs:9153 'KARIGAR ISSUE', :9165 'KARIGAR RECEIPT'), over
  // KR_DATA. Issue sends metal out to the karigar; receipt takes finished metal back in. Without them a
  // fresh company could not open Karigar Issue / Receive at all — the writer refuses a book-less scope
  // ('company year and book are required'). G19.
  {
    book: 'KRI',
    name: 'Karigar Issue',
    mainBook: 'KARIGAR ISSUE',
    inout: 'O',
    acCode: 'PURCHASE',
    shortName: 'KRISU',
    table: 'KR_DATA',
  },
  {
    book: 'KRR',
    name: 'Karigar Receipt',
    mainBook: 'KARIGAR RECEIPT',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'KRREC',
    table: 'KR_DATA',
  },
  // Desktop Job-work/Jadtar dispatch is JDTR ISU / JDTR REC (MDI_FORM.cs:9717/9726), both over
  // MFG_DATA/MFG_DETL (MS_UPDATE.cs:7913). The shared KarigarForm now sends the selected book.
  {
    book: 'JDI',
    name: 'Jadtar Issue',
    mainBook: 'JDTR ISU',
    inout: 'O',
    acCode: 'PURCHASE',
    shortName: 'JDISU',
    table: 'MFG_DATA',
  },
  {
    book: 'JDR',
    name: 'Jadtar Receipt',
    mainBook: 'JDTR REC',
    inout: 'I',
    acCode: 'PURCHASE',
    shortName: 'JDREC',
    table: 'MFG_DATA',
  },
  { book: 'JV', name: 'Journal', mainBook: 'JOURNAL', inout: 'I', acCode: 'KASAR' },
  { book: 'CON', name: 'Contra', mainBook: 'CONTRA', inout: 'I', acCode: 'CASH' },
  // Desktop Dhiran (pledge loan): the Pledge Loan Issue menu opens on MAIN_BOOK 'DHIRAN ISSUE' and Pledge
  // Receipt on 'DHIRAN RECEIPT' (MDI_FORM.cs:9527/9539, Dhiran_Form). The issue writes DHRN_ISU_DATA and the
  // receipt DHRN_REC_DATA; both post against the DHRN receivable. Without them the Pledge Loan screens have
  // no book to select and Save is refused on a provisioned company (N97, same class as the Stock In/Out gap).
  {
    book: 'DHI',
    name: 'Dhiran Issue',
    mainBook: 'DHIRAN ISSUE',
    inout: 'O',
    acCode: 'DHRN',
    shortName: 'DHIS',
    table: 'DHRN_ISU_DATA',
  },
  {
    book: 'DHR',
    name: 'Dhiran Receipt',
    mainBook: 'DHIRAN RECEIPT',
    inout: 'I',
    acCode: 'DHRN',
    shortName: 'DHRC',
    table: 'DHRN_REC_DATA',
  },
  // Desktop TR_WH_SALE serves both: book 034 `WSALE` / `WH SALES` and book 064 `RCUT` / `RATE CUT`, each an OUT
  // book over RATE_CUT_DATA. Without them a new company had no book either screen could post to, and the Rate
  // Cut screen fell back to the cash Receipt book.
  {
    book: 'WHS',
    name: 'Wholesale Sale',
    mainBook: 'WH SALES',
    inout: 'O',
    acCode: 'SALES',
    slots: WHOLESALE_SLOTS,
    shortName: 'WSALE',
    table: 'RATE_CUT_DATA',
  },
  // Desktop book 434 WHQUT / WH QUOT uses TR_WH_SALE's document grids, while its posting routines
  // exclude WH QUOT. Empty slots are deliberate: a quotation must not need or imply ledger accounts.
  {
    book: 'WHQ',
    name: 'Wholesale Quotation',
    mainBook: 'WH QUOT',
    inout: 'O',
    acCode: 'SALES',
    slots: [],
    shortName: 'WHQUT',
    table: 'RATE_CUT_DATA',
  },
  {
    book: 'RTC',
    name: 'Rate Cut',
    mainBook: 'RATE CUT',
    inout: 'O',
    acCode: 'SALES',
    slots: WHOLESALE_SLOTS,
    shortName: 'RCUT',
    table: 'RATE_CUT_DATA',
  },
];

export interface SeedResult {
  coCode: string;
  created: {
    coMast: boolean;
    accounts: number;
    taxes: number;
    books: number;
    srno: boolean;
    coSet: boolean;
    /** The location and fiscal year without which the company cannot be entered at all. */
    locality: boolean;
    year: boolean;
  };
}

export async function seedCompany(
  prisma: any,
  tenantId: string,
  coCode: string,
  opts?: { coName?: string; lcCode?: string },
): Promise<SeedResult> {
  if (!coCode) throw new Error('coCode is required');
  const lcCode = opts?.lcCode ?? '01';
  // The fiscal year the desktop would open: April-to-March around today.
  const y = new Date().getFullYear();
  return withTxBudget(prisma, tenantId, 'heavy', async (tx: any) => {
    /**
     * Does this company lack the row we are about to create?
     *
     * The tenant predicate is written into every query explicitly rather than left to RLS. Relying on
     * RLS made this function silently do nothing when handed an owner connection: the owner bypasses
     * row-level security, so `WHERE "CO_CODE"='01'` matched some OTHER tenant's company, every check
     * reported "already present", nothing was inserted, and the result came back
     * `created: {…all false}` — indistinguishable from a company that was genuinely already
     * provisioned. It worked in the running application only because the app connects as a non-owner.
     *
     * Same defect class as the message-log isolation bug: a query that filters on a business key and
     * leans on RLS for the tenant is correct under one connection type only. An explicit predicate is
     * correct under both.
     */
    const absent = async (table: string, where: string, ...p: unknown[]): Promise<boolean> => {
      const sql = `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND ${where}`;
      return Number((await tx.$queryRawUnsafe(sql, tenantId, ...p))[0]?.n ?? 0) === 0;
    };
    let coMast = false,
      accounts = 0,
      taxes = 0,
      books = 0,
      srno = false,
      coSet = false,
      locality = false,
      year = false;

    if (await absent('CO_MAST', '"CO_CODE"=$2', coCode)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES ($1,$2,$3,$4)`,
        tenantId,
        coCode,
        opts?.coName ?? `Company ${coCode}`,
        lcCode,
      );
      coMast = true;
    }
    for (const a of SYSTEM_ACCOUNTS) {
      if (await absent('AC_MAST', '"CO_CODE"=$2 AND "AC_CODE"=$3', coCode, a.code)) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,$2,$3,$4,$5,$6)`,
          tenantId,
          coCode,
          lcCode,
          a.code,
          a.name,
          a.gr,
        );
        accounts += 1;
      }
    }
    for (const t of TAXES) {
      // Parent row at SR_NO 0 — the row the resolver pins a named code to (G82).
      if (
        await absent(
          'TAX_MAST',
          '"CO_CODE"=$2 AND "TAX_CODE"=$3 AND coalesce("SR_NO",0)=0',
          coCode,
          t.code,
        )
      ) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP") VALUES ($1,$2,$3,0,$4,$5,'N')`,
          tenantId,
          coCode,
          t.code,
          t.name,
          t.prc,
        );
        taxes += 1;
      }
      // SGST / CGST / IGST component rows at SR_NO 1..3 for a GST code.
      if (t.isGst) {
        for (const c of gstComponents(t.prc)) {
          if (
            await absent(
              'TAX_MAST',
              '"CO_CODE"=$2 AND "TAX_CODE"=$3 AND coalesce("SR_NO",0)=$4',
              coCode,
              t.code,
              c.srNo,
            )
          ) {
            await tx.$executeRawUnsafe(
              `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP") VALUES ($1,$2,$3,$4,$5,$6,$7)`,
              tenantId,
              coCode,
              t.code,
              c.srNo,
              `${t.name} ${c.group}`,
              c.prc,
              c.group,
            );
            taxes += 1;
          }
        }
      }
    }
    for (const b of BOOKS) {
      // MAIN_BOOK / direction come from workflowPolicy when the book backs a workflow, so provisioning
      // cannot spell them differently from the resolver that validates them.
      const wf = b.workflow ? workflowPolicy[b.workflow] : undefined;
      const mainBook = wf?.mainBook ?? b.mainBook ?? b.name.toUpperCase();
      const inout = wf?.inout ?? b.inout ?? 'I';
      if (
        await absent(
          'BOOK_DATA',
          '"CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4',
          coCode,
          lcCode,
          b.book,
        )
      ) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
             "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
           VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y',$9)`,
          tenantId,
          coCode,
          lcCode,
          b.book,
          b.name,
          b.shortName ?? b.book,
          mainBook,
          inout,
          b.table ?? null,
        );
        // BOOK_DETL carries ONE ROW PER POSTING LEG, and `bookPolicy.resolveBookAccountTx` asks for a
        // specific SR_NO. The sale path alone resolves three: 1 = the control/sales account, 2 = the
        // cash/bank account a settlement lands in, 3 = the round-off / kasar account. Creating only row 1
        // produced `book SL account row 2 is missing` on the first cash sale.
        const legs: Array<{ srNo: number; acCode: string }> = b.slots ?? [
          { srNo: 1, acCode: b.acCode },
          { srNo: 2, acCode: 'CASH' },
          { srNo: 3, acCode: 'ROUNDOFF' },
        ];
        for (const leg of legs) {
          await tx.$executeRawUnsafe(
            `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME",
               "BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
             VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,'L')`,
            tenantId,
            coCode,
            lcCode,
            b.book,
            leg.srNo,
            b.name,
            b.shortName ?? b.book,
            mainBook,
            inout,
            leg.acCode,
            leg.acCode,
          );
        }
        books += 1;
      }
    }
    if (await absent('SRNO_MAST', '"CO_CODE"=$2 AND "LC_CODE"=$3', coCode, lcCode)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,0,0)`,
        tenantId,
        coCode,
        lcCode,
      );
      srno = true;
    }
    // A company with no LOCATION cannot be selected: resolveLoginScope() cannot build a scope without
    // one, and /context/select answers `location-unavailable`. Provisioning previously created the books
    // and accounts but not the location, so a provisioned company was unreachable through the UI.
    if (await absent('LOCT_MAST', '"CO_CODE"=$2 AND "LC_CODE"=$3', coCode, lcCode)) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE") VALUES ($1,$2,$3,$4,$5)`,
        tenantId,
        coCode,
        lcCode,
        'Main Counter',
        // The branch account TR_INOUT posts stock in/out against (MS_LOCT.cs:3458; N91/G105).
        'BRANCH',
      );
      locality = true;
    }
    // Likewise a fiscal year: businessScope.year() filters by company, and without a row every business
    // endpoint answers `scope-incomplete`.
    if (await absent('YEAR_MAST', '"CO_CODE"=$2', coCode)) {
      const startYear = new Date().getMonth() + 1 >= 4 ? y : y - 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,$4,$5)`,
        tenantId,
        coCode,
        `${startYear}-${startYear + 1}`,
        new Date(Date.UTC(startYear, 3, 1)),
        new Date(Date.UTC(startYear + 1, 2, 31)),
      );
      year = true;
    }
    if (await absent('CO_SET', '"CO_CODE"=$2', coCode)) {
      // The desktop never leaves the amount types NULL. The schema upgrade backfills them
      // (Ac_Image.cs:6221 `SL_AMT_TYPE = 'N'`, :7101 `PR_AMT_TYPE = 'F'`) and company open repeats
      // it in memory (MS_OPNCOMP.cs:881-888). The loader applies the same defaults to a blank
      // value, but storing them here makes a web company's CO_SET read like a desktop one.
      await tx.$executeRawUnsafe(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","SL_AMT_TYPE","PR_AMT_TYPE") VALUES ($1,$2,'N','F')`,
        tenantId,
        coCode,
      );
      coSet = true;
    }
    return { coCode, created: { coMast, accounts, taxes, books, srno, coSet, locality, year } };
  });
}
