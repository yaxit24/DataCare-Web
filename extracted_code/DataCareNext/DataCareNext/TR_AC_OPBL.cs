using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_AC_OPBL : Form
{
	private IContainer components;

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
	[AccessedThroughProperty("MSG_TOT")]
	private AxMSFlexGrid _MSG_TOT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_AC")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _MSG_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboBalType")]
	private ComboBox _cboBalType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOpAmt")]
	private TextBox _nOpAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAmt")]
	private ComboBox _cboAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboGold")]
	private ComboBox _cboGold;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOpGoldFine")]
	private TextBox _nOpGoldFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSilver")]
	private ComboBox _cboSilver;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOpSilverFine")]
	private TextBox _nOpSilverFine;

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
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private FlowLayoutPanel _FlowLayoutPanel1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAbTypeMerg")]
	private SimpleButton _btnAbTypeMerg;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private DataTable RsMast1;

	private SqlTransaction Tran;

	private string DataTrfr;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private DataTable VchOldData;

	private double OldValTot;

	private double NewValTot;

	private bool MsgClear;

	private bool UpDown;

	private int MsgOldRow;

	private bool Msgleft;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private long FGRow;

	private const int cSr = 0;

	private const int cVchNo = 1;

	private const int cVchDate = 2;

	private const int cBillNo = 3;

	private const int cDays = 4;

	private const int cItName = 5;

	private const int cItType = 6;

	private const int cGrWt = 7;

	private const int cNetWt = 8;

	private const int cGhatWt = 9;

	private const int cTouch = 10;

	private const int cWestPrc = 11;

	private const int cFineGl = 12;

	private const int cFineSl = 13;

	private const int cDmPcs = 14;

	private const int cDmWt = 15;

	private const int cDmAmt = 16;

	private const int cNetAmt = 17;

	private const int cCrDr = 18;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			KeyEventHandler val2 = new KeyEventHandler(TEXT_ENTRY_KeyUp);
			EventHandler eventHandler = TEXT_ENTRY_GotFocus;
			TextBox val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyUp -= val2;
				((Control)val3).GotFocus -= eventHandler;
			}
			_TEXT_ENTRY = value;
			val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).KeyUp += val2;
				((Control)val3).GotFocus += eventHandler;
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
			EventHandler eventHandler2 = MSG_EnterCell;
			EventHandler eventHandler3 = MSG_LeaveCell;
			EventHandler eventHandler4 = MSG_Scroll;
			EventHandler eventHandler5 = MSG_RowColChange;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.Scroll -= eventHandler4;
				val.RowColChange -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.Scroll += eventHandler4;
				val.RowColChange += eventHandler5;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG_TOT
	{
		[CompilerGenerated]
		get
		{
			return _MSG_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_TOT_Scroll;
			AxMSFlexGrid val = _MSG_TOT;
			if (val != null)
			{
				val.Scroll -= eventHandler;
			}
			_MSG_TOT = value;
			val = _MSG_TOT;
			if (val != null)
			{
				val.Scroll += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private virtual TextBox _tAcName;

	internal virtual TextBox tAcName
	{
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcName = value;
		}
	}

	internal virtual TextBox tAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX MSG_AC
	{
		[CompilerGenerated]
		get
		{
			return _MSG_AC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(MSG_AC_CellFormatting);
			DataGridViewRowPrePaintEventHandler val2 = new DataGridViewRowPrePaintEventHandler(MSG_AC_RowPrePaint);
			EventHandler eventHandler = MSG_AC_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _MSG_AC;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).RowPrePaint -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_MSG_AC = value;
			val3 = _MSG_AC;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).RowPrePaint += val2;
				((Control)val3).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboBalType
	{
		[CompilerGenerated]
		get
		{
			return _cboBalType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyPressEventHandler val = new KeyPressEventHandler(cboBalType_KeyPress);
			EventHandler eventHandler = CboBalType_SelectedIndexChanged;
			ComboBox val2 = _cboBalType;
			if (val2 != null)
			{
				((Control)val2).KeyPress -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboBalType = value;
			val2 = _cboBalType;
			if (val2 != null)
			{
				((Control)val2).KeyPress += val;
				val2.SelectedIndexChanged += eventHandler;
			}
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

	internal virtual TextBox nOpAmt
	{
		[CompilerGenerated]
		get
		{
			return _nOpAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOpAmt_KeyDown);
			KeyPressEventHandler val2 = new KeyPressEventHandler(nOpAmt_KeyPress);
			TextBox val3 = _nOpAmt;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyPress -= val2;
			}
			_nOpAmt = value;
			val3 = _nOpAmt;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).KeyPress += val2;
			}
		}
	}

	internal virtual ComboBox cboAmt
	{
		[CompilerGenerated]
		get
		{
			return _cboAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboAmt_KeyDown);
			ComboBox val2 = _cboAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboAmt = value;
			val2 = _cboAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboGold
	{
		[CompilerGenerated]
		get
		{
			return _cboGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboGold_KeyDown);
			ComboBox val2 = _cboGold;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboGold = value;
			val2 = _cboGold;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nOpGoldFine
	{
		[CompilerGenerated]
		get
		{
			return _nOpGoldFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOpGoldFine_KeyDown);
			KeyPressEventHandler val2 = new KeyPressEventHandler(nOpGoldFine_KeyPress);
			TextBox val3 = _nOpGoldFine;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyPress -= val2;
			}
			_nOpGoldFine = value;
			val3 = _nOpGoldFine;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).KeyPress += val2;
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

	internal virtual ComboBox cboSilver
	{
		[CompilerGenerated]
		get
		{
			return _cboSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboSilver_KeyDown);
			ComboBox val2 = _cboSilver;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboSilver = value;
			val2 = _cboSilver;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nOpSilverFine
	{
		[CompilerGenerated]
		get
		{
			return _nOpSilverFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOpSilverFine_KeyDown);
			KeyPressEventHandler val2 = new KeyPressEventHandler(nOpSilverFine_KeyPress);
			TextBox val3 = _nOpSilverFine;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyPress -= val2;
			}
			_nOpSilverFine = value;
			val3 = _nOpSilverFine;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).KeyPress += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label5")]
	private virtual Label _Label5;

	internal virtual Label Label5
	{
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label5 = value;
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

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = FlowLayoutPanel1_DoubleClick;
			FlowLayoutPanel val = _FlowLayoutPanel1;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_FlowLayoutPanel1 = value;
			val = _FlowLayoutPanel1;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLast")]
	private virtual SimpleButton _BtnLast;

	internal virtual SimpleButton BtnLast
	{
		get
		{
			return _BtnLast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnLast = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnFirst")]
	private virtual SimpleButton _BtnFirst;

	internal virtual SimpleButton BtnFirst
	{
		get
		{
			return _BtnFirst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnFirst = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDataType")]
	private virtual TextBox _tDataType;

	internal virtual TextBox tDataType
	{
		get
		{
			return _tDataType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tDataType = value;
		}
	}

	internal virtual SimpleButton btnAbTypeMerg
	{
		[CompilerGenerated]
		get
		{
			return _btnAbTypeMerg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAbTypeMerg_Click;
			SimpleButton val = _btnAbTypeMerg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAbTypeMerg = value;
			val = _btnAbTypeMerg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public TR_AC_OPBL()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += TR_AC_OPBL_Load;
		((Form)this).Activated += TR_AC_OPBL_Activated;
		((Form)this).Deactivate += TR_AC_OPBL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_AC_OPBL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_AC_OPBL_KeyDown);
		((Form)this).Closed += TR_AC_OPBL_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_AC_OPBL_KeyUp);
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
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Expected O, but got Unknown
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Expected O, but got Unknown
		//IL_07cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Expected O, but got Unknown
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Expected O, but got Unknown
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Expected O, but got Unknown
		//IL_09d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Expected O, but got Unknown
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa2: Expected O, but got Unknown
		//IL_0b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b39: Expected O, but got Unknown
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Expected O, but got Unknown
		//IL_0c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c63: Expected O, but got Unknown
		//IL_0cf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfe: Expected O, but got Unknown
		//IL_0db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Expected O, but got Unknown
		//IL_0e48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e52: Expected O, but got Unknown
		//IL_0ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eed: Expected O, but got Unknown
		//IL_0fbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc5: Expected O, but got Unknown
		//IL_1027: Unknown result type (might be due to invalid IL or missing references)
		//IL_1031: Expected O, but got Unknown
		//IL_115b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c2: Expected O, but got Unknown
		//IL_1226: Unknown result type (might be due to invalid IL or missing references)
		//IL_1230: Expected O, but got Unknown
		//IL_12da: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e4: Expected O, but got Unknown
		//IL_13f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fa: Expected O, but got Unknown
		//IL_1518: Unknown result type (might be due to invalid IL or missing references)
		//IL_1522: Expected O, but got Unknown
		//IL_1586: Unknown result type (might be due to invalid IL or missing references)
		//IL_1590: Expected O, but got Unknown
		//IL_1639: Unknown result type (might be due to invalid IL or missing references)
		//IL_1643: Expected O, but got Unknown
		//IL_16a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b1: Expected O, but got Unknown
		//IL_17b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c0: Expected O, but got Unknown
		//IL_18b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c3: Expected O, but got Unknown
		//IL_19d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19dc: Expected O, but got Unknown
		//IL_1a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a75: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_AC_OPBL));
		lblBook = new Label();
		Label2 = new Label();
		TEXT_ENTRY = new TextBox();
		tAcName = new TextBox();
		tAcCode = new TextBox();
		MSG_AC = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboBalType = new ComboBox();
		Label1 = new Label();
		Label3 = new Label();
		nOpAmt = new TextBox();
		cboAmt = new ComboBox();
		cboGold = new ComboBox();
		nOpGoldFine = new TextBox();
		Label4 = new Label();
		cboSilver = new ComboBox();
		nOpSilverFine = new TextBox();
		Label5 = new Label();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		tDataType = new TextBox();
		btnAbTypeMerg = new SimpleButton();
		((ISupportInitialize)MSG_AC).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(192, 0, 0);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Party Opening";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(15, 41);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(87, 20);
		((Control)Label2).TabIndex = 104;
		Label2.Text = "Party Code";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(535, 148);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 1;
		((Control)TEXT_ENTRY).Visible = false;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tAcName).Location = new Point(194, 41);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(350, 22);
		((Control)tAcName).TabIndex = 1127;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(112, 41);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(78, 22);
		((Control)tAcCode).TabIndex = 0;
		((DataGridView)MSG_AC).AllowUserToAddRows = false;
		((DataGridView)MSG_AC).AllowUserToDeleteRows = false;
		((DataGridView)MSG_AC).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)MSG_AC).BackgroundColor = Color.SeaShell;
		((DataGridView)MSG_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)MSG_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)MSG_AC).ColumnHeadersHeight = 30;
		((DataGridView)MSG_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)MSG_AC).DefaultCellStyle = val3;
		((DataGridView)MSG_AC).EnableHeadersVisualStyles = false;
		((DataGridView)MSG_AC).GridColor = Color.FromArgb(208, 215, 229);
		((Control)MSG_AC).Location = new Point(14, 343);
		((Control)MSG_AC).Name = "MSG_AC";
		MSG_AC.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)MSG_AC).RowHeadersDefaultCellStyle = val4;
		((DataGridView)MSG_AC).RowHeadersVisible = false;
		((DataGridView)MSG_AC).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)MSG_AC).RowsDefaultCellStyle = val5;
		MSG_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		MSG_AC.SelectAllSignVisible = false;
		((DataGridView)MSG_AC).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)MSG_AC).Size = new Size(718, 206);
		((DataGridView)MSG_AC).StandardTab = true;
		((Control)MSG_AC).TabIndex = 1129;
		cboBalType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboBalType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboBalType).FormattingEnabled = true;
		((Control)cboBalType).Location = new Point(126, 311);
		((Control)cboBalType).Name = "cboBalType";
		((Control)cboBalType).Size = new Size(156, 24);
		((Control)cboBalType).TabIndex = 1130;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(18, 311);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(97, 20);
		((Control)Label1).TabIndex = 1131;
		Label1.Text = "Balance Type";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(826, 339);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(142, 20);
		((Control)Label3).TabIndex = 1132;
		Label3.Text = "Opening Amount";
		Label3.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nOpAmt).BackColor = Color.White;
		((Control)nOpAmt).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nOpAmt).Location = new Point(975, 338);
		((TextBoxBase)nOpAmt).MaxLength = 12;
		((Control)nOpAmt).Name = "nOpAmt";
		((Control)nOpAmt).Size = new Size(133, 26);
		((Control)nOpAmt).TabIndex = 2;
		nOpAmt.TextAlign = (HorizontalAlignment)1;
		cboAmt.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboAmt).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboAmt).FormattingEnabled = true;
		((Control)cboAmt).Location = new Point(1114, 337);
		cboAmt.MaxLength = 2;
		((Control)cboAmt).Name = "cboAmt";
		((Control)cboAmt).Size = new Size(60, 26);
		((Control)cboAmt).TabIndex = 3;
		cboGold.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboGold).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboGold).FormattingEnabled = true;
		((Control)cboGold).Location = new Point(1114, 369);
		cboGold.MaxLength = 2;
		((Control)cboGold).Name = "cboGold";
		((Control)cboGold).Size = new Size(60, 26);
		((Control)cboGold).TabIndex = 5;
		((TextBoxBase)nOpGoldFine).BackColor = Color.White;
		((Control)nOpGoldFine).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nOpGoldFine).Location = new Point(975, 370);
		((TextBoxBase)nOpGoldFine).MaxLength = 12;
		((Control)nOpGoldFine).Name = "nOpGoldFine";
		((Control)nOpGoldFine).Size = new Size(133, 26);
		((Control)nOpGoldFine).TabIndex = 4;
		nOpGoldFine.TextAlign = (HorizontalAlignment)1;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(826, 369);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(142, 20);
		((Control)Label4).TabIndex = 1135;
		Label4.Text = "Opening Gold Fine";
		Label4.TextAlign = (ContentAlignment)16;
		cboSilver.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboSilver).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboSilver).FormattingEnabled = true;
		((Control)cboSilver).Location = new Point(1114, 401);
		cboSilver.MaxLength = 2;
		((Control)cboSilver).Name = "cboSilver";
		((Control)cboSilver).Size = new Size(60, 26);
		((Control)cboSilver).TabIndex = 7;
		((TextBoxBase)nOpSilverFine).BackColor = Color.White;
		((Control)nOpSilverFine).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nOpSilverFine).Location = new Point(975, 402);
		((TextBoxBase)nOpSilverFine).MaxLength = 12;
		((Control)nOpSilverFine).Name = "nOpSilverFine";
		((Control)nOpSilverFine).Size = new Size(133, 26);
		((Control)nOpSilverFine).TabIndex = 6;
		nOpSilverFine.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(826, 404);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(142, 20);
		((Control)Label5).TabIndex = 1138;
		Label5.Text = "Opening Silver Fine";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG_TOT).Location = new Point(14, 286);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1153, 16);
		((Control)MSG_TOT).TabIndex = 1123;
		((Control)MSG).Location = new Point(12, 72);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1160, 210);
		((Control)MSG).TabIndex = 1;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 1139;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1215, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 11;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1118, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 10;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
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
		((Control)BtnCancel).TabIndex = 9;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(924, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 8;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(827, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)3;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 40);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(199, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 29;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(152, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 28;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)tDataType).BackColor = Color.White;
		((Control)tDataType).Enabled = false;
		((Control)tDataType).Font = new Font("Tahoma", 9f);
		((Control)tDataType).Location = new Point(550, 42);
		((TextBoxBase)tDataType).MaxLength = 8;
		((Control)tDataType).Name = "tDataType";
		((Control)tDataType).Size = new Size(27, 22);
		((Control)tDataType).TabIndex = 1140;
		tDataType.TextAlign = (HorizontalAlignment)2;
		((Control)tDataType).Visible = false;
		((BaseStyleControl)btnAbTypeMerg).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnAbTypeMerg).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnAbTypeMerg).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnAbTypeMerg).Appearance.Options.UseForeColor = true;
		((Control)btnAbTypeMerg).Location = new Point(1204, 502);
		((BaseControl)btnAbTypeMerg).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnAbTypeMerg).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnAbTypeMerg).Name = "btnAbTypeMerg";
		((Control)btnAbTypeMerg).Size = new Size(99, 37);
		((Control)btnAbTypeMerg).TabIndex = 1141;
		btnAbTypeMerg.Text = "&A/B Merge";
		((BaseButton)btnAbTypeMerg).ToolTipAnchor = (ToolTipAnchor)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).BackgroundImageLayout = (ImageLayout)3;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnAbTypeMerg);
		((Control)this).Controls.Add((Control)(object)tDataType);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)cboSilver);
		((Control)this).Controls.Add((Control)(object)nOpSilverFine);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)cboGold);
		((Control)this).Controls.Add((Control)(object)nOpGoldFine);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboAmt);
		((Control)this).Controls.Add((Control)(object)nOpAmt);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)cboBalType);
		((Control)this).Controls.Add((Control)(object)MSG_AC);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_AC_OPBL";
		((Form)this).Text = "Party Oening";
		((Form)this).WindowState = (FormWindowState)2;
		((ISupportInitialize)MSG_AC).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 19;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr.";
			mSG[1] = (int)Math.Round(1000.0 * ColCon);
			mSG[1] = 3;
			mSG[0, 1] = "VchNo";
			mSG[2] = (int)Math.Round(1300.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "VchDate";
			mSG[3] = (int)Math.Round(1000.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "BillNo";
			mSG[4] = (int)Math.Round(750.0 * ColCon);
			mSG[4] = 3;
			mSG[0, 4] = "Days";
			mSG[5] = (int)Math.Round(2000.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Item Name";
			mSG[6] = (int)Math.Round(800.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "ItType";
			mSG[7] = (int)Math.Round(1000.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "GrWt";
			mSG[8] = (int)Math.Round(1000.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "NetWt";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "GhtWt";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Touch";
			mSG[11] = (int)Math.Round(1000.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "West%";
			mSG[12] = (int)Math.Round(1100.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "Gold Fine";
			mSG[13] = (int)Math.Round(1100.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "Silver Fine";
			mSG[14] = (int)Math.Round(750.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "DmPcs";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "DmWt";
			mSG[16] = (int)Math.Round(1100.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "DmAmt";
			mSG[17] = (int)Math.Round(1200.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "Amount";
			mSG[18] = (int)Math.Round(1100.0 * ColCon);
			mSG[18] = 3;
			mSG[0, 18] = "Cr/Dr";
			mSG.Row = 1;
			mSG.Col = 0;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'AC_OPBL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG[DC_Main.M] = 0;
						}
						mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG = null;
			MSG[1, 2] = Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy");
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num2 = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)
			{
				MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
			}
			MSG_TOT_FILL();
			mSG_TOT = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		UpDown = false;
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
				((Control)TEXT_ENTRY).Focus();
				mSG = null;
			}
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (mSG[mSG.Col] == 0)
			{
				TEXT_ENTRY.Text = "";
				mSG[mSG.Row, mSG.Col] = "";
				DC_Main.M = 1;
				while (mSG[mSG.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG.Col > 1)
						{
							mSG.Col -= 1;
						}
					}
					else if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG.Row == 0) | (mSG.CellWidth <= 0)) && MSG[MSG.Col] != 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
				int col = MSG.Col;
				if (col == 1 || col == 3 || col == unchecked(0 - ((((TextBoxBase)TEXT_ENTRY).MaxLength == 7) ? 1 : 0)))
				{
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 2)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 14)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 6)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 4 || col == 0)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 5)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 100;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 18)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				}
				else if (col == 10 || col == 11 || col == 15 || col == 16 || col == 17)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				}
				else if (col == 7 || col == 8 || col == 9 || col == 12 || col == 13)
				{
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (UpDown || MsgClear || MSG.Row == 0 || MSG[MSG.Col] == 0 || !((Control)TEXT_ENTRY).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG = MSG;
		switch (MSG.Col)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 14:
			MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 18:
			MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			CommPassTotal();
			break;
		case 10:
		case 11:
		case 15:
		case 16:
		case 17:
			MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 7:
			MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			if (Conversion.Val(MSG[mSG.Row, 8]) == 0.0)
			{
				MSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			}
			CommPassTotal();
			break;
		case 8:
		case 9:
		case 12:
		case 13:
			MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal();
			break;
		}
		mSG = null;
	}

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 2] = Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy");
		if (mSG.Row > 1)
		{
			mSG[mSG.Row, 6] = mSG[checked(mSG.Row - 1), 6];
		}
		mSG = null;
	}

	private void CommPassTotal()
	{
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(mSG[mSG.Row, 6], "G", false) == 0)
		{
			if (Conversion.Val(mSG[mSG.Row, 10]) == 0.0)
			{
				mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 8]), "0.000");
			}
			else
			{
				mSG[mSG.Row, 12] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 10]) + Conversion.Val(mSG[mSG.Row, 11])) / 100.0), "0.000");
			}
		}
		else if (Operators.CompareString(mSG[mSG.Row, 6], "S", false) == 0)
		{
			if (Conversion.Val(mSG[mSG.Row, 10]) == 0.0)
			{
				mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 8]), "0.000");
			}
			else
			{
				mSG[mSG.Row, 13] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 10]) + Conversion.Val(mSG[mSG.Row, 11])) / 100.0), "0.000");
			}
		}
		mSG = null;
		MSG_TOT_FILL();
	}

	private void MSG_TOT_FILL()
	{
		if (UpDown)
		{
			return;
		}
		AxMSFlexGrid mSG_TOT = MSG_TOT;
		checked
		{
			int num = MSG.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG_TOT[0, DC_Main.M] = "";
				DC_Main.M++;
			}
			mSG_TOT[0, 5] = "Total :";
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				if (Operators.CompareString(MSG[DC_Main.M, 18], "D", false) == 0)
				{
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) - Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) - Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) - Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					if (Operators.CompareString(MSG[DC_Main.M, 6], "G", false) == 0)
					{
						mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) - Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					}
					if (Operators.CompareString(MSG[DC_Main.M, 6], "S", false) == 0)
					{
						mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) - Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					}
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) - Conversion.Val(MSG[DC_Main.M, 10]))), "0.00");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) - Conversion.Val(MSG[DC_Main.M, 11]))), "0.00");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) - Conversion.Val(MSG[DC_Main.M, 15]))), "0.00");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) - Conversion.Val(MSG[DC_Main.M, 16]))), "0.00");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) - Conversion.Val(MSG[DC_Main.M, 14]))), "0");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) - Conversion.Val(MSG[DC_Main.M, 17]))), "0.00");
				}
				else
				{
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					if (Operators.CompareString(MSG[DC_Main.M, 6], "G", false) == 0)
					{
						mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					}
					if (Operators.CompareString(MSG[DC_Main.M, 6], "S", false) == 0)
					{
						mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					}
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.00");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.00");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.00");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.00");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.00");
				}
				DC_Main.M++;
			}
			if (Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(mSG_TOT[0, 15]) != 0.0)
			{
				if (Conversion.Val(mSG_TOT[0, 17]) > 0.0)
				{
					cboAmt.SelectedIndex = 0;
				}
				else if (Conversion.Val(mSG_TOT[0, 17]) < 0.0)
				{
					cboAmt.SelectedIndex = 1;
				}
				nOpAmt.Text = Strings.Format((object)Math.Abs(Conversion.Val(mSG_TOT[0, 17])), "0.00");
				if (Conversion.Val(mSG_TOT[0, 12]) > 0.0)
				{
					cboGold.SelectedIndex = 0;
				}
				else if (Conversion.Val(mSG_TOT[0, 12]) < 0.0)
				{
					cboGold.SelectedIndex = 1;
				}
				nOpGoldFine.Text = Strings.Format((object)Math.Abs(Conversion.Val(mSG_TOT[0, 12])), "0.000");
				if (Conversion.Val(mSG_TOT[0, 13]) > 0.0)
				{
					cboSilver.SelectedIndex = 0;
				}
				else if (Conversion.Val(mSG_TOT[0, 13]) < 0.0)
				{
					cboSilver.SelectedIndex = 1;
				}
				nOpSilverFine.Text = Strings.Format((object)Math.Abs(Conversion.Val(mSG_TOT[0, 13])), "0.000");
			}
			else if (MSG.Rows > 2)
			{
				nOpAmt.Text = "";
				nOpGoldFine.Text = "";
				nOpSilverFine.Text = "";
			}
			NewValTot = Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text);
			mSG_TOT = null;
		}
	}

	private void TOTAL_FILL()
	{
	}

	private void TR_AC_OPBL_Load(object sender, EventArgs e)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0b85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b94: Expected O, but got Unknown
		//IL_0bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected O, but got Unknown
		//IL_0c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c65: Expected O, but got Unknown
		//IL_0c84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c93: Expected O, but got Unknown
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Expected O, but got Unknown
		//IL_0d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Expected O, but got Unknown
		//IL_0dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de9: Expected O, but got Unknown
		//IL_0e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e80: Expected O, but got Unknown
		//IL_0ef2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efd: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		DC_Main.MCo_Book = "000";
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
				if (val is AxMSFlexGrid)
				{
					Control val2;
					(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
					(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
					(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
					(val2 = val).Top = val2.Top + ((int)Math.Round((double)val.Top * num2) + (int)Math.Round((double)val.Top / 15.0));
				}
				else
				{
					Control val2;
					(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
					(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
					(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
					(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num2);
				}
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
			((Control)MSG_TOT).Top = ((Control)MSG).Bottom + 1;
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj7 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj8 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj9 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj10 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj11 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((DataGridView)MSG_AC).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj14 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj16 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj19 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX mSG_AC = MSG_AC;
				object? obj21 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)mSG_AC).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj24 = lblBook;
				object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj26 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX mSG_AC2 = MSG_AC;
				object? obj27 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)mSG_AC2).BackgroundColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle;
				object? obj28 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj29 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj30 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj31 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj33 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj34 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				ComboBox obj35 = cboBalType;
				object? obj36 = colorConverter.ConvertFromString("Cornsilk");
				obj35.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
			}
			((Control)this).Dock = (DockStyle)5;
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
					((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)MSG_AC).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)MSG_AC).Font.Style);
					((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)MSG_AC).Font.Style);
					((DataGridView)MSG_AC).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)MSG_AC).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)MSG_AC).RowTemplate.Height = (int)Math.Round((double)((DataGridView)MSG_AC).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)tAcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcCode).Font;
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
			cboAmt.Items.Add((object)"Cr");
			cboAmt.Items.Add((object)"Dr");
			cboAmt.SelectedIndex = 0;
			cboGold.Items.Add((object)"Cr");
			cboGold.Items.Add((object)"Dr");
			cboGold.SelectedIndex = 0;
			cboSilver.Items.Add((object)"Cr");
			cboSilver.Items.Add((object)"Dr");
			cboSilver.SelectedIndex = 0;
			cboBalType.Items.Add((object)"Amount");
			cboBalType.Items.Add((object)"Gold");
			cboBalType.Items.Add((object)"Silver");
			cboBalType.SelectedIndex = 0;
			CLEAR_DATA();
			OpStk_Val();
			EntryMode = "A";
			CurActCtrl = (Control)(object)tAcCode;
		}
	}

	private void TR_AC_OPBL_Activated(object sender, EventArgs e)
	{
		DC_Main.MCo_Book = "000";
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void MSG_AC_CLEAR()
	{
		((DataGridView)MSG_AC).DataSource = null;
		((DataGridView)MSG_AC).Columns.Clear();
		((DataGridView)MSG_AC).Rows.Clear();
		((Control)MSG_AC).Refresh();
	}

	private void MSG_AC_FILL()
	{
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Expected O, but got Unknown
		MSG_AC_CLEAR();
		if (cboBalType.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,CASE WHEN OP_SIGN = 'C' THEN OP_AMT ELSE 0 END AS CrAmt,CASE WHEN OP_SIGN = 'D' THEN OP_AMT ELSE 0 END AS DrAmt,  B.AC_GR,B.AC_NAME FROM OP_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '000' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.OP_AMT <> 0 ORDER BY B.AC_GR,B.AC_NAME "));
		}
		else if (cboBalType.SelectedIndex == 1)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,CASE WHEN FINE_SIGN = 'C' THEN FINE_BAL ELSE 0 END AS CrAmt,CASE WHEN FINE_SIGN = 'D' THEN FINE_BAL ELSE 0 END AS DrAmt,  B.AC_GR,B.AC_NAME FROM OP_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '000' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.FINE_BAL <> 0 ORDER BY B.AC_GR,B.AC_NAME "));
		}
		else if (cboBalType.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,CASE WHEN SL_FINE_SIGN = 'C' THEN SL_FINE_BAL ELSE 0 END AS CrAmt,CASE WHEN SL_FINE_SIGN = 'D' THEN SL_FINE_BAL ELSE 0 END AS DrAmt,  B.AC_GR,B.AC_NAME FROM OP_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '000' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.DATA_TYPE = '"), (object)tDataType.Text), (object)"' AND A.SL_FINE_BAL <> 0 ORDER BY B.AC_GR,B.AC_NAME "));
		}
		RsMast1 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsMast1);
		checked
		{
			if (dataView.Count == 0)
			{
				((DataGridView)MSG_AC).MultiSelect = false;
				((DataGridView)MSG_AC).AutoGenerateColumns = false;
				((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)MSG_AC).ColumnCount = 6;
				((DataGridView)MSG_AC).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
				((DataGridView)MSG_AC).Columns[0].HeaderText = "Sr.";
				((DataGridView)MSG_AC).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)MSG_AC).Columns[1].HeaderText = "AcGr";
				((DataGridView)MSG_AC).Columns[2].Width = (int)Math.Round(350.0 * ColCon);
				((DataGridView)MSG_AC).Columns[3].HeaderText = "Account Name";
				((DataGridView)MSG_AC).Columns[3].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)MSG_AC).Columns[3].HeaderText = "Dr Balance";
				((DataGridView)MSG_AC).Columns[4].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)MSG_AC).Columns[4].HeaderText = "Cr Balance";
				((DataGridView)MSG_AC).Columns[5].Visible = false;
				((DataGridView)MSG_AC).Columns[5].HeaderText = "Ac Code";
				((DataGridView)MSG_AC).Rows.Add(new object[4] { 1, "", 0, 0 });
			}
			if (dataView.Count > 0)
			{
				((DataGridView)MSG_AC).MultiSelect = false;
				((DataGridView)MSG_AC).AutoGenerateColumns = false;
				((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)MSG_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)MSG_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)MSG_AC).ColumnCount = 6;
				((DataGridView)MSG_AC).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
				((DataGridView)MSG_AC).Columns[0].DataPropertyName = Conversions.ToString(((DataGridView)MSG_AC).Rows.Count + 1);
				((DataGridView)MSG_AC).Columns[0].HeaderText = "Sr.";
				((DataGridView)MSG_AC).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)MSG_AC).Columns[1].DataPropertyName = "AC_GR";
				((DataGridView)MSG_AC).Columns[1].HeaderText = "AcGr";
				((DataGridView)MSG_AC).Columns[1].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)MSG_AC).Columns[2].Width = (int)Math.Round(350.0 * ColCon);
				((DataGridView)MSG_AC).Columns[2].DataPropertyName = "AC_NAME";
				((DataGridView)MSG_AC).Columns[2].HeaderText = "Account Name";
				((DataGridView)MSG_AC).Columns[3].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)MSG_AC).Columns[3].DataPropertyName = "DrAmt";
				((DataGridView)MSG_AC).Columns[3].HeaderText = "Dr Balance";
				((DataGridView)MSG_AC).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				if (cboBalType.SelectedIndex == 0)
				{
					((DataGridView)MSG_AC).Columns[3].DefaultCellStyle.Format = "N2";
				}
				else
				{
					((DataGridView)MSG_AC).Columns[3].DefaultCellStyle.Format = "N3";
				}
				((DataGridView)MSG_AC).Columns[4].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)MSG_AC).Columns[4].DataPropertyName = "CrAmt";
				((DataGridView)MSG_AC).Columns[4].HeaderText = "Cr Balance";
				((DataGridView)MSG_AC).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				if (cboBalType.SelectedIndex == 0)
				{
					((DataGridView)MSG_AC).Columns[4].DefaultCellStyle.Format = "N2";
				}
				else
				{
					((DataGridView)MSG_AC).Columns[4].DefaultCellStyle.Format = "N3";
				}
				((DataGridView)MSG_AC).Columns[5].Visible = false;
				((DataGridView)MSG_AC).Columns[5].DataPropertyName = "AC_CODE";
				((DataGridView)MSG_AC).Columns[5].HeaderText = "Ac Code";
				dataView.AddNew();
				dataView.AddNew();
				dataView.AddNew();
				((DataGridView)MSG_AC).DataSource = dataView;
				double num = 0.0;
				double num2 = 0.0;
				int num3 = ((DataGridView)MSG_AC).Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)MSG_AC).Rows[i].Cells[3].Value, (object)""));
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)MSG_AC).Rows[i].Cells[4].Value, (object)""));
				}
				int num4 = ((DataGridView)MSG_AC).Rows.Count - 2;
				((DataGridView)MSG_AC).Rows[num4].Cells[2].Value = "Total :";
				((DataGridView)MSG_AC).Rows[num4].Cells[3].Value = num2;
				((DataGridView)MSG_AC).Rows[num4].Cells[4].Value = num;
				int num5 = ((DataGridView)MSG_AC).Rows.Count - 1;
				((DataGridView)MSG_AC).Rows[num5].Cells[2].Value = "Differenc :";
				if (num2 > num)
				{
					((DataGridView)MSG_AC).Rows[num5].Cells[4].Value = num2 - num;
				}
				else if (num2 < num)
				{
					((DataGridView)MSG_AC).Rows[num5].Cells[3].Value = num - num2;
				}
			}
		}
	}

	private void MSG_AC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 3) <= 1u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 103:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009d;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 103;
				continue;
			}
			break;
			IL_009d:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
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
		DataTrfr = "N";
		OldValTot = 0.0;
		NewValTot = 0.0;
		MSG_CLEAR();
		CommPassAdd();
		cboAmt.SelectedIndex = 0;
		cboGold.SelectedIndex = 0;
		cboSilver.SelectedIndex = 0;
		if (VchOldData != null)
		{
			VchOldData.Clear();
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				((Control)tDataType).Visible = true;
				tDataType.Text = "B";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				((Control)tDataType).Visible = true;
				tDataType.Text = "A";
			}
			else
			{
				((Control)tDataType).Visible = true;
				tDataType.Text = "A";
			}
		}
		else
		{
			tDataType.Text = "A";
		}
		MSG_AC_FILL();
		EntryMode = "A";
		((Control)tAcCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsDataType, "", false) == 0)
		{
			Interaction.MsgBox((object)"Plese Select Data Type A or B then Try...", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "' ";
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			VchOldData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsMast.Rows.Count <= 0)
		{
			return;
		}
		tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsMast.Rows[0]["AC_CODE"], (object)""));
		MainUser = Conversions.ToString(Operators.ConcatenateObject(RsMast.Rows[0]["MAIN_USER"], (object)""));
		DataTrfr = Conversions.ToString(Operators.ConcatenateObject(RsMast.Rows[0]["DATA_TRFR"], (object)""));
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " AC_CODE = '" + tAcCode.Text + "'";
		if (dataView.Count > 0)
		{
			DataView dataView2 = dataView;
			nOpAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["OP_AMT"]), "0.00");
			if (Operators.ConditionalCompareObjectEqual(dataView2[0]["OP_SIGN"], (object)"C", false))
			{
				cboAmt.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["OP_SIGN"], (object)"D", false))
			{
				cboAmt.SelectedIndex = 1;
			}
			nOpGoldFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["FINE_BAL"]), "0.000");
			if (Operators.ConditionalCompareObjectEqual(dataView2[0]["FINE_SIGN"], (object)"C", false))
			{
				cboGold.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["FINE_SIGN"], (object)"D", false))
			{
				cboGold.SelectedIndex = 1;
			}
			nOpSilverFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["SL_FINE_BAL"]), "0.000");
			if (Operators.ConditionalCompareObjectEqual(dataView2[0]["SL_FINE_SIGN"], (object)"C", false))
			{
				cboSilver.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(dataView2[0]["SL_FINE_SIGN"], (object)"D", false))
			{
				cboSilver.SelectedIndex = 1;
			}
			dataView2 = null;
		}
		OldValTot = Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text);
		NewValTot = Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text);
		MSG_CLEAR();
		DC_Main.RsQry = "SELECT * FROM OP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  AC_CODE = '" + tAcCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"], (object)""));
				mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_DATE"], (object)""));
				mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["BILL_NO"], (object)""));
				mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CR_DAYS"], (object)""));
				mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_DESC"], (object)""));
				mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"]), "0.000");
				mSG[DC_Main.i + 1, 8] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"]), "0.000");
				mSG[DC_Main.i + 1, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHTWT"]), "0.00");
				mSG[DC_Main.i + 1, 10] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"]), "0.00");
				mSG[DC_Main.i + 1, 11] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST"]), "0.00");
				mSG[DC_Main.i + 1, 12] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GL_FINE"]), "0.000");
				mSG[DC_Main.i + 1, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SL_FINE"]), "0.000");
				mSG[DC_Main.i + 1, 14] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_PCS"], (object)""));
				mSG[DC_Main.i + 1, 15] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["DM_WT"]), "0.00");
				mSG[DC_Main.i + 1, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["DM_AMT"]), "0.00");
				mSG[DC_Main.i + 1, 17] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"]), "0.00");
				mSG[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIGN"], (object)""));
				mSG.Rows += 1;
				DC_Main.i++;
			}
			mSG[1, 0] = Conversions.ToString(1);
			if (mSG.Rows > 2)
			{
				mSG.Rows -= 1;
			}
			mSG = null;
			MSG_TOT_FILL();
			EntryMode = "E";
			((TextBoxBase)tAcCode).ReadOnly = true;
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
		//IL_0b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tDataType.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Data Type = A or Data Type = B and try You Cant Change in Data Type = C ....", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			if (MSG.Rows > 1)
			{
				int num = MSG.Rows - 2;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if (Operators.CompareString(MSG[DC_Main.M, 1], "", false) == 0)
					{
						((Control)tAcCode).Focus();
						Interaction.MsgBox((object)"Please Insert Vch No and Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
					if (Conversion.Val(MSG[DC_Main.M, 12]) + Conversion.Val(MSG[DC_Main.M, 13]) + Conversion.Val(MSG[DC_Main.M, 17]) == 0.0)
					{
						((Control)tAcCode).Focus();
						Interaction.MsgBox((object)"Please Insert Gold fine or Silver fine or Net Amount and try...", (MsgBoxStyle)0, (object)null);
						return;
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(tAcCode.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Enter Party First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				return;
			}
			MSG_TOT_FILL();
			Tran = null;
			try
			{
				if (DC_Main.Dc.State != ConnectionState.Open)
				{
					DC_Main.Dc.Open();
				}
				Tran = DC_Main.Dc.BeginTransaction();
				DC_Main.RsQry = "DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Tran);
				DC_Main.RsQry = "DELETE FROM OP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  AC_CODE = '" + tAcCode.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Tran);
				DC_Main.RsQry = "SELECT * FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "' ";
				RsData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Tran);
				Module_Save.MsInsertDataSave(Tran);
				DataRow dataRow = RsData.NewRow();
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["LC_CODE"] = DC_Main.MLc_code;
				dataRow["CO_YEAR"] = DC_Main.MCo_year;
				dataRow["CO_BOOK"] = "000";
				dataRow["VCH_NO"] = "00000";
				dataRow["AC_CODE"] = tAcCode.Text;
				dataRow["OP_AMT"] = Conversion.Val(nOpAmt.Text);
				dataRow["OP_SIGN"] = Strings.Mid(cboAmt.Text, 1, 1);
				dataRow["FINE_BAL"] = Conversion.Val(nOpGoldFine.Text);
				dataRow["FINE_SIGN"] = Strings.Mid(cboGold.Text, 1, 1);
				dataRow["SL_FINE_BAL"] = Conversion.Val(nOpSilverFine.Text);
				dataRow["SL_FINE_SIGN"] = Strings.Mid(cboSilver.Text, 1, 1);
				dataRow["DATA_TYPE"] = tDataType.Text;
				if (Operators.CompareString(DataTrfr, "", false) == 0)
				{
					DataTrfr = "N";
				}
				dataRow["DATA_TRFR"] = DataTrfr;
				dataRow["MAIN_USER"] = MainUser;
				RsData.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
				RsData.Clear();
				DC_Main.RsQry = "SELECT * FROM OP_DETL WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  AC_CODE = '" + tAcCode.Text + "' ";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Tran);
				Module_Save.MsInsertDataSave(Tran);
				DataRow dataRow2 = RsDetl.NewRow();
				int num2 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					if ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 7]) + Conversion.Val(MSG[DC_Main.i, 12]) + Conversion.Val(MSG[DC_Main.i, 13]) + Conversion.Val(MSG[DC_Main.i, 17]) + Conversion.Val(MSG[DC_Main.i, 15]) != 0.0))
					{
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						dataRow2["LC_CODE"] = DC_Main.MLc_code;
						dataRow2["CO_YEAR"] = DC_Main.MCo_year;
						dataRow2["CO_BOOK"] = "000";
						dataRow2["AC_CODE"] = tAcCode.Text;
						dataRow2["SR_NO"] = Conversion.Val(MSG[DC_Main.i, 0]);
						dataRow2["VCH_NO"] = MSG[DC_Main.i, 1];
						dataRow2["VCH_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(MSG[DC_Main.i, 2], "", false) == 0, (object)DBNull.Value, (object)MSG[DC_Main.i, 2]));
						dataRow2["BILL_NO"] = MSG[DC_Main.i, 3];
						dataRow2["CR_DAYS"] = Conversion.Val(MSG[DC_Main.i, 4]);
						dataRow2["ITM_TYPE"] = MSG[DC_Main.i, 6];
						dataRow2["ITM_DESC"] = MSG[DC_Main.i, 5];
						dataRow2["ITM_GWT"] = Conversion.Val(MSG[DC_Main.i, 7]);
						dataRow2["ITM_NWT"] = Conversion.Val(MSG[DC_Main.i, 8]);
						dataRow2["ITM_GHTWT"] = Conversion.Val(MSG[DC_Main.i, 9]);
						dataRow2["ITM_TOUCH"] = Conversion.Val(MSG[DC_Main.i, 10]);
						dataRow2["ITM_WEST"] = Conversion.Val(MSG[DC_Main.i, 11]);
						dataRow2["ITM_GL_FINE"] = Conversion.Val(MSG[DC_Main.i, 12]);
						dataRow2["ITM_SL_FINE"] = Conversion.Val(MSG[DC_Main.i, 13]);
						dataRow2["DM_PCS"] = Conversion.Val(MSG[DC_Main.i, 14]);
						dataRow2["DM_WT"] = Conversion.Val(MSG[DC_Main.i, 15]);
						dataRow2["DM_AMT"] = Conversion.Val(MSG[DC_Main.i, 16]);
						dataRow2["ITM_AMT"] = Conversion.Val(MSG[DC_Main.i, 17]);
						dataRow2["ITM_SIGN"] = MSG[DC_Main.i, 18];
						dataRow2["MAIN_USER"] = MainUser;
						RsDetl.Rows.Add(dataRow2);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					DC_Main.i++;
				}
				Tran.Commit();
				Module_Save.TranPosting = null;
				try
				{
					if (DC_Main.Dc.State != ConnectionState.Open)
					{
						DC_Main.Dc.Open();
					}
					Module_Save.TranPosting = DC_Main.Dc.BeginTransaction();
					DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "' ";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TranPosting);
					Ac_Ledr.AcOp_Ledr(tAcCode.Text, tDataType.Text);
					Module_Save.TranPosting.Commit();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					try
					{
						Module_Save.TranPosting.Rollback();
						Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						Interaction.MsgBox((object)("Rollback Failed: " + ex4.Message), (MsgBoxStyle)0, (object)null);
						ProjectData.ClearProjectError();
					}
					((Control)BtnSave).Enabled = true;
					ProjectData.ClearProjectError();
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
				{
					DC_Main.RsQry = "SELECT * FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "' ";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.TableCol();
					string text = "";
					int num3 = RsData.Columns.Count - 2;
					DC_Main.M = 0;
					while (DC_Main.M <= num3)
					{
						if (VchOldData.Rows.Count > 0 && Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
						{
							int num4 = DC_Main.RsTblCol.Rows.Count - 1;
							for (int i = 0; i <= num4; i++)
							{
								if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[i]["TBL_COL_NAME"], false))
								{
									text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[i]["COL_NAME"], (object)""));
								}
							}
							if (Operators.CompareString(text, "", false) == 0)
							{
								text = RsData.Columns[DC_Main.M].ColumnName;
							}
							DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000','" + tAcCode.Text + "','" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','OPSTK','" + text + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','N')";
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							text = "";
						}
						DC_Main.M++;
					}
					DC_Main.RsTblCol.Clear();
				}
				Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				try
				{
					Tran.Rollback();
					Interaction.MsgBox((object)("Error: " + ex6.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					Interaction.MsgBox((object)("Rollback Failed: " + ex8.Message), (MsgBoxStyle)0, (object)null);
					ProjectData.ClearProjectError();
				}
				((Control)BtnSave).Enabled = true;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Account Details.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,'" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','OPBAL','" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  'Ac OpBal',A.AC_CODE,C.AC_NAME,CASE WHEN OP_SIGN = 'D' THEN OP_AMT ELSE 0 END,CASE WHEN OP_SIGN = 'C' THEN OP_AMT ELSE 0 END,CASE WHEN FINE_BAL <> 0 THEN 'G' ELSE 'A' END,CASE WHEN FINE_SIGN = 'D' THEN FINE_BAL ELSE 0 END,CASE WHEN FINE_SIGN = 'C' THEN FINE_BAL ELSE 0 END,VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',''   FROM OP_DATA AS A LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '000' AND A.AC_CODE = '" + tAcCode.Text + "' AND OP_AMT + FINE_BAL <> 0  ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,1,'" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','OPBAL','" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  'Ac OpBal',A.AC_CODE,C.AC_NAME,0,0,'S',CASE WHEN SL_FINE_SIGN = 'D' THEN SL_FINE_BAL ELSE 0 END,CASE WHEN SL_FINE_SIGN = 'C' THEN SL_FINE_BAL ELSE 0 END,VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',''  FROM OP_DATA AS A LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '000' AND A.AC_CODE = '" + tAcCode.Text + "' AND SL_FINE_BAL <> 0 ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM OP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + tDataType.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			EntryMode = "A";
			((Control)tAcCode).Focus();
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void TR_AC_OPBL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_AC_OPBL_KeyPress(object sender, KeyPressEventArgs e)
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

	private void TR_AC_OPBL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
			else if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 0;
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
				((Control)BtnSave).Focus();
			}
			else
			{
				((Control)BtnSave).Enabled = true;
				((Control)BtnSave).Focus();
			}
		}
	}

	private void MSG_TOT_Scroll(object sender, EventArgs e)
	{
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MsgOldRow != MSG.Row)
		{
			MsgOldRow = MSG.Row;
		}
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.LC_CODE,A.AC_NAME";
				}
				else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[8];
				DC_Main.ColWidth[0] = 270.0;
				DC_Main.ColWidth[1] = 80.0;
				DC_Main.ColWidth[2] = 170.0;
				DC_Main.ColWidth[3] = 180.0;
				DC_Main.ColWidth[4] = 220.0;
				DC_Main.ColWidth[5] = 160.0;
				DC_Main.ColWidth[6] = 110.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (DC_Main.MsCreat)
				{
					MS_ACCT mS_ACCT = new MS_ACCT();
					((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)mS_ACCT).Show();
					((Control)mS_ACCT).Focus();
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
					DISPLAY_DATA();
				}
				((Control)tAcCode).Focus();
				return;
			}
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DISPLAY_DATA();
			SendKeys.Send("{tab}");
		}
		if ((int)e.KeyCode == 13)
		{
			if (MSG.Rows > 1)
			{
				MSG.Col = 1;
				MSG.Row = 1;
			}
			else
			{
				((Control)nOpAmt).Focus();
			}
		}
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
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
						UpDown = true;
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col < mSG.Cols - 1)
					{
						UpDown = true;
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						UpDown = true;
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						UpDown = true;
						mSG.Row += 1;
					}
					return;
				}
			}
			else
			{
				switch (mSG.Col)
				{
				case 1:
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
					{
						((Control)TEXT_ENTRY).Visible = false;
						((Control)nOpAmt).Focus();
						return;
					}
					break;
				case 2:
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
					{
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					break;
				case 6:
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
					{
						Interaction.MsgBox((object)"Please insert ItmType  G = Gold S = Silver Or A = Amount and try", (MsgBoxStyle)0, (object)null);
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					break;
				case 18:
					if ((Operators.CompareString(TEXT_ENTRY.Text, "C", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "D", false) != 0))
					{
						Interaction.MsgBox((object)"Please Enter C or D and Try Again...", (MsgBoxStyle)0, (object)null);
					}
					else if (mSG.Row == mSG.Rows - 1)
					{
						mSG.Rows += 1;
						mSG.Row += 1;
						CommPassAdd();
						mSG.Col = 1;
					}
					else
					{
						mSG.Row += 1;
						mSG.Col = 1;
						((Control)TEXT_ENTRY).Visible = true;
						((Control)TEXT_ENTRY).Focus();
					}
					return;
				}
				if (mSG.Col < mSG.Cols - 1)
				{
					MSG.Col += 1;
				}
				((Control)TEXT_ENTRY).Visible = true;
				((Control)TEXT_ENTRY).Focus();
			}
			mSG = null;
		}
	}

	private void nOpAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nOpAmt.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nOpAmt.Text = Strings.Format((object)Convert.ToDouble(nOpAmt.Text), "0.00");
			NewValTot = Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text);
			SendKeys.Send("{TAB}");
		}
	}

	private void nOpGoldFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nOpGoldFine.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nOpGoldFine.Text = Strings.Format((object)Convert.ToDouble(nOpGoldFine.Text), "0.000");
			NewValTot = Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text);
			SendKeys.Send("{TAB}");
		}
	}

	private void nOpSilverFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nOpSilverFine.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nOpSilverFine.Text = Strings.Format((object)Convert.ToDouble(nOpSilverFine.Text), "0.000");
			NewValTot = Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text);
			SendKeys.Send("{TAB}");
		}
	}

	private void cboAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboGold_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboSilver_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void cboBalType_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = true;
	}

	private void MSG_AC_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			((DataGridView)MSG_AC).Rows[e.RowIndex].Cells[0].Value = checked(e.RowIndex + 1);
		}
	}

	private void TR_AC_OPBL_Closed(object sender, EventArgs e)
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

	private void MSG_AC_DoubleClick(object sender, EventArgs e)
	{
		tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)MSG_AC).CurrentRow.Cells[5].Value, (object)""));
		tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)MSG_AC).CurrentRow.Cells[2].Value, (object)""));
		DISPLAY_DATA();
		((Control)tAcCode).Focus();
	}

	private void CboBalType_SelectedIndexChanged(object sender, EventArgs e)
	{
		MSG_AC_FILL();
	}

	private void nOpAmt_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (((Strings.Asc(e.KeyChar) != 8) & (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", false) != 0)) && ((Strings.Asc(e.KeyChar) < 48) | (Strings.Asc(e.KeyChar) > 57)))
		{
			e.Handled = true;
		}
	}

	private void nOpGoldFine_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (((Strings.Asc(e.KeyChar) != 8) & (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", false) != 0)) && ((Strings.Asc(e.KeyChar) < 48) | (Strings.Asc(e.KeyChar) > 57)))
		{
			e.Handled = true;
		}
	}

	private void nOpSilverFine_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (((Strings.Asc(e.KeyChar) != 8) & (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", false) != 0)) && ((Strings.Asc(e.KeyChar) < 48) | (Strings.Asc(e.KeyChar) > 57)))
		{
			e.Handled = true;
		}
	}

	private void TEXT_ENTRY_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		if (MSG.Col == 2 && (int)e.KeyCode != 8)
		{
			if (Strings.Len(TEXT_ENTRY.Text) == 2)
			{
				TEXT_ENTRY.Text += "/";
			}
			else if (Strings.Len(TEXT_ENTRY.Text) == 5)
			{
				TEXT_ENTRY.Text += "/";
			}
			if (Strings.Len(TEXT_ENTRY.Text) != 10)
			{
				((TextBoxBase)TEXT_ENTRY).SelectionStart = Strings.Len(TEXT_ENTRY.Text);
			}
		}
	}

	private void TEXT_ENTRY_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
		((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
	}

	private void OpStk_Val()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 1 && (int)Interaction.MsgBox((object)"Are You Sure To insert Opning blance Entry In Contra Data  Location Wise...?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = "SELECT MAX((VCH_NO)) AS CoCode  From CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '017' HAVING MAX((VCH_NO)) > 0";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = ((DC_Main.Rshlp.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000") : "00001");
		DC_Main.RsQry = "SELECT * FROM BAL_GR WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY CLG_AC";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		checked
		{
			while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TYPE = 'A' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CLG_AC"]), (object)"'"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '017' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CLG_AC"]), (object)"' AND CRDR_TYPE = 'Cr' AND VCH_DATE = '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"'"));
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CONTRA_DATA SET CR_AMT = ", dataTable.Rows[0]["OP_AMT"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' And CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CLG_AC"]), (object)"' AND CRDR_TYPE = 'Cr'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CONTRA_DATA SET DR_AMT = ", dataTable.Rows[0]["OP_AMT"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.i]["OP_AC"]), (object)"' AND CRDR_TYPE = 'Dr'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND  VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"'")));
						Ac_Ledr.Contra_Ledr(Conversions.ToString(dataTable2.Rows[0]["CO_BOOK"]), Conversions.ToString(dataTable2.Rows[0]["VCH_NO"]));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO CONTRA_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,DR_AMT,CR_AMT,CRDR_TYPE,IT_DESC,LDR_TYPE,EMP_CODE,DATA_TRFR,HD_VCH_NO,CR_FINE,DR_FINE,IT_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','017','" + text + "',1,'" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','JV','O','J','" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','CONTRA',  '"), DC_Main.Rshlp.Rows[DC_Main.i]["CLG_AC"]), (object)"','','"), DC_Main.Rshlp.Rows[DC_Main.i]["OP_AC"]), (object)"',0,"), dataTable.Rows[0]["OP_AMT"]), (object)",'Cr','',0,'001','N','"), (object)text), (object)"',0,0,'A')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO CONTRA_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,  AC_CODE,AC_NAME,LD_CODE,DR_AMT,CR_AMT,CRDR_TYPE,IT_DESC,LDR_TYPE,EMP_CODE,DATA_TRFR,HD_VCH_NO,CR_FINE,DR_FINE,IT_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','017','" + text + "',2,'" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','JV','O','J','" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "','CONTRA',  '"), DC_Main.Rshlp.Rows[DC_Main.i]["OP_AC"]), (object)"','','"), DC_Main.Rshlp.Rows[DC_Main.i]["CLG_AC"]), (object)"',"), dataTable.Rows[0]["OP_AMT"]), (object)",0,'Dr','',1,'001','N','"), (object)text), (object)"',0,0,'A')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '017' AND  VCH_NO = '" + text + "'");
						Ac_Ledr.Contra_Ledr("017", text);
						text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
		}
	}

	private void TR_AC_OPBL_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
	}

	private void btnAbTypeMerg_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"A And B Data Merge Transfer...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,'A' As DataType,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '000'  GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  ORDER BY A.AC_CODE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["GoldWt"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SilverWt"]))) != 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" "), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["Amount"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["GoldWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["GoldWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SilverWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["SilverWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["DataType"]), (object)"','"), (object)DC_Main.MCo_User), (object)"','',NULL,'Y')"));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				Application.DoEvents();
			}
			Interaction.MsgBox((object)"Data is Merge Pleas Refresh Data and Check....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void FlowLayoutPanel1_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnAbTypeMerg).Visible = true;
	}
}
