/**
 * Desktop replay oracle — the PURE part (no database, no network), unit-tested in
 * apps/api/test/replayDesktop.test.ts with synthetic fixtures.
 *
 * A desktop voucher is handed over as `{ family, book, mainBook, bookSname, vchNo, tables }`, where `tables` maps an
 * upper-case table name to the plain row objects the desktop wrote for that voucher (dates as ISO strings).
 *
 * The request builders turn the desktop's OWN header and line rows back into the body the web page posts. They read
 * only operator-input columns (party, date, item, weights, touch, wastage, rate, labour, tender, narration). Every
 * desktop-DERIVED column (fine, amounts, tax, totals, ledger legs, day book, stock, outstanding) is left for the web
 * to compute, because copying it would make its comparison vacuous.
 */

const str = (v) => (v == null ? '' : String(v).trim());
const num = (v) => {
  if (v == null || v === '') return 0;
  const n = Number(v);
  return Number.isFinite(n) ? n : 0;
};
/** A number only when it is non-zero, so an empty desktop cell is not sent as an explicit 0. */
const nz = (v) => (num(v) !== 0 ? num(v) : undefined);
const opt = (v) => str(v) || undefined;
const isoDay = (v) => (v == null || v === '' ? undefined : String(v).slice(0, 10));
const bySr = (a, b) => num(a.SR_NO) - num(b.SR_NO);

/** Drop undefined keys so a body looks like what JSON.stringify of the page's object produces. */
export function compact(value) {
  if (Array.isArray(value)) return value.map(compact);
  if (value && typeof value === 'object') {
    const out = {};
    for (const [k, v] of Object.entries(value)) if (v !== undefined) out[k] = compact(v);
    return out;
  }
  return value;
}

/* ---------------------------------------------------------------------------------------------- *
 * Families. `detect` uses BOOK_DATA.MAIN_BOOK exactly as the desktop's book help does
 * (DC_Main.cs:1503 `MAIN_BOOK = '<family>'`).
 * ---------------------------------------------------------------------------------------------- */

export const FAMILIES = {
  SALES: { header: 'SL_DATA', mainBooks: ['SALES'] },
  PURCHASE: { header: 'PR_DATA', mainBooks: ['PURCHASE'] },
  'CASH/BANK': {
    header: 'CASH_DATA',
    mainBooks: ['CASH REC', 'CASH PAY', 'BANK REC', 'BANK PAY'],
  },
  CONTRA: { header: 'CONTRA_DATA', mainBooks: ['CONTRA'] },
  'FINE JV': { header: 'CONTRA_DATA', mainBooks: ['FINE JV'] },
  'SALES ORDER': { header: 'SL_ORD_DATA', mainBooks: ['SALES ORDER'] },
  'WH SALES': { header: 'RATE_CUT_DATA', mainBooks: ['WH SALES'] },
  'RATE CUT': { header: 'RATE_CUT_DATA', mainBooks: ['RATE CUT'] },
};

/** Families with a request builder. The others are enumerated and reported as could-not-replay. */
export const REPLAYABLE = new Set(['SALES', 'PURCHASE', 'CASH/BANK', 'CONTRA', 'FINE JV']);

/**
 * Map a book to its family. Book 043 (`GLURD`, the gold URD purchase book) has a blank MAIN_BOOK on this database but
 * writes PR_DATA/PR_DETL linked to a sale through SL_BILL_NO; it is entered on the purchase form, so it replays as a
 * purchase.
 */
export function familyOf(book) {
  const main = str(book.MAIN_BOOK).toUpperCase();
  for (const [name, f] of Object.entries(FAMILIES)) if (f.mainBooks.includes(main)) return name;
  if (!main && /URD/i.test(str(book.BOOK_SNAME))) return 'PURCHASE';
  return null;
}

/** `--book SALES`, `--book "CASH/BANK"`, `--book 026`, comma separated; empty = every replayable family. */
export function selectBooks(books, wanted) {
  const asked = String(wanted ?? '')
    .split(',')
    .map((s) => s.trim().toUpperCase())
    .filter(Boolean);
  return books.filter((b) => {
    const fam = familyOf(b);
    if (!fam) return false;
    if (!asked.length) return true;
    return asked.includes(fam) || asked.includes(str(b.CO_BOOK).toUpperCase());
  });
}

/* ---------------------------------------------------------------------------------------------- *
 * Replay order.
 *
 * Within a book the desktop allocates MAX(VCH_NO)+1 at save (TR_SALE.cs / TR_CASH.cs `SELECT MAX(VCH_NO)`), so voucher
 * number order IS that book's entry order, even where a later voucher carries an earlier (back-dated) VCH_DATE. Across
 * books the only clock is VCH_DATE + VCH_TIME. The replay therefore merges the per-book queues, always taking the head
 * with the earliest (VCH_DATE, VCH_TIME), which is date order wherever date order is consistent with numbering.
 * ---------------------------------------------------------------------------------------------- */
export function replayOrder(vouchers) {
  const queues = new Map();
  for (const v of vouchers) {
    if (!queues.has(v.book)) queues.set(v.book, []);
    queues.get(v.book).push(v);
  }
  for (const q of queues.values()) q.sort((a, b) => num(a.vchNo) - num(b.vchNo));
  const key = (v) => `${str(v.vchDate).slice(0, 10)}|${str(v.vchTime)}|${v.book}|${v.vchNo}`;
  const out = [];
  for (;;) {
    let best = null;
    for (const q of queues.values()) {
      if (!q.length) continue;
      if (!best || key(q[0]) < key(best[0])) best = q;
    }
    if (!best) break;
    out.push(best.shift());
  }
  return out;
}

/**
 * The throwaway row needed so the web's MAX(VCH_NO)+1 (vouchers/numbering.ts nextVoucherNoTx) lands on the desktop's
 * number: the number to insert at, or null when the web's own sequence already gives it. Gaps come from vouchers the
 * desktop deleted (DELETE_DATA) or that could not be replayed. With `force` the row is placed even without a gap: the
 * driver retries that way when the web's own numbering collided, and records the collision as a finding.
 */
export function placeholderFor(wantVchNo, lastWebVchNo, force = false) {
  const want = num(wantVchNo);
  if (want <= 1) return null;
  if (!force && want <= num(lastWebVchNo) + 1) return null;
  return String(want - 1).padStart(5, '0');
}

/* ---------------------------------------------------------------------------------------------- *
 * Request builders: desktop rows -> { method, path, body } as the page sends it.
 * ---------------------------------------------------------------------------------------------- */

/**
 * The TR_CONTRA grid behind a set of CONTRA_DATA rows.
 *
 * The desktop saves grid rows 2..n each as a pair (TR_CONTRA.cs:2762-2866): first an LDR_TYPE '0' record for row i
 * (its side, account, name and description), then an LDR_TYPE '1' mirror record carrying ROW 1's side, account and
 * name with row i's amount on the opposite side. So grid row 1 is the account of the LDR_TYPE '1' records, its amount
 * is the sum of theirs, and rows 2..n are the LDR_TYPE '0' records in SR_NO order. Reading the rows in SR_NO order
 * instead would put row i first and swap every ledger key.
 */
export function contraGrid(rows, amountOf) {
  const sorted = [...rows].sort(bySr);
  const own = sorted.filter((r) => str(r.LDR_TYPE) === '0');
  const mirror = sorted.filter((r) => str(r.LDR_TYPE) === '1');
  const side = (r) => (str(r.CRDR_TYPE).toUpperCase() === 'CR' ? 'CR' : 'DR');
  if (!own.length || !mirror.length)
    return sorted.map((r) => ({ crdr: side(r), acCode: str(r.AC_CODE), r, amount: amountOf(r) }));
  const head = mirror[0];
  return [
    {
      crdr: side(head),
      acCode: str(head.AC_CODE),
      r: head,
      amount: Math.round(mirror.reduce((n, r) => n + amountOf(r), 0) * 1000) / 1000,
    },
    ...own.map((r) => ({ crdr: side(r), acCode: str(r.AC_CODE), r, amount: amountOf(r) })),
  ];
}

/** Contra Entry (TR_CONTRA grid; web page app/(app)/txn/contra/page.tsx submit()). */
export function contraRequest(v) {
  const rows = v.tables.CONTRA_DATA ?? [];
  if (!rows.length) throw new ReplayBuildError('no CONTRA_DATA rows');
  const grid = contraGrid(rows, (r) => num(r.DR_AMT) || num(r.CR_AMT));
  return {
    method: 'POST',
    path: '/contra',
    body: compact({
      coBook: v.book,
      vchDate: isoDay(rows[0].VCH_DATE),
      empCode: opt(rows[0].EMP_CODE),
      lines: grid.map((g) => ({
        crdr: g.crdr,
        acCode: g.acCode,
        acName: opt(g.r.AC_NAME)?.slice(0, 50),
        itDesc: opt(g.r.IT_DESC),
        amount: g.amount,
      })),
    }),
  };
}

/** Fine JV (TR_CONTRA with MAIN_BOOK 'FINE JV'; page app/(app)/txn/fine-jv/page.tsx). The route refuses extra keys. */
export function fineJvRequest(v) {
  const rows = v.tables.CONTRA_DATA ?? [];
  if (!rows.length) throw new ReplayBuildError('no CONTRA_DATA rows');
  const metal = str(rows[0].IT_TYPE).toUpperCase() === 'S' ? 'S' : 'G';
  const grid = contraGrid(rows, (r) => num(r.DR_FINE) || num(r.CR_FINE));
  return {
    method: 'POST',
    path: '/fine-jv',
    body: compact({
      coBook: v.book,
      vchDate: isoDay(rows[0].VCH_DATE),
      metal,
      empCode: opt(rows[0].EMP_CODE),
      lines: grid.map((g) => ({
        crdr: g.crdr,
        acCode: g.acCode,
        itDesc: opt(g.r.IT_DESC),
        fine: g.amount,
      })),
    }),
  };
}

/**
 * Cash / bank receipt or payment (TR_CASH; page components/PaymentForm.tsx). One CASH_DATA line without narration is
 * what the page's single-party mode posts; anything else is the multi-line grid, which also carries the narration.
 * The cash/bank and kasar accounts are not sent: the web resolves them from BOOK_DETL slots 1 and 2, as the desktop
 * does (Ac_Ledr.cs:565-583).
 */
export function cashRequest(v) {
  const rows = [...(v.tables.CASH_DATA ?? [])].sort(bySr);
  if (!rows.length) throw new ReplayBuildError('no CASH_DATA rows');
  const main = str(v.mainBook).toUpperCase();
  const direction = main.endsWith('REC') ? 'receipts' : main.endsWith('PAY') ? 'payments' : null;
  if (!direction) throw new ReplayBuildError(`book ${v.book} (${main}) is not a cash/bank book`);
  const chqNo = opt(rows.find((r) => str(r.CHQ_NO))?.CHQ_NO);
  const mode = main.startsWith('CASH') ? 'cash' : chqNo ? 'cheque' : 'bank';
  const head = rows[0];
  // The grid cells beyond party and amount (TR_CASH.cs:3034-3047): Remark, Charges, Clearing Dt (the voucher date
  // when empty, :3022-3029), and the Chq Ac Name and Bank Name boxes. Only a cell the operator filled is sent.
  const cells = (r) => ({
    itDesc: opt(r.IT_DESC),
    bankCharges: nz(r.BANK_CHARGES),
    clrDate: isoDay(r.CLR_DATE) !== isoDay(r.VCH_DATE) ? isoDay(r.CLR_DATE) : undefined,
    chqPrintName: opt(r.CHQ_PRINT_NAME),
    bankName: opt(r.BANK_NAME),
  });
  const grid = (r) => Boolean(str(r.IT_DESC) || nz(r.BANK_CHARGES) || cells(r).clrDate);
  const single = rows.length === 1 && !grid(head);
  if (single) {
    return {
      method: 'POST',
      path: `/${direction}`,
      body: compact({
        coBook: v.book,
        vchDate: isoDay(head.VCH_DATE),
        partyAc: str(head.AC_CODE),
        partyName: opt(head.AC_NAME),
        amount: num(head.REC_AMT),
        mode,
        chqNo,
        kasar: nz(head.KASAR_AMT),
        empCode: opt(head.EMP_CODE),
        chqPrintName: cells(head).chqPrintName,
        bankName: cells(head).bankName,
      }),
    };
  }
  return {
    method: 'POST',
    path: `/${direction}/multi`,
    body: compact({
      coBook: v.book,
      vchDate: isoDay(head.VCH_DATE),
      mode,
      chqNo,
      empCode: opt(head.EMP_CODE),
      lines: rows
        // PaymentForm keeps a row with an account and Amount + Kasar not zero (TR_CASH.cs:3014).
        .filter((r) => str(r.AC_CODE) && num(r.REC_AMT) + num(r.KASAR_AMT) !== 0)
        .map((r) => ({
          partyAc: str(r.AC_CODE),
          partyName: opt(r.AC_NAME),
          amount: num(r.REC_AMT),
          kasar: nz(r.KASAR_AMT),
          ...cells(r),
        })),
    }),
  };
}

/** LBR_TYPE 'N' with a rate is per gram; with only an amount it is a typed (fixed) amount; 'P' is a percentage. */
export function labourOf(line) {
  const type = str(line.LBR_TYPE).toUpperCase();
  if (type === 'P')
    return { labourType: 'percentage', labourRate: nz(line.LBR_PRC ?? line.LBR_RATE) };
  // The labour-amount cell is computed as Math.Round((net + ghat) x rate) (net x rate when LBR_WITH_GHT is 'N';
  // TR_SALE.cs:11084-11127) but open for typing. A stored amount that neither product rounds to was typed: it is sent
  // as the amount, with the rate the grid showed beside it, as the page posts a typed amount.
  const rate = num(line.LBR_RATE);
  const amount = num(line.LBR_AMT);
  const rounds = (weight) => Math.abs(rate * weight - amount) <= 0.5 + 1e-9;
  if (
    rate !== 0 &&
    amount !== 0 &&
    !rounds(num(line.ITM_NWT) + num(line.ITM_GHT_WT)) &&
    !rounds(num(line.ITM_NWT))
  )
    return { labourType: 'fixed', labourFixed: amount, labourRate: rate };
  if (num(line.LBR_RATE) !== 0) return { labourType: 'per_gram', labourRate: num(line.LBR_RATE) };
  if (num(line.LBR_AMT) !== 0) return { labourType: 'fixed', labourFixed: num(line.LBR_AMT) };
  return {};
}

const metalOf = (v) => {
  const t = str(v).toUpperCase();
  return t === 'G' || t === 'S' ? t : undefined;
};
const tagOf = (v) => {
  const t = str(v);
  return t && t.toUpperCase() !== 'N' ? t : undefined;
};

/**
 * Sale (TR_SALE; page app/(app)/txn/sales/page.tsx). Karigar figures of a tagged line come from the TAG (BAR_DETL),
 * as the page's tag pick fills them, never from the desktop's SL_DETL output. `ctx.tag(tagNo, vchSrno)` returns the
 * BAR_DETL row or undefined.
 */
export function saleRequest(v, ctx = {}) {
  const h = (v.tables.SL_DATA ?? [])[0];
  if (!h) throw new ReplayBuildError('no SL_DATA header');
  const lines = [...(v.tables.SL_DETL ?? [])].sort(bySr);
  if (!lines.length) throw new ReplayBuildError('sale has no SL_DETL lines');
  const orders = (v.tables.SL_ORD_ADJ ?? []).map((o) => ({
    ordNo: str(o.ORD_NO),
    amount: num(o.ORD_AMT),
    ordBook: opt(o.ORD_DBCD),
    ordYear: opt(o.ORD_YRCD),
    ordLc: opt(o.ORD_LC),
    ordAcCode: opt(o.ORD_AC_CODE),
    ordHdVchNo: opt(o.ORD_HD_VCH_NO),
  }));
  const oldGold = (v.tables.SL_PR_DETL ?? [])
    .filter((o) => v.book === str(o.CO_BOOK))
    .sort(bySr)
    .map((o) => ({
      itCode: str(o.IT_CODE) || undefined,
      metal: metalOf(o.IT_TYPE),
      description: opt(o.IT_DESC),
      pcs: num(o.ITM_PCS),
      grossWt: num(o.ITM_GWT),
      otherWt: nz(o.ITM_OTH),
      netWt: num(o.ITM_NWT),
      touch: num(o.ITM_TOUCH),
      conversionPct: nz(o.CON_PRC),
      conversionWt: nz(o.CON_WT),
      rate: num(o.ITM_RATE),
      rateType: opt(o.ITM_RATE_TYPE),
      // The page sends the old-metal row's amount cell; the desktop grid computes it the same way.
      amount: num(o.NET_AMT),
      itType: opt(o.IT_TYPE),
    }));
  const body = {
    coBook: v.book,
    coYear: opt(h.CO_YEAR),
    lcCode: opt(h.LC_CODE),
    acCode: str(h.AC_CODE),
    acName: opt(h.AC_NAME),
    vchDate: isoDay(h.VCH_DATE),
    billNo: opt(h.BILL_NO),
    taxCode: opt(h.TAX_CODE),
    taxRatePct: num(h.TAX_PRC),
    interState: str(h.AC_GST_TYPE).toUpperCase() === 'I',
    rateUnfix: str(h.RATE_UNFIX).toUpperCase() === 'Y' || undefined,
    kasarAmount: nz(h.KASAR_AMT),
    crDays: nz(h.CR_DAYS),
    empCode: opt(h.EMP_CODE),
    bankAc: num(h.CHQ_AMT) ? opt(h.BANK_AC) : undefined,
    cashPaid: nz(h.CASH_PAID),
    mobile: opt(h.MOBILE),
    description: opt(h.VCH_DESC),
    cashAmt: nz(h.CASH_AMT),
    chequeAmt: nz(h.CHQ_AMT),
    orders: orders.length ? orders : undefined,
    oldGold: oldGold.length ? oldGold : undefined,
    lines: lines.map((l) => {
      const tagNo = tagOf(l.TAG_NO);
      const tag = tagNo && ctx.tag ? ctx.tag(tagNo, l.VCH_SRNO) : undefined;
      return {
        itCode: str(l.IT_CODE),
        tagNo,
        vchSrno: tagNo ? nz(l.VCH_SRNO) : undefined,
        pcs: num(l.ITM_PCS),
        grossWt: num(l.ITM_GWT),
        netWt: num(l.ITM_NWT),
        lessWt: nz(l.ITM_OTH_WT),
        touch: num(l.ITM_TOUCH),
        westPct: nz(l.ITM_WEST_PRC),
        ghtWt: nz(l.ITM_GHT_WT),
        rate: num(l.ITM_RATE),
        metal: metalOf(l.IT_TYPE),
        designNo: opt(l.DESIGN_NO),
        itmSize: opt(l.ITM_SIZE),
        tblCode: opt(l.TBL_CODE),
        remark: opt(l.ITM_REMARK),
        otherAmount: nz(l.OTH_AMT),
        // The line's own Tax% cell, typed on the desktop grid (TR_SALE.cs:11588, saved at :15437).
        taxPct: nz(l.TAX_PRC),
        rateType: opt(l.RATE_TYPE),
        rateWith: opt(l.RATE_WITH),
        prCode: opt(l.PR_CODE),
        employeeCode: opt(l.EMP_CODE),
        huid: opt(l.HM_ID),
        hallmarkId2: opt(l.HM_ID2),
        hallmarkId3: opt(l.HM_ID3),
        hallmarkId4: opt(l.HM_ID4),
        hallmarkIdWt: nz(l.HM_ID_WT),
        hallmarkId2Wt: nz(l.HM_ID2_WT),
        hallmarkId3Wt: nz(l.HM_ID3_WT),
        hallmarkId4Wt: nz(l.HM_ID4_WT),
        tagGrossWt: tag ? nz(tag.ITM_GWT) : undefined,
        tagNetWt: tag ? nz(tag.ITM_NWT) : undefined,
        karigarNetWt: tag ? nz(tag.KR_NET_WT) : undefined,
        karigarTouch: tag ? nz(tag.KR_TOUCH) : undefined,
        karigarWestPct: tag ? nz(tag.KR_WEST_PRC) : undefined,
        karigarFine: tag ? nz(tag.KR_FINE) : undefined,
        karigarName: tag ? opt(tag.KR_NAME) : undefined,
        ...labourOf(l),
      };
    }),
  };
  return { method: 'POST', path: '/sales', body: compact(body) };
}

/** Purchase (TR_PURC; page app/(app)/txn/purchase/page.tsx). The URD book links to the sale it settles. */
/** One PR_IDTL row back to the purchase page's stone sub-grid cells (purchase.ts PurchaseStoneInput). */
export function purchaseStone(r) {
  return {
    isrNo: nz(r.ISR_NO),
    itCode: opt(r.IT_CODE),
    dmCode: opt(r.DM_CODE),
    dmName: opt(r.DM_NAME),
    dmColor: opt(r.DM_COLOR),
    dmSize: opt(r.DM_SIZE),
    dmOrigin: opt(r.DM_ORIGIN),
    dmRemark: opt(r.DM_REMARK),
    dmSfNo: opt(r.DM_SFNO),
    pcs: nz(r.IT_PCS),
    grossWt: nz(r.IT_GWT),
    conPct: nz(r.IT_CON_PRC),
    rateType: opt(r.IT_RATE_TYPE),
    rate: nz(r.IT_RATE),
    amount: nz(r.IT_AMT),
    lbrRate: nz(r.IT_LBR_RATE),
    lbrAmount: nz(r.IT_LBR_AMT),
    netAmount: nz(r.IT_NET_AMT),
    conWt: nz(r.IT_CON_WT),
    itType: opt(r.IT_TYPE),
  };
}

export function purchaseRequest(v) {
  const h = (v.tables.PR_DATA ?? [])[0];
  if (!h) throw new ReplayBuildError('no PR_DATA header');
  const lines = [...(v.tables.PR_DETL ?? [])].sort(bySr);
  if (!lines.length) throw new ReplayBuildError('purchase has no PR_DETL lines');
  const body = {
    coBook: v.book,
    coYear: opt(h.CO_YEAR),
    lcCode: opt(h.LC_CODE),
    acCode: str(h.AC_CODE),
    acName: opt(h.AC_NAME),
    vchDate: isoDay(h.VCH_DATE),
    billNo: opt(h.BILL_NO),
    taxCode: opt(h.TAX_CODE),
    taxRatePct: num(h.TAX_PRC),
    interState: str(h.AC_GST_TYPE).toUpperCase() === 'I',
    urd: /URD/i.test(str(v.bookSname)) || undefined,
    rateUnfix: str(h.RATE_UNFIX).toUpperCase() === 'Y' || undefined,
    tcsCode: opt(h.TCS_CODE),
    tcsPct: nz(h.TCS_PRC),
    empCode: opt(h.EMP_CODE),
    vchDesc: opt(h.VCH_DESC),
    saleBillNo: opt(h.SL_BILL_NO),
    saleBillLc: str(h.SL_BILL_NO) ? opt(h.SL_BILL_LC) : undefined,
    saleBillYear: str(h.SL_BILL_NO) ? opt(h.SL_BILL_YRCD) : undefined,
    saleBillBook: opt(h.SL_BILL_DBCD),
    cashAmt: nz(h.CASH_AMT),
    chequeAmt: nz(h.CHQ_AMT),
    bankAc: num(h.CHQ_AMT) ? opt(h.BANK_AC) : undefined,
    kasar: nz(h.KASAR_AMT),
    lines: lines.map((l) => ({
      itCode: str(l.IT_CODE),
      metal: metalOf(l.IT_TYPE),
      itDesc: opt(l.IT_DESC),
      tagNo: tagOf(l.TAG_NO),
      pcs: num(l.ITM_PCS),
      grossWt: num(l.ITM_GWT),
      lessWt: nz(l.ITM_OTH_WT),
      netWt: num(l.ITM_NWT),
      touch: num(l.ITM_TOUCH),
      westPct: nz(l.ITM_WEST_PRC),
      ghtWt: nz(l.ITM_GHT_WT),
      rate: num(l.ITM_RATE),
      otherAmount: nz(l.OTH_AMT),
      withStock: opt(l.WITH_STOCK),
      rateType: opt(l.RATE_TYPE),
      urdRateType: opt(l.URD_RATE_TYPE),
      prCode: opt(l.PR_CODE),
      tblCode: opt(l.TBL_CODE),
      designNo: opt(l.DESIGN_NO),
      lotNo: opt(l.LOT_NO),
      // The stone sub-grid the operator filled for this line (PR_IDTL keyed by the line's SR_NO).
      stones: (() => {
        const rows = (v.tables.PR_IDTL ?? []).filter((s) => num(s.SR_NO) === num(l.SR_NO));
        return rows.length
          ? rows.sort((a, b) => num(a.ISR_NO) - num(b.ISR_NO)).map(purchaseStone)
          : undefined;
      })(),
      ...labourOf(l),
    })),
  };
  return { method: 'POST', path: '/purchases', body: compact(body) };
}

export class ReplayBuildError extends Error {
  constructor(message) {
    super(message);
    this.name = 'ReplayBuildError';
  }
}

/** The request for one desktop voucher, or a ReplayBuildError naming why it cannot be rebuilt. */
export function buildRequest(v, ctx) {
  switch (v.family) {
    case 'CONTRA':
      return contraRequest(v);
    case 'FINE JV':
      return fineJvRequest(v);
    case 'CASH/BANK':
      return cashRequest(v);
    case 'SALES':
      return saleRequest(v, ctx);
    case 'PURCHASE':
      return purchaseRequest(v);
    default:
      throw new ReplayBuildError(`no request builder for the ${v.family} family yet`);
  }
}

/* ---------------------------------------------------------------------------------------------- *
 * Normalisation — only what CANNOT agree by construction. Everything else is compared.
 *
 * bundleDiff already excludes tenant_id, row_id, the voucher-number trail, VCH_TIME, ENTRY_TIME, MAIN_USER and
 * USER_UPDATE (modules/parity/bundle.ts EXCLUDED_FIELDS). On top of that:
 * ---------------------------------------------------------------------------------------------- */

/** Tables dropped from both sides, each with the reason. */
export const DROP_TABLES = {
  DELETE_DATA:
    'audit of an earlier desktop delete of the same book/number (desktop history, not written by a create)',
  OP_LDR:
    'year-opening ledger snapshot; (CO_BOOK, VCH_NO) does not identify a voucher (parity-extract-mssql.mjs)',
};

/** Columns dropped from both sides: wall clock and operator identity, which differ between two sessions. */
export function isDroppedColumn(name) {
  const n = String(name).toUpperCase();
  return (
    /_TIME$/.test(n) ||
    n === 'ADD_USER' ||
    n === 'DELETE_USER' ||
    n === 'TENANT_ID' ||
    n === 'ROW_ID' ||
    // A copy of the voucher's own hidden number (HD_VCH_NO), which bundle.ts excludes as independently allocated.
    n === 'BILL_HD_VCH_NO'
  );
}

/**
 * Normalise one bundle case in place-free style. `desktopTables` is the set of table names in the DESKTOP schema: a
 * table only the web schema has (audit, idempotency, version tables) is a web addition and cannot be a parity failure,
 * while a desktop table the web wrote and the desktop did not stays as a genuine extra write.
 */
export function normaliseCase(c, desktopTables) {
  const tables = {};
  for (const [name, t] of Object.entries(c.tables)) {
    const upper = name.toUpperCase();
    if (DROP_TABLES[upper]) continue;
    if (desktopTables && !desktopTables.has(upper)) continue;
    const keep = t.columns.map((col, i) => [col, i]).filter(([col]) => !isDroppedColumn(col.name));
    tables[upper] = {
      columns: keep.map(([col]) => col),
      rows: t.rows.map((r) => keep.map(([, i]) => r[i])),
    };
  }
  return { ...c, tables };
}

/* ---------------------------------------------------------------------------------------------- *
 * Reporting helpers.
 * ---------------------------------------------------------------------------------------------- */

/** Personal / free-text columns whose VALUES must not appear in a report. Codes and numbers stay readable. */
const PERSONAL =
  /(NAME|ADD\d|ADDRESS|MOBILE|PHONE|PAN|GST_NO|GSTIN|EMAIL|CITY|AREA|REMARK|DESC|NARR|IT_NAME|CHQ_PRINT|ADHAR|AADHAR)/i;
const NOT_PERSONAL = /^(BOOK_NAME|TAX_NAME|LDR_NAME_TYPE)$/i;

export function maskValue(column, value) {
  const v = value == null ? '(null)' : String(value);
  if (PERSONAL.test(column) && !NOT_PERSONAL.test(column)) {
    if (v === '' || v === '(null)') return v;
    return `<text ${v.length}ch>`;
  }
  return v;
}

/**
 * Group the field differences of a diff report so identical defects read as one line:
 * key = family | table | column | kind, with a count of cases and up to three masked examples.
 */
export function groupDifferences(report, familyOfCase) {
  const groups = new Map();
  const add = (fam, table, column, kind, caseId, example) => {
    const key = `${fam}|${table}|${column}|${kind}`;
    const g = groups.get(key) ?? {
      family: fam,
      table,
      column,
      kind,
      cases: new Set(),
      examples: [],
    };
    g.cases.add(caseId);
    if (example && g.examples.length < 3) g.examples.push({ caseId, ...example });
    groups.set(key, g);
  };
  for (const c of report.cases) {
    const fam = familyOfCase(c.caseId);
    for (const t of c.tables) {
      if (t.presentOn === 'desktop-only')
        add(fam, t.table, '*', 'table-not-written-by-web', c.caseId);
      else if (t.presentOn === 'web-only')
        add(fam, t.table, '*', 'table-written-only-by-web', c.caseId);
      else {
        if (t.desktopRows !== t.webRows)
          add(fam, t.table, '*', 'row-count', c.caseId, {
            desktop: String(t.desktopRows),
            web: String(t.webRows),
          });
        else if (t.missingRows.length || t.extraRows.length)
          add(fam, t.table, '*', 'rows-unpaired', c.caseId);
        for (const col of t.missingColumns)
          add(fam, t.table, col, 'column-missing-in-web', c.caseId);
        for (const d of t.differences)
          add(fam, t.table, d.column, 'value', c.caseId, {
            rowKey: d.rowKey.startsWith('content:') ? '(content key)' : maskValue('key', d.rowKey),
            desktop: maskValue(d.column, d.desktop),
            web: maskValue(d.column, d.web),
          });
      }
    }
  }
  return [...groups.values()]
    .map((g) => ({ ...g, cases: g.cases.size }))
    .sort((a, b) => b.cases - a.cases || a.table.localeCompare(b.table));
}

/** Per-family tallies from the replay log and the diff. */
export function familyTallies(results, report) {
  const byCase = new Map(report.cases.map((c) => [c.caseId, c]));
  const out = {};
  for (const r of results) {
    const f = (out[r.family] ??= {
      vouchers: 0,
      replayed: 0,
      matched: 0,
      differed: 0,
      couldNotReplay: 0,
      reasons: {},
    });
    f.vouchers += 1;
    if (r.status !== 'REPLAYED') {
      f.couldNotReplay += 1;
      const reason = shortReason(r.reason);
      f.reasons[reason] = (f.reasons[reason] ?? 0) + 1;
      continue;
    }
    f.replayed += 1;
    const d = byCase.get(r.caseId);
    if (d?.matched) f.matched += 1;
    else f.differed += 1;
  }
  return out;
}

/** A refusal message reduced to its shape, so the same refusal on many vouchers groups together. */
export function shortReason(reason) {
  return String(reason ?? 'unknown')
    .replace(/\b\d{5}\b/g, '#####')
    .replace(/\b0\d{4,}\b/g, '<code>')
    .replace(/\d+(\.\d+)?/g, 'N')
    .slice(0, 160);
}
