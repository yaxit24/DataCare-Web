import ts from 'typescript';

/**
 * SQL raw-interpolation safety (N94 / G79, SP03).
 *
 * The codebase passes VALUES to `$queryRawUnsafe`/`$executeRawUnsafe` as parameterized `$n` placeholders and
 * only ever interpolates IDENTIFIERS and pre-built SQL FRAGMENTS into the template (SECURITY-REVIEW.md §6):
 * there was no static rule enforcing that. This checker is that rule.
 *
 * Deciding "is this interpolation a SQL fragment or an unescaped value?" purely by the variable's NAME is
 * whack-a-mole — the codebase names fragments freely (branchWhere, sqlProjection, keyColumn, …). So the rule
 * is framed around the ACTUAL injection vector the review names: a value that originates from the HTTP
 * request reaching a SQL template. It flags any interpolation whose expression references a request/input
 * root (`req`, `request`, `reply`, `body`, `query`, `rawBody`, `headers`, `cookies`, `params` used as a
 * value), or string concatenation that mixes such a value into SQL text. Server-derived identifiers,
 * `$n`-bind indices, SQL-fragment variables and the identifier sanitizers all pass — values must travel as
 * `$n` parameters, never interpolated.
 *
 * The allow-list of SQL builders is kept explicit so the vetted boundary is documented and a new builder is a
 * visible, reviewed change; it is only consulted to short-circuit a call that would otherwise look like a
 * request reference (it never overrides a genuine request-root interpolation).
 */

/** SQL-builder and identifier-sanitizer helpers whose RESULT is SQL text, never an unescaped value. */
export const SQL_BUILDER_CALLS = new Set([
  'quoteIdent',
  'quoteIdentifier',
  'assertSafeIdent',
  'isSafeIdent',
  'n',
  'NN',
  'VAL',
  'S',
  'q',
  'qcol',
  'qid',
  'col',
  'colSql',
  'fineExpr',
  'voucherKeyWhere',
  'barTagAvailableSql',
  'mfgMetalBalance',
  'recordSql',
  'orderBy',
]);

/** HTTP-request / input roots. A value reachable from any of these must travel as a `$n` parameter. */
const REQUEST_ROOT =
  /^(?:req|request|reply|res|response|rawBody|rawRequest|headers|cookies|searchParams)$/;
/** `body`/`query`/`params`/`input` are request roots only when used as a VALUE (member or element access). */
const REQUEST_VALUE_ROOT = /^(?:body|query|params|input|payload|userInput|formData)$/;

/** The left-most identifier a member/element/call chain reads from (e.g. `req.body.x` → `req`). */
function rootIdentifier(expr) {
  let node = expr;
  for (;;) {
    if (ts.isPropertyAccessExpression(node) || ts.isElementAccessExpression(node)) {
      node = node.expression;
    } else if (ts.isCallExpression(node)) {
      node = node.expression;
    } else if (ts.isNonNullExpression(node) || ts.isParenthesizedExpression(node)) {
      node = node.expression;
    } else break;
  }
  return ts.isIdentifier(node) ? node.text : null;
}

/** Does this expression read a value out of the HTTP request / input? */
function referencesRequestValue(expr) {
  let found = false;
  const walk = (node) => {
    if (found) return;
    const root =
      ts.isPropertyAccessExpression(node) || ts.isElementAccessExpression(node)
        ? rootIdentifier(node)
        : null;
    if (root) {
      if (REQUEST_ROOT.test(root)) found = true;
      // `body`/`query`/`params`/`input` are request values when something is read OUT of them
      // (`input.key`), but `params.length` is a bind-index count, which is safe.
      else if (REQUEST_VALUE_ROOT.test(root)) {
        const text = node.getText();
        if (!/\.length\b/.test(text)) found = true;
      }
    }
    if (!found) ts.forEachChild(node, walk);
  };
  walk(expr);
  return found;
}

const calleeName = (expr) => {
  if (ts.isIdentifier(expr)) return expr.text;
  if (ts.isPropertyAccessExpression(expr)) return expr.name.text;
  return '';
};

/** Is this interpolated expression safe (not an unescaped request/input value)? */
function isSafeInterpolation(expr, precededByDollar) {
  // `…$${expr}` builds a bind PLACEHOLDER index ($1, $2, …); the value itself travels as a parameter.
  if (precededByDollar) return true;
  if (ts.isParenthesizedExpression(expr)) return isSafeInterpolation(expr.expression, false);
  // A nested string / template literal is a SQL fragment the caller assembled; check ITS own spans by
  // the same rule (a `$${…}` inside it is a placeholder index; a request value inside it is still unsafe).
  if (ts.isStringLiteralLike(expr) || ts.isNoSubstitutionTemplateLiteral(expr)) return true;
  if (ts.isTemplateExpression(expr)) {
    return expr.templateSpans.every((span, i) => {
      const before = i === 0 ? expr.head.text : expr.templateSpans[i - 1].literal.text;
      return isSafeInterpolation(span.expression, /\$$/.test(before));
    });
  }
  if (ts.isConditionalExpression(expr)) {
    return isSafeInterpolation(expr.whenTrue, false) && isSafeInterpolation(expr.whenFalse, false);
  }
  // A call to a vetted SQL builder / sanitizer always yields SQL text.
  if (ts.isCallExpression(expr) && SQL_BUILDER_CALLS.has(calleeName(expr.expression))) return true;
  // The real rule: reject anything that reads a value out of the HTTP request / input.
  return !referencesRequestValue(expr);
}

const RAW_UNSAFE = new Set(['$queryRawUnsafe', '$executeRawUnsafe']);

/** The SQL text that appears immediately before a template span (the preceding literal). */
function literalBefore(template, spanIndex) {
  if (spanIndex === 0) return template.head.text;
  return template.templateSpans[spanIndex - 1].literal.text;
}

/**
 * Walk a parsed source file and return findings for raw-unsafe SQL templates that interpolate a value read
 * from the HTTP request / input rather than binding it as a `$n` parameter. `line` is 1-based.
 */
export function findUnsafeSqlInterpolations(source) {
  const findings = [];
  const visit = (node) => {
    if (
      ts.isCallExpression(node) &&
      ts.isPropertyAccessExpression(node.expression) &&
      RAW_UNSAFE.has(node.expression.name.text)
    ) {
      const first = node.arguments[0];
      if (first && ts.isTemplateExpression(first)) {
        first.templateSpans.forEach((span, i) => {
          const before = literalBefore(first, i);
          const precededByDollar = /\$$/.test(before);
          if (!isSafeInterpolation(span.expression, precededByDollar)) {
            const line =
              source.getLineAndCharacterOfPosition(span.expression.getStart(source)).line + 1;
            findings.push({
              line,
              expr: span.expression.getText(source).slice(0, 80),
              method: node.expression.name.text,
            });
          }
        });
      }
    }
    ts.forEachChild(node, visit);
  };
  visit(source);
  return findings;
}
