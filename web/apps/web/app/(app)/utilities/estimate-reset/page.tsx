'use client';

import { useCallback, useEffect, useMemo, useState } from 'react';
import { ApiError, post } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

interface EstimateResetDiff {
  table: string;
  insert: number;
  update: number;
  delete: number;
}

interface EstimateResetPreview {
  kind: string;
  generatedAt: string;
  asOfDate: string;
  scope: { tenantId: string; coCode: string; lcCode: string; coYear: string };
  companyType: string;
  desktopSource: string[];
  diffs: EstimateResetDiff[];
  samples: string[];
  totals: {
    insert: number;
    update: number;
    delete: number;
    selectedVouchers: number;
    stockAdjustmentDetails: number;
  };
  requiresConfirmation: string;
  postApplyMessage: string;
  registrationSpecificBranches: string[];
  applied?: boolean;
}

const today = () => new Date().toISOString().slice(0, 10);
const num = (value: number) => Number(value || 0).toLocaleString('en-IN');
const errText = (e: unknown, fallback: string): string =>
  e instanceof ApiError ? e.body?.message || e.body?.error || e.message : fallback;

export default function EstimateResetPage() {
  const scope = useBusinessScope();
  const [asOfDate, setAsOfDate] = useState(today());
  const [preview, setPreview] = useState<EstimateResetPreview | null>(null);
  const [confirmation, setConfirmation] = useState('');
  const [busy, setBusy] = useState<'preview' | 'apply' | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);

  const canApply = useMemo(
    () => preview && preview.totals.delete + preview.totals.insert + preview.totals.update > 0,
    [preview],
  );

  const loadPreview = useCallback(async function loadPreview() {
    setBusy('preview');
    setMsg(null);
    try {
      const next = await post<EstimateResetPreview>('/utilities/estimate-reset/preview', { asOfDate });
      setPreview(next);
      setConfirmation('');
    } catch (e) {
      setPreview(null);
      setMsg({ kind: 'err', text: errText(e, 'Failed to load Estimate Reset preview.') });
    } finally {
      setBusy(null);
    }
  }, [asOfDate]);

  async function applyReset() {
    if (!preview) return;
    if (confirmation.trim().toUpperCase() !== preview.requiresConfirmation) {
      setMsg({ kind: 'err', text: `Type ${preview.requiresConfirmation} before applying.` });
      return;
    }
    const ok = window.confirm(
      `Estimate Reset will permanently delete ${num(preview.totals.delete)} row${preview.totals.delete === 1 ? '' : 's'} and insert ${num(preview.totals.insert)} stock-adjust row${preview.totals.insert === 1 ? '' : 's'} for company ${scope.coCode}, location ${scope.lcCode}, year ${scope.coYear} through ${preview.asOfDate}.`,
    );
    if (!ok) return;
    setBusy('apply');
    setMsg(null);
    try {
      const applied = await post<EstimateResetPreview>('/utilities/estimate-reset/apply', {
        asOfDate: preview.asOfDate,
        confirmation,
      });
      setPreview(applied);
      setMsg({ kind: 'ok', text: applied.postApplyMessage });
      setConfirmation('');
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Failed to apply Estimate Reset.') });
    } finally {
      setBusy(null);
    }
  }

  useEffect(() => {
    void loadPreview();
  }, [scope.coCode, scope.lcCode, scope.coYear, loadPreview]);

  const diffs = preview?.diffs ?? [];

  return (
    <div>
      <h1>Estimate Reset</h1>
      <p className="muted">
        Web replacement for desktop UT_IMPORT Estimate Reset. It previews and applies the desktop reset-book
        cleanup for estimate sales, tag-cancel vouchers, wholesale sales, and orphan approval tags.
      </p>

      <div className="panel">
        <div className="toolbar">
          <label>
            Estimate Reset As On{' '}
            <input type="date" value={asOfDate} onChange={(e) => setAsOfDate(e.target.value)} />
          </label>
          <button className="primary" onClick={loadPreview} disabled={busy !== null}>
            {busy === 'preview' ? 'Loading…' : 'Preview Reset'}
          </button>
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Scope: company <strong>{scope.coCode}</strong>, location <strong>{scope.lcCode}</strong>, year{' '}
          <strong>{scope.coYear}</strong>. Apply requires Delete rights on Utilities / Estimate Reset.
        </p>
      </div>

      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      {preview && (
        <>
          <div className="tiles">
            <div className="tile"><span className="muted">Selected vouchers</span><div className="big">{num(preview.totals.selectedVouchers)}</div></div>
            <div className="tile"><span className="muted">Rows to delete</span><div className="big">{num(preview.totals.delete)}</div></div>
            <div className="tile"><span className="muted">Rows to insert</span><div className="big">{num(preview.totals.insert)}</div></div>
            <div className="tile"><span className="muted">Stock-adjust details</span><div className="big">{num(preview.totals.stockAdjustmentDetails)}</div></div>
          </div>

          <div className="panel" style={{ overflow: 'auto' }}>
            <strong>Reset table impact</strong>
            {diffs.length === 0 ? (
              <p className="muted">No eligible reset rows were found for this date and scope.</p>
            ) : (
              <table className="grid">
                <thead>
                  <tr>
                    <th>Table</th>
                    <th className="num">Insert</th>
                    <th className="num">Update</th>
                    <th className="num">Delete</th>
                  </tr>
                </thead>
                <tbody>
                  {diffs.map((row) => (
                    <tr key={row.table}>
                      <td>{row.table}</td>
                      <td className="num">{num(row.insert)}</td>
                      <td className="num">{num(row.update)}</td>
                      <td className="num">{num(row.delete)}</td>
                    </tr>
                  ))}
                </tbody>
                <tfoot>
                  <tr className="totals">
                    <td>Total</td>
                    <td className="num">{num(preview.totals.insert)}</td>
                    <td className="num">{num(preview.totals.update)}</td>
                    <td className="num">{num(preview.totals.delete)}</td>
                  </tr>
                </tfoot>
              </table>
            )}
          </div>

          <div className="panel">
            <strong>Voucher samples</strong>
            {preview.samples.length ? (
              <ul>
                {preview.samples.map((sample) => <li key={sample}>{sample}</li>)}
              </ul>
            ) : (
              <p className="muted">No voucher samples available.</p>
            )}
          </div>

          <div className="panel">
            <strong>Apply reset</strong>
            <p className="muted">
              Desktop message after completion: {preview.postApplyMessage} This web action creates the same
              stock-adjust return rows before deleting eligible reset-book vouchers.
            </p>
            <label>
              Type <strong>{preview.requiresConfirmation}</strong>{' '}
              <input value={confirmation} onChange={(e) => setConfirmation(e.target.value)} />
            </label>
            <div className="toolbar" style={{ marginTop: 12 }}>
              <button className="danger" onClick={applyReset} disabled={busy !== null || !canApply}>
                {busy === 'apply' ? 'Applying…' : 'Apply Estimate Reset'}
              </button>
              <a className="button ghost" href="/utilities/data-refresh">Open Data Refresh</a>
            </div>
          </div>
        </>
      )}
    </div>
  );
}
