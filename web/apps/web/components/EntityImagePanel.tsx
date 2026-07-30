'use client';

import { useCallback, useEffect, useRef, useState } from 'react';
import { ApiError, del, get, post } from '../lib/api';
import { useCameraCapture } from './CameraCapture';

/**
 * Tag photograph panel — the desktop's `BtnImgS` (select), `BtnImgC` (capture) and `BtnImgD` (delete)
 * controls, plus click-to-enlarge.
 *
 * 24 desktop forms carry these buttons. Rather than repeat the plumbing per form, every surface that shows a
 * tag mounts this one component keyed on the tag instance `(TAG_NO, VCH_SRNO)` — the same identity the
 * desktop uses, and the identity `TAG_IMAGE_DATA` is keyed on.
 *
 * The image is fetched as a blob URL rather than a base64 payload so a large photo does not sit in React
 * state, and the URL is revoked on change to avoid leaking object URLs as the operator moves between rows.
 */
export type ImageEntityType = 'TAG' | 'AC' | 'MEMB' | 'SCHM' | 'DESIGN' | 'ITEM';

export function EntityImagePanel({
  entityType = 'TAG',
  entityKey,
  instance = 0,
  imageType,
  label = 'Image',
  disabled,
  testId = 'entity-image',
}: {
  /** Which kind of record owns the photograph: a tag, a party, a member, a scheme, a design. */
  entityType?: ImageEntityType;
  /** Tag number, account code, member code, scheme code or design number. */
  entityKey: string;
  /** Voucher instance for a tag; 0 for master records. */
  instance?: number;
  /** Single-character desktop code: 'T' tag (default), 'D' design. */
  imageType?: string;
  label?: string;
  disabled?: boolean;
  testId?: string;
}) {
  const [url, setUrl] = useState<string | null>(null);
  const [meta, setMeta] = useState<{ size: number; type: string } | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const [zoom, setZoom] = useState(false);
  const fileRef = useRef<HTMLInputElement | null>(null);
  const urlRef = useRef<string | null>(null);
  const camera = useCameraCapture({ fileName: `${entityKey || 'image'}.jpg` });

  const query = useCallback(() => {
    const q = new URLSearchParams({
      entityType,
      entityKey,
      instance: String(instance),
    });
    if (imageType) q.set('imageType', imageType);
    return q.toString();
  }, [entityType, entityKey, instance, imageType]);

  const release = useCallback(() => {
    if (urlRef.current) {
      URL.revokeObjectURL(urlRef.current);
      urlRef.current = null;
    }
  }, []);

  const load = useCallback(async () => {
    release();
    setUrl(null);
    setMeta(null);
    if (!entityKey) return;
    try {
      // The image route returns raw bytes, so it is fetched directly rather than through the JSON helper.
      const res = await fetch(`/api/stock/tag-image?${query()}`, { credentials: 'include' });
      if (res.status === 404) return; // no image for this tag is the normal case
      if (!res.ok) {
        setError('Could not load the image');
        return;
      }
      const blob = await res.blob();
      // A 200 with an empty or non-image body is NOT an image. Trusting the status alone would render a
      // broken thumbnail and enable Delete for something that does not exist.
      if (blob.size === 0 || !blob.type.startsWith('image/')) return;
      const objectUrl = URL.createObjectURL(blob);
      urlRef.current = objectUrl;
      setUrl(objectUrl);
      setMeta({ size: blob.size, type: blob.type });
    } catch {
      setError('Could not load the image');
    }
  }, [entityKey, query, release]);

  useEffect(() => {
    void load();
    return release;
  }, [load, release]);

  const upload = useCallback(
    async (file: File) => {
      setBusy(true);
      setError('');
      try {
        const buf = await file.arrayBuffer();
        // btoa needs a binary string; chunked to avoid blowing the argument limit on a large photo.
        let binary = '';
        const bytes = new Uint8Array(buf);
        for (let i = 0; i < bytes.length; i += 8192) {
          binary += String.fromCharCode(...bytes.subarray(i, i + 8192));
        }
        await post('/stock/tag-image', {
          entityType,
          entityKey,
          instance,
          imageType,
          data: btoa(binary),
          // The server verifies magic bytes and REFUSES a declared type that disagrees, so the browser's
          // guess is sent only as a cross-check, never as the authority.
          mimeType: file.type || undefined,
        });
        await load();
      } catch (e) {
        setError(
          e instanceof ApiError
            ? e.body?.message || e.body?.error || 'Upload failed'
            : 'Upload failed',
        );
      } finally {
        setBusy(false);
      }
    },
    [entityKey, entityType, imageType, instance, load],
  );

  const remove = useCallback(async () => {
    setBusy(true);
    setError('');
    try {
      await del(`/stock/tag-image?${query()}`);
      await load();
    } catch (e) {
      setError(e instanceof ApiError ? e.body?.message || 'Delete failed' : 'Delete failed');
    } finally {
      setBusy(false);
    }
  }, [load, query]);

  const inert = disabled || !entityKey || busy;
  // The hook reports 'unsupported' when the browser has no camera API; there is no separate boolean.
  const cameraUsable = camera.status !== 'unsupported';

  return (
    <div className="panel" data-testid={testId}>
      <div className="toolbar" style={{ marginBottom: 8 }}>
        <b>{label}</b>
        <span className="muted" data-testid={`${testId}-tag`}>
          {entityKey
            ? entityType === 'TAG'
              ? `${entityKey} / ${instance}`
              : entityKey
            : 'no record selected'}
        </span>
        <span className="spacer" />
        <input
          ref={fileRef}
          type="file"
          accept="image/jpeg,image/png"
          style={{ display: 'none' }}
          onChange={(e) => {
            const f = e.target.files?.[0];
            if (f) void upload(f);
            e.target.value = '';
          }}
        />
        <button
          type="button"
          className="ghost"
          disabled={inert}
          data-testid={`${testId}-select`}
          onClick={() => fileRef.current?.click()}
        >
          Select
        </button>
        <button
          type="button"
          className="ghost"
          disabled={inert || !cameraUsable}
          data-testid={`${testId}-capture`}
          onClick={async () => {
            const f = await camera.capture();
            if (f) void upload(f);
          }}
        >
          Camera
        </button>
        <button
          type="button"
          className="ghost"
          disabled={inert || !url}
          data-testid={`${testId}-delete`}
          onClick={remove}
        >
          Delete
        </button>
      </div>

      {/* Honest device status: without a granted camera this must never claim to be live. */}
      <div className="muted" data-testid={`${testId}-camera-status`}>
        camera: {camera.status}
        {camera.message ? ` — ${camera.message}` : ''}
      </div>

      {error && (
        <div className="msg err" data-testid={`${testId}-error`}>
          {error}
        </div>
      )}

      {url ? (
        <>
          <button
            type="button"
            className="ghost"
            style={{ padding: 0, border: 0, background: 'none' }}
            onClick={() => setZoom((z) => !z)}
            aria-label={zoom ? `Shrink ${label}` : `Enlarge ${label}`}
            data-testid={`${testId}-zoom`}
          >
            <img
              src={url}
              alt={`${label} ${entityKey}`}
              style={{
                maxWidth: zoom ? '100%' : 180,
                maxHeight: zoom ? 600 : 180,
                objectFit: 'contain',
                border: '1px solid var(--line, #ccc)',
              }}
            />
          </button>
          {meta && (
            <div className="muted">
              {meta.type} · {Math.ceil(meta.size / 1024)} KB
            </div>
          )}
        </>
      ) : (
        <div className="muted" data-testid={`${testId}-empty`}>
          {entityKey ? 'No image for this record' : ''}
        </div>
      )}
    </div>
  );
}
