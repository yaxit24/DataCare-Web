// Resolve merge conflicts in the plan's record files after `git merge origin/main`, by rule, with no guessing:
//   node resolve-records.mjs <worktree>
// - JSON (the backlog): a three-way merge of the parsed documents; arrays of objects with an `id` merge by id.
// - Markdown tables: rows are keyed by their first cell; a row changed on one side only takes that side.
// - project-memory/HANDOFF.md: both sides' new sections are kept, this branch's first.
// Anything the rules cannot decide stops the script with the file and the key, and leaves the file conflicted.
import { execFileSync } from 'node:child_process';
import fs from 'node:fs';
import path from 'node:path';

const wt = process.argv[2];
const git = (...args) => execFileSync('git', args, { cwd: wt, encoding: 'utf8', maxBuffer: 256 * 1024 * 1024 });
const stage = (n, file) => {
  try {
    return git('show', `:${n}:${file}`);
  } catch {
    return null;
  }
};
const eq = (a, b) => JSON.stringify(a) === JSON.stringify(b);
const isObj = (v) => v && typeof v === 'object' && !Array.isArray(v);
const idArray = (v) => Array.isArray(v) && v.length > 0 && v.every((x) => isObj(x) && typeof x.id === 'string');

function merge3(b, o, t, where) {
  if (eq(o, t)) return o;
  if (eq(b, o)) return t;
  if (eq(b, t)) return o;
  if ((idArray(o) || (Array.isArray(o) && !o.length)) && (idArray(t) || (Array.isArray(t) && !t.length))) {
    const baseById = new Map((Array.isArray(b) ? b : []).map((x) => [x.id, x]));
    const oursById = new Map(o.map((x) => [x.id, x]));
    const out = [];
    for (const item of t) {
      if (oursById.has(item.id)) out.push(merge3(baseById.get(item.id), oursById.get(item.id), item, `${where}[${item.id}]`));
      else if (!baseById.has(item.id)) out.push(item); // added on main
      // else: removed on this branch -> stays removed
    }
    const theirs = new Set(t.map((x) => x.id));
    for (const item of o) if (!theirs.has(item.id) && !baseById.has(item.id)) out.push(item); // added on this branch
    return out;
  }
  if (isObj(o) && isObj(t)) {
    const out = {};
    for (const key of new Set([...Object.keys(t), ...Object.keys(o)])) {
      const inO = key in o;
      const inT = key in t;
      const inB = isObj(b) && key in b;
      if (inO && inT) out[key] = merge3(inB ? b[key] : undefined, o[key], t[key], `${where}.${key}`);
      else if (inO && !inB) out[key] = o[key];
      else if (inT && !inB) out[key] = t[key];
      // present on one side and in the base: the other side deleted it -> stays deleted
    }
    return out;
  }
  throw new Error(`cannot decide ${where}: changed differently on both sides`);
}

function resolveJson(file) {
  const [b, o, t] = [1, 2, 3].map((n) => stage(n, file));
  const merged = merge3(JSON.parse(b), JSON.parse(o), JSON.parse(t), path.basename(file));
  const indent = (t.match(/\n( +)"/) || [, '  '])[1].length;
  const text = `${JSON.stringify(merged, null, indent)}\n`;
  if (`${JSON.stringify(JSON.parse(t), null, indent)}\n` !== t) throw new Error(`${file}: main's copy does not round-trip through JSON.stringify; resolve by hand`);
  fs.writeFileSync(path.join(wt, file), text);
}

const firstCell = (line) => (line.startsWith('|') ? line.split('|')[1]?.trim() : null);

function resolveMarkdown(file, mode) {
  const baseRows = new Map();
  for (const line of (stage(1, file) || '').split('\n')) {
    const k = firstCell(line);
    if (k && !baseRows.has(k)) baseRows.set(k, line);
  }
  const out = [];
  let ours = null;
  let theirs = null;
  for (const line of fs.readFileSync(path.join(wt, file), 'utf8').split('\n')) {
    if (line.startsWith('<<<<<<< ')) ours = [];
    else if (line.startsWith('=======') && ours && !theirs) theirs = [];
    else if (line.startsWith('>>>>>>> ') && theirs) {
      if (mode === 'sections') out.push(...ours, ...(ours.at(-1) === '' ? [] : ['']), ...theirs);
      else {
        const o = new Map(ours.map((l) => [firstCell(l), l]));
        const seen = new Set();
        for (const l of theirs) {
          const k = firstCell(l);
          if (!k) throw new Error(`${file}: a conflict line is not a table row: ${l.slice(0, 80)}`);
          seen.add(k);
          const mine = o.get(k);
          const base = baseRows.get(k);
          if (mine === undefined || mine === l || mine === base) out.push(l);
          else if (l === base) out.push(mine);
          else throw new Error(`${file}: row "${k}" changed on both sides`);
        }
        for (const l of ours) {
          const k = firstCell(l);
          if (!k) throw new Error(`${file}: a conflict line is not a table row: ${l.slice(0, 80)}`);
          if (!seen.has(k)) out.push(l);
        }
      }
      ours = null;
      theirs = null;
    } else if (theirs) theirs.push(line);
    else if (ours) ours.push(line);
    else out.push(line);
  }
  fs.writeFileSync(path.join(wt, file), out.join('\n'));
}

const conflicted = git('diff', '--name-only', '--diff-filter=U').split('\n').filter(Boolean);
for (const file of conflicted) {
  if (file.endsWith('.json')) resolveJson(file);
  else if (file === 'project-memory/HANDOFF.md') resolveMarkdown(file, 'sections');
  else if (file.endsWith('.md')) resolveMarkdown(file, 'rows');
  else throw new Error(`${file}: no rule for this file; resolve by hand`);
  const left = fs.readFileSync(path.join(wt, file), 'utf8').split('\n').filter((l) => /^(<<<<<<< |>>>>>>> )/.test(l)).length;
  if (left) throw new Error(`${file}: ${left} conflict markers remain`);
  console.log(`resolved ${file}`);
}
