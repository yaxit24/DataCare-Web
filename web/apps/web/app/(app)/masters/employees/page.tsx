'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { round, vbVal } from '@datacare/core';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Employee master (desktop MS_EMP, Master → Employee), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_EMP.layout.json`): the SEARCH RECORD box and the Code / Name list on the
 * left, and on the right Employee Code, Employee Name, Account Code with the account name, User Name, Amount and Day
 * Hour, in that tab order; Print, Save, Cancel, Delete and Exit along the bottom, Save first in the tab order.
 *
 * - A new entry gets the next code and the cursor in the name (CLEAR_DATA, MS_EMP.cs:1241-1273). Enter or a double
 *   click on the list opens an employee with its code read-only (DGV_KeyDown :1600-1622, DISPLAY_DATA :1274-1299).
 * - Enter on the code moves on when it is not blank and F1 goes to the search box (:1334-1348); Enter on a blank name
 *   says "Please Insert Employee Name ..." (:1372-1389); Enter on the account takes a code found in the account master
 *   or opens the help (:1631-1680); Enter on Amount and Day Hour shows Val of the box as 0.00 and moves on (:1681-1724).
 *   Up and Down go to the list and Esc leaves (MS_EMP_KeyDown :1436-1446); in the list F1 goes to the search box and
 *   Backspace shortens it (:1600-1622). Typed text is upper-cased and the apostrophe is refused (:1319-1332).
 * - Leaving the code refuses a code another employee has, and leaving the name a name another code has (:1350-1411).
 * - The User Name box lists the login names (AddCboItem :1152-1177). It is a drop-down list, so an opened employee
 *   whose user is not listed (the 'ABC' stored for a blank user) shows a blank user.
 * - Save, Delete and Print answer with the desktop texts and rights (:1462-1599).
 *
 * Deliberate differences:
 * - Up and Down keep working in the User Name list and in an open account help instead of jumping to the employee list.
 * - The account box shows the letters as typed until a code is taken; the desktop upper-cases every key.
 * - The search box drops its SEARCH RECORD text whenever it gets the cursor, and Backspace in the list leaves that text
 *   alone. The desktop clears it only on a click (:1454-1460), so typing after F1 searched for "SEARCH RECORD…" and
 *   Backspace in the list searched for "SEARCH RECOR", both showing no employees.
 * - An opened employee carries the version read with it: when another operator changed or deleted it meanwhile, Save
 *   and Delete are refused and it must be opened again. The desktop's later save wins.
 * - Print shows the company's employees on the screen with a print button, because the EmpMast report layout is not in
 *   the repository.
 * - The account help cannot create an account (the desktop opens the Party master from the help, :1659-1665).
 */
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Record now?';
const SELECT_FOR_DELETE = 'Please Select Employee For Delete.';
const NAME_REQUIRED = 'Please Insert Employee Name ...';
const DETAIL_REQUIRED = 'Enter Employee Detail';
const SEARCH_TEXT = 'SEARCH RECORD';
const codeTaken = (name: string) =>
  `This Employee Code already Exist in  '${name}'  Employee Name...Please Change Employee Code...`;
const nameTaken = (code: string) =>
  `This Employee Name already Exist in  '${code}'  Employee Code...Please Change Employee Name...`;

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
}
interface Entry {
  code: string;
  name: string;
  account: string;
  accountName: string;
  user: string;
  amount: string;
  dayHours: string;
}
interface PrintRow {
  code: string;
  name: string;
  user: string;
  account: string;
  amount: number;
  dayHours: number;
}

const blankEntry = (code: string): Entry => ({
  code,
  name: '',
  account: '',
  accountName: '',
  user: '',
  amount: '',
  dayHours: '',
});
/** MS_EMP_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
/** Strings.Format(Val(box), "0.00"). */
const twoPlaces = (value: string | number) => round(vbVal(value), 2).toFixed(2);
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function EmployeeMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [rows, setRows] = useState<ListRow[]>([]);
  const [users, setUsers] = useState<string[]>(['']);
  const [rights, setRights] = useState<Rights | null>(null);
  const [entry, setEntry] = useState<Entry>(blankEntry(''));
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [printRows, setPrintRows] = useState<PrintRow[] | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const codeRef = useRef<HTMLInputElement>(null);
  const nameRef = useRef<HTMLInputElement>(null);
  const accountBox = useRef<HTMLDivElement>(null);
  const userRef = useRef<HTMLSelectElement>(null);
  const amountRef = useRef<HTMLInputElement>(null);
  const hoursRef = useRef<HTMLInputElement>(null);
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);

  /** CLEAR_DATA: blank boxes, the next code, the list read again (by name, or by code after a delete). */
  const clear = useCallback(async (order: 'name' | 'code' = 'name') => {
    setBusy(true);
    try {
      const view = await get<{
        rows: ListRow[];
        nextCode: string;
        users: string[];
        rights: Rights;
      }>(`/masters/employee-master${order === 'code' ? '?order=code' : ''}`);
      setRows(view.rows);
      setUsers(view.users.length ? view.users : ['']);
      setRights(view.rights);
      setEntry(blankEntry(view.nextCode));
      setEntryMode('A');
      setVersion('');
      setSearch(SEARCH_TEXT);
      setCurrent(0);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setBusy(false);
      setTimeout(() => nameRef.current?.focus(), 0);
    }
  }, []);
  useEffect(() => {
    void clear('name');
  }, [clear]);

  /** Text1_TextChanged: EMP_NAME LIKE 'text%'; the SEARCH RECORD text lists everyone. */
  const shown = useMemo(() => {
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted ? rows.filter((row) => row.name.toUpperCase().startsWith(wanted)) : rows;
  }, [rows, search]);

  async function open(code: string) {
    if (!code) return;
    setBusy(true);
    setMsg(null);
    try {
      const found = await get<{
        code: string;
        name: string;
        user: string;
        account: string;
        accountName: string;
        amount: number;
        dayHours: number;
        version: string;
      }>(`/masters/employee-master/${encodeURIComponent(code)}`);
      setEntry({
        code: found.code,
        name: found.name,
        account: found.account,
        accountName: found.accountName,
        user: users.includes(found.user) ? found.user : '',
        amount: twoPlaces(found.amount),
        dayHours: twoPlaces(found.dayHours),
      });
      setEntryMode('E');
      setVersion(found.version);
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
      setTimeout(() => nameRef.current?.focus(), 0);
    }
  }

  const set = (key: keyof Entry, value: string) => setEntry((e) => ({ ...e, [key]: value }));

  /** tEmpCode_Validating: a new entry may not take a code another employee has. */
  function codeFree() {
    if (entryMode !== 'A') return true;
    const other = rows.find((row) => row.code === entry.code.trim());
    if (other && other.name !== entry.name.trim()) {
      setMsg({ kind: 'err', text: codeTaken(other.name) });
      setTimeout(() => {
        codeRef.current?.focus();
        codeRef.current?.select();
      }, 0);
      return false;
    }
    return true;
  }
  /** tEmpName_Validating: the name may not be another code's. */
  function nameFree() {
    const name = entry.name.trim();
    const other = name && rows.find((row) => row.name === name && row.code !== entry.code.trim());
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

  async function save() {
    setMsg(null);
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!entry.code.trim() && !entry.name.trim()) {
      setMsg({ kind: 'err', text: DETAIL_REQUIRED });
      return nameRef.current?.focus();
    }
    if (!codeFree() || !nameFree()) return;
    setBusy(true);
    try {
      const payload = {
        code: entry.code.trim(),
        name: entry.name.trim(),
        account: entry.account.trim(),
        user: entry.user,
        amount: entry.amount,
        dayHours: entry.dayHours,
      };
      if (entryMode === 'E')
        await put(`/masters/employee-master/${encodeURIComponent(payload.code)}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/employee-master', payload);
      setMsg({ kind: 'ok', text: SAVED });
      await clear('name');
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!entry.code.trim()) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/employee-master/${encodeURIComponent(entry.code.trim())}${opened}`);
      setMsg({ kind: 'ok', text: DELETED });
      await clear('code');
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function print() {
    setMsg(null);
    if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: NO_PRINT_RIGHTS });
    try {
      const out = await get<{ rows: PrintRow[] }>('/masters/employee-master/print');
      setPrintRows(out.rows);
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_PRINT_RIGHTS) });
    }
  }

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const focusList = (index = current) => {
    const all = listRows();
    all[Math.max(0, Math.min(index, all.length - 1))]?.focus();
  };
  const toSearch = () => {
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_EMP_KeyDown with KeyPreview: Esc leaves, Up and Down go to the list. */
  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented) return;
    const target = event.target as HTMLElement;
    if (target.closest?.('[data-lookup-open="true"]')) return;
    if (event.key === 'Escape') {
      event.preventDefault();
      router.back();
    } else if (
      (event.key === 'ArrowUp' || event.key === 'ArrowDown') &&
      !target.closest?.('select,[data-testid="employee-list"],[data-testid="employee-print"]')
    ) {
      event.preventDefault();
      focusList();
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
      const next = Math.max(
        0,
        Math.min(shown.length - 1, current + (event.key === 'ArrowDown' ? 1 : -1)),
      );
      setCurrent(next);
      focusList(next);
    }
  }

  const onEnter =
    (next: () => void) => (event: KeyboardEvent<HTMLInputElement | HTMLSelectElement>) => {
      if (event.key !== 'Enter') return;
      event.preventDefault();
      next();
    };

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Employee Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      {/* The desktop's tab order is the boxes, the buttons, the search box, then the list (MS_EMP form spec); the grid
          areas draw the list on the left as the form does. */}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '450px minmax(480px, 1fr)',
          gridTemplateAreas: '"list fields" "list buttons"',
          gap: '12px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields', minWidth: 480 }}>
          <div className="field">
            <label htmlFor="employee-code">Employee Code</label>
            <input
              id="employee-code"
              ref={codeRef}
              value={entry.code}
              maxLength={3}
              readOnly={entryMode === 'E'}
              style={{ width: 84 }}
              onChange={(e) => set('code', typed(e.target.value))}
              onBlur={codeFree}
              onKeyDown={(event) => {
                if (event.key === 'F1') {
                  event.preventDefault();
                  toSearch();
                } else if (event.key === 'Enter') {
                  event.preventDefault();
                  if (entry.code.trim()) nameRef.current?.focus();
                }
              }}
            />
          </div>
          <div className="field">
            <label htmlFor="employee-name">Employee Name</label>
            <input
              id="employee-name"
              ref={nameRef}
              value={entry.name}
              maxLength={40}
              style={{ width: 352 }}
              onChange={(e) => set('name', typed(e.target.value))}
              onBlur={nameFree}
              onKeyDown={onEnter(() => {
                if (!entry.name.trim()) {
                  setMsg({ kind: 'err', text: NAME_REQUIRED });
                  nameRef.current?.focus();
                } else {
                  accountBox.current?.querySelector('input')?.focus();
                }
              })}
            />
          </div>
          <div className="field">
            <label>Account Code</label>
            <div ref={accountBox} className="row" style={{ gap: 6, alignItems: 'center' }}>
              <LookupPicker
                entity="accounts"
                searchPath="/masters/employee-master/accounts"
                ariaLabel="Account Code"
                value={entry.account}
                resolveTypedCode
                // The box keeps the text as typed: the picker keeps a help list only for the exact text it was asked for
                // (G185), so upper-casing here dropped every answer to a lower-case search. A pick or an exactly typed
                // code (matched case-insensitively) puts the master's code in the box, and Save upper-cases the rest.
                onChange={(code) =>
                  setEntry((e) => ({
                    ...e,
                    account: code,
                    accountName: code === e.account ? e.accountName : '',
                  }))
                }
                onPick={(row) =>
                  setEntry((e) => ({
                    ...e,
                    account: String(row.code),
                    accountName: String(row.name ?? ''),
                  }))
                }
                style={{ width: 84 }}
              />
              <input
                aria-label="Account Name"
                data-testid="employee-account-name"
                value={entry.accountName}
                readOnly
                tabIndex={-1}
                style={{ width: 263 }}
              />
            </div>
          </div>
          <div className="field">
            <label htmlFor="employee-user">User Name</label>
            <select
              id="employee-user"
              ref={userRef}
              value={entry.user}
              style={{ width: 157 }}
              onChange={(e) => set('user', e.target.value)}
              onKeyDown={onEnter(() => amountRef.current?.focus())}
            >
              {users.map((user) => (
                <option key={user || '(blank)'} value={user}>
                  {user}
                </option>
              ))}
            </select>
          </div>
          <div className="field">
            <label htmlFor="employee-amount">Amount</label>
            <input
              id="employee-amount"
              ref={amountRef}
              value={entry.amount}
              inputMode="decimal"
              style={{ width: 84, textAlign: 'right' }}
              onChange={(e) => set('amount', e.target.value)}
              onKeyDown={onEnter(() => {
                set('amount', twoPlaces(entry.amount));
                hoursRef.current?.focus();
              })}
            />
          </div>
          <div className="field">
            <label htmlFor="employee-day-hours">Day Hour</label>
            <input
              id="employee-day-hours"
              ref={hoursRef}
              value={entry.dayHours}
              inputMode="decimal"
              style={{ width: 84, textAlign: 'right' }}
              onChange={(e) => set('dayHours', e.target.value)}
              onKeyDown={onEnter(() => {
                set('dayHours', twoPlaces(entry.dayHours));
                saveRef.current?.focus();
              })}
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
            onClick={() => void clear('name')}
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
            <tbody ref={listRef} data-testid="employee-list" onKeyDown={onListKeyDown}>
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
        <section className="panel" data-testid="employee-print" aria-label="Employee Master print">
          <div className="row" style={{ justifyContent: 'space-between' }}>
            <h2 style={{ margin: 0 }}>Employee Master</h2>
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
                <th>User Name</th>
                <th>Account Code</th>
                <th className="num">Amount</th>
                <th className="num">Day Hour</th>
              </tr>
            </thead>
            <tbody>
              {printRows.map((row) => (
                <tr key={row.code}>
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                  <td>{row.user}</td>
                  <td>{row.account}</td>
                  <td className="num">{twoPlaces(row.amount)}</td>
                  <td className="num">{twoPlaces(row.dayHours)}</td>
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
