import { defineConfig } from "vitest/config";
export default defineConfig({
  test: {
    include: ["packages/core/test/saleReturnSaveGuards.test.ts"],
    maxWorkers: 1,
    minWorkers: 1,
  },
});
