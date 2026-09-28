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
    // LEDR_KEY uniqueness the desktop enforces via PK_AC_DATA and the web lacked.
    name: '20260801160000_ledger_key_uniqueness',
    checksum: 'a5233b5115ef855e2bec6999e37fd4a59c58b563dacc27a69f75c0c7a6c7612b',
  },
  {
    // Corrects 226 columns that were varchar in Postgres while the desktop holds them as float or int.
    name: '20260801120000_column_type_parity',
    checksum: 'd90f7313519b2cd7a158a6ce55728e1d181807bfe2d8dc41506efffe55373413',
  },
  {
    // Provides least-privilege, transactional global sequence advancement for same-company restore.
    name: '20260829010000_company_restore_sequence_guard',
    checksum: '84afef22c62860d9227f6643e537aa5bd393ac93374f69a3b45d23374e609512',
  },
  {
    // Append-only company backup ledger plus the authority evidence a destructive data repair records.
    name: '20260830000000_data_repair_authority',
    checksum: 'ede47cc4821cf4c0aaf28f948788df8b900ecf2e753bb483c9b79d9878650ced',
  },
  {
    // UPI_DATA split identity uses the desktop SR_NO + ISR_NO key so one member line can carry multiple UPI tenders.
    name: '20260910010000_upi_data_split_key',
    checksum: '27a70022e5f51673fa2f1f086d1fd90723254f49ce74e3fdec31166cb4c18e7a',
  },
  {
    // MFG_ISU_REC.ITM_LOT preserves the item-lot column used by manufacturing issue/receive rows.
    name: '20260910020000_mfg_isu_rec_item_lot',
    checksum: '27f5ee541cd03769e2e1c4de4ba80f936414f9ea964e05dc0ea0eafb4ae788d4',
  },
  {
    // Desktop design-book style specification (MS_UPDATE.cs:6721).
    name: '20260911010000_design_detail_style',
    checksum: 'be9000ba6025d5623759473d1218e9e168eacc1229a46ef618c9bbed0682e2cb',
  },
  {
    // AC_DATA.ENTRY_TIME retains the voucher wall clock used by desktop balance cutoffs.
    name: '20260911020000_ledger_entry_timestamp',
    checksum: 'b6dd19d5450d9c9a6ddfe12521bfbfed1e327979f0d67b4d980e3d1c6e3a2061',
  },
  {
    // Preserve full saved order image identity without truncating existing keys.
    name: '20260911030000_order_image_identity',
    checksum: 'af42c4466169c9d325249855737870e404398ce69fbda486aaf3eafe307f5129',
  },
  {
    // Primary desktop component material-lot identity and owner, independently confirmed in EXE.
    name: '20260911040000_mfg_component_lot',
    checksum: 'd34052b7e193a51366dfbcd137e6b70dbaebc2d75a01e665d0d5a5fdf1e1f575',
  },
  {
    // MS_OPNCOMP sale/e-credit-note header ledger override.
    name: '20260911050000_sale_header_ledger',
    checksum: '2b94e2e048952bf2e3e9daaa7c0bf6c9e65713a3e55f84e9b862bd11f8f4a4e6',
  },
  {
    // Persist web photo revisions across replacement/deletion for concurrent saved-order clients.
    name: '20260911060000_image_revision',
    checksum: 'a18e61bcd3460005986fdca31ec8ff63bc010130f2fe73b838228f8850d29570',
  },
  {
    // MS_OPNCOMP:5844, incoming Return tag labour code retained independently from LBR_CODE.
    name: '20260911070000_sale_return_tag_labour_code',
    checksum: '585051aaa5d30794ff5248f3c370050cada7edfc2632cbd107dacac8353a9218',
  },
  {
    // Server context generations and explicit unknown ledger state; runtime lifecycle is separate.
    name: '20260912004500_session_context_epoch',
    checksum: 'b2ebec67672c219db30e547cb1b6b7346f49e94cc3c621a12610e1e54bf35b7d',
  },
];
