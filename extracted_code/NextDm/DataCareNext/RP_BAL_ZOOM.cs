using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class RP_BAL_ZOOM : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

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
	[AccessedThroughProperty("DGV_AC")]
	private DataGridViewX _DGV_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DataGridViewX _DGV_VCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOpBal")]
	private CheckBox _chkOpBal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearch")]
	private SearchControl _tSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_BALANCE")]
	private DataGridViewX _DGV_BALANCE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGoldAmt")]
	private TextBox _nGoldAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSilverAmt")]
	private TextBox _nSilverAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTodayBal")]
	private CheckBox _chkTodayBal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkLedrFine")]
	private CheckBox _chkLedrFine;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private DataTable RsLdr;

	private double ColCon;

	private bool DgvAcEnter;

	private string AcGrCode;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cBalGrCodeCr = 0;

	private const int cBalGrNameCr = 1;

	private const int cBalSummFineCr = 2;

	private const int cBalSummCr = 3;

	private const int cBalGrCodeDr = 4;

	private const int cBalGrNameDr = 5;

	private const int cBalSummFineDr = 6;

	private const int cBalSummDr = 7;

	private const int cAcCode = 0;

	private const int cAcName = 1;

	private const int cAddress = 2;

	private const int cMobile = 3;

	private const int cDrAmt = 4;

	private const int cCrAmt = 5;

	private const int cDrGold = 6;

	private const int cCrGold = 7;

	private const int cDrSilver = 8;

	private const int cCrSilver = 9;

	private const int cAcRefBy = 10;

	private const int cAcCity = 11;

	private const int cAcKhataNo = 12;

	private const int c2SrNo = 0;

	private const int c2BookName = 1;

	private const int c2VchNo = 2;

	private const int c2VchDate = 3;

	private const int c2AcName = 4;

	private const int c2Cramt = 5;

	private const int c2DrAmt = 6;

	private const int c2BalAmt = 7;

	private const int c2CrDr = 8;

	private const int c2CrGold = 9;

	private const int c2DrGold = 10;

	private const int c2BalGold = 11;

	private const int c2GlCrDr = 12;

	private const int c2CrSilver = 13;

	private const int c2DrSilver = 14;

	private const int c2BalSilver = 15;

	private const int c2SlCrDr = 16;

	private const int c2CoBook = 17;

	private const int c2AcCode = 18;

	private const int c2MainBook = 19;

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

	internal virtual DataGridViewX DGV_AC
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			EventHandler eventHandler = DGV_DoubleClick;
			KeyEventHandler val2 = new KeyEventHandler(DGV_KeyDown);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(DGV_RowEnter);
			DataGridViewX val4 = _DGV_AC;
			if (val4 != null)
			{
				((DataGridView)val4).CellFormatting -= val;
				((Control)val4).DoubleClick -= eventHandler;
				((Control)val4).KeyDown -= val2;
				((DataGridView)val4).RowEnter -= val3;
			}
			_DGV_AC = value;
			val4 = _DGV_AC;
			if (val4 != null)
			{
				((DataGridView)val4).CellFormatting += val;
				((Control)val4).DoubleClick += eventHandler;
				((Control)val4).KeyDown += val2;
				((DataGridView)val4).RowEnter += val3;
			}
		}
	}

	internal virtual DataGridViewX DGV_VCH
	{
		[CompilerGenerated]
		get
		{
			return _DGV_VCH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			DataGridViewX val2 = _DGV_VCH;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_VCH = value;
			val2 = _DGV_VCH;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlAcSumm")]
	private virtual Panel _PnlAcSumm;

	internal virtual Panel PnlAcSumm
	{
		get
		{
			return _PnlAcSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlAcSumm = value;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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

	internal virtual DataGridViewX DGV_DETL
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewX val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblRefby")]
	private virtual Label _lblRefby;

	internal virtual Label lblRefby
	{
		get
		{
			return _lblRefby;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRefby = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Panel1")]
	private virtual Panel _Panel1;

	internal virtual Panel Panel1
	{
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMobile")]
	private virtual Label _lblMobile;

	internal virtual Label lblMobile
	{
		get
		{
			return _lblMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd1")]
	private virtual Label _lblAdd1;

	internal virtual Label lblAdd1
	{
		get
		{
			return _lblAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd1 = value;
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

	internal virtual CheckBox chkOpBal
	{
		[CompilerGenerated]
		get
		{
			return _chkOpBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkOpBal_CheckedChanged;
			CheckBox val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkOpBal = value;
			val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mToDt
	{
		[CompilerGenerated]
		get
		{
			return _mToDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mToDt_KeyDown);
			EventHandler eventHandler = mToDt_GotFocus;
			MaskedTextBox val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mToDt = value;
			val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mFromDt
	{
		[CompilerGenerated]
		get
		{
			return _mFromDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFromDt_KeyDown);
			EventHandler eventHandler = mFromDt_GotFocus;
			MaskedTextBox val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual SearchControl tSerchAll
	{
		[CompilerGenerated]
		get
		{
			return _tSerchAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSerchAll_TextChanged;
			SearchControl val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSerchAll = value;
			val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	internal virtual SearchControl tSearch
	{
		[CompilerGenerated]
		get
		{
			return _tSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSearch_TextChanged;
			SearchControl val = _tSearch;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSearch = value;
			val = _tSearch;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlGrSumm")]
	private virtual Panel _PnlGrSumm;

	internal virtual Panel PnlGrSumm
	{
		get
		{
			return _PnlGrSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlGrSumm = value;
		}
	}

	internal virtual DataGridViewX DGV_BALANCE
	{
		[CompilerGenerated]
		get
		{
			return _DGV_BALANCE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = DGV_BALANCE_DoubleClick;
			DataGridViewX val = _DGV_BALANCE;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV_BALANCE = value;
			val = _DGV_BALANCE;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAcGrName")]
	private virtual Label _lblAcGrName;

	internal virtual Label lblAcGrName
	{
		get
		{
			return _lblAcGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAcGrName = value;
		}
	}

	internal virtual TextBox nGoldAmt
	{
		[CompilerGenerated]
		get
		{
			return _nGoldAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldAmt_KeyDown);
			TextBox val2 = _nGoldAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGoldAmt = value;
			val2 = _nGoldAmt;
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

	internal virtual TextBox nSilverAmt
	{
		[CompilerGenerated]
		get
		{
			return _nSilverAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSilverAmt_KeyDown);
			TextBox val2 = _nSilverAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSilverAmt = value;
			val2 = _nSilverAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLcCode_KeyDown);
			TextBox val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tLcCode = value;
			val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcName")]
	private virtual TextBox _tLcName;

	internal virtual TextBox tLcName
	{
		get
		{
			return _tLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLcName = value;
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

	internal virtual CheckBox chkTodayBal
	{
		[CompilerGenerated]
		get
		{
			return _chkTodayBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkTodayBal_CheckedChanged;
			CheckBox val = _chkTodayBal;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkTodayBal = value;
			val = _chkTodayBal;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkLedrFine
	{
		[CompilerGenerated]
		get
		{
			return _chkLedrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkLedrFine_Click;
			EventHandler eventHandler2 = chkLedrFine_CheckedChanged;
			CheckBox val = _chkLedrFine;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				val.CheckedChanged -= eventHandler2;
			}
			_chkLedrFine = value;
			val = _chkLedrFine;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				val.CheckedChanged += eventHandler2;
			}
		}
	}

	public int newindex { get; set; }

	public RP_BAL_ZOOM()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_BAL_ZOOM_Load;
		((Form)this).Deactivate += RP_BAL_ZOOM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_BAL_ZOOM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_BAL_ZOOM_KeyDown);
		((Form)this).Activated += RP_BAL_ZOOM_Activated;
		((Form)this).Closed += RP_BAL_ZOOM_Closed;
		DgvAcEnter = false;
		AcGrCode = "";
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
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Expected O, but got Unknown
		//IL_07e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected O, but got Unknown
		//IL_0907: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Expected O, but got Unknown
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected O, but got Unknown
		//IL_0a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Expected O, but got Unknown
		//IL_0b07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b11: Expected O, but got Unknown
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bea: Expected O, but got Unknown
		//IL_0c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c89: Expected O, but got Unknown
		//IL_0d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Expected O, but got Unknown
		//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfd: Expected O, but got Unknown
		//IL_0e66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e70: Expected O, but got Unknown
		//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3b: Expected O, but got Unknown
		//IL_0fd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe1: Expected O, but got Unknown
		//IL_1067: Unknown result type (might be due to invalid IL or missing references)
		//IL_1071: Expected O, but got Unknown
		//IL_1158: Unknown result type (might be due to invalid IL or missing references)
		//IL_1162: Expected O, but got Unknown
		//IL_11cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d5: Expected O, but got Unknown
		//IL_130c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1316: Expected O, but got Unknown
		//IL_13ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f6: Expected O, but got Unknown
		//IL_1462: Unknown result type (might be due to invalid IL or missing references)
		//IL_1468: Expected O, but got Unknown
		//IL_146a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1470: Expected O, but got Unknown
		//IL_14f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1502: Expected O, but got Unknown
		//IL_156e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1574: Expected O, but got Unknown
		//IL_1576: Unknown result type (might be due to invalid IL or missing references)
		//IL_157c: Expected O, but got Unknown
		//IL_15bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c5: Expected O, but got Unknown
		//IL_1676: Unknown result type (might be due to invalid IL or missing references)
		//IL_1680: Expected O, but got Unknown
		//IL_1717: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Expected O, but got Unknown
		//IL_17a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ab: Expected O, but got Unknown
		//IL_1868: Unknown result type (might be due to invalid IL or missing references)
		//IL_1872: Expected O, but got Unknown
		//IL_1924: Unknown result type (might be due to invalid IL or missing references)
		//IL_192e: Expected O, but got Unknown
		//IL_19a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19af: Expected O, but got Unknown
		//IL_1a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3d: Expected O, but got Unknown
		//IL_1b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b14: Expected O, but got Unknown
		//IL_1bb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bba: Expected O, but got Unknown
		//IL_1c40: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4a: Expected O, but got Unknown
		//IL_1d31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3b: Expected O, but got Unknown
		//IL_1da4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dae: Expected O, but got Unknown
		//IL_1e43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e4d: Expected O, but got Unknown
		//IL_1f10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1a: Expected O, but got Unknown
		//IL_1fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff9: Expected O, but got Unknown
		//IL_2092: Unknown result type (might be due to invalid IL or missing references)
		//IL_209c: Expected O, but got Unknown
		//IL_2316: Unknown result type (might be due to invalid IL or missing references)
		//IL_2320: Expected O, but got Unknown
		//IL_23bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c5: Expected O, but got Unknown
		//IL_2456: Unknown result type (might be due to invalid IL or missing references)
		//IL_2460: Expected O, but got Unknown
		//IL_251b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2525: Expected O, but got Unknown
		//IL_25af: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b9: Expected O, but got Unknown
		//IL_2667: Unknown result type (might be due to invalid IL or missing references)
		//IL_2671: Expected O, but got Unknown
		//IL_26fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2705: Expected O, but got Unknown
		//IL_27d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_27df: Expected O, but got Unknown
		//IL_287b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2885: Expected O, but got Unknown
		//IL_290b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2915: Expected O, but got Unknown
		//IL_29fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a06: Expected O, but got Unknown
		//IL_2a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a79: Expected O, but got Unknown
		//IL_2b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b34: Expected O, but got Unknown
		//IL_2bf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c03: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_BAL_ZOOM));
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
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		DataGridViewCellStyle val16 = new DataGridViewCellStyle();
		DataGridViewCellStyle val17 = new DataGridViewCellStyle();
		DataGridViewCellStyle val18 = new DataGridViewCellStyle();
		DataGridViewCellStyle val19 = new DataGridViewCellStyle();
		DataGridViewCellStyle val20 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		Panel1 = new Panel();
		lblMobile = new Label();
		lblAdd1 = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV_AC = new DataGridViewX();
		DGV_VCH = new DataGridViewX();
		PnlAcSumm = new Panel();
		lblAcGrName = new Label();
		tSerchAll = new SearchControl();
		tSearch = new SearchControl();
		Label1 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		Label3 = new Label();
		chkOpBal = new CheckBox();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		lblRefby = new Label();
		BtnF1 = new SimpleButton();
		PnlGrSumm = new Panel();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		nSilverAmt = new TextBox();
		Label5 = new Label();
		nGoldAmt = new TextBox();
		Label4 = new Label();
		DGV_BALANCE = new DataGridViewX();
		chkTodayBal = new CheckBox();
		chkLedrFine = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_AC).BeginInit();
		((ISupportInitialize)DGV_VCH).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)tSearch.Properties).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)PnlGrSumm).SuspendLayout();
		((ISupportInitialize)DGV_BALANCE).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)Panel1);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 3;
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
		((Control)BtnExit).TabIndex = 0;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1118, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 1;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(1021, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 3;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnSave).TabIndex = 2;
		BtnSave.Text = "&Excel";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)Panel1).Controls.Add((Control)(object)lblMobile);
		((Control)Panel1).Controls.Add((Control)(object)lblAdd1);
		((Control)Panel1).Location = new Point(109, 3);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(809, 38);
		((Control)Panel1).TabIndex = 11;
		((Control)lblMobile).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.White;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(23, 18);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).RightToLeft = (RightToLeft)1;
		((Control)lblMobile).Size = new Size(301, 20);
		((Control)lblMobile).TabIndex = 1140;
		lblMobile.Text = "Mobile";
		((Control)lblAdd1).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.White;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(23, 0);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).RightToLeft = (RightToLeft)1;
		((Control)lblAdd1).Size = new Size(301, 20);
		((Control)lblAdd1).TabIndex = 1139;
		lblAdd1.Text = "Address";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1247, 476);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(192, 0, 0);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 6;
		lblBook.Text = "Balance Sheet Zoom";
		lblBook.TextAlign = (ContentAlignment)32;
		((DataGridView)DGV_AC).AllowUserToAddRows = false;
		((DataGridView)DGV_AC).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AC).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_AC).BackgroundColor = Color.Snow;
		((DataGridView)DGV_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_AC).ColumnHeadersHeight = 30;
		((DataGridView)DGV_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).DefaultCellStyle = val3;
		((DataGridView)DGV_AC).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_AC).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_AC).Location = new Point(16, 43);
		((Control)DGV_AC).Name = "DGV_AC";
		DGV_AC.PaintEnhancedSelection = false;
		((DataGridView)DGV_AC).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AC).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_AC).RowHeadersVisible = false;
		((DataGridView)DGV_AC).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_AC).RowsDefaultCellStyle = val5;
		DGV_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_AC.SelectAllSignVisible = false;
		((DataGridView)DGV_AC).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_AC).Size = new Size(1160, 475);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((DataGridView)DGV_VCH).AllowUserToAddRows = false;
		((DataGridView)DGV_VCH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_VCH).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_VCH).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_VCH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_VCH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_VCH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_VCH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).DefaultCellStyle = val8;
		((DataGridView)DGV_VCH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_VCH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_VCH).Location = new Point(13, 79);
		((Control)DGV_VCH).Name = "DGV_VCH";
		DGV_VCH.PaintEnhancedSelection = false;
		((DataGridView)DGV_VCH).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_VCH).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_VCH).RowHeadersVisible = false;
		((DataGridView)DGV_VCH).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_VCH).RowsDefaultCellStyle = val10;
		DGV_VCH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_VCH.SelectAllSignVisible = false;
		((DataGridView)DGV_VCH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_VCH).Size = new Size(1159, 473);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 7;
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblAcGrName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSearch);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Location = new Point(-1, 34);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 531);
		((Control)PnlAcSumm).TabIndex = 0;
		((Control)lblAcGrName).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblAcGrName).ForeColor = Color.Black;
		lblAcGrName.ImeMode = (ImeMode)0;
		((Control)lblAcGrName).Location = new Point(349, 12);
		((Control)lblAcGrName).Name = "lblAcGrName";
		((Control)lblAcGrName).Size = new Size(279, 20);
		((Control)lblAcGrName).TabIndex = 1160;
		lblAcGrName.Text = ":";
		lblAcGrName.TextAlign = (ContentAlignment)16;
		((Control)tSerchAll).Location = new Point(174, 10);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Ac Or Mobile Search";
		((Control)tSerchAll).Size = new Size(150, 24);
		((Control)tSerchAll).TabIndex = 1159;
		((Control)tSearch).Location = new Point(18, 10);
		((Control)tSearch).Name = "tSearch";
		((RepositoryItem)tSearch.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSearch.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSearch.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSearch.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSearch.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((Control)tSearch).Size = new Size(150, 24);
		((Control)tSearch).TabIndex = 1158;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(189, 14);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(74, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "To Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(268, 11);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(104, 11);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(18, 12);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(80, 20);
		((Control)Label3).TabIndex = 1156;
		Label3.Text = "From Date";
		Label3.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkOpBal).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkOpBal).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOpBal).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkOpBal).Location = new Point(195, 7);
		((Control)chkOpBal).Name = "chkOpBal";
		((Control)chkOpBal).RightToLeft = (RightToLeft)0;
		((Control)chkOpBal).Size = new Size(141, 20);
		((Control)chkOpBal).TabIndex = 2;
		((ButtonBase)chkOpBal).Text = "Opning Balance";
		((ButtonBase)chkOpBal).UseVisualStyleBackColor = false;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(109, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(78, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(191, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(272, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(16, 45);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Party Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Linen;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val13;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 79);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val15;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((Control)lblRefby).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRefby).ForeColor = Color.Black;
		lblRefby.ImeMode = (ImeMode)0;
		((Control)lblRefby).Location = new Point(516, 45);
		((Control)lblRefby).Name = "lblRefby";
		((Control)lblRefby).Size = new Size(404, 20);
		((Control)lblRefby).TabIndex = 1140;
		lblRefby.Text = "AcRefBy";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(469, 44);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1152;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Ledger Date";
		((Control)PnlGrSumm).Controls.Add((Control)(object)tLcCode);
		((Control)PnlGrSumm).Controls.Add((Control)(object)tLcName);
		((Control)PnlGrSumm).Controls.Add((Control)(object)Label6);
		((Control)PnlGrSumm).Controls.Add((Control)(object)nSilverAmt);
		((Control)PnlGrSumm).Controls.Add((Control)(object)Label5);
		((Control)PnlGrSumm).Controls.Add((Control)(object)nGoldAmt);
		((Control)PnlGrSumm).Controls.Add((Control)(object)Label4);
		((Control)PnlGrSumm).Controls.Add((Control)(object)DGV_BALANCE);
		((Control)PnlGrSumm).Controls.Add((Control)(object)mToDt);
		((Control)PnlGrSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlGrSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlGrSumm).Controls.Add((Control)(object)mFromDt);
		((Control)PnlGrSumm).Location = new Point(1, 34);
		((Control)PnlGrSumm).Name = "PnlGrSumm";
		((Control)PnlGrSumm).Size = new Size(1196, 531);
		((Control)PnlGrSumm).TabIndex = 1153;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(893, 12);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(55, 23);
		((Control)tLcCode).TabIndex = 1182;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(954, 12);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(216, 23);
		((Control)tLcName).TabIndex = 1184;
		((Control)tLcName).Visible = false;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(826, 12);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1183;
		Label6.Text = "lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label6).Visible = false;
		((TextBoxBase)nSilverAmt).BackColor = Color.White;
		((Control)nSilverAmt).Font = new Font("Tahoma", 9f);
		((Control)nSilverAmt).Location = new Point(715, 12);
		((TextBoxBase)nSilverAmt).MaxLength = 6;
		((Control)nSilverAmt).Name = "nSilverAmt";
		((Control)nSilverAmt).Size = new Size(76, 22);
		((Control)nSilverAmt).TabIndex = 3;
		nSilverAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(594, 13);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(114, 20);
		((Control)Label5).TabIndex = 1181;
		Label5.Text = "Silver Rate 10 gm";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nGoldAmt).BackColor = Color.White;
		((Control)nGoldAmt).Font = new Font("Tahoma", 9f);
		((Control)nGoldAmt).Location = new Point(498, 12);
		((TextBoxBase)nGoldAmt).MaxLength = 6;
		((Control)nGoldAmt).Name = "nGoldAmt";
		((Control)nGoldAmt).Size = new Size(76, 22);
		((Control)nGoldAmt).TabIndex = 2;
		nGoldAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(381, 13);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(111, 20);
		((Control)Label4).TabIndex = 1179;
		Label4.Text = "Gold Rate 10 gm";
		Label4.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_BALANCE).AllowUserToAddRows = false;
		((DataGridView)DGV_BALANCE).AllowUserToDeleteRows = false;
		((DataGridView)DGV_BALANCE).AllowUserToResizeRows = false;
		val16.BackColor = Color.PapayaWhip;
		val16.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val16.ForeColor = Color.FromArgb(64, 64, 64);
		val16.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val16.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle = val16;
		((DataGridView)DGV_BALANCE).BackgroundColor = Color.Snow;
		((DataGridView)DGV_BALANCE).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_BALANCE).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val17.Alignment = (DataGridViewContentAlignment)16;
		val17.BackColor = SystemColors.Control;
		val17.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val17.ForeColor = Color.FromArgb(64, 64, 64);
		val17.SelectionBackColor = SystemColors.ScrollBar;
		val17.SelectionForeColor = Color.White;
		val17.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle = val17;
		((DataGridView)DGV_BALANCE).ColumnHeadersHeight = 30;
		((DataGridView)DGV_BALANCE).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val18.Alignment = (DataGridViewContentAlignment)16;
		val18.BackColor = SystemColors.Window;
		val18.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val18.ForeColor = Color.FromArgb(64, 64, 64);
		val18.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val18.SelectionForeColor = Color.Maroon;
		val18.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_BALANCE).DefaultCellStyle = val18;
		((DataGridView)DGV_BALANCE).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_BALANCE).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_BALANCE).Location = new Point(13, 43);
		((Control)DGV_BALANCE).Name = "DGV_BALANCE";
		DGV_BALANCE.PaintEnhancedSelection = false;
		((DataGridView)DGV_BALANCE).ReadOnly = true;
		val19.Alignment = (DataGridViewContentAlignment)16;
		val19.BackColor = Color.MintCream;
		val19.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val19.ForeColor = SystemColors.WindowText;
		val19.SelectionBackColor = SystemColors.Highlight;
		val19.SelectionForeColor = SystemColors.HighlightText;
		val19.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_BALANCE).RowHeadersDefaultCellStyle = val19;
		((DataGridView)DGV_BALANCE).RowHeadersVisible = false;
		((DataGridView)DGV_BALANCE).RowHeadersWidth = 20;
		val20.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val20.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_BALANCE).RowsDefaultCellStyle = val20;
		DGV_BALANCE.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_BALANCE.SelectAllSignVisible = false;
		((DataGridView)DGV_BALANCE).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_BALANCE).Size = new Size(1160, 475);
		((DataGridView)DGV_BALANCE).StandardTab = true;
		((Control)DGV_BALANCE).TabIndex = 2;
		((ButtonBase)chkTodayBal).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkTodayBal).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkTodayBal).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkTodayBal).Location = new Point(19, 7);
		((Control)chkTodayBal).Name = "chkTodayBal";
		((Control)chkTodayBal).RightToLeft = (RightToLeft)0;
		((Control)chkTodayBal).Size = new Size(141, 20);
		((Control)chkTodayBal).TabIndex = 1154;
		((ButtonBase)chkTodayBal).Text = "ToDay Balance";
		((ButtonBase)chkTodayBal).UseVisualStyleBackColor = false;
		((ButtonBase)chkLedrFine).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkLedrFine).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkLedrFine).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkLedrFine).Location = new Point(1032, 7);
		((Control)chkLedrFine).Name = "chkLedrFine";
		((Control)chkLedrFine).RightToLeft = (RightToLeft)0;
		((Control)chkLedrFine).Size = new Size(163, 20);
		((Control)chkLedrFine).TabIndex = 1155;
		((ButtonBase)chkLedrFine).Text = "Ledger Amt With Fine";
		((ButtonBase)chkLedrFine).UseVisualStyleBackColor = false;
		((Control)chkLedrFine).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkLedrFine);
		((Control)this).Controls.Add((Control)(object)chkTodayBal);
		((Control)this).Controls.Add((Control)(object)PnlGrSumm);
		((Control)this).Controls.Add((Control)(object)chkOpBal);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)DGV_VCH);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)lblRefby);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_BAL_ZOOM";
		((Form)this).Text = "Balance Sheet Zoom";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_AC).EndInit();
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)tSearch.Properties).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)PnlGrSumm).ResumeLayout(false);
		((Control)PnlGrSumm).PerformLayout();
		((ISupportInitialize)DGV_BALANCE).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void TOT_FINE_SUMM()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e62: Expected O, but got Unknown
		//IL_0ebd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec7: Expected O, but got Unknown
		//IL_2d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d78: Expected O, but got Unknown
		//IL_2dd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddd: Expected O, but got Unknown
		//IL_2fc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fce: Expected O, but got Unknown
		//IL_3029: Unknown result type (might be due to invalid IL or missing references)
		//IL_3033: Expected O, but got Unknown
		//IL_31d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_31e0: Expected O, but got Unknown
		//IL_323b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3245: Expected O, but got Unknown
		((DataGridView)DGV_BALANCE).DataSource = null;
		((DataGridView)DGV_BALANCE).ClearSelection();
		((DataGridView)DGV_BALANCE).Rows.Clear();
		((DataGridView)DGV_BALANCE).Columns.Clear();
		((Control)DGV_BALANCE).Refresh();
		((DataGridView)DGV_BALANCE).MultiSelect = false;
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_BALANCE).AutoGenerateColumns = false;
		((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
		checked
		{
			((DataGridView)DGV_BALANCE).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[0].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[1].Width = (int)Math.Round(280.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrFine");
			((DataGridView)DGV_BALANCE).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[2].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrAmt");
			((DataGridView)DGV_BALANCE).Columns[3].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
			((DataGridView)DGV_BALANCE).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[5].Width = (int)Math.Round(280.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrFine");
			((DataGridView)DGV_BALANCE).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrAmt");
			((DataGridView)DGV_BALANCE).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Format = "N2";
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			int num9 = 0;
			int num10 = 0;
			double num11 = 0.0;
			DC_Main.ExeQuteDc("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '999'");
			Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), DC_Main.MsRptBalZoomType, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
			DC_Main.RsQry = "SELECT * FROM  AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAIN_GR IN ('1','2')";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_GR,SUM(A.CR_AMT) AS CrAmt ,SUM(A.DR_AMT) As DrAmt FROM LEDR_AC_DATA AS A   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND VCH_DT >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  and VCH_DT <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_GR ORDER BY A.AC_GR "));
			RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(RsLdr);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (dataTable.Rows.Count > 0)
			{
				int num12 = dataTable.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num12)
				{
					DataGridViewX dGV_BALANCE = DGV_BALANCE;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_GR =  '", dataTable.Rows[DC_Main.M]["AC_GR"]), (object)"' "));
					if (dataView.Count > 0)
					{
						int num13 = dataView.Count - 1;
						for (int i = 0; i <= num13; i++)
						{
							DataGridViewCell val;
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[0, num9].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[1, num9].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								(val = ((DataGridView)dGV_BALANCE)[3, num9]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
								if (chkLedrFine.Checked)
								{
									if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
									{
										if (Conversion.Val(nSilverAmt.Text) != 0.0)
										{
											(val = ((DataGridView)dGV_BALANCE)[2, num9]).Value = Operators.AddObject(val.Value, (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])) / (Conversion.Val(nSilverAmt.Text) / 10.0)));
										}
									}
									else if (Conversion.Val(nGoldAmt.Text) != 0.0)
									{
										(val = ((DataGridView)dGV_BALANCE)[2, num9]).Value = Operators.AddObject(val.Value, (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])) / (Conversion.Val(nGoldAmt.Text) / 10.0)));
									}
								}
							}
							if (!(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])) > 0.0))
							{
								continue;
							}
							((DataGridView)dGV_BALANCE)[4, num10].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
							((DataGridView)dGV_BALANCE)[5, num10].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
							(val = ((DataGridView)dGV_BALANCE)[7, num10]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])));
							if (!chkLedrFine.Checked)
							{
								continue;
							}
							if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
							{
								if (Conversion.Val(nSilverAmt.Text) != 0.0)
								{
									(val = ((DataGridView)dGV_BALANCE)[6, num10]).Value = Operators.AddObject(val.Value, (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])) / (Conversion.Val(nSilverAmt.Text) / 10.0)));
								}
							}
							else if (Conversion.Val(nGoldAmt.Text) != 0.0)
							{
								(val = ((DataGridView)dGV_BALANCE)[6, num10]).Value = Operators.AddObject(val.Value, (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])) / (Conversion.Val(nGoldAmt.Text) / 10.0)));
							}
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num9].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num10].Value));
						num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[2, num9].Value));
						num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[6, num10].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num9].Value)) != 0.0)
						{
							if (num9 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num9++;
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num10].Value)) != 0.0)
						{
							if (num10 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num10++;
						}
					}
					dGV_BALANCE = null;
					DC_Main.M++;
				}
			}
			num7 = num;
			num8 = num2;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num9].Value = num;
			((DataGridView)DGV_BALANCE)[7, num10].Value = num2;
			if (chkLedrFine.Checked)
			{
				((DataGridView)DGV_BALANCE)[2, num9].Value = num5;
				((DataGridView)DGV_BALANCE)[6, num10].Value = num6;
			}
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (DC_Main.MsOnlyOpBalnce)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE ,SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" AND A.LC_CODE = '" + DC_Main.MLc_code + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"' and AC_CODE NOT IN ('00045','00050','00098') "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY  A.AC_CODE "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE ,SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)(" AND A.LC_CODE = '" + DC_Main.MLc_code + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'  and AC_CODE NOT IN ('00045','00050','00098') "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY  A.AC_CODE "));
			}
			RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			double num15 = default(double);
			double num16 = default(double);
			double num17 = default(double);
			double num18 = default(double);
			if (RsLdr.Rows.Count > 0)
			{
				int num14 = RsLdr.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num14)
				{
					if (Operators.ConditionalCompareObjectGreater(RsLdr.Rows[DC_Main.M]["GoldWt"], (object)0, false))
					{
						num15 += Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsLdr.Rows[DC_Main.M]["GoldWt"]), "0.000"));
					}
					else
					{
						num16 += Conversions.ToDouble(Strings.Format((object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(RsLdr.Rows[DC_Main.M]["GoldWt"]))), "0.000"));
					}
					if (Operators.ConditionalCompareObjectGreater(RsLdr.Rows[DC_Main.M]["SilverWt"], (object)0, false))
					{
						num17 += Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsLdr.Rows[DC_Main.M]["SilverWt"]), "0.000"));
					}
					else
					{
						num18 += Conversions.ToDouble(Strings.Format((object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(RsLdr.Rows[DC_Main.M]["SilverWt"]))), "0.000"));
					}
					DC_Main.M++;
				}
			}
			double num19 = 0.0;
			double num20 = 0.0;
			num19 = num15 - num16;
			num20 = num17 - num18;
			if (num19 > 0.0)
			{
				((DataGridView)DGV_BALANCE)[0, num9].Value = "FG";
				((DataGridView)DGV_BALANCE)[1, num9].Value = "PARTY GOLD";
				((DataGridView)DGV_BALANCE)[2, num9].Value = num19;
				((DataGridView)DGV_BALANCE)[3, num9].Value = Strings.Format((object)(num19 * (Conversion.Val(nGoldAmt.Text) / 10.0)), "0.00");
			}
			if (num19 < 0.0)
			{
				((DataGridView)DGV_BALANCE)[4, num10].Value = "FG";
				((DataGridView)DGV_BALANCE)[5, num10].Value = "PARTY GOLD";
				((DataGridView)DGV_BALANCE)[6, num10].Value = Math.Abs(num19);
				((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)(Math.Abs(num19) * (Conversion.Val(nGoldAmt.Text) / 10.0)), "0.00");
			}
			num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_BALANCE)[3, num9].Value));
			num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_BALANCE)[7, num10].Value));
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (num20 > 0.0)
			{
				((DataGridView)DGV_BALANCE)[0, num9].Value = "FS";
				((DataGridView)DGV_BALANCE)[1, num9].Value = "PARTY SILVER";
				((DataGridView)DGV_BALANCE)[2, num9].Value = num20;
				((DataGridView)DGV_BALANCE)[3, num9].Value = Strings.Format((object)(num20 * (Conversion.Val(nSilverAmt.Text) / 10.0)), "0.00");
			}
			if (num20 < 0.0)
			{
				((DataGridView)DGV_BALANCE)[4, num10].Value = "FS";
				((DataGridView)DGV_BALANCE)[5, num10].Value = "PARTY SILVER";
				((DataGridView)DGV_BALANCE)[6, num10].Value = Math.Abs(num20);
				((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)(Math.Abs(num20) * (Conversion.Val(nSilverAmt.Text) / 10.0)), "0.00");
			}
			num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_BALANCE)[3, num9].Value));
			num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_BALANCE)[7, num10].Value));
			DateTime dateTime;
			if (DC_Main.MsOnlyOpBalnce)
			{
				DC_Main.AvgTouch(DC_Main.MOp_dt.AddDays(-1.0), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("And A.LC_CODE = '" + tLcCode.Text + "'"))));
				dateTime = DC_Main.MOp_dt.AddDays(-1.0);
			}
			else
			{
				DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)));
				dateTime = Conversions.ToDate(mToDt.Text);
			}
			if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE As ItType,0 As ClFine,B.AVG_RATE As WtRate,B.PCS_RATE As PcsRate,B.AVG_TOUCH,B.GR_CODE, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.IT_CODE <> '' AND B.RATE_TYPE <> 'P' "));
				DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE,B.AVG_FINE,B.AVG_TOUCH,B.GR_CODE,B.AVG_RATE,B.PCS_RATE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME";
			}
			else if (Operators.CompareString(DC_Main.MsTotFineStkType, "T", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.TRAD_TYPE AS Code ,C.TRAD_NAME AS Name,C.IT_TYPE As ItType,C.AVG_FINE As ClFine,C.AVG_TOUCH,C.AVG_AMT,C.CLG_AC,C.CLOSING_AC,C.TRAD_AMT, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" And A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.TRAD_TYPE <> '' AND A.ITM_MRP = 0 AND B.RATE_TYPE <> 'P' "));
				DC_Main.RsQry += "GROUP BY B.TRAD_TYPE,C.TRAD_NAME,C.IT_TYPE,C.AVG_FINE,C.AVG_TOUCH,C.AVG_AMT,C.CLG_AC,C.CLOSING_AC,C.TRAD_AMT ORDER BY C.TRAD_NAME";
			}
			else if (Operators.CompareString(DC_Main.MsTotFineStkType, "G", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.GR_CODE AS Code,C.GR_NAME AS Name,C.GR_TYPE As ItType,C.AVG_FINE As ClFine,C.AVG_TOUCH, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.GR_CODE <> '' AND A.ITM_MRP = 0 AND B.RATE_TYPE <> 'P' "));
				DC_Main.RsQry += "GROUP BY B.GR_CODE,C.GR_NAME,C.GR_TYPE,C.AVG_FINE,C.AVG_TOUCH ORDER BY C.GR_TYPE,C.GR_NAME";
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE As ItType,B.AVG_FINE As ClFine,B.AVG_TOUCH,B.GR_CODE, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.IT_CODE <> '' AND A.ITM_MRP = 0 AND B.RATE_TYPE <> 'P' "));
				DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE,B.AVG_FINE,B.AVG_TOUCH,B.GR_CODE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME";
			}
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			int num24 = dataTable2.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num24)
			{
				((DataGridView)DGV_BALANCE).Rows.Add();
				num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
				((DataGridView)DGV_BALANCE)[4, num10].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["Code"]);
				if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
				{
					((DataGridView)DGV_BALANCE)[5, num10].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["Name"], (object)" / "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"])), "0.000")), (object)" / "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["WtRate"])), "0.00"));
					((DataGridView)DGV_BALANCE)[6, num10].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["ItType"], (object)""), (object)"G", false))
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["WtRate"])) != 0.0)
						{
							((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["WtRate"]))), "0.00");
							num22 += Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"]));
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["ItType"], (object)""), (object)"S", false) && Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["WtRate"])) != 0.0)
					{
						((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["WtRate"]))), "0.00");
						num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"]));
					}
				}
				else
				{
					((DataGridView)DGV_BALANCE)[5, num10].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["Name"], (object)" / "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClNwt"])), "0.000")), (object)" / "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AVG_TOUCH"])), "0.00"));
					((DataGridView)DGV_BALANCE)[6, num10].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClFine"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["ItType"], (object)""), (object)"G", false))
					{
						if (Conversion.Val(nGoldAmt.Text) != 0.0)
						{
							((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClFine"])) * (Conversion.Val(nGoldAmt.Text) / 10.0)), "0.00");
							num22 += Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClFine"]));
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["ItType"], (object)""), (object)"S", false) && Conversion.Val(nSilverAmt.Text) != 0.0)
					{
						((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClFine"])) * (Conversion.Val(nSilverAmt.Text) / 10.0)), "0.00");
						num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClFine"]));
					}
				}
				num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_BALANCE)[7, num10].Value));
				DC_Main.M++;
			}
			((DataGridView)DGV_BALANCE).Rows.Add();
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
			{
				((DataGridView)DGV_BALANCE)[5, num10].Value = "Gold Nwt : " + Strings.Format((object)num22, "0.00") + " Silver Nwt : " + Strings.Format((object)num23, "0.00");
			}
			else
			{
				((DataGridView)DGV_BALANCE)[5, num10].Value = "Gold Fine : " + Strings.Format((object)num22, "0.00") + " Silver Fine : " + Strings.Format((object)num23, "0.00");
			}
			if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE As ItType,0 As ClFine,B.AVG_RATE As WtRate,B.PCS_RATE As PcsRate,B.AVG_TOUCH,B.GR_CODE, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.IT_CODE <> '' AND B.RATE_TYPE = 'P' "));
				DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE,B.AVG_FINE,B.AVG_TOUCH,B.GR_CODE,B.AVG_RATE,B.PCS_RATE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME";
			}
			else if (Operators.CompareString(DC_Main.MsTotFineStkType, "T", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.TRAD_TYPE AS Code,C.TRAD_NAME AS Name,C.IT_TYPE As ItType,0 As ClFine,0 AS AVG_RATE,C.AVG_AMT, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.IT_CODE <> '' AND (RATE_TYPE = 'P' or A.ITM_MRP <> 0)"));
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY B.TRAD_TYPE,C.TRAD_NAME,C.IT_TYPE,C.AVG_AMT  HAVING SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) > 0 ORDER BY C.IT_TYPE,B.TRAD_TYPE,C.TRAD_NAME";
			}
			else if (Operators.CompareString(DC_Main.MsTotFineStkType, "G", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.GR_CODE AS Code,C.GR_NAME AS Name,C.GR_TYPE As ItType,B.AVG_FINE As ClFine,B.AVG_RATE,B.GR_CODE, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.IT_CODE <> '' AND (RATE_TYPE = 'P' or A.ITM_MRP <> 0)"));
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY B.GR_CODE,C.GR_NAME,C.GR_TYPE,B.AVG_FINE,B.AVG_RATE,B.GR_CODE  HAVING SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) > 0 ORDER BY C.GR_TYPE,B.GR_CODE,C.GR_NAME";
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE As ItType,B.AVG_FINE As ClFine,B.AVG_RATE,B.GR_CODE, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.IT_CODE <> '' AND (RATE_TYPE = 'P' or A.ITM_MRP <> 0)"));
				DC_Main.RsQry = DC_Main.RsQry + "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE,B.AVG_FINE,B.AVG_RATE,B.GR_CODE  HAVING SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) > 0 ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME";
			}
			dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			int num25 = dataTable2.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num25)
			{
				((DataGridView)DGV_BALANCE).Rows.Add();
				num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
				((DataGridView)DGV_BALANCE)[4, num10].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["Code"]);
				if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
				{
					((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClPcs"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["PcsRate"]))), "0.00");
					((DataGridView)DGV_BALANCE)[5, num10].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["Name"], (object)" /  "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["PcsRate"])), "0.00"));
					((DataGridView)DGV_BALANCE)[6, num10].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClPcs"])), "0");
				}
				else if (Operators.CompareString(DC_Main.MsTotFineStkType, "T", false) == 0)
				{
					((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)Math.Round(Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AVG_AMT"], (object)""))), "0.00");
					((DataGridView)DGV_BALANCE)[5, num10].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["Name"]);
					((DataGridView)DGV_BALANCE)[6, num10].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClPcs"])), "0");
				}
				else
				{
					((DataGridView)DGV_BALANCE)[7, num10].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClPcs"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AVG_RATE"]))), "0.00");
					((DataGridView)DGV_BALANCE)[5, num10].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["Name"], (object)" /  "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AVG_RATE"])), "0.00"));
					((DataGridView)DGV_BALANCE)[6, num10].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ClPcs"])), "0");
				}
				num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_BALANCE)[7, num10].Value));
				DC_Main.M++;
			}
			num8 += num21;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[5, num10].Value = "Stock Value :";
			((DataGridView)DGV_BALANCE)[7, num10].Value = num21;
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[5].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num9].Value = num7;
			((DataGridView)DGV_BALANCE)[7, num10].Value = num8;
			if (chkLedrFine.Checked)
			{
				if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
				{
					if (Conversion.Val(nSilverAmt.Text) != 0.0)
					{
						((DataGridView)DGV_BALANCE)[2, num9].Value = num7 / (Conversions.ToDouble(nSilverAmt.Text) / 10.0);
						((DataGridView)DGV_BALANCE)[6, num10].Value = num8 / (Conversions.ToDouble(nSilverAmt.Text) / 10.0);
					}
				}
				else if (Conversion.Val(nGoldAmt.Text) != 0.0)
				{
					((DataGridView)DGV_BALANCE)[2, num9].Value = num7 / (Conversions.ToDouble(nGoldAmt.Text) / 10.0);
					((DataGridView)DGV_BALANCE)[6, num10].Value = num8 / (Conversions.ToDouble(nGoldAmt.Text) / 10.0);
				}
			}
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num9].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num9 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num10 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (num8 - num7 > 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num10].Value = "Net Profit : ";
				((DataGridView)DGV_BALANCE)[7, num10].Value = num8 - num7;
				if (chkLedrFine.Checked)
				{
					if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
					{
						if (Conversion.Val(nSilverAmt.Text) != 0.0)
						{
							((DataGridView)DGV_BALANCE)[6, num10].Value = (num8 - num7) / (Conversions.ToDouble(nSilverAmt.Text) / 10.0);
						}
					}
					else if (Conversion.Val(nGoldAmt.Text) != 0.0)
					{
						((DataGridView)DGV_BALANCE)[6, num10].Value = (num8 - num7) / (Conversions.ToDouble(nGoldAmt.Text) / 10.0);
					}
				}
				((DataGridView)DGV_BALANCE).Rows[num10].Cells[5].Style.ForeColor = Color.Maroon;
				((DataGridView)DGV_BALANCE).Rows[num10].Cells[5].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
				((DataGridView)DGV_BALANCE).Rows[num10].Cells[7].Style.ForeColor = Color.Maroon;
				((DataGridView)DGV_BALANCE).Rows[num10].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			}
			else
			{
				if (!(num7 - num8 > 0.0))
				{
					return;
				}
				((DataGridView)DGV_BALANCE)[5, num9].Value = "Net Loss : ";
				((DataGridView)DGV_BALANCE)[7, num9].Value = num7 - num8;
				if (chkLedrFine.Checked)
				{
					if (Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0)
					{
						if (Conversion.Val(nSilverAmt.Text) != 0.0)
						{
							((DataGridView)DGV_BALANCE)[2, num9].Value = (num7 - num8) / (Conversions.ToDouble(nSilverAmt.Text) / 10.0);
						}
					}
					else if (Conversion.Val(nGoldAmt.Text) != 0.0)
					{
						((DataGridView)DGV_BALANCE)[2, num9].Value = (num7 - num8) / (Conversions.ToDouble(nGoldAmt.Text) / 10.0);
					}
				}
				((DataGridView)DGV_BALANCE).Rows[num9].Cells[1].Style.ForeColor = Color.Maroon;
				((DataGridView)DGV_BALANCE).Rows[num9].Cells[1].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
				((DataGridView)DGV_BALANCE).Rows[num9].Cells[3].Style.ForeColor = Color.Maroon;
				((DataGridView)DGV_BALANCE).Rows[num9].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			}
		}
	}

	private void BAL_SUMM()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Expected O, but got Unknown
		//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7f: Expected O, but got Unknown
		//IL_0cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d03: Expected O, but got Unknown
		//IL_0d5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d68: Expected O, but got Unknown
		//IL_0dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcd: Expected O, but got Unknown
		//IL_0e28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e32: Expected O, but got Unknown
		((DataGridView)DGV_BALANCE).DataSource = null;
		((DataGridView)DGV_BALANCE).ClearSelection();
		((DataGridView)DGV_BALANCE).Rows.Clear();
		((DataGridView)DGV_BALANCE).Columns.Clear();
		((Control)DGV_BALANCE).Refresh();
		((DataGridView)DGV_BALANCE).MultiSelect = false;
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_BALANCE).AutoGenerateColumns = false;
		((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
		checked
		{
			((DataGridView)DGV_BALANCE).Columns[0].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[0].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrFine");
			((DataGridView)DGV_BALANCE).Columns[2].Visible = false;
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrAmt");
			((DataGridView)DGV_BALANCE).Columns[3].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
			((DataGridView)DGV_BALANCE).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[5].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrFine");
			((DataGridView)DGV_BALANCE).Columns[6].Visible = false;
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrAmt");
			((DataGridView)DGV_BALANCE).Columns[7].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Format = "N2";
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			int num8 = 0;
			double num9 = 0.0;
			Ac_Final.Trading_Stock(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)), Conversion.Val(nGoldAmt.Text), Conversion.Val(nSilverAmt.Text));
			Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), DC_Main.MsRptBalZoomType, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
			DC_Main.RsQry = "SELECT * FROM  AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAIN_GR IN ('1','2')";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_GR,SUM(A.CR_AMT) AS CrAmt ,SUM(A.DR_AMT) As DrAmt FROM LEDR_AC_DATA AS A   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND VCH_DT >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  and VCH_DT <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_GR ORDER BY A.AC_GR "));
			RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(RsLdr);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (dataTable.Rows.Count > 0)
			{
				int num10 = dataTable.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num10)
				{
					DataGridViewX dGV_BALANCE = DGV_BALANCE;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_GR =  '", dataTable.Rows[DC_Main.M]["AC_GR"]), (object)"' "));
					if (dataView.Count > 0)
					{
						int num11 = dataView.Count - 1;
						for (int i = 0; i <= num11; i++)
						{
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[0, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								string text = Conversions.ToString(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE)[3, num7]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
								int num12 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
							}
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[4, num8].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[5, num8].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE)[7, num8]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])));
							}
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num7].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num8].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num7].Value)) != 0.0)
						{
							if (num7 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num7++;
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num8].Value)) != 0.0)
						{
							if (num8 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num8++;
						}
					}
					dGV_BALANCE = null;
					DC_Main.M++;
				}
			}
			num5 = num;
			num6 = num2;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num7].Value = num;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num2;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num9 = num2 - num;
			if (num9 > 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num8].Value = "Net Profit : ";
				((DataGridView)DGV_BALANCE)[7, num8].Value = num9;
			}
			else if (num9 < 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num7].Value = "Net Loos : ";
				((DataGridView)DGV_BALANCE)[3, num7].Value = Math.Abs(num9);
			}
			else
			{
				((DataGridView)DGV_BALANCE)[5, num8].Value = "Net Profit : ";
				((DataGridView)DGV_BALANCE)[5, num7].Value = "Net Loos : ";
			}
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[5].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[5].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
		}
	}

	private void PROFIT_SUMM()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3f: Expected O, but got Unknown
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba4: Expected O, but got Unknown
		//IL_0d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d28: Expected O, but got Unknown
		//IL_0d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8d: Expected O, but got Unknown
		//IL_0de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df2: Expected O, but got Unknown
		//IL_0e4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e57: Expected O, but got Unknown
		//IL_12ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f4: Expected O, but got Unknown
		//IL_134f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1359: Expected O, but got Unknown
		//IL_144d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1457: Expected O, but got Unknown
		//IL_14b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bc: Expected O, but got Unknown
		//IL_1517: Unknown result type (might be due to invalid IL or missing references)
		//IL_1521: Expected O, but got Unknown
		//IL_169d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a7: Expected O, but got Unknown
		//IL_1702: Unknown result type (might be due to invalid IL or missing references)
		//IL_170c: Expected O, but got Unknown
		//IL_1767: Unknown result type (might be due to invalid IL or missing references)
		//IL_1771: Expected O, but got Unknown
		//IL_17cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d6: Expected O, but got Unknown
		((DataGridView)DGV_BALANCE).DataSource = null;
		((DataGridView)DGV_BALANCE).ClearSelection();
		((DataGridView)DGV_BALANCE).Rows.Clear();
		((DataGridView)DGV_BALANCE).Columns.Clear();
		((Control)DGV_BALANCE).Refresh();
		((DataGridView)DGV_BALANCE).MultiSelect = false;
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_BALANCE).AutoGenerateColumns = false;
		((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
		checked
		{
			((DataGridView)DGV_BALANCE).Columns[0].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[0].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrFine");
			((DataGridView)DGV_BALANCE).Columns[2].Visible = false;
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrAmt");
			((DataGridView)DGV_BALANCE).Columns[3].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
			((DataGridView)DGV_BALANCE).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[5].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrFine");
			((DataGridView)DGV_BALANCE).Columns[6].Visible = false;
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrAmt");
			((DataGridView)DGV_BALANCE).Columns[7].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Format = "N2";
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			int num8 = 0;
			double num9 = 0.0;
			Ac_Final.Trading_Stock(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)), Conversion.Val(nGoldAmt.Text), Conversion.Val(nSilverAmt.Text));
			Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), DC_Main.MsRptBalZoomType, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
			DC_Main.RsQry = "SELECT * FROM  AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAIN_GR IN ('3','4')";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM  AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAIN_GR IN ('5','6')";
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_GR,SUM(A.CR_AMT) AS CrAmt ,SUM(A.DR_AMT) As DrAmt FROM LEDR_AC_DATA AS A   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND VCH_DT >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  and VCH_DT <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_GR ORDER BY A.AC_GR "));
			RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(RsLdr);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (dataTable.Rows.Count > 0)
			{
				int num10 = dataTable.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num10)
				{
					DataGridViewX dGV_BALANCE = DGV_BALANCE;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_GR =  '", dataTable.Rows[DC_Main.M]["AC_GR"]), (object)"' "));
					if (dataView.Count > 0)
					{
						int num11 = dataView.Count - 1;
						for (int i = 0; i <= num11; i++)
						{
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[0, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								string text = Conversions.ToString(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE)[3, num7]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
								int num12 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
							}
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[4, num8].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[5, num8].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE)[7, num8]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])));
							}
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num7].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num8].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num7].Value)) != 0.0)
						{
							if (num7 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num7++;
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num8].Value)) != 0.0)
						{
							if (num8 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num8++;
						}
					}
					dGV_BALANCE = null;
					DC_Main.M++;
				}
			}
			num5 = num;
			num6 = num2;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num7].Value = num;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num2;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num9 = num - num2;
			if (num9 > 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num8].Value = "Gross Profit : ";
				((DataGridView)DGV_BALANCE)[7, num8].Value = num9;
			}
			else if (num9 < 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num7].Value = "Gross Loos : ";
				((DataGridView)DGV_BALANCE)[3, num7].Value = Math.Abs(num9);
			}
			else
			{
				((DataGridView)DGV_BALANCE)[5, num8].Value = "Gross Profit : ";
				((DataGridView)DGV_BALANCE)[5, num7].Value = "Gross Loos : ";
			}
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[5].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[5].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num = 0.0;
			num2 = 0.0;
			if (dataTable2.Rows.Count > 0)
			{
				int num13 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num13)
				{
					DataGridViewX dGV_BALANCE2 = DGV_BALANCE;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_GR =  '", dataTable2.Rows[DC_Main.M]["AC_GR"]), (object)"' "));
					if (dataView.Count > 0)
					{
						int num14 = dataView.Count - 1;
						for (int j = 0; j <= num14; j++)
						{
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["CrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE2)[0, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE2)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE2)[3, num7]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["CrAmt"])));
							}
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["DrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE2)[4, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE2)[5, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE2)[7, num8]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["DrAmt"])));
							}
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[3, num7].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[7, num8].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[3, num7].Value)) != 0.0)
						{
							if (num7 == ((DataGridView)dGV_BALANCE2).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE2).Rows.Add();
							}
							num7++;
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[7, num8].Value)) != 0.0)
						{
							if (num8 == ((DataGridView)dGV_BALANCE2).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE2).Rows.Add();
							}
							num8++;
						}
					}
					dGV_BALANCE2 = null;
					DC_Main.M++;
				}
			}
			num5 += num;
			num6 += num2;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num7].Value = num;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num2;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[1, num7].Value = "Total Balance :";
			((DataGridView)DGV_BALANCE)[3, num7].Value = num5;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num6;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num9 = num5 - num6;
			if (num9 > 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num8].Value = "Net Profit : ";
				((DataGridView)DGV_BALANCE)[7, num8].Value = num9;
			}
			else if (num9 < 0.0)
			{
				((DataGridView)DGV_BALANCE)[5, num7].Value = "Net Loos : ";
				((DataGridView)DGV_BALANCE)[3, num7].Value = Math.Abs(num9);
			}
			else
			{
				((DataGridView)DGV_BALANCE)[5, num8].Value = "Net Profit : ";
				((DataGridView)DGV_BALANCE)[5, num7].Value = "Net Loos : ";
			}
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[5].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[5].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
		}
	}

	private void TRIAL_BAL_SUMM()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b34: Expected O, but got Unknown
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected O, but got Unknown
		//IL_102c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1036: Expected O, but got Unknown
		//IL_1091: Unknown result type (might be due to invalid IL or missing references)
		//IL_109b: Expected O, but got Unknown
		//IL_118f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1199: Expected O, but got Unknown
		//IL_11f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fe: Expected O, but got Unknown
		//IL_1259: Unknown result type (might be due to invalid IL or missing references)
		//IL_1263: Expected O, but got Unknown
		((DataGridView)DGV_BALANCE).DataSource = null;
		((DataGridView)DGV_BALANCE).ClearSelection();
		((DataGridView)DGV_BALANCE).Rows.Clear();
		((DataGridView)DGV_BALANCE).Columns.Clear();
		((Control)DGV_BALANCE).Refresh();
		((DataGridView)DGV_BALANCE).MultiSelect = false;
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_BALANCE).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_BALANCE).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_BALANCE).AutoGenerateColumns = false;
		((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
		checked
		{
			((DataGridView)DGV_BALANCE).Columns[0].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[0].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrFine");
			((DataGridView)DGV_BALANCE).Columns[2].Visible = false;
			((DataGridView)DGV_BALANCE).Columns.Add("", "CrAmt");
			((DataGridView)DGV_BALANCE).Columns[3].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[3].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_BALANCE).Columns.Add("", "Code");
			((DataGridView)DGV_BALANCE).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_BALANCE).Columns.Add("", "Group Name");
			((DataGridView)DGV_BALANCE).Columns[5].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrFine");
			((DataGridView)DGV_BALANCE).Columns[6].Visible = false;
			((DataGridView)DGV_BALANCE).Columns.Add("", "DrAmt");
			((DataGridView)DGV_BALANCE).Columns[7].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_BALANCE).Columns[7].DefaultCellStyle.Format = "N2";
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			int num8 = 0;
			Ac_Final.Trading_Stock(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)), Conversion.Val(nGoldAmt.Text), Conversion.Val(nSilverAmt.Text));
			Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), DC_Main.MsRptBalZoomType, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
			DC_Main.RsQry = "SELECT * FROM  AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAIN_GR IN ('1','2')";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM  AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAIN_GR IN ('3','4','5','6')";
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_GR,SUM(A.CR_AMT) AS CrAmt ,SUM(A.DR_AMT) As DrAmt FROM LEDR_AC_DATA AS A   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND VCH_DT >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'  and VCH_DT <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.AC_GR ORDER BY A.AC_GR "));
			RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(RsLdr);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			if (dataTable.Rows.Count > 0)
			{
				int num9 = dataTable.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num9)
				{
					DataGridViewX dGV_BALANCE = DGV_BALANCE;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_GR =  '", dataTable.Rows[DC_Main.M]["AC_GR"]), (object)"' "));
					if (dataView.Count > 0)
					{
						int num10 = dataView.Count - 1;
						for (int i = 0; i <= num10; i++)
						{
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[0, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								string text = Conversions.ToString(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE)[3, num7]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
								int num11 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["CrAmt"])));
							}
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE)[4, num8].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE)[5, num8].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE)[7, num8]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[i]["DrAmt"])));
							}
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num7].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num8].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[3, num7].Value)) != 0.0)
						{
							if (num7 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num7++;
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE)[7, num8].Value)) != 0.0)
						{
							if (num8 == ((DataGridView)dGV_BALANCE).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE).Rows.Add();
							}
							num8++;
						}
					}
					dGV_BALANCE = null;
					DC_Main.M++;
				}
			}
			num5 = num;
			num6 = num2;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num7].Value = num;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num2;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num = 0.0;
			num2 = 0.0;
			if (dataTable2.Rows.Count > 0)
			{
				int num12 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num12)
				{
					DataGridViewX dGV_BALANCE2 = DGV_BALANCE;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_GR =  '", dataTable2.Rows[DC_Main.M]["AC_GR"]), (object)"' "));
					if (dataView.Count > 0)
					{
						int num13 = dataView.Count - 1;
						for (int j = 0; j <= num13; j++)
						{
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["CrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE2)[0, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE2)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE2)[3, num7]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["CrAmt"])));
							}
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["DrAmt"])) > 0.0)
							{
								((DataGridView)dGV_BALANCE2)[4, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR"]);
								((DataGridView)dGV_BALANCE2)[5, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_GR_NAME"]);
								DataGridViewCell val;
								(val = ((DataGridView)dGV_BALANCE2)[7, num8]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[j]["DrAmt"])));
							}
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[3, num7].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[7, num8].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[3, num7].Value)) != 0.0)
						{
							if (num7 == ((DataGridView)dGV_BALANCE2).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE2).Rows.Add();
							}
							num7++;
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_BALANCE2)[7, num8].Value)) != 0.0)
						{
							if (num8 == ((DataGridView)dGV_BALANCE2).Rows.Count - 1)
							{
								((DataGridView)dGV_BALANCE2).Rows.Add();
							}
							num8++;
						}
					}
					dGV_BALANCE2 = null;
					DC_Main.M++;
				}
			}
			num5 += num;
			num6 += num2;
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[3, num7].Value = num;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num2;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows.Add();
			((DataGridView)DGV_BALANCE).Rows.Add();
			num7 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			num8 = ((DataGridView)DGV_BALANCE).Rows.Count - 1;
			((DataGridView)DGV_BALANCE)[1, num7].Value = "Total Balance :";
			((DataGridView)DGV_BALANCE)[3, num7].Value = num5;
			((DataGridView)DGV_BALANCE)[7, num8].Value = num6;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[1].Style.Font = new Font("Bahnschrift", 11f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[3].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.ForeColor = Color.Maroon;
			((DataGridView)DGV_BALANCE).Rows[num7].Cells[7].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		object obj = default(object);
		int num5 = default(int);
		int num6 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		int num13 = default(int);
		int num14 = default(int);
		int num15 = default(int);
		int num16 = default(int);
		int num17 = default(int);
		int num18 = default(int);
		int num19 = default(int);
		int num20 = default(int);
		int num21 = default(int);
		int num22 = default(int);
		int num23 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num24 = default(int);
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
						num2 = 1;
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 3388:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_001e;
							case 4:
							case 5:
								goto IL_0034;
							case 6:
								goto IL_004b;
							case 7:
								goto IL_007d;
							case 8:
								goto IL_00a5;
							case 9:
								goto IL_00ae;
							case 10:
								goto IL_00d6;
							case 11:
								goto IL_0109;
							case 12:
								goto IL_012e;
							case 13:
								goto IL_0145;
							case 14:
								goto IL_018d;
							case 15:
								goto IL_019c;
							case 16:
								goto IL_01b9;
							case 17:
								goto IL_01d4;
							case 19:
								goto IL_01e9;
							case 20:
								goto IL_020c;
							case 23:
								goto IL_0278;
							case 24:
								goto IL_029b;
							case 18:
							case 21:
							case 22:
							case 25:
							case 26:
							case 27:
								goto IL_02f3;
							case 28:
								goto IL_0305;
							case 30:
								goto IL_0326;
							case 31:
								goto IL_0345;
							case 32:
								goto IL_035c;
							case 33:
								goto IL_03a4;
							case 34:
								goto IL_03b3;
							case 35:
								goto IL_03d0;
							case 36:
								goto IL_03eb;
							case 38:
								goto IL_0429;
							case 39:
								goto IL_044c;
							case 42:
								goto IL_04b8;
							case 43:
								goto IL_04db;
							case 37:
							case 40:
							case 41:
							case 44:
							case 45:
							case 46:
								goto IL_0533;
							case 47:
								goto IL_0545;
							case 49:
								goto IL_0566;
							case 50:
								goto IL_058b;
							case 51:
								goto IL_05a2;
							case 52:
								goto IL_05ea;
							case 53:
								goto IL_05f9;
							case 54:
								goto IL_0616;
							case 55:
								goto IL_0631;
							case 57:
								goto IL_066f;
							case 58:
								goto IL_0692;
							case 61:
								goto IL_06fe;
							case 62:
								goto IL_0721;
							case 56:
							case 59:
							case 60:
							case 63:
							case 64:
							case 65:
								goto IL_0779;
							case 66:
								goto IL_078b;
							case 68:
								goto IL_07ad;
							case 69:
								goto IL_07c4;
							case 70:
								goto IL_080c;
							case 71:
								goto IL_081b;
							case 72:
								goto IL_0838;
							case 73:
								goto IL_0852;
							case 74:
								goto IL_0875;
							case 75:
							case 76:
								goto IL_08ca;
							case 77:
								goto IL_08dc;
							case 29:
							case 48:
							case 67:
							case 78:
							case 79:
								goto IL_08f8;
							case 80:
								goto IL_0902;
							case 81:
								goto IL_0955;
							case 82:
								goto IL_09aa;
							case 83:
								goto IL_0a02;
							case 84:
								goto IL_0a70;
							case 85:
								goto IL_0ab3;
							case 86:
								goto IL_0ae2;
							case 87:
								goto IL_0b25;
							case 88:
								goto IL_0b66;
							case 89:
								goto IL_0b87;
							case 90:
								goto IL_0b95;
							case 91:
								goto IL_0b9b;
							case 92:
								goto IL_0ba1;
							case 93:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 94:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0875:
						num2 = 74;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_08ca;
						IL_08ca:
						num2 = 76;
						num5++;
						goto IL_08d3;
						IL_0852:
						num2 = 73;
						if (((DataGridView)DGV_AC)[num5, DC_Main.i].Value != null)
						{
							goto IL_0875;
						}
						goto IL_08ca;
						IL_07c4:
						num2 = 69;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_AC).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_080c;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						obj2 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
						goto IL_004b;
						IL_004b:
						num2 = 6;
						obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
						goto IL_007d;
						IL_007d:
						num2 = 7;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00a5;
						IL_00a5:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00ae;
						IL_00ae:
						num2 = 9;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00d6;
						IL_00d6:
						num2 = 10;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_0109;
						IL_0109:
						num2 = 11;
						if (Operators.CompareString(BtnExit.Text, "E&xit", false) == 0)
						{
							goto IL_012e;
						}
						goto IL_0326;
						IL_012e:
						num2 = 12;
						num7 = ((DataGridView)DGV_BALANCE).ColumnCount - 1;
						num8 = 0;
						goto IL_0196;
						IL_0196:
						if (num8 <= num7)
						{
							goto IL_0145;
						}
						goto IL_019c;
						IL_019c:
						num2 = 15;
						num9 = ((DataGridView)DGV_BALANCE).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0314;
						IL_0314:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_08f8;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_BALANCE).ColumnCount - 1;
						num11 = 0;
						goto IL_02fc;
						IL_02fc:
						if (num11 <= num10)
						{
							goto IL_01d4;
						}
						goto IL_0305;
						IL_0305:
						num2 = 28;
						DC_Main.i++;
						goto IL_0314;
						IL_01d4:
						num2 = 17;
						if (num11 == 3 || num11 == 7)
						{
							goto IL_01e9;
						}
						goto IL_0278;
						IL_080c:
						num2 = 70;
						num6++;
						goto IL_0815;
						IL_0278:
						num2 = 23;
						if (((DataGridView)DGV_BALANCE)[num11, DC_Main.i].Value != null)
						{
							goto IL_029b;
						}
						goto IL_02f3;
						IL_029b:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_BALANCE)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_02f3;
						IL_01e9:
						num2 = 19;
						if (((DataGridView)DGV_BALANCE)[num11, DC_Main.i].Value != null)
						{
							goto IL_020c;
						}
						goto IL_02f3;
						IL_020c:
						num2 = 20;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV_BALANCE)[num11, DC_Main.i].Value.ToString()), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_02f3;
						IL_02f3:
						num2 = 27;
						num11++;
						goto IL_02fc;
						IL_0145:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_BALANCE).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_018d;
						IL_018d:
						num2 = 14;
						num8++;
						goto IL_0196;
						IL_0326:
						num2 = 30;
						if (Operators.CompareString(DC_Main.MsLdrSumm, "Y", false) == 0)
						{
							goto IL_0345;
						}
						goto IL_0566;
						IL_0345:
						num2 = 31;
						num12 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num13 = 0;
						goto IL_03ad;
						IL_03ad:
						if (num13 <= num12)
						{
							goto IL_035c;
						}
						goto IL_03b3;
						IL_03b3:
						num2 = 34;
						num14 = ((DataGridView)DGV_VCH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0554;
						IL_0554:
						if (DC_Main.i <= num14)
						{
							goto IL_03d0;
						}
						goto IL_08f8;
						IL_03d0:
						num2 = 35;
						num15 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num16 = 0;
						goto IL_053c;
						IL_053c:
						if (num16 <= num15)
						{
							goto IL_03eb;
						}
						goto IL_0545;
						IL_0545:
						num2 = 47;
						DC_Main.i++;
						goto IL_0554;
						IL_03eb:
						num2 = 36;
						switch (num16)
						{
						case 5:
						case 6:
						case 7:
						case 9:
						case 10:
						case 11:
						case 13:
						case 14:
						case 15:
							break;
						default:
							goto IL_04b8;
						}
						goto IL_0429;
						IL_04b8:
						num2 = 42;
						if (((DataGridView)DGV_VCH)[num16, DC_Main.i].Value != null)
						{
							goto IL_04db;
						}
						goto IL_0533;
						IL_04db:
						num2 = 43;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num16 + 1,
							((DataGridView)DGV_VCH)[num16, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0533;
						IL_0429:
						num2 = 38;
						if (((DataGridView)DGV_VCH)[num16, DC_Main.i].Value != null)
						{
							goto IL_044c;
						}
						goto IL_0533;
						IL_044c:
						num2 = 39;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num16 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV_VCH)[num16, DC_Main.i].Value.ToString()), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_0533;
						IL_0533:
						num2 = 46;
						num16++;
						goto IL_053c;
						IL_035c:
						num2 = 32;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num13 + 1,
							((DataGridView)DGV_VCH).Columns[num13].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_03a4;
						IL_03a4:
						num2 = 33;
						num13++;
						goto IL_03ad;
						IL_0566:
						num2 = 49;
						if (Operators.CompareString(BtnExit.Text, "&Back2", false) == 0)
						{
							goto IL_058b;
						}
						goto IL_07ad;
						IL_058b:
						num2 = 50;
						num17 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num18 = 0;
						goto IL_05f3;
						IL_05f3:
						if (num18 <= num17)
						{
							goto IL_05a2;
						}
						goto IL_05f9;
						IL_05f9:
						num2 = 53;
						num19 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_079a;
						IL_079a:
						if (DC_Main.i <= num19)
						{
							goto IL_0616;
						}
						goto IL_08f8;
						IL_0616:
						num2 = 54;
						num20 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num21 = 0;
						goto IL_0782;
						IL_0782:
						if (num21 <= num20)
						{
							goto IL_0631;
						}
						goto IL_078b;
						IL_078b:
						num2 = 66;
						DC_Main.i++;
						goto IL_079a;
						IL_0631:
						num2 = 55;
						switch (num21)
						{
						case 5:
						case 6:
						case 7:
						case 9:
						case 10:
						case 11:
						case 13:
						case 14:
						case 15:
							break;
						default:
							goto IL_06fe;
						}
						goto IL_066f;
						IL_06fe:
						num2 = 61;
						if (((DataGridView)DGV_DETL)[num21, DC_Main.i].Value != null)
						{
							goto IL_0721;
						}
						goto IL_0779;
						IL_0721:
						num2 = 62;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num21 + 1,
							((DataGridView)DGV_DETL)[num21, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0779;
						IL_066f:
						num2 = 57;
						if (((DataGridView)DGV_DETL)[num21, DC_Main.i].Value != null)
						{
							goto IL_0692;
						}
						goto IL_0779;
						IL_0692:
						num2 = 58;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num21 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV_DETL)[num21, DC_Main.i].Value.ToString()), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_0779;
						IL_0779:
						num2 = 65;
						num21++;
						goto IL_0782;
						IL_05a2:
						num2 = 51;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num18 + 1,
							((DataGridView)DGV_DETL).Columns[num18].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_05ea;
						IL_05ea:
						num2 = 52;
						num18++;
						goto IL_05f3;
						IL_07ad:
						num2 = 68;
						num22 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num6 = 0;
						goto IL_0815;
						IL_0815:
						if (num6 <= num22)
						{
							goto IL_07c4;
						}
						goto IL_081b;
						IL_081b:
						num2 = 71;
						num23 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_08eb;
						IL_08eb:
						if (DC_Main.i <= num23)
						{
							goto IL_0838;
						}
						goto IL_08f8;
						IL_08f8:
						num2 = 79;
						colorConverter = new ColorConverter();
						goto IL_0902;
						IL_0902:
						num2 = 80;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:  1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0955;
						IL_0955:
						num2 = 81;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_09aa;
						IL_09aa:
						num2 = 82;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_0a02;
						IL_0a02:
						num2 = 83;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0a70;
						IL_0a70:
						num2 = 84;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0ab3;
						IL_0ab3:
						num2 = 85;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0ae2;
						IL_0ae2:
						num2 = 86;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0b25;
						IL_0b25:
						num2 = 87;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0b66;
						IL_0b66:
						num2 = 88;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0b87;
						IL_0b87:
						num2 = 89;
						Cursor.Current = Cursors.Default;
						goto IL_0b95;
						IL_0b95:
						num2 = 90;
						obj = null;
						goto IL_0b9b;
						IL_0b9b:
						num2 = 91;
						obj3 = null;
						goto IL_0ba1;
						IL_0ba1:
						num2 = 92;
						obj2 = null;
						break;
						IL_0838:
						num2 = 72;
						num24 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_08d3;
						IL_08d3:
						if (num5 <= num24)
						{
							goto IL_0852;
						}
						goto IL_08dc;
						IL_08dc:
						num2 = 77;
						DC_Main.i++;
						goto IL_08eb;
						end_IL_0001_2:
						break;
					}
					num2 = 93;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 3388;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void RP_BAL_ZOOM_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)PnlAcSumm).Controls)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
				object obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control4 in ((Control)Panel1).Controls)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
				object obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control5 in ((Control)PnlGrSumm).Controls)
			{
				object objectValue4 = RuntimeHelpers.GetObjectValue(control5);
				object obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
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
				CheckBox obj6 = chkOpBal;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj6).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				CheckBox obj8 = chkOpBal;
				object? obj9 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj8).ForeColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				CheckBox obj10 = chkLedrFine;
				object? obj11 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				CheckBox obj12 = chkLedrFine;
				object? obj13 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				CheckBox obj14 = chkTodayBal;
				object? obj15 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				CheckBox obj16 = chkTodayBal;
				object? obj17 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj16).ForeColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj18 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewX dGV_BALANCE = DGV_BALANCE;
				object? obj19 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_BALANCE).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewX dGV_AC = DGV_AC;
				object? obj21 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewX dGV_VCH = DGV_VCH;
				object? obj23 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj24 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				DataGridViewX dGV_DETL = DGV_DETL;
				object? obj25 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj26 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				((Control)lblAdd1).ForeColor = Color.Black;
				((Control)lblMobile).ForeColor = Color.Black;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj27 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((ButtonBase)chkOpBal).BackColor = Color.LightSlateGray;
				((Control)chkOpBal).ForeColor = Color.White;
				((ButtonBase)chkLedrFine).BackColor = Color.LightSlateGray;
				((Control)chkLedrFine).ForeColor = Color.White;
				((ButtonBase)chkTodayBal).BackColor = Color.LightSlateGray;
				((Control)chkTodayBal).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV_BALANCE2 = DGV_BALANCE;
				object? obj28 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_BALANCE2).BackgroundColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle;
				object? obj29 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DataGridViewX dGV_AC2 = DGV_AC;
				object? obj30 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj32 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj34 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj35 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj37 = lblBook;
				object? obj38 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj37).ForeColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				((ButtonBase)chkOpBal).BackColor = Color.Cornsilk;
				CheckBox obj39 = chkOpBal;
				object? obj40 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj39).ForeColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				((ButtonBase)chkLedrFine).BackColor = Color.Cornsilk;
				CheckBox obj41 = chkLedrFine;
				object? obj42 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj41).ForeColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				((ButtonBase)chkTodayBal).BackColor = Color.Cornsilk;
				CheckBox obj43 = chkTodayBal;
				object? obj44 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj43).ForeColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj45 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				DataGridViewX dGV_BALANCE3 = DGV_BALANCE;
				object? obj46 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_BALANCE3).BackgroundColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV_BALANCE).AlternatingRowsDefaultCellStyle;
				object? obj47 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				DataGridViewX dGV_AC3 = DGV_AC;
				object? obj48 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle10 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj49 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle10.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj50 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle11 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj51 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle11.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
				DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj52 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj52 != null) ? ((Color)obj52) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle12 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj53 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle12.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
			}
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
				((Control)Label6).Visible = true;
			}
			DC_Main.RsQry = "SELECT VCH_DATE,FINE_GL_RATE,FINE_SL_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				nGoldAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_GL_RATE"])), "0.00");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) != 0.0)
				{
					nSilverAmt.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) / 100.0), "0.00");
				}
			}
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			CurActCtrl = (Control)(object)mFromDt;
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
			else if (val is MaskedTextBox)
			{
				val.Text = DC_Main.MMask;
			}
		}
		MainUser = DC_Main.MCo_User;
		DgvAcEnter = false;
		((TextEdit)tSearch).Text = "";
		((TextEdit)tSerchAll).Text = "";
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)PnlAcSumm).Visible = true;
		DC_Main.RsQry = "SELECT VCH_DATE,FINE_GL_RATE,FINE_SL_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			nGoldAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_GL_RATE"])), "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) != 0.0)
			{
				nSilverAmt.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) / 100.0), "0.00");
			}
		}
		DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)));
		if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
		{
			TRIAL_BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
		{
			PROFIT_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
		{
			BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
		{
			TOT_FINE_SUMM();
		}
		((Control)mFromDt).Focus();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV_AC).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsAcSum);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).ColumnCount = 13;
		((DataGridView)DGV_AC).Columns[0].Visible = false;
		((DataGridView)DGV_AC).Columns[0].DataPropertyName = "AC_CODE";
		((DataGridView)DGV_AC).Columns[0].HeaderText = "Code";
		checked
		{
			((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_NAME";
			((DataGridView)DGV_AC).Columns[1].HeaderText = "Party Name";
			((DataGridView)DGV_AC).Columns[2].Visible = false;
			((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_ADD1";
			((DataGridView)DGV_AC).Columns[2].HeaderText = "Address1";
			((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
			((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
			((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_AC).Columns[5].DataPropertyName = "CrAmt";
			((DataGridView)DGV_AC).Columns[5].HeaderText = "CrAmt";
			((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_AC).Columns[4].DataPropertyName = "DrAmt";
			((DataGridView)DGV_AC).Columns[4].HeaderText = "DrAmt";
			((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_AC).Columns[7].DataPropertyName = "CrGold";
			((DataGridView)DGV_AC).Columns[7].HeaderText = "CrGold";
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DrGold";
			((DataGridView)DGV_AC).Columns[6].HeaderText = "DrGold";
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_AC).Columns[9].DataPropertyName = "CrSilver";
			((DataGridView)DGV_AC).Columns[9].HeaderText = "CrSilver";
			((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_AC).Columns[8].DataPropertyName = "DrSilver";
			((DataGridView)DGV_AC).Columns[8].HeaderText = "DrSilver";
			((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[10].Visible = false;
			((DataGridView)DGV_AC).Columns[10].DataPropertyName = "AC_REFBY";
			((DataGridView)DGV_AC).Columns[2].HeaderText = "RefBy";
			((DataGridView)DGV_AC).Columns[11].Visible = false;
			((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_CITY";
			((DataGridView)DGV_AC).Columns[11].HeaderText = "City";
			((DataGridView)DGV_AC).Columns[12].Visible = false;
			((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_KHATA_NO";
			((DataGridView)DGV_AC).Columns[12].HeaderText = "KhataNo";
			((DataGridView)DGV_AC).DataSource = dataView;
			if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = ((DataGridView)DGV_AC).Rows.Count - 1;
			for (int i = 0; i <= num7; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
				{
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[4].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[8].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[9].Value, (object)""));
				}
			}
			int num8 = ((DataGridView)DGV_AC).Rows.Count - 1;
			((DataGridView)DGV_AC).Rows[num8].Cells[1].Value = "Total :";
			((DataGridView)DGV_AC).Rows[num8].Cells[4].Value = num;
			((DataGridView)DGV_AC).Rows[num8].Cells[5].Value = num2;
			((DataGridView)DGV_AC).Rows[num8].Cells[6].Value = num3;
			((DataGridView)DGV_AC).Rows[num8].Cells[7].Value = num4;
			((DataGridView)DGV_AC).Rows[num8].Cells[8].Value = num5;
			((DataGridView)DGV_AC).Rows[num8].Cells[9].Value = num6;
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 4) <= 5u && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 86:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_008c;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 86;
				continue;
			}
			break;
			IL_008c:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back2", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((DataGridView)DGV_DETL).Columns.Clear();
			((Control)DGV_DETL).Refresh();
			AcSumm(AcGrCode);
			BtnExit.Text = "&Back";
			((Control)PnlAcSumm).Visible = true;
			BtnPrint.Text = "&Print";
			lblRefby.Text = "Ref By :";
			lblAdd1.Text = "";
			lblMobile.Text = "";
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
		{
			((DataGridView)DGV_VCH).DataSource = null;
			((DataGridView)DGV_VCH).ClearSelection();
			((DataGridView)DGV_VCH).Rows.Clear();
			((DataGridView)DGV_VCH).Columns.Clear();
			((Control)DGV_VCH).Refresh();
			AcSumm(AcGrCode);
			BtnExit.Text = "&Back";
			((Control)PnlAcSumm).Visible = true;
			BtnPrint.Text = "&Print";
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			BtnExit.Text = "E&xit";
			((Control)PnlGrSumm).Visible = true;
			BtnPrint.Text = "&Print";
			lblRefby.Text = "Ref By :";
			lblAdd1.Text = "";
			lblMobile.Text = "";
			if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
			{
				TRIAL_BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
			{
				PROFIT_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
			{
				BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
			{
				TOT_FINE_SUMM();
			}
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_BAL_ZOOM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_BAL_ZOOM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_BAL_ZOOM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Invalid comparison between Unknown and I4
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back2", false) == 0)
			{
				((DataGridView)DGV_DETL).DataSource = null;
				((DataGridView)DGV_DETL).ClearSelection();
				((DataGridView)DGV_DETL).Rows.Clear();
				((DataGridView)DGV_DETL).Columns.Clear();
				((Control)DGV_DETL).Refresh();
				AcSumm(AcGrCode);
				BtnExit.Text = "E&xit";
				((Control)PnlAcSumm).Visible = true;
				BtnPrint.Text = "&Print";
				lblRefby.Text = "Ref By :";
				lblAdd1.Text = "";
				lblMobile.Text = "";
			}
			else if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
			{
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((DataGridView)DGV_VCH).Columns.Clear();
				((Control)DGV_VCH).Refresh();
				AcSumm(AcGrCode);
				BtnExit.Text = "E&xit";
				((Control)PnlAcSumm).Visible = true;
				BtnPrint.Text = "&Print";
			}
			else
			{
				((Form)this).Close();
			}
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV_AC).Focus();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
		}
		checked
		{
			if ((Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0) | (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0) | (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0) | ((Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0) & (Operators.CompareString(BtnExit.Text, "E&xit", false) == 0)))
			{
				DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DataGridViewX dGV_BALANCE = DGV_BALANCE;
				DC_Main.RsQry = "INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','0','" + ((DataGridView)dGV_BALANCE).Columns[1].HeaderText + "','" + ((DataGridView)dGV_BALANCE).Columns[2].HeaderText + "','" + ((DataGridView)dGV_BALANCE).Columns[3].HeaderText + "','" + ((DataGridView)dGV_BALANCE).Columns[4].HeaderText + "','" + ((DataGridView)dGV_BALANCE).Columns[5].HeaderText + "','" + ((DataGridView)dGV_BALANCE).Columns[6].HeaderText + "','" + ((DataGridView)dGV_BALANCE).Columns[7].HeaderText + "')";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				int num = ((DataGridView)dGV_BALANCE).RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)dGV_BALANCE)[0, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[3, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[5, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_BALANCE)[7, DC_Main.X].Value), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				dGV_BALANCE = null;
				DC_Main.RsQry = "SELECT * FROM REPORT_DATA";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				CurFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "' " + lblBook.Text + " AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptName = "BalZoom";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BalZoom.RPT";
					Cr[(short)0] = "RptTitel = '" + lblBook.Text + " As On" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
					Cr.Action = -1;
					CurFormula = "";
				}
				return;
			}
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA");
				int num2 = ((DataGridView)DGV_AC).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[0].Value, (object)""), (object)"", false))
					{
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE, LC_CODE,CO_YEAR, VCH_DT, AC_CODE, CR_AMT, DR_AMT, CR_FINE_WT, DR_FINE_WT, CR_SL_FINE, DR_SL_FINE, DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','"), ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[0].Value), (object)"',");
						DataGridViewCell val;
						object Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[5]).Value);
						double num3 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num3), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[4]).Value);
						double num4 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num4), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[7]).Value);
						double num5 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num5), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[6]).Value);
						double num6 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num6), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[9]).Value);
						double num7 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num7), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_AC).Rows[DC_Main.M].Cells[8]).Value);
						double num8 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num8), (object)",'A')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptName = "AcSummLdr";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcSummLdr.RPT";
					Cr[(short)0] = "RptTitel = 'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
					CurFormula = "";
				}
				return;
			}
			double num9 = 0.0;
			DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num9 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
			}
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedger.RPT";
			CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "FromDate";
				DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
				DC_Main.MsCrForName2 = "ToDate";
				DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
				DC_Main.MsCrForName3 = "AcOpAmt";
				DC_Main.MsCrForVal3 = Strings.Format((object)num9, "0.00");
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "AcLedger";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
				Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
				Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num9, "0.00")) ?? "";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				CurFormula = "";
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_BAL_ZOOM_Activated(object sender, EventArgs e)
	{
		if (DC_Main.MsOnlyOpBalnce)
		{
			chkOpBal.Checked = true;
		}
		else
		{
			chkOpBal.Checked = false;
		}
		if (DC_Main.MsTodayBalance)
		{
			chkTodayBal.Checked = true;
		}
		else
		{
			chkTodayBal.Checked = false;
		}
		if (Operators.CompareString(BtnExit.Text, "&Back2", false) == 0)
		{
			DGV_DETL_FILL();
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
		{
			DGV_VCH_FILL();
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			AcSumm(AcGrCode);
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
		{
			((Control)chkOpBal).Visible = true;
			((Control)chkTodayBal).Visible = true;
			lblBook.Text = "Report Trial Balance";
			TRIAL_BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
		{
			((Control)chkOpBal).Visible = true;
			((Control)chkTodayBal).Visible = true;
			lblBook.Text = "Report Profit and Loss";
			PROFIT_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
		{
			((Control)chkOpBal).Visible = true;
			((Control)chkTodayBal).Visible = true;
			lblBook.Text = "Report Balance Sheet";
			BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
		{
			((Control)chkOpBal).Visible = false;
			((Control)chkTodayBal).Visible = false;
			((Control)chkLedrFine).Visible = true;
			lblBook.Text = "Total Fine Report";
			TOT_FINE_SUMM();
		}
		CurActCtrl.Focus();
	}

	private void AcSumm(string AcGr)
	{
		DgvAcEnter = false;
		if (chkTodayBal.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.AC_GR = '" + AcGr + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and A.VCH_DATE = '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME "));
		}
		else if (chkOpBal.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.AC_GR = '" + AcGr + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and A.VCH_DATE < '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.AC_GR = '" + AcGr + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME "));
		}
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void RP_BAL_ZOOM_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '999' "), Interaction.IIf(Operators.CompareString(DC_Main.MLc_code, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + DC_Main.MLc_code + "'"))), (object)"")));
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlAcSumm).Visible = false;
		DgvAcEnter = true;
		int columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		tAcCode.Text = ((DataGridView)DGV_AC)[0, index].Value.ToString();
		tAcName.Text = ((DataGridView)DGV_AC)[1, index].Value.ToString();
		lblRefby.Text = "Ref By : " + ((DataGridView)DGV_AC)[10, index].Value.ToString();
		lblAdd1.Text = ((DataGridView)DGV_AC)[2, index].Value.ToString() + " - " + ((DataGridView)DGV_AC)[11, index].Value.ToString();
		lblMobile.Text = ((DataGridView)DGV_AC)[3, index].Value.ToString();
		DC_Main.RsQry = "SELECT LAST_DATE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0 && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LAST_DATE"])) && DateTime.Compare(Conversions.ToDate(DC_Main.Tbl.Rows[0]["LAST_DATE"]), DC_Main.MOp_dt) > 0)
		{
			mFromDt.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["LAST_DATE"]);
		}
		if (Operators.CompareString(DC_Main.MsLdrSumm, "Y", false) == 0)
		{
			BtnExit.Text = "&Back1";
			BtnPrint.Text = "Ledr";
			((Control)DGV_VCH).Visible = true;
			DGV_VCH_FILL();
		}
		else
		{
			BtnExit.Text = "&Back2";
			((Control)DGV_VCH).Visible = false;
			BtnPrint.Text = "Ledr";
			DGV_DETL_FILL();
		}
	}

	private void DGV_DETL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					ProjectData.ClearProjectError();
					num2 = 2;
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 9:
					case 10:
					case 11:
					case 13:
					case 14:
					case 15:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 8:
					case 12:
						break;
					}
					break;
				case 149:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00cb;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 149;
				continue;
			}
			break;
			IL_00cb:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_DETL_FILL()
	{
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE As AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.LDR_NAME,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver,B.MAIN_BOOK  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,A.LDR_NAME ORDER BY A.VCH_DATE,B.BOOK_NAME"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Party Name");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Gold");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Gold");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Gold");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Silver");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Silver");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Silver");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[17].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[18].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			DC_Main.R = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"])) != 0.0)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL)[1, DC_Main.R].Value = "Op Balance";
					((DataGridView)dGV_DETL)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_DETL)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_DETL)[7, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"]);
					((DataGridView)dGV_DETL)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[0]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable.Rows[0]["CrGold"]));
					((DataGridView)dGV_DETL)[11, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"]);
					((DataGridView)dGV_DETL)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable.Rows[0]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable.Rows[0]["CrSilver"]));
					((DataGridView)dGV_DETL)[15, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL)[16, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL)[16, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[16, DC_Main.R].Value = "";
					}
					DC_Main.R++;
				}
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num7 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DataGridViewX dGV_DETL2 = DGV_DETL;
					((DataGridView)dGV_DETL2).Rows.Add();
					((DataGridView)dGV_DETL2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_DETL2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_DETL2)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["LDR_NAME"], (object)""), (object)"", false))
					{
						((DataGridView)dGV_DETL2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LDR_NAME"]);
					}
					else
					{
						((DataGridView)dGV_DETL2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_NAME"]);
					}
					((DataGridView)dGV_DETL2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_DETL2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_DETL2)[7, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrGold"]);
					((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable2.Rows[DC_Main.M]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable2.Rows[DC_Main.M]["CrGold"]));
					((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[12, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrSilver"]);
					((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable2.Rows[DC_Main.M]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable2.Rows[DC_Main.M]["CrSilver"]));
					((DataGridView)dGV_DETL2)[15, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_DETL2)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_DETL2)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					DC_Main.R++;
					dGV_DETL2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_DETL).Rows.Add();
					((DataGridView)DGV_DETL).Rows.Add();
				}
				int num8 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num8].Cells[4].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num8].Cells[6].Value = num;
				((DataGridView)DGV_DETL).Rows[num8].Cells[5].Value = num2;
				((DataGridView)DGV_DETL).Rows[num8].Cells[7].Value = Math.Abs(num2 - num);
				if (Conversion.Val((object)(num2 - num)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[8].Value = "Cr";
				}
				else if (Conversion.Val((object)(num2 - num)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[8].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[8].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num8].Cells[10].Value = num3;
				((DataGridView)DGV_DETL).Rows[num8].Cells[9].Value = num4;
				((DataGridView)DGV_DETL).Rows[num8].Cells[11].Value = Math.Abs(num4 - num3);
				if (Conversion.Val((object)(num4 - num3)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[12].Value = "Cr";
				}
				else if (Conversion.Val((object)(num4 - num3)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[12].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[12].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num8].Cells[14].Value = num5;
				((DataGridView)DGV_DETL).Rows[num8].Cells[13].Value = num6;
				((DataGridView)DGV_DETL).Rows[num8].Cells[15].Value = Math.Abs(num6 - num5);
				if (Conversion.Val((object)(num6 - num5)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[16].Value = "Cr";
				}
				else if (Conversion.Val((object)(num6 - num5)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[16].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num8].Cells[16].Value = "";
				}
			}
			((Control)tAcCode).Focus();
			((TextBoxBase)tAcCode).SelectAll();
		}
	}

	private void DGV_VCH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					ProjectData.ClearProjectError();
					num2 = 2;
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 9:
					case 10:
					case 11:
					case 13:
					case 14:
					case 15:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 8:
					case 12:
						break;
					}
					break;
				case 149:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00cb;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 149;
				continue;
			}
			break;
			IL_00cb:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_VCH_FILL()
	{
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,  SUM(A.DR_AMT) As DrAmt,SUM(A.CR_AMT) CrAmt,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END) As DrGold,  SUM(Case When A.IT_TYPE = 'G' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrGold,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '-' THEN A.FINE_WT ELSE 0 END) As DrSilver,  SUM(CASE WHEN A.IT_TYPE = 'S' AND A.SIGN = '+' THEN A.FINE_WT ELSE 0 END) As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK ORDER BY A.VCH_DATE,B.BOOK_NAME,A.VCH_NO"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_VCH).AutoGenerateColumns = false;
		((DataGridView)DGV_VCH).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_VCH).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Book");
			((DataGridView)DGV_VCH).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "VchNo");
			((DataGridView)DGV_VCH).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Date");
			((DataGridView)DGV_VCH).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Party Name");
			((DataGridView)DGV_VCH).Columns[4].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_VCH).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_VCH).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "CrDr");
			((DataGridView)DGV_VCH).Columns[8].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "Cr Gold");
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Dr Gold");
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Bal Gold");
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "CrDr");
			((DataGridView)DGV_VCH).Columns[12].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "Cr Silver");
			((DataGridView)DGV_VCH).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Dr Silver");
			((DataGridView)DGV_VCH).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Bal Silver");
			((DataGridView)DGV_VCH).Columns[15].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "CrDr");
			((DataGridView)DGV_VCH).Columns[16].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "CoBook");
			((DataGridView)DGV_VCH).Columns[17].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "AcCode");
			((DataGridView)DGV_VCH).Columns[18].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "MainBook");
			((DataGridView)DGV_VCH).Columns[19].Visible = false;
			DC_Main.R = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_VCH = DGV_VCH;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"])) != 0.0)
				{
					((DataGridView)dGV_VCH).Rows.Add();
					((DataGridView)dGV_VCH)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_VCH)[1, DC_Main.R].Value = "Op Balance";
					((DataGridView)dGV_VCH)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_VCH)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_VCH)[7, DC_Main.R].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_VCH)[8, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_VCH)[8, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH)[8, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"]);
					((DataGridView)dGV_VCH)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[0]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable.Rows[0]["CrGold"]));
					((DataGridView)dGV_VCH)[11, DC_Main.R].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_VCH)[12, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_VCH)[12, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH)[12, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"]);
					((DataGridView)dGV_VCH)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable.Rows[0]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable.Rows[0]["CrSilver"]));
					((DataGridView)dGV_VCH)[15, DC_Main.R].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_VCH)[16, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_VCH)[16, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH)[16, DC_Main.R].Value = "";
					}
					DC_Main.R++;
				}
				dGV_VCH = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num7 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DataGridViewX dGV_VCH2 = DGV_VCH;
					((DataGridView)dGV_VCH2).Rows.Add();
					((DataGridView)dGV_VCH2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_VCH2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_VCH2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_VCH2)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV_VCH2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_NAME"]);
					((DataGridView)dGV_VCH2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_VCH2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_VCH2)[7, DC_Main.R].Value = Math.Abs(num2 - num);
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_VCH2)[8, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_VCH2)[8, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH2)[8, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH2)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrGold"]);
					((DataGridView)dGV_VCH2)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable2.Rows[DC_Main.M]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable2.Rows[DC_Main.M]["CrGold"]));
					((DataGridView)dGV_VCH2)[11, DC_Main.R].Value = Math.Abs(num4 - num3);
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_VCH2)[12, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_VCH2)[12, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH2)[12, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrSilver"]);
					((DataGridView)dGV_VCH2)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable2.Rows[DC_Main.M]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable2.Rows[DC_Main.M]["CrSilver"]));
					((DataGridView)dGV_VCH2)[15, DC_Main.R].Value = Math.Abs(num6 - num5);
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_VCH2)[16, DC_Main.R].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_VCH2)[16, DC_Main.R].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_VCH2)[16, DC_Main.R].Value = "";
					}
					((DataGridView)dGV_VCH2)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_VCH2)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_VCH2)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					DC_Main.R++;
					dGV_VCH2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_VCH).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridView)DGV_VCH).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridView)DGV_VCH).Rows.Count - 1].Cells[4].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_VCH).Rows.Add();
					((DataGridView)DGV_VCH).Rows.Add();
				}
				int num8 = ((DataGridView)DGV_VCH).Rows.Count - 1;
				((DataGridView)DGV_VCH).Rows[num8].Cells[4].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num8].Cells[6].Value = num;
				((DataGridView)DGV_VCH).Rows[num8].Cells[5].Value = num2;
				((DataGridView)DGV_VCH).Rows[num8].Cells[7].Value = Math.Abs(num2 - num);
				if (Conversion.Val((object)(num2 - num)) > 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[8].Value = "Cr";
				}
				else if (Conversion.Val((object)(num2 - num)) < 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[8].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[8].Value = "";
				}
				((DataGridView)DGV_VCH).Rows[num8].Cells[10].Value = num3;
				((DataGridView)DGV_VCH).Rows[num8].Cells[9].Value = num4;
				((DataGridView)DGV_VCH).Rows[num8].Cells[11].Value = Math.Abs(num4 - num3);
				if (Conversion.Val((object)(num4 - num3)) > 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[12].Value = "Cr";
				}
				else if (Conversion.Val((object)(num4 - num3)) < 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[12].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[12].Value = "";
				}
				((DataGridView)DGV_VCH).Rows[num8].Cells[14].Value = num5;
				((DataGridView)DGV_VCH).Rows[num8].Cells[13].Value = num6;
				((DataGridView)DGV_VCH).Rows[num8].Cells[15].Value = Math.Abs(num6 - num5);
				if (Conversion.Val((object)(num6 - num5)) > 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[16].Value = "Cr";
				}
				else if (Conversion.Val((object)(num6 - num5)) < 0.0)
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[16].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_VCH).Rows[num8].Cells[16].Value = "";
				}
			}
			((Control)tAcCode).Focus();
			((TextBoxBase)tAcCode).SelectAll();
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 75.0;
			DC_Main.ColWidth[3] = 300.0;
			DC_Main.ColWidth[4] = 100.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
				if (Operators.CompareString(DC_Main.MsLdrSumm, "Y", false) == 0)
				{
					DGV_VCH_FILL();
				}
				else
				{
					DGV_DETL_FILL();
				}
			}
			((Control)tAcCode).Focus();
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			if (Operators.CompareString(DC_Main.MsLdrSumm, "Y", false) == 0)
			{
				DGV_VCH_FILL();
			}
			else
			{
				DGV_DETL_FILL();
			}
			((Control)tAcCode).Focus();
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DgvAcEnter = true;
			DGV_DoubleClick(DGV_AC, new EventArgs());
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[17].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
		{
			TR_CASH tR_CASH = new TR_CASH();
			((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH).Show();
			((Control)tR_CASH).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
		{
			TR_CASH tR_CASH2 = new TR_CASH();
			((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH2).Show();
			((Control)tR_CASH2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
		{
			TR_CASH tR_CASH3 = new TR_CASH();
			((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH3).Show();
			((Control)tR_CASH3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
		{
			TR_CASH tR_CASH4 = new TR_CASH();
			((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH4).Show();
			((Control)tR_CASH4).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
		{
			TR_CONTRA tR_CONTRA = new TR_CONTRA();
			((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA).Show();
			((Control)tR_CONTRA).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
		{
			TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
			((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA2).Show();
			((Control)tR_CONTRA2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
		{
			TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
			((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_ORD_ADJ).Show();
			((Control)tR_SL_ORD_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
		{
			TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
			((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ENT).Show();
			((Control)tR_MEMB_ENT).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
		{
			TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
			((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ADJ).Show();
			((Control)tR_MEMB_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU2).Show();
			((Control)tR_DHRN_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC2).Show();
			((Control)tR_DHRN_INTREC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
			((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC2).Show();
			((Control)tR_DHRN_REC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CARD ADJUST", false) == 0)
		{
			TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
			((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CARD_REC).Show();
			((Control)tR_CARD_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
	}

	private void DGV_VCH_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[17].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[2].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
		{
			TR_CASH tR_CASH = new TR_CASH();
			((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH).Show();
			((Control)tR_CASH).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
		{
			TR_CASH tR_CASH2 = new TR_CASH();
			((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH2).Show();
			((Control)tR_CASH2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
		{
			TR_CASH tR_CASH3 = new TR_CASH();
			((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH3).Show();
			((Control)tR_CASH3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
		{
			TR_CASH tR_CASH4 = new TR_CASH();
			((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH4).Show();
			((Control)tR_CASH4).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
		{
			TR_CONTRA tR_CONTRA = new TR_CONTRA();
			((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA).Show();
			((Control)tR_CONTRA).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
		{
			TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
			((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA2).Show();
			((Control)tR_CONTRA2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
		{
			TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
			((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_ORD_ADJ).Show();
			((Control)tR_SL_ORD_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
		{
			TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
			((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ENT).Show();
			((Control)tR_MEMB_ENT).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
		{
			TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
			((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ADJ).Show();
			((Control)tR_MEMB_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU2).Show();
			((Control)tR_DHRN_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC2).Show();
			((Control)tR_DHRN_INTREC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
			((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC2).Show();
			((Control)tR_DHRN_REC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
	}

	private void DGV_RowEnter(object sender, DataGridViewCellEventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataGridViewRow val = default(DataGridViewRow);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (DgvAcEnter)
					{
						goto end_IL_0001;
					}
					goto IL_0014;
				case 433:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001_2;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_0014;
						case 3:
							goto IL_0027;
						case 4:
							goto IL_003a;
						case 5:
							goto IL_0051;
						case 6:
							goto IL_005a;
						case 7:
							goto IL_0074;
						case 8:
							goto IL_00bb;
						case 9:
							goto IL_00e9;
						case 11:
							goto end_IL_0001_3;
						default:
							goto end_IL_0001_2;
						case 10:
						case 12:
						case 13:
						case 14:
						case 15:
							goto end_IL_0001;
						}
						goto default;
					}
					IL_0074:
					num2 = 7;
					lblAdd1.Text = val.Cells[2].Value.ToString() + " - " + val.Cells[11].Value.ToString();
					goto IL_00bb;
					IL_00bb:
					num2 = 8;
					if (Operators.CompareString(val.Cells[12].Value.ToString(), "", false) == 0)
					{
						break;
					}
					goto IL_00e9;
					IL_005a:
					num2 = 6;
					val = ((DataGridView)DGV_AC).Rows[e.RowIndex];
					goto IL_0074;
					IL_00e9:
					num2 = 9;
					lblMobile.Text = val.Cells[3].Value.ToString() + "  KhataNo - " + val.Cells[12].Value.ToString();
					goto end_IL_0001;
					IL_0014:
					num2 = 2;
					lblAdd1.Text = "";
					goto IL_0027;
					IL_0027:
					num2 = 3;
					lblMobile.Text = "";
					goto IL_003a;
					IL_003a:
					num2 = 4;
					if (e.RowIndex < 0)
					{
						goto end_IL_0001;
					}
					goto IL_0051;
					IL_0051:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_005a;
					end_IL_0001_3:
					break;
				}
				num2 = 11;
				lblMobile.Text = val.Cells[3].Value.ToString();
				break;
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 433;
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

	private void BtnF1_Click(object sender, EventArgs e)
	{
		DC_Main.LdrAcMastCode = tAcCode.Text;
		MS_ACCT mS_ACCT = new MS_ACCT();
		((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)mS_ACCT).Show();
		((Control)mS_ACCT).Focus();
	}

	private void chkOpBal_CheckedChanged(object sender, EventArgs e)
	{
		BtnExit.Text = "E&xit";
		((Control)PnlAcSumm).Visible = true;
		BtnPrint.Text = "&Print";
		lblRefby.Text = "Ref By :";
		((Control)lblAdd1).Visible = false;
		((Control)lblMobile).Visible = false;
		if (chkOpBal.Checked)
		{
			chkTodayBal.Checked = false;
		}
		if (chkOpBal.Checked)
		{
			DC_Main.MsTodayBalance = false;
		}
		DC_Main.MsOnlyOpBalnce = Conversions.ToBoolean(Interaction.IIf(chkOpBal.Checked, (object)true, (object)false));
		if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
		{
			TRIAL_BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
		{
			PROFIT_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
		{
			BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
		{
			TOT_FINE_SUMM();
		}
	}

	private void mFromDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mFromDt;
			DC_Main.SetDate(ref MsDate);
			mFromDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
			{
				TRIAL_BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
			{
				PROFIT_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
			{
				BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
			{
				TOT_FINE_SUMM();
			}
		}
	}

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void tSearch_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) == 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '" + ((TextEdit)tSearch).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Visible = false;
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[2].Visible = false;
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "DrAmt";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "DrAmt";
					((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "CrAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "CrAmt";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DrGold";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "DrGold";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "CrGold";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "CrGold";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "DrSilver";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "DrSilver";
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "CrSilver";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "CrSilver";
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[10].Visible = false;
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "AC_REFBY";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "RefBy";
					((DataGridView)DGV_AC).Columns[11].Visible = false;
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "City";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
		}
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
			{
				DGV_FILL();
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '%" + ((TextEdit)tSerchAll).Text + "%' OR AC_MOBILE Like '%" + ((TextEdit)tSerchAll).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Visible = false;
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(325.0 * ColCon);
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[2].Visible = false;
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "DrAmt";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "DrAmt";
					((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[4].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "CrAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "CrAmt";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "DrGold";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "DrGold";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "CrGold";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "CrGold";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "DrSilver";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "DrSilver";
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "CrSilver";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "CrSilver";
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[10].Visible = false;
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "AC_REFBY";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "RefBy";
					((DataGridView)DGV_AC).Columns[11].Visible = false;
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "City";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
		}
	}

	private void DGV_BALANCE_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlGrSumm).Visible = false;
		int columnIndex = ((DataGridView)DGV_BALANCE).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_BALANCE).CurrentRow).Index;
		if (columnIndex < 4)
		{
			if (((DataGridView)DGV_BALANCE)[0, index].Value == null)
			{
				((Control)PnlGrSumm).Visible = true;
				return;
			}
			AcGrCode = ((DataGridView)DGV_BALANCE)[0, index].Value.ToString();
			lblAcGrName.Text = ((DataGridView)DGV_BALANCE)[0, index].Value.ToString() + " : " + ((DataGridView)DGV_BALANCE)[1, index].Value.ToString();
			AcSumm(AcGrCode);
		}
		else
		{
			if (((DataGridView)DGV_BALANCE)[4, index].Value == null)
			{
				((Control)PnlGrSumm).Visible = true;
				return;
			}
			AcGrCode = ((DataGridView)DGV_BALANCE)[4, index].Value.ToString();
			lblAcGrName.Text = ((DataGridView)DGV_BALANCE)[4, index].Value.ToString() + " : " + ((DataGridView)DGV_BALANCE)[5, index].Value.ToString();
			AcSumm(AcGrCode);
		}
		BtnExit.Text = "&Back";
	}

	private void nGoldAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		nGoldAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldAmt.Text)), "0.00");
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
			{
				TRIAL_BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
			{
				PROFIT_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
			{
				BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
			{
				TOT_FINE_SUMM();
			}
		}
	}

	private void nSilverAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		nSilverAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSilverAmt.Text)), "0.00");
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
			{
				TRIAL_BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
			{
				PROFIT_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
			{
				BAL_SUMM();
			}
			else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
			{
				TOT_FINE_SUMM();
			}
		}
	}

	private void chkTodayBal_CheckedChanged(object sender, EventArgs e)
	{
		BtnExit.Text = "E&xit";
		((Control)PnlAcSumm).Visible = true;
		BtnPrint.Text = "&Print";
		lblRefby.Text = "Ref By :";
		((Control)lblAdd1).Visible = false;
		((Control)lblMobile).Visible = false;
		DC_Main.MsTodayBalance = Conversions.ToBoolean(Interaction.IIf(chkTodayBal.Checked, (object)true, (object)false));
		if (chkTodayBal.Checked)
		{
			chkOpBal.Checked = false;
		}
		if (chkTodayBal.Checked)
		{
			DC_Main.MsOnlyOpBalnce = false;
		}
		if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
		{
			TRIAL_BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
		{
			PROFIT_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
		{
			BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
		{
			TOT_FINE_SUMM();
		}
	}

	private void chkLedrFine_Click(object sender, EventArgs e)
	{
		TOT_FINE_SUMM();
	}

	private void tLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE";
				DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 70.0;
				DC_Main.ColWidth[1] = 280.0;
				DC_Main.ColWidth[2] = 300.0;
				DC_Main.ColWidth[3] = 250.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tLcCode.Text = DC_Main.ColValue[0];
					tLcName.Text = DC_Main.ColValue[1];
				}
				return;
			}
			tLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsRptBalZoomType, "T", false) == 0)
		{
			TRIAL_BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "P", false) == 0)
		{
			PROFIT_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "B", false) == 0)
		{
			BAL_SUMM();
		}
		else if (Operators.CompareString(DC_Main.MsRptBalZoomType, "F", false) == 0)
		{
			TOT_FINE_SUMM();
		}
	}

	private void chkLedrFine_CheckedChanged(object sender, EventArgs e)
	{
	}
}
