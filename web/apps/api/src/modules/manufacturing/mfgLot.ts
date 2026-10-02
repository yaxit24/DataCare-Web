import { createHash } from 'node:crypto';
import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export type MfgLotKind = 'issue' | 'receive';
export type MfgLotSourceKind = 'stock-material' | 'setting-material-outstanding';
type Row = Record<string, unknown>;
type Scope = VoucherScope & { coYear: string; coBook: string };
type PageQuery = { search?: string; offset?: number | string; limit?: number | string };
const families = { issue: 'MFG STNG ISU', receive: 'MFG STNG REC' } as const;
export class MfgLotValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'MfgLotValidationError';
  }
}
const value = (v: unknown) => String(v ?? '').trim();
const args = (s: Scope) => [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook];
const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5`;
const unavailable =
  'Saved entries and source balances can be reviewed. Creating, changing and reversing lot entries is not available until this installation’s manufacturing rules are verified.';
// JSON numeric values must not pass through IEEE-754 before the browser can display them.
// PostgreSQL serializes business dates/timestamps and exact numeric text; null and blank remain distinct.
function recordSql(alias: string, stockIdentity = false) {
  return `(SELECT jsonb_object_agg(k, CASE WHEN jsonb_typeof(v)='number' THEN to_jsonb(v#>>'{}') ELSE v END)
    FROM jsonb_each(to_jsonb(${alias})-'tenant_id'-'row_id') AS cells(k,v))${stockIdentity ? ` || jsonb_build_object('stockRowId', ${alias}.row_id::text)` : ''}`;
}
function scopeOf(s: VoucherScope): Scope {
  if (![s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook].every((v) => value(v)))
    throw new MfgLotValidationError(
      'Select a company, branch, financial year and configured Setting book.',
    );
  return { ...s, coBook: value(s.coBook), coYear: value(s.coYear) };
}
function pageOf(query: PageQuery) {
  const pageNumber = (input: number | string | undefined, fallback: number) => {
    if (input === undefined) return fallback;
    if (typeof input === 'number') return input;
    return typeof input === 'string' && /^(0|[1-9]\d*)$/.test(input) ? Number(input) : NaN;
  };
  const offset = pageNumber(query.offset, 0),
    limit = pageNumber(query.limit, 50),
    search = value(query.search);
  if (
    !Number.isSafeInteger(offset) ||
    offset < 0 ||
    offset > 100000 ||
    !Number.isSafeInteger(limit) ||
    limit < 1 ||
    limit > 100
  )
    throw new MfgLotValidationError('Invalid lot browse page.');
  if (search.length > 100)
    throw new MfgLotValidationError('Search must be at most 100 characters.');
  return { offset, limit, pattern: `%${search.replace(/[\\%_]/g, '\\$&')}%` };
}

/** Current names are display metadata, never replacements for the imported business snapshot. */
async function displayLabelsTx(tx: any, scope: Scope, records: Row[]) {
  const codes = (keys: string[]) => [
    ...new Set(records.flatMap((row) => keys.map((key) => value(row[key]))).filter(Boolean)),
  ];
  const accountCodes = codes([
    'AC_CODE',
    'KR_CODE',
    'KR_AC_CODE',
    'REP_AC_CODE',
    'ORD_AC_CODE',
    'IR_AC',
    'BANK_AC',
    'CARD_AC',
    'ITM_LOT_AC_CODE',
    'account',
    'karigar',
    'sourceAccount',
  ]);
  const itemCodes = codes([
    'IT_CODE',
    'ISU_IT_CODE',
    'MTRL_IT_CODE',
    'CHOL_IT_CODE',
    'FTNG_IT_CODE',
    'itemCode',
    'receivedItemCode',
  ]);
  const accountRows: Row[] = accountCodes.length
    ? await tx.$queryRawUnsafe(
        `SELECT "AC_CODE","AC_NAME","LC_CODE" FROM "AC_MAST"
    WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=ANY($4::text[])
      AND ("LC_CODE"=$3 OR COALESCE(TRIM("LC_CODE"),'')='')`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        accountCodes,
      )
    : [];
  const accounts = Object.fromEntries(
    accountCodes.map((code) => {
      const rows = accountRows.filter((row) => value(row.AC_CODE) === code);
      const exact = rows.filter((row) => value(row.LC_CODE) === scope.lcCode);
      const names = [
        ...new Set(
          (exact.length ? exact : rows).map((row) =>
            row.AC_NAME == null ? null : String(row.AC_NAME),
          ),
        ),
      ];
      // Conflicting current names remain unnamed instead of selecting an arbitrary branch/row.
      return [code, names.length === 1 ? names[0] : null];
    }),
  );
  const items: Row[] = itemCodes.length
    ? await tx.$queryRawUnsafe(
        `SELECT "IT_CODE","IT_NAME" FROM "ITEM_MAST"
    WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=ANY($3::text[])`,
        scope.tenantId,
        scope.coCode,
        itemCodes,
      )
    : [];
  return {
    accounts,
    items: Object.fromEntries(
      itemCodes.map((code) => {
        const names = [
          ...new Set(
            items
              .filter((row) => value(row.IT_CODE) === code)
              .map((row) => (row.IT_NAME == null ? null : String(row.IT_NAME))),
          ),
        ];
        return [code, names.length === 1 ? names[0] : null];
      }),
    ),
  };
}
async function bookTx(tx: any, s: Scope, kind: MfgLotKind): Promise<Row> {
  if (kind !== 'issue' && kind !== 'receive')
    throw new MfgLotValidationError('Unknown lot manufacturing operation.');
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME"
    FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
    s.tenantId,
    s.coCode,
    s.lcCode,
    s.coBook,
  );
  const b = rows[0];
  if (
    rows.length !== 1 ||
    !b ||
    value(b.MAIN_BOOK).toUpperCase() !== families[kind] ||
    value(b.CUR_USE).toUpperCase() === 'N' ||
    (value(b.BOOK_TBL_NAME) && value(b.BOOK_TBL_NAME) !== 'MFG_DATA')
  )
    throw new MfgLotValidationError(
      `Select an active ${kind === 'issue' ? 'Setting issue' : 'Setting receipt'} book.`,
    );
  return b;
}
async function settingsTx(tx: any, s: Scope, kind: MfgLotKind) {
  const book = await bookTx(tx, s, kind);
  const stages: Row[] = await tx.$queryRawUnsafe(
    `SELECT "SM_MAIN_CODE","SM_CODE","ENTRY_TYPE","NEXT_TRAN","LAST_TRAN","STK_ISU","STK_REC","IN_OUT","CUR_IN_USE"
    FROM "MFG_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 ORDER BY "SM_MAIN_CODE"`,
    s.tenantId,
    s.coCode,
    s.coBook,
  );
  const stage = stages.length === 1 ? stages[0]! : null;
  let sourceUnavailableReason: string | null = null;
  if (!stage)
    sourceUnavailableReason =
      'The selected book needs one unambiguous manufacturing stage before source balances can be selected.';
  else if (value(stage.CUR_IN_USE).toUpperCase() === 'N')
    sourceUnavailableReason = 'The selected manufacturing stage is inactive.';
  else if (
    !['I', 'O'].includes(value(book.BOOK_INOUT)) ||
    (value(stage.IN_OUT) && value(stage.IN_OUT) !== value(book.BOOK_INOUT))
  )
    sourceUnavailableReason =
      'The selected book and manufacturing stage have an unresolved movement direction.';
  else if (
    value(stage.ENTRY_TYPE) !== 'S' ||
    (kind === 'receive' && value(stage.LAST_TRAN) !== 'S')
  )
    sourceUnavailableReason =
      'Source selection is available only for the verified Setting material selector profile.';
  const sourceBooks: Row[] =
    kind === 'receive' && !sourceUnavailableReason
      ? await tx.$queryRawUnsafe(
          `SELECT b."CO_BOOK",b."BOOK_NAME",b."BOOK_INOUT"
    FROM "BOOK_DATA" b JOIN "MFG_MAST" m ON m.tenant_id=b.tenant_id AND m."CO_CODE"=b."CO_CODE" AND m."CO_BOOK"=b."CO_BOOK"
    WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3 AND b."MAIN_BOOK"='MFG STNG ISU'
      AND COALESCE(b."CUR_USE",'Y')<>'N' AND COALESCE(m."CUR_IN_USE",'Y')<>'N' AND m."ENTRY_TYPE"=$4
    GROUP BY b."CO_BOOK",b."BOOK_NAME",b."BOOK_INOUT" HAVING COUNT(*)=1 ORDER BY b."CO_BOOK"`,
          s.tenantId,
          s.coCode,
          s.lcCode,
          value(stage?.LAST_TRAN),
        )
      : [];
  return {
    book,
    stage,
    stages,
    savedBrowse: true,
    sourceKind: kind === 'issue' ? 'stock-material' : 'setting-material-outstanding',
    sourceBooks,
    sourceSelection: !sourceUnavailableReason,
    sourceUnavailableReason,
    writes: false,
    unavailableReason: unavailable,
    effectiveMode: {
      status: 'unverified',
      message:
        'The installation’s lot, order, one-form and ledger mode has not been established from imported desktop configuration.',
    },
  };
}
export async function getMfgLotSettings(prisma: any, rawScope: VoucherScope, kind: MfgLotKind) {
  const s = scopeOf(rawScope);
  return withTxBudget(prisma, s.tenantId, SNAPSHOT_READ, (tx: any) => settingsTx(tx, s, kind));
}
export async function listMfgLots(
  prisma: any,
  rawScope: VoucherScope,
  kind: MfgLotKind,
  query: PageQuery = {},
) {
  const s = scopeOf(rawScope),
    p = pageOf(query);
  return withTxBudget(prisma, s.tenantId, SNAPSHOT_READ, async (tx: any) => {
    const book = await bookTx(tx, s, kind);
    const rows: { data: Row }[] = await tx.$queryRawUnsafe(
      `SELECT ${recordSql('a')} AS data FROM "MFG_DATA" a WHERE ${where}
      AND ($6='%%' OR "VCH_NO" ILIKE $6 OR "BILL_NO" ILIKE $6 OR "AC_CODE" ILIKE $6 OR "VCH_DESC" ILIKE $6)
      ORDER BY "VCH_DATE" DESC NULLS LAST,"VCH_NO" DESC LIMIT $7 OFFSET $8`,
      ...args(s),
      p.pattern,
      p.limit + 1,
      p.offset,
    );
    const pageRows = rows.slice(0, p.limit).map((r) => r.data);
    return {
      book,
      rows: pageRows,
      displayLabels: await displayLabelsTx(tx, s, pageRows),
      hasMore: rows.length > p.limit,
      limit: p.limit,
      offset: p.offset,
    };
  });
}
export async function getMfgLot(
  prisma: any,
  rawScope: VoucherScope,
  kind: MfgLotKind,
  voucherNo: unknown,
) {
  const s = scopeOf(rawScope);
  const rawNo = String(voucherNo ?? '');
  const suppliedNo = rawNo.trim();
  if (!suppliedNo || Array.from(suppliedNo).length > 8 || /[\u0000-\u001f\u007f]/.test(rawNo))
    throw new MfgLotValidationError(
      'Enter a saved voucher reference of at most 8 characters without control characters.',
    );
  return withTxBudget(prisma, s.tenantId, SNAPSHOT_READ, async (tx: any) => {
    const settings = await settingsTx(tx, s, kind);
    let vchNo = suppliedNo;
    const read = async (
      table: 'MFG_DATA' | 'MFG_DETL' | 'MFG_IDTL' | 'MFG_ISU_REC' | 'MAIN_STOCK',
      order: string,
    ): Promise<Row[]> => {
      const rows: { data: Row }[] = await tx.$queryRawUnsafe(
        `SELECT ${recordSql('a', table === 'MAIN_STOCK')} AS data FROM "${table}" a WHERE ${where} AND "VCH_NO"=$6 ORDER BY ${order}${table === 'MAIN_STOCK' ? ',row_id' : ''}`,
        ...args(s),
        vchNo,
      );
      return rows.map((r) => r.data);
    };
    let headers = await read('MFG_DATA', '"VCH_NO"');
    // MFG_DATA stores up to eight characters; desktop Format00000 is a minimum display
    // width, not a five-digit maximum. Exact imported keys win over numeric convenience.
    if (!headers.length && /^\d{1,4}$/.test(suppliedNo)) {
      vchNo = suppliedNo.padStart(5, '0');
      headers = await read('MFG_DATA', '"VCH_NO"');
    }
    if (!headers.length) return null;
    if (headers.length !== 1)
      throw new MfgLotValidationError('The saved lot voucher identity is ambiguous.');
    const lines = await read('MFG_DETL', '"SR_NO"'),
      components = await read('MFG_IDTL', '"SR_NO","ISR_NO"');
    const ids = new Set<string>();
    for (const line of lines) {
      const id = value(line.SR_NO);
      if (!id || ids.has(id))
        throw new MfgLotValidationError('A saved lot parent identity is missing or duplicated.');
      ids.add(id);
    }
    const childIds = new Set<string>();
    for (const child of components) {
      const id = JSON.stringify([child.SR_NO, child.ISR_NO]);
      if (child.ISR_NO == null || !ids.has(value(child.SR_NO)) || childIds.has(id))
        throw new MfgLotValidationError(
          'A saved lot component is duplicated or has no exact parent row.',
        );
      childIds.add(id);
    }
    const movements = await read('MFG_ISU_REC', '"SR_NO","ISR_NO"'),
      stock = await read('MAIN_STOCK', '"SR_NO","ISR_NO"');
    const snapshot = { header: headers[0]!, lines, components, movements, stock };
    const version = createHash('sha256').update(JSON.stringify(snapshot)).digest('hex');
    return {
      scope: { coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear, coBook: s.coBook, vchNo },
      settings,
      ...snapshot,
      version,
      displayLabels: await displayLabelsTx(tx, s, [
        headers[0]!,
        ...lines,
        ...components,
        ...movements,
        ...stock,
      ]),
    };
  });
}

/** Read-only source inspection. No balance from this endpoint grants a write/allocation. */
export async function listMfgLotSources(
  prisma: any,
  rawScope: VoucherScope,
  kind: MfgLotKind,
  query: {
    sourceKind?: string;
    sourceBook?: string;
    acCode?: string;
    search?: string;
    offset?: number | string;
    limit?: number | string;
  } = {},
) {
  const s = scopeOf(rawScope),
    p = pageOf(query);
  return withTxBudget(prisma, s.tenantId, SNAPSHOT_READ, async (tx: any) => {
    const settings = await settingsTx(tx, s, kind);
    if (!settings.sourceSelection)
      throw new MfgLotValidationError(settings.sourceUnavailableReason!);
    if (query.sourceKind && query.sourceKind !== settings.sourceKind)
      throw new MfgLotValidationError(
        'The source kind does not belong to the selected Setting workflow.',
      );
    let rows: Row[];
    if (kind === 'issue') {
      // TR_MFG_WITH_LOT.ItemLotIsu:5141 canonical typed-lot balance. Do not split a negative
      // movement away from its material lot merely because its purchase metadata is different.
      rows = await tx.$queryRawUnsafe(
        `SELECT a."ITM_LOT" AS "materialLot",a."IT_CODE" AS "itemCode",MIN(a."VCH_DATE")::text AS "sourceDate",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_GWT" ELSE 0 END)::text AS "originalWeight",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN 0 ELSE a."ITM_GWT" END)::text AS "accountedWeight",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_GWT" ELSE -a."ITM_GWT" END)::text AS "remainingWeight",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_NWT" ELSE -a."ITM_NWT" END)::text AS "remainingNetWeight",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_PCS" ELSE -a."ITM_PCS" END)::text AS "remainingPieces",
        jsonb_agg(${recordSql('a', true)} ORDER BY a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."SR_NO",a."ISR_NO",a.row_id) AS contributors
        FROM "MAIN_STOCK" a WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
          AND NULLIF(TRIM(a."ITM_LOT"),'') IS NOT NULL AND a."TAG_NO"='N'
          AND ($4='%%' OR a."ITM_LOT" ILIKE $4 OR a."IT_CODE" ILIKE $4)
        GROUP BY a."ITM_LOT",a."IT_CODE"
        HAVING SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_GWT" ELSE -a."ITM_GWT" END)>0
        ORDER BY a."ITM_LOT",a."IT_CODE" LIMIT $5 OFFSET $6`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        p.pattern,
        p.limit + 1,
        p.offset,
      );
    } else {
      const account = value(query.acCode),
        sourceBook = value(query.sourceBook);
      if (!account || account.length > 8)
        throw new MfgLotValidationError(
          'Select a karigar account to inspect Setting receipt sources.',
        );
      if (!settings.sourceBooks.some((b) => value(b.CO_BOOK) === sourceBook))
        throw new MfgLotValidationError('Select an eligible configured Setting issue source book.');
      const sourceSettings = await settingsTx(tx, { ...s, coBook: sourceBook }, 'issue');
      if (!sourceSettings.sourceSelection)
        throw new MfgLotValidationError(
          'The selected issue source book has an unresolved manufacturing stage.',
        );
      // TR_MFG_WITH_LOT.Setting_Rec_ItmLot:5047. Availability is pieces, unlike the separate
      // tag/work-lot accountable-weight selector. Every source dimension is explicit here.
      rows = await tx.$queryRawUnsafe(
        `SELECT a."ITM_LOT" AS "materialLot",a."IT_CODE" AS "itemCode",c."ISU_IT_CODE" AS "receivedItemCode",
        a."IR_LC" AS "sourceBranch",a."IR_YRCD" AS "sourceYear",a."IR_DBCD" AS "sourceBook",a."IR_NO" AS "sourceVoucher",
        a."IR_SRNO"::text AS "sourceOldSrNo",a."IR_AC" AS "sourceAccount",a."IR_TYPE" AS process,a."AC_CODE" AS account,a."KR_AC_CODE" AS karigar,
        (MIN(a."VCH_DATE") FILTER (WHERE a."ITM_SIGN"='-'))::text AS "sourceDate",
        SUM(CASE WHEN a."ITM_SIGN"='-' THEN a."ITM_GWT" ELSE 0 END)::text AS "originalWeight",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_GWT" ELSE 0 END)::text AS "accountedWeight",
        SUM(CASE WHEN a."ITM_SIGN"='-' THEN a."IR_PCS" ELSE 0 END)::text AS "originalPieces",
        SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."IR_PCS" ELSE 0 END)::text AS "accountedPieces",
        (SUM(CASE WHEN a."ITM_SIGN"='-' THEN a."IR_PCS" ELSE 0 END)-SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."IR_PCS" ELSE 0 END))::text AS "remainingPieces",
        (SUM(CASE WHEN a."ITM_SIGN"='-' THEN a."ITM_GWT" ELSE 0 END)-SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_GWT" ELSE 0 END))::text AS "remainingWeight",
        (SUM(CASE WHEN a."ITM_SIGN"='-' THEN a."ITM_NWT" ELSE 0 END)-SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."ITM_NWT" ELSE 0 END))::text AS "remainingNetWeight",
        jsonb_agg(${recordSql('a')} ORDER BY a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."SR_NO",a."ISR_NO") AS contributors
        FROM "MFG_ISU_REC" a JOIN "MFG_DETL" c ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE" AND c."LC_CODE"=a."LC_CODE"
          AND c."CO_YEAR"=a."CO_YEAR" AND c."CO_BOOK"=a."CO_BOOK" AND c."VCH_NO"=a."VCH_NO" AND c."SR_NO"=a."SR_NO"
        JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."AC_CODE"=$4 AND a."KR_AC_CODE"=$4
          AND a."IR_TYPE"=$5 AND a."IR_DBCD"=$6 AND a."IR_LC"=$3 AND b."MAIN_BOOK" IN ('MFG STNG ISU','MFG STNG REC')
          AND NULLIF(TRIM(a."ITM_LOT"),'') IS NOT NULL AND ($7='%%' OR a."ITM_LOT" ILIKE $7 OR a."IT_CODE" ILIKE $7 OR a."IR_NO" ILIKE $7)
        GROUP BY a."ITM_LOT",a."IT_CODE",c."ISU_IT_CODE",a."IR_LC",a."IR_YRCD",a."IR_DBCD",a."IR_NO",a."IR_SRNO",a."IR_AC",a."IR_TYPE",a."AC_CODE",a."KR_AC_CODE"
        HAVING SUM(CASE WHEN a."ITM_SIGN"='-' THEN a."IR_PCS" ELSE 0 END)-SUM(CASE WHEN a."ITM_SIGN"='+' THEN a."IR_PCS" ELSE 0 END)>0
        ORDER BY a."ITM_LOT",a."IR_YRCD",a."IR_DBCD",a."IR_NO",a."IR_SRNO",a."IT_CODE",c."ISU_IT_CODE",a."IR_AC"
        LIMIT $8 OFFSET $9`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        account,
        value(settings.stage?.LAST_TRAN),
        sourceBook,
        p.pattern,
        p.limit + 1,
        p.offset,
      );
    }
    const sources = rows.slice(0, p.limit).map((row) => {
      const identity =
        kind === 'issue'
          ? {
              kind: settings.sourceKind,
              coCode: s.coCode,
              lcCode: s.lcCode,
              materialLot: row.materialLot,
              itemCode: row.itemCode,
            }
          : {
              kind: settings.sourceKind,
              coCode: s.coCode,
              lcCode: s.lcCode,
              sourceBranch: row.sourceBranch,
              sourceYear: row.sourceYear,
              sourceBook: row.sourceBook,
              sourceVoucher: row.sourceVoucher,
              sourceOldSrNo: row.sourceOldSrNo,
              sourceAccount: row.sourceAccount,
              materialLot: row.materialLot,
              itemCode: row.itemCode,
              receivedItemCode: row.receivedItemCode,
              process: row.process,
              account: row.account,
              karigar: row.karigar,
            };
      return {
        ...row,
        kind: settings.sourceKind,
        identity,
        key: createHash('sha256').update(JSON.stringify(identity)).digest('hex'),
        availabilityBasis: kind === 'issue' ? 'gross-weight' : 'pieces',
        advisory: true,
      };
    });
    return {
      settings,
      rows: sources,
      displayLabels: await displayLabelsTx(
        tx,
        s,
        rows
          .slice(0, p.limit)
          .flatMap((row) => [
            row,
            ...(Array.isArray(row.contributors) ? (row.contributors as Row[]) : []),
          ]),
      ),
      hasMore: rows.length > p.limit,
      offset: p.offset,
      limit: p.limit,
    };
  });
}
