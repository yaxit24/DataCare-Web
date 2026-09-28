import { Decimal } from 'decimal.js';
import { decimalCellText } from './money.js';
import {
  createSaleReturnIncomingState,
  type SaleReturnIncomingRaw,
  type SaleReturnIncomingState,
} from './saleReturnIncoming.js';

/** Saved primary MSG_PR projection, TR_SALE_RTN.cs:10353–10438.
 * This is the declared mathematical display profile, not measured VB DBNull,
 * Double/Format/culture parity. It performs no event, calculation or admission.
 */
export const SALE_RETURN_INCOMING_PROJECTION_VERSION = 'saved-primary-incoming-projection-v1';

export type SaleReturnIncomingProjectionCode =
  | 'invalid-projection-input'
  | 'missing-saved-column'
  | 'unsupported-numeric-null'
  | 'invalid-saved-decimal'
  | 'unsupported-saved-precision'
  | 'missing-item-master'
  | 'ambiguous-item-master'
  | 'unresolved-item-type-binding'
  | 'invalid-editor-state';
export interface SaleReturnIncomingProjectionDiagnostic {
  readonly code: SaleReturnIncomingProjectionCode;
  readonly fieldId?: string;
  readonly message: string;
}
export type SaleReturnIncomingProjectionResult =
  | { readonly status: 'ready'; readonly state: SaleReturnIncomingState }
  | {
      readonly status: 'unsupported';
      readonly diagnostics: readonly SaleReturnIncomingProjectionDiagnostic[];
    };
export interface SavedSaleReturnIncomingProjectionInput {
  readonly rowIdentity: string;
  readonly ordinal: number;
  readonly raw: SaleReturnIncomingRaw;
  readonly itemMasters: readonly SaleReturnIncomingRaw[];
}
export type SaleReturnIncomingEditorTextResult =
  | { readonly status: 'ready'; readonly editorTextByField: Readonly<Record<string, string>> }
  | {
      readonly status: 'unsupported';
      readonly diagnostics: readonly SaleReturnIncomingProjectionDiagnostic[];
    };

export const SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS = Object.freeze([
  19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38,
] as const);

const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const TEXT = {
  1: 'IT_CODE',
  2: 'TAG_NO',
  4: 'TBL_CODE',
  5: 'DESIGN_NO',
  6: 'ITM_STYLE',
  7: 'ITM_SIZE',
  8: 'HM_ID',
  13: 'LBR_CODE',
  22: 'LBR_TYPE',
  39: 'KR_NAME',
  40: 'VCH_SRNO',
  43: 'IT_TYPE',
  44: 'RATE_TYPE',
  50: 'APR_ISU',
  52: 'PR_CODE',
  53: 'PR_CODE',
  54: 'TAG_TYPE',
  55: 'TAG_TYPE',
  59: 'HM_ID2',
  60: 'HM_ID3',
  61: 'HM_ID4',
  68: 'EMP_ISU',
  69: 'DESIGN_IMG_ID',
  70: 'DATA_TYPE',
} as const;
const FORMATTED = {
  10: ['ITM_GWT', 3],
  11: ['ITM_OTH_WT', 3],
  12: ['ITM_NWT', 3],
  14: ['ITM_GHT_PRC', 2],
  15: ['ITM_GHT_WT', 3],
  16: ['ITM_TOUCH', 2],
  17: ['ITM_WEST_PRC', 2],
  18: ['ITM_FINE', 3],
  19: ['ITM_RATE', 2],
  20: ['ITM_AMT', 2],
  21: ['LBR_PRC', 2],
  23: ['LBR_RATE', 2],
  24: ['LBR_AMT', 2],
  25: ['DISC_PRC', 2],
  26: ['DISC_AMT', 2],
  27: ['OTH_AMT', 2],
  28: ['ITM_MRP', 2],
  30: ['TAG_LBR_PRC', 2],
  31: ['TAG_LBR_RATE', 2],
  32: ['TAG_LBR_AMT', 2],
  33: ['TAG_OTH_AMT', 2],
  34: ['TAG_COST', 2],
  35: ['TAG_MRP', 2],
  36: ['TOT_AMT', 2],
  37: ['TAX_PRC', 2],
  38: ['NET_AMT', 2],
  51: ['OLD_SRNO', 0],
  56: ['TAG_SRNO', 0],
  62: ['HM_ID_WT', 3],
  63: ['HM_ID2_WT', 3],
  64: ['HM_ID3_WT', 3],
  65: ['HM_ID4_WT', 3],
} as const;
const object = (value: unknown): value is Record<string, unknown> =>
  !!value && typeof value === 'object' && !Array.isArray(value);
const rawRecord = (value: unknown): value is SaleReturnIncomingRaw =>
  object(value) && Object.values(value).every((cell) => cell === null || typeof cell === 'string');
const fieldId = (column: number) => 'x13.primary-incoming.c' + String(column).padStart(2, '0');

/** Inputs are trusted server observations, never a client-supplied baseline.
 * Missing/NULL numeric source values reject this whole initial projection; raw
 * read access remains separate. Text concatenation's blank display never changes
 * the retained raw NULL. Eight caches are seeded only after source formatting.
 */
export function projectSavedSaleReturnIncoming(
  input: SavedSaleReturnIncomingProjectionInput,
): SaleReturnIncomingProjectionResult {
  const diagnostics: SaleReturnIncomingProjectionDiagnostic[] = [];
  const add = (code: SaleReturnIncomingProjectionCode, message: string, column?: number) => {
    diagnostics.push(
      Object.freeze({
        code,
        message,
        ...(column === undefined ? {} : { fieldId: fieldId(column) }),
      }),
    );
  };
  const unsupported = (): SaleReturnIncomingProjectionResult =>
    Object.freeze({ status: 'unsupported', diagnostics: Object.freeze(diagnostics) });
  if (
    !object(input) ||
    typeof input.rowIdentity !== 'string' ||
    !input.rowIdentity.trim() ||
    !Number.isSafeInteger(input.ordinal) ||
    input.ordinal < 1 ||
    !rawRecord(input.raw) ||
    !Array.isArray(input.itemMasters) ||
    !input.itemMasters.every(rawRecord)
  ) {
    add(
      'invalid-projection-input',
      'A saved identity, positive display ordinal and exact raw string/NULL observations are required.',
    );
    return unsupported();
  }
  const { raw } = input;
  if (
    typeof raw.CO_CODE !== 'string' ||
    !raw.CO_CODE ||
    raw.CO_CODE !== raw.CO_CODE.trim() ||
    typeof raw.IT_CODE !== 'string' ||
    !raw.IT_CODE ||
    raw.IT_CODE !== raw.IT_CODE.trim()
  ) {
    add(
      'invalid-projection-input',
      'The saved company and item identity must be explicit canonical text.',
      1,
    );
    return unsupported();
  }
  const masters = input.itemMasters.filter(
    (row) => row.CO_CODE === raw.CO_CODE && row.IT_CODE === raw.IT_CODE,
  );
  // The service must also discover relevant case/trim aliases in its query.
  // A matching exact row cannot conceal another row that desktop collation
  // might join. This conservative rule does not claim full collation parity.
  const normalized = (value: string | null | undefined) => value?.trim().toUpperCase();
  if (
    input.itemMasters.some(
      (row) =>
        normalized(row.CO_CODE) === normalized(raw.CO_CODE) &&
        normalized(row.IT_CODE) === normalized(raw.IT_CODE) &&
        (row.CO_CODE !== raw.CO_CODE || row.IT_CODE !== raw.IT_CODE),
    )
  )
    add(
      'ambiguous-item-master',
      'A noncanonical company/item alias could match the saved item under desktop collation.',
      1,
    );
  // A:* already includes RATE_TYPE/IT_TYPE in the original SELECT. Until the
  // DataAdapter duplicate-name binding is established, only equal non-NULL
  // saved/master values are admitted; a modern object merge cannot choose B.
  if (!masters.length)
    add('missing-item-master', 'The saved item has no exact company/item master.', 1);
  else if (masters.length !== 1)
    add(
      'ambiguous-item-master',
      'The saved item matches more than one physical company/item master.',
      1,
    );
  const master = masters.length === 1 ? masters[0]! : undefined;
  if (master) {
    for (const [key, column] of [
      ['RATE_TYPE', 44],
      ['IT_TYPE', 43],
    ] as const) {
      if (
        typeof raw[key] !== 'string' ||
        typeof master[key] !== 'string' ||
        raw[key] !== master[key]
      )
        add(
          'unresolved-item-type-binding',
          'Saved and master ' +
            key +
            ' must agree exactly until the desktop duplicate-column binding is resolved.',
          column,
        );
    }
    if (!Object.hasOwn(master, 'IT_NAME'))
      add('missing-item-master', 'The item master name observation is missing.', 3);
  }
  const cells: Partial<Record<number, string>> = Object.fromEntries(
    Array.from({ length: 71 }, (_, column) => [column, '']),
  );
  const saved = (key: string, column: number): string | null | undefined => {
    if (!Object.hasOwn(raw, key)) {
      add('missing-saved-column', 'The saved ' + key + ' observation is missing.', column);
      return undefined;
    }
    return raw[key];
  };
  const numeric = (key: string, column: number): string | undefined => {
    const value = saved(key, column);
    if (value === undefined) return undefined;
    if (value === null) {
      add(
        'unsupported-numeric-null',
        'The saved ' + key + ' is NULL; its desktop numeric conversion is not established.',
        column,
      );
      return undefined;
    }
    if (!value || value.length > 128 || !/^[+-]?(?:\d+(?:\.\d*)?|\.\d+)$/.test(value)) {
      add(
        'invalid-saved-decimal',
        'The saved ' + key + ' requires a finite plain decimal observation.',
        column,
      );
      return undefined;
    }
    const decimal = new D(value);
    if (decimal.precision() > 36 || decimal.decimalPlaces() > 18 || decimal.abs().gte('1e36')) {
      add(
        'unsupported-saved-precision',
        'The saved ' + key + ' exceeds the declared exact-decimal projection profile.',
        column,
      );
      return undefined;
    }
    return value;
  };
  for (const [column, key] of Object.entries(TEXT)) {
    const value = saved(key, Number(column));
    if (value !== undefined) cells[Number(column)] = value ?? '';
  }
  for (const [column, [key, dp]] of Object.entries(FORMATTED)) {
    const value = numeric(key, Number(column));
    if (value !== undefined) cells[Number(column)] = decimalCellText(value, dp);
  }
  const pieces = numeric('ITM_PCS', 9);
  if (pieces !== undefined) cells[9] = pieces; // source ToString, no integer Format on load
  const description = saved('ITM_REMARK', 3);
  if (description !== undefined) cells[3] = description || master?.IT_NAME || '';
  const tagLabour = saved('TAG_LBR_CODE', 29);
  if (tagLabour !== undefined) cells[29] = tagLabour || cells[13] || '';
  cells[0] = String(input.ordinal);
  cells[57] = 'E';
  if (diagnostics.length) return unsupported();
  return Object.freeze({
    status: 'ready',
    state: createSaleReturnIncomingState({
      rowIdentity: input.rowIdentity,
      raw,
      cells,
      cacheMode: 'saved',
    }),
  });
}

/** EnterCell4538–4541/4561–4575 formats these editors to two decimals without
 * changing the displayed cell or comparison caches. A blank visible manual
 * amount becomes editor text0.00, not a committed zero. No event is emitted.
 */
export function projectSaleReturnIncomingEditorText(
  state: SaleReturnIncomingState,
): SaleReturnIncomingEditorTextResult {
  const editorTextByField: Record<string, string> = {};
  const diagnostics: SaleReturnIncomingProjectionDiagnostic[] = [];
  for (const column of SALE_RETURN_INCOMING_MONEY_PREVIEW_COLUMNS) {
    const value = state?.visible?.[column];
    if (
      typeof value !== 'string' ||
      value.length > 128 ||
      (value.trim() !== '' && !/^\s*[+-]?(?:\d+(?:\.\d*)?|\.\d+)\s*$/.test(value))
    ) {
      diagnostics.push(
        Object.freeze({
          code: 'invalid-editor-state',
          fieldId: fieldId(column),
          message: 'The source editor requires a finite plain decimal cell.',
        }),
      );
      continue;
    }
    const decimal = new D(value.trim() || '0');
    if (decimal.abs().gte('1e60')) {
      diagnostics.push(
        Object.freeze({
          code: 'invalid-editor-state',
          fieldId: fieldId(column),
          message: 'The source editor cell exceeds the declared calculation result range.',
        }),
      );
      continue;
    }
    editorTextByField[fieldId(column)] = decimalCellText(decimal, 2);
  }
  return diagnostics.length
    ? Object.freeze({ status: 'unsupported', diagnostics: Object.freeze(diagnostics) })
    : Object.freeze({ status: 'ready', editorTextByField: Object.freeze(editorTextByField) });
}
