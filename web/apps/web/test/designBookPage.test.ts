import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';
import {
  DESIGN_COLUMNS,
  COMPONENT_COLUMNS,
  blankDesign,
  blankComponent,
  designFromDb,
  designToPayload,
} from '../lib/designBookDraft';

const read = (path: string) => readFileSync(join(__dirname, '..', path), 'utf8');

describe('design book draft round trip', () => {
  const saved = {
    SR_NO: 17,
    OLD_SRNO: 17,
    DESIGN_NO: 'D-007',
    PAGE_NO: '001',
    ITM_STYLE: 'engraved',
    DIE_NO: 'D-02',
    ITM_GHT: '0.137',
    ITM_RATE: null,
    ITM_SIZE: '',
    VCH_DATE: '2024-05-15T00:00:00.000Z',
    DESIGN_IMG_ID: '01_BOOK_RG_D-007',
    components: [
      {
        ISR_NO: 4,
        SR_NO: 17,
        IT_CODE: 'ST001',
        IT_PCS: '3',
        IT_PCS_WT: '0.251',
        KR_WT: '0.753',
        KR_LESS_PRC: '87.65',
        IT_GWT: '0.660',
        IT_CON_PRC: '0.2',
        IT_CON_WT: '0.132',
        IT_RATE_TYPE: 'P',
        IT_RATE: '123.45',
        IT_AMT: '370.35',
        IT_LBR_RATE: '6.75',
        IT_LBR_AMT: null,
        IT_NET_AMT: '390.60',
        IT_TYPE: '',
      },
    ],
  };
  it('keeps all loaded values, nulls, dates, image and parent/child serials unchanged', () => {
    const draft = designFromDb(saved);
    const output = designToPayload(draft);
    for (const { key, column } of DESIGN_COLUMNS)
      if (Object.hasOwn(saved, column)) {
        expect(output[key], column).toEqual(saved[column as keyof typeof saved]);
      }
    const [child] = output.components as Record<string, unknown>[];
    for (const { key, column } of COMPONENT_COLUMNS) {
      expect(child[key], column).toEqual(
        saved.components[0][column as keyof (typeof saved.components)[0]],
      );
    }
    expect(output.vchDate).toBe(saved.VCH_DATE);
    expect(output.designImageId).toBe(saved.DESIGN_IMG_ID);
  });
  it('retains original serials when a parent moves and a component is removed', () => {
    const first = designFromDb(saved);
    const second = designFromDb({ ...saved, SR_NO: 23, OLD_SRNO: 23 });
    first.components.push(blankComponent(first.nextComponentSerial++));
    first.components[1].values.itCode = 'ST002';
    first.components.shift();
    const payload = [second, first].map(designToPayload);
    expect(payload.map((row) => row.srNo)).toEqual([23, 17]);
    expect((payload[1].components as Record<string, unknown>[]).map((row) => row.isrNo)).toEqual([
      5,
    ]);
  });
  it('allows explicit zero, field clearing and changed child amounts without changing hidden values', () => {
    const draft = designFromDb(saved);
    draft.values.pageNo = '';
    draft.values.ghatWt = '0';
    draft.components[0].values.labourAmount = '0';
    draft.components[0].values.rate = '991.23';
    const output = designToPayload(draft);
    expect(output.pageNo).toBe('');
    expect(output.ghatWt).toBe(0);
    expect(output.designImageId).toBe(saved.DESIGN_IMG_ID);
    expect((output.components as Record<string, unknown>[])[0]).toMatchObject({
      labourAmount: 0,
      rate: 991.23,
      karigarWt: '0.753',
      conversionWt: '0.132',
      isrNo: 4,
    });
  });
  it('rejects invalid numeric drafts and blank component item without silently dropping rows', () => {
    const draft = designFromDb(saved);
    draft.components[0].values.rate = 'abc';
    expect(() => designToPayload(draft)).toThrow('finite number');
    draft.components[0].values.rate = '123';
    draft.components[0].values.itCode = '';
    expect(() => designToPayload(draft)).toThrow('needs an item');
    expect(() => designToPayload(blankDesign(1))).toThrow('design number');
  });
  it('wires create, edit, delete and scoped saved photographs to the dedicated screen', () => {
    const page = read('app/(app)/masters/design-book/page.tsx');
    expect(page).toContain('/masters/design-book?');
    expect(page).toContain("post<{ written: number }>('/masters/design-book'");
    expect(page).toContain("put<{ written: number }>('/masters/design-book'");
    expect(page).toContain("del('/masters/design-book'");
    expect(page).toContain('expectedVersion: bookVersion');
    expect(page).toContain('endpoint="/masters/design-book/image"');
    expect(page).toContain('String(activeLine.saved.DESIGN_IMG_ID)');
    const nav = read('lib/nav.ts');
    expect(nav).toContain("href: '/masters/design-book'");
  });
});
