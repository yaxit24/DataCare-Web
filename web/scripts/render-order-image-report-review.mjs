#!/usr/bin/env node
/** Synthetic rendering evidence; database identity/ledger evidence lives in orderReport.db.test.ts. */
import assert from 'node:assert/strict';
import { createHash } from 'node:crypto';
import { mkdirSync, readFileSync, writeFileSync } from 'node:fs';
import { createRequire } from 'node:module';
import { resolve } from 'node:path';
import {
  loadReportSpec,
  renderReportLayout,
} from '../apps/api/dist/modules/reports/reportEngine.js';
import { resolveReportBinding } from '../apps/api/dist/modules/reports/reportBindingContract.js';
import {
  completeOrderFields,
  orderFormulaValues,
  orderParentFormulaValues,
} from '../apps/api/dist/modules/reports/orderReportValues.js';

const requireApi = createRequire(new URL('../apps/api/package.json', import.meta.url));
const { chromium } = requireApi('playwright');
const output = resolve(process.argv[2] ?? 'output/pdf/order-image-report-round3');
mkdirSync(output, { recursive: true });
const browser = await chromium.launch({ headless: true });
const results = [];
try {
  for (const [name, count] of [
    ['OrdVchImg', 2],
    ['TourOrdImg', 2],
    ['TourOrdImg-missing', 2],
    ['TourOrdImg-long', 18],
  ]) {
    const spec = loadReportSpec(name.replace(/-(long|missing)$/, ''));
    const contract = resolveReportBinding(spec);
    const netAmount = count * 6500;
    const taxAmount = (netAmount * 3) / 100;
    const parents = Array.from({ length: count }, (_, index) =>
      orderParentFormulaValues(spec, {
        'SL_ORD_DETL.SR_NO': String(index + 1),
        'SL_ORD_DETL.ITM_PCS': '1',
        'SL_ORD_DETL.TAG_NO': index === 0 ? 'TAG-001' : '',
        'SL_ORD_DETL.DESIGN_NO': `D-${String(index + 1).padStart(3, '0')}`,
        'ITEM_MAST.IT_NAME': `Gold ring ${index + 1}`,
        'SL_ORD_DETL.ITM_GWT': '12.345',
        'SL_ORD_DETL.ITM_NWT': '11.111',
        'SL_ORD_DETL.NET_AMT': '6500',
        'SL_ORD_DETL.LBR_RATE': '250',
        'SL_ORD_DETL.OTH_AMT': '50',
        'SL_ORD_DETL.ITM_SIZE': '14',
        'SL_ORD_DETL.ITM_REMARK':
          index === 0
            ? 'Handcrafted ring; retain the engraved initials and fit the clasp to the approved design.'
            : '',
      }),
    );
    const received = [
      {
        'SL_PR_DETL.IT_DESC': 'Received gold chain',
        'SL_PR_DETL.ITM_PCS': '1',
        'SL_PR_DETL.ITM_NWT': '5.125',
        'SL_PR_DETL.ITM_TOUCH': '91.6',
        'SL_PR_DETL.ITM_RATE': '6200',
        'SL_PR_DETL.NET_AMT': '31775',
      },
      {
        'SL_PR_DETL.IT_DESC': 'Received silver bracelet',
        'SL_PR_DETL.ITM_PCS': '2',
        'SL_PR_DETL.ITM_NWT': '8.25',
        'SL_PR_DETL.ITM_TOUCH': '92.5',
        'SL_PR_DETL.ITM_RATE': '85',
        'SL_PR_DETL.NET_AMT': '701.25',
      },
    ];
    const header = orderFormulaValues(
      spec,
      completeOrderFields(spec, {
        'SL_ORD_DATA.CO_YEAR': '2026-2027',
        'SL_ORD_DATA.CO_BOOK': 'Z09',
        'SL_ORD_DATA.VCH_NO': '00001',
        'SL_ORD_DATA.AC_CODE': 'PARTY',
        'SL_ORD_DATA.AC_NAME': 'Meera Shah',
        'SL_ORD_DATA.VCH_DATE': '2026-04-03',
        'SL_ORD_DATA.DEL_DATE': '2026-04-09',
        'SL_ORD_DATA.VCH_DESC': 'Confirm delivery after the final fitting.',
        'SL_ORD_DATA.TOT_AMT': String(netAmount + taxAmount),
        'SL_ORD_DATA.NET_AMT': String(netAmount),
        'SL_ORD_DATA.TAX_PRC': '3',
        'SL_ORD_DATA.TAX_AMT': String(taxAmount),
        'SL_ORD_DATA.ADV_AMT': '2500',
        'SL_ORD_DATA.CASH_AMT': '1500',
        'SL_ORD_DATA.CARD_AMT': '1000',
        'SL_ORD_DATA.CHQ_AMT': '0',
        'CO_MAST.CO_NAME': 'Datagenex Sample Jewellery',
        'CO_MAST.CO_ADD1': '12 Market Road',
        'CO_MAST.CO_ADD2': 'Jewellery Centre',
        'CO_MAST.CO_ADD3': 'West Wing',
        'CO_MAST.CO_CITY': 'Ahmedabad',
        'CO_MAST.CO_MOBILE': '9000000000',
        'CO_MAST.CO_PHONE': '0790000000',
        'AC_MAST.AC_ADD1': '45 Garden Street',
        'AC_MAST.AC_ADD2': 'Navrangpura',
        'AC_MAST.AC_ADD3': 'Ahmedabad',
        'AC_MAST.AC_CITY': 'Gujarat',
        'AC_MAST.AC_MOBILE': '9000000001',
        'BOOK_DATA.BOOK_NAME': spec.report === 'TourOrdImg' ? 'Tour Order' : 'Sales Order',
      }),
      parents,
      received,
      { opening: '-500', closing: '2000' },
      'O',
    );
    const orderImages = Object.fromEntries(
      parents.map((parent, index) => [
        parent['SL_ORD_DETL.SR_NO'],
        name.endsWith('-missing') && index === 1
          ? { state: 'absent' }
          : {
              state: 'present',
              bytes: readFileSync(
                index % 2 === 0
                  ? 'apps/api/test/fixtures/order-design-portrait.png'
                  : 'apps/api/test/fixtures/order-tag-landscape.jpg',
              ),
              mimeType: index % 2 === 0 ? 'image/png' : 'image/jpeg',
              source: index % 2 === 0 ? 'DESIGN' : 'TAG',
            },
      ]),
    );
    const bound = {
      header,
      detailRows: parents,
      orderImages,
      subreports: {
        OrdRec: {
          detailRows: received,
          header: {
            ...completeOrderFields(spec.subreports.OrdRec, {}),
            'Sum ({SL_PR_DETL.ITM_PCS})': '3',
            'Sum ({SL_PR_DETL.ITM_NWT})': '13.375',
          },
        },
      },
      ...(contract.child
        ? {
            parentChild: {
              parentSections: contract.parentSections,
              childSections: contract.childSections,
              parentFooterSections: contract.parentFooterSections,
              groups: parents.map((parent, index) => ({
                key: String(index + 1),
                parent,
                children:
                  index === 0
                    ? [
                        {
                          'ITEM_MAST_IDTL.IT_NAME': 'Ruby component',
                          'SL_ORD_IDTL.IT_PCS': '1',
                          'SL_ORD_IDTL.IT_GWT': '0.123',
                        },
                        {
                          'ITEM_MAST_IDTL.IT_NAME': 'Diamond component',
                          'SL_ORD_IDTL.IT_PCS': '2',
                          'SL_ORD_IDTL.IT_GWT': '0.456',
                        },
                      ]
                    : [],
              })),
            },
          }
        : {}),
    };
    const html = renderReportLayout(spec, bound);
    writeFileSync(resolve(output, `${name}.html`), html);
    const page = await browser.newPage({ viewport: { width: 1100, height: 1200 } });
    const errors = [];
    page.on('pageerror', (error) => errors.push(error.message));
    await page.setContent(html, { waitUntil: 'load' });
    await page.evaluate(() => document.fonts.ready);
    await page.evaluate(() => Promise.all([...document.images].map((image) => image.decode())));
    const geometry = await page.evaluate(() => {
      const outside = [...document.querySelectorAll('.order-object')].flatMap((element) => {
        const box = element.getBoundingClientRect(),
          band = element.closest('.order-band').getBoundingClientRect();
        return box.bottom > band.bottom + 1
          ? [
              {
                field: element.getAttribute('data-field'),
                bottom: box.bottom,
                bandBottom: band.bottom,
              },
            ]
          : [];
      });
      const overlaps = [...document.querySelectorAll('.order-content')].flatMap((content) => {
        const footer = content.querySelector('.order-footer').getBoundingClientRect();
        const bands = [...content.querySelectorAll('.order-main .order-band')];
        return bands.some((band) => band.getBoundingClientRect().bottom > footer.top + 1)
          ? ['main content overlaps footer']
          : [];
      });
      const images = [...document.querySelectorAll('img.order-image')].map((image) => ({
        parent: image.getAttribute('data-parent'),
        decoded: image.complete && image.naturalWidth > 0,
        width: image.naturalWidth,
        height: image.naturalHeight,
        inParentGroup:
          image.closest('.order-image-group')?.getAttribute('data-parent') ===
          image.getAttribute('data-parent'),
      }));
      return { pages: document.querySelectorAll('.order-page').length, outside, overlaps, images };
    });
    assert.deepEqual(errors, []);
    assert.deepEqual(geometry.outside, []);
    assert.deepEqual(geometry.overlaps, []);
    assert.equal(geometry.images.length, name.endsWith('-missing') ? count - 1 : count);
    assert.equal(
      geometry.images.every((image) => image.decoded && image.inParentGroup),
      true,
    );
    assert.equal((await page.locator('body').innerText()).includes('Received gold chain'), true);
    for (let index = 0; index < geometry.pages; index++)
      await page
        .locator('.order-page')
        .nth(index)
        .screenshot({ path: resolve(output, `${name}-page-${index + 1}.png`) });
    await page.pdf({
      path: resolve(output, `${name}.pdf`),
      printBackground: true,
      preferCSSPageSize: true,
    });
    results.push({
      report: name,
      fixture: 'synthetic; not a desktop golden',
      ...geometry,
      pageErrors: errors,
    });
    await page.close();
  }
} finally {
  await browser.close();
}
const runtimeFiles = [
  'reportEngine',
  'reportBindingContract',
  'orderReportValues',
  'orderReportLayout',
  'orderReportImages',
].map((name) => {
  const path = `apps/api/dist/modules/reports/${name}.js`;
  return { path, sha256: createHash('sha256').update(readFileSync(path)).digest('hex') };
});
writeFileSync(
  resolve(output, 'render-review.json'),
  JSON.stringify({ capturedAt: new Date().toISOString(), runtimeFiles, results }, null, 2),
);
console.log(JSON.stringify({ output, results }, null, 2));
