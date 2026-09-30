import { withTenant } from '@datacare/db';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import {
  resolveBookAccountTx,
  resolveBookPolicyTx,
  type BookPolicy,
} from '../shared/bookPolicy.js';
import { fineFor } from '../shared/finePolicy.js';
import { resolveRoundingPolicyTx } from '../shared/roundingPolicyLoader.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { assertFiscalDateTx, voucherTimestamp } from '../vouchers/lifecycle.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import {
  completeFinanceScope,
  createIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  voucherKey,
  type CompleteFinanceScope,
  type VoucherIdentity,
} from '../finance/lifecycle.js';

export class WholesaleSaleReturnValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'WholesaleSaleReturnValidationError';
  }
}

const numOr0 = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
const textOr = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;
/** Several RATE_CUT_REC columns are varchar(255) in the restored schema. */
const asText = (v: unknown): string | null => (v == null || v === '' ? null : String(v));
// Numeric sibling of asText, for the columns corrected from varchar to double precision. NULL rather
// than 0 for a cleared value, so "not entered" stays distinguishable from "entered as zero".
const asNumberOrNull = (v: unknown): number | null => (v == null || v === '' ? null : Number(v));

export interface WholesaleSaleReturnComponentInput {
  dmCode: string;
  pcs?: number;
  weight?: number;
  rateType?: string;
  rate?: number;
  labourRate?: number;
}

export interface WholesaleSaleReturnLineInput {
  tagNo?: string;
  tagVoucherSrNo?: number;
  sourceYear?: string;
  sourceBook?: string;
  sourceVoucherNo?: string;
  itemCode?: string;
  tableCode?: string;
  designNo?: string;
  size?: string;
  remark?: string;
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  ghatPct?: number;
  touch?: number;
  westPct?: number;
  lessTouch?: number;
  rateType?: string;
  rate?: number;
  mrp?: number;
  labourType?: string;
  labourRate?: number;
  otherAmount?: number;
  taxPct?: number;
  taxCode?: string;
  components?: WholesaleSaleReturnComponentInput[];
}

export interface WholesaleSaleReturnInput {
  scope: VoucherScope;
  vchDate: string | Date;
  partyCode: string;
  billNo?: string;
  employeeCode?: string;
  description?: string;
  cashAmount?: number;
  chequeAmount?: number;
  cardAmount?: number;
  kasarAmount?: number;
  bankAccount?: string;
  cardAccount?: string;
  chequeNo?: string;
  lines: WholesaleSaleReturnLineInput[];
  mainUser?: string;
}

type ReturnPolicy = BookPolicy & { configuredName: string; dataType: string };
type Component = {
  dmCode: string;
  dmName: string;
  dmOrigin: string;
  dmColor: string;
  pcs: number;
  weight: number;
  rateType: string;
  rate: number;
  amount: number;
  labourRate: number;
  labourAmount: number;
  netAmount: number;
};
type Line = {
  // ---- Rate-cut basis (RATE_CUT_REC) -------------------------------------------------------------
  lessWt?: number; // LESS_WT
  tagCost?: number; // TAG_COST
  labourPct?: number; // LBR_PRC
  lotNo?: string; // LOT_NO
  otherRate?: number | string; // ITM_OTH_RATE (varchar)
  otherFine?: number | string; // ITM_OTH_FINE (varchar)
  convRate?: number | string; // CONV_RATE (varchar)
  convPct?: number | string; // CONV_PRC (varchar)
  silverFine?: number | string; // SILVER_FINE (varchar)
  srNo: number;
  oldSrNo: number;
  tagNo: string;
  tagVoucherSrNo: number;
  itemCode: string;
  itemName: string;
  itemType: 'G' | 'S';
  tableCode: string;
  designNo: string;
  size: string;
  remark: string;
  pcs: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  ghatPct: number;
  ghatWt: number;
  touch: number;
  westPct: number;
  lessTouch: number;
  fineWt: number;
  rateType: string;
  rate: number;
  itemAmount: number;
  mrp: number;
  labourType: string;
  labourRate: number;
  labourAmount: number;
  otherAmount: number;
  totalAmount: number;
  netAmount: number;
  taxPct: number;
  prCode: string;
  sourceYear: string;
  sourceBook: string;
  sourceVoucherNo: string;
  components: Component[];
};

const n = (value: unknown): number => Number(value ?? 0) || 0;
const money = (value: unknown): number => Math.round((n(value) + Number.EPSILON) * 100) / 100;
const weight = (value: unknown): number => Math.round((n(value) + Number.EPSILON) * 1000) / 1000;

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new WholesaleSaleReturnValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new WholesaleSaleReturnValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function resolveBookTx(tx: any, scope: CompleteFinanceScope): Promise<ReturnPolicy> {
  // TR_WH_SALE_RTN.cs:6515-6520 loads CurBookName, MAIN_BOOK, BOOK_SNAME and BOOK_INOUT;
  // :7350-7353 persists short name as VCH_TYPE and MAIN_BOOK as BOOK_NAME.
  const policy = await resolveBookPolicyTx(tx, scope, 'WHOLESALE SALE RETURN');
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","DATA_TYPE","MAIN_BOOK","BOOK_INOUT" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N' ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (
    rows.length !== 1 ||
    text(rows[0]?.MAIN_BOOK).toUpperCase() !== 'WH RTN' ||
    text(rows[0]?.BOOK_INOUT).toUpperCase() !== 'I'
  ) {
    throw new WholesaleSaleReturnValidationError(
      'wholesale sale return book configuration is ambiguous',
    );
  }
  return {
    ...policy,
    configuredName: text(rows[0]!.BOOK_NAME) || policy.mainBook,
    dataType: text(rows[0]!.DATA_TYPE) || 'A',
  };
}

async function accountTx(tx: any, scope: CompleteFinanceScope, codeInput: unknown, label: string) {
  const code = text(codeInput);
  if (!code) {
    // Exact desktop validation: TR_WH_SALE_RTN.cs:7171.
    throw new WholesaleSaleReturnValidationError(
      label === 'party' ? 'Please Insert Party and try' : `${label} is required`,
    );
  }
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
      AND "AC_CODE"=$3 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1) {
    throw new WholesaleSaleReturnValidationError(
      rows.length ? `${label} is ambiguous: ${code}` : `${label} not found: ${code}`,
    );
  }
  return { code: text(rows[0]!.AC_CODE), name: text(rows[0]!.AC_NAME) };
}

async function employeeTx(tx: any, input: WholesaleSaleReturnInput): Promise<string> {
  const code = text(input.employeeCode);
  if (!code) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    code,
  );
  if (rows.length !== 1)
    throw new WholesaleSaleReturnValidationError(`employee not found: ${code}`);
  return code;
}

async function itemTx(
  tx: any,
  scope: CompleteFinanceScope,
  codeInput: unknown,
): Promise<Record<string, unknown> & { itemType: 'G' | 'S' }> {
  const code = text(codeInput);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE","IT_TOUCH","IT_WEST",
            "IT_LBR_RATE","IT_GHT_PRC" FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1) {
    throw new WholesaleSaleReturnValidationError(
      rows.length ? `item is ambiguous: ${code}` : `item not found: ${code}`,
    );
  }
  const itemType = text(rows[0]!.IT_TYPE).toUpperCase();
  if (itemType !== 'G' && itemType !== 'S') {
    throw new WholesaleSaleReturnValidationError(`item ${code} has invalid metal type`);
  }
  return { ...rows[0]!, itemType: itemType as 'G' | 'S' };
}

async function componentInputTx(
  tx: any,
  scope: CompleteFinanceScope,
  values: WholesaleSaleReturnComponentInput[],
): Promise<Component[]> {
  const out: Component[] = [];
  for (const value of values) {
    const code = text(value.dmCode);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "DM_CODE","DM_NAME","DM_SHAPE","DM_COLOR" FROM "DM_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "DM_CODE"=$3 LIMIT 2`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (rows.length !== 1) {
      throw new WholesaleSaleReturnValidationError(
        rows.length ? `component is ambiguous: ${code}` : `component not found: ${code}`,
      );
    }
    const pcs = n(value.pcs);
    const wt = weight(value.weight);
    const rate = money(value.rate);
    const labourRate = money(value.labourRate);
    const amount = money(wt * rate);
    const labourAmount = money(pcs * labourRate);
    out.push({
      dmCode: code,
      dmName: text(rows[0]!.DM_NAME),
      dmOrigin: text(rows[0]!.DM_SHAPE),
      dmColor: text(rows[0]!.DM_COLOR),
      pcs,
      weight: wt,
      rateType: text(value.rateType),
      rate,
      amount,
      labourRate,
      labourAmount,
      netAmount: money(amount + labourAmount),
    });
  }
  return out;
}

async function soldTagTx(
  tx: any,
  scope: CompleteFinanceScope,
  partyCode: string,
  input: WholesaleSaleReturnLineInput,
  currentVoucherNo?: string,
) {
  const tagNo = text(input.tagNo);
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `tag-issue|${scope.coCode}|${scope.lcCode}|${tagNo}`,
  );
  const params: unknown[] = [scope.tenantId, scope.coCode, scope.lcCode, partyCode, tagNo];
  const filters: string[] = [];
  for (const [column, value] of [
    ['CO_YEAR', input.sourceYear],
    ['CO_BOOK', input.sourceBook],
    ['VCH_NO', input.sourceVoucherNo && formatVoucherNo(input.sourceVoucherNo)],
  ] as const) {
    if (text(value)) {
      params.push(value);
      filters.push(`AND r."${column}"::text=$${params.length}::text`);
    }
  }
  if (n(input.tagVoucherSrNo)) {
    params.push(n(input.tagVoucherSrNo));
    filters.push(`AND coalesce(r."VCH_SRNO",0)=$${params.length}::numeric`);
  }
  // Desktop tag help is RATE_CUT_ISU limited to WH SALES/TOUR SALES and the selected party
  // (TR_WH_SALE_RTN.cs:4783-4798). All item/tag values therefore come from this persisted row.
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT r.* FROM "RATE_CUT_ISU" r WHERE r.tenant_id=$1 AND r."CO_CODE"=$2
      AND r."LC_CODE"=$3 AND r."AC_CODE"=$4 AND r."TAG_NO"=$5
      AND upper(btrim(coalesce(r."BOOK_NAME"::text,''))) IN ('WH SALES','TOUR SALES')
      ${filters.join(' ')} ORDER BY r."VCH_DATE" DESC,r.row_id DESC LIMIT 2 FOR UPDATE`,
    ...params,
  );
  if (rows.length !== 1) {
    throw new WholesaleSaleReturnValidationError(
      rows.length
        ? `sold tag identity is ambiguous: ${tagNo}`
        : `sold tag not found for party: ${tagNo}`,
    );
  }
  const source = rows[0]!;
  /**
   * "Currently sold" is decided by the tag's LATEST stock movement, not by a signed count.
   *
   * The count required exactly -1, which only holds for a tag that never had an inward row. A purchased or
   * opening tag enters stock with a '+' row, so once the wholesale sale writes its '-' row (Wh_Sale_Stk SR_NO 1)
   * the count is 0 and a genuinely sold tag was refused; an edited return of such a tag counts +1 and was
   * refused too. The desktop's return help (TR_WH_SALE_RTN.cs:4775-4800) tests no balance at all. The latest
   * movement answers the real question for every origin:
   *   new return  → the latest row is the source wholesale voucher's '-' (sold, not yet returned);
   *   edit        → the latest row is this return's own '+' (nothing has moved the tag since).
   */
  const latest: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_YEAR","CO_BOOK","VCH_NO","ITM_SIGN"
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
        AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')
      ORDER BY row_id DESC LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    source.TAG_NO,
    source.VCH_SRNO ?? 0,
    source.IT_CODE,
  );
  const last = latest[0];
  const lastIs = (year: unknown, book: unknown, voucher: unknown, sign: string): boolean =>
    !!last &&
    text(last.CO_YEAR) === text(year) &&
    text(last.CO_BOOK) === text(book) &&
    text(last.VCH_NO) === text(voucher) &&
    text(last.ITM_SIGN) === sign;
  if (currentVoucherNo) {
    if (!lastIs(scope.coYear, scope.coBook, currentVoucherNo, '+')) {
      throw new WholesaleSaleReturnValidationError(
        `tag is not owned by this return or was moved again: ${tagNo}`,
      );
    }
  } else if (!lastIs(source.CO_YEAR, source.CO_BOOK, source.VCH_NO, '-')) {
    throw new WholesaleSaleReturnValidationError(
      `tag is not currently sold or was already returned: ${tagNo}`,
    );
  }
  return source;
}

async function sourceComponentsTx(
  tx: any,
  scope: CompleteFinanceScope,
  source: Record<string, unknown>,
) {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND "CO_YEAR"::text=$4::text AND "CO_BOOK"::text=$5::text AND "VCH_NO"::text=$6::text
      AND coalesce("SR_NO",0)=coalesce($7::numeric,0) ORDER BY "ISR_NO",row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    source.CO_YEAR,
    source.CO_BOOK,
    source.VCH_NO,
    source.SR_NO ?? source.OLD_SRNO ?? 0,
  );
  return rows.map((row) => ({
    dmCode: text(row.DM_CODE),
    dmName: text(row.DM_NAME),
    dmOrigin: text(row.DM_ORIGIN),
    dmColor: text(row.DM_COLOR),
    pcs: n(row.IT_PCS),
    weight: weight(row.IT_GWT),
    rateType: text(row.IT_RATE_TYPE),
    rate: money(row.IT_RATE),
    amount: money(row.IT_AMT),
    labourRate: money(row.IT_LBR_RATE),
    labourAmount: money(row.IT_LBR_AMT),
    netAmount: money(row.IT_NET_AMT),
  }));
}

function itemAmount(rateType: string, pcs: number, fineWt: number, rate: number): number {
  // TR_WH_SALE_RTN.cs:5805-5818: P=pcs, 1=fine/10, K=fine/1000, default=fine.
  const raw =
    rateType === 'P'
      ? pcs * rate
      : rateType === '1'
        ? fineWt * (rate / 10)
        : rateType === 'K'
          ? fineWt * (rate / 1000)
          : fineWt * rate;
  return money(Math.round(raw));
}

function labourAmount(
  type: string,
  pcs: number,
  gross: number,
  net: number,
  ghat: number,
  rate: number,
) {
  // TR_WH_SALE_RTN.cs:5849-5871: P=pcs, N=net (the persisted company ghat switch is not guessed),
  // K=(net+ghat)/1000, default=gross; desktop rounds to whole currency units.
  if (type === 'P') return money(Math.round(pcs * rate));
  if (type === 'N') return money(Math.round(net * rate));
  if (type === 'K') return money(Math.round((net + ghat) * (rate / 1000)));
  return money(Math.round(gross * rate));
}

async function resolveLinesTx(
  tx: any,
  input: WholesaleSaleReturnInput,
  currentVoucherNo?: string,
): Promise<Line[]> {
  const scope = completeFinanceScope(input.scope);
  if (!Array.isArray(input.lines) || !input.lines.length) {
    throw new WholesaleSaleReturnValidationError(
      'wholesale sale return requires at least one item line',
    );
  }
  const rounding = await resolveRoundingPolicyTx(tx, scope);
  const party = await accountTx(tx, scope, input.partyCode, 'party');
  const out: Line[] = [];
  const seen = new Set<string>();
  for (let index = 0; index < input.lines.length; index++) {
    const value = input.lines[index]!;
    const tagged = text(value.tagNo) && text(value.tagNo).toUpperCase() !== 'N';
    const source = tagged
      ? await soldTagTx(tx, scope, party.code, value, currentVoucherNo)
      : undefined;
    const item = await itemTx(tx, scope, source?.IT_CODE ?? value.itemCode);
    const tagNo = tagged ? text(source!.TAG_NO) : 'N';
    const identity = `${tagNo}|${n(source?.VCH_SRNO)}|${text(item.IT_CODE)}`;
    if (tagged && seen.has(identity)) {
      throw new WholesaleSaleReturnValidationError(`duplicate returned tag: ${tagNo}`);
    }
    seen.add(identity);
    const grossWt = weight(source?.ITM_GWT ?? value.grossWt);
    const otherWt = weight(source?.ITM_OTH_WT ?? value.otherWt);
    const netWt = weight(source?.ITM_NWT ?? grossWt - otherWt);
    const ghatPct = n(source?.ITM_GHT_PRC ?? value.ghatPct ?? item.IT_GHT_PRC);
    const ghatWt = weight(source?.ITM_GHT_WT ?? (netWt * ghatPct) / 100);
    const touch = n(source?.ITM_TOUCH ?? value.touch ?? item.IT_TOUCH);
    const westPct = n(source?.ITM_WEST_PRC ?? value.westPct ?? item.IT_WEST);
    const lessTouch = n(value.lessTouch ?? source?.LESS_TOUCH);
    const fineWt = fineFor('wholesaleSaleReturn', {
      netWt,
      ghtWt: ghatWt,
      touch,
      westPct,
      lesTouch: lessTouch,
    });
    const pcs = n(source?.ITM_PCS ?? value.pcs);
    const rateType = text(value.rateType || source?.RATE_TYPE || item.RATE_TYPE);
    const rate = rounding.roundItemRate(n(value.rate ?? source?.ITM_RATE));
    const itmAmount = itemAmount(rateType, pcs, fineWt, rate);
    const labourType = text(value.labourType || source?.LBR_TYPE || 'G');
    const labourRate = money(value.labourRate ?? source?.LBR_RATE ?? item.IT_LBR_RATE);
    const lbrAmount = labourAmount(labourType, pcs, grossWt, netWt, ghatWt, labourRate);
    const otherAmount = money(value.otherAmount ?? source?.OTH_AMT);
    const mrp = money(value.mrp ?? source?.ITM_MRP);
    const totalAmount = mrp || money(itmAmount + lbrAmount + otherAmount);
    const taxPct = n(value.taxPct ?? source?.TAX_PRC);
    if (taxPct) {
      const tax = await resolveTaxPolicyTx(tx, scope, {
        acCode: party.code,
        taxPct,
        taxCode: value.taxCode,
      });
      if (tax.taxPct !== taxPct)
        throw new WholesaleSaleReturnValidationError(
          'tax rate does not match persisted tax policy',
        );
    }
    // Inclusive-tax entry: TR_WH_SALE_RTN.cs:5963-6004 computes total then backs tax out of NET_AMT.
    const netAmount = taxPct
      ? money(Math.round((totalAmount / (taxPct + 100)) * 100))
      : totalAmount;
    out.push({
      srNo: index + 1,
      oldSrNo: n(source?.OLD_SRNO ?? source?.SR_NO) || index + 1,
      tagNo,
      tagVoucherSrNo: n(source?.VCH_SRNO),
      itemCode: text(item.IT_CODE),
      itemName: text(item.IT_NAME),
      itemType: item.itemType,
      tableCode: text(source?.TBL_CODE ?? value.tableCode) || '001',
      designNo: text(source?.DESIGN_NO ?? value.designNo),
      size: text(source?.ITM_SIZE ?? value.size),
      remark: text(value.remark || source?.ITM_REMARK).slice(0, 150),
      pcs,
      grossWt,
      otherWt,
      netWt,
      ghatPct,
      ghatWt,
      touch,
      westPct,
      lessTouch,
      fineWt,
      rateType,
      rate,
      itemAmount: itmAmount,
      mrp,
      labourType,
      labourRate,
      labourAmount: lbrAmount,
      otherAmount,
      totalAmount,
      netAmount,
      taxPct,
      prCode: text(source?.PR_CODE ?? item.PR_CODE),
      sourceYear: text(source?.CO_YEAR),
      sourceBook: text(source?.CO_BOOK),
      sourceVoucherNo: text(source?.VCH_NO),
      components: tagged
        ? await sourceComponentsTx(tx, scope, source!)
        : await componentInputTx(tx, scope, value.components ?? []),
    });
  }
  const types = new Set(out.map((line) => line.itemType));
  if (types.size !== 1) {
    throw new WholesaleSaleReturnValidationError(
      'one wholesale sale return cannot mix gold and silver item types',
    );
  }
  return out;
}

async function assertReplacementSafeTx(
  tx: any,
  scope: CompleteFinanceScope,
  voucherNo: string,
  replacement: Line[],
): Promise<void> {
  const stock: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT row_id,"TAG_NO","VCH_SRNO","IT_CODE" FROM "MAIN_STOCK"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
       AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  for (const row of stock.filter((value) => text(value.TAG_NO) !== 'N')) {
    const moved: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
        AND "IT_CODE"=$6 AND "ITM_SIGN"='-' AND row_id>$7`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      row.TAG_NO,
      row.VCH_SRNO ?? 0,
      row.IT_CODE,
      row.row_id,
    );
    if (n(moved[0]?.n)) {
      throw new WholesaleSaleReturnValidationError(
        `wholesale sale return cannot be changed — returned tag ${text(row.TAG_NO)} was sold or moved again`,
      );
    }
  }
  const loose = replacement.filter((line) => line.tagNo === 'N');
  const items = [
    ...new Set([
      ...stock.filter((r) => text(r.TAG_NO) === 'N').map((r) => text(r.IT_CODE)),
      ...loose.map((r) => r.itemCode),
    ]),
  ].filter(Boolean);
  for (const code of items.sort()) {
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `loose-stock|${scope.coCode}|${scope.lcCode}|${code}|`,
    );
  }
  for (const code of items) {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_PCS",0) ELSE -coalesce("ITM_PCS",0) END),0)::float pcs,
              coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_GWT",0) ELSE -coalesce("ITM_GWT",0) END),0)::float gwt,
              coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_NWT",0) ELSE -coalesce("ITM_NWT",0) END),0)::float nwt,
              coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_FINE",0) ELSE -coalesce("ITM_FINE",0) END),0)::float fine
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "IT_CODE"=$4
          AND coalesce("TAG_NO"::text,'N')='N' AND NOT ("CO_YEAR"=$5 AND "CO_BOOK"=$6 AND "VCH_NO"=$7)`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      code,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const proposed = loose.filter((line) => line.itemCode === code);
    const balance = {
      pcs: n(rows[0]?.pcs) + proposed.reduce((sum, line) => sum + line.pcs, 0),
      gwt: n(rows[0]?.gwt) + proposed.reduce((sum, line) => sum + line.grossWt, 0),
      nwt: n(rows[0]?.nwt) + proposed.reduce((sum, line) => sum + line.netWt, 0),
      fine: n(rows[0]?.fine) + proposed.reduce((sum, line) => sum + line.fineWt, 0),
    };
    if (Object.values(balance).some((value) => value < -0.0005)) {
      throw new WholesaleSaleReturnValidationError(
        `item ${code} returned metal was already consumed; this change would strand negative stock`,
      );
    }
  }
}

function ledgerBase(
  scope: CompleteFinanceScope,
  policy: ReturnPolicy,
  identity: VoucherIdentity,
  key: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    VCH_TYPE: policy.vchType,
    VCH_DATE: identity.voucherDate,
    LEDR_KEY: key,
    BOOK_NAME: policy.mainBook,
    BILL_NO: '',
    BILL_DATE: null,
    CHQ_NO: '',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: '',
    ENTRY_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    CLR_DATE: null,
    DATA_TYPE: policy.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    FINE_RATE: 0,
    PARTY_AC_CODE: '',
    LDR_NAME: '',
  };
}

async function writeTx(
  tx: any,
  input: WholesaleSaleReturnInput,
  policy: ReturnPolicy,
  identity: VoucherIdentity,
  lines: Line[],
) {
  const scope = completeFinanceScope(input.scope);
  // RATE_PAR mirrors the company's configured metal-rate basis. The desktop sets CurRatePar from MsRatePar
  // for a new voucher (TR_WH_SALE_RTN.cs:6604-6612) and reads it back on reopen (:6787), so a hardcoded 'G'
  // mislabels every voucher at a shop quoting per-10-gram or per-kilogram rates — and the error then
  // propagates, because the stored value is what a reopened voucher trusts.
  const { rateBasis } = await resolveSettingsBehaviorTx(tx, scope);
  const party = await accountTx(tx, scope, input.partyCode, 'party');
  const employee = await employeeTx(tx, input);
  const itemType = lines[0]!.itemType;
  const itemAccount = await resolveBookAccountTx(tx, scope, policy, itemType === 'G' ? 1 : 2);
  const labourTotal = money(lines.reduce((sum, line) => sum + line.labourAmount, 0));
  const otherTotal = money(lines.reduce((sum, line) => sum + line.otherAmount, 0));
  const cashAmount = money(input.cashAmount);
  const chequeAmount = money(input.chequeAmount);
  const cardAmount = money(input.cardAmount);
  const kasarAmount = money(input.kasarAmount);
  const tenderAmounts = [cashAmount, chequeAmount, cardAmount, kasarAmount];
  if (tenderAmounts.some((amount) => amount < 0)) {
    throw new WholesaleSaleReturnValidationError('settlement amounts cannot be negative');
  }
  const labourAccount =
    labourTotal || otherTotal || kasarAmount
      ? await resolveBookAccountTx(tx, scope, policy, 4)
      : itemAccount;
  const otherAccount = otherTotal ? await resolveBookAccountTx(tx, scope, policy, 6) : itemAccount;
  const cashAccount = cashAmount ? await resolveBookAccountTx(tx, scope, policy, 3) : itemAccount;
  const kasarRojmelAccount = kasarAmount
    ? await resolveBookAccountTx(tx, scope, policy, 5)
    : labourAccount;
  const bankAccount = chequeAmount
    ? (await accountTx(tx, scope, input.bankAccount, 'bank account')).code
    : '';
  const cardAccount = cardAmount
    ? (await accountTx(tx, scope, input.cardAccount, 'card account')).code
    : '';
  await accountTx(tx, scope, itemAccount, 'configured item account');
  if (labourTotal || otherTotal || kasarAmount)
    await accountTx(tx, scope, labourAccount, 'configured labour/kasar account');
  if (otherTotal) await accountTx(tx, scope, otherAccount, 'configured other account');
  if (cashAmount) await accountTx(tx, scope, cashAccount, 'configured cash account');
  if (kasarAmount)
    await accountTx(tx, scope, kasarRojmelAccount, 'configured kasar rojmel account');
  const itemTotal = money(lines.reduce((sum, line) => sum + (line.mrp || line.itemAmount), 0));
  const total = money(lines.reduce((sum, line) => sum + line.totalAmount, 0));
  const settled = money(tenderAmounts.reduce((sum, amount) => sum + amount, 0));
  if (settled > total) {
    throw new WholesaleSaleReturnValidationError('settlement amounts exceed voucher total');
  }
  const billOutstanding = money(total - settled);
  const totalFine = weight(lines.reduce((sum, line) => sum + line.fineWt, 0));

  // Main numbering is RATE_CUT_DATA by fiscal scope (:6671, :7193); hidden numbering is
  // TEMP_BOOK_DATA by company+location+book with no year (:6683, :7205).
  await insertHiddenIdentityTx(tx, scope, identity, policy.configuredName);
  // Complete desktop RATE_CUT_DATA assignment block: TR_WH_SALE_RTN.cs:7229-7330.
  await insertRowTx(tx, 'RATE_CUT_DATA', scope.tenantId, {
    ...voucherKey(scope, identity.voucherNo),
    VCH_DATE: identity.voucherDate,
    VCH_TIME: identity.voucherTime,
    BILL_NO: text(input.billNo).slice(0, 30),
    HD_VCH_NO: identity.hiddenVoucherNo,
    AC_CODE: party.code,
    AC_NAME: party.name,
    DR_AMT: 0,
    CR_FINE: 0,
    CR_AMT: 0,
    DR_FINE: 0,
    CONV_RATE: 0,
    CONV_PRC: 0,
    // The zero settlement columns above are faithful: TR_WH_SALE_RTN writes DR_AMT/CR_AMT/DR_FINE/CR_FINE/
    // CONV_RATE/CONV_PRC as literal zeros and does NOT derive a money/metal settlement. Only RATE_PAR is
    // configured.
    RATE_PAR: rateBasis,
    FINE_RATE: 0,
    SL_FINE: Number(totalFine) || 0,
    PR_FINE: 0,
    TOT_FINE_CR: 0,
    TOT_FINE_DR: Number(totalFine) || 0,
    KSR_FINE_CR: 0,
    KSR_FINE_DR: 0,
    IT_TYPE: itemType,
    SILVER_FINE_DR: 0,
    SILVER_FINE_CR: 0,
    SLV_FINE_CR: 0,
    SLV_FINE_DR: 0,
    SLV_AMT_CR: 0,
    SLV_AMT_DR: 0,
    SLV_FINE_RATE: 0,
    PR_ITM_AMT: 0,
    PR_LBR_AMT: 0,
    PR_OTH_AMT: 0,
    PR_NET_AMT: 0,
    PR_TAX_AMT: 0,
    PR_TOT_AMT: 0,
    PR_CHQ_AMT: 0,
    PR_CARD_AMT: 0,
    PR_ADV_AMT: 0,
    PR_CASH_AMT: 0,
    PR_KASAR_AMT: 0,
    PR_BILL_OS: 0,
    TAX_PRC: 0,
    SL_ITM_AMT: Number(itemTotal) || 0,
    SL_LBR_AMT: Number(labourTotal) || 0,
    SL_OTH_AMT: Number(otherTotal) || 0,
    SL_NET_AMT: Number(total) || 0,
    SL_TAX_AMT: 0,
    SL_TOT_AMT: Number(total) || 0,
    SL_CHQ_AMT: Number(chequeAmount) || 0,
    SL_CARD_AMT: Number(cardAmount) || 0,
    SL_ADV_AMT: 0,
    SL_CASH_AMT: Number(cashAmount) || 0,
    SL_KASAR_AMT: Number(kasarAmount) || 0,
    SL_BILL_OS: Number(billOutstanding) || 0,
    CARD_AC: cardAccount,
    BANK_AC: bankAccount,
    CHQ_NO: text(input.chequeNo).slice(0, 30),
    CR_DAYS: 0,
    INT_DAYS: 0,
    INT_PRC_FINE: 0,
    INT_FINE: 0,
    EMP_CODE: employee,
    VCH_DESC: text(input.description).slice(0, 150),
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    MOB_ENTRY_SAVE: 'Y',
    TDS_PRC: 0,
    PR_TDS_AMT: 0,
    SL_TDS_AMT: 0,
    VP_AMT: 0,
    VP_INS_AMT: 0,
    VP_CHARG_AMT: 0,
    VP_ADJ_AMT: 0,
  });

  for (const line of lines) {
    const detail = {
      ...voucherKey(scope, identity.voucherNo),
      SR_NO: line.srNo,
      OLD_SRNO: line.oldSrNo,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      HD_VCH_NO: identity.hiddenVoucherNo,
      AC_CODE: party.code,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'P',
      BOOK_NAME: policy.mainBook,
      IT_CODE: line.itemCode,
      ITM_REMARK: line.remark,
      TAG_NO: line.tagNo,
      TBL_CODE: line.tableCode,
      DESIGN_NO: line.designNo,
      ITM_SIZE: line.size,
      BAG_WT: 0,
      ITM_PCS: line.pcs,
      ITM_GWT: line.grossWt,
      ITM_OTH_WT: line.otherWt,
      ITM_NWT: line.netWt,
      ITM_GHT_WT: line.ghatWt,
      ITM_TOUCH: line.touch,
      ITM_WEST_PRC: line.westPct,
      ITM_FINE: line.fineWt,
      LBR_TYPE: line.labourType,
      LBR_RATE: line.labourRate,
      LBR_AMT: line.labourAmount,
      OTH_AMT: line.otherAmount,
      ITM_RATE: line.rate,
      ITM_AMT: line.itemAmount,
      ITM_MRP: line.mrp,
      TOT_AMT: line.totalAmount,
      TAX_PRC: line.taxPct,
      NET_AMT: line.netAmount,
      RATE_TYPE: line.rateType,
      IT_TYPE: line.itemType,
      PR_CODE: line.prCode,
      VCH_SRNO: line.tagVoucherSrNo,
      ISU_NO: line.sourceVoucherNo,
      ISU_LC_CODE: scope.lcCode,
      ISU_YRCD: line.sourceYear,
      ISU_DBCD: line.sourceBook,
      WITH_STOCK: 'Y',
      TAG_OTH_WT: line.otherWt,
      TAG_NWT: line.netWt,
      TAG_TOUCH: line.touch,
      TAG_WEST_PRC: line.westPct,
      TAG_FINE: line.fineWt,
      KR_OTH_WT: line.otherWt,
      KR_NWT: line.netWt,
      KR_GHT_PRC: line.ghatPct,
      KR_GHT_WT: line.ghatWt,
      KR_TOUCH: line.touch,
      KR_WEST_PRC: line.westPct,
      KR_FINE: line.fineWt,
      OLD_VCH_SRNO: line.tagVoucherSrNo,
      // TR_WH_SALE_RTN.cs:7336-7450 also stamps the rate-cut basis on the receipt row. The varchar
      // columns in the restored schema are written as text rather than coerced to numbers.
      LESS_WT: numOr0(line.lessWt),
      TAG_COST: numOr0(line.tagCost),
      LBR_PRC: numOr0(line.labourPct),
      LOT_NO: textOr(line.lotNo, 15),
      ADD_USER: textOr(identity.mainUser, 15),
      LESS_TOUCH: asNumberOrNull(line.lessTouch),
      ITM_OTH_RATE: asNumberOrNull(line.otherRate),
      ITM_OTH_FINE: asNumberOrNull(line.otherFine),
      CONV_RATE: asNumberOrNull(line.convRate),
      CONV_PRC: asNumberOrNull(line.convPct),
      SILVER_FINE: asNumberOrNull(line.silverFine),
      OLD_VCH_NO: null,
      NEW_VCH_NO: null,
      MAIN_USER: identity.mainUser || null,
    };
    // Every RATE_CUT_REC column assigned by the desktop grid is in :7336-7450.
    await insertRowTx(tx, 'RATE_CUT_REC', scope.tenantId, detail);

    for (let index = 0; index < line.components.length; index++) {
      const c = line.components[index]!;
      const component = {
        ...voucherKey(scope, identity.voucherNo),
        SR_NO: line.oldSrNo,
        ISR_NO: index + 1,
        VCH_DATE: identity.voucherDate,
        VCH_TYPE: policy.vchType,
        INOUT_TYPE: policy.inout,
        ENTRY_TYPE: 'P',
        BOOK_NAME: policy.mainBook,
        AC_CODE: party.code,
        TAG_NO: line.tagNo,
        VCH_SRNO: line.tagVoucherSrNo,
        IT_CODE: c.dmCode,
        DM_CODE: c.dmCode,
        DM_NAME: c.dmName,
        DM_COLOR: c.dmColor,
        DM_ORIGIN: c.dmOrigin,
        DM_REMARK: '',
        DM_SIZE: '',
        DM_SFNO: '',
        IT_PCS: c.pcs,
        IT_PCS_WT: 0,
        KR_WT: 0,
        KR_LESS_PRC: 0,
        IT_GWT: c.weight,
        IT_CON_PRC: 0,
        IT_RATE_TYPE: c.rateType,
        KR_RATE: 0,
        KR_AMT: 0,
        IT_RATE: c.rate,
        IT_AMT: c.amount,
        IT_LBR_RATE: c.labourRate,
        IT_LBR_AMT: c.labourAmount,
        IT_NET_AMT: c.netAmount,
        IT_CON_WT: 0,
        KR_CON_WT: 0,
        IT_TYPE: line.itemType,
        MAIN_USER: identity.mainUser || null,
      };
      // SL_IDTL mapping is TR_WH_SALE_RTN.cs:7462-7508.
      await insertRowTx(tx, 'SL_IDTL', scope.tenantId, component);
      if (line.tagNo !== 'N') {
        // BAR_IDTL re-tag projection is :7674-7736, ENTRY_TYPE='S'.
        await insertRowTx(tx, 'BAR_IDTL', scope.tenantId, { ...component, ENTRY_TYPE: 'S' });
      }
    }

    if (line.tagNo !== 'N') {
      // BAR_DETL re-admits returned tagged goods; exact assignment block :7544-7664.
      await insertRowTx(tx, 'BAR_DETL', scope.tenantId, {
        ...voucherKey(scope, identity.voucherNo),
        SR_NO: line.srNo,
        OLD_SRNO: line.oldSrNo,
        HD_VCH_NO: identity.hiddenVoucherNo,
        VCH_DATE: identity.voucherDate,
        VCH_TIME: identity.voucherTime,
        STK_DATE: identity.voucherDate.toISOString().slice(0, 10),
        VCH_TYPE: policy.vchType,
        INOUT_TYPE: policy.inout,
        ENTRY_TYPE: 'I',
        BOOK_NAME: policy.mainBook,
        AC_CODE: party.code,
        IT_CODE: line.itemCode,
        TAG_NO: line.tagNo,
        LOT_NO: '',
        TBL_CODE: line.tableCode,
        DESIGN_NO: line.designNo,
        ITM_SIZE: line.size,
        BAG_WT: 0,
        ITM_PCS: line.pcs,
        ITM_GWT: line.grossWt,
        ITM_OTH_WT: line.otherWt,
        ITM_NWT: line.netWt,
        ITM_GHT_PRC: 0,
        ITM_GHT_WT: 0,
        ITM_TOUCH: line.touch,
        ITM_WEST_PRC: line.westPct,
        ITM_FINE: line.fineWt,
        LBR_TYPE: line.labourType,
        LBR_RATE: line.labourRate,
        LBR_AMT: line.labourAmount,
        OTH_AMT: line.otherAmount,
        ITM_RATE: line.rate,
        ITM_AMT: line.itemAmount,
        TAG_COST: line.mrp,
        ITM_MRP: line.mrp,
        KR_OTH_WT: line.otherWt,
        KR_NET_WT: line.netWt,
        KR_GHT_PRC: Number(line.ghatPct) || 0,
        KR_GHT_WT: Number(line.ghatWt) || 0,
        KR_TOUCH: line.touch,
        KR_WEST_PRC: line.westPct,
        KR_FINE: line.fineWt,
        TAG_SRNO: Number(line.srNo) || 0,
        VCH_SRNO: line.tagVoucherSrNo,
        RATE_TYPE: line.rateType,
        IT_TYPE: line.itemType,
        TAG_TYPE: line.itemType,
        PR_CODE: line.prCode,
        APR_ISU: 'N',
        MAIN_USER: identity.mainUser || null,
        DATA_TYPE: 'A',
        DATA_TRFR: 'N',
      });
    }

    // Ac_Stock.cs:182-186: loose rows are SR_NO=1, tagged rows SR_NO=2; both are TR_TYPE='I',
    // ITM_SIGN='+', VCH_TYPE=BOOK_SNAME and BOOK_NAME=MAIN_BOOK.
    await insertRowTx(tx, 'MAIN_STOCK', scope.tenantId, {
      ...voucherKey(scope, identity.voucherNo),
      SR_NO: line.tagNo === 'N' ? 1 : 2,
      ISR_NO: line.srNo,
      VCH_DATE: identity.voucherDate,
      STK_DATE: identity.voucherDate.toISOString().slice(0, 10),
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.mainBook,
      AC_CODE: party.code,
      IT_CODE: line.itemCode,
      TAG_NO: line.tagNo,
      VCH_SRNO: line.tagVoucherSrNo,
      TBL_CODE: line.tableCode,
      TR_TYPE: 'I',
      ITM_SIGN: '+',
      ITM_QTY: 1,
      ITM_PCS: line.pcs,
      ITM_GWT: line.grossWt,
      ITM_NWT: line.netWt,
      ITM_TOUCH: line.touch,
      ITM_WEST: line.westPct,
      ITM_FINE: line.fineWt,
      ITM_RATE: line.rate,
      ITM_AMT: line.itemAmount,
      LBR_RATE: line.labourRate,
      LBR_AMT: line.labourAmount,
      OTH_AMT: line.otherAmount,
      ITM_MRP: 0,
      NET_AMT: line.netAmount,
      KR_NWT: line.netWt,
      KR_TOUCH: line.touch,
      KR_WEST: line.westPct,
      KR_FINE: line.fineWt,
      KR_LBR_AMT: line.tagNo === 'N' ? 0 : line.labourAmount,
      KR_OTH_AMT: line.tagNo === 'N' ? 0 : line.otherAmount,
      KR_COST: line.tagNo === 'N' ? 0 : line.mrp,
      EMP_CODE: employee,
      ENTRY_TIME: identity.voucherTime,
      MAIN_USER: identity.mainUser || null,
      DATA_TYPE: policy.dataType,
      DESIGN_NO: line.designNo,
      ITM_SIZE: line.size,
      ITM_DESC: line.remark,
      GHT_PRC: 0,
      ITM_LOT: '',
      ITM_DISC: 0,
    });
  }

  if (lines.some((line) => line.tagNo !== 'N')) {
    // BAR_DATA header mapping is TR_WH_SALE_RTN.cs:7514-7534. TAG_SET is read for numbering/help
    // (:5576,:5605) but this form never inserts it, so no TAG_SET row is invented.
    await insertRowTx(tx, 'BAR_DATA', scope.tenantId, {
      ...voucherKey(scope, identity.voucherNo),
      HD_VCH_NO: identity.hiddenVoucherNo,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      STK_IT_CODE: '',
      EMP_CODE: employee,
      VCH_DESC: text(input.description).slice(0, 150),
      DATA_TRFR: 'N',
      MAIN_USER: identity.mainUser || null,
    });
  }

  const prefix = `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}`;
  const ledger: Record<string, unknown>[] = [];
  const addPair = (amount: number, control: string, suffix: string) => {
    if (!amount) return;
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}${suffix}`),
      AC_CODE: party.code,
      LD_CODE: control,
      CR_AMT: 0,
      DR_AMT: amount,
      PARTY_AC_CODE: party.code,
    });
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}${Number(suffix) + 1}`),
      AC_CODE: control,
      LD_CODE: party.code,
      CR_AMT: amount,
      DR_AMT: 0,
    });
  };
  // Ac_Ledr.cs:780-825: item, labour, other, cheque, card, cash and kasar configured legs.
  addPair(itemTotal, itemAccount, itemType === 'G' ? '01' : '04');
  addPair(labourTotal, labourAccount, '07');
  addPair(otherTotal, otherAccount, '09');
  addPair(chequeAmount, bankAccount, '15');
  addPair(cardAmount, cardAccount, '17');
  addPair(cashAmount, cashAccount, '19');
  if (kasarAmount) {
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}21`),
      AC_CODE: party.code,
      LD_CODE: labourAccount,
      CR_AMT: kasarAmount,
      DR_AMT: 0,
      PARTY_AC_CODE: party.code,
    });
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}22`),
      AC_CODE: labourAccount,
      LD_CODE: party.code,
      CR_AMT: 0,
      DR_AMT: kasarAmount,
    });
  }
  if (totalFine) {
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}11`),
      AC_CODE: party.code,
      LD_CODE: itemAccount,
      CR_AMT: 0,
      DR_AMT: 0,
      IT_TYPE: itemType,
      SIGN: '+',
      FINE_WT: totalFine,
      PARTY_AC_CODE: party.code,
    });
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}12`),
      AC_CODE: itemAccount,
      LD_CODE: party.code,
      CR_AMT: 0,
      DR_AMT: 0,
      IT_TYPE: itemType,
      SIGN: '-',
      FINE_WT: totalFine,
    });
  }
  assertBalanced(ledger);
  const fineBalance = weight(
    ledger.reduce(
      (sum, row) =>
        sum +
        (text(row.SIGN) === '+' ? n(row.FINE_WT) : text(row.SIGN) === '-' ? -n(row.FINE_WT) : 0),
      0,
    ),
  );
  if (fineBalance !== 0)
    throw new WholesaleSaleReturnValidationError('wholesale return fine ledger is unbalanced');
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);

  // Ac_Rojmel.cs:312-333: item/fine, bank, card, kasar and labour/other row families.
  const rojmelBase = (key: string) => ({
    ...voucherKey(scope, identity.voucherNo),
    LEDR_KEY: `${prefix}${key}`,
    VCH_DATE: identity.voucherDate,
    VCH_TYPE: policy.vchType,
    BOOK_NAME: policy.mainBook,
    AC_CODE: '',
    LD_CODE: '',
    CR_AMT: 0,
    DR_AMT: 0,
    AC_NAME: '',
    IT_TYPE: 'A',
    SIGN: '',
    ITM_PCS: 0,
    ITM_GWT: 0,
    ITM_NWT: 0,
    ITM_TOUCH: 0,
    ITM_WEST: 0,
    ITM_FINE: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    NET_AMT: 0,
    IT_DESC: text(input.description),
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: policy.dataType,
  });
  const addRojmel = async (key: string, row: Record<string, unknown>) =>
    insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, { ...rojmelBase(key), ...row });
  const itemPrefix = itemType === 'G' ? '01' : '04';
  if (totalFine || billOutstanding) {
    await addRojmel(itemPrefix, {
      AC_CODE: party.code,
      LD_CODE: itemAccount,
      CR_AMT: itemType === 'G' ? billOutstanding : 0,
      AC_NAME: `${policy.vchType} - ${party.name}`,
      IT_TYPE: itemType,
      SIGN: '-',
      ITM_FINE: totalFine,
    });
  }
  if (itemTotal) {
    await addRojmel(itemType === 'G' ? '02' : '05', {
      AC_CODE: itemAccount,
      LD_CODE: party.code,
      DR_AMT: itemTotal,
      AC_NAME: `${policy.vchType} - ${party.name}`,
    });
  }
  for (const line of lines.filter((value) => value.itemAmount === 0 && value.fineWt !== 0)) {
    await addRojmel(`${itemType === 'G' ? '03' : '06'}${line.srNo}`, {
      AC_CODE: party.code,
      LD_CODE: itemAccount,
      AC_NAME: party.name,
      IT_TYPE: line.itemType,
      SIGN: '+',
      ITM_PCS: line.pcs,
      ITM_GWT: line.grossWt,
      ITM_NWT: line.netWt,
      ITM_TOUCH: line.touch,
      ITM_WEST: line.westPct,
      ITM_FINE: line.fineWt,
      IT_DESC: line.remark,
      IT_CODE: line.itemCode,
    });
  }
  if (chequeAmount) {
    await addRojmel('07', {
      AC_CODE: bankAccount,
      LD_CODE: party.code,
      CR_AMT: chequeAmount,
    });
  }
  if (cardAmount) {
    await addRojmel('08', {
      AC_CODE: cardAccount,
      LD_CODE: party.code,
      CR_AMT: cardAmount,
    });
  }
  if (kasarAmount) {
    await addRojmel('09', {
      AC_CODE: kasarRojmelAccount,
      LD_CODE: party.code,
      CR_AMT: kasarAmount,
      AC_NAME: `KSR - ${party.name}`,
    });
  }
  if (labourTotal || otherTotal) {
    await addRojmel('10', {
      AC_CODE: labourAccount,
      LD_CODE: party.code,
      DR_AMT: money(labourTotal + otherTotal),
      AC_NAME: `LBR - ${party.name}`,
    });
  }
}

const writeTables = [
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'DM_DATA',
  'BAR_IDTL',
  'BAR_DETL',
  'BAR_DATA',
  'SL_IDTL',
  'RATE_CUT_REC',
  'TAX_DATA',
  'RATE_CUT_DATA',
] as const;

async function saveTx(tx: any, input: WholesaleSaleReturnInput, requestedVoucherNo?: string) {
  const scope = completeFinanceScope(input.scope);
  const policy = await resolveBookTx(tx, scope);
  const requested = businessDate(input.vchDate);
  // Exact desktop fiscal/lock messages are at :7152 and :7158; web checks fail closed.
  await assertFiscalDateTx(tx, scope, requested.iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: requested.date }] },
  });
  await accountTx(tx, scope, input.partyCode, 'party');
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'RATE_CUT_DATA',
      scope,
      requestedVoucherNo,
      requestedDate: requested.date,
    });
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    const lines = await resolveLinesTx(tx, input, edited.identity.voucherNo);
    await assertReplacementSafeTx(tx, scope, edited.identity.voucherNo, lines);
    // Existing load preserves HD_VCH_NO (:6713), VCH_TIME (:6711) and MAIN_USER (:6771).
    // Edit rewrites the same write set (:7213-7762) and contains no DELETE_DATA insert.
    await replaceWriteSetTx(
      tx,
      scope,
      edited.identity.voucherNo,
      edited.identity.hiddenVoucherNo,
      writeTables,
    );
    await writeTx(tx, input, policy, edited.identity, lines);
    return {
      voucherNo: edited.identity.voucherNo,
      hiddenVoucherNo: edited.identity.hiddenVoucherNo,
      created: false,
      lines: lines.length,
    };
  }
  const identity = await createIdentityTx(tx, scope, requested.date, input.mainUser);
  const lines = await resolveLinesTx(tx, input);
  await writeTx(tx, input, policy, identity, lines);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created: true,
    lines: lines.length,
  };
}

export async function saveWholesaleSaleReturn(
  prisma: any,
  input: WholesaleSaleReturnInput,
  requestedVoucherNo?: string,
) {
  return withTenant(prisma, input.scope.tenantId, (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getWholesaleSaleReturn(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT h.*,h."VCH_DATE"::text "VCH_DAY",to_char(h."VCH_TIME",'HH24:MI:SS.MS') "VCH_CLOCK"
        FROM "RATE_CUT_DATA" h WHERE h.tenant_id=$1 AND h."CO_CODE"=$2 AND h."LC_CODE"=$3
         AND h."CO_YEAR"=$4 AND h."CO_BOOK"=$5 AND h."VCH_NO"=$6 ORDER BY h.row_id LIMIT 2`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (headers.length !== 1) {
      throw new WholesaleSaleReturnValidationError(
        headers.length
          ? `wholesale sale return is ambiguous: ${voucherNo}`
          : `wholesale sale return not found: ${voucherNo}`,
      );
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d.*,m."IT_NAME" FROM "RATE_CUT_REC" d LEFT JOIN "ITEM_MAST" m
        ON m.tenant_id=d.tenant_id AND m."CO_CODE"=d."CO_CODE" AND m."IT_CODE"=d."IT_CODE"
       WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
        AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO",d.row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const h = headers[0]!;
    return {
      voucherNo,
      vchDate: text(h.VCH_DAY).slice(0, 10),
      voucherTime: text(h.VCH_CLOCK),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      partyCode: text(h.AC_CODE),
      partyName: text(h.AC_NAME),
      billNo: text(h.BILL_NO),
      employeeCode: text(h.EMP_CODE),
      description: text(h.VCH_DESC),
      cashAmount: n(h.SL_CASH_AMT),
      chequeAmount: n(h.SL_CHQ_AMT),
      cardAmount: n(h.SL_CARD_AMT),
      kasarAmount: n(h.SL_KASAR_AMT),
      billOutstanding: n(h.SL_BILL_OS),
      bankAccount: text(h.BANK_AC),
      cardAccount: text(h.CARD_AC),
      chequeNo: text(h.CHQ_NO),
      lines: rows.map((row) => ({
        srNo: n(row.SR_NO),
        tagNo: text(row.TAG_NO) === 'N' ? '' : text(row.TAG_NO),
        tagVoucherSrNo: n(row.VCH_SRNO),
        itemCode: text(row.IT_CODE),
        itemName: text(row.IT_NAME),
        tableCode: text(row.TBL_CODE),
        designNo: text(row.DESIGN_NO),
        size: text(row.ITM_SIZE),
        remark: text(row.ITM_REMARK),
        pcs: n(row.ITM_PCS),
        grossWt: n(row.ITM_GWT),
        otherWt: n(row.ITM_OTH_WT),
        netWt: n(row.ITM_NWT),
        touch: n(row.ITM_TOUCH),
        westPct: n(row.ITM_WEST_PRC),
        fineWt: n(row.ITM_FINE),
        rateType: text(row.RATE_TYPE),
        rate: n(row.ITM_RATE),
        itemAmount: n(row.ITM_AMT),
        labourType: text(row.LBR_TYPE),
        labourRate: n(row.LBR_RATE),
        labourAmount: n(row.LBR_AMT),
        otherAmount: n(row.OTH_AMT),
        taxPct: n(row.TAX_PRC),
        netAmount: n(row.NET_AMT),
      })),
    };
  });
}

export async function deleteWholesaleSaleReturn(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
): Promise<{ reversed: true; auditedRows: 1 }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope);
    const edited = await editIdentityTx(tx, {
      table: 'RATE_CUT_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
      extraColumns: [
        'AC_CODE',
        'AC_NAME',
        'SL_NET_AMT',
        'PR_NET_AMT',
        'IT_TYPE',
        'TOT_FINE_DR',
        'TOT_FINE_CR',
        'VCH_DESC',
      ],
    });
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    await assertReplacementSafeTx(tx, scope, voucherNo, []);
    const header: Record<string, unknown> = {
      ...edited.persisted,
      VCH_TIME: voucherTimestamp(
        new Date(`${persistedIso}T00:00:00.000Z`),
        edited.persisted.VCH_CLOCK,
      ),
    };
    // Exact single DELETE_DATA mapping is TR_WH_SALE_RTN.cs:7924:
    // DR=SL_NET_AMT, CR=PR_NET_AMT, FINE_TYPE=IT_TYPE, fine DR/CR=TOT_FINE_DR/CR,
    // configured BOOK_SNAME and first 20 chars of BOOK_NAME, description first 150 chars.
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: policy.configuredName.slice(0, 20), shortName: policy.vchType },
      header,
      deleteUser,
      rows: [
        {
          srNo: 0,
          acCode: header.AC_CODE,
          acName: header.AC_NAME,
          valueDr: n(header.SL_NET_AMT),
          valueCr: n(header.PR_NET_AMT),
          fineType: text(header.IT_TYPE),
          fineDr: n(header.TOT_FINE_DR),
          fineCr: n(header.TOT_FINE_CR),
          description: text(header.VCH_DESC).slice(0, 150),
        },
      ],
    });
    // Desktop delete removes TEMP_BOOK_DATA plus :7927-7938 write set; no migration/table guess.
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, writeTables);
    return { reversed: true, auditedRows: 1 };
  });
}
