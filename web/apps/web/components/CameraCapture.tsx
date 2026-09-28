'use client';

import { useCallback, useEffect, useRef, useState } from 'react';
import { CameraRequestGuard } from '../lib/cameraRequestGuard';

/**
 * Webcam capture — the web equivalent of the desktop's `UT_WEB_CAM` / `PicImage` flow.
 *
 * The desktop opens a capture device, shows a preview, and on confirm writes a JPEG. It saves to a LAN
 * share (`DC_Main.MSImageSavePath`), which is why its failure path talks about a "Len connection"; the web
 * stores the bytes in the database instead, so a capture here produces a `File` that goes through the same
 * upload endpoint an operator would use for a file. That keeps one storage path and one set of size and
 * type checks.
 *
 * Honesty rules, same as the scale:
 *  • with no camera or no permission the control reports that plainly and stays disabled;
 *  • nothing is ever synthesised — there is no placeholder image;
 *  • the stream is stopped on unmount and after capture, so the camera light does not stay on.
 */
export type CameraStatus = 'idle' | 'unsupported' | 'requesting' | 'live' | 'denied' | 'error';

export interface CameraCaptureOptions {
  /** JPEG quality, matching the desktop's `.jpg` save. */
  quality?: number;
  /** Longest edge in pixels; keeps uploads inside the existing size limit. */
  maxEdge?: number;
  fileName?: string;
}

export function useCameraCapture(options: CameraCaptureOptions = {}) {
  const { quality = 0.85, maxEdge = 1280, fileName = 'capture.jpg' } = options;
  const [status, setStatus] = useState<CameraStatus>('idle');
  const [message, setMessage] = useState('');
  const videoRef = useRef<HTMLVideoElement | null>(null);
  const guardRef = useRef<CameraRequestGuard | null>(null);
  if (!guardRef.current) guardRef.current = new CameraRequestGuard();
  const guard = guardRef.current;

  useEffect(() => {
    if (
      typeof navigator === 'undefined' ||
      typeof navigator.mediaDevices?.getUserMedia !== 'function'
    ) {
      setStatus('unsupported');
      setMessage('This browser or context has no camera API. Attach a file instead.');
    }
  }, []);

  const stop = useCallback(() => {
    guard.stop();
    if (videoRef.current) videoRef.current.srcObject = null;
    setStatus((current) => (current === 'unsupported' ? current : 'idle'));
  }, [guard]);

  useEffect(
    () => () => {
      guard.stop();
    },
    [guard],
  );

  const start = useCallback(async () => {
    if (typeof navigator.mediaDevices?.getUserMedia !== 'function') return;
    const request = guard.begin();
    setStatus('requesting');
    setMessage('');
    try {
      const stream = await navigator.mediaDevices.getUserMedia({ video: true, audio: false });
      if (!guard.accept(request, stream)) return;
      if (videoRef.current) {
        videoRef.current.srcObject = stream;
        await videoRef.current.play().catch(() => undefined);
      }
      if (guard.isLive(request)) setStatus('live');
    } catch (error) {
      if (!guard.isCurrent(request)) return;
      const name = (error as { name?: string } | null)?.name ?? '';
      if (name === 'NotAllowedError' || name === 'SecurityError') {
        setStatus('denied');
        setMessage('Camera permission was refused.');
      } else {
        setStatus('error');
        setMessage('No camera could be opened.');
      }
    }
  }, [guard]);

  /** Capture the current frame as a JPEG File, or null when there is nothing live to capture. */
  const capture = useCallback(async (): Promise<File | null> => {
    const video = videoRef.current;
    const request = guard.token();
    if (!video || status !== 'live' || !guard.isLive(request)) return null;
    const width = video.videoWidth;
    const height = video.videoHeight;
    if (!width || !height) return null;

    const scale = Math.min(1, maxEdge / Math.max(width, height));
    const canvas = document.createElement('canvas');
    canvas.width = Math.round(width * scale);
    canvas.height = Math.round(height * scale);
    const context = canvas.getContext('2d');
    if (!context) return null;
    context.drawImage(video, 0, 0, canvas.width, canvas.height);

    const blob = await new Promise<Blob | null>((resolve) =>
      canvas.toBlob((result) => resolve(result), 'image/jpeg', quality),
    );
    if (!blob || !guard.isLive(request)) return null;
    return new File([blob], fileName, { type: 'image/jpeg' });
  }, [fileName, guard, maxEdge, quality, status]);

  return { status, message, videoRef, start, stop, capture };
}
