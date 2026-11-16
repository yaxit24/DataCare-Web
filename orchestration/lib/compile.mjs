// Context pack: the one prompt file a worker receives. The dispatcher assembles it, so a worker never has to
// discover rules, skills or files on its own, and two different tools or models receive identical instructions.
import fs from 'node:fs';
import path from 'node:path';
import { DESKTOP_SRC, ORCH, REPO } from './util.mjs';
import { outlineForm, renderOutline } from './outline.mjs';

function splitRef(ref) {
  const m = ref.match(/^(.*?):(\d+)-(\d+)$/);
  return m ? { file: m[1], start: Number(m[2]), end: Number(m[3]) } : { file: ref };
}

function excerpt(root, ref) {
  const { file, start, end } = splitRef(ref);
  const p = path.join(root, file);
  if (!fs.existsSync(p)) return `### ${ref}\n\nMISSING: this file is not in the worktree. Report it as blocked; do not guess its content.\n`;
  const lines = fs.readFileSync(p, 'utf8').split(/\r?\n/);
  const from = start ? Math.max(1, start) : 1;
  const to = end ? Math.min(lines.length, end) : lines.length;
  const width = String(to).length;
  const body = lines.slice(from - 1, to).map((l, i) => `${String(from + i).padStart(width)}  ${l}`);
  return `### ${file} (lines ${from}-${to} of ${lines.length})\n\n\`\`\`\n${body.join('\n')}\n\`\`\`\n`;
}

function skillBody(root, name) {
  const p = path.join(root, '.kiro', 'skills', name, 'SKILL.md');
  if (!fs.existsSync(p)) return `### Skill ${name}\n\nMISSING: .kiro/skills/${name}/SKILL.md\n`;
  return `### Skill ${name}\n\n${fs.readFileSync(p, 'utf8').replace(/^---[\s\S]*?---\s*/, '').trim()}\n`;
}

/** Writes form indexes for every desktop form the packet names; returns their worktree-relative paths. */
export function writeFormIndexes(packet, worktree) {
  const made = [];
  for (const ref of [...(packet.context || []), ...(packet.inline || [])]) {
    const { file } = splitRef(ref);
    if (!file.startsWith(`${DESKTOP_SRC}/`) || !file.endsWith('.cs')) continue;
    const src = path.join(worktree, file);
    if (!fs.existsSync(src)) continue;
    const rel = `.orch/index/${path.basename(file, '.cs')}.md`;
    if (made.includes(rel)) continue;
    fs.mkdirSync(path.join(worktree, '.orch', 'index'), { recursive: true });
    fs.writeFileSync(path.join(worktree, rel), renderOutline(outlineForm(src)));
    made.push(rel);
  }
  return made;
}

export function compilePrompt(packet, scope, { worktree = REPO, indexes = [], attempt = 1, previousFailures = [] } = {}) {
  const role = (name) => fs.readFileSync(path.join(ORCH, 'roles', `${name}.md`), 'utf8').trim();
  const list = (items, empty = '(none)') => (items && items.length ? items.map((i) => `- \`${i}\``).join('\n') : empty);
  const gates = (packet.gates || []).map((g) => {
    if (g.type === 'cite') return `- citation check on \`${g.file}\`${g.requireSnippets ? ' (every citation needs its {{quoted source text}})' : ''}`;
    if (g.type === 'node-test') return `- \`node --test ${g.path || ''}\``;
    return `- in \`${g.cwd || '.'}\`: \`${g.run}\``;
  });
  const parts = [];
  parts.push(`# WORK PACKET ${packet.id}: ${packet.title}`);
  parts.push(
    [
      'You are one worker session in the DataCare-Web orchestration. A dispatcher script started you, will check your',
      'work with scripts when you stop, and reports to a supervisor who decides what is merged. Everything you need is',
      'in this file. Read all of it before you act.',
    ].join('\n'),
  );
  if (attempt > 1 && previousFailures.length) {
    parts.push(`## 0. This is attempt ${attempt}. The previous attempt failed these checks; fix exactly these first\n\n${previousFailures.map((f) => `- ${f}`).join('\n')}`);
  }
  parts.push(`## 1. Rules for every worker\n\n${role('common')}`);
  parts.push(`## 2. Your role: ${packet.role}\n\n${role(packet.role)}`);
  parts.push(`## 3. The task\n\n${packet.body}`);
  parts.push(
    [
      '## 4. Scope the dispatcher enforces',
      '',
      `Work package: ${packet.wp || '(none)'} · branch \`${packet.branch}\` (already checked out here; never switch branch).`,
      '',
      'You may create or change only these paths:',
      list(scope.allow),
      '',
      'You must not change these, even if a path above seems to include them:',
      list([...(packet.deny || []), 'tests locked for your role, the desktop source under unified/, .github/, the orchestration machinery, AGENTS.md']),
      '',
      'Files that must exist when you stop:',
      list(packet.outputs),
      '',
      'Checks that run after you stop (run them yourself first when you can):',
      gates.length ? gates.join('\n') : '(guards only)',
      '',
      `Limits: ${scope.limits.minutes} minutes, ${scope.limits.maxChangedFiles} changed files, ${scope.limits.maxDiffLines} added lines.`,
    ].join('\n'),
  );
  parts.push(`## 5. Read these first\n\n${list([...indexes, ...(packet.context || [])])}\n\nA form index under \`.orch/index/\` maps a desktop form by line range: use it to open only the parts you need.`);
  if (packet.inline?.length) parts.push(`## 6. Excerpts\n\n${packet.inline.map((ref) => excerpt(worktree, ref)).join('\n')}`);
  if (packet.skills?.length) parts.push(`## 7. Project skills that apply\n\n${packet.skills.map((s) => skillBody(worktree, s)).join('\n')}`);
  parts.push(`## 8. How to finish\n\n${role('report')}`);
  return `${parts.join('\n\n')}\n`;
}
