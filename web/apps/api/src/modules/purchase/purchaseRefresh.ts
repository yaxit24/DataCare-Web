import { createHash } from 'node:crypto';
import { round } from '@datacare/core';
import { type RefreshCandidate, type RefreshVoucherScope } from '../finance/contraRefresh.js';
import { resolveBookPolicyTx, resolveBookAccountTx } from '../shared/bookPolicy.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { resolveRoundingPolicyTx } from '../shared/roundingPolicyLoader.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { purchaseRojmelOptionsTx } from '../shared/purchaseRojmel.js';
import { hasWebRoundOffLegTx } from '../shared/legacyRoundOff.js';
import { materializeVoucherRowsTx } from '../posting/posting.js';
import { purchasePostInput } from './purchasePosting.js';

type Row = Record<string, any>;
const text = (v: unknown) => String(v ?? '').trim();
const num = (v: unknown) => Number(v ?? 0);
export const PURCHASE_REFRESH_BOOKS = ['PURCHASE', 'TAG PURCHASE', 'CON PUR'] as const;

/** Exact voucher prefix and complete tail, never endsWith(role). Reserved keys are positional. */
export function purchasePostingRole(key: string, prefix: string): string | null {
  const raw = key.trimEnd();
  if (!raw.startsWith(prefix)) return null;
  const tail = raw.slice(prefix.length);
  if (/^(01|03|06|07|16|17|26)$/.test(tail)) return `role:${tail}`;
  if (/^[5-9][0-9]$/.test(tail)) return `position:${Number(tail) - 50}`;
  if (
    tail.length === 12 &&
    /^\s+[1-9]\d*03$/.test(tail) &&
    tail.slice(0, -2) === String(Number(tail.slice(0, -2))).padStart(10, ' ')
  )
    return `item:${Number(tail.slice(0, -2))}`;
  if (
    tail.length === 12 &&
    /^\s+[1-9]\d*21$/.test(tail) &&
    tail === `${Number(tail.trim().slice(0, -2))}21`.padStart(12, ' ')
  )
    return `fine:${Number(tail.trim().slice(0, -2))}`;
  return null;
}

/**
 * Preview only: Purc_Ledr / Purc_Rojmel / Purc_GST read PR_DATA and PR_DETL
 * (unified/src/csharp_nextdm/DataCareNext/Ac_Ledr.cs:377-476, Ac_Rojmel.cs:115-177,
 * Ac_Tax.cs:111-132). Never reopen/save, renumber, resolve sale links or touch stock.
 * Missing historical configuration snapshots limit coverage; refusal is distinct from orphanhood.
 */
export async function derivePurchasePostingsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<RefreshCandidate> {
  const refuse = (reason: string): RefreshCandidate => ({
    ledger: { table: 'AC_DATA', lines: [] },
    unverifiedReason: `voucher ${voucherNo}: ${reason}`,
  });
  const args = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
  const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
  const load = (table: string): Promise<Row[]> =>
    tx.$queryRawUnsafe(
      `SELECT t.*, "VCH_DATE"::text AS "VCH_DATE"${table.startsWith('PR_') ? ', "VCH_TIME"::text AS "VCH_TIME"' : ''} FROM "${table}" t WHERE ${where} ORDER BY ${table === 'ROJ_MEL_DATA' ? '"LEDR_KEY"' : 'row_id'}`,
      ...args,
    );
  const heads = await load('PR_DATA');
  if (heads.length !== 1) return refuse('older shape: expected exactly one PR_DATA header');
  const h = heads[0]!;
  if (!text(h.AC_NAME)) return refuse('older shape: saved party name/fallback is not recoverable');
  const details = (await load('PR_DETL')).sort((a, b) => num(a.SR_NO) - num(b.SR_NO));
  const books: Row[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
    ...args.slice(0, 3),
    scope.coBook,
  );
  if (
    books.length !== 1 ||
    !PURCHASE_REFRESH_BOOKS.includes(text(books[0]?.MAIN_BOOK) as any) ||
    text(books[0]?.BOOK_INOUT) !== 'I'
  )
    return refuse('unsupported or ambiguous purchase book coverage');
  const b = books[0]!;
  if (num(h.TAX_AMT) && text(b.BOOK_TYPE) !== 'T')
    return refuse('unsupported tax-register book coverage: Purc_GST requires BOOK_TYPE T');
  if (!/^\d{5}$/.test(text(voucherNo))) return refuse('older shape: unsupported voucher numbering');
  if (!details.length || !text(h.VCH_DATE) || !text(h.VCH_TIME) || !text(h.AC_CODE))
    return refuse('older shape: missing source identity/date/time/details');
  const identity = ['CO_CODE', 'LC_CODE', 'CO_YEAR', 'CO_BOOK', 'VCH_NO', 'AC_CODE'];
  if (
    details.some(
      (d, i) =>
        num(d.SR_NO) !== i + 1 ||
        identity.some((c) => text(d[c]) !== text(h[c])) ||
        !['G', 'S'].includes(text(d.IT_TYPE)),
    )
  )
    return refuse('older shape: conflicting detail identity, metal or non-contiguous serials');
  const requiredHeader = [
    'NET_AMT',
    'DISC_AMT',
    'TAX_AMT',
    'CGST_TAX',
    'SGST_TAX',
    'IGST_TAX',
    'TOT_AMT',
    'ROF_AMT',
    'TCS_AMT',
    'BILL_OS',
  ];
  const requiredDetail = ['ITM_AMT', 'LBR_AMT', 'OTH_AMT', 'TOT_AMT', 'NET_AMT', 'ITM_FINE'];
  const numericColumns = [
    'COMM_AMT',
    'ITM_OTH_FINE',
    'SILVER_FINE',
    'ITM_PCS',
    'ITM_GWT',
    'ITM_NWT',
    'ITM_TOUCH',
    'ITM_WEST_PRC',
    'ITM_RATE',
    'LBR_RATE',
    'LBR_PRC',
  ];
  if (
    details.some((d) => numericColumns.some((c) => !Number.isFinite(num(d[c])))) ||
    ['HM_AMT', 'HM_TAX_AMT', 'HM_TAX_PRC', 'TDS_AMT', 'TAX_PRC'].some(
      (c) => !Number.isFinite(num(h[c])),
    )
  )
    return refuse('older shape: nonfinite posting facts');
  if (
    requiredHeader.some((c) => h[c] == null || !Number.isFinite(Number(h[c]))) ||
    details.some((d) => requiredDetail.some((c) => d[c] == null || !Number.isFinite(Number(d[c]))))
  )
    return refuse('older shape: missing or nonfinite economic facts');
  const linked = (r: Row) =>
    text(r.SL_BILL_NO) ||
    text(r.SL_BILL_DBCD) ||
    (text(r.SL_BILL_LC) && text(r.SL_BILL_LC) !== scope.lcCode) ||
    (text(r.SL_BILL_YRCD) && text(r.SL_BILL_YRCD) !== scope.coYear);
  if (text(b.MAIN_BOOK) !== 'CON PUR' && [h, ...details].some(linked))
    return refuse('linked-to-sale or partial/stray SL_BILL reference outside CON PUR');
  if (await hasWebRoundOffLegTx(tx, args))
    return refuse('legacy 99 computed round-off; typed origin is not established');
  const ac = await load('AC_DATA'),
    roj = await load('ROJ_MEL_DATA'),
    taxRows = await load('TAX_DATA');
  const prefix = args.slice(1).map(text).join('');
  if (
    [...ac, ...roj, ...taxRows].some(
      (r) => text(r.BOOK_NAME) && text(r.BOOK_NAME) !== text(b.MAIN_BOOK),
    )
  )
    return refuse('configuration drift: posting/source book coverage disagreement');
  if (ac.some((r) => purchasePostingRole(String(r.LEDR_KEY), prefix) === null))
    return refuse('older shape: unsupported ledger numbering');
  if (num(h.ROF_AMT) && !ac.some((r) => text(r.LEDR_KEY) === prefix + '26'))
    return refuse('round-off origin ambiguous: no typed leg 26 (legacy 99 may have been lost)');
  if (
    ['CASH_AMT', 'CHQ_AMT', 'CARD_AMT', 'KASAR_AMT'].some(
      (c) => !Number.isFinite(num(h[c])) || num(h[c]) < 0,
    ) ||
    round(
      num(h.TOT_AMT) -
        num(h.BILL_OS) -
        num(h.CASH_AMT) -
        num(h.CHQ_AMT) -
        num(h.CARD_AMT) -
        num(h.KASAR_AMT),
      2,
    ) !== 0
  )
    return refuse(
      'payment ambiguity: unrecorded UPI or unexplained outstanding residual/negative tender',
    );
  if (
    (num(h.CHQ_AMT) + num(h.CARD_AMT) && !text(h.BANK_AC)) ||
    (num(h.CARD_AMT) && !text(h.CARD_AC))
  )
    return refuse('payment ambiguity: missing bank/card account');
  if (
    round(num(h.CGST_TAX) + num(h.SGST_TAX) + num(h.IGST_TAX), 2) !== round(num(h.TAX_AMT), 2) ||
    (text(h.AC_GST_TYPE) === 'I' ? num(h.CGST_TAX) || num(h.SGST_TAX) : num(h.IGST_TAX))
  )
    return refuse('older shape: inconsistent stored tax splits');
  if (
    details.some(
      (d) =>
        round(num(d.ITM_AMT) + num(d.LBR_AMT) + num(d.OTH_AMT), 2) !== num(d.TOT_AMT) ||
        round(num(d.TOT_AMT) + num(d.COMM_AMT), 2) !== num(d.NET_AMT),
    )
  )
    return refuse('older shape: unsupported detail net/commission mapping');
  const behavior = await resolveSettingsBehaviorTx(tx, scope);
  if (details.some((d) => num(d.LBR_PRC)) || behavior.labourRateGeneration)
    return refuse('older shape: historical day-book labour rate is not recoverable');
  if (
    (num(h.HM_TAX_AMT) && !behavior.purchaseWithHallmarkTax) ||
    (num(h.TDS_AMT) && !behavior.purchaseTdsEnabled) ||
    (num(h.ROF_AMT) && behavior.purchaseTdsEnabled)
  )
    return refuse('configuration drift: hallmark/TDS options');
  const book = await resolveBookPolicyTx(
    tx,
    scope,
    text(b.MAIN_BOOK) === 'CON PUR'
      ? 'CONSIGNMENT PURCHASE'
      : text(b.MAIN_BOOK) === 'TAG PURCHASE'
        ? 'TAG PURCHASE'
        : 'PURCHASE',
  );
  const slot = (n: number) => resolveBookAccountTx(tx, scope, book, n);
  const controlAc = await slot(1);
  const cashAc = num(h.CASH_AMT) ? await slot(2) : controlAc;
  const roundAc = num(h.ROF_AMT) || num(h.KASAR_AMT) ? await slot(3) : controlAc;
  const items: Row[] = await tx.$queryRawUnsafe(
    `SELECT i."IT_CODE",i."IT_NAME",g."PURC_AC" FROM "ITEM_MAST" i LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE" WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"::text=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    details.map((d) => text(d.IT_CODE)),
  );
  const purcAcByItem: Record<string, string> = {},
    itemNameByItem: Record<string, string> = {};
  for (const d of details) {
    const matches = items.filter((i) => text(i.IT_CODE) === text(d.IT_CODE));
    if (matches.length !== 1 || (text(b.ITM_TYPE) === 'A' && !text(matches[0]?.PURC_AC)))
      return refuse('missing/ambiguous item or group purchase account');
    if (text(matches[0]!.PURC_AC)) purcAcByItem[text(d.IT_CODE)] = text(matches[0]!.PURC_AC);
    itemNameByItem[text(d.IT_CODE)] = text(matches[0]!.IT_NAME);
  }
  const taxMasters: Row[] = text(h.TAX_CODE)
    ? await tx.$queryRawUnsafe(
        `SELECT * FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"::text=$3`,
        scope.tenantId,
        scope.coCode,
        text(h.TAX_CODE),
      )
    : [];
  const legacyTax =
    taxMasters.length === 1 &&
    num(taxMasters[0]!.SR_NO) === 1 &&
    num(taxMasters[0]!.TAX_PRC) === num(h.TAX_PRC);
  if (
    taxMasters.filter((r) => num(r.SR_NO) === 0).length > 1 ||
    new Set(taxMasters.map((r) => num(r.SR_NO))).size !== taxMasters.length
  )
    return refuse('configuration drift: duplicate tax parent/components');
  const taxPolicy = await resolveTaxPolicyTx(tx, scope, {
    acCode: text(h.AC_CODE),
    taxPct: num(h.TAX_PRC),
    taxCode: legacyTax ? undefined : text(h.TAX_CODE),
  });
  if (text(taxPolicy.taxCode) !== text(h.TAX_CODE))
    return refuse('configuration drift: tax identity');
  if (
    text(taxPolicy.accountGstType) !== text(h.AC_GST_TYPE) ||
    (num(h.TAX_AMT) && taxPolicy.taxPct !== num(h.TAX_PRC))
  )
    return refuse('configuration drift: supplier GST type or tax rate');
  const parents: Row[] = num(h.TCS_AMT)
    ? await tx.$queryRawUnsafe(
        `SELECT "TAX_AC" FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"::text=$3 AND coalesce("SR_NO",0)=0`,
        scope.tenantId,
        scope.coCode,
        text(h.TCS_CODE),
      )
    : [];
  if (num(h.TCS_AMT) && (parents.length !== 1 || !text(parents[0]?.TAX_AC)))
    return refuse('TCS account missing or duplicate parent configuration');
  const tcsAc = text(parents[0]?.TAX_AC);
  if (
    num(h.TCS_AMT) &&
    !ac.some((r) => text(r.LEDR_KEY) === prefix + '07') &&
    !roj.some((r) => text(r.LEDR_KEY) === prefix + '04')
  )
    return refuse('TCS account evidence missing from ledger and day book');
  const taxAc = taxPolicy.taxAc ?? 'GST-INPUT';
  const rojmelOptions = await purchaseRojmelOptionsTx(tx, scope, book, h, {
    withLabour: behavior.purchaseWithLabour,
    partyAccount: controlAc,
    kasarAccount: roundAc,
    taxAccount: taxAc,
    tcsAccount: tcsAc,
  });
  if (rojmelOptions.uae || rojmelOptions.b2b) return refuse('unsupported UAE/B2B purchase');
  if (
    (num(h.TDS_AMT) && !rojmelOptions.tdsAccount) ||
    (num(h.HM_TAX_AMT) && text(h.HM_TAX_CODE) && !rojmelOptions.hallmarkTaxAccount)
  )
    return refuse('configuration drift: missing TDS/hallmark tax parent account');
  for (const code of [
    num(h.TDS_AMT) ? text(h.TDS_CODE) : '',
    num(h.HM_TAX_AMT) ? text(h.HM_TAX_CODE) : '',
  ].filter(Boolean)) {
    const rows: Row[] = await tx.$queryRawUnsafe(
      `SELECT "TAX_AC" FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"::text=$3 AND coalesce("SR_NO",0)=0`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (rows.length !== 1) return refuse('configuration drift: ambiguous TDS/hallmark tax parent');
  }

  const rounding = await resolveRoundingPolicyTx(tx, scope);
  const lineNet = details.reduce(
    (sum, d) => sum + round(num(d.ITM_AMT) + num(d.LBR_AMT) + num(d.OTH_AMT), 2),
    0,
  );
  if (rounding.roundBillTotal(lineNet) !== num(h.NET_AMT))
    return refuse(
      'configuration drift or older shape: header net differs from stored detail components',
    );
  const bill = rounding.roundBillTotal(
    rounding.roundBillTotal(num(h.NET_AMT) - num(h.DISC_AMT)) +
      num(h.TAX_AMT) +
      num(h.TCS_AMT) +
      num(h.ROF_AMT),
  );
  if (rounding.roundBillTotal(bill + num(h.HM_AMT) + num(h.HM_TAX_AMT)) !== num(h.TOT_AMT))
    return refuse(
      'configuration drift or older shape: stored bill total disagrees with rounding policy',
    );
  const settings = {
    ...book,
    purchaseAc: controlAc,
    controlAc,
    taxAc,
    tcsAc,
    roundAc,
    cashAc,
    kasarAc: roundAc,
    linePathBook: text(b.ITM_TYPE) === 'A',
    withLabour: behavior.purchaseWithLabour,
    labourAc:
      text(b.ITM_TYPE) !== 'A' && !behavior.purchaseWithLabour && num(h.LBR_AMT) + num(h.OTH_AMT)
        ? await slot(4)
        : undefined,
    purcAcByItem,
    itemNameByItem,
    taxPolicy,
    rojmelOptions,
    roundBillTotal: rounding.roundBillTotal,
    roundTaxAmount: rounding.roundTaxAmount,
    billTotalDecimals: rounding.billTotalDecimals,
  };
  let posting = purchasePostInput(h, details, settings);
  let expected = await materializeVoucherRowsTx(tx, scope.tenantId, posting);
  if (num(h.HM_AMT) > 0) {
    const hmDebit = expected.get('AC_DATA')?.find((r) => text(r.AC_CODE) === 'HMCHRG');
    const hmCredit = expected.get('AC_DATA')?.find((r) => text(r.LD_CODE) === 'HMCHRG');
    const debit = ac.find((r) => text(r.LEDR_KEY) === text(hmDebit?.LEDR_KEY));
    const credit = ac.find((r) => text(r.LEDR_KEY) === text(hmCredit?.LEDR_KEY));
    if (
      !debit ||
      !credit ||
      !text(debit.AC_CODE) ||
      text(debit.AC_CODE) !== text(credit.LD_CODE) ||
      text(debit.LD_CODE) !== text(h.AC_CODE) ||
      text(credit.AC_CODE) !== text(h.AC_CODE)
    )
      return refuse('ambiguous hallmark expense account evidence');
    posting = purchasePostInput(h, details, { ...settings, hmChargeAc: text(debit.AC_CODE) });
    expected = await materializeVoucherRowsTx(tx, scope.tenantId, posting);
  }
  const expenseKeys = (rows: Row[]) =>
    rows
      .map((r) => purchasePostingRole(String(r.LEDR_KEY), prefix))
      .filter((r) => r === 'role:03' || r?.startsWith('item:'));
  const oldExpense = expenseKeys(ac),
    newExpense = expenseKeys(expected.get('AC_DATA') ?? []);
  if (oldExpense.length && newExpense.length && oldExpense.some((k) => !newExpense.includes(k)))
    return refuse('configuration drift: item-vs-book expense layout');
  if (num(h.LBR_AMT) + num(h.OTH_AMT)) {
    for (const r of roj) {
      const want = expected.get('ROJ_MEL_DATA')?.find((w) => text(w.LEDR_KEY) === text(r.LEDR_KEY));
      if (
        want &&
        text(want.AC_NAME) !== text(r.AC_NAME) &&
        [text(h.AC_NAME), ''].includes(text(r.AC_NAME))
      )
        return refuse('configuration drift: labour split/name evidence');
    }
  }
  // Role account evidence is conservative: an account mismatch may be drift or tampering, never an
  // instruction to repair using today's account. Exact complete keys also cover positional HM/tender pairs.
  for (const [table, rows] of [
    ['AC_DATA', ac],
    ['ROJ_MEL_DATA', roj],
    ['TAX_DATA', taxRows],
  ] as const) {
    const key = table === 'TAX_DATA' ? 'SR_NO' : 'LEDR_KEY';
    for (const row of rows) {
      const want = expected.get(table)?.find((w) => text(w[key]) === text(row[key]));
      if (!want) continue;
      if (table === 'ROJ_MEL_DATA' && text(row.IT_CODE) && text(want.IT_DESC) !== text(row.IT_DESC))
        return refuse('configuration drift or ambiguous item-name evidence');
      const configColumns =
        table === 'TAX_DATA'
          ? ['TAX_TYPE', 'TAX_PRC']
          : ['AC_CODE', 'LD_CODE', 'BOOK_NAME', 'VCH_TYPE', 'DATA_TYPE'];
      if (configColumns.some((c) => want[c] != null && text(want[c]) !== text(row[c])))
        return refuse(`configuration drift or ambiguous account/layout evidence in ${table}`);
    }
  }
  // A missing historical override cannot be invented. HM and fallback bank/kasar shapes require a
  // complete recognizable ledger; these can be checked, but missing/extra legs are not reconstructed.
  if (num(h.HM_AMT) || num(h.CHQ_AMT) || num(h.CARD_AMT) || num(h.KASAR_AMT)) {
    const expectedAc = expected.get('AC_DATA') ?? [];
    if (
      ac.length !== expectedAc.length ||
      expectedAc.some((w) => !ac.some((r) => text(r.LEDR_KEY) === text(w.LEDR_KEY)))
    )
      return refuse('payment/HM ambiguity: incomplete positional ledger shape');
  }
  return {
    ...posting,
    configurationFingerprint: createHash('sha256')
      .update(
        JSON.stringify(
          {
            book: b,
            behavior,
            rounding,
            items: items.sort((a, b) => text(a.IT_CODE).localeCompare(text(b.IT_CODE))),
            taxPolicy: { ...taxPolicy, components: [...taxPolicy.components.entries()] },
            taxMasters: taxMasters.sort((a, b) => num(a.SR_NO) - num(b.SR_NO)),
            tcsAc,
            settings,
          },
          (_key, value) => (typeof value === 'bigint' ? value.toString() : value),
        ),
      )
      .digest('hex'),
  };
}
