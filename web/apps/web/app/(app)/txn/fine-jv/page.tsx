'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import { LookupPicker } from '../../../../components/LookupPicker';

// FINE-JV (desktop FJV): a pure metal-weight transfer between two parties — no money moves.
// The TO party receives fine (+), the FROM party gives fine (−); the API writes the two contra legs.
export default function FineJvPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [fromAc, setFromAc] = useState('');
  const [fromName, setFromName] = useState('');
  // P3: receiving account name, as the desktop denormalises it onto the voucher.
  const [toAcName, setToAcName] = useState('');
  const [toAc, setToAc] = useState('');
  const [toName, setToName] = useState('');
  const [fineWt, setFineWt] = useState('');
  const [metal, setMetal] = useState<'G' | 'S'>('G');
  const [result, setResult] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');

  function resetForm() {
    setLoadedVch('');
    setFromAc('');
    setFromName('');
    setToAc('');
    setToName('');
    setToAcName('');
    setFineWt('');
    setResult(null);
    setErr('');
  }

  async function loadFineJv(vchNo: string) {
    setErr('');
    setResult(null);
    try {
      const d = await get<any>(
        `/fine-jv/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setFromAc(String(d.fromAc ?? ''));
      setToAc(String(d.toAc ?? ''));
      setFineWt(String(d.fineWt ?? ''));
      setMetal(String(d.metal ?? 'G') === 'S' ? 'S' : 'G');
      setVchDate(String(d.vchDate ?? '').slice(0, 10));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed to load');
    }
  }

  const wt = Number(fineWt || 0);
  const sameAc = !!fromAc && !!toAc && fromAc === toAc;
  const canSubmit = !!fromAc && !!toAc && !sameAc && wt > 0;

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        toAcName: toAcName.trim() || undefined,
        coBook,
        coYear,
        lcCode,
        vchDate: vchDate || undefined,
        fromAc,
        toAc,
        fineWt: wt,
        metal,
      };
      setResult(
        loadedVch
          ? await put<{ vchNo: number }>(`/fine-jv/${encodeURIComponent(loadedVch)}`, body)
          : await post<{ vchNo: number }>('/fine-jv', body),
      );
      if (!loadedVch) setFineWt('');
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Fine JV — Metal Weight Transfer</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>To A/c Name</label>
              <input value={toAcName} onChange={(e) => setToAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="FJV" />
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
          </div>
        </div>

        <div className="panel">
          <h2>Transfer</h2>
          <div className="row">
            <div className="field" style={{ flex: 2 }}>
              <label>From party (gives fine −)</label>
              <LookupPicker
                entity="accounts"
                value={fromAc}
                onChange={setFromAc}
                onPick={(r) => setFromName(String(r.name || ''))}
                placeholder="search accounts…"
              />
              {fromName && (
                <span className="muted" style={{ fontSize: 12 }}>
                  {fromName}
                </span>
              )}
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>To party (receives fine +)</label>
              <LookupPicker
                entity="accounts"
                value={toAc}
                onChange={setToAc}
                onPick={(r) => setToName(String(r.name || ''))}
                placeholder="search accounts…"
              />
              {toName && (
                <span className="muted" style={{ fontSize: 12 }}>
                  {toName}
                </span>
              )}
            </div>
            <div className="field">
              <label>Metal</label>
              <select value={metal} onChange={(e) => setMetal(e.target.value as 'G' | 'S')}>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field">
              <label>Fine Wt</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={fineWt}
                inputMode="decimal"
                onChange={(e) => setFineWt(e.target.value)}
                placeholder="0.000"
              />
            </div>
          </div>

          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">
              {fromAc && toAc && wt > 0 && !sameAc ? (
                <>
                  Transfer <b>{wt.toLocaleString('en-IN')}</b> fine{' '}
                  {metal === 'G' ? 'gold' : 'silver'}: <b>{toAc}</b> receives (+), <b>{fromAc}</b>{' '}
                  gives (−)
                </>
              ) : (
                'Pick both parties and a fine weight to post.'
              )}
            </span>
            <span className="spacer" />
            {sameAc && (
              <span className="muted" style={{ marginRight: 16, color: 'var(--err)' }}>
                From and To must be different accounts
              </span>
            )}
            {loadedVch && (
              <button type="button" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
            <button className="primary" data-save-mnemonic disabled={busy || !canSubmit}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Fine JV'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            {loadedVch ? 'Updated' : 'Posted'} — Fine JV #{result.vchNo}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="CONTRA_DATA"
          book={coBook}
          deleteBase="/fine-jv"
          onLoad={(vchNo) => void loadFineJv(vchNo)}
          reloadKey={result?.vchNo}
        />
      )}
    </div>
  );
}
