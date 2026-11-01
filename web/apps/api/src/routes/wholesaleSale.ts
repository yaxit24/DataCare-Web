import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { round } from '@datacare/core';
import { formatVoucherNo, type VoucherScope } from '../modules/vouchers/numbering.js';
import { resolvePrintScope, sendVoucherDocument } from '../modules/documents/voucherPrint.js';
import { getWholesaleSale } from '../modules/sales/rateCut.js';
import {
  wholesaleSaleBillHtml,
  type WholesaleBalances,
  type WholesaleBillBand,
} from '../modules/sales/wholesaleSaleBill.js';
import { withTxBudget } from '../modules/shared/txBudget.js';

/**
 * Wh Sales print (desktop BtnPrint_Click, TR_WH_SALE.cs:13654-13800): the print right, then WhSalesBill for a WH SALES
 * book. Kept out of `txn.ts`, whose size ceiling only tightens.
 */
export interface WholesaleSaleRouteHelpers {
  prisma: any;
  auth: any;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  readScope: (req: FastifyRequest) => VoucherScope;
  standardDocumentCopy: (raw: unknown, reply: FastifyReply) => string | null | undefined;
}

const BAND_COLUMNS = [
  'FINE_RATE',
  'PR_FINE',
  'SL_FINE',
  'DR_FINE',
  'CR_FINE',
  'PR_NET_AMT',
  'SL_NET_AMT',
  'PR_CASH_AMT',
  'SL_CASH_AMT',
  'PR_CARD_AMT',
  'SL_CARD_AMT',
  'PR_CHQ_AMT',
  'SL_CHQ_AMT',
  'PR_KASAR_AMT',
  'SL_KASAR_AMT',
  'PR_BILL_OS',
  'SL_BILL_OS',
] as const;

/** Money (Dr − Cr), gold and silver fine of a party, over the whole ledger or over one voucher's legs. */
const BALANCE_SQL = `SELECT coalesce(sum(coalesce("DR_AMT",0) - coalesce("CR_AMT",0)),0)::float8 AS amount,
    coalesce(sum(CASE WHEN "IT_TYPE"='G' THEN (CASE WHEN "SIGN"='-' THEN -1 ELSE 1 END)*coalesce("FINE_WT",0) ELSE 0 END),0)::float8 AS gold,
    coalesce(sum(CASE WHEN "IT_TYPE"='S' THEN (CASE WHEN "SIGN"='-' THEN -1 ELSE 1 END)*coalesce("FINE_WT",0) ELSE 0 END),0)::float8 AS silver
  FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3`;

export function registerWholesaleSaleRoutes(
  app: FastifyInstance,
  helpers: WholesaleSaleRouteHelpers,
): void {
  const { prisma, auth, guard, readScope, standardDocumentCopy } = helpers;
  app.get('/wholesale-sales/:vchNo/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = req.query as any;
    const copy = standardDocumentCopy(q.copy, reply);
    if (copy === null) return reply;
    let voucherNo: string;
    try {
      voucherNo = formatVoucherNo((req.params as any).vchNo);
    } catch (error) {
      return reply
        .code(400)
        .send({ error: 'invalid-voucher-number', message: (error as Error).message });
    }
    const scope = resolvePrintScope(reply, readScope(req), voucherNo);
    if (!scope) return reply;
    let voucher: any;
    try {
      // getWholesaleSale refuses a book that is not WH SALES (assertRateCutBookGuard).
      voucher = await getWholesaleSale(prisma, scope, voucherNo);
    } catch (error) {
      if (error instanceof Error && /ValidationError$/.test(error.name))
        return reply.code(/not found/.test(error.message) ? 404 : 400).send({
          error: error.name,
          message: error.message,
        });
      throw error;
    }
    const context = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
      const [band] = (await tx.$queryRawUnsafe(
        `SELECT ${BAND_COLUMNS.map((c) => `coalesce("${c}",0)::float8 AS "${c}"`).join(',')}
           FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      )) as WholesaleBillBand[];
      const [company] = await tx.$queryRawUnsafe(
        `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
      );
      const [party] = await tx.$queryRawUnsafe(
        `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
          ORDER BY ("LC_CODE"=$4) DESC,row_id LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        String(voucher.acCode ?? ''),
        scope.lcCode,
      );
      // @OpAmt / @ClAmt and the gold and silver lines: the party's ledger without and with this voucher's legs.
      const [closing] = await tx.$queryRawUnsafe(
        BALANCE_SQL,
        scope.tenantId,
        scope.coCode,
        String(voucher.acCode ?? ''),
      );
      const [own] = await tx.$queryRawUnsafe(
        `${BALANCE_SQL} AND "LC_CODE"=$4 AND "CO_YEAR"=$5 AND "CO_BOOK"=$6 AND "VCH_NO"=$7`,
        scope.tenantId,
        scope.coCode,
        String(voucher.acCode ?? ''),
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      const r2 = (x: number) => round(x, 2);
      const r3 = (x: number) => round(x, 3);
      const balances: WholesaleBalances = {
        closing: { amount: r2(closing.amount), gold: r3(closing.gold), silver: r3(closing.silver) },
        opening: {
          amount: r2(closing.amount - own.amount),
          gold: r3(closing.gold - own.gold),
          silver: r3(closing.silver - own.silver),
        },
      };
      return { band, company, party, balances };
    });
    if (!context.band)
      return reply
        .code(404)
        .send({ error: 'wholesale-sale-not-found', message: `voucher not found: ${voucherNo}` });
    return sendVoucherDocument(
      reply,
      wholesaleSaleBillHtml(voucher, context.band, {
        company: context.company,
        party: context.party,
        copy: copy ?? undefined,
        balances: context.balances,
      }),
      { format: q.format, filename: `wholesale-sale-${voucherNo}` },
    );
  });
}
