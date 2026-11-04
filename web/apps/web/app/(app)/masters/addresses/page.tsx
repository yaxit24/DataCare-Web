'use client';
import {
  useCallback,
  useEffect,
  useLayoutEffect,
  useMemo,
  useRef,
  useState,
  type KeyboardEvent,
} from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Address master (desktop MS_ADD_MAST, Master → Address), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_ADD_MAST.layout.json`): the SEARCH RECORD box and the Code / Name list on the
 * left; the Company Detail, Other Detail and Family Detl tabs on the right; Print, Save, Cancel, Delete and Exit along
 * the bottom.
 *
 * - A new entry offers the next code of the location, read-only, with the cursor in the name (CLEAR_DATA,
 *   MS_ADD_MAST.cs:3454-3547); Ctrl+E unlocks the code box (:3721-3738). Enter on the list or a double click opens an
 *   address with the cursor in the name (:3690-3719).
 * - Keys: typed letters are upper-cased and the apostrophe refused (:3604-3617). F1 on the name or the F1 button opens the
 *   help of the location's addresses (:3740-3775); typing a name lists up to 99 of the company's addresses whose name
 *   starts with it (tAcName_KeyUp :4171-4294); Enter on a blank name says "Please Insert Party Name ..."; Enter on the
 *   mobile of a new entry refuses a mobile the company has (:3867-3887); Enter on every other box moves on, and on L Birth
 *   Date goes to Save (:4316-4325). Esc leaves the screen.
 * - Leaving the name refuses a name another code has (:4389-4409); a refusal also stops Save, Delete and Print, as the
 *   desktop's cancelled Validating suppresses the button's click.
 * - Save, Delete and Print answer with the desktop texts and rights (:3675-3689, :4411-4544).
 *
 * Deliberate differences: the next code is the location prefix and four digits; an opened address carries the version
 * read with it; the search box drops SEARCH RECORD whenever it gets the cursor; Print shows the addresses on the screen
 * because the PartyMast report layout is not in the repository. The customer-detail box over the tabs (tCustDetl) and the
 * import button (hidden) are left out.
 */
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Account now?';
const SELECT_FOR_DELETE = 'Please Select AcCode For Delete.';
const NAME_REQUIRED = 'Please Insert Party Name ...';
const DETAIL_REQUIRED = 'Please Select Customer name and try....';
const SEARCH_TEXT = 'SEARCH RECORD';
const nameTaken = (code: string) =>
  `This Ac Name already Exist in  '${code}'  Ac Code... Please Change Account Name...`;
const mobileTaken = (name: string) => `This Mobile No = ${name}  With this Account .....`;

type Key =
  | 'name'
  | 'group'
  | 'mobile'
  | 'phone'
  | 'person'
  | 'address1'
  | 'address2'
  | 'address3'
  | 'city'
  | 'pin'
  | 'area'
  | 'country'
  | 'state'
  | 'district'
  | 'email'
  | 'birthDate'
  | 'anniversary'
  | 'lBirthDate'
  | 'mobile2'
  | 'phone2';
type Combo = 'groups' | 'countries' | 'states' | 'districts' | 'cities' | 'areas';
/** Company Detail in tab order (Pnl1, tab indexes 1-22), with the box's MaxLength and its combo list. */
const COMPANY: Array<{
  key: Key;
  label: string;
  max?: number;
  width: number;
  combo?: Combo;
  date?: boolean;
}> = [
  { key: 'name', label: 'Ac Name', max: 50, width: 391 },
  { key: 'group', label: 'Ac Group', max: 15, width: 391, combo: 'groups' },
  { key: 'mobile', label: 'Mobile No', max: 15, width: 158 },
  { key: 'phone', label: 'Phone No', max: 15, width: 148 },
  { key: 'person', label: 'Con Person', max: 40, width: 391 },
  { key: 'address1', label: 'Address1', max: 50, width: 391 },
  { key: 'address2', label: 'Address2', max: 50, width: 391 },
  { key: 'address3', label: 'Address3', max: 50, width: 391 },
  { key: 'city', label: 'City', max: 20, width: 216, combo: 'cities' },
  { key: 'pin', label: 'Pin Code', max: 8, width: 102 },
  { key: 'area', label: 'City Area', max: 25, width: 391, combo: 'areas' },
  { key: 'country', label: 'Country', max: 20, width: 391, combo: 'countries' },
  { key: 'state', label: 'State', max: 20, width: 391, combo: 'states' },
  { key: 'district', label: 'District', max: 20, width: 391, combo: 'districts' },
  { key: 'email', label: 'Email', max: 50, width: 391 },
  { key: 'birthDate', label: 'Birth Date', width: 90, date: true },
  { key: 'anniversary', label: 'Anv Date', width: 90, date: true },
  { key: 'lBirthDate', label: 'L Birth Date', width: 90, date: true },
];
const OTHER: typeof COMPANY = [
  { key: 'mobile2', label: 'Mobile No2', max: 15, width: 148 },
  { key: 'phone2', label: 'Phone No2', max: 15, width: 148 },
];
/** Rows the form spec draws side by side (Mobile with Phone, City with Pin Code, the three dates). */
const PAIRS: Record<string, Key> = { mobile: 'phone', city: 'pin', birthDate: 'anniversary' };
const PAIRED = new Set(Object.values(PAIRS));

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
  group?: string;
  address?: string;
  phone?: string;
  mobile?: string;
}
type Values = Record<Key, string>;
const blank = (): Values =>
  Object.fromEntries([...COMPANY, ...OTHER].map((f) => [f.key, ''])) as Values;
/** MS_ADD_MAST_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
/** The masked date boxes (mask 00/00/0000): digits only, with the slashes the mask shows. */
const maskDate = (value: string) => {
  const d = value.replace(/\D/g, '').slice(0, 8);
  if (d.length > 4) return `${d.slice(0, 2)}/${d.slice(2, 4)}/${d.slice(4)}`;
  return d.length > 2 ? `${d.slice(0, 2)}/${d.slice(2)}` : d;
};
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function AddressMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [matches, setMatches] = useState<ListRow[] | null>(null);
  const [combos, setCombos] = useState<Record<Combo, string[]>>({
    groups: [],
    countries: [],
    states: [],
    districts: [],
    cities: [],
    areas: [],
  });
  const [rights, setRights] = useState<Rights | null>(null);
  const [code, setCode] = useState('');
  const [codeLocked, setCodeLocked] = useState(true);
  const [values, setValues] = useState<Values>(blank);
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [tab, setTab] = useState<'company' | 'other' | 'family'>('company');
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [help, setHelp] = useState<number | null>(null);
  const [printRows, setPrintRows] = useState<Array<Record<string, string>> | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const boxes = useRef<Partial<Record<Key | 'code', HTMLInputElement | null>>>({});
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const helpRef = useRef<HTMLTableSectionElement>(null);
  const focusName = useRef(false);
  const focusCode = useRef(false);

  useEffect(() => {
    if (busy || !focusName.current) return;
    focusName.current = false;
    boxes.current.name?.focus();
  }, [busy, entryMode, code]);
  /**
   * Ctrl+E unlocks the code box and puts the cursor in it as one step (MS_ADD_MAST_KeyDown, :3721-3738). A layout effect
   * runs in the commit that makes the box editable; a timer left a gap in which a late tick took the cursor from the
   * name the operator had already started typing.
   */
  useLayoutEffect(() => {
    if (codeLocked || !focusCode.current) return;
    focusCode.current = false;
    boxes.current.code?.focus();
  }, [codeLocked]);
  useEffect(() => {
    if (help !== null) helpRef.current?.querySelectorAll<HTMLTableRowElement>('tr')[help]?.focus();
  }, [help]);

  /** CLEAR_DATA: blank boxes, the combos and the list read again, the next code, the cursor in the name. */
  const clear = useCallback(async () => {
    setBusy(true);
    try {
      const view = await get<{
        rows: ListRow[];
        combos: Record<Combo, string[]>;
        nextCode: string;
        rights: Rights;
      }>('/masters/address-master');
      setList(view.rows);
      setCombos(view.combos);
      setRights(view.rights);
      setCode(view.nextCode);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setValues(blank());
      setCodeLocked(true);
      setEntryMode('A');
      setVersion('');
      setMatches(null);
      setTab('company');
      setSearch(SEARCH_TEXT);
      setCurrent(0);
      focusName.current = true;
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void clear();
  }, [clear]);

  /** Text1_TextChanged: AC_NAME LIKE 'text%'; the name's key-up list replaces it while the name is typed. */
  const shown = useMemo(() => {
    if (matches) return matches;
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted ? list.filter((row) => row.name.toUpperCase().startsWith(wanted)) : list;
  }, [list, search, matches]);

  async function open(openCode: string) {
    if (!openCode) return;
    setBusy(true);
    setMsg(null);
    setHelp(null);
    try {
      const found = await get<Values & { code: string; version: string }>(
        `/masters/address-master/${encodeURIComponent(openCode)}`,
      );
      const next = blank();
      for (const key of Object.keys(next) as Key[]) next[key] = String(found[key] ?? '');
      setValues(next);
      setCode(found.code);
      setCodeLocked(true);
      setEntryMode('E');
      setVersion(found.version);
      setMatches(null);
      focusName.current = true;
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const set = (key: Key, value: string) => setValues((v) => ({ ...v, [key]: value }));

  /** tAcName_Validating: the name may not be another code's (the location's list). */
  function nameFree() {
    const wanted = values.name.trim();
    const other =
      wanted && list.find((row) => row.name.toUpperCase() === wanted && row.code !== code.trim());
    if (other) {
      setMsg({ kind: 'err', text: nameTaken(other.code) });
      setTimeout(() => {
        boxes.current.name?.focus();
        boxes.current.name?.select();
      }, 0);
      return false;
    }
    return true;
  }

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);

  async function save() {
    setMsg(null);
    if (!nameFree()) return;
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!code.trim() || !values.name.trim()) return setMsg({ kind: 'err', text: DETAIL_REQUIRED });
    setBusy(true);
    try {
      const payload = Object.fromEntries(
        Object.entries(values).map(([k, v]) => [k, String(v).trim()]),
      );
      if (entryMode === 'E')
        await put(`/masters/address-master/${encodeURIComponent(code.trim())}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/address-master', { code: code.trim(), ...payload });
      setMsg({ kind: 'ok', text: SAVED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (!nameFree()) return;
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!code.trim()) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/address-master/${encodeURIComponent(code.trim())}${opened}`);
      setMsg({ kind: 'ok', text: DELETED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function print() {
    setMsg(null);
    if (!nameFree()) return;
    if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: NO_PRINT_RIGHTS });
    try {
      setPrintRows(
        (await get<{ rows: Array<Record<string, string>> }>('/masters/address-master/print')).rows,
      );
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_PRINT_RIGHTS) });
    }
  }

  /** tAcName_KeyUp: the list shows up to 99 of the company's addresses whose name starts with the name typed. */
  const nameSearch = useRef(0);
  async function nameTyped(value: string) {
    const asked = ++nameSearch.current;
    try {
      const found = await get<ListRow[]>(
        `/masters/address-master/names?q=${encodeURIComponent(value)}`,
      );
      // An answer for older text (the operator kept typing) must not replace the current list.
      if (asked === nameSearch.current) setMatches(found);
    } catch {
      if (asked === nameSearch.current) setMatches(null);
    }
  }

  /** The tab order of the visible boxes, for Enter's SendKeys {tab}. */
  const order = useMemo(() => (tab === 'other' ? OTHER : COMPANY).map((f) => f.key), [tab]);
  function next(from: Key) {
    if (from === 'lBirthDate') return saveRef.current?.focus();
    const i = order.indexOf(from);
    const target = order[i + 1];
    if (target) boxes.current[target]?.focus();
    else saveRef.current?.focus();
  }

  async function onBoxKeyDown(event: KeyboardEvent<HTMLInputElement>, key: Key) {
    if (key === 'name' && event.key === 'F1') {
      event.preventDefault();
      setHelp(0);
      return;
    }
    if (event.key !== 'Enter') return;
    event.preventDefault();
    if (key === 'name' && !values.name.trim()) {
      setMsg({ kind: 'err', text: NAME_REQUIRED });
      return;
    }
    if (key === 'mobile' && entryMode === 'A' && values.mobile.trim()) {
      try {
        const { taken } = await get<{ taken: { name: string } | null }>(
          `/masters/address-master/mobile?no=${encodeURIComponent(values.mobile.trim())}`,
        );
        if (taken) return setMsg({ kind: 'err', text: mobileTaken(taken.name) });
      } catch (error) {
        return setMsg({ kind: 'err', text: messageOf(error) });
      }
    }
    next(key);
  }

  /** The help lists the location's addresses by name (ORDER BY AC_NAME, :3744). */
  const helpRows = useMemo(() => [...list].sort((a, b) => a.name.localeCompare(b.name)), [list]);
  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const toSearch = () => {
    setMatches(null);
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_ADD_MAST_KeyDown with KeyPreview: Ctrl+E unlocks the code box, Esc leaves the screen. */
  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented) return;
    if (event.ctrlKey && (event.key === 'e' || event.key === 'E')) {
      event.preventDefault();
      if (codeLocked) {
        focusCode.current = true;
        setCodeLocked(false);
      } else boxes.current.code?.focus();
    } else if (event.key === 'Escape') {
      event.preventDefault();
      if (help !== null) setHelp(null);
      else router.back();
    }
  }

  function onListKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    if (event.key === 'F1') {
      event.preventDefault();
      toSearch();
    } else if (event.key === 'Enter') {
      event.preventDefault();
      const row = shown[current];
      if (row) void open(row.code);
    } else if (event.key === 'Backspace') {
      event.preventDefault();
      setSearch((s) => (s === SEARCH_TEXT ? s : s.slice(0, -1)));
      setCurrent(0);
    } else if (event.key === 'ArrowDown' || event.key === 'ArrowUp') {
      event.preventDefault();
      const n = Math.max(
        0,
        Math.min(shown.length - 1, current + (event.key === 'ArrowDown' ? 1 : -1)),
      );
      setCurrent(n);
      listRows()[n]?.focus();
    }
  }

  function onHelpKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    if (help === null) return;
    if (event.key === 'ArrowDown' || event.key === 'ArrowUp') {
      event.preventDefault();
      setHelp(
        Math.max(0, Math.min(helpRows.length - 1, help + (event.key === 'ArrowDown' ? 1 : -1))),
      );
    } else if (event.key === 'Enter') {
      event.preventDefault();
      const row = helpRows[help];
      if (row) void open(row.code);
    } else if (event.key === 'Escape') {
      event.preventDefault();
      event.stopPropagation();
      setHelp(null);
      boxes.current.name?.focus();
    }
  }

  const field = (f: (typeof COMPANY)[number]) => (
    <input
      id={`address-${f.key}`}
      ref={(el) => {
        boxes.current[f.key] = el;
      }}
      aria-label={f.label}
      value={values[f.key]}
      maxLength={f.date ? 10 : f.max}
      placeholder={f.date ? 'DD/MM/YYYY' : undefined}
      list={f.combo ? `address-${f.combo}` : undefined}
      style={{ width: f.width }}
      onChange={(e) => {
        const value = f.date ? maskDate(e.target.value) : typed(e.target.value);
        set(f.key, value);
        if (f.key === 'name') void nameTyped(value);
      }}
      onBlur={f.key === 'name' ? nameFree : undefined}
      onKeyDown={(event) => void onBoxKeyDown(event, f.key)}
    />
  );
  const rowOf = (fields: typeof COMPANY) =>
    fields
      .filter((f) => !PAIRED.has(f.key))
      .map((f) => {
        const partner = PAIRS[f.key] ? fields.find((g) => g.key === PAIRS[f.key]) : undefined;
        return (
          <div
            key={f.key}
            className="row"
            style={{ alignItems: 'center', gap: 6, marginBottom: 5 }}
          >
            <label htmlFor={`address-${f.key}`} style={{ width: 96 }}>
              {f.label}
            </label>
            {field(f)}
            {partner && (
              <>
                <label htmlFor={`address-${partner.key}`} style={{ width: 80, marginLeft: 8 }}>
                  {partner.label}
                </label>
                {field(partner)}
              </>
            )}
          </div>
        );
      });

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Address Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      {(Object.keys(combos) as Combo[]).map((name) => (
        <datalist key={name} id={`address-${name}`}>
          {/* The states list keeps the desktop's UNION ALL, so a state can appear twice (:4004). */}
          {combos[name].filter(Boolean).map((v, i) => (
            <option key={`${v}-${i}`} value={v} />
          ))}
        </datalist>
      ))}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '440px minmax(590px, 1fr)',
          gridTemplateAreas: '"list fields" "list buttons"',
          gap: '10px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields', minWidth: 590 }}>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 8 }}>
            <label htmlFor="address-code" style={{ width: 96 }}>
              Ac Code
            </label>
            <input
              id="address-code"
              ref={(el) => {
                boxes.current.code = el;
              }}
              value={code}
              maxLength={8}
              readOnly={codeLocked}
              style={{ width: 90, background: codeLocked ? undefined : 'mistyrose' }}
              onChange={(e) => setCode(typed(e.target.value))}
              onKeyDown={(event) => {
                if (event.key === 'Enter') {
                  event.preventDefault();
                  boxes.current.name?.focus();
                }
              }}
            />
            <button type="button" className="ghost" tabIndex={-1} onClick={() => setHelp(0)}>
              F1
            </button>
          </div>
          {/* The selected tab is not a `primary` button: Save is the screen's main action. */}
          <div
            role="tablist"
            aria-label="Address details"
            className="row"
            style={{ gap: 4, marginBottom: 8 }}
          >
            {(
              [
                ['company', 'Company Detail'],
                ['other', 'Other Detail'],
                ['family', 'Family Detl'],
              ] as const
            ).map(([id, title]) => (
              <button
                key={id}
                type="button"
                role="tab"
                aria-selected={tab === id}
                className="ghost"
                style={
                  tab === id
                    ? { borderColor: 'var(--accent)', color: 'var(--accent)', fontWeight: 600 }
                    : undefined
                }
                tabIndex={-1}
                onClick={() => setTab(id)}
              >
                {title}
              </button>
            ))}
          </div>
          <div role="tabpanel" hidden={tab !== 'company'}>
            {rowOf(COMPANY.filter((f) => f.key !== 'lBirthDate'))}
            <div className="row" style={{ alignItems: 'center', gap: 6 }}>
              <label htmlFor="address-lBirthDate" style={{ width: 96 }}>
                L Birth Date
              </label>
              {field(COMPANY.find((f) => f.key === 'lBirthDate')!)}
            </div>
          </div>
          <div role="tabpanel" hidden={tab !== 'other'}>
            <div className="row" style={{ alignItems: 'center', gap: 6 }}>
              <label htmlFor="address-mobile2" style={{ width: 96 }}>
                Mobile No2
              </label>
              {field(OTHER[0]!)}
              <label htmlFor="address-phone2" style={{ width: 80, marginLeft: 8 }}>
                Phone No2
              </label>
              {field(OTHER[1]!)}
            </div>
          </div>
          <div role="tabpanel" hidden={tab !== 'family'} />
          {help !== null && (
            <section className="panel" aria-label="Address help" style={{ marginTop: 8 }}>
              <table className="grid">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th>Code</th>
                    <th>Group</th>
                    <th>Address</th>
                    <th>Phone</th>
                    <th>Mobile</th>
                  </tr>
                </thead>
                <tbody ref={helpRef} data-testid="address-help" onKeyDown={onHelpKeyDown}>
                  {helpRows.map((row, i) => (
                    <tr
                      key={row.code}
                      tabIndex={0}
                      data-code={row.code}
                      className={i === help ? 'selected' : undefined}
                      onFocus={() => setHelp(i)}
                      onDoubleClick={() => void open(row.code)}
                    >
                      <td>{row.name}</td>
                      <td>{row.code}</td>
                      <td>{row.group}</td>
                      <td>{row.address}</td>
                      <td>{row.phone}</td>
                      <td>{row.mobile}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </section>
          )}
        </div>
        <div className="row" style={{ gridArea: 'buttons', gap: 8, justifyContent: 'flex-end' }}>
          <button
            ref={saveRef}
            type="button"
            className="primary"
            data-save-mnemonic
            disabled={busy}
            onClick={() => void save()}
          >
            Save
          </button>
          <button
            type="button"
            className="ghost"
            disabled={busy}
            style={{ order: -1 }}
            onClick={() => void print()}
          >
            Print
          </button>
          <button
            type="button"
            className="ghost"
            disabled={busy}
            onClick={() => {
              setMsg(null);
              void clear();
            }}
          >
            Cancel
          </button>
          <button type="button" className="danger" disabled={busy} onClick={() => void remove()}>
            Delete
          </button>
          <button type="button" className="ghost" onClick={() => router.back()}>
            Exit
          </button>
        </div>
        <div className="panel" style={{ gridArea: 'list', width: 440 }}>
          <input
            ref={searchRef}
            aria-label="Search record"
            value={search}
            onFocus={() => {
              setMatches(null);
              setSearch((s) => (s === SEARCH_TEXT ? '' : s));
            }}
            onChange={(e) => {
              setSearch(typed(e.target.value));
              setCurrent(0);
            }}
            style={{ width: '100%' }}
          />
          <table className="grid" style={{ marginTop: 6 }}>
            <thead>
              <tr>
                <th style={{ width: 80 }}>Code</th>
                <th>Name</th>
              </tr>
            </thead>
            <tbody ref={listRef} data-testid="address-list" onKeyDown={onListKeyDown}>
              {shown.map((row, i) => (
                <tr
                  key={row.code}
                  tabIndex={0}
                  aria-selected={i === current}
                  data-code={row.code}
                  className={i === current ? 'selected' : undefined}
                  onFocus={() => setCurrent(i)}
                  onDoubleClick={() => void open(row.code)}
                >
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      {printRows && (
        <section className="panel" data-testid="address-print" aria-label="Address Master print">
          <div className="row" style={{ justifyContent: 'space-between' }}>
            <h2 style={{ margin: 0 }}>Address Master</h2>
            <div className="row" style={{ gap: 8 }}>
              <button type="button" className="ghost" onClick={() => window.print()}>
                Print now
              </button>
              <button type="button" className="ghost" onClick={() => setPrintRows(null)}>
                Close
              </button>
            </div>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>Code</th>
                <th>Name</th>
                <th>Address</th>
                <th>City</th>
                <th>Pin Code</th>
                <th>Mobile No</th>
                <th>Phone No</th>
              </tr>
            </thead>
            <tbody>
              {printRows.map((row) => (
                <tr key={row.code}>
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                  <td>{row.address}</td>
                  <td>{row.city}</td>
                  <td>{row.pin}</td>
                  <td>{row.mobile}</td>
                  <td>{row.phone}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </section>
      )}
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
