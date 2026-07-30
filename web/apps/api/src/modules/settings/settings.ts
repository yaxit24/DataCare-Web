import { withTenant } from '@datacare/db';
import { CONFIGURABLE_SETTINGS, type SettingTable } from './settingsInventory.js';
import {
  SETTING_CATALOG,
  SETTING_CATALOG_BY_ID,
  type SettingDescriptor,
} from './settingsCatalog.js';

/**
 * Company settings — the desktop's `UT_SETTING`, `UT_SETTING_MAIN` and `UT_SET_ADMIN`.
 *
 * WHAT CHANGED AND WHY
 * --------------------
 * This module previously exposed 55 curated keys and read/wrote **`CO_SET` only**. `CO_SET_NEW` holds 70
 * further settings — including `NEGATIVE_STK_SALE`, `CUR_DAY_POSTING`, `SL_NWT_LOCK`, `PROFIT_RPT_TYPE`
 * (which decides whether the balance sheet values metal at all) and the hallmark/TDS flags. Those were read
 * directly by their consuming modules, so they governed behaviour while being invisible and unmanageable:
 * an owner could not see them, let alone change them. The surface now covers all 130 columns across both
 * tables.
 *
 * Three further defects in the old implementation are fixed here:
 *   1. every value was written with `String(...)`, which cannot be right for the numeric and date columns
 *      of `CO_SET_NEW` (`PR_RATE_ROF` numeric, `FONT_SIZE`/`WAPP_DELAY` float, `GRID_ROW_HIGHT`/
 *      `TOT_AMT_ROF` integer, `F_DISC_DATE`/`T_DISC_DATE` date);
 *   2. reads flattened NULL to `''`, so "never configured" was indistinguishable from "deliberately blank";
 *   3. unknown keys were silently filtered out, so a typo looked like a successful save.
 */
export class SettingsError extends Error {
  /** Per-key reasons, so the client can mark the offending fields rather than showing one banner. */
  readonly details: Record<string, string>;
  constructor(m: string, details: Record<string, string> = {}) {
    super(m);
    this.name = 'SettingsError';
    this.details = details;
  }
}

/** Public field metadata for the settings screen. Internal provenance is not exposed. */
export const SETTING_FIELDS: readonly SettingDescriptor[] = SETTING_CATALOG;

const qcol = (c: string): string => '"' + c.replace(/[^A-Za-z0-9_]/g, '') + '"';

const TABLES: SettingTable[] = ['CO_SET', 'CO_SET_NEW'];

const columnsFor = (table: SettingTable): SettingDescriptor[] =>
  SETTING_CATALOG.filter((d) => d.table === table);

/**
 * Read every configurable setting from both tables.
 *
 * A missing row yields `null` for its columns rather than `''`: the settings screen shows "not configured"
 * and an unrelated save must not turn that into a blank string.
 */
export async function getSettings(
  prisma: any,
  scope: { tenantId: string; coCode: string },
): Promise<Record<string, unknown>> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const out: Record<string, unknown> = {};
    for (const table of TABLES) {
      const desc = columnsFor(table);
      if (!desc.length) continue;
      const cols = desc.map((d) => qcol(d.key)).join(',');
      const rows: any[] = await tx.$queryRawUnsafe(
        `SELECT ${cols} FROM ${qcol(table)} WHERE "CO_CODE"=$1 LIMIT 1`,
        scope.coCode,
      );
      const row = rows[0] ?? {};
      for (const d of desc) {
        const v = row[d.key];
        // Keyed by descriptor id, not column name: COUNTRY_ID exists in both tables.
        // Decimal/BigInt/Date arrive as objects from the driver; normalise to wire-friendly scalars
        // without collapsing null, which carries meaning.
        if (v == null) out[d.id] = null;
        else if (v instanceof Date) out[d.id] = v.toISOString().slice(0, 10);
        else if (typeof v === 'object') out[d.id] = String(v);
        else out[d.id] = v;
      }
    }
    return out;
  });
}

/**
 * Validate one submitted value against its descriptor, returning the value to persist.
 *
 * Enum and boolean membership is checked against the PERSISTED value, not the label, so a client that
 * submits `"Yes"` where the desktop stores `"Y"` is rejected instead of quietly corrupting the setting.
 */
export function coerceSettingValue(
  d: SettingDescriptor,
  raw: unknown,
): { ok: true; value: unknown } | { ok: false; reason: string } {
  if (raw == null || (typeof raw === 'string' && raw.trim() === '')) {
    return { ok: true, value: null }; // clearing a setting is legitimate
  }
  const s = String(raw).trim();
  switch (d.type) {
    case 'boolean':
    case 'enum': {
      const allowed = (d.options ?? []).map((o) => o.value);
      if (!allowed.includes(s)) {
        return { ok: false, reason: `must be one of ${allowed.join(', ')}` };
      }
      return { ok: true, value: s };
    }
    case 'number': {
      const n = Number(s);
      if (!Number.isFinite(n)) return { ok: false, reason: 'must be a number' };
      if (d.options?.length) {
        const allowed = d.options.map((o) => Number(o.value));
        if (!allowed.includes(n)) {
          return { ok: false, reason: `must be one of ${allowed.join(', ')}` };
        }
      }
      return { ok: true, value: n };
    }
    case 'date': {
      if (!/^\d{4}-\d{2}-\d{2}$/.test(s)) return { ok: false, reason: 'must be YYYY-MM-DD' };
      const dt = new Date(`${s}T00:00:00Z`);
      if (Number.isNaN(dt.getTime())) return { ok: false, reason: 'is not a real date' };
      return { ok: true, value: dt };
    }
    default: {
      // Slice to the column's REAL width from information_schema, never a guessed 255.
      if (d.maxLength && s.length > d.maxLength) {
        return { ok: false, reason: `must be at most ${d.maxLength} characters` };
      }
      return { ok: true, value: s };
    }
  }
}

/**
 * Save a patch of changed settings across both tables in ONE transaction.
 *
 * An unknown or invalid key rejects the WHOLE request. Partially applying a save would leave the operator
 * believing every field was stored.
 */
export async function saveSettings(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  patch: Record<string, unknown>,
): Promise<{ saved: true; changed: number }> {
  const keys = Object.keys(patch ?? {});
  if (!keys.length) throw new SettingsError('no settings supplied');

  const errors: Record<string, string> = {};
  const values = new Map<string, unknown>();
  for (const k of keys) {
    const d = SETTING_CATALOG_BY_ID[k];
    if (!d) {
      errors[k] = 'is not a known setting';
      continue;
    }
    const r = coerceSettingValue(d, patch[k]);
    if (r.ok) values.set(k, r.value);
    else errors[k] = r.reason;
  }
  if (Object.keys(errors).length) {
    throw new SettingsError('invalid settings', errors);
  }

  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    let changed = 0;
    for (const table of TABLES) {
      const mine = [...values.keys()].filter((k) => SETTING_CATALOG_BY_ID[k]?.table === table);
      if (!mine.length) continue;
      const exists: unknown[] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM ${qcol(table)} WHERE "CO_CODE"=$1 LIMIT 1`,
        scope.coCode,
      );
      if (!exists.length) {
        await tx.$executeRawUnsafe(
          `INSERT INTO ${qcol(table)}(tenant_id,"CO_CODE") VALUES ($1,$2)`,
          scope.tenantId,
          scope.coCode,
        );
      }
      // Write the COLUMN name, not the descriptor id.
      const sets = mine
        .map((k, i) => `${qcol(SETTING_CATALOG_BY_ID[k]!.key)}=$${i + 2}`)
        .join(', ');
      await tx.$executeRawUnsafe(
        `UPDATE ${qcol(table)} SET ${sets} WHERE "CO_CODE"=$1`,
        scope.coCode,
        ...mine.map((k) => values.get(k)),
      );
      changed += mine.length;
    }
    return { saved: true, changed };
  });
}

/** Exposure metric for the parity gate: catalog coverage of the schema-derived denominator. */
export function settingsExposure(): { exposed: number; total: number; pct: number } {
  const total = new Set(CONFIGURABLE_SETTINGS.map((c) => c.key)).size;
  const exposed = new Set(SETTING_CATALOG.map((d) => d.key)).size;
  return { exposed, total, pct: Math.round((1000 * exposed) / total) / 10 };
}
