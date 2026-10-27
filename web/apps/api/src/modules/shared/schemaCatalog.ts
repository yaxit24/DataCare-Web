/**
 * Process-wide column catalog of the application schema (N53 / G30).
 *
 * Posting and voucher numbering need to know which columns a table carries: whether to stamp `DATA_TYPE`,
 * which provenance columns exist, which tables hold a complete voucher identity. They used to ask
 * `information_schema` from inside the posting transaction, per table, and numbering asked on every
 * allocation without caching at all. Catalog queries are slow under load, and they ran while the
 * transaction's time budget was running, holding its locks.
 *
 * The catalog is loaded in ONE query: by `warmSchemaCatalog` at server start-up, before `listen`, so a
 * served request never queries it. A writer used without start-up (a script, a module-level test) loads the
 * whole catalog once on first use, through its own transaction, instead of once per table.
 *
 * The schema is migration-owned and migrations run before the server starts, so a loaded catalog does not
 * go stale while serving. `resetSchemaCatalog` exists for tests that need a cold catalog.
 */

type CatalogDb = { $queryRawUnsafe: (query: string, ...values: unknown[]) => Promise<unknown> };
type Catalog = ReadonlyMap<string, ReadonlySet<string>>;
/** table -> column -> information_schema `data_type` (e.g. `double precision`, `timestamp without time zone`). */
type TypeCatalog = ReadonlyMap<string, ReadonlyMap<string, string>>;

const CATALOG_SQL = `SELECT table_name::text AS table_name, column_name::text AS column_name,
       data_type::text AS data_type
  FROM information_schema.columns
 WHERE table_schema = current_schema()`;

const EMPTY: ReadonlySet<string> = new Set<string>();
const EMPTY_TYPES: ReadonlyMap<string, string> = new Map<string, string>();
let catalog: Catalog | null = null;
let types: TypeCatalog | null = null;

async function loadCatalog(db: CatalogDb): Promise<{ columns: Catalog; types: TypeCatalog }> {
  const rows = (await db.$queryRawUnsafe(CATALOG_SQL)) as Array<{
    table_name: string;
    column_name: string;
    data_type: string;
  }>;
  const tables = new Map<string, Set<string>>();
  const typed = new Map<string, Map<string, string>>();
  for (const row of rows) {
    let columns = tables.get(row.table_name);
    let columnTypes = typed.get(row.table_name);
    if (!columns || !columnTypes) {
      columns = new Set<string>();
      columnTypes = new Map<string, string>();
      tables.set(row.table_name, columns);
      typed.set(row.table_name, columnTypes);
    }
    columns.add(row.column_name);
    columnTypes.set(row.column_name, String(row.data_type ?? ''));
  }
  return { columns: tables, types: typed };
}

async function load(db: CatalogDb): Promise<void> {
  const loaded = await loadCatalog(db);
  catalog = loaded.columns;
  types = loaded.types;
}

/** Load the whole column catalog in one query. Call outside any transaction, before serving requests. */
export async function warmSchemaCatalog(db: CatalogDb): Promise<number> {
  await load(db);
  return catalog!.size;
}

/** True once the catalog has been loaded. */
export function schemaCatalogWarm(): boolean {
  return catalog !== null;
}

/** Forget the loaded catalog, so the next lookup loads it again. For tests only. */
export function resetSchemaCatalog(): void {
  catalog = null;
  types = null;
}

async function catalogTx(tx: CatalogDb): Promise<Catalog> {
  if (!catalog) await load(tx);
  return catalog!;
}

/** Columns of `table` (empty for a table the schema does not have). */
export async function tableColumnsTx(tx: CatalogDb, table: string): Promise<ReadonlySet<string>> {
  return (await catalogTx(tx)).get(table) ?? EMPTY;
}

/** Column data types of `table`, keyed by column name (empty for a table the schema does not have). */
export async function tableColumnTypesTx(
  tx: CatalogDb,
  table: string,
): Promise<ReadonlyMap<string, string>> {
  if (!types) await load(tx);
  return types!.get(table) ?? EMPTY_TYPES;
}

/**
 * Tables that carry every one of `columns`, minus `exclude`, sorted by name.
 * Used by voucher numbering to find every table holding a complete voucher identity.
 */
export async function tablesWithColumnsTx(
  tx: CatalogDb,
  columns: readonly string[],
  exclude: readonly string[] = [],
): Promise<string[]> {
  const skip = new Set(exclude);
  const found: string[] = [];
  for (const [table, tableColumns] of await catalogTx(tx)) {
    if (!skip.has(table) && columns.every((column) => tableColumns.has(column))) found.push(table);
  }
  return found.sort();
}
