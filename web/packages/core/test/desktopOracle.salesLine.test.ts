import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  fineFor,
  saleLineLabourAmount,
  lineTotalDesktop,
  resolveRoundingPolicy,
  round,
  PRECISION,
  saleAmountBasis,
  saleItemAmount,
  saleItemAmountRounded,
  vbVal,
  type LabourType,
  type RoundingPolicy,
} from '../src/index.js';

/**
 * Desktop oracle, family 1: the Sale line (WP-40 / WP-41 family 1, docs/parity/LITE-MASTER-PLAN.md §6 O2).
 *
 * `expected.json` is NOT written by hand. The `desktop-oracle.yml` workflow compiles
 * `web/scripts/desktop-oracle/sales-line/Oracle.cs` (TR_SALE.cs:9524-11891 `CommPassTotal`, verbatim) with the
 * .NET Framework 4.8 compiler on windows-latest, runs it on `vectors.json`, and uploads the result as an artifact.
 * The checked-in copy is that artifact, byte for byte; `source.runId` names the run.
 *
 * Each vector is one fresh sale-grid row. This test feeds the web's `@datacare/core` sale-line primitives the same
 * inputs and compares every stage. Each stage is fed the DESKTOP's upstream cells (net, ghat, fine, item amount),
 * so a disagreement is attributed to exactly one web function rather than cascading.
 *
 * The web composition mirrors the API's posting path (`apps/api/src/modules/sales/sales.ts` `computeLine`): the item
 * rate is rounded by `ITM_RATE_ROF`, the item and labour amounts are rounded by the company line precision, and the
 * labour charge is `saleLineLabourAmount` (core `labourCharge`, rounded once) in the web's labour vocabulary.
 */

const oracleDir = new URL('../../../scripts/desktop-oracle/sales-line/', import.meta.url);
const desktopSource = new URL(
  '../../../../unified/src/csharp/DataCareNext/TR_SALE.cs',
  import.meta.url,
);

interface Vector {
  id: string;
  col: number;
  settings?: Record<string, string | number>;
  checks: string[];
  passes?: number;
  cells: Record<string, string>;
}
interface Result {
  id: string;
  error?: string;
  msgBox?: string;
  cells: Record<string, string>;
}

const vectors = (
  JSON.parse(readFileSync(new URL('vectors.json', oracleDir), 'utf8')) as { vectors: Vector[] }
).vectors;
const expected = JSON.parse(readFileSync(new URL('expected.json', oracleDir), 'utf8')) as {
  family: string;
  source: { workflow: string; runId: string; commit: string; clr: string; method: string };
  results: Result[];
};
const byId = new Map(expected.results.map((r) => [r.id, r]));

/** A grid cell as the desktop reads it: `Conversion.Val` of its text, so "" is 0. */
const cell = (cells: Record<string, string>, col: number): number =>
  vbVal(cells[String(col)] ?? '');
const text = (cells: Record<string, string>, col: number): string =>
  (cells[String(col)] ?? '').trim().toUpperCase();

/**
 * The company settings the vector runs under, as the web resolves them. CommPassTotal never reads TOT_AMT_ROF (it
 * hardcodes 0, or 2 under ALL_ROF_REMOVE, TR_SALE.cs:10343-10362); the web rounds line amounts by TOT_AMT_ROF, so
 * the comparison uses 0, the value measured on the real customer database.
 */
function webPolicy(v: Vector): RoundingPolicy {
  const s = v.settings ?? {};
  return resolveRoundingPolicy({
    LBR_ROF: String(s.MsLbrRof ?? 2),
    ITM_RATE_ROF: String(s.MsItmRateRof ?? 2),
    TOT_AMT_ROF: '0',
    ALL_ROF_REMOVE: String(s.MsAllRofRemove ?? 'N'),
  });
}

/**
 * The desktop labour types the web vocabulary (`per_gram | per_piece | percentage | fixed`) can express. G (gross
 * weight), K (per kilogram) and blank (the default branch, which always adds ghat: TR_SALE.cs:11100) have no web
 * mode, so those vectors document the desktop and are not compared (see UNREPRESENTED below).
 */
const WEB_LABOUR_TYPE: Record<string, LabourType | undefined> = { N: 'per_gram', P: 'per_piece' };

type Stage = 'net' | 'ghat' | 'fine' | 'amount' | 'labour' | 'total';

/** The web's value for one stage, or undefined when the web has no counterpart for this vector. */
function webStage(v: Vector, stage: Stage, d: Record<string, string>): number | undefined {
  const s = v.settings ?? {};
  const policy = webPolicy(v);
  const input = v.cells;
  switch (stage) {
    case 'net':
      // ITM_NWT = ITM_GWT - ITM_OTH_WT, to 3 dp (TR_SALE.cs:10440).
      return round(cell(input, 12) - cell(input, 13), PRECISION.weight);
    case 'ghat':
      return undefined;
    case 'fine':
      return fineFor('sale', {
        netWt: cell(d, 14),
        ghtWt: cell(d, 17),
        touch: cell(input, 18),
        westPct: cell(input, 19),
      });
    case 'amount': {
      const rate = cell(input, 22);
      if (rate === 0) return 0;
      const basis = saleAmountBasis(
        {
          pcs: cell(input, 11),
          grossWt: cell(input, 12),
          netWt: cell(d, 14),
          ghtWt: cell(d, 17),
          fineWt: cell(d, 20),
        },
        text(input, 21),
        text(input, 58),
      );
      return basis.quantity > 0
        ? saleItemAmountRounded(basis, policy.roundItemRate(rate), policy)
        : 0;
    }
    case 'labour': {
      const pct = cell(input, 24);
      const withGhat = String(s.MsLbrWithGht ?? 'Y') !== 'N';
      const type: LabourType | undefined =
        pct !== 0 ? 'percentage' : WEB_LABOUR_TYPE[text(input, 25)];
      if (!type) return undefined;
      const rate = cell(input, 22);
      const basis = saleAmountBasis(
        {
          pcs: cell(input, 11),
          grossWt: cell(input, 12),
          netWt: cell(d, 14),
          ghtWt: cell(d, 17),
          fineWt: cell(d, 20),
        },
        text(input, 21),
        text(input, 58),
      );
      const metal =
        rate !== 0 && basis.quantity > 0 ? saleItemAmount(basis, policy.roundItemRate(rate)) : 0;
      const labour = saleLineLabourAmount(
        type,
        {
          netWt: cell(d, 14),
          ghatWt: cell(d, 17),
          withGhat,
          pcs: cell(input, 11),
          rate: cell(input, 26),
          pct,
          metalAmount: metal,
        },
        policy,
      );
      return labour;
    }
    case 'total':
      // SL_DETL.TOT_AMT, from the desktop's own components.
      return lineTotalDesktop({
        itemAmount: cell(d, 23),
        labourAmount: cell(d, 27),
        otherAmount: cell(d, 29),
      });
  }
}

/** The desktop cell each stage is compared with. */
const DESKTOP_COLUMN: Record<Stage, number> = {
  net: 14,
  ghat: 17,
  fine: 20,
  amount: 23,
  labour: 27,
  total: 35,
};

/**
 * Desktop behaviour the web has no input or output for. These vectors run in the oracle and their desktop values are
 * kept in expected.json as the specification, but there is no web value to compare.
 */
const UNREPRESENTED: Record<string, string> = {
  labourRate:
    'LBR_RATE derived from LBR_PRC lives in the API (labourDesktop.ts effectiveLabourRate), not in core',
  discount: 'the line labour discount (columns 31-33) has no core function',
  mrp: 'MRP lines (column 30) are priced by the desktop from the MRP; the web has no MRP pricing',
  ghat: 'ghat weight from ITM_GHT_PRC has no core function',
  taxInclusive:
    'a line TAX_PRC makes the desktop back NET_AMT out of a tax-inclusive line total (TR_SALE.cs:11596-11688); the web taxes at bill level only',
};

/**
 * Proven disagreements, each with the reason it is open. Rule 4 of the master plan: a failing case is baselined
 * with its finding and removed in the change that fixes it.
 */
const PCT_LABOUR =
  'OPEN, reported not fixed (changes posted labour on every percentage line): the desktop derives LBR_RATE = ' +
  'Math.Round(ITM_RATE x LBR_PRC / 100, LBR_ROF) (TR_SALE.cs:11021) and multiplies it by the LBR_TYPE basis ' +
  '(TR_SALE.cs:11084-11127); core labourCharge("percentage") takes LBR_PRC of the item amount instead';
const KNOWN_MISMATCHES: Record<string, string> = {
  'labour.pct.G.rtF:labour': PCT_LABOUR,
  'labour.pct.G.rtN:labour': PCT_LABOUR,
  'labour.pct.K.rtF:labour': PCT_LABOUR,
  'labour.pct.K.rtN:labour': PCT_LABOUR,
  'labour.pct.N.rtF:labour': PCT_LABOUR,
  'labour.pct.P.rtF:labour': PCT_LABOUR,
  'labour.pct.P.rtN:labour': PCT_LABOUR,
  'labour.pct.rof0:labour': PCT_LABOUR,
  'total.stone:total': 'FIXED in a following commit: the line total keeps paise',
};

describe('desktop oracle: sales line (TR_SALE.cs CommPassTotal)', () => {
  it('Oracle.cs carries TR_SALE.cs:9524-11891 verbatim, except the documented catch clause', () => {
    const desktop = readFileSync(desktopSource, 'utf8').split('\n').slice(9523, 11891);
    const oracle = readFileSync(new URL('Oracle.cs', oracleDir), 'utf8').split('\n');
    const begin = oracle.findIndex((l) => l.includes('===== BEGIN VERBATIM TR_SALE.cs:9524-11891'));
    const end = oracle.findIndex((l) => l.includes('===== END VERBATIM TR_SALE.cs:9524-11891'));
    const copy = oracle.slice(begin + 1, end);
    expect(copy.length).toBe(desktop.length);
    const changed = copy
      .map((line, i) => ({ line: 9524 + i, desktop: desktop[i]!.trim(), oracle: line.trim() }))
      .filter((x) => x.desktop !== x.oracle);
    expect(changed).toEqual([
      {
        line: 11875,
        desktop: 'catch (object obj) when (obj is Exception && num3 != 0 && num == 0)',
        oracle: 'catch (Exception obj)',
      },
      {
        line: 11876,
        desktop: '{',
        oracle: '{ if (!(obj is Exception && num3 != 0 && num == 0)) throw;',
      },
    ]);
  });

  it('expected.json is a workflow artifact covering every vector, with no runtime error', () => {
    expect(expected.family).toBe('sales-line');
    expect(expected.source.workflow).toBe('desktop-oracle.yml');
    expect(expected.source.runId).toMatch(/^\d+$/);
    expect(expected.source.clr).toMatch(/^4\.0\.30319/);
    expect(expected.results.map((r) => r.id)).toEqual(vectors.map((v) => v.id));
    expect(expected.results.filter((r) => r.error || r.msgBox)).toEqual([]);
  });

  it('every check names a stage the test knows', () => {
    const known = new Set([...Object.keys(DESKTOP_COLUMN), ...Object.keys(UNREPRESENTED)]);
    expect(vectors.flatMap((v) => v.checks.filter((c) => !known.has(c)))).toEqual([]);
  });

  it('the web matches the desktop on every comparable stage', () => {
    const mismatches: Record<string, string> = {};
    let compared = 0;
    for (const v of vectors) {
      const d = byId.get(v.id)!.cells;
      for (const check of v.checks) {
        if (!(check in DESKTOP_COLUMN)) continue;
        const stage = check as Stage;
        const web = webStage(v, stage, d);
        if (web === undefined) continue;
        compared += 1;
        const desk = cell(d, DESKTOP_COLUMN[stage]);
        if (Math.abs(web - desk) > 1e-9) {
          mismatches[`${v.id}:${stage}`] = `desktop ${d[String(DESKTOP_COLUMN[stage])]} web ${web}`;
        }
      }
    }
    expect(compared).toBeGreaterThan(300);
    expect(
      Object.fromEntries(Object.entries(mismatches).filter(([k]) => !(k in KNOWN_MISMATCHES))),
    ).toEqual({});
    // A baseline entry that no longer fails must be removed with the fix.
    expect(Object.keys(KNOWN_MISMATCHES).filter((k) => !(k in mismatches))).toEqual([]);
  });
});
