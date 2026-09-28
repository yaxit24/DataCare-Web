using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
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
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_BILL_PROFIT : Form
{
	private IContainer components;

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
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnBillWise")]
	private QButton _BtnBillWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTagWise")]
	private QButton _BtnTagWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DATE")]
	private DataGridViewX _DGV_DATE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DataGridViewX _DGV_VCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ITEM")]
	private DataGridViewX _DGV_ITEM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBookSelect")]
	private CheckBox _chkBookSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItCancel")]
	private QButton _btnItCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCounterCode")]
	private TextBox _tCounterCode;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private bool DgvLoad;

	private string RptDisplay;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string StkType;

	private string CurRpt;

	private double[] TotPcs;

	private string DgvRptType;

	private string ScelectBook;

	private const int c1SrNo = 0;

	private const int c1BookType = 1;

	private const int c1VchNo = 2;

	private const int c1VchDate = 3;

	private const int c1AcName = 4;

	private const int c1TagNo = 5;

	private const int c1ItName = 6;

	private const int c1Pcs = 7;

	private const int c1GrWt = 8;

	private const int c1NetWt = 9;

	private const int c1KrNetWt = 10;

	private const int c1SlFine = 11;

	private const int c1KrFine = 12;

	private const int c1PfFine = 13;

	private const int c1ItmAmt = 14;

	private const int c1LbrAmt = 15;

	private const int c1OthAmt = 16;

	private const int c1NetAmt = 17;

	private const int c1PrAmt = 18;

	private const int c1PrLbrAmt = 19;

	private const int c1PrOthAmt = 20;

	private const int c1Mrp = 21;

	private const int c1TotalCost = 22;

	private const int c1ProfitAmt = 23;

	private const int c1AcCode = 24;

	private const int c1EmpCode = 25;

	private const int c1BookCode = 26;

	private const int c1MainBook = 27;

	private const int c1GlFineRate = 28;

	private const int c1SlFineRate = 29;

	private const int c1ItType = 30;

	private const int c1BookName = 31;

	private const int cbSrNo = 0;

	private const int cbVchType = 1;

	private const int cbVchNo = 2;

	private const int cbVchDt = 3;

	private const int cbAcName = 4;

	private const int cbPcs = 5;

	private const int cbGrWt = 6;

	private const int cbNetWt = 7;

	private const int cbRItmAmt = 8;

	private const int cbRLbrAmt = 9;

	private const int cbROthAmt = 10;

	private const int cbRMrp = 11;

	private const int cbRTotAmt = 12;

	private const int cbWFine = 13;

	private const int cbWFineAmt = 14;

	private const int cbWLbrAmt = 15;

	private const int cbWOthAmt = 16;

	private const int cbWTotAmt = 17;

	private const int cbPrFine = 18;

	private const int cbPrLbr = 19;

	private const int cbPrOth = 20;

	private const int cbPrGlRate = 21;

	private const int cbPrSlRate = 22;

	private const int cbPrAmt = 23;

	private const int cbPrTot = 24;

	private const int cbOldItPf = 25;

	private const int cbProfit = 26;

	private const int cbWFinePf = 27;

	private const int cbWOthPf = 28;

	private const int cbItType = 29;

	private const int cbItName = 30;

	private const int cbCoBook = 31;

	private const int cbMainBook = 32;

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

	internal virtual DataGridViewX DGV
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private virtual ComboBox _cboItemTyp;

	internal virtual ComboBox cboItemTyp
	{
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboItemTyp = value;
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

	internal virtual QButton BtnBillWise
	{
		[CompilerGenerated]
		get
		{
			return _BtnBillWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBillWise_Click;
			QButton val = _BtnBillWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnBillWise = value;
			val = _BtnBillWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual QButton BtnTagWise
	{
		[CompilerGenerated]
		get
		{
			return _BtnTagWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagWise_Click;
			QButton val = _BtnTagWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTagWise = value;
			val = _BtnTagWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGrCode_KeyDown);
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPrCode
	{
		[CompilerGenerated]
		get
		{
			return _tPrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrCode_KeyDown);
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPrCode = value;
			val2 = _tPrCode;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagNo")]
	private virtual TextBox _tTagNo;

	internal virtual TextBox tTagNo
	{
		get
		{
			return _tTagNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTagNo = value;
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
	[AccessedThroughProperty("Panel2")]
	private virtual Panel _Panel2;

	internal virtual Panel Panel2
	{
		get
		{
			return _Panel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel2 = value;
		}
	}

	internal virtual DataGridViewX DGV_DATE
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DATE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DATE_CellFormatting);
			EventHandler eventHandler = DGV_DATE_DoubleClick;
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_DATE_CellContentClick);
			DataGridViewX val3 = _DGV_DATE;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((DataGridView)val3).CellContentClick -= val2;
			}
			_DGV_DATE = value;
			val3 = _DGV_DATE;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((Control)val3).DoubleClick += eventHandler;
				((DataGridView)val3).CellContentClick += val2;
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

	internal virtual DataGridViewX DGV_ITEM
	{
		[CompilerGenerated]
		get
		{
			return _DGV_ITEM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_ITEM_CellFormatting);
			EventHandler eventHandler = DGV_ITEM_DoubleClick;
			DataGridViewX val2 = _DGV_ITEM;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_ITEM = value;
			val2 = _DGV_ITEM;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRptType")]
	private virtual ComboBox _cboRptType;

	internal virtual ComboBox cboRptType
	{
		get
		{
			return _cboRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboRptType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label7")]
	private virtual Label _Label7;

	internal virtual Label Label7
	{
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label7 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label8")]
	private virtual Label _Label8;

	internal virtual Label Label8
	{
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label8 = value;
		}
	}

	internal virtual TextBox tBookCode
	{
		[CompilerGenerated]
		get
		{
			return _tBookCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBookCode_KeyDown);
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBookCode = value;
			val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual CheckBox chkBookSelect
	{
		[CompilerGenerated]
		get
		{
			return _chkBookSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkBookSelect_Click;
			CheckBox val = _chkBookSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkBookSelect = value;
			val = _chkBookSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlIt")]
	private virtual Panel _PnlIt;

	internal virtual Panel PnlIt
	{
		get
		{
			return _PnlIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlIt = value;
		}
	}

	internal virtual QButton btnItCancel
	{
		[CompilerGenerated]
		get
		{
			return _btnItCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItCancel_Click;
			QButton val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItCancel = value;
			val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOk_Click;
			QButton val = _btnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOk = value;
			val = _btnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ITM")]
	private virtual DataGridViewX _DGV_ITM;

	internal virtual DataGridViewX DGV_ITM
	{
		get
		{
			return _DGV_ITM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_ITM = value;
		}
	}

	internal virtual TextBox tCounterCode
	{
		[CompilerGenerated]
		get
		{
			return _tCounterCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCounterCode_KeyDown);
			TextBox val2 = _tCounterCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCounterCode = value;
			val2 = _tCounterCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	public int newindex { get; set; }

	public RP_BILL_PROFIT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_BILL_PROFIT_Load;
		((Form)this).Deactivate += RP_BILL_PROFIT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_BILL_PROFIT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_BILL_PROFIT_KeyDown);
		((Form)this).Activated += RP_BILL_PROFIT_Activated;
		((Form)this).Closed += RP_LEDR_Closed;
		DgvLoad = false;
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
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Expected O, but got Unknown
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Expected O, but got Unknown
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_08d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Expected O, but got Unknown
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Expected O, but got Unknown
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a29: Expected O, but got Unknown
		//IL_0a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected O, but got Unknown
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7a: Expected O, but got Unknown
		//IL_0c0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Expected O, but got Unknown
		//IL_0c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca1: Expected O, but got Unknown
		//IL_0d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8d: Expected O, but got Unknown
		//IL_0df6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_0eae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb8: Expected O, but got Unknown
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2b: Expected O, but got Unknown
		//IL_1249: Unknown result type (might be due to invalid IL or missing references)
		//IL_126d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1291: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12de: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e8: Expected O, but got Unknown
		//IL_130b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1381: Unknown result type (might be due to invalid IL or missing references)
		//IL_138b: Expected O, but got Unknown
		//IL_141f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1429: Expected O, but got Unknown
		//IL_14ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b6: Expected O, but got Unknown
		//IL_174e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1772: Unknown result type (might be due to invalid IL or missing references)
		//IL_1796: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ed: Expected O, but got Unknown
		//IL_1810: Unknown result type (might be due to invalid IL or missing references)
		//IL_1884: Unknown result type (might be due to invalid IL or missing references)
		//IL_188e: Expected O, but got Unknown
		//IL_190c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1916: Expected O, but got Unknown
		//IL_1983: Unknown result type (might be due to invalid IL or missing references)
		//IL_198d: Expected O, but got Unknown
		//IL_1a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a34: Expected O, but got Unknown
		//IL_1ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1adb: Expected O, but got Unknown
		//IL_1b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b53: Expected O, but got Unknown
		//IL_1ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cee: Expected O, but got Unknown
		//IL_1d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d94: Expected O, but got Unknown
		//IL_1e1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e24: Expected O, but got Unknown
		//IL_1f0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f15: Expected O, but got Unknown
		//IL_1f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f88: Expected O, but got Unknown
		//IL_2049: Unknown result type (might be due to invalid IL or missing references)
		//IL_2053: Expected O, but got Unknown
		//IL_20ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f9: Expected O, but got Unknown
		//IL_217f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2189: Expected O, but got Unknown
		//IL_2270: Unknown result type (might be due to invalid IL or missing references)
		//IL_227a: Expected O, but got Unknown
		//IL_22e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ed: Expected O, but got Unknown
		//IL_23ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b8: Expected O, but got Unknown
		//IL_2454: Unknown result type (might be due to invalid IL or missing references)
		//IL_245e: Expected O, but got Unknown
		//IL_24e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ee: Expected O, but got Unknown
		//IL_25d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25df: Expected O, but got Unknown
		//IL_2648: Unknown result type (might be due to invalid IL or missing references)
		//IL_2652: Expected O, but got Unknown
		//IL_29a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_29cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a48: Expected O, but got Unknown
		//IL_2a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d71: Expected O, but got Unknown
		//IL_2d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e34: Expected O, but got Unknown
		//IL_2ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eda: Expected O, but got Unknown
		//IL_2f60: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f6a: Expected O, but got Unknown
		//IL_3044: Unknown result type (might be due to invalid IL or missing references)
		//IL_304e: Expected O, but got Unknown
		//IL_30b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c1: Expected O, but got Unknown
		//IL_3174: Unknown result type (might be due to invalid IL or missing references)
		//IL_317e: Expected O, but got Unknown
		//IL_31fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3206: Expected O, but got Unknown
		//IL_328b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3295: Expected O, but got Unknown
		//IL_334f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3359: Expected O, but got Unknown
		//IL_33c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_33d0: Expected O, but got Unknown
		//IL_346d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3477: Expected O, but got Unknown
		//IL_3514: Unknown result type (might be due to invalid IL or missing references)
		//IL_351e: Expected O, but got Unknown
		//IL_35a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_35aa: Expected O, but got Unknown
		//IL_3657: Unknown result type (might be due to invalid IL or missing references)
		//IL_3661: Expected O, but got Unknown
		//IL_36ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d8: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_BILL_PROFIT));
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
		DataGridViewCellStyle val21 = new DataGridViewCellStyle();
		DataGridViewCellStyle val22 = new DataGridViewCellStyle();
		DataGridViewCellStyle val23 = new DataGridViewCellStyle();
		DataGridViewCellStyle val24 = new DataGridViewCellStyle();
		DataGridViewCellStyle val25 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV = new DataGridViewX();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		BtnBillWise = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		BtnTagWise = new QButton();
		tGrCode = new TextBox();
		tPrCode = new TextBox();
		Label4 = new Label();
		Label1 = new Label();
		tTagNo = new TextBox();
		Label5 = new Label();
		Panel2 = new Panel();
		DGV_DATE = new DataGridViewX();
		DGV_VCH = new DataGridViewX();
		DGV_ITEM = new DataGridViewX();
		PnlIt = new Panel();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DataGridViewX();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label6 = new Label();
		cboRptType = new ComboBox();
		Label7 = new Label();
		Label8 = new Label();
		tBookCode = new TextBox();
		chkBookSelect = new CheckBox();
		tCounterCode = new TextBox();
		Label10 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)Panel1).SuspendLayout();
		((Control)Panel2).SuspendLayout();
		((ISupportInitialize)DGV_DATE).BeginInit();
		((ISupportInitialize)DGV_VCH).BeginInit();
		((ISupportInitialize)DGV_ITEM).BeginInit();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
		((Control)this).SuspendLayout();
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
		((Control)PnlBotam).TabIndex = 12;
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
		((Control)BtnExit).TabIndex = 4;
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
		((Control)BtnDelete).TabIndex = 3;
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
		((Control)BtnCancel).TabIndex = 2;
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
		((Control)BtnSave).TabIndex = 1;
		BtnSave.Text = "Excel";
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
		((Control)BtnPrint).TabIndex = 0;
		BtnPrint.Text = "Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(793, 3);
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
		lblBook.Text = "Bill Wise Profit";
		lblBook.TextAlign = (ContentAlignment)32;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
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
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(10, 13);
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
		((Control)DGV).Size = new Size(1160, 423);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 2;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(320, 45);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(102, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(236, 46);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(79, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.PeachPuff;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Location = new Point(0, 113);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 451);
		((Control)Panel1).TabIndex = 110;
		((QControl)BtnBillWise).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnBillWise).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnBillWise).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnBillWise).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnBillWise).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnBillWise).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnBillWise).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnBillWise).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnBillWise).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnBillWise).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnBillWise).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnBillWise).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnBillWise).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnBillWise).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnBillWise.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBillWise.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBillWise.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBillWise.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBillWise.Image = null;
		((QControl)BtnBillWise).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnBillWise).Location = new Point(852, 79);
		((Control)BtnBillWise).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnBillWise).Name = "BtnBillWise";
		((Control)BtnBillWise).Size = new Size(143, 37);
		((Control)BtnBillWise).TabIndex = 8;
		BtnBillWise.Text = "&Bill Wise";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(74, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(160, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(18, 45);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(48, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "Date";
		Label2.TextAlign = (ContentAlignment)64;
		((QControl)BtnTagWise).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTagWise).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTagWise).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTagWise).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTagWise).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTagWise).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTagWise).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTagWise).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTagWise).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTagWise).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTagWise).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTagWise).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTagWise).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTagWise).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTagWise.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagWise.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagWise.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagWise.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagWise.Image = null;
		((QControl)BtnTagWise).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTagWise).Location = new Point(1011, 79);
		((Control)BtnTagWise).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTagWise).Name = "BtnTagWise";
		((Control)BtnTagWise).Size = new Size(143, 37);
		((Control)BtnTagWise).TabIndex = 9;
		BtnTagWise.Text = "Tag Wise";
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(486, 79);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(48, 22);
		((Control)tGrCode).TabIndex = 1177;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(486, 45);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(48, 22);
		((Control)tPrCode).TabIndex = 1175;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(425, 80);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(57, 20);
		((Control)Label4).TabIndex = 1174;
		Label4.Text = "Group";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(541, 47);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(55, 20);
		((Control)Label1).TabIndex = 1173;
		Label1.Text = "TagNo";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(602, 44);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(93, 22);
		((Control)tTagNo).TabIndex = 1171;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(417, 46);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(65, 20);
		((Control)Label5).TabIndex = 1172;
		Label5.Text = "PrCode";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Panel2).BackColor = Color.Bisque;
		Panel2.BorderStyle = (BorderStyle)1;
		((Control)Panel2).Controls.Add((Control)(object)DGV_DATE);
		((Control)Panel2).Controls.Add((Control)(object)DGV_VCH);
		((Control)Panel2).Controls.Add((Control)(object)DGV_ITEM);
		((Control)Panel2).Location = new Point(0, 114);
		((Control)Panel2).Name = "Panel2";
		((Control)Panel2).Size = new Size(1309, 451);
		((Control)Panel2).TabIndex = 1181;
		((Control)Panel2).Visible = false;
		((DataGridView)DGV_DATE).AllowUserToAddRows = false;
		((DataGridView)DGV_DATE).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DATE).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_DATE).BackgroundColor = Color.Snow;
		((DataGridView)DGV_DATE).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DATE).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_DATE).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DATE).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DATE).DefaultCellStyle = val8;
		((DataGridView)DGV_DATE).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DATE).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DATE).Location = new Point(10, 13);
		((Control)DGV_DATE).Name = "DGV_DATE";
		DGV_DATE.PaintEnhancedSelection = false;
		((DataGridView)DGV_DATE).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DATE).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_DATE).RowHeadersVisible = false;
		((DataGridView)DGV_DATE).RowHeadersWidth = 20;
		val10.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DATE).RowsDefaultCellStyle = val10;
		DGV_DATE.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DATE.SelectAllSignVisible = false;
		((DataGridView)DGV_DATE).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DATE).Size = new Size(1160, 423);
		((DataGridView)DGV_DATE).StandardTab = true;
		((Control)DGV_DATE).TabIndex = 2;
		((DataGridView)DGV_VCH).AllowUserToAddRows = false;
		((DataGridView)DGV_VCH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_VCH).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_VCH).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_VCH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_VCH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_VCH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_VCH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).DefaultCellStyle = val13;
		((DataGridView)DGV_VCH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_VCH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_VCH).Location = new Point(12, 13);
		((Control)DGV_VCH).Name = "DGV_VCH";
		DGV_VCH.PaintEnhancedSelection = false;
		((DataGridView)DGV_VCH).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_VCH).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_VCH).RowHeadersVisible = false;
		((DataGridView)DGV_VCH).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_VCH).RowsDefaultCellStyle = val15;
		DGV_VCH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_VCH.SelectAllSignVisible = false;
		((DataGridView)DGV_VCH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_VCH).Size = new Size(1158, 423);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 3;
		((DataGridView)DGV_ITEM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITEM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITEM).AllowUserToResizeRows = false;
		val16.BackColor = Color.PapayaWhip;
		val16.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val16.ForeColor = Color.FromArgb(64, 64, 64);
		val16.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val16.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITEM).AlternatingRowsDefaultCellStyle = val16;
		((DataGridView)DGV_ITEM).BackgroundColor = Color.White;
		((DataGridView)DGV_ITEM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITEM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val17.Alignment = (DataGridViewContentAlignment)16;
		val17.BackColor = SystemColors.Control;
		val17.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val17.ForeColor = Color.FromArgb(64, 64, 64);
		val17.SelectionBackColor = SystemColors.ScrollBar;
		val17.SelectionForeColor = Color.White;
		val17.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITEM).ColumnHeadersDefaultCellStyle = val17;
		((DataGridView)DGV_ITEM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITEM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val18.Alignment = (DataGridViewContentAlignment)16;
		val18.BackColor = SystemColors.Window;
		val18.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val18.ForeColor = Color.FromArgb(64, 64, 64);
		val18.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val18.SelectionForeColor = Color.Maroon;
		val18.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITEM).DefaultCellStyle = val18;
		((DataGridView)DGV_ITEM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITEM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITEM).Location = new Point(12, 13);
		((Control)DGV_ITEM).Name = "DGV_ITEM";
		DGV_ITEM.PaintEnhancedSelection = false;
		((DataGridView)DGV_ITEM).ReadOnly = true;
		val19.Alignment = (DataGridViewContentAlignment)16;
		val19.BackColor = Color.MintCream;
		val19.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val19.ForeColor = SystemColors.WindowText;
		val19.SelectionBackColor = SystemColors.Highlight;
		val19.SelectionForeColor = SystemColors.HighlightText;
		val19.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITEM).RowHeadersDefaultCellStyle = val19;
		((DataGridView)DGV_ITEM).RowHeadersVisible = false;
		((DataGridView)DGV_ITEM).RowHeadersWidth = 20;
		val20.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val20.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITEM).RowsDefaultCellStyle = val20;
		DGV_ITEM.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_ITEM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITEM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITEM).Size = new Size(1158, 423);
		((DataGridView)DGV_ITEM).StandardTab = true;
		((Control)DGV_ITEM).TabIndex = 4;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(715, 128);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1210;
		((Control)PnlIt).Visible = false;
		((QControl)btnItCancel).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItCancel).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItCancel.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Image = null;
		((QControl)btnItCancel).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItCancel).Location = new Point(255, 248);
		((Control)btnItCancel).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItCancel).Name = "btnItCancel";
		((Control)btnItCancel).Size = new Size(100, 38);
		((Control)btnItCancel).TabIndex = 1158;
		btnItCancel.Text = "Cancel";
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(106, 248);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(100, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV_ITM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITM).AllowUserToResizeRows = false;
		val21.BackColor = Color.PapayaWhip;
		val21.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val21.ForeColor = Color.FromArgb(64, 64, 64);
		val21.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val21.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val21;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val22.Alignment = (DataGridViewContentAlignment)16;
		val22.BackColor = SystemColors.Control;
		val22.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val22.ForeColor = Color.FromArgb(64, 64, 64);
		val22.SelectionBackColor = SystemColors.ScrollBar;
		val22.SelectionForeColor = Color.White;
		val22.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val22;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val23.Alignment = (DataGridViewContentAlignment)16;
		val23.BackColor = SystemColors.Window;
		val23.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val23.ForeColor = Color.FromArgb(64, 64, 64);
		val23.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val23.SelectionForeColor = Color.Maroon;
		val23.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val23;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val24.Alignment = (DataGridViewContentAlignment)16;
		val24.BackColor = Color.MintCream;
		val24.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val24.ForeColor = SystemColors.WindowText;
		val24.SelectionBackColor = SystemColors.Highlight;
		val24.SelectionForeColor = SystemColors.HighlightText;
		val24.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val24;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val25.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val25.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val25;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(74, 79);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 1182;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(160, 79);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(262, 23);
		((Control)tAcName).TabIndex = 1183;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(-3, 76);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(69, 20);
		((Control)Label6).TabIndex = 1184;
		Label6.Text = "Ac Code";
		Label6.TextAlign = (ContentAlignment)64;
		cboRptType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboRptType).Font = new Font("Tahoma", 9f);
		((ListControl)cboRptType).FormattingEnabled = true;
		((Control)cboRptType).Location = new Point(1045, 43);
		((Control)cboRptType).Name = "cboRptType";
		((Control)cboRptType).Size = new Size(109, 22);
		((Control)cboRptType).TabIndex = 1185;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(938, 43);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(94, 20);
		((Control)Label7).TabIndex = 1186;
		Label7.Text = "Report Type";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(541, 80);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(55, 20);
		((Control)Label8).TabIndex = 1188;
		Label8.Text = "Book";
		Label8.TextAlign = (ContentAlignment)64;
		((Control)tBookCode).Font = new Font("Tahoma", 9f);
		((Control)tBookCode).Location = new Point(602, 78);
		((TextBoxBase)tBookCode).MaxLength = 15;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(93, 22);
		((Control)tBookCode).TabIndex = 1187;
		((ButtonBase)chkBookSelect).BackColor = Color.Transparent;
		((Control)chkBookSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBookSelect).ForeColor = Color.Black;
		((Control)chkBookSelect).Location = new Point(719, 78);
		((Control)chkBookSelect).Name = "chkBookSelect";
		((Control)chkBookSelect).RightToLeft = (RightToLeft)0;
		((Control)chkBookSelect).Size = new Size(116, 19);
		((Control)chkBookSelect).TabIndex = 1209;
		((ButtonBase)chkBookSelect).Text = "Select Book";
		((ButtonBase)chkBookSelect).UseVisualStyleBackColor = false;
		((TextBoxBase)tCounterCode).BackColor = Color.White;
		((Control)tCounterCode).Font = new Font("Tahoma", 9f);
		((Control)tCounterCode).Location = new Point(773, 44);
		((TextBoxBase)tCounterCode).MaxLength = 3;
		((Control)tCounterCode).Name = "tCounterCode";
		((Control)tCounterCode).Size = new Size(64, 22);
		((Control)tCounterCode).TabIndex = 1212;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(688, 45);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(77, 20);
		((Control)Label10).TabIndex = 1211;
		Label10.Text = "Counter";
		Label10.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tTagNo);
		((Control)this).Controls.Add((Control)(object)tCounterCode);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)PnlIt);
		((Control)this).Controls.Add((Control)(object)chkBookSelect);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)cboRptType);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Panel2);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)BtnBillWise);
		((Control)this).Controls.Add((Control)(object)BtnTagWise);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_BILL_PROFIT";
		((Form)this).Text = "Bill Wise Profit";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel2).ResumeLayout(false);
		((ISupportInitialize)DGV_DATE).EndInit();
		((ISupportInitialize)DGV_VCH).EndInit();
		((ISupportInitialize)DGV_ITEM).EndInit();
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
	}

	private void BtnTagWise_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DATE).DataSource = null;
		((DataGridView)DGV_DATE).ClearSelection();
		((DataGridView)DGV_DATE).Rows.Clear();
		((DataGridView)DGV_DATE).Columns.Clear();
		((Control)DGV_DATE).Refresh();
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		((DataGridView)DGV_ITEM).DataSource = null;
		((DataGridView)DGV_ITEM).ClearSelection();
		((DataGridView)DGV_ITEM).Rows.Clear();
		((DataGridView)DGV_ITEM).Columns.Clear();
		((Control)DGV_ITEM).Refresh();
		BtnExit.Text = "&Exit";
		((Control)Panel2).Visible = false;
		((Control)DGV).Visible = true;
		RptDisplay = "TagWise";
		BillProfitClear();
	}

	private void BillProfitClear()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_1035: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(35.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "BkType");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "VchNo");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "VchDate");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Ac Name");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(175.0 * ColCon);
			if (Operators.CompareString(RptDisplay, "TagWise", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "TagNo");
				((DataGridView)DGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns.Add("", "It Name");
				((DataGridView)DGV).Columns[6].Width = (int)Math.Round(160.0 * ColCon);
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "TagNo");
				((DataGridView)DGV).Columns[5].Visible = false;
				((DataGridView)DGV).Columns.Add("", "It Name");
				((DataGridView)DGV).Columns[6].Visible = false;
			}
			((DataGridView)DGV).Columns.Add("", "Pcs");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "GrWt");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "NetWt");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "KrNwt");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SlFine");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "KrFine");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Pf Fine");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N3";
			if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "ItmAmt");
				((DataGridView)DGV).Columns[14].Visible = false;
				((DataGridView)DGV).Columns.Add("", "LbrAmt");
				((DataGridView)DGV).Columns[15].Visible = false;
				((DataGridView)DGV).Columns.Add("", "OthAmt");
				((DataGridView)DGV).Columns[16].Visible = false;
				((DataGridView)DGV).Columns.Add("", "NetAmt");
				((DataGridView)DGV).Columns[17].Visible = false;
				((DataGridView)DGV).Columns.Add("", "PrAmt");
				((DataGridView)DGV).Columns[18].Visible = false;
				((DataGridView)DGV).Columns.Add("", "PrLbrAmt");
				((DataGridView)DGV).Columns[19].Visible = false;
				((DataGridView)DGV).Columns.Add("", "PrOthAmt");
				((DataGridView)DGV).Columns[20].Visible = false;
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "ItmAmt");
				((DataGridView)DGV).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "LbrAmt");
				((DataGridView)DGV).Columns[15].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "OthAmt");
				((DataGridView)DGV).Columns[16].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "NetAmt");
				((DataGridView)DGV).Columns[17].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "PrAmt");
				((DataGridView)DGV).Columns[18].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "PLbrAmt");
				((DataGridView)DGV).Columns[19].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "POthAmt");
				((DataGridView)DGV).Columns[20].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[20].DefaultCellStyle.Format = "N2";
			}
			((DataGridView)DGV).Columns.Add("", "Mrp");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotCost");
			((DataGridView)DGV).Columns[22].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "ProftiAmt");
			((DataGridView)DGV).Columns[23].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "AcCode");
			((DataGridView)DGV).Columns[24].Visible = false;
			((DataGridView)DGV).Columns.Add("", "EmpCode");
			((DataGridView)DGV).Columns[25].Visible = false;
			((DataGridView)DGV).Columns.Add("", "BookCode");
			((DataGridView)DGV).Columns[26].Visible = false;
			((DataGridView)DGV).Columns.Add("", "MainBook");
			((DataGridView)DGV).Columns[27].Visible = false;
			((DataGridView)DGV).Columns.Add("", "GlFineRate");
			((DataGridView)DGV).Columns[28].Visible = false;
			((DataGridView)DGV).Columns.Add("", "SlFineRate");
			((DataGridView)DGV).Columns[29].Visible = false;
			((DataGridView)DGV).Columns.Add("", "ItType");
			((DataGridView)DGV).Columns[30].Visible = false;
			((DataGridView)DGV).Columns.Add("", "BookName");
			((DataGridView)DGV).Columns[31].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			TagProfitData();
		}
	}

	private void TagProfitData()
	{
		DC_Main.RsQry = "SELECT FINE_GL_RATE,FINE_SL_RATE,VCH_DATE,GR_RATE,GR_TYPE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND GR_CODE IN ('FGL','FSL') ORDER BY VCH_DATE DESC";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(DC_Main.Tbl);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_TYPE,A.VCH_NO,FORMAT(A.VCH_DATE,'dd/MM/yyyy') As CurDate,D.AC_NAME,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_FINE,B.KR_NET_WT,B.KR_FINE,  A.ITM_AMT,A.LBR_AMT,A.OTH_AMT,B.KR_LBR_AMT,B.KR_OTH_AMT,A.ITM_MRP,B.KR_COST,C.IT_TYPE,A.CO_BOOK,A.BOOK_NAME,A.VCH_SRNO,A.IT_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND  A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE)  LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.TAG_NO <> 'N'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tCounterCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.TBL_CODE = '" + tCounterCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE = '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK in (" + ScelectBook + ")";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO = '" + tTagNo.Text + "'";
		}
		DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.VCH_TYPE,A.VCH_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		double num14 = 0.0;
		double num15 = 0.0;
		double num16 = 0.0;
		double num17 = 0.0;
		DC_Main.R = 0;
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num18 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num18)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_TYPE"]);
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["CurDate"]);
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_NAME"]);
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"]);
					((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_PCS"]);
					((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_GWT"]);
					((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_NWT"]);
					((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_NET_WT"]);
					((DataGridView)dGV)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_FINE"]);
					((DataGridView)dGV)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_FINE"]);
					((DataGridView)dGV)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_AMT"]);
					((DataGridView)dGV)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["LBR_AMT"]);
					((DataGridView)dGV)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["OTH_AMT"]);
					((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[14, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[15, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[16, DC_Main.R].Value, (object)""));
					((DataGridView)dGV)[21, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_MRP"]);
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_AMT"])) == 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_MRP"])) == 0.0))
					{
						DataGridViewCell obj = ((DataGridView)dGV)[13, DC_Main.R];
						object obj2 = DC_Main.Rshlp.Rows[DC_Main.M]["ITM_FINE"];
						object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["KR_FINE"], (object)"");
						obj.Value = Operators.SubtractObject(obj2, (object)DC_Main.Fnv(ref Value));
					}
					else if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_MRP"]);
						((DataGridView)dGV)[22, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_COST"]);
						DataGridViewCell obj3 = ((DataGridView)dGV)[23, DC_Main.R];
						DataGridViewCell val;
						object Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[21, DC_Main.R]).Value);
						double num19 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[22, DC_Main.R]).Value);
						double num20 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						obj3.Value = num19 - num20;
						((DataGridView)dGV)[11, DC_Main.R].Value = "";
						((DataGridView)dGV)[12, DC_Main.R].Value = "";
						((DataGridView)dGV)[10, DC_Main.R].Value = "";
					}
					else
					{
						((DataGridView)dGV)[11, DC_Main.R].Value = "";
						double num21 = 0.0;
						double num22 = 0.0;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.GR_TOUCH FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if ((DC_Main.Tbl.Rows.Count > 0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_AMT"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_NWT"])) != 0.0))
							{
								double num23 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_AMT"])) / Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_NWT"]))), "0.00"));
								double num24 = num23 * 100.0 / Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["GR_TOUCH"], (object)""));
								((DataGridView)dGV)[18, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[12, DC_Main.R].Value, (object)"")) * num24), "0.00");
							}
						}
						else
						{
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
							{
								dataView.RowFilter = " VCH_DATE <= '" + Conversions.ToString(Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.M]["CurDate"])) + "' AND GR_TYPE = 'G'";
								if (dataView.Count > 0)
								{
									num21 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["GR_RATE"])) / 10.0), "0.00"));
								}
								dataView.RowFilter = " VCH_DATE <= '" + Conversions.ToString(Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.M]["CurDate"])) + "' AND GR_TYPE = 'S'";
								if (dataView.Count > 0)
								{
									num22 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["GR_RATE"])) / 10.0), "0.00"));
								}
							}
							else
							{
								dataView.RowFilter = " VCH_DATE <= '" + Conversions.ToString(Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.M]["CurDate"])) + "'";
								if (dataView.Count > 0)
								{
									num21 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["FINE_GL_RATE"])) / 10.0), "0.00"));
									num22 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["FINE_SL_RATE"])) / 1000.0), "0.00"));
								}
							}
							if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"], (object)"G", false))
							{
								((DataGridView)dGV)[18, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[12, DC_Main.R].Value, (object)"")) * num21), "0.00");
							}
							else if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"], (object)"S", false))
							{
								((DataGridView)dGV)[18, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[12, DC_Main.R].Value, (object)"")) * num22), "0.00");
							}
						}
						((DataGridView)dGV)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_LBR_AMT"]);
						((DataGridView)dGV)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_OTH_AMT"]);
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.M]["BOOK_NAME"], (object)"SALES", false))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT DISC_AMT FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"]), (object)""));
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.RsDg.Rows.Count > 0)
							{
								if (Conversion.Val(Operators.ConcatenateObject(DC_Main.RsDg.Rows[0]["DISC_AMT"], (object)"")) > 0.0)
								{
									((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[19, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.AddObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.RsDg.Rows[0]["DISC_AMT"], (object)""))));
								}
								else
								{
									((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[19, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)""));
								}
							}
						}
						else
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[19, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)""));
						}
						((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[17, DC_Main.R].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[22, DC_Main.R].Value, (object)""));
					}
					num = (int)Math.Round((double)num + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[7, DC_Main.R].Value, (object)"")));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[8, DC_Main.R].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[9, DC_Main.R].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[10, DC_Main.R].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[11, DC_Main.R].Value, (object)""));
					if (Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[14, DC_Main.R].Value, (object)"")) == 0.0)
					{
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[12, DC_Main.R].Value, (object)""));
					}
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[13, DC_Main.R].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[14, DC_Main.R].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[15, DC_Main.R].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[16, DC_Main.R].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[17, DC_Main.R].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)""));
					num13 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[19, DC_Main.R].Value, (object)""));
					num14 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)""));
					num15 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[21, DC_Main.R].Value, (object)""));
					num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[22, DC_Main.R].Value, (object)""));
					num17 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[23, DC_Main.R].Value, (object)""));
					DC_Main.R++;
					dGV = null;
					DC_Main.M++;
				}
			}
			if (((DataGridView)DGV).Rows.Count >= 1)
			{
				((DataGridView)DGV).Rows.Add();
				((DataGridView)DGV).Rows.Add();
				DC_Main.R++;
				((DataGridView)DGV)[7, DC_Main.R].Value = num;
				((DataGridView)DGV)[8, DC_Main.R].Value = num2;
				((DataGridView)DGV)[9, DC_Main.R].Value = num3;
				((DataGridView)DGV)[10, DC_Main.R].Value = num4;
				((DataGridView)DGV)[11, DC_Main.R].Value = num5;
				((DataGridView)DGV)[12, DC_Main.R].Value = num6;
				((DataGridView)DGV)[13, DC_Main.R].Value = num7;
				((DataGridView)DGV)[14, DC_Main.R].Value = num8;
				((DataGridView)DGV)[15, DC_Main.R].Value = num9;
				((DataGridView)DGV)[16, DC_Main.R].Value = num10;
				((DataGridView)DGV)[17, DC_Main.R].Value = num11;
				((DataGridView)DGV)[18, DC_Main.R].Value = num12;
				((DataGridView)DGV)[19, DC_Main.R].Value = num13;
				((DataGridView)DGV)[20, DC_Main.R].Value = num14;
				((DataGridView)DGV)[21, DC_Main.R].Value = num15;
				((DataGridView)DGV)[22, DC_Main.R].Value = num16;
				((DataGridView)DGV)[23, DC_Main.R].Value = num17;
			}
		}
	}

	private void BtnBillWise_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_DATE).DataSource = null;
		((DataGridView)DGV_DATE).ClearSelection();
		((DataGridView)DGV_DATE).Rows.Clear();
		((DataGridView)DGV_DATE).Columns.Clear();
		((Control)DGV_DATE).Refresh();
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		((DataGridView)DGV_ITEM).DataSource = null;
		((DataGridView)DGV_ITEM).ClearSelection();
		((DataGridView)DGV_ITEM).Rows.Clear();
		((DataGridView)DGV_ITEM).Columns.Clear();
		((Control)DGV_ITEM).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV_DATE).Visible = true;
		DgvRptType = "BillWise";
		((Control)Panel2).Visible = true;
		BillProfitData();
	}

	private void BillProfitData()
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
		//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fd: Expected O, but got Unknown
		//IL_1369: Unknown result type (might be due to invalid IL or missing references)
		//IL_1373: Expected O, but got Unknown
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1434: Unknown result type (might be due to invalid IL or missing references)
		//IL_143e: Expected O, but got Unknown
		//IL_1454: Unknown result type (might be due to invalid IL or missing references)
		//IL_1459: Unknown result type (might be due to invalid IL or missing references)
		//IL_1463: Expected O, but got Unknown
		//IL_1479: Unknown result type (might be due to invalid IL or missing references)
		//IL_147e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1488: Expected O, but got Unknown
		//IL_1577: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d0: Expected O, but got Unknown
		//IL_1879: Unknown result type (might be due to invalid IL or missing references)
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[0].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Type");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[1].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "VchNo");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV).Columns[2].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "VchDate");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[3].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Ac Name");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(175.0 * ColCon);
			((DataGridView)DGV).Columns[4].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Pcs");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "GrWt");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "NetWt");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "ItmAmt");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "LbrAmt");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "OthAmt");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Mrp");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "NetAmt");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns[4].Frozen = true;
			if (cboRptType.SelectedIndex == 1)
			{
				((DataGridView)DGV).Columns[8].Visible = false;
				((DataGridView)DGV).Columns[9].Visible = false;
				((DataGridView)DGV).Columns[10].Visible = false;
				((DataGridView)DGV).Columns[11].Visible = false;
				((DataGridView)DGV).Columns[12].Visible = false;
			}
			((DataGridView)DGV).Columns.Add("", "Wh Fine");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Wh Amt");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Wh Lbr");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Wh Oth");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Wh Tot");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N0";
			if (cboRptType.SelectedIndex == 0)
			{
				((DataGridView)DGV).Columns[13].Visible = false;
				((DataGridView)DGV).Columns[14].Visible = false;
				((DataGridView)DGV).Columns[15].Visible = false;
				((DataGridView)DGV).Columns[16].Visible = false;
				((DataGridView)DGV).Columns[17].Visible = false;
			}
			((DataGridView)DGV).Columns.Add("", "Kr Fine");
			((DataGridView)DGV).Columns[18].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Kr Lbr");
			((DataGridView)DGV).Columns[19].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Kr Oth");
			((DataGridView)DGV).Columns[20].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Gl Rate");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Sl Rate");
			((DataGridView)DGV).Columns[22].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Kr ItAmt");
			((DataGridView)DGV).Columns[23].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Kr Tot");
			((DataGridView)DGV).Columns[24].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[24].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[24].DefaultCellStyle.Format = "N0";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "Old ItPf");
				((DataGridView)DGV).Columns[25].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[25].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[25].DefaultCellStyle.Format = "N0";
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "Old ItPf");
				((DataGridView)DGV).Columns[25].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[25].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[25].DefaultCellStyle.Format = "N0";
				((DataGridView)DGV).Columns[25].Visible = false;
			}
			((DataGridView)DGV).Columns.Add("", "Amt Profit");
			((DataGridView)DGV).Columns[26].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[26].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Fin Profit");
			((DataGridView)DGV).Columns[27].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[27].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[27].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Oth Profit");
			((DataGridView)DGV).Columns[28].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[28].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[28].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "ItType");
			((DataGridView)DGV).Columns[29].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[29].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "It Name");
			((DataGridView)DGV).Columns[30].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV).Columns[30].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
			((DataGridView)DGV).Columns.Add("", "Co Book");
			((DataGridView)DGV).Columns[31].Visible = false;
			((DataGridView)DGV).Columns.Add("", "Main Book");
			((DataGridView)DGV).Columns[32].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DateTime dateTime = Conversions.ToDate(mFromDt.Text);
			int num = 0;
			((DataGridView)DGV_DATE).DataSource = null;
			((DataGridView)DGV_DATE).ClearSelection();
			((DataGridView)DGV_DATE).Rows.Clear();
			((DataGridView)DGV_DATE).Columns.Clear();
			((Control)DGV_DATE).Refresh();
			((DataGridView)DGV_DATE).MultiSelect = false;
			((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
			if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
			{
				((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_DATE).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_DATE).RowTemplate.Height = DC_Main.MsGridRowHeight;
			}
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
			((DataGridView)DGV).AutoGenerateColumns = false;
			int num2 = ((DataGridView)DGV).ColumnCount - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num2)
			{
				((DataGridView)DGV_DATE).Columns.Add("", ((DataGridView)DGV).Columns[DC_Main.i].HeaderText);
				((DataGridView)DGV_DATE).Columns[DC_Main.i].Width = ((DataGridView)DGV).Columns[DC_Main.i].Width;
				((DataGridView)DGV_DATE).Columns[DC_Main.i].DefaultCellStyle.Alignment = ((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment;
				((DataGridView)DGV_DATE).Columns[DC_Main.i].DefaultCellStyle.Format = ((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Format;
				switch (DC_Main.i)
				{
				case 1:
				case 2:
				case 4:
				case 21:
				case 22:
				case 29:
				case 30:
					((DataGridView)DGV_DATE).Columns[DC_Main.i].Visible = false;
					break;
				}
				if (!((DataGridView)DGV).Columns[DC_Main.i].Visible)
				{
					((DataGridView)DGV_DATE).Columns[DC_Main.i].Visible = false;
				}
				DC_Main.i++;
			}
			((DataGridView)DGV_DATE).Columns[0].Frozen = true;
			((DataGridView)DGV_DATE).Columns[3].Frozen = true;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			int num3 = 0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			double num24 = 0.0;
			DC_Main.RsQry = "SELECT IT_CODE,AVG_TOUCH FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(table);
			DC_Main.RsQry = "SELECT FINE_GL_RATE,FINE_SL_RATE,VCH_DATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND GR_CODE IN ('FGL','FSL') ORDER BY VCH_DATE DESC";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"Please Insert Todays Gold Fine Rate and Silver Fine Rate in Rate Master....", (MsgBoxStyle)0, (object)null);
			}
			DC_Main.RsQry = "SELECT FINE_GL_RATE,FINE_SL_RATE,VCH_DATE,GR_RATE,GR_TYPE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND GR_CODE IN ('FGL','FSL') ORDER BY VCH_DATE DESC";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView2 = new DataView(DC_Main.Tbl);
			DC_Main.RsQry = "SELECT FINE_GL_RATE,FINE_SL_RATE,VCH_DATE,GR_RATE,GR_TYPE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND GR_CODE IN ('FGL','FSL') ORDER BY VCH_DATE ";
			DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView3 = new DataView(table2);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_TYPE,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.BOOK_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.ITM_AMT,A.LBR_AMT,A.OTH_AMT,A.ITM_MRP,B.AC_NAME,A.NET_AMT,A.ITM_FINE,  CASE WHEN A.TAG_NO = 'N' THEN A.KR_FINE ELSE  D.KR_FINE END AS KR_FINE,D.KR_LBR_AMT,CASE WHEN A.TAG_NO = 'N' THEN A.KR_OTH_AMT ELSE D.KR_OTH_AMT END AS KR_OTH_AMT,CASE WHEN A.TAG_NO = 'N' THEN A.KR_COST ELSE  D.KR_COST END AS KR_COST,C.IT_TYPE,C.IT_NAME,A.TAG_NO,A.IT_CODE,C.RATE_TYPE,C.AVG_RATE,A.IT_CODE FROM ((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.TAG_NO = D.TAG_NO AND A.VCH_SRNO = D.VCH_SRNO) LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.BOOK_NAME IN ('SALES','WH SALES','TOUR SALES','LABOUR WORK') "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE = '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE = '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK in (" + ScelectBook + ")";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK = '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO = '" + tTagNo.Text + "'";
			}
			DataTable table3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView4 = new DataView(table3);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,B.MAIN_BOOK FROM (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND B.MAIN_BOOK IN ('SALES','WH SALES','TOUR SALES','LABOUR WORK') "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.GR_CODE = '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(tPrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.PR_CODE = '" + tPrCode.Text + "'";
			}
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK in (" + ScelectBook + ")";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK = '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CODE = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO = '" + tTagNo.Text + "'";
			}
			DC_Main.RsQry += "GROUP BY B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,B.MAIN_BOOK ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.R = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num25 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num25)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					dataView4.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" CO_BOOK = '", DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
					int num26 = dataView4.Count - 1;
					for (int i = 0; i <= num26; i++)
					{
						if (DC_Main.R == 0)
						{
							dateTime = Conversions.ToDate(Strings.Format((object)Conversions.ToDate(dataView4[i]["VCH_DATE"]), "dd/MM/yyyy"));
						}
						if (DateTime.Compare(dateTime, Conversions.ToDate(Strings.Format((object)Conversions.ToDate(dataView4[i]["VCH_DATE"]), "dd/MM/yyyy"))) != 0)
						{
							DataGridViewX dGV_DATE = DGV_DATE;
							((DataGridView)dGV_DATE).Rows.Add();
							((DataGridView)dGV_DATE)[0, num].Value = num + 1;
							((DataGridView)dGV_DATE)[3, num].Value = Strings.Format((object)dateTime, "dd/MM/yyyy");
							((DataGridView)dGV_DATE)[5, num].Value = num3;
							((DataGridView)dGV_DATE)[6, num].Value = num4;
							((DataGridView)dGV_DATE)[7, num].Value = num5;
							((DataGridView)dGV_DATE)[8, num].Value = num6;
							((DataGridView)dGV_DATE)[9, num].Value = num7;
							((DataGridView)dGV_DATE)[10, num].Value = num8;
							((DataGridView)dGV_DATE)[11, num].Value = num9;
							((DataGridView)dGV_DATE)[12, num].Value = num10;
							((DataGridView)dGV_DATE)[13, num].Value = num11;
							((DataGridView)dGV_DATE)[14, num].Value = num12;
							((DataGridView)dGV_DATE)[15, num].Value = num13;
							((DataGridView)dGV_DATE)[16, num].Value = num14;
							((DataGridView)dGV_DATE)[17, num].Value = num15;
							((DataGridView)dGV_DATE)[18, num].Value = num16;
							((DataGridView)dGV_DATE)[23, num].Value = num17;
							((DataGridView)dGV_DATE)[19, num].Value = num18;
							((DataGridView)dGV_DATE)[20, num].Value = num19;
							((DataGridView)dGV_DATE)[24, num].Value = num20;
							((DataGridView)dGV_DATE)[25, num].Value = num24;
							((DataGridView)dGV_DATE)[26, num].Value = num21;
							((DataGridView)dGV_DATE)[27, num].Value = num22;
							((DataGridView)dGV_DATE)[28, num].Value = num23;
							dGV_DATE = null;
							num3 = 0;
							num4 = 0.0;
							num5 = 0.0;
							num6 = 0.0;
							num7 = 0.0;
							num8 = 0.0;
							num9 = 0.0;
							num10 = 0.0;
							num11 = 0.0;
							num12 = 0.0;
							num13 = 0.0;
							num14 = 0.0;
							num15 = 0.0;
							num16 = 0.0;
							num17 = 0.0;
							num18 = 0.0;
							num19 = 0.0;
							num20 = 0.0;
							num21 = 0.0;
							num22 = 0.0;
							num23 = 0.0;
							num24 = 0.0;
							dateTime = Conversions.ToDate(Strings.Format((object)Conversions.ToDate(dataView4[i]["VCH_DATE"]), "dd/MM/yyyy"));
							num++;
						}
						((DataGridView)dGV)[31, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["CO_BOOK"]);
						((DataGridView)dGV)[32, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["BOOK_NAME"]);
						((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["VCH_TYPE"]);
						((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["VCH_NO"]);
						((DataGridView)dGV)[3, DC_Main.R].Value = Strings.Format((object)Conversions.ToDate(dataView4[i]["VCH_DATE"]), "dd/MM/yyyy");
						((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["AC_NAME"]);
						((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_PCS"]);
						((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_GWT"]);
						((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_NWT"]);
						if (Operators.ConditionalCompareObjectEqual(dataView4[i]["BOOK_NAME"], (object)"SALES", false))
						{
							((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_AMT"]);
							((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["LBR_AMT"]);
							((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["OTH_AMT"]);
							((DataGridView)dGV)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_MRP"]);
							((DataGridView)dGV)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["NET_AMT"]);
						}
						else if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataView4[i]["BOOK_NAME"], (object)"WH SALES", false), Operators.CompareObjectEqual(dataView4[i]["BOOK_NAME"], (object)"TOUR SALES", false))))
						{
							((DataGridView)dGV)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_FINE"]);
							((DataGridView)dGV)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_AMT"]);
							((DataGridView)dGV)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["LBR_AMT"]);
							((DataGridView)dGV)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["OTH_AMT"]);
							((DataGridView)dGV)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_MRP"]);
							((DataGridView)dGV)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["NET_AMT"]);
						}
						if (Operators.ConditionalCompareObjectEqual(dataView4[i]["TAG_NO"], (object)"N", false))
						{
							dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"IT_CODE >= '", dataView4[i]["IT_CODE"]), (object)"'"));
							if (dataView.Count > 0 && Conversion.Val(RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_NWT"])) != 0.0)
							{
								((DataGridView)dGV)[18, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_NWT"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["AVG_TOUCH"])) / 100.0), "0.000");
							}
						}
						else
						{
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["KR_FINE"]);
							}
							((DataGridView)dGV)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["KR_LBR_AMT"]);
							((DataGridView)dGV)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["KR_OTH_AMT"]);
						}
						((DataGridView)dGV)[29, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["IT_TYPE"]);
						((DataGridView)dGV)[30, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["IT_NAME"]);
						object Value;
						DataGridViewCell val;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) == 0.0)
						{
							if (Operators.ConditionalCompareObjectEqual(dataView4[i]["RATE_TYPE"], (object)"P", false))
							{
								((DataGridView)dGV)[23, DC_Main.R].Value = Operators.MultiplyObject(dataView4[i]["AVG_RATE"], dataView4[i]["ITM_PCS"]);
							}
							else if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.GR_TOUCH,A.IT_TYPE FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '"), dataView4[i]["IT_CODE"]), (object)"'"));
								DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if ((DC_Main.Tbl.Rows.Count > 0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_AMT"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_NWT"])) != 0.0))
								{
									double num27 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_AMT"])) / Conversion.Val(RuntimeHelpers.GetObjectValue(dataView4[i]["ITM_NWT"]))), "0.00"));
									double num28 = num27 * 100.0 / Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["GR_TOUCH"], (object)""));
									((DataGridView)dGV)[23, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)"")) * num28), "0.00");
									if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
									{
										((DataGridView)dGV)[21, DC_Main.R].Value = Strings.Format((object)num28, "0.00");
									}
									if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""), (object)"S", false))
									{
										((DataGridView)dGV)[22, DC_Main.R].Value = Strings.Format((object)num28, "0.00");
									}
								}
							}
							else
							{
								dataView3.RowFilter = " VCH_DATE >= '" + Conversions.ToString(Conversions.ToDate(dataView4[i]["VCH_DATE"])) + "'";
								if (dataView3.Count > 0)
								{
									if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView4[i]["IT_TYPE"], (object)""), (object)"G", false))
									{
										if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
										{
											dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_TYPE = '", dataView4[i]["IT_TYPE"]), (object)"' AND VCH_DATE = '"), (object)Conversions.ToDate(((DataGridView)dGV)[3, DC_Main.R].Value)), (object)"'"));
											if (dataView3.Count > 0)
											{
												((DataGridView)dGV)[21, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView3[0]["GR_RATE"])) / 10.0), "0.00");
											}
										}
										else
										{
											((DataGridView)dGV)[21, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView3[0]["FINE_GL_RATE"])) / 10.0), "0.00");
										}
										DataGridViewCell obj = ((DataGridView)dGV)[23, DC_Main.R];
										Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[18, DC_Main.R]).Value);
										double num29 = DC_Main.Fnv(ref Value);
										val.Value = RuntimeHelpers.GetObjectValue(Value);
										Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[21, DC_Main.R]).Value);
										double num30 = DC_Main.Fnv(ref Value);
										val.Value = RuntimeHelpers.GetObjectValue(Value);
										obj.Value = num29 * num30;
										if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) == 0.0)
										{
											((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value));
											((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value));
										}
									}
									else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView4[i]["IT_TYPE"], (object)""), (object)"S", false))
									{
										if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
										{
											dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_TYPE = '", dataView4[i]["IT_TYPE"]), (object)"' AND VCH_DATE = '"), (object)Conversions.ToDate(((DataGridView)dGV)[3, DC_Main.R].Value)), (object)"'"));
											if (dataView3.Count > 0)
											{
												((DataGridView)dGV)[22, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView3[0]["GR_RATE"])) / 10.0), "0.00");
											}
										}
										else
										{
											((DataGridView)dGV)[22, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView3[0]["FINE_SL_RATE"])) / 1000.0), "0.00");
										}
										((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)"")) * Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[22, DC_Main.R].Value, (object)""));
										double num31 = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[22, DC_Main.R].Value, (object)""));
										if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) == 0.0)
										{
											((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value));
											((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value));
										}
									}
								}
								else
								{
									dataView2.RowFilter = " VCH_DATE >= '" + Conversions.ToString(Conversions.ToDate(dataView4[i]["VCH_DATE"])) + "'";
									if (dataView2.Count > 0)
									{
										if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView4[i]["IT_TYPE"], (object)""), (object)"G", false))
										{
											if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
											{
												dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_TYPE = '", dataView4[i]["IT_TYPE"]), (object)"' AND VCH_DATE = '"), (object)Conversions.ToDate(((DataGridView)dGV)[3, DC_Main.R].Value)), (object)"'"));
												if (dataView3.Count > 0)
												{
													((DataGridView)dGV)[21, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["GR_RATE"])) / 10.0), "0.00");
												}
											}
											else
											{
												((DataGridView)dGV)[21, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["FINE_GL_RATE"])) / 10.0), "0.00");
											}
											DataGridViewCell obj2 = ((DataGridView)dGV)[23, DC_Main.R];
											Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[18, DC_Main.R]).Value);
											double num32 = DC_Main.Fnv(ref Value);
											val.Value = RuntimeHelpers.GetObjectValue(Value);
											Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[21, DC_Main.R]).Value);
											double num33 = DC_Main.Fnv(ref Value);
											val.Value = RuntimeHelpers.GetObjectValue(Value);
											obj2.Value = num32 * num33;
											if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) == 0.0)
											{
												((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value));
												((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value));
											}
										}
										else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView4[i]["IT_TYPE"], (object)""), (object)"S", false))
										{
											if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
											{
												dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_TYPE = '", dataView4[i]["IT_TYPE"]), (object)"' AND VCH_DATE = '"), (object)Conversions.ToDate(((DataGridView)dGV)[3, DC_Main.R].Value)), (object)"'"));
												if (dataView3.Count > 0)
												{
													((DataGridView)dGV)[22, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["GR_RATE"])) / 10.0), "0.00");
												}
											}
											else
											{
												((DataGridView)dGV)[22, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["FINE_SL_RATE"])) / 1000.0), "0.00");
											}
											((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)"")) * Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[22, DC_Main.R].Value, (object)""));
											if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) == 0.0)
											{
												((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value));
												((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value));
											}
										}
									}
								}
							}
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) != 0.0)
						{
							((DataGridView)dGV)[24, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataView4[i]["KR_COST"]);
						}
						else
						{
							DataGridViewCell obj3 = ((DataGridView)dGV)[24, DC_Main.R];
							Value = Operators.ConcatenateObject(((DataGridView)dGV)[23, DC_Main.R].Value, (object)"");
							double num34 = DC_Main.Fnv(ref Value);
							Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[19, DC_Main.R]).Value);
							double num35 = DC_Main.Fnv(ref Value);
							val.Value = RuntimeHelpers.GetObjectValue(Value);
							double num36 = num34 + num35;
							Value = Operators.ConcatenateObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)"");
							obj3.Value = num36 + DC_Main.Fnv(ref Value);
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(NET_AMT) As SlAmt,SUM(PR_COST) As PrAmt FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV)[31, DC_Main.R].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV)[2, DC_Main.R].Value), (object)"' HAVING SUM(PR_COST) > 0"));
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								((DataGridView)dGV)[25, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["PrAmt"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SlAmt"]));
							}
							else
							{
								((DataGridView)dGV)[25, DC_Main.R].Value = 0;
							}
							((DataGridView)dGV)[26, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[24, DC_Main.R].Value));
						}
						else
						{
							DataGridViewCell obj4 = ((DataGridView)dGV)[26, DC_Main.R];
							Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[12, DC_Main.R]).Value);
							double num37 = DC_Main.Fnv(ref Value);
							val.Value = RuntimeHelpers.GetObjectValue(Value);
							Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[17, DC_Main.R]).Value);
							double num38 = DC_Main.Fnv(ref Value);
							val.Value = RuntimeHelpers.GetObjectValue(Value);
							double num39 = num37 + num38;
							Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[24, DC_Main.R]).Value);
							double num40 = DC_Main.Fnv(ref Value);
							val.Value = RuntimeHelpers.GetObjectValue(Value);
							obj4.Value = num39 - num40;
						}
						DataGridViewCell obj5 = ((DataGridView)dGV)[28, DC_Main.R];
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[12, DC_Main.R]).Value);
						double num41 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[17, DC_Main.R]).Value);
						double num42 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						double num43 = num41 + num42;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[24, DC_Main.R]).Value);
						double num44 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						obj5.Value = num43 - num44;
						if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataView4[i]["BOOK_NAME"], (object)"WH SALES", false), Operators.CompareObjectEqual(dataView4[i]["BOOK_NAME"], (object)"TOUR SALES", false))))
						{
							((DataGridView)dGV)[27, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, DC_Main.R].Value));
						}
						((DataGridView)dGV)[28, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[10, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[16, DC_Main.R].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)""));
						num3 = Conversions.ToInteger(Operators.AddObject((object)num3, ((DataGridView)dGV)[5, DC_Main.R].Value));
						num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV)[6, DC_Main.R].Value));
						num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV)[7, DC_Main.R].Value));
						num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV)[8, DC_Main.R].Value));
						num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV)[9, DC_Main.R].Value));
						num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV)[10, DC_Main.R].Value));
						num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV)[11, DC_Main.R].Value));
						num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV)[12, DC_Main.R].Value));
						num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV)[13, DC_Main.R].Value));
						num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV)[14, DC_Main.R].Value));
						num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV)[15, DC_Main.R].Value));
						num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV)[16, DC_Main.R].Value));
						num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV)[17, DC_Main.R].Value));
						num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[18, DC_Main.R].Value, (object)""));
						num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV)[23, DC_Main.R].Value));
						double num45 = num18;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[19, DC_Main.R]).Value);
						double num46 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num18 = num45 + num46;
						num19 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[20, DC_Main.R].Value, (object)""));
						num20 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[24, DC_Main.R].Value, (object)""));
						num21 = Conversions.ToDouble(Operators.AddObject((object)num21, ((DataGridView)dGV)[26, DC_Main.R].Value));
						num22 = Conversions.ToDouble(Operators.AddObject((object)num22, ((DataGridView)dGV)[27, DC_Main.R].Value));
						num23 = Conversions.ToDouble(Operators.AddObject((object)num23, ((DataGridView)dGV)[28, DC_Main.R].Value));
						num24 = Conversions.ToDouble(Operators.AddObject((object)num24, ((DataGridView)dGV)[25, DC_Main.R].Value));
						DC_Main.R++;
						((DataGridView)dGV).Rows.Add();
					}
					DC_Main.R++;
					dGV = null;
					DC_Main.M++;
				}
				DataGridViewX dGV_DATE2 = DGV_DATE;
				((DataGridView)dGV_DATE2).Rows.Add();
				((DataGridView)dGV_DATE2)[0, num].Value = num + 1;
				((DataGridView)dGV_DATE2)[3, num].Value = Strings.Format((object)dateTime, "dd/MM/yyyy");
				((DataGridView)dGV_DATE2)[5, num].Value = num3;
				((DataGridView)dGV_DATE2)[6, num].Value = num4;
				((DataGridView)dGV_DATE2)[7, num].Value = num5;
				((DataGridView)dGV_DATE2)[8, num].Value = num6;
				((DataGridView)dGV_DATE2)[9, num].Value = num7;
				((DataGridView)dGV_DATE2)[10, num].Value = num8;
				((DataGridView)dGV_DATE2)[11, num].Value = num9;
				((DataGridView)dGV_DATE2)[12, num].Value = num10;
				((DataGridView)dGV_DATE2)[13, num].Value = num11;
				((DataGridView)dGV_DATE2)[14, num].Value = num12;
				((DataGridView)dGV_DATE2)[15, num].Value = num13;
				((DataGridView)dGV_DATE2)[16, num].Value = num14;
				((DataGridView)dGV_DATE2)[17, num].Value = num15;
				((DataGridView)dGV_DATE2)[18, num].Value = num16;
				((DataGridView)dGV_DATE2)[23, num].Value = num17;
				((DataGridView)dGV_DATE2)[19, num].Value = num18;
				((DataGridView)dGV_DATE2)[20, num].Value = num19;
				((DataGridView)dGV_DATE2)[24, num].Value = num20;
				((DataGridView)dGV_DATE2)[25, num].Value = num24;
				((DataGridView)dGV_DATE2)[26, num].Value = num21;
				((DataGridView)dGV_DATE2)[27, num].Value = num22;
				((DataGridView)dGV_DATE2)[28, num].Value = num23;
				dGV_DATE2 = null;
			}
			((DataGridView)DGV_DATE).Rows.Add();
			((DataGridView)DGV_DATE).Rows.Add();
			int num47 = ((DataGridView)DGV_DATE).Rows.Count - 1;
			DC_Main.M = 0;
			int num48 = ((DataGridView)DGV_DATE).Rows.Count - 2;
			DC_Main.M = 0;
			while (DC_Main.M <= num48)
			{
				DataGridViewX dGV_DATE3 = DGV_DATE;
				DataGridViewCell val;
				(val = ((DataGridView)dGV_DATE3)[5, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[5, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[6, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[6, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[7, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[7, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[8, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[8, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[9, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[9, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[10, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[10, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[11, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[11, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[12, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[12, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[13, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[13, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[14, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[14, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[15, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[15, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[16, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[16, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[17, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[17, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[18, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[18, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[23, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[23, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[19, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[19, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[20, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[20, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[24, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[24, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[25, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[25, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[26, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[26, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[27, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[27, DC_Main.M].Value);
				(val = ((DataGridView)dGV_DATE3)[28, num47]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_DATE3)[28, DC_Main.M].Value);
				dGV_DATE3 = null;
				DC_Main.M++;
			}
			((DataGridView)DGV_DATE)[3, num47].Value = "Total :";
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 354:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0029;
						case 5:
							goto IL_009f;
						case 6:
							goto IL_00b0;
						case 7:
							goto IL_00d1;
						case 8:
							goto IL_00df;
						case 4:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 14:
						case 15:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00b0:
					num2 = 6;
					if (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) != 0)
					{
						break;
					}
					goto IL_00d1;
					IL_00d1:
					num2 = 7;
					((ConvertEventArgs)e).Value = "";
					goto IL_00df;
					IL_009f:
					num2 = 5;
					if (((ConvertEventArgs)e).Value == null)
					{
						break;
					}
					goto IL_00b0;
					IL_00df:
					num2 = 8;
					e.FormattingApplied = true;
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DgvRptType, "BillWise", false) != 0)
					{
						break;
					}
					goto IL_0029;
					IL_0029:
					num2 = 3;
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					case 23:
					case 24:
					case 28:
						break;
					default:
						goto end_IL_0001_2;
					}
					goto IL_009f;
					end_IL_0001_2:
					break;
				}
				num2 = 13;
				if (Operators.CompareString(DgvRptType, "TagWise", false) != 0)
				{
				}
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 354;
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		object obj = default(object);
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
		ColorConverter colorConverter = default(ColorConverter);
		int num14 = default(int);
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
					case 1861:
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
								goto IL_01d0;
							case 18:
								goto IL_0223;
							case 19:
								goto IL_0232;
							case 21:
								goto IL_0254;
							case 22:
								goto IL_026b;
							case 23:
								goto IL_02b3;
							case 24:
								goto IL_02c2;
							case 25:
								goto IL_02df;
							case 26:
								goto IL_02f9;
							case 27:
								goto IL_031c;
							case 28:
							case 29:
								goto IL_0371;
							case 30:
								goto IL_0383;
							case 20:
							case 31:
							case 32:
								goto IL_039f;
							case 33:
								goto IL_03a9;
							case 34:
								goto IL_03fc;
							case 35:
								goto IL_0451;
							case 36:
								goto IL_04a9;
							case 37:
								goto IL_0517;
							case 38:
								goto IL_055a;
							case 39:
								goto IL_0589;
							case 40:
								goto IL_05cc;
							case 41:
								goto IL_060d;
							case 42:
								goto IL_062e;
							case 43:
								goto IL_063c;
							case 44:
								goto IL_0656;
							case 45:
								goto IL_065c;
							case 46:
								goto IL_0662;
							case 47:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 48:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0371:
						num2 = 29;
						num5++;
						goto IL_037a;
						IL_026b:
						num2 = 22;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02b3;
						IL_031c:
						num2 = 27;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0371;
						IL_02b3:
						num2 = 23;
						num6++;
						goto IL_02bc;
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
						if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
						{
							goto IL_012e;
						}
						goto IL_0254;
						IL_012e:
						num2 = 12;
						num7 = ((DataGridView)DGV_VCH).ColumnCount - 1;
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
						num9 = ((DataGridView)DGV_VCH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0241;
						IL_0241:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_039f;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num11 = 0;
						goto IL_022c;
						IL_022c:
						if (num11 <= num10)
						{
							goto IL_01d0;
						}
						goto IL_0232;
						IL_0232:
						num2 = 19;
						DC_Main.i++;
						goto IL_0241;
						IL_01d0:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0223;
						IL_0223:
						num2 = 18;
						num11++;
						goto IL_022c;
						IL_0145:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_VCH).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_018d;
						IL_018d:
						num2 = 14;
						num8++;
						goto IL_0196;
						IL_0254:
						num2 = 21;
						num12 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_02bc;
						IL_02bc:
						if (num6 <= num12)
						{
							goto IL_026b;
						}
						goto IL_02c2;
						IL_02c2:
						num2 = 24;
						num13 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0392;
						IL_0392:
						if (DC_Main.i <= num13)
						{
							goto IL_02df;
						}
						goto IL_039f;
						IL_039f:
						num2 = 32;
						colorConverter = new ColorConverter();
						goto IL_03a9;
						IL_03a9:
						num2 = 33;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_03fc;
						IL_03fc:
						num2 = 34;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0451;
						IL_0451:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04a9;
						IL_04a9:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0517;
						IL_0517:
						num2 = 37;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_055a;
						IL_055a:
						num2 = 38;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0589;
						IL_0589:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05cc;
						IL_05cc:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_060d;
						IL_060d:
						num2 = 41;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_062e;
						IL_062e:
						num2 = 42;
						Cursor.Current = Cursors.Default;
						goto IL_063c;
						IL_063c:
						num2 = 43;
						NewLateBinding.LateCall(obj2, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0656;
						IL_0656:
						num2 = 44;
						obj = null;
						goto IL_065c;
						IL_065c:
						num2 = 45;
						obj3 = null;
						goto IL_0662;
						IL_0662:
						num2 = 46;
						obj2 = null;
						break;
						IL_02df:
						num2 = 25;
						num14 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_037a;
						IL_037a:
						if (num5 <= num14)
						{
							goto IL_02f9;
						}
						goto IL_0383;
						IL_0383:
						num2 = 30;
						DC_Main.i++;
						goto IL_0392;
						IL_02f9:
						num2 = 26;
						if (((DataGridView)DGV)[num5, DC_Main.i].Value != null)
						{
							goto IL_031c;
						}
						goto IL_0371;
						end_IL_0001_2:
						break;
					}
					num2 = 47;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1861;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	private void RP_BILL_PROFIT_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_106a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1071: Expected O, but got Unknown
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f0: Expected O, but got Unknown
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_117d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1187: Expected O, but got Unknown
		//IL_11f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1204: Expected O, but got Unknown
		//IL_12b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c5: Expected O, but got Unknown
		//IL_12e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f3: Expected O, but got Unknown
		//IL_1312: Unknown result type (might be due to invalid IL or missing references)
		//IL_1317: Unknown result type (might be due to invalid IL or missing references)
		//IL_1321: Expected O, but got Unknown
		//IL_13a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b2: Expected O, but got Unknown
		//IL_13d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e0: Expected O, but got Unknown
		//IL_13ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1404: Unknown result type (might be due to invalid IL or missing references)
		//IL_140e: Expected O, but got Unknown
		//IL_1490: Unknown result type (might be due to invalid IL or missing references)
		//IL_1495: Unknown result type (might be due to invalid IL or missing references)
		//IL_149f: Expected O, but got Unknown
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cd: Expected O, but got Unknown
		//IL_14ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fb: Expected O, but got Unknown
		//IL_157d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1582: Unknown result type (might be due to invalid IL or missing references)
		//IL_158c: Expected O, but got Unknown
		//IL_15ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ba: Expected O, but got Unknown
		//IL_15d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15de: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e8: Expected O, but got Unknown
		//IL_166a: Unknown result type (might be due to invalid IL or missing references)
		//IL_166f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1679: Expected O, but got Unknown
		//IL_1698: Unknown result type (might be due to invalid IL or missing references)
		//IL_169d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a7: Expected O, but got Unknown
		//IL_16c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d5: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
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
			foreach (object control3 in ((Control)Panel1).Controls)
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
			foreach (object control4 in ((Control)Panel2).Controls)
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
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				object? obj2 = colorConverter.ConvertFromString("Gainsboro");
				((Form)this).BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
				Label obj3 = lblBook;
				object? obj4 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj3).BackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
				Label obj5 = lblBook;
				object? obj6 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj5).ForeColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewX dGV_DATE = DGV_DATE;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DATE).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewX dGV_VCH = DGV_VCH;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DataGridViewX dGV_ITEM = DGV_ITEM;
				object? obj14 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_ITEM).BackgroundColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_ITEM).AlternatingRowsDefaultCellStyle;
				object? obj15 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				((Control)Panel2).BackColor = Color.Silver;
				ComboBox obj16 = cboItemTyp;
				object? obj17 = colorConverter.ConvertFromString("243, 240, 239");
				obj16.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				ComboBox obj18 = cboRptType;
				object? obj19 = colorConverter.ConvertFromString("243, 240, 239");
				obj18.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj20 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV2 = DGV;
				object? obj21 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewX dGV_DATE2 = DGV_DATE;
				object? obj23 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DATE2).BackgroundColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle;
				object? obj24 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj25 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj26 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				DataGridViewX dGV_ITEM2 = DGV_ITEM;
				object? obj27 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_ITEM2).BackgroundColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_ITEM).AlternatingRowsDefaultCellStyle;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				Panel panel = Panel1;
				object? obj29 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				Panel panel2 = Panel2;
				object? obj30 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel2).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				ComboBox obj31 = cboItemTyp;
				object? obj32 = colorConverter.ConvertFromString("233, 235, 240");
				obj31.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				ComboBox obj33 = cboRptType;
				object? obj34 = colorConverter.ConvertFromString("233, 235, 240");
				obj33.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj35 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj36 = lblBook;
				object? obj37 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj36).ForeColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj38 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj39 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj40 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				DataGridViewX dGV_DATE3 = DGV_DATE;
				object? obj41 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DATE3).BackgroundColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle10 = ((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle;
				object? obj42 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle10.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj43 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle11 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj44 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle11.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				DataGridViewX dGV_ITEM3 = DGV_ITEM;
				object? obj45 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_ITEM3).BackgroundColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle12 = ((DataGridView)DGV_ITEM).AlternatingRowsDefaultCellStyle;
				object? obj46 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle12.BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				Panel panel3 = Panel1;
				object? obj47 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel3).BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				Panel panel4 = Panel2;
				object? obj48 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel4).BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
				cboRptType.BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tPrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tPrCode).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DATE).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DATE).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DATE).Font.Style);
					((DataGridView)DGV_DATE).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DATE).Font.Style);
					((DataGridView)DGV_DATE).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DATE).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DATE).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DATE).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_VCH).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_VCH).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_VCH).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_ITEM).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITEM).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_ITEM).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITEM).Font.Style);
					((DataGridView)DGV_ITEM).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITEM).Font.Style);
					((DataGridView)DGV_ITEM).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_ITEM).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_ITEM).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_ITEM).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_ITM).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_ITM).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_ITM).RowTemplate.Height * (1.0 + num2));
				}
			}
			cboItemTyp.Items.Add((object)"");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			cboItemTyp.SelectedIndex = 0;
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
			{
				cboRptType.Items.Add((object)"Retail");
				cboRptType.Items.Add((object)"WhSale");
				cboRptType.Items.Add((object)"Lbr Work");
				cboRptType.Items.Add((object)"");
				if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
				{
					cboRptType.SelectedIndex = 1;
				}
				else
				{
					cboRptType.SelectedIndex = 0;
				}
			}
			else
			{
				cboRptType.Items.Add((object)"Retail");
				cboRptType.Items.Add((object)"WhSale");
				cboRptType.Items.Add((object)"");
				if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
				{
					cboRptType.SelectedIndex = 1;
				}
				else
				{
					cboRptType.SelectedIndex = 0;
				}
			}
			mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			BookMast();
			DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), DC_Main.MLc_code);
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
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		((DataGridView)DGV_DATE).DataSource = null;
		((DataGridView)DGV_DATE).ClearSelection();
		((DataGridView)DGV_DATE).Rows.Clear();
		((DataGridView)DGV_DATE).Columns.Clear();
		((Control)DGV_DATE).Refresh();
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		((DataGridView)DGV_ITEM).DataSource = null;
		((DataGridView)DGV_ITEM).ClearSelection();
		((DataGridView)DGV_ITEM).Rows.Clear();
		((DataGridView)DGV_ITEM).Columns.Clear();
		((Control)DGV_ITEM).Refresh();
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		DGV_CLEAR();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DgvRptType, "BillWise", false) == 0)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((DataGridView)DGV_VCH).DataSource = null;
				((DataGridView)DGV_VCH).ClearSelection();
				((DataGridView)DGV_VCH).Rows.Clear();
				((DataGridView)DGV_VCH).Columns.Clear();
				((Control)DGV_VCH).Refresh();
				BtnExit.Text = "&Exit";
				((Control)DGV_DATE).Visible = true;
			}
			else if (Operators.CompareString(BtnExit.Text, "&Back1", false) == 0)
			{
				((DataGridView)DGV_ITEM).DataSource = null;
				((DataGridView)DGV_ITEM).ClearSelection();
				((DataGridView)DGV_ITEM).Rows.Clear();
				((DataGridView)DGV_ITEM).Columns.Clear();
				((Control)DGV_ITEM).Refresh();
				BtnExit.Text = "&Back";
				((Control)DGV_VCH).Visible = true;
			}
			else
			{
				((Form)this).Close();
			}
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_VCH).DataSource = null;
			((DataGridView)DGV_VCH).ClearSelection();
			((DataGridView)DGV_VCH).Rows.Clear();
			((Control)DGV_VCH).Refresh();
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_BILL_PROFIT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_BILL_PROFIT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_BILL_PROFIT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
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

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_BILL_PROFIT_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void RP_LEDR_Closed(object sender, EventArgs e)
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
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDt;
			DC_Main.SetDate(ref MsDate);
			mToDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
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

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tGrCode.Text = DC_Main.ColValue[1];
			}
			((TextBoxBase)tGrCode).SelectAll();
		}
	}

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tPrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT PR_NAME As PrNameL,PR_CODE as PrCodeL FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[3];
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tPrCode.Text = DC_Main.ColValue[1];
			}
			((TextBoxBase)tPrCode).SelectAll();
		}
	}

	private void DGV_DATE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 315:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0029;
						case 5:
							goto IL_009f;
						case 6:
							goto IL_00b0;
						case 7:
							goto IL_00d1;
						case 8:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 4:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_009f:
					num2 = 5;
					if (((ConvertEventArgs)e).Value == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_00b0;
					IL_00b0:
					num2 = 6;
					if (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00d1;
					IL_0029:
					num2 = 3;
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					case 23:
					case 24:
					case 28:
						break;
					default:
						goto end_IL_0001_3;
					}
					goto IL_009f;
					IL_00d1:
					num2 = 7;
					((ConvertEventArgs)e).Value = "";
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DgvRptType, "BillWise", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0029;
					end_IL_0001_2:
					break;
				}
				num2 = 8;
				e.FormattingApplied = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 315;
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

	private void DGV_DATE_DoubleClick(object sender, EventArgs e)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		int index = ((DataGridViewBand)((DataGridView)DGV_DATE).CurrentRow).Index;
		DateTime t = Conversions.ToDate(((DataGridView)DGV_DATE)[3, index].Value);
		BtnExit.Text = "&Back";
		((Control)DGV_DATE).Visible = false;
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		((Control)DGV_VCH).Visible = true;
		((DataGridView)DGV_VCH).MultiSelect = false;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		checked
		{
			int num = ((DataGridView)DGV).ColumnCount - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				((DataGridView)DGV_VCH).Columns.Add("", ((DataGridView)DGV).Columns[DC_Main.i].HeaderText);
				((DataGridView)DGV_VCH).Columns[DC_Main.i].Width = ((DataGridView)DGV).Columns[DC_Main.i].Width;
				((DataGridView)DGV_VCH).Columns[DC_Main.i].DefaultCellStyle.Alignment = ((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment;
				((DataGridView)DGV_VCH).Columns[DC_Main.i].DefaultCellStyle.Format = ((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Format;
				int i = DC_Main.i;
				if (unchecked((uint)(i - 21) <= 1u || (uint)(i - 29) <= 1u))
				{
					((DataGridView)DGV_VCH).Columns[DC_Main.i].Visible = false;
				}
				if (!((DataGridView)DGV).Columns[DC_Main.i].Visible)
				{
					((DataGridView)DGV_VCH).Columns[DC_Main.i].Visible = false;
				}
				DC_Main.i++;
			}
			((DataGridView)DGV_VCH).Columns[0].Frozen = true;
			((DataGridView)DGV_VCH).Columns[4].Frozen = true;
			int num2 = 0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			DC_Main.R = 0;
			string text = "";
			int num24 = 0;
			int num25 = ((DataGridView)DGV).Rows.Count - 1;
			DC_Main.R = 0;
			while (DC_Main.R <= num25)
			{
				DataGridViewX dGV = DGV;
				if (DateTime.Compare(t, Conversions.ToDate(((DataGridView)DGV)[3, DC_Main.R].Value)) == 0)
				{
					if (Operators.ConditionalCompareObjectNotEqual((object)text, Operators.ConcatenateObject(((DataGridView)DGV)[31, DC_Main.R].Value, ((DataGridView)DGV)[2, DC_Main.R].Value), false))
					{
						((DataGridView)DGV_VCH).Rows.Add();
						((DataGridView)DGV_VCH)[0, num24].Value = num24 + 1;
						((DataGridView)DGV_VCH)[1, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[1, DC_Main.R].Value);
						((DataGridView)DGV_VCH)[31, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[31, DC_Main.R].Value);
						((DataGridView)DGV_VCH)[2, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[2, DC_Main.R].Value);
						((DataGridView)DGV_VCH)[3, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[3, DC_Main.R].Value);
						((DataGridView)DGV_VCH)[4, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[4, DC_Main.R].Value);
						if (num24 != 0)
						{
							((DataGridView)DGV_VCH)[5, num24 - 1].Value = num2;
							((DataGridView)DGV_VCH)[6, num24 - 1].Value = num3;
							((DataGridView)DGV_VCH)[7, num24 - 1].Value = num4;
							((DataGridView)DGV_VCH)[8, num24 - 1].Value = num5;
							((DataGridView)DGV_VCH)[9, num24 - 1].Value = num6;
							((DataGridView)DGV_VCH)[10, num24 - 1].Value = num7;
							((DataGridView)DGV_VCH)[11, num24 - 1].Value = num8;
							((DataGridView)DGV_VCH)[12, num24 - 1].Value = num9;
							((DataGridView)DGV_VCH)[13, num24 - 1].Value = num10;
							((DataGridView)DGV_VCH)[14, num24 - 1].Value = num11;
							((DataGridView)DGV_VCH)[15, num24 - 1].Value = num12;
							((DataGridView)DGV_VCH)[16, num24 - 1].Value = num13;
							((DataGridView)DGV_VCH)[17, num24 - 1].Value = num14;
							((DataGridView)DGV_VCH)[18, num24 - 1].Value = num15;
							((DataGridView)DGV_VCH)[23, num24 - 1].Value = num16;
							((DataGridView)DGV_VCH)[19, num24 - 1].Value = num17;
							((DataGridView)DGV_VCH)[20, num24 - 1].Value = num18;
							((DataGridView)DGV_VCH)[24, num24 - 1].Value = num19;
							((DataGridView)DGV_VCH)[25, num24 - 1].Value = num23;
							((DataGridView)DGV_VCH)[26, num24 - 1].Value = num20;
							((DataGridView)DGV_VCH)[27, num24 - 1].Value = num21;
							((DataGridView)DGV_VCH)[28, num24 - 1].Value = num22;
						}
						text = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV)[31, DC_Main.R].Value, ((DataGridView)DGV)[2, DC_Main.R].Value));
						num24++;
						if (DC_Main.R != ((DataGridView)DGV).Rows.Count - 1)
						{
							num2 = 0;
							num3 = 0.0;
							num4 = 0.0;
							num5 = 0.0;
							num6 = 0.0;
							num7 = 0.0;
							num8 = 0.0;
							num9 = 0.0;
							num10 = 0.0;
							num11 = 0.0;
							num12 = 0.0;
							num13 = 0.0;
							num14 = 0.0;
							num15 = 0.0;
							num16 = 0.0;
							num17 = 0.0;
							num18 = 0.0;
							num19 = 0.0;
							num20 = 0.0;
							num21 = 0.0;
							num22 = 0.0;
							num23 = 0.0;
						}
					}
					num2 = Conversions.ToInteger(Operators.AddObject((object)num2, ((DataGridView)dGV)[5, DC_Main.R].Value));
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[6, DC_Main.R].Value));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV)[7, DC_Main.R].Value));
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV)[8, DC_Main.R].Value));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV)[9, DC_Main.R].Value));
					num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV)[10, DC_Main.R].Value));
					num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV)[11, DC_Main.R].Value));
					num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV)[12, DC_Main.R].Value));
					num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV)[13, DC_Main.R].Value));
					num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV)[14, DC_Main.R].Value));
					num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV)[15, DC_Main.R].Value));
					num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV)[16, DC_Main.R].Value));
					num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV)[17, DC_Main.R].Value));
					num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV)[18, DC_Main.R].Value));
					num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV)[23, DC_Main.R].Value));
					num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV)[19, DC_Main.R].Value));
					num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV)[20, DC_Main.R].Value));
					num19 = Conversions.ToDouble(Operators.AddObject((object)num19, ((DataGridView)dGV)[24, DC_Main.R].Value));
					num20 = Conversions.ToDouble(Operators.AddObject((object)num20, ((DataGridView)dGV)[26, DC_Main.R].Value));
					num21 = Conversions.ToDouble(Operators.AddObject((object)num21, ((DataGridView)dGV)[27, DC_Main.R].Value));
					num22 = Conversions.ToDouble(Operators.AddObject((object)num22, ((DataGridView)dGV)[28, DC_Main.R].Value));
					num23 = Conversions.ToDouble(Operators.AddObject((object)num23, ((DataGridView)dGV)[25, DC_Main.R].Value));
				}
				dGV = null;
				DC_Main.R++;
			}
			num24--;
			((DataGridView)DGV_VCH)[5, num24].Value = num2;
			((DataGridView)DGV_VCH)[6, num24].Value = num3;
			((DataGridView)DGV_VCH)[7, num24].Value = num4;
			((DataGridView)DGV_VCH)[8, num24].Value = num5;
			((DataGridView)DGV_VCH)[9, num24].Value = num6;
			((DataGridView)DGV_VCH)[10, num24].Value = num7;
			((DataGridView)DGV_VCH)[11, num24].Value = num8;
			((DataGridView)DGV_VCH)[12, num24].Value = num9;
			((DataGridView)DGV_VCH)[13, num24].Value = num10;
			((DataGridView)DGV_VCH)[14, num24].Value = num11;
			((DataGridView)DGV_VCH)[15, num24].Value = num12;
			((DataGridView)DGV_VCH)[16, num24].Value = num13;
			((DataGridView)DGV_VCH)[17, num24].Value = num14;
			((DataGridView)DGV_VCH)[18, num24].Value = num15;
			((DataGridView)DGV_VCH)[23, num24].Value = num16;
			((DataGridView)DGV_VCH)[19, num24].Value = num17;
			((DataGridView)DGV_VCH)[20, num24].Value = num18;
			((DataGridView)DGV_VCH)[24, num24].Value = num19;
			((DataGridView)DGV_VCH)[25, num24].Value = num23;
			((DataGridView)DGV_VCH)[26, num24].Value = num20;
			((DataGridView)DGV_VCH)[27, num24].Value = num21;
			((DataGridView)DGV_VCH)[28, num24].Value = num22;
			((DataGridView)DGV_VCH).Rows.Add();
			((DataGridView)DGV_VCH).Rows.Add();
			int num26 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			index = 0;
			int num27 = ((DataGridView)DGV_VCH).Rows.Count - 2;
			for (index = 0; index <= num27; index++)
			{
				DataGridViewX dGV_VCH = DGV_VCH;
				DataGridViewCell val;
				(val = ((DataGridView)dGV_VCH)[5, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[5, index].Value);
				(val = ((DataGridView)dGV_VCH)[6, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[6, index].Value);
				(val = ((DataGridView)dGV_VCH)[7, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[7, index].Value);
				(val = ((DataGridView)dGV_VCH)[8, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[8, index].Value);
				(val = ((DataGridView)dGV_VCH)[9, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[9, index].Value);
				(val = ((DataGridView)dGV_VCH)[10, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[10, index].Value);
				(val = ((DataGridView)dGV_VCH)[11, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[11, index].Value);
				(val = ((DataGridView)dGV_VCH)[12, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[12, index].Value);
				(val = ((DataGridView)dGV_VCH)[13, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[13, index].Value);
				(val = ((DataGridView)dGV_VCH)[14, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[14, index].Value);
				(val = ((DataGridView)dGV_VCH)[15, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[15, index].Value);
				(val = ((DataGridView)dGV_VCH)[16, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[16, index].Value);
				(val = ((DataGridView)dGV_VCH)[17, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[17, index].Value);
				(val = ((DataGridView)dGV_VCH)[18, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[18, index].Value);
				(val = ((DataGridView)dGV_VCH)[23, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[23, index].Value);
				(val = ((DataGridView)dGV_VCH)[19, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[19, index].Value);
				(val = ((DataGridView)dGV_VCH)[20, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[20, index].Value);
				(val = ((DataGridView)dGV_VCH)[24, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[24, index].Value);
				(val = ((DataGridView)dGV_VCH)[25, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[25, index].Value);
				(val = ((DataGridView)dGV_VCH)[26, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[26, index].Value);
				(val = ((DataGridView)dGV_VCH)[27, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[27, index].Value);
				(val = ((DataGridView)dGV_VCH)[28, num26]).Value = Operators.AddObject(val.Value, ((DataGridView)dGV_VCH)[28, index].Value);
				dGV_VCH = null;
			}
			((DataGridView)DGV_VCH)[3, num26].Value = "Total :";
		}
	}

	private void DGV_VCH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 315:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0029;
						case 5:
							goto IL_009f;
						case 6:
							goto IL_00b0;
						case 7:
							goto IL_00d1;
						case 8:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 4:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_009f:
					num2 = 5;
					if (((ConvertEventArgs)e).Value == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_00b0;
					IL_00b0:
					num2 = 6;
					if (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00d1;
					IL_0029:
					num2 = 3;
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					case 23:
					case 24:
					case 28:
						break;
					default:
						goto end_IL_0001_3;
					}
					goto IL_009f;
					IL_00d1:
					num2 = 7;
					((ConvertEventArgs)e).Value = "";
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DgvRptType, "BillWise", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0029;
					end_IL_0001_2:
					break;
				}
				num2 = 8;
				e.FormattingApplied = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 315;
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

	private void DGV_VCH_DoubleClick(object sender, EventArgs e)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		int index = ((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index;
		string text = Conversions.ToString(((DataGridView)DGV_VCH)[31, index].Value);
		string text2 = Conversions.ToString(((DataGridView)DGV_VCH)[2, index].Value);
		BtnExit.Text = "&Back1";
		((Control)DGV_VCH).Visible = false;
		((DataGridView)DGV_ITEM).DataSource = null;
		((DataGridView)DGV_ITEM).ClearSelection();
		((DataGridView)DGV_ITEM).Rows.Clear();
		((DataGridView)DGV_ITEM).Columns.Clear();
		((Control)DGV_ITEM).Refresh();
		((Control)DGV_ITEM).Visible = true;
		((DataGridView)DGV_ITEM).MultiSelect = false;
		((DataGridView)DGV_ITEM).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_ITEM).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_ITEM).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_ITEM).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_ITEM).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		checked
		{
			int num = ((DataGridView)DGV).ColumnCount - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				((DataGridView)DGV_ITEM).Columns.Add("", ((DataGridView)DGV).Columns[DC_Main.i].HeaderText);
				((DataGridView)DGV_ITEM).Columns[DC_Main.i].Width = ((DataGridView)DGV).Columns[DC_Main.i].Width;
				((DataGridView)DGV_ITEM).Columns[DC_Main.i].DefaultCellStyle.Alignment = ((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Alignment;
				((DataGridView)DGV_ITEM).Columns[DC_Main.i].DefaultCellStyle.Format = ((DataGridView)DGV).Columns[DC_Main.i].DefaultCellStyle.Format;
				if (!((DataGridView)DGV).Columns[DC_Main.i].Visible)
				{
					((DataGridView)DGV_ITEM).Columns[DC_Main.i].Visible = false;
				}
				DC_Main.i++;
			}
			((DataGridView)DGV_ITEM).Columns[0].Frozen = true;
			((DataGridView)DGV_ITEM).Columns[4].Frozen = true;
			int num2 = 0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			DC_Main.R = 0;
			int num24 = 0;
			int num25 = ((DataGridView)DGV).Rows.Count - 1;
			DC_Main.R = 0;
			while (DC_Main.R <= num25)
			{
				DataGridViewX dGV = DGV;
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual((object)text, ((DataGridView)DGV)[31, DC_Main.R].Value, false), Operators.CompareObjectEqual((object)text2, ((DataGridView)DGV)[2, DC_Main.R].Value, false))))
				{
					((DataGridView)DGV_ITEM).Rows.Add();
					((DataGridView)DGV_ITEM)[0, num24].Value = num24 + 1;
					((DataGridView)DGV_ITEM)[31, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[31, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[32, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[32, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[1, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[1, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[2, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[2, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[3, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[3, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[4, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[5, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[6, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[7, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[8, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[9, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[10, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[11, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[12, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[13, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[14, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[15, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[16, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[17, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[21, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[22, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[22, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[18, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[23, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[23, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[19, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[19, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[20, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[20, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[24, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[24, DC_Main.R].Value);
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITEM)[0, num24].Value, (object)1, false))
					{
						((DataGridView)DGV_ITEM)[25, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[25, DC_Main.R].Value);
					}
					((DataGridView)DGV_ITEM)[26, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[26, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[27, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[27, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[28, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[28, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[29, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[29, DC_Main.R].Value);
					((DataGridView)DGV_ITEM)[30, num24].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[30, DC_Main.R].Value);
					num2 = Conversions.ToInteger(Operators.AddObject((object)num2, ((DataGridView)dGV)[5, DC_Main.R].Value));
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[6, DC_Main.R].Value));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV)[7, DC_Main.R].Value));
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, ((DataGridView)dGV)[8, DC_Main.R].Value));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV)[9, DC_Main.R].Value));
					num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV)[10, DC_Main.R].Value));
					num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV)[11, DC_Main.R].Value));
					num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV)[12, DC_Main.R].Value));
					num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV)[13, DC_Main.R].Value));
					num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV)[14, DC_Main.R].Value));
					num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV)[15, DC_Main.R].Value));
					num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV)[16, DC_Main.R].Value));
					num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV)[17, DC_Main.R].Value));
					num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV)[18, DC_Main.R].Value));
					num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV)[23, DC_Main.R].Value));
					num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV)[19, DC_Main.R].Value));
					num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV)[20, DC_Main.R].Value));
					num19 = Conversions.ToDouble(Operators.AddObject((object)num19, ((DataGridView)dGV)[24, DC_Main.R].Value));
					num20 = Conversions.ToDouble(Operators.AddObject((object)num20, ((DataGridView)dGV)[26, DC_Main.R].Value));
					num21 = Conversions.ToDouble(Operators.AddObject((object)num21, ((DataGridView)dGV)[27, DC_Main.R].Value));
					num22 = Conversions.ToDouble(Operators.AddObject((object)num22, ((DataGridView)dGV)[28, DC_Main.R].Value));
					num23 = Conversions.ToDouble(Operators.AddObject((object)num23, ((DataGridView)dGV)[25, DC_Main.R].Value));
					num24++;
				}
				dGV = null;
				DC_Main.R++;
			}
			((DataGridView)DGV_ITEM).Rows.Add();
			((DataGridView)DGV_ITEM).Rows.Add();
			num24++;
			((DataGridView)DGV_ITEM)[4, num24].Value = "Bill Total :";
			((DataGridView)DGV_ITEM)[5, num24].Value = num2;
			((DataGridView)DGV_ITEM)[6, num24].Value = num3;
			((DataGridView)DGV_ITEM)[7, num24].Value = num4;
			((DataGridView)DGV_ITEM)[8, num24].Value = num5;
			((DataGridView)DGV_ITEM)[9, num24].Value = num6;
			((DataGridView)DGV_ITEM)[10, num24].Value = num7;
			((DataGridView)DGV_ITEM)[11, num24].Value = num8;
			((DataGridView)DGV_ITEM)[12, num24].Value = num9;
			((DataGridView)DGV_ITEM)[13, num24].Value = num10;
			((DataGridView)DGV_ITEM)[14, num24].Value = num11;
			((DataGridView)DGV_ITEM)[15, num24].Value = num12;
			((DataGridView)DGV_ITEM)[16, num24].Value = num13;
			((DataGridView)DGV_ITEM)[17, num24].Value = num14;
			((DataGridView)DGV_ITEM)[18, num24].Value = num15;
			((DataGridView)DGV_ITEM)[23, num24].Value = num16;
			((DataGridView)DGV_ITEM)[19, num24].Value = num17;
			((DataGridView)DGV_ITEM)[20, num24].Value = num18;
			((DataGridView)DGV_ITEM)[24, num24].Value = num19;
			((DataGridView)DGV_ITEM)[25, num24].Value = num23;
			((DataGridView)DGV_ITEM)[26, num24].Value = num20;
			((DataGridView)DGV_ITEM)[27, num24].Value = num21;
			((DataGridView)DGV_ITEM)[28, num24].Value = num22;
		}
	}

	private void DGV_ITEM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 315:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0029;
						case 5:
							goto IL_009f;
						case 6:
							goto IL_00b0;
						case 7:
							goto IL_00d1;
						case 8:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 4:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_009f:
					num2 = 5;
					if (((ConvertEventArgs)e).Value == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_00b0;
					IL_00b0:
					num2 = 6;
					if (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00d1;
					IL_0029:
					num2 = 3;
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					case 23:
					case 24:
					case 28:
						break;
					default:
						goto end_IL_0001_3;
					}
					goto IL_009f;
					IL_00d1:
					num2 = 7;
					((ConvertEventArgs)e).Value = "";
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DgvRptType, "BillWise", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0029;
					end_IL_0001_2:
					break;
				}
				num2 = 8;
				e.FormattingApplied = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 315;
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

	private void DGV_ITEM_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV_ITEM).Rows[((DataGridViewBand)((DataGridView)DGV_ITEM).CurrentRow).Index].Cells[31].Value), (object)""), (object)"' "));
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
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL2 = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL2).Show();
			((Control)tR_TAG_OPBL2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "STOCK ADJUST", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN2).Show();
			((Control)tR_TAG_CAN2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "APR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON ISU", false) == 0))
		{
			TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
			((Form)tR_APR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU).Show();
			((Control)tR_APR_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "APR RTN", false) == 0)
		{
			TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
			((Form)tR_APR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU2).Show();
			((Control)tR_APR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
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
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
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
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
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
			TR_TAG_CAN tR_TAG_CAN3 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN3).Show();
			((Control)tR_TAG_CAN3).Focus();
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
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
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
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				((Control)BtnBillWise).Focus();
			}
		}
		else
		{
			((Control)BtnBillWise).Focus();
		}
	}

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.BOOK_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[3];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tBookCode.Text = DC_Main.ColValue[1];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				((Control)BtnBillWise).Focus();
			}
		}
		else
		{
			((Control)BtnBillWise).Focus();
		}
	}

	private void BookMast()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.CO_BOOK,A.BOOK_NAME FROM BOOK_DATA  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.MAIN_BOOK IN ('SALES','WH SALES')  ORDER BY A.MAIN_BOOK,A.CO_BOOK ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV_ITM).Rows.Count <= 0)
			{
				DataGridViewX dGV_ITM = DGV_ITM;
				((DataGridView)dGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV_ITM).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV_ITM).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV_ITM).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "CO_BOOK");
				((DataGridView)dGV_ITM).Columns[1].Width = 50;
				((DataGridView)dGV_ITM).Columns.Add("", "BOOK_NAME");
				((DataGridView)dGV_ITM).Columns[2].Width = 250;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV_ITM).Rows.Add();
					((DataGridView)dGV_ITM)[1, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["CO_BOOK"]);
					((DataGridView)dGV_ITM)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["BOOK_NAME"]);
					DC_Main.i++;
				}
				dGV_ITM = null;
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		if (!chkBookSelect.Checked)
		{
			return;
		}
		ScelectBook = "";
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false) && chkBookSelect.Checked)
				{
					ScelectBook = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(ScelectBook + "'"), ((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells[1].Value), (object)"',"));
				}
				DC_Main.M++;
			}
			if (chkBookSelect.Checked)
			{
				if (Operators.CompareString(ScelectBook, "", false) == 0)
				{
					Interaction.MsgBox((object)"Book Selection Not Done...", (MsgBoxStyle)0, (object)null);
					((Control)PnlIt).Visible = false;
				}
				else
				{
					ScelectBook = Strings.Mid(ScelectBook, 1, Strings.Len(ScelectBook) - 1);
					Interaction.MsgBox((object)"Book Selection is Ok...", (MsgBoxStyle)0, (object)null);
					((Control)PnlIt).Visible = false;
				}
			}
		}
	}

	private void chkBookSelect_Click(object sender, EventArgs e)
	{
		if (chkBookSelect.Checked)
		{
			((Control)PnlIt).Visible = true;
		}
		else
		{
			((Control)PnlIt).Visible = false;
		}
	}

	private void BtnItCancel_Click(object sender, EventArgs e)
	{
		((Control)PnlIt).Visible = false;
		ScelectBook = "";
	}

	private void tCounterCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND TABLE_CODE = '" + tCounterCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT TABLE_CODE as CodeL,TABLE_NAME As CounterL FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY TABLE_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tCounterCode.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tCounterCode).SelectAll();
			}
		}
		else
		{
			BtnTagWise_Click(BtnTagWise, new EventArgs());
		}
	}

	private void DGV_DATE_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}
}
