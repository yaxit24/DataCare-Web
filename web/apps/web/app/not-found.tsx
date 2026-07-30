import Link from 'next/link';

// App Router 404 boundary.
export default function NotFound() {
  return (
    <div style={{ padding: 24 }}>
      <h2 style={{ margin: '0 0 6px' }}>404 — Not found</h2>
      <p className="muted">That page doesn’t exist.</p>
      <Link href="/" className="ghost">
        Go home
      </Link>
    </div>
  );
}
