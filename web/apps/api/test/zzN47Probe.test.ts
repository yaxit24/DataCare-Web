import { expect, it } from 'vitest';

// N47 scratch proof: deliberate test type error. Never merge.
const count: number = 'not a number';
it('n47 probe', () => expect(count).toBeDefined());
