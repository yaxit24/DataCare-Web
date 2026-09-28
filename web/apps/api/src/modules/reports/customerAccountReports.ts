import { withTenant } from '@datacare/db';
import { applyFilters } from './reportFilters.js';
import type { ReportScope } from './reports.js';

const t = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};

const d = (v: unknown): string | null => {
  if (v instanceof Date) return v.toISOString().slice(0, 10);
  const s = t(v);
  return s ? s.slice(0, 10) : null;
};

export interface LastVisitRow {
  srNo: number;
  acName: string | null;
  mobile: string | null;
  lastVisit: string | null;
  lastTran: string | null;
  city: string | null;
  address1: string | null;
  area: string | null;
  acGroup: string | null;
  acCode: string | null;
}

export interface AddressPrintRow {
  srNo: number;
  acCode: string | null;
  acName: string | null;
  address1: string | null;
  address2: string | null;
  address3: string | null;
  city: string | null;
  pin: string | null;
  phone: string | null;
  mobile: string | null;
  mobile2: string | null;
  email: string | null;
  contactPerson: string | null;
  area: string | null;
  state: string | null;
}

function datePredicate(column: string, s: ReportScope, params: unknown[]): string {
  let sql = '';
  if (s.fromDate) {
    params.push(s.fromDate);
    sql += ` AND ${column} >= $${params.length}::date`;
  }
  if (s.toDate) {
    params.push(s.toDate);
    sql += ` AND ${column} <= $${params.length}::date`;
  }
  return sql;
}

/**
 * Desktop Last Visit report (`RP_CUST`).
 *
 * The desktop updates AC_MAST.LAST_VISIT from the most recent AC_DATA row on form load, then lists customer
 * groups 04/05/10/15/20/45/19 by date descending. The web read model avoids mutating a report request: it
 * uses the stored LAST_VISIT when present and computes the latest AC_DATA voucher as the fallback, preserving
 * the same visible columns while keeping the route read-only.
 */
export async function lastVisitReport(
  prisma: any,
  s: ReportScope,
): Promise<{ rows: LastVisitRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.tenantId, s.coCode];
    const scopeWhere = ['a.tenant_id=$1', 'a."CO_CODE"::text=$2'];
    if (s.lcCode) {
      params.push(s.lcCode);
      scopeWhere.push(`a."LC_CODE"::text=$${params.length}`);
    }
    const filterSql = applyFilters('last-visit', s.filters, params);
    const lastDateExpr = `coalesce(
      CASE
        WHEN coalesce(a."LAST_VISIT"::text,'') ~ '^\\d{2}/\\d{2}/\\d{4}$' THEN to_date(a."LAST_VISIT"::text,'MM/DD/YYYY')
        WHEN coalesce(a."LAST_VISIT"::text,'') ~ '^\\d{4}-\\d{2}-\\d{2}$' THEN a."LAST_VISIT"::date
        ELSE NULL
      END,
      latest."VCH_DATE"
    )`;
    const dateSql = datePredicate(lastDateExpr, s, params);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `WITH latest AS (
         SELECT DISTINCT ON (d.tenant_id,d."CO_CODE",d."LC_CODE",d."AC_CODE")
                d.tenant_id,d."CO_CODE",d."LC_CODE",d."AC_CODE",d."VCH_DATE",d."CO_BOOK"
           FROM "AC_DATA" d
          WHERE d.tenant_id=$1 AND d."CO_CODE"::text=$2
          ORDER BY d.tenant_id,d."CO_CODE",d."LC_CODE",d."AC_CODE",d."VCH_DATE" DESC NULLS LAST,d.row_id DESC
       )
       SELECT row_number() OVER (ORDER BY ${lastDateExpr} DESC NULLS LAST,a."AC_CODE" DESC) AS "srNo",
              a."AC_NAME" AS "acName",a."AC_MOBILE" AS "mobile",${lastDateExpr}::text AS "lastVisit",
              b."BOOK_NAME" AS "lastTran",a."AC_CITY" AS "city",a."AC_ADD1" AS "address1",
              a."AC_AREA" AS "area",a."AC_GR" AS "acGroup",a."AC_CODE" AS "acCode"
         FROM "AC_MAST" a
         LEFT JOIN latest
           ON latest.tenant_id=a.tenant_id AND latest."CO_CODE"::text=a."CO_CODE"::text
          AND latest."LC_CODE"::text=a."LC_CODE"::text AND latest."AC_CODE"::text=a."AC_CODE"::text
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id AND b."CO_CODE"::text=a."CO_CODE"::text
          AND b."LC_CODE"::text=a."LC_CODE"::text
          AND b."CO_BOOK"::text=coalesce(nullif(a."VISIT_TRAN"::text,''),latest."CO_BOOK"::text)
        WHERE ${scopeWhere.join(' AND ')}
          AND a."AC_GR"::text IN ('04','05','10','15','20','45','19')
          ${filterSql}${dateSql}
        ORDER BY ${lastDateExpr} DESC NULLS LAST,a."AC_CODE" DESC`,
      ...params,
    );
    return {
      rows: rows.map((r) => ({
        srNo: Number(r.srNo ?? 0),
        acName: t(r.acName),
        mobile: t(r.mobile),
        lastVisit: d(r.lastVisit),
        lastTran: t(r.lastTran),
        city: t(r.city),
        address1: t(r.address1),
        area: t(r.area),
        acGroup: t(r.acGroup),
        acCode: t(r.acCode),
      })),
    };
  });
}

/** Account-address label list from desktop `RP_ADDRESS` / Address type. */
export async function addressPrintReport(
  prisma: any,
  s: ReportScope,
): Promise<{ rows: AddressPrintRow[] }> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params: unknown[] = [s.tenantId, s.coCode];
    const where = ['a.tenant_id=$1', 'a."CO_CODE"::text=$2'];
    if (s.lcCode) {
      params.push(s.lcCode);
      where.push(`a."LC_CODE"::text=$${params.length}`);
    }
    const filterSql = applyFilters('address-print', s.filters, params);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT row_number() OVER (ORDER BY a."AC_NAME",a."AC_CODE") AS "srNo",
              a."AC_CODE" AS "acCode",a."AC_NAME" AS "acName",a."AC_ADD1" AS "address1",
              a."AC_ADD2" AS "address2",a."AC_ADD3" AS "address3",a."AC_CITY" AS "city",
              a."AC_PIN" AS "pin",a."AC_PHONE" AS "phone",a."AC_MOBILE" AS "mobile",
              a."AC_MOBILE2" AS "mobile2",a."AC_EMAIL" AS "email",a."AC_PERSON" AS "contactPerson",
              a."AC_AREA" AS "area",a."AC_STATE" AS "state"
         FROM "AC_MAST" a
        WHERE ${where.join(' AND ')}${filterSql}
        ORDER BY a."AC_NAME",a."AC_CODE"`,
      ...params,
    );
    return {
      rows: rows.map((r) => ({
        srNo: Number(r.srNo ?? 0),
        acCode: t(r.acCode),
        acName: t(r.acName),
        address1: t(r.address1),
        address2: t(r.address2),
        address3: t(r.address3),
        city: t(r.city),
        pin: t(r.pin),
        phone: t(r.phone),
        mobile: t(r.mobile),
        mobile2: t(r.mobile2),
        email: t(r.email),
        contactPerson: t(r.contactPerson),
        area: t(r.area),
        state: t(r.state),
      })),
    };
  });
}
