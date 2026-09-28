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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_CASH_BANK : Form
{
	public enum GridViewColumnType
	{
		TextBox,
		InvisibleTextBoxCell
	}

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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DataGridViewX _DGV_DETL;

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
	[AccessedThroughProperty("nMembAmt")]
	private TextBox _nMembAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkSchmPanding")]
	private CheckBox _chkSchmPanding;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboScheme")]
	private ComboBox _cboScheme;

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
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMembCode")]
	private TextBox _tMembCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkComplete")]
	private CheckBox _chkComplete;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string[] ArySchmCode;

	private string[] AryEmpCode;

	private string CurSchmType;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cAcName = 1;

	private const int cAcCode = 2;

	private const int cMobile = 3;

	private const int cEmpName = 4;

	private const int cJoinDt = 5;

	private const int cMembAmt = 6;

	private const int cGlWt = 7;

	private const int cSchmAmt = 8;

	private const int cSchmAdjAmt = 9;

	private const int cSchmBonusAmt = 10;

	private const int cSchmBalAmt = 11;

	private const int cAdd1 = 12;

	private const int cEmpCode = 13;

	private const int c2SrNo = 0;

	private const int c2BookName = 1;

	private const int c2VchNo = 2;

	private const int c2VchDate = 3;

	private const int c2AcName = 4;

	private const int c2AcArea = 5;

	private const int c2DrAmt = 6;

	private const int c2Cramt = 7;

	private const int c2BalAmt = 8;

	private const int c2CrDr = 9;

	private const int c2CoBook = 10;

	private const int c2AcCode = 11;

	private const int c2MainBook = 12;

	private const int xBox = 0;

	private const int xSrNo = 1;

	private const int xBook = 2;

	private const int xVchNo = 3;

	private const int xDate = 4;

	private const int xMonth = 5;

	private const int xLdrName = 6;

	private const int xGlRate = 7;

	private const int xGlWt = 8;

	private const int xGlBal = 9;

	private const int xSchmAmt = 10;

	private const int xAdjAmt = 11;

	private const int xBonusAmt = 12;

	private const int xBalanceAmt = 13;

	private const int xBookCode = 14;

	private const int xMainBook = 15;

	private const int xSchmeCode = 16;

	private const int xSchmYrCd = 17;

	private const int xSchmSrNo = 18;

	private const int xRecAc = 19;

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

	internal virtual TextBox nMembAmt
	{
		[CompilerGenerated]
		get
		{
			return _nMembAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMembAmt_KeyDown);
			TextBox val2 = _nMembAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMembAmt = value;
			val2 = _nMembAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label15")]
	private virtual Label _Label15;

	internal virtual Label Label15
	{
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label15 = value;
		}
	}

	internal virtual CheckBox chkSchmPanding
	{
		[CompilerGenerated]
		get
		{
			return _chkSchmPanding;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkSchmPanding_KeyDown);
			EventHandler eventHandler = chkSchmPanding_CheckedChanged;
			CheckBox val2 = _chkSchmPanding;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.CheckedChanged -= eventHandler;
			}
			_chkSchmPanding = value;
			val2 = _chkSchmPanding;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.CheckedChanged += eventHandler;
			}
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

	internal virtual ComboBox cboScheme
	{
		[CompilerGenerated]
		get
		{
			return _cboScheme;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboScheme_KeyDown);
			EventHandler eventHandler = cboScheme_SelectedIndexChanged;
			ComboBox val2 = _cboScheme;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboScheme = value;
			val2 = _cboScheme;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			EventHandler eventHandler = DGV_DoubleClick;
			KeyEventHandler val2 = new KeyEventHandler(DGV_KeyDown);
			DataGridViewCellEventHandler val3 = new DataGridViewCellEventHandler(DGV_CellContentClick);
			DataGridViewX val4 = _DGV;
			if (val4 != null)
			{
				((DataGridView)val4).CellFormatting -= val;
				((Control)val4).DoubleClick -= eventHandler;
				((Control)val4).KeyDown -= val2;
				((DataGridView)val4).CellContentClick -= val3;
			}
			_DGV = value;
			val4 = _DGV;
			if (val4 != null)
			{
				((DataGridView)val4).CellFormatting += val;
				((Control)val4).DoubleClick += eventHandler;
				((Control)val4).KeyDown += val2;
				((DataGridView)val4).CellContentClick += val3;
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
	[AccessedThroughProperty("nLineSkip")]
	private virtual TextBox _nLineSkip;

	internal virtual TextBox nLineSkip
	{
		get
		{
			return _nLineSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLineSkip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLineSkip")]
	private virtual Label _lblLineSkip;

	internal virtual Label lblLineSkip
	{
		get
		{
			return _lblLineSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLineSkip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private virtual FlowLayoutPanel _FlowLayoutPanel1;

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_FlowLayoutPanel1 = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookName")]
	private virtual TextBox _tBookName;

	internal virtual TextBox tBookName
	{
		get
		{
			return _tBookName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBookName = value;
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

	internal virtual TextBox tMembCode
	{
		[CompilerGenerated]
		get
		{
			return _tMembCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMembCode_KeyDown);
			TextBox val2 = _tMembCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMembCode = value;
			val2 = _tMembCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual CheckBox chkComplete
	{
		[CompilerGenerated]
		get
		{
			return _chkComplete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkComplete_KeyDown);
			EventHandler eventHandler = chkComplete_CheckedChanged;
			CheckBox val2 = _chkComplete;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.CheckedChanged -= eventHandler;
			}
			_chkComplete = value;
			val2 = _chkComplete;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.CheckedChanged += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

	public RP_CASH_BANK()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += RP_CASH_BANK_Load;
		((Form)this).Activated += RP_CASH_BANK_Activated;
		((Form)this).Deactivate += RP_CASH_BANK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_CASH_BANK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_CASH_BANK_KeyDown);
		((Form)this).Closed += RP_CASH_BANK_Closed;
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
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_060c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Expected O, but got Unknown
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Expected O, but got Unknown
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Expected O, but got Unknown
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Expected O, but got Unknown
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected O, but got Unknown
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Expected O, but got Unknown
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Expected O, but got Unknown
		//IL_0b39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Expected O, but got Unknown
		//IL_0bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be8: Expected O, but got Unknown
		//IL_0ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd5: Expected O, but got Unknown
		//IL_0d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4d: Expected O, but got Unknown
		//IL_0dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e06: Expected O, but got Unknown
		//IL_0e80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8a: Expected O, but got Unknown
		//IL_0f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f18: Expected O, but got Unknown
		//IL_0fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff0: Expected O, but got Unknown
		//IL_1082: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Expected O, but got Unknown
		//IL_110a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1114: Expected O, but got Unknown
		//IL_11e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f3: Expected O, but got Unknown
		//IL_125c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1266: Expected O, but got Unknown
		//IL_14e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ea: Expected O, but got Unknown
		//IL_15a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b1: Expected O, but got Unknown
		//IL_165f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1669: Expected O, but got Unknown
		//IL_1717: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Expected O, but got Unknown
		//IL_17bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c7: Expected O, but got Unknown
		//IL_184d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1857: Expected O, but got Unknown
		//IL_193e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1948: Expected O, but got Unknown
		//IL_19b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bb: Expected O, but got Unknown
		//IL_1c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1c: Expected O, but got Unknown
		//IL_1d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de6: Expected O, but got Unknown
		//IL_1e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6d: Expected O, but got Unknown
		//IL_1f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f52: Expected O, but got Unknown
		//IL_1fcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd6: Expected O, but got Unknown
		//IL_20ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b8: Expected O, but got Unknown
		//IL_2142: Unknown result type (might be due to invalid IL or missing references)
		//IL_214c: Expected O, but got Unknown
		//IL_2227: Unknown result type (might be due to invalid IL or missing references)
		//IL_2231: Expected O, but got Unknown
		//IL_22ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b8: Expected O, but got Unknown
		//IL_2366: Unknown result type (might be due to invalid IL or missing references)
		//IL_2370: Expected O, but got Unknown
		//IL_23e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f1: Expected O, but got Unknown
		//IL_24a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ac: Expected O, but got Unknown
		//IL_25a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b2: Expected O, but got Unknown
		//IL_261e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2624: Expected O, but got Unknown
		//IL_2626: Unknown result type (might be due to invalid IL or missing references)
		//IL_262c: Expected O, but got Unknown
		//IL_267d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2687: Expected O, but got Unknown
		//IL_2735: Unknown result type (might be due to invalid IL or missing references)
		//IL_273f: Expected O, but got Unknown
		//IL_27d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e0: Expected O, but got Unknown
		//IL_2874: Unknown result type (might be due to invalid IL or missing references)
		//IL_287e: Expected O, but got Unknown
		//IL_28ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2909: Expected O, but got Unknown
		//IL_298d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2997: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_CASH_BANK));
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
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnJmaUdhar = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		nLineSkip = new TextBox();
		lblLineSkip = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		PnlAcSumm = new Panel();
		chkComplete = new CheckBox();
		Label6 = new Label();
		tMembCode = new TextBox();
		DGV = new DataGridViewX();
		btnOk = new QButton();
		cboEmp = new ComboBox();
		Label3 = new Label();
		cboScheme = new ComboBox();
		Label1 = new Label();
		cboArea = new ComboBox();
		Label17 = new Label();
		cboCity = new ComboBox();
		lblCity = new Label();
		nMembAmt = new TextBox();
		Label15 = new Label();
		chkSchmPanding = new CheckBox();
		tSerchAll = new SearchControl();
		Label4 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label5 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnJmaUdhar);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 4;
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
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)nLineSkip);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)lblLineSkip);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(268, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(456, 33);
		((Control)FlowLayoutPanel1).TabIndex = 1167;
		((TextBoxBase)nLineSkip).BackColor = Color.White;
		((Control)nLineSkip).Font = new Font("Arial", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLineSkip).Location = new Point(414, 3);
		((TextBoxBase)nLineSkip).MaxLength = 15;
		((Control)nLineSkip).Name = "nLineSkip";
		((Control)nLineSkip).Size = new Size(39, 27);
		((Control)nLineSkip).TabIndex = 1165;
		nLineSkip.TextAlign = (HorizontalAlignment)2;
		((Control)nLineSkip).Visible = false;
		((Control)lblLineSkip).BackColor = Color.Transparent;
		((Control)lblLineSkip).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLineSkip).ForeColor = Color.Black;
		lblLineSkip.ImeMode = (ImeMode)0;
		((Control)lblLineSkip).Location = new Point(328, 0);
		((Control)lblLineSkip).Name = "lblLineSkip";
		((Control)lblLineSkip).Size = new Size(80, 31);
		((Control)lblLineSkip).TabIndex = 1166;
		lblLineSkip.Text = "Line Skip";
		lblLineSkip.TextAlign = (ContentAlignment)64;
		((Control)lblLineSkip).Visible = false;
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
		lblBook.Text = "Cash and Bank Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(339, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(78, 22);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(421, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(272, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(246, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Party Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_DETL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Tahoma", 9.75f);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val3;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 80);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val5;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkComplete);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label6);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tMembCode);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV);
		((Control)PnlAcSumm).Controls.Add((Control)(object)btnOk);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboEmp);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboScheme);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboArea);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label17);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)nMembAmt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label15);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkSchmPanding);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAcSumm).Location = new Point(1, 34);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 531);
		((Control)PnlAcSumm).TabIndex = 3;
		((ButtonBase)chkComplete).BackColor = Color.Transparent;
		((Control)chkComplete).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkComplete).ForeColor = Color.Navy;
		((Control)chkComplete).Location = new Point(835, 46);
		((Control)chkComplete).Name = "chkComplete";
		((Control)chkComplete).RightToLeft = (RightToLeft)0;
		((Control)chkComplete).Size = new Size(136, 22);
		((Control)chkComplete).TabIndex = 1148;
		((ButtonBase)chkComplete).Text = "Only Complete";
		((ButtonBase)chkComplete).UseVisualStyleBackColor = false;
		((Control)chkComplete).Visible = false;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(284, 45);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(96, 19);
		((Control)Label6).TabIndex = 1147;
		Label6.Text = "Memb Code";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMembCode).BackColor = Color.White;
		((Control)tMembCode).Font = new Font("Tahoma", 9f);
		((Control)tMembCode).Location = new Point(386, 45);
		((TextBoxBase)tMembCode).MaxLength = 10;
		((Control)tMembCode).Name = "tMembCode";
		((Control)tMembCode).Size = new Size(73, 22);
		((Control)tMembCode).TabIndex = 1146;
		tMembCode.TextAlign = (HorizontalAlignment)2;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV).ColumnHeadersHeight = 25;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val8;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(13, 76);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 10;
		val10.Font = new Font("Calibri", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((DataGridView)DGV).RowsDefaultCellStyle = val10;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)1;
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
		((Control)btnOk).Location = new Point(1059, 21);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(103, 37);
		((Control)btnOk).TabIndex = 7;
		btnOk.Text = "&Ok";
		cboEmp.AutoCompleteMode = (AutoCompleteMode)3;
		cboEmp.AutoCompleteSource = (AutoCompleteSource)256;
		cboEmp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboEmp).Font = new Font("Tahoma", 9f);
		((ListControl)cboEmp).FormattingEnabled = true;
		((Control)cboEmp).Location = new Point(757, 14);
		((Control)cboEmp).Name = "cboEmp";
		((Control)cboEmp).Size = new Size(157, 22);
		((Control)cboEmp).TabIndex = 4;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(685, 14);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(66, 19);
		((Control)Label3).TabIndex = 1144;
		Label3.Text = "Employ";
		Label3.TextAlign = (ContentAlignment)64;
		cboScheme.AutoCompleteMode = (AutoCompleteMode)3;
		cboScheme.AutoCompleteSource = (AutoCompleteSource)256;
		cboScheme.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboScheme).Font = new Font("Tahoma", 9f);
		((ListControl)cboScheme).FormattingEnabled = true;
		((Control)cboScheme).Location = new Point(93, 12);
		((Control)cboScheme).Name = "cboScheme";
		((Control)cboScheme).Size = new Size(179, 22);
		((Control)cboScheme).TabIndex = 0;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(17, 12);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(69, 19);
		((Control)Label1).TabIndex = 1142;
		Label1.Text = "Scheme";
		Label1.TextAlign = (ContentAlignment)64;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(521, 44);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(144, 22);
		((Control)cboArea).TabIndex = 3;
		((Control)cboArea).UseWaitCursor = true;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(466, 45);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(47, 19);
		((Control)Label17).TabIndex = 1140;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(521, 13);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(144, 22);
		((Control)cboCity).TabIndex = 2;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(470, 14);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(43, 19);
		((Control)lblCity).TabIndex = 1138;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nMembAmt).BackColor = Color.White;
		((Control)nMembAmt).Font = new Font("Tahoma", 9f);
		((Control)nMembAmt).Location = new Point(386, 13);
		((TextBoxBase)nMembAmt).MaxLength = 10;
		((Control)nMembAmt).Name = "nMembAmt";
		((Control)nMembAmt).Size = new Size(73, 22);
		((Control)nMembAmt).TabIndex = 5;
		nMembAmt.TextAlign = (HorizontalAlignment)2;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(290, 14);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(89, 20);
		((Control)Label15).TabIndex = 1136;
		Label15.Text = "Memb Amt";
		Label15.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkSchmPanding).BackColor = Color.Transparent;
		((Control)chkSchmPanding).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkSchmPanding).ForeColor = Color.Navy;
		((Control)chkSchmPanding).Location = new Point(705, 45);
		((Control)chkSchmPanding).Name = "chkSchmPanding";
		((Control)chkSchmPanding).RightToLeft = (RightToLeft)0;
		((Control)chkSchmPanding).Size = new Size(111, 22);
		((Control)chkSchmPanding).TabIndex = 6;
		((ButtonBase)chkSchmPanding).Text = "Only Panding";
		((ButtonBase)chkSchmPanding).UseVisualStyleBackColor = false;
		((Control)chkSchmPanding).Visible = false;
		((Control)tSerchAll).Location = new Point(93, 43);
		((Control)tSerchAll).Name = "tSerchAll";
		tSerchAll.Properties.AllowAutoApply = false;
		((RepositoryItemPopupBase)tSerchAll.Properties).AllowDropDownWhenReadOnly = (DefaultBoolean)1;
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Search Name and Number";
		((Control)tSerchAll).Size = new Size(179, 24);
		((Control)tSerchAll).TabIndex = 1;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(32, 45);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(44, 20);
		((Control)Label4).TabIndex = 1159;
		Label4.Text = "Date";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(164, 44);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(82, 44);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(762, 46);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(68, 23);
		((Control)tBookCode).TabIndex = 1162;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(836, 46);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(268, 23);
		((Control)tBookName).TabIndex = 1164;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(702, 46);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(50, 20);
		((Control)Label5).TabIndex = 1163;
		Label5.Text = "Book";
		Label5.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_CASH_BANK";
		((Form)this).Text = "Cash And Bank Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_SCHM_FILL()
	{
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Expected O, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Expected O, but got Unknown
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Expected O, but got Unknown
		//IL_0e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e38: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["SCHM_TYPE"], (object)"G", false))
			{
				CurSchmType = "G";
			}
			else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["SCHM_TYPE"], (object)"S", false))
			{
				CurSchmType = "S";
			}
			else
			{
				CurSchmType = "A";
			}
		}
		if (chkComplete.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,C.EMP_NAME,B.JOIN_DATE As JoinDt,B.MEMB_AMT As MembAmt,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.GOLD_WT ELSE 0 END) ELSE 0 END) as SchmGold,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAmt,SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAdj,SUM(CASE WHEN A.OS_TYPE = 'B' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as BonusAmt FROM (AD_OS AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.MEMB_CODE = B.MEMB_CODE AND A.SCHM_CODE = B.SCHM_CODE) LEFT JOIN EMP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.EMP_CODE = C.EMP_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "'"), Interaction.IIf(Operators.CompareString(nMembAmt.Text, "", false) == 0, (object)"", (object)(("AND B.MEMB_AMT = " + Conversions.ToString(Conversion.Val(nMembAmt.Text))) ?? ""))), Interaction.IIf(Operators.CompareString(cboEmp.Text, "", false) == 0, (object)"", (object)("AND B.EMP_CODE = '" + AryEmpCode[cboEmp.SelectedIndex] + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tMembCode.Text, "", false) == 0, (object)"", (object)("AND B.MEMB_CODE = '" + tMembCode.Text + "'"))), (object)" GROUP BY A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,C.EMP_NAME,B.JOIN_DATE,B.MEMB_AMT "), (object)" HAVING SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) - SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) <= 0 ORDER BY A.MEMB_CODE "));
		}
		else if (chkSchmPanding.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,C.EMP_NAME,B.JOIN_DATE As JoinDt,B.MEMB_AMT As MembAmt,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.GOLD_WT ELSE 0 END) ELSE 0 END) as SchmGold,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAmt,SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAdj,SUM(CASE WHEN A.OS_TYPE = 'B' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as BonusAmt FROM (AD_OS AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.MEMB_CODE = B.MEMB_CODE AND A.SCHM_CODE = B.SCHM_CODE) LEFT JOIN EMP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.EMP_CODE = C.EMP_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "'"), Interaction.IIf(Operators.CompareString(nMembAmt.Text, "", false) == 0, (object)"", (object)(("AND B.MEMB_AMT = " + Conversions.ToString(Conversion.Val(nMembAmt.Text))) ?? ""))), Interaction.IIf(Operators.CompareString(cboEmp.Text, "", false) == 0, (object)"", (object)("AND B.EMP_CODE = '" + AryEmpCode[cboEmp.SelectedIndex] + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tMembCode.Text, "", false) == 0, (object)"", (object)("AND B.MEMB_CODE = '" + tMembCode.Text + "'"))), (object)" GROUP BY A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,C.EMP_NAME,B.JOIN_DATE,B.MEMB_AMT "), (object)" HAVING SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) - SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) > 0 ORDER BY A.MEMB_CODE "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,C.EMP_NAME,B.JOIN_DATE As JoinDt,B.MEMB_AMT As MembAmt,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.GOLD_WT ELSE 0 END) ELSE 0 END) as SchmGold,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAmt,SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAdj,SUM(CASE WHEN A.OS_TYPE = 'B' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as BonusAmt FROM (AD_OS AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.MEMB_CODE = B.MEMB_CODE AND A.SCHM_CODE = B.SCHM_CODE) LEFT JOIN EMP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.EMP_CODE = C.EMP_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "'"), Interaction.IIf(Operators.CompareString(nMembAmt.Text, "", false) == 0, (object)"", (object)(("AND B.MEMB_AMT = " + Conversions.ToString(Conversion.Val(nMembAmt.Text))) ?? ""))), Interaction.IIf(Operators.CompareString(cboEmp.Text, "", false) == 0, (object)"", (object)("AND B.EMP_CODE = '" + AryEmpCode[cboEmp.SelectedIndex] + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tMembCode.Text, "", false) == 0, (object)"", (object)("AND B.MEMB_CODE = '" + tMembCode.Text + "'"))), (object)" GROUP BY A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,C.EMP_NAME,B.JOIN_DATE,B.MEMB_AMT  ORDER BY A.MEMB_CODE "));
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
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
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Memb Name");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(230.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Code");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Mobile");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Emp Name");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Join Dt");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Memb Amt");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N2";
			if (Operators.CompareString(CurSchmType, "G", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "GoldWt");
				((DataGridView)DGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
			}
			else if (Operators.CompareString(CurSchmType, "S", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "SlvrWt");
				((DataGridView)DGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "GoldWt");
				((DataGridView)DGV).Columns[7].Visible = false;
			}
			((DataGridView)DGV).Columns.Add("", "Schm Amt");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Adj Amt");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Bonus");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Bal Amt");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "cAdd1");
			((DataGridView)DGV).Columns[12].Visible = false;
			((DataGridView)DGV).Columns.Add("", "cEmpCode");
			((DataGridView)DGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			int num6 = 0;
			if (dataTable.Rows.Count > 0)
			{
				int num7 = dataTable.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, num6].Value = num6 + 1;
					((DataGridView)dGV)[1, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MEMB_NAME"]);
					((DataGridView)dGV)[2, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MEMB_CODE"]);
					((DataGridView)dGV)[3, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_MOBILE"]);
					((DataGridView)dGV)[4, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["EMP_NAME"]);
					((DataGridView)dGV)[5, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["JoinDt"]);
					((DataGridView)dGV)[6, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MembAmt"]);
					((DataGridView)dGV)[7, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SchmGold"]);
					((DataGridView)dGV)[8, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SchmAmt"]);
					((DataGridView)dGV)[9, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["SchmAdj"]);
					((DataGridView)dGV)[10, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BonusAmt"]);
					((DataGridView)dGV)[11, num6].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num6].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num6].Value));
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[DC_Main.M]["SchmAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[DC_Main.M]["SchmAdj"]));
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[DC_Main.M]["BonusAmt"]));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num6].Value));
					num5 += Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["MembAmt"], (object)""));
					((DataGridView)dGV)[13, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["EMP_CODE"]);
					((DataGridView)dGV)[12, num6].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["AC_ADD1"]);
					num6++;
					dGV = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridView)DGV).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV).Rows.Add();
					((DataGridView)DGV).Rows.Add();
				}
				int num8 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num8].Cells[1].Value = "Total :";
				((DataGridView)DGV).Rows[num8].Cells[6].Value = num5;
				((DataGridView)DGV).Rows[num8].Cells[8].Value = num;
				((DataGridView)DGV).Rows[num8].Cells[9].Value = num2;
				((DataGridView)DGV).Rows[num8].Cells[10].Value = num3;
				((DataGridView)DGV).Rows[num8].Cells[11].Value = num4;
			}
			((Control)DGV).Focus();
		}
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		int num = 1;
		checked
		{
			if (Versioned.IsNumeric((object)((TextEdit)tSerchAll).Text))
			{
				num = 2;
				if (!((Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0) & (Strings.Len(((TextEdit)tSerchAll).Text) > 2)))
				{
					return;
				}
				int num2 = ((DataGridView)DGV).Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = ((BaseCollection)((DataGridView)DGV).Rows[i].Cells).Count - 1;
					for (num = 0; num <= num3; num++)
					{
						if (((DataGridView)DGV)[num, i].Value != null && ((DataGridView)DGV)[num, i].Value.ToString().ToLower().StartsWith(((TextEdit)tSerchAll).Text.ToLower()))
						{
							((DataGridView)DGV).Rows[i].Selected = true;
							((DataGridView)DGV).CurrentCell = ((DataGridView)DGV).Rows[i].Cells[num];
							break;
						}
					}
				}
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				int num4 = ((DataGridView)DGV).Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (((DataGridView)DGV)[num, j].Value != null && ((DataGridView)DGV)[num, j].Value.ToString().ToLower().StartsWith(((TextEdit)tSerchAll).Text.ToLower()))
					{
						((DataGridView)DGV).CurrentCell = ((DataGridView)DGV).Rows[j].Cells[num];
						((DataGridView)DGV).Rows[j].Selected = true;
						break;
					}
				}
			}
			else
			{
				((DataGridView)DGV).CurrentCell = ((DataGridView)DGV).Rows[0].Cells[num];
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
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 6) <= 5u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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
					case 2021:
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
								goto IL_0129;
							case 13:
								goto IL_0140;
							case 14:
								goto IL_0188;
							case 15:
								goto IL_0197;
							case 16:
								goto IL_01b4;
							case 17:
								goto IL_01ce;
							case 18:
								goto IL_01f1;
							case 19:
							case 20:
								goto IL_0246;
							case 21:
								goto IL_0258;
							case 23:
								goto IL_027a;
							case 24:
								goto IL_0291;
							case 25:
								goto IL_02d9;
							case 26:
								goto IL_02e8;
							case 27:
								goto IL_0305;
							case 28:
								goto IL_031f;
							case 29:
								goto IL_0346;
							case 31:
								goto IL_0351;
							case 33:
								goto IL_03bb;
							case 30:
							case 32:
							case 34:
							case 35:
							case 36:
								goto IL_0413;
							case 37:
								goto IL_0425;
							case 22:
							case 38:
							case 39:
								goto IL_0441;
							case 40:
								goto IL_044b;
							case 41:
								goto IL_049e;
							case 42:
								goto IL_04f3;
							case 43:
								goto IL_054b;
							case 44:
								goto IL_05b9;
							case 45:
								goto IL_05fc;
							case 46:
								goto IL_062b;
							case 47:
								goto IL_066e;
							case 48:
								goto IL_06af;
							case 49:
								goto IL_06d0;
							case 50:
								goto IL_06de;
							case 51:
								goto IL_06e4;
							case 52:
								goto IL_06ea;
							case 53:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 54:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0413:
						num2 = 36;
						num5++;
						goto IL_041c;
						IL_0291:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_DETL).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02d9;
						IL_0351:
						num2 = 31;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							Strings.Format((object)Conversions.ToDate(((DataGridView)DGV_DETL)[num5, DC_Main.i].Value.ToString()), "MM/dd/yyyy")
						}, (string[])null, (Type[])null);
						goto IL_0413;
						IL_02d9:
						num2 = 25;
						num6++;
						goto IL_02e2;
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
						if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
						{
							goto IL_0129;
						}
						goto IL_027a;
						IL_0129:
						num2 = 12;
						num7 = ((DataGridView)DGV).ColumnCount - 1;
						num8 = 0;
						goto IL_0191;
						IL_0191:
						if (num8 <= num7)
						{
							goto IL_0140;
						}
						goto IL_0197;
						IL_0197:
						num2 = 15;
						num9 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0267;
						IL_0267:
						if (DC_Main.i <= num9)
						{
							goto IL_01b4;
						}
						goto IL_0441;
						IL_01b4:
						num2 = 16;
						num10 = ((DataGridView)DGV).ColumnCount - 1;
						num11 = 0;
						goto IL_024f;
						IL_024f:
						if (num11 <= num10)
						{
							goto IL_01ce;
						}
						goto IL_0258;
						IL_0258:
						num2 = 21;
						DC_Main.i++;
						goto IL_0267;
						IL_01ce:
						num2 = 17;
						if (((DataGridView)DGV)[num11, DC_Main.i].Value != null)
						{
							goto IL_01f1;
						}
						goto IL_0246;
						IL_01f1:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0246;
						IL_0246:
						num2 = 20;
						num11++;
						goto IL_024f;
						IL_0140:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0188;
						IL_0188:
						num2 = 14;
						num8++;
						goto IL_0191;
						IL_027a:
						num2 = 23;
						num12 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num6 = 0;
						goto IL_02e2;
						IL_02e2:
						if (num6 <= num12)
						{
							goto IL_0291;
						}
						goto IL_02e8;
						IL_02e8:
						num2 = 26;
						num13 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0434;
						IL_0434:
						if (DC_Main.i <= num13)
						{
							goto IL_0305;
						}
						goto IL_0441;
						IL_0441:
						num2 = 39;
						colorConverter = new ColorConverter();
						goto IL_044b;
						IL_044b:
						num2 = 40;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_049e;
						IL_049e:
						num2 = 41;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_04f3;
						IL_04f3:
						num2 = 42;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_054b;
						IL_054b:
						num2 = 43;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_05b9;
						IL_05b9:
						num2 = 44;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05fc;
						IL_05fc:
						num2 = 45;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_062b;
						IL_062b:
						num2 = 46;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_066e;
						IL_066e:
						num2 = 47;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_06af;
						IL_06af:
						num2 = 48;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_06d0;
						IL_06d0:
						num2 = 49;
						Cursor.Current = Cursors.Default;
						goto IL_06de;
						IL_06de:
						num2 = 50;
						obj = null;
						goto IL_06e4;
						IL_06e4:
						num2 = 51;
						obj3 = null;
						goto IL_06ea;
						IL_06ea:
						num2 = 52;
						obj2 = null;
						break;
						IL_0305:
						num2 = 27;
						num14 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num5 = 0;
						goto IL_041c;
						IL_041c:
						if (num5 <= num14)
						{
							goto IL_031f;
						}
						goto IL_0425;
						IL_0425:
						num2 = 37;
						DC_Main.i++;
						goto IL_0434;
						IL_031f:
						num2 = 28;
						if (((DataGridView)DGV_DETL)[num5, DC_Main.i].Value != null)
						{
							goto IL_0346;
						}
						goto IL_0413;
						IL_0346:
						num2 = 29;
						if (num5 == 3)
						{
							goto IL_0351;
						}
						goto IL_03bb;
						IL_03bb:
						num2 = 33;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_DETL)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0413;
						end_IL_0001_2:
						break;
					}
					num2 = 53;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 2021;
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

	private void RP_CASH_BANK_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Expected O, but got Unknown
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b27: Expected O, but got Unknown
		//IL_0bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected O, but got Unknown
		//IL_0c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c79: Expected O, but got Unknown
		//IL_0ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Expected O, but got Unknown
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Expected O, but got Unknown
		//IL_0dd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de5: Expected O, but got Unknown
		//IL_0e04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e13: Expected O, but got Unknown
		//IL_0e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea4: Expected O, but got Unknown
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed2: Expected O, but got Unknown
		//IL_0ef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Expected O, but got Unknown
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
				DataGridViewX dGV_DETL = DGV_DETL;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj12 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj14 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj22 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj23 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tMembCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tMembCode).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
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
				num3 = (int)Math.Ceiling((double)((Control)tMembCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tMembCode).Font;
				try
				{
					foreach (object control5 in ((Control)PnlAcSumm).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font3 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
				}
			}
			DC_Main.RsQry = "SELECT SCHM_NAME As SchmName,SCHM_CODE as Code FROM AD_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY SCHM_CODE";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				ArySchmCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				ArySchmCode[DC_Main.X] = "";
				cboScheme.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboScheme.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)" - "), DC_Main.Rshlp.Rows[DC_Main.X]["SchmName"]), (object)""));
					ArySchmCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboScheme.Items.Add((object)"");
				ArySchmCode = new string[2];
				ArySchmCode[DC_Main.X] = "";
			}
			cboScheme.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT EMP_NAME As SchmName,EMP_CODE as Code FROM EMP_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_CODE";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryEmpCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryEmpCode[DC_Main.X] = "";
				cboEmp.Items.Add((object)"");
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
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
			CLEAR_DATA();
			if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
			{
				CurActCtrl = (Control)(object)cboScheme;
				((Control)Label5).Visible = false;
				((Control)tBookCode).Visible = false;
				((Control)tBookName).Visible = false;
				((Control)chkSchmPanding).Visible = true;
				((Control)chkComplete).Visible = true;
			}
			else
			{
				CurActCtrl = (Control)(object)mFromDt;
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
			else if (val is MaskedTextBox)
			{
				val.Text = DC_Main.MMask;
			}
		}
		MainUser = DC_Main.MCo_User;
		if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
		{
			mFromDt.Text = "01/01/2010";
		}
		else
		{
			mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		}
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
		{
			cboScheme.SelectedIndex = 0;
			((DataGridView)DGV).DataSource = null;
			((DataGridView)DGV).ClearSelection();
			((DataGridView)DGV).Rows.Clear();
			((DataGridView)DGV).Columns.Clear();
			((Control)DGV).Refresh();
		}
		else
		{
			((Control)PnlAcSumm).Visible = false;
			tAcCode.Text = "00001";
			tAcName.Text = "CASH ON HAND";
			DGV_DETL_FILL();
		}
		((Control)mFromDt).Focus();
	}

	private void RP_CASH_BANK_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Scheme Ledger", false) != 0)
		{
			DGV_DETL_FILL();
		}
		CurActCtrl.Focus();
	}

	private void DGV_DETL_FILL()
	{
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Expected O, but got Unknown
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected O, but got Unknown
		//IL_0981: Unknown result type (might be due to invalid IL or missing references)
		//IL_098b: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,AC_NAME FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView2 = new DataView(table2);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE As AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,C.AC_AREA,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver,B.MAIN_BOOK  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,C.AC_AREA ORDER BY A.VCH_DATE,B.BOOK_NAME"));
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
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Party Name");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(240.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Area");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[10].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[11].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[12].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			int num7 = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					((DataGridView)dGV_DETL)[0, num7].Value = num7 + 1;
					((DataGridView)dGV_DETL)[1, num7].Value = "Op Balance";
					((DataGridView)dGV_DETL)[6, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_DETL)[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_DETL)[8, num7].Value = Math.Abs(num2 - num);
					if (num2 - num > 0.0)
					{
						((DataGridView)dGV_DETL)[9, num7].Value = "Cr";
					}
					else if (num2 - num < 0.0)
					{
						((DataGridView)dGV_DETL)[9, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[9, num7].Value = "";
					}
					num7++;
				}
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num8 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num8)
				{
					DataGridViewX dGV_DETL2 = DGV_DETL;
					((DataGridView)dGV_DETL2).Rows.Add();
					((DataGridView)dGV_DETL2)[0, num7].Value = num7 + 1;
					((DataGridView)dGV_DETL2)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_DETL2)[2, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_DETL2)[3, num7].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV_DETL2)[10, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"SALES", false))
					{
						dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
						if (dataView.Count > 0)
						{
							((DataGridView)dGV_DETL2)[4, num7].Value = RuntimeHelpers.GetObjectValue(dataView[0]["AC_NAME"]);
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"PURCHASE", false))
					{
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV_DETL2)[4, num7].Value = RuntimeHelpers.GetObjectValue(dataView2[0]["AC_NAME"]);
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"MEMB ENTRY", false))
					{
						string text = Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.M]["LEDR_KEY"]), 25, 10);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.MEMB_NAME FROM (AD_DATA AS A INNER JOIN ROJ_MEL_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO) INNER JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND  A.CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.SR_NO = "), (object)Conversion.Val(text)), (object)" "));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV_DETL2)[4, num7].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)"");
						}
					}
					else
					{
						((DataGridView)dGV_DETL2)[4, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_NAME"]);
					}
					((DataGridView)dGV_DETL2)[5, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_AREA"]);
					((DataGridView)dGV_DETL2)[6, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_DETL2)[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_DETL2)[8, num7].Value = Math.Abs(num2 - num);
					if (num2 - num > 0.0)
					{
						((DataGridView)dGV_DETL2)[9, num7].Value = "Cr";
					}
					else if (num2 - num < 0.0)
					{
						((DataGridView)dGV_DETL2)[9, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[9, num7].Value = "";
					}
					((DataGridView)dGV_DETL2)[11, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_DETL2)[12, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					num7++;
					dGV_DETL2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total : ", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_DETL).Rows.Add();
					((DataGridView)DGV_DETL).Rows.Add();
				}
				int num9 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num9].Cells[4].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num9].Cells[6].Value = num;
				((DataGridView)DGV_DETL).Rows[num9].Cells[7].Value = num2;
				((DataGridView)DGV_DETL).Rows[num9].Cells[8].Value = Math.Abs(num2 - num);
				if (num2 - num > 0.0)
				{
					((DataGridView)DGV_DETL)[9, num9].Value = "Cr";
				}
				else if (num2 - num < 0.0)
				{
					((DataGridView)DGV_DETL)[9, num9].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL)[9, num9].Value = "";
				}
			}
			((TextBoxBase)tAcCode).SelectionStart = 0;
			((TextBoxBase)tAcCode).SelectionLength = Strings.Len(tAcCode.Text);
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
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 6) <= 2u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((Control)DGV_DETL).Refresh();
			BtnExit.Text = "&Exit";
			((Control)PnlAcSumm).Visible = true;
			((Control)lblLineSkip).Visible = false;
			((Control)nLineSkip).Visible = false;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_CASH_BANK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_CASH_BANK_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_CASH_BANK_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((DataGridView)DGV_DETL).DataSource = null;
				((DataGridView)DGV_DETL).ClearSelection();
				((DataGridView)DGV_DETL).Rows.Clear();
				((Control)DGV_DETL).Refresh();
				BtnExit.Text = "&Exit";
				((Control)PnlAcSumm).Visible = true;
				((Control)DGV).Focus();
			}
			else
			{
				((Form)this).Close();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		checked
		{
			if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM TEMP_AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				int num = (int)Math.Round(Conversion.Val(nLineSkip.Text));
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					DC_Main.RsQry = "INSERT INTO TEMP_AD_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_DATE,  SCHM_CODE,MEMB_CODE,REC_AC,ITM_GWT,ITM_RATE,REC_AMT,BAL_AMT,CHQ_NO)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000',0,Null,Null,  '','','',0,0,0,0,'')";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Cr[(short)0] = "HeaderPrint = 'N'";
					DC_Main.i++;
				}
				DC_Main.i = 0;
				int num2 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num2)
				{
					if (Operators.ConditionalCompareObjectNotEqual(((DataGridView)DGV_DETL)[14, DC_Main.i].Value, (object)"", false) && Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_DETL)[0, DC_Main.i].Value, (object)true, false))
					{
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TEMP_AD_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_DATE,  SCHM_CODE,MEMB_CODE,REC_AC,ITM_GWT,ITM_RATE,REC_AMT,BAL_AMT,CHQ_NO,GOLD_BAL)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), ((DataGridView)DGV_DETL)[14, DC_Main.i].Value), (object)"','"), ((DataGridView)DGV_DETL)[3, DC_Main.i].Value), (object)"',"), (object)(DC_Main.i + 1)), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)DGV_DETL)[4, DC_Main.i].Value), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)DGV_DETL)[5, DC_Main.i].Value), "MM/dd/yyyy")), (object)"', "), (object)" '"), ((DataGridView)DGV_DETL)[16, DC_Main.i].Value), (object)"','"), (object)tAcCode.Text), (object)"','"), ((DataGridView)DGV_DETL)[19, DC_Main.i].Value), (object)"',");
						DataGridViewCell val;
						object Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_DETL)[8, DC_Main.i]).Value);
						double num3 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num3), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_DETL)[7, DC_Main.i]).Value);
						double num4 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num4), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_DETL)[10, DC_Main.i]).Value);
						double num5 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num5), (object)",");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_DETL)[13, DC_Main.i]).Value);
						double num6 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num6), (object)",'',");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)DGV_DETL)[9, DC_Main.i]).Value);
						double num7 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num7), (object)")"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM TEMP_AD_DATA";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.RptName = "SchmPassBook";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptFormula = "{TEMP_AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "'";
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SchmPassBook.RPT";
					Cr.SelectionFormula = "{TEMP_AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' ";
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
					CurFormula = "";
				}
				return;
			}
			double num8 = 0.0;
			DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num8 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
			}
			CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " and {AC_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
			}
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
				DC_Main.MsRptTitelStr = "'Cash and Bank Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "FromDate";
				DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
				DC_Main.MsCrForName2 = "ToDate";
				DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
				DC_Main.MsCrForName3 = "AcOpAmt";
				DC_Main.MsCrForVal3 = Strings.Format((object)num8, "0.00");
				DC_Main.RptName = "AcLedger";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr.SelectionFormula = CurFormula;
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedger.RPT";
				Cr[(short)0] = "RptTitel = 'Cash and Bank Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
				Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
				Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num8, "0.00")) ?? "";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_CASH_BANK_Closed(object sender, EventArgs e)
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
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
		{
			DC_Main.RsQry = "Select * From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT SCHM_CODE As CodeL,SCHM_NAME as SchemeNameL, SCHM_AMT AS AmountR,SCHM_TYPE As SchmTypeM FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY SCHM_CODE";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 300.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[0];
						tAcName.Text = DC_Main.ColValue[1];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_NAME"], (object)""));
				DGV_DETL_SCHM();
			}
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ( '02','03','19','21','22','23') AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ( '02','03','19','21','22','23') AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
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
					DGV_DETL_FILL();
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_DETL_FILL();
			((Control)tAcCode).Focus();
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
		{
			if (Conversions.ToBoolean(Operators.AndObject((object)(DateTime.Compare(Conversions.ToDate(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[4].Value), DC_Main.MOp_dt) < 0), Operators.CompareObjectEqual(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[14].Value, (object)"076", false))))
			{
				Interaction.MsgBox((object)"Please check this entry in Last Year You cant open Last Year Member Adjust Entry.. In Current Year... ", (MsgBoxStyle)0, (object)null);
				return;
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[14].Value), (object)""), (object)"' "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[10].Value), (object)""), (object)"' "));
		}
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
		if (Operators.CompareString(CurRpt, "Scheme Ledger", false) == 0)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[3].Value, (object)""));
		}
		else
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
		}
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB OPENING", false) == 0))
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

	private void BtnJmaUdhar_Click(object sender, EventArgs e)
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
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# ";
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
			DC_Main.MsRptTitelStr = "'Cash and Bank Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "FromDate";
			DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
			DC_Main.MsCrForName2 = "ToDate";
			DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName3 = "OpBal";
			DC_Main.MsCrForVal3 = Strings.Format((object)num, "0.00");
			DC_Main.MsCrForName4 = "ClBal";
			DC_Main.MsCrForVal4 = Strings.Format((object)num2, "0.00");
			DC_Main.RptName = "JmUdAmt";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdAmt.RPT";
			Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num2, "0.00")) ?? "";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void cboScheme_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DGV_SCHM_FILL();
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		DGV_SCHM_FILL();
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

	private void nMembAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nMembAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nMembAmt.Text)), "0.00");
			SendKeys.Send("{tab}");
		}
	}

	private void chkSchmPanding_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DGV_SCHM_FILL();
		}
	}

	private void chkSchmPanding_CheckedChanged(object sender, EventArgs e)
	{
		chkComplete.Checked = false;
		DGV_SCHM_FILL();
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		DGV_DETL_SCHM();
	}

	private void DGV_DETL_SCHM()
	{
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_0cd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdb: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		((Control)PnlAcSumm).Visible = false;
		BtnExit.Text = "&Back";
		((Control)lblLineSkip).Visible = true;
		((Control)nLineSkip).Visible = true;
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		tAcCode.Text = Conversions.ToString(((DataGridView)DGV)[2, index].Value);
		tAcName.Text = Conversions.ToString(((DataGridView)DGV)[1, index].Value);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN OS_TYPE = 'A' THEN ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAmt,  Sum(CASE WHEN SIGN = '-' THEN (CASE WHEN OS_TYPE = 'D' THEN ADJ_AMT ELSE 0 END) ELSE 0 END) As AdjAmt ,  Sum(CASE WHEN SIGN = '-' THEN (CASE WHEN OS_TYPE = 'B' THEN ADJ_AMT ELSE 0 END) ELSE 0 END) As BonusAmt,  Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN OS_TYPE = 'A' THEN GOLD_WT ELSE 0 END) ELSE 0 END) as GlFine,  Sum(CASE WHEN SIGN = '-' THEN (CASE WHEN OS_TYPE = 'D' THEN GOLD_WT ELSE 0 END) ELSE 0 END) as AdjFine  FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MEMB_CODE = '" + tAcCode.Text + "' AND  MEMB_CODE = '"), ((DataGridView)DGV)[2, index].Value), (object)"' "), (object)" "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("And DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND SCHM_CODE = '"), (object)ArySchmCode[cboScheme.SelectedIndex]), (object)"' AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"), (object)" HAVING (Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN OS_TYPE = 'A' THEN ADJ_AMT ELSE 0 END) ELSE 0 END) <> 0 or Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN OS_TYPE = 'D' THEN ADJ_AMT ELSE 0 END) ELSE 0 END) <> 0 OR Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN OS_TYPE = 'B' THEN ADJ_AMT ELSE 0 END) ELSE 0 END) <> 0) "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* ,B.AC_NAME FROM AD_OS AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LD_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.MEMB_CODE = '" + tAcCode.Text + "' AND SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("And A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' ORDER BY A.VCH_DATE,SCHM_DATE,A.CO_BOOK "));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		if (dataTable.Rows.Count > 0)
		{
			num = Conversions.ToDouble(dataTable.Rows[0]["SchmAmt"]);
			num2 = Conversions.ToDouble(dataTable.Rows[0]["AdjAmt"]);
			num5 = Conversions.ToDouble(dataTable.Rows[0]["GlFine"]);
			num6 = Conversions.ToDouble(dataTable.Rows[0]["AdjFine"]);
			num3 = Conversions.ToDouble(dataTable.Rows[0]["BonusAmt"]);
			num4 = num - num2 - num3;
			num7 = num5 - num6;
		}
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridViewColumn)val).Name = "Select";
		checked
		{
			((DataGridViewColumn)val).Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add((DataGridViewColumn)(object)val);
			((DataGridView)DGV_DETL).Columns.Add("", "Sr");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Month");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Ledger Name");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(300.0 * ColCon);
			if (Operators.CompareString(CurSchmType, "G", false) == 0)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "GlRate");
				((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns.Add("", "GoldWt");
				((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns.Add("", "GoldBal");
				((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "RecAc");
				((DataGridView)DGV_DETL).Columns[7].Visible = false;
				((DataGridView)DGV_DETL).Columns.Add("", "RecAc");
				((DataGridView)DGV_DETL).Columns[8].Visible = false;
				((DataGridView)DGV_DETL).Columns.Add("", "RecAc");
				((DataGridView)DGV_DETL).Columns[9].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Schm amt");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Adj Amt");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bonus Amt");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Balance Amt");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "BookCode");
			((DataGridView)DGV_DETL).Columns[14].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[15].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "SchmeCode");
			((DataGridView)DGV_DETL).Columns[16].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "SchmYrCd");
			((DataGridView)DGV_DETL).Columns[17].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "SchmSrNo");
			((DataGridView)DGV_DETL).Columns[18].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "RecAc");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			int num8 = 0;
			if (num > 0.0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[1, num8].Value = num8 + 1;
				((DataGridView)dGV_DETL)[6, num8].Value = "Op Balance";
				num5 = Conversions.ToDouble(dataTable.Rows[0]["GlFine"]);
				num6 = Conversions.ToDouble(dataTable.Rows[0]["AdjFine"]);
				((DataGridView)dGV_DETL)[8, num8].Value = num5;
				((DataGridView)dGV_DETL)[9, num8].Value = num7;
				((DataGridView)dGV_DETL)[10, num8].Value = num;
				((DataGridView)dGV_DETL)[11, num8].Value = num2;
				((DataGridView)dGV_DETL)[12, num8].Value = num3;
				((DataGridView)dGV_DETL)[13, num8].Value = num4;
				num8++;
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count <= 0)
			{
				return;
			}
			int num9 = dataTable2.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num9)
			{
				DataGridViewX dGV_DETL2 = DGV_DETL;
				((DataGridView)dGV_DETL2).Rows.Add();
				((DataGridView)dGV_DETL2)[1, num8].Value = num8 + 1;
				((DataGridView)dGV_DETL2)[2, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_TYPE"]);
				((DataGridView)dGV_DETL2)[3, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
				((DataGridView)dGV_DETL2)[4, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV_DETL2)[5, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["SCHM_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV_DETL2)[6, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_NAME"]);
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_NAME"], (object)""), (object)"", false))
				{
					if (Operators.ConditionalCompareObjectNotEqual(dataTable2.Rows[DC_Main.M]["UPI_NAME"], (object)"", false))
					{
						((DataGridView)dGV_DETL2)[6, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["UPI_NAME"]);
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT UPI_TYPE,UPI_AMT,UPI_AC_NAME FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable2.Rows[DC_Main.M]["SR_NO"]), (object)" "));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							int num10 = DC_Main.Tbl.Rows.Count - 1;
							for (int i = 0; i <= num10; i++)
							{
								if (Operators.CompareString(DC_Main.SSRegSrNo, "DD012NPDD", false) == 0)
								{
									DataGridViewCell val2;
									DataGridViewCell obj = (val2 = ((DataGridView)dGV_DETL2)[6, num8]);
									object value = val2.Value;
									object obj2 = Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_AC_NAME"], (object)"/");
									Type? typeFromHandle = typeof(Math);
									DataRow dataRow;
									object[] obj3 = new object[2]
									{
										(dataRow = DC_Main.Tbl.Rows[i])["UPI_AMT"],
										0
									};
									object[] array = obj3;
									bool[] obj4 = new bool[2] { true, false };
									bool[] array2 = obj4;
									object obj5 = NewLateBinding.LateGet((object)null, typeFromHandle, "Round", obj3, (string[])null, (Type[])null, obj4);
									if (array2[0])
									{
										dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
									}
									obj.Value = Operators.AddObject(value, Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, obj5), (object)"  "));
								}
								else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_TYPE"], (object)""), (object)"", false))
								{
									DataGridViewCell val2;
									DataGridViewCell obj6 = (val2 = ((DataGridView)dGV_DETL2)[6, num8]);
									object value2 = val2.Value;
									object obj7 = Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_AC_NAME"], (object)"/");
									Type? typeFromHandle2 = typeof(Math);
									DataRow dataRow;
									object[] obj8 = new object[2]
									{
										(dataRow = DC_Main.Tbl.Rows[i])["UPI_AMT"],
										0
									};
									object[] array = obj8;
									bool[] obj9 = new bool[2] { true, false };
									bool[] array2 = obj9;
									object obj10 = NewLateBinding.LateGet((object)null, typeFromHandle2, "Round", obj8, (string[])null, (Type[])null, obj9);
									if (array2[0])
									{
										dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
									}
									obj6.Value = Operators.AddObject(value2, Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, obj10), (object)"  "));
								}
								else
								{
									DataGridViewCell val2;
									DataGridViewCell obj11 = (val2 = ((DataGridView)dGV_DETL2)[6, num8]);
									object value3 = val2.Value;
									object obj12 = Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_TYPE"], (object)"/");
									Type? typeFromHandle3 = typeof(Math);
									DataRow dataRow;
									object[] obj13 = new object[2]
									{
										(dataRow = DC_Main.Tbl.Rows[i])["UPI_AMT"],
										0
									};
									object[] array = obj13;
									bool[] obj14 = new bool[2] { true, false };
									bool[] array2 = obj14;
									object obj15 = NewLateBinding.LateGet((object)null, typeFromHandle3, "Round", obj13, (string[])null, (Type[])null, obj14);
									if (array2[0])
									{
										dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
									}
									obj11.Value = Operators.AddObject(value3, Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, obj15), (object)"  "));
								}
							}
						}
					}
				}
				((DataGridView)dGV_DETL2)[15, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
				if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["OS_TYPE"], (object)"A", false))
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_DETL2)[15, num8].Value, (object)"MEMB ENTRY", false))
					{
						((DataGridView)dGV_DETL2)[2, num8].Value = "REC";
					}
					else
					{
						((DataGridView)dGV_DETL2)[2, num8].Value = "OPN";
					}
					((DataGridView)dGV_DETL2)[7, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ITM_RATE"]), "0.00");
					((DataGridView)dGV_DETL2)[8, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["GOLD_WT"]), "0.000");
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[8, num8].Value));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[8, num8].Value));
					((DataGridView)dGV_DETL2)[9, num8].Value = Strings.Format((object)num7, "0.000");
					((DataGridView)dGV_DETL2)[10, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ADJ_AMT"]), "0.00");
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[10, num8].Value));
					((DataGridView)dGV_DETL2)[13, num8].Value = Strings.Format((object)num4, "0.00");
				}
				else if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["OS_TYPE"], (object)"D", false))
				{
					((DataGridView)dGV_DETL2)[8, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["GOLD_WT"]), "0.000");
					num7 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[8, num8].Value));
					((DataGridView)dGV_DETL2)[9, num8].Value = Strings.Format((object)num7, "0.000");
					((DataGridView)dGV_DETL2)[11, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ADJ_AMT"]), "0.00");
					num4 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[11, num8].Value));
					((DataGridView)dGV_DETL2)[13, num8].Value = Strings.Format((object)num4, "0.00");
					num6 = 0.0;
				}
				else
				{
					((DataGridView)dGV_DETL2)[2, num8].Value = "BON";
					((DataGridView)dGV_DETL2)[12, num8].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["ADJ_AMT"]), "0.00");
					((DataGridView)dGV_DETL2)[13, num8].Value = Strings.Format((object)num4, "0.00");
				}
				num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[10, num8].Value));
				num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[11, num8].Value));
				num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL2)[12, num8].Value));
				((DataGridView)dGV_DETL2)[14, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
				((DataGridView)dGV_DETL2)[16, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["SCHM_CODE"]);
				((DataGridView)dGV_DETL2)[17, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_YEAR"]);
				((DataGridView)dGV_DETL2)[18, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["SR_NO"]);
				((DataGridView)dGV_DETL2)[19, num8].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LD_CODE"]);
				num8++;
				dGV_DETL2 = null;
				DC_Main.M++;
			}
			if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"", false))))
			{
				((DataGridView)DGV_DETL).Rows.Add();
				((DataGridView)DGV_DETL).Rows.Add();
			}
			int num11 = ((DataGridView)DGV_DETL).Rows.Count - 1;
			((DataGridView)DGV_DETL).Rows[num11].Cells[4].Value = " Grand Total :";
			((DataGridView)DGV_DETL).Rows[num11].Cells[10].Value = num;
			((DataGridView)DGV_DETL).Rows[num11].Cells[11].Value = num2;
			((DataGridView)DGV_DETL).Rows[num11].Cells[12].Value = num3;
			((DataGridView)DGV_DETL).Rows[num11].Cells[13].Value = num4;
			((DataGridView)DGV_DETL).Rows[num11].Cells[8].Value = num5;
			((DataGridView)DGV_DETL).Rows[num11].Cells[9].Value = num7;
		}
	}

	private void cboScheme_SelectedIndexChanged(object sender, EventArgs e)
	{
		((Control)cboScheme).Focus();
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		Keys keyCode = e.KeyCode;
		if ((int)keyCode != 38)
		{
			if ((int)keyCode == 40)
			{
				((Control)DGV).Focus();
			}
		}
		else
		{
			((Control)DGV).Focus();
		}
		if ((int)e.KeyCode == 13)
		{
			DGV_DoubleClick(DGV, new EventArgs());
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
						tBookName.Text = DC_Main.ColValue[0];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));
				if (Operators.CompareString(CurRpt, "Scheme Ledger", false) != 0)
				{
					DGV_DETL_FILL();
				}
			}
		}
		else
		{
			tBookName.Text = "";
			if (Operators.CompareString(CurRpt, "Scheme Ledger", false) != 0)
			{
				DGV_DETL_FILL();
			}
		}
	}

	private void tMembCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.MEMB_CODE,A.MEMB_NAME,A.SCHM_CODE FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "' AND A.MEMB_CODE = '" + tMembCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.MEMB_CODE as MembNoL,A.MEMB_NAME As MembNameL,A.AC_MOBILE AS MobileL,A.SCHM_CODE AS SchemeL ,A.MEMB_AMT AS SchmAmtR,FORMAT(SUM(IIF(SIGN = '+',B.ADJ_AMT,- B.ADJ_AMT)),'0.00') AS MembBalR  FROM AD_MEMB AS A LEFT JOIN AD_OS AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SCHM_CODE = '" + ArySchmCode[cboScheme.SelectedIndex] + "'  GROUP BY A.MEMB_CODE,A.MEMB_NAME,A.SCHM_CODE,A.MEMB_AMT,A.AC_MOBILE ORDER BY A.SCHM_CODE,A.MEMB_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.ColWidth[2] = 150.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.ColWidth[4] = 120.0;
			DC_Main.ColWidth[5] = 120.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tMembCode.Text = DC_Main.ColValue[0];
				}
				((Control)tMembCode).Focus();
			}
		}
		else
		{
			tMembCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_CODE"], (object)""));
			DGV_SCHM_FILL();
		}
	}

	private void chkComplete_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DGV_SCHM_FILL();
		}
	}

	private void chkComplete_CheckedChanged(object sender, EventArgs e)
	{
		chkSchmPanding.Checked = false;
		DGV_SCHM_FILL();
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}
}
