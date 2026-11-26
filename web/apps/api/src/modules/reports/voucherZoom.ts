import { loadPrincipal, authorizeForm, FormForbiddenError } from '../rbac/authorization.js';
import { withTxBudget } from '../shared/txBudget.js';

/**
 * Voucher zoom from a report row (desktop RP_TAG.cs:8917-9140 DGV_DoubleClick, RP_HUID.cs DGV_DoubleClick).
 *
 * The desktop reads the row's book from BOOK_DATA (MAIN_BOOK, MENU_NAME), refuses with "You Have No Rights..." when the
 * user's rights row for that menu says View = N, then opens the form of the book family on the row's voucher number.
 * Here the answer names the web screen and the query that opens the voucher; the target screen reads it
 * (`useVoucherZoom`, web lib/voucherZoom.ts). The right is checked on the target form by the caller; unlike the desktop, which refuses only an
 * explicit N, a missing rights row also refuses (the web is fail-closed, decision 4 of WP-15).
 */
export interface ZoomTarget {
  /** The web screen that opens the voucher. */
  path: string;
  /** Extra query the screen needs (Only Tag Entry is the Tag Opening screen in TAG GEN mode). */
  query: Record<string, string>;
  /** The rights form of the target menu (rbac/formCatalog). */
  form: string;
}

/** BOOK_DATA.MAIN_BOOK to the screen that opens its vouchers (RP_TAG.cs:8951-9140, the families the web screens open by number). */
const TARGETS: Readonly<Record<string, ZoomTarget>> = {
  OPSTK: { path: '/txn/tag-opening', query: {}, form: 'Inventory/Tag Opening' },
  // The provisioned Tag Opening book carries the MAIN_BOOK name TAG OPENING (seedCompany); desktop books say OPSTK.
  'TAG OPENING': { path: '/txn/tag-opening', query: {}, form: 'Inventory/Tag Opening' },
  'TAG GEN': {
    path: '/txn/tag-opening',
    query: { mode: 'TAG GEN' },
    form: 'Inventory/Tag Opening',
  },
  'JDTR TAG': {
    path: '/txn/tag-opening',
    query: { mode: 'TAG GEN' },
    form: 'Inventory/Tag Opening',
  },
  'MFG TAG': {
    path: '/txn/tag-opening',
    query: { mode: 'TAG GEN' },
    form: 'Inventory/Tag Opening',
  },
  PURCHASE: { path: '/txn/purchase', query: {}, form: 'Purchase/Purchase Invoice' },
  'STOCK ADJUST': { path: '/txn/stock-adjust', query: {}, form: 'Inventory/Stock Adjust' },
  'TAG CANCEL': { path: '/txn/tag-cancel', query: {}, form: 'Inventory/Tag Cancel' },
  'APR ISU': { path: '/txn/tour', query: {}, form: 'Sales/Tour / Approval Sale' },
  'APR RTN': { path: '/txn/tour-return', query: {}, form: 'Sales/Approval Return' },
  SALES: { path: '/txn/sales', query: {}, form: 'Sales/Sales Invoice' },
  'SALES RETURNE': { path: '/txn/sale-return', query: {}, form: 'Sales/Sales Return' },
};

export const zoomQuerySchema = {
  querystring: {
    type: 'object',
    additionalProperties: false,
    // `bookCode`, not `book`/`coBook`: a scope-book parameter is validated against the session's books
    // (businessScope.ts) before the handler runs, so the merged-stock rule (RP_HUID.cs:2254) could never answer.
    required: ['bookCode', 'vchNo'],
    properties: {
      bookCode: { type: 'string', minLength: 1, maxLength: 20 },
      vchNo: { type: 'string', minLength: 1, maxLength: 40 },
    },
  },
};

export interface ZoomAnswer {
  target: ZoomTarget & { coBook: string; vchNo: string; lcCode: string; mainBook: string };
}

export class ZoomNoTargetError extends Error {}

/**
 * The screen for a row's book. `OPSTK` books with a one-character voucher number open nothing (RP_TAG.cs:8953, the
 * year-opening marker rows). Unknown books and families whose screen cannot open a voucher by number give no target.
 */
export async function resolveZoom(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
  input: { book: string; vchNo: string },
): Promise<ZoomAnswer> {
  const book = String(input.book ?? '').trim();
  const vchNo = String(input.vchNo ?? '').trim();
  if (!book || !vchNo) throw new ZoomNoTargetError('no voucher on the row');
  const rows: Array<{ main: string | null }> = await withTxBudget(
    prisma,
    scope.tenantId,
    'read',
    (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "MAIN_BOOK" AS main FROM "BOOK_DATA"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        book,
      ),
  );
  const mainBook = String(rows[0]?.main ?? '')
    .trim()
    .toUpperCase();
  const target = TARGETS[mainBook];
  if (!target) throw new ZoomNoTargetError(`no screen opens books of ${mainBook || 'this book'}`);
  if ((mainBook === 'OPSTK' || mainBook === 'TAG OPENING') && vchNo.length === 1)
    throw new ZoomNoTargetError('a one-character opening voucher has no form');
  return { target: { ...target, coBook: book, vchNo, lcCode: scope.lcCode, mainBook } };
}

/**
 * The route handler both report screens share (`GET /reports/<report>/zoom?bookCode=&vchNo=`): 404 when the row's book
 * has no screen, 403 "You Have No Rights..." (RP_TAG.cs:8943) without the target menu's View right, else the target.
 */
export function zoomHandler(h: {
  prisma: any;
  scopeOf: (req: any) => { tenantId: string; coCode: string; lcCode: string };
  mayRead: (req: any, form: string) => Promise<boolean>;
  disableWhenMerged?: boolean;
}) {
  return async (req: any, reply: any) => {
    const query = (req.query ?? {}) as Record<string, unknown>;
    if (h.disableWhenMerged) {
      const scope = h.scopeOf(req);
      const [settings]: Array<{ merge: string | null }> = await withTxBudget(
        h.prisma,
        scope.tenantId,
        'read',
        (tx: any) =>
          tx.$queryRawUnsafe(
            `SELECT "CO_STK_MERGE" AS merge FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
            scope.tenantId,
            scope.coCode,
          ),
      );
      // RP_HUID.cs:2254-2257: merged stock has no voucher zoom.
      if (settings?.merge?.trim() === 'Y') return reply.code(404).send({ error: 'no-zoom-target' });
    }
    let answer: ZoomAnswer;
    try {
      answer = await resolveZoom(h.prisma, h.scopeOf(req), {
        book: String(query.bookCode ?? ''),
        vchNo: String(query.vchNo ?? ''),
      });
    } catch (error) {
      if (error instanceof ZoomNoTargetError)
        return reply.code(404).send({ error: 'no-zoom-target', message: error.message });
      throw error;
    }
    if (!(await h.mayRead(req, answer.target.form)))
      return reply
        .code(403)
        .send({ error: 'forbidden', message: 'You Have No Rights...', form: answer.target.form });
    return reply.send(answer.target);
  };
}

/** Shared target View check. Report access alone never grants access to the source voucher. */
export function voucherZoomAuthorizer(prisma: any, session: (req: any) => any) {
  return async (req: any, form: string): Promise<boolean> => {
    const s = session(req);
    const principal = await loadPrincipal(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      loginCoCode: s.loginCoCode,
      loginName: s.sub,
    });
    try {
      await authorizeForm(prisma, {
        tenantId: s.tenantId,
        lcCode: s.lcCode,
        principal,
        form,
        action: 'read',
      });
      return true;
    } catch (error) {
      if (error instanceof FormForbiddenError) return false;
      throw error;
    }
  };
}
