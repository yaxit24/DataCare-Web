import { SALES_BUTTONS, type SalesButton } from './types';

/** The mnemonic letter of a WinForms caption: the character after `&` (RP_ALL.cs:4723 "&Sales Report"). */
export function keyOf(caption: string): string | null {
  const at = caption.indexOf('&');
  return at >= 0 ? (caption[at + 1] ?? '').toUpperCase() : null;
}

/**
 * PanelSale (RP_ALL.cs:4364-4378): the 13 Lite buttons in tab order. A button whose report the API does not serve yet is
 * shown, disabled and titled "Not available yet" (inventory section 5).
 */
export function SalesButtons({
  busy,
  onRun,
}: {
  busy: boolean;
  onRun: (button: SalesButton, element: HTMLButtonElement) => void;
}) {
  return (
    <div className="row" data-panel="sale" style={{ marginTop: 10 }}>
      {SALES_BUTTONS.map((button) => {
        const key = keyOf(button.caption);
        const text = button.caption.replace('&', '');
        return (
          <button
            key={button.caption}
            type="button"
            className="ghost"
            accessKey={key ? key.toLowerCase() : undefined}
            disabled={!button.mode || busy}
            title={button.mode ? undefined : 'Not available yet'}
            onClick={(event) => onRun(button, event.currentTarget)}
          >
            {key ? (
              <>
                {text.slice(0, text.indexOf(key))}
                <u>{key}</u>
                {text.slice(text.indexOf(key) + 1)}
              </>
            ) : (
              text
            )}
          </button>
        );
      })}
    </div>
  );
}
