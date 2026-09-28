import { createHash } from 'node:crypto';
import type { Tx } from '@datacare/db';

/** Internal prerequisite for DC_Main.MsAcBal1463–1487. This reader does not
 * authenticate a mode, initialize a session, expose a route or authorize a
 * known Return balance. A future caller must resolve live mode authority in
 * this same transaction before supplying these semantic inputs. */
export const DESKTOP_ACCOUNT_BALANCE_VERSION = 'desktop-ms-ac-bal-observation-v1' as const;
export const DESKTOP_ACCOUNT_BALANCE_PROFILE = 'canonical-postgresql-fixed-decimal-v1' as const;
export interface DesktopAccountBalanceInput {
  scope: { tenantId: string; coCode: string; lcCode: string; coYear: string };
  accountCode: string;
  cutoffLocalSecond: string;
  mode: 'A' | 'B' | 'C';
}
export class DesktopAccountBalanceInputError extends Error {
  readonly statusCode = 400;
  constructor(
    public readonly code: 'invalid-input' | 'invalid-transaction-context',
    message: string,
  ) {
    super(message);
    this.name = 'DesktopAccountBalanceInputError';
  }
}
export interface DesktopAccountBalanceDiagnostic {
  code: string;
  field?: string;
  physicalId?: string;
  message: string;
}
export interface DesktopAccountBalanceObservedRow {
  raw: Record<string, string | null>;
  physicalId: string;
  revision: string;
  locator: string;
  entryTimeLocal: string;
}
export interface DesktopAccountBalanceRawGroup {
  accountCode: string;
  eligibleRows: string;
  amount: string | null;
  gold: string | null;
  silver: string | null;
}
export interface DesktopAccountBalancePhase {
  groupPresent: boolean;
  eligibleRows: string;
  amount: string | null;
  gold: string | null;
  silver: string | null;
}
export interface DesktopAccountBalanceObservation extends DesktopAccountBalanceInput {
  version: typeof DESKTOP_ACCOUNT_BALANCE_VERSION;
  profile: typeof DESKTOP_ACCOUNT_BALANCE_PROFILE;
  status: 'ready' | 'unsupported';
  observationVersion: string;
  observations: DesktopAccountBalanceObservedRow[];
  rawGroups: {
    opening: DesktopAccountBalanceRawGroup[];
    helperClosing: DesktopAccountBalanceRawGroup[];
  };
  opening: DesktopAccountBalancePhase;
  helperClosing: DesktopAccountBalancePhase;
  diagnostics: DesktopAccountBalanceDiagnostic[];
}

function plain(value: unknown): value is Record<string, unknown> {
  if (!value || typeof value !== 'object' || Array.isArray(value)) return false;
  const prototype = Object.getPrototypeOf(value);
  return prototype === Object.prototype || prototype === null;
}
function exact(value: unknown, keys: readonly string[]): value is Record<string, unknown> {
  if (!plain(value)) return false;
  const own = Reflect.ownKeys(value);
  return (
    own.length === keys.length &&
    own.every((key) => typeof key === 'string' && keys.includes(key)) &&
    own.every((key) => Object.hasOwn(Object.getOwnPropertyDescriptor(value, key)!, 'value'))
  );
}
function keyText(value: unknown, max: number, uppercase = true): value is string {
  return (
    typeof value === 'string' &&
    value.length > 0 &&
    value.length <= max &&
    !/[^\x20-\x7e]/.test(value) &&
    value.trim() === value &&
    (!uppercase || value.toUpperCase() === value)
  );
}
/** Calendar validation uses bounded date components only, never JavaScript Date
 * or timezone conversion. The caller must already have qualified the source
 * date-plus-clock/whole-second cutoff; this function never truncates a clock. */
function localSecond(value: unknown): value is string {
  if (typeof value !== 'string' || value.length !== 19) return false;
  const match = /^(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})$/.exec(value);
  if (!match) return false;
  const [year, month, day, hour, minute, second] = match.slice(1).map(Number);
  if (!year || !month || !day || month > 12 || hour! > 23 || minute! > 59 || second! > 59)
    return false;
  const leap = year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
  const days = [31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
  return day <= days[month - 1]!;
}
function inputValue(value: unknown): DesktopAccountBalanceInput {
  if (
    !exact(value, ['scope', 'accountCode', 'cutoffLocalSecond', 'mode']) ||
    !exact(value.scope, ['tenantId', 'coCode', 'lcCode', 'coYear']) ||
    !keyText(value.scope.tenantId, 24, false) ||
    !keyText(value.scope.coCode, 2) ||
    !keyText(value.scope.lcCode, 2) ||
    !keyText(value.scope.coYear, 10) ||
    !keyText(value.accountCode, 8) ||
    !localSecond(value.cutoffLocalSecond) ||
    !['A', 'B', 'C'].includes(value.mode as string)
  )
    throw new DesktopAccountBalanceInputError(
      'invalid-input',
      'Use an exact internal scope, canonical account, qualified local whole-second cutoff and resolved A/B/C mode.',
    );
  return {
    scope: {
      tenantId: value.scope.tenantId,
      coCode: value.scope.coCode,
      lcCode: value.scope.lcCode,
      coYear: value.scope.coYear,
    },
    accountCode: value.accountCode,
    cutoffLocalSecond: value.cutoffLocalSecond,
    mode: value.mode as DesktopAccountBalanceInput['mode'],
  };
}
function canonical(value: unknown): string {
  if (Array.isArray(value)) return '[' + value.map(canonical).join(',') + ']';
  if (plain(value))
    return (
      '{' +
      Object.keys(value)
        .sort()
        .map((key) => JSON.stringify(key) + ':' + canonical(value[key]))
        .join(',') +
      '}'
    );
  return JSON.stringify(value) ?? 'null';
}
function freeze<T>(value: T): T {
  if (value && typeof value === 'object') {
    Object.values(value).forEach(freeze);
    Object.freeze(value);
  }
  return value;
}

// One materialized observation supplies both groups and the complete physical
// dependency set. There is intentionally no book, voucher, VCH_DATE or LIMIT.
// Normalized discovery exposes aliases without claiming SQL Server collation.
const statement = `WITH candidates AS MATERIALIZED (
 SELECT t.*,t.row_id::text AS physical_id,t.xmin::text AS revision,t.ctid::text AS locator,
   (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id') e) AS raw
 FROM "AC_DATA" t
 WHERE t.tenant_id=$1 AND upper(btrim(t."CO_CODE"))=$2 AND upper(btrim(t."LC_CODE"))=$3
   AND upper(btrim(t."CO_YEAR"))=$4 AND upper(btrim(t."AC_CODE"))=$5
   AND t."ENTRY_TIME"<=$6::timestamp
   AND ($7='C' OR upper(btrim(t."DATA_TYPE"))=$7)
), eligible AS MATERIALIZED (
 SELECT * FROM candidates WHERE "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "AC_CODE"=$5
   AND ($7='C' OR "DATA_TYPE"=$7)
), groups AS (
 SELECT boundary,"AC_CODE" AS account_code,count(*)::text AS eligible_rows,
   SUM("CR_AMT"-"DR_AMT")::text AS amount,
   SUM(CASE WHEN "IT_TYPE"='G' THEN CASE WHEN "SIGN"='+' THEN "FINE_WT" ELSE -"FINE_WT" END ELSE 0 END)::text AS gold,
   SUM(CASE WHEN "IT_TYPE"='S' THEN CASE WHEN "SIGN"='+' THEN "FINE_WT" ELSE -"FINE_WT" END ELSE 0 END)::text AS silver
 FROM eligible CROSS JOIN (VALUES ('opening'),('helperClosing')) bounds(boundary)
 WHERE boundary='helperClosing' OR "ENTRY_TIME"<$6::timestamp
 GROUP BY boundary,"AC_CODE"
)
SELECT current_setting('app.tenant_id',true) AS tenant,
 current_setting('transaction_isolation') AS isolation,
 COALESCE((SELECT jsonb_agg(jsonb_build_object('raw',raw,'physicalId',physical_id,'revision',revision,
   'locator',locator,'entryTimeLocal',to_char("ENTRY_TIME",'YYYY-MM-DD HH24:MI:SS.US')) ORDER BY row_id) FROM candidates),'[]'::jsonb) AS observations,
 COALESCE((SELECT jsonb_agg(jsonb_build_object('accountCode',account_code,'eligibleRows',eligible_rows,
   'amount',amount,'gold',gold,'silver',silver)) FROM groups WHERE boundary='opening'),'[]'::jsonb) AS opening,
 COALESCE((SELECT jsonb_agg(jsonb_build_object('accountCode',account_code,'eligibleRows',eligible_rows,
   'amount',amount,'gold',gold,'silver',silver)) FROM groups WHERE boundary='helperClosing'),'[]'::jsonb) AS closing`;

/** Exact fixed-scale formatting for current PostgreSQL numeric(18,2)/(14,3)
 * aggregate output. No Double emulation or arbitrary numeric rounding occurs. */
function fixed(value: string | null, scale: 2 | 3): string | null {
  if (typeof value !== 'string' || /[^\x20-\x7e]/.test(value)) return null;
  const match = /^(-?)(0|[1-9]\d*)(?:\.(\d+))?$/.exec(value);
  if (!match || (match[3]?.length ?? 0) > scale || match[2]!.length > 36) return null;
  const digits = (match[2]! + (match[3] ?? '')).replace(/^0+/, '');
  if (digits.length > 36) return null;
  const negative = match[1] && /[1-9]/.test(digits) ? '-' : '';
  return negative + match[2] + '.' + (match[3] ?? '').padEnd(scale, '0');
}
function phase(
  name: 'opening' | 'helperClosing',
  groups: DesktopAccountBalanceRawGroup[],
  diagnostics: DesktopAccountBalanceDiagnostic[],
): DesktopAccountBalancePhase {
  if (groups.length === 0)
    return {
      groupPresent: false,
      eligibleRows: '0',
      amount: '0.00',
      gold: '0.000',
      silver: '0.000',
    };
  const group = groups[0]!;
  const result: DesktopAccountBalancePhase = {
    groupPresent: true,
    eligibleRows: group.eligibleRows,
    amount: null,
    gold: null,
    silver: null,
  };
  for (const field of ['amount', 'gold', 'silver'] as const) {
    result[field] = fixed(group[field], field === 'amount' ? 2 : 3);
    if (result[field] === null)
      diagnostics.push({
        code: group[field] === null ? 'null-group-sum' : 'unsupported-numeric-sum',
        field: `${name}.${field}`,
        message: `The ${name} ${field} aggregate has no supported complete source-helper conversion.`,
      });
  }
  return result;
}

export async function observeDesktopAccountBalanceTx(
  tx: Tx,
  value: unknown,
): Promise<DesktopAccountBalanceObservation> {
  const input = inputValue(value);
  const rows = await tx.$queryRawUnsafe<
    Array<{
      tenant: string | null;
      isolation: string;
      observations: DesktopAccountBalanceObservedRow[];
      opening: DesktopAccountBalanceRawGroup[];
      closing: DesktopAccountBalanceRawGroup[];
    }>
  >(
    statement,
    input.scope.tenantId,
    input.scope.coCode,
    input.scope.lcCode,
    input.scope.coYear,
    input.accountCode,
    input.cutoffLocalSecond,
    input.mode,
  );
  const observed = rows[0];
  if (
    !observed ||
    observed.tenant !== input.scope.tenantId ||
    !['repeatable read', 'serializable'].includes(observed.isolation)
  )
    throw new DesktopAccountBalanceInputError(
      'invalid-transaction-context',
      'A matching tenant-bound RepeatableRead or Serializable transaction is required.',
    );
  const diagnostics: DesktopAccountBalanceDiagnostic[] = [];
  for (const row of observed.observations) {
    for (const [field, expected] of Object.entries({
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear,
      AC_CODE: input.accountCode,
      ...(input.mode === 'C' ? {} : { DATA_TYPE: input.mode }),
    }))
      if (row.raw[field] !== expected)
        diagnostics.push({
          code: 'noncanonical-ledger-key',
          field,
          physicalId: row.physicalId,
          message: `An eligible ${field} alias needs source collation qualification.`,
        });
    const type = row.raw.IT_TYPE;
    const sign = row.raw.SIGN;
    if (
      (type !== null &&
        type !== undefined &&
        (/[^\x20-\x7e]/.test(type) || ['g', 's'].includes(type))) ||
      (sign !== null && sign !== undefined && /[^\x20-\x7e]/.test(sign))
    )
      diagnostics.push({
        code: 'noncanonical-comparison-text',
        physicalId: row.physicalId,
        message: 'An eligible metal/sign comparison is outside the canonical source profile.',
      });
    const stamp = row.raw.ENTRY_TIME;
    if (
      typeof stamp !== 'string' ||
      !/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d{1,6})?$/.test(stamp) ||
      !localSecond(stamp.slice(0, 19).replace('T', ' '))
    )
      diagnostics.push({
        code: 'unsupported-entry-time',
        physicalId: row.physicalId,
        message: 'An eligible entry clock is outside the qualified local timestamp profile.',
      });
  }
  const invalidObservation = diagnostics.length > 0;
  const opening = phase('opening', observed.opening, diagnostics);
  const helperClosing = phase('helperClosing', observed.closing, diagnostics);
  if (invalidObservation)
    for (const current of [opening, helperClosing])
      current.amount = current.gold = current.silver = null;
  const rawGroups = { opening: observed.opening, helperClosing: observed.closing };
  const identity = {
    version: DESKTOP_ACCOUNT_BALANCE_VERSION,
    profile: DESKTOP_ACCOUNT_BALANCE_PROFILE,
    ...input,
    observations: observed.observations,
    rawGroups,
  };
  return freeze({
    ...identity,
    status: diagnostics.length ? 'unsupported' : 'ready',
    observationVersion: createHash('sha256').update(canonical(identity)).digest('hex'),
    opening,
    helperClosing,
    diagnostics,
  });
}
