import { z } from 'zod';

/**
 * The active scope every transactional query is bound to (Req 5.2/5.3).
 * `tenantId` is the SaaS partition (RLS); the rest are the desktop composite keys
 * (CO_CODE, LC_CODE, CO_YEAR, CO_BOOK) preserved for parity. Order per data-model.json.
 */
export const TenantScope = z.object({
  tenantId: z.string().min(1),
  coCode: z.string().length(2), // CO_CODE
  lcCode: z.string().length(2), // LC_CODE
  coYear: z.string().min(1), // CO_YEAR
  coBook: z.string().max(3).optional(), // CO_BOOK (book-scoped ops only)
});
export type TenantScope = z.infer<typeof TenantScope>;

/** User-right flags resolved at login (Req 6.3). */
export const UserRights = z.object({
  userUpdate: z.boolean(),
  userDelete: z.boolean(),
  userPrint: z.boolean(),
});
export type UserRights = z.infer<typeof UserRights>;
