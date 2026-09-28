import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import { resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { assertPeriodOpen } from '../posting/posting.js';
import { formatVoucherNo } from '../vouchers/numbering.js';

/** TR_SALE_RTN MSG_PR metadata only. Never use the destructive legacy return writer here. */
export interface SavedSaleReturnScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}
export type SavedSaleReturnRaw = Record<string, string | null>;
export interface SavedSaleReturnFieldCapability {
  allowed: boolean;
  reason: string | null;
}
export interface SavedSaleReturnLineIdentity {
  srNo: string;
  oldSrNo: string | null;
  vchSrno: string | null;
  tagSrNo: string | null;
  itCode: string | null;
  tagNo: string | null;
}
export interface SavedSaleReturnMetadataPatch {
  version: string;
  header?: { employeeCode: string };
  lines?: Array<{
    identity: SavedSaleReturnLineIdentity;
    changes: { huid?: string; description?: string };
  }>;
}
export interface SavedSaleReturnIncoming {
  scope: SavedSaleReturnScope;
  voucherNo: string;
  version: string;
  header: {
    raw: SavedSaleReturnRaw;
    display: { employeeName: string | null; employeeNameReason: string | null };
    capabilities: { employeeCode: SavedSaleReturnFieldCapability };
  };
  lines: Array<{
    identity: SavedSaleReturnLineIdentity;
    raw: SavedSaleReturnRaw;
    display: { itemName: string | null; itemNameReason: string | null; description: string };
    capabilities: {
      huid: SavedSaleReturnFieldCapability;
      description: SavedSaleReturnFieldCapability;
    };
  }>;
  related: {
    outgoingLines: SavedSaleReturnRaw[];
    outgoingComponents: SavedSaleReturnRaw[];
    tagHeaders: SavedSaleReturnRaw[];
    tagParents: SavedSaleReturnRaw[];
    tagComponents: SavedSaleReturnRaw[];
  };
  provenance: {
    incomingLineCount: number;
    outgoingLineCount: number;
    outgoingComponentCount: number;
    tagHeaderCount: number;
    tagParentCount: number;
    tagComponentCount: number;
  };
  capabilities: { canUpdate: boolean; reason: string | null };
}
export interface SavedSaleReturnListRow {
  voucherNo: string;
  raw: SavedSaleReturnRaw;
  display: { customer: string; date: string; billNo: string };
}
export class SavedSaleReturnError extends Error {
  constructor(
    public readonly statusCode: 400 | 404 | 409 | 422,
    public readonly code: string,
    message: string,
  ) {
    super(message);
    this.name = 'SavedSaleReturnError';
  }
}

export type SavedSaleReturnObservedRow = {
  raw: SavedSaleReturnRaw;
  revision: string;
  locator: string;
  physicalId: string | null;
};
type ObservedRow = SavedSaleReturnObservedRow;
const TABLES = [
  'SL_DATA',
  'SL_DETL_RTN',
  'SL_DETL',
  'SL_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
] as const;
type Table = (typeof TABLES)[number];
const rawRows = (rows: ObservedRow[]): SavedSaleReturnRaw[] => rows.map((row) => row.raw);
const trimmed = (value: unknown): string => String(value ?? '').trim();
const permit = (reason: string | null): SavedSaleReturnFieldCapability => ({
  allowed: reason === null,
  reason,
});
const deny = (message: string): never => {
  throw new SavedSaleReturnError(400, 'invalid-input', message);
};
const canonical = (value: unknown): string => {
  if (Array.isArray(value)) return `[${value.map(canonical).join(',')}]`;
  if (value && typeof value === 'object') {
    return `{${Object.entries(value)
      .sort(([a], [b]) => a.localeCompare(b))
      .map(([key, v]) => `${JSON.stringify(key)}:${canonical(v)}`)
      .join(',')}}`;
  }
  return JSON.stringify(value) ?? 'null';
};
function scopeKey(
  scope: SavedSaleReturnScope,
  requestedVoucherNo?: string | number,
): string | undefined {
  for (const key of ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const) {
    if (
      typeof scope?.[key] !== 'string' ||
      !scope[key].trim() ||
      scope[key] !== scope[key].trim()
    ) {
      deny(`Complete explicit ${key} is required.`);
    }
  }
  if (requestedVoucherNo === undefined) return undefined;
  if (!/^\d{1,8}$/.test(String(requestedVoucherNo)))
    deny('A saved numeric voucher number is required.');
  return formatVoucherNo(requestedVoucherNo);
}
const params = (scope: SavedSaleReturnScope, voucherNo: string): unknown[] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];
const where =
  't.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6';
/** Convert each PostgreSQL scalar to text BEFORE the JSON driver can coerce a decimal or timestamp. */
const projection = `(SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id') e) AS raw,
  t.xmin::text AS revision,t.ctid::text AS locator,to_jsonb(t)->>'row_id' AS "physicalId"`;
async function observe(
  tx: any,
  table: Table,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  lock: boolean,
): Promise<ObservedRow[]> {
  const rows: ObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${projection} FROM "${table}" t WHERE ${where}${lock ? ' FOR UPDATE OF t' : ''}`,
    ...params(scope, voucherNo),
  );
  return rows.sort((a, b) => canonical(a).localeCompare(canonical(b)));
}
function identity(raw: SavedSaleReturnRaw): SavedSaleReturnLineIdentity {
  return {
    srNo: raw.SR_NO ?? '',
    oldSrNo: raw.OLD_SRNO ?? null,
    vchSrno: raw.VCH_SRNO ?? null,
    tagSrNo: raw.TAG_SRNO ?? null,
    itCode: raw.IT_CODE ?? null,
    tagNo: raw.TAG_NO ?? null,
  };
}
const tagged = (raw: SavedSaleReturnRaw): boolean => !['', 'N'].includes(trimmed(raw.TAG_NO));
const activeFlag = (value: unknown): boolean => !['', 'N'].includes(trimmed(value));

async function configured(tx: any, scope: SavedSaleReturnScope): Promise<void> {
  await resolveBookPolicyTx(tx, scope, 'SALES RETURN', {
    requireExplicitMainBook: true,
    expectedTable: 'SL_DATA',
  });
}
async function periodReason(
  tx: any,
  scope: SavedSaleReturnScope,
  header: SavedSaleReturnRaw,
): Promise<string | null> {
  // assertPeriodOpen returns early for an empty LOCK_DATE; validate saved business dates first.
  // This Date is only a calendar validator: raw DB dates and microsecond clocks are never rebuilt.
  const date = header.VCH_DATE;
  if (typeof date !== 'string' || !/^\d{4}-\d{2}-\d{2}$/.test(date)) {
    return 'The saved voucher date is not a supported YYYY-MM-DD calendar date.';
  }
  const calendar = new Date(`${date}T00:00:00.000Z`);
  if (Number.isNaN(calendar.getTime()) || calendar.toISOString().slice(0, 10) !== date) {
    return 'The saved voucher date is not a valid calendar date.';
  }
  try {
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: header.VCH_DATE }] },
    });
    return null;
  } catch (error: unknown) {
    if (error instanceof Error && /^PeriodLock/.test(error.name)) return error.message;
    throw error;
  }
}

export type SavedSaleReturnObservation = {
  dto: SavedSaleReturnIncoming;
  tables: Record<Table, ObservedRow[]>;
  settings: SavedSaleReturnRaw[];
  /** Domain/date restriction only; it is independent of an operator's form rights. */
  editReason: string | null;
};
async function snapshot(
  tx: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  lock: boolean,
): Promise<SavedSaleReturnObservation> {
  await configured(tx, scope);
  // Header first: the legacy edit/delete path locks this same row before any replacement.
  const headers = await observe(tx, 'SL_DATA', scope, voucherNo, lock);
  if (headers.length !== 1) {
    throw new SavedSaleReturnError(
      headers.length ? 422 : 404,
      headers.length ? 'unsupported-state' : 'not-found',
      headers.length
        ? 'The saved Return header is ambiguous.'
        : 'Saved Return not found in this scope.',
    );
  }
  const tables = { SL_DATA: headers } as Record<Table, ObservedRow[]>;
  for (const table of TABLES.slice(1))
    tables[table] = await observe(tx, table, scope, voucherNo, lock);
  const emptyIncomingReason = tables.SL_DETL_RTN.length
    ? null
    : 'The saved voucher has no incoming Return rows.';
  // A saved header can be inspected before/without any incoming rows. It grants
  // no metadata mutation authority: the locked writer retains its prior refusal.
  if (lock && emptyIncomingReason)
    throw new SavedSaleReturnError(422, 'unsupported-state', emptyIncomingReason);
  const header = headers[0]!.raw;
  const settingsRows: ObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${projection} FROM "CO_SET" t WHERE t.tenant_id=$1 AND t."CO_CODE"=$2${lock ? ' FOR SHARE OF t' : ''}`,
    scope.tenantId,
    scope.coCode,
  );
  const books: ObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${projection} FROM "BOOK_DATA" t WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_BOOK"=$4${lock ? ' FOR SHARE OF t' : ''}`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  const itemCodes = [...new Set(tables.SL_DETL_RTN.map((row) => trimmed(row.raw.IT_CODE)))];
  const itemNames: Array<{ code: string | null; name: string | null }> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE"::text AS code,"IT_NAME"::text AS name FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND btrim("IT_CODE"::text)=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    itemCodes,
  );
  const employeeNames: Array<{ name: string | null }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_NAME"::text AS name FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"::text=$3`,
    scope.tenantId,
    scope.coCode,
    header.EMP_CODE,
  );
  const lockReason = await periodReason(tx, scope, header);
  const globalReason =
    emptyIncomingReason ??
    lockReason ??
    (trimmed(header.USER_UPDATE) === 'N' ? 'This saved voucher does not permit editing.' : null);
  const incoming = rawRows(tables.SL_DETL_RTN).sort((a, b) => Number(a.SR_NO) - Number(b.SR_NO));
  const lineReason = (row: SavedSaleReturnRaw): string | null => {
    if (globalReason) return globalReason;
    if (!Number.isFinite(Number(row.SR_NO)) || Number(row.SR_NO) <= 0 || !trimmed(row.IT_CODE))
      return 'The saved incoming row identity is unsupported.';
    if (!['P', 'R'].includes(trimmed(row.ENTRY_TYPE)))
      return 'The saved incoming entry kind is not supported for metadata editing.';
    if (tagged(row))
      return 'Tagged Return metadata requires verified ownership and consumption of its admitted tag instance.';
    if (activeFlag(row.APR_ISU) || activeFlag(row.EMP_ISU))
      return 'Issued or approval-linked Return metadata cannot be edited in this workflow.';
    if (tables.BAR_DETL.length)
      return 'The return-owned tag companion requires a verified metadata mapping.';
    return null;
  };
  let employeeReason = globalReason;
  if (!employeeReason && (tables.SL_DETL.length || tables.SL_IDTL.length))
    employeeReason = 'Employee changes for an outgoing exchange leg are not implemented.';
  if (!employeeReason && incoming.some((row) => lineReason(row)))
    employeeReason = 'Employee changes require every incoming row to be eligible.';
  if (
    !employeeReason &&
    (tables.BAR_DETL.length || tables.BAR_IDTL.length || tables.BAR_DATA.length > 1)
  )
    employeeReason = 'Employee changes require an unambiguous supported Return companion.';
  if (!employeeReason && tables.BAR_DATA.some((row) => trimmed(row.raw.USER_UPDATE) === 'N'))
    employeeReason = 'The saved Return companion does not permit editing.';
  if (!employeeReason && tables.DM_DATA.length)
    employeeReason =
      'Employee effects on the saved diamond ledger require a separate source contract.';
  if (
    !employeeReason &&
    tables.BAR_DATA.some(
      ({ raw }) =>
        !header.VCH_DATE ||
        !header.VCH_TIME ||
        raw.VCH_DATE !== header.VCH_DATE ||
        raw.VCH_TIME !== header.VCH_TIME ||
        raw.EMP_CODE !== header.EMP_CODE ||
        raw.VCH_DESC !== header.VCH_DESC ||
        raw.STK_IT_CODE !== '',
    )
  ) {
    employeeReason = 'The saved Return header companion does not match the proven source metadata.';
  }
  if (!employeeReason && settingsRows.length !== 1)
    employeeReason = 'Employee configuration is missing or ambiguous.';
  const lines = incoming.map((row) => {
    const matchingItems = itemNames.filter((item) => trimmed(item.code) === trimmed(row.IT_CODE));
    const itemName = matchingItems.length === 1 ? matchingItems[0]!.name : null;
    const itemNameReason =
      matchingItems.length === 1
        ? null
        : matchingItems.length
          ? 'The saved item code matches multiple company item masters.'
          : 'The saved item was not found in the company item master.';
    const reason = lineReason(row);
    return {
      identity: identity(row),
      raw: row,
      display: {
        itemName,
        itemNameReason,
        description: row.ITM_REMARK ? row.ITM_REMARK : (itemName ?? ''),
      },
      capabilities: { huid: permit(reason), description: permit(reason) },
    };
  });
  const related = {
    outgoingLines: rawRows(tables.SL_DETL),
    outgoingComponents: rawRows(tables.SL_IDTL),
    tagHeaders: rawRows(tables.BAR_DATA),
    tagParents: rawRows(tables.BAR_DETL),
    tagComponents: rawRows(tables.BAR_IDTL),
  };
  const version = createHash('sha256')
    .update(
      canonical({
        format: 'saved-incoming-return-v1',
        scope,
        voucherNo,
        tables,
        settings: settingsRows.sort((a, b) => canonical(a).localeCompare(canonical(b))),
        books: books.sort((a, b) => canonical(a).localeCompare(canonical(b))),
      }),
    )
    .digest('hex');
  const canUpdate =
    employeeReason === null ||
    lines.some((row) => row.capabilities.huid.allowed || row.capabilities.description.allowed);
  return {
    tables,
    settings: rawRows(settingsRows),
    editReason: globalReason,
    dto: {
      scope: { ...scope },
      voucherNo,
      version,
      header: {
        raw: header,
        display: {
          employeeName:
            trimmed(header.EMP_CODE) && employeeNames.length === 1 ? employeeNames[0]!.name : null,
          employeeNameReason:
            !trimmed(header.EMP_CODE) || employeeNames.length === 1
              ? null
              : employeeNames.length
                ? 'The saved employee code matches multiple company employees.'
                : 'The saved employee was not found in the company employee master.',
        },
        capabilities: { employeeCode: permit(employeeReason) },
      },
      lines,
      related,
      provenance: {
        incomingLineCount: incoming.length,
        outgoingLineCount: related.outgoingLines.length,
        outgoingComponentCount: related.outgoingComponents.length,
        tagHeaderCount: related.tagHeaders.length,
        tagParentCount: related.tagParents.length,
        tagComponentCount: related.tagComponents.length,
      },
      capabilities: {
        canUpdate,
        reason: canUpdate
          ? null
          : (globalReason ?? lines[0]?.capabilities.huid.reason ?? employeeReason),
      },
    },
  };
}

/** Caller owns tenant binding and transaction isolation. No nested transaction or mutation.
 * Used to compose the saved document with effective configuration/projection inputs. */
export async function readSavedSaleReturnIncomingTx(
  tx: any,
  scope: SavedSaleReturnScope,
  requestedVoucherNo: string,
): Promise<SavedSaleReturnObservation> {
  const voucherNo = scopeKey(scope, requestedVoucherNo)!;
  return snapshot(tx, scope, voucherNo, false);
}

export async function getSavedSaleReturnIncoming(
  prisma: any,
  scope: SavedSaleReturnScope,
  requestedVoucherNo: string | number,
): Promise<SavedSaleReturnIncoming> {
  const voucherNo = scopeKey(scope, requestedVoucherNo)!;
  return withTenant(
    prisma,
    scope.tenantId,
    async (tx: any) => (await snapshot(tx, scope, voucherNo, false)).dto,
    { isolationLevel: 'RepeatableRead' },
  );
}
export async function listSavedSaleReturnIncoming(
  prisma: any,
  scope: SavedSaleReturnScope,
): Promise<{ rows: SavedSaleReturnListRow[] }> {
  scopeKey(scope);
  return withTenant(
    prisma,
    scope.tenantId,
    async (tx: any) => {
      await configured(tx, scope);
      const rows: ObservedRow[] = await tx.$queryRawUnsafe(
        `SELECT ${projection} FROM "SL_DATA" t WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5
       AND EXISTS (SELECT 1 FROM "SL_DETL_RTN" r WHERE r.tenant_id=t.tenant_id AND r."CO_CODE"=t."CO_CODE" AND r."LC_CODE"=t."LC_CODE" AND r."CO_YEAR"=t."CO_YEAR" AND r."CO_BOOK"=t."CO_BOOK" AND r."VCH_NO"=t."VCH_NO")
       ORDER BY t."VCH_DATE" DESC NULLS LAST,t."VCH_NO" DESC,t.row_id DESC LIMIT 100`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
      );
      return {
        rows: rows.map(({ raw }) => ({
          voucherNo: raw.VCH_NO ?? '',
          raw,
          display: {
            customer: raw.AC_NAME ?? raw.AC_CODE ?? '',
            date: raw.VCH_DATE ?? '',
            billNo: raw.BILL_NO ?? '',
          },
        })),
      };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}

function object(value: unknown, label: string): Record<string, unknown> {
  if (!value || typeof value !== 'object' || Array.isArray(value))
    deny(`${label} must be an object.`);
  return value as Record<string, unknown>;
}
function keys(value: Record<string, unknown>, allowed: string[], label: string): void {
  if (Object.keys(value).some((key) => !allowed.includes(key)))
    deny(`${label} contains unsupported fields.`);
}
function boundedText(value: unknown, maximum: number, label: string): asserts value is string {
  if (typeof value !== 'string' || [...value].length > maximum || value.includes('\u0000'))
    deny(`${label} must be text of at most ${maximum} characters.`);
}
function validatePatch(value: unknown): SavedSaleReturnMetadataPatch {
  const patch = object(value, 'Metadata patch');
  keys(patch, ['version', 'header', 'lines'], 'Metadata patch');
  if (typeof patch.version !== 'string' || !/^[a-f0-9]{64}$/.test(patch.version))
    deny('Reload the saved Return and submit its version.');
  let count = 0;
  if (Object.hasOwn(patch, 'header')) {
    const header = object(patch.header, 'Header patch');
    keys(header, ['employeeCode'], 'Header patch');
    if (!Object.hasOwn(header, 'employeeCode')) deny('An explicit employeeCode is required.');
    boundedText(header.employeeCode, 3, 'Employee code');
    count++;
  }
  if (Object.hasOwn(patch, 'lines')) {
    if (!Array.isArray(patch.lines) || patch.lines.length > 200)
      deny('At most 200 saved line patches are allowed.');
    const seen = new Set<string>();
    for (const candidate of patch.lines as unknown[]) {
      const line = object(candidate, 'Line patch');
      keys(line, ['identity', 'changes'], 'Line patch');
      const id = object(line.identity, 'Saved line identity');
      const identityKeys = ['srNo', 'oldSrNo', 'vchSrno', 'tagSrNo', 'itCode', 'tagNo'];
      keys(id, identityKeys, 'Saved line identity');
      if (
        identityKeys.some(
          (key) => !Object.hasOwn(id, key) || (id[key] !== null && typeof id[key] !== 'string'),
        )
      )
        deny('All saved identity fields are required as exact strings or null.');
      if (
        typeof id.srNo !== 'string' ||
        !id.srNo.trim() ||
        !Number.isFinite(Number(id.srNo)) ||
        Number(id.srNo) <= 0
      )
        deny('A finite positive saved SR_NO is required.');
      const srNo = id.srNo as string;
      if (seen.has(srNo)) deny('A saved row may appear only once in a metadata patch.');
      seen.add(srNo);
      const changes = object(line.changes, 'Line changes');
      keys(changes, ['huid', 'description'], 'Line changes');
      if (!Object.keys(changes).length) deny('An explicit line metadata change is required.');
      if (Object.hasOwn(changes, 'huid')) boundedText(changes.huid, 10, 'HUID');
      if (Object.hasOwn(changes, 'description'))
        boundedText(changes.description, 50, 'Item description');
      count += Object.keys(changes).length;
    }
  }
  if (!count) deny('At least one explicit metadata change is required.');
  return patch as unknown as SavedSaleReturnMetadataPatch;
}

export async function updateSavedSaleReturnMetadata(
  prisma: any,
  scope: SavedSaleReturnScope,
  requestedVoucherNo: string | number,
  input: unknown,
): Promise<SavedSaleReturnIncoming> {
  const voucherNo = scopeKey(scope, requestedVoucherNo)!;
  const patch = validatePatch(input);
  try {
    return await withTenant(
      prisma,
      scope.tenantId,
      async (tx: any) => {
        const saved = await snapshot(tx, scope, voucherNo, true);
        if (saved.dto.version !== patch.version)
          throw new SavedSaleReturnError(
            409,
            'version-conflict',
            'The saved Return changed. Reload before retrying.',
          );
        const updates: Array<{ srNo: string; column: 'HM_ID' | 'ITM_REMARK'; value: string }> = [];
        for (const row of patch.lines ?? []) {
          const prior = saved.dto.lines.find((line) => line.identity.srNo === row.identity.srNo);
          if (!prior || canonical(prior.identity) !== canonical(row.identity))
            throw new SavedSaleReturnError(
              409,
              'identity-conflict',
              'The saved incoming row identity changed. Reload before retrying.',
            );
          for (const [field, column] of [
            ['huid', 'HM_ID'],
            ['description', 'ITM_REMARK'],
          ] as const) {
            if (!Object.hasOwn(row.changes, field)) continue;
            const capability = prior.capabilities[field];
            if (!capability.allowed)
              throw new SavedSaleReturnError(
                422,
                'unsupported-state',
                capability.reason ?? 'This metadata change is not supported.',
              );
            const value = row.changes[field]!;
            if (prior.raw[column] !== value)
              updates.push({ srNo: row.identity.srNo, column, value });
          }
        }
        let employee: string | undefined;
        if (patch.header) {
          const capability = saved.dto.header.capabilities.employeeCode;
          if (!capability.allowed)
            throw new SavedSaleReturnError(
              422,
              'unsupported-state',
              capability.reason ?? 'Employee changes are not supported.',
            );
          employee = patch.header.employeeCode;
          if (employee !== employee.trim())
            deny('Employee code must not contain surrounding spaces.');
          if (!employee) {
            if (trimmed(saved.settings[0]?.EMP_CODE_MANDATORY) === 'Y')
              deny('An employee is required by company configuration.');
          } else {
            const employees: unknown[] = await tx.$queryRawUnsafe(
              `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"::text=$3 FOR SHARE`,
              scope.tenantId,
              scope.coCode,
              employee,
            );
            if (employees.length !== 1)
              deny('Select one unambiguous employee belonging to this company.');
          }
        }
        for (const update of updates) {
          const changed = await tx.$executeRawUnsafe(
            `UPDATE "SL_DETL_RTN" t SET "${update.column}"=$7 WHERE ${where} AND t."SR_NO"::text=$8`,
            ...params(scope, voucherNo),
            update.value,
            update.srNo,
          );
          if (changed !== 1)
            throw new SavedSaleReturnError(
              409,
              'identity-conflict',
              'The saved incoming row changed. Reload before retrying.',
            );
        }
        if (employee !== undefined) {
          for (const table of ['SL_DATA', 'SL_DETL_RTN', 'BAR_DATA'] as const) {
            await tx.$executeRawUnsafe(
              `UPDATE "${table}" t SET "EMP_CODE"=$7 WHERE ${where} AND t."EMP_CODE" IS DISTINCT FROM $7`,
              ...params(scope, voucherNo),
              employee,
            );
          }
        }
        return (await snapshot(tx, scope, voucherNo, true)).dto;
      },
      { isolationLevel: 'Serializable', timeout: 20000 },
    );
  } catch (error: any) {
    if (error instanceof SavedSaleReturnError) throw error;
    if (
      error?.code === 'P2034' ||
      error?.meta?.code === '40001' ||
      error?.code === '40001' ||
      /could not serialize access|deadlock detected/i.test(String(error?.message ?? ''))
    ) {
      throw new SavedSaleReturnError(
        409,
        'version-conflict',
        'The saved Return changed. Reload before retrying.',
      );
    }
    throw error;
  }
}
