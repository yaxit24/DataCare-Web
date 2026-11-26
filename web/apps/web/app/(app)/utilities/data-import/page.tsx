'use client';

import { useRouter } from 'next/navigation';
import { useRef, useState } from 'react';
import { ApiError, post, postCommand } from '../../../../lib/api';
import { useIdempotencyKey } from '../../../../lib/idempotencyKey';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';

/**
 * Other → Data Import: desktop UT_IMPORT, "Old Softwar Import" (UT_IMPORT.cs:3187), the Lite Soft button only
 * (BtnLite_Click :8413-8445; owner decision D-IMP-1). The desktop asks its question, opens the .mdb and runs five steps
 * behind a progress bar. The web (D-IMP-2) reads the chosen file first and shows what each step will write, the rows
 * it cannot import and why, and refuses a company that already has data; only then does it ask the desktop question
 * and import, all in one transaction. After "Process Are Complete...." the desktop exits (:8444); the web signs out.
 */

interface Issue {
  step: string;
  table: string;
  row?: number;
  key?: string;
  reason: string;
}
interface Step {
  step: string;
  title: string;
  desktopSource: string;
  writes: Record<string, number>;
  replaces: Record<string, number>;
}
interface Preview {
  fileName: string;
  format: string;
  sourceTables: Record<string, number>;
  ignoredTables: string[];
  steps: Step[];
  errors: Issue[];
  warnings: Issue[];
  refusal: string | null;
  companyData: Record<string, number>;
  newOpeningDate: string;
  question: string;
  previewHash: string;
  skipped: { acCode: string; name: string; amount: number; gold: number; silver: number }[];
  skippedTotal: number;
}
interface Applied extends Preview {
  message: string;
}

const LITE_TITLE = 'Lite Software Import'; // lblBook.Text, UT_IMPORT.cs:8420
const COMPLETE = 'Process Are Complete....'; // UT_IMPORT.cs:8443
const errText = (e: unknown, fallback: string): string =>
  e instanceof ApiError ? e.body?.message || e.body?.error || e.message : fallback;
const tableList = (counts: Record<string, number>) =>
  Object.entries(counts)
    .map(([t, n]) => `${t} ${n}`)
    .join(', ');

/** The file as base64, read in the browser (the API never sees a path). */
async function base64Of(file: File): Promise<string> {
  const bytes = new Uint8Array(await file.arrayBuffer());
  let binary = '';
  for (let i = 0; i < bytes.length; i += 0x8000)
    binary += String.fromCharCode(...bytes.subarray(i, i + 0x8000));
  return btoa(binary);
}

function IssueTable({ caption, rows }: { caption: string; rows: Issue[] }) {
  return (
    <table className="grid" aria-label={caption}>
      <thead>
        <tr>
          <th>Step</th>
          <th>Table</th>
          <th className="num">Row</th>
          <th>Code</th>
          <th>Reason</th>
        </tr>
      </thead>
      <tbody>
        {rows.map((r, i) => (
          <tr key={`${r.table}-${r.row ?? ''}-${r.key ?? ''}-${i}`}>
            <td>{r.step}</td>
            <td>{r.table}</td>
            <td className="num">{r.row ?? ''}</td>
            <td>{r.key ?? ''}</td>
            <td>{r.reason}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default function DataImportPage() {
  const input = useRef<HTMLInputElement>(null);
  const [file, setFile] = useState<{ name: string; data: string } | null>(null);
  const [preview, setPreview] = useState<Preview | null>(null);
  const [busy, setBusy] = useState<'read' | 'import' | null>(null);
  const [acknowledged, setAcknowledged] = useState(false);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [processLabel, setProcessLabel] = useState('Data Import');
  // One key per chosen file: a retried Import of the same file answers the first result (D18).
  const command = useIdempotencyKey();
  const router = useRouter();

  /** UT_IMPORT_KeyDown (UT_IMPORT.cs:3422-3430): Esc closes the form, except while a file is read or imported. */
  function onScreenKeyDown(event: ScreenKeyEvent) {
    if (event.defaultPrevented || event.key !== 'Escape' || busy !== null) return;
    event.preventDefault();
    router.push('/dashboard');
  }
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);

  async function choose(chosen: File | undefined) {
    if (!chosen) return;
    setBusy('read');
    setMsg(null);
    setPreview(null);
    try {
      const data = await base64Of(chosen);
      const next = await post<Preview>('/utilities/data-import/lite/preview', {
        fileName: chosen.name,
        data,
      });
      setFile({ name: chosen.name, data });
      setPreview(next);
      setAcknowledged(false);
      command.renew();
    } catch (e) {
      setFile(null);
      setMsg({ kind: 'err', text: errText(e, 'The file could not be read.') });
    } finally {
      setBusy(null);
      if (input.current) input.current.value = '';
    }
  }

  function liteSoft() {
    setProcessLabel(LITE_TITLE);
    input.current?.click();
  }

  async function runImport() {
    if (!preview || !file) return;
    if (!window.confirm(preview.question)) return;
    setBusy('import');
    setMsg(null);
    try {
      const done = await postCommand<Applied>(
        '/utilities/data-import/lite/apply',
        {
          fileName: file.name,
          data: file.data,
          previewHash: preview.previewHash,
          acknowledgeSkipped: acknowledged,
        },
        command.key,
      );
      setPreview(done);
      window.alert(done.message || COMPLETE);
      // Application.Exit (UT_IMPORT.cs:8444): the session ends and the operator signs in again.
      await post('/auth/logout').catch(() => {});
      window.location.assign('/login');
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'The import failed; nothing was imported.') });
      setBusy(null);
    }
  }

  const canImport =
    !!preview &&
    !preview.refusal &&
    preview.errors.length === 0 &&
    (preview.skippedTotal === 0 || acknowledged) &&
    busy === null;

  return (
    <div ref={screenRef} onKeyDown={onScreenKeyDown}>
      <h1>Old Software Import</h1>
      <div className="panel">
        <div className="toolbar">
          <span className="muted" aria-label="Process">
            {processLabel}
          </span>
        </div>
        <div className="toolbar">
          <button className="primary" onClick={liteSoft} disabled={busy !== null} autoFocus>
            Lite Soft
          </button>
          <input
            ref={input}
            type="file"
            accept=".mdb"
            aria-label="Old software file"
            style={{ display: 'none' }}
            onChange={(e) => void choose(e.target.files?.[0])}
          />
          {busy === 'read' && <span className="muted">Reading the file…</span>}
          {busy === 'import' && <progress aria-label="Import progress" style={{ width: 240 }} />}
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Imports the old Lite software&apos;s accounts, items, party openings, tags and item
          openings into this company. It is meant for a new company: a company that already has
          vouchers, openings or tags is refused.
        </p>
      </div>

      {msg && (
        <div className={`msg ${msg.kind}`} role="alert">
          {msg.text}
        </div>
      )}

      {preview && (
        <>
          <div className="panel" style={{ overflow: 'auto' }}>
            <strong>File {preview.fileName}</strong>
            <p className="muted" style={{ margin: '4px 0' }}>
              Tables read: {tableList(preview.sourceTables) || 'none'}
              {preview.ignoredTables.length > 0 && (
                <> · ignored: {preview.ignoredTables.join(', ')}</>
              )}
            </p>
            <table className="grid" aria-label="Import steps">
              <thead>
                <tr>
                  <th>Step</th>
                  <th>Writes</th>
                  <th>Replaces</th>
                  <th>Desktop</th>
                </tr>
              </thead>
              <tbody>
                {preview.steps.map((s) => (
                  <tr key={s.step} data-step={s.step}>
                    <td>{s.title}</td>
                    <td>{tableList(s.writes)}</td>
                    <td>{tableList(s.replaces)}</td>
                    <td className="muted">{s.desktopSource}</td>
                  </tr>
                ))}
              </tbody>
            </table>
            <p className="muted" style={{ margin: '4px 0 0' }}>
              The year&apos;s opening date becomes{' '}
              {preview.newOpeningDate.split('-').reverse().join('/')}.
            </p>
          </div>

          {preview.refusal && (
            <div className="msg err" role="alert" aria-label="Refusal">
              {preview.refusal} ({tableList(preview.companyData)})
            </div>
          )}

          {preview.errors.length > 0 && (
            <div className="panel" style={{ overflow: 'auto' }}>
              <strong>Rows that cannot be imported</strong>
              <IssueTable caption="Import errors" rows={preview.errors} />
            </div>
          )}

          {preview.warnings.length > 0 && (
            <div className="panel" style={{ overflow: 'auto' }}>
              <strong>Not imported</strong>
              <IssueTable caption="Import warnings" rows={preview.warnings} />
            </div>
          )}

          {preview.skippedTotal > 0 && (
            <div className="panel" style={{ overflow: 'auto' }}>
              <strong>Opening balances with no web account</strong>
              <table className="grid" aria-label="Skipped balances">
                <thead>
                  <tr>
                    <th>Account</th>
                    <th>Name</th>
                    <th className="num">Amount</th>
                    <th className="num">Gold</th>
                    <th className="num">Silver</th>
                  </tr>
                </thead>
                <tbody>
                  {preview.skipped.map((x) => (
                    <tr key={x.acCode}>
                      <td>{x.acCode}</td>
                      <td>{x.name}</td>
                      <td className="num">{x.amount.toFixed(2)}</td>
                      <td className="num">{x.gold.toFixed(3)}</td>
                      <td className="num">{x.silver.toFixed(3)}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <label>
                <input
                  type="checkbox"
                  checked={acknowledged}
                  onChange={(e) => setAcknowledged(e.target.checked)}
                />{' '}
                Import without these balances (total {preview.skippedTotal})
              </label>
            </div>
          )}

          <div className="toolbar">
            <button className="danger" onClick={() => void runImport()} disabled={!canImport}>
              {busy === 'import' ? 'Importing…' : 'Import'}
            </button>
          </div>
        </>
      )}
    </div>
  );
}
