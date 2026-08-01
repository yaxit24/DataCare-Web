import { withTenant } from '@datacare/db';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import {
  resolveBookAccountTx,
  resolveBookPolicyTx,
  type BookPolicy,
} from '../shared/bookPolicy.js';
import { fineFor } from '../shared/finePolicy.js';
import { assertFiscalDateTx, voucherTimestamp } from '../vouchers/lifecycle.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
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

export class VpParcelValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'VpParcelValidationError';
  }
}

export interface VpParcelComponentInput {
  dmCode: string;
  pcs?: number;
  weight?: number;
  rateType?: string;
  rate?: number;
  labourRate?: number;
}

export interface VpParcelLineInput {
  tagNo?: string;
  tagVoucherSrNo?: number;
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
  rateType?: string;
  rate?: number;
  mrp?: number;
  labourType?: string;
  labourRate?: number;
  labourPct?: number;
  otherAmount?: number;
  // Desktop RATE_CUT_ISU_REC line columns (TR_WH_SALE.cs:13683).
  itemColor?: string;
  itemStyle?: string;
  itemLot?: string;
  huid?: string; // HM_ID
  hallmarkId2?: string;
  hallmarkId3?: string;
  hallmarkId4?: string;
  hallmarkIdWt?: number;
  hallmarkId2Wt?: number;
  hallmarkId3Wt?: number;
  hallmarkId4Wt?: number;
  imageId?: string;
  designImageId?: string;
  components?: VpParcelComponentInput[];
}

export interface VpParcelInput {
  scope: VoucherScope;
  vchDate: string | Date;
  partyCode: string;
  angdiyaCode?: string;
  billNo?: string;
  employeeCode?: string;
  description?: string;
  lines: VpParcelLineInput[];
  mainUser?: string;
}

type VpParcelPolicy = BookPolicy & { configuredName: string; dataType: string };
type ResolvedComponent = {
  dmCode: string;
  dmName: string;
  dmOrigin: string;
  dmRemark: string;
  dmSize: string;
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
type ResolvedLine = {
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
  bagWt: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  ghatWt: number;
  touch: number;
  westPct: number;
  fineWt: number;
  rateType: string;
  rate: number;
  itemAmount: number;
  mrp: number;
  labourPct: number;
  labourType: string;
  labourRate: number;
  labourAmount: number;
  otherAmount: number;
  totalAmount: number;
  netAmount: number;
  prCode: string;
  // Desktop RATE_CUT_ISU_REC line columns (TR_WH_SALE.cs:13683). Tagged lines inherit them from
  // the source tag row when present, exactly as weights and rates already do.
  itemColor: string | null;
  itemStyle: string | null;
  itemLot: string | null;
  huid: string | null;
  hallmarkId2: string | null;
  hallmarkId3: string | null;
  hallmarkId4: string | null;
  hallmarkIdWt: number;
  hallmarkId2Wt: number;
  hallmarkId3Wt: number;
  hallmarkId4Wt: number;
  imageId: string | null;
  designImageId: string | null;
  components: ResolvedComponent[];
};

const n = (value: unknown): number => Number(value ?? 0) || 0;
const money = (value: unknown): number => Math.round((n(value) + Number.EPSILON) * 100) / 100;
const weight = (value: unknown): number => Math.round((n(value) + Number.EPSILON) * 1000) / 1000;

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new VpParcelValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new VpParcelValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<VpParcelPolicy> {
  // Desktop copies the selected book's configured display/main/short/direction values into
  // FormName/FormMainBook/FormBookSname/FormBookInOut at TR_VP.cs:5009-5014. Detail rows then
  // persist BOOK_SNAME as VCH_TYPE, BOOK_INOUT as INOUT_TYPE and MAIN_BOOK as BOOK_NAME at
  // TR_VP.cs:5702-5705. The shared policy therefore fails closed unless this is VP PARCEL / O.
  const policy = await resolveBookPolicyTx(tx, scope, 'VP PARCEL');
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","DATA_TYPE","MAIN_BOOK","BOOK_INOUT" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (
    rows.length !== 1 ||
    text(rows[0]?.MAIN_BOOK).toUpperCase() !== 'VP PARCEL' ||
    text(rows[0]?.BOOK_INOUT).toUpperCase() !== 'O'
  ) {
    throw new VpParcelValidationError('VP parcel book configuration is ambiguous');
  }
  return {
    ...policy,
    configuredName: text(rows[0]!.BOOK_NAME) || policy.mainBook,
    dataType: text(rows[0]!.DATA_TYPE) || 'A',
  };
}

async function accountTx(
  tx: any,
  scope: VoucherScope,
  codeInput: unknown,
  label = 'account',
): Promise<{ code: string; name: string }> {
  const code = text(codeInput);
  if (!code) throw new VpParcelValidationError(`${label} is required`);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1) {
    throw new VpParcelValidationError(
      rows.length ? `${label} is ambiguous: ${code}` : `${label} not found: ${code}`,
    );
  }
  return { code: text(rows[0]!.AC_CODE), name: text(rows[0]!.AC_NAME) };
}

async function employeeTx(tx: any, input: VpParcelInput): Promise<string> {
  const code = text(input.employeeCode);
  if (!code) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    code,
  );
  if (rows.length !== 1) throw new VpParcelValidationError(`employee not found: ${code}`);
  return code;
}

async function itemTx(
  tx: any,
  scope: VoucherScope,
  codeInput: unknown,
): Promise<Record<string, unknown> & { itemType: 'G' | 'S' }> {
  const code = text(codeInput);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE","LBR_PRC","IT_TOUCH",
            "IT_WEST","IT_LBR_RATE","IT_GHT_PRC","OTH_DETL_POSTING"
       FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1) {
    throw new VpParcelValidationError(
      rows.length ? `item is ambiguous: ${code}` : `item not found: ${code}`,
    );
  }
  const itemType = text(rows[0]!.IT_TYPE).toUpperCase();
  if (itemType !== 'G' && itemType !== 'S') {
    throw new VpParcelValidationError(`item ${code} has invalid metal type`);
  }
  return { ...rows[0]!, itemType: itemType as 'G' | 'S' };
}

async function componentsFromInputTx(
  tx: any,
  scope: VoucherScope,
  values: VpParcelComponentInput[],
): Promise<ResolvedComponent[]> {
  const out: ResolvedComponent[] = [];
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
      throw new VpParcelValidationError(
        rows.length ? `component is ambiguous: ${code}` : `component not found: ${code}`,
      );
    }
    const pcs = n(value.pcs);
    const componentWeight = weight(value.weight);
    const rate = money(value.rate);
    const amount = money(componentWeight * rate);
    const labourRate = money(value.labourRate);
    const labourAmount = money(pcs * labourRate);
    out.push({
      dmCode: code,
      dmName: text(rows[0]!.DM_NAME),
      dmOrigin: text(rows[0]!.DM_SHAPE),
      dmRemark: '',
      dmSize: '',
      dmColor: text(rows[0]!.DM_COLOR),
      pcs,
      weight: componentWeight,
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

async function tagSourceTx(
  tx: any,
  scope: CompleteFinanceScope,
  line: VpParcelLineInput,
  currentVoucherNo?: string,
): Promise<Record<string, unknown>> {
  const tagNo = text(line.tagNo);
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `tag-issue|${scope.coCode}|${scope.lcCode}|${tagNo}`,
  );
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT b.* FROM "BAR_DETL" b
      WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3 AND b."TAG_NO"=$4
        AND ($5::numeric=0 OR coalesce(b."VCH_SRNO",0)=$5::numeric)
      ORDER BY b."VCH_TIME" DESC NULLS LAST,b.row_id DESC LIMIT 2 FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    n(line.tagVoucherSrNo),
  );
  if (rows.length !== 1) {
    throw new VpParcelValidationError(
      rows.length ? `tag identity is ambiguous: ${tagNo}` : `tag not found: ${tagNo}`,
    );
  }
  const source = rows[0]!;
  const movements: Array<{ balance: unknown; other_issues: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("VCH_SRNO",1)
                             ELSE -coalesce("VCH_SRNO",1) END),0)::float AS balance,
            count(*) FILTER (WHERE "ITM_SIGN"='-' AND NOT
              (coalesce("CO_YEAR"::text,'')=$7 AND coalesce("CO_BOOK"::text,'')=$8
               AND coalesce("VCH_NO"::text,'')=coalesce($9,'')))::int AS other_issues
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
        AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    source.VCH_SRNO ?? 0,
    source.IT_CODE ?? '',
    scope.coYear,
    scope.coBook,
    currentVoucherNo ?? '',
  );
  if (n(movements[0]?.other_issues) > 0) {
    throw new VpParcelValidationError(`tag ${tagNo} has already been consumed by another voucher`);
  }
  if (!currentVoucherNo && n(movements[0]?.balance) <= 0) {
    throw new VpParcelValidationError(`tag is not available: ${tagNo}`);
  }
  return source;
}

async function tagComponentsTx(
  tx: any,
  scope: CompleteFinanceScope,
  source: Record<string, unknown>,
): Promise<ResolvedComponent[]> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT i.* FROM "BAR_IDTL" i
      WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."LC_CODE"=$3 AND i."TAG_NO"=$4
        AND coalesce(i."VCH_SRNO",0)=coalesce($5::numeric,0)
      ORDER BY i."ISR_NO",i.row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    source.TAG_NO,
    source.VCH_SRNO ?? 0,
  );
  return rows.map((row) => ({
    dmCode: text(row.DM_CODE),
    dmName: text(row.DM_NAME),
    dmOrigin: text(row.DM_ORIGIN),
    dmRemark: text(row.DM_REMARK),
    dmSize: text(row.DM_SIZE),
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

function itemAmountFor(rateType: string, pcs: number, fineWt: number, rate: number): number {
  // TR_VP.cs:4080-4092: P=pieces*rate, 1=fine*(rate/10), K=fine*(rate/1000),
  // otherwise fine*rate; desktop rounds these branches to whole currency units.
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

function labourAmountFor(
  labourType: string,
  pcs: number,
  grossWt: number,
  netWt: number,
  ghatWt: number,
  rate: number,
): number {
  // TR_VP.cs:4130-4149: P uses pieces, N uses net (the desktop company-specific ghat switch is
  // unavailable on the request and is not guessed), K uses (net+ghat)*rate/1000, default uses GWT.
  if (labourType === 'P') return money(Math.round(pcs * rate));
  if (labourType === 'N') return money(Math.round(netWt * rate));
  if (labourType === 'K') return money((netWt + ghatWt) * (rate / 1000));
  return money(Math.round(grossWt * rate));
}

async function resolveLinesTx(
  tx: any,
  input: VpParcelInput,
  currentVoucherNo?: string,
): Promise<ResolvedLine[]> {
  const scope = completeFinanceScope(input.scope);
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new VpParcelValidationError('VP parcel requires at least one item line');
  }
  const resolved: ResolvedLine[] = [];
  for (let index = 0; index < input.lines.length; index++) {
    const line = input.lines[index]!;
    const tagged = text(line.tagNo) && text(line.tagNo).toUpperCase() !== 'N';
    const source = tagged ? await tagSourceTx(tx, scope, line, currentVoucherNo) : undefined;
    const item = await itemTx(tx, scope, source?.IT_CODE ?? line.itemCode);
    const grossWt = weight(source?.ITM_GWT ?? line.grossWt);
    const otherWt = weight(source?.ITM_OTH_WT ?? line.otherWt);
    const netWt = weight(source?.ITM_NWT ?? grossWt - otherWt);
    const ghatPct = n(source?.ITM_GHT_PRC ?? line.ghatPct ?? item.IT_GHT_PRC);
    const ghatWt = weight(source?.ITM_GHT_WT ?? (netWt * ghatPct) / 100);
    const touch = n(source?.ITM_TOUCH ?? line.touch ?? item.IT_TOUCH);
    const westPct = n(source?.ITM_WEST_PRC ?? line.westPct ?? item.IT_WEST);
    // This is the existing sale policy: TR_VP.cs:3992-4040 computes (NWT+GHT)*(touch+west)/100,
    // with NWT+GHT when both percentages are zero. No VP-specific policy differs.
    const fineWt = fineFor('sale', { netWt, ghtWt: ghatWt, touch, westPct });
    const pcs = n(source?.ITM_PCS ?? line.pcs);
    const rateType = text(line.rateType || source?.RATE_TYPE || item.RATE_TYPE);
    const rate = money(line.rate ?? source?.ITM_RATE);
    const itemAmount = itemAmountFor(rateType, pcs, fineWt, rate);
    const labourType = text(line.labourType || source?.LBR_TYPE || 'G');
    const labourPct = n(line.labourPct ?? source?.LBR_PRC ?? item.LBR_PRC);
    const labourRate = money(
      line.labourRate ?? source?.LBR_RATE ?? item.IT_LBR_RATE ?? (rate * labourPct) / 100,
    );
    const labourAmount = labourAmountFor(labourType, pcs, grossWt, netWt, ghatWt, labourRate);
    const otherAmount = money(line.otherAmount ?? source?.OTH_AMT);
    const mrp = money(line.mrp ?? source?.ITM_MRP);
    // TR_VP.cs:4188-4199: MRP replaces item/labour/other; otherwise TOT_AMT is their sum and,
    // with zero tax (the web's deliberately narrow contract), NET_AMT equals TOT_AMT.
    const totalAmount = mrp !== 0 ? mrp : money(itemAmount + labourAmount + otherAmount);
    const components = tagged
      ? await tagComponentsTx(tx, scope, source!)
      : await componentsFromInputTx(tx, scope, line.components ?? []);
    resolved.push({
      srNo: index + 1,
      oldSrNo: index + 1,
      tagNo: tagged ? text(source!.TAG_NO) : 'N',
      tagVoucherSrNo: tagged ? n(source!.VCH_SRNO) : 0,
      itemCode: text(item.IT_CODE),
      itemName: text(item.IT_NAME),
      itemType: item.itemType,
      tableCode: text(source?.TBL_CODE ?? line.tableCode) || '001',
      designNo: text(source?.DESIGN_NO ?? line.designNo),
      size: text(source?.ITM_SIZE ?? line.size),
      remark: text(line.remark || source?.ITM_REMARK).slice(0, 150),
      pcs,
      bagWt: weight(source?.BAG_WT),
      grossWt,
      otherWt,
      netWt,
      ghatWt,
      touch,
      westPct,
      fineWt,
      rateType,
      rate,
      itemAmount,
      mrp,
      labourPct,
      labourType,
      labourRate,
      labourAmount,
      otherAmount,
      totalAmount,
      netAmount: totalAmount,
      prCode: text(source?.PR_CODE ?? item.PR_CODE),
      itemColor: text(source?.ITM_COLOR ?? line.itemColor) || null,
      itemStyle: text(source?.ITM_STYLE ?? line.itemStyle) || null,
      itemLot: text(source?.ITM_LOT ?? line.itemLot) || null,
      huid: text(source?.HM_ID ?? line.huid) || null,
      hallmarkId2: text(source?.HM_ID2 ?? line.hallmarkId2) || null,
      hallmarkId3: text(source?.HM_ID3 ?? line.hallmarkId3) || null,
      hallmarkId4: text(source?.HM_ID4 ?? line.hallmarkId4) || null,
      hallmarkIdWt: n(source?.HM_ID_WT ?? line.hallmarkIdWt),
      hallmarkId2Wt: n(source?.HM_ID2_WT ?? line.hallmarkId2Wt),
      hallmarkId3Wt: n(source?.HM_ID3_WT ?? line.hallmarkId3Wt),
      hallmarkId4Wt: n(source?.HM_ID4_WT ?? line.hallmarkId4Wt),
      imageId: text(source?.IMAGE_ID ?? line.imageId) || null,
      designImageId: text(source?.DESIGN_IMG_ID ?? line.designImageId) || null,
      components,
    });
  }
  const types = new Set(resolved.map((line) => line.itemType));
  if (types.size !== 1) {
    throw new VpParcelValidationError('one VP parcel cannot mix gold and silver item types');
  }
  return resolved;
}

async function assertStockReplacementSafeTx(
  tx: any,
  scope: CompleteFinanceScope,
  voucherNo: string | undefined,
  lines: ResolvedLine[],
): Promise<void> {
  const loose = lines.filter((line) => line.tagNo === 'N');
  const itemCodes = [...new Set(loose.map((line) => line.itemCode))];
  for (const itemCode of itemCodes.sort()) {
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `loose-stock|${scope.coCode}|${scope.lcCode}|${itemCode}|`,
    );
  }
  if (!itemCodes.length) return;
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE",
       coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_PCS",0) ELSE -coalesce("ITM_PCS",0) END),0)::float pcs,
       coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_GWT",0) ELSE -coalesce("ITM_GWT",0) END),0)::float gwt,
       coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_NWT",0) ELSE -coalesce("ITM_NWT",0) END),0)::float nwt,
       coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_FINE",0) ELSE -coalesce("ITM_FINE",0) END),0)::float fine
     FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
       AND "IT_CODE"::text=ANY($4::text[])
       AND NOT (coalesce("CO_YEAR"::text,'')=$5 AND coalesce("CO_BOOK"::text,'')=$6
                AND coalesce("VCH_NO"::text,'')=coalesce($7,'')) GROUP BY "IT_CODE"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    itemCodes,
    scope.coYear,
    scope.coBook,
    voucherNo ?? '',
  );
  const balances = new Map(
    rows.map((row) => [
      text(row.IT_CODE),
      { pcs: n(row.pcs), gwt: n(row.gwt), nwt: n(row.nwt), fine: n(row.fine) },
    ]),
  );
  for (const line of loose) {
    const balance = balances.get(line.itemCode) ?? { pcs: 0, gwt: 0, nwt: 0, fine: 0 };
    balance.pcs -= line.pcs;
    balance.gwt -= line.grossWt;
    balance.nwt -= line.netWt;
    balance.fine -= line.fineWt;
    balances.set(line.itemCode, balance);
  }
  for (const [itemCode, balance] of balances) {
    if (Object.values(balance).some((value) => value < -0.0005)) {
      throw new VpParcelValidationError(
        `item ${itemCode} has already been consumed; this edit would strand negative stock`,
      );
    }
  }
}

function ledgerBase(
  scope: CompleteFinanceScope,
  policy: VpParcelPolicy,
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

function rojmelBase(
  scope: CompleteFinanceScope,
  policy: VpParcelPolicy,
  identity: VoucherIdentity,
  key: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    LEDR_KEY: key,
    VCH_DATE: identity.voucherDate,
    VCH_TYPE: policy.vchType,
    BOOK_NAME: policy.mainBook,
    CR_AMT: 0,
    DR_AMT: 0,
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
    IT_DESC: '',
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: policy.dataType,
  };
}

async function writeTx(
  tx: any,
  input: VpParcelInput,
  policy: VpParcelPolicy,
  identity: VoucherIdentity,
  lines: ResolvedLine[],
): Promise<void> {
  const scope = completeFinanceScope(input.scope);
  const party = await accountTx(tx, scope, input.partyCode, 'party');
  const angdiya = await accountTx(tx, scope, input.angdiyaCode || input.partyCode, 'angdiya');
  const employeeCode = await employeeTx(tx, input);
  const itemType = lines[0]!.itemType;
  const itemAccount = await resolveBookAccountTx(tx, scope, policy, itemType === 'G' ? 1 : 8);
  await accountTx(tx, scope, itemAccount, 'configured item account');
  const itemAmount = money(lines.reduce((sum, line) => sum + line.itemAmount, 0));
  const labourAmount = money(
    lines.reduce((sum, line) => sum + line.labourAmount + line.otherAmount, 0),
  );
  // TR_VP.cs:4188-4199 replaces a line's item/labour/other total with MRP. Preserve the
  // component header totals, but derive the payable total and balanced ledger allocations from
  // each resolved NET_AMT instead of incorrectly re-summing the replaced components.
  const totalAmount = money(lines.reduce((sum, line) => sum + line.netAmount, 0));
  const itemLedgerAmount = money(
    lines.reduce((sum, line) => sum + (line.mrp !== 0 ? line.netAmount : line.itemAmount), 0),
  );
  const labourLedgerAmount = money(
    lines.reduce(
      (sum, line) => sum + (line.mrp !== 0 ? 0 : line.labourAmount + line.otherAmount),
      0,
    ),
  );
  const totalFine = weight(lines.reduce((sum, line) => sum + line.fineWt, 0));
  const labourAccount = labourLedgerAmount
    ? await resolveBookAccountTx(tx, scope, policy, 6)
    : itemAccount;
  if (labourLedgerAmount) await accountTx(tx, scope, labourAccount, 'configured labour account');

  // TR_VP.cs:5580-5587 writes TEMP_BOOK_DATA with company/location/book/hidden number/book name;
  // hidden numbering is independently MAX(VCH_NO)+1 without fiscal year (TR_VP.cs:5105-5114).
  await insertHiddenIdentityTx(tx, scope, identity, policy.configuredName);

  // Complete desktop RATE_CUT_DATA header mapping is TR_VP.cs:5599-5684. Request-provided
  // names/accounts are deliberately absent: party, angdiya, employee and book metadata above are
  // resolved from masters/configuration, while all totals are derived from resolved lines.
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
    // FAITHFUL, not a defect: TR_VP.cs:5628 writes `dataRow2["RATE_PAR"] = "G"` as a literal and never reads
    // MsRatePar at all — unlike TR_WH_SALE, TR_WH_SALE_RTN and TR_FINE_SL_PR, which all derive it from the
    // setting. Making this configurable would diverge from the desktop.
    RATE_PAR: 'G',
    FINE_RATE: 0,
    SL_FINE: Number(totalFine) || 0,
    PR_FINE: 0,
    SILVER_FINE_DR: 0,
    SILVER_FINE_CR: 0,
    TOT_FINE_CR: 0,
    TOT_FINE_DR: Number(totalFine) || 0,
    KSR_FINE_CR: 0,
    KSR_FINE_DR: 0,
    IT_TYPE: itemType,
    TAX_CODE: '',
    TAX_PRC: 0,
    SL_TAX_AMT: 0,
    SL_ITM_AMT: Number(itemAmount) || 0,
    SL_LBR_AMT: Number(lines.reduce((sum, line) => sum + line.labourAmount, 0)) || 0,
    SL_OTH_AMT: Number(lines.reduce((sum, line) => sum + line.otherAmount, 0)) || 0,
    SL_NET_AMT: Number(totalAmount) || 0,
    SL_CHQ_AMT: 0,
    SL_CARD_AMT: 0,
    SL_ADV_AMT: 0,
    SL_CASH_AMT: 0,
    SL_KASAR_AMT: 0,
    SL_BILL_OS: Number(totalAmount) || 0,
    PR_ITM_AMT: 0,
    PR_LBR_AMT: 0,
    PR_OTH_AMT: 0,
    PR_NET_AMT: 0,
    PR_CHQ_AMT: 0,
    PR_CARD_AMT: 0,
    PR_ADV_AMT: 0,
    PR_CASH_AMT: 0,
    PR_KASAR_AMT: 0,
    PR_BILL_OS: 0,
    CARD_AC: '',
    BANK_AC: '',
    CHQ_NO: '',
    VP_AMT_TYPE: 'A',
    VP_AMT: Number(totalAmount) || 0,
    VP_INS_AMT: 0,
    VP_CHARG_AMT: 0,
    AC_ANGDIYA: angdiya.code,
    VP_ADJ_AMT: 0,
    CR_DAYS: 0,
    EMP_CODE: employeeCode,
    VCH_DESC: text(input.description).slice(0, 150),
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
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
      ENTRY_TYPE: 'O',
      BOOK_NAME: policy.mainBook,
      IT_CODE: line.itemCode,
      ITM_REMARK: line.remark,
      TAG_NO: line.tagNo,
      TBL_CODE: line.tableCode,
      DESIGN_NO: line.designNo,
      ITM_SIZE: line.size,
      BAG_WT: line.bagWt,
      ITM_PCS: line.pcs,
      ITM_GWT: line.grossWt,
      ITM_OTH_WT: line.otherWt,
      ITM_NWT: line.netWt,
      ITM_GHT_WT: line.ghatWt,
      ITM_TOUCH: line.touch,
      ITM_WEST_PRC: line.westPct,
      ITM_FINE: line.fineWt,
      LBR_PRC: line.labourPct,
      LBR_TYPE: line.labourType,
      LBR_RATE: line.labourRate,
      LBR_AMT: line.labourAmount,
      OTH_AMT: line.otherAmount,
      ITM_RATE: line.rate,
      ITM_AMT: line.itemAmount,
      ITM_MRP: line.mrp,
      TOT_AMT: line.totalAmount,
      TAX_PRC: 0,
      NET_AMT: line.netAmount,
      KR_NET_WT: 0,
      KR_TOUCH: 0,
      KR_WEST_PRC: 0,
      KR_FINE: 0,
      KR_NAME: '',
      RATE_TYPE: line.rateType,
      IT_TYPE: line.itemType,
      PR_CODE: line.prCode,
      VCH_SRNO: line.tagVoucherSrNo,
      MAIN_USER: identity.mainUser || null,
      EMP_CODE: employeeCode,
      DESIGN_IMG_ID: null,
      DATA_TRFR: 'N',
    };
    // TR_VP.cs:5691-5758 writes these RATE_CUT_ISU columns from the grid and preserved identity.
    await insertRowTx(tx, 'RATE_CUT_ISU', scope.tenantId, detail);

    // The desktop report scratch projection maps RATE_CUT_ISU into RATE_CUT_ISU_REC at
    // TR_VP.cs:5945-5948, but first deletes the entire company's scratch table. The web keeps the
    // same mapped columns voucher-scoped and lifecycle-owned instead of reproducing that unsafe
    // global delete.
    await insertRowTx(tx, 'RATE_CUT_ISU_REC', scope.tenantId, {
      ...voucherKey(scope, identity.voucherNo),
      SR_NO: line.srNo,
      ENTRY_TYPE: 'I',
      AC_CODE: party.code,
      IT_CODE: line.itemCode,
      IT_DESC: line.remark,
      TAG_NO: line.tagNo,
      DESIGN_NO: line.designNo,
      ITM_PCS: line.pcs,
      BAG_WT: line.bagWt,
      ITM_GWT: line.grossWt,
      ITM_OTH_WT: line.otherWt,
      ITM_NWT: line.netWt,
      ITM_GHT_WT: line.ghatWt,
      ITM_TOUCH: line.touch,
      ITM_WEST_PRC: line.westPct,
      ITM_FINE: line.fineWt,
      LBR_PRC: line.labourPct,
      LBR_RATE: line.labourRate,
      LBR_TYPE: line.labourType,
      LBR_AMT: line.labourAmount,
      OTH_AMT: line.otherAmount,
      ITM_RATE: line.rate,
      ITM_AMT: line.itemAmount,
      ITM_MRP: line.mrp,
      NET_AMT: line.netAmount,
      RATE_TYPE: line.rateType,
      IT_TYPE: line.itemType,
      LESS_TOUCH: 0,
      ITM_OTH_FINE: 0,
      CONV_RATE: 0,
      CONV_PRC: 0,
      LESS_WT: 0,
      VCH_DATE: identity.voucherDate,
      EMP_CODE: employeeCode,
      TBL_CODE: line.tableCode,
      ITM_SIZE: line.size,
      // Remaining columns of the desktop RATE_CUT_ISU_REC row (TR_WH_SALE.cs:13683, the richest of
      // the ~10 forms writing this table): item attributes, the hallmark block and the image links.
      ITM_COLOR: line.itemColor ?? null,
      ITM_STYLE: line.itemStyle ?? null,
      ITM_LOT: line.itemLot ?? null,
      HM_ID: line.huid ?? null,
      HM_ID2: line.hallmarkId2 ?? null,
      HM_ID3: line.hallmarkId3 ?? null,
      HM_ID4: line.hallmarkId4 ?? null,
      HM_ID_WT: line.hallmarkIdWt ?? 0,
      HM_ID2_WT: line.hallmarkId2Wt ?? 0,
      HM_ID3_WT: line.hallmarkId3Wt ?? 0,
      HM_ID4_WT: line.hallmarkId4Wt ?? 0,
      IMAGE_ID: line.imageId ?? null,
      DESIGN_IMG_ID: line.designImageId ?? null,
      MAIN_USER: identity.mainUser || null,
    });

    // TR_VP only deletes SL_PR_DETL on delete (TR_VP.cs:5889) and contains no corresponding
    // insert. A voucher-scoped zero-purchase companion row records that lifecycle ownership without
    // fabricating a receipt/stock movement; this is the sole intentional compatibility projection.
    await insertRowTx(tx, 'SL_PR_DETL', scope.tenantId, {
      ...voucherKey(scope, identity.voucherNo),
      SR_NO: line.srNo,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'O',
      BOOK_NAME: policy.mainBook,
      AC_CODE: party.code,
      IT_CODE: line.itemCode,
      IT_DESC: line.remark,
      ITM_PCS: 0,
      ITM_GWT: 0,
      ITM_NWT: 0,
      ITM_TOUCH: 0,
      ITM_FINE: 0,
      ITM_RATE: 0,
      NET_AMT: 0,
      IT_TYPE: line.itemType,
      HD_VCH_NO: identity.hiddenVoucherNo,
      DATA_TRFR: 'N',
      MAIN_USER: identity.mainUser || null,
    });

    for (let componentIndex = 0; componentIndex < line.components.length; componentIndex++) {
      const component = line.components[componentIndex]!;
      const isrNo = componentIndex + 1;
      // TR_VP.cs:5761-5810 writes SL_IDTL. Component identity/name/origin/color is resolved from
      // BAR_IDTL for tags or DM_MAST for loose rows, never trusted as request metadata.
      await insertRowTx(tx, 'SL_IDTL', scope.tenantId, {
        ...voucherKey(scope, identity.voucherNo),
        SR_NO: line.srNo,
        ISR_NO: isrNo,
        HD_VCH_NO: identity.hiddenVoucherNo,
        VCH_DATE: identity.voucherDate,
        AC_CODE: party.code,
        VCH_TYPE: policy.vchType,
        INOUT_TYPE: policy.inout,
        ENTRY_TYPE: 'O',
        BOOK_NAME: policy.mainBook,
        TAG_NO: line.tagNo,
        VCH_SRNO: line.tagVoucherSrNo,
        IT_CODE: line.itemCode,
        DM_CODE: component.dmCode,
        DM_NAME: component.dmName,
        DM_SIZE: component.dmSize,
        DM_SFNO: '',
        IT_PCS: component.pcs,
        IT_GWT: component.weight,
        KR_WT: 0,
        IT_CON_PRC: 0,
        IT_RATE_TYPE: component.rateType,
        IT_RATE: component.rate,
        IT_AMT: component.amount,
        IT_LBR_RATE: component.labourRate,
        IT_LBR_AMT: component.labourAmount,
        IT_NET_AMT: component.netAmount,
        IT_CON_WT: 0,
        IT_TYPE: line.itemType,
        MAIN_USER: identity.mainUser || null,
        DM_ORIGIN: component.dmOrigin,
        DM_REMARK: component.dmRemark,
        DM_COLOR: component.dmColor,
      });
      // Ac_Stock.cs:869-875 (Dm_Vp_Sale_Sale_Detl) projects component rows with ENTRY_TYPE='S',
      // DM_SIGN='-', BOOK_SNAME, main item/TBL identities and resolved component values.
      await insertRowTx(tx, 'DM_DATA', scope.tenantId, {
        ...voucherKey(scope, identity.voucherNo),
        MAIN_SRNO: 1,
        SR_NO: line.srNo,
        ISR_NO: isrNo,
        VCH_DATE: identity.voucherDate,
        ENTRY_TYPE: 'S',
        BOOK_NAME: policy.vchType,
        AC_CODE: party.code,
        IT_CODE: line.itemCode,
        DM_CODE: component.dmCode,
        DM_ORIGIN: component.dmOrigin,
        DM_REMARK: component.dmRemark,
        DM_SIZE: component.dmSize,
        DM_COLOR: component.dmColor,
        DM_LOT_NO: '',
        DM_PCS: component.pcs,
        DM_WT: component.weight,
        DM_SIGN: '-',
        DM_RATE: component.rate,
        DM_AMT: component.amount,
        EMP_CODE: '',
        MAIN_USER: identity.mainUser || null,
        TAG_NO: line.tagNo,
        VCH_SRNO: line.tagVoucherSrNo,
        MAIN_IT_CODE: line.itemCode,
        INOUT_TYPE: 'S',
      });
    }

    // Ac_Stock.cs:146-157 is the VP PARCEL stock family: RATE_CUT_ISU -> SR_NO=1,
    // ISR_NO=detail SR_NO, VCH_TYPE=BOOK_SNAME, BOOK_NAME=MAIN_BOOK, TR_TYPE='S', ITM_SIGN='-'.
    await insertRowTx(tx, 'MAIN_STOCK', scope.tenantId, {
      ...voucherKey(scope, identity.voucherNo),
      SR_NO: 1,
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
      TR_TYPE: 'S',
      ITM_SIGN: '-',
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
      ITM_MRP: line.mrp,
      NET_AMT: line.netAmount,
      KR_NWT: 0,
      KR_TOUCH: 0,
      KR_WEST: 0,
      KR_FINE: 0,
      KR_LBR_AMT: 0,
      KR_OTH_AMT: 0,
      KR_COST: 0,
      EMP_CODE: employeeCode,
      ENTRY_TIME: identity.voucherTime,
      MAIN_USER: identity.mainUser || null,
      DATA_TYPE: policy.dataType,
      DESIGN_NO: line.designNo,
      ITM_SIZE: line.size,
      ITM_DESC: line.remark,
      GHT_PRC: 0,
      ITM_LOT: '',
      ITM_DISC: '0',
    });
  }

  const prefix = `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}`;
  const ledger: Record<string, unknown>[] = [];
  // Ac_Ledr.cs:1723-1799 (VP_Ledr): configured SR1/SR8 item legs, SR6 labour/other leg,
  // party/angdiya identities, and paired metal fine legs. Only non-zero legs are materialized.
  if (totalAmount) {
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}01`),
      AC_CODE: angdiya.code,
      LD_CODE: itemAccount,
      CR_AMT: 0,
      DR_AMT: totalAmount,
      IT_TYPE: itemType,
      SIGN: '+',
      PARTY_AC_CODE: party.code,
    });
  }
  if (itemLedgerAmount) {
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}02`),
      AC_CODE: itemAccount,
      LD_CODE: angdiya.code,
      CR_AMT: itemLedgerAmount,
      DR_AMT: 0,
    });
  }
  if (labourLedgerAmount) {
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}16`),
      AC_CODE: labourAccount,
      LD_CODE: party.code,
      CR_AMT: labourLedgerAmount,
      DR_AMT: 0,
    });
  }
  if (totalFine) {
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}19`),
      AC_CODE: party.code,
      LD_CODE: itemAccount,
      CR_AMT: 0,
      DR_AMT: 0,
      IT_TYPE: itemType,
      SIGN: '-',
      FINE_WT: totalFine,
      PARTY_AC_CODE: party.code,
    });
    ledger.push({
      ...ledgerBase(scope, policy, identity, `${prefix}20`),
      AC_CODE: itemAccount,
      LD_CODE: party.code,
      CR_AMT: 0,
      DR_AMT: 0,
      IT_TYPE: itemType,
      SIGN: '+',
      FINE_WT: totalFine,
    });
  }
  assertBalanced(ledger);
  const fineBalance = weight(
    ledger.reduce(
      (sum, row) => sum + (text(row.SIGN) === '+' ? n(row.FINE_WT) : -n(row.FINE_WT)),
      0,
    ),
  );
  if (fineBalance !== 0) throw new VpParcelValidationError('VP parcel fine ledger is unbalanced');
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);

  // Ac_Rojmel.cs:805-834 mirrors party outstanding/item/fine/detail/labour legs. The web emits the
  // non-zero deterministic subset with the same configured identities and signed detail weights.
  await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
    ...rojmelBase(scope, policy, identity, `${prefix}R03`),
    AC_CODE: party.code,
    LD_CODE: itemAccount,
    DR_AMT: totalAmount,
    AC_NAME: `${policy.vchType} - ${party.name}`,
    IT_TYPE: itemType,
    SIGN: '+',
    ITM_FINE: totalFine,
    IT_DESC: text(input.description),
  });
  for (const line of lines) {
    await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
      ...rojmelBase(scope, policy, identity, `${prefix}R05${line.srNo}`),
      AC_CODE: party.code,
      LD_CODE: itemAccount,
      AC_NAME: party.name,
      IT_TYPE: line.itemType,
      SIGN: '-',
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
  if (itemLedgerAmount) {
    await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
      ...rojmelBase(scope, policy, identity, `${prefix}R04`),
      AC_CODE: itemAccount,
      LD_CODE: angdiya.code,
      CR_AMT: itemLedgerAmount,
      AC_NAME: '',
      IT_DESC: text(input.description),
    });
  }
  if (labourLedgerAmount) {
    await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
      ...rojmelBase(scope, policy, identity, `${prefix}R27`),
      AC_CODE: labourAccount,
      LD_CODE: party.code,
      CR_AMT: labourLedgerAmount,
      AC_NAME: `LBR - ${party.name}`,
      IT_DESC: text(input.description),
    });
  }
}

const writeTables = [
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'DM_DATA',
  'SL_IDTL',
  'SL_PR_DETL',
  'RATE_CUT_ISU_REC',
  'RATE_CUT_ISU',
  'RATE_CUT_DATA',
] as const;

async function saveTx(tx: any, input: VpParcelInput, requestedVoucherNo?: string) {
  const scope = completeFinanceScope(input.scope);
  const policy = await resolveBookTx(tx, scope);
  const requested = businessDate(input.vchDate);
  // Exact desktop messages/rules: fiscal year at TR_VP.cs:5533, lock date at 5539, rights at 5545,
  // party required at 5551 and voucher required at 5558. Route RBAC supplies rights; server-derived
  // numbering supplies VCH_NO; fiscal and period checks fail closed here.
  await assertFiscalDateTx(tx, scope, requested.iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: requested.date }] },
  });
  await accountTx(tx, scope, input.partyCode, 'party');
  const created = !requestedVoucherNo;
  let identity: VoucherIdentity;
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'RATE_CUT_DATA',
      scope,
      requestedVoucherNo,
      requestedDate: requested.date,
    });
    identity = edited.identity;
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    // Existing load preserves time, HD_VCH_NO and MAIN_USER at TR_VP.cs:5167-5168,5243.
    // Edit removes/rebuilds the write set at 5589-5594,5813-5824 and has no DELETE_DATA insert.
    const lines = await resolveLinesTx(tx, input, identity.voucherNo);
    await assertStockReplacementSafeTx(tx, scope, identity.voucherNo, lines);
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, writeTables);
    await writeTx(tx, input, policy, identity, lines);
    return {
      voucherNo: identity.voucherNo,
      hiddenVoucherNo: identity.hiddenVoucherNo,
      created,
      lines: lines.length,
    };
  }
  identity = await createIdentityTx(tx, scope, requested.date, input.mainUser);
  const lines = await resolveLinesTx(tx, input);
  await assertStockReplacementSafeTx(tx, scope, undefined, lines);
  await writeTx(tx, input, policy, identity, lines);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created,
    lines: lines.length,
  };
}

export async function saveVpParcel(prisma: any, input: VpParcelInput, requestedVoucherNo?: string) {
  return withTenant(prisma, input.scope.tenantId, (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getVpParcel(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT h.*,h."VCH_DATE"::text AS "VCH_DAY",to_char(h."VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK"
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
      throw new VpParcelValidationError(
        headers.length
          ? `VP parcel is ambiguous: ${voucherNo}`
          : `VP parcel not found: ${voucherNo}`,
      );
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d.*,m."IT_NAME" FROM "RATE_CUT_ISU" d LEFT JOIN "ITEM_MAST" m
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
    const header = headers[0]!;
    return {
      voucherNo,
      vchDate: text(header.VCH_DAY).slice(0, 10),
      voucherTime: text(header.VCH_CLOCK),
      hiddenVoucherNo: text(header.HD_VCH_NO),
      mainUser: text(header.MAIN_USER),
      partyCode: text(header.AC_CODE),
      partyName: text(header.AC_NAME),
      angdiyaCode: text(header.AC_ANGDIYA),
      billNo: text(header.BILL_NO),
      employeeCode: text(header.EMP_CODE),
      description: text(header.VCH_DESC),
      lines: rows.map((row) => ({
        srNo: n(row.SR_NO),
        tagNo: text(row.TAG_NO),
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
        ghatWt: n(row.ITM_GHT_WT),
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
        netAmount: n(row.NET_AMT),
      })),
    };
  });
}

export async function deleteVpParcel(
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
      extraColumns: ['AC_CODE', 'AC_NAME'],
    });
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    const persistedLines = await resolveLinesTx(
      tx,
      {
        scope,
        vchDate: persistedIso,
        partyCode: text(edited.persisted.AC_CODE),
        lines: await tx.$queryRawUnsafe(
          `SELECT "TAG_NO" AS "tagNo","VCH_SRNO" AS "tagVoucherSrNo","IT_CODE" AS "itemCode",
                  "ITM_PCS" AS pcs,"ITM_GWT" AS "grossWt","ITM_OTH_WT" AS "otherWt",
                  "ITM_TOUCH" AS touch,"ITM_WEST_PRC" AS "westPct","RATE_TYPE" AS "rateType",
                  "ITM_RATE" AS rate,"LBR_TYPE" AS "labourType","LBR_RATE" AS "labourRate",
                  "LBR_PRC" AS "labourPct","OTH_AMT" AS "otherAmount","ITM_MRP" AS mrp
             FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
              AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
          scope.tenantId,
          scope.coCode,
          scope.lcCode,
          scope.coYear,
          scope.coBook,
          voucherNo,
        ),
      },
      voucherNo,
    );
    await assertStockReplacementSafeTx(tx, scope, voucherNo, persistedLines);
    // TR_VP.cs:5877 contains exactly one INSERT INTO DELETE_DATA and maps one header row:
    // scope/VCH/VCH_DATE/VCH_TIME/HD_VCH_NO/MAIN_USER from RATE_CUT_DATA; VCH_TYPE=BOOK_SNAME,
    // BOOK_NAME=BOOK_NAME, account name from AC_MAST, SR/values/fines=0, FINE_TYPE='A',
    // deletion timestamps/user at deletion, and VCH_DESC is literal 0.
    // Prisma materializes timestamp-without-time-zone as Date. Rebuild the persisted wall clock
    // before the DELETE_DATA insert; passing that Date through again shifts it by the process zone.
    const deleteHeader = {
      ...edited.persisted,
      VCH_TIME: voucherTimestamp(
        new Date(`${persistedIso}T00:00:00.000Z`),
        edited.persisted.VCH_CLOCK,
      ),
    };
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: policy.configuredName, shortName: policy.vchType },
      header: deleteHeader,
      deleteUser,
      rows: [
        {
          srNo: 0,
          acCode: edited.persisted.AC_CODE,
          acName: edited.persisted.AC_NAME,
          valueDr: 0,
          valueCr: 0,
          fineType: 'A',
          fineDr: 0,
          fineCr: 0,
          description: '0',
        },
      ],
    });
    // Full desktop removal is TR_VP.cs:5879-5889; edit uses the same set without audit.
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, writeTables);
    return { reversed: true, auditedRows: 1 };
  });
}
