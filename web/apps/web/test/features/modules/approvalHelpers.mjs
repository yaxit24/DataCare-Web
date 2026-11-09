import assert from 'node:assert/strict';
import { ITEMS, PARTIES } from '../fixtures/catalogue.mjs';

export const TENANT = 'feature-e2e';
export const ISSUE_BOOK = 'TUR';
export const RETURN_BOOK = 'TRR';
export const EMPLOYEE = 'E01';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
export const YEAR = `${startYear}-${startYear + 1}`;
export const DAY = `${startYear}-07-10`;
let serial = 992000000;

export const as = (user, slot) => ({
  user,
  slot,
  get password() {
    return process.env.FEATURE_E2E_PASSWORD;
  },
});
export const label = (page, name) => page.getByLabel(name, { exact: true });
export const isApi = (response, method, path) =>
  response.request().method() === method && new URL(response.url()).pathname === `/api${path}`;

export async function ensureApprovalFixture(ctx) {
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME")
     SELECT $1::text,'01',$2::text,'APPROVAL EMPLOYEE'
      WHERE NOT EXISTS (SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "EMP_CODE"=$2::text)`,
    TENANT,
    EMPLOYEE,
  );
}

/** A live BAR_DETL tag plus its positive MAIN_STOCK row, as Tag Opening leaves it. */
export async function seedApprovalTag(ctx, prefix = 'AIE') {
  await ensureApprovalFixture(ctx);
  serial += 1;
  const tag = `${prefix}${String(serial).slice(-6)}`;
  const sr = serial - 992000000;
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
       "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
       "ITM_TOUCH","ITM_FINE","TBL_CODE","IT_TYPE","APR_ISU","APP_TRFR")
     VALUES ($1,'01','01',$2,'TOP','09001',$3,$3,$4::date,'TAG OPENING','I',$5,$6,$7,1,10.5,10,91.6,
             9.16,'001','G','N','N')`,
    TENANT,
    YEAR,
    sr,
    DAY,
    tag,
    serial,
    ITEMS.gold.code,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
       "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
     VALUES ($1,'01','01',$2,'TOP','09001',$3,1,$4::date,$5,$6,$7,'P','+',1,1,10.5,10)`,
    TENANT,
    YEAR,
    sr,
    DAY,
    ITEMS.gold.code,
    tag,
    serial,
  );
  return { tag, serial };
}

/** Add the BAR_DETL richness and BAR_IDTL component copied by TR_APR_ISU tag selection. */
export async function seedApprovalStone(ctx, source) {
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","OTH_DETL_POSTING")
     SELECT $1::text,'01','DIAE1','E2E ROUND DIAMOND','D','DI','Y'
      WHERE NOT EXISTS (SELECT 1 FROM "ITEM_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "IT_CODE"='DIAE1')`,
    TENANT,
  );
  await ctx.owner.$executeRawUnsafe(
    `UPDATE "BAR_DETL" SET "LOT_NO"='LOT-E2E',"ITM_COLOR"='ROSE',"TAG_COST"=501.25,
            "HM_ID"='HUID1',"HM_ID2"='HUID2',"HM_ID_WT"=.101,"HM_ID2_WT"=.102,
            "BAG_WT"=.15,"ITM_OTH_WT"=.5,"ITM_GHT_WT"=.25,"ITM_WEST_PRC"=2,
            "LBR_PRC"=1.25,"ITM_AMT"=61234,"KR_NET_WT"=10,"KR_TOUCH"=91,
            "KR_WEST_PRC"=1,"KR_FINE"=9.2,"RATE_TYPE"='W',"DESIGN_IMG_ID"='IMG-E2E'
      WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "TAG_NO"=$2 AND "VCH_SRNO"=$3`,
    TENANT,
    source.tag,
    source.serial,
  );
  await ctx.owner.$executeRawUnsafe(
    `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
       "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","IT_TYPE","DM_CODE","DM_NAME","DM_SIZE","DM_SFNO","DM_LEB",
       "IT_PCS","IT_PCS_WT","IT_GWT","KR_WT","IT_CON_PRC","IT_CON_WT","IT_RATE_TYPE","IT_RATE","IT_AMT",
       "IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","KR_LESS_PRC","KR_CON_PRC","KR_CON_WT","KR_RATE","KR_AMT",
       "KR_LBR_RATE","KR_LBR_AMT","KR_NET_AMT")
     VALUES ($1,'01','01',$2,'TOP','09001',1,7,$3::date,$4,$5,'DIAE1','D','RD','Round','1.2MM','CERT-1','GIA',
             2,.02,.25,.24,5,.013,'W',5000,1250,100,25,1275,1,4,.01,4500,1080,90,21.6,1101.6)`,
    TENANT,
    YEAR,
    DAY,
    source.tag,
    source.serial,
  );
}

async function pick(input, code) {
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: false }).first().waitFor();
  await input.press('Enter');
}

export async function openApproval(ctx, kind = 'issue', session) {
  await ensureApprovalFixture(ctx);
  const current = session ?? (await ctx.session());

  const { page } = current;
  await page.goto(kind === 'issue' ? '/txn/tour' : '/txn/tour-return');
  await page
    .getByRole('heading', {
      name: kind === 'issue' ? 'Approval Issue' : 'Approval Return',
      exact: true,
    })
    .waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  const expected = kind === 'issue' ? ISSUE_BOOK : RETURN_BOOK;
  for (let attempt = 0; attempt < 50 && (await book.inputValue()) !== expected; attempt += 1)
    await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), expected);
  return { ...current, page, book };
}

export async function fillIssue(page, tag, description = 'browser approval') {
  await label(page, 'Vch Date').fill(DAY);
  await pick(label(page, 'Party Code'), PARTIES.local.code);
  await pick(label(page, 'Employee Code'), EMPLOYEE);
  await label(page, 'Vch Desc').fill(description);
  const tagInput = label(page, 'TagNo line 1');
  await tagInput.fill(tag);
  await tagInput.locator('xpath=..').getByText(tag, { exact: false }).first().waitFor();
  await tagInput.press('Enter');
  await page.waitForFunction(() => {
    const input = document.querySelector('input[aria-label="ItCode line 1"]');
    return input && input.value;
  });
}

export async function saveApproval(page, kind = 'issue', method = 'POST') {
  const expectedPath = kind === 'issue' ? '/tour/issue' : '/tour/return';
  const [response] = await Promise.all([
    page.waitForResponse((answer) => {
      const path = new URL(answer.url()).pathname;
      if (answer.request().method() !== method) return false;
      if (method === 'POST') return path === `/api${expectedPath}`;
      return kind === 'issue'
        ? /^\/api\/tour\/\d+$/.test(path)
        : /^\/api\/tour\/return\/\d+$/.test(path);
    }),
    page.getByTestId(`approval-${kind}-save`).click(),
  ]);
  return response;
}

export async function createIssue(ctx, tag, description = 'browser approval', session) {
  const { page } = await openApproval(ctx, 'issue', session);
  await fillIssue(page, tag, description);
  const response = await saveApproval(page, 'issue');
  assert.equal(response.status(), 201, await response.text());
  const result = await response.json();
  await page.getByText(`Saved — Approval Issue #${result.vchNo}`, { exact: true }).waitFor();
  return { page, result, voucherNo: String(result.voucherNo), tag };
}

export async function reopenApproval(page, kind, voucherNo) {
  let box = label(page, 'Vch No');
  if (!(await box.isEditable())) {
    await page.getByTestId(`approval-${kind}-new`).click();
    box = label(page, 'Vch No');
  }
  await box.fill(voucherNo);
  const path = kind === 'issue' ? `/api/tour/${voucherNo}` : `/api/tour/return/${voucherNo}`;
  await Promise.all([
    page.waitForResponse((response) => new URL(response.url()).pathname === path),
    box.press('Enter'),
  ]);
  await page.getByText(`Loaded voucher ${voucherNo}`, { exact: true }).waitFor();
}

export async function prepareReturn(ctx, issue, session) {
  const { page } = await openApproval(ctx, 'return', session);
  await label(page, 'Vch Date').fill(DAY);
  await pick(label(page, 'Party Code'), PARTIES.local.code);
  await pick(label(page, 'Employee Code'), EMPLOYEE);
  await label(page, 'Original Issue Vch No').fill(issue.voucherNo);
  await Promise.all([
    page.waitForResponse(
      (response) => new URL(response.url()).pathname === `/api/tour/${issue.voucherNo}/lines`,
    ),
    page.getByTestId('approval-return-load-lines').click(),
  ]);
  await label(page, 'TagNo line 1').waitFor();
  assert.equal(await label(page, 'TagNo line 1').inputValue(), issue.tag);
  return page;
}

export async function createReturn(ctx, issue, description = 'browser return', session) {
  const page = await prepareReturn(ctx, issue, session);
  await label(page, 'Vch Desc').fill(description);
  const response = await saveApproval(page, 'return');
  assert.equal(response.status(), 201, await response.text());
  const result = await response.json();
  await page.getByText(`Saved — Approval Return #${result.vchNo}`, { exact: true }).waitFor();
  return { page, result, voucherNo: String(result.voucherNo) };
}

export const approvalRows = (ctx, book, voucherNo) =>
  ctx.rows(
    `SELECT "BOOK_NAME" book,"VCH_TYPE" type,"INOUT_TYPE" inout,"TAG_NO" tag,"VCH_SRNO"::float8 serial,
            "ITM_NWT"::float8 net,"ITM_FINE"::float8 fine,"ISU_REC" received,"VCH_DESC" description
       FROM "APR_DETL" d LEFT JOIN "APR_DATA" h ON h.tenant_id=d.tenant_id AND h."CO_CODE"=d."CO_CODE"
        AND h."LC_CODE"=d."LC_CODE" AND h."CO_YEAR"=d."CO_YEAR" AND h."CO_BOOK"=d."CO_BOOK"
        AND h."VCH_NO"=d."VCH_NO"
      WHERE d.tenant_id=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"=$3 ORDER BY d."SR_NO"`,
    book,
    voucherNo,
  );

export const approvalStock = (ctx, book, voucherNo) =>
  ctx.rows(
    `SELECT "BOOK_NAME" book,"VCH_TYPE" type,"TR_TYPE" tr,"ITM_SIGN" sign,"TAG_NO" tag,
            "VCH_SRNO"::float8 serial,"ITM_NWT"::float8 net,"ITM_FINE"::float8 fine
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
    book,
    voucherNo,
  );

export const tagState = async (ctx, tag) =>
  (
    await ctx.rows(
      `SELECT b."APR_ISU" apr,b."APP_TRFR" transfer,
              coalesce((SELECT sum(CASE WHEN m."ITM_SIGN"='+' THEN 1 ELSE -1 END)::int FROM "MAIN_STOCK" m
                         WHERE m.tenant_id=b.tenant_id AND m."TAG_NO"=b."TAG_NO"),0) balance
         FROM "BAR_DETL" b WHERE b.tenant_id=$1 AND b."TAG_NO"=$2 ORDER BY b.row_id LIMIT 1`,
      tag,
    )
  )[0];

/** Every table an approval save or delete writes (TR_APR_ISU.cs:6123-6431, :6608-6680), counted per tenant. */
const WRITE_TABLES = [
  'APR_DATA',
  'APR_DETL',
  'APR_IDTL',
  'MAIN_STOCK',
  'DM_DATA',
  'REMARK_DATA',
  'TEMP_BOOK_DATA',
  'DELETE_DATA',
];
export async function approvalWriteCounts(ctx) {
  const counts = {};
  for (const table of WRITE_TABLES) {
    const [row] = await ctx.rows(`SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1`);
    counts[table] = row.n;
  }
  return counts;
}

/**
 * T14: run `work` while REMARK_DATA refuses the voucher's description row. REMARK_DATA is the writer's last
 * effect (after the APR rows, stock, BAR flag and source closure), so a committed partial save would show.
 */
export async function withRemarkFault(ctx, book, remark, work) {
  const name = `e2e_approval_fault_${book.toLowerCase()}`;
  await ctx.owner.$executeRawUnsafe(
    `CREATE OR REPLACE FUNCTION ${name}() RETURNS trigger LANGUAGE plpgsql AS $fault$
     BEGIN
       IF NEW.tenant_id='${TENANT}' AND NEW."CO_BOOK"='${book}' AND upper(btrim(NEW."VCH_REMARK"))=upper('${remark}') THEN
         RAISE EXCEPTION 'e2e approval fault after every other write';
       END IF;
       RETURN NEW;
     END $fault$`,
  );
  await ctx.owner.$executeRawUnsafe(
    `CREATE TRIGGER ${name} AFTER INSERT ON "REMARK_DATA" FOR EACH ROW EXECUTE FUNCTION ${name}()`,
  );
  try {
    return await work();
  } finally {
    await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS ${name} ON "REMARK_DATA"`);
    await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS ${name}()`);
  }
}
