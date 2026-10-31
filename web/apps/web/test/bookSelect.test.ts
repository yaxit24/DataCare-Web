import * as React from 'react';
import { createElement } from 'react';
import { renderToStaticMarkup } from 'react-dom/server';
import { describe, expect, it } from 'vitest';
import { BookSelect } from '../components/BookSelect';

// The component relies on Next's automatic JSX runtime; this test runner compiles JSX to React.createElement, which
// the component body resolves at render time.
(globalThis as { React?: typeof React }).React = React;

// N189 (G199): a voucher's own book stays required; a reference to another voucher's book can opt out, because a
// purchase return needs only a party and a voucher number (TR_KR_ISU.cs:4986-4999).
describe('BookSelect required', () => {
  const render = (props: Record<string, unknown> = {}) =>
    renderToStaticMarkup(createElement(BookSelect, { value: '', onChange: () => {}, ...props }));

  it('is required by default', () => {
    expect(render()).toMatch(/<select[^>]*\srequired(=""|\s|>)/);
  });

  it('is optional when the screen says so', () => {
    expect(render({ required: false })).not.toMatch(/\srequired/);
  });
});
