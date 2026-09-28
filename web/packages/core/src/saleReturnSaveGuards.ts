import { Decimal } from 'decimal.js';

/** Pure supplied-observation evaluator for TR_SALE_RTN:12117–12407.
 * Neither qualified facts nor ready results establish runtime/provider authority. */
export const SALE_RETURN_SAVE_GUARDS_VERSION = 'saved-return-save-guards-v1' as const;
export const SALE_RETURN_SAVE_GUARDS_PROFILE =
  'qualified-saved-incoming-zero-cash-non-e-v1' as const;
const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const LIMIT = new D('1e36');
type Cell = string | null;
type Matrix = readonly (readonly Cell[])[];
export type SaleReturnSaveGuardObservation<T> =
  | {
      readonly status: 'qualified';
      readonly revision: string;
      readonly binding: string;
      readonly value: T;
    }
  | {
      readonly status: 'unavailable';
      readonly revision: string;
      readonly reason: string;
    };
export interface SaleReturnSaveGuardEntry {
  readonly mode: Cell;
  readonly voucherNo: Cell;
  readonly savedVoucherNo: Cell;
  readonly hiddenVoucherNo: Cell;
  readonly savedHiddenVoucherNo: Cell;
  readonly instance: Cell;
  readonly employeeCode: Cell;
  readonly userUpdate: Cell;
}
export interface SaleReturnSaveGuardBill {
  readonly phase: Cell;
  readonly nAcCrAmt: Cell;
  readonly nAcDrAmt: Cell;
  readonly matrix: Matrix;
}
export interface SaleReturnSaveGuardRow {
  readonly rowIdentity: string;
  readonly ordinal: number;
  readonly itemCode: Cell;
  readonly counterCode: Cell;
}
export interface SaleReturnSaveGuardValues {
  readonly entry: SaleReturnSaveGuardEntry;
  readonly employeeRule: Cell;
  readonly defaulter: {
    readonly cardinality: 'one' | 'none' | 'multiple';
    readonly accountCode: Cell;
    readonly rawFlag: Cell;
  };
  readonly cashLimit: Cell;
  readonly bill: SaleReturnSaveGuardBill;
  readonly period: {
    readonly voucherDate: Cell;
    readonly openingDate: Cell;
    readonly closingDate: Cell;
    readonly lockDate: Cell;
  };
  readonly userEdit: Cell;
  readonly counterRule: Cell;
  readonly incomingRows: readonly SaleReturnSaveGuardRow[];
  readonly saveFold: {
    readonly phase: Cell;
    readonly upDown: boolean;
    readonly incomingFine18: Cell;
    readonly incomingNet38: Cell;
    readonly outgoingTotal24: Cell;
  };
  readonly beforeBill: { readonly matrix: Matrix };
  readonly edition: Cell;
  readonly book: { readonly mainBook: Cell; readonly bookInout: Cell };
  readonly freshUpdate: boolean;
}
export interface SaleReturnSaveGuardsInput {
  readonly provenance: {
    readonly documentIdentity: string;
    readonly documentVersion: string;
    readonly observationId: string;
  };
  readonly observations: {
    readonly [K in keyof SaleReturnSaveGuardValues]: SaleReturnSaveGuardObservation<
      SaleReturnSaveGuardValues[K]
    >;
  };
}
export type SaleReturnSaveGuard =
  | 'entry-mode'
  | 'new-entry-license'
  | 'employee-required'
  | 'defaulter'
  | 'cash-limit'
  | 'employee-required-repeat'
  | 'cheque-bank'
  | 'card-bank'
  | 'new-entry-company-type'
  | 'new-entry-clock'
  | 'year-range'
  | 'lock-date'
  | 'ordinary-edit'
  | 'voucher-number'
  | 'counter-required'
  | 'save-fold'
  | 'amount-nonzero'
  | 'profile';
export interface SaleReturnSaveGuardCheck {
  readonly guard: SaleReturnSaveGuard;
  readonly outcome: 'passed' | 'not-applicable' | 'source-rejected' | 'unsupported';
}
export interface SaleReturnSaveGuardsResult {
  readonly version: typeof SALE_RETURN_SAVE_GUARDS_VERSION;
  readonly profile: typeof SALE_RETURN_SAVE_GUARDS_PROFILE;
  readonly canCommit: false;
  readonly status: 'ready' | 'source-rejected' | 'unsupported' | 'invalid-input';
  readonly diagnostic: {
    readonly code: string;
    readonly guard: SaleReturnSaveGuard | 'envelope';
  } | null;
  readonly checks: readonly SaleReturnSaveGuardCheck[];
  readonly observation: SaleReturnSaveGuardsInput | null;
}
const KEYS = [
  'entry',
  'employeeRule',
  'defaulter',
  'cashLimit',
  'bill',
  'period',
  'userEdit',
  'counterRule',
  'incomingRows',
  'saveFold',
  'beforeBill',
  'edition',
  'book',
  'freshUpdate',
] as const;
const plainCell = (x: unknown): x is Cell => x === null || typeof x === 'string';
const id = (x: unknown): x is string =>
  typeof x === 'string' &&
  x.length > 0 &&
  x.length <= 256 &&
  !/[^\x20-\x7e]/.test(x) &&
  x.trim() === x;
function invalid(): never {
  throw new Error('invalid-input');
}
function exact(x: unknown, keys: readonly string[]): Record<string, unknown> {
  if (!x || typeof x !== 'object' || Array.isArray(x)) invalid();
  const actual = Object.keys(x);
  if (actual.length !== keys.length || actual.some((k) => !keys.includes(k))) invalid();
  return x as Record<string, unknown>;
}
function scalarRecord(x: unknown, keys: readonly string[]): void {
  const r = exact(x, keys);
  if (Object.values(r).some((v) => !plainCell(v))) invalid();
}
function matrix(x: unknown): void {
  if (
    !Array.isArray(x) ||
    x.length !== 9 ||
    x.some((r) => !Array.isArray(r) || r.length !== 6 || r.some((c) => !plainCell(c)))
  )
    invalid();
}
function freeze<T>(x: T): T {
  if (x && typeof x === 'object') {
    for (const v of Object.values(x)) freeze(v);
    Object.freeze(x);
  }
  return x;
}
/** Own-data copy: descriptors are inspected without evaluating property getters.
 * Proxy reflection failures are contained; this is not a sandbox for malicious proxies. */
function detached(input: unknown): unknown {
  const active = new Set<object>();
  let nodes = 0;
  function visit(x: unknown, depth: number): unknown {
    if (++nodes > 100000 || depth > 16) invalid();
    if (x === null || typeof x === 'boolean') return x;
    if (typeof x === 'string') {
      if (x.length > 4096) invalid();
      return x;
    }
    if (typeof x === 'number') {
      if (!Number.isFinite(x)) invalid();
      return x;
    }
    if (!x || typeof x !== 'object' || active.has(x)) invalid();
    const proto = Object.getPrototypeOf(x);
    if (
      proto !== Object.prototype &&
      proto !== null &&
      !(Array.isArray(x) && proto === Array.prototype)
    )
      invalid();
    const descriptors = Object.getOwnPropertyDescriptors(x);
    const keys = Reflect.ownKeys(descriptors);
    active.add(x);
    let result: unknown;
    if (Array.isArray(x)) {
      const length = descriptors.length?.value as unknown;
      if (
        typeof length !== 'number' ||
        !Number.isSafeInteger(length) ||
        length < 0 ||
        length > 256 ||
        keys.length !== length + 1
      )
        invalid();
      const values: unknown[] = [];
      for (let i = 0; i < length; i++) {
        const d = descriptors[String(i)];
        if (!d || !d.enumerable || !Object.hasOwn(d, 'value')) invalid();
        values.push(visit(d.value, depth + 1));
      }
      result = values;
    } else {
      const record: Record<string, unknown> = {};
      for (const k of keys) {
        if (typeof k !== 'string' || k === '__proto__') invalid();
        const d = descriptors[k];
        if (!d?.enumerable || !Object.hasOwn(d, 'value')) invalid();
        record[k] = visit(d.value, depth + 1);
      }
      result = record;
    }
    active.delete(x);
    return result;
  }
  const copy = visit(input, 0);
  let bytes = 0;
  for (const c of JSON.stringify(copy)) {
    const code = c.codePointAt(0)!;
    bytes += code < 128 ? 1 : code < 2048 ? 2 : code < 65536 ? 3 : 4;
    if (bytes > 2097152) invalid();
  }
  return copy;
}
function parse(input: unknown): SaleReturnSaveGuardsInput {
  const x = exact(detached(input), ['provenance', 'observations']);
  const provenance = exact(x.provenance, ['documentIdentity', 'documentVersion', 'observationId']);
  if (!Object.values(provenance).every(id)) invalid();
  const observations = exact(x.observations, KEYS);
  for (const key of KEYS) {
    const o = observations[key];
    if (!o || typeof o !== 'object') invalid();
    const status = (o as Record<string, unknown>).status;
    if (status === 'unavailable') {
      const r = exact(o, ['status', 'revision', 'reason']);
      if (!id(r.revision) || !id(r.reason)) invalid();
      continue;
    }
    const r = exact(o, ['status', 'revision', 'binding', 'value']);
    if (status !== 'qualified' || !id(r.revision) || !id(r.binding)) invalid();
    const value = r.value;
    switch (key) {
      case 'entry':
        scalarRecord(value, [
          'mode',
          'voucherNo',
          'savedVoucherNo',
          'hiddenVoucherNo',
          'savedHiddenVoucherNo',
          'instance',
          'employeeCode',
          'userUpdate',
        ]);
        break;
      case 'employeeRule':
      case 'cashLimit':
      case 'userEdit':
      case 'counterRule':
      case 'edition':
        if (!plainCell(value)) invalid();
        break;
      case 'defaulter': {
        const d = exact(value, ['cardinality', 'accountCode', 'rawFlag']);
        if (
          !['one', 'none', 'multiple'].includes(String(d.cardinality)) ||
          typeof d.cardinality !== 'string' ||
          !plainCell(d.accountCode) ||
          !plainCell(d.rawFlag)
        )
          invalid();
        break;
      }
      case 'bill': {
        const b = exact(value, ['phase', 'nAcCrAmt', 'nAcDrAmt', 'matrix']);
        if (![b.phase, b.nAcCrAmt, b.nAcDrAmt].every(plainCell)) invalid();
        matrix(b.matrix);
        break;
      }
      case 'beforeBill':
        matrix(exact(value, ['matrix']).matrix);
        break;
      case 'period':
        scalarRecord(value, ['voucherDate', 'openingDate', 'closingDate', 'lockDate']);
        break;
      case 'book':
        scalarRecord(value, ['mainBook', 'bookInout']);
        break;
      case 'freshUpdate':
        if (typeof value !== 'boolean') invalid();
        break;
      case 'saveFold': {
        const f = exact(value, [
          'phase',
          'upDown',
          'incomingFine18',
          'incomingNet38',
          'outgoingTotal24',
        ]);
        if (
          typeof f.upDown !== 'boolean' ||
          ![f.phase, f.incomingFine18, f.incomingNet38, f.outgoingTotal24].every(plainCell)
        )
          invalid();
        break;
      }
      case 'incomingRows': {
        if (!Array.isArray(value) || value.length > 256) invalid();
        const seen = new Set<string>();
        value.forEach((row, index) => {
          const r = exact(row, ['rowIdentity', 'ordinal', 'itemCode', 'counterCode']);
          if (
            !id(r.rowIdentity) ||
            seen.has(r.rowIdentity) ||
            r.ordinal !== index + 1 ||
            !plainCell(r.itemCode) ||
            !plainCell(r.counterCode)
          )
            invalid();
          seen.add(r.rowIdentity);
        });
        break;
      }
    }
  }
  return x as unknown as SaleReturnSaveGuardsInput;
}
class Stop extends Error {
  constructor(
    readonly status: 'unsupported' | 'source-rejected',
    readonly code: string,
  ) {
    super(code);
  }
}
function unsupported(code: string): never {
  throw new Stop('unsupported', code);
}
function reject(code: string): never {
  throw new Stop('source-rejected', code);
}
function text(x: Cell | undefined): string {
  if (typeof x !== 'string' || /[^\x20-\x7e]/.test(x)) unsupported('unsupported-text');
  return x;
}
function flag(x: Cell): string {
  return x === null ? '' : text(x);
}
function domain(x: Decimal): Decimal {
  if (!x.isFinite() || x.abs().gte(LIMIT) || x.sd() > 36 || x.dp() > 18)
    unsupported('unsupported-precision');
  return x;
}
function numeric(x: Cell | undefined, blankIsZero = true): Decimal {
  if (typeof x !== 'string' || x.length > 128 || /[^\x20-\x7e]/.test(x))
    unsupported('unsupported-decimal');
  const clean = x.replace(/^ +| +$/g, '');
  if (clean === '') {
    if (blankIsZero) return new D(0);
    unsupported('unsupported-decimal');
  }
  if (!/^[+-]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)$/.test(clean)) unsupported('unsupported-decimal');
  return domain(new D(clean));
}
function date(x: Cell): string {
  if (typeof x !== 'string' || x.length !== 10 || !/^[0-9]{4}-[0-9]{2}-[0-9]{2}$/.test(x))
    unsupported('unsupported-date');
  const year = BigInt(x.slice(0, 4));
  const month = x.slice(5, 7);
  const day = x.slice(8, 10);
  const days: Record<string, string> = {
    '01': '31',
    '02': year % 4n === 0n && (year % 100n !== 0n || year % 400n === 0n) ? '29' : '28',
    '03': '31',
    '04': '30',
    '05': '31',
    '06': '30',
    '07': '31',
    '08': '31',
    '09': '30',
    '10': '31',
    '11': '30',
    '12': '31',
  };
  if (year < 1n || !days[month] || day < '01' || day > days[month]!)
    unsupported('unsupported-date');
  return x;
}
function canonicalCode(x: Cell, blank = false): string {
  const value = text(x);
  if (value.length > 255 || value.trim() !== value || (!blank && value === ''))
    unsupported('noncanonical-code');
  return value;
}

export function evaluateSavedSaleReturnSaveGuards(input: unknown): SaleReturnSaveGuardsResult {
  let observation: SaleReturnSaveGuardsInput;
  try {
    observation = parse(input);
  } catch {
    return freeze({
      version: SALE_RETURN_SAVE_GUARDS_VERSION,
      profile: SALE_RETURN_SAVE_GUARDS_PROFILE,
      canCommit: false,
      status: 'invalid-input',
      diagnostic: { code: 'invalid-input', guard: 'envelope' },
      checks: [],
      observation: null,
    });
  }
  const checks: SaleReturnSaveGuardCheck[] = [];
  let current: SaleReturnSaveGuard = 'entry-mode';
  function read<K extends keyof SaleReturnSaveGuardValues>(key: K): SaleReturnSaveGuardValues[K] {
    const o = observation.observations[key];
    if (o.status === 'unavailable') unsupported('observation-unavailable');
    if (o.binding !== observation.provenance.observationId)
      unsupported('observation-binding-mismatch');
    return o.value;
  }
  function check(guard: SaleReturnSaveGuard, work: () => void | 'not-applicable'): void {
    current = guard;
    const outcome = work();
    checks.push({ guard, outcome: outcome ?? 'passed' });
  }
  function bill(): SaleReturnSaveGuardBill {
    const b = read('bill');
    if (b.phase !== 'post-events-before-save-fold') unsupported('unsupported-bill-phase');
    return b;
  }
  const cell = (m: Matrix, r: number, c: number): Cell | undefined => m[r]?.[c];
  function employee(): void {
    const rule = flag(read('employeeRule'));
    const code = text(read('entry').employeeCode);
    if (rule === 'Y' && code === '') reject('employee-required');
  }
  try {
    check('entry-mode', () => {
      if (read('entry').mode !== 'E') unsupported('saved-edit-required');
    });
    check('new-entry-license', () => 'not-applicable');
    check('employee-required', employee);
    check('defaulter', () => {
      const a = read('defaulter');
      if (a.cardinality !== 'one') unsupported('account-observation-unqualified');
      const f = flag(a.rawFlag);
      const received = numeric(cell(bill().matrix, 8, 4));
      if (f === 'Y' && received.gt(0)) reject('defaulter-received-outstanding');
    });
    check('cash-limit', () => {
      const limit = numeric(read('cashLimit'), false);
      if (limit.gt(0) && text(read('defaulter').accountCode) !== '00045')
        unsupported('cash-ledger-observation-required');
      return 'not-applicable';
    });
    check('employee-required-repeat', employee);
    check('cheque-bank', () => {
      const m = bill().matrix;
      const sum = domain(numeric(cell(m, 4, 3)).plus(numeric(cell(m, 4, 4))));
      const bank = text(cell(m, 4, 5));
      if (!sum.isZero() && bank === '') reject('bank-account-required');
    });
    check('card-bank', () => {
      const m = bill().matrix;
      const sum = domain(numeric(cell(m, 5, 3)).plus(numeric(cell(m, 5, 4))));
      const bank = text(cell(m, 5, 5));
      if (!sum.isZero() && bank === '') reject('card-account-required');
    });
    check('new-entry-company-type', () => 'not-applicable');
    check('new-entry-clock', () => 'not-applicable');
    check('year-range', () => {
      const p = read('period');
      const opening = date(p.openingDate);
      const voucher = date(p.voucherDate);
      const closing = date(p.closingDate);
      if (opening > voucher || closing < voucher) reject('voucher-outside-year');
    });
    check('lock-date', () => {
      const p = read('period');
      if (date(p.lockDate) >= date(p.voucherDate)) reject('voucher-locked');
    });
    check('ordinary-edit', () => {
      if (flag(read('entry').userUpdate) === 'Y') return 'not-applicable';
      if (flag(read('userEdit')) !== 'Y') reject('source-edit-denied');
    });
    check('voucher-number', () => {
      if (text(read('entry').voucherNo) === '') reject('voucher-required');
    });
    check('counter-required', () => {
      if (flag(read('counterRule')) !== 'Y') return 'not-applicable';
      for (const row of read('incomingRows')) {
        const counter = text(row.counterCode);
        const item = text(row.itemCode);
        if (counter === '' && item !== '') reject('counter-required');
      }
    });
    check('save-fold', () => {
      if (read('saveFold').phase !== 'save-fold-outgoing-then-incoming-no-bill')
        unsupported('unsupported-save-phase');
    });
    check('amount-nonzero', () => {
      const b = bill();
      const sum = domain(numeric(b.nAcCrAmt).plus(numeric(b.nAcDrAmt)));
      const withFine = domain(sum.plus(numeric(read('saveFold').incomingFine18)));
      if (sum.isZero() && withFine.isZero()) reject('item-value-required');
      if (sum.isZero() !== withFine.isZero()) unsupported('fine-branch-unqualified');
    });
    check('profile', () => {
      const e = read('entry');
      if (e.userUpdate !== 'N') unsupported('stored-update-override');
      const voucher = text(e.voucherNo);
      const hidden = text(e.hiddenVoucherNo);
      if (
        !/^[0-9]{5}$/.test(voucher) ||
        voucher === '00000' ||
        !/^[0-9]{5}$/.test(hidden) ||
        hidden === '00000' ||
        voucher !== e.savedVoucherNo ||
        hidden !== e.savedHiddenVoucherNo
      )
        unsupported('saved-identity-mismatch');
      if (!numeric(e.instance, false).gt(0)) unsupported('unsupported-instance');
      canonicalCode(e.employeeCode, true);
      const rows = read('incomingRows');
      let items = 0;
      for (const row of rows) {
        if (canonicalCode(row.itemCode, true) !== '') items++;
        canonicalCode(row.counterCode, true);
      }
      if (items !== 1) unsupported('unsupported-row-profile');
      const account = canonicalCode(read('defaulter').accountCode);
      if (account === '00045') unsupported('special-account');
      if (!numeric(read('cashLimit'), false).isZero()) unsupported('unsupported-cash-limit');
      const edition = read('edition');
      if (edition === 'E') unsupported('edition-audit-required');
      if (!['L', 'B', 'S', 'U', 'P', 'A'].includes(edition ?? ''))
        unsupported('unsupported-edition');
      const book = read('book');
      if (book.mainBook !== 'SALES RETURNE' || book.bookInout !== 'I')
        unsupported('unsupported-book');
      if (!read('freshUpdate')) unsupported('fresh-update-required');
      const fold = read('saveFold');
      if (fold.upDown) unsupported('unsupported-updown');
      const b = bill();
      const credit = numeric(b.nAcCrAmt);
      const debit = numeric(b.nAcDrAmt);
      if (
        !credit.gt(0) ||
        !credit.isInteger() ||
        !debit.isZero() ||
        !numeric(fold.incomingNet38).gt(0) ||
        !numeric(fold.outgoingTotal24).isZero()
      )
        unsupported('unsupported-return-totals');
      for (const m of [read('beforeBill').matrix, b.matrix]) {
        for (let row = 1; row <= 8; row++)
          if (!numeric(cell(m, row, 4)).isZero()) unsupported('nonzero-received-or-tender');
        for (let row = 4; row <= 7; row++)
          if (!numeric(cell(m, row, 3)).isZero()) unsupported('nonzero-received-or-tender');
        if (!numeric(cell(m, 3, 3)).gt(0) || !numeric(cell(m, 8, 3)).gt(0))
          unsupported('unsupported-return-totals');
      }
    });
    return freeze({
      version: SALE_RETURN_SAVE_GUARDS_VERSION,
      profile: SALE_RETURN_SAVE_GUARDS_PROFILE,
      canCommit: false,
      status: 'ready',
      diagnostic: null,
      checks,
      observation,
    });
  } catch (error) {
    if (!(error instanceof Stop)) throw error;
    checks.push({ guard: current, outcome: error.status });
    return freeze({
      version: SALE_RETURN_SAVE_GUARDS_VERSION,
      profile: SALE_RETURN_SAVE_GUARDS_PROFILE,
      canCommit: false,
      status: error.status,
      diagnostic: { code: error.code, guard: current },
      checks,
      observation,
    });
  }
}
