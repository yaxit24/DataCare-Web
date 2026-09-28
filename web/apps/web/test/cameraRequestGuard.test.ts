import { describe, expect, it, vi } from 'vitest';
import { CameraRequestGuard } from '../lib/cameraRequestGuard';

function stream() {
  const stop = vi.fn();
  return {
    value: { getTracks: () => [{ stop }] } as unknown as Pick<MediaStream, 'getTracks'>,
    stop,
  };
}

describe('camera permission and capture ownership', () => {
  it('stops every track returned by a permission request after stop/unmount', () => {
    const guard = new CameraRequestGuard(),
      camera = stream();
    const request = guard.begin();
    guard.stop();
    expect(guard.accept(request, camera.value)).toBe(false);
    expect(camera.stop).toHaveBeenCalledOnce();
    expect(guard.isLive(request)).toBe(false);
  });
  it('cannot let an older permission response replace or stop the newer active stream', () => {
    const guard = new CameraRequestGuard(),
      old = stream(),
      latest = stream();
    const first = guard.begin(),
      second = guard.begin();
    expect(guard.accept(second, latest.value)).toBe(true);
    expect(guard.accept(first, old.value)).toBe(false);
    expect(old.stop).toHaveBeenCalledOnce();
    expect(latest.stop).not.toHaveBeenCalled();
    expect(guard.isLive(second)).toBe(true);
  });
  it('invalidates an in-flight frame token when stopped or another capture session begins', () => {
    const guard = new CameraRequestGuard(),
      first = stream(),
      second = stream();
    const token = guard.begin();
    guard.accept(token, first.value);
    expect(guard.isLive(token)).toBe(true);
    const next = guard.begin();
    guard.accept(next, second.value);
    expect(guard.isLive(token)).toBe(false);
    expect(first.stop).toHaveBeenCalledOnce();
    guard.stop();
    guard.stop();
    expect(second.stop).toHaveBeenCalledOnce();
    expect(guard.isLive(next)).toBe(false);
  });
});
