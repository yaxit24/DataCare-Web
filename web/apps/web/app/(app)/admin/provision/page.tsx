'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';

interface Result {
  coCode: string;
  created: {
    coMast: boolean;
    accounts: number;
    taxes: number;
    books: number;
    srno: boolean;
    coSet: boolean;
  };
}

export default function ProvisionCompanyPage() {
  const [coCode, setCoCode] = useState('');
  const [coName, setCoName] = useState('');
  const [res, setRes] = useState<Result | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!coCode.trim()) {
      setMsg({ kind: 'err', text: 'enter a company code' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<Result>(
        `/admin/companies/${encodeURIComponent(coCode.trim())}/provision`,
        { coName: coName.trim() || undefined },
      );
      setRes(r);
      const c = r.created;
      const n = c.accounts + c.taxes + c.books;
      setMsg({
        kind: 'ok',
        text:
          n === 0 && !c.coMast
            ? 'Already provisioned — nothing to add'
            : `Provisioned company ${r.coCode}`,
      });
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Provision Company{' '}
        <span className="muted">— seed system accounts, taxes, books &amp; settings</span>
      </h1>
      <p className="muted">
        Sets up a new company so it can post immediately: the system ledger accounts the posting
        engine uses (CASH, SALES, PURCHASE, GST, KASAR, TCS, …), standard GST/TCS taxes, voucher
        books, the numbering counter and a settings row. Safe to re-run (only adds what's missing).
      </p>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form className="panel" onSubmit={submit}>
        <div className="row">
          <div className="field">
            <label>Company Code</label>
            <input
              value={coCode}
              onChange={(e) => setCoCode(e.target.value)}
              placeholder="e.g. 02"
            />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label>Company Name (optional)</label>
            <input
              value={coName}
              onChange={(e) => setCoName(e.target.value)}
              placeholder="leave blank to keep existing"
            />
          </div>
        </div>
        <button className="primary" disabled={busy}>
          {busy ? 'Provisioning…' : 'Provision'}
        </button>
      </form>
      {res && (
        <div className="panel">
          <div className="tiles">
            <div className="tile">
              <div className="muted">Company row</div>
              <div className="big kpi">{res.created.coMast ? 'created' : 'existing'}</div>
            </div>
            <div className="tile">
              <div className="muted">Accounts added</div>
              <div className="big kpi">{res.created.accounts}</div>
            </div>
            <div className="tile">
              <div className="muted">Taxes added</div>
              <div className="big kpi">{res.created.taxes}</div>
            </div>
            <div className="tile">
              <div className="muted">Books added</div>
              <div className="big kpi">{res.created.books}</div>
            </div>
            <div className="tile">
              <div className="muted">Counter</div>
              <div className="big kpi">{res.created.srno ? 'created' : 'existing'}</div>
            </div>
            <div className="tile">
              <div className="muted">Settings</div>
              <div className="big kpi">{res.created.coSet ? 'created' : 'existing'}</div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
