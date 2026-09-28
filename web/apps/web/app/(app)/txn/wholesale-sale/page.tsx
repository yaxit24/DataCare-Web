'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker, type LookupRow } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

// WHOLESALE SALE (desktop TR_WH_SALE, book 034 "Wh Sales", BOOK_SNAME 'WSALE').
//
// WHY THIS POSTS /rate-cut AND NOT /sales
// =======================================
// This page previously posted `/sales`, the RETAIL endpoint, so a wholesale voucher was silently stored as a
// retail sale — wrong book, wrong VCH_TYPE, and none of the wholesale write set.
//
// The correct family is established from the data, not from the form's name:
//   * BOOK_DATA for MAIN_BOOK='WH SALES' has BOOK_TBL_NAME = 'RATE_CUT_DATA' (book 034, CUR_USE='Y').
//   * A real Live24 wholesale voucher (034/00001) writes RATE_CUT_DATA 1, RATE_CUT_ISU 1, AC_DATA 4,
//     ROJ_MEL_DATA 1, MAIN_STOCK 1 — the rate-cut family, which `postRateCut` implements.
//   * TR_WH_SALE.cs's heaviest table references are RATE_CUT_DATA (16), RATE_CUT_ISU (14),
//     RATE_CUT_ISU_REC (9) and RATE_CUT_REC (6).
//
// WHAT THE OLD FORM MODEL GOT WRONG
// =================================
// Measured across all 15 real wholesale vouchers in Live24:
//   * TAX_PRC is 0 on every one. The old form defaulted to 3% GST.
//   * RATE_CUT_DATA has NO discount column. The old form had a "Discount amount" field with nowhere to go.
//   * SL_FINE and TOT_FINE_DR are populated on 14 of 15; money legs on only 1–2.
// Wholesale here is a FINE-METAL settlement voucher, not a taxed retail invoice. The invented tax and
// discount inputs are therefore gone, and the metal fields the family actually uses are surfaced instead.

type RateType = 'G' | '1' | 'K' | 'P';

interface Line {
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  othWt: string;
  netWt: string;
  touch: string;
  west: string;
  rate: string;
  rateType: RateType;
  making: string;
  lessWt: string;
  adjustWt: string;
  tagCost: string;
  lotNo: string;
  itemLot: string;
  lessTouch: string;
  otherRate: string;
  otherFine: string;
  convRate: string;
  silverFine: string;
  issueLcCode: string;
  tagGrossWt: string;
  tagNetWt: string;
  mcxRate: string;
  hallmarkFine: string;
  prCode: string;
  itemName: string;
  designNo: string;
  ghtPct: string;
  lbrAmt: string;
  othAmt: string;
  mrp: string;
  taxPct: string;
  bookingLookup: string;
  issueYear: string;
  issueBook: string;
  issueNo: string;
  issueSrno: string;
}

const extendedLineFields: Array<[keyof Line, string]> = [
  ['lessWt', 'LessWt'],
  ['adjustWt', 'AdjWt'],
  ['tagCost', 'TagCost'],
  ['lotNo', 'LotNo'],
  ['itemLot', 'ItmLot'],
  ['lessTouch', 'LTouch'],
  ['otherRate', 'ORate'],
  ['otherFine', 'OFine'],
  ['convRate', 'ConRate'],
  ['silverFine', 'SlvrFine'],
  ['issueLcCode', 'IsuLc'],
  ['tagGrossWt', 'TagGwt'],
  ['tagNetWt', 'TagNwt'],
  ['mcxRate', 'McxRate'],
  ['hallmarkFine', 'HmFine'],
  ['prCode', 'PrCost'],
  ['itemName', 'ItName'],
  ['designNo', 'Design'],
  ['ghtPct', 'Ght%'],
  ['lbrAmt', 'LbrAmt'],
  ['othAmt', 'OthAmt'],
  ['mrp', 'Mrp'],
  ['taxPct', 'Tax%'],
  ['issueYear', 'IsuYear'],
  ['issueBook', 'IsuBook'],
  ['issueNo', 'IsuNo'],
  ['issueSrno', 'IsuSr'],
];

const NUMERIC_EXTENDED = new Set<string>([
  'lessWt',
  'adjustWt',
  'tagCost',
  'lessTouch',
  'otherRate',
  'otherFine',
  'convRate',
  'silverFine',
  'tagGrossWt',
  'tagNetWt',
  'mcxRate',
  'hallmarkFine',
  'ghtPct',
  'lbrAmt',
  'othAmt',
  'mrp',
  'taxPct',
]);

const blank = (): Line => ({
  itCode: '',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  othWt: '',
  netWt: '',
  touch: '',
  west: '',
  rate: '',
  rateType: 'G',
  making: '',
  lessWt: '',
  adjustWt: '',
  tagCost: '',
  lotNo: '',
  itemLot: '',
  lessTouch: '',
  otherRate: '',
  otherFine: '',
  convRate: '',
  silverFine: '',
  issueLcCode: '',
  tagGrossWt: '',
  tagNetWt: '',
  mcxRate: '',
  hallmarkFine: '',
  prCode: '',
  itemName: '',
  designNo: '',
  ghtPct: '',
  lbrAmt: '',
  othAmt: '',
  mrp: '',
  taxPct: '',
  bookingLookup: '',
  issueYear: '',
  issueBook: '',
  issueNo: '',
  issueSrno: '',
});

const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function WholesaleSalePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  // IT_TYPE is set on all 15 real vouchers: the metal this voucher deals in.
  const [itType, setItType] = useState<'G' | 'S'>('G');
  // CONV_PRC is set on all 15 real vouchers.
  const [convPct, setConvPct] = useState('');
  const [cash, setCash] = useState('');
  const [kasar, setKasar] = useState('');
  const [billOs, setBillOs] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // P1-5: desktop grids are keyboard-first — arrows move, Enter advances and appends at the end,
  // Ctrl/Cmd+D removes a row (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      setLines((current) =>
        current.length === 1 ? [blank()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [result, setResult] = useState<{ vchNo: number; fine: number; netAmt: number } | null>(
    null,
  );
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));
  const bookingParams = new URLSearchParams({ itType });
  if (acCode.trim()) bookingParams.set('acCode', acCode.trim());
  const bookingSearchPath = `/lookup/bullion-bookings?${bookingParams.toString()}`;
  const bookingPatch = (line: Line, row: LookupRow): Line => ({
    ...line,
    bookingLookup: String(row.code ?? ''),
    issueLcCode: String(row.issueLcCode ?? row.LC_CODE ?? lcCode),
    issueYear: String(row.issueYear ?? row.CO_YEAR ?? ''),
    issueBook: String(row.issueBook ?? row.CO_BOOK ?? ''),
    issueNo: String(row.issueNo ?? row.VCH_NO ?? ''),
    issueSrno: String(row.issueSrno ?? row.SR_NO ?? ''),
    itCode: line.itCode || String(row.IT_CODE ?? ''),
    rate: line.rate || String(row.ITM_RATE ?? ''),
    mcxRate: line.mcxRate || String(row.MCX_RATE ?? ''),
  });
  const pickBooking = (i: number, row: LookupRow) =>
    setLines((rows) => rows.map((line, j) => (j === i ? bookingPatch(line, row) : line)));

  // Operator preview only — postRateCut recomputes authoritatively.
  // fine = net × (touch + west) / 100, mirroring rateCut.ts `fine()`.
  const calc = (l: Line) => {
    const net = n(l.netWt) || r3(n(l.grossWt) - n(l.othWt));
    const fine = r3((net * (n(l.touch) + n(l.west))) / 100);
    const metal = r2(fine * n(l.rate));
    const mk = r2(net * n(l.making));
    return { net, fine, metal, mk, total: r2(metal + mk) };
  };
  const totFine = r3(lines.reduce((s, l) => s + calc(l).fine, 0));
  const totAmt = r2(lines.reduce((s, l) => s + calc(l).total, 0));

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        vchDate: vchDate || undefined,
        acCode,
        acName: acName || undefined,
        itType,
        convPct: n(convPct) || undefined,
        lines: lines
          .filter((l) => n(l.netWt) > 0 || n(l.grossWt) > 0 || n(l.rate) > 0)
          .map((l) => {
            const sourceRef =
              l.issueYear.trim() || l.issueBook.trim() || l.issueNo.trim() || l.issueSrno.trim()
                ? {
                    yrcd: l.issueYear.trim() || undefined,
                    dbcd: l.issueBook.trim() || undefined,
                    no: l.issueNo.trim() || undefined,
                    srno: l.issueSrno.trim() ? n(l.issueSrno) : undefined,
                  }
                : undefined;
            return {
              itCode: l.itCode || undefined,
              tagNo: l.tagNo || undefined,
              pcs: n(l.pcs) || undefined,
              grossWt: n(l.grossWt) || undefined,
              othWt: n(l.othWt) || undefined,
              netWt: n(l.netWt) || undefined,
              touch: n(l.touch),
              westPct: n(l.west),
              rate: n(l.rate),
              rateType: l.rateType,
              itType,
              // 'N' = per gram, matching the desktop labour types the rate-cut engine accepts.
              ...(l.making ? { lbrType: 'N' as const, lbrRate: n(l.making) } : {}),
              // P7: writer-verified extended columns. A blank cell is OMITTED, never sent as 0 —
              // an explicit zero is an override at the writer and defeats the server's derivation.
              ...Object.fromEntries(
                extendedLineFields
                  .map(([key]) => [
                    key,
                    String((l as unknown as Record<string, unknown>)[key] ?? '').trim(),
                  ])
                  .filter(([, v]) => v !== '')
                  .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
              ),
              isuRef: sourceRef,
            };
          }),
        pay: {
          cash: n(cash) || undefined,
          kasar: n(kasar) || undefined,
          billOs: n(billOs) || undefined,
        },
      };
      setResult((await post('/rate-cut', body)) as { vchNo: number; fine: number; netAmt: number });
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Wholesale Sale</h1>
      <p className="muted">
        Desktop <code>TR_WH_SALE</code> — book <code>WSALE</code>. Posts the rate-cut family (
        <code>RATE_CUT_DATA</code>), which is what the desktop book writes.
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label htmlFor="wh-book">Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="WH" />
            </div>
            <div className="field">
              <label htmlFor="wh-date">Date</label>
              <input
                id="wh-date"
                type="date"
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
              />
            </div>
            <div className="field">
              <label htmlFor="wh-metal">Metal</label>
              <select
                id="wh-metal"
                value={itType}
                onChange={(e) => setItType(e.target.value as 'G' | 'S')}
              >
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field">
              <label htmlFor="wh-conv">Conversion %</label>
              <input
                id="wh-conv"
                inputMode="decimal"
                value={convPct}
                onChange={(e) => setConvPct(e.target.value)}
              />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label htmlFor="wh-party">Party</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => {
                  setAcCode(String(r.code));
                  setAcName(String(r.name || ''));
                }}
                placeholder="search accounts…"
              />
            </div>
            <div className="field">
              <label htmlFor="wh-party-name">Party name</label>
              <input
                id="wh-party-name"
                value={acName}
                onChange={(e) => setAcName(e.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="panel">
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="wholesale-sale-grid-mode"
          />
          <table onKeyDown={handleGridKey}>
            <caption className="sr-only">Wholesale sale lines</caption>
            <thead>
              <tr>
                <th scope="col">Item</th>
                <th scope="col">Tag</th>
                <th scope="col">Pcs</th>
                <th scope="col">Gross</th>
                <th scope="col">Other wt</th>
                <th scope="col">Net</th>
                <th scope="col">Touch</th>
                <th scope="col">West %</th>
                <th scope="col">Rate</th>
                <th scope="col">Rate type</th>
                <th scope="col">Making /g</th>
                <th scope="col">Booking</th>
                <th scope="col">Fine</th>
                <th scope="col">Amount</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => {
                const c = calc(l);
                return (
                  <tr key={i}>
                    <td>
                      <input
                        aria-label={`Item code line ${i + 1}`}
                        value={l.itCode}
                        onChange={(e) => setLine(i, 'itCode', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Tag line ${i + 1}`}
                        value={l.tagNo}
                        onChange={(e) => setLine(i, 'tagNo', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Pieces line ${i + 1}`}
                        inputMode="numeric"
                        value={l.pcs}
                        onChange={(e) => setLine(i, 'pcs', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Gross weight line ${i + 1}`}
                        inputMode="decimal"
                        value={l.grossWt}
                        onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Other weight line ${i + 1}`}
                        inputMode="decimal"
                        value={l.othWt}
                        onChange={(e) => setLine(i, 'othWt', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Net weight line ${i + 1}`}
                        inputMode="decimal"
                        value={l.netWt}
                        onChange={(e) => setLine(i, 'netWt', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Touch line ${i + 1}`}
                        inputMode="decimal"
                        value={l.touch}
                        onChange={(e) => setLine(i, 'touch', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Wastage percent line ${i + 1}`}
                        inputMode="decimal"
                        value={l.west}
                        onChange={(e) => setLine(i, 'west', e.target.value)}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Rate line ${i + 1}`}
                        inputMode="decimal"
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td>
                      <select
                        aria-label={`Rate type line ${i + 1}`}
                        value={l.rateType}
                        onChange={(e) => setLine(i, 'rateType', e.target.value)}
                      >
                        <option value="G">Per gram</option>
                        <option value="1">Per 10g</option>
                        <option value="K">Per kg</option>
                        <option value="P">Per piece</option>
                      </select>
                    </td>
                    <td>
                      <input
                        aria-label={`Making per gram line ${i + 1}`}
                        inputMode="decimal"
                        value={l.making}
                        onChange={(e) => setLine(i, 'making', e.target.value)}
                      />
                    </td>
                    <td>
                      <LookupPicker
                        entity="bullion-bookings"
                        value={l.bookingLookup}
                        onChange={(value) => setLine(i, 'bookingLookup', value)}
                        onPick={(row) => pickBooking(i, row)}
                        searchPath={bookingSearchPath}
                        placeholder="search bookings…"
                        ariaLabel={`Bullion booking source wholesale line ${i + 1}`}
                        style={{ minWidth: 210 }}
                      />
                    </td>
                    <td>{c.fine.toFixed(3)}</td>
                    <td>{c.total.toFixed(2)}</td>
                    <ExtendedBodyCells
                      full={fullGrid}
                      fields={extendedLineFields}
                      line={l}
                      row={i}
                      baseColumns={14}
                      setValue={(row, key, value) => setLine(row, key, value)}
                    />
                  </tr>
                );
              })}
            </tbody>
          </table>
          <button type="button" onClick={() => setLines((ls) => [...ls, blank()])}>
            Add line
          </button>
        </div>

        <div className="panel">
          <div className="row">
            <div className="field">
              <label htmlFor="wh-cash">Cash</label>
              <input
                id="wh-cash"
                inputMode="decimal"
                value={cash}
                onChange={(e) => setCash(e.target.value)}
              />
            </div>
            <div className="field">
              <label htmlFor="wh-kasar">Kasar</label>
              <input
                id="wh-kasar"
                inputMode="decimal"
                value={kasar}
                onChange={(e) => setKasar(e.target.value)}
              />
            </div>
            <div className="field">
              <label htmlFor="wh-billos">Bill outstanding</label>
              <input
                id="wh-billos"
                inputMode="decimal"
                value={billOs}
                onChange={(e) => setBillOs(e.target.value)}
              />
            </div>
          </div>
          <p>
            Total fine <strong>{totFine.toFixed(3)}</strong> · Total amount{' '}
            <strong>{totAmt.toFixed(2)}</strong>
          </p>
        </div>

        {err ? (
          <p className="error" role="alert">
            {err}
          </p>
        ) : null}
        {result ? (
          <p role="status">
            Saved voucher {result.vchNo} — fine {result.fine}, net {result.netAmt}
          </p>
        ) : null}
        <button className="primary" type="submit" disabled={busy || !coBook || !acCode}>
          {busy ? 'Saving…' : 'Save'}
        </button>
      </form>
    </div>
  );
}
