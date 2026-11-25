import { PrismaClient } from '@datacare/db';
import { purgeDeletedCompanies } from './modules/ops/companyPurge.js';
// Platform scheduler invokes this worker with a tenant id; credentials come only from the environment.
const tenant = process.argv[2];
if (!tenant || tenant.length > 24) throw new Error('A tenant id is required');
const prisma = new PrismaClient();
try {
  await purgeDeletedCompanies(prisma, tenant);
} finally {
  await prisma.$disconnect();
}
