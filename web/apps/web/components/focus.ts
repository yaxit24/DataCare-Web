export const FOCUSABLE_SELECTOR =
  'input:not([type="hidden"]),select,textarea,button,a[href],[tabindex]:not([tabindex="-1"])';

type DisableableElement = HTMLElement & { disabled?: boolean };

function isVisible(element: HTMLElement): boolean {
  if (element.hidden || element.getAttribute('aria-hidden') === 'true') return false;
  const style = window.getComputedStyle(element);
  return style.display !== 'none' && style.visibility !== 'hidden';
}

export function focusableElements(root: ParentNode): HTMLElement[] {
  return Array.from(root.querySelectorAll<HTMLElement>(FOCUSABLE_SELECTOR)).filter((element) => {
    if ((element as DisableableElement).disabled) return false;
    if (element.tabIndex < 0) return false;
    return isVisible(element);
  });
}

function isSubmitControl(element: HTMLElement): boolean {
  if (element instanceof HTMLButtonElement) return (element.type || 'submit') === 'submit';
  return element instanceof HTMLInputElement && element.type.toLowerCase() === 'submit';
}

/** Focus the next visible form control without landing on a submit control. */
export function focusNext(current: HTMLElement, root?: ParentNode): boolean {
  const scope = root ?? current.closest('form') ?? document.body;
  const elements = focusableElements(scope);
  const index = elements.indexOf(current);
  const next = index >= 0 ? elements[index + 1] : undefined;
  if (!next || isSubmitControl(next)) return false;
  next.focus();
  return document.activeElement === next;
}
