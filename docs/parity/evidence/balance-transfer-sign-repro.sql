-- Reproduction for PA-01 (Balance TrFr / Year-End Close carry-forward). Throwaway Postgres only.
-- Run:  docker run -d --rm --name dc-gap-proof -e POSTGRES_PASSWORD=x -p 127.0.0.1:55790:5432 postgres:16-alpine
--       docker exec -i dc-gap-proof psql -U postgres -q < docs/parity/evidence/balance-transfer-sign-repro.sql
--       docker stop dc-gap-proof
--
-- What it does: builds the party and income rows in the DESKTOP convention (AC_DATA.SIGN '+' = credit, '-' = debit
-- for metal legs), runs the web's own year-end closing query (web/apps/api/src/modules/ops/yearEnd.ts:113-145,
-- copied verbatim in logic), builds the opening leg exactly as buildOpeningRow does (yearEnd.ts:185-208), and reads
-- that leg back with the web ledger's own signed formula (web/apps/api/src/modules/reports/accountLedgerShared.ts:252-253).
-- Then it shows what the desktop (BtmSchm.cs:2759-2800) would have carried for the same data.
-- It is a SQL-level reproduction on hand-built rows. It is not a run of the live application.

CREATE TABLE "AC_DATA"("CO_CODE" text,"CO_YEAR" text,"CO_BOOK" text,"VCH_TYPE" text,"AC_CODE" text,
  "DR_AMT" numeric,"CR_AMT" numeric,"SIGN" text,"FINE_WT" numeric,"IT_TYPE" text);

-- Party P1 (an AC_MAIN_GR < '3' party account): money Dr 100; gold Cr 10.000 and Dr 4.000 (net 6.000 Cr);
-- silver Cr 50.000.  Account SALES is an income account, not a party.
INSERT INTO "AC_DATA" VALUES
 ('01','2526','010','SALE','P1',0,0,'+',10,'G'),
 ('01','2526','010','SALE','P1',0,0,'-',4,'G'),
 ('01','2526','010','SALE','P1',0,0,'+',50,'S'),
 ('01','2526','010','SALE','P1',100,0,NULL,0,'A'),
 ('01','2526','010','SALE','SALES',0,100,NULL,0,'A');

\echo '=== 1. WEB closing query (computeClosingsTx): one row per account, one fine number, one IT_TYPE ==='
SELECT "AC_CODE" AS "acCode",
  coalesce(sum("DR_AMT"),0) AS dr, coalesce(sum("CR_AMT"),0) AS cr,
  coalesce(sum(CASE WHEN "SIGN"='C' THEN -"FINE_WT" ELSE "FINE_WT" END),0) AS web_fine,
  max(NULLIF("IT_TYPE",'')) FILTER (WHERE "IT_TYPE" IN ('G','S')) AS web_it_type
FROM "AC_DATA" WHERE "CO_CODE"='01' AND "CO_YEAR"='2526' AND coalesce("CO_BOOK",'')<>'999'
GROUP BY "AC_CODE" ORDER BY 1;

\echo '=== 2. Opening leg the web writes for P1 (buildOpeningRow): SIGN D, FINE_WT 64, IT_TYPE S ==='
INSERT INTO "AC_DATA"
SELECT '01','2627','000','ACOP',"AC_CODE",
  CASE WHEN sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0))>0 THEN sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)) ELSE 0 END,
  CASE WHEN sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0))<0 THEN -sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)) ELSE 0 END,
  CASE WHEN sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0))>0 THEN 'D' ELSE 'C' END,
  abs(sum(CASE WHEN "SIGN"='C' THEN -"FINE_WT" ELSE "FINE_WT" END)),
  max("IT_TYPE") FILTER (WHERE "IT_TYPE" IN ('G','S'))
FROM "AC_DATA" WHERE "CO_YEAR"='2526' GROUP BY "AC_CODE";
SELECT "AC_CODE","DR_AMT","CR_AMT","SIGN","FINE_WT","IT_TYPE" FROM "AC_DATA" WHERE "CO_YEAR"='2627' ORDER BY 1;

\echo '=== 3. What the web ledger reads back from that opening (SIGNED_GOLD / SIGNED_SILVER formulas) ==='
SELECT "AC_CODE",
  coalesce(sum(CASE WHEN "IT_TYPE"='G' THEN (CASE WHEN "SIGN"='+' THEN "FINE_WT" ELSE -"FINE_WT" END) ELSE 0 END),0) AS web_gold,
  coalesce(sum(CASE WHEN "IT_TYPE"='S' THEN (CASE WHEN "SIGN"='+' THEN "FINE_WT" ELSE -"FINE_WT" END) ELSE 0 END),0) AS web_silver
FROM "AC_DATA" WHERE "CO_YEAR"='2627' GROUP BY 1 ORDER BY 1;

\echo '=== 4. DESKTOP semantics for the same data (BtmSchm Rtl_AcOpbl): gold and silver separate, + = Cr, party accounts only ==='
SELECT "AC_CODE",
  sum(coalesce("CR_AMT",0)-coalesce("DR_AMT",0)) AS amount_cr_minus_dr,
  sum(CASE WHEN "IT_TYPE"='G' THEN CASE WHEN "SIGN"='+' THEN "FINE_WT" ELSE -"FINE_WT" END ELSE 0 END) AS gold,
  sum(CASE WHEN "IT_TYPE"='S' THEN CASE WHEN "SIGN"='+' THEN "FINE_WT" ELSE -"FINE_WT" END ELSE 0 END) AS silver
FROM "AC_DATA" WHERE "CO_YEAR"='2526' AND "AC_CODE"='P1' GROUP BY 1;
