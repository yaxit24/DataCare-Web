'use client';
import { useEffect, useState } from 'react';
import { get, post, ApiError } from '../lib/api';

type Resolved =
  { coBook: string; bookName: string; source: string; settingIgnored?: string } | { error: string };
interface UrdBookView {
  values: { goldBook: string | null; silverBook: string | null };
  books: Array<{ coBook: string; bookName: string }>;
  lcCode: string;
  resolved: { gold: Resolved; silver: Resolved };
}

const SOURCE: Record<string, string> = {
  setting: 'chosen here',
  'desktop-code': 'desktop book code',
  name: 'found by book name',
};

/** What the metal resolves to at the session's location (books are per location; the choice is per company). */
const describe = (r: Resolved, lcCode: string) =>
  'error' in r
    ? `Location ${lcCode}: ${r.error}`
    : `In use at location ${lcCode}: ${r.coBook} ${r.bookName} (${SOURCE[r.source] ?? r.source})` +
      (r.settingIgnored ? ` — ${r.settingIgnored}` : '');

/**
 * Old gold purchase books: the Gold / Silver URD purchase book a tax-invoice sale's Old Gold / Old Silver row opens
 * (owner decision 2B). The desktop hardcodes 043 / 044 (TR_SALE.cs:18756-18842); "(automatic)" keeps that rule, then
 * the single purchase book named "Gold URD …" / "Silver URD …".
 */
export function UrdBookSettings() {
  const [view, setView] = useState<UrdBookView | null>(null);
  const [gold, setGold] = useState('');
  const [silver, setSilver] = useState('');
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [saving, setSaving] = useState(false);

  const apply = (v: UrdBookView) => {
    setView(v);
    setGold(v.values.goldBook ?? '');
    setSilver(v.values.silverBook ?? '');
  };
  useEffect(() => {
    get<UrdBookView>('/settings/urd-books')
      .then(apply)
      .catch(() => setMsg({ kind: 'err', text: 'Failed to load the old gold purchase books' }));
  }, []);

  async function save(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setSaving(true);
    try {
      apply(await post<UrdBookView>('/settings/urd-books', { goldBook: gold, silverBook: silver }));
      setMsg({ kind: 'ok', text: 'Saved old gold purchase books' });
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.message || err.body?.error || 'Save failed'
            : 'Save failed',
      });
    } finally {
      setSaving(false);
    }
  }

  if (!view) return msg ? <div className={`msg ${msg.kind}`}>{msg.text}</div> : null;
  const select = (id: string, value: string, onChange: (v: string) => void) => (
    <select id={id} value={value} onChange={(e) => onChange(e.target.value)}>
      <option value="">(automatic)</option>
      {view.books.map((b) => (
        <option key={b.coBook} value={b.coBook}>
          {b.coBook} {b.bookName}
        </option>
      ))}
    </select>
  );
  return (
    <form className="panel" onSubmit={save} aria-labelledby="urd-books-title">
      <h2 id="urd-books-title">Old Gold Purchase Books</h2>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="row">
        <div className="field" style={{ minWidth: 220 }}>
          <label htmlFor="urd-gold-book">Gold URD Purchase book</label>
          {select('urd-gold-book', gold, setGold)}
          <small className="muted" data-testid="urd-gold-resolved">
            {describe(view.resolved.gold, view.lcCode)}
          </small>
        </div>
        <div className="field" style={{ minWidth: 220 }}>
          <label htmlFor="urd-silver-book">Silver URD Purchase book</label>
          {select('urd-silver-book', silver, setSilver)}
          <small className="muted" data-testid="urd-silver-resolved">
            {describe(view.resolved.silver, view.lcCode)}
          </small>
        </div>
      </div>
      <button className="primary" disabled={saving}>
        {saving ? 'Saving…' : 'Save Old Gold Books'}
      </button>
    </form>
  );
}
