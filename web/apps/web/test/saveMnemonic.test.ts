import { describe, expect, it, vi } from 'vitest';
import {
  findSaveButton,
  isSaveMnemonic,
  SAVE_MNEMONIC_ATTRIBUTE,
  type ButtonLike,
} from '../lib/saveMnemonic';

/** G171: the desktop saves with the &Save mnemonic, Alt+S (TR_SALE.cs:4896); there is no Ctrl+S binding. */
describe('isSaveMnemonic', () => {
  it('accepts Alt+S by physical key, including Option+S on a Mac that types ß', () => {
    expect(isSaveMnemonic({ altKey: true, code: 'KeyS', key: 's' })).toBe(true);
    expect(isSaveMnemonic({ altKey: true, code: 'KeyS', key: 'ß' })).toBe(true);
    expect(isSaveMnemonic({ altKey: true, key: 'S' })).toBe(true);
  });
  it('refuses other chords: Ctrl+S, Alt+Shift+S, Ctrl+Alt+S, Meta+Alt+S, plain S, Alt+D', () => {
    expect(isSaveMnemonic({ ctrlKey: true, code: 'KeyS' })).toBe(false);
    expect(isSaveMnemonic({ altKey: true, shiftKey: true, code: 'KeyS' })).toBe(false);
    expect(isSaveMnemonic({ altKey: true, ctrlKey: true, code: 'KeyS' })).toBe(false);
    expect(isSaveMnemonic({ altKey: true, metaKey: true, code: 'KeyS' })).toBe(false);
    expect(isSaveMnemonic({ code: 'KeyS', key: 's' })).toBe(false);
    expect(isSaveMnemonic({ altKey: true, code: 'KeyD', key: 'd' })).toBe(false);
  });
  it('ignores auto-repeat, so a held Alt+S cannot submit twice', () => {
    expect(isSaveMnemonic({ altKey: true, code: 'KeyS', repeat: true })).toBe(false);
  });
});

describe('findSaveButton', () => {
  const button = (over: Partial<ButtonLike> & { shown?: boolean } = {}): ButtonLike => ({
    disabled: over.disabled ?? false,
    getClientRects: () => ({ length: over.shown === false ? 0 : 1 }),
    click: over.click ?? vi.fn(),
  });
  const root = (buttons: ButtonLike[]) => ({
    querySelectorAll: (selector: string) => {
      expect(selector).toBe(`button[${SAVE_MNEMONIC_ATTRIBUTE}]`);
      return buttons;
    },
  });

  it('returns the first marked button that is enabled and on screen', () => {
    const hidden = button({ shown: false });
    const disabled = button({ disabled: true });
    const live = button();
    expect(findSaveButton(root([hidden, disabled, live]))).toBe(live);
  });
  it('returns nothing when the screen has no usable save button (Alt+S then does nothing)', () => {
    expect(findSaveButton(root([]))).toBeNull();
    expect(findSaveButton(root([button({ disabled: true })]))).toBeNull();
  });
});
