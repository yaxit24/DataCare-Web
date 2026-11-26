/**
 * The replay oracle's human report (REPORT.md in ORACLE_OUT_DIR). Values in it are codes and numbers; personal and
 * free-text values are already masked by lib.mjs maskValue before they reach this file.
 */
import { writeFileSync } from 'node:fs';

const cell = (v) => String(v ?? '').replace(/\|/g, '\\|');

export function renderReport(s) {
  const L = [];
  L.push('# Desktop replay oracle report', '');
  L.push(
    `Desktop ${s.desktop.database} (${String(s.desktop.appVersion ?? '').slice(0, 60)}), company ${s.scope.coCode}, ` +
      `location ${s.scope.lcCode}, year ${s.scope.coYear}. Run ${s.startedAt} to ${s.finishedAt}. ` +
      `Arguments: ${JSON.stringify(s.args)}.`,
    '',
  );
  L.push(
    `Context load: ${s.load.rows} desktop row(s) copied into the replay tenant, ${s.load.refused} refused by the web schema.` +
      (s.load.reopenedBooks?.length
        ? ` Books retired after the year (CUR_USE 'N') reopened for the replay: ${s.load.reopenedBooks.join(', ')}.`
        : ''),
    '',
  );
  L.push('## Per book family', '');
  L.push('| Family | Vouchers | Replayed | Matched exactly | Differed | Could not replay |');
  L.push('|---|---:|---:|---:|---:|---:|');
  for (const [fam, t] of Object.entries(s.tallies))
    L.push(
      `| ${fam} | ${t.vouchers} | ${t.replayed} | ${t.matched} | ${t.differed} | ${t.couldNotReplay} |`,
    );
  L.push('');
  const tt = s.totals;
  L.push(
    `Compared ${tt.fieldsCompared} field(s) across ${tt.cases} replayed voucher(s); ${tt.fieldDifferences} value ` +
      `difference(s), ${tt.rowsMissing} desktop row(s) the web did not write, ${tt.rowsExtra} extra web row(s), ` +
      `${tt.tablesDesktopOnly} table write(s) missing on the web.`,
    '',
  );
  L.push('## Could not replay (grouped by reason)', '');
  if (!s.refusals.length) L.push('None.', '');
  else {
    L.push('| Family / status / reason | Vouchers |', '|---|---:|');
    for (const [k, n] of s.refusals) L.push(`| ${cell(k)} | ${n} |`);
    L.push('');
  }
  if (s.numberingDifferent.length)
    L.push(
      `Web voucher number differed from the desktop on ${s.numberingDifferent.length} voucher(s): ` +
        `${s.numberingDifferent.slice(0, 20).join(', ')}${s.numberingDifferent.length > 20 ? ', …' : ''}`,
      '',
    );
  if (s.numberingCollisions?.length) {
    L.push(
      '## Web numbering collisions (the web reused a voucher number; the replay then placed it explicitly)',
      '',
    );
    L.push('| Family / route / book / refusal | Vouchers |', '|---|---:|');
    for (const [k, n] of s.numberingCollisions) L.push(`| ${cell(k)} | ${n} |`);
    L.push('');
  }
  const known = s.groups.filter((g) => g.buildDifference);
  if (known.length) {
    L.push('## Desktop build differences (expected, not defects)', '');
    L.push('| Family | Table | Column | Kind | Vouchers | Build difference |');
    L.push('|---|---|---|---|---:|---|');
    for (const g of known)
      L.push(
        `| ${g.family} | ${g.table} | ${g.column} | ${g.kind} | ${g.cases} | ${cell(g.buildDifference)} |`,
      );
    L.push('');
  }
  L.push('## Column-level differences (identical differences grouped)', '');
  L.push('| Family | Table | Column | Kind | Vouchers | Examples (desktop → web) |');
  L.push('|---|---|---|---|---:|---|');
  for (const g of s.groups.filter((x) => !x.buildDifference)) {
    const ex = g.examples
      .map((e) => (e.desktop !== undefined ? `${e.caseId}: ${e.desktop} → ${e.web}` : e.caseId))
      .join('; ');
    L.push(`| ${g.family} | ${g.table} | ${g.column} | ${g.kind} | ${g.cases} | ${cell(ex)} |`);
  }
  L.push('');
  return `${L.join('\n')}\n`;
}

export function writeReport(path, summary) {
  writeFileSync(path, renderReport(summary));
}
