import { Decimal } from 'decimal.js';

/** Seven SELECT projections only: Ac_Ledr1324/1326, Ac_Rojmel586/588,
 * Ac_Stock247, Ac_Tax191/193. No supplied token/qualifier creates authority. */
export const SALE_RETURN_FINANCIAL_EFFECTS_VERSION = 'primary-return-seven-financial-effects-v1';
export const SALE_RETURN_FINANCIAL_EFFECTS_PROFILE =
  'saved-one-pi-n-sr1-c27-t-zero-tax-existing-effects-v1';
const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
export type SaleReturnFinancialRaw = Readonly<Record<string, string | null>>;
export type SaleReturnFinancialRole =
  | 'incoming-customer-ledger'
  | 'incoming-sale-account-ledger'
  | 'return-outstanding-rojmel'
  | 'return-taxbook-summary-rojmel'
  | 'incoming-stock'
  | 'return-tax-sr1'
  | 'return-tax-sr2';
export type SaleReturnFinancialTable = 'AC_DATA' | 'ROJ_MEL_DATA' | 'MAIN_STOCK' | 'TAX_DATA';
export interface SaleReturnFinancialObservation {
  readonly physicalIdentity: string;
  readonly version: string;
  readonly raw: SaleReturnFinancialRaw;
}
export interface SaleReturnFinancialObserved {
  readonly acData: readonly SaleReturnFinancialObservation[];
  readonly rojMel: readonly SaleReturnFinancialObservation[];
  readonly mainStock: readonly SaleReturnFinancialObservation[];
  readonly taxData: readonly SaleReturnFinancialObservation[];
}
export interface SaleReturnFinancialPhase {
  readonly incoming: SaleReturnFinancialRaw;
  readonly header: SaleReturnFinancialRaw;
}
export type SaleReturnFinancialStorage =
  | { readonly status: 'unavailable'; readonly reason: string }
  | {
      readonly status: 'qualified';
      readonly observationIdentity: string;
      readonly values: Readonly<
        Record<
          | 'acEntryTime'
          | 'stockEntryDate'
          | 'stockDateText'
          | 'customerLedgerKey'
          | 'saleLedgerKey'
          | 'stockDiscountText'
          | 'taxZeroRatedText',
          string
        >
      >;
    };
export type SaleReturnFinancialContext =
  | { readonly status: 'unavailable'; readonly reason: string }
  | {
      readonly status: 'qualified';
      readonly observationIdentity: string;
      readonly companyShortName: string;
      readonly openingDate: string;
      readonly book: readonly SaleReturnFinancialRaw[];
      readonly bookDetail: readonly SaleReturnFinancialRaw[];
      readonly item: readonly SaleReturnFinancialRaw[];
      readonly group: readonly SaleReturnFinancialRaw[];
      readonly account: readonly SaleReturnFinancialRaw[];
      readonly taxes: readonly SaleReturnFinancialRaw[];
      readonly storage: SaleReturnFinancialStorage;
    };
export interface SaleReturnFinancialInput {
  readonly tenantId: string;
  readonly rowIdentity: string;
  readonly documentVersion: string;
  readonly context: SaleReturnFinancialContext;
  readonly before: SaleReturnFinancialPhase;
  readonly after: SaleReturnFinancialPhase;
  readonly observed: SaleReturnFinancialObserved;
}
export type SaleReturnFinancialProjection = Readonly<
  Record<SaleReturnFinancialRole, SaleReturnFinancialRaw>
>;
export type SaleReturnFinancialCode =
  | 'invalid-input'
  | 'invalid-raw'
  | 'missing-raw-field'
  | 'invalid-decimal'
  | 'unsupported-storage'
  | 'unsupported-profile'
  | 'unsupported-context'
  | 'context-unavailable'
  | 'unowned-source-change'
  | 'observed-membership-mismatch'
  | 'observation-identity-mismatch'
  | 'observation-value-mismatch'
  | 'unsupported-effect-change';
export interface SaleReturnFinancialDiagnostic {
  readonly code: SaleReturnFinancialCode;
  readonly message: string;
  readonly field?: string;
  readonly role?: SaleReturnFinancialRole;
}
export interface SaleReturnFinancialCandidate {
  readonly role: SaleReturnFinancialRole;
  readonly table: SaleReturnFinancialTable;
  readonly physicalIdentity: string;
  readonly version: string;
  readonly raw: SaleReturnFinancialRaw;
  readonly candidateRaw: SaleReturnFinancialRaw;
  readonly patch: Readonly<Record<string, string>>;
}
export interface SaleReturnFinancialResult {
  readonly version: typeof SALE_RETURN_FINANCIAL_EFFECTS_VERSION;
  readonly profile: typeof SALE_RETURN_FINANCIAL_EFFECTS_PROFILE;
  readonly status: 'ready' | 'unsupported';
  readonly canCommit: false;
  readonly tenantId: string | null;
  readonly rowIdentity: string | null;
  readonly documentVersion: string | null;
  readonly context: SaleReturnFinancialContext | null;
  readonly source: Readonly<{
    before: SaleReturnFinancialPhase | null;
    after: SaleReturnFinancialPhase | null;
  }>;
  readonly observed: SaleReturnFinancialObserved | null;
  readonly before: SaleReturnFinancialProjection | null;
  readonly after: SaleReturnFinancialProjection | null;
  readonly candidatePlan: readonly SaleReturnFinancialCandidate[] | null;
  readonly diagnostics: readonly SaleReturnFinancialDiagnostic[];
  readonly requirements: readonly string[];
}
const ROLES: readonly SaleReturnFinancialRole[] = [
  'incoming-customer-ledger',
  'incoming-sale-account-ledger',
  'return-outstanding-rojmel',
  'return-taxbook-summary-rojmel',
  'incoming-stock',
  'return-tax-sr1',
  'return-tax-sr2',
];
const TABLES: readonly SaleReturnFinancialTable[] = [
  'AC_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'TAX_DATA',
  'TAX_DATA',
];
const GROUPS = ['acData', 'acData', 'rojMel', 'rojMel', 'mainStock', 'taxData', 'taxData'] as const;
const PATCH_FIELDS = [
  ['CR_AMT'],
  ['DR_AMT'],
  ['CR_AMT'],
  ['DR_AMT'],
  ['OTH_AMT', 'NET_AMT'],
  ['NET_AMT', 'TOT_AMT'],
  ['NET_AMT', 'TOT_AMT'],
] as const;
const SCOPE = ['CO_CODE', 'LC_CODE', 'CO_YEAR', 'CO_BOOK', 'VCH_NO'] as const;
const REQUIREMENTS = Object.freeze([
  'trusted-complete-c27-hydration-replay-and-header-float-qualification',
  'complete-catalogue-and-effect-membership-physical-versions',
  'N-companions-and-all-other-effects-references-and-save-guards',
  'source-clock-STR-and-storage-witness-authority',
  'fresh-session-update-ordinary-permission-and-edition-audit-policy',
  'single-serializable-writer-typed-postconditions-and-rollback',
]);
class Refusal extends Error {
  constructor(
    readonly code: SaleReturnFinancialCode,
    message: string,
    readonly field?: string,
    readonly role?: SaleReturnFinancialRole,
  ) {
    super(message);
  }
}
function fail(
  code: SaleReturnFinancialCode,
  message: string,
  field?: string,
  role?: SaleReturnFinancialRole,
): never {
  throw new Refusal(code, message, field, role);
}
function rec(v: unknown): Record<string, unknown> {
  if (
    !v ||
    typeof v !== 'object' ||
    Array.isArray(v) ||
    ![Object.prototype, null].includes(Object.getPrototypeOf(v))
  )
    fail('invalid-input', 'An ordinary own-data record is required.');
  const ds = Object.getOwnPropertyDescriptors(v),
    keys = Reflect.ownKeys(ds);
  if (keys.length > 1024 || keys.some((k) => typeof k !== 'string'))
    fail('invalid-input', 'Unsupported record keys.');
  return Object.fromEntries(
    (keys as string[]).map((k) => {
      const d = ds[k]!;
      if (!d.enumerable || !Object.hasOwn(d, 'value'))
        fail('invalid-input', 'Accessors/non-enumerable fields are unsupported.');
      return [k, d.value];
    }),
  );
}
function exact(
  r: Record<string, unknown>,
  keys: readonly string[],
  code: SaleReturnFinancialCode = 'invalid-input',
) {
  if (Object.keys(r).length !== keys.length || keys.some((k) => !Object.hasOwn(r, k)))
    fail(code, 'Exact envelope fields are required.');
}
function arr(v: unknown, max = 8): unknown[] {
  if (!Array.isArray(v) || Object.getPrototypeOf(v) !== Array.prototype || v.length > max)
    fail('invalid-input', 'Bounded ordinary array required.');
  const ds = Object.getOwnPropertyDescriptors(v);
  if (Reflect.ownKeys(ds).length !== v.length + 1)
    fail('invalid-input', 'Sparse or decorated arrays are unsupported.');
  const out: unknown[] = [];
  for (let i = 0; i < v.length; i++) {
    const d = ds[String(i)];
    if (!d?.enumerable || !Object.hasOwn(d, 'value'))
      fail('invalid-input', 'Only dense data arrays are supported.');
    out.push(d.value);
  }
  return out;
}
function raw(v: unknown, table?: string): SaleReturnFinancialRaw {
  const r = rec(v);
  let size = 0;
  for (const [k, t] of Object.entries(r)) {
    if (
      !k ||
      k.length > 128 ||
      /[^\x20-\x7e]/.test(k) ||
      (t !== null && (typeof t !== 'string' || t.length > 65536))
    )
      fail('invalid-raw', 'Raw fields must be bounded exact strings/NULL.');
    size += k.length + (typeof t === 'string' ? t.length : 0);
  }
  if (size > 65536) fail('invalid-raw', 'Raw observation exceeds64KiB.');
  if (table)
    for (const k of REQUIRED[table]!)
      if (!Object.hasOwn(r, k))
        fail('missing-raw-field', 'A current-schema raw field is absent.', table + '.' + k);
  return Object.freeze(r) as SaleReturnFinancialRaw;
}
function hash(v: unknown): v is string {
  return typeof v === 'string' && /^[0-9a-f]{64}$/.test(v) && v.length === 64;
}
function token(v: unknown, max = 64): v is string {
  return typeof v === 'string' && v.length > 0 && v.length <= max && /^[A-Za-z0-9_-]+$/.test(v);
}
function canonical(v: unknown, max = 64): v is string {
  return typeof v === 'string' && v.length > 0 && v.length <= max && /^[A-Z0-9_-]+$/.test(v);
}
function num(v: string | null | undefined, field: string): Decimal {
  if (
    typeof v !== 'string' ||
    v.length > 128 ||
    /[^\x20-\x7e]/.test(v) ||
    !/^ *[+-]?(?:\d+(?:\.\d*)?|\.\d+) *$/.test(v)
  )
    fail('invalid-decimal', 'Finite bounded ASCII decimal required; NULL is not zero.', field);
  const d = new D(v.trim());
  if (!d.isFinite() || d.sd() > 36 || d.dp() > 18 || d.abs().gte('1e36'))
    fail('unsupported-storage', 'Decimal exceeds the mathematical profile.', field);
  return d;
}
function textNum(d: Decimal) {
  return d.isZero() ? '0' : d.toFixed();
}
function day(v: unknown): v is string {
  if (typeof v !== 'string' || !/^\d{4}-\d{2}-\d{2}$/.test(v)) return false;
  const y = BigInt(v.slice(0, 4)),
    m = BigInt(v.slice(5, 7)),
    d = BigInt(v.slice(8));
  if (y < 1n || m < 1n || m > 12n || d < 1n) return false;
  const leap = y % 4n === 0n && (y % 100n !== 0n || y % 400n === 0n);
  const days = m === 2n ? (leap ? 29n : 28n) : [4n, 6n, 9n, 11n].includes(m) ? 30n : 31n;
  return d <= days;
}
function clock(v: unknown): v is string {
  return (
    typeof v === 'string' &&
    v.length === 19 &&
    day(v.slice(0, 10)) &&
    /^T(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$/.test(v.slice(10))
  );
}
function wholeClock(v: string | null | undefined): string | null {
  if (
    typeof v !== 'string' ||
    !/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.0{1,6})?$/.test(v) ||
    !clock(v.slice(0, 19))
  )
    return null;
  return v.slice(0, 19);
}
function phase(v: unknown): SaleReturnFinancialPhase {
  const r = rec(v);
  exact(r, ['incoming', 'header']);
  return Object.freeze({
    incoming: raw(r.incoming, 'SL_DETL_RTN'),
    header: raw(r.header, 'SL_DATA'),
  });
}
function observed(v: unknown): SaleReturnFinancialObserved {
  const r = rec(v);
  exact(r, ['acData', 'rojMel', 'mainStock', 'taxData']);
  const entries = (['acData', 'rojMel', 'mainStock', 'taxData'] as const).map((g) => {
    const rows = arr(r[g]).map((v) => {
      const x = rec(v);
      exact(x, ['physicalIdentity', 'version', 'raw']);
      if (
        typeof x.physicalIdentity !== 'string' ||
        !x.physicalIdentity ||
        x.physicalIdentity.length > 128 ||
        !hash(x.version)
      )
        fail('invalid-input', 'Physical identity and observed version are required.');
      return Object.freeze({
        physicalIdentity: x.physicalIdentity,
        version: x.version,
        raw: raw(x.raw),
      });
    });
    return [g, Object.freeze(rows)];
  });
  return Object.freeze(Object.fromEntries(entries)) as unknown as SaleReturnFinancialObserved;
}
function recover(v: unknown): SaleReturnFinancialObserved | null {
  try {
    if (!v || typeof v !== 'object') return null;
    const d = Object.getOwnPropertyDescriptor(v, 'observed');
    return d && Object.hasOwn(d, 'value') ? observed(d.value) : null;
  } catch {
    return null;
  }
}
const MASTER = {
  book: [
    'CO_CODE',
    'LC_CODE',
    'CO_BOOK',
    'MAIN_BOOK',
    'BOOK_INOUT',
    'BOOK_TYPE',
    'BOOK_TBL_NAME',
    'BOOK_SNAME',
    'DATA_TYPE',
  ],
  bookDetail: [
    'CO_CODE',
    'LC_CODE',
    'CO_BOOK',
    'MAIN_BOOK',
    'BOOK_INOUT',
    'BOOK_TYPE',
    'BOOK_SNAME',
    'DATA_TYPE',
    'SR_NO',
    'AC_CODE',
  ],
  item: ['CO_CODE', 'IT_CODE', 'GR_CODE'],
  group: ['CO_CODE', 'GR_CODE', 'SALE_AC'],
  account: ['CO_CODE', 'AC_CODE', 'AC_GST_TYPE'],
  taxes: ['CO_CODE', 'TAX_CODE', 'SR_NO', 'TAX_GROUP', 'TAX_PRC'],
} as const;
const STORAGE = [
  'acEntryTime',
  'stockEntryDate',
  'stockDateText',
  'customerLedgerKey',
  'saleLedgerKey',
  'stockDiscountText',
  'taxZeroRatedText',
] as const;
function context(v: unknown): SaleReturnFinancialContext {
  const r = rec(v);
  if (r.status === 'unavailable') {
    exact(r, ['status', 'reason']);
    if (typeof r.reason !== 'string' || !r.reason.trim() || r.reason.length > 4096)
      fail('unsupported-context', 'A nonblank unavailability reason is required.');
    return Object.freeze(r) as unknown as SaleReturnFinancialContext;
  }
  exact(r, [
    'status',
    'observationIdentity',
    'companyShortName',
    'openingDate',
    ...Object.keys(MASTER),
    'storage',
  ]);
  if (
    r.status !== 'qualified' ||
    !hash(r.observationIdentity) ||
    !canonical(r.companyShortName, 32) ||
    r.companyShortName === 'UAE' ||
    !day(r.openingDate)
  )
    fail('unsupported-context', 'Canonical supplied non-UAE/opening context required.');
  const out: Record<string, unknown> = { ...r };
  for (const [k, keys] of Object.entries(MASTER)) {
    const items = arr(r[k]);
    if (items.length !== (k === 'taxes' ? 2 : 1))
      fail('unsupported-context', 'Exact selected master cardinality required.', k);
    out[k] = Object.freeze(
      items.map((v) => {
        const x = raw(v);
        exact(x, keys, 'unsupported-context');
        return x;
      }),
    );
  }
  const z = rec(r.storage);
  if (z.status === 'unavailable') {
    exact(z, ['status', 'reason']);
    if (typeof z.reason !== 'string' || !z.reason.trim() || z.reason.length > 4096)
      fail('unsupported-context', 'Storage reason required.');
    out.storage = Object.freeze(z);
  } else {
    exact(z, ['status', 'observationIdentity', 'values']);
    const x = rec(z.values);
    exact(x, STORAGE);
    if (
      z.status !== 'qualified' ||
      !hash(z.observationIdentity) ||
      Object.values(x).some((v) => typeof v !== 'string' || v.length > 128) ||
      !clock(x.acEntryTime) ||
      !day(x.stockEntryDate) ||
      !day(x.stockDateText) ||
      x.stockDiscountText !== '0' ||
      x.taxZeroRatedText !== '0'
    )
      fail('unsupported-context', 'Qualified current-PG storage witnesses required.');
    out.storage = Object.freeze({ ...z, values: Object.freeze(x) });
  }
  return Object.freeze(out) as unknown as SaleReturnFinancialContext;
}
function validateContext(
  c: Extract<SaleReturnFinancialContext, { status: 'qualified' }>,
  p: SaleReturnFinancialPhase,
) {
  if (c.storage.status !== 'qualified') fail('context-unavailable', c.storage.reason);
  const a = p.incoming,
    h = p.header,
    b = c.book[0]!,
    bd = c.bookDetail[0]!,
    it = c.item[0]!,
    gr = c.group[0]!,
    ac = c.account[0]!,
    s = c.storage.values;
  for (const x of [b, bd]) {
    if (
      x.MAIN_BOOK !== 'SALES RETURNE' ||
      x.BOOK_INOUT !== 'I' ||
      x.BOOK_TYPE !== 'T' ||
      !canonical(x.BOOK_SNAME, 5) ||
      !['A', 'B', 'C'].includes(x.DATA_TYPE ?? '')
    )
      fail('unsupported-context', 'Only canonical T/incoming book facts are supported.');
    for (const k of ['CO_CODE', 'LC_CODE', 'CO_BOOK'])
      if (x[k] !== a[k]) fail('unsupported-context', 'Selected book scope differs.', k);
  }
  if (
    b.BOOK_TBL_NAME !== 'SL_DATA' ||
    bd.SR_NO !== '1' ||
    !canonical(bd.AC_CODE, 8) ||
    !canonical(gr.SALE_AC, 8) ||
    !canonical(it.GR_CODE, 8) ||
    !canonical(a.IT_CODE, 5) ||
    !canonical(a.AC_CODE, 8) ||
    a.AC_CODE === '00045' ||
    ac.AC_GST_TYPE !== 'N' ||
    it.CO_CODE !== a.CO_CODE ||
    it.IT_CODE !== a.IT_CODE ||
    gr.CO_CODE !== a.CO_CODE ||
    gr.GR_CODE !== it.GR_CODE ||
    ac.CO_CODE !== a.CO_CODE ||
    ac.AC_CODE !== a.AC_CODE
  )
    fail('unsupported-context', 'Exact item/group/account/detail joins are required.');
  const serials = new Set<string>();
  for (const t of c.taxes) {
    if (
      t.CO_CODE !== a.CO_CODE ||
      t.TAX_CODE !== h.TAX_CODE ||
      !canonical(t.TAX_CODE, 2) ||
      !canonical(t.TAX_GROUP, 64) ||
      !['1', '2'].includes(t.SR_NO ?? '') ||
      serials.has(t.SR_NO!) ||
      !num(t.TAX_PRC, 'tax.TAX_PRC').isZero()
    )
      fail('unsupported-context', 'Exact two zero-rate non-interstate tax observations required.');
    serials.add(t.SR_NO!);
  }
  if (
    !day(a.VCH_DATE) ||
    a.VCH_DATE !== h.VCH_DATE ||
    a.VCH_DATE < c.openingDate ||
    a.AC_CODE !== h.AC_CODE
  )
    fail('unsupported-context', 'Coherent source day/account and opening predicate required.');
  const vchClock = wholeClock(a.VCH_TIME),
    headerClock = wholeClock(h.VCH_TIME);
  if (
    !vchClock ||
    vchClock !== headerClock ||
    vchClock !== s.acEntryTime ||
    s.stockEntryDate !== vchClock.slice(0, 10) ||
    s.stockDateText !== a.VCH_DATE
  )
    fail('unsupported-context', 'Supplied storage witnesses differ from source raw values.');
  const base = SCOPE.map((k) => a[k]).join('');
  if (
    s.customerLedgerKey !== base + '01' + '         1' ||
    s.saleLedgerKey !== base + '02' + '         1'
  )
    fail('unsupported-context', 'Qualified SR1 ten-column STR key differs from scope.');
}
const ZERO_HEADER =
  'NET_AMT TOT_AMT BILL_OS TAX_AMT CHQ_AMT CARD_AMT CASH_AMT KASAR_AMT RTN_CHQ_AMT RTN_CARD_AMT RTN_CASH_AMT RTN_KASAR_AMT HM_AMT HM_TAX_AMT DISC_AMT'.split(
    ' ',
  );
function validatePhase(p: SaleReturnFinancialPhase, tenant: string) {
  const a = p.incoming,
    h = p.header;
  for (const x of [a, h]) {
    if (x.tenant_id !== tenant) fail('unsupported-profile', 'Source tenant differs.');
    for (const [k, n] of Object.entries({ CO_CODE: 2, LC_CODE: 2, CO_YEAR: 10, CO_BOOK: 3 }))
      if (!canonical(x[k], n))
        fail('unsupported-profile', 'Canonical complete source scope required.', k);
    if (typeof x.VCH_NO !== 'string' || !/^\d{5}$/.test(x.VCH_NO))
      fail('unsupported-profile', 'Exact five-digit saved voucher required.');
  }
  if (
    SCOPE.some((k) => a[k] !== h[k]) ||
    a.ENTRY_TYPE !== 'P' ||
    a.INOUT_TYPE !== 'I' ||
    a.TAG_NO !== 'N' ||
    a.SR_NO !== '1' ||
    a.OLD_SRNO !== '1' ||
    !num(a.VCH_SRNO, 'VCH_SRNO').gt(0) ||
    !['A', 'B', 'C'].includes(a.DATA_TYPE ?? '') ||
    h.RATE_UNFIX !== 'N' ||
    h.USER_UPDATE !== 'N'
  )
    fail(
      'unsupported-profile',
      'Only stable primary P/I/N/SR1/OLD1 ordinary source values are supported.',
    );
  for (const k of ['ITM_MRP', 'DISC_PRC', 'DISC_AMT', 'TAX_PRC'])
    if (!num(a[k], k).isZero())
      fail('unsupported-profile', 'MRP/discount/row-tax variants remain unavailable.', k);
  if (
    !num(a.ITM_AMT, 'ITM_AMT').gt(0) ||
    !num(a.NET_AMT, 'NET_AMT').gt(0) ||
    !num(a.TOT_AMT, 'TOT_AMT').gt(0) ||
    num(a.ITM_NWT, 'ITM_NWT').plus(num(a.NET_AMT, 'NET_AMT')).isZero()
  )
    fail('unsupported-profile', 'Positive ordinary retained metal/row membership required.');
  for (const k of ZERO_HEADER)
    if (!num(h[k], k).isZero())
      fail('unsupported-profile', 'The zero tax/tender/received profile is required.', k);
  for (const k of ['RTN_NET_AMT', 'RTN_TOT_AMT', 'RTN_BILL_OS'])
    if (!num(h[k], k).gt(0))
      fail('unsupported-profile', 'Positive incoming header effect required.', k);
  // Validate every amount that may become a candidate, even if malformed values
  // otherwise cancel in an aggregate. This does not calculate row/header totals.
  for (const k of ['OTH_AMT', 'TOT_AMT', 'NET_AMT'])
    typed('MAIN_STOCK', k === 'TOT_AMT' ? 'NET_AMT' : k, a[k]!);
}
function unchanged(b: SaleReturnFinancialRaw, a: SaleReturnFinancialRaw, allow: readonly string[]) {
  const keys = new Set([...Object.keys(b), ...Object.keys(a)]);
  for (const k of keys)
    if (!Object.hasOwn(b, k) || !Object.hasOwn(a, k) || (!allow.includes(k) && b[k] !== a[k]))
      fail('unowned-source-change', 'Unowned source field/key must remain exact.', k);
}
function typed(table: string, field: string, v: string | null): string | null {
  const t = TARGET[table]?.[field];
  if (!t) fail('unsupported-storage', 'No target schema classification.', field);
  if (v === null) {
    if (!t.nullable) fail('unsupported-storage', 'NULL cannot populate this target.', field);
    return null;
  }
  if (t.type === 'Decimal') {
    const d = num(v, field);
    if (d.dp() > t.scale! || d.abs().gte(new D(10).pow(t.precision! - t.scale!)))
      fail(
        'unsupported-storage',
        'Exact target numeric precision/scale exceeded.',
        table + '.' + field,
      );
    return d.toFixed(t.scale!);
  }
  if (t.type === 'Float') {
    return textNum(num(v, field));
  }
  if (t.type === 'DateTime') {
    if (t.storage === 'date' ? !day(v) : !clock(v))
      fail('unsupported-storage', 'An explicit canonical target date/clock is required.', field);
  }
  if (t.maxLength !== undefined && [...v].length > t.maxLength)
    fail('unsupported-storage', 'Target text length exceeded.', field);
  return v;
}
function project(
  p: SaleReturnFinancialPhase,
  c: Extract<SaleReturnFinancialContext, { status: 'qualified' }>,
): SaleReturnFinancialProjection {
  if (c.storage.status !== 'qualified') fail('context-unavailable', c.storage.reason);
  const a = p.incoming,
    h = p.header,
    b = c.book[0]!,
    bd = c.bookDetail[0]!,
    g = c.group[0]!,
    s = c.storage.values;
  const scope = Object.fromEntries(SCOPE.map((k) => [k, a[k]!])),
    key = SCOPE.map((k) => a[k]).join('');
  const ac: Record<string, string | null> = {
    ...scope,
    VCH_TYPE: b.BOOK_SNAME!,
    VCH_DATE: a.VCH_DATE!,
    LEDR_KEY: s.customerLedgerKey,
    BOOK_NAME: b.MAIN_BOOK!,
    BILL_NO: '',
    BILL_DATE: null,
    CHQ_NO: '',
    AC_CODE: a.AC_CODE!,
    LD_CODE: g.SALE_AC!,
    CR_AMT: a.NET_AMT!,
    DR_AMT: '0',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: '0',
    IT_DESC: '',
    ENTRY_TIME: s.acEntryTime,
    HD_VCH_NO: a.HD_VCH_NO!,
    CLR_DATE: null,
    DATA_TYPE: b.DATA_TYPE!,
    DATA_TRFR: 'N',
    MAIN_USER: a.MAIN_USER!,
    FINE_RATE: '0',
    PARTY_AC_CODE: a.AC_CODE!,
    LDR_NAME: '',
  };
  const sale = {
    ...ac,
    LEDR_KEY: s.saleLedgerKey,
    AC_CODE: g.SALE_AC!,
    LD_CODE: a.AC_CODE!,
    CR_AMT: '0',
    DR_AMT: a.NET_AMT!,
    PARTY_AC_CODE: '',
  };
  const roj: Record<string, string | null> = {
    ...scope,
    LEDR_KEY: key + '01',
    VCH_DATE: h.VCH_DATE!,
    VCH_TYPE: bd.BOOK_SNAME!,
    BOOK_NAME: bd.MAIN_BOOK!,
    AC_CODE: h.AC_CODE!,
    LD_CODE: bd.AC_CODE!,
    CR_AMT: h.RTN_BILL_OS!,
    DR_AMT: '0',
    AC_NAME: '',
    IT_TYPE: 'A',
    SIGN: '',
    IT_DESC: h.VCH_DESC!,
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: bd.DATA_TYPE!,
  };
  for (const k of 'ITM_PCS ITM_GWT ITM_NWT ITM_TOUCH ITM_WEST ITM_FINE ITM_RATE ITM_AMT LBR_RATE LBR_AMT OTH_AMT NET_AMT'.split(
    ' ',
  ))
    roj[k] = '0';
  // SQL string concatenation propagates NULL; no empty-name fallback.
  const summary = {
    ...roj,
    LEDR_KEY: key + '02',
    CR_AMT: '0',
    DR_AMT: h.RTN_NET_AMT!,
    AC_NAME: h.AC_NAME === null ? null : 'RTN - ' + h.AC_NAME,
  };
  const stock: Record<string, string | null> = {
    ...scope,
    SR_NO: '2',
    ISR_NO: a.SR_NO!,
    VCH_DATE: a.VCH_DATE!,
    STK_DATE: s.stockDateText,
    VCH_TYPE: b.BOOK_SNAME!,
    BOOK_NAME: b.MAIN_BOOK!,
    AC_CODE: a.AC_CODE!,
    IT_CODE: a.IT_CODE!,
    TAG_NO: a.TAG_NO!,
    VCH_SRNO: a.VCH_SRNO!,
    TBL_CODE: a.TBL_CODE!,
    TR_TYPE: 'I',
    ITM_SIGN: '+',
    ITM_QTY: '1',
    ITM_MRP: '0',
    KR_NWT: a.ITM_NWT!,
    KR_TOUCH: a.ITM_TOUCH!,
    KR_WEST: a.ITM_WEST_PRC!,
    KR_FINE: a.ITM_FINE!,
    KR_LBR_AMT: '0',
    KR_OTH_AMT: '0',
    KR_COST: a.TAG_COST!,
    EMP_CODE: a.EMP_CODE!,
    ENTRY_TIME: s.stockEntryDate,
    MAIN_USER: a.MAIN_USER!,
    DATA_TYPE: a.DATA_TYPE!,
    DESIGN_NO: a.DESIGN_NO!,
    ITM_SIZE: a.ITM_SIZE!,
    ITM_DESC: '',
    GHT_PRC: a.ITM_GHT_PRC!,
    ITM_LOT: '',
    ITM_DISC: s.stockDiscountText,
  };
  for (const k of 'ITM_PCS ITM_GWT ITM_NWT ITM_TOUCH ITM_FINE ITM_RATE ITM_AMT LBR_RATE LBR_AMT OTH_AMT NET_AMT'.split(
    ' ',
  ))
    stock[k] = a[k]!;
  stock.ITM_WEST = a.ITM_WEST_PRC!;
  const taxes = ['1', '2'].map((sr) => {
    const t = c.taxes.find((t) => t.SR_NO === sr)!;
    return {
      ...scope,
      SR_NO: sr,
      BOOK_NAME: b.MAIN_BOOK!,
      TRAN_TYPE: 'S',
      VCH_DATE: h.VCH_DATE!,
      AC_CODE: h.AC_CODE!,
      TAX_CODE: h.TAX_CODE!,
      TAX_TYPE: t.TAX_GROUP!,
      TAX_PRC: t.TAX_PRC!,
      NET_AMT: h.RTN_NET_AMT!,
      TAX_AMT: textNum(num(h.TAX_AMT, 'TAX_AMT').div(2)),
      DISC_AMT: '0',
      TOT_AMT: h.RTN_TOT_AMT!,
      TAX_SIGN: '-',
      PARTY_NAME: h.AC_NAME!,
      R_CHARG: 'N',
      ISR_NO: '0',
      TAX_FREE_AMT: '0',
      ZERO_RATED_AMT: s.taxZeroRatedText,
    };
  });
  const maps = [ac, sale, roj, summary, stock, ...taxes];
  return Object.freeze(
    Object.fromEntries(
      ROLES.map((role, i) => [
        role,
        Object.freeze(
          Object.fromEntries(
            Object.entries(maps[i]!).map(([k, v]) => [k, typed(TABLES[i]!, k, v)]),
          ),
        ),
      ]),
    ),
  ) as SaleReturnFinancialProjection;
}
function equals(table: SaleReturnFinancialTable, k: string, a: string | null, b: string | null) {
  if (a === null || b === null) return a === b;
  const t = TARGET[table]![k]!;
  if (t.type === 'Decimal' || t.type === 'Float') {
    typed(table, k, a);
    return num(a, k).eq(num(b, k));
  }
  return a === b;
}

export function planSaleReturnFinancialEffects(input: unknown): SaleReturnFinancialResult {
  let obs = recover(input),
    ctx: SaleReturnFinancialContext | null = null,
    b: SaleReturnFinancialPhase | null = null,
    a: SaleReturnFinancialPhase | null = null,
    bp: SaleReturnFinancialProjection | null = null,
    ap: SaleReturnFinancialProjection | null = null,
    tenantId: string | null = null,
    rowIdentity: string | null = null,
    documentVersion: string | null = null;
  const diagnostics: SaleReturnFinancialDiagnostic[] = [];
  const add = (e: unknown) => {
    const x =
      e instanceof Refusal
        ? e
        : new Refusal('invalid-input', 'The supplied data could not be inspected safely.');
    diagnostics.push(
      Object.freeze({
        code: x.code,
        message: x.message,
        ...(x.field ? { field: x.field } : {}),
        ...(x.role ? { role: x.role } : {}),
      }),
    );
  };
  const result = (
    candidatePlan: readonly SaleReturnFinancialCandidate[] | null,
  ): SaleReturnFinancialResult =>
    Object.freeze({
      version: SALE_RETURN_FINANCIAL_EFFECTS_VERSION,
      profile: SALE_RETURN_FINANCIAL_EFFECTS_PROFILE,
      status: candidatePlan ? 'ready' : 'unsupported',
      canCommit: false,
      tenantId,
      rowIdentity,
      documentVersion,
      context: ctx,
      source: Object.freeze({ before: b, after: a }),
      observed: obs,
      before: bp,
      after: ap,
      candidatePlan,
      diagnostics: Object.freeze([...diagnostics]),
      requirements: REQUIREMENTS,
    });
  try {
    const r = rec(input);
    exact(r, [
      'tenantId',
      'rowIdentity',
      'documentVersion',
      'context',
      'before',
      'after',
      'observed',
    ]);
    if (!token(r.tenantId, 24) || !hash(r.rowIdentity) || !hash(r.documentVersion))
      fail('invalid-input', 'Tenant and observed document/row identities are required.');
    tenantId = r.tenantId;
    rowIdentity = r.rowIdentity;
    documentVersion = r.documentVersion;
    obs = observed(r.observed);
    ctx = context(r.context);
    if (ctx.status === 'unavailable') fail('context-unavailable', ctx.reason);
    const c = ctx;
    try {
      b = phase(r.before);
      validatePhase(b, tenantId);
      validateContext(c, b);
      bp = project(b, c);
    } catch (e) {
      add(e);
    }
    try {
      a = phase(r.after);
      validatePhase(a, tenantId);
      validateContext(c, a);
      ap = project(a, c);
    } catch (e) {
      add(e);
    }
    if (!b || !a || !bp || !ap || diagnostics.length) return result(null);
    unchanged(b.incoming, a.incoming, ['OTH_AMT', 'TOT_AMT', 'NET_AMT']);
    unchanged(b.header, a.header, ['RTN_NET_AMT', 'RTN_TOT_AMT', 'RTN_BILL_OS']);
    for (const [g, n] of Object.entries({ acData: 2, rojMel: 2, mainStock: 1, taxData: 2 }))
      if (obs[g as keyof SaleReturnFinancialObserved].length !== n)
        fail('observed-membership-mismatch', 'Exactly seven existing role rows required.', g);
    for (const [g, table] of [
      ['acData', 'AC_DATA'],
      ['rojMel', 'ROJ_MEL_DATA'],
      ['mainStock', 'MAIN_STOCK'],
      ['taxData', 'TAX_DATA'],
    ] as const)
      for (const o of obs[g])
        for (const k of REQUIRED[table]!)
          if (!Object.hasOwn(o.raw, k))
            fail('missing-raw-field', 'A current-schema raw field is absent.', table + '.' + k);
    const plans: SaleReturnFinancialCandidate[] = [];
    const used = new Set<SaleReturnFinancialObservation>(),
      physical = new Set<string>();
    for (let i = 0; i < ROLES.length; i++) {
      const role = ROLES[i]!,
        table = TABLES[i]!,
        before = bp[role],
        after = ap[role],
        members = obs[GROUPS[i]!];
      const match = members.filter((o) =>
        table === 'AC_DATA' || table === 'ROJ_MEL_DATA'
          ? o.raw.LEDR_KEY === before.LEDR_KEY
          : table === 'TAX_DATA'
            ? o.raw.SR_NO === before.SR_NO
            : o.raw.SR_NO === before.SR_NO && o.raw.ISR_NO === before.ISR_NO,
      );
      if (match.length !== 1 || used.has(match[0]!))
        fail(
          'observed-membership-mismatch',
          'Exact role locator must select one existing row.',
          undefined,
          role,
        );
      const o = match[0]!;
      used.add(o);
      const pid = table + ':' + o.physicalIdentity;
      if (
        physical.has(pid) ||
        o.raw.tenant_id !== tenantId ||
        SCOPE.some((k) => o.raw[k] !== b!.incoming[k]) ||
        (table === 'ROJ_MEL_DATA'
          ? o.physicalIdentity !== o.raw.LEDR_KEY
          : !/^\d+$/.test(o.physicalIdentity) ||
            o.physicalIdentity.startsWith('0') ||
            BigInt(o.physicalIdentity) > 9223372036854775807n ||
            o.physicalIdentity !== o.raw.row_id)
      )
        fail(
          'observation-identity-mismatch',
          'Physical identity, tenant and full scope must agree.',
          undefined,
          role,
        );
      physical.add(pid);
      const patch: Record<string, string> = {};
      for (const [k, v] of Object.entries(before)) {
        if (!equals(table, k, o.raw[k]!, v))
          fail(
            'observation-value-mismatch',
            'Existing source-owned field differs from the complete old projection.',
            k,
            role,
          );
        if (!equals(table, k, v, after[k]!)) {
          if (!(PATCH_FIELDS[i] as readonly string[]).includes(k) || typeof after[k] !== 'string')
            fail(
              'unsupported-effect-change',
              'Changed effect field is not owned by the c27 planner.',
              k,
              role,
            );
          patch[k] = after[k] as string;
        }
      }
      plans.push(
        Object.freeze({
          role,
          table,
          physicalIdentity: o.physicalIdentity,
          version: o.version,
          raw: o.raw,
          candidateRaw: Object.freeze({ ...o.raw, ...patch }),
          patch: Object.freeze(patch),
        }),
      );
    }
    return result(Object.freeze(plans));
  } catch (e) {
    add(e);
    return result(null);
  }
}

// Current-schema minimum fields; opaque future raw fields are retained. Target
// classifications are pinned to schema.prisma in the staged storage index.
interface Target {
  readonly type: string;
  readonly nullable: boolean;
  readonly precision?: number;
  readonly scale?: number;
  readonly maxLength?: number;
  readonly storage?: string;
}
const REQUIRED: Readonly<Record<string, readonly string[]>> = {
  AC_DATA: [
    'tenant_id',
    'row_id',
    'VCH_NO',
    'CO_CODE',
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_TYPE',
    'VCH_DATE',
    'LEDR_KEY',
    'BOOK_NAME',
    'BILL_NO',
    'BILL_DATE',
    'CHQ_NO',
    'AC_CODE',
    'LD_CODE',
    'CR_AMT',
    'DR_AMT',
    'IT_TYPE',
    'SIGN',
    'FINE_WT',
    'IT_DESC',
    'ENTRY_TIME',
    'HD_VCH_NO',
    'CLR_DATE',
    'DATA_TYPE',
    'DATA_TRFR',
    'MAIN_USER',
    'FINE_RATE',
    'PARTY_AC_CODE',
    'LDR_NAME',
  ],
  ROJ_MEL_DATA: [
    'tenant_id',
    'CO_CODE',
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_NO',
    'LEDR_KEY',
    'VCH_DATE',
    'VCH_TYPE',
    'BOOK_NAME',
    'AC_CODE',
    'AC_NAME',
    'LD_CODE',
    'CR_AMT',
    'DR_AMT',
    'IT_TYPE',
    'SIGN',
    'ITM_PCS',
    'ITM_GWT',
    'ITM_NWT',
    'ITM_TOUCH',
    'ITM_WEST',
    'ITM_FINE',
    'ITM_RATE',
    'ITM_AMT',
    'LBR_RATE',
    'LBR_AMT',
    'OTH_AMT',
    'NET_AMT',
    'IT_DESC',
    'IT_CODE',
    'MEMB_CODE',
    'SCHM_CODE',
    'REF_NO',
    'DATA_TYPE',
  ],
  MAIN_STOCK: [
    'tenant_id',
    'row_id',
    'VCH_SRNO',
    'CO_CODE',
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_NO',
    'SR_NO',
    'ISR_NO',
    'VCH_DATE',
    'STK_DATE',
    'VCH_TYPE',
    'BOOK_NAME',
    'AC_CODE',
    'IT_CODE',
    'TAG_NO',
    'TBL_CODE',
    'TR_TYPE',
    'ITM_SIGN',
    'ITM_QTY',
    'ITM_PCS',
    'ITM_GWT',
    'ITM_NWT',
    'ITM_TOUCH',
    'ITM_WEST',
    'ITM_FINE',
    'ITM_RATE',
    'ITM_AMT',
    'LBR_RATE',
    'LBR_AMT',
    'OTH_AMT',
    'ITM_MRP',
    'NET_AMT',
    'KR_NWT',
    'KR_TOUCH',
    'KR_WEST',
    'KR_FINE',
    'KR_LBR_AMT',
    'KR_OTH_AMT',
    'KR_COST',
    'EMP_CODE',
    'ENTRY_TIME',
    'MAIN_USER',
    'DATA_TYPE',
    'DESIGN_NO',
    'ITM_SIZE',
    'ITM_DESC',
    'GHT_PRC',
    'ITM_LOT',
    'ITM_DISC',
    'GRID_SCROLL',
    'OTH_FINE',
    'ITM_COLOR',
  ],
  TAX_DATA: [
    'tenant_id',
    'row_id',
    'CO_CODE',
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_NO',
    'SR_NO',
    'BOOK_NAME',
    'TRAN_TYPE',
    'VCH_DATE',
    'AC_CODE',
    'TAX_CODE',
    'TAX_TYPE',
    'TAX_PRC',
    'NET_AMT',
    'TAX_AMT',
    'DISC_AMT',
    'TOT_AMT',
    'TAX_SIGN',
    'PARTY_NAME',
    'R_CHARG',
    'ISR_NO',
    'TAX_FREE_AMT',
    'ZERO_RATED_AMT',
    'BILL_NO',
    'BILL_DATE',
    'BILL_DBCD',
    'VCH_SRNO',
  ],
  SL_DETL_RTN: [
    'tenant_id',
    'CO_CODE',
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_NO',
    'SR_NO',
    'OLD_SRNO',
    'VCH_DATE',
    'VCH_TYPE',
    'INOUT_TYPE',
    'ENTRY_TYPE',
    'VCH_TIME',
    'BOOK_NAME',
    'AC_CODE',
    'IT_CODE',
    'TAG_NO',
    'TBL_CODE',
    'DESIGN_NO',
    'ITM_SIZE',
    'ITM_PCS',
    'ITM_GWT',
    'ITM_OTH_WT',
    'ITM_NWT',
    'ITM_GHT_WT',
    'ITM_TOUCH',
    'ITM_WEST_PRC',
    'ITM_FINE',
    'ITM_RATE',
    'ITM_AMT',
    'LBR_TYPE',
    'LBR_PRC',
    'LBR_RATE',
    'LBR_AMT',
    'OTH_AMT',
    'TAG_LBR_PRC',
    'TAG_LBR_RATE',
    'TAG_LBR_AMT',
    'TAG_OTH_AMT',
    'ITM_MRP',
    'TOT_AMT',
    'TAX_PRC',
    'NET_AMT',
    'RATE_TYPE',
    'IT_TYPE',
    'HD_VCH_NO',
    'MAIN_USER',
    'DATA_TRFR',
    'KR_NAME',
    'TAG_COST',
    'ITM_MARGIN',
    'VCH_SRNO',
    'TAG_TYPE',
    'PR_CODE',
    'TAG_SRNO',
    'ITM_GHT_PRC',
    'HM_ID2',
    'HM_ID3',
    'HM_ID4',
    'HM_ID_WT',
    'HM_ID2_WT',
    'HM_ID3_WT',
    'HM_ID4_WT',
    'HM_ID',
    'ITM_REMARK',
    'ITM_COLOR',
    'EMP_CODE',
    'LBR_CODE',
    'TAG_MRP',
    'TAG_LBR_CODE',
    'DESIGN_IMG_ID',
    'EMP_ISU',
    'APR_ISU',
    'ITM_STYLE',
    'ITM_LOT',
    'DISC_PRC',
    'DISC_AMT',
    'RTN_IT_TAX_AMT',
    'DATA_TYPE',
  ],
  SL_DATA: [
    'LDR_CODE',
    'tenant_id',
    'row_id',
    'VCH_NO',
    'IRN_NO',
    'CO_CODE',
    'LC_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_DATE',
    'VCH_TIME',
    'BILL_NO',
    'HD_VCH_NO',
    'AC_CODE',
    'AC_NAME',
    'NET_AMT',
    'DISC_PRC',
    'DISC_AMT',
    'TAX_CODE',
    'TAX_PRC',
    'TAX_AMT',
    'ROF_AMT',
    'TOT_AMT',
    'ADV_AMT',
    'OLD_GL_AMT',
    'OLD_SL_AMT',
    'CASH_AMT',
    'CARD_AMT',
    'CHQ_AMT',
    'SCHM_AMT',
    'CASH_PAID',
    'KASAR_AMT',
    'BILL_OS',
    'OS_ADJ_AMT',
    'CR_DAYS',
    'CARD_AC',
    'BANK_AC',
    'CHQ_NO',
    'BANK_NAME',
    'EMP_CODE',
    'VCH_DESC',
    'ENTRY_TIME',
    'OLD_GL',
    'OLD_SL',
    'ADD1',
    'ADD2',
    'ADD3',
    'CITY',
    'MOBILE',
    'AC_GST_TYPE',
    'IGST_TAX',
    'CGST_TAX',
    'SGST_TAX',
    'DATA_TRFR',
    'OLD_VCH_NO',
    'NEW_VCH_NO',
    'MAIN_USER',
    'SCHM_AC',
    'CARD_ADJ',
    'ISU_NO',
    'ISU_LC_CODE',
    'ISU_YRCD',
    'ISU_DBCD',
    'RTN_NET_AMT',
    'RTN_TOT_AMT',
    'RTN_CHQ_AMT',
    'RTN_CARD_AMT',
    'RTN_CASH_AMT',
    'RTN_KASAR_AMT',
    'RTN_BILL_OS',
    'TCS_CODE',
    'TCS_PRC',
    'TCS_AMT',
    'HM_AMT',
    'HM_TAX_PRC',
    'HM_TAX_AMT',
    'HM_TAX_CODE',
    'TDS_CODE',
    'TDS_PRC',
    'TDS_AMT',
    'CARD_COM_AMT',
    'USER_UPDATE',
    'USER_DELETE',
    'POINT_VAL',
    'ACK_NO',
    'ACK_DATE',
    'ORNA_ISU',
    'MOB_ENTRY_SAVE',
    'UPI_AMT',
    'LBR_AMT',
    'OTH_AMT',
    'CRNT_ADJ_AMT',
    'PARTY_FINE',
    'IT_TYPE',
    'OZ_RATE',
    'OZ_CONV',
    'FX_RATE',
    'FX_CODE',
    'MTL_RATE',
    'TOT_TAX_FREE_AMT',
    'ZERO_RATED_AMT',
    'RATE_UNFIX',
  ],
};
const TARGET: Readonly<Record<string, Readonly<Record<string, Target>>>> = {
  AC_DATA: {
    tenant_id: { type: 'String', nullable: false, maxLength: 24 },
    row_id: { type: 'BigInt', nullable: false },
    VCH_NO: { type: 'String', nullable: true, maxLength: 8 },
    CO_CODE: { type: 'String', nullable: true, maxLength: 2 },
    LC_CODE: { type: 'String', nullable: true, maxLength: 2 },
    CO_YEAR: { type: 'String', nullable: true, maxLength: 10 },
    CO_BOOK: { type: 'String', nullable: true, maxLength: 3 },
    VCH_TYPE: { type: 'String', nullable: true, maxLength: 6 },
    VCH_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    LEDR_KEY: { type: 'String', nullable: true, maxLength: 50 },
    BOOK_NAME: { type: 'String', nullable: true },
    BILL_NO: { type: 'String', nullable: true, maxLength: 30 },
    BILL_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    CHQ_NO: { type: 'String', nullable: true, maxLength: 10 },
    AC_CODE: { type: 'String', nullable: true, maxLength: 8 },
    LD_CODE: { type: 'String', nullable: true, maxLength: 8 },
    CR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    DR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    IT_TYPE: { type: 'String', nullable: true, maxLength: 1 },
    SIGN: { type: 'String', nullable: true, maxLength: 1 },
    FINE_WT: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    IT_DESC: { type: 'String', nullable: true },
    ENTRY_TIME: { type: 'DateTime', nullable: true, storage: 'timestamp6' },
    HD_VCH_NO: { type: 'String', nullable: true, maxLength: 10 },
    CLR_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    DATA_TYPE: { type: 'String', nullable: true, maxLength: 1 },
    DATA_TRFR: { type: 'String', nullable: true, maxLength: 1 },
    MAIN_USER: { type: 'String', nullable: true, maxLength: 15 },
    FINE_RATE: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    PARTY_AC_CODE: { type: 'String', nullable: true, maxLength: 255 },
    LDR_NAME: { type: 'String', nullable: true, maxLength: 255 },
  },
  ROJ_MEL_DATA: {
    tenant_id: { type: 'String', nullable: false, maxLength: 24 },
    CO_CODE: { type: 'String', nullable: true, maxLength: 2 },
    LC_CODE: { type: 'String', nullable: true, maxLength: 2 },
    CO_YEAR: { type: 'String', nullable: true, maxLength: 10 },
    CO_BOOK: { type: 'String', nullable: true, maxLength: 3 },
    VCH_NO: { type: 'String', nullable: true, maxLength: 8 },
    LEDR_KEY: { type: 'String', nullable: false, maxLength: 50 },
    VCH_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    VCH_TYPE: { type: 'String', nullable: true, maxLength: 6 },
    BOOK_NAME: { type: 'String', nullable: true, maxLength: 20 },
    AC_CODE: { type: 'String', nullable: true, maxLength: 8 },
    AC_NAME: { type: 'String', nullable: true },
    LD_CODE: { type: 'String', nullable: true, maxLength: 8 },
    CR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    DR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    IT_TYPE: { type: 'String', nullable: true, maxLength: 1 },
    SIGN: { type: 'String', nullable: true, maxLength: 1 },
    ITM_PCS: { type: 'Decimal', nullable: true, precision: 12, scale: 3 },
    ITM_GWT: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_NWT: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_TOUCH: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_WEST: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_FINE: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_RATE: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    ITM_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    LBR_RATE: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    LBR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    OTH_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    NET_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    IT_DESC: { type: 'String', nullable: true },
    IT_CODE: { type: 'String', nullable: true, maxLength: 5 },
    MEMB_CODE: { type: 'String', nullable: true, maxLength: 5 },
    SCHM_CODE: { type: 'String', nullable: true, maxLength: 3 },
    REF_NO: { type: 'String', nullable: true, maxLength: 20 },
    DATA_TYPE: { type: 'String', nullable: true, maxLength: 1 },
  },
  MAIN_STOCK: {
    tenant_id: { type: 'String', nullable: false, maxLength: 24 },
    row_id: { type: 'BigInt', nullable: false },
    VCH_SRNO: { type: 'Float', nullable: true },
    CO_CODE: { type: 'String', nullable: true, maxLength: 2 },
    LC_CODE: { type: 'String', nullable: true },
    CO_YEAR: { type: 'String', nullable: true, maxLength: 10 },
    CO_BOOK: { type: 'String', nullable: true, maxLength: 3 },
    VCH_NO: { type: 'String', nullable: true, maxLength: 8 },
    SR_NO: { type: 'Float', nullable: true },
    ISR_NO: { type: 'Float', nullable: true },
    VCH_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    STK_DATE: { type: 'String', nullable: true, maxLength: 255 },
    VCH_TYPE: { type: 'String', nullable: true, maxLength: 6 },
    BOOK_NAME: { type: 'String', nullable: true },
    AC_CODE: { type: 'String', nullable: true },
    IT_CODE: { type: 'String', nullable: true, maxLength: 5 },
    TAG_NO: { type: 'String', nullable: true, maxLength: 15 },
    TBL_CODE: { type: 'String', nullable: true },
    TR_TYPE: { type: 'String', nullable: true, maxLength: 1 },
    ITM_SIGN: { type: 'String', nullable: true, maxLength: 1 },
    ITM_QTY: { type: 'Decimal', nullable: true, precision: 12, scale: 3 },
    ITM_PCS: { type: 'Decimal', nullable: true, precision: 12, scale: 3 },
    ITM_GWT: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_NWT: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_TOUCH: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_WEST: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_FINE: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_RATE: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    ITM_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    LBR_RATE: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    LBR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    OTH_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    ITM_MRP: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    NET_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    KR_NWT: { type: 'Float', nullable: true },
    KR_TOUCH: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    KR_WEST: { type: 'Float', nullable: true },
    KR_FINE: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    KR_LBR_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    KR_OTH_AMT: { type: 'Float', nullable: true },
    KR_COST: { type: 'Float', nullable: true },
    EMP_CODE: { type: 'String', nullable: true, maxLength: 3 },
    ENTRY_TIME: { type: 'DateTime', nullable: true, storage: 'date' },
    MAIN_USER: { type: 'String', nullable: true, maxLength: 15 },
    DATA_TYPE: { type: 'String', nullable: true, maxLength: 1 },
    DESIGN_NO: { type: 'String', nullable: true },
    ITM_SIZE: { type: 'String', nullable: true, maxLength: 20 },
    ITM_DESC: { type: 'String', nullable: true, maxLength: 255 },
    GHT_PRC: { type: 'Decimal', nullable: true, precision: 9, scale: 4 },
    ITM_LOT: { type: 'String', nullable: true, maxLength: 255 },
    ITM_DISC: { type: 'String', nullable: true, maxLength: 255 },
    GRID_SCROLL: { type: 'String', nullable: true, maxLength: 255 },
    OTH_FINE: { type: 'Decimal', nullable: true, precision: 14, scale: 3 },
    ITM_COLOR: { type: 'String', nullable: true, maxLength: 15 },
  },
  TAX_DATA: {
    tenant_id: { type: 'String', nullable: false, maxLength: 24 },
    row_id: { type: 'BigInt', nullable: false },
    CO_CODE: { type: 'String', nullable: true, maxLength: 2 },
    LC_CODE: { type: 'String', nullable: true, maxLength: 2 },
    CO_YEAR: { type: 'String', nullable: true, maxLength: 10 },
    CO_BOOK: { type: 'String', nullable: true, maxLength: 3 },
    VCH_NO: { type: 'String', nullable: true },
    SR_NO: { type: 'Float', nullable: true },
    BOOK_NAME: { type: 'String', nullable: true, maxLength: 20 },
    TRAN_TYPE: { type: 'String', nullable: true, maxLength: 255 },
    VCH_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    AC_CODE: { type: 'String', nullable: true },
    TAX_CODE: { type: 'String', nullable: true, maxLength: 2 },
    TAX_TYPE: { type: 'String', nullable: true },
    TAX_PRC: { type: 'Decimal', nullable: true, precision: 9, scale: 4 },
    NET_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    TAX_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 3 },
    DISC_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    TOT_AMT: { type: 'Decimal', nullable: true, precision: 18, scale: 2 },
    TAX_SIGN: { type: 'String', nullable: true, maxLength: 255 },
    PARTY_NAME: { type: 'String', nullable: true, maxLength: 255 },
    R_CHARG: { type: 'String', nullable: true, maxLength: 255 },
    ISR_NO: { type: 'Float', nullable: true },
    TAX_FREE_AMT: { type: 'Float', nullable: true },
    ZERO_RATED_AMT: { type: 'String', nullable: true, maxLength: 255 },
    BILL_NO: { type: 'String', nullable: true, maxLength: 20 },
    BILL_DATE: { type: 'DateTime', nullable: true, storage: 'date' },
    BILL_DBCD: { type: 'String', nullable: true, maxLength: 3 },
    VCH_SRNO: { type: 'String', nullable: true, maxLength: 5 },
  },
};
