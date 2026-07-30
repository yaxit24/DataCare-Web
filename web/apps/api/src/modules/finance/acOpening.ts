import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
} from '../posting/posting.js';

export class AcOpeningValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'AcOpeningValidationError';
  }
}

/** Book code (CO_BOOK) and ledger BOOK_NAME stamped on account-opening vouchers (desktop parity). */
const ACO_BOOK = 'ACO';
const ACO_BOOK_NAME = 'OPENING';
/** Desktop opening voucher type — every AC_DATA leg is marked VCH_TYPE 'ACOP'. */
const ACOP_TYPE = 'ACOP';

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

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};

/**
 * Build the ADDITIONAL AC_DATA metal opening leg for an account (desktop parity, mirrors the leg
 * added in manufacturing/karigar.ts): IT_TYPE 'G'/'S', SIGN '+' for a debit/asset opening (fine
 * >= 0) or '-' for a credit (fine < 0), FINE_WT carries |fine|, FINE_RATE 0 and DR_AMT=CR_AMT=0 —
 * the money columns are zero so assertBalanced (Σ Dr == Σ Cr) is unaffected. postVoucherTx's
 * enrichLedgerLine preserves this caller-set IT_TYPE (it only defaults to 'A' when null).
 */
function metalLeg(
  key: VoucherKey,
  vchDate: Date,
  acCode: string,
  itType: 'G' | 'S',
  fine: number,
): LedgerLine {
  return {
    ...key,
    VCH_TYPE: ACOP_TYPE,
    VCH_DATE: vchDate,
    AC_CODE: acCode,
    IT_TYPE: itType,
    SIGN: fine >= 0 ? '+' : '-',
    FINE_WT: Math.abs(fine),
    FINE_RATE: 0,
    DR_AMT: 0,
    CR_AMT: 0,
  };
}

/**
 * One account-opening line: names an account and carries its opening money debit / credit (the
 * IT_TYPE 'A' leg). A metal account additionally opens its fine balance via goldFine / silverFine,
 * each of which emits a SEPARATE AC_DATA metal leg (IT_TYPE 'G' / 'S') — the desktop ACOP layout
 * stores the money on the 'A' leg and the metal fine on its own 'G'/'S' leg.
 *
 * (Legacy fineWt / itType are kept for backward compatibility: they stamp FINE_WT / IT_TYPE on the
 * money leg itself. New callers should prefer goldFine / silverFine for the separate metal legs.)
 */
export interface AcOpeningLineInput {
  acCode: string;
  drAmt?: number;
  crAmt?: number;
  fineWt?: number;
  itType?: string;
  /**
   * Opening GOLD fine weight. When non-zero we emit an ADDITIONAL AC_DATA leg (IT_TYPE 'G') carrying
   * this fine, with DR_AMT=CR_AMT=0 so the Dr=Cr balance is untouched. The number's sign selects the
   * desktop SIGN: >= 0 ⇒ '+' (a debit/asset opening — metal held / owed to us), < 0 ⇒ '-' (a credit
   * opening — metal we owe). FINE_WT stores the magnitude |goldFine|.
   */
  goldFine?: number;
  /** Opening SILVER fine weight — same contract as goldFine but emits an IT_TYPE 'S' leg. */
  silverFine?: number;
}

export interface AcOpeningInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  lines: AcOpeningLineInput[];
}

export interface AcOpeningResult {
  vchNo: number;
}

/**
 * Account Opening Balance voucher (TR_AC_OPBL). Seeds the opening balances of ledger accounts as a
 * single balanced double-entry voucher: every line debits or credits one account and the only
 * output is the AC_DATA ledger — there is no header/detail/tax/stock row. We require ≥1 line and
 * Σ Dr == Σ Cr (assertBalanced, Req 13.1), then allocate the number + write the ledger inside ONE
 * tenant transaction so numbering and posting commit atomically (Req 9.x / 13.1).
 *
 * Each leg is stamped VCH_TYPE 'ACOP' (desktop parity). A metal-account opening line also emits a
 * SEPARATE IT_TYPE 'G'/'S' leg via goldFine / silverFine (FINE_WT = opening fine, SIGN '+' for a
 * debit/asset opening or '-' for a credit, DR=CR=0 so the balance is untouched); postVoucherTx only
 * overrides IT_TYPE when it is unset, so the per-line metal type wins. (Legacy fineWt + itType still
 * stamp those columns on the money leg for backward compatibility.)
 *
 * NOTE on columns: postVoucherTx auto-stamps the desktop ledger-line fields (LEDR_KEY, LD_CODE and
 * — because we pass bookName — BOOK_NAME) so they are NOT set here. The optional vchDate is stamped
 * on AC_DATA.VCH_DATE so the opening shows up in the date-scoped Day Book / account-ledger reports
 * (which filter and order AC_DATA by VCH_DATE).
 */
export async function postAcOpening(prisma: any, input: AcOpeningInput): Promise<AcOpeningResult> {
  const rawLines = input.lines ?? [];
  if (rawLines.length < 1)
    throw new AcOpeningValidationError('account opening requires at least 1 line');

  // Per-line shape: an account is required and the opening amounts cannot be negative.
  for (const l of rawLines) {
    if (!l.acCode || !String(l.acCode).trim())
      throw new AcOpeningValidationError('every opening line needs an account code');
    if (num(l.drAmt) < 0 || num(l.crAmt) < 0)
      throw new AcOpeningValidationError('opening amounts cannot be negative');
  }

  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const tenantId = input.scope.tenantId;

  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, ACO_BOOK);
    const ledger: LedgerLine[] = rawLines.flatMap((l) => {
      const dr = num(l.drAmt);
      const cr = num(l.crAmt);
      const moneyLeg: LedgerLine = {
        ...key,
        VCH_TYPE: ACOP_TYPE,
        VCH_DATE: vchDate,
        AC_CODE: l.acCode,
        DR_AMT: dr,
        CR_AMT: cr,
        SIGN: dr > 0 ? 'D' : 'C',
        // Opening fine weight + metal type for metal accounts ('A' money is the default); IT_TYPE is
        // set here (not left null) so postVoucherTx keeps the per-line 'G'/'S' instead of defaulting.
        FINE_WT: l.fineWt ?? 0,
        IT_TYPE: l.itType ?? 'A',
      };
      // Desktop parity: a metal account also opens its GOLD/SILVER fine balance as a SEPARATE AC_DATA
      // leg (IT_TYPE 'G'/'S', SIGN '+' debit-asset / '-' credit, FINE_WT = opening fine, money cols 0
      // so Σ Dr == Σ Cr is untouched). Skip when the fine is zero/absent so money-only openings are
      // unchanged.
      const legs: LedgerLine[] = [moneyLeg];
      const gold = num(l.goldFine);
      if (gold !== 0) legs.push(metalLeg(key, vchDate, l.acCode, 'G', gold));
      const silver = num(l.silverFine);
      if (silver !== 0) legs.push(metalLeg(key, vchDate, l.acCode, 'S', silver));
      return legs;
    });
    // Σ Dr must equal Σ Cr (Req 13.1). postVoucherTx re-asserts this, but we fail fast here too.
    assertBalanced(ledger);
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: ACO_BOOK_NAME,
    });
    return { vchNo };
  });
}

export interface DeleteAcOpeningInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string; // CO_BOOK used at creation (defaults to 'ACO')
  deleteUser?: string;
}

/**
 * Delete/reverse an account-opening voucher: remove its AC_DATA ledger rows by voucher key and
 * write a DELETE_DATA audit row — all in one transaction (Req 13.4). Opening vouchers write only
 * AC_DATA, so that is the single table reversed.
 */
export async function deleteAcOpening(
  prisma: any,
  input: DeleteAcOpeningInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book ?? ACO_BOOK);
  return withTenant(prisma, tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...key,
          VCH_TYPE: ACOP_TYPE,
          BOOK_NAME: ACO_BOOK_NAME,
          DELETE_USER: input.deleteUser ?? 'system',
        },
      },
    });
    return { reversed: true };
  });
}
