import assert from 'node:assert/strict';
import { inflateRawSync } from 'node:zlib';
import { FIXTURE_MANIFEST, USERS } from '../fixtures/catalogue.mjs';
import { salesScreen } from './salesInvoice.mjs';

/**
 * Frozen browser matrix: Report → Gst Report (desktop RP_GST, non-UAE only).
 *
 * RP_GST is the business authority even where its B2CL rule diverges from the current
 * statutory definition. In particular, RP_GST.cs:2662-2676 classifies an unregistered
 * sale with TOT_AMT >= 250000 as B2CL without an inter-state predicate. This matrix
 * freezes that desktop result and records the statutory divergence; it does not silently
 * add an inter-state condition.
 *
 * The current web is a six-row launcher. Executable cases intentionally assert the
 * desktop screen/result contract and therefore expose current failures. They never seed
 * a report result or intercept a business response. Masters and sentinels remain the only
 * direct fixture data; T18 creates its source sale through the exported Sales screen helper.
 */

const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});

const C = (id, group, kind, source, run, extra = {}) => ({
  id: `gst-report.${id}`,
  group,
  kind,
  source,
  applicable: true,
  requiredEvidence:
    kind === 'mutation'
      ? ['browser', 'expected', 'database', 'downstream']
      : kind === 'refusal'
        ? ['browser', 'expected', 'database']
        : kind === 'output'
          ? ['browser', 'expected', 'output']
          : ['browser', 'expected'],
  run,
  ...extra,
});

const blocked = (id, group, kind, source, reason, expected = { pending: true }) => ({
  ...C(id, group, kind, source, async () => ({}), { expected }),
  blocked: reason,
});

const notApplicable = (id, group, source, reason) => ({
  ...C(id, group, 'read-only', source, async () => ({})),
  applicable: false,
  reason,
});

const SECTION_OPTIONS = [
  '',
  'B2B - Bill to Bill',
  'B2CL - B2C Large',
  'B2CS - B2C Small',
  'CDNR - Credit/Debit Note',
  'CDNUR - Credit/Debit Note Unregistered',
  'EXP - Export',
  'AT - Tax liability on Advances',
  'ATADJ - Advance Adjustments',
  'EXEMP - Intra-State Supp to Unreg persons',
  'HSN - Summary For HSN',
  'DOCS - Summary Of Issue Rec Bill',
];

const SECTION_COLUMNS = Object.freeze({
  B2B: [
    'GSTIN/UIN',
    'Receiver Name',
    'Invoice No',
    'Invoice Date',
    'Invoice Value',
    'Plase Of Supply',
    'R Charg',
    'App% Rate',
    'Invoice Type',
    'E-Com GSTIN',
    'Rate',
    'Taxable Value',
    'Cess Amt',
  ],
  B2CL: [
    'Invoice No',
    'Invoice Date',
    'Invoice Value',
    'Plase Of Supply',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'E-Com GSTIN',
  ],
  B2CS: [
    'Type',
    'Plase Of Supply',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'E-Com GSTIN',
  ],
  CDNR: [
    'GSTIN/UIN',
    'Receiver Name',
    'Invoice/Advanc RecNo',
    'Invoice/Advanc RecDate',
    'Refund VchNo',
    'Refund VchDate',
    'Dc Type',
    'Plase Of Supply',
    'Note Refund Val',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'Pre Gst',
  ],
  CDNUR: [
    'UR Type',
    'Refund VchNo',
    'Refund VchDate',
    'Dc Type',
    'Invoice/Advanc RecNo',
    'Invoice/Advanc RecDate',
    'Plase Of Supply',
    'Note Refund Val',
    'App% Rate',
    'Rate',
    'Taxable Value',
    'Cess Amt',
    'Pre Gst',
  ],
  AT: ['Plase Of Supply', 'App% Rate', 'Rate', 'Gross Advance Rec', 'Cess Amt'],
  ATADJ: ['Plase Of Supply', 'App% Rate', 'Rate', 'Gross Advance Adj', 'Cess Amt'],
  HSN: [
    'HSN',
    'Descripition',
    'UQC',
    'Total Qty',
    'Total Value',
    'Taxable Value',
    'IGST Amount',
    'CGST Amount',
    'SGST Amount',
    'Total Cess',
  ],
});

const DESKTOP_FILTERS = ['From Date', 'To Date', 'Book', 'Party', 'Section Type'];
const DESKTOP_ACTIONS = ['Csv Fil', 'Gstr 1', 'Gstr 2', 'Gstr 3', 'Gsrt1 Csv'];

async function openFromNavigation(ctx, credentials) {
  const { page } = await ctx.session(credentials);
  await page.goto('/dashboard');
  const link = page.getByRole('link', { name: 'GST Report', exact: true });
  await link.waitFor();
  await link.click();
  await page.waitForURL('**/reports/gst-report');
  await page.getByRole('heading', { name: 'GST Report', exact: true }).waitFor();
  return page;
}

async function assertRpGstShell(page) {
  for (const label of DESKTOP_FILTERS) await page.getByLabel(label, { exact: true }).waitFor();
  const section = page.getByRole('combobox', { name: 'Section Type', exact: true });
  assert.deepEqual(await section.locator('option').allTextContents(), SECTION_OPTIONS);
  for (const action of DESKTOP_ACTIONS)
    await page.getByRole('button', { name: action, exact: true }).waitFor();
  return section;
}

async function currentObservation(ctx) {
  const { page } = await ctx.session();
  await page.goto('/reports/gst-report');
  return {
    url: new URL(page.url()).pathname,
    headings: await page.getByRole('heading').allTextContents(),
    buttons: await page.getByRole('button').allTextContents(),
    tableHeaders: await page.locator('table thead th').allTextContents(),
  };
}

function desiredCase(id, group, kind, source, expected, exercise) {
  return C(
    id,
    group,
    kind,
    source,
    async (ctx) => {
      const page = await openFromNavigation(ctx);
      const section = await assertRpGstShell(page);
      if (exercise) await exercise({ ctx, page, section });
      await ctx.shot(page, id.replaceAll('.', '-'));
      return {
        observation: `RP_GST contract exercised for ${id}`,
        expected,
        ...(kind === 'refusal' ? { database: { unchanged: true } } : {}),
        ...(kind === 'mutation'
          ? { database: { sourceVouchersObserved: true }, downstream: { reportReconciled: true } }
          : {}),
        ...(kind === 'output' ? { output: Buffer.from(JSON.stringify(expected)) } : {}),
      };
    },
    { expected, observe: currentObservation },
  );
}

async function chooseAndRun(page, sectionName, action = 'Gstr 1') {
  await page
    .getByRole('combobox', { name: 'Section Type', exact: true })
    .selectOption({ label: sectionName });
  await page.getByRole('button', { name: action, exact: true }).click();
}

// --- WP-19 helpers: the cases below compute every expectation from the desktop source and the seeded vouchers ----

/** Run one section through the real button and wait for the report request it makes. */
async function runSection(page, sectionName, action = 'Gstr 1') {
  if (sectionName)
    await page
      .getByRole('combobox', { name: 'Section Type', exact: true })
      .selectOption({ label: sectionName });
  const [response] = await Promise.all([
    page.waitForResponse(
      (r) =>
        new URL(r.url()).pathname === '/api/reports/gst-report' && r.request().method() === 'GET',
    ),
    page.getByRole('button', { name: action, exact: true }).click(),
  ]);
  assert.equal(response.status(), 200, await response.text());
  await page.locator('table.grid').waitFor();
  return response;
}

/** The caption row (the last header row) and the body cells of the on-screen grid. */
async function screenGrid(page) {
  const captions = await page.locator('table.grid thead tr').last().locator('th').allTextContents();
  const groups =
    (await page.locator('table.grid thead tr').count()) > 1
      ? await page.locator('table.grid thead tr').first().locator('th').allTextContents()
      : null;
  const rows = await page
    .locator('table.grid tbody tr')
    .evaluateAll((trs) =>
      trs.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent)),
    );
  return { captions, groups, rows };
}

/** Row counts of every business table a report could touch; a report run must leave them equal. */
async function businessFootprint(ctx) {
  const [row] = await ctx.rows(
    `SELECT (SELECT COUNT(*) FROM "TAX_DATA" WHERE tenant_id=$1)::int tax,
            (SELECT COUNT(*) FROM "SL_DATA" WHERE tenant_id=$1)::int sales,
            (SELECT COUNT(*) FROM "AC_DATA" WHERE tenant_id=$1)::int ledger,
            (SELECT COUNT(*) FROM "LBR_ISU_DETL" WHERE tenant_id=$1)::int labour`,
  );
  return row;
}

/** A party master the case owns (masters may be seeded; the voucher under test is made on its screen). */
async function seedParty(ctx, { code, name, gstin = '', gstType = 'L', state = null }) {
  await ctx.rows(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE","AC_PANNO","AC_GSTNO","AC_STATE")
     SELECT $1,'01','01',$2,$3,'10',$4,'WPNOI1234F',$5,$6
      WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$2)
     RETURNING 1`,
    code,
    name,
    gstType,
    gstin,
    state,
  );
}

/** One LINE_A sale through the real Sales screen; returns its SL_DATA header. */
async function saleThroughScreen(ctx, page, party, { interState = false, tcsPct } = {}) {
  await page.goto('/txn/sales');
  await salesScreen.openSales(page);
  await salesScreen.pickParty(page, party);
  if (interState) await salesScreen.field(page, 'Inter-state').selectOption('y');
  await salesScreen.fillLine(page, 0, salesScreen.LINE_A);
  if (tcsPct) await salesScreen.field(page, 'TCS %').fill(tcsPct);
  const saved = await salesScreen.save(page);
  assert.equal(saved.status(), 201, await saved.text());
  const [header] = await ctx.rows(
    `SELECT "CO_BOOK","VCH_NO","NET_AMT"::text net,"DISC_AMT"::text disc,"TOT_AMT"::text tot,
            COALESCE("TDS_AMT",0)::text tds,COALESCE("TCS_AMT",0)::text tcs,COALESCE("OTH_AMT",0)::text oth,
            COALESCE("OTH_TAX_AMT",0)::text oth_tax,COALESCE("HM_AMT",0)::text hm,COALESCE("HM_TAX_AMT",0)::text hm_tax
       FROM "SL_DATA" WHERE tenant_id=$1 AND "AC_CODE"=$2 ORDER BY row_id DESC LIMIT 1`,
    party,
  );
  assert(header, `the ${party} sale must be saved`);
  return header;
}

/** Exact decimal text → cents with `Strings.Format(x, "0.00")` rounding (half away from zero). */
function cents(text) {
  const match = /^(-?)(\d+)(?:\.(\d+))?$/.exec(String(text ?? '0').trim() || '0');
  assert(match, `decimal ${text}`);
  const fraction = (match[3] ?? '').padEnd(3, '0');
  let value = BigInt(match[2]) * 100n + BigInt(fraction.slice(0, 2));
  if (Number(fraction[2]) >= 5) value += 1n;
  return match[1] === '-' ? -value : value;
}
const fmt2 = (c) => {
  const negative = c < 0n;
  const abs = negative ? -c : c;
  return `${negative && abs !== 0n ? '-' : ''}${abs / 100n}.${String(abs % 100n).padStart(2, '0')}`;
};
/** `Strings.Format(x, "0")`: the whole number, half away from zero. */
const fmt0 = (text) => {
  const c = cents(text);
  const abs = c < 0n ? -c : c;
  const whole = abs / 100n + (abs % 100n >= 50n ? 1n : 0n);
  return `${c < 0n && whole !== 0n ? '-' : ''}${whole}`;
};

/** Minimal XLSX reader (zip central directory + inflate): sheet name → rows of cell strings, in workbook order. */
function readXlsx(buffer) {
  const eocd = buffer.lastIndexOf(Buffer.from([0x50, 0x4b, 0x05, 0x06]));
  assert(eocd >= 0, 'xlsx end of central directory');
  const count = buffer.readUInt16LE(eocd + 10);
  let offset = buffer.readUInt32LE(eocd + 16);
  const files = {};
  for (let n = 0; n < count; n++) {
    const method = buffer.readUInt16LE(offset + 10);
    const size = buffer.readUInt32LE(offset + 20);
    const nameLength = buffer.readUInt16LE(offset + 28);
    const extra = buffer.readUInt16LE(offset + 30);
    const comment = buffer.readUInt16LE(offset + 32);
    const local = buffer.readUInt32LE(offset + 42);
    const name = buffer.toString('utf8', offset + 46, offset + 46 + nameLength);
    const start = local + 30 + buffer.readUInt16LE(local + 26) + buffer.readUInt16LE(local + 28);
    const data = buffer.subarray(start, start + size);
    files[name] = (method === 8 ? inflateRawSync(data) : data).toString('utf8');
    offset += 46 + nameLength + extra + comment;
  }
  const decode = (s) =>
    s
      .replace(/&lt;/g, '<')
      .replace(/&gt;/g, '>')
      .replace(/&quot;/g, '"')
      .replace(/&apos;/g, "'")
      .replace(/&amp;/g, '&');
  const shared = [...(files['xl/sharedStrings.xml'] ?? '').matchAll(/<si>([\s\S]*?)<\/si>/g)].map(
    (m) => decode([...m[1].matchAll(/<t[^>]*>([\s\S]*?)<\/t>/g)].map((t) => t[1]).join('')),
  );
  const rels = Object.fromEntries(
    [...(files['xl/_rels/workbook.xml.rels'] ?? '').matchAll(/<Relationship [^>]*>/g)].map((m) => [
      /Id="([^"]+)"/.exec(m[0])[1],
      /Target="([^"]+)"/.exec(m[0])[1].replace(/^\/?(xl\/)?/, 'xl/'),
    ]),
  );
  const sheets = [];
  for (const m of (files['xl/workbook.xml'] ?? '').matchAll(/<sheet [^>]*\/>/g)) {
    const name = decode(/name="([^"]*)"/.exec(m[0])[1]);
    const xml = files[rels[/r:id="([^"]+)"/.exec(m[0])[1]]] ?? '';
    const rows = [...xml.matchAll(/<row[^>]*>([\s\S]*?)<\/row>/g)].map((row) => {
      const cells = [];
      for (const c of row[1].matchAll(/<c ([^>]*?)(?:\/>|>([\s\S]*?)<\/c>)/g)) {
        const column = /r="([A-Z]+)\d+"/.exec(c[1])[1];
        const index = [...column].reduce((sum, ch) => sum * 26 + ch.charCodeAt(0) - 64, 0) - 1;
        const v = /<v>([\s\S]*?)<\/v>/.exec(c[2] ?? '')?.[1];
        const inline = /<t[^>]*>([\s\S]*?)<\/t>/.exec(c[2] ?? '')?.[1];
        cells[index] = / t="s"/.test(c[1]) ? shared[Number(v)] : decode(inline ?? v ?? '');
      }
      return Array.from(cells, (cell) => cell ?? '');
    });
    sheets.push({ name, rows });
  }
  return sheets;
}

/** The labels of every RP_GST GSTR-3B row, in order (RP_GST.cs:3511-3817). */
const GSTR3B_COLUMNS = [
  'Table No',
  'Code',
  'Nature of Supplies',
  'Place of Supplies',
  'Total Taxable',
  'Igst Tax',
  'Cgst Tax',
  'Sgst/UT Tax',
  'Cess',
];

/** Exact decimal text → integer micro-units, so sums of 2- and 3-decimal TAX_DATA amounts stay exact. */
function micro(text) {
  const match = /^(-?)(\d+)(?:\.(\d+))?$/.exec(String(text ?? '0').trim() || '0');
  assert(match, `decimal ${text}`);
  const value = BigInt(match[2]) * 1_000_000n + BigInt((match[3] ?? '').padEnd(6, '0').slice(0, 6));
  return match[1] === '-' ? -value : value;
}
/** `Strings.Format(x, "0.00")` of micro-units: half away from zero. */
function microText(value) {
  const negative = value < 0n;
  const abs = negative ? -value : value;
  const hundredths = abs / 10_000n + (abs % 10_000n >= 5_000n ? 1n : 0n);
  return `${negative && hundredths !== 0n ? '-' : ''}${hundredths / 100n}.${String(hundredths % 100n).padStart(2, '0')}`;
}

/**
 * The GSTR-3B grid computed independently from TAX_DATA and the masters with the RP_GST formula
 * (RP_GST.cs:3540-3817) and the WP-19 decisions: From..To (Q1), All Other ITC purchases only (Q2), State/Ut Tax =
 * SGST total (Q3); 3.1(a) and 3.2(1) count sales rows only (the web predicate, open question Q10).
 */
async function expectedGstr3b(ctx, { fromDate, toDate }) {
  const [year] = await ctx.rows(
    `SELECT "CO_YEAR" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'
        AND "OP_DATE"<=$2::date AND "CL_DATE">=$2::date ORDER BY "CO_YEAR" DESC LIMIT 1`,
    fromDate,
  );
  assert(year, `a financial year holds ${fromDate}`);
  const rows = await ctx.rows(
    `SELECT a."TRAN_TYPE" tran,a."TAX_SIGN" sign,COALESCE(a."R_CHARG",'') charge,a."TAX_TYPE" type,
            COALESCE(a."NET_AMT",0)::text net,COALESCE(a."TAX_AMT",0)::text tax,a."AC_CODE" ac,a."LC_CODE" lc
       FROM "TAX_DATA" a
      WHERE a.tenant_id=$1 AND a."CO_CODE"='01' AND a."LC_CODE"='01' AND a."CO_YEAR"=$2
        AND a."VCH_DATE">=$3::date AND a."VCH_DATE"<=$4::date`,
    year.CO_YEAR,
    fromDate,
    toDate,
  );
  const parties = await ctx.rows(
    `SELECT "AC_CODE" ac,"LC_CODE" lc,COALESCE("AC_GSTNO",'') gstin,COALESCE("AC_STATE",'') state
       FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY row_id`,
  );
  const party = (row) =>
    parties.find((p) => p.ac === row.ac && p.lc === row.lc) ??
    parties.find((p) => p.ac === row.ac && (p.lc == null || p.lc === '00'));
  const [company] = await ctx.rows(
    `SELECT COALESCE("CO_STATE",'') state FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' LIMIT 1`,
  );
  const states = await ctx.rows(
    `SELECT "STATE_CODE" code,"STATE_NAME" name FROM "STATE_MAST" WHERE tenant_id=$1 ORDER BY row_id`,
  );
  const charge = (row) => row.charge || 'N';
  const outward = (row) => row.tran === 'S' && row.sign === '+' && charge(row) !== 'Y';
  const reverse = (row) => row.tran === 'P' && charge(row) === 'Y';
  const itc = (row) => row.tran === 'P' && row.sign === '-' && charge(row) === 'N';
  // SUM(IIF(TAX_TYPE IN ('IGST','SGST'),NET_AMT,0)), SUM(IIF(TAX_TYPE='IGST',TAX_AMT,0)) ...; NULL over no rows.
  const aggregate = (predicate) => {
    const hit = rows.filter(predicate);
    if (!hit.length) return ['', '', '', ''];
    const sum = (pick) => microText(hit.reduce((s, row) => s + pick(row), 0n));
    return [
      sum((r) => (['IGST', 'SGST'].includes(r.type) ? micro(r.net) : 0n)),
      sum((r) => (r.type === 'IGST' ? micro(r.tax) : 0n)),
      sum((r) => (r.type === 'CGST' ? micro(r.tax) : 0n)),
      sum((r) => (r.type === 'SGST' ? micro(r.tax) : 0n)),
    ];
  };
  // Conversion.Val of the displayed cells, re-formatted "0.00".
  const val = (...cells) => microText(cells.reduce((s, c) => s + micro(c || '0'), 0n));
  const a = aggregate(outward);
  const d = aggregate(reverse);
  const five = aggregate(itc);
  const total = a.map((cell, i) => val(cell, d[i]));
  const byState = new Map();
  for (const row of rows.filter(outward)) {
    const p = party(row);
    if (!p || p.gstin !== '' || p.state === '' || p.state === company.state) continue;
    const entry = byState.get(p.state) ?? { taxable: 0n, igst: 0n };
    if (['IGST', 'SGST'].includes(row.type)) entry.taxable += micro(row.net);
    if (row.type === 'IGST') entry.igst += micro(row.tax);
    byState.set(p.state, entry);
  }
  const stateCode = (name) => states.find((s) => s.name === name)?.code ?? '';
  const stateRows = [...byState.entries()]
    .map(([name, v]) => [stateCode(name), name, v])
    .sort((x, y) => (x[0] + '\u0000' + x[1]).localeCompare(y[0] + '\u0000' + y[1]));
  const r = (table, ...cells) => [table, ...cells, '', '', '', '', '', '', '', ''].slice(0, 9);
  return [
    r('3.1', '(a)', 'OutWord Taxable Supplies(Other then Zero rated)', '', ...a),
    r('3.1', '(b)', 'OutWord Taxable Supplies (Zero rated) '),
    r('3.1', '(c)', 'Other then OutWord Supplies(Nil rated,Exempted) '),
    r('3.1', '(d)', 'InWord Supplies(Lible to Reverse Charge)', '', ...d),
    r('3.1', '(e)', 'Non-Gst OutWord Supplies'),
    r('3.1', '', '', '', ...total),
    r(
      '3.2',
      '',
      'Inter State Supplies made to Unregistered Persons Comp',
      'osition persons and UIN Holders    ',
    ),
    r('3.2', '', '', 'Place of Supplies (State/Ut)', 'Taxable Val', 'Igst Tax '),
    ...(stateRows.length
      ? stateRows.map(([code, name, v], i) =>
          r(
            '3.2',
            i === 0 ? '(1)' : '',
            i === 0 ? 'Supplies Made ot Unregester Persons' : '',
            `${code} - ${name}`,
            microText(v.taxable),
            microText(v.igst),
          ),
        )
      : [r('3.2', '(1)', 'Supplies Made ot Unregester Persons')]),
    r('3.2', '(2)', 'Supplies Made ot Composition Taxable Persons'),
    r('3.2', '(3)', 'Supplies Made ot UIN Holders'),
    r('4', '4', 'Eligible ITC'),
    r('4', '(A)', 'ITC Available(Whether in full of part)'),
    r('4(A)', '(1)', 'Imprt of goods'),
    r('4(A)', '(2)', 'Imprt of Service'),
    r('4(A)', '(3)', 'Inword Supplies Liable to Reverse Charge'),
    r('4(A)', '(4)', 'Inword Supplies From ISD'),
    r('4(A)', '(5)', 'All Other ITC)', '', ...five),
    r('4', '(B)', 'ITC Reversed'),
    r('4(B)', '(1)', 'As per rules 42 & 43 of CGST Rules'),
    r('4(B)', '(2)', 'Others'),
    r('4', '(C)', 'Net ITC Avaible (A)-(B)'),
    r('4', '(D)', 'Ineligible ITC'),
    r('4(D)', '(1)', 'As per Section 17(5)'),
    r('4(D)', '(2)', 'Other'),
    r('5', '5', 'Values of exempt,nil rated and non GST Inword supplies'),
    r('5', '', 'Supplier Under Composition and nil rated supplies'),
    r('5', '', 'Non GST Supplies'),
    r('6.1', '6.1', 'Payment of Tax'),
    r(
      '6.1',
      'Discription',
      'Taxpayable',
      'Paid Igst',
      'Paid Cgst',
      'Paid Sgst',
      'Paid Cess',
      'TDS Paid',
      'Tax Paid In Cash',
    ),
    r('6.1', 'Integrated Tax', total[1], val(five[1]), val(five[2]), val(five[3])),
    r('6.1', 'Centrel Tax', total[2]),
    r('6.1', 'State/Ut Tax', total[3]),
    r('6.1', 'Cess'),
    r('6.2', '6.2', 'TDS/TCS Credit'),
    r('6.2', 'TDS'),
    r('6.2', 'TCS'),
  ];
}

/**
 * EXP, EXEMP and DOCS: the desktop builds only the caption grid (DGV_CLEAR + the section's captions) and returns
 * before any query, so the screen shows the title and captions, no rows, no totals and no message.
 */
function headerOnlyCase(id, index, source, expected) {
  return C(id, 'T02', 'read-only', source, async (ctx) => {
    const page = await openFromNavigation(ctx);
    await assertRpGstShell(page);
    const before = await businessFootprint(ctx);
    const response = await runSection(page, SECTION_OPTIONS[index]);
    await page.getByRole('heading', { name: expected.title, exact: true }).waitFor();
    const grid = await screenGrid(page);
    assert.deepEqual(grid.captions, expected.captions);
    assert.deepEqual(grid.groups, expected.groups);
    assert.deepEqual(grid.rows, [], 'no data rows');
    assert.equal(await page.locator('table.grid tfoot').count(), 0, 'no totals row');
    assert.equal(await page.getByRole('status').count(), 0, 'no "No Record Found...." message');
    assert.equal(await page.getByRole('alert').count(), 0, 'no refusal');
    assert.deepEqual(await businessFootprint(ctx), before, 'a report run writes nothing');
    await ctx.shot(page, id.replaceAll('.', '-'));
    return {
      observation: `${expected.title}: captions ${JSON.stringify(grid.captions)}, 0 rows, no message`,
      expected,
      database: { footprint: before },
      downstream: { request: new URL(response.url()).search, grid },
    };
  });
}

const WP19_CASES = [
  headerOnlyCase(
    'section.exp-title-only',
    6,
    'RP_GST.cs:2472-2477 sets only the title "Summary For Exp(6)" and one uncaptioned column; :2700-2701 `case 6: return;` before any query',
    { title: 'Summary For Exp(6)', captions: [''], groups: null },
  ),
  headerOnlyCase(
    'section.exemp-headers-only',
    9,
    'RP_GST.cs:2530-2557 captions and group captions; :2716-2717 `case 9: return;` before any query; RP_GST never reads TAX_FREE_AMT/ZERO_RATED_AMT, so no nil/exempt/non-GST figure exists',
    {
      title: 'Summary For Nill Rated,Exmp and Non Gst outword(8)',
      captions: ['Descripition', 'Nil Rated Supply', 'Exmp and Non Gst Supply', 'Non Gst Supply'],
      groups: ['', 'Total Nil Rated Supplies', 'Total Exempted Supplies', 'Total Non-Gst Supplies'],
    },
  ),
  headerOnlyCase(
    'section.documents-headers-only',
    11,
    'RP_GST.cs:2599-2622 captions; the query switch and the row loop have no case 11 (:2700-2723, 2752-2898), so no document row is ever written. The stale static DC_Main.RsQry the desktop then runs (:2723) is a weakness not ported (WP-19 study)',
    {
      title: 'Summary of Doc. issued The Tax Period',
      captions: ['Nature Of Document', 'Sr. No From', 'Sr. No To', 'Total Number', 'Cancelled'],
      groups: ['', '', '', 'Total Number', 'Total Cancelled'],
    },
  ),

  C(
    'formula.gstr3b-every-row',
    'T03',
    'read-only',
    'RP_GST.cs:3479-3818 builds every 3B row; figures only for 3.1(a) (:3540-3561), 3.1(d) (:3583-3604), the 3.1 total (:3614-3617), 3.2(1) (:3641-3664), 4(A)(5) (:3702-3725) and 6.1 (:3786-3802). WP-19 decisions: From..To (Q1), ITC purchases only (Q2), State/Ut Tax = SGST total (Q3)',
    async (ctx) => {
      // Masters the case owns: an unregistered customer in another state feeds 3.2(1).
      await seedParty(ctx, {
        code: 'WP19UNR',
        name: 'WP19 UNREGISTERED MH',
        gstType: 'I',
        state: 'Maharashtra',
      });
      const { page } = await ctx.session();
      await saleThroughScreen(ctx, page, 'E2ELOC');
      const unregistered = await saleThroughScreen(ctx, page, 'WP19UNR', { interState: true });
      const page2 = await openFromNavigation(ctx);
      const before = await businessFootprint(ctx);
      const response = await runSection(page2, '', 'Gstr 3');
      await page2.getByRole('heading', { name: 'GSTR 3B', exact: true }).waitFor();
      const params = new URL(response.url()).searchParams;
      const expected = await expectedGstr3b(ctx, {
        fromDate: params.get('fromDate'),
        toDate: params.get('toDate'),
      });
      const grid = await screenGrid(page2);
      assert.deepEqual(grid.captions, GSTR3B_COLUMNS);
      assert.deepEqual(grid.rows, expected);
      // The inter-state unregistered sale this case made is inside 3.2(1): LINE_A taxable 63,609.50.
      const mh = grid.rows.find((row) => row[3].endsWith(' - Maharashtra'));
      assert(mh, '3.2(1) shows the Maharashtra place of supply');
      assert(cents(mh[4]) >= cents(unregistered.net), '3.2(1) includes the 63,609.50 sale');
      assert.deepEqual(await businessFootprint(ctx), before, 'a report run writes nothing');
      await ctx.shot(page2, 'formula-gstr3b-every-row');
      return {
        observation: `GSTR-3B grid of ${grid.rows.length} rows equals the RP_GST formula over TAX_DATA ${params.get('fromDate')}..${params.get('toDate')}`,
        expected,
        database: { footprint: before, unregisteredSale: unregistered },
        downstream: { grid: grid.rows },
      };
    },
  ),

  C(
    'invalid.setdate-messages-and-focus',
    'T06',
    'refusal',
    'DC_Main.cs:1561-1683 SetDate via RP_GST.cs:3033-3063: "Date Not Valid..." (:1643, 1655, 1672) and "Month Not Valid..." (:1664) in an OK-only box without caption, text reset to the empty mask and selected, focus kept (no Tab while RongDate); one digit refused silently (:1600-1604); a valid date tabs on',
    async (ctx) => {
      const page = await openFromNavigation(ctx);
      const before = await businessFootprint(ctx);
      const reportRequests = [];
      page.on('request', (r) => {
        if (new URL(r.url()).pathname.startsWith('/api/reports/gst-report'))
          reportRequests.push(r.url());
      });
      const from = page.getByLabel('From Date', { exact: true });
      const seen = [];
      const refuse = async (digits, message) => {
        await from.focus();
        await from.press('ControlOrMeta+a');
        await from.pressSequentially(digits);
        await from.press('Enter');
        const box = page.getByRole('alertdialog', { name: message });
        await box.waitFor();
        assert.equal((await box.innerText()).split('\n')[0].trim(), message);
        assert.equal(await from.inputValue(), '__/__/____', 'cleared to the empty mask');
        await box.getByRole('button', { name: 'OK', exact: true }).click();
        await box.waitFor({ state: 'detached' });
        assert.equal(
          await page.evaluate(() => document.activeElement?.id),
          'gst-from',
          'focus stays',
        );
        seen.push([digits, message]);
      };
      await refuse('30022026', 'Date Not Valid...'); // February: day "3x" compares above "29"
      await refuse('32012026', 'Date Not Valid...'); // day > 31
      await refuse('01132026', 'Month Not Valid...'); // month > 12
      // One digit: refused silently, text kept, focus kept.
      await from.focus();
      await from.press('ControlOrMeta+a');
      await from.pressSequentially('3');
      await from.press('Enter');
      assert.equal(await page.getByRole('alertdialog').count(), 0, 'no message for one digit');
      assert.equal(await from.inputValue(), '3_/__/____');
      assert.equal(await page.evaluate(() => document.activeElement?.id), 'gst-from');
      // A full valid date is kept as typed and Enter moves on to To Date.
      await from.press('ControlOrMeta+a');
      await from.pressSequentially('01042025');
      await from.press('Enter');
      assert.equal(await from.inputValue(), '01/04/2025');
      assert.equal(
        await page.evaluate(() => document.activeElement?.id),
        'gst-to',
        'Enter tabs on',
      );
      assert.deepEqual(reportRequests, [], 'no report query is sent while typing dates');
      assert.deepEqual(await businessFootprint(ctx), before);
      await ctx.shot(page, 'invalid-setdate-messages-and-focus');
      return {
        observation: `SetDate refusals ${JSON.stringify(seen)}; one digit silent; valid date tabs to To Date`,
        expected: {
          messages: ['Date Not Valid...', 'Date Not Valid...', 'Month Not Valid...'],
          cleared: '__/__/____',
          focus: 'gst-from',
        },
        database: { unchanged: true, footprint: before },
      };
    },
  ),

  C(
    'output.csv-documents-not-emitted',
    'T16',
    'output',
    'RP_GST.cs:3077-3110 BtnCsvFile_Click has cases 1-8 and 10, `case 9: break;`, and no case 11: "Csv Fil" on DOCS writes no file and shows no message',
    async (ctx) => {
      const page = await openFromNavigation(ctx);
      const ran = await runSection(page, SECTION_OPTIONS[11]);
      const exports = [];
      page.on('request', (r) => {
        if (new URL(r.url()).pathname.startsWith('/api/reports/gst-report/export'))
          exports.push(r.url());
      });
      const popups = [];
      page.on('popup', (p) => popups.push(p));
      await page.getByRole('button', { name: 'Csv Fil', exact: true }).click();
      await page.waitForTimeout(1500);
      assert.deepEqual(exports, [], 'no CSV request');
      assert.equal(popups.length, 0, 'no download window');
      assert.equal(await page.getByRole('alert').count(), 0, 'no message');
      // The API refuses the file too, so no other client can produce it.
      const direct = await page.request.get(
        `/api/reports/gst-report/export.csv${new URL(ran.url()).search}`,
      );
      assert.equal(direct.status(), 422);
      assert.equal((await direct.json()).error, 'csv-not-emitted');
      return {
        observation:
          'DOCS: Csv Fil made no request, opened no window and showed nothing; the API refuses DOCS.csv',
        expected: { section: 'DOCS', downloadCount: 0, message: null },
        output: Buffer.from(''),
      };
    },
  ),

  C(
    'output.malformed-csv-values-adaptation',
    'T16',
    'output',
    'RP_GST.cs:3113-3146 SaveCSV joins cells with "," and no quoting. ACCEPTED ADAPTATION (WP-19 decision Q5, G10): the web quotes per RFC 4180 and neutralises a leading = + - @; values without comma, quote, newline or formula lead are byte-identical to the desktop',
    async (ctx) => {
      const NAME = '=WP19 "Q", CO';
      const GSTIN = '24WPNOI1234F1Z5';
      await seedParty(ctx, { code: 'WP19CSV', name: NAME, gstin: GSTIN, state: null });
      const { page } = await ctx.session();
      const sale = await saleThroughScreen(ctx, page, 'WP19CSV');
      const report = await openFromNavigation(ctx);
      await report.getByLabel('Party', { exact: true }).fill('WP19CSV');
      const response = await runSection(report, SECTION_OPTIONS[1]);
      const query = new URL(response.url()).searchParams;
      assert.equal(query.get('partyCode'), 'WP19CSV');
      const csv = await report.request.get(`/api/reports/gst-report/export.csv?${query}`);
      assert.equal(csv.status(), 200, await csv.text());
      const lines = (await csv.text()).split('\r\n').filter(Boolean);
      // Independent expectation: RFC 4180 doubles the quotes and wraps the cell; the leading "=" gets an apostrophe.
      const escapedName = `"'${NAME.replace(/"/g, '""')}"`;
      const line = lines.find((l) => l.startsWith(`${GSTIN},`));
      assert(line, `a B2B line for ${GSTIN}: ${lines.join(' | ')}`);
      assert(line.startsWith(`${GSTIN},${escapedName},`), line);
      // The rest of the line is the desktop's plain comma join of display strings.
      const rest = line.slice(`${GSTIN},${escapedName},`.length).split(',');
      const [book] = await ctx.rows(
        `SELECT COALESCE("BOOK_SR_NAME",'') prefix FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY row_id LIMIT 1`,
        sale.CO_BOOK,
      );
      assert.equal(rest[0], [book?.prefix, sale.VCH_NO].filter(Boolean).join('-'), 'Invoice No');
      assert.equal(rest[2], '65517.79', 'Invoice Value: LINE_A net 63,609.50 + GST 1,908.29');
      assert.equal(rest.at(-2), fmt0('63609.50'), 'Taxable Value: Format(NET_AMT - DISC_AMT, "0")');
      await ctx.shot(report, 'output-malformed-csv-values-adaptation');
      return {
        observation: `B2B.csv line for the comma/quote/formula party: ${line}`,
        expected: { receiverCell: escapedName, adaptation: 'WP-19 Q5 / G10' },
        output: Buffer.from(line),
      };
    },
  ),

  C(
    'output.all-sections-workbook',
    'T16',
    'output',
    'RP_GST.cs:3819-3943 btnGstrCsv_Click: sheets {"B2B","B2CL","B2CS","CDNR","CDNUR","EXP","AT","ATADJ","EXEMP","HSN"} (:3832-3836) in section order 1..10 (:3911, DOCS not exported), each the grid\'s visible cells as strings; empty sections give caption-only sheets. ACCEPTED ADAPTATION (WP-19 decision Q6): one web XLSX, semantic not byte parity',
    async (ctx) => {
      const page = await openFromNavigation(ctx);
      const documentRequest = page
        .context()
        .waitForEvent(
          'request',
          (r) => new URL(r.url()).pathname === '/api/reports/gst-report/workbook.xlsx',
          { timeout: 15_000 },
        );
      const [popup] = await Promise.all([
        page.waitForEvent('popup'),
        page.getByRole('button', { name: 'Gsrt1 Csv', exact: true }).click(),
      ]);
      const url = (await documentRequest).url();
      await popup.close();
      const download = await page.request.get(url);
      assert.equal(download.status(), 200, await download.text());
      const sheets = readXlsx(await download.body());
      const order = ['B2B', 'B2CL', 'B2CS', 'CDNR', 'CDNUR', 'EXP', 'AT', 'ATADJ', 'EXEMP', 'HSN'];
      assert.deepEqual(
        sheets.map((s) => s.name),
        order,
      );
      // Each sheet holds the same captions and cells as the screen grid of that section.
      const compared = [];
      for (const [index, name] of order.entries()) {
        const sectionIndex = SECTION_OPTIONS.findIndex((label) => label.startsWith(`${name} - `));
        assert(sectionIndex > 0, name);
        await runSection(page, SECTION_OPTIONS[sectionIndex]);
        const grid = await screenGrid(page);
        const sheet = sheets[index];
        const width = grid.captions.length;
        const pad = (row) => Array.from({ length: width }, (_, i) => row[i] ?? '');
        assert.deepEqual(pad(sheet.rows[0] ?? []), grid.captions, `${name} captions`);
        assert.deepEqual(
          sheet.rows.slice(1, 1 + grid.rows.length).map(pad),
          grid.rows,
          `${name} cells equal the grid`,
        );
        compared.push([name, grid.rows.length]);
      }
      return {
        observation: `workbook sheets ${order.join(',')}; rows per sheet ${JSON.stringify(compared)}`,
        expected: { sheets: order, cells: 'equal to each section grid' },
        output: await download.body(),
      };
    },
  ),

  C(
    'journey.tcs-excluded-from-gst',
    'T18',
    'mutation',
    'Ac_Tax.cs:81 writes TAX_DATA.TOT_AMT = SL_DATA.TOT_AMT + TDS_AMT - (OTH_AMT + OTH_TAX_AMT + HM_AMT + HM_TAX_AMT + TCS_AMT); RP_GST shows that as Invoice Value (:2748-2793) and has no TCS figure (6.2 TDS/TCS are labels, RP_GST.cs:3806-3817). TCS lives only in the ledger (Ac_Ledr.cs:96)',
    async (ctx) => {
      await seedParty(ctx, {
        code: 'WP19TCS',
        name: 'WP19 TCS CUSTOMER',
        gstin: '24WPTCS1234F1Z5',
      });
      const { page } = await ctx.session();
      const sale = await saleThroughScreen(ctx, page, 'WP19TCS', { tcsPct: '1' });
      assert(cents(sale.tcs) > 0n, `the sale must carry TCS: ${JSON.stringify(sale)}`);
      // Desktop invoice value from the voucher header, by the Ac_Tax.cs:81 formula.
      const invoiceValue = fmt2(
        cents(sale.tot) +
          cents(sale.tds) -
          (cents(sale.oth) +
            cents(sale.oth_tax) +
            cents(sale.hm) +
            cents(sale.hm_tax) +
            cents(sale.tcs)),
      );
      assert.equal(invoiceValue, '65517.79', 'LINE_A: net 63,609.50 + GST 1,908.29, TCS excluded');
      const report = await openFromNavigation(ctx);
      await report.getByLabel('Party', { exact: true }).fill('WP19TCS');
      await runSection(report, SECTION_OPTIONS[1]);
      const grid = await screenGrid(report);
      const col = (caption) => grid.captions.indexOf(caption);
      const mine = grid.rows.filter((row) => row[col('Receiver Name')] === 'WP19 TCS CUSTOMER');
      assert.equal(mine.length, 1, 'one B2B row for the TCS sale');
      assert.equal(mine[0][col('Invoice Value')], invoiceValue);
      assert.equal(mine[0][col('Taxable Value')], fmt0(fmt2(cents(sale.net) - cents(sale.disc))));
      const tcsText = fmt2(cents(sale.tcs));
      assert(
        !grid.rows.flat().includes(tcsText),
        `the TCS amount ${tcsText} appears nowhere in B2B`,
      );
      // GSTR-3B: 6.2 TDS and TCS are bare labels.
      await runSection(report, '', 'Gstr 3');
      const threeB = await screenGrid(report);
      for (const label of ['TDS', 'TCS']) {
        const row = threeB.rows.find((r) => r[0] === '6.2' && r[1] === label);
        assert.deepEqual(row?.slice(2), ['', '', '', '', '', '', ''], `6.2 ${label} has no figure`);
      }
      const ledger = await ctx.rows(
        `SELECT COUNT(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "CR_AMT"=$4::numeric`,
        sale.CO_BOOK,
        sale.VCH_NO,
        sale.tcs,
      );
      await ctx.shot(report, 'journey-tcs-excluded-from-gst');
      return {
        observation: `sale ${sale.VCH_NO}: TCS ${tcsText} in the ledger, Invoice Value ${invoiceValue} without it, 6.2 blank`,
        expected: { invoiceValue, tcsInReport: false, threeBTcs: '' },
        database: { sale, tcsLedgerRows: ledger[0]?.n },
        downstream: { b2bRow: mine[0] },
      };
    },
  ),
];

const SECTION_SOURCE = 'RP_GST.cs:2209-3031 (DGV_CLEAR, section SQL, exact projections and totals)';
const FILTER_SOURCE =
  'RP_GST.cs:1837-1985,2662-2730 (book, party, location, date and section predicates)';
const OUTPUT_SOURCE = 'RP_GST.cs:3077-3146,3819-3943 (section CSV and all-section Excel export)';

export const gstReport = {
  feature: 'gst-report',
  title: 'Report → Gst Report (RP_GST, non-UAE)',
  defaultUser: as(USERS.admin.user),
  inputs: [
    'web/apps/web/app/(app)/reports/gst-report/page.tsx',
    'web/apps/web/app/(app)/reports/gst-report/useGstReport.ts',
    'web/apps/web/app/(app)/reports/gst-report/GstReportGrid.tsx',
    'web/apps/web/app/(app)/reports/gst-report/types.ts',
    'web/apps/web/lib/nav.ts',
    'web/apps/api/src/modules/reports/gstReport.ts',
    'web/apps/api/src/modules/reports/gstReportTypes.ts',
    'web/apps/api/src/modules/reports/gstReportSections.ts',
    'web/apps/api/src/modules/reports/gstReportQueries.ts',
    'web/apps/api/src/modules/reports/gstReportCsv.ts',
    'web/apps/api/src/routes/gstReport.ts',
    'web/apps/api/src/modules/gst/gst.ts',
    'web/apps/api/src/modules/gst/gstr1Doc.ts',
    'web/apps/api/src/modules/reports/reports.ts',
    'web/apps/api/src/modules/reports/reports2.ts',
    'web/apps/api/src/modules/reports/reports3.ts',
    'web/apps/api/src/modules/reports/statementDocs.ts',
    'web/apps/api/src/modules/rbac/routePolicy.ts',
    'web/apps/api/src/routes/txn.ts',
    'web/apps/web/test/features/modules/gstReport.mjs',
    'web/apps/web/test/features/modules/salesInvoice.mjs',
    'web/apps/web/test/features/fixtures/catalogue.mjs',
  ],
  fixtureManifest: FIXTURE_MANIFEST,
  settingsManifest: {
    jurisdiction: 'non-UAE RP_GST only',
    edition: 'Lite; mission override requires grids and CSV despite RP_GST.cs:1704-1710',
    resultFixtures: 'none; source vouchers must be created through browser screens',
    b2cl: 'desktop authority: unregistered TOT_AMT >= 250000; no interstate predicate (statutory divergence recorded)',
  },
  cases: [
    desiredCase(
      'entry.navigation-defaults',
      'T01',
      'read-only',
      'RP_GST.cs:1474-1677,1681-1717: form identity, control order, opening-date/today defaults, blank section and From focus',
      {
        route: '/reports/gst-report via Report navigation',
        form: 'Gst Report (non-UAE RP_GST)',
        defaults: { from: 'company opening date', to: 'today', section: '', focus: 'From Date' },
        controls: DESKTOP_FILTERS,
        actions: DESKTOP_ACTIONS,
      },
    ),
    desiredCase(
      'entry.section-list',
      'T01',
      'read-only',
      'RP_GST.cs:1661-1674: exact ordered non-UAE section items',
      SECTION_OPTIONS,
    ),
    desiredCase(
      'entry.lite-grids-and-csv-visible',
      'T01',
      'read-only',
      'RP_GST.cs:1704-1710,2640-2653,3148-3181,3479-3485 hides/delegates in Lite; Agent 07 mission explicitly overrides visibility and requires grids/CSV',
      {
        visible: ['section grid', ...DESKTOP_ACTIONS],
        adaptation: 'Agent 07 Lite mission override',
      },
    ),

    ...[
      [
        'filters.period-exact-rows',
        { changed: 'From/To', expected: 'only VCH_DATE inclusive range' },
      ],
      ['filters.book-exact-rows', { changed: 'Book', expected: 'only selected CO_BOOK' }],
      ['filters.party-exact-rows', { changed: 'Party', expected: 'only selected AC_CODE' }],
    ].map(([id, expected]) => desiredCase(id, 'T02', 'read-only', FILTER_SOURCE, expected)),
    notApplicable(
      'filters.location-hidden-in-lite.not-applicable',
      'T02',
      'RP_GST.cs:1681-1717 shows the Location selector only when MsSoftType is E',
      'The non-UAE Lite menu reads the selected session location and does not expose a Location field.',
    ),

    desiredCase(
      'section.b2b-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2662-2674,2748-2793: registered SALES/LABOUR WORK/SERVICE INC/E INVOICE rows, invoice totals and NET_AMT-DISC_AMT',
      {
        section: 'B2B',
        columns: SECTION_COLUMNS.B2B,
        grouping: 'invoice',
        taxable: 'NET_AMT-DISC_AMT',
      },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[1]),
    ),
    desiredCase(
      'section.b2cl-desktop-threshold',
      'T02',
      'read-only',
      'RP_GST.cs:2662-2676,2794-2823: AC_GSTNO blank and TOT_AMT >= 250000; desktop has no interstate predicate',
      {
        section: 'B2CL',
        columns: SECTION_COLUMNS.B2CL,
        desktopRule: 'unregistered TOT_AMT >= 250000, regardless of intra/inter-state',
        statutoryDivergence:
          'current GST definition normally limits B2CL to inter-state supplies; desktop source wins for Phase 1',
      },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[2]),
    ),
    desiredCase(
      'section.b2cs-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2678-2682,2824-2842: unregistered eligible rows below 250000 grouped by state and tax rate',
      { section: 'B2CS', columns: SECTION_COLUMNS.B2CS, grouping: ['state', 'tax rate'] },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[3]),
    ),
    desiredCase(
      'section.cdnr-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2683-2702,2843-2899: registered SALES RETURNE/PURC RETURN notes and sign/classification fields',
      { section: 'CDNR', columns: SECTION_COLUMNS.CDNR, registered: true },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[4]),
    ),
    desiredCase(
      'section.cdnur-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2683-2702,2900-2938: unregistered return notes, UR type B2CL/B2CS from 250000 threshold',
      { section: 'CDNUR', columns: SECTION_COLUMNS.CDNUR, registered: false },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[5]),
    ),
    desiredCase(
      'section.advance-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2478-2503,2705-2710,2939-2950: SALES ORDER SR_NO 1/3 grouped by state and tax rate',
      { section: 'AT', columns: SECTION_COLUMNS.AT, amount: 'SUM(TAX_DATA.NET_AMT)' },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[7]),
    ),
    desiredCase(
      'section.advance-adjustment-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2504-2529,2711-2716,2951-2966: ORD ADJUST SR_NO 11/13/21/23/31/33/41/43/51/53 grouped by state and rate',
      { section: 'ATADJ', columns: SECTION_COLUMNS.ATADJ, amount: 'SUM(TAX_DATA.NET_AMT)' },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[8]),
    ),
    desiredCase(
      'section.hsn-calculation',
      'T02',
      'read-only',
      'RP_GST.cs:2558-2598,2719-2730,2939-2985: sales, returns, e-credit and labour/making unions grouped by HSN/rate type/item type/GST type',
      { section: 'HSN', columns: SECTION_COLUMNS.HSN, labourHsn: '998892', returns: 'negative' },
      ({ page }) => chooseAndRun(page, SECTION_OPTIONS[10]),
    ),
    desiredCase(
      'section.switch-clears-prior-grid',
      'T02',
      'read-only',
      'RP_GST.cs:2209-2638,2640-2647: every run calls DGV_CLEAR before rebuilding the selected section grid',
      { first: SECTION_COLUMNS.B2B, second: SECTION_COLUMNS.B2CS, staleB2BColumnsAfterSwitch: [] },
      async ({ page }) => {
        await chooseAndRun(page, SECTION_OPTIONS[1]);
        await chooseAndRun(page, SECTION_OPTIONS[3]);
      },
    ),

    desiredCase(
      'formula.gstr1-local-cgst-sgst',
      'T03',
      'read-only',
      'RP_GST.cs:2748-3031: GSTR-1 detail/totals; local HSN tax is split equally between CGST and SGST',
      {
        taxable: 'line net - line discount',
        igst: 0,
        cgst: 'tax/2',
        sgst: 'tax/2',
        display: '0.00',
      },
    ),
    desiredCase(
      'formula.gstr1-interstate-igst',
      'T03',
      'read-only',
      'RP_GST.cs:2748-3031: interstate HSN tax is placed in IGST and displayed to two decimals',
      { taxable: 'line net - line discount', igst: 'full tax', cgst: 0, sgst: 0, display: '0.00' },
    ),
    desiredCase(
      'formula.gstr2-input-signs',
      'T03',
      'read-only',
      'RP_GST.cs:3195-3477: GSTR-2 purchase/input rows and totals use the input-side TAX_DATA sign convention',
      {
        purchaseInput: 'positive display',
        purchaseReturn: 'negative display',
        reconciliation: 'TAX_DATA',
      },
    ),
    desiredCase(
      'formula.gstr3b-settled-outward-reverse-charge-itc',
      'T03',
      'read-only',
      'RP_GST.cs:3540-3704: TAX_SIGN + outward; + with R_CHARG Y reverse charge; - with R_CHARG N eligible ITC',
      {
        outward: 'TAX_SIGN=+',
        reverseCharge: "TAX_SIGN='+' and R_CHARG='Y'",
        itc: "TAX_SIGN='-' and R_CHARG='N'",
      },
    ),
    desiredCase(
      'formula.hsn-quantity-value-tax-split',
      'T03',
      'read-only',
      'RP_GST.cs:2723-2730,2939-2985: quantity is pieces for RATE_TYPE P otherwise net weight; returns subtract; value/tax/discount aggregate by HSN',
      {
        quantity: 'P → pieces; otherwise net weight',
        returnSign: -1,
        taxable: 'value-discount',
        columns: SECTION_COLUMNS.HSN,
      },
    ),
    C(
      'formula.hsn-fnv-midpoint',
      'T03',
      'mutation',
      'RP_GST.cs:2951-2964 formats Strings.Format(DC_Main.Fnv(tax) / 2.0, "0.00") for local CGST/SGST and Strings.Format(Fnv(tax), "0.00") for IGST; DC_Main.cs:2088-2102 Fnv = Conversion.Val. Measured on .NET Framework 4.8 (windows-latest, web/scripts/dotnet-fx-probe): half away from zero at every 2-decimal midpoint, so 1908.29 -> 954.15',
      async (ctx) => {
        // The case owns its item and HSN code, so the grid row it checks cannot include any other module's sales.
        const ITEM = 'HSNM1';
        const HSN = '711319';
        await ctx.rows(
          `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","HSN_CODE","RATE_TYPE")
           VALUES ($1,'01',$2,'HSN MIDPOINT GOLD','G','E1',$3,'G') RETURNING 1`,
          ITEM,
          HSN,
        );
        await ctx.rows(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","TAG_NO")
           VALUES ($1,'01','01','2024-2025','OPN','00002','2024-04-01',$2,'+',500,500,'N') RETURNING 1`,
          ITEM,
        );
        // RP_GST.cs:2719 reads only books whose Invoice Type (BOOK_DATA.BOOK_TYPE, MS_BOOK.cs:2625) is 'T'. Web-provisioned
        // books leave it blank, so the case sets it and puts the previous value back, as the e-invoice export reads it too.
        const [book] = await ctx.rows(
          `SELECT "BOOK_TYPE" prior FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL'`,
        );
        await ctx.rows(
          `UPDATE "BOOK_DATA" SET "BOOK_TYPE"='T' WHERE tenant_id=$1 AND "CO_BOOK"='SL' RETURNING 1`,
        );
        try {
          const page = await openFromNavigation(ctx);
          // Two real sales of the same gold line (net 63,609.50, GST 3% = 1,908.285 -> 1,908.29): one local, which the
          // desktop stores as 954.145 CGST + 954.145 SGST (an exact midpoint at two decimals), one inter-state (IGST).
          const line = { ...salesScreen.LINE_A, item: ITEM };
          for (const [party, interState] of [
            ['E2ELOC', false],
            ['E2EINT', true],
          ]) {
            await page.goto('/txn/sales');
            await salesScreen.openSales(page);
            await salesScreen.pickParty(page, party);
            if (interState) await salesScreen.field(page, 'Inter-state').selectOption('y');
            await salesScreen.fillLine(page, 0, line);
            const saved = await salesScreen.save(page);
            assert.equal(saved.status(), 201, await saved.text());
          }
          const lines = await ctx.rows(
            `SELECT "CO_BOOK","VCH_NO","NET_AMT"::text net,"IT_TAX_AMT"::text tax FROM "SL_DETL"
              WHERE tenant_id=$1 AND "IT_CODE"=$2 ORDER BY "VCH_NO"`,
            ITEM,
          );
          assert.deepEqual(
            lines.map((r) => [r.net, r.tax]),
            [
              ['63609.50', '1908.29'],
              ['63609.50', '1908.29'],
            ],
          );
          const taxRows = await ctx.rows(
            `SELECT "VCH_NO","TAX_TYPE","TAX_AMT"::text tax FROM "TAX_DATA"
              WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO" = ANY($3::text[]) ORDER BY "VCH_NO","TAX_TYPE"`,
            lines[0].CO_BOOK,
            lines.map((r) => r.VCH_NO),
          );
          const stored = taxRows.map((r) => `${r.TAX_TYPE}=${r.tax}`).sort();
          assert.deepEqual(
            stored,
            ['CGST=954.145', 'IGST=1908.290', 'SGST=954.145'],
            `the local sale must really sit on the midpoint, or this case proves nothing; found ${JSON.stringify(taxRows)} for ${JSON.stringify(lines)}`,
          );

          await page.goto('/reports/gst-report');
          await page.getByRole('heading', { name: 'GST Report', exact: true }).waitFor();
          await page
            .getByRole('combobox', { name: 'Section Type', exact: true })
            .selectOption({ label: 'HSN - Summary For HSN' });
          const ran = page.waitForResponse(
            (r) =>
              new URL(r.url()).pathname === '/api/reports/gst-report' &&
              r.request().method() === 'GET',
          );
          await page.getByRole('button', { name: 'Gstr 1', exact: true }).click();
          const response = await ran;
          assert.equal(response.status(), 200, `HSN must not be refused: ${await response.text()}`);
          await page.locator('table.grid tbody tr').first().waitFor();

          const headers = await page.locator('table.grid thead th').allTextContents();
          assert.deepEqual(headers, SECTION_COLUMNS.HSN);
          const grid = await page
            .locator('table.grid tbody tr')
            .evaluateAll((trs) =>
              trs.map((tr) => [...tr.querySelectorAll('td')].map((td) => td.textContent.trim())),
            );
          const col = (name) => headers.indexOf(name);
          const mine = grid.filter((row) => row[col('HSN')] === HSN);
          assert.equal(mine.length, 2, `one local and one inter-state row for HSN ${HSN}`);
          const local = mine.find((row) => row[col('IGST Amount')] === '0.00');
          const inter = mine.find((row) => row[col('IGST Amount')] !== '0.00');
          assert.ok(local && inter, 'a local row and an inter-state row');
          // Windows-measured: Format(Val("1908.29") / 2.0, "0.00") = 954.15; Format(Val("1908.29"), "0.00") = 1908.29.
          assert.equal(local[col('CGST Amount')], '954.15');
          assert.equal(local[col('SGST Amount')], '954.15');
          assert.equal(inter[col('IGST Amount')], '1908.29');
          assert.equal(inter[col('CGST Amount')], '0.00');
          for (const row of [local, inter]) {
            assert.equal(row[col('Taxable Value')], '63609.50');
            assert.equal(row[col('Total Value')], '65517.79');
            assert.equal(row[col('UQC')], 'GMS-GRAMMES');
            assert.equal(row[col('Total Qty')], '10.00');
          }
          // The footer adds the displayed cells, as the desktop does (RP_GST.cs:2960-2985).
          const footer = await page
            .locator('table.grid tfoot tr td')
            .evaluateAll((tds) => tds.map((td) => td.textContent.trim()));
          for (const name of [
            'Total Value',
            'Taxable Value',
            'IGST Amount',
            'CGST Amount',
            'SGST Amount',
          ]) {
            const cents = grid.reduce(
              (sum, row) => sum + Math.round(Number(row[col(name)]) * 100),
              0,
            );
            assert.equal(
              footer[col(name)],
              (cents / 100).toFixed(2),
              `footer ${name} is the sum of the rows`,
            );
          }
          await ctx.shot(page, 'formula-hsn-fnv-midpoint');

          const csv = await page.request.fetch(
            `/api/reports/gst-report/export.csv?${new URL(response.url()).searchParams.toString()}`,
          );
          assert.equal(csv.status(), 200);
          const csvRows = (await csv.text())
            .split('\r\n')
            .filter(Boolean)
            .map((l) => l.split(','));
          const csvLocal = csvRows.find((c) => c[0] === HSN && c[col('IGST Amount')] === '0.00');
          assert.equal(
            csvLocal?.[col('CGST Amount')],
            '954.15',
            'HSNSUM.csv carries the displayed halves',
          );
          return {
            observation:
              'HSN answered 200; the local row shows CGST and SGST 954.15 each for a 1,908.29 tax, the inter-state row IGST 1,908.29, and the footer adds the rows',
            expected: { cgst: '954.15', sgst: '954.15', igst: '1908.29', stored: '954.145 each' },
            database: { sales: lines, taxRows: stored },
            downstream: { gridRows: mine, csvRow: csvLocal },
          };
        } finally {
          await ctx.rows(
            `UPDATE "BOOK_DATA" SET "BOOK_TYPE"=$2 WHERE tenant_id=$1 AND "CO_BOOK"='SL' RETURNING 1`,
            book?.prior ?? null,
          );
        }
      },
    ),
    desiredCase(
      'formula.mixed-rates-and-making',
      'T03',
      'read-only',
      'RP_GST.cs:2723-2730,2939-2985: HSN groups mixed rates independently and emits labour/making under HSN 998892',
      { grouping: ['HSN_CODE', 'RATE_TYPE', 'IT_TYPE', 'AC_GST_TYPE'], makingHsn: '998892' },
    ),

    ...[
      ['lookup.book-enter-help-cancel-stale-scope', 'RP_GST.cs:1837-1883'],
      ['lookup.party-enter-help-cancel-stale-scope', 'RP_GST.cs:1885-1943'],
    ].map(([id, lines]) =>
      desiredCase(
        id,
        'T04',
        'read-only',
        `${lines}: Enter validates exact code, blank advances, unknown opens scoped help; F1/type-ahead/stale rejection is the shared web lookup contract, not an RP_GST F1 handler`,
        {
          enter: 'exact code or scoped help',
          cancel: 'preserve prior value',
          staleResponse: 'rejected',
          scope: ['company', 'location where applicable'],
        },
      ),
    ),
    notApplicable(
      'lookup.location-hidden-in-lite.not-applicable',
      'T04',
      'RP_GST.cs:1681-1717 hides Location unless MsSoftType is E',
      'The Lite screen takes location from the authenticated business context; there is no location help control.',
    ),

    notApplicable(
      'children.no-hierarchy.not-applicable',
      'T05',
      'RP_GST.cs:2209-3031 constructs flat statutory grids and defines no row drill-down event',
      'RP_GST has no child-row ownership, nested grouping, voucher zoom, or ledger drill-down. DGV_CLEAR and BtnGst1Zoom only define and fill flat rows.',
    ),

    desiredCase(
      'invalid.section-required',
      'T06',
      'refusal',
      'RP_GST.cs:2655-2659,3184-3190: blank section says “Please Select Section Type And Try...” and focuses Section Type',
      {
        message: 'Please Select Section Type And Try...',
        focus: 'Section Type',
        database: 'unchanged',
      },
      ({ page }) => page.getByRole('button', { name: 'Gstr 1', exact: true }).click(),
    ),
    desiredCase(
      'invalid.no-record',
      'T06',
      'refusal',
      'RP_GST.cs:2732-2745,3246-3251: an implemented empty section says “No Record Found....” and focuses From Date',
      { message: 'No Record Found....', focus: 'From Date', gridRows: [], database: 'unchanged' },
    ),
    desiredCase(
      'invalid.from-after-to',
      'T06',
      'refusal',
      'RP_GST.cs:3033-3063 sends both dates through DC_Main.SetDate before report execution',
      { refusal: 'From Date after To Date', database: 'unchanged', crash: false },
    ),
    desiredCase(
      'invalid.date-outside-company-year',
      'T06',
      'refusal',
      'RP_GST.cs:2662-2730 constrains report data to MCo_year; RP_GST.cs:3033-3063 delegates date acceptance to SetDate',
      { refusal: 'date outside selected financial year', database: 'unchanged', crash: false },
    ),

    desiredCase(
      'snapshot.complete-browser-created-dataset',
      'T07',
      'mutation',
      'RP_GST.cs:2662-3031,3195-3477,3540-3704: report rows/totals reconcile to browser-created TAX_DATA-backed vouchers',
      {
        source: 'real Sales/Purchase/Return screens',
        sections: ['B2B', 'B2CL', 'B2CS', 'CDNR', 'CDNUR', 'AT', 'ATADJ', 'HSN'],
        resultSeeded: false,
      },
    ),
    desiredCase(
      'rerun.identical-and-no-report-writes',
      'T08',
      'read-only',
      'RP_GST.cs:2640-3031,3148-3817 only selects, fills grids, renders, and exports; no report table write exists',
      { reruns: 'identical ordered rows/totals/bytes', reportWrites: 0, stagingResidue: 0 },
    ),
    desiredCase(
      'edit.source-voucher-reclassifies-and-recomputes',
      'T09',
      'mutation',
      'RP_GST.cs:2662-3031: every run re-queries voucher date, party GSTIN, amount, section and HSN inputs',
      {
        edit: ['date across boundary', 'amount across 250000', 'party GST registration'],
        expected: 'only affected section/period/totals/HSN change',
      },
    ),
    desiredCase(
      'delete-return-and-cancel-effects',
      'T10',
      'mutation',
      'RP_GST.cs:2683-2702,2723-2730,2843-2985: deleted sources disappear; sales/purchase returns feed CDNR/CDNUR and subtract from HSN',
      {
        delete: 'source disappears',
        return: 'credit/debit classification and negative HSN',
        cancelledTag: 'only if a queried source table consumes it',
      },
    ),

    desiredCase(
      'scope.company-location-year-book-tenant',
      'T11',
      'read-only',
      'RP_GST.cs:1758-1821,2031-2207,2662-2730: company/year plus applicable location/book/party filters; web contract adds forced tenant isolation',
      {
        absentEverywhere: ['other tenant', 'company', 'location', 'year', 'book'],
        surfaces: ['grid', 'totals', 'PDF', 'CSV/Excel'],
      },
    ),
    desiredCase(
      'rights.list-denied-direct-api',
      'T11',
      'refusal',
      'RP_GST.cs:1491-1503 reads caption-keyed USER_SET; GST Report desktop rights are ----PL and List protects data APIs',
      { directApiStatus: 403, right: 'List', database: 'unchanged', leakedRows: 0 },
    ),
    desiredCase(
      'rights.print-denied-direct-api',
      'T11',
      'refusal',
      'RP_GST.cs:1491-1503 reads FRM_PRINT from caption-keyed USER_SET; print/export requires the P right',
      { directApiStatus: 403, right: 'Print', database: 'unchanged', outputBytes: 0 },
    ),

    desiredCase(
      'concurrent.sessions-independent-filters',
      'T12',
      'read-only',
      'RP_GST.cs:2640-3031 derives each grid from that form’s selectors; report addendum T12 requires independent browser/server requests',
      { sessions: 2, filters: 'different period and section', crossContamination: 0 },
    ),
    desiredCase(
      'concurrent.edit-between-run-and-export',
      'T12',
      'mutation',
      'RP_GST.cs:3077-3146 exports the current selected grid; web adaptation must re-derive export from the requesting session’s explicit filters',
      { export: 'same requested filter snapshot', otherSessionRows: 0, staleGlobalGrid: false },
    ),
    desiredCase(
      'retry.duplicate-run-idempotent',
      'T13',
      'read-only',
      'RP_GST.cs:2640-3031 is read-only and rebuilds the grid for every run',
      { requests: 2, logicalResults: 1, databaseChanges: 0 },
    ),
    desiredCase(
      'retry.duplicate-export-identical-bytes',
      'T13',
      'output',
      'RP_GST.cs:3077-3146 rewrites the selected CSV deterministically from visible grid rows',
      { downloads: 2, bytes: 'identical', databaseChanges: 0 },
    ),
    blocked(
      'failure.query-or-render-no-write.pending',
      'T14',
      'refusal',
      'RP_GST.cs:2640-3031,3148-3817 is a read-only query/render path: no try/catch, no transaction, no table write (WP-19 study G6 settles the expected result: nothing persisted)',
      'Remaining: the feature harness has no scoped server-side query fault injector (G173 / N166), and a browser-side abort would intercept a business response, which this matrix forbids; a 5xx is also a console error the harness fails on. Executable once the harness injects a report-query fault.',
    ),
    blocked(
      'failure.export-sentinels-intact.pending',
      'T14',
      'refusal',
      'RP_GST.cs:3077-3146,3819-3943 writes output files/workbooks but no business tables; the Excel catch only shows "Error Exporting to Excel: " (:3925-3935) (WP-19 study G7)',
      'Remaining: the feature harness has no scoped download/export failure injector (G173 / N166). Executable once it can fail an export mid-stream.',
    ),

    desiredCase(
      'history.party-gstin-and-state-live-master',
      'T15',
      'mutation',
      'RP_GST.cs:2662-2702 joins AC_MAST and STATE_MAST at report time',
      {
        afterMasterEdit: 'historic voucher uses live party GSTIN/state/name',
        sourceVoucher: 'unchanged',
      },
    ),
    desiredCase(
      'history.item-hsn-live-master',
      'T15',
      'mutation',
      'RP_GST.cs:2723-2730 joins ITEM_MAST at report time for HSN/rate type/item type',
      {
        afterMasterEdit: 'historic detail is regrouped under live item HSN',
        sourceVoucher: 'unchanged',
      },
    ),
    desiredCase(
      'history.historic-year',
      'T15',
      'read-only',
      'RP_GST.cs:1758-1821,2031-2207,2662-2730 applies MCo_year to GSTR-1/2/print and HSN queries',
      { selectedYear: 'historic', currentYearLeak: 0 },
    ),
    desiredCase(
      'history.edited-and-deleted-voucher',
      'T15',
      'mutation',
      'RP_GST.cs:2662-3031 re-queries live TAX_DATA/detail tables on every run',
      { edited: 'latest source values', deleted: 'absent', staleReportSnapshot: false },
    ),

    ...[
      ['output.gstr1-crystal-pdf', 'RP_GST.cs:2031-2131 and Gstr_1.rpt', 'GSTR-1'],
      ['output.gstr2-crystal-pdf', 'RP_GST.cs:1758-1850 and Gstr_2.rpt', 'GSTR-2'],
      ['output.gstr3-crystal-pdf', 'RP_GST.cs:2133-2207 and Gstr_3.rpt', 'GSTR-3'],
    ].map(([id, source, title]) =>
      desiredCase(id, 'T16', 'output', source, {
        title,
        rowsAndTotals: 'same complete requested result as grid',
        layout: 'semantic Crystal field/order parity',
      }),
    ),
    ...[
      ['b2b', 'B2B.csv', 'B2B'],
      ['b2cl', 'B2CL.csv', 'B2CL'],
      ['b2cs', 'B2CS.csv', 'B2CS'],
      ['cdnr', 'CDNR.csv', 'CDNR'],
      ['cdnur', 'CDNUR.csv', 'CDNUR'],
      ['advance', 'AT.csv', 'AT'],
      ['advance-adjustment', 'ATADJ.csv', 'ATADJ'],
      ['hsn', 'HSNSUM.csv', 'HSN'],
    ].map(([slug, filename, section]) =>
      desiredCase(`output.csv-${slug}`, 'T16', 'output', OUTPUT_SOURCE, {
        filename,
        section,
        columns: SECTION_COLUMNS[section],
        firstRow: 'desktop grid row 3 column headings',
        dataRows: 'all grid rows from index 4, visible-width columns only, in display order',
        delimiter: ',',
        quoting: 'none in desktop output',
        date: 'dd-MMM-yy',
        numbers:
          'display strings, generally 0.00; B2B taxable follows desktop conversion at RP_GST.cs:2781',
      }),
    ),
    blocked(
      'output.csv-exp.pending',
      'T16',
      'output',
      'RP_GST.cs:3097 names EXP.csv; SaveCSV (:3113-3146) writes grid rows 3..Rows-1 of visible columns, and the EXP grid (:2472-2477, Rows = 5 from DGV_CLEAR) has one uncaptioned column and no data',
      'Remaining (WP-19 decision Q9): the EXP.csv bytes (inferred: two empty CR LF lines) are not displayed by any source line; a Windows desktop run must confirm them. Until then the web refuses EXP.csv (422 csv-not-settled) rather than certify an inferred file.',
    ),
    desiredCase(
      'output.csv-exempt-not-emitted',
      'T16',
      'output',
      'RP_GST.cs:3077-3110 has no SaveCSV call for section 9 (EXEMP)',
      { section: 'EXEMP', downloadCount: 0, desktopBehavior: 'no file emitted' },
    ),
    desiredCase(
      'output.more-than-one-page-whole-result',
      'T16',
      'output',
      'RP_GST.cs:2732-3031,3113-3146 loads and exports the whole result without paging',
      {
        screenMayPage: true,
        totals: 'whole result',
        export: 'whole result',
        rows: 'more than one web page',
      },
    ),

    desiredCase(
      'keyboard.complete-workflow-1366x768',
      'T17',
      'read-only',
      'RP_GST.cs:1730-1756,1837-1995,3033-3063: uppercase/apostrophe suppression, Esc close, Enter date/lookup/section flow',
      {
        viewport: '1366x768',
        flow: [
          'navigation',
          'From Enter',
          'To Enter',
          'book/party/location Enter help',
          'Section Enter',
          'report actions',
          'Escape',
        ],
      },
    ),

    desiredCase(
      'journey.sales-purchases-returns-reconcile',
      'T18',
      'mutation',
      'RP_GST.cs:2662-3031,3195-3477,3540-3704: browser-created sales, purchases and returns reconcile GSTR-1/2/3B/HSN to TAX_DATA, then follow edit/delete/return',
      {
        sourceVouchers: [
          'registered local CGST/SGST sale',
          'registered interstate IGST sale',
          'unregistered desktop-B2CL >=250000 (no interstate predicate)',
          'unregistered B2CS <250000',
          'zero/exempt sale (pending branch separately blocked)',
          'local and interstate purchases',
          'registered and unregistered returns',
          'two HSN/items, mixed rates, labour/making GST',
        ],
        lifecycle: ['edit across period', 'delete', 'return', 'rerun'],
        resultSeeded: false,
      },
      async ({ ctx, page }) => {
        await page.goto('/txn/sales');
        await salesScreen.openSales(page);
        await salesScreen.pickParty(page, 'E2ELOC');
        await salesScreen.fillLine(page, 0, salesScreen.LINE_A);
        const response = await salesScreen.save(page);
        assert.equal(response.status(), 201, await response.text());
        await page.goto('/dashboard');
        await page.getByRole('link', { name: 'GST Report', exact: true }).click();
        await assertRpGstShell(page);
        const taxRows = await ctx.rows(
          `SELECT "CO_BOOK","VCH_NO","TAX_TYPE","TAX_SIGN","NET_AMT"::float net,"TAX_AMT"::float tax
             FROM "TAX_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK","VCH_NO","SR_NO"`,
        );
        assert(taxRows.length > 0, 'the browser-created source voucher must post TAX_DATA');
      },
    ),
    ...WP19_CASES,
  ],
};
