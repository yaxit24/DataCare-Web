import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { nextHiddenVoucherNoTx } from '../vouchers/lifecycle.js';
import { postVoucherTx } from '../posting/posting.js';

/**
 * Melting / refining (TR_MLT_PRO): scrap/old ornaments are melted into pure metal. Per line the
 * accountable input fine = NWT × touch/100 (PARTY_FINE); recovered NET_FINE = explicit assay result
 * or input × (1 − loss%); LOSS_WT = PARTY_FINE − NET_FINE. Pure metal flow (MLT_DATA + MLT_DETL) —
 * no money ledger. Mirrors MLT_DETL columns.
 */
export class MeltingError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'MeltingError';
  }
}
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;
const num = (v: unknown): number => (v == null ? 0 : Number(v));

export interface MeltLine {
  itCode?: string;
  netWt: number;
  touch: number;
  recoveredFine?: number;
}

/**
 * Legacy one-grid web adapter retained until the two-grid persisted TR_MLT_PRO lifecycle is wired.
 * It is not the desktop formula contract; new work must use meltingParity.ts.
 */
export function meltLine(
  l: MeltLine,
  lossPct = 0,
): { partyFine: number; netFine: number; lossWt: number } {
  const partyFine = round3((num(l.netWt) * num(l.touch)) / 100);
  const netFine =
    l.recoveredFine != null
      ? round3(num(l.recoveredFine))
      : round3(partyFine * (1 - lossPct / 100));
  return { partyFine, netFine, lossWt: round3(partyFine - netFine) };
}

export interface MeltInput {
  scope: VoucherScope;
  acCode?: string;
  acName?: string;
  lossPct?: number;
  vchDate?: Date | string;
  lines: MeltLine[];
  /**
   * The operator saving the voucher.
   *
   * A melt destroys one item's weight and creates another's, and previously recorded NO acting user,
   * NO VCH_TIME and NO HD_VCH_NO — although MLT_DATA and MLT_DETL carry all three columns.
   */
  mainUser?: string;
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
function keyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'MLT',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export async function meltProcess(
  prisma: any,
  input: MeltInput,
): Promise<{ vchNo: number; inputFine: number; recoveredFine: number; lossFine: number }> {
  if (!input.lines?.length) throw new MeltingError('at least one melt line is required');
  const tenantId = input.scope.tenantId;
  const computed = input.lines.map((l) => ({ in: l, calc: meltLine(l, input.lossPct ?? 0) }));
  const inputFine = round3(computed.reduce((s, c) => s + c.calc.partyFine, 0));
  const recoveredFine = round3(computed.reduce((s, c) => s + c.calc.netFine, 0));
  const lossFine = round3(inputFine - recoveredFine);
  const totalNwt = round3(computed.reduce((s, c) => s + num(c.in.netWt), 0));
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();

  const vchNo = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const no = await nextVoucherNoTx(tx, { ...input.scope, coBook: 'MLT' });
    // The hidden series is per book; a melt always books to 'MLT'.
    const hdVchNo = await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: 'MLT' } as never);
    const key = keyOf(input.scope, no);
    const header = {
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: 'MELT',
      INOUT_TYPE: 'M',
      ENTRY_TYPE: 'N',
      AC_CODE: input.acCode ?? null,
      AC_NAME: input.acName ?? null,
      ISU_WT: totalNwt,
      MAIN_USER: input.mainUser ?? null,
      HD_VCH_NO: hdVchNo,
      VCH_TIME: vchDate,
    };
    const detl = computed.map((c, i) => ({
      ...key,
      VCH_TYPE: 'MELT',
      ENTRY_TYPE: 'N',
      SR_NO: i + 1,
      MAIN_USER: input.mainUser ?? null,
      HD_VCH_NO: hdVchNo,
      VCH_TIME: vchDate,
      IT_CODE: c.in.itCode ?? null,
      ITM_NWT: num(c.in.netWt),
      ITM_TOUCH: num(c.in.touch),
      PARTY_FINE: c.calc.partyFine,
      NET_FINE: c.calc.netFine,
      LOSS_WT: c.calc.lossWt,
    }));
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes: [
        { table: 'MLT_DATA', rows: [header] },
        { table: 'MLT_DETL', rows: detl },
      ],
    });
    return no;
  });
  return { vchNo, inputFine, recoveredFine, lossFine };
}
