import { describe, expect, it } from 'vitest';
import {
  resolveTaxPolicyTx,
  TransactionTaxValidationError,
} from '../src/modules/shared/taxPolicy.js';

const scope = {
  tenantId: 'tenant',
  coCode: '01',
  lcCode: '01',
  coYear: '2024',
  coBook: 'SAL',
};

describe('transaction tax policy', () => {
  it('derives inter-state and tax identity from AC_MAST/TAX_MAST', async () => {
    const answers = [
      [{ gst_type: 'I' }],
      [{ tax_code: '10', tax_group: 'G', tax_ac: 'GSTOUT', tax_pct: 3 }],
    ];
    const tx = { $queryRawUnsafe: async () => answers.shift() };
    await expect(resolveTaxPolicyTx(tx, scope, { acCode: 'CUST', taxPct: 3 })).resolves.toEqual({
      interState: true,
      accountGstType: 'I',
      taxCode: '10',
      taxGroup: 'G',
      taxAc: 'GSTOUT',
      taxPct: 3,
    });
  });

  it('fails when the account or tax mapping is absent', async () => {
    const noAccount = { $queryRawUnsafe: async () => [] };
    await expect(
      resolveTaxPolicyTx(noAccount, scope, { acCode: 'MISSING', taxPct: 3 }),
    ).rejects.toBeInstanceOf(TransactionTaxValidationError);

    const answers = [[{ gst_type: 'L' }], []];
    const noTax = { $queryRawUnsafe: async () => answers.shift() };
    await expect(
      resolveTaxPolicyTx(noTax, scope, { acCode: 'CUST', taxPct: 3 }),
    ).rejects.toBeInstanceOf(TransactionTaxValidationError);
  });
});
