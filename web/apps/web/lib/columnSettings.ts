import type { BusinessScope } from '../components/BusinessScope';

export const COLUMN_KEYS = ['CO_CODE', 'BOOK_NAME', 'COL_NAME'] as const;
export const COLUMN_VALUES = ['COL_NEW_NAME', 'COL_RPT', 'YES_NO'] as const;
export type ColumnValue = (typeof COLUMN_VALUES)[number];
export interface ColumnSetting {
  row_id: string;
  CO_CODE: string;
  BOOK_NAME: string | null;
  COL_NAME: string | null;
  COL_NEW_NAME: string | null;
  COL_RPT: string | null;
  YES_NO: string | null;
  _columnVersion: string;
  _columnIdentityCount: number;
  _columnCollectionVersion: string;
  _columnTotal: number;
}
export interface ColumnCapabilities {
  canCreate: boolean;
  canUpdate: boolean;
  canDelete: boolean;
}
const object = (value: unknown): value is Record<string, unknown> =>
  !!value && typeof value === 'object' && !Array.isArray(value);
const nullableText = (value: unknown): value is string | null =>
  value === null || typeof value === 'string';
export function columnSettingsQuery(scope: BusinessScope): string {
  return new URLSearchParams({
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    coYear: scope.coYear,
  }).toString();
}
export function readColumnSettings(meta: unknown, rows: unknown, coCode: string) {
  if (
    !object(meta) ||
    meta.table !== 'COL_MAST' ||
    JSON.stringify(meta.keyColumns) !== JSON.stringify(COLUMN_KEYS) ||
    !object(meta.capabilities)
  )
    throw new Error('Reload column settings; the form identity could not be verified.');
  const caps = meta.capabilities;
  if (
    ['canCreate', 'canUpdate', 'canDelete'].some((key) => typeof caps[key] !== 'boolean') ||
    !Array.isArray(rows)
  )
    throw new Error('Column settings could not be verified.');
  const seen = new Set<string>();
  for (const row of rows) {
    if (
      !object(row) ||
      typeof row.row_id !== 'string' ||
      !/^\d+$/.test(row.row_id) ||
      seen.has(row.row_id) ||
      row.CO_CODE !== coCode ||
      typeof row._columnVersion !== 'string' ||
      !/^[a-f0-9]{64}$/.test(row._columnVersion) ||
      typeof row._columnIdentityCount !== 'number' ||
      !Number.isInteger(row._columnIdentityCount) ||
      row._columnIdentityCount < 1 ||
      typeof row._columnCollectionVersion !== 'string' ||
      !/^[a-f0-9]{64}$/.test(row._columnCollectionVersion) ||
      typeof row._columnTotal !== 'number' ||
      !Number.isInteger(row._columnTotal) ||
      row._columnTotal < rows.length ||
      [...COLUMN_VALUES, 'BOOK_NAME', 'COL_NAME'].some((key) => !nullableText(row[key]))
    )
      throw new Error('A saved column setting has an invalid observation. Reload before editing.');
    seen.add(row.row_id);
  }
  const typed = rows as ColumnSetting[];
  if (
    typed.some(
      (row) =>
        row._columnCollectionVersion !== typed[0]?._columnCollectionVersion ||
        row._columnTotal !== typed[0]?._columnTotal,
    )
  )
    throw new Error('Column settings changed while the page was read. Reload the list.');
  return {
    capabilities: caps as unknown as ColumnCapabilities,
    rows: typed,
    total: typed[0]?._columnTotal ?? 0,
    collectionVersion: typed[0]?._columnCollectionVersion ?? null,
  };
}
export function appendColumnSettingsPage(
  before: ReturnType<typeof readColumnSettings>,
  next: ReturnType<typeof readColumnSettings>,
) {
  if (
    before.collectionVersion !== next.collectionVersion ||
    before.total !== next.total ||
    !next.rows.length
  )
    throw new Error('Column settings changed between pages. Reload the list before continuing.');
  const seen = new Set(before.rows.map((row) => row.row_id));
  if (
    next.rows.some((row) => seen.has(row.row_id)) ||
    before.rows.length + next.rows.length > before.total
  )
    throw new Error('A column settings page overlaps the current list. Reload before continuing.');
  return { ...next, rows: [...before.rows, ...next.rows] };
}
export function columnSettingProblem(row: ColumnSetting): string | null {
  if (!row.BOOK_NAME?.trim() || !row.COL_NAME?.trim())
    return 'The saved form family or original column name is missing. Reconcile this imported setting before changing it.';
  if (
    [row.BOOK_NAME, row.COL_NAME].some(
      (name) => name !== name.trim() || /[\u0000-\u001f\u007f]/.test(name),
    )
  )
    return 'This imported identity contains surrounding whitespace or control characters. Reconcile it before changing this setting.';
  if (row._columnIdentityCount !== 1)
    return 'Several saved settings share this form and original column. Reconcile them before changing this setting.';
  return null;
}
export function columnSettingKey(row: ColumnSetting) {
  const problem = columnSettingProblem(row);
  if (problem) throw new Error(problem);
  return { CO_CODE: row.CO_CODE, BOOK_NAME: row.BOOK_NAME!, COL_NAME: row.COL_NAME! };
}
export function columnSettingPatch(
  row: ColumnSetting,
  values: Record<ColumnValue, string>,
  touched: readonly ColumnValue[],
) {
  const changes = Object.fromEntries(
    [...new Set(touched)].map((key) => {
      if (!COLUMN_VALUES.includes(key) || typeof values[key] !== 'string')
        throw new Error('A column change is invalid.');
      return [key, values[key]];
    }),
  );
  if (!Object.keys(changes).length)
    throw new Error('Change a caption, visibility or repeat option before saving.');
  return { ...columnSettingKey(row), version: row._columnVersion, ...changes };
}
export function columnSettingsExport(rows: readonly ColumnSetting[]) {
  return rows.map((row) =>
    Object.fromEntries([...COLUMN_KEYS, ...COLUMN_VALUES].map((key) => [key, row[key]])),
  );
}

/** CSV business values stay exact; quoted captions may contain commas/newlines.
 * Known observation/surrogate columns from previous exports are never imported. */
export function parseColumnSettingsCsv(text: string): Record<string, string>[] {
  text = text.replace(/^\uFEFF/, '');
  const records: string[][] = [];
  let record: string[] = [],
    field = '',
    quoted = false,
    afterQuote = false;
  for (let i = 0; i < text.length; i++) {
    const char = text[i]!;
    if (quoted) {
      if (char === '"' && text[i + 1] === '"') {
        field += '"';
        i++;
      } else if (char === '"') {
        quoted = false;
        afterQuote = true;
      } else field += char;
    } else if (char === '"') {
      if (field || afterQuote) throw new Error('The CSV contains an invalid quoted value.');
      quoted = true;
    } else if (char === ',' || char === '\n' || char === '\r') {
      record.push(field);
      field = '';
      afterQuote = false;
      if (char !== ',') {
        records.push(record);
        record = [];
        if (char === '\r' && text[i + 1] === '\n') i++;
      }
    } else {
      if (afterQuote) throw new Error('The CSV contains text after a closing quote.');
      field += char;
    }
  }
  if (quoted) throw new Error('The CSV has an unfinished quoted value.');
  if (field || record.length || afterQuote) records.push([...record, field]);
  const nonempty = records.filter((row) => row.some((cell) => cell !== ''));
  const header = nonempty
    .shift()
    ?.map((cell, index) => (index === 0 ? cell.replace(/^\uFEFF/, '') : cell).trim());
  if (!header || !nonempty.length) throw new Error('The CSV has no data rows.');
  if (new Set(header).size !== header.length) throw new Error('The CSV repeats a column heading.');
  if (!header.includes('BOOK_NAME') || !header.includes('COL_NAME'))
    throw new Error('The CSV must include BOOK_NAME and COL_NAME.');
  const allowed = new Set<string>([...COLUMN_KEYS, ...COLUMN_VALUES]);
  const ignored = new Set([
    'tenant_id',
    'row_id',
    '_columnVersion',
    '_columnIdentityCount',
    '_columnCollectionVersion',
    '_columnTotal',
  ]);
  if (header.some((key) => !allowed.has(key) && !ignored.has(key)))
    throw new Error('The CSV contains an unsupported column.');
  return nonempty.map((row) => {
    if (row.length !== header.length)
      throw new Error('A CSV row has a different number of columns.');
    return Object.fromEntries(
      header.flatMap((key, index) => (allowed.has(key) ? [[key, row[index]!]] : [])),
    );
  });
}
