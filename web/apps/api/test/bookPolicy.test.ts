import { describe, expect, it } from 'vitest';
import {
  BookPolicyValidationError,
  resolveBookAccountTx,
  resolveBookPolicyTx,
} from '../src/modules/shared/bookPolicy.js';

const scope = {
  tenantId: 'tenant',
  coCode: '01',
  lcCode: '01',
  coYear: '2024',
  coBook: '001',
};

const row = (MAIN_BOOK: string, BOOK_INOUT: string) => ({
  CO_BOOK: '001',
  BOOK_SNAME: 'VCH',
  BOOK_NAME: 'Display name',
  MAIN_BOOK,
  BOOK_INOUT,
});

describe('book policy', () => {
  it.each([
    ['SALES', 'SALES', 'O'],
    ['PURCHASE', 'PURCHASE', 'I'],
    ['SALES RETURN', 'SALES RETURNE', 'I'],
    ['WHOLESALE SALE RETURN', 'WH RTN', 'I'],
    ['PURCHASE RETURN', 'PURC RETURN', 'O'],
  ] as const)('resolves %s from desktop BOOK_DATA', async (workflow, mainBook, inout) => {
    const tx = { $queryRawUnsafe: async () => [row(mainBook, inout)] };
    await expect(resolveBookPolicyTx(tx, scope, workflow)).resolves.toEqual({
      coBook: '001',
      vchType: 'VCH',
      bookName: mainBook,
      mainBook,
      inout,
    });
  });

  it('rejects missing, ambiguous, wrong-main-book, and wrong-direction books', async () => {
    await expect(
      resolveBookPolicyTx({ $queryRawUnsafe: async () => [] }, scope, 'SALES'),
    ).rejects.toBeInstanceOf(BookPolicyValidationError);
    await expect(
      resolveBookPolicyTx(
        { $queryRawUnsafe: async () => [row('SALES', 'O'), row('SALES', 'O')] },
        scope,
        'SALES',
      ),
    ).rejects.toBeInstanceOf(BookPolicyValidationError);
    await expect(
      resolveBookPolicyTx({ $queryRawUnsafe: async () => [row('PURCHASE', 'O')] }, scope, 'SALES'),
    ).rejects.toBeInstanceOf(BookPolicyValidationError);
    await expect(
      resolveBookPolicyTx({ $queryRawUnsafe: async () => [row('SALES', 'I')] }, scope, 'SALES'),
    ).rejects.toBeInstanceOf(BookPolicyValidationError);
  });

  it('returns exactly one configured BOOK_DETL account and rejects missing/duplicate rows', async () => {
    const policy = await resolveBookPolicyTx(
      { $queryRawUnsafe: async () => [row('SALES', 'O')] },
      scope,
      'SALES',
    );
    await expect(
      resolveBookAccountTx(
        { $queryRawUnsafe: async () => [{ AC_CODE: '00001' }] },
        scope,
        policy,
        1,
      ),
    ).resolves.toBe('00001');
    await expect(
      resolveBookAccountTx({ $queryRawUnsafe: async () => [] }, scope, policy, 1),
    ).rejects.toBeInstanceOf(BookPolicyValidationError);
    await expect(
      resolveBookAccountTx(
        { $queryRawUnsafe: async () => [{ AC_CODE: '00001' }, { AC_CODE: '00002' }] },
        scope,
        policy,
        1,
      ),
    ).rejects.toBeInstanceOf(BookPolicyValidationError);
  });
});
