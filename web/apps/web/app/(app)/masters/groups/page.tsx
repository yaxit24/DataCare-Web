'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { round, vbVal } from '@datacare/core';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Item Group master (desktop MS_GROUP, Master → Group), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_GROUP.layout.json`): the SEARCH RECORD box and the Code / Name list on the
 * left; Gr Code, Gr Name, Item Type with the trade type, Gr Rate Touch with Purc Touch, Melting % with West %, Sales Ac
 * and Purchase Ac with their names, Hsn Code, Rate Tax % and Rate Display In Main Screen on the right; Print, Save,
 * Cancel, Delete and Exit along the bottom.
 *
 * - A new entry has blank boxes, Item Type Gold and the cursor in the code (CLEAR_DATA, MS_GROUP.cs:1713-1736). Enter on
 *   the list or a double click opens a group with the cursor in the name (DGV keys :2110-2139); the code box is
 *   read-only for an opened group (DISPLAY_DATA :1738-1808).
 * - Keys: typed letters are upper-cased and the apostrophe refused (:1975-1988). Enter on the code moves on and F1 goes
 *   to the search box (:1990-2004); Enter on a blank name says "Please Insert Group Name ..." (:2091-2108); Enter on the
 *   item type moves on (:2141-2149); Enter on the trade type takes a code found in BAL_GR, else opens its help
 *   (:2271-2304); Enter on the touches, melting and wastage shows Val of the box as 0.00 (:2151-2193); Enter on Sales Ac
 *   takes a group-25 code, else opens the help of group 25 without 00099 (:2195-2231); Enter on Purchase Ac does the same
 *   over group 30 (:2233-2269); Enter on Hsn Code and Rate Tax % moves on, Rate Tax % to Save (:2318-2336). Esc leaves
 *   the screen (:2073-2081). In the list F1 goes to the search box and Backspace shortens it.
 * - Leaving the code refuses a code another group has, and leaving the name a name another code has (:2006-2048).
 * - Save, Delete and Print answer with the desktop texts and rights (:1810-1954); Delete refuses a group an item uses
 *   before it asks (:1940-1944).
 *
 * - A code or name refused on leave also stops Save, Delete and Print, as the desktop's cancelled Validating suppresses
 *   the button's click; Cancel and Exit still work on the web.
 *
 * Deliberate differences: an opened group carries the version read with it. The search box drops SEARCH RECORD whenever
 * it gets the cursor. A pick from a help moves on at once, where the desktop waits for a second Enter, and a help pick
 * does not switch a new group to edit mode (the desktop sets EntryMode "E" after an account help, :2222 and :2260, so a
 * user without the edit right cannot save the new group). The account names cannot be typed in (Save never reads them).
 * Print shows the groups on the screen, because the GroupMast report layout is not in the repository.
 */
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Group now?';
const SELECT_FOR_DELETE = 'Please Select Group For Delete.';
const IN_ITEM_MASTER = 'You Cant Delete Record This Group Code Use in Item Master....';
const NAME_REQUIRED = 'Please Insert Group Name ...';
const ACCOUNTS_REQUIRED = 'Please Select Sales and Purchase Account And Try';
const DETAIL_REQUIRED = 'Enter Group Detail';
const SEARCH_TEXT = 'SEARCH RECORD';
const codeTaken = (name: string) =>
  `This Group Code already Exist in  '${name}'  Group Name... Please Change Group Code...`;
const nameTaken = (code: string) =>
  `This Group Name already Exist in  '${code}'  Group Code... Please Change Group Name...`;

/** The Item Type combo (MS_GROUP_Load :1642-1648); GR_TYPE stores the first letter. */
const ITEM_TYPES = [
  { letter: 'G', label: 'Gold' },
  { letter: 'S', label: 'Silver' },
  { letter: 'D', label: 'Diamond' },
  { letter: 'R', label: 'Real Stone' },
  { letter: 'E', label: 'Emitation' },
  { letter: 'O', label: 'Other' },
  { letter: 'P', label: 'Platinum' },
] as const;

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
}
interface Fields {
  code: string;
  name: string;
  itemType: string;
  tradeType: string;
  rateTouch: string;
  purcTouch: string;
  melting: string;
  west: string;
  saleAc: string;
  saleAcName: string;
  purcAc: string;
  purcAcName: string;
  hsn: string;
  taxPct: string;
  rateDisplay: boolean;
}
interface GroupView {
  code: string;
  name: string;
  itemType: string;
  tradeType: string;
  rateTouch: number;
  purcTouch: number;
  melting: number;
  west: number;
  taxPct: number;
  saleAc: string;
  saleAcName: string;
  purcAc: string;
  purcAcName: string;
  hsn: string;
  rateDisplay: boolean;
  items: number;
  version: string;
}
interface PrintRow {
  code: string;
  name: string;
  itemType: string;
  tradeType: string;
  rateTouch: number;
  purcTouch: number;
  melting: number;
  west: number;
  saleAc: string;
  purcAc: string;
  hsn: string;
  taxPct: number;
}

const blankFields: Fields = {
  code: '',
  name: '',
  itemType: 'G',
  tradeType: '',
  rateTouch: '',
  purcTouch: '',
  melting: '',
  west: '',
  saleAc: '',
  saleAcName: '',
  purcAc: '',
  purcAcName: '',
  hsn: '',
  taxPct: '',
  rateDisplay: false,
};
/** MS_GROUP_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
/** Strings.Format(Val(box), "0.00"). */
const fixed = (value: string | number) => round(vbVal(value), 2).toFixed(2);
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function GroupMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [rights, setRights] = useState<Rights | null>(null);
  const [fields, setFields] = useState<Fields>(blankFields);
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [items, setItems] = useState(0);
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [printRows, setPrintRows] = useState<PrintRow[] | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const codeRef = useRef<HTMLInputElement>(null);
  const nameRef = useRef<HTMLInputElement>(null);
  const typeRef = useRef<HTMLSelectElement>(null);
  const tradeBox = useRef<HTMLDivElement>(null);
  const rateTouchRef = useRef<HTMLInputElement>(null);
  const purcTouchRef = useRef<HTMLInputElement>(null);
  const meltingRef = useRef<HTMLInputElement>(null);
  const westRef = useRef<HTMLInputElement>(null);
  const saleBox = useRef<HTMLDivElement>(null);
  const purcBox = useRef<HTMLDivElement>(null);
  const hsnRef = useRef<HTMLInputElement>(null);
  const taxRef = useRef<HTMLInputElement>(null);
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const focusAfterLoad = useRef<'code' | 'name' | null>(null);

  useEffect(() => {
    if (busy || !focusAfterLoad.current) return;
    const which = focusAfterLoad.current;
    focusAfterLoad.current = null;
    (which === 'name' ? nameRef : codeRef).current?.focus();
  }, [busy, entryMode, fields.code]);

  /** CLEAR_DATA: blank boxes, Item Type Gold, the list read again, the cursor in the code. */
  const clear = useCallback(async () => {
    setBusy(true);
    try {
      const view = await get<{ rows: ListRow[]; rights: Rights }>('/masters/group-master');
      setList(view.rows);
      setRights(view.rights);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setFields(blankFields);
      setEntryMode('A');
      setVersion('');
      setItems(0);
      setSearch(SEARCH_TEXT);
      setCurrent(0);
      focusAfterLoad.current = 'code';
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void clear();
  }, [clear]);

  /** Text1_TextChanged: GR_NAME LIKE 'text%'; the SEARCH RECORD text lists every group. */
  const shown = useMemo(() => {
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted ? list.filter((row) => row.name.toUpperCase().startsWith(wanted)) : list;
  }, [list, search]);

  /** DISPLAY_DATA, then the cursor in the name (DGV_KeyDown and DGV_DoubleClick). */
  async function open(code: string) {
    if (!code) return;
    setBusy(true);
    setMsg(null);
    try {
      const found = await get<GroupView>(`/masters/group-master/${encodeURIComponent(code)}`);
      setFields((f) => ({
        code: found.code,
        name: found.name,
        // A GR_TYPE the combo does not know leaves the combo as it was (:1745-1772).
        itemType: ITEM_TYPES.some((t) => t.letter === found.itemType) ? found.itemType : f.itemType,
        tradeType: found.tradeType,
        rateTouch: fixed(found.rateTouch),
        purcTouch: fixed(found.purcTouch),
        melting: fixed(found.melting),
        west: fixed(found.west),
        saleAc: found.saleAc,
        saleAcName: found.saleAcName,
        purcAc: found.purcAc,
        purcAcName: found.purcAcName,
        hsn: found.hsn,
        taxPct: fixed(found.taxPct),
        rateDisplay: found.rateDisplay,
      }));
      setEntryMode('E');
      setVersion(found.version);
      setItems(found.items);
      focusAfterLoad.current = 'name';
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const set = <K extends keyof Fields>(key: K, value: Fields[K]) =>
    setFields((f) => ({ ...f, [key]: value }));

  /** tGrCode_Validating: a new entry may not take a code another group has. */
  function codeFree() {
    if (entryMode !== 'A') return true;
    const other = list.find((row) => row.code === fields.code.trim());
    if (other && other.name.toUpperCase() !== fields.name.trim()) {
      setMsg({ kind: 'err', text: codeTaken(other.name) });
      setTimeout(() => {
        codeRef.current?.focus();
        codeRef.current?.select();
      }, 0);
      return false;
    }
    return true;
  }
  /** tGrName_Validating: the name may not be another code's. */
  function nameFree() {
    const name = fields.name.trim();
    const other =
      name &&
      list.find((row) => row.name.toUpperCase() === name && row.code !== fields.code.trim());
    if (other) {
      setMsg({ kind: 'err', text: nameTaken(other.code) });
      setTimeout(() => {
        nameRef.current?.focus();
        nameRef.current?.select();
      }, 0);
      return false;
    }
    return true;
  }

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);
  const focusBox = (box: React.RefObject<HTMLDivElement | null>) =>
    box.current?.querySelector('input')?.focus();

  async function save() {
    setMsg(null);
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!fields.saleAc.trim() || !fields.purcAc.trim()) {
      setMsg({ kind: 'err', text: ACCOUNTS_REQUIRED });
      return focusBox(saleBox);
    }
    if (!fields.code.trim() || !fields.name.trim())
      return setMsg({ kind: 'err', text: DETAIL_REQUIRED });
    if (!codeFree() || !nameFree()) return;
    setBusy(true);
    try {
      const payload = {
        code: fields.code.trim(),
        name: fields.name.trim(),
        itemType: fields.itemType,
        tradeType: fields.tradeType.trim(),
        rateTouch: fields.rateTouch,
        purcTouch: fields.purcTouch,
        melting: fields.melting,
        west: fields.west,
        saleAc: fields.saleAc.trim(),
        purcAc: fields.purcAc.trim(),
        hsn: fields.hsn.trim(),
        taxPct: fields.taxPct,
        rateDisplay: fields.rateDisplay,
      };
      if (entryMode === 'E')
        await put(`/masters/group-master/${encodeURIComponent(payload.code)}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/group-master', payload);
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
    // A code or name refused on leave stops the button, as the desktop's cancelled Validating suppresses the click.
    if (!codeFree() || !nameFree()) return;
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    const code = fields.code.trim();
    if (!code) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    // The items of a typed (not opened) code are read as the desktop reads them before it asks (:1940-1944).
    let used = entryMode === 'E' ? items : 0;
    if (entryMode !== 'E') {
      try {
        used = (await get<GroupView>(`/masters/group-master/${encodeURIComponent(code)}`)).items;
      } catch {
        used = 0;
      }
    }
    if (used > 0) return setMsg({ kind: 'err', text: IN_ITEM_MASTER });
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/group-master/${encodeURIComponent(code)}${opened}`);
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
    if (!codeFree() || !nameFree()) return;
    if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: NO_PRINT_RIGHTS });
    try {
      const out = await get<{ rows: PrintRow[] }>('/masters/group-master/print');
      setPrintRows(out.rows);
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_PRINT_RIGHTS) });
    }
  }

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const toSearch = () => {
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_GROUP_KeyDown with KeyPreview: Esc leaves the screen. */
  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented || event.key !== 'Escape') return;
    if ((event.target as HTMLElement).closest?.('[data-lookup-open="true"]')) return;
    event.preventDefault();
    router.back();
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
      const next = Math.max(
        0,
        Math.min(shown.length - 1, current + (event.key === 'ArrowDown' ? 1 : -1)),
      );
      setCurrent(next);
      listRows()[next]?.focus();
    }
  }

  const onEnter = (next: () => void) => (event: KeyboardEvent<HTMLElement>) => {
    if (event.key !== 'Enter') return;
    event.preventDefault();
    next();
  };
  /** nGrTouch/nGrPrTouch/nMelting/nWest_KeyDown: Enter shows Val of the box as 0.00 and moves on. */
  const numberBox = (
    key: 'rateTouch' | 'purcTouch' | 'melting' | 'west',
    ref: React.RefObject<HTMLInputElement | null>,
    label: string,
    next: () => void,
  ) => (
    <input
      id={`group-${key}`}
      ref={ref}
      aria-label={label}
      value={fields[key]}
      maxLength={5}
      inputMode="decimal"
      style={{ width: 60, textAlign: 'right' }}
      onChange={(e) => set(key, e.target.value)}
      onKeyDown={onEnter(() => {
        set(key, fixed(fields[key]));
        next();
      })}
    />
  );
  const labelStyle = { width: 120, display: 'inline-block' } as const;

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Item Group Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      {/* The desktop's tab order is the boxes, the buttons, the search box, the list and then the Rate Display box
          (MS_GROUP form spec); the grid areas draw the list on the left as the form does. */}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '450px minmax(560px, 1fr)',
          gridTemplateAreas: '"list fields" "list check" "list buttons"',
          gap: '8px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields', minWidth: 560 }}>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label htmlFor="group-code" style={labelStyle}>
              Gr Code
            </label>
            <input
              id="group-code"
              ref={codeRef}
              value={fields.code}
              maxLength={3}
              readOnly={entryMode === 'E'}
              style={{ width: 65 }}
              onChange={(e) => set('code', typed(e.target.value))}
              onBlur={codeFree}
              onKeyDown={(event) => {
                if (event.key === 'F1') {
                  event.preventDefault();
                  toSearch();
                } else if (event.key === 'Enter') {
                  event.preventDefault();
                  if (fields.code.trim()) nameRef.current?.focus();
                }
              }}
            />
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label htmlFor="group-name" style={labelStyle}>
              Gr Name
            </label>
            <input
              id="group-name"
              ref={nameRef}
              value={fields.name}
              maxLength={40}
              style={{ width: 341 }}
              onChange={(e) => set('name', typed(e.target.value))}
              onBlur={nameFree}
              onKeyDown={onEnter(() => {
                if (!fields.name.trim()) {
                  setMsg({ kind: 'err', text: NAME_REQUIRED });
                  nameRef.current?.focus();
                } else typeRef.current?.focus();
              })}
            />
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label htmlFor="group-type" style={labelStyle}>
              Item Type
            </label>
            <select
              id="group-type"
              ref={typeRef}
              value={fields.itemType}
              style={{ width: 187 }}
              onChange={(e) => set('itemType', e.target.value)}
              onKeyDown={onEnter(() => focusBox(tradeBox))}
            >
              {ITEM_TYPES.map((t) => (
                <option key={t.letter} value={t.letter}>
                  {t.label}
                </option>
              ))}
            </select>
            <div ref={tradeBox} style={{ marginLeft: 6 }}>
              <LookupPicker
                entity="trade-types"
                searchPath="/masters/group-master/trade-types"
                ariaLabel="Trade Type"
                value={fields.tradeType}
                placeholder=""
                resolveTypedCode
                onChange={(code) => set('tradeType', typed(code))}
                onPick={(row) => set('tradeType', String(row.code))}
                style={{ width: 60 }}
              />
            </div>
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label htmlFor="group-rateTouch" style={labelStyle}>
              Gr Rate Touch
            </label>
            {numberBox('rateTouch', rateTouchRef, 'Gr Rate Touch', () =>
              purcTouchRef.current?.focus(),
            )}
            <label htmlFor="group-purcTouch" style={{ width: 98, marginLeft: 30 }}>
              Purc Touch
            </label>
            {numberBox('purcTouch', purcTouchRef, 'Purc Touch', () => meltingRef.current?.focus())}
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label htmlFor="group-melting" style={labelStyle}>
              Melting %
            </label>
            {numberBox('melting', meltingRef, 'Melting %', () => westRef.current?.focus())}
            <label htmlFor="group-west" style={{ width: 98, marginLeft: 30 }}>
              West %
            </label>
            {numberBox('west', westRef, 'West %', () => focusBox(saleBox))}
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label style={labelStyle}>Sales Ac</label>
            <div ref={saleBox} className="row" style={{ gap: 6, alignItems: 'center' }}>
              <LookupPicker
                entity="accounts"
                searchPath="/masters/group-master/accounts?kind=sale"
                ariaLabel="Sales Ac"
                value={fields.saleAc}
                placeholder=""
                resolveTypedCode
                onChange={(code) =>
                  setFields((f) => ({
                    ...f,
                    saleAc: typed(code),
                    saleAcName: typed(code) === f.saleAc ? f.saleAcName : '',
                  }))
                }
                onPick={(row) =>
                  setFields((f) => ({
                    ...f,
                    saleAc: String(row.code),
                    saleAcName: String(row.name ?? ''),
                  }))
                }
                style={{ width: 80 }}
              />
              <input
                aria-label="Sales Account Name"
                value={fields.saleAcName}
                readOnly
                tabIndex={-1}
                style={{ width: 279 }}
              />
            </div>
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label style={labelStyle}>Purchase Ac</label>
            <div ref={purcBox} className="row" style={{ gap: 6, alignItems: 'center' }}>
              <LookupPicker
                entity="accounts"
                searchPath="/masters/group-master/accounts?kind=purchase"
                ariaLabel="Purchase Ac"
                value={fields.purcAc}
                placeholder=""
                resolveTypedCode
                onChange={(code) =>
                  setFields((f) => ({
                    ...f,
                    purcAc: typed(code),
                    purcAcName: typed(code) === f.purcAc ? f.purcAcName : '',
                  }))
                }
                onPick={(row) =>
                  setFields((f) => ({
                    ...f,
                    purcAc: String(row.code),
                    purcAcName: String(row.name ?? ''),
                  }))
                }
                style={{ width: 80 }}
              />
              <input
                aria-label="Purchase Account Name"
                value={fields.purcAcName}
                readOnly
                tabIndex={-1}
                style={{ width: 279 }}
              />
            </div>
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
            <label htmlFor="group-hsn" style={labelStyle}>
              Hsn Code
            </label>
            <input
              id="group-hsn"
              ref={hsnRef}
              value={fields.hsn}
              maxLength={10}
              style={{ width: 156 }}
              onChange={(e) => set('hsn', typed(e.target.value))}
              onKeyDown={onEnter(() => taxRef.current?.focus())}
            />
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6 }}>
            <label htmlFor="group-tax" style={labelStyle}>
              Rate Tax %
            </label>
            <input
              id="group-tax"
              ref={taxRef}
              value={fields.taxPct}
              maxLength={5}
              inputMode="decimal"
              style={{ width: 60, textAlign: 'right' }}
              onChange={(e) => set('taxPct', e.target.value)}
              // nTaxPrc_KeyDown: Enter moves on without formatting; the next stop is Save (tab index 12).
              onKeyDown={onEnter(() => saveRef.current?.focus())}
            />
          </div>
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
        <div className="panel" style={{ gridArea: 'list', width: 450 }}>
          <input
            ref={searchRef}
            aria-label="Search record"
            value={search}
            onFocus={() => setSearch((s) => (s === SEARCH_TEXT ? '' : s))}
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
            <tbody ref={listRef} data-testid="group-list" onKeyDown={onListKeyDown}>
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
        <label
          className="row"
          style={{ gridArea: 'check', gap: 6, alignItems: 'center', paddingLeft: 138 }}
        >
          <input
            type="checkbox"
            checked={fields.rateDisplay}
            onChange={(e) => set('rateDisplay', e.target.checked)}
          />
          Rate Display In Main Screen
        </label>
      </div>
      {printRows && (
        <section className="panel" data-testid="group-print" aria-label="Item Group Master print">
          <div className="row" style={{ justifyContent: 'space-between' }}>
            <h2 style={{ margin: 0 }}>Item Group Master</h2>
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
                <th>Type</th>
                <th>Trade</th>
                <th className="num">Rate Touch</th>
                <th className="num">Purc Touch</th>
                <th className="num">Melting %</th>
                <th className="num">West %</th>
                <th>Sales Ac</th>
                <th>Purchase Ac</th>
                <th>Hsn Code</th>
                <th className="num">Tax %</th>
              </tr>
            </thead>
            <tbody>
              {printRows.map((row) => (
                <tr key={row.code}>
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                  <td>
                    {ITEM_TYPES.find((t) => t.letter === row.itemType)?.label ?? row.itemType}
                  </td>
                  <td>{row.tradeType}</td>
                  <td className="num">{fixed(row.rateTouch)}</td>
                  <td className="num">{fixed(row.purcTouch)}</td>
                  <td className="num">{fixed(row.melting)}</td>
                  <td className="num">{fixed(row.west)}</td>
                  <td>{row.saleAc}</td>
                  <td>{row.purcAc}</td>
                  <td>{row.hsn}</td>
                  <td className="num">{fixed(row.taxPct)}</td>
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
