import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import type { SavedSaleReturnRaw, SavedSaleReturnScope } from './savedSaleReturn.js';

type Raw = SavedSaleReturnRaw;
export type SaleReturnSourceScope = {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  voucherNo: string;
};
export type SaleReturnSourceAvailability = {
  status: 'available' | 'returned' | 'ambiguous' | 'unsupported';
  reason: string | null;
};
type Display = { customer: string; date: string; bookName: string; billAmount: string | null };
export type SaleReturnSourceListQuery = {
  sourceYear?: string;
  sourceBook?: string;
  search?: string;
  offset?: number | string;
  limit?: number | string;
};
export type SaleReturnSourceItemsQuery = {
  sourceYear: string;
  sourceBook: string;
  sourceVchNo: string;
};
export type SaleReturnSourceComponentIdentity = {
  recordId: string;
  srNo: string | null;
  isrNo: string | null;
  vchSrno: string | null;
  tagNo: string | null;
  itCode: string | null;
};
export type SaleReturnSourceComponent = {
  identity: SaleReturnSourceComponentIdentity;
  raw: Raw;
};
export type SaleReturnSourceRef = SaleReturnSourceScope & {
  recordId: string;
  version: string;
  srNo: string | null;
  oldSrNo: string | null;
  vchSrno: string | null;
  tagSrNo: string | null;
  itCode: string | null;
  tagNo: string | null;
};
export type SaleReturnSourceList = {
  scope: SavedSaleReturnScope;
  rows: Array<{
    source: SaleReturnSourceScope;
    raw: Raw;
    display: Display;
    availability: SaleReturnSourceAvailability;
  }>;
  offset: number;
  limit: number;
  hasMore: boolean;
};
export type SaleReturnSourceItems = {
  scope: SavedSaleReturnScope;
  source: SaleReturnSourceScope;
  version: string;
  header: { raw: Raw; display: Display };
  lines: Array<{
    sourceRef: SaleReturnSourceRef;
    raw: Raw;
    display: { itemName: string | null; itemNameReason: string | null };
    components: SaleReturnSourceComponent[];
    availability: SaleReturnSourceAvailability;
    canSelect: boolean;
  }>;
  unresolvedComponents: Array<SaleReturnSourceComponent & { reason: string }>;
  linkedReturns: Array<{
    source: SaleReturnSourceScope;
    headerRaw: Raw;
    linesRaw: Raw[];
  }>;
  capabilities: { canApplyIncoming: false; reason: string };
};
export class SaleReturnSourceError extends Error {
  constructor(
    public readonly statusCode: 400 | 404 | 422,
    public readonly code: string,
    message: string,
  ) {
    super(message);
    this.name = 'SaleReturnSourceError';
  }
}
type Observed = { raw: Raw; revision: string; locator: string; physicalId: string | null };
type Table =
  'SL_DATA' | 'SL_DETL' | 'SL_IDTL' | 'SL_DETL_RTN' | 'ITEM_MAST' | 'BOOK_DATA' | 'YEAR_MAST';
const fail = (status: 400 | 404 | 422, code: string, message: string): never => {
  throw new SaleReturnSourceError(status, code, message);
};
const invalid = (message: string): never => fail(400, 'invalid-input', message);
const text = (value: string | null | undefined) => value?.trim() ?? '';
const canonical = (value: unknown): string => {
  if (Array.isArray(value)) return `[${value.map(canonical).join(',')}]`;
  if (value && typeof value === 'object')
    return `{${Object.entries(value)
      .sort(([a], [b]) => a.localeCompare(b))
      .map(([k, v]) => `${JSON.stringify(k)}:${canonical(v)}`)
      .join(',')}}`;
  return JSON.stringify(value) ?? 'null';
};
const hash = (value: unknown) => createHash('sha256').update(canonical(value)).digest('hex');
const ordered = (rows: Observed[]) => rows.sort((a, b) => canonical(a).localeCompare(canonical(b)));
// SQL text projection precedes JSON deserialization. No numeric/date reconstruction of saved data.
const projection = `(SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)-'tenant_id'-'row_id') e) AS raw,
 t.xmin::text AS revision,t.ctid::text AS locator,to_jsonb(t)->>'row_id' AS "physicalId"`;
async function observe(
  tx: any,
  table: Table,
  where: string,
  values: unknown[],
): Promise<Observed[]> {
  const order =
    table === 'SL_IDTL'
      ? ' ORDER BY t."SR_NO" NULLS LAST,t."ISR_NO" NULLS LAST,t.row_id'
      : table === 'SL_DETL'
        ? ' ORDER BY t."SR_NO" NULLS LAST,t.row_id'
        : table === 'SL_DETL_RTN'
          ? ' ORDER BY t."SR_NO"'
          : '';
  const rows = await tx.$queryRawUnsafe(
    `SELECT ${projection} FROM "${table}" t WHERE ${where}${order}`,
    ...values,
  );
  return order ? rows : ordered(rows);
}
const companyWhere = 't.tenant_id=$1 AND t."CO_CODE"=$2';
const branchWhere = `${companyWhere} AND t."LC_CODE"=$3`;
const sourceWhere = `${branchWhere} AND t."CO_YEAR"=$4 AND t."CO_BOOK"=$5 AND t."VCH_NO"=$6`;
const branchValues = (scope: SavedSaleReturnScope) => [scope.tenantId, scope.coCode, scope.lcCode];
const sourceValues = (scope: SavedSaleReturnScope, source: SaleReturnSourceScope) => [
  ...branchValues(scope),
  source.coYear,
  source.coBook,
  source.voucherNo,
];
function object(value: unknown, allowed: string[], label: string): Record<string, unknown> {
  if (!value || typeof value !== 'object' || Array.isArray(value))
    invalid(`${label} must be an object.`);
  const result = value as Record<string, unknown>;
  if (Object.keys(result).some((key) => !allowed.includes(key)))
    invalid(`${label} contains unsupported fields.`);
  return result;
}
function string(value: unknown, name: string, max: number, optional = false): string | undefined {
  if (optional && value === undefined) return undefined;
  if (
    typeof value !== 'string' ||
    !value ||
    value !== value.trim() ||
    [...value].length > max ||
    /[\u0000-\u001f]/.test(value)
  )
    invalid(`${name} must be explicit text of at most ${max} characters.`);
  return value as string;
}
function validateScope(scope: SavedSaleReturnScope) {
  object(scope, ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'], 'Target scope');
  for (const [key, max] of [
    ['tenantId', 24],
    ['coCode', 2],
    ['lcCode', 2],
    ['coYear', 10],
    ['coBook', 3],
  ] as const)
    string(scope[key], key, max);
}
function pagination(value: unknown, fallback: number, min: number, max: number, name: string) {
  if (value === undefined) return fallback;
  if (
    (typeof value !== 'number' && typeof value !== 'string') ||
    !/^(0|[1-9]\d*)$/.test(String(value))
  )
    invalid(`${name} must be a canonical whole number.`);
  const result = Number(value);
  if (!Number.isSafeInteger(result) || result < min || result > max)
    invalid(`${name} is outside ${min}–${max}.`);
  return result;
}
function bookReason(rows: Observed[], family: string, direction: string): string | null {
  if (rows.length !== 1)
    return rows.length
      ? 'The book configuration is ambiguous.'
      : 'The configured book was not found.';
  const raw = rows[0]!.raw;
  if (text(raw.CUR_USE).toUpperCase() === 'N') return 'The source/target book is inactive.';
  if (text(raw.MAIN_BOOK).toUpperCase() !== family) return `The book must belong to ${family}.`;
  if (text(raw.BOOK_INOUT) && text(raw.BOOK_INOUT).toUpperCase() !== direction)
    return 'The configured book direction is incompatible.';
  if (text(raw.BOOK_TBL_NAME) && text(raw.BOOK_TBL_NAME).toUpperCase() !== 'SL_DATA')
    return 'The configured book table must be SL_DATA.';
  return null;
}
async function config(
  tx: any,
  target: SavedSaleReturnScope,
  sourceYear?: string,
  sourceBook?: string,
) {
  const books = await observe(tx, 'BOOK_DATA', branchWhere, branchValues(target));
  const years = await observe(tx, 'YEAR_MAST', companyWhere, [target.tenantId, target.coCode]);
  if (years.filter((row) => row.raw.CO_YEAR === target.coYear).length !== 1)
    fail(422, 'configuration', 'The selected Return year is missing or ambiguous in YEAR_MAST.');
  const reason = bookReason(
    books.filter((row) => row.raw.CO_BOOK === target.coBook),
    'SALES RETURNE',
    'I',
  );
  if (reason) fail(422, 'configuration', reason);
  if (sourceBook) {
    const sourceReason = bookReason(
      books.filter((row) => row.raw.CO_BOOK === sourceBook),
      'SALES',
      'O',
    );
    if (sourceReason) fail(422, 'configuration', sourceReason);
  }
  if (sourceYear && years.filter((row) => row.raw.CO_YEAR === sourceYear).length !== 1)
    fail(422, 'configuration', 'The original sale year is missing or ambiguous in YEAR_MAST.');
  return { books, years };
}
const sourceScope = (raw: Raw): SaleReturnSourceScope => ({
  coCode: raw.CO_CODE ?? '',
  lcCode: raw.LC_CODE ?? '',
  coYear: raw.CO_YEAR ?? '',
  coBook: raw.CO_BOOK ?? '',
  voucherNo: raw.VCH_NO ?? '',
});
const display = (raw: Raw, books: Observed[]): Display => ({
  customer: raw.AC_NAME ?? raw.AC_CODE ?? '',
  date: raw.VCH_DATE ?? '',
  bookName:
    books.length === 1 ? (books[0]!.raw.BOOK_NAME ?? raw.CO_BOOK ?? '') : (raw.CO_BOOK ?? ''),
  billAmount: raw.TOT_AMT ?? null,
});
type Linked = { header: Observed; lines: Observed[]; referenceReason: string | null };
async function linkedReturns(
  tx: any,
  target: SavedSaleReturnScope,
  source: SaleReturnSourceScope,
): Promise<Linked[]> {
  const headers = await observe(
    tx,
    'SL_DATA',
    `${branchWhere} AND btrim(t."ISU_YRCD")=$4 AND btrim(t."ISU_DBCD")=$5 AND btrim(t."ISU_NO")=$6
    AND (btrim(t."ISU_LC_CODE")=$3 OR btrim(coalesce(t."ISU_LC_CODE",''))='')`,
    sourceValues(target, source),
  );
  const result: Linked[] = [];
  for (const header of headers)
    result.push({
      header,
      referenceReason:
        header.raw.ISU_LC_CODE !== source.lcCode ||
        header.raw.ISU_YRCD !== source.coYear ||
        header.raw.ISU_DBCD !== source.coBook ||
        header.raw.ISU_NO !== source.voucherNo
          ? 'A linked Return original reference is incomplete or noncanonical; inspect the exact saved reference.'
          : null,
      lines: await observe(
        tx,
        'SL_DETL_RTN',
        sourceWhere,
        sourceValues(target, sourceScope(header.raw)),
      ),
    });
  return result;
}
function linkedAmbiguity(links: Linked[]): string | null {
  const referenceReason = links.find((link) => link.referenceReason)?.referenceReason;
  if (referenceReason) return referenceReason;
  const counts = new Map<string, number>();
  for (const link of links) {
    const k = canonical(sourceScope(link.header.raw));
    counts.set(k, (counts.get(k) ?? 0) + 1);
  }
  if ([...counts.values()].some((count) => count !== 1))
    return 'Linked Return headers are ambiguous.';
  if (links.some((link) => !text(link.header.raw.ISU_LC_CODE)))
    return 'A linked Return has no proven original location.';
  if (links.some((link) => !link.lines.length))
    return 'A linked Return has no incoming rows; source availability is unresolved.';
  if (links.some((link) => link.lines.some((line) => !text(line.raw.TAG_NO))))
    return 'A linked Return has a blank/null tag; source availability is unresolved.';
  return null;
}
const availability = (
  status: SaleReturnSourceAvailability['status'],
  reason: string | null = null,
): SaleReturnSourceAvailability => ({ status, reason });
export async function listSaleReturnSourceVouchers(
  prisma: any,
  target: SavedSaleReturnScope,
  query: SaleReturnSourceListQuery = {},
): Promise<SaleReturnSourceList> {
  validateScope(target);
  object(query, ['sourceYear', 'sourceBook', 'search', 'offset', 'limit'], 'Source voucher query');
  const sourceYear = string(query.sourceYear, 'sourceYear', 10, true);
  const sourceBook = string(query.sourceBook, 'sourceBook', 3, true);
  if (
    query.search !== undefined &&
    (typeof query.search !== 'string' ||
      query.search.length > 100 ||
      /[\u0000-\u001f]/.test(query.search))
  )
    invalid('search must be at most100 text characters.');
  const search = query.search ?? '';
  const offset = pagination(query.offset, 0, 0, 100000, 'offset');
  const limit = pagination(query.limit, 25, 1, 100, 'limit');
  return withTenant(
    prisma,
    target.tenantId,
    async (tx: any) => {
      const configured = await config(tx, target, sourceYear, sourceBook);
      const allowedBooks = [
        ...new Set(
          configured.books
            .filter(
              (row) =>
                text(row.raw.MAIN_BOOK).toUpperCase() === 'SALES' &&
                text(row.raw.CUR_USE).toUpperCase() !== 'N',
            )
            .map((row) => row.raw.CO_BOOK)
            .filter((value): value is string => !!value),
        ),
      ];
      const allowedYears = [
        ...new Set(
          configured.years
            .map((row) => row.raw.CO_YEAR)
            .filter((value): value is string => !!value),
        ),
      ];
      const headers: Observed[] = await tx.$queryRawUnsafe(
        `SELECT ${projection} FROM "SL_DATA" t WHERE ${branchWhere}
      AND t."CO_BOOK"=ANY($4::text[]) AND t."CO_YEAR"=ANY($5::text[]) AND ($6::text IS NULL OR t."CO_YEAR"=$6) AND ($7::text IS NULL OR t."CO_BOOK"=$7)
      AND (strpos(lower(coalesce(t."VCH_NO",'')||' '||coalesce(t."BILL_NO",'')||' '||coalesce(t."AC_NAME",'')),lower($8))>0
        OR EXISTS(SELECT 1 FROM "BOOK_DATA" b WHERE b.tenant_id=t.tenant_id AND b."CO_CODE"=t."CO_CODE" AND b."LC_CODE"=t."LC_CODE" AND b."CO_BOOK"=t."CO_BOOK" AND strpos(lower(coalesce(b."BOOK_NAME",'')),lower($8))>0))
      ORDER BY t."VCH_DATE" DESC NULLS LAST,t."VCH_NO" DESC,t."CO_YEAR",t."CO_BOOK",t.row_id LIMIT $9 OFFSET $10`,
        ...branchValues(target),
        allowedBooks,
        allowedYears,
        sourceYear ?? null,
        sourceBook ?? null,
        search,
        limit + 1,
        offset,
      );
      const rows: SaleReturnSourceList['rows'] = [];
      for (const header of headers.slice(0, limit)) {
        const source = sourceScope(header.raw);
        const books = configured.books.filter((row) => row.raw.CO_BOOK === source.coBook);
        const duplicates = await observe(tx, 'SL_DATA', sourceWhere, sourceValues(target, source));
        const sourceParents = await observe(
          tx,
          'SL_DETL',
          sourceWhere,
          sourceValues(target, source),
        );
        const links = await linkedReturns(tx, target, source);
        const reason =
          bookReason(books, 'SALES', 'O') ||
          (configured.years.filter((row) => row.raw.CO_YEAR === source.coYear).length !== 1
            ? 'The original sale year configuration is ambiguous.'
            : null) ||
          (duplicates.length !== 1 ? 'Original sale header identity is ambiguous.' : null) ||
          linkedAmbiguity(links);
        const unsupportedReason =
          Object.values(source).some((value) => !value || value !== value.trim()) ||
          !/^\d{1,8}$/.test(source.voucherNo) ||
          !/[1-9]/.test(source.voucherNo)
            ? 'The original sale has an unsupported saved source key.'
            : !sourceParents.length
              ? 'The original sale has no saved source items.'
              : null;
        rows.push({
          source,
          raw: header.raw,
          display: display(header.raw, books),
          availability: reason
            ? availability('ambiguous', reason)
            : unsupportedReason
              ? availability('unsupported', unsupportedReason)
              : links.length
                ? availability(
                    'returned',
                    'This original sale already has linked Returns; whole-voucher import is unavailable.',
                  )
                : availability('available'),
        });
      }
      return { scope: { ...target }, rows, offset, limit, hasMore: headers.length > limit };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}
const finitePositive = (value: string | null | undefined) =>
  !!value && Number.isFinite(Number(value)) && Number(value) > 0;
const recordId = (target: SavedSaleReturnScope, table: Table, row: Observed) =>
  hash({
    tenantId: target.tenantId,
    table,
    scope: sourceScope(row.raw),
    physicalId: row.physicalId,
  });
function component(target: SavedSaleReturnScope, row: Observed): SaleReturnSourceComponent {
  return {
    identity: {
      recordId: recordId(target, 'SL_IDTL', row),
      srNo: row.raw.SR_NO ?? null,
      isrNo: row.raw.ISR_NO ?? null,
      vchSrno: row.raw.VCH_SRNO ?? null,
      tagNo: row.raw.TAG_NO ?? null,
      itCode: row.raw.IT_CODE ?? null,
    },
    raw: row.raw,
  };
}
const untagged = (value: string | null | undefined) => !text(value) || text(value) === 'N';
function identityMismatch(parent: Raw, child: Raw): string | null {
  if (!finitePositive(child.ISR_NO)) return 'The component serial is missing or nonfinite.';
  if (!(untagged(parent.TAG_NO) && untagged(child.TAG_NO)) && parent.TAG_NO !== child.TAG_NO)
    return 'The component tag conflicts with its OLD_SRNO owner.';
  if (
    child.VCH_SRNO != null &&
    (!Number.isFinite(Number(child.VCH_SRNO)) ||
      (parent.VCH_SRNO != null && child.VCH_SRNO !== parent.VCH_SRNO))
  )
    return 'The component instance conflicts with its OLD_SRNO owner.';
  return null;
}
export async function getSaleReturnSourceItems(
  prisma: any,
  target: SavedSaleReturnScope,
  query: SaleReturnSourceItemsQuery,
): Promise<SaleReturnSourceItems> {
  validateScope(target);
  object(query, ['sourceYear', 'sourceBook', 'sourceVchNo'], 'Source item query');
  const sourceYear = string(query.sourceYear, 'sourceYear', 10)!;
  const sourceBook = string(query.sourceBook, 'sourceBook', 3)!;
  const requested = string(query.sourceVchNo, 'sourceVchNo', 8)!;
  if (!/^\d{1,8}$/.test(requested) || !/[1-9]/.test(requested))
    invalid('sourceVchNo must be a nonzero numeric saved key of1–8 digits.');
  return withTenant(
    prisma,
    target.tenantId,
    async (tx: any) => {
      const configured = await config(tx, target, sourceYear, sourceBook);
      const source: SaleReturnSourceScope = {
        coCode: target.coCode,
        lcCode: target.lcCode,
        coYear: sourceYear,
        coBook: sourceBook,
        voucherNo: requested,
      };
      let headers = await observe(tx, 'SL_DATA', sourceWhere, sourceValues(target, source));
      if (!headers.length && requested.length < 5) {
        source.voucherNo = requested.padStart(5, '0');
        headers = await observe(tx, 'SL_DATA', sourceWhere, sourceValues(target, source));
      }
      if (headers.length !== 1)
        fail(
          headers.length ? 422 : 404,
          headers.length ? 'unsupported-state' : 'not-found',
          headers.length
            ? 'The original sale header identity is ambiguous.'
            : 'Original sale not found in the requested scope.',
        );
      const parents = await observe(tx, 'SL_DETL', sourceWhere, sourceValues(target, source));
      const children = await observe(tx, 'SL_IDTL', sourceWhere, sourceValues(target, source));
      const codes = [...new Set(parents.map((row) => text(row.raw.IT_CODE)).filter(Boolean))];
      const masters = await observe(
        tx,
        'ITEM_MAST',
        `${companyWhere} AND btrim(t."IT_CODE"::text)=ANY($3::text[])`,
        [target.tenantId, target.coCode, codes],
      );
      const links = await linkedReturns(tx, target, source);
      const relevantBooks = configured.books.filter(
        (row) => row.raw.CO_BOOK === target.coBook || row.raw.CO_BOOK === sourceBook,
      );
      const relevantYears = configured.years.filter(
        (row) => row.raw.CO_YEAR === sourceYear || row.raw.CO_YEAR === target.coYear,
      );
      const version = hash({
        format: 'sale-return-original-source-v1',
        target,
        source,
        headers,
        parents,
        children,
        links,
        masters,
        books: relevantBooks,
        years: relevantYears,
      });
      const attached = new Map<string, SaleReturnSourceComponent[]>();
      const unresolvedComponents: SaleReturnSourceItems['unresolvedComponents'] = [];
      for (const child of children) {
        const owners = parents.filter(
          (parent) =>
            finitePositive(parent.raw.OLD_SRNO) && parent.raw.OLD_SRNO === child.raw.SR_NO,
        );
        const duplicates = children.filter(
          (row) => row.raw.SR_NO === child.raw.SR_NO && row.raw.ISR_NO === child.raw.ISR_NO,
        );
        const reason =
          owners.length !== 1
            ? 'The component has no unique source parent OLD_SRNO owner.'
            : duplicates.length !== 1
              ? 'The component SR_NO/ISR_NO identity is duplicated.'
              : identityMismatch(owners[0]!.raw, child.raw);
        const dto = component(target, child);
        if (reason) unresolvedComponents.push({ ...dto, reason });
        else {
          const id = recordId(target, 'SL_DETL', owners[0]!);
          attached.set(id, [...(attached.get(id) ?? []), dto]);
        }
      }
      const priorReason = linkedAmbiguity(links);
      const lines: SaleReturnSourceItems['lines'] = parents.map((row) => {
        const raw = row.raw;
        const id = recordId(target, 'SL_DETL', row);
        const matching = text(raw.IT_CODE)
          ? masters.filter((master) => text(master.raw.IT_CODE) === text(raw.IT_CODE))
          : [];
        const itemNameReason = !text(raw.IT_CODE)
          ? 'The saved source item code is blank.'
          : matching.length === 1
            ? null
            : matching.length
              ? 'The saved item code matches multiple company item masters.'
              : 'The saved item was not found in the company item master.';
        let status: SaleReturnSourceAvailability;
        if (priorReason) status = availability('ambiguous', priorReason);
        else if (unresolvedComponents.length)
          status = availability(
            'ambiguous',
            'Original sale component ownership is unresolved; inspect all saved components.',
          );
        else if (
          parents.filter((parent) => parent.raw.SR_NO === raw.SR_NO).length !== 1 ||
          parents.filter((parent) => parent.raw.OLD_SRNO === raw.OLD_SRNO).length !== 1 ||
          parents.filter((parent) => parent.raw.TAG_NO === raw.TAG_NO).length !== 1
        )
          status = availability(
            'ambiguous',
            'The source parent row, OLD_SRNO or tag does not resolve uniquely.',
          );
        else if (
          !finitePositive(raw.SR_NO) ||
          !finitePositive(raw.OLD_SRNO) ||
          (raw.VCH_SRNO != null && !Number.isFinite(Number(raw.VCH_SRNO)))
        )
          status = availability(
            'unsupported',
            'The saved source parent identity is missing or nonfinite.',
          );
        else if (!text(raw.TAG_NO))
          status = availability(
            'unsupported',
            'Desktop single-item selection requires a nonblank source tag.',
          );
        else if (itemNameReason)
          status = availability(matching.length ? 'ambiguous' : 'unsupported', itemNameReason);
        else if (links.some((link) => link.lines.some((line) => line.raw.TAG_NO === raw.TAG_NO)))
          status = availability('returned', 'This source tag already appears in a linked Return.');
        else status = availability('available');
        return {
          sourceRef: {
            ...source,
            recordId: id,
            version,
            srNo: raw.SR_NO ?? null,
            oldSrNo: raw.OLD_SRNO ?? null,
            vchSrno: raw.VCH_SRNO ?? null,
            tagSrNo: raw.TAG_SRNO ?? null,
            itCode: raw.IT_CODE ?? null,
            tagNo: raw.TAG_NO ?? null,
          },
          raw,
          display: {
            itemName: matching.length === 1 ? (matching[0]!.raw.IT_NAME ?? null) : null,
            itemNameReason,
          },
          components: attached.get(id) ?? [],
          availability: status,
          canSelect: status.status === 'available',
        };
      });
      return {
        scope: { ...target },
        source,
        version,
        header: {
          raw: headers[0]!.raw,
          display: display(
            headers[0]!.raw,
            configured.books.filter((row) => row.raw.CO_BOOK === sourceBook),
          ),
        },
        lines,
        unresolvedComponents,
        linkedReturns: links.map((link) => ({
          source: sourceScope(link.header.raw),
          headerRaw: link.header.raw,
          linesRaw: link.lines.map((row) => row.raw),
        })),
        capabilities: {
          canApplyIncoming: false,
          reason:
            'You can inspect the original sale here. Applying it to a return is not available yet.',
        },
      };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}
