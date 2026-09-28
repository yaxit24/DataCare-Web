import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import type { SavedSaleReturnRaw, SavedSaleReturnScope } from './savedSaleReturn.js';

type Raw = SavedSaleReturnRaw;
export type SaleReturnIncomingConfigurationRow = {
  raw: Raw;
  revision: string;
  locator: string;
  physicalId: string | null;
};
/** Server observations only. Neither this input nor an effective policy is accepted from HTTP. */
export type SaleReturnIncomingConfigurationObservations = {
  settings: SaleReturnIncomingConfigurationRow[];
  newSettings: SaleReturnIncomingConfigurationRow[];
  columns: SaleReturnIncomingConfigurationRow[];
  books: SaleReturnIncomingConfigurationRow[];
  years: SaleReturnIncomingConfigurationRow[];
  edition?:
    | { state: 'unresolved' }
    | { state: 'resolved'; value: 'L' | 'B' | 'S' | 'U' | 'P' | 'A' | 'E'; version: string };
};
export type SaleReturnIncomingConfigurationColumn = {
  id: string;
  sourceColumn: number;
  sourceName: string | null;
  storageField: string | null;
  nominalWidth: number;
  widthState: 'zero' | 'nonzero' | 'unresolved';
  label: string | null;
  originalLabel: string | null;
  configured: boolean;
  forcedVisible: boolean;
  commitKind: 'text' | 'integer' | 'decimal2' | 'decimal3' | 'admission' | 'none';
};
export type SaleReturnIncomingConfiguration = {
  scope: Omit<SavedSaleReturnScope, 'tenantId'>;
  form: 'TR_SALE_RTN';
  grid: 'MSG_PR';
  columnFamily: 'SALES RETURNE';
  contractVersion: 'x13-primary-incoming-config-v1';
  version: string;
  policy: null | {
    saleAmountType: string;
    labourRoundingDecimals: number;
    labourIncludesGhat: boolean;
    generateLabourRate: boolean;
    fineColumnWidth: number;
  };
  newRowDefaults: { labourType: string | null };
  widthMode: 'source-zero-predicate';
  columns: SaleReturnIncomingConfigurationColumn[];
  rawSettings: Raw;
  diagnostics: Array<{ code: string; fieldId?: string; message: string; blocking: boolean }>;
  /** Calculation applies only to resolved catalog fields; it grants no mutation authority. */
  capabilities: { canCalculate: boolean; canSaveNumeric: false };
};
export class SaleReturnIncomingConfigurationError extends Error {
  constructor(
    public readonly statusCode: 400 | 422,
    public readonly code: string,
    message: string,
  ) {
    super(message);
    this.name = 'SaleReturnIncomingConfigurationError';
  }
}

const FORM = 'TR_SALE_RTN' as const;
const FAMILY = 'SALES RETURNE' as const;
const CONTRACT = 'x13-primary-incoming-config-v1' as const;
const fieldId = (index: number) => `x13.primary-incoming.c${String(index).padStart(2, '0')}`;
type Definition = readonly [
  string,
  number,
  string,
  SaleReturnIncomingConfigurationColumn['commitKind'],
];
// TR_SALE_RTN MSG_PR_CLEAR:3577–3703; final Sr/RecCode widths:3758–3759.
const definitions: readonly Definition[] = [
  ['Sr', 325, 'SR_NO', 'text'],
  ['RecCode', 300, 'IT_CODE', 'admission'],
  ['TagNo', 1100, 'TAG_NO', 'text'],
  ['Receive Item', 2200, 'ITM_REMARK', 'text'],
  ['Counter', 900, 'TBL_CODE', 'text'],
  ['Design', 1300, 'DESIGN_NO', 'text'],
  ['Style', 1200, 'ITM_STYLE', 'text'],
  ['Size', 800, 'ITM_SIZE', 'text'],
  ['HmId', 900, 'HM_ID', 'text'],
  ['Pcs', 700, 'ITM_PCS', 'integer'],
  ['GrWt', 1100, 'ITM_GWT', 'decimal3'],
  ['OthWt', 900, 'ITM_OTH_WT', 'decimal3'],
  ['NetWt', 1100, 'ITM_NWT', 'decimal3'],
  ['LCode', 800, 'LBR_CODE', 'text'],
  ['Ght%', 900, 'ITM_GHT_PRC', 'decimal2'],
  ['GhtWt', 900, 'ITM_GHT_WT', 'decimal3'],
  ['Touch', 750, 'ITM_TOUCH', 'decimal2'],
  ['West%', 800, 'ITM_WEST_PRC', 'decimal2'],
  ['Fine', 1000, 'ITM_FINE', 'decimal3'],
  ['Rate', 1000, 'ITM_RATE', 'decimal2'],
  ['ItAmt', 1100, 'ITM_AMT', 'decimal2'],
  ['Lbr%', 800, 'LBR_PRC', 'decimal2'],
  ['Ltype', 750, 'LBR_TYPE', 'text'],
  ['LRate', 900, 'LBR_RATE', 'decimal2'],
  ['LAmt', 1000, 'LBR_AMT', 'decimal2'],
  ['LDisc%', 850, 'DISC_PRC', 'decimal2'],
  ['LDiscAmt', 950, 'DISC_AMT', 'decimal2'],
  ['OthAmt', 1000, 'OTH_AMT', 'decimal2'],
  ['RtnMrp', 1100, 'ITM_MRP', 'decimal2'],
  ['TgLCode', 800, 'TAG_LBR_CODE', 'text'],
  ['Tag%', 900, 'TAG_LBR_PRC', 'decimal2'],
  ['TagLRate', 1000, 'TAG_LBR_RATE', 'decimal2'],
  ['TagLAmt', 1000, 'TAG_LBR_AMT', 'decimal2'],
  ['TagOtAmt', 1000, 'TAG_OTH_AMT', 'decimal2'],
  ['TagCost', 1000, 'TAG_COST', 'decimal2'],
  ['TagMrp', 1000, 'TAG_MRP', 'decimal2'],
  ['TotAmt', 1100, 'TOT_AMT', 'decimal2'],
  ['TaxPrc', 900, 'TAX_PRC', 'decimal2'],
  ['NetAmt', 1200, 'NET_AMT', 'decimal2'],
  ['KrCode', 900, 'KR_NAME', 'text'],
];
// 41/42 have leave handlers but no proved incoming heading/storage identity. Cache slots
// stay distinct from business fields and are never ordinary commit targets.
const hiddenFields: Readonly<Record<number, string>> = {
  40: 'VCH_SRNO',
  43: 'IT_TYPE',
  44: 'RATE_TYPE',
  50: 'APR_ISU',
  51: 'OLD_SRNO',
  52: 'PR_CODE',
  54: 'TAG_TYPE',
  56: 'TAG_SRNO',
  59: 'HM_ID2',
  60: 'HM_ID3',
  61: 'HM_ID4',
  62: 'HM_ID_WT',
  63: 'HM_ID2_WT',
  64: 'HM_ID3_WT',
  65: 'HM_ID4_WT',
  68: 'EMP_ISU',
  69: 'DESIGN_IMG_ID',
  70: 'DATA_TYPE',
};
export const SALE_RETURN_INCOMING_COLUMN_CATALOG: ReadonlyArray<
  Readonly<SaleReturnIncomingConfigurationColumn>
> = Object.freeze(
  Array.from({ length: 71 }, (_, sourceColumn) => {
    const definition = definitions[sourceColumn];
    const name = definition?.[0] ?? null;
    return Object.freeze({
      id: fieldId(sourceColumn),
      sourceColumn,
      sourceName: name,
      storageField: definition?.[2] ?? hiddenFields[sourceColumn] ?? null,
      nominalWidth: definition?.[1] ?? 0,
      widthState: sourceColumn === 6 ? 'unresolved' : definition ? 'nonzero' : 'zero',
      label: name,
      originalLabel: name,
      configured: false,
      forcedVisible: sourceColumn === 0 || sourceColumn === 1,
      commitKind: definition?.[3] ?? 'none',
    } satisfies SaleReturnIncomingConfigurationColumn);
  }),
);

const canonical = (value: unknown): string => {
  if (Array.isArray(value)) return `[${value.map(canonical).join(',')}]`;
  if (value && typeof value === 'object')
    return `{${Object.entries(value)
      .sort(([a], [b]) => a.localeCompare(b))
      .map(([key, item]) => `${JSON.stringify(key)}:${canonical(item)}`)
      .join(',')}}`;
  return JSON.stringify(value) ?? 'null';
};
const hash = (value: unknown) => createHash('sha256').update(canonical(value)).digest('hex');
const ordered = (rows: SaleReturnIncomingConfigurationRow[]) =>
  [...rows].sort((a, b) => canonical(a).localeCompare(canonical(b)));
const normalized = (value: string | null | undefined) =>
  (value ?? '').trim().replace(/\s+/g, ' ').toUpperCase();
const bookValue = (value: string | null | undefined) => (value ?? '').trim().toUpperCase();
const invalid = (message: string): never => {
  throw new SaleReturnIncomingConfigurationError(400, 'invalid-input', message);
};
const configurationError = (message: string): never => {
  throw new SaleReturnIncomingConfigurationError(422, 'configuration', message);
};
function validateScope(scope: SavedSaleReturnScope) {
  const keys = ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const;
  if (
    !scope ||
    typeof scope !== 'object' ||
    Array.isArray(scope) ||
    Object.keys(scope).some((key) => !keys.includes(key as (typeof keys)[number]))
  )
    invalid('A complete selected Return scope is required.');
  for (const [key, max] of [
    ['tenantId', 24],
    ['coCode', 2],
    ['lcCode', 2],
    ['coYear', 10],
    ['coBook', 3],
  ] as const) {
    const value = scope[key];
    if (
      typeof value !== 'string' ||
      !value ||
      value !== value.trim() ||
      [...value].length > max ||
      /[\u0000-\u001f]/.test(value)
    )
      invalid(`${key} must be explicit text of at most ${max} characters.`);
  }
}
const settingsFields = [
  'SL_AMT_TYPE',
  'LBR_ROF',
  'LBR_RATE_GEN',
  'ALL_ROF_REMOVE',
  'LBR_TYPE',
] as const;
const project = (rows: SaleReturnIncomingConfigurationRow[], fields: readonly string[]) =>
  rows.map((row) => ({
    ...row,
    raw: Object.fromEntries(['CO_CODE', ...fields].map((field) => [field, row.raw[field] ?? null])),
  }));

/** Pure, deterministic resolver of exact server-observed SQL text. No settings or data writes. */
export function resolveSaleReturnIncomingConfiguration(
  scope: SavedSaleReturnScope,
  observations: SaleReturnIncomingConfigurationObservations,
): SaleReturnIncomingConfiguration {
  validateScope(scope);
  const company = (row: SaleReturnIncomingConfigurationRow) => row.raw.CO_CODE === scope.coCode;
  const settings = ordered(project(observations.settings.filter(company), settingsFields));
  const newSettings = ordered(project(observations.newSettings.filter(company), ['LBR_WITH_GHT']));
  const books = ordered(
    observations.books.filter(
      (row) => company(row) && row.raw.LC_CODE === scope.lcCode && row.raw.CO_BOOK === scope.coBook,
    ),
  );
  const years = ordered(
    observations.years.filter((row) => company(row) && row.raw.CO_YEAR === scope.coYear),
  );
  if (books.length !== 1) configurationError('The selected Return book is missing or ambiguous.');
  const book = books[0]!.raw;
  // Conservatively treat imported lowercase n as inactive, as the source reader does. Unlike
  // generic bookPolicy's SQL filter, this strict observation also rejects any duplicate book row.
  if (bookValue(book.CUR_USE) === 'N') configurationError('The selected Return book is inactive.');
  if (bookValue(book.MAIN_BOOK) !== FAMILY)
    configurationError('The selected book must belong to SALES RETURNE.');
  // Match existing bookPolicy's compatibility for absent table/direction; explicit contradictions fail.
  if (bookValue(book.BOOK_TBL_NAME) && bookValue(book.BOOK_TBL_NAME) !== 'SL_DATA')
    configurationError('The selected Return book must use SL_DATA.');
  if (bookValue(book.BOOK_INOUT) && bookValue(book.BOOK_INOUT) !== 'I')
    configurationError('The selected Return book must have incoming direction.');
  if (years.length !== 1)
    configurationError('The selected Return year is missing or ambiguous in YEAR_MAST.');
  // Collect the entire company first: filtering exact family in SQL would hide imported collisions.
  const columnRows = ordered(
    observations.columns.filter((row) => company(row) && normalized(row.raw.BOOK_NAME) === FAMILY),
  );
  const edition = observations.edition ?? { state: 'unresolved' as const };
  const diagnostics: SaleReturnIncomingConfiguration['diagnostics'] = [];
  const diagnostic = (code: string, message: string, blocking = true, id?: string) => {
    diagnostics.push({ code, message, blocking, ...(id ? { fieldId: id } : {}) });
  };
  if (settings.length !== 1)
    diagnostic(
      'settings-row-count',
      'Exactly one company CO_SET row is required; reconcile missing or duplicate settings.',
    );
  if (newSettings.length !== 1)
    diagnostic(
      'new-settings-row-count',
      'Exactly one company CO_SET_NEW row is required; reconcile missing or duplicate settings.',
    );
  const rawSettings: Raw = Object.fromEntries(
    settingsFields.map((field) => [
      `CO_SET.${field}`,
      settings.length === 1 ? (settings[0]!.raw[field] ?? null) : null,
    ]),
  );
  rawSettings['CO_SET_NEW.LBR_WITH_GHT'] =
    newSettings.length === 1 ? (newSettings[0]!.raw.LBR_WITH_GHT ?? null) : null;
  function flag(key: string, fallback: string, values: string[]): string | null {
    const raw = rawSettings[key];
    if (raw === '') return fallback;
    if (typeof raw === 'string' && values.includes(raw)) return raw;
    diagnostic(
      'unsupported-setting',
      `${key} has an unsupported stored value; select a canonical setting before calculating.`,
    );
    return null;
  }
  const saleAmountType = flag('CO_SET.SL_AMT_TYPE', 'N', ['N', 'G', 'F', 'P']);
  const generate = flag('CO_SET.LBR_RATE_GEN', 'N', ['N', 'Y']);
  const remove = flag('CO_SET.ALL_ROF_REMOVE', 'N', ['N', 'Y']);
  const includesGhat = flag('CO_SET_NEW.LBR_WITH_GHT', 'Y', ['N', 'Y']);
  const labourType = flag('CO_SET.LBR_TYPE', 'G', ['N', 'G', 'P', 'K']);
  let precision: number | null = null;
  const rawPrecision = rawSettings['CO_SET.LBR_ROF'];
  // MS_OPNCOMP:691 CInt comes BEFORE :817 >3->0 and :1297 final ALL_ROF_REMOVE override.
  // Only exact integral SQL text within Int32 is proved here; malformed/fractional conversion is contained.
  if (
    typeof rawPrecision !== 'string' ||
    !/^-?(0|[1-9]\d*)$/.test(rawPrecision) ||
    !Number.isInteger(Number(rawPrecision)) ||
    Number(rawPrecision) < -2147483648 ||
    Number(rawPrecision) > 2147483647
  ) {
    diagnostic(
      'unsupported-labour-rounding',
      'Labour rounding must contain a supported whole Int32 value.',
    );
  } else {
    const sourcePrecision = Number(rawPrecision);
    precision = sourcePrecision > 3 ? 0 : sourcePrecision;
    if (remove === 'Y') precision = 2;
    if (precision < 0) {
      precision = null;
      diagnostic(
        'unsupported-labour-rounding',
        'Negative labour precision requires the configured all-rounding override.',
      );
    }
  }
  const columns: SaleReturnIncomingConfigurationColumn[] = SALE_RETURN_INCOMING_COLUMN_CATALOG.map(
    (column) => ({ ...column }),
  );
  const style = columns[6]!;
  if (edition.state === 'unresolved') {
    diagnostic(
      'edition-unresolved',
      'Style availability has not been resolved for this installation; Style commits are unavailable.',
      false,
      style.id,
    );
    style.label = null;
    style.originalLabel = null;
  } else if (!['A', 'E'].includes(edition.value)) {
    style.nominalWidth = 0;
    style.widthState = 'zero';
    style.label = null;
    style.originalLabel = null;
  } else {
    style.widthState = 'nonzero';
  }
  const candidates = new Map<number, SaleReturnIncomingConfigurationRow[]>();
  const ambiguousWidths = new Set<number>();
  for (const row of columnRows) {
    const raw = row.raw;
    const index = definitions.findIndex(
      (definition) => normalized(definition[0]) === normalized(raw.COL_NAME),
    );
    if (raw.BOOK_NAME !== FAMILY) {
      diagnostic(
        'noncanonical-column-family',
        'A Return column family differs in case or spacing; reconcile the imported key.',
      );
      if (index > 0 && !columns[index]!.forcedVisible) ambiguousWidths.add(index);
      continue;
    }
    if (!normalized(raw.COL_NAME)) {
      diagnostic(
        'invalid-column-key',
        'A Return column has a blank or missing original name; hidden fields cannot be configured this way.',
      );
      continue;
    }
    if (index < 0) {
      diagnostic(
        'unknown-column-key',
        'An extra Return column name has no supported primary-grid field mapping.',
        false,
      );
      continue;
    }
    const column = columns[index]!;
    if (raw.COL_NAME !== column.sourceName) {
      diagnostic(
        'noncanonical-column-key',
        'A Return original column name differs in case or spacing; reconcile the imported key.',
        true,
        column.id,
      );
      if (!column.forcedVisible) ambiguousWidths.add(index);
      continue;
    }
    if (index === 0) {
      diagnostic(
        'sr-override-ignored',
        'The desktop does not apply column overrides to Sr.',
        false,
        column.id,
      );
      continue;
    }
    if (index === 6 && edition.state === 'resolved' && !['A', 'E'].includes(edition.value)) {
      diagnostic(
        'style-override-inactive',
        'Style stays unavailable for this edition; its override cannot enable it.',
        false,
        column.id,
      );
      continue;
    }
    candidates.set(index, [...(candidates.get(index) ?? []), row]);
  }
  for (const [index, rows] of candidates) {
    const column = columns[index]!;
    column.configured = true;
    if (rows.length !== 1) {
      diagnostic(
        'duplicate-column-key',
        'The Return column has duplicate configuration rows; reconcile their identity.',
        true,
        column.id,
      );
      if (!column.forcedVisible) column.widthState = 'unresolved';
      continue;
    }
    const raw = rows[0]!.raw;
    // Unknown edition means the Style heading may not exist in the desktop grid at all;
    // the observed override is conditional and cannot supply an effective display caption.
    column.label =
      index === 6 && edition.state === 'unresolved' ? null : (raw.COL_NEW_NAME ?? null);
    if (raw.COL_NEW_NAME == null)
      diagnostic(
        'null-column-label',
        'The Return column caption is NULL; its desktop display needs reconciliation.',
        true,
        column.id,
      );
    if (!['N', 'Y', ''].includes(raw.YES_NO as string)) {
      diagnostic(
        'unsupported-column-visibility',
        'The Return column has an unsupported visibility value.',
        true,
        column.id,
      );
      if (!column.forcedVisible) column.widthState = 'unresolved';
    } else if (raw.YES_NO === 'N' && !column.forcedVisible && index !== 6) {
      column.nominalWidth = 0;
      column.widthState = 'zero';
    } else if (raw.YES_NO === 'N' && index === 6 && edition.state === 'resolved') {
      column.nominalWidth = 0;
      column.widthState = 'zero';
    }
  }
  // A later exact row cannot resolve the width of an earlier collation-ambiguous alias.
  for (const index of ambiguousWidths) columns[index]!.widthState = 'unresolved';
  // Captions remain display-only: collisions never merge or redirect a stable source field ID.
  const aliases = new Map<string, SaleReturnIncomingConfigurationColumn[]>();
  for (const column of columns) {
    if (!column.label) continue;
    const alias = normalized(column.label);
    aliases.set(alias, [...(aliases.get(alias) ?? []), column]);
  }
  for (const group of aliases.values())
    if (group.length > 1)
      for (const column of group)
        diagnostic(
          'duplicate-caption',
          'This caption is shared by another Return field; use its stable field identity.',
          false,
          column.id,
        );
  const blocked = diagnostics.some((item) => item.blocking);
  const fine = columns[18]!;
  const policy =
    !blocked && saleAmountType !== null && precision !== null && fine.widthState !== 'unresolved'
      ? {
          saleAmountType,
          labourRoundingDecimals: precision,
          labourIncludesGhat: includesGhat === 'Y',
          generateLabourRate: generate === 'Y',
          fineColumnWidth: fine.nominalWidth,
        }
      : null;
  return {
    scope: {
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
      coBook: scope.coBook,
    },
    form: FORM,
    grid: 'MSG_PR',
    columnFamily: FAMILY,
    contractVersion: CONTRACT,
    version: hash({
      scope,
      contract: CONTRACT,
      catalog: SALE_RETURN_INCOMING_COLUMN_CATALOG,
      settings,
      newSettings,
      columns: columnRows,
      books,
      years,
      edition,
      counts: {
        settings: settings.length,
        newSettings: newSettings.length,
        columns: columnRows.length,
        books: books.length,
        years: years.length,
      },
    }),
    policy,
    newRowDefaults: { labourType },
    widthMode: 'source-zero-predicate',
    columns,
    rawSettings,
    diagnostics,
    capabilities: { canCalculate: policy !== null, canSaveNumeric: false },
  };
}

type Table = 'CO_SET' | 'CO_SET_NEW' | 'COL_MAST' | 'BOOK_DATA' | 'YEAR_MAST';
async function observe(
  tx: any,
  table: Table,
  scope: SavedSaleReturnScope,
): Promise<SaleReturnIncomingConfigurationRow[]> {
  // Text conversion occurs in PostgreSQL, before JSON parsing can lose a numeric value.
  return tx.$queryRawUnsafe(
    `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id') e) AS raw,
      t.xmin::text AS revision,t.ctid::text AS locator,to_jsonb(t)->>'row_id' AS "physicalId"
     FROM "${table}" t WHERE t.tenant_id=$1 AND t."CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
}
/** Caller owns tenant binding and isolation; all effective inputs are observed in that snapshot. */
export async function readSaleReturnIncomingConfigurationTx(
  tx: any,
  scope: SavedSaleReturnScope,
): Promise<SaleReturnIncomingConfiguration> {
  validateScope(scope);
  const settings = await observe(tx, 'CO_SET', scope);
  const newSettings = await observe(tx, 'CO_SET_NEW', scope);
  const columns = await observe(tx, 'COL_MAST', scope);
  const books = await observe(tx, 'BOOK_DATA', scope);
  const years = await observe(tx, 'YEAR_MAST', scope);
  return resolveSaleReturnIncomingConfiguration(scope, {
    settings,
    newSettings,
    columns,
    books,
    years,
  });
}

export async function getSaleReturnIncomingConfiguration(
  prisma: any,
  scope: SavedSaleReturnScope,
): Promise<SaleReturnIncomingConfiguration> {
  validateScope(scope);
  return withTenant(
    prisma,
    scope.tenantId,
    async (tx: any) => {
      // One RepeatableRead observation includes absence and all duplicate physical rows. No row locks
      // or token from this read confer future write authority or durable validity across restore.
      return readSaleReturnIncomingConfigurationTx(tx, scope);
    },
    { isolationLevel: 'RepeatableRead' },
  );
}
