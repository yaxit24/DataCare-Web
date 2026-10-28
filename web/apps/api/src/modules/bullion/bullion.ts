import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  resolveBookAccountTx,
  BookPolicyValidationError,
  type BookPolicy,
} from '../shared/bookPolicy.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
} from '../posting/posting.js';

/**
 * Bullion Booking (Phase 8 — desktop TR_BUL_BOOKING / BUL_DATA). A party books a bulk quantity of
 * fine metal at a locked rate (amount = fineWt × rate). The header row lands in BUL_DATA and the
 * balanced double-entry goes to AC_DATA. A later settlement/sale (TR_BUL_SALE) draws this booking
 * down against ADJ_WT. Errors surface as BullionValidationError → HTTP 400 via the route adapter.
 */
export class BullionValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'BullionValidationError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

const num = (v: unknown): number => (v == null ? 0 : Number(v));
const round2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
const round3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

/** Voucher key for a bullion booking (book defaults to 'BUL' — the desktop bullion book). */
function keyOf(s: VoucherScope, vchNo: number | string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'BUL',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

/**
 * G121 / P0-04: resolve a bullion booking account from the book's BOOK_DETL slot (1 = payable/control,
 * 2 = cash), honouring an explicit caller override. The seeded BUL book carries slot 1 = BULLION and
 * slot 2 = CASH; fail closed on a missing/ambiguous slot rather than a literal.
 */
async function resolveBullionAccountTx(
  tx: any,
  scope: VoucherScope,
  srNo: number,
  override?: string,
): Promise<string> {
  const trimmed = (override ?? '').trim();
  if (trimmed) return trimmed;
  const coBook = scope.coBook ?? 'BUL';
  const policy: BookPolicy = {
    coBook,
    vchType: 'BULBK',
    bookName: 'BUL SALE',
    mainBook: 'BUL SALE',
    inout: 'I',
  };
  try {
    return await resolveBookAccountTx(tx, { ...scope, coBook }, policy, srNo);
  } catch (e) {
    if (e instanceof BookPolicyValidationError)
      throw new BullionValidationError(
        `bullion book ${coBook} account slot ${srNo} is not configured: ${e.message}`,
      );
    throw e;
  }
}

export interface BullionBookingInput {
  scope: VoucherScope; // tenantId, coCode, lcCode, coYear, coBook
  partyAc: string; // booking party account (required)
  fineWt: number; // fine metal weight booked
  rate: number; // locked rate per fine unit
  amount?: number; // override for fineWt × rate (e.g. per-10g / per-kg rates handled upstream)
  advanceAmt?: number; // advance cash received now (Dr cash / Cr party)
  vchDate?: Date | string;
  itCode?: string; // metal item code (optional)
  itType?: string; // metal type 'G'/'S' (default 'G')
  payableAc?: string; // bullion-payable ledger (default 'BULLION')
  cashAc?: string; // advance cash ledger (default 'CASH')
  amtType?: string; // settlement type 'C'(cash)/'B'(bank) (default 'C')
  empCode?: string;
  itDesc?: string;
  mainUser?: string;
}

export interface BullionBookingResult {
  vchNo: number;
  amount: number;
}

/**
 * Build the balanced AC_DATA ledger for a booking (pure, Req 13.1):
 *   Dr party (booked value) / Cr bullion-payable (our obligation to deliver metal).
 * When an advance is received now, add Dr cash / Cr party — the party's net receivable becomes
 * amount − advance while the whole voucher stays balanced (Σ DR = Σ CR).
 */
export function buildBookingLedger(p: {
  key: VoucherKey;
  partyAc: string;
  payableAc: string;
  cashAc: string;
  amount: number;
  advanceAmt: number;
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: 'BUL' };
  const amount = round2(p.amount);
  const advance = round2(p.advanceAmt);
  const lines: LedgerLine[] = [
    { ...base, AC_CODE: p.partyAc, DR_AMT: amount, CR_AMT: 0, SIGN: 'D' }, // party owes the booked value
    { ...base, AC_CODE: p.payableAc, DR_AMT: 0, CR_AMT: amount, SIGN: 'C' }, // bullion payable (deliver metal later)
  ];
  if (advance > 0) {
    lines.push({ ...base, AC_CODE: p.cashAc, DR_AMT: advance, CR_AMT: 0, SIGN: 'D' }); // advance cash received
    lines.push({ ...base, AC_CODE: p.partyAc, DR_AMT: 0, CR_AMT: advance, SIGN: 'C' }); // reduce party receivable
  }
  return lines;
}

/**
 * Create a bullion booking end-to-end in ONE transaction (Req 9/10/13): allocate the voucher no,
 * post the balanced ledger, and write the BUL_DATA header. Any failure rolls the whole thing back.
 */
export async function bullionBooking(
  prisma: any,
  input: BullionBookingInput,
): Promise<BullionBookingResult> {
  if (!input.partyAc) throw new BullionValidationError('party account (partyAc) is required');
  const fineWt = round3(num(input.fineWt));
  const rate = num(input.rate);
  if (!(fineWt > 0)) throw new BullionValidationError('fineWt must be positive');
  if (input.amount == null && !(rate > 0))
    throw new BullionValidationError('rate must be positive');
  const amount = round2(input.amount != null ? num(input.amount) : fineWt * rate);
  if (!(amount > 0)) throw new BullionValidationError('amount must be positive');
  const advanceAmt = round2(num(input.advanceAmt));

  const tenantId = input.scope.tenantId;

  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    // G121 / P0-04: the payable and funding accounts come from the booking book's BOOK_DETL slots
    // (slot 1 = bullion payable/control, slot 2 = cash), not literals; explicit overrides still win.
    const payableAc = await resolveBullionAccountTx(tx, input.scope, 1, input.payableAc);
    const cashAc = await resolveBullionAccountTx(tx, input.scope, 2, input.cashAc);
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo);
    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();

    const ledger = buildBookingLedger({
      key,
      partyAc: input.partyAc,
      payableAc,
      cashAc,
      amount,
      advanceAmt,
    });
    assertBalanced(ledger);

    // BUL_DATA header — only columns that EXIST (verified against the live schema). fineWt → ITM_GWT
    // & ITM_NWT, rate → ITM_RATE, amount → ITM_AMT/TOT_AMT; ADJ_WT 0 (nothing settled/sold yet).
    const header = {
      ...key,
      SR_NO: 1,
      OLD_SRNO: 1,
      VCH_DATE: vchDate,
      VCH_TIME: vchDate,
      VCH_TYPE: 'BUL',
      INOUT_TYPE: 'I', // booking is the inbound side a later BUL SALE draws against
      ENTRY_TYPE: 'S',
      BOOK_NAME: 'BULLION',
      AC_CODE: input.partyAc,
      IT_CODE: input.itCode ?? null,
      IT_TYPE: input.itType ?? 'G',
      ITM_GWT: fineWt,
      ITM_NWT: fineWt,
      ADJ_WT: 0,
      MCX_RATE: rate,
      ITM_RATE: rate,
      ITM_AMT: amount,
      PRM_AMT: 0,
      AMT_TYPE: input.amtType ?? 'C',
      TAX_PRC: 0,
      TOT_AMT: amount,
      IT_DESC: input.itDesc ?? null,
      EMP_CODE: input.empCode ?? null,
      ENTRY_TIME: new Date(),
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
      MAIN_USER: input.mainUser ?? 'system',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: 'BULLION',
      writes: [{ table: 'BUL_DATA', rows: [header] }],
    });

    return { vchNo, amount };
  });
}

export interface DeleteBullionBookingInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}

/**
 * Delete/reverse a bullion booking in ONE transaction (Req 13.4): remove BUL_DATA + AC_DATA by
 * voucher key and write a DELETE_DATA audit row.
 */
export async function deleteBullionBooking(
  prisma: any,
  input: DeleteBullionBookingInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo));
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['BUL_DATA', 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'BUL', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}
