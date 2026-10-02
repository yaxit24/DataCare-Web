/**
 * Extract the PostgreSQL SQLSTATE codes carried by a Prisma error, across Prisma 6 and Prisma 7 shapes.
 *
 * Prisma 6 (Rust engine) put the SQLSTATE on `error.meta.code` for a raw-query failure (P2010).
 * Prisma 7 (driver adapter) nests it under `error.meta.driverAdapterError.cause`, as `originalCode` and
 * sometimes `code`. Business code that classifies a failure as a serialisation conflict, deadlock or
 * timeout must read both, or a conflict that was a 409 under Prisma 6 silently becomes an opaque 500.
 *
 * N86 (D26): the Prisma 7 upgrade changed where these codes live; this is the single place that knows it.
 */
export function postgresErrorCodes(error: unknown): Set<string> {
  const codes = new Set<string>();
  for (let current: unknown = error, depth = 0; current && depth < 6; depth += 1) {
    const node = current as {
      code?: unknown;
      kind?: unknown;
      originalCode?: unknown;
      cause?: unknown;
      meta?: {
        code?: unknown;
        driverAdapterError?: { cause?: { code?: unknown; originalCode?: unknown } };
      };
    };
    if (typeof node.code === 'string') codes.add(node.code);
    // An unwrapped DriverAdapterError (e.g. a commit-time SSI write-skew) carries the SQLSTATE on its own
    // cause as `originalCode`, and the conflict kind as `kind`.
    if (typeof node.originalCode === 'string') codes.add(node.originalCode);
    if (node.kind === 'TransactionWriteConflict') codes.add('40001');
    const meta = node.meta;
    if (meta) {
      if (typeof meta.code === 'string') codes.add(meta.code);
      const cause = meta.driverAdapterError?.cause;
      if (cause) {
        if (typeof cause.code === 'string') codes.add(cause.code);
        if (typeof cause.originalCode === 'string') codes.add(cause.originalCode);
      }
    }
    current = node.cause;
  }
  return codes;
}

/** True when the error carries any of the given SQLSTATE/Prisma codes, in either Prisma 6 or 7 shape. */
export function hasPostgresErrorCode(error: unknown, ...wanted: string[]): boolean {
  const codes = postgresErrorCodes(error);
  return wanted.some((code) => codes.has(code));
}
