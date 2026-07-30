'use client';
import { type ReactNode, useEffect, useState } from 'react';

/**
 * Shared voucher chrome (mirrors the desktop voucher form): a header strip with Vch No / Date
 * (+ time + weekday) / Ref No / Employe / Bank / Vch Desc, and an action bar (◀ ▶ Print[copies]
 * Save Cancel Delete Exit). Every action + field is optional; a control renders only when its
 * handler is supplied. If `onSave` is omitted the Save button is a native submit (drop inside a
 * <form>). Print supports desktop-style Original/Duplicate/Triplicate copy selection.
 */
export interface VoucherChromeProps {
  title?: string;
  vchNo?: string | number | null;
  date?: string; // yyyy-mm-dd
  onDateChange?: (d: string) => void;
  showTime?: boolean;
  refNo?: string;
  onRefNoChange?: (r: string) => void;
  employee?: string;
  onEmployeeChange?: (v: string) => void;
  bank?: string;
  onBankChange?: (v: string) => void;
  vchDesc?: string;
  onVchDescChange?: (v: string) => void;
  onPrev?: () => void;
  onNext?: () => void;
  onPrint?: () => void;
  printCopies?: string[]; // e.g. ['Original','Duplicate','Triplicate']
  onPrintCopy?: (copy: string) => void;
  onSave?: () => void;
  onCancel?: () => void;
  onDelete?: () => void;
  onExit?: () => void;
  saving?: boolean;
  saveLabel?: string;
  extra?: ReactNode;
}

const WEEKDAYS = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
function weekdayOf(d?: string): string {
  if (!d) return '';
  const dt = new Date(d + 'T00:00:00');
  return Number.isNaN(dt.getTime()) ? '' : WEEKDAYS[dt.getDay()];
}

export function VoucherChrome(props: VoucherChromeProps) {
  const wd = weekdayOf(props.date);
  const [now, setNow] = useState('');
  const [copy, setCopy] = useState((props.printCopies && props.printCopies[0]) || 'Original');
  useEffect(() => {
    if (!props.showTime) return;
    const tick = () =>
      setNow(new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));
    tick();
    const id = setInterval(tick, 30000);
    return () => clearInterval(id);
  }, [props.showTime]);

  const fld = (label: ReactNode, node: ReactNode) => (
    <div className="field">
      <label>{label}</label>
      {node}
    </div>
  );

  return (
    <div className="voucher-chrome">
      <div className="row" style={{ alignItems: 'flex-end', gap: 12, flexWrap: 'wrap' }}>
        {props.title && <h1 style={{ margin: 0, marginRight: 'auto' }}>{props.title}</h1>}
        {fld(
          'Vch No',
          <input
            value={props.vchNo != null ? String(props.vchNo) : ''}
            readOnly
            placeholder="auto"
            style={{ width: 90, background: 'var(--muted-bg,#f3f4f6)' }}
          />,
        )}
        {fld(
          <>
            Date{' '}
            {wd && (
              <span className="muted">
                ({wd}
                {props.showTime && now ? ' ' + now : ''})
              </span>
            )}
          </>,
          <input
            type="date"
            value={props.date ?? ''}
            onChange={(e) => props.onDateChange?.(e.target.value)}
            readOnly={!props.onDateChange}
            style={{ width: 150 }}
          />,
        )}
        {fld(
          'Ref No',
          <input
            value={props.refNo ?? ''}
            onChange={(e) => props.onRefNoChange?.(e.target.value)}
            readOnly={!props.onRefNoChange}
            placeholder="reference"
            style={{ width: 110 }}
          />,
        )}
        {props.onEmployeeChange &&
          fld(
            'Employe',
            <input
              value={props.employee ?? ''}
              onChange={(e) => props.onEmployeeChange?.(e.target.value)}
              placeholder="emp code"
              style={{ width: 100 }}
            />,
          )}
        {props.onBankChange &&
          fld(
            'Bank',
            <input
              value={props.bank ?? ''}
              onChange={(e) => props.onBankChange?.(e.target.value)}
              placeholder="deposit bank"
              style={{ width: 120 }}
            />,
          )}
        {props.onVchDescChange &&
          fld(
            'Vch Desc',
            <input
              value={props.vchDesc ?? ''}
              onChange={(e) => props.onVchDescChange?.(e.target.value)}
              placeholder="narration"
              style={{ width: 200 }}
            />,
          )}
        {props.extra}
      </div>
      <div className="toolbar voucher-actions" style={{ marginTop: 8, gap: 6 }}>
        {props.onPrev && (
          <button type="button" className="ghost" onClick={props.onPrev} title="Previous">
            ◀
          </button>
        )}
        {props.onNext && (
          <button type="button" className="ghost" onClick={props.onNext} title="Next">
            ▶
          </button>
        )}
        <span className="spacer" />
        {props.printCopies && props.onPrintCopy && (
          <>
            <select
              value={copy}
              onChange={(e) => setCopy(e.target.value)}
              title="Print copy"
              style={{ width: 110 }}
            >
              {props.printCopies.map((c) => (
                <option key={c} value={c}>
                  {c}
                </option>
              ))}
            </select>
            <button type="button" className="ghost" onClick={() => props.onPrintCopy?.(copy)}>
              Print
            </button>
          </>
        )}
        {!props.printCopies && props.onPrint && (
          <button type="button" className="ghost" onClick={props.onPrint}>
            Print
          </button>
        )}
        <button
          type={props.onSave ? 'button' : 'submit'}
          className="primary"
          onClick={props.onSave}
          disabled={props.saving}
        >
          {props.saving ? 'Saving…' : (props.saveLabel ?? 'Save')}
        </button>
        {props.onCancel && (
          <button type="button" className="ghost" onClick={props.onCancel}>
            Cancel
          </button>
        )}
        {props.onDelete && (
          <button type="button" className="danger" onClick={props.onDelete}>
            Delete
          </button>
        )}
        {props.onExit && (
          <button type="button" className="ghost" onClick={props.onExit}>
            Exit
          </button>
        )}
      </div>
    </div>
  );
}

export default VoucherChrome;
