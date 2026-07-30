'use client';
import { useEffect } from 'react';
import { focusNext } from './focus';

/**
 * Desktop-style keyboard-first data entry, installed app-wide:
 *  • Enter in a plain input advances to the next visible control.
 *  • Enter on the last field falls through to native form submission.
 *  • Ctrl/Cmd+Enter submits the enclosing form from any focused control.
 * Controls can opt out of plain-Enter traversal with data-no-advance.
 */
export function KeyboardNav() {
  useEffect(() => {
    const onKey = (event: KeyboardEvent) => {
      if (event.key !== 'Enter' || event.defaultPrevented) return;
      const element = event.target as HTMLElement | null;
      const form = element?.closest('form');
      if (!element || !form) return;

      if (event.ctrlKey || event.metaKey) {
        event.preventDefault();
        (form as HTMLFormElement).requestSubmit();
        return;
      }
      if (!(element instanceof HTMLInputElement) || event.altKey || event.shiftKey) return;
      const type = (element.type || 'text').toLowerCase();
      if (['submit', 'button', 'checkbox', 'radio', 'file'].includes(type)) return;
      if (element.hasAttribute('data-no-advance')) return;
      if (focusNext(element, form)) event.preventDefault();
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, []);
  return null;
}
