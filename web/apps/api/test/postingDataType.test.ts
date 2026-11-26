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
it('a book with no slots takes BOOK_DATA.DATA_TYPE (TR_SALE.cs:16105-16107), unknown -> A', async () => {
  const row = { CO_CODE: '01', LC_CODE: '01', CO_BOOK: '027' };
  // First query: BOOK_DETL (no slots); second: BOOK_DATA.
  const seq = (...answers: unknown[][]) => {
    const queue = [...answers];
    let calls = 0;
    return {
      tx: { $queryRawUnsafe: async () => (calls++, queue.shift() ?? []) },
      calls: () => calls,
    };
  };
  const b = seq([], [{ dataType: 'B' }]);
  expect(await postingDataTypeTx(b.tx, 'test', 'AC_DATA', row)).toBe('B');
  const unknown = seq([], []);
  expect(await postingDataTypeTx(unknown.tx, 'test', 'AC_DATA', row)).toBe('A');
  // One lookup per book per posting through the cache.
  const cached = seq([{ dataType: 'B' }]);
  const cache = new Map<string, string>();
  for (const table of ['AC_DATA', 'MAIN_STOCK', 'BAR_DETL'])
    expect(await postingDataTypeTx(cached.tx, 'test', table, row, cache)).toBe('B');
  expect(cached.calls()).toBe(1);
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

it('inside an A request, posting into a B book is refused; All and unknown books are not', async () => {
  const { runWithSessionDataType } = await import('../src/modules/auth/bookDataType.js');
  const { resolveBookPolicyTx } = await import('../src/modules/shared/bookPolicy.js');
  const row = { CO_CODE: '01', LC_CODE: '01', CO_BOOK: '027' };
  const session = (dataType: string) => ({ tenantId: 't', coCode: '01', lcCode: '01', dataType });
  const bSlots = { $queryRawUnsafe: async () => [{ dataType: 'B' }] };
  await expect(
    runWithSessionDataType(session('A'), () => postingDataTypeTx(bSlots, 't', 'AC_DATA', row)),
  ).rejects.toMatchObject({ name: 'BookDataTypeMismatchError', statusCode: 403 });
  expect(
    await runWithSessionDataType(session('B'), () => postingDataTypeTx(bSlots, 't', 'AC_DATA', row)),
  ).toBe('B');
  expect(
    await runWithSessionDataType(session('C'), () => postingDataTypeTx(bSlots, 't', 'AC_DATA', row)),
  ).toBe('B');
  // A book unknown to BOOK_DETL and BOOK_DATA is left to the writer.
  const none = { $queryRawUnsafe: async () => [] };
  expect(
    await runWithSessionDataType(session('B'), () => postingDataTypeTx(none, 't', 'AC_DATA', row)),
  ).toBe('A');
  // The shared book resolver (load, post and delete of a voucher) refuses the other type before anything else.
  const bBook = { $queryRawUnsafe: async () => [{ book: 'FSL', dataType: 'B' }] };
  await expect(
    runWithSessionDataType(session('A'), () =>
      resolveBookPolicyTx(
        bBook,
        { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2026', coBook: 'FSL' } as any,
        'SALES',
      ),
    ),
  ).rejects.toMatchObject({ name: 'BookDataTypeMismatchError' });
});
