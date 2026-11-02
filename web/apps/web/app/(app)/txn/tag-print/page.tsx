'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { get, post, ApiError } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Tag Print (desktop UT_TAG_PRINT, Other → Tag Print; MDI_FORM.cs:8596-8605), laid out as its form spec
 * (`web/apps/api/form-specs/UT_TAG_PRINT.initcomp.json`): Book, Vch No with F1, Gr Code and Pr Code with Item Type, the
 * Hm Id Update box and the Print file with Set over the tag grid; Item Name and Lable Skip under it; Print, Save, Cancel,
 * Delete and Exit along the bottom.
 *
 * - The grid is filled from a voucher (Book and Vch No, Enter; a blank Vch No goes to the grid) or from the stock (Gr
 *   Code and Pr Code, Enter, filtered by the Item Type), every row marked Y (tVchNo_KeyDown :5284-5403, MSG_VCH_FILL
 *   :5575-5635). A tag typed in the TagNo column is looked up in the stock; one already in the grid says "Duplicate Tag
 *   No"; an unknown tag opens the tag help (:4102-4420). Y/N toggles a row; Ctrl+D removes a row after "This Row Record
 *   will Removed permantley ?" (:3532-3561). F1 on Vch No, Gr Code, Pr Code and TagNo opens their helps.
 * - Print (BtnPrint_Click :5122-5226) needs the print right ("You Have No Print Rights....."), stages the Y rows after the
 *   Lable Skip blanks and shows the label sheet. With Hm Id Update ticked the grid shows the four HM ids and weights,
 *   Lbr%, LRate and Mrp for editing, and Print first says "Please First Update Hmid Data and Then print"; Save writes them
 *   back to BAR_DETL and then prints (:5073-5096). Set makes the chosen label file the default (:5636-5655).
 *
 * Deliberate differences: Print shows the web's label sheet because the Crystal label files are not in the repository; a
 * blank Gr Code or Pr Code goes on / loads the stock (the desktop opens the help); F1 keeps the Book (the desktop's
 * CLEAR_DATA clears it); the typed cells of ItCode, Counter and GrWt are not editable because a label is copied from
 * BAR_DETL; Delete does nothing, as the desktop's empty BtnDelete_Click; Save outside Hm Id Update says so (the desktop
 * does nothing); the RFID button, the Print Type box and the QR picture (named registrations only) are left out.
 */
const M = {
  NO_PRINT_RIGHTS: 'You Have No Print Rights.....',
  NO_RIGHTS: 'You Have No Rights.....',
  HM_FIRST: 'Please First Update Hmid Data and Then print',
  DUPLICATE: 'Duplicate Tag No',
  REMOVE: 'This Row Record will Removed permantley ?',
  SAVE_HM_ONLY: 'Save writes the Hm Id data only; tick Hm Id Update to change it.',
  NOTHING: 'Please select the tags to print (Y) and try.',
  DELETE_NONE: 'Delete does nothing on this screen.',
} as const;

interface Row {
  tagNo: string;
  itCode: string;
  itName: string;
  counter: string;
  design: string;
  size: string;
  lCode: string;
  bagWt: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  ghatWt: string;
  touch: string;
  wastage: string;
  fine: string;
  lbrPrc: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  mrp: string;
  krCode: string;
  vchSrno: number;
  hmIds: [string, string, string, string];
  hmWts: [string, string, string, string];
}
interface GridRow extends Row {
  y: boolean;
}
interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
type HelpKind = 'vouchers' | 'books' | 'groups' | 'products' | 'tags';
interface HelpState {
  kind: HelpKind;
  rows: Array<Record<string, string>>;
  at: number;
}
const HELP_COLUMNS: Record<HelpKind, Array<[string, string]>> = {
  vouchers: [
    ['vchNo', 'VchNoL'],
    ['vchDate', 'VchDateL'],
    ['party', 'PartyNameL'],
  ],
  books: [
    ['name', 'BookNameL'],
    ['code', 'BookL'],
  ],
  groups: [
    ['name', 'GrNameL'],
    ['code', 'GrCodeL'],
    ['type', 'TypeL'],
    ['trade', 'TradTypeL'],
  ],
  products: [
    ['name', 'PrNameL'],
    ['code', 'PrCodeL'],
  ],
  tags: [
    ['tagNo', 'TagNoL'],
    ['itName', 'ItNameL'],
    ['itCode', 'ItCodeL'],
    ['design', 'DesignNoL'],
    ['grossWt', 'GrWtW'],
    ['netWt', 'NetWtW'],
    ['mrp', 'MrpR'],
  ],
};

/** The grid's columns in the desktop's column order (MSG_CLEAR :1816-2077), per mode. */
type Col = { key: string; title: string; width: number; align?: 'right' };
const col = (key: string, title: string, width: number, align?: 'right'): Col => ({
  key,
  title,
  width,
  align,
});
const NORMAL_COLS: Col[] = [
  col('sr', 'Sr', 40),
  col('y', 'Y/N', 52),
  col('tagNo', 'TagNo', 110),
  col('itCode', 'ItCode', 80),
  col('counter', 'Counter', 72),
  col('design', 'Design', 100),
  col('size', 'Size', 60),
  col('pcs', 'Pcs', 52, 'right'),
  col('grossWt', 'GrWt', 80, 'right'),
  col('netWt', 'NetWt', 80, 'right'),
  col('ghatWt', 'GhtWt', 70, 'right'),
  col('touch', 'Touch', 70, 'right'),
  col('wastage', 'West%', 70, 'right'),
  col('fine', 'Fine', 80, 'right'),
  col('lCode', 'LCode', 64),
  col('lbrRate', 'LbrRate', 72, 'right'),
  col('lbrAmt', 'LbrAmt', 76, 'right'),
  col('othAmt', 'OthAmt', 80, 'right'),
  col('mrp', 'Mrp', 72, 'right'),
  col('krCode', 'KrCode', 72),
];
const HM_COLS: Col[] = [
  ...NORMAL_COLS.slice(0, 9),
  col('hmId0', 'HmId', 84),
  col('hmWt0', 'HmWt', 76, 'right'),
  col('hmId1', 'HmId2', 84),
  col('hmWt1', 'HmWt2', 76, 'right'),
  col('hmId2', 'HmId3', 84),
  col('hmWt2', 'HmWt3', 76, 'right'),
  col('hmId3', 'HmId4', 84),
  col('hmWt3', 'HmWt4', 76, 'right'),
  col('lCode', 'LCode', 64),
  col('lbrRate', 'LRate', 76, 'right'),
  col('mrp', 'Mrp', 88, 'right'),
  col('krCode', 'KrCode', 72),
  col('lbrPrc', 'Lbr%', 76, 'right'),
];
const HM_EDITABLE = new Set([
  'hmId0',
  'hmWt0',
  'hmId1',
  'hmWt1',
  'hmId2',
  'hmWt2',
  'hmId3',
  'hmWt3',
  'lbrRate',
  'mrp',
  'lbrPrc',
]);

const blankRow = (): GridRow => ({
  y: true,
  tagNo: '',
  itCode: '',
  itName: '',
  counter: '',
  design: '',
  size: '',
  lCode: '',
  bagWt: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  ghatWt: '',
  touch: '',
  wastage: '',
  fine: '',
  lbrPrc: '',
  lbrType: '',
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  mrp: '',
  krCode: '',
  vchSrno: 0,
  hmIds: ['', '', '', ''],
  hmWts: ['', '', '', ''],
});
/** MS_ACCT-style KeyPress: every typed key upper-cased. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function TagPrintPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [files, setFiles] = useState<string[]>([]);
  const [file, setFile] = useState('');
  const [itemTypes, setItemTypes] = useState<string[]>([]);
  const [itemType, setItemType] = useState('');
  const [rights, setRights] = useState<Rights | null>(null);
  const [book, setBook] = useState('');
  const [bookName, setBookName] = useState('');
  const [vchNo, setVchNo] = useState('');
  const [group, setGroup] = useState('');
  const [groupName, setGroupName] = useState('');
  const [product, setProduct] = useState('');
  const [productName, setProductName] = useState('');
  const [hm, setHm] = useState(false);
  const [hmDone, setHmDone] = useState(false);
  const [skip, setSkip] = useState('');
  const [rows, setRows] = useState<GridRow[]>([blankRow()]);
  const [current, setCurrent] = useState(0);
  const [help, setHelp] = useState<HelpState | null>(null);
  const [helpFilter, setHelpFilter] = useState('');
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const refs = useRef<Record<string, HTMLElement | null>>({});
  const helpBack = useRef<string>('book');
  const defaultType = useRef('');

  /** Focus a box now, or as soon as a render has created it (the grid's cells exist only after the rows are set). */
  const pendingFocus = useRef<string | null>(null);
  const applyFocus = useCallback(() => {
    const id = pendingFocus.current;
    const el = id ? refs.current[id] : null;
    if (!id || !el) return;
    el.focus();
    // A disabled button (a print in progress) cannot take it yet; the next render tries again.
    if (document.activeElement !== el) return;
    pendingFocus.current = null;
    if (el instanceof HTMLInputElement) el.select();
  }, []);
  const focus = useCallback(
    (id: string) => {
      pendingFocus.current = id;
      setTimeout(applyFocus, 0);
    },
    [applyFocus],
  );
  useEffect(() => {
    applyFocus();
  });
  const reg = (id: string) => (el: HTMLElement | null) => {
    refs.current[id] = el;
  };

  /** Load: the label files, the default file and the item type. */
  useEffect(() => {
    void (async () => {
      try {
        const s = await get<{
          files: string[];
          defaultFile: string;
          itemTypes: string[];
          itemType: string;
          rights: Rights;
        }>('/stock/tag-print-screen');
        setFiles(s.files);
        setFile(s.defaultFile);
        setItemTypes(s.itemTypes);
        setItemType(s.itemType);
        defaultType.current = s.itemType;
        setRights(s.rights);
      } catch (error) {
        setMsg({
          kind: 'err',
          text: error instanceof ApiError && error.status === 403 ? M.NO_RIGHTS : messageOf(error),
        });
      }
      focus('book');
    })();
  }, [focus]);

  /** CLEAR_DATA / Cancel: blank boxes and grid, the cursor in Vch No. */
  function clear() {
    setBook('');
    setBookName('');
    setVchNo('');
    setGroup('');
    setGroupName('');
    setProduct('');
    setProductName('');
    setHm(false);
    setHmDone(false);
    setSkip('');
    setRows([blankRow()]);
    setCurrent(0);
    setHelp(null);
    setMsg(null);
    setItemType(defaultType.current);
    focus('book');
  }

  const cols = hm ? HM_COLS : NORMAL_COLS;
  // A typed tag that was not found has no ItCode and is not a row to print.
  const filled = useMemo(() => rows.filter((r) => r.tagNo && r.itCode), [rows]);
  const itemName = rows[current]?.itName ?? '';

  function setRowsFrom(list: Row[]) {
    const next: GridRow[] = list.map((r) => ({ ...r, y: true }));
    next.push(blankRow());
    setRows(next);
    setCurrent(0);
    setHmDone(false);
  }

  async function openHelp(kind: HelpKind, back: string, query = '') {
    try {
      const path =
        kind === 'vouchers'
          ? `/stock/tag-print-screen/vouchers?bookCode=${encodeURIComponent(book)}`
          : kind === 'books'
            ? '/stock/tag-print-screen/books'
            : kind === 'tags'
              ? '/stock/tag-print-screen/tags'
              : `/stock/tag-print-screen/lookups/${kind}`;
      const r = await get<{ rows: Array<Record<string, string>> }>(path);
      helpBack.current = back;
      setHelpFilter(query);
      setHelp({ kind, rows: r.rows, at: 0 });
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }
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
    setHelp(null);
    focus(helpBack.current);
  }
  async function pickHelp(row: Record<string, string>) {
    if (!help) return;
    const { kind } = help;
    setHelp(null);
    if (kind === 'vouchers') {
      setVchNo(row.vchNo ?? '');
      return focus('vchNo');
    }
    if (kind === 'books') {
      setBook(row.code ?? '');
      setBookName(row.name ?? '');
      return focus('book');
    }
    if (kind === 'groups') {
      setGroup(row.code ?? '');
      setGroupName(row.name ?? '');
      return focus('product');
    }
    if (kind === 'products') {
      setProduct(row.code ?? '');
      setProductName(row.name ?? '');
      return focus('product');
    }
    await addTag(row.tagNo ?? '');
  }

  /** tBookCode_KeyDown (:5439-5482). */
  async function onBookEnter() {
    setMsg(null);
    if (!book.trim()) return focus('vchNo');
    try {
      const { book: found } = await get<{ book: { code: string; name: string } | null }>(
        `/stock/tag-print-screen/book?code=${encodeURIComponent(book.trim())}`,
      );
      if (!found) return void openHelp('books', 'book');
      setBook(found.code);
      setBookName(found.name);
      focus('vchNo');
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }
  /** tVchNo_KeyDown (:5284-5403). */
  async function onVchEnter() {
    setMsg(null);
    if (!vchNo.trim()) return focus(`cell-${current}-tagNo`);
    try {
      const r = await get<{ rows: Row[] }>(
        `/stock/tag-print-screen/voucher?bookCode=${encodeURIComponent(book.trim())}&vchNo=${encodeURIComponent(vchNo.trim())}`,
      );
      if (!r.rows.length) return void openHelp('vouchers', 'vchNo');
      setRowsFrom(r.rows);
      focus('cell-0-y');
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }
  /** tGrCode_KeyDown (:5499-5537). */
  async function onGroupEnter() {
    setMsg(null);
    if (!group.trim()) return focus('product');
    try {
      const r = await get<{ rows: Array<{ code: string; name: string }> }>(
        '/stock/tag-print-screen/lookups/groups',
      );
      const found = r.rows.find((g) => g.code.toUpperCase() === group.trim().toUpperCase());
      if (!found) return void openHelp('groups', 'group');
      setGroupName(found.name);
      focus('product');
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }
  /** tPrCode_KeyDown (:5538-5574): a known product (or none) fills the grid from the stock. */
  async function onProductEnter() {
    setMsg(null);
    try {
      if (product.trim()) {
        const r = await get<{ rows: Array<{ code: string; name: string }> }>(
          '/stock/tag-print-screen/lookups/products',
        );
        const found = r.rows.find((p) => p.code.toUpperCase() === product.trim().toUpperCase());
        if (!found) return void openHelp('products', 'product');
        setProductName(found.name);
      }
      const q = new URLSearchParams({ group: group.trim(), product: product.trim(), itemType });
      const stock = await get<{ rows: Row[] }>(`/stock/tag-print-screen/stock?${q}`);
      setRowsFrom(stock.rows);
      focus('cell-0-y');
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }

  /** The TagNo column's Enter (:4102-4420): add the tag to the grid. */
  async function addTag(tagRaw: string) {
    const tagNo = typed(tagRaw).trim();
    setMsg(null);
    if (!tagNo) return;
    if (rows.some((r, i) => i !== current && r.tagNo === tagNo)) {
      setMsg({ kind: 'err', text: M.DUPLICATE });
      setRows((list) => list.map((r, i) => (i === current ? { ...r, tagNo: '' } : r)));
      focus(`cell-${current}-tagNo`);
      return;
    }
    try {
      const { row } = await get<{ row: Row | null }>(
        `/stock/tag-print-screen/tag?tagNo=${encodeURIComponent(tagNo)}`,
      );
      if (!row) return void openHelp('tags', `cell-${current}-tagNo`);
      setRows((list) => {
        const next = list.map((r, i) => (i === current ? { ...row, y: true } : r));
        if (current === next.length - 1) next.push(blankRow());
        return next;
      });
      setCurrent(current + 1);
      setHmDone(false);
      focus(`cell-${current + 1}-tagNo`);
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }

  function removeRow(index: number) {
    if (!rows[index]?.tagNo) return;
    if (!window.confirm(M.REMOVE)) return;
    setRows((list) => {
      const next = list.filter((_, i) => i !== index);
      return next.length && !next[next.length - 1]!.tagNo ? next : [...next, blankRow()];
    });
    setCurrent(Math.max(0, index - 1));
    setHmDone(false);
  }

  function setCell(index: number, key: string, value: string) {
    setHmDone(false);
    setRows((list) =>
      list.map((r, i) => {
        if (i !== index) return r;
        const m = /^(hmId|hmWt)(\d)$/.exec(key);
        if (m) {
          const arr = [...(m[1] === 'hmId' ? r.hmIds : r.hmWts)] as [
            string,
            string,
            string,
            string,
          ];
          arr[Number(m[2])] = m[1] === 'hmId' ? typed(value) : value.replace(/[^0-9.]/g, '');
          return m[1] === 'hmId' ? { ...r, hmIds: arr } : { ...r, hmWts: arr };
        }
        return { ...r, [key]: key === 'tagNo' ? typed(value) : value.replace(/[^0-9.]/g, '') };
      }),
    );
  }

  function onCellKeyDown(event: KeyboardEvent<HTMLElement>, index: number, key: string) {
    if (event.ctrlKey && (event.key === 'd' || event.key === 'D')) {
      event.preventDefault();
      return removeRow(index);
    }
    if (event.key === 'F1' && key === 'tagNo') {
      event.preventDefault();
      setCurrent(index);
      return void openHelp('tags', `cell-${index}-tagNo`);
    }
    if (key === 'y') {
      if (event.key === 'y' || event.key === 'Y' || event.key === 'n' || event.key === 'N') {
        event.preventDefault();
        const on = event.key.toLowerCase() === 'y';
        setRows((list) => list.map((r, i) => (i === index ? { ...r, y: on } : r)));
      } else if (event.key === ' ') {
        event.preventDefault();
        setRows((list) => list.map((r, i) => (i === index ? { ...r, y: !r.y } : r)));
      }
    }
    if (event.key === 'ArrowDown' && index < rows.length - 1) {
      event.preventDefault();
      setCurrent(index + 1);
      return focus(`cell-${index + 1}-${key}`);
    }
    if (event.key === 'ArrowUp' && index > 0) {
      event.preventDefault();
      setCurrent(index - 1);
      return focus(`cell-${index - 1}-${key}`);
    }
    if (event.key !== 'Enter') return;
    event.preventDefault();
    if (key === 'tagNo') {
      if (rows[index]!.tagNo && rows[index]!.itCode) {
        // An existing row: on to the next row's TagNo.
        if (index < rows.length - 1) {
          setCurrent(index + 1);
          return focus(`cell-${index + 1}-tagNo`);
        }
        return focus('print');
      }
      setCurrent(index);
      return void addTag(rows[index]!.tagNo);
    }
    const editable = cols.filter(
      (c) => c.key === 'y' || c.key === 'tagNo' || (hm && HM_EDITABLE.has(c.key)),
    );
    const at = editable.findIndex((c) => c.key === key);
    const nextCol = editable[at + 1];
    if (nextCol) return focus(`cell-${index}-${nextCol.key}`);
    if (index < rows.length - 1) {
      setCurrent(index + 1);
      return focus(`cell-${index + 1}-${editable[0]!.key}`);
    }
    focus(hm ? 'save' : 'print');
  }

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);

  async function stageAndShow() {
    const tags = filled.filter((r) => r.y).map((r) => ({ tagNo: r.tagNo, vchSrno: r.vchSrno }));
    if (!tags.length && !Number(skip)) return setMsg({ kind: 'err', text: M.NOTHING });
    await post('/stock/tag-print-screen/print', { bookCode: book.trim(), labelSkip: skip, tags });
    openDocument('/api/stock/tag-print-screen/labels');
  }
  /** BtnPrint_Click (:5122-5226). */
  async function print() {
    setMsg(null);
    if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: M.NO_PRINT_RIGHTS });
    if (hm && !hmDone) {
      setMsg({ kind: 'err', text: M.HM_FIRST });
      return focus('save');
    }
    setBusy(true);
    try {
      await stageAndShow();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, M.NO_PRINT_RIGHTS) });
    } finally {
      setBusy(false);
      focus('print');
    }
  }
  /** BtnSave_Click (:5073-5096): only with Hm Id Update ticked. */
  async function save() {
    setMsg(null);
    if (!hm) return setMsg({ kind: 'err', text: M.SAVE_HM_ONLY });
    if (rights && !rights.canUpdate) return setMsg({ kind: 'err', text: M.NO_RIGHTS });
    setBusy(true);
    try {
      await post('/stock/tag-print-screen/hm-update', {
        rows: filled.map((r) => ({
          tagNo: r.tagNo,
          vchSrno: r.vchSrno,
          hmIds: r.hmIds,
          hmWts: r.hmWts,
          lbrPrc: r.lbrPrc,
          mrp: r.mrp,
          lbrRate: r.lbrRate,
        })),
      });
      setHmDone(true);
      if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: M.NO_PRINT_RIGHTS });
      await stageAndShow();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, M.NO_RIGHTS) });
    } finally {
      setBusy(false);
      focus('print');
    }
  }
  /** BtnTagSet_Click (:5636-5655). */
  async function setDefault() {
    setMsg(null);
    if (rights && !rights.canUpdate) return setMsg({ kind: 'err', text: M.NO_RIGHTS });
    try {
      await post('/stock/tag-print-screen/default-file', { file });
      setMsg({ kind: 'ok', text: `${file} is the default label file.` });
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, M.NO_RIGHTS) });
    }
  }

  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented) return;
    if (event.key === 'Escape') {
      event.preventDefault();
      if (help) closeHelp();
      else router.back();
    }
  }
  function onHelpKeyDown(event: KeyboardEvent<HTMLElement>) {
    if (!help) return;
    if (event.key === 'ArrowDown' || event.key === 'ArrowUp') {
      event.preventDefault();
      const at = Math.max(
        0,
        Math.min(helpRows.length - 1, help.at + (event.key === 'ArrowDown' ? 1 : -1)),
      );
      setHelp({ ...help, at });
    } else if (event.key === 'Enter') {
      event.preventDefault();
      const row = helpRows[help.at];
      if (row) void pickHelp(row);
      else closeHelp();
    } else if (event.key === 'Escape') {
      event.preventDefault();
      event.stopPropagation();
      closeHelp();
    }
  }

  const input = (
    id: string,
    label: string,
    value: string,
    set: (v: string) => void,
    width: number,
    onEnter?: () => void,
    help?: () => void,
    max?: number,
  ) => (
    <input
      id={`tp-${id}`}
      ref={reg(id)}
      aria-label={label}
      value={value}
      maxLength={max}
      style={{ width }}
      onChange={(e) => set(typed(e.target.value))}
      onKeyDown={(e) => {
        if (e.key === 'F1' && help) {
          e.preventDefault();
          return help();
        }
        if (e.key === 'Enter' && onEnter) {
          e.preventDefault();
          onEnter();
        }
      }}
    />
  );
  const label = (text: string, htmlFor: string, width = 70) => (
    <label htmlFor={`tp-${htmlFor}`} style={{ width, display: 'inline-block' }}>
      {text}
    </label>
  );

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Tag Print</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="panel">
        {/* The form spec's two rows: Book / Vch No at x 36-408, Gr Code / Pr Code at 413-792, Hm Id Update and the label file at 895+. */}
        <div
          style={{
            display: 'grid',
            gridTemplateColumns: '66px 76px 224px 70px 66px 240px 24px auto',
            gap: '6px 6px',
            alignItems: 'center',
            marginBottom: 8,
          }}
        >
          {label('Book', 'book', 60)}
          {input(
            'book',
            'Book',
            book,
            setBook,
            76,
            () => void onBookEnter(),
            () => void openHelp('books', 'book'),
            8,
          )}
          <input
            aria-label="Book name"
            value={bookName}
            readOnly
            tabIndex={-1}
            style={{ width: 224 }}
          />
          {label('Gr Code', 'group', 66)}
          {input(
            'group',
            'Gr Code',
            group,
            setGroup,
            66,
            () => void onGroupEnter(),
            () => void openHelp('groups', 'group'),
            3,
          )}
          <input
            aria-label="Gr Name"
            value={groupName}
            readOnly
            tabIndex={-1}
            style={{ width: 240 }}
          />
          <span />
          <label style={{ display: 'inline-flex', gap: 6, alignItems: 'center' }}>
            <input
              type="checkbox"
              aria-label="Hm Id Update"
              checked={hm}
              onChange={(e) => {
                setHm(e.target.checked);
                setHmDone(false);
                setRows([blankRow()]);
                setCurrent(0);
                focus('cell-0-tagNo');
              }}
            />
            Hm Id Update
          </label>
          {label('Vch No', 'vchNo', 60)}
          {input(
            'vchNo',
            'Vch No',
            vchNo,
            setVchNo,
            76,
            () => void onVchEnter(),
            () => void openHelp('vouchers', 'vchNo'),
            8,
          )}
          <span className="row" style={{ gap: 6, alignItems: 'center', flexWrap: 'nowrap' }}>
            <button
              type="button"
              className="ghost"
              tabIndex={-1}
              onClick={() => void openHelp('vouchers', 'vchNo')}
            >
              F1
            </button>
            {label('Item Type', 'itemType', 66)}
            <select
              id="tp-itemType"
              ref={reg('itemType')}
              aria-label="Item Type"
              value={itemType}
              onChange={(e) => setItemType(e.target.value)}
              style={{ width: 99 }}
            >
              {itemTypes.map((t) => (
                <option key={t} value={t}>
                  {t}
                </option>
              ))}
            </select>
          </span>
          {label('Pr Code', 'product', 66)}
          {input(
            'product',
            'Pr Code',
            product,
            setProduct,
            66,
            () => void onProductEnter(),
            () => void openHelp('products', 'product'),
            2,
          )}
          <input
            aria-label="Pr Name"
            value={productName}
            readOnly
            tabIndex={-1}
            style={{ width: 240 }}
          />
          <span />
          <span className="row" style={{ gap: 6, alignItems: 'center', flexWrap: 'nowrap' }}>
            <span style={{ whiteSpace: 'nowrap' }}>Print file Name</span>
            <select
              aria-label="Print file Name"
              value={file}
              onChange={(e) => setFile(e.target.value)}
              style={{ minWidth: 113 }}
            >
              {files.map((f) => (
                <option key={f} value={f}>
                  {f}
                </option>
              ))}
            </select>
            <button type="button" className="ghost" onClick={() => void setDefault()}>
              Set
            </button>
          </span>
        </div>
        <div style={{ overflowX: 'auto', maxHeight: 360, overflowY: 'auto' }}>
          <table className="grid" data-testid="tag-print-grid">
            <thead>
              <tr>
                {cols.map((c) => (
                  <th key={c.key} style={{ minWidth: c.width }}>
                    {c.title}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i} className={i === current ? 'selected' : undefined} data-tag={r.tagNo}>
                  {cols.map((c) => {
                    const id = `cell-${i}-${c.key}`;
                    if (c.key === 'sr') return <td key={c.key}>{r.tagNo ? i + 1 : ''}</td>;
                    if (c.key === 'y')
                      return (
                        <td key={c.key}>
                          {r.tagNo ? (
                            <button
                              type="button"
                              ref={reg(id)}
                              className="ghost"
                              aria-label={`Print row ${i + 1}`}
                              aria-pressed={r.y}
                              style={{ minWidth: 34, padding: '0 6px' }}
                              onFocus={() => setCurrent(i)}
                              onClick={() =>
                                setRows((list) =>
                                  list.map((x, k) => (k === i ? { ...x, y: !x.y } : x)),
                                )
                              }
                              onKeyDown={(e) => onCellKeyDown(e, i, 'y')}
                            >
                              {r.y ? 'Y' : 'N'}
                            </button>
                          ) : null}
                        </td>
                      );
                    if (c.key === 'tagNo')
                      return (
                        <td key={c.key}>
                          <input
                            ref={reg(id)}
                            aria-label={`TagNo row ${i + 1}`}
                            value={r.tagNo}
                            readOnly={Boolean(r.itCode)}
                            style={{ width: c.width - 12 }}
                            onFocus={() => setCurrent(i)}
                            onChange={(e) => setCell(i, 'tagNo', e.target.value)}
                            onKeyDown={(e) => onCellKeyDown(e, i, 'tagNo')}
                          />
                        </td>
                      );
                    const hmMatch = /^(hmId|hmWt)(\d)$/.exec(c.key);
                    const value = hmMatch
                      ? (hmMatch[1] === 'hmId' ? r.hmIds : r.hmWts)[Number(hmMatch[2])]!
                      : String((r as unknown as Record<string, string>)[c.key] ?? '');
                    if (hm && HM_EDITABLE.has(c.key) && r.tagNo)
                      return (
                        <td key={c.key}>
                          <input
                            ref={reg(id)}
                            aria-label={`${c.title} row ${i + 1}`}
                            value={value}
                            maxLength={hmMatch?.[1] === 'hmId' ? 10 : 12}
                            style={{ width: c.width - 12, textAlign: c.align }}
                            onFocus={() => setCurrent(i)}
                            onChange={(e) => setCell(i, c.key, e.target.value)}
                            onKeyDown={(e) => onCellKeyDown(e, i, c.key)}
                          />
                        </td>
                      );
                    return (
                      <td key={c.key} style={{ textAlign: c.align }}>
                        {value}
                      </td>
                    );
                  })}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <div
          className="row"
          style={{ gap: 8, alignItems: 'center', marginTop: 8, justifyContent: 'space-between' }}
        >
          <span aria-label="Item Name" data-testid="tag-print-item" style={{ minWidth: 221 }}>
            {itemName}
          </span>
          <span className="row" style={{ gap: 6, alignItems: 'center' }}>
            {label('Lable Skip', 'skip', 80)}
            <input
              id="tp-skip"
              ref={reg('skip')}
              aria-label="Lable Skip"
              inputMode="numeric"
              value={skip}
              maxLength={15}
              style={{ width: 39 }}
              onChange={(e) => setSkip(e.target.value.replace(/[^0-9.]/g, ''))}
            />
          </span>
        </div>
        {help && (
          <section
            className="panel"
            aria-label="Tag Print help"
            style={{ marginTop: 8 }}
            onKeyDown={onHelpKeyDown}
          >
            <input
              autoFocus
              aria-label="Help search"
              value={helpFilter}
              onChange={(e) => {
                setHelpFilter(typed(e.target.value));
                setHelp({ ...help, at: 0 });
              }}
              style={{ width: 240, marginBottom: 6 }}
            />
            <div style={{ maxHeight: 240, overflowY: 'auto' }}>
              <table className="grid">
                <thead>
                  <tr>
                    {HELP_COLUMNS[help.kind].map(([, title]) => (
                      <th key={title}>{title}</th>
                    ))}
                  </tr>
                </thead>
                <tbody data-testid="tag-print-help">
                  {helpRows.map((row, i) => (
                    <tr
                      key={i}
                      data-code={row.tagNo ?? row.code ?? row.vchNo}
                      className={i === help.at ? 'selected' : undefined}
                      onClick={() => setHelp({ ...help, at: i })}
                      onDoubleClick={() => void pickHelp(row)}
                    >
                      {HELP_COLUMNS[help.kind].map(([key]) => (
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
      <div className="row" style={{ gap: 8, justifyContent: 'flex-end', marginTop: 10 }}>
        <button
          ref={reg('print')}
          type="button"
          className="ghost"
          disabled={busy}
          onClick={() => void print()}
        >
          Print
        </button>
        <button
          ref={reg('save')}
          type="button"
          className="primary"
          data-save-mnemonic
          disabled={busy}
          onClick={() => void save()}
        >
          Save
        </button>
        <button type="button" className="ghost" disabled={busy} onClick={clear}>
          Cancel
        </button>
        <button
          type="button"
          className="danger"
          disabled={busy}
          onClick={() => setMsg({ kind: 'err', text: M.DELETE_NONE })}
        >
          Delete
        </button>
        <button type="button" className="ghost" onClick={() => router.back()}>
          Exit
        </button>
      </div>
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
