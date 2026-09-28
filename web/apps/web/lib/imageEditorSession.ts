import { ApiError } from './api';

export type EditableImage =
  | { state: 'absent' }
  | { state: 'unavailable'; message?: string }
  | { state: 'present'; mimeType: string; data: string; size?: number };

export interface ImageEditorPayload {
  version: string;
  canUpdate: boolean;
  canDelete: boolean;
  image: EditableImage;
}

export interface PreparedImage {
  data: string;
  mimeType?: string;
}

export interface ImageEditorTransport {
  read: () => Promise<ImageEditorPayload>;
  upload: (image: PreparedImage, version: string) => Promise<unknown>;
  remove: (version: string) => Promise<unknown>;
}

export interface ImageEditorSnapshot {
  payload: ImageEditorPayload | null;
  pendingFile: File | null;
  loading: boolean;
  writing: boolean;
  needsReload: boolean;
  conflict: boolean;
  error: string;
}

export interface ImageEditLease {
  owner: object;
  generation: number;
  version: string;
}

const emptySnapshot = (): ImageEditorSnapshot => ({
  payload: null,
  pendingFile: null,
  loading: false,
  writing: false,
  needsReload: false,
  conflict: false,
  error: '',
});

function errorText(error: unknown): string {
  return error instanceof ApiError
    ? String(error.body?.message || error.body?.error || error.message)
    : error instanceof Error
      ? error.message
      : 'The image request failed. Reload the image and try again.';
}

function validatePayload(payload: ImageEditorPayload): ImageEditorPayload {
  if (
    !payload ||
    !/^[a-f\d]{64}$/i.test(payload.version) ||
    typeof payload.canUpdate !== 'boolean' ||
    typeof payload.canDelete !== 'boolean' ||
    !payload.image ||
    !['absent', 'unavailable', 'present'].includes(payload.image.state) ||
    (payload.image.state === 'present' &&
      (!['image/jpeg', 'image/png'].includes(payload.image.mimeType) ||
        typeof payload.image.data !== 'string' ||
        !payload.image.data))
  )
    throw new Error('The image state is incomplete. Reload before changing the image.');
  return payload;
}

function validateFile(file: File) {
  if (!file.size || file.size > 4 * 1024 * 1024)
    throw new Error('Select a JPEG or PNG image up to 4 MB.');
  // Some file choosers omit MIME. The server always checks the actual bytes and decodes the image.
  if (file.type && !['image/jpeg', 'image/png'].includes(file.type))
    throw new Error('Select a JPEG or PNG image.');
}

/**
 * One selected image identity and observed revision. No automatic retry after a conflict.
 * A lease captures the observation before the native chooser/camera or file reader can yield.
 */
export class ImageEditorSession {
  private snapshot = emptySnapshot();
  private generation = 0;
  private active = false;
  private readonly owner = {};
  private readonly listeners = new Set<() => void>();

  constructor(
    private readonly transport: ImageEditorTransport,
    private readonly isCurrent: () => boolean = () => true,
    private readonly canMutate: () => boolean = () => true,
  ) {}

  getSnapshot = () => this.snapshot;
  subscribe = (listener: () => void) => {
    this.listeners.add(listener);
    return () => {
      this.listeners.delete(listener);
    };
  };

  activate() {
    this.active = true;
  }

  dispose() {
    this.active = false;
    this.generation += 1;
    this.snapshot = emptySnapshot();
  }

  private current(generation = this.generation) {
    return this.active && this.isCurrent() && generation === this.generation;
  }

  isCurrentContext() {
    return this.current();
  }

  private set(values: Partial<ImageEditorSnapshot>) {
    this.snapshot = { ...this.snapshot, ...values };
    for (const listener of this.listeners) listener();
  }

  private idle() {
    return !this.snapshot.loading && !this.snapshot.writing;
  }

  lease(): ImageEditLease | null {
    if (
      !this.current() ||
      !this.canMutate() ||
      !this.idle() ||
      this.snapshot.needsReload ||
      !this.snapshot.payload?.canUpdate
    )
      return null;
    return {
      owner: this.owner,
      generation: this.generation,
      version: this.snapshot.payload.version,
    };
  }

  private validLease(lease: ImageEditLease | null): lease is ImageEditLease {
    return Boolean(
      lease &&
      lease.owner === this.owner &&
      this.current(lease.generation) &&
      this.canMutate() &&
      this.idle() &&
      !this.snapshot.needsReload &&
      this.snapshot.payload?.canUpdate &&
      lease.version === this.snapshot.payload.version,
    );
  }

  async reload(): Promise<boolean> {
    if (!this.current() || !this.idle()) return false;
    const generation = ++this.generation;
    this.set({ loading: true, error: '' });
    try {
      const payload = validatePayload(await this.transport.read());
      if (!this.current(generation)) return false;
      this.set({ payload, needsReload: false, conflict: false, error: '' });
      return true;
    } catch (error) {
      if (this.current(generation)) this.set({ error: errorText(error), needsReload: true });
      return false;
    } finally {
      if (this.current(generation)) this.set({ loading: false });
    }
  }

  async upload(file: File, lease = this.lease()): Promise<boolean> {
    if (!this.validLease(lease)) return false;
    const generation = ++this.generation;
    this.set({ pendingFile: file, writing: true, error: '', conflict: false });
    let committed = false;
    try {
      validateFile(file);
      const bytes = new Uint8Array(await file.arrayBuffer());
      if (!this.current(generation) || !this.canMutate()) return false;
      let binary = '';
      for (let index = 0; index < bytes.length; index += 8192)
        binary += String.fromCharCode(...bytes.subarray(index, index + 8192));
      await this.transport.upload(
        { data: btoa(binary), mimeType: file.type || undefined },
        lease.version,
      );
      committed = true;
      if (!this.current(generation)) return false;
      // A successful write is never retried just because its readback subsequently failed.
      this.set({ pendingFile: null, payload: null, needsReload: true });
      const payload = validatePayload(await this.transport.read());
      if (!this.current(generation)) return false;
      this.set({ payload, needsReload: false, conflict: false, error: '' });
      return true;
    } catch (error) {
      if (this.current(generation)) {
        const conflict = error instanceof ApiError && error.status === 409;
        this.set({
          conflict,
          needsReload:
            committed ||
            conflict ||
            (error instanceof ApiError && [401, 403].includes(error.status)),
          error: committed ? `Image saved. ${errorText(error)}` : errorText(error),
        });
      }
      return false;
    } finally {
      if (this.current(generation)) this.set({ writing: false });
    }
  }

  retryUpload(): Promise<boolean> {
    const file = this.snapshot.pendingFile;
    return file ? this.upload(file) : Promise.resolve(false);
  }

  async remove(): Promise<boolean> {
    const payload = this.snapshot.payload;
    if (
      !this.current() ||
      !this.canMutate() ||
      !this.idle() ||
      this.snapshot.needsReload ||
      !payload?.canDelete ||
      payload.image.state === 'absent'
    )
      return false;
    const generation = ++this.generation;
    this.set({ writing: true, error: '', conflict: false });
    let committed = false;
    try {
      await this.transport.remove(payload.version);
      committed = true;
      if (!this.current(generation)) return false;
      this.set({ pendingFile: null, payload: null, needsReload: true });
      const next = validatePayload(await this.transport.read());
      if (!this.current(generation)) return false;
      this.set({ payload: next, needsReload: false, conflict: false, error: '' });
      return true;
    } catch (error) {
      if (this.current(generation)) {
        const conflict = error instanceof ApiError && error.status === 409;
        this.set({
          conflict,
          needsReload:
            committed ||
            conflict ||
            (error instanceof ApiError && [401, 403].includes(error.status)),
          error: committed ? `Image deleted. ${errorText(error)}` : errorText(error),
        });
      }
      return false;
    } finally {
      if (this.current(generation)) this.set({ writing: false });
    }
  }
}
