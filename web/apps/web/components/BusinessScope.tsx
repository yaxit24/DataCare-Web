'use client';

import { createContext, useContext } from 'react';

export interface BusinessScope {
  coCode: string;
  lcCode: string;
  coYear: string;
}

const BusinessScopeContext = createContext<BusinessScope | null>(null);

export function BusinessScopeProvider({
  scope,
  children,
}: {
  scope: BusinessScope;
  children: React.ReactNode;
}) {
  return <BusinessScopeContext.Provider value={scope}>{children}</BusinessScopeContext.Provider>;
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
