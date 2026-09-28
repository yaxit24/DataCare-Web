import { describe, expect, it, vi } from 'vitest';
import { ApiError } from '../lib/api';
import { ImageScopeBarrier } from '../lib/imageScopeBarrier';
import {
  ImageEditorSession,
  type EditableImage,
  type ImageEditorPayload,
  type ImageEditorTransport,
} from '../lib/imageEditorSession';

const version = (value: string) => value.repeat(64);
const payload = (
  v = 'a',
  image: EditableImage = { state: 'absent' },
  canUpdate = true,
  canDelete = true,
): ImageEditorPayload => ({ version: version(v), image, canUpdate, canDelete });
const photo = (data = 'cGhvdG8='): EditableImage => ({
  state: 'present',
  mimeType: 'image/png',
  data,
  size: 5,
});
const file = () => new File(['selected bytes'], 'selected.png', { type: 'image/png' });
const conflict = () =>
  new ApiError('image-version-conflict', 409, {
    message: 'The image changed. Reload before retrying.',
  });
function deferred<T>() {
  let resolve!: (value: T) => void;
  let reject!: (error: unknown) => void;
  const promise = new Promise<T>((ok, fail) => {
    resolve = ok;
    reject = fail;
  });
  return { promise, resolve, reject };
}
function editor(transport: ImageEditorTransport, current = () => true, mutable = () => true) {
  const session = new ImageEditorSession(transport, current, mutable);
  session.activate();
  return session;
}
function transport(read: () => Promise<ImageEditorPayload> = async () => payload()) {
  return {
    read: vi.fn(read),
    upload: vi.fn<ImageEditorTransport['upload']>(async () => undefined),
    remove: vi.fn<ImageEditorTransport['remove']>(async () => undefined),
  };
}

describe('revision-aware shared image editor session', () => {
  it('uses an observed absent revision for first upload and clears the committed local file', async () => {
    const api = transport();
    api.read.mockResolvedValueOnce(payload()).mockResolvedValueOnce(payload('b', photo()));
    const session = editor(api);
    expect(await session.upload(file())).toBe(false);
    expect(await session.reload()).toBe(true);
    const chosen = file();
    expect(await session.upload(chosen)).toBe(true);
    expect(api.upload).toHaveBeenCalledTimes(1);
    expect(api.upload).toHaveBeenCalledWith(
      { data: btoa('selected bytes'), mimeType: 'image/png' },
      version('a'),
    );
    expect(session.getSnapshot()).toMatchObject({
      payload: payload('b', photo()),
      pendingFile: null,
      needsReload: false,
      writing: false,
    });
  });

  it('retains a failed file but never retries until explicit reload and explicit retry', async () => {
    const api = transport();
    api.read
      .mockResolvedValueOnce(payload())
      .mockResolvedValueOnce(payload('b', photo('bmV3ZXI=')))
      .mockResolvedValueOnce(payload('c', photo()));
    api.upload.mockRejectedValueOnce(conflict());
    const session = editor(api);
    await session.reload();
    const chosen = file();
    expect(await session.upload(chosen)).toBe(false);
    expect(session.getSnapshot()).toMatchObject({
      pendingFile: chosen,
      conflict: true,
      needsReload: true,
    });
    expect(await session.retryUpload()).toBe(false);
    expect(api.upload).toHaveBeenCalledTimes(1);
    expect(api.read).toHaveBeenCalledTimes(1);
    expect(await session.reload()).toBe(true);
    expect(session.getSnapshot()).toMatchObject({
      payload: payload('b', photo('bmV3ZXI=')),
      pendingFile: chosen,
      conflict: false,
    });
    expect(api.upload).toHaveBeenCalledTimes(1);
    expect(await session.retryUpload()).toBe(true);
    expect(api.upload.mock.calls[1]?.[1]).toBe(version('b'));
    expect(session.getSnapshot().pendingFile).toBeNull();
  });

  it('requires reload and a second deliberate delete after stale delete', async () => {
    const api = transport();
    api.read
      .mockResolvedValueOnce(payload('a', photo()))
      .mockResolvedValueOnce(payload('b', photo('bmV3ZXI=')))
      .mockResolvedValueOnce(payload('c'));
    api.remove.mockRejectedValueOnce(conflict());
    const session = editor(api);
    await session.reload();
    expect(await session.remove()).toBe(false);
    expect(await session.remove()).toBe(false);
    await session.reload();
    expect(api.remove).toHaveBeenCalledTimes(1);
    expect(await session.remove()).toBe(true);
    expect(api.remove.mock.calls.map((call) => call[0])).toEqual([version('a'), version('b')]);
    expect(session.getSnapshot().payload?.image.state).toBe('absent');
  });

  it('cannot delete an absent image even when the server grants delete permission', async () => {
    const api = transport();
    const session = editor(api);
    await session.reload();
    expect(await session.remove()).toBe(false);
    expect(api.remove).not.toHaveBeenCalled();
  });

  it('allows replacement and deletion of unavailable stored images with the observed token', async () => {
    const unavailable = payload('a', { state: 'unavailable', message: 'invalid historical image' });
    const api = transport(async () => unavailable);
    const session = editor(api);
    await session.reload();
    expect(await session.upload(file())).toBe(true);
    expect(await session.remove()).toBe(true);
    expect(api.remove).toHaveBeenCalledTimes(1);
    expect(api.remove).toHaveBeenCalledWith(version('a'));
  });

  it('keeps read-only image state visible and refuses all mutations', async () => {
    const readOnly = payload('a', photo(), false, false);
    const api = transport(async () => readOnly);
    const session = editor(api);
    await session.reload();
    expect(session.getSnapshot().payload).toEqual(readOnly);
    expect(session.lease()).toBeNull();
    expect(await session.upload(file())).toBe(false);
    expect(await session.remove()).toBe(false);
    expect(api.upload).not.toHaveBeenCalled();
    expect(api.remove).not.toHaveBeenCalled();
  });

  it('requires a new capability read after authorization is revoked during upload', async () => {
    const api = transport();
    api.upload.mockRejectedValueOnce(new ApiError('forbidden', 403, {}));
    api.read
      .mockResolvedValueOnce(payload())
      .mockResolvedValueOnce(payload('a', photo(), false, false));
    const session = editor(api);
    await session.reload();
    await session.upload(file());
    expect(session.getSnapshot().needsReload).toBe(true);
    expect(await session.retryUpload()).toBe(false);
    await session.reload();
    expect(await session.retryUpload()).toBe(false);
    expect(api.upload).toHaveBeenCalledTimes(1);
  });

  it('fails closed when a read fails or does not contain a valid observed token', async () => {
    const api = transport();
    api.read
      .mockRejectedValueOnce(new Error('offline'))
      .mockResolvedValueOnce({ ...payload(), version: '' });
    const session = editor(api);
    expect(await session.reload()).toBe(false);
    expect(session.lease()).toBeNull();
    expect(await session.reload()).toBe(false);
    expect(session.getSnapshot().payload).toBeNull();
    expect(await session.upload(file())).toBe(false);
    expect(api.upload).not.toHaveBeenCalled();
  });

  it('does not send delayed file bytes after the selected context changes before effect cleanup', async () => {
    let current = true;
    const read = deferred<ArrayBuffer>();
    const selected = file();
    Object.defineProperty(selected, 'arrayBuffer', { value: () => read.promise });
    const api = transport();
    const session = editor(api, () => current);
    await session.reload();
    const operation = session.upload(selected);
    current = false;
    read.resolve(new Uint8Array([1, 2, 3]).buffer);
    expect(await operation).toBe(false);
    expect(api.upload).not.toHaveBeenCalled();
    session.dispose();
    expect(session.getSnapshot().pendingFile).toBeNull();
    expect(session.isCurrentContext()).toBe(false);
  });

  it('does not send delayed file bytes when the parent becomes disabled', async () => {
    let mutable = true;
    const read = deferred<ArrayBuffer>();
    const selected = file();
    Object.defineProperty(selected, 'arrayBuffer', { value: () => read.promise });
    const api = transport();
    const session = editor(
      api,
      () => true,
      () => mutable,
    );
    await session.reload();
    const operation = session.upload(selected);
    mutable = false;
    read.resolve(new Uint8Array([1]).buffer);
    expect(await operation).toBe(false);
    expect(api.upload).not.toHaveBeenCalled();
  });

  it('rejects a chooser lease from another session or before reload even when the version is unchanged', async () => {
    const api = transport();
    const first = editor(api),
      second = editor(api);
    await first.reload();
    await second.reload();
    const lease = first.lease();
    expect(await second.upload(file(), lease)).toBe(false);
    await first.reload();
    expect(await first.upload(file(), lease)).toBe(false);
    expect(api.upload).not.toHaveBeenCalled();
  });

  it('drops a late old read and does not restore old payload after disposal/reactivation', async () => {
    const old = deferred<ImageEditorPayload>(),
      next = deferred<ImageEditorPayload>();
    const api = transport();
    api.read.mockReturnValueOnce(old.promise).mockReturnValueOnce(next.promise);
    const session = editor(api);
    const initial = session.reload();
    session.dispose();
    session.activate();
    const latest = session.reload();
    old.resolve(payload('a', photo()));
    expect(await initial).toBe(false);
    expect(session.getSnapshot().payload).toBeNull();
    next.resolve(payload('b'));
    expect(await latest).toBe(true);
    expect(session.getSnapshot().payload).toEqual(payload('b'));
  });

  it('serializes user writes and never replaces the first pending file with a concurrent second upload', async () => {
    const write = deferred<void>();
    const api = transport();
    api.upload.mockReturnValueOnce(write.promise);
    const session = editor(api);
    await session.reload();
    const selected = file();
    const first = session.upload(selected);
    await vi.waitFor(() => expect(api.upload).toHaveBeenCalledTimes(1));
    expect(await session.upload(file())).toBe(false);
    expect(session.getSnapshot().pendingFile).toBe(selected);
    write.resolve();
    expect(await first).toBe(true);
    expect(api.upload).toHaveBeenCalledTimes(1);
  });

  it('never resends a committed upload when only readback failed', async () => {
    const api = transport();
    api.read
      .mockResolvedValueOnce(payload())
      .mockRejectedValueOnce(new Error('readback offline'))
      .mockResolvedValueOnce(payload('b', photo()));
    const session = editor(api);
    await session.reload();
    expect(await session.upload(file())).toBe(false);
    expect(session.getSnapshot()).toMatchObject({
      pendingFile: null,
      payload: null,
      needsReload: true,
    });
    expect(session.getSnapshot().error).toContain('Image saved.');
    expect(await session.retryUpload()).toBe(false);
    await session.reload();
    expect(api.upload).toHaveBeenCalledTimes(1);
    expect(session.getSnapshot().payload?.version).toBe(version('b'));
  });

  it.each([
    new File([], 'empty.png', { type: 'image/png' }),
    new File([new Uint8Array(4 * 1024 * 1024 + 1)], 'large.png', { type: 'image/png' }),
    new File(['not image'], 'file.txt', { type: 'text/plain' }),
  ])('rejects invalid file $name before sending bytes', async (selected) => {
    const api = transport();
    const session = editor(api);
    await session.reload();
    expect(await session.upload(selected)).toBe(false);
    expect(api.upload).not.toHaveBeenCalled();
    expect(session.getSnapshot().error).toContain('JPEG or PNG');
  });
});

describe('mounted image scope acknowledgment', () => {
  it('allows initial scope and unchanged rerenders without an extra acknowledgment', () => {
    const barrier = new ImageScopeBarrier('company01/location01/year2024');
    expect(barrier.observe('company01/location01/year2024')).toBe(false);
    expect(barrier.observe('company01/location01/year2024')).toBe(false);
  });
  it('requires an explicit reload for A to B to A, including the previously acknowledged A', () => {
    const barrier = new ImageScopeBarrier('A');
    expect(barrier.observe('B')).toBe(true);
    expect(barrier.observe('A')).toBe(true);
    expect(barrier.acknowledge('A', barrier.generationToken())).toBe(true);
    expect(barrier.observe('A')).toBe(false);
    expect(barrier.observe('B')).toBe(true);
    expect(barrier.acknowledge('B', barrier.generationToken())).toBe(true);
    expect(barrier.observe('B')).toBe(false);
    expect(barrier.observe('A')).toBe(true);
  });
  it('does not let an older scope reload handler acknowledge the newly selected scope', () => {
    const barrier = new ImageScopeBarrier('A');
    const firstGeneration = barrier.generationToken();
    expect(barrier.observe('B')).toBe(true);
    expect(barrier.acknowledge('A', firstGeneration)).toBe(false);
    expect(barrier.observe('B')).toBe(true);
    expect(barrier.observe('A')).toBe(true);
    expect(barrier.acknowledge('A', firstGeneration)).toBe(false);
    expect(barrier.observe('A')).toBe(true);
  });
});
