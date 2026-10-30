'use client';
import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { desktopGlobalFormKeyActions, useFormKeys } from './FormKeys';
import { findSaveButton, isSaveMnemonic } from '../lib/saveMnemonic';

/**
 * Installs the desktop MDI shell's global accelerators on every authenticated page.
 *
 * The desktop binds these in `MDI_FORM.cs` — the shell, not the individual forms — so F2/F3/F4/F5/F7/F8/
 * F9/F11/F12 and the Ctrl chords work from anywhere in the application. The web previously mounted
 * `FormKeyHints` on 13 transaction pages only, so on the other ~87 pages (including the dashboard, every
 * master and every report) NONE of the accelerators existed. Mounting here restores the desktop's actual
 * scope.
 *
 * This component renders nothing: the visible hint bar stays a per-page concern, while the key bindings
 * themselves are global exactly as the desktop has them.
 */
export function GlobalFormKeys() {
  const router = useRouter();
  useFormKeys(desktopGlobalFormKeyActions((href) => router.push(href)));
  // The &Save mnemonic (G171): Alt+S presses the screen's marked save button, from any field.
  useEffect(() => {
    const onKeyDown = (event: KeyboardEvent) => {
      if (!isSaveMnemonic(event)) return;
      const button = findSaveButton(document);
      if (!button) return;
      event.preventDefault();
      event.stopPropagation();
      button.click();
    };
    document.addEventListener('keydown', onKeyDown, true);
    return () => document.removeEventListener('keydown', onKeyDown, true);
  }, []);
  return null;
}
