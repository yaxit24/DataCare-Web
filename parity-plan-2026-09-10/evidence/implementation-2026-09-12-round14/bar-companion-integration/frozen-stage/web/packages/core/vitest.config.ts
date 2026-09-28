import { defineConfig } from "vitest/config";
export default defineConfig({
  test: {
    include: ["test/saleReturnNBarCompanions.test.ts"],
    pool: "forks",
    poolOptions: { forks: { singleFork: true } },
  },
});
