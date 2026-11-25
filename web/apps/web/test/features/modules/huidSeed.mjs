import { SECOND_TENANT } from '../harness.mjs';
/**
 * Seed for the HuId Report browser cases (RP_HUID.cs, /reports/huid). Data: orchestration/work/WP-18/cases.md "Test data"
 * (lines 896-937). Codes are shortened to the schema widths (migration 20260627200423_init); spec names are the display names:
 * IT_CODE GD-RING GDR, GD-CHAIN GDC, SV-CHAIN SVC; PR_CODE PR-RING RG, PR-CHAIN CH; GR_CODE GR-PLAIN PLN, GR-LINK LNK, GR-SILV SLV.
 * The row labelled TG-008 has TAG_NO 'N'. MISSING: metal type G is not set here (Gold default depends on the catalogue);
 * accounts V1, V2, K1, K2 have no spec names and are named 'TEST ACCOUNT <code>'. Cleanup removes only the rows it wrote.
 */
const CO = '01';
/**
 * Dedicated location. The browser runner shares one database across about 45 modules and every other module seeds
 * company 01, location 01 in the current year; a HuId grid at location 01 would list their tags. The huid-report
 * session signs in at this location (huidUser) and the seed writes its rows here, so the report returns exactly the
 * rows seeded. Location 01 is not filtered out: it stays the "other location" the report must exclude.
 */
export const HUID_LC = '09';
const LC = HUID_LC;
const YEAR = '2026-2027';
/** Credentials for a huid-report session: the user at the dedicated location (the real Open Company selector). */
export const huidUser = (user) => ({
  user,
  location: HUID_LC,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

/** Origin tags: one BAR_DETL row and one '+' MAIN_STOCK row each. `mv` adds sales ('-') and returns ('+'). hm: slot -> [value, weight]. */
export const HUID_TAGS = [
  {
    tag: 'TG-001',
    n: 1,
    it: 'GDR',
    d: '2026-04-10',
    s: '2026-04-10',
    sr: 1,
    ctr: 'C1',
    pcs: 1,
    g: '10.000',
    nw: '9.500',
    ac: 'V1',
    hm: { 1: ['HU0001', '0.500'] },
  },
  {
    tag: 'TG-002',
    n: 2,
    it: 'GDC',
    d: '2026-04-12',
    s: '2026-04-12',
    sr: 2,
    ctr: 'C1',
    pcs: 2,
    g: '20.000',
    nw: '19.000',
    ac: 'V2',
    hm: {},
  },
  {
    tag: 'TG-003',
    n: 3,
    it: 'GDR',
    d: '2026-04-15',
    s: '2026-04-15',
    sr: 3,
    ctr: 'C2',
    pcs: 1,
    g: '8.000',
    nw: '7.800',
    ac: 'V2',
    hm: { 2: ['HU0003', '0.300'] },
  },
  {
    tag: 'TG-004',
    n: 4,
    it: 'GDR',
    d: '2026-04-16',
    s: '2026-04-16',
    sr: 4,
    ctr: 'C1',
    pcs: 1,
    g: '5.000',
    nw: '4.900',
    ac: 'V2',
    hm: { 1: ['   ', '0.000'] },
  },
  {
    tag: 'TG-005',
    n: 5,
    it: 'GDR',
    d: '2026-04-20',
    s: '2026-04-20',
    sr: 5,
    ctr: 'C1',
    pcs: 1,
    g: '6.000',
    nw: '5.800',
    ac: 'V2',
    hm: { 1: ['HU0005', '0.400'] },
    mv: [['-', '2026-04-25', 'K1', 'HUIDS5']],
  },
  {
    tag: 'TG-006',
    n: 6,
    it: 'GDR',
    d: '2026-04-22',
    s: '2026-04-22',
    sr: 6,
    ctr: 'C2',
    pcs: 1,
    g: '4.000',
    nw: '3.900',
    ac: 'V2',
    hm: { 1: ['HU0006', '0.200'] },
    mv: [
      ['-', '2026-04-26', 'K2', 'HUIDS6'],
      ['+', '2026-04-28', 'K2', 'HUIDR6'],
    ],
  },
  {
    tag: 'TG-007',
    n: 7,
    it: 'SVC',
    d: '2026-05-05',
    s: '2026-05-05',
    sr: 7,
    ctr: 'C1',
    pcs: 3,
    g: '30.000',
    nw: '29.000',
    ac: 'V2',
    hm: { 1: ['HS0007', '1.000'] },
  },
  {
    tag: 'N',
    n: 8,
    it: 'GDR',
    d: '2026-05-06',
    s: '2026-05-06',
    sr: 8,
    ctr: 'C1',
    pcs: 1,
    g: '2.000',
    nw: '2.000',
    ac: 'V2',
    hm: {},
  },
  {
    tag: 'TG-009',
    n: 9,
    it: 'GDR',
    d: '2025-05-10',
    s: '2025-05-10',
    sr: 9,
    ctr: 'C1',
    pcs: 1,
    g: '7.000',
    nw: '6.900',
    ac: 'V2',
    hm: {},
    yr: '2025-2026',
  },
  {
    tag: 'TG-010',
    n: 10,
    it: 'GDR',
    d: '2026-05-20',
    s: '2026-07-15',
    sr: 10,
    ctr: 'C1',
    pcs: 1,
    g: '3.000',
    nw: '2.900',
    ac: 'V2',
    hm: { 2: ['HU0010', '0.100'] },
  },
  {
    tag: 'TG-011',
    n: 11,
    it: 'GDR',
    d: '2026-04-02',
    s: '2026-04-02',
    sr: 11,
    ctr: 'C1',
    pcs: 1,
    g: '9.000',
    nw: '8.900',
    ac: 'V2',
    hm: { 1: ['HU0011', '0.600'] },
  },
  {
    tag: 'TG-012',
    n: 12,
    it: 'GDR',
    d: '2026-05-25',
    s: '2026-05-25',
    sr: 0,
    ctr: 'C1',
    pcs: 1,
    g: '1.000',
    nw: '1.000',
    ac: 'V2',
    hm: {},
  },
  {
    tag: 'TG-013',
    n: 13,
    it: 'GDC',
    d: '2026-04-18',
    s: '2026-04-18',
    sr: 13,
    ctr: 'C2',
    pcs: 1,
    g: '12.000',
    nw: '11.500',
    ac: 'V2',
    hm: { 4: ['HU0013', '0.250'] },
  },
  {
    tag: 'TG-014',
    n: 14,
    it: 'GDR',
    d: '2026-04-01',
    s: '2026-04-01',
    sr: 14,
    ctr: 'C1',
    pcs: 1,
    g: '1.000',
    nw: '0.950',
    ac: 'V2',
    hm: {},
  },
  {
    tag: 'TG-015',
    n: 15,
    it: 'GDC',
    d: '2026-06-30',
    s: '2026-06-30',
    sr: 15,
    ctr: 'C1',
    pcs: 1,
    g: '2.000',
    nw: '1.900',
    ac: 'V2',
    hm: {},
  },
  {
    tag: 'TG-016',
    n: 16,
    it: 'GDR',
    d: '2026-07-05',
    s: '2026-06-30',
    sr: 16,
    ctr: 'C1',
    pcs: 1,
    g: '1.000',
    nw: '0.900',
    ac: 'V2',
    hm: {},
  },
];

/** Sentinels: other company (TG-S1), other location 01 (TG-S2), other tenant (TG-S3). Never in the company 01 window. */
export const SENTINEL_TAGS = [
  {
    tag: 'TG-S1',
    n: 'X1',
    co: '02',
    it: 'GDR',
    d: '2026-04-10',
    s: '2026-04-10',
    sr: 21,
    ctr: 'C1',
    pcs: 1,
    g: '1.000',
    nw: '1.000',
    ac: 'V1',
    hm: { 1: ['HUS001', '0.100'] },
    mv: [['-', '2026-04-26', 'K1', 'HUIDX4']],
  },
  {
    tag: 'TG-S2',
    n: 'X2',
    lc: '01',
    it: 'GDR',
    d: '2026-04-10',
    s: '2026-04-10',
    sr: 22,
    ctr: 'C1',
    pcs: 1,
    g: '1.000',
    nw: '1.000',
    ac: 'V1',
    hm: { 1: ['HUS002', '0.100'] },
  },
  {
    tag: 'TG-S3',
    n: 'X3',
    other: true,
    it: 'GDR',
    d: '2026-04-10',
    s: '2026-04-10',
    sr: 23,
    ctr: 'C1',
    pcs: 1,
    g: '1.000',
    nw: '1.000',
    ac: 'V1',
    hm: { 1: ['HUT001', '0.100'] },
  },
];

const ALL = [...HUID_TAGS, ...SENTINEL_TAGS];
const vchOf = (r) => 'HUID' + (typeof r.n === 'number' ? String(r.n).padStart(3, '0') : r.n);
const CODES = ALL.flatMap((r) => [vchOf(r), ...(r.mv ?? []).map((m) => m[3])]);
const TAGS = ALL.map((r) => r.tag);

const ITEMS = [
  ['GDR', 'GD-RING', 'G', 'RG', 'PLN'],
  ['GDC', 'GD-CHAIN', 'G', 'CH', 'LNK'],
  ['SVC', 'SV-CHAIN', 'S', 'CH', 'SLV'],
];
const PRODUCTS = [
  ['RG', 'PR-RING'],
  ['CH', 'PR-CHAIN'],
];
const GROUPS = [
  ['PLN', 'GR-PLAIN'],
  ['LNK', 'GR-LINK'],
  ['SLV', 'GR-SILV'],
];
const ACCOUNTS = [
  ['V1', 'TEST ACCOUNT V1'],
  ['V2', 'TEST ACCOUNT V2'],
  ['K1', 'TEST ACCOUNT K1'],
  ['K2', 'TEST ACCOUNT K2'],
];

const insert = (db, table, row) => {
  const keys = Object.keys(row);
  const cols = keys.map((k) => `"${k}"`).join(',');
  const marks = keys.map((_, i) => `$${i + 1}`).join(',');
  return db.$executeRawUnsafe(
    `INSERT INTO "${table}"(${cols}) VALUES (${marks})`,
    ...keys.map((k) => row[k]),
  );
};

function barRow(tenant, r) {
  const row = {
    tenant_id: tenant,
    CO_CODE: r.co ?? CO,
    LC_CODE: r.lc ?? LC,
    CO_YEAR: r.yr ?? YEAR,
    CO_BOOK: 'TOP',
    VCH_NO: vchOf(r),
    SR_NO: 1,
    VCH_DATE: r.d,
    STK_DATE: r.s,
    VCH_TYPE: 'OPN',
    BOOK_NAME: 'TAG OPENING',
    AC_CODE: r.ac,
    IT_CODE: r.it,
    TAG_NO: r.tag,
    TBL_CODE: r.ctr,
    ITM_PCS: r.pcs,
    ITM_GWT: r.g,
    ITM_NWT: r.nw,
    VCH_SRNO: r.sr,
    DATA_TYPE: 'C',
  };
  for (const k of [1, 2, 3, 4]) {
    const [value, weight] = r.hm[k] ?? [null, null];
    row[k === 1 ? 'HM_ID' : `HM_ID${k}`] = value;
    row[k === 1 ? 'HM_ID_WT' : `HM_ID${k}_WT`] = weight;
  }
  return row;
}

/** One MAIN_STOCK movement; sales and returns copy the tag's pcs and weights, as the seed description requires. */
const stockRow = (tenant, r, [sign, date, acct, vch]) => ({
  tenant_id: tenant,
  CO_CODE: r.co ?? CO,
  LC_CODE: r.lc ?? LC,
  CO_YEAR: r.yr ?? YEAR,
  CO_BOOK: 'TOP',
  VCH_NO: vch,
  SR_NO: 1,
  VCH_DATE: date,
  STK_DATE: r.s,
  VCH_TYPE: vch === vchOf(r) ? 'OPN' : 'STK',
  BOOK_NAME: 'TAG OPENING',
  AC_CODE: acct,
  IT_CODE: r.it,
  TAG_NO: r.tag,
  TBL_CODE: r.ctr,
  TR_TYPE: 'P',
  ITM_SIGN: sign,
  ITM_PCS: r.pcs,
  ITM_GWT: r.g,
  ITM_NWT: r.nw,
  VCH_SRNO: r.sr,
  DATA_TYPE: 'C',
});

/** Inserts the masters (items upserted; products, groups and accounts added only when absent) and the test rows. */
export async function seedHuid(ctx) {
  await cleanHuid(ctx);
  const db = ctx.owner;
  const t = ctx.tenantId;
  // The dedicated location must exist for the Open Company selector; cleanHuid removes it again.
  await db.$executeRawUnsafe(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") SELECT $1::text,'01',$2::text,'E2E HUID LOCATION' WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "LC_CODE"=$2::text)`,
    t,
    HUID_LC,
  );
  for (const [code, name, type, pr, gr] of ITEMS) {
    await db.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE") VALUES ($1,'01',$2,$3,$4,$5,$6) ON CONFLICT (tenant_id,"CO_CODE","IT_CODE") DO UPDATE SET "IT_NAME"=EXCLUDED."IT_NAME","IT_TYPE"=EXCLUDED."IT_TYPE","PR_CODE"=EXCLUDED."PR_CODE","GR_CODE"=EXCLUDED."GR_CODE"`,
      t,
      code,
      name,
      type,
      pr,
      gr,
    );
  }
  for (const [code, name] of PRODUCTS) {
    await db.$executeRawUnsafe(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") SELECT $1::text,'01',$2::text,$3::text WHERE NOT EXISTS (SELECT 1 FROM "PRODUCT_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "PR_CODE"=$2::text)`,
      t,
      code,
      name,
    );
  }
  for (const [code, name] of GROUPS) {
    await db.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME") SELECT $1::text,'01',$2::text,$3::text WHERE NOT EXISTS (SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "GR_CODE"=$2::text)`,
      t,
      code,
      name,
    );
  }
  for (const [code, name] of ACCOUNTS) {
    await db.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") SELECT $1::text,'01',$4::text,$2::text,$3::text WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "LC_CODE"=$4::text AND "AC_CODE"=$2::text)`,
      t,
      code,
      name,
      HUID_LC,
    );
  }
  for (const r of ALL) {
    const tenant = r.other ? SECOND_TENANT : t;
    await insert(db, 'BAR_DETL', barRow(tenant, r));
    for (const m of [['+', r.d, r.ac, vchOf(r)], ...(r.mv ?? [])])
      await insert(db, 'MAIN_STOCK', stockRow(tenant, r, m));
  }
}

/** Removes exactly the rows this seed writes: VCH_NO and TAG_NO both from the seed lists, in both tenants. */
export async function cleanHuid(ctx) {
  for (const tenant of [ctx.tenantId, SECOND_TENANT]) {
    for (const table of ['MAIN_STOCK', 'BAR_DETL']) {
      await ctx.owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "VCH_NO" = ANY($2::text[]) AND "TAG_NO" = ANY($3::text[])`,
        tenant,
        CODES,
        TAGS,
      );
    }
  }
  // The dedicated location and its accounts belong to this seed alone.
  await ctx.owner.$executeRawUnsafe(
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$2 AND "AC_CODE" = ANY($3::text[])`,
    ctx.tenantId,
    HUID_LC,
    ACCOUNTS.map(([code]) => code),
  );
  await ctx.owner.$executeRawUnsafe(
    `DELETE FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"=$2 AND "LC_NAME"='E2E HUID LOCATION'`,
    ctx.tenantId,
    HUID_LC,
  );
}
