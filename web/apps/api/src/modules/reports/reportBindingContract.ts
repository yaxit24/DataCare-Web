import type { RptSpec } from './reportEngine.js';
import { createHash } from 'node:crypto';

export type ReportRow = Record<string, string>;

/** A document line owns its component rows. Parent amounts must never be fanned out. */
export interface ParentChildBands {
  parentSections: string[];
  childSections: string[];
  parentFooterSections: string[];
  groups: { key: string; parent: ReportRow; children: ReportRow[] }[];
}

export interface ReportBindingContract {
  header: string;
  detail: string;
  child?: string;
  orderBy?: string;
  partyAliases?: string[];
  parentSections?: string[];
  childSections?: string[];
  parentFooterSections?: string[];
  orderDocument?: {
    family: 'SALES ORDER' | 'TOUR ORDER' | 'either';
    orderedItems: boolean;
    images?: boolean;
    specSha256: string;
  };
}

export class UnsupportedReportBindingError extends Error {
  readonly code = 'unsupported-report-binding';

  constructor(
    readonly report: string,
    readonly reason = 'unregistered-template',
  ) {
    super(
      `No supported report binding for ${report || 'this report'} (${reason}); refusing sales fallback`,
    );
  }
}

const childBill = (family: 'SL' | 'PR' | 'KR'): ReportBindingContract => ({
  header: `${family}_DATA`,
  detail: `${family}_DETL`,
  child: `${family}_IDTL`,
  orderBy: 'SR_NO',
  parentSections: ['Section9'],
  childSections: ['Section5'],
  parentFooterSections: ['Section10'],
});

/**
 * Explicit extracted-template contracts, not a substring search through arbitrary formulas.
 * SalesBillHz and the listed invoice variants have the same line/component group structure:
 * Section9 (DETL) -> Section5 (IDTL) -> Section10 (line footer), followed by voucher totals.
 * Evidence: apps/api/report-specs/<name>.spec.json; TR_SALE.cs:14670 and
 * TR_PURC.cs:12364,12479 read IDTL by the full voucher key and SR_NO/ISR_NO.
 * Registration establishes a dataset/band contract, not Crystal formula/visual certification.
 */
export const REPORT_BINDING_CONTRACTS: Readonly<Record<string, ReportBindingContract>> = {
  // Full main reports recovered from direct XML children; OrdRec remains an independent
  // received-metal subreport. TR_SALE_ORD.cs:9815–9818 / TR_TOUR_ORD.cs:7980–7996 select these.
  OrderVch: {
    header: 'SL_ORD_DATA',
    detail: 'SL_ORD_DATA',
    orderDocument: {
      family: 'either',
      orderedItems: false,
      specSha256: 'ae98795a6e5797bbf38b6bbc9100517a6bfc7cfd3a47174b604177aadc63a136',
    },
  },
  OrderBill: {
    header: 'SL_ORD_DATA',
    detail: 'SL_ORD_DETL',
    child: 'SL_ORD_IDTL',
    orderBy: 'SR_NO',
    parentSections: ['Section10'],
    childSections: ['Section5'],
    parentFooterSections: ['Section17', 'Section8'],
    orderDocument: {
      family: 'SALES ORDER',
      orderedItems: true,
      specSha256: '0273b928b4c08082b2df511184b2c7df057f00cf8876d751ba61f9557f19ed82',
    },
  },
  TourOrdVch: {
    header: 'SL_ORD_DATA',
    detail: 'SL_ORD_DETL',
    child: 'SL_ORD_IDTL',
    orderBy: 'SR_NO',
    parentSections: ['Section10'],
    childSections: ['Section5'],
    parentFooterSections: ['Section8'],
    orderDocument: {
      family: 'TOUR ORDER',
      orderedItems: true,
      specSha256: '92d5d2eda3826f907b87c98f25be872cc0de3c14d2964c509e5fc72716fc9477',
    },
  },
  OrdVchImg: {
    header: 'SL_ORD_DATA',
    detail: 'SL_ORD_DETL',
    child: 'SL_ORD_IDTL',
    orderBy: 'SR_NO',
    parentSections: ['Section10'],
    childSections: ['Section5'],
    parentFooterSections: ['Section17', 'Section8'],
    orderDocument: {
      family: 'SALES ORDER',
      orderedItems: true,
      images: true,
      specSha256: 'b81fce190197f67009a19630132ee3455e539bbcadcd5c9bc7008e1de700a16f',
    },
  },
  TourOrdImg: {
    header: 'SL_ORD_DATA',
    detail: 'SL_ORD_DETL',
    child: 'SL_ORD_IDTL',
    orderBy: 'SR_NO',
    parentSections: ['Section10'],
    childSections: ['Section5'],
    parentFooterSections: ['Section17', 'Section8'],
    orderDocument: {
      family: 'TOUR ORDER',
      orderedItems: true,
      images: true,
      specSha256: '25ac43d932d98c27d687a0ac3a4a75296d2fe91370a30ba7bd711bdf17dcd2f6',
    },
  },
  SalesBillHz: childBill('SL'),
  SalesBillHzGst: childBill('SL'),
  SalesBillA4: childBill('SL'),
  SalesBillA4Gst: childBill('SL'),
  B2BSaleBillA4Tax: childBill('SL'),
  SlBillWapp: childBill('SL'),
  SalesToPurcFixingVch: childBill('SL'),
  // SalesQuotation places child weight/rate in a parent footer; its required grouping semantics
  // are not in the extracted spec. Register only after that contract is independently resolved.
  PurcBillA4Gst: childBill('PR'),
  PurcBillHalfGst: childBill('PR'),
  B2BPurcBillA4Tax: childBill('PR'),
  PrRtnBillGst: childBill('PR'),
  PurcToSalesFixingVch: childBill('PR'),
  KrRecVchGst: childBill('KR'),
  PurcBillA4: { header: 'PR_DATA', detail: 'PR_DETL', orderBy: 'SR_NO' },
  PrRtnBill: { header: 'PR_DATA', detail: 'PR_DETL', orderBy: 'SR_NO' },
  KrIsuBill: { header: 'KR_DATA', detail: 'KR_DETL', orderBy: 'SR_NO' },
  KrIsuBillGst: { header: 'KR_DATA', detail: 'KR_DETL', orderBy: 'SR_NO' },
  KrRecVch: { header: 'KR_DATA', detail: 'KR_DETL', orderBy: 'SR_NO' },
  OldItmSaleVch: { header: 'KR_DATA', detail: 'KR_DETL', orderBy: 'SR_NO' },
  MtlIsu: { header: 'KR_DATA', detail: 'KR_DETL', orderBy: 'SR_NO' },
  CashBankBill: { header: 'CASH_DATA', detail: 'CASH_DATA', orderBy: 'SR_NO' },
  TagStkRpt: { header: 'TAG_STOCK_PRINT', detail: 'TAG_STOCK_PRINT', orderBy: 'SR_NO' },
  AcLedger: { header: 'AC_DATA', detail: 'AC_DATA', partyAliases: ['AC_MAST', 'AC_MAST_LEDR'] },
};

const databaseTables = (value: string): string[] =>
  [...value.matchAll(/\{([A-Za-z][A-Za-z0-9_]*)\.[A-Za-z0-9_]+\}/g)].map((m) => m[1]!);

export function resolveReportBinding(spec: RptSpec): ReportBindingContract {
  const contract = REPORT_BINDING_CONTRACTS[spec.report];
  const refuse = (reason: string): never => {
    throw new UnsupportedReportBindingError(spec.report, reason);
  };
  if (!contract) return refuse('unregistered-template');
  if (contract.orderDocument) {
    // The dedicated order renderer implements these recovered formulas, suppression conditions,
    // group totals and one linked subreport. A changed template must be reviewed as a new contract.
    if (
      createHash('sha256').update(JSON.stringify(spec)).digest('hex') !==
      contract.orderDocument.specSha256
    )
      return refuse('altered-order-report-spec');
    return contract;
  }
  const sections = spec.areas.flatMap((area) => area.sections);
  if (new Set(sections.map((section) => section.name)).size !== sections.length)
    return refuse('duplicate-section-name');
  const allowedTables = new Set([
    contract.header,
    contract.detail,
    contract.child,
    'CO_MAST',
    'LOCT_MAST',
    'BOOK_DATA',
    'AC_MAST',
    'ITEM_MAST',
    ...(contract.partyAliases ?? []),
    ...(contract.child ? ['ITEM_MAST_IDTL'] : []),
    ...(contract.header === 'TAG_STOCK_PRINT' ? ['PRODUCT_MAST', 'GROUP_MAST'] : []),
  ]);
  const referencedTables = new Set(
    databaseTables(JSON.stringify({ areas: spec.areas, formulas: spec.formulas })),
  );
  if (!referencedTables.has(contract.header)) return refuse('missing-required-header-reference');
  for (const table of referencedTables)
    if (!allowedTables.has(table)) return refuse(`unbound-table:${table}`);
  for (const section of sections) {
    for (const object of section.objects) {
      if (!['TextObject', 'FieldObject', 'LineObject', 'BoxObject'].includes(object.type))
        return refuse(`unsupported-object:${object.type}`);
    }
  }
  if (!contract.child) return contract;
  if (!referencedTables.has(contract.detail) || !referencedTables.has(contract.child))
    return refuse('missing-required-parent-child-reference');
  const parentSections = contract.parentSections!;
  const childSections = contract.childSections!;
  const footerSections = contract.parentFooterSections!;
  const groupNames = [...parentSections, ...childSections, ...footerSections];
  const start = sections.findIndex((section) => section.name === groupNames[0]);
  if (start < 0 || groupNames.some((name, index) => sections[start + index]?.name !== name))
    return refuse('unsupported-parent-child-section-order');
  for (const section of sections) {
    const expectedKind = parentSections.includes(section.name)
      ? 'GroupHeader'
      : childSections.includes(section.name)
        ? 'Detail'
        : footerSections.includes(section.name)
          ? 'GroupFooter'
          : undefined;
    if (expectedKind && section.kind !== expectedKind)
      return refuse('unexpected-parent-child-section-kind');
    // Extra detail bands cannot silently repeat parent rows or omit a component dataset.
    if (section.kind === 'Detail' && !childSections.includes(section.name))
      return refuse('unbound-detail-section');
    const formulas = new Map(spec.formulas.map((formula) => [formula.name, formula.text]));
    const refs = (source: string, seen = new Set<string>()): string[] => {
      const tables = databaseTables(source);
      for (const match of source.matchAll(/\{@([^}]+)\}/g)) {
        const name = match[1]!;
        if (!seen.has(name)) {
          seen.add(name);
          tables.push(...refs(formulas.get(name) ?? '', seen));
        }
      }
      return tables;
    };
    const sectionTables = section.objects.flatMap((object) => refs(object.dataSource ?? ''));
    if (
      !childSections.includes(section.name) &&
      sectionTables.some((table) => table === contract.child || table === 'ITEM_MAST_IDTL')
    )
      return refuse('child-reference-outside-child-band');
    if (childSections.includes(section.name) && sectionTables.includes(contract.detail))
      return refuse('parent-reference-in-child-band');
  }
  return contract;
}
