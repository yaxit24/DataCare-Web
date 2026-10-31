'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';

/**
 * Card Receipt / CARD ADJUST (desktop TR_CARD_REC). A customer card settlement: the party is credited
 * the gross card charge (card amount + card commission), the acquiring bank is debited, bank commission
 * is retained, and any cash paid back is debited to the party. Posts to /card-receipts on the CRD
 * (CARD ADJUST) book. Full lifecycle: create / reopen / edit / delete.
 */
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function CardReceiptPage() {
  const [coBook, setCoBook] = useState('');
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [bankAc, setBankAc] = useState('');
  const [bankName, setBankName] = useState('');
  const [cardAmt, setCardAmt] = useState('');
  const [cardComPrc, setCardComPrc] = useState('');
  const [bankComPrc, setBankComPrc] = useState('');
  const [bankSchPrc, setBankSchPrc] = useState('');
  const [cashPaid, setCashPaid] = useState('');
  const [desc, setDesc] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [res, setRes] = useState<{ vchNo: number; totals?: any } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');

  // Local preview (server is authoritative): card commission to a whole unit, gross = amt + comm,
  // bank commission on the base, net = gross − bank comm, party net = amt − cash paid.
  const amt = n(cardAmt);
  const cardCom = cardComPrc.trim() ? Math.round((amt * n(cardComPrc)) / 100) : 0;
  const gross = r2(amt + cardCom);
  const bankBase = n(cashPaid) !== 0 ? amt : gross;
  const bankComm1 = bankComPrc.trim() ? r2((bankBase * n(bankComPrc)) / 100) : 0;
  const bankComm2 = bankComm1 && bankSchPrc.trim() ? r2((bankComm1 * n(bankSchPrc)) / 100) : 0;
  const bankCom = r2(bankComm1 + bankComm2);
  const bankNet = r2(gross - bankCom);

  function resetForm() {
    setLoadedVch('');
    setPartyAc('');
    setPartyName('');
    setBankAc('');
    setBankName('');
    setCardAmt('');
    setCardComPrc('');
    setBankComPrc('');
    setBankSchPrc('');
    setCashPaid('');
    setDesc('');
    setRes(null);
    setErr('');
  }

  async function loadCard(vchNo: string) {
    setErr('');
    setRes(null);
    try {
      const d = await get<any>(
        `/card-receipts/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setPartyAc(String(d.partyAc ?? ''));
      setPartyName(String(d.partyName ?? ''));
      setBankAc(String(d.bankAc ?? ''));
      setBankName(String(d.bankName ?? ''));
      setCardAmt(String(d.cardAmt ?? ''));
      setCardComPrc(Number(d.cardComPrc ?? 0) ? String(d.cardComPrc) : '');
      setBankComPrc(Number(d.bankComPrc ?? 0) ? String(d.bankComPrc) : '');
      setBankSchPrc(Number(d.bankSchPrc ?? 0) ? String(d.bankSchPrc) : '');
      setCashPaid(Number(d.cashPaid ?? 0) ? String(d.cashPaid) : '');
      setDesc(String(d.desc ?? ''));
      setVchDate(String(d.vchDate ?? '').slice(0, 10));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed to load');
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    if (!coBook) return setErr('select the Card Adjust book first');
    if (!partyAc.trim()) return setErr('pick the customer/party account');
    if (!bankAc.trim()) return setErr('pick the card bank account');
    if (!(amt > 0)) return setErr('card amount must be positive');
    setBusy(true);
    try {
      const body = {
        coBook,
        partyAc: partyAc.trim(),
        partyName: partyName || undefined,
        bankAc: bankAc.trim(),
        bankName: bankName || undefined,
        cardAmt: amt,
        cardComPrc: cardComPrc.trim() ? n(cardComPrc) : undefined,
        bankComPrc: bankComPrc.trim() ? n(bankComPrc) : undefined,
        bankSchPrc: bankSchPrc.trim() ? n(bankSchPrc) : undefined,
        cashPaid: cashPaid.trim() ? n(cashPaid) : undefined,
        desc: desc || undefined,
        vchDate: vchDate || undefined,
      };
      const saved = loadedVch
        ? await put<{ vchNo: number; totals?: any }>(
            `/card-receipts/${encodeURIComponent(loadedVch)}`,
            body,
          )
        : await post<{ vchNo: number; totals?: any }>('/card-receipts', body);
      setRes(saved);
      if (!loadedVch) {
        setCardAmt('');
        setCardComPrc('');
        setBankComPrc('');
        setBankSchPrc('');
        setCashPaid('');
        setDesc('');
      }
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Card Receipt <span className="muted">— CARD ADJUST (TR_CARD_REC)</span>
      </h1>
      {err && <div className="msg err">{err}</div>}
      <form className="panel" onSubmit={submit}>
        <div className="row">
          <div className="field">
            <label>Book</label>
            <BookSelect
              value={coBook}
              onChange={setCoBook}
              preferred="CRD"
              mainBooks={['CARD ADJUST']}
            />
          </div>
          <div className="field">
            <label>Date</label>
            <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label>Customer (party)</label>
            <LookupPicker
              entity="accounts"
              value={partyAc}
              onChange={setPartyAc}
              onPick={(r) => setPartyName(String(r.name || ''))}
            />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label>Card Bank A/c</label>
            <LookupPicker
              entity="accounts"
              value={bankAc}
              onChange={setBankAc}
              onPick={(r) => setBankName(String(r.name || ''))}
            />
          </div>
        </div>
        <div className="row">
          <div className="field">
            <label>Card Amount ₹</label>
            <input value={cardAmt} onChange={(e) => setCardAmt(e.target.value)} required />
          </div>
          <div className="field">
            <label>Card Comm %</label>
            <input value={cardComPrc} onChange={(e) => setCardComPrc(e.target.value)} />
          </div>
          <div className="field">
            <label>Bank Comm %</label>
            <input value={bankComPrc} onChange={(e) => setBankComPrc(e.target.value)} />
          </div>
          <div className="field">
            <label>Sch Charg %</label>
            <input value={bankSchPrc} onChange={(e) => setBankSchPrc(e.target.value)} />
          </div>
          <div className="field">
            <label>Cash Paid ₹</label>
            <input value={cashPaid} onChange={(e) => setCashPaid(e.target.value)} />
          </div>
        </div>
        <div className="row">
          <div className="field" style={{ flex: 3 }}>
            <label>Narration</label>
            <input value={desc} onChange={(e) => setDesc(e.target.value)} />
          </div>
        </div>
        <div className="tiles" style={{ marginTop: 8 }}>
          <div className="tile">
            <div className="muted">card comm</div>
            <div className="big kpi">{cardCom.toLocaleString('en-IN')}</div>
          </div>
          <div className="tile">
            <div className="muted">gross charged</div>
            <div className="big kpi">{gross.toLocaleString('en-IN')}</div>
          </div>
          <div className="tile">
            <div className="muted">bank comm</div>
            <div className="big kpi">{bankCom.toLocaleString('en-IN')}</div>
          </div>
          <div className="tile">
            <div className="muted">bank net</div>
            <div className="big kpi">{bankNet.toLocaleString('en-IN')}</div>
          </div>
        </div>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <span className="muted">
            POST /card-receipts · server computes the authoritative figures
          </span>
          <span className="spacer" />
          {loadedVch && (
            <button type="button" onClick={resetForm} disabled={busy}>
              New
            </button>
          )}
          <button className="primary" data-save-mnemonic disabled={busy || !coBook}>
            {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Card Receipt'}
          </button>
        </div>
      </form>
      {res && (
        <div className="panel">
          <div className="msg ok">
            Card receipt {loadedVch ? 'updated' : 'posted'} — Voucher #{res.vchNo}
            {res.totals
              ? ` · bank net ₹${Number(res.totals.bankNet ?? 0).toLocaleString('en-IN')}`
              : ''}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="CARD_DATA"
          book={coBook}
          deleteBase="/card-receipts"
          onLoad={(vchNo) => void loadCard(vchNo)}
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
