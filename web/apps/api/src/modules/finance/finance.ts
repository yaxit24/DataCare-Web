/**
 * The finance vouchers' public surface. The TR_CASH writers and readers (cash and bank receipts and payments)
 * live in `cashBank.ts`, where all four menus share one write path; the Contra grid (TR_CONTRA) lives in
 * `contra.ts`. Callers keep importing from here.
 */
export * from './cashBank.js';

// Contra Entry lives in contra.ts (the desktop TR_CONTRA grid); re-exported for existing callers.
export { postContra, getContra, editContra, deleteContra, type ContraInput } from './contra.js';
