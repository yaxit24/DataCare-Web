import { describe, it, expect } from 'vitest';
import { metalInrPerGram, fetchLiveRates, OZ_TO_GRAM } from '../src/modules/integrations/rates.js';

describe('live rates', () => {
  it('metalInrPerGram = usd/oz × usdInr ÷ oz→g × purity', () => {
    expect(metalInrPerGram(4000, 90, 1)).toBeCloseTo((4000 * 90) / OZ_TO_GRAM, 1);
    expect(metalInrPerGram(4000, 90, 22 / 24)).toBeCloseTo(
      ((4000 * 90) / OZ_TO_GRAM) * (22 / 24),
      1,
    );
  });

  it('composes gold/silver/forex via injected fetch', async () => {
    const fake = (async (u: string) => ({
      ok: true,
      json: async () =>
        u.includes('XAU')
          ? { price: 4000 }
          : u.includes('XAG')
            ? { price: 50 }
            : { rates: { INR: 90 } },
    })) as unknown as typeof fetch;
    const r = await fetchLiveRates({ fetchImpl: fake });
    expect(r.ok).toBe(true);
    expect(r.usdInr).toBe(90);
    expect(r.gold24kInrGram).toBeCloseTo((4000 * 90) / OZ_TO_GRAM, 0);
    expect(r.gold22kInrGram!).toBeLessThan(r.gold24kInrGram!);
  });

  it('returns ok:false on network error (never throws)', async () => {
    const r = await fetchLiveRates({
      fetchImpl: (async () => {
        throw new Error('net');
      }) as unknown as typeof fetch,
    });
    expect(r.ok).toBe(false);
    expect(r.error).toBeDefined();
  });
});

it('uses the server-supplied company ounce conversion for pure and fetched rates', async () => {
  expect(metalInrPerGram(3000, 4, 1, 30)).toBe(400);
  expect(metalInrPerGram(3000, 4, 1, 40)).toBe(300);
  const fake = (async (u: string) => ({
    ok: true,
    json: async () =>
      u.includes('XAU')
        ? { price: 3000 }
        : u.includes('XAG')
          ? { price: 30 }
          : { rates: { INR: 4 } },
  })) as unknown as typeof fetch;
  const r = await fetchLiveRates({ fetchImpl: fake, ounceConversion: 30 });
  expect(r.gold24kInrGram).toBe(400);
  expect(r.silverInrGram).toBe(4);
});
