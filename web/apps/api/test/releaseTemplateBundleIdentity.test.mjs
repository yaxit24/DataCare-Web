import { createHash } from 'node:crypto';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  RELEASE_TEMPLATE_BUNDLE_IDENTITY_MANIFEST,
  candidateTemplateBundleProblems,
  expectedCandidateTemplateBundle,
  expectedCandidateTemplateBundleFromGit,
  observeCandidateTemplateBundle,
  templateBundleIdentity,
  templateBundleManifestSha256,
  templateBundleTreeEntries,
} from '../../../scripts/lib/release-template-bundle-identity.mjs';

const SHA = 'a'.repeat(40);
const OTHER_SHA = 'b'.repeat(40);
const FORM_ROOT = 'web/apps/api/form-specs';
const REPORT_ROOT = 'web/apps/api/report-specs';
const FORM_INDEX = `${FORM_ROOT}/initcomp-index.json`;
const FORM_SPEC = `${FORM_ROOT}/Alpha.initcomp.json`;
const FORM_LAYOUT = `${FORM_ROOT}/DataCareNext.Alpha.layout.json`;
const REPORT_INDEX = `${REPORT_ROOT}/report-layouts-index.json`;
const REPORT_SPEC = `${REPORT_ROOT}/ReportA.spec.json`;

const json = (value) => `${JSON.stringify(value, null, 2)}\n`;
const sha256 = (value) =>
  createHash('sha256')
    .update(Buffer.isBuffer(value) ? value : Buffer.from(value, 'utf8'))
    .digest('hex');

const FORM_SPEC_VALUE = Object.freeze({
  form: 'Alpha',
  controlCount: 1,
  byKind: { textbox: 1 },
  grids: [],
  tabs: [],
  gridColumns: 0,
  controls: [{ name: 'Name', kind: 'textbox' }],
});
const FORM_INDEX_VALUE = Object.freeze([
  {
    form: 'Alpha',
    controlCount: 1,
    byKind: { textbox: 1 },
    grids: 0,
    tabs: 0,
    gridColumns: 0,
  },
]);
const FORM_LAYOUT_VALUE = Object.freeze({
  form: 'DataCareNext.Alpha',
  controlCount: 1,
  byKind: { label: 1 },
  controls: [{ name: 'Label', kind: 'label' }],
});
const REPORT_SPEC_VALUE = Object.freeze({
  report: 'ReportA',
  areas: [{ sections: [{ objects: [{ name: 'Field1' }, { name: 'Field2' }] }] }],
  formulas: [{ name: 'Amount' }],
  sectionCount: 1,
  objectCount: 2,
  formulaCount: 1,
});
const REPORT_INDEX_VALUE = Object.freeze([
  { report: 'ReportA', areas: 1, sections: 1, objects: 2, formulas: 1 },
]);

const BASE_FILES = Object.freeze({
  [FORM_INDEX]: json(FORM_INDEX_VALUE),
  [FORM_SPEC]: json(FORM_SPEC_VALUE),
  [FORM_LAYOUT]: json(FORM_LAYOUT_VALUE),
  [REPORT_INDEX]: json(REPORT_INDEX_VALUE),
  [REPORT_SPEC]: json(REPORT_SPEC_VALUE),
});

const cloneFiles = (overrides = {}) => ({ ...BASE_FILES, ...overrides });
const rawEntries = (files = BASE_FILES) =>
  Object.entries(files).map(([path, bytes]) => ({ path, bytes }));
const manifestDigest = (files, prefix = '') => {
  const entries = Object.entries(files)
    .filter(([path]) => path.startsWith(prefix))
    .map(([path, bytes]) => ({ path, sha256: sha256(bytes) }))
    .sort((left, right) => Buffer.compare(Buffer.from(left.path), Buffer.from(right.path)));
  return sha256(JSON.stringify(entries));
};

function treeFixture(files = BASE_FILES, options = {}) {
  const order = options.order ?? Object.keys(files);
  const descriptors = new Map();
  const records = order.map((path) => {
    const oid = sha256(files[path]).slice(0, 40);
    descriptors.set(oid, files[path]);
    const mode = options.mode?.[path] ?? '100644';
    const type = options.type?.[path] ?? 'blob';
    return `${mode} ${type} ${oid}\t${path}`;
  });
  return {
    listing: Buffer.from(`${records.join('\0')}\0`, 'utf8'),
    descriptors,
  };
}

function gitFixture({ files = BASE_FILES, resolved = SHA, order } = {}) {
  const tree = treeFixture(files, { order: order ?? Object.keys(files) });
  const calls = [];
  const runGit = (_repoRoot, args) => {
    calls.push(args);
    if (args[0] === 'rev-parse') return Buffer.from(`${resolved}\n`, 'utf8');
    if (args[0] === 'ls-tree') return tree.listing;
    if (args[0] === 'cat-file') {
      const value = tree.descriptors.get(args[2]);
      if (value === undefined) throw new Error(`missing Git blob ${args[2]}`);
      return Buffer.from(value, 'utf8');
    }
    throw new Error(`unexpected Git command ${args.join(' ')}`);
  };
  return { calls, runGit };
}

describe('release template bundle identity contract', () => {
  it('documents the exact bounded template universe', () => {
    expect(RELEASE_TEMPLATE_BUNDLE_IDENTITY_MANIFEST).toEqual({
      kind: 'datacare.release-template-bundle-identity/1.0',
      algorithm: 'sha256(utf8(JSON.stringify([{path,sha256},...])))',
      selection: 'git ls-tree -r -z <commit> -- <pathspecs>',
      pathspecs: [FORM_ROOT, REPORT_ROOT],
      requiredIndexes: [FORM_INDEX, REPORT_INDEX],
      form: {
        root: FORM_ROOT,
        index: FORM_INDEX,
        specSuffix: '.initcomp.json',
        layoutSuffix: '.layout.json',
      },
      report: {
        root: REPORT_ROOT,
        index: REPORT_INDEX,
        specSuffix: '.spec.json',
      },
    });
  });

  it('hashes raw bytes in UTF-8 path order with stable component identities', () => {
    const identity = templateBundleIdentity(rawEntries().reverse());
    expect(identity).toMatchObject({
      templateSha256: manifestDigest(BASE_FILES),
      templateFileCount: 5,
      formTemplateSha256: manifestDigest(BASE_FILES, `${FORM_ROOT}/`),
      formTemplateFileCount: 3,
      formSpecCount: 1,
      formLayoutCount: 1,
      reportTemplateSha256: manifestDigest(BASE_FILES, `${REPORT_ROOT}/`),
      reportTemplateFileCount: 2,
      reportSpecCount: 1,
    });
    expect(identity.templateEntries.map(({ path }) => path)).toEqual(
      [...Object.keys(BASE_FILES)].sort((left, right) =>
        Buffer.compare(Buffer.from(left), Buffer.from(right)),
      ),
    );
    expect(Object.isFrozen(identity)).toBe(true);
    expect(Object.isFrozen(identity.templateEntries)).toBe(true);
    expect(identity.templateEntries.every(Object.isFrozen)).toBe(true);
  });

  it('changes only the affected component and aggregate for an exact-byte change', () => {
    const before = templateBundleIdentity(rawEntries());
    const changedFiles = cloneFiles({ [FORM_SPEC]: `${BASE_FILES[FORM_SPEC]} ` });
    const changed = templateBundleIdentity(rawEntries(changedFiles));
    expect(changed.formTemplateSha256).not.toBe(before.formTemplateSha256);
    expect(changed.templateSha256).not.toBe(before.templateSha256);
    expect(changed.reportTemplateSha256).toBe(before.reportTemplateSha256);
  });

  it('sorts full Git tree entries and rejects duplicate, unsupported and non-regular entries', () => {
    const reverse = treeFixture(BASE_FILES, { order: Object.keys(BASE_FILES).reverse() });
    expect(templateBundleTreeEntries(reverse.listing).map(({ path }) => path)).toEqual(
      templateBundleIdentity(rawEntries()).templateEntries.map(({ path }) => path),
    );

    const duplicate = Buffer.concat([reverse.listing, reverse.listing]);
    expect(() => templateBundleTreeEntries(duplicate)).toThrow('duplicate paths');
    const outOfScope = treeFixture({ 'web/other/Other.json': '{}' });
    expect(() => templateBundleTreeEntries(outOfScope.listing)).toThrow('out-of-scope path');
    const unsupported = treeFixture({ ...BASE_FILES, [`${FORM_ROOT}/Notes.json`]: '{}' });
    expect(() => templateBundleTreeEntries(unsupported.listing)).toThrow('unsupported JSON asset');
    const symlink = treeFixture(BASE_FILES, { mode: { [FORM_SPEC]: '120000' } });
    expect(() => templateBundleTreeEntries(symlink.listing)).toThrow('not a regular Git blob');
    const submodule = treeFixture(BASE_FILES, {
      mode: { [FORM_SPEC]: '160000' },
      type: { [FORM_SPEC]: 'commit' },
    });
    expect(() => templateBundleTreeEntries(submodule.listing)).toThrow('not a regular Git blob');
  });

  it('requires both indexes and nonempty form, layout and report spec sets', () => {
    const withoutFormIndex = cloneFiles();
    delete withoutFormIndex[FORM_INDEX];
    expect(() => templateBundleIdentity(rawEntries(withoutFormIndex))).toThrow(
      `missing required index ${FORM_INDEX}`,
    );

    const withoutForms = cloneFiles();
    delete withoutForms[FORM_SPEC];
    expect(() => templateBundleIdentity(rawEntries(withoutForms))).toThrow(
      'contains no form specs',
    );

    const withoutLayouts = cloneFiles();
    delete withoutLayouts[FORM_LAYOUT];
    expect(() => templateBundleIdentity(rawEntries(withoutLayouts))).toThrow(
      'contains no form layouts',
    );

    const withoutReports = cloneFiles();
    delete withoutReports[REPORT_SPEC];
    expect(() => templateBundleIdentity(rawEntries(withoutReports))).toThrow(
      'contains no report specs',
    );
  });

  it('requires valid UTF-8 JSON objects whose embedded names match their basenames', () => {
    expect(() =>
      templateBundleIdentity(rawEntries(cloneFiles({ [REPORT_SPEC]: Buffer.from([0xff]) }))),
    ).toThrow('is not valid UTF-8');
    expect(() =>
      templateBundleIdentity(rawEntries(cloneFiles({ [REPORT_SPEC]: '{not json}\n' }))),
    ).toThrow(`${REPORT_SPEC} is invalid`);
    expect(() =>
      templateBundleIdentity(rawEntries(cloneFiles({ [REPORT_SPEC]: json([]) }))),
    ).toThrow('must contain an object');
    expect(() =>
      templateBundleIdentity(
        rawEntries(cloneFiles({ [REPORT_SPEC]: json({ ...REPORT_SPEC_VALUE, report: 'Other' }) })),
      ),
    ).toThrow('names report Other instead of ReportA');
  });

  it('requires unique index IDs and exact index-to-spec basename equality', () => {
    expect(() =>
      templateBundleIdentity(
        rawEntries(cloneFiles({ [FORM_INDEX]: json([...FORM_INDEX_VALUE, ...FORM_INDEX_VALUE]) })),
      ),
    ).toThrow('duplicate form Alpha');

    const wrongReportIndex = [{ ...REPORT_INDEX_VALUE[0], report: 'Other' }];
    expect(() =>
      templateBundleIdentity(rawEntries(cloneFiles({ [REPORT_INDEX]: json(wrongReportIndex) }))),
    ).toThrow('does not equal report spec basenames; missing ReportA; unexpected Other');
  });

  it('rejects stale index metadata and internally stale spec metrics', () => {
    const staleIndex = [{ ...REPORT_INDEX_VALUE[0], objects: 3 }];
    expect(() =>
      templateBundleIdentity(rawEntries(cloneFiles({ [REPORT_INDEX]: json(staleIndex) }))),
    ).toThrow('stale objects for ReportA');
    expect(() =>
      templateBundleIdentity(
        rawEntries(
          cloneFiles({
            [REPORT_SPEC]: json({ ...REPORT_SPEC_VALUE, objectCount: 3 }),
          }),
        ),
      ),
    ).toThrow('objectCount does not match its content');
  });

  it('validates manifest hashes independently of entry order', () => {
    const entries = templateBundleIdentity(rawEntries()).templateEntries;
    expect(templateBundleManifestSha256([...entries].reverse())).toBe(manifestDigest(BASE_FILES));
    expect(() => templateBundleManifestSha256([])).toThrow('requires a nonempty entry manifest');
    expect(() => templateBundleManifestSha256([...entries, entries[0]])).toThrow('duplicate paths');
  });
});

describe('template bundle observers and fail-closed comparison', () => {
  it('observes worktree bytes while HEAD supplies the exact regular-file set', () => {
    const tree = treeFixture(BASE_FILES, { order: Object.keys(BASE_FILES).reverse() });
    const root = '/repo';
    const byFullPath = Object.fromEntries(
      Object.entries(BASE_FILES).map(([path, bytes]) => [resolve(root, path), bytes]),
    );
    const gitCalls = [];
    const observed = observeCandidateTemplateBundle(
      root,
      (_repoRoot, args) => {
        gitCalls.push(args);
        return tree.listing;
      },
      (path) => Buffer.from(byFullPath[path], 'utf8'),
      () => ({ isFile: () => true }),
    );
    expect(observed.templateSha256).toBe(manifestDigest(BASE_FILES));
    expect(gitCalls).toEqual([['ls-tree', '-r', '-z', 'HEAD', '--', FORM_ROOT, REPORT_ROOT]]);

    const refused = observeCandidateTemplateBundle(
      root,
      () => tree.listing,
      () => Buffer.alloc(0),
      () => ({ isFile: () => false }),
    );
    expect(refused).toMatchObject({
      templateSha256: null,
      templateFileCount: null,
      error: expect.stringContaining('not a regular worktree file'),
    });
  });

  it('derives the same identity exclusively from an exact immutable Git commit', () => {
    const fixture = gitFixture({ order: Object.keys(BASE_FILES).reverse() });
    const expected = expectedCandidateTemplateBundleFromGit('/repo', SHA, fixture.runGit);
    expect(expected).toMatchObject({
      releaseSha: SHA,
      templateSha256: manifestDigest(BASE_FILES),
      formTemplateSha256: manifestDigest(BASE_FILES, `${FORM_ROOT}/`),
      reportTemplateSha256: manifestDigest(BASE_FILES, `${REPORT_ROOT}/`),
    });
    expect(fixture.calls[0]).toEqual(['rev-parse', '--verify', `${SHA}^{commit}`]);
    expect(fixture.calls[1]).toEqual(['ls-tree', '-r', '-z', SHA, '--', FORM_ROOT, REPORT_ROOT]);
    expect(fixture.calls.slice(2).every((args) => args[0] === 'cat-file')).toBe(true);
  });

  it('rejects malformed or differently resolved commit IDs before trusting Git objects', () => {
    let invoked = false;
    expect(() =>
      expectedCandidateTemplateBundleFromGit('/repo', 'HEAD', () => {
        invoked = true;
        return Buffer.alloc(0);
      }),
    ).toThrow('exact 40-character hexadecimal object id');
    expect(invoked).toBe(false);
    expect(() =>
      expectedCandidateTemplateBundleFromGit(
        '/repo',
        SHA,
        gitFixture({ resolved: OTHER_SHA }).runGit,
      ),
    ).toThrow(`release commit ${SHA} did not resolve to that exact commit object`);
  });

  it('requires a valid independent digest and refuses mismatch or observation errors', () => {
    const observed = templateBundleIdentity(rawEntries());
    expect(
      candidateTemplateBundleProblems(
        expectedCandidateTemplateBundle({
          RELEASE_TEMPLATE_SHA256: observed.templateSha256.toUpperCase(),
        }),
        observed,
      ),
    ).toEqual([]);
    expect(candidateTemplateBundleProblems(expectedCandidateTemplateBundle({}), observed)).toEqual([
      'RELEASE_TEMPLATE_SHA256 is required to bind certification to the candidate template bundle',
    ]);
    expect(candidateTemplateBundleProblems({ templateSha256: 'short' }, observed)).toEqual([
      'RELEASE_TEMPLATE_SHA256 must be an exact 64-character SHA-256 digest',
    ]);
    expect(candidateTemplateBundleProblems({ templateSha256: 'f'.repeat(64) }, observed)).toEqual([
      `RELEASE_TEMPLATE_SHA256 ${'f'.repeat(64)} does not match candidate checkout ${observed.templateSha256}`,
    ]);
    expect(
      candidateTemplateBundleProblems(
        { templateSha256: observed.templateSha256 },
        { templateSha256: null, error: 'catalog invalid' },
      ),
    ).toEqual([
      'RELEASE_TEMPLATE_SHA256 could not be observed from the candidate checkout',
      'candidate template bundle identity could not be observed: catalog invalid',
    ]);
  });
});
