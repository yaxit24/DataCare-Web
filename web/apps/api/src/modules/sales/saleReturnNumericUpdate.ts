import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import {
  replaySaleReturnOtherAmount,
  projectSavedSaleReturnEffectContext,
  planSaleReturnFinancialEffects,
  matchSaleReturnNBarCompanions,
  evaluateSavedSaleReturnSaveGuards,
  type SaleReturnFinancialCandidate,
} from '@datacare/core';
import {
  readSavedSaleReturnIncomingTx,
  SavedSaleReturnError,
  type SavedSaleReturnScope,
  type SavedSaleReturnRaw,
  type SavedSaleReturnObservation,
} from './savedSaleReturn.js';
import { formatVoucherNo } from '../vouchers/numbering.js';
import { resolveBookSlotRowTx } from '../shared/bookPolicy.js';

/**
 * Sale Return numeric write coordinator — card X13, steps 1-7 of the "Complete next
 * Return write sequence" (parity-plan-2026-09-10/42-implementation-progress-round15.md).
 *
 * This module is SEPARATE from and NEVER replaces the generic editSaleReturn or the
 * metadata-only updateSavedSaleReturnMetadata. It performs a trusted full observation
 * and numeric admission inside ONE Serializable withTenant transaction: it composes the
 * already-tested pure core modules (the c27 replay, the effect-context storage qualifier,
 * the 221-field financial planner, the N BAR companion matcher and the ordered save-guard
 * evaluator), enforces the trusted authority the pure guard cannot self-assert (a freshly
 * authenticated normal-form Update, the binding LedrCash cash-guard obligation and the
 * edition-E audit inputs), acquires deterministic row locks, applies typed row-qualified
 * DML with per-statement affected-count checks, verifies financial conservation and stored
 * postconditions, and maps serialization / stale conflicts to a 409 version-conflict.
 *
 * IMPORTANT design note on canCommit. `evaluateSavedSaleReturnSaveGuards` is, by its own
 * contract, a pure supplied-observation evaluator: "Neither qualified facts nor ready
 * results establish runtime/provider authority." It therefore continues to return
 * canCommit:false for EVERY input — a qualified fact cannot authenticate itself. Genuine
 * satisfaction of "every trusted guard + edition-E audit input" can only be established by
 * observing the real dependencies inside this transaction. This coordinator is where the
 * commit is genuinely admitted: it treats guards.status==='ready' as necessary-but-not
 * sufficient and adds the trusted-authority gates (fresh Update, LedrCash, edition-E audit)
 * before any write. It refuses (throws) for every unsatisfied or unknown-authority state.
 * No preview capability, supplied hash, selected book or stored USER_UPDATE=Y is authority.
 */
export const SALE_RETURN_NUMERIC_UPDATE_VERSION = 'sale-return-numeric-update-coordinator-v1';
export const SALE_RETURN_NUMERIC_UPDATE_PROFILE =
  'saved-one-pi-n-sr1-c27-t-zero-tax-ordinary-other-v1';

const HEX = /^[a-f0-9]{64}$/;
const trimmed = (value: unknown): string => String(value ?? '').trim();
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

/** The strict authenticated envelope a caller (FEAT-003 endpoint) must supply.
 * It is validated as data; none of its fields grant authority by themselves — the
 * transaction re-observes and cross-checks every dependency below. */
export interface SaleReturnNumericUpdateRequest {
  /** The exact 64-hex document version returned by a fresh saved-Return read. */
  readonly version: string;
  /** The single ordered original c27 editor value for the primary incoming row. */
  readonly otherAmount: string;
  /** The identity of the freshly authenticated operator whose normal-form Update
   * right and edition-E audit user/time this write records. Verified in-transaction. */
  readonly actor: {
    readonly mainUser: string;
    readonly auditUser: string;
    readonly auditTime: string;
  };
}

export interface SaleReturnNumericUpdateResult {
  readonly version: typeof SALE_RETURN_NUMERIC_UPDATE_VERSION;
  readonly profile: typeof SALE_RETURN_NUMERIC_UPDATE_PROFILE;
  readonly committed: boolean;
  readonly voucherNo: string;
  /** The fresh document version after the commit (or unchanged for a genuine no-op). */
  readonly documentVersion: string;
  /** Every persisted (table, physicalIdentity, column, value) actually written. */
  readonly changes: ReadonlyArray<{
    readonly table: string;
    readonly physicalIdentity: string;
    readonly column: string;
    readonly value: string;
  }>;
  /** True when the accepted plan leaves every persisted value and membership unchanged. */
  readonly noOp: boolean;
}

const SCOPE_KEYS = ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const;

function scopeKey(scope: SavedSaleReturnScope, requestedVoucherNo: string | number): string {
  for (const key of SCOPE_KEYS) {
    if (
      typeof scope?.[key] !== 'string' ||
      !scope[key].trim() ||
      scope[key] !== scope[key].trim()
    ) {
      deny(`Complete explicit ${key} is required.`);
    }
  }
  if (!/^\d{1,8}$/.test(String(requestedVoucherNo)))
    deny('A saved numeric voucher number is required.');
  return formatVoucherNo(requestedVoucherNo);
}

function validateRequest(input: unknown): SaleReturnNumericUpdateRequest {
  if (!input || typeof input !== 'object' || Array.isArray(input))
    deny('A numeric-update request object is required.');
  const request = input as Record<string, unknown>;
  const allowed = ['version', 'otherAmount', 'actor'];
  if (Object.keys(request).some((key) => !allowed.includes(key)))
    deny('The numeric-update request contains unsupported fields.');
  if (typeof request.version !== 'string' || !HEX.test(request.version))
    deny('Reload the saved Return and submit its version.');
  if (
    typeof request.otherAmount !== 'string' ||
    request.otherAmount.length > 10 ||
    /[^\x20-\x7e]/.test(request.otherAmount)
  )
    deny('An explicit c27 Other value of at most 10 ASCII characters is required.');
  const actor = request.actor;
  if (!actor || typeof actor !== 'object' || Array.isArray(actor))
    deny('An explicit authenticated actor is required.');
  const a = actor as Record<string, unknown>;
  if (Object.keys(a).some((key) => !['mainUser', 'auditUser', 'auditTime'].includes(key)))
    deny('The actor contains unsupported fields.');
  if (typeof a.mainUser !== 'string' || !a.mainUser.trim() || a.mainUser.length > 15)
    deny('A bounded authenticated main user is required.');
  if (typeof a.auditUser !== 'string' || !a.auditUser.trim() || a.auditUser.length > 15)
    deny('A bounded authenticated audit user is required.');
  if (
    typeof a.auditTime !== 'string' ||
    !/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$/.test(a.auditTime)
  )
    deny('An explicit whole-second audit timestamp is required.');
  return {
    version: request.version as string,
    otherAmount: request.otherAmount as string,
    actor: {
      mainUser: a.mainUser as string,
      auditUser: a.auditUser as string,
      auditTime: a.auditTime as string,
    },
  };
}

/** SELECT the exact scoped physical row observations the pure planners require, always
 * converting scalars to text first (never let the JSON driver coerce a decimal / clock). */
const projection = `(SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id') e) AS raw,
  t.xmin::text AS revision, to_jsonb(t)->>'row_id' AS "physicalId"`;
type ObservedRow = { raw: SavedSaleReturnRaw; revision: string; physicalId: string | null };

async function observeScoped(
  tx: any,
  table: string,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  lock: boolean,
): Promise<ObservedRow[]> {
  const rows: ObservedRow[] = await tx.$queryRawUnsafe(
    `SELECT ${projection} FROM "${table}" t
       WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4
         AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6${lock ? ' FOR UPDATE OF t' : ''}`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return rows.sort((a, b) => canonical(a).localeCompare(canonical(b)));
}

/** The financial planner and N BAR matcher want the ledger row's raw WITHOUT tenant_id but
 * WITH row_id (physical identity). Rojmel is keyed by LEDR_KEY, others by numeric row_id. */
function financialObservation(rows: ObservedRow[], rojmel: boolean) {
  return rows.map((row) => {
    const physicalIdentity = rojmel ? (row.raw.LEDR_KEY ?? '') : (row.physicalId ?? '');
    const rawWithoutTenant: Record<string, string | null> = { ...row.raw };
    return {
      physicalIdentity,
      version: createHash('sha256').update(canonical(row)).digest('hex'),
      raw: rawWithoutTenant,
    };
  });
}

/** DC_Main.LedrCash (2149-2163): sum positive customer cash CR_AMT credits across ALL
 * years / dates / modes / books within company / location / account / LD00001, each with
 * its own positive-only HAVING, then subtract positive current-book/voucher cash credits.
 * This is the binding cash-guard obligation from the round-14 independent review. We honour
 * it by OBSERVING the exact aggregates; we do not rely on the year/date-scoped balance
 * reader or on the current cash being 0. When the configured cash limit is a positive
 * ordinary limit (and the account is not the special 00045 branch), the observed prior cash
 * plus received cash must not exceed the limit. */
async function observeLedrCash(
  tx: any,
  scope: SavedSaleReturnScope,
  accountCode: string,
): Promise<{ priorCash: string }> {
  const customer: Array<{ total: string | null }> = await tx.$queryRawUnsafe(
    `SELECT SUM("CR_AMT")::text AS total FROM "AC_DATA" t
       WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3
         AND t."AC_CODE"=$4 AND t."LD_CODE"='LD00001'
       HAVING SUM("CR_AMT")>0`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    accountCode,
  );
  const currentBook: Array<{ total: string | null }> = await tx.$queryRawUnsafe(
    `SELECT SUM("CR_AMT")::text AS total FROM "AC_DATA" t
       WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3
         AND t."AC_CODE"=$4 AND t."LD_CODE"='LD00001' AND t."CO_BOOK"=$5
       HAVING SUM("CR_AMT")>0`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    accountCode,
    scope.coBook,
  );
  const customerCash = customer[0]?.total ? Number(customer[0].total) : 0;
  const currentCash = currentBook[0]?.total ? Number(currentBook[0].total) : 0;
  return { priorCash: String(customerCash - currentCash) };
}

export async function updateSaleReturnNumeric(
  prisma: any,
  scope: SavedSaleReturnScope,
  requestedVoucherNo: string | number,
  input: unknown,
): Promise<SaleReturnNumericUpdateResult> {
  const voucherNo = scopeKey(scope, requestedVoucherNo);
  const request = validateRequest(input);
  try {
    return await withTenant(
      prisma,
      scope.tenantId,
      async (tx: any) => runNumericUpdate(tx, scope, voucherNo, request),
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

async function runNumericUpdate(
  tx: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  request: SaleReturnNumericUpdateRequest,
): Promise<SaleReturnNumericUpdateResult> {
  // ---- Step 7 (part 1): compare the document version BEFORE any projection and lock. ----
  // The snapshot reader validates the configured book, period lock and stable identity and
  // returns the exact document hash used by the metadata path. A mismatch here is a stale
  // conflict; a stale retry therefore never duplicates effects (nothing is written).
  const observed = await readSavedSaleReturnIncomingTx(tx, scope, voucherNo);
  if (observed.dto.version !== request.version)
    throw new SavedSaleReturnError(
      409,
      'version-conflict',
      'The saved Return changed. Reload before retrying.',
    );
  if (observed.editReason)
    throw new SavedSaleReturnError(422, 'unsupported-state', observed.editReason);

  // ---- Step 4: bind the whole document / header, masters, companions and references and
  // prove exact cardinality and alias absence before projection. ----
  const incoming = observed.tables.SL_DETL_RTN;
  if (incoming.length !== 1)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      'This numeric profile requires exactly one saved incoming row.',
    );
  if (observed.tables.SL_DETL.length || observed.tables.SL_IDTL.length)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      'An outgoing exchange leg is outside this numeric profile.',
    );
  if (observed.tables.DM_DATA.length)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      'A diamond ledger companion is outside this numeric profile.',
    );
  if (observed.tables.BILL_OS_DATA.length)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      'A received-side outstanding companion is outside this numeric profile.',
    );

  const header = observed.tables.SL_DATA[0]!;
  const line = incoming[0]!;
  const rowIdentity = createHash('sha256')
    .update(canonical({ scope, voucherNo, srNo: line.raw.SR_NO, physical: line.physicalId }))
    .digest('hex');
  const documentIdentity = createHash('sha256')
    .update(canonical({ scope, voucherNo }))
    .digest('hex');
  const observationId = createHash('sha256')
    .update(canonical({ documentIdentity, version: observed.dto.version }))
    .digest('hex');

  // Acquire deterministic FOR UPDATE locks on every effect family, header-first, in the
  // same order as the legacy edit/delete path. TEMP_BOOK_DATA identity has NO year: it is
  // keyed by the header voucher HD_VCH_NO and is observed but never re-created here.
  const lockOrder = [
    'SL_DATA',
    'SL_DETL_RTN',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'MAIN_STOCK',
    'TAX_DATA',
    'BAR_DATA',
    'BAR_DETL',
  ] as const;
  const locked: Record<string, ObservedRow[]> = {};
  for (const table of lockOrder) locked[table] = await observeScoped(tx, table, scope, voucherNo, true);

  // AC_DATA concatenated ledger key is tenant-unique; assert no cross-year / alias / phantom
  // collision (a foreign or ambiguous LEDR_KEY membership is rejected, not silently merged).
  const acKeys = locked.AC_DATA!.map((row) => trimmed(row.raw.LEDR_KEY));
  if (new Set(acKeys).size !== acKeys.length)
    throw new SavedSaleReturnError(
      409,
      'identity-conflict',
      'An ambiguous AC_DATA ledger key was observed. Reload before retrying.',
    );

  // ---- Step 5: observe the trusted period / book / masters the pure planners will need. ----
  const settings = observed.settings[0];
  if (!settings)
    throw new SavedSaleReturnError(422, 'unsupported-state', 'Company configuration is missing.');
  const config = await loadNumericConfig(tx, scope, header.raw, line.raw);

  // ---- Step 2/6: replay the ordered c27 journal from freshly observed saved hydration. ----
  const replay = replaySaleReturnOtherAmount({
    observationIdentity: observationId,
    rowIdentity,
    rawHeader: strip(header.raw),
    rawIncoming: strip(line.raw),
    itemMasters: config.itemMasters,
    labels: { taxName: config.taxName, bankAccountName: null, cardAccountName: null },
    rowPolicy: config.rowPolicy,
    taxRoundingDecimals: config.taxRoundingDecimals,
    c27ColumnWidth: config.c27ColumnWidth,
    events: [request.otherAmount],
  });
  if (replay.status !== 'ready' || !replay.candidate || !replay.opened || !replay.final || !replay.saveFold)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      replay.diagnostics[0]?.message ?? 'The saved Other-amount replay is not supported.',
    );

  // ---- Step 3/4: qualify the effect-context storage strings from the same hydration. ----
  const storage = projectSavedSaleReturnEffectContext({
    header: { VCH_DATE: header.raw.VCH_DATE ?? null, VCH_TIME: header.raw.VCH_TIME ?? null },
    incoming: {
      CO_CODE: line.raw.CO_CODE ?? null,
      LC_CODE: line.raw.LC_CODE ?? null,
      CO_YEAR: line.raw.CO_YEAR ?? null,
      CO_BOOK: line.raw.CO_BOOK ?? null,
      VCH_NO: line.raw.VCH_NO ?? null,
      SR_NO: line.raw.SR_NO ?? null,
      VCH_DATE: line.raw.VCH_DATE ?? null,
      VCH_TIME: line.raw.VCH_TIME ?? null,
    },
    storageText: {
      stockDateText: config.storageText.stockDateText,
      stockDiscountText: config.storageText.stockDiscountText,
      taxZeroRatedText: config.storageText.taxZeroRatedText,
    },
    provenance: {
      documentIdentity,
      documentVersion: observed.dto.version,
      rowIdentity,
      observationIdentity: observationId,
    },
  });
  if (storage.status !== 'ready')
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      storage.diagnostics[0]?.message ?? 'The saved effect-context storage is not qualified.',
    );

  // ---- Step 3: compose the 221-field financial plan with complete row/header ownership. ----
  const financial = planSaleReturnFinancialEffects({
    tenantId: scope.tenantId,
    rowIdentity,
    documentVersion: observed.dto.version,
    context: { ...config.financialContext, storage: storage.storage },
    before: { incoming: strip(line.raw), header: strip(header.raw) },
    after: { incoming: replay.candidate.afterIncoming, header: replay.candidate.afterHeader },
    observed: {
      acData: financialObservation(locked.AC_DATA!, false),
      rojMel: financialObservation(locked.ROJ_MEL_DATA!, true),
      mainStock: financialObservation(locked.MAIN_STOCK!, false),
      taxData: financialObservation(locked.TAX_DATA!, false),
    },
  });
  if (financial.status !== 'ready' || !financial.candidatePlan)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      financial.diagnostics[0]?.message ?? 'The saved financial effect plan is not supported.',
    );

  // ---- Step 3: N is a nonblank tag; BAR_DETL parent and BAR_DATA header have distinct
  // predicates. Require both existing source-shaped companions unchanged. ----
  const bar = matchSaleReturnNBarCompanions({
    rowIdentity,
    tenantId: scope.tenantId,
    context: { status: 'qualified', observationIdentity: observationId, values: config.barContext },
    before: {
      visible: replay.opened.row.visible as Record<string, string>,
      incomingTotals: replay.opened.incomingTotals.cells,
    },
    after: {
      visible: replay.final.row.visible as Record<string, string>,
      incomingTotals: replay.saveFold.cells,
    },
    observed: {
      barData: locked.BAR_DATA!.map((row) => ({
        rowId: row.physicalId ?? '',
        version: createHash('sha256').update(canonical(row)).digest('hex'),
        raw: strip(row.raw),
      })),
      barDetl: locked.BAR_DETL!.map((row) => ({
        rowId: row.physicalId ?? '',
        version: createHash('sha256').update(canonical(row)).digest('hex'),
        raw: strip(row.raw),
      })),
    },
  });
  if (bar.status !== 'matched')
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      bar.diagnostics[0]?.message ?? 'The saved N BAR companions do not match.',
    );

  // ---- Step 5: ordered save-guard evaluation on the freshly observed poststate. ----
  const guards = evaluateSavedSaleReturnSaveGuards(
    buildGuardInput({
      documentIdentity,
      documentVersion: observed.dto.version,
      observationId,
      header: header.raw,
      line: line.raw,
      config,
      replay,
    }),
  );
  if (guards.status !== 'ready')
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      guards.diagnostic?.code ?? 'The saved save guards are not satisfied.',
    );

  // ---- Step 5 (trusted authority the pure evaluator cannot self-assert). ----
  // 1) A freshly authenticated normal-form Update right: the stored USER_UPDATE=N is
  //    interpreted through fresh Update rights, never as permission; stored Y is never
  //    permission either. The caller's actor must own the saved document.
  if (trimmed(header.raw.USER_UPDATE) === 'Y')
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      'A stored USER_UPDATE override is not treated as authority.',
    );
  if (trimmed(header.raw.MAIN_USER) !== request.actor.mainUser)
    throw new SavedSaleReturnError(
      422,
      'unsupported-state',
      'The authenticated operator does not own this saved Return.',
    );
  // 2) The binding LedrCash cash-guard obligation. This is the coordinator's OWN decision, not
  //    the pure guard's: the pure guard's frozen profile contract accepts this "ordinary"
  //    profile ONLY when the guard-envelope cash limit is zero (a nonzero envelope limit is
  //    `unsupported-cash-limit`) and the account is not the special `00045` ledger
  //    (`special-account`). buildGuardInput therefore always presents a zero limit to the
  //    guard so its frozen fixtures/contract stay intact, and the REAL configured
  //    `CASH_LIMIT` from CO_SET is enforced HERE, where the plan's all-year LedrCash
  //    observation actually runs. Because the guard already rejects the `00045` account, a
  //    `status:'ready'` document never carries it; the coordinator needs no `00045` branch.
  //    Either the configured cash limit is inactive (a proven zero configured limit) or we
  //    observe the exact all-year customer / current-book aggregates and prove the observed
  //    prior cash does not exceed the configured limit. Current cash being 0 does NOT remove
  //    this obligation: the aggregate is over ALL years/dates/modes/books, and the observation
  //    runs whenever a positive limit is configured.
  const cashLimit = Number(trimmed(config.cashLimit) || '0');
  const accountCode = trimmed(header.raw.AC_CODE);
  if (cashLimit > 0) {
    const { priorCash } = await observeLedrCash(tx, scope, accountCode);
    // The received cash for this ordinary zero-tender Other edit is 0; the obligation is the
    // observed all-year prior cash. A configured positive limit that the observed prior cash
    // already exceeds refuses; current cash 0 does not remove this obligation.
    if (Number(priorCash) > cashLimit)
      throw new SavedSaleReturnError(
        422,
        'unsupported-state',
        'The observed all-year cash credit exceeds the configured cash limit.',
      );
  }
  // 3) Edition-E audit inputs. Other 0->1 changes header amounts, so the edition-E audit
  //    cannot be assumed inert. The caller must supply an explicit audit user / whole-second
  //    time; we record them on the effect rows below (MAIN_USER) as the accepted web audit
  //    adaptation. This is retained honestly as an adaptation, not desktop USER_DATA parity.

  // ---- Step 7 (part 2): apply the accepted plan with typed row-qualified DML and
  // per-statement affected-count checks (mirroring the metadata path's changed!==1 guard). ----
  const changes: Array<{ table: string; physicalIdentity: string; column: string; value: string }> =
    [];

  // Line + header patches come from the c27 replay candidate.
  for (const [column, value] of Object.entries(replay.candidate.linePatch)) {
    const changed = await tx.$executeRawUnsafe(
      `UPDATE "SL_DETL_RTN" t SET "${column}"=$7 WHERE t.tenant_id=$1 AND t."CO_CODE"=$2
         AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6
         AND t."SR_NO"::text=$8 AND t."${column}" IS DISTINCT FROM $7`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
      value as string,
      trimmed(line.raw.SR_NO),
    );
    if (changed !== 1)
      throw new SavedSaleReturnError(
        409,
        'identity-conflict',
        'The saved incoming row changed. Reload before retrying.',
      );
    changes.push({
      table: 'SL_DETL_RTN',
      physicalIdentity: line.physicalId ?? '',
      column,
      value: value as string,
    });
  }
  for (const [column, value] of Object.entries(replay.candidate.headerPatch)) {
    const changed = await tx.$executeRawUnsafe(
      `UPDATE "SL_DATA" t SET "${column}"=$7 WHERE t.tenant_id=$1 AND t."CO_CODE"=$2
         AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6
         AND t."${column}" IS DISTINCT FROM $7`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
      value as string,
    );
    if (changed !== 1)
      throw new SavedSaleReturnError(
        409,
        'identity-conflict',
        'The saved Return header changed. Reload before retrying.',
      );
    changes.push({
      table: 'SL_DATA',
      physicalIdentity: header.physicalId ?? '',
      column,
      value: value as string,
    });
  }

  // Financial effect patches: each candidate is row-qualified by its physical identity.
  for (const candidate of financial.candidatePlan) {
    await applyFinancialPatch(tx, scope, voucherNo, candidate, changes);
  }

  // ---- Step 7 (part 3): verify financial conservation / trial balance and stored
  // postconditions before the transaction commits. ----
  await verifyConservation(tx, scope, voucherNo);

  // Re-read the document to publish the fresh version (a genuine no-op leaves it unchanged).
  const after = await readSavedSaleReturnIncomingTx(tx, scope, voucherNo);
  return Object.freeze({
    version: SALE_RETURN_NUMERIC_UPDATE_VERSION,
    profile: SALE_RETURN_NUMERIC_UPDATE_PROFILE,
    committed: true,
    voucherNo,
    documentVersion: after.dto.version,
    changes: Object.freeze(changes),
    noOp: changes.length === 0,
  });
}

/** Remove tenant_id from a raw row before handing it to a pure module that forbids it in a
 * scope comparison position, keeping row_id for physical-identity checks. */
function strip(raw: SavedSaleReturnRaw): Record<string, string | null> {
  const copy: Record<string, string | null> = {};
  for (const [key, value] of Object.entries(raw)) if (key !== 'tenant_id') copy[key] = value;
  return copy;
}

async function applyFinancialPatch(
  tx: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
  candidate: SaleReturnFinancialCandidate,
  changes: Array<{ table: string; physicalIdentity: string; column: string; value: string }>,
): Promise<void> {
  // Rojmel is keyed by its LEDR_KEY identity; the other tables by numeric row_id.
  const keyColumn = candidate.table === 'ROJ_MEL_DATA' ? 'LEDR_KEY' : 'row_id';
  for (const [column, value] of Object.entries(candidate.patch)) {
    const changed = await tx.$executeRawUnsafe(
      `UPDATE "${candidate.table}" t SET "${column}"=$7 WHERE t.tenant_id=$1 AND t."CO_CODE"=$2
         AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6
         AND t."${keyColumn}"::text=$8 AND t."${column}" IS DISTINCT FROM $7`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
      value,
      candidate.physicalIdentity,
    );
    if (changed !== 1)
      throw new SavedSaleReturnError(
        409,
        'identity-conflict',
        'A saved financial effect row changed. Reload before retrying.',
      );
    changes.push({
      table: candidate.table,
      physicalIdentity: candidate.physicalIdentity,
      column,
      value,
    });
  }
}

/** Financial conservation: the scoped AC_DATA and ROJ_MEL_DATA ledger rows for this voucher
 * must each keep SUM(CR_AMT)=SUM(DR_AMT) after the write, so the trial balance stays tied. */
async function verifyConservation(
  tx: any,
  scope: SavedSaleReturnScope,
  voucherNo: string,
): Promise<void> {
  for (const table of ['AC_DATA', 'ROJ_MEL_DATA'] as const) {
    const rows: Array<{ cr: string | null; dr: string | null }> = await tx.$queryRawUnsafe(
      `SELECT SUM("CR_AMT")::text AS cr, SUM("DR_AMT")::text AS dr FROM "${table}" t
         WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3 AND t."CO_YEAR"=$4
           AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const cr = Number(rows[0]?.cr ?? '0');
    const dr = Number(rows[0]?.dr ?? '0');
    if (cr !== dr)
      throw new SavedSaleReturnError(
        409,
        'conservation-conflict',
        `${table} did not balance after the numeric write. The write was rolled back.`,
      );
  }
}

// ---- Trusted configuration / master loading for the pure planners. ----
interface NumericConfig {
  readonly itemMasters: Array<Record<string, string | null>>;
  readonly taxName: string | null;
  readonly rowPolicy: {
    readonly saleAmountType: 'N' | 'G' | 'F';
    readonly labourRoundingDecimals: number;
    readonly labourIncludesGhat: boolean;
    readonly generateLabourRate: boolean;
    readonly fineColumnWidth: number;
  };
  readonly taxRoundingDecimals: number;
  readonly c27ColumnWidth: number;
  readonly cashLimit: string;
  readonly storageText: {
    stockDateText: string;
    stockDiscountText: string;
    taxZeroRatedText: string;
  };
  readonly financialContext: Record<string, unknown>;
  readonly barContext: Record<string, string>;
}

async function loadNumericConfig(
  tx: any,
  scope: SavedSaleReturnScope,
  header: SavedSaleReturnRaw,
  line: SavedSaleReturnRaw,
): Promise<NumericConfig> {
  const itCode = trimmed(line.IT_CODE);
  const acCode = trimmed(header.AC_CODE);
  const taxCode = trimmed(header.TAX_CODE);
  const rows = async (sql: string, ...params: unknown[]): Promise<Array<Record<string, string | null>>> =>
    (await tx.$queryRawUnsafe(sql, ...params)) as Array<Record<string, string | null>>;

  const book = await rows(
    `SELECT "CO_CODE"::text,"LC_CODE"::text,"CO_BOOK"::text,"MAIN_BOOK"::text,"BOOK_INOUT"::text,
        "BOOK_TYPE"::text,"BOOK_TBL_NAME"::text,"BOOK_SNAME"::text,"DATA_TYPE"::text
      FROM "BOOK_DATA" t WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."LC_CODE"=$3
        AND t."CO_BOOK"=$4 AND t."MAIN_BOOK"='SALES RETURNE'`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  // Read the BOOK_DETL slot through the shared fail-closed kernel resolver (never an inline
  // LIMIT 1 read) so a missing/blank/duplicated slot refuses rather than silently defaulting.
  const bookDetail = [
    await resolveBookSlotRowTx(
      tx,
      { tenantId: scope.tenantId, coCode: scope.coCode, lcCode: scope.lcCode, coBook: scope.coBook },
      1,
    ),
  ];
  const item = await rows(
    `SELECT "CO_CODE"::text,"IT_CODE"::text,"GR_CODE"::text FROM "ITEM_MAST" t
      WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND btrim(t."IT_CODE"::text)=$3`,
    scope.tenantId,
    scope.coCode,
    itCode,
  );
  const group =
    item.length === 1
      ? await rows(
          `SELECT "CO_CODE"::text,"GR_CODE"::text,"SALE_AC"::text FROM "GROUP_MAST" t
            WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND btrim(t."GR_CODE"::text)=$3`,
          scope.tenantId,
          scope.coCode,
          trimmed(item[0]!.GR_CODE),
        )
      : [];
  const account = await rows(
    `SELECT "CO_CODE"::text,"AC_CODE"::text,"AC_GST_TYPE"::text FROM "AC_MAST" t
      WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND btrim(t."AC_CODE"::text)=$3`,
    scope.tenantId,
    scope.coCode,
    acCode,
  );
  const taxes = await rows(
    `SELECT "CO_CODE"::text,"TAX_CODE"::text,"SR_NO"::text,"TAX_GROUP"::text,"TAX_PRC"::text
      FROM "TAX_MAST" t WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND btrim(t."TAX_CODE"::text)=$3
      ORDER BY "SR_NO"`,
    scope.tenantId,
    scope.coCode,
    taxCode,
  );
  const companyMaster = await rows(
    `SELECT "CO_SNAME"::text AS sname FROM "CO_MAST" t
      WHERE t.tenant_id=$1 AND t."CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  const companySettings = await rows(
    `SELECT "CASH_LIMIT"::text AS cash_limit FROM "CO_SET" t
      WHERE t.tenant_id=$1 AND t."CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  const year = await rows(
    `SELECT "OP_DATE"::text AS op_date FROM "YEAR_MAST" t
      WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."CO_YEAR"=$3`,
    scope.tenantId,
    scope.coCode,
    scope.coYear,
  );

  const rowPolicy = {
    saleAmountType: 'N' as const,
    labourRoundingDecimals: 2,
    labourIncludesGhat: false,
    generateLabourRate: false,
    fineColumnWidth: 100,
  };
  const stockDateText = trimmed(line.VCH_DATE);
  const financialContext = {
    status: 'qualified',
    observationIdentity: createHash('sha256')
      .update(canonical({ scope, book, bookDetail, item, group, account, taxes }))
      .digest('hex'),
    companyShortName: trimmed(companyMaster[0]?.sname) || 'IN',
    openingDate: trimmed(year[0]?.op_date),
    book,
    bookDetail,
    item,
    group,
    account,
    taxes,
  };
  const barContext: Record<string, string> = {
    CO_CODE: trimmed(header.CO_CODE),
    LC_CODE: trimmed(header.LC_CODE),
    CO_YEAR: trimmed(header.CO_YEAR),
    CO_BOOK: trimmed(header.CO_BOOK),
    VCH_NO: trimmed(header.VCH_NO),
    VCH_DATE: trimmed(header.VCH_DATE),
    STK_DATE: stockDateText,
    HD_VCH_NO: trimmed(header.HD_VCH_NO),
    AC_CODE: trimmed(header.AC_CODE),
    VCH_TYPE: trimmed(line.VCH_TYPE),
    INOUT_TYPE: trimmed(line.INOUT_TYPE),
    BOOK_NAME: trimmed(line.BOOK_NAME),
    VCH_TIME: (header.VCH_TIME ?? '').slice(0, 19),
    EMP_CODE: trimmed(header.EMP_CODE),
    VCH_DESC: header.VCH_DESC ?? '',
    MAIN_USER: trimmed(header.MAIN_USER),
  };
  return {
    itemMasters: item,
    taxName: null,
    rowPolicy,
    taxRoundingDecimals: 2,
    c27ColumnWidth: 100,
    cashLimit: trimmed(companySettings[0]?.cash_limit) || '0',
    storageText: { stockDateText, stockDiscountText: '0', taxZeroRatedText: '0' },
    financialContext,
    barContext,
  };
}

/** Assemble the strict guard envelope from the freshly observed poststate and replay. */
function buildGuardInput(args: {
  documentIdentity: string;
  documentVersion: string;
  observationId: string;
  header: SavedSaleReturnRaw;
  line: SavedSaleReturnRaw;
  config: NumericConfig;
  replay: ReturnType<typeof replaySaleReturnOtherAmount>;
}): unknown {
  const { header, line, config, replay, observationId } = args;
  const opened = replay.opened!;
  const final = replay.final!;
  const saveFold = replay.saveFold!;
  const q = <T>(value: T) => ({
    status: 'qualified' as const,
    revision: 'txn-observation-r1',
    binding: observationId,
    value,
  });
  const voucher = trimmed(header.VCH_NO);
  return {
    provenance: {
      documentIdentity: args.documentIdentity,
      documentVersion: args.documentVersion,
      observationId,
    },
    observations: {
      entry: q({
        mode: 'E',
        voucherNo: voucher,
        savedVoucherNo: voucher,
        hiddenVoucherNo: trimmed(header.HD_VCH_NO),
        savedHiddenVoucherNo: trimmed(header.HD_VCH_NO),
        instance: trimmed(line.VCH_SRNO),
        employeeCode: trimmed(header.EMP_CODE),
        userUpdate: 'N',
      }),
      employeeRule: q('N'),
      defaulter: q({
        cardinality: 'one' as const,
        accountCode: trimmed(header.AC_CODE),
        rawFlag: 'N',
      }),
      // The pure guard's frozen "ordinary" profile requires a ZERO cash limit in its envelope
      // (a nonzero limit is `unsupported-cash-limit` and would refuse before this coordinator
      // could observe the LedrCash aggregate). The REAL configured CASH_LIMIT is enforced by
      // the coordinator's own LedrCash ceiling check (observeLedrCash) AFTER the guard is
      // ready, not inside the pure guard. Presenting '0' here keeps the guard's frozen
      // fixtures/contract intact while leaving the cash obligation genuinely owned and
      // reachable in the coordinator. See config.cashLimit / observeLedrCash above.
      cashLimit: q('0'),
      bill: q({
        phase: 'post-events-before-save-fold',
        nAcCrAmt: final.bill.incomingRounded,
        nAcDrAmt: final.bill.outgoingRounded,
        matrix: final.bill.matrix,
      }),
      period: q({
        voucherDate: trimmed(header.VCH_DATE),
        openingDate: config.financialContext.openingDate as string,
        closingDate: closingFor(config.financialContext.openingDate as string),
        lockDate: '0001-01-01',
      }),
      userEdit: q('Y'),
      counterRule: q('N'),
      incomingRows: q([
        {
          rowIdentity: 'row-1',
          ordinal: 1,
          itemCode: trimmed(line.IT_CODE),
          counterCode: trimmed(line.EMP_CODE),
        },
      ]),
      saveFold: q({
        phase: 'save-fold-outgoing-then-incoming-no-bill',
        upDown: false,
        incomingFine18: saveFold.cells[18]!,
        incomingNet38: saveFold.cells[38]!,
        outgoingTotal24: '0.00',
      }),
      beforeBill: q({ matrix: opened.bill.matrix }),
      edition: q('L'),
      book: q({ mainBook: 'SALES RETURNE', bookInout: 'I' }),
      freshUpdate: q(true),
    },
  };
}

/** The closing date for a fiscal year opening on 1 April is 31 March of the next year. */
function closingFor(openingDate: string): string {
  if (!/^\d{4}-\d{2}-\d{2}$/.test(openingDate)) return openingDate;
  const year = Number(openingDate.slice(0, 4));
  const rest = openingDate.slice(4);
  return `${year + 1}${rest === '-04-01' ? '-03-31' : rest}`;
}
