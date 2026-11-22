/** Master-data reads of the rate-cut family writer (moved out of rateCut.ts to hold its size ceiling). */

/** `CO_SET.TRAD_FINE` (blank → N, MS_OPNCOMP.cs:813-816) and `CO_SET_NEW.OLD_GOLD_TYPE` (blank → N, :1132-1135). */
export async function readWholesaleSettingsTx(
  tx: any,
  tenantId: string,
  coCode: string,
): Promise<{ tradeFine: boolean; oldGoldType: string }> {
  const rows: Array<{ trad_fine: string | null; old_gold_type: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT (SELECT upper(btrim(coalesce("TRAD_FINE"::text,''))) FROM "CO_SET"
                WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text ORDER BY row_id LIMIT 1) AS trad_fine,
              (SELECT upper(btrim(coalesce("OLD_GOLD_TYPE"::text,''))) FROM "CO_SET_NEW"
                WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text LIMIT 1) AS old_gold_type`,
      tenantId,
      String(coCode),
    );
  const row = rows[0];
  return {
    tradeFine: String(row?.trad_fine ?? '') === 'Y',
    oldGoldType: String(row?.old_gold_type ?? '') || 'N',
  };
}

/** The party's name and mobile as the account master holds them (TR_WH_SALE.cs:14621-14623). */
export async function readPartyTx(
  tx: any,
  tenantId: string,
  coCode: string,
  lcCode: string,
  acCode: string,
): Promise<{ name?: string; mobile?: string } | undefined> {
  const rows: Array<{ AC_NAME: string | null; AC_MOBILE: string | null; LC_CODE: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT "AC_NAME","AC_MOBILE","LC_CODE" FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        ORDER BY ("LC_CODE"=$4) DESC, row_id LIMIT 1`,
      tenantId,
      coCode,
      acCode,
      lcCode,
    );
  const row = rows[0];
  if (!row) return undefined;
  const text = (value: unknown): string | undefined => String(value ?? '').trim() || undefined;
  return { name: text(row.AC_NAME), mobile: text(row.AC_MOBILE) };
}
