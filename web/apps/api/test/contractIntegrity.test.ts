import { readFileSync, readdirSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  auditContracts,
  citationsIn,
  parseTables,
  vectorCandidates,
  type ContractAuditContext,
  type ContractInput,
} from '../src/modules/ops/contractIntegrity.js';

/**
 * WP-05 — a contract must be checkable, and its citations must be real.
 *
 * The contracts are the project's stated source of truth above the code ("approved behavior contracts; drafts
 * are research, not approval"). Nothing checked them: a draft carrying 33 blank vector cells could be flipped
 * to `approved` and immediately count as G2 evidence, and a rule could cite a desktop line that does not exist.
 *
 * These tests prove each rule with a synthetic contract, then run the rules against the 11 real contracts and
 * the 204 real desktop sources — because a gate whose own behaviour is only asserted on fixtures is the same
 * unproven artefact it is meant to replace.
 */

const here = dirname(fileURLToPath(import.meta.url));
const repoRoot = resolve(here, '../../../..');
const contractsDir = resolve(repoRoot, 'project-memory/contracts');
const desktopDir = resolve(repoRoot, 'unified/src/csharp/DataCareNext');

const realContracts: ContractInput[] = readdirSync(contractsDir)
  .filter((n) => n.endsWith('.contract.md'))
  .sort()
  .map((name) => ({ name, text: readFileSync(resolve(contractsDir, name), 'utf8') }));

const desktopLineCounts: Record<string, number> = {};
for (const name of readdirSync(desktopDir).filter((n) => n.endsWith('.cs'))) {
  desktopLineCounts[name.replace(/\.cs$/, '')] = readFileSync(
    resolve(desktopDir, name),
    'utf8',
  ).split('\n').length;
}
const definedVectorIds = new Set(
  [
    ...readFileSync(resolve(repoRoot, 'web/apps/api/test/goldenVectors.test.ts'), 'utf8').matchAll(
      /GV-[A-Z0-9]+-\d+/g,
    ),
  ].map((m) => m[0] as string),
);

/** Ceilings mirroring scripts/check-contracts.mjs. Kept here so a drift breaks a test, not just a script. */
const DEBT_CEILING = { notEnforced: 28, blankVector: 184, blankTest: 0 };
const ctx: ContractAuditContext = {
  desktopLineCounts,
  definedVectorIds,
  debtCeiling: DEBT_CEILING,
};
/** A context with ceilings high enough that only the rule under test can fail. */
const loose: ContractAuditContext = {
  ...ctx,
  debtCeiling: { notEnforced: 1e6, blankVector: 1e6, blankTest: 1e6 },
};

const blocking = (files: ContractInput[], context = loose): string[] =>
  auditContracts(files, context)
    .findings.filter((f) => f.severity === 'blocking')
    .map((f) => f.rule);

const contract = (body: string, name = 'TR_SALE.contract.md'): ContractInput => ({
  name,
  text: body,
});

describe('contract parsing handles both real table shapes', () => {
  it('reads a generated draft table and a hand-authored one', () => {
    const tables = parseTables(
      [
        '| Desktop message (verbatim) | Status | Web implementation | Test |',
        '|---|---|---|---|',
        '| `Boom` | NOT ENFORCED |  |  |',
        '',
        '| Rule | Citation | Behaviour |',
        '|---|---|---|',
        '| Numbering | `TR_SALE.cs:10` | MAX+1 |',
      ].join('\n'),
    );
    expect(tables).toHaveLength(2);
    expect(tables[0]!.rows).toHaveLength(1);
    expect(tables[1]!.header).toEqual(['rule', 'citation', 'behaviour']);
  });

  it('reads both the full and the shorthand citation form', () => {
    // Hand-authored contracts name the file once and then cite `:4207`. Reading only the full form skipped
    // exactly the citations the reference approved contract relies on most.
    const found = citationsIn(
      'sees `TR_MLT_PRO.cs:3875` and later `:4207` and `:4267`',
      'TR_MLT_PRO',
    );
    expect(found).toEqual([
      { form: 'TR_MLT_PRO', line: 3875 },
      { form: 'TR_MLT_PRO', line: 4207 },
      { form: 'TR_MLT_PRO', line: 4267 },
    ]);
  });
});

describe('contract integrity rules', () => {
  it('requires a filename naming a real desktop form', () => {
    expect(blocking([contract('Status: draft\n', 'notes.md')])).toContain('filename');
    expect(blocking([contract('Status: draft\n', 'TR_NOT_A_FORM.contract.md')])).toContain(
      'desktop-form-exists',
    );
  });

  it('requires exactly one status line', () => {
    expect(blocking([contract('no status here\n')])).toContain('status-line');
    expect(blocking([contract('Status: draft\nStatus: approved\n')])).toContain('status-line');
  });

  it('rejects a citation to a line that does not exist', () => {
    const real = desktopLineCounts.TR_SALE!;
    expect(blocking([contract(`Status: draft\n\nsee \`TR_SALE.cs:${real + 500}\`\n`)])).toContain(
      'citation-resolves',
    );
    expect(blocking([contract('Status: draft\n\nsee `TR_GHOST.cs:12`\n')])).toContain(
      'citation-resolves',
    );
    expect(blocking([contract(`Status: draft\n\nsee \`TR_SALE.cs:${real - 1}\`\n`)])).toEqual([]);
  });

  it('rejects a citation to a golden vector nobody wrote', () => {
    expect(blocking([contract('Status: draft\n\npinned by `GV-NOPE-999`\n')])).toContain(
      'vector-exists',
    );
    const realId = [...definedVectorIds][0]!;
    expect(blocking([contract(`Status: draft\n\npinned by \`${realId}\`\n`)])).toEqual([]);
  });

  it('refuses approval while a desktop validation is unenforced', () => {
    const body = [
      'Status: approved',
      '',
      '| Desktop message (verbatim) | Status | Web implementation | Test |',
      '|---|---|---|---|',
      '| `Boom` | NOT ENFORCED |  |  |',
    ].join('\n');
    expect(blocking([contract(body)])).toContain('approved-has-no-unenforced-rule');
  });

  it('refuses approval while a computed cell has no vector', () => {
    const body = [
      'Status: approved',
      '',
      '| Desktop cell | Grid | Control | Persisted column | Web writes column | Vector |',
      '|---|---|---|---|---|---|',
      '| `MSG[1]` | main | `cFine` | `ITM_FINE` | yes |  |',
    ].join('\n');
    expect(blocking([contract(body)])).toContain('approved-has-no-blank-vector');
  });

  it('accepts a waived row with a reason and refuses one without', () => {
    // "implemented + test OR waived with a reason" is the contracts' own rule, so a waiver needs the reason,
    // not a test. Demanding a test from a licence-tier gate made the gate wrong about the reference contracts.
    const withReason = [
      'Status: approved',
      '',
      '| Desktop message (verbatim) | Status | Disposition / web implementation | Test |',
      '|---|---|---|---|',
      '| `Upgrade your edition` | WAIVED | desktop licence tiering; the web has none |  |',
    ].join('\n');
    expect(blocking([contract(withReason)])).toEqual([]);

    const withoutReason = withReason.replace('desktop licence tiering; the web has none', '');
    expect(blocking([contract(withoutReason)])).toContain('waiver-carries-reason');
  });

  it('requires an enforced row to cite a test', () => {
    const body = [
      'Status: approved',
      '',
      '| Desktop message (verbatim) | Status | Web implementation | Test |',
      '|---|---|---|---|',
      '| `Boom` | ENFORCED | `x.ts:1` |  |',
    ].join('\n');
    // Counted as blankTest debt, and blocked by the zero ceiling the real repository now holds.
    expect(auditContracts([contract(body)], loose).totals.blankTest).toBe(1);
    expect(blocking([contract(body)], ctx)).toContain('debt-ratchet');
  });

  it('requires every hand-authored rule to cite its source', () => {
    const body = [
      'Status: approved',
      '',
      '| Rule | Citation | Behaviour |',
      '|---|---|---|',
      '| Numbering |  | MAX+1 |',
    ].join('\n');
    expect(blocking([contract(body)])).toContain('authored-rule-cites-source');
  });

  it('refuses an approved contract that asserts nothing at all', () => {
    expect(blocking([contract('Status: approved\n\nLooks official.\n')])).toContain(
      'approved-asserts-something',
    );
  });

  it('ratchets debt so it can only shrink', () => {
    const body = [
      'Status: draft',
      '',
      '| Desktop message (verbatim) | Status | Web implementation | Test |',
      '|---|---|---|---|',
      '| `Boom` | NOT ENFORCED |  |  |',
    ].join('\n');
    const tight: ContractAuditContext = {
      ...ctx,
      debtCeiling: { notEnforced: 0, blankVector: 0, blankTest: 0 },
    };
    expect(blocking([contract(body)], tight)).toContain('debt-ratchet');
    expect(blocking([contract(body)], loose)).toEqual([]);
  });
});

describe('the 11 real contracts', () => {
  const report = auditContracts(realContracts, ctx);

  it('passes the gate: every citation resolves and no approval hides an open cell', () => {
    const failures = report.findings.filter((f) => f.severity === 'blocking');
    expect(failures.map((f) => `${f.contract}: [${f.rule}] ${f.detail}`)).toEqual([]);
    expect(report.verdict).toBe('ok');
  });

  it('holds the measured state, so a regression shows up as a number', () => {
    expect(report.totals).toMatchObject({
      contracts: 11,
      approved: 3,
      draft: 8,
      // 37 validation rows: 28 NOT ENFORCED, 5 WAIVED, 2 UI-LEVEL, 2 ENFORCED.
      validations: 37,
      notEnforced: 28,
      computed: 248,
      blankVector: 184,
      // Zero, not the 37 previously reported: every test-less row is waived or unenforced, both counted
      // elsewhere. The old figure came from a parser that could not tell the two table shapes apart.
      blankTest: 0,
    });
  });

  it('resolves all 12 desktop line citations against the real sources', () => {
    // Only the hand-authored reference contract carries line citations, and all of them land inside a
    // 5,243-line file. The generated contracts cite by verbatim message and grid cell instead, which the audit
    // records as debt rather than blocking.
    expect(report.totals.citations).toBe(12);
    const citationDebt = report.findings.filter((f) => f.rule === 'approved-cites-desktop-line');
    expect(citationDebt.map((f) => f.contract)).toEqual([
      'TR_PURC.contract.md',
      'TR_SALE.contract.md',
    ]);
  });

  it('offers 99 vector links with an approved precedent, and applies none of them', () => {
    const candidates = vectorCandidates(realContracts);
    expect(candidates).toHaveLength(99);
    // Every candidate must come from a contract the owner approved, and name a vector that exists.
    for (const c of candidates) {
      expect(['TR_SALE.contract.md', 'TR_PURC.contract.md', 'TR_MLT_PRO.contract.md']).toContain(
        c.precedent,
      );
      expect(definedVectorIds.has(c.vector), `${c.vector}`).toBe(true);
    }
    // And they are candidates only: the drafts still carry their blanks, because a filled Vector cell asserts
    // the formula is pinned and the retained audits do not record the desktop expression to prove it.
    expect(report.totals.blankVector).toBe(184);
  });
});
