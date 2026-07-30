import { readdirSync, readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';

/**
 * VERIFIED PROVENANCE OF THE ALLOWLISTED FIELD GAPS (checked 2026-07-28):
 * every allowlisted TABLE.FIELD token was tested against the extracted DESKTOP production database
 * catalog (project-memory/catalogs/realdb-schema-full.json, 146 tables). Result:
 *   - 22 tokens name a table that does not exist in the desktop database at all
 *     (Crystal query aliases such as AC_MAST_LEDR / CO_BOOK, or legacy tables COMP_PARM, UNIT_NAME,
 *      DYBK_MAST, TABLE_MAST_MAIN, TRAN_DEDC),
 *   - 68 tokens name a column that does not exist on that desktop table either,
 *   - 0 tokens exist in the desktop database but are missing from the web schema.
 * So these are stale/legacy Crystal bindings that do not resolve on the desktop either - they are NOT
 * web parity gaps, and adding the columns to the web schema would be inventing data the desktop has
 * never stored. They are allowlisted here with that evidence rather than silently ignored.
 */

const TEST_DIR = dirname(fileURLToPath(import.meta.url));
const SPEC_DIR = resolve(TEST_DIR, '../report-specs');
const SCHEMA_PATH = resolve(TEST_DIR, '../../../packages/db/prisma/schema.prisma');

type TokenKind = 'database' | 'formula' | 'special' | 'unresolvable';
type ReportSpec = {
  report?: string;
  status?: string;
  areas?: Array<{ sections?: Array<{ objects?: Array<{ dataSource?: string }> }> }>;
  formulas?: Array<{ text?: string }>;
  error?: string;
};

/**
 * Known Crystal-to-Prisma contract gaps. Every entry remains a visible report-data gap;
 * the allowlist only prevents already-documented legacy aliases/absent columns from hiding
 * newly introduced unresolved tokens. Remove an entry as soon as its real mapped source exists.
 */
const UNRESOLVED_DATABASE_FIELD_ALLOWLIST: Readonly<Record<string, string>> = {
  'AC_DATA.DESCR':
    'AC_DATA exists, but DESCR is absent from the current Prisma model; schema/report contract gap.',
  'AC_DATA.ITM_FINE':
    'AC_DATA exists, but ITM_FINE is absent from the current Prisma model; schema/report contract gap.',
  'AC_DATA.ITM_GWT':
    'AC_DATA exists, but ITM_GWT is absent from the current Prisma model; schema/report contract gap.',
  'AC_GROUP.GR_CODE':
    'AC_GROUP exists, but GR_CODE is absent from the current Prisma model; schema/report contract gap.',
  'AC_MAST.AC_LSTNO':
    'AC_MAST exists, but AC_LSTNO is absent from the current Prisma model; schema/report contract gap.',
  'AC_MAST_1.AC_NAME': 'Crystal table alias for AC_MAST; AC_NAME exists on that mapped table.',
  'AC_MAST_ANG.AC_NAME': 'Crystal table alias for AC_MAST; AC_NAME exists on that mapped table.',
  'AC_MAST_LD.AC_NAME': 'Crystal table alias for AC_MAST; AC_NAME exists on that mapped table.',
  'AC_MAST_LEDR.AC_NAME': 'Crystal table alias for AC_MAST; AC_NAME exists on that mapped table.',
  'AC_MAST_REF_AC.AC_NAME': 'Crystal table alias for AC_MAST; AC_NAME exists on that mapped table.',
  'AD_MEMB.AC_LSTNO':
    'AD_MEMB exists, but AC_LSTNO is absent from the current Prisma model; schema/report contract gap.',
  'APR_DATA.BANK_NAME':
    'APR_DATA exists, but BANK_NAME is absent from the current Prisma model; schema/report contract gap.',
  'APR_DATA.CARD_AMT':
    'APR_DATA exists, but CARD_AMT is absent from the current Prisma model; schema/report contract gap.',
  'APR_DATA.CASH_AMT':
    'APR_DATA exists, but CASH_AMT is absent from the current Prisma model; schema/report contract gap.',
  'APR_DATA.CHQ_AMT':
    'APR_DATA exists, but CHQ_AMT is absent from the current Prisma model; schema/report contract gap.',
  'APR_DATA.CHQ_NO':
    'APR_DATA exists, but CHQ_NO is absent from the current Prisma model; schema/report contract gap.',
  'APR_DATA.TAX_PRC':
    'APR_DATA exists, but TAX_PRC is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DATA.BANK_NAME':
    'BAR_CAN_DATA exists, but BANK_NAME is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DATA.CARD_AMT':
    'BAR_CAN_DATA exists, but CARD_AMT is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DATA.CASH_AMT':
    'BAR_CAN_DATA exists, but CASH_AMT is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DATA.CHQ_AMT':
    'BAR_CAN_DATA exists, but CHQ_AMT is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DATA.CHQ_NO':
    'BAR_CAN_DATA exists, but CHQ_NO is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DATA.TAX_PRC':
    'BAR_CAN_DATA exists, but TAX_PRC is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DETL.DESIGN':
    'BAR_CAN_DETL exists, but DESIGN is absent from the current Prisma model; schema/report contract gap.',
  'BAR_CAN_DETL.MRP':
    'BAR_CAN_DETL exists, but MRP is absent from the current Prisma model; schema/report contract gap.',
  'BAR_IDTL.ITM_AMT':
    'BAR_IDTL exists, but ITM_AMT is absent from the current Prisma model; schema/report contract gap.',
  'BAR_IDTL.ITM_GWT':
    'BAR_IDTL exists, but ITM_GWT is absent from the current Prisma model; schema/report contract gap.',
  'BOOK_MAST.BOOK_NAME':
    'Crystal table alias for BOOK_DATA; BOOK_NAME exists on that mapped table.',
  'COMM_DATA.COM_GHT':
    'COMM_DATA exists, but COM_GHT is absent from the current Prisma model; schema/report contract gap.',
  'COMM_DATA.ITM_TOUCH':
    'COMM_DATA exists, but ITM_TOUCH is absent from the current Prisma model; schema/report contract gap.',
  'COMM_DATA.MEMB_AC_CODE':
    'COMM_DATA exists, but MEMB_AC_CODE is absent from the current Prisma model; schema/report contract gap.',
  'COMP_PARM.CO_ADD1':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'COMP_PARM.CO_ADD2':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'COMP_PARM.CO_ADD3':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'COMP_PARM.CO_CITY':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'CO_BOOK.BOOK_NAME': 'Crystal table alias for BOOK_DATA; BOOK_NAME exists on that mapped table.',
  'CO_MAST.CO_FAX':
    'CO_MAST exists, but CO_FAX is absent from the current Prisma model; schema/report contract gap.',
  'CUT_DATA.DISC_AMT':
    'CUT_DATA exists, but DISC_AMT is absent from the current Prisma model; schema/report contract gap.',
  'CUT_DATA.FINE_RATE':
    'CUT_DATA exists, but FINE_RATE is absent from the current Prisma model; schema/report contract gap.',
  'CUT_DETL.ITM_NWT':
    'CUT_DETL exists, but ITM_NWT is absent from the current Prisma model; schema/report contract gap.',
  'CUT_DETL.ITM_TOUCH':
    'CUT_DETL exists, but ITM_TOUCH is absent from the current Prisma model; schema/report contract gap.',
  'DHRN_REC_DATA.OS_AMOUNT':
    'DHRN_REC_DATA exists, but OS_AMOUNT is absent from the current Prisma model; schema/report contract gap.',
  'DYBK_MAST.BOOK_SNAME':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'FINE_DATA.ITM_KEY':
    'FINE_DATA exists, but ITM_KEY is absent from the current Prisma model; schema/report contract gap.',
  'INOUT_DATA.BANK_NAME':
    'INOUT_DATA exists, but BANK_NAME is absent from the current Prisma model; schema/report contract gap.',
  'INOUT_DATA.CARD_AMT':
    'INOUT_DATA exists, but CARD_AMT is absent from the current Prisma model; schema/report contract gap.',
  'INOUT_DATA.CASH_AMT':
    'INOUT_DATA exists, but CASH_AMT is absent from the current Prisma model; schema/report contract gap.',
  'INOUT_DATA.CHQ_AMT':
    'INOUT_DATA exists, but CHQ_AMT is absent from the current Prisma model; schema/report contract gap.',
  'INOUT_DATA.CHQ_NO':
    'INOUT_DATA exists, but CHQ_NO is absent from the current Prisma model; schema/report contract gap.',
  'INOUT_DATA.TAX_PRC':
    'INOUT_DATA exists, but TAX_PRC is absent from the current Prisma model; schema/report contract gap.',
  'ITEM_MAST_IDTL.IT_NAME':
    'Crystal table alias for ITEM_MAST; IT_NAME exists on that mapped table.',
  'LBR_DATA.BANK_NAME':
    'LBR_DATA exists, but BANK_NAME is absent from the current Prisma model; schema/report contract gap.',
  'LBR_ISU_DETL.ITM_SIGN':
    'LBR_ISU_DETL exists, but ITM_SIGN is absent from the current Prisma model; schema/report contract gap.',
  'MAIN_STOCK.CR_AMT':
    'MAIN_STOCK exists, but CR_AMT is absent from the current Prisma model; schema/report contract gap.',
  'MAIN_STOCK.DESCR':
    'MAIN_STOCK exists, but DESCR is absent from the current Prisma model; schema/report contract gap.',
  'MAIN_STOCK.DESIGN':
    'MAIN_STOCK exists, but DESIGN is absent from the current Prisma model; schema/report contract gap.',
  'MAIN_STOCK.FINE_WT':
    'MAIN_STOCK exists, but FINE_WT is absent from the current Prisma model; schema/report contract gap.',
  'MAIN_STOCK.IT_TYPE':
    'MAIN_STOCK exists, but IT_TYPE is absent from the current Prisma model; schema/report contract gap.',
  'MAIN_STOCK.SIGN':
    'MAIN_STOCK exists, but SIGN is absent from the current Prisma model; schema/report contract gap.',
  'MFG_DETL.OLD_LBR':
    'MFG_DETL exists, but OLD_LBR is absent from the current Prisma model; schema/report contract gap.',
  'PR_DETL.ITM_CGST_AMT':
    'PR_DETL exists, but ITM_CGST_AMT is absent from the current Prisma model; schema/report contract gap.',
  'PR_DETL.ITM_IGST_AMT':
    'PR_DETL exists, but ITM_IGST_AMT is absent from the current Prisma model; schema/report contract gap.',
  'PR_DETL.ITM_SGST_AMT':
    'PR_DETL exists, but ITM_SGST_AMT is absent from the current Prisma model; schema/report contract gap.',
  'PR_DETL.IT_TAX_AMT':
    'PR_DETL exists, but IT_TAX_AMT is absent from the current Prisma model; schema/report contract gap.',
  'PR_DETL.TAX_CODE':
    'PR_DETL exists, but TAX_CODE is absent from the current Prisma model; schema/report contract gap.',
  'RATE_CUT_DATA.CARD_AMT':
    'RATE_CUT_DATA exists, but CARD_AMT is absent from the current Prisma model; schema/report contract gap.',
  'RATE_CUT_DATA.CARD_REC_AMT':
    'RATE_CUT_DATA exists, but CARD_REC_AMT is absent from the current Prisma model; schema/report contract gap.',
  'RATE_CUT_DATA.CASH_AMT':
    'RATE_CUT_DATA exists, but CASH_AMT is absent from the current Prisma model; schema/report contract gap.',
  'RATE_CUT_DATA.CASH_REC_AMT':
    'RATE_CUT_DATA exists, but CASH_REC_AMT is absent from the current Prisma model; schema/report contract gap.',
  'RATE_CUT_DATA.CHQ_AMT':
    'RATE_CUT_DATA exists, but CHQ_AMT is absent from the current Prisma model; schema/report contract gap.',
  'RATE_CUT_DATA.CHQ_REC_AMT':
    'RATE_CUT_DATA exists, but CHQ_REC_AMT is absent from the current Prisma model; schema/report contract gap.',
  'ROJ_MEL_DATA.CR_WT':
    'ROJ_MEL_DATA exists, but CR_WT is absent from the current Prisma model; schema/report contract gap.',
  'SL_DATA.DR_AMT':
    'SL_DATA exists, but DR_AMT is absent from the current Prisma model; schema/report contract gap.',
  'SL_DATA.GL_LESS_WT':
    'SL_DATA exists, but GL_LESS_WT is absent from the current Prisma model; schema/report contract gap.',
  'SL_DATA.GL_NWT':
    'SL_DATA exists, but GL_NWT is absent from the current Prisma model; schema/report contract gap.',
  'SL_DATA.GOLD_NWT':
    'SL_DATA exists, but GOLD_NWT is absent from the current Prisma model; schema/report contract gap.',
  'SL_DATA.SILVER_NWT':
    'SL_DATA exists, but SILVER_NWT is absent from the current Prisma model; schema/report contract gap.',
  'SL_ORD_DETL.DESIGN':
    'SL_ORD_DETL exists, but DESIGN is absent from the current Prisma model; schema/report contract gap.',
  'TABLE_MAST_MAIN.TABLE_NAME':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'TAG_PRINT_DATA.DESIGN':
    'TAG_PRINT_DATA exists, but DESIGN is absent from the current Prisma model; schema/report contract gap.',
  'TAG_STOCK_PRINT.ITM_TOUCH':
    'TAG_STOCK_PRINT exists, but ITM_TOUCH is absent from the current Prisma model; schema/report contract gap.',
  'TAG_STOCK_PRINT.ITM_WEST':
    'TAG_STOCK_PRINT exists, but ITM_WEST is absent from the current Prisma model; schema/report contract gap.',
  'TAG_STOCK_PRINT.SIGN':
    'TAG_STOCK_PRINT exists, but SIGN is absent from the current Prisma model; schema/report contract gap.',
  'TAX_DATA.AC_GST_TYPE':
    'TAX_DATA exists, but AC_GST_TYPE is absent from the current Prisma model; schema/report contract gap.',
  'TAX_DATA.ADD_TAX_AMT':
    'TAX_DATA exists, but ADD_TAX_AMT is absent from the current Prisma model; schema/report contract gap.',
  'TRAN_DEDC.VCH_DESC':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'UNIT_NAME.CO_CITY':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'UNIT_NAME.CO_FAX':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'UNIT_NAME.CO_PHONE':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
  'UNIT_NAME.CO_PIN':
    'Crystal/desktop command or table is absent from the current Prisma schema; report data gap.',
};

function parsePrismaTables(schema: string): Map<string, Set<string>> {
  const tables = new Map<string, Set<string>>();
  for (const model of schema.matchAll(/^model\s+(\w+)\s*\{([\s\S]*?)^\}/gm)) {
    const [, modelName, body] = model;
    const mappedTable = body.match(/@@map\("([^"]+)"\)/)?.[1] ?? modelName;
    const columns = new Set<string>();
    for (const line of body.split('\n')) {
      if (line.trimStart().startsWith('@@')) continue;
      const field = line.match(/^\s*(\w+)\s+[^\s]+/);
      if (!field) continue;
      columns.add(line.match(/@map\("([^"]+)"\)/)?.[1] ?? field[1]);
    }
    tables.set(mappedTable.toUpperCase(), new Set([...columns].map((x) => x.toUpperCase())));
  }
  return tables;
}

function classify(token: string): TokenKind {
  if (/^\{[A-Za-z0-9_]+\.[A-Za-z0-9_]+\}$/.test(token)) return 'database';
  if (/^\{@[^{}]+\}$/.test(token)) return 'formula';
  if (
    /^(?:PageNumber|TotalPageCount|PrintDate|PrintTime|RecordNumber|RecordCount)$/i.test(token) ||
    /^\{[?#][^{}]+\}$/.test(token) ||
    /^(?:Sum|Count|DistinctCount|Average|Minimum|Maximum|Mode|Median|NthSmallest|NthLargest|StdDev|PopulationStdDev|Variance|PopulationVariance|RunningTotal|GroupName)\s*\(/i.test(
      token,
    )
  )
    return 'special';
  return 'unresolvable';
}

function databaseKey(token: string): string {
  return token.slice(1, -1).toUpperCase();
}

describe('Crystal report data-source contracts', () => {
  it('classifies every token and resolves every non-allowlisted database field to Prisma', () => {
    const files = readdirSync(SPEC_DIR)
      .filter((name) => name.endsWith('.spec.json') && name !== 'report-layouts-index.json')
      .sort();
    const sources = new Map<string, Set<string>>();
    const add = (token: string, file: string) => {
      const normalized = token.trim();
      if (!normalized) return;
      const found = sources.get(normalized) ?? new Set<string>();
      found.add(file);
      sources.set(normalized, found);
    };

    for (const file of files) {
      const spec = JSON.parse(readFileSync(resolve(SPEC_DIR, file), 'utf8')) as ReportSpec;
      expect(spec.error, `${file} is an extraction error stub`).toBeUndefined();
      expect(spec.areas?.length, `${file} has no report areas`).toBeGreaterThan(0);
      for (const area of spec.areas ?? []) {
        for (const section of area.sections ?? []) {
          for (const object of section.objects ?? []) {
            if (!object.dataSource) continue;
            add(object.dataSource, file);
            for (const match of object.dataSource.matchAll(/\{[A-Za-z0-9_]+\.[A-Za-z0-9_]+\}/g))
              add(match[0], file);
          }
        }
      }
      for (const formula of spec.formulas ?? []) {
        for (const match of (formula.text ?? '').matchAll(/\{[A-Za-z0-9_]+\.[A-Za-z0-9_]+\}/g))
          add(match[0], file);
      }
    }

    const classified: Record<TokenKind, string[]> = {
      database: [],
      formula: [],
      special: [],
      unresolvable: [],
    };
    for (const token of sources.keys()) classified[classify(token)].push(token);
    for (const tokens of Object.values(classified)) tokens.sort();

    const prisma = parsePrismaTables(readFileSync(SCHEMA_PATH, 'utf8'));
    const unresolvedDatabase = classified.database.filter((token) => {
      const [table, column] = databaseKey(token).split('.');
      return !prisma.get(table)?.has(column);
    });
    const unexpectedDatabase = unresolvedDatabase.filter(
      (token) => !(databaseKey(token) in UNRESOLVED_DATABASE_FIELD_ALLOWLIST),
    );
    const staleAllowlist = Object.keys(UNRESOLVED_DATABASE_FIELD_ALLOWLIST).filter(
      (token) => !unresolvedDatabase.some((candidate) => databaseKey(candidate) === token),
    );
    const readable = (tokens: string[]) =>
      tokens
        .map((token) => `- ${token} (${[...(sources.get(token) ?? [])].join(', ')})`)
        .join('\n');

    console.info(
      'REPORT_CONTRACT_TOTALS',
      JSON.stringify({
        specs: files.length,
        distinctTokens: sources.size,
        database: classified.database.length,
        formula: classified.formula.length,
        special: classified.special.length,
        unresolvable: classified.unresolvable.length,
        resolvedDatabase: classified.database.length - unresolvedDatabase.length,
        allowlistedDatabaseGaps: unresolvedDatabase.length,
      }),
    );

    expect(files).toHaveLength(254);
    expect(
      classified.unresolvable,
      `Unclassified Crystal tokens:\n${readable(classified.unresolvable)}`,
    ).toEqual([]);
    expect(
      unexpectedDatabase,
      `Database fields absent from Prisma and not allowlisted:\n${readable(unexpectedDatabase)}`,
    ).toEqual([]);
    expect(
      staleAllowlist,
      `Stale report-contract allowlist entries:\n${staleAllowlist.join('\n')}`,
    ).toEqual([]);
  });
});
