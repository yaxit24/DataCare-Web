/**
 * Report CSV: writing the web's rows, and reading a Crystal export back.
 *
 * WHY CSV MATTERS FOR PARITY
 * --------------------------
 * Crystal Reports exports to CSV, and so can the web. Comparing those two files compares the DATA a report
 * produced — the rows and the totals — which is the part a business depends on. It is not a comparison of
 * layout, and this project does not claim Crystal pixel parity anywhere: the 254 layout baselines only detect
 * regressions in the web's own renderer.
 *
 * Data parity is the stronger claim of the two anyway. A report whose columns line up perfectly but whose
 * closing balance is wrong is worse than one that looks different and adds up.
 *
 * WHY A CRYSTAL EXPORT NEEDS ITS OWN READER
 * -----------------------------------------
 * A Crystal CSV is not a clean table. It carries the artefacts of a paginated, grouped report:
 *
 *  * a title block and column headers, sometimes repeated on every page;
 *  * group header and group footer rows, which restate a subtotal rather than adding a record;
 *  * blank separator lines;
 *  * a grand-total row, which must be read as a TOTAL and not counted as data;
 *  * a UTF-8 BOM, because it was written on Windows.
 *
 * Treating any of those as data rows would make the row counts disagree for reasons that have nothing to do
 * with the business logic, and would send someone hunting a defect that does not exist.
 */

const BOM = '\uFEFF';

/** Quote a value for CSV output, doubling embedded quotes. */
export function csvCell(value: unknown): string {
  if (value === null || value === undefined) return '';
  const text =
    typeof value === 'number' || typeof value === 'boolean' ? String(value) : String(value);
  // A leading '=', '+', '-' or '@' is how a CSV becomes a formula when opened in a spreadsheet. Values are
  // therefore never emitted bare when they begin with one.
  const risky = /^[=+\-@\t\r]/.test(text);
  const needsQuote = risky || /[",\n\r]/.test(text);
  const escaped = text.replace(/"/g, '""');
  return needsQuote ? `"${risky ? `'${escaped}` : escaped}"` : escaped;
}

/**
 * Render rows as CSV.
 *
 * Column order comes from the first row's keys unless given explicitly, so the output is deterministic rather
 * than dependent on object iteration order across engines.
 */
export function toCsv(
  rows: readonly Record<string, unknown>[],
  options: { columns?: readonly string[]; totals?: Record<string, unknown> } = {},
): string {
  const columns =
    options.columns ?? (rows.length ? Object.keys(rows[0]!) : Object.keys(options.totals ?? {}));
  const lines: string[] = [columns.join(',')];
  for (const row of rows) lines.push(columns.map((c) => csvCell(row[c])).join(','));
  if (options.totals) {
    // A totals line is marked so a reader can tell it from a record. Crystal does the same with its grand
    // total, and conflating the two inflates every row count by one.
    lines.push(columns.map((c, i) => (i === 0 ? 'TOTAL' : csvCell(options.totals![c]))).join(','));
  }
  return `${lines.join('\n')}\n`;
}

/** One parsed CSV line, already split into fields. */
function splitLine(line: string): string[] {
  const out: string[] = [];
  let field = '';
  let quoted = false;
  for (let i = 0; i < line.length; i += 1) {
    const ch = line[i]!;
    if (quoted) {
      if (ch === '"') {
        if (line[i + 1] === '"') {
          field += '"';
          i += 1;
        } else quoted = false;
      } else field += ch;
    } else if (ch === '"') quoted = true;
    else if (ch === ',') {
      out.push(field);
      field = '';
    } else field += ch;
  }
  out.push(field);
  return out;
}

export interface ParsedReportCsv {
  /** Header names as the file declares them. */
  columns: string[];
  /** Data rows only: group and total lines are excluded. */
  rows: Record<string, string>[];
  /** The grand-total line, if the file has one. */
  totals?: Record<string, string>;
  /** What the reader discarded and why, so the comparison can publish its own denominator. */
  skipped: { blank: number; repeatedHeader: number; groupOrSubtotal: number; total: number };
}

/**
 * Parse a report CSV from either side.
 *
 * `headerHint` lets a caller name the header row when a Crystal export puts a title block above it. Without a
 * hint the first line containing more than one non-empty field is taken as the header, which is right for a
 * plain export and wrong for a titled one — hence the hint rather than a guess.
 */
export function parseReportCsv(
  text: string,
  options: { headerHint?: string; totalMarkers?: readonly string[] } = {},
): ParsedReportCsv {
  const markers = (options.totalMarkers ?? ['TOTAL', 'GRAND TOTAL', 'Total']).map((m) =>
    m.toUpperCase(),
  );
  const raw = text.replace(/^\uFEFF/, '').split(/\r\n|\n|\r/);
  const skipped = { blank: 0, repeatedHeader: 0, groupOrSubtotal: 0, total: 0 };

  let headerAt = -1;
  if (options.headerHint) {
    headerAt = raw.findIndex((l) => l.includes(options.headerHint!));
  }
  if (headerAt < 0) {
    headerAt = raw.findIndex((l) => splitLine(l).filter((f) => f.trim() !== '').length > 1);
  }
  if (headerAt < 0) return { columns: [], rows: [], skipped };

  const columns = splitLine(raw[headerAt]!).map((c) => c.trim());
  const headerKey = columns.join('|');
  const rows: Record<string, string>[] = [];
  let totals: Record<string, string> | undefined;

  for (let i = headerAt + 1; i < raw.length; i += 1) {
    const line = raw[i]!;
    const fields = splitLine(line);
    const nonEmpty = fields.filter((f) => f.trim() !== '');
    if (!nonEmpty.length) {
      skipped.blank += 1;
      continue;
    }
    if (fields.map((c) => c.trim()).join('|') === headerKey) {
      // Crystal repeats the column header on each page.
      skipped.repeatedHeader += 1;
      continue;
    }
    const first = (fields[0] ?? '').trim().toUpperCase();
    if (markers.some((m) => first === m || first.startsWith(`${m} `))) {
      totals = Object.fromEntries(columns.map((c, k) => [c, (fields[k] ?? '').trim()]));
      skipped.total += 1;
      continue;
    }
    // A line with a single populated field is a group header or a subtotal caption, not a record.
    if (nonEmpty.length === 1 && fields.length > 1) {
      skipped.groupOrSubtotal += 1;
      continue;
    }
    rows.push(Object.fromEntries(columns.map((c, k) => [c, (fields[k] ?? '').trim()])));
  }
  return { columns, rows, totals, skipped };
}
