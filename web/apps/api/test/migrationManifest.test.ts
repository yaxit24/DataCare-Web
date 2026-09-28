import { createHash } from 'node:crypto';
import { readdirSync, readFileSync } from 'node:fs';
import { expect, it } from 'vitest';
import { EXPECTED_MIGRATIONS } from '../src/modules/ops/migrationManifest.js';

it('pins every shipped Prisma migration exactly once with its actual file checksum', () => {
  const directory = new URL('../../../packages/db/prisma/migrations/', import.meta.url);
  const shipped = readdirSync(directory, { withFileTypes: true })
    .filter((entry) => entry.isDirectory())
    .map((entry) => ({
      name: entry.name,
      checksum: createHash('sha256')
        .update(readFileSync(new URL(`${entry.name}/migration.sql`, directory)))
        .digest('hex'),
    }));
  const byName = (a: { name: string }, b: { name: string }) => a.name.localeCompare(b.name);
  expect(shipped.length).toBeGreaterThan(0);
  expect([...EXPECTED_MIGRATIONS].sort(byName)).toStrictEqual(shipped.sort(byName));
});
