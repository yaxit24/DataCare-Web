'use client';

import { useEffect, useMemo, useRef, useState, useSyncExternalStore } from 'react';
import { ImageEditorSession, type ImageEditorTransport } from './imageEditorSession';
import { ImageScopeBarrier } from './imageScopeBarrier';

/** Retained parent drafts are not evidence that the same key belongs to the newly selected scope. */
export function useImageScopeBarrier(scope: { coCode: string; lcCode: string; coYear: string }) {
  const key = JSON.stringify([scope.coCode, scope.lcCode, scope.coYear]);
  const barrier = useRef<ImageScopeBarrier | null>(null);
  if (!barrier.current) barrier.current = new ImageScopeBarrier(key);
  const [, render] = useState(0);
  const blocked = barrier.current.observe(key);
  const generation = barrier.current.generationToken();
  return {
    blocked,
    acknowledge: () => {
      if (barrier.current?.acknowledge(key, generation)) render((value) => value + 1);
    },
  };
}

/** Transport must be memoized from the complete selected scope/record identity. */
export function useImageEditor(
  identity: string,
  transport: ImageEditorTransport,
  disabled = false,
) {
  const context = useRef({ identity, disabled });
  context.current = { identity, disabled };
  const session = useMemo(
    () =>
      new ImageEditorSession(
        transport,
        () => Boolean(identity) && context.current.identity === identity,
        () => context.current.identity === identity && !context.current.disabled,
      ),
    [identity, transport],
  );
  const state = useSyncExternalStore(session.subscribe, session.getSnapshot, session.getSnapshot);
  useEffect(() => {
    session.activate();
    void session.reload();
    return () => session.dispose();
  }, [session]);
  return { session, state };
}
