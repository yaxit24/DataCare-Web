using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_RATE : Form
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
	[AccessedThroughProperty("nSilverRate")]
	private TextBox _nSilverRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGoldRate")]
	private TextBox _nGoldRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mVchDate")]
	private MaskedTextBox _mVchDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGoldOzRate")]
	private TextBox _nGoldOzRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSilverOzRate")]
	private TextBox _nSilverOzRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPrSilverRate")]
	private TextBox _nPrSilverRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPrGoldRate")]
	private TextBox _nPrGoldRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	private string EntryMode;

	private Control CurActCtrl;

	private bool MsgClear;

	private bool UpDown;

	private int MsgOldRow;

	private bool Msgleft;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldGoldRate;

	private double OldSlRate;

	private double OldPrGoldRate;

	private double OldPrSlRate;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private long FGRow;

	private const int cSrNo = 0;

	private const int cGrCode = 1;

	private const int cGrName = 2;

	private const int cTouch = 3;

	private const int cTaxPrc = 4;

	private const int cIncTaxRate = 5;

	private const int cTaxRate = 6;

	private const int cPrTouch = 7;

	private const int cPrRate = 8;

	private const int cGrType = 9;

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
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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
			EventHandler eventHandler4 = MSG_RowColChange;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
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

	internal virtual TextBox nSilverRate
	{
		[CompilerGenerated]
		get
		{
			return _nSilverRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSilverRate_KeyDown);
			EventHandler eventHandler = nSilverRate_TextChanged;
			TextBox val2 = _nSilverRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nSilverRate = value;
			val2 = _nSilverRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label10")]
	private virtual Label _Label10;

	internal virtual Label Label10
	{
		get
		{
			return _Label10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label10 = value;
		}
	}

	internal virtual TextBox nGoldRate
	{
		[CompilerGenerated]
		get
		{
			return _nGoldRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldRate_KeyDown);
			TextBox val2 = _nGoldRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGoldRate = value;
			val2 = _nGoldRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label11")]
	private virtual Label _Label11;

	internal virtual Label Label11
	{
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual MaskedTextBox mVchDate
	{
		[CompilerGenerated]
		get
		{
			return _mVchDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mVchDate_KeyDown);
			MaskedTextBox val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mVchDate = value;
			val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBDate")]
	private virtual Label _lblBDate;

	internal virtual Label lblBDate
	{
		get
		{
			return _lblBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBDate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private virtual TextBox _tEmpCode;

	internal virtual TextBox tEmpCode
	{
		get
		{
			return _tEmpCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tEmpCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpName")]
	private virtual TextBox _tEmpName;

	internal virtual TextBox tEmpName
	{
		get
		{
			return _tEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tEmpName = value;
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

	internal virtual SimpleButton BtnF1
	{
		[CompilerGenerated]
		get
		{
			return _BtnF1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnF1_Click;
			SimpleButton val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnF1 = value;
			val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Cr")]
	private virtual AxCrystalReport _Cr;

	internal virtual AxCrystalReport Cr
	{
		get
		{
			return _Cr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Cr = value;
		}
	}

	internal virtual TextBox nGoldOzRate
	{
		[CompilerGenerated]
		get
		{
			return _nGoldOzRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldOzRate_KeyDown);
			EventHandler eventHandler = nGoldOzRate_TextChanged;
			TextBox val2 = _nGoldOzRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nGoldOzRate = value;
			val2 = _nGoldOzRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox nSilverOzRate
	{
		[CompilerGenerated]
		get
		{
			return _nSilverOzRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSilverOzRate_KeyDown);
			EventHandler eventHandler = nSilverOzRate_TextChanged;
			TextBox val2 = _nSilverOzRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nSilverOzRate = value;
			val2 = _nSilverOzRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox nPrSilverRate
	{
		[CompilerGenerated]
		get
		{
			return _nPrSilverRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPrSilverRate_KeyDown);
			TextBox val2 = _nPrSilverRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPrSilverRate = value;
			val2 = _nPrSilverRate;
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

	internal virtual TextBox nPrGoldRate
	{
		[CompilerGenerated]
		get
		{
			return _nPrGoldRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = nPrGoldRate_TextChanged;
			KeyEventHandler val = new KeyEventHandler(nPrGoldRate_KeyDown);
			TextBox val2 = _nPrGoldRate;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_nPrGoldRate = value;
			val2 = _nPrGoldRate;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual Label Label5
	{
		[CompilerGenerated]
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Label5_Click;
			Label val = _Label5;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Label5 = value;
			val = _Label5;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public MS_RATE()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((Form)this).Load += MS_RATE_Load;
		((Form)this).Activated += MS_RATE_Activated;
		((Form)this).Deactivate += MS_RATE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_RATE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_RATE_KeyDown);
		((Control)this).KeyUp += new KeyEventHandler(MS_RATE_KeyUp);
		((Form)this).Closed += MS_RATE_Closed;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Expected O, but got Unknown
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Expected O, but got Unknown
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Expected O, but got Unknown
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected O, but got Unknown
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0999: Expected O, but got Unknown
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected O, but got Unknown
		//IL_0abf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac9: Expected O, but got Unknown
		//IL_0b3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b49: Expected O, but got Unknown
		//IL_0bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfe: Expected O, but got Unknown
		//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7e: Expected O, but got Unknown
		//IL_0d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d36: Expected O, but got Unknown
		//IL_0db9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc3: Expected O, but got Unknown
		//IL_0e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7e: Expected O, but got Unknown
		//IL_0eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f09: Expected O, but got Unknown
		//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9b: Expected O, but got Unknown
		//IL_106f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1079: Expected O, but got Unknown
		//IL_1151: Unknown result type (might be due to invalid IL or missing references)
		//IL_115b: Expected O, but got Unknown
		//IL_11f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1201: Expected O, but got Unknown
		//IL_1313: Unknown result type (might be due to invalid IL or missing references)
		//IL_131d: Expected O, but got Unknown
		//IL_13a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13aa: Expected O, but got Unknown
		//IL_1465: Unknown result type (might be due to invalid IL or missing references)
		//IL_146f: Expected O, but got Unknown
		//IL_14f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fc: Expected O, but got Unknown
		//IL_15b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c1: Expected O, but got Unknown
		//IL_1644: Unknown result type (might be due to invalid IL or missing references)
		//IL_164e: Expected O, but got Unknown
		//IL_1709: Unknown result type (might be due to invalid IL or missing references)
		//IL_1713: Expected O, but got Unknown
		//IL_1796: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a0: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_RATE));
		lblBook = new Label();
		TEXT_ENTRY = new TextBox();
		MSG = new AxMSFlexGrid();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		nSilverRate = new TextBox();
		Label10 = new Label();
		nGoldRate = new TextBox();
		Label11 = new Label();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		BtnF1 = new SimpleButton();
		nGoldOzRate = new TextBox();
		Label1 = new Label();
		nSilverOzRate = new TextBox();
		Label2 = new Label();
		nPrSilverRate = new TextBox();
		Label4 = new Label();
		nPrGoldRate = new TextBox();
		Label5 = new Label();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Rate Master";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(526, 299);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 7;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG).Location = new Point(249, 149);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(720, 323);
		((Control)MSG).TabIndex = 8;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 10;
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
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(793, 3);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 11;
		((TextBoxBase)nSilverRate).BackColor = Color.White;
		((Control)nSilverRate).Font = new Font("Tahoma", 9f);
		((Control)nSilverRate).Location = new Point(249, 118);
		((TextBoxBase)nSilverRate).MaxLength = 6;
		((Control)nSilverRate).Name = "nSilverRate";
		((Control)nSilverRate).Size = new Size(76, 22);
		((Control)nSilverRate).TabIndex = 2;
		nSilverRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(113, 118);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(122, 20);
		((Control)Label10).TabIndex = 1137;
		Label10.Text = "Silver Rate 1Kg";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nGoldRate).BackColor = Color.White;
		((Control)nGoldRate).Font = new Font("Tahoma", 9f);
		((Control)nGoldRate).Location = new Point(249, 90);
		((TextBoxBase)nGoldRate).MaxLength = 6;
		((Control)nGoldRate).Name = "nGoldRate";
		((Control)nGoldRate).Size = new Size(76, 22);
		((Control)nGoldRate).TabIndex = 1;
		nGoldRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(109, 90);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(126, 20);
		((Control)Label11).TabIndex = 1136;
		Label11.Text = "Gold Rate 10gm";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(249, 61);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 0;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(166, 62);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1139;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(248, 479);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 9;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(313, 480);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1165;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(158, 480);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(84, 20);
		((Control)Label3).TabIndex = 1164;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(331, 62);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(33, 22);
		((Control)BtnF1).TabIndex = 1166;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((TextBoxBase)nGoldOzRate).BackColor = Color.White;
		((Control)nGoldOzRate).Font = new Font("Tahoma", 9f);
		((Control)nGoldOzRate).Location = new Point(710, 93);
		((TextBoxBase)nGoldOzRate).MaxLength = 6;
		((Control)nGoldOzRate).Name = "nGoldOzRate";
		((Control)nGoldOzRate).Size = new Size(76, 22);
		((Control)nGoldOzRate).TabIndex = 5;
		nGoldOzRate.TextAlign = (HorizontalAlignment)1;
		((Control)nGoldOzRate).Visible = false;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(570, 93);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(126, 20);
		((Control)Label1).TabIndex = 1168;
		Label1.Text = "Gold USD Pr Oz";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label1).Visible = false;
		((TextBoxBase)nSilverOzRate).BackColor = Color.White;
		((Control)nSilverOzRate).Font = new Font("Tahoma", 9f);
		((Control)nSilverOzRate).Location = new Point(710, 121);
		((TextBoxBase)nSilverOzRate).MaxLength = 6;
		((Control)nSilverOzRate).Name = "nSilverOzRate";
		((Control)nSilverOzRate).Size = new Size(76, 22);
		((Control)nSilverOzRate).TabIndex = 6;
		nSilverOzRate.TextAlign = (HorizontalAlignment)1;
		((Control)nSilverOzRate).Visible = false;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(570, 121);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(126, 20);
		((Control)Label2).TabIndex = 1170;
		Label2.Text = "Silver USD Pr Oz";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Label2).Visible = false;
		((TextBoxBase)nPrSilverRate).BackColor = Color.White;
		((Control)nPrSilverRate).Font = new Font("Tahoma", 9f);
		((Control)nPrSilverRate).Location = new Point(484, 118);
		((TextBoxBase)nPrSilverRate).MaxLength = 6;
		((Control)nPrSilverRate).Name = "nPrSilverRate";
		((Control)nPrSilverRate).Size = new Size(76, 22);
		((Control)nPrSilverRate).TabIndex = 4;
		nPrSilverRate.TextAlign = (HorizontalAlignment)1;
		((Control)nPrSilverRate).Visible = false;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(344, 118);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(126, 20);
		((Control)Label4).TabIndex = 1174;
		Label4.Text = "Silver Purc 1Kg";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label4).Visible = false;
		((TextBoxBase)nPrGoldRate).BackColor = Color.White;
		((Control)nPrGoldRate).Font = new Font("Tahoma", 9f);
		((Control)nPrGoldRate).Location = new Point(484, 90);
		((TextBoxBase)nPrGoldRate).MaxLength = 6;
		((Control)nPrGoldRate).Name = "nPrGoldRate";
		((Control)nPrGoldRate).Size = new Size(76, 22);
		((Control)nPrGoldRate).TabIndex = 3;
		nPrGoldRate.TextAlign = (HorizontalAlignment)1;
		((Control)nPrGoldRate).Visible = false;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(344, 90);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(126, 20);
		((Control)Label5).TabIndex = 1173;
		Label5.Text = "Gold Purc 10gm";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label5).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)nPrSilverRate);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)nPrGoldRate);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nSilverOzRate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)nGoldOzRate);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)nSilverRate);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)nGoldRate);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_RATE";
		((Form)this).Text = "_U";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 10;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr.";
			mSG[1] = (int)Math.Round(900.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "GrCode";
			mSG[2] = (int)Math.Round(2500.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "GrName";
			mSG[3] = (int)Math.Round(900.0 * ColCon);
			mSG[3] = 7;
			mSG[0, 3] = "Touch";
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "Tax%";
			mSG[5] = (int)Math.Round(1200.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "Rate10gm";
			mSG[6] = (int)Math.Round(1200.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "TaxRate";
			mSG[7] = (int)Math.Round(900.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "PrTouch";
			mSG[8] = (int)Math.Round(1200.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "PrRate";
			mSG[9] = 0;
			mSG[9] = 3;
			mSG[0, 9] = "GrType";
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
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
				switch (MSG.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 6:
				case 8:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 3:
				case 4:
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
		if (!UpDown && !MsgClear && MSG.Row != 0 && MSG[MSG.Col] != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 0:
			case 1:
			case 2:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 3:
			case 4:
			case 5:
			case 6:
			case 8:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			}
			mSG = null;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG = null;
	}

	private void MS_RATE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected O, but got Unknown
		//IL_085e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c1: Expected O, but got Unknown
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected O, but got Unknown
		//IL_09d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Expected O, but got Unknown
		//IL_0a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5f: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj11 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj14 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj15 = lblBook;
				object? obj16 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj15).ForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj17 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj19 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj20 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				num3 = (int)Math.Ceiling((double)((Control)nGoldRate).Font.Size * (1.0 + num2));
				Font font = ((Control)nGoldRate).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
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
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)Label1).Visible = true;
				((Control)Label2).Visible = true;
				((Control)Label4).Visible = true;
				((Control)Label5).Visible = true;
				((Control)nGoldOzRate).Visible = true;
				((Control)nSilverOzRate).Visible = true;
				((Control)nPrGoldRate).Visible = true;
				((Control)nPrSilverRate).Visible = true;
			}
			CLEAR_DATA();
			EntryMode = "A";
			CurActCtrl = (Control)(object)mVchDate;
		}
	}

	private void MS_RATE_Activated(object sender, EventArgs e)
	{
		DISPLAY_DATA();
		((ContainerControl)this).ActiveControl = CurActCtrl;
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
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		OldGoldRate = 0.0;
		OldSlRate = 0.0;
		OldPrGoldRate = 0.0;
		OldPrSlRate = 0.0;
		MSG_CLEAR();
		CommPassAdd();
		EntryMode = "A";
		((Control)mVchDate).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		DateTime dateTime = Conversions.ToDate(mVchDate.Text);
		DC_Main.RsQry = "SELECT * FROM RATE_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND  VCH_DATE = '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsDetl);
		if (RsDetl.Rows.Count > 0)
		{
			nGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_RATE"]), "0.00");
			OldGoldRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_RATE"]), "0.00"));
			nSilverRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_SL_RATE"]), "0.00");
			OldSlRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_SL_RATE"]), "0.00"));
			nPrGoldRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_PR_RATE"]), "0.00");
			OldPrGoldRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_GL_PR_RATE"]), "0.00"));
			nPrSilverRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_SL_PR_RATE"]), "0.00");
			OldPrSlRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["FINE_SL_PR_RATE"]), "0.00"));
			nGoldOzRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["DOLLAR_GL_RATE"]), "0.00");
			nSilverOzRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["DOLLAR_SL_RATE"]), "0.00");
			tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["EMP_CODE"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["MAIN_USER"], (object)""));
			DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
			DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsAc.Rows.Count > 0)
			{
				tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
			}
			EntryMode = "E";
		}
		DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_TOUCH <> 0 ORDER BY GR_TYPE,GR_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["GR_CODE"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["GR_NAME"], (object)""));
				mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["GR_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["GR_TOUCH"]), "0.00");
				AxMSFlexGrid obj = mSG;
				int num = DC_Main.i + 1;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[DC_Main.i])["TAX_PRC"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				obj[num, 4] = Strings.Format((object)num2, "0.00");
				mSG[DC_Main.i + 1, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["GR_PURC_TOUCH"]), "0.00");
				dataView.RowFilter = "GR_CODE = '" + mSG[DC_Main.i + 1, 1] + "'";
				if (dataView.Count > 0)
				{
					AxMSFlexGrid obj2 = mSG;
					int num3 = DC_Main.i + 1;
					DataRowView dataRowView;
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView[0])["GR_RATE"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRowView["GR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					obj2[num3, 5] = Strings.Format((object)num4, "0.00");
					AxMSFlexGrid obj3 = mSG;
					int num5 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView[0])["GR_TAX_RATE"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRowView["GR_TAX_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					obj3[num5, 6] = Strings.Format((object)num6, "0.00");
					AxMSFlexGrid obj4 = mSG;
					int num7 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView[0])["GR_PR_RATE"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRowView["GR_PR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					obj4[num7, 8] = Strings.Format((object)num8, "0.00");
				}
				mSG.Rows += 1;
				DC_Main.i++;
			}
			mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
			mSG = null;
			EntryMode = "E";
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			string rptName = "RateRpt";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Daily Rate Report " + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{RATE_MAST.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_MAST.LC_CODE} = '" + DC_Main.MLc_code + "'  AND {RATE_MAST.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "# ";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
		}
		else
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RateRpt.RPT";
			Cr.SelectionFormula = "{RATE_MAST.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_MAST.LC_CODE} = '" + DC_Main.MLc_code + "'  AND {RATE_MAST.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "# ";
			Cr[(short)0] = "RptTitel = 'Daily Rate Report " + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca8: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					switch (try0001_dispatch)
					{
					default:
					{
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						DateTime dateTime = Conversions.ToDate(mVchDate.Text);
						DC_Main.RsQry = "DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND  VCH_DATE = '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "SELECT * FROM RATE_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND  VCH_DATE = '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = RsDetl.NewRow();
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))
							{
								dataRow["CO_CODE"] = DC_Main.MCo_code;
								dataRow["LC_CODE"] = DC_Main.MLc_code;
								dataRow["CO_YEAR"] = DC_Main.MCo_year;
								dataRow["VCH_DATE"] = mVchDate.Text;
								dataRow["FINE_GL_RATE"] = Conversion.Val(nGoldRate.Text);
								dataRow["FINE_SL_RATE"] = Conversion.Val(nSilverRate.Text);
								dataRow["FINE_GL_PR_RATE"] = Conversion.Val(nPrGoldRate.Text);
								dataRow["FINE_SL_PR_RATE"] = Conversion.Val(nPrSilverRate.Text);
								dataRow["DOLLAR_GL_RATE"] = Conversion.Val(nGoldOzRate.Text);
								dataRow["DOLLAR_SL_RATE"] = Conversion.Val(nSilverOzRate.Text);
								dataRow["SR_NO"] = DC_Main.i;
								dataRow["GR_CODE"] = MSG[DC_Main.i, 1];
								dataRow["GR_TOUCH"] = Conversion.Val(MSG[DC_Main.i, 3]);
								dataRow["GR_TAX_PRC"] = Conversion.Val(MSG[DC_Main.i, 4]);
								dataRow["GR_RATE"] = Conversion.Val(MSG[DC_Main.i, 5]);
								dataRow["GR_TAX_RATE"] = Conversion.Val(MSG[DC_Main.i, 6]);
								dataRow["GR_PR_TOUCH"] = Conversion.Val(MSG[DC_Main.i, 7]);
								dataRow["GR_PR_RATE"] = Conversion.Val(MSG[DC_Main.i, 8]);
								dataRow["GR_TYPE"] = MSG[DC_Main.i, 9];
								dataRow["EMP_CODE"] = tEmpCode.Text;
								dataRow["MAIN_USER"] = MainUser;
								RsDetl.Rows.Add(dataRow);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
								if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
								{
									DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET GR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 5])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + MSG[DC_Main.i, 1] + "'");
								}
							}
							DC_Main.i++;
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
						{
							DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE <> '00' ORDER BY LC_CODE";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.R = 0;
							while (DC_Main.R < DC_Main.Tbl.Rows.Count)
							{
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '"), DC_Main.Tbl.Rows[DC_Main.R]["LC_CODE"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy")), (object)"'")));
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO RATE_MAST(CO_CODE,LC_CODE,CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE,  GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE,  FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE)  SELECT CO_CODE,'", DC_Main.Tbl.Rows[DC_Main.R]["LC_CODE"]), (object)"',CO_YEAR,VCH_DATE,SR_NO,GR_CODE,FINE_GL_RATE,FINE_SL_RATE, "), (object)" GR_RATE,GR_TOUCH,GR_TYPE,EMP_CODE,CASH_AMT,MAIN_USER,ADD_USER,ADD_DATE,GR_PR_TOUCH,GR_PR_RATE, "), (object)" FINE_GL_PR_RATE,FINE_SL_PR_RATE,DOLLAR_GL_RATE,DOLLAR_SL_RATE,AND_TRFR,GR_TAX_RATE,GR_TAX_PRC,OP_GL_RATE "), (object)" FROM RATE_MAST WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '00' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy")), (object)"'"));
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								DC_Main.R++;
							}
						}
						DC_Main.RsQry = "SELECT A.GR_CODE,A.GR_RATE,B.GR_NAME FROM RATE_MAST AS A INNER JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.M = 0;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							((Control)MyProject.Forms.MDI_FORM.Rate_1).Visible = true;
							MyProject.Forms.MDI_FORM.Rate_1.Text = "ToDays Rate :";
						}
						while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
						{
							if (DC_Main.M == 0)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_1).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							if (DC_Main.M == 1)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_2).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							if (DC_Main.M == 2)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_3).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_3.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							if (DC_Main.M == 3)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_4).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_4.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							if (DC_Main.M == 4)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_5).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_5.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							if (DC_Main.M == 5)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_6).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_6.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							if (DC_Main.M == 6)
							{
								((Control)MyProject.Forms.MDI_FORM.Rate_7).Visible = true;
								MyProject.Forms.MDI_FORM.Rate_7.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
							}
							DC_Main.M++;
						}
						if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
						{
							AppSchemeTrfr();
						}
						DC_Main.RsQry = "SELECT CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_RATE,GR_TOUCH,GR_TAX_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							DC_Main.RtView = new DataView(DC_Main.Rshlp);
						}
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						if (DC_Main.MsDailyRateGen)
						{
							DC_Main.MsDailyRateGen = false;
							((Form)this).Close();
						}
						else
						{
							CLEAR_DATA();
						}
						goto end_IL_0001;
					}
					case 3323:
						num = -1;
						switch (num2)
						{
						case 2:
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3323;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void AppSchemeTrfr()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
			text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
			text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		}
		DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
		DC_Main.RsQry = "DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'";
		DC_Main.ExeQuteScm(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		string text4 = "";
		if (DC_Main.Tbl.Rows.Count <= 0)
		{
			return;
		}
		DataTable tbl = DC_Main.Tbl;
		checked
		{
			while (DC_Main.i < tbl.Rows.Count)
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["GR_RATE"])) > 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_NAME FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), tbl.Rows[DC_Main.i]["GR_CODE"]), (object)"'"));
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						text4 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO RATE_MAST(CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_NAME,FINE_GL_RATE,FINE_SL_RATE,GR_RATE)  VALUES('" + DC_Main.MCo_code + "','"), tbl.Rows[DC_Main.i]["LC_CODE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"',"), tbl.Rows[DC_Main.i]["SR_NO"]), (object)",'"), tbl.Rows[DC_Main.i]["GR_CODE"]), (object)"','"), (object)text4), (object)"',"), tbl.Rows[DC_Main.i]["FINE_GL_RATE"]), (object)","), tbl.Rows[DC_Main.i]["FINE_SL_RATE"]), (object)","), tbl.Rows[DC_Main.i]["GR_RATE"]), (object)")"));
					DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				}
				DC_Main.i++;
			}
			tbl = null;
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Day Rate?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'");
			CLEAR_DATA();
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

	private void MS_RATE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_RATE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_RATE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 0;
				((Control)TEXT_ENTRY).Visible = false;
				((Control)BtnSave).Focus();
			}
			else
			{
				((Form)this).Close();
			}
		}
	}

	private void MS_RATE_KeyUp(object sender, KeyEventArgs e)
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

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
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
				int col = mSG.Col;
				if (col == 5 || col == 8)
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						((Control)BtnSave).Focus();
						return;
					}
					mSG.Row += 1;
					mSG.Col = 5;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
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

	private void MS_RATE_Closed(object sender, EventArgs e)
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

	private void mVchDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mVchDate).SelectionStart = 0;
		((TextBoxBase)mVchDate).SelectionLength = Strings.Len(mVchDate.Text);
	}

	private void mVchDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mVchDate;
			DC_Main.SetDate(ref MsDate);
			mVchDate = MsDate;
			if (!DC_Main.RongDate)
			{
				DISPLAY_DATA();
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void nGoldRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nGoldRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nSilverRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		nSilverRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSilverRate.Text)), "0.00");
		if (((Control)nGoldOzRate).Visible)
		{
			SendKeys.Send("{TAB}");
			return;
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				AxMSFlexGrid mSG = MSG;
				string text = mSG[DC_Main.M, 9];
				if (Operators.CompareString(mSG[DC_Main.M, 9], "G", false) == 0)
				{
					if ((Conversion.Val(nGoldRate.Text) != 0.0) & (OldGoldRate != Conversion.Val(nGoldRate.Text)))
					{
						mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");
						mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");
						if (Conversion.Val(MSG[DC_Main.M, 4]) != 0.0)
						{
							mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");
						}
						mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");
					}
				}
				else if (Operators.CompareString(mSG[DC_Main.M, 9], "S", false) == 0 && ((Conversion.Val(nSilverRate.Text) != 0.0) & (OldSlRate != Conversion.Val(nSilverRate.Text))))
				{
					mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");
					mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");
					if (Conversion.Val(MSG[DC_Main.M, 4]) != 0.0)
					{
						mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");
					}
					mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");
				}
				mSG = null;
				DC_Main.M++;
			}
			MSG.Col = 5;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			TEXT_ENTRY.Text = MSG[1, 5];
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT replace(convert(NVARCHAR,VCH_DATE, 103), ' ', '/') AS VchDateL,MAIN_USER As UserL,FINE_GL_RATE As GoldRate10gR,FINE_SL_RATE As SilverRate1KgR  FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,MAIN_USER,FINE_GL_RATE,FINE_SL_RATE  ORDER BY VCH_DATE DESC";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 150.0;
		DC_Main.ColWidth[1] = 150.0;
		DC_Main.ColWidth[2] = 150.0;
		DC_Main.ColWidth[3] = 150.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				mVchDate.Text = DC_Main.ColValue[0];
				DISPLAY_DATA();
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)mVchDate).Focus();
			}
		}
	}

	private void nSilverOzRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		nSilverOzRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSilverOzRate.Text)), "0.00");
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				AxMSFlexGrid mSG = MSG;
				string text = mSG[DC_Main.M, 9];
				if (Operators.CompareString(mSG[DC_Main.M, 9], "G", false) == 0)
				{
					if ((Conversion.Val(nGoldRate.Text) != 0.0) & (OldGoldRate != Conversion.Val(nGoldRate.Text)))
					{
						mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");
						mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");
						if (Conversion.Val(MSG[DC_Main.M, 4]) != 0.0)
						{
							mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");
						}
						mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nGoldRate.Text) / 100.0), "0.00");
					}
					if ((Conversion.Val(nPrGoldRate.Text) != 0.0) & (OldPrGoldRate != Conversion.Val(nPrGoldRate.Text)))
					{
						mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrGoldRate.Text) / 100.0), "0.00");
					}
				}
				else if (Operators.CompareString(mSG[DC_Main.M, 9], "S", false) == 0)
				{
					if ((Conversion.Val(nSilverRate.Text) != 0.0) & (OldSlRate != Conversion.Val(nSilverRate.Text)))
					{
						mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");
						mSG[DC_Main.M, 6] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 3]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");
						if (Conversion.Val(MSG[DC_Main.M, 4]) != 0.0)
						{
							mSG[DC_Main.M, 5] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 6]) / (Conversion.Val(mSG[DC_Main.M, 4]) + 100.0) * 100.0, 0), "0.00");
						}
						mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nSilverRate.Text) / 10000.0), "0.00");
					}
					if ((Conversion.Val(nPrSilverRate.Text) != 0.0) & (OldPrSlRate != Conversion.Val(nPrSilverRate.Text)))
					{
						mSG[DC_Main.M, 8] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.M, 7]) * Conversion.Val(nPrSilverRate.Text) / 10000.0), "0.00");
					}
				}
				mSG = null;
				DC_Main.M++;
			}
			MSG.Col = 5;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			TEXT_ENTRY.Text = MSG[1, 5];
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void nGoldOzRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nGoldOzRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldOzRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	private void Label5_Click(object sender, EventArgs e)
	{
	}

	private void nGoldOzRate_TextChanged(object sender, EventArgs e)
	{
	}

	private void nPrGoldRate_TextChanged(object sender, EventArgs e)
	{
	}

	private void nPrGoldRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPrGoldRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPrGoldRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nPrSilverRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPrSilverRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPrSilverRate.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nSilverOzRate_TextChanged(object sender, EventArgs e)
	{
	}

	private void nSilverRate_TextChanged(object sender, EventArgs e)
	{
	}
}
