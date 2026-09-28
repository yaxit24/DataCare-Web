import { createHash } from 'node:crypto';
import sharp from 'sharp';

export class ImageVersionConflictError extends Error {
  constructor() {
    super('The image changed. Reload before retrying.');
    this.name = 'ImageVersionConflictError';
  }
}
export class ImageStateValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ImageStateValidationError';
  }
}

export function requireImageVersion(value: unknown): string {
  if (typeof value !== 'string' || !/^[a-f0-9]{64}$/.test(value))
    throw new ImageStateValidationError(
      'Reload the image to obtain a valid version before changing it.',
    );
  return value;
}

export function imageStateVersion(snapshot: unknown): string {
  return createHash('sha256').update(JSON.stringify(snapshot)).digest('hex');
}

export function compareImageVersion(expected: string | undefined, actual: string): void {
  // Optional only for trusted in-process import/fixture callers. HTTP adapters require a token.
  if (expected === undefined) return;
  requireImageVersion(expected);
  if (expected !== actual) throw new ImageVersionConflictError();
}

/** Fully decode modern uploads and previews; header signatures alone accept truncated files. */
export async function validateImagePixels(bytes: Buffer, mimeType: string): Promise<void> {
  if (!bytes.length || bytes.length > 4 * 1024 * 1024)
    throw new ImageStateValidationError('Image is empty or exceeds the 4 MB limit.');
  try {
    const decoder = sharp(bytes, { failOn: 'warning', limitInputPixels: 25_000_000 });
    const metadata = await decoder.metadata();
    if (
      (metadata.format === 'jpeg' ? 'image/jpeg' : metadata.format === 'png' ? 'image/png' : '') !==
      mimeType
    )
      throw new Error('Image format mismatch');
    await decoder.raw().toBuffer();
  } catch {
    throw new ImageStateValidationError('The image cannot be decoded as a complete JPEG or PNG.');
  }
}

export type ImagePreview =
  | { state: 'absent' }
  | { state: 'unavailable'; message: string }
  | { state: 'present'; data: string; mimeType: string; size: number };

export async function imagePreview(
  row: { bytes: Buffer; mimeType: string; size: number; validType: boolean } | null,
  missingIndex = false,
): Promise<ImagePreview> {
  if (!row)
    return missingIndex
      ? {
          state: 'unavailable',
          message: 'The image index exists, but its bytes have not been transferred.',
        }
      : { state: 'absent' };
  try {
    if (!row.validType || row.size !== row.bytes.length) throw new Error('Image metadata mismatch');
    await validateImagePixels(row.bytes, row.mimeType);
    return {
      state: 'present',
      data: row.bytes.toString('base64'),
      mimeType: row.mimeType,
      size: row.size,
    };
  } catch {
    return {
      state: 'unavailable',
      message:
        'The saved image is incomplete or its metadata disagrees. Select a complete JPEG or PNG to replace it.',
    };
  }
}
