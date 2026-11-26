import { expect, it } from 'vitest';
import { utilityRefusalText } from '../src/modules/rbac/utilityRefusal.js';

it('uses the desktop Print refusal for restore even when the admin gate denies create', () => {
  expect(utilityRefusalText('/backup/restore', 'create')).toBe('You Have No Print Rights.....');
  expect(utilityRefusalText('/backup', 'print')).toBe('You Have No Print Rights.....');
  expect(utilityRefusalText('/years', 'create')).toBe('You Have No Rights.....');
  expect(utilityRefusalText('/backup-other', 'create')).toBeUndefined();
});
