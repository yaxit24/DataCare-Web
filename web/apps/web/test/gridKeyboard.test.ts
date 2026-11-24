import { describe, expect, it } from 'vitest';
import { planEnterWalk, resolveGridKey } from '../components/GridKeyboard';

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

describe('G96: the Enter walk lands on editable cells only (TR_KR_ISU.cs:3743 skip loop)', () => {
  // Purchase Return's compact row: 8 inputs, then Fine and Amount text cells and the row's delete button.
  const editable = (column: number) => column < 8;
  it('skips the read-only Fine, Amount and delete cells and wraps to the next row Item', () => {
    expect(planEnterWalk(editable, { row: 0, column: 8 }, 2, 11)).toEqual({
      type: 'focus',
      row: 1,
      column: 0,
    });
  });
  it('steps one editable cell inside a row', () => {
    expect(planEnterWalk(editable, { row: 0, column: 3 }, 2, 11)).toEqual({
      type: 'focus',
      row: 0,
      column: 3,
    });
  });
  it('skips a read-only cell in the middle of a row', () => {
    expect(planEnterWalk((c) => c !== 4, { row: 1, column: 4 }, 3, 8)).toEqual({
      type: 'focus',
      row: 1,
      column: 5,
    });
  });
  it('appends a row after the last editable cell of the last row (TR_KR_ISU.cs:3680)', () => {
    expect(planEnterWalk(editable, { row: 1, column: 8 }, 2, 11)).toEqual({
      type: 'append',
      row: 2,
    });
  });
  it('gives up without looping when no cell is editable', () => {
    expect(planEnterWalk(() => false, { row: 0, column: 0 }, 1, 3)).toEqual({
      type: 'append',
      row: 1,
    });
  });
});
