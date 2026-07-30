import { insertRowTx } from '../posting/posting.js';

/**
 * Per-field edit audit (`USER_DATA`) — the desktop's record of *what changed* when a voucher is
 * edited, distinct from `DELETE_DATA` which records deletions.
 *
 * Desktop behaviour (TR_SALE_RTN.cs:13497-13545, identical in TR_SALE, TR_WH_SALE, TR_TOUR_SALE,
 * TR_SALE_LBR, TR_MEMB_ENT and ~10 further forms): on save-over-an-existing-voucher it walks every
 * header column of the persisted row, compares it to the new value and, for each column that
 * differs, inserts one row:
 *
 *   INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,
 *                         ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,
 *                         ENTRY_CHECK)
 *   VALUES (..., <changed column name>, <old value>, <new value>, 'N')
 *
 * `USER_NAME` is the user who originally entered the voucher and `NEW_USER` the one editing it, so
 * the pair answers "who changed this, and from what". `ENTRY_CHECK` is the literal 'N'.
 *
 * This table is deliberately NOT part of any voucher write-set: an edit or delete must not erase the
 * audit trail it just produced.
 */
export interface FieldAuditKey {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
}

export interface FieldAuditInput {
  key: FieldAuditKey;
  acCode?: string | null;
  vchDate: Date;
  bookName?: string | null;
  /** User recorded on the persisted voucher (desktop USER_NAME). */
  originalUser?: string | null;
  /** User performing this edit (desktop NEW_USER). */
  editingUser?: string | null;
  /** Persisted header row as read back before the rewrite. */
  before: Record<string, unknown>;
  /** Header row about to be written. */
  after: Record<string, unknown>;
  /**
   * Columns to ignore. Identity and bookkeeping columns are excluded by default because the desktop
   * compares business columns of the reloaded header, not the rewrite bookkeeping.
   */
  ignore?: readonly string[];
}

const DEFAULT_IGNORED = [
  'tenant_id',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'VCH_TIME',
  'VCH_CLOCK',
  'ENTRY_TIME',
  'EDIT_DATE',
  'HD_VCH_NO',
  'MAIN_USER',
  'USER_UPDATE',
  'USER_DELETE',
  'DATA_TRFR',
] as const;

/** Comparable text form: dates by calendar day, numbers without trailing-zero noise, null as ''. */
function comparable(value: unknown): string {
  if (value == null) return '';
  if (value instanceof Date) {
    return `${value.getFullYear()}-${String(value.getMonth() + 1).padStart(2, '0')}-${String(
      value.getDate(),
    ).padStart(2, '0')}`;
  }
  if (typeof value === 'number') return String(value);
  const text = String(value).trim();
  // Prisma returns Decimal columns as objects/strings; normalise numeric strings so 100 and 100.00
  // are not reported as a change.
  if (text !== '' && !Number.isNaN(Number(text))) return String(Number(text));
  return text;
}

/**
 * Write one USER_DATA row per changed header column. Returns the changed column names, so callers
 * can assert the trail in tests.
 */
export async function recordFieldChangesTx(
  tx: any,
  tenantId: string,
  input: FieldAuditInput,
): Promise<string[]> {
  const ignored = new Set<string>([...DEFAULT_IGNORED, ...(input.ignore ?? [])]);
  const columns = new Set<string>([...Object.keys(input.before), ...Object.keys(input.after)]);
  const changed: string[] = [];

  for (const column of [...columns].sort()) {
    if (ignored.has(column)) continue;
    // Only columns the new header actually carries can have changed: a header that omits a column
    // leaves the persisted value untouched on rewrite.
    if (!(column in input.after)) continue;
    const before = comparable(input.before[column]);
    const after = comparable(input.after[column]);
    if (before === after) continue;
    changed.push(column);
    await insertRowTx(tx, 'USER_DATA', tenantId, {
      // Key columns are listed explicitly rather than spread: the desktop statement names them, and
      // a `...input.key` spread is invisible to the write-set analyzer, which would report this
      // table as missing its key columns when it is not.
      CO_CODE: input.key.CO_CODE,
      LC_CODE: input.key.LC_CODE,
      CO_YEAR: input.key.CO_YEAR,
      CO_BOOK: input.key.CO_BOOK,
      VCH_NO: input.key.VCH_NO,
      AC_CODE: input.acCode ?? null,
      VCH_DATE: input.vchDate,
      EDIT_DATE: input.vchDate,
      ENTRY_TIME: new Date(),
      USER_NAME: input.originalUser ?? null,
      NEW_USER: input.editingUser ?? null,
      BOOK_NAME: input.bookName ? String(input.bookName).slice(0, 20) : null,
      COL_TYPE: column.slice(0, 30),
      OLD_VAL: before.slice(0, 100),
      NEW_VAL: after.slice(0, 100),
      ENTRY_CHECK: 'N',
    });
  }
  return changed;
}
