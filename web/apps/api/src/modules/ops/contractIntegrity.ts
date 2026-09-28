/**
 * Contract integrity (P1-07 / WP-05).
 *
 * WHAT A CONTRACT IS FOR
 * ======================
 * `project-memory/contracts/<FORM>.contract.md` is the approved translation of one desktop form into
 * web-implementable rules. Its own README states the discipline: every rule cites the desktop source by
 * `file:line`, no rule may be inferred from the web implementation, ambiguity goes to Open questions rather
 * than being guessed, and a contract counts as evidence only when it contains the line `Status: approved`.
 *
 * WHAT WAS MISSING
 * ================
 * Nothing checked any of that. Measured across the 11 retained contracts:
 *
 *   * 8 are drafts carrying **30 NOT ENFORCED** desktop validations, **184 blank vector cells** and
 *     **37 blank test cells** — the generated tables' own way of saying "open item".
 *   * Two draft rows were **stale**: the message they call NOT ENFORCED is enforced by current code, because
 *     the contracts were generated on 2026-07-29 and a month of implementation followed.
 *   * A contract could be flipped to `approved` with every one of those cells still blank, and nothing would
 *     object. That is the same hole as an unclassified register or a `continue-on-error` parity gate: the
 *     artefact exists, the enforcement does not.
 *
 * So this module mechanises WP-05's exit criterion — "every validation/vector cell is implemented and tested
 * or covered by a signed divergence; zero blank or NOT ENFORCED cells pass" — and, because the desktop
 * sources are present in this workspace (204 files), it also verifies that every `file:line` citation
 * actually resolves. An unresolvable citation is the one defect that would make a contract worse than no
 * contract, since it looks like evidence.
 *
 * TWO TABLE SHAPES, BOTH REAL
 * ===========================
 * Generated drafts carry `| Desktop message | Status | Web implementation | Test |` and
 * `| Desktop cell | Grid | Control | Persisted column | Web writes column | Vector |`. Hand-authored approved
 * contracts carry `| Rule | Citation | Behaviour |` and `| Value | Vector | Note |`. A parser that assumed one
 * shape reported the reference approved contract as containing zero rules, so tables are classified by their
 * headers.
 */

export type ContractStatus = 'draft' | 'approved' | 'unknown';

export interface ContractInput {
  /** File name, e.g. `TR_SALE.contract.md`. */
  name: string;
  text: string;
}

export interface ContractAuditContext {
  /** Desktop source line counts, keyed by form id — the facts a citation is checked against. */
  desktopLineCounts: Readonly<Record<string, number>>;
  /** Golden-vector ids that actually exist in the test suite. */
  definedVectorIds: ReadonlySet<string>;
  /**
   * Debt that may shrink but never grow. WP-05 is not finished, so the gate ratchets rather than pretending.
   */
  debtCeiling: { notEnforced: number; blankVector: number; blankTest: number };
}

export interface ContractSummary {
  name: string;
  formId: string;
  status: ContractStatus;
  /** Generated validation rows and how many are still unenforced. */
  validations: number;
  notEnforced: number;
  /** Generated computed rows and how many carry no vector. */
  computed: number;
  blankVector: number;
  blankTest: number;
  /** Hand-authored `Rule | Citation | Behaviour` rows. */
  authoredRules: number;
  /** Distinct `FORM.cs:LINE` citations found anywhere in the file. */
  citations: number;
}

export interface ContractFinding {
  contract: string;
  /** `blocking` fails the gate. `debt` is recorded, counted and ratcheted. */
  severity: 'blocking' | 'debt';
  rule: string;
  detail: string;
}

export interface ContractAuditReport {
  verdict: 'ok' | 'red';
  contracts: ContractSummary[];
  findings: ContractFinding[];
  totals: {
    contracts: number;
    approved: number;
    draft: number;
    validations: number;
    notEnforced: number;
    computed: number;
    blankVector: number;
    blankTest: number;
    citations: number;
  };
}

interface ParsedTable {
  header: string[];
  rows: string[][];
}

const splitRow = (line: string): string[] =>
  line
    .replace(/^\s*\|/, '')
    .replace(/\|\s*$/, '')
    .split('|')
    .map((cell) => cell.trim());

/** Pull every Markdown table out of a contract, keeping its header so the table can be identified. */
export function parseTables(text: string): ParsedTable[] {
  const tables: ParsedTable[] = [];
  const lines = text.split('\n');
  for (let i = 0; i < lines.length; i += 1) {
    const line = lines[i] ?? '';
    if (!line.trim().startsWith('|')) continue;
    const next = lines[i + 1] ?? '';
    // A Markdown table is a header row followed by a delimiter row of dashes.
    if (!/^\s*\|[\s:|-]+\|\s*$/.test(next)) continue;
    const header = splitRow(line).map((h) => h.toLowerCase());
    const rows: string[][] = [];
    let j = i + 2;
    for (; j < lines.length; j += 1) {
      const body = lines[j] ?? '';
      if (!body.trim().startsWith('|')) break;
      rows.push(splitRow(body));
    }
    tables.push({ header, rows });
    i = j - 1;
  }
  return tables;
}

const has = (header: string[], ...needles: string[]): boolean =>
  needles.every((n) => header.some((h) => h.includes(n)));

const columnIndex = (header: string[], needle: string): number =>
  header.findIndex((h) => h.includes(needle));

/**
 * Every desktop citation in the text, de-duplicated.
 *
 * Two forms are in use and both are accepted: the full `TR_SALE.cs:14233`, and the shorthand `` `:4207` ``
 * that hand-authored contracts use once the file has been named. The shorthand resolves against the
 * contract's own form, which is why `formId` is a parameter — reading it as a bare number would have skipped
 * exactly the citations the reference contract relies on most.
 */
export function citationsIn(text: string, formId?: string): Array<{ form: string; line: number }> {
  const out = new Map<string, { form: string; line: number }>();
  for (const match of text.matchAll(/`?([A-Za-z][A-Za-z0-9_]*)\.cs:(\d+)/g)) {
    const key = `${match[1]}:${match[2]}`;
    out.set(key, { form: match[1] as string, line: Number(match[2]) });
  }
  if (formId) {
    for (const match of text.matchAll(/`:(\d{2,})`/g)) {
      const key = `${formId}:${match[1]}`;
      out.set(key, { form: formId, line: Number(match[1]) });
    }
  }
  return [...out.values()];
}

/** Every golden-vector id cited in the text. */
export function vectorIdsIn(text: string): string[] {
  return [...new Set([...text.matchAll(/GV-[A-Z0-9]+-\d+/g)].map((m) => m[0] as string))];
}

const STATUS_LINE = /^Status:\s*(draft|approved)\s*$/gm;

/** A generated validation row is open when its status still says the web does not enforce it. */
const NOT_ENFORCED = /NOT ENFORCED/i;

/**
 * Dispositions for which no API test can exist, so a blank Test cell is correct rather than open.
 *
 * The contracts' own discipline is "implemented + test **or** waived with a reason". A row waived because the
 * desktop message is a licence-tier gate, an MDI lifecycle notice, or a page-level prompt has nothing for an
 * API test to assert; what it must carry instead is the reason. Demanding a test from those rows made the gate
 * report the reference approved contracts as defective, which would have taught everyone to ignore it.
 */
const NO_TEST_POSSIBLE = /^(WAIVED|UI-LEVEL|N\/A|NOT APPLICABLE|PROMPT|NOTICE)\b/i;

/**
 * Vector links a draft could adopt, learned from contracts the owner already approved.
 *
 * WHY THIS IS A REPORT AND NOT AN EDIT
 * ===================================
 * 99 of the 184 blank vector cells have a cell in an APPROVED contract with the same control name AND the same
 * persisted column, already carrying a vector id. Writing those ids into the drafts would close 54% of the
 * vector debt in one pass, and it would be wrong to do it here.
 *
 * A filled Vector cell asserts "a golden vector pins this formula". Two forms can name a control `cNetWt` and
 * persist `ITM_NWT` while computing it from different grid cells — `MSG[14]` in the sale, `MSG[16]` in the tag
 * opening — and the audit data records the cell identity but NOT the desktop expression, so equality cannot be
 * established from the retained artefacts. Transcribing the id anyway would turn a visibly open cell into a
 * false pass, which is worse: the gate exists so that blanks cannot be faked, and it would be absurd for the
 * gate's author to fake them.
 *
 * The same shortcut has already failed twice in this project — label matching reported Sales as missing, table
 * grepping reported everything as present. So this returns candidates for a human to confirm against
 * `unified/src/csharp/DataCareNext/<FORM>.cs`, which is the only place the expression exists.
 */
export interface VectorCandidate {
  contract: string;
  control: string;
  column: string;
  vector: string;
  /** The approved contract the mapping was learned from. */
  precedent: string;
}

export function vectorCandidates(files: readonly ContractInput[]): VectorCandidate[] {
  const approved = new Map<string, { vector: string; precedent: string }>();
  const blanks: Array<{ contract: string; control: string; column: string }> = [];

  for (const file of files) {
    const status = /^Status:\s*(draft|approved)\s*$/m.exec(file.text)?.[1] ?? 'unknown';
    for (const table of parseTables(file.text)) {
      if (!has(table.header, 'desktop cell')) continue;
      const controlAt = columnIndex(table.header, 'control');
      const columnAt = columnIndex(table.header, 'persisted');
      const vectorAt = columnIndex(table.header, 'vector');
      if (controlAt < 0 || columnAt < 0 || vectorAt < 0) continue;
      for (const row of table.rows) {
        const control = (row[controlAt] ?? '').replace(/`/g, '').trim();
        const column = (row[columnAt] ?? '').replace(/`/g, '').trim();
        const vector = (row[vectorAt] ?? '').trim();
        if (!control || !column) continue;
        const key = `${control}|${column}`;
        if (status === 'approved' && vector) {
          approved.set(key, { vector, precedent: file.name });
        } else if (status === 'draft' && !vector) {
          blanks.push({ contract: file.name, control, column });
        }
      }
    }
  }

  const out: VectorCandidate[] = [];
  for (const blank of blanks) {
    const match = approved.get(`${blank.control}|${blank.column}`);
    if (match) out.push({ ...blank, vector: match.vector, precedent: match.precedent });
  }
  return out;
}

export function auditContracts(
  files: readonly ContractInput[],
  ctx: ContractAuditContext,
): ContractAuditReport {
  const contracts: ContractSummary[] = [];
  const findings: ContractFinding[] = [];
  const add = (
    contract: string,
    severity: ContractFinding['severity'],
    rule: string,
    detail: string,
  ): void => {
    findings.push({ contract, severity, rule, detail });
  };

  for (const file of files) {
    const nameMatch = /^([A-Za-z][A-Za-z0-9_]*)\.contract\.md$/.exec(file.name);
    const formId = nameMatch?.[1] ?? '';
    if (!formId) {
      add(
        file.name,
        'blocking',
        'filename',
        'must be exactly <FORM_ID>.contract.md (README rule 1)',
      );
    } else if (ctx.desktopLineCounts[formId] == null) {
      // A contract for a form that does not exist describes nothing.
      add(
        file.name,
        'blocking',
        'desktop-form-exists',
        `no desktop source found for form ${formId}`,
      );
    }

    const statusMatches = [...file.text.matchAll(STATUS_LINE)];
    let status: ContractStatus = 'unknown';
    if (statusMatches.length === 1) {
      status = statusMatches[0]![1] as ContractStatus;
    } else {
      add(
        file.name,
        'blocking',
        'status-line',
        statusMatches.length === 0
          ? 'no `Status: draft|approved` line (README rule 3)'
          : `${statusMatches.length} Status lines; exactly one is allowed`,
      );
    }

    const tables = parseTables(file.text);
    let validations = 0;
    let notEnforced = 0;
    let computed = 0;
    let blankVector = 0;
    let blankTest = 0;
    let authoredRules = 0;

    for (const table of tables) {
      if (has(table.header, 'desktop message')) {
        const statusAt = columnIndex(table.header, 'status');
        const testAt = columnIndex(table.header, 'test');
        // The disposition column is titled 'Web implementation' in drafts and
        // 'Disposition / web implementation' in the approved ones.
        const dispositionAt = columnIndex(table.header, 'implementation');
        for (const row of table.rows) {
          validations += 1;
          const rowStatus = statusAt >= 0 ? (row[statusAt] ?? '') : '';
          const message = (row[0] ?? '').slice(0, 70);
          if (NOT_ENFORCED.test(rowStatus)) {
            notEnforced += 1;
            continue;
          }
          if (NO_TEST_POSSIBLE.test(rowStatus.trim())) {
            // No test is possible, so the reason is the evidence and may not be blank.
            if (dispositionAt >= 0 && !(row[dispositionAt] ?? '').trim()) {
              add(
                file.name,
                'blocking',
                'waiver-carries-reason',
                `"${message}" is ${rowStatus.trim()} with no reason recorded (README rule 5)`,
              );
            }
            continue;
          }
          if (testAt >= 0 && !(row[testAt] ?? '').trim()) blankTest += 1;
        }
      } else if (has(table.header, 'desktop cell')) {
        const vectorAt = columnIndex(table.header, 'vector');
        for (const row of table.rows) {
          computed += 1;
          if (vectorAt >= 0 && !(row[vectorAt] ?? '').trim()) blankVector += 1;
        }
      } else if (has(table.header, 'rule', 'citation')) {
        const citationAt = columnIndex(table.header, 'citation');
        for (const row of table.rows) {
          authoredRules += 1;
          if (!(row[citationAt] ?? '').trim()) {
            add(
              file.name,
              'blocking',
              'authored-rule-cites-source',
              `rule "${(row[0] ?? '').slice(0, 60)}" has no citation (README rule 2)`,
            );
          }
        }
      } else if (has(table.header, 'value', 'vector')) {
        const vectorAt = columnIndex(table.header, 'vector');
        for (const row of table.rows) {
          computed += 1;
          if (!(row[vectorAt] ?? '').trim()) blankVector += 1;
        }
      }
    }

    // Citations must resolve. This is the check that separates evidence from the appearance of evidence.
    const citations = citationsIn(file.text, formId || undefined);
    for (const citation of citations) {
      const lineCount = ctx.desktopLineCounts[citation.form];
      if (lineCount == null) {
        add(
          file.name,
          'blocking',
          'citation-resolves',
          `cites ${citation.form}.cs:${citation.line} but no such desktop source exists`,
        );
      } else if (citation.line < 1 || citation.line > lineCount) {
        add(
          file.name,
          'blocking',
          'citation-resolves',
          `cites ${citation.form}.cs:${citation.line} but that file has ${lineCount} lines`,
        );
      }
    }

    // A vector id that does not exist is a test citation to a test nobody wrote.
    for (const id of vectorIdsIn(file.text)) {
      if (!ctx.definedVectorIds.has(id)) {
        add(file.name, 'blocking', 'vector-exists', `cites ${id}, which no golden vector defines`);
      }
    }

    if (status === 'approved') {
      // WP-05's exit criterion, applied only where approval is claimed.
      if (notEnforced > 0) {
        add(
          file.name,
          'blocking',
          'approved-has-no-unenforced-rule',
          `approved with ${notEnforced} NOT ENFORCED validation(s); implement them or record a signed divergence`,
        );
      }
      if (blankVector > 0) {
        add(
          file.name,
          'blocking',
          'approved-has-no-blank-vector',
          `approved with ${blankVector} computed cell(s) carrying no golden-vector id`,
        );
      }
      if (blankTest > 0) {
        add(
          file.name,
          'blocking',
          'approved-has-no-blank-test',
          `approved with ${blankTest} validation row(s) carrying no test`,
        );
      }
      if (validations + computed + authoredRules === 0) {
        add(
          file.name,
          'blocking',
          'approved-asserts-something',
          'approved but contains no rule, validation or computed cell at all',
        );
      }
      if (citations.length === 0) {
        /**
         * README rule 2 asks every rule to cite the desktop source by `file:line`. The generated contracts
         * cite it differently — verbatim desktop message text and the exact grid cell id, e.g. `mSG_TOT[29]` —
         * which is traceable but not a line reference.
         *
         * Recorded as debt rather than blocking on purpose. The substance is there (the generator read the
         * desktop; the message is quoted verbatim), so the gap is the citation FORM, and retroactively
         * invalidating an owner's approval over form is not a gate's decision to make. It is surfaced so the
         * contract owner can decide whether to add line references or amend the README.
         */
        add(
          file.name,
          'debt',
          'approved-cites-desktop-line',
          'approved with no resolvable FORM.cs:LINE citation; rows are cited by verbatim message and grid cell instead (README rule 2)',
        );
      }
    } else if (status === 'draft') {
      if (notEnforced > 0) {
        add(file.name, 'debt', 'draft-debt', `${notEnforced} NOT ENFORCED validation(s)`);
      }
      if (blankVector > 0) {
        add(file.name, 'debt', 'draft-debt', `${blankVector} computed cell(s) without a vector`);
      }
    }

    contracts.push({
      name: file.name,
      formId,
      status,
      validations,
      notEnforced,
      computed,
      blankVector,
      blankTest,
      authoredRules,
      citations: citations.length,
    });
  }

  const sum = (pick: (c: ContractSummary) => number): number =>
    contracts.reduce((total, c) => total + pick(c), 0);
  const totals = {
    contracts: contracts.length,
    approved: contracts.filter((c) => c.status === 'approved').length,
    draft: contracts.filter((c) => c.status === 'draft').length,
    validations: sum((c) => c.validations),
    notEnforced: sum((c) => c.notEnforced),
    computed: sum((c) => c.computed),
    blankVector: sum((c) => c.blankVector),
    blankTest: sum((c) => c.blankTest),
    citations: sum((c) => c.citations),
  };

  // The ratchet. Debt is allowed to exist and required to shrink; growing it needs a deliberate edit here.
  for (const [key, ceiling] of Object.entries(ctx.debtCeiling) as Array<
    [keyof ContractAuditContext['debtCeiling'], number]
  >) {
    const actual = totals[key];
    if (actual > ceiling) {
      add(
        '(all contracts)',
        'blocking',
        'debt-ratchet',
        `${key} rose from ${ceiling} to ${actual}; contract debt may only shrink`,
      );
    }
  }

  return {
    verdict: findings.some((f) => f.severity === 'blocking') ? 'red' : 'ok',
    contracts,
    findings,
    totals,
  };
}
