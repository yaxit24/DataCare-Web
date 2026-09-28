import type { PageContextTicket } from './pageContext';

export interface DeviceContextLease {
  readonly generation: number;
  readonly context: PageContextTicket;
}
export class DeviceCaptureCancelled extends Error {
  constructor() {
    super('device-capture-cancelled');
    this.name = 'DeviceCaptureCancelled';
  }
}

/** A local device may publish only into the exact page and capture operation that started it. */
export class DeviceContextGuard {
  private generation = 0;
  constructor(private readonly assertPage: (ticket: PageContextTicket) => void) {}
  begin(context: PageContextTicket): DeviceContextLease {
    this.assertPage(context);
    return Object.freeze({ generation: ++this.generation, context });
  }
  assert(lease: DeviceContextLease): void {
    if (lease.generation !== this.generation) throw new DeviceCaptureCancelled();
    this.assertPage(lease.context);
  }
  publish(lease: DeviceContextLease, deliver: () => void): void {
    this.assert(lease);
    deliver();
  }
  cancel(): void {
    this.generation++;
  }
}
