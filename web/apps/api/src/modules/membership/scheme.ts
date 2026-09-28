import { withTenant } from '@datacare/db';
import {
  buildMoneyRojmel,
  buildSchemeAdjRojmel,
  type RojmelContext,
  type RojmelRow,
} from '../shared/rojmel.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import { buildTransferLedger, type PayMode } from '../finance/finance.js';
import { resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';

/**
 * Saving Schemes (Phase 9 — desktop BtmSchm + Module_Schm). A customer joins a monthly gold/amount
 * saving scheme (AD_MAST master → AD_MEMB membership), pays monthly installments (AD_DATA detail +
 * AD_OS outstanding), and redeems the accrued balance at maturity. Each installment is money the
 * shop now OWES the member back as gold/cash at maturity, so the financial leg is a balanced receipt:
 * Dr cash/bank (money in) / Cr the scheme-liability account (AD_MAST.SCHM_AC).
 *
 * Column fidelity: AD_MAST PK = (tenant_id, CO_CODE, SCHM_CODE) — note no LC_CODE on the master.
 * AD_MEMB PK = (…, LC_CODE, SCHM_CODE, MEMB_CODE). AD_DATA / AD_OS share the voucher key
 * (…, CO_YEAR, CO_BOOK, VCH_NO, SR_NO). Only columns confirmed to exist in the live DB are written.
 */
export class SchemeError extends Error {
  constructor(m: string) {
    super(m);
    // Name ends in 'ValidationError' so the route adapter (routes/txn.ts `run`) maps it to HTTP 400
    // — matching FinanceValidationError / MembershipError handling (was 500 before).
    this.name = 'SchemeValidationError';
  }
}

/**
 * Desktop member-scheme book / voucher tags (verified vs live BOOK_DATA + 2622 real AC_DATA legs).
 * VCH_TYPE = desktop BOOK_SNAME; AC_DATA/AD_DATA/AD_OS BOOK_NAME = desktop MAIN_BOOK. The monthly
 * installment is book 074 "Member Monthly Entry" (075 is "Member Opening Entry"); maturity/redemption
 * is book 076 "Member Advance Adjust" → AD_ADJ.
 */
export const MEMB_ENTRY = { book: '074', vchType: 'MBENT', bookName: 'MEMB ENTRY' } as const;
export const MEMB_OPENING = { book: '075', vchType: 'MBOP', bookName: 'MEMB OPENING' } as const;
export const MEMB_ADJUST = { book: '076', vchType: 'MBADJ', bookName: 'MEMB ADJUST' } as const;
export const MEMB_GOLD_ADJUST = {
  book: '176',
  vchType: 'MGADJ',
  bookName: 'MEMB GOLD ADJ',
} as const;

/** Monthly-installment tags (desktop 074 / MBENT / 'MEMB ENTRY'). */
const SCHEME_BOOK = MEMB_ENTRY.book;
const BOOK_NAME = MEMB_ENTRY.bookName;
const VCH_TYPE = MEMB_ENTRY.vchType;
/** Fallback liability account when AD_MAST.SCHM_AC is unset (keeps the ledger balanced). */
const DEFAULT_SCHEME_AC = 'SCHEME';

const numv = (v: unknown): number => Number(v ?? 0);
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const trimTo = (v: unknown, len: number): string | null => {
  const t = String(v ?? '').trim();
  return t ? t.slice(0, len) : null;
};
const boolFlag = (v: unknown): boolean =>
  v === true ||
  String(v ?? '')
    .trim()
    .toUpperCase() === 'Y';

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

function keyOf(s: VoucherScope, vchNo: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export interface EnrollSchemeInput {
  scope: VoucherScope;
  schmCode: string;
  membCode?: string; // member-in-scheme code; auto-generated (5-digit) when omitted
  membName?: string;
  monthlyAmt: number;
  months?: number; // advisory only — AD_MEMB has no per-member months column (duration lives on AD_MAST.SCHM_MONTH)
  /**
   * Desktop AD_MEMB member record fields (Module_Schm.cs:489). All optional: a desktop form leaves
   * blank fields NULL, and the same applies here.
   */
  itemGrossWt?: number; // ITM_GWT — gold-weight schemes
  empCode?: string;
  phone?: string;
  phone2?: string;
  mobile?: string;
  mobile2?: string;
  address1?: string;
  address2?: string;
  address3?: string;
  city?: string;
  district?: string;
  area?: string;
  pin?: string;
  email?: string;
  idProof?: string; // ID_PROF (KYC document reference)
  nomineeName?: string;
  birthDate?: Date | string;
  anniversaryDate?: Date | string; // ANV_DATE
  lastBrokenDate?: Date | string; // L_BR_DATE
  joinDate?: Date | string; // defaults to today, as the desktop does
  expiryDate?: Date | string;
  bankName?: string;
  bankArea?: string;
  bankAcNo?: string;
  bankRtgsNo?: string;
  refCode?: string; // AC_REF_CODE (introducer/reference)
  schemeShort?: string; // SCHM_SHORT
  membBonus?: number; // MEMB_BONUS
  mainUser?: string;
}

export interface EnrollSchemeResult {
  membNo: string;
}

/**
 * Enroll a customer into a saving scheme — writes one AD_MEMB row. The scheme (AD_MAST) must exist.
 * If `membCode` is supplied it is used as the member number (and must be unique within the scheme);
 * otherwise the next sequential 5-digit MEMB_CODE for that scheme is allocated.
 */
export async function enrollScheme(
  prisma: any,
  input: EnrollSchemeInput,
): Promise<EnrollSchemeResult> {
  const { scope, schmCode } = input;
  if (!schmCode) throw new SchemeError('scheme code is required');
  const monthlyAmt = numv(input.monthlyAmt);
  if (!(monthlyAmt > 0)) throw new SchemeError('monthly amount must be positive');

  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    // Scheme master must exist (AD_MAST is keyed by CO_CODE + SCHM_CODE — no LC_CODE).
    const sch: any[] = await tx.$queryRawUnsafe(
      `SELECT "SCHM_NAME" FROM "AD_MAST" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 LIMIT 1`,
      scope.coCode,
      schmCode,
    );
    if (!sch.length) throw new SchemeError(`scheme ${schmCode} not found`);

    let membNo = (input.membCode ?? '').trim();
    if (membNo) {
      const ex: unknown[] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "AD_MEMB" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "SCHM_CODE"=$3 AND "MEMB_CODE"=$4 LIMIT 1`,
        scope.coCode,
        scope.lcCode,
        schmCode,
        membNo,
      );
      if (ex.length)
        throw new SchemeError(`member ${membNo} already enrolled in scheme ${schmCode}`);
    } else {
      // Next numeric member code within the scheme (ignore any non-numeric legacy codes).
      const nx: any[] = await tx.$queryRawUnsafe(
        `SELECT COALESCE(MAX(CAST("MEMB_CODE" AS INTEGER)),0)+1 AS next FROM "AD_MEMB"
         WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "SCHM_CODE"=$3 AND "MEMB_CODE" ~ '^[0-9]+$'`,
        scope.coCode,
        scope.lcCode,
        schmCode,
      );
      membNo = String(numv(nx[0]?.next) || 1).padStart(5, '0');
    }

    const membName =
      (input.membName ?? '').trim() ||
      (sch[0]?.SCHM_NAME != null ? String(sch[0].SCHM_NAME) : null);
    // Desktop AD_MEMB is the member record: identity, contact, KYC, key dates, bank details and
    // scheme linkage (Module_Schm.cs:489, the shared writer TR_MEMB_ENT calls). Blank desktop fields
    // persist as NULL/'' , which an absent input reproduces.
    const mt = (v: unknown, len: number): string | null =>
      String(v ?? '')
        .trim()
        .slice(0, len) || null;
    const md = (v: unknown): Date | null => (v ? new Date(v as string) : null);
    await tx.$executeRawUnsafe(
      `INSERT INTO "AD_MEMB"(
         tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME","MEMB_AMT","ITM_GWT",
         "EMP_CODE","AC_PHONE","AC_MOBILE","AC_ADD1","AC_ADD2","AC_ADD3","AC_CITY","AC_PIN",
         "AC_AREA","AC_MOBILE2","AC_PHONE2","ID_PROF","NOMINEE_NAME","AC_EMAIL","AC_DISTRICT",
         "BIRTH_DATE","ANV_DATE","L_BR_DATE","JOIN_DATE","EXP_DATE","BANK_NAME","BANK_AREA",
         "BANK_AC_NO","BANK_RTGS_NO","AC_REF_CODE","SCHM_SHORT","MEMB_BONUS","DATA_TRFR","MAIN_USER")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15,$16,$17,$18,$19,$20,$21,$22,$23,
               $24,$25,$26,$27,$28,$29,$30,$31,$32,$33,$34,$35,$36,$37)`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      schmCode,
      membNo,
      membName,
      monthlyAmt,
      numv(input.itemGrossWt), // ITM_GWT — gold-weight schemes
      mt(input.empCode, 3),
      mt(input.phone, 15),
      mt(input.mobile, 15),
      mt(input.address1, 50),
      mt(input.address2, 50),
      mt(input.address3, 50),
      mt(input.city, 20),
      mt(input.pin, 10),
      mt(input.area, 25),
      mt(input.mobile2, 15),
      mt(input.phone2, 15),
      mt(input.idProof, 50),
      mt(input.nomineeName, 50),
      mt(input.email, 50),
      mt(input.district, 25),
      md(input.birthDate),
      md(input.anniversaryDate),
      md(input.lastBrokenDate),
      input.joinDate ? new Date(input.joinDate) : new Date(),
      md(input.expiryDate),
      mt(input.bankName, 50),
      mt(input.bankArea, 25),
      mt(input.bankAcNo, 25),
      mt(input.bankRtgsNo, 25),
      mt(input.refCode, 10),
      mt(input.schemeShort, 10),
      numv(input.membBonus),
      'N',
      mt(input.mainUser, 10) ?? 'system',
    );
    return { membNo };
  });
}

export interface SchemeUpiLine {
  /** ISR_NO in UPI_DATA: split row number inside the member line. Defaults to 1..n. */
  srNo?: number;
  upiAcCode?: string;
  upiAcName?: string;
  upiType?: string;
  upiId?: string;
  amount: number;
}

export interface SchemeInstallmentInput {
  scope: VoucherScope;
  schmCode: string;
  membCode: string;
  amount: number;
  mode?: PayMode; // defaults to cash
  liabAc?: string; // override scheme-liability AC; else AD_MAST.SCHM_AC
  bankAc?: string; // cash/bank ledger receiving the money (for non-cash modes)
  chqNo?: string;
  vchDate?: Date | string;
  mainUser?: string;
  /** BANK_NAME — the settling bank as printed on the instrument. */
  bankName?: string;
  /** EMP_CODE — varchar(3); the employee who collected the instalment. */
  empCode?: string;
  /** MONTH_CODE — varchar(2); which scheme month this instalment covers. */
  monthCode?: string;
  /** WITH_UPI — 'Y' when the money arrived over UPI. */
  withUpi?: boolean;
  /** Single-row UPI detail. When `upiLines` is supplied it wins. */
  upiAcCode?: string;
  upiAcName?: string;
  upiType?: string;
  upiId?: string;
  upiAmount?: number;
  /** Desktop UPI_DATA split rows for one member line. */
  upiLines?: SchemeUpiLine[];
  /**
   * A day's collection round as ONE voucher, which is what the desktop's TR_MEMB_ENT grid produces.
   * Measured on the real database: 812 of 1428 member-entry vouchers carry more than one member and
   * one opening voucher carries 175. The desktop posts a Dr/Cr ledger PAIR PER LINE, not one
   * aggregate pair — verified at 11 members/22 legs, 7/14 and 6/12 — so each line settles against its
   * own scheme's liability account and the lines may span different schemes.
   *
   * When omitted, the flat schmCode/membCode/amount fields above are treated as a single line, so the
   * one-member call shape stays valid.
   */
  lines?: SchemeInstallmentLine[];
}

/** One member's instalment within a member-entry voucher (AD_DATA/AD_OS SR_NO 1..n). */
export interface SchemeInstallmentLine {
  schmCode: string;
  membCode: string;
  amount: number;
  /** Overrides the scheme's AD_MAST.SCHM_AC for this line only. */
  liabAc?: string;
  chqNo?: string;
  bankName?: string;
  empCode?: string;
  monthCode?: string;
  withUpi?: boolean;
  upiAcCode?: string;
  upiAcName?: string;
  upiType?: string;
  upiId?: string;
  upiAmount?: number;
  upiLines?: SchemeUpiLine[];
}

export interface SchemeInstallmentResult {
  vchNo: number;
}

/** Member-entry variant tags. Desktop TR_MEMB_ENT writes either the monthly 074 MBENT entry or the
 *  075 MBOP opening entry from the SAME form — only book/VCH_TYPE/BOOK_NAME and ENT_TYPE differ. */
type MemberEntryTags = { book: string; vchType: string; bookName: string; entType: 'E' | 'O' };

/**
 * Shared writer for a member scheme entry. Allocates a voucher number, posts a balanced AC_DATA pair
 * (Dr cash/bank, Cr scheme liability) and writes the scheme detail (AD_DATA, ENT_TYPE per variant) +
 * outstanding (AD_OS, OS_TYPE 'A' / SIGN '+' — increases the member's accrued balance), all in one
 * tenant transaction. Backs both the monthly installment (074 MBENT) and the opening entry (075 MBOP).
 */
type SchemeWriteContext = {
  tx: any;
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
};

type NormalizedSchemeUpiRow = {
  lineNo: number;
  isrNo: number;
  schmCode: string;
  membCode: string;
  upiAcCode: string;
  upiAcName: string;
  upiType: string;
  upiId: string;
  amount: number;
};

function lineRequestsUpi(line: SchemeInstallmentLine, mode: PayMode): boolean {
  return (
    boolFlag(line.withUpi) ||
    mode === 'upi' ||
    Boolean(line.upiLines?.length) ||
    Boolean(trimTo(line.upiAcCode, 8)) ||
    Boolean(trimTo(line.upiId, 25)) ||
    Boolean(trimTo(line.upiType, 25)) ||
    numv(line.upiAmount) > 0
  );
}

function normalizeUpiRows(
  line: SchemeInstallmentLine,
  mode: PayMode,
  lineNo: number,
  fallbackAc: string,
): NormalizedSchemeUpiRow[] {
  if (!lineRequestsUpi(line, mode)) return [];
  const explicitRows = line.upiLines?.length
    ? line.upiLines
    : [
        {
          srNo: 1,
          upiAcCode: line.upiAcCode || fallbackAc,
          upiAcName: line.upiAcName || line.bankName || '',
          upiType: line.upiType || 'UPI',
          upiId: line.upiId || line.chqNo || '',
          amount: numv(line.upiAmount) || numv(line.amount),
        },
      ];
  const seen = new Set<number>();
  const rows = explicitRows.map((r, i) => {
    const isrNo = Number(r.srNo ?? i + 1);
    if (!Number.isFinite(isrNo) || isrNo <= 0) {
      throw new SchemeError(`UPI split row number must be positive (line ${lineNo})`);
    }
    if (seen.has(isrNo)) throw new SchemeError(`duplicate UPI split row ${isrNo} (line ${lineNo})`);
    seen.add(isrNo);
    const amount = round2(numv(r.amount));
    if (!(amount > 0)) throw new SchemeError(`UPI amount must be positive (line ${lineNo})`);
    const upiAcCode = trimTo(r.upiAcCode || fallbackAc, 8);
    if (!upiAcCode) throw new SchemeError(`UPI account is required (line ${lineNo})`);
    return {
      lineNo,
      isrNo,
      schmCode: line.schmCode,
      membCode: line.membCode,
      upiAcCode,
      upiAcName: trimTo(r.upiAcName || line.bankName, 50) ?? '',
      upiType: trimTo(r.upiType, 25) ?? 'UPI',
      upiId: trimTo(r.upiId || line.chqNo, 25) ?? '',
      amount,
    };
  });
  const total = round2(rows.reduce((sum, r) => sum + r.amount, 0));
  const expected = round2(numv(line.amount));
  if (total !== expected) {
    throw new SchemeError(
      `UPI split total ${total} must equal member amount ${expected} (line ${lineNo})`,
    );
  }
  return rows;
}

function upiNameOf(rows: NormalizedSchemeUpiRow[]): string | null {
  if (!rows.length) return null;
  const first = rows[0]!;
  const label = [first.upiAcName, first.upiType, first.upiId].filter(Boolean).join(' / ');
  return trimTo(label || 'UPI', 255);
}

function schemeRojmelKey(
  scope: { coCode: string; lcCode: string; coYear: string },
  coBook: string,
  vchNo: string,
  rowType: string,
  lineNo: number,
  isrNo?: number,
): string {
  const head =
    String(scope.coCode).padStart(2, '0').slice(0, 2) +
    String(scope.lcCode).padStart(2, '0').slice(0, 2) +
    String(scope.coYear).padEnd(9).slice(0, 9) +
    String(coBook).padStart(3, '0').slice(0, 3) +
    String(vchNo).padStart(5, '0').slice(0, 5) +
    rowType +
    String(lineNo).padStart(10, ' ');
  return isrNo == null ? head : head + String(isrNo).padStart(10, ' ');
}

function schemeRojmelBlank(ctx: RojmelContext, ledrKey: string): RojmelRow {
  return {
    ...ctx.key,
    LEDR_KEY: ledrKey,
    VCH_DATE: ctx.vchDate,
    VCH_TYPE: ctx.vchType,
    BOOK_NAME: ctx.bookName,
    AC_CODE: '',
    AC_NAME: ctx.partyName,
    LD_CODE: '',
    DR_AMT: 0,
    CR_AMT: 0,
    IT_TYPE: 'A',
    SIGN: '',
    ITM_PCS: 0,
    ITM_GWT: 0,
    ITM_NWT: 0,
    ITM_TOUCH: 0,
    ITM_WEST: 0,
    ITM_FINE: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    NET_AMT: 0,
    IT_DESC: '',
    IT_CODE: '',
  };
}

function buildSchemeUpiRojmel(
  ctx: RojmelContext,
  lines: {
    lineNo: number;
    schmCode: string;
    membCode: string;
    liabAc: string;
    amount: number;
    upiRows: NormalizedSchemeUpiRow[];
  }[],
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  for (const line of lines) {
    if (!line.upiRows.length || !line.amount) continue;
    rows.push({
      ...schemeRojmelBlank(
        ctx,
        schemeRojmelKey(ctx.scope, ctx.coBook, ctx.vchNo, '01', line.lineNo),
      ),
      AC_CODE: line.liabAc,
      LD_CODE: '9999',
      CR_AMT: line.amount,
      SCHM_CODE: line.schmCode,
      MEMB_CODE: line.membCode,
    });
    for (const u of line.upiRows) {
      if (u.upiAcCode === '00001') continue;
      rows.push({
        ...schemeRojmelBlank(
          ctx,
          schemeRojmelKey(ctx.scope, ctx.coBook, ctx.vchNo, '02', line.lineNo, u.isrNo),
        ),
        AC_CODE: u.upiAcCode,
        AC_NAME: u.upiAcName,
        LD_CODE: line.liabAc,
        DR_AMT: u.amount,
        SCHM_CODE: line.schmCode,
        MEMB_CODE: line.membCode,
        REF_NO: u.upiId,
      });
    }
  }
  return rows;
}
async function postMemberEntry(
  prisma: any,
  input: SchemeInstallmentInput,
  tags: MemberEntryTags,
  lifecycle?: SchemeWriteContext,
): Promise<SchemeInstallmentResult> {
  const { scope } = input;
  // Normalise to the grid shape. A single-member call is a one-line voucher.
  const lines: SchemeInstallmentLine[] = input.lines?.length
    ? input.lines
    : [
        {
          schmCode: input.schmCode,
          membCode: input.membCode,
          amount: input.amount,
          liabAc: input.liabAc,
          chqNo: input.chqNo,
          bankName: input.bankName,
          empCode: input.empCode,
          monthCode: input.monthCode,
          withUpi: input.withUpi,
          upiAcCode: input.upiAcCode || input.bankAc,
          upiAcName: input.upiAcName || input.bankName,
          upiType: input.upiType,
          upiId: input.upiId || input.chqNo,
          upiAmount: input.upiAmount,
          upiLines: input.upiLines,
        },
      ];
  if (!lines.length) throw new SchemeError('at least one member line is required');
  lines.forEach((l, i) => {
    const at = input.lines?.length ? ` (line ${i + 1})` : '';
    if (!l.schmCode) throw new SchemeError(`scheme code is required${at}`);
    if (!l.membCode) throw new SchemeError(`member code is required${at}`);
    if (!(numv(l.amount) > 0)) throw new SchemeError(`amount must be positive${at}`);
  });

  const mode: PayMode = input.mode ?? 'cash';
  const tenantId = scope.tenantId;
  const isOpening = tags.entType === 'O';

  const run = async (tx: any): Promise<SchemeInstallmentResult> => {
    // Resolve each distinct scheme once; a grid line may belong to a different scheme than its
    // neighbour, and each settles against its own liability account.
    const liabOf = new Map<string, string>();
    for (const code of new Set(lines.map((l) => l.schmCode))) {
      const sch: any[] = await tx.$queryRawUnsafe(
        `SELECT "SCHM_AC","SCHM_NAME" FROM "AD_MAST" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 LIMIT 1`,
        scope.coCode,
        code,
      );
      if (!sch.length) throw new SchemeError(`scheme ${code} not found`);
      liabOf.set(
        code,
        (sch[0]?.SCHM_AC != null ? String(sch[0].SCHM_AC).trim() : '') || DEFAULT_SCHEME_AC,
      );
    }

    const book = scope.coBook ?? tags.book;
    const sc: VoucherScope = { ...scope, coBook: book };
    const vchNo = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, sc));
    const hdVchNo =
      lifecycle?.hdVchNo ??
      (await nextHiddenVoucherNoTx(tx, sc as VoucherScope & { coBook: string }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key = keyOf(sc, vchNo, book);
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );

    // A Dr/Cr PAIR PER LINE, mirroring the desktop (11 members → 22 AC_DATA legs). One aggregate
    // pair would balance too, so this cannot be caught by a balance assertion alone — the leg count
    // is asserted separately.
    // EXCEPT a MEMB OPENING (entType 'O') posts NO money ledger — desktop TR_MEMB_ENT.cs#L4660 only
    // writes the AD_OS carry-forward for openings, and the real 175-member opening voucher 00086 has
    // 0 AC_DATA legs, confirming it.
    // The desktop's measured leg shape for book 074, from all 2620 real AC_DATA legs:
    //
    //   type 01  the scheme LIABILITY, credited   (1311 rows, one account)
    //   type 02  the RECEIPT account, debited     (1311 rows, cash and four banks)
    //
    // Liability FIRST - type 01 is the credit - and each pair carries the MEMBER LINE in the key, giving 33
    // characters. `buildTransferLedger` is not used here: it emits debit-first, sets no LD_CODE, and is shared
    // with modules whose leg order has not been measured, so changing it would guess on their behalf.
    // The RECEIPT account comes from BOOK_DETL slot 1 when the caller supplies no explicit bank.
    //
    // P0-04: the literal `'CASH'` that used to sit behind this is gone. The real leg-02 rows name 00001 and
    // four banks, and 00001 is book 074's slot 1, so a book with neither an explicit account nor a configured
    // slot now refuses the instalment rather than posting to a code that only exists in the demo seed.
    const recAcResolved = await resolveBookSlotAccountTx(
      tx,
      { ...scope, coBook: scope.coBook ?? tags.book },
      mode === 'cash' ? 'cash-settlement' : 'bank-settlement',
      1,
      input.bankAc,
    );

    const upiRowsByLine = new Map<number, NormalizedSchemeUpiRow[]>();
    const allUpiRows: NormalizedSchemeUpiRow[] = [];
    lines.forEach((line, idx) => {
      const rows = normalizeUpiRows(line, mode, idx + 1, trimTo(input.bankAc, 8) ?? recAcResolved);
      if (rows.length) {
        upiRowsByLine.set(idx + 1, rows);
        allUpiRows.push(...rows);
      }
    });

    const ledger: LedgerLine[] = isOpening
      ? []
      : lines.flatMap((l, idx): LedgerLine[] => {
          const lineNo = idx + 1;
          const liabAc = (l.liabAc ?? '').trim() || liabOf.get(l.schmCode)!;
          const amount = round2(numv(l.amount));
          const upiRows = upiRowsByLine.get(lineNo) ?? [];
          if (upiRows.length) {
            return upiRows.flatMap((u): LedgerLine[] => {
              const suffix = `${String(lineNo).padStart(10, ' ')}${String(u.isrNo).padStart(10, ' ')}`;
              return [
                {
                  ...key,
                  VCH_TYPE: tags.vchType,
                  legKeySuffix: `01${suffix}`,
                  AC_CODE: liabAc,
                  LD_CODE: u.upiAcCode,
                  DR_AMT: 0,
                  CR_AMT: u.amount,
                  CHQ_NO: trimTo(u.upiId, 10) ?? '',
                },
                {
                  ...key,
                  VCH_TYPE: tags.vchType,
                  legKeySuffix: `02${suffix}`,
                  AC_CODE: u.upiAcCode,
                  LD_CODE: liabAc,
                  DR_AMT: u.amount,
                  CR_AMT: 0,
                  CHQ_NO: trimTo(u.upiId, 10) ?? '',
                },
              ];
            });
          }
          const base = { ...key, VCH_TYPE: tags.vchType, legLine: lineNo };
          return [
            {
              ...base,
              legType: 1,
              AC_CODE: liabAc,
              LD_CODE: recAcResolved,
              DR_AMT: 0,
              CR_AMT: amount,
              SIGN: 'C',
            },
            {
              ...base,
              legType: 2,
              AC_CODE: recAcResolved,
              LD_CODE: liabAc,
              DR_AMT: amount,
              CR_AMT: 0,
              SIGN: 'D',
            },
          ];
        });
    if (ledger.length) assertBalanced(ledger);

    const adDataRows = lines.map((l, i) => ({
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      SCHM_CODE: l.schmCode,
      SCHM_DATE: vchDate,
      MEMB_CODE: l.membCode,
      MEMB_AMT: numv(l.amount),
      // TOT_AMT is 0 on all 8160 AD_DATA rows of the real desktop database (Live24). The
      // instalment value lives in MEMB_AMT alone; writing it here too would double-count in any
      // report that sums TOT_AMT.
      TOT_AMT: 0,
      IT_DESC: `Scheme ${l.schmCode} ${isOpening ? 'opening balance' : 'installment'}`,
      ENT_TYPE: tags.entType, // desktop TR_MEMB_ENT (L4567): 'E' = monthly entry, 'O' = MEMB OPENING
      REC_AC: recAcResolved,
      CHQ_NO: l.chqNo ?? null,
      ENTRY_TIME: vchDate,
      VCH_TIME: vchDate,
      VCH_TYPE: tags.vchType,
      INOUT_TYPE: 'I',
      BOOK_NAME: tags.bookName,
      MAIN_USER: mainUser,
      HD_VCH_NO: hdVchNo,
      DATA_TRFR: 'N',
      // TR_MEMB_ENT.cs also records the settlement bank name, the collecting employee, the
      // instalment's month code and whether it came in over UPI. USER_DELETE/USER_UPDATE are the
      // desktop's row-state flags, 'N' until an edit or delete touches the row.
      BANK_NAME: (l.bankName ?? '').trim().slice(0, 50) || null,
      EMP_CODE: (l.empCode ?? '').trim().slice(0, 3) || null,
      MONTH_CODE: (l.monthCode ?? '').trim().slice(0, 2) || null,
      WITH_UPI: (upiRowsByLine.get(i + 1)?.length ?? 0) > 0 ? 'Y' : 'N',
      UPI_NAME: upiNameOf(upiRowsByLine.get(i + 1) ?? []),
      USER_DELETE: 'N',
      USER_UPDATE: 'N',
    }));

    const adOsRows = lines.map((l, i) => ({
      // TR_MEMB_ENT.cs carries the collecting employee, the ledger account the outstanding
      // posts to, and the gold weight side of a metal scheme.
      //
      // LD_CODE is the account the money ARRIVED IN, not the scheme liability. Verified across
      // 8194 real AD_OS rows: 00001 CASH ON HAND (7162), 000754 OLD AXIS BANK CURRENT (714),
      // 000418 OLD HDFC (163), 001023 AXIS CURRENT (33), 000207 SBI (17), blank (91). Writing
      // the liability account here would break any grouping of collections by cash/bank.
      EMP_CODE: (l.empCode ?? '').trim().slice(0, 3) || null,
      LD_CODE: recAcResolved.trim().slice(0, 8) || null,
      GOLD_WT: 0,
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: tags.vchType,
      INOUT_TYPE: 'I',
      // Measured on all 8194 real AD_OS rows: ENTRY_TYPE is 'E' on 8070, 'O' on 90 and 'A' on 34. 'I' appears
      // nowhere, so it was a plausible-looking invention ("instalment") rather than an observed value. It
      // mirrors AD_DATA.ENT_TYPE - 'E' for a monthly entry, 'O' for an opening - and the adjust path already
      // writes 'A' correctly further down.
      ENTRY_TYPE: tags.entType,
      BOOK_NAME: tags.bookName,
      SCHM_CODE: l.schmCode,
      SCHM_DATE: vchDate,
      MEMB_CODE: l.membCode,
      // MEMB_AMT is 0 on all 8194 AD_OS rows of the real desktop database; the movement value
      // lives in ADJ_AMT regardless of OS_TYPE. A member's balance is
      // SUM(A '+') - SUM(D '-') - SUM(B '-') over ADJ_AMT, so populating MEMB_AMT here would
      // make any balance that reads it double the true figure.
      MEMB_AMT: 0,
      ADJ_AMT: numv(l.amount),
      SIGN: '+',
      OS_TYPE: 'A', // 'A' = scheme amount accrued (+) ; redemption later books 'D' (-)
      MAIN_USER: mainUser,
      HD_VCH_NO: hdVchNo,
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
    }));

    const upiDataRows = allUpiRows.map((u) => ({
      ...key,
      SR_NO: u.lineNo,
      ISR_NO: u.isrNo,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      SCHM_CODE: u.schmCode,
      AC_CODE: u.membCode,
      UPI_AC_CODE: u.upiAcCode,
      UPI_AC_NAME: u.upiAcName,
      UPI_TYPE: u.upiType,
      UPI_ID: u.upiId,
      UPI_AMT: u.amount,
      MAIN_USER: mainUser,
      HD_VCH_NO: hdVchNo,
    }));

    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_BOOK: book,
      VCH_NO: hdVchNo,
      BOOK_NAME: tags.bookName,
    });
    // The Rojmel. Book 074 carries 1635 real day-book rows against 1311 instalment lines: one per line
    // for the liability leg, plus a second row per line ONLY when the money landed in a bank. An
    // opening (075) moves no money, so it produces no day-book row at all.
    const rojmelCtx: RojmelContext = {
      scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: sc.coYear! },
      key,
      coBook: book,
      vchNo: key.VCH_NO,
      vchDate,
      vchType: tags.vchType,
      bookName: tags.bookName,
      partyName: '',
      partyCode: recAcResolved,
    };
    const normalRojmelRows = isOpening
      ? []
      : buildMoneyRojmel(
          rojmelCtx,
          lines
            .map((l, i) => ({
              lineNo: i + 1,
              controlAc: (l.liabAc ?? '').trim() || liabOf.get(l.schmCode)!,
              receiptAc: recAcResolved,
              amount: numv(l.amount),
              banked: mode !== 'cash',
              hasUpi: (upiRowsByLine.get(i + 1)?.length ?? 0) > 0,
            }))
            .filter((l) => !l.hasUpi),
        );
    const upiRojmelRows = isOpening
      ? []
      : buildSchemeUpiRojmel(
          rojmelCtx,
          lines.map((l, i) => ({
            lineNo: i + 1,
            schmCode: l.schmCode,
            membCode: l.membCode,
            liabAc: (l.liabAc ?? '').trim() || liabOf.get(l.schmCode)!,
            amount: numv(l.amount),
            upiRows: upiRowsByLine.get(i + 1) ?? [],
          })),
        );
    const rojmelRows = [...normalRojmelRows, ...upiRojmelRows];

    await postVoucherTx(tx, tenantId, {
      bookName: tags.bookName,
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [
        { table: 'AD_DATA', rows: adDataRows },
        ...(upiDataRows.length ? [{ table: 'UPI_DATA', rows: upiDataRows }] : []),
        { table: 'AD_OS', rows: adOsRows },
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return { vchNo };
  };

  return lifecycle ? run(lifecycle.tx) : withTenant(prisma, tenantId, run);
}

/**
 * Record one monthly installment — desktop 074 / MBENT / 'MEMB ENTRY' (AD_DATA.ENT_TYPE='E').
 * Dr cash/bank, Cr scheme liability + AD_DATA + AD_OS ('+', accrued); one tenant transaction.
 */
export async function schemeInstallment(
  prisma: any,
  input: SchemeInstallmentInput,
): Promise<SchemeInstallmentResult> {
  return postMemberEntry(prisma, input, { ...MEMB_ENTRY, entType: 'E' });
}

/**
 * Record a member's opening balance — desktop 075 / MBOP / 'MEMB OPENING' (AD_DATA.ENT_TYPE='O').
 * Same posting shape as an installment; used when migrating an existing member's carried-forward balance.
 */
export async function schemeOpening(
  prisma: any,
  input: SchemeInstallmentInput,
): Promise<SchemeInstallmentResult> {
  return postMemberEntry(prisma, input, { ...MEMB_OPENING, entType: 'O' });
}

export interface DeleteSchemeInstallmentInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string; // CO_BOOK used at creation (defaults to the MEMB ENTRY book '074')
  vchType?: string; // DELETE_DATA log tag (defaults to MBENT; pass 'MBOP' for opening entries)
  deleteUser?: string;
}

/** Delete/reverse a member-entry voucher (installment 074 or opening 075): remove AD_DATA + AD_OS +
 *  AC_DATA by key, log DELETE_DATA. */
type CompleteSchemeScope = VoucherScope & { coYear: string; coBook: string };
const ENTRY_WRITE_TABLES = [
  'AD_DATA',
  'UPI_DATA',
  'AD_OS',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'REMARK_DATA',
] as const;
const ADJUST_WRITE_TABLES = ['AD_ADJ', 'AD_OS', 'AC_DATA', 'ROJ_MEL_DATA', 'REMARK_DATA'] as const;
const text = (v: unknown): string => String(v ?? '').trim();
function schemeScope(scope: VoucherScope, book: string): CompleteSchemeScope {
  if (!scope.coYear) throw new SchemeError('complete voucher scope (coYear) is required');
  return { ...scope, coYear: scope.coYear, coBook: book };
}
const sp = (s: CompleteSchemeScope, v: string): unknown[] => [
  s.tenantId,
  s.coCode,
  s.lcCode,
  s.coYear,
  s.coBook,
  v,
];
export async function getSchemeInstallment(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  book: string = SCHEME_BOOK,
): Promise<Record<string, unknown>> {
  const sc = schemeScope(scope, book),
    v = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT d."SR_NO",d."VCH_NO",d."VCH_DATE"::text,d."VCH_TIME",d."HD_VCH_NO",d."MAIN_USER",d."SCHM_CODE",d."MEMB_CODE",d."MEMB_AMT",d."REC_AC",d."CHQ_NO",d."IT_DESC",d."ENT_TYPE",d."BANK_NAME",d."EMP_CODE",d."MONTH_CODE",d."WITH_UPI",d."UPI_NAME" FROM "AD_DATA" d WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO"`,
      ...sp(sc, v),
    );
    if (!r.length) throw new SchemeError(`scheme installment voucher not found: ${v}`);
    const upi: any[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","ISR_NO","UPI_AC_CODE","UPI_AC_NAME","UPI_TYPE","UPI_ID","UPI_AMT" FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO"`,
      ...sp(sc, v),
    );
    const upiBySr = new Map<number, any[]>();
    for (const u of upi) {
      const sr = numv(u.SR_NO);
      upiBySr.set(sr, [...(upiBySr.get(sr) ?? []), u]);
    }
    const lineOut = r.map((row) => {
      const sr = numv(row.SR_NO);
      const upiLines = (upiBySr.get(sr) ?? []).map((u) => ({
        srNo: numv(u.ISR_NO),
        upiAcCode: text(u.UPI_AC_CODE),
        upiAcName: text(u.UPI_AC_NAME),
        upiType: text(u.UPI_TYPE),
        upiId: text(u.UPI_ID),
        amount: numv(u.UPI_AMT),
      }));
      return {
        srNo: sr,
        schmCode: text(row.SCHM_CODE),
        membCode: text(row.MEMB_CODE),
        amount: numv(row.MEMB_AMT),
        bankAc: text(row.REC_AC),
        chqNo: text(row.CHQ_NO),
        bankName: text(row.BANK_NAME),
        empCode: text(row.EMP_CODE),
        monthCode: text(row.MONTH_CODE),
        withUpi: text(row.WITH_UPI) === 'Y',
        upiName: text(row.UPI_NAME),
        upiLines,
      };
    });
    const x = r[0];
    const first = lineOut[0]!;
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchDate: text(x.VCH_DATE).slice(0, 10),
      schmCode: first.schmCode,
      membCode: first.membCode,
      amount: first.amount,
      bankAc: first.bankAc,
      chqNo: first.chqNo,
      bankName: first.bankName,
      empCode: first.empCode,
      monthCode: first.monthCode,
      withUpi: first.withUpi,
      upiName: first.upiName,
      upiLines: first.upiLines,
      lines: lineOut,
      itDesc: text(x.IT_DESC),
      entryType: text(x.ENT_TYPE),
      book,
    };
  });
}
export async function editSchemeInstallment(
  prisma: any,
  input: SchemeInstallmentInput,
  requestedVoucherNo: number | string,
  book: string = SCHEME_BOOK,
): Promise<SchemeInstallmentResult> {
  const sc = schemeScope(input.scope, book),
    v = formatVoucherNo(requestedVoucherNo),
    requestedDate = input.vchDate ? new Date(input.vchDate) : new Date(),
    tags =
      book === MEMB_OPENING.book
        ? { ...MEMB_OPENING, entType: 'O' as const }
        : { ...MEMB_ENTRY, entType: 'E' as const };
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'AD_DATA',
      scope: sc,
      voucherNo: v,
      extraColumns: [],
    });
    for (const date of [h.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, sc.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: date }] },
      });
    const hd = formatVoucherNo(text(h.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: ENTRY_WRITE_TABLES,
      key: { scope: sc, voucherNo: v },
      tempBook: { voucherNo: hd },
    });
    return postMemberEntry(prisma, { ...input, scope: sc }, tags, {
      tx,
      vchNo: Number(v),
      hdVchNo: hd,
      mainUser: text(h.MAIN_USER),
      persistedClock: h.VCH_CLOCK,
    });
  });
}
export async function deleteSchemeInstallment(
  prisma: any,
  input: DeleteSchemeInstallmentInput,
): Promise<{ reversed: true }> {
  const book = input.book ?? SCHEME_BOOK,
    sc = schemeScope(input.scope, book),
    v = formatVoucherNo(input.vchNo),
    key = keyOf(sc, Number(v), book);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'AD_DATA',
      scope: sc,
      voucherNo: v,
      extraColumns: [],
    });
    await assertPeriodOpen(tx, sc.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: h.VCH_DATE }] },
    });
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT d.*,m."MEMB_NAME",b."BOOK_SNAME",b."BOOK_NAME" FROM "AD_DATA" d LEFT JOIN "AD_MEMB" m ON m.tenant_id=d.tenant_id AND m."CO_CODE"=d."CO_CODE" AND m."SCHM_CODE"=d."SCHM_CODE" AND m."MEMB_CODE"=d."MEMB_CODE" LEFT JOIN "BOOK_DATA" b ON b.tenant_id=d.tenant_id AND b."CO_CODE"=d."CO_CODE" AND b."LC_CODE"=d."LC_CODE" AND b."CO_BOOK"=d."CO_BOOK" WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO" FOR UPDATE OF d`,
      ...sp(sc, v),
    );
    await reverseVoucherTx(tx, sc.tenantId, { tables: [...ENTRY_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      sc.tenantId,
      sc.coCode,
      sc.lcCode,
      sc.coBook,
      text(h.HD_VCH_NO),
    );
    const now = new Date();
    for (const r of rows)
      await insertRowTx(tx, 'DELETE_DATA', sc.tenantId, {
        ...key,
        SR_NO: r.SR_NO,
        VCH_DATE: r.VCH_DATE,
        DELETE_DATE: now,
        VCH_TYPE: r.BOOK_SNAME,
        VCH_TIME: r.VCH_TIME,
        DELETE_TIME: now,
        BOOK_NAME: text(r.BOOK_NAME).slice(0, 20),
        AC_CODE: r.MEMB_CODE,
        AC_NAME: r.MEMB_NAME,
        VCH_VAL_DR: 0,
        VCH_VAL_CR: numv(r.MEMB_AMT),
        FINE_TYPE: 'A',
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 0,
        HD_VCH_NO: r.HD_VCH_NO,
        MAIN_USER: r.MAIN_USER,
        DELETE_USER: input.deleteUser ?? 'system',
        VCH_DESC: `${text(r.SCHM_CODE)}/${text(r.IT_DESC).slice(0, 130)}`,
      });
    return { reversed: true };
  });
}

export interface DeleteEnrollmentInput {
  scope: VoucherScope;
  schmCode: string;
  membCode: string;
}

/** Remove a member from a scheme (deletes the AD_MEMB row). */
export async function deleteEnrollment(
  prisma: any,
  input: DeleteEnrollmentInput,
): Promise<{ reversed: true }> {
  const { scope, schmCode, membCode } = input;
  if (!schmCode || !membCode) throw new SchemeError('scheme and member code are required');
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "AD_MEMB" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "SCHM_CODE"=$3 AND "MEMB_CODE"=$4`,
      scope.coCode,
      scope.lcCode,
      schmCode,
      membCode,
    );
    return { reversed: true };
  });
}

export interface SchemeMaturityInput {
  scope: VoucherScope;
  schmCode: string;
  membCode: string;
  amount: number; // matured scheme principal (AD_ADJ.MEMB_AMT)
  bonus?: number; // maturity bonus added (AD_ADJ.MEMB_BONUS) — default 0
  less?: number; // deductions/penalty (AD_ADJ.MEMB_LESS) — default 0
  mode?: PayMode; // payout mode (money OUT to member); default cash
  liabAc?: string; // member/scheme-liability AC to clear; else AD_MAST.SCHM_AC
  bankAc?: string; // cash/bank ledger paying out (non-cash modes)
  acName?: string; // AD_ADJ.AC_NAME (settlement account name, optional)
  vchDesc?: string; // AD_ADJ.VCH_DESC
  chqNo?: string;
  vchDate?: Date | string;
  mainUser?: string;
}

export interface SchemeMaturityResult {
  vchNo: number;
  payout: number; // net paid out = amount + bonus − less
}

/**
 * Scheme MATURITY / redemption (desktop "Member Advance Adjust" — book 076 / MBADJ → AD_ADJ).
 * Mirror-image of an installment: the accrued scheme balance is paid back to the member, so the
 * ledger reverses direction — Dr scheme-liability (clear what the shop owed) / Cr cash/bank (money
 * out). Writes the balanced AC_DATA pair + the AD_ADJ adjustment detail (SIGN '-', INOUT_TYPE 'O',
 * ENTRY_TYPE 'A' — matching real 076 rows) + an AD_OS redemption row (OS_TYPE 'D' / SIGN '-') that
 * decrements the member's running balance, the exact counterpart of the installment's 'A' / '+'.
 *
 * Net payout = amount (matured principal) + bonus − less; bonus/less default 0 (plain cash redeem).
 * The ledger is always balanced on the net payout figure.
 */
export async function schemeMaturity(
  prisma: any,
  input: SchemeMaturityInput,
  lifecycle?: SchemeWriteContext,
): Promise<SchemeMaturityResult> {
  const { scope, schmCode, membCode } = input;
  if (!schmCode) throw new SchemeError('scheme code is required');
  if (!membCode) throw new SchemeError('member code is required');
  const amount = numv(input.amount);
  if (!(amount > 0)) throw new SchemeError('amount must be positive');
  const bonus = round2(numv(input.bonus));
  const less = round2(numv(input.less));
  if (bonus < 0 || less < 0) throw new SchemeError('bonus and less must not be negative');
  const payout = round2(amount + bonus - less);
  if (!(payout > 0)) throw new SchemeError('net payout (amount + bonus − less) must be positive');

  const mode: PayMode = input.mode ?? 'cash';
  const tenantId = scope.tenantId;

  const run = async (tx: any): Promise<SchemeMaturityResult> => {
    // P0-04: the payout account is the book's configured slot 1 or an explicit bank, never the literal
    // `'CASH'` this used to fall back to.
    const payAc = await resolveBookSlotAccountTx(
      tx,
      { ...scope, coBook: scope.coBook ?? MEMB_ADJUST.book },
      mode === 'cash' ? 'cash-settlement' : 'bank-settlement',
      1,
      input.bankAc,
    );
    const sch: any[] = await tx.$queryRawUnsafe(
      `SELECT "SCHM_AC","SCHM_NAME" FROM "AD_MAST" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 LIMIT 1`,
      scope.coCode,
      schmCode,
    );
    if (!sch.length) throw new SchemeError(`scheme ${schmCode} not found`);
    // Member must be enrolled (AD_MEMB) before maturity.
    const mem: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "AD_MEMB" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "SCHM_CODE"=$3 AND "MEMB_CODE"=$4 LIMIT 1`,
      scope.coCode,
      scope.lcCode,
      schmCode,
      membCode,
    );
    if (!mem.length) throw new SchemeError(`member ${membCode} not enrolled in scheme ${schmCode}`);
    const liabAc =
      (input.liabAc ?? '').trim() ||
      (sch[0]?.SCHM_AC != null ? String(sch[0].SCHM_AC).trim() : '') ||
      DEFAULT_SCHEME_AC;

    const book = scope.coBook ?? MEMB_ADJUST.book;
    const sc: VoucherScope = { ...scope, coBook: book };
    const vchNo = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, sc));
    const hdVchNo =
      lifecycle?.hdVchNo ??
      (await nextHiddenVoucherNoTx(tx, sc as VoucherScope & { coBook: string }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key = keyOf(sc, vchNo, book);
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );
    const acName = (input.acName ?? '').trim() || null;
    const vchDesc =
      (input.vchDesc ?? '').trim() || `Scheme ${schmCode} maturity — member ${membCode}`;

    // Reverse of an installment: Dr scheme liability (clear it) / Cr cash/bank (pay the member out).
    const ledger: LedgerLine[] = buildTransferLedger(
      key,
      MEMB_ADJUST.vchType,
      liabAc,
      payAc,
      payout,
    );
    assertBalanced(ledger);

    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_BOOK: book,
      VCH_NO: hdVchNo,
      BOOK_NAME: MEMB_ADJUST.bookName,
    });
    // The Rojmel (day book). Book 076 carries 37 real rows across three types; the other five in
    // Ac_Rojmel.Schm_Adj_RojMel are dead here, and two independent facts say so - they all require
    // GOLD_WT or GOLD_AMT, which is 0 on all 26 AD_ADJ rows, and they require SCHM_TYPE 'G'/'S' while all
    // four of this company's schemes are 'A'.
    //
    // The bonus is carried on its own row against a different account, so type 01 takes ADJ_AMT less the
    // bonus rather than the whole figure. Type 03 is the settlement mirror and is suppressed when the
    // balance went onto a sales bill, because that bill's own rows already carry it.
    const rojmelRows = buildSchemeAdjRojmel(
      {
        scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: sc.coYear! },
        key,
        coBook: book,
        vchNo: key.VCH_NO,
        vchDate,
        vchType: MEMB_ADJUST.vchType,
        bookName: MEMB_ADJUST.bookName,
        partyName: acName ?? '',
        partyCode: payAc,
      },
      [
        {
          lineNo: 1,
          schemeAc: liabAc,
          // The desktop charges the bonus to BOOK_DETL slot 1. This module does not resolve that slot,
          // so the scheme account is used and the divergence stated rather than an account invented.
          bonusAc: liabAc,
          settlementAc: payAc,
          adjustedAmount: payout,
          bonus,
          memberName: acName ?? undefined,
        },
      ],
    );
    await postVoucherTx(tx, tenantId, {
      bookName: MEMB_ADJUST.bookName,
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
        {
          table: 'AD_ADJ',
          rows: [
            {
              ...key,
              SR_NO: 1,
              VCH_DATE: vchDate,
              VCH_TIME: vchDate,
              VCH_TYPE: MEMB_ADJUST.vchType,
              INOUT_TYPE: 'O',
              ENTRY_TYPE: 'A', // matches real AD_ADJ rows (076)
              BOOK_NAME: MEMB_ADJUST.bookName,
              SCHM_CODE: schmCode,
              MEMB_CODE: membCode,
              MEMB_AMT: amount,
              MEMB_BONUS: bonus,
              MEMB_LESS: less,
              ADJ_AMT: payout,
              AC_CODE: payAc,
              AC_NAME: acName,
              SIGN: '-',
              HD_VCH_NO: hdVchNo,
              GOLD_WT: 0,
              GOLD_RATE: 0,
              GOLD_AMT: 0,
              VCH_DESC: vchDesc,
              MAIN_USER: mainUser,
              DATA_TRFR: 'N',
            },
          ],
        },
        {
          table: 'AD_OS',
          rows: [
            {
              ...key,
              SR_NO: 1,
              VCH_DATE: vchDate,
              VCH_TYPE: MEMB_ADJUST.vchType,
              INOUT_TYPE: 'O',
              ENTRY_TYPE: 'O',
              BOOK_NAME: MEMB_ADJUST.bookName,
              SCHM_CODE: schmCode,
              SCHM_DATE: vchDate,
              MEMB_CODE: membCode,
              MEMB_AMT: amount,
              ADJ_AMT: payout,
              SIGN: '-',
              OS_TYPE: 'D', // 'D' = redemption (−); counterpart of installment 'A' (+)
              MAIN_USER: mainUser,
              HD_VCH_NO: hdVchNo,
              DATA_TRFR: 'N',
              DATA_TYPE: 'A',
            },
          ],
        },
      ],
    });
    return { vchNo, payout };
  };
  return lifecycle ? run(lifecycle.tx) : withTenant(prisma, tenantId, run);
}

export interface SchemeGoldAdjustLineInput {
  srNo?: number;
  schmCode: string;
  membCode: string;
  /** AD_ADJ.AC_CODE: the member/customer account receiving the gold/value adjustment. */
  acCode?: string;
  acName?: string;
  goldWt?: number;
  goldRate?: number;
  goldAmt?: number;
  memberAmount?: number;
  adjustAmount?: number;
  bonus?: number;
  less?: number;
  saleBillNo?: string;
  saleBillLcCode?: string;
  saleBillYear?: string;
  saleBillBook?: string;
  saleBillAmount?: number;
  saleBillHeaderVoucherNo?: string;
  empCode?: string;
  vchDesc?: string;
}

export interface SchemeGoldAdjustInput extends Partial<SchemeGoldAdjustLineInput> {
  scope: VoucherScope;
  vchDate?: Date | string;
  mainUser?: string;
  /** Desktop prompt: update AD_MEMB.EXP_DATE to the adjustment date. Defaults to false. */
  updateExpiry?: boolean;
  /** Desktop grid rows. When supplied, top-level line fields are ignored. */
  lines?: SchemeGoldAdjustLineInput[];
}

export interface SchemeGoldAdjustResult {
  vchNo: number;
  lines: number;
  goldWt: number;
  goldAmt: number;
  adjustedAmount: number;
}

type NormalizedGoldAdjustLine = Required<
  Pick<SchemeGoldAdjustLineInput, 'schmCode' | 'membCode'>
> & {
  srNo: number;
  acCode: string;
  acName: string;
  goldWt: number;
  goldRate: number;
  goldAmt: number;
  memberAmount: number;
  adjustAmount: number;
  bonus: number;
  less: number;
  saleBillNo: string;
  saleBillLcCode: string;
  saleBillYear: string;
  saleBillBook: string;
  saleBillAmount: number;
  saleBillHeaderVoucherNo: string;
  empCode: string;
  vchDesc: string;
  schemeAc: string;
  schemeType: string;
  memberName: string;
};

function round3(n: number): number {
  return Math.round((n + Number.EPSILON) * 1000) / 1000;
}

async function memberSchemeInfoTx(
  tx: any,
  scope: VoucherScope,
  schmCode: string,
  membCode: string,
): Promise<{ schemeAc: string; schemeType: string; memberName: string }> {
  const sch: any[] = await tx.$queryRawUnsafe(
    `SELECT "SCHM_AC","SCHM_TYPE" FROM "AD_MAST" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 LIMIT 1`,
    scope.coCode,
    schmCode,
  );
  if (!sch.length) throw new SchemeError(`scheme ${schmCode} not found`);
  const mem: any[] = await tx.$queryRawUnsafe(
    `SELECT "MEMB_NAME" FROM "AD_MEMB" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "SCHM_CODE"=$3 AND "MEMB_CODE"=$4 LIMIT 1`,
    scope.coCode,
    scope.lcCode,
    schmCode,
    membCode,
  );
  if (!mem.length) throw new SchemeError(`member ${membCode} not enrolled in scheme ${schmCode}`);
  return {
    schemeAc: (sch[0]?.SCHM_AC != null ? String(sch[0].SCHM_AC).trim() : '') || DEFAULT_SCHEME_AC,
    schemeType:
      String(sch[0]?.SCHM_TYPE ?? '')
        .trim()
        .toUpperCase() || 'A',
    memberName: String(mem[0]?.MEMB_NAME ?? '').trim(),
  };
}

async function goldAdjustBookTx(
  tx: any,
  scope: VoucherScope,
  book: string,
): Promise<{
  vchType: string;
  inout: string;
  mainBook: string;
  displayName: string;
  dataType: string;
}> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "BOOK_SNAME","BOOK_INOUT","MAIN_BOOK","BOOK_NAME","DATA_TYPE" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    book,
  );
  if (!rows.length) {
    return {
      vchType: MEMB_GOLD_ADJUST.vchType,
      inout: 'O',
      mainBook: MEMB_GOLD_ADJUST.bookName,
      displayName: 'Member Gold Adjust',
      dataType: 'A',
    };
  }
  const mainBook = String(rows[0]?.MAIN_BOOK ?? '')
    .trim()
    .toUpperCase();
  if (mainBook !== MEMB_GOLD_ADJUST.bookName) {
    throw new SchemeError(`book ${book} is ${mainBook || 'unclassified'}, expected MEMB GOLD ADJ`);
  }
  return {
    vchType: String(rows[0]?.BOOK_SNAME ?? '').trim() || MEMB_GOLD_ADJUST.vchType,
    inout: String(rows[0]?.BOOK_INOUT ?? '').trim() || 'O',
    mainBook: MEMB_GOLD_ADJUST.bookName,
    displayName: String(rows[0]?.BOOK_NAME ?? '').trim() || 'Member Gold Adjust',
    dataType: String(rows[0]?.DATA_TYPE ?? '').trim() || 'A',
  };
}

async function normalizeGoldAdjustLinesTx(
  tx: any,
  input: SchemeGoldAdjustInput,
): Promise<NormalizedGoldAdjustLine[]> {
  const raw = input.lines?.length ? input.lines : [input];
  const seen = new Set<number>();
  const out: NormalizedGoldAdjustLine[] = [];
  for (const [idx, line] of raw.entries()) {
    const lineNo = idx + 1;
    const srNo = Number(line.srNo ?? lineNo);
    if (!Number.isFinite(srNo) || srNo <= 0)
      throw new SchemeError(`line ${lineNo}: srNo must be positive`);
    if (seen.has(srNo)) throw new SchemeError(`duplicate scheme gold-adjust row ${srNo}`);
    seen.add(srNo);
    const schmCode = trimTo(line.schmCode, 3) ?? '';
    const membCode = trimTo(line.membCode, 5) ?? '';
    if (!schmCode) throw new SchemeError(`line ${lineNo}: scheme code is required`);
    if (!membCode) throw new SchemeError(`line ${lineNo}: member code is required`);
    const acCode = trimTo(line.acCode ?? line.membCode, 8) ?? '';
    if (!acCode) throw new SchemeError(`line ${lineNo}: adjustment account is required`);
    const goldWt = round3(numv(line.goldWt));
    const goldRate = round2(numv(line.goldRate));
    const explicitGoldAmt = line.goldAmt != null && String(line.goldAmt).trim() !== '';
    const goldAmt = round2(
      explicitGoldAmt ? numv(line.goldAmt) : goldWt && goldRate ? goldWt * goldRate : 0,
    );
    const memberAmount = round2(numv(line.memberAmount));
    const adjustAmount = round2(numv(line.adjustAmount));
    const bonus = round2(numv(line.bonus));
    const less = round2(numv(line.less));
    for (const [label, value] of [
      ['gold weight', goldWt],
      ['gold rate', goldRate],
      ['gold amount', goldAmt],
      ['member amount', memberAmount],
      ['adjust amount', adjustAmount],
      ['bonus', bonus],
      ['less', less],
    ] as const) {
      if (value < 0) throw new SchemeError(`line ${lineNo}: ${label} must not be negative`);
    }
    if (goldRate && goldAmt - less < 0) {
      throw new SchemeError(`line ${lineNo}: less cannot exceed gold amount`);
    }
    if (!(goldWt || goldAmt || adjustAmount || bonus || less || memberAmount)) {
      throw new SchemeError(
        `line ${lineNo}: at least one gold, amount, bonus, or less value is required`,
      );
    }
    const info = await memberSchemeInfoTx(tx, input.scope, schmCode, membCode);
    out.push({
      srNo,
      schmCode,
      membCode,
      acCode,
      acName: trimTo(line.acName, 50) ?? info.memberName,
      goldWt,
      goldRate,
      goldAmt,
      memberAmount,
      adjustAmount,
      bonus,
      less,
      saleBillNo: trimTo(line.saleBillNo, 10) ?? '',
      saleBillLcCode: trimTo(line.saleBillLcCode, 2) ?? '',
      saleBillYear: trimTo(line.saleBillYear, 10) ?? '',
      saleBillBook: trimTo(line.saleBillBook, 3) ?? '',
      saleBillAmount: round2(numv(line.saleBillAmount)),
      saleBillHeaderVoucherNo: trimTo(line.saleBillHeaderVoucherNo, 10) ?? '',
      empCode: trimTo(line.empCode, 3) ?? '',
      vchDesc: trimTo(line.vchDesc, 50) ?? '',
      schemeAc: info.schemeAc,
      schemeType: info.schemeType,
      memberName: info.memberName,
    });
  }
  return out.sort((a, b) => a.srNo - b.srNo);
}

function goldAdjustLedgerLines(
  key: VoucherKey,
  vchType: string,
  vchDate: Date,
  hdVchNo: string,
  mainUser: string,
  lines: NormalizedGoldAdjustLine[],
  bookSettlementAc: string | null,
): LedgerLine[] {
  const ledger: LedgerLine[] = [];
  for (const l of lines) {
    const isGoldOrSilver = l.schemeType === 'G' || l.schemeType === 'S';
    if (!isGoldOrSilver) continue;
    if (l.goldWt && l.goldRate === 0) {
      ledger.push({
        ...key,
        VCH_TYPE: vchType,
        AC_CODE: l.acCode,
        LD_CODE: l.schemeType === 'S' ? '00009' : '00008',
        CR_AMT: 0,
        DR_AMT: 0,
        IT_TYPE: l.schemeType === 'S' ? 'S' : 'G',
        SIGN: '+',
        FINE_WT: l.goldWt,
        HD_VCH_NO: hdVchNo,
        MAIN_USER: mainUser,
        VCH_DATE: vchDate,
        legType: 7,
        legLine: l.srNo,
      });
    }
    if (l.goldAmt && l.goldRate !== 0) {
      ledger.push(
        {
          ...key,
          VCH_TYPE: vchType,
          AC_CODE: l.acCode,
          LD_CODE: l.schemeAc,
          CR_AMT: l.less,
          DR_AMT: 0,
          IT_TYPE: '',
          SIGN: '',
          FINE_WT: 0,
          HD_VCH_NO: hdVchNo,
          MAIN_USER: mainUser,
          VCH_DATE: vchDate,
          legType: 8,
          legLine: l.srNo,
        },
        {
          ...key,
          VCH_TYPE: vchType,
          AC_CODE: l.schemeAc,
          LD_CODE: l.acCode,
          CR_AMT: 0,
          DR_AMT: l.less,
          IT_TYPE: '',
          SIGN: '',
          FINE_WT: 0,
          HD_VCH_NO: hdVchNo,
          MAIN_USER: mainUser,
          VCH_DATE: vchDate,
          legType: 9,
          legLine: l.srNo,
        },
      );
    }
    if (l.goldRate !== 0) {
      if (!bookSettlementAc)
        throw new SchemeError('book settlement account is required for priced gold adjustment');
      const settlementAmount = round2(l.goldAmt - l.less);
      ledger.push(
        {
          ...key,
          VCH_TYPE: vchType,
          AC_CODE: bookSettlementAc,
          LD_CODE: l.acCode,
          CR_AMT: 0,
          DR_AMT: settlementAmount,
          IT_TYPE: 'A',
          SIGN: '',
          FINE_WT: 0,
          HD_VCH_NO: hdVchNo,
          MAIN_USER: mainUser,
          VCH_DATE: vchDate,
          PARTY_AC_CODE: bookSettlementAc,
          legType: 10,
          legLine: l.srNo,
        },
        {
          ...key,
          VCH_TYPE: vchType,
          AC_CODE: l.acCode,
          LD_CODE: bookSettlementAc,
          CR_AMT: settlementAmount,
          DR_AMT: 0,
          IT_TYPE: 'A',
          SIGN: '',
          FINE_WT: 0,
          HD_VCH_NO: hdVchNo,
          MAIN_USER: mainUser,
          VCH_DATE: vchDate,
          PARTY_AC_CODE: l.acCode,
          legType: 11,
          legLine: l.srNo,
        },
      );
    }
  }
  return ledger;
}

function goldAdjustRojmelRows(
  ctx: RojmelContext,
  lines: NormalizedGoldAdjustLine[],
  bookSettlementAc: string | null,
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const key = (rowType: string, srNo: number) =>
    schemeRojmelKey(ctx.scope, ctx.coBook, ctx.vchNo, rowType, srNo);
  for (const l of lines) {
    const isGoldOrSilver = l.schemeType === 'G' || l.schemeType === 'S';
    if (!isGoldOrSilver || !l.acCode) continue;
    const displayName = l.acName || l.memberName;
    if (l.goldWt && l.goldRate === 0) {
      rows.push({
        ...schemeRojmelBlank(ctx, key('04', l.srNo)),
        AC_CODE: l.acCode,
        AC_NAME: l.schemeType === 'S' ? `${l.schmCode} - ${displayName}` : displayName,
        LD_CODE: l.schemeType === 'S' ? '00009' : '00008',
        IT_TYPE: l.schemeType === 'S' ? 'S' : 'G',
        SIGN: '+',
        ITM_GWT: l.goldWt,
        ITM_NWT: l.goldWt,
        ITM_TOUCH: 100,
        ITM_FINE: l.goldWt,
        MEMB_CODE: l.membCode,
        SCHM_CODE: l.schmCode,
      });
    }
    if (l.goldAmt) {
      rows.push(
        {
          ...schemeRojmelBlank(ctx, key('05', l.srNo)),
          AC_CODE: l.schemeAc,
          AC_NAME: `${l.schmCode} - ${displayName}`,
          LD_CODE: l.acCode,
          CR_AMT: l.less,
          IT_TYPE: 'G',
          SIGN: '+',
          MEMB_CODE: l.membCode,
          SCHM_CODE: l.schmCode,
        },
        {
          ...schemeRojmelBlank(ctx, key('06', l.srNo)),
          AC_CODE: l.acCode,
          LD_CODE: l.schemeAc,
          DR_AMT: l.less,
          IT_TYPE: 'G',
          SIGN: '+',
          MEMB_CODE: l.membCode,
          SCHM_CODE: l.schmCode,
        },
      );
      if (bookSettlementAc) {
        const settlementAmount = round2(l.goldAmt - l.less);
        rows.push(
          {
            ...schemeRojmelBlank(ctx, key('07', l.srNo)),
            AC_CODE: l.acCode,
            AC_NAME: `${l.schmCode} - ${displayName}`,
            LD_CODE: bookSettlementAc,
            CR_AMT: settlementAmount,
            IT_TYPE: 'G',
            SIGN: '+',
            MEMB_CODE: l.membCode,
            SCHM_CODE: l.schmCode,
          },
          {
            ...schemeRojmelBlank(ctx, key('08', l.srNo)),
            AC_CODE: bookSettlementAc,
            LD_CODE: l.acCode,
            DR_AMT: settlementAmount,
            IT_TYPE: 'G',
            SIGN: '+',
            MEMB_CODE: l.membCode,
            SCHM_CODE: l.schmCode,
          },
        );
      }
    }
  }
  return rows;
}

function goldAdjustAdOsRows(
  key: VoucherKey,
  vchDate: Date,
  vchType: string,
  inout: string,
  mainBook: string,
  hdVchNo: string,
  mainUser: string,
  dataType: string,
  lines: NormalizedGoldAdjustLine[],
): Record<string, unknown>[] {
  const rows: Record<string, unknown>[] = [];
  for (const l of lines) {
    const netAdjust = round2(l.adjustAmount - l.bonus + l.less);
    const base = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: inout,
      ENTRY_TYPE: 'A',
      BOOK_NAME: mainBook,
      SCHM_CODE: l.schmCode,
      SCHM_DATE: vchDate,
      MEMB_CODE: l.membCode,
      SIGN: '-',
      LD_CODE: l.acCode,
      EMP_CODE: l.empCode,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
      DATA_TYPE: dataType,
    };
    if (netAdjust) {
      rows.push({
        ...base,
        SR_NO: l.srNo,
        ADJ_AMT: netAdjust,
        OS_TYPE: 'D',
        GOLD_WT: 0,
        ITM_RATE: 0,
      });
    }
    if (l.bonus) {
      rows.push({
        ...base,
        SR_NO: 500 + l.srNo,
        ADJ_AMT: l.bonus,
        OS_TYPE: 'B',
        GOLD_WT: 0,
        ITM_RATE: 0,
      });
    }
    if (l.goldWt) {
      rows.push({
        ...base,
        SR_NO: 700 + l.srNo,
        ADJ_AMT: 0,
        OS_TYPE: 'D',
        GOLD_WT: l.goldWt,
        ITM_RATE: 0,
      });
    }
  }
  return rows;
}

export async function schemeGoldAdjust(
  prisma: any,
  input: SchemeGoldAdjustInput,
  lifecycle?: SchemeWriteContext,
): Promise<SchemeGoldAdjustResult> {
  const { scope } = input;
  const tenantId = scope.tenantId;
  const run = async (tx: any): Promise<SchemeGoldAdjustResult> => {
    const book = scope.coBook ?? MEMB_GOLD_ADJUST.book;
    const sc: VoucherScope = { ...scope, coBook: book };
    const meta = await goldAdjustBookTx(tx, scope, book);
    const lines = await normalizeGoldAdjustLinesTx(tx, input);
    const needsBookSettlement =
      lines.some((l) => l.schemeType === 'G' || l.schemeType === 'S') &&
      lines.some((l) => l.goldRate !== 0);
    const bookSettlementAc = needsBookSettlement
      ? await resolveBookSlotAccountTx(tx, sc, 'bank-settlement', 1, undefined)
      : null;
    const vchNo = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, sc));
    const hdVchNo =
      lifecycle?.hdVchNo ??
      (await nextHiddenVoucherNoTx(tx, sc as VoucherScope & { coBook: string }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key = keyOf(sc, vchNo, book);
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );

    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_BOOK: book,
      VCH_NO: hdVchNo,
      BOOK_NAME: meta.displayName,
    });

    const ledger = goldAdjustLedgerLines(
      key,
      meta.vchType,
      vchDate,
      hdVchNo,
      mainUser,
      lines,
      bookSettlementAc,
    );
    const adOsRows = goldAdjustAdOsRows(
      key,
      vchDate,
      meta.vchType,
      meta.inout,
      meta.mainBook,
      hdVchNo,
      mainUser,
      meta.dataType,
      lines,
    );
    const rojmelRows = goldAdjustRojmelRows(
      {
        scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: sc.coYear! },
        key,
        coBook: book,
        vchNo: key.VCH_NO,
        vchDate,
        vchType: meta.vchType,
        bookName: meta.mainBook,
        partyName: '',
        partyCode: '',
      },
      lines,
      bookSettlementAc,
    );

    await postVoucherTx(tx, tenantId, {
      bookName: meta.mainBook,
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
        {
          table: 'AD_ADJ',
          rows: lines.map((l) => ({
            ...key,
            SR_NO: l.srNo,
            VCH_DATE: vchDate,
            VCH_TIME: vchDate,
            VCH_TYPE: meta.vchType,
            INOUT_TYPE: meta.inout,
            ENTRY_TYPE: 'A',
            BOOK_NAME: meta.mainBook,
            SCHM_CODE: l.schmCode,
            MEMB_CODE: l.membCode,
            GOLD_WT: l.goldWt,
            GOLD_RATE: l.goldRate,
            GOLD_AMT: l.goldAmt,
            MEMB_AMT: l.memberAmount,
            ADJ_AMT: l.adjustAmount,
            MEMB_BONUS: l.bonus,
            MEMB_LESS: l.less,
            SBILL_NO: l.saleBillNo,
            SBILL_LC_CODE: l.saleBillLcCode,
            SBILL_YRCD: l.saleBillYear,
            SBILL_DBCD: l.saleBillBook,
            SBILL_AMT: l.saleBillAmount,
            SBILL_HD_VCH_NO: l.saleBillHeaderVoucherNo,
            SIGN: '-',
            AC_CODE: l.acCode,
            AC_NAME: l.acName,
            VCH_DESC: l.vchDesc,
            HD_VCH_NO: hdVchNo,
            EMP_CODE: l.empCode,
            DATA_TRFR: 'N',
            MAIN_USER: mainUser,
            USER_UPDATE: 'N',
            USER_DELETE: 'N',
          })),
        },
        ...(adOsRows.length ? [{ table: 'AD_OS', rows: adOsRows }] : []),
      ],
    });

    if (boolFlag(input.updateExpiry)) {
      for (const l of lines) {
        await tx.$executeRawUnsafe(
          `UPDATE "AD_MEMB" SET "EXP_DATE"=$1 WHERE "CO_CODE"=$2 AND "LC_CODE"=$3 AND "SCHM_CODE"=$4 AND "MEMB_CODE"=$5`,
          vchDate,
          scope.coCode,
          scope.lcCode,
          l.schmCode,
          l.membCode,
        );
      }
    }

    return {
      vchNo,
      lines: lines.length,
      goldWt: round3(lines.reduce((sum, l) => sum + l.goldWt, 0)),
      goldAmt: round2(lines.reduce((sum, l) => sum + l.goldAmt, 0)),
      adjustedAmount: round2(lines.reduce((sum, l) => sum + l.adjustAmount, 0)),
    };
  };
  return lifecycle ? run(lifecycle.tx) : withTenant(prisma, tenantId, run);
}

export async function getSchemeGoldAdjust(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  book: string = MEMB_GOLD_ADJUST.book,
): Promise<Record<string, unknown>> {
  const sc = schemeScope(scope, book);
  const v = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT a.*,a."VCH_DATE"::text AS "VCH_DATE_TEXT" FROM "AD_ADJ" a
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        ORDER BY "SR_NO"`,
      ...sp(sc, v),
    );
    if (!r.length) throw new SchemeError(`scheme gold adjustment voucher not found: ${v}`);
    const x = r[0];
    const lines = r.map((row) => ({
      srNo: numv(row.SR_NO),
      schmCode: text(row.SCHM_CODE),
      membCode: text(row.MEMB_CODE),
      acCode: text(row.AC_CODE),
      acName: text(row.AC_NAME),
      goldWt: numv(row.GOLD_WT),
      goldRate: numv(row.GOLD_RATE),
      goldAmt: numv(row.GOLD_AMT),
      memberAmount: numv(row.MEMB_AMT),
      adjustAmount: numv(row.ADJ_AMT),
      bonus: numv(row.MEMB_BONUS),
      less: numv(row.MEMB_LESS),
      saleBillNo: text(row.SBILL_NO),
      saleBillLcCode: text(row.SBILL_LC_CODE),
      saleBillYear: text(row.SBILL_YRCD),
      saleBillBook: text(row.SBILL_DBCD),
      saleBillAmount: numv(row.SBILL_AMT),
      saleBillHeaderVoucherNo: text(row.SBILL_HD_VCH_NO),
      empCode: text(row.EMP_CODE),
      vchDesc: text(row.VCH_DESC),
    }));
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchDate: text(x.VCH_DATE_TEXT).slice(0, 10),
      book,
      lines,
      goldWt: round3(lines.reduce((sum, l) => sum + numv(l.goldWt), 0)),
      goldAmt: round2(lines.reduce((sum, l) => sum + numv(l.goldAmt), 0)),
      adjustedAmount: round2(lines.reduce((sum, l) => sum + numv(l.adjustAmount), 0)),
    };
  });
}

export async function deleteSchemeGoldAdjust(
  prisma: any,
  input: DeleteSchemeMaturityInput,
): Promise<{ reversed: true }> {
  const book = input.book ?? MEMB_GOLD_ADJUST.book;
  const sc = schemeScope(input.scope, book);
  const v = formatVoucherNo(input.vchNo);
  const key = keyOf(sc, Number(v), book);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'AD_ADJ',
      scope: sc,
      voucherNo: v,
      extraColumns: [],
    });
    await assertPeriodOpen(tx, sc.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: h.VCH_DATE }] },
    });
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a.*,b."BOOK_SNAME",b."BOOK_NAME" FROM "AD_ADJ" a
        LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
       WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
       ORDER BY a."SR_NO" FOR UPDATE OF a`,
      ...sp(sc, v),
    );
    await reverseVoucherTx(tx, sc.tenantId, { tables: [...ADJUST_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      sc.tenantId,
      sc.coCode,
      sc.lcCode,
      sc.coBook,
      text(h.HD_VCH_NO),
    );
    const now = new Date();
    for (const r of rows) {
      await insertRowTx(tx, 'DELETE_DATA', sc.tenantId, {
        ...key,
        SR_NO: r.SR_NO,
        VCH_DATE: r.VCH_DATE,
        DELETE_DATE: now,
        VCH_TYPE: r.BOOK_SNAME ?? MEMB_GOLD_ADJUST.vchType,
        VCH_TIME: r.VCH_TIME,
        DELETE_TIME: now,
        BOOK_NAME: text(r.BOOK_NAME || MEMB_GOLD_ADJUST.bookName).slice(0, 20),
        AC_CODE: r.AC_CODE,
        AC_NAME: r.AC_NAME,
        VCH_VAL_DR: 0,
        VCH_VAL_CR: numv(r.GOLD_AMT) || numv(r.ADJ_AMT),
        FINE_TYPE: 'G',
        VCH_FINE_DR: 0,
        VCH_FINE_CR: numv(r.GOLD_WT),
        HD_VCH_NO: r.HD_VCH_NO,
        MAIN_USER: r.MAIN_USER,
        DELETE_USER: input.deleteUser ?? 'system',
        VCH_DESC: text(r.VCH_DESC).slice(0, 149),
      });
    }
    return { reversed: true };
  });
}

export interface DeleteSchemeMaturityInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string;
  deleteUser?: string;
}
export async function getSchemeMaturity(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  book = MEMB_ADJUST.book,
): Promise<Record<string, unknown>> {
  const sc = schemeScope(scope, book),
    v = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT a.*,a."VCH_DATE"::text AS "VCH_DATE_TEXT" FROM "AD_ADJ" a WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...sp(sc, v),
    );
    if (!r.length) throw new SchemeError(`scheme maturity voucher not found: ${v}`);
    const x = r[0];
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchDate: text(x.VCH_DATE_TEXT).slice(0, 10),
      schmCode: text(x.SCHM_CODE),
      membCode: text(x.MEMB_CODE),
      amount: numv(x.MEMB_AMT),
      bonus: numv(x.MEMB_BONUS),
      less: numv(x.MEMB_LESS),
      payout: numv(x.ADJ_AMT),
      bankAc: text(x.AC_CODE),
      acName: text(x.AC_NAME),
      vchDesc: text(x.VCH_DESC),
      chqNo: '',
      book,
    };
  });
}
export async function editSchemeMaturity(
  prisma: any,
  input: SchemeMaturityInput,
  requestedVoucherNo: number | string,
): Promise<SchemeMaturityResult> {
  const book = input.scope.coBook ?? MEMB_ADJUST.book,
    sc = schemeScope(input.scope, book),
    v = formatVoucherNo(requestedVoucherNo),
    requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'AD_ADJ',
      scope: sc,
      voucherNo: v,
      extraColumns: ['SBILL_NO'],
    });
    for (const date of [h.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, sc.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: date }] },
      });
    if (text(h.SBILL_NO))
      throw new SchemeError(
        `scheme maturity cannot be edited — linked voucher ${text(h.SBILL_NO)} must be deleted first`,
      );
    const hd = formatVoucherNo(text(h.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: ADJUST_WRITE_TABLES,
      key: { scope: sc, voucherNo: v },
      tempBook: { voucherNo: hd },
    });
    return schemeMaturity(
      prisma,
      { ...input, scope: sc },
      {
        tx,
        vchNo: Number(v),
        hdVchNo: hd,
        mainUser: text(h.MAIN_USER),
        persistedClock: h.VCH_CLOCK,
      },
    );
  });
}
export async function deleteSchemeMaturity(
  prisma: any,
  input: DeleteSchemeMaturityInput,
): Promise<{ reversed: true }> {
  const book = input.book ?? MEMB_ADJUST.book,
    sc = schemeScope(input.scope, book),
    v = formatVoucherNo(input.vchNo),
    key = keyOf(sc, Number(v), book);
  return withTenant(prisma, sc.tenantId, async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'AD_ADJ',
      scope: sc,
      voucherNo: v,
      extraColumns: ['SBILL_NO'],
    });
    await assertPeriodOpen(tx, sc.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: h.VCH_DATE }] },
    });
    if (text(h.SBILL_NO))
      throw new SchemeError(
        `scheme maturity cannot be deleted — linked voucher ${text(h.SBILL_NO)} must be deleted first`,
      );
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a.*,b."BOOK_SNAME",b."BOOK_NAME" FROM "AD_ADJ" a LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK" WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6 ORDER BY a."SR_NO" FOR UPDATE OF a`,
      ...sp(sc, v),
    );
    await reverseVoucherTx(tx, sc.tenantId, { tables: [...ADJUST_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      sc.tenantId,
      sc.coCode,
      sc.lcCode,
      sc.coBook,
      text(h.HD_VCH_NO),
    );
    const now = new Date();
    for (const r of rows)
      await insertRowTx(tx, 'DELETE_DATA', sc.tenantId, {
        ...key,
        SR_NO: r.SR_NO,
        VCH_DATE: r.VCH_DATE,
        DELETE_DATE: now,
        VCH_TYPE: r.BOOK_SNAME,
        VCH_TIME: r.VCH_TIME,
        DELETE_TIME: now,
        BOOK_NAME: text(r.BOOK_NAME).slice(0, 20),
        AC_CODE: r.AC_CODE,
        AC_NAME: r.AC_NAME,
        VCH_VAL_DR: 0,
        VCH_VAL_CR: numv(r.ADJ_AMT),
        FINE_TYPE: 'A',
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 0,
        HD_VCH_NO: r.HD_VCH_NO,
        MAIN_USER: r.MAIN_USER,
        DELETE_USER: input.deleteUser ?? 'system',
        VCH_DESC: text(r.VCH_DESC).slice(0, 149),
      });
    return { reversed: true };
  });
}
