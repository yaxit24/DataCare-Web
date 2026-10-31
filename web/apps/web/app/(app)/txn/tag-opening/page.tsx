'use client';

import { useScaleCapture } from '../../../../components/ScaleCapture';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  extendedGridColumnCount,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';
import { useEffect, useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { useVoucherNumberKeys, VoucherNumberNote } from '../../../../components/VoucherNumberKeys';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ParityContainmentFieldset } from '../../../../components/ParityContainmentNotice';
import { parityContainmentMessage, parityContainmentRule } from '@datacare/core/containment';
import { fineFor, tagKarigarBlock } from '@datacare/core';
import { todayLocal } from '../../../../lib/localDate';

/** Tag Opening and Only Tag Entry (TR_TAG_OPBL): load opening barcoded stock. Tag No auto-generates (SRNO_MAST.TAG_SRNO)
 *  when left blank. Rich per-tag fields → BAR_DETL (Counter/Design/Size/LsWt/Lbr%/LbrRate/OthAmt).
 *  The two menus share the form and differ by book family (MDI_FORM.cs:7700-7710 CurBookHelp("OPSTK"), :8574-8584
 *  CurBookHelp("TAG GEN")): Only Tag Entry (`?mode=TAG GEN`) makes the tags out of a loose stock item, which it asks for. */
const DELETE_CONFIRM = 'Are You Sure To Delete This Voucher now?'; // TR_TAG_OPBL.cs:11387
const DELETE_DONE = 'Delete Success.'; // :11431
interface Line {
  tagNo: string;
  vchSrno?: number;
  itCode: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  lessWt: string;
  netWt: string;
  touch: string;
  lbrPct: string;
  lbrRate: string;
  othAmt: string;
  rate: string;
  mrp: string;
  // Desktop tag-grid columns (TR_TAG_OPBL mSG): item attributes, retail pricing, hallmark,
  // karigar costing, jadtar weights and the order/manufacturing links.
  designImageId: string;
  empIsu: string;
  fineWt: string;
  ghtWt: string;
  hallmarkId2: string;
  hallmarkId2Wt: string;
  hallmarkId3: string;
  hallmarkId3Wt: string;
  hallmarkId4: string;
  hallmarkId4Wt: string;
  hallmarkIdWt: string;
  itmColor: string;
  itmMargin: string;
  itmStyle: string;
  jdtGhtWt: string;
  jdtJdtWt: string;
  jdtKunNet: string;
  jdtKunTouch: string;
  jdtKunWt: string;
  jdtWaxWt: string;
  // The karigar weight block, desktop columns 17-23 (N204).
  karigarOthWt: string;
  karigarNetWt: string;
  karigarGhtPct: string;
  karigarGhtWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  karigarCost: string;
  karigarGwtTouch: string;
  karigarLbrAmt: string;
  karigarLbrRate: string;
  karigarName: string;
  karigarOthAmt: string;
  karigarOthFine: string;
  karigarOthRate: string;
  karigarTotFine: string;
  karigarWaxWt: string;
  lbrAmt: string;
  lbrCode: string;
  lbrType: string;
  mainMarginPct: string;
  mainMrp: string;
  mfgDbcd: string;
  mfgNo: string;
  mfgSrno: string;
  mfgYrcd: string;
  ordAc: string;
  ordDbcd: string;
  ordLcCode: string;
  ordNo: string;
  ordSrno: string;
  ordYrcd: string;
  sfNo: string;
  slType: string;
  tagCost: string;
  westPct: string;
}
const extendedLineFields: Array<[keyof Line, string]> = [
  // TR_TAG_OPBL columns 17-23 follow NetWt on the desktop grid, with these headers (TR_TAG_OPBL.cs:5146-5172).
  ['karigarOthWt', 'KrOthWt'],
  ['karigarNetWt', 'KrNwt'],
  ['karigarGhtPct', 'KrGht%'],
  ['karigarGhtWt', 'KrGht'],
  ['karigarTouch', 'KrTouch'],
  ['karigarWestPct', 'KrWst%'],
  ['karigarFine', 'KrFine'],
  ['designImageId', 'Design Image Id'],
  ['empIsu', 'Emp Isu'],
  ['fineWt', 'Fine Wt'],
  ['ghtWt', 'Ght Wt'],
  ['hallmarkId2', 'Hallmark Id2'],
  ['hallmarkId2Wt', 'Hallmark Id2 Wt'],
  ['hallmarkId3', 'Hallmark Id3'],
  ['hallmarkId3Wt', 'Hallmark Id3 Wt'],
  ['hallmarkId4', 'Hallmark Id4'],
  ['hallmarkId4Wt', 'Hallmark Id4 Wt'],
  ['hallmarkIdWt', 'Hallmark Id Wt'],
  ['itmColor', 'Itm Color'],
  ['itmMargin', 'Itm Margin'],
  ['itmStyle', 'Itm Style'],
  ['jdtGhtWt', 'Jdt Ght Wt'],
  ['jdtJdtWt', 'Jdt Jdt Wt'],
  ['jdtKunNet', 'Jdt Kun Net'],
  ['jdtKunTouch', 'Jdt Kun Touch'],
  ['jdtKunWt', 'Jdt Kun Wt'],
  ['jdtWaxWt', 'Jdt Wax Wt'],
  ['karigarCost', 'Karigar Cost'],
  ['karigarGwtTouch', 'Karigar Gwt Touch'],
  ['karigarLbrAmt', 'Karigar Lbr Amt'],
  ['karigarLbrRate', 'Karigar Lbr Rate'],
  ['karigarName', 'Karigar Name'],
  ['karigarOthAmt', 'Karigar Oth Amt'],
  ['karigarOthFine', 'Karigar Oth Fine'],
  ['karigarOthRate', 'Karigar Oth Rate'],
  ['karigarTotFine', 'Karigar Tot Fine'],
  ['karigarWaxWt', 'Karigar Wax Wt'],
  ['lbrAmt', 'Lbr Amt'],
  ['lbrCode', 'Lbr Code'],
  ['lbrType', 'Lbr Type'],
  ['mainMarginPct', 'Main Margin Pct'],
  ['mainMrp', 'Main Mrp'],
  ['mfgDbcd', 'Mfg Dbcd'],
  ['mfgNo', 'Mfg No'],
  ['mfgSrno', 'Mfg Srno'],
  ['mfgYrcd', 'Mfg Yrcd'],
  ['ordAc', 'Ord Ac'],
  ['ordDbcd', 'Ord Dbcd'],
  ['ordLcCode', 'Ord Lc Code'],
  ['ordNo', 'Ord No'],
  ['ordSrno', 'Ord Srno'],
  ['ordYrcd', 'Ord Yrcd'],
  ['sfNo', 'Sf No'],
  ['slType', 'Sl Type'],
  ['tagCost', 'Tag Cost'],
  ['westPct', 'West Pct'],
];
const blank = (): Line => ({
  tagNo: '',
  itCode: '',
  tblCode: '001',
  designNo: '',
  itmSize: '',
  pcs: '1',
  grossWt: '',
  lessWt: '',
  netWt: '',
  touch: '',
  lbrPct: '',
  lbrRate: '',
  othAmt: '',
  rate: '',
  mrp: '',
  designImageId: '',
  empIsu: '',
  fineWt: '',
  ghtWt: '',
  hallmarkId2: '',
  hallmarkId2Wt: '',
  hallmarkId3: '',
  hallmarkId3Wt: '',
  hallmarkId4: '',
  hallmarkId4Wt: '',
  hallmarkIdWt: '',
  itmColor: '',
  itmMargin: '',
  itmStyle: '',
  jdtGhtWt: '',
  jdtJdtWt: '',
  jdtKunNet: '',
  jdtKunTouch: '',
  jdtKunWt: '',
  jdtWaxWt: '',
  karigarOthWt: '',
  karigarNetWt: '',
  karigarGhtPct: '',
  karigarGhtWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  karigarCost: '',
  karigarGwtTouch: '',
  karigarLbrAmt: '',
  karigarLbrRate: '',
  karigarName: '',
  karigarOthAmt: '',
  karigarOthFine: '',
  karigarOthRate: '',
  karigarTotFine: '',
  karigarWaxWt: '',
  lbrAmt: '',
  lbrCode: '',
  lbrType: '',
  mainMarginPct: '',
  mainMrp: '',
  mfgDbcd: '',
  mfgNo: '',
  mfgSrno: '',
  mfgYrcd: '',
  ordAc: '',
  ordDbcd: '',
  ordLcCode: '',
  ordNo: '',
  ordSrno: '',
  ordYrcd: '',
  sfNo: '',
  slType: '',
  tagCost: '',
  westPct: '',
});
/** A saved row as the grid shows it: text as stored, numbers as typed text, zero as blank (the desktop's empty cell). */
function fromSaved(saved: Record<string, unknown>): Line {
  const line = blank();
  for (const key of Object.keys(line) as Array<keyof Line>) {
    if (key === 'vchSrno') continue;
    const value = saved[key];
    if (value === undefined || value === null) continue;
    (line as unknown as Record<string, string>)[key] =
      typeof value === 'number' ? (value === 0 ? '' : String(value)) : String(value);
  }
  line.vchSrno = Number(saved.vchSrno ?? 0) || undefined;
  if (!line.tblCode) line.tblCode = '001';
  return line;
}
const n = (v: string) => Number(v || 0);
/** The cells the Fine column is worked out from. TR_TAG_OPBL.cs:6527-6594 recomputes the Fine column whenever one of
 *  them changes, so a fine reloaded with the voucher (or typed in Fine Wt) gives way to the formula once they change. */
const FINE_INPUTS = new Set<keyof Line>([
  'grossWt',
  'lessWt',
  'netWt',
  'touch',
  'ghtWt',
  'westPct',
]);
/** CommPassTotal recomputes KrFine when KrTouch, KrWst% or KrGht changes (TR_TAG_OPBL.cs:6749, :6771, :6815), and when
 *  KrNwt changes (:6712), which a change of gross, net or KrOthWt can cause. */
const KARIGAR_FINE_INPUTS = new Set<keyof Line>([
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarGhtWt',
]);
const karigarNet = (line: Line) => tagKarigarBlock(line).karigarNetWt;
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const currentDate = () => todayLocal();
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

export default function TagOpeningPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(currentDate);
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [res, setRes] = useState<{ vchNo: number; tags: number; tagNos: string[] } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  // P3: The loose-stock item code the opened tag draws its metal from.
  const [stockItCode, setStockItCode] = useState('');
  // The menu decides the book family: Tag Opening lists OPSTK books, Only Tag Entry (?mode=TAG GEN) TAG GEN books.
  const [tagGen, setTagGen] = useState(false);
  useEffect(() => {
    setTagGen(new URLSearchParams(window.location.search).get('mode')?.toUpperCase() === 'TAG GEN');
  }, []);
  const [notice, setNotice] = useState('');
  const submitRef = useRef<HTMLButtonElement>(null);
  // Desktop parity: TR_TAG_OPBL reads the scale only while the NET WEIGHT cell is current
  // (`if (MSG.Col != 14) continue;`), so the row that owns focus is tracked and a reading is discarded
  // when no net-weight cell is focused. Nothing is ever written from a stale or unfocused reading.
  const [scaleRow, setScaleRow] = useState<number | null>(null);
  // The desktop's image buttons act on the CURRENT grid row (TR_TAG_OPBL.cs:11941-12190), so the row that
  // last held focus owns the photograph. It sticks after blur so clicking the panel's own buttons does not
  // clear the selection.
  const [imageRow, setImageRow] = useState(0);
  const scale = useScaleCapture((text) => {
    if (scaleRow == null) return;
    setLine(scaleRow, 'netWt', text);
  });

  // Desktop parity: TR_TAG_OPBL's grid types every tag attribute inline.
  const [fullGrid, setFullGrid] = useState(false);
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: extendedGridColumnCount(fullGrid, 14, extendedLineFields.length),
    onAppendRow: () => setLines((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this tag row?')) return false;
      setLines((current) =>
        current.length > 1 ? current.filter((_, index) => index !== row) : [blank()],
      );
      return true;
    },
    onEscape: () => submitRef.current?.focus(),
  });
  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) =>
      ls.map((l, j) => {
        if (j !== i) return l;
        const next = { ...l, [k]: v, ...(FINE_INPUTS.has(k) ? { fineWt: '' } : {}) };
        return KARIGAR_FINE_INPUTS.has(k) || karigarNet(next) !== karigarNet(l)
          ? { ...next, karigarFine: '' }
          : next;
      }),
    );
  // Leaving a cell runs CommPassTotal's karigar block (TR_TAG_OPBL.cs:6679-6826): KrNwt and KrFine are filled in.
  const leaveKarigar = (i: number) =>
    setLines((ls) =>
      ls.map((l, j) => {
        if (j !== i) return l;
        const block = tagKarigarBlock(l);
        const cell = (current: string, worked: number) =>
          worked === 0 && !current.trim() ? current : worked.toFixed(3);
        const karigarNetWt = cell(l.karigarNetWt, block.karigarNetWt);
        const karigarFine = cell(l.karigarFine, block.karigarFine);
        return karigarNetWt === l.karigarNetWt && karigarFine === l.karigarFine
          ? l
          : { ...l, karigarNetWt, karigarFine };
      }),
    );
  // The Fine column shows what will be saved: the stored or typed fine while it stands, else the formula.
  const fine = (l: Line) =>
    l.fineWt.trim()
      ? n(l.fineWt)
      : fineFor('tagOpening', {
          netWt: n(l.netWt),
          touch: n(l.touch),
          ghtWt: n(l.ghtWt),
          westPct: n(l.westPct),
        });
  const scopeQuery = `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;
  const errorText = (error: unknown) =>
    error instanceof ApiError
      ? error.body?.detail || error.body?.message || error.body?.error || error.message
      : 'failed';

  function newVoucher() {
    setLoadedVchNo('');
    setVoucherLookup('');
    setVchDate(currentDate());
    setLines([blank()]);
    setStockItCode('');
    setRes(null);
    setErr('');
    setNotice('');
  }

  async function openVoucher(requested: string): Promise<boolean> {
    const vchNo = requested.trim();
    if (!vchNo) return false;
    setBusy(true);
    setErr('');
    setNotice('');
    try {
      const view = await get<any>(`/stock/tag-opening/${encodeURIComponent(vchNo)}?${scopeQuery}`);
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setVchDate(String(view.vchDate));
      // TR_TAG_OPBL.cs:10398 reloads the stock item (BAR_DATA.STK_IT_CODE) with the voucher.
      setStockItCode(String(view.stockItCode ?? ''));
      // Every field the API returns goes back into the row (G214): copying only the 15 visible columns made an
      // unchanged save blank the other 50 (hallmark ids, karigar costing, JDT weights, order and mfg links).
      const loaded = (view.lines ?? []).map((line: any): Line => fromSaved(line));
      setLines(loaded.length ? loaded : [blank()]);
      setRes(null);
      return true;
    } catch (error) {
      setErr(errorText(error));
      return false;
    } finally {
      setBusy(false);
    }
  }

  async function loadVoucher() {
    await openVoucher(voucherLookup);
  }

  // N172 (G179): the voucher number box's F1, Up, Down and Enter (tVchNo_KeyDown, TR_TAG_OPBL.cs:11879).
  const numberKeys = useVoucherNumberKeys({
    table: 'BAR_DATA',
    book: coBook,
    value: voucherLookup,
    open: (vchNo) => openVoucher(vchNo),
    fresh: newVoucher,
  });

  async function removeVoucher() {
    if (!loadedVchNo || !window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    setErr('');
    try {
      await del(`/stock/tag-opening/${encodeURIComponent(loadedVchNo)}?${scopeQuery}`);
      newVoucher();
      setNotice(DELETE_DONE);
    } catch (error) {
      setErr(errorText(error));
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const body = {
        stockItCode: tagGen ? stockItCode.trim() || undefined : undefined,
        coBook: coBook || undefined,
        coYear,
        lcCode,
        vchDate,
        lines: lines
          .filter((line) => line.itCode)
          .map((line) => ({
            tagNo: line.tagNo || undefined,
            vchSrno: line.vchSrno,
            itCode: line.itCode,
            tblCode: line.tblCode || undefined,
            designNo: line.designNo || undefined,
            itmSize: line.itmSize || undefined,
            designImageId: line.designImageId || undefined,
            empIsu: line.empIsu || undefined,
            fineWt: Number(line.fineWt || 0) || undefined,
            ghtWt: Number(line.ghtWt || 0) || undefined,
            // P0-06/WP-08: HUIDs are ALPHANUMERIC and the contract types them as strings
            // (stockVoucherLifecycle.ts:61-63; the writer stores text(...).slice(0, 10) at :647).
            // This page sent Number(...), so any id containing a letter became NaN and was then
            // dropped by `|| undefined` — the id was silently lost on every save. The *_WT fields
            // beside these ARE numeric, so their coercion is correct and is left alone.
            hallmarkId2: line.hallmarkId2?.trim() || undefined,
            hallmarkId2Wt: Number(line.hallmarkId2Wt || 0) || undefined,
            hallmarkId3: line.hallmarkId3?.trim() || undefined,
            hallmarkId3Wt: Number(line.hallmarkId3Wt || 0) || undefined,
            hallmarkId4: line.hallmarkId4?.trim() || undefined,
            hallmarkId4Wt: Number(line.hallmarkId4Wt || 0) || undefined,
            hallmarkIdWt: Number(line.hallmarkIdWt || 0) || undefined,
            itmColor: line.itmColor || undefined,
            itmMargin: Number(line.itmMargin || 0) || undefined,
            itmStyle: line.itmStyle || undefined,
            jdtGhtWt: Number(line.jdtGhtWt || 0) || undefined,
            jdtJdtWt: Number(line.jdtJdtWt || 0) || undefined,
            jdtKunNet: Number(line.jdtKunNet || 0) || undefined,
            jdtKunTouch: Number(line.jdtKunTouch || 0) || undefined,
            jdtKunWt: Number(line.jdtKunWt || 0) || undefined,
            jdtWaxWt: Number(line.jdtWaxWt || 0) || undefined,
            karigarOthWt: Number(line.karigarOthWt || 0) || undefined,
            karigarNetWt: Number(line.karigarNetWt || 0) || undefined,
            karigarGhtPct: Number(line.karigarGhtPct || 0) || undefined,
            karigarGhtWt: Number(line.karigarGhtWt || 0) || undefined,
            karigarTouch: Number(line.karigarTouch || 0) || undefined,
            karigarWestPct: Number(line.karigarWestPct || 0) || undefined,
            karigarFine: Number(line.karigarFine || 0) || undefined,
            karigarCost: Number(line.karigarCost || 0) || undefined,
            karigarGwtTouch: Number(line.karigarGwtTouch || 0) || undefined,
            karigarLbrAmt: Number(line.karigarLbrAmt || 0) || undefined,
            karigarLbrRate: Number(line.karigarLbrRate || 0) || undefined,
            karigarName: line.karigarName || undefined,
            karigarOthAmt: Number(line.karigarOthAmt || 0) || undefined,
            karigarOthFine: Number(line.karigarOthFine || 0) || undefined,
            karigarOthRate: Number(line.karigarOthRate || 0) || undefined,
            karigarTotFine: Number(line.karigarTotFine || 0) || undefined,
            karigarWaxWt: Number(line.karigarWaxWt || 0) || undefined,
            lbrAmt: Number(line.lbrAmt || 0) || undefined,
            lbrCode: line.lbrCode || undefined,
            lbrType: line.lbrType || undefined,
            mainMarginPct: Number(line.mainMarginPct || 0) || undefined,
            mainMrp: Number(line.mainMrp || 0) || undefined,
            mfgDbcd: line.mfgDbcd || undefined,
            mfgNo: line.mfgNo || undefined,
            mfgSrno: Number(line.mfgSrno || 0) || undefined,
            mfgYrcd: line.mfgYrcd || undefined,
            ordAc: line.ordAc || undefined,
            ordDbcd: line.ordDbcd || undefined,
            ordLcCode: line.ordLcCode || undefined,
            ordNo: line.ordNo || undefined,
            ordSrno: Number(line.ordSrno || 0) || undefined,
            ordYrcd: line.ordYrcd || undefined,
            sfNo: line.sfNo || undefined,
            slType: line.slType || undefined,
            tagCost: Number(line.tagCost || 0) || undefined,
            westPct: Number(line.westPct || 0) || undefined,

            pcs: n(line.pcs),
            grossWt: n(line.grossWt),
            lessWt: n(line.lessWt),
            netWt: n(line.netWt),
            touch: n(line.touch),
            lbrPct: n(line.lbrPct),
            lbrRate: n(line.lbrRate),
            othAmt: n(line.othAmt),
            rate: n(line.rate),
            mrp: n(line.mrp),
          })),
      };
      const saved = loadedVchNo
        ? await put<{ vchNo: number; tags: number; tagNos: string[] }>(
            `/stock/tag-opening/${encodeURIComponent(loadedVchNo)}`,
            body,
          )
        : await post<{ vchNo: number; tags: number; tagNos: string[] }>('/stock/tag-opening', body);
      const savedNo = String(saved.vchNo).padStart(5, '0');
      setLoadedVchNo(savedNo);
      setVoucherLookup(savedNo);
      setRes(saved);
    } catch (error) {
      setErr(errorText(error));
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <h1>
        {tagGen ? 'Only Tag Entry' : 'Tag Opening Balance'}{' '}
        <span className="muted">
          {tagGen
            ? '— tags made from a loose stock item (Tag No auto-generates when blank)'
            : '— barcoded opening stock (Tag No auto-generates when blank)'}
        </span>
      </h1>
      {notice && (
        <div className="msg ok" role="status">
          {notice}
        </div>
      )}
      <form onSubmit={submit}>
        <div className="panel">
          {tagGen && (
            <div className="row">
              <div className="field">
                <label>Stock Item Code</label>
                <LookupPicker
                  entity="items"
                  ariaLabel="Stock Item Code"
                  value={stockItCode}
                  onChange={setStockItCode}
                  style={{ width: 120 }}
                />
              </div>
            </div>
          )}
          <div className="row">
            <div className="field">
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                onKeyDown={numberKeys.onKeyDown}
                placeholder="00001"
              />
            </div>
            <button type="button" className="ghost" disabled={busy} onClick={loadVoucher}>
              Load
            </button>
            <VoucherNumberNote note={numberKeys.note} />
            {loadedVchNo && (
              <span className="msg ok" data-testid="tag-opening-loaded">
                Loaded #{loadedVchNo}
              </span>
            )}
            {loadedVchNo && (
              <button type="button" className="danger" disabled={busy} onClick={removeVoucher}>
                Delete
              </button>
            )}
            <button type="button" className="ghost" disabled={busy} onClick={newVoucher}>
              New
            </button>
            <div className="field">
              <label>Date</label>
              <input
                aria-label="Date"
                ref={numberKeys.dateRef}
                type="date"
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
              />
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred={tagGen ? 'TGN' : 'TOP'}
                mainBooks={tagGen ? ['TAG GEN'] : ['OPSTK', 'TAG OPENING']}
              />
            </div>
          </div>
        </div>
        <fieldset
          className="panel"
          aria-label="Opening tag details"
          style={{ overflow: 'auto', minWidth: 0, border: 0, padding: 0, margin: 0 }}
        >
          <div className="toolbar" style={{ marginBottom: 6 }}>
            <h2 style={{ margin: 0 }}>Opening Tags</h2>
            <span className="spacer" />
            <GridModeToggle
              full={fullGrid}
              setFull={setFullGrid}
              extendedCount={extendedLineFields.length}
              testId="tag-opening-grid-mode"
            />
            {/* Weighing scale, replicating TR_TAG_OPBL's reader. Never fabricates a reading: when the
                port is off, the browser lacks WebSerial, or no port is granted, the operator types the
                weight exactly as they would with an unplugged scale. */}
            <span className="muted" style={{ marginLeft: 12 }} data-testid="scale-status">
              Scale: {scale.status}
              {scale.lastReading ? ` · ${scale.lastReading}` : ''}
            </span>
            {scale.status === 'reading' ? (
              <button type="button" className="ghost" onClick={() => void scale.disconnect()}>
                Disconnect scale
              </button>
            ) : (
              <button
                type="button"
                className="ghost"
                data-testid="scale-connect"
                disabled={scale.status === 'disabled' || scale.status === 'unsupported'}
                title={scale.message || 'Connect a CH340 weighing scale over WebSerial'}
                onClick={() => void scale.connect()}
              >
                Connect scale
              </button>
            )}
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>Tag No</th>
                <th>Item</th>
                <th>Ctr</th>
                <th>Design</th>
                <th>Size</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Ls Wt</th>
                <th className="num">Net</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <th className="num">Lbr%</th>
                <th className="num">LbrRate</th>
                <th className="num">OthAmt</th>
                <th className="num">MRP</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="tag-opening-grid" onKeyDown={handleGridKey}>
              {lines.map((line, i) => (
                <tr key={`${line.vchSrno ?? 'new'}-${i}`}>
                  <td {...gridCell(i, 0)}>
                    <input
                      aria-label={`Tag no row ${i + 1}`}
                      value={line.tagNo}
                      placeholder="auto"
                      // Focusing the tag cell selects the row the image panel acts on.
                      onFocus={() => setImageRow(i)}
                      onChange={(e) => setLine(i, 'tagNo', e.target.value)}
                      style={{ width: 90 }}
                    />
                  </td>
                  <td {...gridCell(i, 1)}>
                    <LookupPicker
                      entity="items"
                      ariaLabel={`Item code row ${i + 1}`}
                      value={line.itCode}
                      onChange={(value) => setLine(i, 'itCode', value)}
                      style={{ width: 80 }}
                    />
                  </td>
                  {(
                    [
                      ['tblCode', 40],
                      ['designNo', 64],
                      ['itmSize', 48],
                      ['pcs', 40],
                      ['grossWt', 60],
                      ['lessWt', 50],
                      ['netWt', 60],
                      ['touch', 52],
                    ] as const
                  ).map(([field, width], columnIndex) => (
                    <td
                      {...gridCell(i, columnIndex + 2)}
                      key={field}
                      className={field === 'tblCode' ? undefined : 'num'}
                    >
                      <input
                        onFocus={() => {
                          // TR_TAG_OPBL reads the scale only while the net-weight cell is current.
                          if (field === 'netWt') setScaleRow(i);
                          setImageRow(i);
                        }}
                        onBlur={() => {
                          if (field === 'netWt')
                            setScaleRow((current) => (current === i ? null : current));
                          leaveKarigar(i);
                        }}
                        aria-label={`Tag opening ${field} row ${i + 1}`}
                        value={line[field]}
                        onChange={(e) => setLine(i, field, e.target.value)}
                        style={{ width, textAlign: field === 'tblCode' ? undefined : 'right' }}
                      />
                    </td>
                  ))}
                  <td className="num" data-testid={`tag-opening-fine-row-${i + 1}`}>
                    {fine(line).toLocaleString('en-IN')}
                  </td>
                  {(
                    [
                      ['lbrPct', 44],
                      ['lbrRate', 56],
                      ['othAmt', 56],
                      ['mrp', 64],
                    ] as const
                  ).map(([field, width], columnIndex) => (
                    <td {...gridCell(i, columnIndex + 10)} key={field} className="num">
                      <input
                        aria-label={`Tag opening ${field} row ${i + 1}`}
                        value={line[field]}
                        onChange={(e) => setLine(i, field, e.target.value)}
                        style={{ width, textAlign: 'right' }}
                      />
                    </td>
                  ))}
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedLineFields}
                    line={line}
                    row={i}
                    baseColumns={14}
                    setValue={(row, key, value) => setLine(row, key, value)}
                    onLeave={(row) => leaveKarigar(row)}
                    cellProps={gridCell}
                  />
                  <td>
                    <button
                      type="button"
                      className="danger"
                      aria-label={`Remove tag row ${i + 1}`}
                      onClick={() =>
                        setLines((current) =>
                          current.length > 1
                            ? current.filter((_, index) => index !== i)
                            : [blank()],
                        )
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>

          {/* Desktop BtnImgS / BtnImgC / BtnImgD act on the current grid row, so the panel follows focus. */}
          <EntityImagePanel
            entityType="TAG"
            entityKey={lines[imageRow]?.tagNo ?? ''}
            instance={lines[imageRow]?.vchSrno ?? imageRow + 1}
            label="Tag image"
            testId="tag-opening-image"
          />
          {lines.map((line, index) => (
            <details
              key={`tag-line-extra-${index}`}
              style={{ marginTop: 8, display: fullGrid ? 'none' : undefined }}
            >
              <summary>Tag row {index + 1} desktop fields</summary>
              <div className="row">
                {extendedLineFields.map(([key, label]) => (
                  <div className="field" key={String(key)}>
                    <label>{label}</label>
                    <input
                      aria-label={`${label} row ${index + 1}`}
                      value={String(line[key] ?? '')}
                      onChange={(e) => setLine(index, key, e.target.value)}
                      onBlur={() => leaveKarigar(index)}
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((current) => [...current, blank()])}
            >
              + Add tag
            </button>
            <span className="spacer" />
            <button ref={submitRef} className="primary" data-save-mnemonic disabled={busy}>
              {busy ? 'Saving…' : loadedVchNo ? 'Update Opening' : 'Load Opening Stock'}
            </button>
          </div>
        </fieldset>
      </form>
      {err && (
        <div className="msg err" role="alert">
          {err}
        </div>
      )}
      {res && (
        <div className="panel">
          <div className="msg ok">
            {loadedVchNo ? 'Saved' : 'Opening saved'} — voucher #{res.vchNo} · {res.tags} tag(s)
          </div>
          {res.tagNos?.length ? (
            <div className="muted" style={{ marginTop: 6 }}>
              Barcodes: <code>{res.tagNos.join(', ')}</code>
            </div>
          ) : null}
        </div>
      )}
      <VoucherList
        table="BAR_DATA"
        book={coBook}
        onLoad={(vchNo) => void openVoucher(vchNo)}
        openKey={numberKeys.listKey}
        reloadKey={res?.vchNo}
      />
    </div>
  );
}
