import { withTxBudget } from '../shared/txBudget.js';
import { DEFAULT_CASH_LIMIT, resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { buildCashRojmel, buildJournalRojmel } from '../shared/rojmel.js';
import { requirePostingAccount, resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
  type VoucherWrite,
} from '../posting/posting.js';
import {
  completeFinanceScope,
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  voucherKey,
  type VoucherIdentity,
} from './lifecycle.js';
import { tenderThresholdDecision } from './tender.js';

export class FinanceValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'FinanceValidationError';
  }
}

export { DEFAULT_CASH_LIMIT } from '../shared/settingsBehavior.js';

export type PayMode = 'cash' | 'cheque' | 'card' | 'upi' | 'bank';

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

/**
 * The `BOOK_DATA.MAIN_BOOK` values a receipt or payment may be written to, and which mode each allows.
 *
 * Desktop: each menu fixes the book family before the form opens (MDI_FORM.cs:8052-8099):
 * - Cash Received → `CurBookHelp("CASH REC")`
 * - Cash Payment → `"CASH PAY"`
 * - Bank Received → `"BANK REC"`
 * - Bank Payment → `"BANK PAY"`
 *
 * `CurBookHelp` lists only books of that MAIN_BOOK (DC_Main.cs:1489-1559), and the book decides the
 * cash or bank layout (TR_CASH.cs:2629-2650). A receipt therefore cannot reach a sales book, and a cash
 * receipt cannot reach a bank book.
 *
 * The web chooses the mode on the form, so the pairing is enforced here instead. Before this check
 * any active book was accepted, and a receipt could be numbered and posted inside a SALES book.
 *
 * `RECEIPT` and `PAYMENT` are the generic books that web provisioning creates (seedCompany). They are
 * not desktop MAIN_BOOK values, and they allow every mode.
 */
const FINANCE_BOOK_FAMILIES = {
  receipt: { 'CASH REC': 'cash', 'BANK REC': 'bank', RECEIPT: 'any' },
  payment: { 'CASH PAY': 'cash', 'BANK PAY': 'bank', PAYMENT: 'any' },
} as const satisfies Record<'receipt' | 'payment', Record<string, 'cash' | 'bank' | 'any'>>;

type FinanceDirection = keyof typeof FINANCE_BOOK_FAMILIES;

/** Resolve the configured book and refuse one outside the receipt/payment family or the mode's layout. */
async function financeBookTx(
  tx: any,
  scope: VoucherScope,
  direction: FinanceDirection,
  mode: PayMode,
): Promise<Awaited<ReturnType<typeof configuredBookTx>> & { layout: 'cash' | 'bank' | 'any' }> {
  const book = await configuredBookTx(tx, scope);
  const mainBook = book.mainBook.toUpperCase();
  const family = FINANCE_BOOK_FAMILIES[direction] as Record<string, 'cash' | 'bank' | 'any'>;
  const allowed = family[mainBook];
  if (!allowed) {
    throw new FinanceValidationError(
      `book ${scope.coBook} is a ${mainBook || 'unclassified'} book; a ${direction} needs a ${Object.keys(family).join(', ')} book`,
    );
  }
  const wanted = mode === 'cash' ? 'cash' : 'bank';
  if (allowed !== 'any' && allowed !== wanted) {
    throw new FinanceValidationError(
      `book ${scope.coBook} is a ${mainBook} book and cannot take a ${mode} ${direction}`,
    );
  }
  return { ...book, layout: allowed };
}

/**
 * The cash or bank account a receipt/payment settles to: the caller's account, else the book's BOOK_DETL slot 1.
 *
 * A desktop CASH REC/PAY book's slot 1 is the cash account and a BANK REC/PAY book's slot 1 is the bank account
 * (TR_CASH.cs:2629-2650 lays the form out from the book), so slot 1 is always the right default for the book's own
 * mode. The generic web RECEIPT/PAYMENT books take every mode with CASH in slot 1, so a bank, card, UPI or cheque
 * movement in them has no configured account: it must name one, and it may not name the cash account. Before
 * this, a "bank" payment left without a bank account was posted to cash on hand (found in the browser, E2E
 * 2026-10-26).
 */
async function financeSettlementAccountTx(
  tx: any,
  scope: VoucherScope,
  book: { layout: 'cash' | 'bank' | 'any' },
  direction: FinanceDirection,
  mode: PayMode,
  explicit: unknown,
): Promise<string> {
  const role = mode === 'cash' ? 'cash-settlement' : 'bank-settlement';
  if (mode === 'cash' || book.layout !== 'any')
    return resolveBookSlotAccountTx(tx, scope, role, 1, explicit);
  const chosen = String(explicit ?? '').trim();
  if (!chosen)
    throw new FinanceValidationError(
      `a ${mode} ${direction} in book ${scope.coBook} needs the bank account it ${direction === 'receipt' ? 'is paid into' : 'is paid from'}`,
    );
  const cashAc = await resolveBookSlotAccountTx(tx, scope, 'cash-settlement', 1).catch(() => '');
  if (cashAc && chosen === cashAc)
    throw new FinanceValidationError(
      `a ${mode} ${direction} cannot settle to the cash account ${cashAc}; choose the bank account`,
    );
  return chosen;
}

/**
 * The kasar (write-off) account: an explicit account, else BOOK_DETL slot 2 of the book.
 *
 * Ac_Ledr.cs:571-581 posts the kasar legs of CASH REC / CASH PAY (and, in the same shape, BANK REC /
 * BANK PAY) by joining `BOOK_DETL ... B.SR_NO = 2 AND A.KASAR_AMT <> 0`.
 *
 * Before this, the web required the caller to send the account. The form had no field for it, so
 * every write-off entered on screen was refused.
 *
 * Web adaptation: slot 2 is refused when it names the same account as the slot-1 settlement account.
 * Web provisioning used to give cash books CASH in both slots, and a write-off posted to the cash
 * account would overstate cash on hand.
 */
export async function kasarAccountTx(
  tx: any,
  scope: VoucherScope,
  explicit: unknown,
  settlementAc: string,
  kasar: number,
): Promise<string> {
  if (String(explicit ?? '').trim()) {
    return requirePostingAccount('kasar', explicit, `book ${scope.coBook} writes off ${kasar}`);
  }
  const account = await resolveBookSlotAccountTx(tx, scope, 'kasar', 2);
  if (account === settlementAc) {
    throw new FinanceValidationError(
      `book ${scope.coBook} slot 2 (kasar) names the settlement account ${account}; configure a kasar account in slot 2 before writing off ${kasar}`,
    );
  }
  return account;
}

/**
 * Compatibility helper retained for callers/tests. Desktop PAN enforcement is a taxable-sale rule,
 * not a cash-payment override (TR_SALE.cs:15111-15128), so payment/receipt writers do not call it.
 */
export function assertCashLimit(
  mode: PayMode,
  amount: number,
  pan: string | undefined,
  limit = DEFAULT_CASH_LIMIT,
): void {
  if (mode === 'cash' && amount > limit && !(pan && pan.trim())) {
    throw new FinanceValidationError(`PAN required for cash transaction over ${limit}`);
  }
}

/** Strict active-company read; query errors/duplicates/invalid values fail the voucher closed. */
export async function cashLimitTx(tx: any, tenantId: string, coCode: unknown): Promise<number> {
  return (await resolveSettingsBehaviorTx(tx, { tenantId, coCode: String(coCode ?? '') }))
    .cashLimit;
}

/** A party's cumulative cash already received (Σ CASH_DATA.REC_AMT settled to CASH) — for the ceiling. */
export async function partyCashReceivedTx(
  tx: any,
  scope: VoucherScope,
  partyAc: string,
  cashAc = 'CASH',
): Promise<number> {
  // DC_Main.cs:2149-2165 LedrCash: cumulative AC_DATA CR for party whose contra is cash.
  const r: any[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(coalesce("CR_AMT",0)),0)::float s
       FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "AC_CODE"::text=$4::text AND "LD_CODE"::text=$5::text`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    String(partyAc),
    cashAc,
  );
  const value = Number(r?.[0]?.s);
  if (!Number.isFinite(value)) throw new FinanceValidationError('party cash total is unreadable');
  return value;
}

/**
 * Desktop cash-RECEIPT ceiling (TR_CASH.cs:2913–2922 "You Can Not Receive More Then Cash Limit").
 * A cash receipt is BLOCKED — with **no PAN escape** — when (this amount + the party's existing cash
 * received) exceeds the cash limit. This is distinct from the sales PAN-gate (`assertCashLimit`).
 */
export function assertCashReceiptCeiling(
  amount: number,
  priorCash: number,
  limit = DEFAULT_CASH_LIMIT,
  partyName = '',
): void {
  const total = round2(amount + priorCash);
  if (
    tenderThresholdDecision({
      cashAmount: amount,
      priorCash,
      billValue: 0,
      cashLimit: limit,
      panCardVal: Number.POSITIVE_INFINITY,
    }).cashBlocked
  ) {
    // TR_CASH.cs:2922; the following goto exits BtnSave_Click, so this is a hard block.
    throw new FinanceValidationError(
      `Cash Recieved Limit Amount = ${limit} \r\nOld Ledr Value Is ${priorCash} \r\nAnd Total Cash Amount Is ${total} \r\nYou Can Not Receive More Then Cash Limit...\r\nParty Name Is ${partyName} `,
    );
  }
}

/** A balanced two-line transfer ledger: Dr `drAc` / Cr `crAc` for `amount` (Req 13.1). */
/**
 * Desktop cash-book leg codes (direction-specific; receipt/payment share none):
 *   CASH REC 01 party Cr / 02 cash Dr · 03 party Cr / 04 kasar Dr (kasar 00057 JAVK)
 *   CASH PAY 05 party Dr / 06 cash Cr · 07 party Dr / 08 kasar Cr (kasar 00042 AVAK)
 * The kasar account mirrors the money (JAVK out / AVAK in). Bank codes are measured separately.
 */
const CASH_LEG = {
  recParty: 1,
  recCash: 2,
  recKasarParty: 3,
  recKasar: 4,
  payParty: 5,
  payCash: 6,
  payKasarParty: 7,
  payKasar: 8,
} as const;

/** BANK leg codes, measured across all 228 legs of the 11 active bank books. NOT a mirror of cash. (detail condensed; see git history / plan doc 06.) */
const BANK_LEG = {
  recParty: 1,
  recBank: 2,
  recKasarParty: 3,
  recKasar: 4,
  recChargesBank: 5,
  recCharges: 6,
  payParty: 7,
  payBank: 8,
  payChargesBank: 11,
  payCharges: 12,
} as const;

/** The leg map for a mode: bank payments use 07/08 where cash payments use 05/06. */
const legsFor = (mode: PayMode) =>
  mode === 'cash'
    ? { party: CASH_LEG.payParty, account: CASH_LEG.payCash }
    : { party: BANK_LEG.payParty, account: BANK_LEG.payBank };

export function buildTransferLedger(
  key: VoucherKey,
  vchType: string,
  drAc: string,
  crAc: string,
  amount: number,
): LedgerLine[] {
  const base = { ...key, VCH_TYPE: vchType };
  return [
    { ...base, AC_CODE: drAc, DR_AMT: amount, CR_AMT: 0, SIGN: 'D' },
    { ...base, AC_CODE: crAc, DR_AMT: 0, CR_AMT: amount, SIGN: 'C' },
  ];
}

/**
 * The cash/bank ledger code for a payment mode.
 *
 * P0-04: this used to return the literals `'CASH'` and `'BANK'`. Neither is an account — the real leg-02 rows
 * on book 001 all name `00001`, that book's `BOOK_DETL` slot 1 — so every caller that wrote the result to
 * `AC_CODE`/`LD_CODE` was posting to a placeholder that only resolves on a seeded demo company. Callers now
 * pass the account they resolved (explicit bank, or the book's configured slot) and this function only
 * chooses BETWEEN them by mode, refusing when the needed one is absent.
 */
export function settlementAc(
  mode: PayMode,
  bankAc?: string,
  cashAc?: string,
  context = 'settlement',
): string {
  return mode === 'cash'
    ? requirePostingAccount('cash-settlement', cashAc, `${context} settles in cash`)
    : requirePostingAccount('bank-settlement', bankAc, `${context} settles by ${mode}`);
}

const numv = (v: unknown): number => Number(v ?? 0);
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

export interface ReceiptInput {
  scope: VoucherScope;
  partyAc: string; // who paid us
  partyName?: string;
  amount: number;
  mode: PayMode;
  bankAc?: string; // cash/bank ledger receiving the money (defaults by mode)
  /**
   * The CASH_DATA line this movement belongs to, which becomes the leading digits of the ledger key's
   * 12-character tail.
   *
   * Real voucher 002/00029 has nine CASH_DATA lines and eighteen legs keyed 105/106 through 905/906, so the
   * line is not bounded at one. A single-line caller may omit it and get 1.
   */
  lineNo?: number;
  chqNo?: string;
  vchDate?: Date | string;
  // Payment-mode detail (desktop TR_CARD_REC / TR_UPI_REC):
  cardCommissionPct?: number; // card mode: bank/card commission % (default 0) → CARD_COM_AMT, net to bank
  bankName?: string; // card/upi: acquiring bank / UPI handle name
  upiId?: string; // upi mode: UPI transaction id / VPA ref
  kasar?: number; // round-off / write-off applied against the party (Dr KASAR), clears amount+kasar
  kasarAc?: string; // default 'KASAR'
  mainUser?: string;
}

export interface FinanceResult {
  vchNo: number;
}

type FinanceWriteContext = { tx: any; identity: VoucherIdentity };

/** Receipt (money IN): Dr cash/bank, Cr party. Header → CASH_DATA. */
export async function postReceipt(
  prisma: any,
  input: ReceiptInput,
  lifecycle?: FinanceWriteContext,
): Promise<FinanceResult> {
  if (!input.partyAc) throw new FinanceValidationError('party account is required');
  if (!(input.amount > 0)) throw new FinanceValidationError('amount must be positive');
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;

  completeFinanceScope(input.scope);
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const write = async (tx: any, identity: VoucherIdentity): Promise<FinanceResult> => {
    // The book first: a receipt must land in a receipt book whose layout matches the mode.
    const configuredBook = await financeBookTx(tx, input.scope, 'receipt', mode);
    // The cash/bank account is the book's BOOK_DETL slot 1 unless the caller names one.
    //
    // P0-04: this used to end in the literal `'CASH'` returned by `settlementAc`, which is a placeholder
    // rather than an account — the real leg-02 rows on book 001 all name 00001, that book's slot 1. The
    // placeholder is now gone in both directions: an explicit account still wins, a configured slot answers
    // otherwise, and a book with neither refuses the receipt before numbering instead of posting to a code
    // that only exists in the demo seed.
    const recAcResolved = await financeSettlementAccountTx(
      tx,
      input.scope,
      configuredBook,
      'receipt',
      mode,
      input.bankAc,
    );
    // Cash-receipt ceiling (desktop TR_CASH): block when this + the party's prior cash exceeds the
    // CO_SET.CASH_LIMIT — no PAN escape (R7). Non-cash modes are exempt.
    if (mode === 'cash') {
      const limit = await cashLimitTx(tx, tenantId, input.scope.coCode);
      const prior = await partyCashReceivedTx(tx, input.scope, input.partyAc, recAcResolved);
      assertCashReceiptCeiling(input.amount, prior, limit, input.partyName);
    }
    const vchNo = identity.vchNo;
    const key = keyOf(input.scope, vchNo, 'RCT');
    const vchType = mode === 'cash' ? 'CREC' : 'BREC';
    const kasar = round2(Number(input.kasar ?? 0));
    const kasarAc =
      kasar > 0 ? await kasarAccountTx(tx, input.scope, input.kasarAc, recAcResolved, kasar) : '';
    const lbase = { ...key, VCH_TYPE: vchType };
    // A SELF-BALANCED PAIR PER MOVEMENT, with the party leg repeated - not one netted party credit.
    //
    // Measured on book 001 (CASH REC), all 162 legs: the amount pair is 01 party Cr / 02 cash Dr (56 each) and
    // the kasar pair is 03 party Cr / 04 kasar Dr (25 each). Real voucher 001/00001 is one CASH_DATA line with
    // REC_AMT 60000.00 and KASAR_AMT 771.00, and it writes FOUR legs: the party is credited twice, once against
    // cash and once against kasar.
    //
    // This previously wrote THREE legs with the party credited once for amount + kasar. Both balance, so no
    // balance assertion could see it - but the leg COUNT differs, so a per-account ledger report showed one
    // line where the desktop shows two.
    //
    // The sale family already does this correctly (`buildSaleLedger`: "Desktop emits a self-balanced
    // party/tender pair, not a netted party balance"), so the two paths disagreed with each other.
    //
    // The key tail is `<line><leg>` as ONE field right-aligned in 12 - not the scheme's bare line number, and
    // not the sale's two characters at 22-23. `legKeySuffix` states it explicitly because no two families agree.
    const lineNo = Number(input.lineNo ?? 1);
    const suffix = (leg: number): string =>
      `${lineNo}${String(leg).padStart(2, '0')}`.padStart(12, ' ');
    const ledger: LedgerLine[] = [
      {
        ...lbase,
        legKeySuffix: suffix(CASH_LEG.recParty),
        AC_CODE: input.partyAc,
        LD_CODE: recAcResolved,
        DR_AMT: 0,
        CR_AMT: input.amount,
        SIGN: 'C',
      },
      {
        ...lbase,
        legKeySuffix: suffix(CASH_LEG.recCash),
        AC_CODE: recAcResolved,
        LD_CODE: input.partyAc,
        DR_AMT: input.amount,
        CR_AMT: 0,
        SIGN: 'D',
      },
    ];
    if (kasar > 0) {
      ledger.push(
        {
          ...lbase,
          legKeySuffix: suffix(CASH_LEG.recKasarParty),
          AC_CODE: input.partyAc,
          LD_CODE: kasarAc,
          DR_AMT: 0,
          CR_AMT: kasar,
          SIGN: 'C',
        },
        {
          ...lbase,
          legKeySuffix: suffix(CASH_LEG.recKasar),
          AC_CODE: kasarAc,
          LD_CODE: input.partyAc,
          DR_AMT: kasar,
          CR_AMT: 0,
          SIGN: 'D',
        },
      );
    }
    assertBalanced(ledger);
    // The Rojmel. The cash books name the cash account but take their DEBIT/CREDIT from the PARTY's leg -
    // verified at 100% within each row type on the real data (book 001 type 01, 56 rows; book 002 type 04,
    // 175 rows). That part of the convention stands.
    //
    // CORRECTED: this comment used to end "the party's ledger figure, which INCLUDES any kasar written off,
    // not the cash actually tendered". That was wrong. Real voucher 001/00001 received 60000.00 against a
    // 771.00 write-off and its type-01 Rojmel row carries 60000.00 - the CASH tendered. The old claim was true
    // only of the code's own former shape, where the party's ledger leg was a single netted 60771; it described
    // the implementation and read as though it described the desktop.
    //
    // The write-off is not folded in anywhere: it gets its OWN PAIR of Rojmel rows, types 02/03 on a receipt
    // and 05/06 on a payment. Book 001 has 56 type-01 rows against 25 each of 02 and 03.
    const rojmelCtx = {
      scope: {
        coCode: input.scope.coCode,
        lcCode: input.scope.lcCode,
        coYear: input.scope.coYear!,
      },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate,
      vchType,
      bookName: configuredBook.name,
      partyName: input.partyName ?? '',
      partyCode: input.partyAc,
    };
    const rojmelRows = buildCashRojmel(rojmelCtx, {
      cashAc: recAcResolved,
      cashAmount: input.amount,
      direction: 'receipt',
      kasar,
      // Blank when nothing is written off: buildCashRojmel emits its kasar rows only when BOTH the
      // amount and the account are present. A non-zero write-off has already resolved its account.
      kasarAc,
    });
    const writes: VoucherWrite[] = [
      {
        table: 'CASH_DATA',
        rows: [
          {
            ...key,
            VCH_TYPE: vchType,
            REC_AMT: input.amount,
            KASAR_AMT: kasar,
            AC_CODE: input.partyAc,
            AC_NAME: input.partyName ?? null,
            REC_AC_CODE: recAcResolved,
            CHQ_NO: input.chqNo ?? null,
            VCH_DATE: vchDate,
            VCH_TIME: identity.voucherTime,
            HD_VCH_NO: identity.hiddenVoucherNo,
            MAIN_USER: identity.mainUser || null,
            BOOK_NAME: configuredBook.name,
            INOUT_TYPE: 'I',
            ENTRY_TYPE: mode === 'cash' ? 'C' : 'B',
          },
        ],
      },
    ];
    // Payment-mode detail tables (desktop TR_CARD_REC / TR_UPI_REC) — closes the CARD_DATA / UPI_DATA
    // write-path gap. Additive: cash/cheque/bank receipts are unchanged.
    if (mode === 'card') {
      const behavior = await resolveSettingsBehaviorTx(tx, input.scope);
      const comPct = round2(numv(input.cardCommissionPct));
      const comAmt = round2((input.amount * comPct) / 100);
      const net = round2(input.amount - comAmt);
      writes.push({
        table: 'CARD_DATA',
        rows: [
          {
            ...key,
            VCH_TYPE: vchType,
            INOUT_TYPE: 'I',
            ENTRY_TYPE: 'C',
            BOOK_NAME: 'BANK REC',
            VCH_TIME: vchDate,
            VCH_DATE: vchDate,
            AC_CODE: input.partyAc,
            AC_NAME: input.partyName ?? null,
            CARD_AMT: input.amount,
            CARD_COM_PRC: comPct,
            CARD_COM_AMT: comAmt,
            CARD_REC_AMT: net,
            BANK_ACCD: recAcResolved,
            BANK_NAME: input.bankName ?? null,
            BANK_NET_AMT: net,
            // TR_SALE.cs:18936 opens CARD ADJUST when CARD_COM_ADJ=Y; persist the workflow marker.
            IT_DESC: behavior.cardCommissionAdjustment
              ? 'Card receipt — adjustment required'
              : 'Card receipt',
            HD_VCH_NO: identity.hiddenVoucherNo,
            MAIN_USER: identity.mainUser || null,
            DATA_TRFR: 'N',
          },
        ],
      });
    } else if (mode === 'upi') {
      writes.push({
        table: 'UPI_DATA',
        rows: [
          {
            ...key,
            SR_NO: 1,
            VCH_DATE: vchDate,
            VCH_TIME: vchDate,
            AC_CODE: input.partyAc,
            UPI_AC_CODE: recAcResolved,
            UPI_AC_NAME: input.bankName ?? null,
            UPI_AMT: input.amount,
            UPI_ID: input.upiId ?? input.chqNo ?? null,
            HD_VCH_NO: identity.hiddenVoucherNo,
            MAIN_USER: identity.mainUser || null,
            UPI_TYPE: 'R',
          },
        ],
      });
    }
    await insertHiddenIdentityTx(tx, input.scope, identity, configuredBook.name);
    if (rojmelRows.length) writes.push({ table: 'ROJ_MEL_DATA', rows: rojmelRows });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: configuredBook.name,
      writes,
    });
    return { vchNo };
  };
  if (lifecycle) return write(lifecycle.tx, lifecycle.identity);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) =>
    write(tx, await createIdentityTx(tx, input.scope, vchDate, input.mainUser)),
  );
}

export interface PaymentInput {
  scope: VoucherScope;
  mainUser?: string;
  partyAc: string; // who we pay
  partyName?: string;
  amount: number;
  mode: PayMode;
  bankAc?: string;
  chqNo?: string;
  vchDate?: Date | string;
  kasar?: number; // discount received / round-off (Cr KASAR), clears amount+kasar on the party
  kasarAc?: string; // default 'KASAR'
  /**
   * The CASH_DATA line this movement belongs to; becomes the leading digits of the key's 12-character tail.
   *
   * Real voucher 002/00029 has nine lines and eighteen legs keyed 105/106 through 905/906, so the line is not
   * bounded at one. A single-line caller may omit it and get 1.
   */
  lineNo?: number;
}

/** Payment (money OUT): Dr party, Cr cash/bank. Header → PAY_DATA. */
export async function postPayment(
  prisma: any,
  input: PaymentInput,
  lifecycle?: FinanceWriteContext,
): Promise<FinanceResult> {
  if (!input.partyAc) throw new FinanceValidationError('party account is required');
  if (!(input.amount > 0)) throw new FinanceValidationError('amount must be positive');
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;

  completeFinanceScope(input.scope);
  const tenantId = input.scope.tenantId;
  const payVchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const write = async (tx: any, identity: VoucherIdentity): Promise<FinanceResult> => {
    // The book first, before numbering: a payment must land in a payment book matching the mode.
    const configuredBook = await financeBookTx(tx, input.scope, 'payment', mode);
    const vchNo = identity.vchNo;
    const key = keyOf(input.scope, vchNo, 'PAY');
    const vchType = mode === 'cash' ? 'CPAY' : 'BPAY';
    const kasar = round2(Number(input.kasar ?? 0));
    const lbase = { ...key, VCH_TYPE: vchType };
    // A SELF-BALANCED PAIR PER MOVEMENT, the mirror of the receipt - and with DIFFERENT leg codes.
    //
    // Measured on book 002 (CASH PAY), all 360 legs: the amount pair is 05 party Dr / 06 cash Cr (175 each) and
    // the kasar pair is 07 party Dr / 08 kasar Cr (5 each). A receipt and a payment share NO codes: the same
    // role takes a different number depending on which way the money moves.
    //
    // The KASAR ACCOUNT differs too. Book 002's leg-08 rows name 00042 KASAR AVAK, where book 001's leg-04 rows
    // name 00057 KASAR JAVK. Gujarati javak is outgoing and avak incoming, so the account mirrors the money
    // rather than the voucher - and one account for both directions would post half the discounts to the wrong
    // ledger. The caller supplies it; the default below is only a last resort.
    //
    // This previously netted the party DEBIT at amount + kasar into one leg, writing three where the desktop
    // writes four. It balanced, so only a leg-count assertion can catch it.
    // Slot 1 of BOOK_DETL, for the same reason as the receipt: book 002's leg-06 rows all name 00001. P0-04
    // removed the `'CASH'` placeholder that used to sit behind this, so an unconfigured book now refuses the
    // payment instead of posting to a code that only exists in the demo seed.
    const payAcResolved = await financeSettlementAccountTx(
      tx,
      input.scope,
      configuredBook,
      'payment',
      mode,
      input.bankAc,
    );

    const lineNo = Number(input.lineNo ?? 1);
    const suffix = (leg: number): string =>
      `${lineNo}${String(leg).padStart(2, '0')}`.padStart(12, ' ');
    const ledger: LedgerLine[] = [
      {
        ...lbase,
        legKeySuffix: suffix(legsFor(mode).party),
        AC_CODE: input.partyAc,
        LD_CODE: payAcResolved,
        DR_AMT: input.amount,
        CR_AMT: 0,
        SIGN: 'D',
      },
      {
        ...lbase,
        legKeySuffix: suffix(legsFor(mode).account),
        AC_CODE: payAcResolved,
        LD_CODE: input.partyAc,
        DR_AMT: 0,
        CR_AMT: input.amount,
        SIGN: 'C',
      },
    ];
    const kasarAc =
      kasar > 0 ? await kasarAccountTx(tx, input.scope, input.kasarAc, payAcResolved, kasar) : '';
    if (kasar > 0) {
      ledger.push(
        {
          ...lbase,
          legKeySuffix: suffix(CASH_LEG.payKasarParty),
          AC_CODE: input.partyAc,
          LD_CODE: kasarAc,
          DR_AMT: kasar,
          CR_AMT: 0,
          SIGN: 'D',
        },
        {
          ...lbase,
          legKeySuffix: suffix(CASH_LEG.payKasar),
          AC_CODE: kasarAc,
          LD_CODE: input.partyAc,
          DR_AMT: 0,
          CR_AMT: kasar,
          SIGN: 'C',
        },
      );
    }
    assertBalanced(ledger);
    // The Rojmel. The cash books name the cash account but take their DEBIT/CREDIT from the PARTY's leg -
    // verified at 100% within each row type on the real data (book 001 type 01, 56 rows; book 002 type 04,
    // 175 rows). That part of the convention stands.
    //
    // CORRECTED: this comment used to end "the party's ledger figure, which INCLUDES any kasar written off,
    // not the cash actually tendered". That was wrong. Real voucher 001/00001 received 60000.00 against a
    // 771.00 write-off and its type-01 Rojmel row carries 60000.00 - the CASH tendered. The old claim was true
    // only of the code's own former shape, where the party's ledger leg was a single netted 60771; it described
    // the implementation and read as though it described the desktop.
    //
    // The write-off is not folded in anywhere: it gets its OWN PAIR of Rojmel rows, types 02/03 on a receipt
    // and 05/06 on a payment. Book 001 has 56 type-01 rows against 25 each of 02 and 03.
    const rojmelCtx = {
      scope: {
        coCode: input.scope.coCode,
        lcCode: input.scope.lcCode,
        coYear: input.scope.coYear!,
      },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate: input.vchDate ? new Date(input.vchDate) : new Date(),
      vchType,
      bookName: mode === 'cash' ? 'CASH PAY' : 'BANK PAY',
      partyName: input.partyName ?? '',
      partyCode: input.partyAc,
    };
    const rojmelRows = buildCashRojmel(rojmelCtx, {
      cashAc: payAcResolved,
      cashAmount: input.amount,
      direction: 'payment',
      kasar,
      // Blank when nothing is written off: buildCashRojmel emits its kasar rows only when BOTH the
      // amount and the account are present. A non-zero write-off has already resolved its account.
      kasarAc,
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: mode === 'cash' ? 'CASH PAY' : 'BANK PAY',
      writes: [
        {
          table: 'PAY_DATA',
          rows: [
            {
              ...key,
              VCH_TYPE: vchType,
              NET_AMT: input.amount,
              TOT_AMT: input.amount,
              KASAR_AMT: kasar,
              AC_CODE: input.partyAc,
              AC_NAME: input.partyName ?? null,
              BANK_AC: mode === 'cash' ? null : payAcResolved,
              CASH_AMT: mode === 'cash' ? input.amount : 0,
              CHQ_AMT: mode === 'cheque' ? input.amount : 0,
              CARD_AMT: mode === 'card' ? input.amount : 0,
              CHQ_NO: input.chqNo ?? null,
              VCH_DATE: input.vchDate ? new Date(input.vchDate) : new Date(),
              HD_VCH_NO: identity.hiddenVoucherNo,
            },
          ],
        },
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    await insertHiddenIdentityTx(tx, input.scope, identity, configuredBook.name);
    return { vchNo };
  };
  if (lifecycle) return write(lifecycle.tx, lifecycle.identity);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) =>
    write(tx, await createIdentityTx(tx, input.scope, payVchDate, input.mainUser)),
  );
}

const PAYMENT_WRITE_TABLES = ['PAY_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const;

/** Edit a single-party payment: replace the write set and repost in one transaction (mirror editReceipt). */
export async function editPayment(
  prisma: any,
  input: PaymentInput,
  requestedVoucherNo: number | string,
): Promise<FinanceResult> {
  completeFinanceScope(input.scope);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'PAY_DATA',
      scope: input.scope,
      requestedVoucherNo,
      requestedDate,
    });
    await replaceWriteSetTx(
      tx,
      input.scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      PAYMENT_WRITE_TABLES,
    );
    return postPayment(prisma, input, { tx, identity });
  });
}

export interface ReceiptPaymentLine {
  partyAc: string;
  partyName?: string;
  amount: number;
  kasar?: number;
  itDesc?: string;
  empCode?: string;
}
export interface ReceiptPaymentLinesInput {
  scope: VoucherScope;
  mode?: PayMode; // cash|cheque|card|upi|bank
  bankAc?: string; // cash/bank ledger (defaults by mode)
  chqNo?: string;
  vchDate?: Date | string;
  kasarAc?: string; // default 'KASAR'
  empCode?: string; // header-level employee
  lines: ReceiptPaymentLine[];
}

function detlLines(
  key: VoucherKey,
  vchType: string,
  bookName: string,
  vchDate: Date,
  lines: ReceiptPaymentLine[],
) {
  return lines.map((l, i) => ({
    ...key,
    SR_NO: i + 1,
    VCH_DATE: vchDate,
    VCH_TYPE: vchType,
    BOOK_NAME: bookName,
    AC_CODE: l.partyAc,
    IT_NAME: l.partyName ?? null,
    NET_AMT: round2(Number(l.amount)),
    TAXABLE_AMT: round2(Number(l.amount)),
    TOT_AMT: round2(Number(l.amount) + Number(l.kasar ?? 0)),
    IT_REMARK: l.itDesc ?? null,
  }));
}

/** Multi-line receipt (money IN): one bank/cash Dr for the total + a Cr per party (each with its own
 *  kasar write-off). Header → CASH_DATA, per-party detail → PAY_DETL. Desktop TR_CASH multi-grid. */
export async function postReceiptLines(
  prisma: any,
  input: ReceiptPaymentLinesInput,
): Promise<FinanceResult & { total: number }> {
  const lines = (input.lines ?? []).filter((l) => l && l.partyAc && Number(l.amount) > 0);
  if (!lines.length)
    throw new FinanceValidationError('at least one receipt line (party + amount) is required');
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;
  const tenantId = input.scope.tenantId;
  const totalAmt = round2(lines.reduce((s, l) => s + Number(l.amount), 0));
  const totalKasar = round2(lines.reduce((s, l) => s + Number(l.kasar ?? 0), 0));
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const receiptBook = await financeBookTx(tx, input.scope, 'receipt', mode);
    // Resolved before the ceiling check and before numbering: the ceiling counts prior cash against THIS
    // account, so a placeholder would have measured the wrong ledger as well as posting to it.
    const recAcLines = await financeSettlementAccountTx(
      tx,
      input.scope,
      receiptBook,
      'receipt',
      mode,
      input.bankAc,
    );
    if (mode === 'cash') {
      const limit = await cashLimitTx(tx, tenantId, input.scope.coCode);
      for (const line of lines) {
        const prior = await partyCashReceivedTx(tx, input.scope, line.partyAc, recAcLines);
        assertCashReceiptCeiling(Number(line.amount), prior, limit, line.partyName);
      }
    }
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, 'RCT');
    const vchType = mode === 'cash' ? 'CREC' : 'BREC';
    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const lbase = { ...key, VCH_TYPE: vchType };
    // A PAIR PER MOVEMENT PER LINE, matching the payment path. This wrote one AGGREGATE cash debit plus one
    // aggregate kasar debit plus one netted party credit per line.
    //
    // The PATTERN is measured on the payment side: real voucher 002/00029 has nine CASH_DATA lines and eighteen
    // AC_DATA legs - a pair per line, no aggregate. The LEG CODES are measured on the receipt side: book 001's
    // 162 legs are 01 party Cr / 02 cash Dr and 03 party Cr / 04 kasar Dr.
    //
    // INFERRED, and labelled as such: every one of the 56 real receipt vouchers has exactly ONE line, so this
    // dataset contains no multi-line receipt to measure. What is applied is the measured payment PATTERN with
    // the measured receipt CODES.
    //
    // The alternative was not "leave it safe". postReceiptLines is reachable from a route and wrote NO Rojmel
    // rows at all, so a multi-line receipt produced an EMPTY DAY BOOK - certainly wrong. A shape that is
    // probably right beats one that is definitely wrong, and this note is what lets a later measurement
    // correct it.
    // Slot 1 of BOOK_DETL. Every leg-02 row on book 001 names 00001. This was the FIFTH occurrence of the
    // `'CASH'` placeholder — the others were postReceipt, postPayment, postPaymentLines and the scheme
    // instalment — so P0-04 removed it from all of them rather than from one.
    const recLineSuffix = (line: number, leg: number): string =>
      `${line}${String(leg).padStart(2, '0')}`.padStart(12, ' ');
    const recKasarAc =
      totalKasar > 0
        ? await kasarAccountTx(tx, input.scope, input.kasarAc, recAcLines, totalKasar)
        : '';
    const ledger: LedgerLine[] = [];
    lines.forEach((l, idx) => {
      const lineNo = idx + 1;
      const amt = round2(Number(l.amount));
      const lineKasar = round2(Number(l.kasar ?? 0));
      ledger.push(
        {
          ...lbase,
          legKeySuffix: recLineSuffix(lineNo, CASH_LEG.recParty),
          AC_CODE: l.partyAc,
          LD_CODE: recAcLines,
          DR_AMT: 0,
          CR_AMT: amt,
          SIGN: 'C',
        },
        {
          ...lbase,
          legKeySuffix: recLineSuffix(lineNo, CASH_LEG.recCash),
          AC_CODE: recAcLines,
          LD_CODE: l.partyAc,
          DR_AMT: amt,
          CR_AMT: 0,
          SIGN: 'D',
        },
      );
      if (lineKasar > 0) {
        const kasarAc = recKasarAc;
        ledger.push(
          {
            ...lbase,
            legKeySuffix: recLineSuffix(lineNo, CASH_LEG.recKasarParty),
            AC_CODE: l.partyAc,
            LD_CODE: kasarAc,
            DR_AMT: 0,
            CR_AMT: lineKasar,
            SIGN: 'C',
          },
          {
            ...lbase,
            legKeySuffix: recLineSuffix(lineNo, CASH_LEG.recKasar),
            AC_CODE: kasarAc,
            LD_CODE: l.partyAc,
            DR_AMT: lineKasar,
            CR_AMT: 0,
            SIGN: 'D',
          },
        );
      }
    });
    const recLinesRojmelRows = lines.flatMap((l, idx) =>
      buildCashRojmel(
        {
          scope: {
            coCode: input.scope.coCode,
            lcCode: input.scope.lcCode,
            coYear: input.scope.coYear!,
          },
          key,
          coBook: input.scope.coBook!,
          vchNo: String(vchNo).padStart(5, '0'),
          vchDate,
          bookName: mode === 'cash' ? 'CASH REC' : 'BANK REC',
          vchType,
          partyCode: l.partyAc,
          partyName: '',
        },
        {
          cashAc: recAcLines,
          cashAmount: round2(Number(l.amount)),
          direction: 'receipt',
          kasar: round2(Number(l.kasar ?? 0)),
          // Blank when nothing is written off; buildCashRojmel needs both amount and account.
          kasarAc: recKasarAc,
          lineNo: idx + 1,
        },
      ),
    );
    assertBalanced(ledger);
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: mode === 'cash' ? 'CASH REC' : 'BANK REC',
      writes: [
        ...(recLinesRojmelRows.length
          ? [{ table: 'ROJ_MEL_DATA' as const, rows: recLinesRojmelRows }]
          : []),
        {
          table: 'CASH_DATA',
          rows: [
            {
              ...key,
              VCH_TYPE: vchType,
              REC_AMT: totalAmt,
              KASAR_AMT: totalKasar,
              AC_CODE: lines[0]!.partyAc,
              REC_AC_CODE: recAcLines,
              CHQ_NO: input.chqNo ?? null,
              EMP_CODE: input.empCode ?? null,
              VCH_DATE: vchDate,
            },
          ],
        },
        {
          table: 'PAY_DETL',
          rows: detlLines(key, vchType, mode === 'cash' ? 'CASH REC' : 'BANK REC', vchDate, lines),
        },
      ],
    });
    return { vchNo, total: totalAmt };
  });
}

/** Multi-line payment (money OUT): one bank/cash Cr for the total + a Dr per party. Header → PAY_DATA. */
export async function postPaymentLines(
  prisma: any,
  input: ReceiptPaymentLinesInput,
): Promise<FinanceResult & { total: number }> {
  const lines = (input.lines ?? []).filter((l) => l && l.partyAc && Number(l.amount) > 0);
  if (!lines.length)
    throw new FinanceValidationError('at least one payment line (party + amount) is required');
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;
  const tenantId = input.scope.tenantId;
  const totalAmt = round2(lines.reduce((s, l) => s + Number(l.amount), 0));
  const totalKasar = round2(lines.reduce((s, l) => s + Number(l.kasar ?? 0), 0));
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const paymentBook = await financeBookTx(tx, input.scope, 'payment', mode);
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, 'PAY');
    const vchType = mode === 'cash' ? 'CPAY' : 'BPAY';
    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const lbase = { ...key, VCH_TYPE: vchType };
    // A PAIR PER LINE, each with its own line number - not one party leg per line plus aggregate cash.
    //
    // Real voucher 002/00029 is NINE CASH_DATA lines and EIGHTEEN AC_DATA legs, keyed 105/106 through 905/906.
    // Every line gets its own cash leg; there is no aggregate. This previously wrote one netted party leg per
    // line plus a single aggregate cash leg plus a single aggregate kasar leg - eleven legs for nine lines.
    //
    // It balanced, which is why it survived. What it cannot do is reproduce a per-account ledger: the desktop
    // shows nine cash movements and the aggregate form shows one.
    const payAcLinesResolved = await financeSettlementAccountTx(
      tx,
      input.scope,
      paymentBook,
      'payment',
      mode,
      input.bankAc,
    );

    const lineSuffix = (line: number, leg: number): string =>
      `${line}${String(leg).padStart(2, '0')}`.padStart(12, ' ');
    const payKasarAc =
      totalKasar > 0
        ? await kasarAccountTx(tx, input.scope, input.kasarAc, payAcLinesResolved, totalKasar)
        : '';
    const ledger: LedgerLine[] = [];
    lines.forEach((l, idx) => {
      const lineNo = idx + 1;
      const amt = round2(Number(l.amount));
      const lineKasar = round2(Number(l.kasar ?? 0));
      ledger.push(
        {
          ...lbase,
          legKeySuffix: lineSuffix(lineNo, legsFor(mode).party),
          AC_CODE: l.partyAc,
          LD_CODE: payAcLinesResolved,
          DR_AMT: amt,
          CR_AMT: 0,
          SIGN: 'D',
        },
        {
          ...lbase,
          legKeySuffix: lineSuffix(lineNo, legsFor(mode).account),
          AC_CODE: payAcLinesResolved,
          LD_CODE: l.partyAc,
          DR_AMT: 0,
          CR_AMT: amt,
          SIGN: 'C',
        },
      );
      if (lineKasar > 0) {
        const kasarAc = payKasarAc;
        ledger.push(
          {
            ...lbase,
            legKeySuffix: lineSuffix(lineNo, CASH_LEG.payKasarParty),
            AC_CODE: l.partyAc,
            LD_CODE: kasarAc,
            DR_AMT: lineKasar,
            CR_AMT: 0,
            SIGN: 'D',
          },
          {
            ...lbase,
            legKeySuffix: lineSuffix(lineNo, CASH_LEG.payKasar),
            AC_CODE: kasarAc,
            LD_CODE: l.partyAc,
            DR_AMT: 0,
            CR_AMT: lineKasar,
            SIGN: 'C',
          },
        );
      }
    });
    assertBalanced(ledger);

    // ONE ROJMEL ROW PER LINE. This path wrote NONE at all - postPaymentLines never called the builder - so the
    // day book showed nothing for a multi-line cash payment. Real voucher 002/00029 has nine lines and nine
    // type-04 Rojmel rows keyed `...0002904` + 1 through 9; the web produced zero.
    const linesRojmelRows = lines.flatMap((l, idx) =>
      buildCashRojmel(
        {
          scope: {
            coCode: input.scope.coCode,
            lcCode: input.scope.lcCode,
            coYear: input.scope.coYear!,
          },
          key,
          coBook: input.scope.coBook!,
          vchNo: String(vchNo).padStart(5, '0'),
          vchDate: vchDate ?? null,
          bookName: mode === 'cash' ? 'CASH PAY' : 'BANK PAY',
          vchType,
          partyCode: l.partyAc,
          partyName: '',
        },
        {
          cashAc: payAcLinesResolved,
          cashAmount: round2(Number(l.amount)),
          direction: 'payment',
          kasar: round2(Number(l.kasar ?? 0)),
          // Blank when nothing is written off; buildCashRojmel needs both amount and account.
          kasarAc: payKasarAc,
          lineNo: idx + 1,
        },
      ),
    );
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: mode === 'cash' ? 'CASH PAY' : 'BANK PAY',
      writes: [
        ...(linesRojmelRows.length
          ? [{ table: 'ROJ_MEL_DATA' as const, rows: linesRojmelRows }]
          : []),
        {
          table: 'PAY_DATA',
          rows: [
            {
              ...key,
              VCH_TYPE: vchType,
              NET_AMT: totalAmt,
              TOT_AMT: round2(totalAmt + totalKasar),
              KASAR_AMT: totalKasar,
              AC_CODE: lines[0]!.partyAc,
              BANK_AC: mode === 'cash' ? null : payAcLinesResolved,
              CASH_AMT: mode === 'cash' ? totalAmt : 0,
              CHQ_NO: input.chqNo ?? null,
              EMP_CODE: input.empCode ?? null,
              VCH_DATE: vchDate,
            },
          ],
        },
        {
          table: 'PAY_DETL',
          rows: detlLines(key, vchType, mode === 'cash' ? 'CASH PAY' : 'BANK PAY', vchDate, lines),
        },
      ],
    });
    return { vchNo, total: totalAmt };
  });
}

export async function deleteReceiptLines(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), 'RCT');
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['CASH_DATA', 'PAY_DETL', 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'CREC', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}
export async function deletePaymentLines(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), 'PAY');
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['PAY_DATA', 'PAY_DETL', 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'CPAY', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}

export interface DeleteFinanceInput {
  scope: VoucherScope;
  vchNo: number | string;
  headerTable: 'CASH_DATA' | 'PAY_DATA' | 'CONTRA_DATA';
  book: string; // CO_BOOK used at creation (RCT/PAY/CON)
  vchType: string;
  deleteUser?: string;
}

/** Delete/reverse a finance voucher: remove header + AC_DATA, write DELETE_DATA (Req 13.4). */
export async function deleteFinance(
  prisma: any,
  input: DeleteFinanceInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: [input.headerTable, 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: input.vchType, DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}

const RECEIPT_WRITE_TABLES = [
  'CASH_DATA',
  'CARD_DATA',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
] as const;

export async function getReceipt(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME",
              "REC_AMT","KASAR_AMT","REC_AC_CODE","CHQ_NO","IT_DESC","BOOK_NAME"
         FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (rows.length !== 1)
      throw new FinanceValidationError(
        rows.length
          ? `receipt voucher is ambiguous: ${voucherNo}`
          : `receipt voucher not found: ${voucherNo}`,
      );
    const card: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "CARD_COM_PRC","BANK_NAME" FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const upi: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "UPI_ID","UPI_AC_NAME" FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const h = rows[0]!;
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      partyAc: text(h.AC_CODE),
      partyName: text(h.AC_NAME),
      amount: numv(h.REC_AMT),
      kasar: numv(h.KASAR_AMT),
      bankAc: text(h.REC_AC_CODE),
      chqNo: text(h.CHQ_NO),
      mode: card.length
        ? 'card'
        : upi.length
          ? 'upi'
          : text(h.REC_AC_CODE) === 'CASH'
            ? 'cash'
            : 'bank',
      cardCommissionPct: numv(card[0]?.CARD_COM_PRC),
      bankName: text(card[0]?.BANK_NAME ?? upi[0]?.UPI_AC_NAME),
      upiId: text(upi[0]?.UPI_ID),
      description: text(h.IT_DESC),
    };
  });
}

export async function editReceipt(
  prisma: any,
  input: ReceiptInput,
  requestedVoucherNo: number | string,
): Promise<FinanceResult> {
  completeFinanceScope(input.scope);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CASH_DATA',
      scope: input.scope,
      requestedVoucherNo,
      requestedDate,
    });
    await replaceWriteSetTx(
      tx,
      input.scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      RECEIPT_WRITE_TABLES,
    );
    return postReceipt(prisma, input, { tx, identity });
  });
}

export async function deleteReceipt(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
): Promise<{ reversed: true }> {
  completeFinanceScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const { persisted: header, identity } = await editIdentityTx(tx, {
      table: 'CASH_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      extraColumns: ['AC_CODE', 'AC_NAME', 'REC_AMT', 'INOUT_TYPE', 'IT_DESC'],
    });
    const book = await configuredBookTx(tx, scope);
    const card: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "CARD_AMT","IT_DESC" FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
       AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: [...RECEIPT_WRITE_TABLES],
      key: voucherKey(scope, voucherNo),
    });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      identity.hiddenVoucherNo,
    );
    const source = card[0];
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: book,
      header,
      rows: [
        {
          srNo: 1,
          valueDr: source ? 0 : text(header.INOUT_TYPE) === 'O' ? numv(header.REC_AMT) : 0,
          valueCr: source
            ? numv(source.CARD_AMT)
            : text(header.INOUT_TYPE) === 'I'
              ? numv(header.REC_AMT)
              : 0,
          fineType: 'A',
          description: text(source?.IT_DESC ?? header.IT_DESC),
        },
      ],
      deleteUser: input.deleteUser,
    });
    return { reversed: true };
  });
}

/** Read a saved payment — plan item F2.1. (detail condensed; see git history / plan doc 06.) */
export async function getPayment(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME",
              "NET_AMT","TOT_AMT","KASAR_AMT","BANK_AC","CASH_AMT","CHQ_AMT","CARD_AMT","CHQ_NO",
              "VCH_DESC","BOOK_NAME"
         FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    // Throw rather than return a blank record: an empty shape reads as "this voucher has no lines", which is
    // the same trap as an empty query result read as a finding. Every sibling reader here does the same.
    if (!rows.length) throw new FinanceValidationError(`payment voucher not found: ${voucherNo}`);
    const h = rows[0]!;
    const mode = numv(h.CHQ_AMT)
      ? 'cheque'
      : numv(h.CARD_AMT)
        ? 'card'
        : numv(h.CASH_AMT) || !text(h.BANK_AC)
          ? 'cash'
          : 'bank';
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      partyAc: text(h.AC_CODE),
      partyName: text(h.AC_NAME),
      amount: numv(h.NET_AMT) || numv(h.TOT_AMT),
      kasar: numv(h.KASAR_AMT),
      bankAc: text(h.BANK_AC),
      chqNo: text(h.CHQ_NO),
      mode,
      // PAY_DATA's narration column is VCH_DESC; CASH_DATA's is IT_DESC.
      description: text(h.VCH_DESC),
      bookName: text(h.BOOK_NAME),
    };
  });
}

// Contra Entry lives in contra.ts (the desktop TR_CONTRA grid); re-exported for existing callers.
export { postContra, getContra, editContra, deleteContra, type ContraInput } from './contra.js';
