import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { resolveBookAccountTx, type BookPolicy } from '../shared/bookPolicy.js';
import {
  assertBalanced,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  voucherKey,
  type VoucherIdentity,
} from '../finance/lifecycle.js';
import { DhrnValidationError, round2, computeDhrnInterestTx } from './dhrn.js';

/** The configured book shape returned by configuredBookTx (shortName/name/mainBook/inout). */
type DhrnBook = Awaited<ReturnType<typeof configuredBookTx>>;

export interface DhrnInterestInput {
  scope: VoucherScope;
  isuNo: number | string; // the issue VCH_NO this interest collection is booked against
  isuBook?: string; // the issue's CO_BOOK (ISU_DBCD); defaults to the DHI issue book
  isuYear?: string; // the issue's CO_YEAR (ISU_YRCD); defaults to the current year
  borrowerAc: string;
  borrowerName?: string;
  loanType?: 'A' | 'G' | 'S'; // desktop LOAN_TYPE (cash/gold/silver); default 'A'
  interest?: number; // INT_AMT assessed; omit to auto-compute
  intReceived?: number; // INT_REC_AMT actually collected; defaults to the assessed interest
  intKasar?: number; // KASAR_AMT interest write-off (settles interest without cash)
  principalReceived?: number; // DHRN_REC_AMT regular principal collected this receipt
  unchakReceived?: number; // UNCHAK_DHRN_REC second principal component
  intPrc?: number;
  fromDate?: Date | string;
  toDate?: Date | string;
  intMonth?: number;
  intDay?: number;
  settlementAc?: string; // LEDR_ACCD cash/bank account receiving the money (default 'CASH')
  intIncAc?: string; // explicit interest-income override; default the book's BOOK_DETL slot 2
  kasarAc?: string; // interest write-off account (desktop literal 00057); default 'KASAR'
  empCode?: string;
  desc?: string;
  mainUser?: string;
  vchDate?: Date | string;
}

const DHRN_INT_TABLES = [
  'DHRN_REC_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'DHRN_DATA',
  'REMARK_DATA',
] as const;

/** Resolve the interest-income account from the interest book's BOOK_DETL slot 2 (desktop Ac_Ledr.cs:1156). */
async function dhrnIntIncomeAcTx(
  tx: any,
  scope: VoucherScope,
  book: DhrnBook,
  override?: string,
): Promise<string> {
  const trimmed = (override ?? '').trim();
  if (trimmed) return trimmed;
  const policy: BookPolicy = {
    coBook: scope.coBook ?? '',
    vchType: book.shortName || (scope.coBook ?? ''),
    bookName: book.mainBook || book.name,
    mainBook: book.mainBook || book.name,
    inout: (book.inout as string) || 'I',
  };
  return resolveBookAccountTx(tx, scope, policy, 2);
}

/** Resolve the cash/bank settlement default from the issue (DHI) book's BOOK_DETL slot 2 (desktop LEDR_ACCD cash default). */
async function resolveIssueCashAcTx(
  tx: any,
  scope: VoucherScope,
  issueBook: string,
): Promise<string> {
  const policy: BookPolicy = {
    coBook: issueBook,
    vchType: issueBook,
    bookName: 'DHIRAN ISSUE',
    mainBook: 'DHIRAN ISSUE',
    inout: 'O',
  };
  return resolveBookAccountTx(tx, { ...scope, coBook: issueBook }, policy, 2);
}

/**
 * Desktop-faithful DHRN interest receipt writer (TR_DHRN_INTREC). Collects interest (assessed I,
 * received R, written-off K) and optionally part/full principal (regular P + unchak U) against a
 * previously issued pledge. Amount-loan ('A') ledger (Ac_Ledr.cs:1152-1166), each pair conditional:
 *   01 Cr borrower Ptot / 02 Dr settlement Ptot    (principal received)   Ptot = P + U
 *   03 Dr borrower I     / 04 Cr interest-income I  (interest assessed)
 *   05 Cr borrower R     / 06 Dr settlement R       (interest collected)
 *   07 Cr borrower K     / 08 Dr kasar K            (interest written off)
 * Balance: ΣDr = Ptot + I + R + K = ΣCr. Also writes the full DHRN_REC_DATA header, a DHRN_DATA
 * movement (INT_REC_AMT = R + K), a ROJ_MEL_DATA projection and a REMARK_DATA row (when narrated).
 */
async function writeDhrnInterestTx(
  tx: any,
  input: DhrnInterestInput,
  identity: VoucherIdentity,
): Promise<{ vchNo: number; interest: number; received: number; principal: number }> {
  const scope = input.scope;
  const book = await configuredBookTx(tx, scope);
  const key = voucherKey(scope, identity.voucherNo);
  const party = String(input.borrowerAc);
  // Settlement (LEDR_ACCD): the operator-chosen cash/bank account. When omitted it defaults to the
  // issue book's cash slot (BOOK_DETL SR_NO 2 of the DHI issue book), literal-free like the dhrn writers.
  const issueCashAc = await resolveIssueCashAcTx(
    tx,
    scope,
    (input.isuBook ?? 'DHI').trim() || 'DHI',
  );
  const settlement = (input.settlementAc ?? '').trim() || issueCashAc;
  const intIncAc = await dhrnIntIncomeAcTx(tx, scope, book, input.intIncAc);
  const kasarAc = (input.kasarAc ?? '').trim() || 'KASAR';
  const loanType = (input.loanType ?? 'A') as 'A' | 'G' | 'S';

  const vchDate = identity.voucherDate;
  const assessed =
    input.interest != null && Number.isFinite(input.interest)
      ? round2(input.interest)
      : await computeDhrnInterestTx(tx, scope, input.isuNo, vchDate);
  const received = input.intReceived != null ? round2(input.intReceived) : assessed;
  const kasar = round2(input.intKasar ?? 0);
  const principal = round2(input.principalReceived ?? 0);
  const unchak = round2(input.unchakReceived ?? 0);
  const ptot = round2(principal + unchak);
  if (!(assessed > 0 || received > 0 || ptot > 0 || kasar > 0))
    throw new DhrnValidationError('nothing to collect (interest, principal or kasar must be > 0)');

  const isuBook = (input.isuBook ?? '').trim() || null;
  const isuYear = (input.isuYear ?? scope.coYear ?? '') || null;
  const base = {
    ...key,
    VCH_TYPE: book.shortName,
    VCH_DATE: vchDate,
    BOOK_NAME: book.mainBook || book.name,
    IT_TYPE: 'A',
    SIGN: '',
    IT_DESC: '',
  };
  // Amount-loan 8-leg ledger; legType sets the 2-char LEDR_KEY suffix (01..08).
  const ledger: LedgerLine[] = [];
  if (ptot !== 0) {
    ledger.push({
      ...base,
      legType: 1,
      AC_CODE: party,
      LD_CODE: settlement,
      DR_AMT: 0,
      CR_AMT: ptot,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 2,
      AC_CODE: settlement,
      LD_CODE: party,
      DR_AMT: ptot,
      CR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  }
  if (assessed !== 0) {
    ledger.push({
      ...base,
      legType: 3,
      AC_CODE: party,
      LD_CODE: intIncAc,
      DR_AMT: assessed,
      CR_AMT: 0,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 4,
      AC_CODE: intIncAc,
      LD_CODE: party,
      DR_AMT: 0,
      CR_AMT: assessed,
      PARTY_AC_CODE: '',
    });
  }
  if (received !== 0) {
    ledger.push({
      ...base,
      legType: 5,
      AC_CODE: party,
      LD_CODE: settlement,
      DR_AMT: 0,
      CR_AMT: received,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 6,
      AC_CODE: settlement,
      LD_CODE: party,
      DR_AMT: received,
      CR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  }
  if (kasar !== 0) {
    ledger.push({
      ...base,
      legType: 7,
      AC_CODE: party,
      LD_CODE: kasarAc,
      DR_AMT: 0,
      CR_AMT: kasar,
      PARTY_AC_CODE: party,
    });
    ledger.push({
      ...base,
      legType: 8,
      AC_CODE: kasarAc,
      LD_CODE: party,
      DR_AMT: kasar,
      CR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  }
  assertBalanced(ledger);

  const isuNoStr = formatVoucherNo(input.isuNo);
  const recHeader = {
    ...key,
    VCH_DATE: vchDate,
    VCH_TIME: identity.voucherTime,
    VCH_TYPE: book.shortName,
    INOUT_TYPE: book.inout ?? 'I',
    ENTRY_TYPE: 'D',
    BOOK_NAME: book.mainBook || book.name,
    AC_CODE: party,
    AC_NAME: input.borrowerName ?? null,
    LEDR_ACCD: settlement,
    ISU_NO: isuNoStr,
    ISU_LC: scope.lcCode,
    ISU_YRCD: isuYear,
    ISU_DBCD: isuBook,
    LOAN_TYPE: loanType,
    DHRN_REC_AMT: principal,
    UNCHAK_DHRN_REC: unchak,
    FROM_DATE: input.fromDate ? new Date(input.fromDate) : null,
    TO_DATE: input.toDate ? new Date(input.toDate) : null,
    INT_MONTH: input.intMonth ?? 0,
    INT_DAY: input.intDay ?? 0,
    INT_PRC: input.intPrc ?? 0,
    INT_AMT: assessed,
    INT_REC_AMT: received,
    KASAR_AMT: kasar,
    EMP_CODE: (input.empCode ?? '').trim() || null,
    VCH_DESC: (input.desc ?? '').trim() || null,
    HD_VCH_NO: identity.hiddenVoucherNo,
    MAIN_USER: identity.mainUser || null,
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
  const movement = {
    ...key,
    SR_NO: 1,
    VCH_DATE: vchDate,
    VCH_TIME: identity.voucherTime,
    VCH_TYPE: book.shortName,
    INOUT_TYPE: book.inout ?? 'I',
    ENTRY_TYPE: 'D',
    BOOK_NAME: book.mainBook || book.name,
    AC_CODE: party,
    ISU_NO: isuNoStr,
    ISU_LC: scope.lcCode,
    ISU_YRCD: isuYear,
    ISU_DBCD: isuBook,
    LOAN_TYPE: loanType,
    FROM_DATE: input.fromDate ? new Date(input.fromDate) : null,
    TO_DATE: input.toDate ? new Date(input.toDate) : null,
    INT_DAYS: input.intDay ?? 0,
    DHRN_AMT: 0,
    DHRN_REC_AMT: principal,
    UNCHAK_DHRN_REC: unchak,
    ADJ_DHRN: 0,
    INT_PRC: input.intPrc ?? 0,
    INT_AMT: assessed,
    INT_REC_AMT: round2(received + kasar),
    REMARKS: (input.desc ?? '').trim() || null,
    HD_VCH_NO: identity.hiddenVoucherNo,
    MAIN_USER: identity.mainUser || null,
    DATA_TRFR: 'N',
  };
  // ROJ_MEL_DATA cash-book projection (Ac_Rojmel.cs:512-526), keyed by LEDR_KEY.
  const acName = input.borrowerName ?? party;
  const rojKey = (n: number) =>
    `${key.CO_CODE}${key.LC_CODE}${key.CO_YEAR}${key.CO_BOOK}${String(key.VCH_NO).padStart(5, '0')}${String(n).padStart(2, '0')}`;
  const rojBase = {
    ...key,
    VCH_DATE: vchDate,
    VCH_TYPE: book.shortName,
    BOOK_NAME: book.mainBook || book.name,
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
    IT_DESC: (input.desc ?? '').trim() || '',
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
  };
  const roj: Record<string, unknown>[] = [];
  if (ptot !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(1),
      AC_CODE: party,
      LD_CODE: settlement,
      CR_AMT: ptot,
      DR_AMT: 0,
      AC_NAME: `DHRN - ${acName}`,
    });
  if (received !== 0 || kasar !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(2),
      AC_CODE: party,
      LD_CODE: intIncAc,
      CR_AMT: round2(received + kasar),
      DR_AMT: 0,
      AC_NAME: `INTREST - ${acName}`,
    });
  if (kasar !== 0)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(3),
      AC_CODE: kasarAc,
      LD_CODE: party,
      CR_AMT: 0,
      DR_AMT: kasar,
      AC_NAME: `INTKSR - ${acName}`,
    });
  const moneyIn = round2(principal + received + unchak);
  if (moneyIn !== 0 && settlement !== issueCashAc)
    roj.push({
      ...rojBase,
      LEDR_KEY: rojKey(4),
      AC_CODE: settlement,
      LD_CODE: party,
      CR_AMT: 0,
      DR_AMT: moneyIn,
      AC_NAME: '',
    });

  const writes: Array<{ table: string; rows: Record<string, unknown>[] }> = [
    { table: 'DHRN_REC_DATA', rows: [recHeader] },
    { table: 'DHRN_DATA', rows: [movement] },
  ];
  if (roj.length) writes.push({ table: 'ROJ_MEL_DATA', rows: roj });
  if ((input.desc ?? '').trim())
    writes.push({
      table: 'REMARK_DATA',
      rows: [
        {
          ...key,
          SR_NO: 0,
          VCH_DATE: vchDate,
          AC_CODE: party,
          AC_NAME: input.borrowerName ?? null,
          MAIN_BOOK: book.mainBook || book.name,
          VCH_REMARK: String(input.desc).slice(0, 255),
        },
      ],
    });

  await insertHiddenIdentityTx(tx, scope, identity, book.name);
  await postVoucherTx(tx, scope.tenantId, {
    bookName: book.mainBook || book.name,
    partyAc: party,
    ledger: { table: 'AC_DATA', lines: ledger },
    writes,
  });
  return { vchNo: identity.vchNo, interest: assessed, received, principal: ptot };
}

const n = (v: unknown) => (v != null ? Number(v) : undefined);
/** Map a raw request body + scope into a DhrnInterestInput (keeps the route file thin). */
export function dhrnInterestInputFromBody(
  scope: VoucherScope,
  b: Record<string, any>,
): DhrnInterestInput {
  return {
    scope,
    isuNo: b.isuNo,
    isuBook: b.isuBook,
    isuYear: b.isuYear,
    borrowerAc: b.borrowerAc,
    borrowerName: b.borrowerName,
    loanType: b.loanType,
    interest: n(b.interest),
    intReceived: n(b.intReceived),
    intKasar: n(b.intKasar),
    principalReceived: n(b.principalReceived),
    unchakReceived: n(b.unchakReceived),
    intPrc: b.intPrc,
    fromDate: b.fromDate,
    toDate: b.toDate,
    intMonth: n(b.intMonth),
    intDay: n(b.intDay),
    settlementAc: b.settlementAc ?? b.cashAc,
    intIncAc: b.intIncAc,
    kasarAc: b.kasarAc,
    empCode: b.empCode,
    desc: b.desc,
    vchDate: b.vchDate,
    mainUser: b.mainUser,
  };
}

/**
 * Interest receipt on a Dhrn/loan issue (TR_DHRN_INTREC). Collects assessed interest, optional
 * principal and interest kasar; the legacy interest-only payload (isuNo + interest) remains the
 * P=U=K=0, I=R subset. Desktop-faithful header + 8-leg ledger + movement + roj + remark.
 */
export async function receiveDhrnInterest(
  prisma: any,
  input: DhrnInterestInput,
): Promise<{ vchNo: number }> {
  if (!input.borrowerAc) throw new DhrnValidationError('borrower account is required');
  const tenantId = input.scope.tenantId;
  const d = input.vchDate ? new Date(input.vchDate) : new Date();
  const res = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) =>
    writeDhrnInterestTx(tx, input, await createIdentityTx(tx, input.scope, d, input.mainUser)),
  );
  return { vchNo: res.vchNo };
}

/** Reopen a Dhrn interest receipt (DHRN_REC_DATA header, desktop DISPLAY_DATA contract). */
export async function getDhrnInterest(prisma: any, scope: VoucherScope, vchNo: number | string) {
  const tenantId = scope.tenantId;
  const no = formatVoucherNo(vchNo);
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","HD_VCH_NO","VCH_DATE"::text vd,"AC_CODE","AC_NAME","LEDR_ACCD","LOAN_TYPE",
              "ISU_NO","ISU_LC","ISU_YRCD","ISU_DBCD","DHRN_REC_AMT"::float8 p,"UNCHAK_DHRN_REC"::float8 u,
              "FROM_DATE"::text fd,"TO_DATE"::text td,"INT_MONTH"::float8 im,"INT_DAY"::float8 idd,
              "INT_PRC"::float8 prc,"INT_AMT"::float8 ia,"INT_REC_AMT"::float8 ir,"KASAR_AMT"::float8 k,
              "EMP_CODE","VCH_DESC","MAIN_USER"
         FROM "DHRN_REC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      no,
    );
    if (!rows.length) throw new DhrnValidationError(`dhrn-interest voucher not found: ${no}`);
    const h = rows[0];
    return {
      voucherNo: no,
      hiddenVoucherNo: String(h.HD_VCH_NO ?? ''),
      mainUser: String(h.MAIN_USER ?? ''),
      vchDate: String(h.vd ?? '').slice(0, 10),
      borrowerAc: String(h.AC_CODE ?? ''),
      borrowerName: String(h.AC_NAME ?? ''),
      settlementAc: String(h.LEDR_ACCD ?? ''),
      loanType: String(h.LOAN_TYPE ?? 'A'),
      isuNo: String(h.ISU_NO ?? ''),
      isuBook: String(h.ISU_DBCD ?? ''),
      isuYear: String(h.ISU_YRCD ?? ''),
      principalReceived: Number(h.p ?? 0),
      unchakReceived: Number(h.u ?? 0),
      fromDate: String(h.fd ?? '').slice(0, 10),
      toDate: String(h.td ?? '').slice(0, 10),
      intMonth: Number(h.im ?? 0),
      intDay: Number(h.idd ?? 0),
      intPrc: Number(h.prc ?? 0),
      interest: Number(h.ia ?? 0),
      intReceived: Number(h.ir ?? 0),
      intKasar: Number(h.k ?? 0),
      empCode: String(h.EMP_CODE ?? ''),
      desc: String(h.VCH_DESC ?? ''),
    };
  });
}

/** Edit a Dhrn interest receipt: replace the write set and repost (desktop save-on-edit). */
export async function editDhrnInterest(
  prisma: any,
  input: DhrnInterestInput,
  vchNo: number | string,
): Promise<{ vchNo: number }> {
  if (!input.borrowerAc) throw new DhrnValidationError('borrower account is required');
  const tenantId = input.scope.tenantId;
  const d = input.vchDate ? new Date(input.vchDate) : new Date();
  const res = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'DHRN_REC_DATA',
      scope: input.scope,
      requestedVoucherNo: vchNo,
      requestedDate: d,
    });
    await replaceWriteSetTx(
      tx,
      input.scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      DHRN_INT_TABLES,
    );
    return writeDhrnInterestTx(tx, input, identity);
  });
  return { vchNo: res.vchNo };
}

/** Delete a Dhrn interest receipt: reverse the write set + desktop DELETE_DATA audit (VCH_VAL_CR = INT_REC_AMT). */
export async function deleteDhrnInterest(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const s = input.scope;
  const no = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'DHRN_REC_DATA',
      scope: s,
      requestedVoucherNo: no,
      requestedDate: new Date(),
    });
    const hdr: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_DATE"::text vd,"VCH_TIME"::text vt,"AC_CODE","AC_NAME","INT_REC_AMT"::float8 ir,"VCH_DESC" FROM "DHRN_REC_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
      no,
    );
    const h = hdr[0] ?? {};
    await reverseVoucherTx(tx, tenantId, {
      tables: [...DHRN_INT_TABLES],
      key: voucherKey(s, no),
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...voucherKey(s, no),
          SR_NO: 1,
          VCH_DATE: h.vd ?? null,
          VCH_TIME: h.vt ?? null,
          AC_CODE: String(h.AC_CODE ?? ''),
          AC_NAME: String(h.AC_NAME ?? ''),
          HD_VCH_NO: identity.hiddenVoucherNo,
          VCH_VAL_DR: 0,
          VCH_VAL_CR: Number(h.ir ?? 0),
          FINE_TYPE: 'A',
          VCH_FINE_DR: 0,
          VCH_FINE_CR: 0,
          DELETE_USER: input.deleteUser ?? 'system',
          VCH_DESC: String(h.VCH_DESC ?? '').slice(0, 149),
          MAIN_USER: identity.mainUser || null,
        },
      },
    });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      tenantId,
      s.coCode,
      s.lcCode,
      s.coBook,
      identity.hiddenVoucherNo,
    );
    return { reversed: true as const };
  });
}
