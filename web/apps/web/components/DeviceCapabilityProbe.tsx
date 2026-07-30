'use client';

import { useEffect, useState } from 'react';

type Capability = { label: string; available: boolean };

export default function DeviceCapabilityProbe() {
  const [capabilities, setCapabilities] = useState<Capability[]>([]);
  const [manualWeight, setManualWeight] = useState('');

  useEffect(() => {
    const hardwareNavigator = navigator as Navigator & { serial?: unknown; usb?: unknown };
    setCapabilities([
      { label: 'WebSerial', available: 'serial' in hardwareNavigator },
      { label: 'WebUSB', available: 'usb' in hardwareNavigator },
      {
        label: 'Camera / microphone media access',
        available: typeof navigator.mediaDevices?.getUserMedia === 'function',
      },
    ]);
  }, []);

  return (
    <section className="panel" aria-labelledby="device-capabilities-heading">
      <h2 id="device-capabilities-heading">Local device capabilities</h2>
      <p className="muted">
        This checks browser support only. It does not claim that a scale, USB device, or camera is
        connected.
      </p>
      <ul aria-live="polite">
        {capabilities.length === 0 ? (
          <li>Checking browser capabilities…</li>
        ) : (
          capabilities.map((capability) => (
            <li key={capability.label}>
              {capability.label}: {capability.available ? 'available' : 'not available'}
            </li>
          ))
        )}
      </ul>
      <div className="field" style={{ maxWidth: 260 }}>
        <label htmlFor="manual-scale-weight">Manual weight (grams)</label>
        <input
          id="manual-scale-weight"
          type="number"
          min="0"
          step="0.001"
          inputMode="decimal"
          value={manualWeight}
          onChange={(event) => setManualWeight(event.target.value)}
          aria-describedby="manual-scale-help"
        />
        <span id="manual-scale-help" className="muted">
          Use manual entry whenever hardware or browser device APIs are unavailable.
        </span>
      </div>
      {manualWeight && <p role="status">Manual reading entered: {manualWeight} g</p>}
    </section>
  );
}
