/**
 * Weighing-scale serial protocol — a faithful port of the desktop's own reader.
 *
 * The desktop implementation lives in `TR_TAG_OPBL.cs` (`WeightScal()`, `Timer1_Tick`,
 * `SerialPort1_DataReceived`). Everything here is derived from that code so that when a real scale is
 * connected to a browser over WebSerial — or to the loopback agent — the number that lands in the grid is
 * the same number the desktop would have produced from the same bytes.
 *
 * DESKTOP BEHAVIOUR, POINT BY POINT
 *
 * 1. Disabled when `DC_Main.MsWeightPort = "0"`:
 *      `if (Operators.CompareString(DC_Main.MsWeightPort, "0", false) == 0) { return; }`
 *    The check appears in both `WeightScal()` and `Timer1_Tick`, so a disabled port neither opens nor
 *    reads. `MsWeightPort` is `CO_SET.WEIGHT_PORT`.
 *
 * 2. Port discovery prefers a friendly name containing `CH340` (the common USB-serial bridge in these
 *    scales). When no CH340 is present the desktop lists the available ports and gives up — it does not
 *    silently pick another port.
 *
 * 3. Primary framing is 9600 baud, 8 data bits, no parity, 1 stop bit. If opening fails, it retries the
 *    CONFIGURED port name at 2400 baud, **7** data bits, no parity, 1 stop bit. The data-bit change
 *    between the two profiles is easy to miss and matters: reading 7-bit data as 8-bit corrupts digits.
 *
 * 4. Bytes arrive on a background event (`Q.Enqueue(SerialPort1.ReadExisting())`) and are consumed by a
 *    timer, so a "frame" is whatever accumulated between ticks rather than a line-delimited record.
 *
 * 5. The timer only consumes a frame while the grid's current column is the net-weight cell
 *    (`if (MSG.Col != 14) { continue; }`). A reading taken with the cursor elsewhere is discarded.
 *
 * 6. Extraction keeps a character when it is numeric OR `.`, and explicitly excludes `+` and CR, over at
 *    most the first 20 characters. **A minus sign is not in the keep set**, so a negative reading loses
 *    its sign — `-1.234` becomes `1.234`. That is reproduced here deliberately; silently "fixing" it
 *    would make the web disagree with the desktop on a tare-negative scale.
 *
 * 7. The result is `Strings.Format(Val(text), "0.000")` — three decimals, format-string rounding, so
 *    half-up (see `GV-ROUND-002` for why that differs from `Math.Round`).
 */

/** `CO_SET.WEIGHT_PORT` value that disables scale capture entirely. */
export const SCALE_PORT_DISABLED = '0';

/** Friendly-name fragment the desktop looks for when discovering the port. */
export const SCALE_PORT_FRIENDLY_NAME = 'CH340';

/** Characters the desktop's extractor explicitly drops even though they may appear in a frame. */
export const SCALE_EXCLUDED_CHARACTERS = ['+', '\r'] as const;

/** Maximum characters the desktop scans in one frame (`while (num <= 20)`). */
export const SCALE_FRAME_SCAN_LIMIT = 20;

/** Decimal places the desktop formats a reading to (`"0.000"`). */
export const SCALE_DECIMAL_PLACES = 3;

export interface SerialPortProfile {
  baudRate: number;
  dataBits: number;
  /** WebSerial spelling; the desktop's `Parity` 0 is none. */
  parity: 'none' | 'even' | 'odd';
  stopBits: number;
}

/**
 * The two profiles the desktop tries, in order. Exposed so the browser opens the port with exactly these
 * parameters instead of guessing — mismatched data bits are the classic cause of garbled weights.
 */
export const SCALE_PORT_PROFILES: {
  primary: SerialPortProfile;
  fallback: SerialPortProfile;
} = {
  // val.BaudRate = 9600; val.DataBits = 8; val.Parity = 0; val.StopBits = 1;
  primary: { baudRate: 9600, dataBits: 8, parity: 'none', stopBits: 1 },
  // SerialPort1.BaudRate = 2400; SerialPort1.DataBits = 7; Parity = 0; StopBits = 1;
  fallback: { baudRate: 2400, dataBits: 7, parity: 'none', stopBits: 1 },
};

/** True when the configured port permits capture at all. */
export function scaleCaptureEnabled(weightPort: unknown): boolean {
  const port = String(weightPort ?? '').trim();
  if (!port) return false;
  return port !== SCALE_PORT_DISABLED;
}

/**
 * The desktop grid column the reading is written into. `Timer1_Tick` discards frames unless the grid's
 * current column is this one, so the web must apply the same focus condition rather than filling the
 * cell from anywhere.
 */
export const SCALE_TARGET_GRID_COLUMN = 14;

export interface ScaleFrameResult {
  /** The digits-and-dot text the desktop's filter produced, before `Val()`. */
  extracted: string;
  /** `Val(extracted)` — leading-numeric parse, 0 when nothing numeric was found. */
  value: number;
  /** `Format(value, "0.000")`, the string the desktop puts in the cell. */
  text: string;
  /** True when the frame contained a minus sign that the desktop's filter discards. */
  signDropped: boolean;
}

/**
 * `Val()` in VB parses the longest leading numeric prefix and yields 0 when there is none. After the
 * desktop's filter the text contains only digits and dots, so the only interesting case is multiple dots
 * (`1.2.3`), where `Val` stops at the second dot.
 */
function vbVal(text: string): number {
  const match = /^\d*(?:\.\d*)?/.exec(text);
  const head = match ? match[0] : '';
  if (!head || head === '.') return 0;
  const parsed = Number(head);
  return Number.isFinite(parsed) ? parsed : 0;
}

/**
 * Parse one accumulated serial frame exactly as `Timer1_Tick` does.
 *
 * An empty frame yields a zero reading: the desktop breaks out of its loop on an empty dequeue and leaves
 * the cell as it was, so callers should treat `extracted === ''` as "no reading" rather than as 0.000.
 */
export function parseScaleFrame(raw: unknown): ScaleFrameResult {
  const frame = typeof raw === 'string' ? raw : '';
  let extracted = '';
  let signDropped = false;

  // `num = 1 … while (num <= 20)`, breaking once past the end of the text.
  const limit = Math.min(frame.length, SCALE_FRAME_SCAN_LIMIT);
  for (let index = 0; index < limit; index += 1) {
    const character = frame[index] as string;
    if (character === '-') {
      signDropped = true;
      continue;
    }
    if ((SCALE_EXCLUDED_CHARACTERS as readonly string[]).includes(character)) continue;
    const isNumeric = character >= '0' && character <= '9';
    if (isNumeric || character === '.') extracted += character;
  }

  const value = vbVal(extracted);
  return {
    extracted,
    value,
    text: value.toFixed(SCALE_DECIMAL_PLACES),
    signDropped,
  };
}
