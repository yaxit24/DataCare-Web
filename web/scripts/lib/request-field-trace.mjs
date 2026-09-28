import ts from 'typescript';

const unwrap = (node) => {
  while (
    node &&
    (ts.isParenthesizedExpression(node) ||
      ts.isAsExpression(node) ||
      ts.isSatisfiesExpression(node) ||
      ts.isNonNullExpression(node) ||
      ts.isAwaitExpression(node))
  )
    node = node.expression;
  return node;
};
const nameOf = (node) =>
  node && (ts.isIdentifier(node) || ts.isStringLiteral(node) || ts.isNumericLiteral(node))
    ? node.text
    : undefined;
const visit = (node, fn) => {
  fn(node);
  ts.forEachChild(node, (child) => visit(child, fn));
};
const prefix = (value, key) => value.map((entry) => ({ ...entry, path: [key, ...entry.path] }));
const get = (value, key) =>
  value.flatMap((entry) =>
    entry.path.length
      ? entry.path[0] === key
        ? [{ ...entry, path: entry.path.slice(1) }]
        : []
      : [{ ...entry, origin: [...entry.origin, key] }],
  );
const scalar = (value) => value.map((entry) => ({ ...entry, path: [] }));
const starts = (value, start) => start.every((part, index) => part === value[index]);
export const formatRequestPath = (parts) => parts.join('.').replaceAll('.[]', '[]');

/** Bounded, syntax-only provenance. No source is executed. Unsupported computed keys and
 * opaque object transforms remain explicit; they are never invented as successful mappings.
 */
function model(text, file = 'source.tsx', entryPoints) {
  const source = ts.createSourceFile(
    file,
    text,
    ts.ScriptTarget.Latest,
    true,
    file.endsWith('x') ? ts.ScriptKind.TSX : ts.ScriptKind.TS,
  );
  const host = ts.createCompilerHost({ noLib: true });
  host.getSourceFile = (requested) => (requested === file ? source : undefined);
  host.fileExists = (requested) => requested === file;
  const program = ts.createProgram([file], { noLib: true, noResolve: true }, host);
  const checker = program.getTypeChecker();
  const symbol = (node) => checker.getSymbolAtLocation(node);
  const references = new Map();
  const diagnostics = new Map();
  const runtime = (node) => {
    for (let at = node; at; at = at.parent)
      if (ts.isTypeNode(at) || ts.isInterfaceDeclaration(at) || ts.isImportDeclaration(at))
        return false;
    return true;
  };
  visit(source, (node) => {
    if (!ts.isIdentifier(node) || !runtime(node)) return;
    const key = symbol(node);
    if (!key || key.declarations?.some((declaration) => declaration.name === node)) return;
    const refs = references.get(key) ?? [];
    refs.push(node);
    references.set(key, refs);
  });
  const unsupported = (node, reason) => {
    const line = source.getLineAndCharacterOfPosition(node.getStart(source)).line + 1;
    diagnostics.set(`${line}:${reason}`, { file, line, reason });
  };
  const declaration = (node) =>
    symbol(node)?.valueDeclaration ??
    symbol(node)?.declarations?.find((item) => !ts.isTypeNode(item));
  const functionOf = (node, seen = new Set()) => {
    node = unwrap(node);
    if (!node || seen.has(node)) return undefined;
    seen = new Set(seen).add(node);
    if (ts.isIdentifier(node)) node = declaration(node);
    if (node && ts.isVariableDeclaration(node)) return functionOf(node.initializer, seen);
    return node && ts.isFunctionLike(node) && node.body ? node : undefined;
  };
  function returns(fn, bindings, seen) {
    if (!ts.isBlock(fn.body)) return evaluate(fn.body, bindings, seen);
    const results = [];
    const walk = (node) => {
      if (node !== fn.body && ts.isFunctionLike(node)) return;
      if (ts.isReturnStatement(node) && node.expression)
        results.push(...evaluate(node.expression, bindings, seen));
      else ts.forEachChild(node, walk);
    };
    walk(fn.body);
    return results;
  }
  function invoke(fn, args, bindings, seen) {
    const next = new Map(bindings);
    fn.parameters.forEach((parameter, index) => {
      if (ts.isIdentifier(parameter.name)) next.set(symbol(parameter.name), args[index] ?? []);
    });
    return returns(fn, next, seen);
  }
  function evaluate(raw, bindings = new Map(), seen = new Set()) {
    const node = unwrap(raw);
    if (!node || seen.has(node)) return [];
    seen = new Set(seen).add(node);
    if (ts.isIdentifier(node)) {
      const key = symbol(node);
      if (bindings.has(key)) return bindings.get(key);
      const decl = declaration(node);
      if (decl && ts.isVariableDeclaration(decl) && decl.initializer)
        return evaluate(decl.initializer, bindings, seen);
      if (decl && ts.isParameter(decl)) {
        const fn = decl.parent;
        const call = fn.parent;
        if (
          ts.isCallExpression(call) &&
          ts.isPropertyAccessExpression(call.expression) &&
          ['map', 'filter', 'flatMap', 'forEach'].includes(call.expression.name.text) &&
          fn.parameters[0] === decl
        )
          return get(evaluate(call.expression.expression, bindings, seen), '[]');
      }
      return node.text === 'undefined' ? [] : [{ path: [], origin: [node.text] }];
    }
    if (ts.isPropertyAccessExpression(node))
      return get(evaluate(node.expression, bindings, seen), node.name.text);
    if (ts.isElementAccessExpression(node)) {
      const key = nameOf(unwrap(node.argumentExpression));
      if (key === undefined || ts.isIdentifier(unwrap(node.argumentExpression))) {
        unsupported(node, 'Dynamic property key cannot be traced statically');
        return [];
      }
      return get(evaluate(node.expression, bindings, seen), key);
    }
    if (ts.isObjectLiteralExpression(node)) {
      const result = [];
      for (const property of node.properties) {
        if (ts.isSpreadAssignment(property))
          result.push(...evaluate(property.expression, bindings, seen));
        else if (ts.isPropertyAssignment(property) || ts.isShorthandPropertyAssignment(property)) {
          const key = nameOf(property.name);
          if (key === undefined) {
            unsupported(property, 'Computed object key cannot be traced statically');
            continue;
          }
          for (let index = result.length - 1; index >= 0; index -= 1)
            if (result[index].path[0] === key) result.splice(index, 1);
          result.push(
            ...prefix(
              evaluate(
                ts.isPropertyAssignment(property) ? property.initializer : property.name,
                bindings,
                seen,
              ),
              key,
            ),
          );
        }
      }
      return result;
    }
    if (ts.isArrayLiteralExpression(node))
      return node.elements.flatMap((item) => prefix(evaluate(item, bindings, seen), '[]'));
    if (ts.isConditionalExpression(node))
      return [
        ...evaluate(node.whenTrue, bindings, seen),
        ...evaluate(node.whenFalse, bindings, seen),
      ];
    if (ts.isBinaryExpression(node))
      return [...evaluate(node.left, bindings, seen), ...evaluate(node.right, bindings, seen)];
    if (ts.isPrefixUnaryExpression(node)) return scalar(evaluate(node.operand, bindings, seen));
    if (ts.isCallExpression(node)) {
      const expression = unwrap(node.expression);
      if (ts.isPropertyAccessExpression(expression)) {
        const method = expression.name.text;
        if (['map', 'flatMap'].includes(method)) {
          const fn = functionOf(node.arguments[0]);
          if (fn) {
            const value = invoke(
              fn,
              [get(evaluate(expression.expression, bindings, seen), '[]')],
              bindings,
              seen,
            );
            return method === 'map' ? prefix(value, '[]') : value;
          }
        }
        if (['filter', 'slice'].includes(method))
          return evaluate(expression.expression, bindings, seen);
        if (['trim', 'toString', 'toUpperCase', 'toLowerCase', 'toFixed'].includes(method))
          return scalar(evaluate(expression.expression, bindings, seen));
      }
      const fn = functionOf(expression);
      const args = node.arguments.map((arg) => evaluate(arg, bindings, seen));
      if (fn) return invoke(fn, args, bindings, seen);
      if (
        ts.isIdentifier(expression) &&
        ['Number', 'String', 'parseInt', 'parseFloat', 'Boolean'].includes(expression.text)
      )
        return scalar(args.flat());
      unsupported(
        node,
        `Opaque call cannot establish an object mapping: ${expression.getText(source)}`,
      );
    }
    return [];
  }
  function used(node, seen = new Set()) {
    if (!node || seen.has(node)) return false;
    seen = new Set(seen).add(node);
    const parent = node.parent;
    if (!parent || !runtime(node)) return false;
    if (ts.isVariableDeclaration(parent) && parent.initializer === node)
      return (references.get(symbol(parent.name)) ?? []).some((ref) => used(ref, seen));
    if (
      ts.isReturnStatement(parent) ||
      ts.isThrowStatement(parent) ||
      ts.isIfStatement(parent) ||
      ts.isSwitchStatement(parent)
    )
      return true;
    if (ts.isCallExpression(parent) || ts.isNewExpression(parent)) return true;
    if (ts.isExpressionStatement(parent))
      return ts.isBinaryExpression(node) || ts.isPostfixUnaryExpression(node);
    if (ts.isArrowFunction(parent) && parent.body === node) return true;
    if (ts.isFunctionLike(parent)) return false;
    return used(parent, seen);
  }
  function reachable(node, seen = new Set()) {
    let fn = node.parent;
    while (fn && !ts.isFunctionLike(fn)) fn = fn.parent;
    if (!fn) return true;
    if (seen.has(fn)) return false;
    seen = new Set(seen).add(fn);
    const owner = ts.isVariableDeclaration(fn.parent) ? fn.parent : fn;
    if (
      fn.modifiers?.some((modifier) => modifier.kind === ts.SyntaxKind.ExportKeyword) &&
      (!entryPoints || entryPoints.includes(nameOf(owner.name)))
    )
      return true;
    if (!owner.name) return reachable(fn, seen);
    return (references.get(symbol(owner.name)) ?? []).some(
      (ref) => used(ref) && reachable(ref, seen),
    );
  }
  return {
    source,
    evaluate,
    unsupported,
    diagnostics,
    used,
    reachable,
    symbol,
    visit: (fn) => visit(source, fn),
  };
}

export function requestFieldMappings(source, fields, file = 'page.tsx') {
  const parsed = model(source, file);
  const mappings = [];
  parsed.visit((node) => {
    if (
      !ts.isCallExpression(node) ||
      !ts.isIdentifier(node.expression) ||
      !['post', 'put', 'patch'].includes(node.expression.text)
    )
      return;
    if (!node.arguments[0] || !ts.isStringLiteral(node.arguments[0])) {
      parsed.unsupported(node, 'Dynamic request endpoint cannot establish a literal route');
      return;
    }
    if (!node.arguments[1]) return;
    for (const entry of parsed.evaluate(node.arguments[1])) {
      const field = entry.origin.at(-1);
      if (fields.includes(field) && entry.path.length)
        mappings.push({
          field,
          method: node.expression.text,
          endpoint: node.arguments[0].text,
          path: entry.path,
          line: parsed.source.getLineAndCharacterOfPosition(node.getStart(parsed.source)).line + 1,
        });
    }
  });
  return { mappings, unsupported: [...parsed.diagnostics.values()] };
}

/** A direct runtime read is still only consumption evidence, not proof that every branch persists.
 * Nested reads additionally retain their alias-expanded path and surrounding output column.
 */
export function writerFieldReads(source, file = 'writer.ts', entryPoints) {
  const parsed = model(source, file, entryPoints);
  const reads = [];
  parsed.visit((node) => {
    if (
      !(ts.isPropertyAccessExpression(node) || ts.isElementAccessExpression(node)) ||
      !parsed.used(node) ||
      !parsed.reachable(node)
    )
      return;
    let property = node.parent;
    while (property && !ts.isPropertyAssignment(property) && !ts.isStatement(property))
      property = property.parent;
    for (const entry of parsed.evaluate(node)) {
      if (entry.path.length || entry.origin.length < 2) continue;
      reads.push({
        field: entry.origin.at(-1),
        path: entry.origin.slice(1),
        column: property && ts.isPropertyAssignment(property) ? nameOf(property.name) : undefined,
        file,
        line: parsed.source.getLineAndCharacterOfPosition(node.getStart(parsed.source)).line + 1,
      });
    }
  });
  return { reads, unsupported: [...parsed.diagnostics.values()] };
}

/** Follow only named imports actually called by reachable runtime code. Reading every export in
 * an imported sibling can credit an unrelated writer with the same leaf field. Imported aliases
 * retain the original export name so the next file's reachability starts at the right function.
 * Namespace dispatch and opaque callback invocation do not establish a called export here.
 */
export function writerImportedCalls(source, file = 'writer.ts', entryPoints) {
  const parsed = model(source, file, entryPoints);
  const imports = new Map();
  for (const node of parsed.source.statements) {
    if (
      !ts.isImportDeclaration(node) ||
      !ts.isStringLiteral(node.moduleSpecifier) ||
      !node.moduleSpecifier.text.startsWith('.') ||
      node.importClause?.isTypeOnly
    )
      continue;
    const bindings = node.importClause?.namedBindings;
    if (bindings && ts.isNamedImports(bindings)) {
      for (const item of bindings.elements) {
        if (item.isTypeOnly) continue;
        imports.set(parsed.symbol(item.name), {
          module: node.moduleSpecifier.text,
          imported: item.propertyName?.text ?? item.name.text,
          local: item.name.text,
        });
      }
    }
  }
  const calls = new Map();
  parsed.visit((node) => {
    if (!ts.isCallExpression(node) || !parsed.reachable(node)) return;
    const callee = unwrap(node.expression);
    if (!ts.isIdentifier(callee)) return;
    const imported = imports.get(parsed.symbol(callee));
    if (!imported) return;
    calls.set(`${imported.module}:${imported.imported}`, {
      ...imported,
      file,
      line: parsed.source.getLineAndCharacterOfPosition(node.getStart(parsed.source)).line + 1,
    });
  });
  return { calls: [...calls.values()] };
}

/** Prove the literal endpoint reaches an import from the selected writer and forwards the path.
 * This covers local input-builder functions and aliases; it does not infer dynamic dispatch.
 */
export function routeFieldForwarding(source, mapping, writerRelativePath, file = 'routes.ts') {
  const parsed = model(source, file);
  const writers = new Map();
  for (const statement of parsed.source.statements) {
    if (
      !ts.isImportDeclaration(statement) ||
      !ts.isStringLiteral(statement.moduleSpecifier) ||
      !statement.moduleSpecifier.text
        .replace(/\.js$/, '.ts')
        .endsWith(`/modules/${writerRelativePath}`) ||
      statement.importClause?.isTypeOnly
    )
      continue;
    const names = statement.importClause?.namedBindings;
    if (names && ts.isNamedImports(names))
      for (const item of names.elements)
        if (!item.isTypeOnly)
          writers.set(item.name.text, item.propertyName?.text ?? item.name.text);
  }
  const forwards = [];
  parsed.visit((node) => {
    if (
      !ts.isCallExpression(node) ||
      !ts.isPropertyAccessExpression(node.expression) ||
      node.expression.name.text !== mapping.method ||
      !ts.isStringLiteral(node.arguments[0]) ||
      node.arguments[0].text !== mapping.endpoint
    )
      return;
    for (const handler of node.arguments.slice(1)) {
      const fn = unwrap(handler);
      if (!ts.isFunctionLike(fn) || !fn.parameters[0] || !ts.isIdentifier(fn.parameters[0].name))
        continue;
      const bindings = new Map([
        [parsed.symbol(fn.parameters[0].name), [{ path: [], origin: ['$request'] }]],
      ]);
      visit(handler, (call) => {
        if (
          !ts.isCallExpression(call) ||
          !ts.isIdentifier(call.expression) ||
          !writers.has(call.expression.text)
        )
          return;
        for (const argument of call.arguments)
          for (const entry of parsed.evaluate(argument, bindings)) {
            const sourcePath =
              entry.origin[0] === '$request' && entry.origin[1] === 'body'
                ? entry.origin.slice(2)
                : undefined;
            if (sourcePath && starts(mapping.path, sourcePath))
              forwards.push({
                writer: writers.get(call.expression.text),
                path: [...entry.path, ...mapping.path.slice(sourcePath.length)],
                line:
                  parsed.source.getLineAndCharacterOfPosition(call.getStart(parsed.source)).line +
                  1,
              });
          }
      });
    }
  });
  return { forwards, unsupported: [...parsed.diagnostics.values()] };
}

export function traceNestedField({
  pageSource,
  routeSource,
  writerSources,
  writerRelativePath,
  field,
}) {
  const request = requestFieldMappings(pageSource, [field]);
  const traces = [];
  const unsupported = [...request.unsupported];
  for (const mapping of request.mappings) {
    const route = routeFieldForwarding(routeSource, mapping, writerRelativePath);
    unsupported.push(...route.unsupported);
    for (const forwarding of route.forwards) {
      const candidates = writerSources.flatMap(({ source, file }) => {
        const result = writerFieldReads(source, file, [forwarding.writer]);
        unsupported.push(...result.unsupported);
        return result.reads;
      });
      for (const read of candidates)
        if (formatRequestPath(read.path) === formatRequestPath(forwarding.path))
          traces.push({ ...mapping, forwarding, read });
    }
  }
  return { traces, unsupported };
}
