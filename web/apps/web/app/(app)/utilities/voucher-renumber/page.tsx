'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';

/**
 * Voucher Renumber (Phase 12 / UT) — desktop UT_VCH_RENO parity.
 *
 * Preview is a READ-ONLY dry-run (GET /utilities/vch-renumber/preview?book=) that shows each
 * voucher's current number, its proposed gapless number (1..N ordered by date then number), its date
 * and ledger-leg count, plus how many numbers would change. Apply (POST /utilities/vch-renumber/apply
 * {book, confirm:true}) performs the collision-safe renumber across every voucher table in one
 * transaction; it is disabled until a preview has run and is guarded by an explicit confirm. Scope
 * (company / year / location) is taken from the session on the server — the page only sends the book.
 */

interface RenumberRow {
  vchNo: number;
  newNo: number;
  vchDate: string;
  legs: number;
}

interface PreviewResult {
  rows: RenumberRow[];
  gaps: number;
}

interface ApplyResult {
  renumbered: number;
  tablesTouched: string[];
}

const apiErr = (e: unknown, fallback: string): string =>
  e instanceof ApiError ? e.body?.error || e.body?.message || e.message : fallback;

export default function VoucherRenumberPage() {
  const [book, setBook] = useState('');
  const [preview, setPreview] = useState<PreviewResult | null>(null);
  const [previewedBook, setPreviewedBook] = useState('');
  const [result, setResult] = useState<ApplyResult | null>(null);
  const [loadingPreview, setLoadingPreview] = useState(false);
  const [loadingApply, setLoadingApply] = useState(false);
  const [err, setErr] = useState('');

  async function runPreview(): Promise<PreviewResult | null> {
    const b = book.trim();
    if (!b) return null;
    setLoadingPreview(true);
    setErr('');
    setResult(null);
    setPreview(null);
    try {
      const r = await get<PreviewResult>(
        `/utilities/vch-renumber/preview?book=${encodeURIComponent(b)}`,
      );
      setPreview(r);
      setPreviewedBook(b);
      return r;
    } catch (e) {
      setErr(apiErr(e, 'Failed to compute the renumber preview'));
      return null;
    } finally {
      setLoadingPreview(false);
    }
  }

  async function runApply() {
    const b = book.trim();
    if (!b || !preview) return;
    if (preview.gaps === 0) {
      setErr(`Book ${b} is already gapless (1..${preview.rows.length}). Nothing to renumber.`);
      return;
    }
    const ok = window.confirm(
      `Renumber book ${b}?\n\n` +
        `This rewrites VCH_NO for ${preview.gaps} voucher(s) to a gapless 1..${preview.rows.length} ` +
        `sequence across ALL of the book's tables (ledger, header, detail, tax, stock). ` +
        `It runs in one transaction and CANNOT be undone except by restoring a backup.\n\n` +
        `Make sure you have a current backup before continuing.`,
    );
    if (!ok) return;
    setLoadingApply(true);
    setErr('');
    try {
      const r = await post<ApplyResult>('/utilities/vch-renumber/apply', {
        book: b,
        confirm: true,
      });
      setResult(r);
      await runPreview(); // refresh — the book should now be gapless
    } catch (e) {
      setErr(apiErr(e, 'Renumber failed — no changes were committed'));
    } finally {
      setLoadingApply(false);
    }
  }

  const rows = preview?.rows ?? [];
  const stale = preview != null && previewedBook !== book.trim();
  const canApply = !!preview && !stale && preview.gaps > 0;

  return (
    <div>
      <h1>Voucher Renumber</h1>
      <p className="muted">
        Resequence a book&apos;s vouchers to a gapless <code>1..N</code> (ordered by date, then
        number) across every voucher table. Preview is a read-only dry-run; applying rewrites the
        voucher numbers in one transaction and is guarded by a confirm. Mirrors the desktop
        UT_VCH_RENO.
      </p>

      <div className="panel">
        <div className="toolbar">
          <div className="field" style={{ marginBottom: 0 }}>
            <label>Book (CO_BOOK)</label>
            <input
              value={book}
              onChange={(e) => setBook(e.target.value)}
              placeholder="e.g. 026"
              style={{ width: 120 }}
              onKeyDown={(e) => {
                if (e.key === 'Enter') void runPreview();
              }}
            />
          </div>
          <button
            className="primary"
            onClick={() => void runPreview()}
            disabled={loadingPreview || !book.trim()}
          >
            {loadingPreview ? 'Previewing…' : 'Preview (dry-run)'}
          </button>
          <button
            className="ghost"
            onClick={() => void runApply()}
            disabled={loadingApply || !canApply}
            title={
              !preview
                ? 'Preview the renumber first'
                : stale
                  ? 'Book changed — preview again'
                  : preview.gaps === 0
                    ? 'Already gapless — nothing to renumber'
                    : ''
            }
          >
            {loadingApply ? 'Renumbering…' : 'Apply Renumber'}
          </button>
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Preview is read-only. Apply rewrites <code>VCH_NO</code> for every changed voucher across
          all its tables in one transaction — take a backup first. Safe to re-run (a gapless book is
          a no-op).
        </p>
      </div>

      {err && <div className="msg err">{err}</div>}

      {result && (
        <div className="msg ok">
          Renumbered {result.renumbered} voucher{result.renumbered === 1 ? '' : 's'}
          {result.tablesTouched.length > 0 ? (
            <>
              {' '}
              across {result.tablesTouched.length} table
              {result.tablesTouched.length === 1 ? '' : 's'}:{' '}
              <code>{result.tablesTouched.join(', ')}</code>
            </>
          ) : (
            ' (no changes were needed)'
          )}
          .
        </div>
      )}

      {preview && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ justifyContent: 'space-between' }}>
            <strong>
              {previewedBook ? `Book ${previewedBook}` : 'Preview'} — {preview.rows.length} voucher
              {preview.rows.length === 1 ? '' : 's'}
            </strong>
            <span
              className={preview.gaps > 0 ? 'msg err' : 'muted'}
              style={{ padding: preview.gaps > 0 ? '2px 8px' : 0 }}
            >
              {preview.gaps > 0
                ? `${preview.gaps} number${preview.gaps === 1 ? '' : 's'} would change`
                : 'Already gapless — no changes'}
            </span>
          </div>
          {stale && (
            <p className="muted">
              Book changed since this preview — run the preview again before applying.
            </p>
          )}
          {rows.length === 0 ? (
            <span className="muted">No numeric vouchers found for this book.</span>
          ) : (
            <table className="grid">
              <thead>
                <tr>
                  <th className="num">Current VchNo</th>
                  <th className="num">New No</th>
                  <th>Date</th>
                  <th className="num">Legs</th>
                </tr>
              </thead>
              <tbody>
                {rows.map((r) => {
                  const changed = r.vchNo !== r.newNo;
                  return (
                    <tr key={r.vchNo} style={changed ? { fontWeight: 600 } : undefined}>
                      <td className="num">{r.vchNo}</td>
                      <td className="num">{changed ? `→ ${r.newNo}` : r.newNo}</td>
                      <td>{r.vchDate || '—'}</td>
                      <td className="num">{r.legs}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          )}
        </div>
      )}
    </div>
  );
}
