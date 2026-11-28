import { describe, expect, it } from 'vitest';
import {
  accountRefreshFamilies,
  ACCOUNT_REFRESH_VERIFIED,
} from '../src/modules/utilities/accountRefresh.js';

describe('Purchase account refresh rollout', () => {
  it('registers purchase for preview without granting apply', () => {
    expect(accountRefreshFamilies().find((f) => f.id === 'purchase')).toEqual({
      id: 'purchase',
      title: 'Purchase',
      operationId: 'data-refresh-account-purchase',
      verified: false,
    });
    expect(ACCOUNT_REFRESH_VERIFIED.has('purchase')).toBe(false);
  });
});

import { purchasePostingRole } from '../src/modules/purchase/purchaseRefresh.js';
import {
  purchasePostInput,
  type PurchasePostingSettings,
} from '../src/modules/purchase/purchasePosting.js';
import { resolveRoundingPolicy } from '../src/modules/shared/roundingPolicy.js';

const prefix = '01012024-2025PUR00001';
const h = {
  CO_CODE: '01',
  LC_CODE: '01',
  CO_YEAR: '2024-2025',
  CO_BOOK: 'PUR',
  VCH_NO: '00001',
  AC_CODE: 'SUP',
  AC_NAME: 'Supplier',
  VCH_DATE: '2024-05-10',
  VCH_TIME: '2024-05-10 14:23:45',
  NET_AMT: 100,
  DISC_AMT: 0,
  TAX_AMT: 3,
  CGST_TAX: 1.5,
  SGST_TAX: 1.5,
  IGST_TAX: 0,
  TCS_AMT: 0,
  ROF_AMT: 0,
  TOT_AMT: 103,
  BILL_OS: 103,
  TAX_PRC: 3,
  AC_GST_TYPE: 'L',
};
const d = {
  SR_NO: 1,
  IT_CODE: 'G',
  IT_TYPE: 'G',
  ITM_AMT: 100,
  LBR_AMT: 0,
  OTH_AMT: 0,
  TOT_AMT: 100,
  NET_AMT: 120,
  COMM_AMT: 20,
  ITM_FINE: 1,
};
const policy = resolveRoundingPolicy({ TOT_AMT_ROF: 0 });
const settings: PurchasePostingSettings = {
  vchType: 'PUR',
  bookName: 'PURCHASE',
  purchaseAc: 'PURAC',
  controlAc: 'CTRL',
  taxAc: 'GST',
  tcsAc: 'TCS',
  roundAc: 'ROUND',
  cashAc: 'CASH',
  kasarAc: 'ROUND',
  linePathBook: true,
  withLabour: true,
  purcAcByItem: { G: 'PURAC' },
  itemNameByItem: { G: 'Gold' },
  taxPolicy: {
    interState: false,
    accountGstType: 'L',
    taxCode: '10',
    taxGroup: 'GST',
    taxAc: 'GST',
    taxPct: 3,
    components: new Map(),
  },
  rojmelOptions: { withLabour: true, partyAccount: 'CTRL', taxAccount: 'GST' },
  ...policy,
};

describe('Purchase posting stored facts (Ac_Ledr.cs:377-476)', () => {
  it('decodes only exact complete role, item and fine keys', () => {
    expect(purchasePostingRole(prefix + '26', prefix)).toBe('role:26');
    expect(purchasePostingRole(prefix + '         103', prefix)).toBe('item:1');
    expect(purchasePostingRole(prefix + '         121', prefix)).toBe('fine:1');
    expect(purchasePostingRole(prefix + '54', prefix)).toBe('position:4');
    expect(purchasePostingRole(prefix + 'garbage26', prefix)).toBeNull();
    expect(purchasePostingRole('different' + prefix + '26', prefix)).toBeNull();
  });
  it('posts stored components without adding commission and keeps wall-clock timestamps', () => {
    const p = purchasePostInput(h, [d], settings);
    expect(p.ledger.lines.filter((l) => l.legType === 1).map((l) => l.CR_AMT)).toEqual([103]);
    expect(p.ledger.lines.filter((l) => l.legType === 3).map((l) => l.DR_AMT)).toEqual([100]);
    expect(
      p.ledger.lines.every((l) => l.VCH_DATE === h.VCH_DATE && l.ENTRY_TIME === h.VCH_TIME),
    ).toBe(true);
    expect(p.writes?.map((w) => w.table)).toEqual(['TAX_DATA', 'ROJ_MEL_DATA']);
  });
  it('uses stored TCS and typed round-off with an economic residue, never leg 99', () => {
    // TR_PURC.cs:15061-15095: 50 + 1.5 GST + 1 TCS = 52.5 -> half-even 52.
    const p = purchasePostInput(
      { ...h, NET_AMT: 50, TAX_AMT: 1.5, TCS_AMT: 1, TOT_AMT: 52, BILL_OS: 52 },
      [{ ...d, ITM_AMT: 50 }],
      settings,
    );
    expect(p.ledger.lines.find((l) => l.legType === 1)?.CR_AMT).toBe(52);
    expect(p.ledger.lines.find((l) => l.legType === 7)?.DR_AMT).toBe(1);
    expect(p.desktopRoundingResidue).toEqual({ amount: 0.5, bound: 0.5 });
    expect(p.ledger.lines.some((l) => l.legType === 99)).toBe(false);
  });
  it('rounds the stored net less discount at the original taxable stage', () => {
    const p = purchasePostInput(
      { ...h, NET_AMT: 100, DISC_AMT: 0.5, TAX_AMT: 0, TOT_AMT: 100 },
      [d],
      settings,
    );
    expect(p.ledger.lines.find((l) => l.legType === 3)?.DR_AMT).toBe(100);
  });
});

import { applyRepair } from '../src/modules/utilities/dataRepair.js';
it('refuses purchase apply before opening a database transaction', async () => {
  await expect(
    applyRepair(
      {},
      'data-refresh-account-purchase',
      {
        tenantId: 'synthetic',
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
      },
      { previewHash: 'unused', operator: 'test' } as any,
    ),
  ).rejects.toMatchObject({ code: 'preview-only' });
});
