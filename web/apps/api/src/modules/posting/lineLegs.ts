import { PRECISION, round } from '@datacare/core';

/**
 * Item legs of a sale or purchase, and how each one is keyed (G169, G176).
 *
 * The desktop posts the item side of a bill on one of two paths, chosen by the book's `BOOK_DATA.ITM_TYPE`:
 *
 * - header path (`ITM_TYPE <> 'A'`): one leg to the book's slot-1 account for the bill net (sale
 *   `Ac_Ledr.cs:92`, purchase `Ac_Ledr.cs:414-421`);
 * - line path (`ITM_TYPE = 'A'`): one leg PER DETAIL LINE to that line's group account for the line's `NET_AMT`,
 *   keyed `VCH_NO + STR(A.SR_NO) + <code>` so two lines never share a key (sale `GROUP_MAST.SALE_AC`,
 *   `Ac_Ledr.cs:90`; purchase `GROUP_MAST.PURC_AC`, `Ac_Ledr.cs:410`).
 *
 * The web posts to per-group accounts but keyed every item leg with the family's single role code (sale 03,
 * purchase 03) and no line number. A bill whose lines map to one account is right that way, and it is what the
 * measured real data shows (sale book 027 voucher 00001: two lines, one 23-character `…03` leg). A bill whose lines
 * map to two accounts, gold and silver, wrote two legs with the same `LEDR_KEY`, and the save failed on AC_DATA's
 * unique key: feature cases `sales-invoice.create.two-lines-dissimilar` and `purchase-invoice.create.two-groups`.
 *
 * Posting to more than one account is the line path's behaviour, so a multi-account bill takes the line path's
 * layout: one leg per detail line, the line number in `STR()` form (right-aligned in 10) ahead of the role code.
 * The role code stays the family's MEASURED code. The decompiled source's codes (sale `07`, purchase `08`) belong
 * to a code map that disagrees with the measured one on every role (sale tax is `09` there and `04` in the data),
 * so one code is not borrowed from it. This layout is inferred, not measured: the captured customer data holds no
 * bill that posts to two item accounts.
 */

/** An item leg: `srNo` is present only when the bill posts to more than one account. */
export interface LineLeg {
  ac: string;
  amount: number;
  /** The detail line's SR_NO; present only on the per-line layout. */
  srNo?: number;
}

/**
 * The item legs of one bill.
 *
 * `lines` are the bill's detail lines in detail-table order, so line `i` is `SR_NO = i + 1` (both writers number
 * their detail rows `idx + 1`). Each carries its line amount and the account its item's group resolves to.
 *
 * - One distinct account: one leg for the whole `total`, exactly as before.
 * - Two or more: one leg per line. `total` is shared out in proportion to each line's amount, and the last line with
 *   a non-zero amount takes the rounding remainder, so the legs sum to `total` exactly. With no bill discount `total`
 *   equals the sum of the line amounts and every leg is its own line's amount, which is what the desktop line path
 *   posts (`A.NET_AMT`).
 */
export function buildLineLegs(
  lines: ReadonlyArray<{ net: number; ac: string }>,
  total: number,
  lineTotal: number,
): LineLeg[] {
  const dp = PRECISION.amount;
  const accounts = [...new Set(lines.map((line) => line.ac))];
  if (accounts.length === 0) return [];
  if (accounts.length === 1) return [{ ac: accounts[0] as string, amount: round(total, dp) }];

  const lastFunded = lines.reduce((last, line, i) => (line.net !== 0 ? i : last), -1);
  const legs: LineLeg[] = [];
  let allocated = 0;
  lines.forEach((line, i) => {
    let amount = 0;
    if (i === lastFunded) amount = round(total - allocated, dp);
    else if (line.net !== 0 && lineTotal !== 0) amount = round((total * line.net) / lineTotal, dp);
    allocated = round(allocated + amount, dp);
    legs.push({ ac: line.ac, amount, srNo: i + 1 });
  });
  return legs;
}

/** SQL Server `STR(n)`: the number right-aligned in a field of 10, as the desktop writes line keys. */
export function sqlStr(value: number): string {
  return String(value).padStart(10, ' ');
}

/**
 * The key directive for an item leg: the measured 23-character form (`legType`) for a single-account bill, or the
 * per-line tail `STR(SR_NO) + code` (`legKeySuffix`, 33 characters in all on a three-digit book) when the bill posts
 * to several accounts. `postVoucherTx` reads both directives and never writes them as columns.
 */
export function lineLegKey(
  leg: Pick<LineLeg, 'srNo'>,
  code: number,
): { legType: number } | { legKeySuffix: string } {
  return leg.srNo == null
    ? { legType: code }
    : { legKeySuffix: `${sqlStr(leg.srNo)}${String(code).padStart(2, '0')}` };
}
