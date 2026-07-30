import { withTenant } from '@datacare/db';
import {
  accountCodeHasConfiguredLength,
  resolveSettingsBehaviorTx,
} from '../shared/settingsBehavior.js';

/** Declarative config for a master table (Req 8). Column names are consistent across the
 * denormalized schema, so referential guards match referencing tables by the same key columns. */
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';

export interface FormFieldOption {
  value: string;
  label: string;
}
export interface FormField {
  col: string;
  label: string;
  type?: 'text' | 'number' | 'select' | 'lookup' | 'date';
  options?: FormFieldOption[]; // for type 'select'
  entity?: string; // for type 'lookup' — LookupPicker /lookup/:entity source
  fill?: { col: string; from: string }[]; // on lookup pick, copy row[from] → form[col] (e.g. AC_GR → AC_MAIN_GR)
  group?: string; // logical section/tab for the New/Edit form (General/Address/Tax & GST/…)
}
export interface MasterConfig {
  table: string;
  keyColumns: string[]; // business key (excludes tenant_id), e.g. ["CO_CODE","AC_CODE"]
  requiredColumns: string[];
  references?: string[]; // tables that reference this master via the same key columns
  formFields?: FormField[]; // rich ordered field set (label+type) the New/Edit form renders; keyColumns stay required
  /**
   * Verbatim desktop message for a specific missing column, e.g. AC_MAST.AC_NAME reports
   * `Please Insert Party Name ...` exactly as `MS_ACCT.cs` does. Columns without an entry keep the
   * generic `missing-required:` form, so operators see desktop wording wherever the desktop has it.
   */
  columnMessages?: Record<string, string>;
  /**
   * Verbatim desktop message when a delete arrives without the record selected, e.g. MS_PRODUCT's
   * `Please Select Product For Delete.` The desktop checks its own key textbox before deleting.
   */
  deleteSelectionMessage?: string;
  /** Verbatim desktop message for a repeated business key, e.g. MS_STYLE's name-already-exists guard. */
  duplicateMessage?: string;
  /**
   * Per-column value rules that are not simple presence checks. Each carries the desktop's exact
   * condition so the comparison direction cannot drift — e.g. MS_PRODUCT rejects a product code of
   * length exactly 1 (`Len(tPrCode.Text) = 1`), which is NOT the same as "must be 2 characters":
   * a blank code is reported by its own presence guard instead.
   */
  columnRules?: ReadonlyArray<{
    column: string;
    message: string;
    invalid: (value: string) => boolean;
  }>;
  /**
   * Refuse to save once a dependent table already holds more than `maxRows` rows for the company,
   * because editing the master would invalidate those records. MS_MFG_MAST.cs does exactly this with
   * `DC_Main.Tbl.Rows.Count > 10` against MFG_DATA.
   */
  saveGuards?: ReadonlyArray<{ table: string; maxRows: number; message: string }>;
  /**
   * Generated columns deliberately kept OFF the form, each with the reason.
   *
   * This exists because `formFields` used to REPLACE the generated column set, which silently hid 127
   * columns across nine masters — including `DG_GOLD_MAST.GOLD_CONV`, `AD_MAST.SCHM_AMT` and
   * `ITEM_MAST.IT_GHT_PRC`, all of which the desktop does expose. Omission is now an explicit,
   * reviewable act: `resolveFormFields` merges everything generated, and `masterFormFields.test.ts`
   * fails if a generated column is neither rendered, scope-injected, nor listed here with a reason.
   *
   * Reasons are evidence, not opinion: `desktop_editable_columns.py` reads which columns the desktop
   * binds to a control, so a column listed here is one the desktop itself never lets an operator type.
   */
  nonFormColumns?: Record<string, string>;
}

/** Classify a column into a logical form section/tab (runtime mirror of gen_master_formfields.mjs). */
export function groupForColumn(col: string): string {
  const c = col.toUpperCase();
  if (/^BANK|IFSC|RTGS/.test(c)) return 'Bank';
  if (/GST|PAN|LST|CST|TIN|VAT|ADHAR|AADHAR|HSN|TDS|TCS/.test(c)) return 'Tax & GST';
  if (/MOBILE|PHONE|TEL|EMAIL|MAIL|FAX|WEB|URL/.test(c)) return 'Contact';
  if (/ADD\d?$|_ADD|^ADD|CITY|PIN|STATE|AREA|DISTRICT|COUNTRY|ZIP|NOMINEE/.test(c))
    return 'Address';
  if (/DATE|BIRTH|ANV|DOB|JOIN|EXP|L_BR/.test(c)) return 'Dates';
  if (/OP_|OPEN|_BAL|BALANCE|CR_DAYS|LIMIT|INT_|_INT$|CREDIT|DEBIT|DISC|BONUS|AMT/.test(c))
    return 'Balances & Terms';
  if (/CODE$|_CODE|NAME|SHORT|^CO_|^LC_|GR_|_GR$|TYPE$|MELT|TOUCH|WEST/.test(c)) return 'General';
  return 'Other';
}

/** Fill a group on any FormField lacking one (so curated + generated configs both render tabbed). */
export function withGroups(fields: FormField[]): FormField[] {
  return fields.map((f) => (f.group ? f : { ...f, group: groupForColumn(f.col) }));
}

export class ValidationError extends Error {
  constructor(
    public missing: string[],
    /** Verbatim desktop wording when the config supplies one for the first missing column. */
    desktopMessage?: string,
  ) {
    super(desktopMessage ?? 'missing-required: ' + missing.join(','));
    this.name = 'ValidationError';
  }
}

/** First desktop message among the missing columns, in the config's own column order. */
export function desktopMessageFor(config: MasterConfig, missing: string[]): string | undefined {
  const messages = config.columnMessages;
  if (!messages) return undefined;
  for (const col of missing) if (messages[col]) return messages[col];
  return undefined;
}
export class DeleteSelectionError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ValidationError';
  }
}
export class DuplicateKeyError extends Error {
  constructor(desktopMessage?: string) {
    super(desktopMessage ?? 'duplicate-key');
    this.name = 'DuplicateKeyError';
  }
}
export class ReferencedError extends Error {
  constructor(public ref: string) {
    super('referenced-by:' + ref);
    this.name = 'ReferencedError';
  }
}
export class DataError extends Error {
  constructor(public detail: string) {
    super(detail);
    this.name = 'DataError';
  }
}
export class NotFoundError extends Error {
  constructor() {
    super('not-found');
    this.name = 'NotFoundError';
  }
}

/** Extract a human-readable message from a Prisma raw-query DB error. */
function dbErrorDetail(e: unknown): string {
  const msg = String((e as { message?: string })?.message ?? '');
  const m = msg.match(/Message: `([^`]+)`/) ?? msg.match(/ERROR:\s*([^\n]+)/);
  return (m?.[1] ?? 'invalid-data').replace(/^ERROR:\s*/, '').trim();
}

const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';

// ---- pure builders (Tier-1 testable, no DB) ----
/** Apply the config's non-presence column rules, reporting the desktop's own wording. */
export function assertColumnRules(config: MasterConfig, data: Record<string, unknown>): void {
  for (const rule of config.columnRules ?? []) {
    const raw = data[rule.column];
    if (raw === undefined || raw === null) continue;
    if (rule.invalid(String(raw).trim())) throw new ValidationError([rule.column], rule.message);
  }
}

export function findMissingRequired(config: MasterConfig, data: Record<string, unknown>): string[] {
  return config.requiredColumns.filter((c) => {
    const v = data[c];
    return v === undefined || v === null || v === '';
  });
}

export interface MasterScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
}

const configuredColumns = (config: MasterConfig): Set<string> =>
  new Set([
    ...config.keyColumns,
    ...config.requiredColumns,
    ...(config.formFields ?? []).map((field) => field.col),
  ]);

/** Force denormalized business-scope columns to the authenticated context. */
/** Key columns the server fills from the active business scope, never typed by the operator. */
const SCOPE_COLUMNS = new Set(['CO_CODE', 'LC_CODE', 'CO_YEAR']);

/**
 * The form field set for a master: generated columns MERGED WITH explicit metadata.
 *
 * The previous expression was `cfg.formFields ?? GENERATED_FORM_FIELDS[cfg.table]`, so supplying any
 * explicit list discarded every generated column that list did not mention. That is why digital gold,
 * schemes, groups, items, accounts, companies, addresses and counters lost fields.
 *
 * Merge order is deliberate: explicit entries come FIRST and in their authored order, because that order
 * was chosen to match the desktop's tab layout. Generated-only columns follow, so a newly added database
 * column appears automatically instead of vanishing. Explicit metadata (label/type/options/entity/fill/
 * group) overrides the generated defaults for the same column.
 *
 * Scope columns are dropped because the server injects them from the session (`applyScope`), so rendering
 * them would invite an operator to contradict their own login scope.
 */
export function resolveFormFields(
  cfg: MasterConfig,
  generated?: readonly FormField[],
): FormField[] | null {
  const explicit = cfg.formFields ?? [];
  const gen = generated ?? [];
  if (!explicit.length && !gen.length) return null;

  const excluded = new Set(Object.keys(cfg.nonFormColumns ?? {}));
  const keep = (col: string): boolean => !SCOPE_COLUMNS.has(col) && !excluded.has(col);

  const byCol = new Map<string, FormField>();
  for (const f of gen) if (keep(f.col)) byCol.set(f.col, f);

  const out: FormField[] = [];
  const seen = new Set<string>();
  for (const f of explicit) {
    if (seen.has(f.col)) continue; // an authored duplicate would render the same column twice
    seen.add(f.col);
    // An explicitly authored column is rendered even if it is scope/excluded elsewhere: the author asked
    // for it by name, so honour that rather than silently dropping it.
    const base = byCol.get(f.col);
    out.push(base ? { ...base, ...f } : f);
  }
  for (const f of gen) {
    if (seen.has(f.col) || !keep(f.col)) continue;
    seen.add(f.col);
    out.push(f);
  }
  return out;
}

export function bindMasterScope(
  config: MasterConfig,
  scope: MasterScope,
  source: Record<string, unknown>,
): Record<string, unknown> {
  const data = { ...source };
  const columns = configuredColumns(config);
  if (columns.has('CO_CODE')) data.CO_CODE = scope.coCode;
  if (columns.has('LC_CODE')) {
    if (!scope.lcCode) throw new ValidationError(['LC_CODE']);
    data.LC_CODE = scope.lcCode;
  }
  delete data.tenant_id;
  delete data.tenantId;
  return data;
}

function masterScopeWhere(
  config: MasterConfig,
  scope: MasterScope,
): { sql: string; params: unknown[] } {
  const columns = configuredColumns(config);
  const parts: string[] = [];
  const params: unknown[] = [];
  if (columns.has('CO_CODE')) {
    params.push(scope.coCode);
    parts.push(`"CO_CODE"::text=$${params.length}::text`);
  }
  if (columns.has('LC_CODE')) {
    if (!scope.lcCode) throw new ValidationError(['LC_CODE']);
    params.push(scope.lcCode);
    parts.push(`"LC_CODE"::text=$${params.length}::text`);
  }
  return { sql: parts.length ? ` WHERE ${parts.join(' AND ')}` : '', params };
}

export function buildInsert(
  config: MasterConfig,
  tenantId: string,
  data: Record<string, unknown>,
): { sql: string; params: unknown[] } {
  const cols = Object.keys(data);
  const colSql = ['tenant_id', ...cols.map(q)].join(',');
  const placeholders = cols.map((_, i) => '$' + (i + 2)).join(',');
  const sql = `INSERT INTO ${q(config.table)}(${colSql}) VALUES ($1${placeholders ? ',' + placeholders : ''})`;
  return { sql, params: [tenantId, ...cols.map((c) => data[c])] };
}

export function buildKeyWhere(
  config: MasterConfig,
  key: Record<string, unknown>,
): { where: string; params: unknown[] } {
  const where = config.keyColumns.map((k, i) => `${q(k)}::text=$${i + 1}::text`).join(' AND ');
  return { where, params: config.keyColumns.map((k) => key[k]) };
}

/** UPDATE the non-key columns present in `data` for the row identified by the key columns (Req 8.4).
 *  Key columns are immutable (used only in WHERE); tenant_id is never updated. */
export function buildUpdate(
  config: MasterConfig,
  key: Record<string, unknown>,
  data: Record<string, unknown>,
): { sql: string; params: unknown[]; setCols: string[] } {
  const keySet = new Set([...config.keyColumns, 'tenant_id']);
  const setCols = Object.keys(data).filter((c) => !keySet.has(c));
  const { where, params: keyParams } = buildKeyWhere(config, key);
  const setSql = setCols.map((c, i) => `${q(c)}=$${keyParams.length + 1 + i}`).join(', ');
  const sql = `UPDATE ${q(config.table)} SET ${setSql} WHERE ${where}`;
  return { sql, params: [...keyParams, ...setCols.map((c) => data[c])], setCols };
}

export function buildDuplicateCheck(config: MasterConfig, key: Record<string, unknown>) {
  const { where, params } = buildKeyWhere(config, key);
  return { sql: `SELECT 1 FROM ${q(config.table)} WHERE ${where} LIMIT 1`, params };
}

export function buildDeleteGuards(config: MasterConfig, key: Record<string, unknown>) {
  const { where, params } = buildKeyWhere(config, key);
  return (config.references ?? []).map((ref) => ({
    ref,
    sql: `SELECT 1 FROM ${q(ref)} WHERE ${where} LIMIT 1`,
    params,
  }));
}

/** Enforce the config's dependent-row thresholds, reporting the desktop's own wording. */
export async function assertSaveGuardsTx(
  tx: any,
  scope: MasterScope,
  config: MasterConfig,
): Promise<void> {
  for (const guard of config.saveGuards ?? []) {
    const rows: Array<{ n: number }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM ${q(guard.table)} WHERE "CO_CODE"=$1`,
      scope.coCode,
    );
    if (Number(rows[0]?.n ?? 0) > guard.maxRows) throw new DataError(guard.message);
  }
}

// ---- live ops (Tier-2) ----
export async function createMaster(
  prisma: any,
  scope: MasterScope,
  config: MasterConfig,
  source: Record<string, unknown>,
): Promise<{ created: true }> {
  const data = bindMasterScope(config, scope, source);
  const missing = findMissingRequired(config, data);
  if (missing.length) throw new ValidationError(missing, desktopMessageFor(config, missing));
  assertColumnRules(config, data);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertSaveGuardsTx(tx, scope, config);
    if (config.table === 'AC_MAST') {
      const behavior = await resolveSettingsBehaviorTx(tx, scope);
      if (!accountCodeHasConfiguredLength(data.AC_CODE, behavior.accountCodeLength))
        throw new DataError('AC_CODE does not match CO_SET.AC_LC_CODE_LEN'); // MS_ACCT.cs:6285,7741
    }
    const dup = buildDuplicateCheck(config, data);
    const exists: unknown[] = await tx.$queryRawUnsafe(dup.sql, ...dup.params);
    if (exists.length) throw new DuplicateKeyError(config.duplicateMessage);
    const ins = buildInsert(config, scope.tenantId, data);
    try {
      await tx.$executeRawUnsafe(ins.sql, ...ins.params);
    } catch (e) {
      throw new DataError(dbErrorDetail(e));
    }
    return { created: true };
  });
}

/** Update a master row by its business key (Req 8.4). Key columns identify the row (immutable);
 *  the remaining columns in `data` are SET. Guards: key present, row exists, no required column blanked. */
export async function updateMaster(
  prisma: any,
  scope: MasterScope,
  config: MasterConfig,
  source: Record<string, unknown>,
): Promise<{ updated: true }> {
  const data = bindMasterScope(config, scope, source);
  // The key columns must be present to identify the row.
  const missingKey = config.keyColumns.filter((k) => {
    const v = data[k];
    return v === undefined || v === null || v === '';
  });
  if (missingKey.length) throw new ValidationError(missingKey);
  // A required column may not be explicitly blanked by the update.
  const blanked = config.requiredColumns.filter(
    (c) => c in data && (data[c] === null || data[c] === ''),
  );
  if (blanked.length) throw new ValidationError(blanked, desktopMessageFor(config, blanked));
  const built = buildUpdate(config, data, data);
  if (!built.setCols.length) throw new ValidationError(['(no updatable columns supplied)']);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    if (config.table === 'AC_MAST' && data.AC_CODE != null) {
      const behavior = await resolveSettingsBehaviorTx(tx, scope);
      if (!accountCodeHasConfiguredLength(data.AC_CODE, behavior.accountCodeLength))
        throw new DataError('AC_CODE does not match CO_SET.AC_LC_CODE_LEN'); // MS_ACCT.cs:8800
    }
    const chk = buildDuplicateCheck(config, data);
    const exists: unknown[] = await tx.$queryRawUnsafe(chk.sql, ...chk.params);
    if (!exists.length) throw new NotFoundError();
    try {
      await tx.$executeRawUnsafe(built.sql, ...built.params);
    } catch (e) {
      throw new DataError(dbErrorDetail(e));
    }
    return { updated: true };
  });
}

export async function deleteMaster(
  prisma: any,
  scope: MasterScope,
  config: MasterConfig,
  source: Record<string, unknown>,
): Promise<{ deleted: true }> {
  if (config.deleteSelectionMessage) {
    // Desktop masters check their own key textbox before deleting (MS_PRODUCT.cs etc.).
    const unselected = config.keyColumns.filter(
      (col) => !SCOPE_COLUMNS.has(col) && String(source[col] ?? '').trim() === '',
    );
    if (unselected.length) throw new DeleteSelectionError(config.deleteSelectionMessage);
  }
  const key = bindMasterScope(config, scope, source);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    for (const g of buildDeleteGuards(config, key)) {
      const r: unknown[] = await tx.$queryRawUnsafe(g.sql, ...g.params);
      if (r.length) throw new ReferencedError(g.ref);
    }
    const { where, params } = buildKeyWhere(config, key);
    await tx.$executeRawUnsafe(`DELETE FROM ${q(config.table)} WHERE ${where}`, ...params);
    return { deleted: true };
  });
}

const jsonSafe = (rows: Record<string, unknown>[]): Record<string, unknown>[] =>
  rows.map((r) =>
    Object.fromEntries(
      Object.entries(r).map(([k, v]) => [k, typeof v === 'bigint' ? v.toString() : v]),
    ),
  );

export async function listMaster(
  prisma: any,
  scope: MasterScope,
  config: MasterConfig,
  limit = 100,
): Promise<Record<string, unknown>[]> {
  const n = Math.min(Number(limit) || 100, 500);
  const where = masterScopeWhere(config, scope);
  const rows: Record<string, unknown>[] = await withTenant(prisma, scope.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(`SELECT * FROM ${q(config.table)}${where.sql} LIMIT ${n}`, ...where.params),
  );
  return jsonSafe(rows);
}

export const AC_MAST_CONFIG: MasterConfig = {
  // Desktop-evidence exclusions: desktop_editable_columns.py found no control binding
  // for these, so the desktop never lets an operator type them.
  nonFormColumns: {
    AC_PARSON:
      'not bound to any MS_ACCT control (the desktop spells its own contact field AC_PERSON)',
  },
  table: 'AC_MAST',
  keyColumns: ['CO_CODE', 'AC_CODE'],
  requiredColumns: ['CO_CODE', 'AC_CODE', 'AC_NAME'],
  deleteSelectionMessage: DESKTOP_MESSAGES.ACCOUNT_SELECT_FOR_DELETE,
  // MS_ACCT.cs reports the blank name in these exact words.
  columnMessages: { AC_NAME: DESKTOP_MESSAGES.PARTY_NAME_REQUIRED },
  references: ['AC_DATA'],
  // Party Master (desktop MS_ACCT) — full editable field set.
  formFields: [
    { col: 'CO_CODE', label: 'Company' },
    { col: 'AC_CODE', label: 'Account Code' },
    { col: 'AC_NAME', label: 'Account Name' },
    {
      col: 'AC_GR',
      label: 'Account Group',
      type: 'lookup',
      entity: 'ac-groups',
      fill: [{ col: 'AC_MAIN_GR', from: 'AC_MAIN_GR' }],
    },
    { col: 'AC_MAIN_GR', label: 'Main Group' },
    { col: 'AC_SHORT', label: 'Short Name' },
    { col: 'AC_PERSON', label: 'Contact Person' },
    { col: 'AC_MOBILE', label: 'Mobile' },
    { col: 'AC_MOBILE2', label: 'Mobile 2' },
    { col: 'AC_PHONE', label: 'Phone' },
    { col: 'AC_PHONE2', label: 'Phone 2' },
    { col: 'AC_ADD1', label: 'Address 1' },
    { col: 'AC_ADD2', label: 'Address 2' },
    { col: 'AC_ADD3', label: 'Address 3' },
    { col: 'AC_CITY', label: 'City' },
    { col: 'AC_AREA', label: 'Area' },
    { col: 'AC_PIN', label: 'Pin Code' },
    { col: 'AC_STATE', label: 'State' },
    { col: 'AC_DISTRICT', label: 'District' },
    { col: 'AC_COUNTRY', label: 'Country' },
    { col: 'AC_GSTNO', label: 'GSTIN' },
    {
      col: 'AC_GST_TYPE',
      label: 'GST Type',
      type: 'select',
      options: [
        { value: 'L', label: 'Local (CGST+SGST)' },
        { value: 'I', label: 'Inter-state (IGST)' },
      ],
    },
    { col: 'AC_PANNO', label: 'PAN' },
    { col: 'AC_ADHAR_NO', label: 'Aadhaar' },
    { col: 'AC_EMAIL', label: 'Email' },
    {
      col: 'AC_REF_CODE',
      label: 'Referred By',
      type: 'lookup',
      entity: 'accounts',
      fill: [{ col: 'AC_REF_NAME', from: 'name' }],
    },
    { col: 'AC_REF_NAME', label: 'Referred-By Name' },
    { col: 'AC_KHATA_NO', label: 'Khata No' },
    { col: 'BR_DATE', label: 'Birth Date', type: 'date' },
    { col: 'AN_DATE', label: 'Anniversary', type: 'date' },
    { col: 'AC_CR_DAYS', label: 'Credit Days', type: 'number' },
    { col: 'AC_INT_PRC', label: 'Interest %', type: 'number' },
    { col: 'DPC_PRC', label: 'DPC %', type: 'number' },
    { col: 'AMT_LIMIT', label: 'Amount Limit', type: 'number' },
    { col: 'GOLD_LIMIT', label: 'Gold Limit', type: 'number' },
    { col: 'SILVER_LIMIT', label: 'Silver Limit', type: 'number' },
    { col: 'BANK_NAME', label: 'Bank Name' },
    { col: 'BANK_AREA', label: 'Bank Branch' },
    { col: 'BANK_AC_NO', label: 'Bank A/c No' },
    { col: 'BANK_RTGS_NO', label: 'IFSC' },
    { col: 'AC_TYPE', label: 'Account Type' },
  ],
};
export const ITEM_MAST_CONFIG: MasterConfig = {
  // Desktop-evidence exclusions: desktop_editable_columns.py found no control binding
  // for these, so the desktop never lets an operator type them.
  nonFormColumns: {
    AVG_FINE: 'running average maintained by posting, never typed on MS_ITEM',
    AVG_NWT: 'running average maintained by posting, never typed on MS_ITEM',
    AVG_RATE: 'running average maintained by posting, never typed on MS_ITEM',
    AVG_TOUCH: 'running average maintained by posting, never typed on MS_ITEM',
    BULK_SALE: 'not bound to any MS_ITEM control',
    MRP_DISC_PRC: 'not bound to any MS_ITEM control',
    OP_FINE: 'opening fine is set by the opening-balance form, not MS_ITEM',
    OP_TOUCH: 'opening touch is set by the opening-balance form, not MS_ITEM',
    PCS_RATE: 'maintained by posting, never typed on MS_ITEM',
    TOT_PCS: 'maintained by posting, never typed on MS_ITEM',
  },
  table: 'ITEM_MAST',
  keyColumns: ['CO_CODE', 'IT_CODE'],
  requiredColumns: ['CO_CODE', 'IT_CODE', 'IT_NAME'],
  columnMessages: { IT_NAME: DESKTOP_MESSAGES.ITEM_NAME_REQUIRED },
  deleteSelectionMessage: DESKTOP_MESSAGES.ITEM_SELECT_FOR_DELETE,
  references: ['SL_DETL'],
  // Item Master (desktop MS_ITEM) — full editable field set.
  formFields: [
    { col: 'CO_CODE', label: 'Company' },
    { col: 'IT_CODE', label: 'Item Code' },
    { col: 'IT_NAME', label: 'Item Name' },
    { col: 'PR_CODE', label: 'Product', type: 'lookup', entity: 'products' },
    { col: 'GR_CODE', label: 'Group', type: 'lookup', entity: 'groups' },
    {
      col: 'IT_TYPE',
      label: 'Metal',
      type: 'select',
      options: [
        { value: 'G', label: 'Gold' },
        { value: 'S', label: 'Silver' },
      ],
    },
    { col: 'IT_TOUCH', label: 'Touch %', type: 'number' },
    { col: 'IT_WEST', label: 'Wastage %', type: 'number' },
    { col: 'IT_LBR_RATE', label: 'Labour Rate', type: 'number' },
    { col: 'LBR_PRC', label: 'Labour %', type: 'number' },
    { col: 'HSN_CODE', label: 'HSN Code' },
    { col: 'UNIT_NAME', label: 'Unit' },
    { col: 'RATE_TYPE', label: 'Rate Per' },
    { col: 'ITEM_RATE', label: 'Item Rate', type: 'number' },
    { col: 'OTHER_RATE', label: 'Other Rate', type: 'number' },
    { col: 'CON_PRC', label: 'Conversion %', type: 'number' },
    { col: 'DISC_PRC', label: 'Discount %', type: 'number' },
    { col: 'IT_BAG_WT', label: 'Bag Weight', type: 'number' },
    { col: 'SAFE_NAME', label: 'Safe' },
    { col: 'STK_DISPLAY', label: 'Stock Display' },
    { col: 'MIN_STK', label: 'Min Stock', type: 'number' },
  ],
};

/** Bulk import master rows (CSV) — each row is its own tx via createMaster, so failures are isolated.
 *  Returns counts + the first 20 per-row errors. Desktop UT_IMPORT. */
export async function importMaster(
  prisma: any,
  scope: MasterScope,
  config: MasterConfig,
  rows: Record<string, unknown>[],
): Promise<{ created: number; failed: number; errors: { row: number; error: string }[] }> {
  let created = 0;
  let failed = 0;
  const errors: { row: number; error: string }[] = [];
  for (let i = 0; i < rows.length; i++) {
    try {
      await createMaster(prisma, scope, config, rows[i] ?? {});
      created++;
    } catch (e) {
      failed++;
      const msg =
        e instanceof ValidationError
          ? 'missing: ' + e.missing.join(',')
          : e instanceof DuplicateKeyError
            ? 'duplicate key'
            : e instanceof ReferencedError
              ? 'referenced'
              : e instanceof DataError
                ? e.detail
                : 'error';
      if (errors.length < 20) errors.push({ row: i + 1, error: msg });
    }
  }
  return { created, failed, errors };
}
