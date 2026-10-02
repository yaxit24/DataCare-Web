/** Read-only PostgreSQL storage checks; no saved Return writer is exercised. */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { qualifySaleReturnHeaderFloat } from '@datacare/core';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import fixture from './fixtures/saleReturnHeaderFloat.storage.json' with { type: 'json' };
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const fields = ['RTN_BILL_OS', 'RTN_NET_AMT', 'RTN_TOT_AMT'];
const values = (text: string) => ({ RTN_NET_AMT: text, RTN_TOT_AMT: text, RTN_BILL_OS: text });

run('saved Return exact header Float profile against actual PostgreSQL', () => {
  let prisma: PrismaClient;
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    prisma = new PrismaClient();
    const roles = await prisma.$queryRawUnsafe<Array<{ rolsuper: boolean; rolbypassrls: boolean }>>(
      'SELECT rolsuper,rolbypassrls FROM pg_roles WHERE rolname=current_user',
    );
    expect(roles).toEqual([{ rolsuper: false, rolbypassrls: false }]);
  });
  afterAll(async () => {
    if (prisma) await prisma.$disconnect();
  });

  it('confirms all three real header columns are double precision', async () => {
    const columns = await prisma.$queryRawUnsafe<Array<{ name: string; type: string }>>(
      `SELECT attname AS name,format_type(atttypid,atttypmod) AS type FROM pg_attribute
       WHERE attrelid='"SL_DATA"'::regclass AND attname=ANY($1::text[]) AND NOT attisdropped ORDER BY attname`,
      fields,
    );
    expect(columns).toEqual(fields.map((name) => ({ name, type: 'double precision' })));
  });

  it.each(fixture.accepted)(
    'preserves the independently specified binary64 bits for $decimal',
    async (vector) => {
      const qualified = qualifySaleReturnHeaderFloat(values(vector.decimal));
      expect(qualified.status).toBe('ready');
      if (qualified.status !== 'ready')
        throw new Error('Expected exact mathematical storage value');
      expect(qualified.canCommit).toBe(false);
      const rows = await withTenant(prisma, 'r14-header-float', (tx) =>
        tx.$queryRawUnsafe<Array<{ net: string; total: string; outstanding: string }>>(
          `SELECT encode(float8send($1::double precision),'hex') AS net,
                encode(float8send($2::double precision),'hex') AS total,
                encode(float8send($3::double precision),'hex') AS outstanding`,
          qualified.values.RTN_NET_AMT,
          qualified.values.RTN_TOT_AMT,
          qualified.values.RTN_BILL_OS,
        ),
      );
      expect(rows).toEqual([{ net: vector.hex, total: vector.hex, outstanding: vector.hex }]);
    },
  );

  it('keeps decimal0.1 outside this exact profile although PostgreSQL can round it to a nearest float', async () => {
    const example = fixture.rejectedExample;
    expect(qualifySaleReturnHeaderFloat(values(example.decimal))).toMatchObject({
      status: 'unsupported',
      values: null,
      canCommit: false,
      diagnostic: { code: example.qualifierDiagnostic },
    });
    const rows = await prisma.$queryRawUnsafe<Array<{ bits: string }>>(
      `SELECT encode(float8send($1::double precision),'hex') AS bits`,
      example.decimal,
    );
    expect(rows).toEqual([{ bits: example.postgresNearestBits }]);
  });
});
