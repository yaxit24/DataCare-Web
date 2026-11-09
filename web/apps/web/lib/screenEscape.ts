'use client';
import { useEffect, useRef, type RefObject } from 'react';

/**
 * The fields a screen's Esc handler reads. Both a React keyboard event (the wrapper's `onKeyDown`) and a native one (the
 * document listener below) satisfy it, so one handler serves both.
 */
export interface ScreenKeyEvent {
  key: string;
  ctrlKey: boolean;
  target: EventTarget | null;
  defaultPrevented: boolean;
  preventDefault(): void;
}

/**
 * True when a key aimed at `target` belongs to the screen although it missed the screen's wrapper: the target is an
 * ancestor of the screen (the page body or a page container), not the screen itself and not anything inside it. A key
 * aimed inside the screen already reaches the wrapper's own `onKeyDown`; one aimed at the header or sidebar controls
 * (the MDI parent, not the form) stays theirs.
 */
export function isKeyAroundScreen(screen: Node | null, target: EventTarget | null): boolean {
  if (!screen || !target || typeof (target as Node).contains !== 'function') return false;
  const node = target as Node;
  return node !== screen && node.contains(screen);
}

/**
 * Esc closes the screen even when no control has the focus (GB-02, the G239 fix of Tag Print made shared).
 *
 * Every desktop master and the opening forms set `KeyPreview = true` and subscribe their own `KeyDown`, so their Esc
 * branch runs whichever control has the focus (for example MS_ACCT.cs:5559, :3962, :6760-6762; UT_TAG_PRINT.cs:1805,
 * :1154, :5101-5109). A browser has a state the desktop form never has: the focus on no control at all, after a click
 * on the page background or when the focused button is disabled. A key aimed at the page body never reaches a React
 * handler on the screen's wrapper, so this hook takes Esc at the document and hands it to the same handler. Only Esc is
 * forwarded: the screen's other keys keep their present scope.
 *
 * Usage: `const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);` then
 * `<div ref={screenRef} onKeyDown={onScreenKeyDown}>`. The handler keeps deciding what Esc does (close an open help or
 * lookup first, refuse while there are unsaved changes, and so on); it always sees the newest render's state.
 */
export function useScreenEscape<T extends HTMLElement>(
  onScreenKeyDown: (event: ScreenKeyEvent) => void,
): RefObject<T | null> {
  const screenRef = useRef<T | null>(null);
  const handler = useRef(onScreenKeyDown);
  handler.current = onScreenKeyDown;
  useEffect(() => {
    const onPageKeyDown = (event: KeyboardEvent) => {
      if (event.key !== 'Escape' || !isKeyAroundScreen(screenRef.current, event.target)) return;
      handler.current(event);
    };
    document.addEventListener('keydown', onPageKeyDown);
    return () => document.removeEventListener('keydown', onPageKeyDown);
  }, []);
  return screenRef;
}
