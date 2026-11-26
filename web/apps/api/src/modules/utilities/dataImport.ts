import { createHash } from 'node:crypto';
import { withTxBudget } from '../shared/txBudget.js';
import { DESKTOP_COLUMN_DEFAULTS } from '../posting/desktopColumnDefaults.js';
import { writePartyOpeningTx } from '../finance/partyOpening.js';
import { SYSTEM_ACCOUNT_CODES } from '../ops/seedCompany.js';
import {
  type ImportIssue,
  type LitePlan,
  type LiteStep,
  planLiteImport,
} from './dataImportLite.js';
import { SOURCE_TABLES, type SourceReader, openImportSource } from './dataImportSource.js';

/**
 * Other → Data Import (desktop UT_IMPORT "Old Softwar Import", UT_IMPORT.cs:3187), the "Lite Soft" button only
 * (BtnLite_Click, UT_IMPORT.cs:8413-8445; D-IMP-1).
 *
 * The desktop runs five steps one statement at a time with no transaction and first deletes what it replaces. The web
 * (D-IMP-2) reads the file, previews the rows per step, refuses a company that already holds vouchers, openings or
 * tags, and on the operator's Yes writes all five steps in ONE transaction: a failure anywhere leaves the company as it
 * was. The same file must give the same preview (`previewHash`), and a retried request with the same Idempotency-Key
 * answers the first result.
 *
 * After the five steps the desktop sets HDD_MAST.REF_NO = 'S', YEAR_MAST.OP_DATE = today and LOCT_MAST.TRY_DATE =
 * today + 10 (UT_IMPORT.cs:8438-8441). REF_NO and TRY_DATE are licence / trial state and are not ported (D-IMP-4);
 * OP_DATE is. The desktop then exits (Application.Exit, :8444); the web signs the operator out.
 *
 * The desktop import writes no MAIN_STOCK and no ledger legs: the stock and account refresh rebuilds them from the
 * imported rows (Ac_Stock.cs:11-34 Itm_Opbl_Stk / Tag_Opbl_Stk; Ac_Ledr.cs:9-28 AcOp_Ledr). The web has no
 * deferred refresh, so the same rows are posted in the same transaction, exactly as those routines build them.
 */

export const DATA_IMPORT_MESSAGES = {
  QUESTION: 'Are You Sure To Import Old Software Data In Next Software ?', // UT_IMPORT.cs:8422
  COMPLETE: 'Process Are Complete....', // UT_IMPORT.cs:8443
  HAS_DATA:
    'This company already has vouchers, openings or tags. Old Software Import is only for a new company; nothing was imported.',
  STALE: 'The file or the company changed after the preview. Preview the file again; nothing was imported.',
  HAS_ERRORS: 'The file has rows that cannot be imported (listed below); nothing was imported.',
} as const;

export interface DataImportScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  user: string;
}

export class DataImportError extends Error {
  constructor(
    readonly code: 'has-data' | 'stale-preview' | 'row-errors' | 'no-year' | 'file',
    message: string,
    readonly detail?: unknown,
  ) {
    super(message);
    this.name = 'DataImportError';
  }
}

/** Tables whose rows in the company mean it is not new (D-IMP-2): vouchers, openings, tags and stock. */
export const COMPANY_DATA_TABLES = [
  'AC_DATA',
  'OP_DATA',
  'ITM_OPBL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'SL_DATA',
  'PR_DATA',
] as const;

export interface StepPreview {
  step: LiteStep;
  title: string;
  desktopSource: string;
  /** Rows the step writes, per table. */
  writes: Record<string, number>;
  /** Existing rows of the company the step replaces, per table. */
  replaces: Record<string, number>;
}

export interface DataImportPreview {
  fileName: string;
  fileSha256: string;
  format: 'mdb' | 'fixture';
  sourceTables: Record<string, number>;
  ignoredTables: string[];
  steps: StepPreview[];
  errors: ImportIssue[];
  warnings: ImportIssue[];
  /** Why the company is refused, or null. */
  refusal: string | null;
  companyData: Record<string, number>;
  /** The YEAR_MAST.OP_DATE the import will set (today), ISO. */
  newOpeningDate: string;
  question: string;
  previewHash: string;
}

export interface DataImportResult extends DataImportPreview {
  applied: true;
  message: string;
}

const STEP_INFO: Record<LiteStep, { title: string; desktopSource: string }> = {
  Lite_AcMast: { title: 'Account Master', desktopSource: 'UT_IMPORT.cs:8694-8780' },
  Wh_Item: { title: 'Item Master', desktopSource: 'UT_IMPORT.cs:4241-4328' },
  WH_AcOpbl: { title: 'Party Opning', desktopSource: 'UT_IMPORT.cs:4330-4363' },
  Lite_BarData: { title: 'Bar Data', desktopSource: 'UT_IMPORT.cs:8447-8692' },
  WH_ItOpbl: { title: 'Item Opning', desktopSource: 'UT_IMPORT.cs:3887-3965' },
};

/** Today in the business time zone (the desktop's DateAndTime.Now on the shop's PC). */
export function businessToday(): string {
  const zone = process.env.PRINT_TIME_ZONE?.trim() || 'Asia/Kolkata';
  try {
    return new Intl.DateTimeFormat('en-CA', { timeZone: zone }).format(new Date());
  } catch {
    return new Date().toISOString().slice(0, 10);
  }
}

const iso = (v: unknown): string | null => {
  if (v instanceof Date) return v.toISOString().slice(0, 10);
  const s = String(v ?? '');
  return /^\d{4}-\d{2}-\d{2}/.test(s) ? s.slice(0, 10) : null;
};

async function yearTx(tx: any, s: DataImportScope): Promise<{ opDate: string; clDate: string }> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "OP_DATE"::text op, "CL_DATE" cl FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_YEAR"=$3 LIMIT 1`,
    s.tenantId,
    s.coCode,
    s.coYear,
  );
  const opDate = iso(rows[0]?.op);
  const clDate = iso(rows[0]?.cl);
  if (!opDate || !clDate)
    throw new DataImportError('no-year', `Year ${s.coYear} has no opening or closing date.`);
  return { opDate, clDate };
}

async function countTx(tx: any, s: DataImportScope, table: string, where = ''): Promise<number> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2${where}`,
    s.tenantId,
    s.coCode,
  );
  return Number(rows[0]?.n ?? 0);
}

/** AC_MAST rows Lite_AcMast replaces: the desktop's `AC_CODE >= '00101'` (UT_IMPORT.cs:8696), minus the web's system accounts. */
const REPLACED_ACCOUNTS = ` AND "AC_CODE" >= '00101' AND NOT ("AC_CODE" = ANY($3::text[]))`;

async function replacedAccountsTx(tx: any, s: DataImportScope): Promise<number> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT count(*)::int n FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2${REPLACED_ACCOUNTS}`,
    s.tenantId,
    s.coCode,
    [...SYSTEM_ACCOUNT_CODES],
  );
  return Number(rows[0]?.n ?? 0);
}

async function companyDataTx(tx: any, s: DataImportScope): Promise<Record<string, number>> {
  const out: Record<string, number> = {};
  for (const table of COMPANY_DATA_TABLES) out[table] = await countTx(tx, s, table);
  return out;
}

/** varchar lengths of the written columns, so an over-long source value is a row error, not a failed insert. */
async function columnLimitsTx(tx: any, tables: string[]): Promise<Map<string, number>> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT table_name t, column_name c, character_maximum_length l FROM information_schema.columns
      WHERE table_schema='public' AND table_name = ANY($1::text[]) AND character_maximum_length IS NOT NULL`,
    tables,
  );
  return new Map(rows.map((r) => [`${r.t}.${r.c}`, Number(r.l)]));
}

const STEP_TABLE_ROWS: Array<{ step: LiteStep; table: string; pick: (p: LitePlan) => Record<string, unknown>[]; key: string }> = [
  { step: 'Lite_AcMast', table: 'AC_MAST', pick: (p) => p.accounts, key: 'AC_CODE' },
  { step: 'Lite_AcMast', table: 'AC_MAST_SRNO', pick: (p) => (p.accountSrno ? [p.accountSrno] : []), key: 'AC_CODE' },
  { step: 'Wh_Item', table: 'PRODUCT_MAST', pick: (p) => p.products, key: 'PR_CODE' },
  { step: 'Wh_Item', table: 'GROUP_MAST', pick: (p) => p.groups, key: 'GR_CODE' },
  { step: 'Wh_Item', table: 'TABLE_MAST', pick: (p) => p.tables, key: 'TABLE_CODE' },
  { step: 'Wh_Item', table: 'ITEM_MAST', pick: (p) => p.items, key: 'IT_CODE' },
  { step: 'Lite_BarData', table: 'BAR_DATA', pick: (p) => p.barData, key: 'VCH_NO' },
  { step: 'Lite_BarData', table: 'BAR_DETL', pick: (p) => p.barDetl, key: 'TAG_NO' },
  { step: 'Lite_BarData', table: 'BAR_IDTL', pick: (p) => p.barIdtl, key: 'TAG_NO' },
  { step: 'WH_ItOpbl', table: 'ITM_OPBL', pick: (p) => p.itemOpenings, key: 'IT_CODE' },
];

function lengthErrors(plan: LitePlan, limits: Map<string, number>): ImportIssue[] {
  const out: ImportIssue[] = [];
  for (const { step, table, pick, key } of STEP_TABLE_ROWS)
    pick(plan).forEach((row, i) => {
      for (const [column, value] of Object.entries(row)) {
        if (typeof value !== 'string') continue;
        const limit = limits.get(`${table}.${column}`);
        if (limit !== undefined && value.length > limit)
          out.push({
            step,
            table,
            row: i + 1,
            key: String(row[key] ?? ''),
            reason: `${column} "${value}" is longer than ${limit} characters.`,
          });
      }
    });
  plan.accounts.forEach((row, i) => {
    if (SYSTEM_ACCOUNT_CODES.includes(String(row.AC_CODE)))
      out.push({
        step: 'Lite_AcMast',
        table: 'AC_MAST',
        row: i + 1,
        key: String(row.AC_CODE),
        reason: `Account code ${String(row.AC_CODE)} is a system account of the web chart.`,
      });
  });
  return out;
}

function stepsOf(plan: LitePlan, replaces: Record<string, number>): StepPreview[] {
  const writes: Record<LiteStep, Record<string, number>> = {
    Lite_AcMast: {
      AC_MAST: plan.accounts.length,
      AC_MAST_SRNO: plan.accountSrno ? 1 : 0,
      CO_SET: 1,
    },
    Wh_Item: {
      PRODUCT_MAST: plan.products.length,
      GROUP_MAST: plan.groups.length,
      TABLE_MAST: plan.tables.length,
      ITEM_MAST: plan.items.length,
    },
    WH_AcOpbl: {
      OP_DATA: plan.openings.length,
      AC_DATA: plan.openings.reduce(
        (n, o) => n + [o.amount, o.gold, o.silver].filter((v) => v !== 0).length,
        0,
      ),
    },
    Lite_BarData: {
      BAR_DATA: plan.barData.length,
      BAR_DETL: plan.barDetl.length,
      BAR_IDTL: plan.barIdtl.length,
      MAIN_STOCK: plan.barDetl.length,
    },
    WH_ItOpbl: { ITM_OPBL: plan.itemOpenings.length, MAIN_STOCK: plan.itemOpenings.length },
  };
  const replaced: Record<LiteStep, string[]> = {
    Lite_AcMast: ['AC_MAST', 'AC_MAST_SRNO'],
    Wh_Item: ['PRODUCT_MAST', 'GROUP_MAST', 'TABLE_MAST', 'ITEM_MAST'],
    WH_AcOpbl: [],
    Lite_BarData: [],
    WH_ItOpbl: [],
  };
  return (Object.keys(STEP_INFO) as LiteStep[]).map((step) => ({
    step,
    ...STEP_INFO[step],
    writes: writes[step],
    replaces: Object.fromEntries(replaced[step].map((t) => [t, replaces[t] ?? 0])),
  }));
}

interface Planned {
  preview: DataImportPreview;
  plan: LitePlan;
  year: { opDate: string; clDate: string };
}

async function planTx(
  tx: any,
  s: DataImportScope,
  source: SourceReader,
  file: { name: string; sha256: string },
): Promise<Planned> {
  const year = await yearTx(tx, s);
  const plan = planLiteImport(source, {
    coCode: s.coCode,
    lcCode: s.lcCode,
    coYear: s.coYear,
    clDate: year.clDate,
    opDate: year.opDate,
    user: s.user.slice(0, 15),
  });
  if (!plan.errors.length)
    plan.errors.push(
      ...lengthErrors(plan, await columnLimitsTx(tx, STEP_TABLE_ROWS.map((r) => r.table))),
    );
  const companyData = await companyDataTx(tx, s);
  const hasData = Object.values(companyData).some((n) => n > 0);
  const replaces: Record<string, number> = {
    AC_MAST: await replacedAccountsTx(tx, s),
    AC_MAST_SRNO: plan.accountSrno ? await countTx(tx, s, 'AC_MAST_SRNO') : 0,
    PRODUCT_MAST: await countTx(tx, s, 'PRODUCT_MAST'),
    GROUP_MAST: await countTx(tx, s, 'GROUP_MAST'),
    TABLE_MAST: await countTx(tx, s, 'TABLE_MAST'),
    ITEM_MAST: await countTx(tx, s, 'ITEM_MAST'),
  };
  const sourceTables: Record<string, number> = {};
  for (const t of SOURCE_TABLES) {
    const rows = source.rows(t);
    if (rows) sourceTables[t] = rows.length;
  }
  const steps = stepsOf(plan, replaces);
  const newOpeningDate = businessToday();
  const body = {
    file: file.sha256,
    scope: [s.tenantId, s.coCode, s.lcCode, s.coYear],
    steps,
    errors: plan.errors.length,
    warnings: plan.warnings.length,
    companyData,
    year,
    newOpeningDate,
  };
  const previewHash = createHash('sha256').update(JSON.stringify(body)).digest('hex');
  return {
    plan,
    year,
    preview: {
      fileName: file.name,
      fileSha256: file.sha256,
      format: source.format,
      sourceTables,
      ignoredTables: source
        .tableNames()
        .filter((t) => !(SOURCE_TABLES as string[]).includes(t))
        .sort(),
      steps,
      errors: plan.errors.slice(0, 200),
      warnings: plan.warnings.slice(0, 200),
      refusal: hasData ? DATA_IMPORT_MESSAGES.HAS_DATA : null,
      companyData,
      newOpeningDate,
      question: DATA_IMPORT_MESSAGES.QUESTION,
      previewHash,
    },
  };
}

async function sourceOf(bytes: Uint8Array): Promise<SourceReader> {
  try {
    return await openImportSource(bytes);
  } catch (error: any) {
    if (error?.name === 'SourceFileError') throw new DataImportError('file', error.message);
    throw error;
  }
}

const sha256 = (bytes: Uint8Array) => createHash('sha256').update(bytes).digest('hex');

/** Read the file and show what each step would write. Writes nothing. */
export async function previewLiteImport(
  prisma: any,
  s: DataImportScope,
  file: { name: string; bytes: Uint8Array },
): Promise<DataImportPreview> {
  const source = await sourceOf(file.bytes);
  const fileSha = sha256(file.bytes);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) =>
    (await planTx(tx, s, source, { name: file.name, sha256: fileSha })).preview,
  );
}

// ---- writing ------------------------------------------------------------------------------------------------------

const q = (id: string) => `"${id.replace(/[^A-Za-z0-9_]/g, '')}"`;

/** Multi-row INSERT with the desktop column defaults (posting.ts insertRowTx semantics), in chunks. */
export async function insertRowsTx(
  tx: any,
  table: string,
  tenantId: string,
  rows: Record<string, unknown>[],
): Promise<void> {
  if (!rows.length) return;
  const defaults = DESKTOP_COLUMN_DEFAULTS[table] ?? {};
  const full = rows.map((row) => {
    const out: Record<string, unknown> = { ...defaults, ...row };
    for (const [col, fallback] of Object.entries(defaults)) if (out[col] === null) out[col] = fallback;
    return out;
  });
  const cols = [...new Set(full.flatMap((r) => Object.keys(r)))];
  const per = Math.max(1, Math.floor(30_000 / (cols.length + 1)));
  for (let start = 0; start < full.length; start += per) {
    const chunk = full.slice(start, start + per);
    const params: unknown[] = [];
    const values = chunk.map((row) => {
      params.push(tenantId);
      const marks = [`$${params.length}`];
      for (const c of cols) {
        params.push(c in row ? row[c] : (defaults[c] ?? null));
        marks.push(`$${params.length}`);
      }
      return `(${marks.join(',')})`;
    });
    await tx.$executeRawUnsafe(
      `INSERT INTO ${q(table)}(tenant_id,${cols.map(q).join(',')}) VALUES ${values.join(',')}`,
      ...params,
    );
  }
}

async function deleteCompanyTx(tx: any, s: DataImportScope, table: string, where = '', ...extra: unknown[]) {
  await tx.$executeRawUnsafe(
    `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2${where}`,
    s.tenantId,
    s.coCode,
    ...extra,
  );
}

const dayBefore = (isoDate: string): Date => {
  const d = new Date(`${isoDate}T00:00:00.000Z`);
  d.setUTCDate(d.getUTCDate() - 1);
  return d;
};

/** Tag_Opbl_Stk (Ac_Stock.cs:22-26): an opening-book tag is one purchase-in MAIN_STOCK row, 'TAGOP' / 'TAG OPBL'. */
export function tagOpeningStock(detl: Record<string, any>): Record<string, unknown> {
  return {
    CO_CODE: detl.CO_CODE,
    LC_CODE: detl.LC_CODE,
    CO_YEAR: detl.CO_YEAR,
    CO_BOOK: detl.CO_BOOK,
    VCH_NO: detl.VCH_NO,
    SR_NO: detl.SR_NO,
    ISR_NO: 1,
    VCH_DATE: detl.VCH_DATE,
    STK_DATE: detl.STK_DATE,
    VCH_TYPE: 'TAGOP',
    BOOK_NAME: 'TAG OPBL',
    AC_CODE: '',
    IT_CODE: detl.IT_CODE,
    TAG_NO: detl.TAG_NO,
    VCH_SRNO: detl.VCH_SRNO,
    TBL_CODE: detl.TBL_CODE,
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: 1,
    ITM_PCS: detl.ITM_PCS,
    ITM_GWT: detl.ITM_GWT,
    ITM_NWT: detl.ITM_NWT,
    ITM_TOUCH: detl.ITM_TOUCH,
    ITM_WEST: detl.ITM_WEST_PRC,
    ITM_FINE: detl.ITM_FINE,
    ITM_RATE: detl.ITM_RATE,
    ITM_AMT: detl.ITM_AMT,
    LBR_RATE: detl.LBR_RATE,
    LBR_AMT: detl.LBR_AMT,
    OTH_AMT: detl.OTH_AMT,
    ITM_MRP: detl.ITM_MRP,
    NET_AMT: 0,
    KR_NWT: detl.KR_NET_WT,
    KR_TOUCH: detl.KR_TOUCH,
    KR_WEST: detl.KR_WEST_PRC,
    KR_FINE: detl.KR_FINE,
    KR_LBR_AMT: detl.KR_LBR_AMT,
    KR_OTH_AMT: detl.KR_OTH_AMT,
    KR_COST: detl.KR_COST,
    EMP_CODE: '',
    ENTRY_TIME: detl.VCH_TIME,
    MAIN_USER: detl.MAIN_USER,
    DATA_TYPE: detl.DATA_TYPE,
    DESIGN_NO: detl.DESIGN_NO,
    ITM_SIZE: detl.ITM_SIZE,
    ITM_DESC: '',
    GHT_PRC: detl.ITM_GHT_PRC,
    ITM_LOT: '',
    ITM_DISC: '0',
  };
}

/** Itm_Opbl_Stk (Ac_Stock.cs:11-20): an item opening is one 'ITOBL' / 'ITM OPBL' MAIN_STOCK row, dated MOp_dt - 1. */
export function itemOpeningStock(row: Record<string, any>, date: Date): Record<string, unknown> {
  return {
    CO_CODE: row.CO_CODE,
    LC_CODE: row.LC_CODE,
    CO_YEAR: row.CO_YEAR,
    CO_BOOK: row.CO_BOOK,
    VCH_NO: row.VCH_NO,
    SR_NO: 1,
    ISR_NO: row.SR_NO,
    VCH_DATE: date,
    STK_DATE: date.toISOString().slice(0, 10),
    VCH_TYPE: 'ITOBL',
    BOOK_NAME: 'ITM OPBL',
    AC_CODE: '00000',
    IT_CODE: row.IT_CODE,
    TAG_NO: 'N',
    VCH_SRNO: 0,
    TBL_CODE: '',
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: row.ITM_PCS,
    ITM_PCS: row.ITM_PCS,
    ITM_GWT: row.ITM_GWT,
    ITM_NWT: row.ITM_NWT,
    ITM_TOUCH: row.ITM_TOUCH,
    ITM_WEST: 0,
    ITM_FINE: row.ITM_FINE,
    ITM_RATE: row.ITM_RATE,
    ITM_AMT: row.ITM_AMT,
    LBR_RATE: 0,
    LBR_AMT: row.LBR_AMT,
    OTH_AMT: row.OTH_AMT,
    ITM_MRP: 0,
    NET_AMT: row.NET_AMT,
    KR_NWT: row.ITM_NWT,
    KR_TOUCH: row.ITM_TOUCH,
    KR_WEST: 0,
    KR_FINE: row.ITM_FINE,
    KR_LBR_AMT: row.LBR_AMT,
    KR_OTH_AMT: row.OTH_AMT,
    KR_COST: row.NET_AMT,
    EMP_CODE: '',
    ENTRY_TIME: date,
    MAIN_USER: row.MAIN_USER,
    DATA_TYPE: row.DATA_TYPE,
    DESIGN_NO: '',
    ITM_SIZE: '',
    ITM_DESC: '',
    GHT_PRC: 0,
    ITM_LOT: '',
    ITM_DISC: '0',
  };
}

/** Write the five steps in one transaction after the operator's Yes. */
export async function applyLiteImport(
  prisma: any,
  s: DataImportScope,
  file: { name: string; bytes: Uint8Array },
  previewHash: string,
): Promise<DataImportResult> {
  const source = await sourceOf(file.bytes);
  const fileSha = sha256(file.bytes);
  return withTxBudget(prisma, s.tenantId, 'heavy', async (tx: any) => {
    // One import per company at a time; a second request waits here and then finds the company no longer new.
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `data-import|${s.tenantId}|${s.coCode}`,
    );
    const { plan, preview } = await planTx(tx, s, source, { name: file.name, sha256: fileSha });
    if (preview.refusal)
      throw new DataImportError('has-data', preview.refusal, { companyData: preview.companyData });
    if (preview.errors.length)
      throw new DataImportError('row-errors', DATA_IMPORT_MESSAGES.HAS_ERRORS, {
        errors: preview.errors,
      });
    if (previewHash !== preview.previewHash)
      throw new DataImportError('stale-preview', DATA_IMPORT_MESSAGES.STALE);

    // UT_IMPORT.cs:8439-8440: YEAR_MAST.OP_DATE = today for every year of the company. Set first, so the opening legs
    // and item-opening stock take the date the desktop's refresh after the import gives them (OP_DATE - 1).
    const today = preview.newOpeningDate;
    await tx.$executeRawUnsafe(
      `UPDATE "YEAR_MAST" SET "OP_DATE"=$3 WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      s.tenantId,
      s.coCode,
      today,
    );

    // Step 1 Lite_AcMast (:8694-8780)
    await deleteCompanyTx(tx, s, 'AC_MAST', REPLACED_ACCOUNTS, [...SYSTEM_ACCOUNT_CODES]);
    await insertRowsTx(tx, 'AC_MAST', s.tenantId, plan.accounts);
    if (plan.accountSrno) {
      await deleteCompanyTx(tx, s, 'AC_MAST_SRNO');
      await insertRowsTx(tx, 'AC_MAST_SRNO', s.tenantId, [plan.accountSrno]);
    }
    await tx.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "VB_IMPORT"='Y' WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      s.tenantId,
      s.coCode,
    ); // :8778

    // Step 2 Wh_Item (:4241-4328): each master is deleted for the company and filled from the file
    for (const [table, rows] of [
      ['PRODUCT_MAST', plan.products],
      ['GROUP_MAST', plan.groups],
      ['TABLE_MAST', plan.tables],
      ['ITEM_MAST', plan.items],
    ] as const) {
      await deleteCompanyTx(tx, s, table);
      await insertRowsTx(tx, table, s.tenantId, rows);
    }

    // Step 3 WH_AcOpbl (:4330-4363): OP_DATA through the Party Opening writer, which also posts AcOp_Ledr's legs
    await deleteCompanyTx(tx, s, 'OP_DATA');
    for (const o of plan.openings)
      await writePartyOpeningTx(
        tx,
        { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear, dataType: 'A' },
        o.acCode,
        {
          amount: o.amount,
          sign: o.sign,
          gold: o.gold,
          goldSign: o.goldSign,
          silver: o.silver,
          silverSign: o.silverSign,
        },
        s.user.slice(0, 15),
      );

    // Step 4 Lite_BarData (:8447-8692) and its Tag_Opbl_Stk stock rows
    for (const table of ['BAR_DATA', 'BAR_DETL', 'BAR_IDTL']) await deleteCompanyTx(tx, s, table);
    await insertRowsTx(tx, 'BAR_DATA', s.tenantId, plan.barData);
    await insertRowsTx(tx, 'BAR_DETL', s.tenantId, plan.barDetl);
    await insertRowsTx(tx, 'BAR_IDTL', s.tenantId, plan.barIdtl);
    await insertRowsTx(tx, 'MAIN_STOCK', s.tenantId, plan.barDetl.map(tagOpeningStock));

    // Step 5 WH_ItOpbl (:3887-3965) and its Itm_Opbl_Stk stock rows
    await deleteCompanyTx(tx, s, 'ITM_OPBL');
    await insertRowsTx(tx, 'ITM_OPBL', s.tenantId, plan.itemOpenings);
    const stockDate = dayBefore(today);
    await insertRowsTx(
      tx,
      'MAIN_STOCK',
      s.tenantId,
      plan.itemOpenings.map((row) => itemOpeningStock(row, stockDate)),
    );
    return { ...preview, applied: true as const, message: DATA_IMPORT_MESSAGES.COMPLETE };
  });
}
