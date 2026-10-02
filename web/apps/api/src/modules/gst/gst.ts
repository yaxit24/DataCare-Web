import { withTxBudget } from '../shared/txBudget.js';

/**
 * GSTR-1 return datasets (read-only) over the sales tables. Classification follows GST rules using
 * columns actually present: inter- vs intra-state is read from the posted tax (IGST>0 ⇒ inter);
 * B2B = recipient has a GSTIN (AC_MAST.AC_GSTNO); B2CL = unregistered inter-state with invoice value
 * over the threshold; B2CS = remaining B2C summarized by place-of-supply + rate; HSN summary groups
 * detail by HSN (IT_CODE proxy — a dedicated HSN master is a parity item, see Task 30).
 */

/** B2CL invoice-value threshold (₹). Configurable; current GST value is 2,50,000. */
export const B2CL_THRESHOLD = 250000;

export type GstCategory = 'B2B' | 'B2CL' | 'B2CS';

export interface InvoiceRow {
  vchNo: string;
  acCode: string;
  gstin: string | null;
  interState: boolean;
  invoiceValue: number;
  taxable: number;
  cgst: number;
  sgst: number;
  igst: number;
  stateCode: string | null;
  ratePct: number;
}

export interface HsnDetailRow {
  hsn: string;
  qty: number;
  taxable: number;
  cgst: number;
  sgst: number;
  igst: number;
}

const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const hasGstin = (g: string | null | undefined): boolean => !!(g && g.trim());

/** Classify one invoice into a GSTR-1 bucket (Req 18). */
export function classifyInvoice(
  inv: Pick<InvoiceRow, 'gstin' | 'interState' | 'invoiceValue'>,
  threshold = B2CL_THRESHOLD,
): GstCategory {
  if (hasGstin(inv.gstin)) return 'B2B';
  if (inv.interState && inv.invoiceValue > threshold) return 'B2CL';
  return 'B2CS';
}

export interface B2csRow {
  stateCode: string;
  ratePct: number;
  taxable: number;
  cgst: number;
  sgst: number;
  igst: number;
}

/** Summarize B2C-small invoices by (place-of-supply state, rate). */
export function summarizeB2CS(invoices: InvoiceRow[]): B2csRow[] {
  const map = new Map<string, B2csRow>();
  for (const inv of invoices) {
    const state = inv.stateCode ?? '';
    const key = `${state}|${inv.ratePct}`;
    const r = map.get(key) ?? {
      stateCode: state,
      ratePct: inv.ratePct,
      taxable: 0,
      cgst: 0,
      sgst: 0,
      igst: 0,
    };
    r.taxable = round2(r.taxable + inv.taxable);
    r.cgst = round2(r.cgst + inv.cgst);
    r.sgst = round2(r.sgst + inv.sgst);
    r.igst = round2(r.igst + inv.igst);
    map.set(key, r);
  }
  return [...map.values()].sort(
    (a, b) => a.stateCode.localeCompare(b.stateCode) || a.ratePct - b.ratePct,
  );
}

/** Summarize HSN rows by HSN code (optionally mapping IT_CODE → HSN). */
export function summarizeHsn(
  rows: {
    itCode: string;
    qty: number;
    taxable: number;
    cgst: number;
    sgst: number;
    igst: number;
  }[],
  hsnMap: Record<string, string> = {},
): HsnDetailRow[] {
  const map = new Map<string, HsnDetailRow>();
  for (const r of rows) {
    const hsn = hsnMap[r.itCode] ?? r.itCode;
    const acc = map.get(hsn) ?? { hsn, qty: 0, taxable: 0, cgst: 0, sgst: 0, igst: 0 };
    acc.qty = round2(acc.qty + Number(r.qty ?? 0));
    acc.taxable = round2(acc.taxable + Number(r.taxable ?? 0));
    acc.cgst = round2(acc.cgst + Number(r.cgst ?? 0));
    acc.sgst = round2(acc.sgst + Number(r.sgst ?? 0));
    acc.igst = round2(acc.igst + Number(r.igst ?? 0));
    map.set(hsn, acc);
  }
  return [...map.values()].sort((a, b) => a.hsn.localeCompare(b.hsn));
}

export interface Gstr1 {
  b2b: InvoiceRow[];
  b2cl: InvoiceRow[];
  b2cs: B2csRow[];
  hsn: HsnDetailRow[];
}

/** Pure GSTR-1 assembly from classified invoices + detail rows. */
export function buildGstr1(
  invoices: InvoiceRow[],
  detail: {
    itCode: string;
    qty: number;
    taxable: number;
    cgst: number;
    sgst: number;
    igst: number;
  }[],
  opts: { threshold?: number; hsnMap?: Record<string, string> } = {},
): Gstr1 {
  const threshold = opts.threshold ?? B2CL_THRESHOLD;
  const b2b = invoices.filter((i) => classifyInvoice(i, threshold) === 'B2B');
  const b2cl = invoices.filter((i) => classifyInvoice(i, threshold) === 'B2CL');
  const b2csInv = invoices.filter((i) => classifyInvoice(i, threshold) === 'B2CS');
  return { b2b, b2cl, b2cs: summarizeB2CS(b2csInv), hsn: summarizeHsn(detail, opts.hsnMap) };
}

export interface GstScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

function scopeSql(
  s: GstScope,
  alias: string,
  startIdx: number,
): { sql: string; params: unknown[] } {
  const parts = [`${alias}."CO_CODE"=$${startIdx}`];
  const params: unknown[] = [s.coCode];
  let i = startIdx + 1;
  if (s.lcCode) {
    parts.push(`${alias}."LC_CODE"=$${i++}`);
    params.push(s.lcCode);
  }
  if (s.coYear) {
    parts.push(`${alias}."CO_YEAR"=$${i++}`);
    params.push(s.coYear);
  }
  return { sql: parts.join(' AND '), params };
}

/** Live GSTR-1 datasets for a company scope (Req 18). */
export async function gstr1(
  prisma: any,
  s: GstScope,
  opts: { threshold?: number; hsnMap?: Record<string, string> } = {},
): Promise<Gstr1> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const h = scopeSql(s, 'S', 1);
    const n = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;
    // invoices: SL_DATA joined to AC_MAST for buyer GSTIN/state
    const invRows: any[] = await tx.$queryRawUnsafe(
      `SELECT S."VCH_NO" AS "vchNo", S."AC_CODE" AS "acCode", M."AC_GSTNO" AS gstin, M."AC_STATE" AS state,
              ${n('S."IGST_TAX"')} AS igst, ${n('S."CGST_TAX"')} AS cgst, ${n('S."SGST_TAX"')} AS sgst,
              ${n('S."TOT_AMT"')} AS tot, ${n('S."NET_AMT"')}-${n('S."DISC_AMT"')} AS taxable, ${n('S."TAX_PRC"')} AS rate
       FROM "SL_DATA" S LEFT JOIN "AC_MAST" M ON M."CO_CODE"=S."CO_CODE" AND M."AC_CODE"=S."AC_CODE"
       WHERE ${h.sql}`,
      ...h.params,
    );
    const invoices: InvoiceRow[] = invRows.map((r) => ({
      vchNo: String(r.vchNo),
      acCode: r.acCode,
      gstin: r.gstin ?? null,
      interState: Number(r.igst) > 0,
      invoiceValue: Number(r.tot),
      taxable: round2(Number(r.taxable)),
      cgst: round2(Number(r.cgst)),
      sgst: round2(Number(r.sgst)),
      igst: round2(Number(r.igst)),
      stateCode: r.state ?? null,
      ratePct: Number(r.rate),
    }));

    const d = scopeSql(s, 'D', 1);
    const detRows: any[] = await tx.$queryRawUnsafe(
      `SELECT D."IT_CODE" AS "itCode", sum(${n('D."ITM_PCS"')}) AS qty, sum(${n('D."NET_AMT"')}) AS taxable,
              sum(${n('D."ITM_CGST_AMT"')}) AS cgst, sum(${n('D."ITM_SGST_AMT"')}) AS sgst, sum(${n('D."ITM_IGST_AMT"')}) AS igst
       FROM "SL_DETL" D WHERE ${d.sql} GROUP BY D."IT_CODE"`,
      ...d.params,
    );
    const detail = detRows.map((r) => ({
      itCode: r.itCode ?? '',
      qty: Number(r.qty),
      taxable: Number(r.taxable),
      cgst: Number(r.cgst),
      sgst: Number(r.sgst),
      igst: Number(r.igst),
    }));

    return buildGstr1(invoices, detail, opts);
  });
}
