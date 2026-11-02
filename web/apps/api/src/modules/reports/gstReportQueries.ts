import type { Tx } from '../shared/txBudget.js';
import type {
  GstReportInput,
  RawGstr3bResult,
  RawHsnReportRow,
  RawTaxReportRow,
} from './gstReportTypes.js';

const OUTWARD_BOOKS = ['SALES', 'LABOUR WORK', 'SERVICE INC', 'E INVOICE'];
const PURCHASE_BOOKS = ['PURCHASE', 'KARIGAR RECEIPT', 'OTH SERVICE'];
const NOTE_BOOKS = ['SALES RETURNE', 'PURC RETURN'];

function optionalScope(input: GstReportInput, alias: string, params: unknown[]): string {
  let sql = '';
  if (input.bookCode) {
    params.push(input.bookCode);
    sql += ` AND ${alias}."CO_BOOK"=$${params.length}`;
  }
  if (input.partyCode) {
    params.push(input.partyCode);
    sql += ` AND ${alias}."AC_CODE"=$${params.length}`;
  }
  return sql;
}

function inValues(values: readonly string[], params: unknown[]): string {
  return values
    .map((value) => {
      params.push(value);
      return `$${params.length}`;
    })
    .join(',');
}

/** One tenant-bound company caption read inside the report's shared snapshot. */
export async function gstCompanyNameTx(tx: Tx, input: GstReportInput): Promise<string> {
  const rows = await tx.$queryRawUnsafe<Array<{ companyName: string }>>(
    `SELECT COALESCE(c."CO_NAME",'') AS "companyName"
       FROM "CO_MAST" c
      WHERE c.tenant_id=$1 AND c."CO_CODE"=$2
      LIMIT 1`,
    input.tenantId,
    input.coCode,
  );
  return String(rows[0]?.companyName ?? '');
}

/**
 * TAX_DATA source used by B2B/B2CL/B2CS/CDNR/CDNUR/AT/ATADJ. Every joined identity includes tenant_id;
 * location/year/date and optional book/party predicates are applied before any presentation or totals.
 */
export async function gstTaxRowsTx(tx: Tx, input: GstReportInput): Promise<RawTaxReportRow[]> {
  const params: unknown[] = [
    input.tenantId,
    input.coCode,
    input.lcCode,
    input.coYear,
    input.fromDate,
    input.toDate,
  ];
  const section = input.section!;
  let sectionSql = '';
  if (section === 'B2B' || section === 'B2CL' || section === 'B2CS') {
    const books = input.view === 'gstr2' ? PURCHASE_BOOKS : OUTWARD_BOOKS;
    params.push(input.view === 'gstr2' ? 'P' : 'S');
    sectionSql += ` AND a."TRAN_TYPE"=$${params.length}`;
    sectionSql += ` AND a."BOOK_NAME" IN (${inValues(books, params)})`;
    if (section === 'B2B') sectionSql += ` AND COALESCE(b."AC_GSTNO",'')<>''`;
    if (section === 'B2CL')
      sectionSql += ` AND COALESCE(b."AC_GSTNO",'')='' AND a."TOT_AMT">=250000`;
    if (section === 'B2CS') {
      sectionSql += ` AND COALESCE(b."AC_GSTNO",'')='' AND a."TOT_AMT"<250000 AND a."SR_NO" IN (1,3,10,30)`;
    }
  } else if (section === 'CDNR' || section === 'CDNUR') {
    sectionSql += ` AND a."BOOK_NAME" IN (${inValues(NOTE_BOOKS, params)})`;
    sectionSql +=
      section === 'CDNR'
        ? ` AND COALESCE(b."AC_GSTNO",'')<>''`
        : ` AND COALESCE(b."AC_GSTNO",'')=''`;
  } else if (section === 'AT') {
    params.push('SALES ORDER');
    sectionSql += ` AND a."BOOK_NAME"=$${params.length} AND a."SR_NO" IN (1,3)`;
  } else if (section === 'ATADJ') {
    params.push('ORD ADJUST');
    sectionSql += ` AND a."BOOK_NAME"=$${params.length} AND a."SR_NO" IN (11,13,21,23,31,33,41,43,51,53)`;
  }
  const optional = optionalScope(input, 'a', params);
  return tx.$queryRawUnsafe<RawTaxReportRow[]>(
    `SELECT COALESCE(a."CO_BOOK",'') AS "coBook",
            COALESCE(a."BOOK_NAME",'') AS "bookName",
            COALESCE(e."BOOK_SR_NAME",'') AS "bookPrefix",
            COALESCE(a."AC_CODE",'') AS "acCode",
            COALESCE(b."AC_NAME",'') AS "acName",
            COALESCE(b."AC_GSTNO",'') AS gstin,
            COALESCE(st."STATE_CODE",'') AS "stateCode",
            COALESCE(st."STATE_NAME",b."AC_STATE",'') AS "stateName",
            COALESCE(a."VCH_NO",'') AS "voucherNo",
            COALESCE(to_char(a."VCH_DATE",'YYYY-MM-DD'),'') AS "voucherDate",
            COALESCE(a."TOT_AMT",0)::text AS "invoiceValue",
            COALESCE(a."R_CHARG",'') AS "reverseCharge",
            COALESCE(tm."TAX_PRC",a."TAX_PRC",0)::text AS "taxRate",
            COALESCE(a."TAX_CODE",'') AS "taxCode",
            COALESCE(a."NET_AMT",0)::text AS "netAmount",
            COALESCE(a."DISC_AMT",0)::text AS "discountAmount",
            COALESCE(be."BOOK_SR_NAME",'') AS "billBookPrefix",
            COALESCE(a."BILL_NO",'') AS "billNo",
            COALESCE(to_char(a."BILL_DATE",'YYYY-MM-DD'),'') AS "billDate",
            COALESCE(a."SR_NO",0)::text AS "srNo"
       FROM "TAX_DATA" a
       LEFT JOIN LATERAL (
         SELECT m."AC_NAME",m."AC_GSTNO",m."AC_STATE"
           FROM "AC_MAST" m
          WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE"
            AND (m."LC_CODE"=a."LC_CODE" OR m."LC_CODE" IS NULL OR m."LC_CODE"='00')
          ORDER BY CASE WHEN m."LC_CODE"=a."LC_CODE" THEN 0 ELSE 1 END,m.row_id
          LIMIT 1
       ) b ON TRUE
       LEFT JOIN LATERAL (
         SELECT s."STATE_CODE",s."STATE_NAME"
           FROM "STATE_MAST" s
          WHERE s.tenant_id=a.tenant_id AND s."STATE_NAME"=b."AC_STATE"
          ORDER BY s.row_id LIMIT 1
       ) st ON TRUE
       LEFT JOIN LATERAL (
         SELECT t."TAX_PRC"
           FROM "TAX_MAST" t
          WHERE t.tenant_id=a.tenant_id AND t."CO_CODE"=a."CO_CODE"
            AND t."TAX_CODE"=a."TAX_CODE" AND t."SR_NO"=0
          ORDER BY t.row_id LIMIT 1
       ) tm ON TRUE
       LEFT JOIN LATERAL (
         SELECT d."BOOK_SR_NAME"
           FROM "BOOK_DATA" d
          WHERE d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."CO_BOOK"=a."CO_BOOK"
            AND (d."LC_CODE"=a."LC_CODE" OR d."LC_CODE" IS NULL OR d."LC_CODE"='00')
          ORDER BY CASE WHEN d."LC_CODE"=a."LC_CODE" THEN 0 ELSE 1 END,d.row_id LIMIT 1
       ) e ON TRUE
       LEFT JOIN LATERAL (
         SELECT d."BOOK_SR_NAME"
           FROM "BOOK_DATA" d
          WHERE d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."CO_BOOK"=a."BILL_DBCD"
            AND (d."LC_CODE"=a."LC_CODE" OR d."LC_CODE" IS NULL OR d."LC_CODE"='00')
          ORDER BY CASE WHEN d."LC_CODE"=a."LC_CODE" THEN 0 ELSE 1 END,d.row_id LIMIT 1
       ) be ON TRUE
      WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4
        AND a."VCH_DATE">=$5::date AND a."VCH_DATE"<=$6::date
        ${sectionSql}${optional}
      ORDER BY a."VCH_DATE",a."CO_BOOK",a."VCH_NO",COALESCE(tm."TAX_PRC",a."TAX_PRC",0),a.row_id`,
    ...params,
  );
}

function hsnArmScope(alias: string, input: GstReportInput): string {
  let sql = ` ${alias}.tenant_id=$1 AND ${alias}."CO_CODE"=$2 AND ${alias}."LC_CODE"=$3
    AND ${alias}."CO_YEAR"=$4 AND ${alias}."VCH_DATE">=$5::date AND ${alias}."VCH_DATE"<=$6::date`;
  if (input.bookCode) sql += ` AND ${alias}."CO_BOOK"=$7`;
  if (input.partyCode) sql += ` AND ${alias}."AC_CODE"=$${input.bookCode ? 8 : 7}`;
  return sql;
}

/** The five source arms of RP_GST HSN: sale, return, e-credit, labour item and labour service. */
export async function gstHsnRowsTx(tx: Tx, input: GstReportInput): Promise<RawHsnReportRow[]> {
  const params: unknown[] = [
    input.tenantId,
    input.coCode,
    input.lcCode,
    input.coYear,
    input.fromDate,
    input.toDate,
  ];
  if (input.bookCode) params.push(input.bookCode);
  if (input.partyCode) params.push(input.partyCode);
  const scope = (alias: string) => hsnArmScope(alias, input);
  return tx.$queryRawUnsafe<RawHsnReportRow[]>(
    `WITH source AS (
       SELECT i."HSN_CODE" AS hsn,i."RATE_TYPE" AS rate_type,i."IT_TYPE" AS item_type,
              ac."AC_GST_TYPE" AS gst_type,
              CASE WHEN i."RATE_TYPE"='P' THEN COALESCE(d."ITM_PCS",0) ELSE COALESCE(d."ITM_NWT",0) END::numeric AS qty,
              COALESCE(d."NET_AMT",0)::numeric AS item_amount,COALESCE(d."IT_TAX_AMT",0)::numeric AS item_tax,
              COALESCE(d."IT_DISC_AMT",0)::numeric AS item_discount
         FROM "SL_DETL" d
         JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
         JOIN "BOOK_DATA" bk ON bk.tenant_id=d.tenant_id AND bk."CO_CODE"=d."CO_CODE" AND bk."LC_CODE"=d."LC_CODE" AND bk."CO_BOOK"=d."CO_BOOK"
         LEFT JOIN "AC_MAST" ac ON ac.tenant_id=d.tenant_id AND ac."CO_CODE"=d."CO_CODE" AND ac."LC_CODE"=d."LC_CODE" AND ac."AC_CODE"=d."AC_CODE"
        WHERE ${scope('d')} AND bk.tenant_id=$1 AND bk."BOOK_TYPE"='T'
          AND bk."MAIN_BOOK" IN ('SALES','LABOUR WORK','SERVICE INC','E INVOICE')
       UNION ALL
       SELECT i."HSN_CODE",i."RATE_TYPE",i."IT_TYPE",ac."AC_GST_TYPE",
              -(CASE WHEN i."RATE_TYPE"='P' THEN COALESCE(r."ITM_PCS",0) ELSE COALESCE(r."ITM_NWT",0) END)::numeric,
              -COALESCE(r."NET_AMT",0)::numeric,-COALESCE(r."RTN_IT_TAX_AMT",0)::numeric,0::numeric
         FROM "SL_DETL_RTN" r
         JOIN "ITEM_MAST" i ON i.tenant_id=r.tenant_id AND i."CO_CODE"=r."CO_CODE" AND i."IT_CODE"=r."IT_CODE"
         JOIN "BOOK_DATA" bk ON bk.tenant_id=r.tenant_id AND bk."CO_CODE"=r."CO_CODE" AND bk."LC_CODE"=r."LC_CODE" AND bk."CO_BOOK"=r."CO_BOOK"
         LEFT JOIN "AC_MAST" ac ON ac.tenant_id=r.tenant_id AND ac."CO_CODE"=r."CO_CODE" AND ac."LC_CODE"=r."LC_CODE" AND ac."AC_CODE"=r."AC_CODE"
        WHERE ${scope('r')} AND bk.tenant_id=$1 AND bk."BOOK_TYPE"='T'
       UNION ALL
       SELECT i."HSN_CODE",i."RATE_TYPE",i."IT_TYPE",ac."AC_GST_TYPE",
              -(CASE WHEN i."RATE_TYPE"='P' THEN COALESCE(d."ITM_PCS",0) ELSE COALESCE(d."ITM_NWT",0) END)::numeric,
              -COALESCE(d."NET_AMT",0)::numeric,-COALESCE(d."IT_TAX_AMT",0)::numeric,-COALESCE(d."IT_DISC_AMT",0)::numeric
         FROM "SL_DETL" d
         JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
         JOIN "BOOK_DATA" bk ON bk.tenant_id=d.tenant_id AND bk."CO_CODE"=d."CO_CODE" AND bk."LC_CODE"=d."LC_CODE" AND bk."CO_BOOK"=d."CO_BOOK"
         LEFT JOIN "AC_MAST" ac ON ac.tenant_id=d.tenant_id AND ac."CO_CODE"=d."CO_CODE" AND ac."LC_CODE"=d."LC_CODE" AND ac."AC_CODE"=d."AC_CODE"
        WHERE ${scope('d')} AND bk.tenant_id=$1 AND bk."BOOK_TYPE"='T' AND bk."MAIN_BOOK"='E CRNT'
       UNION ALL
       SELECT i."HSN_CODE",i."RATE_TYPE",i."IT_TYPE",ac."AC_GST_TYPE",
              (CASE WHEN i."RATE_TYPE"='P' THEN COALESCE(l."ITM_PCS",0) ELSE COALESCE(l."ITM_NWT",0) END)::numeric,
              COALESCE(l."NET_AMT",0)::numeric,
              COALESCE(NULLIF(l."IT_TAX_AMT",''),'0')::numeric,
              COALESCE(l."DISC_AMT",0)::numeric
         FROM "LBR_ISU_DETL" l
         JOIN "ITEM_MAST" i ON i.tenant_id=l.tenant_id AND i."CO_CODE"=l."CO_CODE" AND i."IT_CODE"=l."IT_CODE"
         JOIN "BOOK_DATA" bk ON bk.tenant_id=l.tenant_id AND bk."CO_CODE"=l."CO_CODE" AND bk."LC_CODE"=l."LC_CODE" AND bk."CO_BOOK"=l."CO_BOOK"
         LEFT JOIN "AC_MAST" ac ON ac.tenant_id=l.tenant_id AND ac."CO_CODE"=l."CO_CODE" AND ac."LC_CODE"=l."LC_CODE" AND ac."AC_CODE"=l."AC_CODE"
        WHERE ${scope('l')} AND bk.tenant_id=$1 AND bk."BOOK_TYPE"='T' AND bk."MAIN_BOOK"='LABOUR WORK'
       UNION ALL
       SELECT '998892',i."RATE_TYPE",i."IT_TYPE",ac."AC_GST_TYPE",COALESCE(l."ITM_NWT",0)::numeric,
              COALESCE(l."LBR_AMT",0)::numeric,COALESCE(NULLIF(l."IT_LBR_TAX",''),'0')::numeric,0::numeric
         FROM "LBR_ISU_DETL" l
         JOIN "ITEM_MAST" i ON i.tenant_id=l.tenant_id AND i."CO_CODE"=l."CO_CODE" AND i."IT_CODE"=l."IT_CODE"
         JOIN "BOOK_DATA" bk ON bk.tenant_id=l.tenant_id AND bk."CO_CODE"=l."CO_CODE" AND bk."LC_CODE"=l."LC_CODE" AND bk."CO_BOOK"=l."CO_BOOK"
         LEFT JOIN "AC_MAST" ac ON ac.tenant_id=l.tenant_id AND ac."CO_CODE"=l."CO_CODE" AND ac."LC_CODE"=l."LC_CODE" AND ac."AC_CODE"=l."AC_CODE"
        WHERE ${scope('l')} AND bk.tenant_id=$1 AND bk."BOOK_TYPE"='T' AND bk."MAIN_BOOK"='LABOUR WORK'
     )
     SELECT COALESCE(hsn,'') AS hsn,COALESCE(rate_type,'') AS "rateType",COALESCE(item_type,'') AS "itemType",
            COALESCE(gst_type,'') AS "gstType",COALESCE(SUM(qty),0)::text AS quantity,
            COALESCE(SUM(item_amount),0)::text AS "itemAmount",COALESCE(SUM(item_tax),0)::text AS "itemTax",
            COALESCE(SUM(item_discount),0)::text AS "itemDiscount"
       FROM source
      GROUP BY hsn,rate_type,item_type,gst_type
      ORDER BY hsn,rate_type,item_type,gst_type`,
    ...params,
  );
}

/** Desktop-computed GSTR-3B rows only: 3.1(a), 3.1(d), and 4(A)(5). */
export async function gstGstr3bTx(tx: Tx, input: GstReportInput): Promise<RawGstr3bResult> {
  const params: unknown[] = [
    input.tenantId,
    input.coCode,
    input.lcCode,
    input.coYear,
    input.fromDate,
    input.toDate,
  ];
  const optional = optionalScope(input, 'a', params);
  const rows = await tx.$queryRawUnsafe<Array<Record<string, string>>>(
    `SELECT
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='S' AND a."TAX_SIGN"='+' AND COALESCE(a."R_CHARG",'N')<>'Y' AND a."TAX_TYPE" IN ('IGST','SGST') THEN a."NET_AMT" ELSE 0 END),0)::text AS outward_taxable,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='S' AND a."TAX_SIGN"='+' AND COALESCE(a."R_CHARG",'N')<>'Y' AND a."TAX_TYPE"='IGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS outward_igst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='S' AND a."TAX_SIGN"='+' AND COALESCE(a."R_CHARG",'N')<>'Y' AND a."TAX_TYPE"='CGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS outward_cgst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='S' AND a."TAX_SIGN"='+' AND COALESCE(a."R_CHARG",'N')<>'Y' AND a."TAX_TYPE"='SGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS outward_sgst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."R_CHARG"='Y' AND a."TAX_TYPE" IN ('IGST','SGST') THEN a."NET_AMT" ELSE 0 END),0)::text AS reverse_taxable,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."R_CHARG"='Y' AND a."TAX_TYPE"='IGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS reverse_igst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."R_CHARG"='Y' AND a."TAX_TYPE"='CGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS reverse_cgst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."R_CHARG"='Y' AND a."TAX_TYPE"='SGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS reverse_sgst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."TAX_SIGN"='-' AND a."R_CHARG"='N' AND a."TAX_TYPE" IN ('IGST','SGST') THEN a."NET_AMT" ELSE 0 END),0)::text AS itc_taxable,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."TAX_SIGN"='-' AND a."R_CHARG"='N' AND a."TAX_TYPE"='IGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS itc_igst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."TAX_SIGN"='-' AND a."R_CHARG"='N' AND a."TAX_TYPE"='CGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS itc_cgst,
       COALESCE(SUM(CASE WHEN a."TRAN_TYPE"='P' AND a."TAX_SIGN"='-' AND a."R_CHARG"='N' AND a."TAX_TYPE"='SGST' THEN a."TAX_AMT" ELSE 0 END),0)::text AS itc_sgst
      FROM "TAX_DATA" a
     WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4
       AND a."VCH_DATE">=$5::date AND a."VCH_DATE"<=$6::date${optional}`,
    ...params,
  );
  const row = rows[0] ?? {};
  const amounts = (prefix: string) => ({
    taxable: row[`${prefix}_taxable`] ?? '0',
    igst: row[`${prefix}_igst`] ?? '0',
    cgst: row[`${prefix}_cgst`] ?? '0',
    sgst: row[`${prefix}_sgst`] ?? '0',
  });
  return {
    outward: amounts('outward'),
    reverseCharge: amounts('reverse'),
    otherItc: amounts('itc'),
  };
}
