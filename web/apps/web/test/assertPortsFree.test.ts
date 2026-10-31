import { createServer, type Server } from 'node:http';
import type { AddressInfo } from 'node:net';
import { afterEach, describe, expect, it } from 'vitest';
import { assertPortsFree } from './real-stack-target.mjs';

const listen = (server: Server) =>
  new Promise<number>((done) =>
    server.listen(0, '127.0.0.1', () => done((server.address() as AddressInfo).port)),
  );
const close = (server: Server) => new Promise<void>((done) => server.close(() => done()));

describe('assertPortsFree (G218)', () => {
  const servers: Server[] = [];
  afterEach(async () => {
    await Promise.all(servers.splice(0).map(close));
  });

  it('refuses a run when a server already answers on its web port', async () => {
    const old = createServer((_, res) => res.end('old build'));
    servers.push(old);
    const port = await listen(old);
    await expect(
      assertPortsFree({ apiOrigin: 'http://127.0.0.1:1', webOrigin: `http://127.0.0.1:${port}` }),
    ).rejects.toThrow(`http://127.0.0.1:${port} already answers`);
  });

  it('passes when nothing listens on either port', async () => {
    const probe = createServer();
    const port = await listen(probe);
    await close(probe);
    await expect(
      assertPortsFree({
        apiOrigin: `http://127.0.0.1:${port}`,
        webOrigin: `http://127.0.0.1:${port}`,
      }),
    ).resolves.toBeUndefined();
  });
});
