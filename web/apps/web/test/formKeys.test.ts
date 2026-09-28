import { describe, expect, it, vi } from 'vitest';
import {
  ALL_FORM_KEYS,
  CTRL_FORM_KEYS,
  desktopGlobalFormKeyActions,
  FORM_KEYS,
  resolveFormKey,
  type FormKey,
} from '../components/FormKeys';

const expected = {
  F2: 'ledger-report',
  F3: 'stock-report',
  F4: 'sales-order',
  F5: 'sales-bill',
  F6: 'wholesale-sales',
  F7: 'purchase-bill',
  F8: 'cash-received',
  F9: 'cash-payment',
  F11: 'rojmel',
  F12: 'tag-stock',
  // Ctrl chords, destinations read from the MDI handler bodies (MDI_FORM.cs:12458-12530).
  'Ctrl+F1': 'daily-rate',
  'Ctrl+F2': 'order-zoom',
  'Ctrl+F5': 'bill-wise-receipt',
  'Ctrl+F6': 'rate-cut',
  'Ctrl+F8': 'bank-receipt',
  'Ctrl+F9': 'bank-payment',
  'Ctrl+F11': 'cash-bank-report',
  'Ctrl+F12': 'tag-estimate',
} as const satisfies Partial<Record<FormKey, string>>;

/**
 * The desktop's bound virtual-key codes, transcribed from the handler chain at
 * MDI_FORM.cs:12462-12525: VK 113-120 then 122-123. Deriving the expected key set from these
 * rather than restating it means a key the desktop binds cannot be dropped from the web without
 * this test failing, and a key it does NOT bind cannot be added without failing either.
 *
 * VK 121 (F10) is absent from the desktop handler despite the "F10 Reminder" menu caption, so it
 * must stay unbound here too.
 */
const DESKTOP_BOUND_VK = [113, 114, 115, 116, 117, 118, 119, 120, 122, 123] as const;
const vkToKey = (vk: number): string => `F${vk - 111}`;

/**
 * Chords whose destination report is not built. Now empty: RP_ORDER and RP_TAG_ESTMATE were the last two
 * and both exist. The list is kept so a future chord cannot be added without declaring the gap.
 */
// Every Ctrl chord the desktop binds now has a destination. Kept as an empty list rather than deleted, so
// that adding a chord without a destination still has to declare it here deliberately.
const UNMAPPED_CHORDS: readonly FormKey[] = [];

describe('desktop global function-key decision table', () => {
  it('maps every implemented key to its cited desktop action', () => {
    const actions = desktopGlobalFormKeyActions(vi.fn());
    for (const key of FORM_KEYS) {
      expect(actions[key]?.id).toBe(expected[key as keyof typeof expected]);
      expect(resolveFormKey({ key, registeredKeys: FORM_KEYS })).toEqual({
        type: 'invoke',
        key,
      });
    }
  });

  it('resolves every Ctrl chord the desktop implements', () => {
    const actions = desktopGlobalFormKeyActions(vi.fn());
    for (const chord of CTRL_FORM_KEYS) {
      const base = chord.replace('Ctrl+', '');
      const decision = resolveFormKey({
        key: base,
        ctrlKey: true,
        registeredKeys: ALL_FORM_KEYS,
      });
      // Ctrl was previously discarded outright, so every one of these returned { type: 'none' }.
      expect(decision, chord).toEqual({ type: 'invoke', key: chord });
      const mapped = (expected as Record<string, string>)[chord];
      if (mapped) expect(actions[chord]?.id, chord).toBe(mapped);
      else expect(actions[chord], `${chord} must stay unmapped`).toBeUndefined();
    }
    for (const chord of UNMAPPED_CHORDS) {
      expect(actions[chord], `${chord} destination is not built`).toBeUndefined();
    }
  });

  it('does not confuse a plain key with its Ctrl chord', () => {
    // Plain F1 is the lookup/help key and must not trigger the Ctrl+F1 daily-rate action.
    expect(resolveFormKey({ key: 'F1', registeredKeys: ALL_FORM_KEYS })).toEqual({ type: 'none' });
    expect(resolveFormKey({ key: 'F1', ctrlKey: true, registeredKeys: ALL_FORM_KEYS })).toEqual({
      type: 'invoke',
      key: 'Ctrl+F1',
    });
    // Adding another modifier disqualifies the press: the desktop binds no Shift/Alt combinations.
    expect(
      resolveFormKey({ key: 'F2', ctrlKey: true, shiftKey: true, registeredKeys: ALL_FORM_KEYS }),
    ).toEqual({ type: 'none' });
    expect(
      resolveFormKey({ key: 'F2', ctrlKey: true, altKey: true, registeredKeys: ALL_FORM_KEYS }),
    ).toEqual({ type: 'none' });
  });

  it('binds exactly the plain keys the desktop binds, no more and no fewer', () => {
    const actions = desktopGlobalFormKeyActions(vi.fn());
    const desktopKeys = DESKTOP_BOUND_VK.map(vkToKey).sort();
    expect([...FORM_KEYS].sort()).toEqual(desktopKeys);
    // F6 is bound by the desktop (VK 117 -> ShoF6WhSales_Click -> TR_WH_SALE) and must resolve.
    expect(resolveFormKey({ key: 'F6', registeredKeys: FORM_KEYS })).toEqual({
      type: 'invoke',
      key: 'F6',
    });
    expect(actions.F6?.id).toBe('wholesale-sales');
    // F10 is NOT bound by the desktop: VK 121 has no branch. It must stay inert.
    expect(DESKTOP_BOUND_VK).not.toContain(121);
    expect(resolveFormKey({ key: 'F10', registeredKeys: FORM_KEYS })).toEqual({ type: 'none' });
  });

  it('leaves unregistered and unsupported keys inert', () => {
    expect(resolveFormKey({ key: 'F2', registeredKeys: [] })).toEqual({ type: 'none' });
    expect(resolveFormKey({ key: 'F10', registeredKeys: FORM_KEYS })).toEqual({ type: 'none' });
    expect(resolveFormKey({ key: 'Enter', registeredKeys: FORM_KEYS })).toEqual({ type: 'none' });
  });

  it('suppresses registered keys while a lookup or modal overlay is open', () => {
    expect(resolveFormKey({ key: 'F7', registeredKeys: FORM_KEYS, overlayOpen: true })).toEqual({
      type: 'none',
    });
  });

  it('does not misread modified, repeated, or already-handled combinations', () => {
    for (const modified of [
      { ctrlKey: true },
      { metaKey: true },
      { altKey: true },
      { shiftKey: true },
      { repeat: true },
      { defaultPrevented: true },
    ]) {
      expect(resolveFormKey({ key: 'F5', registeredKeys: FORM_KEYS, ...modified })).toEqual({
        type: 'none',
      });
    }
  });
});
