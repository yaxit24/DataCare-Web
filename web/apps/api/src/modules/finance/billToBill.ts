import { withTenant } from '@datacare/db';
import { formatVoucherNo, nextVoucherNoTx } from '../vouchers/numbering.js';
import { postVoucherTx, assertBalanced, type LedgerLine } from '../posting/posting.js';

/**
 * BILL-TO-BILL settlement (desktop TR_BILL_TO). Applies receipts (REC_AMT) and write-offs / round-off
 * (KASAR_AMT, a.k.a. "kasar") against a party's SPECIFIC outstanding bills held in BILL_OS_DATA.
 *
 * GROUND TRUTH — verified against the live BILL_OS_DATA table (information_schema + sample reads):
 *   • key columns   : tenant_id, CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, AC_CODE  (all varchar)
 *   • direction     : INOUT_TYPE 'O' = receivable (sale) · 'I' = payable (purchase)
 *   • money columns : BILL_AMT, REC_AMT, KASAR_AMT are NUMERIC   [+ metal BILL_GOLD/REC_GOLD/KASAR_GOLD]
 *   • a bill's OPEN BALANCE = BILL_AMT - REC_AMT - KASAR_AMT
 *
 * The list/settle key here is (tenant_id, CO_CODE, CO_BOOK, VCH_NO, AC_CODE) — the desktop Bill_OS()
 * lists a party's open bills filtered by CO_CODE/AC_CODE (NOT by CO_YEAR: outstanding routinely spans
 * years — e.g. one party holding open bills in CO_YEAR '2023-2024' and '2024'), and a single location
 * makes (CO_BOOK, VCH_NO) unique per company. Each open bill is one BILL_OS_DATA row, so a settlement
 * increments that row's REC_AMT/KASAR_AMT in place.
 *
 * SCOPE NOTE: this module is intentionally focused on the BILL_OS_DATA outstanding update. The desktop
 * TR_BILL_TO ALSO posts an AC_DATA receipt leg (Ac_Ledr.Bill_to_Bill_Ledr) and links the settling
 * voucher to the original bills via BILL_OS_DATA.OLD_VCH_NO / NEW_VCH_NO. That ledger posting +
 * OLD/NEW_VCH_NO linkage is a follow-up (handled by the receipt-posting path — postReceipt /
 * postBatchReceipt in finance.ts / batchReceipt.ts) and is deliberately out of scope here so the
 * outstanding update stays a single, focused, parameterised step.
 */

/** Read/write scope for bill-to-bill. tenantId + coCode are required; coYear/lcCode/coBook are accepted
 *  for API symmetry but are NOT used to filter outstanding bills (outstanding spans years/locations).
 *  Structurally compatible with the route adapter's readScope()/scopeOf() outputs. */
export interface BillScope {
  tenantId: string;
  coCode: string;
  coYear?: string;
  lcCode?: string;
  coBook?: string;
}

/** One outstanding bill of a party: its book + voucher identity, money figures, and derived open
 *  balance (openBal = billAmt - recAmt - kasarAmt). */
export interface BillOpen {
  coBook: string;
  vchNo: string;
  billAmt: number;
  recAmt: number;
  kasarAmt: number;
  openBal: number;
}

/** One settlement line: which bill (coBook + vchNo) and how much to receive / write off against it. */
export interface BillAllocation {
  coBook: string;
  vchNo: string;
  recAmt?: number;
  kasarAmt?: number;
}

export interface BillSettleInput {
  scope: BillScope;
  acCode: string;
  allocations: BillAllocation[];
  // Tender for the posted receipt (desktop posts a real Cash/Bank receipt against the allocated bills).
  mode?: 'cash' | 'bank';
  bankAc?: string;
  cashAc?: string;
  kasarAc?: string;
  partyName?: string;
  vchDate?: Date | string;
  // Mixed tender (desktop top tender grid): split the receipt across multiple cash/bank legs. When
  // present, Σ tender amounts must equal the total received (Σ allocation recAmt). Falls back to `mode`.
  tenders?: {
    mode: 'cash' | 'bank' | 'card' | 'upi' | 'cheque';
    amount: number;
    bankAc?: string;
    chqNo?: string;
  }[];
}

export interface BillSettleResult {
  settled: number; // bills actually updated (non-zero allocations)
  totalRec: number; // Σ REC_AMT applied
  totalKasar: number; // Σ KASAR_AMT applied
  vchNo: number; // the posted receipt voucher (0 if nothing applied)
}

/** Name ends in 'ValidationError' so the route adapter (run()) maps it to HTTP 400. */
export class BillToBillValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'BillToBillValidationError';
  }
}

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
/** Below this (₹0.005) an amount is treated as zero — the open-balance / overpay tolerance. */
const EPS = 0.005;

/** SQL: a bill's open balance, reading each numeric money column defensively (''/NULL ⇒ 0). The
 *  columns ARE numeric in the live schema; the ::text → NULLIF('') → ::numeric guard keeps the
 *  expression correct even for a null/blank value. */
const OPEN_BAL_SQL = `(COALESCE(NULLIF("BILL_AMT"::text,'')::numeric,0)
  - COALESCE(NULLIF("REC_AMT"::text,'')::numeric,0)
  - COALESCE(NULLIF("KASAR_AMT"::text,'')::numeric,0))`;

/**
 * List a party's OPEN bills (open balance > 0.005), READ-ONLY. Mirrors desktop Bill_OS(): scoped to
 * tenant + company + party, ordered by book then voucher, NOT filtered by year. Returns one row per
 * outstanding BILL_OS_DATA bill. Numeric outputs are cast to float8 so they serialise as plain JSON
 * numbers.
 */
export async function listOpenBills(
  prisma: any,
  scope: BillScope,
  acCode: string,
): Promise<BillOpen[]> {
  const party = String(acCode ?? '').trim();
  if (!party) throw new BillToBillValidationError('party account (acCode) is required');
  const tenantId = scope.tenantId;
  return withTenant(prisma, tenantId, async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "CO_BOOK" AS "coBook", "VCH_NO" AS "vchNo",
              COALESCE(NULLIF("BILL_AMT"::text,'')::numeric,0)::float8   AS "billAmt",
              COALESCE(NULLIF("REC_AMT"::text,'')::numeric,0)::float8    AS "recAmt",
              COALESCE(NULLIF("KASAR_AMT"::text,'')::numeric,0)::float8  AS "kasarAmt",
              ${OPEN_BAL_SQL}::float8 AS "openBal"
         FROM "BILL_OS_DATA"
        WHERE tenant_id = $1 AND "CO_CODE" = $2 AND "AC_CODE" = $3
          AND ${OPEN_BAL_SQL} > ${EPS}
        ORDER BY "CO_BOOK", "VCH_NO"`,
      tenantId,
      String(scope.coCode ?? ''),
      party,
    );
    return rows.map((r) => ({
      coBook: String(r.coBook ?? ''),
      vchNo: String(r.vchNo ?? ''),
      billAmt: round2(num(r.billAmt)),
      recAmt: round2(num(r.recAmt)),
      kasarAmt: round2(num(r.kasarAmt)),
      openBal: round2(num(r.openBal)),
    }));
  });
}

/**
 * Settle a party's specific bills. For each allocation, add its REC_AMT and KASAR_AMT onto the
 * matching BILL_OS_DATA bill (keyed by tenant_id, CO_CODE, CO_BOOK, VCH_NO, AC_CODE), refusing to
 * OVERPAY — the receive + kasar applied to a bill must not exceed that bill's CURRENT open balance
 * (within the ₹0.005 tolerance). Validation, the open-balance check and every UPDATE run inside ONE
 * tenant transaction, so a single bad / overpaying line rolls the whole settlement back. All SQL is
 * parameterised ($executeRawUnsafe / $queryRawUnsafe — no string interpolation of values).
 *
 * Zero-amount lines (rec + kasar ≈ 0) are skipped as no-ops and not counted in `settled`. Because the
 * checks run sequentially in the transaction, two allocations against the same bill correctly see the
 * balance already reduced by the earlier line.
 */
export async function settleBills(prisma: any, input: BillSettleInput): Promise<BillSettleResult> {
  const acCode = String(input?.acCode ?? '').trim();
  if (!acCode) throw new BillToBillValidationError('party account (acCode) is required');
  const allocations = input?.allocations ?? [];
  if (!Array.isArray(allocations) || allocations.length === 0) {
    throw new BillToBillValidationError('at least one bill allocation is required');
  }

  const scope = input.scope;
  const tenantId = scope.tenantId;
  const coCode = String(scope.coCode ?? '');

  return withTenant(prisma, tenantId, async (tx: any) => {
    let settled = 0;
    let totalRec = 0;
    let totalKasar = 0;
    // Allocate the receipt voucher up-front (so each settled bill carries the NEW_VCH_NO link) when money applies.
    const willApply = allocations.some((a) => round2(num(a?.recAmt) + num(a?.kasarAmt)) > EPS);
    const mode: 'cash' | 'bank' = input.mode === 'bank' ? 'bank' : 'cash';
    const book = scope.coBook ?? 'RCT';
    const no = willApply
      ? await nextVoucherNoTx(tx, {
          tenantId,
          coCode,
          lcCode: scope.lcCode ?? '01',
          coYear: scope.coYear,
          coBook: book,
        } as any)
      : 0;
    const key = {
      CO_CODE: coCode,
      LC_CODE: scope.lcCode ?? '01',
      CO_YEAR: scope.coYear ?? '',
      CO_BOOK: book,
      VCH_NO: no > 0 ? formatVoucherNo(no) : '',
    };

    for (const a of allocations) {
      const coBook = String(a?.coBook ?? '').trim();
      const rawVchNo = String(a?.vchNo ?? '').trim();
      if (!coBook || !rawVchNo)
        throw new BillToBillValidationError('each allocation needs coBook and vchNo');
      const vchNo = formatVoucherNo(rawVchNo);

      const rec = round2(num(a?.recAmt));
      const kasar = round2(num(a?.kasarAmt));
      if (rec < 0 || kasar < 0) {
        throw new BillToBillValidationError(
          `amounts cannot be negative for bill ${coBook}/${vchNo}`,
        );
      }
      const applied = round2(rec + kasar);
      if (applied <= EPS) continue; // nothing to apply on this line — skip (no-op)

      // Current open balance of THIS bill (same defensive numeric read as listOpenBills).
      const cur: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT ${OPEN_BAL_SQL}::float8 AS "openBal"
           FROM "BILL_OS_DATA"
          WHERE tenant_id = $1 AND "CO_CODE" = $2 AND "CO_BOOK" = $3 AND "VCH_NO" = $4 AND "AC_CODE" = $5`,
        tenantId,
        coCode,
        coBook,
        vchNo,
        acCode,
      );
      if (!cur.length) {
        throw new BillToBillValidationError(
          `bill ${coBook}/${vchNo} not found for party ${acCode}`,
        );
      }
      const openBal = round2(num(cur[0]!.openBal));
      if (applied > openBal + EPS) {
        throw new BillToBillValidationError(
          `overpay on bill ${coBook}/${vchNo}: receive+kasar ${applied} exceeds open balance ${openBal}`,
        );
      }

      // Apply the receipt + kasar to this bill's outstanding. Columns are numeric; the cast guard
      // keeps the increment safe for any null/blank stored value. Values are bound parameters.
      await tx.$executeRawUnsafe(
        `UPDATE "BILL_OS_DATA"
            SET "REC_AMT"   = (COALESCE(NULLIF("REC_AMT"::text,'')::numeric,0)   + $6::numeric),
                "KASAR_AMT" = (COALESCE(NULLIF("KASAR_AMT"::text,'')::numeric,0) + $7::numeric),
                "NEW_VCH_NO" = $8
          WHERE tenant_id = $1 AND "CO_CODE" = $2 AND "CO_BOOK" = $3 AND "VCH_NO" = $4 AND "AC_CODE" = $5`,
        tenantId,
        coCode,
        coBook,
        vchNo,
        acCode,
        rec,
        kasar,
        formatVoucherNo(no),
      );

      settled += 1;
      totalRec = round2(totalRec + rec);
      totalKasar = round2(totalKasar + kasar);
    }

    // Post the REAL receipt (desktop Bill_to_Bill_Ledr): Dr cash/bank (Σrec) + Dr kasar (Σkasar) / Cr party.
    if (willApply && round2(totalRec + totalKasar) > EPS) {
      const cashAc = mode === 'bank' ? (input.bankAc ?? 'BANK') : (input.cashAc ?? 'CASH');
      const kasarAc = input.kasarAc ?? 'KASAR';
      const vchType = mode === 'bank' ? 'BREC' : 'CREC';
      const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
      const base = { ...key, VCH_TYPE: vchType };
      const ledger: LedgerLine[] = [];
      // Mixed tender: Dr one leg per tender (Σ must equal totalRec). Otherwise a single leg for totalRec.
      const tenders = (input.tenders ?? []).filter((t) => round2(num(t.amount)) > EPS);
      let tenderSum = 0;
      if (tenders.length) {
        for (const t of tenders) {
          const amt = round2(num(t.amount));
          const ac =
            t.mode === 'cash' ? (input.cashAc ?? 'CASH') : (t.bankAc ?? input.bankAc ?? 'BANK');
          ledger.push({ ...base, AC_CODE: ac, DR_AMT: amt, CR_AMT: 0, SIGN: 'D' });
          tenderSum = round2(tenderSum + amt);
        }
        if (Math.abs(tenderSum - totalRec) > EPS)
          throw new BillToBillValidationError(
            `tender total ${tenderSum} must equal received total ${totalRec}`,
          );
      } else {
        ledger.push({ ...base, AC_CODE: cashAc, DR_AMT: totalRec, CR_AMT: 0, SIGN: 'D' });
      }
      if (totalKasar > EPS)
        ledger.push({ ...base, AC_CODE: kasarAc, DR_AMT: totalKasar, CR_AMT: 0, SIGN: 'D' });
      ledger.push({
        ...base,
        AC_CODE: acCode,
        DR_AMT: 0,
        CR_AMT: round2(totalRec + totalKasar),
        SIGN: 'C',
      });
      assertBalanced(ledger);
      await postVoucherTx(tx, tenantId, {
        ledger: { table: 'AC_DATA', lines: ledger },
        bookName: mode === 'bank' ? 'BANK REC' : 'CASH REC',
        writes: [
          {
            table: 'CASH_DATA',
            rows: [
              {
                ...key,
                SR_NO: 1,
                VCH_TYPE: vchType,
                INOUT_TYPE: 'I',
                ENTRY_TYPE: mode === 'bank' ? 'B' : 'C',
                BOOK_NAME: mode === 'bank' ? 'BANK REC' : 'CASH REC',
                VCH_DATE: vchDate,
                AC_CODE: acCode,
                AC_NAME: input.partyName ?? null,
                REC_AMT: totalRec,
                KASAR_AMT: totalKasar,
                REC_AC_CODE: cashAc,
                BANK_NAME: mode === 'bank' ? cashAc : null,
              },
            ],
          },
        ],
      });
    }
    return { settled, totalRec, totalKasar, vchNo: willApply ? Number(no) : 0 };
  });
}

export interface DeleteBillSettlementInput {
  scope: BillScope & { coYear?: string; coBook?: string };
  vchNo: number | string;
  /** CO_BOOK the settlement was posted under; defaults to the scope's book. */
  book?: string;
  deleteUser?: string;
}

/**
 * Reverse a bill-to-bill settlement — plan item F1.4.
 *
 * WHY THIS WAS BLOCKED, AND WHY IT NO LONGER IS
 * =============================================
 * This was recorded as decision D-4 on the grounds that a settlement could not be reversed: `settleBills`
 * INCREMENTS each targeted bill's `REC_AMT`/`KASAR_AMT` in place and records no per-bill allocation, so
 * subtracting the right amount back is impossible once two vouchers have touched the same bill.
 *
 * Measuring the desktop dissolved the problem rather than solving it. **`UPDATE BILL_OS_DATA` appears ZERO
 * times in `TR_BILL_TO.cs`'s delete path.** The desktop deletes rows keyed to the SETTLING voucher's own
 * `VCH_NO` (`TR_BILL_TO.cs:4746`) alongside `CASH_DATA`, `AC_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`,
 * `REMARK_DATA` and `SL_PR_DETL`, and writes a `DELETE_DATA` audit row — and it leaves the increments it
 * applied to the original bills exactly where they are.
 *
 * The models agree, which is what made the blocker dissolve: `BILL_OS_DATA` rows belong to the voucher that
 * CREATED the outstanding, not to the settlement. Measured on the real database, 363 of 365 rows sit on sales
 * books, 1 on labour work, and just 1 on book 210 `BILL REC` — the bill-to-bill book itself, for the case
 * where a settlement leaves its own balance. `REC_AMT` is non-zero on 222 of 365 and `KASAR_AMT` on 121, so
 * in-place accumulation is the desktop's convention too.
 *
 * ## A CONSEQUENCE WORTH STATING PLAINLY
 * Deleting a settlement does NOT restore the bills it paid: they stay showing as partly paid. That is the
 * desktop's behaviour, and it is arguably a defect in the desktop. It is replicated deliberately, because the
 * point of this migration is that the web agrees with the system the business is reconciling against —
 * inventing a more correct reversal here would make the web's outstanding balances differ from the desktop's,
 * which is worse than sharing its flaw. If the owner wants the increments restored, that is a change to BOTH
 * systems and needs the per-bill allocation persisted first (option (b) of D-4).
 */
export async function deleteBillSettlement(
  prisma: any,
  input: DeleteBillSettlementInput,
): Promise<{ reversed: true; billOsRowsRemoved: number }> {
  const { scope } = input;
  const voucherNo = formatVoucherNo(input.vchNo);
  const book = String(input.book ?? scope.coBook ?? '').trim();
  if (!book) throw new BillToBillValidationError('the settlement book is required to reverse it');
  const coYear = String(scope.coYear ?? '').trim();
  const lcCode = scope.lcCode ?? '01';

  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const header: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME",COALESCE("REC_AMT",0)::float8 AS rec,
              COALESCE("KASAR_AMT",0)::float8 AS kasar,"HD_VCH_NO","MAIN_USER","VCH_DATE","VCH_TYPE"
         FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      lcCode,
      coYear,
      book,
      voucherNo,
    );
    // Throw rather than report success on nothing, as every sibling reversal does.
    if (!header.length) {
      throw new BillToBillValidationError(`bill-to-bill voucher not found: ${voucherNo}`);
    }
    const h = header[0]!;

    // The desktop's DELETE_DATA insert (TR_BILL_TO.cs:5027) classifies by the book's BOOK_SNAME and uses
    // FINE_TYPE 'A' for a cash voucher, with the receipt amount on the side matching INOUT_TYPE.
    const bookRow: Array<{ sname: string | null; name: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "BOOK_SNAME" AS sname,"BOOK_NAME" AS name FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
      scope.tenantId,
      scope.coCode,
      lcCode,
      book,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "DELETE_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
          "VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","AC_NAME","VCH_VAL_DR","VCH_VAL_CR",
          "FINE_TYPE","VCH_FINE_DR","VCH_FINE_CR","HD_VCH_NO","MAIN_USER","DELETE_USER")
       VALUES ($1,$2,$3,$4,$5,$6,1,$7,$8,$9,$10,$11,0,$12,'A',0,0,$13,$14,$15)`,
      scope.tenantId,
      scope.coCode,
      lcCode,
      coYear,
      book,
      voucherNo,
      h.VCH_DATE ?? null,
      String(bookRow[0]?.sname ?? h.VCH_TYPE ?? '').trim(),
      String(bookRow[0]?.name ?? '').trim(),
      String(h.AC_CODE ?? '').trim(),
      String(h.AC_NAME ?? '').trim(),
      Number(h.rec ?? 0),
      String(h.HD_VCH_NO ?? '').trim(),
      String(h.MAIN_USER ?? '').trim(),
      input.deleteUser ?? 'system',
    );

    /**
     * Remove the voucher's OWN rows, table by table, exactly as the desktop's delete does. `BILL_OS_DATA` is
     * matched on this voucher's VCH_NO — a settlement that left its own balance owns a row here (real book
     * 210 has one). Other bills' REC_AMT is deliberately untouched; see the note above.
     */
    let billOsRowsRemoved = 0;
    for (const table of ['BILL_OS_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'REMARK_DATA', 'CASH_DATA']) {
      const removed = await tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
        scope.tenantId,
        scope.coCode,
        lcCode,
        coYear,
        book,
        voucherNo,
      );
      if (table === 'BILL_OS_DATA') billOsRowsRemoved = Number(removed ?? 0);
    }
    // TEMP_BOOK_DATA is keyed by the HIDDEN voucher number and carries no CO_YEAR.
    const hidden = String(h.HD_VCH_NO ?? '').trim();
    if (hidden) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
        scope.tenantId,
        scope.coCode,
        lcCode,
        book,
        hidden,
      );
    }
    return { reversed: true, billOsRowsRemoved };
  });
}
