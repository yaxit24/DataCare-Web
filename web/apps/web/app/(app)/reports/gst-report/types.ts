export type GstView = 'gstr1' | 'gstr2' | 'gstr3b';
export type GstSection =
  | ''
  | 'B2B'
  | 'B2CL'
  | 'B2CS'
  | 'CDNR'
  | 'CDNUR'
  | 'EXP'
  | 'AT'
  | 'ATADJ'
  | 'EXEMP'
  | 'HSN'
  | 'DOCS';

export interface GstColumn {
  key: string;
  header: string;
}

export interface GstReportResult {
  view: GstView;
  section: Exclude<GstSection, ''> | null;
  title: string;
  fileName: string;
  columns: GstColumn[];
  rows: Record<string, string>[];
  totals: Record<string, string>;
  metadata: {
    companyName?: string;
    fromDate?: string;
    toDate?: string;
    source: 'RP_GST';
    blockedSections?: string[];
    blockedRows?: string[];
    limitations?: string[];
  };
}

export interface GstFilters {
  section: GstSection;
  fromDate: string;
  toDate: string;
  bookCode: string;
  partyCode: string;
}
