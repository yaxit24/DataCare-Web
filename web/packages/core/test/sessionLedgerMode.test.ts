import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import {
  SESSION_LEDGER_MODE_VERSION,
  bootstrapSessionLedgerMode,
  transitionSessionLedgerMode,
} from '../src/sessionLedgerMode.js';

type Mode = 'A' | 'B' | 'C';
type Edition = 'L' | 'B' | 'S' | 'U' | 'P' | 'A' | 'E';
type Raw = { CO_CODE: string | null; CON_CODE: string | null; CON_NAME: string | null };
const bytes = readFileSync(new URL('./fixtures/session-ledger-mode.v1.json', import.meta.url));
const vectors = JSON.parse(bytes.toString()) as {
  bootstrap: Array<{
    id: string;
    bootstrapEdition: Edition | null;
    forceCombinedException: boolean | null;
    completedOpen: boolean | null;
    expected: { status: 'resolved' | 'unresolved'; mode: Mode | null };
  }>;
  catalogs: Record<string, Raw[]>;
  commands: Array<{
    id: string;
    commandEdition: Edition | null;
    previousMode: Mode;
    kind: 'special-letter' | 'general-alias';
    value: string;
    catalog: string;
    expected: { decision: 'assigned' | 'retained' | 'unsupported'; mode: Mode };
  }>;
};

const profile = 'trusted-bootstrap-and-commands-abc-v1';
const context = {
  tenantId: 'mode-fixture',
  coCode: '02',
  lcCode: '03',
  coYear: '2024-2025',
  identity: 'context-epoch-17',
};
function known<T>(value: T, revision = 'fact-revision-1') {
  return { status: 'known' as const, value, revision };
}
function unknown(reason = 'Trusted fact unavailable.', revision = 'unavailable-revision-1') {
  return { status: 'unknown' as const, reason, revision };
}
function fact<T>(value: T | null, revision: string) {
  return value === null ? unknown('Trusted fact unavailable.', revision) : known(value, revision);
}
function bootstrapInput(edition: Edition = 'A') {
  return {
    context: { ...context },
    completed: known(true, 'completed-1'),
    edition: known(edition, 'bootstrap-edition-1'),
    forceCombined: known(false, 'exception-1'),
  };
}
function catalog(rows: readonly Raw[] = []) {
  return {
    company: '01',
    complete: true,
    revision: 'catalog-observation-7',
    rows: rows.map((raw, index) => ({
      identity: 'physical-row-' + (index + 1),
      revision: 'row-revision-' + (index + 1),
      raw: { ...raw },
    })),
  };
}
function previous(mode: Mode = 'B') {
  const bootstrap = bootstrapInput(mode === 'C' ? 'L' : 'A');
  const initialMode = mode === 'C' ? 'C' : 'A';
  const history =
    mode === 'B'
      ? [
          {
            commandEdition: known('A', 'old-command-edition'),
            command: { kind: 'special', letter: 'B' },
            catalog: catalog(),
            previousMode: 'A',
            nextMode: 'B',
            outcome: 'applied',
            branch: 'direct-special',
          },
        ]
      : [];
  return {
    version: 'session-ledger-mode-semantic-v1',
    profile,
    context: bootstrap.context,
    status: 'resolved',
    mode: initialMode === 'A' && mode === 'B' ? 'B' : initialMode,
    reason: null,
    bootstrap: {
      completed: bootstrap.completed,
      edition: bootstrap.edition,
      forceCombined: bootstrap.forceCombined,
    },
    history,
  };
}
function unresolvedPrevious(completed = true) {
  // Obtain the validated provenance-derived reason, while independently
  // asserting the source-defined unresolved/null baseline before any command.
  const result = bootstrapSessionLedgerMode({
    ...bootstrapInput(),
    completed: known(completed, 'completed-1'),
    forceCombined: unknown(
      'Trusted exception classification unavailable.',
      'exception-unavailable',
    ),
  });
  expect(result.status).toBe('unresolved');
  expect(result.state?.mode).toBeNull();
  expect(result.state?.history).toEqual([]);
  if (!result.state) throw new Error('Expected independently asserted unresolved state');
  return structuredClone(result.state);
}
function commandInput() {
  return {
    previous: previous(),
    commandEdition: known('A', 'command-edition-9'),
    command: { kind: 'special', letter: 'C' },
    catalog: catalog(),
  };
}
function assertDeepFrozen(value: unknown): void {
  if (value === null || typeof value !== 'object') return;
  expect(Object.isFrozen(value)).toBe(true);
  for (const child of Object.values(value)) assertDeepFrozen(child);
}
function assertDiagnostics(result: { diagnostics: readonly { code: string; message: string }[] }) {
  expect(result.diagnostics.length).toBeGreaterThan(0);
  for (const diagnostic of result.diagnostics) {
    expect(diagnostic.code.trim()).not.toBe('');
    expect(diagnostic.message.trim()).not.toBe('');
  }
}
const branches: Record<string, string> = {
  C01: 'direct-special',
  C02: 'direct-special',
  C03: 'direct-special',
  C04: 'mapped-special',
  C05: 'special-fallback',
  C06: 'alias-retained',
  C07: 'mapped-alias',
  C08: 'mapped-alias',
  C09: 'alias-retained',
  C10: 'direct-special',
};

describe('independent desktop session ledger-mode semantics', () => {
  it('pins literal52 source-derived outcomes frozen before implementation existed', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'f6974c2f079073bba1cfb04305d824fb72c9e651c308999a72c01ea1962645f5',
    );
    expect(vectors.bootstrap).toHaveLength(24);
    expect(vectors.commands).toHaveLength(28);
    expect(SESSION_LEDGER_MODE_VERSION).toBe('session-ledger-mode-semantic-v1');
  });

  it.each(vectors.bootstrap)(
    '$id completed bootstrap preserves independent expected mode',
    (vector) => {
      const input = {
        context: { ...context },
        completed: fact(vector.completedOpen, 'completed-1'),
        edition: fact(vector.bootstrapEdition, 'bootstrap-edition-1'),
        forceCombined: fact(vector.forceCombinedException, 'exception-1'),
      };
      const before = structuredClone(input);
      const result = bootstrapSessionLedgerMode(input);
      expect(result.status).toBe(vector.expected.status);
      expect(result.state).toMatchObject({
        version: 'session-ledger-mode-semantic-v1',
        profile,
        context,
        status: vector.expected.status,
        mode: vector.expected.mode,
        history: [],
        bootstrap: {
          completed: input.completed,
          edition: input.edition,
          forceCombined: input.forceCombined,
        },
      });
      if (result.status === 'resolved') {
        expect(result.state?.reason).toBeNull();
        expect(result.diagnostics).toEqual([]);
      } else {
        expect(result.state?.reason).toEqual(expect.any(String));
        assertDiagnostics(result);
      }
      assertDeepFrozen(result);
      expect(input).toEqual(before);
      expect(Object.isFrozen(input)).toBe(false);
      expect(Object.isFrozen(input.context)).toBe(false);
      expect(result.state?.context).not.toBe(input.context);
    },
  );

  it.each(vectors.commands)(
    '$id resolves exact source branch or preserves refused previous state',
    (vector) => {
      const raw = vectors.catalogs[vector.catalog];
      if (!raw) throw new Error('Missing independently frozen catalog ' + vector.catalog);
      const input = {
        previous: previous(vector.previousMode),
        commandEdition: fact(vector.commandEdition, 'command-edition-9'),
        command: {
          kind: vector.kind === 'special-letter' ? 'special' : 'alias',
          letter: vector.value,
        },
        catalog: catalog(raw),
      };
      const before = structuredClone(input);
      const result = transitionSessionLedgerMode(input);
      const status = vector.expected.decision === 'assigned' ? 'applied' : vector.expected.decision;
      expect(result.status).toBe(status);
      expect(result.state?.mode).toBe(vector.expected.mode);
      if (status === 'unsupported') {
        expect(result.state).toEqual(before.previous);
        assertDiagnostics(result);
      } else {
        expect(result.diagnostics).toEqual([]);
        expect(result.state).toMatchObject({
          status: 'resolved',
          reason: null,
          context: before.previous.context,
          bootstrap: before.previous.bootstrap,
          history: [
            ...before.previous.history,
            {
              commandEdition: before.commandEdition,
              command: before.command,
              catalog: before.catalog,
              previousMode: vector.previousMode,
              nextMode: vector.expected.mode,
              outcome: status,
              branch: branches[vector.id],
            },
          ],
        });
      }
      assertDeepFrozen(result);
      expect(input).toEqual(before);
      expect(Object.isFrozen(input.previous)).toBe(false);
      expect(Object.isFrozen(input.catalog.rows)).toBe(false);
      expect(result.state).not.toBe(input.previous);
      expect(result.state?.context).not.toBe(input.previous.context);
    },
  );

  it('changing command edition after bootstrap does not reset the existing mode', () => {
    const input = commandInput();
    input.previous = previous('C'); // Fully completed L bootstrap gives C.
    input.command.letter = 'A'; // Current A command edition admits a later explicit command.
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('applied');
    expect(result.state?.mode).toBe('A');
    expect(result.state?.bootstrap.edition).toEqual(known('L', 'bootstrap-edition-1'));
    expect(result.state?.history.at(-1)).toMatchObject({ previousMode: 'C', nextMode: 'A' });
  });

  it.each(['L', 'B', 'S', 'U', 'P'])(
    'current non-A/E edition %s refuses without rebootstrap',
    (edition) => {
      const input = { ...commandInput(), commandEdition: known(edition) };
      const result = transitionSessionLedgerMode(input);
      expect(result.status).toBe('unsupported');
      expect(result.state).toEqual(input.previous);
      assertDiagnostics(result);
    },
  );

  it('unknown prior mode cannot be invented by a missing general alias', () => {
    const input = {
      ...commandInput(),
      previous: unresolvedPrevious(),
      command: { kind: 'alias', letter: 'Q' },
    };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('unsupported');
    expect(result.state).toEqual(input.previous);
    assertDiagnostics(result);
  });

  it('completed bootstrap with unknown initial mode permits an independently resolved command', () => {
    const input = { ...commandInput(), previous: unresolvedPrevious() };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('applied');
    expect(result.state?.mode).toBe('C');
    expect(result.state?.bootstrap).toEqual(input.previous.bootstrap);
    expect(result.state?.history.at(-1)).toMatchObject({ previousMode: null, nextMode: 'C' });
  });

  it('failed company-open observation cannot be repaired by a semantic mode command', () => {
    const state = unresolvedPrevious(false);
    const input = { ...commandInput(), previous: state };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('unsupported');
    expect(result.state).toEqual(state);
    assertDiagnostics(result);
  });

  it('NULL unconsumed sentinel name stays raw and does not become missing sentinel', () => {
    const input = {
      ...commandInput(),
      command: { kind: 'special', letter: 'B' },
      catalog: catalog([{ CO_CODE: '01', CON_CODE: 'A', CON_NAME: null }]),
    };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('applied');
    expect(result.state?.mode).toBe('A');
    expect(result.state?.history.at(-1)).toMatchObject({
      branch: 'special-fallback',
      catalog: input.catalog,
    });
  });

  it.each([null, { ...catalog(), complete: false }])(
    'unavailable complete catalog refuses fallback (%j)',
    (value) => {
      const input = { ...commandInput(), catalog: value };
      const result = transitionSessionLedgerMode(input);
      expect(result.status).toBe('unsupported');
      expect(result.state).toEqual(input.previous);
      assertDiagnostics(result);
    },
  );

  it('same scope strings with a distinct context epoch remain distinct observations', () => {
    const first = bootstrapSessionLedgerMode(bootstrapInput());
    const second = bootstrapSessionLedgerMode({
      ...bootstrapInput(),
      context: { ...context, identity: 'context-epoch-19' },
    });
    expect(first.status).toBe('resolved');
    expect(second.status).toBe('resolved');
    expect(first.state?.context.identity).toBe('context-epoch-17');
    expect(second.state?.context.identity).toBe('context-epoch-19');
    expect(first.state).not.toEqual(second.state);
  });

  it('accepted same-value command records an explicit proof instead of silently deduplicating', () => {
    const input = { ...commandInput(), command: { kind: 'special', letter: 'B' } };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('applied');
    expect(result.state?.history).toHaveLength(input.previous.history.length + 1);
    expect(result.state?.history.at(-1)).toMatchObject({
      outcome: 'applied',
      branch: 'direct-special',
      previousMode: 'B',
      nextMode: 'B',
    });
  });

  it('later caller edits cannot alter detached bootstrap output', () => {
    const input = bootstrapInput();
    const result = bootstrapSessionLedgerMode(input);
    const saved = structuredClone(result);
    input.context.identity = 'caller-changed';
    input.edition.value = 'E';
    input.completed.revision = 'caller-revision';
    expect(result).toEqual(saved);
  });

  it('later caller edits cannot alter catalog proof or retained history in output', () => {
    const input = {
      ...commandInput(),
      command: { kind: 'alias', letter: 'R' },
      catalog: catalog([{ CO_CODE: '01', CON_CODE: 'C', CON_NAME: 'R' }]),
    };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('applied');
    const saved = structuredClone(result);
    input.catalog.rows[0]!.raw.CON_CODE = 'A';
    input.catalog.revision = 'caller-new-revision';
    input.previous.context.identity = 'caller-new-context';
    input.previous.history[0]!.catalog.rows.push({
      identity: 'late-row',
      revision: 'late-revision',
      raw: { CO_CODE: '01', CON_CODE: 'B', CON_NAME: 'Q' },
    });
    expect(result).toEqual(saved);
    assertDeepFrozen(result);
  });

  it('accepts already deeply frozen ordinary input without mutating it', () => {
    const freeze = (value: unknown): void => {
      if (value !== null && typeof value === 'object') {
        for (const child of Object.values(value)) freeze(child);
        Object.freeze(value);
      }
    };
    const input = commandInput();
    freeze(input);
    expect(transitionSessionLedgerMode(input).status).toBe('applied');
  });
});

describe('ledger-mode plain-data envelope containment', () => {
  const malformedBootstrap = [
    null,
    [],
    'A',
    1,
    NaN,
    Infinity,
    { ...bootstrapInput(), surprise: true },
    { ...bootstrapInput(), context: { ...context, identity: '' } },
    { ...bootstrapInput(), edition: known('a') },
    { ...bootstrapInput(), edition: known('Z') },
    { ...bootstrapInput(), completed: known('true') },
    { ...bootstrapInput(), forceCombined: known(1) },
    { ...bootstrapInput(), completed: { status: 'known', value: true } },
    { ...bootstrapInput(), edition: { status: 'unknown', reason: '', revision: 'unknown-1' } },
  ];
  it.each(malformedBootstrap.map((value, index) => ({ value, index })))(
    'malformed bootstrap $index is recoverable with no state',
    ({ value }) => {
      const result = bootstrapSessionLedgerMode(value);
      expect(result.status).toBe('invalid-input');
      expect(result.state).toBeNull();
      assertDiagnostics(result);
      assertDeepFrozen(result);
    },
  );

  it('own accessor is refused without invoking it', () => {
    let reads = 0;
    const input = bootstrapInput();
    Object.defineProperty(input, 'completed', {
      enumerable: true,
      get: () => {
        reads += 1;
        throw new Error('Getter must not execute');
      },
    });
    const result = bootstrapSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.state).toBeNull();
    expect(reads).toBe(0);
  });

  it('cyclic plain-data input is refused without recursion failure', () => {
    const input: Record<string, unknown> = bootstrapInput();
    input.self = input;
    expect(bootstrapSessionLedgerMode(input).status).toBe('invalid-input');
  });

  it('inherited required envelope fields are not trusted observations', () => {
    const input: unknown = Object.create(bootstrapInput());
    expect(bootstrapSessionLedgerMode(input).status).toBe('invalid-input');
  });

  it.each([
    { kind: 'special', letter: 'D' },
    { kind: 'alias', letter: 'A' },
    { kind: 'special', letter: '' },
    { kind: 'special', letter: 'b' },
    { kind: 'alias', letter: 'R ' },
    { kind: 'alias', letter: 'R\n' },
    { kind: 'alias', letter: 'R\u2028' },
    { kind: 'special', letter: 'B', mode: 'C' },
  ])('malformed semantic command %j preserves valid previous state', (command) => {
    const input = { ...commandInput(), command };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.state).toEqual(input.previous);
    expect(result.state).not.toBe(input.previous);
    assertDiagnostics(result);
    assertDeepFrozen(result);
  });

  it('malformed previous mode is not returned as a valid source state', () => {
    const input = commandInput();
    input.previous.mode = 'Z';
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.state).toBeNull();
  });

  it('sparse catalog rows cannot masquerade as a complete observation', () => {
    const input = commandInput();
    input.catalog.rows.length = 1;
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.state).toEqual(input.previous);
  });

  it('catalog row accessors cannot execute during containment', () => {
    let reads = 0;
    const raw = { CO_CODE: '01', CON_CODE: 'B', CON_NAME: 'R' };
    Object.defineProperty(raw, 'CON_CODE', {
      enumerable: true,
      get: () => {
        reads += 1;
        throw new Error('No accessor read');
      },
    });
    const input = {
      ...commandInput(),
      command: { kind: 'alias', letter: 'R' },
      catalog: { ...catalog(), rows: [{ identity: 'row-1', revision: 'revision-1', raw }] },
    };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.state).toEqual(input.previous);
    expect(reads).toBe(0);
  });

  it('missing catalog raw key differs from explicit SQL NULL', () => {
    const input = {
      ...commandInput(),
      catalog: {
        ...catalog(),
        rows: [
          {
            identity: 'row-1',
            revision: 'revision-1',
            raw: { CO_CODE: '01', CON_CODE: 'A' },
          },
        ],
      },
    };
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.state).toEqual(input.previous);
  });

  it.each(['02', '01 ', ''])(
    'catalog wrapper company %j cannot replace literal company01',
    (company) => {
      const input = { ...commandInput(), catalog: { ...catalog(), company } };
      const result = transitionSessionLedgerMode(input);
      expect(['invalid-input', 'unsupported']).toContain(result.status);
      expect(result.state).toEqual(input.previous);
      assertDiagnostics(result);
    },
  );

  it('duplicate physical row identity is not two independently observed mappings', () => {
    const item = {
      identity: 'same-row',
      revision: 'row-1',
      raw: { CO_CODE: '01', CON_CODE: 'B', CON_NAME: 'R' },
    };
    const input = {
      ...commandInput(),
      command: { kind: 'alias', letter: 'R' },
      catalog: { ...catalog(), rows: [item, { ...item, raw: { ...item.raw } }] },
    };
    const result = transitionSessionLedgerMode(input);
    expect(['invalid-input', 'unsupported']).toContain(result.status);
    expect(result.state).toEqual(input.previous);
    assertDiagnostics(result);
  });

  it('refuses an accepted-input boundary whose appended proof would exceed reread limits', () => {
    const largeCatalog = (count: number) => ({
      ...catalog(),
      rows: Array.from({ length: count }, (_, index) => ({
        identity: 'row' + index,
        revision: 'z'.repeat(256),
        raw: { CO_CODE: '02', CON_CODE: 'x'.repeat(255), CON_NAME: 'y'.repeat(255) },
      })),
    });
    const state = previous('A');
    state.history = Array.from({ length: 10 }, () => ({
      commandEdition: known('A', 'r'),
      command: { kind: 'special', letter: 'A' },
      catalog: largeCatalog(1000),
      previousMode: 'A',
      nextMode: 'A',
      outcome: 'applied',
      branch: 'direct-special',
    }));
    const input = {
      previous: state,
      commandEdition: known('A', 'r'),
      command: { kind: 'special', letter: 'B' },
      catalog: largeCatalog(840),
    };
    const textSize = (value: unknown): number => {
      if (typeof value === 'string') return value.length;
      if (value === null || typeof value !== 'object') return 0;
      return Object.values(value).reduce<number>((total, child) => total + textSize(child), 0);
    };
    const limit = 8_388_608;
    let excess = textSize(input) - limit;
    expect(excess).toBeGreaterThan(0);
    for (const row of input.catalog.rows) {
      for (const key of ['CON_CODE', 'CON_NAME'] as const) {
        const remove = Math.min(excess, row.raw[key].length);
        row.raw[key] = row.raw[key].slice(0, row.raw[key].length - remove);
        excess -= remove;
      }
    }
    expect(excess).toBe(0);
    expect(textSize(input)).toBe(limit);
    // Source-independent boundary: the accepted result needs an additional
    // previousMode/nextMode/outcome/branch proof. It must remain re-readable.
    const before = structuredClone(state);
    const result = transitionSessionLedgerMode(input);
    expect(result.status).toBe('invalid-input');
    expect(result.diagnostics).toEqual(
      expect.arrayContaining([expect.objectContaining({ code: 'input-limit' })]),
    );
    expect(result.state).toEqual(before);
    expect(result.state).not.toBe(state);
    assertDeepFrozen(result);
    expect(state).toEqual(before);
    expect(Object.isFrozen(state)).toBe(false);
    const recovered = transitionSessionLedgerMode({
      previous: result.state,
      commandEdition: known('A', 'r'),
      command: { kind: 'special', letter: 'C' },
      catalog: catalog(),
    });
    expect(recovered.status).toBe('applied');
    expect(recovered.state?.mode).toBe('C');
    expect(recovered.state?.history).toHaveLength(11);
  });
});
