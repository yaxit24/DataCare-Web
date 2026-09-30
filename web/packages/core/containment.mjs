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
 *
 * DISCHARGED — `tag-cancel` and `tag-transfer` (N18, cards X19 and X18), each against its own exit gate.
 *
 * Both menus open the desktop form TR_TAG_CAN on a book of their own MAIN_BOOK, so one writer serves both
 * (`apps/api/src/modules/stock/tagCancel.ts`); the contract is
 * `parity-plan-2026-09-10/evidence/implementation-2026-09-29-n18/contract.md`. Evidence for the gate clauses:
 *   • exact live identity — every tag line resolves through the sale's resolver (`issueTagTx`): company,
 *     location, TAG_NO and VCH_SRNO with a positive signed balance; two live instances without a serial are
 *     refused, another location's tag and a sold tag are "not available" (tagCancelLifecycle.db.test.ts V4-V6)
 *   • full detail and lineage — BAR_CAN_DATA / DETL / IDTL carry exactly the desktop's columns, the tag's
 *     stones are copied from its own BAR_IDTL rows, and the source BAR_DETL / BAR_IDTL / image index are
 *     byte-identical after cancel, edit and delete (V1, V3, V11; full-database diff)
 *   • lifecycle / locks / reversal — list, read, edit and delete, with TEMP_BOOK_DATA, DM_DATA and the
 *     desktop DELETE_DATA rows; every touched tag is locked in sorted order, a concurrent sale of the same tag
 *     loses cleanly, and a failure part-way leaves nothing (V2, V3, V7, V8)
 *   • transfer conservation — the tag's '-' row and the loose item's '+' row carry the same pieces, weights
 *     and fine (T1-T4)
 *   • desktop database diff — derived from the source; no desktop BAR_CAN_* rows were ever captured, so the
 *     cards stay open until a desktop replay and business acceptance.
 * Merging this change is the release decision for both operations.
 *
 * DISCHARGED — `tag-split` (N19, card X20), against its exit gate ("atomic parent consume, child identity /
 * detail / image creation, conservation, lifecycle, locks, and desktop database diff", P0-05/WP-09).
 *
 * The desktop form TR_TAG_SPLIT consumes one or more parent tags and creates child tags, conserving metal; one
 * writer (`apps/api/src/modules/stock/tagSplit.ts`) implements it; the contract is
 * `parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md`. Evidence for the gate clauses:
 *   • atomic parent consume — each parent resolves through the shared resolver (`issueTagTx`) under a sorted tag
 *     lock and leaves stock; a sold or ambiguous parent is refused; a failure part-way leaves nothing
 *     (tagSplitLifecycle.db.test.ts V6, V8, V10; full-database diff)
 *   • child identity and detail — every child gets an allocated TAG_NO / VCH_SRNO / SRNO_MAST row and a full
 *     BAR_DETL / BAR_IDTL record, so it is a real, sellable tag (V1); the register is LBR_DATA / ISU_DETL /
 *     ISU_IDTL / REC_DETL and MAIN_STOCK is built by Tag_Split_Stk (parent '-', child '+')
 *   • conservation — the child net total equals the parent net total, or the difference posts the Tag_Split_Ledr
 *     absorption legs against a configured account; a difference with no account is refused (V1, V2, V3)
 *   • image lineage — each child copies the parent's TAG image; the parent's own image is never modified (V1)
 *   • lifecycle / locks / reversal — list, read, edit and delete, with TEMP_BOOK_DATA and the desktop
 *     DELETE_DATA audit; a child that was sold or split again blocks the edit and the delete (V4, V5, V7)
 *   • desktop database diff — derived from the source; no desktop TAG SPLIT rows were ever captured, so the card
 *     stays open until a desktop replay and business acceptance.
 * Merging this change is the release decision.
 */
export const parityContainmentOperations = Object.freeze([
  'logical-restore',
  'production-cutover-load',
  'tag-weight-difference',
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
  'tag-weight-difference': rule(
    'tag-weight-difference',
    'Tag Weight Difference mutation',
    'The current path is a simplified net adjustment and omits desktop tag replacement, barcode detail, image, Rojmel, serial, and karigar branches.',
    'Use tag lookup for inspection only; perform weight change in the desktop application until every desktop branch is certified.',
    'P0-05/WP-09: complete branch matrix, configured accounts, lifecycle/locks/reversal, and desktop database diff.',
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
