import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import {
  aggregateSaleReturnIncoming,
  calculateSaleReturnBill,
  createSaleReturnIncomingAggregateState,
  reduceSaleReturnIncomingAggregate,
  projectSavedSaleReturnBill,
  projectSaleReturnIncomingEditorText,
  resolveSaleReturnBillTaxPolicy,
  SALE_RETURN_BILL_PROJECTION_VERSION,
  SALE_RETURN_BILL_TAX_POLICY_VERSION,
  SALE_RETURN_INCOMING_AGGREGATE_VERSION,
  SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS,
  type SaleReturnBillState,
  type SaleReturnBillTaxPolicyResult,
  type SaleReturnIncomingAggregateState,
  type SaleReturnIncomingAggregateContext,
  type SaleReturnIncomingState,
  type SaleReturnIncomingTotalsState,
} from '@datacare/core';
import {
  SavedSaleReturnError,
  type SavedSaleReturnRaw,
  type SavedSaleReturnScope,
  type SavedSaleReturnObservedRow,
} from './savedSaleReturn.js';
import {
  observeSaleReturnIncomingReplayTx,
  saleReturnIncomingReplayInput,
  SaleReturnIncomingReplayError,
} from './saleReturnIncomingReplay.js';
import { SaleReturnIncomingConfigurationError } from './saleReturnIncomingConfiguration.js';
import { BookPolicyValidationError } from '../shared/bookPolicy.js';
import type {
  SaleReturnIncomingReplayState,
  SaleReturnIncomingReplayCellSnapshot,
  SaleReturnIncomingReplayEvent,
  SaleReturnIncomingReplayDiagnostic,
} from './saleReturnIncomingReplay.js';

export const SALE_RETURN_BILL_REPLAY_CONTRACT = 'x13-saved-incoming-bill-replay-v1' as const;
export const SALE_RETURN_BILL_REPLAY_PROFILE = 'saved-primary-incoming-bill-preview-v1' as const;
export interface SaleReturnBillReplayPhase {
  incomingTotals: Record<string, string>;
  bill: SaleReturnBillState;
}
export interface SaleReturnBillReplayIdentity {
  contractVersion: typeof SALE_RETURN_BILL_REPLAY_CONTRACT;
  scope: Omit<SavedSaleReturnScope, 'tenantId'>;
  voucherNo: string;
  replayVersion: string;
  documentVersion: string;
  configurationVersion: string;
}
export interface SaleReturnBillReplayState extends SaleReturnBillReplayIdentity {
  profile: typeof SALE_RETURN_BILL_REPLAY_PROFILE;
  /** The unchanged v1 row/configuration observation, including its own v1 token. */
  rowReplay: SaleReturnIncomingReplayState;
  savedHeader: SavedSaleReturnRaw;
  taxPolicy: SaleReturnBillTaxPolicyResult;
  headerProjectionVersion: string;
  phases: { loaded: SaleReturnBillReplayPhase | null; opened: SaleReturnBillReplayPhase | null };
  diagnostics: SaleReturnIncomingReplayDiagnostic[];
  capabilities: { canPreviewBill: boolean; canPreviewClosing: false; canSaveNumeric: false };
}
export interface SaleReturnBillReplayResult extends SaleReturnBillReplayIdentity {
  rowIdentity: string;
  baseline: SaleReturnIncomingReplayCellSnapshot;
  preview: SaleReturnIncomingReplayCellSnapshot;
  phases: {
    loaded: SaleReturnBillReplayPhase;
    opened: SaleReturnBillReplayPhase;
    preview: SaleReturnBillReplayPhase;
  };
  events: Array<SaleReturnIncomingReplayEvent & { status: 'applied' | 'skipped' }>;
  capabilities: { canPreviewClosing: false; canSaveNumeric: false };
}
export interface SaleReturnBillReplayRecovery {
  eventIndex?: number;
  fieldId?: string;
  editorText?: string;
  baseline?: SaleReturnIncomingReplayCellSnapshot;
  preview?: SaleReturnIncomingReplayCellSnapshot;
  phases?: SaleReturnBillReplayResult['phases'];
  diagnostics: SaleReturnIncomingReplayDiagnostic[];
}
export class SaleReturnBillReplayError extends Error {
  constructor(
    public readonly statusCode: 400 | 404 | 409 | 422,
    public readonly code: string,
    message: string,
    public readonly details?: SaleReturnBillReplayRecovery,
  ) {
    super(message);
    this.name = 'SaleReturnBillReplayError';
  }
}

const OPENING_UNAVAILABLE = Object.freeze({
  status: 'unavailable' as const,
  reason: 'Customer balance requires a resolved ledger mode.',
});
const LEDGER_CONTEXT_VERSION = 'unresolved-session-ledger-mode-v1';
const fieldId = (column: number) => `x13.primary-incoming.c${String(column).padStart(2, '0')}`;
const allowedFields = new Map(
  SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS.map((c) => [fieldId(c), c]),
);
const canonical = (value: unknown): string => {
  if (Array.isArray(value)) return '[' + value.map(canonical).join(',') + ']';
  if (value && typeof value === 'object')
    return (
      '{' +
      Object.entries(value)
        .sort(([a], [b]) => a.localeCompare(b))
        .map(([k, v]) => JSON.stringify(k) + ':' + canonical(v))
        .join(',') +
      '}'
    );
  return JSON.stringify(value) ?? 'null';
};
const hash = (value: unknown) => createHash('sha256').update(canonical(value)).digest('hex');
const diag = (code: string, message: string): SaleReturnIncomingReplayDiagnostic => ({
  code,
  message,
});
function validateScope(scope: SavedSaleReturnScope, voucherNo: string): void {
  for (const key of ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const)
    if (
      typeof scope?.[key] !== 'string' ||
      !scope[key] ||
      scope[key] !== scope[key].trim() ||
      /[\u0000-\u001f\u007f]/.test(scope[key])
    )
      throw new SaleReturnBillReplayError(
        400,
        'invalid-scope',
        `Complete explicit ${key} is required.`,
      );
  if (
    typeof voucherNo !== 'string' ||
    voucherNo.length !== 5 ||
    !/^(?!00000)\d{5}$/.test(voucherNo)
  )
    throw new SaleReturnBillReplayError(
      400,
      'invalid-voucher',
      'Use the exact positive five-digit saved voucher key.',
    );
}
/** Retain the original ordered-event envelope; no client policy or phase exists. */
export function saleReturnBillReplayInput(value: unknown) {
  const input = saleReturnIncomingReplayInput(value);
  if (
    input.replayVersion.length !== 64 ||
    input.rowIdentity.length !== 64 ||
    input.events.some((event) => /[^\x20-\x7e]/.test(event.fieldId))
  )
    throw new SaleReturnBillReplayError(
      400,
      'invalid-input',
      'Use exact saved identity and field tokens.',
    );
  if (input.events.some((event) => /[^\x20-\x7e]/.test(event.editorText)))
    throw new SaleReturnBillReplayError(
      400,
      'invalid-input',
      'Field changes must use printable ASCII numeric text.',
    );
  return input;
}
const sqlProjection = `(SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id') e) AS raw,
  t.xmin::text AS revision,t.ctid::text AS locator,to_jsonb(t)->>'row_id' AS "physicalId"`;
const normalized = (text: string | null | undefined) => (text ?? '').trim().toUpperCase();
type ExtraObservation = {
  taxPolicy: SaleReturnBillTaxPolicyResult;
  labels: {
    taxName: string | null;
    bankAccountName: string | null;
    cardAccountName: string | null;
  };
  diagnostics: SaleReturnIncomingReplayDiagnostic[];
  settings: SavedSaleReturnObservedRow[];
  taxes: SavedSaleReturnObservedRow[];
  accounts: SavedSaleReturnObservedRow[];
};
async function observeAdditional(
  tx: any,
  scope: SavedSaleReturnScope,
  header: SavedSaleReturnRaw,
): Promise<ExtraObservation> {
  // Alias discovery does not grant SQL Server collation equivalence. Ambiguous
  // settings block policy; ambiguous display masters leave their labels unknown.
  const settings: SavedSaleReturnObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${sqlProjection} FROM "CO_SET" t WHERE tenant_id=$1 AND upper(btrim(t."CO_CODE"::text))=upper(btrim($2::text))`,
    scope.tenantId,
    scope.coCode,
  );
  const taxes: SavedSaleReturnObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${sqlProjection} FROM "TAX_MAST" t WHERE tenant_id=$1 AND upper(btrim(t."CO_CODE"::text))=upper(btrim($2::text))
      AND "SR_NO"=0 AND upper(btrim(t."TAX_CODE"::text))=upper(btrim($3::text))`,
    scope.tenantId,
    scope.coCode,
    header.TAX_CODE ?? '',
  );
  const codes = [...new Set([normalized(header.BANK_AC), normalized(header.CARD_AC)])];
  const accounts: SavedSaleReturnObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${sqlProjection} FROM "AC_MAST" t WHERE tenant_id=$1 AND upper(btrim(t."CO_CODE"::text))=upper(btrim($2::text))
      AND upper(btrim(t."AC_CODE"::text))=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    codes,
  );
  for (const rows of [settings, taxes, accounts])
    rows.sort((a, b) => canonical(a).localeCompare(canonical(b)));
  const diagnostics: SaleReturnIncomingReplayDiagnostic[] = [];
  const setting =
    settings.length === 1 && settings[0]!.raw.CO_CODE === scope.coCode ? settings[0]!.raw : null;
  const taxPolicy = resolveSaleReturnBillTaxPolicy(
    setting && Object.hasOwn(setting, 'TAX_ROF') && Object.hasOwn(setting, 'ALL_ROF_REMOVE')
      ? {
          'CO_SET.TAX_ROF': setting.TAX_ROF,
          'CO_SET.ALL_ROF_REMOVE': setting.ALL_ROF_REMOVE,
        }
      : undefined,
  );
  if (!setting)
    diagnostics.push(
      diag('ambiguous-tax-settings', 'Exactly one canonical company tax-setting row is required.'),
    );
  if (taxPolicy.status === 'unsupported')
    diagnostics.push(...taxPolicy.diagnostics.map((d) => diag(d.code, d.message)));
  function label(
    rows: SavedSaleReturnObservedRow[],
    key: 'TAX_CODE' | 'AC_CODE',
    code: string,
    name: 'TAX_NAME' | 'AC_NAME',
    kind: string,
  ): string | null {
    const relevant = rows.filter((row) => normalized(row.raw[key]) === normalized(code));
    if (
      relevant.length === 1 &&
      relevant[0]!.raw.CO_CODE === scope.coCode &&
      relevant[0]!.raw[key] === code &&
      Object.hasOwn(relevant[0]!.raw, name)
    )
      return relevant[0]!.raw[name] ?? '';
    diagnostics.push(
      diag(
        kind + '-label-unavailable',
        `The saved ${kind} label is missing or ambiguous; the saved code and amounts are retained.`,
      ),
    );
    return null;
  }
  return {
    settings,
    taxes,
    accounts,
    taxPolicy,
    diagnostics,
    labels: {
      taxName: label(taxes, 'TAX_CODE', header.TAX_CODE ?? '', 'TAX_NAME', 'tax'),
      bankAccountName: label(
        accounts,
        'AC_CODE',
        header.BANK_AC ?? '',
        'AC_NAME',
        'cheque-account',
      ),
      cardAccountName: label(accounts, 'AC_CODE', header.CARD_AC ?? '', 'AC_NAME', 'card-account'),
    },
  };
}
function rowCells(state: SaleReturnIncomingState): SaleReturnIncomingReplayCellSnapshot {
  const editor = projectSaleReturnIncomingEditorText(state);
  if (editor.status !== 'ready')
    throw new SaleReturnBillReplayError(
      422,
      'unsupported-editor',
      'Calculated editor values are unsupported.',
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
const blankTotals = (): SaleReturnIncomingTotalsState => ({
  cells: Object.fromEntries(Array.from({ length: 71 }, (_, i) => [i, ''])),
  totCrFine: '0',
  prOthAmtLess: '0',
});
const phase = (
  totals: SaleReturnIncomingTotalsState,
  bill: SaleReturnBillState,
): SaleReturnBillReplayPhase => ({ incomingTotals: { ...totals.cells }, bill });
function publicIdentity(dto: SaleReturnBillReplayIdentity): SaleReturnBillReplayIdentity {
  const {
    contractVersion,
    scope,
    voucherNo,
    replayVersion,
    documentVersion,
    configurationVersion,
  } = dto;
  return {
    contractVersion,
    scope,
    voucherNo,
    replayVersion,
    documentVersion,
    configurationVersion,
  };
}
type Observed = {
  dto: SaleReturnBillReplayState;
  state: SaleReturnIncomingAggregateState | null;
  context: SaleReturnIncomingAggregateContext | null;
};
async function observe(
  tx: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  expectedVersion?: string,
): Promise<Observed> {
  let extra!: ExtraObservation;
  let replayVersion = '';
  const rowObservation = await observeSaleReturnIncomingReplayTx(
    tx,
    scope,
    voucherNo,
    undefined,
    async (observed) => {
      extra = await observeAdditional(tx, scope, observed.saved.dto.header.raw);
      replayVersion = hash({
        contract: SALE_RETURN_BILL_REPLAY_CONTRACT,
        profile: SALE_RETURN_BILL_REPLAY_PROFILE,
        headerProjection: SALE_RETURN_BILL_PROJECTION_VERSION,
        aggregate: SALE_RETURN_INCOMING_AGGREGATE_VERSION,
        taxPolicy: SALE_RETURN_BILL_TAX_POLICY_VERSION,
        fields: [...allowedFields.keys()],
        scope,
        voucherNo,
        rowReplayVersion: observed.replayVersion,
        settings: extra.settings,
        taxes: extra.taxes,
        accounts: extra.accounts,
        ledger: { version: LEDGER_CONTEXT_VERSION, ...OPENING_UNAVAILABLE },
      });
      if (expectedVersion !== undefined && expectedVersion !== replayVersion)
        throw new SaleReturnBillReplayError(
          409,
          'version-conflict',
          'The saved Return or bill calculation inputs changed. Reload before previewing again.',
        );
    },
  );
  const { dto: rowReplay, saved, states } = rowObservation;
  const diagnostics = [
    ...extra.diagnostics,
    diag('ledger-mode-unresolved', OPENING_UNAVAILABLE.reason),
  ];
  const projected = projectSavedSaleReturnBill({ raw: saved.dto.header.raw, labels: extra.labels });
  let loaded: SaleReturnBillReplayPhase | null = null;
  let opened: SaleReturnBillReplayPhase | null = null;
  let state: SaleReturnIncomingAggregateState | null = null;
  const context: SaleReturnIncomingAggregateContext | null =
    extra.taxPolicy.status === 'ready'
      ? {
          taxRoundingDecimals: extra.taxPolicy.policy.taxRoundingDecimals,
          editOpen: false,
          upDown: false,
          openingBalance: OPENING_UNAVAILABLE,
        }
      : null;
  if (projected.status === 'unsupported')
    diagnostics.push(...projected.diagnostics.map((d) => diag(d.code, d.message)));
  else loaded = phase(blankTotals(), projected.state);
  const eligibleRows =
    rowReplay.rows.length > 0 &&
    rowReplay.rows.every((row) => row.diagnostics.length === 0 && states.has(row.rowIdentity));
  if (!rowReplay.rows.length)
    diagnostics.push(
      diag('empty-incoming-grid', 'This saved Return has no incoming items to preview.'),
    );
  for (const row of rowReplay.rows) diagnostics.push(...row.diagnostics);
  if (projected.status === 'ready' && context && eligibleRows && rowReplay.configuration.policy) {
    const rows = rowReplay.rows.map((row, index) => ({
      ordinal: index + 1,
      state: states.get(row.rowIdentity)!,
    }));
    const folded = aggregateSaleReturnIncoming(rows, blankTotals(), false);
    if (folded.status === 'rejected') diagnostics.push(folded.diagnostic);
    else {
      // The existing profile has proved no outgoing parent/child rows. Source
      // cleared outgoing grid + MSG_TOT_FILL supplies0.00, never saved NET_AMT.
      const billed = calculateSaleReturnBill(
        projected.state,
        folded.state.cells[38]!,
        '0.00',
        context,
      );
      if (billed.status === 'rejected') diagnostics.push(billed.diagnostic);
      else {
        const created = createSaleReturnIncomingAggregateState({
          raw: projected.raw,
          rows,
          totals: folded.state,
          bill: billed.state,
          outgoingTotal24: '0.00',
        });
        if (created.status === 'unsupported') diagnostics.push(created.diagnostic);
        else {
          state = created.state;
          opened = phase(state.totals, state.bill);
        }
      }
    }
  }
  return {
    state,
    context,
    dto: {
      contractVersion: SALE_RETURN_BILL_REPLAY_CONTRACT,
      profile: SALE_RETURN_BILL_REPLAY_PROFILE,
      scope: { ...rowReplay.scope },
      voucherNo,
      replayVersion,
      documentVersion: rowReplay.documentVersion,
      configurationVersion: rowReplay.configurationVersion,
      rowReplay,
      savedHeader: { ...saved.dto.header.raw },
      taxPolicy: extra.taxPolicy,
      headerProjectionVersion: SALE_RETURN_BILL_PROJECTION_VERSION,
      phases: { loaded, opened },
      diagnostics,
      capabilities: {
        canPreviewBill: !!state && rowReplay.capabilities.canPreview,
        canPreviewClosing: false,
        canSaveNumeric: false,
      },
    },
  };
}
function errorBoundary(error: unknown): never {
  if (
    error instanceof SavedSaleReturnError ||
    error instanceof SaleReturnIncomingReplayError ||
    error instanceof SaleReturnIncomingConfigurationError
  )
    throw new SaleReturnBillReplayError(error.statusCode, error.code, error.message);
  if (error instanceof BookPolicyValidationError)
    throw new SaleReturnBillReplayError(422, 'configuration', error.message);
  throw error;
}
export async function getSaleReturnBillReplayState(
  prisma: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
): Promise<SaleReturnBillReplayState> {
  validateScope(scope, voucherNo);
  try {
    return await withTenant(
      prisma,
      scope.tenantId,
      async (tx) => (await observe(tx, scope, voucherNo)).dto,
      { isolationLevel: 'RepeatableRead' },
    );
  } catch (error) {
    return errorBoundary(error);
  }
}
export async function previewSaleReturnBillReplay(
  prisma: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  value: unknown,
): Promise<SaleReturnBillReplayResult> {
  validateScope(scope, voucherNo);
  try {
    const input = saleReturnBillReplayInput(value);
    return await withTenant(
      prisma,
      scope.tenantId,
      async (tx) => {
        const observed = await observe(tx, scope, voucherNo, input.replayVersion);
        const { dto, context } = observed;
        const row = dto.rowReplay.rows.find((r) => r.rowIdentity === input.rowIdentity);
        if (!row)
          throw new SaleReturnBillReplayError(
            409,
            'identity-conflict',
            'The saved row identity is missing. Reload the Return.',
          );
        if (
          !observed.state ||
          !context ||
          !dto.phases.loaded ||
          !dto.phases.opened ||
          !dto.rowReplay.configuration.policy ||
          !dto.capabilities.canPreviewBill ||
          !row.fieldCapabilities.some((c) => c.allowed)
        )
          throw new SaleReturnBillReplayError(
            422,
            'unsupported-state',
            'This saved Return is outside the supported bill preview.',
            { diagnostics: dto.diagnostics },
          );
        let state = observed.state;
        const index = state.rows.findIndex((r) => r.state.rowIdentity === row.rowIdentity);
        const baseline = rowCells(state.rows[index]!.state);
        const events: SaleReturnBillReplayResult['events'] = [];
        const phases = (): SaleReturnBillReplayResult['phases'] => ({
          loaded: dto.phases.loaded!,
          opened: dto.phases.opened!,
          preview: phase(state.totals, state.bill),
        });
        const recovery = (
          eventIndex: number,
          event: SaleReturnIncomingReplayEvent,
          diagnostics: SaleReturnIncomingReplayDiagnostic[],
        ): SaleReturnBillReplayRecovery => ({
          eventIndex,
          ...event,
          baseline,
          preview: rowCells(state.rows[index]!.state),
          phases: phases(),
          diagnostics,
        });
        for (const [eventIndex, event] of input.events.entries()) {
          const column = allowedFields.get(event.fieldId);
          const capability = row.fieldCapabilities.find((c) => c.fieldId === event.fieldId);
          if (column === undefined || !capability?.allowed)
            throw new SaleReturnBillReplayError(
              422,
              'unsupported-field',
              capability?.reason ?? 'This field has no supported bill-preview event.',
              recovery(eventIndex, event, [
                diag('unsupported-field', capability?.reason ?? 'Unsupported field.'),
              ]),
            );
          const configured = dto.rowReplay.configuration.columns.find(
            (c) => c.id === event.fieldId,
          )!;
          const result = reduceSaleReturnIncomingAggregate(
            state,
            {
              kind: 'leaveCell',
              rowIdentity: row.rowIdentity,
              column,
              text: event.editorText,
              context: {
                currentRow: index + 1,
                clearing: false,
                editorVisible: true,
                committedColumnWidth: configured.nominalWidth,
              },
            },
            dto.rowReplay.configuration.policy,
            context,
          );
          if (result.status === 'rejected')
            throw new SaleReturnBillReplayError(
              422,
              'calculation-rejected',
              result.diagnostic.message,
              recovery(eventIndex, event, [result.diagnostic]),
            );
          // Editor projection is part of an accepted transient step. Verify it
          // before publishing this prefix so recovery never contains a partial row.
          try {
            rowCells(result.state.rows[index]!.state);
          } catch (error) {
            if (error instanceof SaleReturnBillReplayError)
              throw new SaleReturnBillReplayError(
                422,
                error.code,
                error.message,
                recovery(eventIndex, event, error.details?.diagnostics ?? []),
              );
            throw error;
          }
          state = result.state;
          events.push({ ...event, status: result.status });
        }
        return {
          ...publicIdentity(dto),
          rowIdentity: row.rowIdentity,
          baseline,
          preview: rowCells(state.rows[index]!.state),
          phases: phases(),
          events,
          capabilities: { canPreviewClosing: false, canSaveNumeric: false },
        };
      },
      { isolationLevel: 'RepeatableRead' },
    );
  } catch (error) {
    return errorBoundary(error);
  }
}
