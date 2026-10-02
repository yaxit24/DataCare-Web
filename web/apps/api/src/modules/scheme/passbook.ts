import { withTxBudget } from '../shared/txBudget.js';
import {
  docShell,
  esc,
  num,
  money,
  rupeesInWords,
  billFooter,
  type DocMeta,
} from '../documents/docChrome.js';

/** Scheme (monthly gold-saving) PASSBOOK: AD_MEMB member + AD_MAST scheme + AD_DATA installments.
 *  Mirrors desktop SchmPassBook.rpt — member, scheme, per-installment date/amount/mode running ledger,
 *  installments paid vs plan, total paid, bonus %, maturity estimate. Keyed by scheme+member (not a vch). */
export interface PassbookScope {
  tenantId: string;
  coCode: string;
  schmCode: string;
  membCode: string;
}

/**
 * `TEMP_AD_DATA` — the scheme-passbook report staging table.
 *
 * Desktop TR_MEMB_ENT.cs:5381 clears it by company and 5402 inserts one row per installment before
 * Crystal reads it; `SchmPassBook.spec.json` binds CHQ_NO, CO_BOOK, CO_YEAR, ITM_GWT, ITM_RATE,
 * MEMB_CODE, REC_AMT, SCHM_CODE, SCHM_DATE, VCH_DATE and VCH_NO from it, so the report renders blank
 * unless it is populated. Staged from the member's own AD_DATA installments, the same rows the
 * desktop copies. The clear is tenant-and-company scoped; forced RLS makes cross-tenant impossible.
 */
export const TEMP_AD_DATA_COLUMNS = [
  // GOLD_BAL — the metal side of a scheme balance, shown on a gold-scheme passbook.
  'GOLD_BAL',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'VCH_DATE',
  'SCHM_DATE',
  'SCHM_CODE',
  'MEMB_CODE',
  'REC_AC',
  'ITM_GWT',
  'ITM_RATE',
  'REC_AMT',
  'BAL_AMT',
  'CHQ_NO',
] as const;

export async function stageSchemePassbookRowsTx(
  tx: any,
  tenantId: string,
  s: PassbookScope,
): Promise<number> {
  await tx.$executeRawUnsafe(
    `DELETE FROM "TEMP_AD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    tenantId,
    s.coCode,
  );
  // AD_DATA carries the installment. The desktop staging columns REC_AMT/BAL_AMT do not exist on
  // AD_DATA (verified against the restored schema): the installment amount is MEMB_AMT and the
  // running total is TOT_AMT, so those are copied. Nothing is recomputed here.
  return (await tx.$executeRawUnsafe(
    `INSERT INTO "TEMP_AD_DATA"(
       tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","SCHM_DATE",
       "SCHM_CODE","MEMB_CODE","REC_AC","ITM_GWT","ITM_RATE","REC_AMT","BAL_AMT","CHQ_NO")
     SELECT $1::text,a."CO_CODE",a."LC_CODE",a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."SR_NO",a."VCH_DATE",
            a."VCH_DATE",a."SCHM_CODE",a."MEMB_CODE",a."REC_AC",a."ITM_GWT",a."ITM_RATE",
            a."MEMB_AMT",a."TOT_AMT",a."CHQ_NO"
       FROM "AD_DATA" a
      WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."SCHM_CODE"=$3 AND a."MEMB_CODE"=$4`,
    tenantId,
    s.coCode,
    s.schmCode,
    s.membCode,
  )) as number;
}

export async function schemePassbookData(
  prisma: any,
  s: PassbookScope,
): Promise<{ member: any; scheme: any; installments: any[]; company: any } | null> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const m: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AD_MEMB" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 AND "MEMB_CODE"=$3 LIMIT 1`,
      s.coCode,
      s.schmCode,
      s.membCode,
    );
    if (!m.length) return null;
    const scheme: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AD_MAST" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 LIMIT 1`,
      s.coCode,
      s.schmCode,
    );
    const installments: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AD_DATA" WHERE "CO_CODE"=$1 AND "SCHM_CODE"=$2 AND "MEMB_CODE"=$3 ORDER BY "VCH_DATE", "SR_NO"`,
      s.coCode,
      s.schmCode,
      s.membCode,
    );
    await stageSchemePassbookRowsTx(tx, s.tenantId, s);
    const co: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`,
      s.coCode,
    );
    return { member: m[0], scheme: scheme[0] ?? null, installments, company: co[0] ?? null };
  });
}

export interface PassbookCtx {
  company?: any;
  copy?: string;
  fallbackName?: string;
}
const dt = (v: any): string => (v ? String(v).slice(0, 10) : '');

export function schemePassbookHtml(
  member: any,
  scheme: any,
  installments: any[],
  ctx: PassbookCtx = {},
): string {
  const mb = member ?? {};
  const sc = scheme ?? {};
  const instAmt = num(mb.MEMB_AMT) || num(sc.SCHM_AMT);
  const months = num(sc.SCHM_MONTH);

  let running = 0;
  const rows = installments
    .map((r, i) => {
      const amt = num(r.MEMB_AMT) || num(r.TOT_AMT);
      running += amt;
      const mode =
        num(r.WITH_UPI) > 0 || r.UPI_NAME
          ? 'UPI'
          : r.CHQ_NO
            ? `Cheque ${r.CHQ_NO}`
            : r.REC_AC
              ? 'Bank'
              : 'Cash';
      return (
        `<tr><td class="c">${i + 1}</td><td class="c">${esc(dt(r.VCH_DATE))}</td><td class="c">${esc(r.MONTH_CODE ?? '')}</td>` +
        `<td class="r">${money(amt)}</td><td class="c">${esc(mode)}</td><td class="r">${money(running)}</td></tr>`
      );
    })
    .join('');
  const totalPaid = running;
  const paidCount = installments.length;
  const bonusPrc = num(sc.BONUS_PRC);
  const bonus = bonusPrc > 0 ? (totalPaid * bonusPrc) / 100 : 0;

  const table =
    `<table class="items"><thead><tr><th>#</th><th>Date</th><th>Month</th><th class="r">Amount</th><th>Mode</th><th class="r">Running Total</th></tr></thead>` +
    `<tbody>${rows || '<tr><td colspan="6" class="c">No installments yet</td></tr>'}</tbody>` +
    `<tfoot><tr><td class="c" colspan="3">Total (${paidCount} installments)</td><td class="r">${money(totalPaid)}</td><td></td><td class="r">${money(totalPaid)}</td></tr></tfoot></table>`;

  const t: string[] = [
    `<tr><td>Installment / month</td><td class="r">${money(instAmt)}</td></tr>`,
    `<tr><td>Installments Paid</td><td class="r">${paidCount}${months ? ` / ${months}` : ''}</td></tr>`,
    `<tr class="sub"><td>Total Paid</td><td class="r">${money(totalPaid)}</td></tr>`,
  ];
  if (bonusPrc > 0)
    t.push(`<tr><td>Bonus (${bonusPrc}%)</td><td class="r">${money(bonus)}</td></tr>`);
  t.push(
    `<tr class="grand"><td>Maturity Value</td><td class="r">₹ ${money(totalPaid + bonus)}</td></tr>`,
  );
  const infoBox =
    `<div class="hsn"><div style="border:1px solid #94a3b8;border-radius:4px;padding:6px 8px;font-size:11px">` +
    `<b>Scheme:</b> ${esc(sc.SCHM_NAME ?? mb.SCHM_CODE ?? '')}${months ? ` (${months} months)` : ''}` +
    `${mb.JOIN_DATE ? `<br/><b>Joined:</b> ${esc(dt(mb.JOIN_DATE))}` : ''}${mb.EXP_DATE ? ` &nbsp; <b>Maturity:</b> ${esc(dt(mb.EXP_DATE))}` : ''}` +
    `${mb.NOMINEE_NAME ? `<br/><b>Nominee:</b> ${esc(mb.NOMINEE_NAME)}` : ''}</div></div>`;
  const lower =
    `<div class="lower">${infoBox}<div class="tot"><table>${t.join('')}</table></div></div>` +
    `<div class="words"><b>Total paid in words:</b> ${esc(rupeesInWords(totalPaid))} only.</div>`;

  const meta: DocMeta[] = [
    { k: 'Member Code', v: String(mb.MEMB_CODE ?? '') },
    { k: 'Scheme Code', v: String(mb.SCHM_CODE ?? '') },
    { k: 'Installment', v: money(instAmt) },
  ];
  return docShell({
    title: 'Scheme Passbook',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Member',
      name: mb.MEMB_NAME ?? mb.MEMB_CODE,
      addr: [mb.AC_ADD1, mb.AC_CITY, mb.AC_MOBILE && `Mob: ${mb.AC_MOBILE}`].filter(Boolean),
    },
    meta,
    body: table + lower,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Passbook of monthly scheme contributions. Bonus/maturity as per scheme rules. E.&O.E.',
    ),
  });
}
