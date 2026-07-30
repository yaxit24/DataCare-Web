'use client';

import { useCameraCapture } from './CameraCapture';

import { useEffect, useRef, useState } from 'react';
import { ApiError, del, get, post } from '../lib/api';

interface RepairImagePayload {
  imageNo: string;
  imageType: string;
  mimeType: string;
  size: number;
  entryTime: string;
  data: string;
}

/**
 * Repair-line image attachment, mirroring the desktop TR_REP_REC image buttons.
 *
 * Desktop keys the photo to the source customer repair row when the grid row was imported from one,
 * so `imageBook`/`imageYear`/`vchNo`/`srNo` must be the *source* identity on KRREP ISSUE and the
 * current voucher identity on CUSTREP RECEIPT. Bytes live in REP_IMAGE rather than a file share.
 */
export function RepairImagePanel({
  imageBook,
  imageYear,
  vchNo,
  srNo,
  disabled,
  testId = 'repair-image',
}: {
  imageBook: string;
  imageYear?: string;
  vchNo: string;
  srNo: number;
  disabled?: boolean;
  testId?: string;
}) {
  const [image, setImage] = useState<RepairImagePayload | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const fileRef = useRef<HTMLInputElement>(null);
  const camera = useCameraCapture({ fileName: `${testId}-capture.jpg` });
  const ready = Boolean(imageBook && vchNo && srNo && !disabled);
  const query = `coBook=${encodeURIComponent(imageBook)}&vchNo=${encodeURIComponent(
    vchNo,
  )}&srNo=${srNo}${imageYear ? `&imageYear=${encodeURIComponent(imageYear)}` : ''}`;

  useEffect(() => {
    let active = true;
    if (!ready) {
      setImage(null);
      return () => {
        active = false;
      };
    }
    (async () => {
      try {
        const found = await get<RepairImagePayload>(`/repair-images/line?${query}&format=json`);
        if (active) setImage(found);
      } catch {
        if (active) setImage(null);
      }
    })();
    return () => {
      active = false;
    };
  }, [ready, query]);

  const keyBody = () => ({
    // Duplicate the source book as coBook so the authoritative request-scope layer validates it.
    coBook: imageBook,
    imageBook,
    imageYear: imageYear || undefined,
    vchNo,
    srNo,
  });

  async function upload(file: File) {
    setError('');
    setBusy(true);
    try {
      const buffer = await file.arrayBuffer();
      const bytes = new Uint8Array(buffer);
      let binary = '';
      for (const byte of bytes) binary += String.fromCharCode(byte);
      await post('/repair-images', {
        ...keyBody(),
        mimeType: file.type || undefined,
        data: btoa(binary),
      });
      const saved = await get<RepairImagePayload>(`/repair-images/line?${query}&format=json`);
      setImage(saved);
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'repair image upload failed',
      );
    } finally {
      setBusy(false);
      if (fileRef.current) fileRef.current.value = '';
    }
  }

  async function remove() {
    if (!window.confirm('Are you sure to delete this image now?')) return;
    setError('');
    setBusy(true);
    try {
      await del('/repair-images', keyBody());
      setImage(null);
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'repair image delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div className="panel" data-testid={testId}>
      <h2>Repair Image</h2>
      {!ready && (
        <p className="muted">
          Save the voucher and select a repair row to attach its photo. Images stay attached to the
          customer repair row through every workflow stage.
        </p>
      )}
      {ready && (
        <div className="row" style={{ alignItems: 'flex-start' }}>
          <div>
            {image ? (
              /* eslint-disable-next-line @next/next/no-img-element */
              <img
                src={`data:${image.mimeType};base64,${image.data}`}
                alt={`Repair image ${image.imageNo}`}
                style={{ maxWidth: 220, maxHeight: 220, border: '1px solid #cbd5e1' }}
                data-testid={`${testId}-preview`}
              />
            ) : (
              <div className="muted" data-testid={`${testId}-empty`}>
                No image attached
              </div>
            )}
          </div>
          <div>
            <div className="field">
              <label htmlFor={`${testId}-file`}>Attach JPEG / PNG (max 4 MB)</label>
              <input
                id={`${testId}-file`}
                ref={fileRef}
                type="file"
                accept="image/jpeg,image/png"
                disabled={busy}
                onChange={(event) => {
                  const file = event.target.files?.[0];
                  if (file) void upload(file);
                }}
              />
            </div>
            {/* Webcam capture, the UT_WEB_CAM equivalent. A captured frame becomes a JPEG File and goes
                through the SAME upload path as an attached file, so there is one storage route and one
                set of size/type checks. Never synthesises an image: with no camera or no permission the
                control stays disabled and says why. */}
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
            <div className="toolbar" style={{ marginTop: 8 }}>
              {camera.status === 'live' ? (
                <>
                  <button
                    type="button"
                    className="ghost"
                    disabled={busy}
                    data-testid={`${testId}-camera-capture`}
                    onClick={async () => {
                      const file = await camera.capture();
                      if (!file) return;
                      camera.stop();
                      await upload(file);
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
                  data-testid={`${testId}-camera-start`}
                  disabled={busy || camera.status === 'unsupported'}
                  onClick={() => void camera.start()}
                >
                  Use camera
                </button>
              )}
              <button type="button" className="danger" disabled={!image || busy} onClick={remove}>
                Delete image
              </button>
            </div>
            {image && (
              <p className="muted" style={{ marginTop: 6 }}>
                {image.imageNo} · {image.mimeType} · {(image.size / 1024).toFixed(1)} KB
              </p>
            )}
          </div>
        </div>
      )}
      {error && <div className="msg err">{error}</div>}
    </div>
  );
}
