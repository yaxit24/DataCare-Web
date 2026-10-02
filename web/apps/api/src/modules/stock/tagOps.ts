import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx, type LedgerLine } from '../posting/posting.js';
import { resolveLiveTagIdentityTx } from './stock.js';
import { fineFor } from '@datacare/core';

/**
 * Phase 4 tag operation — Tag Weight Change (TR_TAG_WT_DIFF), still contained (X21).
 *
 * Tag Cancel and Tag Transfer (desktop TR_TAG_CAN) moved to `tagCancel.ts` (N18), which writes the desktop's
 * register, stock, diamond and delete-audit rows with the full lifecycle.
 *
 * Tag Weight Change books only the NET weight difference (new − old) as a stock adjustment plus a
 * balanced value ledger. The desktop (Ac_Stock.Tag_Wt_Diff_Stk + Ac_Ledr.Tag_Wt_Diff_Ledr +
 * Ac_Rojmel.Tag_Wt_Diff_Rojmel) replaces the whole tag (full OUT + full IN); this web model is the
 * simplified, equivalent net-of-difference form requested for Phase 4: one signed MAIN_STOCK movement
 * of |diff| (sign '+'/'-' per direction) and a Dr/Cr AC_DATA pair valuing the fine difference at rate.
 */

export class TagOpsError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'TagOpsError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/** Coerce to number (null/undefined ⇒ 0), matching stock.ts N(). */
const N = (v: unknown): number => (v == null ? 0 : Number(v));
/** Round to 3 dp (weights/fine), matching stock.ts r3(). */
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
/** Round to 2 dp (money). */
const r2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

const WTDIFF_BOOK = 'TWD'; // CO_BOOK (varchar(3)) for Tag Weight Change
const DEFAULT_STOCK_ADJ_AC = 'STKADJ'; // stock-adjustment (inventory valuation) account
const DEFAULT_DIFF_AC = 'WTDIFF'; // weight-difference counter (P&L) account

/** Build the 5-part voucher key (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO) from scope + number. */
function keyOf(s: VoucherScope, no: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(no),
  };
}

/* -------------------------------------------------------------- Tag Weight Change --------------- */

/** One tag whose net weight is being corrected. */
export interface TagWeightDiffLine {
  tagNo: string;
  itCode: string;
  oldNetWt?: number;
  newNetWt?: number;
  touch?: number;
  rate?: number; // fine rate used to value the weight difference
  /**
   * The live tag INSTANCE whose weight is changing, when a tag number has more than one.
   *
   * `BAR_DETL` keys an instance by TAG_NO + VCH_SRNO and the resolver treats an ambiguous number as an
   * error rather than picking one, so this selects the intended instance.
   */
  vchSrno?: number;
  /** ITM_WEST_PRC — part of the fine base, as in every other voucher family. */
  westPct?: number;
}

export interface TagWeightDiffInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string;
  stockAdjAc?: string; // stock-adjustment account (default 'STKADJ')
  diffAc?: string; // difference counter account (default 'WTDIFF')
  // P1-8: route the weight difference to a karigar PARTY (its gold sub-ledger) + optional old-gold
  // absorption + optional cash payment for the labour on the change.
  partyAc?: string; // karigar/party — receives the fine difference as a gold leg (KR_TOUCH/KR_FINE)
  absorbItCode?: string; // bulk item (e.g. old-gold) that absorbs the metal difference in stock
  absorbSign?: '+' | '-'; // absorption direction (default: opposite the tag movement)
  payAc?: string; // cash/bank paid to the karigar for the work
  payAmt?: number; // amount paid now
  labourAc?: string; // labour expense (default 'LABOUR')
  lines: TagWeightDiffLine[];
}

/**
 * Tag Weight Change (TR_TAG_WT_DIFF): book the net weight difference (newNetWt − oldNetWt) per tag.
 * For each line with a non-zero difference we write:
 *   • a MAIN_STOCK movement (VCH_TYPE 'TGWD', BOOK_NAME 'TAG WT CHANGE') of |diff| with ITM_SIGN/
 *     TR_TYPE '+'/'I' when weight increased, '-'/'O' when it decreased; ITM_FINE = |diff|·touch/100;
 *   • a balanced AC_DATA pair valuing that fine at rate (value = diffFine·rate):
 *       gain (diff>0) ⇒ Dr stock-adjust / Cr diff-account (inventory value up),
 *       loss (diff<0) ⇒ Dr diff-account / Cr stock-adjust (inventory value down).
 * Each pair self-balances, so the whole voucher satisfies Σ DR = Σ CR. Reversible via deleteTagWeightDiff.
 */
export async function tagWeightDiff(
  prisma: any,
  input: TagWeightDiffInput,
): Promise<{ vchNo: number; tags: number; diffFine: number; value: number }> {
  if (!input.lines?.length) throw new TagOpsError('tagWeightDiff: at least one tag line required');
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const stockAdjAc = input.stockAdjAc ?? DEFAULT_STOCK_ADJ_AC;
  const diffAc = input.diffAc ?? DEFAULT_DIFF_AC;

  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, no, input.book ?? WTDIFF_BOOK);
    const useParty = !!input.partyAc;

    /**
     * P6/WP-09 — resolve the LIVE tag instance before adjusting its weight.
     *
     * This path previously never looked the tag up at all: it wrote a MAIN_STOCK movement keyed on
     * TAG_NO alone, so it would happily adjust a tag that does not exist, one belonging to another
     * location, or one already sold. It also stamped no VCH_SRNO, so the movement did not net against
     * any particular instance of a repeated tag number.
     *
     * `resolveLiveTagIdentityTx` is the resolver a sale uses — LC_CODE-scoped, per-instance, netting the
     * MAIN_STOCK signs. Note it RESOLVES without consuming: a weight change does not remove the tag from
     * stock, so `issueTagTx` (which deletes the TAG_STOCK row) would be wrong here. That distinction is
     * why this calls the resolver directly rather than reusing the cancel path.
     */
    const identities = new Map<number, { VCH_SRNO: number; IT_CODE: string }>();
    for (let i = 0; i < input.lines.length; i += 1) {
      const l = input.lines[i]!;
      if (r3(N(l.newNetWt) - N(l.oldNetWt)) === 0) continue; // unchanged tag: nothing to resolve
      const identity = await resolveLiveTagIdentityTx(tx, {
        CO_CODE: input.scope.coCode,
        LC_CODE: input.scope.lcCode,
        TAG_NO: String(l.tagNo),
        IT_CODE: l.itCode ? String(l.itCode) : undefined,
        VCH_SRNO: l.vchSrno != null ? Number(l.vchSrno) : undefined,
      } as never);
      identities.set(i, {
        VCH_SRNO: Number(identity.VCH_SRNO ?? 0),
        IT_CODE: String(identity.IT_CODE ?? l.itCode ?? ''),
      });
    }

    const mainStock: Record<string, unknown>[] = [];
    const ledger: LedgerLine[] = [];
    let totDiffFine = 0;
    let totValue = 0;

    input.lines.forEach((l, i) => {
      const diff = r3(N(l.newNetWt) - N(l.oldNetWt));
      if (diff === 0) return; // no movement for an unchanged tag
      const absDiff = Math.abs(diff);
      const up = diff > 0;
      // Fine goes through the shared desktop policy so a weight change agrees with the tag it adjusts,
      // rather than using a local netWt x touch / 100 that ignores wastage.
      const diffFine = fineFor('tagOpening', {
        netWt: absDiff,
        touch: N(l.touch),
        westPct: N(l.westPct),
      });
      const value = r2(diffFine * N(l.rate));
      totDiffFine += up ? diffFine : -diffFine;
      totValue += up ? value : -value;

      mainStock.push({
        ...key,
        SR_NO: i + 1,
        ISR_NO: 1,
        VCH_DATE: vchDate,
        VCH_TYPE: 'TGWD',
        BOOK_NAME: 'TAG WT CHANGE',
        IT_CODE: identities.get(i)?.IT_CODE || l.itCode,
        TAG_NO: l.tagNo,
        // The resolved instance: without it the movement nets against no particular tag row.
        VCH_SRNO: identities.get(i)?.VCH_SRNO ?? 0,
        TR_TYPE: up ? 'I' : 'O',
        ITM_SIGN: up ? '+' : '-',
        ITM_QTY: absDiff,
        ITM_PCS: 0,
        ITM_GWT: absDiff,
        ITM_NWT: absDiff,
        ITM_TOUCH: N(l.touch),
        // Wastage travels rather than being hard-coded to 0, matching every other voucher family.
        ITM_WEST: N(l.westPct),
        ITM_FINE: diffFine,
        ITM_RATE: N(l.rate),
        KR_TOUCH: N(l.touch),
        KR_FINE: diffFine,
        NET_AMT: value,
      });

      if (useParty) {
        // Karigar PARTY gold leg (metal-only, no money): tag gained ⇒ party is owed the added fine
        // (Cr-Gold, SIGN '+'); tag lost ⇒ party gold reduces (SIGN '-'). KR_TOUCH/KR_FINE carried.
        ledger.push({
          ...key,
          VCH_TYPE: 'TGWD',
          AC_CODE: input.partyAc as string,
          IT_TYPE: 'G',
          SIGN: up ? '+' : '-',
          FINE_WT: diffFine,
          FINE_RATE: N(l.rate),
          DR_AMT: 0,
          CR_AMT: 0,
        });
        // Old-gold absorption: the metal difference moves through a bulk item so stock is conserved.
        if (input.absorbItCode) {
          const aSign = input.absorbSign ?? (up ? '-' : '+');
          mainStock.push({
            ...key,
            SR_NO: 900 + i,
            ISR_NO: 1,
            VCH_DATE: vchDate,
            VCH_TYPE: 'TGWD',
            BOOK_NAME: 'TAG WT CHANGE',
            IT_CODE: input.absorbItCode,
            TAG_NO: 'N',
            TR_TYPE: aSign === '+' ? 'I' : 'O',
            ITM_SIGN: aSign,
            ITM_QTY: absDiff,
            ITM_NWT: absDiff,
            ITM_GWT: absDiff,
            ITM_TOUCH: N(l.touch),
            ITM_FINE: diffFine,
            ITM_RATE: N(l.rate),
            NET_AMT: value,
          });
        }
      } else if (value !== 0) {
        // Legacy self-balanced value pair (no party): Dr/Cr STKADJ ↔ WTDIFF.
        const drAc = up ? stockAdjAc : diffAc;
        const crAc = up ? diffAc : stockAdjAc;
        ledger.push(
          {
            ...key,
            VCH_TYPE: 'TGWD',
            AC_CODE: drAc,
            DR_AMT: value,
            CR_AMT: 0,
            SIGN: 'D',
            FINE_WT: diffFine,
            FINE_RATE: N(l.rate),
          },
          {
            ...key,
            VCH_TYPE: 'TGWD',
            AC_CODE: crAc,
            DR_AMT: 0,
            CR_AMT: value,
            SIGN: 'C',
            FINE_WT: diffFine,
            FINE_RATE: N(l.rate),
          },
        );
      }
    });

    if (!mainStock.length)
      throw new TagOpsError('tagWeightDiff: no non-zero weight differences to post');

    // Optional cash payment to the karigar for the work (Dr labour / Cr cash-bank).
    const payAmt = r2(N(input.payAmt));
    if (useParty && payAmt > 0) {
      const labourAc = input.labourAc ?? 'LABOUR';
      const payAc = input.payAc ?? 'CASH';
      ledger.push(
        { ...key, VCH_TYPE: 'TGWD', AC_CODE: labourAc, DR_AMT: payAmt, CR_AMT: 0, SIGN: 'D' },
        { ...key, VCH_TYPE: 'TGWD', AC_CODE: payAc, DR_AMT: 0, CR_AMT: payAmt, SIGN: 'C' },
      );
    }

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [{ table: 'MAIN_STOCK', rows: mainStock }],
      bookName: 'TAG WT CHANGE',
    });
    return { vchNo: no, tags: mainStock.length, diffFine: r3(totDiffFine), value: r2(totValue) };
  });
}

/** Delete/reverse a tag-weight-change voucher (removes MAIN_STOCK + AC_DATA rows by voucher key). */
export async function deleteTagWeightDiff(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  book = WTDIFF_BOOK,
): Promise<{ reversed: true }> {
  const key = keyOf(scope, Number(vchNo), book);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, scope.tenantId, { tables: ['MAIN_STOCK', 'AC_DATA'], key });
    return { reversed: true };
  });
}
