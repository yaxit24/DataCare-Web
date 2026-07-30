'use client';
import { useState } from 'react';

export default function BackupPage() {
  const [busy, setBusy] = useState(false);
  async function download() {
    setBusy(true);
    try {
      const res = await fetch('/api/backup', { credentials: 'include' });
      const blob = await res.blob();
      const url = URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `backup-${new Date().toISOString().slice(0, 10)}.json`;
      document.body.appendChild(a);
      a.click();
      a.remove();
      setTimeout(() => URL.revokeObjectURL(url), 1000);
    } finally {
      setBusy(false);
    }
  }
  return (
    <div>
      <h1>Backup</h1>
      <div className="panel">
        <p>
          Download a logical backup of this company&apos;s masters + transactions (accounts, items,
          sales, purchases, ledger, loyalty, manufacturing) as a JSON file.
        </p>
        <p className="muted">
          For full physical database backups, the server cron uses <code>deploy/backup.sh</code>{' '}
          (pg_dump).
        </p>
        <button className="primary" onClick={download} disabled={busy}>
          {busy ? 'Preparing…' : 'Download Company Backup (JSON)'}
        </button>
      </div>
    </div>
  );
}
