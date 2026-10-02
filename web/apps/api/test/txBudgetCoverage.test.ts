import { readdirSync, readFileSync } from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import ts from 'typescript';
import { describe, expect, it } from 'vitest';

/**
 * N53 / G30: no transaction in apps/api/src relies on Prisma's implicit 5-second default.
 *
 * Every interactive transaction goes through `withTxBudget` (modules/shared/txBudget.ts), which declares a
 * budget class (read / voucher / heavy, or a named profile with an isolation level) and binds a
 * transaction-local statement_timeout. A direct `withTenant(...)` or `client.$transaction(...)` call is
 * allowed only where it is listed in EXPLICIT with its own reason and count. Stale entries fail, so the list
 * can only shrink.
 */
const SRC = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../src');

/** `file:enclosing function` -> number of direct transaction calls allowed there, and why. */
const EXPLICIT: Record<string, { count: number; reason: string }> = {
  'modules/shared/txBudget.ts:withTxBudget': { count: 1, reason: 'the budgeted wrapper itself' },
  'modules/ops/backup.ts:backupCompany': {
    count: 1,
    reason: 'explicit BACKUP_TRANSACTION_TIMEOUT_MS (120 s), longer than the heavy class',
  },
  'modules/ops/backup.ts:restoreCompany': {
    count: 1,
    reason: 'explicit RESTORE_TRANSACTION_TIMEOUT_MS (300 s), longer than the heavy class',
  },
};

export interface DirectTransaction {
  site: string;
  line: number;
  call: string;
}

function enclosingName(node: ts.Node): string {
  for (let p: ts.Node | undefined = node.parent; p; p = p.parent) {
    if ((ts.isFunctionDeclaration(p) || ts.isMethodDeclaration(p)) && p.name)
      return p.name.getText();
    if ((ts.isArrowFunction(p) || ts.isFunctionExpression(p)) && p.parent) {
      const owner = p.parent;
      if (ts.isVariableDeclaration(owner) && ts.isIdentifier(owner.name)) return owner.name.text;
      if (ts.isPropertyAssignment(owner)) return owner.name.getText();
    }
  }
  return '(module)';
}

/** Direct `withTenant(...)` and `x.$transaction(...)` calls in one source file. */
export function directTransactions(file: string, source: string): DirectTransaction[] {
  const sf = ts.createSourceFile(file, source, ts.ScriptTarget.Latest, true, ts.ScriptKind.TS);
  const found: DirectTransaction[] = [];
  const visit = (node: ts.Node) => {
    if (ts.isCallExpression(node)) {
      const callee = node.expression;
      const call =
        ts.isIdentifier(callee) && callee.text === 'withTenant'
          ? 'withTenant'
          : ts.isPropertyAccessExpression(callee) && callee.name.text === '$transaction'
            ? '$transaction'
            : null;
      if (call)
        found.push({
          site: `${file}:${enclosingName(node)}`,
          line: sf.getLineAndCharacterOfPosition(node.getStart(sf)).line + 1,
          call,
        });
    }
    ts.forEachChild(node, visit);
  };
  visit(sf);
  return found;
}

function sourceFiles(dir: string): string[] {
  return readdirSync(dir, { withFileTypes: true }).flatMap((entry) => {
    const full = path.join(dir, entry.name);
    if (entry.isDirectory()) return sourceFiles(full);
    return entry.name.endsWith('.ts') ? [full] : [];
  });
}

describe('transaction budget coverage (N53)', () => {
  it('finds a planted direct transaction, wherever it is written', () => {
    const planted = `
      import { withTenant } from '@datacare/db';
      export async function saveThing(prisma: any) {
        return withTenant(prisma, 't', async (tx: any) => tx.$executeRawUnsafe('UPDATE x SET y=1'));
      }
      export const removeThing = (prisma: any) => prisma.$transaction(async () => 1);
      // withTenant(prisma, 't', fn) in a comment is not a call
      const text = 'withTenant(prisma, t, fn) in a string is not a call';`;
    expect(directTransactions('modules/x/thing.ts', planted)).toEqual([
      { site: 'modules/x/thing.ts:saveThing', line: 4, call: 'withTenant' },
      { site: 'modules/x/thing.ts:removeThing', line: 6, call: '$transaction' },
    ]);
  });

  it('every transaction in apps/api/src goes through withTxBudget or is an explicit exception', () => {
    const counts = new Map<string, number>();
    const unexpected: string[] = [];
    for (const file of sourceFiles(SRC)) {
      const rel = path.relative(SRC, file).split(path.sep).join('/');
      for (const found of directTransactions(rel, readFileSync(file, 'utf8'))) {
        counts.set(found.site, (counts.get(found.site) ?? 0) + 1);
        if (!EXPLICIT[found.site]) unexpected.push(`${rel}:${found.line} ${found.call}`);
      }
    }
    // A new transaction must declare its budget: withTxBudget(prisma, tenantId, 'read' | 'voucher' |
    // 'heavy' | <profile>, fn). Do not add to EXPLICIT unless the command needs a longer, named limit.
    expect(unexpected).toEqual([]);
    for (const [site, entry] of Object.entries(EXPLICIT))
      expect(
        counts.get(site) ?? 0,
        `${site}: ${entry.reason} (stale entries must be removed)`,
      ).toBe(entry.count);
  });
});
