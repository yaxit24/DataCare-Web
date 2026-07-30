import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx } from '../posting/posting.js';

/**
 * Fine In/Out (TR_FN_INOUT — pure fine-metal in/out, e.g. to/from a refinery or inter-branch).
 *
 * This is the pure-metal flavour of the desktop Branch In/Out (TR_INOUT) form: each line is a
 * weight of metal moving IN (received) or OUT (sent). Per the recovered desktop footprint we write
 *   • the voucher header  → INOUT_DATA
 *   • one detail row/line → INOUT_DETL
 *   • one MAIN_STOCK movement/line — the row that actually changes on-hand fine:
 *        IN  ⇒ TR_TYPE 'I', ITM_SIGN '+', VCH_TYPE 'FNIN'
 *        OUT ⇒ TR_TYPE 'O', ITM_SIGN '-', VCH_TYPE 'FNOUT'
 *      both stamped BOOK_NAME 'FINE INOUT'.
 * It is a pure inventory movement: NO money ledger (AC_DATA is posted empty), since INOUT_DATA only
 * carries metal/weight totals. INOUT_IDTL (tag component sub-detail) is not used by a fine movement.
 * Reversible by voucher key via {@link deleteFineInout}.
 */

export class FineInoutError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'FineInoutError';
  }
}

const num = (v: unknown): number => (v == null ? 0 : Number(v));
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;

/** A fine-metal in/out line: an item + its weights. fineWt is optional (derived if omitted). */
export interface FineInoutLine {
  itCode: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fineWt?: number;
}

export interface FineInoutInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string; // CO_BOOK (default 'FIO')
  direction: 'IN' | 'OUT';
  partyAc?: string; // counter-party account (refinery / branch)
  lines: FineInoutLine[];
}

const DEFAULT_BOOK = 'FIO';
const BOOK_NAME = 'FINE INOUT';

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

function keyOf(s: VoucherScope, book: string, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

/** Pure: fine weight for a line — an explicit fineWt wins, else net × touch / 100 (Tier-1 testable). */
export function lineFine(l: FineInoutLine): number {
  return l.fineWt != null ? round3(num(l.fineWt)) : round3((num(l.netWt) * num(l.touch)) / 100);
}

/**
 * Record a Fine In/Out voucher. Allocates the next voucher number, writes INOUT_DATA + INOUT_DETL
 * and a signed MAIN_STOCK movement per line, all inside ONE tenant transaction (rolls back on any
 * failure). Returns the new voucher number and the total fine moved.
 */
export async function fineInout(
  prisma: any,
  input: FineInoutInput,
): Promise<{ vchNo: number; fine: number }> {
  if (!input.lines?.length) throw new FineInoutError('at least one line is required');
  if (input.direction !== 'IN' && input.direction !== 'OUT')
    throw new FineInoutError("direction must be 'IN' or 'OUT'");

  const tenantId = input.scope.tenantId;
  const book = input.book ?? input.scope.coBook ?? DEFAULT_BOOK;
  const isIn = input.direction === 'IN';
  const trType: 'I' | 'O' = isIn ? 'I' : 'O';
  const sign: '+' | '-' = isIn ? '+' : '-';
  const vchType = isIn ? 'FNIN' : 'FNOUT';
  const inoutType = isIn ? 'I' : 'O';
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const partyAc = input.partyAc ?? null;

  const computed = input.lines.map((l) => ({ in: l, fine: lineFine(l) }));
  const totGwt = round3(computed.reduce((s, c) => s + num(c.in.grossWt), 0));
  const totNwt = round3(computed.reduce((s, c) => s + num(c.in.netWt), 0));
  const totFine = round3(computed.reduce((s, c) => s + c.fine, 0));

  const vchNo = await withTenant(prisma, tenantId, async (tx: any) => {
    const no = await nextVoucherNoTx(tx, { ...input.scope, coBook: book });
    const key = keyOf(input.scope, book, no);

    const header = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: 'O',
      BOOK_NAME,
      AC_CODE: partyAc,
      TOT_GWT: totGwt,
      TOT_NWT: totNwt,
      TOT_FINE: totFine,
      TOT_LBR: 0,
      TOT_OTH: 0,
      TOT_NET_AMT: 0,
      STK_TRFR: 'N',
      DATA_TRFR: 'N',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };

    const detl = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      OLD_SRNO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: 'O',
      BOOK_NAME,
      AC_CODE: partyAc,
      IT_CODE: c.in.itCode ?? null,
      TAG_NO: 'N', // pure fine metal — no tag
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
    }));

    const mainStock = computed.map((c, i) => ({
      ...key,
      SR_NO: i + 1,
      ISR_NO: 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      BOOK_NAME,
      AC_CODE: partyAc,
      IT_CODE: c.in.itCode ?? null,
      TAG_NO: 'N',
      TR_TYPE: trType,
      ITM_SIGN: sign,
      ITM_QTY: num(c.in.netWt),
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.fine,
      DATA_TYPE: 'A',
    }));

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] }, // pure metal movement — no money ledger
      writes: [
        { table: 'INOUT_DATA', rows: [header] },
        { table: 'INOUT_DETL', rows: detl },
        { table: 'MAIN_STOCK', rows: mainStock },
      ],
    });
    return no;
  });

  return { vchNo, fine: totFine };
}

/** Delete/reverse a Fine In/Out voucher (removes INOUT_DATA + INOUT_DETL + MAIN_STOCK by key). */
export async function deleteFineInout(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  book = DEFAULT_BOOK,
): Promise<{ reversed: true }> {
  const key = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear ?? '',
    CO_BOOK: scope.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: ['INOUT_DATA', 'INOUT_DETL', 'MAIN_STOCK'],
      key,
    });
    return { reversed: true };
  });
}
