import { createHash } from 'node:crypto';
import type { Tx } from '@datacare/db';
import {
  SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION,
  type SaleReturnIncomingLabourObservation,
  type SaleReturnIncomingLabourMaster,
  type SaleReturnIncomingLabourScope,
} from '@datacare/core';

export interface SaleReturnIncomingLabourReadInput {
  readonly scope: SaleReturnIncomingLabourScope;
  readonly enteredCode: string;
}
export class SaleReturnIncomingLabourReadError extends Error {
  constructor(
    readonly code: 'invalid-input' | 'invalid-transaction-context' | 'invalid-observation',
    message: string,
  ) {
    super(message);
    this.name = 'SaleReturnIncomingLabourReadError';
  }
}
function exact(value: unknown, keys: readonly string[]): value is Record<string, unknown> {
  if (!value || typeof value !== 'object' || Array.isArray(value)) return false;
  const proto = Object.getPrototypeOf(value);
  if (proto !== Object.prototype && proto !== null) return false;
  const own = Reflect.ownKeys(value);
  return (
    own.length === keys.length &&
    own.every(
      (key) =>
        typeof key === 'string' &&
        keys.includes(key) &&
        Object.hasOwn(Object.getOwnPropertyDescriptor(value, key)!, 'value'),
    )
  );
}
function keyText(value: unknown, max: number): value is string {
  return (
    typeof value === 'string' &&
    value.length > 0 &&
    value.length <= max &&
    !/[^\x20-\x7e]/.test(value) &&
    value.trim() === value
  );
}
function readInput(value: unknown): SaleReturnIncomingLabourReadInput {
  if (
    !exact(value, ['scope', 'enteredCode']) ||
    !exact(value.scope, ['tenantId', 'coCode']) ||
    !keyText(value.scope.tenantId, 24) ||
    !keyText(value.scope.coCode, 2) ||
    !keyText(value.enteredCode, 2)
  )
    throw new SaleReturnIncomingLabourReadError(
      'invalid-input',
      'An exact tenant/company and unpadded nonblank ASCII code of at most two characters are required.',
    );
  return {
    scope: { tenantId: value.scope.tenantId, coCode: value.scope.coCode },
    enteredCode: value.enteredCode,
  };
}
function canonical(value: unknown): string {
  if (Array.isArray(value)) return '[' + value.map(canonical).join(',') + ']';
  if (value && typeof value === 'object') {
    const record = value as Record<string, unknown>;
    return (
      '{' +
      Object.keys(record)
        .sort()
        .map((key) => JSON.stringify(key) + ':' + canonical(record[key]))
        .join(',') +
      '}'
    );
  }
  return JSON.stringify(value) ?? 'null';
}
function freeze<T>(value: T): T {
  if (value && typeof value === 'object') {
    Object.values(value).forEach(freeze);
    Object.freeze(value);
  }
  return value;
}

/** One SQL statement observes every relevant current PostgreSQL case/ASCII-space
 * candidate, including raw NULL/Float text and the full tenant/company/code PK.
 * There is no LIMIT, fallback company, numeric cast through JS, write or lock.
 * This discovery does not establish every SQL Server collation equivalence. */
const statement = `SELECT current_setting('app.tenant_id',true) AS tenant,
 current_setting('transaction_isolation') AS isolation,
 COALESCE((SELECT jsonb_agg(jsonb_build_object(
   'raw',(SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)) e),
   'revision',t.xmin::text,'locator',t.ctid::text)
   ORDER BY t."CO_CODE" COLLATE "C",t."LBR_CODE" COLLATE "C",t.ctid)
 FROM "LBR_MAST" t WHERE t.tenant_id=$1
   AND upper(btrim(t."CO_CODE"))=upper(btrim($2::text))
   AND upper(btrim(t."LBR_CODE"))=upper(btrim($3::text))), '[]'::jsonb) AS masters`;

/** Internal prerequisite only. Caller owns a tenant-bound RepeatableRead or
 * Serializable transaction and must bind document, configuration and live
 * session authority in that same operation before any future copy/replay.
 * The returned hash covers this extant master observation only. It is not a
 * bearer capability or durable absence-cycle/restore revision. */
export async function readSaleReturnIncomingLabourTx(
  tx: Tx,
  value: unknown,
): Promise<SaleReturnIncomingLabourObservation> {
  let input: SaleReturnIncomingLabourReadInput;
  try {
    input = readInput(value);
  } catch (error) {
    if (error instanceof SaleReturnIncomingLabourReadError) throw error;
    throw new SaleReturnIncomingLabourReadError(
      'invalid-input',
      'A plain internal read input is required.',
    );
  }
  const rows = await tx.$queryRawUnsafe<
    Array<{ tenant: string | null; isolation: string; masters: SaleReturnIncomingLabourMaster[] }>
  >(statement, input.scope.tenantId, input.scope.coCode, input.enteredCode);
  if (
    !Array.isArray(rows) ||
    rows.length !== 1 ||
    rows[0]!.tenant !== input.scope.tenantId ||
    !['repeatable read', 'serializable'].includes(rows[0]!.isolation)
  )
    throw new SaleReturnIncomingLabourReadError(
      'invalid-transaction-context',
      'Use the matching tenant-bound RepeatableRead or Serializable caller transaction.',
    );
  const masters = rows[0]!.masters;
  if (
    !Array.isArray(masters) ||
    !masters.every(
      (row) =>
        exact(row, ['raw', 'revision', 'locator']) &&
        row.raw &&
        typeof row.raw === 'object' &&
        !Array.isArray(row.raw) &&
        Object.values(row.raw).every((cell) => cell === null || typeof cell === 'string') &&
        row.raw.tenant_id === input.scope.tenantId &&
        ['CO_CODE', 'LBR_CODE', 'LBR_CATG', 'LBR_VAL'].every((key) =>
          Object.hasOwn(row.raw, key),
        ) &&
        typeof row.revision === 'string' &&
        row.revision.length > 0 &&
        !/[^0-9]/.test(row.revision) &&
        typeof row.locator === 'string' &&
        !/[^\x20-\x7e]/.test(row.locator) &&
        /^\([0-9]+,[0-9]+\)$/.test(row.locator),
    )
  )
    throw new SaleReturnIncomingLabourReadError(
      'invalid-observation',
      'The complete raw physical labour-master observation is unavailable.',
    );
  const detached = masters.map((row) => ({
    raw: { ...row.raw },
    revision: row.revision,
    locator: row.locator,
  }));
  detached.sort((a, b) => {
    const x = canonical(a);
    const y = canonical(b);
    return x < y ? -1 : x > y ? 1 : 0;
  });
  const observation = {
    version: SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION,
    scope: input.scope,
    enteredCode: input.enteredCode,
    complete: true as const,
    masters: detached,
  };
  return freeze({
    ...observation,
    observationVersion: createHash('sha256').update(canonical(observation)).digest('hex'),
  });
}
