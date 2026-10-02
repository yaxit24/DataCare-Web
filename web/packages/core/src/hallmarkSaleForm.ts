import { valueOldGoldLine } from './oldGold.js';

/**
 * Hallmark Sale editor ↔ voucher mapping (N40 / G45).
 *
 * A hallmark sale is an `SL_DATA` sale. `PUT /sales/:vchNo` rebuilds the voucher's complete write set
 * from the request, so whatever the editor does not send is lost. The screen used to restore about 13 of
 * the 60-odd line fields `GET /sales/:vchNo` returns, and none of the header fields it does not display.
 * An unchanged save therefore blanked HUID 2–4 and their weights, order and issue references,
 * descriptors and line discounts. It also moved the voucher to today's date, because an omitted `vchDate`
 * means "today".
 *
 * Rule: a loaded voucher is sent back AS LOADED, and only what the operator changed is overlaid.
 *  - Every field the view returns is passed through, including the ones this screen does not display.
 *  - A changed field takes the editor's value; a field cleared to blank is omitted, so the server applies
 *    its default.
 *  - `fineWt` and `metalAmount` are server derivations that the writer also accepts as overrides
 *    (sales.ts `lineFine`, `computeLine`). If an input they depend on changes, the loaded value is dropped
 *    so the server derives it again, unless the operator typed a new value into that cell.
 * A new voucher is built from the editor alone, exactly as before.
 */

export interface HallmarkLine {
  itCode: string;
  tagNo: string;
  huid: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  lessWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  fineWt: string;
  rateWith: string;
  rateType: string;
  metalAmount: string;
  labourType: string;
  labourPct: string;
  labourFixed: string;
  otherAmount: string;
  discountPct: string;
  ghatAmount: string;
  mrp: string;
  designNo: string;
  itmSize: string;
  style: string;
  itemLot: string;
  bagWt: string;
  remark: string;
  tblCode: string;
  tagGrossWt: string;
  tagNetWt: string;
  tagCost: string;
  karigarName: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  employeeCode: string;
  prCode: string;
  ordNo: string;
  ordYrcd: string;
  ordDbcd: string;
  ordSrno: string;
  isuNo: string;
  isuYrcd: string;
  isuDbcd: string;
  isuSrno: string;
  designImageId: string;
  orderTagStockAdd: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
  /** The line as the server returned it and as the editor first showed it. Absent on a new line. */
  loaded?: { view: Record<string, unknown>; editor: HallmarkLineFields };
}

export type HallmarkLineFields = Omit<HallmarkLine, 'loaded'>;
type FieldKey = keyof HallmarkLineFields;

/**
 * P7: fields deliberately NOT exposed on this grid, having been checked against the writer.
 *
 * Five have NO COLUMN IN SL_DETL at all despite the interface carrying a column comment
 * (ITM_MARGIN, TAG_LBR_PRC, TAG_LBR_RATE, TAG_LBR_AMT, TAG_OTH_AMT) — verified against
 * information_schema. Four more are declared on the contract but never read by the writer
 * (otherWt, itType, tagType, dataTransfer). Three are internal serials the server assigns
 * (tagSrNo, oldSrNo, vchSrno). `margin` is additionally server-derived on purpose: sales.ts:1866
 * notes a client-supplied cost would let the margin be manipulated.
 *
 * Exposing any of them would give the operator a cell that silently discards what they type, which is
 * worse than not showing the column — and it would inflate the depth metric with dead surface.
 * fineWt, metalAmount and labourFixed ARE exposed, because the writer honours each as an override.
 */
/**
 * Numeric line cells. A blank cell is omitted, never sent as 0: an explicit zero is an override at the
 * writer and would defeat the server's own derivation.
 */
export const NUMERIC_EXTENDED = new Set<string>([
  'lessWt',
  'ghtPct',
  'ghtWt',
  'westPct',
  'fineWt',
  'metalAmount',
  'labourPct',
  'labourFixed',
  'otherAmount',
  'discountPct',
  'ghatAmount',
  'mrp',
  'bagWt',
  'tagGrossWt',
  'tagNetWt',
  'tagCost',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
  'ordSrno',
  'isuSrno',
]);
const NUMERIC_BASE = new Set<string>(['pcs', 'grossWt', 'netWt', 'touch', 'rate']);

export const extendedLineFields: Array<[FieldKey, string]> = [
  ['lessWt', 'Ls Wt'],
  ['ghtPct', 'Ght%'],
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['fineWt', 'Fine'],
  ['rateWith', 'RtWith'],
  ['rateType', 'RateType'],
  ['metalAmount', 'ItAmt'],
  ['labourType', 'LType'],
  ['labourPct', 'Lbr%'],
  ['labourFixed', 'LbrFix'],
  ['otherAmount', 'OthAmt'],
  ['discountPct', 'LDisc%'],
  ['ghatAmount', 'GhtAmt'],
  ['mrp', 'Mrp'],
  ['designNo', 'Design'],
  ['itmSize', 'Size'],
  ['style', 'Style'],
  ['itemLot', 'ItmLot'],
  ['bagWt', 'BagWt'],
  ['remark', 'Remark'],
  ['tblCode', 'TblCode'],
  ['tagGrossWt', 'TagGwt'],
  ['tagNetWt', 'TagNwt'],
  ['tagCost', 'TagCost'],
  ['karigarName', 'KrCode'],
  ['karigarNetWt', 'KrNwt'],
  ['karigarTouch', 'KrTouch'],
  ['karigarWestPct', 'KrWst%'],
  ['karigarFine', 'KrFine'],
  ['employeeCode', 'EmpCod'],
  ['prCode', 'PrCost'],
  ['ordNo', 'OrdNo'],
  ['ordYrcd', 'OrdYr'],
  ['ordDbcd', 'OrdBk'],
  ['ordSrno', 'OrdSr'],
  ['isuNo', 'IsuNo'],
  ['isuYrcd', 'IsuYr'],
  ['isuDbcd', 'IsuBk'],
  ['isuSrno', 'IsuSr'],
  ['designImageId', 'Image'],
  ['orderTagStockAdd', 'OrdStk'],
  ['hallmarkId2', 'HmId2'],
  ['hallmarkId3', 'HmId3'],
  ['hallmarkId4', 'HmId4'],
  ['hallmarkIdWt', 'HmIdWt'],
  ['hallmarkId2Wt', 'HmId2Wt'],
  ['hallmarkId3Wt', 'HmId3Wt'],
  ['hallmarkId4Wt', 'HmId4Wt'],
];

export const blankHallmarkLine = (): HallmarkLine => ({
  itCode: 'GOLD',
  tagNo: '',
  huid: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  lessWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  fineWt: '',
  rateWith: '',
  rateType: '',
  metalAmount: '',
  labourType: '',
  labourPct: '',
  labourFixed: '',
  otherAmount: '',
  discountPct: '',
  ghatAmount: '',
  mrp: '',
  designNo: '',
  itmSize: '',
  style: '',
  itemLot: '',
  bagWt: '',
  remark: '',
  tblCode: '',
  tagGrossWt: '',
  tagNetWt: '',
  tagCost: '',
  karigarName: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  employeeCode: '',
  prCode: '',
  ordNo: '',
  ordYrcd: '',
  ordDbcd: '',
  ordSrno: '',
  isuNo: '',
  isuYrcd: '',
  isuDbcd: '',
  isuSrno: '',
  designImageId: '',
  orderTagStockAdd: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
});

/** Display text for a loaded value: zero and absent numbers show as a blank cell, as the desktop grid does. */
const cell = (value: unknown): string =>
  value == null
    ? ''
    : typeof value === 'number'
      ? value === 0
        ? ''
        : String(value)
      : String(value);
const n = (value: string): number => Number(value || 0);

/** View fields that are derived or positional and must never be sent back. */
const VIEW_LINE_READ_ONLY = new Set(['srNo', 'netAmount']);
/** Inputs to the writer's fine and metal-amount derivations. */
const DERIVATION_INPUTS: FieldKey[] = [
  'itCode',
  'pcs',
  'grossWt',
  'netWt',
  'lessWt',
  'touch',
  'ghtWt',
  'ghtPct',
  'westPct',
  'rate',
  'rateWith',
  'rateType',
];
const DERIVED_OVERRIDES: FieldKey[] = ['fineWt', 'metalAmount'];

/** The editor line for a line returned by `GET /sales/:vchNo`, remembering exactly what was loaded. */
export function hallmarkLineFromView(view: Record<string, unknown>): HallmarkLine {
  const fields = blankHallmarkLine();
  for (const key of Object.keys(fields) as FieldKey[]) {
    if (key === 'making' || key === 'pcs') continue;
    if (key in view) fields[key] = cell(view[key]);
  }
  fields.pcs = cell(view.pcs) || '1';
  fields.making = view.labourType === 'per_gram' ? cell(view.labourRate) : '';
  const editor = { ...fields };
  delete (editor as Partial<HallmarkLine>).loaded;
  return { ...fields, loaded: { view: { ...view }, editor } };
}

/** The request line a new (never loaded) editor line produces. */
function freshLineCommand(line: HallmarkLineFields): Record<string, unknown> {
  return {
    itCode: line.itCode,
    tagNo: line.tagNo || undefined,
    pcs: n(line.pcs),
    grossWt: n(line.grossWt),
    netWt: n(line.netWt),
    touch: n(line.touch),
    rate: n(line.rate),
    huid: line.huid || undefined,
    ...(line.making ? { labourType: 'per_gram', labourRate: n(line.making) } : {}),
    ...Object.fromEntries(
      extendedLineFields
        .map(([key]) => [key, String(line[key] ?? '').trim()] as const)
        .filter(([, value]) => value !== '')
        .map(([key, value]) => [key, NUMERIC_EXTENDED.has(key) ? Number(value) : value]),
    ),
  };
}

/** Keys whose editor value differs from what the editor showed when the line was loaded. */
export function changedLineFields(line: HallmarkLine): FieldKey[] {
  if (!line.loaded) return [];
  const before = line.loaded.editor;
  return (Object.keys(before) as FieldKey[]).filter(
    (key) => String(line[key] ?? '').trim() !== String(before[key] ?? '').trim(),
  );
}

/** The request line for an editor line: the loaded line as loaded, with only the operator's changes. */
export function hallmarkLineCommand(line: HallmarkLine): Record<string, unknown> {
  const { loaded, ...fields } = line;
  if (!loaded) return freshLineCommand(fields);
  // Blank text is omitted, exactly as a new voucher omits it, so the writer applies the same default it
  // applied on create (an untagged line is stored as TAG_NO 'N', which the view shows as blank).
  const command: Record<string, unknown> = Object.fromEntries(
    Object.entries(loaded.view).filter(
      ([key, value]) => !VIEW_LINE_READ_ONLY.has(key) && value !== undefined && value !== '',
    ),
  );
  const changed = new Set(changedLineFields(line));
  for (const key of changed) {
    if (key === 'making') continue;
    const value = String(fields[key] ?? '').trim();
    if (value === '') delete command[key];
    else command[key] = NUMERIC_EXTENDED.has(key) || NUMERIC_BASE.has(key) ? Number(value) : value;
  }
  if (changed.has('making')) {
    if (fields.making.trim()) {
      command.labourRate = n(fields.making);
      if (!fields.labourType.trim()) command.labourType = 'per_gram';
    } else {
      delete command.labourRate;
      if (command.labourType === 'per_gram' && !fields.labourType.trim()) delete command.labourType;
    }
  }
  // A changed input invalidates the loaded fine and metal amount, unless the operator typed new ones.
  if (DERIVATION_INPUTS.some((key) => changed.has(key))) {
    for (const key of DERIVED_OVERRIDES) if (!changed.has(key)) delete command[key];
  }
  return command;
}

/** Header fields this screen edits, as the editor holds them. */
export interface HallmarkHeader {
  acCode: string;
  acName: string;
  taxRatePct: string;
  discountAmount: string;
  interState: boolean;
  hallmarkAmount: string;
  cashAmt: string;
  cardAmt: string;
  upiAmt: string;
  chequeAmt: string;
}

/** The single old-metal row this screen edits. */
export interface HallmarkOldGold {
  netWt: string;
  touch: string;
  rate: string;
}

/** Everything the server returned on load, and what the editor first showed from it. */
export interface LoadedHallmarkSale {
  view: Record<string, unknown>;
  header: HallmarkHeader;
  oldGold: HallmarkOldGold;
}

/**
 * Header fields of `GET /sales/:vchNo` that `PUT /sales/:vchNo` accepts under the same name
 * (routes/txn.ts `saleInput`). They are passed back unchanged, including the ones this screen does not
 * display: date, bill number, salesperson, address, settlement accounts, TCS/TDS, kasar, issue references.
 *
 * `taxCode` is deliberately NOT passed back. This screen never chooses a tax code: create and edit both
 * resolve it from the tax rate, so an unchanged save stores the same code. Passing it back would send it
 * through the by-code resolver instead, which requires the desktop parent row (`TAX_MAST.SR_NO = 0`).
 * Web-provisioned companies hold their tax codes at `SR_NO = 1` (G82), so the edit would be refused.
 */
const VIEW_HEADER_PASSTHROUGH = [
  'acCode',
  'acName',
  'billNo',
  'vchDate',
  'discountAmount',
  'discountPct',
  'taxRatePct',
  'interState',
  'rateUnfix',
  'cashAmt',
  'cardAmt',
  'upiAmt',
  'chequeAmt',
  'bankAc',
  'hallmarkAmount',
  'tcsAmount',
  'tcsPct',
  'tcsCode',
  'tdsCode',
  'tdsPct',
  'tdsAmount',
  'kasarAmount',
  'orderRef',
  'crDays',
  'empCode',
  'cardAc',
  'chequeNo',
  'bankName',
  'cardCommissionAmount',
  'cashPaid',
  'currentAdjustmentAmount',
  'schemeAc',
  'schemeAmount',
  'pointValue',
  'address1',
  'address2',
  'address3',
  'city',
  'mobile',
  'issueNo',
  'issueYear',
  'issueBook',
  'description',
  'ornamentIssued',
] as const;

export function hallmarkHeaderFromView(view: Record<string, unknown>): HallmarkHeader {
  return {
    acCode: String(view.acCode ?? ''),
    acName: String(view.acName ?? ''),
    taxRatePct: cell(view.taxRatePct) || '0',
    discountAmount: cell(view.discountAmount),
    interState: !!view.interState,
    hallmarkAmount: cell(view.hallmarkAmount),
    cashAmt: cell(view.cashAmt),
    cardAmt: cell(view.cardAmt),
    upiAmt: cell(view.upiAmt),
    chequeAmt: cell(view.chequeAmt),
  };
}

export function hallmarkOldGoldFromView(view: Record<string, unknown>): HallmarkOldGold {
  const first = ((view.oldGold as Array<Record<string, unknown>> | undefined) ?? [])[0];
  return { netWt: cell(first?.netWt), touch: cell(first?.touch), rate: cell(first?.rate) };
}

/**
 * The screen's old-metal amount, exactly as the writer stores it (G83): `valueOldGoldLine`, i.e. fine at three
 * decimals and `Math.Round(fine x rate, 0)` (`TR_SALE.cs` `CommPassTotal_Old`). Computing net x touch x rate to the
 * paisa showed 25,821.60 for a row the server stores at 25,822.
 */
const oldGoldAmount = (og: HallmarkOldGold) =>
  valueOldGoldLine({ netWt: n(og.netWt), touch: n(og.touch), rate: n(og.rate) }).amount;

/** The hallmark screen's old-metal helpers: read a loaded voucher's row, and preview the stored amount. */
export const hallmarkOldGold = Object.freeze({
  fromView: hallmarkOldGoldFromView,
  value: (netWt: string, touch: string, rate: string): number =>
    oldGoldAmount({ netWt, touch, rate }),
});

/** The new-voucher header, exactly as the screen always built it. */
function freshHeader(header: HallmarkHeader): Record<string, unknown> {
  return {
    acCode: header.acCode,
    acName: header.acName || undefined,
    taxRatePct: Number(header.taxRatePct),
    interState: header.interState,
    discountAmount: header.discountAmount ? Number(header.discountAmount) : undefined,
    hallmarkAmount: header.hallmarkAmount ? n(header.hallmarkAmount) : undefined,
    cashAmt: header.cashAmt ? n(header.cashAmt) : undefined,
    cardAmt: header.cardAmt ? n(header.cardAmt) : undefined,
    upiAmt: header.upiAmt ? n(header.upiAmt) : undefined,
    chequeAmt: header.chequeAmt ? n(header.chequeAmt) : undefined,
  };
}

function freshOldGold(og: HallmarkOldGold): Array<Record<string, unknown>> | undefined {
  const amount = oldGoldAmount(og);
  return amount > 0
    ? [{ itCode: 'OG', netWt: n(og.netWt), touch: n(og.touch), rate: n(og.rate), amount }]
    : undefined;
}

/** The `POST /sales` or `PUT /sales/:vchNo` body for the editor's state. */
export function hallmarkSaleCommand(input: {
  scope: { coBook: string; coYear: string; lcCode: string };
  header: HallmarkHeader;
  oldGold: HallmarkOldGold;
  lines: HallmarkLine[];
  loaded?: LoadedHallmarkSale;
}): Record<string, unknown> {
  const lines = input.lines
    .filter((line) => line.loaded || (line.itCode && (line.netWt || line.rate)))
    .map(hallmarkLineCommand);
  if (!input.loaded) {
    return {
      ...input.scope,
      ...freshHeader(input.header),
      oldGold: freshOldGold(input.oldGold),
      lines,
    };
  }
  const { view, header: before, oldGold: oldGoldBefore } = input.loaded;
  const command: Record<string, unknown> = Object.fromEntries(
    VIEW_HEADER_PASSTHROUGH.filter((key) => view[key] !== undefined && view[key] !== '').map(
      (key) => [key, view[key]],
    ),
  );
  const fresh = freshHeader(input.header);
  for (const key of Object.keys(before) as Array<keyof HallmarkHeader>) {
    if (input.header[key] === before[key]) continue;
    if (fresh[key] === undefined) delete command[key];
    else command[key] = fresh[key];
  }
  const oldGoldChanged = (Object.keys(oldGoldBefore) as Array<keyof HallmarkOldGold>).some(
    (key) => input.oldGold[key].trim() !== oldGoldBefore[key].trim(),
  );
  const loadedOldGold = (view.oldGold as Array<Record<string, unknown>> | undefined) ?? [];
  let oldGold: Array<Record<string, unknown>> | undefined = loadedOldGold.length
    ? loadedOldGold.map((row) => ({ ...row }))
    : undefined;
  // Since G83 the writer values every exchange row on the server and posts the detail, header, ledger and
  // BILL_OS from that one valuation, so the posted `amount` only matters when no rate is supplied (the desktop's
  // typed-amount flow). Sending the stored header total back keeps an unchanged save identical either way.
  const goldRows = (oldGold ?? []).filter((row) => (row.metal ?? 'G') === 'G');
  if (goldRows.length === 1 && typeof view.oldGoldAmount === 'number')
    goldRows[0]!.amount = view.oldGoldAmount;
  if (oldGoldChanged) {
    const amount = oldGoldAmount(input.oldGold);
    const edited = {
      ...(loadedOldGold[0] ?? { itCode: 'OG' }),
      netWt: n(input.oldGold.netWt),
      touch: n(input.oldGold.touch),
      rate: n(input.oldGold.rate),
      amount,
    };
    const rest = loadedOldGold.slice(1).map((row) => ({ ...row }));
    oldGold = amount > 0 ? [edited, ...rest] : rest.length ? rest : undefined;
  }
  return { ...input.scope, ...command, oldGold, lines };
}
