/**
 * Code 39 barcode as a pure SVG generator — the open-source replacement for the desktop's
 * FRE3OF9X.TTF font used for tag/barcode printing. No font file, no native dependency. Encodes
 * 0-9, A-Z and - . space $ / + %, framed by the '*' start/stop, with an optional mod-43 check char.
 */

export class BarcodeError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'BarcodeError';
  }
}

// 9-element width patterns (bar,space,bar,...,bar): 'w' = wide, 'n' = narrow.
const CODE39: Record<string, string> = {
  '0': 'nnnwwnwnn',
  '1': 'wnnwnnnnw',
  '2': 'nnwwnnnnw',
  '3': 'wnwwnnnnn',
  '4': 'nnnwwnnnw',
  '5': 'wnnwwnnnn',
  '6': 'nnwwwnnnn',
  '7': 'nnnwnnwnw',
  '8': 'wnnwnnwnn',
  '9': 'nnwwnnwnn',
  A: 'wnnnnwnnw',
  B: 'nnwnnwnnw',
  C: 'wnwnnwnnn',
  D: 'nnnnwwnnw',
  E: 'wnnnwwnnn',
  F: 'nnwnwwnnn',
  G: 'nnnnnwwnw',
  H: 'wnnnnwwnn',
  I: 'nnwnnwwnn',
  J: 'nnnnwwwnn',
  K: 'wnnnnnnww',
  L: 'nnwnnnnww',
  M: 'wnwnnnnwn',
  N: 'nnnnwnnww',
  O: 'wnnnwnnwn',
  P: 'nnwnwnnwn',
  Q: 'nnnnnnwww',
  R: 'wnnnnnwwn',
  S: 'nnwnnnwwn',
  T: 'nnnnwnwwn',
  U: 'wwnnnnnnw',
  V: 'nwwnnnnnw',
  W: 'wwwnnnnnn',
  X: 'nwnnwnnnw',
  Y: 'wwnnwnnnn',
  Z: 'nwwnwnnnn',
  '-': 'nwnnnnwnw',
  '.': 'wwnnnnwnn',
  ' ': 'nwwnnnnwn',
  $: 'nwnwnwnnn',
  '/': 'nwnwnnnwn',
  '+': 'nwnnnwnwn',
  '%': 'nnnwnwnwn',
  '*': 'nwnnwnwnn',
};

// mod-43 value of each character (for the optional check digit).
const VALUES = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%';

/** mod-43 check character for Code 39 (Req: tag barcode integrity). */
export function code39CheckChar(data: string): string {
  let sum = 0;
  for (const ch of data.toUpperCase()) {
    const v = VALUES.indexOf(ch);
    if (v < 0) throw new BarcodeError(`character not encodable in Code39: '${ch}'`);
    sum += v;
  }
  return VALUES[sum % 43]!;
}

export interface Code39Options {
  moduleWidth?: number; // narrow element width in px (default 2)
  wideRatio?: number; // wide:narrow ratio (default 3)
  height?: number; // bar height in px (default 50)
  withCheck?: boolean; // append mod-43 check char
}

/** Encode data as a Code 39 barcode SVG string (pure). */
export function code39Svg(data: string, opts: Code39Options = {}): string {
  const moduleWidth = opts.moduleWidth ?? 2;
  const wide = (opts.wideRatio ?? 3) * moduleWidth;
  const height = opts.height ?? 50;
  let payload = data.toUpperCase();
  for (const ch of payload) {
    if (!(ch in CODE39) || ch === '*')
      throw new BarcodeError(`character not encodable in Code39: '${ch}'`);
  }
  if (opts.withCheck) payload += code39CheckChar(payload);
  const seq = `*${payload}*`;

  const rects: string[] = [];
  let x = 0;
  for (let i = 0; i < seq.length; i++) {
    const pattern = CODE39[seq[i]!]!;
    for (let e = 0; e < pattern.length; e++) {
      const w = pattern[e] === 'w' ? wide : moduleWidth;
      const isBar = e % 2 === 0; // even = bar (black), odd = space
      if (isBar) rects.push(`<rect x="${x}" y="0" width="${w}" height="${height}" fill="#000"/>`);
      x += w;
    }
    x += moduleWidth; // inter-character narrow gap
  }
  const total = x;
  return `<svg xmlns="http://www.w3.org/2000/svg" width="${total}" height="${height}" viewBox="0 0 ${total} ${height}" role="img" aria-label="${data}">${rects.join('')}</svg>`;
}

/**
 * QR code as SVG (for UPI pay QR, e-invoice IRN QR, tag QR). Uses the `qrcode` package via a guarded
 * dynamic import so the codebase compiles without it; throws BarcodeError if unavailable.
 */
export async function qrSvg(data: string, width = 200): Promise<string> {
  if (!data) throw new BarcodeError('qr: data is required');
  let mod: any;
  try {
    const moduleName = 'qrcode';
    mod = await import(moduleName);
  } catch {
    throw new BarcodeError(
      'qrcode package not installed (run: pnpm --filter @datacare/api add qrcode)',
    );
  }
  const qrcode = mod.default ?? mod;
  return qrcode.toString(data, { type: 'svg', margin: 1, width });
}
