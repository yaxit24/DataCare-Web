'use client';
import { useEffect, useState } from 'react';
import { get } from './api';
import { useBusinessScope } from '../components/BusinessScope';

type Actions = { canDelete: boolean; canPrint: boolean };
const denied: Actions = { canDelete: false, canPrint: false };
/** Session-owned USER_SET rights; unavailable/loading rights fail closed. Server authorization remains mandatory. */
export function useFormRights(form: string): Actions {
  const { coCode, lcCode, coYear } = useBusinessScope();
  const scope = `${coCode}/${lcCode}/${coYear}/${form}`;
  const [loaded, setLoaded] = useState<{ scope: string; rights: Actions } | null>(null);
  useEffect(() => {
    let active = true;
    setLoaded(null);
    void get<{ isAdmin: boolean; formActions: Record<string, Actions> | null }>('/me')
      .then((me) => {
        if (active)
          setLoaded({
            scope,
            rights: me.isAdmin
              ? { canDelete: true, canPrint: true }
              : (me.formActions?.[form] ?? denied),
          });
      })
      .catch(() => {
        if (active) setLoaded({ scope, rights: denied });
      });
    return () => {
      active = false;
    };
  }, [scope, form]);
  return loaded?.scope === scope ? loaded.rights : denied;
}
