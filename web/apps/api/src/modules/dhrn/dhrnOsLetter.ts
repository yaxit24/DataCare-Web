import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import {
  resolveSettingsBehaviorTx,
  interestTypeForBook,
  desktopDhrnInterest,
} from '../shared/settingsBehavior.js';
import {
  docShell,
  esc,
  num,
  money,
  rupeesInWords,
  billFooter,
  type DocMeta,
} from '../documents/docChrome.js';

/**
 * Dhrn Os Letter — a per-party pledge OUTSTANDING statement/letter (desktop RP_DHRN_OS "Dhrn Due" +
 * DhrnOsLetter.RPT, opened via CurBookHelp('OS LETTER')). For each still-open pledge (DHRN_ISU_DATA)
 * of the borrower it shows the bill/packet, issue + due dates, pledged items, original principal,
 * principal repaid, outstanding principal, interest rate, accrued (unpaid) interest to an as-of date
 * and the total due. Stateless document: it reads + computes, posts nothing and writes no REPORT_DATA.
 *
 * Outstanding & interest roll-forward (RP_DHRN_OS.cs:1961,1990-2015,2103-2109):
 *   outstandingPrincipal = DHRN_AMT − Σ(DHRN_DATA.DHRN_REC_AMT + UNCHAK_DHRN_REC) through asOf
 *   accrualFrom          = latest DHRN_DATA.TO_DATE through asOf, else issue VCH_DATE
 *   currentInterest      = desktopDhrnInterest(outstandingPrincipal, INT_PRC, accrualFrom..asOf)
 *   unpaidInterest       = currentInterest + Σ INT_AMT − Σ INT_REC_AMT through asOf
 *   totalDue             = outstandingPrincipal + unpaidInterest
 */
export interface DhrnOsLetterScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
  acCode: string;
  asOf?: string; // ISO yyyy-mm-dd cut-off; default today
}

const dt = (v: any): string => (v ? String(v).slice(0, 10) : '');
const r2 = (n: number): number => round(n, 2);

export interface DhrnOsLetterPledge {
  vchNo: string;
  bill: string;
  packet: string;
  issueDate: string;
  dueDate: string;
  items: string;
  principal: number;
  repaid: number;
  outstanding: number;
  intPrc: number;
  interest: number;
  totalDue: number;
}

export async function dhrnOsLetterData(
  prisma: any,
  s: DhrnOsLetterScope,
): Promise<{
  party: any;
  company: any;
  asOf: string;
  pledges: DhrnOsLetterPledge[];
  totals: { principal: number; repaid: number; outstanding: number; interest: number; due: number };
} | null> {
  const asOf =
    s.asOf && /^\d{4}-\d{2}-\d{2}$/.test(s.asOf) ? s.asOf : new Date().toISOString().slice(0, 10);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const party: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      s.coCode,
      s.acCode,
    );
    const co: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`,
      s.coCode,
    );
    // Open pledges for the party, issued on/before the cut-off.
    const issues: any[] = await tx.$queryRawUnsafe(
      `SELECT "CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE"::text vd,"DHRN_BILL","PACKET_NO","DHRN_DUE_DATE"::text dd,
              coalesce("DHRN_AMT",0)::float8 amt,coalesce("DHRN_MONTH",0)::float8 mon,coalesce("INT_PRC",0)::float8 prc,
              "GOLD_DESC","LOAN_TYPE"
         FROM "DHRN_ISU_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4
          AND coalesce("ENTRY_TYPE",'D')='D' AND "VCH_DATE"<=$5::date
        ORDER BY "VCH_DATE","CO_YEAR","CO_BOOK","VCH_NO"`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.acCode,
      asOf,
    );
    if (!party.length && !issues.length) return null;

    const settings = await resolveSettingsBehaviorTx(tx, {
      tenantId: s.tenantId,
      coCode: s.coCode,
    });
    const intSettings = {
      ...settings,
      loanIntType: interestTypeForBook(settings, 'INTREST RECIVED'),
    };

    const pledges: DhrnOsLetterPledge[] = [];
    for (const i of issues) {
      // movement aggregate for this issue (by the ISU_* key), through the cut-off
      const mv: any[] = await tx.$queryRawUnsafe(
        `SELECT coalesce(sum("DHRN_REC_AMT"),0)::float8 rec, coalesce(sum("UNCHAK_DHRN_REC"),0)::float8 unch,
                coalesce(sum("INT_AMT"),0)::float8 ia, coalesce(sum("INT_REC_AMT"),0)::float8 ir,
                max("TO_DATE")::text mxto
           FROM "DHRN_DATA"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "ISU_LC"=$3 AND "ISU_YRCD"=$4 AND "ISU_DBCD"=$5 AND "ISU_NO"=$6
            AND "VCH_DATE"<=$7::date`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        i.CO_YEAR,
        i.CO_BOOK,
        i.VCH_NO,
        asOf,
      );
      const m = mv[0] ?? {};
      const repaid = r2(Number(m.rec ?? 0) + Number(m.unch ?? 0));
      const outstanding = r2(Number(i.amt) - repaid);
      if (!(outstanding > 0)) continue; // only open pledges
      const accrualFrom = m.mxto ? String(m.mxto).slice(0, 10) : dt(i.vd);
      const current = desktopDhrnInterest({
        principal: outstanding,
        annualRatePct: Number(i.prc),
        from: accrualFrom || dt(i.vd),
        to: asOf,
        settings: intSettings,
        loanType: String(i.LOAN_TYPE ?? 'A'),
      });
      const unpaidInterest = r2(current + Number(m.ia ?? 0) - Number(m.ir ?? 0));
      // pledged items: detail IT_NAME/IT_CODE, fallback GOLD_DESC
      const detl: any[] = await tx.$queryRawUnsafe(
        `SELECT coalesce(nullif(btrim("IT_NAME"),''),nullif(btrim("IT_CODE"),'')) nm
           FROM "DHRN_ISU_DETL"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
          ORDER BY "SR_NO"`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        i.CO_YEAR,
        i.CO_BOOK,
        i.VCH_NO,
      );
      const items =
        detl
          .map((d) => String(d.nm ?? '').trim())
          .filter(Boolean)
          .join(', ') || String(i.GOLD_DESC ?? '').trim();
      // due date: stored DHRN_DUE_DATE, else issue date + DHRN_MONTH*30 days
      let dueDate = dt(i.dd);
      if (!dueDate && i.vd) {
        const d = new Date(i.vd);
        d.setDate(d.getDate() + Math.round(Number(i.mon) * 30));
        dueDate = d.toISOString().slice(0, 10);
      }
      pledges.push({
        vchNo: String(i.VCH_NO),
        bill: String(i.DHRN_BILL ?? i.VCH_NO),
        packet: String(i.PACKET_NO ?? ''),
        issueDate: dt(i.vd),
        dueDate,
        items,
        principal: r2(Number(i.amt)),
        repaid,
        outstanding,
        intPrc: Number(i.prc),
        interest: unpaidInterest,
        totalDue: r2(outstanding + unpaidInterest),
      });
    }

    const totals = pledges.reduce(
      (t, p) => ({
        principal: r2(t.principal + p.principal),
        repaid: r2(t.repaid + p.repaid),
        outstanding: r2(t.outstanding + p.outstanding),
        interest: r2(t.interest + p.interest),
        due: r2(t.due + p.totalDue),
      }),
      { principal: 0, repaid: 0, outstanding: 0, interest: 0, due: 0 },
    );
    return { party: party[0] ?? null, company: co[0] ?? null, asOf, pledges, totals };
  });
}

export interface DhrnOsLetterCtx {
  company?: any;
  fallbackName?: string;
}

export function dhrnOsLetterHtml(
  data: NonNullable<Awaited<ReturnType<typeof dhrnOsLetterData>>>,
  ctx: DhrnOsLetterCtx = {},
): string {
  const p = data.party ?? {};
  const rows = data.pledges
    .map(
      (g) =>
        `<tr><td>${esc(g.bill)}</td><td class="c">${esc(g.packet)}</td><td class="c">${esc(g.issueDate)}</td>` +
        `<td class="c">${esc(g.dueDate)}</td><td>${esc(g.items)}</td>` +
        `<td class="r">${money(g.principal)}</td><td class="r">${money(g.repaid)}</td>` +
        `<td class="r">${money(g.outstanding)}</td><td class="r">${g.intPrc ? `${num(g.intPrc)}%` : ''}</td>` +
        `<td class="r">${money(g.interest)}</td><td class="r">${money(g.totalDue)}</td></tr>`,
    )
    .join('');
  const table =
    `<table class="items"><thead><tr><th>Pledge/Bill</th><th>Packet</th><th>Issued</th><th>Due</th>` +
    `<th style="width:22%">Pledged Items</th><th class="r">Principal</th><th class="r">Repaid</th>` +
    `<th class="r">Outstanding</th><th class="r">Rate</th><th class="r">Interest</th><th class="r">Total Due</th></tr></thead>` +
    `<tbody>${rows || '<tr><td colspan="11" class="c">No outstanding pledges</td></tr>'}</tbody>` +
    `<tfoot><tr><td class="c" colspan="5">Total</td><td class="r">${money(data.totals.principal)}</td>` +
    `<td class="r">${money(data.totals.repaid)}</td><td class="r">${money(data.totals.outstanding)}</td>` +
    `<td></td><td class="r">${money(data.totals.interest)}</td><td class="r">${money(data.totals.due)}</td></tr></tfoot></table>`;
  const summary =
    `<div class="lower"><div class="hsn"><div style="border:1px solid #94a3b8;border-radius:4px;padding:6px 8px;font-size:11px">` +
    `We are sorry for any inconvenience caused. Kindly clear the outstanding dues at the earliest to redeem your pledged articles.</div></div>` +
    `<div class="tot"><table><tr class="grand"><td>Total Amount Due</td><td class="r">₹ ${money(data.totals.due)}</td></tr></table></div></div>` +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(data.totals.due))} only.</div>`;
  const meta: DocMeta[] = [
    { k: 'Account', v: String(p.AC_CODE ?? '') },
    { k: 'As on', v: data.asOf },
    { k: 'Open Pledges', v: String(data.pledges.length) },
  ];
  return docShell({
    title: 'Pledge Outstanding Letter',
    company: ctx.company ?? data.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'To',
      name: p.AC_NAME ?? p.AC_CODE,
      addr: [p.AC_ADD1, p.AC_CITY, p.AC_MOBILE && `Mob: ${p.AC_MOBILE}`].filter(Boolean),
    },
    meta,
    body: table + summary,
    footer: billFooter(
      ctx.company ?? data.company,
      ctx.fallbackName,
      'Statement of pledge dues as per our books as on the date above. E.&O.E.',
    ),
  });
}
