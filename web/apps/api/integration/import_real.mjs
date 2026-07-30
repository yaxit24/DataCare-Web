#!/usr/bin/env node
// Deprecated compatibility entry point. Use integration/cutover.mjs directly.
import { main } from './cutover.mjs';

process.stderr.write(
  'DEPRECATED: import_real.mjs contains no connection settings; use integration/cutover.mjs.\n',
);
main().catch((error) => {
  process.stdout.write(
    `${JSON.stringify(
      {
        schemaVersion: 1,
        status: 'failed',
        error: {
          code: 'UNEXPECTED_ERROR',
          message: error instanceof Error ? error.message : String(error),
        },
      },
      null,
      2,
    )}\n`,
  );
  process.exitCode = 1;
});
