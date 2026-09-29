'use client';

import { useEffect, useState } from 'react';
import { get } from './api';

/**
 * Company settings, for the ones the desktop honours in the UI rather than on the server.
 *
 * WHY A CLIENT HOOK IS THE RIGHT PLACE
 * Some settings are not calculations — they are read-only locks on a grid cell. `ITM_FINE_LOCK` is
 * literally `TEXT_PR.ReadOnly = true` in the desktop (`TR_PURC.cs:7145-7148`), and `SL_NWT_LOCK` is
 * the same idea on the sale's net-weight cell. There is nothing for the server to enforce: the value
 * still posts, the operator simply may not retype it. Honouring them anywhere but the screen would
 * be inventing behaviour the desktop does not have.
 *
 * `GET /settings` already returns every persisted `CO_SET`/`CO_SET_NEW` value, so no new endpoint is
 * needed. Values are fetched once per mount and cached in module scope, because a lock must not
 * flicker on while a voucher is being typed.
 */
export type CompanySettingValues = Record<string, unknown>;

let cached: CompanySettingValues | null = null;
let inFlight: Promise<CompanySettingValues> | null = null;

const load = async (): Promise<CompanySettingValues> => {
  if (cached) return cached;
  if (!inFlight) {
    inFlight = get<{ values: CompanySettingValues }>('/settings')
      .then((response) => {
        cached = response.values ?? {};
        return cached;
      })
      .catch(() => ({}) as CompanySettingValues)
      .finally(() => {
        inFlight = null;
      });
  }
  return inFlight;
};

/**
 * Read a Y/N company flag.
 *
 * `blankDefault` matters and is not cosmetic: the desktop fills a blank setting before use and the
 * default differs per setting (`MS_OPNCOMP.cs`, the `if (MsX == "") MsX = "V"` block). Two of them
 * default to the PERMISSIVE value, so assuming false for a blank column would invert live behaviour.
 * Callers pass the desktop's default for the flag they are reading.
 */
export function companyFlag(
  values: CompanySettingValues | null,
  column: string,
  blankDefault: 'Y' | 'N' = 'N',
): boolean {
  if (!values) return blankDefault === 'Y';
  const raw = String(companySetting(values, column) ?? '')
    .trim()
    .toUpperCase();
  if (raw === '') return blankDefault === 'Y';
  return raw === 'Y';
}

/**
 * One persisted CO_SET / CO_SET_NEW value, by column name.
 *
 * `GET /settings` keys its values by descriptor id (`CO_SET.SL_AMT_TYPE`, `CO_SET_NEW.LBR_WITH_GHT`),
 * not by bare column name, because some columns (COUNTRY_ID) exist in both tables. Callers asked for
 * the bare name and always got undefined. `LBR_WITH_GHT`, `SL_NWT_LOCK` and `ITM_FINE_LOCK` therefore
 * fell back to their blank defaults whatever the company had configured.
 *
 * An exact key still wins, so a column held in both tables can be requested by its full id.
 */
export function companySetting(values: CompanySettingValues | null, column: string): unknown {
  if (!values) return undefined;
  if (Object.prototype.hasOwnProperty.call(values, column)) return values[column];
  for (const table of ['CO_SET', 'CO_SET_NEW']) {
    const id = `${table}.${column}`;
    if (Object.prototype.hasOwnProperty.call(values, id)) return values[id];
  }
  return undefined;
}

/** Company setting values, or null until the first fetch resolves. */
export function useCompanySettings(): CompanySettingValues | null {
  const [values, setValues] = useState<CompanySettingValues | null>(cached);
  useEffect(() => {
    if (cached) {
      setValues(cached);
      return;
    }
    let alive = true;
    load().then((next) => {
      if (alive) setValues(next);
    });
    return () => {
      alive = false;
    };
  }, []);
  return values;
}
