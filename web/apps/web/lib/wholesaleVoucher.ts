/**
 * TR_WH_SALE — the one desktop form behind both "Wh Sales" (F6) and "Rate Cut" (Ctrl+F6).
 *
 * The desktop opens the same form from two menus and scopes it to a book family: `CurBookHelp("WH SALES")` or
 * `CurBookHelp("RATE CUT")` (MDI_FORM.cs:14188-14210, :16107-16121). The web keeps one form
 * (components/WholesaleVoucherForm.tsx) on two pages, each posting only to its own resource and books.
 *
 * This module is the form's pure half — state, the desktop's cell cascades, the request payload, the preview and
 * the reopen mapping — so it can be tested without a browser. The preview runs the SAME `@datacare/core`
 * arithmetic the API posts with (`wholesaleIssueLine` / `wholesaleReceiveLine` / `wholesaleGridTotals` /
 * `settleMoneyMetal` / `wholesaleBand`) on the SAME payload the form sends, so what the operator sees is what
 * posts.
 */
import {
  round,
  settleMoneyMetal,
  wholesaleBand,
  wholesaleGridTotals,
  wholesaleIssueLine,
  wholesaleReceiveLine,
  type SettlementResult,
  type WholesaleBand,
  type WholesaleGridTotals,
  type WholesaleLineInput,
  type WholesaleLineResult,
  type WholesaleLineSettings,
} from '@datacare/core';
import { companyFlag, companySetting, type CompanySettingValues } from './companySettings';

export type WholesaleWorkflow = 'wholesale-sale' | 'rate-cut' | 'wholesale-quotation' | 'tour-sale';

export interface WholesaleWorkflowConfig {
  title: string;
  /** API resource. Each refuses a book of the other family (`assertRateCutBookGuard`). */
  endpoint: '/wholesale-sales' | '/rate-cut' | '/wholesale-quotations' | '/tour-sales';
  /** `BOOK_DATA.MAIN_BOOK` the book picker offers. */
  mainBook: 'WH SALES' | 'RATE CUT' | 'WH QUOT' | 'TOUR SALES';
  /** Where the desktop opens it from. */
  desktop: string;
  testId: string;
}

export const WHOLESALE_WORKFLOWS: Record<WholesaleWorkflow, WholesaleWorkflowConfig> = {
  'wholesale-sale': {
    title: 'Wholesale Sale',
    endpoint: '/wholesale-sales',
    mainBook: 'WH SALES',
    desktop: 'Wh Sales (F6)',
    testId: 'wholesale-sale',
  },
  'rate-cut': {
    title: 'Rate Cut',
    endpoint: '/rate-cut',
    mainBook: 'RATE CUT',
    desktop: 'Rate Cut (Ctrl+F6)',
    testId: 'rate-cut',
  },
  'wholesale-quotation': {
    title: 'Wholesale Quotation',
    endpoint: '/wholesale-quotations',
    mainBook: 'WH QUOT',
    desktop: 'Wh Quotation — TR_WH_SALE',
    testId: 'wholesale-quotation',
  },
  'tour-sale': {
    title: 'Tour Sales',
    endpoint: '/tour-sales',
    mainBook: 'TOUR SALES',
    desktop: 'Tour Sales — TR_TOUR_SALE',
    testId: 'tour-sale',
  },
};

// ────────────────────────────────────────────────────────────────────────────
// STATE
// ────────────────────────────────────────────────────────────────────────────

/** One grid row, as typed. Every cell is a string so a blank stays distinguishable from 0. */
export interface VoucherLine {
  tagNo: string;
  /** The tag instance picked (`VCH_SRNO`); sent with the tag so the save reserves exactly that one. */
  vchSrno: string;
  itCode: string;
  itemName: string;
  tblCode: string;
  designNo: string;
  itemSize: string;
  hallmarkId: string;
  hallmarkIdWt: string;
  karigarName: string;
  prCode: string;
  lotNo: string;
  itemLot: string;
  pcs: string;
  grossWt: string;
  othWt: string;
  netWt: string;
  ghtPct: string;
  ghtWt: string;
  touch: string;
  westPct: string;
  lessTouch: string;
  lessWt: string;
  hallmarkFine: string;
  convRate: string;
  convPct: string;
  rate: string;
  /** Item `RATE_TYPE`: '' leaves it to the item master; G per gram, 1 per 10 g, K per kg, P per piece. */
  rateType: string;
  lbrType: string;
  /** A new row's labour basis is the company's until the operator picks one (CommPassAdd col 34, :8362). */
  lbrTypeFromCompany: boolean;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  otherRate: string;
  otherFine: string;
  mrp: string;
  taxPct: string;
  tagCost: string;
  tagGrossWt: string;
  tagNetWt: string;
  silverFine: string;
  mcxRate: string;
  adjustWt: string;
  issueLcCode: string;
  issueYear: string;
  issueBook: string;
  issueNo: string;
  issueSrno: string;
  /** The fine the tag or the saved voucher brought (TR_WH_SALE.cs:10697, :12497). */
  storedFine: string;
  /** Weight and purity as they were when `storedFine` was taken; any edit to them drops it. */
  storedFineKey: string;
  /**
   * The figures came from a tag or a saved voucher. A blank numeric cell then posts as 0: omitting it would let
   * the server fill the tag's own value back in, so the row saved would not be the row on screen.
   */
  explicit: boolean;
}

export type LineField = Exclude<keyof VoucherLine, 'lbrTypeFromCompany' | 'explicit'>;

export const blankLine = (): VoucherLine => ({
  tagNo: '',
  vchSrno: '',
  itCode: '',
  itemName: '',
  tblCode: '',
  designNo: '',
  itemSize: '',
  hallmarkId: '',
  hallmarkIdWt: '',
  karigarName: '',
  prCode: '',
  lotNo: '',
  itemLot: '',
  pcs: '',
  grossWt: '',
  othWt: '',
  netWt: '',
  ghtPct: '',
  ghtWt: '',
  touch: '',
  westPct: '',
  lessTouch: '',
  lessWt: '',
  hallmarkFine: '',
  convRate: '',
  convPct: '',
  rate: '',
  rateType: '',
  lbrType: '',
  lbrTypeFromCompany: true,
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  otherRate: '',
  otherFine: '',
  mrp: '',
  taxPct: '',
  tagCost: '',
  tagGrossWt: '',
  tagNetWt: '',
  silverFine: '',
  mcxRate: '',
  adjustWt: '',
  issueLcCode: '',
  issueYear: '',
  issueBook: '',
  issueNo: '',
  issueSrno: '',
  storedFine: '',
  storedFineKey: '',
  explicit: false,
});

export interface VoucherHeader {
  vchDate: string;
  billNo: string;
  acCode: string;
  acName: string;
  mobile: string;
  add1: string;
  add2: string;
  add3: string;
  city: string;
  empCode: string;
  vchDesc: string;
  /** `cboItemTyp` Gold / Silver (the header IT_TYPE). */
  itType: 'G' | 'S';
  /** `nFineRate`, `nConvRate`, `nConvPrc`: the rate the fine is cut at. */
  fineRate: string;
  convRate: string;
  convPct: string;
  /** "Ac Amt Dr / Cr" and "Ac Fine Dr / Cr" (nAcDrAmt, nAcCrAmt, nAcDrFine, nAcCrFine). */
  settleDrAmt: string;
  settleCrAmt: string;
  settleDrFine: string;
  settleCrFine: string;
}

/** One column of the settlement band: rows Cheque, Card, Cash and Kasar. */
export interface VoucherTender {
  cheque: string;
  card: string;
  cash: string;
  kasar: string;
}

export interface VoucherState {
  header: VoucherHeader;
  issued: VoucherLine[];
  received: VoucherLine[];
  /** Band column 4, captioned "Received": the SL_* tender, API `pay`. */
  receivedTender: VoucherTender;
  /** Band column 3, captioned "Payment": the PR_* tender, API `receivedPay`. */
  paymentTender: VoucherTender;
  /** One bank account with its cheque number, and one card account, per voucher (BANK_AC, CHQ_NO, CARD_AC). */
  bankAc: string;
  chqNo: string;
  cardAc: string;
}

/** The operator's local calendar day, not UTC's: before 05:30 IST the UTC date is still yesterday. */
export function todayLocal(now = new Date()): string {
  const pad = (value: number) => String(value).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
}

const blankTender = (): VoucherTender => ({ cheque: '', card: '', cash: '', kasar: '' });

export const blankVoucher = (vchDate = todayLocal()): VoucherState => ({
  header: {
    vchDate,
    billNo: '',
    acCode: '',
    acName: '',
    mobile: '',
    add1: '',
    add2: '',
    add3: '',
    city: '',
    empCode: '',
    vchDesc: '',
    itType: 'G',
    fineRate: '',
    convRate: '',
    convPct: '',
    settleDrAmt: '',
    settleCrAmt: '',
    settleDrFine: '',
    settleCrFine: '',
  },
  issued: [blankLine()],
  received: [blankLine()],
  receivedTender: blankTender(),
  paymentTender: blankTender(),
  bankAc: '',
  chqNo: '',
  cardAc: '',
});

// ────────────────────────────────────────────────────────────────────────────
// COMPANY SETTINGS
// ────────────────────────────────────────────────────────────────────────────

export interface WholesaleSettings {
  line: WholesaleLineSettings;
  /** `MsRatePar` from CO_SET.RATE_PAR: T per 10 g, K per kg, anything else per gram. */
  ratePar: 'G' | 'T' | 'K';
}

/**
 * The settings the grid honours: `CO_SET_NEW.LBR_WITH_GHT` (blank is 'Y', MS_OPNCOMP.cs:1224-1226),
 * `CO_SET.LBR_TYPE` (blank is 'G', :733-735) and `CO_SET.RATE_PAR` (blank is 'G', :672). Until `/settings`
 * answers, the desktop's blank defaults apply — the same the server falls back to.
 */
export function wholesaleSettings(values: CompanySettingValues | null): WholesaleSettings {
  const first = (column: string) =>
    String(companySetting(values, column) ?? '')
      .trim()
      .toUpperCase()
      .slice(0, 1);
  const labourType = first('LBR_TYPE');
  const ratePar = first('RATE_PAR');
  return {
    line: {
      labourIncludesGhat: companyFlag(values, 'LBR_WITH_GHT', 'Y'),
      companyLabourType: ['G', 'N', 'K', 'P'].includes(labourType) ? labourType : 'G',
    },
    ratePar: ratePar === 'T' || ratePar === 'K' ? ratePar : 'G',
  };
}

/** `lblRate`: "10gm Rate", "Kg Rate" or "1gm Rate" by the company's rate basis (TR_WH_SALE.cs:12086-12099). */
export function fineRateCaption(ratePar: WholesaleSettings['ratePar']): string {
  if (ratePar === 'T') return '10gm Rate';
  if (ratePar === 'K') return 'Kg Rate';
  return '1gm Rate';
}

// ────────────────────────────────────────────────────────────────────────────
// CELL CASCADES (the desktop recomputes a dependent cell when its source changes)
// ────────────────────────────────────────────────────────────────────────────

const n = (value: string | undefined): number => {
  const x = Number(String(value ?? '').trim() || 0);
  return Number.isFinite(x) ? x : 0;
};
const filled = (value: string | undefined): boolean => String(value ?? '').trim() !== '';
const digits3 = (x: number): string => String(round(x, 3));

/**
 * The weight and purity a stored fine depends on: the cells whose change makes the grid recompute it (issue
 * col 26 from cols 15-21 and 24, TR_WH_SALE.cs:9436-9660; receive col 15 from cols 8-14, :6872-6906). A hallmark
 * fine is not here because the arithmetic itself drops a stored fine once one is entered (:9540).
 */
export function fineKey(line: VoucherLine, side: 'issue' | 'receive'): string {
  return [
    line.grossWt,
    line.othWt,
    line.netWt,
    line.ghtPct,
    line.ghtWt,
    line.touch,
    line.westPct,
    side === 'issue' ? line.lessWt : line.lessTouch,
  ]
    .map((value) => String(value ?? '').trim())
    .join('|');
}

/**
 * Apply one typed cell, with the desktop's cascades:
 * - gross or other weight → net = gross − other (`CommPassTotal` col 17, TR_WH_SALE.cs:9190; receive col 10);
 * - a ghat % replaces a typed ghat weight and the reverse (col 19 = col 17 × col 18 / 100);
 * - choosing a labour basis ends the company default;
 * - retyping a picked tag's number starts the line afresh, since its figures belonged to the old tag.
 */
export function editLine(line: VoucherLine, field: LineField, value: string): VoucherLine {
  if (field === 'tagNo' && line.explicit && value.trim() !== line.tagNo.trim()) {
    return { ...blankLine(), tagNo: value };
  }
  const next: VoucherLine = { ...line, [field]: value };
  if (field === 'grossWt' || field === 'othWt') {
    next.netWt =
      filled(next.grossWt) || filled(next.othWt) ? digits3(n(next.grossWt) - n(next.othWt)) : '';
  }
  if (field === 'ghtPct' && filled(value)) next.ghtWt = '';
  if (field === 'ghtWt' && filled(value)) next.ghtPct = '';
  if (field === 'lbrType') next.lbrTypeFromCompany = false;
  return next;
}

/** A row that carries something to post. Blank rows are the grid's spare lines and are not sent. */
export function isActiveLine(line: VoucherLine): boolean {
  if (filled(line.tagNo) || filled(line.itCode)) return true;
  return [line.pcs, line.grossWt, line.netWt, line.rate, line.lbrAmt, line.othAmt].some(
    (value) => n(value) !== 0,
  );
}

// ────────────────────────────────────────────────────────────────────────────
// PICKS
// ────────────────────────────────────────────────────────────────────────────

type Row = Record<string, unknown>;
const cell = (value: unknown): string => {
  if (value == null) return '';
  if (typeof value === 'number') return value === 0 ? '' : String(value);
  return String(value).trim();
};
const LABOUR_TYPES = new Set(['', 'G', 'N', 'K', 'P']);
const RATE_TYPES = new Set(['G', '1', 'K', 'P']);
const codeOf = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase();

/**
 * A tag chosen from `/lookup/available-tags` fills the row as TR_WH_SALE does (:10641-10736): weights, ghat %,
 * touch, wastage and the stored fine; counter, design, size, hallmark, karigar and product; labour basis, rate
 * and amount; other charges; item rate, rate type, MRP and cost (`KR_COST` → TagCost, col 58). The tag's labour
 * basis replaces the company default, blank included (Next23 034/4 saves '').
 */
export function lineFromTag(row: Row, previous: VoucherLine = blankLine()): VoucherLine {
  const labourType = codeOf(row.LBR_TYPE);
  const rateType = codeOf(row.RATE_TYPE);
  const line: VoucherLine = {
    ...blankLine(),
    // Receive-side links on the row the operator started are kept; everything else comes from the tag.
    issueLcCode: previous.issueLcCode,
    tagNo: cell(row.code ?? row.TAG_NO),
    vchSrno: row.VCH_SRNO == null ? '' : String(row.VCH_SRNO),
    itCode: cell(row.IT_CODE),
    itemName: cell(row.IT_NAME),
    tblCode: cell(row.TBL_CODE),
    designNo: cell(row.DESIGN_NO),
    itemSize: cell(row.ITM_SIZE),
    hallmarkId: cell(row.HM_ID),
    hallmarkIdWt: cell(row.HM_ID_WT),
    karigarName: cell(row.KR_NAME),
    prCode: cell(row.PR_CODE),
    pcs: cell(row.ITM_PCS),
    grossWt: cell(row.ITM_GWT),
    othWt: cell(row.ITM_OTH_WT),
    netWt: cell(row.ITM_NWT),
    ghtPct: cell(row.ITM_GHT_PRC),
    touch: cell(row.ITM_TOUCH),
    westPct: cell(row.ITM_WEST_PRC),
    // An unrecognised basis is left to the company's, as the server's tag defaults leave it.
    lbrType: LABOUR_TYPES.has(labourType) ? labourType : '',
    lbrTypeFromCompany: !LABOUR_TYPES.has(labourType),
    lbrRate: cell(row.LBR_RATE),
    lbrAmt: cell(row.LBR_AMT),
    othAmt: cell(row.OTH_AMT),
    rate: cell(row.ITM_RATE),
    rateType: RATE_TYPES.has(rateType) ? rateType : '',
    mrp: cell(row.ITM_MRP),
    tagCost: cell(row.KR_COST),
    explicit: true,
  };
  // A BAR_DETL tag carries its fine; a web-created tag (TAG_STOCK only) has none and is computed.
  if (String(row.source ?? '') !== 'TAG_STOCK' && row.ITM_FINE != null) {
    line.storedFine = String(row.ITM_FINE);
    line.storedFineKey = fineKey(line, 'issue');
  }
  return line;
}

/** An item chosen from `/lookup/items` brings its name and rate type (TR_WH_SALE.cs:11109-11116). */
export function lineWithItem(line: VoucherLine, row: Row): VoucherLine {
  const rateType = codeOf(row.RATE_TYPE);
  return {
    ...line,
    itCode: cell(row.code ?? row.IT_CODE),
    itemName: cell(row.name ?? row.IT_NAME) || line.itemName,
    rateType: RATE_TYPES.has(rateType) ? rateType : line.rateType,
  };
}

// ────────────────────────────────────────────────────────────────────────────
// PAYLOAD (the API's RateCutLine / RateCutInput)
// ────────────────────────────────────────────────────────────────────────────

export type LinePayload = Record<string, unknown> & {
  netWt?: number;
  ghtPct?: number;
  ghtWt?: number;
  fine?: number;
  lbrType?: string;
  rateType?: string;
};

const TEXT_FIELDS = [
  'itCode',
  'itemName',
  'tblCode',
  'designNo',
  'itemSize',
  'hallmarkId',
  'karigarName',
  'prCode',
  'lotNo',
  'itemLot',
  'issueLcCode',
] as const;

/** Numbers where 0 and "not given" mean the same to the grid arithmetic. */
const NUMBER_FIELDS = [
  'pcs',
  'grossWt',
  'othWt',
  'touch',
  'westPct',
  'lessTouch',
  'lessWt',
  'hallmarkFine',
  'hallmarkIdWt',
  'convRate',
  'convPct',
  'rate',
  'lbrRate',
  'lbrAmt',
  'othAmt',
  'otherRate',
  'otherFine',
  'mrp',
  'taxPct',
  'tagCost',
  'tagGrossWt',
  'tagNetWt',
  'silverFine',
  'mcxRate',
  'adjustWt',
] as const;

/** Fields the receive grid does not have (no tags, no hallmark fine, no counter/size/hallmark id/karigar). */
const ISSUE_ONLY = new Set<string>([
  'hallmarkFine',
  'hallmarkIdWt',
  'tblCode',
  'itemSize',
  'hallmarkId',
  'karigarName',
  'tagGrossWt',
]);

/**
 * One row as the API takes it.
 *
 * - A loose row omits a blank cell (the server's derivations stand); a row from a tag or a saved voucher sends
 *   it as 0 (see `VoucherLine.explicit`).
 * - Net, ghat weight and fine are never sent blank: a blank net is gross − other, a blank ghat weight follows the
 *   ghat %, and the fine is sent only while the stored one still applies — otherwise the grid formula decides.
 * - The labour basis is omitted while it is the company's, so the server applies the same `MsLbrType`.
 */
export function linePayload(line: VoucherLine, side: 'issue' | 'receive'): LinePayload {
  const out: LinePayload = {};
  for (const field of TEXT_FIELDS) {
    if (side === 'receive' && ISSUE_ONLY.has(field)) continue;
    const value = line[field].trim();
    if (value) out[field] = value;
  }
  for (const field of NUMBER_FIELDS) {
    if (side === 'receive' && ISSUE_ONLY.has(field)) continue;
    if (filled(line[field])) out[field] = n(line[field]);
    else if (line.explicit) out[field] = 0;
  }
  if (filled(line.netWt)) out.netWt = n(line.netWt);
  if (filled(line.ghtPct)) out.ghtPct = n(line.ghtPct);
  else if (filled(line.ghtWt)) out.ghtWt = n(line.ghtWt);
  else if (line.explicit) out.ghtPct = 0;
  if (filled(line.storedFine) && line.storedFineKey === fineKey(line, side)) {
    out.fine = n(line.storedFine);
  }
  if (!line.lbrTypeFromCompany) out.lbrType = line.lbrType.trim().toUpperCase();
  if (filled(line.rateType)) out.rateType = line.rateType.trim().toUpperCase();
  if (side === 'issue') {
    const tagNo = line.tagNo.trim();
    if (tagNo && tagNo.toUpperCase() !== 'N') {
      out.tagNo = tagNo;
      if (filled(line.vchSrno) && n(line.vchSrno) !== 0) out.vchSrno = n(line.vchSrno);
    }
  }
  if ([line.issueYear, line.issueBook, line.issueNo, line.issueSrno].some(filled)) {
    out.isuRef = {
      yrcd: line.issueYear.trim() || undefined,
      dbcd: line.issueBook.trim() || undefined,
      no: line.issueNo.trim() || undefined,
      srno: filled(line.issueSrno) ? n(line.issueSrno) : undefined,
    };
  }
  return out;
}

const amount = (value: string): number | undefined => (filled(value) ? n(value) : undefined);

/** The request body for POST/PUT `/wholesale-sales` or `/rate-cut`. */
export function voucherPayload(
  state: VoucherState,
  scope: { coBook: string; coYear?: string; lcCode?: string },
): Record<string, unknown> {
  const h = state.header;
  const text = (value: string) => value.trim() || undefined;
  const tender = (t: VoucherTender) => ({
    cash: amount(t.cash),
    chq: amount(t.cheque),
    card: amount(t.card),
    kasar: amount(t.kasar),
  });
  return {
    coBook: scope.coBook,
    coYear: scope.coYear || undefined,
    lcCode: scope.lcCode || undefined,
    vchDate: h.vchDate || undefined,
    billNo: text(h.billNo),
    acCode: h.acCode.trim(),
    acName: text(h.acName),
    mobile: text(h.mobile),
    add1: text(h.add1),
    add2: text(h.add2),
    add3: text(h.add3),
    city: text(h.city),
    empCode: text(h.empCode),
    vchDesc: text(h.vchDesc),
    itType: h.itType,
    fineRate: amount(h.fineRate),
    convRate: amount(h.convRate),
    convPct: amount(h.convPct),
    settleDrAmt: amount(h.settleDrAmt),
    settleCrAmt: amount(h.settleCrAmt),
    settleDrFine: amount(h.settleDrFine),
    settleCrFine: amount(h.settleCrFine),
    lines: state.issued.filter(isActiveLine).map((line) => linePayload(line, 'issue')),
    receivedLines: state.received.filter(isActiveLine).map((line) => linePayload(line, 'receive')),
    // BANK_AC / CHQ_NO / CARD_AC are one per voucher; the server applies them to both columns.
    pay: {
      ...tender(state.receivedTender),
      bankAc: text(state.bankAc),
      chqNo: text(state.chqNo),
      cardAc: text(state.cardAc),
    },
    receivedPay: tender(state.paymentTender),
  };
}

// ────────────────────────────────────────────────────────────────────────────
// PREVIEW
// ────────────────────────────────────────────────────────────────────────────

const optional = (value: unknown): number | undefined =>
  value == null || value === '' ? undefined : Number(value);

/**
 * The grid-arithmetic input for a payload row — the mapping `computeLine` applies on the server
 * (apps/api rateCut.ts), with the company labour basis standing in for an omitted one (`withLabourBasis`).
 */
export function lineInput(payload: LinePayload, settings: WholesaleSettings): WholesaleLineInput {
  const p = payload as Record<string, unknown>;
  return {
    pcs: optional(p.pcs),
    grossWt: optional(p.grossWt),
    othWt: optional(p.othWt),
    netWt: optional(p.netWt),
    ghtPct: optional(p.ghtPct),
    ghtWt: optional(p.ghtWt),
    touch: optional(p.touch),
    westPct: optional(p.westPct),
    lessWt: optional(p.lessWt),
    hallmarkFine: optional(p.hallmarkFine),
    lessTouch: optional(p.lessTouch),
    fine: optional(p.fine),
    rate: optional(p.rate),
    rateType: p.rateType == null ? undefined : String(p.rateType),
    convRate: optional(p.convRate),
    convPct: optional(p.convPct),
    lbrType: p.lbrType == null ? settings.line.companyLabourType : String(p.lbrType),
    lbrRate: optional(p.lbrRate),
    lbrAmt: optional(p.lbrAmt),
    othAmt: optional(p.othAmt),
    otherRate: optional(p.otherRate),
    otherFine: optional(p.otherFine),
    taxPct: optional(p.taxPct),
  };
}

export interface GridPreview {
  /** Aligned with the grid's rows; null for a spare (inactive) row. */
  lines: Array<WholesaleLineResult | null>;
  totals: WholesaleGridTotals;
}

export function previewGrid(
  lines: VoucherLine[],
  side: 'issue' | 'receive',
  settings: WholesaleSettings,
): GridPreview {
  const compute = side === 'receive' ? wholesaleReceiveLine : wholesaleIssueLine;
  const results = lines.map((line) =>
    isActiveLine(line)
      ? compute(lineInput(linePayload(line, side), settings), settings.line)
      : null,
  );
  return {
    lines: results,
    totals: wholesaleGridTotals(results.filter((r): r is WholesaleLineResult => r !== null)),
  };
}

export interface VoucherPreview {
  issued: GridPreview;
  received: GridPreview;
  settlement: SettlementResult;
  band: WholesaleBand;
}

/** The whole voucher as BILL_TOTAL would show it: grid totals, the derived settlement, and the band. */
export function previewVoucher(state: VoucherState, settings: WholesaleSettings): VoucherPreview {
  const issued = previewGrid(state.issued, 'issue', settings);
  const received = previewGrid(state.received, 'receive', settings);
  const h = state.header;
  const settlement = settleMoneyMetal({
    convRate: n(h.convRate),
    convPct: n(h.convPct),
    fineRate: n(h.fineRate),
    drAmt: n(h.settleDrAmt),
    crAmt: n(h.settleCrAmt),
    drFine: n(h.settleDrFine),
    crFine: n(h.settleCrFine),
    ratePar: settings.ratePar,
  });
  const tender = (t: VoucherTender) => ({
    cash: n(t.cash),
    cheque: n(t.cheque),
    card: n(t.card),
    kasar: n(t.kasar),
  });
  const band = wholesaleBand({
    settlement,
    issued: issued.totals,
    received: received.totals,
    receivedTender: tender(state.receivedTender),
    paymentTender: tender(state.paymentTender),
  });
  return { issued, received, settlement, band };
}

// ────────────────────────────────────────────────────────────────────────────
// REOPEN (GET /wholesale-sales/:no or /rate-cut/:no)
// ────────────────────────────────────────────────────────────────────────────

export interface SavedVoucher {
  voucherNo: string;
  vchDate?: string;
  billNo?: string;
  acCode?: string;
  acName?: string;
  mobile?: string;
  add1?: string;
  add2?: string;
  add3?: string;
  city?: string;
  empCode?: string;
  vchDesc?: string;
  itType?: string;
  fineRate?: number;
  convRate?: number;
  convPct?: number;
  settleDrAmt?: number;
  settleCrAmt?: number;
  settleDrFine?: number;
  settleCrFine?: number;
  pay?: Row;
  receivedPay?: Row;
  lines?: Row[];
  receivedLines?: Row[];
}

/** A saved row back into the grid: every figure explicit, and its saved fine kept until weight or purity moves. */
export function lineFromSaved(row: Row, side: 'issue' | 'receive'): VoucherLine {
  const tag = cell(row.tagNo);
  const ref = (row.isuRef ?? {}) as Row;
  const labourType = codeOf(row.lbrType);
  const rateType = codeOf(row.rateType);
  const line: VoucherLine = {
    ...blankLine(),
    tagNo: side === 'issue' && tag.toUpperCase() !== 'N' ? tag : '',
    vchSrno: side === 'issue' && tag && tag.toUpperCase() !== 'N' ? cell(row.vchSrno) : '',
    itCode: cell(row.itCode),
    itemName: cell(row.itemName),
    tblCode: cell(row.tblCode),
    designNo: cell(row.designNo),
    itemSize: cell(row.itemSize),
    hallmarkId: cell(row.hallmarkId),
    hallmarkIdWt: cell(row.hallmarkIdWt),
    karigarName: cell(row.karigarName),
    prCode: cell(row.prCode),
    lotNo: cell(row.lotNo),
    itemLot: cell(row.itemLot),
    pcs: cell(row.pcs),
    grossWt: cell(row.grossWt),
    othWt: cell(row.othWt),
    netWt: cell(row.netWt),
    // RATE_CUT_ISU / RATE_CUT_REC keep the ghat as a weight only (desktop reopen fills col 19, :12478).
    ghtWt: cell(row.ghtWt),
    touch: cell(row.touch),
    westPct: cell(row.westPct),
    lessTouch: cell(row.lessTouch),
    lessWt: cell(row.lessWt),
    hallmarkFine: cell(row.hallmarkFine),
    convRate: cell(row.convRate),
    convPct: cell(row.convPct),
    rate: cell(row.rate),
    rateType: RATE_TYPES.has(rateType) ? rateType : '',
    lbrType: LABOUR_TYPES.has(labourType) ? labourType : '',
    lbrTypeFromCompany: false,
    lbrRate: cell(row.lbrRate),
    lbrAmt: cell(row.lbrAmt),
    othAmt: cell(row.othAmt),
    otherRate: cell(row.otherRate),
    otherFine: cell(row.otherFine),
    mrp: cell(row.mrp),
    taxPct: cell(row.taxPct),
    tagCost: cell(row.tagCost),
    tagGrossWt: cell(row.tagGrossWt),
    tagNetWt: cell(row.tagNetWt),
    silverFine: cell(row.silverFine),
    mcxRate: cell(row.mcxRate),
    adjustWt: cell(row.adjustWt),
    issueLcCode: cell(row.issueLcCode),
    issueYear: cell(ref.yrcd),
    issueBook: cell(ref.dbcd),
    issueNo: cell(ref.no),
    issueSrno: cell(ref.srno),
    storedFine: row.fine == null ? '' : String(row.fine),
    explicit: true,
  };
  line.storedFineKey = fineKey(line, side);
  return line;
}

export function voucherFromSaved(view: SavedVoucher): VoucherState {
  const text = (value: unknown) => cell(value);
  const tender = (pay: Row | undefined): VoucherTender => ({
    cheque: cell(pay?.chq),
    card: cell(pay?.card),
    cash: cell(pay?.cash),
    kasar: cell(pay?.kasar),
  });
  const issued = (view.lines ?? []).map((row) => lineFromSaved(row, 'issue'));
  const received = (view.receivedLines ?? []).map((row) => lineFromSaved(row, 'receive'));
  return {
    header: {
      vchDate: text(view.vchDate).slice(0, 10) || todayLocal(),
      billNo: text(view.billNo),
      acCode: text(view.acCode),
      acName: text(view.acName),
      mobile: text(view.mobile),
      add1: text(view.add1),
      add2: text(view.add2),
      add3: text(view.add3),
      city: text(view.city),
      empCode: text(view.empCode),
      vchDesc: text(view.vchDesc),
      itType: view.itType === 'S' ? 'S' : 'G',
      fineRate: cell(view.fineRate),
      convRate: cell(view.convRate),
      convPct: cell(view.convPct),
      settleDrAmt: cell(view.settleDrAmt),
      settleCrAmt: cell(view.settleCrAmt),
      settleDrFine: cell(view.settleDrFine),
      settleCrFine: cell(view.settleCrFine),
    },
    // A spare row after the saved ones, as the desktop grid always leaves one.
    issued: [...issued, blankLine()],
    received: [...received, blankLine()],
    receivedTender: tender(view.pay),
    paymentTender: tender(view.receivedPay),
    bankAc: text(view.pay?.bankAc),
    chqNo: text(view.pay?.chqNo),
    cardAc: text(view.pay?.cardAc),
  };
}

/** Money and fine as the desktop shows them. */
export const money = (x: number): string => round(x, 2).toFixed(2);
export const weight = (x: number): string => round(x, 3).toFixed(3);
