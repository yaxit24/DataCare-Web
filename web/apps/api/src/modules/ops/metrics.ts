export type RouteClass = 'public' | 'system' | 'form' | 'unknown';
export type VoucherOutcome = 'success' | 'rejected' | 'server_error';

const statusClass = (status: number): string => `${Math.max(0, Math.floor(status / 100))}xx`;
const metricKey = (...labels: string[]): string => labels.join('\u0000');
const labelValue = (value: string): string => value.replace(/\\/g, '\\\\').replace(/"/g, '\\"');

export class MetricsRegistry {
  private readonly requests = new Map<string, number>();
  private readonly voucherWrites = new Map<VoucherOutcome, number>();
  private auditFailures = 0;
  private periodLockRejections = 0;
  private dbProbeLatencyMs = 0;
  private dbProbeUp = 0;
  private dbPoolConnections = 0;
  private dbPoolActiveConnections = 0;

  recordRequest(routeClass: RouteClass, status: number): void {
    const key = metricKey(routeClass, statusClass(status));
    this.requests.set(key, (this.requests.get(key) ?? 0) + 1);
  }

  recordVoucherWrite(outcome: VoucherOutcome): void {
    this.voucherWrites.set(outcome, (this.voucherWrites.get(outcome) ?? 0) + 1);
  }

  recordAuditWriteFailure(): void {
    this.auditFailures += 1;
  }

  recordPeriodLockRejection(): void {
    this.periodLockRejections += 1;
  }

  observeDatabase(input: {
    latencyMs: number;
    up: boolean;
    connections?: number;
    active?: number;
  }): void {
    this.dbProbeLatencyMs = Math.max(0, input.latencyMs);
    this.dbProbeUp = input.up ? 1 : 0;
    this.dbPoolConnections = Math.max(0, input.connections ?? 0);
    this.dbPoolActiveConnections = Math.max(0, input.active ?? 0);
  }

  snapshot(): Record<string, unknown> {
    return {
      requests: Object.fromEntries(this.requests),
      voucherWrites: Object.fromEntries(this.voucherWrites),
      auditWriteFailures: this.auditFailures,
      periodLockRejections: this.periodLockRejections,
      database: {
        latencyMs: this.dbProbeLatencyMs,
        up: this.dbProbeUp,
        connections: this.dbPoolConnections,
        activeConnections: this.dbPoolActiveConnections,
      },
    };
  }

  prometheus(): string {
    const lines = [
      '# HELP datacare_http_requests_total Completed HTTP requests.',
      '# TYPE datacare_http_requests_total counter',
    ];
    for (const [key, value] of [...this.requests].sort(([a], [b]) => a.localeCompare(b))) {
      const [routeClass = 'unknown', status = '0xx'] = key.split('\u0000');
      lines.push(
        `datacare_http_requests_total{route_class="${labelValue(routeClass)}",status_class="${labelValue(status)}"} ${value}`,
      );
    }
    lines.push(
      '# HELP datacare_voucher_writes_total Voucher write requests by outcome.',
      '# TYPE datacare_voucher_writes_total counter',
    );
    for (const outcome of ['success', 'rejected', 'server_error'] as const) {
      lines.push(
        `datacare_voucher_writes_total{outcome="${outcome}"} ${this.voucherWrites.get(outcome) ?? 0}`,
      );
    }
    lines.push(
      '# HELP datacare_audit_write_failures_total Failed audit persistence attempts.',
      '# TYPE datacare_audit_write_failures_total counter',
      `datacare_audit_write_failures_total ${this.auditFailures}`,
      '# HELP datacare_period_lock_rejections_total Voucher writes rejected by period lock.',
      '# TYPE datacare_period_lock_rejections_total counter',
      `datacare_period_lock_rejections_total ${this.periodLockRejections}`,
      '# HELP datacare_db_probe_latency_ms Latest database probe latency.',
      '# TYPE datacare_db_probe_latency_ms gauge',
      `datacare_db_probe_latency_ms ${this.dbProbeLatencyMs.toFixed(3)}`,
      '# HELP datacare_db_probe_up Whether the latest database probe succeeded.',
      '# TYPE datacare_db_probe_up gauge',
      `datacare_db_probe_up ${this.dbProbeUp}`,
      '# HELP datacare_db_pool_connections Current database connections for this database.',
      '# TYPE datacare_db_pool_connections gauge',
      `datacare_db_pool_connections ${this.dbPoolConnections}`,
      '# HELP datacare_db_pool_active_connections Current active database connections.',
      '# TYPE datacare_db_pool_active_connections gauge',
      `datacare_db_pool_active_connections ${this.dbPoolActiveConnections}`,
    );
    return `${lines.join('\n')}\n`;
  }
}

export async function collectDatabaseMetrics(
  prisma: any,
  registry: MetricsRegistry,
): Promise<void> {
  const started = performance.now();
  try {
    const rows: Array<{ connections: unknown; active: unknown }> = await prisma.$queryRawUnsafe(
      `SELECT COUNT(*)::int AS connections,
              COUNT(*) FILTER (WHERE state = 'active')::int AS active
         FROM pg_stat_activity
        WHERE datname = current_database()`,
    );
    registry.observeDatabase({
      latencyMs: performance.now() - started,
      up: true,
      connections: Number(rows[0]?.connections ?? 0),
      active: Number(rows[0]?.active ?? 0),
    });
  } catch {
    registry.observeDatabase({ latencyMs: performance.now() - started, up: false });
  }
}
