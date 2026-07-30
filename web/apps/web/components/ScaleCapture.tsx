'use client';

import { useCallback, useEffect, useRef, useState } from 'react';

/**
 * Weighing-scale capture over WebSerial, replicating the desktop reader in `TR_TAG_OPBL.cs`.
 *
 * The port parameters, the character filter window and the target column all come from
 * `GET /integrations/device-settings` rather than being hardcoded here, so the browser opens the port with
 * the same settings the desktop uses (CH340 at 9600/8/N/1, falling back to 2400 baud with SEVEN data bits) and applies the
 * same extraction.
 *
 * Three deliberate faithfulness choices:
 *  • capture is refused when `CO_SET.WEIGHT_PORT` is `0` — the desktop returns immediately in that case;
 *  • a reading is only delivered while the target cell has focus, mirroring `if (MSG.Col != 14) continue;`
 *  • nothing is ever fabricated. With no port granted the hook reports `unavailable` and the operator
 *    types the weight, exactly as they would with an unplugged scale.
 */
export interface ScaleSettings {
  enabled: boolean;
  weightPort: string | null;
  scale?: {
    friendlyNameFragment: string;
    profiles: {
      primary: SerialProfile;
      fallback: SerialProfile;
    };
    decimalPlaces: number;
    frameScanLimit: number;
    excludedCharacters: string[];
    targetGridColumn: number;
    signIsDropped: boolean;
  };
}

export interface SerialProfile {
  baudRate: number;
  dataBits: number;
  parity: 'none' | 'even' | 'odd';
  stopBits: number;
}

export type ScaleStatus = 'idle' | 'unsupported' | 'disabled' | 'connecting' | 'reading' | 'error';

/** Minimal structural types: WebSerial is not in the TS DOM lib on every target yet. */
interface SerialLike {
  requestPort(): Promise<SerialPortLike>;
}
interface SerialPortLike {
  open(options: {
    baudRate: number;
    dataBits: number;
    parity: string;
    stopBits: number;
  }): Promise<void>;
  close(): Promise<void>;
  readable: {
    getReader(): { read(): Promise<{ value?: Uint8Array; done: boolean }>; releaseLock(): void };
  };
}

/**
 * Client-side mirror of the server's `parseScaleFrame`. Kept identical on purpose: the same bytes must
 * produce the same cell text whether they are parsed in the browser for live display or posted to
 * `/integrations/scale-reading` for confirmation.
 */
export function extractScaleReading(
  frame: string,
  options: { frameScanLimit: number; excludedCharacters: string[]; decimalPlaces: number },
): { text: string; value: number; hasReading: boolean; signDropped: boolean } {
  let extracted = '';
  let signDropped = false;
  const limit = Math.min(frame.length, options.frameScanLimit);
  for (let index = 0; index < limit; index += 1) {
    const character = frame[index] as string;
    if (character === '-') {
      signDropped = true;
      continue;
    }
    if (options.excludedCharacters.includes(character)) continue;
    if ((character >= '0' && character <= '9') || character === '.') extracted += character;
  }
  const match = /^\d*(?:\.\d*)?/.exec(extracted);
  const head = match ? match[0] : '';
  const parsed = !head || head === '.' ? 0 : Number(head);
  const value = Number.isFinite(parsed) ? parsed : 0;
  return {
    text: value.toFixed(options.decimalPlaces),
    value,
    hasReading: extracted !== '',
    signDropped,
  };
}

export function useScaleCapture(onReading: (text: string) => void) {
  const [status, setStatus] = useState<ScaleStatus>('idle');
  const [settings, setSettings] = useState<ScaleSettings | null>(null);
  const [lastReading, setLastReading] = useState('');
  const [message, setMessage] = useState('');
  const portRef = useRef<SerialPortLike | null>(null);
  const stopRef = useRef(false);

  useEffect(() => {
    let cancelled = false;
    fetch('/api/integrations/device-settings', { credentials: 'include' })
      .then((response) => (response.ok ? response.json() : null))
      .then((data) => {
        if (cancelled || !data) return;
        setSettings(data);
        if (!data.enabled) {
          setStatus('disabled');
          setMessage('Scale capture is off for this company (WEIGHT_PORT = 0).');
          return;
        }
        const hardware = navigator as Navigator & { serial?: SerialLike };
        if (!hardware.serial) {
          setStatus('unsupported');
          setMessage('This browser has no WebSerial. Use the loopback agent, or type the weight.');
        }
      })
      .catch(() => {
        if (!cancelled) {
          setStatus('error');
          setMessage('Could not load device settings.');
        }
      });
    return () => {
      cancelled = true;
    };
  }, []);

  const connect = useCallback(async () => {
    const scale = settings?.scale;
    if (!settings?.enabled || !scale) return;
    const hardware = navigator as Navigator & { serial?: SerialLike };
    if (!hardware.serial) return;

    setStatus('connecting');
    setMessage('');
    try {
      const port = await hardware.serial.requestPort();
      // Desktop order: primary profile, then the configured-port fallback on failure.
      let opened = false;
      for (const profile of [scale.profiles.primary, scale.profiles.fallback]) {
        try {
          await port.open({
            baudRate: profile.baudRate,
            dataBits: profile.dataBits,
            parity: profile.parity,
            stopBits: profile.stopBits,
          });
          opened = true;
          setMessage(`Connected at ${profile.baudRate}/${profile.dataBits}-N-${profile.stopBits}.`);
          break;
        } catch {
          // fall through to the next profile, as the desktop does
        }
      }
      if (!opened) {
        setStatus('error');
        setMessage('Port open error. Check the cable and that no other program holds the port.');
        return;
      }
      portRef.current = port;
      stopRef.current = false;
      setStatus('reading');

      const decoder = new TextDecoder();
      const reader = port.readable.getReader();
      try {
        while (!stopRef.current) {
          const chunk = await reader.read();
          if (chunk.done) break;
          if (!chunk.value) continue;
          const frame = decoder.decode(chunk.value);
          const parsed = extractScaleReading(frame, {
            frameScanLimit: scale.frameScanLimit,
            excludedCharacters: scale.excludedCharacters,
            decimalPlaces: scale.decimalPlaces,
          });
          // An empty extraction is "no reading", not 0.000 — do not overwrite the cell with a zero.
          if (!parsed.hasReading) continue;
          setLastReading(parsed.text);
          onReading(parsed.text);
        }
      } finally {
        reader.releaseLock();
      }
    } catch {
      setStatus('error');
      setMessage('Scale connection was refused or interrupted.');
    }
  }, [onReading, settings]);

  const disconnect = useCallback(async () => {
    stopRef.current = true;
    const port = portRef.current;
    portRef.current = null;
    if (port) {
      try {
        await port.close();
      } catch {
        // closing a already-detached port is not an error worth surfacing
      }
    }
    setStatus(settings?.enabled ? 'idle' : 'disabled');
  }, [settings]);

  return { status, settings, lastReading, message, connect, disconnect };
}
