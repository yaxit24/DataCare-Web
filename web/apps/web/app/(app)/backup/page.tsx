'use client';
import { useState } from 'react';
import { getBlob } from '../../../lib/api';
import { ParityContainmentNotice } from '../../../components/ParityContainmentNotice';
import { todayLocal } from '../../../lib/localDate';

export default function BackupPage() {
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  async function download() {
    setBusy(true);
    setError('');
    try {
      const blob = await getBlob('/backup');
      const url = URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `backup-${todayLocal()}.json`;
      document.body.appendChild(a);
      a.click();
      a.remove();
      setTimeout(() => URL.revokeObjectURL(url), 1000);
    } catch (error) {
      setError(error instanceof Error ? error.message : 'Could not download the company backup.');
    } finally {
      setBusy(false);
    }
  }
  return (
    <div>
      <h1>Backup</h1>
      <ParityContainmentNotice operation="logical-restore" />
      <div className="panel">
        <p>
          Download the current logical JSON export for inspection or parity evidence. It covers an
          allowlisted subset and is not a production disaster-recovery backup.
        </p>
        <p className="muted">
          For full physical database backups, the server cron uses <code>deploy/backup.sh</code>{' '}
          (pg_dump).
        </p>
        <button className="primary" onClick={download} disabled={busy}>
          {busy ? 'Preparing…' : 'Download Company Backup (JSON)'}
        </button>
        {error && (
          <p className="msg err" role="alert">
            {error}
          </p>
        )}
      </div>
    </div>
  );
}
