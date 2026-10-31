import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  deletePartyOpening,
  getPartyOpening,
  listPartyOpenings,
  savePartyOpening,
  type OpeningBalanceType,
} from '../modules/finance/partyOpening.js';

/**
 * Party Opening (TR_AC_OPBL): the opening list, one party's opening, save and delete. The Party master's inline opening
 * keeps its `/accounts/:acCode/opening` paths and goes through the same module, so every opening writes OP_DATA in
 * book '000' and its AcOp_Ledr ledger legs. Moved out of routes/txn.ts with the rework.
 */
export function registerPartyOpeningRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'guard' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear ?? '' };
  };
  const acCodeOf = (req: FastifyRequest) => String((req.params as any).acCode ?? '');
  const headsOf = (b: Record<string, any>) => ({
    amount: b.amount,
    sign: b.sign,
    gold: b.gold,
    goldSign: b.goldSign,
    silver: b.silver,
    silverSign: b.silverSign,
  });

  app.get('/ac-opbl', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const balanceType = String((req.query as any)?.balanceType ?? 'amount') as OpeningBalanceType;
    return run(reply, 200, () => listPartyOpenings(prisma, scope(req), balanceType));
  });
  app.get('/ac-opbl/:acCode', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getPartyOpening(prisma, scope(req), acCodeOf(req)));
  });
  app.post('/ac-opbl', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 200, () =>
      savePartyOpening(prisma, {
        scope: scope(req),
        acCode: String(b.acCode ?? ''),
        mainUser: mainUserOf(req),
        ...headsOf(b),
      }),
    );
  });
  app.delete('/ac-opbl/:acCode', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const out = await run(reply, 200, () =>
      deletePartyOpening(prisma, scope(req), acCodeOf(req), mainUserOf(req)),
    );
    return out;
  });

  // The Party master's inline opening (MS_ACCT) and the Opening Balance page.
  app.get('/accounts/:acCode/opening', auth as any, async (req, reply) =>
    run(reply, 200, () => getPartyOpening(prisma, scope(req), acCodeOf(req))),
  );
  app.post('/accounts/:acCode/opening', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      savePartyOpening(prisma, {
        scope: scope(req),
        acCode: acCodeOf(req),
        mainUser: mainUserOf(req),
        ...headsOf(b),
      }),
    );
  });
}
