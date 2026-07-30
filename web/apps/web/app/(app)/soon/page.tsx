'use client';
import { Suspense } from 'react';
import { useSearchParams } from 'next/navigation';

function SoonInner() {
  const form = useSearchParams().get('f') ?? '';
  return (
    <div>
      <h1>{form || 'Module'}</h1>
      <div className="panel">
        <div className="msg">
          This screen is planned and being ported from the desktop form
          {form ? ` “${form}”` : ''}. The backend logic and parity tests are tracked in the
          execution plan; the UI for this form is queued.
        </div>
        <p className="muted">Built screens are highlighted in the sidebar without a “soon” tag.</p>
      </div>
    </div>
  );
}

export default function SoonPage() {
  return (
    <Suspense fallback={<div className="muted">Loading…</div>}>
      <SoonInner />
    </Suspense>
  );
}
