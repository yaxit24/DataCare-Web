import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';

/**
 * Membership / loyalty (TR_MEMB_ENT + POINT_*). Members live in POINT_MEMB (PK CO_CODE+POINT_CODE+
 * MEMB_CODE). IMPORTANT desktop-fidelity note: POINT_MEMB.MEMB_POINT is varchar(1) (a flag), NOT the
 * balance — the points balance is DERIVED from the POINT_DATA ledger: Σ TOT_POINT(INOUT 'I' earn) −
 * Σ TOT_POINT(INOUT 'O' redeem) per member. Points are not money → no AC_DATA ledger entry.
 */
export class MembershipError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'MembershipError';
  }
}

const DEFAULT_POINT = 'L1';
const numv = (v: unknown): number => Number(v ?? 0);
const r2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

export interface MemberScope extends VoucherScope {}

async function balanceTx(
  tx: any,
  scope: MemberScope,
  pointCode: string,
  membCode: string,
): Promise<number> {
  const r: { bal: unknown }[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(CASE WHEN "INOUT_TYPE"='I' THEN ${NN('"TOT_POINT"')} ELSE -${NN('"TOT_POINT"')} END),0) AS bal
     FROM "POINT_DATA" WHERE "CO_CODE"=$1 AND "POINT_CODE"=$2 AND "MEMB_CODE"=$3`,
    scope.coCode,
    pointCode,
    membCode,
  );
  return r2(numv(r[0]?.bal));
}

export async function enrollMember(
  prisma: any,
  scope: MemberScope,
  m: { pointCode?: string; membCode: string; membName: string; mobile?: string; cardNo?: string },
): Promise<{ enrolled: true }> {
  if (!m.membCode || !m.membName) throw new MembershipError('member code and name are required');
  const pointCode = m.pointCode || DEFAULT_POINT;
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const ex: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "POINT_MEMB" WHERE "CO_CODE"=$1 AND "POINT_CODE"=$2 AND "MEMB_CODE"=$3 LIMIT 1`,
      scope.coCode,
      pointCode,
      m.membCode,
    );
    if (ex.length) throw new MembershipError('member already exists');
    // MEMB_POINT is a varchar(1) flag in the schema — the balance derives from POINT_DATA, never
    // from this column. The desktop still writes the three flags with fixed literals on enrolment
    // (TR_SALE.cs:20879: SL_POINT 'Y', REF_POINT '', MEMB_POINT ''), so they are written as such.
    await tx.$executeRawUnsafe(
      `INSERT INTO "POINT_MEMB"(tenant_id,"CO_CODE","POINT_CODE","MEMB_CODE","MEMB_NAME","MOBILE_NO","CARD_NO","SL_POINT","REF_POINT","MEMB_POINT","DATA_TRFR","LAST_BILL_DATE")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'Y','','',$8,$9)`,
      scope.tenantId,
      scope.coCode,
      pointCode,
      m.membCode,
      m.membName,
      m.mobile ?? null,
      m.cardNo ?? null,
      // DATA_TRFR 'N' = not yet transferred. LAST_BILL_DATE stays null on enrolment: the member has not
      // billed yet, and a date here would misreport them as active to the loyalty reminder reports.
      'N',
      null,
    );
    return { enrolled: true };
  });
}

export async function postPoints(
  prisma: any,
  scope: MemberScope,
  p: {
    pointCode?: string;
    membCode: string;
    points: number;
    type: 'earn' | 'redeem';
    amount?: number;
    /** REF_NAME — the referring member/customer (TR_SALE.cs `tRefName.Text`). */
    refName?: string;
    /** MAIN_USER — the acting operator. */
    mainUser?: string;
  },
): Promise<{ vchNo: number; balance: number }> {
  const pointCode = p.pointCode || DEFAULT_POINT;
  const inout = p.type === 'redeem' ? 'O' : 'I';
  const pts = numv(p.points);
  if (!(pts > 0)) throw new MembershipError('points must be positive');
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const mem: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "POINT_MEMB" WHERE "CO_CODE"=$1 AND "POINT_CODE"=$2 AND "MEMB_CODE"=$3 LIMIT 1`,
      scope.coCode,
      pointCode,
      p.membCode,
    );
    if (!mem.length) throw new MembershipError('member not found');
    const cur = await balanceTx(tx, scope, pointCode, p.membCode);
    if (inout === 'O' && pts > cur + 1e-9)
      throw new MembershipError(`redeem ${pts} exceeds balance ${cur}`);
    const no = await nextVoucherNoTx(tx, { ...scope, coBook: 'PNT' });
    const cols = [
      'tenant_id',
      'CO_CODE',
      'LC_CODE',
      'CO_YEAR',
      'CO_BOOK',
      'VCH_NO',
      'SR_NO',
      'VCH_DATE',
      'VCH_TYPE',
      'INOUT_TYPE',
      'POINT_CODE',
      'MEMB_CODE',
      'TOT_AMT',
      'TOT_POINT',
      // TR_SALE.cs also stamps the point classification and its provenance on every POINT_DATA row:
      // POINT_TYPE is the literal 'S' for a sale-earned point, POINT_VAL the settlement grid's point
      // value, REF_NAME the referrer, plus the generic book/user/time/sign block.
      'POINT_TYPE',
      'POINT_VAL',
      'REF_NAME',
      'BOOK_NAME',
      'ITM_SIGN',
      'MAIN_USER',
      'VCH_TIME',
    ];
    const vals: unknown[] = [
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      'PNT',
      formatVoucherNo(no),
      1,
      new Date(),
      inout === 'I' ? 'PERN' : 'PRED',
      inout,
      pointCode,
      p.membCode,
      numv(p.amount),
      pts,
      // 'S' = earned on a sale; a redemption is distinguished by INOUT_TYPE, matching the desktop.
      inout === 'I' ? 'S' : 'R',
      pts,
      (p.refName ?? '').trim().slice(0, 50) || null,
      inout === 'I' ? 'POINT EARN' : 'POINT REDEEM',
      inout === 'I' ? '+' : '-',
      (p.mainUser ?? '').trim().slice(0, 15) || null,
      new Date(),
    ];
    const colSql = cols.map((c) => (c === 'tenant_id' ? c : `"${c}"`)).join(',');
    const ph = vals.map((_, i) => '$' + (i + 1)).join(',');
    await tx.$executeRawUnsafe(`INSERT INTO "POINT_DATA"(${colSql}) VALUES (${ph})`, ...vals);
    return { vchNo: no, balance: r2(inout === 'I' ? cur + pts : cur - pts) };
  });
}

export async function listMembers(prisma: any, scope: MemberScope): Promise<Record<string, any>[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT m."MEMB_CODE" AS "membCode", m."MEMB_NAME" AS "membName", m."MOBILE_NO" AS mobile, m."POINT_CODE" AS "pointCode",
              coalesce((SELECT sum(CASE WHEN d."INOUT_TYPE"='I' THEN ${NN('d."TOT_POINT"')} ELSE -${NN('d."TOT_POINT"')} END)
                        FROM "POINT_DATA" d WHERE d."CO_CODE"=m."CO_CODE" AND d."POINT_CODE"=m."POINT_CODE" AND d."MEMB_CODE"=m."MEMB_CODE"),0) AS points
       FROM "POINT_MEMB" m WHERE m."CO_CODE"=$1 ORDER BY m."MEMB_CODE" LIMIT 200`,
      scope.coCode,
    );
    return rows.map((r) => ({
      membCode: r.membCode,
      membName: r.membName,
      mobile: r.mobile,
      pointCode: r.pointCode,
      points: r2(numv(r.points)),
    }));
  });
}
