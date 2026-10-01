# ADR-0004 — Two-phase delivery: desktop parity first, then the SaaS product

- **Status:** Accepted
- **Date:** 2026-10-01
- **Plan reference:** decision D25 in `docs/master-parity-plan-2026-09-29/12-lineage-verification-2026-10-01.md`

## Context
The programme has two goals that pull in different directions. Existing DataCareNext customers need the web
version to behave like the desktop: the same modules, workflows, forms, prints and business results, so they can
move without retraining and without accounting differences. The product owner also wants to sell the web version to
many jewellery businesses as an online service, which needs a super admin, plans and billing, tenant isolation
beyond the database, managed operations and a maintainable codebase.

Doing both at once risks two failures: SaaS refactoring silently changing desktop-equivalent calculations, and
desktop habits that are unsafe online (local drive backups, machine registration, global tiles, destructive
utilities) being reproduced as-is.

## Decision
1. **Phase 1 — the desktop, in the web.** Reproduce every in-scope desktop menu, workflow, form, print and business
   rule across database, API and UI, with the same write sets, calculations and report data. Layout parity is
   semantic (D20). Desktop weaknesses are not ported (document 08: string-built SQL, plaintext passwords,
   process-wide state, unscoped deletes, partial writes, online machine translation). Phase 1 ends with the release
   certificate of document 11 (N82).
2. **Phase 2 — the SaaS product.** Build the platform control plane, commercial model, cloud operations, compliance
   and scale on top of the certified Phase 1 candidate (`docs/master-parity-plan-2026-09-29/14-phase2-saas-plan.md`).
3. **SaaS workflow changes are flagged.** A Phase 2 change to an operator workflow ships behind a per-tenant flag
   that defaults to desktop behaviour for migrated tenants. No flag may change an accounting, stock or tax result;
   a result change needs its own versioned, effective-dated decision.
4. **Parity stays a gate.** The Phase 1 golden vectors, write-set database tests, zero-mock journeys and desktop
   differential remain blocking for every Phase 2 change.
5. **Two kinds of preparation start in Phase 1** because delaying them makes Phase 2 harder: maintainability
   boundaries (N88: route plugins, error taxonomy, shared voucher editor, size budgets) and a supported runtime
   (N86).

## Consequences
- Phase 2 product work (super admin, billing, onboarding) does not start before the Phase 1 pilot scope is
  certified, except the two preparations above and decisions (milestone M0).
- Reviews can ask one question of every change: does it keep desktop-equivalent results?
- Some desktop utilities are implemented twice: a faithful Phase 1 version for migrated customers and a managed
  Phase 2 replacement behind a flag (SP21).
