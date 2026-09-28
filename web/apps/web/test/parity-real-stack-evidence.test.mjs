import test from 'node:test';
import assert from 'node:assert/strict';
import {
  aggregateRealStackEvidence,
  summarizeJourneyEvidence,
} from './parity-real-stack-evidence.mjs';

test('accepts an assertion-backed journey and derives zero provenance counters', () => {
  const summary = summarizeJourneyEvidence('design-book', { checks: ['saved and reopened'] });
  assert.deepEqual(summary, {
    journey: { journeyId: 'design-book', status: 'passed' },
    provenance: { mockedRequests: 0, mockedResponses: 0, interceptionIndicators: 0 },
    problems: [],
  });
  assert.deepEqual(aggregateRealStackEvidence([summary]), {
    mockedRequests: 0,
    mockedResponses: 0,
    interceptionIndicators: 0,
    problems: [],
  });
});

test('uses an explicit journey status and fails closed on missing checks or result objects', () => {
  for (const detail of [null, true, {}, { checks: [] }, { checks: ['ok'], status: 'failed' }]) {
    const summary = summarizeJourneyEvidence('credit-note', detail);
    assert.equal(summary.journey.status, 'failed');
    assert(summary.problems.length > 0);
  }
});

test('detects nested mock, response, and interception indicators', () => {
  const summary = summarizeJourneyEvidence('order-images', {
    status: 'passed',
    checks: ['real request'],
    mockedRequests: 2,
    network: { mockedResponses: 1, routeInterceptions: true },
  });
  assert.equal(summary.journey.status, 'failed');
  assert.deepEqual(summary.provenance, {
    mockedRequests: 2,
    mockedResponses: 1,
    interceptionIndicators: 1,
  });
  assert.equal(summary.problems.length, 3);
});

test('detects mock indicators nested inside arrays', () => {
  const summary = summarizeJourneyEvidence('order-images', {
    checks: ['real request'],
    network: [{ request: { mockedResponses: 1 } }],
  });
  assert.equal(summary.journey.status, 'failed');
  assert.equal(summary.provenance.mockedResponses, 1);
  assert.deepEqual(summary.problems, ['order-images.network[0].request.mockedResponses reports 1']);
});

test('rejects malformed provenance instead of coercing it to zero', () => {
  for (const value of [null, false, '0', [], {}, -1, 0.5, Number.NaN]) {
    const summary = summarizeJourneyEvidence('tour-order', {
      checks: ['real request'],
      mockedRequests: value,
    });
    assert.equal(summary.journey.status, 'failed', String(value));
    assert.match(summary.problems.join('\n'), /must be a non-negative integer/);
  }
});

test('runner-observed route registration fails the aggregate evidence', () => {
  const summary = summarizeJourneyEvidence('sales-order', {
    checks: ['real request'],
    mockedRequests: 0,
    mockedResponses: 0,
  });
  assert.deepEqual(aggregateRealStackEvidence([summary], 1), {
    mockedRequests: 0,
    mockedResponses: 0,
    interceptionIndicators: 1,
    problems: ['runner registered 1 request interception route(s)'],
  });
});
