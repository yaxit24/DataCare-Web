/**
 * Pure helpers for scripts/parity-test-env.mjs (N49 step 3), kept apart so they can be unit-tested
 * (apps/api/test/parityTestEnv.test.mjs).
 */
import { createHash } from 'node:crypto';

export const DEFAULT_PARITY_TEST_PORT = '55433';
const APPLICATION_DATABASE_PORT = '5433';

/**
 * The Compose project for a checkout. By default a stable hash of the checkout's real path, so two
 * worktrees never share a container or volume; `PARITY_TEST_PROJECT` overrides it.
 */
export function parityTestProject(checkoutPath, override) {
  const name = override?.trim();
  if (name) {
    if (!/^[a-z0-9][a-z0-9_-]{0,62}$/.test(name))
      throw new Error(
        'PARITY_TEST_PROJECT must start with a lowercase letter or digit and contain only a-z, 0-9, - or _',
      );
    return name;
  }
  return `datacare-parity-${createHash('sha256').update(checkoutPath).digest('hex').slice(0, 12)}`;
}

/** The loopback port the disposable database listens on: `PARITY_TEST_PORT`, default 55433. */
export function parityTestPort(value) {
  const port = value?.trim() || DEFAULT_PARITY_TEST_PORT;
  if (!/^\d{4,5}$/.test(port) || Number(port) < 1024 || Number(port) > 65535)
    throw new Error('PARITY_TEST_PORT must be a whole port number from 1024 to 65535');
  if (port === APPLICATION_DATABASE_PORT)
    throw new Error('PARITY_TEST_PORT 5433 is the application database port');
  return port;
}

/**
 * What changed between the database identity recorded before the command ran and the one found after it.
 * A different container ID means the container was replaced; a different system identifier means a
 * different PostgreSQL cluster answered (a new volume, or another server on the port).
 */
export function parityTestIdentityChanges(before, after) {
  const changes = [];
  if (!after.containerId) changes.push(`container ${before.containerId} is gone`);
  else if (after.containerId !== before.containerId)
    changes.push(`container ${before.containerId} was replaced by ${after.containerId}`);
  if (after.systemIdentifier !== before.systemIdentifier)
    changes.push(
      `system identifier ${before.systemIdentifier} became ${after.systemIdentifier || '(unreadable)'}`,
    );
  return changes;
}
