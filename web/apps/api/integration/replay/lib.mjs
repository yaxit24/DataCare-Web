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
export const REPLAYABLE = new Set([
  'SALES',
  'PURCHASE',
  'CASH/BANK',
  'CONTRA',
  'FINE JV',
  'SALES ORDER',
  'WH SALES',
]);

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
  // The labour-amount cell is typed over the rate x weight product on the desktop grid; when the stored amount is
  // not rate x net weight to the rupee, the operator typed the amount, and that amount is the input.
  const perGram = num(line.LBR_RATE) * num(line.ITM_NWT);
  if (
    num(line.LBR_RATE) !== 0 &&
    num(line.LBR_AMT) !== 0 &&
    Math.abs(perGram - num(line.LBR_AMT)) > 1
  )
    return { labourType: 'fixed', labourFixed: num(line.LBR_AMT) };
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

/** One SL_ORD_IDTL row back to the order page's component sub-grid (salesOrder.ts OrderComponent). */
export function orderComponent(r) {
  return {
    isrNo: nz(r.ISR_NO),
    itCode: str(r.IT_CODE),
    itType: opt(r.IT_TYPE),
    pcs: nz(r.IT_PCS),
    grossWt: nz(r.IT_GWT),
    amount: nz(r.IT_AMT),
    netAmount: nz(r.IT_NET_AMT),
    dmCode: opt(r.DM_CODE),
    dmName: opt(r.DM_NAME),
    dmSize: opt(r.DM_SIZE),
    dmSfNo: opt(r.DM_SFNO),
    dmColor: opt(r.DM_COLOR),
    dmOrigin: opt(r.DM_ORIGIN),
    dmRemark: opt(r.DM_REMARK),
    dmLeb: opt(r.DM_LEB),
    pcsWt: nz(r.IT_PCS_WT),
    conPct: nz(r.IT_CON_PRC),
    conWt: nz(r.IT_CON_WT),
    rateType: opt(r.IT_RATE_TYPE),
    rate: nz(r.IT_RATE),
    labourRate: nz(r.IT_LBR_RATE),
    labourAmount: nz(r.IT_LBR_AMT),
    karigarWt: nz(r.KR_WT),
    karigarLessPct: nz(r.KR_LESS_PRC),
    karigarConPct: nz(r.KR_CON_PRC),
    karigarConWt: nz(r.KR_CON_WT),
    karigarRate: nz(r.KR_RATE),
    karigarAmount: nz(r.KR_AMT),
    karigarLabourRate: nz(r.KR_LBR_RATE),
    karigarLabourAmount: nz(r.KR_LBR_AMT),
    karigarNetAmount: nz(r.KR_NET_AMT),
  };
}

/**
 * One SL_PR_DETL row of an order back to the old-metal grid MSG_OLD (salesOrderOldMetal.ts orderOldMetalOf). The fine
 * is a typed cell only without a touch (CommPassTotal_Old, TR_SALE_ORD.cs:4455-4472) and the amount only when the
 * rate does not give it (:4474-4503).
 */
export function orderOldMetal(r) {
  const net = Math.round((num(r.ITM_GWT) - num(r.ITM_OTH)) * 1000) / 1000;
  const fine = num(r.ITM_FINE);
  const rateType = str(r.ITM_RATE_TYPE).toUpperCase() === 'N' ? 'N' : 'F';
  const basis = rateType === 'N' ? net : fine;
  const rate = num(r.ITM_RATE);
  const amount = num(r.NET_AMT);
  const product = basis * rate;
  // Math.Round half to even: an exact .5 product may land either way, so both neighbours count as the formula.
  const formula = Math.abs(product - amount) <= 0.5 + 1e-9;
  return {
    itCode: str(r.IT_CODE),
    pcs: nz(r.ITM_PCS),
    grossWt: num(r.ITM_GWT),
    otherWt: nz(r.ITM_OTH),
    touch: nz(r.ITM_TOUCH),
    fine: num(r.ITM_TOUCH) ? undefined : nz(fine),
    rateType,
    rate: nz(rate),
    netAmt: rate && formula ? undefined : nz(amount),
  };
}

/**
 * Sales order (TR_SALE_ORD; page app/(app)/txn/sales-order/page.tsx, lib/salesOrderForm.ts salesOrderPayload). The
 * header carries the tender grid MSG2_TOTAL (cash [3,3], cheque [4,3] with bank and number, card [5,3], scheme [8,3]),
 * the old-metal grid (SL_PR_DETL) and the delivery and function dates; each line carries the grid cells TR_SALE_ORD
 * saves at :9205-9305, the labour amount only when it was typed over the rate, and its stone components.
 */
export function salesOrderRequest(v) {
  const h = (v.tables.SL_ORD_DATA ?? [])[0];
  if (!h) throw new ReplayBuildError('no SL_ORD_DATA header');
  const lines = [...(v.tables.SL_ORD_DETL ?? [])].sort(bySr);
  const comps = v.tables.SL_ORD_IDTL ?? [];
  const old = [...(v.tables.SL_PR_DETL ?? [])].filter((o) => v.book === str(o.CO_BOOK)).sort(bySr);
  const upi = [...(v.tables.UPI_DATA ?? [])].sort(bySr);
  if (num(h.UPI_AMT) && !upi.length) throw new ReplayBuildError('UPI_AMT without UPI_DATA rows');
  if (num(h.RCUT_RATE)) throw new ReplayBuildError('rate-cut advance (RCUT_RATE) not rebuilt yet');
  const delDate = isoDay(h.DEL_DATE);
  const body = {
    coBook: v.book,
    coYear: opt(h.CO_YEAR),
    lcCode: opt(h.LC_CODE),
    acCode: str(h.AC_CODE),
    acName: opt(h.AC_NAME),
    vchDate: isoDay(h.VCH_DATE),
    // The bill number defaults to the voucher number; a different one was typed.
    billNo: str(h.BILL_NO) && str(h.BILL_NO) !== str(v.vchNo) ? str(h.BILL_NO) : undefined,
    taxCode: opt(h.TAX_CODE),
    taxRatePct: num(h.TAX_PRC),
    vchDesc: opt(h.VCH_DESC),
    empCode: opt(h.EMP_CODE),
    mobile: opt(h.MOBILE),
    address1: opt(h.ADD1),
    address2: opt(h.ADD2),
    address3: opt(h.ADD3),
    city: opt(h.CITY),
    deliveryDate: delDate,
    functionDate: isoDay(h.FUN_DATE),
    advanceAmount: num(h.CASH_AMT),
    chequeAmount: nz(h.CHQ_AMT),
    bankAc: num(h.CHQ_AMT) ? opt(h.BANK_AC) : undefined,
    chequeNo: num(h.CHQ_AMT) ? opt(h.CHQ_NO) : undefined,
    bankName: opt(h.BANK_NAME),
    cardAmount: nz(h.CARD_AMT),
    cardAc: num(h.CARD_AMT) ? opt(h.CARD_AC) : undefined,
    cardAdj: opt(h.CARD_ADJ),
    schemeAmount: nz(h.SCHM_AMT),
    adjustGold: nz(h.ADJ_GOLD),
    adjustSilver: nz(h.ADJ_SILVER),
    orderAdjustAmount: nz(h.ORD_ADJ_AMT),
    upiRows: upi.length
      ? upi.map((u) => ({
          upiAc: str(u.UPI_AC_CODE),
          upiType: str(u.UPI_TYPE),
          upiId: str(u.UPI_ID),
          amount: num(u.UPI_AMT),
        }))
      : undefined,
    oldMetalRows: old.length ? old.map(orderOldMetal) : undefined,
    // An order without grid lines is saved on its typed amount (salesOrder.ts `input.netAmount`).
    netAmount: lines.length ? undefined : nz(h.NET_AMT),
    lines: lines.map((l) => {
      const labour = labourOf(l);
      const tagNo = tagOf(l.TAG_NO);
      const lineDel = isoDay(l.ORD_DEL_DATE);
      return {
        srNo: nz(l.SR_NO),
        oldSrNo: num(l.OLD_SRNO) !== num(l.SR_NO) ? nz(l.OLD_SRNO) : undefined,
        itCode: str(l.IT_CODE),
        tagNo,
        vchSrno: tagNo ? nz(l.VCH_SRNO) : undefined,
        designNo: opt(l.DESIGN_NO),
        tblCode: opt(l.TBL_CODE),
        itmColor: opt(l.ITM_COLOR),
        itmSize: opt(l.ITM_SIZE),
        bagWt: nz(l.BAG_WT),
        pcs: num(l.ITM_PCS),
        grossWt: num(l.ITM_GWT),
        lessWt: nz(l.ITM_OTH_WT),
        netWt: num(l.ITM_NWT),
        ghtPct: nz(l.ITM_GHT_PRC),
        ghtWt: nz(l.ITM_GHT_WT),
        touch: num(l.ITM_TOUCH),
        westPct: nz(l.ITM_WEST_PRC),
        rate: num(l.ITM_RATE),
        rateFix: opt(l.RATE_FIX),
        labourType: opt(l.LBR_TYPE),
        labourPct: nz(l.LBR_PRC),
        labourRate: nz(l.LBR_RATE),
        // The amount cell is typed only where it is not the rate x weight product (labourOf).
        labourAmount: labour.labourType === 'fixed' ? labour.labourFixed : undefined,
        otherAmount: nz(l.OTH_AMT),
        mrp: nz(l.ITM_MRP),
        remark: opt(l.ITM_REMARK),
        // A line delivery date equal to the header's is the default the grid copies (:9285-9290).
        orderDeliveryDate: lineDel && lineDel !== delDate ? lineDel : undefined,
        karigarNetWt: nz(l.KR_NET_WT),
        karigarTouch: nz(l.KR_TOUCH),
        karigarWestPct: nz(l.KR_WEST_PRC),
        karigarFine: nz(l.KR_FINE),
        karigarName: opt(l.KR_NAME),
        tagCost: nz(l.TAG_COST),
        rateType: opt(l.RATE_TYPE),
        itType: opt(l.IT_TYPE),
        prCode: opt(l.PR_CODE),
        oldTblCode: opt(l.OLD_TBL_CODE),
        tagStockLess: str(l.TAG_STK_LESS) === 'Y' ? 'Y' : undefined,
        huid: opt(l.HM_ID),
        hallmarkId2: opt(l.HM_ID2),
        hallmarkId3: opt(l.HM_ID3),
        hallmarkId4: opt(l.HM_ID4),
        hallmarkIdWt: nz(l.HM_ID_WT),
        hallmarkId2Wt: nz(l.HM_ID2_WT),
        hallmarkId3Wt: nz(l.HM_ID3_WT),
        hallmarkId4Wt: nz(l.HM_ID4_WT),
        // The route requires the component array on every line (txn.ts completeSalesOrderInput).
        components: comps
          .filter((c) => num(c.SR_NO) === num(l.SR_NO))
          .sort((a, b) => num(a.ISR_NO) - num(b.ISR_NO))
          .map(orderComponent),
      };
    }),
  };
  return { method: 'POST', path: '/sales-orders', body: compact(body) };
}

/**
 * One RATE_CUT_ISU (issue) or RATE_CUT_REC (receive) row back to the TR_WH_SALE grid row the page posts
 * (web lib/wholesaleVoucher.ts linePayload). The grid derives net (gross - other), the tag weights (the line's own
 * gross and net), fine, amounts and the karigar columns; a stored value is sent only where it is not that formula.
 */
export function wholesaleLine(r, side) {
  const net = Math.round((num(r.ITM_GWT) - num(r.ITM_OTH_WT)) * 1000) / 1000;
  const tagNo = side === 'issue' ? tagOf(r.TAG_NO) : undefined;
  const rate = num(r.LBR_RATE);
  return {
    itCode: str(r.IT_CODE),
    itemName: opt(r.ITM_REMARK),
    tagNo,
    vchSrno: tagNo ? nz(r.VCH_SRNO) : undefined,
    tblCode: side === 'issue' ? opt(r.TBL_CODE) : undefined,
    designNo: opt(r.DESIGN_NO),
    itemSize: side === 'issue' ? opt(r.ITM_SIZE) : undefined,
    hallmarkId: side === 'issue' ? opt(r.HM_ID) : undefined,
    hallmarkIdWt: side === 'issue' ? nz(r.HM_ID_WT) : undefined,
    karigarName: side === 'issue' ? opt(r.KR_NAME) : undefined,
    prCode: opt(r.PR_CODE),
    lotNo: opt(r.LOT_NO),
    itemLot: opt(r.ITM_LOT),
    pcs: nz(r.ITM_PCS),
    grossWt: num(r.ITM_GWT),
    othWt: nz(r.ITM_OTH_WT),
    netWt: Math.abs(num(r.ITM_NWT) - net) > 1e-9 ? num(r.ITM_NWT) : undefined,
    ghtWt: nz(r.ITM_GHT_WT),
    touch: nz(r.ITM_TOUCH),
    westPct: nz(r.ITM_WEST_PRC),
    lessTouch: nz(r.LESS_TOUCH),
    lessWt: nz(r.LESS_WT),
    hallmarkFine: side === 'issue' ? nz(r.HM_FINE) : undefined,
    convRate: nz(r.CONV_RATE),
    convPct: nz(r.CONV_PRC),
    rate: nz(r.ITM_RATE),
    rateType: opt(r.RATE_TYPE),
    // The Lbr Type cell starts as the company basis (CommPassAdd, TR_WH_SALE.cs:8362) and can be cleared; a stored
    // blank is what the operator left, so the cell is always sent (the page sends it once it is not the company's).
    lbrType: str(r.LBR_TYPE).toUpperCase(),
    lbrRate: nz(rate),
    // With a rate the grid computes the labour amount (rateCut.ts RateCutLine.lbrRate); without one it is typed.
    lbrAmt: rate ? undefined : nz(r.LBR_AMT),
    othAmt: nz(r.OTH_AMT),
    otherRate: nz(r.ITM_OTH_RATE),
    otherFine: nz(r.ITM_OTH_FINE),
    mrp: nz(r.ITM_MRP),
    taxPct: nz(r.TAX_PRC),
    tagCost: nz(r.TAG_COST),
    tagGrossWt: side === 'issue' && num(r.TAG_GWT) !== num(r.ITM_GWT) ? num(r.TAG_GWT) : undefined,
    tagNetWt: num(r.TAG_NWT) !== num(r.ITM_NWT) ? num(r.TAG_NWT) : undefined,
    silverFine: nz(r.SILVER_FINE),
    adjustWt: nz(r.ADJ_WT),
    isuRef: str(r.ISU_NO)
      ? {
          yrcd: opt(r.ISU_YRCD),
          dbcd: opt(r.ISU_DBCD),
          no: opt(r.ISU_NO),
          srno: nz(r.ISU_SRNO),
        }
      : undefined,
  };
}

/**
 * Wholesale sale (TR_WH_SALE on a WH SALES book; page app/(app)/txn/wholesale-sale/page.tsx through
 * components/WholesaleVoucherForm.tsx and lib/wholesaleVoucher.ts voucherPayload). The settlement boxes of BILL_TOTAL
 * are sent as the operator fills them: the fine rate, the fine cut (DR_FINE / CR_FINE) and the fine kasar; the money
 * legs follow from them.
 */
export function wholesaleSaleRequest(v) {
  const h = (v.tables.RATE_CUT_DATA ?? [])[0];
  if (!h) throw new ReplayBuildError('no RATE_CUT_DATA header');
  const issued = [...(v.tables.RATE_CUT_ISU ?? [])].sort(bySr);
  const received = [...(v.tables.RATE_CUT_REC ?? [])].sort(bySr);
  const tender = (p) => ({
    cash: nz(h[`${p}_CASH_AMT`]),
    chq: nz(h[`${p}_CHQ_AMT`]),
    card: nz(h[`${p}_CARD_AMT`]),
    kasar: nz(h[`${p}_KASAR_AMT`]),
  });
  const body = {
    coBook: v.book,
    coYear: opt(h.CO_YEAR),
    lcCode: opt(h.LC_CODE),
    vchDate: isoDay(h.VCH_DATE),
    billNo: str(h.BILL_NO) && str(h.BILL_NO) !== str(v.vchNo) ? str(h.BILL_NO) : undefined,
    acCode: str(h.AC_CODE),
    acName: opt(h.AC_NAME),
    mobile: opt(h.MOBILE),
    add1: opt(h.ADD1),
    add2: opt(h.ADD2),
    add3: opt(h.ADD3),
    city: opt(h.CITY),
    bankName: opt(h.BANK_NAME),
    empCode: opt(h.EMP_CODE),
    vchDesc: opt(h.VCH_DESC),
    itType: str(h.IT_TYPE).toUpperCase() === 'S' ? 'S' : 'G',
    fineRate: nz(h.FINE_RATE),
    convRate: nz(h.CONV_RATE),
    convPct: nz(h.CONV_PRC),
    settleDrFine: nz(h.DR_FINE),
    settleCrFine: nz(h.CR_FINE),
    ksrFineDr: nz(h.KSR_FINE_DR),
    ksrFineCr: nz(h.KSR_FINE_CR),
    lines: issued.map((r) => wholesaleLine(r, 'issue')),
    receivedLines: received.map((r) => wholesaleLine(r, 'receive')),
    pay: {
      ...tender('SL'),
      bankAc: opt(h.BANK_AC),
      chqNo: opt(h.CHQ_NO),
      cardAc: opt(h.CARD_AC),
    },
    receivedPay: tender('PR'),
  };
  return { method: 'POST', path: '/wholesale-sales', body: compact(body) };
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
    case 'SALES ORDER':
      return salesOrderRequest(v);
    case 'WH SALES':
      return wholesaleSaleRequest(v);
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
  FINE_DATA:
    'scheme ledger staging: the scheme module deletes and rebuilds it for the whole company (Module_Schm.cs:138, ' +
    ':963) and no voucher save writes it',
  RATE_CUT_ISU_REC:
    'Wh Sales print scratch: BtnPrint_Click empties it for the company and refills it with the printed voucher ' +
    '(TR_WH_SALE.cs:13682-13722), so it holds whichever voucher was printed last, not what a save wrote',
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
 * Desktop columns a LATER voucher or utility rewrites after the save: the replayed save writes the save-time value,
 * so the desktop side is compared at that value. Each entry names the save and the later writer.
 */
export const LATER_UPDATES = {
  SL_ORD_DETL: {
    ORD_REC_AMT: {
      saved: 0,
      note: 'the order save writes 0 (TR_SALE_ORD.cs:9306); the scheme/receipt roll-up rewrites it (BtmSchm.cs:3210-3212)',
    },
  },
};

/**
 * Normalise one bundle case in place-free style. `desktopTables` is the set of table names in the DESKTOP schema: a
 * table only the web schema has (audit, idempotency, version tables) is a web addition and cannot be a parity failure,
 * while a desktop table the web wrote and the desktop did not stays as a genuine extra write.
 */
export function normaliseCase(c, desktopTables, side) {
  const tables = {};
  for (const [name, t] of Object.entries(c.tables)) {
    const upper = name.toUpperCase();
    if (DROP_TABLES[upper]) continue;
    if (desktopTables && !desktopTables.has(upper)) continue;
    const keep = t.columns.map((col, i) => [col, i]).filter(([col]) => !isDroppedColumn(col.name));
    const later = side === 'desktop' ? (LATER_UPDATES[upper] ?? {}) : {};
    tables[upper] = {
      columns: keep.map(([col]) => col),
      rows: t.rows.map((r) =>
        keep.map(([col, i]) =>
          later[String(col.name).toUpperCase()]
            ? later[String(col.name).toUpperCase()].saved
            : r[i],
        ),
      ),
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
 * Differences the replay is EXPECTED to report because the web follows the current desktop source while the replayed
 * year was written by an older build (owner decision: copy the current DataCareNext source). They are grouped apart
 * in the report as "desktop build difference" rather than as defects. A row whose key holds the code (AC_DATA
 * LEDR_KEY, MAIN_STOCK SR_NO) cannot pair, so those tables' unpaired rows and row counts are listed here too; a real
 * defect in the same table still shows in its column-level value differences.
 */
export const KNOWN_BUILD_DIFFERENCES = [
  {
    family: 'SALES',
    table: 'AC_DATA',
    note:
      'sale LEDR_KEY codes: data 01/03/04/02, bank 09/10, cash 19/20, kasar 25/26; source (Ac_Ledr.cs:61-172) ' +
      '01/08/09/STR+07, cheque 15/16, card 17/18, cash 25/26, kasar 31/32, discount 33/34, old metal STR+23/24, ' +
      'UPI 36/37+STR',
  },
  {
    family: 'SALES',
    table: 'MAIN_STOCK',
    note: 'sale stock section SR_NO: data 1/2, source 3/4 (Ac_Stock.cs:114, :116)',
  },
  {
    family: 'SALES ORDER',
    table: 'SL_ORD_DETL',
    columns: ['TAG_NO'],
    note: "untagged order line TAG_NO: data '', source 'N' (TR_SALE_ORD.cs:9208-9215)",
  },
  {
    family: 'SALES ORDER',
    table: 'ROJ_MEL_DATA',
    note:
      "scheme adjustment day-book row 05 (account 00079, 'MADJ - party'): source writes it whenever SCHM_AMT <> 0 " +
      '(Ac_Rojmel.cs:19), the data has none',
  },
  ...[
    ['RATE_CUT_ISU', ['ITM_FINE']],
    ['MAIN_STOCK', ['ITM_FINE']],
    ['ROJ_MEL_DATA', ['ITM_FINE']],
    ['AC_DATA', ['FINE_WT']],
    ['RATE_CUT_DATA', ['SL_FINE', 'TOT_FINE_DR']],
  ].map(([table, columns]) => ({
    family: 'WH SALES',
    table,
    columns,
    note:
      'loose-line fine net x (touch + wastage) / 100: data rounded to 2 decimals on the vouchers up to July 2024 and ' +
      'to 3 after, source Strings.Format(..., "0.000") (TR_WH_SALE.cs:10692, :10799)',
  })),
  {
    family: 'WH SALES',
    table: 'MAIN_STOCK',
    columns: ['TBL_CODE'],
    note: "loose-line issue stock TBL_CODE: data '001', source the line's own blank A.TBL_CODE (Ac_Stock.cs:153)",
  },
  ...['SALES ORDER', 'WH SALES'].map((family) => ({
    family,
    table: 'MAIN_STOCK',
    columns: ['ITM_LOT'],
    note:
      "stock ITM_LOT: data NULL up to July 2024 and '' from March 2025; source '' (Order_Stk, Ac_Stock.cs:86-97) " +
      "or the line's NOT NULL ITM_LOT (Wh_Sale_Stk, :153)",
  })),
  {
    family: 'WH SALES',
    table: 'MAIN_STOCK',
    columns: ['ITM_SIZE'],
    note: "received-line stock ITM_SIZE: data '', source the RATE_CUT_REC row's NULL A.ITM_SIZE (Ac_Stock.cs:155)",
  },
  {
    family: 'WH SALES',
    table: 'ROJ_MEL_DATA',
    columns: ['IT_TYPE', 'SIGN'],
    note: "purchase bill outstanding day-book row 13: data IT_TYPE 'G', SIGN '-'; source 'A', '' (Ac_Rojmel.cs:247)",
  },
];

/** The build-difference note of a grouped difference, or undefined for a genuine one. */
export function buildDifferenceOf(group) {
  // An entry naming columns covers the value differences of those columns; one without covers the keyed ones.
  const columnEntry = KNOWN_BUILD_DIFFERENCES.find(
    (k) =>
      k.columns &&
      k.family === group.family &&
      k.table === group.table &&
      group.kind === 'value' &&
      k.columns.includes(group.column),
  );
  if (columnEntry) return columnEntry.note;
  const known = KNOWN_BUILD_DIFFERENCES.find(
    (k) => !k.columns && k.family === group.family && k.table === group.table,
  );
  if (!known) return undefined;
  const keyed =
    group.kind === 'rows-unpaired' ||
    group.kind === 'row-count' ||
    (group.table === 'AC_DATA' && group.column === 'LEDR_KEY') ||
    (group.table === 'MAIN_STOCK' && group.column === 'SR_NO');
  return keyed ? known.note : undefined;
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
    .map((g) => ({ ...g, cases: g.cases.size, buildDifference: buildDifferenceOf(g) }))
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
