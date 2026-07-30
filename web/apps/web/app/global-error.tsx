'use client';
// Root error boundary (App Router). Catches errors thrown in the root layout itself and is the
// component Next.js requires to render the global error state — its absence is what produces the
// dev-overlay "Missing required error components, refreshing…" loop. Must render <html>/<body>.
export default function GlobalError({
  error,
  reset,
}: {
  error: Error & { digest?: string };
  reset: () => void;
}) {
  return (
    <html lang="en">
      <body
        style={{
          fontFamily: 'system-ui, sans-serif',
          margin: 0,
          background: '#0f1115',
          color: '#e7e9ee',
        }}
      >
        <div style={{ maxWidth: 560, margin: '12vh auto', padding: 24 }}>
          <h2 style={{ margin: '0 0 8px' }}>Something went wrong</h2>
          <p style={{ color: '#9aa0aa', whiteSpace: 'pre-wrap' }}>
            {error?.message || 'An unexpected error occurred.'}
            {error?.digest ? ` (ref ${error.digest})` : ''}
          </p>
          <div style={{ marginTop: 16, display: 'flex', gap: 8 }}>
            <button onClick={() => reset()} style={{ padding: '8px 14px', cursor: 'pointer' }}>
              Try again
            </button>
            <a href="/" style={{ padding: '8px 14px', color: '#7aa2f7' }}>
              Go home
            </a>
          </div>
        </div>
      </body>
    </html>
  );
}
