export const EXPECTED_MIGRATIONS: ReadonlyArray<{
  name: string;
  checksum: string;
}> = [
  {
    name: '20260627200423_init',
    checksum: 'c390ab923703889a96e87d08adb5e020cce8b210cf7cc2437969fa3e94ea3097',
  },
  {
    name: '20260714010000_schema_parity',
    checksum: '41f0641b86606851f2a48870c98136f6604fae850b7feff7447e15e5d2a6b1f4',
  },
  {
    name: '20260715010000_runtime_schema_security',
    checksum: '82a7fd3af8ac3259c3df66de4a1e9a154ed65957d3fcecbd3d3d46e2b99923e6',
  },
  {
    name: '20260715020000_schema_model_convergence',
    checksum: '776c66fee6407799fa2393fd9e4aee81461dca9dfefba4e1f56b479a1842901a',
  },
  {
    name: '20260715030000_authoritative_scope_rbac_sessions',
    checksum: '4d011ad562511873982957325ffc47b62ca5d824a25b312495c531c185ae873c',
  },
  {
    name: '20260715040000_transaction_integrity',
    checksum: '91f95a7af1ee8fa41b56cc4ed068e0107b91965d9db45912bc5ea2f4eb364545',
  },
  {
    name: '20260727010000_repair_image',
    checksum: '273493f985ce821a128ee6d2b10f91129ae78242cdf8873e8148eee168a39ef8',
  },
  {
    name: '20260727020000_melting_detail_parity',
    checksum: 'ea6d2267d2cf202f63445b33f9afa2b8cd8e42c9fd44031391b66524f529493e',
  },
  {
    name: '20260727030000_melting_mfg_linkage',
    checksum: '0557c5f869957e2edffaf09b014551613e7e63d99c170d520bfca8e1c7031428',
  },
  {
    name: '20260728010000_message_attempt_log',
    checksum: '6ace8aeaa4d29640e9e33c0505ea4dc95a2d153159143ebfcb258af59d1d2512',
  },
  // Added 2026-07-30. These four were applied but never pinned here, so the drift detector was blind to
  // them — a gap in the gate itself rather than in the schema. Checksums read from _prisma_migrations.
  {
    name: '20260730010000_data_repair_console',
    checksum: '6c5a23844987a9909a9ff0de90c6f3b9b4bc9d402ef2ef56c52c37e8c66bc06a',
  },
  {
    name: '20260730020000_tag_image_store',
    checksum: '1d33bffff5724307457d685bf6e7f7a6db7b0c07060f655cc4095aaa74a225bc',
  },
  {
    name: '20260730030000_entity_image_store',
    checksum: '772f68dec65312887af32c511b6f4278e1a81f1779788fcbc989cc44dca31ec3',
  },
  {
    name: '20260730040000_gold_mast_bank_account',
    checksum: '014e9928425e3b6d4f535022524f15abcdf4b77942c327e8a5c70b862ce142a5',
  },
  {
    name: '20260730050000_message_log_rls',
    checksum: '298e2dd8f3b511ae27c2302e8d3d546b06baf13346b6dabbe84a261bdf3449c6',
  },
  {
    // Corrects 226 columns that were varchar in Postgres while the desktop holds them as float or int.
    name: '20260801120000_column_type_parity',
    checksum: 'd90f7313519b2cd7a158a6ce55728e1d181807bfe2d8dc41506efffe55373413',
  },
];
