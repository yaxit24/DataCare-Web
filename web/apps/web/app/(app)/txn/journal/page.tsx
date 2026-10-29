'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { todayLocal } from '../../../../lib/localDate';

interface Line {
  acCode: string;
  desc: string;
  debit: string;
  credit: string;
}
const blank = (): Line => ({ acCode: '', desc: '', debit: '', credit: '' });
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function JournalEntryPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const [narration, setNarration] = useState('');
  const [lines, setLines] = useState<Line[]>([blank(), blank()]);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [result, setResult] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');

  function resetForm() {
    setLoadedVch('');
    setLines([blank(), blank()]);
    setNarration('');
    setVchDate(todayLocal());
    setResult(null);
    setErr('');
  }

  async function loadJournal(vchNo: string) {
    setErr('');
    setResult(null);
    try {
      const d = await get<any>(
        `/journal/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setNarration(String(d.narration ?? ''));
      setVchDate(String(d.vchDate ?? todayLocal()).slice(0, 10));
      const rows: Line[] = (d.lines ?? []).map((l: any) => ({
        acCode: String(l.acCode ?? ''),
        desc: String(l.desc ?? ''),
        debit: Number(l.drAmt ?? 0) ? String(l.drAmt) : '',
        credit: Number(l.crAmt ?? 0) ? String(l.crAmt) : '',
      }));
      setLines(rows.length ? rows : [blank(), blank()]);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed to load');
    }
  }

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // Live double-entry totals: balanced when Σ Debit == Σ Credit (and non-zero).
  const totDebit = r2(lines.reduce((s, l) => s + n(l.debit), 0));
  const totCredit = r2(lines.reduce((s, l) => s + n(l.credit), 0));
  const diff = r2(totDebit - totCredit);
  const balanced = totDebit === totCredit && totDebit > 0;
  const validLines = lines.filter((l) => l.acCode.trim() && (n(l.debit) > 0 || n(l.credit) > 0));
  const canSubmit = balanced && validLines.length >= 2;

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        vchDate: vchDate || undefined,
        narration: narration || undefined,
        lines: validLines.map((l) => ({
          acCode: l.acCode,
          drAmt: Number(l.debit || 0),
          crAmt: Number(l.credit || 0),
          desc: l.desc || undefined,
        })),
      };
      setResult(
        loadedVch
          ? await put<{ vchNo: number }>(`/journal/${encodeURIComponent(loadedVch)}`, body)
          : await post<{ vchNo: number }>('/journal', body),
      );
      if (!loadedVch) {
        setLines([blank(), blank()]);
        setNarration('');
      }
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Journal Voucher</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="JV"
                mainBooks={['JOURNAL']}
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
            <div className="field">
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Narration</label>
              <input
                value={narration}
                onChange={(e) => setNarration(e.target.value)}
                placeholder="reason for the adjustment"
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Entries</h2>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Account</th>
                <th>Description</th>
                <th className="num">Debit</th>
                <th className="num">Credit</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={l.acCode}
                      onChange={(v) => setLine(i, 'acCode', v)}
                      onPick={(r) => {
                        if (!l.desc) setLine(i, 'desc', String(r.name || ''));
                      }}
                      style={{ width: 180 }}
                    />
                  </td>
                  <td>
                    <input
                      style={{ width: '100%', minWidth: 200 }}
                      value={l.desc}
                      onChange={(e) => setLine(i, 'desc', e.target.value)}
                      placeholder="line note"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 110, textAlign: 'right' }}
                      value={l.debit}
                      onChange={(e) => setLine(i, 'debit', e.target.value)}
                      disabled={n(l.credit) > 0}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 110, textAlign: 'right' }}
                      value={l.credit}
                      onChange={(e) => setLine(i, 'credit', e.target.value)}
                      disabled={n(l.debit) > 0}
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setLines((ls) =>
                          ls.length > 2
                            ? ls.filter((_, j) => j !== i)
                            : ls.map((x, j) => (j === i ? blank() : x)),
                        )
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={2} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Totals
                </td>
                <td className="num">
                  <b>{totDebit.toLocaleString('en-IN')}</b>
                </td>
                <td className="num">
                  <b>{totCredit.toLocaleString('en-IN')}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>

          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Dr ₹{totDebit.toLocaleString('en-IN')} · Cr ₹{totCredit.toLocaleString('en-IN')} ·{' '}
              {balanced ? (
                <b style={{ color: 'var(--ok)' }}>Balanced ✓</b>
              ) : (
                <b style={{ color: 'var(--err)' }}>Difference ₹{diff.toLocaleString('en-IN')}</b>
              )}
            </span>
            {loadedVch && (
              <button type="button" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
            <button className="primary" disabled={busy || !canSubmit}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Post Journal'}
            </button>
          </div>
          {!balanced && totDebit + totCredit > 0 && (
            <div className="muted" style={{ marginTop: 6 }}>
              Debits must equal credits to post.
            </div>
          )}
          {balanced && validLines.length < 2 && (
            <div className="muted" style={{ marginTop: 6 }}>
              A journal needs at least 2 lines.
            </div>
          )}
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            {loadedVch ? 'Updated' : 'Posted'} — Journal Voucher #{result.vchNo}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="CONTRA_DATA"
          book={coBook}
          deleteBase="/journal"
          onLoad={(vchNo) => void loadJournal(vchNo)}
          printHref={(v) =>
            `/api/journal/${encodeURIComponent(v)}/print?coBook=${encodeURIComponent(coBook)}&format=html`
          }
          reloadKey={result?.vchNo}
        />
      )}
    </div>
  );
}
