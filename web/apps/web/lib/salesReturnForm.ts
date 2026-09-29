import type { BusinessScope } from '../components/BusinessScope';
import { ApiError } from './api';

export type SavedReturnScope = BusinessScope & { coBook: string };
export type SavedReturnRaw = Record<string, string | null>;
export type SavedReturnFieldCapability = { allowed: boolean; reason: string | null };
export interface SavedReturnIdentity {
  srNo: string;
  oldSrNo: string | null;
  vchSrno: string | null;
  tagSrNo: string | null;
  itCode: string | null;
  tagNo: string | null;
}
export interface SavedReturnLine {
  identity: SavedReturnIdentity;
  raw: SavedReturnRaw;
  display: {
    itemName: string | null;
    itemNameReason: string | null;
    description: string;
    [key: string]: unknown;
  };
  capabilities: {
    huid: SavedReturnFieldCapability;
    description: SavedReturnFieldCapability;
  };
}
export interface SavedIncomingReturn {
  scope: SavedReturnScope;
  voucherNo: string;
  version: string;
  canUpdate: boolean;
  capabilities: { canUpdate: boolean; reason: string | null };
  header: {
    raw: SavedReturnRaw;
    display: {
      employeeName: string | null;
      employeeNameReason: string | null;
      [key: string]: unknown;
    };
    capabilities: { employeeCode: SavedReturnFieldCapability };
  };
  lines: SavedReturnLine[];
  related: Record<
    'outgoingLines' | 'outgoingComponents' | 'tagHeaders' | 'tagParents' | 'tagComponents',
    SavedReturnRaw[]
  >;
  provenance: Record<
    | 'incomingLineCount'
    | 'outgoingLineCount'
    | 'outgoingComponentCount'
    | 'tagHeaderCount'
    | 'tagParentCount'
    | 'tagComponentCount',
    number
  >;
  [key: string]: unknown;
}
export interface SavedReturnRecent {
  rows: Array<{
    voucherNo: string;
    raw: SavedReturnRaw;
    display: Record<string, unknown>;
  }>;
}
export interface SavedReturnDraft {
  employeeCode: string;
  lines: Record<string, { huid: string; description: string }>;
}
export interface SavedReturnMetadataPatch {
  version: string;
  header?: { employeeCode: string };
  lines?: Array<{
    identity: SavedReturnIdentity;
    changes: { huid?: string; description?: string };
  }>;
}

export function savedReturnScopeKey(scope: SavedReturnScope): string {
  return JSON.stringify([scope.coCode, scope.lcCode, scope.coYear, scope.coBook]);
}

export function savedReturnQuery(scope: SavedReturnScope): string {
  if (![scope.coCode, scope.lcCode, scope.coYear, scope.coBook].every((part) => part.trim()))
    throw new Error('Select a company, location, year and configured return book.');
  return new URLSearchParams({
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    coYear: scope.coYear,
    coBook: scope.coBook,
  }).toString();
}

function voucherIdentity(value: string): string {
  if (!/^\d{1,8}$/.test(value)) throw new Error('Enter a return voucher number of up to 8 digits.');
  return value.replace(/^0+/, '') || '0';
}

const SAVED_RETURN_ACTIONS = {
  read: 'incoming',
  metadata: 'incoming-metadata',
  numeric: 'incoming-numeric',
} as const;

export function savedReturnPath(
  scope: SavedReturnScope,
  voucherNo: string,
  action: 'read' | 'metadata' | 'numeric' = 'read',
): string {
  const voucher = voucherNo.trim();
  voucherIdentity(voucher);
  return `/sales-returns/${encodeURIComponent(voucher)}/${SAVED_RETURN_ACTIONS[action]}?${savedReturnQuery(scope)}`;
}

export function savedReturnRecentPath(scope: SavedReturnScope): string {
  return `/sales-returns/incoming-recent?${savedReturnQuery(scope)}`;
}

function record(value: unknown): value is Record<string, unknown> {
  return value !== null && typeof value === 'object' && !Array.isArray(value);
}

function exactRaw(value: unknown): value is SavedReturnRaw {
  return (
    record(value) && Object.values(value).every((cell) => cell === null || typeof cell === 'string')
  );
}

function nullableText(value: unknown): value is string | null {
  return value === null || typeof value === 'string';
}

function fieldCapability(value: unknown): value is SavedReturnFieldCapability {
  return (
    record(value) &&
    typeof value.allowed === 'boolean' &&
    (value.reason === null || typeof value.reason === 'string')
  );
}

function lineIdentity(value: unknown): value is SavedReturnIdentity {
  return (
    record(value) &&
    typeof value.srNo === 'string' &&
    value.srNo.length > 0 &&
    ['oldSrNo', 'vchSrno', 'tagSrNo', 'itCode', 'tagNo'].every(
      (key) => value[key] === null || typeof value[key] === 'string',
    )
  );
}

function rawScopeMatches(raw: SavedReturnRaw, scope: SavedReturnScope, voucherNo: string): boolean {
  return (
    raw.CO_CODE === scope.coCode &&
    raw.LC_CODE === scope.lcCode &&
    raw.CO_YEAR === scope.coYear &&
    raw.CO_BOOK === scope.coBook &&
    typeof raw.VCH_NO === 'string' &&
    /^\d{1,8}$/.test(raw.VCH_NO) &&
    voucherIdentity(raw.VCH_NO) === voucherIdentity(voucherNo)
  );
}

/** A lossy or mismatched observation must never enable editing. */
export function readSavedIncomingReturn(
  value: unknown,
  scope: SavedReturnScope,
  voucherNo: string,
): SavedIncomingReturn {
  const fail = () =>
    new Error('The saved return observation is incomplete. Reload before editing.');
  if (!record(value) || !record(value.scope)) throw fail();
  const observedScope = value.scope;
  if (
    ['coCode', 'lcCode', 'coYear', 'coBook'].some(
      (key) => observedScope[key] !== scope[key as keyof SavedReturnScope],
    ) ||
    typeof value.voucherNo !== 'string' ||
    voucherIdentity(value.voucherNo) !== voucherIdentity(voucherNo.trim()) ||
    typeof value.version !== 'string' ||
    !/^[a-f0-9]{64}$/.test(value.version) ||
    typeof value.canUpdate !== 'boolean' ||
    !record(value.capabilities) ||
    typeof value.capabilities.canUpdate !== 'boolean' ||
    !(value.capabilities.reason === null || typeof value.capabilities.reason === 'string') ||
    !record(value.header) ||
    !exactRaw(value.header.raw) ||
    !record(value.header.display) ||
    !nullableText(value.header.display.employeeName) ||
    !nullableText(value.header.display.employeeNameReason) ||
    !record(value.header.capabilities) ||
    !fieldCapability(value.header.capabilities.employeeCode) ||
    !Array.isArray(value.lines) ||
    !record(value.related) ||
    !record(value.provenance)
  )
    throw fail();
  if (
    !rawScopeMatches(value.header.raw, scope, value.voucherNo) ||
    !Object.hasOwn(value.header.raw, 'EMP_CODE')
  )
    throw fail();
  for (const key of [
    'outgoingLines',
    'outgoingComponents',
    'tagHeaders',
    'tagParents',
    'tagComponents',
  ]) {
    const rows = value.related[key];
    if (!Array.isArray(rows) || !rows.every(exactRaw)) throw fail();
  }
  for (const key of [
    'incomingLineCount',
    'outgoingLineCount',
    'outgoingComponentCount',
    'tagHeaderCount',
    'tagParentCount',
    'tagComponentCount',
  ]) {
    const count = value.provenance[key];
    if (typeof count !== 'number' || !Number.isSafeInteger(count) || count < 0) throw fail();
  }
  if (value.provenance.incomingLineCount !== value.lines.length) throw fail();
  const seen = new Set<string>();
  for (const line of value.lines) {
    if (
      !record(line) ||
      !lineIdentity(line.identity) ||
      !exactRaw(line.raw) ||
      !record(line.display) ||
      !nullableText(line.display.itemName) ||
      !nullableText(line.display.itemNameReason) ||
      typeof line.display.description !== 'string' ||
      !record(line.capabilities) ||
      !fieldCapability(line.capabilities.huid) ||
      !fieldCapability(line.capabilities.description) ||
      seen.has(line.identity.srNo)
    )
      throw fail();
    const observedRaw = line.raw;
    const observedIdentity = line.identity;
    if (
      !rawScopeMatches(observedRaw, scope, value.voucherNo) ||
      !Object.hasOwn(observedRaw, 'HM_ID') ||
      !Object.hasOwn(observedRaw, 'ITM_REMARK') ||
      (
        [
          ['SR_NO', 'srNo'],
          ['OLD_SRNO', 'oldSrNo'],
          ['VCH_SRNO', 'vchSrno'],
          ['TAG_SRNO', 'tagSrNo'],
          ['IT_CODE', 'itCode'],
          ['TAG_NO', 'tagNo'],
        ] as const
      ).some(([column, key]) => observedRaw[column] !== observedIdentity[key])
    )
      throw fail();
    seen.add(line.identity.srNo);
  }
  return value as unknown as SavedIncomingReturn;
}

export function readSavedReturnRecent(value: unknown): SavedReturnRecent {
  if (
    !record(value) ||
    !Array.isArray(value.rows) ||
    value.rows.some(
      (row) =>
        !record(row) ||
        typeof row.voucherNo !== 'string' ||
        !/^\d{1,8}$/.test(row.voucherNo) ||
        !exactRaw(row.raw) ||
        !record(row.display),
    )
  )
    throw new Error('The saved return list is incomplete. Refresh the list.');
  return value as unknown as SavedReturnRecent;
}

export function savedReturnLineKey(identity: SavedReturnIdentity): string {
  return JSON.stringify([
    identity.srNo,
    identity.oldSrNo,
    identity.vchSrno,
    identity.tagSrNo,
    identity.itCode,
    identity.tagNo,
  ]);
}

/** Display fallback is a draft baseline, never a replacement for an untouched raw NULL. */
export function savedReturnDraft(document: SavedIncomingReturn): SavedReturnDraft {
  return {
    employeeCode: document.header.raw.EMP_CODE ?? '',
    lines: Object.fromEntries(
      document.lines.map((line) => [
        savedReturnLineKey(line.identity),
        {
          huid: line.raw.HM_ID ?? '',
          description: line.display.description,
        },
      ]),
    ),
  };
}

export function savedReturnHasChanges(
  document: SavedIncomingReturn,
  draft: SavedReturnDraft,
): boolean {
  const baseline = savedReturnDraft(document);
  return (
    draft.employeeCode !== baseline.employeeCode ||
    document.lines.some((line) => {
      const key = savedReturnLineKey(line.identity);
      return (
        draft.lines[key]?.huid !== baseline.lines[key]?.huid ||
        draft.lines[key]?.description !== baseline.lines[key]?.description
      );
    })
  );
}

/** No numeric values, source-owned metadata or current toolbar scope can enter this patch. */
export function savedReturnMetadataPatch(
  document: SavedIncomingReturn,
  draft: SavedReturnDraft,
): SavedReturnMetadataPatch | null {
  const baseline = savedReturnDraft(document);
  const keys = new Set(Object.keys(baseline.lines));
  if (
    Object.keys(draft.lines).some((key) => !keys.has(key)) ||
    keys.size !== Object.keys(draft.lines).length
  )
    throw new Error('The saved row identity changed. Reload before editing.');
  const patch: SavedReturnMetadataPatch = { version: document.version };
  if (draft.employeeCode !== baseline.employeeCode) {
    if (!document.header.capabilities.employeeCode.allowed)
      throw new Error(
        document.header.capabilities.employeeCode.reason || 'Employee editing is unavailable.',
      );
    if (Array.from(draft.employeeCode).length > 3)
      throw new Error('Employee code must be at most 3 characters.');
    patch.header = { employeeCode: draft.employeeCode };
  }
  for (const line of document.lines) {
    const key = savedReturnLineKey(line.identity);
    const row = draft.lines[key];
    const original = baseline.lines[key];
    if (!row || !original)
      throw new Error('The saved row identity changed. Reload before editing.');
    const changes: { huid?: string; description?: string } = {};
    for (const field of ['huid', 'description'] as const) {
      if (row[field] === original[field]) continue;
      if (!line.capabilities[field].allowed)
        throw new Error(
          line.capabilities[field].reason ||
            `${field} editing is unavailable for row ${line.identity.srNo}.`,
        );
      const max = field === 'huid' ? 10 : 50;
      if (Array.from(row[field]).length > max)
        throw new Error(
          `${field === 'huid' ? 'HUID' : 'Receive Item'} for row ${line.identity.srNo} must be at most ${max} characters.`,
        );
      changes[field] = row[field];
    }
    if (Object.keys(changes).length)
      (patch.lines ??= []).push({ identity: { ...line.identity }, changes });
  }
  if (!patch.header && !patch.lines?.length) return null;
  if (!document.canUpdate || !document.capabilities.canUpdate)
    throw new Error(document.capabilities.reason || 'This saved return is read-only.');
  return patch;
}

/** An uncertain server/gateway response is never permission to resend an observed-version patch. */
export function savedReturnSaveFailure(
  error: unknown,
  phase: { dispatched: boolean; committed: boolean },
): { needsReload: boolean; conflict: boolean; message: string } {
  const detail =
    error instanceof ApiError
      ? String(error.body?.message || error.body?.error || error.message)
      : error instanceof Error
        ? error.message
        : 'The saved return request failed.';
  const conflict = error instanceof ApiError && error.status === 409;
  const uncertain = phase.dispatched && (!(error instanceof ApiError) || error.status >= 500);
  return {
    conflict,
    needsReload:
      phase.committed ||
      conflict ||
      uncertain ||
      (error instanceof ApiError && [401, 403, 404, 422].includes(error.status)),
    message: phase.committed
      ? `Metadata saved, but the returned observation could not be read. Reload before editing. ${detail}`
      : uncertain
        ? `The save result could not be confirmed. Reload before retrying. ${detail}`
        : detail,
  };
}

export interface SavedReturnRequestToken {
  context: number;
  request: number;
  kind: 'browse' | 'document';
}

/** Transition generations also invalidate the first A's callbacks after A→B→A. */
export class SavedReturnRequestGuard {
  private scope = '';
  private generation = 0;
  private sequences = { browse: 0, document: 0 };

  observe(scope: string): number {
    if (scope !== this.scope) {
      this.scope = scope;
      this.generation += 1;
    }
    return this.generation;
  }

  invalidate(): number {
    this.generation += 1;
    return this.generation;
  }

  begin(kind: SavedReturnRequestToken['kind']): SavedReturnRequestToken {
    return { context: this.generation, request: ++this.sequences[kind], kind };
  }

  current(token: SavedReturnRequestToken): boolean {
    return token.context === this.generation && token.request === this.sequences[token.kind];
  }
}
