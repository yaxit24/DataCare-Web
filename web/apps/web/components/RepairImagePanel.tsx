'use client';

import { useEffect, useMemo, useRef, useState } from 'react';
import { del, get, post } from '../lib/api';
import type { ImageEditLease, ImageEditorPayload } from '../lib/imageEditorSession';
import { useImageEditor, useImageScopeBarrier } from '../lib/useImageEditor';
import { useBusinessScope } from './BusinessScope';
import { useCameraCapture } from './CameraCapture';

/** Repair photos follow the original customer repair row, including its book/year and exact serial. */
export function RepairImagePanel({
  imageBook,
  imageYear,
  vchNo,
  srNo,
  disabled = false,
  testId = 'repair-image',
}: {
  imageBook: string;
  imageYear?: string;
  vchNo: string;
  srNo: number;
  disabled?: boolean;
  testId?: string;
}) {
  const scope = useBusinessScope();
  const scopeBarrier = useImageScopeBarrier(scope);
  const body = JSON.stringify({
    ...scope,
    coBook: imageBook,
    imageBook,
    imageYear: imageYear || undefined,
    vchNo,
    srNo,
  });
  const query = new URLSearchParams({
    ...scope,
    coBook: imageBook,
    imageBook,
    vchNo,
    srNo: String(srNo),
    ...(imageYear ? { imageYear } : {}),
  }).toString();
  const ready = Boolean(
    scope.coCode && scope.lcCode && scope.coYear && imageBook && vchNo && srNo > 0 && !disabled,
  );
  const identity = ready && !scopeBarrier.blocked ? `/repair-images?${query}` : '';
  const transport = useMemo(
    () => ({
      read: () => get<ImageEditorPayload>(`/repair-images/state?${query}`),
      upload: (image: { data: string; mimeType?: string }, version: string) =>
        post('/repair-images', { ...JSON.parse(body), ...image, version }),
      remove: (version: string) => del('/repair-images', { ...JSON.parse(body), version }),
    }),
    [body, query],
  );
  const { session, state } = useImageEditor(identity, transport, disabled);
  const payload = state.payload;
  const busy = state.loading || state.writing;
  const canUpdate =
    ready && !scopeBarrier.blocked && !busy && !state.needsReload && payload?.canUpdate;
  const canDelete =
    ready &&
    !scopeBarrier.blocked &&
    !busy &&
    !state.needsReload &&
    payload?.canDelete &&
    payload.image.state !== 'absent';
  const fileRef = useRef<HTMLInputElement>(null);
  const chooser = useRef<{ lease: ImageEditLease | null } | null>(null);
  const cameraLease = useRef<ImageEditLease | null>(null);
  const camera = useCameraCapture({ fileName: `${testId}-capture.jpg` });
  const stopCamera = camera.stop;
  const [imageProblem, setImageProblem] = useState<{ identity: string; version: string } | null>(
    null,
  );
  useEffect(() => {
    if (chooser.current) chooser.current.lease = null;
    cameraLease.current = null;
    stopCamera();
    return stopCamera;
  }, [identity, payload?.version, state.writing, stopCamera]);
  const failedImage =
    imageProblem?.identity === identity && imageProblem.version === payload?.version;
  const image = payload?.image.state === 'present' && !failedImage ? payload.image : null;
  const error =
    state.error || (failedImage ? 'The saved repair image could not be displayed.' : '');
  function reload() {
    cameraLease.current = null;
    stopCamera();
    setImageProblem(null);
    if (scopeBarrier.blocked) scopeBarrier.acknowledge();
    else void session.reload();
  }

  return (
    <div className="panel" data-testid={testId} style={{ minWidth: 0 }}>
      <h2>Repair Image</h2>
      {!ready && (
        <p className="muted">
          Save the voucher and select a repair row to attach its photo. Images stay attached to the
          customer repair row through every workflow stage.
        </p>
      )}
      {ready && (
        <>
          <p className="muted" data-testid={`${testId}-scope`}>
            Company {scope.coCode} · Location {scope.lcCode} · Year {scope.coYear}; repair source{' '}
            {imageBook} / {imageYear || scope.coYear} / {vchNo}, row {srNo}.
          </p>
          {scopeBarrier.blocked && (
            <p role="status" data-testid={`${testId}-scope-changed`}>
              Scope changed. Reload this record’s image before editing.
            </p>
          )}
          <div className="row" style={{ alignItems: 'flex-start' }}>
            <div>
              {image ? (
                <img
                  src={`data:${image.mimeType};base64,${image.data}`}
                  alt={`Repair image ${imageBook}/${imageYear || scope.coYear}/${vchNo}/${srNo}`}
                  style={{
                    maxWidth: 220,
                    maxHeight: 220,
                    objectFit: 'contain',
                    border: '1px solid #cbd5e1',
                  }}
                  data-testid={`${testId}-preview`}
                  onError={() => {
                    if (payload) setImageProblem({ identity, version: payload.version });
                  }}
                />
              ) : payload?.image.state === 'absent' ? (
                <div className="muted" data-testid={`${testId}-empty`}>
                  No image attached
                </div>
              ) : null}
              {payload?.image.state === 'unavailable' && (
                <p className="msg err" role="alert" data-testid={`${testId}-unavailable`}>
                  {payload.image.message || 'The stored repair image could not be decoded.'}
                </p>
              )}
            </div>
            <div>
              <div className="field">
                <label htmlFor={`${testId}-file`}>Attach JPEG / PNG (max 4 MB)</label>
                <input
                  key={identity}
                  id={`${testId}-file`}
                  data-testid={`${testId}-file`}
                  ref={fileRef}
                  type="file"
                  accept="image/jpeg,image/png"
                  disabled={!canUpdate}
                  onClick={() => {
                    chooser.current = { lease: session.lease() };
                  }}
                  onChange={(event) => {
                    const file = event.target.files?.[0];
                    const lease = chooser.current ? chooser.current.lease : session.lease();
                    chooser.current = null;
                    if (file) void session.upload(file, lease);
                    event.target.value = '';
                  }}
                />
              </div>
              <div className="field" style={{ marginTop: 8 }}>
                <video
                  ref={camera.videoRef}
                  muted
                  playsInline
                  aria-label="Camera preview"
                  data-testid={`${testId}-camera-preview`}
                  style={{
                    width: '100%',
                    maxWidth: 260,
                    background: '#000',
                    display: camera.status === 'live' ? 'block' : 'none',
                  }}
                />
                <span className="muted" data-testid={`${testId}-camera-status`}>
                  Camera: {camera.status}
                  {camera.message ? ` · ${camera.message}` : ''}
                </span>
              </div>
              <div className="toolbar" style={{ marginTop: 8, flexWrap: 'wrap' }}>
                {camera.status === 'live' ? (
                  <>
                    <button
                      type="button"
                      className="ghost"
                      disabled={!canUpdate}
                      data-testid={`${testId}-camera-capture`}
                      onClick={async () => {
                        const lease = cameraLease.current;
                        const file = await camera.capture();
                        if (!lease || cameraLease.current !== lease || !session.isCurrentContext())
                          return;
                        cameraLease.current = null;
                        stopCamera();
                        if (file) void session.upload(file, lease);
                      }}
                    >
                      Capture photo
                    </button>
                    <button type="button" className="ghost" onClick={stopCamera}>
                      Stop camera
                    </button>
                  </>
                ) : (
                  <button
                    type="button"
                    className="ghost"
                    data-testid={`${testId}-camera-start`}
                    disabled={!canUpdate || ['unsupported', 'requesting'].includes(camera.status)}
                    onClick={() => {
                      cameraLease.current = session.lease();
                      if (cameraLease.current) void camera.start();
                    }}
                  >
                    Use camera
                  </button>
                )}
                <button
                  type="button"
                  className="danger"
                  disabled={!canDelete}
                  data-testid={`${testId}-delete`}
                  onClick={() => {
                    if (window.confirm('Are you sure to delete this image now?'))
                      void session.remove();
                  }}
                >
                  Delete image
                </button>
                <button
                  type="button"
                  className="ghost"
                  disabled={busy}
                  data-testid={`${testId}-reload`}
                  onClick={reload}
                >
                  Reload image
                </button>
              </div>
              {image && (
                <p className="muted" style={{ marginTop: 6 }}>
                  {image.mimeType}
                  {image.size != null ? ` · ${(image.size / 1024).toFixed(1)} KB` : ''}
                </p>
              )}
            </div>
          </div>
        </>
      )}
      {busy && <p role="status">{state.writing ? 'Saving image…' : 'Loading image…'}</p>}
      {error && (
        <div className="msg err" role="alert" data-testid={`${testId}-error`}>
          {state.conflict ? <span data-testid={`${testId}-conflict`}>{error}</span> : error}
        </div>
      )}
      {state.pendingFile && (
        <div className="row" style={{ alignItems: 'center' }}>
          <span className="muted">Selected file: {state.pendingFile.name}</span>
          <button
            type="button"
            className="ghost"
            disabled={!canUpdate}
            data-testid={`${testId}-retry-upload`}
            onClick={() => void session.retryUpload()}
          >
            Retry upload
          </button>
        </div>
      )}
    </div>
  );
}
