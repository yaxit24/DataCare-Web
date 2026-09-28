import { execFileSync } from 'node:child_process';
import { createHash } from 'node:crypto';
import { lstatSync, readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { TextDecoder } from 'node:util';

const COMMIT_SHA = /^[0-9a-f]{40}$/i;
const SHA256 = /^[0-9a-f]{64}$/i;
const REGULAR_FILE_MODE = /^100(?:644|755)$/;

const FORM_ROOT = 'web/apps/api/form-specs';
const REPORT_ROOT = 'web/apps/api/report-specs';
const FORM_INDEX = `${FORM_ROOT}/initcomp-index.json`;
const REPORT_INDEX = `${REPORT_ROOT}/report-layouts-index.json`;
const FORM_SPEC_SUFFIX = '.initcomp.json';
const FORM_LAYOUT_SUFFIX = '.layout.json';
const REPORT_SPEC_SUFFIX = '.spec.json';

const TEMPLATE_PATHSPECS = Object.freeze([FORM_ROOT, REPORT_ROOT]);
const REQUIRED_INDEXES = Object.freeze([FORM_INDEX, REPORT_INDEX]);

/**
 * Candidate-owned web template bundle contract.
 *
 * This identity covers the JSON assets loaded by the form/report layout engines. It deliberately does not
 * claim to identify the private desktop Crystal `.rpt` files or tenant-owned database message templates.
 * Selection is taken from Git so additions, removals, renames, symlinks and submodules cannot be hidden by a
 * filesystem glob. JSON is parsed only for structural validation; the digest always covers its original bytes.
 */
export const RELEASE_TEMPLATE_BUNDLE_IDENTITY_MANIFEST = Object.freeze({
  kind: 'datacare.release-template-bundle-identity/1.0',
  algorithm: 'sha256(utf8(JSON.stringify([{path,sha256},...])))',
  selection: 'git ls-tree -r -z <commit> -- <pathspecs>',
  pathspecs: TEMPLATE_PATHSPECS,
  requiredIndexes: REQUIRED_INDEXES,
  form: Object.freeze({
    root: FORM_ROOT,
    index: FORM_INDEX,
    specSuffix: FORM_SPEC_SUFFIX,
    layoutSuffix: FORM_LAYOUT_SUFFIX,
  }),
  report: Object.freeze({
    root: REPORT_ROOT,
    index: REPORT_INDEX,
    specSuffix: REPORT_SPEC_SUFFIX,
  }),
});

const utf8 = new TextDecoder('utf-8', { fatal: true });
const pathOrder = (left, right) =>
  Buffer.compare(Buffer.from(left, 'utf8'), Buffer.from(right, 'utf8'));
const asBytes = (value) => (Buffer.isBuffer(value) ? value : Buffer.from(String(value), 'utf8'));
const sha256Bytes = (value) => createHash('sha256').update(asBytes(value)).digest('hex');
const gitObject = (repoRoot, args) =>
  execFileSync('git', args, { cwd: repoRoot, stdio: ['ignore', 'pipe', 'pipe'] });
const errorText = (error) => String(error?.stderr ?? error?.message ?? error);

function decodeUtf8(value, label) {
  try {
    return utf8.decode(asBytes(value));
  } catch {
    throw new Error(`${label} is not valid UTF-8`);
  }
}

function templatePathKind(path) {
  const roots = [FORM_ROOT, REPORT_ROOT];
  const root = roots.find((candidate) => path.startsWith(`${candidate}/`));
  if (!root) throw new Error(`template manifest contains out-of-scope path ${path}`);

  const leaf = path.slice(root.length + 1);
  if (!leaf || leaf.includes('/') || !/^[A-Za-z0-9_.-]+\.json$/.test(leaf)) {
    throw new Error(`template manifest contains unsupported path ${path}`);
  }
  if (path === FORM_INDEX) return 'form-index';
  if (path === REPORT_INDEX) return 'report-index';
  if (root === FORM_ROOT && leaf.endsWith(FORM_SPEC_SUFFIX)) return 'form-spec';
  if (root === FORM_ROOT && leaf.endsWith(FORM_LAYOUT_SUFFIX)) return 'form-layout';
  if (root === REPORT_ROOT && leaf.endsWith(REPORT_SPEC_SUFFIX)) return 'report-spec';
  throw new Error(`template manifest contains unsupported JSON asset ${path}`);
}

/** Parse `git ls-tree -r -z` output and require an exact set of ordinary JSON blobs. */
export function templateBundleTreeEntries(gitListing) {
  const listing = decodeUtf8(gitListing, 'template Git tree listing');
  if (listing && !listing.endsWith('\0')) {
    throw new Error('template Git tree listing is not NUL terminated');
  }

  const entries = listing
    .split('\0')
    .filter(Boolean)
    .map((record) => {
      const separator = record.indexOf('\t');
      const metadata = separator < 0 ? '' : record.slice(0, separator);
      const path = separator < 0 ? '' : record.slice(separator + 1);
      const match = metadata.match(/^([0-7]{6}) ([a-z]+) ([0-9a-f]{40,64})$/i);
      if (!match || !path) throw new Error('template Git tree listing contains an invalid entry');
      const [, mode, type, oid] = match;
      if (type !== 'blob' || !REGULAR_FILE_MODE.test(mode)) {
        throw new Error(`template path ${path} is not a regular Git blob`);
      }
      templatePathKind(path);
      return Object.freeze({ mode, type, oid: oid.toLowerCase(), path });
    });

  const paths = entries.map(({ path }) => path);
  if (new Set(paths).size !== paths.length) {
    throw new Error('template Git tree listing contains duplicate paths');
  }
  for (const index of REQUIRED_INDEXES) {
    if (!paths.includes(index))
      throw new Error(`template manifest is missing required index ${index}`);
  }
  return Object.freeze(entries.sort((left, right) => pathOrder(left.path, right.path)));
}

function record(value, path) {
  if (value === null || typeof value !== 'object' || Array.isArray(value)) {
    throw new Error(`template JSON ${path} must contain an object`);
  }
  return value;
}

function integer(value, path, field) {
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new Error(`template JSON ${path} has invalid ${field}`);
  }
  return value;
}

function countRecord(value, path, field) {
  const source = record(value, path);
  const stable = {};
  for (const key of Object.keys(source).sort(pathOrder)) {
    if (!key) throw new Error(`template JSON ${path} has an empty ${field} key`);
    stable[key] = integer(source[key], path, `${field}.${key}`);
  }
  return stable;
}

function sameCountRecord(left, right) {
  const leftKeys = Object.keys(left).sort(pathOrder);
  const rightKeys = Object.keys(right).sort(pathOrder);
  return (
    leftKeys.length === rightKeys.length &&
    leftKeys.every((key, index) => key === rightKeys[index] && left[key] === right[key])
  );
}

function leafIdentity(path, suffix) {
  const leaf = path.slice(path.lastIndexOf('/') + 1);
  return leaf.slice(0, -suffix.length);
}

function validateFormAsset(path, value, suffix) {
  const spec = record(value, path);
  const expectedName = leafIdentity(path, suffix);
  if (spec.form !== expectedName) {
    throw new Error(
      `template JSON ${path} names form ${String(spec.form)} instead of ${expectedName}`,
    );
  }
  if (!Array.isArray(spec.controls)) {
    throw new Error(`template JSON ${path} has invalid controls`);
  }
  if (integer(spec.controlCount, path, 'controlCount') !== spec.controls.length) {
    throw new Error(`template JSON ${path} controlCount does not match controls`);
  }
  return spec;
}

function validateReportSpec(path, value) {
  const spec = record(value, path);
  const expectedName = leafIdentity(path, REPORT_SPEC_SUFFIX);
  if (spec.report !== expectedName) {
    throw new Error(
      `template JSON ${path} names report ${String(spec.report)} instead of ${expectedName}`,
    );
  }
  if (!Array.isArray(spec.areas) || !Array.isArray(spec.formulas)) {
    throw new Error(`template JSON ${path} has invalid areas or formulas`);
  }
  let sectionCount = 0;
  let objectCount = 0;
  for (const [areaIndex, areaValue] of spec.areas.entries()) {
    const area = record(areaValue, `${path} areas[${areaIndex}]`);
    if (!Array.isArray(area.sections)) {
      throw new Error(`template JSON ${path} has invalid sections`);
    }
    sectionCount += area.sections.length;
    for (const [sectionIndex, sectionValue] of area.sections.entries()) {
      const section = record(sectionValue, `${path} sections[${sectionIndex}]`);
      if (!Array.isArray(section.objects)) {
        throw new Error(`template JSON ${path} has invalid objects`);
      }
      objectCount += section.objects.length;
    }
  }
  const metrics = {
    areas: spec.areas.length,
    sections: sectionCount,
    objects: objectCount,
    formulas: spec.formulas.length,
  };
  for (const [field, actual] of Object.entries({
    sectionCount: sectionCount,
    objectCount: objectCount,
    formulaCount: spec.formulas.length,
  })) {
    if (integer(spec[field], path, field) !== actual) {
      throw new Error(`template JSON ${path} ${field} does not match its content`);
    }
  }
  return { spec, metrics };
}

function indexRows(value, path, idField) {
  if (!Array.isArray(value) || value.length === 0) {
    throw new Error(`template index ${path} must contain a nonempty array`);
  }
  const rows = new Map();
  for (const [index, valueRow] of value.entries()) {
    const row = record(valueRow, `${path}[${index}]`);
    const id = row[idField];
    if (typeof id !== 'string' || !id || !/^[A-Za-z0-9_.-]+$/.test(id)) {
      throw new Error(`template index ${path} has invalid ${idField} at row ${index}`);
    }
    if (rows.has(id)) throw new Error(`template index ${path} contains duplicate ${idField} ${id}`);
    rows.set(id, row);
  }
  return rows;
}

function requireExactIndex(index, specs, indexPath, label) {
  const missing = [...specs.keys()].filter((id) => !index.has(id)).sort(pathOrder);
  const unexpected = [...index.keys()].filter((id) => !specs.has(id)).sort(pathOrder);
  if (missing.length || unexpected.length) {
    throw new Error(
      `template index ${indexPath} does not equal ${label} basenames` +
        `${missing.length ? `; missing ${missing.join(', ')}` : ''}` +
        `${unexpected.length ? `; unexpected ${unexpected.join(', ')}` : ''}`,
    );
  }
}

function validateFormIndex(indexValue, formSpecs) {
  const index = indexRows(indexValue, FORM_INDEX, 'form');
  requireExactIndex(index, formSpecs, FORM_INDEX, 'form spec');
  for (const [name, spec] of formSpecs) {
    const row = index.get(name);
    const metrics = {
      controlCount: spec.controlCount,
      grids: Array.isArray(spec.grids) ? spec.grids.length : spec.grids,
      tabs: Array.isArray(spec.tabs) ? spec.tabs.length : spec.tabs,
      gridColumns: Array.isArray(spec.gridColumns) ? spec.gridColumns.length : spec.gridColumns,
    };
    for (const [field, actual] of Object.entries(metrics)) {
      if (integer(row[field], FORM_INDEX, `${name}.${field}`) !== actual) {
        throw new Error(`template index ${FORM_INDEX} has stale ${field} for ${name}`);
      }
    }
    const indexedKinds = countRecord(row.byKind, FORM_INDEX, `${name}.byKind`);
    const specKinds = countRecord(spec.byKind, `${FORM_ROOT}/${name}${FORM_SPEC_SUFFIX}`, 'byKind');
    if (!sameCountRecord(indexedKinds, specKinds)) {
      throw new Error(`template index ${FORM_INDEX} has stale byKind for ${name}`);
    }
  }
}

function validateReportIndex(indexValue, reportSpecs) {
  const index = indexRows(indexValue, REPORT_INDEX, 'report');
  requireExactIndex(index, reportSpecs, REPORT_INDEX, 'report spec');
  for (const [name, value] of reportSpecs) {
    const row = index.get(name);
    for (const [field, actual] of Object.entries(value.metrics)) {
      if (integer(row[field], REPORT_INDEX, `${name}.${field}`) !== actual) {
        throw new Error(`template index ${REPORT_INDEX} has stale ${field} for ${name}`);
      }
    }
  }
}

/** Hash an already-hashed entry manifest using the documented stable JSON contract. */
export function templateBundleManifestSha256(entries) {
  if (!Array.isArray(entries) || entries.length === 0) {
    throw new Error('template digest requires a nonempty entry manifest');
  }
  const stable = entries
    .map(({ path, sha256 }) => {
      if (typeof path !== 'string' || !SHA256.test(String(sha256))) {
        throw new Error('template digest contains an invalid entry');
      }
      return { path, sha256: String(sha256).toLowerCase() };
    })
    .sort((left, right) => pathOrder(left.path, right.path));
  if (new Set(stable.map(({ path }) => path)).size !== stable.length) {
    throw new Error('template digest contains duplicate paths');
  }
  return sha256Bytes(Buffer.from(JSON.stringify(stable), 'utf8'));
}

/** Validate and identify exact raw bytes for one complete form/report template bundle. */
export function templateBundleIdentity(rawEntries) {
  if (!Array.isArray(rawEntries) || rawEntries.length === 0) {
    throw new Error('template bundle must contain a nonempty entry set');
  }
  const entries = rawEntries
    .map(({ path, bytes }) => ({ path, bytes: asBytes(bytes), kind: templatePathKind(path) }))
    .sort((left, right) => pathOrder(left.path, right.path));
  if (new Set(entries.map(({ path }) => path)).size !== entries.length) {
    throw new Error('template bundle contains duplicate paths');
  }
  for (const index of REQUIRED_INDEXES) {
    if (!entries.some(({ path }) => path === index)) {
      throw new Error(`template manifest is missing required index ${index}`);
    }
  }

  const parsed = new Map();
  const formSpecs = new Map();
  const formLayouts = new Map();
  const reportSpecs = new Map();
  for (const entry of entries) {
    let value;
    try {
      value = JSON.parse(decodeUtf8(entry.bytes, `template JSON ${entry.path}`));
    } catch (error) {
      if (String(error?.message ?? '').includes('is not valid UTF-8')) throw error;
      throw new Error(`template JSON ${entry.path} is invalid: ${String(error?.message ?? error)}`);
    }
    parsed.set(entry.path, value);
    if (entry.kind === 'form-spec') {
      const spec = validateFormAsset(entry.path, value, FORM_SPEC_SUFFIX);
      formSpecs.set(spec.form, spec);
    } else if (entry.kind === 'form-layout') {
      const spec = validateFormAsset(entry.path, value, FORM_LAYOUT_SUFFIX);
      if (formLayouts.has(spec.form)) {
        throw new Error(`template bundle contains duplicate form layout ${spec.form}`);
      }
      formLayouts.set(spec.form, spec);
    } else if (entry.kind === 'report-spec') {
      const value = validateReportSpec(entry.path, parsed.get(entry.path));
      reportSpecs.set(value.spec.report, value);
    }
  }
  if (formSpecs.size === 0) throw new Error('template bundle contains no form specs');
  if (formLayouts.size === 0) throw new Error('template bundle contains no form layouts');
  if (reportSpecs.size === 0) throw new Error('template bundle contains no report specs');
  validateFormIndex(parsed.get(FORM_INDEX), formSpecs);
  validateReportIndex(parsed.get(REPORT_INDEX), reportSpecs);

  const templateEntries = Object.freeze(
    entries.map(({ path, bytes }) => Object.freeze({ path, sha256: sha256Bytes(bytes) })),
  );
  const formEntries = templateEntries.filter(({ path }) => path.startsWith(`${FORM_ROOT}/`));
  const reportEntries = templateEntries.filter(({ path }) => path.startsWith(`${REPORT_ROOT}/`));
  return Object.freeze({
    templateSha256: templateBundleManifestSha256(templateEntries),
    templateFileCount: templateEntries.length,
    formTemplateSha256: templateBundleManifestSha256(formEntries),
    formTemplateFileCount: formEntries.length,
    formSpecCount: formSpecs.size,
    formLayoutCount: formLayouts.size,
    reportTemplateSha256: templateBundleManifestSha256(reportEntries),
    reportTemplateFileCount: reportEntries.length,
    reportSpecCount: reportSpecs.size,
    templateEntries,
  });
}

const emptyObservation = (error) =>
  Object.freeze({
    templateSha256: null,
    templateFileCount: null,
    formTemplateSha256: null,
    formTemplateFileCount: null,
    formSpecCount: null,
    formLayoutCount: null,
    reportTemplateSha256: null,
    reportTemplateFileCount: null,
    reportSpecCount: null,
    templateEntries: Object.freeze([]),
    error: errorText(error),
  });

/** Observe template bytes from the live worktree while HEAD supplies the exact allowed file set. */
export function observeCandidateTemplateBundle(
  repoRoot,
  runGit = gitObject,
  readFile = readFileSync,
  lstat = lstatSync,
) {
  try {
    const listing = runGit(repoRoot, ['ls-tree', '-r', '-z', 'HEAD', '--', ...TEMPLATE_PATHSPECS]);
    const treeEntries = templateBundleTreeEntries(listing);
    return templateBundleIdentity(
      treeEntries.map(({ path }) => {
        const fullPath = resolve(repoRoot, path);
        if (!lstat(fullPath).isFile()) {
          throw new Error(`candidate template path ${path} is not a regular worktree file`);
        }
        return { path, bytes: readFile(fullPath) };
      }),
    );
  } catch (error) {
    return emptyObservation(error);
  }
}

/** Derive the independently expected template identity exclusively from an immutable Git commit. */
export function expectedCandidateTemplateBundleFromGit(repoRoot, releaseSha, runGit = gitObject) {
  const candidate = String(releaseSha ?? '')
    .trim()
    .toLowerCase();
  if (!COMMIT_SHA.test(candidate)) {
    throw new Error('release commit must be an exact 40-character hexadecimal object id');
  }
  const resolved = asBytes(runGit(repoRoot, ['rev-parse', '--verify', `${candidate}^{commit}`]))
    .toString('utf8')
    .trim()
    .toLowerCase();
  if (!COMMIT_SHA.test(resolved) || resolved !== candidate) {
    throw new Error(`release commit ${candidate} did not resolve to that exact commit object`);
  }
  const listing = runGit(repoRoot, ['ls-tree', '-r', '-z', candidate, '--', ...TEMPLATE_PATHSPECS]);
  const treeEntries = templateBundleTreeEntries(listing);
  const identity = templateBundleIdentity(
    treeEntries.map(({ oid, path }) => ({
      path,
      bytes: runGit(repoRoot, ['cat-file', 'blob', oid]),
    })),
  );
  return Object.freeze({ releaseSha: candidate, ...identity });
}

/** Read the future runner's independently supplied expectation without silently defaulting it. */
export function expectedCandidateTemplateBundle(env) {
  return Object.freeze({
    templateSha256: String(env.RELEASE_TEMPLATE_SHA256 ?? '')
      .trim()
      .toLowerCase(),
  });
}

/** Fail closed for absent, malformed, unreadable or mismatched template bundle identities. */
export function candidateTemplateBundleProblems(expected, observed) {
  const problems = [];
  const supplied = String(expected?.templateSha256 ?? '')
    .trim()
    .toLowerCase();
  const actual = String(observed?.templateSha256 ?? '').toLowerCase();
  if (!supplied) {
    problems.push(
      'RELEASE_TEMPLATE_SHA256 is required to bind certification to the candidate template bundle',
    );
  } else if (!SHA256.test(supplied)) {
    problems.push('RELEASE_TEMPLATE_SHA256 must be an exact 64-character SHA-256 digest');
  } else if (!SHA256.test(actual)) {
    problems.push('RELEASE_TEMPLATE_SHA256 could not be observed from the candidate checkout');
  } else if (actual !== supplied) {
    problems.push(
      `RELEASE_TEMPLATE_SHA256 ${supplied} does not match candidate checkout ${actual}`,
    );
  }
  if (observed?.error) {
    problems.push(`candidate template bundle identity could not be observed: ${observed.error}`);
  }
  return problems;
}
