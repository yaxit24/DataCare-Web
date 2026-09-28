import { defineConfig } from "vitest/config";
export default defineConfig({
  test: {
    include: ["test/saleReturnIncomingSaveProjection.test.ts"],
    pool: "forks",
    poolOptions: { forks: { singleFork: true } },
  },
});
