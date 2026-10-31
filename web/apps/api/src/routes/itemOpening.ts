import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  deleteItemOpening,
  getItemOpening,
  saveItemOpening,
} from '../modules/stock/itemOpening.js';
import { requiredVersion } from '../modules/vouchers/version.js';

/** The rights row the screen and its routes share (routePolicy 'Inventory/Item Opening (non-tag)'). */
const FORM = 'Inventory/Item Opening (non-tag)';

/**
 * Item Opening (TR_ITM_OPBL): one grid per metal type in book '000', the type letter as voucher number. Read, save
 * and delete by type, plus the user's rights: TR_ITM_OPBL_Load reads FRM_EDIT, FRM_DELETE and FRM_PRINT
 * (TR_ITM_OPBL.cs:1061-1063) so the buttons can answer with the desktop text, and Print has no route of its own. The
 * save and delete routes enforce the same rights. The older numbered-voucher routes (`/stock/item-opening` POST and
 * `/:vchNo`) stay for the vouchers they wrote; the screen no longer uses them.
 */
export function registerItemOpeningRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'guard' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'>,
  capabilities: (
    req: FastifyRequest,
    form: string,
  ) => Promise<{ canUpdate: boolean; canDelete: boolean; canPrint: boolean }>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear ?? '' };
  };
  const typeOf = (req: FastifyRequest) => String((req.params as any).type ?? '');

  app.get('/stock/item-opening/rights', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => capabilities(req, FORM));
  });
  app.get('/stock/item-opening/type/:type', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getItemOpening(prisma, scope(req), typeOf(req)));
  });
  app.put('/stock/item-opening/type/:type', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveItemOpening(prisma, {
        scope: scope(req),
        type: typeOf(req),
        rows: b.rows,
        expectedVersion: requiredVersion(b.expectedVersion),
        mainUser: mainUserOf(req),
      }),
    );
  });
  app.delete('/stock/item-opening/type/:type', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteItemOpening(
        prisma,
        scope(req),
        typeOf(req),
        requiredVersion((req.query as any)?.expectedVersion),
      ),
    );
  });
}
