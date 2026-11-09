'use client';

import { useState } from 'react';
import { round, toIsoDate } from '@datacare/core';
import { ApiError, del, get, post, put } from '../lib/api';
import { todayLocal } from '../lib/localDate';
import { useBusinessScope } from './BusinessScope';
import { BookSelect } from './BookSelect';
import { LookupPicker } from './LookupPicker';
import { useSubDetail } from './SubDetailGrid';
import {
  ApprovalGrid,
  approvalFine,
  approvalLineFromApi,
  approvalLineInput,
  approvalStonesFromApi,
  blankApprovalLine,
  type ApprovalExtendedField,
  type ApprovalLine,
} from './ApprovalGrid';

interface ApprovalView {
  voucherNo: string;
  vchDate: string;
  vchTime: string;
  partyAc: string;
  partyName: string;
  empCode: string;
  empName: string;
  vchDesc: string;
  origVchNo: string;
  origBook: string;
  origYear: string;
  version: string;
  lines: Array<Record<string, unknown>>;
}
interface SaveResult {
  vchNo: number;
  voucherNo: string;
  fine: number;
  version: string;
  closedLines?: number;
}

const messageOf = (error: unknown): string =>
  error instanceof ApiError
    ? String(error.body?.message ?? error.body?.detail ?? error.body?.error ?? error.message)
    : error instanceof Error
      ? error.message
      : 'Approval operation failed';

export default function ApprovalVoucherForm({
  kind,
  extendedFields,
}: {
  kind: 'issue' | 'return';
  extendedFields: ApprovalExtendedField[];
}) {
  const returning = kind === 'return';
  const title = returning ? 'Approval Return' : 'Approval Issue';
  const mainBook = returning ? 'APR RTN' : 'APR ISU';
  const preferredBook = returning ? 'TRR' : 'TUR';
  const route = returning ? '/tour/return' : '/tour';
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [origBook, setOrigBook] = useState('');
  const [origYear, setOrigYear] = useState(coYear);
  const [origVchNo, setOrigVchNo] = useState('');
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedNo, setLoadedNo] = useState('');
  const [version, setVersion] = useState('');
  const [vchDate, setVchDate] = useState(todayLocal());
  const [vchTime, setVchTime] = useState(() =>
    new Date().toLocaleTimeString('en-GB', { hour12: false }),
  );
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [empCode, setEmpCode] = useState('');
  const [empName, setEmpName] = useState('');
  const [vchDesc, setVchDesc] = useState('');
  const [lines, setLines] = useState<ApprovalLine[]>([blankApprovalLine()]);
  const [fullGrid, setFullGrid] = useState(false);
  const [busy, setBusy] = useState(false);
  const [status, setStatus] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const sub = useSubDetail(lines.length);

  const reset = () => {
    setVoucherNo('');
    setLoadedNo('');
    setVersion('');
    setVchDate(todayLocal());
    setVchTime(new Date().toLocaleTimeString('en-GB', { hour12: false }));
    setPartyAc('');
    setPartyName('');
    setEmpCode('');
    setEmpName('');
    setVchDesc('');
    setOrigVchNo('');
    setOrigBook('');
    setOrigYear(coYear);
    setLines([blankApprovalLine()]);
    sub.reset();
    setStatus(null);
  };

  const hydrate = (view: ApprovalView) => {
    setVoucherNo(view.voucherNo);
    setLoadedNo(view.voucherNo);
    setVersion(view.version);
    setVchDate(toIsoDate(view.vchDate || todayLocal()));
    setVchTime(String(view.vchTime || '').slice(0, 8));
    setPartyAc(String(view.partyAc || ''));
    setPartyName(String(view.partyName || ''));
    setEmpCode(String(view.empCode || ''));
    setEmpName(String(view.empName || ''));
    setVchDesc(String(view.vchDesc || ''));
    setOrigVchNo(String(view.origVchNo || ''));
    setOrigBook(String(view.origBook || ''));
    setOrigYear(String(view.origYear || coYear));
    const loaded = (view.lines ?? []).map((line) => approvalLineFromApi(line));
    setLines(loaded.length ? loaded : [blankApprovalLine()]);
    sub.load((view.lines ?? []).map((line) => approvalStonesFromApi(line)));
    setStatus({ kind: 'ok', text: `Loaded voucher ${view.voucherNo}` });
  };

  async function loadVoucher() {
    const number = voucherNo.trim();
    if (!number) {
      setStatus({ kind: 'err', text: 'Please Insert VchNo and try' });
      return;
    }
    setBusy(true);
    try {
      hydrate(
        await get<ApprovalView>(
          `${route}/${encodeURIComponent(number)}?coBook=${encodeURIComponent(coBook)}`,
        ),
      );
    } catch (error) {
      setStatus({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  async function loadIssueLines() {
    if (!origBook || !origVchNo.trim()) {
      setStatus({ kind: 'err', text: 'Please select the original Approval Isu book and voucher' });
      return;
    }
    setBusy(true);
    try {
      const source = await get<Array<Record<string, unknown>>>(
        `/tour/${encodeURIComponent(origVchNo.trim())}/lines?coBook=${encodeURIComponent(origBook)}`,
      );
      const open = source.filter((line) => line.open !== false);
      const loaded = open.map((line, index) =>
        approvalLineFromApi({ ...line, origSrNo: line.srNo, oldSrNo: index + 1 }),
      );
      setLines(loaded.length ? loaded : [blankApprovalLine()]);
      sub.load(loaded.map(() => [{}]));
      setOrigYear(coYear);
      setStatus({
        kind: 'ok',
        text: `Loaded ${loaded.length} open line(s) from issue ${origVchNo.trim()}`,
      });
    } catch (error) {
      setStatus({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const payload = () => ({
    coBook,
    vchDate,
    partyAc,
    empCode,
    vchDesc,
    ...(loadedNo ? { expectedVersion: version } : {}),
    ...(returning ? { origBook, origYear: origYear || coYear, origVchNo: origVchNo.trim() } : {}),
    lines: lines
      .map((line, index) => ({ line, index }))
      .filter(({ line }) => line.itCode.trim())
      .map(({ line, index }) => approvalLineInput(line, sub.inputsFor(index))),
  });

  async function save(event?: React.FormEvent) {
    event?.preventDefault();
    setBusy(true);
    setStatus(null);
    try {
      const result = loadedNo
        ? await put<SaveResult>(`${route}/${encodeURIComponent(loadedNo)}`, payload())
        : await post<SaveResult>(returning ? '/tour/return' : '/tour/issue', payload());
      setVoucherNo(result.voucherNo);
      setLoadedNo(result.voucherNo);
      setVersion(result.version);
      setStatus({ kind: 'ok', text: `Saved — ${title} #${result.vchNo}` });
    } catch (error) {
      setStatus({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedNo || !version || !window.confirm('Are You Sure To Delete This Voucher now?'))
      return;
    setBusy(true);
    try {
      await del(
        `${route}/${encodeURIComponent(loadedNo)}?coBook=${encodeURIComponent(coBook)}&expectedVersion=${encodeURIComponent(version)}`,
      );
      reset();
      setStatus({ kind: 'ok', text: 'Delete Success.' });
    } catch (error) {
      setStatus({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const print = () => {
    if (!loadedNo) return;
    window.open(
      `/api${route}/${encodeURIComponent(loadedNo)}/print?coBook=${encodeURIComponent(coBook)}&format=html`,
      '_blank',
      'noopener,noreferrer',
    );
  };
  const totalPcs = round(
    lines.reduce((sum, line) => sum + Number(line.pcs || 0), 0),
    3,
  );
  const totalFine = round(
    lines.reduce((sum, line) => sum + approvalFine(line), 0),
    3,
  );
  const totalNet = round(
    lines.reduce((sum, line) => sum + Number(line.netWt || 0), 0),
    3,
  );
  const dayName = vchDate
    ? new Date(`${vchDate}T00:00:00`).toLocaleDateString('en-US', { weekday: 'long' })
    : '';

  return (
    <div>
      <h1>{title}</h1>
      {status && (
        <div role={status.kind === 'err' ? 'alert' : 'status'} className={`msg ${status.kind}`}>
          {status.text}
        </div>
      )}
      <form onSubmit={save}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>
                Vch No
                <input
                  aria-label="Vch No"
                  value={voucherNo}
                  onChange={(e) => setVoucherNo(e.target.value)}
                  onKeyDown={(e) => {
                    if (e.key === 'Enter') {
                      e.preventDefault();
                      void loadVoucher();
                    }
                  }}
                  readOnly={!!loadedNo}
                />
              </label>
            </div>
            <button
              type="button"
              className="ghost"
              onClick={() => void loadVoucher()}
              disabled={busy || !coBook}
            >
              Load
            </button>
            <div className="field">
              <label>
                Book
                <BookSelect
                  value={coBook}
                  onChange={setCoBook}
                  preferred={preferredBook}
                  mainBooks={[mainBook]}
                  disabled={!!loadedNo}
                />
              </label>
            </div>
            <div className="field">
              <label>
                Vch Date
                <input
                  aria-label="Vch Date"
                  type="date"
                  value={vchDate}
                  onChange={(e) => setVchDate(e.target.value)}
                />
              </label>
            </div>
            <div className="field">
              <label>
                Hidden Vch No
                <input aria-label="Hidden Vch No" value={loadedNo} readOnly />
              </label>
            </div>
            <div className="field">
              <label>
                Time
                <input aria-label="Vch Time" value={vchTime} readOnly />
              </label>
            </div>
            <div className="field">
              <label>
                Day
                <input aria-label="Vch Day" value={dayName} readOnly />
              </label>
            </div>
            <div className="field">
              <label>
                Year
                <input value={coYear} readOnly />
              </label>
            </div>
            <div className="field">
              <label>
                Location
                <input value={lcCode} readOnly />
              </label>
            </div>
          </div>
          {returning && (
            <div className="row">
              <div className="field">
                <label>
                  Original Issue Book
                  <BookSelect
                    value={origBook}
                    onChange={setOrigBook}
                    preferred="TUR"
                    mainBooks={['APR ISU']}
                    disabled={!!loadedNo}
                  />
                </label>
              </div>
              <div className="field">
                <label>
                  Original Issue Year
                  <input aria-label="Original Issue Year" value={origYear} readOnly />
                </label>
              </div>
              <div className="field">
                <label>
                  Original Issue Vch No
                  <input
                    aria-label="Original Issue Vch No"
                    value={origVchNo}
                    onChange={(e) => setOrigVchNo(e.target.value)}
                    readOnly={!!loadedNo}
                  />
                </label>
              </div>
              <button
                type="button"
                data-testid="approval-return-load-lines"
                className="ghost"
                onClick={() => void loadIssueLines()}
                disabled={busy || !!loadedNo}
              >
                Load lines
              </button>
            </div>
          )}
          <div className="row">
            <div className="field">
              <label>
                Party Code
                <LookupPicker
                  entity="accounts"
                  value={partyAc}
                  onChange={setPartyAc}
                  onPick={(row) => setPartyName(String(row.name || ''))}
                  ariaLabel="Party Code"
                  resolveTypedCode
                />
              </label>
            </div>
            <div className="field">
              <label>
                Party Name
                <input value={partyName} readOnly />
              </label>
            </div>
            <div className="field">
              <label>
                Employee Code
                <LookupPicker
                  entity="employees"
                  value={empCode}
                  onChange={setEmpCode}
                  onPick={(row) => setEmpName(String(row.name || ''))}
                  ariaLabel="Employee Code"
                  resolveTypedCode
                />
              </label>
            </div>
            <div className="field">
              <label>
                Employee Name
                <input value={empName} readOnly />
              </label>
            </div>
            <div className="field" style={{ flex: 1 }}>
              <label>
                Vch Desc
                <input
                  aria-label="Vch Desc"
                  value={vchDesc}
                  onChange={(e) => setVchDesc(e.target.value)}
                />
              </label>
            </div>
          </div>
        </div>
        <ApprovalGrid
          kind={kind}
          lines={lines}
          setLines={setLines}
          full={fullGrid}
          setFull={setFullGrid}
          extended={extendedFields}
          sub={sub}
          disabled={busy}
        />
        <div className="toolbar">
          <label>
            Total Pcs
            <input aria-label="Total Pcs" value={totalPcs} readOnly style={{ width: 70 }} />
          </label>
          <span>
            Net {totalNet.toLocaleString('en-IN')} g ·{' '}
            <b>Fine {totalFine.toLocaleString('en-IN')} g</b>
          </span>
          <span className="spacer" />
          <button
            type="button"
            data-testid={`approval-${kind}-new`}
            className="ghost"
            onClick={reset}
          >
            New
          </button>
          <button
            type="button"
            data-testid={`approval-${kind}-print`}
            className="ghost"
            onClick={print}
            disabled={!loadedNo}
          >
            Print
          </button>
          <button
            type="button"
            data-testid={`approval-${kind}-delete`}
            className="danger"
            onClick={() => void remove()}
            disabled={!loadedNo || busy}
          >
            Delete
          </button>
          <button
            data-testid={`approval-${kind}-save`}
            data-save-mnemonic
            className="primary"
            disabled={busy || !coBook || !lines.some((line) => line.itCode.trim())}
          >
            {busy ? 'Saving…' : loadedNo ? `Update #${loadedNo}` : 'Save'}
          </button>
        </div>
      </form>
    </div>
  );
}
