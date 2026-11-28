'use client';

import {
  useEffect,
  useLayoutEffect,
  useRef,
  useState,
  type KeyboardEvent,
  type RefObject,
} from 'react';
import { createPortal } from 'react-dom';
import { dotNetRoundDouble } from '@datacare/core';
import { get } from '../lib/api';
import { carryPurchaseHeader } from '../lib/purchaseCarry';
import { useGridKeyboard } from './GridKeyboard';
import { stoneRowFromApi, subDetailInputs } from './SubDetailGrid';
import {
  blankPurchaseLine,
  PurchaseLineDetails,
  PurchaseLineGrid,
  purchaseLineFromView,
  purchaseLinesBody,
  usePurchasePricing,
  type PurchaseLine,
} from './PurchaseEntryForm';

/**
 * Owner decision 2B: on a tax-invoice (BOOK_TYPE 'T') sale book the Sales screen's Old Gold / Old Silver totals rows
 * open the purchase entry on the URD book (TR_SALE.cs:18756-18842 opens TR_PURC on 043/044 with the sale's party,
 * 00045 becoming 00050, and the sale number in tSlBill read-only, TR_PURC.cs:13724-13740). "Done" brings back the
 * purchase's amount (BILL_OS; TOT_AMT for 00050) and net weight (TR_PURC.cs:13283-13312, TR_SALE.cs:16482-16497).
 *
 * The web saves nothing then: the purchase travels with the sale as `linkedOldPurchase: { gold?, silver? }` and the
 * server writes both in one transaction, reading the amounts back from the stored purchase. The figures here are the
 * purchase screen's own preview arithmetic (PurchaseEntryForm), so they equal what the server stores.
 */
type Metal = 'G' | 'S';
const KEY: Record<Metal, 'gold' | 'silver'> = { G: 'gold', S: 'silver' };
const WORD: Record<Metal, string> = { G: 'Gold', S: 'Silver' };

interface Draft {
  lines: PurchaseLine[];
  taxRatePct: string;
  discountAmount: string;
  roundOff: string;
  /** The stored purchase as reopened (GET /sales/:vchNo `linkedOldPurchases[].purchase`); unshown values go back. */
  view: Record<string, unknown> | null;
  amount: number;
  netWt: number;
  stored?: string; // "043/00001"
  /** Entered or changed since it was loaded or saved: only then does the sale save send it (absent = keep). */
  dirty: boolean;
}
/** A linked purchase the operator may not view (no Purchase view right): amounts only, kept unchanged on save. */
interface Summary {
  metal: Metal;
  coBook: string;
  vchNo: string;
  amount: number;
  netWt: number;
}

const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const r2 = (v: number) => Math.round(v * 100) / 100;
const r3 = (v: number) => Math.round(v * 1000) / 1000;
const filled = (l: PurchaseLine) => !!l.itCode && !!(l.netWt || l.rate);
const money = (v: number) => v.toLocaleString('en-IN', { minimumFractionDigits: 2 });
const stonesOf = (line: PurchaseLine | undefined) => {
  const s = line?.source?.stones;
  const rows = Array.isArray(s) ? subDetailInputs(s.map((x) => stoneRowFromApi(x))) : [];
  return rows.length ? rows : undefined;
};

/**
 * The linked purchase as the request sends it: the modal's own fields, over the stored header it does not show. Tender,
 * kasar, TCS, TDS and hallmark are the modal's keys too and left empty, so the bill the modal previews is what the
 * server stores (BILL_OS = TOT_AMT; a 00050 purchase is paid in cash by the server itself, TR_PURC.cs:15087-15090).
 */
function purchaseBody(d: Draft, interState: boolean) {
  const rof = n(d.roundOff);
  return carryPurchaseHeader(d.view, {
    taxRatePct: n(d.taxRatePct),
    interState,
    discountAmount: d.discountAmount ? n(d.discountAmount) : undefined,
    discountPct: undefined,
    roundOffAmount: rof !== 0 ? rof : undefined,
    ...{ cashAmt: undefined, chequeAmt: undefined, cardAmt: undefined, upiAmt: undefined },
    ...{ kasar: undefined, bankAc: undefined, cashAc: undefined, kasarAc: undefined },
    ...{ tcsCode: undefined, tcsPct: undefined, tcsAmount: undefined },
    ...{ tdsCode: undefined, tdsPct: undefined, tdsAmount: undefined },
    ...{ hmAmount: undefined, hmTaxPct: undefined, hmTaxCode: undefined },
    lines: purchaseLinesBody(d.lines, (i) => stonesOf(d.lines[i])),
  });
}
/** What Done compares to decide whether the operator changed the purchase. */
const signature = (d: Pick<Draft, 'lines' | 'taxRatePct' | 'discountAmount' | 'roundOff'>) =>
  JSON.stringify([
    purchaseLinesBody(d.lines, (i) => stonesOf(d.lines[i])),
    n(d.taxRatePct),
    n(d.discountAmount),
    n(d.roundOff),
  ]);

function draftFromView(p: Record<string, any>, amount: number, netWt: number): Draft {
  const lines = (p.lines ?? []).map(purchaseLineFromView) as PurchaseLine[];
  return {
    lines: lines.length ? lines : [blankPurchaseLine()],
    taxRatePct: str(p.taxRatePct) || '0',
    discountAmount: str(p.discountAmount),
    roundOff: str(p.roundOffAmount),
    view: p,
    amount,
    netWt,
    dirty: false,
  };
}

export interface SaleContext {
  enabled: boolean;
  acCode: string;
  acName: string;
  vchDate: string;
  coBook: string;
  vchNo: string;
  /** The sale's inter-state flag: the purchase is on the same party, so its GST type is the same. */
  interState: boolean;
}

/** The purchase party (TR_PURC.cs:13724-13740: the cash sale party 00045 buys as 00050) and its GST split. */
const purchaseParty = (sale: SaleContext) =>
  sale.acCode.trim() === '00045'
    ? { acCode: '00050', interState: false }
    : { acCode: sale.acCode, interState: sale.interState };

/** One linked purchase as the sale read or save returns it. */
type LinkedSummary = {
  metal?: unknown;
  coBook?: unknown;
  vchNo?: unknown;
  amount?: unknown;
  netWt?: unknown;
};
const metalOf = (x: LinkedSummary): Metal => (x.metal === 'S' ? 'S' : 'G');

/** State, request body and screen node of the sale's linked old-gold / old-silver purchases. */
export function useLinkedOldPurchase(
  sale: SaleContext,
  afterDone: RefObject<HTMLInputElement | null>,
) {
  const [drafts, setDrafts] = useState<Partial<Record<Metal, Draft>>>({});
  const [locked, setLocked] = useState<Summary[] | null>(null);
  // The stored state the request is compared with: which metals are linked, on which party and date.
  const [base, setBase] = useState<{ metals: Metal[]; party: string; date: string } | null>(null);
  const [open, setOpen] = useState<Metal | null>(null);
  const rowsRef = useRef<HTMLDivElement>(null);
  const silverRef = useRef<HTMLButtonElement>(null);
  const goldRef = useRef<HTMLButtonElement>(null);

  const rows: Array<{ metal: Metal; amount: number; netWt: number; label: string }> = (
    ['G', 'S'] as const
  ).map((metal) => {
    const lockedRows = (locked ?? []).filter((s) => s.metal === metal);
    const d = drafts[metal];
    const amount = locked ? lockedRows.reduce((s, x) => s + x.amount, 0) : (d?.amount ?? 0);
    const netWt = locked ? lockedRows.reduce((s, x) => s + x.netWt, 0) : (d?.netWt ?? 0);
    const label = locked
      ? lockedRows.map((x) => `${x.coBook}/${x.vchNo}`).join(', ')
      : (d?.stored ?? (d ? 'not saved yet' : ''));
    return { metal, amount: r2(amount), netWt: r3(netWt), label };
  });
  const amount = sale.enabled ? r2(rows.reduce((s, r) => s + r.amount, 0)) : 0;

  const reset = () => {
    setDrafts({});
    setLocked(null);
    setBase(null);
    setOpen(null);
  };

  /** GET /sales/:vchNo `linkedOldPurchases[]`: the full purchase with the Purchase view right, else amounts only. */
  const load = (view: { linkedOldPurchases?: any[]; acCode?: unknown; vchDate?: unknown }) => {
    reset();
    const found = Array.isArray(view.linkedOldPurchases) ? view.linkedOldPurchases : [];
    if (!found.length) return;
    setBase({
      metals: found.map(metalOf),
      party: String(view.acCode ?? ''),
      date: String(view.vchDate ?? ''),
    });
    if (found.some((x) => !x.purchase)) {
      setLocked(
        found.map((x) => ({
          metal: x.metal === 'S' ? 'S' : 'G',
          coBook: String(x.coBook ?? ''),
          vchNo: String(x.vchNo ?? ''),
          amount: Number(x.amount ?? 0),
          netWt: Number(x.netWt ?? 0),
        })),
      );
      return;
    }
    const next: Partial<Record<Metal, Draft>> = {};
    for (const x of found) {
      const metal: Metal = x.metal === 'S' ? 'S' : 'G';
      next[metal] = {
        ...draftFromView(x.purchase, Number(x.amount ?? 0), Number(x.netWt ?? 0)),
        stored: `${x.coBook}/${x.vchNo}`,
      };
    }
    setDrafts(next);
  };

  /**
   * The request's `linkedOldPurchase`. Omitted on a non-T book, when the operator may not view the stored purchases,
   * and when nothing changed: the server then keeps the stored purchases (checking they still match the sale's party
   * and date), so an edit of the sale alone needs no Purchase right. Present, it is authoritative for both metals (a
   * metal it does not carry is deleted), so when one metal changed, the other stored one is sent as it is.
   */
  const body = () => {
    if (!sale.enabled || locked) return undefined;
    const stored = base?.metals ?? [];
    const changed =
      stored.some((m) => !drafts[m]) ||
      (['G', 'S'] as const).some((m) => drafts[m]?.dirty) ||
      (!!base &&
        !!(drafts.G || drafts.S) &&
        (base.party !== sale.acCode || base.date !== sale.vchDate));
    if (!changed) return undefined;
    const { interState } = purchaseParty(sale);
    return {
      ...(drafts.G ? { gold: purchaseBody(drafts.G, interState) } : {}),
      ...(drafts.S ? { silver: purchaseBody(drafts.S, interState) } : {}),
    };
  };

  /** After a save: the stored amounts (POST/PUT `linkedOldPurchases`) become the rows and the new baseline. */
  const saved = (response: { linkedOldPurchases?: LinkedSummary[] }, sent: boolean) => {
    if (!sent || !sale.enabled || locked) return;
    const found = Array.isArray(response.linkedOldPurchases) ? response.linkedOldPurchases : [];
    setBase({ metals: found.map(metalOf), party: sale.acCode, date: sale.vchDate });
    setDrafts((all) => {
      const next: Partial<Record<Metal, Draft>> = {};
      for (const x of found) {
        const d = all[metalOf(x)];
        if (!d) continue;
        next[metalOf(x)] = {
          ...d,
          amount: Number(x.amount ?? 0),
          netWt: Number(x.netWt ?? 0),
          stored: `${String(x.coBook ?? '')}/${String(x.vchNo ?? '')}`,
          dirty: false,
        };
      }
      return next;
    });
  };

  // While the purchase is open the sale form is inert (as OrderAdvanceConfirm): no book switch or save behind it.
  // Closing returns focus in the same commit that removes the dialog: the previous run's cleanup has already lifted
  // `inert`, so the row (or the next field) takes focus before anything else can observe the closed dialog. A deferred
  // focus (setTimeout) left a window in which focus sat on <body>.
  const focusAfter = useRef<() => HTMLElement | null>(null);
  useLayoutEffect(() => {
    const form = rowsRef.current?.closest('form');
    if (!open) {
      const target = focusAfter.current?.();
      focusAfter.current = null;
      target?.focus();
      return;
    }
    if (!form) return;
    form.setAttribute('inert', '');
    return () => form.removeAttribute('inert');
  }, [open]);

  /**
   * TR_SALE.cs:19125-19150: a T-book sale on the cash party 00045 with linked old metal takes the desktop's own cash
   * figure (the server refuses any other, linkedOldMetal.ts). Old above the bill: no cash, the excess paid back.
   */
  const walkInCash = (p: {
    total: number;
    advance: number;
    kasar: number;
    upi: number;
    digits: 0 | 2;
  }): { cash: number; paid: number } | null => {
    if (!sale.enabled || sale.acCode.trim() !== '00045' || amount === 0) return null;
    const r = (v: number) => (p.digits === 2 ? r2(v) : dotNetRoundDouble(v, 0));
    if (amount > p.total) return { cash: 0, paid: r(amount - p.total) };
    return { cash: r(p.total - amount - p.advance - p.kasar - p.upi), paid: 0 };
  };

  const close = (metal: Metal) => {
    focusAfter.current = () => (metal === 'G' ? goldRef : silverRef).current;
    setOpen(null);
  };

  const node = sale.enabled ? (
    <div className="row" style={{ marginTop: 10 }} data-testid="sales-linked-old" ref={rowsRef}>
      {rows.map((row) => (
        <div className="field" key={row.metal}>
          <label>Old {WORD[row.metal]}</label>
          <div className="toolbar">
            <button
              type="button"
              className="ghost"
              ref={row.metal === 'G' ? goldRef : silverRef}
              disabled={!!locked}
              title={
                locked
                  ? 'You may not view Purchase: the linked purchase is shown and kept as stored'
                  : undefined
              }
              onClick={() => setOpen(row.metal)}
            >
              Old {WORD[row.metal]} purchase…
            </button>
            <span data-testid={`sales-old-${KEY[row.metal]}-amount`}>{money(row.amount)}</span>
            <span className="muted" data-testid={`sales-old-${KEY[row.metal]}-wt`}>
              {row.netWt.toFixed(3)} g{row.label ? ` · ${row.label}` : ''}
            </span>
            {!locked && drafts[row.metal] && (
              <button
                type="button"
                className="danger"
                aria-label={`Remove Old ${WORD[row.metal]} purchase`}
                onClick={() => setDrafts(({ [row.metal]: _gone, ...rest }) => rest)}
              >
                ×
              </button>
            )}
          </div>
        </div>
      ))}
      {open && (
        <LinkedOldPurchaseModal
          metal={open}
          draft={drafts[open]}
          sale={sale}
          onCancel={() => close(open)}
          onRemove={() => {
            setDrafts(({ [open]: _gone, ...rest }) => rest);
            close(open);
          }}
          onDone={(d) => {
            const before = drafts[open];
            const dirty = !before || before.dirty || signature(before) !== signature(d);
            setDrafts((all) => ({ ...all, [open]: { ...d, dirty } }));
            focusAfter.current = () => (open === 'G' ? silverRef.current : afterDone.current);
            setOpen(null);
          }}
        />
      )}
    </div>
  ) : null;

  return { amount, load, reset, body, saved, walkInCash, node };
}

type UrdResolved = { coBook: string; bookName: string } | { error: string };

function LinkedOldPurchaseModal({
  metal,
  draft,
  sale,
  onCancel,
  onRemove,
  onDone,
}: {
  metal: Metal;
  draft: Draft | undefined;
  sale: SaleContext;
  onCancel: () => void;
  onRemove: () => void;
  onDone: (draft: Omit<Draft, 'dirty'>) => void;
}) {
  const pricing = usePurchasePricing();
  // URD books skip the default tax code 10 (TR_PURC.cs:11657): a new linked purchase starts at 0% tax.
  const [lines, setLines] = useState<PurchaseLine[]>(
    () => draft?.lines ?? [blankPurchaseLine(metal)],
  );
  const [taxRatePct, setTaxRatePct] = useState(draft?.taxRatePct ?? '0');
  const { acCode: party, interState } = purchaseParty(sale);
  const [discountAmount, setDiscountAmount] = useState(draft?.discountAmount ?? '');
  const [roundOff, setRoundOff] = useState(draft?.roundOff ?? '');
  const [fullGrid, setFullGrid] = useState(false);
  const [book, setBook] = useState<UrdResolved | null>(null);
  const [msg, setMsg] = useState('');
  const box = useRef<HTMLDivElement>(null);
  const setLine = pricing.lineSetter(setLines);
  const { taxable, taxPrev, totalPrev } = pricing.bill({
    lines,
    discountAmount,
    taxRatePct,
    interState,
    roundOff,
  });
  const netWt = r3(lines.filter(filled).reduce((s, l) => s + n(l.netWt), 0));
  const onGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blankPurchaseLine(metal)]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blankPurchaseLine(metal)] : rows.filter((_, i) => i !== row),
      );
      return true;
    },
    // Escape leaves the grid for Done (as the sale grid's Escape leaves for Cash), or Cancel while Done is disabled;
    // a second Escape closes.
    onEscape: () =>
      (
        box.current?.querySelector<HTMLButtonElement>('button.primary:not([disabled])') ??
        box.current?.querySelector<HTMLButtonElement>('[data-cancel]')
      )?.focus(),
  });

  // The URD book the server will use (urdBook.ts), or its message telling the operator how to create one.
  useEffect(() => {
    let live = true;
    get<{ resolved: Record<'gold' | 'silver', UrdResolved> }>('/sales/urd-books')
      .then((v) => live && setBook(v.resolved[KEY[metal]]))
      .catch(() => live && setBook({ error: 'The old gold purchase book could not be read' }));
    return () => {
      live = false;
    };
  }, [metal]);
  useEffect(() => {
    if (book && !('error' in book))
      box.current?.querySelector<HTMLInputElement>('table.grid tbody input')?.focus();
    else if (book) box.current?.querySelector<HTMLButtonElement>('button:not([disabled])')?.focus();
  }, [book]);

  // Escape closes the dialog wherever focus is (the sale form behind it is inert).
  useEffect(() => {
    const onDoc = (e: globalThis.KeyboardEvent) => {
      if (e.key !== 'Escape' || e.defaultPrevented || box.current?.contains(e.target as Node))
        return;
      e.preventDefault();
      onCancel();
    };
    document.addEventListener('keydown', onDoc);
    return () => document.removeEventListener('keydown', onDoc);
  }, [onCancel]);

  // Desktop-like Enter: a header field moves to the next one; the grid has its own walk (GridKeyboard).
  // Tab is trapped in the dialog.
  const onKeyDown = (e: KeyboardEvent<HTMLDivElement>) => {
    if (e.defaultPrevented) return;
    if (e.key === 'Tab') {
      const focusable = Array.from(
        box.current?.querySelectorAll<HTMLElement>('input,select,button,textarea,[tabindex]') ?? [],
      ).filter((el) => !(el as HTMLInputElement).disabled && el.tabIndex >= 0);
      const first = focusable[0];
      const last = focusable[focusable.length - 1];
      if (e.shiftKey && document.activeElement === first) {
        e.preventDefault();
        last?.focus();
      } else if (!e.shiftKey && document.activeElement === last) {
        e.preventDefault();
        first?.focus();
      }
      return;
    }
    if (e.key === 'Escape') {
      e.preventDefault();
      e.stopPropagation();
      onCancel();
      return;
    }
    const target = e.target as HTMLElement;
    if (e.key !== 'Enter' || target.closest('table') || target.tagName === 'BUTTON') return;
    e.preventDefault();
    const all = Array.from(
      box.current?.querySelectorAll<HTMLElement>('input:not([readonly]),select,button') ?? [],
    ).filter((el) => !(el as HTMLInputElement).disabled);
    all[all.indexOf(target) + 1]?.focus();
  };

  const done = () => {
    if (!lines.some(filled)) {
      setMsg(`Enter at least one Old ${WORD[metal]} line (item and net weight or rate)`);
      return;
    }
    onDone({
      lines,
      taxRatePct,
      discountAmount,
      roundOff,
      view: draft?.view ?? null,
      amount: r2(totalPrev),
      netWt,
      stored: draft?.stored,
    });
  };

  const ro = (label: string, value: string) => (
    <div className="field">
      <label>{label}</label>
      <input aria-label={`Old ${WORD[metal]} ${label}`} value={value} readOnly />
    </div>
  );

  return createPortal(
    <div
      ref={box}
      className="panel"
      role="dialog"
      aria-modal="true"
      aria-label={`Old ${WORD[metal]} purchase`}
      onKeyDown={onKeyDown}
      style={{
        position: 'fixed',
        top: '5vh',
        left: '50%',
        transform: 'translateX(-50%)',
        width: 'min(1100px, 96vw)',
        maxHeight: '90vh',
        overflow: 'auto',
        zIndex: 1000,
        boxShadow: '0 4px 24px rgba(0,0,0,.35)',
      }}
    >
      <h2 style={{ marginTop: 0 }}>Old {WORD[metal]} purchase</h2>
      {!book ? (
        <p className="muted">Loading the URD purchase book…</p>
      ) : 'error' in book ? (
        <div className="msg err" role="alert" data-testid="linked-old-no-book">
          {book.error}
        </div>
      ) : (
        <>
          <div className="row">
            {ro('Book', `${book.coBook} — ${book.bookName}`)}
            {ro(
              'Party',
              party === sale.acCode ? `${party} ${sale.acName}`.trim() : `${party} (cash purchase)`,
            )}
            {ro('Date', sale.vchDate)}
            {ro('Sale Bill', `${sale.coBook}/${sale.vchNo || 'new'}`)}
            <div className="field">
              <label>Tax %</label>
              <input value={taxRatePct} onChange={(e) => setTaxRatePct(e.target.value)} />
            </div>
            <div className="field">
              <label>Discount ₹</label>
              <input value={discountAmount} onChange={(e) => setDiscountAmount(e.target.value)} />
            </div>
            {ro('Inter-state', interState ? 'Yes (IGST)' : 'No (CGST+SGST)')}
            {!pricing.tdsOn && (
              <div className="field">
                <label>Round Off</label>
                <input value={roundOff} onChange={(e) => setRoundOff(e.target.value)} />
              </div>
            )}
          </div>
          <PurchaseLineGrid
            lines={lines}
            setLines={setLines}
            setLine={setLine}
            pricing={pricing}
            fullGrid={fullGrid}
            setFullGrid={setFullGrid}
            testId="linked-old-grid-mode"
            onGridKey={onGridKey}
            onRemoveLine={(i) => setLines((ls) => ls.filter((_, j) => j !== i))}
          />
          <PurchaseLineDetails lines={lines} fullGrid={fullGrid} setLine={setLine} />
          <p className="muted" data-testid="linked-old-totals">
            Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹{taxPrev.toLocaleString('en-IN')} ·{' '}
            <b>Amount ₹{money(r2(totalPrev))}</b> · Net Wt {netWt.toFixed(3)} g
          </p>
        </>
      )}
      {pricing.settingsState.status === 'error' && (
        <p className="msg err" data-testid="linked-old-settings-error">
          Company settings could not be read, so the purchase amount cannot be computed as the
          server stores it: Done is disabled. Reload the page, or ask for the Settings view right.
        </p>
      )}
      {msg && <div className="msg err">{msg}</div>}
      <div className="toolbar">
        <button
          type="button"
          className="ghost"
          onClick={() => setLines((ls) => [...ls, blankPurchaseLine(metal)])}
          disabled={!book || 'error' in book}
        >
          + Add line
        </button>
        <span className="spacer" />
        {draft && (
          <button type="button" className="danger" onClick={onRemove}>
            Remove
          </button>
        )}
        <button type="button" className="ghost" data-cancel onClick={onCancel}>
          Cancel
        </button>
        <button
          type="button"
          className="primary"
          onClick={done}
          disabled={!book || 'error' in book || !pricing.settingsReady}
        >
          Done
        </button>
      </div>
    </div>,
    document.body,
  );
}
