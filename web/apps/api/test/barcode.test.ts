import { describe, it, expect } from 'vitest';
import { code39Svg, renderTagLabels } from '../src/modules/stock/tagPrint.js';

// Standard Code39 element table (same as the encoder) for building a reverse decoder.
const CODE39: Record<string, string> = {
  '0': 'nnnwwnwnn',
  '1': 'wnnwnnnnw',
  '2': 'nnwwnnnnw',
  '3': 'wnwwnnnnn',
  '4': 'nnnwwnnnw',
  '5': 'wnnwwnnnn',
  '6': 'nnwwwnnnn',
  '7': 'nnnwnnwnw',
  '8': 'wnnwnnwnn',
  '9': 'nnwwnnwnn',
  A: 'wnnnnwnnw',
  B: 'nnwnnwnnw',
  C: 'wnwnnwnnn',
  D: 'nnnnwwnnw',
  E: 'wnnnwwnnn',
  F: 'nnwnwwnnn',
  G: 'nnnnnwwnw',
  H: 'wnnnnwwnn',
  I: 'nnwnnwwnn',
  J: 'nnnnwwwnn',
  K: 'wnnnnnnww',
  L: 'nnwnnnnww',
  M: 'wnwnnnnwn',
  N: 'nnnnwnnww',
  O: 'wnnnwnnwn',
  P: 'nnwnwnnwn',
  Q: 'nnnnnnwww',
  R: 'wnnnnnwwn',
  S: 'nnwnnnwwn',
  T: 'nnnnwnwwn',
  U: 'wwnnnnnnw',
  V: 'nwwnnnnnw',
  W: 'wwwnnnnnn',
  X: 'nwnnwnnnw',
  Y: 'wwnnwnnnn',
  Z: 'nwwnwnnnn',
  '-': 'nwnnnnwnw',
  '.': 'wwnnnnwnn',
  ' ': 'nwwnnnwnn',
  '*': 'nwnnwnwnn',
  $: 'nwnwnwnnn',
  '/': 'nwnwnnnwn',
  '+': 'nwnnnwnwn',
  '%': 'nnnwnwnwn',
};
const REV: Record<string, string> = Object.fromEntries(
  Object.entries(CODE39).map(([k, v]) => [v, k]),
);

/** Decode a code39Svg() output back to its text by reading bars + inter-bar gaps (proves scannability). */
function decode(svg: string): string {
  const bars = [...svg.matchAll(/<rect x="(\d+)" y="0" width="(\d+)"/g)]
    .map((m) => ({ x: +m[1], w: +m[2] }))
    .sort((a, b) => a.x - b.x);
  const cls = (w: number) => (w >= 6 ? 'w' : 'n');
  let out = '';
  for (let k = 0; k + 5 <= bars.length; k += 5) {
    const b = bars.slice(k, k + 5);
    const el: string[] = [];
    for (let i = 0; i < 5; i++) {
      el.push(cls(b[i].w)); // bar
      if (i < 4) el.push(cls(b[i + 1].x - (b[i].x + b[i].w))); // intra-char space
    }
    out += REV[el.join('')] ?? '?';
  }
  return out;
}

describe('Code39 tag barcode (scannable)', () => {
  it('round-trips alphanumeric tag through encode→decode', () => {
    expect(decode(code39Svg('RG1'))).toBe('*RG1*');
    expect(decode(code39Svg('00123'))).toBe('*00123*');
    expect(decode(code39Svg('ABC-9'))).toBe('*ABC-9*');
  });
  it('bar count matches Code39 (5 bars per char incl. start/stop)', () => {
    expect((code39Svg('RG1').match(/<rect/g) || []).length).toBe(5 * 5); // *RG1* = 5 chars
    expect(code39Svg('X').startsWith('<svg')).toBe(true);
  });
  it('label sheet embeds real barcode + HUID + weights', () => {
    const html = renderTagLabels([
      {
        tagNo: 'RG1',
        itCode: 'G22',
        designNo: 'D1',
        tblCode: null,
        netWt: 10,
        grossWt: 10.5,
        touch: 91.6,
        mrp: 60000,
        rate: 5000,
        hmId: 'HUID123456',
        pcs: 1,
      },
    ]);
    expect(html).toContain('<svg');
    expect(html).toContain('HUID123456');
    expect(html).toContain('RG1');
    expect(html).toContain('MRP');
  });
});
