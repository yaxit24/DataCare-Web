import { createHash } from 'node:crypto';
import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import type { MasterScope } from './master.service.js';

/** UT_SETTING.cs:4887 identifies a column by company, family and ORIGINAL name.
 * The old generic two-column key could update/delete several unrelated forms. */
export const COLUMN_SETTING_KEYS = ['CO_CODE', 'BOOK_NAME', 'COL_NAME'] as const;
export const COLUMN_SETTING_VALUES = ['COL_NEW_NAME', 'COL_RPT', 'YES_NO'] as const;
export class ColumnSettingsError extends Error {
  constructor(
    readonly statusCode: 400 | 404 | 409,
    readonly code: string,
    message: string,
  ) {
    super(message);
    this.name = 'ColumnSettingsError';
  }
}
type Operation = 'create' | 'update' | 'delete';
type Input = {
  key: { CO_CODE: string; BOOK_NAME: string; COL_NAME: string };
  changes: Partial<Record<(typeof COLUMN_SETTING_VALUES)[number], string | null>>;
  version?: string;
};
type Row = Record<string, unknown> & {
  row_id: string;
  CO_CODE: string;
  BOOK_NAME: string | null;
  COL_NAME: string | null;
  COL_NEW_NAME: string | null;
  COL_RPT: string | null;
  YES_NO: string | null;
  _revision: string;
  _physical: string;
};
const invalid = (message: string): never => {
  throw new ColumnSettingsError(400, 'invalid-column-setting', message);
};

export function columnSettingInput(
  scope: MasterScope,
  source: unknown,
  operation: Operation,
): Input {
  if (!source || typeof source !== 'object' || Array.isArray(source))
    invalid('A column setting object is required.');
  const value = source as Record<string, unknown>;
  const allowed = new Set<string>([
    ...COLUMN_SETTING_KEYS,
    ...(operation === 'delete' ? [] : COLUMN_SETTING_VALUES),
    ...(operation === 'create' ? [] : ['version']),
  ]);
  if (Object.keys(value).some((key) => !allowed.has(key)))
    invalid('The request contains an unsupported column-setting field.');
  if (value.CO_CODE !== undefined && value.CO_CODE !== scope.coCode)
    invalid('The selected company changed. Reload column settings.');
  for (const name of ['BOOK_NAME', 'COL_NAME'] as const) {
    const original = value[name];
    if (typeof original !== 'string' || !original.trim())
      invalid(
        `Select the original ${name === 'BOOK_NAME' ? 'form family' : 'column name'} before changing a column setting.`,
      );
    if (
      typeof original === 'string' &&
      (original !== original.trim() || /[\u0000-\u001f\u007f]/.test(original))
    )
      invalid(
        'Original form and column names cannot contain surrounding whitespace or control characters. Reconcile imported identities without renaming them here.',
      );
  }
  const changes: Input['changes'] = {};
  for (const name of COLUMN_SETTING_VALUES) {
    if (!Object.hasOwn(value, name)) continue;
    const cell = value[name];
    if (cell !== null && (typeof cell !== 'string' || cell.length > 255))
      invalid(`${name} must be text of at most 255 characters or NULL.`);
    changes[name] = cell as string | null;
  }
  if (operation === 'update' && !Object.keys(changes).length)
    invalid('Supply a column caption, visibility or repeat change.');
  if (
    operation !== 'create' &&
    (typeof value.version !== 'string' || !/^[a-f0-9]{64}$/.test(value.version))
  )
    invalid('Reload this column setting before changing it; a valid version is required.');
  return {
    key: {
      CO_CODE: scope.coCode,
      BOOK_NAME: value.BOOK_NAME as string,
      COL_NAME: value.COL_NAME as string,
    },
    changes,
    ...(operation === 'create' ? {} : { version: value.version as string }),
  };
}

const projection = `row_id::text AS row_id,"CO_CODE","BOOK_NAME","COL_NAME", "COL_NEW_NAME","COL_RPT","YES_NO",xmin::text AS _revision,ctid::text AS _physical`;
function version(scope: MasterScope, row: Row): string {
  return createHash('sha256')
    .update(
      JSON.stringify([
        'column-setting-v1',
        scope.tenantId,
        scope.coCode,
        row.row_id,
        row._revision,
        row._physical,
        ...COLUMN_SETTING_KEYS.map((name) => row[name]),
        ...COLUMN_SETTING_VALUES.map((name) => row[name]),
      ]),
    )
    .digest('hex');
}

export function columnSettingListOptions(
  input: { offset?: unknown; limit?: unknown; family?: unknown; search?: unknown } = {},
) {
  const integer = (value: unknown, fallback: number, min: number, max: number) => {
    if (value === undefined) return fallback;
    if ((typeof value !== 'string' && typeof value !== 'number') || !/^\d+$/.test(String(value)))
      invalid('Pagination requires whole-number offset and limit.');
    const number = Number(value);
    if (!Number.isSafeInteger(number) || number < min || number > max)
      invalid('Pagination is outside the supported range.');
    return number;
  };
  const field = (value: unknown) => {
    if (value === undefined) return '';
    if (typeof value !== 'string' || value.length > 255 || /[\u0000-\u001f\u007f]/.test(value))
      invalid('The column filter must be text of at most 255 characters.');
    return value as string;
  };
  return {
    offset: integer(input.offset, 0, 0, 1000000),
    limit: integer(input.limit, 100, 1, 500),
    family: field(input.family),
    search: field(input.search),
  };
}
export async function listColumnSettings(
  prisma: any,
  scope: MasterScope,
  input: Parameters<typeof columnSettingListOptions>[0] = {},
) {
  const options = columnSettingListOptions(input);
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx) => {
    // Present-row revisions detect observed insertion/deletion and present-row ABA.
    // An absent -> insert -> delete history is not retained by this collection token.
    // Avoid fetching every caption/value to paginate a large company's settings.
    const revisions = await tx.$queryRawUnsafe<
      { row_id: string; revision: string; physical: string }[]
    >(
      'SELECT row_id::text AS row_id,xmin::text AS revision,ctid::text AS physical FROM "COL_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id',
      scope.tenantId,
      scope.coCode,
    );
    const collectionVersion = createHash('sha256')
      .update(
        JSON.stringify([
          'column-collection-v1',
          scope.tenantId,
          scope.coCode,
          options.family,
          options.search,
          revisions,
        ]),
      )
      .digest('hex');
    const pattern = `%${options.search.replace(/[\\%_]/g, '\\$&')}%`;
    const rows = await tx.$queryRawUnsafe<Row[]>(
      `WITH scoped AS (SELECT ${projection},count(*) OVER (PARTITION BY "CO_CODE","BOOK_NAME","COL_NAME")::int AS "_columnIdentityCount"
       FROM "COL_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2)
       SELECT *,count(*) OVER ()::int AS "_columnTotal" FROM scoped
       WHERE ($3='' OR "BOOK_NAME"=$3) AND ($4='' OR COALESCE("BOOK_NAME",'') ILIKE $5 OR COALESCE("COL_NAME",'') ILIKE $5 OR COALESCE("COL_NEW_NAME",'') ILIKE $5)
       ORDER BY "BOOK_NAME" NULLS FIRST,"COL_NAME" NULLS FIRST,row_id::bigint LIMIT $6 OFFSET $7`,
      scope.tenantId,
      scope.coCode,
      options.family,
      options.search,
      pattern,
      options.limit,
      options.offset,
    );
    return rows.map((row) => {
      const { _revision, _physical, ...raw } = row;
      return {
        ...raw,
        _columnVersion: version(scope, row),
        _columnCollectionVersion: collectionVersion,
      };
    });
  });
}

async function mutate(prisma: any, scope: MasterScope, source: unknown, operation: Operation) {
  const input = columnSettingInput(scope, source, operation);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx) => {
    // Generic COL_MAST create/CSV import/update/delete uses this lock. Company
    // cloning, restore and administrator SQL are separate writers, not covered.
    // No unique constraint is added over unreconciled imported duplicate rows.
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtextextended($1,0))',
      JSON.stringify([
        'column-setting',
        scope.tenantId,
        ...COLUMN_SETTING_KEYS.map((key) => input.key[key]),
      ]),
    );
    const rows = await tx.$queryRawUnsafe<Row[]>(
      `SELECT ${projection} FROM "COL_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "BOOK_NAME"=$3 AND "COL_NAME"=$4 FOR UPDATE`,
      scope.tenantId,
      input.key.CO_CODE,
      input.key.BOOK_NAME,
      input.key.COL_NAME,
    );
    if (rows.length > 1)
      throw new ColumnSettingsError(
        409,
        'ambiguous-column-setting',
        'Several saved settings share this form and original column. Reconcile them before editing.',
      );
    const row = rows[0];
    if (operation === 'create') {
      if (row)
        throw new ColumnSettingsError(
          409,
          'duplicate-key',
          'This form already has a setting for that original column.',
        );
    } else {
      if (!row)
        throw new ColumnSettingsError(
          404,
          'not-found',
          'This column setting no longer exists. Reload the list.',
        );
      if (version(scope, row) !== input.version)
        throw new ColumnSettingsError(
          409,
          'column-setting-version-conflict',
          'This column setting changed. Reload before retrying.',
        );
    }
    // Permit unchanged imported NULL/unusual flags without rewriting them. New
    // flag values follow the desktop settings UI's Y/N spelling (4887).
    for (const name of ['COL_RPT', 'YES_NO'] as const) {
      if (!Object.hasOwn(input.changes, name)) continue;
      const next = input.changes[name];
      if (row && next === row[name]) continue;
      if (next !== null && !['', 'Y', 'N'].includes(next ?? ''))
        invalid(`${name} must be Y, N or blank.`);
    }
    if (operation === 'create') {
      const names = [...COLUMN_SETTING_KEYS, ...Object.keys(input.changes)];
      const values = { ...input.key, ...input.changes } as Record<string, unknown>;
      await tx.$executeRawUnsafe(
        `INSERT INTO "COL_MAST"(tenant_id,${names.map((name) => `"${name}"`).join(',')}) VALUES ($1,${names.map((_, i) => `$${i + 2}`).join(',')})`,
        scope.tenantId,
        ...names.map((name) => values[name]),
      );
    } else if (operation === 'delete') {
      await tx.$executeRawUnsafe(
        'DELETE FROM "COL_MAST" WHERE tenant_id=$1 AND row_id=$2::bigint',
        scope.tenantId,
        row!.row_id,
      );
    } else {
      const names = Object.keys(input.changes);
      const count = await tx.$executeRawUnsafe(
        `UPDATE "COL_MAST" SET ${names.map((name, i) => `"${name}"=$${i + 3}`).join(',')} WHERE tenant_id=$1 AND row_id=$2::bigint`,
        scope.tenantId,
        row!.row_id,
        ...names.map((name) => input.changes[name as keyof Input['changes']]),
      );
      if (count !== 1)
        throw new ColumnSettingsError(
          409,
          'column-setting-version-conflict',
          'This column setting changed. Reload before retrying.',
        );
    }
  });
}
export async function createColumnSetting(prisma: any, scope: MasterScope, source: unknown) {
  await mutate(prisma, scope, source, 'create');
  return { created: true as const };
}
export async function updateColumnSetting(prisma: any, scope: MasterScope, source: unknown) {
  await mutate(prisma, scope, source, 'update');
  return { updated: true as const };
}
export async function deleteColumnSetting(prisma: any, scope: MasterScope, source: unknown) {
  await mutate(prisma, scope, source, 'delete');
  return { deleted: true as const };
}
