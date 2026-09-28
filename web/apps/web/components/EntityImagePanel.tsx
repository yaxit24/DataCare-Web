'use client';

import { useEffect, useMemo, useRef, useState } from 'react';
import { del, get, post } from '../lib/api';
import type { ImageEditLease, ImageEditorPayload } from '../lib/imageEditorSession';
import { useImageEditor, useImageScopeBarrier } from '../lib/useImageEditor';
import { useBusinessScope } from './BusinessScope';
import { useCameraCapture } from './CameraCapture';

export type ImageEntityType = 'TAG' | 'AC' | 'MEMB' | 'SCHM' | 'DESIGN' | 'ITEM';

/** Shared photographs use the exact scoped entity identity and the revision observed by this editor. */
export function EntityImagePanel({
  entityType = 'TAG',
  entityKey,
  instance = 0,
  imageType,
  label = 'Image',
  disabled = false,
  testId = 'entity-image',
  endpoint = '/stock/tag-image',
}: {
  entityType?: ImageEntityType;
  entityKey: string;
  instance?: number;
  imageType?: string;
  label?: string;
  disabled?: boolean;
  testId?: string;
  /** Design Book keeps its own saved-parent validation and form authority. */
  endpoint?: string;
}) {
  const scope = useBusinessScope();
  const scopeBarrier = useImageScopeBarrier(scope);
  const imageCode = imageType || 'T';
  const query = new URLSearchParams({
    ...scope,
    entityType,
    entityKey,
    instance: String(instance),
    imageType: imageCode,
  }).toString();
  const body = JSON.stringify({ ...scope, entityType, entityKey, instance, imageType: imageCode });
  const ready = Boolean(
    scope.coCode && scope.lcCode && scope.coYear && entityKey && Number.isFinite(instance),
  );
  const identity = ready && !scopeBarrier.blocked ? `${endpoint}?${query}` : '';
  const transport = useMemo(
    () => ({
      read: () => get<ImageEditorPayload>(`${endpoint}/state?${query}`),
      upload: (image: { data: string; mimeType?: string }, version: string) =>
        post(endpoint, { ...JSON.parse(body), ...image, version }),
      remove: (version: string) =>
        del(`${endpoint}?${query}&version=${encodeURIComponent(version)}`),
    }),
    [body, endpoint, query],
  );
  const { session, state } = useImageEditor(identity, transport, disabled);
  const payload = state.payload;
  const busy = state.loading || state.writing;
  const canUpdate =
    ready &&
    !scopeBarrier.blocked &&
    !disabled &&
    !busy &&
    !state.needsReload &&
    payload?.canUpdate;
  const canDelete =
    ready &&
    !scopeBarrier.blocked &&
    !disabled &&
    !busy &&
    !state.needsReload &&
    payload?.canDelete &&
    payload.image.state !== 'absent';
  const [zoom, setZoom] = useState(false);
  const [imageProblem, setImageProblem] = useState<{ identity: string; version: string } | null>(
    null,
  );
  const fileRef = useRef<HTMLInputElement>(null);
  const chooser = useRef<{ lease: ImageEditLease | null } | null>(null);
  const cameraLease = useRef<ImageEditLease | null>(null);
  const camera = useCameraCapture({ fileName: `${entityKey || 'image'}.jpg` });
  const stopCamera = camera.stop;
  useEffect(() => {
    // Keep a cancelled native chooser distinguishable from programmatic file assignment.
    if (chooser.current) chooser.current.lease = null;
    cameraLease.current = null;
    stopCamera();
    return stopCamera;
  }, [identity, disabled, payload?.version, state.writing, stopCamera]);
  useEffect(() => setZoom(false), [identity, payload?.version]);
  const failedImage =
    imageProblem?.identity === identity && imageProblem.version === payload?.version;
  const image = payload?.image.state === 'present' && !failedImage ? payload.image : null;
  const error = state.error || (failedImage ? 'The saved image could not be displayed.' : '');

  function reload() {
    cameraLease.current = null;
    stopCamera();
    setImageProblem(null);
    if (scopeBarrier.blocked) scopeBarrier.acknowledge();
    else void session.reload();
  }

  return (
    <div className="panel" data-testid={testId} style={{ minWidth: 0 }}>
      <div className="toolbar" style={{ marginBottom: 8, flexWrap: 'wrap' }}>
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
          key={`${identity}:${disabled}`}
          ref={fileRef}
          type="file"
          accept="image/jpeg,image/png"
          disabled={!canUpdate}
          style={{ display: 'none' }}
          data-testid={`${testId}-file`}
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
        <button
          type="button"
          className="ghost"
          disabled={!canUpdate}
          data-testid={`${testId}-select`}
          onClick={() => {
            chooser.current = { lease: session.lease() };
            if (chooser.current.lease) fileRef.current?.click();
          }}
        >
          Select
        </button>
        {camera.status !== 'live' ? (
          <button
            type="button"
            className="ghost"
            disabled={!canUpdate || ['unsupported', 'requesting'].includes(camera.status)}
            data-testid={`${testId}-capture`}
            onClick={() => {
              cameraLease.current = session.lease();
              if (cameraLease.current) void camera.start();
            }}
          >
            Camera
          </button>
        ) : (
          <>
            <button
              type="button"
              className="ghost"
              disabled={!canUpdate}
              data-testid={`${testId}-camera-capture`}
              onClick={async () => {
                const lease = cameraLease.current;
                const file = await camera.capture();
                if (!lease || cameraLease.current !== lease || !session.isCurrentContext()) return;
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
        )}
        <button
          type="button"
          className="ghost"
          disabled={!canDelete}
          data-testid={`${testId}-delete`}
          onClick={() => void session.remove()}
        >
          Delete
        </button>
        <button
          type="button"
          className="ghost"
          disabled={!ready || busy || disabled}
          data-testid={`${testId}-reload`}
          onClick={reload}
        >
          Reload image
        </button>
      </div>

      <p className="muted" data-testid={`${testId}-scope`}>
        Company {scope.coCode} · Location {scope.lcCode} · Year {scope.coYear}
      </p>
      {scopeBarrier.blocked && (
        <p role="status" data-testid={`${testId}-scope-changed`}>
          Scope changed. Reload this record’s image before editing.
        </p>
      )}

      <video
        ref={camera.videoRef}
        muted
        playsInline
        aria-label="Camera preview"
        data-testid={`${testId}-camera-preview`}
        style={{
          display: camera.status === 'live' ? 'block' : 'none',
          maxWidth: '100%',
          width: 260,
        }}
      />
      <div className="muted" data-testid={`${testId}-camera-status`}>
        camera: {camera.status}
        {camera.message ? ` — ${camera.message}` : ''}
      </div>
      {busy && <p role="status">{state.writing ? 'Saving image…' : 'Loading image…'}</p>}
      {error && (
        <div className="msg err" role="alert" data-testid={`${testId}-error`}>
          {state.conflict ? <span data-testid={`${testId}-conflict`}>{error}</span> : error}
        </div>
      )}
      {state.pendingFile && (
        <div className="row" style={{ alignItems: 'center', marginBottom: 8 }}>
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
      {payload?.image.state === 'unavailable' && (
        <p className="msg err" role="alert" data-testid={`${testId}-unavailable`}>
          {payload.image.message || 'The stored image could not be decoded.'}
        </p>
      )}
      {image ? (
        <>
          <button
            type="button"
            className="ghost"
            style={{ padding: 0, border: 0, background: 'none' }}
            onClick={() => setZoom((value) => !value)}
            aria-label={zoom ? `Shrink ${label}` : `Enlarge ${label}`}
            data-testid={`${testId}-zoom`}
          >
            <img
              src={`data:${image.mimeType};base64,${image.data}`}
              alt={`${label} ${entityKey}`}
              data-testid={`${testId}-preview`}
              style={{
                maxWidth: zoom ? '100%' : 180,
                maxHeight: zoom ? 600 : 180,
                objectFit: 'contain',
                border: '1px solid var(--line, #ccc)',
              }}
              onError={() => {
                if (payload) setImageProblem({ identity, version: payload.version });
              }}
            />
          </button>
          <div className="muted">
            {image.mimeType}
            {image.size != null ? ` · ${Math.ceil(image.size / 1024)} KB` : ''}
          </div>
        </>
      ) : payload?.image.state === 'absent' || !ready ? (
        <div className="muted" data-testid={`${testId}-empty`}>
          {entityKey ? 'No image for this record' : ''}
        </div>
      ) : null}
    </div>
  );
}
