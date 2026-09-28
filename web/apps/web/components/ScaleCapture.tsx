'use client';

import { useCallback, useEffect, useRef, useState } from 'react';
import {
  get,
  capturePageContextTicket,
  assertPageContextTicket,
  subscribePageContext,
  PageContextError,
  type PageContextTicket,
} from '../lib/api';
import { DeviceContextGuard, DeviceCaptureCancelled } from '../lib/deviceContextLease';

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
    getReader(): SerialReaderLike;
  };
}

interface SerialReaderLike {
  read(): Promise<{ value?: Uint8Array; done: boolean }>;
  releaseLock(): void;
  cancel?(): Promise<void>;
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
  const readerRef = useRef<SerialReaderLike | null>(null);
  const stopRef = useRef(false);
  const mountedRef = useRef(true);
  const settingsContextRef = useRef<PageContextTicket | null>(null);
  const captureGuard = useRef(new DeviceContextGuard(assertPageContextTicket));
  const onReadingRef = useRef(onReading);
  onReadingRef.current = onReading;

  const cancelCapture = useCallback(async () => {
    captureGuard.current.cancel();
    stopRef.current = true;
    const reader = readerRef.current;
    if (reader) {
      try {
        await reader.cancel?.();
      } catch {
        /* detached device */
      }
      // The owning read loop releases its lock and closes its own port in finally.
    } else {
      const port = portRef.current;
      if (port) {
        if (portRef.current === port) portRef.current = null;
        try {
          await port.close();
        } catch {
          /* detached device */
        }
      }
    }
  }, []);

  useEffect(() => {
    let cancelled = false;
    mountedRef.current = true;
    const unsubscribe = subscribePageContext(() => {
      const ticket = settingsContextRef.current;
      if (!ticket) return;
      try {
        assertPageContextTicket(ticket);
      } catch (error) {
        void cancelCapture();
        if (!cancelled) {
          setStatus('error');
          setMessage(error instanceof Error ? error.message : 'Reload before using the scale.');
        }
      }
    });
    (async () => {
      try {
        const ticket = capturePageContextTicket();
        settingsContextRef.current = ticket;
        const data = await get<ScaleSettings>('/integrations/device-settings');
        if (cancelled || !data) return;
        assertPageContextTicket(ticket);
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
      } catch (error) {
        if (!cancelled) {
          setStatus('error');
          setMessage(
            error instanceof PageContextError ? error.message : 'Could not load device settings.',
          );
        }
      }
    })();
    return () => {
      cancelled = true;
      mountedRef.current = false;
      unsubscribe();
      void cancelCapture();
    };
  }, [cancelCapture]);

  const connect = useCallback(async () => {
    const scale = settings?.scale;
    const context = settingsContextRef.current;
    if (!settings?.enabled || !scale || !context) return;
    const hardware = navigator as Navigator & { serial?: SerialLike };
    if (!hardware.serial) return;
    let port: SerialPortLike | null = null;
    let reader: SerialReaderLike | null = null;
    let opened = false;
    try {
      const lease = captureGuard.current.begin(context);
      stopRef.current = false;
      setStatus('connecting');
      setMessage('');
      port = await hardware.serial.requestPort();
      captureGuard.current.assert(lease);
      // Preserve primary then configured fallback, and the exact server-provided port options.
      for (const profile of [scale.profiles.primary, scale.profiles.fallback]) {
        try {
          await port.open({
            baudRate: profile.baudRate,
            dataBits: profile.dataBits,
            parity: profile.parity,
            stopBits: profile.stopBits,
          });
          opened = true;
        } catch {
          captureGuard.current.assert(lease);
          continue;
        }
        captureGuard.current.assert(lease);
        setMessage(`Connected at ${profile.baudRate}/${profile.dataBits}-N-${profile.stopBits}.`);
        break;
      }
      if (!opened) {
        setStatus('error');
        setMessage('Port open error. Check the cable and that no other program holds the port.');
        return;
      }
      portRef.current = port;
      setStatus('reading');
      const decoder = new TextDecoder();
      reader = port.readable.getReader();
      readerRef.current = reader;
      while (!stopRef.current) {
        const chunk = await reader.read();
        captureGuard.current.assert(lease);
        if (chunk.done) break;
        if (!chunk.value) continue;
        const parsed = extractScaleReading(decoder.decode(chunk.value), {
          frameScanLimit: scale.frameScanLimit,
          excludedCharacters: scale.excludedCharacters,
          decimalPlaces: scale.decimalPlaces,
        });
        if (!parsed.hasReading) continue;
        captureGuard.current.publish(lease, () => {
          setLastReading(parsed.text);
          // The page owns the currently focused row; do not retain the Connect-time callback.
          onReadingRef.current(parsed.text);
        });
      }
      captureGuard.current.assert(lease);
      if (mountedRef.current) setStatus('idle');
    } catch (error) {
      if (!(error instanceof DeviceCaptureCancelled) && mountedRef.current) {
        setStatus('error');
        setMessage(
          error instanceof PageContextError
            ? error.message
            : 'Scale connection was refused or interrupted.',
        );
      }
    } finally {
      if (reader) {
        if (readerRef.current === reader) readerRef.current = null;
        try {
          reader.releaseLock();
        } catch {
          /* detached device */
        }
      }
      if (port && opened) {
        if (portRef.current === port) portRef.current = null;
        try {
          await port.close();
        } catch {
          /* detached device */
        }
      }
    }
  }, [settings]);

  const disconnect = useCallback(async () => {
    await cancelCapture();
    if (mountedRef.current) setStatus(settings?.enabled ? 'idle' : 'disabled');
  }, [cancelCapture, settings]);

  return { status, settings, lastReading, message, connect, disconnect };
}
