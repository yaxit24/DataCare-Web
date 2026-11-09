import { formatCell } from './engine.js';
import type { RpAllResult } from './index.js';
import type { XlsxColumn } from '../xlsx.js';

/**
 * Flatten an RP_ALL result for CSV/Excel: one line per printed row in report order, each group band that
 * prints a subtotal as its own line (label in the first column), and the grand total last. The export and
 * the screen are built from the same RpAllResult, so they cannot disagree; the export covers the whole
 * result, never a page of it.
 */
export interface ExportTable {
  columns: { key: string; caption: string; kind: string }[];
  lines: Record<string, string>[];
}

export function exportTable(result: RpAllResult): ExportTable {
  const columns = [
    { key: '_band', caption: 'Band', kind: 'text' },
    ...result.columns.map((c) => ({ key: c.key, caption: c.caption, kind: c.kind })),
  ];
  const lines: Record<string, string>[] = [];
  const subtotalOf = new Map(result.groupLevels.map((g, depth) => [depth, g]));
  const totalLine = (band: string, totals: Record<string, number>) => {
    const line: Record<string, string> = { _band: band };
    for (const c of result.columns)
      if (totals[c.key] !== undefined) line[c.key] = formatCell(c.kind, totals[c.key]!);
    return line;
  };
  let rowIndex = 0;
  const pathKey = (path: string[]) => path.join('\u0000');
  // Emit rows grouped under their bands: a band's line precedes ('header') or follows ('footer') its rows.
  const flushRowsFor = (key: string | null) => {
    while (
      rowIndex < result.rows.length &&
      (key === null || pathKey(result.rows[rowIndex]!.groupPath) === key)
    ) {
      const row = result.rows[rowIndex]!;
      const line: Record<string, string> = { _band: row.level };
      for (const c of result.columns) {
        if (c.level !== row.level) continue;
        line[c.key] = formatCell(c.kind, row.cells[c.key] ?? null);
      }
      lines.push(line);
      rowIndex += 1;
    }
  };
  const groups = result.groups;
  for (let i = 0; i < groups.length; i += 1) {
    const group = groups[i]!;
    const level = subtotalOf.get(group.depth)!;
    const isLeaf = group.depth === result.groupLevels.length - 1;
    const label = `${'  '.repeat(group.depth)}${group.label}`;
    if (level.subtotal === 'header') lines.push({ ...totalLine(label, group.totals) });
    else lines.push({ _band: label });
    if (isLeaf) {
      flushRowsFor(pathKey(group.groupPath));
      if (level.subtotal === 'footer')
        lines.push(totalLine(level.subtotalCaption ?? 'Total', group.totals));
    }
    // A footer of an outer level closes after its last inner group.
    const next = groups[i + 1];
    for (let depth = group.depth - 1; depth >= 0; depth -= 1) {
      const outer = subtotalOf.get(depth)!;
      const closes = !next || next.depth <= depth;
      if (closes && outer.subtotal === 'footer') {
        const outerGroup = [...groups.slice(0, i + 1)].reverse().find((g) => g.depth === depth)!;
        lines.push(totalLine(outer.subtotalCaption ?? 'Total', outerGroup.totals));
      }
    }
  }
  flushRowsFor(null);
  if (result.grandTotal) lines.push(totalLine(result.grandTotalCaption ?? 'Total', result.totals));
  return { columns, lines };
}

/** CSV text: header captions, then every line; values are already formatted text. */
export function exportCsv(result: RpAllResult): string {
  const table = exportTable(result);
  const cell = (v: string | undefined) => {
    const s = v ?? '';
    return /[",\n\r]/.test(s) || /^[=+\-@]/.test(s) ? `"${s.replace(/"/g, '""')}"` : s;
  };
  const out = [table.columns.map((c) => cell(c.caption)).join(',')];
  for (const line of table.lines) out.push(table.columns.map((c) => cell(line[c.key])).join(','));
  return `${out.join('\r\n')}\r\n`;
}

/** Excel columns: text cells for everything (values are pre-formatted to the desktop precision). */
export function exportXlsxColumns(result: RpAllResult): XlsxColumn[] {
  return exportTable(result).columns.map((c) => ({
    header: c.caption,
    key: c.key,
    type: 'text',
    width: c.kind === 'text' ? 24 : 14,
  }));
}
