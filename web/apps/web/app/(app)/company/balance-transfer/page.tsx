'use client';

import { useRouter } from 'next/navigation';
import { useCallback, useEffect, useRef, useState } from 'react';
import { ApiError, get, post } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';

/**
 * Company → Balance TrFr: the desktop BtmSchm form. Title is the menu caption (BtmSchm.cs:1947); "Transfer Year" shows
 * the first later YEAR_MAST year (:2085-2105), computed by the server and not typed; the five Lite dataset buttons in
 * the desktop tab order (Ac Balance 1, Item Stock 2, Tag Stock 3, Sales Order 1155, Approval 1159; study §Screen);
 * Exit and Cancel. Every button asks "Are You Sure To Data Transfer to Next Year ?" (:2729) and answers "Process Are
 * Complete...." (:2755). Esc closes (:2692-2695). The desktop's Delete and Print are empty (:2699-2723) and the other
 * fourteen buttons belong to menus outside Lite, so none is shown.
 *
 * Deliberate differences: with no later year the buttons are disabled (the desktop leaves them live, weakness 8);
 * Cancel clears the messages but never blanks the Transfer Year (the desktop blanks it, :2641-2652); a failed run
 * shows its error instead of the completion text (weakness 9).
 */
const CONFIRM = 'Are You Sure To Data Transfer to Next Year ?';

interface Context {
  fromYear: string;
  toYear: string | null;
  opDate: string | null;
  clDate: string | null;
  message: string | null;
}
interface RunResult {
  dataset: string;
  toYear: string;
  rows: number;
  message: string;
}

const DATASETS = [
  { key: 'ac-balance', label: 'Ac Balance' },
  { key: 'item-stock', label: 'Item Stock' },
  { key: 'tag-stock', label: 'Tag Stock' },
  { key: 'sales-order', label: 'Sales Order' },
  { key: 'approval', label: 'Approval' },
] as const;

const errText = (e: unknown): string =>
  e instanceof ApiError
    ? e.body?.message || e.body?.error || e.message
    : e instanceof Error
      ? e.message
      : 'The transfer failed.';

export default function BalanceTransferPage() {
  const router = useRouter();
  const { coYear } = useBusinessScope();
  const [ctx, setCtx] = useState<Context | null>(null);
  const [busy, setBusy] = useState<string | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const firstButton = useRef<HTMLButtonElement | null>(null);

  const load = useCallback(async () => {
    try {
      const c = await get<Context>('/balance-transfer');
      setCtx(c);
      if (c.message) setMsg({ kind: 'err', text: c.message });
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e) });
    }
  }, []);

  useEffect(() => {
    setCtx(null);
    setMsg(null);
    void load();
  }, [coYear, load]);

  useEffect(() => {
    if (ctx?.toYear) firstButton.current?.focus();
  }, [ctx]);

  async function runDataset(key: string) {
    if (!ctx?.toYear || busy) return;
    if (!window.confirm(CONFIRM)) return;
    setBusy(key);
    setMsg(null);
    try {
      const result = await post<RunResult>(`/balance-transfer/${key}`, { toYear: ctx.toYear });
      setMsg({ kind: 'ok', text: result.message });
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e) });
    } finally {
      setBusy(null);
    }
  }

  const onScreenKeyDown = (event: ScreenKeyEvent) => {
    if (event.key !== 'Escape' || event.defaultPrevented) return;
    event.preventDefault();
    // A run in progress is not aborted by Esc (cases.md keyboard.esc-closes); the page leaves after it ends.
    if (!busy) router.back();
  };
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);

  const disabled = !ctx?.toYear || busy !== null;
  return (
    <div ref={screenRef} onKeyDown={onScreenKeyDown}>
      <h1>Balance TrFr</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="panel">
        <div className="field" style={{ maxWidth: 220 }}>
          <label htmlFor="balance-transfer-year">Transfer Year</label>
          <input
            id="balance-transfer-year"
            value={ctx?.toYear ?? ''}
            readOnly
            tabIndex={-1}
            style={{ textAlign: 'center' }}
          />
        </div>
        <div className="toolbar" data-testid="balance-transfer-buttons">
          {DATASETS.map((d, i) => (
            <button
              key={d.key}
              type="button"
              className="primary"
              ref={i === 0 ? firstButton : undefined}
              disabled={disabled}
              onClick={() => void runDataset(d.key)}
            >
              {busy === d.key ? `${d.label}…` : d.label}
            </button>
          ))}
        </div>
      </div>
      <div className="toolbar">
        <button
          type="button"
          className="ghost"
          onClick={() => router.back()}
          disabled={busy !== null}
        >
          Exit
        </button>
        <button
          type="button"
          className="ghost"
          onClick={() => setMsg(ctx?.message ? { kind: 'err', text: ctx.message } : null)}
          disabled={busy !== null}
        >
          Cancel
        </button>
      </div>
    </div>
  );
}
