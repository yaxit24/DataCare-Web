import type { FastifyInstance } from 'fastify';
import { withTxBudget } from '../modules/shared/txBudget.js';
import { getUrdBookSettingsTx, saveUrdBookSettingsTx } from '../modules/purchase/urdBook.js';
import type { CrmRouteHelpers } from './crm.js';

/**
 * Settings → Old gold purchase books: the per-company Gold / Silver URD purchase book (owner decision 2B; the desktop
 * hardcodes 043/044, TR_SALE.cs:18756-18842). Same rights as the company settings screen (Utilities/Settings).
 */
export function registerUrdBookSettingsRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'guard' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  app.get('/settings/urd-books', auth as any, async (req, reply) => {
    const scope = scopeOf(req);
    return run(reply, 200, () =>
      withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => getUrdBookSettingsTx(tx, scope)),
    );
  });
  app.post('/settings/urd-books', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const scope = scopeOf(req);
    const b = body(req);
    return run(reply, 200, () =>
      withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
        await saveUrdBookSettingsTx(tx, scope, b, mainUserOf(req));
        return getUrdBookSettingsTx(tx, scope);
      }),
    );
  });
}
