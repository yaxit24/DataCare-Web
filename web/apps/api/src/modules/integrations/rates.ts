/**
 * Live precious-metal + forex rates — web replacement for the desktop MDI_FORM live-rate feed.
 * The desktop pulled gold price from api.gold-api.com and USD→INR from api.frankfurter.app (both
 * free, no API key) and showed INR/gram. We do the same and compute 24k/22k INR per gram.
 * Best-effort: never throws — returns { ok:false, error } on any network failure.
 */
import { DEFAULT_OUNCE_CONVERSION, ounceRatePerGram } from '../shared/settingsBehavior.js';

/** Blank CO_SET.OZ_CON_VAL preserves the former web constant. */
export const OZ_TO_GRAM = DEFAULT_OUNCE_CONVERSION;

export interface LiveRates {
  ok: boolean;
  updatedAt: string;
  usdInr?: number;
  goldUsdOz?: number;
  silverUsdOz?: number;
  gold24kInrGram?: number;
  gold22kInrGram?: number;
  silverInrGram?: number;
  source?: string;
  error?: string;
}

const r2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

/** Pure: TR_PR_SL_UAE.cs:10846 computes spot × FX / OZ_CON_VAL, then applies purity. */
export function metalInrPerGram(
  usdPerOz: number,
  usdInr: number,
  purity = 1,
  ounceConversion = OZ_TO_GRAM,
): number {
  return r2(ounceRatePerGram(usdPerOz, usdInr, ounceConversion) * purity);
}

export async function fetchLiveRates(
  opts: { fetchImpl?: typeof fetch; timeoutMs?: number; ounceConversion?: number } = {},
): Promise<LiveRates> {
  const f = opts.fetchImpl ?? fetch;
  const timeoutMs = opts.timeoutMs ?? 8000;
  const get = async (u: string): Promise<any> => {
    const res = await f(u, { signal: AbortSignal.timeout(timeoutMs) } as any);
    if (!res.ok) throw new Error(`HTTP ${res.status} for ${u}`);
    return res.json();
  };
  try {
    const [xau, xag, fx] = await Promise.all([
      get('https://api.gold-api.com/price/XAU'),
      get('https://api.gold-api.com/price/XAG').catch(() => null),
      get('https://api.frankfurter.app/latest?base=USD&symbols=INR'),
    ]);
    const usdInr = Number(fx?.rates?.INR);
    const goldUsdOz = Number(xau?.price);
    const silverUsdOz = xag ? Number(xag.price) : undefined;
    if (!(usdInr > 0) || !(goldUsdOz > 0)) throw new Error('invalid rate payload');
    const ounceConversion = opts.ounceConversion ?? OZ_TO_GRAM;
    return {
      ok: true,
      updatedAt: new Date().toISOString(),
      usdInr: r2(usdInr),
      goldUsdOz: r2(goldUsdOz),
      silverUsdOz: silverUsdOz ? r2(silverUsdOz) : undefined,
      gold24kInrGram: metalInrPerGram(goldUsdOz, usdInr, 1, ounceConversion),
      gold22kInrGram: metalInrPerGram(goldUsdOz, usdInr, 22 / 24, ounceConversion),
      silverInrGram: silverUsdOz
        ? metalInrPerGram(silverUsdOz, usdInr, 1, ounceConversion)
        : undefined,
      source: 'gold-api.com + frankfurter.app',
    };
  } catch (e: any) {
    return {
      ok: false,
      updatedAt: new Date().toISOString(),
      error: e?.message ?? 'rate fetch failed',
    };
  }
}
