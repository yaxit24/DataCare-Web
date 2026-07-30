import { describe, expect, it } from 'vitest';
import { MetricsRegistry } from '../src/modules/ops/metrics.js';

describe('MetricsRegistry', () => {
  it('counts requests, voucher outcomes, audit failures, and period-lock rejections', () => {
    const registry = new MetricsRegistry();
    registry.recordRequest('public', 200);
    registry.recordRequest('public', 204);
    registry.recordRequest('form', 422);
    registry.recordRequest('system', 503);
    registry.recordVoucherWrite('success');
    registry.recordVoucherWrite('success');
    registry.recordVoucherWrite('rejected');
    registry.recordVoucherWrite('server_error');
    registry.recordAuditWriteFailure();
    registry.recordAuditWriteFailure();
    registry.recordPeriodLockRejection();

    expect(registry.snapshot()).toEqual({
      requests: {
        ['public\0' + '2xx']: 2,
        ['form\0' + '4xx']: 1,
        ['system\0' + '5xx']: 1,
      },
      voucherWrites: { success: 2, rejected: 1, server_error: 1 },
      auditWriteFailures: 2,
      periodLockRejections: 1,
      database: { latencyMs: 0, up: 0, connections: 0, activeConnections: 0 },
    });
  });

  it('renders valid Prometheus text with all counters and database gauges', () => {
    const registry = new MetricsRegistry();
    registry.recordRequest('unknown', 404);
    registry.recordVoucherWrite('rejected');
    registry.recordAuditWriteFailure();
    registry.recordPeriodLockRejection();
    registry.observeDatabase({ latencyMs: 1.23456, up: true, connections: 7, active: 2 });

    const text = registry.prometheus();
    expect(text).toContain('# TYPE datacare_http_requests_total counter');
    expect(text).toContain(
      'datacare_http_requests_total{route_class="unknown",status_class="4xx"} 1',
    );
    expect(text).toContain('datacare_voucher_writes_total{outcome="success"} 0');
    expect(text).toContain('datacare_voucher_writes_total{outcome="rejected"} 1');
    expect(text).toContain('datacare_voucher_writes_total{outcome="server_error"} 0');
    expect(text).toContain('datacare_audit_write_failures_total 1');
    expect(text).toContain('datacare_period_lock_rejections_total 1');
    expect(text).toContain('datacare_db_probe_latency_ms 1.235');
    expect(text).toContain('datacare_db_probe_up 1');
    expect(text).toContain('datacare_db_pool_connections 7');
    expect(text).toContain('datacare_db_pool_active_connections 2');
    expect(text.endsWith('\n')).toBe(true);
  });
});

describe('load profile summarizer', () => {
  it('uses nearest-rank percentiles and reports errors per operation', async () => {
    const { percentile, summarizeResults } = await import('../../../scripts/load-profile.mjs');
    expect(percentile([40, 10, 30, 20], 0.5)).toBe(20);
    expect(percentile([40, 10, 30, 20], 0.95)).toBe(40);
    expect(percentile([], 0.99)).toBe(0);
    expect(() => percentile([1], 1.1)).toThrow('quantile');

    expect(
      summarizeResults([
        { operation: 'read', durationMs: 10, ok: true },
        { operation: 'read', durationMs: 20, ok: false },
        { operation: 'create', durationMs: 5, ok: true },
      ]),
    ).toEqual({
      create: { requests: 1, errors: 0, p50Ms: 5, p95Ms: 5, p99Ms: 5 },
      read: { requests: 2, errors: 1, p50Ms: 10, p95Ms: 20, p99Ms: 20 },
    });
  });
});
