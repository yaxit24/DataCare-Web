import { mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { describe, expect, it } from 'vitest';
import { writePreflightRefusalRecord } from '../../../scripts/lib/release-certification-record.mjs';
import { ensureWorkflowRefusalRecord } from '../../../scripts/lib/release-certification-workflow-refusal.mjs';

const SHA = 'a'.repeat(40);
const TREE = 'b'.repeat(40);
const LOCK = 'c'.repeat(64);
const SCHEMA = 'd'.repeat(64);
const REQUIREMENTS = 'e'.repeat(64);
const CERTIFIER_SOURCE = 'f'.repeat(64);
const TEMPLATE = '1'.repeat(64);
const FORM_TEMPLATE = '2'.repeat(64);
const REPORT_TEMPLATE = '3'.repeat(64);
const WORKFLOW_RUN_ID = '9001-1';
const GATE_OUTCOMES = [
  'passed',
  'failed',
  'skipped',
  'missing',
  'red',
  'stale',
  'synthetic',
  'self-approved',
  'unexpected',
  'duplicate',
  'unconfigured',
];

const totalsFor = (...outcomes) =>
  Object.fromEntries(
    GATE_OUTCOMES.map((outcome) => [
      outcome,
      outcomes.filter((candidate) => candidate === outcome).length,
    ]),
  );

const nullCandidateRecord = () => ({
  headSha: null,
  treeOid: null,
  clean: false,
  dirtyPathRecords: null,
  lockSha256: null,
  schemaSha256: null,
  schemaFileCount: null,
  templateSha256: null,
  templateFileCount: null,
  formTemplateSha256: null,
  formTemplateFileCount: null,
  formSpecCount: null,
  formLayoutCount: null,
  reportTemplateSha256: null,
  reportTemplateFileCount: null,
  reportSpecCount: null,
});

const completeCandidateRecord = () => ({
  headSha: SHA,
  treeOid: TREE,
  clean: true,
  dirtyPathRecords: 0,
  lockSha256: LOCK,
  schemaSha256: SCHEMA,
  schemaFileCount: 21,
  templateSha256: TEMPLATE,
  templateFileCount: 431,
  formTemplateSha256: FORM_TEMPLATE,
  formTemplateFileCount: 176,
  formSpecCount: 160,
  formLayoutCount: 15,
  reportTemplateSha256: REPORT_TEMPLATE,
  reportTemplateFileCount: 255,
  reportSpecCount: 254,
});

const failedGate = () => ({
  id: 'typecheck',
  title: 'Typecheck',
  outcome: 'failed',
  reason: 'command exited 1',
});

const withoutField = (value, field) => {
  const copy = { ...value };
  delete copy[field];
  return copy;
};

const validPreflightRecord = () => ({
  kind: 'datacare.release-certification-preflight/1.0',
  verdict: 'failed',
  stage: 'preflight',
  evaluatedAt: '2026-09-12T00:00:00.000Z',
  releaseSha: SHA,
  workflowRunId: WORKFLOW_RUN_ID,
  approvedRequirementSetHash: null,
  certifierSourceSha256: null,
  requirementSetHash: null,
  candidate: nullCandidateRecord(),
  problems: ['a precise preflight refusal'],
  gatesRun: 0,
});

const validFinalRecord = () => ({
  kind: 'datacare.release-certification/1.0',
  verdict: 'failed',
  evaluatedAt: '2026-09-12T00:00:00.000Z',
  releaseSha: SHA,
  workflowRunId: WORKFLOW_RUN_ID,
  freshnessWindowHours: 24,
  candidate: completeCandidateRecord(),
  requirementSetHash: REQUIREMENTS,
  approvedRequirementSetHash: REQUIREMENTS,
  certifierSourceSha256: CERTIFIER_SOURCE,
  gates: [failedGate()],
  totals: totalsFor('failed'),
});

describe('release certification preflight refusal record', () => {
  it('retains a bounded zero-gate refusal as both immutable and latest records', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      const { named, record } = writePreflightRefusalRecord(root, {
        releaseSha: SHA.toUpperCase(),
        workflowRunId: '12345-2',
        approvedRequirementSetHash: REQUIREMENTS.toUpperCase(),
        certifierSourceSha256: CERTIFIER_SOURCE.toUpperCase(),
        actualRequirementSetHash: REQUIREMENTS,
        candidateIdentity: { headSha: SHA, treeOid: TREE, dirtyPathRecords: 2 },
        candidateInputIdentity: {
          lockSha256: LOCK,
          schemaSha256: SCHEMA,
          schemaFileCount: 21,
        },
        candidateTemplateIdentity: {
          templateSha256: TEMPLATE,
          templateFileCount: 431,
          formTemplateSha256: FORM_TEMPLATE,
          formTemplateFileCount: 176,
          formSpecCount: 160,
          formLayoutCount: 15,
          reportTemplateSha256: REPORT_TEMPLATE,
          reportTemplateFileCount: 255,
          reportSpecCount: 254,
        },
        problems: ['candidate checkout is dirty (2 changed path record(s))'],
        now: new Date('2026-09-11T17:00:00.000Z'),
      });

      expect(record).toMatchObject({
        kind: 'datacare.release-certification-preflight/1.0',
        verdict: 'failed',
        stage: 'preflight',
        releaseSha: SHA,
        workflowRunId: '12345-2',
        approvedRequirementSetHash: REQUIREMENTS,
        certifierSourceSha256: CERTIFIER_SOURCE,
        requirementSetHash: REQUIREMENTS,
        gatesRun: 0,
        candidate: {
          headSha: SHA,
          treeOid: TREE,
          clean: false,
          dirtyPathRecords: 2,
          lockSha256: LOCK,
          schemaSha256: SCHEMA,
          schemaFileCount: 21,
          templateSha256: TEMPLATE,
          templateFileCount: 431,
          formTemplateSha256: FORM_TEMPLATE,
          formTemplateFileCount: 176,
          formSpecCount: 160,
          formLayoutCount: 15,
          reportTemplateSha256: REPORT_TEMPLATE,
          reportTemplateFileCount: 255,
          reportSpecCount: 254,
        },
      });
      const immutable = JSON.parse(readFileSync(named, 'utf8'));
      const latest = JSON.parse(readFileSync(join(root, 'certification-latest.json'), 'utf8'));
      expect(immutable).toEqual(record);
      expect(latest).toEqual(record);
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });

  it('redacts malformed identities and refuses to write a non-refusal', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      const { record } = writePreflightRefusalRecord(root, {
        releaseSha: 'HEAD',
        approvedRequirementSetHash: '/secret/path',
        certifierSourceSha256: 'not-a-digest',
        actualRequirementSetHash: null,
        candidateIdentity: {
          headSha: 'not-a-sha',
          treeOid: null,
          dirtyPathRecords: null,
        },
        candidateInputIdentity: {
          lockSha256: '/secret/path',
          schemaSha256: null,
          schemaFileCount: null,
        },
        candidateTemplateIdentity: {
          templateSha256: '/secret/path',
          templateFileCount: null,
          formTemplateSha256: null,
          formTemplateFileCount: null,
          formSpecCount: null,
          formLayoutCount: null,
          reportTemplateSha256: null,
          reportTemplateFileCount: null,
          reportSpecCount: null,
        },
        problems: ['identity unavailable'],
      });
      expect(record.releaseSha).toBeNull();
      expect(record.workflowRunId).toBeNull();
      expect(record.approvedRequirementSetHash).toBeNull();
      expect(record.certifierSourceSha256).toBeNull();
      expect(record.requirementSetHash).toBeNull();
      expect(record.candidate).toEqual({
        headSha: null,
        treeOid: null,
        clean: false,
        dirtyPathRecords: null,
        lockSha256: null,
        schemaSha256: null,
        schemaFileCount: null,
        templateSha256: null,
        templateFileCount: null,
        formTemplateSha256: null,
        formTemplateFileCount: null,
        formSpecCount: null,
        formLayoutCount: null,
        reportTemplateSha256: null,
        reportTemplateFileCount: null,
        reportSpecCount: null,
      });
      expect(() =>
        writePreflightRefusalRecord(root, {
          releaseSha: SHA,
          problems: [],
        }),
      ).toThrow(/at least one problem/);
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });

  it('creates one generic fallback and preserves a precise record from the same workflow run', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      const first = ensureWorkflowRefusalRecord(root, {
        workflowRunId: WORKFLOW_RUN_ID,
        releaseSha: SHA,
        candidateIdentity: { headSha: SHA, treeOid: TREE, dirtyPathRecords: 0 },
        candidateInputIdentity: {
          lockSha256: LOCK,
          schemaSha256: SCHEMA,
          schemaFileCount: 21,
        },
        now: new Date('2026-09-12T00:00:00.000Z'),
      });
      expect(first.created).toBe(true);
      expect(first.record).toMatchObject({
        workflowRunId: '9001-1',
        gatesRun: 0,
        problems: [expect.stringContaining('before the certifier produced a decision record')],
      });

      const second = ensureWorkflowRefusalRecord(root, {
        workflowRunId: WORKFLOW_RUN_ID,
        releaseSha: SHA.toUpperCase(),
        now: new Date('2026-09-12T01:00:00.000Z'),
      });
      expect(second.created).toBe(false);
      expect(second.record).toEqual(first.record);
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });

  it('preserves a valid final decision from the same workflow run and release SHA', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      const precise = validFinalRecord();
      writeFileSync(join(root, 'certification-latest.json'), JSON.stringify(precise));

      const result = ensureWorkflowRefusalRecord(root, {
        workflowRunId: WORKFLOW_RUN_ID,
        releaseSha: SHA,
      });

      expect(result).toEqual({ created: false, record: precise });
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });

  it('preserves a failed postflight decision whose identity observers returned nulls', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      const precise = {
        ...validFinalRecord(),
        candidate: nullCandidateRecord(),
        gates: [
          {
            id: 'candidate-identity-postflight',
            title: 'Candidate identity postflight',
            outcome: 'failed',
            reason: 'candidate identities could not be observed after the gates ran',
          },
        ],
        totals: totalsFor('failed'),
      };
      writeFileSync(join(root, 'certification-latest.json'), JSON.stringify(precise));

      const result = ensureWorkflowRefusalRecord(root, {
        workflowRunId: WORKFLOW_RUN_ID,
        releaseSha: SHA,
      });

      expect(result).toEqual({ created: false, record: precise });
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });

  it('preserves internally consistent duplicate gate verdicts from a malformed universe', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      const precise = {
        ...validFinalRecord(),
        gates: [failedGate(), failedGate()],
        totals: totalsFor('failed', 'failed'),
      };
      writeFileSync(join(root, 'certification-latest.json'), JSON.stringify(precise));

      const result = ensureWorkflowRefusalRecord(root, {
        workflowRunId: WORKFLOW_RUN_ID,
        releaseSha: SHA,
      });

      expect(result).toEqual({ created: false, record: precise });
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });

  it('overwrites malformed same-run records instead of treating them as decisions', () => {
    const passedGate = { ...failedGate(), outcome: 'passed', reason: 'command passed' };
    const malformedRecords = [
      { ...validPreflightRecord(), releaseSha: 'b'.repeat(40) },
      { ...validPreflightRecord(), verdict: 'green' },
      { ...validPreflightRecord(), evaluatedAt: 'not-a-timestamp' },
      { ...validPreflightRecord(), candidate: [] },
      { ...validPreflightRecord(), kind: 'datacare.release-certification-preflight/0.9' },
      { ...validPreflightRecord(), stage: 'gates' },
      { ...validPreflightRecord(), gatesRun: 1 },
      { ...validPreflightRecord(), problems: [] },
      { ...validPreflightRecord(), problems: ['  '] },
      withoutField(validPreflightRecord(), 'requirementSetHash'),
      { ...validPreflightRecord(), approvedRequirementSetHash: 'not-a-digest' },
      {
        ...validPreflightRecord(),
        candidate: withoutField(nullCandidateRecord(), 'lockSha256'),
      },
      {
        ...validPreflightRecord(),
        candidate: { ...nullCandidateRecord(), dirtyPathRecords: null, clean: true },
      },
      {
        ...validPreflightRecord(),
        candidate: { ...nullCandidateRecord(), schemaFileCount: 0 },
      },
      { ...validFinalRecord(), gates: [] },
      {
        ...validFinalRecord(),
        gates: [{ id: 'typecheck', title: 'Typecheck', outcome: 'green', reason: 'invalid' }],
      },
      { ...validFinalRecord(), gates: [{ ...failedGate(), id: '' }] },
      { ...validFinalRecord(), gates: [{ ...failedGate(), id: 'Typecheck' }] },
      { ...validFinalRecord(), gates: [{ ...failedGate(), title: ' Typecheck' }] },
      { ...validFinalRecord(), gates: [{ ...failedGate(), reason: ' ' }] },
      { ...validFinalRecord(), totals: [] },
      { ...validFinalRecord(), totals: {} },
      { ...validFinalRecord(), totals: { ...totalsFor('failed'), failed: 0 } },
      { ...validFinalRecord(), totals: { ...totalsFor('failed'), extra: 0 } },
      { ...validFinalRecord(), requirementSetHash: 'not-a-digest' },
      { ...validFinalRecord(), approvedRequirementSetHash: '4'.repeat(64) },
      { ...validFinalRecord(), approvedRequirementSetHash: 'not-a-digest' },
      { ...validFinalRecord(), certifierSourceSha256: 'not-a-digest' },
      { ...validFinalRecord(), freshnessWindowHours: 0 },
      { ...validFinalRecord(), verdict: 'passed' },
      {
        ...validFinalRecord(),
        gates: [passedGate],
        totals: totalsFor('passed'),
      },
      {
        ...validFinalRecord(),
        verdict: 'passed',
        gates: [passedGate],
        totals: totalsFor('passed'),
      },
      {
        ...validFinalRecord(),
        verdict: 'passed',
        candidate: nullCandidateRecord(),
        gates: [passedGate],
        totals: totalsFor('passed'),
      },
      {
        ...validFinalRecord(),
        candidate: withoutField(completeCandidateRecord(), 'reportSpecCount'),
      },
      {
        ...validFinalRecord(),
        candidate: { ...completeCandidateRecord(), lockSha256: 'not-a-digest' },
      },
      {
        ...validFinalRecord(),
        candidate: { ...completeCandidateRecord(), dirtyPathRecords: 1 },
      },
    ];

    for (const malformed of malformedRecords) {
      const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
      try {
        writeFileSync(join(root, 'certification-latest.json'), JSON.stringify(malformed));

        const result = ensureWorkflowRefusalRecord(root, {
          workflowRunId: WORKFLOW_RUN_ID,
          releaseSha: SHA,
          now: new Date('2026-09-12T01:00:00.000Z'),
        });

        expect(result.created).toBe(true);
        expect(result.record).toMatchObject({
          kind: 'datacare.release-certification-preflight/1.0',
          verdict: 'failed',
          workflowRunId: WORKFLOW_RUN_ID,
          releaseSha: SHA,
          gatesRun: 0,
          problems: [expect.stringContaining('before the certifier produced a decision record')],
        });
        expect(result.record).not.toEqual(malformed);
      } finally {
        rmSync(root, { recursive: true, force: true });
      }
    }
  });

  it('requires an exact Actions run-attempt identity for fallback attribution', () => {
    const root = mkdtempSync(join(tmpdir(), 'release-certification-record-'));
    try {
      for (const workflowRunId of [undefined, '', '9001', 'run-1', '0-1', '1-0']) {
        expect(() => ensureWorkflowRefusalRecord(root, { workflowRunId, releaseSha: SHA })).toThrow(
          /RELEASE_WORKFLOW_RUN_ID/,
        );
      }
    } finally {
      rmSync(root, { recursive: true, force: true });
    }
  });
});
