'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import {
  messagingFailure,
  messagingOutcome,
  type MessagingOutcome,
} from '../../../../lib/messagingOutcome';

/**
 * Reminders — Phase 12 / UT_REMINDER.
 *
 * Two sections:
 *  • Outstanding — parties with an unpaid balance (GET /reminders/overdue). Each row shows
 *    party / mobile / balance / days overdue and a "Send" button that POSTs { mobile, message }
 *    to /reminders/send (WhatsApp/SMS via the configured provider).
 *  • Birthdays — parties whose birthday/anniversary falls on the chosen date
 *    (GET /reminders/birthdays?onDate=…), each individually sendable.
 *
 * The message body is rendered client-side from an editable template (mirrors the desktop CUST_SMS
 * behaviour). Provider status comes from GET /integrations/status (.messaging). Until WhatsApp/SMS
 * credentials are set the server refuses sends (503 messaging-unconfigured); a test-mode send is reported as
 * simulated and a provider acceptance as not yet confirmed delivered (N54, G33).
 *
 * NOTE: /reminders/* may not be wired into the API yet — a 404 is handled gracefully so the
 * coordinator can attach the routes without changing this page.
 */

type OverdueRow = {
  acCode: string;
  party: string | null;
  mobile: string | null;
  bills: number;
  balance: number;
  oldestBill: string | null;
  daysOverdue: number | null;
};

type BirthdayRow = {
  acCode: string;
  party: string | null;
  mobile: string | null;
  occasion: string;
  onDate: string | null;
};

type ListReport<T> = { rows: T[]; totals?: Record<string, number>; note?: string };

type SendState = { state: 'pending' } | { state: 'done'; outcome: MessagingOutcome };

const inr = (n: number): string =>
  (Number(n) || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

function fmtDate(d: string | null): string {
  if (!d) return '—';
  const dt = new Date(d);
  return isNaN(dt.getTime()) ? String(d) : dt.toLocaleDateString('en-IN');
}

function todayIso(): string {
  const d = new Date();
  return `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
}

/** Substitute {placeholder} tokens (mirrors backend renderTemplate / desktop CUST_SMS). */
function applyTemplate(tpl: string, vars: Record<string, string | number | null>): string {
  return tpl.replace(/\{(\w+)\}/g, (_m, k: string) => {
    const v = vars[k];
    return v === undefined || v === null ? '' : String(v);
  });
}

const DEFAULT_OVERDUE_TPL =
  'Dear {party}, our records show an outstanding balance of Rs. {balance} on your account (oldest bill {days} days overdue). Kindly arrange payment at your earliest convenience. Thank you.';
const DEFAULT_BIRTHDAY_TPL = 'Dear {party}, wishing you a very happy {occasion}! Warm regards.';

export default function RemindersPage() {
  const [tab, setTab] = useState<'overdue' | 'birthdays'>('overdue');
  const [provider, setProvider] = useState<{ provider?: string; status?: string } | null>(null);

  // ---- Outstanding ----
  const [overdue, setOverdue] = useState<ListReport<OverdueRow> | null>(null);
  const [overdueLoading, setOverdueLoading] = useState(false);
  const [overdueErr, setOverdueErr] = useState('');
  const [overdueTpl, setOverdueTpl] = useState(DEFAULT_OVERDUE_TPL);

  // ---- Birthdays ----
  const [onDate, setOnDate] = useState(todayIso());
  const [birthdays, setBirthdays] = useState<ListReport<BirthdayRow> | null>(null);
  const [bdayLoading, setBdayLoading] = useState(false);
  const [bdayErr, setBdayErr] = useState('');
  const [bdayTpl, setBdayTpl] = useState(DEFAULT_BIRTHDAY_TPL);

  // Per-row send state and idempotency key, keyed by a stable row key.
  const [sends, setSends] = useState<Record<string, SendState>>({});
  const [attemptKeys, setAttemptKeys] = useState<Record<string, string>>({});

  const loadOverdue = useCallback(async () => {
    setOverdueLoading(true);
    setOverdueErr('');
    try {
      setOverdue(await get<ListReport<OverdueRow>>('/reminders/overdue'));
    } catch (e) {
      setOverdueErr(
        e instanceof ApiError
          ? e.status === 404
            ? 'Endpoint /reminders/overdue is not wired yet (pending coordinator).'
            : e.body?.error || e.message
          : 'Failed to load outstanding reminders',
      );
    } finally {
      setOverdueLoading(false);
    }
  }, []);

  const loadBirthdays = useCallback(async (date: string) => {
    setBdayLoading(true);
    setBdayErr('');
    try {
      const q = date ? `?onDate=${encodeURIComponent(date)}` : '';
      setBirthdays(await get<ListReport<BirthdayRow>>(`/reminders/birthdays${q}`));
    } catch (e) {
      setBdayErr(
        e instanceof ApiError
          ? e.status === 404
            ? 'Endpoint /reminders/birthdays is not wired yet (pending coordinator).'
            : e.body?.error || e.message
          : 'Failed to load birthday reminders',
      );
    } finally {
      setBdayLoading(false);
    }
  }, []);

  useEffect(() => {
    loadOverdue();
    loadBirthdays(todayIso());
    get('/integrations/status')
      .then((s: any) => setProvider(s?.messaging ?? null))
      .catch(() => {});
  }, [loadOverdue, loadBirthdays]);

  async function send(
    rowKey: string,
    mobile: string | null,
    message: string,
    templateKind: 'overdue-reminder' | 'birthday-reminder',
  ) {
    if (!mobile) {
      setSends((m) => ({
        ...m,
        [rowKey]: {
          state: 'done',
          outcome: { tone: 'err', text: 'No mobile number on this party.' },
        },
      }));
      return;
    }
    setSends((m) => ({ ...m, [rowKey]: { state: 'pending' } }));
    try {
      const idempotencyKey = attemptKeys[rowKey] ?? crypto.randomUUID();
      setAttemptKeys((keys) => ({ ...keys, [rowKey]: idempotencyKey }));
      const res: any = await post('/reminders/send', {
        mobile,
        message,
        idempotencyKey,
        templateKind,
      });
      setSends((m) => ({ ...m, [rowKey]: { state: 'done', outcome: messagingOutcome(res) } }));
    } catch (e) {
      const outcome: MessagingOutcome =
        e instanceof ApiError && e.status === 404
          ? {
              tone: 'err',
              text: 'Endpoint /reminders/send is not wired yet (pending coordinator).',
            }
          : messagingOutcome(messagingFailure(e));
      setSends((m) => ({ ...m, [rowKey]: { state: 'done', outcome } }));
    }
  }

  function renderSendStatus(rowKey: string) {
    const r = sends[rowKey];
    if (!r) return <span className="muted">—</span>;
    if (r.state === 'pending') return <span className="muted">Sending…</span>;
    return (
      <span role="status" style={{ color: r.outcome.tone === 'ok' ? 'var(--ok)' : 'var(--err)' }}>
        {r.outcome.text}
      </span>
    );
  }

  const overdueRows = overdue?.rows ?? [];
  const overdueTotals = overdue?.totals;
  const bdayRows = birthdays?.rows ?? [];

  return (
    <div>
      <h1>Reminders</h1>

      <div className="panel">
        <div className="toolbar">
          <button
            className={tab === 'overdue' ? 'primary' : 'ghost'}
            onClick={() => setTab('overdue')}
          >
            Outstanding{overdue ? ` (${overdueRows.length})` : ''}
          </button>
          <button
            className={tab === 'birthdays' ? 'primary' : 'ghost'}
            onClick={() => setTab('birthdays')}
          >
            Birthdays{birthdays ? ` (${bdayRows.length})` : ''}
          </button>
          <span className="spacer" style={{ flex: 1 }} />
          {provider && (
            <span className="muted">
              Messaging: {provider.provider}
              {provider.status ? ` — ${provider.status}` : ''}
            </span>
          )}
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Send payment-due and birthday/anniversary reminders over WhatsApp/SMS. Messages are built
          from the editable template below; <code>{'{party}'}</code>, <code>{'{balance}'}</code>,{' '}
          <code>{'{days}'}</code> and <code>{'{occasion}'}</code> are substituted per row.
        </p>
      </div>

      {tab === 'overdue' && (
        <>
          <div className="panel">
            <div className="toolbar">
              <button className="primary" onClick={loadOverdue} disabled={overdueLoading}>
                {overdueLoading ? 'Loading…' : 'Refresh'}
              </button>
              {overdueTotals && (
                <span className="muted">
                  {overdueTotals.parties ?? 0} parties · outstanding Rs.{' '}
                  {inr(overdueTotals.balance ?? 0)}
                </span>
              )}
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label>Message template</label>
              <textarea
                value={overdueTpl}
                onChange={(e) => setOverdueTpl(e.target.value)}
                rows={2}
                style={{ width: '100%' }}
              />
            </div>
          </div>

          {overdueErr && <div className="msg err">{overdueErr}</div>}

          <div className="panel" style={{ overflow: 'auto' }}>
            {overdueLoading ? (
              <span className="muted">Loading outstanding reminders…</span>
            ) : overdueRows.length === 0 ? (
              <span className="muted">No parties with an outstanding balance.</span>
            ) : (
              <table className="grid">
                <thead>
                  <tr>
                    <th>Party</th>
                    <th>Mobile</th>
                    <th className="num">Balance</th>
                    <th className="num">Bills</th>
                    <th>Oldest Bill</th>
                    <th className="num">Days</th>
                    <th>Status</th>
                    <th>Action</th>
                  </tr>
                </thead>
                <tbody>
                  {overdueRows.map((row) => {
                    const key = `od:${row.acCode}`;
                    const pending = sends[key]?.state === 'pending';
                    const message = applyTemplate(overdueTpl, {
                      party: row.party ?? row.acCode,
                      balance: inr(row.balance),
                      days: row.daysOverdue ?? 0,
                    });
                    return (
                      <tr key={key}>
                        <td>{row.party ?? row.acCode}</td>
                        <td>{row.mobile ?? <span className="muted">—</span>}</td>
                        <td className="num">{inr(row.balance)}</td>
                        <td className="num">{row.bills}</td>
                        <td>{fmtDate(row.oldestBill)}</td>
                        <td className="num">{row.daysOverdue ?? '—'}</td>
                        <td>{renderSendStatus(key)}</td>
                        <td>
                          <button
                            className="primary"
                            onClick={() => send(key, row.mobile, message, 'overdue-reminder')}
                            disabled={pending || !row.mobile}
                            title={row.mobile ? message : 'No mobile number'}
                          >
                            {pending ? 'Sending…' : 'Send'}
                          </button>
                        </td>
                      </tr>
                    );
                  })}
                </tbody>
                {overdueTotals && (
                  <tfoot>
                    <tr className="totals">
                      <td colSpan={2}>Total ({overdueRows.length} parties)</td>
                      <td className="num">{inr(overdueTotals.balance ?? 0)}</td>
                      <td colSpan={5} />
                    </tr>
                  </tfoot>
                )}
              </table>
            )}
          </div>
        </>
      )}

      {tab === 'birthdays' && (
        <>
          <div className="panel">
            <div className="toolbar">
              <div className="field" style={{ marginBottom: 0 }}>
                <label>On date</label>
                <input type="date" value={onDate} onChange={(e) => setOnDate(e.target.value)} />
              </div>
              <button
                className="primary"
                onClick={() => loadBirthdays(onDate)}
                disabled={bdayLoading}
              >
                {bdayLoading ? 'Loading…' : 'Load'}
              </button>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label>Message template</label>
              <textarea
                value={bdayTpl}
                onChange={(e) => setBdayTpl(e.target.value)}
                rows={2}
                style={{ width: '100%' }}
              />
            </div>
            {birthdays?.note && (
              <p className="muted" style={{ margin: '8px 0 0' }}>
                {birthdays.note}
              </p>
            )}
          </div>

          {bdayErr && <div className="msg err">{bdayErr}</div>}

          <div className="panel" style={{ overflow: 'auto' }}>
            {bdayLoading ? (
              <span className="muted">Loading birthday reminders…</span>
            ) : bdayRows.length === 0 ? (
              <span className="muted">No birthdays or anniversaries on {onDate || '—'}.</span>
            ) : (
              <table className="grid">
                <thead>
                  <tr>
                    <th>Party</th>
                    <th>Mobile</th>
                    <th>Occasion</th>
                    <th>Date</th>
                    <th>Status</th>
                    <th>Action</th>
                  </tr>
                </thead>
                <tbody>
                  {bdayRows.map((row) => {
                    const key = `bd:${row.acCode}:${row.occasion}`;
                    const pending = sends[key]?.state === 'pending';
                    const message = applyTemplate(bdayTpl, {
                      party: row.party ?? row.acCode,
                      occasion: (row.occasion || 'day').toLowerCase(),
                    });
                    return (
                      <tr key={key}>
                        <td>{row.party ?? row.acCode}</td>
                        <td>{row.mobile ?? <span className="muted">—</span>}</td>
                        <td>{row.occasion}</td>
                        <td>{fmtDate(row.onDate)}</td>
                        <td>{renderSendStatus(key)}</td>
                        <td>
                          <button
                            className="primary"
                            onClick={() => send(key, row.mobile, message, 'birthday-reminder')}
                            disabled={pending || !row.mobile}
                            title={row.mobile ? message : 'No mobile number'}
                          >
                            {pending ? 'Sending…' : 'Send'}
                          </button>
                        </td>
                      </tr>
                    );
                  })}
                </tbody>
              </table>
            )}
          </div>
        </>
      )}
    </div>
  );
}
