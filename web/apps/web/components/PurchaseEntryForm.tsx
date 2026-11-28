'use client';

import type { Dispatch, KeyboardEvent, SetStateAction } from 'react';
import { ExtendedBodyCells, ExtendedHeaderCells, GridModeToggle } from './ExtendedGrid';
import { useRoundingPolicy } from './BusinessScope';
import { LookupPicker } from './LookupPicker';
import { companyFlag, companySetting, useCompanySettingsState } from '../lib/companySettings';
import {
  billTotals,
  roundHalfEven,
  fineFor,
  normalizePurchaseExplicitFine,
  purchaseAmountType,
  purchaseLineAmounts,
} from '@datacare/core';
import { carryUnmanaged } from '../lib/purchaseCarry';

/**
 * The Purchase entry grid (TR_PURC mSG_PR) and its totals, shared by the Purchase screen and the Sales screen's linked
 * old-gold purchase (owner decision 2B: a tax-invoice sale's Old Gold / Silver row opens TR_PURC on the URD book,
 * TR_SALE.cs:18756-18842). Both compute a line and the bill with the same arithmetic the purchase writer posts.
 */
export interface PurchaseLine {
  itCode: string;
  tagNo: string;
  vchSrno?: number;
  metal?: 'G' | 'S';
  labourType?: 'per_gram' | 'per_piece' | 'percentage' | 'fixed';
  labourRate?: number;
  labourFixed?: number;
  labourAmount: string;
  otherFineWt?: number;
  silverFineWt?: number;
  otherAmount: string;
  huid?: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  // Desktop purchase-grid columns the API accepts (TR_PURC mSG_PR); without controls the
  // operator cannot enter them.
  tblCode: string;
  designNo: string;
  itDesc: string;
  lotNo: string;
  itmLot: string;
  withStock: string;
  bagWt: string;
  lessWt: string;
  lossWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  fineWt: string;
  labourPct: string;
  lessTouch: string;
  lesTouch: string;
  kunFine: string;
  convRate: string;
  convPct: string;
  otherRate: string;
  mrp: string;
  metalAmount: string;
  commissionPct: string;
  commissionAmount: string;
  fineCutPcs: string;
  fineCutGrossWt: string;
  fineCutNetWt: string;
  fineCutFine: string;
  prCode: string;
  rateType: string;
  urdRateType: string;
  /** Loaded persisted calculations remain authoritative until a derivation input is edited. */
  loadedFineWt?: boolean;
  loadedMetalAmount?: boolean;
  loadedLabourAmount?: boolean;
  /** WP-28: the stored line this row was reopened from; its unshown values go back on save. */
  source?: Record<string, unknown>;
}
export const blankPurchaseLine = (metal: 'G' | 'S' = 'G'): PurchaseLine => ({
  itCode: '', // desktop grids start empty; a demo default posts to the wrong item
  tagNo: '',
  metal,
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  labourAmount: '',
  otherAmount: '',
  tblCode: '',
  designNo: '',
  itDesc: '',
  lotNo: '',
  itmLot: '',
  withStock: '',
  bagWt: '',
  lessWt: '',
  lossWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  fineWt: '',
  labourPct: '',
  lessTouch: '',
  lesTouch: '',
  kunFine: '',
  convRate: '',
  convPct: '',
  otherRate: '',
  mrp: '',
  metalAmount: '',
  commissionPct: '',
  commissionAmount: '',
  fineCutPcs: '',
  fineCutGrossWt: '',
  fineCutNetWt: '',
  fineCutFine: '',
  prCode: '',
  rateType: '',
  urdRateType: '',
});
export const purchaseExtendedLineFields: Array<[keyof PurchaseLine, string]> = [
  ['huid', 'HuId'], // TR_PURC.cs:8741, tag grid column 8
  ['tblCode', 'Counter'],
  ['designNo', 'Design'],
  ['itDesc', 'Item Desc'],
  ['lotNo', 'Lot No'],
  ['itmLot', 'Item Lot'],
  ['withStock', 'With Stock'],
  ['bagWt', 'Bag Wt'],
  ['lessWt', 'Less Wt'],
  ['lossWt', 'Loss Wt'],
  ['ghtPct', 'Ghat %'],
  ['ghtWt', 'Ghat Wt'],
  ['westPct', 'Wastage %'],
  ['fineWt', 'Fine Wt'],
  ['labourPct', 'Labour %'],
  ['lessTouch', 'Less Touch'],
  ['lesTouch', 'Old-gold Less Touch'],
  ['kunFine', 'Kun Fine'],
  ['convRate', 'Conv Rate'],
  ['convPct', 'Conv %'],
  ['otherRate', 'Other Rate'],
  ['mrp', 'MRP'],
  ['metalAmount', 'Metal Amt'],
  ['labourAmount', 'Labour Amt'],
  ['otherAmount', 'Other Amt'],
  ['commissionPct', 'Comm %'],
  ['commissionAmount', 'Comm Amt'],
  ['fineCutPcs', 'Fine-cut Pcs'],
  ['fineCutGrossWt', 'Fine-cut Gross'],
  ['fineCutNetWt', 'Fine-cut Net'],
  ['fineCutFine', 'Fine-cut Fine'],
  ['prCode', 'PR Code'],
  ['rateType', 'Rate Type'],
  ['urdRateType', 'URD Rate Type'],
];
const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const editableString = (v: unknown) => (v == null ? '' : String(v));
const optionalNumber = (v: unknown): number | undefined =>
  v == null || String(v).trim() === '' ? undefined : Number(v);

const metalDerivationInputs: Array<keyof PurchaseLine> = [
  'pcs',
  'grossWt',
  'netWt',
  'ghtWt',
  'touch',
  'westPct',
  'fineWt',
  'lesTouch',
  'kunFine',
  'rate',
  'rateType',
  'urdRateType',
];

function loadedLabourDependsOn(
  line: PurchaseLine,
  field: keyof PurchaseLine,
  labourWithGhat: boolean,
): boolean {
  const mode = line.making ? 'per_gram' : line.labourType;
  switch (mode) {
    case 'per_gram':
      return (
        field === 'netWt' ||
        (labourWithGhat && field === 'ghtWt') ||
        field === 'making' ||
        (!line.making && field === 'labourRate') ||
        field === 'labourType'
      );
    case 'per_piece':
      return (
        field === 'pcs' || field === 'labourRate' || field === 'making' || field === 'labourType'
      );
    case 'percentage':
      return (
        field === 'labourPct' ||
        field === 'labourType' ||
        field === 'metalAmount' ||
        metalDerivationInputs.includes(field)
      );
    case 'fixed':
      return field === 'labourFixed' || field === 'labourType';
    default:
      // Persisted G/K or ambiguous legacy/web modes cannot be recovered safely. Keep their loaded
      // labour amount authoritative instead of clearing it and recomputing under a guessed mode.
      return false;
  }
}

/** One typed cell: a derivation input clears the loaded figure it feeds, so it is recomputed. */
function editPurchaseLine(
  line: PurchaseLine,
  k: keyof PurchaseLine,
  v: string,
  labourWithGhat: boolean,
): PurchaseLine {
  const next = { ...line, [k]: v };
  const fineInputs: Array<keyof PurchaseLine> = [
    'netWt',
    'ghtWt',
    'touch',
    'westPct',
    'lesTouch',
    'kunFine',
  ];
  if (k === 'fineWt') next.loadedFineWt = false;
  else if (line.loadedFineWt && fineInputs.includes(k)) {
    next.fineWt = '';
    next.loadedFineWt = false;
  }
  if (k === 'metalAmount') next.loadedMetalAmount = false;
  else if (line.loadedMetalAmount && metalDerivationInputs.includes(k)) {
    next.metalAmount = '';
    next.loadedMetalAmount = false;
  }
  if (k === 'labourAmount') next.loadedLabourAmount = false;
  else if (line.loadedLabourAmount && loadedLabourDependsOn(line, k, labourWithGhat)) {
    next.labourAmount = '';
    next.loadedLabourAmount = false;
  }
  return next;
}

/** A stored purchase line (GET /purchases/:vchNo `lines[]`) as a grid row. */
export function purchaseLineFromView(line: any): PurchaseLine {
  return {
    ...blankPurchaseLine(),
    itCode: String(line.itCode ?? ''),
    tagNo: String(line.tagNo ?? ''),
    vchSrno: Number(line.vchSrno ?? 0) || undefined,
    metal: line.metal === 'S' ? 'S' : 'G',
    pcs: str(line.pcs),
    grossWt: str(line.grossWt),
    netWt: str(line.netWt),
    touch: str(line.touch),
    ghtWt: str(line.ghtWt),
    westPct: str(line.westPct),
    rate: str(line.rate),
    making: line.labourType === 'per_gram' ? editableString(line.labourRate) : '',
    labourType: line.labourType,
    labourPct: editableString(line.labourPct),
    labourRate: line.labourRate == null ? undefined : Number(line.labourRate),
    labourFixed: line.labourFixed == null ? undefined : Number(line.labourFixed),
    otherFineWt: Number(line.otherFineWt ?? 0) || undefined,
    silverFineWt: Number(line.silverFineWt ?? 0) || undefined,
    fineWt: String(line.fineWt ?? ''),
    metalAmount: String(line.metalAmount ?? ''),
    labourAmount: String(line.labourAmount ?? ''),
    loadedFineWt: true,
    loadedMetalAmount: true,
    loadedLabourAmount: true,
    otherAmount: str(line.otherAmount),
    rateType: String(line.rateType ?? ''),
    urdRateType: String(line.urdRateType ?? ''),
    huid: String(line.huid ?? '') || undefined,
    // WP-28 (G1): the stored grid columns, so an unchanged save writes them back.
    tblCode: editableString(line.tblCode),
    designNo: editableString(line.designNo),
    itDesc: editableString(line.itDesc),
    lotNo: editableString(line.lotNo),
    itmLot: editableString(line.itmLot),
    withStock: editableString(line.withStock),
    bagWt: str(line.bagWt),
    lessWt: str(line.lessWt),
    lossWt: str(line.lossWt),
    ghtPct: str(line.ghtPct),
    lessTouch: str(line.lessTouch),
    convRate: str(line.convRate),
    convPct: str(line.convPct),
    otherRate: str(line.otherRate),
    mrp: str(line.mrp),
    commissionPct: str(line.commissionPct),
    commissionAmount: str(line.commissionAmount),
    fineCutPcs: str(line.fineCutPcs),
    fineCutGrossWt: str(line.fineCutGrossWt),
    fineCutNetWt: str(line.fineCutNetWt),
    fineCutFine: str(line.fineCutFine),
    prCode: editableString(line.prCode),
    source: line,
  };
}

/**
 * The request lines of the grid. The ORIGINAL index is carried through the filter on purpose: stones are keyed by the
 * line the operator entered them against, and empty lines are dropped, so a filtered position would attach a stone
 * block to the wrong item.
 */
export function purchaseLinesBody(lines: PurchaseLine[], stonesFor: (index: number) => unknown) {
  return lines
    .map((l, sourceIndex) => ({ l, sourceIndex }))
    .filter(({ l }) => l.itCode && (l.netWt || l.rate))
    .map(({ l, sourceIndex }) =>
      carryUnmanaged(l.source, {
        stones: stonesFor(sourceIndex),
        itCode: l.itCode,
        tagNo: l.tagNo || undefined,
        vchSrno: l.vchSrno,
        metal: l.metal,
        pcs: n(l.pcs),
        grossWt: n(l.grossWt),
        netWt: n(l.netWt),
        touch: n(l.touch),
        rate: n(l.rate),
        otherFineWt: l.otherFineWt,
        silverFineWt: l.silverFineWt,
        otherAmount: optionalNumber(l.otherAmount),
        tblCode: l.tblCode || undefined,
        designNo: l.designNo || undefined,
        itDesc: l.itDesc || undefined,
        lotNo: l.lotNo || undefined,
        itmLot: l.itmLot || undefined,
        withStock: l.withStock || undefined,
        bagWt: n(l.bagWt) || undefined,
        lessWt: n(l.lessWt) || undefined,
        lossWt: n(l.lossWt) || undefined,
        ghtPct: n(l.ghtPct) || undefined,
        ghtWt: n(l.ghtWt) || undefined,
        westPct: n(l.westPct) || undefined,
        fineWt: optionalNumber(l.fineWt),
        labourPct: optionalNumber(l.labourPct),
        labourAmount: optionalNumber(l.labourAmount),
        lessTouch: n(l.lessTouch) || undefined,
        lesTouch: optionalNumber(l.lesTouch),
        kunFine: optionalNumber(l.kunFine),
        convRate: n(l.convRate) || undefined,
        convPct: n(l.convPct) || undefined,
        otherRate: n(l.otherRate) || undefined,
        mrp: n(l.mrp) || undefined,
        metalAmount: optionalNumber(l.metalAmount),
        commissionPct: n(l.commissionPct) || undefined,
        commissionAmount: n(l.commissionAmount) || undefined,
        fineCutPcs: n(l.fineCutPcs) || undefined,
        fineCutGrossWt: n(l.fineCutGrossWt) || undefined,
        fineCutNetWt: n(l.fineCutNetWt) || undefined,
        fineCutFine: n(l.fineCutFine) || undefined,
        prCode: l.prCode || undefined,
        rateType: l.rateType || undefined,
        urdRateType: l.urdRateType || undefined,

        huid: l.huid,
        ...(l.making
          ? { labourType: 'per_gram' as const, labourRate: n(l.making) }
          : l.labourType
            ? {
                labourType: l.labourType,
                labourRate: l.labourRate,
                labourFixed: l.labourFixed,
              }
            : {}),
      }),
    );
}

/**
 * The company settings the purchase arithmetic depends on, the line calculation and the bill preview: the same
 * figures the purchase writer posts (G102), so the shown total equals the saved total.
 */
export function usePurchasePricing() {
  const roundingPolicy = useRoundingPolicy();
  /**
   * P4: `ITM_FINE_LOCK` — the desktop sets the fine cell's entry box read-only when this is on
   * (TR_PURC.cs:7145-7148, `TEXT_PR.ReadOnly = true`), so the computed fine cannot be overtyped.
   * There is nothing for the server to enforce: the value still posts, it just may not be retyped.
   * Blank default 'N' per MS_OPNCOMP.cs.
   */
  const settingsState = useCompanySettingsState();
  const companySettings = settingsState.values;
  const settingsReady = settingsState.status === 'ready';
  const amountType = purchaseAmountType(companySetting(companySettings, 'PR_AMT_TYPE'));
  const fineLocked = settingsReady && companyFlag(companySettings, 'ITM_FINE_LOCK', 'N');
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  // Row 4 is the round-off the operator types unless PR_TDS_TAX makes it TDS (TR_PURC.cs:15085); nothing else rounds.
  const tdsOn = companyFlag(companySettings, 'PR_TDS_TAX', 'N');

  const calc = (l: PurchaseLine) => {
    const enteredFine = normalizePurchaseExplicitFine(optionalNumber(l.fineWt));
    const lesTouch = optionalNumber(l.lesTouch);
    const kunFine = optionalNumber(l.kunFine);
    const fine =
      enteredFine ??
      fineFor(lesTouch != null || kunFine != null ? 'purchaseOldGold' : 'purchaseItem', {
        netWt: n(l.netWt),
        touch: n(l.touch),
        ghtWt: n(l.ghtWt),
        westPct: n(l.westPct),
        lesTouch,
        kunFine,
      });
    const labourType = l.making ? ('per_gram' as const) : l.labourType;
    const amounts = purchaseLineAmounts(
      {
        pieces: n(l.pcs),
        grossWt: n(l.grossWt),
        netWt: n(l.netWt),
        ghatWt: n(l.ghtWt),
        fineWt: fine,
        rate: n(l.rate),
        rateType: l.rateType,
        urdRateType: l.urdRateType,
        itemAmount: optionalNumber(l.metalAmount),
        labourType,
        labourRate: l.making ? n(l.making) : l.labourRate,
        labourPct: optionalNumber(l.labourPct),
        labourFixed: l.labourFixed,
        labourAmount: optionalNumber(l.labourAmount),
        otherAmount: optionalNumber(l.otherAmount),
      },
      amountType,
      roundingPolicy,
      labourWithGhat,
    );
    return { fine, metal: amounts.item, mk: amounts.labour, net: amounts.net };
  };

  /** Row 0..4 of the purchase totals: taxable, tax, TCS, round-off and the bill total (TR_PURC.cs:15072-15085). */
  const bill = (p: {
    lines: PurchaseLine[];
    discountAmount: string;
    taxRatePct: string;
    interState: boolean;
    tcsPct?: string;
    roundOff?: string;
  }) => {
    const lineNet = p.lines.reduce((s, l) => s + calc(l).net, 0);
    const previewTotals = billTotals(
      {
        lineNetTotal: lineNet,
        discountAmount: n(p.discountAmount),
        taxRatePct: n(p.taxRatePct),
        interState: p.interState,
      },
      roundingPolicy,
    );
    const taxable = previewTotals.taxable;
    const taxPrev = previewTotals.tax;
    // TR_PURC.cs:15072: whole-rupee TCS on net before discount plus tax.
    const tcsAmount = roundHalfEven(((previewTotals.net + taxPrev) * n(p.tcsPct ?? '')) / 100, 0);
    const rofAmt = tdsOn ? 0 : n(p.roundOff ?? '');
    const totalPrev = roundingPolicy.roundBillTotal(taxable + taxPrev + tcsAmount + rofAmt);
    return { taxable, taxPrev, tcsAmount, rofAmt, totalPrev };
  };

  /** setLine for a grid held in `setLines`. */
  const lineSetter =
    (setLines: Dispatch<SetStateAction<PurchaseLine[]>>) =>
    (i: number, k: keyof PurchaseLine, v: string) =>
      setLines((ls) =>
        ls.map((line, j) => (j === i ? editPurchaseLine(line, k, v, labourWithGhat) : line)),
      );

  return {
    settingsState,
    companySettings,
    settingsReady,
    fineLocked,
    labourWithGhat,
    tdsOn,
    calc,
    bill,
    lineSetter,
  };
}

type Pricing = ReturnType<typeof usePurchasePricing>;

/** The Items toolbar and the purchase line grid (TR_PURC mSG_PR). */
export function PurchaseLineGrid({
  lines,
  setLines,
  setLine,
  pricing,
  fullGrid,
  setFullGrid,
  testId,
  onGridKey,
  onRemoveLine,
}: {
  lines: PurchaseLine[];
  setLines: Dispatch<SetStateAction<PurchaseLine[]>>;
  setLine: (i: number, k: keyof PurchaseLine, v: string) => void;
  pricing: Pricing;
  fullGrid: boolean;
  setFullGrid: Dispatch<SetStateAction<boolean>>;
  testId: string;
  onGridKey: (event: KeyboardEvent<HTMLElement>) => void;
  onRemoveLine: (i: number) => void;
}) {
  const { calc, fineLocked, settingsReady, labourWithGhat } = pricing;
  return (
    <>
      <div className="toolbar" style={{ marginBottom: 6 }}>
        <h2 style={{ margin: 0 }}>Items</h2>
        <span className="spacer" />
        <GridModeToggle
          full={fullGrid}
          setFull={setFullGrid}
          extendedCount={purchaseExtendedLineFields.length}
          testId={testId}
        />
      </div>
      <table className="grid" onKeyDown={onGridKey}>
        <thead>
          <tr>
            <th>Item</th>
            <th>Tag</th>
            <th className="num">Pcs</th>
            <th className="num">Gross</th>
            <th className="num">Net Wt</th>
            <th className="num">Touch%</th>
            <th className="num">Rate</th>
            <th className="num">Making/g</th>
            <ExtendedHeaderCells full={fullGrid} fields={purchaseExtendedLineFields} />
            <th className="num">Fine</th>
            <th className="num">Amount</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {lines.map((l, i) => {
            const c = calc(l);
            const numCell = (k: keyof PurchaseLine, width: number) => (
              <td className="num">
                <input
                  style={{ width, textAlign: 'right' }}
                  value={String(l[k] ?? '')}
                  onChange={(e) => setLine(i, k, e.target.value)}
                />
              </td>
            );
            return (
              <tr key={i}>
                <td>
                  <LookupPicker
                    entity="items"
                    value={l.itCode}
                    onChange={(v) => setLine(i, 'itCode', v)}
                    style={{ width: 80 }}
                  />
                </td>
                <td>
                  <LookupPicker
                    entity="tags"
                    value={l.tagNo}
                    onChange={(v) => setLine(i, 'tagNo', v)}
                    style={{ width: 110 }}
                    onPick={(r) =>
                      setLines((ls) =>
                        ls.map((x, j) => {
                          if (j !== i) return x;
                          const invalidateLabour =
                            !!x.loadedLabourAmount &&
                            (
                              ['grossWt', 'netWt', 'touch', 'rate'] as Array<keyof PurchaseLine>
                            ).some((field) => loadedLabourDependsOn(x, field, labourWithGhat));
                          return {
                            ...x,
                            tagNo: String(r.code),
                            itCode: String(r.name || x.itCode),
                            netWt: String(r.ITM_NWT ?? x.netWt),
                            grossWt: String(r.ITM_GWT ?? x.grossWt),
                            touch: String(r.ITM_TOUCH ?? x.touch),
                            rate: String(r.ITM_RATE ?? x.rate),
                            fineWt: x.loadedFineWt ? '' : x.fineWt,
                            metalAmount: x.loadedMetalAmount ? '' : x.metalAmount,
                            labourAmount: invalidateLabour ? '' : x.labourAmount,
                            loadedFineWt: false,
                            loadedMetalAmount: false,
                            loadedLabourAmount: invalidateLabour ? false : x.loadedLabourAmount,
                          };
                        }),
                      )
                    }
                  />
                </td>
                {numCell('pcs', 44)}
                {numCell('grossWt', 64)}
                {numCell('netWt', 64)}
                {numCell('touch', 56)}
                {numCell('rate', 72)}
                {numCell('making', 64)}
                <ExtendedBodyCells
                  full={fullGrid}
                  fields={purchaseExtendedLineFields}
                  line={l}
                  row={i}
                  baseColumns={0}
                  setValue={(row, key, value) => setLine(row, key, value)}
                  readOnlyFields={fineLocked ? (['fineWt'] as const) : undefined}
                />
                <td className="num">{c.fine.toLocaleString('en-IN')}</td>
                <td className="num">{settingsReady ? c.net.toLocaleString('en-IN') : '—'}</td>
                <td>
                  <button type="button" className="danger" onClick={() => onRemoveLine(i)}>
                    ×
                  </button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </>
  );
}

/** Compact mode's per-row panel of the extended columns. */
export function PurchaseLineDetails({
  lines,
  fullGrid,
  setLine,
}: {
  lines: PurchaseLine[];
  fullGrid: boolean;
  setLine: (i: number, k: keyof PurchaseLine, v: string) => void;
}) {
  return (
    <>
      {lines.map((line, index) => (
        <details
          key={`purc-line-extra-${index}`}
          style={{ marginTop: 8, display: fullGrid ? 'none' : undefined }}
        >
          <summary>Item row {index + 1} desktop fields</summary>
          <div className="row">
            {purchaseExtendedLineFields.map(([key, label]) => (
              <div className="field" key={String(key)}>
                <label>{label}</label>
                <input
                  value={String(line[key] ?? '')}
                  onChange={(e) => setLine(index, key, e.target.value)}
                />
              </div>
            ))}
          </div>
        </details>
      ))}
    </>
  );
}
