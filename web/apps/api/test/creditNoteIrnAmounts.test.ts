import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import {
  FakeIrnTransport,
  submitIrnForCreditNote,
  submitIrnForSale,
} from '../src/modules/einvoice/einvoice.js';

const scope = {
  tenantId: 'irn-amount-unit',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: '146',
};

/** Adapter-unit fixture only: SQL responses are explicit fixtures, transport is the existing
 * deterministic fake. The real scoped reads/writes have separate database tests. */
function storedDocument(lines: Array<Record<string, unknown>>, mainBook: string) {
  const tx = {
    $executeRawUnsafe: vi.fn(async () => 1),
    $queryRawUnsafe: vi.fn(async (sql: string) => {
      if (sql.includes('FROM "BOOK_DATA"')) return [{ MAIN_BOOK: mainBook, BOOK_SR_NAME: 'DOC' }];
      if (sql.includes('FROM "SL_DATA"'))
        return [
          {
            AC_CODE: 'BUYER',
            AC_NAME: 'Buyer',
            AC_GST_TYPE: 'I',
            NET_AMT: 100,
            TAX_PRC: 3,
            VCH_DATE: new Date('2024-07-01T00:00:00Z'),
          },
        ];
      if (sql.includes('FROM "CO_MAST"'))
        return [{ CO_GST_NO: '24ABCDE1234F1Z5', CO_NAME: 'Seller', CO_STATE_CODE: '24' }];
      if (sql.includes('FROM "AC_MAST"'))
        return [{ AC_GSTNO: '27ABCDE1234F1Z5', AC_NAME: 'Buyer', AC_STATE: '27' }];
      if (sql.includes('FROM "SL_DETL"'))
        return lines.map((line) => ({ IT_CODE: 'GOLD', ITM_NWT: 1, ITM_RATE: 100, ...line }));
      if (sql.includes('FROM "ITEM_MAST"'))
        return [{ IT_CODE: 'GOLD', HSN_CODE: '711319', UNIT_NAME: 'GMS' }];
      throw new Error(`Unexpected unit fixture query: ${sql}`);
    }),
  };
  return { $transaction: async (fn: (value: typeof tx) => unknown) => fn(tx) };
}

describe.each(['CRN', 'INV'] as const)('stored %s IRN amount adapter preserves zero', (family) => {
  const submit = (lines: Array<Record<string, unknown>>) => {
    const mainBook = family === 'CRN' ? 'E CRNT' : 'SALES';
    const prisma = storedDocument(lines, mainBook);
    return family === 'CRN'
      ? submitIrnForCreditNote(prisma, scope, { vchNo: '00001' })
      : submitIrnForSale(prisma, scope, { vchNo: '00001', expectedMainBook: mainBook });
  };
  beforeEach(() => {
    vi.stubEnv('NODE_ENV', 'test');
    for (const key of [
      'GSP_ASPID',
      'GSP_PASSWORD',
      'GSP_GSTIN',
      'GSP_USER',
      'GSP_EINV_PWD',
      'GSP_SANDBOX',
    ])
      vi.stubEnv(key, undefined);
    vi.stubGlobal(
      'fetch',
      vi.fn(() => {
        throw new Error('No network calls are allowed in this adapter unit test');
      }),
    );
  });
  afterEach(() => {
    vi.restoreAllMocks();
    vi.unstubAllEnvs();
    vi.unstubAllGlobals();
  });

  it('keeps mixed100/0 line totals at100 and preserves the zero line GST rate', async () => {
    const generated = vi.spyOn(FakeIrnTransport.prototype, 'generateIRN');
    const result = await submit([
      { NET_AMT: 100, TAX_PRC: 3, ITM_IGST_AMT: 3 },
      { NET_AMT: 0, TAX_PRC: 0, ITM_IGST_AMT: 0 },
    ]);
    expect(result.mode).toBe('fake-development');
    expect(generated).toHaveBeenCalledTimes(1);
    const payload = generated.mock.calls[0]![0];
    expect(payload.DocDtls.Typ).toBe(family);
    expect(payload.ItemList.map((line) => [line.AssAmt, line.GstRt])).toEqual([
      [100, 3],
      [0, 0],
    ]);
    expect(payload.ValDtls.AssVal).toBe(100);
    expect(payload.ValDtls.TotInvVal).toBe(103);
    expect(fetch).not.toHaveBeenCalled();
  });

  it.each([
    { name: 'explicit zero', value: 0, amount: 0, rate: 0 },
    { name: 'null', value: null, amount: 100, rate: 3 },
    { name: 'absent', value: undefined, amount: 100, rate: 3 },
  ])(
    'distinguishes $name detail values from missing header fallbacks',
    async ({ value, amount, rate }) => {
      const generated = vi.spyOn(FakeIrnTransport.prototype, 'generateIRN');
      const request = submit([{ NET_AMT: value, TAX_PRC: value }]);
      if (value === 0) {
        // Existing validation rejects an entirely zero-total document. It must not become a
        // chargeable header-total document merely because zero was treated as missing.
        await expect(request).rejects.toThrow('ValDtls.TotInvVal');
        expect(generated).not.toHaveBeenCalled();
        expect(fetch).not.toHaveBeenCalled();
        return;
      }
      await request;
      const payload = generated.mock.calls[0]![0];
      expect(payload.DocDtls.Typ).toBe(family);
      expect(payload.ItemList[0]).toMatchObject({ AssAmt: amount, GstRt: rate });
      expect(payload.ValDtls.AssVal).toBe(amount);
      expect(fetch).not.toHaveBeenCalled();
    },
  );
});
