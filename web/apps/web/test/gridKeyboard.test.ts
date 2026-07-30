import { describe, expect, it } from 'vitest';
import { resolveGridKey } from '../components/GridKeyboard';

const base = {
  row: 1,
  column: 1,
  rowCount: 3,
  columnCount: 4,
};

describe('desktop grid keyboard decision table', () => {
  it('moves vertically in the same editable column without wrapping', () => {
    expect(resolveGridKey({ ...base, key: 'ArrowUp' })).toEqual({
      type: 'move',
      row: 0,
      column: 1,
    });
    expect(resolveGridKey({ ...base, key: 'ArrowDown' })).toEqual({
      type: 'move',
      row: 2,
      column: 1,
    });
    expect(resolveGridKey({ ...base, key: 'ArrowDown', row: 2 })).toEqual({ type: 'none' });
  });

  it('moves horizontally only when the text caret is at the corresponding edge', () => {
    expect(resolveGridKey({ ...base, key: 'ArrowLeft', atHorizontalStart: false })).toEqual({
      type: 'none',
    });
    expect(resolveGridKey({ ...base, key: 'ArrowLeft', atHorizontalStart: true })).toEqual({
      type: 'move',
      row: 1,
      column: 0,
    });
    expect(resolveGridKey({ ...base, key: 'ArrowRight', atHorizontalEnd: true })).toEqual({
      type: 'move',
      row: 1,
      column: 2,
    });
  });

  it('advances Enter across cells, then rows, then appends at the last cell', () => {
    expect(resolveGridKey({ ...base, key: 'Enter' })).toEqual({
      type: 'move',
      row: 1,
      column: 2,
    });
    expect(resolveGridKey({ ...base, key: 'Enter', column: 3 })).toEqual({
      type: 'move',
      row: 2,
      column: 0,
    });
    expect(resolveGridKey({ ...base, key: 'Enter', row: 2, column: 3 })).toEqual({
      type: 'append',
      row: 3,
      column: 0,
    });
  });

  it('maps extracted Escape and Ctrl/Cmd+D while preserving save and paste commands', () => {
    expect(resolveGridKey({ ...base, key: 'Escape' })).toEqual({ type: 'escape' });
    expect(resolveGridKey({ ...base, key: 'd', ctrlKey: true })).toEqual({
      type: 'remove',
      row: 1,
    });
    expect(resolveGridKey({ ...base, key: 'D', metaKey: true })).toEqual({
      type: 'remove',
      row: 1,
    });
    expect(resolveGridKey({ ...base, key: 'Enter', ctrlKey: true })).toEqual({ type: 'none' });
    expect(resolveGridKey({ ...base, key: 'v', ctrlKey: true })).toEqual({ type: 'none' });
  });

  it('does not override child controls or modified key combinations', () => {
    expect(resolveGridKey({ ...base, key: 'Enter', defaultPrevented: true })).toEqual({
      type: 'none',
    });
    expect(resolveGridKey({ ...base, key: 'Enter', shiftKey: true })).toEqual({ type: 'none' });
    expect(resolveGridKey({ ...base, key: 'ArrowDown', altKey: true })).toEqual({ type: 'none' });
  });
});
