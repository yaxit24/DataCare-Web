import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx } from '../posting/posting.js';
import { fineWt } from '../shared/fine.js';

/**
 * Tag Split (TR_TAG_SPLIT) — split one parent stock tag into several child tags.
 *
 * Mirrors the desktop Ac_Stock.Tag_Split_Stk: the parent tag leaves stock as a single MAIN_STOCK
 * out-movement (SR_NO 1, TR_TYPE 'O', ITM_SIGN '-', carrying its full weight/fine columns) and each
 * child tag enters stock as its own in-movement (TR_TYPE 'I', ITM_SIGN '+', fine = net·touch/100).
 * Both legs share VCH_TYPE 'TGSPL' / BOOK_NAME 'TAG SPLIT'. It is pure inventory re-tagging — no
 * value changes hands, so the money ledger (AC_DATA) is empty, exactly like tagOpening/tagCancel.
 *
 * Weight conservation is enforced: Σ(children netWt) must equal the parent netWt (within 0.01),
 * so the split neither creates nor destroys metal. The whole voucher is reversible by its key via
 * deleteTagSplit (removes the MAIN_STOCK rows), following the tagOps.ts footprint.
 */

export class TagSplitError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'TagSplitError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/** Coerce to number (null/undefined ⇒ 0), matching stock.ts/tagOps.ts N(). */
const N = (v: unknown): number => (v == null ? 0 : Number(v));
/** Round to 3 dp (weights/fine), matching stock.ts/tagOps.ts r3(). */
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

const SPLIT_BOOK = 'TSP'; // CO_BOOK (varchar(3)) for Tag Split
const NET_TOLERANCE = 0.01; // max |Σchildren.netWt − parent.netWt| accepted

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

/** The parent tag being split (leaves stock in full). */
export interface TagSplitParent {
  tagNo: string;
  itCode: string;
  pcs?: number;
  netWt?: number;
  grossWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number; // optional explicit fine; otherwise (net+ght)×(touch+west)/100
}

/** One child tag produced by the split (enters stock). */
export interface TagSplitChild {
  tagNo: string;
  itCode: string;
  pcs?: number;
  netWt?: number;
  grossWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number;
}

export interface TagSplitInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string;
  parent: TagSplitParent;
  children: TagSplitChild[];
}

/**
 * Split a parent tag into child tags. Writes one MAIN_STOCK OUT row for the parent plus one IN row
 * per child inside a single tenant transaction; no money ledger (empty AC_DATA). Reversible by key.
 */
export async function splitTag(
  prisma: any,
  input: TagSplitInput,
): Promise<{ vchNo: number; children: number }> {
  const parent = input.parent;
  const children = input.children;
  if (!parent?.tagNo) throw new TagSplitError('splitTag: parent tag is required');
  if (!children?.length) throw new TagSplitError('splitTag: at least one child tag is required');

  // Weight conservation — the children must redistribute exactly the parent's net weight.
  const parentNet = r3(N(parent.netWt));
  const childNet = r3(children.reduce((s, c) => s + N(c.netWt), 0));
  if (Math.abs(childNet - parentNet) > NET_TOLERANCE) {
    // TR_TAG_SPLIT.cs reports an unbalanced split in these words when no absorbing account is given
    // (`tAcCode.Text = '' AND Val(nCrWt) <> Val(nDrWt)`). The web split has no account field, so that
    // is the only reachable branch; the numbers are appended because the desktop shows them on screen.
    throw new TagSplitError(
      `${DESKTOP_MESSAGES.SPLIT_WEIGHT_DIFFERENCE} received ${childNet}, issued ${parentNet}`,
    );
  }

  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const parentFine =
    parent.fineWt != null
      ? r3(Number(parent.fineWt))
      : fineWt(parent.netWt, parent.ghtWt, parent.touch, parent.westPct);
  const childFine = (c: TagSplitChild): number =>
    c.fineWt != null ? r3(Number(c.fineWt)) : fineWt(c.netWt, c.ghtWt, c.touch, c.westPct);

  return withTenant(prisma, tenantId, async (tx: any) => {
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, no, input.book ?? SPLIT_BOOK);

    // SR_NO 1: parent leaves stock (full weight/fine), TR_TYPE 'O' / ITM_SIGN '-'.
    const parentRow: Record<string, unknown> = {
      ...key,
      SR_NO: 1,
      ISR_NO: 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'TGSPL',
      BOOK_NAME: 'TAG SPLIT',
      IT_CODE: parent.itCode,
      TAG_NO: parent.tagNo,
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      ITM_QTY: N(parent.netWt) || N(parent.pcs) || 1,
      ITM_PCS: N(parent.pcs) || 1,
      ITM_GWT: N(parent.grossWt),
      ITM_NWT: N(parent.netWt),
      ITM_TOUCH: N(parent.touch),
      ITM_WEST: 0,
      ITM_FINE: parentFine,
      KR_TOUCH: N(parent.touch),
      KR_FINE: parentFine,
      NET_AMT: 0,
    };

    // SR_NO 2..n: each child enters stock, TR_TYPE 'I' / ITM_SIGN '+', fine = net·touch/100.
    const childRows: Record<string, unknown>[] = children.map((c, i) => {
      const fine = childFine(c);
      return {
        ...key,
        SR_NO: i + 2,
        ISR_NO: 1,
        VCH_DATE: vchDate,
        VCH_TYPE: 'TGSPL',
        BOOK_NAME: 'TAG SPLIT',
        IT_CODE: c.itCode,
        TAG_NO: c.tagNo,
        TR_TYPE: 'I',
        ITM_SIGN: '+',
        ITM_QTY: N(c.netWt) || N(c.pcs) || 1,
        ITM_PCS: N(c.pcs) || 1,
        ITM_GWT: N(c.grossWt),
        ITM_NWT: N(c.netWt),
        ITM_TOUCH: N(c.touch),
        ITM_WEST: 0,
        ITM_FINE: fine,
        KR_TOUCH: N(c.touch),
        KR_FINE: fine,
        NET_AMT: 0,
      };
    });

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] }, // pure inventory re-tag — no amount entry
      writes: [{ table: 'MAIN_STOCK', rows: [parentRow, ...childRows] }],
    });
    return { vchNo: no, children: children.length };
  });
}

/** Delete/reverse a tag-split voucher (removes its MAIN_STOCK rows by voucher key). */
export async function deleteTagSplit(
  prisma: any,
  scope: VoucherScope,
  vchNo: number | string,
  book = SPLIT_BOOK,
): Promise<{ reversed: true }> {
  const key = keyOf(scope, Number(vchNo), book);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, scope.tenantId, { tables: ['MAIN_STOCK'], key });
    return { reversed: true };
  });
}
