import { toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { assertFiscalDateTx, deleteVoucherWriteSetTx } from '../vouchers/lifecycle.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertVoucherVersionTx,
  requiredVersion,
  versionKeyOf,
  voucherVersionTx,
} from '../vouchers/version.js';
import {
  assertPeriodOpen,
  insertRowTx,
  PeriodLockValidationError,
  postVoucherTx,
} from '../posting/posting.js';
import {
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  num,
  requireBookFamily,
  text,
  voucherKey,
  type VoucherIdentity,
} from '../finance/lifecycle.js';
import {
  detailRow,
  dmRowsTx,
  lineFromRow,
  resolveIssueTagsTx,
  setBarFlagsTx,
  setSourceReceivedTx,
  sourceLinesTx,
  stockRows,
  stoneRows,
  type ApprovalBook,
} from './approvalRows.js';
import {
  APPROVAL_MESSAGES,
  ApprovalNotFoundError,
  approvalBusinessDate,
  approvalRound3,
  completeApprovalScope,
  isApprovalTag,
  normalizeApprovalLines,
  tourLineFine,
  TourValidationError,
  type ApprovalKind,
  type ApprovalRow as Row,
  type CompleteApprovalScope,
  type DeleteTourInput,
  type TourIssueInput,
  type TourIssueLine,
  type TourIssueResult,
  type TourReturnInput,
  type TourReturnResult,
} from './approvalTypes.js';

export * from './approvalTypes.js';

const VERSION_TABLES = [
  'APR_DATA',
  'APR_DETL',
  'APR_IDTL',
  'MAIN_STOCK',
  'DM_DATA',
  'REMARK_DATA',
] as const;
const DELETE_TABLES = [...VERSION_TABLES] as const;

async function approvalBookTx(
  tx: any,
  scope: VoucherScope,
  kind: ApprovalKind,
): Promise<ApprovalBook> {
  const book = await configuredBookTx(tx, scope);
  const expected = kind === 'issue' ? 'APR ISU' : 'APR RTN';
  requireBookFamily(book, expected, `approval-${kind}`);
  const direction = kind === 'issue' ? 'O' : 'I';
  if (book.inout.toUpperCase() !== direction)
    throw new TourValidationError(`approval-${kind} requires a ${direction} book`);
  return book;
}

export async function approvalPrintBook(
  prisma: any,
  scope: VoucherScope,
  kind: ApprovalKind,
): Promise<ApprovalBook> {
  completeApprovalScope(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => approvalBookTx(tx, scope, kind));
}

async function withDesktopLockText<T>(work: () => Promise<T>): Promise<T> {
  try {
    return await work();
  } catch (error) {
    if (error instanceof PeriodLockValidationError)
      error.message = APPROVAL_MESSAGES.lockDate(error.lockDate);
    throw error;
  }
}

async function assertSaveAllowedTx(
  tx: any,
  scope: CompleteApprovalScope,
  options: { creating: boolean; date: Date; iso: string; empCode: string; partyAc: string },
): Promise<void> {
  // BtnSave_Click desktop order, TR_APR_ISU.cs:6015-6064. Licence expiry is not represented by a
  // server-owned web field, so it is not accepted from the request or invented here.
  if (options.creating) {
    const types: Array<{ type: string }> = await tx.$queryRawUnsafe(
      `SELECT DISTINCT upper(btrim(coalesce("CO_TYPE"::text,''))) type FROM "CO_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      scope.tenantId,
      scope.coCode,
    );
    if (types.some((row) => row.type === 'B'))
      throw new TourValidationError(APPROVAL_MESSAGES.COMPANY_TYPE_B);
  }
  try {
    await assertFiscalDateTx(tx, scope, options.iso);
  } catch (error) {
    if (error instanceof Error && /is outside fiscal year/.test(error.message))
      throw new TourValidationError(APPROVAL_MESSAGES.NOT_IN_CURRENT_YEAR);
    throw error;
  }
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: options.date }] },
  });
  const settings: Array<{ mandatory: string }> = await tx.$queryRawUnsafe(
    `SELECT upper(btrim(coalesce("EMP_CODE_MANDATORY"::text,''))) mandatory FROM "CO_SET"
      WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  if (settings.some((row) => row.mandatory === 'Y') && !options.empCode)
    throw new TourValidationError(APPROVAL_MESSAGES.EMPLOYEE_REQUIRED);
  if (!options.partyAc) throw new TourValidationError(APPROVAL_MESSAGES.PARTY_REQUIRED);
  const parties: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    options.partyAc,
  );
  if (!parties.length) throw new TourValidationError(`party not found: ${options.partyAc}`);
  if (options.empCode) {
    const employees: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      options.empCode,
    );
    if (!employees.length) throw new TourValidationError(`employee not found: ${options.empCode}`);
  }
}

async function rebuildRemarkTx(
  tx: any,
  scope: CompleteApprovalScope,
  identity: VoucherIdentity,
  book: ApprovalBook,
  partyAc: string,
  description: string,
): Promise<void> {
  if (!description) return;
  const names: Array<{ AC_NAME: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
      ORDER BY CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END,row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    partyAc,
    scope.lcCode,
  );
  await insertRowTx(tx, 'REMARK_DATA', scope.tenantId, {
    ...voucherKey(scope, identity.voucherNo),
    SR_NO: 0,
    VCH_DATE: identity.voucherDate,
    AC_CODE: partyAc,
    AC_NAME: text(names[0]?.AC_NAME).slice(0, 50) || null,
    MAIN_BOOK: book.mainBook,
    VCH_REMARK: description,
  });
}

async function writeTx(
  tx: any,
  kind: ApprovalKind,
  input: TourIssueInput,
  book: ApprovalBook,
  identity: VoucherIdentity,
  lines: TourIssueLine[],
  source?: { year: string; book: string; no: string },
): Promise<TourIssueResult | TourReturnResult> {
  const scope = completeApprovalScope(input.scope);
  const partyAc = text(input.partyAc ?? input.salesmanAc);
  const empCode = text(input.empCode).slice(0, 3);
  const description = text(input.vchDesc).toUpperCase();
  const key = voucherKey(scope, identity.voucherNo);
  const header = {
    ...key,
    VCH_DATE: identity.voucherDate,
    VCH_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    AC_CODE: partyAc,
    EMP_CODE: empCode || null,
    VCH_DESC: description || null,
    ISU_NO: source?.no ?? null,
    ISU_LC_CODE: scope.lcCode,
    ISU_YRCD: source?.year ?? null,
    ISU_DBCD: source?.book ?? null,
    MAIN_USER: identity.mainUser || null,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
  const details = lines.map((line, index) =>
    detailRow(key, identity, book, partyAc, empCode, line, index, source),
  );
  const stones = stoneRows(key, identity, book, partyAc, lines);
  const stock = stockRows(details, book, kind);
  const diamonds = await dmRowsTx(tx, scope.tenantId, stones, details, book, kind);
  await insertHiddenIdentityTx(tx, scope, identity, book.name);
  await postVoucherTx(tx, scope.tenantId, {
    bookName: book.mainBook,
    ledger: { table: 'AC_DATA', lines: [] },
    writes: [
      { table: 'APR_DATA', rows: [header] },
      { table: 'APR_DETL', rows: details },
      ...(stones.length ? [{ table: 'APR_IDTL', rows: stones }] : []),
      { table: 'MAIN_STOCK', rows: stock },
      ...(diamonds.length ? [{ table: 'DM_DATA', rows: diamonds }] : []),
    ],
  });
  await setBarFlagsTx(tx, scope.tenantId, details, kind);
  if (kind === 'return') await setSourceReceivedTx(tx, scope.tenantId, details, 'Y');
  await rebuildRemarkTx(tx, scope, identity, book, partyAc, description);
  const version = await voucherVersionTx(
    tx,
    VERSION_TABLES,
    versionKeyOf(scope, identity.voucherNo),
  );
  const base = {
    vchNo: identity.vchNo,
    voucherNo: identity.voucherNo,
    fine: approvalRound3(lines.reduce((sum, line) => sum + tourLineFine(line), 0)),
    version,
  };
  return kind === 'return' ? { ...base, closedLines: lines.length } : base;
}

async function rowsTx(tx: any, scope: CompleteApprovalScope, voucherNo: string, lock = false) {
  const header: Row[] = await tx.$queryRawUnsafe(
    `SELECT h.*,to_char(h."VCH_TIME",'HH24:MI:SS.MS') "VCH_CLOCK",
            (SELECT a."AC_NAME" FROM "AC_MAST" a
              WHERE a.tenant_id=h.tenant_id AND a."CO_CODE"=h."CO_CODE" AND a."AC_CODE"=h."AC_CODE"
              ORDER BY CASE WHEN a."LC_CODE"=h."LC_CODE" THEN 0 ELSE 1 END,a.row_id LIMIT 1) "PARTY_NAME",
            (SELECT e."EMP_NAME" FROM "EMP_MAST" e
              WHERE e.tenant_id=h.tenant_id AND e."CO_CODE"=h."CO_CODE" AND e."EMP_CODE"=h."EMP_CODE"
              ORDER BY e.row_id LIMIT 1) "EMP_NAME"
       FROM "APR_DATA" h
      WHERE h.tenant_id=$1 AND h."CO_CODE"=$2 AND h."LC_CODE"=$3 AND h."CO_YEAR"=$4 AND h."CO_BOOK"=$5
        AND h."VCH_NO"=$6 ORDER BY h.row_id${lock ? ' FOR UPDATE OF h' : ''}`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (header.length !== 1) return null;
  // Approval Rtn locks these same source rows in sourceLinesTx. Issue edit/delete must take the
  // row locks before checking ISU_REC or downstream links, otherwise a committing return can be
  // invisible to the check and lose its source. OLD_SRNO order is the desktop-stable line identity.
  const details: Row[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
      AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "OLD_SRNO","SR_NO",row_id${
        lock ? ' FOR UPDATE' : ''
      }`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const stones: Row[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "APR_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
      AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO",row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return { header: header[0]!, details, stones };
}

function viewOf(
  scope: CompleteApprovalScope,
  kind: ApprovalKind,
  book: ApprovalBook,
  voucherNo: string,
  state: NonNullable<Awaited<ReturnType<typeof rowsTx>>>,
  version: string,
) {
  const header = state.header;
  return {
    kind,
    voucherNo,
    book: {
      code: scope.coBook,
      name: book.name,
      shortName: book.shortName,
      mainBook: book.mainBook,
    },
    hiddenVoucherNo: text(header.HD_VCH_NO),
    vchDate: toIsoDate(header.VCH_DATE),
    vchTime: text(header.VCH_CLOCK),
    partyAc: text(header.AC_CODE),
    partyName: text(header.PARTY_NAME),
    empCode: text(header.EMP_CODE),
    empName: text(header.EMP_NAME),
    vchDesc: text(header.VCH_DESC),
    mainUser: text(header.MAIN_USER),
    origVchNo: text(header.ISU_NO),
    origBook: text(header.ISU_DBCD),
    origYear: text(header.ISU_YRCD),
    version,
    lines: state.details.map((row) => {
      const line = lineFromRow({
        ...row,
        stones: state.stones.filter((stone) => num(stone.SR_NO) === num(row.OLD_SRNO ?? row.SR_NO)),
      });
      return kind === 'return' ? { ...line, origSrNo: num(row.ISU_SRNO) } : line;
    }),
  };
}

type ApprovalView = ReturnType<typeof viewOf>;

function sparseStonesWithFallback(
  raw: TourIssueLine['stones'],
  fallback: NonNullable<TourIssueLine['stones']>,
): TourIssueLine['stones'] {
  if (!Array.isArray(raw)) return raw;
  return raw.map((value) => {
    if (!value || typeof value !== 'object' || Array.isArray(value)) return value;
    const isrNo = num(value.isrNo);
    const persisted = isrNo
      ? fallback.find((candidate) => num(candidate.isrNo) === isrNo)
      : undefined;
    return persisted ? { ...persisted, ...value, isrNo: persisted.isrNo } : value;
  });
}

function sparseLinesWithFallback(raw: unknown, fallback: TourIssueLine[]): unknown {
  if (!Array.isArray(raw)) return raw;
  return raw.map((value) => {
    if (!value || typeof value !== 'object' || Array.isArray(value)) return value;
    const line = value as TourIssueLine;
    const oldSrNo = num(line.oldSrNo ?? line.origSrNo);
    if (!oldSrNo) return line;
    const persisted = fallback.find(
      (candidate) => num(candidate.oldSrNo ?? candidate.origSrNo) === oldSrNo,
    );
    if (!persisted) return line;
    return {
      ...persisted,
      ...line,
      stones:
        line.stones === undefined
          ? persisted.stones
          : sparseStonesWithFallback(line.stones, persisted.stones ?? []),
    };
  });
}

function issueLinesWithPersistedLifecycle(lines: TourIssueLine[], details: Row[]): TourIssueLine[] {
  const byOldSrNo = new Map(details.map((row) => [num(row.OLD_SRNO ?? row.SR_NO), row] as const));
  const submitted = new Map(lines.map((line) => [num(line.oldSrNo), line] as const));
  const consumed = (row: Row) => {
    const received = text(row.ISU_REC).toUpperCase();
    return (
      (received !== '' && received !== 'N') ||
      text(row.EMP_SALE).toUpperCase() === 'Y' ||
      text(row.CON_ISU_REC).toUpperCase() === 'Y'
    );
  };
  for (const [oldSrNo, row] of byOldSrNo) {
    if (!consumed(row)) continue;
    const line = submitted.get(oldSrNo);
    const sameIdentity =
      line &&
      text(line.itCode) === text(row.IT_CODE) &&
      text(line.tagNo || 'N') === text(row.TAG_NO || 'N') &&
      num(line.vchSrno) === num(row.VCH_SRNO);
    if (!sameIdentity)
      throw new TourValidationError(
        `approval issue line ${oldSrNo} has already been returned or billed and cannot be removed or retagged`,
      );
  }
  return lines.map((line) => {
    const row = byOldSrNo.get(num(line.oldSrNo));
    if (!row) return line;
    return {
      ...line,
      oldSrNo: num(row.OLD_SRNO ?? row.SR_NO),
      isuRec: text(row.ISU_REC) || 'N',
      empSale: text(row.EMP_SALE) || 'N',
      conIsuRec: text(row.CON_ISU_REC),
      isuNo: text(row.ISU_NO),
      isuYrcd: text(row.ISU_YRCD),
      isuDbcd: text(row.ISU_DBCD),
      isuLcCode: text(row.ISU_LC_CODE),
      isuSrNo: num(row.ISU_SRNO),
    };
  });
}

async function getTx(
  tx: any,
  scope: CompleteApprovalScope,
  kind: ApprovalKind,
  rawNo: number | string,
  lock = false,
) {
  const book = await approvalBookTx(tx, scope, kind);
  const voucherNo = formatVoucherNo(rawNo);
  const state = await rowsTx(tx, scope, voucherNo, lock);
  if (!state) throw new ApprovalNotFoundError(kind, voucherNo);
  const version = await voucherVersionTx(tx, VERSION_TABLES, versionKeyOf(scope, voucherNo));
  return { book, state, view: viewOf(scope, kind, book, voucherNo, state, version) };
}

export async function getApproval(
  prisma: any,
  scopeInput: VoucherScope,
  kind: ApprovalKind,
  vchNo: number | string,
): Promise<ApprovalView> {
  const scope = completeApprovalScope(scopeInput);
  return withTxBudget(
    prisma,
    scope.tenantId,
    'read',
    async (tx: any) => (await getTx(tx, scope, kind, vchNo)).view,
  );
}

function comparable(input: TourIssueInput, fallback: ApprovalView): string {
  const returning = 'origVchNo' in input;
  const rtn = input as Partial<TourReturnInput>;
  return JSON.stringify({
    vchDate: input.vchDate ? toIsoDate(input.vchDate) : fallback.vchDate,
    partyAc: text(input.partyAc ?? input.salesmanAc) || fallback.partyAc,
    empCode: input.empCode === undefined ? fallback.empCode : text(input.empCode),
    vchDesc: input.vchDesc === undefined ? fallback.vchDesc : text(input.vchDesc).toUpperCase(),
    origVchNo: returning && rtn.origVchNo != null ? formatVoucherNo(rtn.origVchNo) : '',
    origBook: returning ? text(rtn.origBook) : '',
    origYear: returning ? text(rtn.origYear) : '',
    lines: normalizeApprovalLines(sparseLinesWithFallback(input.lines, fallback.lines)),
  });
}

function comparableView(view: ApprovalView): string {
  return JSON.stringify({
    vchDate: view.vchDate,
    partyAc: view.partyAc,
    empCode: view.empCode,
    vchDesc: view.vchDesc,
    origVchNo: view.origVchNo,
    origBook: view.origBook,
    origYear: view.origYear,
    lines: normalizeApprovalLines(view.lines),
  });
}

async function assertReturnLinksTx(tx: any, tenantId: string, details: Row[]): Promise<void> {
  for (const row of details) {
    if (
      !text(row.ISU_YRCD) ||
      !text(row.ISU_DBCD) ||
      !text(row.ISU_LC_CODE) ||
      !text(row.ISU_NO) ||
      !num(row.ISU_SRNO)
    )
      throw new TourValidationError(APPROVAL_MESSAGES.LEGACY_RETURN_UNLINKED);
    const sources: Row[] = await tx.$queryRawUnsafe(
      `SELECT "row_id","TAG_NO","VCH_SRNO","IT_CODE" FROM "APR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "OLD_SRNO"::numeric=$7::numeric
          AND coalesce("TAG_NO",'N')=coalesce($8,'N')
          AND coalesce("IT_CODE"::text,'')=coalesce($9::text,'')
          AND coalesce("VCH_SRNO",0)::numeric=$10::numeric
        ORDER BY row_id FOR UPDATE`,
      tenantId,
      row.CO_CODE,
      row.ISU_LC_CODE,
      row.ISU_YRCD,
      row.ISU_DBCD,
      row.ISU_NO,
      num(row.ISU_SRNO),
      text(row.TAG_NO) || 'N',
      text(row.IT_CODE),
      num(row.VCH_SRNO),
    );
    if (sources.length !== 1)
      throw new TourValidationError(APPROVAL_MESSAGES.LEGACY_RETURN_UNLINKED);
    if (!isApprovalTag(row.TAG_NO)) continue;
    const bars: Row[] = await tx.$queryRawUnsafe(
      `SELECT row_id FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric
        AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'') ORDER BY row_id FOR UPDATE`,
      tenantId,
      row.CO_CODE,
      row.LC_CODE,
      row.TAG_NO,
      num(row.VCH_SRNO),
      text(row.IT_CODE),
    );
    if (bars.length !== 1) throw new TourValidationError(APPROVAL_MESSAGES.LEGACY_RETURN_UNLINKED);
  }
}

async function clearEffectsTx(
  tx: any,
  scope: CompleteApprovalScope,
  kind: ApprovalKind,
  state: NonNullable<Awaited<ReturnType<typeof rowsTx>>>,
): Promise<void> {
  const details = state.details;
  if (kind === 'return') {
    await setSourceReceivedTx(tx, scope.tenantId, details, 'N');
    await setBarFlagsTx(tx, scope.tenantId, details, 'issue');
  } else {
    for (const row of details.filter((line) => isApprovalTag(line.TAG_NO))) {
      const affected = await tx.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "APR_ISU"='N' WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        row.TAG_NO,
        num(row.VCH_SRNO),
      );
      if (affected !== 1) throw new TourValidationError(APPROVAL_MESSAGES.LEGACY_RETURN_UNLINKED);
    }
  }
}

async function create(
  prisma: any,
  kind: ApprovalKind,
  input: TourIssueInput | TourReturnInput,
): Promise<TourIssueResult | TourReturnResult> {
  const scope = completeApprovalScope(input.scope);
  const requested = approvalBusinessDate(input.vchDate);
  const partyAc = text(input.partyAc ?? input.salesmanAc);
  const empCode = text(input.empCode).slice(0, 3);
  return withTxBudget(prisma, scope.tenantId, 'voucher', (tx: any) =>
    withDesktopLockText(async () => {
      const book = await approvalBookTx(tx, scope, kind);
      await assertSaveAllowedTx(tx, scope, {
        creating: true,
        date: requested.date,
        iso: requested.iso,
        empCode,
        partyAc,
      });
      let lines: TourIssueLine[];
      let source: { year: string; book: string; no: string } | undefined;
      if (kind === 'issue') {
        lines = await resolveIssueTagsTx(tx, scope, normalizeApprovalLines(input.lines));
      } else {
        const rtn = input as TourReturnInput;
        lines = await sourceLinesTx(tx, scope, rtn, true);
        source = {
          year: text(rtn.origYear) || scope.coYear,
          book: text(rtn.origBook),
          no: formatVoucherNo(rtn.origVchNo),
        };
      }
      const identity = await createIdentityTx(tx, scope, requested.date, input.mainUser);
      return writeTx(tx, kind, input, book, identity, lines, source);
    }),
  );
}

async function edit(
  prisma: any,
  kind: ApprovalKind,
  input: TourIssueInput | TourReturnInput,
  rawNo: number | string,
): Promise<TourIssueResult | TourReturnResult> {
  const scope = completeApprovalScope(input.scope);
  const voucherNo = formatVoucherNo(rawNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', (tx: any) =>
    withDesktopLockText(async () => {
      const current = await getTx(tx, scope, kind, voucherNo, true);
      await assertVoucherVersionTx(
        tx,
        VERSION_TABLES,
        versionKeyOf(scope, voucherNo),
        requiredVersion(input.expectedVersion),
      );
      if (comparable(input, current.view) === comparableView(current.view)) {
        const fine = approvalRound3(
          current.view.lines.reduce((sum, line) => sum + tourLineFine(line), 0),
        );
        const base = {
          vchNo: Number(voucherNo),
          voucherNo,
          fine,
          version: current.view.version,
        };
        return kind === 'return' ? { ...base, closedLines: current.view.lines.length } : base;
      }
      if (kind === 'return') await assertReturnLinksTx(tx, scope.tenantId, current.state.details);
      const requested = approvalBusinessDate(input.vchDate || current.view.vchDate);
      const partyAc = text(input.partyAc ?? input.salesmanAc) || current.view.partyAc;
      const empCode = input.empCode === undefined ? current.view.empCode : text(input.empCode);
      await assertSaveAllowedTx(tx, scope, {
        creating: false,
        date: requested.date,
        iso: requested.iso,
        empCode,
        partyAc,
      });
      const { identity } = await editIdentityTx(tx, {
        table: 'APR_DATA',
        scope,
        requestedVoucherNo: voucherNo,
        requestedDate: requested.date,
      });
      const mergedInput = {
        ...input,
        scope,
        partyAc,
        empCode,
        vchDate: requested.iso,
        vchDesc:
          input.vchDesc === undefined ? current.view.vchDesc : text(input.vchDesc).toUpperCase(),
      };
      let lines = normalizeApprovalLines(sparseLinesWithFallback(input.lines, current.view.lines));
      if (kind === 'issue') lines = issueLinesWithPersistedLifecycle(lines, current.state.details);
      await clearEffectsTx(tx, scope, kind, current.state);
      await deleteVoucherWriteSetTx(tx, {
        tables: DELETE_TABLES,
        key: { scope, voucherNo },
        tempBook: { voucherNo: identity.hiddenVoucherNo },
      });
      let source: { year: string; book: string; no: string } | undefined;
      if (kind === 'issue') lines = await resolveIssueTagsTx(tx, scope, lines);
      else {
        const rtn = mergedInput as TourReturnInput;
        lines = await sourceLinesTx(tx, scope, rtn, true);
        source = {
          year: text(rtn.origYear) || current.view.origYear,
          book: text(rtn.origBook) || current.view.origBook,
          no: formatVoucherNo(rtn.origVchNo || current.view.origVchNo),
        };
      }
      return writeTx(tx, kind, mergedInput, current.book, identity, lines, source);
    }),
  );
}

export const tourIssue = (prisma: any, input: TourIssueInput): Promise<TourIssueResult> =>
  create(prisma, 'issue', input) as Promise<TourIssueResult>;
export const editTour = (
  prisma: any,
  input: TourIssueInput,
  vchNo: number | string,
): Promise<TourIssueResult> => edit(prisma, 'issue', input, vchNo) as Promise<TourIssueResult>;
export const tourReturn = (prisma: any, input: TourReturnInput): Promise<TourReturnResult> =>
  create(prisma, 'return', input) as Promise<TourReturnResult>;
export const editTourReturn = (
  prisma: any,
  input: TourReturnInput,
  vchNo: number | string,
): Promise<TourReturnResult> => edit(prisma, 'return', input, vchNo) as Promise<TourReturnResult>;

async function assertIssueDeleteAllowedTx(
  tx: any,
  scope: CompleteApprovalScope,
  voucherNo: string,
): Promise<void> {
  const returns: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "APR_DETL" rtn
      JOIN "BOOK_DATA" book ON book.tenant_id=rtn.tenant_id AND book."CO_CODE"=rtn."CO_CODE"
       AND book."LC_CODE"=rtn."LC_CODE" AND book."CO_BOOK"=rtn."CO_BOOK"
     WHERE rtn.tenant_id=$1 AND rtn."CO_CODE"=$2 AND rtn."ISU_NO"=$6
       AND upper(btrim(book."MAIN_BOOK"))='APR RTN'
       AND ((rtn."ISU_YRCD"=$4 AND rtn."ISU_DBCD"=$5 AND rtn."ISU_LC_CODE"=$3)
         OR ((rtn."ISU_YRCD" IS NULL OR btrim(rtn."ISU_YRCD")=''
              OR rtn."ISU_DBCD" IS NULL OR btrim(rtn."ISU_DBCD")=''
              OR rtn."ISU_LC_CODE" IS NULL OR btrim(rtn."ISU_LC_CODE")='')
             AND rtn."CO_YEAR"=$4 AND rtn."LC_CODE"=$3))
     LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (returns.length) throw new TourValidationError(APPROVAL_MESSAGES.DELETE_RETURNED);
  const retailSales: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND "ISU_YRCD"=$4 AND "ISU_DBCD"=$5 AND "ISU_NO"=$6 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (retailSales.length) throw new TourValidationError(APPROVAL_MESSAGES.DELETE_SALE);
  const sales: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND "ISU_YRCD"=$4 AND "ISU_DBCD"=$5 AND "ISU_NO"=$6 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (sales.length) throw new TourValidationError(APPROVAL_MESSAGES.DELETE_WHOLESALE);
}

async function remove(
  prisma: any,
  kind: ApprovalKind,
  input: DeleteTourInput,
): Promise<{ reversed: true }> {
  const scope = completeApprovalScope(input.scope);
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', (tx: any) =>
    withDesktopLockText(async () => {
      const current = await getTx(tx, scope, kind, voucherNo, true);
      if (kind === 'return') await assertReturnLinksTx(tx, scope.tenantId, current.state.details);
      const { persisted, identity } = await editIdentityTx(tx, {
        table: 'APR_DATA',
        scope,
        requestedVoucherNo: voucherNo,
        requestedDate: new Date(),
        checkRequestedDate: false,
      });
      if (kind === 'issue') await assertIssueDeleteAllowedTx(tx, scope, voucherNo);
      await assertVoucherVersionTx(
        tx,
        VERSION_TABLES,
        versionKeyOf(scope, voucherNo),
        requiredVersion(input.expectedVersion),
      );
      await clearEffectsTx(tx, scope, kind, current.state);
      await deleteVoucherWriteSetTx(tx, {
        tables: DELETE_TABLES,
        key: { scope, voucherNo },
        tempBook: { voucherNo: identity.hiddenVoucherNo },
      });
      await insertDesktopDeleteAuditTx(tx, {
        scope,
        configuredBook: current.book,
        header: persisted,
        rows: current.state.details.map((row) => ({
          srNo: num(row.SR_NO),
          fineType: text(row.IT_TYPE) || 'A',
          // TR_APR_ISU.cs:6648 puts ITM_NWT in VCH_FINE_CR despite that column's name.
          fineCr: num(row.ITM_NWT),
          acCode: row.AC_CODE,
          acName: current.state.header.PARTY_NAME,
          description: `ItCode / ${text(row.IT_CODE)}   TagNo / ${text(row.TAG_NO)}`,
        })),
        deleteUser: input.deleteUser,
      });
      return { reversed: true as const };
    }),
  );
}

export const deleteTour = (prisma: any, input: DeleteTourInput) => remove(prisma, 'issue', input);
export const deleteTourReturn = (prisma: any, input: DeleteTourInput) =>
  remove(prisma, 'return', input);

export async function tourLines(prisma: any, scopeInput: VoucherScope, vchNo: number | string) {
  const scope = completeApprovalScope(scopeInput);
  const voucherNo = formatVoucherNo(vchNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await approvalBookTx(tx, scope, 'issue');
    const rows: Row[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","OLD_SRNO","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT",
              "ITM_TOUCH","ITM_RATE","DESIGN_NO","ISU_REC"
         FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    return rows.map((line) => ({
      srNo: num(line.OLD_SRNO ?? line.SR_NO),
      itCode: text(line.IT_CODE),
      tagNo: isApprovalTag(line.TAG_NO) ? text(line.TAG_NO) : null,
      vchSrno: num(line.VCH_SRNO),
      pcs: num(line.ITM_PCS),
      grossWt: num(line.ITM_GWT),
      netWt: num(line.ITM_NWT),
      touch: num(line.ITM_TOUCH),
      rate: num(line.ITM_RATE),
      designNo: text(line.DESIGN_NO) || null,
      open: text(line.ISU_REC).toUpperCase() !== 'Y',
    }));
  });
}

export async function markApprovalBilled(
  prisma: any,
  scopeInput: VoucherScope,
  vchNo: number | string,
  saleRef?: string,
): Promise<{ marked: number }> {
  const scope = completeApprovalScope(scopeInput);
  const voucherNo = formatVoucherNo(vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await approvalBookTx(tx, scope, 'issue');
    const rows: Row[] = await tx.$queryRawUnsafe(
      `SELECT "TAG_NO","VCH_SRNO" FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND coalesce("ISU_REC",'N')='N'`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const marked = await tx.$executeRawUnsafe(
      `UPDATE "APR_DETL" SET "EMP_SALE"='Y',"ISU_REC"='Y',"ITM_REMARK"=$7
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5
          AND "VCH_NO"=$6 AND coalesce("ISU_REC",'N')='N'`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
      `Billed: ${saleRef ?? ''}`,
    );
    for (const row of rows.filter((line) => isApprovalTag(line.TAG_NO)))
      await tx.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "APR_ISU"='N',"APP_TRFR"='Y' WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        row.TAG_NO,
        num(row.VCH_SRNO),
      );
    return { marked: Number(marked) };
  });
}
