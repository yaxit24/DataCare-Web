/** MS_DESIGN_BOOK TEXT_ENTRY/IDTL_KeyDown: navigate the source's editable grid columns.
 * Added web-only preserved fields remain reachable by Tab and pointer. */
export const DESIGN_KEY_FIELDS = [
  'pageNo',
  'designNo',
  'style',
  'grCode',
  'itmSize',
  'dieNo',
  'pcs',
  'grossWt',
  'otherWt',
  'netWt',
  'ghatPct',
  'ghatWt',
  'touch',
  'westPct',
  'fineWt',
  'labourPct',
  'labourType',
  'labourRate',
  'labourAmount',
  'otherAmount',
  'rate',
  'amount',
  'tagCost',
  'purchaseCost',
  'marginPct',
  'mrp',
  'karigarName',
];
export const COMPONENT_KEY_FIELDS = [
  'itCode',
  'pcs',
  'pcsWt',
  'karigarWt',
  'karigarLessPct',
  'grossWt',
  'conversionPct',
  'rateType',
  'rate',
  'amount',
  'labourRate',
  'labourAmount',
  'netAmount',
];
export type DesignGridAction =
  | { kind: 'none' | 'confirmRemove' | 'enterComponents' | 'leaveComponents' }
  | { kind: 'move'; row: number; field: string }
  | { kind: 'append'; field: string };

export function designGridAction(input: {
  key: string;
  field: string;
  value: string;
  row: number;
  rowCount: number;
  fields: readonly string[];
  components?: boolean;
  command?: boolean;
  shift?: boolean;
  alt?: boolean;
  defaultPrevented?: boolean;
  atStart?: boolean;
  atEnd?: boolean;
}): DesignGridAction {
  if (input.defaultPrevented || input.alt || input.shift) return { kind: 'none' };
  if (input.command) return { kind: input.key.toLowerCase() === 'd' ? 'confirmRemove' : 'none' };
  const source = input.components ? COMPONENT_KEY_FIELDS : DESIGN_KEY_FIELDS;
  const fields = source.filter((field) => input.fields.includes(field));
  const col = fields.indexOf(input.field);
  if (col < 0) return { kind: 'none' };
  if (input.key === 'ArrowUp' && input.row > 0)
    return { kind: 'move', row: input.row - 1, field: input.field };
  if (input.key === 'ArrowDown' && input.row < input.rowCount - 1)
    return { kind: 'move', row: input.row + 1, field: input.field };
  // Retain native text editing until the caret reaches the boundary of a web input.
  if (input.key === 'ArrowLeft' && input.atStart && col > 0)
    return { kind: 'move', row: input.row, field: fields[col - 1]! };
  if (input.key === 'ArrowRight' && input.atEnd && col < fields.length - 1)
    return { kind: 'move', row: input.row, field: fields[col + 1]! };
  if (input.key !== 'Enter') return { kind: 'none' };
  if (!input.components && input.field === 'grossWt') return { kind: 'enterComponents' };
  if (input.components && input.field === 'itCode' && !input.value.trim())
    return { kind: 'leaveComponents' };
  if (col < fields.length - 1) return { kind: 'move', row: input.row, field: fields[col + 1]! };
  return input.row < input.rowCount - 1
    ? { kind: 'move', row: input.row + 1, field: fields[0]! }
    : { kind: 'append', field: fields[0]! };
}

export function designComponentReturnField(origin: string, visible: readonly string[]): string {
  const start = DESIGN_KEY_FIELDS.indexOf(origin);
  return (
    DESIGN_KEY_FIELDS.slice(Math.max(0, start + 1)).find((key) => visible.includes(key)) ??
    DESIGN_KEY_FIELDS.find((key) => visible.includes(key)) ??
    'designNo'
  );
}
