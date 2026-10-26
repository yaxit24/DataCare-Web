import { fineFor, labourCharge, lineNet, metalAmount } from '@datacare/core';

/**
 * Purchase Return editor <-> voucher mapping (N34 / G47).
 *
 * `PUT /purchase-returns/:vchNo` rebuilds the voucher's complete write set from the request (TR_KR_ISU saves a
 * reopened voucher through the same handler as a new one, BtnSave_Click :4928-5355), so whatever the screen
 * does not send back is lost. Rule, as for the hallmark sale (`@datacare/core` hallmarkSaleForm):
 *  - A loaded line is sent back AS LOADED: every field `GET /purchase-returns/:vchNo` returned, including the
 *    ones the grid does not show (metal code, rate type, HUID, other amount, labour amount).
 *  - Only the cells the operator changed are overlaid; a cell cleared to blank is omitted.
 *  - `fineWt`, `metalAmount` and `labourAmount` are server derivations the writer also accepts as overrides
 *    (purchase.ts `lineFine`, `computeLine`). When an input they depend on changes they are dropped, so the
 *    server derives them again, unless the operator typed a new value into that cell.
 * A new line (typed or imported from the original purchase) is built from the editor alone.
 */
export interface LineFields {
  itCode: string;
  tagNo: string;
  /** The tag instance on the original purchase line. Server-owned identity; never typed by the operator. */
  vchSrno?: number;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
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
  urdRateType: string;
}

export interface Line extends LineFields {
  /** What the server returned for this line, and what the editor first showed from it. */
  loaded?: { view: Record<string, unknown>; editor: LineFields };
}

type TextKey = Exclude<keyof LineFields, 'vchSrno'>;

export const extendedLineFields: Array<[TextKey, string]> = [
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
  ['commissionPct', 'Comm %'],
  ['commissionAmount', 'Comm Amt'],
  ['fineCutPcs', 'Fine-cut Pcs'],
  ['fineCutGrossWt', 'Fine-cut Gross'],
  ['fineCutNetWt', 'Fine-cut Net'],
  ['fineCutFine', 'Fine-cut Fine'],
  ['prCode', 'PR Code'],
  ['urdRateType', 'URD Rate Type'],
];

/** Extended cells sent as numbers. The others, and the fine-cut and commission amounts, keep the old wire form. */
const NUMERIC_EXTENDED = new Set<string>([
  'bagWt',
  'lessWt',
  'lossWt',
  'ghtPct',
  'ghtWt',
  'westPct',
  'fineWt',
  'labourPct',
  'lessTouch',
  'lesTouch',
  'kunFine',
  'convRate',
  'convPct',
  'otherRate',
  'mrp',
  'metalAmount',
]);
const NUMERIC_BASE = new Set<string>(['pcs', 'grossWt', 'netWt', 'touch', 'rate']);
/** View fields that are derived or positional and are never sent back. */
const VIEW_LINE_READ_ONLY = new Set(['srNo', 'netAmount', 'stones']);
/** Inputs to the writer's fine and metal-amount derivations. */
const FINE_INPUTS: TextKey[] = [
  'itCode',
  'grossWt',
  'netWt',
  'touch',
  'ghtWt',
  'westPct',
  'lesTouch',
  'kunFine',
];
/** Inputs to the per-gram and per-piece labour derivations. */
const LABOUR_INPUTS: TextKey[] = ['pcs', 'netWt', 'ghtWt', 'making', 'labourPct'];

export const blank = (): Line => ({
  itCode: 'GOLD',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
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
  urdRateType: '',
});

/** Display text for a loaded value: zero and absent numbers show as a blank cell, as the desktop grid does. */
export const cell = (value: unknown): string =>
  value == null
    ? ''
    : typeof value === 'number'
      ? value === 0
        ? ''
        : String(value)
      : String(value);
const n = (value: string): number => Number(value || 0);
const num = (value: unknown): number => Number(value ?? 0) || 0;

const fieldsOf = (line: Line): LineFields => {
  const { loaded: _loaded, ...fields } = line;
  return fields;
};

/** An editor line for a line of `GET /purchase-returns/:vchNo`, remembering exactly what was loaded. */
export function lineFromView(view: Record<string, unknown>): Line {
  const fields = blank() as LineFields;
  for (const key of Object.keys(fields) as TextKey[]) {
    if (key === 'making' || key === 'pcs') continue;
    if (key in view) fields[key] = cell(view[key]);
  }
  fields.pcs = cell(view.pcs) || '1';
  fields.making = view.labourType === 'per_gram' ? cell(view.labourRate) : '';
  fields.vchSrno = Number(view.vchSrno ?? 0) || undefined;
  return { ...fields, loaded: { view: { ...view }, editor: { ...fields } } };
}

/** A new line from a line of the original purchase (`GET /purchases/:vchNo`), for the source import. */
export function lineFromPurchase(view: Record<string, unknown>): Line {
  return {
    ...blank(),
    itCode: String(view.itCode ?? ''),
    tagNo: String(view.tagNo ?? ''),
    vchSrno: Number(view.vchSrno ?? 0) || undefined,
    pcs: cell(view.pcs) || '1',
    grossWt: cell(view.grossWt),
    netWt: cell(view.netWt),
    touch: cell(view.touch),
    rate: cell(view.rate),
    making: view.labourType === 'per_gram' ? cell(view.labourRate) : '',
    ghtWt: cell(view.ghtWt),
    westPct: cell(view.westPct),
    designNo: String(view.designNo ?? ''),
    tblCode: String(view.tblCode ?? ''),
    itDesc: String(view.itDesc ?? ''),
    mrp: cell(view.mrp),
  };
}

/** Keys whose editor value differs from what the editor showed when the line was loaded. */
export function changedLineFields(line: Line): TextKey[] {
  if (!line.loaded) return [];
  const before = line.loaded.editor;
  return (Object.keys(before) as Array<keyof LineFields>).filter(
    (key): key is TextKey =>
      key !== 'vchSrno' && String(line[key] ?? '').trim() !== String(before[key] ?? '').trim(),
  );
}

/** The loaded cells an edited input invalidates: a fine input invalidates fine and metal, a rate or fine metal. */
function invalidatedBy(key: TextKey): TextKey[] {
  if ((FINE_INPUTS as string[]).includes(key)) return ['fineWt', 'metalAmount'];
  return key === 'rate' || key === 'fineWt' ? ['metalAmount'] : [];
}

/**
 * Set cells. On a loaded line, a loaded fine or metal amount that an edited input invalidates is shown blank
 * (the server derives it again), unless the operator typed a new value into that cell.
 */
export function updateLine(line: Line, patch: Partial<LineFields>): Line {
  const next: Line = { ...line, ...patch };
  // A different tag is a different instance: the serial of the old one never carries over.
  if ('tagNo' in patch && !('vchSrno' in patch) && patch.tagNo !== line.tagNo)
    next.vchSrno = undefined;
  if (!line.loaded) return next;
  for (const key of Object.keys(patch) as Array<keyof LineFields>) {
    if (key === 'vchSrno') continue;
    for (const derived of invalidatedBy(key))
      if (!(derived in patch) && next[derived] === line.loaded.editor[derived]) next[derived] = '';
  }
  return next;
}

export const setLineCell = (line: Line, key: TextKey, value: string): Line =>
  updateLine(line, { [key]: value });

/** The request line a new (never loaded) editor line produces. */
function freshLineCommand(line: LineFields): Record<string, unknown> {
  return {
    itCode: line.itCode,
    tagNo: line.tagNo || undefined,
    vchSrno: line.tagNo ? line.vchSrno : undefined,
    pcs: n(line.pcs),
    grossWt: n(line.grossWt),
    netWt: n(line.netWt),
    touch: n(line.touch),
    rate: n(line.rate),
    ...(line.making ? { labourType: 'per_gram', labourRate: n(line.making) } : {}),
    // A blank cell is OMITTED, never sent as 0: an explicit zero is an override at the writer.
    ...Object.fromEntries(
      extendedLineFields
        .map(([key]) => [key, String(line[key] ?? '').trim()] as const)
        .filter(([, value]) => value !== '')
        .map(([key, value]) => [key, NUMERIC_EXTENDED.has(key) ? Number(value) : value]),
    ),
  };
}

/** The request line for an editor line: the loaded line as loaded, with only the operator's changes. */
export function lineCommand(line: Line): Record<string, unknown> {
  const fields = fieldsOf(line);
  const loaded = line.loaded;
  if (!loaded) return freshLineCommand(fields);
  // Blank text is omitted, as a new voucher omits it, so the writer applies the default it applied on
  // create (an untagged line is stored as TAG_NO 'N', which the view shows as blank).
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
  if (changed.has('tagNo')) {
    // A different tag is a different instance: the serial loaded with the old one no longer applies.
    if (fields.vchSrno == null || !fields.tagNo) delete command.vchSrno;
    else command.vchSrno = fields.vchSrno;
  }
  if (changed.has('making')) {
    if (fields.making.trim()) {
      command.labourType = 'per_gram';
      command.labourRate = n(fields.making);
    } else if (command.labourType === 'per_gram') {
      delete command.labourType;
      delete command.labourRate;
    }
  }
  if (FINE_INPUTS.some((key) => changed.has(key)) && !changed.has('fineWt')) delete command.fineWt;
  if (
    [...FINE_INPUTS, 'rate' as const, 'fineWt' as const].some((key) => changed.has(key)) &&
    !changed.has('metalAmount')
  )
    delete command.metalAmount;
  // Labour the server can derive (per gram, per piece) is derived again from the changed inputs; an amount
  // with no derivable basis (desktop G or K, or a flat charge) is kept as loaded. A changed making rate is a
  // new labour basis, so the loaded amount never survives it (clearing the rate removes the labour).
  const derivable = command.labourType === 'per_gram' || command.labourType === 'per_piece';
  if (changed.has('making') || (derivable && LABOUR_INPUTS.some((key) => changed.has(key))))
    delete command.labourAmount;
  return command;
}

/**
 * Live preview of one line, computed from the request line itself so the screen shows what the server will
 * derive: fine as `lineFine` (purchase.ts), metal = fine x rate, labour per gram ((net + ghat) x rate, ghat
 * dropped when LBR_WITH_GHT = 'N') or per piece, plus the other amount.
 */
export function linePreview(
  line: Line,
  labourWithGhat: boolean,
): { fine: number; metal: number; labour: number; net: number } {
  const c = lineCommand(line);
  const oldGold = c.lesTouch != null || c.kunFine != null;
  const fine =
    c.fineWt != null
      ? num(c.fineWt)
      : fineFor(oldGold ? 'purchaseOldGold' : 'purchaseItem', {
          netWt: num(c.netWt),
          touch: num(c.touch),
          ghtWt: num(c.ghtWt),
          westPct: num(c.westPct),
          lesTouch: num(c.lesTouch),
          kunFine: num(c.kunFine),
        });
  const metal = c.metalAmount != null ? num(c.metalAmount) : metalAmount(fine, num(c.rate));
  const labour =
    c.labourAmount != null
      ? num(c.labourAmount)
      : c.labourType === 'per_gram'
        ? labourCharge('per_gram', {
            netWt: num(c.netWt),
            ghatWt: num(c.ghtWt),
            withGhat: labourWithGhat,
            rate: num(c.labourRate),
          })
        : c.labourType === 'per_piece'
          ? labourCharge('per_piece', { pcs: num(c.pcs), rate: num(c.labourRate) })
          : 0;
  return { fine, metal, labour, net: lineNet({ metal, labour, other: num(c.otherAmount) }) };
}
