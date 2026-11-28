/**
 * The sale a purchase is booked against: PR_DATA / PR_DETL SL_BILL_NO, SL_BILL_LC, SL_BILL_YRCD, SL_BILL_DBCD
 * (TR_PURC.cs:12647-12650, :12766-12769). Pure helpers shared by the purchase writer and linkedPurchase.ts, kept out of
 * purchase.ts (size ceiling) and free of its imports.
 */
export interface SaleLink {
  saleBillNo: string;
  saleBillLc: string;
  saleBillYear: string;
  saleBillBook: string;
}

const text = (value: unknown): string => String(value ?? '').trim();

/** The link as the writer stores it (purchaseLinkFromInput widths: 10 / 2 / 10 / 3). */
export function normalizeSaleLink(link: SaleLink): SaleLink {
  return {
    saleBillNo: text(link.saleBillNo).slice(0, 10),
    saleBillLc: text(link.saleBillLc).slice(0, 2),
    saleBillYear: text(link.saleBillYear).slice(0, 10),
    saleBillBook: text(link.saleBillBook).slice(0, 3),
  };
}

export function persistedSaleLink(header: Record<string, unknown>): SaleLink {
  return normalizeSaleLink({
    saleBillNo: text(header.SL_BILL_NO),
    saleBillLc: text(header.SL_BILL_LC),
    saleBillYear: text(header.SL_BILL_YRCD),
    saleBillBook: text(header.SL_BILL_DBCD),
  });
}

/** Exact match on all four columns; an empty sale number never matches. */
export function sameSaleLink(a: SaleLink, b: SaleLink | undefined): boolean {
  if (!b) return false;
  const x = normalizeSaleLink(a);
  const y = normalizeSaleLink(b);
  return (
    x.saleBillNo !== '' &&
    x.saleBillNo === y.saleBillNo &&
    x.saleBillLc === y.saleBillLc &&
    x.saleBillYear === y.saleBillYear &&
    x.saleBillBook === y.saleBillBook
  );
}

/**
 * The standalone refusal. The desktop refuses deleting a linked purchase ("Linkd With … Please Delete Then First",
 * TR_PURC.cs:13443-13447); the web also refuses editing it outside its sale, because the sale's Old Gold amount and
 * balance are derived from the purchase (owner decision 2B). The message names the sale to open.
 */
export function linkedPurchaseRefusal(header: Record<string, unknown>): string {
  const link = persistedSaleLink(header);
  return `Linked with sale ${link.saleBillBook || '?'}/${link.saleBillNo}; open that sale`;
}

/** The PR_DATA columns the refusal and the link check read. */
export const SALE_LINK_COLUMNS = [
  'SL_BILL_NO',
  'SL_BILL_LC',
  'SL_BILL_YRCD',
  'SL_BILL_DBCD',
] as const;

/**
 * `input` with its sale link replaced by `link`, or cleared when there is none. The public purchase routes cannot set
 * SL_BILL_* on a PURCHASE book: the linked-purchase lookup and the sale-delete cascade trust those columns.
 */
export function withSaleLink<T extends Partial<SaleLink>>(input: T, link: SaleLink | undefined): T {
  return {
    ...input,
    saleBillNo: link?.saleBillNo,
    saleBillLc: link?.saleBillLc,
    saleBillYear: link?.saleBillYear,
    saleBillBook: link?.saleBillBook,
  };
}
