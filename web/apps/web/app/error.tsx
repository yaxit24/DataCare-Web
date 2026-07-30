'use client';
import { useEffect } from 'react';

// Segment error boundary (App Router). Renders when a route/segment throws on the client; `reset`
// re-renders the segment. Styled to match the app shell (msg/err classes in globals).
export default function Error({
  error,
  reset,
}: {
  error: Error & { digest?: string };
  reset: () => void;
}) {
  useEffect(() => {
    console.error(error);
  }, [error]);
  return (
    <div style={{ padding: 24 }}>
      <div className="msg err" role="alert">
        Something went wrong: {error?.message || 'unexpected error'}
        {error?.digest ? ` (ref ${error.digest})` : ''}
      </div>
      <div className="toolbar" style={{ marginTop: 12 }}>
        <button className="primary" onClick={() => reset()}>
          Retry
        </button>
        <a className="ghost" href="/" style={{ marginLeft: 8 }}>
          Go home
        </a>
      </div>
    </div>
  );
}
