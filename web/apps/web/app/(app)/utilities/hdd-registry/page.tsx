'use client';
import { useCallback, useEffect, useState } from 'react';
import { ApiError, del, get, post, put } from '../../../../lib/api';

interface RegistryRow {
  id: string;
  refNo: string;
}

const errorText = (error: unknown): string =>
  error instanceof ApiError
    ? error.body?.message || error.body?.detail || error.body?.error || error.message
    : 'Request failed';

export default function HddRegistryPage() {
  const [rows, setRows] = useState<RegistryRow[]>([]);
  const [refNo, setRefNo] = useState('');
  const [message, setMessage] = useState<{ ok: boolean; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    try {
      const result = await get<RegistryRow[]>('/utilities/hdd-registry');
      setRows(result);
      setRefNo(result[0]?.refNo ?? '');
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    }
  }, []);

  useEffect(() => {
    void load();
  }, [load]);

  async function save(event: React.FormEvent) {
    event.preventDefault();
    setBusy(true);
    setMessage(null);
    try {
      const current = rows[0]?.refNo;
      const result = current
        ? await put<{ message: string }>(`/utilities/hdd-registry/${encodeURIComponent(current)}`, {
            refNo,
          })
        : await post<{ message: string }>('/utilities/hdd-registry', { refNo });
      setMessage({ ok: true, text: result.message });
      await load();
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function remove(value: string) {
    setBusy(true);
    setMessage(null);
    try {
      await del(`/utilities/hdd-registry/${encodeURIComponent(value)}`);
      setMessage({ ok: true, text: 'HDD registry entry deleted' });
      await load();
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>HDD Registry</h1>
      {message && (
        <div
          className={`msg ${message.ok ? 'ok' : 'err'}`}
          data-testid={message.ok ? 'hdd-registry-saved' : undefined}
        >
          {message.text}
        </div>
      )}
      <form className="panel" onSubmit={save}>
        <div className="field">
          <label htmlFor="hdd-ref-no">HDD Reference Number</label>
          <input
            id="hdd-ref-no"
            maxLength={10}
            value={refNo}
            onChange={(event) => setRefNo(event.target.value)}
          />
        </div>
        <div className="row">
          <button type="submit" className="primary" disabled={busy}>
            {busy ? 'Saving…' : rows.length ? 'Update HDD' : 'Create HDD'}
          </button>
          <button type="button" onClick={() => void load()} disabled={busy}>
            Refresh
          </button>
          {rows[0] && (
            <button
              type="button"
              className="danger"
              onClick={() => void remove(rows[0]!.refNo)}
              disabled={busy}
            >
              Delete HDD
            </button>
          )}
        </div>
      </form>
      <div className="panel">
        <h2>Active registration</h2>
        <p>{rows[0]?.refNo || <span className="muted">No registration</span>}</p>
      </div>
    </div>
  );
}
