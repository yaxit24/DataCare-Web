import { withTxBudget } from '../shared/txBudget.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import {
  formatVoucherNo,
  nextVoucherNoTx,
  nextTagNoTx,
  type VoucherScope,
} from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx } from '../posting/posting.js';
import { fineWt } from '../shared/fine.js';
import { barTagAvailableSql } from '../shared/stockSql.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';

/**
 * Tag stock lifecycle (TAG_STOCK). The desktop models availability by ROW PRESENCE:
 * a tag in stock has a row; issuing it (sale/consumption) removes the row; reversing a
 * sale restores (re-inserts) it. There is no status column. Double-issue is prevented by
 * an atomic DELETE that checks the affected-row count.
 */

export interface TagKey {
  CO_CODE: string;
  LC_CODE: string;
  TAG_NO: string;
  VCH_SRNO?: number;
  IT_CODE?: string;
}

export interface ResolvedTagIdentity extends TagKey {
  VCH_SRNO: number;
  source: 'TAG_STOCK' | 'BAR_DETL';
  stock: Record<string, unknown>;
}

export class TagNotAvailableError extends Error {
  constructor(public tag: string) {
    super(`tag not available for issue: ${tag}`);
    this.name = 'TagNotAvailableError';
  }
}

export class TagExistsError extends Error {
  constructor(public tag: string) {
    // Desktop wording (see shared/desktopMessages.ts DUPLICATE_TAG); the tag is appended for
    // diagnosis because the desktop shows the offending grid row instead.
    super(`${DESKTOP_MESSAGES.DUPLICATE_TAG}: ${tag}`);
    this.name = 'TagExistsError';
  }
}

export class TagIdentityAmbiguousValidationError extends Error {
  constructor(public tag: string) {
    super(`tag identity is ambiguous; VCH_SRNO is required: ${tag}`);
    this.name = 'TagIdentityAmbiguousValidationError';
  }
}

const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';

/** Build the ordered TAG_STOCK key. Optional desktop identity dimensions narrow imported tags. */
export function buildTagWhere(key: TagKey): { sql: string; params: Array<string | number> } {
  const clauses = ['"CO_CODE"::text=$1', '"LC_CODE"::text=$2', '"TAG_NO"::text=$3'];
  const params: Array<string | number> = [key.CO_CODE, key.LC_CODE, key.TAG_NO];
  if (key.VCH_SRNO != null) {
    params.push(key.VCH_SRNO);
    clauses.push(`coalesce("VCH_SRNO",0)::numeric=$${params.length}::numeric`);
  }
  return { sql: clauses.join(' AND '), params };
}

async function availableBarTags(tx: any, key: TagKey): Promise<Record<string, unknown>[]> {
  const params: Array<string | number> = [key.CO_CODE, key.LC_CODE, key.TAG_NO];
  const filters = [
    'b."CO_CODE"::text=$1',
    'b."LC_CODE"::text=$2',
    'b."TAG_NO"::text=$3',
    `coalesce(b."EMP_ISU"::text,'') <> 'Y'`,
  ];
  if (key.VCH_SRNO != null) {
    params.push(key.VCH_SRNO);
    filters.push(`coalesce(b."VCH_SRNO",0)::numeric=$${params.length}::numeric`);
  }
  if (key.IT_CODE) {
    params.push(key.IT_CODE);
    filters.push(`b."IT_CODE"::text=$${params.length}`);
  }
  return tx.$queryRawUnsafe(
    // KR_NET_WT / KR_TOUCH / KR_FINE are selected because a SALE LINE COPIES THEM FROM THE TAG.
    //
    // Measured across all 102 tagged sale lines on the real customer database: SL_DETL.KR_TOUCH equals
    // BAR_DETL.KR_TOUCH and SL_DETL.KR_FINE equals BAR_DETL.KR_FINE, 102 of 102 for both. They are not derived
    // - `KR_NET_WT x KR_TOUCH/100` fits only 7 of 92 rows - so the tag is the only source, and omitting them
    // here silently wrote zeros even once the sale path was asking for them.
    // The descriptive columns after KR_FINE are what TR_WH_SALE copies from the tag onto a wholesale line when
    // the tag number is entered (TR_WH_SALE.cs:10641-10736): counter, design, size, hallmark, karigar, product,
    // labour basis and rate type. Measured on the desktop rows of Next23 034/4-6 and Next25 034/1.
    //
    // ONE ROW PER INSTANCE, not per BAR_DETL row. A returned tag gets a second BAR_DETL row with the same
    // (TAG_NO, VCH_SRNO, IT_CODE) — the wholesale return re-records it under the return voucher — and both rows
    // share one stock balance. Listing each row made every returned tag "ambiguous" and unsellable. The desktop
    // groups by the instance (TR_WH_SALE.cs:10601 `GROUP BY … HAVING SUM(…) > 0`) and then reads the first
    // BAR_DETL row of that instance (:10633), which is what `DISTINCT ON … ORDER BY row_id` keeps.
    `SELECT DISTINCT ON (coalesce(b."VCH_SRNO",0),coalesce(b."IT_CODE"::text,''))
            b."CO_CODE",b."LC_CODE",b."TAG_NO",b."VCH_SRNO",b."IT_CODE",
            b."ITM_PCS",b."ITM_GWT",b."ITM_OTH_WT",b."ITM_NWT",b."ITM_GHT_PRC",b."ITM_TOUCH",
            b."ITM_WEST_PRC",b."ITM_FINE",b."TBL_CODE",b."KR_NET_WT",b."KR_TOUCH",b."KR_FINE",
            b."DESIGN_NO",b."ITM_SIZE",b."HM_ID",b."HM_ID_WT",b."KR_NAME",b."PR_CODE",
            b."LBR_TYPE",b."LBR_RATE",b."LBR_AMT",b."OTH_AMT",b."ITM_RATE",b."ITM_MRP",
            b."KR_COST",b."RATE_TYPE"
       FROM "BAR_DETL" b
      WHERE ${filters.join(' AND ')}
        AND coalesce((
          SELECT sum(CASE WHEN m."ITM_SIGN"::text='+'
                          THEN coalesce(m."VCH_SRNO",b."VCH_SRNO",1)
                          ELSE -coalesce(m."VCH_SRNO",b."VCH_SRNO",1) END)
            FROM "MAIN_STOCK" m
           WHERE m."CO_CODE"::text=b."CO_CODE"::text
             AND m."LC_CODE"::text=b."LC_CODE"::text
             AND m."TAG_NO"::text=b."TAG_NO"::text
             AND coalesce(m."VCH_SRNO",0)=coalesce(b."VCH_SRNO",0)
             AND coalesce(m."IT_CODE"::text,'')=coalesce(b."IT_CODE"::text,'')
        ),0) > 0
      ORDER BY coalesce(b."VCH_SRNO",0),coalesce(b."IT_CODE"::text,''),b.row_id`,
    ...params,
  );
}

async function existsTx(tx: any, key: TagKey): Promise<boolean> {
  const w = buildTagWhere(key);
  const stock = await tx.$queryRawUnsafe(
    `SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE ${w.sql}`,
    ...w.params,
  );
  if (Number(stock[0]?.n ?? 0) > 0) return true;
  return (await availableBarTags(tx, key)).length === 1;
}

/**
 * The `TAG_STOCK` columns the desktop writes (`MS_PRODUCT.cs`), declared explicitly.
 *
 * `insertTagTx` builds its INSERT from `Object.keys(data)`, which is flexible but makes the written
 * column set unmeasurable — the depth audit reported this table as never written while it was in fact
 * being written on every tag creation. Declaring the set here makes the write auditable and gives callers
 * a checkable contract, without changing the dynamic insert that follows.
 */
export const TAG_STOCK_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'TAG_NO',
  'VCH_SRNO',
  'SR_NO',
  'IT_TYPE',
  'PR_CODE',
  'PR_NAME',
  'GR_CODE',
  'GR_NAME',
  'GR_RATE',
  'DESIGN_NO',
  'DESIGN_IMG_ID',
  'ITM_SIZE',
  'ITM_PCS',
  'ITM_GWT',
  'ITM_NWT',
  'ITM_MRP',
  'LBR_TYPE',
  'LBR_PRC',
  'LBR_RATE',
  'LBR_AMT',
  'OTH_AMT',
  'STK_TYPE',
  'MAIN_USER',
] as const;

async function insertTagTx(
  tx: any,
  tenantId: string,
  data: Record<string, unknown> & TagKey,
): Promise<void> {
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `tag-stock|${tenantId}|${data.CO_CODE}|${data.LC_CODE}|${data.TAG_NO}`,
  );
  const w = buildTagWhere(data);
  const present = await tx.$queryRawUnsafe(
    `SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE ${w.sql}`,
    ...w.params,
  );
  if (Number(present[0]?.n ?? 0) > 0) throw new TagExistsError(data.TAG_NO);
  // The declared column set governs the write: anything outside it is a caller mistake, and this is what
  // makes the write auditable instead of an opaque Object.keys() spread.
  const allowed = new Set<string>(TAG_STOCK_COLUMNS);
  const unknownColumns = Object.keys(data).filter((c) => !allowed.has(c));
  if (unknownColumns.length) {
    throw new Error(`insertTagTx: unknown TAG_STOCK column(s) ${unknownColumns.join(', ')}`);
  }
  // Emit in the declared order so the statement is stable regardless of object key order.
  const cols = TAG_STOCK_COLUMNS.filter((c) => c in data);
  const colSql = ['tenant_id', ...cols.map(q)].join(',');
  const ph = cols.map((_, i) => '$' + (i + 2)).join(',');
  await tx.$executeRawUnsafe(
    `INSERT INTO "TAG_STOCK"(${colSql}) VALUES ($1,${ph})`,
    tenantId,
    ...cols.map((c) => data[c]),
  );
}

export async function tagAvailable(prisma: any, tenantId: string, key: TagKey): Promise<boolean> {
  return withTxBudget(prisma, tenantId, 'read', (tx: any) => existsTx(tx, key));
}

export async function createTag(
  prisma: any,
  tenantId: string,
  data: Record<string, unknown> & TagKey,
): Promise<{ created: true }> {
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await insertTagTx(tx, tenantId, data);
    return { created: true };
  });
}

/**
 * Resolve a live tag identity WITHOUT consuming it.
 *
 * Same resolution and same refusals as `issueTagTx` — this is that function's first half, extracted so a caller
 * that must learn a tag's serial does not have to reserve the tag to find it out. Karigar issue needs exactly
 * that: the desktop records an issued tag as a signed `-` movement and has no live-tag table at all
 * (`TR_KR_ISU.cs` references `TAG_STOCK` zero times), so consuming the web's `TAG_STOCK` row would add a
 * reversal obligation the desktop does not have.
 *
 * The advisory lock is still taken, and is transaction-scoped, so a caller that goes on to consume the tag in
 * the same transaction holds the same lock throughout.
 */
export async function resolveLiveTagIdentityTx(tx: any, key: TagKey): Promise<ResolvedTagIdentity> {
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `tag-issue|${key.CO_CODE}|${key.LC_CODE}|${key.TAG_NO}`,
  );
  const w = buildTagWhere(key);
  const stockRows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "TAG_STOCK" WHERE ${w.sql} FOR UPDATE`,
    ...w.params,
  );
  if (stockRows.length > 1) throw new TagIdentityAmbiguousValidationError(key.TAG_NO);
  if (stockRows.length === 1) {
    const row = stockRows[0] as Record<string, unknown>;
    return {
      CO_CODE: key.CO_CODE,
      LC_CODE: key.LC_CODE,
      TAG_NO: key.TAG_NO,
      VCH_SRNO: Number(row.VCH_SRNO ?? key.VCH_SRNO ?? 0),
      IT_CODE: key.IT_CODE,
      source: 'TAG_STOCK',
      stock: row,
    };
  }

  const barRows = await availableBarTags(tx, key);
  if (barRows.length === 0) throw new TagNotAvailableError(key.TAG_NO);
  if (barRows.length > 1) throw new TagIdentityAmbiguousValidationError(key.TAG_NO);
  const row = barRows[0] as Record<string, unknown>;
  return {
    CO_CODE: key.CO_CODE,
    LC_CODE: key.LC_CODE,
    TAG_NO: key.TAG_NO,
    VCH_SRNO: Number(row.VCH_SRNO ?? 0),
    IT_CODE: String(row.IT_CODE ?? key.IT_CODE ?? ''),
    source: 'BAR_DETL',
    stock: row,
  };
}

/** Resolve and reserve a tag under an identity advisory lock. TAG_STOCK rows are removed; imported
 * BAR_DETL rows remain and become unavailable when this transaction writes its MAIN_STOCK '-' leg. */
export async function issueTagTx(tx: any, key: TagKey): Promise<ResolvedTagIdentity> {
  const identity = await resolveLiveTagIdentityTx(tx, key);
  if (identity.source === 'TAG_STOCK') {
    const w = buildTagWhere(key);
    await tx.$executeRawUnsafe(`DELETE FROM "TAG_STOCK" WHERE ${w.sql}`, ...w.params);
  }
  return identity;
}

export async function restoreTagTx(
  tx: any,
  tenantId: string,
  data: Record<string, unknown> & TagKey,
): Promise<void> {
  await insertTagTx(tx, tenantId, data);
}

export async function createTagTx(
  tx: any,
  tenantId: string,
  data: Record<string, unknown> & TagKey,
): Promise<void> {
  await insertTagTx(tx, tenantId, data);
}

/**
 * Issue (sell/consume) a tag: atomically remove it from available stock. If it is not present
 * (already issued), throw TagNotAvailableError — this is the double-issue guard (Req 8.x).
 */
export async function issueTag(
  prisma: any,
  tenantId: string,
  key: TagKey,
): Promise<{ issued: true }> {
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await issueTagTx(tx, key);
    return { issued: true };
  });
}

/** Restore a previously-issued tag back into stock (on sale reversal). Rejects if already present. */
export async function restoreTag(
  prisma: any,
  tenantId: string,
  data: Record<string, unknown> & TagKey,
): Promise<{ restored: true }> {
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await restoreTagTx(tx, tenantId, data);
    return { restored: true };
  });
}

/** On-hand balance over the tag inventory (BAR_DETL) for a CO scope (LC optional). */
export async function onHand(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE?: string },
): Promise<{ pcs: number; gwt: number; nwt: number; fine: number }> {
  const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const lc = scope.LC_CODE ? ' AND b."LC_CODE"::text=$2' : '';
    const params = scope.LC_CODE ? [scope.CO_CODE, scope.LC_CODE] : [scope.CO_CODE];
    const r = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(${NN('b."ITM_PCS"')}),0)::float AS pcs, coalesce(sum(${NN('b."ITM_GWT"')}),0)::float AS gwt, coalesce(sum(${NN('b."ITM_NWT"')}),0)::float AS nwt, coalesce(sum(${NN('b."ITM_FINE"')}),0)::float AS fine
         FROM "BAR_DETL" b
        WHERE b."CO_CODE"::text=$1${lc} AND ${barTagAvailableSql('b')}`,
      ...params,
    );
    return {
      pcs: Number(r[0].pcs) || 0,
      gwt: Number(r[0].gwt) || 0,
      nwt: Number(r[0].nwt) || 0,
      fine: Number(r[0].fine) || 0,
    };
  });
}

/**
 * On-hand as the full signed `MAIN_STOCK` net (Req 14.4 / desktop `Ac_Stock` ItemSummInsert): for a
 * CO/LC scope, Σ(+in) − Σ(−out) of pcs/gross/net/**fine** across EVERY movement (tagged opening,
 * purchase, sale, tag ops, AND non-tag `ITM_OPBL`/lot) — not just BAR_DETL tags. This is the
 * desktop's stock-truth (there is no stored balance).
 */
export async function onHandNet(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE?: string },
): Promise<{ pcs: number; gwt: number; nwt: number; fine: number }> {
  const S = (c: string): string =>
    `sum(CASE WHEN "ITM_SIGN"::text='+' THEN coalesce(NULLIF(${c}::text,'')::numeric,0) ELSE -coalesce(NULLIF(${c}::text,'')::numeric,0) END)`;
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const behavior = await resolveSettingsBehaviorTx(tx, { tenantId, coCode: scope.CO_CODE });
    // RP_STOCK.cs/RP_TAG.cs MsCoStockMerge branches widen company scope; tenant RLS remains active.
    const company = behavior.companyStockMerge ? '' : ' AND "CO_CODE"::text=$1';
    const lc = scope.LC_CODE ? ` AND "LC_CODE"::text=$${behavior.companyStockMerge ? 1 : 2}` : '';
    const params = behavior.companyStockMerge
      ? scope.LC_CODE
        ? [scope.LC_CODE]
        : []
      : scope.LC_CODE
        ? [scope.CO_CODE, scope.LC_CODE]
        : [scope.CO_CODE];
    const r = await tx.$queryRawUnsafe(
      `SELECT coalesce(${S('"ITM_PCS"')},0)::float AS pcs, coalesce(${S('"ITM_GWT"')},0)::float AS gwt, coalesce(${S('"ITM_NWT"')},0)::float AS nwt, coalesce(${S('"ITM_FINE"')},0)::float AS fine
       FROM "MAIN_STOCK" WHERE true${company}${lc}`,
      ...params,
    );
    return {
      pcs: Number(r[0].pcs) || 0,
      gwt: Number(r[0].gwt) || 0,
      nwt: Number(r[0].nwt) || 0,
      fine: Number(r[0].fine) || 0,
    };
  });
}

/** List in-stock tags (BAR_DETL — real desktop tag inventory) for a CO scope (LC optional). */
export async function listTags(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE?: string },
  limit = 200,
): Promise<Record<string, unknown>[]> {
  const n = Math.min(Number(limit) || 200, 500);
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const lc = scope.LC_CODE ? ' AND b."LC_CODE"::text=$2' : '';
    const params = scope.LC_CODE ? [scope.CO_CODE, scope.LC_CODE] : [scope.CO_CODE];
    const rows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO",b."VCH_SRNO",b."IT_CODE",b."ITM_PCS",b."ITM_GWT",b."ITM_NWT",b."ITM_FINE",b."ITM_MRP"
         FROM "BAR_DETL" b
        WHERE b."CO_CODE"::text=$1${lc} AND ${barTagAvailableSql('b')}
        ORDER BY b."TAG_NO",coalesce(b."VCH_SRNO",0) LIMIT ${n}`,
      ...params,
    );
    return rows.map((r) =>
      Object.fromEntries(
        Object.entries(r).map(([k, v]) => [k, typeof v === 'bigint' ? Number(v) : v]),
      ),
    );
  });
}

/**
 * Physical stock reconciliation (TR_PHYSTK): compare physically-counted tag numbers against the
 * book (TAG_STOCK). missing = in book but not counted (shortage); extra = counted but not in book
 * (surplus/untagged). Read-only — produces the variance the operator acts on.
 */
export async function physicalReconcileLegacy(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  counted: Array<string | { tagNo: string; netWt?: number }>,
): Promise<{
  matched: string[];
  missing: string[];
  extra: string[];
  detail: Array<{
    tagNo: string;
    status: 'matched' | 'missing' | 'extra';
    bookWt: number;
    countedWt: number | null;
    diffWt: number;
  }>;
  bookCount: number;
  countedCount: number;
  matchedCount: number;
  missingCount: number;
  extraCount: number;
}> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    // Book = REAL desktop tag inventory (BAR_DETL) still in stock (no MAIN_STOCK '-' out-movement).
    const rows: { TAG_NO: unknown; VCH_SRNO: unknown; nwt: unknown }[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO",b."VCH_SRNO",coalesce(NULLIF(b."ITM_NWT"::text,'')::numeric,0)::float AS nwt
           FROM "BAR_DETL" b
          WHERE b."CO_CODE"::text=$1 AND b."LC_CODE"::text=$2
            AND ${barTagAvailableSql('b')}`,
      scope.CO_CODE,
      scope.LC_CODE,
    );
    const bookWt = new Map<string, number>(rows.map((r) => [String(r.TAG_NO), Number(r.nwt)]));
    const book = new Set(bookWt.keys());
    const cmap = new Map<string, number | undefined>();
    for (const c of counted) {
      if (typeof c === 'string') {
        const t = c.trim();
        if (t) cmap.set(t, undefined);
      } else if (c && c.tagNo) {
        const t = String(c.tagNo).trim();
        if (t) cmap.set(t, c.netWt != null ? Number(c.netWt) : undefined);
      }
    }
    const counted2 = new Set(cmap.keys());
    const matched = [...counted2].filter((t) => book.has(t));
    const missing = [...book].filter((t) => !counted2.has(t));
    const extra = [...counted2].filter((t) => !book.has(t));
    const r3d = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
    const detail = [
      ...matched.map((t) => {
        const bw = bookWt.get(t) ?? 0;
        const cw = cmap.get(t);
        return {
          tagNo: t,
          status: 'matched' as const,
          bookWt: bw,
          countedWt: cw ?? null,
          diffWt: cw != null ? r3d(cw - bw) : 0,
        };
      }),
      ...missing.map((t) => ({
        tagNo: t,
        status: 'missing' as const,
        bookWt: bookWt.get(t) ?? 0,
        countedWt: null,
        diffWt: r3d(-(bookWt.get(t) ?? 0)),
      })),
      ...extra.map((t) => ({
        tagNo: t,
        status: 'extra' as const,
        bookWt: 0,
        countedWt: cmap.get(t) ?? null,
        diffWt: cmap.get(t) ?? 0,
      })),
    ];
    return {
      matched,
      missing,
      extra,
      detail,
      bookCount: book.size,
      countedCount: counted2.size,
      matchedCount: matched.length,
      missingCount: missing.length,
      extraCount: extra.length,
    };
  });
}

/** Exact physical reconciliation keyed by the desktop tag instance (TAG_NO + VCH_SRNO). */
export async function physicalReconcile(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  counted: Array<string | { tagNo: string; vchSrno?: number; netWt?: number }>,
): Promise<{
  matched: string[];
  missing: string[];
  extra: string[];
  detail: Array<{
    tagNo: string;
    vchSrno: number;
    status: 'matched' | 'missing' | 'extra';
    bookWt: number;
    countedWt: number | null;
    diffWt: number;
  }>;
  bookCount: number;
  countedCount: number;
  matchedCount: number;
  missingCount: number;
  extraCount: number;
}> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const rows: { TAG_NO: unknown; VCH_SRNO: unknown; nwt: unknown }[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO",b."VCH_SRNO",coalesce(NULLIF(b."ITM_NWT"::text,'')::numeric,0)::float AS nwt
           FROM "BAR_DETL" b
          WHERE b."CO_CODE"::text=$1 AND b."LC_CODE"::text=$2
            AND coalesce(upper(btrim(b."EMP_ISU"::text)),'N') <> 'Y'
            AND ${barTagAvailableSql('b')}`,
      scope.CO_CODE,
      scope.LC_CODE,
    );
    const keyOf = (tagNo: string, vchSrno: number): string => `${tagNo}|${vchSrno}`;
    const bookRows = new Map<string, { tagNo: string; vchSrno: number; bookWt: number }>();
    const byTag = new Map<string, string[]>();
    for (const row of rows) {
      const tagNo = String(row.TAG_NO ?? '').trim();
      const vchSrno = Number(row.VCH_SRNO ?? 0);
      const rowKey = keyOf(tagNo, vchSrno);
      bookRows.set(rowKey, { tagNo, vchSrno, bookWt: Number(row.nwt ?? 0) });
      byTag.set(tagNo, [...(byTag.get(tagNo) ?? []), rowKey]);
    }
    const countedRows = new Map<string, { tagNo: string; vchSrno: number; countedWt?: number }>();
    for (const value of counted) {
      const tagNo = String(typeof value === 'string' ? value : (value?.tagNo ?? '')).trim();
      if (!tagNo) continue;
      const requestedSrno = typeof value === 'string' ? 0 : Number(value.vchSrno ?? 0);
      const candidates = byTag.get(tagNo) ?? [];
      const rowKey =
        requestedSrno > 0
          ? keyOf(tagNo, requestedSrno)
          : candidates.length === 1
            ? candidates[0]!
            : keyOf(tagNo, 0);
      const resolved = bookRows.get(rowKey);
      countedRows.set(rowKey, {
        tagNo,
        vchSrno: resolved?.vchSrno ?? requestedSrno,
        countedWt:
          typeof value === 'string' || value.netWt == null ? undefined : Number(value.netWt),
      });
    }
    const bookKeys = new Set(bookRows.keys());
    const countedKeys = new Set(countedRows.keys());
    const matched = [...countedKeys].filter((rowKey) => bookKeys.has(rowKey));
    const missing = [...bookKeys].filter((rowKey) => !countedKeys.has(rowKey));
    const extra = [...countedKeys].filter((rowKey) => !bookKeys.has(rowKey));
    const r3 = (value: number): number => Math.round((value + 1e-9) * 1000) / 1000;
    const detail = [
      ...matched.map((rowKey) => {
        const book = bookRows.get(rowKey)!;
        const physical = countedRows.get(rowKey)!;
        return {
          tagNo: book.tagNo,
          vchSrno: book.vchSrno,
          status: 'matched' as const,
          bookWt: book.bookWt,
          countedWt: physical.countedWt ?? null,
          diffWt: physical.countedWt == null ? 0 : r3(physical.countedWt - book.bookWt),
        };
      }),
      ...missing.map((rowKey) => {
        const book = bookRows.get(rowKey)!;
        return {
          tagNo: book.tagNo,
          vchSrno: book.vchSrno,
          status: 'missing' as const,
          bookWt: book.bookWt,
          countedWt: null,
          diffWt: r3(-book.bookWt),
        };
      }),
      ...extra.map((rowKey) => {
        const physical = countedRows.get(rowKey)!;
        return {
          tagNo: physical.tagNo,
          vchSrno: physical.vchSrno,
          status: 'extra' as const,
          bookWt: 0,
          countedWt: physical.countedWt ?? null,
          diffWt: r3(physical.countedWt ?? 0),
        };
      }),
    ];
    return {
      matched,
      missing,
      extra,
      detail,
      bookCount: bookKeys.size,
      countedCount: countedKeys.size,
      matchedCount: matched.length,
      missingCount: missing.length,
      extraCount: extra.length,
    };
  });
}
/** List the in-stock tags (BAR_DETL, not sold) for the physical-count scan grid, with optional
 *  counter (TBL_CODE) / item (IT_CODE) filters. */
export async function physicalStockList(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  filters?: {
    tblCode?: string;
    itCode?: string;
    tagNo?: string;
    vchSrno?: number;
    limit?: number;
    offset?: number;
  },
): Promise<
  Array<{
    tagNo: string;
    vchSrno: number;
    itCode: string;
    itemName: string;
    designNo: string | null;
    itmSize: string | null;
    tblCode: string | null;
    pieces: number;
    netWt: number;
    grossWt: number;
    otherWt: number;
    touch: number;
    labourAmount: number;
    otherAmount: number;
    mrp: number;
    karigarName: string | null;
  }>
> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const cl: string[] = [];
    if (filters?.tblCode) {
      params.push(filters.tblCode);
      cl.push(`b."TBL_CODE"::text=$${params.length}`);
    }
    if (filters?.itCode) {
      params.push(filters.itCode);
      cl.push(`b."IT_CODE"::text=$${params.length}`);
    }
    if (filters?.tagNo) {
      params.push(filters.tagNo);
      cl.push(`b."TAG_NO"::text=$${params.length}`);
    }
    if (filters?.vchSrno != null && Number(filters.vchSrno) > 0) {
      params.push(Number(filters.vchSrno));
      cl.push(`coalesce(b."VCH_SRNO",0)::numeric=$${params.length}::numeric`);
    }
    const limit = Math.min(Math.max(Number(filters?.limit) || 500, 1), 500);
    const offset = Math.max(Number(filters?.offset) || 0, 0);
    const extra = cl.length ? ' AND ' + cl.join(' AND ') : '';
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO" tag,b."VCH_SRNO" vs,b."IT_CODE" it,coalesce(i."IT_NAME",'') nm,
              b."DESIGN_NO" dn,b."ITM_SIZE" sz,b."TBL_CODE" tc,b."KR_NAME" kr,
              coalesce(NULLIF(b."ITM_PCS"::text,'')::numeric,0)::float pcs,
              coalesce(NULLIF(b."ITM_NWT"::text,'')::numeric,0)::float nwt,
              coalesce(NULLIF(b."ITM_GWT"::text,'')::numeric,0)::float gwt,
              coalesce(NULLIF(b."ITM_OTH_WT"::text,'')::numeric,0)::float owt,
              coalesce(NULLIF(b."ITM_TOUCH"::text,'')::numeric,0)::float touch,
              coalesce(NULLIF(b."LBR_AMT"::text,'')::numeric,0)::float lamt,
              coalesce(NULLIF(b."OTH_AMT"::text,'')::numeric,0)::float oamt,
              coalesce(NULLIF(b."ITM_MRP"::text,'')::numeric,0)::float mrp
         FROM "BAR_DETL" b
         LEFT JOIN "ITEM_MAST" i ON i.tenant_id=b.tenant_id AND i."CO_CODE"=b."CO_CODE"
                                AND i."IT_CODE"=b."IT_CODE"
        WHERE b."CO_CODE"::text=$1 AND b."LC_CODE"::text=$2${extra}
          AND coalesce(upper(btrim(b."EMP_ISU"::text)),'N') <> 'Y'
          AND ${barTagAvailableSql('b')}
        ORDER BY b."TAG_NO",coalesce(b."VCH_SRNO",0) LIMIT ${limit} OFFSET ${offset}`,
      ...params,
    );
    return rows.map((r) => ({
      tagNo: String(r.tag),
      vchSrno: Number(r.vs ?? 0),
      itCode: String(r.it ?? ''),
      itemName: String(r.nm ?? ''),
      designNo: r.dn ?? null,
      itmSize: r.sz ?? null,
      tblCode: r.tc ?? null,
      pieces: Number(r.pcs),
      netWt: Number(r.nwt),
      grossWt: Number(r.gwt),
      otherWt: Number(r.owt),
      touch: Number(r.touch),
      labourAmount: Number(r.lamt),
      otherAmount: Number(r.oamt),
      mrp: Number(r.mrp),
      karigarName: r.kr ?? null,
    }));
  });
}

export {
  tagOpening,
  getTagOpening,
  editTagOpening,
  deleteTagOpening,
  itemOpening,
  getItemOpening,
  editItemOpening,
  deleteItemOpening,
  itemLot,
  getItemLot,
  editItemLot,
  deleteItemLot,
  StockVoucherValidationError,
} from './stockVoucherLifecycle.js';
export type {
  TagOpeningLine,
  TagOpeningInput,
  ItemOpeningLine,
  ItemOpeningInput,
  ItemLotLine,
  ItemLotInput,
} from './stockVoucherLifecycle.js';

// ───────────────────────── Stock Adjust voucher (TR_STK_ADJ) ─────────────────────────
export interface StockAdjustLine {
  itCode: string;
  tagNo?: string;
  sign?: '+' | '-';
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  rate?: number;
  tblCode?: string;
  designNo?: string;
  itmSize?: string;
  lessWt?: number;
  westPct?: number;
  mrp?: number;
  krCode?: string;
}
export interface StockAdjustInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  lines: StockAdjustLine[];
}

/**
 * Stock Adjust (TR_STK_ADJ) — a manual stock-correction voucher: per line ADD (+) or REMOVE (-) loose/
 * tagged stock via a signed MAIN_STOCK movement (VCH_TYPE 'STADJ' / BOOK_NAME 'STOCK ADJ' / TR_TYPE 'A').
 * No money ledger (pure inventory). Reversible by voucher key. Book 'SAJ'. Distinct from physical-stock
 * reconcile (read-only) — this is the adjusting voucher that actually changes on-hand.
 */
export async function stockAdjust(
  prisma: any,
  input: StockAdjustInput,
): Promise<{ vchNo: number; lines: number }> {
  if (!input.lines?.length)
    throw new TagNotAvailableError('(stock adjust: at least one line required)');
  const tenantId = input.scope.tenantId;
  const N = (v: unknown): number => (v == null ? 0 : Number(v));
  const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
  const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear ?? '',
      CO_BOOK: input.scope.coBook ?? 'SAJ',
      VCH_NO: formatVoucherNo(no),
    };
    const fineOf = (l: StockAdjustLine): number =>
      r3((N(l.netWt) * (N(l.touch) + N(l.westPct))) / 100);
    const mainStock = input.lines.map((l, i) => ({
      ...key,
      SR_NO: i + 1,
      ISR_NO: 2,
      VCH_DATE: vchDate,
      STK_DATE: vchDate,
      VCH_TYPE: 'STADJ',
      BOOK_NAME: 'STOCK ADJ',
      IT_CODE: l.itCode,
      TAG_NO: l.tagNo ?? 'N',
      TBL_CODE: l.tblCode ?? '000',
      TR_TYPE: 'A',
      ITM_SIGN: l.sign === '-' ? '-' : '+',
      ITM_QTY: N(l.pcs) || 1,
      ITM_PCS: N(l.pcs),
      ITM_GWT: N(l.grossWt),
      ITM_NWT: N(l.netWt),
      ITM_TOUCH: N(l.touch),
      ITM_WEST: N(l.westPct),
      DESIGN_NO: l.designNo ?? null,
      ITM_SIZE: l.itmSize ?? null,
      ITM_MRP: N(l.mrp),
      AC_CODE: l.krCode ?? null,
      ITM_FINE: fineOf(l),
      ITM_RATE: N(l.rate),
      ITM_AMT: r2(fineOf(l) * N(l.rate)),
      NET_AMT: r2(fineOf(l) * N(l.rate)),
    }));
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes: [{ table: 'MAIN_STOCK', rows: mainStock }],
    });
    return { vchNo: no, lines: input.lines.length };
  });
}

/** Delete/reverse a stock-adjust voucher (removes its MAIN_STOCK rows by voucher key). */
export async function deleteStockAdjust(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; book?: string; deleteUser?: string },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_YEAR: input.scope.coYear ?? '',
    CO_BOOK: input.scope.coBook ?? input.book ?? 'SAJ',
    VCH_NO: formatVoucherNo(input.vchNo),
  };
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['MAIN_STOCK'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'STADJ', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}

// ───────────────────────── Counter Transfer (TR_COUNTER_TRFR) ─────────────────────────
export interface CounterTransferLine {
  itCode: string;
  tagNo?: string;
  fromCounter: string;
  toCounter: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  rate?: number;
}
export interface CounterTransferInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  lines: CounterTransferLine[];
}

/**
 * Counter Transfer (desktop "Counter Trfr"): relocate stock from one counter to another. Per line we
 * emit a MAIN_STOCK OUT of the source counter (TBL_CODE=fromCounter, ITM_SIGN '-') and an IN to the
 * target counter (TBL_CODE=toCounter, ITM_SIGN '+') with the same item/weight/fine, so total on-hand
 * is unchanged and only the counter location moves. No money ledger. Book 'CTR'. Reversible.
 */
export async function counterTransfer(
  prisma: any,
  input: CounterTransferInput,
): Promise<{ vchNo: number; lines: number }> {
  if (!input.lines?.length)
    throw new TagNotAvailableError('(counter transfer: at least one line required)');
  for (const l of input.lines) {
    if (!l.fromCounter || !l.toCounter)
      throw new TagNotAvailableError('(counter transfer: fromCounter and toCounter are required)');
    if (l.fromCounter === l.toCounter)
      throw new TagNotAvailableError('(counter transfer: from and to counters must differ)');
  }
  const tenantId = input.scope.tenantId;
  const N = (v: unknown): number => (v == null ? 0 : Number(v));
  const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
  const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const no = await nextVoucherNoTx(tx, { ...input.scope, coBook: 'CTR' });
    const key = {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear ?? '',
      CO_BOOK: 'CTR',
      VCH_NO: formatVoucherNo(no),
    };
    const rows: any[] = [];
    let sr = 0;
    for (const l of input.lines) {
      const fine = fineWt(l.netWt, l.ghtWt, l.touch, l.westPct);
      const amt = r2(fine * N(l.rate));
      const base = {
        ...key,
        ISR_NO: 2,
        VCH_DATE: vchDate,
        STK_DATE: vchDate,
        VCH_TYPE: 'CTRF',
        BOOK_NAME: 'COUNTER TRFR',
        TR_TYPE: 'A',
        IT_CODE: l.itCode,
        TAG_NO: l.tagNo ?? 'N',
        ITM_QTY: N(l.pcs) || 1,
        ITM_PCS: N(l.pcs),
        ITM_GWT: N(l.grossWt),
        ITM_NWT: N(l.netWt),
        ITM_TOUCH: N(l.touch),
        ITM_FINE: fine,
        ITM_RATE: N(l.rate),
        ITM_AMT: amt,
        NET_AMT: amt,
      };
      sr += 1;
      rows.push({ ...base, SR_NO: sr, TBL_CODE: l.fromCounter, ITM_SIGN: '-' }); // OUT source counter
      sr += 1;
      rows.push({ ...base, SR_NO: sr, TBL_CODE: l.toCounter, ITM_SIGN: '+' }); // IN target counter
    }
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes: [{ table: 'MAIN_STOCK', rows }],
    });
    return { vchNo: no, lines: input.lines.length };
  });
}

/** Delete/reverse a counter-transfer voucher (removes its MAIN_STOCK rows by voucher key). */
export async function deleteCounterTransfer(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; book?: string; deleteUser?: string },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_YEAR: input.scope.coYear ?? '',
    CO_BOOK: input.scope.coBook ?? input.book ?? 'CTR',
    VCH_NO: formatVoucherNo(input.vchNo),
  };
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['MAIN_STOCK'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'CTRF', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}
