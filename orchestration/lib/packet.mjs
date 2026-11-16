// Work packets: one Markdown file = one task for one worker session.
// The file starts with a ```json header block (machine-read) followed by the brief (worker-read).
import fs from 'node:fs';
import path from 'node:path';
import { ORCH, loadConfig } from './util.mjs';

const BRANCH_OK = /^(agent|docs|fix|feat|test)\/[a-z0-9][a-z0-9._-]*$/;
const ID_OK = /^[A-Za-z0-9][A-Za-z0-9._-]*$/;

/** Paths no worker may change, whatever its packet says: the desktop authority, CI and this machinery. */
export const UNIVERSAL_DENY = [
  'unified/**',
  'extracted_code/**',
  'extraction_output/**',
  'DataCareSetup/**',
  'DataCareSetup_extracted/**',
  'DataCareNext_Source/**',
  'new/**',
  'zip_contents/**',
  '.github/**',
  '.claude/**',
  '.opencode/**',
  '.kiro/**',
  'AGENTS.md',
  'CLAUDE.md',
  'orchestration/bin/**',
  'orchestration/lib/**',
  'orchestration/config/**',
  'orchestration/roles/**',
  'orchestration/setup/**',
  'orchestration/test/**',
  'orchestration/tools/**',
  '**/.env',
  '**/.env.*',
];

export function parsePacket(file) {
  const text = fs.readFileSync(file, 'utf8');
  const m = text.match(/```json\s*\r?\n([\s\S]*?)\r?\n```/);
  if (!m) throw new Error(`${file}: no \`\`\`json header block`);
  let head;
  try {
    head = JSON.parse(m[1]);
  } catch (e) {
    throw new Error(`${file}: the header is not valid JSON (${e.message})`);
  }
  const body = text.slice(m.index + m[0].length).trim();
  return { ...head, body, file: path.resolve(file) };
}

export function validatePacket(p, routing = loadConfig('routing.json')) {
  const errors = [];
  const need = (cond, msg) => {
    if (!cond) errors.push(msg);
  };
  need(typeof p.id === 'string' && ID_OK.test(p.id), 'id: required, letters, digits, dot, dash, underscore');
  need(typeof p.title === 'string' && p.title.length > 3, 'title: required');
  need(typeof p.role === 'string' && routing.roles[p.role], `role: must be one of ${Object.keys(routing.roles).join(', ')}`);
  need(!p.role || fs.existsSync(path.join(ORCH, 'roles', `${p.role}.md`)), `role: orchestration/roles/${p.role}.md is missing`);
  need(typeof p.branch === 'string' && BRANCH_OK.test(p.branch), 'branch: required, like agent/wp18-huid-report (never main)');
  need(!p.tier || routing.tiers[p.tier], `tier: must be one of ${Object.keys(routing.tiers).join(', ')}`);
  need(!p.risk || ['A', 'B', 'C'].includes(p.risk), 'risk: A, B or C');
  for (const key of ['allow', 'deny', 'context', 'inline', 'skills', 'outputs', 'dependsOn']) {
    need(p[key] === undefined || (Array.isArray(p[key]) && p[key].every((x) => typeof x === 'string')), `${key}: array of strings`);
  }
  const readOnly = routing.roles[p.role]?.readOnly === true;
  need(readOnly || (Array.isArray(p.allow) && p.allow.length > 0), 'allow: list the paths this worker may change');
  for (const g of p.gates || []) {
    need(['cite', 'cmd', 'node-test'].includes(g?.type), `gate type must be cite, cmd or node-test: ${JSON.stringify(g)}`);
    if (g?.type === 'cite') need(typeof g.file === 'string', 'cite gate: file required');
    if (g?.type === 'cmd') need(typeof g.run === 'string', 'cmd gate: run required');
  }
  need(p.body && p.body.length > 40, 'the brief under the header is empty');
  for (const section of ['## Goal', '## Done when']) need(p.body.includes(section), `the brief needs a "${section}" section`);
  return errors;
}

/** Role defaults merged with the packet. The packet's own deny list and the universal list always apply. */
export function effectiveScope(p, routing = loadConfig('routing.json')) {
  const role = routing.roles[p.role] || {};
  const roleDeny = p.denyDefaults === false ? [] : role.deny || [];
  return {
    allow: role.readOnly ? ['.orch/**'] : [...(p.allow || [])],
    deny: [...UNIVERSAL_DENY, ...roleDeny, ...(p.deny || [])],
    limits: { minutes: 45, maxChangedFiles: 40, maxDiffLines: 4000, ...(role.limits || {}), ...(p.limits || {}) },
    tier: p.tier || role.tier || 'C',
  };
}
