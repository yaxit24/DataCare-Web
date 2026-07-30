/** Desktop tag availability is the positive signed movement balance for the exact
 * company/location/TAG_NO/VCH_SRNO/IT_CODE instance. Callers pass only a static SQL alias. */
export function barTagAvailableSql(alias = 'b'): string {
  if (!/^[A-Za-z_][A-Za-z0-9_]*$/.test(alias)) throw new Error('invalid SQL alias');
  return `coalesce((
    SELECT sum(CASE WHEN m."ITM_SIGN"::text='+'
                    THEN coalesce(m."VCH_SRNO",${alias}."VCH_SRNO",1)
                    ELSE -coalesce(m."VCH_SRNO",${alias}."VCH_SRNO",1) END)
      FROM "MAIN_STOCK" m
     WHERE m."CO_CODE"::text=${alias}."CO_CODE"::text
       AND m."LC_CODE"::text=${alias}."LC_CODE"::text
       AND m."TAG_NO"::text=${alias}."TAG_NO"::text
       AND coalesce(m."VCH_SRNO",0)=coalesce(${alias}."VCH_SRNO",0)
       AND coalesce(m."IT_CODE"::text,'')=coalesce(${alias}."IT_CODE"::text,'')
  ),0) > 0`;
}
