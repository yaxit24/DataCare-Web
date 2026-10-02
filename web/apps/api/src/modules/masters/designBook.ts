import { createHash } from 'node:crypto';
import { withTxBudget } from '../shared/txBudget.js';
import {
  createDesignCalculationState,
  applyDesignCalculationEvent,
  type DesignCalculationEvent,
  type DesignCalculationValues,
  type DesignCalculationPolicy,
  type DesignComponentDefaults,
} from '@datacare/core';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';

/** MS_DESIGN_BOOK.cs:4447–4536, 4652–4751. Children belong to the complete
 * company/book/product/parent serial, never the displayed design number alone. */
export class DesignBookError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'DesignBookValidationError';
  }
}

export class DesignBookConflictError extends DesignBookError {
  readonly statusCode = 409;
  constructor() {
    super('This design book changed after it was loaded. Reload it before saving or deleting.');
    this.name = 'DesignBookConflictError';
  }
}

type Numeric = number | null;
export interface DesignBookComponent {
  isrNo?: number;
  itCode: string;
  itType?: string | null;
  pcs?: Numeric;
  pcsWt?: Numeric;
  karigarWt?: Numeric;
  karigarLessPct?: Numeric;
  grossWt?: Numeric;
  conversionPct?: Numeric;
  conversionWt?: Numeric;
  rateType?: string | null;
  rate?: Numeric;
  amount?: Numeric;
  labourRate?: Numeric;
  labourAmount?: Numeric;
  netAmount?: Numeric;
}

export interface DesignBookLine {
  srNo?: number;
  oldSrNo?: number | null;
  pageNo?: string | null;
  designNo: string;
  style?: string | null;
  grCode?: string | null;
  itmSize?: string | null;
  dieNo?: string | null;
  pcs?: Numeric;
  grossWt?: Numeric;
  otherWt?: Numeric;
  netWt?: Numeric;
  touch?: Numeric;
  westPct?: Numeric;
  fineWt?: Numeric;
  rate?: Numeric;
  amount?: Numeric;
  labourType?: string | null;
  labourPct?: Numeric;
  labourRate?: Numeric;
  labourAmount?: Numeric;
  otherAmount?: Numeric;
  tagCost?: Numeric;
  mrp?: Numeric;
  ghatPct?: Numeric;
  ghatWt?: Numeric;
  netAmount?: Numeric;
  rateType?: string | null;
  itType?: string | null;
  karigarName?: string | null;
  vchDate?: Date | string | null;
  /** Existing image associations are retained when omitted. */
  designImageId?: string | null;
  /** Omitted: retain existing children (legacy clients). []: remove all children. */
  components?: DesignBookComponent[];
  /** Ordered explicit cell commits. Omission retains compatibility with import/manual clients. */
  calculationEvents?: DesignCalculationEvent[];
  calculationVersion?: string;
}

type DesignScope = { tenantId: string; coCode: string };
export interface DesignBookInput {
  scope: DesignScope;
  bookName: string;
  prCode: string;
  vchDate?: Date | string;
  mainUser?: string;
  /** Snapshot returned by listDesignBook; 'new' represents an empty book. */
  expectedVersion?: string;
  lines: DesignBookLine[];
}

type Row = Record<string, any>;
type Field = readonly [string, string, number?];
// Third element = text width; omitted = numeric. PAGE_NO is database text.
const PARENT_FIELDS: readonly Field[] = [
  ['pageNo', 'PAGE_NO', Infinity],
  ['grCode', 'GR_CODE', 3],
  ['itmSize', 'ITM_SIZE', 15],
  ['dieNo', 'DIE_NO', 10],
  ['pcs', 'ITM_PCS'],
  ['grossWt', 'ITM_GWT'],
  ['otherWt', 'ITM_OTH_WT'],
  ['netWt', 'ITM_NWT'],
  ['touch', 'ITM_TOUCH'],
  ['westPct', 'ITM_WEST_PRC'],
  ['fineWt', 'ITM_FINE'],
  ['rate', 'ITM_RATE'],
  ['amount', 'ITM_AMT'],
  ['labourType', 'LBR_TYPE', 1],
  ['labourPct', 'LBR_PRC'],
  ['labourRate', 'LBR_RATE'],
  ['labourAmount', 'LBR_AMT'],
  ['otherAmount', 'OTH_AMT'],
  ['tagCost', 'TAG_COST'],
  ['mrp', 'ITM_MRP'],
  ['ghatPct', 'GHT_PRC'],
  ['ghatWt', 'ITM_GHT'],
  ['netAmount', 'NET_AMT'],
  ['rateType', 'RATE_TYPE', 1],
  ['itType', 'IT_TYPE', 1],
  ['karigarName', 'KR_NAME', 5],
];
const COMPONENT_FIELDS: readonly Field[] = [
  ['itCode', 'IT_CODE', 5],
  ['itType', 'IT_TYPE', 1],
  ['pcs', 'IT_PCS'],
  ['pcsWt', 'IT_PCS_WT'],
  ['karigarWt', 'KR_WT'],
  ['karigarLessPct', 'KR_LESS_PRC'],
  ['grossWt', 'IT_GWT'],
  ['conversionPct', 'IT_CON_PRC'],
  ['conversionWt', 'IT_CON_WT'],
  ['rateType', 'IT_RATE_TYPE', 1],
  ['rate', 'IT_RATE'],
  ['amount', 'IT_AMT'],
  ['labourRate', 'IT_LBR_RATE'],
  ['labourAmount', 'IT_LBR_AMT'],
  ['netAmount', 'IT_NET_AMT'],
];

export interface DesignCalculationConfig extends DesignCalculationPolicy {
  version: string;
  columns: { bookName: string; name: string; label: string; visible: boolean; repeat: boolean }[];
}
async function calculationConfig(tx: any, scope: DesignScope): Promise<DesignCalculationConfig> {
  const settings: Row[] = await tx.$queryRawUnsafe(
    'SELECT "LBR_TYPE" FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2',
    scope.tenantId,
    scope.coCode,
  );
  const licenses: Row[] = await tx.$queryRawUnsafe(
    'SELECT "REF_NO" FROM "HDD_MAST" WHERE tenant_id=$1 AND COALESCE("REF_NO",\'\')<>\'\'',
    scope.tenantId,
  );
  const columns: Row[] = await tx.$queryRawUnsafe(
    'SELECT "BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO","COL_RPT" FROM "COL_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "BOOK_NAME" IN (\'DESIGN DETL\',\'TAG_IDTL\') ORDER BY "BOOK_NAME","COL_NAME"',
    scope.tenantId,
    scope.coCode,
  );
  const labour = [...new Set(settings.map((row) => String(row.LBR_TYPE ?? '').trim() || 'G'))];
  const costModes = [
    ...new Set(
      licenses.map((row) => ['AK004NEAK', 'AK019NEAK'].includes(String(row.REF_NO).trim())),
    ),
  ];
  if (labour.length > 1 || costModes.length > 1)
    throw new DesignBookError('Conflicting design calculation settings require reconciliation.');
  const seen = new Map<string, string>();
  const configured = columns.map((row) => {
    const id = JSON.stringify([row.BOOK_NAME, row.COL_NAME]);
    const serialized = JSON.stringify(row);
    if (seen.has(id) && seen.get(id) !== serialized)
      throw new DesignBookError('Conflicting design column settings require reconciliation.');
    seen.set(id, serialized);
    return {
      bookName: String(row.BOOK_NAME),
      name: String(row.COL_NAME),
      label: String(row.COL_NEW_NAME ?? ''),
      visible: row.YES_NO !== 'N',
      repeat: row.COL_RPT === 'Y',
    };
  });
  const policy = {
    defaultLabourType: labour[0] ?? 'G',
    automaticCost: costModes[0] ?? false,
    tagCostVisible: !configured.some(
      (column) => column.bookName === 'DESIGN DETL' && column.name === 'TagCost' && !column.visible,
    ),
    columns: configured.filter(
      (column, index) =>
        configured.findIndex(
          (candidate) => candidate.bookName === column.bookName && candidate.name === column.name,
        ) === index,
    ),
  };
  return { ...policy, version: createHash('sha256').update(JSON.stringify(policy)).digest('hex') };
}
export async function getDesignCalculationConfig(
  prisma: any,
  scope: DesignScope,
): Promise<DesignCalculationConfig> {
  if (!scope.coCode) throw new DesignBookError('company scope is required');
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => calculationConfig(tx, scope));
}
async function componentDefaults(
  tx: any,
  scope: DesignScope,
  code: string,
): Promise<DesignComponentDefaults> {
  const itCode = text(code, 5, 'component item');
  if (!itCode) throw new DesignBookError('component item is required');
  const rows: Row[] = await tx.$queryRawUnsafe(
    'SELECT "IT_TYPE","CON_PRC","OTH_RATE_TYPE","OTH_RATE" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3',
    scope.tenantId,
    scope.coCode,
    itCode,
  );
  if (rows.length !== 1) throw new DesignBookError('Component item was not found in this company.');
  const row = rows[0]!;
  return {
    itType: String(row.IT_TYPE ?? ''),
    conversionPct: row.CON_PRC == null ? null : String(row.CON_PRC),
    rateType: String(row.OTH_RATE_TYPE ?? ''),
    rate: row.OTH_RATE == null ? null : String(row.OTH_RATE),
  };
}
export async function getDesignComponentDefaults(
  prisma: any,
  scope: DesignScope,
  itCode: string,
): Promise<DesignComponentDefaults> {
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    componentDefaults(tx, scope, itCode),
  );
}
function calculationValues(
  row: Row | undefined,
  definitions: readonly Field[],
): DesignCalculationValues {
  const allowed =
    definitions === PARENT_FIELDS
      ? new Set([
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
          'rateType',
          'amount',
          'tagCost',
          'mrp',
          'itType',
        ])
      : new Set(COMPONENT_FIELDS.map(([name]) => name));
  return Object.fromEntries(
    definitions
      .filter(([name, column]) => allowed.has(name) && row && Object.hasOwn(row, column))
      .map(([name, column]) => {
        const value = row![column];
        return [
          name,
          value == null || typeof value === 'number' || typeof value === 'string'
            ? value
            : String(value),
        ];
      }),
  );
}
/** Desktop save applies Conversion.Val to cleared numeric grid cells. Keep NULL loaded cells
 * untouched; only explicit empty strings produced by repeat/keyboard replay become zero. */
function calculatedFields(values: DesignCalculationValues, definitions: readonly Field[]): Row {
  const numeric = new Set(
    definitions.filter(([, , width]) => width === undefined).map(([name]) => name),
  );
  return Object.fromEntries(
    Object.entries(values).map(([name, value]) => [
      name,
      numeric.has(name) && value === '' ? 0 : value,
    ]),
  );
}
async function calculateLine(
  tx: any,
  scope: DesignScope,
  line: DesignBookLine,
  previous: Row | undefined,
  previousChildren: Row[],
  policy: DesignCalculationConfig,
  newBook: boolean,
): Promise<DesignBookLine> {
  if (!Array.isArray(line.calculationEvents) || line.calculationEvents.length > 10000)
    throw new DesignBookError('Invalid design calculation history.');
  if (line.calculationVersion !== policy.version)
    throw new DesignBookError(
      'Design calculation settings changed. Reload the book before saving.',
    );
  try {
    let state = createDesignCalculationState(
      calculationValues(previous, PARENT_FIELDS),
      previousChildren.map((row) => ({
        isrNo: Number(row.ISR_NO),
        values: calculationValues(row, COMPONENT_FIELDS),
      })),
      policy,
      Boolean(previous),
    );
    for (const original of line.calculationEvents) {
      if (!original || typeof original !== 'object')
        throw new DesignBookError('Invalid design calculation event.');
      let event = original;
      if (event.kind === 'item')
        event = { ...event, defaults: await componentDefaults(tx, scope, event.itCode) };
      else if (event.kind === 'componentEnter') {
        const serial = event.isrNo;
        const child = state.components.find((entry) => entry.isrNo === serial);
        event = { ...event, defaults: undefined };
        if (
          event.field === 'grossWt' &&
          Number(child?.values.pcs ?? 0) === 0 &&
          Number(child?.values.grossWt ?? 0) === 0
        )
          event = {
            ...event,
            defaults: await componentDefaults(tx, scope, String(child?.values.itCode ?? '')),
          };
      }
      state = applyDesignCalculationEvent(state, event, { ...policy, newBook });
    }
    const components =
      line.components ??
      previousChildren.map((row) => ({
        isrNo: Number(row.ISR_NO),
        itCode: String(row.IT_CODE ?? ''),
      }));
    if (
      components.length !== state.components.length ||
      components.some(
        (child, index) =>
          !state.components.some(
            (stateChild) => stateChild.isrNo === Number(child.isrNo ?? index + 1),
          ),
      )
    )
      throw new DesignBookError('Component changes are missing from the calculation history.');
    return {
      ...line,
      ...calculatedFields(state.values, PARENT_FIELDS),
      components: components.map((child, index) => ({
        ...child,
        ...calculatedFields(
          state.components.find(
            (stateChild) => stateChild.isrNo === Number(child.isrNo ?? index + 1),
          )!.values,
          COMPONENT_FIELDS,
        ),
      })),
    } as DesignBookLine;
  } catch (error) {
    if (error instanceof DesignBookError) throw error;
    throw new DesignBookError(
      error instanceof Error ? error.message : 'Invalid design calculation history.',
    );
  }
}

function text(value: unknown, width: number, name: string): string | null {
  if (value === null) return null;
  const result = String(value ?? '').trim();
  if (result.length > width) throw new DesignBookError(`${name} exceeds ${width} characters`);
  return result;
}
function serial(value: unknown, name: string): number {
  const result = Number(value);
  if (!Number.isSafeInteger(result) || result <= 0)
    throw new DesignBookError(`${name} must be a positive whole number`);
  return result;
}
function date(value: unknown): Date | null {
  if (value === null) return null;
  const result = value instanceof Date ? value : new Date(String(value));
  if (!Number.isFinite(result.getTime())) throw new DesignBookError('invalid design date');
  return result;
}
function key(scope: DesignScope, book: string, product: string) {
  const bookName = text(book, 20, 'book name');
  const prCode = text(product, 2, 'product code');
  if (!bookName) throw new DesignBookError(DESKTOP_MESSAGES.BOOK_DETAIL_FIRST);
  if (!prCode) throw new DesignBookError('product code is required');
  if (!scope.tenantId || !scope.coCode) throw new DesignBookError('company scope is required');
  return [scope.tenantId, scope.coCode, bookName, prCode] as const;
}
function fields(input: Row, previous: Row | undefined, definitions: readonly Field[]): Row {
  const result: Row = {};
  for (const [name, column, width] of definitions) {
    const value = input[name];
    if (value === undefined)
      result[column] = previous ? previous[column] : width === undefined ? 0 : null;
    else if (previous && value === previous[column]) result[column] = value;
    else if (width !== undefined) result[column] = text(value, width, name);
    else if (value === null) result[column] = null;
    else {
      if (
        (typeof value !== 'number' && typeof value !== 'string') ||
        String(value).trim() === '' ||
        !Number.isFinite(Number(value))
      ) {
        throw new DesignBookError(`${name} must be a finite number`);
      }
      result[column] = Number(value);
    }
  }
  return result;
}
const WHERE = 'tenant_id=$1 AND "CO_CODE"=$2 AND "BOOK_NAME"=$3 AND "PR_CODE"=$4';
async function snapshot(tx: any, args: readonly string[]) {
  const parents: Row[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "DESIGN_DETL" WHERE ${WHERE} ORDER BY "SR_NO"`,
    ...args,
  );
  const children: Row[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "DESIGN_IDTL" WHERE ${WHERE} ORDER BY "SR_NO","ISR_NO"`,
    ...args,
  );
  const version =
    parents.length || children.length
      ? createHash('sha256').update(JSON.stringify({ parents, children })).digest('hex')
      : 'new';
  return { parents, children, version };
}
async function lock(tx: any, args: readonly string[]) {
  // Serializes replacement even when this book has no parent rows to lock yet.
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtextextended($1, 0))',
    JSON.stringify(['design-book', ...args]),
  );
}
function checkVersion(expected: string | undefined, actual: string) {
  if (expected !== undefined && expected !== actual) throw new DesignBookConflictError();
}
function dataOf(row: Row | undefined): Row {
  if (!row) return {};
  const { tenant_id: _tenant, ...data } = row;
  return data;
}

/** Atomically replace one catalogue. Existing identities and omitted business columns survive;
 * omitted components are retained for compatibility with the original parent-only API. */
export async function saveDesignBook(prisma: any, input: DesignBookInput): Promise<number> {
  const args = key(input.scope, input.bookName, input.prCode);
  if (!Array.isArray(input.lines) || !input.lines.length)
    throw new DesignBookError('at least one design line is required');
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    await lock(tx, args);
    const before = await snapshot(tx, args);
    checkVersion(input.expectedVersion, before.version);
    const policy = input.lines.some((line) => line?.calculationEvents !== undefined)
      ? await calculationConfig(tx, input.scope)
      : undefined;
    const parentRows: Row[] = [];
    const childRows: Row[] = [];
    const seen = new Set<number>();
    for (const [index, sourceLine] of input.lines.entries()) {
      if (!sourceLine || typeof sourceLine !== 'object')
        throw new DesignBookError('invalid design line');
      let line = sourceLine;
      const srNo = serial(line.srNo ?? index + 1, 'parent serial');
      if (seen.has(srNo)) throw new DesignBookError(`duplicate parent serial ${srNo}`);
      seen.add(srNo);
      const previous = before.parents.find((row) => Number(row.SR_NO) === srNo);
      const priorChildren = before.children.filter((child) => Number(child.SR_NO) === srNo);
      if (line.calculationEvents !== undefined && policy)
        line = await calculateLine(
          tx,
          input.scope,
          line,
          previous,
          priorChildren,
          policy,
          before.version === 'new',
        );
      const designNo = text(line.designNo, 15, 'design number');
      if (!designNo) throw new DesignBookError(DESKTOP_MESSAGES.DESIGN_NO_REQUIRED);
      const row = {
        ...dataOf(previous),
        ...fields(line, previous, PARENT_FIELDS),
        CO_CODE: args[1],
        BOOK_NAME: args[2],
        PR_CODE: args[3],
        SR_NO: srNo,
        OLD_SRNO:
          line.oldSrNo === undefined
            ? previous
              ? previous.OLD_SRNO
              : srNo
            : line.oldSrNo === null
              ? null
              : serial(line.oldSrNo, 'old serial'),
        DESIGN_NO: previous?.DESIGN_NO === line.designNo ? previous.DESIGN_NO : designNo,
        VCH_DATE:
          line.vchDate !== undefined
            ? date(line.vchDate)
            : input.vchDate !== undefined
              ? date(input.vchDate)
              : previous
                ? previous.VCH_DATE
                : new Date(),
        DESIGN_IMG_ID:
          line.designImageId !== undefined
            ? previous && previous.DESIGN_IMG_ID === line.designImageId
              ? line.designImageId
              : text(line.designImageId, 50, 'image identity')
            : previous
              ? previous.DESIGN_IMG_ID
              : `${args[1]}_${args[2]}_${args[3]}_${designNo}`,
        MAIN_USER:
          input.mainUser === undefined
            ? (previous?.MAIN_USER ?? null)
            : text(input.mainUser, 15, 'user'),
      };
      // ITM_STYLE is restored by the X11 migration; do not overwrite historical style on omission.
      if (line.style !== undefined)
        (row as Row).ITM_STYLE =
          previous?.ITM_STYLE === line.style ? line.style : (text(line.style, 50, 'style') ?? '');
      parentRows.push(row);
      if (line.components === undefined) {
        childRows.push(...priorChildren.map(dataOf));
        continue;
      }
      if (!Array.isArray(line.components)) throw new DesignBookError('components must be an array');
      const childSerials = new Set<number>();
      for (const [childIndex, component] of line.components.entries()) {
        if (!component || typeof component !== 'object')
          throw new DesignBookError('invalid design component');
        const isrNo = serial(component.isrNo ?? childIndex + 1, 'component serial');
        if (childSerials.has(isrNo))
          throw new DesignBookError(`duplicate component serial ${isrNo} on parent ${srNo}`);
        childSerials.add(isrNo);
        if (!String(component.itCode ?? '').trim())
          throw new DesignBookError(`component item is required on parent ${srNo}`);
        const previousChild = priorChildren.find((child) => Number(child.ISR_NO) === isrNo);
        childRows.push({
          ...dataOf(previousChild),
          ...fields(component, previousChild, COMPONENT_FIELDS),
          CO_CODE: args[1],
          BOOK_NAME: args[2],
          PR_CODE: args[3],
          SR_NO: srNo,
          ISR_NO: isrNo,
          // The desktop child writer does not assign DESIGN_NO; preserve its historical value.
          DESIGN_NO: previousChild?.DESIGN_NO ?? null,
          MAIN_USER:
            input.mainUser === undefined
              ? (previousChild?.MAIN_USER ?? null)
              : text(input.mainUser, 15, 'user'),
        });
      }
    }
    await tx.$executeRawUnsafe(`DELETE FROM "DESIGN_IDTL" WHERE ${WHERE}`, ...args);
    await tx.$executeRawUnsafe(`DELETE FROM "DESIGN_DETL" WHERE ${WHERE}`, ...args);
    for (const row of parentRows) await insertRowTx(tx, 'DESIGN_DETL', args[0], row);
    for (const row of childRows) await insertRowTx(tx, 'DESIGN_IDTL', args[0], row);
    return parentRows.length;
  });
}

/** Compatible flat parent array, enriched with its actual persisted children and snapshot identity. */
export async function listDesignBook(
  prisma: any,
  scope: DesignScope,
  bookName: string,
  prCode: string,
): Promise<Record<string, unknown>[]> {
  const args = key(scope, bookName, prCode);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await lock(tx, args);
    const { parents, children, version } = await snapshot(tx, args);
    return parents.map((parent) => ({
      ...parent,
      components: children.filter((child) => Number(child.SR_NO) === Number(parent.SR_NO)),
      bookVersion: version,
    }));
  });
}

/** MS_DESIGN_BOOK.cs:4795–4796 deletes both owned datasets for the selected book/product. */
export async function deleteDesignBook(
  prisma: any,
  scope: DesignScope,
  bookName: string,
  prCode: string,
  expectedVersion?: string,
): Promise<number> {
  const args = key(scope, bookName, prCode);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lock(tx, args);
    const before = await snapshot(tx, args);
    checkVersion(expectedVersion, before.version);
    await tx.$executeRawUnsafe(`DELETE FROM "DESIGN_IDTL" WHERE ${WHERE}`, ...args);
    await tx.$executeRawUnsafe(`DELETE FROM "DESIGN_DETL" WHERE ${WHERE}`, ...args);
    return before.parents.length;
  });
}
