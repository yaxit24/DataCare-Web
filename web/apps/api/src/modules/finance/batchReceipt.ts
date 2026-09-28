import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
} from '../posting/posting.js';
import { type PayMode } from './finance.js';
import { requirePostingAccount, resolveBookSlotAccountTx } from '../shared/postingAccounts.js';

export class BatchReceiptValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'BatchReceiptValidationError';
  }
}

/** Book code (CO_BOOK) and ledger BOOK_NAME stamped on (batch) receipt vouchers (desktop parity). */
const RCT_BOOK = 'RCT';
const RCT_BOOK_NAME = 'RECEIPT';
/** Desktop receipt voucher type — every CASH_DATA row and AC_DATA leg is marked VCH_TYPE 'RCT'. */
const RCT_TYPE = 'RCT';

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
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

/**
 * One collection line of a multi-party receipt: who paid us, how much was received, by what mode,
 * with an optional cheque number and an optional kasar (discount / round-off) written off on that
 * party so their balance clears in full.
 */
export interface BatchReceiptLineInput {
  partyAc: string; // who paid us
  partyName?: string;
  amount: number; // money actually received into cash/bank
  mode: PayMode; // cash | cheque | card | upi | bank
  bankAc?: string; // cash/bank ledger receiving the money (defaults by mode)
  chqNo?: string;
  kasarAmt?: number; // discount / round-off written off on this party (>= 0)
  /** Write-off ledger for this line's kasar. Required when `kasarAmt` is non-zero (P0-04). */
  kasarAc?: string;
  bankCharges?: number; // BANK_CHARGES — the bank's own charge on the instrument (varchar in schema)
  chqPrintName?: string; // CHQ_PRINT_NAME — the payee name printed on the cheque
  clearDate?: Date | string; // CLR_DATE — when the instrument cleared
  itemDescriptionCode?: number; // IT_DESC — numeric in this table despite the name
}

export interface BatchReceiptInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  lines: BatchReceiptLineInput[];
  /** Voucher-level write-off ledger, used by any line that does not name its own. */
  kasarAc?: string;
}

export interface BatchReceiptResult {
  vchNo: number;
  total: number; // Σ amount received across all lines (cash/bank in)
}

/**
 * Multi-Party Receipt (Phase 6 / TR_CASH grid). Collects money IN from several parties in ONE
 * receipt voucher. Each line settles exactly one party:
 *   • Dr cash/bank (settlementAc by mode) for the amount actually received
 *   • Dr KASAR (discount / round-off) for the kasar written off — only when kasar > 0
 *   • Cr party for (amount + kasar) — clears the party's balance in full
 *
 * Across every line Σ Dr (= Σ amount + Σ kasar) equals Σ Cr (= Σ (amount + kasar)), so the whole
 * voucher is balanced (assertBalanced, Req 13.1). One CASH_DATA row is written per line (desktop
 * TR_CASH grid parity) carrying VCH_TYPE 'RCT', the received REC_AMT, the KASAR_AMT, the paying
 * party AC_CODE and the receiving cash/bank REC_AC_CODE. Numbering, the AC_DATA ledger and the
 * CASH_DATA headers all commit inside ONE tenant transaction (Req 9.x / 13.1); any failure rolls
 * the whole voucher back.
 *
 * NOTE on columns: postVoucherTx auto-stamps the desktop ledger-line fields (LEDR_KEY, IT_TYPE,
 * LD_CODE and — because we pass bookName — BOOK_NAME) on each AC_DATA leg, so they are NOT set here.
 * Each leg carries VCH_DATE so the receipt shows up in the date-scoped Day Book / account-ledger
 * reports (which filter and order AC_DATA by VCH_DATE). The mode is lower-cased before routing so a
 * 'CASH'/'cash' (etc.) from any caller settles to the correct cash/bank ledger.
 */
export async function postBatchReceipt(
  prisma: any,
  input: BatchReceiptInput,
): Promise<BatchReceiptResult> {
  const rawLines = input.lines ?? [];
  if (rawLines.length < 1)
    throw new BatchReceiptValidationError('batch receipt requires at least 1 line');

  // Per-line shape: a party is required, the received amount must be positive, kasar cannot be < 0.
  for (const l of rawLines) {
    if (!l.partyAc || !String(l.partyAc).trim())
      throw new BatchReceiptValidationError('every receipt line needs a party account');
    if (!(num(l.amount) > 0))
      throw new BatchReceiptValidationError(`amount must be positive for party "${l.partyAc}"`);
    if (num(l.kasarAmt) < 0)
      throw new BatchReceiptValidationError(`kasar cannot be negative for party "${l.partyAc}"`);
  }

  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const tenantId = input.scope.tenantId;

  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, RCT_BOOK);
    const base = { ...key, VCH_TYPE: RCT_TYPE, VCH_DATE: vchDate };
    // P0-04: the settlement and write-off accounts used to be the literals `'CASH'`/`'BANK'` and a module
    // constant `'KASAR'`. Neither exists in a real dataset. The book's configured slot 1 answers for the
    // settlement, the caller names the write-off account, and a collection that needs either without having
    // one is refused inside this transaction — so the voucher serial taken above rolls back with it.
    const bookSettlementAc = await resolveBookSlotAccountTx(tx, input.scope, 'cash-settlement', 1);

    const ledger: LedgerLine[] = [];
    const cashRows: Record<string, unknown>[] = [];
    let total = 0;

    rawLines.forEach((l, idx) => {
      const mode = String(l.mode || 'cash').toLowerCase() as PayMode;
      const amount = round2(num(l.amount));
      const kasar = round2(num(l.kasarAmt));
      // An explicit bank wins for a non-cash line; cash settles to the book's configured account.
      const recAc =
        mode === 'cash'
          ? bookSettlementAc
          : requirePostingAccount(
              'bank-settlement',
              l.bankAc,
              `batch receipt line ${idx + 1} settles ${amount} by ${mode}`,
            );
      const cleared = round2(amount + kasar); // party credited the full settlement (received + kasar)
      total = round2(total + amount);

      // Dr cash/bank for the money actually received.
      ledger.push({ ...base, AC_CODE: recAc, DR_AMT: amount, CR_AMT: 0, SIGN: 'D' });
      // Dr the write-off account for the give-up — only when there is one.
      if (kasar > 0) {
        const kasarAc = requirePostingAccount(
          'kasar',
          l.kasarAc ?? input.kasarAc,
          `batch receipt line ${idx + 1} writes off ${kasar}`,
        );
        ledger.push({ ...base, AC_CODE: kasarAc, DR_AMT: kasar, CR_AMT: 0, SIGN: 'D' });
      }
      // Cr the party for amount + kasar (clears the party in full).
      ledger.push({ ...base, AC_CODE: l.partyAc, DR_AMT: 0, CR_AMT: cleared, SIGN: 'C' });

      // One CASH_DATA header row per collection line (desktop TR_CASH grid parity).
      cashRows.push({
        ...key,
        SR_NO: idx + 1,
        VCH_TYPE: RCT_TYPE,
        VCH_DATE: vchDate,
        BOOK_NAME: RCT_BOOK_NAME,
        AC_CODE: l.partyAc,
        AC_NAME: l.partyName ?? null,
        REC_AMT: amount,
        KASAR_AMT: kasar,
        REC_AC_CODE: recAc,
        CHQ_NO: l.chqNo ?? null,
        // TR_CASH.cs also records the bank's own charge on the instrument, the name to print on the
        // cheque, the clearing date and a description. MOB_ENTRY_SAVE marks a row saved from the mobile
        // entry path; a desktop-equivalent web save is 'N'.
        // BANK_CHARGES, CHQ_PRINT_NAME and MOB_ENTRY_SAVE are varchar(255) in the restored schema, so
        // they are written as text. IT_DESC is NUMERIC here despite the name — an oddity of the restored
        // schema, so a numeric value is written rather than a caption.
        BANK_CHARGES: Number(round2(num(l.bankCharges))) || 0,
        CHQ_PRINT_NAME: (l.chqPrintName ?? '').trim().slice(0, 255) || null,
        CLR_DATE: l.clearDate ? new Date(l.clearDate) : null,
        IT_DESC: num(l.itemDescriptionCode),
        MOB_ENTRY_SAVE: 'N',
      });
    });

    // Σ Dr must equal Σ Cr (Req 13.1). postVoucherTx re-asserts this, but we fail fast here too.
    assertBalanced(ledger);
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [{ table: 'CASH_DATA', rows: cashRows }],
      bookName: RCT_BOOK_NAME,
    });
    return { vchNo, total: round2(total) };
  });
}

export interface DeleteBatchReceiptInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string; // CO_BOOK used at creation (defaults to 'RCT')
  deleteUser?: string;
}

/**
 * Delete/reverse a multi-party receipt: remove its CASH_DATA header rows and AC_DATA ledger rows by
 * voucher key, and write a DELETE_DATA audit row — all in one transaction (Req 13.4). A batch
 * receipt writes the CASH_DATA grid + the AC_DATA ledger, so those two tables are reversed.
 */
export async function deleteBatchReceipt(
  prisma: any,
  input: DeleteBatchReceiptInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book ?? RCT_BOOK);
  return withTenant(prisma, tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['CASH_DATA', 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...key,
          VCH_TYPE: RCT_TYPE,
          BOOK_NAME: RCT_BOOK_NAME,
          DELETE_USER: input.deleteUser ?? 'system',
        },
      },
    });
    return { reversed: true };
  });
}
