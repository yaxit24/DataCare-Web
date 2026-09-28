import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  getDesignCalculationConfig,
  listDesignBook,
  saveDesignBook,
  type DesignBookLine,
} from '../src/modules/masters/designBook.js';
import type { DesignCalculationEvent } from '@datacare/core';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const scope = { tenantId: 'design-repeat-db', coCode: '01' };
const book = { bookName: 'REPEAT BOOK', prCode: 'RG' };
function first<T>(rows: readonly T[]): T {
  const value = rows[0];
  if (value === undefined) throw new Error('Missing fixture row');
  return value;
}
const business = (row: Record<string, unknown>) => {
  const { bookVersion: _version, ...values } = row;
  return values;
};

(enabled ? describe : describe.skip)(
  'X11 repeat and keyboard replay against stored snapshots',
  () => {
    const prisma = new PrismaClient();
    const read = () => listDesignBook(prisma, scope, book.bookName, book.prCode);
    const save = (lines: DesignBookLine[], expectedVersion?: string) =>
      saveDesignBook(prisma, { scope, ...book, lines, expectedVersion });
    async function cleanup() {
      await withTenant(prisma, scope.tenantId, async (tx) => {
        for (const table of ['DESIGN_IDTL', 'DESIGN_DETL', 'COL_MAST', 'ITEM_MAST'])
          await tx.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, scope.tenantId);
      });
    }
    beforeEach(async () => {
      await cleanup();
      await withTenant(prisma, scope.tenantId, async (tx) => {
        await tx.$executeRawUnsafe(
          "INSERT INTO \"ITEM_MAST\"(tenant_id,\"CO_CODE\",\"IT_CODE\",\"IT_TYPE\",\"CON_PRC\",\"OTH_RATE_TYPE\",\"OTH_RATE\") VALUES ($1,'01','STONE','S',0.2,'F',77.25),($1,'02','STONE','D',0.9,'F',999)",
          scope.tenantId,
        );
        for (const [bookName, name, label, visible] of [
          ['DESIGN DETL', 'GrWt', 'Customer gross', 'Y'],
          ['DESIGN DETL', 'TagCost', 'Private cost', 'N'],
          ['TAG_IDTL', 'ItCode', 'Stone item', 'Y'],
          ['TAG_IDTL', 'PcsWt', 'Each weight', 'Y'],
          ['TAG_IDTL', 'ItAmt', 'Stone amount', 'N'],
        ])
          await tx.$executeRawUnsafe(
            'INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO","COL_RPT") VALUES ($1,\'01\',$2,$3,$4,$5,\'Y\')',
            scope.tenantId,
            bookName,
            name,
            label,
            visible,
          );
      });
    });
    afterAll(async () => {
      await cleanup();
      await prisma.$disconnect();
    });
    async function seed() {
      await save(
        [
          {
            srNo: 17,
            oldSrNo: 42,
            designNo: 'IMPORTED',
            grossWt: 10,
            netWt: 7,
            fineWt: 3.333,
            amount: 91.17,
            otherAmount: 91,
            tagCost: 71.23,
            style: 'Legacy',
            components: [
              { isrNo: 3, itCode: 'STONE', pcsWt: 0.125, amount: null },
              { isrNo: 9, itCode: 'STONE', pcsWt: 0.251, amount: 17.29, netAmount: 55.37 },
            ],
          },
        ],
        'new',
      );
      return first(await read());
    }
    it('persists copied parent amounts without recalculation and leaves the source full snapshot and identity intact', async () => {
      const before = await seed();
      const config = await getDesignCalculationConfig(prisma, scope);
      await save(
        [
          { srNo: 17, designNo: 'IMPORTED' },
          {
            srNo: 23,
            oldSrNo: 23,
            designNo: 'COPIED',
            grossWt: 999,
            tagCost: 999,
            components: [],
            calculationVersion: config.version,
            calculationEvents: [
              { kind: 'repeatParent', values: { grossWt: '10', tagCost: '71.23' } },
            ],
          },
        ],
        String(before.bookVersion),
      );
      const rows = await read();
      expect(business(first(rows))).toEqual(business(before));
      const copied = rows.find((row) => row.SR_NO === 23);
      expect(copied).toBeDefined();
      expect(Number(copied?.ITM_GWT)).toBe(10);
      expect(Number(copied?.TAG_COST)).toBe(71.23);
      expect(Number(copied?.ITM_NWT)).toBe(0);
      expect(Number(copied?.ITM_FINE)).toBe(0);
      expect(copied?.DESIGN_IMG_ID).not.toBe(before.DESIGN_IMG_ID);
    });
    it('repeats the preceding component through the server policy with stable 3/9/10 serials and no aggregate refresh', async () => {
      const before = await seed();
      const config = await getDesignCalculationConfig(prisma, scope);
      await save(
        [
          {
            srNo: 17,
            designNo: 'IMPORTED',
            calculationVersion: config.version,
            calculationEvents: [
              { kind: 'addComponent', isrNo: 10 },
              { kind: 'repeatComponent', isrNo: 10, fromIsrNo: 9 },
            ],
            components: [
              { isrNo: 3, itCode: 'STONE' },
              { isrNo: 9, itCode: 'STONE' },
              { isrNo: 10, itCode: 'STONE', amount: 9999 },
            ],
          },
        ],
        String(before.bookVersion),
      );
      const after = first(await read());
      const children = after.components as Record<string, unknown>[];
      expect(children.map((row) => row.ISR_NO)).toEqual([3, 9, 10]);
      expect(children.slice(0, 2)).toEqual(before.components);
      expect(Number(children[2]?.IT_PCS_WT)).toBe(0.251);
      expect(Number(children[2]?.IT_AMT)).toBe(17.29);
      expect(Number(children[2]?.IT_NET_AMT)).toBe(0);
      expect(after.SR_NO).toBe(17);
      expect(after.OLD_SRNO).toBe(42);
      expect(Number(after.OTH_AMT)).toBe(91);
    });
    it('resolves Weight Enter fixed amount from the current scoped item and ignores caller defaults', async () => {
      const config = await getDesignCalculationConfig(prisma, scope);
      const events: DesignCalculationEvent[] = [
        { kind: 'addComponent', isrNo: 7 },
        { kind: 'item', isrNo: 7, itCode: 'STONE' },
        { kind: 'component', isrNo: 7, field: 'netAmount', value: 0 },
        {
          kind: 'componentEnter',
          isrNo: 7,
          field: 'grossWt',
          value: 2,
          defaults: { itType: 'X', conversionPct: 9, rateType: 'P', rate: 9999 },
        },
      ];
      await save(
        [
          {
            designNo: 'KEYBOARD',
            calculationVersion: config.version,
            calculationEvents: events,
            components: [{ isrNo: 7, itCode: 'STONE', netAmount: 9999 }],
          },
        ],
        'new',
      );
      const child = first(first(await read()).components as Record<string, unknown>[]);
      expect(child.IT_TYPE).toBe('S');
      expect(Number(child.IT_GWT)).toBe(2);
      expect(Number(child.IT_NET_AMT)).toBe(77.25);
      expect(Number(child.IT_RATE)).toBe(0);
    });
    it('rejects disabled/reserved repeat fields and repeat on an existing row without changing any saved business data', async () => {
      const before = await seed();
      const config = await getDesignCalculationConfig(prisma, scope);
      for (const event of [
        { kind: 'repeatParent', values: { grossWt: 20 } },
        { kind: 'repeatComponent', isrNo: 9, fromIsrNo: 3 },
      ] as DesignCalculationEvent[]) {
        await expect(
          save(
            [
              {
                srNo: 17,
                designNo: 'CHANGED',
                calculationVersion: config.version,
                calculationEvents: [event],
              },
            ],
            String(before.bookVersion),
          ),
        ).rejects.toThrow();
        expect(first(await read())).toEqual(before);
      }
      for (const values of [{ rate: 999 }, { srNo: 17 }, { grossWt: 'invalid' }]) {
        await expect(
          save(
            [
              { srNo: 17, designNo: 'IMPORTED' },
              {
                srNo: 23,
                designNo: 'INVALID',
                calculationVersion: config.version,
                calculationEvents: [{ kind: 'repeatParent', values }],
              },
            ],
            String(before.bookVersion),
          ),
        ).rejects.toThrow();
        expect(first(await read())).toEqual(before);
      }
    });
    it('discards an untouched temporary child while preserving the full loaded aggregate, including original serials', async () => {
      const before = await seed();
      const config = await getDesignCalculationConfig(prisma, scope);
      await save(
        [
          {
            srNo: 17,
            designNo: 'IMPORTED',
            calculationVersion: config.version,
            calculationEvents: [
              { kind: 'addComponent', isrNo: 10 },
              { kind: 'discardEmptyComponent', isrNo: 10 },
            ],
          },
        ],
        String(before.bookVersion),
      );
      expect(first(await read())).toEqual(before);
    });
    it('rejects invalid keyboard numbers and stale configuration before replacement', async () => {
      const before = await seed();
      const config = await getDesignCalculationConfig(prisma, scope);
      await expect(
        save(
          [
            {
              srNo: 17,
              designNo: 'INVALID',
              calculationVersion: config.version,
              calculationEvents: [
                { kind: 'componentEnter', isrNo: 9, field: 'netAmount', value: 'invalid' },
              ],
            },
          ],
          String(before.bookVersion),
        ),
      ).rejects.toThrow('finite');
      await expect(
        save(
          [
            {
              srNo: 17,
              designNo: 'INVALID',
              calculationVersion: 'old-policy',
              calculationEvents: [
                { kind: 'componentEnter', isrNo: 9, field: 'netAmount', value: 10 },
              ],
            },
          ],
          String(before.bookVersion),
        ),
      ).rejects.toThrow('settings changed');
      expect(first(await read())).toEqual(before);
    });
  },
);
