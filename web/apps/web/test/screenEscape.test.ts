import { describe, expect, it } from 'vitest';
import { isKeyAroundScreen } from '../lib/screenEscape';

/** A tiny tree with Node's `contains` (inclusive), enough for the predicate without a DOM. */
type FakeNode = { name: string; parent: FakeNode | null; contains(other: unknown): boolean };
function node(name: string, parent: FakeNode | null = null): FakeNode {
  const self: FakeNode = {
    name,
    parent,
    contains(other: unknown) {
      for (let at = other as FakeNode | null; at; at = at.parent) if (at === self) return true;
      return false;
    },
  };
  return self;
}

describe('isKeyAroundScreen (GB-02, G239: Esc with no focused control)', () => {
  const body = node('body');
  const main = node('main', body);
  const screen = node('screen', main);
  const box = node('box', screen);
  const header = node('header', body);
  const company = node('company', header);
  const around = (target: unknown) =>
    isKeyAroundScreen(screen as unknown as Node, target as EventTarget | null);

  it('takes a key aimed at the page body or a page container around the screen', () => {
    expect(around(body)).toBe(true);
    expect(around(main)).toBe(true);
  });

  it("leaves a key aimed at the screen or inside it to the wrapper's own handler", () => {
    expect(around(screen)).toBe(false);
    expect(around(box)).toBe(false);
  });

  it('leaves a key aimed at the header or sidebar controls to them', () => {
    expect(around(header)).toBe(false);
    expect(around(company)).toBe(false);
  });

  it('takes nothing before the screen is mounted or without a node target', () => {
    expect(isKeyAroundScreen(null, body as unknown as EventTarget)).toBe(false);
    expect(around(null)).toBe(false);
    expect(around({})).toBe(false);
  });
});
