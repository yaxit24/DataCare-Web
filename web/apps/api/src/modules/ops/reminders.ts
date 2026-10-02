import { withTxBudget } from '../shared/txBudget.js';
import {
  MessagingUnconfiguredError,
  senderFromEnv,
  notifyWithAttemptLog,
} from '../integrations/messaging.js';
import type { Channel, MessagingMode, NotifyResult } from '../integrations/messaging.js';
import type { ReportScope, ListReport } from '../reports/reports.js';

/**
 * Phase 12 — UT_REMINDER. Read-only reminder datasets + a sendable bridge to the messaging provider.
 *
 * Built in the exact style of reports.ts / reports2.ts: withTenant() supplies the e2e-safe tenant
 * context, NN() casts the desktop's text-typed amount columns to numeric, and the list datasets
 * return the ListReport { rows, totals } shape, scoped by WHERE "CO_CODE"=$1.
 *
 *  • overdueReminders  — parties carrying an outstanding (unpaid) balance in BILL_OS_DATA, with the
 *    party name + mobile resolved from AC_MAST, the consolidated balance Σ(BILL_AMT−REC_AMT), the
 *    oldest open-bill date and days overdue.
 *  • birthdayReminders — parties whose AC_MAST birthday (BR_DATE / L_BR_DATE) or anniversary
 *    (AN_DATE) falls on a given day (defaults to today). The columns exist in this schema; if a
 *    deployment lacks them the query is caught and an empty result with a note is returned.
 *  • sendReminder      — claims a persistent tenant/idempotency attempt before calling the
 *    configured provider and reports the stored/provider result. Duplicate keys are at-most-once.
 *
 * Dataset functions are read-only; sendReminder writes only the outbound attempt log.
 */

const round2 = (x: number): number => Math.round((x + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => Number(v ?? 0);
/** Desktop amount columns are text-typed; coalesce empty/non-numeric to 0 (matches reports.ts NN). */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;
const pad2 = (n: number): string => String(n).padStart(2, '0');

/** ListReport plus an optional free-text status line (data-source note / fallback message). */
export interface ReminderList extends ListReport {
  note?: string;
}

/**
 * Outstanding-due reminders (BILL_OS_DATA): one row per party with a net unpaid balance
 * Σ(BILL_AMT − REC_AMT) > 0. Party name + mobile come from AC_MAST (AC_MOBILE, falling back to
 * AC_MOBILE2). oldestBill is the earliest open voucher date and daysOverdue is the age of that bill
 * in days (CURRENT_DATE − oldest). Scoped by company only (outstanding accrues across years, so the
 * reminder must reflect the party's whole open position, not a single CO_YEAR). Ordered by balance.
 */
export async function overdueReminders(prisma: any, s: ReportScope): Promise<ListReport> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT b."AC_CODE" AS "acCode",
              (SELECT m."AC_NAME" FROM "AC_MAST" m
                 WHERE m."AC_CODE"::text=b."AC_CODE"::text AND m."CO_CODE"::text=b."CO_CODE"::text LIMIT 1) AS party,
              (SELECT coalesce(NULLIF(m."AC_MOBILE",''), NULLIF(m."AC_MOBILE2",'')) FROM "AC_MAST" m
                 WHERE m."AC_CODE"::text=b."AC_CODE"::text AND m."CO_CODE"::text=b."CO_CODE"::text LIMIT 1) AS mobile,
              sum(${NN('b."BILL_AMT"')} - ${NN('b."REC_AMT"')}) AS balance,
              count(*)::int AS bills,
              min(b."VCH_DATE") AS "oldestBill",
              (CURRENT_DATE - min(b."VCH_DATE"))::int AS "daysOverdue"
       FROM "BILL_OS_DATA" b
       WHERE b."CO_CODE"=$1
       GROUP BY b."AC_CODE", b."CO_CODE"
       HAVING sum(${NN('b."BILL_AMT"')} - ${NN('b."REC_AMT"')}) > 0.005
       ORDER BY balance DESC`,
      s.coCode,
    );
    const out = rows.map((r) => ({
      acCode: r.acCode,
      party: r.party ?? r.acCode,
      mobile: r.mobile ?? null,
      bills: Number(r.bills),
      balance: round2(num(r.balance)),
      oldestBill: r.oldestBill ?? null,
      daysOverdue: r.daysOverdue != null ? Number(r.daysOverdue) : null,
    }));
    return {
      rows: out,
      totals: {
        parties: out.length,
        bills: out.reduce((t, r) => t + r.bills, 0),
        balance: round2(out.reduce((t, r) => t + r.balance, 0)),
      },
    };
  });
}

/** Resolve the month/day to match against, from an optional onDate (defaults to today).
 *  A bare YYYY-MM-DD string is read literally (no timezone shift); anything else goes via Date. */
function monthDay(onDate?: Date | string): { month: number; day: number; iso: string } {
  if (typeof onDate === 'string') {
    const m = onDate.match(/^(\d{4})-(\d{2})-(\d{2})/);
    if (m) return { month: Number(m[2]), day: Number(m[3]), iso: `${m[1]}-${m[2]}-${m[3]}` };
  }
  const d = onDate != null ? new Date(onDate) : new Date();
  const dd = isNaN(d.getTime()) ? new Date() : d;
  return { month: dd.getMonth() + 1, day: dd.getDate(), iso: dd.toISOString().slice(0, 10) };
}

/**
 * Birthday / anniversary reminders (AC_MAST): parties whose birthday (L_BR_DATE date column, or the
 * text BR_DATE when it holds an ISO date) or anniversary (text AN_DATE) shares the month+day of
 * `onDate` (defaults to today). Each row carries the occasion ('Birthday' | 'Anniversary'), party,
 * mobile and the stored date. These columns exist in the current schema; should a deployment lack
 * them the query error is caught and an empty result with an explanatory note is returned.
 */
export async function birthdayReminders(
  prisma: any,
  s: ReportScope,
  onDate?: Date | string,
): Promise<ReminderList> {
  const { month, day, iso } = monthDay(onDate);
  const mmdd = `${pad2(month)}-${pad2(day)}`;
  try {
    return await withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
      const rows: any[] = await tx.$queryRawUnsafe(
        `WITH src AS (
           SELECT "AC_CODE" AS "acCode", "AC_NAME" AS party,
                  coalesce(NULLIF("AC_MOBILE",''), NULLIF("AC_MOBILE2",'')) AS mobile,
                  COALESCE("L_BR_DATE",
                    CASE WHEN "BR_DATE" ~ '^[0-9]{4}-[0-9]{2}-[0-9]{2}' THEN "BR_DATE"::date END) AS bday,
                  CASE WHEN "AN_DATE" ~ '^[0-9]{4}-[0-9]{2}-[0-9]{2}' THEN "AN_DATE"::date END AS aniv
           FROM "AC_MAST" WHERE "CO_CODE"=$1
         )
         SELECT "acCode", party, mobile, 'Birthday' AS occasion, bday AS "onDate"
           FROM src WHERE bday IS NOT NULL
             AND EXTRACT(MONTH FROM bday)=$2 AND EXTRACT(DAY FROM bday)=$3
         UNION ALL
         SELECT "acCode", party, mobile, 'Anniversary' AS occasion, aniv AS "onDate"
           FROM src WHERE aniv IS NOT NULL
             AND EXTRACT(MONTH FROM aniv)=$2 AND EXTRACT(DAY FROM aniv)=$3
         ORDER BY occasion, party`,
        s.coCode,
        month,
        day,
      );
      const out = rows.map((r) => ({
        acCode: r.acCode,
        party: r.party ?? r.acCode,
        mobile: r.mobile ?? null,
        occasion: String(r.occasion),
        onDate: r.onDate ?? null,
      }));
      const birthdays = out.filter((r) => r.occasion === 'Birthday').length;
      const anniversaries = out.filter((r) => r.occasion === 'Anniversary').length;
      const note =
        out.length === 0
          ? `No birthdays/anniversaries on ${mmdd}. Source: AC_MAST BR_DATE/L_BR_DATE & AN_DATE (few party masters currently carry these dates).`
          : `Matched AC_MAST BR_DATE/L_BR_DATE (birthday) & AN_DATE (anniversary) for ${mmdd}.`;
      return { rows: out, totals: { count: out.length, birthdays, anniversaries }, note };
    });
  } catch (e: any) {
    // Birthday/anniversary columns may be absent in some deployments — degrade to empty + note.
    return {
      rows: [],
      totals: { count: 0, birthdays: 0, anniversaries: 0 },
      note: `Birthday/anniversary reminders unavailable for ${iso}: ${e?.message ?? 'no birthday column'}.`,
    };
  }
}

export interface SendReminderInput {
  /** Recipient phone (E.164 ideally); required. */
  mobile: string;
  /** Rendered message body. */
  message: string;
  /** Optional override; defaults to the channel implied by the configured provider. */
  channel?: Channel;
  idempotencyKey: string;
  templateKind: string;
}

export interface SendReminderResult {
  /** True only when a real provider accepted the reminder (not proof of delivery). */
  ok: boolean;
  /** `accepted` by a provider, `simulated` in explicit test mode, or `failed` (G33). */
  status: NotifyResult['status'];
  /** Provider mode: 'whatsapp-cloud' | 'http-sms' | 'simulated' (MESSAGING_FAKE_MODE outside production). */
  mode: MessagingMode;
  channel: Channel;
  to: string;
  id?: string;
  error?: string;
  deduplicated: boolean;
}

/**
 * Send one reminder through the persistent tenant-scoped at-most-once messaging workflow.
 *
 * With no provider configured this throws `MessagingUnconfiguredError` (HTTP 503) BEFORE an attempt is
 * recorded, rather than "sending" through a fake (N54 step 4, G33).
 */
export async function sendReminder(
  prisma: any,
  scope: Pick<ReportScope, 'tenantId' | 'coCode' | 'lcCode'>,
  input: SendReminderInput,
): Promise<SendReminderResult> {
  const to = String(input?.mobile ?? '').trim();
  const body = String(input?.message ?? '');
  const { sender, mode } = senderFromEnv();
  if (!sender) throw new MessagingUnconfiguredError();
  const channel: Channel = input?.channel ?? (mode === 'http-sms' ? 'sms' : 'whatsapp');
  const result = await notifyWithAttemptLog(
    prisma,
    sender,
    scope,
    { to, channel, body },
    { idempotencyKey: input.idempotencyKey, templateKind: input.templateKind },
  );
  return { ...result, mode, channel, to };
}
