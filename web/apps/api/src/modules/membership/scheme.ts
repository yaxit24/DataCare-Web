import { withTenant } from '@datacare/db';
import { buildMoneyRojmel, buildSchemeAdjRojmel } from '../shared/rojmel.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import { settlementAc, buildTransferLedger, type PayMode } from '../finance/finance.js';
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

/** Monthly-installment tags (desktop 074 / MBENT / 'MEMB ENTRY'). */
const SCHEME_BOOK = MEMB_ENTRY.book;
const BOOK_NAME = MEMB_ENTRY.bookName;
const VCH_TYPE = MEMB_ENTRY.vchType;
/** Fallback liability account when AD_MAST.SCHM_AC is unset (keeps the ledger balanced). */
const DEFAULT_SCHEME_AC = 'SCHEME';

const numv = (v: unknown): number => Number(v ?? 0);

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
  const recAc = settlementAc(mode, input.bankAc); // money IN ⇒ debited (cash/bank)
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
    const ledger: LedgerLine[] = isOpening
      ? []
      : lines.flatMap((l) =>
          buildTransferLedger(
            key,
            tags.vchType,
            recAc,
            (l.liabAc ?? '').trim() || liabOf.get(l.schmCode)!,
            numv(l.amount),
          ),
        );
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
      REC_AC: recAc,
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
      WITH_UPI: l.withUpi ? 'Y' : 'N',
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
      LD_CODE: recAc.trim().slice(0, 8) || null,
      GOLD_WT: 0,
      ...key,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: tags.vchType,
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'I',
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
    const rojmelRows = isOpening
      ? []
      : buildMoneyRojmel(
          {
            scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: sc.coYear! },
            key,
            coBook: book,
            vchNo: key.VCH_NO,
            vchDate,
            vchType: tags.vchType,
            bookName: tags.bookName,
            partyName: '',
            partyCode: recAc,
          },
          lines.map((l, i) => ({
            lineNo: i + 1,
            controlAc: (l.liabAc ?? '').trim() || liabOf.get(l.schmCode)!,
            receiptAc: recAc,
            amount: numv(l.amount),
            banked: mode !== 'cash',
          })),
        );

    await postVoucherTx(tx, tenantId, {
      bookName: tags.bookName,
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [
        { table: 'AD_DATA', rows: adDataRows },
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
      `SELECT d."VCH_NO",d."VCH_DATE"::text,d."VCH_TIME",d."HD_VCH_NO",d."MAIN_USER",d."SCHM_CODE",d."MEMB_CODE",d."MEMB_AMT",d."REC_AC",d."CHQ_NO",d."IT_DESC",d."ENT_TYPE" FROM "AD_DATA" d WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO"`,
      ...sp(sc, v),
    );
    if (!r.length) throw new SchemeError(`scheme installment voucher not found: ${v}`);
    const x = r[0];
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchDate: text(x.VCH_DATE).slice(0, 10),
      schmCode: text(x.SCHM_CODE),
      membCode: text(x.MEMB_CODE),
      amount: numv(x.MEMB_AMT),
      bankAc: text(x.REC_AC),
      chqNo: text(x.CHQ_NO),
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

const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

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
  const payAc = settlementAc(mode, input.bankAc); // money OUT ⇒ credited (cash/bank)
  const tenantId = scope.tenantId;

  const run = async (tx: any): Promise<SchemeMaturityResult> => {
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
