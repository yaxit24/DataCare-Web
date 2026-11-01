import type { RptObject, RptSection, RptSpec } from './reportEngine.js';
import type { ParentChildBands, ReportRow } from './reportBindingContract.js';
import { UnsupportedReportBindingError, resolveReportBinding } from './reportBindingContract.js';
import { suppressOrderField, type BoundSubreport } from './orderReportValues.js';
import { orderReportImageUri, type OrderReportImages } from './orderReportImages.js';

export interface OrderLayoutOptions {
  header?: ReportRow;
  detailRows?: ReportRow[];
  parentChild?: ParentChildBands;
  subreports?: Record<string, BoundSubreport>;
  orderImages?: OrderReportImages;
  company?: string;
}
const esc = (value: unknown) =>
  String(value ?? '').replace(
    /[&<>"']/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' })[c]!,
  );
const px = (twips: number) => twips / 15;
interface Block {
  html: string;
  height: number;
}

/** Bounded order layout: independently scoped OrdRec, typed precomputed formulas and real pages. */
export function renderOrderReportLayout(spec: RptSpec, options: OrderLayoutOptions): string {
  const contract = resolveReportBinding(spec);
  const fail = (reason: string): never => {
    throw new UnsupportedReportBindingError(spec.report, reason);
  };
  if (!options.header || !options.subreports?.OrdRec) return fail('missing-order-render-datasets');
  const sections = spec.areas.flatMap((area) => area.sections);
  const header = options.header;
  const field = (source: string, row: ReportRow): string => {
    if (source === '{@CurPag}') return '__ORDER_PAGE_NUMBER__';
    if (source in row) return row[source]!;
    const key = source.replace(/^\{|\}$/g, '');
    if (key in row) return row[key]!;
    return fail(`missing-order-field:${source}`);
  };
  const object = (o: RptObject, row: ReportRow): { html: string; bottom: number } => {
    if (o.suppressed || suppressOrderField(o.suppressWhen, row)) return { html: '', bottom: 0 };
    const value =
      o.type === 'TextObject'
        ? (o.text ?? '')
        : o.type === 'FieldObject'
          ? field(o.dataSource ?? '', row)
          : '';
    const font = o.font;
    const fontPx = ((font?.points ?? 9) * 4) / 3;
    // Reserve conservative growth space before page allocation; content is never clipped for CanGrow.
    const textLines = value
      .split('\n')
      .reduce(
        (sum, line) =>
          sum + Math.max(1, Math.ceil(line.length / Math.max(1, Math.floor(px(o.width) / fontPx)))),
        0,
      );
    const height = o.canGrow ? Math.max(px(o.height), textLines * fontPx * 1.2) : px(o.height);
    const align =
      o.alignment === 'RightAlign'
        ? 'right'
        : o.alignment === 'HorizontalCenterAlign'
          ? 'center'
          : 'left';
    const style =
      `position:absolute;left:${px(o.left)}px;top:${px(o.top)}px;width:${px(o.width)}px;height:${height}px;` +
      `font-size:${fontPx}px;font-family:${esc(font?.name ?? 'Arial')},sans-serif;font-weight:${font?.bold ? 700 : 400};` +
      `font-style:${font?.italic ? 'italic' : 'normal'};text-align:${align};`;
    if (o.type === 'BlobFieldObject') {
      if (
        !contract.orderDocument?.images ||
        o.name !== 'Field22' ||
        o.dataSource !== '{IMAGE_DATA.TAG_IMAGE}'
      )
        return fail('unsupported-order-blob-field');
      const parentKey = row['SL_ORD_DETL.SR_NO'] ?? '';
      if (!options.orderImages || !Object.hasOwn(options.orderImages, parentKey))
        return fail(`missing-order-parent-image-state:${parentKey}`);
      const uri = orderReportImageUri(spec.report, options.orderImages[parentKey]!);
      return {
        html: uri
          ? `<img class="order-object order-image" data-object="${esc(o.name)}" data-field="${esc(o.dataSource)}" data-parent="${esc(parentKey)}" alt="${esc(row['@ItemName'] ?? 'Item image')}" src="${uri}" style="${style}object-fit:contain;">`
          : `<div class="order-object order-image-absent" data-parent="${esc(parentKey)}" style="${style}"></div>`,
        bottom: px(o.top) + height,
      };
    }
    if (o.type === 'LineObject' || o.type === 'BoxObject') {
      const border =
        o.type === 'BoxObject'
          ? 'border:1px solid #333;'
          : o.width === 0
            ? 'border-left:1px solid #333;'
            : 'border-top:1px solid #333;';
      // Crystal border lines can deliberately extend through later bands. Their geometry must
      // not inflate the owning band, or the half-page advance voucher loses all printable space.
      return { html: `<div style="${style}${border}"></div>`, bottom: 0 };
    }
    if (!['TextObject', 'FieldObject'].includes(o.type))
      return fail(`unsupported-visible-order-object:${o.type}`);
    return {
      html: `<div class="order-object" data-object="${esc(o.name)}" data-field="${esc(o.dataSource ?? '')}" style="${style}">${esc(value)}</div>`,
      bottom: px(o.top) + height,
    };
  };
  const band = (section: RptSection, row: ReportRow, subreport?: string): Block | null => {
    if (section.suppressed || suppressOrderField(section.suppressWhen, row)) return null;
    const objects = section.objects.map((o) => object(o, row));
    const height = Math.max(px(section.height), ...objects.map((o) => o.bottom));
    return {
      height,
      html: `<div class="order-band" data-section="${esc(section.name)}" data-kind="${esc(section.kind)}"${subreport ? ` data-subreport="${esc(subreport)}"` : ''} style="height:${height}px;">${objects.map((o) => o.html).join('')}</div>`,
    };
  };
  const blocks: Block[] = [];
  const emit = (section: RptSection, row: ReportRow) => {
    if (section.suppressed || suppressOrderField(section.suppressWhen, row)) return;
    const sub = section.objects.find((o) => o.type === 'SubreportObject');
    if (sub) {
      if (section.objects.length !== 1 || sub.subreportName !== 'OrdRec')
        return fail('unsupported-order-subreport-placement');
      const childSpec = spec.subreports!.OrdRec!;
      const data = options.subreports!.OrdRec!;
      // The XML's independently linked voucher-level received-metal rows must never join to SR_NO.
      for (const childSection of childSpec.areas.flatMap((area) => area.sections)) {
        for (const childRow of childSection.kind === 'Detail' ? data.detailRows : [{}]) {
          const childBand = band(childSection, { ...data.header, ...childRow }, 'OrdRec');
          if (childBand)
            blocks.push({
              ...childBand,
              html: `<div style="margin-left:${px(sub.left)}px;width:${px(sub.width)}px;">${childBand.html}</div>`,
            });
        }
      }
    } else {
      const result = band(section, row);
      if (result) blocks.push(result);
    }
  };
  const grouped = options.parentChild;
  const groupNames = grouped
    ? [...grouped.parentSections, ...grouped.childSections, ...grouped.parentFooterSections]
    : [];
  if (spec.report !== 'OrderVch' && !grouped) return fail('missing-order-parent-child-bands');
  if (contract.orderDocument?.images) {
    if (!options.orderImages) return fail('missing-order-render-images');
    const parentKeys = new Set(grouped!.groups.map((group) => group.key));
    if (Object.keys(options.orderImages).some((key) => !parentKeys.has(key)))
      return fail('orphan-order-render-image');
  }
  for (const section of sections) {
    if (section.kind === 'PageHeader' || section.kind === 'PageFooter') continue;
    if (groupNames.includes(section.name)) {
      if (section.name !== groupNames[0]) continue;
      for (const group of grouped!.groups) {
        const start = blocks.length;
        for (const name of groupNames) {
          const groupSection = sections.find((s) => s.name === name)!;
          for (const row of grouped!.childSections.includes(name) ? group.children : [{}])
            emit(groupSection, { ...header, ...group.parent, ...row });
        }
        if (contract.orderDocument?.images) {
          // A photo and the line it belongs to must stay together. Oversized image groups are
          // refused by the page allocator rather than placing an unlabelled image on another page.
          const groupBlocks = blocks.splice(start);
          blocks.push({
            height: groupBlocks.reduce((sum, block) => sum + block.height, 0),
            html: `<div class="order-image-group" data-parent="${esc(group.key)}">${groupBlocks.map((block) => block.html).join('')}</div>`,
          });
        }
      }
    } else emit(section, header);
  }
  const repeated = (kind: string) =>
    sections
      .filter((s) => s.kind === kind)
      .map((s) => band(s, header))
      .filter((b): b is Block => b != null);
  const pageHeader = repeated('PageHeader'),
    pageFooter = repeated('PageFooter');
  const contentHeight = px(Number(spec.printOptions!.PageContentHeight));
  const contentWidth = px(Number(spec.printOptions!.PageContentWidth));
  const margin = (edge: string) => px(Number(spec.printOptions![`margin${edge}`] ?? 0));
  const paperWidth = contentWidth + margin('Left') + margin('Right');
  const paperHeight = contentHeight + margin('Top') + margin('Bottom');
  const capacity =
    contentHeight - [...pageHeader, ...pageFooter].reduce((sum, b) => sum + b.height, 0);
  const pages: Block[][] = [[]];
  let used = 0;
  for (const block of blocks) {
    if (block.height > capacity) return fail('order-band-exceeds-page-capacity');
    if (used + block.height > capacity) {
      pages.push([]);
      used = 0;
    }
    pages.at(-1)!.push(block);
    used += block.height;
  }
  const render = (rows: Block[]) => rows.map((b) => b.html).join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>${esc(spec.report)}</title><style>
    *{box-sizing:border-box}body{margin:0;background:#eee;color:#111}.order-page{background:white;margin:12px auto;padding:${margin('Top')}px ${margin('Right')}px ${margin('Bottom')}px ${margin('Left')}px;break-after:page;width:${paperWidth}px;}
    .order-content{position:relative;width:${contentWidth}px;height:${contentHeight}px;display:flex;flex-direction:column}.order-main{flex:1}.order-band{position:relative;flex-shrink:0;break-inside:avoid}.order-object{white-space:pre-wrap;overflow:hidden;line-height:1.2}
    .order-footer{margin-top:auto}.noprint{margin:12px auto;width:${contentWidth}px;font:13px Arial} @page{size:${paperWidth}px ${paperHeight}px;margin:0}
    @media print{body{background:white}.order-page{margin:0}.order-page:last-child{break-after:auto}.noprint{display:none}}
    </style></head><body><div class="noprint"><button onclick="window.print()">Print</button> ${esc(spec.report)}</div>${pages
      .map((rows, index) =>
        `<article class="order-page" data-page="${index + 1}"><div class="order-content">${render(pageHeader)}<main class="order-main">${render(rows)}</main><footer class="order-footer">${render(pageFooter)}</footer></div></article>`.replaceAll(
          '__ORDER_PAGE_NUMBER__',
          String(index + 1),
        ),
      )
      .join('')}</body></html>`;
}
