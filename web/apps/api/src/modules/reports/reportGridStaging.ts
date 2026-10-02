import { withTxBudget } from '../shared/txBudget.js';

/**
 * `REPORT_DATA` — the desktop's "print this grid" bridge.
 *
 * Six supplied Crystal specs bind it (UserDtlRpt, ReminderAll, DharnDue, ItmStkBalance,
 * ItmStkWithGrid, ItmStkWithOthWt) and seven report forms populate it (RP_USER, RP_REMINDER,
 * RP_DHRN_OS, RP_STOCK, RP_EMP, RP_INOUT, RP_BAL_ZOOM). It is deliberately untyped: the table is
 * `CO_CODE, LC_CODE, SR_NO, COL_1..COL_33`, and each report writes whatever its on-screen grid holds.
 *
 * Desktop shape, from RP_USER.cs:3534 and 3542:
 *   • clear the company's rows;
 *   • insert one row with `SR_NO = '0'` carrying the grid's COLUMN HEADER texts
 *     (`dGV_DETL.Columns[n].HeaderText` → COL_1..COL_33);
 *   • insert one row per grid row carrying that row's cell values.
 * Crystal then renders COL_n against the header row, which is how one layout prints any grid.
 *
 * Because the slots are positional, this writer takes headers and rows as given by the caller — the
 * same values the screen shows — and never invents or reorders them. Values beyond 33 columns are
 * dropped exactly as the desktop's fixed slot count drops them.
 */
/** The 33 positional slots, declared explicitly: the schema is fixed and an explicit list keeps the
 * write set visible to the column audit. */
export const REPORT_DATA_SLOT_COLUMNS = [
  'COL_1',
  'COL_2',
  'COL_3',
  'COL_4',
  'COL_5',
  'COL_6',
  'COL_7',
  'COL_8',
  'COL_9',
  'COL_10',
  'COL_11',
  'COL_12',
  'COL_13',
  'COL_14',
  'COL_15',
  'COL_16',
  'COL_17',
  'COL_18',
  'COL_19',
  'COL_20',
  'COL_21',
  'COL_22',
  'COL_23',
  'COL_24',
  'COL_25',
  'COL_26',
  'COL_27',
  'COL_28',
  'COL_29',
  'COL_30',
  'COL_31',
  'COL_32',
  'COL_33',
] as const;

export const REPORT_DATA_SLOTS = REPORT_DATA_SLOT_COLUMNS.length;

export interface ReportGridScope {
  coCode: string;
  lcCode: string;
}

export interface ReportGridSnapshot {
  /** Column captions, in display order, as shown on screen. */
  headers: readonly string[];
  /** One entry per grid row, each a list of cell values in the same order as `headers`. */
  rows: readonly (readonly unknown[])[];
}

const slotColumns = REPORT_DATA_SLOT_COLUMNS;

const cell = (value: unknown): string => {
  if (value == null) return '';
  if (value instanceof Date) {
    return `${String(value.getDate()).padStart(2, '0')}/${String(value.getMonth() + 1).padStart(2, '0')}/${value.getFullYear()}`;
  }
  return String(value);
};

/**
 * Stage a grid snapshot for the company. Returns the number of rows written including the header
 * row, so a caller/test can assert the shape.
 */
export async function stageReportGridTx(
  tx: any,
  tenantId: string,
  scope: ReportGridScope,
  snapshot: ReportGridSnapshot,
): Promise<number> {
  const quoted = slotColumns.map((c) => `"${c}"`).join(',');
  const placeholders = slotColumns.map((_, i) => `$${i + 5}`).join(',');

  // Desktop clears by company before repopulating (RP_USER.cs:3533 region, MS_COMPANY.cs:6384).
  await tx.$executeRawUnsafe(
    `DELETE FROM "REPORT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    tenantId,
    scope.coCode,
  );

  const insert = async (srNo: number, values: readonly unknown[]): Promise<void> => {
    const slots = slotColumns.map((_, i) => cell(values[i]));
    await tx.$executeRawUnsafe(
      `INSERT INTO "REPORT_DATA"(tenant_id,"CO_CODE","LC_CODE","SR_NO",${quoted})
         VALUES ($1,$2,$3,$4,${placeholders})`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      String(srNo),
      ...slots,
    );
  };

  // SR_NO '0' is the header row; data rows follow from 1.
  await insert(0, snapshot.headers);
  let written = 1;
  for (const row of snapshot.rows) {
    await insert(written, row);
    written += 1;
  }
  return written;
}

export async function stageReportGrid(
  prisma: any,
  tenantId: string,
  scope: ReportGridScope,
  snapshot: ReportGridSnapshot,
): Promise<number> {
  return withTxBudget(prisma, tenantId, 'read', (tx: any) =>
    stageReportGridTx(tx, tenantId, scope, snapshot),
  );
}

/**
 * Stage a list-shaped report (the web equivalent of the desktop's on-screen grid) into REPORT_DATA.
 *
 * Column order is taken from the first row's key order, which is the order the API returns and the
 * order the UI renders — the same correspondence the desktop relies on between `dGV_DETL` columns and
 * COL_n slots. Header captions default to the key names unless the caller supplies labels.
 */
export async function stageListReportTx(
  tx: any,
  tenantId: string,
  scope: ReportGridScope,
  rows: readonly Record<string, unknown>[],
  labels?: Readonly<Record<string, string>>,
): Promise<number> {
  const keys = rows.length ? Object.keys(rows[0]!) : [];
  return stageReportGridTx(tx, tenantId, scope, {
    headers: keys.map((k) => labels?.[k] ?? k),
    rows: rows.map((row) => keys.map((k) => row[k])),
  });
}
