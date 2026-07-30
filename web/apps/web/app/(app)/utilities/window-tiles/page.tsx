'use client';
import { useCallback, useEffect, useState } from 'react';
import { ApiError, get } from '../../../../lib/api';

interface Tile {
  menuName: string;
  sequence: string;
  displayName: string;
  shortName: string;
  tileName: string;
  itemShow: string;
  canView: boolean;
  canPrint: boolean;
}

const errorText = (error: unknown): string =>
  error instanceof ApiError
    ? error.body?.message || error.body?.detail || error.body?.error || error.message
    : 'Request failed';

export default function WindowTilesPage() {
  const [tiles, setTiles] = useState<Tile[]>([]);
  const [message, setMessage] = useState<{ ok: boolean; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    setBusy(true);
    try {
      const result = await get<Tile[]>('/utilities/window-tiles');
      setTiles(result);
      setMessage({ ok: true, text: 'Tile configuration loaded' });
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }, []);

  useEffect(() => {
    void load();
  }, [load]);

  async function open(tile: Tile) {
    setBusy(true);
    try {
      const selected = await get<Tile>(
        `/utilities/window-tiles/${encodeURIComponent(tile.tileName)}`,
      );
      setMessage({ ok: true, text: `${selected.displayName || selected.menuName} is available` });
    } catch (error) {
      setMessage({ ok: false, text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Window Tiles</h1>
      {message && (
        <div
          className={`msg ${message.ok ? 'ok' : 'err'}`}
          data-testid={message.ok ? 'window-tiles-saved' : undefined}
        >
          {message.text}
        </div>
      )}
      <div className="panel">
        <button type="button" onClick={() => void load()} disabled={busy}>
          {busy ? 'Loading…' : 'Refresh Tiles'}
        </button>
      </div>
      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Tile</th>
              <th>Display Name</th>
              <th>Menu</th>
              <th>Visible</th>
              <th>View Right</th>
              <th>Print Right</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {tiles.map((tile) => (
              <tr key={`${tile.tileName}/${tile.menuName}`}>
                <td>{tile.tileName}</td>
                <td>{tile.displayName}</td>
                <td>{tile.menuName}</td>
                <td>{tile.itemShow || '—'}</td>
                <td>{tile.canView ? 'Yes' : 'No'}</td>
                <td>{tile.canPrint ? 'Yes' : 'No'}</td>
                <td>
                  <button
                    type="button"
                    onClick={() => void open(tile)}
                    disabled={busy}
                    aria-label={`Open ${tile.displayName || tile.menuName}`}
                  >
                    Open
                  </button>
                </td>
              </tr>
            ))}
            {!tiles.length && (
              <tr>
                <td colSpan={7} className="muted">
                  No tile configuration is available for this tenant.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
