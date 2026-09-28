/**
 * Tag invariants (WP-07, plan §7.1).
 *
 * The plan states twelve tag invariants and says they "become database constraints, transactional assertions,
 * and replay checks where feasible". Four of them are properties of the PERSISTED DATA and can therefore be
 * checked by SQL at any time — against a test fixture, a migrated company, or production. The rest are
 * properties of code paths, or wait on decisions nobody has taken yet; `TAG_INVARIANT_COVERAGE` records which
 * is which, because an invariant that is merely written down is indistinguishable from one that is enforced.
 *
 * WHY IDENTITY IS THE WHOLE PROBLEM
 * =================================
 * `TAG_NO` alone is not an identity. The desktop reuses tag text across companies, locations and time, and
 * distinguishes instances by `VCH_SRNO`. The existing kernel already knows this — `stock.ts` carries `TagKey`
 * with `VCH_SRNO`, refuses an ambiguous match with `TagIdentityAmbiguousValidationError`, and serialises
 * `issueTagTx` on an advisory lock — so these checks ask whether the DATA obeys the same rule, which is the
 * half that code cannot assert about itself.
 *
 * WHAT A VIOLATION MEANS
 * ======================
 * Not "a test failed". A duplicate live identity means two rows claim the same physical ornament, so whichever
 * one a query happens to read decides what the shop believes it owns. A signed on-hand of 2 means an ornament
 * was admitted twice; of -1, that it was issued without ever being admitted. These are the failures that the
 * plan's §7 tag matrix exists to prevent, expressed as queries rather than prose.
 */

export type TagInvariantId =
  | 'INV-1-unambiguous-live-identity'
  | 'INV-2-serial-allocated-once'
  | 'INV-3-on-hand-zero-or-one'
  | 'INV-9-movement-has-provenance';

export interface TagInvariantViolation {
  invariant: TagInvariantId;
  /** Business key of the offending identity, formatted for an operator. */
  identity: string;
  detail: string;
}

export interface TagInvariantResult {
  invariant: TagInvariantId;
  title: string;
  /** What the plan requires, quoted. */
  requirement: string;
  violations: TagInvariantViolation[];
  /** Rows examined, so a clean result on an empty table is not mistaken for a proof. */
  examined: number;
}

export interface TagInvariantReport {
  healthy: boolean;
  checkedAt: string;
  results: TagInvariantResult[];
  totalViolations: number;
}

const asNumber = (value: unknown): number => {
  const n = Number(value);
  return Number.isFinite(n) ? n : 0;
};

const rows = async (tx: any, sql: string): Promise<Array<Record<string, unknown>>> =>
  (await tx.$queryRawUnsafe(sql)) as Array<Record<string, unknown>>;

/**
 * SQL predicate selecting genuinely TAGGED rows.
 *
 * `TAG_NO <> ''` is not that predicate. The desktop never stores an empty tag on a stock row: its shared stock
 * poster substitutes the literal `'N'` for untagged stock — `CASE WHEN A.TAG_NO = '' THEN 'N' ELSE A.TAG_NO END`
 * (Ac_Stock.cs:54) — and hardcodes `'N'` in every untagged insert (Ac_Stock.cs:15, :17, :32, :42, :44, :56).
 * It reads loose stock back the same way, with `TAG_NO = 'N'` (TR_KR_ISU.cs:6961,
 * TR_MFG_KR_ISU_REC.cs:4694, :8096, :8100). The web writes the same sentinel (stock.ts:780, :934, :1036) and
 * the untag repair restores it (dataRepairOps.ts:646).
 *
 * Filtering only on non-empty therefore swept every loose movement in a company into one fabricated identity
 * `('N', 0)`, whose signed net is the entire loose balance — so INV-3 reported a violation for stock that was
 * never tagged, and INV-2 reported a reused serial for untagged barcode rows that legitimately share ('N', 0).
 * Both were false positives on any real company holding loose stock.
 */
const IS_TAGGED = `coalesce("TAG_NO"::text,'') NOT IN ('', 'N')`;

/**
 * Run the data-level tag invariants.
 *
 * `tx` must already be scoped to a tenant (RLS does the scoping), which is why no tenant parameter appears:
 * a check that could be pointed at another tenant's rows would be a cross-tenant read dressed as diagnostics.
 */
export async function checkTagInvariants(tx: any): Promise<TagInvariantReport> {
  const results: TagInvariantResult[] = [];

  // INV-1. A live tag identity is unambiguous.
  //
  // This one is already a DATABASE CONSTRAINT, which is the strongest form the plan asks for: `TAG_STOCK`'s
  // primary key is (tenant_id, CO_CODE, LC_CODE, TAG_NO), so a second live row claiming the same tag text in
  // the same company and location cannot be inserted at all. Scanning for duplicates would therefore be
  // theatre — the check that can actually fail is whether the constraint still EXISTS, because dropping it
  // would silently turn an enforced invariant into an unenforced one.
  //
  // Note what the key does NOT include: `VCH_SRNO`. At most one instance of a tag text is LIVE per location,
  // and the serial distinguishes instances over TIME in the history tables. `issueTagTx` locks on
  // `tag-issue|CO|LC|TAG_NO` for the same reason, so the lock granularity and the constraint agree.
  {
    const key = await rows(
      tx,
      `SELECT string_agg(a.attname, ',' ORDER BY k.ord) AS cols
         FROM pg_index ix
         JOIN pg_class t ON t.oid = ix.indrelid
         JOIN pg_namespace n ON n.oid = t.relnamespace
         CROSS JOIN LATERAL unnest(ix.indkey) WITH ORDINALITY AS k(attnum, ord)
         JOIN pg_attribute a ON a.attrelid = t.oid AND a.attnum = k.attnum
        WHERE n.nspname='public' AND t.relname='TAG_STOCK' AND ix.indisunique`,
    );
    const columns = String(key[0]?.cols ?? '');
    const required = ['tenant_id', 'CO_CODE', 'LC_CODE', 'TAG_NO'];
    const missing = required.filter((c) => !columns.split(',').includes(c));
    const examined = await rows(tx, `SELECT count(*)::int n FROM "TAG_STOCK"`);
    results.push({
      invariant: 'INV-1-unambiguous-live-identity',
      title: 'A live tag identity is unambiguous, enforced by the TAG_STOCK key',
      requirement:
        'plan §7.1(1): a live tag identity is unambiguous for company/location/tag/serial/item',
      examined: asNumber(examined[0]?.n),
      violations: missing.length
        ? [
            {
              invariant: 'INV-1-unambiguous-live-identity' as const,
              identity: 'TAG_STOCK',
              detail:
                `the unique key is (${columns || 'none'}) and no longer covers ${missing.join(', ')}; ` +
                'two live rows could claim one ornament',
            },
          ]
        : [],
    });
  }

  // INV-2. A serial is allocated once.
  //
  // Two BAR_DETL rows sharing company/location/tag/serial means the serial allocator handed the same identity
  // out twice, or a rollback left a partial one behind.
  {
    const dupes = await rows(
      tx,
      `SELECT "CO_CODE" co,"LC_CODE" lc,"TAG_NO" tag,coalesce("VCH_SRNO",0)::text srno,count(*)::int n
         FROM "BAR_DETL"
        WHERE ${IS_TAGGED}
        GROUP BY 1,2,3,4
       HAVING count(*) > 1
        ORDER BY n DESC, tag
        LIMIT 50`,
    );
    const examined = await rows(tx, `SELECT count(*)::int n FROM "BAR_DETL" WHERE ${IS_TAGGED}`);
    results.push({
      invariant: 'INV-2-serial-allocated-once',
      title: 'A tag serial is allocated once',
      requirement:
        'plan §7.1(2): a serial is allocated once; rollback cannot expose a partially created identity',
      examined: asNumber(examined[0]?.n),
      violations: dupes.map((r) => ({
        invariant: 'INV-2-serial-allocated-once' as const,
        identity: `${r.co}/${r.lc}/${r.tag}#${r.srno}`,
        detail: `${asNumber(r.n)} BAR_DETL rows share this identity`,
      })),
    });
  }

  // INV-3. Signed on-hand per exact identity is 0 or 1.
  //
  // `MAIN_STOCK.ITM_SIGN` carries the direction and `ITM_PCS` the pieces. A tagged ornament is one piece, so
  // the signed net across all its movements is 1 while it is held and 0 once it has left. 2 means it was
  // admitted twice; -1 means it was issued without ever being admitted.
  {
    const offenders = await rows(
      tx,
      `SELECT "CO_CODE" co,"LC_CODE" lc,"TAG_NO" tag,coalesce("VCH_SRNO",0)::text srno,
              sum(CASE WHEN "ITM_SIGN"::text='+'
                       THEN coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)
                       ELSE -coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0) END)::float net
         FROM "MAIN_STOCK"
        WHERE ${IS_TAGGED}
        GROUP BY 1,2,3,4
       HAVING sum(CASE WHEN "ITM_SIGN"::text='+'
                       THEN coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)
                       ELSE -coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0) END) NOT IN (0,1)
        ORDER BY tag
        LIMIT 50`,
    );
    const examined = await rows(tx, `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE ${IS_TAGGED}`);
    results.push({
      invariant: 'INV-3-on-hand-zero-or-one',
      title: 'Signed on-hand per exact identity is 0 or 1',
      requirement:
        'plan §7.1(3): signed on-hand balance per exact identity is only 0 or 1 unless a documented desktop branch permits otherwise',
      examined: asNumber(examined[0]?.n),
      violations: offenders.map((r) => ({
        invariant: 'INV-3-on-hand-zero-or-one' as const,
        identity: `${r.co}/${r.lc}/${r.tag}#${r.srno}`,
        detail: `signed on-hand is ${asNumber(r.net)}, which is neither 0 nor 1`,
      })),
    });
  }

  // INV-9. Every tagged movement can be traced back to the voucher that made it.
  //
  // The plan asks for provenance "and, where required, BAR_DETL/BAR_IDTL". Which movements REQUIRE a
  // BAR_DETL row is a desktop question nobody has answered — imported tags legitimately live in TAG_STOCK
  // alone — so this checks the part that is unconditional: a movement must name its book and voucher. A
  // movement that names neither cannot be explained to an auditor at all.
  {
    const orphans = await rows(
      tx,
      `SELECT "CO_CODE" co,"LC_CODE" lc,"TAG_NO" tag,coalesce("VCH_SRNO",0)::text srno,
              coalesce("CO_BOOK"::text,'') book, coalesce("VCH_NO"::text,'') vch
         FROM "MAIN_STOCK"
        WHERE ${IS_TAGGED}
          AND (coalesce("CO_BOOK"::text,'') = '' OR coalesce("VCH_NO"::text,'') = '')
        ORDER BY tag
        LIMIT 50`,
    );
    const examined = await rows(tx, `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE ${IS_TAGGED}`);
    results.push({
      invariant: 'INV-9-movement-has-provenance',
      title: 'Every tagged movement names its voucher',
      requirement:
        'plan §7.1(9): every MAIN_STOCK tag movement can join to its provenance and, where required, BAR_DETL/BAR_IDTL',
      examined: asNumber(examined[0]?.n),
      violations: orphans.map((r) => ({
        invariant: 'INV-9-movement-has-provenance' as const,
        identity: `${r.co}/${r.lc}/${r.tag}#${r.srno}`,
        detail: `movement names book '${String(r.book)}' voucher '${String(r.vch)}'`,
      })),
    });
  }

  const totalViolations = results.reduce((sum, r) => sum + r.violations.length, 0);
  return {
    healthy: totalViolations === 0,
    checkedAt: new Date().toISOString(),
    results,
    totalViolations,
  };
}

/** How an invariant is currently held, if at all. */
export type InvariantEnforcement =
  /** Checked against persisted data by `checkTagInvariants`. */
  | 'data-check'
  /** Enforced by a code path that a test exercises. */
  | 'code-tested'
  /** The unsafe path is blocked outright, so the invariant cannot be violated through the API. */
  | 'contained'
  /** Cannot be settled without a decision the owner has not taken. */
  | 'blocked-owner-decision'
  /** Waits on the §7.2 transition model, which must be derived from desktop evidence. */
  | 'blocked-transition-model';

export interface TagInvariantCoverage {
  number: number;
  invariant: string;
  enforcement: InvariantEnforcement;
  evidence: string;
}

/**
 * The twelve §7.1 invariants and how each is actually held today.
 *
 * This table is the honest half of WP-07. Its exit criterion asks that invariants 1–12 be "enforced/tested
 * under concurrency"; four are checkable against data, several are held by code with tests, four of the
 * riskiest are held only because WP-01 CONTAINS the operation that would violate them, and two cannot be
 * settled at all until an owner decides a business rule. Recording that distinction is what stops a reader
 * concluding that a written invariant is a kept one.
 */
export const TAG_INVARIANT_COVERAGE: readonly TagInvariantCoverage[] = Object.freeze([
  {
    number: 1,
    invariant: 'A live tag identity is unambiguous for company/location/tag/serial/item',
    enforcement: 'data-check',
    evidence:
      'enforced as a DATABASE CONSTRAINT: TAG_STOCK primary key (tenant_id, CO_CODE, LC_CODE, TAG_NO). checkTagInvariants INV-1 asserts the constraint still exists; issueTagTx additionally refuses an ambiguous match',
  },
  {
    number: 2,
    invariant: 'A serial is allocated once; rollback cannot expose a partial identity',
    enforcement: 'data-check',
    evidence:
      'checkTagInvariants INV-2. BAR_DETL has only a surrogate row_id key, so nothing in the schema prevents a duplicated identity — this is why a data check is needed rather than a constraint assertion',
  },
  {
    number: 3,
    invariant: 'Signed on-hand per exact identity is only 0 or 1',
    enforcement: 'data-check',
    evidence:
      'checkTagInvariants INV-3 over signed MAIN_STOCK movements; MAIN_STOCK is likewise keyed only on row_id',
  },
  {
    number: 4,
    invariant:
      'Sale, transfer, split, weight replacement and cancel serialise on one identity lock',
    enforcement: 'code-tested',
    evidence:
      'issueTagTx takes pg_advisory_xact_lock on tag-issue|CO|LC|TAG_NO; concurrent double issue is covered by a database test. Transfer/split/weight/cancel are CONTAINED by WP-01, so they cannot contend today',
  },
  {
    number: 5,
    invariant:
      'Parent split OUT equals children IN within approved tolerance, or posts the desktop absorption branch',
    enforcement: 'blocked-owner-decision',
    evidence:
      'plan §8.1 item 3 — split conservation tolerance and absorbing account are undecided; split is contained',
  },
  {
    number: 6,
    invariant: 'Tag transfer conserves the desktop measures between tag OUT and target IN',
    enforcement: 'contained',
    evidence:
      'WP-01 blocks tag transfer; conservation is unproved and the route returns 503 PARITY_CONTAINMENT',
  },
  {
    number: 7,
    invariant: 'A sold tag cannot be sold, split, transferred, changed or cancelled concurrently',
    enforcement: 'code-tested',
    evidence:
      'TAG_STOCK row presence plus the atomic DELETE affected-row check; the other four operations are contained',
  },
  {
    number: 8,
    invariant: 'A return must reference one original issue and can re-admit it only once',
    enforcement: 'blocked-owner-decision',
    evidence:
      'plan §8.1 item 2 — old-tag versus new-tag identity on return is undecided; the web restores the same identity',
  },
  {
    number: 9,
    invariant: 'Every MAIN_STOCK tag movement can join to its provenance',
    enforcement: 'data-check',
    evidence:
      'checkTagInvariants INV-9 asserts book and voucher are named; the BAR_DETL half needs desktop evidence',
  },
  {
    number: 10,
    invariant:
      'Images, HUIDs, sub-details, source voucher and order links survive the approved lineage rules',
    enforcement: 'blocked-transition-model',
    evidence:
      'plan §7 records that split/weight/cancel do not migrate image lineage; those paths are contained and the lineage rules are unwritten',
  },
  {
    number: 11,
    invariant: 'Delete/edit restores the complete prior state or fails before any mutation',
    enforcement: 'code-tested',
    evidence:
      'reverseVoucherTx and replaceWriteSetTx run inside one transaction; tag-opening update is contained by WP-01',
  },
  {
    number: 12,
    invariant: 'Concurrent print jobs and reports never share mutable staging rows',
    enforcement: 'blocked-transition-model',
    evidence:
      'plan §7 records that tag-print staging clears all tenant rows; an immutable print-job id is WP-10 work',
  },
]);
