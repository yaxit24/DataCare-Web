import { readFileSync, existsSync, readdirSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';

/**
 * Form Layout engine — renders the extracted desktop WinForms layouts (form-specs/<name>.initcomp.json
 * or .layout.json: controls with pixel Location/Size + kind + label text) as an absolutely-positioned
 * HTML preview that matches the desktop screen coordinates. Shows the exact field/grid/tab/button
 * arrangement of each of the 177 forms (TR_SALE's 8 grids incl. old-gold/order-adjust, etc.).
 */
const SPEC_DIR = resolve(dirname(fileURLToPath(import.meta.url)), '../../../form-specs');

const esc = (s: unknown): string =>
  String(s ?? '').replace(
    /[&<>"]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c] as string,
  );
const XY = (s: unknown): [number, number] => {
  const m = String(s ?? '').match(/(-?\d+)\s*,\s*(-?\d+)/);
  return m ? [Number(m[1] ?? 0), Number(m[2] ?? 0)] : [0, 0];
};
const clean = (t: unknown): string => String(t ?? '').replace(/&(?=\w)/g, '');

export function loadFormLayout(name: string): any | null {
  const n = String(name).replace(/[^\w.-]/g, '');
  for (const suf of ['.initcomp.json', '.layout.json']) {
    const p = resolve(SPEC_DIR, n + suf);
    if (existsSync(p)) return JSON.parse(readFileSync(p, 'utf8'));
  }
  // resx layouts are prefixed DataCareNext.
  const p2 = resolve(SPEC_DIR, 'DataCareNext.' + n + '.layout.json');
  return existsSync(p2) ? JSON.parse(readFileSync(p2, 'utf8')) : null;
}

export function listFormLayouts(): {
  form: string;
  controlCount: number;
  grids: number;
  tabs: number;
}[] {
  const out: Record<string, any> = {};
  for (const f of readdirSync(SPEC_DIR)) {
    if (!f.endsWith('.json') || f.includes('index')) continue;
    try {
      const d = JSON.parse(readFileSync(resolve(SPEC_DIR, f), 'utf8'));
      const form = String(d.form || f)
        .replace(/^DataCareNext\./, '')
        .replace(/\.(initcomp|layout)$/, '');
      const bk = d.byKind || {};
      const cur = out[form];
      const rec = {
        form,
        controlCount: d.controlCount || 0,
        grids: d.grids?.length ?? bk.grid ?? 0,
        tabs: d.tabs?.length ?? bk.tab ?? 0,
        inputs:
          (bk.textbox || 0) + (bk.combo || 0) + (bk.masked || 0) + (bk.date || 0) + (bk.check || 0),
        buttons: bk.button || 0,
      };
      if (!cur || rec.controlCount > cur.controlCount) out[form] = rec; // prefer richer (initcomp over resx shell)
    } catch {
      /* skip */
    }
  }
  return Object.values(out).sort((a: any, b: any) => b.controlCount - a.controlCount);
}

export function renderFormLayout(spec: any): string {
  const controls: any[] = spec.controls || [];
  let maxW = 200,
    maxH = 120;
  // containers (panel/grid/tab) render first (behind), inputs/labels/buttons on top
  const order = (c: any) => (['panel', 'grid', 'tab'].includes(c.kind) ? 0 : 1);
  const sorted = [...controls].sort((a, b) => order(a) - order(b));
  const els = sorted
    .map((c) => {
      const [x, y] = XY(c.location);
      const [w0, h0] = XY(c.size);
      const w = w0 || 80,
        h = h0 || 22;
      maxW = Math.max(maxW, x + w);
      maxH = Math.max(maxH, y + h);
      const st = `position:absolute;left:${x}px;top:${y}px;width:${w}px;height:${h}px;`;
      const t = esc(clean(c.text));
      switch (c.kind) {
        case 'label':
          return `<div class="c lbl" style="${st}">${t}</div>`;
        case 'button':
          return `<button class="c btn" style="${st}" disabled>${t || esc(c.name)}</button>`;
        case 'check':
        case 'radio':
          return `<label class="c chk" style="${st}"><input type="checkbox" disabled/> ${t}</label>`;
        case 'combo':
          return `<div class="c inp cmb" style="${st}">${t}<span class="caret">▾</span></div>`;
        case 'date':
          return `<div class="c inp" style="${st}">${t || 'dd/mm/yyyy'} <span class="caret">▦</span></div>`;
        case 'grid':
          return `<div class="c grd" style="${st}"><span class="glab">▤ ${esc(c.name)}</span></div>`;
        case 'panel':
        case 'tab':
          return `<div class="c pnl" style="${st}"></div>`;
        case 'textbox':
        case 'masked':
          return `<div class="c inp" style="${st}">${t}</div>`;
        default:
          return `<div class="c oth" style="${st}"></div>`;
      }
    })
    .join('');
  const bk = spec.byKind || {};
  const legend = Object.entries(bk)
    .map(([k, v]) => `${k}:${v}`)
    .join(' · ');
  return `<!doctype html><html><head><meta charset="utf-8"><title>${esc(spec.form)}</title><style>
    *{box-sizing:border-box} body{margin:0;background:#e9edf2;font-family:'Segoe UI',Tahoma,Arial,sans-serif;font-size:12px}
    .wrap{margin:12px auto;width:max-content}
    .titlebar{background:#0b5cab;color:#fff;font-weight:600;padding:5px 10px;border-radius:6px 6px 0 0}
    .form{position:relative;background:#f0f0f0;border:1px solid #b9c2cc;}
    .c{overflow:hidden}
    .lbl{color:#222;line-height:1.4;font-size:12px;padding-top:2px}
    .inp{background:#fff;border:1px solid #7a8aa0;border-radius:2px;padding:1px 4px;line-height:1.5;color:#111}
    .cmb .caret,.inp .caret{float:right;color:#666}
    .btn{background:linear-gradient(#fafafa,#e4e8ee);border:1px solid #8895a6;border-radius:3px;font-size:12px;color:#111;cursor:default}
    .chk{color:#222} .pnl{background:rgba(255,255,255,.35);border:1px solid #cdd6e0;border-radius:3px}
    .grd{background:#fff;border:1px solid #5b6b82;} .grd .glab{display:block;background:#dce6f2;border-bottom:1px solid #5b6b82;padding:1px 5px;font-size:10px;color:#123}
    .noprint{width:max-content;margin:8px auto 0}
    @media print{body{background:#fff}.noprint{display:none}}
  </style></head><body>
    <div class="noprint muted">Desktop form layout (pixel-exact) — ${esc(spec.form)} · ${spec.controlCount} controls · ${esc(legend)}</div>
    <div class="wrap">
      <div class="titlebar">${esc(spec.form)}</div>
      <div class="form" style="width:${maxW + 16}px;height:${maxH + 16}px;">${els}</div>
    </div>
  </body></html>`;
}
