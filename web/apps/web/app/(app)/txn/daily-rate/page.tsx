'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { recalcDailyRateGrid } from '@datacare/core';
import { get, post, del, ApiError } from '../../../../lib/api';
import { RateTicker } from '../../../../components/RateTicker';
import { LookupPicker } from '../../../../components/LookupPicker';
import { todayLocal } from '../../../../lib/localDate';

/**
 * Daily Rate (desktop MS_RATE, "Rate Master", MDI_FORM.cs:8564-8573). The grid lists the item groups that have a
 * touch; typing the Gold Rate 10gm and Silver Rate 1Kg and pressing Enter on the silver rate recomputes the gold and
 * silver rows whose metal rate changed (MS_RATE.cs:2314-2368). Every cell can then be overridden; Save stores the grid
 * as shown. Purchase and USD rates are shown only for a UAE company (MS_RATE.cs:1705-1715).
 */
type Row = {
  grCode: string;
  grName: string;
  grType: string;
  touch: number;
  taxPct: number;
  prTouch: number;
  rate: number;
  taxRate: number;
  prRate: number;
};
type Header = {
  goldRate: string;
  silverRate: string;
  prGoldRate: string;
  prSilverRate: string;
  goldOzRate: string;
  silverOzRate: string;
};
type Day = { date: string; mainUser: string; goldRate: number; silverRate: number };
const blankHeader: Header = {
  goldRate: '',
  silverRate: '',
  prGoldRate: '',
  prSilverRate: '',
  goldOzRate: '',
  silverOzRate: '',
};
const n = (v: string | number) => Number(v || 0);
const f2 = (v: number) => (v ? v.toFixed(2) : '');
const errText = (e: unknown, fallback: string) =>
  e instanceof ApiError ? e.body?.message || e.body?.error || e.message : fallback;

export default function DailyRatePage() {
  const [date, setDate] = useState(todayLocal());
  const [header, setHeader] = useState<Header>(blankHeader);
  const [loaded, setLoaded] = useState({
    goldRate: 0,
    silverRate: 0,
    prGoldRate: 0,
    prSilverRate: 0,
  });
  const [empCode, setEmpCode] = useState('');
  const [empName, setEmpName] = useState('');
  const [rows, setRows] = useState<Row[]>([]);
  const [exists, setExists] = useState(false);
  const [foreign, setForeign] = useState(false);
  const [days, setDays] = useState<Day[] | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  // The day the screen shows; a load for an earlier date that answers late is dropped.
  const shown = useRef('');

  const load = useCallback(async (d: string) => {
    shown.current = d;
    try {
      const r = await get<any>(`/daily-rate?date=${encodeURIComponent(d)}`);
      if (shown.current !== d) return;
      const h = {
        goldRate: f2(r.goldRate),
        silverRate: f2(r.silverRate),
        prGoldRate: f2(r.prGoldRate),
        prSilverRate: f2(r.prSilverRate),
        goldOzRate: f2(r.goldOzRate),
        silverOzRate: f2(r.silverOzRate),
      };
      setHeader(h);
      setLoaded({
        goldRate: r.goldRate,
        silverRate: r.silverRate,
        prGoldRate: r.prGoldRate,
        prSilverRate: r.prSilverRate,
      });
      setEmpCode(r.empCode || '');
      setEmpName(r.empName || '');
      setExists(!!r.exists);
      setForeign(!!r.foreignRates);
      setRows(r.groups ?? []);
    } catch (e) {
      setRows([]);
      setMsg({ kind: 'err', text: errText(e, 'failed to load') });
    }
  }, []);
  useEffect(() => {
    void load(date);
  }, [date, load]);

  const setCell = (i: number, key: keyof Row, value: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [key]: n(value) } : r)));
  const setH = (key: keyof Header, value: string) => setHeader((h) => ({ ...h, [key]: value }));
  /** MS_RATE.cs:2314-2368 (and :2397-2458 for a UAE company): recompute the changed metals' rows. */
  function recalc() {
    const now = {
      goldRate: n(header.goldRate),
      silverRate: n(header.silverRate),
      prGoldRate: n(header.prGoldRate),
      prSilverRate: n(header.prSilverRate),
    };
    setRows((rs) => recalcDailyRateGrid(rs, now, loaded, { foreignRates: foreign }));
    setLoaded(now);
  }
  const enter =
    (key: keyof Header, last: boolean) => (e: React.KeyboardEvent<HTMLInputElement>) => {
      if (e.key !== 'Enter') return;
      e.preventDefault();
      setH(key, n(header[key]).toFixed(2));
      if (last) recalc();
    };

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setBusy(true);
    try {
      const saved = await post<{ date: string; saved: number }>('/daily-rate', {
        date,
        goldRate: n(header.goldRate),
        silverRate: n(header.silverRate),
        ...(foreign
          ? {
              prGoldRate: n(header.prGoldRate),
              prSilverRate: n(header.prSilverRate),
              goldOzRate: n(header.goldOzRate),
              silverOzRate: n(header.silverOzRate),
            }
          : {}),
        empCode: empCode.trim(),
        rows: rows.map((r) => ({
          grCode: r.grCode,
          touch: r.touch,
          taxPct: r.taxPct,
          rate: r.rate,
          taxRate: r.taxRate,
          prRate: r.prRate,
        })),
      });
      setMsg({ kind: 'ok', text: `Saved ${saved.saved} group rate(s) for ${saved.date}` });
      await load(date);
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err, 'failed') });
    } finally {
      setBusy(false);
    }
  }

  async function removeDay() {
    // MS_RATE.cs:2103
    if (!window.confirm('Are You Sure To Delete This Day Rate?')) return;
    setBusy(true);
    try {
      await del(`/daily-rate?date=${encodeURIComponent(date)}`);
      setMsg({ kind: 'ok', text: 'Deleted.' });
      await load(date);
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err, 'delete failed') });
    } finally {
      setBusy(false);
    }
  }

  async function openList() {
    try {
      setDays(await get<Day[]>('/daily-rate/dates'));
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err, 'failed to list') });
    }
  }

  const rateInput = (key: keyof Header, label: string, last = false) => (
    <div className="field">
      <label htmlFor={`daily-rate-${key}`}>{label}</label>
      <input
        id={`daily-rate-${key}`}
        value={header[key]}
        inputMode="decimal"
        onChange={(e) => setH(key, e.target.value)}
        onKeyDown={enter(key, last)}
        style={{ width: 130, textAlign: 'right' }}
      />
    </div>
  );

  return (
    <div>
      <h1>Rate Master</h1>
      <RateTicker />
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : undefined}>
          {msg.text}
        </div>
      )}
      <form className="panel" onSubmit={submit}>
        <div className="row">
          <div className="field">
            <label htmlFor="daily-rate-date">Vch Date</label>
            <input
              id="daily-rate-date"
              type="date"
              value={date}
              onChange={(e) => setDate(e.target.value)}
              onKeyDown={(e) => {
                if (e.key === 'F1') {
                  e.preventDefault();
                  void openList();
                }
              }}
              required
            />
          </div>
          <div className="field">
            <label>&nbsp;</label>
            <button type="button" onClick={() => void openList()}>
              F1
            </button>
          </div>
          {rateInput('goldRate', 'Gold Rate 10gm')}
          {foreign && rateInput('prGoldRate', 'Gold Purc 10gm')}
          {rateInput('silverRate', 'Silver Rate 1Kg', !foreign)}
          {foreign && rateInput('prSilverRate', 'Silver Purc 1Kg')}
          {foreign && rateInput('goldOzRate', 'Gold USD Pr Oz')}
          {foreign && rateInput('silverOzRate', 'Silver USD Pr Oz', true)}
          <div className="field" style={{ flex: 2 }}>
            <label>Employee</label>
            <LookupPicker
              entity="employees"
              value={empCode}
              onChange={(code) => {
                setEmpCode(code);
                setEmpName('');
              }}
              onPick={(picked) => setEmpName(String(picked.name || ''))}
              ariaLabel="Employee"
              resolveTypedCode
            />
            {empName && (
              <span className="muted" style={{ fontSize: 12 }}>
                {empName}
              </span>
            )}
          </div>
        </div>
        {days && (
          <div className="panel" aria-label="Saved days">
            <table className="grid">
              <thead>
                <tr>
                  <th>Vch Date</th>
                  <th>User</th>
                  <th className="num">Gold Rate 10gm</th>
                  <th className="num">Silver Rate 1Kg</th>
                  <th>
                    <span className="muted">Open</span>
                  </th>
                </tr>
              </thead>
              <tbody>
                {days.map((d) => (
                  <tr key={d.date}>
                    <td>{d.date.split('-').reverse().join('/')}</td>
                    <td>{d.mainUser}</td>
                    <td className="num">{d.goldRate.toFixed(2)}</td>
                    <td className="num">{d.silverRate.toFixed(2)}</td>
                    <td>
                      <button
                        type="button"
                        onClick={() => {
                          setDays(null);
                          setDate(d.date);
                        }}
                      >
                        Open {d.date}
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
        <table className="grid" style={{ marginTop: 10 }}>
          <thead>
            <tr>
              <th>Sr.</th>
              <th>GrCode</th>
              <th>GrName</th>
              <th className="num">Touch</th>
              <th className="num">Tax%</th>
              <th className="num">Rate10gm</th>
              <th className="num">TaxRate</th>
              <th className="num">PrTouch</th>
              <th className="num">PrRate</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((r, i) => {
              const cell = (key: keyof Row, label: string) => (
                <td className="num">
                  <input
                    aria-label={`${label} ${r.grCode}`}
                    value={r[key] === 0 ? '' : String(r[key])}
                    inputMode="decimal"
                    onChange={(e) => setCell(i, key, e.target.value)}
                    style={{ width: 100, textAlign: 'right' }}
                  />
                </td>
              );
              return (
                <tr key={r.grCode}>
                  <td className="c">{i + 1}</td>
                  <td>{r.grCode}</td>
                  <td>{r.grName}</td>
                  {cell('touch', 'Touch')}
                  {cell('taxPct', 'Tax%')}
                  {cell('rate', 'Rate10gm')}
                  {cell('taxRate', 'TaxRate')}
                  <td className="num">{r.prTouch ? r.prTouch.toFixed(2) : ''}</td>
                  {cell('prRate', 'PrRate')}
                </tr>
              );
            })}
          </tbody>
        </table>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <span className="muted">
            {rows.length} group(s) with a touch{exists ? ' · saved day' : ''}
          </span>
          <span className="spacer" />
          {exists && (
            <>
              <a
                className="btn"
                href={`/api/daily-rate/print?date=${encodeURIComponent(date)}&format=html`}
                target="_blank"
                rel="noreferrer"
              >
                Print
              </a>
              <button
                type="button"
                className="danger"
                onClick={() => void removeDay()}
                disabled={busy}
              >
                Delete
              </button>
            </>
          )}
          <button
            type="button"
            onClick={() => {
              setDate(todayLocal());
              void load(todayLocal());
            }}
            disabled={busy}
          >
            Cancel
          </button>
          <button className="primary" data-save-mnemonic disabled={busy || !rows.length}>
            {busy ? 'Saving…' : 'Save'}
          </button>
        </div>
      </form>
    </div>
  );
}
