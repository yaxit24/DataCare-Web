/**
 * Minimal Crystal Reports formula evaluator for the common DISPLAY formulas in these bills
 * (address concatenation, conditional show/hide, ToText/Trim, numeric +/-/*). Not a full Crystal
 * engine — it resolves field refs via `getRef`, handles single-level if/then/else, string concat
 * with '+', comparisons (<> = > < >= <=), and ToText/Trim/CStr. Always safe: any parse failure
 * returns '' rather than throwing, so a report never breaks on an exotic formula.
 */
export type RefGetter = (ref: string) => string;

const num = (s: string): number => {
  const n = parseFloat(String(s).replace(/[^0-9.\-]/g, ''));
  return isNaN(n) ? 0 : n;
};
const isNumeric = (s: string): boolean => /^\s*-?[0-9.,]+\s*$/.test(s);

function stripFn(t: string): { fn: string; inner: string } | null {
  const m = t.match(/^\s*(ToText|totext|Trim|trim|CStr|cstr|TrimLeft|TrimRight)\s*\((.*)\)\s*$/s);
  return m ? { fn: (m[1] ?? '').toLowerCase(), inner: m[2] ?? '' } : null;
}

/** split a string by a top-level operator (respecting quotes + parens) */
function splitTop(s: string, ops: string[]): { parts: string[]; sep: string[] } {
  const parts: string[] = [];
  const sep: string[] = [];
  let depth = 0,
    q = false,
    cur = '';
  for (let i = 0; i < s.length; i++) {
    const c = s[i];
    if (q) {
      cur += c;
      if (c === "'") q = false;
      continue;
    }
    if (c === "'") {
      q = true;
      cur += c;
      continue;
    }
    if (c === '(') depth++;
    else if (c === ')') depth--;
    let matched = '';
    if (depth === 0)
      for (const op of ops) {
        if (s.substr(i, op.length) === op) {
          matched = op;
          break;
        }
      }
    if (matched) {
      parts.push(cur);
      sep.push(matched);
      cur = '';
      i += matched.length - 1;
    } else cur += c;
  }
  parts.push(cur);
  return { parts, sep };
}

function evalTerm(t: string, get: RefGetter, depth: number): string {
  t = t.trim();
  if (!t) return '';
  const fn = stripFn(t);
  if (fn) return evalExpr(fn.inner, get, depth + 1);
  if (t.startsWith("'") && t.endsWith("'")) return t.slice(1, -1).replace(/''/g, "'");
  const ref = t.match(/^\{@?([A-Za-z0-9_. ]+)\}$/);
  if (ref) return get(t);
  if (isNumeric(t)) return t.trim();
  return t; // bare identifier/unknown → passthrough
}

function evalExpr(s: string, get: RefGetter, depth: number): string {
  if (depth > 10) return '';
  const { parts } = splitTop(s, ['+']);
  if (parts.length > 1) {
    const vals = parts.map((p) => evalTerm(p, get, depth));
    if (vals.every((v) => isNumeric(v) || v === ''))
      return String(vals.reduce((a, v) => a + num(v), 0));
    return vals.join('');
  }
  // try - * for numeric
  for (const op of ['-', '*']) {
    const sp = splitTop(s, [op]);
    if (sp.parts.length > 1) {
      const vals = sp.parts.map((p) => num(evalTerm(p, get, depth)));
      return String(op === '-' ? vals.reduce((a, v) => a - v) : vals.reduce((a, v) => a * v));
    }
  }
  return evalTerm(s, get, depth);
}

function evalCond(c: string, get: RefGetter, depth: number): boolean {
  for (const op of ['<>', '>=', '<=', '=', '>', '<']) {
    const sp = splitTop(c, [op]);
    if (sp.parts.length === 2) {
      const a = evalExpr(sp.parts[0] ?? '', get, depth),
        b = evalExpr(sp.parts[1] ?? '', get, depth);
      if (isNumeric(a) && isNumeric(b)) {
        const x = num(a),
          y = num(b);
        return op === '<>'
          ? x !== y
          : op === '='
            ? x === y
            : op === '>'
              ? x > y
              : op === '<'
                ? x < y
                : op === '>='
                  ? x >= y
                  : x <= y;
      }
      return op === '<>'
        ? a !== b
        : op === '='
          ? a === b
          : op === '>'
            ? a > b
            : op === '<'
              ? a < b
              : op === '>='
                ? a >= b
                : a <= b;
    }
  }
  return !!evalExpr(c, get, depth).trim();
}

export function evalCrystal(text: string, get: RefGetter, depth = 0): string {
  try {
    if (depth > 12 || !text) return '';
    const t = text.trim().replace(/;\s*$/, '');
    const ite = t.match(/^if\s+([\s\S]+?)\s+then\s+([\s\S]+?)(?:\s+else\s+([\s\S]+))?$/i);
    if (ite)
      return evalCond(ite[1] ?? '', get, depth)
        ? evalCrystal(ite[2] ?? '', get, depth + 1)
        : ite[3]
          ? evalCrystal(ite[3], get, depth + 1)
          : '';
    return evalExpr(t, get, depth);
  } catch {
    return '';
  }
}
