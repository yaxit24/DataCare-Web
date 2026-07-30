import ts from 'typescript';

const SENSITIVE_NAME =
  /(?:password|passwd|pwd|secret|api[_-]?key|access[_-]?token|auth[_-]?token|private[_-]?key)/i;
const PLACEHOLDER =
  /^(?:test(?:[-_ ]|$)|example(?:[-_ ]|$)|dummy(?:[-_ ]|$)|fake(?:[-_ ]|$)|placeholder|change[-_ ]?me|dev[-_ ])/i;

const nameText = (node) => {
  if (!node) return '';
  if (ts.isIdentifier(node) || ts.isPrivateIdentifier(node)) return node.text;
  if (ts.isStringLiteralLike(node) || ts.isNumericLiteral(node)) return node.text;
  if (ts.isPropertyAccessExpression(node)) return node.name.text;
  if (ts.isElementAccessExpression(node) && ts.isStringLiteralLike(node.argumentExpression)) {
    return node.argumentExpression.text;
  }
  return '';
};

const literalText = (node) => {
  if (ts.isStringLiteralLike(node) || ts.isNoSubstitutionTemplateLiteral(node)) return node.text;
  return null;
};

export function isPlausibleSecretValue(value) {
  const text = String(value).trim();
  if (text.length < 8) return false;
  if (PLACEHOLDER.test(text) || /^<[^>]+>$/.test(text) || /^\$\{[^}]+\}$/.test(text)) return false;
  // Prose, not a credential. A secret is a single opaque token; it does not read as a sentence.
  // This matters because desktop-parity UI messages legitimately live under names like
  // OLD_PASSWORD_REQUIRED ('Please Insert Old Password'). Two or more spaces AND no non-word
  // characters typical of encoded secrets is a safe discriminator: any value containing base64/hex
  // padding, separators or URL syntax is still reported even when it contains spaces.
  // Desktop messages routinely end in runs of dots ('...Then Try...'), so trailing punctuation is
  // stripped before judging. A lone dot run is not a secret signal; separators like :// _- += are.
  const prose = text.replace(/[.\s]+$/, '');
  const words = prose.split(/\s+/);
  const looksEncoded = /[=/+_\-:]{2,}|[A-Za-z0-9+/]{24,}/.test(prose);
  if (words.length >= 3 && !looksEncoded && /^[A-Za-z][A-Za-z\s.,'!?]*$/.test(prose)) return false;
  return true;
}

export function findPlausibleSecretLiterals(text, fileName = 'source.ts') {
  const kind = fileName.endsWith('.tsx')
    ? ts.ScriptKind.TSX
    : fileName.endsWith('.ts')
      ? ts.ScriptKind.TS
      : ts.ScriptKind.JS;
  const source = ts.createSourceFile(fileName, text, ts.ScriptTarget.Latest, true, kind);
  const findings = [];

  const add = (nameNode, valueNode) => {
    const name = nameText(nameNode);
    const value = literalText(valueNode);
    if (!SENSITIVE_NAME.test(name) || value === null || !isPlausibleSecretValue(value)) return;
    const { line, character } = source.getLineAndCharacterOfPosition(valueNode.getStart(source));
    findings.push({
      line: line + 1,
      column: character + 1,
      name,
      message: `plausible secret literal assigned to ${name}; read it from environment or secret storage`,
    });
  };

  const inspect = (node) => {
    if (ts.isVariableDeclaration(node) && node.initializer) add(node.name, node.initializer);
    if (ts.isPropertyAssignment(node)) add(node.name, node.initializer);
    if (ts.isBinaryExpression(node) && node.operatorToken.kind === ts.SyntaxKind.EqualsToken) {
      add(node.left, node.right);
    }
    ts.forEachChild(node, inspect);
  };
  inspect(source);
  return findings;
}
