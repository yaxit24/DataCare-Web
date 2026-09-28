using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class UT_WINDOW : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile4")]
	private TileItem _tile4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile5")]
	private TileItem _tile5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile2")]
	private TileItem _tile2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile1")]
	private TileItem _tile1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile3")]
	private TileItem _tile3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile6")]
	private TileItem _tile6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnClose")]
	private Button _btnClose;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile10")]
	private TileItem _tile10;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile11")]
	private TileItem _tile11;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile12")]
	private TileItem _tile12;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile7")]
	private TileItem _tile7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile8")]
	private TileItem _tile8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tile9")]
	private TileItem _tile9;

	private Control CurActCtrl;

	private double ColCon;

	private DataTable RsRight;

	private string MsSideBtn;

	private DataTable RsTile;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dlgOpen")]
	private virtual FolderBrowserDialog _dlgOpen;

	internal virtual FolderBrowserDialog dlgOpen
	{
		get
		{
			return _dlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_dlgOpen = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TileControl")]
	private virtual TileControl _TileControl;

	internal virtual TileControl TileControl
	{
		get
		{
			return _TileControl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TileControl = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TileGroup2")]
	private virtual TileGroup _TileGroup2;

	internal virtual TileGroup TileGroup2
	{
		get
		{
			return _TileGroup2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TileGroup2 = value;
		}
	}

	internal virtual TileItem tile4
	{
		[CompilerGenerated]
		get
		{
			return _tile4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile4_ItemClick);
			TileItem val2 = _tile4;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile4 = value;
			val2 = _tile4;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile5
	{
		[CompilerGenerated]
		get
		{
			return _tile5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile5_ItemClick);
			TileItem val2 = _tile5;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile5 = value;
			val2 = _tile5;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile2
	{
		[CompilerGenerated]
		get
		{
			return _tile2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile2_ItemClick);
			TileItem val2 = _tile2;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile2 = value;
			val2 = _tile2;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile1
	{
		[CompilerGenerated]
		get
		{
			return _tile1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile1_ItemClick);
			TileItem val2 = _tile1;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile1 = value;
			val2 = _tile1;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile3
	{
		[CompilerGenerated]
		get
		{
			return _tile3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile3_ItemClick);
			TileItem val2 = _tile3;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile3 = value;
			val2 = _tile3;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile6
	{
		[CompilerGenerated]
		get
		{
			return _tile6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile6_ItemClick);
			TileItem val2 = _tile6;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile6 = value;
			val2 = _tile6;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual Button btnClose
	{
		[CompilerGenerated]
		get
		{
			return _btnClose;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnClose_Click;
			Button val = _btnClose;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnClose = value;
			val = _btnClose;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TileControl1")]
	private virtual TileControl _TileControl1;

	internal virtual TileControl TileControl1
	{
		get
		{
			return _TileControl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TileControl1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TileGroup1")]
	private virtual TileGroup _TileGroup1;

	internal virtual TileGroup TileGroup1
	{
		get
		{
			return _TileGroup1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TileGroup1 = value;
		}
	}

	internal virtual TileItem tile10
	{
		[CompilerGenerated]
		get
		{
			return _tile10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile10_ItemClick);
			TileItem val2 = _tile10;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile10 = value;
			val2 = _tile10;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile11
	{
		[CompilerGenerated]
		get
		{
			return _tile11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile11_ItemClick);
			TileItem val2 = _tile11;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile11 = value;
			val2 = _tile11;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile12
	{
		[CompilerGenerated]
		get
		{
			return _tile12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile12_ItemClick);
			TileItem val2 = _tile12;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile12 = value;
			val2 = _tile12;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile7
	{
		[CompilerGenerated]
		get
		{
			return _tile7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile7_ItemClick);
			TileItem val2 = _tile7;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile7 = value;
			val2 = _tile7;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile8
	{
		[CompilerGenerated]
		get
		{
			return _tile8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile8_ItemClick);
			TileItem val2 = _tile8;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile8 = value;
			val2 = _tile8;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	internal virtual TileItem tile9
	{
		[CompilerGenerated]
		get
		{
			return _tile9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TileItemClickEventHandler val = new TileItemClickEventHandler(Tile9_ItemClick);
			TileItem val2 = _tile9;
			if (val2 != null)
			{
				val2.ItemClick -= val;
			}
			_tile9 = value;
			val2 = _tile9;
			if (val2 != null)
			{
				val2.ItemClick += val;
			}
		}
	}

	public UT_WINDOW()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += UT_WINDOW_Load;
		((Form)this).Deactivate += UT_WINDOW_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_WINDOW_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_WINDOW_KeyDown);
		((Form)this).Closed += UT_WINDOW_Closed;
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected O, but got Unknown
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected O, but got Unknown
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected O, but got Unknown
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Expected O, but got Unknown
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d5: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d8: Expected O, but got Unknown
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a98: Expected O, but got Unknown
		//IL_0afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Expected O, but got Unknown
		//IL_0b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b32: Expected O, but got Unknown
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Expected O, but got Unknown
		//IL_0c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c35: Expected O, but got Unknown
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Expected O, but got Unknown
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7f: Expected O, but got Unknown
		//IL_0df7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e01: Expected O, but got Unknown
		//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e82: Expected O, but got Unknown
		//IL_0f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f33: Expected O, but got Unknown
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1186: Expected O, but got Unknown
		//IL_11b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c3: Expected O, but got Unknown
		//IL_123b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1245: Expected O, but got Unknown
		//IL_12bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c6: Expected O, but got Unknown
		//IL_136d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1377: Expected O, but got Unknown
		//IL_142b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1435: Expected O, but got Unknown
		//IL_1475: Unknown result type (might be due to invalid IL or missing references)
		//IL_147f: Expected O, but got Unknown
		//IL_14f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1501: Expected O, but got Unknown
		//IL_1578: Unknown result type (might be due to invalid IL or missing references)
		//IL_1582: Expected O, but got Unknown
		//IL_1638: Unknown result type (might be due to invalid IL or missing references)
		//IL_1642: Expected O, but got Unknown
		//IL_16a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b2: Expected O, but got Unknown
		//IL_16d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16dc: Expected O, but got Unknown
		//IL_1754: Unknown result type (might be due to invalid IL or missing references)
		//IL_175e: Expected O, but got Unknown
		//IL_17d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17df: Expected O, but got Unknown
		//IL_18e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ed: Expected O, but got Unknown
		//IL_1971: Unknown result type (might be due to invalid IL or missing references)
		//IL_197b: Expected O, but got Unknown
		//IL_19fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a08: Expected O, but got Unknown
		//IL_1a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a96: Expected O, but got Unknown
		//IL_1ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad3: Expected O, but got Unknown
		//IL_1b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b55: Expected O, but got Unknown
		//IL_1bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd6: Expected O, but got Unknown
		//IL_1c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c87: Expected O, but got Unknown
		TileItemElement val = new TileItemElement();
		TileItemElement val2 = new TileItemElement();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_WINDOW));
		TileItemElement val3 = new TileItemElement();
		TileItemElement val4 = new TileItemElement();
		TileItemElement val5 = new TileItemElement();
		TileItemElement val6 = new TileItemElement();
		TileItemFrame val7 = new TileItemFrame();
		TileItemElement val8 = new TileItemElement();
		TileItemFrame val9 = new TileItemFrame();
		TileItemElement val10 = new TileItemElement();
		TileItemElement val11 = new TileItemElement();
		TileItemElement val12 = new TileItemElement();
		TileItemElement val13 = new TileItemElement();
		TileItemElement val14 = new TileItemElement();
		TileItemElement val15 = new TileItemElement();
		TileItemFrame val16 = new TileItemFrame();
		TileItemElement val17 = new TileItemElement();
		TileItemFrame val18 = new TileItemFrame();
		TileItemElement val19 = new TileItemElement();
		TileItemElement val20 = new TileItemElement();
		TileItemElement val21 = new TileItemElement();
		TileItemElement val22 = new TileItemElement();
		TileItemElement val23 = new TileItemElement();
		TileItemElement val24 = new TileItemElement();
		TileControl = new TileControl();
		TileGroup2 = new TileGroup();
		tile1 = new TileItem();
		tile4 = new TileItem();
		tile5 = new TileItem();
		tile2 = new TileItem();
		tile3 = new TileItem();
		tile6 = new TileItem();
		btnClose = new Button();
		TileControl1 = new TileControl();
		TileGroup1 = new TileGroup();
		tile7 = new TileItem();
		tile10 = new TileItem();
		tile11 = new TileItem();
		tile8 = new TileItem();
		tile9 = new TileItem();
		tile12 = new TileItem();
		((Control)this).SuspendLayout();
		TileControl.Groups.Add(TileGroup2);
		((Control)TileControl).Location = new Point(6, 9);
		TileControl.MaxId = 58;
		((Control)TileControl).Name = "TileControl";
		((Control)TileControl).Size = new Size(554, 296);
		((Control)TileControl).TabIndex = 0;
		((Control)TileControl).Text = "TileControl";
		TileGroup2.Items.Add((ITileItem)(object)tile1);
		TileGroup2.Items.Add((ITileItem)(object)tile4);
		TileGroup2.Items.Add((ITileItem)(object)tile5);
		TileGroup2.Items.Add((ITileItem)(object)tile2);
		TileGroup2.Items.Add((ITileItem)(object)tile3);
		TileGroup2.Items.Add((ITileItem)(object)tile6);
		TileGroup2.Name = "TileGroup2";
		tile1.AppearanceItem.Hovered.Font = new Font("Microsoft Sans Serif", 8.25f);
		tile1.AppearanceItem.Hovered.Options.UseFont = true;
		tile1.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile1.AppearanceItem.Normal.Options.UseFont = true;
		tile1.AppearanceItem.Pressed.Font = new Font("Microsoft Sans Serif", 8.25f);
		tile1.AppearanceItem.Pressed.Options.UseFont = true;
		tile1.AppearanceItem.Selected.Font = new Font("Microsoft Sans Serif", 8.25f);
		tile1.AppearanceItem.Selected.Options.UseFont = true;
		val.Appearance.Hovered.Font = new Font("Segoe UI Light", 17f);
		val.Appearance.Hovered.Options.UseFont = true;
		val.Appearance.Hovered.Options.UseTextOptions = true;
		val.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val.Appearance.Normal.Options.UseFont = true;
		val.Appearance.Normal.Options.UseTextOptions = true;
		val.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val.Appearance.Selected.Font = new Font("Segoe UI Light", 17f);
		val.Appearance.Selected.Options.UseFont = true;
		val.Appearance.Selected.Options.UseTextOptions = true;
		val.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val.MaxWidth = 160;
		val.Text = "F1";
		val.TextAlignment = (TileItemContentAlignment)1;
		val.TextLocation = new Point(75, 0);
		((ImageCollectionImageOptions)val2.ImageOptions).Image = (Image)componentResourceManager.GetObject("resource.Image");
		val2.ImageOptions.ImageAlignment = (TileItemContentAlignment)10;
		val2.ImageOptions.ImageLocation = new Point(4, 8);
		val2.ImageOptions.ImageScaleMode = (TileItemImageScaleMode)6;
		val2.ImageOptions.ImageSize = new Size(64, 64);
		tile1.Elements.Add(val);
		tile1.Elements.Add(val2);
		tile1.Id = 1;
		tile1.ItemSize = (TileItemSize)3;
		tile1.Name = "tile1";
		tile4.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile4.AppearanceItem.Normal.Options.UseFont = true;
		val3.Text = "F4";
		tile4.Elements.Add(val3);
		tile4.Id = 4;
		tile4.ItemSize = (TileItemSize)2;
		tile4.Name = "tile4";
		tile5.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile5.AppearanceItem.Normal.Options.UseFont = true;
		val4.Text = "F5";
		tile5.Elements.Add(val4);
		tile5.Id = 5;
		tile5.ItemSize = (TileItemSize)2;
		tile5.Name = "tile5";
		tile2.AppearanceItem.Hovered.Font = new Font("Microsoft Sans Serif", 8.25f);
		tile2.AppearanceItem.Hovered.Options.UseFont = true;
		tile2.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile2.AppearanceItem.Normal.Options.UseFont = true;
		tile2.AppearanceItem.Pressed.Font = new Font("Microsoft Sans Serif", 8.25f);
		tile2.AppearanceItem.Pressed.Options.UseFont = true;
		tile2.AppearanceItem.Selected.Font = new Font("Microsoft Sans Serif", 8.25f);
		tile2.AppearanceItem.Selected.Options.UseFont = true;
		val5.Text = "F2";
		tile2.Elements.Add(val5);
		tile2.Id = 2;
		tile2.ItemSize = (TileItemSize)2;
		tile2.Name = "tile2";
		tile3.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile3.AppearanceItem.Normal.Options.UseFont = true;
		tile3.CurrentFrameIndex = 1;
		val6.Appearance.Hovered.Font = new Font("Segoe UI", 9f);
		val6.Appearance.Hovered.Options.UseFont = true;
		val6.Appearance.Hovered.Options.UseTextOptions = true;
		val6.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val6.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val6.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val6.Appearance.Normal.Options.UseFont = true;
		val6.Appearance.Normal.Options.UseTextOptions = true;
		val6.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val6.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val6.Appearance.Selected.Font = new Font("Segoe UI", 9f);
		val6.Appearance.Selected.Options.UseFont = true;
		val6.Appearance.Selected.Options.UseTextOptions = true;
		val6.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val6.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val6.Text = "F3";
		val6.TextAlignment = (TileItemContentAlignment)10;
		val6.TextLocation = new Point(4, 11);
		tile3.Elements.Add(val6);
		val7.Animation = (TileItemContentAnimationType)2;
		((ImageCollectionImageOptions)val8.ImageOptions).Image = (Image)componentResourceManager.GetObject("resource.Image1");
		val8.ImageOptions.ImageAlignment = (TileItemContentAlignment)10;
		val8.ImageOptions.ImageLocation = new Point(-12, -8);
		val8.ImageOptions.ImageScaleMode = (TileItemImageScaleMode)6;
		val8.ImageOptions.ImageSize = new Size(120, 120);
		val7.Elements.Add(val8);
		val7.Image = (Image)componentResourceManager.GetObject("TileItemFrame1.Image");
		val9.Animation = (TileItemContentAnimationType)1;
		val10.Appearance.Hovered.Font = new Font("Segoe UI", 9f);
		val10.Appearance.Hovered.Options.UseFont = true;
		val10.Appearance.Hovered.Options.UseTextOptions = true;
		val10.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val10.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val10.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val10.Appearance.Normal.Options.UseFont = true;
		val10.Appearance.Normal.Options.UseTextOptions = true;
		val10.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val10.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val10.Appearance.Selected.Font = new Font("Segoe UI", 9f);
		val10.Appearance.Selected.Options.UseFont = true;
		val10.Appearance.Selected.Options.UseTextOptions = true;
		val10.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val10.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val10.Text = "F3";
		val10.TextAlignment = (TileItemContentAlignment)10;
		val10.TextLocation = new Point(4, 11);
		val9.Elements.Add(val10);
		tile3.Frames.Add(val7);
		tile3.Frames.Add(val9);
		tile3.Id = 3;
		tile3.ItemSize = (TileItemSize)2;
		tile3.Name = "tile3";
		tile6.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile6.AppearanceItem.Normal.Options.UseFont = true;
		val11.Appearance.Hovered.Font = new Font("Segoe UI Light", 17f);
		val11.Appearance.Hovered.Options.UseFont = true;
		val11.Appearance.Hovered.Options.UseTextOptions = true;
		val11.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val11.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val11.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val11.Appearance.Normal.Options.UseFont = true;
		val11.Appearance.Normal.Options.UseTextOptions = true;
		val11.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val11.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val11.Appearance.Selected.Font = new Font("Segoe UI Light", 17f);
		val11.Appearance.Selected.Options.UseFont = true;
		val11.Appearance.Selected.Options.UseTextOptions = true;
		val11.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val11.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val11.MaxWidth = 160;
		val11.Text = "F6";
		val11.TextAlignment = (TileItemContentAlignment)10;
		val11.TextLocation = new Point(75, 0);
		((ImageCollectionImageOptions)val12.ImageOptions).Image = (Image)componentResourceManager.GetObject("resource.Image2");
		val12.ImageOptions.ImageAlignment = (TileItemContentAlignment)10;
		val12.ImageOptions.ImageLocation = new Point(4, 8);
		val12.ImageOptions.ImageScaleMode = (TileItemImageScaleMode)6;
		val12.ImageOptions.ImageSize = new Size(64, 64);
		tile6.Elements.Add(val11);
		tile6.Elements.Add(val12);
		tile6.Id = 6;
		tile6.ItemSize = (TileItemSize)3;
		tile6.Name = "tile6";
		((Control)btnClose).Location = new Point(501, 578);
		((Control)btnClose).Name = "btnClose";
		((Control)btnClose).Size = new Size(34, 25);
		((Control)btnClose).TabIndex = 1147;
		((ButtonBase)btnClose).Text = "X";
		((ButtonBase)btnClose).UseVisualStyleBackColor = true;
		TileControl1.Groups.Add(TileGroup1);
		((Control)TileControl1).Location = new Point(5, 283);
		TileControl1.MaxId = 58;
		((Control)TileControl1).Name = "TileControl1";
		((Control)TileControl1).Size = new Size(554, 293);
		((Control)TileControl1).TabIndex = 1148;
		((Control)TileControl1).Text = "TileControl1";
		TileGroup1.Items.Add((ITileItem)(object)tile7);
		TileGroup1.Items.Add((ITileItem)(object)tile10);
		TileGroup1.Items.Add((ITileItem)(object)tile11);
		TileGroup1.Items.Add((ITileItem)(object)tile8);
		TileGroup1.Items.Add((ITileItem)(object)tile9);
		TileGroup1.Items.Add((ITileItem)(object)tile12);
		TileGroup1.Name = "TileGroup1";
		tile7.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile7.AppearanceItem.Normal.Options.UseFont = true;
		val13.Appearance.Hovered.Font = new Font("Segoe UI Light", 17f);
		val13.Appearance.Hovered.Options.UseFont = true;
		val13.Appearance.Hovered.Options.UseTextOptions = true;
		val13.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val13.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val13.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val13.Appearance.Normal.Options.UseFont = true;
		val13.Appearance.Normal.Options.UseTextOptions = true;
		val13.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val13.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val13.Appearance.Selected.Font = new Font("Segoe UI Light", 17f);
		val13.Appearance.Selected.Options.UseFont = true;
		val13.Appearance.Selected.Options.UseTextOptions = true;
		val13.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val13.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val13.MaxWidth = 160;
		val13.Text = "F7";
		val13.TextAlignment = (TileItemContentAlignment)10;
		val13.TextLocation = new Point(75, 0);
		((ImageCollectionImageOptions)val14.ImageOptions).Image = (Image)componentResourceManager.GetObject("resource.Image3");
		val14.ImageOptions.ImageAlignment = (TileItemContentAlignment)10;
		val14.ImageOptions.ImageLocation = new Point(4, 8);
		val14.ImageOptions.ImageScaleMode = (TileItemImageScaleMode)6;
		val14.ImageOptions.ImageSize = new Size(64, 64);
		tile7.Elements.Add(val13);
		tile7.Elements.Add(val14);
		tile7.Id = 7;
		tile7.ItemSize = (TileItemSize)3;
		tile7.Name = "tile7";
		tile10.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile10.AppearanceItem.Normal.Options.UseFont = true;
		tile10.CurrentFrameIndex = 1;
		val15.Appearance.Hovered.Font = new Font("Segoe UI", 9f);
		val15.Appearance.Hovered.Options.UseFont = true;
		val15.Appearance.Hovered.Options.UseTextOptions = true;
		val15.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val15.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val15.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val15.Appearance.Normal.Options.UseFont = true;
		val15.Appearance.Normal.Options.UseTextOptions = true;
		val15.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val15.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val15.Appearance.Selected.Font = new Font("Segoe UI", 9f);
		val15.Appearance.Selected.Options.UseFont = true;
		val15.Appearance.Selected.Options.UseTextOptions = true;
		val15.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val15.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val15.Text = "X";
		val15.TextAlignment = (TileItemContentAlignment)10;
		val15.TextLocation = new Point(4, 11);
		tile10.Elements.Add(val15);
		val16.Animation = (TileItemContentAnimationType)2;
		((ImageCollectionImageOptions)val17.ImageOptions).Image = (Image)componentResourceManager.GetObject("resource.Image4");
		val17.ImageOptions.ImageAlignment = (TileItemContentAlignment)10;
		val17.ImageOptions.ImageLocation = new Point(-12, -8);
		val17.ImageOptions.ImageScaleMode = (TileItemImageScaleMode)6;
		val17.ImageOptions.ImageSize = new Size(120, 120);
		val16.Elements.Add(val17);
		val16.Image = (Image)componentResourceManager.GetObject("TileItemFrame3.Image");
		val18.Animation = (TileItemContentAnimationType)1;
		val19.Appearance.Hovered.Font = new Font("Segoe UI", 9f);
		val19.Appearance.Hovered.Options.UseFont = true;
		val19.Appearance.Hovered.Options.UseTextOptions = true;
		val19.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val19.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val19.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val19.Appearance.Normal.Options.UseFont = true;
		val19.Appearance.Normal.Options.UseTextOptions = true;
		val19.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val19.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val19.Appearance.Selected.Font = new Font("Segoe UI", 9f);
		val19.Appearance.Selected.Options.UseFont = true;
		val19.Appearance.Selected.Options.UseTextOptions = true;
		val19.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val19.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val19.Text = "X";
		val19.TextAlignment = (TileItemContentAlignment)10;
		val19.TextLocation = new Point(4, 11);
		val18.Elements.Add(val19);
		tile10.Frames.Add(val16);
		tile10.Frames.Add(val18);
		tile10.Id = 10;
		tile10.ItemSize = (TileItemSize)2;
		tile10.Name = "tile10";
		tile11.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile11.AppearanceItem.Normal.Options.UseFont = true;
		val20.Text = "F11";
		tile11.Elements.Add(val20);
		tile11.Id = 11;
		tile11.ItemSize = (TileItemSize)2;
		tile11.Name = "tile11";
		tile8.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile8.AppearanceItem.Normal.Options.UseFont = true;
		val21.Text = "F8";
		tile8.Elements.Add(val21);
		tile8.Id = 8;
		tile8.ItemSize = (TileItemSize)2;
		tile8.Name = "tile8";
		tile9.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile9.AppearanceItem.Normal.Options.UseFont = true;
		val22.Text = "F9";
		tile9.Elements.Add(val22);
		tile9.Id = 9;
		tile9.ItemSize = (TileItemSize)2;
		tile9.Name = "tile9";
		tile12.AppearanceItem.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		tile12.AppearanceItem.Normal.Options.UseFont = true;
		val23.Appearance.Hovered.Font = new Font("Segoe UI Light", 17f);
		val23.Appearance.Hovered.Options.UseFont = true;
		val23.Appearance.Hovered.Options.UseTextOptions = true;
		val23.Appearance.Hovered.TextOptions.Trimming = (Trimming)4;
		val23.Appearance.Hovered.TextOptions.WordWrap = (WordWrap)2;
		val23.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1);
		val23.Appearance.Normal.Options.UseFont = true;
		val23.Appearance.Normal.Options.UseTextOptions = true;
		val23.Appearance.Normal.TextOptions.Trimming = (Trimming)4;
		val23.Appearance.Normal.TextOptions.WordWrap = (WordWrap)2;
		val23.Appearance.Selected.Font = new Font("Segoe UI Light", 17f);
		val23.Appearance.Selected.Options.UseFont = true;
		val23.Appearance.Selected.Options.UseTextOptions = true;
		val23.Appearance.Selected.TextOptions.Trimming = (Trimming)4;
		val23.Appearance.Selected.TextOptions.WordWrap = (WordWrap)2;
		val23.MaxWidth = 160;
		val23.Text = "F12";
		val23.TextAlignment = (TileItemContentAlignment)10;
		val23.TextLocation = new Point(75, 0);
		((ImageCollectionImageOptions)val24.ImageOptions).Image = (Image)componentResourceManager.GetObject("resource.Image5");
		val24.ImageOptions.ImageAlignment = (TileItemContentAlignment)10;
		val24.ImageOptions.ImageLocation = new Point(4, 8);
		val24.ImageOptions.ImageScaleMode = (TileItemImageScaleMode)6;
		val24.ImageOptions.ImageSize = new Size(64, 64);
		tile12.Elements.Add(val23);
		tile12.Elements.Add(val24);
		tile12.Id = 12;
		tile12.ItemSize = (TileItemSize)3;
		tile12.Name = "tile12";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(566, 612);
		((Control)this).Controls.Add((Control)(object)TileControl1);
		((Control)this).Controls.Add((Control)(object)btnClose);
		((Control)this).Controls.Add((Control)(object)TileControl);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_WINDOW";
		((Form)this).Text = "Window Menu";
		((Control)this).ResumeLayout(false);
	}

	private void roundCorners(Form obj)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		obj.FormBorderStyle = (FormBorderStyle)0;
		GraphicsPath val = new GraphicsPath();
		val.StartFigure();
		val.AddArc(new Rectangle(0, 0, 40, 40), 180f, 90f);
		checked
		{
			val.AddLine(40, 0, ((Control)obj).Width - 40, 0);
			val.AddArc(new Rectangle(((Control)obj).Width - 40, 0, 40, 40), -90f, 90f);
			val.AddLine(((Control)obj).Width, 40, ((Control)obj).Width, ((Control)obj).Height - 40);
			val.AddArc(new Rectangle(((Control)obj).Width - 40, ((Control)obj).Height - 40, 40, 40), 0f, 90f);
			val.AddLine(((Control)obj).Width - 40, ((Control)obj).Height, 40, ((Control)obj).Height);
			val.AddArc(new Rectangle(0, ((Control)obj).Height - 40, 40, 40), 90f, 90f);
			val.CloseFigure();
			((Control)obj).Region = new Region(val);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void UT_WINDOW_Load(object sender, EventArgs e)
	{
		checked
		{
			if (Operators.CompareString(DC_Main.MsTileMenuShow, "W", false) == 0)
			{
				((Control)btnClose).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MsTileMenuShow, "R", false) == 0)
			{
				((Control)this).Visible = true;
				int num = Screen.PrimaryScreen.WorkingArea.Width;
				int y = Screen.PrimaryScreen.WorkingArea.Height - ((Control)this).Height;
				while (num != Screen.PrimaryScreen.WorkingArea.Width - ((Control)this).Width)
				{
					num--;
					((Form)this).Location = new Point(num, y);
				}
				((Form)this).TopMost = true;
			}
			else
			{
				((Control)this).Left = Screen.PrimaryScreen.WorkingArea.Left;
				((Control)this).Top = Screen.PrimaryScreen.WorkingArea.Bottom - ((Control)this).Height;
				((Form)this).TopMost = true;
			}
			DC_Main.MsImageNo = "01";
			DC_Main.MsImageType = "TagImage";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				tile1.Image = Image.FromFile(DC_Main.MsImagePath);
				tile1.ImageScaleMode = (TileItemImageScaleMode)2;
			}
			else
			{
				tile1.BackgroundImage = null;
			}
			ColorConverter colorConverter = new ColorConverter();
			AppearanceObject normal = tile1.AppearanceItem.Normal;
			object? obj = colorConverter.ConvertFromString("0, 170, 230");
			normal.BackColor = ((obj != null) ? ((Color)obj) : default(Color));
			AppearanceObject normal2 = tile2.AppearanceItem.Normal;
			object? obj2 = colorConverter.ConvertFromString("232, 155, 20");
			normal2.BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
			AppearanceObject normal3 = tile3.AppearanceItem.Normal;
			object? obj3 = colorConverter.ConvertFromString("228, 189, 16");
			normal3.BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
			AppearanceObject normal4 = tile4.AppearanceItem.Normal;
			object? obj4 = colorConverter.ConvertFromString("228, 189, 16");
			normal4.BackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
			AppearanceObject normal5 = tile5.AppearanceItem.Normal;
			object? obj5 = colorConverter.ConvertFromString("102, 197, 195");
			normal5.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
			AppearanceObject normal6 = tile6.AppearanceItem.Normal;
			object? obj6 = colorConverter.ConvertFromString("80, 166, 105");
			normal6.BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
			AppearanceObject normal7 = tile7.AppearanceItem.Normal;
			object? obj7 = colorConverter.ConvertFromString("232, 155, 20");
			normal7.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			AppearanceObject normal8 = tile8.AppearanceItem.Normal;
			object? obj8 = colorConverter.ConvertFromString("228, 189, 16");
			normal8.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			AppearanceObject normal9 = tile9.AppearanceItem.Normal;
			object? obj9 = colorConverter.ConvertFromString("0, 170, 230");
			normal9.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			AppearanceObject normal10 = tile10.AppearanceItem.Normal;
			object? obj10 = colorConverter.ConvertFromString("228, 189, 16");
			normal10.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			AppearanceObject normal11 = tile11.AppearanceItem.Normal;
			object? obj11 = colorConverter.ConvertFromString("80, 166, 105");
			normal11.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			AppearanceObject normal12 = tile12.AppearanceItem.Normal;
			object? obj12 = colorConverter.ConvertFromString("102, 197, 195");
			normal12.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
			DC_Main.RsQry = "SELECT * FROM TILE_DATA";
			RsTile = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			for (int i = 0; i < RsTile.Rows.Count; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile1", false))
				{
					tile1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F1 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile1.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile2", false))
				{
					tile2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F2 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile2.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile3", false))
				{
					tile3.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F3 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile3.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile4", false))
				{
					tile4.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F4 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile4.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile5", false))
				{
					tile5.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F5 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile5.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile6", false))
				{
					tile6.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F6 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile6.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile7", false))
				{
					tile7.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F7 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile7.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile8", false))
				{
					tile8.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F8 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile8.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile9", false))
				{
					tile9.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F9 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile9.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile10", false))
				{
					tile10.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"X - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile10.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile11", false))
				{
					tile11.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F11 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile11.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
				else if (Operators.ConditionalCompareObjectEqual(RsTile.Rows[i]["TILE_NAME"], (object)"tile12", false))
				{
					tile12.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"F12 - ", RsTile.Rows[i]["DISPLAY_NAME"]), (object)""));
					tile12.Tag = Operators.ConcatenateObject(RsTile.Rows[i]["SM_MAIN_NAME"], (object)"");
				}
			}
		}
	}

	private void UT_WINDOW_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_WINDOW_KeyPress(object sender, KeyPressEventArgs e)
	{
		short num;
		checked
		{
			num = (short)Strings.Asc(e.KeyChar);
			num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));
		}
		e.KeyChar = Strings.Chr((int)num);
		if (num == 0 || num == 39)
		{
			e.Handled = true;
		}
	}

	private void UT_WINDOW_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected I4, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		Keys keyCode = e.KeyCode;
		if ((int)keyCode != 88)
		{
			switch (keyCode - 112)
			{
			case 0:
				Tile1_ItemClick(tile1, new TileItemEventArgs());
				break;
			case 1:
				Tile2_ItemClick(tile2, new TileItemEventArgs());
				break;
			case 2:
				Tile3_ItemClick(tile3, new TileItemEventArgs());
				break;
			case 3:
				Tile4_ItemClick(tile4, new TileItemEventArgs());
				break;
			case 4:
				Tile5_ItemClick(tile5, new TileItemEventArgs());
				break;
			case 5:
				Tile6_ItemClick(tile6, new TileItemEventArgs());
				break;
			case 6:
				Tile7_ItemClick(tile7, new TileItemEventArgs());
				break;
			case 7:
				Tile8_ItemClick(tile8, new TileItemEventArgs());
				break;
			case 8:
				Tile9_ItemClick(tile9, new TileItemEventArgs());
				break;
			case 10:
				Tile11_ItemClick(tile11, new TileItemEventArgs());
				break;
			case 11:
				Tile12_ItemClick(tile12, new TileItemEventArgs());
				break;
			}
		}
		else
		{
			Tile10_ItemClick(tile10, new TileItemEventArgs());
		}
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void Transaction_Form()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ea: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "Select * From USER_SET WHERE USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + MsSideBtn + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
			return;
		}
		checked
		{
			switch (MsSideBtn)
			{
			case "Tag Opening":
				DC_Main.CurBookHelp("OPSTK");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)MyProject.Forms.TR_TAG_OPBL).Show();
				((Control)MyProject.Forms.TR_TAG_OPBL).Focus();
				break;
			case "Purchase":
			{
				DC_Main.CurBookHelp("PURCHASE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_PURC tR_PURC3 = new TR_PURC();
				((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_PURC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_PURC3).Show();
				((Control)tR_PURC3).Focus();
				break;
			}
			case "Purchase Rtn":
			{
				DC_Main.CurBookHelp("PURC RETURN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_KR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
				break;
			}
			case "Sales":
				DC_Main.CurBookHelp("SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
				{
					TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
					((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE_HM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE_HM).Show();
					((Control)tR_SALE_HM).Focus();
				}
				else
				{
					TR_SALE tR_SALE = new TR_SALE();
					((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE).Show();
					((Control)tR_SALE).Focus();
				}
				break;
			case "Sales Return":
			{
				DC_Main.CurBookHelp("SALES RETURNE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_SALE_RTN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
				break;
			}
			case "Sales Order":
			{
				DC_Main.CurBookHelp("SALES ORDER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
				((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_SALE_ORD).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_SALE_ORD).Show();
				((Control)tR_SALE_ORD).Focus();
				break;
			}
			case "Wh Sales":
			{
				DC_Main.CurBookHelp("WH SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
				((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_WH_SALE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_WH_SALE).Show();
				((Control)tR_WH_SALE).Focus();
				break;
			}
			case "Cash Received":
			{
				DC_Main.CurBookHelp("CASH REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_CASH tR_CASH4 = new TR_CASH();
				((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH4).Show();
				((Control)tR_CASH4).Focus();
				break;
			}
			case "Cash Payment":
			{
				DC_Main.CurBookHelp("CASH PAY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_CASH tR_CASH3 = new TR_CASH();
				((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH3).Show();
				((Control)tR_CASH3).Focus();
				break;
			}
			case "Bank Received":
			{
				DC_Main.CurBookHelp("BANK REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_CASH tR_CASH2 = new TR_CASH();
				((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH2).Show();
				((Control)tR_CASH2).Focus();
				break;
			}
			case "Bank Payment":
			{
				DC_Main.CurBookHelp("BANK PAY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
				break;
			}
			case "Contra Entry":
			{
				DC_Main.CurBookHelp("CONTRA");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_CONTRA tR_CONTRA = new TR_CONTRA();
				((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_CONTRA).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CONTRA).Show();
				((Control)tR_CONTRA).Focus();
				break;
			}
			case "Rate Cut":
			{
				DC_Main.CurBookHelp("RATE CUT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_WH_SALE tR_WH_SALE2 = new TR_WH_SALE();
				((Form)tR_WH_SALE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_WH_SALE2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_WH_SALE2).Show();
				((Control)tR_WH_SALE2).Focus();
				break;
			}
			case "Approval Isu":
			{
				DC_Main.CurBookHelp("APR ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_APR_ISU tR_APR_ISU5 = new TR_APR_ISU();
				((Form)tR_APR_ISU5).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_APR_ISU5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_APR_ISU5).Show();
				((Control)tR_APR_ISU5).Focus();
				break;
			}
			case "Approval Rtn":
			{
				DC_Main.CurBookHelp("APR RTN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_APR_ISU tR_APR_ISU4 = new TR_APR_ISU();
				((Form)tR_APR_ISU4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_APR_ISU4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_APR_ISU4).Show();
				((Control)tR_APR_ISU4).Focus();
				break;
			}
			case "Labour Work":
			{
				DC_Main.CurBookHelp("LABOUR WORK");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
				((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_SALE_LBR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_SALE_LBR).Show();
				((Control)tR_SALE_LBR).Focus();
				break;
			}
			case "Old Item Sales":
			{
				DC_Main.CurBookHelp("OLD ITEM SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_PURC tR_PURC2 = new TR_PURC();
				((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_PURC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_PURC2).Show();
				((Control)tR_PURC2).Focus();
				break;
			}
			case "Bill Wise Rec":
			{
				DC_Main.CurBookHelp("BILL REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
				((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_BILL_TO).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_BILL_TO).Show();
				((Control)tR_BILL_TO).Focus();
				break;
			}
			case "Fine Jv Entry":
			{
				DC_Main.CurBookHelp("FINE JV");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
				((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_CONTRA2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CONTRA2).Show();
				((Control)tR_CONTRA2).Focus();
				break;
			}
			case "Other Expenses":
			{
				DC_Main.CurBookHelp("OTH EXP");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
				((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_OTH_PURC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_OTH_PURC).Show();
				((Control)tR_OTH_PURC).Focus();
				break;
			}
			case "Vp Parcel":
			{
				DC_Main.CurBookHelp("VP PARCEL");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_VP tR_VP = new TR_VP();
				((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_VP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_VP).Show();
				((Control)tR_VP).Focus();
				break;
			}
			case "Consi Rec":
			{
				DC_Main.CurBookHelp("CON REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
				((Form)tR_APR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_APR_ISU2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_APR_ISU2).Show();
				((Control)tR_APR_ISU2).Focus();
				break;
			}
			case "Consi Purc":
			{
				DC_Main.CurBookHelp("CON PUR");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
				((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_KR_ISU2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_KR_ISU2).Show();
				((Control)tR_KR_ISU2).Focus();
				break;
			}
			case "Consi Isu":
			{
				DC_Main.CurBookHelp("CON ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
				((Form)tR_APR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_APR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_APR_ISU).Show();
				((Control)tR_APR_ISU).Focus();
				break;
			}
			case "Only Tag Entry":
			{
				DC_Main.CurBookHelp("TAG GEN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
				((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_TAG_OPBL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_TAG_OPBL).Show();
				((Control)tR_TAG_OPBL).Focus();
				break;
			}
			case "Tag Cancel":
			{
				DC_Main.CurBookHelp("TAG CANCEL");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_TAG_CAN tR_TAG_CAN3 = new TR_TAG_CAN();
				((Form)tR_TAG_CAN3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_TAG_CAN3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_TAG_CAN3).Show();
				((Control)tR_TAG_CAN3).Focus();
				break;
			}
			case "Tag Print":
			{
				UT_TAG_PRINT uT_TAG_PRINT = new UT_TAG_PRINT();
				((Form)uT_TAG_PRINT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)uT_TAG_PRINT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_TAG_PRINT).Show();
				((Control)uT_TAG_PRINT).Focus();
				break;
			}
			case "Stock Adjust":
			{
				DC_Main.CurBookHelp("STOCK ADJUST");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
				((Form)tR_TAG_CAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_TAG_CAN2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_TAG_CAN2).Show();
				((Control)tR_TAG_CAN2).Focus();
				break;
			}
			case "Order Cancel":
			{
				DC_Main.CurBookHelp("ORDER CANCEL");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
				((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_SL_ORD_ADJ).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_SL_ORD_ADJ).Show();
				((Control)tR_SL_ORD_ADJ).Focus();
				break;
			}
			case "Reminder Entry":
			{
				DC_Main.CurBookHelp("REM ENTRY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				UT_REMINDER uT_REMINDER = new UT_REMINDER();
				((Form)uT_REMINDER).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)uT_REMINDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_REMINDER).Show();
				((Control)uT_REMINDER).Focus();
				break;
			}
			case "Physical Stock":
			{
				DC_Main.CurBookHelp("PHY STOCK");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_PHYSTK tR_PHYSTK2 = new TR_PHYSTK();
				((Form)tR_PHYSTK2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_PHYSTK2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_PHYSTK2).Show();
				((Control)tR_PHYSTK2).Focus();
				break;
			}
			case "Tag Transfer":
			{
				DC_Main.CurBookHelp("TAG TRFR");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
				((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_TAG_CAN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_TAG_CAN).Show();
				((Control)tR_TAG_CAN).Focus();
				break;
			}
			case "Tag Wt Change":
			{
				DC_Main.CurBookHelp("TAG WT CHANGE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
				((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_TAG_WT_DIFF).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_TAG_WT_DIFF).Show();
				((Control)tR_TAG_WT_DIFF).Focus();
				break;
			}
			case "Sms":
			{
				UT_SMS uT_SMS = new UT_SMS();
				((Form)uT_SMS).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)uT_SMS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_SMS).Show();
				((Control)uT_SMS).Focus();
				break;
			}
			case "Counter Trfr":
			{
				DC_Main.CurBookHelp("COUNTER TRFR");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_PHYSTK tR_PHYSTK = new TR_PHYSTK();
				((Form)tR_PHYSTK).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_PHYSTK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_PHYSTK).Show();
				((Control)tR_PHYSTK).Focus();
				break;
			}
			case "Kr Issue":
			{
				DC_Main.CurBookHelp("KARIGAR ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_KR_ISU tR_KR_ISU3 = new TR_KR_ISU();
				((Form)tR_KR_ISU3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_KR_ISU3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_KR_ISU3).Show();
				((Control)tR_KR_ISU3).Focus();
				break;
			}
			case "Kr Received":
			{
				DC_Main.CurBookHelp("KARIGAR RECEIPT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_PURC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
				break;
			}
			case "Kr Design Isu":
			{
				DC_Main.CurBookHelp("KARIGAR ORDER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_APR_ISU tR_APR_ISU3 = new TR_APR_ISU();
				((Form)tR_APR_ISU3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_APR_ISU3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_APR_ISU3).Show();
				((Control)tR_APR_ISU3).Focus();
				break;
			}
			case "Cust Repar Rec":
			{
				DC_Main.CurBookHelp("CUSTREP RECEIPT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_REP_REC tR_REP_REC4 = new TR_REP_REC();
				((Form)tR_REP_REC4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_REP_REC4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_REP_REC4).Show();
				((Control)tR_REP_REC4).Focus();
				break;
			}
			case "Kr Repar Isu":
			{
				DC_Main.CurBookHelp("KRREP ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_REP_REC tR_REP_REC3 = new TR_REP_REC();
				((Form)tR_REP_REC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_REP_REC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_REP_REC3).Show();
				((Control)tR_REP_REC3).Focus();
				break;
			}
			case "Kr Repar Rec":
			{
				DC_Main.CurBookHelp("KRREP RECEIPT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_REP_REC tR_REP_REC2 = new TR_REP_REC();
				((Form)tR_REP_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_REP_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_REP_REC2).Show();
				((Control)tR_REP_REC2).Focus();
				break;
			}
			case "Cust Repar Isu":
			{
				DC_Main.CurBookHelp("CUSTREP ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_REP_REC tR_REP_REC = new TR_REP_REC();
				((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_REP_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_REP_REC).Show();
				((Control)tR_REP_REC).Focus();
				break;
			}
			case "Kr Report":
			{
				RP_ALL rP_ALL7 = new RP_ALL();
				((Form)rP_ALL7).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL7).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL7).Show();
				((Control)rP_ALL7).Focus();
				break;
			}
			case "Member Mast":
			{
				MS_MEMB mS_MEMB = new MS_MEMB();
				((Form)mS_MEMB).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)mS_MEMB).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_MEMB).Show();
				((Control)mS_MEMB).Focus();
				break;
			}
			case "Memb Opening":
			{
				DC_Main.CurBookHelp("MEMB OPENING");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_MEMB_ENT tR_MEMB_ENT2 = new TR_MEMB_ENT();
				((Form)tR_MEMB_ENT2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_MEMB_ENT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_MEMB_ENT2).Show();
				((Control)tR_MEMB_ENT2).Focus();
				break;
			}
			case "Memb Entry":
			{
				DC_Main.CurBookHelp("MEMB ENTRY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
				((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_MEMB_ENT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_MEMB_ENT).Show();
				((Control)tR_MEMB_ENT).Focus();
				break;
			}
			case "Memb Adjust":
			{
				DC_Main.CurBookHelp("MEMB ADJUST");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
				((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_MEMB_ADJ).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_MEMB_ADJ).Show();
				((Control)tR_MEMB_ADJ).Focus();
				break;
			}
			case "Scheme Report":
			{
				RP_ALL rP_ALL6 = new RP_ALL();
				((Form)rP_ALL6).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL6).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL6).Show();
				((Control)rP_ALL6).Focus();
				break;
			}
			case "Scheme Ledger":
			{
				RP_CASH_BANK rP_CASH_BANK2 = new RP_CASH_BANK();
				((Form)rP_CASH_BANK2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_CASH_BANK2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CASH_BANK2).Show();
				((Control)rP_CASH_BANK2).Focus();
				break;
			}
			case "Dhrn Issue":
			{
				DC_Main.CurBookHelp("DHIRAN ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
				((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_ISU2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_ISU2).Show();
				((Control)tR_DHRN_ISU2).Focus();
				break;
			}
			case "Dhrn Rec":
			{
				DC_Main.CurBookHelp("DHIRAN RECEIVED");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
				((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_REC2).Show();
				((Control)tR_DHRN_REC2).Focus();
				break;
			}
			case "Intrest Rec":
			{
				DC_Main.CurBookHelp("INTREST RECIVED");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_INTREC tR_DHRN_INTREC3 = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_INTREC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_INTREC3).Show();
				((Control)tR_DHRN_INTREC3).Focus();
				break;
			}
			case "Dhiran Report":
			{
				RP_DHRN_LOAN rP_DHRN_LOAN2 = new RP_DHRN_LOAN();
				((Form)rP_DHRN_LOAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_LOAN2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_LOAN2).Show();
				((Control)rP_DHRN_LOAN2).Focus();
				break;
			}
			case "Intrest All":
			{
				RP_DHRN_OS rP_DHRN_OS3 = new RP_DHRN_OS();
				((Form)rP_DHRN_OS3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_OS3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_OS3).Show();
				((Control)rP_DHRN_OS3).Focus();
				break;
			}
			case "Dhrn Os Letter":
			{
				DC_Main.CurBookHelp("OS LETTER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_INTREC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_INTREC2).Show();
				((Control)tR_DHRN_INTREC2).Focus();
				break;
			}
			case "Dhrn Due":
			{
				RP_DHRN_OS rP_DHRN_OS2 = new RP_DHRN_OS();
				((Form)rP_DHRN_OS2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_OS2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_OS2).Show();
				((Control)rP_DHRN_OS2).Focus();
				break;
			}
			case "Loan Received":
			{
				DC_Main.CurBookHelp("LOAN REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
				((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_ISU).Show();
				((Control)tR_DHRN_ISU).Focus();
				break;
			}
			case "Loan Intrest":
			{
				DC_Main.CurBookHelp("LOAN INT ENTRY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
				((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_INTREC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_INTREC).Show();
				((Control)tR_DHRN_INTREC).Focus();
				break;
			}
			case "Loan Issue":
			{
				DC_Main.CurBookHelp("LOAN ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) == 0)
				{
					return;
				}
				TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
				((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)tR_DHRN_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_DHRN_REC).Show();
				((Control)tR_DHRN_REC).Focus();
				break;
			}
			case "Loan Report":
			{
				RP_DHRN_LOAN rP_DHRN_LOAN = new RP_DHRN_LOAN();
				((Form)rP_DHRN_LOAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_LOAN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_LOAN).Show();
				((Control)rP_DHRN_LOAN).Focus();
				break;
			}
			case "Intrest Isu All":
			{
				RP_DHRN_OS rP_DHRN_OS = new RP_DHRN_OS();
				((Form)rP_DHRN_OS).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_OS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_OS).Show();
				((Control)rP_DHRN_OS).Focus();
				break;
			}
			case "Ledger Report":
			{
				RP_LEDR rP_LEDR = new RP_LEDR();
				((Form)rP_LEDR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_LEDR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_LEDR).Show();
				((Control)rP_LEDR).Focus();
				break;
			}
			case "Stock Report":
			{
				RP_STOCK rP_STOCK = new RP_STOCK();
				((Form)rP_STOCK).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_STOCK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STOCK).Show();
				((Control)rP_STOCK).Focus();
				break;
			}
			case "Tag Stock":
			{
				RP_TAG rP_TAG = new RP_TAG();
				((Form)rP_TAG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG).Show();
				((Control)rP_TAG).Focus();
				break;
			}
			case "Sales Report":
			{
				RP_ALL rP_ALL5 = new RP_ALL();
				((Form)rP_ALL5).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL5).Show();
				((Control)rP_ALL5).Focus();
				break;
			}
			case "Purchase Rpt":
			{
				RP_ALL rP_ALL4 = new RP_ALL();
				((Form)rP_ALL4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL4).Show();
				((Control)rP_ALL4).Focus();
				break;
			}
			case "Approval Rpt":
			{
				RP_ALL rP_ALL3 = new RP_ALL();
				((Form)rP_ALL3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL3).Show();
				((Control)rP_ALL3).Focus();
				break;
			}
			case "Order Report":
			{
				RP_ALL rP_ALL2 = new RP_ALL();
				((Form)rP_ALL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL2).Show();
				((Control)rP_ALL2).Focus();
				break;
			}
			case "Cash Bank":
			{
				RP_CASH_BANK rP_CASH_BANK = new RP_CASH_BANK();
				((Form)rP_CASH_BANK).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_CASH_BANK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CASH_BANK).Show();
				((Control)rP_CASH_BANK).Focus();
				break;
			}
			case "Gst Report":
			{
				RP_GST rP_GST = new RP_GST();
				((Form)rP_GST).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_GST).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_GST).Show();
				((Control)rP_GST).Focus();
				break;
			}
			case "Party Os":
			{
				RP_OS rP_OS = new RP_OS();
				((Form)rP_OS).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_OS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_OS).Show();
				((Control)rP_OS).Focus();
				break;
			}
			case "Final Reports":
			{
				RP_BALANCE rP_BALANCE = new RP_BALANCE();
				((Form)rP_BALANCE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_BALANCE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_BALANCE).Show();
				((Control)rP_BALANCE).Focus();
				break;
			}
			case "Tag Estmate":
			{
				RP_TAG_ESTMATE rP_TAG_ESTMATE = new RP_TAG_ESTMATE();
				((Form)rP_TAG_ESTMATE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG_ESTMATE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG_ESTMATE).Show();
				((Control)rP_TAG_ESTMATE).Focus();
				break;
			}
			case "Tag Image":
			{
				RP_TAG_IMAGE rP_TAG_IMAGE = new RP_TAG_IMAGE();
				((Form)rP_TAG_IMAGE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG_IMAGE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG_IMAGE).Show();
				((Control)rP_TAG_IMAGE).Focus();
				break;
			}
			case "Consi Report":
			{
				RP_CONSI_APR rP_CONSI_APR = new RP_CONSI_APR();
				((Form)rP_CONSI_APR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_CONSI_APR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CONSI_APR).Show();
				((Control)rP_CONSI_APR).Focus();
				break;
			}
			case "Trading Report":
			{
				RP_TRADING rP_TRADING = new RP_TRADING();
				((Form)rP_TRADING).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_TRADING).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TRADING).Show();
				((Control)rP_TRADING).Focus();
				break;
			}
			case "HuId Report":
			{
				RP_HUID rP_HUID = new RP_HUID();
				((Form)rP_HUID).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_HUID).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_HUID).Show();
				((Control)rP_HUID).Focus();
				break;
			}
			case "Rojmel":
			{
				RP_ROJMEL rP_ROJMEL = new RP_ROJMEL();
				((Form)rP_ROJMEL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ROJMEL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ROJMEL).Show();
				((Control)rP_ROJMEL).Focus();
				break;
			}
			case "Stock With Fine":
			{
				RP_STOCK_FINE rP_STOCK_FINE = new RP_STOCK_FINE();
				((Form)rP_STOCK_FINE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_STOCK_FINE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STOCK_FINE).Show();
				((Control)rP_STOCK_FINE).Focus();
				break;
			}
			case "Sale Zoom":
			{
				RP_SLPR_ZOOM rP_SLPR_ZOOM3 = new RP_SLPR_ZOOM();
				((Form)rP_SLPR_ZOOM3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_SLPR_ZOOM3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_SLPR_ZOOM3).Show();
				((Control)rP_SLPR_ZOOM3).Focus();
				break;
			}
			case "Purc Zoom":
			{
				RP_SLPR_ZOOM rP_SLPR_ZOOM2 = new RP_SLPR_ZOOM();
				((Form)rP_SLPR_ZOOM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_SLPR_ZOOM2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_SLPR_ZOOM2).Show();
				((Control)rP_SLPR_ZOOM2).Focus();
				break;
			}
			case "Old Stock":
			{
				RP_SLPR_ZOOM rP_SLPR_ZOOM = new RP_SLPR_ZOOM();
				((Form)rP_SLPR_ZOOM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_SLPR_ZOOM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_SLPR_ZOOM).Show();
				((Control)rP_SLPR_ZOOM).Focus();
				break;
			}
			case "Item InOut":
			{
				RP_ALL rP_ALL = new RP_ALL();
				((Form)rP_ALL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL).Show();
				((Control)rP_ALL).Focus();
				break;
			}
			case "Reminder Rpt":
			{
				RP_REMINDER rP_REMINDER = new RP_REMINDER();
				((Form)rP_REMINDER).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_REMINDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_REMINDER).Show();
				((Control)rP_REMINDER).Focus();
				break;
			}
			case "Address Print":
			{
				RP_ADDRESS rP_ADDRESS = new RP_ADDRESS();
				((Form)rP_ADDRESS).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				DC_Main.TotOpenForm++;
				((Form)rP_ADDRESS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ADDRESS).Show();
				((Control)rP_ADDRESS).Focus();
				break;
			}
			default:
				Interaction.MsgBox((object)"No Menu Found.....", (MsgBoxStyle)0, (object)null);
				break;
			}
			if (Operators.CompareString(DC_Main.MsTileMenuShow, "W", false) != 0)
			{
				((Form)this).Close();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void UT_WINDOW_Closed(object sender, EventArgs e)
	{
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void Tile1_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile1.Tag);
		Transaction_Form();
	}

	private void Tile2_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile2.Tag);
		Transaction_Form();
	}

	private void Tile3_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile3.Tag);
		Transaction_Form();
	}

	private void Tile4_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile4.Tag);
		Transaction_Form();
	}

	private void Tile5_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile5.Tag);
		Transaction_Form();
	}

	private void Tile6_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile6.Tag);
		Transaction_Form();
	}

	private void Tile7_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile7.Tag);
		Transaction_Form();
	}

	private void Tile8_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile8.Tag);
		Transaction_Form();
	}

	private void Tile9_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile9.Tag);
		Transaction_Form();
	}

	private void Tile10_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile10.Tag);
		Transaction_Form();
	}

	private void Tile11_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile11.Tag);
		Transaction_Form();
	}

	private void Tile12_ItemClick(object sender, TileItemEventArgs e)
	{
		MsSideBtn = Conversions.ToString(tile12.Tag);
		Transaction_Form();
	}
}
