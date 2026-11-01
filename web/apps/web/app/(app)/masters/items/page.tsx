'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { round, vbVal } from '@datacare/core';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Item master (desktop MS_ITEM, Master → Item), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_ITEM.layout.json`): the SEARCH RECORD box and the Code / Name / Safe list on
 * the left; Pr Code, Gr Code with the trade type, Item Code with the item and tag types, Item Name, Safe Name with Stk
 * Display, Hsn Code, Unit Name, Rate Per, Labour Rate, Labour % with Ght %, Conversion %, Discount %, Item Rate, Oth itm
 * Rate with its type and Bag Weight on the right; Print, Save, Cancel, Delete and Exit along the bottom.
 *
 * - A new entry has blank boxes, Safe MAIN, Gram Wise, Yes, Weight and the cursor in the product (CLEAR_DATA,
 *   MS_ITEM.cs:2845-2877). A double click on the list (or Enter) opens an item with the cursor in the name (:3366-3395).
 * - Keys: typed letters are upper-cased and the apostrophe refused (:3066-3079). The product and group boxes take a code
 *   from their helps (:3081-3116, :3397-3450); a chosen group fills the types and, on a new entry, the item code (product
 *   + group) and name (product name + " " + group code), and asks "This Item already Exist in ..." when that code exists
 *   (:3452-3495). Enter moves box to box in the desktop order; Enter on the number boxes shows Val as 0.00 (bag weight
 *   0.0000) and on Bag Weight goes to Save (:3559-3754). Esc leaves (:3141-3155). In the list F1 goes to the search box.
 * - Leaving the item code refuses a code another item has under another name, and leaving the name a name another code
 *   has (:3497-3629); a refusal also stops Save and Delete, as the desktop's cancelled Validating suppresses the click.
 * - Save, Delete and Print answer with the desktop texts and rights (:3165-3355, :3697-3705). A double click on the
 *   button bar opens the Item Wise Tag Value Update panel (PnlBotam_DoubleClick :3922-3934, :3936-4015).
 *
 * Deliberate differences: an opened item's code is read-only (the desktop leaves it open, and a changed code saves a
 * copy under the new code while the old item stays); Enter on the list opens the item as the double click does (the
 * desktop's Enter puts the item code into the product box and reads the blank item code, which clears the entry); a pick
 * from a help moves on at once; a new entry unlocks the product box again (the desktop keeps it read-only after the first
 * opened item); an opened item carries the version read with it; the boxes the desktop draws late in its tab order (Item
 * and Trade Type, Stk Display, the setting check boxes) follow Bag Weight in the web's tab order.
 */
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Record now?';
const SELECT_FOR_DELETE = 'Please Select Item For Delete.';
const IN_TRANSACTION = "You Can't Delete Record This Item Use in Transaction....";
const DEFAULT_CODE = 'You Cant Delete Record This Item Code Is Default Code....';
const PRODUCT_REQUIRED = 'Product Code Is Null Please Create Item Again..';
const GROUP_REQUIRED = 'Group Code Is Null Please Create Item Again..';
const CODE_REQUIRED = 'Item Code Is Null Please Create Item Again..';
const NAME_REQUIRED = 'Please Insert Item Name';
const TAG_CONFIRM = 'Are You Sure To Update This Item Tag With New Value... ?';
const TAG_DONE = 'Item Tag Value Is Update.....';
const SEARCH_TEXT = 'SEARCH RECORD';
const codeTaken = (name: string) =>
  `This Item Code already Exist in  '${name}'  Item Name...Please Change It Code...`;
const nameTaken = (code: string) =>
  `This Item Code already Exist in  '${code}'  Item Name...Please Change It Name...`;
const existsQuestion = (name: string) =>
  `This Item already Exist in  '${name}' Item Name...You Want to Creat New Item...`;
const DEFAULT_ITEMS = new Set([
  'SN',
  'RD',
  'OS',
  'OG',
  'OE',
  'HM',
  'FSL',
  'DM',
  '24CT',
  '999',
  'ORG',
  'ORS',
  'ORD',
  'OO',
]);

const RATE_TYPES = [
  ['G', 'Gram Wise'],
  ['1', '10Gm Wise'],
  ['K', 'Kg Wise'],
  ['P', 'Pcs Wise'],
] as const;
const OTHER_RATE_TYPES = [
  ['W', 'Weight'],
  ['P', 'Pcs'],
  ['F', 'Fix'],
] as const;
type NumberKey =
  'lbrRate' | 'lbrPrc' | 'ghtPrc' | 'conPrc' | 'discPrc' | 'itemRate' | 'othRate' | 'bagWt';
/** The number boxes with their caption, MaxLength, width and Strings.Format places (:3559-3754). */
const NUMBERS: Record<NumberKey, { label: string; max: number; width: number; places: number }> = {
  lbrRate: { label: 'Labour Rate', max: 6, width: 90, places: 2 },
  lbrPrc: { label: 'Labour %', max: 6, width: 90, places: 2 },
  ghtPrc: { label: 'Ght %', max: 6, width: 75, places: 2 },
  conPrc: { label: 'Conversion %', max: 6, width: 90, places: 2 },
  discPrc: { label: 'Discount %', max: 6, width: 90, places: 2 },
  itemRate: { label: 'Item Rate', max: 10, width: 90, places: 2 },
  othRate: { label: 'Oth itm Rate', max: 10, width: 90, places: 2 },
  bagWt: { label: 'Bag Weight', max: 10, width: 90, places: 4 },
};

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
  safe: string;
}
interface Fields extends Record<NumberKey, string> {
  productCode: string;
  productName: string;
  groupCode: string;
  groupName: string;
  code: string;
  name: string;
  itType: string;
  tagType: string;
  tradeType: string;
  safe: string;
  hsn: string;
  unit: string;
  rateType: string;
  stockDisplay: string;
  othRateType: string;
  othItmWtRemove: boolean;
  lotStock: boolean;
}
const blankFields = (): Fields => ({
  productCode: '',
  productName: '',
  groupCode: '',
  groupName: '',
  code: '',
  name: '',
  itType: '',
  tagType: '',
  tradeType: '',
  safe: 'MAIN',
  hsn: '',
  unit: '',
  rateType: 'G',
  stockDisplay: 'Y',
  othRateType: 'W',
  othItmWtRemove: false,
  lotStock: false,
  lbrRate: '',
  lbrPrc: '',
  ghtPrc: '',
  conPrc: '',
  discPrc: '',
  itemRate: '',
  othRate: '',
  bagWt: '',
});
/** MS_ITEM_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
const fixed = (value: string | number, places: number) =>
  round(vbVal(value), places).toFixed(places);
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function ItemMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [combos, setCombos] = useState<{ units: string[]; safes: string[] }>({
    units: [],
    safes: [],
  });
  const [settings, setSettings] = useState({ othItmWtRemove: false, lotStock: false });
  const [rights, setRights] = useState<Rights | null>(null);
  const [fields, setFields] = useState<Fields>(blankFields);
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [inStock, setInStock] = useState(false);
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [tagPanel, setTagPanel] = useState(false);
  const [tagBoxes, setTagBoxes] = useState({ lbrPrc: '', krTouch: '', krWestPrc: '' });
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const box = useRef<Partial<Record<string, HTMLElement | null>>>({});
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const focusAfterLoad = useRef<'product' | 'name' | null>(null);

  const focus = (key: string) => {
    const el = box.current[key];
    const input = el instanceof HTMLDivElement ? el.querySelector('input') : el;
    (input as HTMLElement | null)?.focus();
  };
  useEffect(() => {
    if (busy || !focusAfterLoad.current) return;
    const which = focusAfterLoad.current;
    focusAfterLoad.current = null;
    focus(which === 'name' ? 'name' : 'productCode');
  }, [busy, entryMode, fields.code]);

  /** CLEAR_DATA: blank boxes, the combos and the list read again, the cursor in the product. */
  const clear = useCallback(async () => {
    setBusy(true);
    try {
      const view = await get<{
        rows: ListRow[];
        combos: { units: string[]; safes: string[] };
        settings: { othItmWtRemove: boolean; lotStock: boolean };
        rights: Rights;
      }>('/masters/item-master');
      setList(view.rows);
      setCombos(view.combos);
      setSettings(view.settings);
      setRights(view.rights);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setFields(blankFields());
      setEntryMode('A');
      setVersion('');
      setInStock(false);
      setSearch(SEARCH_TEXT);
      setCurrent(0);
      focusAfterLoad.current = 'product';
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void clear();
  }, [clear]);

  /** Text1_TextChanged: IT_NAME or IT_CODE LIKE 'text%' (:3118-3139). */
  const shown = useMemo(() => {
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted
      ? list.filter(
          (row) =>
            row.name.toUpperCase().startsWith(wanted) || row.code.toUpperCase().startsWith(wanted),
        )
      : list;
  }, [list, search]);

  async function open(code: string) {
    if (!code) return;
    setBusy(true);
    setMsg(null);
    try {
      const found = await get<
        Fields & { code: string; version: string; inStock: boolean } & Record<NumberKey, number>
      >(`/masters/item-master/${encodeURIComponent(code)}`);
      const next = blankFields();
      for (const key of Object.keys(next) as Array<keyof Fields>) {
        const value = (found as any)[key];
        if (key in NUMBERS)
          (next as any)[key] = fixed(value ?? 0, NUMBERS[key as NumberKey].places);
        else if (typeof next[key] === 'boolean') (next as any)[key] = Boolean(value);
        else (next as any)[key] = String(value ?? '');
      }
      setFields(next);
      setEntryMode('E');
      setVersion(found.version);
      setInStock(found.inStock);
      focusAfterLoad.current = 'name';
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const set = <K extends keyof Fields>(key: K, value: Fields[K]) =>
    setFields((f) => ({ ...f, [key]: value }));

  /** tItCode_Validating: a new entry may not take a code another item has under another name. */
  function codeFree() {
    if (entryMode !== 'A') return true;
    const other = list.find((row) => row.code === fields.code.trim());
    if (other && other.name.toUpperCase() !== fields.name.trim()) {
      setMsg({ kind: 'err', text: codeTaken(other.name) });
      setTimeout(() => focus('code'), 0);
      return false;
    }
    return true;
  }
  /** tItName_Validating: the name may not be another code's. */
  function nameFree() {
    const wanted = fields.name.trim();
    const other =
      wanted &&
      list.find((row) => row.name.toUpperCase() === wanted && row.code !== fields.code.trim());
    if (other) {
      setMsg({ kind: 'err', text: nameTaken(other.code) });
      setTimeout(() => focus('name'), 0);
      return false;
    }
    return true;
  }

  /** tGrCode_KeyDown and tGrCode_Validating after a group is chosen on a new entry. */
  function groupChosen(group: { code: string; name: string; type?: unknown; trade?: unknown }) {
    const type = String(group.type ?? '');
    const next = {
      ...fields,
      groupCode: group.code,
      groupName: group.name,
      itType: type,
      tagType: type,
      tradeType: String(group.trade ?? ''),
    };
    if (entryMode !== 'A') return setFields(next);
    const code = `${fields.productCode}${group.code}`;
    const existing = list.find((r) => r.code === code);
    if (!existing) return setFields({ ...next, code, name: `${fields.productName} ${group.code}` });
    // MsgBoxStyle 260: Yes / No with No as the default; Yes clears the code and name for a new code.
    if (window.confirm(existsQuestion(existing.name))) {
      setFields({ ...next, code: '', name: '' });
      setTimeout(() => focus('code'), 0);
    } else {
      setFields({ ...next, groupCode: '', groupName: '', code: '', name: '' });
      setTimeout(() => focus('groupCode'), 0);
    }
  }

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);

  async function save() {
    setMsg(null);
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!codeFree() || !nameFree()) return;
    if (!fields.productCode.trim()) {
      setMsg({ kind: 'err', text: PRODUCT_REQUIRED });
      return focus('productCode');
    }
    if (!fields.groupCode.trim()) {
      setMsg({ kind: 'err', text: GROUP_REQUIRED });
      return focus('groupCode');
    }
    if (!fields.code.trim()) {
      // BtnSave_Click puts the cursor in the group here (:3223).
      setMsg({ kind: 'err', text: CODE_REQUIRED });
      return focus('groupCode');
    }
    if (!fields.name.trim()) {
      setMsg({ kind: 'err', text: NAME_REQUIRED });
      return focus('name');
    }
    setBusy(true);
    try {
      const { productName, groupName, ...payload } = fields;
      void productName;
      void groupName;
      if (entryMode === 'E')
        await put(`/masters/item-master/${encodeURIComponent(fields.code.trim())}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/item-master', payload);
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
    if (!codeFree() || !nameFree()) return;
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    const code = fields.code.trim();
    // BtnDelete_Click reads the stock rows and the default codes before the blank code and the question (:3311-3346).
    let used = entryMode === 'E' ? inStock : false;
    if (entryMode !== 'E' && code) {
      try {
        used = (await get<{ inStock: boolean }>(`/masters/item-master/${encodeURIComponent(code)}`))
          .inStock;
      } catch {
        used = false;
      }
    }
    if (used) return setMsg({ kind: 'err', text: IN_TRANSACTION });
    if (DEFAULT_ITEMS.has(code)) return setMsg({ kind: 'err', text: DEFAULT_CODE });
    if (!code) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/item-master/${encodeURIComponent(code)}${opened}`);
      setMsg({ kind: 'ok', text: DELETED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  /** BtnPrint_Click_1 (:3697-3705): the print right is checked and nothing else happens. */
  function print() {
    setMsg(null);
    if (rights && !rights.canPrint) setMsg({ kind: 'err', text: NO_PRINT_RIGHTS });
  }

  /** btnTagValUpdate_Click (:3969-4015). */
  async function updateTags() {
    setMsg(null);
    if (!window.confirm(TAG_CONFIRM)) return;
    const code = fields.code.trim();
    if (!code) return setMsg({ kind: 'ok', text: TAG_DONE });
    if (rights && !rights.canUpdate) return setMsg({ kind: 'err', text: NO_RIGHTS });
    try {
      await post(`/masters/item-master/${encodeURIComponent(code)}/tag-values`, tagBoxes);
      setMsg({ kind: 'ok', text: TAG_DONE });
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    }
  }

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const toSearch = () => {
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

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
      const n = Math.max(
        0,
        Math.min(shown.length - 1, current + (event.key === 'ArrowDown' ? 1 : -1)),
      );
      setCurrent(n);
      listRows()[n]?.focus();
    }
  }

  /** Enter moves on (SendKeys {tab}); the product-dependent boxes need a product first (:3519-3727). */
  const onEnter =
    (next: string, guard: () => boolean = () => true) =>
    (event: KeyboardEvent<HTMLElement>) => {
      if (event.key !== 'Enter') return;
      event.preventDefault();
      if (guard()) focus(next);
    };
  const hasProduct = () => fields.productCode.trim() !== '';
  const ref = (key: string) => (el: HTMLElement | null) => {
    box.current[key] = el;
  };
  const NUMBER_NEXT: Record<NumberKey, string> = {
    lbrRate: 'lbrPrc',
    lbrPrc: 'ghtPrc',
    ghtPrc: 'conPrc',
    conPrc: 'discPrc',
    discPrc: 'itemRate',
    itemRate: 'othRate',
    othRate: 'othRateType',
    bagWt: 'save',
  };
  const numberBox = (key: NumberKey) => (
    <input
      id={`item-${key}`}
      ref={ref(key)}
      aria-label={NUMBERS[key].label}
      value={fields[key]}
      maxLength={NUMBERS[key].max}
      inputMode="decimal"
      style={{ width: NUMBERS[key].width, textAlign: 'right' }}
      onChange={(e) => set(key, e.target.value)}
      onKeyDown={(event) => {
        if (event.key !== 'Enter') return;
        event.preventDefault();
        set(key, fixed(fields[key], NUMBERS[key].places));
        if (NUMBER_NEXT[key] === 'save') saveRef.current?.focus();
        else focus(NUMBER_NEXT[key]);
      }}
    />
  );
  const row = (label: string, htmlFor: string, ...children: React.ReactNode[]) => (
    <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 5 }}>
      <label htmlFor={htmlFor} style={{ width: 106 }}>
        {label}
      </label>
      {children}
    </div>
  );
  const inline = (label: string, htmlFor: string, width = 90) => (
    <label htmlFor={htmlFor} style={{ width, marginLeft: 18 }}>
      {label}
    </label>
  );
  const readOnlyName = (label: string, value: string, width: number) => (
    <input aria-label={label} value={value} readOnly tabIndex={-1} style={{ width }} />
  );

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Item Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <datalist id="item-units">
        {combos.units.filter(Boolean).map((v) => (
          <option key={v} value={v} />
        ))}
      </datalist>
      <datalist id="item-safes">
        {combos.safes.filter(Boolean).map((v) => (
          <option key={v} value={v} />
        ))}
      </datalist>
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '450px minmax(600px, 1fr)',
          gridTemplateAreas: '"list fields" "list buttons"',
          gap: '10px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields', minWidth: 600 }}>
          {row(
            'Pr Code',
            'item-productCode',
            entryMode === 'A' ? (
              <div key="p" ref={ref('productCode')}>
                <LookupPicker
                  entity="products"
                  searchPath="/masters/item-master/products"
                  ariaLabel="Pr Code"
                  value={fields.productCode}
                  placeholder=""
                  resolveTypedCode
                  onChange={(code) =>
                    setFields((f) => ({
                      ...f,
                      productCode: typed(code),
                      productName: typed(code) === f.productCode ? f.productName : '',
                    }))
                  }
                  onPick={(picked) =>
                    setFields((f) => ({
                      ...f,
                      productCode: String(picked.code),
                      productName: String(picked.name ?? ''),
                    }))
                  }
                  style={{ width: 66 }}
                />
              </div>
            ) : (
              <input
                key="p"
                id="item-productCode"
                ref={ref('productCode')}
                aria-label="Pr Code"
                value={fields.productCode}
                readOnly
                style={{ width: 66 }}
                onKeyDown={onEnter('groupCode')}
              />
            ),
            <span key="n">{readOnlyName('Product Name', fields.productName, 274)}</span>,
          )}
          {row(
            'Gr Code',
            'item-groupCode',
            entryMode === 'A' ? (
              <div key="g" ref={ref('groupCode')}>
                <LookupPicker
                  entity="groups"
                  searchPath="/masters/item-master/groups"
                  ariaLabel="Gr Code"
                  value={fields.groupCode}
                  placeholder=""
                  resolveTypedCode
                  onChange={(code) =>
                    setFields((f) => ({
                      ...f,
                      groupCode: typed(code),
                      groupName: typed(code) === f.groupCode ? f.groupName : '',
                    }))
                  }
                  onPick={(picked) =>
                    groupChosen({
                      code: String(picked.code),
                      name: String(picked.name ?? ''),
                      type: picked.type,
                      trade: picked.trade,
                    })
                  }
                  style={{ width: 66 }}
                />
              </div>
            ) : (
              <input
                key="g"
                id="item-groupCode"
                ref={ref('groupCode')}
                aria-label="Gr Code"
                value={fields.groupCode}
                readOnly
                style={{ width: 66 }}
                onKeyDown={onEnter('code')}
              />
            ),
            <span key="n">{readOnlyName('Group Name', fields.groupName, 240)}</span>,
          )}
          {row(
            'Item Code',
            'item-code',
            <input
              key="c"
              id="item-code"
              ref={ref('code')}
              value={fields.code}
              maxLength={5}
              readOnly={entryMode === 'E'}
              style={{ width: 90 }}
              onChange={(e) => set('code', typed(e.target.value))}
              onBlur={codeFree}
              onKeyDown={onEnter('tagType', hasProduct)}
            />,
            <input
              key="t"
              id="item-tagType"
              ref={ref('tagType')}
              aria-label="Tag Type"
              value={fields.tagType}
              maxLength={1}
              style={{ width: 26 }}
              onChange={(e) => set('tagType', typed(e.target.value))}
              onKeyDown={onEnter('name', hasProduct)}
            />,
          )}
          {row(
            'Item Name',
            'item-name',
            <input
              key="n"
              id="item-name"
              ref={ref('name')}
              value={fields.name}
              maxLength={50}
              style={{ width: 344 }}
              onChange={(e) => set('name', typed(e.target.value))}
              onBlur={nameFree}
              onKeyDown={onEnter('safe', () => fields.name.trim() !== '')}
            />,
          )}
          {row(
            'Safe Name',
            'item-safe',
            <input
              key="s"
              id="item-safe"
              ref={ref('safe')}
              value={fields.safe}
              maxLength={30}
              list="item-safes"
              style={{ width: 172 }}
              onChange={(e) => set('safe', typed(e.target.value))}
              onKeyDown={onEnter('hsn')}
            />,
          )}
          {row(
            'Hsn Code',
            'item-hsn',
            <input
              key="h"
              id="item-hsn"
              ref={ref('hsn')}
              value={fields.hsn}
              maxLength={10}
              style={{ width: 124 }}
              onChange={(e) => set('hsn', typed(e.target.value))}
              onKeyDown={onEnter('unit', hasProduct)}
            />,
          )}
          {row(
            'Unit Name',
            'item-unit',
            <input
              key="u"
              id="item-unit"
              ref={ref('unit')}
              value={fields.unit}
              maxLength={5}
              list="item-units"
              style={{ width: 124 }}
              onChange={(e) => set('unit', typed(e.target.value))}
              onKeyDown={onEnter('rateType', hasProduct)}
            />,
          )}
          {row(
            'Rate Per',
            'item-rateType',
            <select
              key="r"
              id="item-rateType"
              ref={ref('rateType')}
              value={fields.rateType}
              style={{ width: 124 }}
              onChange={(e) => set('rateType', e.target.value)}
              onKeyDown={onEnter('lbrRate')}
            >
              {RATE_TYPES.map(([letter, caption]) => (
                <option key={letter} value={letter}>
                  {caption}
                </option>
              ))}
            </select>,
          )}
          {row('Labour Rate', 'item-lbrRate', <span key="a">{numberBox('lbrRate')}</span>)}
          {row(
            'Labour %',
            'item-lbrPrc',
            <span key="a">{numberBox('lbrPrc')}</span>,
            <span key="b">{inline('Ght %', 'item-ghtPrc', 63)}</span>,
            <span key="c">{numberBox('ghtPrc')}</span>,
          )}
          {row('Conversion %', 'item-conPrc', <span key="a">{numberBox('conPrc')}</span>)}
          {row('Discount %', 'item-discPrc', <span key="a">{numberBox('discPrc')}</span>)}
          {row('Item Rate', 'item-itemRate', <span key="a">{numberBox('itemRate')}</span>)}
          {row(
            'Oth itm Rate',
            'item-othRate',
            <span key="a">{numberBox('othRate')}</span>,
            <span key="b">{inline('Oth Dtl Rate Type', 'item-othRateType', 120)}</span>,
            <select
              key="c"
              id="item-othRateType"
              ref={ref('othRateType')}
              value={fields.othRateType}
              style={{ width: 75 }}
              onChange={(e) => set('othRateType', e.target.value)}
              onKeyDown={onEnter('bagWt')}
            >
              {OTHER_RATE_TYPES.map(([letter, caption]) => (
                <option key={letter} value={letter}>
                  {caption}
                </option>
              ))}
            </select>,
          )}
          {row('Bag Weight', 'item-bagWt', <span key="a">{numberBox('bagWt')}</span>)}
          {/* The boxes the desktop draws on the rows above but reaches late in its tab order (tab index 106-143). */}
          <div
            className="row"
            style={{ alignItems: 'center', gap: 6, marginTop: 8, flexWrap: 'wrap' }}
          >
            <label htmlFor="item-itType">Item Type</label>
            <input
              id="item-itType"
              value={fields.itType}
              maxLength={1}
              style={{ width: 28 }}
              onChange={(e) => set('itType', typed(e.target.value))}
            />
            <label htmlFor="item-tradeType" style={{ marginLeft: 12 }}>
              Trade Type
            </label>
            <input
              id="item-tradeType"
              value={fields.tradeType}
              maxLength={2}
              style={{ width: 28 }}
              onChange={(e) => set('tradeType', typed(e.target.value))}
            />
            <label htmlFor="item-stockDisplay" style={{ marginLeft: 12 }}>
              Stk Display
            </label>
            <select
              id="item-stockDisplay"
              value={fields.stockDisplay}
              style={{ width: 70 }}
              onChange={(e) => set('stockDisplay', e.target.value)}
            >
              <option value="Y">Yes</option>
              <option value="N">No</option>
            </select>
            {settings.lotStock && (
              <label className="row" style={{ gap: 4, marginLeft: 12 }}>
                <input
                  type="checkbox"
                  checked={fields.lotStock}
                  onChange={(e) => set('lotStock', e.target.checked)}
                />
                Lot Wise Stock
              </label>
            )}
            {settings.othItmWtRemove && (
              <label className="row" style={{ gap: 4, marginLeft: 12 }}>
                <input
                  type="checkbox"
                  checked={fields.othItmWtRemove}
                  onChange={(e) => set('othItmWtRemove', e.target.checked)}
                />
                Oth Item Wt Less In Wh Sal
              </label>
            )}
          </div>
          {tagPanel && (
            <section
              className="panel"
              aria-label="Item Wise Tag Value Update"
              style={{ marginTop: 10 }}
            >
              <h2 style={{ marginTop: 0 }}>Item Wise Tag Value Update</h2>
              {(
                [
                  ['lbrPrc', 'Lbr %', 'krTouch'],
                  ['krTouch', 'Kr Touch %', 'krWestPrc'],
                  ['krWestPrc', 'Kr West  %', 'tagButton'],
                ] as const
              ).map(([key, caption, next]) => (
                <div
                  key={key}
                  className="row"
                  style={{ alignItems: 'center', gap: 6, marginBottom: 5 }}
                >
                  <label htmlFor={`item-tag-${key}`} style={{ width: 90 }}>
                    {caption}
                  </label>
                  <input
                    id={`item-tag-${key}`}
                    ref={ref(`tag-${key}`)}
                    value={tagBoxes[key]}
                    maxLength={6}
                    inputMode="decimal"
                    style={{ width: 90, textAlign: 'right' }}
                    onChange={(e) => setTagBoxes((t) => ({ ...t, [key]: e.target.value }))}
                    onKeyDown={(event) => {
                      if (event.key !== 'Enter') return;
                      event.preventDefault();
                      setTagBoxes((t) => ({ ...t, [key]: fixed(t[key], 2) }));
                      focus(next === 'tagButton' ? 'tagButton' : `tag-${next}`);
                    }}
                  />
                </div>
              ))}
              <button
                type="button"
                ref={ref('tagButton')}
                className="ghost"
                onClick={() => void updateTags()}
              >
                Tag Value Update
              </button>
            </section>
          )}
        </div>
        <div
          className="row"
          data-testid="item-button-bar"
          style={{ gridArea: 'buttons', gap: 8, justifyContent: 'flex-end', padding: 4 }}
          onDoubleClick={(event) => {
            // PnlBotam_DoubleClick: the panel itself, not a button on it.
            if (event.target !== event.currentTarget) return;
            setTagPanel(!tagPanel);
            setTimeout(() => focus(tagPanel ? 'name' : 'tag-lbrPrc'), 0);
          }}
        >
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
            onClick={print}
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
                <th style={{ width: 75 }}>Code</th>
                <th>Name</th>
                <th style={{ width: 110 }}>Safe</th>
              </tr>
            </thead>
            <tbody ref={listRef} data-testid="item-list" onKeyDown={onListKeyDown}>
              {shown.map((r, i) => (
                <tr
                  key={r.code}
                  tabIndex={0}
                  aria-selected={i === current}
                  data-code={r.code}
                  className={i === current ? 'selected' : undefined}
                  onFocus={() => setCurrent(i)}
                  onDoubleClick={() => void open(r.code)}
                >
                  <td>{r.code}</td>
                  <td>{r.name}</td>
                  <td>{r.safe}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
