# Round12 ledger test typing correction

The full strict compiler found TS2352 at `desktopAccountBalance.db.test.ts:324`: TypeScript inferred a union of patch-object keys, so casting that union to `Record<string,string>` was unsafe. The test now declares the common `it.each` row shape `{id:string;patch:Record<string,string>;mode:'A'|'C'}` and spreads `patch` directly. This is the only test-source change; all 12 independent vectors, seven alias cases, assertions and runtime operations are unchanged.

Before editing, the complete prior source was hashed and transpiled with TypeScript 5.9.3 (ES2022/NodeNext; no source maps). After editing, the erased JavaScript was compared byte for byte with the retained pre-change output: **identical**.

- Prior test source SHA256: `da57beda30df821c8178f423a2b2f6142381348e1033ca386a56617322ca017c`.
- Corrected test source SHA256: `3cad287d96b7039a24162d9c7ac7a21ab78836aee0b52f16fbebb0b35377fa74`.
- Identical emitted JavaScript SHA256: `fc7f7f10253a0b610337d0aaa5f02f7a6cc35df4797717bd1eb68a2202961450`.
- Unchanged independent fixture SHA256: `32f1d4533a01923972f650ed06c4825f0c4f567d2a44e383f609ed059018e6c7`.

The bounded strict check includes only this test and its imported dependencies, extends the existing API `tsconfig.test.json`, and passed with exit 0 in about 5.14 seconds. It is not a full-project compiler result. The initial bounded invocation failed with TS2688 because the external evidence-directory config could not locate Node types; its failed log and config remain preserved. The corrected config explicitly resolves the existing API `node_modules/@types` directory, without disabling strict options or changing test inclusion.

Prior focused/full database results and frozen manifests remain historical evidence for the old source hash. No database test, browser, workspace build, full compiler or release certification was run here. A new full API input capture and regression remains root-owned; byte-identical JavaScript does not silently rewrite previous evidence.
