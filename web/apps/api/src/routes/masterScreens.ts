import type { FastifyInstance } from 'fastify';
import { registerAddressMasterRoutes } from './addressMaster.js';
import { registerItemMasterRoutes } from './itemMaster.js';
import { registerPartyMasterRoutes } from './partyMaster.js';

type Helpers = Parameters<typeof registerPartyMasterRoutes>[1];
type Capabilities = Parameters<typeof registerPartyMasterRoutes>[2];

/**
 * The Address (MS_ADD_MAST), Item (MS_ITEM) and Party (MS_ACCT) master screens' routes. They share the route helpers
 * and the form-capability reader of routes/txn.ts, so txn.ts registers them in one call.
 */
export function registerMasterScreenRoutes(
  app: FastifyInstance,
  helpers: Helpers,
  capabilities: Capabilities,
): void {
  registerAddressMasterRoutes(app, helpers, capabilities);
  registerItemMasterRoutes(app, helpers, capabilities);
  registerPartyMasterRoutes(app, helpers, capabilities);
}
