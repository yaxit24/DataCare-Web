#!/usr/bin/env node
// Machine bootstrap for the orchestration layer. Run it from inside a clone of the repository:
//   node orchestration/setup/bootstrap.mjs            configure this clone, create the folders, run the checks
//   node orchestration/setup/bootstrap.mjs --install  also install the missing npm-based tools
//   node orchestration/setup/bootstrap.mjs --with-lfs keep Git LFS downloads on (the reference copy with binaries)
// It works the same on Windows, macOS and Linux and changes nothing outside this clone, <root>/wt, <root>/state
// and (with --install) the global npm packages. See orchestration/SETUP.md.
import { spawnSync } from 'node:child_process';
import fs from 'node:fs';
import path from 'node:path';
import { ORCH, git, layout, loadConfig, sh } from '../lib/util.mjs';

const flags = new Set(process.argv.slice(2));
const say = (s) => console.log(s);
const has = (bin) => (process.platform === 'win32' ? sh('where', [bin]) : sh('which', [bin])).code === 0;
const npm = (args) => spawnSync('npm', args, { stdio: 'inherit', shell: process.platform === 'win32' }).status === 0;

const l = layout();
say(`Base clone  ${l.base}\nWorktrees   ${l.wtRoot}\nState       ${l.stateRoot}\n`);

say('1. Clone settings');
const set = (key, value) => {
  git(['config', key, value], l.base);
  say(`   ${key} = ${value}`);
};
set('core.autocrlf', 'false');
if (process.platform === 'win32') set('core.longpaths', 'true');
if (!flags.has('--with-lfs')) {
  set('filter.lfs.smudge', 'git-lfs smudge --skip -- %f');
  set('filter.lfs.process', 'git-lfs filter-process --skip');
}
const name = git(['config', '--get', 'user.name'], l.base, { allowFail: true }).out;
if (!name) say('   NOTE: no commit identity. Set one for this clone:\n         git config user.name "<name>"\n         git config user.email "<id>+<login>@users.noreply.github.com"');

say('\n2. Folders');
for (const dir of [l.wtRoot, l.stateRoot, path.join(l.stateRoot, 'runs')]) {
  fs.mkdirSync(dir, { recursive: true });
  say(`   ${dir}`);
}
const keys = path.join(l.stateRoot, 'providers.env');
if (!fs.existsSync(keys)) {
  fs.copyFileSync(path.join(ORCH, 'config', 'providers.example.env'), keys);
  say(`   created ${keys} (fill in the keys you have; it is outside the repository)`);
} else say(`   kept ${keys}`);

say('\n3. Tools');
if (!has('pnpm')) {
  if (flags.has('--install')) npm(['install', '--global', 'pnpm@9.15.4']);
  else say('   pnpm is missing: npm install --global pnpm@9.15.4');
}
for (const [id, runner] of Object.entries(loadConfig('runners.json'))) {
  if (has(runner.bin)) say(`   ${id}: installed`);
  else if (flags.has('--install') && runner.install.startsWith('npm install')) npm(runner.install.split(' ').slice(1));
  else say(`   ${id}: missing -> ${runner.install}`);
}

say('\n4. Checks');
const orch = path.join(ORCH, 'bin', 'orch.mjs');
const doctor = spawnSync(process.execPath, [orch, 'doctor'], { stdio: 'inherit' }).status;
say('');
spawnSync(process.execPath, [orch, 'providers'], { stdio: 'inherit' });

say('\n5. Still by hand');
if (process.platform === 'win32') {
  say('   - Docker needs WSL 2. In an administrator terminal: wsl --install --no-distribution   then restart Windows,');
  say('     start Docker Desktop and set Settings > Resources > Advanced > Disk image location to a drive with space.');
}
say('   - Sign in to the worker tools you will use: opencode auth login, codex login.');
say(`   - Put provider keys in ${keys}, then set the model ids in orchestration/config/routing.json.`);
say('   - Web dependencies, once per worktree that runs gates: cd web && pnpm install --frozen-lockfile');
say('   - Optional: herdr (https://herdr.dev) to watch several interactive sessions.');
process.exit(doctor === 0 ? 0 : 1);
