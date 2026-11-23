// Citation check for desktop-authority claims.
// A citation is `FORM.cs:123` or `FORM.cs:120-130`. A verified citation adds the quoted source text:
//   MS_YEAR.cs:980 {{Are You Sure To Delete This User now?}}
// The check fails on a missing file, a line outside the file, or a quote that is not at (or within two lines of)
// the cited lines. This is what catches invented line numbers, the most common failure of a cheap model.
import fs from 'node:fs';
import path from 'node:path';
import { DESKTOP_SRC, REPO } from './util.mjs';

const CITE = /(?:unified\/src\/csharp\/DataCareNext\/)?\b([A-Za-z_][A-Za-z0-9_]*\.cs):(\d+)(?:-(\d+))?(?:\s*\{\{(.+?)\}\})?/g;
const squeeze = (s) => s.replace(/\s+/g, ' ').trim();

export function checkCitations(text, { srcDir = path.join(REPO, DESKTOP_SRC), requireSnippets = false, tolerance = 2 } = {}) {
  const cache = new Map();
  const linesOf = (file) => {
    if (!cache.has(file)) {
      const p = path.join(srcDir, file);
      cache.set(file, fs.existsSync(p) ? fs.readFileSync(p, 'utf8').split(/\r?\n/) : null);
    }
    return cache.get(file);
  };
  const result = { total: 0, verified: 0, rangeOnly: 0, errors: [] };
  text.split(/\r?\n/).forEach((line, index) => {
    for (const m of line.matchAll(CITE)) {
      const [whole, file, a, b, snippet] = m;
      const at = `line ${index + 1}: ${whole.slice(0, 90)}`;
      result.total++;
      const src = linesOf(file);
      if (!src) {
        result.errors.push(`${at} -> ${file} is not in ${DESKTOP_SRC}`);
        continue;
      }
      const start = Number(a);
      const end = b ? Number(b) : start;
      if (start < 1 || end < start || end > src.length) {
        result.errors.push(`${at} -> outside 1-${src.length}`);
        continue;
      }
      if (!snippet) {
        result.rangeOnly++;
        if (requireSnippets) result.errors.push(`${at} -> no {{quoted source text}}`);
        continue;
      }
      const want = squeeze(snippet);
      if (want.length < 6) {
        result.errors.push(`${at} -> the quote is too short to prove anything`);
        continue;
      }
      const from = Math.max(0, start - 1 - tolerance);
      const to = Math.min(src.length, end + tolerance);
      const window = squeeze(src.slice(from, to).join(' '));
      if (window.includes(want)) result.verified++;
      else result.errors.push(`${at} -> the quote is not at ${file}:${start}${b ? `-${end}` : ''}`);
    }
  });
  return result;
}

export function checkCitationFile(file, opts) {
  return checkCitations(fs.readFileSync(file, 'utf8'), opts);
}
