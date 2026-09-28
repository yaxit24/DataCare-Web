export const PARITY_CONTAINMENT_CODE = 'PARITY_CONTAINMENT';
export const PARITY_CONTAINMENT_WORK_PACKAGE = 'WP-01';

/**
 * DISCHARGED — `tag-opening-update`, released after its exit gate was satisfied.
 *
 * The gate asked for "symmetric create/get/update contract and unchanged rich-tag/image desktop
 * differential" (P0-06/WP-08). Evidence, all in `apps/api/test/tagOpeningRoundTrip.db.test.ts`:
 *   • reopen returns every field the writer accepts — the reader went from 22 of 65 fields to all 65
 *   • the ENTIRE persisted BAR_DETL row (>60 columns) is byte-identical across reopen-and-save
 *   • BAR_IDTL sub-detail is byte-identical too, which was an assumption until it became an assertion
 *   • tag identity (TAG_NO + VCH_SRNO) and its MAIN_STOCK movement survive the round trip
 *   • hallmark ids stay text, so an alphanumeric HUID is preserved
 * `designImageId` is inside the asserted fixture, so image association is covered. Each assertion was
 * fail-proofed: blanking the reader's `pcs` made the sub-detail check name IT_PCS.
 *
 * The page-side half was fixed too: tag-opening sent `Number(hallmarkId2)`, so any HUID containing a
 * letter became NaN and was dropped on every save. `apps/web/test/textIdentifiers.test.ts` now forbids
 * Number() on nine string-typed identifiers across every transaction page.
 *
 * The remaining six rules stay blocked. Releasing this one does not weaken them, and the registry still
 * has intentionally no environment override.
 */
export const parityContainmentOperations = Object.freeze([
  'logical-restore',
  'production-cutover-load',
  'tag-transfer',
  'tag-cancel',
  'tag-weight-difference',
  'tag-split',
]);

const rule = (operation, title, reason, safeAlternative, exitGate) =>
  Object.freeze({
    operation,
    blocked: true,
    title,
    reason,
    safeAlternative,
    exitGate,
    workPackage: PARITY_CONTAINMENT_WORK_PACKAGE,
  });

/**
 * Fail-closed parity containment registry.
 *
 * There is intentionally no environment override. Re-enabling an operation requires a reviewed code
 * change that cites the desktop-differential and safety evidence satisfying its exit gate.
 */
export const parityContainmentRules = Object.freeze({
  'logical-restore': rule(
    'logical-restore',
    'Logical company restore',
    'The v2 company-scoped restore has passed WP-02A engineering verification, but destructive logical restore remains disabled pending explicit operator release authorization and a controlled post-deploy drill.',
    'Continue using the verified physical database recovery procedure. Retain v2 JSON backups as integrity-checked artifacts, but do not invoke logical restore until this containment rule is explicitly lifted.',
    'P0-01 engineering gate passed in WP-02A; release still requires migrate-deploy confirmation, a green /ready probe, an authorized controlled drill, and an explicit containment-policy change.',
  ),
  'production-cutover-load': rule(
    'production-cutover-load',
    'Production migration load',
    'The current loader uses a partial table list, unscoped source extraction, tenant-wide replacement, and false-pass statuses for missing or skipped data.',
    'Run only --dry-run diagnostics. Use no production load until the scope-safe shadow-load pipeline is independently certified.',
    'P0-08/WP-14A: signed ownership manifest, completeness-failing validation, two-company/two-year isolation, and two clean shadow loads.',
  ),
  'tag-transfer': rule(
    'tag-transfer',
    'Tag Transfer mutation',
    'The current transfer does not preserve exact VCH_SRNO identity and lacks the desktop open/edit/lineage and shared-lock behavior.',
    'Use tag lookup for inspection only; perform the business operation in the desktop application until the exact web lifecycle is certified.',
    'P0-05/WP-09: exact identity, full lifecycle, conservation, concurrency, reversal, and desktop database diff.',
  ),
  'tag-cancel': rule(
    'tag-cancel',
    'Tag Cancellation mutation',
    'The current cancel path can resolve historical availability instead of one live serial identity and omits required source and sub-detail lineage.',
    'Use tag lookup for inspection only; perform cancellation in the desktop application until the exact web lifecycle is certified.',
    'P0-05/WP-09: exact live identity, full cancel detail, lifecycle/locks/reversal, and desktop database diff.',
  ),
  'tag-weight-difference': rule(
    'tag-weight-difference',
    'Tag Weight Difference mutation',
    'The current path is a simplified net adjustment and omits desktop tag replacement, barcode detail, image, Rojmel, serial, and karigar branches.',
    'Use tag lookup for inspection only; perform weight change in the desktop application until every desktop branch is certified.',
    'P0-05/WP-09: complete branch matrix, configured accounts, lifecycle/locks/reversal, and desktop database diff.',
  ),
  'tag-split': rule(
    'tag-split',
    'Tag Split mutation',
    'The current split writes stock movements only; it does not allocate child serials or create barcode detail, sub-detail, image, and parent-child lineage.',
    'Use parent tag lookup for inspection only; perform splitting in the desktop application until exact child creation is certified.',
    'P0-05/WP-09: atomic parent consume, child identity/detail/image creation, conservation, lifecycle, locks, and desktop database diff.',
  ),
});

export function parityContainmentRule(operation) {
  const found = parityContainmentRules[operation];
  if (!found) throw new TypeError(`Unknown parity containment operation: ${String(operation)}`);
  return found;
}

export function parityContainmentMessage(operation) {
  const found = parityContainmentRule(operation);
  return `${found.title} is disabled by the ${found.workPackage} parity safety gate.`;
}

export function parityContainmentProblem(operation) {
  const found = parityContainmentRule(operation);
  if (!found.blocked) return null;
  return Object.freeze({
    statusCode: 503,
    body: Object.freeze({
      error: 'parity-containment',
      code: PARITY_CONTAINMENT_CODE,
      operation: found.operation,
      message: parityContainmentMessage(operation),
      reason: found.reason,
      safeAlternative: found.safeAlternative,
      exitGate: found.exitGate,
      workPackage: found.workPackage,
      retryable: false,
    }),
  });
}
