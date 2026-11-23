import { describe, expect, it } from 'vitest';
import * as rpAllModule from '../src/modules/reports/rpAll/index.js';
import { approvalReport as currentApprovalReport } from '../src/modules/reports/reportFamilyReports.js';

/**
 * WP-13: the "Approval Rpt" branch of RP_ALL as pure selection logic — no database, no browser.
 *
 * The desktop does not compute the A/B data-type predicate in the report; each of the three approval
 * click handlers appends it to the Crystal record-selection string when the session setting is A or B
 * (RP_ALL.cs:8186-8192, 8261-8267, 8336-8342). The web builder must do the same. The test drives the
 * approval builder through a fake Prisma client and inspects the parameterised SQL it issues, so the
 * expected predicate comes from the desktop rule and never from what the web returns.
 *
 * The driver prefers the shared rpAll engine's approval adapter once it exists (the WP-13 implementation
 * adds it beside `salesReport`), and falls back to the current reportFamilyReports builder while the
 * adapter is absent. The assertions are identical in both cases; only the source of the builder changes.
 */

const SCOPE = {
  tenantId: 'wp13-approval-selection',
  coCode: '01',
  lcCode: '01',
  coYear: '2026-27',
  fromDate: '2010-01-01',
  toDate: '2026-07-15',
  filters: {},
};

type Builder = (prisma: any, scope: any, options: any) => Promise<unknown>;
const rpAll = rpAllModule as unknown as Record<string, unknown>;
const builder: Builder =
  typeof rpAll.approvalReport === 'function'
    ? (rpAll.approvalReport as Builder)
    : (currentApprovalReport as Builder);

interface Selection {
  text: string;
  values: unknown[];
}

/** Run the builder with a fake tenant transaction and capture its one parameterised SELECT. */
async function selection(dataType?: string, mode = 'issue'): Promise<Selection> {
  let captured: Selection = { text: '', values: [] };
  const tx = {
    $executeRawUnsafe: async () => 1,
    $queryRawUnsafe: async (sql: unknown, ...values: unknown[]) => {
      captured = { text: String(sql), values };
      return [];
    },
  };
  const prisma = {
    $transaction: (fn: (t: typeof tx) => Promise<unknown>) => fn(tx),
  };
  const scope = {
    ...SCOPE,
    dataType,
    filters: { ...(dataType ? { dataType } : {}) },
  };
  await builder(prisma, scope, { mode });
  return captured;
}

describe('Approval Rpt selection builder (RP_ALL, three approval buttons)', () => {
  it('approval-report.filters.data-type-selection: A, B and blank/other append exactly the desktop DATA_TYPE predicate', async () => {
    const a = await selection('A');
    // RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}
    // RP_ALL.cs:8188 {{CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";}}
    expect(a.text, 'setting A must append the BOOK_DATA.DATA_TYPE predicate').toMatch(
      /DATA_TYPE"\s*=\s*\$\d+/,
    );
    expect(a.values, 'the predicate must be parameterised, not interpolated').toContain('A');

    const b = await selection('B');
    // RP_ALL.cs:8190 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}
    // RP_ALL.cs:8192 {{CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";}}
    expect(b.text, 'setting B must append the same predicate with B').toMatch(
      /DATA_TYPE"\s*=\s*\$\d+/,
    );
    expect(b.values).toContain('B');
    expect(b.values).not.toContain('A');

    for (const other of [undefined, '', 'X']) {
      const none = await selection(other);
      // RP_ALL.cs:8186 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}
      // RP_ALL.cs:8190 {{else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)}}
      expect(
        none.text,
        `setting ${JSON.stringify(other)} must append no DATA_TYPE predicate`,
      ).not.toMatch(/DATA_TYPE/);
    }
  });
});
