'use client';

import { useEffect, useRef, useState } from 'react';
import { ApiError, del, get, post } from '../lib/api';
import { useCameraCapture } from './CameraCapture';
import type { BusinessScope } from './BusinessScope';

export type OrderImageFamily = 'sales-orders' | 'tour-orders';
interface ImagePayload {
  version: string;
  editable: boolean;
  canUpdate: boolean;
  canDelete: boolean;
  reason: string | null;
  source: string | null;
  image:
    | { state: 'absent' }
    | { state: 'unavailable'; code: 'unavailable-image' | 'invalid-image'; message: string }
    | {
        state: 'present';
        mimeType: 'image/jpeg' | 'image/png';
        data: string;
        source: string;
      };
}
const errorText = (error: unknown) =>
  error instanceof ApiError
    ? error.body?.message || error.body?.error || error.message
    : error instanceof Error
      ? error.message
      : 'The order image could not be loaded.';

/** A saved parent serial selects the image; filenames, design IDs and tag keys never come from the browser. */
export function OrderImagePanel({
  family,
  scope,
  coBook,
  voucherNo,
  srNo,
  disabled,
  revision = '',
  testId = 'order-image',
}: {
  family: OrderImageFamily;
  scope: BusinessScope;
  coBook: string;
  voucherNo: string;
  srNo?: string | number;
  disabled?: boolean;
  revision?: string;
  testId?: string;
}) {
  const ready = Boolean(
    scope.coCode &&
    scope.lcCode &&
    scope.coYear &&
    coBook &&
    voucherNo &&
    Number.isSafeInteger(Number(srNo)) &&
    Number(srNo) > 0 &&
    !disabled,
  );
  const query = new URLSearchParams({ ...scope, coBook, srNo: String(srNo ?? '') }).toString();
  const path = `/${family}/${encodeURIComponent(voucherNo)}/image?${query}`;
  const identity = ready ? `${path}#${revision}` : '';
  const current = useRef(identity);
  current.current = identity;
  const generation = useRef(0);
  const [attempt, retry] = useState(0);
  const [loaded, setLoaded] = useState<{ identity: string; payload: ImagePayload } | null>(null);
  const [problem, setProblem] = useState<{ identity: string; text: string } | null>(null);
  const [busyIdentity, setBusyIdentity] = useState('');
  const [zoom, setZoom] = useState(false);
  const fileRef = useRef<HTMLInputElement>(null);
  const chooser = useRef<{ identity: string; request: number } | null>(null);
  const camera = useCameraCapture({ fileName: `${family}-${voucherNo}-${srNo}.jpg` });
  const stopCamera = camera.stop;
  const payload = loaded?.identity === identity ? loaded.payload : null;
  const error = problem?.identity === identity ? problem.text : '';
  const busy = busyIdentity === identity && Boolean(identity);
  const editable = ready && payload?.editable && payload.canUpdate && !busy;
  const removable = ready && payload?.editable && payload.canDelete && !busy;
  const shown = payload?.image.state === 'present' ? payload.image : null;

  useEffect(() => {
    const request = ++generation.current;
    setLoaded(null);
    setProblem(null);
    setZoom(false);
    stopCamera();
    if (identity) {
      setBusyIdentity(identity);
      void get<ImagePayload>(path)
        .then((found) => {
          if (current.current === identity && request === generation.current)
            setLoaded({ identity, payload: found });
        })
        .catch((caught) => {
          if (current.current === identity && request === generation.current)
            setProblem({ identity, text: errorText(caught) });
        })
        .finally(() => {
          if (current.current === identity && request === generation.current) setBusyIdentity('');
        });
    }
    return () => {
      generation.current += 1;
      stopCamera();
    };
  }, [identity, path, attempt, stopCamera]);

  async function upload(
    file: File,
    selectedIdentity = identity,
    selectedRequest = generation.current,
  ) {
    // The chooser or camera may finish after the user has moved to another saved row.
    if (
      !editable ||
      !payload ||
      current.current !== selectedIdentity ||
      selectedRequest !== generation.current
    )
      return;
    const version = payload.version;
    setBusyIdentity(selectedIdentity);
    setProblem(null);
    try {
      if (
        !['image/jpeg', 'image/png'].includes(file.type) ||
        !file.size ||
        file.size > 4 * 1024 * 1024
      )
        throw new Error('Select a JPEG or PNG image up to 4 MB.');
      const bytes = new Uint8Array(await file.arrayBuffer());
      if (current.current !== selectedIdentity || selectedRequest !== generation.current) return;
      let binary = '';
      for (let index = 0; index < bytes.length; index += 8192)
        binary += String.fromCharCode(...bytes.subarray(index, index + 8192));
      await post(path, { version, mimeType: file.type, data: btoa(binary) });
      if (current.current === selectedIdentity && selectedRequest === generation.current)
        retry((value) => value + 1);
    } catch (caught) {
      if (current.current === selectedIdentity && selectedRequest === generation.current)
        setProblem({ identity: selectedIdentity, text: errorText(caught) });
    } finally {
      if (current.current === selectedIdentity && selectedRequest === generation.current)
        setBusyIdentity('');
      if (fileRef.current) fileRef.current.value = '';
    }
  }

  async function remove() {
    if (!removable || !payload || payload.image.state === 'absent') return;
    const selectedIdentity = identity,
      request = generation.current;
    // Both desktop order forms confirm BtnImgD before changing the saved image.
    if (!window.confirm('Are you sure you want to delete this image?')) return;
    if (current.current !== selectedIdentity || request !== generation.current) return;
    setBusyIdentity(identity);
    setProblem(null);
    try {
      await del(`${path}&version=${encodeURIComponent(payload.version)}`);
      if (current.current === selectedIdentity && request === generation.current)
        retry((value) => value + 1);
    } catch (caught) {
      if (current.current === selectedIdentity && request === generation.current)
        setProblem({ identity: selectedIdentity, text: errorText(caught) });
    } finally {
      if (current.current === selectedIdentity && request === generation.current)
        setBusyIdentity('');
    }
  }

  return (
    <div className="panel" data-testid={testId}>
      <h2>Order image</h2>
      {!ready ? (
        <p className="muted">
          Open a saved order and select an item row to view or change its image.
        </p>
      ) : (
        <>
          <p className="muted" data-testid={`${testId}-identity`}>
            Saved order {coBook} / {voucherNo}, item {srNo}. Save item changes before changing its
            image.
          </p>
          {busy && <p role="status">Loading or saving image…</p>}
          {error && (
            <p className="msg err" role="alert" data-testid={`${testId}-error`}>
              {error}
            </p>
          )}
          {payload?.reason && (
            <p className="muted" data-testid={`${testId}-reason`}>
              {payload.reason}
            </p>
          )}
          {payload?.image.state === 'unavailable' && (
            <p className="msg err" role="alert" data-testid={`${testId}-unavailable`}>
              {payload.image.message}{' '}
              {editable ? 'Select or capture a valid image to replace it.' : ''}
            </p>
          )}
          {shown ? (
            <button
              type="button"
              className="ghost"
              onClick={() => setZoom((value) => !value)}
              aria-label={zoom ? 'Shrink order image' : 'Enlarge order image'}
            >
              <img
                data-testid={`${testId}-preview`}
                src={`data:${shown.mimeType};base64,${shown.data}`}
                alt={`Order ${voucherNo}, item ${srNo}`}
                style={{
                  maxWidth: zoom ? '100%' : 220,
                  maxHeight: zoom ? 600 : 220,
                  objectFit: 'contain',
                }}
                onError={() =>
                  setProblem({
                    identity,
                    text: 'The saved image could not be displayed. Reload the image or select a valid JPEG or PNG.',
                  })
                }
              />
            </button>
          ) : payload?.image.state === 'absent' ? (
            <p className="muted" data-testid={`${testId}-empty`}>
              No image saved for this item.
            </p>
          ) : null}
          {payload?.source && (
            <p className="muted" data-testid={`${testId}-source`}>
              Image source:{' '}
              {payload.source === 'DESIGN'
                ? 'Design Book'
                : payload.source === 'TAG'
                  ? 'Tag'
                  : 'Order item'}
            </p>
          )}
          <div className="toolbar">
            <label>
              JPEG / PNG (max 4 MB){' '}
              <input
                ref={fileRef}
                type="file"
                accept="image/jpeg,image/png"
                disabled={!editable}
                data-testid={`${testId}-file`}
                onClick={() => {
                  chooser.current = { identity, request: generation.current };
                }}
                onChange={(event) => {
                  const file = event.target.files?.[0];
                  const selected = chooser.current ?? { identity, request: generation.current };
                  chooser.current = null;
                  if (file) void upload(file, selected.identity, selected.request);
                }}
              />
            </label>
            <button
              type="button"
              className="ghost"
              data-testid={`${testId}-delete`}
              disabled={!removable || payload?.image.state === 'absent'}
              onClick={() => void remove()}
            >
              Delete image
            </button>
            <button
              type="button"
              className="ghost"
              disabled={busy}
              onClick={() => retry((value) => value + 1)}
            >
              Reload image
            </button>
          </div>
          <video
            ref={camera.videoRef}
            muted
            playsInline
            aria-label="Order image camera preview"
            data-testid={`${testId}-camera-preview`}
            style={{
              display: camera.status === 'live' ? 'block' : 'none',
              maxWidth: 260,
              background: '#000',
            }}
          />
          <p className="muted" data-testid={`${testId}-camera-status`}>
            Camera: {camera.status}
            {camera.message ? ` · ${camera.message}` : ''}
          </p>
          <div className="toolbar">
            {camera.status === 'live' ? (
              <>
                <button
                  type="button"
                  disabled={!editable}
                  data-testid={`${testId}-camera-capture`}
                  onClick={async () => {
                    const selectedIdentity = identity,
                      request = generation.current;
                    const file = await camera.capture();
                    camera.stop();
                    if (file) await upload(file, selectedIdentity, request);
                  }}
                >
                  Capture photo
                </button>
                <button type="button" className="ghost" onClick={camera.stop}>
                  Stop camera
                </button>
              </>
            ) : (
              <button
                type="button"
                className="ghost"
                disabled={
                  !editable || camera.status === 'unsupported' || camera.status === 'requesting'
                }
                data-testid={`${testId}-camera-start`}
                onClick={async () => {
                  const selectedIdentity = identity,
                    request = generation.current;
                  await camera.start();
                  if (current.current !== selectedIdentity || request !== generation.current)
                    camera.stop();
                }}
              >
                Use camera
              </button>
            )}
          </div>
        </>
      )}
    </div>
  );
}
