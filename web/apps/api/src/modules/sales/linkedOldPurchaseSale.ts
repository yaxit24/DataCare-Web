import { round, toIsoDate } from '@datacare/core';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { withTxBudget } from '../shared/txBudget.js';
import {
  deleteLinkedPurchaseTx,
  findLinkedPurchasesTx,
  writeLinkedPurchaseTx,
  type LinkedPurchaseInput,
  type LinkedPurchaseRef,
} from '../purchase/linkedPurchase.js';
import { getPurchaseTx } from '../purchase/purchase.js';
import {
  isUrdPurchaseBookTx,
  resolveUrdPurchaseBookTx,
  type UrdMetal,
} from '../purchase/urdBook.js';
import { FormForbiddenError, authorizeFormTx, loadPrincipalTx } from '../rbac/authorization.js';
import { SaleValidationError, type SaleInput } from './sales.js';
import { getSaleTx } from './saleRead.js';
import type { LinkedOldMetal, LinkedOldPurchaseSummary, LinkedSaleHook } from './linkedOldMetal.js';

/**
 * The sale side of the linked old-gold (URD) purchase (owner decision 2B, PR2).
 *
 * Desktop: on a tax-invoice book (FormBookType "T") the totals grid's Old Gold / Old Silver row opens TR_PURC on the
 * URD book with the sale's party (cash party 00045 → 00050) and the sale's number in tSlBill (TR_SALE.cs:18756-18842;
 * TR_PURC.cs:13724-13740). After the purchase commits, its BILL_OS (TOT_AMT for 00050) and net weight come back into
 * MSG2_TOTAL[9|10] (TR_PURC.cs:13283-13312; TR_SALE.cs:16482-16497), and the sale stores them as OLD_GL_AMT / OLD_GL
 * and OLD_SL_AMT / OLD_SL (:15064-15065, :15090-15091), reduces BILL_OS (:19150/:19155) and, for 00045, grosses up
 * CASH_AMT (:15071-15080). Sales_Ledr has no OLD_GL leg: the purchase's own Purc_Ledr settles the party.
 *
 * The web writes both in ONE transaction (deliberate deviation: the desktop commits the purchase first and abandons it
 * when the sale is not saved). `POST/PUT /sales` carries `linkedOldPurchase: { gold?, silver? }` in the purchase
 * writer's shape; the server sets the book (urdBook.ts), the party, the date and the SL_BILL_* link, and reads the
 * amounts back from the stored purchase — the client's figures are never used.
 *
 * On edit, `linkedOldPurchase` present is authoritative: a metal it no longer carries has its purchase deleted.
 * Absent (an older page), the stored linked purchases stay as they are and still fill the sale's Old Gold / Silver.
 */
export interface LinkedOldPurchaseRequest {
  gold?: LinkedPurchaseInput;
  silver?: LinkedPurchaseInput;
}

/** The operator's Purchase right, checked inside the sale transaction (the action depends on what is stored). */
export type PurchaseRightCheck = (
  tx: any,
  action: 'read' | 'create' | 'update' | 'delete',
  metal: UrdMetal,
) => Promise<void>;

export class LinkedPurchaseForbiddenError extends FormForbiddenError {
  constructor(action: 'read' | 'create' | 'update' | 'delete', metal: UrdMetal) {
    super(PURCHASE_FORM, action);
    this.message = `You need the Purchase ${action} right to save the Old ${metal === 'G' ? 'Gold' : 'Silver'} purchase of this sale`;
    this.name = 'LinkedPurchaseForbiddenError';
  }
}

const PURCHASE_FORM = 'Purchase/Purchase Invoice';
const METAL_KEY: Record<UrdMetal, keyof LinkedOldPurchaseRequest> = { G: 'gold', S: 'silver' };
const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => (value == null ? 0 : Number(value));

const PURCHASE_ONLY_FIELDS = [
  'scope',
  // The web `urd` flag forces tax to 0; the desktop URD book only skips the default tax code 10 (TR_PURC.cs:11657),
  // so a typed tax stays and the flag is never taken from the client.
  'urd',
  'linkedCashParty',
  'saleBillNo',
  'saleBillLc',
  'saleBillYear',
  'saleBillBook',
  'consiNo',
  'consiLcCode',
  'consiYrcd',
  'consiDbcd',
] as const;

/**
 * `body.linkedOldPurchase` as the writer takes it: undefined when absent; each metal parsed by the purchase route's
 * own body reader, without the book, link or consignment fields (the server sets them).
 */
export function linkedOldPurchaseRequest(
  raw: unknown,
  purchaseInput: (body: Record<string, any>) => Record<string, any>,
): LinkedOldPurchaseRequest | undefined {
  if (raw == null) return undefined;
  if (typeof raw !== 'object' || Array.isArray(raw))
    throw new SaleValidationError('linkedOldPurchase must be an object with gold and/or silver');
  const out: LinkedOldPurchaseRequest = {};
  for (const key of ['gold', 'silver'] as const) {
    const body = (raw as Record<string, unknown>)[key];
    if (body == null) continue;
    if (typeof body !== 'object' || Array.isArray(body))
      throw new SaleValidationError(`linkedOldPurchase.${key} must be a purchase`);
    const parsed: Record<string, any> = { ...purchaseInput(body as Record<string, any>) };
    for (const field of PURCHASE_ONLY_FIELDS) delete parsed[field];
    const lines = (body as Record<string, unknown>).lines;
    if (!Array.isArray(lines) || !lines.length)
      throw new SaleValidationError(`linkedOldPurchase.${key} needs at least one line`);
    out[key] = { ...parsed, lines } as LinkedPurchaseInput;
  }
  return out;
}

/** The operator's Purchase right on the session location (USER_SET, as the route guard checks a form). */
export function purchaseRightCheck(session: {
  tenantId: string;
  coCode: string;
  loginCoCode: string;
  loginName: string;
  lcCode: string;
}): PurchaseRightCheck {
  return async (tx, action, metal) => {
    const principal = await loadPrincipalTx(tx, {
      tenantId: session.tenantId,
      coCode: session.coCode,
      loginCoCode: session.loginCoCode,
      loginName: session.loginName,
    });
    try {
      await authorizeFormTx(tx, {
        tenantId: session.tenantId,
        lcCode: session.lcCode,
        principal,
        form: PURCHASE_FORM,
        action,
      });
    } catch (error) {
      if (error instanceof FormForbiddenError)
        throw new LinkedPurchaseForbiddenError(action, metal);
      throw error;
    }
  };
}

/** A linked purchase's metal: the URD book rule, else the book's ITM_TYPE (a book chosen in Settings earlier). */
async function metalOfBookTx(tx: any, scope: VoucherScope, coBook: string): Promise<UrdMetal> {
  const metal = await isUrdPurchaseBookTx(
    tx,
    { tenantId: scope.tenantId, coCode: scope.coCode, lcCode: scope.lcCode },
    coBook,
  );
  if (metal) return metal;
  const rows: Array<{ t: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "ITM_TYPE" t FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND btrim("CO_BOOK")=$4 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    coBook,
  );
  return text(rows[0]?.t).toUpperCase() === 'S' ? 'S' : 'G';
}

/**
 * The stored purchase's amount and weight: BILL_OS, or TOT_AMT for party 00050, and the net weight total
 * (TR_PURC.cs:13283-13312, MSG2_TOTAL[10,3] / [5,3] and MSG_PR_TOT[0,15]).
 */
async function summarizeTx(
  tx: any,
  ref: LinkedPurchaseRef & { tenantId: string; coCode: string },
  metal: UrdMetal,
  created: boolean,
  version: string,
): Promise<LinkedOldPurchaseSummary & { acCode: string; vchDate: string }> {
  const params = [ref.tenantId, ref.coCode, ref.lcCode, ref.coYear, ref.coBook, ref.vchNo];
  const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
  const [header]: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","BILL_OS","TOT_AMT","VCH_DATE"::text AS "DT" FROM "PR_DATA" WHERE ${where}`,
    ...params,
  );
  if (!header)
    throw new SaleValidationError(`linked purchase ${ref.coBook}/${ref.vchNo} not found`);
  const [weight]: Array<{ nwt: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(coalesce("ITM_NWT",0)),0)::float AS nwt FROM "PR_DETL" WHERE ${where}`,
    ...params,
  );
  return {
    metal,
    coBook: ref.coBook,
    vchNo: ref.vchNo,
    amount: round(num(text(header.AC_CODE) === '00050' ? header.TOT_AMT : header.BILL_OS), 2),
    netWt: round(num(weight?.nwt), 3),
    created,
    version,
    acCode: text(header.AC_CODE),
    vchDate: text(header.DT),
  };
}

function totalsOf(
  all: Array<LinkedOldPurchaseSummary & { acCode?: string; vchDate?: string }>,
  cashDigits: 0 | 2,
): LinkedOldMetal {
  const purchases: LinkedOldPurchaseSummary[] = all.map(({ acCode: _a, vchDate: _d, ...p }) => p);
  const sum = (metal: UrdMetal, pick: (p: LinkedOldPurchaseSummary) => number) =>
    purchases.filter((p) => p.metal === metal).reduce((s, p) => s + pick(p), 0);
  return {
    goldAmt: round(
      sum('G', (p) => p.amount),
      2,
    ),
    goldWt: round(
      sum('G', (p) => p.netWt),
      3,
    ),
    silverAmt: round(
      sum('S', (p) => p.amount),
      2,
    ),
    silverWt: round(
      sum('S', (p) => p.netWt),
      3,
    ),
    purchases,
    cashDigits,
  };
}

async function saleBookTypeTx(tx: any, scope: VoucherScope): Promise<string> {
  const rows: Array<{ t: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_TYPE" t FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N' ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  return text(rows[0]?.t).toUpperCase();
}

/**
 * A T book never opens the in-bill old-metal grid (MSG_OLD / SL_PR_DETL): rows 9/10 open the URD purchase instead
 * (TR_SALE.cs:18843-18847 reaches MSG_OLD_EnterCell only for a non-T book). A T sale can still carry SL_PR_DETL rows
 * moved over by the voucher transfer (:20494), so the grid is refused only beside a linked purchase, never mixed.
 */
function assertNoInBillOldMetal(input: SaleInput): void {
  const rows = (input.oldGold ?? []).filter((g) => num(g.netWt) !== 0 || num(g.amount) !== 0);
  if (rows.length)
    throw new SaleValidationError(
      'Old gold / silver is taken through the linked URD purchase on a tax-invoice book; remove the exchange rows',
    );
}

/** CO_SET.ALL_ROF_REMOVE: the 00045 cash is rounded to 2 places when 'Y', else to the rupee (TR_SALE.cs:19125-19150). */
async function cashDigitsTx(tx: any, scope: VoucherScope): Promise<0 | 2> {
  const rows: Array<{ v: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "ALL_ROF_REMOVE"::text v FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  return text(rows[0]?.v).toUpperCase() === 'Y' ? 2 : 0;
}

const refName = (r: { coBook: string; vchNo: string }) => `${r.coBook}/${r.vchNo}`;

/**
 * The hook createSale / editSale run inside the sale transaction.
 *
 * Create: a purchase already linked to the new sale key (left by a sale that was never saved) is refused by name —
 * it is never edited or silently counted. Edit without `linkedOldPurchase`: the stored purchases are kept only while
 * their party (sale party, 00045 → 00050) and date still match the sale; otherwise the old-gold purchase must be
 * reopened and sent again.
 */
export function linkedOldPurchaseHook(
  input: SaleInput,
  request: LinkedOldPurchaseRequest | undefined,
  authorize: PurchaseRightCheck,
): LinkedSaleHook {
  return async (tx, saleVoucherNo, isEdit) => {
    const scope = input.scope as VoucherScope & { coYear: string; coBook: string };
    const link = {
      saleBillNo: saleVoucherNo,
      saleBillLc: scope.lcCode,
      saleBillYear: scope.coYear,
      saleBillBook: scope.coBook,
    };
    const saleKey = { tenantId: scope.tenantId, coCode: scope.coCode, ...link };
    const existing = await findLinkedPurchasesTx(tx, saleKey);
    const scopedRef = (ref: LinkedPurchaseRef) => ({
      ...ref,
      tenantId: scope.tenantId,
      coCode: scope.coCode,
    });
    if (!isEdit && existing.length)
      throw new SaleValidationError(
        `Purchase ${existing.map(refName).join(', ')} is already linked to sale ${scope.coBook}/${saleVoucherNo}, left by a sale that was not saved; open purchase ${existing.map(refName).join(', ')} and use Delete this stray purchase before saving this sale`,
      );
    if (!existing.length && !request) return undefined;
    // TR_PURC.cs:13724-13740: the party is the sale's, the cash party 00045 becoming 00050; the date is the sale's.
    const acCode = text(input.acCode) === '00045' ? '00050' : text(input.acCode);
    const saleDate = input.vchDate ? toIsoDate(input.vchDate) : '';
    const cashDigits = await cashDigitsTx(tx, scope);

    if (!request) {
      assertNoInBillOldMetal(input);
      const kept = [];
      for (const ref of existing) {
        const metal = await metalOfBookTx(tx, scope, ref.coBook);
        const stored = await summarizeTx(tx, scopedRef(ref), metal, false, '');
        if (stored.acCode !== acCode || (saleDate && stored.vchDate !== saleDate))
          throw new SaleValidationError(
            `The old ${metal === 'G' ? 'gold' : 'silver'} purchase ${refName(ref)} is on party ${stored.acCode} dated ${stored.vchDate}, but this sale now needs party ${acCode}${saleDate ? ` dated ${saleDate}` : ''}: reopen the old-gold purchase and save the sale again`,
          );
        kept.push(stored);
      }
      return totalsOf(kept, cashDigits);
    }

    const metals = (['G', 'S'] as const).filter((m) => request[METAL_KEY[m]]);
    if (metals.length) {
      const bookType = await saleBookTypeTx(tx, scope);
      if (bookType !== 'T')
        throw new SaleValidationError(
          `The linked old gold / silver purchase is only for a tax-invoice (T) sale book; book ${scope.coBook} is type '${bookType || '?'}': use the Old Gold / Silver exchange rows`,
        );
      assertNoInBillOldMetal(input);
    }
    const written = [];
    for (const metal of metals) {
      const book = await resolveUrdPurchaseBookTx(tx, scope, metal);
      const purchaseScope: VoucherScope = { ...scope, coBook: book.coBook };
      const stored = existing.some(
        (r) => r.lcCode === scope.lcCode && r.coYear === scope.coYear && r.coBook === book.coBook,
      );
      await authorize(tx, stored ? 'update' : 'create', metal);
      const body = request[METAL_KEY[metal]]!;
      // TR_PURC.cs:15087-15090: the 00050 purchase pays itself in cash (the writer sets CASH_AMT); no other tender.
      if (
        acCode === '00050' &&
        [body.chequeAmt, body.cardAmt, body.upiAmt].some((v) => num(v) !== 0)
      )
        throw new SaleValidationError(
          'The old-gold purchase of a cash sale (party 00050) is paid in cash only: remove the cheque, card and UPI amounts',
        );
      const result = await writeLinkedPurchaseTx(
        tx,
        purchaseScope,
        {
          ...body,
          acCode,
          acName: input.acName ?? body.acName,
          vchDate: input.vchDate ?? new Date(),
          mainUser: input.mainUser,
          linkedCashParty: true,
        },
        link,
        { allowLinkedEdit: true },
      );
      written.push(
        await summarizeTx(
          tx,
          scopedRef({
            lcCode: scope.lcCode,
            coYear: scope.coYear,
            coBook: book.coBook,
            vchNo: formatVoucherNo(result.vchNo),
          }),
          metal,
          result.created,
          result.version,
        ),
      );
    }
    // An edit that no longer carries a metal removes its purchase (Purchase delete right).
    for (const ref of existing) {
      if (written.some((w) => w.coBook === ref.coBook && w.vchNo === ref.vchNo)) continue;
      await authorize(tx, 'delete', await metalOfBookTx(tx, scope, ref.coBook));
      await deleteLinkedPurchaseTx(tx, scopedRef(ref), link, input.mainUser);
    }
    return written.length ? totalsOf(written, cashDigits) : undefined;
  };
}

/**
 * GET /sales/:vchNo: the sale and its linked purchases in ONE read transaction. With the Purchase view right each
 * comes in the purchase reopen view; without it, only the link key and the amounts the sale uses.
 */
export async function getSaleWithLinkedPurchases(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  mayViewPurchase: (tx: any) => Promise<boolean>,
): Promise<Record<string, unknown>> {
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const sale = await getSaleTx(tx, scope, voucherNo);
    const found = await findLinkedPurchasesTx(
      tx,
      {
        tenantId: scope.tenantId,
        coCode: scope.coCode,
        saleBillNo: voucherNo,
        saleBillLc: scope.lcCode,
        saleBillYear: String(scope.coYear ?? ''),
        saleBillBook: String(scope.coBook ?? ''),
      },
      { lock: false },
    );
    const view = found.length ? await mayViewPurchase(tx) : false;
    const linkedOldPurchases = [];
    for (const ref of found) {
      const metal = await metalOfBookTx(tx, scope, ref.coBook);
      const scoped = { ...ref, tenantId: scope.tenantId, coCode: scope.coCode };
      const { amount, netWt } = await summarizeTx(tx, scoped, metal, false, '');
      const pscope = { ...scope, lcCode: ref.lcCode, coYear: ref.coYear, coBook: ref.coBook };
      linkedOldPurchases.push({
        metal,
        coBook: ref.coBook,
        vchNo: ref.vchNo,
        amount,
        netWt,
        ...(view ? { purchase: await getPurchaseTx(tx, pscope, ref.vchNo) } : {}),
      });
    }
    return { ...sale, linkedOldPurchases };
  });
}

/** Whether the operator may view the Purchase form (USER_SET FRM_VIEW), for the GET above. */
export function purchaseViewCheck(
  session: Parameters<typeof purchaseRightCheck>[0],
): (tx: any) => Promise<boolean> {
  const check = purchaseRightCheck(session);
  return async (tx) => {
    try {
      await check(tx, 'read', 'G');
      return true;
    } catch (error) {
      if (error instanceof LinkedPurchaseForbiddenError) return false;
      throw error;
    }
  };
}

/** The route's one call: parse `linkedOldPurchase` and build the hook with the session's Purchase right check. */
export function linkedSaleHookFor(
  input: SaleInput,
  raw: unknown,
  purchaseInput: (body: Record<string, any>) => Record<string, any>,
  session: Parameters<typeof purchaseRightCheck>[0],
): LinkedSaleHook {
  return linkedOldPurchaseHook(
    input,
    linkedOldPurchaseRequest(raw, purchaseInput),
    purchaseRightCheck(session),
  );
}
