/**
 * The desktop's &Save mnemonic: Alt+S presses the form's Save button.
 *
 * `TR_SALE.cs:4896` captions the button `BtnSave.Text = "&Save"`, and 106 desktop forms caption their save
 * button the same way, so Alt+S saves on every one of them. The desktop has no Ctrl+S binding (G171).
 *
 * A screen opts in by marking its save button with `data-save-mnemonic`; the shell's global key handler
 * (`GlobalFormKeys`) presses the first marked button that is enabled and on screen. The physical key (`code`) is
 * matched rather than the character, because Option+S on a Mac types "ß". A held key's auto-repeat is ignored, so
 * holding Alt+S cannot submit the voucher twice.
 */
export const SAVE_MNEMONIC_ATTRIBUTE = 'data-save-mnemonic';

export interface KeyLike {
  key?: string;
  code?: string;
  altKey?: boolean;
  ctrlKey?: boolean;
  metaKey?: boolean;
  shiftKey?: boolean;
  repeat?: boolean;
}

/** Alt+S and nothing else: no Ctrl, Meta or Shift, and not an auto-repeat. */
export function isSaveMnemonic(event: KeyLike): boolean {
  if (!event.altKey || event.ctrlKey || event.metaKey || event.shiftKey || event.repeat)
    return false;
  if (event.code) return event.code === 'KeyS';
  return (event.key ?? '').toLowerCase() === 's';
}

export interface ButtonLike {
  disabled?: boolean;
  getClientRects(): { length: number };
  click(): void;
}

/** The first marked save button that is enabled and rendered (a hidden or collapsed one has no client rects). */
export function findSaveButton(root: {
  querySelectorAll(selector: string): ArrayLike<ButtonLike>;
}): ButtonLike | null {
  const marked = Array.from(root.querySelectorAll(`button[${SAVE_MNEMONIC_ATTRIBUTE}]`));
  return marked.find((button) => !button.disabled && button.getClientRects().length > 0) ?? null;
}
