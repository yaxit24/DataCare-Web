import { it, expect } from 'vitest';
import { postingDataTypeTx } from '../src/modules/posting/dataType.js';
it('uses the B book slot for ledger and stock but preserves desktop literal-A tables', async () => {
  const tx = { $queryRawUnsafe: async () => [{ dataType: 'B' }] };
  const row = { CO_CODE: '01', LC_CODE: '01', CO_BOOK: '027' };
  for (const table of [
    'AC_DATA',
    'LEDR_AC_DATA',
    'FINE_DATA',
    'ROJ_MEL_DATA',
    'MAIN_STOCK',
    'BAR_DETL',
    'BAR_CAN_DETL',
  ])
    expect(await postingDataTypeTx(tx, 'test', table, row)).toBe('B');
  for (const table of ['BILL_OS_DATA', 'COMM_DATA', 'ITM_LOT_DETL', 'BUL_DATA', 'DG_GOLD_DATA'])
    expect(await postingDataTypeTx(tx, 'test', table, row)).toBe('A');
});
it('treats an unconfigured book as A and refuses ambiguous slots', async () => {
  expect(
    await postingDataTypeTx({ $queryRawUnsafe: async () => [] }, 'test', 'AC_DATA', {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_BOOK: '027',
    }),
  ).toBe('A');
  for (const rows of [[{ dataType: 'A' }, { dataType: 'B' }]]) {
    await expect(
      postingDataTypeTx({ $queryRawUnsafe: async () => rows }, 'test', 'AC_DATA', {
        CO_CODE: '01',
        LC_CODE: '01',
        CO_BOOK: '027',
      }),
    ).rejects.toThrow('book-data-type-unavailable');
  }
});

it('refuses with a typed 4xx, never a 500, and never defaults a row that names no book', async () => {
  const tx = { $queryRawUnsafe: async () => [{ dataType: 'A' }, { dataType: 'B' }] };
  const mixed = await postingDataTypeTx(tx, 'test', 'AC_DATA', {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_BOOK: '027',
  }).catch((e) => e);
  expect(mixed).toMatchObject({ name: 'BookDataTypeError', statusCode: 409 });
  for (const row of [{ CO_CODE: '01', LC_CODE: '01' }, { CO_CODE: '01', CO_BOOK: '027' }, {}]) {
    const missing = await postingDataTypeTx(tx, 'test', 'AC_DATA', row).catch((e) => e);
    expect(missing).toMatchObject({ message: 'book-data-type-missing-key', statusCode: 400 });
  }
});
