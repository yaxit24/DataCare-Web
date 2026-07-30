'use client';
import { useEffect, useState } from 'react';
import Link from 'next/link';
import { get } from '../../../lib/api';

interface Utility {
  title: string;
  href: string;
  desc: string;
}

// Mirrors the "Utilities" group in lib/nav.ts.
const UTILITIES: Utility[] = [
  {
    title: 'Settings',
    href: '/settings',
    desc: 'Company settings — GST, interest, cash-limit, SMS templates & printing.',
  },
  {
    title: 'Backup',
    href: '/backup',
    desc: 'Create and download database backups for safekeeping.',
  },
  {
    title: 'Audit Log',
    href: '/audit',
    desc: 'Review user activity and a trail of system changes.',
  },
  {
    title: 'Users & Rights',
    href: '/admin/users',
    desc: 'Manage user accounts, roles and access permissions.',
  },
  {
    title: 'e-Invoice (IRN)',
    href: '/utilities/e-invoice',
    desc: 'Generate and track GST e-Invoice IRNs for sales.',
  },
  {
    title: 'Integrations & Rates',
    href: '/integrations',
    desc: 'Live metal rates, WhatsApp / SMS and provider status.',
  },
  {
    title: 'Import / Export',
    href: '/masters/accounts',
    desc: 'Bulk import and export of master data.',
  },
];

export default function UtilitiesPage() {
  // Optional, non-blocking: surface a small integrations status line. Degrades gracefully.
  const [status, setStatus] = useState<Record<string, any> | null>(null);

  useEffect(() => {
    get<Record<string, any>>('/integrations/status')
      .then(setStatus)
      .catch(() => setStatus(null));
  }, []);

  const tracked = status ? Object.keys(status).length : 0;

  return (
    <div>
      <h1>Utilities</h1>
      <p className="muted">
        System tools &amp; configuration — settings, backup, audit, users, e-Invoice and
        integrations.
      </p>

      {status && tracked > 0 && (
        <div className="msg ok" style={{ display: 'inline-block' }}>
          Integrations online — {tracked} provider{tracked === 1 ? '' : 's'} tracked.
        </div>
      )}

      <div className="tiles">
        {UTILITIES.map((u) => (
          <Link
            key={u.href}
            href={u.href}
            className="tile"
            style={{ display: 'block', color: 'inherit' }}
          >
            <div className="big" style={{ fontSize: 16 }}>
              {u.title}
            </div>
            <div className="muted" style={{ margin: '6px 0 10px' }}>
              {u.desc}
            </div>
            <span style={{ color: 'var(--accent)', fontWeight: 600 }}>{u.href} →</span>
          </Link>
        ))}
      </div>
    </div>
  );
}
