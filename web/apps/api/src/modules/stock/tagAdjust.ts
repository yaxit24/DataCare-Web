import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { insertRowTx } from '../posting/posting.js';
import { resolveLiveTagIdentityTx } from './stock.js';

export const TAG_ADJUST_BOOK = 'TAD' as const;

export class TagAdjustError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagAdjustError';
  }
}

export interface TagAdjustLine {
  tagNo: string;
  dataType: string;
  itCode?: string;
  vchSrno?: number;
  remark?: string;
}

export interface TagAdjustInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  book?: string;
  vchNo?: string | number;
  acCode?: string;
  empCode?: string;
  vchDesc?: string;
  mainUser?: string;
  lines: TagAdjustLine[];
}

export interface TagAdjustVoucher {
  header: Record<string, unknown> | null;
  lines: Array<Record<string, unknown>>;
  stones: Array<Record<string, unknown>>;
}

const text = (value: unknown, max = 255): string =>
  String(value ?? '')
    .trim()
    .slice(0, max);
const nullableText = (value: unknown, max = 255): string | null => text(value, max) || null;
const n = (value: unknown): number => Number(value ?? 0) || 0;

function normalizeScope(input: TagAdjustInput): VoucherScope & { coYear: string; coBook: string } {
  const coBook = text(input.book ?? input.scope.coBook ?? TAG_ADJUST_BOOK, 3);
  const scope = {
    ...input.scope,
    coBook,
    coYear: text(input.scope.coYear, 10),
  };
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new TagAdjustError('tagAdjust requires tenant, company, location, year and book');
  }
  return scope as VoucherScope & { coYear: string; coBook: string };
}

async function assertTagAdjustBookTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
) {
  const rows = (await tx.$queryRawUnsafe(
    `SELECT "BOOK_SNAME","BOOK_INOUT","MAIN_BOOK","BOOK_NAME"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1
        AND "CO_CODE"::text=$2::text
        AND "CO_BOOK"::text=$3::text
        AND ("LC_CODE"::text=$4::text OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
        AND coalesce(upper("CUR_USE"::text),'Y')<>'N'
      ORDER BY CASE WHEN "LC_CODE"::text=$4::text THEN 0 ELSE 1 END
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.coBook,
    scope.lcCode,
  )) as Array<Record<string, unknown>>;
  const row = rows[0];
  if (!row) throw new TagAdjustError(`tag-adjust book ${scope.coBook} is not configured`);
  const mainBook = text(row.MAIN_BOOK ?? row.BOOK_NAME, 30).toUpperCase();
  if (mainBook !== 'TAG ADJ') {
    throw new TagAdjustError(`book ${scope.coBook} is ${mainBook || 'blank'}, not TAG ADJ`);
  }
  return {
    vchType: text(row.BOOK_SNAME, 6) || 'TADJ',
    inoutType: text(row.BOOK_INOUT, 1) || 'T',
    mainBook: 'TAG ADJ',
    bookName: text(row.BOOK_NAME, 50) || 'Tag Adjust',
  };
}

async function sourceTagTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  line: TagAdjustLine,
): Promise<Record<string, unknown>> {
  const identity = await resolveLiveTagIdentityTx(tx, {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    TAG_NO: text(line.tagNo, 15),
    IT_CODE: nullableText(line.itCode, 5) ?? undefined,
    VCH_SRNO: line.vchSrno != null ? Number(line.vchSrno) : undefined,
  } as never);
  const rows = (await tx.$queryRawUnsafe(
    `SELECT *
       FROM "BAR_DETL"
      WHERE tenant_id=$1
        AND "CO_CODE"::text=$2::text
        AND "LC_CODE"::text=$3::text
        AND "TAG_NO"::text=$4::text
        AND "VCH_SRNO"::double precision IS NOT DISTINCT FROM $5::double precision
      ORDER BY row_id DESC
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    String(identity.TAG_NO ?? line.tagNo),
    Number(identity.VCH_SRNO ?? 0),
  )) as Array<Record<string, unknown>>;
  if (!rows[0]) throw new TagAdjustError(`tag ${line.tagNo} has no BAR_DETL source row to adjust`);
  return rows[0];
}

function headerRow(
  scope: VoucherScope & { coYear: string; coBook: string },
  input: TagAdjustInput,
  vchNo: string,
  vchDate: Date,
): Record<string, unknown> {
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: vchNo,
    VCH_DATE: vchDate,
    VCH_TIME: vchDate,
    HD_VCH_NO: vchNo,
    AC_CODE: nullableText(input.acCode, 8),
    EMP_CODE: nullableText(input.empCode, 3),
    VCH_DESC: nullableText(input.vchDesc, 255),
    MAIN_USER: nullableText(input.mainUser, 15) ?? 'system',
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
}

function detailRow(
  scope: VoucherScope & { coYear: string; coBook: string },
  meta: { vchType: string; inoutType: string; mainBook: string },
  input: TagAdjustInput,
  vchNo: string,
  vchDate: Date,
  line: TagAdjustLine,
  source: Record<string, unknown>,
  srNo: number,
): Record<string, unknown> {
  const dataType = text(line.dataType, 1).toUpperCase();
  if (!dataType) throw new TagAdjustError(`dataType is required for row ${srNo}`);
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: vchNo,
    SR_NO: srNo,
    OLD_SRNO: source.OLD_SRNO ?? srNo,
    VCH_DATE: vchDate,
    VCH_TIME: vchDate,
    VCH_TYPE: meta.vchType,
    INOUT_TYPE: meta.inoutType,
    ENTRY_TYPE: 'T',
    BOOK_NAME: meta.mainBook,
    AC_CODE: nullableText(input.acCode, 8),
    IT_CODE: source.IT_CODE,
    TAG_NO: source.TAG_NO,
    VCH_SRNO: source.VCH_SRNO,
    LOT_NO: source.LOT_NO,
    ITM_LOT: source.ITM_LOT,
    DESIGN_NO: source.DESIGN_NO,
    TBL_CODE: source.TBL_CODE,
    ITM_SIZE: source.ITM_SIZE,
    ITM_STYLE: source.ITM_STYLE,
    ITM_COLOR: source.ITM_COLOR,
    BAG_WT: source.BAG_WT,
    ITM_PCS: source.ITM_PCS,
    ITM_GWT: source.ITM_GWT,
    ITM_OTH_WT: source.ITM_OTH_WT,
    ITM_NWT: source.ITM_NWT,
    ITM_GHT_WT: source.ITM_GHT_WT,
    ITM_TOUCH: source.ITM_TOUCH,
    ITM_WEST_PRC: source.ITM_WEST_PRC,
    ITM_FINE: source.ITM_FINE,
    LBR_PRC: source.LBR_PRC,
    LBR_TYPE: source.LBR_TYPE,
    LBR_RATE: source.LBR_RATE,
    LBR_AMT: source.LBR_AMT,
    OTH_AMT: source.OTH_AMT,
    ITM_RATE: source.ITM_RATE,
    ITM_AMT: source.ITM_AMT,
    ITM_MRP: source.ITM_MRP,
    TAG_COST: source.TAG_COST,
    KR_NET_WT: source.KR_NET_WT,
    KR_TOUCH: source.KR_TOUCH,
    KR_WEST_PRC: source.KR_WEST_PRC,
    KR_FINE: source.KR_FINE,
    KR_NAME: source.KR_NAME,
    RATE_TYPE: source.RATE_TYPE,
    IT_TYPE: source.IT_TYPE,
    PR_CODE: source.PR_CODE,
    ITM_SIGN: source.ITM_SIGN,
    DATA_TYPE: dataType,
    ITM_REMARK: nullableText(line.remark, 255) ?? source.ITM_REMARK,
    HD_VCH_NO: vchNo,
    MAIN_USER: nullableText(input.mainUser, 15) ?? 'system',
    DATA_TRFR: 'N',
    DESIGN_IMG_ID: source.DESIGN_IMG_ID,
  };
}

async function copyStoneRowsTx(
  tx: any,
  tenantId: string,
  detail: Record<string, unknown>,
  source: Record<string, unknown>,
  srNo: number,
): Promise<number> {
  const stones = (await tx.$queryRawUnsafe(
    `SELECT *
       FROM "BAR_IDTL"
      WHERE tenant_id=$1
        AND "CO_CODE"::text=$2::text
        AND "LC_CODE"::text=$3::text
        AND "TAG_NO"::text=$4::text
        AND "VCH_SRNO"::double precision IS NOT DISTINCT FROM $5::double precision
      ORDER BY "SR_NO", "ISR_NO", row_id`,
    tenantId,
    detail.CO_CODE,
    detail.LC_CODE,
    source.TAG_NO,
    n(source.VCH_SRNO),
  )) as Array<Record<string, unknown>>;
  let copied = 0;
  for (const [index, stone] of stones.entries()) {
    const row: Record<string, unknown> = {
      CO_CODE: detail.CO_CODE,
      LC_CODE: detail.LC_CODE,
      CO_YEAR: detail.CO_YEAR,
      CO_BOOK: detail.CO_BOOK,
      VCH_NO: detail.VCH_NO,
      SR_NO: srNo,
      ISR_NO: stone.ISR_NO ?? index + 1,
      VCH_DATE: detail.VCH_DATE,
      VCH_TYPE: detail.VCH_TYPE,
      INOUT_TYPE: detail.INOUT_TYPE,
      ENTRY_TYPE: 'T',
      BOOK_NAME: detail.BOOK_NAME,
      AC_CODE: detail.AC_CODE,
      TAG_NO: detail.TAG_NO,
      VCH_SRNO: detail.VCH_SRNO,
      IT_CODE: stone.IT_CODE,
      IT_TYPE: stone.IT_TYPE,
      DM_CODE: stone.DM_CODE,
      DM_SIZE: stone.DM_SIZE,
      DM_SFNO: stone.DM_SFNO,
      DM_LEB: stone.DM_LEB,
      DM_NAME: stone.DM_NAME,
      DM_ORIGIN: stone.DM_ORIGIN,
      DM_REMARK: stone.DM_REMARK,
      DM_COLOR: stone.DM_COLOR,
      IT_PCS: stone.IT_PCS,
      IT_PCS_WT: stone.IT_PCS_WT,
      KR_WT: stone.KR_WT,
      KR_LESS_PRC: stone.KR_LESS_PRC,
      IT_GWT: stone.IT_GWT,
      IT_CON_PRC: stone.IT_CON_PRC,
      IT_CON_WT: stone.IT_CON_WT,
      IT_RATE_TYPE: stone.IT_RATE_TYPE,
      IT_RATE: stone.IT_RATE,
      IT_AMT: stone.IT_AMT,
      IT_LBR_RATE: stone.IT_LBR_RATE,
      IT_LBR_AMT: stone.IT_LBR_AMT,
      IT_NET_AMT: stone.IT_NET_AMT,
      KR_CON_PRC: stone.KR_CON_PRC,
      KR_CON_WT: stone.KR_CON_WT,
      KR_RATE: stone.KR_RATE,
      KR_AMT: stone.KR_AMT,
      KR_LBR_RATE: stone.KR_LBR_RATE,
      KR_LBR_AMT: stone.KR_LBR_AMT,
      KR_NET_AMT: stone.KR_NET_AMT,
      HD_VCH_NO: detail.HD_VCH_NO,
      MAIN_USER: detail.MAIN_USER,
    };
    await insertRowTx(tx, 'BAR_CAN_IDTL', tenantId, row);
    copied += 1;
  }
  return copied;
}

async function deleteRegisterTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  vchNo: string,
): Promise<void> {
  for (const table of ['BAR_CAN_IDTL', 'BAR_CAN_DETL', 'BAR_CAN_DATA'] as const) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text
          AND "CO_YEAR"::text=$4::text AND "CO_BOOK"::text=$5::text AND "VCH_NO"::text=$6::text`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
  }
}

async function updateSourceDataTypesTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  vchNo: string,
): Promise<{ barDetlUpdated: number; mainStockUpdated: number }> {
  const barDetlUpdated = Number(
    await tx.$executeRawUnsafe(
      `UPDATE "BAR_DETL" AS B
          SET "DATA_TYPE"=A."DATA_TYPE"
         FROM "BAR_CAN_DETL" AS A
        WHERE B.tenant_id=A.tenant_id
          AND B."CO_CODE"::text=A."CO_CODE"::text
          AND B."LC_CODE"::text=A."LC_CODE"::text
          AND B."TAG_NO"::text=A."TAG_NO"::text
          AND B."VCH_SRNO"::double precision IS NOT DISTINCT FROM A."VCH_SRNO"::double precision
          AND A.tenant_id=$1
          AND A."CO_CODE"::text=$2::text
          AND A."LC_CODE"::text=$3::text
          AND A."CO_YEAR"::text=$4::text
          AND A."CO_BOOK"::text=$5::text
          AND A."VCH_NO"::text=$6::text`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    ),
  );
  const mainStockUpdated = Number(
    await tx.$executeRawUnsafe(
      `UPDATE "MAIN_STOCK" AS M
          SET "DATA_TYPE"=A."DATA_TYPE"
         FROM "BAR_CAN_DETL" AS A
        WHERE M.tenant_id=A.tenant_id
          AND M."CO_CODE"::text=A."CO_CODE"::text
          AND M."LC_CODE"::text=A."LC_CODE"::text
          AND M."TAG_NO"::text=A."TAG_NO"::text
          AND M."VCH_SRNO"::double precision IS NOT DISTINCT FROM A."VCH_SRNO"::double precision
          AND A.tenant_id=$1
          AND A."CO_CODE"::text=$2::text
          AND A."LC_CODE"::text=$3::text
          AND A."CO_YEAR"::text=$4::text
          AND A."CO_BOOK"::text=$5::text
          AND A."VCH_NO"::text=$6::text`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    ),
  );
  return { barDetlUpdated, mainStockUpdated };
}

export async function saveTagAdjust(
  prisma: any,
  input: TagAdjustInput,
): Promise<{
  vchNo: number;
  lines: number;
  stones: number;
  barDetlUpdated: number;
  mainStockUpdated: number;
}> {
  if (!input.lines?.length) throw new TagAdjustError('tagAdjust requires at least one line');
  const scope = normalizeScope(input);
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const meta = await assertTagAdjustBookTx(tx, scope);
    const vchNo =
      input.vchNo == null
        ? formatVoucherNo(await nextVoucherNoTx(tx, scope))
        : formatVoucherNo(input.vchNo);
    await deleteRegisterTx(tx, scope, vchNo);
    await insertRowTx(tx, 'BAR_CAN_DATA', scope.tenantId, headerRow(scope, input, vchNo, vchDate));
    let stones = 0;
    for (const [index, line] of input.lines.entries()) {
      if (!text(line.tagNo, 15)) throw new TagAdjustError(`tagNo is required for row ${index + 1}`);
      const source = await sourceTagTx(tx, scope, line);
      const detail = detailRow(scope, meta, input, vchNo, vchDate, line, source, index + 1);
      await insertRowTx(tx, 'BAR_CAN_DETL', scope.tenantId, detail);
      stones += await copyStoneRowsTx(tx, scope.tenantId, detail, source, index + 1);
    }
    const updates = await updateSourceDataTypesTx(tx, scope, vchNo);
    return { vchNo: Number(vchNo), lines: input.lines.length, stones, ...updates };
  });
}

export async function getTagAdjust(
  prisma: any,
  inputScope: VoucherScope,
  vchNoInput: string | number,
  book?: string,
): Promise<TagAdjustVoucher | null> {
  const scope = normalizeScope({
    scope: { ...inputScope, coBook: book ?? inputScope.coBook },
    lines: [{ tagNo: 'x', dataType: 'x' }],
  });
  const vchNo = formatVoucherNo(vchNoInput);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const headers = (await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_CAN_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text
          AND "CO_YEAR"::text=$4::text AND "CO_BOOK"::text=$5::text AND "VCH_NO"::text=$6::text
        LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    )) as Array<Record<string, unknown>>;
    if (!headers[0]) return null;
    const lines = (await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_CAN_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text
          AND "CO_YEAR"::text=$4::text AND "CO_BOOK"::text=$5::text AND "VCH_NO"::text=$6::text
        ORDER BY "SR_NO", row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    )) as Array<Record<string, unknown>>;
    const stones = (await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_CAN_IDTL"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "LC_CODE"::text=$3::text
          AND "CO_YEAR"::text=$4::text AND "CO_BOOK"::text=$5::text AND "VCH_NO"::text=$6::text
        ORDER BY "SR_NO", "ISR_NO", row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    )) as Array<Record<string, unknown>>;
    return { header: headers[0], lines, stones };
  });
}

export async function deleteTagAdjust(
  prisma: any,
  inputScope: VoucherScope,
  vchNoInput: string | number,
  book?: string,
): Promise<{ deleted: true }> {
  const scope = normalizeScope({
    scope: { ...inputScope, coBook: book ?? inputScope.coBook },
    lines: [{ tagNo: 'x', dataType: 'x' }],
  });
  const vchNo = formatVoucherNo(vchNoInput);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await deleteRegisterTx(tx, scope, vchNo);
    return { deleted: true };
  });
}
