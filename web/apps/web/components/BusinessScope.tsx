'use client';

import { createContext, useContext, useMemo } from 'react';
import {
  resolveRoundingPolicy,
  type RoundingFlagValues,
  type RoundingPolicy,
} from '@datacare/core';

export interface BusinessScope {
  coCode: string;
  lcCode: string;
  coYear: string;
}

const BusinessScopeContext = createContext<BusinessScope | null>(null);
/**
 * The company money-rounding flags from the session (`/me`), kept SEPARATE from `BusinessScope` because the
 * scope object is spread into query-parameter bags; a screen builds the same policy the server posts with so
 * a document's previewed total matches the saved total (G102/G84). Null keeps the 2dp default.
 */
const RoundingFlagsContext = createContext<RoundingFlagValues | null>(null);

export function BusinessScopeProvider({
  scope,
  roundingFlags = null,
  children,
}: {
  scope: BusinessScope;
  roundingFlags?: RoundingFlagValues | null;
  children: React.ReactNode;
}) {
  return (
    <BusinessScopeContext.Provider value={scope}>
      <RoundingFlagsContext.Provider value={roundingFlags}>
        {children}
      </RoundingFlagsContext.Provider>
    </BusinessScopeContext.Provider>
  );
}

/**
 * Current company/location/year comes from the server-authenticated session loaded by app layout.
 * Business pages must use this hook instead of editable or hard-coded scope defaults.
 */
export function useBusinessScope(): BusinessScope {
  const scope = useContext(BusinessScopeContext);
  if (!scope) throw new Error('business-scope-provider-missing');
  return scope;
}

/**
 * The company money-rounding policy for the current session, built once from the session flags. Pass it to
 * `billTotals` in a screen's preview so the shown total equals the posted total (G102/G84). With no flags it
 * resolves to the 2dp default.
 */
export function useRoundingPolicy(): RoundingPolicy {
  const flags = useContext(RoundingFlagsContext);
  return useMemo(() => resolveRoundingPolicy(flags ?? {}), [flags]);
}
