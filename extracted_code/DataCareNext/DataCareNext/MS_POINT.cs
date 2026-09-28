using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxMSFlexGridLib;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_POINT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPointName")]
	private TextBox _tPointName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPointAmt")]
	private TextBox _nPointAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMinPoint")]
	private TextBox _nMinPoint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCurInUse")]
	private ComboBox _cboCurInUse;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_AC")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_AC;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private bool MsgClear;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cPointType = 1;

	private const int cSlValue = 2;

	private const int cPointCount = 3;

	private const int cFixPoint = 4;

	private const int c1GmPoint = 5;

	private const int cAcSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cAcAdd = 3;

	private const int cAcCity = 4;

	private const int cAcMobile = 5;

	private const int cAcCardNo = 6;

	private const int cAcSale = 7;

	private const int cAcRef = 8;

	private const int cAcMemb = 9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private virtual Label _lblBook;

	internal virtual Label lblBook
	{
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBook = value;
		}
	}

	public virtual TextBox Text1
	{
		[CompilerGenerated]
		get
		{
			return _Text1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
			}
		}
	}

	internal virtual TextBox TEXT_ENTRY
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG
	{
		[CompilerGenerated]
		get
		{
			return _MSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_ClickEvent;
			EventHandler eventHandler2 = MSG_Enter;
			EventHandler eventHandler3 = MSG_EnterCell;
			EventHandler eventHandler4 = MSG_LeaveCell;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				((Control)val).Enter -= eventHandler2;
				val.EnterCell -= eventHandler3;
				val.LeaveCell -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				((Control)val).Enter += eventHandler2;
				val.EnterCell += eventHandler3;
				val.LeaveCell += eventHandler4;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private virtual FlowLayoutPanel _PnlBotam;

	internal virtual FlowLayoutPanel PnlBotam
	{
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlBotam = value;
		}
	}

	internal virtual SimpleButton BtnExit
	{
		[CompilerGenerated]
		get
		{
			return _BtnExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExit_Click;
			SimpleButton val = _BtnExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExit = value;
			val = _BtnExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDelete_Click;
			SimpleButton val = _BtnDelete;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDelete = value;
			val = _BtnDelete;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCancel_Click;
			SimpleButton val = _BtnCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCancel = value;
			val = _BtnCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnSave
	{
		[CompilerGenerated]
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSave_Click;
			SimpleButton val = _BtnSave;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSave = value;
			val = _BtnSave;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnPrint
	{
		[CompilerGenerated]
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPrint_Click;
			SimpleButton val = _BtnPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPrint = value;
			val = _BtnPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
	{
		[CompilerGenerated]
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = DGV_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val = _DGV;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val = _DGV;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPointCode")]
	private virtual TextBox _tPointCode;

	internal virtual TextBox tPointCode
	{
		get
		{
			return _tPointCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPointCode = value;
		}
	}

	internal virtual TextBox tPointName
	{
		[CompilerGenerated]
		get
		{
			return _tPointName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPointName_KeyDown);
			TextBox val2 = _tPointName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPointName = value;
			val2 = _tPointName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label4")]
	private virtual Label _Label4;

	internal virtual Label Label4
	{
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label4 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private virtual Label _Label1;

	internal virtual Label Label1
	{
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label1 = value;
		}
	}

	internal virtual TextBox nPointAmt
	{
		[CompilerGenerated]
		get
		{
			return _nPointAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPointAmt_KeyDown);
			TextBox val2 = _nPointAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPointAmt = value;
			val2 = _nPointAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private virtual Label _Label2;

	internal virtual Label Label2
	{
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label2 = value;
		}
	}

	internal virtual TextBox nMinPoint
	{
		[CompilerGenerated]
		get
		{
			return _nMinPoint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMinPoint_KeyDown);
			TextBox val2 = _nMinPoint;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMinPoint = value;
			val2 = _nMinPoint;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private virtual Label _Label3;

	internal virtual Label Label3
	{
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label3 = value;
		}
	}

	internal virtual ComboBox cboCurInUse
	{
		[CompilerGenerated]
		get
		{
			return _cboCurInUse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCurInUse_KeyDown);
			ComboBox val2 = _cboCurInUse;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCurInUse = value;
			val2 = _cboCurInUse;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label6")]
	private virtual Label _Label6;

	internal virtual Label Label6
	{
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label6 = value;
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_AC
	{
		[CompilerGenerated]
		get
		{
			return _DGV_AC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = DGV_AC_SelectionChanged;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_AC_CellEnter);
			KeyEventHandler val2 = new KeyEventHandler(DGV_AC_KeyDown);
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV_AC;
			if (val3 != null)
			{
				((DataGridView)val3).SelectionChanged -= eventHandler;
				((DataGridView)val3).CellEnter -= val;
				((Control)val3).KeyDown -= val2;
			}
			_DGV_AC = value;
			val3 = _DGV_AC;
			if (val3 != null)
			{
				((DataGridView)val3).SelectionChanged += eventHandler;
				((DataGridView)val3).CellEnter += val;
				((Control)val3).KeyDown += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_AC")]
	private virtual TextBox _TEXT_AC;

	internal virtual TextBox TEXT_AC
	{
		get
		{
			return _TEXT_AC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TEXT_AC = value;
		}
	}

	public MS_POINT()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_POINT_Load;
		((Form)this).Activated += MS_POINT_Activated;
		((Form)this).Deactivate += MS_POINT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_POINT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_POINT_KeyDown);
		((Form)this).Closed += MS_POINT_Closed;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
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
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected O, but got Unknown
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b2: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a75: Expected O, but got Unknown
		//IL_0b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b51: Expected O, but got Unknown
		//IL_0be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf0: Expected O, but got Unknown
		//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Expected O, but got Unknown
		//IL_0d51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5b: Expected O, but got Unknown
		//IL_0dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dce: Expected O, but got Unknown
		//IL_0e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7b: Expected O, but got Unknown
		//IL_0ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f02: Expected O, but got Unknown
		//IL_0f83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8d: Expected O, but got Unknown
		//IL_103e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1048: Expected O, but got Unknown
		//IL_10f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1103: Expected O, but got Unknown
		//IL_1191: Unknown result type (might be due to invalid IL or missing references)
		//IL_119b: Expected O, but got Unknown
		//IL_124c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1256: Expected O, but got Unknown
		//IL_12e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ee: Expected O, but got Unknown
		//IL_13ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b6: Expected O, but got Unknown
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1439: Expected O, but got Unknown
		//IL_150c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1516: Expected O, but got Unknown
		//IL_15b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Expected O, but got Unknown
		//IL_1642: Unknown result type (might be due to invalid IL or missing references)
		//IL_164c: Expected O, but got Unknown
		//IL_1720: Unknown result type (might be due to invalid IL or missing references)
		//IL_172a: Expected O, but got Unknown
		//IL_1793: Unknown result type (might be due to invalid IL or missing references)
		//IL_179d: Expected O, but got Unknown
		//IL_184a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1854: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_POINT));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		lblBook = new Label();
		Text1 = new TextBox();
		MSG = new AxMSFlexGrid();
		TEXT_ENTRY = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		tPointCode = new TextBox();
		tPointName = new TextBox();
		Label4 = new Label();
		Label1 = new Label();
		nPointAmt = new TextBox();
		Label2 = new Label();
		nMinPoint = new TextBox();
		Label3 = new Label();
		cboCurInUse = new ComboBox();
		Label6 = new Label();
		DGV_AC = new DevComponents.DotNetBar.Controls.DataGridViewX();
		TEXT_AC = new TextBox();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)DGV_AC).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Point Master";
		lblBook.TextAlign = (ContentAlignment)32;
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		((Control)Text1).Font = new Font("Franklin Gothic Book", 11.25f);
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Location = new Point(80, 42);
		((Control)Text1).Margin = new Padding(2);
		((TextBoxBase)Text1).MaxLength = 50;
		((Control)Text1).Name = "Text1";
		((Control)Text1).RightToLeft = (RightToLeft)0;
		((Control)Text1).Size = new Size(402, 18);
		((Control)Text1).TabIndex = 8;
		Text1.Text = "SEARCH RECORD";
		Text1.TextAlign = (HorizontalAlignment)2;
		((Control)MSG).Location = new Point(593, 160);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(422, 147);
		((Control)MSG).TabIndex = 9;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)TEXT_ENTRY).Location = new Point(783, 226);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 5;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 7;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1215, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 4;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1118, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 3;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1021, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 2;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(924, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 0;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(827, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(127, 127, 127);
		((Control)DGV).Location = new Point(79, 69);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(404, 238);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 9;
		((TextBoxBase)tPointCode).BackColor = Color.White;
		((Control)tPointCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPointCode).Location = new Point(593, 69);
		((TextBoxBase)tPointCode).MaxLength = 2;
		((Control)tPointCode).Name = "tPointCode";
		((Control)tPointCode).Size = new Size(61, 23);
		((Control)tPointCode).TabIndex = 0;
		((TextBoxBase)tPointName).BackColor = Color.White;
		((Control)tPointName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPointName).Location = new Point(593, 98);
		((TextBoxBase)tPointName).MaxLength = 30;
		((Control)tPointName).Name = "tPointName";
		((Control)tPointName).Size = new Size(252, 23);
		((Control)tPointName).TabIndex = 1;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(527, 69);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(60, 20);
		((Control)Label4).TabIndex = 1174;
		Label4.Text = "Code";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(527, 98);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1176;
		Label1.Text = "Name";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPointAmt).BackColor = Color.White;
		((Control)nPointAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPointAmt).Location = new Point(593, 128);
		((TextBoxBase)nPointAmt).MaxLength = 10;
		((Control)nPointAmt).Name = "nPointAmt";
		((Control)nPointAmt).Size = new Size(61, 23);
		((Control)nPointAmt).TabIndex = 2;
		nPointAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(507, 127);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(80, 20);
		((Control)Label2).TabIndex = 1178;
		Label2.Text = "1 Point Amt";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nMinPoint).BackColor = Color.White;
		((Control)nMinPoint).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nMinPoint).Location = new Point(784, 128);
		((TextBoxBase)nMinPoint).MaxLength = 10;
		((Control)nMinPoint).Name = "nMinPoint";
		((Control)nMinPoint).Size = new Size(61, 23);
		((Control)nMinPoint).TabIndex = 3;
		nMinPoint.TextAlign = (HorizontalAlignment)1;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(671, 128);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(104, 20);
		((Control)Label3).TabIndex = 1180;
		Label3.Text = "Minimum Point";
		Label3.TextAlign = (ContentAlignment)64;
		cboCurInUse.AutoCompleteMode = (AutoCompleteMode)2;
		cboCurInUse.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCurInUse).Font = new Font("Tahoma", 9f);
		((ListControl)cboCurInUse).FormattingEnabled = true;
		((Control)cboCurInUse).Location = new Point(946, 128);
		cboCurInUse.MaxLength = 5;
		((Control)cboCurInUse).Name = "cboCurInUse";
		((Control)cboCurInUse).Size = new Size(69, 22);
		((Control)cboCurInUse).TabIndex = 4;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(859, 129);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(81, 20);
		((Control)Label6).TabIndex = 1182;
		Label6.Text = "Cur In Use";
		Label6.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_AC).AllowUserToAddRows = false;
		((DataGridView)DGV_AC).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AC).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_AC).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_AC).ColumnHeadersHeight = 30;
		((DataGridView)DGV_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).DefaultCellStyle = val8;
		((DataGridView)DGV_AC).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_AC).GridColor = Color.FromArgb(127, 127, 127);
		((Control)DGV_AC).Location = new Point(16, 322);
		((Control)DGV_AC).Name = "DGV_AC";
		DGV_AC.PaintEnhancedSelection = false;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AC).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_AC).RowHeadersVisible = false;
		((DataGridView)DGV_AC).RowHeadersWidth = 20;
		val10.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_AC).RowsDefaultCellStyle = val10;
		DGV_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_AC.SelectAllSignVisible = false;
		((DataGridView)DGV_AC).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_AC).Size = new Size(1144, 228);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 6;
		((TextBoxBase)TEXT_AC).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_AC).BorderStyle = (BorderStyle)0;
		((Control)TEXT_AC).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)TEXT_AC).Location = new Point(367, 422);
		((Control)TEXT_AC).Name = "TEXT_AC";
		((Control)TEXT_AC).Size = new Size(100, 18);
		((Control)TEXT_AC).TabIndex = 1183;
		((Control)TEXT_AC).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)TEXT_AC);
		((Control)this).Controls.Add((Control)(object)DGV_AC);
		((Control)this).Controls.Add((Control)(object)cboCurInUse);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nMinPoint);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)nPointAmt);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tPointCode);
		((Control)this).Controls.Add((Control)(object)tPointName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_POINT";
		((Form)this).Text = "Point Master";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)DGV_AC).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_AC_FILL()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).ClearSelection();
		((DataGridView)DGV_AC).Rows.Clear();
		((DataGridView)DGV_AC).Columns.Clear();
		((Control)DGV_AC).Refresh();
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "MCode");
			((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "MembName");
			((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(250.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Address");
			((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(170.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "City");
			((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(140.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Mobile");
			((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "CardNo");
			((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_AC).Columns.Add("", "Sales");
			((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_AC).Columns.Add("", "AcRef");
			((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_AC).Columns.Add("", "SchmRef");
			((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.RsQry = "select ROW_NUMBER() OVER (ORDER BY A.CARD_NO,A.MEMB_NAME) AS SrNo,A.*,B.AC_ADD1,B.AC_CITY from POINT_MEMB AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.MEMB_CODE = B.AC_CODE where A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.POINT_CODE = '" + tPointCode.Text + "' ORDER BY A.CARD_NO,A.MEMB_NAME";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
			while (DC_Main.X < dataTable.Rows.Count)
			{
				((DataGridView)dGV_AC).Rows.Add();
				DC_Main.R = ((DataGridView)dGV_AC).Rows.Count - 1;
				((DataGridView)dGV_AC)[0, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV_AC)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MEMB_CODE"], (object)"");
				((DataGridView)dGV_AC)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MEMB_NAME"], (object)"");
				((DataGridView)dGV_AC)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_ADD1"], (object)"");
				((DataGridView)dGV_AC)[4, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_CITY"], (object)"");
				((DataGridView)dGV_AC)[5, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MOBILE_NO"], (object)"");
				((DataGridView)dGV_AC)[6, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CARD_NO"], (object)"");
				((DataGridView)dGV_AC)[7, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["SL_POINT"], (object)"");
				((DataGridView)dGV_AC)[8, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["REF_POINT"], (object)"");
				((DataGridView)dGV_AC)[9, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MEMB_POINT"], (object)"");
				DC_Main.X++;
			}
			dGV_AC = null;
			dataTable.Clear();
			((DataGridView)DGV_AC).Rows.Add();
			DC_Main.R = ((DataGridView)DGV_AC).Rows.Count - 1;
			((DataGridView)DGV_AC)[0, DC_Main.R].Value = DC_Main.R + 1;
			((Control)DGV_AC).Focus();
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 6;
		mSG.Rows = 4;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1700.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "Point Type";
			mSG[5] = (int)Math.Round(0.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "1Gm Point";
			mSG[4] = (int)Math.Round(1200.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "Fix Point";
			mSG[2] = (int)Math.Round(1200.0 * ColCon);
			mSG[2] = 7;
			mSG[0, 2] = "Sl Value";
			mSG[3] = (int)Math.Round(1200.0 * ColCon);
			mSG[3] = 7;
			mSG[0, 3] = "Point Count";
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG[1, 0] = Conversions.ToString(1);
			mSG[1, 1] = "Sales";
			mSG[2, 0] = Conversions.ToString(2);
			mSG[2, 1] = "Customer Ref";
			mSG[3, 0] = Conversions.ToString(3);
			mSG[3, 1] = "Member Ref";
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (mSG.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
				mSG = null;
			}
		}
	}

	private void MSG_Enter(object sender, EventArgs e)
	{
		if (((Control)TEXT_ENTRY).Visible)
		{
			TEXT_ENTRY.Text = MSG[MSG.Row, MSG.Col];
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (!MsgClear && !((mSG.Row == 0) | (mSG.CellWidth <= 0)))
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				if (((Control)TEXT_ENTRY).Visible)
				{
					((Control)TEXT_ENTRY).Focus();
				}
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
				Application.DoEvents();
				switch (MSG.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 4:
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClear && MSG.Row != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 0:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 1:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 2:
			case 3:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			case 4:
			case 5:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			}
			((Control)TEXT_ENTRY).Visible = false;
			mSG = null;
		}
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG.Col > 1)
					{
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						mSG.Row += 1;
					}
					return;
				}
			}
			else
			{
				if (mSG.Col == 1)
				{
					if (mSG.Row == mSG.Rows - 1 && Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
					{
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						MSG_LeaveCell(MSG, new EventArgs());
						return;
					}
				}
				else if ((mSG.Col == 4) | (mSG.Col == 5))
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
						MSG_LeaveCell(MSG, new EventArgs());
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
					}
					else
					{
						mSG.Row += 1;
						mSG.Col = 1;
					}
				}
				if (mSG.Col < mSG.Cols - 1)
				{
					MSG.Col += 1;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
			}
			mSG = null;
		}
	}

	private void MS_POINT_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Expected O, but got Unknown
		//IL_0a62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Expected O, but got Unknown
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af4: Expected O, but got Unknown
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b22: Expected O, but got Unknown
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Expected O, but got Unknown
		//IL_0bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdc: Expected O, but got Unknown
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0a: Expected O, but got Unknown
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbe: Expected O, but got Unknown
		//IL_0d23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d32: Expected O, but got Unknown
		//IL_0dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc9: Expected O, but got Unknown
		//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e46: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		ColCon = 1.0 + num;
		checked
		{
			foreach (Control control in ((Control)this).Controls)
			{
				Control val = control;
				Control val2;
				(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
				(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
				(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
				(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num2);
			}
			foreach (object control2 in ((Control)PnlBotam).Controls)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(control2);
				object obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((DataGridView)DGV_AC).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj12 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj13 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj14 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
				object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj17 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj18 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj20 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj21 = lblBook;
				object? obj22 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj21).ForeColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj23 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj24 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj25 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC2 = DGV_AC;
				object? obj26 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj27 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj28 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj29 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj30 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj30 != null) ? ((Color)obj30) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV_AC).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_AC).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_AC).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_AC).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)tPointName).Font.Size * (1.0 + num2));
				Font font = ((Control)tPointName).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
			}
			cboCurInUse.Items.Add((object)"No");
			cboCurInUse.Items.Add((object)"Yes");
			cboCurInUse.SelectedIndex = 0;
			CLEAR_DATA();
			CurActCtrl = (Control)(object)tPointName;
		}
	}

	private void MS_POINT_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		DGV_CLEAR();
		DC_Main.RsQry = "SELECT A.POINT_CODE,A.POINT_NAME FROM POINT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.POINT_CODE,A.POINT_NAME  ORDER BY A.POINT_CODE ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsMast);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).MultiSelect = false;
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV).ColumnCount = 2;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "POINT_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "POINT_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
		}
		MainUser = DC_Main.MCo_User;
		DGV_CLEAR();
		MSG_CLEAR();
		((TextBoxBase)tPointCode).ReadOnly = false;
		Text1.Text = "SEARCH RECORD";
		EntryMode = "A";
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).ClearSelection();
		((DataGridView)DGV_AC).Rows.Clear();
		((DataGridView)DGV_AC).Columns.Clear();
		((Control)DGV_AC).Refresh();
		cboCurInUse.SelectedIndex = 0;
		DC_Main.RsQry = "SELECT POINT_CODE As CoCode From POINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY CAST(POINT_CODE AS INT) DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			tPointCode.Text = "01";
		}
		else
		{
			tPointCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00");
		}
		DC_Main.RsQry = "SELECT A.POINT_CODE,A.POINT_NAME FROM POINT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.POINT_CODE,A.POINT_NAME  ORDER BY A.POINT_CODE ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
		EntryMode = "A";
		((Control)tPointName).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		checked
		{
			if (Operators.CompareString(tPointCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM POINT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.POINT_CODE = '" + tPointCode.Text + "' ORDER BY A.SR_NO ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tPointCode.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["POINT_CODE"]);
					tPointName.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["POINT_NAME"]);
					nPointAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["POINT_AMT"])), "0.00");
					nMinPoint.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MIN_POINT"])), "0");
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CUR_IN_USE"], (object)""), (object)"Y", false))
				{
					cboCurInUse.SelectedIndex = 1;
				}
				else
				{
					cboCurInUse.SelectedIndex = 0;
				}
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["POINT_TYPE"], (object)""), (object)"S", false))
					{
						DC_Main.M = 1;
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["POINT_TYPE"], (object)""), (object)"C", false))
					{
						DC_Main.M = 2;
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["POINT_TYPE"], (object)""), (object)"M", false))
					{
						DC_Main.M = 3;
					}
					mSG[DC_Main.i + 1, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["SL_AMT"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["SL_POINT"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["GRM_POINT"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["FIX_POINT"], (object)"")), "0.00");
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				DGV_AC_FILL();
			}
			EntryMode = "E";
			((TextBoxBase)tPointCode).ReadOnly = true;
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tPointCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Error Found : Please Enter code First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "DELETE FROM POINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  POINT_CODE = '" + tPointCode.Text + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM POINT_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "'  AND POINT_CODE  = '" + tPointCode.Text + "' ";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = RsDetl.NewRow();
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if ((Operators.CompareString(tPointCode.Text, "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 5]) + Conversion.Val(MSG[DC_Main.i, 4]) + Conversion.Val(MSG[DC_Main.i, 2]) + Conversion.Val(MSG[DC_Main.i, 3]) != 0.0))
				{
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["POINT_CODE"] = tPointCode.Text;
					dataRow["POINT_NAME"] = tPointName.Text;
					dataRow["SR_NO"] = DC_Main.i;
					if (DC_Main.i == 1)
					{
						dataRow["POINT_TYPE"] = "S";
					}
					else if (DC_Main.M == 2)
					{
						dataRow["POINT_TYPE"] = "C";
					}
					else if (DC_Main.M == 3)
					{
						dataRow["POINT_TYPE"] = "M";
					}
					dataRow["CUR_IN_USE"] = Strings.Mid(cboCurInUse.Text, 1, 1);
					dataRow["GRM_POINT"] = Conversion.Val(MSG[DC_Main.i, 5]);
					dataRow["FIX_POINT"] = Conversion.Val(MSG[DC_Main.i, 4]);
					dataRow["SL_AMT"] = Conversion.Val(MSG[DC_Main.i, 2]);
					dataRow["SL_POINT"] = Conversion.Val(MSG[DC_Main.i, 3]);
					dataRow["POINT_AMT"] = Conversion.Val(nPointAmt.Text);
					dataRow["MIN_POINT"] = Conversion.Val(nMinPoint.Text);
					dataRow["MAIN_USER"] = DC_Main.MCo_User;
					dataRow["DATA_TRFR"] = "N";
					RsDetl.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				DC_Main.i++;
			}
			if (Operators.CompareString(cboCurInUse.Text, "Yes", false) == 0)
			{
				DC_Main.MsPointCode = tPointCode.Text;
			}
			DC_Main.RsQry = "DELETE FROM POINT_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  POINT_CODE = '" + tPointCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM POINT_MEMB WHERE CO_CODE  = '" + DC_Main.MCo_code + "'  AND POINT_CODE  = '" + tPointCode.Text + "' ";
			RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = RsDetl.NewRow();
			int num2 = ((DataGridView)DGV_AC).Rows.Count - 1;
			DC_Main.R = 0;
			while (DC_Main.R <= num2)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject((object)(Operators.CompareString(tPointCode.Text, "", false) != 0), Operators.CompareObjectNotEqual(((DataGridView)DGV_AC)[1, DC_Main.R].Value, (object)"", false)), Operators.CompareObjectNotEqual(((DataGridView)DGV_AC)[2, DC_Main.R].Value, (object)"", false)), Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(((DataGridView)DGV_AC)[7, DC_Main.R].Value, (object)"", false), Operators.CompareObjectNotEqual(((DataGridView)DGV_AC)[8, DC_Main.R].Value, (object)"", false)), Operators.CompareObjectNotEqual(((DataGridView)DGV_AC)[9, DC_Main.R].Value, (object)"", false)))))
				{
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["POINT_CODE"] = tPointCode.Text;
					dataRow2["MEMB_CODE"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[1, DC_Main.R].Value);
					dataRow2["MEMB_NAME"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[2, DC_Main.R].Value);
					dataRow2["CARD_NO"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[6, DC_Main.R].Value);
					dataRow2["MOBILE_NO"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[5, DC_Main.R].Value);
					dataRow2["SL_POINT"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[7, DC_Main.R].Value);
					dataRow2["REF_POINT"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[8, DC_Main.R].Value);
					dataRow2["MEMB_POINT"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_AC)[9, DC_Main.R].Value);
					dataRow2["DATA_TRFR"] = "N";
					RsDetl.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				DC_Main.R++;
			}
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT A.POINT_CODE,A.POINT_NAME FROM POINT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.POINT_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tPointCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Product For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_POINT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_POINT_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "tBkName", false) != 0)
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
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsMast);
				dataView.RowFilter = "POINT_NAME Like  '" + Text1.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).AutoGenerateColumns = false;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = "POINT_CODE";
					((DataGridView)DGV).Columns[0].HeaderText = "Code";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "POINT_NAME";
					((DataGridView)DGV).Columns[1].HeaderText = "Name";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void MS_POINT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13)
		{
			tPointCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tPointCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tPointName).Focus();
	}

	private void MS_POINT_Closed(object sender, EventArgs e)
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

	private void tDataType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void nPointAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPointAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPointAmt.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nMinPoint_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nMinPoint.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nMinPoint.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void cboCurInUse_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Row = 1;
			MSG.Col = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tPointName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPointName.Text, "", false) != 0)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void DGV_AC_SelectionChanged(object sender, EventArgs e)
	{
	}

	private void DGV_AC_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_AC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		int columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		checked
		{
			switch (columnIndex)
			{
			case 1:
				if (Operators.ConditionalCompareObjectNotEqual(((DataGridView)DGV_AC)[1, index].Value, (object)"", false))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '"), ((DataGridView)DGV_AC)[1, index].Value), (object)"' "));
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL,A.AC_ADD1 AS AddressL,A.AC_CITY As CityL,A.AC_MOBILE AS MobileL FROM AC_MAST AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CODE > '00100' ORDER BY A.AC_NAME";
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[6];
						DC_Main.ColWidth[0] = 400.0;
						DC_Main.ColWidth[1] = 100.0;
						DC_Main.ColWidth[2] = 300.0;
						DC_Main.ColWidth[3] = 250.0;
						DC_Main.ColWidth[4] = 130.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
						{
							((DataGridView)DGV_AC)[1, DC_Main.R].Value = DC_Main.ColValue[1];
							((DataGridView)DGV_AC)[2, DC_Main.R].Value = DC_Main.ColValue[0];
						}
						return;
					}
					((DataGridView)DGV_AC)[2, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)"");
					((DataGridView)DGV_AC)[3, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)"");
					((DataGridView)DGV_AC)[4, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)"");
					((DataGridView)DGV_AC)[5, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)"");
					break;
				}
				((Control)BtnSave).Focus();
				return;
			case 9:
				if (index == ((DataGridView)DGV_AC).Rows.Count - 1)
				{
					((DataGridView)DGV_AC).Rows.Add();
					DC_Main.R = ((DataGridView)DGV_AC).Rows.Count - 1;
					((DataGridView)DGV_AC)[0, DC_Main.R].Value = DC_Main.R + 1;
					((Control)DGV_AC).Focus();
				}
				break;
			}
			DgvAcEnter();
			e.Handled = true;
		}
	}

	private void DgvAcEnter()
	{
		int columnIndex;
		DataGridViewCell currentCell;
		checked
		{
			if (((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index < ((DataGridView)DGV_AC).RowCount - 1 && ((DataGridView)DGV_AC).CurrentCell.ColumnIndex == ((DataGridView)DGV_AC).ColumnCount - 1)
			{
				((DataGridView)DGV_AC).CurrentCell = ((DataGridView)DGV_AC)[0, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index + 1];
				return;
			}
			currentCell = ((DataGridView)DGV_AC).CurrentCell;
			columnIndex = currentCell.ColumnIndex;
		}
		columnIndex = checked(columnIndex + 1) % ((BaseCollection)((DataGridView)DGV_AC).Columns).Count;
		currentCell = ((DataGridView)DGV_AC).CurrentRow.Cells[columnIndex];
		((DataGridView)DGV_AC).CurrentCell = currentCell;
	}
}
