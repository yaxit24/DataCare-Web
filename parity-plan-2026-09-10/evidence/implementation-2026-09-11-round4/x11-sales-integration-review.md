# Round4 independent Design → Sales integration review

Reviewed against `TR_SALE_ORD.cs:7307–7373`, calculation block6732–6874, load8711/8714/8716, save9217–9250 and9297. This is a read review of the shared in-progress tree; final source hashes and executable results are recorded in the final manifest.

## Confirmed integration properties

- The Sales page invokes the dedicated picker only from its Design field/button. F1 prevents the browser help default and grid propagation. The picker lives outside the editor form and has its own search form.
- Native dialog cancellation does not call onSelect; cleanup restores the invoking row's Design input. The page stores that ref by stable clientKey, not a shifting row array position. This is the deliberate web preservation behavior, not a claim of desktop Escape equivalence; see the correction below.
- Selection context binds current company/branch/year/book, row key and item. The page verifies that context before applying a returned selection. Preview additionally requires matching current Design number and image identifier.
- Saved E status derives from a matching persisted parent serial in the loaded original document. A newly appended parent in a loaded document remains A.
- The pure selection helper changes only the exact source-defined fields. The page preserves component objects and parent client identity, and its component editor preserves existing child serials.
- The source selector service binds tenant/company/item/product and complete saved Design identity/version. It resolves source values inside the writer transaction with SHARE locks. Authorized read/preview routes validate a configured ordinary Sales book in their own repeatable-read snapshot.
- The API boundary sets `requireDesignSelection` itself; the source-reference requirement is not a user-selectable flag.

## Findings addressed during implementation

The first Sales helper retained empty computed display cells on a new row. Its generic Tour total renderer consequently derived a new amount immediately from F1's copied Touch/West/Labour defaults. That contradicted the desktop's copy-without-CommPassTotal behavior. The current helper initializes explicit new cached totals, keeps F1 separate, and returns the cached line amount. Real numeric blur commits update that calculation state.

The first trigger model compared the visible selected labour rate/percentage with the focused cell value. F1 leaves hidden caches84/85/86 unchanged, so that comparison could miss the next actual trigger. A separate shared `orderLabourWithCache` helper now executes the exact ordered amount→percentage→rate comparison block. It returns the block's actual cache writes, including intentionally unchanged85 after the rate branch. UI and API integrate the same helper.

An initial concern about exceptions inside the page's `setRows` callback was retracted after inspecting the actual wrapper. `setRows` synchronously evaluates against `rowsRef.current` before passing a finished array to React, so its caller's try/catch catches validation errors. It is not a deferred React state updater. The real journey still asserts no unhandled page errors around an invalid draft and F1.

## Final-run verification

The first actual combined browser run failed its forward Tab-containment assertion. The failure screenshot shows a readable modal with all eleven columns/actions inside its bounds; native modality allowed keyboard focus to wrap into browser chrome. The owned picker now explicitly cycles visible enabled controls in both directions, and the journey checks twenty forward plus twenty backward moves. Focus lint/web types pass; the first failed run remains at `browser-first.txt` and `web/test-results/parity-real-stack-round4-first`. Final rebuilt-browser verification passed at `browser-blank-source.txt`.

The dedicated journey passed actual picker/search/preview/cancel, invalid draft preservation, POST/reopen, E selection/PUT/reopen, unchanged cached amounts and component identities, clear, and additional source-blank create/edit persistence. Its fixture source has duplicate displayed Design numbers with distinct albums/source serials and both nonzero and zero defaults. Four final screenshots were reviewed: modal bounds, complete portrait, readable source/action columns and Design focus passed. The absent-image panels are below the captured viewports; their absence proof comes from explicit real DOM/API assertions.

The API source-copy call translates the shared helper's unsupported decimal precision exception to a client validation response, retaining the order transaction and draft. The source version and defaults cannot be bypassed by a direct non-N image identifier change without the required selection event. These error paths were reviewed with the API owner and covered by its integration checks before final freeze.

A subsequent read review caught another complete-path gap: a source NULL image correctly became an empty draft cell in the core helper, but generic payload text normalization omitted it. The writer's omission fallback could then restore the old persisted photo (or N on a new row). Separately, a nullable source ID failed the page's exact source-preview comparison against its copied empty cell, and the saved-photo panel could continue showing the old photo while a new source selection was pending. API/UI owners corrected explicit source text intent, authoritative replay persistence, normalized preview context and pending-image action guards. The extended actual journey uses source B with SQL NULL DESIGN_IMG_ID and tests both new POST and existing-photo replacement PUT. It requires the returned saved field exactly empty string, immediate absent source preview, no old saved photo, exact source identity and unchanged parent/components. These checks passed in the final eleven-check `parity-real-stack-round4-blank-source` result; earlier ten-check passes are retained but do not certify the newly added path.

This review does not certify the later source total/MRP/tax chain, runtime-specific binary-double midpoint behavior, transferred desktop filesystem images, or complete module/business acceptance.

Read-only follow-up source scoping found further shared-help commands in `MS_HELP.cs:2148–2280`: grid Up/Down navigation, Left/Right search-column selection/reset, current-row Enter, Backspace search editing, and F1 create/sub-create flags. The current accessible modal's Tab/Enter/Escape and explicit multi-field search do not establish parity with that full shared help command set. No additional product edits are introduced while the combined round4 browser run is being prepared.

## Correction: shared-help Escape versus HelpClose

`TR_SALE_ORD:7337–7340` only proves that HelpClose=true returns unchanged. Deeper `MS_HELP` tracing shows Load1058 resets HelpClose=false;1235 initializes a blank ColValue array; Escape2236–2238 only closes; Closed2388–2392 does not set HelpClose. Enter with zero rows explicitly sets HelpClose=true at2202. The alternate desktop extraction agrees. Ordinary Escape therefore appears to enter the caller's empty-selection branch7366–7370 and clear Design/imageN. The current web's draft-preserving Escape is an intentional loss-prevention difference pending desktop execution/business acceptance. The frozen round3 next-contract's broader cancellation assumption is superseded by this finding and retained as historical evidence, not silently rewritten. Root and the Sales UI owner were notified before final freeze.
