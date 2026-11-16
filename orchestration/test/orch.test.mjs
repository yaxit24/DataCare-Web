// Run with: node --test orchestration/test/orch.test.mjs
// The end-to-end tests use a throwaway git repository and a scripted stand-in for the worker, so they need no
// model, no provider key and no network.
import assert from 'node:assert/strict';
import fs from 'node:fs';
import os from 'node:os';
import path from 'node:path';
import { after, before, test } from 'node:test';
import { checkCitations } from '../lib/cite.mjs';
import { compilePrompt } from '../lib/compile.mjs';
import { outlineForm, renderOutline } from '../lib/outline.mjs';
import { effectiveScope, parsePacket, validatePacket } from '../lib/packet.mjs';
import { runPacket } from '../lib/run.mjs';
import { fill, git, globToRegExp, loadEnvFile, matchAny } from '../lib/util.mjs';

const tmp = fs.mkdtempSync(path.join(os.tmpdir(), 'dc-orch-'));
const repo = path.join(tmp, 'repo');
const state = path.join(tmp, 'state');
const fwd = (p) => p.replace(/\\/g, '/');

const FORM = [
  'namespace DataCareNext;',
  'public class DEMO : Form',
  '{',
  '\tprivate void InitializeComponent()',
  '\t{',
  '\t\tBtnSave.Text = "&Save";',
  '\t}',
  '\tprivate void BtnSave_Click(object sender, EventArgs e)',
  '\t{',
  '\t\tInteraction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);',
  '\t\tDC_Main.ExeQuteMc("DELETE FROM LOGIN_MAST WHERE CO_CODE = \'" + DC_Main.MCo_code + "\'");',
  '\t\tDC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = \'1\'";',
  '\t}',
  '\tprivate void DEMO_KeyDown(object sender, KeyEventArgs e)',
  '\t{',
  '\t\tif (e.KeyCode == Keys.Escape) Close();',
  '\t}',
  '}',
].join('\n');

function packetText(extra = {}) {
  const head = {
    id: 'T-01.study', wp: 'T-01', title: 'Demo study', role: 'study', branch: 'agent/t01-demo',
    allow: ['orchestration/work/T-01/**'], outputs: ['orchestration/work/T-01/study.md'],
    context: ['unified/src/csharp/DataCareNext/DEMO.cs'],
    gates: [{ type: 'cite', file: 'orchestration/work/T-01/study.md', requireSnippets: true }],
    ...extra,
  };
  return `# Packet\n\n\`\`\`json\n${JSON.stringify(head, null, 2)}\n\`\`\`\n\n## Goal\n\nStudy the demo form and write the study document.\n\n## Done when\n\n- The study exists and its citations pass.\n`;
}

function worker(name, body) {
  const file = path.join(tmp, `${name}.mjs`);
  fs.writeFileSync(file, `import fs from 'node:fs';\n${body}\n`);
  return `node "${fwd(file)}"`;
}

const GOOD_WORKER = `
fs.mkdirSync('orchestration/work/T-01', { recursive: true });
fs.writeFileSync('orchestration/work/T-01/study.md', '# Study\\n\\nThe save button refuses without rights: DEMO.cs:10 {{You Have No Rights.....}}\\n');
fs.writeFileSync('.orch/report.md', 'STATUS: DONE\\n\\n## What I did\\nWrote the study.\\n');
`;

before(() => {
  fs.mkdirSync(path.join(repo, 'unified/src/csharp/DataCareNext'), { recursive: true });
  fs.mkdirSync(path.join(repo, 'web/apps/api/test'), { recursive: true });
  fs.mkdirSync(state, { recursive: true });
  fs.writeFileSync(path.join(repo, 'unified/src/csharp/DataCareNext/DEMO.cs'), FORM);
  fs.writeFileSync(path.join(repo, 'web/apps/api/test/demo.test.ts'), "it('works', () => {});\n");
  fs.writeFileSync(path.join(repo, '.gitignore'), '.orch/\n');
  git(['init', '-q', '-b', 'agent/t01-demo'], repo);
  git(['config', 'user.name', 'orch-test'], repo);
  git(['config', 'user.email', 'orch-test@example.invalid'], repo);
  git(['config', 'core.autocrlf', 'false'], repo);
  git(['add', '.'], repo);
  git(['commit', '-q', '-m', 'fixture'], repo);
  process.env.DATACARE_STATE_ROOT = state;
});

after(() => {
  delete process.env.DATACARE_STATE_ROOT;
  fs.rmSync(tmp, { recursive: true, force: true });
});

const reset = () => {
  git(['reset', '-q', '--hard', 'HEAD'], repo);
  git(['clean', '-q', '-fdx'], repo);
};
const writePacket = (extra) => {
  const file = path.join(tmp, 'packet.md');
  fs.writeFileSync(file, packetText(extra));
  return file;
};

test('glob patterns match the way packets expect', () => {
  assert.ok(globToRegExp('web/apps/api/test/**').test('web/apps/api/test/a/b.test.ts'));
  assert.ok(globToRegExp('web/packages/*/test/**').test('web/packages/core/test/x.ts'));
  assert.ok(!globToRegExp('web/packages/*/test/**').test('web/packages/core/src/x.ts'));
  assert.ok(globToRegExp('**/.env.*').test('web/.env.local'));
  assert.ok(globToRegExp('**/.env').test('.env'));
  assert.ok(!globToRegExp('docs/*.md').test('docs/a/b.md'));
  assert.ok(matchAny('AGENTS.md', ['AGENTS.md']));
});

test('template fill and env files', () => {
  assert.equal(fill('--model {model} {unknown}', { model: 'x/y' }), '--model x/y {unknown}');
  const f = path.join(tmp, 'p.env');
  fs.writeFileSync(f, '# comment\nA_KEY=abc\nB_KEY="quoted value"\n\nbad line\n');
  assert.deepEqual(loadEnvFile(f), { A_KEY: 'abc', B_KEY: 'quoted value' });
});

test('a packet must name a work branch, its allowed paths and its goal', () => {
  const good = writePacket();
  assert.deepEqual(validatePacket(parsePacket(good)), []);
  const onMain = validatePacket(parsePacket(writePacket({ branch: 'main' })));
  assert.ok(onMain.some((e) => e.startsWith('branch')));
  const noAllow = validatePacket(parsePacket(writePacket({ allow: [] })));
  assert.ok(noAllow.some((e) => e.startsWith('allow')));
  const badRole = validatePacket(parsePacket(writePacket({ role: 'wizard' })));
  assert.ok(badRole.some((e) => e.startsWith('role')));
  const scope = effectiveScope(parsePacket(writePacket({ role: 'implement', allow: ['web/**'] })));
  assert.ok(matchAny('web/apps/api/test/x.db.test.ts', scope.deny), 'tests are locked for the implement role');
  assert.ok(matchAny('unified/src/csharp/DataCareNext/DEMO.cs', scope.deny), 'the desktop source is always locked');
});

test('citations: a quote must be at the cited line', () => {
  const srcDir = path.join(repo, 'unified/src/csharp/DataCareNext');
  const ok = checkCitations('Rule: DEMO.cs:10 {{You Have No Rights.....}} and DEMO.cs:11-12 {{DELETE FROM LOGIN_MAST}}', { srcDir });
  assert.deepEqual([ok.total, ok.verified, ok.errors.length], [2, 2, 0]);
  const wrongLine = checkCitations('DEMO.cs:2 {{You Have No Rights.....}}', { srcDir });
  assert.equal(wrongLine.errors.length, 1);
  const invented = checkCitations('DEMO.cs:10 {{You Do Not Have Permission}}', { srcDir });
  assert.equal(invented.errors.length, 1);
  assert.equal(checkCitations('DEMO.cs:999', { srcDir }).errors.length, 1);
  assert.equal(checkCitations('NOPE.cs:1', { srcDir }).errors.length, 1);
  assert.equal(checkCitations('DEMO.cs:10', { srcDir }).errors.length, 0);
  assert.equal(checkCitations('DEMO.cs:10', { srcDir, requireSnippets: true }).errors.length, 1);
});

test('form index lists members, messages, captions and tables with lines', () => {
  const o = outlineForm(path.join(repo, 'unified/src/csharp/DataCareNext/DEMO.cs'));
  assert.deepEqual(o.members.map((m) => [m.name, m.start, m.kind]), [['InitializeComponent', 4, 'designer'], ['BtnSave_Click', 8, 'event:Click'], ['DEMO_KeyDown', 14, 'event:KeyDown']]);
  assert.equal(o.members[1].end, 13);
  assert.ok(o.members[2].keys);
  assert.deepEqual(o.messages.map((m) => [m.text, m.line, m.member]), [['You Have No Rights.....', 10, 'BtnSave_Click']]);
  assert.deepEqual(o.captions, [{ control: 'BtnSave', text: '&Save', line: 6 }]);
  assert.deepEqual(o.tables.get('LOGIN_MAST').writes, ['DELETE 11']);
  assert.deepEqual(o.tables.get('YEAR_MAST').reads, ['12']);
  assert.match(renderOutline(o), /\| BtnSave_Click \| 8-13 \| event:Click \|/);
});

test('the context pack carries the rules, the role, the task and the scope', () => {
  const packet = parsePacket(writePacket({ inline: ['unified/src/csharp/DataCareNext/DEMO.cs:8-10'] }));
  const prompt = compilePrompt(packet, effectiveScope(packet), { worktree: repo, indexes: ['.orch/index/DEMO.md'] });
  for (const needle of ['WORK PACKET T-01.study', 'Rules for every worker', 'Your role: study', 'Study the demo form', 'orchestration/work/T-01/**', '.orch/index/DEMO.md', 'STATUS: DONE', '10  \t\tInteraction.MsgBox']) {
    assert.ok(prompt.includes(needle), `prompt lacks: ${needle}`);
  }
});

test('end to end: a worker that stays in scope and cites correctly passes and is committed', async () => {
  reset();
  const result = await runPacket(writePacket(), { worktree: repo, runnerCmd: worker('good', GOOD_WORKER), commit: true });
  assert.equal(result.verdict, 'pass', JSON.stringify([result.guards.failures, result.gates], null, 1));
  assert.deepEqual(result.guards.changed.map((c) => c.file), ['orchestration/work/T-01/study.md']);
  assert.ok(result.commit, 'the dispatcher committed the work');
  assert.ok(fs.existsSync(path.join(repo, '.orch/index/DEMO.md')), 'the form index was generated for the worker');
  assert.match(git(['log', '-1', '--format=%B'], repo).out, /Packet: T-01\.study \(study\)/);
  const ledger = fs.readFileSync(path.join(state, 'ledger.jsonl'), 'utf8').trim().split('\n').map((l) => JSON.parse(l));
  assert.equal(ledger.at(-1).verdict, 'pass');
  assert.ok(fs.existsSync(path.join(result.runDir, 'summary.md')));
});

test('end to end: an invented citation fails the run', async () => {
  reset();
  const bad = GOOD_WORKER.replace('DEMO.cs:10 {{You Have No Rights.....}}', 'DEMO.cs:10 {{Access Denied For This User}}');
  const result = await runPacket(writePacket(), { worktree: repo, runnerCmd: worker('bad-cite', bad) });
  assert.equal(result.verdict, 'fail');
  assert.ok(result.gates.some((g) => !g.ok && g.gate.startsWith('cite')));
});

test('end to end: touching the desktop source or a path outside the packet fails the run', async () => {
  reset();
  const rogue = `${GOOD_WORKER}\nfs.appendFileSync('unified/src/csharp/DataCareNext/DEMO.cs', '\\n// edited');\nfs.writeFileSync('web/stray.ts', 'export {};\\n');`;
  const result = await runPacket(writePacket(), { worktree: repo, runnerCmd: worker('rogue', rogue) });
  assert.equal(result.verdict, 'fail');
  assert.ok(result.guards.failures.some((f) => f.includes('protected path: unified/')));
  assert.ok(result.guards.failures.some((f) => f.includes('outside the packet') && f.includes('web/stray.ts')));
  assert.deepEqual(result.gates, [], 'gates are not run when a guard fails');
});

test('end to end: a skipped test and a deleted test file are caught', async () => {
  reset();
  const weaken = `
fs.writeFileSync('web/apps/api/test/new.test.ts', "it.skip('later', () => {});\\n");
fs.rmSync('web/apps/api/test/demo.test.ts');
fs.writeFileSync('.orch/report.md', 'STATUS: DONE\\n');
`;
  const file = writePacket({ id: 'T-01.tests', role: 'tests', allow: ['web/apps/api/test/**'], outputs: [], gates: [] });
  const result = await runPacket(file, { worktree: repo, runnerCmd: worker('weaken', weaken) });
  assert.equal(result.verdict, 'fail');
  assert.ok(result.guards.failures.some((f) => f.startsWith('test-skipped-or-focused')));
  assert.ok(result.guards.failures.some((f) => f.startsWith('deleted a test file')));
});

test('end to end: rewriting an LF file with CRLF line endings is refused', async () => {
  reset();
  const crlf = `
fs.writeFileSync('web/apps/api/test/demo.test.ts', "it('works', () => {});\\r\\nit('more', () => {});\\r\\n");
fs.writeFileSync('.orch/report.md', 'STATUS: DONE\\n');
`;
  const file = writePacket({ id: 'T-01.tests', role: 'tests', allow: ['web/apps/api/test/**'], outputs: [], gates: [] });
  const result = await runPacket(file, { worktree: repo, runnerCmd: worker('crlf', crlf) });
  assert.equal(result.verdict, 'fail');
  assert.ok(result.guards.failures.some((f) => f.startsWith('line endings changed from LF to CRLF')));
});

test('end to end: no report, or a blocked report, is not a pass', async () => {
  reset();
  const silent = GOOD_WORKER.replace(/fs\.writeFileSync\('\.orch\/report\.md'.*\n/, '');
  assert.equal((await runPacket(writePacket(), { worktree: repo, runnerCmd: worker('silent', silent) })).verdict, 'fail');
  reset();
  const blocked = GOOD_WORKER.replace('STATUS: DONE', 'STATUS: BLOCKED');
  assert.equal((await runPacket(writePacket(), { worktree: repo, runnerCmd: worker('blocked', blocked) })).verdict, 'blocked');
});

test('a dry run builds the context pack and starts nothing', async () => {
  reset();
  const result = await runPacket(writePacket(), { worktree: repo, runnerCmd: 'never-run', dryRun: true });
  assert.ok(result.dryRun && result.approxTokens > 500);
  assert.equal(git(['status', '--porcelain'], repo).out, '');
});
