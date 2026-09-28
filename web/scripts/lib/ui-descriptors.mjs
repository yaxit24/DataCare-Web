import ts from 'typescript';
import { existsSync, readFileSync, readdirSync, statSync } from 'node:fs';
import { dirname, join, relative, resolve } from 'node:path';

const UNKNOWN = Symbol('unknown');
const inputTags = new Set(['input', 'select', 'textarea', 'LookupPicker', 'BookSelect']);
const unwrap = (node) => {
  while (
    node &&
    (ts.isParenthesizedExpression(node) ||
      ts.isAsExpression(node) ||
      ts.isSatisfiesExpression(node) ||
      ts.isNonNullExpression(node))
  )
    node = node.expression;
  return node;
};
const nameOf = (node) =>
  node && (ts.isIdentifier(node) || ts.isStringLiteral(node)) ? node.text : null;

/** Static descriptor provenance, not execution or persistence coverage.
 * Only descriptors reached from a rendered map are followed. Function returns, literal
 * boolean selector arguments, local aliases and relative imports are supported. A filter
 * or flatMap with dynamic visibility contributes conditional candidates, never a claim
 * that every candidate is visible in the current business configuration.
 */
export function descriptorScanner(workspaceRoot) {
  const root = resolve(workspaceRoot);
  const modules = new Map();
  function moduleOf(file) {
    file = resolve(file);
    if (modules.has(file)) return modules.get(file);
    const source = ts.createSourceFile(
      file,
      readFileSync(file, 'utf8'),
      ts.ScriptTarget.Latest,
      true,
      file.endsWith('.tsx') ? ts.ScriptKind.TSX : ts.ScriptKind.TS,
    );
    const module = { file, source, bindings: new Map(), imports: new Map(), defaultNode: null };
    modules.set(file, module);
    for (const statement of source.statements) {
      if (ts.isImportDeclaration(statement) && ts.isStringLiteral(statement.moduleSpecifier)) {
        const spec = statement.moduleSpecifier.text;
        if (!spec.startsWith('.') || statement.importClause?.isTypeOnly) continue;
        const base = resolve(dirname(file), spec.replace(/\.js$/, ''));
        const target = [
          base,
          `${base}.ts`,
          `${base}.tsx`,
          join(base, 'index.ts'),
          join(base, 'index.tsx'),
        ].find((candidate) => existsSync(candidate) && statSync(candidate).isFile());
        if (!target) continue;
        const clause = statement.importClause;
        if (clause?.name) module.imports.set(clause.name.text, { target, name: 'default' });
        if (clause?.namedBindings && ts.isNamedImports(clause.namedBindings)) {
          for (const binding of clause.namedBindings.elements)
            if (!binding.isTypeOnly)
              module.imports.set(binding.name.text, {
                target,
                name: binding.propertyName?.text ?? binding.name.text,
              });
        }
      }
      if (ts.isVariableStatement(statement))
        for (const declaration of statement.declarationList.declarations)
          if (ts.isIdentifier(declaration.name))
            module.bindings.set(declaration.name.text, declaration.initializer);
      if (ts.isFunctionDeclaration(statement) && statement.name)
        module.bindings.set(statement.name.text, statement);
      if (statement.modifiers?.some((modifier) => modifier.kind === ts.SyntaxKind.DefaultKeyword))
        module.defaultNode = statement;
      if (ts.isExportAssignment(statement)) module.defaultNode = statement.expression;
    }
    return module;
  }
  function binding(name, context) {
    if (context.locals?.has(name)) return { node: context.locals.get(name), context };
    if (context.module.bindings.has(name))
      return {
        node: context.module.bindings.get(name),
        context: { ...context, locals: new Map(), params: new Map() },
      };
    const imported = context.module.imports.get(name);
    if (imported) {
      const module = moduleOf(imported.target);
      return {
        node: imported.name === 'default' ? module.defaultNode : module.bindings.get(imported.name),
        context: { module, locals: new Map(), params: new Map() },
      };
    }
    return null;
  }
  function literal(node, context) {
    node = unwrap(node);
    if (!node) return UNKNOWN;
    if (ts.isStringLiteralLike(node)) return node.text;
    if (node.kind === ts.SyntaxKind.TrueKeyword) return true;
    if (node.kind === ts.SyntaxKind.FalseKeyword) return false;
    if (ts.isIdentifier(node) && context.params?.has(node.text))
      return context.params.get(node.text);
    if (ts.isPrefixUnaryExpression(node) && node.operator === ts.SyntaxKind.ExclamationToken) {
      const value = literal(node.operand, context);
      return value === UNKNOWN ? UNKNOWN : !value;
    }
    return UNKNOWN;
  }
  function contextFor(fn, context, args = []) {
    const locals = new Map();
    const params = new Map();
    for (let i = 0; i < fn.parameters.length; i++) {
      const parameter = fn.parameters[i];
      if (ts.isIdentifier(parameter.name))
        params.set(parameter.name.text, args[i] ?? literal(parameter.initializer, context));
    }
    function visit(node) {
      if (node !== fn.body && ts.isFunctionLike(node)) return;
      if (ts.isVariableDeclaration(node) && ts.isIdentifier(node.name))
        locals.set(node.name.text, node.initializer);
      ts.forEachChild(node, visit);
    }
    if (fn.body) visit(fn.body);
    return { ...context, locals, params };
  }
  const origin = (node, context) => ({
    file: relative(root, context.module.file),
    line: context.module.source.getLineAndCharacterOfPosition(node.getStart()).line + 1,
  });
  function trace(node, context, seen = new Set()) {
    node = unwrap(node);
    if (!node)
      return { fields: [], conditions: [], unsupported: ['Missing descriptor expression'] };
    const id = `${context.module.file}:${node.kind}:${node.pos}:${node.end}:${[...(context.params ?? [])].map(([key, value]) => `${key}=${String(value)}`).join(',')}`;
    if (seen.has(id))
      return { fields: [], conditions: [], unsupported: ['Cyclic descriptor dependency'] };
    seen = new Set(seen).add(id);
    const empty = () => ({ fields: [], conditions: [], unsupported: [] });
    const merge = (parts) => ({
      fields: parts.flatMap((part) => part.fields),
      conditions: [...new Set(parts.flatMap((part) => part.conditions))],
      unsupported: [...new Set(parts.flatMap((part) => part.unsupported))],
    });
    if (ts.isIdentifier(node)) {
      const resolved = binding(node.text, context);
      return resolved
        ? trace(resolved.node, resolved.context, seen)
        : { ...empty(), unsupported: [`Unresolved binding ${node.text}`] };
    }
    if (ts.isArrayLiteralExpression(node)) {
      const parts = [];
      for (const element of node.elements) {
        if (ts.isSpreadElement(element)) {
          parts.push(trace(element.expression, context, seen));
          continue;
        }
        const entry = unwrap(element);
        let key,
          label,
          identity = false;
        if (ts.isArrayLiteralExpression(entry) && entry.elements.length === 2) {
          key = literal(entry.elements[0], context);
          label = literal(entry.elements[1], context);
        } else if (ts.isObjectLiteralExpression(entry)) {
          const properties = new Map(
            entry.properties
              .filter(ts.isPropertyAssignment)
              .map((property) => [nameOf(property.name), property.initializer]),
          );
          key = literal(properties.get('key'), context);
          label = literal(properties.get('label'), context);
          identity = literal(properties.get('identity'), context) === true;
        }
        if (typeof key === 'string' && typeof label === 'string')
          parts.push({ ...empty(), fields: [{ key, label, identity, ...origin(entry, context) }] });
        else
          parts.push({
            ...empty(),
            unsupported: [
              `Nonliteral descriptor at ${origin(entry, context).file}:${origin(entry, context).line}`,
            ],
          });
      }
      return merge(parts);
    }
    if (ts.isConditionalExpression(node)) {
      const condition = literal(node.condition, context);
      if (condition !== UNKNOWN)
        return trace(condition ? node.whenTrue : node.whenFalse, context, seen);
      const result = merge([
        trace(node.whenTrue, context, seen),
        trace(node.whenFalse, context, seen),
      ]);
      result.conditions.push(`Unresolved selector: ${node.condition.getText()}`);
      return result;
    }
    if (ts.isCallExpression(node) && ts.isIdentifier(node.expression)) {
      const resolved = binding(node.expression.text, context);
      const fn = resolved && unwrap(resolved.node);
      if (fn && ts.isFunctionLike(fn) && fn.body) {
        const fnContext = contextFor(
          fn,
          resolved.context,
          node.arguments.map((argument) => literal(argument, context)),
        );
        if (!ts.isBlock(fn.body)) return trace(fn.body, fnContext, seen);
        const returns = fn.body.statements.filter(ts.isReturnStatement);
        if (returns.length === 1) return trace(returns[0].expression, fnContext, seen);
      }
    }
    if (
      ts.isCallExpression(node) &&
      ts.isPropertyAccessExpression(node.expression) &&
      ['filter', 'flatMap'].includes(node.expression.name.text)
    ) {
      const callback = node.arguments[0];
      if (callback && (ts.isArrowFunction(callback) || ts.isFunctionExpression(callback))) {
        const body = unwrap(callback.body);
        // An unconditional empty result/false filter renders no descriptors.
        const returns = ts.isBlock(body)
          ? body.statements.filter(ts.isReturnStatement)
          : [{ expression: body }];
        if (
          returns.length === 1 &&
          ((ts.isArrayLiteralExpression(unwrap(returns[0].expression)) &&
            unwrap(returns[0].expression).elements.length === 0) ||
            literal(returns[0].expression, context) === false)
        )
          return empty();
        const parameter = callback.parameters[0]?.name;
        const preservesItem =
          parameter &&
          ts.isIdentifier(parameter) &&
          returns.some((returned) => {
            const value = unwrap(returned.expression);
            return (
              value &&
              ts.isArrayLiteralExpression(value) &&
              value.elements.length > 0 &&
              value.elements.every((element) => {
                element = unwrap(element);
                if (ts.isIdentifier(element)) return element.text === parameter.text;
                if (!ts.isObjectLiteralExpression(element)) return false;
                const spreads = element.properties.filter(ts.isSpreadAssignment);
                return (
                  spreads.length === 1 &&
                  nameOf(spreads[0].expression) === parameter.text &&
                  element.properties.every(
                    (property) =>
                      ts.isSpreadAssignment(property) ||
                      (ts.isPropertyAssignment(property) && nameOf(property.name) === 'label'),
                  )
                );
              })
            );
          });
        if (node.expression.name.text === 'filter' || preservesItem) {
          const result = trace(node.expression.expression, context, seen);
          result.conditions.push(
            `Runtime ${node.expression.name.text} visibility/labels at ${origin(node, context).file}:${origin(node, context).line}`,
          );
          return result;
        }
      }
    }
    return {
      ...empty(),
      unsupported: [
        `Unsupported descriptor expression at ${origin(node, context).file}:${origin(node, context).line}: ${ts.SyntaxKind[node.kind]}`,
      ],
    };
  }
  function analyzePage(file) {
    const uses = [];
    const rendered = new Set();
    function render(node, context) {
      node = unwrap(node);
      if (!node) return;
      if (ts.isIdentifier(node)) {
        const resolved = binding(node.text, context);
        if (resolved) render(resolved.node, resolved.context);
        return;
      }
      if (!ts.isFunctionLike(node) || !node.body) return;
      const id = `${context.module.file}:${node.pos}`;
      if (rendered.has(id)) return;
      rendered.add(id);
      const scoped = contextFor(node, context);
      function walk(child, renderConditions = []) {
        if (ts.isFunctionLike(child)) return;
        if (ts.isConditionalExpression(child)) {
          const condition = literal(child.condition, scoped);
          if (condition !== UNKNOWN)
            walk(condition ? child.whenTrue : child.whenFalse, renderConditions);
          else {
            const conditions = [
              ...renderConditions,
              `Conditional render: ${child.condition.getText()}`,
            ];
            walk(child.whenTrue, conditions);
            walk(child.whenFalse, conditions);
          }
          return;
        }
        if (
          ts.isBinaryExpression(child) &&
          [ts.SyntaxKind.AmpersandAmpersandToken, ts.SyntaxKind.BarBarToken].includes(
            child.operatorToken.kind,
          )
        ) {
          const value = literal(child.left, scoped);
          walk(child.left, renderConditions);
          if (value === UNKNOWN)
            walk(child.right, [...renderConditions, `Conditional render: ${child.left.getText()}`]);
          else if (
            (child.operatorToken.kind === ts.SyntaxKind.AmpersandAmpersandToken && value) ||
            (child.operatorToken.kind === ts.SyntaxKind.BarBarToken && !value)
          )
            walk(child.right, renderConditions);
          return;
        }
        if (
          ts.isCallExpression(child) &&
          ts.isPropertyAccessExpression(child.expression) &&
          child.expression.name.text === 'map'
        ) {
          const callback = child.arguments[0];
          if (callback && (ts.isArrowFunction(callback) || ts.isFunctionExpression(callback))) {
            const surface = { grid: false, input: false, readOnlyStates: [] };
            function inspect(current) {
              if (current !== callback && ts.isFunctionLike(current)) return;
              if (ts.isJsxOpeningElement(current) || ts.isJsxSelfClosingElement(current)) {
                const tag = current.tagName.getText();
                if (tag === 'th') surface.grid = true;
                if (inputTags.has(tag)) {
                  let bound = false;
                  let readOnly = false;
                  for (const attribute of current.attributes.properties) {
                    if (
                      ts.isJsxAttribute(attribute) &&
                      ['value', 'checked', 'defaultValue'].includes(attribute.name.text) &&
                      attribute.initializer?.getText().includes('[')
                    )
                      bound = true;
                    if (ts.isJsxAttribute(attribute) && attribute.name.text === 'readOnly') {
                      readOnly = attribute.initializer
                        ? literal(attribute.initializer.expression, scoped)
                        : true;
                      // This descriptor flag is classified separately for each candidate below.
                      if (
                        readOnly === UNKNOWN &&
                        attribute.initializer.getText().match(/^\{\w+\.identity\}$/)
                      )
                        readOnly = false;
                    }
                  }
                  if (bound) {
                    surface.input = true;
                    surface.readOnlyStates.push(readOnly);
                  }
                }
              }
              ts.forEachChild(current, inspect);
            }
            inspect(callback);
            if (surface.grid || surface.input) {
              const result = trace(child.expression.expression, scoped);
              uses.push({
                ...origin(child, scoped),
                expression: child.expression.expression.getText(),
                grid: surface.grid,
                input: surface.input,
                readOnly: surface.readOnlyStates.includes(UNKNOWN)
                  ? 'unknown'
                  : surface.readOnlyStates.length > 0 && surface.readOnlyStates.every(Boolean),
                ...result,
                conditions: [...new Set([...result.conditions, ...renderConditions])],
              });
            }
            walk(callback.body, renderConditions);
          }
          return;
        }
        if (ts.isJsxOpeningElement(child) || ts.isJsxSelfClosingElement(child)) {
          const tag = child.tagName;
          if (ts.isIdentifier(tag) && /^[A-Z]/.test(tag.text)) {
            const resolved = binding(tag.text, scoped);
            if (resolved) render(resolved.node, resolved.context);
          }
        }
        ts.forEachChild(child, (descendant) => walk(descendant, renderConditions));
      }
      // Only returned JSX is a rendering root; dead helper functions and unused imports do not count.
      if (ts.isBlock(node.body)) {
        for (const statement of node.body.statements)
          if (ts.isReturnStatement(statement) && statement.expression) walk(statement.expression);
      } else walk(node.body);
    }
    const module = moduleOf(file);
    render(module.defaultNode, { module, locals: new Map(), params: new Map() });
    const fields = new Map();
    for (const use of uses)
      for (const field of use.fields) {
        const id = `${field.file}:${field.line}:${field.key}`;
        const previous = fields.get(id);
        const access = field.identity
          ? 'identity'
          : use.input
            ? use.readOnly === 'unknown'
              ? 'unknown'
              : use.readOnly
                ? 'display-only'
                : 'editable-candidate'
            : 'display-only';
        fields.set(id, {
          ...field,
          grid: !!previous?.grid || use.grid,
          input: !!previous?.input || use.input,
          access: previous?.access === 'editable-candidate' ? previous.access : access,
          conditional: !!previous?.conditional || use.conditions.length > 0,
        });
      }
    return { page: relative(root, file), fields: [...fields.values()], uses };
  }
  return { analyzePage };
}

export function measureUiDescriptors(workspaceRoot) {
  const root = resolve(workspaceRoot);
  const scanner = descriptorScanner(root);
  const pages = [];
  function discover(directory) {
    for (const entry of readdirSync(directory, { withFileTypes: true })) {
      const file = join(directory, entry.name);
      if (entry.isDirectory()) discover(file);
      else if (entry.name === 'page.tsx') pages.push(scanner.analyzePage(file));
    }
  }
  discover(join(root, 'apps/web/app'));
  const union = new Map();
  for (const page of pages)
    for (const field of page.fields) {
      const id = `${field.file}:${field.line}:${field.key}`;
      const previous = union.get(id);
      union.set(id, {
        ...field,
        grid: field.grid || !!previous?.grid,
        input: field.input || !!previous?.input,
        conditional: field.conditional || !!previous?.conditional,
      });
    }
  const fields = [...union.values()];
  return {
    kind: 'datacare.ui-descriptor-surface/1.0',
    basis:
      'Additive static descriptor candidates reached from returned JSX maps; historical heuristic counters and budgets unchanged',
    totals: {
      discoveredPages: pages.length,
      pagesWithDescriptorCandidates: pages.filter((page) => page.fields.length).length,
      distinctDescriptorCandidates: fields.length,
      gridCandidates: fields.filter((field) => field.grid).length,
      inputCandidates: fields.filter((field) => field.input).length,
      identityCandidates: fields.filter((field) => field.identity).length,
      editableInputCandidates: fields.filter((field) => field.access === 'editable-candidate')
        .length,
      conditionalCandidates: fields.filter((field) => field.conditional).length,
      unsupportedConsumers: pages.reduce(
        (sum, page) => sum + page.uses.filter((use) => use.unsupported.length).length,
        0,
      ),
    },
    pages: pages.filter((page) => page.uses.length),
    limits:
      'Candidate field origins only. Conditional configuration, generic props, indirect/re-exported factories and unsupported expressions require further tracing. No route, writer, reader, persistence, runtime visibility or functional parity is certified. Do not add these candidates to the historical totals: overlap is intentional and un-reconciled.',
  };
}
