/**
 * Query scoping (Req 5.2/5.3). Every transactional query is filtered by the active
 * Company/Location/Year/Book composite key (in addition to RLS tenant_id partitioning).
 */
export interface Scope {
  coCode: string; // CO_CODE
  lcCode?: string; // LC_CODE
  coYear?: string; // CO_YEAR
  coBook?: string; // CO_BOOK (book-scoped operations only)
}

/** Build a Prisma `where` fragment from the active scope (only the provided keys). */
export function buildScopeWhere(scope: Scope): Record<string, string> {
  const where: Record<string, string> = { CO_CODE: scope.coCode };
  if (scope.lcCode !== undefined) where.LC_CODE = scope.lcCode;
  if (scope.coYear !== undefined) where.CO_YEAR = scope.coYear;
  if (scope.coBook !== undefined) where.CO_BOOK = scope.coBook;
  return where;
}
