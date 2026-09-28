import { describe, it, expect } from 'vitest';
import { readFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join } from 'node:path';

/**
 * Routes must forward every input their module documents.
 *
 * This gate exists because of a real defect. `SchemeInstallmentInput` documents 14 fields, including
 * BANK_NAME, EMP_CODE, MONTH_CODE and WITH_UPI — four columns the desktop's TR_MEMB_ENT grid captures
 * on every instalment. The route forwarded six. The module was correct, the persisted rows had the
 * columns, and there was no way to populate them over the API. Nothing failed: the module-level tests
 * called the function directly and passed, which is exactly why a module-level test cannot cover this.
 *
 * The check is static, like `routePolicy.test.ts`: it reads the route source, isolates the object
 * literal passed to the module, and asserts each documented field name appears as a forwarded key.
 * A field that must NOT come from the client (identity, tenant scope) is exempted with its reason.
 */

const here = dirname(fileURLToPath(import.meta.url));
const read = (rel: string): string => readFileSync(join(here, '..', 'src', rel), 'utf8');

/** Fields a route must never take from the request body, with the reason it is refused. */
const SERVER_OWNED: Record<string, string> = {
  scope: 'derived from the authenticated session, never the body',
  mainUser: 'the acting user comes from the session, not the payload',
};

/** Extract the field names declared on an exported interface. */
function interfaceFields(source: string, name: string): string[] {
  const start = source.indexOf(`export interface ${name} {`);
  if (start < 0) throw new Error(`interface ${name} not found`);
  let depth = 0;
  let end = start;
  for (let i = source.indexOf('{', start); i < source.length; i += 1) {
    if (source[i] === '{') depth += 1;
    else if (source[i] === '}') {
      depth -= 1;
      if (depth === 0) {
        end = i;
        break;
      }
    }
  }
  const body = source.slice(start, end);
  const fields = new Set<string>();
  // Match `name?: type;` / `name: type;` at the top level of the interface body, skipping comments.
  for (const line of body.split('\n')) {
    const t = line.trim();
    if (!t || t.startsWith('*') || t.startsWith('//') || t.startsWith('/*')) continue;
    const m = /^([A-Za-z_][A-Za-z0-9_]*)\??\s*:/.exec(t);
    if (m) fields.add(m[1]!);
  }
  return [...fields];
}

function literalKeys(source: string, open: number): string[] {
  let depth = 0;
  let end = open;
  for (let i = open; i < source.length; i += 1) {
    if (source[i] === '{') depth += 1;
    else if (source[i] === '}') {
      depth -= 1;
      if (depth === 0) {
        end = i;
        break;
      }
    }
  }
  const body = source.slice(open + 1, end);
  const keys = new Set<string>();
  for (const line of body.split('\n')) {
    const t = line.trim();
    if (!t || t.startsWith('*') || t.startsWith('//') || t.startsWith('/*')) continue;
    const m = /^([A-Za-z_][A-Za-z0-9_]*)\s*:/.exec(t);
    if (m) keys.add(m[1]!);
  }
  return [...keys];
}

/** Extract the object literal passed as the second argument of `call(prisma, { ... })`. */
function forwardedKeys(source: string, call: string): string[] {
  const at = source.indexOf(`${call}(prisma, {`);
  if (at < 0) throw new Error(`call ${call}(prisma, { … }) not found`);
  return literalKeys(source, source.indexOf('{', at));
}

/** Extract keys from a route-local helper defined as `const helper = (...) => ({ ... })`. */
function helperKeys(source: string, helper: string): string[] {
  const at = source.indexOf(`const ${helper} =`);
  if (at < 0) throw new Error(`helper ${helper} not found`);
  const arrow = source.indexOf('=> ({', at);
  if (arrow < 0) throw new Error(`helper ${helper} does not return an object literal`);
  return literalKeys(source, source.indexOf('{', arrow));
}

describe('routes forward every documented module input', () => {
  const scheme = read('modules/membership/scheme.ts');
  const rateCut = read('modules/sales/rateCut.ts');
  const txn = read('routes/txn.ts');

  it('the extractors actually find something (guard against a vacuous pass)', () => {
    const fields = interfaceFields(scheme, 'SchemeInstallmentInput');
    expect(fields.length).toBeGreaterThan(8);
    expect(fields).toContain('monthCode');
    const keys = forwardedKeys(txn, 'schemeInstallment');
    expect(keys.length).toBeGreaterThan(6);
  });

  it('/scheme/installment forwards all client-supplied SchemeInstallmentInput fields', () => {
    const declared = interfaceFields(scheme, 'SchemeInstallmentInput');
    const forwarded = new Set(forwardedKeys(txn, 'schemeInstallment'));
    const missing = declared.filter((f) => !forwarded.has(f) && !(f in SERVER_OWNED));
    expect(missing).toEqual([]);
  });

  it('/scheme/opening forwards them too (same grid, book 075)', () => {
    const declared = interfaceFields(scheme, 'SchemeInstallmentInput');
    const forwarded = new Set(forwardedKeys(txn, 'schemeOpening'));
    const missing = declared.filter((f) => !forwarded.has(f) && !(f in SERVER_OWNED));
    expect(missing).toEqual([]);
  });

  it('/rate-cut forwards all client-supplied RateCutInput fields', () => {
    expect(txn).toContain('postRateCut(prisma, rateCutInput(req, b))');
    const declared = interfaceFields(rateCut, 'RateCutInput');
    const forwarded = new Set(helperKeys(txn, 'rateCutInput'));
    const missing = declared.filter((f) => !forwarded.has(f) && !(f in SERVER_OWNED));
    expect(missing).toEqual([]);
  });

  it('server-owned fields are refused from the body, each with a stated reason', () => {
    for (const [field, reason] of Object.entries(SERVER_OWNED)) {
      expect(reason.length).toBeGreaterThan(20);
      // `scope` is passed but built server-side; assert it is not read off the body.
      expect(txn).not.toContain(`${field}: b.${field}`);
    }
  });
});
