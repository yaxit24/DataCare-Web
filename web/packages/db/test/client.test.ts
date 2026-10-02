import { describe, expect, it } from 'vitest';
import { PrismaClient, prismaConnectionString } from '../src/index.js';

describe('Prisma 7 PostgreSQL adapter boundary', () => {
  it('preserves legacy datasource precedence without reading a different process URL', () => {
    expect(
      prismaConnectionString(
        {
          datasources: { db: { url: 'postgresql://owner@127.0.0.1:55434/datacare' } },
          datasourceUrl: 'postgresql://second@127.0.0.1:55434/datacare',
        },
        { DATABASE_URL: 'postgresql://runtime@127.0.0.1:55434/datacare' },
      ),
    ).toBe('postgresql://owner@127.0.0.1:55434/datacare');
    expect(
      prismaConnectionString(
        { datasourceUrl: 'postgresql://second@127.0.0.1:55434/datacare' },
        { DATABASE_URL: 'postgresql://runtime@127.0.0.1:55434/datacare' },
      ),
    ).toBe('postgresql://second@127.0.0.1:55434/datacare');
    expect(prismaConnectionString({}, { DATABASE_URL: 'postgresql://runtime/db' })).toBe(
      'postgresql://runtime/db',
    );
  });

  it('allows a deliberately skipped database suite to construct and disconnect without a URL', async () => {
    const client = new PrismaClient({ datasources: { db: { url: '' } } });
    await expect(client.$disconnect()).resolves.toBeUndefined();
  });
});
