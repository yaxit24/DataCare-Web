'use client';
import { useEffect, useRef, useState } from 'react';
import { usePathname } from 'next/navigation';
import { getDownload } from '../../../lib/api';

const DESTINATION = 'Browser Save dialog';

export default function BackupPage() {
  const pathname = usePathname();
  const [destinationSelected, setDestinationSelected] = useState(false);
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const busyRef = useRef(false);
  const selectButton = useRef<HTMLButtonElement>(null);

  useEffect(() => {
    setDestinationSelected(false);
    setMessage(null);
  }, [pathname]);

  function selectDestination() {
    if (busyRef.current) return;
    setDestinationSelected(true);
    setMessage(null);
  }

  function cancel() {
    if (busyRef.current) return;
    setDestinationSelected(false);
    setMessage(null);
    selectButton.current?.focus();
  }

  async function backup() {
    if (busyRef.current) return;
    setMessage(null);
    if (!destinationSelected) {
      setMessage({ kind: 'err', text: 'Please Select Path and Try' });
      selectButton.current?.focus();
      return;
    }

    busyRef.current = true;
    setBusy(true);
    try {
      const { blob, filename } = await getDownload('/backup');
      const url = URL.createObjectURL(blob);
      const a = document.createElement('a');
      try {
        a.href = url;
        a.download = filename;
        document.body.appendChild(a);
        a.click();
      } finally {
        a.remove();
        setTimeout(() => URL.revokeObjectURL(url), 1000);
      }
      setMessage({ kind: 'ok', text: 'Backup Process Complete.' });
    } catch (error) {
      setMessage({
        kind: 'err',
        text: error instanceof Error ? error.message : 'Could not download the company backup.',
      });
    } finally {
      busyRef.current = false;
      setBusy(false);
    }
  }

  return (
    <div onKeyDown={(event) => event.key === 'Escape' && cancel()}>
      <h1>Backup Data</h1>
      <div className="panel" aria-busy={busy}>
        <p>The browser Save dialog chooses the download location. No path is sent or stored.</p>
        <div className="field">
          <label htmlFor="backup-destination">Backup Path</label>
          <input
            id="backup-destination"
            value={destinationSelected ? DESTINATION : ''}
            placeholder="Select a download destination"
            readOnly
            tabIndex={-1}
          />
        </div>
        <button
          ref={selectButton}
          type="button"
          className="ghost"
          onClick={selectDestination}
          disabled={busy}
          autoFocus
        >
          Select
        </button>
        {busy && (
          <progress
            role="progressbar"
            aria-label="Backup progress"
            aria-valuetext="Preparing backup"
          />
        )}
        <div className="row" style={{ marginTop: 12 }}>
          <button type="button" className="primary" onClick={backup} disabled={busy}>
            Backup
          </button>
          <button type="button" className="ghost" onClick={cancel} disabled={busy}>
            Cancel
          </button>
        </div>
        {message && (
          <p className={`msg ${message.kind}`} role={message.kind === 'err' ? 'alert' : 'status'}>
            {message.text}
          </p>
        )}
      </div>
    </div>
  );
}
