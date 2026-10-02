import { PrismaPg } from '@prisma/adapter-pg';
import { PrismaClient as GeneratedPrismaClient, Prisma } from './generated/prisma/client.js';

const UNCONFIGURED_URL = 'postgresql://invalid@127.0.0.1:1/invalid';

type LegacyDatasourceOptions = {
  datasources?: { db?: { url?: string } };
  datasourceUrl?: string;
};

export type DataCarePrismaClientOptions = Omit<
  Prisma.PrismaClientOptions,
  'adapter' | 'accelerateUrl'
> &
  LegacyDatasourceOptions;

/**
 * Resolve the v6 constructor forms at one compatibility boundary. A syntactically valid, unreachable URL
 * lets explicitly skipped database suites load their modules without opening a connection; any attempted
 * query still fails. Production startup validates DATABASE_URL before constructing this client.
 */
export function prismaConnectionString(
  options: LegacyDatasourceOptions = {},
  environment: Record<string, string | undefined> = process.env,
): string {
  const configured =
    options.datasources?.db?.url ?? options.datasourceUrl ?? environment.DATABASE_URL;
  return configured?.trim() ? configured : UNCONFIGURED_URL;
}

/** Prisma 7 client with the PostgreSQL driver adapter required by D26/N86. */
export class PrismaClient extends GeneratedPrismaClient {
  constructor(options: DataCarePrismaClientOptions = {}) {
    const { datasources, datasourceUrl, ...clientOptions } = options;
    const adapter = new PrismaPg({
      connectionString: prismaConnectionString({ datasources, datasourceUrl }),
      // Prisma 6 stopped waiting for a connection after five seconds; node-postgres defaults to no limit.
      connectionTimeoutMillis: 5_000,
    });
    super({ ...clientOptions, adapter });
  }
}
