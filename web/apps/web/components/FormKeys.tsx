'use client';

import { useEffect, useRef } from 'react';

export const FORM_KEYS = ['F2', 'F3', 'F4', 'F5', 'F7', 'F8', 'F9', 'F11', 'F12'] as const;
export type PlainFormKey = (typeof FORM_KEYS)[number];

/**
 * Ctrl-modified accelerators. The desktop MDI shell implements these alongside the plain F-keys
 * (`MDI_FORM.cs:12458-12530`), using the decompiled idiom `keyCode == (0x71 & (0 - (e.Control ? 1 : 0)))`
 * — the mask is all-ones only while Control is held, so the comparison matches Ctrl+F2 and nothing else.
 *
 * These were entirely unreachable in the web app: `resolveFormKey` returned `none` for ANY ctrlKey press,
 * so all eight desktop chords silently did nothing. For a counter operator these are the fastest paths in
 * the product.
 */
export const CTRL_FORM_KEYS = [
  'Ctrl+F1',
  'Ctrl+F2',
  'Ctrl+F5',
  'Ctrl+F6',
  'Ctrl+F8',
  'Ctrl+F9',
  'Ctrl+F11',
  'Ctrl+F12',
] as const;
export type CtrlFormKey = (typeof CTRL_FORM_KEYS)[number];
export type FormKey = PlainFormKey | CtrlFormKey;
export const ALL_FORM_KEYS: readonly FormKey[] = [...FORM_KEYS, ...CTRL_FORM_KEYS];
export type FormKeyActionId =
  | 'daily-rate'
  | 'bill-wise-receipt'
  | 'rate-cut'
  | 'bank-receipt'
  | 'bank-payment'
  | 'cash-bank-report'
  | 'ledger-report'
  | 'stock-report'
  | 'sales-order'
  | 'sales-bill'
  | 'purchase-bill'
  | 'cash-received'
  | 'cash-payment'
  | 'rojmel'
  | 'tag-stock'
  | 'order-zoom'
  | 'tag-estimate';

export interface FormKeyAction {
  id: FormKeyActionId;
  label: string;
  run: () => void;
}

export type FormKeyActions = Partial<Record<FormKey, FormKeyAction>>;

export interface FormKeyContext {
  key: string;
  registeredKeys: readonly FormKey[];
  defaultPrevented?: boolean;
  ctrlKey?: boolean;
  metaKey?: boolean;
  altKey?: boolean;
  shiftKey?: boolean;
  repeat?: boolean;
  overlayOpen?: boolean;
}

export type FormKeyDecision = { type: 'invoke'; key: FormKey } | { type: 'none' };

/**
 * Pure decision table. An exact registered desktop accelerator may be consumed; anything else falls through
 * to the browser.
 *
 * Ctrl is now a MEANINGFUL modifier because the desktop uses it, but Alt, Shift and Meta still disqualify a
 * press: the desktop binds none of those, and swallowing them would break browser and OS shortcuts.
 * Ctrl+Shift+F2 must therefore NOT trigger Ctrl+F2.
 */
export function resolveFormKey(context: FormKeyContext): FormKeyDecision {
  if (
    context.defaultPrevented ||
    context.metaKey ||
    context.altKey ||
    context.shiftKey ||
    context.repeat ||
    context.overlayOpen
  ) {
    return { type: 'none' };
  }
  const base = context.key.toUpperCase();
  if (!/^F([1-9]|1[0-2])$/.test(base)) return { type: 'none' };
  const key = (context.ctrlKey ? `Ctrl+${base}` : base) as FormKey;
  if (!ALL_FORM_KEYS.includes(key)) return { type: 'none' };
  if (!context.registeredKeys.includes(key)) return { type: 'none' };
  return { type: 'invoke', key };
}

function overlayOpen(): boolean {
  return Boolean(
    document.querySelector(
      'dialog[open], [role="dialog"][aria-modal="true"], [data-modal-open="true"], [data-lookup-open="true"]',
    ),
  );
}

/** Installs page-scoped accelerators. Inert keys retain their native browser behavior. */
export function useFormKeys(actions: FormKeyActions): void {
  const actionsRef = useRef(actions);
  actionsRef.current = actions;

  useEffect(() => {
    const onKeyDown = (event: KeyboardEvent): void => {
      const current = actionsRef.current;
      const registeredKeys = ALL_FORM_KEYS.filter((key) => Boolean(current[key]));
      const decision = resolveFormKey({
        key: event.key,
        registeredKeys,
        defaultPrevented: event.defaultPrevented,
        ctrlKey: event.ctrlKey,
        metaKey: event.metaKey,
        altKey: event.altKey,
        shiftKey: event.shiftKey,
        repeat: event.repeat,
        overlayOpen: overlayOpen(),
      });
      if (decision.type === 'none') return;
      const action = current[decision.key];
      if (!action) return;
      event.preventDefault();
      action.run();
    };
    document.addEventListener('keydown', onKeyDown);
    return () => document.removeEventListener('keydown', onKeyDown);
  }, []);
}

/**
 * Desktop MDI global map. Numeric VK bindings are in MDI_FORM.cs:12462-12525 and the
 * corresponding visible labels are in MDI_FORM.cs:5571-5601. Destination handlers are
 * MDI_FORM.cs:13918-14238.
 */
export function desktopGlobalFormKeyActions(navigate: (href: string) => void): FormKeyActions {
  return {
    F2: {
      id: 'ledger-report',
      label: 'Ledger report',
      run: () => navigate('/reports/account-ledger'),
    },
    F3: {
      id: 'stock-report',
      label: 'Stock report',
      run: () => navigate('/reports/stock-valuation'),
    },
    F4: { id: 'sales-order', label: 'Sales order', run: () => navigate('/txn/sales-order') },
    F5: { id: 'sales-bill', label: 'Sales bill', run: () => navigate('/txn/sales') },
    F7: { id: 'purchase-bill', label: 'Purchase bill', run: () => navigate('/txn/purchase') },
    F8: { id: 'cash-received', label: 'Cash received', run: () => navigate('/txn/receipt') },
    F9: { id: 'cash-payment', label: 'Cash payment', run: () => navigate('/txn/payment') },
    // Points at the real Rojmel now. It used to open /reports/day-book, which reads AC_DATA and shows
    // money only - not the same report: the desktop's Rojmel carries metal weights beside the money.
    F11: { id: 'rojmel', label: 'Rojmel', run: () => navigate('/reports/rojmel') },
    F12: { id: 'tag-stock', label: 'Tag stock', run: () => navigate('/reports/tag-stock') },

    // ---- Ctrl-modified accelerators (MDI_FORM.cs:12458-12530) ----
    // Each destination was read from the handler body rather than inferred from the caption:
    //   F1CtrlDailyRateToolStripMenuItem -> new MS_RATE(...)
    //   ShoCtrlF5BillRec                 -> new TR_BILL_TO(...)
    //   ShoCtrlF6RateCut                 -> new TR_WH_SALE(...)
    //   ShoCtrlF8BankRec / ShoCtrlF9BankPay -> new TR_CASH(...)
    //   F11CtrlCashBankToolStripMenuItem -> new RP_CASH_BANK(...)
    'Ctrl+F1': {
      id: 'daily-rate',
      label: 'Daily rate',
      run: () => navigate('/txn/daily-rate'),
    },
    'Ctrl+F5': {
      id: 'bill-wise-receipt',
      label: 'Bill-wise receipt',
      run: () => navigate('/txn/bill-to-bill'),
    },
    'Ctrl+F6': {
      id: 'rate-cut',
      label: 'Rate cut',
      run: () => navigate('/txn/wholesale-sale'),
    },
    // TR_CASH serves both; the desktop opens it in bank mode, which the web models as a mode on the
    // receipt/payment forms.
    'Ctrl+F8': {
      id: 'bank-receipt',
      label: 'Bank receipt',
      run: () => navigate('/txn/receipt?mode=BANK'),
    },
    'Ctrl+F9': {
      id: 'bank-payment',
      label: 'Bank payment',
      run: () => navigate('/txn/payment?mode=BANK'),
    },
    'Ctrl+F11': {
      id: 'cash-bank-report',
      label: 'Cash / bank book',
      run: () => navigate('/reports/cash-book'),
    },
    // Previously unmapped because their destinations did not exist. Both report families are now built,
    // so the chords point at the real screens rather than a near-miss page.
    // MDI_FORM.cs:7147 'Order Zoom' -> RP_ORDER; MDI_FORM.cs:8994 'Tag Estmate' -> RP_TAG_ESTMATE.
    'Ctrl+F2': {
      id: 'order-zoom',
      label: 'Order zoom',
      run: () => navigate('/reports/order-lot-zoom'),
    },
    'Ctrl+F12': {
      id: 'tag-estimate',
      label: 'Tag estimate',
      run: () => navigate('/reports/tag-estimate'),
    },
  };
}

/** Visible buttons make every accelerator keyboard- and screen-reader-accessible without F-keys. */
export function FormKeyHints({ actions }: { actions: FormKeyActions }) {
  useFormKeys(actions);
  return (
    <nav className="toolbar form-key-hints" aria-label="Desktop keyboard shortcuts">
      {ALL_FORM_KEYS.map((key) => {
        const action = actions[key];
        if (!action) return null;
        return (
          <button
            key={key}
            type="button"
            className="ghost"
            aria-label={`${key}: ${action.label}`}
            onClick={action.run}
          >
            <kbd>{key}</kbd> {action.label}
          </button>
        );
      })}
    </nav>
  );
}
