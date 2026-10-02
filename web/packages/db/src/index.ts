/**
 * @datacare/db — PostgreSQL data layer.
 * schema.prisma (Task 7) + scoped data-access (Task 9). Repository helpers grow per module.
 */
export const DB_PACKAGE = '@datacare/db';
export { buildScopeWhere } from './scope.js';
export type { Scope } from './scope.js';
export { PrismaClient, prismaConnectionString } from './client.js';
export type { DataCarePrismaClientOptions } from './client.js';
export { Prisma } from './generated/prisma/client.js';
export { withTenant, atomic } from './tenant.js';
export type { Tx } from './tenant.js';
