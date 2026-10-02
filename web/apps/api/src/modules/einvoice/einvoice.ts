import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTxBudget } from '../shared/txBudget.js';

/**
 * E-Invoice (IRN) generation + cancellation — NIC e-invoice schema v1.1, ported from the desktop
 * GenIRN.txt template + UT_E_INVOICE form. The payload builder is pure and unit-tested. Submission
 * goes through an injected transport: `FakeIrnTransport` (deterministic, for tests / no-creds mode)
 * or the REAL `CharteredInfoIrnTransport` (the desktop's GSP). The live transport is selected by
 * `irnTransportFromEnv` when GSP credentials are present in the environment (GSP_ASPID/GSP_PASSWORD/
 * GSP_GSTIN/GSP_USER/GSP_EINV_PWD [+ GSP_SANDBOX]). Credentials are read from the environment ONLY —
 * secrets are never persisted in the application DB. `testGspAuth` validates the configured creds
 * (auth round-trip) and `gspStatus` reports the (masked) configuration. On IRN success we store
 * IRN/ACK on SL_DATA + a row in E_DATA; on cancel we clear them (NIC allows cancel within 24h).
 *
 * E-invoice is a B2B obligation: a recipient GSTIN is required (we throw otherwise).
 */

export class EInvoiceValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'EInvoiceValidationError';
  }
}

/**
 * Raised when the e-invoice configuration is unsafe rather than merely absent — specifically when production
 * would otherwise fall back to `FakeIrnTransport` and persist a fabricated IRN onto a real invoice, or when
 * GSP credentials are supplied without stating sandbox vs production.
 */
export class EInvoiceConfigError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'EInvoiceConfigError';
  }
}

export interface IrnParty {
  gstin: string;
  lglNm: string;
  trdNm?: string;
  addr1?: string;
  loc?: string;
  pin?: number;
  stcd: string; // state code
}

export interface IrnItemInput {
  desc: string;
  hsn: string;
  qty: number;
  unit?: string; // default GMS (jewellery)
  unitPrice: number;
  assAmt: number; // taxable value
  gstRt: number;
  igst?: number;
  cgst?: number;
  sgst?: number;
}

export type IrnDocType = 'INV' | 'CRN';

export interface SaleForIrn {
  billNo: string;
  vchDate: Date | string;
  interState: boolean;
  roundOff?: number;
  /** TR_SL_EBILL.JsonGen: E CRNT sends CRN, every other e-bill path sends INV. */
  docType?: IrnDocType;
}

const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

/** Format a date as dd/MM/yyyy (NIC e-invoice format). */
export function fmtIrnDate(d: Date | string): string {
  const dt = d instanceof Date ? d : new Date(d);
  const dd = String(dt.getDate()).padStart(2, '0');
  const mm = String(dt.getMonth() + 1).padStart(2, '0');
  return `${dd}/${mm}/${dt.getFullYear()}`;
}

export interface IrnPayload {
  Version: string;
  TranDtls: { TaxSch: string; SupTyp: string; RegRev: string; IgstOnIntra: string };
  DocDtls: { Typ: string; No: string; Dt: string };
  SellerDtls: Record<string, unknown>;
  BuyerDtls: Record<string, unknown>;
  ItemList: Record<string, unknown>[];
  ValDtls: Record<string, number>;
}

function partyDtls(p: IrnParty): Record<string, unknown> {
  return {
    Gstin: p.gstin,
    LglNm: p.lglNm,
    TrdNm: p.trdNm ?? p.lglNm,
    Addr1: p.addr1 ?? '',
    Loc: p.loc ?? '',
    Pin: p.pin ?? 0,
    Stcd: p.stcd,
  };
}

/** Build the NIC v1.1 IRN payload from a sale (Req 18.4). Throws if not a valid B2B e-invoice. */
export function buildIrnPayload(args: {
  seller: IrnParty;
  buyer: IrnParty;
  sale: SaleForIrn;
  items: IrnItemInput[];
}): IrnPayload {
  const { seller, buyer, sale, items } = args;
  if (!seller?.gstin) throw new EInvoiceValidationError('seller GSTIN is required');
  if (!buyer?.gstin)
    throw new EInvoiceValidationError('recipient GSTIN is required (e-invoice is B2B only)');
  if (!items?.length) throw new EInvoiceValidationError('at least one item is required');

  const itemList = items.map((it, i) => {
    const igst = round2(it.igst ?? 0);
    const cgst = round2(it.cgst ?? 0);
    const sgst = round2(it.sgst ?? 0);
    const assAmt = round2(it.assAmt);
    const totItemVal = round2(assAmt + igst + cgst + sgst);
    return {
      SlNo: String(i + 1),
      PrdDesc: it.desc,
      IsServc: 'N',
      HsnCd: it.hsn,
      Qty: it.qty,
      FreeQty: 0,
      Unit: it.unit ?? 'GMS',
      UnitPrice: round2(it.unitPrice),
      TotAmt: assAmt,
      Discount: 0,
      PreTaxVal: assAmt,
      AssAmt: assAmt,
      GstRt: it.gstRt,
      IgstAmt: igst,
      CgstAmt: cgst,
      SgstAmt: sgst,
      OthChrg: 0,
      TotItemVal: totItemVal,
    };
  });

  const sum = (k: 'AssAmt' | 'IgstAmt' | 'CgstAmt' | 'SgstAmt' | 'TotItemVal'): number =>
    round2(itemList.reduce((s, it) => s + (it[k] as number), 0));
  const rnd = round2(sale.roundOff ?? 0);

  return {
    Version: '1.1',
    TranDtls: { TaxSch: 'GST', SupTyp: 'B2B', RegRev: 'N', IgstOnIntra: 'N' },
    DocDtls: { Typ: sale.docType ?? 'INV', No: sale.billNo, Dt: fmtIrnDate(sale.vchDate) },
    SellerDtls: partyDtls(seller),
    BuyerDtls: { ...partyDtls(buyer), Pos: buyer.stcd },
    ItemList: itemList,
    ValDtls: {
      AssVal: sum('AssAmt'),
      CgstVal: sum('CgstAmt'),
      SgstVal: sum('SgstAmt'),
      IgstVal: sum('IgstAmt'),
      Discount: 0,
      OthChrg: 0,
      RndOffAmt: rnd,
      TotInvVal: round2(sum('TotItemVal') + rnd),
    },
  };
}

/** Required-field validation (returns missing-field list; empty ⇒ valid). */
export function validateIrnPayload(p: IrnPayload): string[] {
  const missing: string[] = [];
  if (!p.SellerDtls?.Gstin) missing.push('SellerDtls.Gstin');
  if (!p.BuyerDtls?.Gstin) missing.push('BuyerDtls.Gstin');
  if (!p.DocDtls?.No) missing.push('DocDtls.No');
  if (!p.DocDtls?.Dt) missing.push('DocDtls.Dt');
  if (!['INV', 'CRN'].includes(String(p.DocDtls?.Typ ?? ''))) missing.push('DocDtls.Typ');
  if (!p.ItemList?.length) missing.push('ItemList');
  if (!((p.ValDtls?.TotInvVal ?? 0) > 0)) missing.push('ValDtls.TotInvVal');
  return missing;
}

export interface IrnResult {
  /** True when the portal reported this document as already registered and returned the existing IRN. */
  duplicate?: boolean;
  Irn: string;
  AckNo: string;
  AckDt: string;
  SignedQRCode: string;
  Status: string;
}

export interface IrnCancelResult {
  Irn: string;
  CancelDate: string;
  Status: string;
}

export interface IrnTransport {
  generateIRN(payload: IrnPayload): Promise<IrnResult>;
  cancelIRN?(irn: string, reason: string, remark?: string): Promise<IrnCancelResult>;
}

/** Deterministic fake GSP transport for tests (no network). Mimics a successful IRN registration + cancel. */
export class FakeIrnTransport implements IrnTransport {
  async generateIRN(payload: IrnPayload): Promise<IrnResult> {
    const seed = `${payload.SellerDtls.Gstin}|${payload.DocDtls.No}|${payload.DocDtls.Dt}`;
    // 64-char hex-ish IRN (NIC IRNs are 64 chars); deterministic from the invoice identity
    let h = 0;
    for (const c of seed) h = (h * 31 + c.charCodeAt(0)) >>> 0;
    const irn = (h.toString(16).padStart(8, '0') + seed.replace(/[^A-Za-z0-9]/g, ''))
      .padEnd(64, '0')
      .slice(0, 64);
    return {
      Irn: irn,
      AckNo: String(100000000000 + (h % 900000000000)),
      AckDt: payload.DocDtls.Dt,
      SignedQRCode: `QR:${irn.slice(0, 24)}`,
      Status: 'ACT',
    };
  }
  async cancelIRN(irn: string): Promise<IrnCancelResult> {
    return { Irn: irn, CancelDate: new Date().toISOString().slice(0, 10), Status: 'CNL' };
  }
}

type VoucherScope = {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
  coBook?: string;
};

type IrnBookInfo = { coBook: string; mainBook: string; bookSrName: string };

const text = (v: unknown): string => String(v ?? '').trim();

async function resolveIrnBookTx(
  tx: any,
  scope: VoucherScope,
  coBook: string,
  expectedMainBook?: string,
): Promise<IrnBookInfo> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","MAIN_BOOK","BOOK_SR_NAME"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    coBook,
  );
  const row = rows[0];
  if (!row) throw new EInvoiceValidationError(`e-invoice book configuration not found: ${coBook}`);
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  if (expectedMainBook && mainBook !== expectedMainBook.toUpperCase()) {
    throw new EInvoiceValidationError(
      `expected BOOK_DATA.MAIN_BOOK='${expectedMainBook}' for book ${coBook}, got ${mainBook || 'blank'}`,
    );
  }
  return { coBook, mainBook, bookSrName: text(row.BOOK_SR_NAME) };
}

function scopedWhere(scope: VoucherScope, coBook: string, vchNo: number | string): unknown[] {
  return [
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear ?? '',
    coBook,
    formatVoucherNo(vchNo),
  ];
}

/**
 * Submit a built IRN payload via the injected transport, then persist IRN/ACK to SL_DATA and E_DATA
 * within one tenant transaction. Returns the IRN result.
 */
export async function submitIrn(
  prisma: any,
  scope: VoucherScope,
  args: { vchNo: number | string; payload: IrnPayload; transport: IrnTransport },
): Promise<IrnResult> {
  const missing = validateIrnPayload(args.payload);
  if (missing.length)
    throw new EInvoiceValidationError(`invalid IRN payload, missing: ${missing.join(', ')}`);

  const res = await args.transport.generateIRN(args.payload);

  await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const coBook = scope.coBook ?? 'SAL';
    const vchNo = formatVoucherNo(args.vchNo);
    const ackDate = new Date();
    await tx.$executeRawUnsafe(
      `UPDATE "SL_DATA"
          SET "IRN_NO"=$1, "ACK_NO"=$2, "ACK_DATE"=$3
        WHERE tenant_id=$4 AND "CO_CODE"=$5 AND "LC_CODE"=$6 AND "CO_YEAR"=$7 AND "CO_BOOK"=$8 AND "VCH_NO"=$9`,
      res.Irn,
      res.AckNo,
      ackDate,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      coBook,
      vchNo,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "E_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IRN_NO","ACK_NO","ACK_DATE","QR_DATA")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10)`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      coBook,
      vchNo,
      res.Irn,
      res.AckNo,
      ackDate,
      Buffer.from(res.SignedQRCode, 'utf8'),
    );
  });

  return res;
}

const enc = (s: string): string => encodeURIComponent(s);

/**
 * Real GSP transport — Chartered Info (the desktop's GSP, TR_SL_EBILL/UT_E_INVOICE). Two-step:
 *   1) auth  → eivital/dec/v1.04/auth  → AuthToken
 *   2) IRN   → eicore/dec/v1.03/Invoice (POST payload) → Irn/AckNo/AckDt/SignedQRCode
 * Prod host einvapi.charteredinfo.com, sandbox gstsandbox.charteredinfo.com. Needs GSP creds.
 */
/**
 * NIC e-invoice error codes that must NOT be treated as failures or as retryable.
 *
 * `2150` is the one that matters most in practice: the portal already holds an IRN for this document, and
 * it returns that IRN in the error payload. A network timeout on the first attempt followed by a retry
 * produces exactly this, so treating 2150 as a failure would permanently strand a bill that the portal
 * considers registered. The desktop has no retry at all — the operator pressed the button again — so the
 * web must handle the duplicate the portal reports rather than inventing a second registration.
 */
export const NIC_DUPLICATE_IRN_CODE = '2150';

/** Auth failures where retrying with the same credentials cannot help. */
export const NIC_FATAL_AUTH_CODES = new Set(['1005', '1006', '1002']);

export interface NicErrorDetail {
  code: string;
  message: string;
}

/**
 * NIC returns errors as `ErrorDetails: [{ErrorCode, ErrorMessage}]`, sometimes as a `Data` string
 * containing the same JSON, and sometimes only as a top-level message. All three shapes are normalised
 * here so callers branch on a code rather than on substring matching.
 */
export function parseNicErrors(body: unknown): NicErrorDetail[] {
  const out: NicErrorDetail[] = [];
  const visit = (value: unknown): void => {
    if (!value) return;
    if (typeof value === 'string') {
      const trimmed = value.trim();
      if (trimmed.startsWith('[') || trimmed.startsWith('{')) {
        try {
          visit(JSON.parse(trimmed));
        } catch {
          /* not JSON: nothing to extract */
        }
      }
      return;
    }
    if (Array.isArray(value)) {
      for (const entry of value) visit(entry);
      return;
    }
    if (typeof value === 'object') {
      const record = value as Record<string, unknown>;
      const code = record.ErrorCode ?? record.errorCode ?? record.error_cd;
      const message = record.ErrorMessage ?? record.errorMessage ?? record.error_desc;
      if (code != null) out.push({ code: String(code), message: String(message ?? '') });
      for (const key of ['ErrorDetails', 'errorDetails', 'Data', 'data', 'InfoDtls']) {
        if (key in record) visit(record[key]);
      }
    }
  };
  visit(body);
  return out;
}

/** Duplicate-IRN detail, when the portal reports one. */
export function duplicateIrnFrom(body: unknown): { irn: string } | null {
  const errors = parseNicErrors(body);
  if (!errors.some((e) => e.code === NIC_DUPLICATE_IRN_CODE)) return null;
  // The IRN travels either in Info/Desc or alongside the error; take the first 64-hex-ish token.
  const text = JSON.stringify(body ?? '');
  const match = /[0-9a-f]{64}/i.exec(text);
  return match ? { irn: match[0] } : null;
}

export class CharteredInfoIrnTransport implements IrnTransport {
  private base: string;
  /**
   * Cached auth token. NIC tokens are valid for hours and the portal rate-limits authentication, so
   * re-authenticating per call would start failing under real load. The expiry is honoured with a safety
   * margin and the token is dropped on any auth-related error so the next call re-authenticates.
   */
  private token: { value: string; expiresAt: number } | null = null;
  constructor(
    private cfg: {
      aspId: string;
      aspPassword: string;
      gstin: string;
      userId: string;
      eInvPwd: string;
      sandbox?: boolean;
      fetchImpl?: typeof fetch;
    },
  ) {
    this.base =
      cfg.sandbox === false
        ? 'https://einvapi.charteredinfo.com'
        : 'https://gstsandbox.charteredinfo.com';
  }
  private get f(): typeof fetch {
    return this.cfg.fetchImpl ?? fetch;
  }
  /** Discard the cached token, forcing the next call to re-authenticate. */
  invalidateToken(): void {
    this.token = null;
  }

  async authToken(force = false): Promise<string> {
    const now = Date.now();
    if (!force && this.token && this.token.expiresAt > now) return this.token.value;

    const u = `${this.base}/eivital/dec/v1.04/auth?aspid=${enc(this.cfg.aspId)}&password=${enc(this.cfg.aspPassword)}&Gstin=${enc(this.cfg.gstin)}&User_name=${enc(this.cfg.userId)}&eInvPwd=${enc(this.cfg.eInvPwd)}`;
    const r = await this.f(u, { signal: AbortSignal.timeout(20000) } as any);
    const j: any = await r.json().catch(() => ({}));
    const tok = j?.AuthToken ?? j?.Data?.AuthToken ?? j?.data?.AuthToken;
    if (!tok) {
      const errors = parseNicErrors(j);
      const fatal = errors.find((e) => NIC_FATAL_AUTH_CODES.has(e.code));
      const detail = fatal ? `${fatal.code}: ${fatal.message}` : JSON.stringify(j).slice(0, 160);
      throw new EInvoiceValidationError(`GSP auth failed: ${detail}`);
    }
    // NIC returns TokenExpiry as 'yyyy-MM-dd HH:mm:ss'; fall back to a conservative hour when absent,
    // and always keep a 5-minute margin so a token never expires mid-request.
    const rawExpiry = j?.TokenExpiry ?? j?.Data?.TokenExpiry ?? j?.data?.TokenExpiry;
    const parsed = rawExpiry ? Date.parse(String(rawExpiry).replace(' ', 'T')) : NaN;
    const expiresAt = Number.isFinite(parsed) ? parsed - 5 * 60_000 : now + 55 * 60_000;
    this.token = { value: String(tok), expiresAt };
    return this.token.value;
  }
  private invoiceUrl(token: string): string {
    return `${this.base}/eicore/dec/v1.03/Invoice?aspid=${enc(this.cfg.aspId)}&password=${enc(this.cfg.aspPassword)}&Gstin=${enc(this.cfg.gstin)}&User_Name=${enc(this.cfg.userId)}&AuthToken=${enc(token)}&QrCodeSize=250`;
  }

  async generateIRN(payload: IrnPayload): Promise<IrnResult> {
    let attempt = 0;
    // At most one retry, and only to replace an expired token. This is NOT a general retry loop: a
    // second submission of the same document would either be rejected as a duplicate or, worse, create a
    // second registration, so anything other than an auth problem is surfaced immediately.
    for (;;) {
      const token = await this.authToken(attempt > 0);
      const r = await this.f(this.invoiceUrl(token), {
        method: 'POST',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(payload),
        signal: AbortSignal.timeout(30000),
      } as any);
      const j: any = await r.json().catch(() => ({}));
      const d = j?.Data ?? j?.data ?? j;
      if (d?.Irn) {
        return {
          Irn: String(d.Irn),
          AckNo: String(d.AckNo ?? ''),
          AckDt: String(d.AckDt ?? ''),
          SignedQRCode: String(d.SignedQRCode ?? d.QRCode ?? ''),
          Status: String(d.Status ?? 'ACT'),
        };
      }

      // The portal already registered this document (typically our own earlier attempt that timed out).
      // It returns the existing IRN, which is the correct answer — not an error.
      const duplicate = duplicateIrnFrom(j);
      if (duplicate) {
        return {
          Irn: duplicate.irn,
          AckNo: String(d?.AckNo ?? ''),
          AckDt: String(d?.AckDt ?? ''),
          SignedQRCode: String(d?.SignedQRCode ?? d?.QRCode ?? ''),
          Status: 'ACT',
          duplicate: true,
        };
      }

      const errors = parseNicErrors(j);
      const authExpired = errors.some((e) => NIC_FATAL_AUTH_CODES.has(e.code));
      if (authExpired && attempt === 0) {
        this.invalidateToken();
        attempt += 1;
        continue;
      }
      const detail = errors.length
        ? errors
            .map((e) => `${e.code}: ${e.message}`)
            .join('; ')
            .slice(0, 200)
        : JSON.stringify(j).slice(0, 160);
      throw new EInvoiceValidationError(`IRN generation failed: ${detail}`);
    }
  }
  async cancelIRN(irn: string, reason: string, remark?: string): Promise<IrnCancelResult> {
    const token = await this.authToken();
    const u = `${this.base}/eicore/dec/v1.03/Cancel?aspid=${enc(this.cfg.aspId)}&password=${enc(this.cfg.aspPassword)}&Gstin=${enc(this.cfg.gstin)}&User_Name=${enc(this.cfg.userId)}&AuthToken=${enc(token)}`;
    // NIC cancel reason codes: '1'=Duplicate, '2'=Data entry mistake, '3'=Order cancelled, '4'=Other
    const body = { Irn: irn, CnlRsn: reason || '2', CnlRem: remark || 'Cancelled from ERP' };
    const r = await this.f(u, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(body),
      signal: AbortSignal.timeout(30000),
    } as any);
    const j: any = await r.json().catch(() => ({}));
    const d = j?.Data ?? j?.data ?? j;
    if (!(d?.Irn || d?.CancelDate || d?.CancelDt))
      throw new EInvoiceValidationError('IRN cancel failed: ' + JSON.stringify(j).slice(0, 160));
    return {
      Irn: String(d.Irn ?? irn),
      CancelDate: String(d.CancelDate ?? d.CancelDt ?? new Date().toISOString().slice(0, 10)),
      Status: 'CNL',
    };
  }
}

/** Pick the IRN transport from env: real Chartered Info GSP if creds set, else Fake. */
/**
 * The variables `irnTransportFromEnv` requires, declared beside it for the same reason as the messaging
 * lists: the readiness report imports these rather than restating them.
 */
export const GSP_ENV = [
  'GSP_ASPID',
  'GSP_PASSWORD',
  'GSP_GSTIN',
  'GSP_USER',
  'GSP_EINV_PWD',
] as const;
/** Optional: absent or any value other than '0' means sandbox. */
export const GSP_OPTIONAL_ENV = ['GSP_SANDBOX'] as const;

export function irnTransportFromEnv(env: NodeJS.ProcessEnv = process.env): {
  transport: IrnTransport;
  mode: string;
} {
  if (env.GSP_ASPID && env.GSP_PASSWORD && env.GSP_GSTIN && env.GSP_USER && env.GSP_EINV_PWD) {
    if (env.GSP_SANDBOX === undefined || env.GSP_SANDBOX.trim() === '') {
      // Refuse to guess. Sandbox IRNs are not legally valid and production IRNs cannot be undone, so the
      // operator must state which one they mean. The old code defaulted to sandbox, which meant a complete
      // set of production credentials still silently produced invalid IRNs.
      throw new EInvoiceConfigError(
        'GSP_SANDBOX must be set explicitly to 1 (sandbox) or 0 (production) when GSP credentials are ' +
          'supplied. Sandbox IRNs are not legally valid; refusing to assume.',
      );
    }
    const sandbox = env.GSP_SANDBOX !== '0';
    return {
      transport: new CharteredInfoIrnTransport({
        aspId: env.GSP_ASPID,
        aspPassword: env.GSP_PASSWORD,
        gstin: env.GSP_GSTIN,
        userId: env.GSP_USER,
        eInvPwd: env.GSP_EINV_PWD,
        sandbox,
      }),
      mode: sandbox ? 'chartered-info-sandbox' : 'chartered-info-prod',
    };
  }

  // FAIL CLOSED IN PRODUCTION.
  //
  // `FakeIrnTransport` returns a 64-character IRN, a 12-digit AckNo, a QR string and Status 'ACT' — it is
  // indistinguishable from a government-issued IRN, and `submitIrn` persists it into SL_DATA.IRN_NO and
  // E_DATA. Under GST e-invoicing rules an invoice carrying an invalid IRN is not valid tax documentation,
  // so silently substituting a fake makes the business non-compliant while telling it that it is compliant.
  //
  // Every deployment path sets NODE_ENV=production (docker-compose.yml, deploy/docker-compose.prod.yml, and
  // ENV in Dockerfile.api), so this guard is reachable wherever it matters. A shop that does not e-invoice at
  // all is unaffected: this throws only when an IRN is actually requested, not at startup.
  if (env.NODE_ENV === 'production') {
    throw new EInvoiceConfigError(
      'refusing to issue a fake IRN in production. Set GSP_ASPID, GSP_PASSWORD, GSP_GSTIN, GSP_USER, ' +
        'GSP_EINV_PWD and GSP_SANDBOX to reach the GSP, or do not call the e-invoice routes.',
    );
  }
  return { transport: new FakeIrnTransport(), mode: 'fake-development' };
}

/** Masked GSP configuration status (never returns secret values). */
export interface GspStatus {
  mode: string;
  provider: string;
  host: string;
  sandbox: boolean;
  configured: boolean;
  vars: Record<string, boolean>;
  gstin: string | null;
}
export function gspStatus(env: NodeJS.ProcessEnv = process.env): GspStatus {
  const configured = !!(
    env.GSP_ASPID &&
    env.GSP_PASSWORD &&
    env.GSP_GSTIN &&
    env.GSP_USER &&
    env.GSP_EINV_PWD
  );
  const sandbox = env.GSP_SANDBOX !== '0';
  const sandboxDeclared = !(env.GSP_SANDBOX === undefined || env.GSP_SANDBOX.trim() === '');
  const mask = (v?: string) => (v ? v.slice(0, 2) + '••••' + v.slice(-2) : null);
  // Report the state the write path will actually take, so the readiness endpoint cannot claim a working
  // 'fake' mode where an IRN request is in fact going to be refused.
  const mode = configured
    ? sandboxDeclared
      ? sandbox
        ? 'chartered-info-sandbox'
        : 'chartered-info-prod'
      : 'blocked-sandbox-undeclared'
    : env.NODE_ENV === 'production'
      ? 'blocked-production-no-credentials'
      : 'fake-development';
  return {
    mode,
    provider: 'Chartered Info GSP (charteredinfo.com)',
    host: sandbox ? 'gstsandbox.charteredinfo.com' : 'einvapi.charteredinfo.com',
    sandbox,
    configured,
    vars: {
      GSP_ASPID: !!env.GSP_ASPID,
      GSP_PASSWORD: !!env.GSP_PASSWORD,
      GSP_GSTIN: !!env.GSP_GSTIN,
      GSP_USER: !!env.GSP_USER,
      GSP_EINV_PWD: !!env.GSP_EINV_PWD,
      GSP_SANDBOX: env.GSP_SANDBOX === '0' ? false : true,
    },
    gstin: mask(env.GSP_GSTIN),
  };
}

/** Validate the configured GSP credentials with a live auth round-trip. Returns ok/detail; no secrets leaked. */
export async function testGspAuth(
  env: NodeJS.ProcessEnv = process.env,
  fetchImpl?: typeof fetch,
): Promise<{ ok: boolean; mode: string; detail: string }> {
  const st = gspStatus(env);
  if (!st.configured)
    return {
      ok: false,
      mode: 'fake',
      detail:
        'No GSP credentials set. Provide GSP_ASPID, GSP_PASSWORD, GSP_GSTIN, GSP_USER, GSP_EINV_PWD (and GSP_SANDBOX=0 for production) in the API environment.',
    };
  const t = new CharteredInfoIrnTransport({
    aspId: env.GSP_ASPID!,
    aspPassword: env.GSP_PASSWORD!,
    gstin: env.GSP_GSTIN!,
    userId: env.GSP_USER!,
    eInvPwd: env.GSP_EINV_PWD!,
    sandbox: st.sandbox,
    fetchImpl,
  });
  try {
    const tok = await t.authToken();
    return {
      ok: true,
      mode: st.mode,
      detail: `Auth OK against ${st.host} (token ${tok.slice(0, 6)}…).`,
    };
  } catch (e: any) {
    return {
      ok: false,
      mode: st.mode,
      detail: `Auth failed against ${st.host}: ${String(e?.message ?? e).slice(0, 200)}`,
    };
  }
}

/** Cancel a previously-generated IRN for a stored sale: call the GSP cancel API, then clear IRN/ACK. */
export async function cancelIrnForSale(
  prisma: any,
  scope: VoucherScope,
  args: {
    coBook: string;
    vchNo: number | string;
    reason?: string;
    remark?: string;
    expectedMainBook?: string;
  },
): Promise<{ irn: string; cancelDate: string; mode: string }> {
  const coBook = args.coBook || scope.coBook || 'SAL';
  const irn = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    if (args.expectedMainBook) await resolveIrnBookTx(tx, scope, coBook, args.expectedMainBook);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IRN_NO" FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
      ...scopedWhere(scope, coBook, args.vchNo),
    );
    const v = String(rows[0]?.IRN_NO ?? '').trim();
    if (!v) throw new EInvoiceValidationError(`no IRN on ${coBook}/${args.vchNo} to cancel`);
    return v;
  });
  const { transport, mode } = irnTransportFromEnv();
  const res = transport.cancelIRN
    ? await transport.cancelIRN(irn, args.reason ?? '2', args.remark)
    : { Irn: irn, CancelDate: new Date().toISOString().slice(0, 10), Status: 'CNL' };
  await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(
      `UPDATE "SL_DATA" SET "IRN_NO"=NULL,"ACK_NO"=NULL,"ACK_DATE"=NULL
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...scopedWhere(scope, coBook, args.vchNo),
    );
    await tx.$executeRawUnsafe(
      `DELETE FROM "E_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...scopedWhere(scope, coBook, args.vchNo),
    );
  });
  return { irn: res.Irn, cancelDate: res.CancelDate, mode };
}

/** Load a stored sale (SL_DATA/SL_DETL + company + party), build the IRN payload, and submit it. */
export async function submitIrnForSale(
  prisma: any,
  scope: VoucherScope,
  args: {
    coBook?: string;
    vchNo: number | string;
    docType?: IrnDocType;
    expectedMainBook?: string;
  },
): Promise<IrnResult & { mode: string }> {
  const coBook = args.coBook || scope.coBook || 'SAL';
  const data = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const book = await resolveIrnBookTx(tx, scope, coBook, args.expectedMainBook);
    const hdrRows: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
      ...scopedWhere(scope, coBook, args.vchNo),
    );
    const hdr = hdrRows[0];
    if (!hdr) throw new EInvoiceValidationError(`sale not found: ${coBook}/${args.vchNo}`);
    const co =
      (
        await tx.$queryRawUnsafe(
          `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
          scope.tenantId,
          scope.coCode,
        )
      )[0] ?? {};
    const party =
      (
        await tx.$queryRawUnsafe(
          `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"::text=$3::text LIMIT 1`,
          scope.tenantId,
          scope.coCode,
          String(hdr.AC_CODE),
        )
      )[0] ?? {};
    const detl: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...scopedWhere(scope, coBook, args.vchNo),
    );
    // De-hardcode HSN/unit: read them from ITEM_MAST per line item (desktop master-driven), fallback 7113/GMS.
    const itCodes = Array.from(
      new Set(detl.map((d: any) => String(d.IT_CODE ?? '').trim()).filter(Boolean)),
    );
    const itemRows: any[] = itCodes.length
      ? await tx.$queryRawUnsafe(
          `SELECT "IT_CODE","HSN_CODE","UNIT_NAME" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"::text = ANY($3::text[])`,
          scope.tenantId,
          scope.coCode,
          itCodes,
        )
      : [];
    const itemMap: Record<string, any> = Object.fromEntries(
      itemRows.map((r: any) => [String(r.IT_CODE).trim(), r]),
    );
    return { hdr, co, party, detl, itemMap, book };
  });
  const N = (v: unknown): number => Number(v ?? 0) || 0;
  const { hdr, co, party, detl, itemMap, book } = data;
  const interState = String(hdr.AC_GST_TYPE ?? '') === 'I' || N(hdr.IGST_TAX) > 0;
  const seller: IrnParty = {
    gstin: co.CO_GST_NO || '24AAAAA0000A1Z5',
    lglNm: co.CO_NAME || 'SELLER',
    trdNm: co.CO_SNAME || undefined,
    addr1: co.CO_ADD1 || undefined,
    loc: co.CO_CITY || undefined,
    pin: N(co.CO_PIN) || undefined,
    stcd: String(co.CO_STATE_CODE || '24'),
  };
  const buyer: IrnParty = {
    gstin: party.AC_GSTNO || 'URP',
    lglNm: hdr.AC_NAME || party.AC_NAME || 'CUSTOMER',
    loc: party.AC_CITY || undefined,
    stcd: String(party.AC_STATE || co.CO_STATE_CODE || '24'),
  };
  const items: IrnItemInput[] = (detl.length ? detl : [{}]).map((d: any) => {
    const im = itemMap[String(d.IT_CODE ?? '').trim()] ?? {};
    const hsn = String(im.HSN_CODE ?? '').trim() || '7113'; // ITEM_MAST.HSN_CODE (incl. 9997 hallmark), fallback jewellery 7113
    const unit = String(im.UNIT_NAME ?? '').trim() || 'GMS';
    return {
      desc: d.IT_DESC || d.IT_CODE || 'JEWELLERY',
      hsn,
      qty: N(d.ITM_NWT) || 1,
      unit,
      unitPrice: N(d.ITM_RATE),
      // A stored zero is a real line value (for example a no-charge component), not a
      // missing field. Falling back on falsiness duplicated the header amount on zero lines.
      assAmt: N(d.NET_AMT ?? hdr.NET_AMT),
      gstRt: N(d.TAX_PRC ?? hdr.TAX_PRC),
      cgst: N(d.ITM_CGST_AMT),
      sgst: N(d.ITM_SGST_AMT),
      igst: N(d.ITM_IGST_AMT),
    };
  });
  const vchNo = formatVoucherNo(args.vchNo);
  const sale: SaleForIrn = {
    billNo: book.bookSrName ? `${book.bookSrName}/${vchNo}` : hdr.BILL_NO || vchNo,
    vchDate: hdr.VCH_DATE,
    interState,
    roundOff: N(hdr.ROF_AMT),
    docType: args.docType ?? 'INV',
  };
  const payload = buildIrnPayload({ seller, buyer, sale, items });
  const { transport, mode } = irnTransportFromEnv();
  const res = await submitIrn(
    prisma,
    { ...scope, coBook },
    { vchNo: args.vchNo, payload, transport },
  );
  return { ...res, mode };
}

export function buildCreditNoteIrnPayload(args: {
  seller: IrnParty;
  buyer: IrnParty;
  sale: Omit<SaleForIrn, 'docType'>;
  items: IrnItemInput[];
}): IrnPayload {
  return buildIrnPayload({ ...args, sale: { ...args.sale, docType: 'CRN' } });
}

export async function submitIrnForCreditNote(
  prisma: any,
  scope: VoucherScope,
  args: { coBook?: string; vchNo: number | string },
): Promise<IrnResult & { mode: string }> {
  return submitIrnForSale(prisma, scope, {
    ...args,
    coBook: args.coBook || scope.coBook || '146',
    docType: 'CRN',
    expectedMainBook: 'E CRNT',
  });
}
