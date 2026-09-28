#!/usr/bin/env node
/**
 * gen_master_formfields.mjs — turn real master-table columns into rich FormField[]
 * so the generic web master form renders the FULL desktop-equivalent field set
 * instead of 2–5 key columns.
 *
 * Input : /tmp/master_cols.tsv   (table \t column \t data_type \t ordinal)
 * Output: apps/api/src/modules/masters/generated-formfields.ts
 *         export const GENERATED_FORM_FIELDS: Record<string, FormField[]>
 *
 * Used as a FALLBACK in app.ts /masters/:name/meta when a config has no explicit
 * formFields. Additive only — no schema changes, no override of the 4 curated
 * configs (AC_MAST, ITEM_MAST, GROUP_MAST, CO_MAST keep their hand-tuned fields).
 */
import fs from 'node:fs';
import path from 'node:path';

const TSV = '/tmp/master_cols.tsv';
const OUT = path.resolve(process.argv[2] ||
  'apps/api/src/modules/masters/generated-formfields.ts');

// system / audit columns never shown on a form
const DENY = new Set([
  'tenant_id', 'row_id', 'MAIN_USER', 'DATA_TRFR', 'ENT_BY', 'ENT_DATE', 'ENT_TIME',
  'UPDATE_BY', 'UPDATE_DATE', 'UP_BY', 'UP_DATE', 'UPD_BY', 'UPD_DATE', 'MOD_BY',
  'MOD_DATE', 'DEL_FLAG', 'DELETE_FLAG', 'SYNC_FLAG', 'ENTRY_BY', 'ENTRY_DATE',
  'USER_ID', 'EDIT_BY', 'EDIT_DATE', 'TRFR_DATE', 'DATA_TYPE',
]);

const NUMERIC = new Set([
  'numeric', 'integer', 'bigint', 'smallint', 'double precision', 'real', 'decimal', 'money',
]);

// exact-column curated selects (enums the desktop uses)
const SELECTS = {
  GR_TYPE: [['G', 'Gold'], ['S', 'Silver'], ['B', 'Both']],
  METAL_TYPE: [['G', 'Gold'], ['S', 'Silver'], ['B', 'Both']],
  WORK_TYPE: [['R', 'Retail'], ['W', 'Wholesale'], ['M', 'Manufacturing']],
  AC_GST_TYPE: [['R', 'Regular'], ['C', 'Composition'], ['U', 'Unregistered'], ['E', 'Exempt']],
  RATE_DISPLAY: [['Y', 'Yes'], ['N', 'No']],
};

// acronym dictionary for humanized labels
const ACR = {
  AC: 'A/c', NO: 'No', AMT: 'Amount', PRC: '%', WT: 'Weight', GR: 'Group', DESC: 'Description',
  QTY: 'Qty', PCS: 'Pieces', GST: 'GST', HSN: 'HSN', PAN: 'PAN', PIN: 'PIN', IFSC: 'IFSC',
  UPI: 'UPI', HUID: 'HUID', ID: 'ID', LST: 'LST', CST: 'CST', TDS: 'TDS', TCS: 'TCS',
  CO: 'Company', LC: 'Location', DM: 'Diamond', MFG: 'Mfg', IT: 'Item', LBR: 'Labour',
  MOB: 'Mobile', TEL: 'Phone', ADD: 'Address', ADD1: 'Address 1', ADD2: 'Address 2',
  ADD3: 'Address 3', DT: 'Date', SM: 'Sub', PR: 'Product', EMP: 'Employee', SCHM: 'Scheme',
  INT: 'Interest', OP: 'Opening', CL: 'Closing', BAL: 'Balance', CR: 'Credit', DR: 'Debit',
};

function label(col) {
  return col.split('_').map((t) => {
    if (ACR[t]) return ACR[t];
    if (/^[A-Z]{2,4}$/.test(t) && ['GST', 'HSN', 'PAN', 'PIN', 'IFSC', 'UPI', 'HUID', 'LST', 'CST', 'TDS', 'TCS', 'ID'].includes(t)) return t;
    return t.charAt(0) + t.slice(1).toLowerCase();
  }).join(' ').replace(/\s+/g, ' ').trim();
}

/** Classify a column into a logical form section/tab (checked in priority order). */
function groupOf(col) {
  const c = col.toUpperCase();
  if (/^BANK|IFSC|RTGS/.test(c)) return 'Bank';
  if (/GST|PAN|LST|CST|TIN|VAT|ADHAR|AADHAR|HSN|TDS|TCS/.test(c)) return 'Tax & GST';
  if (/MOBILE|PHONE|TEL|EMAIL|MAIL|FAX|WEB|URL/.test(c)) return 'Contact';
  if (/ADD\d?$|_ADD|^ADD|CITY|PIN|STATE|AREA|DISTRICT|COUNTRY|ZIP|NOMINEE/.test(c)) return 'Address';
  if (/DATE|BIRTH|ANV|DOB|JOIN|EXP|L_BR/.test(c)) return 'Dates';
  if (/OP_|OPEN|_BAL|BALANCE|CR_DAYS|LIMIT|INT_|_INT$|CREDIT|DEBIT|DISC|BONUS|AMT/.test(c)) return 'Balances & Terms';
  if (/CODE$|_CODE|NAME|SHORT|^CO_|^LC_|GR_|_GR$|TYPE$|MELT|TOUCH|WEST/.test(c)) return 'General';
  return 'Other';
}

function fieldFor(table, col, dataType) {
  const f = { col, label: label(col), group: groupOf(col) };
  // curated select
  if (SELECTS[col]) {
    f.type = 'select';
    f.options = SELECTS[col].map(([value, l]) => ({ value, label: l }));
    return f;
  }
  // curated lookups (avoid self-lookup on this table's own key namespace)
  if (col.endsWith('_AC')) { f.type = 'lookup'; f.entity = 'accounts'; return f; }
  if (col === 'STATE_CODE') { f.type = 'lookup'; f.entity = 'states'; return f; }
  if (col === 'GR_CODE' && table !== 'GROUP_MAST') { f.type = 'lookup'; f.entity = 'groups'; return f; }
  if (col === 'AC_GR' && table !== 'AC_GROUP') { f.type = 'lookup'; f.entity = 'ac-groups'; return f; }
  if ((col === 'IT_CODE' || col === 'ITEM_CODE') && table !== 'ITEM_MAST') { f.type = 'lookup'; f.entity = 'items'; return f; }
  if (col === 'EMP_CODE' && table !== 'EMP_MAST') { f.type = 'lookup'; f.entity = 'employees'; return f; }
  // primitive type inference
  const dt = dataType.toLowerCase();
  if (dt.includes('date') || dt.includes('timestamp')) f.type = 'date';
  else if (NUMERIC.has(dt)) f.type = 'number';
  return f;
}

// ---- read + group ----
const byTable = {};
for (const line of fs.readFileSync(TSV, 'utf8').split('\n')) {
  if (!line.trim()) continue;
  const [table, col, dataType] = line.split('\t');
  if (DENY.has(col)) continue;
  (byTable[table] ||= []).push(fieldFor(table, col, dataType || 'character varying'));
}

// ---- emit ----
const tables = Object.keys(byTable).sort();
let out = `// AUTO-GENERATED by unified/tools/gen_master_formfields.mjs — do not edit by hand.\n`;
out += `// Full per-table field sets derived from the live DB columns (${tables.length} master tables).\n`;
out += `import type { FormField } from './master.service.js';\n\n`;
out += `export const GENERATED_FORM_FIELDS: Record<string, FormField[]> = {\n`;
for (const t of tables) {
  out += `  ${t}: [\n`;
  for (const f of byTable[t]) out += `    ${JSON.stringify(f)},\n`;
  out += `  ],\n`;
}
out += `};\n`;
fs.writeFileSync(OUT, out);
const total = tables.reduce((n, t) => n + byTable[t].length, 0);
console.log(`generated ${tables.length} tables, ${total} fields -> ${OUT}`);
for (const t of tables) console.log(`  ${t}: ${byTable[t].length} fields`);
