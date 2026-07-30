'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

interface Member {
  membCode: string;
  membName: string;
  mobile?: string;
  pointCode?: string;
  points: number;
}

// MembershipError / invalid-data both surface a human message in the ApiError body (see routes `run`).
const errText = (e: unknown): string =>
  e instanceof ApiError
    ? e.body?.message || e.body?.detail || e.body?.error || e.message || 'failed'
    : e instanceof Error
      ? e.message || 'failed'
      : 'failed';

export default function MembershipPage() {
  const [members, setMembers] = useState<Member[]>([]);
  // POST /members  → { pointCode?, membCode, membName, mobile?, cardNo? }
  const [enroll, setEnroll] = useState({
    membCode: '',
    membName: '',
    mobile: '',
    pointCode: 'L1',
    cardNo: '',
  });
  // POST /members/points → { pointCode?, membCode, points, type, amount? }
  const [pts, setPts] = useState({
    membCode: '',
    type: 'earn',
    points: '',
    amount: '',
    pointCode: 'L1',
  });
  const [ptsResult, setPtsResult] = useState<{ vchNo: number; balance: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busyE, setBusyE] = useState(false);
  const [busyP, setBusyP] = useState(false);

  // GET /members → list with derived points balance
  const load = useCallback(async () => {
    setMembers(await get<Member[]>('/members').catch(() => []));
  }, []);
  useEffect(() => {
    load();
  }, [load]);

  async function doEnroll(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    const body = {
      membCode: enroll.membCode.trim(),
      membName: enroll.membName.trim(),
      mobile: enroll.mobile.trim() || undefined,
      pointCode: enroll.pointCode.trim() || undefined,
      cardNo: enroll.cardNo.trim() || undefined,
    };
    if (!body.membCode || !body.membName) {
      setMsg({ kind: 'err', text: 'member code and name are required' });
      return;
    }
    setBusyE(true);
    try {
      await post<{ enrolled: true }>('/members', body);
      setMsg({ kind: 'ok', text: `Member ${body.membCode} enrolled` });
      setEnroll({ membCode: '', membName: '', mobile: '', pointCode: 'L1', cardNo: '' });
      await load();
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err) });
    } finally {
      setBusyE(false);
    }
  }

  async function doPoints(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setPtsResult(null);
    const body = {
      membCode: pts.membCode.trim(),
      type: pts.type === 'redeem' ? 'redeem' : 'earn',
      points: Number(pts.points || 0),
      amount: Number(pts.amount || 0),
      pointCode: pts.pointCode.trim() || undefined,
    };
    if (!body.membCode) {
      setMsg({ kind: 'err', text: 'select a member' });
      return;
    }
    if (!(body.points > 0)) {
      setMsg({ kind: 'err', text: 'points must be positive' });
      return;
    }
    setBusyP(true);
    try {
      const r = await post<{ vchNo: number; balance: number }>('/members/points', body);
      setPtsResult(r);
      setMsg({
        kind: 'ok',
        text: `${body.type === 'redeem' ? 'Redeemed' : 'Earned'} ${body.points} pts for ${body.membCode} — balance ${r.balance} (voucher #${r.vchNo})`,
      });
      setPts((s) => ({ ...s, points: '', amount: '' }));
      await load();
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err) });
    } finally {
      setBusyP(false);
    }
  }

  return (
    <div>
      <h1>Membership &amp; Loyalty</h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      <div className="row">
        {/* ───── Section 1: Enroll ───── */}
        <form className="panel" style={{ flex: 1 }} onSubmit={doEnroll}>
          <h2>Enroll Member</h2>
          <div className="field">
            <label>Customer Account (Member Code)</label>
            <LookupPicker
              entity="accounts"
              value={enroll.membCode}
              onChange={(v) => setEnroll((s) => ({ ...s, membCode: v }))}
              onPick={(r) =>
                setEnroll((s) => ({
                  ...s,
                  membCode: String(r.code),
                  membName: r.name ? String(r.name) : s.membName,
                  mobile: r.AC_MOBILE ? String(r.AC_MOBILE) : s.mobile,
                }))
              }
            />
          </div>
          <div className="field">
            <label>Name</label>
            <input
              value={enroll.membName}
              onChange={(e) => setEnroll((s) => ({ ...s, membName: e.target.value }))}
              required
            />
          </div>
          <div className="row">
            <div className="field">
              <label>Mobile</label>
              <input
                value={enroll.mobile}
                onChange={(e) => setEnroll((s) => ({ ...s, mobile: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Point Code</label>
              <input
                value={enroll.pointCode}
                onChange={(e) => setEnroll((s) => ({ ...s, pointCode: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Card No</label>
              <input
                value={enroll.cardNo}
                onChange={(e) => setEnroll((s) => ({ ...s, cardNo: e.target.value }))}
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">POST /members</span>
            <span className="spacer" />
            <button className="primary" disabled={busyE}>
              {busyE ? 'Enrolling…' : 'Enroll'}
            </button>
          </div>
        </form>

        {/* ───── Section 2: Points ───── */}
        <form className="panel" style={{ flex: 1 }} onSubmit={doPoints}>
          <h2>Earn / Redeem Points</h2>
          <div className="field">
            <label>Member (Account)</label>
            <LookupPicker
              entity="accounts"
              value={pts.membCode}
              onChange={(v) => setPts((s) => ({ ...s, membCode: v }))}
            />
          </div>
          <div className="row">
            <div className="field">
              <label>Type</label>
              <select
                value={pts.type}
                onChange={(e) => setPts((s) => ({ ...s, type: e.target.value }))}
              >
                <option value="earn">Earn</option>
                <option value="redeem">Redeem</option>
              </select>
            </div>
            <div className="field">
              <label>Points</label>
              <input
                value={pts.points}
                onChange={(e) => setPts((s) => ({ ...s, points: e.target.value }))}
                required
              />
            </div>
            <div className="field">
              <label>Bill Amount ₹</label>
              <input
                value={pts.amount}
                onChange={(e) => setPts((s) => ({ ...s, amount: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Point Code</label>
              <input
                value={pts.pointCode}
                onChange={(e) => setPts((s) => ({ ...s, pointCode: e.target.value }))}
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">POST /members/points</span>
            <span className="spacer" />
            <button className="primary" disabled={busyP}>
              {busyP ? 'Posting…' : 'Post Points'}
            </button>
          </div>
          {ptsResult && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">balance</div>
                <div className="big kpi">{Number(ptsResult.balance).toLocaleString('en-IN')}</div>
              </div>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{ptsResult.vchNo}</div>
              </div>
            </div>
          )}
        </form>
      </div>

      {/* ───── Members list (refreshes after enroll / points) ───── */}
      <div className="panel" style={{ overflow: 'auto' }}>
        <div className="toolbar">
          <h2 style={{ margin: 0 }}>Members</h2>
          <span className="spacer" />
          <button type="button" className="ghost" onClick={() => load()}>
            Refresh
          </button>
        </div>
        <table className="grid">
          <thead>
            <tr>
              <th>Code</th>
              <th>Name</th>
              <th>Mobile</th>
              <th>Point</th>
              <th className="num">Points</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {members.map((m, i) => (
              <tr key={m.membCode + i}>
                <td>{m.membCode}</td>
                <td>{m.membName}</td>
                <td>{m.mobile}</td>
                <td>{m.pointCode}</td>
                <td className="num">{Number(m.points).toLocaleString('en-IN')}</td>
                <td>
                  <button
                    type="button"
                    className="ghost"
                    onClick={() =>
                      setPts((s) => ({
                        ...s,
                        membCode: m.membCode,
                        pointCode: m.pointCode || s.pointCode,
                      }))
                    }
                  >
                    Points
                  </button>
                </td>
              </tr>
            ))}
            {members.length === 0 && (
              <tr>
                <td colSpan={6} className="muted">
                  No members enrolled.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      {/* Desktop BtnImgS / BtnImgC / BtnImgD on this form photograph the record itself. */}
      <EntityImagePanel
        entityType="MEMB"
        entityKey={enroll.membCode}
        instance={0}
        label="Member photo"
        testId="membership-image"
      />
    </div>
  );
}
