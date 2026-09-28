using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
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
public class RP_DHRN_OS : Form
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
	[AccessedThroughProperty("BtnJmaUdhar")]
	private SimpleButton _BtnJmaUdhar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkIntType")]
	private CheckBox _chkIntType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEmp")]
	private ComboBox _cboEmp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkInt")]
	private CheckBox _chkInt;

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
	[AccessedThroughProperty("tPacketNo")]
	private TextBox _tPacketNo;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string[] ArySchmCode;

	private string[] AryEmpCode;

	private string CurIntTypeCalc;

	private bool FormLoad;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cAcName = 1;

	private const int cIsuNo = 2;

	private const int cDhrnIsuDt = 3;

	private const int cDhrnNo = 4;

	private const int cItWt = 5;

	private const int cDhrnAmt = 6;

	private const int cDhrnRec = 7;

	private const int cUnchakRec = 8;

	private const int cPanDhrn = 9;

	private const int cFromDate = 10;

	private const int cIntDays = 11;

	private const int cIntMonth = 12;

	private const int cIntPrc = 13;

	private const int cIntAmt = 14;

	private const int cOldIntAmt = 15;

	private const int cOldIntRec = 16;

	private const int cIntKasar = 17;

	private const int cPanInt = 18;

	private const int cTotPan = 19;

	private const int cItDesc = 20;

	private const int cOldIsu = 21;

	private const int cAcCode = 22;

	private const int cIsuYrCd = 23;

	private const int cIsuDbCd = 24;

	private const int cIntType = 25;

	private const int cIntYear = 26;

	private const int cCashRec = 27;

	private const int c1SrNo = 0;

	private const int c1AcName = 1;

	private const int c1Mobile = 2;

	private const int c1IsuNo = 3;

	private const int c1Packet = 4;

	private const int c1DhrnIsuDt = 5;

	private const int c1IsuMonth = 6;

	private const int c1IntMonth = 7;

	private const int c1ItDesc = 8;

	private const int c1ItWt = 9;

	private const int c1GlFine = 10;

	private const int c1SlFine = 11;

	private const int c1OrnaAmt = 12;

	private const int c1DhrnAmt = 13;

	private const int c1TotPan = 14;

	private const int c1DhrnRec = 15;

	private const int c1PanDhrn = 16;

	private const int c1PanInt = 17;

	private const int c1IntAmt = 18;

	private const int c1OldIntAmt = 19;

	private const int c1OldIntRec = 20;

	private const int c1FromDate = 21;

	private const int c1IntDays = 22;

	private const int c1IntPrc = 23;

	private const int c1OldIsu = 24;

	private const int c1AcCode = 25;

	private const int c1IsuYrCd = 26;

	private const int c1IsuDbCd = 27;

	private const int c1DhrnNo = 28;

	private const int c1IntType = 29;

	private const int c1IntYear = 30;

	private const int c1CashRec = 31;

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

	internal virtual SimpleButton BtnJmaUdhar
	{
		[CompilerGenerated]
		get
		{
			return _BtnJmaUdhar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnJmaUdhar_Click;
			SimpleButton val = _BtnJmaUdhar;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnJmaUdhar = value;
			val = _BtnJmaUdhar;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual ComboBox cboArea
	{
		[CompilerGenerated]
		get
		{
			return _cboArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboArea_KeyDown);
			ComboBox val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboArea = value;
			val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label17")]
	private virtual Label _Label17;

	internal virtual Label Label17
	{
		get
		{
			return _Label17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label17 = value;
		}
	}

	internal virtual ComboBox cboCity
	{
		[CompilerGenerated]
		get
		{
			return _cboCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCity_KeyDown);
			ComboBox val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCity = value;
			val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCity")]
	private virtual Label _lblCity;

	internal virtual Label lblCity
	{
		get
		{
			return _lblCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCity = value;
		}
	}

	internal virtual CheckBox chkIntType
	{
		[CompilerGenerated]
		get
		{
			return _chkIntType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkIntType_KeyDown);
			EventHandler eventHandler = chkIntType_CheckedChanged;
			CheckBox val2 = _chkIntType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.CheckedChanged -= eventHandler;
			}
			_chkIntType = value;
			val2 = _chkIntType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboEmp
	{
		[CompilerGenerated]
		get
		{
			return _cboEmp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboEmp_KeyDown);
			ComboBox val2 = _cboEmp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboEmp = value;
			val2 = _cboEmp;
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
			EventHandler eventHandler = btnOk_Click;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_CellContentClick);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((DataGridView)val3).CellContentClick -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((DataGridView)val3).CellContentClick += val2;
				((Control)val3).DoubleClick += eventHandler;
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

	internal virtual CheckBox chkInt
	{
		[CompilerGenerated]
		get
		{
			return _chkInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = ChkInt_CheckedChanged;
			KeyEventHandler val = new KeyEventHandler(chkInt_KeyDown);
			CheckBox val2 = _chkInt;
			if (val2 != null)
			{
				val2.CheckedChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_chkInt = value;
			val2 = _chkInt;
			if (val2 != null)
			{
				val2.CheckedChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLoanType")]
	private virtual ComboBox _cboLoanType;

	internal virtual ComboBox cboLoanType
	{
		get
		{
			return _cboLoanType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboLoanType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLoanType")]
	private virtual Label _lblLoanType;

	internal virtual Label lblLoanType
	{
		get
		{
			return _lblLoanType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLoanType = value;
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
	[AccessedThroughProperty("nSlRate")]
	private virtual TextBox _nSlRate;

	internal virtual TextBox nSlRate
	{
		get
		{
			return _nSlRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nSlRate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGlRate")]
	private virtual TextBox _nGlRate;

	internal virtual TextBox nGlRate
	{
		get
		{
			return _nGlRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nGlRate = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlPacket")]
	private virtual Panel _pnlPacket;

	internal virtual Panel pnlPacket
	{
		get
		{
			return _pnlPacket;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlPacket = value;
		}
	}

	internal virtual TextBox tPacketNo
	{
		[CompilerGenerated]
		get
		{
			return _tPacketNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPacketNo_KeyDown);
			TextBox val2 = _tPacketNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPacketNo = value;
			val2 = _tPacketNo;
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
	[AccessedThroughProperty("chkOverValue")]
	private virtual CheckBox _chkOverValue;

	internal virtual CheckBox chkOverValue
	{
		get
		{
			return _chkOverValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOverValue = value;
		}
	}

	public int newindex { get; set; }

	public RP_DHRN_OS()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += RP_DHRN_OS_Load;
		((Form)this).Activated += RP_DHRN_OS_Activated;
		((Form)this).Deactivate += RP_DHRN_OS_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_DHRN_OS_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_DHRN_OS_KeyDown);
		((Form)this).Closed += RP_DHRN_OS_Closed;
		CurIntTypeCalc = "";
		FormLoad = false;
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
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Expected O, but got Unknown
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Expected O, but got Unknown
		//IL_08ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f7: Expected O, but got Unknown
		//IL_095a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0964: Expected O, but got Unknown
		//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a57: Expected O, but got Unknown
		//IL_0ac5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acf: Expected O, but got Unknown
		//IL_0e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e72: Expected O, but got Unknown
		//IL_0eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Expected O, but got Unknown
		//IL_0f9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa9: Expected O, but got Unknown
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_103e: Expected O, but got Unknown
		//IL_10bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c5: Expected O, but got Unknown
		//IL_1162: Unknown result type (might be due to invalid IL or missing references)
		//IL_116c: Expected O, but got Unknown
		//IL_121a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1224: Expected O, but got Unknown
		//IL_12bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c5: Expected O, but got Unknown
		//IL_1365: Unknown result type (might be due to invalid IL or missing references)
		//IL_136f: Expected O, but got Unknown
		//IL_13de: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e8: Expected O, but got Unknown
		//IL_14b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bd: Expected O, but got Unknown
		//IL_156c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1576: Expected O, but got Unknown
		//IL_1621: Unknown result type (might be due to invalid IL or missing references)
		//IL_162b: Expected O, but got Unknown
		//IL_16a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ac: Expected O, but got Unknown
		//IL_1767: Unknown result type (might be due to invalid IL or missing references)
		//IL_1771: Expected O, but got Unknown
		//IL_1806: Unknown result type (might be due to invalid IL or missing references)
		//IL_1810: Expected O, but got Unknown
		//IL_188e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1898: Expected O, but got Unknown
		//IL_197a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1984: Expected O, but got Unknown
		//IL_19ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f7: Expected O, but got Unknown
		//IL_1cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4b: Expected O, but got Unknown
		//IL_1d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e16: Expected O, but got Unknown
		//IL_1e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9d: Expected O, but got Unknown
		//IL_1f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f82: Expected O, but got Unknown
		//IL_200c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2016: Expected O, but got Unknown
		//IL_20f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fb: Expected O, but got Unknown
		//IL_2178: Unknown result type (might be due to invalid IL or missing references)
		//IL_2182: Expected O, but got Unknown
		//IL_224d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2257: Expected O, but got Unknown
		//IL_231f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2329: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_DHRN_OS));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnJmaUdhar = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		PnlAcSumm = new Panel();
		pnlPacket = new Panel();
		tPacketNo = new TextBox();
		Label4 = new Label();
		nSlRate = new TextBox();
		nGlRate = new TextBox();
		Label8 = new Label();
		Label1 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		cboLoanType = new ComboBox();
		lblLoanType = new Label();
		chkInt = new CheckBox();
		Label2 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		DGV = new DataGridViewX();
		btnOk = new QButton();
		cboEmp = new ComboBox();
		Label3 = new Label();
		cboArea = new ComboBox();
		Label17 = new Label();
		cboCity = new ComboBox();
		lblCity = new Label();
		chkIntType = new CheckBox();
		chkOverValue = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((Control)pnlPacket).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnJmaUdhar);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 1;
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
		((Control)BtnExit).TabIndex = 7;
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
		((Control)BtnDelete).TabIndex = 6;
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
		((Control)BtnCancel).TabIndex = 5;
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
		((Control)BtnSave).TabIndex = 4;
		BtnSave.Text = "&Excel";
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
		((Control)BtnPrint).TabIndex = 3;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnPrint).Visible = false;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnJmaUdhar.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnJmaUdhar.ImageOptions.SvgImage");
		((Control)BtnJmaUdhar).Location = new Point(730, 3);
		((BaseControl)BtnJmaUdhar).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnJmaUdhar).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnJmaUdhar).Name = "BtnJmaUdhar";
		((Control)BtnJmaUdhar).Size = new Size(91, 37);
		((Control)BtnJmaUdhar).TabIndex = 10;
		BtnJmaUdhar.Text = "&JmUdr";
		((BaseButton)BtnJmaUdhar).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnJmaUdhar).Visible = false;
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
		lblBook.Text = "Dhran Intrest Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkOverValue);
		((Control)PnlAcSumm).Controls.Add((Control)(object)pnlPacket);
		((Control)PnlAcSumm).Controls.Add((Control)(object)nSlRate);
		((Control)PnlAcSumm).Controls.Add((Control)(object)nGlRate);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label8);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mToDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mFromDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboLoanType);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblLoanType);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkInt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label2);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcName);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV);
		((Control)PnlAcSumm).Controls.Add((Control)(object)btnOk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboEmp);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboArea);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label17);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkIntType);
		((Control)PnlAcSumm).Location = new Point(0, 33);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 530);
		((Control)PnlAcSumm).TabIndex = 0;
		((Control)pnlPacket).Controls.Add((Control)(object)tPacketNo);
		((Control)pnlPacket).Controls.Add((Control)(object)Label4);
		((Control)pnlPacket).Location = new Point(692, 0);
		((Control)pnlPacket).Name = "pnlPacket";
		((Control)pnlPacket).Size = new Size(256, 37);
		((Control)pnlPacket).TabIndex = 1288;
		((Control)pnlPacket).Visible = false;
		((TextBoxBase)tPacketNo).BackColor = Color.White;
		((Control)tPacketNo).Font = new Font("Tahoma", 9f);
		((Control)tPacketNo).Location = new Point(77, 8);
		((TextBoxBase)tPacketNo).MaxLength = 10;
		((Control)tPacketNo).Name = "tPacketNo";
		((Control)tPacketNo).Size = new Size(79, 22);
		((Control)tPacketNo).TabIndex = 1287;
		tPacketNo.TextAlign = (HorizontalAlignment)1;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(5, 7);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(68, 20);
		((Control)Label4).TabIndex = 1288;
		Label4.Text = "Packet No";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nSlRate).BackColor = Color.White;
		((Control)nSlRate).Font = new Font("Tahoma", 9f);
		((Control)nSlRate).Location = new Point(854, 42);
		((TextBoxBase)nSlRate).MaxLength = 6;
		((Control)nSlRate).Name = "nSlRate";
		((Control)nSlRate).Size = new Size(79, 22);
		((Control)nSlRate).TabIndex = 1287;
		nSlRate.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nGlRate).BackColor = Color.White;
		((Control)nGlRate).Font = new Font("Tahoma", 9f);
		((Control)nGlRate).Location = new Point(769, 42);
		((TextBoxBase)nGlRate).MaxLength = 6;
		((Control)nGlRate).Name = "nGlRate";
		((Control)nGlRate).Size = new Size(79, 22);
		((Control)nGlRate).TabIndex = 1285;
		nGlRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(687, 42);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(75, 20);
		((Control)Label8).TabIndex = 1286;
		Label8.Text = "Rate G / S";
		Label8.TextAlign = (ContentAlignment)64;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(32, 10);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(44, 20);
		((Control)Label1).TabIndex = 1284;
		Label1.Text = "Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(164, 11);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(82, 11);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		cboLoanType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboLoanType).Font = new Font("Tahoma", 9f);
		((ListControl)cboLoanType).FormattingEnabled = true;
		((Control)cboLoanType).Location = new Point(776, 10);
		((Control)cboLoanType).Name = "cboLoanType";
		((Control)cboLoanType).Size = new Size(137, 22);
		((Control)cboLoanType).TabIndex = 6;
		((Control)lblLoanType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLoanType).ForeColor = Color.Black;
		lblLoanType.ImeMode = (ImeMode)0;
		((Control)lblLoanType).Location = new Point(690, 11);
		((Control)lblLoanType).Name = "lblLoanType";
		((Control)lblLoanType).Size = new Size(79, 20);
		((Control)lblLoanType).TabIndex = 1281;
		lblLoanType.Text = "Loan Type";
		lblLoanType.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkInt).BackColor = Color.Transparent;
		chkInt.Checked = true;
		chkInt.CheckState = (CheckState)1;
		((Control)chkInt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkInt).ForeColor = Color.Navy;
		((Control)chkInt).Location = new Point(954, 28);
		((Control)chkInt).Name = "chkInt";
		((Control)chkInt).RightToLeft = (RightToLeft)0;
		((Control)chkInt).Size = new Size(141, 19);
		((Control)chkInt).TabIndex = 8;
		((ButtonBase)chkInt).Text = "With Compund Intrest";
		((ButtonBase)chkInt).UseVisualStyleBackColor = false;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(11, 45);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(65, 20);
		((Control)Label2).TabIndex = 1148;
		Label2.Text = "Ac Code";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(82, 43);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 22);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(164, 43);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(284, 23);
		((Control)tAcName).TabIndex = 1147;
		((Control)DGV).AllowDrop = true;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToOrderColumns = true;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 25;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(13, 76);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 10;
		val5.Font = new Font("Calibri", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1161, 443);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1145;
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(1101, 25);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(73, 37);
		((Control)btnOk).TabIndex = 9;
		btnOk.Text = "Ok";
		cboEmp.AutoCompleteMode = (AutoCompleteMode)3;
		cboEmp.AutoCompleteSource = (AutoCompleteSource)256;
		cboEmp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboEmp).Font = new Font("Tahoma", 9f);
		((ListControl)cboEmp).FormattingEnabled = true;
		((Control)cboEmp).Location = new Point(522, 42);
		((Control)cboEmp).Name = "cboEmp";
		((Control)cboEmp).Size = new Size(160, 22);
		((Control)cboEmp).TabIndex = 5;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(452, 43);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(64, 19);
		((Control)Label3).TabIndex = 1144;
		Label3.Text = "Employ";
		Label3.TextAlign = (ContentAlignment)64;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(522, 10);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(160, 22);
		((Control)cboArea).TabIndex = 4;
		((Control)cboArea).UseWaitCursor = true;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(471, 12);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(46, 19);
		((Control)Label17).TabIndex = 1140;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(295, 11);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(153, 22);
		((Control)cboCity).TabIndex = 3;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(250, 11);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(37, 19);
		((Control)lblCity).TabIndex = 1138;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkIntType).BackColor = Color.Transparent;
		chkIntType.Checked = true;
		chkIntType.CheckState = (CheckState)1;
		((Control)chkIntType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkIntType).ForeColor = Color.Navy;
		((Control)chkIntType).Location = new Point(954, 4);
		((Control)chkIntType).Name = "chkIntType";
		((Control)chkIntType).RightToLeft = (RightToLeft)0;
		((Control)chkIntType).Size = new Size(141, 20);
		((Control)chkIntType).TabIndex = 7;
		((ButtonBase)chkIntType).Text = "Only Panding";
		((ButtonBase)chkIntType).UseVisualStyleBackColor = false;
		((ButtonBase)chkOverValue).BackColor = Color.Transparent;
		chkOverValue.Checked = true;
		chkOverValue.CheckState = (CheckState)1;
		((Control)chkOverValue).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOverValue).ForeColor = Color.Navy;
		((Control)chkOverValue).Location = new Point(954, 52);
		((Control)chkOverValue).Name = "chkOverValue";
		((Control)chkOverValue).RightToLeft = (RightToLeft)0;
		((Control)chkOverValue).Size = new Size(139, 19);
		((Control)chkOverValue).TabIndex = 1289;
		((ButtonBase)chkOverValue).Text = "Only Over Valued";
		((ButtonBase)chkOverValue).UseVisualStyleBackColor = false;
		((Control)this).AccessibleRole = (AccessibleRole)0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_DHRN_OS";
		((Form)this).Text = "Dhiran / Loan Os Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((Control)pnlPacket).ResumeLayout(false);
		((Control)pnlPacket).PerformLayout();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
	}

	private void DGV_DHRN_DUE()
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		DateTime dateTime = Conversions.ToDate(Strings.Format((object)DateAndTime.Today, "dd/MM/yyyy"));
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
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV).Columns[0].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Party Name");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(170.0 * ColCon);
			((DataGridView)DGV).Columns[1].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Mobile");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "VchNo");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Packt");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "VchDate");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "DMnth");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "Month");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "It Desc");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(160.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "GrWt");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "GFine");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SFine");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "OrnaAmt");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "DhrnAmt");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotPan");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "DhrnRec");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "PanDhrn");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "PanInt");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "IntAmt");
			((DataGridView)DGV).Columns[18].Visible = false;
			((DataGridView)DGV).Columns.Add("", "OldIntAmt");
			((DataGridView)DGV).Columns[19].Visible = false;
			((DataGridView)DGV).Columns.Add("", "OldIntRec");
			((DataGridView)DGV).Columns[20].Visible = false;
			((DataGridView)DGV).Columns.Add("", "LastRec");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "IntDay");
			((DataGridView)DGV).Columns[22].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IntPrc");
			((DataGridView)DGV).Columns[23].Visible = false;
			((DataGridView)DGV).Columns.Add("", "c1OldIsu");
			((DataGridView)DGV).Columns[24].Visible = false;
			((DataGridView)DGV).Columns.Add("", "AcCode");
			((DataGridView)DGV).Columns[25].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IsuYrCd");
			((DataGridView)DGV).Columns[26].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IsuDbCd");
			((DataGridView)DGV).Columns[27].Visible = false;
			((DataGridView)DGV).Columns.Add("", "DhrnNo");
			((DataGridView)DGV).Columns[28].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IntType");
			((DataGridView)DGV).Columns[29].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IntYear");
			((DataGridView)DGV).Columns[30].Visible = false;
			((DataGridView)DGV).Columns.Add("", "CashRec");
			((DataGridView)DGV).Columns[31].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,C.AC_MOBILE,A.VCH_NO,A.PACKET_NO,A.DHRN_BILL,A.CO_YEAR,A.CO_BOOK,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,A.GOLD_WT,A.GOLD_DESC,B.ISU_LC,B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,SUM(B.DHRN_REC_AMT) AS DHRN_REC_AMT,SUM(B.UNCHAK_DHRN_REC) AS UNCHAK_REC,A.OLD_ISU_NO,A.DHRN_MONTH  FROM ((DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.ISU_LC AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LOAN_TYPE = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "' AND A.ENTRY_TYPE = 'D' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" AND A.AC_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPacketNo.Text, "", false) == 0, (object)"", (object)(" AND A.PACKET_NO = '" + tPacketNo.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" And A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY  A.AC_CODE,A.AC_NAME,C.AC_MOBILE,A.VCH_NO,A.PACKET_NO,A.DHRN_BILL,A.CO_YEAR,A.CO_BOOK,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,A.GOLD_WT,A.GOLD_DESC,B.ISU_LC,B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,A.OLD_ISU_NO,A.DHRN_MONTH HAVING SUM(A.DHRN_AMT) - SUM(B.DHRN_REC_AMT) > 0  ORDER BY A.VCH_DATE "));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			int num12 = 0;
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				return;
			}
			int num13 = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num13)
			{
				DataGridViewX dGV = DGV;
				num2 = 0.0;
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[0, num12].Value = num12 + 1;
				((DataGridView)dGV)[25, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]);
				((DataGridView)dGV)[1, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_NAME"]);
				((DataGridView)dGV)[2, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_MOBILE"]);
				((DataGridView)dGV)[3, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]);
				((DataGridView)dGV)[4, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["PACKET_NO"]);
				((DataGridView)dGV)[6, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_MONTH"]);
				((DataGridView)dGV)[28, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_BILL"]);
				((DataGridView)dGV)[26, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]);
				((DataGridView)dGV)[27, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]);
				((DataGridView)dGV)[5, num12].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[13, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"])), "0.000");
				}
				else
				{
					((DataGridView)dGV)[13, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"])), "0.00");
				}
				((DataGridView)dGV)[9, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GOLD_WT"])), "0.000");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_YEAR,A.CO_BOOK,A.VCH_NO,SUM(CASE WHEN A.IT_TYPE = 'G' THEN A.ITM_FINE ELSE 0 END) AS GlFine,SUM(CASE WHEN A.IT_TYPE = 'S' THEN A.ITM_FINE ELSE 0 END) AS SlFine FROM  DHRN_ISU_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' GROUP BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				double num14 = 0.0;
				if (dataTable.Rows.Count > 0)
				{
					((DataGridView)dGV)[10, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GlFine"])), "0.000");
					if (Conversion.Val(nGlRate.Text) != 0.0)
					{
						num14 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num12].Value)) * (Conversion.Val(nGlRate.Text) / 10.0);
					}
					((DataGridView)dGV)[11, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SlFine"])), "0.000");
					if (Conversion.Val(nSlRate.Text) != 0.0)
					{
						num14 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num12].Value)) * (Conversion.Val(nSlRate.Text) / 10.0);
					}
					((DataGridView)dGV)[12, num12].Value = Strings.Format((object)num14, "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,SUM(A.INT_AMT) AS IntAmt,SUM(A.INT_REC_AMT) As IntRec,SUM(A.DHRN_REC_AMT) As DhrnRec,SUM(A.UNCHAK_DHRN_REC) As UnchakRec FROM  DHRN_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND A.ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' GROUP BY A.AC_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO"));
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (cboLoanType.SelectedIndex != 0)
					{
						((DataGridView)dGV)[19, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntAmt"])), "0.000");
						((DataGridView)dGV)[20, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntRec"])), "0.000");
						((DataGridView)dGV)[15, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DhrnRec"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UnchakRec"]))), "0.000");
					}
					else
					{
						((DataGridView)dGV)[19, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntAmt"])), "0.00");
						((DataGridView)dGV)[20, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntRec"])), "0.00");
						((DataGridView)dGV)[15, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DhrnRec"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UnchakRec"]))), "0.00");
					}
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[16, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num12].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num12].Value))), "0.000");
				}
				else
				{
					((DataGridView)dGV)[16, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num12].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num12].Value))), "0.00");
					if (!Operators.ConditionalCompareObjectEqual(((DataGridView)dGV)[16, num12].Value, (object)0, false))
					{
					}
				}
				num = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'  AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'  ORDER BY TO_DATE DESC"));
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				dateTime = ((dataTable2.Rows.Count <= 0) ? Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy")) : Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TO_DATE"]), "dd/MM/yyyy")));
				((DataGridView)dGV)[21, num12].Value = Strings.Format((object)dateTime, "dd/MM/yyyy");
				if (Operators.CompareString(CurIntTypeCalc, "M", false) == 0)
				{
					if (Operators.CompareString(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 1, 2), false) >= 0)
					{
						DateTime dateTime2 = ((Operators.CompareString(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2), "31", false) == 0) ? (((Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "04", false) == 0) | (Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "06", false) == 0) | (Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "09", false) == 0) | (Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "11", false) == 0)) ? Conversions.ToDate(string.Concat(Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(dateTime), 1, 2)) - 1.0) + "/" + Strings.Mid(Conversions.ToString(Conversions.ToDate(mToDt.Text)), 4, 2), Strings.Mid(Conversions.ToString(Conversions.ToDate(mToDt.Text)), 6, 8))) : ((!((Conversion.Val(Strings.Mid(mToDt.Text, 4, 2)) == 2.0) & (Conversion.Val(Strings.Mid(Strings.Format((object)dateTime.AddDays(-1.0), "dd/MM/yyyy"), 1, 2)) >= 28.0))) ? Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2) + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 3, 3), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8))) : Conversions.ToDate(string.Concat(Conversions.ToString(28) + "/" + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8))))) : ((!((Conversion.Val(Strings.Mid(mToDt.Text, 4, 2)) == 2.0) & (Conversion.Val(Strings.Mid(Strings.Format((object)dateTime.AddDays(-1.0), "dd/MM/yyyy"), 1, 2)) >= 28.0))) ? Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2) + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 3, 3), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8))) : Conversions.ToDate(string.Concat(Conversions.ToString(28) + "/" + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8)))));
						num = ((DateTime.Compare(dateTime2, dateTime) > 0) ? ((int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, dateTime2, dateTime, (FirstDayOfWeek)1, (FirstWeekOfYear)1))) : 0);
					}
					else
					{
						DateTime dateTime2 = (((Conversions.ToDouble(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2)) + 1.0 == Conversions.ToDouble("02")) & (Operators.CompareString(Strings.Format((object)Strings.Mid(Conversions.ToString(dateTime), 1, 2), "00"), "29", false) == 0)) ? Conversions.ToDate(Conversions.ToString(Conversion.Val(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) + 1.0) + "/" + Conversions.ToString(Conversion.Val(Strings.Mid(mToDt.Text, 4, 2))) + "/" + Strings.Mid(mToDt.Text, 7, 4)) : ((Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(Conversions.ToString(Conversions.ToDate(mToDt.Text)), 4, 2)) + 1.0), "00"), "12", false) > 0) ? Conversions.ToDate(Conversions.ToString(Conversion.Val(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2))) + "/" + Conversions.ToString(1) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 7, 4)) + 1.0), "0000")) : ((Operators.CompareString(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2), "31", false) == 0) ? (((Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "04", false) == 0) | (Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "06", false) == 0) | (Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "09", false) == 0) | (Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "11", false) == 0)) ? Conversions.ToDate(Conversions.ToString(Conversions.ToDouble(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) - 1.0) + "/" + Strings.Mid(mToDt.Text, 4, 2) + Strings.Mid(mToDt.Text, 6, 8)) : ((Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "02", false) != 0) ? Conversions.ToDate(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)) : Conversions.ToDate(Conversions.ToString(28) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)))) : (((Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0 == Conversions.ToDouble("02")) & (Conversions.ToDouble(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) > 28.0)) ? Conversions.ToDate(Conversions.ToString(28) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)) : (((Conversion.Val(Strings.Mid(mToDt.Text, 4, 2)) == 2.0) & (Conversions.ToDouble(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) > 28.0)) ? Conversions.ToDate(Conversions.ToString(28) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)) : ((DateTime.Compare(Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 3) + Strings.Mid(mToDt.Text, 4, 2), Strings.Mid(mToDt.Text, 6, 8))), Conversions.ToDate(mToDt.Text)) != 0) ? Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 3) + Conversions.ToString(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), Strings.Mid(mToDt.Text, 6, 8))) : Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 3) + Strings.Mid(mToDt.Text, 4, 2), Strings.Mid(mToDt.Text, 6, 8)))))))));
						num = ((DateTime.Compare(DateAndTime.Now, Conversions.ToDate(Strings.Format((object)dateTime, "dd/MM/yyyy"))) >= 0) ? ((int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, dateTime2, dateTime, (FirstDayOfWeek)1, (FirstWeekOfYear)1))) : 0);
					}
					int num15 = 0;
					if (num != 0)
					{
						num15 = (int)Math.Round((double)num / 365.0 * 360.0 / 30.0);
						((DataGridView)dGV)[7, num12].Value = Strings.Format((object)num15, "0");
					}
					if (Conversion.Val((object)num) != 0.0)
					{
						num = num15 * 30;
						double num16 = Conversion.Val((object)num) - Math.Round(Conversion.Val((object)num) / 30.0) * 30.0;
						num = (int)Math.Round(Conversion.Val((object)num) - num16);
					}
					((DataGridView)dGV)[22, num12].Value = Strings.Format((object)num, "0");
					((DataGridView)dGV)[23, num12].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), "0");
					if (num != 0)
					{
						((DataGridView)dGV)[30, num12].Value = Strings.Format((object)(Conversion.Val((object)num) / 365.0), "0.00");
					}
					double num17 = 0.0;
					double num18 = 0.0;
					double num19 = 0.0;
					double num20 = 0.0;
					if (chkInt.Checked)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[30, num12].Value)) > 1.0)
						{
							if (((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[22, num12].Value)) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
							{
								((DataGridView)dGV)[30, num12].Value = Strings.Mid(Conversions.ToString(((DataGridView)dGV)[30, num12].Value), 1, 1);
								num18 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value));
								int num21 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[30, num12].Value)));
								DC_Main.i = 1;
								while (DC_Main.i <= num21)
								{
									num17 = Conversions.ToDouble(Strings.Format((object)Math.Round(num18 * Conversion.Val(Operators.DivideObject(((DataGridView)dGV)[23, num12].Value, (object)100)) / DC_Main.MsIntYearDays * 360.0), "0.00"));
									num20 += num17;
									num18 += num17;
									num19 += 360.0;
									DC_Main.i++;
								}
								num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format((object)Math.Round(num18 * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[23, num12].Value)) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[22, num12].Value)) - num19) + num20), "0.00")) : Conversions.ToDouble(Strings.Format((object)Math.Round(num18 * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[23, num12].Value)) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[22, num12].Value)) - num19) + num20, 3), "0.000")));
							}
						}
						else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), (object)0, false), (object)(num > 0))) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
								0
							}, (string[])null, (Type[])null, (bool[])null)), "0.00")) : Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
								3
							}, (string[])null, (Type[])null, (bool[])null)), "0.000")));
						}
					}
					else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), (object)0, false), (object)(num > 0))))
					{
						num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							0
						}, (string[])null, (Type[])null, (bool[])null)), "0.00")) : Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							3
						}, (string[])null, (Type[])null, (bool[])null)), "0.000")));
					}
				}
				else
				{
					num = (int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDt.Text), dateTime, (FirstDayOfWeek)1, (FirstWeekOfYear)1));
					((DataGridView)dGV)[22, num12].Value = Strings.Format((object)num, "0");
					((DataGridView)dGV)[23, num12].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), "0.00");
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), (object)0, false), (object)(num > 0))))
					{
						num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							0
						}, (string[])null, (Type[])null, (bool[])null)), "0.00")) : Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							3
						}, (string[])null, (Type[])null, (bool[])null)), "0.000")));
					}
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[18, num12].Value = Strings.Format((object)num2, "0.000");
				}
				else
				{
					((DataGridView)dGV)[18, num12].Value = Strings.Format((object)num2, "0");
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[17, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[19, num12].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[20, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[31, num12].Value)))), "0.000");
					((DataGridView)dGV)[14, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value))), "0.000");
				}
				else
				{
					((DataGridView)dGV)[17, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[19, num12].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[20, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[31, num12].Value)))), "0");
					((DataGridView)dGV)[14, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value))), "0.00");
				}
				((DataGridView)dGV)[8, num12].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GOLD_DESC"], (object)"");
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[num12]["GOLD_DESC"], (object)""), (object)"", false))
				{
					if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[num12]["VCH_NO"], DC_Main.Rshlp.Rows[DC_Main.M]["OLD_ISU_NO"], false))
					{
						((DataGridView)dGV)[24, num12].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["OLD_ISU_NO"], (object)"");
					}
					else
					{
						((DataGridView)dGV)[24, num12].Value = "";
					}
				}
				else
				{
					((DataGridView)dGV)[24, num12].Value = "";
				}
				if (chkOverValue.Checked)
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num12].Value)) <= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num12].Value)))
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) <= 0.0)
						{
							((DataGridView)DGV).Rows.RemoveAt(num12);
						}
						else
						{
							num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num12].Value));
							num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num12].Value));
							num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value));
							num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value));
							num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[20, num12].Value));
							num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value));
							num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num12].Value));
							num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num12].Value));
							num12++;
						}
					}
					else
					{
						((DataGridView)DGV).Rows.RemoveAt(num12);
					}
				}
				else if (chkIntType.Checked & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) <= 0.0))
				{
					((DataGridView)DGV).Rows.RemoveAt(num12);
				}
				else
				{
					num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num12].Value));
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num12].Value));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value));
					num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[20, num12].Value));
					num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num12].Value));
					num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num12].Value));
					num12++;
				}
				dGV = null;
				Application.DoEvents();
				DC_Main.M++;
			}
			if (((DataGridView)DGV).Rows.Count >= 1)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV).Rows.Add();
					((DataGridView)DGV).Rows.Add();
				}
				int num22 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num22].Cells[1].Value = "Total :";
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)DGV).Rows[num22].Cells[13].Value = Strings.Format((object)num3, "0.00");
					((DataGridView)DGV).Rows[num22].Cells[15].Value = Strings.Format((object)num5, "0.00");
					((DataGridView)DGV).Rows[num22].Cells[16].Value = Strings.Format((object)num7, "0.00");
					((DataGridView)DGV).Rows[num22].Cells[18].Value = Strings.Format((object)num4, "0.00");
					((DataGridView)DGV).Rows[num22].Cells[20].Value = Strings.Format((object)num8, "0.00");
					((DataGridView)DGV).Rows[num22].Cells[17].Value = Strings.Format((object)num9, "0.00");
					((DataGridView)DGV).Rows[num22].Cells[14].Value = Strings.Format((object)num10, "0.00");
				}
				else
				{
					((DataGridView)DGV).Rows[num22].Cells[13].Value = Strings.Format((object)num3, "0");
					((DataGridView)DGV).Rows[num22].Cells[15].Value = Strings.Format((object)num5, "0");
					((DataGridView)DGV).Rows[num22].Cells[16].Value = Strings.Format((object)num7, "0");
					((DataGridView)DGV).Rows[num22].Cells[18].Value = Strings.Format((object)num4, "0");
					((DataGridView)DGV).Rows[num22].Cells[20].Value = Strings.Format((object)num8, "0");
					((DataGridView)DGV).Rows[num22].Cells[17].Value = Strings.Format((object)num9, "0");
					((DataGridView)DGV).Rows[num22].Cells[14].Value = Strings.Format((object)num10, "0");
					((DataGridView)DGV).Rows[num22].Cells[12].Value = Strings.Format((object)num11, "0");
				}
			}
		}
	}

	private void DGV_DHRN_FILL()
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f56: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		DateTime dateTime = Conversions.ToDate(Strings.Format((object)DateAndTime.Today, "dd/MM/yyyy"));
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
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Party Name");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Vch No");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Vch Date");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "RefNo");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "GrWt");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			if (Operators.CompareString(CurRpt, "Intrest All", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "Dhrn Amt");
				((DataGridView)DGV).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "Dhrn Rec");
				((DataGridView)DGV).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "Unchk Rec");
				((DataGridView)DGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "Pan Dhrn");
				((DataGridView)DGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "Loan Amt");
				((DataGridView)DGV).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "Loan Isu");
				((DataGridView)DGV).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "Unchk Isu");
				((DataGridView)DGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV).Columns.Add("", "Pan Loan");
				((DataGridView)DGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			}
			((DataGridView)DGV).Columns.Add("", "From Date");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "IntDay");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV).Columns.Add("", "Month");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N1";
			((DataGridView)DGV).Columns.Add("", "Int%");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "IntAmt");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OldInt");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OldIntRec");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "IntKasar");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "PanInt");
			((DataGridView)DGV).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotPan");
			((DataGridView)DGV).Columns[19].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Remark");
			((DataGridView)DGV).Columns[20].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "OldIsu");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "AcCode");
			((DataGridView)DGV).Columns[22].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IsuYrCd");
			((DataGridView)DGV).Columns[23].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IsuDbCd");
			((DataGridView)DGV).Columns[24].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IntType");
			((DataGridView)DGV).Columns[25].Visible = false;
			((DataGridView)DGV).Columns.Add("", "IntYear");
			((DataGridView)DGV).Columns[26].Visible = false;
			((DataGridView)DGV).Columns.Add("", "CashRec");
			((DataGridView)DGV).Columns[27].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (Operators.CompareString(CurRpt, "Intrest All", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.VCH_NO,A.DHRN_BILL,A.CO_YEAR,A.CO_BOOK,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,A.GOLD_WT,A.GOLD_DESC,B.ISU_LC,B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,SUM(B.DHRN_REC_AMT) AS DHRN_REC_AMT,SUM(B.UNCHAK_DHRN_REC) AS UNCHAK_REC,A.OLD_ISU_NO  FROM (DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.ISU_LC AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LOAN_TYPE = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "' AND A.ENTRY_TYPE = 'D' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" AND A.AC_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY  A.AC_CODE,A.AC_NAME,A.VCH_NO,A.DHRN_BILL,A.CO_YEAR,A.CO_BOOK,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,A.GOLD_WT,A.GOLD_DESC,B.ISU_LC,B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,A.OLD_ISU_NO HAVING SUM(A.DHRN_AMT) - SUM(B.DHRN_REC_AMT) > 0  ORDER BY A.VCH_DATE "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.VCH_NO,A.DHRN_BILL,A.CO_YEAR,A.CO_BOOK,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,A.GOLD_WT,A.GOLD_DESC,B.ISU_LC,B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,SUM(B.DHRN_REC_AMT) AS DHRN_REC_AMT,SUM(B.UNCHAK_DHRN_REC) AS UNCHAK_REC,A.OLD_ISU_NO  FROM (DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.ISU_LC AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LOAN_TYPE = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "' AND A.ENTRY_TYPE = 'L' "), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)(" AND A.AC_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY  A.AC_CODE,A.AC_NAME,A.VCH_NO,A.DHRN_BILL,A.CO_YEAR,A.CO_BOOK,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,A.GOLD_WT,A.GOLD_DESC,B.ISU_LC,B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,A.OLD_ISU_NO HAVING SUM(A.DHRN_AMT) - SUM(B.DHRN_REC_AMT) > 0  ORDER BY A.VCH_DATE "));
			}
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			int num12 = 0;
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				return;
			}
			int num13 = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num13)
			{
				DataGridViewX dGV = DGV;
				num2 = 0.0;
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[0, num12].Value = num12 + 1;
				((DataGridView)dGV)[22, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]);
				((DataGridView)dGV)[1, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["AC_NAME"]);
				((DataGridView)dGV)[2, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]);
				((DataGridView)dGV)[4, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_BILL"]);
				((DataGridView)dGV)[23, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]);
				((DataGridView)dGV)[24, num12].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]);
				((DataGridView)dGV)[3, num12].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[6, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"])), "0.000");
				}
				else
				{
					((DataGridView)dGV)[6, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"])), "0.00");
				}
				((DataGridView)dGV)[5, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GOLD_WT"])), "0.000");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,SUM(A.INT_AMT) AS IntAmt,SUM(A.INT_REC_AMT) As IntRec,SUM(A.DHRN_REC_AMT) As DhrnRec,SUM(A.UNCHAK_DHRN_REC) As UnchakRec FROM  DHRN_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND A.ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' GROUP BY A.AC_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (cboLoanType.SelectedIndex != 0)
					{
						((DataGridView)dGV)[15, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntAmt"])), "0.000");
						((DataGridView)dGV)[16, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntRec"])), "0.000");
						((DataGridView)dGV)[7, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DhrnRec"])), "0.000");
						((DataGridView)dGV)[8, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UnchakRec"])), "0.000");
					}
					else
					{
						((DataGridView)dGV)[15, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntAmt"])), "0.00");
						((DataGridView)dGV)[16, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntRec"])), "0.00");
						((DataGridView)dGV)[7, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DhrnRec"])), "0.00");
						((DataGridView)dGV)[8, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UnchakRec"])), "0.00");
					}
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[9, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, num12].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num12].Value)))), "0.000");
				}
				else
				{
					((DataGridView)dGV)[9, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, num12].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num12].Value)))), "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,SUM(A.KASAR_AMT) AS KasarAmt FROM  DHRN_REC_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND A.ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' GROUP BY A.AC_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO HAVING SUM(A.KASAR_AMT) > 0"));
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (cboLoanType.SelectedIndex != 0)
					{
						((DataGridView)dGV)[17, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["KasarAmt"])), "0.000");
						DataGridViewCell val;
						(val = ((DataGridView)dGV)[16, num12]).Value = Operators.SubtractObject(val.Value, (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value)), "0.000"));
					}
					else
					{
						((DataGridView)dGV)[17, num12].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["KasarAmt"])), "0.00");
						DataGridViewCell val;
						(val = ((DataGridView)dGV)[16, num12]).Value = Operators.SubtractObject(val.Value, (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value)), "0.00"));
					}
				}
				num = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'  AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'  ORDER BY TO_DATE DESC"));
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				dateTime = ((dataTable2.Rows.Count <= 0) ? Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy")) : Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TO_DATE"]), "dd/MM/yyyy")));
				((DataGridView)dGV)[10, num12].Value = Strings.Format((object)dateTime, "dd/MM/yyyy");
				if (Operators.CompareString(CurIntTypeCalc, "M", false) == 0)
				{
					if (Operators.CompareString(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 1, 2), false) >= 0)
					{
						DateTime dateTime2 = ((Operators.CompareString(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2), "31", false) == 0) ? (((Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "04", false) == 0) | (Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "06", false) == 0) | (Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "09", false) == 0) | (Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "11", false) == 0)) ? Conversions.ToDate(string.Concat(Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(dateTime), 1, 2)) - 1.0) + "/" + Strings.Mid(Conversions.ToString(Conversions.ToDate(mToDt.Text)), 4, 2), Strings.Mid(Conversions.ToString(Conversions.ToDate(mToDt.Text)), 6, 8))) : ((!((Operators.CompareString(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), "02", false) == 0) & (Conversion.Val(Strings.Mid(Strings.Format((object)dateTime.AddDays(-1.0), "dd/MM/yyyy"), 1, 2)) >= 28.0))) ? Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2) + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 3, 3), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8))) : Conversions.ToDate(string.Concat(Conversions.ToString(28) + "/" + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8))))) : ((!((Conversion.Val(Strings.Mid(mToDt.Text, 4, 2)) == 2.0) & (Conversion.Val(Strings.Mid(Strings.Format((object)dateTime.AddDays(-1.0), "dd/MM/yyyy"), 1, 2)) >= 28.0))) ? Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2) + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 3, 3), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8))) : Conversions.ToDate(string.Concat(Conversions.ToString(28) + "/" + Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2), Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 6, 8)))));
						num = ((DateTime.Compare(dateTime2, dateTime) > 0) ? ((int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, dateTime2, dateTime, (FirstDayOfWeek)1, (FirstWeekOfYear)1))) : 0);
					}
					else
					{
						DateTime dateTime2 = (((Conversions.ToDouble(Strings.Mid(Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy"), 4, 2)) + 1.0 == Conversions.ToDouble("02")) & (Operators.CompareString(Strings.Format((object)Strings.Mid(Conversions.ToString(dateTime), 1, 2), "00"), "29", false) == 0)) ? Conversions.ToDate(Conversions.ToString(Conversion.Val(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) + 1.0) + "/" + Conversions.ToString(Conversion.Val(Strings.Mid(mToDt.Text, 4, 2))) + "/" + Strings.Mid(mToDt.Text, 7, 4)) : ((Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(Conversions.ToString(Conversions.ToDate(mToDt.Text)), 4, 2)) + 1.0), "00"), "12", false) > 0) ? Conversions.ToDate(Conversions.ToString(Conversion.Val(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2))) + "/" + Conversions.ToString(1) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 7, 4)) + 1.0), "0000")) : ((Operators.CompareString(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2), "31", false) == 0) ? (((Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "04", false) == 0) | (Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "06", false) == 0) | (Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "09", false) == 0) | (Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "11", false) == 0)) ? Conversions.ToDate(Conversions.ToString(Conversions.ToDouble(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) - 1.0) + "/" + Strings.Mid(mToDt.Text, 4, 2) + Strings.Mid(mToDt.Text, 6, 8)) : ((Operators.CompareString(Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00"), "02", false) != 0) ? Conversions.ToDate(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)) : Conversions.ToDate(Conversions.ToString(28) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)))) : (((Conversion.Val(Strings.Mid(mToDt.Text, 4, 2)) + 1.0 == Conversions.ToDouble("02")) & (Conversions.ToDouble(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) > 28.0)) ? Conversions.ToDate(Conversions.ToString(28) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)) : (((Conversion.Val(Strings.Mid(mToDt.Text, 4, 2)) == 2.0) & (Conversions.ToDouble(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 2)) > 28.0)) ? Conversions.ToDate(Conversions.ToString(28) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), "00") + Strings.Mid(mToDt.Text, 6, 8)) : ((DateTime.Compare(Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 3) + Strings.Mid(mToDt.Text, 4, 2), Strings.Mid(mToDt.Text, 6, 8))), Conversions.ToDate(mToDt.Text)) != 0) ? Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 3) + Conversions.ToString(Conversions.ToDouble(Strings.Mid(mToDt.Text, 4, 2)) + 1.0), Strings.Mid(mToDt.Text, 6, 8))) : Conversions.ToDate(string.Concat(Strings.Mid(Strings.Format((object)dateTime, "dd/MM/yyyy"), 1, 3) + Strings.Mid(mToDt.Text, 4, 2), Strings.Mid(mToDt.Text, 6, 8)))))))));
						num = ((DateTime.Compare(DateAndTime.Now, Conversions.ToDate(Strings.Format((object)dateTime, "dd/MM/yyyy"))) >= 0) ? ((int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, dateTime2, dateTime, (FirstDayOfWeek)1, (FirstWeekOfYear)1))) : 0);
					}
					int num14 = 0;
					if (num != 0)
					{
						num14 = (int)Math.Round((double)num / 365.0 * 360.0 / 30.0);
						((DataGridView)dGV)[12, num12].Value = Strings.Format((object)num14, "0");
					}
					if (Conversion.Val((object)num) != 0.0)
					{
						num = num14 * 30;
						double num15 = Conversion.Val((object)num) - Math.Round(Conversion.Val((object)num) / 30.0) * 30.0;
						num = (int)Math.Round(Conversion.Val((object)num) - num15);
					}
					((DataGridView)dGV)[11, num12].Value = Strings.Format((object)num, "0");
					((DataGridView)dGV)[13, num12].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), "0");
					if (num != 0)
					{
						((DataGridView)dGV)[26, num12].Value = Strings.Format((object)(Conversion.Val((object)num) / 365.0), "0.00");
					}
					double num16 = 0.0;
					double num17 = 0.0;
					double num18 = 0.0;
					double num19 = 0.0;
					if (chkInt.Checked)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[26, num12].Value)) > 1.0)
						{
							if (((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num12].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num12].Value)) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
							{
								((DataGridView)dGV)[26, num12].Value = Strings.Mid(Conversions.ToString(((DataGridView)dGV)[26, num12].Value), 1, 1);
								num17 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num12].Value));
								int num20 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[26, num12].Value)));
								DC_Main.i = 1;
								while (DC_Main.i <= num20)
								{
									num16 = Conversions.ToDouble(Strings.Format((object)Math.Round(num17 * Conversion.Val(Operators.DivideObject(((DataGridView)dGV)[13, num12].Value, (object)100)) / DC_Main.MsIntYearDays * 360.0), "0.00"));
									num19 += num16;
									num17 += num16;
									num18 += 360.0;
									DC_Main.i++;
								}
								num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format((object)Math.Round(num17 * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num12].Value)) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num12].Value)) - num18) + num19), "0.00")) : Conversions.ToDouble(Strings.Format((object)Math.Round(num17 * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num12].Value)) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num12].Value)) - num18) + num19, 3), "0.000")));
							}
						}
						else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), (object)0, false), (object)(num > 0))) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
								0
							}, (string[])null, (Type[])null, (bool[])null)), "0.00")) : Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
								3
							}, (string[])null, (Type[])null, (bool[])null)), "0.000")));
						}
					}
					else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), (object)0, false), (object)(num > 0))))
					{
						num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							0
						}, (string[])null, (Type[])null, (bool[])null)), "0.00")) : Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							3
						}, (string[])null, (Type[])null, (bool[])null)), "0.000")));
					}
				}
				else
				{
					num = (int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDt.Text), dateTime, (FirstDayOfWeek)1, (FirstWeekOfYear)1));
					((DataGridView)dGV)[11, num12].Value = Strings.Format((object)num, "0");
					((DataGridView)dGV)[13, num12].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), "0.00");
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), (object)0, false), (object)(num > 0))))
					{
						num2 = ((cboLoanType.SelectedIndex == 0) ? Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							0
						}, (string[])null, (Type[])null, (bool[])null)), "0.00")) : Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(Operators.SubtractObject(DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_AMT"], DC_Main.Rshlp.Rows[DC_Main.M]["DHRN_REC_AMT"]), DC_Main.Rshlp.Rows[DC_Main.M]["INT_PRC"]), (object)100), (object)num), (object)DC_Main.MsIntYearDays),
							3
						}, (string[])null, (Type[])null, (bool[])null)), "0.000")));
					}
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[14, num12].Value = Strings.Format((object)num2, "0.000");
				}
				else
				{
					((DataGridView)dGV)[14, num12].Value = Strings.Format((object)num2, "0");
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)dGV)[18, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num12].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[27, num12].Value)))), "0.000");
					((DataGridView)dGV)[19, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value))), "0.000");
				}
				else
				{
					((DataGridView)dGV)[18, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num12].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[27, num12].Value)))), "0");
					((DataGridView)dGV)[19, num12].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num12].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value))), "0");
				}
				((DataGridView)dGV)[20, num12].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GOLD_DESC"], (object)"");
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[num12]["GOLD_DESC"], (object)""), (object)"", false))
				{
					if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[num12]["VCH_NO"], DC_Main.Rshlp.Rows[DC_Main.M]["OLD_ISU_NO"], false))
					{
						((DataGridView)dGV)[21, num12].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["OLD_ISU_NO"], (object)"");
					}
					else
					{
						((DataGridView)dGV)[21, num12].Value = "";
					}
				}
				else
				{
					((DataGridView)dGV)[21, num12].Value = "";
				}
				if (chkIntType.Checked & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num12].Value)) <= 0.0))
				{
					((DataGridView)DGV).Rows.RemoveAt(num12);
				}
				else
				{
					num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, num12].Value));
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num12].Value));
					num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num12].Value));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num12].Value));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num12].Value));
					num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, num12].Value));
					num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, num12].Value));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[19, num12].Value));
					num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, num12].Value));
					num12++;
				}
				dGV = null;
				Application.DoEvents();
				DC_Main.M++;
			}
			if (((DataGridView)DGV).Rows.Count >= 1)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV).Rows.Add();
					((DataGridView)DGV).Rows.Add();
				}
				int num21 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num21].Cells[1].Value = "Total :";
				if (cboLoanType.SelectedIndex != 0)
				{
					((DataGridView)DGV).Rows[num21].Cells[6].Value = Strings.Format((object)num3, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[7].Value = Strings.Format((object)num5, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[8].Value = Strings.Format((object)num6, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[9].Value = Strings.Format((object)num7, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[14].Value = Strings.Format((object)num4, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[16].Value = Strings.Format((object)num8, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[17].Value = Strings.Format((object)num11, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[18].Value = Strings.Format((object)num9, "0.00");
					((DataGridView)DGV).Rows[num21].Cells[19].Value = Strings.Format((object)num10, "0.00");
				}
				else
				{
					((DataGridView)DGV).Rows[num21].Cells[6].Value = Strings.Format((object)num3, "0");
					((DataGridView)DGV).Rows[num21].Cells[7].Value = Strings.Format((object)num5, "0");
					((DataGridView)DGV).Rows[num21].Cells[8].Value = Strings.Format((object)num6, "0");
					((DataGridView)DGV).Rows[num21].Cells[9].Value = Strings.Format((object)num7, "0");
					((DataGridView)DGV).Rows[num21].Cells[14].Value = Strings.Format((object)num4, "0");
					((DataGridView)DGV).Rows[num21].Cells[16].Value = Strings.Format((object)num8, "0");
					((DataGridView)DGV).Rows[num21].Cells[17].Value = Strings.Format((object)num11, "0");
					((DataGridView)DGV).Rows[num21].Cells[18].Value = Strings.Format((object)num9, "0");
					((DataGridView)DGV).Rows[num21].Cells[19].Value = Strings.Format((object)num10, "0");
				}
			}
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
					ProjectData.ClearProjectError();
					num2 = 2;
					if (((ConvertEventArgs)e).Value == null)
					{
						break;
					}
					switch (e.ColumnIndex)
					{
					case 5:
					case 6:
					case 7:
					case 9:
					case 14:
					case 15:
					case 16:
					case 18:
					case 19:
						if (((ConvertEventArgs)e).Value != null && ((Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0) | (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0.00", false) == 0) | (Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0.000", false) == 0)))
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 8:
					case 10:
					case 11:
					case 12:
					case 13:
					case 17:
						break;
					}
					break;
				case 237:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_0123;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 237;
				continue;
			}
			break;
			IL_0123:
			throw ProjectData.CreateProjectError(-2146828237);
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
		object obj = default(object);
		int num5 = default(int);
		int num6 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num9 = default(int);
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
					case 2008:
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
								goto IL_0120;
							case 13:
								goto IL_0168;
							case 14:
								goto IL_0177;
							case 15:
								goto IL_0194;
							case 16:
								goto IL_01ae;
							case 17:
								goto IL_01d4;
							case 18:
								goto IL_01f1;
							case 20:
								goto IL_0255;
							case 22:
								goto IL_02a3;
							case 24:
								goto IL_0310;
							case 26:
								goto IL_037a;
							case 30:
								goto IL_03de;
							case 19:
							case 21:
							case 23:
							case 25:
							case 27:
							case 28:
							case 29:
							case 31:
							case 32:
								goto IL_041b;
							case 33:
								goto IL_042d;
							case 34:
								goto IL_0448;
							case 35:
								goto IL_0452;
							case 36:
								goto IL_04a5;
							case 37:
								goto IL_04fa;
							case 38:
								goto IL_0552;
							case 39:
								goto IL_05c0;
							case 40:
								goto IL_0603;
							case 41:
								goto IL_0632;
							case 42:
								goto IL_0675;
							case 43:
								goto IL_06b6;
							case 44:
								goto IL_06d7;
							case 45:
								goto IL_06e5;
							case 46:
								goto IL_06eb;
							case 47:
								goto IL_06f1;
							case 48:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 49:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0120:
						num2 = 12;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num5 + 1,
							((DataGridView)DGV).Columns[num5].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_0310:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num6 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV)[num6, DC_Main.i].Value.ToString()), "0.00")
						}, (string[])null, (Type[])null);
						goto IL_041b;
						IL_0168:
						num2 = 13;
						num5++;
						goto IL_0171;
						IL_02a3:
						num2 = 22;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num6 + 1,
							Strings.Format((object)Conversion.Val(((DataGridView)DGV)[num6, DC_Main.i].Value.ToString()), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_041b;
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
						num7 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_0171;
						IL_0171:
						if (num5 <= num7)
						{
							goto IL_0120;
						}
						goto IL_0177;
						IL_0177:
						num2 = 14;
						num8 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_043c;
						IL_043c:
						if (DC_Main.i <= num8)
						{
							goto IL_0194;
						}
						goto IL_0448;
						IL_0448:
						num2 = 34;
						colorConverter = new ColorConverter();
						goto IL_0452;
						IL_0452:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_04a5;
						IL_04a5:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_04fa;
						IL_04fa:
						num2 = 37;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_0552;
						IL_0552:
						num2 = 38;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_05c0;
						IL_05c0:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0603;
						IL_0603:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0632;
						IL_0632:
						num2 = 41;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0675;
						IL_0675:
						num2 = 42;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_06b6;
						IL_06b6:
						num2 = 43;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_06d7;
						IL_06d7:
						num2 = 44;
						Cursor.Current = Cursors.Default;
						goto IL_06e5;
						IL_06e5:
						num2 = 45;
						obj = null;
						goto IL_06eb;
						IL_06eb:
						num2 = 46;
						obj3 = null;
						goto IL_06f1;
						IL_06f1:
						num2 = 47;
						obj2 = null;
						break;
						IL_0194:
						num2 = 15;
						num9 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_0424;
						IL_0424:
						if (num6 <= num9)
						{
							goto IL_01ae;
						}
						goto IL_042d;
						IL_042d:
						num2 = 33;
						DC_Main.i++;
						goto IL_043c;
						IL_01ae:
						num2 = 16;
						if (((DataGridView)DGV)[num6, DC_Main.i].Value != null)
						{
							goto IL_01d4;
						}
						goto IL_03de;
						IL_01d4:
						num2 = 17;
						if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
						{
							goto IL_01f1;
						}
						goto IL_0255;
						IL_01f1:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num6 + 1,
							((DataGridView)DGV)[num6, DC_Main.i].Value.ToString() ?? ""
						}, (string[])null, (Type[])null);
						goto IL_041b;
						IL_041b:
						num2 = 32;
						num6++;
						goto IL_0424;
						IL_03de:
						num2 = 30;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num6 + 1,
							""
						}, (string[])null, (Type[])null);
						goto IL_041b;
						IL_0255:
						num2 = 20;
						switch (num6)
						{
						case 5:
							break;
						case 6:
						case 7:
						case 9:
						case 14:
						case 16:
						case 18:
						case 19:
							goto IL_0310;
						default:
							goto IL_037a;
						}
						goto IL_02a3;
						IL_037a:
						num2 = 26;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num6 + 1,
							((DataGridView)DGV)[num6, DC_Main.i].Value.ToString() ?? ""
						}, (string[])null, (Type[])null);
						goto IL_041b;
						end_IL_0001_2:
						break;
					}
					num2 = 48;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 2008;
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

	private void RP_DHRN_OS_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0991: Expected O, but got Unknown
		//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Expected O, but got Unknown
		//IL_0a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Expected O, but got Unknown
		//IL_0b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2b: Expected O, but got Unknown
		//IL_0b9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba8: Expected O, but got Unknown
		//IL_0c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c69: Expected O, but got Unknown
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c97: Expected O, but got Unknown
		//IL_0cb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc5: Expected O, but got Unknown
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
				DataGridViewX dGV = DGV;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV2 = DGV;
				object? obj10 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj12 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj13 = lblBook;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj13).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj16 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj17 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mFromDt).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is SearchControl || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control5 in ((Control)PnlAcSumm).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
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
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
			}
			DC_Main.RsQry = "SELECT EMP_NAME As SchmName,EMP_CODE as Code FROM EMP_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_CODE";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryEmpCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryEmpCode[DC_Main.X] = "";
				cboEmp.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboEmp.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["SchmName"], (object)""));
					AryEmpCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboEmp.Items.Add((object)"");
				AryEmpCode[DC_Main.X] = "";
			}
			cboEmp.SelectedIndex = 0;
			if (Operators.CompareString(CurRpt, "Intrest All", false) == 0)
			{
				CurIntTypeCalc = DC_Main.MsDhrnIntType;
				((Control)lblLoanType).Visible = false;
				((Control)cboLoanType).Visible = false;
				((Control)nGlRate).Visible = false;
				((Control)nSlRate).Visible = false;
				((Control)Label8).Visible = false;
				if (Operators.CompareString(DC_Main.MsDhrnCompound, "N", false) == 0)
				{
					chkInt.Checked = false;
				}
				else
				{
					chkInt.Checked = true;
				}
				lblLoanType.Text = "Dhrn Type";
				((Control)lblLoanType).Visible = true;
				((Control)cboLoanType).Visible = true;
			}
			else if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
			{
				CurIntTypeCalc = DC_Main.MsDhrnIntType;
				((Control)lblLoanType).Visible = false;
				((Control)cboLoanType).Visible = false;
				((Control)pnlPacket).Visible = true;
				if (Operators.CompareString(DC_Main.MsDhrnCompound, "N", false) == 0)
				{
					chkInt.Checked = false;
				}
				else
				{
					chkInt.Checked = true;
				}
				((Control)BtnPrint).Visible = true;
				DC_Main.RsQry = "SELECT VCH_DATE,FINE_GL_RATE,FINE_SL_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					nGlRate.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_GL_RATE"])), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) != 0.0)
					{
						nSlRate.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) / 100.0), "0.00");
					}
				}
			}
			else
			{
				chkInt.Checked = false;
				((Control)nGlRate).Visible = false;
				((Control)nSlRate).Visible = false;
				((Control)Label8).Visible = false;
				CurIntTypeCalc = DC_Main.MsLoanIntType;
			}
			DC_Main.RsQry = "UPDATE A SET A.DHRN_REC_AMT = B.DhrnRec, A.UNCHAK_DHRN_REC = B.UnchakRec FROM DHRN_ISU_DATA AS A  INNER JOIN(Select CO_CODE, ISU_LC, ISU_YRCD, ISU_DBCD, ISU_NO, SUM(DHRN_REC_AMT) As DhrnRec, SUM(UNCHAK_DHRN_REC) As UnchakRec  FROM DHRN_DATA GROUP BY CO_CODE, ISU_LC, ISU_YRCD, ISU_DBCD, ISU_NO) As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ISU_LC  And A.CO_YEAR = B.ISU_YRCD And A.CO_BOOK = B.ISU_DBCD And A.VCH_NO = B.ISU_NO And A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			cboLoanType.Items.Add((object)"Amount");
			cboLoanType.Items.Add((object)"Gold");
			cboLoanType.Items.Add((object)"Silver");
			cboLoanType.SelectedIndex = 0;
			CLEAR_DATA();
			mFromDt.Text = "01/01/2010";
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			CurActCtrl = (Control)(object)tAcCode;
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
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		cboLoanType.SelectedIndex = 0;
		((Control)mFromDt).Focus();
	}

	private void RP_DHRN_OS_Activated(object sender, EventArgs e)
	{
		FormLoad = true;
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_DHRN_OS_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_DHRN_OS_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_DHRN_OS_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(UserPrint, "Y", false) != 0)
			{
				Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(tAcCode.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Select Party And Try....", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DataGridViewX dGV = DGV;
				DC_Main.RsQry = "INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13,COL_14,COL_15,COL_16,COL_17,COL_18,COL_19,COL_20,COL_21,COL_22,COL_23)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','0','" + ((DataGridView)dGV).Columns[1].HeaderText + "','" + ((DataGridView)dGV).Columns[2].HeaderText + "','" + ((DataGridView)dGV).Columns[3].HeaderText + "','" + ((DataGridView)dGV).Columns[4].HeaderText + "','" + ((DataGridView)dGV).Columns[5].HeaderText + "','" + ((DataGridView)dGV).Columns[6].HeaderText + "','" + ((DataGridView)dGV).Columns[7].HeaderText + "',  '" + ((DataGridView)dGV).Columns[8].HeaderText + "','" + ((DataGridView)dGV).Columns[9].HeaderText + "','" + ((DataGridView)dGV).Columns[10].HeaderText + "','" + ((DataGridView)dGV).Columns[11].HeaderText + "','" + ((DataGridView)dGV).Columns[12].HeaderText + "','" + ((DataGridView)dGV).Columns[13].HeaderText + "','" + ((DataGridView)dGV).Columns[14].HeaderText + "','" + ((DataGridView)dGV).Columns[15].HeaderText + "','" + ((DataGridView)dGV).Columns[16].HeaderText + "','" + ((DataGridView)dGV).Columns[17].HeaderText + "','" + ((DataGridView)dGV).Columns[18].HeaderText + "','" + ((DataGridView)dGV).Columns[19].HeaderText + "','" + ((DataGridView)dGV).Columns[20].HeaderText + "','" + ((DataGridView)dGV).Columns[21].HeaderText + "','" + ((DataGridView)dGV).Columns[22].HeaderText + "','" + ((DataGridView)dGV).Columns[23].HeaderText + "')";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				int num = ((DataGridView)dGV).RowCount - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13,COL_14,COL_15,COL_16,COL_17,COL_18,COL_19,COL_20,COL_21,COL_22,COL_23)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)dGV)[0, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[3, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[5, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[7, DC_Main.X].Value), (object)"', "), (object)" '"), (object)Strings.Mid(Conversions.ToString(((DataGridView)dGV)[8, DC_Main.X].Value), 1, 50)), (object)"','"), ((DataGridView)dGV)[9, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[10, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[11, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[12, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[13, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[14, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[15, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[16, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[17, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[18, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[19, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[20, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[21, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[22, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[23, DC_Main.X].Value), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				dGV = null;
				DC_Main.RsQry = "SELECT * FROM REPORT_DATA";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DharnDue.RPT";
				Cr.SelectionFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
				Cr[(short)0] = "RptTitel = '" + tAcName.Text + "  Accounts Dharin Panding Report As On" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				Cr.Action = -1;
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
		if (Operators.CompareString(CurRpt, "Dhrn Due", false) != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT VCH_DATE,FINE_GL_RATE,FINE_SL_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			nGlRate.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_GL_RATE"])), "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) != 0.0)
			{
				nSlRate.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) / 100.0), "0.00");
			}
		}
	}

	private void RP_DHRN_OS_Closed(object sender, EventArgs e)
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

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
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
					if ((Operators.CompareString(CurRpt, "Intrest All", false) == 0) | (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0))
					{
						DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_GR ='15' ORDER BY LC_CODE,AC_NAME";
					}
					else
					{
						DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_GR IN('01','03','04') ORDER BY LC_CODE,AC_NAME";
					}
				}
				else if ((Operators.CompareString(CurRpt, "Intrest All", false) == 0) | (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0))
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_GR ='15' ORDER BY AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_GR IN('01','03','04') ORDER BY AC_NAME";
				}
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
					if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
					{
						DGV_DHRN_DUE();
					}
					else
					{
						DGV_DHRN_FILL();
					}
				}
				((Control)tAcCode).Focus();
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
				{
					DGV_DHRN_DUE();
				}
				else
				{
					DGV_DHRN_FILL();
				}
				((Control)tAcCode).Focus();
			}
		}
		else if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
		{
			DGV_DHRN_DUE();
		}
		else
		{
			DGV_DHRN_FILL();
		}
	}

	private void BtnJmaUdhar_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr[(short)7] = "";
		double num = 0.0;
		double num2 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdAmt.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
		Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";
		Cr[(short)4] = ("ClBal = " + Strings.Format((object)num2, "0.00")) ?? "";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
		{
			DGV_DHRN_DUE();
		}
		else
		{
			DGV_DHRN_FILL();
		}
	}

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboEmp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void chkIntType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
			{
				DGV_DHRN_DUE();
			}
			else
			{
				DGV_DHRN_FILL();
			}
		}
	}

	private void chkIntType_CheckedChanged(object sender, EventArgs e)
	{
		if (FormLoad)
		{
			if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
			{
				DGV_DHRN_DUE();
			}
			else
			{
				DGV_DHRN_FILL();
			}
		}
	}

	private void ChkInt_CheckedChanged(object sender, EventArgs e)
	{
		if (FormLoad)
		{
			if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
			{
				DGV_DHRN_DUE();
			}
			else
			{
				DGV_DHRN_FILL();
			}
		}
	}

	private void chkInt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
			{
				DGV_DHRN_DUE();
			}
			else
			{
				DGV_DHRN_FILL();
			}
		}
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(CurRpt, "Dhrn Due", false) == 0)
		{
			if (Operators.ConditionalCompareObjectLess(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[5].Value, (object)DC_Main.MOp_dt, false))
			{
				Interaction.MsgBox((object)"You cant open old year entry...", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		else if (Operators.ConditionalCompareObjectLess(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[3].Value, (object)DC_Main.MOp_dt, false))
		{
			Interaction.MsgBox((object)"You cant open old year entry...", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[24].Value), (object)""), (object)"' "));
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
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[2].Value, (object)""));
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

	private void tPacketNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btnOk).Focus();
		}
	}
}
