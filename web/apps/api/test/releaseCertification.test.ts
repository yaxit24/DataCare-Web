import { createHash } from 'node:crypto';
import { existsSync, readFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  certify,
  contextProblems,
  evaluateGate,
  RELEASE_GATES,
  REQUIRED_G5_COMPARISON_CASE_IDS,
  REQUIRED_REAL_BROWSER_JOURNEY_IDS,
  REQUIRED_REPORT_COMPARISON_IDS,
  requirementSetFingerprint,
  requirementSetProblems,
  type CertificationContext,
  type GateObservation,
  type GateRequirement,
} from '../src/modules/ops/releaseCertification.js';

/**
 * P0-07 / WP-03 — the release gate must refuse RED, SKIP, stale, synthetic and missing evidence.
 *
 * The exit criterion is a negative one: "protected release job CANNOT succeed on RED, SKIP, stale, synthetic
 * or missing evidence." A test that only proves the happy path would leave every one of those five words
 * unverified, so each has its own case here, driven through the same public entry point the runner uses.
 *
 * The last block runs the rules against the repository's ACTUAL retained evidence. That is the part which
 * makes this more than a unit test: it demonstrates the gate is red today for the reasons the plan says it
 * should be, rather than red because a fixture was written to make it red.
 */

const here = dirname(fileURLToPath(import.meta.url));
// Evidence and active GitHub workflows are relative to the repository root — the directory that holds both
// `web/` and `project-memory/` — while gate COMMANDS run inside `web/`. From this test that is four levels up.
const repoRoot = resolve(here, '../../../..');
const SHA = 'a'.repeat(40);
const CERTIFIER_SOURCE_SHA = 'd'.repeat(64);
const NOW = new Date('2026-08-30T10:00:00.000Z');

const ctx: CertificationContext = {
  releaseSha: SHA,
  freshnessWindowHours: 24,
  approvedRequirementSetHash: 'c'.repeat(64),
  certifierSourceSha256: CERTIFIER_SOURCE_SHA,
  now: NOW,
};

const commandGate: GateRequirement = {
  id: 'example',
  title: 'Example command gate',
  because: 'test',
  command: 'pnpm example',
};

const ok = (over: Partial<GateObservation> = {}): GateObservation => ({
  id: 'example',
  command: 'pnpm example',
  exitCode: 0,
  stdout: 'EXAMPLE_OK',
  stderr: '',
  ...over,
});

describe('release certification: run setup', () => {
  it('refuses to judge anything without the release commit', () => {
    for (const releaseSha of [undefined, '', 'HEAD', 'abc123', `${'a'.repeat(39)}z`]) {
      const v = evaluateGate(commandGate, ok(), { ...ctx, releaseSha });
      expect(v.outcome, String(releaseSha)).toBe('unconfigured');
      expect(v.reason).toContain('release commit');
    }
    expect(evaluateGate(commandGate, ok(), { ...ctx, releaseSha: SHA.toUpperCase() }).outcome).toBe(
      'passed',
    );
  });

  it('refuses to invent a freshness window, because it is an owner decision', () => {
    for (const freshnessWindowHours of [undefined, 0, -1, Number.NaN, Number.POSITIVE_INFINITY]) {
      const v = evaluateGate(commandGate, ok(), { ...ctx, freshnessWindowHours });
      expect(v.outcome, String(freshnessWindowHours)).toBe('unconfigured');
      expect(v.reason).toMatch(/freshness window/);
    }
  });

  it('refuses a missing or malformed owner-approved requirement-set digest', () => {
    for (const approvedRequirementSetHash of [
      undefined,
      '',
      'candidate-decides',
      'a'.repeat(63),
      `${'a'.repeat(63)}z`,
    ]) {
      const candidate = { ...ctx, approvedRequirementSetHash };
      const verdict = evaluateGate(commandGate, ok(), candidate);
      expect(verdict.outcome, String(approvedRequirementSetHash)).toBe('unconfigured');
      expect(verdict.reason).toContain('approved requirement-set hash');
      expect(contextProblems(candidate).join('\n')).toContain('RELEASE_REQUIREMENT_SET_SHA256');
    }
    expect(
      evaluateGate(commandGate, ok(), {
        ...ctx,
        approvedRequirementSetHash: 'C'.repeat(64),
      }).outcome,
    ).toBe('passed');
  });

  it('refuses to evaluate gates without a candidate decision-rule source digest', () => {
    for (const certifierSourceSha256 of [undefined, '', 'not-a-digest', 'a'.repeat(63)]) {
      const candidate = { ...ctx, certifierSourceSha256 };
      const verdict = evaluateGate(commandGate, ok(), candidate);
      expect(verdict.outcome, String(certifierSourceSha256)).toBe('unconfigured');
      expect(verdict.reason).toContain('certifier source digest');
      expect(contextProblems(candidate).join('\n')).toContain('decision rules');
    }
  });
});

describe('release certification: what a command did', () => {
  it('passes a gate that ran and said nothing', () => {
    expect(evaluateGate(commandGate, ok(), ctx).outcome).toBe('passed');
  });

  it('fails a non-zero exit', () => {
    const v = evaluateGate(commandGate, ok({ exitCode: 1 }), ctx);
    expect(v.outcome).toBe('failed');
    expect(v.reason).toContain('exited 1');
  });

  it('treats a gate that never ran as missing rather than as passing', () => {
    const v = evaluateGate(commandGate, undefined, ctx);
    expect(v.outcome).toBe('missing');
  });

  it('refuses SKIP even though the gate exited 0', () => {
    // The three real emitters, plus the shape so a new one is caught the day it is written.
    for (const token of [
      'SCHEMA_READINESS_SKIP',
      'TYPE_PARITY_SKIP',
      'FRESH_PROVISION_SKIP',
      'SOME_FUTURE_GATE_SKIP',
    ]) {
      const v = evaluateGate(commandGate, ok({ stdout: `note\n${token}\n` }), ctx);
      expect(v.outcome, token).toBe('skipped');
      expect(v.reason).toContain(token);
    }
    // Also when it is only on stderr.
    expect(evaluateGate(commandGate, ok({ stderr: 'TYPE_PARITY_SKIP' }), ctx).outcome).toBe(
      'skipped',
    );
  });

  it('does not mistake ordinary output for a skip', () => {
    for (const line of ['TYPE_PARITY_OK', 'skipped 3 planned citations', 'REGISTER_OK']) {
      expect(evaluateGate(commandGate, ok({ stdout: line }), ctx).outcome, line).toBe('passed');
    }
  });

  it('refuses a gate invoked in its own self-approving mode', () => {
    const v = evaluateGate(commandGate, ok({ command: 'node scripts/x.mjs --write' }), ctx);
    expect(v.outcome).toBe('self-approved');
    expect(v.reason).toContain('--write');
  });

  it('treats the runner-owned postflight observation as a required executable check', () => {
    const gate: GateRequirement = {
      id: 'candidate-identity-postflight',
      title: 'Candidate identity postflight',
      because: 'test the internal runner observation contract',
      runnerCheck: 'candidate-identity-postflight',
    };
    expect(
      evaluateGate(gate, { id: gate.id, exitCode: 0, stdout: 'POSTFLIGHT_OK' }, ctx).outcome,
    ).toBe('passed');
    const failed = evaluateGate(
      gate,
      { id: gate.id, exitCode: 1, stderr: 'candidate checkout changed' },
      ctx,
    );
    expect(failed.outcome).toBe('failed');
    expect(failed.reason).toContain('candidate checkout changed');
    expect(evaluateGate(gate, undefined, ctx).outcome).toBe('missing');
  });
});

const evidenceGate: GateRequirement = {
  id: 'evidence',
  title: 'Example evidence gate',
  because: 'test',
  evidence: {
    path: 'project-memory/example.json',
    timestampField: 'comparedAt',
    provenance: (json) =>
      json.engine === 'sqlserver' ? { ok: true } : { ok: false, reason: 'not a real capture' },
    positive: (json) =>
      json.matched === true ? { ok: true } : { ok: false, reason: 'matched != true' },
  },
};

const evidence = (json: Record<string, unknown> | undefined): GateObservation => ({
  id: 'evidence',
  artefact: {
    path: 'project-memory/example.json',
    present: json !== undefined,
    json,
  },
});

const goodEvidence = {
  engine: 'sqlserver',
  matched: true,
  comparedAt: '2026-08-30T09:00:00.000Z',
  releaseSha: SHA,
};

describe('release certification: what the evidence says', () => {
  it('passes evidence that is real, positive, attributable and fresh', () => {
    expect(evaluateGate(evidenceGate, evidence(goodEvidence), ctx).outcome).toBe('passed');
  });

  it('refuses missing or unreadable evidence', () => {
    expect(evaluateGate(evidenceGate, evidence(undefined), ctx).outcome).toBe('missing');
    expect(
      evaluateGate(
        evidenceGate,
        { id: 'evidence', artefact: { path: 'x', present: true, json: 'not an object' } },
        ctx,
      ).outcome,
    ).toBe('missing');
  });

  it('refuses RED evidence', () => {
    const v = evaluateGate(evidenceGate, evidence({ ...goodEvidence, matched: false }), ctx);
    expect(v.outcome).toBe('red');
    expect(v.reason).toContain('matched != true');
  });

  it('refuses synthetic evidence before judging whether it is positive', () => {
    // A fabricated artefact usually claims success; provenance has to be checked first or the claim wins.
    const v = evaluateGate(evidenceGate, evidence({ ...goodEvidence, engine: 'postgres' }), ctx);
    expect(v.outcome).toBe('synthetic');
  });

  it('refuses stale, undated and future-dated evidence', () => {
    const cases: Array<[string, Record<string, unknown>]> = [
      ['outside the window', { ...goodEvidence, comparedAt: '2026-08-02T17:10:44.204Z' }],
      ['undated', { engine: 'sqlserver', matched: true, releaseSha: SHA }],
      ['unparseable date', { ...goodEvidence, comparedAt: 'last Tuesday' }],
      ['future dated', { ...goodEvidence, comparedAt: '2026-09-01T00:00:00.000Z' }],
    ];
    for (const [label, json] of cases) {
      expect(evaluateGate(evidenceGate, evidence(json), ctx).outcome, label).toBe('stale');
    }
  });

  it('refuses evidence that belongs to another commit, or to none', () => {
    const other = evaluateGate(
      evidenceGate,
      evidence({ ...goodEvidence, releaseSha: 'b'.repeat(40) }),
      ctx,
    );
    expect(other.outcome).toBe('stale');
    expect(other.reason).toContain('releaseSha');

    const unbound = { engine: 'sqlserver', matched: true, comparedAt: goodEvidence.comparedAt };
    expect(evaluateGate(evidenceGate, evidence(unbound), ctx).outcome).toBe('stale');
  });

  it('reports RED rather than stale when the evidence is both', () => {
    // The operator has to fix the comparison, not the clock; the reported reason must say so.
    const v = evaluateGate(
      evidenceGate,
      evidence({ ...goodEvidence, matched: false, comparedAt: '2026-01-01T00:00:00.000Z' }),
      ctx,
    );
    expect(v.outcome).toBe('red');
  });

  it('dates evidence by a nested field when that is where the timestamp lives', () => {
    const nested: GateRequirement = {
      id: 'nested',
      title: 'nested',
      because: 'test',
      evidence: { path: 'x.json', timestampField: 'desktop.capturedAt' },
    };
    const observation: GateObservation = {
      id: 'nested',
      artefact: {
        path: 'x.json',
        present: true,
        json: { desktop: { capturedAt: '2026-08-30T09:30:00.000Z' }, releaseSha: SHA },
      },
    };
    expect(evaluateGate(nested, observation, ctx).outcome).toBe('passed');
  });
});

describe('release certification: exact evidence member sets', () => {
  const gate = RELEASE_GATES.find((candidate) => candidate.id === 'report-comparison')!;
  const observation = (ids: readonly string[]): GateObservation => ({
    id: gate.id,
    artefact: {
      path: gate.evidence!.path,
      present: true,
      json: {
        comparedAt: goodEvidence.comparedAt,
        releaseSha: SHA,
        reports: ids.map((reportModeId) => ({
          reportModeId,
          matched: true,
          crystal: { rows: 1, sums: { amount: 1.25 } },
          web: { rows: 1, sums: { amount: 1.25 } },
          rowCountMatches: true,
          totalsMatch: true,
          rowLevel: { compared: 1, differences: [] },
          unmappedCrystalColumns: [],
          missingWebColumns: [],
        })),
      },
    },
  });

  it('pins the independently discovered report comparison universe', () => {
    const frozenSetHash = createHash('sha256')
      .update(JSON.stringify(REQUIRED_REPORT_COMPARISON_IDS))
      .digest('hex');
    expect(frozenSetHash).toBe('4d42858af050001150c83bdfddcef4a9cfae6fbabed7af1c03d29102dd8ad835');
    const registerPath = resolve(repoRoot, 'parity-plan-2026-09-10/evidence/report-register.json');
    if (existsSync(registerPath)) {
      const register = JSON.parse(readFileSync(registerPath, 'utf8')) as Array<{ id: string }>;
      expect(REQUIRED_REPORT_COMPARISON_IDS).toEqual(register.map((entry) => entry.id));
    }
    expect(new Set(REQUIRED_REPORT_COMPARISON_IDS).size).toBe(
      REQUIRED_REPORT_COMPARISON_IDS.length,
    );
    expect(REQUIRED_REPORT_COMPARISON_IDS).toContain('AcLedger');
    // Referenced-but-absent identities may not disappear until source review gives them a disposition.
    expect(REQUIRED_REPORT_COMPARISON_IDS).toContain('salesrtna4print');
    expect(Object.isFrozen(REQUIRED_REPORT_COMPARISON_IDS)).toBe(true);
  });

  it('rejects a one-report all-pass artefact when the frozen set requires more reports', () => {
    const verdict = evaluateGate(gate, observation([REQUIRED_REPORT_COMPARISON_IDS[0]!]), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('exact-set mismatch');
    expect(verdict.reason).toContain('missing ids');
    expect(verdict.reason).toContain(REQUIRED_REPORT_COMPARISON_IDS[1]!);
  });

  it('accepts the complete required report/mode set regardless of result order', () => {
    const reversed = [...REQUIRED_REPORT_COMPARISON_IDS].reverse();
    expect(evaluateGate(gate, observation(reversed), ctx).outcome).toBe('passed');
  });

  it('requires concrete safe numeric report denominators instead of coercing JSON values', () => {
    for (const malformed of ['1', true, null, Number.NaN, Number.POSITIVE_INFINITY, 1.5]) {
      const invalid = observation(REQUIRED_REPORT_COMPARISON_IDS);
      const json = invalid.artefact!.json as {
        reports: Array<{ crystal: { rows: unknown } }>;
      };
      json.reports[0]!.crystal.rows = malformed;
      const verdict = evaluateGate(gate, invalid, ctx);
      expect(verdict.outcome, `crystal.rows=${String(malformed)}`).toBe('synthetic');
      expect(verdict.reason).toContain('crystal.rows');
    }

    for (const malformed of ['1.25', true, null, Number.NaN, Number.POSITIVE_INFINITY]) {
      const invalid = observation(REQUIRED_REPORT_COMPARISON_IDS);
      const json = invalid.artefact!.json as {
        reports: Array<{ web: { sums: { amount: unknown } } }>;
      };
      json.reports[0]!.web.sums.amount = malformed;
      const verdict = evaluateGate(gate, invalid, ctx);
      expect(verdict.outcome, `web.sums.amount=${String(malformed)}`).toBe('synthetic');
      expect(verdict.reason).toContain('web.sums.amount');
    }
  });

  it('requires row-level comparison structure in every matched report result', () => {
    const invalid = observation(REQUIRED_REPORT_COMPARISON_IDS);
    const json = invalid.artefact!.json as {
      reports: Array<{ rowLevel?: { compared: number; differences: unknown[] } }>;
    };
    delete json.reports[0]!.rowLevel;
    const verdict = evaluateGate(gate, invalid, ctx);
    expect(verdict.outcome).toBe('synthetic');
    expect(verdict.reason).toContain('rowLevel.compared');
  });

  it('rejects duplicate, missing and unexpected report/mode identities with an actionable reason', () => {
    const ids = [...REQUIRED_REPORT_COMPARISON_IDS];
    ids[1] = ids[0]!;
    ids.push('not-in-the-frozen-report-set');
    const verdict = evaluateGate(gate, observation(ids), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain(`duplicate ids: ${ids[0]}`);
    expect(verdict.reason).toContain(`missing ids: ${REQUIRED_REPORT_COMPARISON_IDS[1]}`);
    expect(verdict.reason).toContain('unexpected ids: not-in-the-frozen-report-set');
  });

  it('rejects members that do not carry a stable reportModeId', () => {
    const invalid = observation(REQUIRED_REPORT_COMPARISON_IDS);
    const json = invalid.artefact!.json as { reports: Array<Record<string, unknown>> };
    delete json.reports[0]!.reportModeId;
    const verdict = evaluateGate(gate, invalid, ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('members without a valid reportModeId: indexes 0');
  });

  it('fails closed when an exact-set requirement has no independently configured universe', () => {
    const unconfigured: GateRequirement = {
      id: 'unconfigured-members',
      title: 'Unconfigured members',
      because: 'test',
      evidence: {
        path: 'x.json',
        timestampField: 'comparedAt',
        exactSet: { collectionPath: 'reports', idField: 'id', requiredIds: [] },
      },
    };
    const verdict = evaluateGate(
      unconfigured,
      {
        id: unconfigured.id,
        artefact: {
          path: 'x.json',
          present: true,
          json: { comparedAt: goodEvidence.comparedAt, releaseSha: SHA, reports: [] },
        },
      },
      ctx,
    );
    expect(verdict.outcome).toBe('unconfigured');
    expect(verdict.reason).toContain('requiredIds is empty');
  });

  it('binds the frozen member identities into the certification requirement hash', () => {
    const changed: GateRequirement = {
      ...gate,
      evidence: {
        ...gate.evidence!,
        exactSet: {
          ...gate.evidence!.exactSet!,
          requiredIds: REQUIRED_REPORT_COMPARISON_IDS.slice(1),
        },
      },
    };
    expect(requirementSetFingerprint([changed], CERTIFIER_SOURCE_SHA)).not.toBe(
      requirementSetFingerprint([gate], CERTIFIER_SOURCE_SHA),
    );
  });

  it('binds predicate semantics and the shared certifier source into the requirement hash', () => {
    const permissive: GateRequirement = {
      ...gate,
      evidence: {
        ...gate.evidence!,
        positive: () => ({ ok: true }),
      },
    };
    expect(requirementSetFingerprint([permissive], CERTIFIER_SOURCE_SHA)).not.toBe(
      requirementSetFingerprint([gate], CERTIFIER_SOURCE_SHA),
    );
    expect(requirementSetFingerprint([gate], 'e'.repeat(64))).not.toBe(
      requirementSetFingerprint([gate], CERTIFIER_SOURCE_SHA),
    );
  });
});

describe('release certification: exact desktop comparison cases', () => {
  const gate = RELEASE_GATES.find((candidate) => candidate.id === 'g5-desktop-comparison')!;
  const observation = (ids: readonly string[]): GateObservation => ({
    id: gate.id,
    command: gate.command,
    exitCode: 0,
    stdout: 'G5_PARITY_OK',
    artefact: {
      path: gate.evidence!.path,
      present: true,
      json: {
        comparedAt: goodEvidence.comparedAt,
        releaseSha: SHA,
        matched: true,
        desktop: { engine: 'sqlserver', appVersion: 'Microsoft SQL Server 2022' },
        totals: {
          cases: ids.length,
          casesMatched: ids.length,
          tablesCompared: ids.length,
          tablesDesktopOnly: 0,
          tablesWebOnly: 0,
          fieldsCompared: ids.length,
          fieldsExcluded: 0,
          fieldDifferences: 0,
          rowsMissing: 0,
          rowsExtra: 0,
        },
        cases: ids.map((caseId) => ({ caseId, matched: true })),
        desktopOnlyCases: [],
        webOnlyCases: [],
      },
    },
  });

  it('pins the retained minimum exactly to the independent parity-ratchet case register', () => {
    const frozenSetHash = createHash('sha256')
      .update(JSON.stringify(REQUIRED_G5_COMPARISON_CASE_IDS))
      .digest('hex');
    expect(frozenSetHash).toBe('42e4d25d4c4d1c8fcbc35961fbe584a9a69c0b5ec272300d222fab605262c712');
    // The retained ratchet is operational evidence and may be intentionally absent from an isolated source
    // checkout. When available, it must still agree byte-for-byte with the release-side frozen universe.
    const ratchetPath = resolve(repoRoot, 'project-memory/parity/PARITY-RATCHET.json');
    if (existsSync(ratchetPath)) {
      const ratchet = JSON.parse(readFileSync(ratchetPath, 'utf8')) as { caseIds: string[] };
      expect(REQUIRED_G5_COMPARISON_CASE_IDS).toEqual(ratchet.caseIds);
    }
    expect(new Set(REQUIRED_G5_COMPARISON_CASE_IDS).size).toBe(
      REQUIRED_G5_COMPARISON_CASE_IDS.length,
    );
    expect(Object.isFrozen(REQUIRED_G5_COMPARISON_CASE_IDS)).toBe(true);
  });

  it('rejects an all-pass desktop comparison that returns only one required case', () => {
    const verdict = evaluateGate(gate, observation([REQUIRED_G5_COMPARISON_CASE_IDS[0]!]), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('exact-set mismatch at cases');
    expect(verdict.reason).toContain(`missing ids: ${REQUIRED_G5_COMPARISON_CASE_IDS[1]}`);
  });

  it('accepts the complete retained case set independent of result order', () => {
    const reversed = [...REQUIRED_G5_COMPARISON_CASE_IDS].reverse();
    expect(evaluateGate(gate, observation(reversed), ctx).outcome).toBe('passed');
  });

  it('requires every one of the 70 case results to carry matched=true', () => {
    for (const matched of [false, undefined, 'true']) {
      const invalid = observation(REQUIRED_G5_COMPARISON_CASE_IDS);
      const json = invalid.artefact!.json as {
        cases: Array<{ caseId: string; matched?: unknown }>;
      };
      json.cases[0]!.matched = matched;
      const verdict = evaluateGate(gate, invalid, ctx);
      expect(verdict.outcome, String(matched)).toBe('red');
      expect(verdict.reason).toContain(REQUIRED_G5_COMPARISON_CASE_IDS[0]!);
    }
  });

  it('requires totals.cases to equal the frozen exact set and never coerces numeric fields', () => {
    const wrongTotal = observation(REQUIRED_G5_COMPARISON_CASE_IDS);
    const wrongJson = wrongTotal.artefact!.json as { totals: Record<string, unknown> };
    wrongJson.totals.cases = REQUIRED_G5_COMPARISON_CASE_IDS.length - 1;
    expect(evaluateGate(gate, wrongTotal, ctx)).toMatchObject({
      outcome: 'synthetic',
      reason: expect.stringContaining('frozen 70-case universe'),
    });

    for (const [field, malformed] of [
      ['cases', String(REQUIRED_G5_COMPARISON_CASE_IDS.length)],
      ['fieldsCompared', true],
      ['fieldDifferences', null],
      ['rowsMissing', Number.NaN],
      ['rowsExtra', Number.POSITIVE_INFINITY],
      ['tablesCompared', 1.5],
      ['fieldsExcluded', Number.MAX_SAFE_INTEGER + 1],
    ] as const) {
      const invalid = observation(REQUIRED_G5_COMPARISON_CASE_IDS);
      const json = invalid.artefact!.json as { totals: Record<string, unknown> };
      json.totals[field] = malformed;
      const verdict = evaluateGate(gate, invalid, ctx);
      expect(verdict.outcome, `${field}=${String(malformed)}`).toBe('synthetic');
      expect(verdict.reason).toContain(field);
    }
  });
});

describe('release certification: retained parity ratchet evidence', () => {
  const gate = RELEASE_GATES.find((candidate) => candidate.id === 'parity-ratchet')!;
  const observation = (
    caseIds: readonly unknown[] = REQUIRED_G5_COMPARISON_CASE_IDS,
  ): GateObservation => ({
    id: gate.id,
    command: gate.command,
    exitCode: 0,
    stdout: 'PARITY_RATCHET_OK',
    artefact: {
      path: gate.evidence!.path,
      present: true,
      json: {
        recordedAt: goodEvidence.comparedAt,
        releaseSha: SHA,
        caseIds,
        metrics: {
          cases: REQUIRED_G5_COMPARISON_CASE_IDS.length,
          casesMatched: 0,
          tablesCompared: 387,
          tablesDesktopOnly: 59,
          tablesWebOnly: 76,
          fieldsCompared: 27_895,
          fieldsExcluded: 1_701,
          fieldDifferences: 510,
          rowsMissing: 153,
          rowsExtra: 137,
        },
      },
    },
  });

  it('freezes the ratchet to the same exact 70-case universe as the desktop comparison', () => {
    expect(gate.evidence?.exactSet).toEqual({
      collectionPath: 'caseIds',
      requiredIds: REQUIRED_G5_COMPARISON_CASE_IDS,
    });
    expect(
      evaluateGate(gate, observation([...REQUIRED_G5_COMPARISON_CASE_IDS].reverse()), ctx).outcome,
    ).toBe('passed');
  });

  it('rejects missing, duplicate, unexpected, and malformed ratchet case identities', () => {
    const first = REQUIRED_G5_COMPARISON_CASE_IDS[0]!;
    const second = REQUIRED_G5_COMPARISON_CASE_IDS[1]!;
    for (const caseIds of [
      REQUIRED_G5_COMPARISON_CASE_IDS.slice(1),
      [first, first, ...REQUIRED_G5_COMPARISON_CASE_IDS.slice(2)],
      ['not-retained', ...REQUIRED_G5_COMPARISON_CASE_IDS.slice(1)],
      [null, ...REQUIRED_G5_COMPARISON_CASE_IDS.slice(1)],
    ]) {
      const verdict = evaluateGate(gate, observation(caseIds), ctx);
      expect(verdict.outcome).toBe('red');
      expect(verdict.reason).toContain('exact-set mismatch at caseIds');
    }
    expect(evaluateGate(gate, observation([first]), ctx).reason).toContain(second);
  });

  it('requires real safe-integer metrics and an exact aggregate case count', () => {
    for (const [field, malformed] of [
      ['cases', String(REQUIRED_G5_COMPARISON_CASE_IDS.length)],
      ['fieldsCompared', true],
      ['fieldDifferences', null],
      ['rowsMissing', Number.NaN],
      ['rowsExtra', Number.POSITIVE_INFINITY],
      ['tablesCompared', 1.5],
      ['fieldsExcluded', Number.MAX_SAFE_INTEGER + 1],
    ] as const) {
      const invalid = observation();
      const json = invalid.artefact!.json as { metrics: Record<string, unknown> };
      json.metrics[field] = malformed;
      const verdict = evaluateGate(gate, invalid, ctx);
      expect(verdict.outcome, `${field}=${String(malformed)}`).toBe('red');
      expect(verdict.reason).toContain(field);
    }

    const wrongCount = observation();
    const json = wrongCount.artefact!.json as { metrics: Record<string, unknown> };
    json.metrics.cases = REQUIRED_G5_COMPARISON_CASE_IDS.length - 1;
    expect(evaluateGate(gate, wrongCount, ctx).reason).toContain('frozen retained universe');
  });
});

describe('release certification: exact real-browser journeys', () => {
  const gate = RELEASE_GATES.find((candidate) => candidate.id === 'real-browser')!;
  const observation = (
    ids: readonly string[],
    overrides: Record<string, unknown> = {},
  ): GateObservation => ({
    id: gate.id,
    command: gate.command,
    exitCode: 0,
    stdout: 'PARITY_REAL_STACK_PASSED',
    artefact: {
      path: gate.evidence!.path,
      present: true,
      json: {
        finishedAt: goodEvidence.comparedAt,
        releaseSha: SHA,
        database: 'disposable localhost:55433 / app_user',
        mockedRequests: 0,
        mockedResponses: 0,
        interceptionIndicators: 0,
        status: 'passed',
        journeys: ids.map((journeyId) => ({ journeyId, status: 'passed' })),
        ...overrides,
      },
    },
  });

  it('pins the 23 production-stack journeys and keeps them frozen and unique', () => {
    // 19 plus the evaluation-defect journeys cash-receipt-payment (D1) and sale-amount-basis (D6), X16's
    // wholesale-rate-cut (TR_WH_SALE on its WH SALES and RATE CUT books), N18's tag-cancel-transfer (TR_TAG_CAN
    // on its TAG CANCEL and TAG TRFR books) and N19's tag-split (TR_TAG_SPLIT on a TAG SPLIT book).
    expect(REQUIRED_REAL_BROWSER_JOURNEY_IDS).toHaveLength(24);
    expect(new Set(REQUIRED_REAL_BROWSER_JOURNEY_IDS).size).toBe(
      REQUIRED_REAL_BROWSER_JOURNEY_IDS.length,
    );
    expect(REQUIRED_REAL_BROWSER_JOURNEY_IDS).toContain('sales-return-bill-replay');
    expect(REQUIRED_REAL_BROWSER_JOURNEY_IDS).toContain('sales-return-labour-replay');
    expect(Object.isFrozen(REQUIRED_REAL_BROWSER_JOURNEY_IDS)).toBe(true);

    const producer = readFileSync(
      resolve(repoRoot, 'web/apps/web/test/parity.real-stack.mjs'),
      'utf8',
    );
    const emittedBlock = producer.match(/result\.journeys = \[([\s\S]*?)\]\.map/);
    expect(emittedBlock, 'real-stack harness must emit a journey result collection').not.toBeNull();
    const emittedIds = [...emittedBlock![1]!.matchAll(/\['([^']+)',\s*result\./g)].map(
      (match) => match[1]!,
    );
    expect(emittedIds.sort()).toEqual([...REQUIRED_REAL_BROWSER_JOURNEY_IDS].sort());
  });

  it('accepts the complete journey set and rejects an all-pass subset', () => {
    const complete = evaluateGate(
      gate,
      observation([...REQUIRED_REAL_BROWSER_JOURNEY_IDS].reverse()),
      ctx,
    );
    expect(complete.outcome).toBe('passed');

    const subset = evaluateGate(gate, observation([REQUIRED_REAL_BROWSER_JOURNEY_IDS[0]!]), ctx);
    expect(subset.outcome).toBe('red');
    expect(subset.reason).toContain('exact-set mismatch at journeys');
    expect(subset.reason).toContain('missing ids');
  });

  // Journeys added after each historical set; the reconstructions below remove them too.
  const N19_JOURNEYS = ['tag-split'];
  const N18_JOURNEYS = ['tag-cancel-transfer'];
  const X16_JOURNEYS = ['wholesale-rate-cut'];
  const EVALUATION_DEFECT_JOURNEYS = [
    'cash-receipt-payment',
    'sale-amount-basis',
    ...X16_JOURNEYS,
    ...N18_JOURNEYS,
    ...N19_JOURNEYS,
  ];
  const before = (...added: string[]) =>
    REQUIRED_REAL_BROWSER_JOURNEY_IDS.filter(
      (id) => !added.includes(id) && !EVALUATION_DEFECT_JOURNEYS.includes(id),
    );

  it('rejects the former twenty-three when the N19 tag split journey is missing', () => {
    const previous = REQUIRED_REAL_BROWSER_JOURNEY_IDS.filter((id) => !N19_JOURNEYS.includes(id));
    expect(previous).toHaveLength(23);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('tag-split');
  });

  it('rejects the former twenty-two when the N18 tag cancel / transfer journey is missing', () => {
    const previous = REQUIRED_REAL_BROWSER_JOURNEY_IDS.filter(
      (id) => !N18_JOURNEYS.includes(id) && !N19_JOURNEYS.includes(id),
    );
    expect(previous).toHaveLength(22);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('tag-cancel-transfer');
  });

  it('rejects the former twenty-one when the X16 wholesale / rate cut journey is missing', () => {
    const previous = REQUIRED_REAL_BROWSER_JOURNEY_IDS.filter(
      (id) =>
        !X16_JOURNEYS.includes(id) && !N18_JOURNEYS.includes(id) && !N19_JOURNEYS.includes(id),
    );
    expect(previous).toHaveLength(21);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('wholesale-rate-cut');
  });

  it('rejects the former nineteen when the evaluation-defect journeys are missing', () => {
    const previous = before();
    expect(previous).toHaveLength(19);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('cash-receipt-payment');
    expect(verdict.reason).toContain('sale-amount-basis');
  });

  it('rejects the former complete sixteen when the labour preview journey is missing', () => {
    const previous = before('sales-return-labour-replay', 'credit-note-entry', 'e-invoice-entry');
    expect(previous).toHaveLength(16);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('missing ids');
    expect(verdict.reason).toContain('sales-return-labour-replay');
  });

  it('rejects the former eighteen when the X15 e-invoice entry journey is missing', () => {
    const previous = before('e-invoice-entry');
    expect(previous).toHaveLength(18);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('e-invoice-entry');
  });

  it('rejects the former complete seventeen when the X15 credit-note entry journey is missing', () => {
    const previous = before('credit-note-entry', 'e-invoice-entry');
    expect(previous).toHaveLength(17);
    const verdict = evaluateGate(gate, observation(previous), ctx);
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain('credit-note-entry');
  });

  it('rejects mocked, wrong-database, or negative real-browser evidence', () => {
    for (const field of ['mockedRequests', 'mockedResponses', 'interceptionIndicators'] as const) {
      for (const malformed of [1, null, false, '', [], {}]) {
        expect(
          evaluateGate(
            gate,
            observation(REQUIRED_REAL_BROWSER_JOURNEY_IDS, { [field]: malformed }),
            ctx,
          ).outcome,
          `${field}=${JSON.stringify(malformed)}`,
        ).toBe('synthetic');
      }
    }
    for (const database of ['mock database', ['disposable localhost:55433 / app_user'], null]) {
      expect(
        evaluateGate(gate, observation(REQUIRED_REAL_BROWSER_JOURNEY_IDS, { database }), ctx)
          .outcome,
        JSON.stringify(database),
      ).toBe('synthetic');
    }
    expect(
      evaluateGate(gate, observation(REQUIRED_REAL_BROWSER_JOURNEY_IDS, { status: 'failed' }), ctx)
        .outcome,
    ).toBe('red');
  });

  it('rejects any named journey whose retained status is not passed', () => {
    const journeys = REQUIRED_REAL_BROWSER_JOURNEY_IDS.map((journeyId, index) => ({
      journeyId,
      status: index === 0 ? 'missing' : 'passed',
    }));
    const verdict = evaluateGate(
      gate,
      observation(REQUIRED_REAL_BROWSER_JOURNEY_IDS, { journeys }),
      ctx,
    );
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toContain(REQUIRED_REAL_BROWSER_JOURNEY_IDS[0]!);
  });
});

describe('release certification: restore-drill proof', () => {
  const gate = RELEASE_GATES.find((candidate) => candidate.id === 'restore-drill')!;
  const observation = (overrides: Record<string, unknown> = {}): GateObservation => ({
    id: gate.id,
    command: gate.command,
    exitCode: 0,
    stdout: 'RESTORE_DRILL_OK',
    artefact: {
      path: gate.evidence!.path,
      present: true,
      json: {
        status: 'passed',
        measuredAt: goodEvidence.comparedAt,
        releaseSha: SHA,
        verification: {
          verified: true,
          sourceRows: 2,
          restoredRows: 2,
          tablesChecked: 1,
          mismatches: [],
          tables: [
            {
              table: 'AC_DATA',
              sourceRows: 2,
              restoredRows: 2,
              sourceChecksum: 'abc123',
              restoredChecksum: 'abc123',
              matches: true,
            },
          ],
        },
        ...overrides,
      },
    },
  });

  it('does not accept status=passed without concrete verification evidence', () => {
    for (const verification of [undefined, null, {}, { verified: false }]) {
      const verdict = evaluateGate(gate, observation({ verification }), ctx);
      expect(verdict.outcome, JSON.stringify(verification)).toBe('red');
      expect(verdict.reason).toContain('verification.verified=true');
    }
  });

  it('accepts a non-empty checksum-and-row verified restore', () => {
    expect(evaluateGate(gate, observation(), ctx).outcome).toBe('passed');
  });

  it('rejects coerced, unequal, empty, or internally inconsistent verification', () => {
    for (const malformed of ['2', true, null, 1.5, Number.POSITIVE_INFINITY]) {
      const invalid = observation();
      const json = invalid.artefact!.json as {
        verification: Record<string, unknown>;
      };
      json.verification.sourceRows = malformed;
      const verdict = evaluateGate(gate, invalid, ctx);
      expect(verdict.outcome, String(malformed)).toBe('red');
      expect(verdict.reason).toContain('sourceRows');
    }

    for (const verification of [
      {
        verified: true,
        sourceRows: 2,
        restoredRows: 1,
        tablesChecked: 0,
        mismatches: [],
        tables: [],
      },
      {
        verified: true,
        sourceRows: 2,
        restoredRows: 2,
        tablesChecked: 1,
        mismatches: [],
        tables: [
          {
            table: 'AC_DATA',
            sourceRows: 2,
            restoredRows: 2,
            sourceChecksum: 'source',
            restoredChecksum: 'different',
            matches: true,
          },
        ],
      },
    ]) {
      expect(evaluateGate(gate, observation({ verification }), ctx).outcome).toBe('red');
    }
  });
});

describe('release certification: the aggregate verdict', () => {
  const gates: GateRequirement[] = [commandGate, evidenceGate];
  const aggregateCtx: CertificationContext = {
    ...ctx,
    approvedRequirementSetHash: requirementSetFingerprint(gates, CERTIFIER_SOURCE_SHA),
  };

  it('passes only when every gate passed', () => {
    const record = certify(gates, [ok(), evidence(goodEvidence)], aggregateCtx);
    expect(record.verdict).toBe('passed');
    expect(record.totals.passed).toBe(2);
    expect(record.releaseSha).toBe(SHA);
    expect(record.kind).toBe('datacare.release-certification/1.0');
    expect(record.requirementSetHash).toBe(requirementSetFingerprint(gates, CERTIFIER_SOURCE_SHA));
    expect(record.approvedRequirementSetHash).toBe(record.requirementSetHash);
    expect(record.requirementSetHash).toMatch(/^[a-f0-9]{64}$/);
  });

  it('fails on a single non-passing gate and keeps every reason', () => {
    const record = certify(
      gates,
      [ok({ stdout: 'TYPE_PARITY_SKIP' }), evidence(undefined)],
      aggregateCtx,
    );
    expect(record.verdict).toBe('failed');
    expect(record.totals).toMatchObject({ passed: 0, skipped: 1, missing: 1 });
    expect(record.gates.map((g) => g.outcome)).toEqual(['skipped', 'missing']);
  });

  it('fails a gate the runner forgot to observe, so silence is never success', () => {
    const record = certify(gates, [], aggregateCtx);
    expect(record.verdict).toBe('failed');
    expect(record.totals.missing).toBe(2);
  });

  it('fails duplicate observations instead of letting the last one overwrite the first', () => {
    const record = certify(
      gates,
      [ok(), ok({ stderr: 'duplicate' }), evidence(goodEvidence)],
      aggregateCtx,
    );
    expect(record.verdict).toBe('failed');
    expect(record.totals.duplicate).toBe(1);
    expect(record.gates.find((g) => g.id === 'example')).toMatchObject({
      outcome: 'duplicate',
      reason: expect.stringContaining('exact-set certification'),
    });
  });

  it('fails unexpected observations that are not in the required gate set', () => {
    const record = certify(
      gates,
      [ok(), evidence(goodEvidence), { id: 'extra-green-gate', exitCode: 0, stdout: 'OK' }],
      aggregateCtx,
    );
    expect(record.verdict).toBe('failed');
    expect(record.totals.unexpected).toBe(1);
    expect(record.gates.find((g) => g.id === 'extra-green-gate')).toMatchObject({
      outcome: 'unexpected',
    });
  });

  it('refuses an empty required set so a non-zero release universe cannot be replaced with zero', () => {
    const record = certify([], [], {
      ...ctx,
      approvedRequirementSetHash: requirementSetFingerprint([], CERTIFIER_SOURCE_SHA),
    });
    expect(record.verdict).toBe('failed');
    expect(record.totals.unconfigured).toBe(1);
    expect(RELEASE_GATES.length).toBeGreaterThan(10);
  });

  it('refuses duplicate identities in the required gate universe', () => {
    const duplicated = [commandGate, { ...commandGate, title: 'Duplicate requirement id' }];
    expect(requirementSetProblems(duplicated)).toEqual(['duplicate gate ids: example']);
    const record = certify(duplicated, [ok()], {
      ...ctx,
      approvedRequirementSetHash: requirementSetFingerprint(duplicated, CERTIFIER_SOURCE_SHA),
    });
    expect(record.verdict).toBe('failed');
    expect(record.totals.unconfigured).toBe(1);
    expect(record.gates.find((gate) => gate.id === 'required-gate-set')?.reason).toContain(
      'duplicate gate ids: example',
    );
  });

  it('rejects malformed required gate IDs before execution', () => {
    expect(requirementSetProblems([{ ...commandGate, id: ' Example ' }])).toEqual([
      'invalid gate ids:  Example ',
    ]);
  });

  it('rejects malformed exact-set declarations during zero-gate preflight', () => {
    const malformed: GateRequirement = {
      id: 'malformed-members',
      title: 'Malformed members',
      because: 'test exact-set preflight validation',
      evidence: {
        path: 'evidence.json',
        timestampField: 'comparedAt',
        exactSet: {
          collectionPath: 'reports..items',
          idField: ' ',
          requiredIds: ['valid', 'valid', ' invalid '],
        },
      },
    };
    const problems = requirementSetProblems([malformed]).join('\n');
    expect(problems).toContain('malformed-members exact-set collectionPath is invalid');
    expect(problems).toContain('malformed-members exact-set idField is invalid');
    expect(problems).toContain('invalid required ids');
    expect(problems).toContain('duplicate required ids: valid');

    const empty = {
      ...malformed,
      evidence: {
        ...malformed.evidence!,
        exactSet: { collectionPath: 'reports', idField: 'id', requiredIds: [] },
      },
    };
    expect(requirementSetProblems([empty]).join('\n')).toContain('requiredIds is empty');
  });

  it('rejects no-op gates but accepts evidence-only and runner-owned requirements', () => {
    const noOp: GateRequirement = {
      id: 'no-op',
      title: 'No operation',
      because: 'a declaration without any observation channel proves nothing',
    };
    expect(requirementSetProblems([noOp])).toEqual([
      'gates without a command, runner check, or evidence: no-op',
    ]);

    const evidenceOnly: GateRequirement = {
      id: 'evidence-only',
      title: 'Evidence only',
      because: 'some independently produced evidence has no repository command',
      evidence: { path: 'evidence.json', timestampField: 'comparedAt' },
    };
    const runnerOwned: GateRequirement = {
      id: 'candidate-identity-postflight',
      title: 'Candidate identity postflight',
      because: 'the runner owns this in-process observation',
      runnerCheck: 'candidate-identity-postflight',
    };
    expect(requirementSetProblems([evidenceOnly, runnerOwned])).toEqual([]);
  });

  it('refuses a green run when the candidate requirement universe differs from owner approval', () => {
    const record = certify(gates, [ok(), evidence(goodEvidence)], {
      ...ctx,
      approvedRequirementSetHash: 'f'.repeat(64),
    });
    expect(record.verdict).toBe('failed');
    expect(record.totals).toMatchObject({ passed: 2, unconfigured: 1 });
    expect(record.gates.find((gate) => gate.id === 'approved-requirement-set')).toMatchObject({
      outcome: 'unconfigured',
      reason: expect.stringContaining(record.requirementSetHash),
    });
  });

  it('detects an approval mismatch during zero-gate preflight setup', () => {
    const actualRequirementSetHash = requirementSetFingerprint(gates, CERTIFIER_SOURCE_SHA);
    const problems = contextProblems({
      ...ctx,
      approvedRequirementSetHash: 'f'.repeat(64),
      actualRequirementSetHash,
    });
    expect(problems).toEqual([
      expect.stringContaining(
        `does not match candidate requirement set ${actualRequirementSetHash}`,
      ),
    ]);
  });
});

describe('the release gate set', () => {
  it('covers every gate P0-07 names, in its strict form', () => {
    const ids = RELEASE_GATES.map((g) => g.id);
    expect(new Set(ids).size).toBe(ids.length);
    for (const required of [
      'g5-desktop-comparison',
      'real-browser',
      'completion-register',
      'type-parity',
      'schema-readiness',
      'report-comparison',
      'restore-drill',
      'candidate-identity-postflight',
    ]) {
      expect(ids, `P0-07 names ${required}`).toContain(required);
    }
    // The register gate must be the strict form; the default script accepts 198 unclassified entries.
    const register = RELEASE_GATES.find((g) => g.id === 'completion-register')!;
    expect(register.command).toContain('--strict');
    const typeParity = RELEASE_GATES.find((g) => g.id === 'type-parity')!;
    expect(typeParity.command).toBe('node scripts/check-type-parity.mjs --release');
    expect(typeParity.because).toMatch(/5,231.*numeric.*text/);
    // No gate may invoke a self-approving mode.
    for (const gate of RELEASE_GATES) expect(gate.command ?? '').not.toContain('--write');
    // Every gate explains why it is required, so a refusal is actionable.
    for (const gate of RELEASE_GATES) expect(gate.because.length).toBeGreaterThan(20);
  });

  it('demands attributable evidence from the gates whose claim is a comparison', () => {
    for (const id of [
      'g5-desktop-comparison',
      'real-browser',
      'report-comparison',
      'restore-drill',
    ]) {
      const gate = RELEASE_GATES.find((g) => g.id === id)!;
      expect(gate.evidence, `${id} must produce a retained artefact`).toBeDefined();
      expect(gate.evidence!.timestampField, `${id} must be datable`).toBeTruthy();
    }
  });
});

describe('the release workflow is separate and tolerates nothing', () => {
  /**
   * P0-07's required action is "separate developer CI from release certification". That separation is a
   * property of two YAML files, and a property nobody checks is a convention. These read the workflows as
   * text — deliberately not a YAML parser, because `continue-on-error` smuggled into a run script or an
   * expression would still be tolerance — and hold each file to its own job.
   */
  const workflow = (name: string): string =>
    readFileSync(resolve(repoRoot, `.github/workflows/${name}`), 'utf8');

  const nestedWorkflow = (name: string): string =>
    readFileSync(resolve(repoRoot, `web/.github/workflows/${name}`), 'utf8');

  /** Strip comment lines so the prose explaining tolerance is not mistaken for tolerance. */
  const code = (text: string): string[] =>
    text
      .split('\n')
      .filter((line) => !line.trim().startsWith('#'))
      .map((line) => line.trim());

  it('exists as its own workflow rather than a flag on developer CI', () => {
    const release = workflow('release-certification.yml');
    expect(release).toContain('name: Release certification');
    expect(release).toContain('working-directory: web');
    expect(release).toMatch(/permissions:\s*\n\s*contents:\s*read/);
    expect(release).toContain('persist-credentials: false');
    expect(release).toMatch(/release_sha:[\s\S]{0,180}required:\s*true/);
    // It must not run on every push/pull request: certification reads real credentials and takes real time.
    expect(release).toContain('workflow_dispatch');
    expect(release).not.toMatch(/^on:\s*\n\s*pull_request/m);
    expect(release).not.toMatch(/^\s+tags:/m);
    // It must run the certifier, not a hand-assembled list of steps that could drift from RELEASE_GATES.
    expect(release).toContain('pnpm release:certify');
  });

  it('keeps the active root workflows semantically aligned with the historical nested copies', () => {
    for (const name of ['ci.yml', 'release-certification.yml']) {
      expect(workflow(name), name).toBe(nestedWorkflow(name));
    }
  });

  it('contains no tolerated failure of any kind', () => {
    const lines = code(workflow('release-certification.yml'));
    const tolerated = lines.filter(
      (line) => line.includes('continue-on-error') || line.includes('|| true'),
    );
    expect(tolerated, 'a release gate that tolerates a failure is not a gate').toEqual([]);
  });

  it('requires the freshness window as an input rather than defaulting it', () => {
    const release = workflow('release-certification.yml');
    expect(release).toContain('evidence_max_age_hours');
    expect(release).toMatch(/evidence_max_age_hours:[\s\S]{0,200}required:\s*true/);
    // And it must not hardcode a window, which would be deciding an owner question in YAML.
    expect(release).not.toMatch(/RELEASE_EVIDENCE_MAX_AGE_HOURS:\s*['"]?\d/);
  });

  it('requires an owner-reviewed requirement-set hash and passes it only through environment data', () => {
    const release = workflow('release-certification.yml');
    expect(release).toContain('requirement_set_sha256');
    expect(release).toMatch(/requirement_set_sha256:[\s\S]{0,240}required:\s*true/);
    expect(release).toContain(
      'RELEASE_REQUIREMENT_SET_SHA256: ${{ inputs.requirement_set_sha256 }}',
    );
    expect(release).not.toMatch(/requirement_set_sha256:[\s\S]{0,240}default:/);
    expect(release).not.toContain("requirement_hash='${{ inputs.requirement_set_sha256 }}'");
  });

  it('retains a refusal artifact when Actions fails before the certifier can decide', () => {
    const release = workflow('release-certification.yml');
    expect(release).toContain(
      'RELEASE_WORKFLOW_RUN_ID: ${{ github.run_id }}-${{ github.run_attempt }}',
    );
    expect(release).toMatch(
      /name: Ensure an early workflow failure has a refusal record[\s\S]{0,160}if: failure\(\)/,
    );
    expect(release).toContain('node scripts/release-certification-workflow-refusal.mjs');
  });

  it('derives expected lock/schema/template identities from Git objects before installation', () => {
    const release = workflow('release-certification.yml');
    const identity = release.indexOf('release-candidate-expected-identity.mjs');
    const install = release.indexOf('pnpm install --frozen-lockfile');
    expect(identity).toBeGreaterThan(0);
    expect(identity).toBeLessThan(install);
    expect(release).toContain(
      'RELEASE_LOCK_SHA256: ${{ steps.candidate-inputs.outputs.lock_sha256 }}',
    );
    expect(release).toContain(
      'RELEASE_SCHEMA_SHA256: ${{ steps.candidate-inputs.outputs.schema_sha256 }}',
    );
    expect(release).toContain(
      'RELEASE_TEMPLATE_SHA256: ${{ steps.candidate-inputs.outputs.template_sha256 }}',
    );
    expect(release).toContain('RELEASE_SHA: ${{ steps.commit.outputs.sha }}');
    expect(release).not.toContain('RELEASE_SHA: ${{ steps.candidate-inputs.outputs.release_sha }}');
    // Workflow-dispatch text must enter the shell through an environment variable, never source interpolation.
    expect(release).not.toContain("sha='${{ inputs.release_sha }}'");
    expect(release).toContain('REQUESTED_RELEASE_SHA: ${{ inputs.release_sha }}');
  });

  it('hashes and imports the same candidate-source snapshot from a fresh compilation directory', () => {
    const runner = readFileSync(resolve(repoRoot, 'web/scripts/release-certify.mjs'), 'utf8');
    const captured = runner.indexOf('const certifierSource = readFileSync(certifierSourcePath)');
    const hashed = runner.indexOf("createHash('sha256').update(certifierSource)");
    const freshDirectory = runner.indexOf(
      "mkdtempSync(resolve(tmpdir(), 'datacare-release-certifier-'))",
    );
    const snapshot = runner.indexOf('writeFileSync(certifierSnapshot, certifierSource)');
    const isolatedOutput = runner.indexOf("'--outDir',\n      certifierBuildDir");
    const imported = runner.indexOf(
      "await import(resolve(certifierBuildDir, 'releaseCertification.mjs'))",
    );
    expect(captured).toBeGreaterThan(0);
    expect(hashed).toBeGreaterThan(captured);
    expect(freshDirectory).toBeGreaterThan(hashed);
    expect(snapshot).toBeGreaterThan(freshDirectory);
    expect(isolatedOutput).toBeGreaterThan(snapshot);
    expect(imported).toBeGreaterThan(isolatedOutput);
    expect(runner.match(/readFileSync\(certifierSourcePath\)/g)).toHaveLength(1);
    expect(runner).not.toContain('apps/api/dist/modules/ops/releaseCertification.js');
  });

  it('validates the required gate universe before invoking its commands', () => {
    const runner = readFileSync(resolve(repoRoot, 'web/scripts/release-certify.mjs'), 'utf8');
    expect(runner.indexOf('...requirementSetProblems(RELEASE_GATES)')).toBeLessThan(
      runner.indexOf('RELEASE_GATES.map((gate)'),
    );
  });

  it('leaves developer CI actionable, with its one tolerance confined to the desktop comparison', () => {
    // The separation only works if developer CI is allowed to stay green on a known-red capture. What must
    // NOT happen is tolerance spreading to other gates, so the count is pinned.
    const lines = code(workflow('ci.yml'));
    const tolerated = lines.filter((line) => line.startsWith('continue-on-error'));
    expect(tolerated).toHaveLength(1);
    const text = workflow('ci.yml');
    const index = text.indexOf('continue-on-error');
    const preceding = text.slice(Math.max(0, index - 400), index);
    expect(preceding, 'the single tolerated step must still be the desktop comparison').toMatch(
      /desktop comparison/i,
    );
  });

  it('does not mutate dependencies or publish checked-in G5 evidence for a skipped desktop run', () => {
    const ci = workflow('ci.yml');
    expect(ci).not.toMatch(/\bpnpm add\b/);
    expect(ci).toContain("if: github.event_name == 'push' && github.ref == 'refs/heads/main'");
    expect(ci).toContain("if: always() && steps.g5_comparison.outputs.produced == 'true'");
    expect(ci).toContain('echo \'produced=true\' >> "$GITHUB_OUTPUT"');
    expect(ci).toContain(
      'name: g5-desktop-comparison-${{ github.sha }}-${{ github.run_id }}-${{ github.run_attempt }}',
    );
    expect(ci).not.toContain('if [ -n "${{ secrets.DESKTOP_SOURCE_DATABASE }}" ]');
    expect(ci).toContain('DESKTOP_SOURCE_DATABASE: ${{ secrets.DESKTOP_SOURCE_DATABASE }}');
  });

  it('limits workflow credentials to reviewed code and the step that consumes them', () => {
    const ci = workflow('ci.yml');
    const release = workflow('release-certification.yml');
    expect(ci).toMatch(/permissions:\s*\n\s*contents:\s*read/);
    // One checkout per job (static-gates, quality, the main-only desktop comparison), and every one of them
    // drops the token, so no later step of candidate-controlled code can reuse it.
    const checkouts = ci.match(/uses: actions\/checkout@/g) ?? [];
    expect(checkouts).toHaveLength(3);
    expect(ci.match(/persist-credentials: false/g)).toHaveLength(checkouts.length);
    expect(release.match(/persist-credentials: false/g)).toHaveLength(1);
    expect(release).not.toContain('secrets.RELEASE_APP_DB_PASSWORD');
    expect(release).not.toContain('secrets.RELEASE_JWT_SECRET');
    expect(release.match(/secrets\.RELEASE_MSSQL_TYPE_DUMP_PATH/g)).toHaveLength(1);
    expect(release.indexOf('secrets.RELEASE_MSSQL_TYPE_DUMP_PATH')).toBeGreaterThan(
      release.indexOf('- name: Certify'),
    );
  });
});

describe('the rules applied to this repository today', () => {
  /**
   * The plan states the release gate must be red until the evidence exists. These cases prove it IS red, and
   * for the stated reasons, using the files actually in the repository rather than fixtures.
   */
  const readJson = (path: string): Record<string, unknown> | undefined => {
    try {
      return JSON.parse(readFileSync(resolve(repoRoot, path), 'utf8')) as Record<string, unknown>;
    } catch {
      return undefined;
    }
  };

  it('refuses the retained G5 evidence, which reports matched:false', () => {
    const gate = RELEASE_GATES.find((g) => g.id === 'g5-desktop-comparison')!;
    const json = readJson(gate.evidence!.path);
    expect(json, 'the retained parity-diff-latest.json should exist').toBeDefined();
    const verdict = evaluateGate(
      gate,
      {
        id: gate.id,
        command: gate.command,
        exitCode: 0,
        stdout: '',
        artefact: { path: gate.evidence!.path, present: true, json },
      },
      ctx,
    );
    expect(verdict.outcome).toBe('red');
    expect(verdict.reason).toMatch(/matched != true|fieldDifferences|rowsMissing/);
  });

  it('refuses the report comparison, which has no artefact at all', () => {
    const gate = RELEASE_GATES.find((g) => g.id === 'report-comparison')!;
    const json = readJson(gate.evidence!.path);
    expect(json, 'no report comparison artefact exists yet (plan P1-06)').toBeUndefined();
    const verdict = evaluateGate(
      gate,
      { id: gate.id, artefact: { path: gate.evidence!.path, present: false } },
      ctx,
    );
    expect(verdict.outcome).toBe('missing');
  });

  it('refuses the retained restore drill, which is months old and unattributed', () => {
    const gate = RELEASE_GATES.find((g) => g.id === 'restore-drill')!;
    const json = readJson(gate.evidence!.path);
    expect(json).toBeDefined();
    const verdict = evaluateGate(
      gate,
      {
        id: gate.id,
        command: gate.command,
        exitCode: 0,
        stdout: 'RESTORE_DRILL_OK',
        artefact: { path: gate.evidence!.path, present: true, json },
      },
      ctx,
    );
    expect(verdict.outcome).toBe('stale');
  });
});
