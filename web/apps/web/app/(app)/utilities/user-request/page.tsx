'use client';
import { useCallback, useEffect, useState } from 'react';
import { ApiError, del, get, post, put } from '../../../../lib/api';

interface RequestRow {
  coBook: string;
  vchNo: string;
  vchDate: string | null;
  acCode: string;
  acName: string;
  userName: string;
  editUser: string;
  remark: string;
  requestTime: string | null;
  requestType: string;
}

const errorText = (error: unknown): string =>
  error instanceof ApiError
    ? error.body?.message || error.body?.detail || error.body?.error || error.message
    : 'Request failed';

export default function UserRequestPage() {
  const [rows, setRows] = useState<RequestRow[]>([]);
  const [coBook, setCoBook] = useState('');
  const [vchNo, setVchNo] = useState('');
  const [acCode, setAcCode] = useState('');
  const [remark, setRemark] = useState('');
  const [requestType, setRequestType] = useState<'E' | 'D'>('E');
  const [editing, setEditing] = useState<{ coBook: string; vchNo: string } | null>(null);
  const [message, setMessage] = useState<{ ok: boolean; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    try {
      setRows(await get<RequestRow[]>('/utilities/user-requests'));
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    }
  }, []);

  useEffect(() => {
    void load();
  }, [load]);

  function reset() {
    setEditing(null);
    setCoBook('');
    setVchNo('');
    setAcCode('');
    setRemark('');
    setRequestType('E');
  }

  function edit(row: RequestRow) {
    setEditing({ coBook: row.coBook, vchNo: row.vchNo });
    setCoBook(row.coBook);
    setVchNo(row.vchNo);
    setAcCode(row.acCode);
    setRemark(row.remark);
    setRequestType(row.requestType === 'D' ? 'D' : 'E');
  }

  async function save(event: React.FormEvent) {
    event.preventDefault();
    setBusy(true);
    setMessage(null);
    try {
      const payload = { coBook, vchNo, acCode, remark, requestType };
      const result = editing
        ? await put<{ message: string }>(
            `/utilities/user-requests/${encodeURIComponent(editing.coBook)}/${encodeURIComponent(editing.vchNo)}`,
            payload,
          )
        : await post<{ message: string }>('/utilities/user-requests', payload);
      setMessage({ ok: true, text: result.message });
      reset();
      await load();
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function remove(row: RequestRow) {
    setBusy(true);
    setMessage(null);
    try {
      await del(
        `/utilities/user-requests/${encodeURIComponent(row.coBook)}/${encodeURIComponent(row.vchNo)}`,
      );
      setMessage({ ok: true, text: 'User request deleted' });
      await load();
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>User Request</h1>
      {message && (
        <div
          className={`msg ${message.ok ? 'ok' : 'err'}`}
          data-testid={message.ok ? 'user-request-saved' : undefined}
        >
          {message.text}
        </div>
      )}
      <form className="panel" onSubmit={save}>
        <div className="row">
          <div className="field">
            <label htmlFor="request-book">Book Code</label>
            <input
              id="request-book"
              maxLength={3}
              required
              value={coBook}
              onChange={(event) => setCoBook(event.target.value)}
              disabled={Boolean(editing)}
            />
          </div>
          <div className="field">
            <label htmlFor="request-voucher">Voucher Number</label>
            <input
              id="request-voucher"
              maxLength={8}
              required
              value={vchNo}
              onChange={(event) => setVchNo(event.target.value)}
              disabled={Boolean(editing)}
            />
          </div>
          <div className="field">
            <label htmlFor="request-account">Account Code</label>
            <input
              id="request-account"
              maxLength={10}
              value={acCode}
              onChange={(event) => setAcCode(event.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor="request-type">Request Type</label>
            <select
              id="request-type"
              value={requestType}
              onChange={(event) => setRequestType(event.target.value as 'E' | 'D')}
            >
              <option value="E">Edit</option>
              <option value="D">Delete</option>
            </select>
          </div>
        </div>
        <div className="field">
          <label htmlFor="request-remark">Reason / Remarks</label>
          <input
            id="request-remark"
            required
            maxLength={255}
            value={remark}
            onChange={(event) => setRemark(event.target.value)}
          />
        </div>
        <div className="row">
          <button type="submit" className="primary" disabled={busy}>
            {busy ? 'Saving…' : editing ? 'Update Request' : 'Send Request'}
          </button>
          <button type="button" onClick={reset} disabled={busy}>
            New Request
          </button>
          <button type="button" onClick={() => void load()} disabled={busy}>
            Refresh
          </button>
        </div>
      </form>
      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Book</th>
              <th>Voucher</th>
              <th>Date</th>
              <th>Account</th>
              <th>Type</th>
              <th>Reason</th>
              <th>Requested by</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((row) => (
              <tr key={`${row.coBook}/${row.vchNo}`}>
                <td>{row.coBook}</td>
                <td>{row.vchNo}</td>
                <td>{row.vchDate ?? ''}</td>
                <td>{row.acName || row.acCode}</td>
                <td>{row.requestType === 'D' ? 'Delete' : 'Edit'}</td>
                <td>{row.remark}</td>
                <td>{row.editUser}</td>
                <td>
                  <button type="button" onClick={() => edit(row)} disabled={busy}>
                    Edit
                  </button>{' '}
                  <button
                    type="button"
                    className="danger"
                    onClick={() => void remove(row)}
                    disabled={busy}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
            {!rows.length && (
              <tr>
                <td colSpan={8} className="muted">
                  No requests in the active company, location and year.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
