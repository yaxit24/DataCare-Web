import { useCallback, useState } from 'react';

/**
 * The Idempotency-Key of one voucher draft (N52, D18; the API side is
 * web/apps/api/src/modules/shared/idempotency.ts).
 *
 * Made when the form opens and renewed only after a successful save. A retry of the same draft (a lost
 * response, a proxy retry, the token-refresh retry in lib/api.ts) therefore carries the same key, and the API
 * answers it with the first save's response instead of posting a second voucher. A refused save keeps the key:
 * the API kept no receipt for it, so the corrected draft saves normally.
 */
export function newIdempotencyKey(): string {
  if (typeof crypto.randomUUID === 'function') return crypto.randomUUID();
  // crypto.randomUUID exists only in a secure context; a shop LAN served over plain http still has this.
  const bytes = crypto.getRandomValues(new Uint8Array(16));
  bytes[6] = (bytes[6]! & 0x0f) | 0x40;
  bytes[8] = (bytes[8]! & 0x3f) | 0x80;
  const hex = Array.from(bytes, (b) => b.toString(16).padStart(2, '0')).join('');
  return `${hex.slice(0, 8)}-${hex.slice(8, 12)}-${hex.slice(12, 16)}-${hex.slice(16, 20)}-${hex.slice(20)}`;
}

/** The current draft's key and `renew()`, to call after a successful save. */
export function useIdempotencyKey(): { key: string; renew: () => void } {
  const [key, setKey] = useState(newIdempotencyKey);
  const renew = useCallback(() => setKey(newIdempotencyKey()), []);
  return { key, renew };
}
