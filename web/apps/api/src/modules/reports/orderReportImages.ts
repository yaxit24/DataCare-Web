import { ENTITY_IMAGE_MAX_BYTES } from '../images/entityImage.js';
import { UnsupportedReportBindingError } from './reportBindingContract.js';

/** Resolver output for one saved parent; ordinary absence is different from an unavailable import. */
export type OrderReportImage =
  | { state: 'absent' }
  | { state: 'present'; bytes: Buffer; mimeType: 'image/jpeg' | 'image/png'; source: string };
export type OrderReportImages = Record<string, OrderReportImage>;

/** Decoding is performed by the transaction-local image resolver before bytes reach this renderer. */
export function orderReportImageUri(report: string, image: OrderReportImage): string | null {
  if (!image || (image.state !== 'absent' && image.state !== 'present'))
    throw new UnsupportedReportBindingError(report, 'invalid-order-render-image');
  if (image.state === 'absent') return null;
  const bytes = image.bytes;
  const validSize =
    Buffer.isBuffer(bytes) && bytes.length > 0 && bytes.length <= ENTITY_IMAGE_MAX_BYTES;
  if (!validSize) throw new UnsupportedReportBindingError(report, 'invalid-order-render-image');
  const png =
    image.mimeType === 'image/png' &&
    bytes.subarray(0, 8).equals(Buffer.from([137, 80, 78, 71, 13, 10, 26, 10]));
  const jpeg =
    image.mimeType === 'image/jpeg' && bytes.subarray(0, 3).equals(Buffer.from([255, 216, 255]));
  if (!png && !jpeg) throw new UnsupportedReportBindingError(report, 'invalid-order-render-image');
  return `data:${image.mimeType};base64,${bytes.toString('base64')}`;
}
