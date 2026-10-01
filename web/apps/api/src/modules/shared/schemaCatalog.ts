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

const CATALOG_SQL = `SELECT table_name::text AS table_name, column_name::text AS column_name
  FROM information_schema.columns
 WHERE table_schema = current_schema()`;

const EMPTY: ReadonlySet<string> = new Set<string>();
let catalog: Catalog | null = null;

async function loadCatalog(db: CatalogDb): Promise<Catalog> {
  const rows = (await db.$queryRawUnsafe(CATALOG_SQL)) as Array<{
    table_name: string;
    column_name: string;
  }>;
  const tables = new Map<string, Set<string>>();
  for (const row of rows) {
    let columns = tables.get(row.table_name);
    if (!columns) {
      columns = new Set<string>();
      tables.set(row.table_name, columns);
    }
    columns.add(row.column_name);
  }
  return tables;
}

/** Load the whole column catalog in one query. Call outside any transaction, before serving requests. */
export async function warmSchemaCatalog(db: CatalogDb): Promise<number> {
  catalog = await loadCatalog(db);
  return catalog.size;
}

/** True once the catalog has been loaded. */
export function schemaCatalogWarm(): boolean {
  return catalog !== null;
}

/** Forget the loaded catalog, so the next lookup loads it again. For tests only. */
export function resetSchemaCatalog(): void {
  catalog = null;
}

async function catalogTx(tx: CatalogDb): Promise<Catalog> {
  if (!catalog) catalog = await loadCatalog(tx);
  return catalog;
}

/** Columns of `table` (empty for a table the schema does not have). */
export async function tableColumnsTx(tx: CatalogDb, table: string): Promise<ReadonlySet<string>> {
  return (await catalogTx(tx)).get(table) ?? EMPTY;
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
