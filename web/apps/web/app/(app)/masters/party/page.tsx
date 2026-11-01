'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Party master (desktop MS_ACCT, Master → Party; MDI_FORM.cs:7600-7609), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_ACCT.layout.json`): the search box and the Code / Name / Mobile list, the
 * photo, the "Oppning Balance" box and the Last Visit and Ledger Date boxes on the left; the customer line and the
 * Company Detail, Other Detail and Family Detl tabs on the right; Print, Save, Cancel, Delete and Exit along the bottom.
 *
 * - A new entry offers the next code, read-only, with the cursor in the name (CLEAR_DATA :6134-6355); Ctrl+E unlocks
 *   the code box (:6735-6745). Enter on the list or a double click opens a party (DGV_KeyDown :6704-6733).
 * - Every typed key is upper-cased and the apostrophe refused (MS_ACCT_KeyPress :6606-6619); the email is lower case.
 * - Enter moves through the boxes in the form's tab order. On the way: a blank name says "Please Insert Party Name ...";
 *   the group code fills its name or opens the AC_GROUP help; the mobile, mobile 2 and short name refuse a value another
 *   account has; the GST number fills the state and GST type; the main account and the reference open the account help
 *   when the code is unknown; the opening boxes are formatted; Silver's Cr/Dr goes to Mobile No2 on Other Detail and
 *   Khata No to Save (:6766-9640).
 * - F1 on the name and the F1 button open the help of the location's parties; F1 on the short name (administrator)
 *   lists the short names; the D, S and A buttons copy an address, a scheme member or another account (:8501-8574,
 *   :9024-9058). Leaving the name refuses a name another listed code has (:7624-7648).
 * - The photo buttons pick a JPEG (saved at once), take one from the camera, or delete it after asking; a double click
 *   zooms (:8162-8466).
 * - Save, Delete and Print answer with the desktop's texts and rights (:7650-8025, :8657-8668).
 *
 * Deliberate differences: the opening of an opened party is read-only (Party Opening edits it); the next code counts the
 * location's AC_MAST codes too; an opened party carries the version read with it; Print shows the listed accounts on the
 * screen because the AcMast report layout is not in the repository; the customer line uses the current mobile. The
 * hidden admin panel, defaulter box and limits (shown only for the Advance and Enterprise software types, :5964-5973),
 * the UAE boxes and the hidden Excel and old-year import buttons (Ctrl+O, Ctrl+Y) are left out; Family Detl is empty as
 * on the desktop.
 */
const M = {
  NO_RIGHTS: 'You Have No Rights.....',
  NO_PRINT_RIGHTS: 'You Have No Print Rights.....',
  SAVED: 'Data Are Saved.',
  DELETED: 'Delete Success.',
  DELETE_CONFIRM: 'Are You Sure To Delete This Account now?',
  SELECT_FOR_DELETE: 'Please Select AcCode For Delete.',
  NAME_REQUIRED: 'Please Insert Party Name ...',
  DETAIL_REQUIRED: 'Enter Party Name and Account group Detail',
  PHOTO_DELETE_CONFIRM: 'Are You Sure To Delete This Image now?',
  SEARCH_TEXT: 'SEARCH  NAME - MOBILE',
  RECORD_TEXT: 'SEARCH RECORD',
} as const;
const nameTaken = (code: string) =>
  `This Ac Name already Exist in  '${code}'  Ac Code... Please Change Account Name...`;
const codeTaken = (name: string) =>
  `This Ac Code already Exist in  '${name}'  Party Name...Please Change Party Name...`;

type TextKey =
  | 'name'
  | 'group'
  | 'mainGroup'
  | 'acType'
  | 'mobile'
  | 'phone'
  | 'person'
  | 'short'
  | 'address1'
  | 'address2'
  | 'address3'
  | 'city'
  | 'pin'
  | 'area'
  | 'gstNo'
  | 'gstType'
  | 'panNo'
  | 'lcsNo'
  | 'state'
  | 'district'
  | 'mainAcCode'
  | 'birthDate'
  | 'anniversary'
  | 'lBirthDate'
  | 'refCode'
  | 'refName'
  | 'mobile2'
  | 'phone2'
  | 'aadhaar'
  | 'passport'
  | 'country'
  | 'bankName'
  | 'bankArea'
  | 'bankAcNo'
  | 'rtgs'
  | 'email'
  | 'crDays'
  | 'intPrc'
  | 'dpcPrc'
  | 'khata'
  | 'amtLimit'
  | 'goldLimit'
  | 'silverLimit'
  | 'lastVisit'
  | 'ledgerDate';
type FlagKey = 'defaulter' | 'withTds' | 'member' | 'shareHolder';
type OpeningKey = 'opAmount' | 'opSign' | 'opGold' | 'opGoldSign' | 'opSilver' | 'opSilverSign';
type Stop = TextKey | OpeningKey | 'code';
type Combo = 'countries' | 'states' | 'districts' | 'cities' | 'areas';

interface Box {
  key: TextKey;
  label: string;
  width: number;
  max?: number;
  combo?: Combo;
  date?: boolean;
  readOnly?: boolean;
  select?: Array<[string, string]>;
}
const box = (key: TextKey, label: string, width: number, extra: Partial<Box> = {}): Box => ({
  key,
  label,
  width,
  ...extra,
});
/** Company Detail (Pnl1) row by row, with the boxes' widths and MaxLength (DataCareNext.MS_ACCT.resx). */
const COMPANY_ROWS: Box[][] = [
  [box('name', 'Ac Name', 391, { max: 50 })],
  [
    box('group', 'Ac Group', 75, { max: 2 }),
    box('mainGroup', 'Main Group', 25, { max: 1, readOnly: true }),
    // CLEAR_DATA selects A (:6233); a party stored with no type shows the DropDownList blank.
    box('acType', 'Ac Type', 76, { select: ['', 'A', 'B', 'C', 'D', 'E'].map((v) => [v, v]) }),
  ],
  [box('mobile', 'Mobile No', 158, { max: 15 }), box('phone', 'Phone No', 148, { max: 15 })],
  [box('person', 'Con Person', 246, { max: 40 }), box('short', 'Ac Short', 66, { max: 5 })],
  [box('address1', 'Address1', 391, { max: 50 })],
  [box('address2', 'Address2', 391, { max: 50 })],
  [box('address3', 'Address3', 391, { max: 50 })],
  [box('city', 'City', 220, { max: 20, combo: 'cities' }), box('pin', 'Pin Code', 102, { max: 8 })],
  [box('area', 'City Area', 391, { max: 25, combo: 'areas' })],
  [
    box('gstNo', 'Gst No', 220, { max: 15 }),
    box('gstType', 'Gst Type', 166, {
      select: [
        ['L', 'Local'],
        ['I', 'Inter state'],
      ],
    }),
  ],
  [box('panNo', 'Pan No', 220, { max: 20 }), box('lcsNo', 'Lcs No', 107, { max: 15 })],
  [box('state', 'State', 391, { max: 20, combo: 'states' })],
  [
    box('district', 'District', 220, { max: 21, combo: 'districts' }),
    box('mainAcCode', 'Main Ac', 79, { max: 8 }),
  ],
  [
    box('birthDate', 'Birth Date', 79, { date: true }),
    box('anniversary', 'Anv Dt', 78, { date: true }),
    box('lBirthDate', 'L Birth Dt', 79, { date: true }),
  ],
  [box('refCode', 'Ref By', 78, { max: 8 }), box('refName', 'Ref Name', 310, { max: 50 })],
];
/** Other Detail (Pnl2), the boxes the Lite software type shows. */
const OTHER_ROWS: Box[][] = [
  [box('mobile2', 'Mobile No2', 148, { max: 15 }), box('phone2', 'Phone No2', 148, { max: 15 })],
  [box('aadhaar', 'Adhar No', 148, { max: 12 }), box('passport', 'Passport No', 148, { max: 15 })],
  [box('country', 'Country', 391, { max: 20, combo: 'countries' })],
  [box('bankName', 'Bank Name', 391, { max: 50 })],
  [box('bankArea', 'Branch Name', 391, { max: 40 })],
  [box('bankAcNo', 'Bank AcNo', 391, { max: 30 })],
  [box('rtgs', 'ISFC Code', 391, { max: 30 })],
  [box('email', 'Email', 391, { max: 50 })],
  [box('crDays', 'Cr Day', 79, { max: 10 }), box('intPrc', 'Month Int %', 78, { max: 10 })],
  [box('dpcPrc', 'Dpc %', 79, { max: 10 })],
  [box('khata', 'Khata No', 79, { max: 10 })],
];
/** The Enter order (SendKeys {tab} and the handlers' Focus calls). */
const COMPANY_ORDER: Stop[] = [
  'code',
  'name',
  'group',
  'acType',
  'mobile',
  'phone',
  'person',
  'short',
  'address1',
  'address2',
  'address3',
  'city',
  'pin',
  'area',
  'gstNo',
  'gstType',
  'panNo',
  'lcsNo',
  'state',
  'district',
  'mainAcCode',
  'birthDate',
  'anniversary',
  'lBirthDate',
  'refCode',
  'opAmount',
  'opSign',
  'opGold',
  'opGoldSign',
  'opSilver',
  'opSilverSign',
];
const OTHER_ORDER: Stop[] = [
  'mobile2',
  'phone2',
  'aadhaar',
  'passport',
  'country',
  'bankName',
  'bankArea',
  'bankAcNo',
  'rtgs',
  'email',
  'crDays',
  'intPrc',
  'dpcPrc',
  'khata',
];
const ALL_BOXES = [...COMPANY_ROWS.flat(), ...OTHER_ROWS.flat()];
const TEXT_KEYS: TextKey[] = [
  ...ALL_BOXES.map((b) => b.key),
  'amtLimit',
  'goldLimit',
  'silverLimit',
  'lastVisit',
  'ledgerDate',
];
const FLAGS: Array<[FlagKey, string]> = [
  ['withTds', 'This Ac Set With Tds Tax'],
  ['member', 'Member For Commission'],
  ['shareHolder', 'Shareholder Commission'],
];

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
  mobile: string;
  lc: string;
}
type Values = Record<TextKey, string> & Record<FlagKey, boolean>;
interface Opening {
  amount: string;
  sign: 'C' | 'D';
  gold: string;
  goldSign: 'C' | 'D';
  silver: string;
  silverSign: 'C' | 'D';
}
type HelpKind = 'names' | 'f1' | 'groups' | 'short' | 'main' | 'address' | 'member' | 'account';
interface HelpState {
  kind: HelpKind;
  /** What the pick does: open the party, fill a box, or copy a source. */
  target: 'open' | 'group' | 'mainAcCode' | 'refCode' | 'copy' | 'view';
  rows: Array<Record<string, string>>;
  back: Stop;
}
const HELP_COLUMNS: Record<HelpKind, Array<[string, string]>> = {
  names: [
    ['name', 'AcNameL'],
    ['code', 'AcCodeL'],
    ['group', 'GroupL'],
    ['address', 'AddressL'],
    ['phone', 'PhoneL'],
    ['mobile', 'MobileL'],
  ],
  f1: [
    ['name', 'AcNameL'],
    ['code', 'AcCodeL'],
    ['short', 'ShortL'],
    ['group', 'GroupL'],
    ['address', 'AddressL'],
    ['phone', 'PhoneL'],
    ['mobile', 'MobileL'],
    ['user', 'UserL'],
  ],
  groups: [
    ['code', 'GrCode'],
    ['name', 'AcGroupL'],
    ['subGroup', 'MainGroupL'],
  ],
  short: [
    ['short', 'ShortL'],
    ['name', 'AcNameL'],
    ['address', 'AddressL'],
    ['mobile', 'MobileL'],
  ],
  main: [
    ['name', 'AcNameL'],
    ['code', 'AcCodeL'],
    ['group', 'GroupL'],
    ['area', 'AreaL'],
    ['address', 'AddressL'],
    ['city', 'CityL'],
    ['mobile', 'MobileL'],
  ],
  address: [
    ['name', 'AcNameL'],
    ['code', 'AcCodeL'],
    ['area', 'AreaL'],
    ['address', 'AddressL'],
    ['city', 'CityL'],
  ],
  member: [
    ['name', 'AcNameL'],
    ['code', 'MembCodeL'],
    ['scheme', 'SchmCodeL'],
    ['address', 'AddressL'],
    ['city', 'CityL'],
  ],
  account: [
    ['name', 'AcNameL'],
    ['code', 'AcCodeL'],
    ['area', 'AreaL'],
    ['address', 'AddressL'],
    ['city', 'CityL'],
  ],
};

const today = () => {
  const d = new Date();
  return `${String(d.getDate()).padStart(2, '0')}/${String(d.getMonth() + 1).padStart(2, '0')}/${d.getFullYear()}`;
};
const blank = (state = ''): Values => {
  const v = Object.fromEntries(TEXT_KEYS.map((k) => [k, ''])) as unknown as Values;
  v.acType = 'A';
  v.gstType = 'L';
  v.state = state;
  v.lastVisit = today();
  v.defaulter = false;
  v.withTds = false;
  v.member = false;
  v.shareHolder = false;
  return v;
};
const NO_OPENING: Opening = {
  amount: '',
  sign: 'C',
  gold: '',
  goldSign: 'C',
  silver: '',
  silverSign: 'C',
};
/** MS_ACCT_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
/** The masked date boxes (mask 00/00/0000): digits only, with the slashes the mask shows. */
const maskDate = (value: string) => {
  const d = value.replace(/\D/g, '').slice(0, 8);
  if (d.length > 4) return `${d.slice(0, 2)}/${d.slice(2, 4)}/${d.slice(4)}`;
  return d.length > 2 ? `${d.slice(0, 2)}/${d.slice(2)}` : d;
};
/** Strings.Format(Val(x), "0.00") / "0.000" on Enter (nOpAmt_KeyDown :8071-8085 and the others). */
const formatted = (value: string, places: number) => {
  const m = /^\s*[+-]?(\d+\.?\d*|\.\d+)/.exec(value);
  const n = m ? Number(m[0]) : 0;
  return Number.isFinite(n) ? n.toFixed(places) : (0).toFixed(places);
};
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function PartyMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [groups, setGroups] = useState<Array<Record<string, string>>>([]);
  const [combos, setCombos] = useState<Record<Combo, string[]>>({
    countries: [],
    states: [],
    districts: [],
    cities: [],
    areas: [],
  });
  const [rights, setRights] = useState<Rights | null>(null);
  const [admin, setAdmin] = useState(false);
  const [coState, setCoState] = useState('');
  const [code, setCode] = useState('');
  const [codeLocked, setCodeLocked] = useState(true);
  const [values, setValues] = useState<Values>(() => blank());
  const [groupName, setGroupName] = useState('');
  const [opening, setOpening] = useState<Opening>(NO_OPENING);
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [tab, setTab] = useState<'company' | 'other' | 'family'>('company');
  const [search, setSearch] = useState<string>(M.SEARCH_TEXT);
  const [typing, setTyping] = useState(false);
  const [current, setCurrent] = useState(0);
  const [help, setHelp] = useState<HelpState | null>(null);
  const [helpFilter, setHelpFilter] = useState('');
  const [helpAt, setHelpAt] = useState(0);
  const [photo, setPhoto] = useState<string | null>(null);
  const [zoom, setZoom] = useState(false);
  const [printRows, setPrintRows] = useState<Array<Record<string, string>> | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const boxes = useRef<Partial<Record<Stop | 'lastVisit' | 'ledgerDate', HTMLElement | null>>>({});
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const helpFilterRef = useRef<HTMLInputElement>(null);
  const photoInput = useRef<HTMLInputElement>(null);
  const cameraInput = useRef<HTMLInputElement>(null);
  const focusAfter = useRef<Stop | null>(null);

  const focus = useCallback((stop: Stop | 'lastVisit' | 'ledgerDate') => {
    const el = boxes.current[stop];
    el?.focus();
    if (el instanceof HTMLInputElement) el.select();
  }, []);
  useEffect(() => {
    if (busy || !focusAfter.current) return;
    const stop = focusAfter.current;
    focusAfter.current = null;
    setTimeout(() => focus(stop), 0);
  }, [busy, entryMode, code, tab, focus]);
  useEffect(() => {
    if (help) setTimeout(() => helpFilterRef.current?.focus(), 0);
  }, [help]);

  /** CLEAR_DATA: blank boxes, the combos and the list read again, the next code, the cursor in the name. */
  const clear = useCallback(async () => {
    setBusy(true);
    setValues(blank());
    setGroupName('');
    setOpening(NO_OPENING);
    setCodeLocked(true);
    setEntryMode('A');
    setVersion('');
    setTab('company');
    setSearch(M.SEARCH_TEXT);
    setTyping(false);
    setCurrent(0);
    setHelp(null);
    setPhoto(null);
    focusAfter.current = 'name';
    try {
      const [view, groupHelp] = await Promise.all([
        get<{
          rows: ListRow[];
          combos: Record<Combo, string[]>;
          nextCode: string;
          rights: Rights;
          admin: boolean;
          coState: string;
        }>('/masters/party-master'),
        get<{ rows: Array<Record<string, string>> }>('/masters/party-master/help/groups'),
      ]);
      setList(view.rows);
      setCombos(view.combos);
      setRights(view.rights);
      setAdmin(view.admin);
      setCoState(view.coState);
      setCode(view.nextCode);
      setGroups(groupHelp.rows);
      setValues(blank(view.coState));
      const shot = await get<{ dataUrl: string | null }>(
        `/masters/party-master/${encodeURIComponent(view.nextCode)}/photo`,
      ).catch(() => ({ dataUrl: null }));
      setPhoto(shot.dataUrl);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? M.NO_RIGHTS : messageOf(error),
      });
    } finally {
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void clear();
  }, [clear]);

  /** Text1_TextChanged: names that contain the text or mobiles that start with it; tAcName_TextChanged in a new
   *  entry: names that start with the name typed. */
  const shown = useMemo(() => {
    if (typing && entryMode === 'A' && values.name.trim()) {
      const wanted = values.name.trim();
      return list.filter((row) => row.name.toUpperCase().startsWith(wanted));
    }
    const wanted = search === M.SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted
      ? list.filter((r) => r.name.toUpperCase().includes(wanted) || r.mobile.startsWith(wanted))
      : list;
  }, [list, search, typing, entryMode, values.name]);

  async function open(openCode: string) {
    if (!openCode) return;
    setBusy(true);
    setMsg(null);
    setHelp(null);
    try {
      const found = await get<
        | {
            code: string;
            values: Record<string, string | boolean>;
            groupName: string;
            opening: Opening & { exists: boolean };
            version: string;
          }
        | { branch: string }
      >(`/masters/party-master/${encodeURIComponent(openCode)}`);
      if ('branch' in found) {
        setMsg({
          kind: 'err',
          text: `This Ac Code Is Branch With : ${found.branch} You Cant Change...`,
        });
        return;
      }
      const next = blank(coState);
      for (const key of TEXT_KEYS) next[key] = String(found.values[key] ?? '');
      for (const [key] of [['defaulter'], ...FLAGS] as Array<[FlagKey]>)
        next[key] = found.values[key] === true;
      setValues(next);
      setGroupName(found.groupName);
      setOpening(found.opening.exists ? found.opening : NO_OPENING);
      setCode(found.code);
      setCodeLocked(true);
      setEntryMode('E');
      setVersion(found.version);
      setTyping(false);
      setTab('company');
      const shot = await get<{ dataUrl: string | null }>(
        `/masters/party-master/${encodeURIComponent(found.code)}/photo`,
      ).catch(() => ({ dataUrl: null }));
      setPhoto(shot.dataUrl);
      focusAfter.current = 'name';
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const set = (key: TextKey, value: string) => setValues((v) => ({ ...v, [key]: value }));
  const setFlag = (key: FlagKey, value: boolean) => setValues((v) => ({ ...v, [key]: value }));

  /** tAcName_Validating: the name may not be another listed code's. */
  function nameFree() {
    const wanted = values.name.trim();
    const other =
      wanted && list.find((row) => row.name.toUpperCase() === wanted && row.code !== code.trim());
    if (other) {
      setMsg({ kind: 'err', text: nameTaken(other.code) });
      setTimeout(() => focus('name'), 0);
      return false;
    }
    return true;
  }
  /** tAcCode_Validating: an unlocked code may not be another party's when a name is typed. */
  function codeFree() {
    if (codeLocked || !values.name.trim()) return true;
    const row = list.find((r) => r.code === code.trim());
    if (row && row.name.toUpperCase() !== values.name.trim()) {
      setMsg({ kind: 'err', text: codeTaken(row.name) });
      setTimeout(() => focus('code'), 0);
      return false;
    }
    return true;
  }

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);

  async function save() {
    setMsg(null);
    if (!codeFree() || !nameFree()) return;
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: M.NO_RIGHTS });
    setBusy(true);
    try {
      const payload: Record<string, unknown> = { unlocked: !codeLocked };
      for (const key of TEXT_KEYS) payload[key] = values[key].trim();
      for (const [key] of [['defaulter'], ...FLAGS] as Array<[FlagKey]>) payload[key] = values[key];
      if (entryMode === 'E')
        await put(`/masters/party-master/${encodeURIComponent(code.trim())}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/party-master', { code: code.trim(), ...payload, opening });
      await clear();
      setMsg({ kind: 'ok', text: M.SAVED });
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, M.NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (!codeFree() || !nameFree()) return;
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: M.NO_RIGHTS });
    if (!code.trim()) return setMsg({ kind: 'err', text: M.SELECT_FOR_DELETE });
    const q = new URLSearchParams();
    if (entryMode === 'E' && version) q.set('expectedVersion', version);
    if (!codeLocked) q.set('unlocked', 'Y');
    const url = (dryRun: boolean) => {
      const query = new URLSearchParams(q);
      if (dryRun) query.set('dryRun', 'Y');
      const tail = query.toString() ? `?${query}` : '';
      return `/masters/party-master/${encodeURIComponent(code.trim())}${tail}`;
    };
    // BtnDelete_Click refuses a party in use or a default account before it asks (:7975-7998).
    try {
      await del(url(true));
    } catch (error) {
      return setMsg({ kind: 'err', text: refusal(error, M.NO_RIGHTS) });
    }
    if (!window.confirm(M.DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      await del(url(false));
      await clear();
      setMsg({ kind: 'ok', text: M.DELETED });
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, M.NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function print() {
    setMsg(null);
    if (!codeFree() || !nameFree()) return;
    if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: M.NO_PRINT_RIGHTS });
    try {
      setPrintRows(
        (await get<{ rows: Array<Record<string, string>> }>('/masters/party-master/print')).rows,
      );
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, M.NO_PRINT_RIGHTS) });
    }
  }

  async function openHelp(kind: HelpKind, target: HelpState['target'], back: Stop) {
    try {
      const rows =
        kind === 'groups'
          ? groups
          : (
              await get<{ rows: Array<Record<string, string>> }>(
                `/masters/party-master/help/${kind}`,
              )
            ).rows;
      setHelpFilter('');
      setHelpAt(0);
      setHelp({ kind, target, rows, back });
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }
  /** MS_HELP's search box keeps the rows whose first column contains the text (MS_HELP.cs:1687). */
  const helpRows = useMemo(() => {
    if (!help) return [];
    const first = HELP_COLUMNS[help.kind][0]![0];
    const wanted = helpFilter.trim().toUpperCase();
    return wanted
      ? help.rows.filter((r) =>
          String(r[first] ?? '')
            .toUpperCase()
            .includes(wanted),
        )
      : help.rows;
  }, [help, helpFilter]);
  function closeHelp() {
    const back = help?.back ?? 'name';
    setHelp(null);
    setTimeout(() => focus(back), 0);
  }
  async function pick(row: Record<string, string>) {
    if (!help) return;
    const { target, kind, back } = help;
    setHelp(null);
    if (target === 'open') return void open(row.code ?? '');
    if (target === 'group') {
      set('group', row.code ?? '');
      set('mainGroup', row.mainGroup ?? '');
      setGroupName(row.name ?? '');
    } else if (target === 'mainAcCode') set('mainAcCode', row.code ?? '');
    else if (target === 'refCode') {
      set('refCode', row.code ?? '');
      set('refName', row.name ?? '');
    } else if (target === 'copy') {
      try {
        const q = new URLSearchParams({ code: row.code ?? '', scheme: row.scheme ?? '' });
        const { values: copied } = await get<{ values: Record<string, string> | null }>(
          `/masters/party-master/copy/${kind}?${q}`,
        );
        if (copied) setValues((v) => ({ ...v, ...copied }));
        setTimeout(() => focus('name'), 0);
      } catch (error) {
        setMsg({ kind: 'err', text: messageOf(error) });
      }
      return;
    }
    setTimeout(() => focus(back), 0);
  }

  /** The next stop of Enter in the visible tab (SendKeys {tab}); Silver's combo goes to Mobile No2 on Other Detail. */
  function next(from: Stop) {
    if (from === 'opSilverSign') {
      setTab('other');
      focusAfter.current = 'mobile2';
      setTimeout(() => {
        if (focusAfter.current === 'mobile2') {
          focusAfter.current = null;
          focus('mobile2');
        }
      }, 0);
      return;
    }
    if (from === 'khata') return saveRef.current?.focus();
    const order = COMPANY_ORDER.includes(from) ? COMPANY_ORDER : OTHER_ORDER;
    const target = order[order.indexOf(from) + 1];
    if (target) focus(target);
    else saveRef.current?.focus();
  }

  async function taken(kind: 'mobile' | 'mobile2' | 'short', value: string) {
    const q = new URLSearchParams({ value, code: code.trim() });
    return (
      await get<{ taken: { message: string; clear: boolean } | null }>(
        `/masters/party-master/taken/${kind}?${q}`,
      )
    ).taken;
  }

  async function onEnter(key: Stop) {
    setMsg(null);
    try {
      if (key === 'name' && !values.name.trim()) {
        setMsg({ kind: 'err', text: M.NAME_REQUIRED });
        return;
      }
      if (key === 'name' && !nameFree()) return;
      if (key === 'group') {
        const exact = groups.find((g) => g.code === values.group.trim());
        if (!exact) return void openHelp('groups', 'group', 'group');
        set('mainGroup', exact.mainGroup ?? '');
        setGroupName(exact.name ?? '');
      }
      if ((key === 'mobile' || key === 'mobile2' || key === 'short') && values[key].trim()) {
        const found = await taken(key, values[key].trim());
        if (found) {
          if (found.clear) set(key, '');
          setMsg({ kind: 'err', text: found.message });
          return;
        }
      }
      if (key === 'phone') return focus('person');
      if (key === 'gstNo') {
        const s = await get<{ state: string; gstType: 'L' | 'I' | null }>(
          `/masters/party-master/gst-state?gst=${encodeURIComponent(values.gstNo.trim())}`,
        );
        setValues((v) => ({ ...v, state: s.state || v.state, gstType: s.gstType ?? v.gstType }));
      }
      if ((key === 'mainAcCode' || key === 'refCode') && values[key].trim()) {
        const { account } = await get<{ account: { code: string; name: string } | null }>(
          `/masters/party-master/account?code=${encodeURIComponent(values[key].trim())}`,
        );
        if (!account) return void openHelp(key === 'refCode' ? 'names' : 'main', key, key as Stop);
        if (key === 'refCode') set('refName', account.name);
      }
      if (key === 'opAmount' && opening.amount.trim() && entryMode === 'A')
        setOpening((o) => ({ ...o, amount: formatted(o.amount, 2) }));
      if (key === 'opGold' && opening.gold.trim() && entryMode === 'A')
        setOpening((o) => ({ ...o, gold: formatted(o.gold, 3) }));
      if (key === 'opSilver' && opening.silver.trim() && entryMode === 'A')
        setOpening((o) => ({ ...o, silver: formatted(o.silver, 3) }));
      if (key === 'intPrc' || key === 'dpcPrc') set(key, formatted(values[key], 2));
      next(key);
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }

  function onBoxKeyDown(event: KeyboardEvent<HTMLElement>, key: Stop) {
    if (event.key === 'F1') {
      if (key === 'name') {
        event.preventDefault();
        return void openHelp('names', 'open', 'name');
      }
      if (key === 'short' && admin) {
        event.preventDefault();
        return void openHelp('short', 'view', 'short');
      }
    }
    if (event.key !== 'Enter') return;
    event.preventDefault();
    void onEnter(key);
  }

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const toSearch = () => {
    setTyping(false);
    setSearch((s) => (s === M.SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_ACCT_KeyDown with KeyPreview: Ctrl+E unlocks the code box, Esc leaves the screen. */
  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented) return;
    if (event.ctrlKey && (event.key === 'e' || event.key === 'E')) {
      event.preventDefault();
      setCodeLocked(false);
      setTimeout(() => focus('code'), 0);
    } else if (event.key === 'Escape') {
      event.preventDefault();
      if (zoom) setZoom(false);
      else if (help) closeHelp();
      else if (printRows) setPrintRows(null);
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
      setSearch((s) => (s === M.SEARCH_TEXT ? s : s.slice(0, -1)));
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

  function onHelpKeyDown(event: KeyboardEvent<HTMLElement>) {
    if (!help) return;
    if (event.key === 'ArrowDown' || event.key === 'ArrowUp') {
      event.preventDefault();
      setHelpAt((at) =>
        Math.max(0, Math.min(helpRows.length - 1, at + (event.key === 'ArrowDown' ? 1 : -1))),
      );
    } else if (event.key === 'Enter') {
      event.preventDefault();
      const row = helpRows[helpAt];
      if (row && help.target !== 'view') void pick(row);
      else closeHelp();
    } else if (event.key === 'Escape') {
      event.preventDefault();
      event.stopPropagation();
      closeHelp();
    }
  }

  async function savePhoto(file: File | undefined) {
    if (!file) return;
    if (!/^image\/(jpeg|jpg|png)$/.test(file.type))
      return setMsg({ kind: 'err', text: 'Please pick a JPEG image.' });
    const dataUrl = await new Promise<string>((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = () => resolve(String(reader.result ?? ''));
      reader.onerror = () => reject(reader.error);
      reader.readAsDataURL(file);
    });
    try {
      await post(`/masters/party-master/${encodeURIComponent(code.trim())}/photo`, { dataUrl });
      setPhoto(dataUrl);
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }
  async function deletePhoto() {
    if (!photo || !window.confirm(M.PHOTO_DELETE_CONFIRM)) return;
    try {
      await post(`/masters/party-master/${encodeURIComponent(code.trim())}/photo/delete`, {});
      setPhoto(null);
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }

  const ref =
    (stop: Stop | 'lastVisit' | 'ledgerDate') =>
    (el: HTMLInputElement | HTMLSelectElement | null) => {
      boxes.current[stop] = el;
    };
  const field = (b: Box) =>
    b.select ? (
      <select
        id={`party-${b.key}`}
        ref={ref(b.key)}
        aria-label={b.label}
        value={values[b.key]}
        style={{ width: b.width }}
        onChange={(e) => set(b.key, e.target.value)}
        onKeyDown={(event) => onBoxKeyDown(event, b.key)}
      >
        {b.select.map(([value, label]) => (
          <option key={value} value={value}>
            {label}
          </option>
        ))}
      </select>
    ) : (
      <input
        id={`party-${b.key}`}
        ref={ref(b.key)}
        aria-label={b.label}
        value={values[b.key]}
        maxLength={b.date ? 10 : b.max}
        readOnly={b.readOnly}
        tabIndex={b.readOnly ? -1 : undefined}
        placeholder={b.date ? 'DD/MM/YYYY' : undefined}
        list={b.combo ? `party-${b.combo}` : undefined}
        style={{ width: b.width }}
        onChange={(e) => {
          const raw = e.target.value;
          const value = b.date
            ? maskDate(raw)
            : b.key === 'email'
              ? raw.toLowerCase().replace(/'/g, '')
              : typed(raw);
          set(b.key, value);
          if (b.key === 'name') setTyping(true);
          if (b.key === 'group') setGroupName('');
        }}
        onBlur={b.key === 'name' ? () => void nameFree() : undefined}
        onKeyDown={(event) => onBoxKeyDown(event, b.key)}
      />
    );
  const rows = (fields: Box[][]) =>
    fields.map((row) => (
      <div
        key={row[0]!.key}
        className="row"
        style={{ alignItems: 'center', gap: 6, marginBottom: 5 }}
      >
        {row.map((b, i) => (
          <span key={b.key} className="row" style={{ alignItems: 'center', gap: 6 }}>
            {b.key === 'mainGroup' ? (
              <input
                aria-label="Ac Group Name"
                value={groupName}
                readOnly
                tabIndex={-1}
                style={{ width: 197 }}
              />
            ) : null}
            {b.key !== 'mainGroup' && b.key !== 'acType' && b.key !== 'gstType' && (
              <label
                htmlFor={`party-${b.key}`}
                style={{ width: i === 0 ? 96 : undefined, marginLeft: i === 0 ? 0 : 8 }}
              >
                {b.key === 'refName' ? '' : b.label}
              </label>
            )}
            {field(b)}
          </span>
        ))}
      </div>
    ));
  const sign = (key: 'opSign' | 'opGoldSign' | 'opSilverSign', field: keyof Opening) => (
    <select
      ref={ref(key)}
      aria-label={`${key === 'opSign' ? 'Amount' : key === 'opGoldSign' ? 'Gold' : 'Silver'} Cr/Dr`}
      value={opening[field]}
      disabled={entryMode === 'E'}
      onChange={(e) => setOpening((o) => ({ ...o, [field]: e.target.value as 'C' | 'D' }))}
      onKeyDown={(event) => onBoxKeyDown(event, key)}
    >
      <option value="C">Cr</option>
      <option value="D">Dr</option>
    </select>
  );
  const openingBox = (
    key: 'opAmount' | 'opGold' | 'opSilver',
    field: keyof Opening,
    max: number,
  ) => (
    <input
      ref={ref(key)}
      aria-label={key === 'opAmount' ? 'Amount' : key === 'opGold' ? 'Gold' : 'Silver'}
      value={opening[field]}
      maxLength={max}
      readOnly={entryMode === 'E'}
      inputMode="decimal"
      style={{ width: 110, textAlign: 'right' }}
      onChange={(e) =>
        setOpening((o) => ({ ...o, [field]: e.target.value.replace(/[^0-9.]/g, '') }))
      }
      onKeyDown={(event) => onBoxKeyDown(event, key)}
    />
  );
  const custLine = values.name.trim()
    ? `${code} - ${values.name}  ( Mo - ${values.mobile} )`
    : M.RECORD_TEXT;

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Party Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      {(Object.keys(combos) as Combo[]).map((name) => (
        <datalist key={name} id={`party-${name}`}>
          {/* The states list keeps the desktop's UNION ALL, so a state can appear twice (:7114). */}
          {combos[name].filter(Boolean).map((v, i) => (
            <option key={`${v}-${i}`} value={v} />
          ))}
        </datalist>
      ))}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '460px minmax(600px, 1fr)',
          gridTemplateAreas: '"left fields" "left buttons"',
          gap: '10px 24px',
          alignItems: 'start',
        }}
      >
        <div style={{ gridArea: 'left', width: 460, display: 'grid', gap: 10 }}>
          <div className="panel">
            <input
              ref={searchRef}
              aria-label="Search name or mobile"
              value={search}
              onFocus={() => {
                setTyping(false);
                setSearch((s) => (s === M.SEARCH_TEXT ? '' : s));
              }}
              onChange={(e) => {
                setSearch(typed(e.target.value));
                setCurrent(0);
              }}
              style={{ width: '100%' }}
            />
            <div style={{ maxHeight: 290, overflowY: 'auto', marginTop: 6 }}>
              <table className="grid">
                <thead>
                  <tr>
                    <th style={{ width: 80 }}>Code</th>
                    <th>Name</th>
                    <th style={{ width: 110 }}>Mobile</th>
                  </tr>
                </thead>
                <tbody ref={listRef} data-testid="party-list" onKeyDown={onListKeyDown}>
                  {shown.map((row, i) => (
                    <tr
                      key={`${row.lc}-${row.code}`}
                      tabIndex={0}
                      aria-selected={i === current}
                      data-code={row.code}
                      className={i === current ? 'selected' : undefined}
                      onFocus={() => setCurrent(i)}
                      onDoubleClick={() => void open(row.code)}
                    >
                      <td>{row.code}</td>
                      <td>{row.name}</td>
                      <td>{row.mobile}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
          <div className="row" style={{ gap: 16, alignItems: 'flex-start' }}>
            <div>
              <div
                data-testid="party-photo"
                onDoubleClick={() => photo && setZoom(true)}
                style={{
                  width: 178,
                  height: 146,
                  border: '1px solid var(--border, #ccc)',
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'center',
                  overflow: 'hidden',
                }}
              >
                {photo ? (
                  <img
                    src={photo}
                    alt="Party photo"
                    style={{ maxWidth: '100%', maxHeight: '100%' }}
                  />
                ) : (
                  <span className="muted">No photo</span>
                )}
              </div>
              <div className="row" style={{ gap: 6, marginTop: 6, justifyContent: 'center' }}>
                <button
                  type="button"
                  className="ghost"
                  tabIndex={-1}
                  aria-label="Take photo"
                  onClick={() => cameraInput.current?.click()}
                >
                  📷
                </button>
                <button
                  type="button"
                  className="ghost"
                  tabIndex={-1}
                  aria-label="Select photo"
                  onClick={() => photoInput.current?.click()}
                >
                  📂
                </button>
                <button
                  type="button"
                  className="ghost"
                  tabIndex={-1}
                  aria-label="Delete photo"
                  onClick={() => void deletePhoto()}
                >
                  ✖
                </button>
              </div>
              <input
                ref={photoInput}
                type="file"
                accept="image/jpeg"
                hidden
                onChange={(e) => {
                  void savePhoto(e.target.files?.[0]);
                  e.target.value = '';
                }}
              />
              <input
                ref={cameraInput}
                type="file"
                accept="image/jpeg"
                capture="user"
                hidden
                onChange={(e) => {
                  void savePhoto(e.target.files?.[0]);
                  e.target.value = '';
                }}
              />
            </div>
            <div>
              <fieldset style={{ width: 250, boxSizing: 'border-box', margin: 0 }}>
                <legend>Oppning Balance</legend>
                {(
                  [
                    ['opAmount', 'amount', 'Amount', 'opSign', 'sign', 8],
                    ['opGold', 'gold', 'Gold', 'opGoldSign', 'goldSign', 12],
                    ['opSilver', 'silver', 'Silver', 'opSilverSign', 'silverSign', 12],
                  ] as const
                ).map(([key, field, label, signKey, signField, max]) => (
                  <div
                    key={key}
                    className="row"
                    style={{ gap: 6, alignItems: 'center', marginBottom: 4 }}
                  >
                    <span style={{ width: 50 }}>{label}</span>
                    {openingBox(key, field, max)}
                    {sign(signKey, signField)}
                  </div>
                ))}
              </fieldset>
              {(
                [
                  ['lastVisit', 'Last Visit'],
                  ['ledgerDate', 'Ledger Date'],
                ] as const
              ).map(([key, label]) => (
                <div
                  key={key}
                  className="row"
                  style={{ gap: 6, alignItems: 'center', marginTop: 6 }}
                >
                  <label htmlFor={`party-${key}`} style={{ width: 90, textAlign: 'right' }}>
                    {label}
                  </label>
                  <input
                    id={`party-${key}`}
                    ref={ref(key)}
                    value={values[key]}
                    maxLength={10}
                    placeholder="DD/MM/YYYY"
                    style={{ width: 90 }}
                    onChange={(e) => set(key, maskDate(e.target.value))}
                    onKeyDown={(event) => {
                      // mLastVisit_KeyDown and MLdrDate_KeyDown go to Save (:8371-8386, :8479-8494).
                      if (event.key !== 'Enter') return;
                      event.preventDefault();
                      saveRef.current?.focus();
                    }}
                  />
                </div>
              ))}
            </div>
          </div>
        </div>
        <div className="panel" style={{ gridArea: 'fields', minWidth: 600 }}>
          <input
            aria-label="Customer detail"
            data-testid="party-cust-detail"
            value={custLine}
            readOnly
            tabIndex={-1}
            style={{ width: '100%', marginBottom: 8 }}
          />
          {/* The selected tab is not a `primary` button: Save is the screen's main action. */}
          <div
            role="tablist"
            aria-label="Party details"
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
            <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 6 }}>
              <label htmlFor="party-code" style={{ width: 96 }}>
                Ac Code
              </label>
              <input
                id="party-code"
                ref={ref('code')}
                value={code}
                maxLength={8}
                readOnly={codeLocked}
                style={{ width: 90, background: codeLocked ? undefined : 'mistyrose' }}
                onChange={(e) => setCode(typed(e.target.value))}
                onBlur={() => void codeFree()}
                onKeyDown={(event) => onBoxKeyDown(event, 'code')}
              />
              <button
                type="button"
                className="ghost"
                tabIndex={-1}
                onClick={() => void openHelp('f1', 'open', 'name')}
              >
                F1
              </button>
              <span style={{ flex: 1 }} />
              {(
                [
                  ['account', 'A', 'Copy another account'],
                  ['address', 'D', 'Copy an address'],
                  ['member', 'S', 'Copy a scheme member'],
                ] as const
              ).map(([kind, caption, title]) => (
                <button
                  key={kind}
                  type="button"
                  className="ghost"
                  tabIndex={-1}
                  title={title}
                  aria-label={title}
                  onClick={() => void openHelp(kind, 'copy', 'name')}
                >
                  {caption}
                </button>
              ))}
            </div>
            {rows(COMPANY_ROWS)}
          </div>
          <div role="tabpanel" hidden={tab !== 'other'}>
            {rows(OTHER_ROWS)}
            {FLAGS.map(([key, label]) => (
              <label key={key} className="row" style={{ gap: 6, marginLeft: 102, marginTop: 4 }}>
                <input
                  type="checkbox"
                  checked={values[key]}
                  onChange={(e) => setFlag(key, e.target.checked)}
                />
                {label}
              </label>
            ))}
          </div>
          <div role="tabpanel" hidden={tab !== 'family'} />
          {help && (
            <section
              className="panel"
              aria-label="Party help"
              style={{ marginTop: 8 }}
              onKeyDown={onHelpKeyDown}
            >
              <input
                ref={helpFilterRef}
                autoFocus
                aria-label="Help search"
                value={helpFilter}
                onChange={(e) => {
                  setHelpFilter(typed(e.target.value));
                  setHelpAt(0);
                }}
                style={{ width: 240, marginBottom: 6 }}
              />
              <div style={{ maxHeight: 260, overflowY: 'auto' }}>
                <table className="grid">
                  <thead>
                    <tr>
                      {HELP_COLUMNS[help.kind]
                        .filter(([key]) => key !== 'short' || help.kind !== 'f1' || admin)
                        .map(([key, title]) => (
                          <th key={key}>{title}</th>
                        ))}
                    </tr>
                  </thead>
                  <tbody data-testid="party-help">
                    {helpRows.map((row, i) => (
                      <tr
                        key={`${row.code ?? row.short}-${row.scheme ?? ''}-${i}`}
                        data-code={row.code ?? row.short}
                        className={i === helpAt ? 'selected' : undefined}
                        onClick={() => setHelpAt(i)}
                        onDoubleClick={() =>
                          help.target === 'view' ? closeHelp() : void pick(row)
                        }
                      >
                        {HELP_COLUMNS[help.kind]
                          .filter(([key]) => key !== 'short' || help.kind !== 'f1' || admin)
                          .map(([key]) => (
                            <td key={key}>{row[key]}</td>
                          ))}
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </section>
          )}
        </div>
        <div className="row" style={{ gridArea: 'buttons', gap: 8, justifyContent: 'flex-end' }}>
          <button type="button" className="ghost" disabled={busy} onClick={() => void print()}>
            Print
          </button>
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
      </div>
      {zoom && photo && (
        <div
          role="dialog"
          aria-label="Party photo zoom"
          onDoubleClick={() => setZoom(false)}
          style={{
            position: 'fixed',
            inset: 0,
            background: 'rgba(0,0,0,0.6)',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            zIndex: 50,
          }}
        >
          <img
            src={photo}
            alt="Party photo, large"
            style={{ maxWidth: '80vw', maxHeight: '80vh' }}
          />
        </div>
      )}
      {printRows && (
        <section className="panel" data-testid="party-print" aria-label="Party Master print">
          <div className="row" style={{ justifyContent: 'space-between' }}>
            <h2 style={{ margin: 0 }}>Party Master</h2>
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
                <th>Group</th>
                <th>Address</th>
                <th>City</th>
                <th>Mobile No</th>
                <th>Gst No</th>
              </tr>
            </thead>
            <tbody>
              {printRows.map((row, i) => (
                <tr key={`${row.code}-${i}`}>
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                  <td>{row.group}</td>
                  <td>{row.address}</td>
                  <td>{row.city}</td>
                  <td>{row.mobile}</td>
                  <td>{row.gstNo}</td>
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
