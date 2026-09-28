'use client';

import { useEffect, useState } from 'react';
import { ApiError, get, post } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

interface DataExportTablePreview {
  table: string;
  columns: number;
  rowCount: number;
  pendingRows: number | null;
  hasDataTransferFlag: boolean;
}

interface DataExportPreview {
  kind: string;
  generatedAt: string;
  scope: { tenantId: string; coCode: string; lcCode?: string; coYear?: string };
  tables: DataExportTablePreview[];
  totals: { tables: number; rows: number; pendingRows: number; flaggedTables: number };
}

interface FlagResult {
  state: 'Y' | 'N';
  pendingOnly: boolean;
  updated: Record<string, number>;
  total: number;
}

const errText = (e: unknown, fallback: string): string =>
  e instanceof ApiError ? e.body?.message || e.body?.error || e.message : fallback;
const numberFmt = (n: number | null): string => (n == null ? '—' : (Number(n) || 0).toLocaleString('en-IN'));

export default function DataExportPage() {
  const scope = useBusinessScope();
  const [preview, setPreview] = useState<DataExportPreview | null>(null);
  const [busy, setBusy] = useState<'preview' | 'mark' | 'reset' | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);

  async function loadPreview() {
    setBusy('preview');
    setMsg(null);
    try {
      setPreview(await get<DataExportPreview>('/utilities/data-export/preview'));
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Failed to load data export preview.') });
    } finally {
      setBusy(null);
    }
  }

  async function markExported() {
    const pending = preview?.totals.pendingRows ?? 0;
    if (pending <= 0) {
      setMsg({ kind: 'ok', text: 'No pending transfer rows to mark exported.' });
      return;
    }
    const ok = window.confirm(
      `Mark ${pending.toLocaleString('en-IN')} pending row${pending === 1 ? '' : 's'} as exported?`,
    );
    if (!ok) return;
    setBusy('mark');
    setMsg(null);
    try {
      const result = await post<FlagResult>('/utilities/data-export/mark-exported', { pendingOnly: true });
      setMsg({ kind: 'ok', text: `Marked ${result.total.toLocaleString('en-IN')} row${result.total === 1 ? '' : 's'} as exported.` });
      await loadPreview();
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Failed to mark rows exported.') });
    } finally {
      setBusy(null);
    }
  }

  async function resetFlags() {
    const ok = window.confirm(
      'Reset DATA_TRFR to N for every scoped export table row?\n\nUse this only when the next transfer must resend all rows.',
    );
    if (!ok) return;
    setBusy('reset');
    setMsg(null);
    try {
      const result = await post<FlagResult>('/utilities/data-export/reset-flags', {});
      setMsg({ kind: 'ok', text: `Reset ${result.total.toLocaleString('en-IN')} row${result.total === 1 ? '' : 's'} to pending transfer.` });
      await loadPreview();
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Failed to reset transfer flags.') });
    } finally {
      setBusy(null);
    }
  }

  useEffect(() => {
    void loadPreview();
  }, [scope.coCode, scope.lcCode, scope.coYear]);

  const rows = preview?.tables ?? [];
  const pendingUrl = '/api/utilities/data-export/download?pendingOnly=true';
  const allUrl = '/api/utilities/data-export/download?pendingOnly=false';

  return (
    <div>
      <h1>Data Export</h1>
      <p className="muted">
        Web replacement for desktop UT_EXPORT. It packages tenant/company scoped business rows for
        transfer and preserves the desktop DATA_TRFR pending/exported flag workflow.
      </p>

      <div className="panel">
        <div className="toolbar">
          <button className="primary" onClick={loadPreview} disabled={busy !== null}>
            {busy === 'preview' ? 'Loading…' : 'Refresh Preview'}
          </button>
          <a className="button ghost" href={pendingUrl}>Download Pending Rows</a>
          <a className="button ghost" href={allUrl}>Download All Scoped Rows</a>
          <button className="ghost" onClick={markExported} disabled={busy !== null || !preview}>
            {busy === 'mark' ? 'Marking…' : 'Mark Pending Exported'}
          </button>
          <button className="ghost" onClick={resetFlags} disabled={busy !== null || !preview}>
            {busy === 'reset' ? 'Resetting…' : 'Reset Flags to Pending'}
          </button>
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Scope: company <strong>{scope.coCode}</strong>, location <strong>{scope.lcCode}</strong>, year{' '}
          <strong>{scope.coYear}</strong>. Preview and download are read-only; the flag buttons update
          only rows in this scoped table family.
        </p>
      </div>

      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      {preview && (
        <div className="tiles">
          <div className="tile"><span className="muted">Export tables</span><div className="big">{preview.totals.tables}</div></div>
          <div className="tile"><span className="muted">Scoped rows</span><div className="big">{numberFmt(preview.totals.rows)}</div></div>
          <div className="tile"><span className="muted">Pending rows</span><div className="big">{numberFmt(preview.totals.pendingRows)}</div></div>
          <div className="tile"><span className="muted">Flagged tables</span><div className="big">{preview.totals.flaggedTables}</div></div>
        </div>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        <strong>Transfer table preview</strong>
        {!preview ? (
          <p className="muted">Load the preview to see table counts.</p>
        ) : rows.length === 0 ? (
          <p className="muted">No exportable tables were found in this schema.</p>
        ) : (
          <table className="grid">
            <thead>
              <tr>
                <th>Table</th>
                <th className="num">Columns</th>
                <th className="num">Scoped rows</th>
                <th className="num">Pending rows</th>
                <th>DATA_TRFR</th>
              </tr>
            </thead>
            <tbody>
              {rows.map((row) => (
                <tr key={row.table}>
                  <td>{row.table}</td>
                  <td className="num">{row.columns}</td>
                  <td className="num">{numberFmt(row.rowCount)}</td>
                  <td className="num">{numberFmt(row.pendingRows)}</td>
                  <td>{row.hasDataTransferFlag ? 'Yes' : 'No'}</td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr className="totals">
                <td>Total</td>
                <td />
                <td className="num">{numberFmt(preview.totals.rows)}</td>
                <td className="num">{numberFmt(preview.totals.pendingRows)}</td>
                <td>{preview.totals.flaggedTables}</td>
              </tr>
            </tfoot>
          </table>
        )}
      </div>
    </div>
  );
}
