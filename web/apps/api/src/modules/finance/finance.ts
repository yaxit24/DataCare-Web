import { withTenant } from '@datacare/db';
import { DEFAULT_CASH_LIMIT, resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { buildCashRojmel } from '../shared/rojmel.js';
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
 * Desktop leg codes for the cash books, measured across all 522 legs of books 001 and 002.
 *
 * DIRECTION-SPECIFIC: a receipt and a payment share NO codes, and the same role takes a different number
 * depending on which way the money moves.
 *
 *   book 001 CASH REC   01 party Cr / 02 cash  Dr        03 party Cr / 04 kasar Dr   (kasar 00057 JAVK)
 *   book 002 CASH PAY   05 party Dr / 06 cash  Cr        07 party Dr / 08 kasar Cr   (kasar 00042 AVAK)
 *
 * The kasar ACCOUNT differs too - 00057 KASAR JAVK on a receipt, 00042 KASAR AVAK on a payment. Gujarati
 * javak is outgoing and avak incoming, so it mirrors the money rather than the voucher. One account for both
 * would post half the discounts to the wrong ledger.
 *
 * Bank books are NOT covered here. They have the same MAIN_BOOK shape but their codes must be measured, not
 * assumed - the cash codes already differ by direction, so assuming they carry across would be the same error
 * one level up.
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

/** The cash/bank ledger code for a payment mode (cash→CASH; everything else routes to bank/clearing). */
export function settlementAc(mode: PayMode, bankAc?: string): string {
  return mode === 'cash' ? 'CASH' : (bankAc ?? 'BANK');
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

  const recAc = settlementAc(mode, input.bankAc);
  completeFinanceScope(input.scope);
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const write = async (tx: any, identity: VoucherIdentity): Promise<FinanceResult> => {
    // Cash-receipt ceiling (desktop TR_CASH): block when this + the party's prior cash exceeds the
    // CO_SET.CASH_LIMIT — no PAN escape (R7). Non-cash modes are exempt.
    if (mode === 'cash') {
      const limit = await cashLimitTx(tx, tenantId, input.scope.coCode);
      const prior = await partyCashReceivedTx(tx, input.scope, input.partyAc, recAc);
      assertCashReceiptCeiling(input.amount, prior, limit, input.partyName);
    }
    // The cash/bank account comes from BOOK_DETL slot 1 when the caller names no bank.
    //
    // `settlementAc` returns the literal 'CASH', which is a placeholder rather than an account: the real leg-02
    // rows on book 001 all name 00001, which is that book's slot 1. The same defect was found in the scheme
    // family, so the placeholder is systemic across the finance paths rather than local to one.
    //
    // An explicit bankAc still wins, and the literal stays as a last resort so a book without the slot behaves
    // as before rather than failing.
    const slot = (await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
          AND coalesce("SR_NO",0)::numeric=1
        LIMIT 1`,
      tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      input.scope.coBook,
    )) as Array<{ AC_CODE: unknown }>;
    const recAcResolved =
      (input.bankAc ?? '').trim() || String(slot[0]?.AC_CODE ?? '').trim() || recAc;

    const vchNo = identity.vchNo;
    const key = keyOf(input.scope, vchNo, 'RCT');
    const configuredBook = await configuredBookTx(tx, input.scope);
    const vchType = mode === 'cash' ? 'CREC' : 'BREC';
    const kasar = round2(Number(input.kasar ?? 0));
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
      const kasarAc = input.kasarAc ?? 'KASAR';
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
    // The Rojmel. The cash books name the cash account but take their DEBIT/CREDIT from the PARTY's
    // leg - verified at 100% within each row type on the real data (book 001 type 01, 56 rows; book
    // 002 type 04, 175 rows). partyLegAmount is therefore the party's ledger figure, which includes
    // any kasar written off, not the cash actually tendered.
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
      partyLegAmount: round2(input.amount + kasar),
      direction: 'receipt',
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
            BANK_ACCD: recAc,
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
            UPI_AC_CODE: recAc,
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
  return withTenant(prisma, tenantId, async (tx: any) =>
    write(tx, await createIdentityTx(tx, input.scope, vchDate, input.mainUser)),
  );
}

export interface PaymentInput {
  scope: VoucherScope;
  partyAc: string; // who we pay
  partyName?: string;
  amount: number;
  mode: PayMode;
  bankAc?: string;
  chqNo?: string;
  vchDate?: Date | string;
  kasar?: number; // discount received / round-off (Cr KASAR), clears amount+kasar on the party
  kasarAc?: string; // default 'KASAR'
}

/** Payment (money OUT): Dr party, Cr cash/bank. Header → PAY_DATA. */
export async function postPayment(prisma: any, input: PaymentInput): Promise<FinanceResult> {
  if (!input.partyAc) throw new FinanceValidationError('party account is required');
  if (!(input.amount > 0)) throw new FinanceValidationError('amount must be positive');
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;

  const payAc = settlementAc(mode, input.bankAc);
  const tenantId = input.scope.tenantId;
  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, 'PAY');
    const vchType = mode === 'cash' ? 'CPAY' : 'BPAY';
    const kasar = round2(Number(input.kasar ?? 0));
    const lbase = { ...key, VCH_TYPE: vchType };
    const ledger: LedgerLine[] = [
      {
        ...lbase,
        AC_CODE: input.partyAc,
        DR_AMT: round2(input.amount + kasar),
        CR_AMT: 0,
        SIGN: 'D',
      },
    ];
    ledger.push({ ...lbase, AC_CODE: payAc, DR_AMT: 0, CR_AMT: input.amount, SIGN: 'C' });
    if (kasar > 0)
      ledger.push({
        ...lbase,
        AC_CODE: input.kasarAc ?? 'KASAR',
        DR_AMT: 0,
        CR_AMT: kasar,
        SIGN: 'C',
      }); // discount received
    assertBalanced(ledger);
    // The Rojmel. The cash books name the cash account but take their DEBIT/CREDIT from the PARTY's
    // leg - verified at 100% within each row type on the real data (book 001 type 01, 56 rows; book
    // 002 type 04, 175 rows). partyLegAmount is therefore the party's ledger figure, which includes
    // any kasar written off, not the cash actually tendered.
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
      cashAc: payAc,
      partyLegAmount: round2(input.amount + kasar),
      direction: 'payment',
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
              BANK_AC: mode === 'cash' ? null : payAc,
              CASH_AMT: mode === 'cash' ? input.amount : 0,
              CHQ_AMT: mode === 'cheque' ? input.amount : 0,
              CARD_AMT: mode === 'card' ? input.amount : 0,
              CHQ_NO: input.chqNo ?? null,
              VCH_DATE: input.vchDate ? new Date(input.vchDate) : new Date(),
            },
          ],
        },
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return { vchNo };
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
  const recAc = settlementAc(mode, input.bankAc);
  const tenantId = input.scope.tenantId;
  const totalAmt = round2(lines.reduce((s, l) => s + Number(l.amount), 0));
  const totalKasar = round2(lines.reduce((s, l) => s + Number(l.kasar ?? 0), 0));
  return withTenant(prisma, tenantId, async (tx: any) => {
    if (mode === 'cash') {
      const limit = await cashLimitTx(tx, tenantId, input.scope.coCode);
      for (const line of lines) {
        const prior = await partyCashReceivedTx(tx, input.scope, line.partyAc, recAc);
        assertCashReceiptCeiling(Number(line.amount), prior, limit, line.partyName);
      }
    }
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, 'RCT');
    const vchType = mode === 'cash' ? 'CREC' : 'BREC';
    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const lbase = { ...key, VCH_TYPE: vchType };
    const ledger: LedgerLine[] = [
      {
        ...lbase,
        AC_CODE: recAc,
        LD_CODE: lines[0]!.partyAc,
        DR_AMT: totalAmt,
        CR_AMT: 0,
        SIGN: 'D',
      },
    ];
    if (totalKasar > 0)
      ledger.push({
        ...lbase,
        AC_CODE: input.kasarAc ?? 'KASAR',
        DR_AMT: totalKasar,
        CR_AMT: 0,
        SIGN: 'D',
      });
    for (const l of lines)
      ledger.push({
        ...lbase,
        AC_CODE: l.partyAc,
        LD_CODE: recAc,
        DR_AMT: 0,
        CR_AMT: round2(Number(l.amount) + Number(l.kasar ?? 0)),
        SIGN: 'C',
      });
    assertBalanced(ledger);
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: mode === 'cash' ? 'CASH REC' : 'BANK REC',
      writes: [
        {
          table: 'CASH_DATA',
          rows: [
            {
              ...key,
              VCH_TYPE: vchType,
              REC_AMT: totalAmt,
              KASAR_AMT: totalKasar,
              AC_CODE: lines[0]!.partyAc,
              REC_AC_CODE: recAc,
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
  const payAc = settlementAc(mode, input.bankAc);
  const tenantId = input.scope.tenantId;
  const totalAmt = round2(lines.reduce((s, l) => s + Number(l.amount), 0));
  const totalKasar = round2(lines.reduce((s, l) => s + Number(l.kasar ?? 0), 0));
  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, vchNo, 'PAY');
    const vchType = mode === 'cash' ? 'CPAY' : 'BPAY';
    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const lbase = { ...key, VCH_TYPE: vchType };
    const ledger: LedgerLine[] = [];
    for (const l of lines)
      ledger.push({
        ...lbase,
        AC_CODE: l.partyAc,
        DR_AMT: round2(Number(l.amount) + Number(l.kasar ?? 0)),
        CR_AMT: 0,
        SIGN: 'D',
      });
    ledger.push({ ...lbase, AC_CODE: payAc, DR_AMT: 0, CR_AMT: totalAmt, SIGN: 'C' });
    if (totalKasar > 0)
      ledger.push({
        ...lbase,
        AC_CODE: input.kasarAc ?? 'KASAR',
        DR_AMT: 0,
        CR_AMT: totalKasar,
        SIGN: 'C',
      });
    assertBalanced(ledger);
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
              NET_AMT: totalAmt,
              TOT_AMT: round2(totalAmt + totalKasar),
              KASAR_AMT: totalKasar,
              AC_CODE: lines[0]!.partyAc,
              BANK_AC: mode === 'cash' ? null : payAc,
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
  return withTenant(prisma, tenantId, async (tx: any) => {
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
  return withTenant(prisma, tenantId, async (tx: any) => {
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

export interface ContraInput {
  /** Item type selector (TR_CONTRA.cs:2786 cboItemTyp first character); 'A' = amount. */
  itemType?: string;
  /** Desktop CONTRA_DATA columns (TR_CONTRA.cs:2783,2803): counter-account name, employee. */
  toAcName?: string;
  empCode?: string;
  scope: VoucherScope;
  fromAc: string; // money leaves here
  toAc: string; // money arrives here
  amount: number;
  vchDate?: Date | string;
  itDesc?: string; // narration (CONTRA_DATA.IT_DESC)
  mainUser?: string;
}

/** Contra (bank↔cash transfer): Dr toAc, Cr fromAc. Header → CONTRA_DATA. */
export async function postContra(
  prisma: any,
  input: ContraInput,
  lifecycle?: FinanceWriteContext,
): Promise<FinanceResult> {
  if (!input.fromAc || !input.toAc)
    throw new FinanceValidationError('both fromAc and toAc are required');
  if (input.fromAc === input.toAc) throw new FinanceValidationError('fromAc and toAc must differ');
  if (!(input.amount > 0)) throw new FinanceValidationError('amount must be positive');

  completeFinanceScope(input.scope);
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const write = async (tx: any, identity: VoucherIdentity): Promise<FinanceResult> => {
    const vchNo = identity.vchNo;
    const key = keyOf(input.scope, vchNo, 'CON');
    const book = await configuredBookTx(tx, input.scope);
    const ledger = buildTransferLedger(key, book.shortName, input.toAc, input.fromAc, input.amount);
    for (const line of ledger) line.VCH_DATE = vchDate;
    assertBalanced(ledger);
    await insertHiddenIdentityTx(tx, input.scope, identity, book.name);
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: book.name,
      writes: [
        {
          table: 'CONTRA_DATA',
          rows: [
            {
              ...key,
              VCH_TYPE: book.shortName,
              SR_NO: 1,
              AC_CODE: input.toAc,
              LD_CODE: input.fromAc,
              DR_AMT: input.amount,
              CR_AMT: input.amount,
              CRDR_TYPE: 'D',
              IT_DESC: input.itDesc ?? null,
              // Desktop CONTRA_DATA columns (TR_CONTRA.cs:2783,2803,2805): the counter-account name
              // from the grid, the employee and the DATA_TRFR literal.
              AC_NAME: input.toAcName ?? null,
              EMP_CODE: input.empCode ?? null,
              DATA_TRFR: 'N',
              // TR_CONTRA.cs:2786-2788 — a money transfer carries no metal, so the fine columns are
              // the desktop's zeros and IT_TYPE the item-type selector's first character.
              DR_FINE: 0,
              CR_FINE: 0,
              IT_TYPE: input.itemType ?? 'A',
              VCH_DATE: vchDate,
              VCH_TIME: identity.voucherTime,
              HD_VCH_NO: identity.hiddenVoucherNo,
              MAIN_USER: identity.mainUser || null,
              BOOK_NAME: book.name,
              INOUT_TYPE: 'I',
              ENTRY_TYPE: 'J',
              LDR_TYPE: '1',
            },
          ],
        },
      ],
    });
    return { vchNo };
  };
  if (lifecycle) return write(lifecycle.tx, lifecycle.identity);
  return withTenant(prisma, tenantId, async (tx: any) =>
    write(tx, await createIdentityTx(tx, input.scope, vchDate, input.mainUser)),
  );
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
  return withTenant(prisma, tenantId, async (tx: any) => {
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

const RECEIPT_WRITE_TABLES = ['CASH_DATA', 'CARD_DATA', 'UPI_DATA', 'AC_DATA'] as const;

export async function getReceipt(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
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
  return withTenant(prisma, input.scope.tenantId, async (tx: any) => {
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
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
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

const CONTRA_WRITE_TABLES = ['CONTRA_DATA', 'AC_DATA'] as const;

export async function getContra(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
) {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","AC_CODE","LD_CODE","DR_AMT","CR_AMT","IT_DESC"
       FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length) throw new FinanceValidationError(`contra voucher not found: ${voucherNo}`);
    const h = rows[0]!;
    return {
      voucherNo,
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      toAc: text(h.AC_CODE),
      fromAc: text(h.LD_CODE),
      amount: numv(h.DR_AMT) || numv(h.CR_AMT),
      itDesc: text(h.IT_DESC),
    };
  });
}

export async function editContra(
  prisma: any,
  input: ContraInput,
  requestedVoucherNo: number | string,
) {
  completeFinanceScope(input.scope);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, input.scope.tenantId, async (tx: any) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope: input.scope,
      requestedVoucherNo,
      requestedDate,
    });
    await replaceWriteSetTx(
      tx,
      input.scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      CONTRA_WRITE_TABLES,
    );
    return postContra(prisma, input, { tx, identity });
  });
}

export async function deleteContra(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
) {
  completeFinanceScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const { persisted: header, identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      extraColumns: [
        'AC_CODE',
        'AC_NAME',
        'DR_AMT',
        'CR_AMT',
        'DR_FINE',
        'CR_FINE',
        'IT_TYPE',
        'IT_DESC',
        'SR_NO',
      ],
    });
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","DR_AMT","CR_AMT","DR_FINE","CR_FINE","IT_TYPE","IT_DESC" FROM "CONTRA_DATA"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const book = await configuredBookTx(tx, scope);
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: [...CONTRA_WRITE_TABLES],
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
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: book,
      header,
      rows: details.map((r) => ({
        srNo: numv(r.SR_NO),
        valueDr: numv(r.DR_AMT),
        valueCr: numv(r.CR_AMT),
        fineType: text(r.IT_TYPE) || 'A',
        fineDr: numv(r.DR_FINE),
        fineCr: numv(r.CR_FINE),
        description: text(r.IT_DESC),
      })),
      deleteUser: input.deleteUser,
    });
    return { reversed: true as const };
  });
}
