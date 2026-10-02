import { withTxBudget } from '../shared/txBudget.js';

/**
 * Auto Item (desktop MS_AUTO_ITEM): bulk-create ITEM_MAST rows for a group × a set of products.
 * The item code is auto-derived as GR_CODE + PR_CODE (IT_CODE is varchar(5) = GR_CODE(3)+PR_CODE(2))
 * and the name as "<group> <product>". Existing codes are skipped (idempotent). Additive: writes only
 * ITEM_MAST (the real item master) — no MS_AUTO_ITEM staging table exists in this schema.
 */
export interface AutoItemProduct {
  prCode: string;
  prName?: string;
  include?: boolean;
}
export interface AutoItemInput {
  scope: { tenantId: string; coCode: string };
  grCode: string;
  grName?: string;
  itType?: string; // 'G' gold / 'S' silver (default 'G')
  hsnCode?: string;
  products: AutoItemProduct[];
}

export class AutoItemError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'AutoItemValidationError';
  }
}

export async function bulkAutoItem(
  prisma: any,
  input: AutoItemInput,
): Promise<{ created: number; skipped: number; codes: string[] }> {
  const grCode = String(input.grCode ?? '').trim();
  if (!grCode) throw new AutoItemError('group code is required');
  const products = (input.products ?? []).filter(
    (p) => p && p.include !== false && String(p.prCode ?? '').trim(),
  );
  if (!products.length) throw new AutoItemError('select at least one product');
  const { tenantId, coCode } = input.scope;
  return withTxBudget(prisma, tenantId, 'heavy', async (tx: any) => {
    let created = 0;
    let skipped = 0;
    const codes: string[] = [];
    for (const p of products) {
      const prCode = String(p.prCode).trim();
      const code = `${grCode}${prCode}`.replace(/\s+/g, '').slice(0, 5);
      const ex: Array<{ n: number }> = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "ITEM_MAST" WHERE "CO_CODE"=$1 AND "IT_CODE"=$2`,
        coCode,
        code,
      );
      if (ex[0] && ex[0].n > 0) {
        skipped += 1;
        continue;
      }
      const name = `${input.grName ?? grCode} ${p.prName ?? prCode}`.trim().slice(0, 50);
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","GR_CODE","PR_CODE","IT_TYPE","HSN_CODE") VALUES ($1,$2,$3,$4,$5,$6,$7,$8)`,
        tenantId,
        coCode,
        code,
        name,
        grCode,
        prCode,
        input.itType ?? 'G',
        input.hsnCode ?? null,
      );
      created += 1;
      codes.push(code);
    }
    return { created, skipped, codes };
  });
}
