'use client';
import { useCallback, useEffect, useRef } from 'react';

/** A local UI callback lease, not server authority or cancellation of an already sent request. */
export function useOperationLease(scopeKey?: unknown): { beginOperation: () => () => boolean } {
  const mounted = useRef(false);
  const generation = useRef(0);
  const scope = useRef(scopeKey);
  scope.current = scopeKey;
  useEffect(() => {
    mounted.current = true;
    return () => {
      mounted.current = false;
      // Read the latest scalar generation: every outstanding callback, including a StrictMode
      // setup/cleanup/setup callback, must stay invalid after this cleanup.
      generation.current += 1;
    };
  }, [scopeKey]);
  const beginOperation = useCallback(() => {
    const admitted = mounted.current;
    const operation = ++generation.current;
    const admittedScope = scope.current;
    return () => admitted && mounted.current && generation.current === operation && Object.is(scope.current, admittedScope);
  }, []);
  return { beginOperation };
}
