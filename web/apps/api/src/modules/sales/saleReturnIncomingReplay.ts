import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import {
  projectSavedSaleReturnIncoming,
  projectSaleReturnIncomingEditorText,
  reduceSaleReturnIncoming,
  SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS,
  SALE_RETURN_INCOMING_PROJECTION_VERSION,
  type SaleReturnIncomingState,
} from '@datacare/core';
import {
  readSavedSaleReturnIncomingTx,
  SavedSaleReturnError,
  type SavedSaleReturnLineIdentity,
  type SavedSaleReturnObservation,
  type SavedSaleReturnObservedRow,
  type SavedSaleReturnRaw,
  type SavedSaleReturnScope,
} from './savedSaleReturn.js';
import {
  readSaleReturnIncomingConfigurationTx,
  SaleReturnIncomingConfigurationError,
  type SaleReturnIncomingConfiguration,
} from './saleReturnIncomingConfiguration.js';
import { BookPolicyValidationError } from '../shared/bookPolicy.js';

/** Read-only saved MSG_PR LeaveCell simulation. Never call a Return writer or allocator here. */
export const SALE_RETURN_INCOMING_REPLAY_CONTRACT = 'x13-saved-incoming-replay-v1' as const;
export const SALE_RETURN_INCOMING_REPLAY_PROFILE =
  'saved-primary-incoming-money-preview-v1' as const;
export interface SaleReturnIncomingReplayDiagnostic {
  code: string;
  fieldId?: string;
  message: string;
}
export interface SaleReturnIncomingReplayEvent {
  fieldId: string;
  editorText: string;
}
export interface SaleReturnIncomingReplayInput {
  replayVersion: string;
  rowIdentity: string;
  events: SaleReturnIncomingReplayEvent[];
}
export interface SaleReturnIncomingReplayCellSnapshot {
  visible: Record<string, string>;
  caches: Record<string, string>;
  editorTextByField: Record<string, string>;
}
export interface SaleReturnIncomingReplayFieldCapability {
  fieldId: string;
  allowed: boolean;
  reason: string | null;
  maxLength: 10;
  editorDecimals: 2;
}
export interface SaleReturnIncomingReplayRow {
  identity: SavedSaleReturnLineIdentity;
  rowIdentity: string;
  raw: SavedSaleReturnRaw;
  visible: Record<string, string> | null;
  caches: Record<string, string> | null;
  editorTextByField: Record<string, string> | null;
  fieldCapabilities: SaleReturnIncomingReplayFieldCapability[];
  diagnostics: SaleReturnIncomingReplayDiagnostic[];
}
interface ReplayObservationIdentity {
  contractVersion: typeof SALE_RETURN_INCOMING_REPLAY_CONTRACT;
  scope: Omit<SavedSaleReturnScope, 'tenantId'>;
  voucherNo: string;
  replayVersion: string;
  documentVersion: string;
  configurationVersion: string;
}
export interface SaleReturnIncomingReplayState extends ReplayObservationIdentity {
  profile: typeof SALE_RETURN_INCOMING_REPLAY_PROFILE;
  configuration: SaleReturnIncomingConfiguration;
  rows: SaleReturnIncomingReplayRow[];
  capabilities: { canPreview: boolean; canSaveNumeric: false };
}
export interface SaleReturnIncomingReplayResult extends ReplayObservationIdentity {
  rowIdentity: string;
  baseline: SaleReturnIncomingReplayCellSnapshot;
  preview: SaleReturnIncomingReplayCellSnapshot;
  events: Array<SaleReturnIncomingReplayEvent & { status: 'applied' | 'skipped' }>;
  aggregateRequired: boolean;
  capabilities: { canSaveNumeric: false };
}
export interface SaleReturnIncomingReplayRecovery {
  eventIndex?: number;
  fieldId?: string;
  editorText?: string;
  baseline?: SaleReturnIncomingReplayCellSnapshot;
  preview?: SaleReturnIncomingReplayCellSnapshot;
  diagnostics: SaleReturnIncomingReplayDiagnostic[];
}
export class SaleReturnIncomingReplayError extends Error {
  constructor(
    public readonly statusCode: 400 | 404 | 409 | 422,
    public readonly code: string,
    message: string,
    public readonly details?: SaleReturnIncomingReplayRecovery,
  ) {
    super(message);
    this.name = 'SaleReturnIncomingReplayError';
  }
}
const fieldId = (column: number) => `x13.primary-incoming.c${String(column).padStart(2, '0')}`;
const allowedIds = new Map(SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS.map((c) => [fieldId(c), c]));
const token = (value: unknown): value is string =>
  typeof value === 'string' && /^[a-f0-9]{64}$/.test(value);
const fail = (message: string): never => {
  throw new SaleReturnIncomingReplayError(400, 'invalid-input', message);
};
function object(value: unknown, name: string): Record<string, unknown> {
  if (!value || typeof value !== 'object' || Array.isArray(value))
    fail(`${name} must be an object.`);
  return value as Record<string, unknown>;
}
function exactKeys(value: Record<string, unknown>, expected: string[], name: string): void {
  if (
    Object.keys(value).length !== expected.length ||
    expected.some((key) => !Object.hasOwn(value, key))
  )
    fail(`${name} must contain only ${expected.join(', ')}.`);
}
/** Strict transport validation; semantic visibility/profile checks use fresh server observations. */
export function saleReturnIncomingReplayInput(value: unknown): SaleReturnIncomingReplayInput {
  const input = object(value, 'Replay request');
  exactKeys(input, ['replayVersion', 'rowIdentity', 'events'], 'Replay request');
  if (!token(input.replayVersion) || !token(input.rowIdentity))
    fail(
      'The saved replay version and complete row identity must be 64-character lowercase hexadecimal tokens.',
    );
  if (!Array.isArray(input.events) || input.events.length > 100)
    fail('Replay events must be an ordered array of at most 100 entries.');
  const events = (input.events as unknown[]).map((value) => {
    const event = object(value, 'Replay event');
    exactKeys(event, ['fieldId', 'editorText'], 'Replay event');
    if (
      typeof event.fieldId !== 'string' ||
      !/^x13\.primary-incoming\.c(?:[0-6]\d|70)$/.test(event.fieldId)
    )
      fail('A known primary incoming field ID is required.');
    if (
      typeof event.editorText !== 'string' ||
      event.editorText.length > 10 ||
      /[\u0000-\u001f\u007f]/.test(event.editorText)
    )
      fail('Original editor text must contain at most 10 characters without control characters.');
    return { fieldId: event.fieldId as string, editorText: event.editorText as string };
  });
  return {
    replayVersion: input.replayVersion as string,
    rowIdentity: input.rowIdentity as string,
    events,
  };
}
function validateScope(
  scope: SavedSaleReturnScope,
  voucherNo: unknown,
): asserts voucherNo is string {
  for (const key of ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const) {
    if (
      typeof scope?.[key] !== 'string' ||
      !scope[key] ||
      scope[key] !== scope[key].trim() ||
      /[\u0000-\u001f\u007f]/.test(scope[key])
    )
      fail(`Complete explicit ${key} is required.`);
  }
  if (typeof voucherNo !== 'string' || !/^(?!00000)\d{5}$/.test(voucherNo))
    fail('This saved preview requires the exact five-digit voucher key.');
}
function canonical(value: unknown): string {
  if (Array.isArray(value)) return `[${value.map(canonical).join(',')}]`;
  if (value && typeof value === 'object')
    return `{${Object.entries(value)
      .sort(([a], [b]) => a.localeCompare(b))
      .map(([k, v]) => `${JSON.stringify(k)}:${canonical(v)}`)
      .join(',')}}`;
  return JSON.stringify(value) ?? 'null';
}
const hash = (value: unknown) => createHash('sha256').update(canonical(value)).digest('hex');
const publicScope = ({ coCode, lcCode, coYear, coBook }: SavedSaleReturnScope) => ({
  coCode,
  lcCode,
  coYear,
  coBook,
});
const diagnostic = (code: string, message: string): SaleReturnIncomingReplayDiagnostic => ({
  code,
  message,
});

function documentReason(saved: SavedSaleReturnObservation): string | null {
  if (saved.editReason) return saved.editReason;
  const t = saved.tables;
  if (t.SL_DETL.length || t.SL_IDTL.length)
    return 'This preview is limited to Returns without an outgoing exchange leg.';
  if (t.BAR_DETL.length || t.BAR_IDTL.length || t.DM_DATA.length)
    return 'Tagged, component or diamond-ledger Returns need a separate calculation workflow.';
  // Existing source-shaped header mapping is the only accepted BAR header profile.
  if (t.BAR_DATA.length && !saved.dto.header.capabilities.employeeCode.allowed)
    return 'The saved Return companion is outside the supported preview profile.';
  return null;
}
function rowReason(raw: SavedSaleReturnRaw): string | null {
  // SR_NO is observed as PostgreSQL numeric text. Do not round it through JS Number;
  // floating storage can legitimately render a finite value in exponent notation.
  const serial =
    typeof raw.SR_NO === 'string'
      ? /^\+?((?:\d+(?:\.\d*)?|\.\d+))(?:[eE][+-]?\d+)?$/.exec(raw.SR_NO)
      : null;
  if (!serial || !/[1-9]/.test(serial[1]!))
    return 'The saved incoming row identity is unsupported.';
  if (raw.ENTRY_TYPE !== 'P' || raw.INOUT_TYPE !== 'I')
    return 'This preview supports only the primary incoming Return row type.';
  if (raw.TAG_NO !== 'N' && raw.TAG_NO !== '')
    return 'This preview supports only ordinary untagged incoming rows.';
  if (
    ![null, '', 'N'].includes(raw.APR_ISU ?? null) ||
    ![null, '', 'N'].includes(raw.EMP_ISU ?? null)
  )
    return 'Issued or approval-linked rows need a separate calculation workflow.';
  return null;
}
function cells(state: SaleReturnIncomingState): SaleReturnIncomingReplayCellSnapshot {
  const editor = projectSaleReturnIncomingEditorText(state);
  if (editor.status === 'unsupported')
    throw new SaleReturnIncomingReplayError(
      422,
      'unsupported-projection',
      'The calculated editor presentation is not supported.',
      { diagnostics: [...editor.diagnostics] },
    );
  return {
    visible: Object.fromEntries(
      Object.entries(state.visible).filter(
        (entry): entry is [string, string] => typeof entry[1] === 'string',
      ),
    ),
    caches: { ...state.caches },
    editorTextByField: { ...editor.editorTextByField },
  };
}
export type SaleReturnIncomingReplayObservation = {
  dto: SaleReturnIncomingReplayState;
  states: Map<string, SaleReturnIncomingState>;
  saved: SavedSaleReturnObservation;
};
/** An internal composition boundary, never a client callback or a new v1 DTO.
 * Additional same-transaction observations may bind their own version before
 * row projection starts. The existing v1 hash and public responses are retained.
 */
export async function observeSaleReturnIncomingReplayTx(
  tx: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  expectedReplayVersion?: string,
  beforeProjection?: (observation: {
    saved: SavedSaleReturnObservation;
    configuration: SaleReturnIncomingConfiguration;
    replayVersion: string;
  }) => Promise<void>,
): Promise<SaleReturnIncomingReplayObservation> {
  const saved = await readSavedSaleReturnIncomingTx(tx, scope, voucherNo);
  const configuration = await readSaleReturnIncomingConfigurationTx(tx, scope);
  // Keep the old saved DTO/version unchanged. Source ORDER BY A.SR_NO controls the
  // new replay's ordinals; let the database order its numeric storage directly.
  const serials: Array<{ srNo: string }> = await tx.$queryRawUnsafe(
    `SELECT to_jsonb(t)->>'SR_NO' AS "srNo" FROM "SL_DETL_RTN" t
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
     ORDER BY "SR_NO"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const ordinal = new Map(serials.map(({ srNo }, index) => [srNo, index]));
  const lines = [...saved.dto.lines].sort(
    (a, b) =>
      (ordinal.get(a.identity.srNo) ?? Number.MAX_SAFE_INTEGER) -
      (ordinal.get(b.identity.srNo) ?? Number.MAX_SAFE_INTEGER),
  );
  const itemCodes = [
    ...new Set(saved.dto.lines.map(({ raw }) => (raw.IT_CODE ?? '').trim().toUpperCase())),
  ];
  const masters: SavedSaleReturnObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id') e) AS raw,
     t.xmin::text AS revision,t.ctid::text AS locator,to_jsonb(t)->>'row_id' AS "physicalId"
     FROM "ITEM_MAST" t WHERE t.tenant_id=$1 AND upper(btrim(t."CO_CODE"::text))=upper(btrim($2::text)) AND upper(btrim(t."IT_CODE"::text))=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    itemCodes,
  );
  masters.sort((a, b) => canonical(a).localeCompare(canonical(b)));
  const replayVersion = hash({
    contract: SALE_RETURN_INCOMING_REPLAY_CONTRACT,
    profile: SALE_RETURN_INCOMING_REPLAY_PROFILE,
    projection: SALE_RETURN_INCOMING_PROJECTION_VERSION,
    fields: [...allowedIds.keys()],
    scope,
    voucherNo,
    documentVersion: saved.dto.version,
    configurationVersion: configuration.version,
    masters,
  });
  if (expectedReplayVersion !== undefined && expectedReplayVersion !== replayVersion)
    throw new SaleReturnIncomingReplayError(
      409,
      'version-conflict',
      'The saved Return or its calculation inputs changed. Reload before previewing again.',
    );
  await beforeProjection?.({ saved, configuration, replayVersion });
  const states = new Map<string, SaleReturnIncomingState>();
  const globalReason = documentReason(saved);
  const rows = lines.map((line, index): SaleReturnIncomingReplayRow => {
    const rowIdentity = hash({
      contract: SALE_RETURN_INCOMING_REPLAY_CONTRACT,
      scope,
      voucherNo,
      identity: line.identity,
    });
    const diagnostics: SaleReturnIncomingReplayDiagnostic[] = [];
    const profileReason = globalReason ?? rowReason(line.raw);
    if (profileReason) diagnostics.push(diagnostic('unsupported-profile', profileReason));
    if (saved.dto.lines.filter((other) => other.identity.srNo === line.identity.srNo).length !== 1)
      diagnostics.push(
        diagnostic('ambiguous-row-identity', 'More than one saved incoming row has this serial.'),
      );
    const projected = projectSavedSaleReturnIncoming({
      rowIdentity,
      ordinal: index + 1,
      raw: line.raw,
      itemMasters: masters.map(({ raw }) => raw),
    });
    let display: SaleReturnIncomingReplayCellSnapshot | null = null;
    if (projected.status === 'unsupported') diagnostics.push(...projected.diagnostics);
    else {
      const editor = projectSaleReturnIncomingEditorText(projected.state);
      if (editor.status === 'unsupported') diagnostics.push(...editor.diagnostics);
      else {
        display = cells(projected.state);
        states.set(rowIdentity, projected.state);
      }
    }
    if (!configuration.capabilities.canCalculate || !configuration.policy)
      diagnostics.push(
        ...configuration.diagnostics
          .filter((d) => d.blocking)
          .map(({ code, fieldId, message }) => ({
            code,
            ...(fieldId ? { fieldId } : {}),
            message,
          })),
      );
    const commonReason =
      diagnostics[0]?.message ??
      (!configuration.policy ? 'The effective calculation configuration is unresolved.' : null);
    const fieldCapabilities = [...allowedIds.keys()].map(
      (id): SaleReturnIncomingReplayFieldCapability => {
        const column = configuration.columns.find((c) => c.id === id);
        const reason =
          commonReason ??
          (column?.widthState !== 'nonzero'
            ? 'This field is hidden or its configured visibility is unresolved.'
            : null);
        return {
          fieldId: id,
          allowed: reason === null && display !== null,
          reason,
          maxLength: 10,
          editorDecimals: 2,
        };
      },
    );
    return {
      identity: { ...line.identity },
      rowIdentity,
      raw: { ...line.raw },
      visible: display?.visible ?? null,
      caches: display?.caches ?? null,
      editorTextByField: display?.editorTextByField ?? null,
      fieldCapabilities,
      diagnostics,
    };
  });
  return {
    saved,
    states,
    dto: {
      contractVersion: SALE_RETURN_INCOMING_REPLAY_CONTRACT,
      profile: SALE_RETURN_INCOMING_REPLAY_PROFILE,
      scope: publicScope(scope),
      voucherNo,
      replayVersion,
      documentVersion: saved.dto.version,
      configurationVersion: configuration.version,
      configuration,
      rows,
      capabilities: {
        canPreview: rows.some((row) => row.fieldCapabilities.some((field) => field.allowed)),
        canSaveNumeric: false,
      },
    },
  };
}
function errorBoundary(error: unknown): never {
  if (
    error instanceof SavedSaleReturnError ||
    error instanceof SaleReturnIncomingConfigurationError
  )
    throw new SaleReturnIncomingReplayError(error.statusCode, error.code, error.message);
  if (error instanceof BookPolicyValidationError)
    throw new SaleReturnIncomingReplayError(422, 'configuration', error.message);
  throw error;
}
export async function getSaleReturnIncomingReplayState(
  prisma: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
): Promise<SaleReturnIncomingReplayState> {
  validateScope(scope, voucherNo);
  try {
    return await withTenant(
      prisma,
      scope.tenantId,
      async (tx) => (await observeSaleReturnIncomingReplayTx(tx, scope, voucherNo)).dto,
      { isolationLevel: 'RepeatableRead' },
    );
  } catch (error) {
    return errorBoundary(error);
  }
}
export async function previewSaleReturnIncomingReplay(
  prisma: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  value: unknown,
): Promise<SaleReturnIncomingReplayResult> {
  validateScope(scope, voucherNo);
  const input = saleReturnIncomingReplayInput(value);
  try {
    return await withTenant(
      prisma,
      scope.tenantId,
      async (tx) => {
        const { dto, states } = await observeSaleReturnIncomingReplayTx(
          tx,
          scope,
          voucherNo,
          input.replayVersion,
        );
        const matching = dto.rows.filter((row) => row.rowIdentity === input.rowIdentity);
        if (matching.length !== 1)
          throw new SaleReturnIncomingReplayError(
            409,
            'identity-conflict',
            'This saved row identity is missing or ambiguous. Reload the Return.',
          );
        const row = matching[0]!;
        const initial = states.get(row.rowIdentity);
        if (
          !initial ||
          !dto.configuration.policy ||
          !row.fieldCapabilities.some((field) => field.allowed)
        )
          throw new SaleReturnIncomingReplayError(
            422,
            'unsupported-state',
            row.diagnostics[0]?.message ??
              'This saved row is outside the supported calculation preview.',
            { diagnostics: row.diagnostics },
          );
        const baseline = cells(initial);
        let state = initial;
        let aggregateRequired = false;
        const events: SaleReturnIncomingReplayResult['events'] = [];
        for (const [eventIndex, event] of input.events.entries()) {
          const column = allowedIds.get(event.fieldId);
          const capability = row.fieldCapabilities.find((field) => field.fieldId === event.fieldId);
          const recovery = (
            diagnostics: SaleReturnIncomingReplayDiagnostic[],
          ): SaleReturnIncomingReplayRecovery => ({
            eventIndex,
            ...event,
            baseline,
            preview: cells(state),
            diagnostics,
          });
          if (column === undefined || !capability?.allowed)
            throw new SaleReturnIncomingReplayError(
              422,
              'unsupported-field',
              capability?.reason ?? 'This field is not available in the saved calculation preview.',
              recovery([
                diagnostic(
                  'unsupported-field',
                  capability?.reason ?? 'The requested field has no supported preview action.',
                ),
              ]),
            );
          const configured = dto.configuration.columns.find((c) => c.id === event.fieldId)!;
          const result = reduceSaleReturnIncoming(
            state,
            {
              kind: 'leaveCell',
              rowIdentity: row.rowIdentity,
              column,
              text: event.editorText,
              context: {
                currentRow:
                  dto.rows.findIndex((candidate) => candidate.rowIdentity === row.rowIdentity) + 1,
                clearing: false,
                editorVisible: true,
                committedColumnWidth: configured.nominalWidth,
              },
            },
            dto.configuration.policy,
          );
          if (result.status === 'rejected')
            throw new SaleReturnIncomingReplayError(
              422,
              'calculation-refused',
              result.diagnostic.message,
              recovery([
                {
                  code: result.diagnostic.code,
                  fieldId: event.fieldId,
                  message: result.diagnostic.message,
                },
              ]),
            );
          state = result.state;
          aggregateRequired ||= result.aggregateRequired;
          events.push({ ...event, status: result.status });
        }
        return {
          contractVersion: dto.contractVersion,
          scope: dto.scope,
          voucherNo: dto.voucherNo,
          replayVersion: dto.replayVersion,
          documentVersion: dto.documentVersion,
          configurationVersion: dto.configurationVersion,
          rowIdentity: row.rowIdentity,
          baseline,
          preview: cells(state),
          events,
          aggregateRequired,
          capabilities: { canSaveNumeric: false as const },
        };
      },
      { isolationLevel: 'RepeatableRead' },
    );
  } catch (error) {
    return errorBoundary(error);
  }
}
