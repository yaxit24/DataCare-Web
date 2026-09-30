/** Shared E CRNT fixture (X15): two E CRNT books with four BOOK_DETL slots, GST 10 with components,
 * a group sale account, two items and an other-year sentinel voucher. */
export const E_CRNT_CO = '01';
export const E_CRNT_LC = '01';
export const E_CRNT_YEAR = '2024-2025';
export const E_CRNT_BOOK = '146';

type Exec = (sql: string, ...params: unknown[]) => Promise<unknown>;

export async function seedECreditNoteFixture(
  exec: Exec,
  TENANT: string,
  options: { companyType?: string; employeeMandatory?: boolean } = {},
) {
  const CO = E_CRNT_CO;
  const LC = E_CRNT_LC;
  const YEAR = E_CRNT_YEAR;
  const BOOK = E_CRNT_BOOK;
  const seedBook = async (book: string, name: string) => {
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","ITM_TYPE","DATA_TYPE","BOOK_SR_NAME")
     VALUES ($1,$2,$3,$4,$5,'ECRNT','E CRNT','I','Y','SL_DATA','SL_DETL','A','A','CN')`,
      TENANT,
      CO,
      LC,
      book,
      name,
    );
    for (const [srNo, ac] of [
      [1, 'CRN001'],
      [2, 'CASH01'],
      [3, 'KSR001'],
      [4, 'ROF001'],
    ] as const) {
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","DATA_TYPE","BOOK_TYPE","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'ECRNT','E CRNT','A','','I')`,
        TENANT,
        CO,
        LC,
        book,
        srNo,
        ac,
        name,
      );
    }
  };

  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_NAME","CO_TYPE") VALUES ($1,$2,$3,'Credit Jewels',$4)`,
    TENANT,
    CO,
    LC,
    options.companyType ?? 'R',
  );
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","TAX_ROF","LBR_ROF","CASH_LIMIT","ALL_ROF_REMOVE","LBR_TYPE","EMP_CODE_MANDATORY")
     VALUES ($1,$2,2,0,0,'N','G',$3)`,
    TENANT,
    CO,
    options.employeeMandatory ? 'Y' : 'N',
  );
  for (const year of [YEAR, '2025-2026']) {
    const start = Number(year.slice(0, 4));
    await exec(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,$4,$5::timestamp)`,
      TENANT,
      CO,
      year,
      `${start}-04-01`,
      `${start + 1}-03-31`,
    );
  }
  await seedBook(BOOK, 'E Credit Note');
  await seedBook('147', 'Second E Credit Note');
  for (const [code, name, gst] of [
    ['CUST01', 'Credit Customer', 'L'],
    ['CUST02', 'Interstate Customer', 'I'],
    ['CRN001', 'Credit Note Control', 'L'],
    ['CASH01', 'Cash on Hand', 'L'],
    ['KSR001', 'Kasar', 'L'],
    ['ROF001', 'Round Off', 'L'],
    ['SALE01', 'Gold Sales', 'L'],
    ['GST001', 'Output GST', 'L'],
    ['BANK01', 'Bank', 'L'],
  ] as const) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES ($1,$2,$3,$4,$5,$6)`,
      TENANT,
      CO,
      LC,
      code,
      name,
      gst,
    );
  }
  await exec(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC") VALUES
       ($1,$2,'10',0,'N','GST 3%',3,'GST001'),
       ($1,$2,'10',1,'SGST','SGST 1.5',1.5,'GST001'),
       ($1,$2,'10',2,'CGST','CGST 1.5',1.5,'GST001'),
       ($1,$2,'10',3,'IGST','IGST 3',3,'GST001')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES ($1,$2,'G1','Gold','SALE01')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","GR_CODE","IT_TYPE","RATE_TYPE","PR_CODE") VALUES
       ($1,$2,'GOLD','Gold Ring','G1','G','G','P1'),
       ($1,$2,'CHAIN','Gold Chain Pc','G1','G','P','P1')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,$2,'E01','Employee One')`,
    TENANT,
    CO,
  );
  // Untouched sentinel: the same voucher number in another year must never be read or deleted.
  await exec(
    `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","TOT_AMT")
     VALUES ($1,$2,$3,'2025-2026',$4,'00001','2025-05-01','CUST01',999)`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
}

export const E_INVOICE_BOOK = 'EIN';

/** The E CRNT fixture plus an outward E INVOICE book (slots 1-5), TCS 20, TDS 25 and code 00. */
export async function seedEInvoiceFixture(
  exec: Exec,
  TENANT: string,
  options: { companyType?: string; employeeMandatory?: boolean } = {},
) {
  await seedECreditNoteFixture(exec, TENANT, options);
  const CO = E_CRNT_CO;
  const LC = E_CRNT_LC;
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
       "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","ITM_TYPE","DATA_TYPE","BOOK_SR_NAME")
     VALUES ($1,$2,$3,$4,'E Invoice','EINV','E INVOICE','O','Y','SL_DATA','SL_DETL','A','A','INV')`,
    TENANT,
    CO,
    LC,
    E_INVOICE_BOOK,
  );
  for (const [srNo, ac] of [
    [1, 'INV001'],
    [2, 'CASH01'],
    [3, 'KSR001'],
    [4, 'ROF001'],
    [5, 'ROF005'],
  ] as const) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","DATA_TYPE","BOOK_TYPE","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,'E Invoice','EINV','E INVOICE','A','','O')`,
      TENANT,
      CO,
      LC,
      E_INVOICE_BOOK,
      srNo,
      ac,
    );
  }
  for (const [code, name] of [
    ['INV001', 'Sales Control'],
    ['ROF005', 'Round Off Invoice'],
    ['TCS001', 'TCS Payable'],
    ['TDS001', 'TDS Receivable'],
  ] as const) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  }
  await exec(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC") VALUES
       ($1,$2,'20',0,'TCS','TCS 0.1%',0.1,'TCS001'),
       ($1,$2,'25',0,'TDS','TDS 1%',1,'TDS001'),
       ($1,$2,'00',0,'NIL','No TCS/TDS',0,'')`,
    TENANT,
    CO,
  );
}
