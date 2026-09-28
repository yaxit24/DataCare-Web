import { readFileSync, existsSync, readdirSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { evalCrystal } from './crystalFormula.js';
import type { ParentChildBands } from './reportBindingContract.js';
import { renderOrderReportLayout } from './orderReportLayout.js';
import type { BoundSubreport } from './orderReportValues.js';
import type { OrderReportImages } from './orderReportImages.js';

/**
 * Spec-driven Crystal-report LAYOUT ENGINE. Renders the extracted RptToXml layout specs
 * (report-specs/<name>.spec.json — areas→sections→positioned Field/Text objects in twips + formulas)
 * as pixel-exact A4 HTML: bands stacked in report order, each object absolutely positioned
 * (twips→px = /15), TextObjects show their label text, FieldObjects show the bound field/formula
 * (or, when `data` is supplied, the actual value; Detail band repeats per data row).
 */
const SPEC_DIR = resolve(dirname(fileURLToPath(import.meta.url)), '../../../report-specs');

export interface RptObject {
  type: string;
  name: string;
  left: number;
  top: number;
  width: number;
  height: number;
  dataSource?: string;
  text?: string;
  suppressed?: boolean;
  suppressWhen?: string;
  canGrow?: boolean;
  subreportName?: string;
  alignment?: string;
  font?: { name: string; points: number; bold: boolean; italic: boolean };
}
export interface RptSection {
  name: string;
  kind: string;
  height: number;
  objects: RptObject[];
  suppressed?: boolean;
  suppressWhen?: string;
}
export interface RptArea {
  kind: string;
  name: string;
  sections: RptSection[];
}
export interface RptSpec {
  report: string;
  areas: RptArea[];
  formulas: { name: string; ref: string; type: string; text: string }[];
  sectionCount: number;
  objectCount: number;
  formulaCount: number;
  source?: { kind: string; xml: string; sha256: string };
  groups?: string[];
  databaseFields?: Record<string, string>;
  runningTotals?: Record<string, string>[];
  subreportLinks?: Record<string, string>[];
  subreports?: Record<string, RptSpec>;
  printOptions?: Record<string, string>;
  imageBindingEvidence?: { section: string; object: string; field: string; proof: string };
}

const esc = (s: unknown): string =>
  String(s ?? '').replace(
    /[&<>"]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c] as string,
  );
const T = (v: number): number => Math.round((Number(v) || 0) / 15); // twips → px (1px=15twips @96dpi)

export function loadReportSpec(name: string): RptSpec | null {
  const p = resolve(SPEC_DIR, String(name).replace(/[^\w.-]/g, '') + '.spec.json');
  return existsSync(p) ? JSON.parse(readFileSync(p, 'utf8')) : null;
}
export function listReportSpecs(): {
  report: string;
  areas: number;
  sections: number;
  objects: number;
  formulas: number;
}[] {
  const idx = resolve(SPEC_DIR, 'report-layouts-index.json');
  if (existsSync(idx)) return JSON.parse(readFileSync(idx, 'utf8'));
  return readdirSync(SPEC_DIR)
    .filter((f) => f.endsWith('.spec.json'))
    .map((f) => ({ report: f.slice(0, -10), areas: 0, sections: 0, objects: 0, formulas: 0 }));
}

/** derive a short label from a Crystal DataSource token like {SL_IDTL.IT_AMT} or {@Formula}. */
function fieldLabel(ds?: string): string {
  if (!ds) return '';
  const m = ds.match(/\{@?([A-Za-z0-9_. ]+)\}/);
  const raw = (m ? m[1] : ds) || '';
  const col = raw.includes('.') ? raw.split('.').pop() || raw : raw;
  return '[' + col + ']';
}

function renderObject(
  o: RptObject,
  bound: Record<string, string> | undefined,
  resolve: (ds: string, b?: Record<string, string>) => string,
): string {
  const style = `position:absolute;left:${T(o.left)}px;top:${T(o.top)}px;width:${T(o.width)}px;min-height:${T(o.height)}px;`;
  if (o.type === 'TextObject')
    return `<div class="ro tx" style="${style}">${esc(o.text || '')}</div>`;
  if (o.type === 'LineObject' || o.type === 'BoxObject')
    return `<div class="ro bx" style="${style}"></div>`;
  const val = resolve(o.dataSource || '', bound);
  return `<div class="ro fl" style="${style}" title="${esc(o.dataSource || '')}">${esc(val)}</div>`;
}

function renderSection(
  sec: RptSection,
  header: Record<string, string> | undefined,
  rows: Record<string, string>[] | undefined,
  resolve: (ds: string, b?: Record<string, string>) => string,
): string {
  const h = T(sec.height);
  const one = (bound?: Record<string, string>) =>
    `<div class="band" data-kind="${esc(sec.kind)}" style="position:relative;width:100%;min-height:${h}px;">` +
    sec.objects.map((o) => renderObject(o, bound, resolve)).join('') +
    `</div>`;
  if (sec.kind === 'Detail' && rows)
    return rows.map((r) => one({ ...(header || {}), ...r })).join('');
  return one(header);
}

export function renderReportLayout(
  spec: RptSpec,
  opts: {
    header?: Record<string, string>;
    detailRows?: Record<string, string>[];
    parentChild?: ParentChildBands;
    subreports?: Record<string, BoundSubreport>;
    orderImages?: OrderReportImages;
    company?: string;
  } = {},
): string {
  // The catalog's unbound layout preview remains a labelled placeholder view. Production order
  // documents take the dedicated contract path and require all main/subreport datasets.
  if (spec.source?.kind === 'order-xml-v1' && (opts.header || opts.detailRows))
    return renderOrderReportLayout(spec, opts);
  const bound = opts.detailRows || (opts.header && Object.keys(opts.header).length);
  const formulas: Record<string, string> = {};
  for (const f of spec.formulas || []) if (f.name) formulas[f.name] = f.text;
  const resolveField = (ds: string, b?: Record<string, string>): string => {
    const key = String(ds || '').replace(/[{}]/g, '');
    if (!key) return '';
    if (key.startsWith('@')) {
      const name = key.slice(1);
      if (formulas[name] != null) return evalCrystal(formulas[name], (ref) => resolveField(ref, b));
      return fieldLabel(ds);
    }
    return b && key in b ? (b[key] ?? '') : fieldLabel(ds);
  };
  const sections = spec.areas.flatMap((area) => area.sections);
  const grouped = opts.parentChild;
  const groupNames = grouped
    ? [...grouped.parentSections, ...grouped.childSections, ...grouped.parentFooterSections]
    : [];
  // The binder validates a contiguous, explicitly registered parent/component band block.
  // Emit the entire block for one parent, then move to the next parent. Voucher totals outside
  // the block render once. An empty child set renders no invented component/placeholder row.
  const renderParentGroups = () =>
    grouped!.groups
      .map((group) => {
        const parent = { ...opts.header, ...group.parent };
        return groupNames
          .map((name) => {
            const section = sections.find((entry) => entry.name === name)!;
            return renderSection(
              section,
              parent,
              grouped!.childSections.includes(name) ? group.children : undefined,
              resolveField,
            );
          })
          .join('');
      })
      .join('');
  const bands = sections
    .map((section) => {
      if (grouped && groupNames.includes(section.name))
        return section.name === groupNames[0] ? renderParentGroups() : '';
      return renderSection(
        section,
        opts.header,
        section.kind === 'Detail' ? opts.detailRows : undefined,
        resolveField,
      );
    })
    .join('');
  const title = spec.report;
  return `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>
    *{box-sizing:border-box} body{margin:0;background:#f4f4f4;font-family:Arial,Helvetica,sans-serif}
    .page{width:816px;margin:10px auto;background:#fff;box-shadow:0 1px 6px rgba(0,0,0,.15);padding:24px 28px;}
    .rpt-title{font-size:12px;color:#0b5cab;font-weight:700;margin:0 0 6px;} .rpt-sub{font-size:10px;color:#888;margin-bottom:8px;}
    .band{border-bottom:1px dotted #eee;} .band[data-kind^="Group"]{background:#fafcff;} .band[data-kind="PageHeader"],.band[data-kind="ReportHeader"]{background:#fcfcfc;}
    .ro{font-size:11px;line-height:1.15;overflow:hidden;white-space:pre-wrap;} .ro.tx{font-weight:600;color:#111;} .ro.fl{color:#0b5cab;} .ro.bx{border:1px solid #999;}
    .noprint{max-width:816px;margin:8px auto 0;}
    @media print{body{background:#fff}.page{box-shadow:none;margin:0}.noprint{display:none}}
  </style></head><body>
    <div class="noprint"><button onclick="window.print()">🖨 Print</button> · pixel-exact layout from Crystal spec (${spec.objectCount} objects, ${spec.formulaCount} formulas)${bound ? ' · bound to real data' : ' · [field] = data placeholder'}</div>
    <div class="page">
      <div class="rpt-title">${esc(opts.company || title)}</div><div class="rpt-sub">${esc(title)} — reconstructed from desktop Crystal layout</div>
      ${bands}
    </div>
  </body></html>`;
}
