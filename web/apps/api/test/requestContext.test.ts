import { describe, expect, it } from 'vitest';
import {
  correlationId,
  redactLogObject,
  requestCompletedFields,
} from '../src/modules/ops/requestContext.js';

describe('request context', () => {
  it('reuses a well-formed inbound X-Request-Id', () => {
    expect(correlationId('client-request_2026:07.28', () => 'generated-id')).toBe(
      'client-request_2026:07.28',
    );
  });

  it.each(['contains spaces', 'contains/slash', '', 'x'.repeat(129)])(
    'rejects malformed inbound X-Request-Id %j and generates a replacement',
    (value) => {
      expect(correlationId(value, () => 'generated-id')).toBe('generated-id');
    },
  );

  it('keeps credentials, cookies, authorization, and request bodies out of emitted records', () => {
    const secrets = {
      password: 'password-value-never-log',
      token: 'token-value-never-log',
      cookie: 'cookie-value-never-log',
      authorization: 'authorization-value-never-log',
      body: 'request-body-value-never-log',
    };
    const record = requestCompletedFields({
      correlationId: 'safe-id',
      method: 'POST',
      route: '/vouchers',
      status: 201,
      durationMs: 12.3456,
      user: 'operator@example.test',
      ...secrets,
    } as Parameters<typeof requestCompletedFields>[0]);
    const serialized = JSON.stringify(record);

    for (const value of Object.values(secrets)) expect(serialized).not.toContain(value);
    expect(record).toMatchObject({
      event: 'request.completed',
      correlationId: 'safe-id',
      method: 'POST',
      route: '/vouchers',
      status: 201,
      durationMs: 12.346,
    });
    expect(String(record.user)).toMatch(/^sha256:[a-f0-9]{16}$/);

    const redacted = JSON.stringify(
      redactLogObject({
        password: secrets.password,
        nested: {
          accessToken: secrets.token,
          cookie: secrets.cookie,
          authorization: secrets.authorization,
        },
      }),
    );
    for (const value of [secrets.password, secrets.token, secrets.cookie, secrets.authorization]) {
      expect(redacted).not.toContain(value);
    }
    expect(redacted.match(/\[redacted\]/g)).toHaveLength(4);
  });
});
