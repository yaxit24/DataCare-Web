import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertBalanced,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  completeFinanceScope,
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  num,
  voucherKey,
  type VoucherIdentity,
} from './lifecycle.js';
import { resolveBookAccountTx, type BookPolicy } from '../shared/bookPolicy.js';

/**
 * Card Receipt / CARD ADJUST (desktop TR_CARD_REC.cs). A customer card settlement: the party is
 * credited the gross card charge (CARD_AMT + card commission), the card commission is debited back
 * out of the party and credited to the book's commission account (BOOK_DETL slot 1), the acquiring
 * bank account is debited the gross and credited the bank commission (same slot-1 account), and any
 * CASH_PAID is debited to the party and credited to the book's cash/control account (slot 2).
 *
 * Exact 8-leg ledger (Ac_Ledr.cs:1790-1804), each conditional:
 *   01 Cr party   R        (R = CARD_AMT + CARD_COM_AMT)         if CARD_AMT != 0
 *   02 Dr party   C        (C = card commission)                if C != 0
 *   03 Cr slot1   C                                             if C != 0
 *   04 Dr bank    R                                             if CARD_AMT != 0
 *   05 Cr bank    B        (B = BANK_COMM_1 + BANK_COMM_2)       if B != 0
 *   06 Dr slot1   B                                             if B != 0
 *   07 Dr party   H        (H = CASH_PAID)                      if H != 0
 *   08 Cr slot2   H                                             if H != 0
 * Net: party Cr (A - H), bank Dr (R - B), slot1 Cr(C)-Dr(B), slot2 Cr(H). Balanced by construction.
 *
 * Also writes CARD_DATA (header, 38 columns) and a 4-row ROJ_MEL_DATA cash-book projection
 * (Ac_Rojmel.cs:843-849). Book workflow MAIN_BOOK 'CARD ADJUST', inward. No CASH_DATA / tax / stock.
 * Spec: docs lineage G132 / TR_CARD_REC.cs:3271-3339.
 */
export class CardReceiptValidationError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'CardReceiptValidationError';
  }
}

export interface CardReceiptInput {
  scope: VoucherScope;
  partyAc: string;
  partyName?: string;
  bankAc: string;
  bankName?: string;
  cardAmt: number;
  cardComPrc?: number;
  cardComAmt?: number; // explicit override (desktop persists the control verbatim)
  bankComPrc?: number;
  bankSchPrc?: number;
  bankComm1?: number; // explicit override
  bankComm2?: number; // explicit override
  cashPaid?: number;
  empCode?: string;
  desc?: string;
  billNo?: string;
  billYrCd?: string;
  billDbCd?: string;
  billAmt?: number;
  vchDate?: Date | string;
  mainUser?: string;
}

export interface CardReceiptResult {
  vchNo: number;
  totals: { cardRec: number; bankCom: number; bankNet: number; partyNet: number };
}

const T = ['CARD_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'DHRN_REC_DETL'] as const;
const r2 = (n: number) => Math.round((n + Number.EPSILON) * 100) / 100;
/** Desktop card commission is rounded to a WHOLE currency unit (one-arg Math.Round, TR_CARD_REC.cs:3796). */
const r0 = (n: number) => Math.round(n + Number.EPSILON);

/** The CARD ADJUST book policy used to resolve the commission (slot 1) and cash (slot 2) accounts. */
function cardPolicy(scope: VoucherScope, book: { shortName: string; name: string }): BookPolicy {
  return {
    coBook: scope.coBook ?? '',
    vchType: book.shortName,
    bookName: book.name,
    mainBook: 'CARD ADJUST',
    inout: 'I',
  };
}

/** Pure amount derivation mirroring BILL_TOTAL (TR_CARD_REC.cs:3792-3844). Explicit overrides win. */
export function cardReceiptCalc(i: CardReceiptInput): {
  cardAmt: number;
  cardCom: number;
  cardRec: number;
  bankComm1: number;
  bankComm2: number;
  bankCom: number;
  bankNet: number;
  cashPaid: number;
} {
  const cardAmt = r2(num(i.cardAmt));
  const cashPaid = r2(num(i.cashPaid));
  const cardComPrc = num(i.cardComPrc);
  // card commission: % of CARD_AMT rounded to a whole unit; explicit override used when % is zero.
  const cardCom =
    i.cardComAmt != null && cardComPrc === 0
      ? r2(num(i.cardComAmt))
      : cardComPrc !== 0
        ? r2(r0((cardAmt * cardComPrc) / 100))
        : r2(num(i.cardComAmt));
  const cardRec = r2(cardAmt + cardCom);
  const bankComPrc = num(i.bankComPrc);
  const bankSchPrc = num(i.bankSchPrc);
  // bank commission 1: base is CARD_AMT when cash is paid, else the gross CARD_REC_AMT.
  const bankComm1 =
    bankComPrc !== 0
      ? r2(((cashPaid !== 0 ? cardAmt : cardRec) * bankComPrc) / 100)
      : r2(num(i.bankComm1));
  const bankComm2 =
    bankComPrc !== 0
      ? bankComm1 !== 0 && bankSchPrc !== 0
        ? r2((bankComm1 * bankSchPrc) / 100)
        : 0
      : r2(num(i.bankComm2));
  const bankCom = r2(bankComm1 + bankComm2);
  const bankNet = r2(cardRec - bankCom);
  return { cardAmt, cardCom, cardRec, bankComm1, bankComm2, bankCom, bankNet, cashPaid };
}

export function assertCardReceiptInput(i: CardReceiptInput): void {
  if (!text(i.partyAc)) throw new CardReceiptValidationError('party account is required');
  if (!text(i.bankAc)) throw new CardReceiptValidationError('card bank account is required');
  const c = cardReceiptCalc(i);
  if (!(c.cardAmt > 0)) throw new CardReceiptValidationError('card amount must be positive');
  if (c.cashPaid < 0) throw new CardReceiptValidationError('cash paid cannot be negative');
  if (c.cashPaid > c.cardAmt)
    throw new CardReceiptValidationError('cash paid cannot exceed the card amount');
}

async function write(
  tx: any,
  i: CardReceiptInput,
  id: VoucherIdentity,
): Promise<CardReceiptResult> {
  completeFinanceScope(i.scope);
  const b = await configuredBookTx(tx, i.scope);
  const k = voucherKey(i.scope, id.voucherNo);
  const party = text(i.partyAc);
  const bank = text(i.bankAc);
  const c = cardReceiptCalc(i);
  const policy = cardPolicy(i.scope, b);
  // slot 1 (commission/charges) needed whenever there is card or bank commission; slot 2 (cash) only on cashback.
  const slot1 =
    c.cardCom !== 0 || c.bankCom !== 0 ? await resolveBookAccountTx(tx, i.scope, policy, 1) : '';
  const slot2 = c.cashPaid !== 0 ? await resolveBookAccountTx(tx, i.scope, policy, 2) : '';
  const desc = text(i.desc);
  const base = {
    ...k,
    VCH_TYPE: b.shortName,
    VCH_DATE: id.voucherDate,
    BOOK_NAME: b.name,
    IT_TYPE: 'A',
    SIGN: '',
    IT_DESC: '',
  };
  // The 8 conditional legs. legType sets the 2-char LEDR_KEY suffix (01..08); LD_CODE + PARTY_AC_CODE
  // are stamped verbatim to match the desktop Ac_Ledr projection exactly.
  const ledger: LedgerLine[] = [];
  if (c.cardAmt !== 0)
    ledger.push({
      ...base,
      legType: 1,
      AC_CODE: party,
      LD_CODE: bank,
      DR_AMT: 0,
      CR_AMT: c.cardRec,
      PARTY_AC_CODE: party,
    });
  if (c.cardCom !== 0) {
    ledger.push({
      ...base,
      legType: 2,
      AC_CODE: party,
      LD_CODE: slot1,
      DR_AMT: c.cardCom,
      CR_AMT: 0,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 3,
      AC_CODE: slot1,
      LD_CODE: party,
      DR_AMT: 0,
      CR_AMT: c.cardCom,
      PARTY_AC_CODE: '',
    });
  }
  if (c.cardAmt !== 0)
    ledger.push({
      ...base,
      legType: 4,
      AC_CODE: bank,
      LD_CODE: party,
      DR_AMT: c.cardRec,
      CR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  if (c.bankCom !== 0) {
    ledger.push({
      ...base,
      legType: 5,
      AC_CODE: bank,
      LD_CODE: party,
      DR_AMT: 0,
      CR_AMT: c.bankCom,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 6,
      AC_CODE: slot1,
      LD_CODE: bank,
      DR_AMT: c.bankCom,
      CR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  }
  if (c.cashPaid !== 0) {
    ledger.push({
      ...base,
      legType: 7,
      AC_CODE: party,
      LD_CODE: slot2,
      DR_AMT: c.cashPaid,
      CR_AMT: 0,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 8,
      AC_CODE: slot2,
      LD_CODE: party,
      DR_AMT: 0,
      CR_AMT: c.cashPaid,
      PARTY_AC_CODE: '',
    });
  }
  assertBalanced(ledger);

  // ROJ_MEL_DATA cash-book projection (Ac_Rojmel.cs:843-849): 4 conditional rows.
  const acName = text(i.partyName);
  const rojBase = {
    ...k,
    VCH_DATE: id.voucherDate,
    VCH_TYPE: b.shortName,
    BOOK_NAME: b.name,
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
    IT_DESC: desc,
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
  };
  const roj: Record<string, unknown>[] = [];
  const rojKey = (n: number) =>
    `${k.CO_CODE}${k.LC_CODE}${k.CO_YEAR}${k.CO_BOOK}${String(k.VCH_NO).padStart(5, '0')}${String(n).padStart(2, '0')}`;
  if (c.cardRec !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(1),
      AC_CODE: party,
      LD_CODE: bank,
      CR_AMT: r2(c.cardAmt - c.cashPaid),
      DR_AMT: 0,
      AC_NAME: `CARD - ${acName}`,
    });
  if (c.cardCom !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(2),
      AC_CODE: party,
      LD_CODE: slot1,
      CR_AMT: c.cardCom,
      DR_AMT: 0,
      AC_NAME: `CARDCOM - ${acName}`,
    });
  if (c.cardRec !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(3),
      AC_CODE: bank,
      LD_CODE: party,
      CR_AMT: 0,
      DR_AMT: c.bankNet,
      AC_NAME: '',
    });
  if (c.bankCom !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(4),
      AC_CODE: bank,
      LD_CODE: party,
      CR_AMT: 0,
      DR_AMT: c.bankCom,
      AC_NAME: `BANKCOM - ${acName}`,
    });

  const header = {
    ...k,
    VCH_DATE: id.voucherDate,
    VCH_TYPE: b.shortName,
    INOUT_TYPE: b.inout ?? 'I',
    ENTRY_TYPE: 'I',
    BOOK_NAME: b.name,
    VCH_TIME: id.voucherTime,
    AC_CODE: party,
    AC_NAME: i.partyName ?? null,
    BILL_NO: text(i.billNo) || null,
    BILL_LC_CODE: i.scope.lcCode,
    BILL_YRCD: text(i.billYrCd) || null,
    BILL_DBCD: text(i.billDbCd) || null,
    BILL_AMT: r2(num(i.billAmt)),
    BILL_ADJ_AMT: 0,
    BILL_OS_AMT: 0,
    CARD_AMT: c.cardAmt,
    CARD_COM_PRC: num(i.cardComPrc),
    CARD_COM_AMT: c.cardCom,
    CARD_REC_AMT: c.cardRec,
    CASH_PAID: c.cashPaid,
    BANK_ACCD: bank,
    BANK_NAME: i.bankName ?? null,
    BANK_COM_PRC: num(i.bankComPrc),
    BANK_SCH_PRC: num(i.bankSchPrc),
    BANK_COMM_1: c.bankComm1,
    BANK_COMM_2: c.bankComm2,
    BANK_COM_AMT: c.bankCom,
    BANK_NET_AMT: c.bankNet,
    IT_DESC: desc,
    EMP_CODE: text(i.empCode) || null,
    DATA_TRFR: 'N',
    HD_VCH_NO: id.hiddenVoucherNo,
    MAIN_USER: id.mainUser || null,
  };

  await insertHiddenIdentityTx(tx, i.scope, id, b.name);
  await postVoucherTx(tx, i.scope.tenantId, {
    bookName: b.name,
    partyAc: party,
    ledger: { table: 'AC_DATA', lines: ledger },
    writes: [
      { table: 'CARD_DATA', rows: [header] },
      ...(roj.length ? [{ table: 'ROJ_MEL_DATA', rows: roj }] : []),
    ],
  });
  return {
    vchNo: id.vchNo,
    totals: {
      cardRec: c.cardRec,
      bankCom: c.bankCom,
      bankNet: c.bankNet,
      partyNet: r2(c.cardAmt - c.cashPaid),
    },
  };
}

const n = (v: unknown) => (v != null ? Number(v) : undefined);
/** Map a raw request body + scope into a CardReceiptInput (keeps the route file thin). */
export function cardReceiptInputFromBody(
  scope: VoucherScope,
  b: Record<string, any>,
): CardReceiptInput {
  return {
    scope,
    partyAc: b.partyAc,
    partyName: b.partyName,
    bankAc: b.bankAc,
    bankName: b.bankName,
    cardAmt: Number(b.cardAmt),
    cardComPrc: n(b.cardComPrc),
    cardComAmt: n(b.cardComAmt),
    bankComPrc: n(b.bankComPrc),
    bankSchPrc: n(b.bankSchPrc),
    bankComm1: n(b.bankComm1),
    bankComm2: n(b.bankComm2),
    cashPaid: n(b.cashPaid),
    empCode: b.empCode,
    desc: b.desc,
    billNo: b.billNo,
    billYrCd: b.billYrCd,
    billDbCd: b.billDbCd,
    billAmt: n(b.billAmt),
    vchDate: b.vchDate,
    mainUser: b.mainUser,
  };
}

export async function postCardReceipt(p: any, i: CardReceiptInput) {
  assertCardReceiptInput(i);
  completeFinanceScope(i.scope);
  const d = i.vchDate ? new Date(i.vchDate) : new Date();
  return withTxBudget(p, i.scope.tenantId, 'voucher', async (tx) =>
    write(tx, i, await createIdentityTx(tx, i.scope, d, i.mainUser)),
  );
}

export async function getCardReceipt(p: any, s: VoucherScope, x: number | string) {
  completeFinanceScope(s);
  const no = formatVoucherNo(x);
  return withTxBudget(p, s.tenantId, 'read', async (tx) => {
    const a: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME","BILL_NO","BILL_YRCD","BILL_DBCD","BILL_AMT",
              "CARD_AMT","CARD_COM_PRC","CARD_COM_AMT","CARD_REC_AMT","CASH_PAID","BANK_ACCD","BANK_NAME","BANK_COM_PRC","BANK_SCH_PRC",
              "BANK_COMM_1","BANK_COMM_2","BANK_COM_AMT","BANK_NET_AMT","EMP_CODE","IT_DESC"
         FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
      no,
    );
    if (a.length !== 1)
      throw new CardReceiptValidationError(`card-receipt voucher not found: ${no}`);
    const h = a[0]!;
    return {
      voucherNo: no,
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      partyAc: text(h.AC_CODE),
      partyName: text(h.AC_NAME),
      billNo: text(h.BILL_NO),
      billYrCd: text(h.BILL_YRCD),
      billDbCd: text(h.BILL_DBCD),
      billAmt: num(h.BILL_AMT),
      cardAmt: num(h.CARD_AMT),
      cardComPrc: num(h.CARD_COM_PRC),
      cardComAmt: num(h.CARD_COM_AMT),
      cardRecAmt: num(h.CARD_REC_AMT),
      cashPaid: num(h.CASH_PAID),
      bankAc: text(h.BANK_ACCD),
      bankName: text(h.BANK_NAME),
      bankComPrc: num(h.BANK_COM_PRC),
      bankSchPrc: num(h.BANK_SCH_PRC),
      bankComm1: num(h.BANK_COMM_1),
      bankComm2: num(h.BANK_COMM_2),
      bankComAmt: num(h.BANK_COM_AMT),
      bankNetAmt: num(h.BANK_NET_AMT),
      empCode: text(h.EMP_CODE),
      desc: text(h.IT_DESC),
    };
  });
}

export async function editCardReceipt(p: any, i: CardReceiptInput, x: number | string) {
  assertCardReceiptInput(i);
  completeFinanceScope(i.scope);
  const d = i.vchDate ? new Date(i.vchDate) : new Date();
  return withTxBudget(p, i.scope.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CARD_DATA',
      scope: i.scope,
      requestedVoucherNo: x,
      requestedDate: d,
    });
    await replaceWriteSetTx(tx, i.scope, identity.voucherNo, identity.hiddenVoucherNo, T);
    return write(tx, i, identity);
  });
}

export async function deleteCardReceipt(
  p: any,
  i: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
) {
  completeFinanceScope(i.scope);
  const s = i.scope;
  const no = formatVoucherNo(i.vchNo);
  return withTxBudget(p, s.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CARD_DATA',
      scope: s,
      requestedVoucherNo: no,
      requestedDate: new Date(),
    });
    // Desktop DELETE_DATA audit carries VCH_VAL_CR = CARD_AMT (TR_CARD_REC.cs:3398).
    const hdr: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE"::text,"VCH_TIME"::text,"AC_CODE","AC_NAME","CARD_AMT","IT_DESC" FROM "CARD_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
      no,
    );
    const h = hdr[0] ?? {};
    await reverseVoucherTx(tx, s.tenantId, {
      tables: [...T],
      key: voucherKey(s, no),
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...voucherKey(s, no),
          SR_NO: 1,
          VCH_DATE: h.VCH_DATE ?? null,
          VCH_TIME: h.VCH_TIME ?? null,
          AC_CODE: text(h.AC_CODE),
          AC_NAME: text(h.AC_NAME),
          HD_VCH_NO: identity.hiddenVoucherNo,
          VCH_VAL_DR: 0,
          VCH_VAL_CR: num(h.CARD_AMT),
          FINE_TYPE: 'A',
          VCH_FINE_DR: 0,
          VCH_FINE_CR: 0,
          DELETE_USER: i.deleteUser ?? 'system',
          VCH_DESC: text(h.IT_DESC).slice(0, 149),
          MAIN_USER: identity.mainUser || null,
        },
      },
    });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coBook,
      identity.hiddenVoucherNo,
    );
    return { reversed: true as const };
  });
}
