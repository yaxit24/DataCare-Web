import { describe, it, expect } from 'vitest';
import * as gate from '../src/modules/rbac/editionGate.js';

// Owner decision 2026-11-25 extends desktop Lite; DC_Main.cs:1491-1502 defines A/B/C.
describe('dataTypes plan feature', () => {
  it('defaults on in every edition and respects explicit tenant opt-out', () => {
    const enabled = (gate as any).dataTypesEnabled;
    expect(typeof enabled).toBe('function');
    for (const code of ['L', 'B', 'S', 'P', 'A', 'E']) {
      expect(enabled({ code })).toBe(true);
      expect(enabled({ code, features: { dataTypes: false } })).toBe(false);
    }
  });
});
