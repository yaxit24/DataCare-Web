using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxMSFlexGridLib;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_SETTING : Form
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
	[AccessedThroughProperty("cboColSet")]
	private ComboBox _cboColSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private FlowLayoutPanel _PnlBotam;

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
	[AccessedThroughProperty("BtnColumnSet")]
	private QButton _BtnColumnSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLbrType")]
	private QButton _btnLbrType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnRateType")]
	private QButton _BtnRateType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTaxRof")]
	private QButton _BtnTaxRof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTagRowChange")]
	private QButton _BtnTagRowChange;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLbrGen")]
	private QButton _BtnLbrGen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnRateOpn")]
	private QButton _BtnRateOpn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnOpDhrn")]
	private QButton _BtnOpDhrn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDhrnType")]
	private QButton _btnDhrnType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnHelpSearch")]
	private QButton _btnHelpSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLdrSumm")]
	private QButton _btnLdrSumm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnReminder")]
	private QButton _btnReminder;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLbrRof")]
	private QButton _btnLbrRof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlRateRof")]
	private QButton _btnSlRateRof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcLbr")]
	private QButton _btnPurcLbr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnRptType")]
	private QButton _BtnRptType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWhTch")]
	private QButton _btnWhTch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPanCardVal")]
	private QButton _btnPanCardVal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDhrnIntPrc")]
	private QButton _btnDhrnIntPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDupPrint")]
	private QButton _BtnDupPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCashPurcAc")]
	private QButton _btnCashPurcAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLoanSet")]
	private QButton _btnLoanSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOzConv")]
	private QButton _btnOzConv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFxRate")]
	private QButton _btnFxRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFxCode")]
	private QButton _btnFxCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPrintZoom")]
	private QButton _btnPrintZoom;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private bool MsgClear;

	private bool UpDown;

	private bool Msgleft;

	private int MsgOldRow;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private const int cSrNo = 0;

	private const int cColName = 1;

	private const int cNewColName = 2;

	private const int cColRpt = 3;

	private const int cColShow = 4;

	private const int cBookName = 5;

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
			EventHandler eventHandler2 = MSG_RowColChange;
			EventHandler eventHandler3 = MSG_EnterCell;
			EventHandler eventHandler4 = MSG_LeaveCell;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.RowColChange -= eventHandler2;
				val.EnterCell -= eventHandler3;
				val.LeaveCell -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.RowColChange += eventHandler2;
				val.EnterCell += eventHandler3;
				val.LeaveCell += eventHandler4;
			}
		}
	}

	internal virtual ComboBox cboColSet
	{
		[CompilerGenerated]
		get
		{
			return _cboColSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = cboColSet_Click;
			KeyEventHandler val = new KeyEventHandler(cboColSet_KeyDown);
			ComboBox val2 = _cboColSet;
			if (val2 != null)
			{
				((Control)val2).Click -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_cboColSet = value;
			val2 = _cboColSet;
			if (val2 != null)
			{
				((Control)val2).Click += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual FlowLayoutPanel PnlBotam
	{
		[CompilerGenerated]
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PnlBotam_DoubleClick;
			FlowLayoutPanel val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PnlBotam = value;
			val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private virtual SimpleButton _BtnDelete;

	internal virtual SimpleButton BtnDelete
	{
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnDelete = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private virtual SimpleButton _BtnPrint;

	internal virtual SimpleButton BtnPrint
	{
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnPrint = value;
		}
	}

	internal virtual QButton BtnColumnSet
	{
		[CompilerGenerated]
		get
		{
			return _BtnColumnSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnColumnSet_Click;
			QButton val = _BtnColumnSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnColumnSet = value;
			val = _BtnColumnSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLbrType")]
	private virtual ComboBox _cboLbrType;

	internal virtual ComboBox cboLbrType
	{
		get
		{
			return _cboLbrType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboLbrType = value;
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

	internal virtual QButton btnLbrType
	{
		[CompilerGenerated]
		get
		{
			return _btnLbrType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLbrType_Click;
			QButton val = _btnLbrType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLbrType = value;
			val = _btnLbrType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnRateType
	{
		[CompilerGenerated]
		get
		{
			return _BtnRateType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRateType_Click;
			QButton val = _BtnRateType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnRateType = value;
			val = _BtnRateType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRateType")]
	private virtual ComboBox _cboRateType;

	internal virtual ComboBox cboRateType
	{
		get
		{
			return _cboRateType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboRateType = value;
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

	internal virtual QButton BtnTaxRof
	{
		[CompilerGenerated]
		get
		{
			return _BtnTaxRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTaxRof_Click;
			QButton val = _BtnTaxRof;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTaxRof = value;
			val = _BtnTaxRof;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTaxRof")]
	private virtual ComboBox _cboTaxRof;

	internal virtual ComboBox cboTaxRof
	{
		get
		{
			return _cboTaxRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTaxRof = value;
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

	internal virtual QButton BtnTagRowChange
	{
		[CompilerGenerated]
		get
		{
			return _BtnTagRowChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagRowChange_Click;
			QButton val = _BtnTagRowChange;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTagRowChange = value;
			val = _BtnTagRowChange;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTagRowChange")]
	private virtual ComboBox _cboTagRowChange;

	internal virtual ComboBox cboTagRowChange
	{
		get
		{
			return _cboTagRowChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTagRowChange = value;
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

	internal virtual QButton BtnLbrGen
	{
		[CompilerGenerated]
		get
		{
			return _BtnLbrGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLbrGen_Click;
			QButton val = _BtnLbrGen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnLbrGen = value;
			val = _BtnLbrGen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbolbrRateGen")]
	private virtual ComboBox _cbolbrRateGen;

	internal virtual ComboBox cbolbrRateGen
	{
		get
		{
			return _cbolbrRateGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cbolbrRateGen = value;
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

	internal virtual QButton BtnRateOpn
	{
		[CompilerGenerated]
		get
		{
			return _BtnRateOpn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRateOpn_Click;
			QButton val = _BtnRateOpn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnRateOpn = value;
			val = _BtnRateOpn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRateOpen")]
	private virtual ComboBox _cboRateOpen;

	internal virtual ComboBox cboRateOpen
	{
		get
		{
			return _cboRateOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboRateOpen = value;
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

	internal virtual QButton BtnOpDhrn
	{
		[CompilerGenerated]
		get
		{
			return _BtnOpDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOpDhrn_Click;
			QButton val = _BtnOpDhrn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnOpDhrn = value;
			val = _BtnOpDhrn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOpDhrn")]
	private virtual ComboBox _cboOpDhrn;

	internal virtual ComboBox cboOpDhrn
	{
		get
		{
			return _cboOpDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOpDhrn = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label9")]
	private virtual Label _Label9;

	internal virtual Label Label9
	{
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label9 = value;
		}
	}

	internal virtual QButton btnDhrnType
	{
		[CompilerGenerated]
		get
		{
			return _btnDhrnType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDhrnType_Click;
			QButton val = _btnDhrnType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDhrnType = value;
			val = _btnDhrnType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDhrnType")]
	private virtual ComboBox _cboDhrnType;

	internal virtual ComboBox cboDhrnType
	{
		get
		{
			return _cboDhrnType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDhrnType = value;
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

	internal virtual QButton btnHelpSearch
	{
		[CompilerGenerated]
		get
		{
			return _btnHelpSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnHelpSearch_Click;
			QButton val = _btnHelpSearch;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnHelpSearch = value;
			val = _btnHelpSearch;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboHelpSearch")]
	private virtual ComboBox _cboHelpSearch;

	internal virtual ComboBox cboHelpSearch
	{
		get
		{
			return _cboHelpSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboHelpSearch = value;
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

	internal virtual QButton btnLdrSumm
	{
		[CompilerGenerated]
		get
		{
			return _btnLdrSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLdrSumm_Click;
			QButton val = _btnLdrSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLdrSumm = value;
			val = _btnLdrSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLdrSumm")]
	private virtual ComboBox _cboLdrSumm;

	internal virtual ComboBox cboLdrSumm
	{
		get
		{
			return _cboLdrSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboLdrSumm = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label12")]
	private virtual Label _Label12;

	internal virtual Label Label12
	{
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label12 = value;
		}
	}

	internal virtual QButton btnReminder
	{
		[CompilerGenerated]
		get
		{
			return _btnReminder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnReminder_Click;
			QButton val = _btnReminder;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReminder = value;
			val = _btnReminder;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboReminder")]
	private virtual ComboBox _cboReminder;

	internal virtual ComboBox cboReminder
	{
		get
		{
			return _cboReminder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboReminder = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label13")]
	private virtual Label _Label13;

	internal virtual Label Label13
	{
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual QButton btnLbrRof
	{
		[CompilerGenerated]
		get
		{
			return _btnLbrRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLbrRof_Click;
			QButton val = _btnLbrRof;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLbrRof = value;
			val = _btnLbrRof;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbolbrrof")]
	private virtual ComboBox _cbolbrrof;

	internal virtual ComboBox cbolbrrof
	{
		get
		{
			return _cbolbrrof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cbolbrrof = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label14")]
	private virtual Label _Label14;

	internal virtual Label Label14
	{
		get
		{
			return _Label14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label14 = value;
		}
	}

	internal virtual QButton btnSlRateRof
	{
		[CompilerGenerated]
		get
		{
			return _btnSlRateRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlRateRof_Click;
			QButton val = _btnSlRateRof;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlRateRof = value;
			val = _btnSlRateRof;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSlRateRof")]
	private virtual ComboBox _cboSlRateRof;

	internal virtual ComboBox cboSlRateRof
	{
		get
		{
			return _cboSlRateRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSlRateRof = value;
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

	internal virtual QButton btnPurcLbr
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcLbr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurcLbr_Click;
			QButton val = _btnPurcLbr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcLbr = value;
			val = _btnPurcLbr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPurcLbr")]
	private virtual ComboBox _cboPurcLbr;

	internal virtual ComboBox cboPurcLbr
	{
		get
		{
			return _cboPurcLbr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPurcLbr = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label18")]
	private virtual Label _Label18;

	internal virtual Label Label18
	{
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label18 = value;
		}
	}

	internal virtual QButton BtnRptType
	{
		[CompilerGenerated]
		get
		{
			return _BtnRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRptType_Click;
			QButton val = _BtnRptType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnRptType = value;
			val = _BtnRptType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboStkRptType")]
	private virtual ComboBox _cboStkRptType;

	internal virtual ComboBox cboStkRptType
	{
		get
		{
			return _cboStkRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboStkRptType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label19")]
	private virtual Label _Label19;

	internal virtual Label Label19
	{
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label19 = value;
		}
	}

	internal virtual QButton btnWhTch
	{
		[CompilerGenerated]
		get
		{
			return _btnWhTch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnWhTch_Click;
			QButton val = _btnWhTch;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhTch = value;
			val = _btnWhTch;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboWhTch")]
	private virtual ComboBox _cboWhTch;

	internal virtual ComboBox cboWhTch
	{
		get
		{
			return _cboWhTch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboWhTch = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label20")]
	private virtual Label _Label20;

	internal virtual Label Label20
	{
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label20 = value;
		}
	}

	internal virtual QButton btnPanCardVal
	{
		[CompilerGenerated]
		get
		{
			return _btnPanCardVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPanCardVal_Click;
			QButton val = _btnPanCardVal;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPanCardVal = value;
			val = _btnPanCardVal;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPanCardVal")]
	private virtual ComboBox _cboPanCardVal;

	internal virtual ComboBox cboPanCardVal
	{
		get
		{
			return _cboPanCardVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPanCardVal = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label21")]
	private virtual Label _Label21;

	internal virtual Label Label21
	{
		get
		{
			return _Label21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label21 = value;
		}
	}

	internal virtual QButton btnDhrnIntPrc
	{
		[CompilerGenerated]
		get
		{
			return _btnDhrnIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnDhrnIntPrc_Click;
			QButton val = _btnDhrnIntPrc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDhrnIntPrc = value;
			val = _btnDhrnIntPrc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDhrnIntPrc")]
	private virtual ComboBox _cboDhrnIntPrc;

	internal virtual ComboBox cboDhrnIntPrc
	{
		get
		{
			return _cboDhrnIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDhrnIntPrc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label22")]
	private virtual Label _Label22;

	internal virtual Label Label22
	{
		get
		{
			return _Label22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label22 = value;
		}
	}

	internal virtual QButton BtnDupPrint
	{
		[CompilerGenerated]
		get
		{
			return _BtnDupPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDupPrint_Click;
			QButton val = _BtnDupPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDupPrint = value;
			val = _BtnDupPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDupPrint")]
	private virtual ComboBox _cboDupPrint;

	internal virtual ComboBox cboDupPrint
	{
		get
		{
			return _cboDupPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDupPrint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label23")]
	private virtual Label _Label23;

	internal virtual Label Label23
	{
		get
		{
			return _Label23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label23 = value;
		}
	}

	internal virtual QButton btnCashPurcAc
	{
		[CompilerGenerated]
		get
		{
			return _btnCashPurcAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCashPurcAc_Click;
			QButton val = _btnCashPurcAc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCashPurcAc = value;
			val = _btnCashPurcAc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPurcAc")]
	private virtual ComboBox _cboPurcAc;

	internal virtual ComboBox cboPurcAc
	{
		get
		{
			return _cboPurcAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPurcAc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	private virtual Label _Label16;

	internal virtual Label Label16
	{
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label16 = value;
		}
	}

	internal virtual QButton btnLoanSet
	{
		[CompilerGenerated]
		get
		{
			return _btnLoanSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLoanSet_Click;
			QButton val = _btnLoanSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLoanSet = value;
			val = _btnLoanSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOpLoan")]
	private virtual ComboBox _cboOpLoan;

	internal virtual ComboBox cboOpLoan
	{
		get
		{
			return _cboOpLoan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOpLoan = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlUAE")]
	private virtual Panel _pnlUAE;

	internal virtual Panel pnlUAE
	{
		get
		{
			return _pnlUAE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlUAE = value;
		}
	}

	internal virtual QButton btnOzConv
	{
		[CompilerGenerated]
		get
		{
			return _btnOzConv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOzConv_Click;
			QButton val = _btnOzConv;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOzConv = value;
			val = _btnOzConv;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOzCon")]
	private virtual ComboBox _cboOzCon;

	internal virtual ComboBox cboOzCon
	{
		get
		{
			return _cboOzCon;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOzCon = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label25")]
	private virtual Label _Label25;

	internal virtual Label Label25
	{
		get
		{
			return _Label25;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label25 = value;
		}
	}

	internal virtual QButton btnFxRate
	{
		[CompilerGenerated]
		get
		{
			return _btnFxRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnFxRate_Click;
			QButton val = _btnFxRate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFxRate = value;
			val = _btnFxRate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboFxRate")]
	private virtual ComboBox _cboFxRate;

	internal virtual ComboBox cboFxRate
	{
		get
		{
			return _cboFxRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFxRate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label24")]
	private virtual Label _Label24;

	internal virtual Label Label24
	{
		get
		{
			return _Label24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label24 = value;
		}
	}

	internal virtual QButton btnFxCode
	{
		[CompilerGenerated]
		get
		{
			return _btnFxCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnFxCode_Click;
			QButton val = _btnFxCode;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFxCode = value;
			val = _btnFxCode;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboFxCode")]
	private virtual ComboBox _cboFxCode;

	internal virtual ComboBox cboFxCode
	{
		get
		{
			return _cboFxCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFxCode = value;
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

	internal virtual QButton btnPrintZoom
	{
		[CompilerGenerated]
		get
		{
			return _btnPrintZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPrintZoom_Click;
			QButton val = _btnPrintZoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPrintZoom = value;
			val = _btnPrintZoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintZoom")]
	private virtual ComboBox _cboPrintZoom;

	internal virtual ComboBox cboPrintZoom
	{
		get
		{
			return _cboPrintZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintZoom = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label26")]
	private virtual Label _Label26;

	internal virtual Label Label26
	{
		get
		{
			return _Label26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label26 = value;
		}
	}

	public UT_SETTING()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((Form)this).Load += UT_SETTING_Load;
		((Form)this).Activated += UT_SETTING_Activated;
		((Form)this).Deactivate += UT_SETTING_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_SETTING_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_SETTING_KeyDown);
		((Control)this).KeyUp += new KeyEventHandler(UT_SETTING_KeyUp);
		((Form)this).Closed += UT_SETTING_Closed;
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
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected O, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Expected O, but got Unknown
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Expected O, but got Unknown
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Expected O, but got Unknown
		//IL_09d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dc: Expected O, but got Unknown
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Expected O, but got Unknown
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c16: Expected O, but got Unknown
		//IL_0c79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Expected O, but got Unknown
		//IL_0d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d35: Expected O, but got Unknown
		//IL_0d98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da2: Expected O, but got Unknown
		//IL_1045: Unknown result type (might be due to invalid IL or missing references)
		//IL_1069: Unknown result type (might be due to invalid IL or missing references)
		//IL_108d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Expected O, but got Unknown
		//IL_1107: Unknown result type (might be due to invalid IL or missing references)
		//IL_1188: Unknown result type (might be due to invalid IL or missing references)
		//IL_1192: Expected O, but got Unknown
		//IL_120d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1217: Expected O, but got Unknown
		//IL_14b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1521: Unknown result type (might be due to invalid IL or missing references)
		//IL_154a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1554: Expected O, but got Unknown
		//IL_1577: Unknown result type (might be due to invalid IL or missing references)
		//IL_17db: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1823: Unknown result type (might be due to invalid IL or missing references)
		//IL_1847: Unknown result type (might be due to invalid IL or missing references)
		//IL_1870: Unknown result type (might be due to invalid IL or missing references)
		//IL_187a: Expected O, but got Unknown
		//IL_189d: Unknown result type (might be due to invalid IL or missing references)
		//IL_191e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1928: Expected O, but got Unknown
		//IL_19a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ad: Expected O, but got Unknown
		//IL_1c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cea: Expected O, but got Unknown
		//IL_1d10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9b: Expected O, but got Unknown
		//IL_1e19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e23: Expected O, but got Unknown
		//IL_20c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_210c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2130: Unknown result type (might be due to invalid IL or missing references)
		//IL_2159: Unknown result type (might be due to invalid IL or missing references)
		//IL_2163: Expected O, but got Unknown
		//IL_2189: Unknown result type (might be due to invalid IL or missing references)
		//IL_220a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2214: Expected O, but got Unknown
		//IL_2292: Unknown result type (might be due to invalid IL or missing references)
		//IL_229c: Expected O, but got Unknown
		//IL_253d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2561: Unknown result type (might be due to invalid IL or missing references)
		//IL_2585: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25dc: Expected O, but got Unknown
		//IL_2602: Unknown result type (might be due to invalid IL or missing references)
		//IL_2683: Unknown result type (might be due to invalid IL or missing references)
		//IL_268d: Expected O, but got Unknown
		//IL_270b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2715: Expected O, but got Unknown
		//IL_29b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_29da: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a55: Expected O, but got Unknown
		//IL_2a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b06: Expected O, but got Unknown
		//IL_2b84: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8e: Expected O, but got Unknown
		//IL_2e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ece: Expected O, but got Unknown
		//IL_2ef4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f7f: Expected O, but got Unknown
		//IL_2ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3007: Expected O, but got Unknown
		//IL_32a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_32cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_32f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3314: Unknown result type (might be due to invalid IL or missing references)
		//IL_333d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3347: Expected O, but got Unknown
		//IL_336d: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_33f8: Expected O, but got Unknown
		//IL_3476: Unknown result type (might be due to invalid IL or missing references)
		//IL_3480: Expected O, but got Unknown
		//IL_3721: Unknown result type (might be due to invalid IL or missing references)
		//IL_3745: Unknown result type (might be due to invalid IL or missing references)
		//IL_3769: Unknown result type (might be due to invalid IL or missing references)
		//IL_378d: Unknown result type (might be due to invalid IL or missing references)
		//IL_37b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_37c0: Expected O, but got Unknown
		//IL_37e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3864: Unknown result type (might be due to invalid IL or missing references)
		//IL_386e: Expected O, but got Unknown
		//IL_38e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_38f3: Expected O, but got Unknown
		//IL_3b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c30: Expected O, but got Unknown
		//IL_3c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cde: Expected O, but got Unknown
		//IL_3d59: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d63: Expected O, but got Unknown
		//IL_4001: Unknown result type (might be due to invalid IL or missing references)
		//IL_4025: Unknown result type (might be due to invalid IL or missing references)
		//IL_4049: Unknown result type (might be due to invalid IL or missing references)
		//IL_406d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4096: Unknown result type (might be due to invalid IL or missing references)
		//IL_40a0: Expected O, but got Unknown
		//IL_40c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4147: Unknown result type (might be due to invalid IL or missing references)
		//IL_4151: Expected O, but got Unknown
		//IL_41cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d9: Expected O, but got Unknown
		//IL_447a: Unknown result type (might be due to invalid IL or missing references)
		//IL_449e: Unknown result type (might be due to invalid IL or missing references)
		//IL_44c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_44e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_450f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4519: Expected O, but got Unknown
		//IL_453f: Unknown result type (might be due to invalid IL or missing references)
		//IL_45c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_45ca: Expected O, but got Unknown
		//IL_4648: Unknown result type (might be due to invalid IL or missing references)
		//IL_4652: Expected O, but got Unknown
		//IL_48f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4917: Unknown result type (might be due to invalid IL or missing references)
		//IL_493b: Unknown result type (might be due to invalid IL or missing references)
		//IL_495f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4988: Unknown result type (might be due to invalid IL or missing references)
		//IL_4992: Expected O, but got Unknown
		//IL_49b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a43: Expected O, but got Unknown
		//IL_4ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4acb: Expected O, but got Unknown
		//IL_4d6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d90: Unknown result type (might be due to invalid IL or missing references)
		//IL_4db4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e01: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e0b: Expected O, but got Unknown
		//IL_4e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_4eb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ebc: Expected O, but got Unknown
		//IL_4f3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f44: Expected O, but got Unknown
		//IL_51e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5209: Unknown result type (might be due to invalid IL or missing references)
		//IL_522d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5251: Unknown result type (might be due to invalid IL or missing references)
		//IL_527a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5284: Expected O, but got Unknown
		//IL_52aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_532b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5335: Expected O, but got Unknown
		//IL_53b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_53bd: Expected O, but got Unknown
		//IL_565e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5682: Unknown result type (might be due to invalid IL or missing references)
		//IL_56a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_56ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_56f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_56fd: Expected O, but got Unknown
		//IL_5723: Unknown result type (might be due to invalid IL or missing references)
		//IL_57a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_57ae: Expected O, but got Unknown
		//IL_582c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5836: Expected O, but got Unknown
		//IL_5ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b76: Expected O, but got Unknown
		//IL_5b9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c27: Expected O, but got Unknown
		//IL_5ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5caf: Expected O, but got Unknown
		//IL_5f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f74: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f98: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fe5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fef: Expected O, but got Unknown
		//IL_6015: Unknown result type (might be due to invalid IL or missing references)
		//IL_6096: Unknown result type (might be due to invalid IL or missing references)
		//IL_60a0: Expected O, but got Unknown
		//IL_611e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6128: Expected O, but got Unknown
		//IL_63c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_63ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_6411: Unknown result type (might be due to invalid IL or missing references)
		//IL_6435: Unknown result type (might be due to invalid IL or missing references)
		//IL_645e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6468: Expected O, but got Unknown
		//IL_648e: Unknown result type (might be due to invalid IL or missing references)
		//IL_650f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6519: Expected O, but got Unknown
		//IL_6597: Unknown result type (might be due to invalid IL or missing references)
		//IL_65a1: Expected O, but got Unknown
		//IL_6842: Unknown result type (might be due to invalid IL or missing references)
		//IL_6866: Unknown result type (might be due to invalid IL or missing references)
		//IL_688a: Unknown result type (might be due to invalid IL or missing references)
		//IL_68ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_68d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_68e1: Expected O, but got Unknown
		//IL_6907: Unknown result type (might be due to invalid IL or missing references)
		//IL_6999: Unknown result type (might be due to invalid IL or missing references)
		//IL_69a3: Expected O, but got Unknown
		//IL_6a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a2b: Expected O, but got Unknown
		//IL_6ccc: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d14: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d61: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d6b: Expected O, but got Unknown
		//IL_6d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e12: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e1c: Expected O, but got Unknown
		//IL_6e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ea4: Expected O, but got Unknown
		//IL_7276: Unknown result type (might be due to invalid IL or missing references)
		//IL_729a: Unknown result type (might be due to invalid IL or missing references)
		//IL_72be: Unknown result type (might be due to invalid IL or missing references)
		//IL_72e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_730b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7315: Expected O, but got Unknown
		//IL_7338: Unknown result type (might be due to invalid IL or missing references)
		//IL_73b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_73c3: Expected O, but got Unknown
		//IL_743e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7448: Expected O, but got Unknown
		//IL_76e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_7707: Unknown result type (might be due to invalid IL or missing references)
		//IL_772b: Unknown result type (might be due to invalid IL or missing references)
		//IL_774f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7778: Unknown result type (might be due to invalid IL or missing references)
		//IL_7782: Expected O, but got Unknown
		//IL_77a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_7826: Unknown result type (might be due to invalid IL or missing references)
		//IL_7830: Expected O, but got Unknown
		//IL_78ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_78b5: Expected O, but got Unknown
		//IL_7b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_7bbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_7be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_7bef: Expected O, but got Unknown
		//IL_7c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c93: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c9d: Expected O, but got Unknown
		//IL_7d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d22: Expected O, but got Unknown
		//IL_7fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_7fe1: Unknown result type (might be due to invalid IL or missing references)
		//IL_8005: Unknown result type (might be due to invalid IL or missing references)
		//IL_8029: Unknown result type (might be due to invalid IL or missing references)
		//IL_8052: Unknown result type (might be due to invalid IL or missing references)
		//IL_805c: Expected O, but got Unknown
		//IL_8082: Unknown result type (might be due to invalid IL or missing references)
		//IL_8114: Unknown result type (might be due to invalid IL or missing references)
		//IL_811e: Expected O, but got Unknown
		//IL_819c: Unknown result type (might be due to invalid IL or missing references)
		//IL_81a6: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_SETTING));
		lblBook = new Label();
		Label2 = new Label();
		TEXT_ENTRY = new TextBox();
		MSG = new AxMSFlexGrid();
		cboColSet = new ComboBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnColumnSet = new QButton();
		cboLbrType = new ComboBox();
		Label1 = new Label();
		btnLbrType = new QButton();
		BtnRateType = new QButton();
		cboRateType = new ComboBox();
		Label3 = new Label();
		BtnTaxRof = new QButton();
		cboTaxRof = new ComboBox();
		Label4 = new Label();
		BtnTagRowChange = new QButton();
		cboTagRowChange = new ComboBox();
		Label5 = new Label();
		BtnLbrGen = new QButton();
		cbolbrRateGen = new ComboBox();
		Label6 = new Label();
		BtnRateOpn = new QButton();
		cboRateOpen = new ComboBox();
		Label7 = new Label();
		BtnOpDhrn = new QButton();
		cboOpDhrn = new ComboBox();
		Label9 = new Label();
		btnDhrnType = new QButton();
		cboDhrnType = new ComboBox();
		Label10 = new Label();
		btnHelpSearch = new QButton();
		cboHelpSearch = new ComboBox();
		Label11 = new Label();
		btnLdrSumm = new QButton();
		cboLdrSumm = new ComboBox();
		Label12 = new Label();
		btnReminder = new QButton();
		cboReminder = new ComboBox();
		Label13 = new Label();
		btnLbrRof = new QButton();
		cbolbrrof = new ComboBox();
		Label14 = new Label();
		btnSlRateRof = new QButton();
		cboSlRateRof = new ComboBox();
		Label15 = new Label();
		btnPurcLbr = new QButton();
		cboPurcLbr = new ComboBox();
		Label18 = new Label();
		BtnRptType = new QButton();
		cboStkRptType = new ComboBox();
		Label19 = new Label();
		btnWhTch = new QButton();
		cboWhTch = new ComboBox();
		Label20 = new Label();
		btnPanCardVal = new QButton();
		cboPanCardVal = new ComboBox();
		Label21 = new Label();
		btnDhrnIntPrc = new QButton();
		cboDhrnIntPrc = new ComboBox();
		Label22 = new Label();
		BtnDupPrint = new QButton();
		cboDupPrint = new ComboBox();
		Label23 = new Label();
		btnCashPurcAc = new QButton();
		cboPurcAc = new ComboBox();
		Label16 = new Label();
		btnLoanSet = new QButton();
		cboOpLoan = new ComboBox();
		Label17 = new Label();
		pnlUAE = new Panel();
		btnOzConv = new QButton();
		cboOzCon = new ComboBox();
		Label25 = new Label();
		btnFxRate = new QButton();
		cboFxRate = new ComboBox();
		Label24 = new Label();
		btnFxCode = new QButton();
		cboFxCode = new ComboBox();
		Label8 = new Label();
		btnPrintZoom = new QButton();
		cboPrintZoom = new ComboBox();
		Label26 = new Label();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)pnlUAE).SuspendLayout();
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
		lblBook.Text = "Company Setting";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(15, 64);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(95, 20);
		((Control)Label2).TabIndex = 104;
		Label2.Text = "Book Col Set";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(260, 238);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 1120;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG).Location = new Point(13, 103);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(416, 435);
		((Control)MSG).TabIndex = 1119;
		cboColSet.AutoCompleteMode = (AutoCompleteMode)2;
		cboColSet.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboColSet).Font = new Font("Tahoma", 9f);
		((ListControl)cboColSet).FormattingEnabled = true;
		((Control)cboColSet).Location = new Point(132, 64);
		cboColSet.MaxLength = 25;
		((Control)cboColSet).Name = "cboColSet";
		((Control)cboColSet).Size = new Size(157, 22);
		((Control)cboColSet).TabIndex = 1125;
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
		((Control)PnlBotam).TabIndex = 1126;
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
		((Control)BtnExit).TabIndex = 25;
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
		((Control)BtnDelete).TabIndex = 24;
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
		((Control)BtnCancel).TabIndex = 23;
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
		((Control)BtnSave).TabIndex = 22;
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
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((QControl)BtnColumnSet).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnColumnSet).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnColumnSet).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnColumnSet).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnColumnSet).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnColumnSet).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnColumnSet).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnColumnSet).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnColumnSet).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnColumnSet).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnColumnSet).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnColumnSet).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnColumnSet).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnColumnSet).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnColumnSet.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnColumnSet.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnColumnSet.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnColumnSet.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnColumnSet.Image = null;
		((QControl)BtnColumnSet).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnColumnSet).Location = new Point(303, 58);
		((Control)BtnColumnSet).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnColumnSet).Name = "BtnColumnSet";
		((Control)BtnColumnSet).Size = new Size(117, 34);
		((Control)BtnColumnSet).TabIndex = 1127;
		BtnColumnSet.Text = "Column Set";
		cboLbrType.AutoCompleteMode = (AutoCompleteMode)2;
		cboLbrType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboLbrType).Font = new Font("Tahoma", 9f);
		((ListControl)cboLbrType).FormattingEnabled = true;
		((Control)cboLbrType).Location = new Point(570, 64);
		cboLbrType.MaxLength = 25;
		((Control)cboLbrType).Name = "cboLbrType";
		((Control)cboLbrType).Size = new Size(106, 22);
		((Control)cboLbrType).TabIndex = 1129;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(445, 64);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(119, 20);
		((Control)Label1).TabIndex = 1128;
		Label1.Text = "Labour Type Set";
		Label1.TextAlign = (ContentAlignment)64;
		((QControl)btnLbrType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLbrType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLbrType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLbrType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLbrType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLbrType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLbrType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLbrType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLbrType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLbrType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLbrType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLbrType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLbrType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLbrType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLbrType.Configuration.FontDefinition = new QFontDefinition("Calibri Light", false, false, false, false, 13f);
		btnLbrType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrType.Image = null;
		((QControl)btnLbrType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLbrType).Location = new Point(684, 58);
		((Control)btnLbrType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLbrType).Name = "btnLbrType";
		((Control)btnLbrType).Size = new Size(121, 32);
		((Control)btnLbrType).TabIndex = 1130;
		btnLbrType.Text = "Lbr Type Set";
		((QControl)BtnRateType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnRateType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnRateType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnRateType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnRateType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnRateType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnRateType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnRateType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnRateType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnRateType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnRateType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnRateType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnRateType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnRateType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnRateType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateType.Image = null;
		((QControl)BtnRateType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnRateType).Location = new Point(684, 102);
		((Control)BtnRateType).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnRateType).Name = "BtnRateType";
		((Control)BtnRateType).Size = new Size(121, 32);
		((Control)BtnRateType).TabIndex = 1133;
		BtnRateType.Text = "Rate Type Set";
		cboRateType.AutoCompleteMode = (AutoCompleteMode)2;
		cboRateType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboRateType).Font = new Font("Tahoma", 9f);
		((ListControl)cboRateType).FormattingEnabled = true;
		((Control)cboRateType).Location = new Point(570, 107);
		cboRateType.MaxLength = 25;
		((Control)cboRateType).Name = "cboRateType";
		((Control)cboRateType).Size = new Size(106, 22);
		((Control)cboRateType).TabIndex = 1132;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(445, 107);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(119, 20);
		((Control)Label3).TabIndex = 1131;
		Label3.Text = "Rate Cut Rate";
		Label3.TextAlign = (ContentAlignment)64;
		((QControl)BtnTaxRof).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTaxRof).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTaxRof).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTaxRof).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTaxRof).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTaxRof).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTaxRof).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnTaxRof).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTaxRof).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTaxRof).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTaxRof).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTaxRof).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTaxRof).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTaxRof).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTaxRof.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTaxRof.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTaxRof.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTaxRof.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTaxRof.Image = null;
		((QControl)BtnTaxRof).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTaxRof).Location = new Point(1044, 276);
		((Control)BtnTaxRof).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTaxRof).Name = "BtnTaxRof";
		((Control)BtnTaxRof).Size = new Size(121, 32);
		((Control)BtnTaxRof).TabIndex = 1136;
		BtnTaxRof.Text = "Tax Rof Set";
		cboTaxRof.AutoCompleteMode = (AutoCompleteMode)2;
		cboTaxRof.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTaxRof).Font = new Font("Tahoma", 9f);
		((ListControl)cboTaxRof).FormattingEnabled = true;
		((Control)cboTaxRof).Location = new Point(930, 281);
		cboTaxRof.MaxLength = 25;
		((Control)cboTaxRof).Name = "cboTaxRof";
		((Control)cboTaxRof).Size = new Size(106, 22);
		((Control)cboTaxRof).TabIndex = 1135;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(805, 281);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(119, 20);
		((Control)Label4).TabIndex = 1134;
		Label4.Text = "Gst Tax Rof";
		Label4.TextAlign = (ContentAlignment)64;
		((QControl)BtnTagRowChange).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTagRowChange).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTagRowChange).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTagRowChange).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTagRowChange.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagRowChange.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagRowChange.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagRowChange.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTagRowChange.Image = null;
		((QControl)BtnTagRowChange).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTagRowChange).Location = new Point(684, 190);
		((Control)BtnTagRowChange).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTagRowChange).Name = "BtnTagRowChange";
		((Control)BtnTagRowChange).Size = new Size(121, 32);
		((Control)BtnTagRowChange).TabIndex = 1139;
		BtnTagRowChange.Text = "Change Set";
		cboTagRowChange.AutoCompleteMode = (AutoCompleteMode)2;
		cboTagRowChange.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTagRowChange).Font = new Font("Tahoma", 9f);
		((ListControl)cboTagRowChange).FormattingEnabled = true;
		((Control)cboTagRowChange).Location = new Point(570, 195);
		cboTagRowChange.MaxLength = 25;
		((Control)cboTagRowChange).Name = "cboTagRowChange";
		((Control)cboTagRowChange).Size = new Size(106, 22);
		((Control)cboTagRowChange).TabIndex = 1138;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(445, 195);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(119, 20);
		((Control)Label5).TabIndex = 1137;
		Label5.Text = "Sl Row Change";
		Label5.TextAlign = (ContentAlignment)64;
		((QControl)BtnLbrGen).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnLbrGen).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnLbrGen).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnLbrGen).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnLbrGen).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnLbrGen).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnLbrGen).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnLbrGen).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnLbrGen).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnLbrGen).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnLbrGen).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnLbrGen).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnLbrGen).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnLbrGen).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnLbrGen.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLbrGen.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLbrGen.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLbrGen.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLbrGen.Image = null;
		((QControl)BtnLbrGen).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnLbrGen).Location = new Point(684, 233);
		((Control)BtnLbrGen).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnLbrGen).Name = "BtnLbrGen";
		((Control)BtnLbrGen).Size = new Size(121, 32);
		((Control)BtnLbrGen).TabIndex = 1142;
		BtnLbrGen.Text = "Lbr Rate Gen";
		cbolbrRateGen.AutoCompleteMode = (AutoCompleteMode)2;
		cbolbrRateGen.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cbolbrRateGen).Font = new Font("Tahoma", 9f);
		((ListControl)cbolbrRateGen).FormattingEnabled = true;
		((Control)cbolbrRateGen).Location = new Point(570, 238);
		cbolbrRateGen.MaxLength = 25;
		((Control)cbolbrRateGen).Name = "cbolbrRateGen";
		((Control)cbolbrRateGen).Size = new Size(106, 22);
		((Control)cbolbrRateGen).TabIndex = 1141;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(445, 238);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(119, 20);
		((Control)Label6).TabIndex = 1140;
		Label6.Text = "Sl Lbr Rate Gen";
		Label6.TextAlign = (ContentAlignment)64;
		((QControl)BtnRateOpn).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnRateOpn).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnRateOpn).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnRateOpn).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnRateOpn).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnRateOpn).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnRateOpn).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnRateOpn).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnRateOpn).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnRateOpn).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnRateOpn).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnRateOpn).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnRateOpn).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnRateOpn).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnRateOpn.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateOpn.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateOpn.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateOpn.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRateOpn.Image = null;
		((QControl)BtnRateOpn).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnRateOpn).Location = new Point(684, 277);
		((Control)BtnRateOpn).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnRateOpn).Name = "BtnRateOpn";
		((Control)BtnRateOpn).Size = new Size(121, 32);
		((Control)BtnRateOpn).TabIndex = 1145;
		BtnRateOpn.Text = "Daily Rate Set";
		cboRateOpen.AutoCompleteMode = (AutoCompleteMode)2;
		cboRateOpen.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboRateOpen).Font = new Font("Tahoma", 9f);
		((ListControl)cboRateOpen).FormattingEnabled = true;
		((Control)cboRateOpen).Location = new Point(570, 281);
		cboRateOpen.MaxLength = 25;
		((Control)cboRateOpen).Name = "cboRateOpen";
		((Control)cboRateOpen).Size = new Size(106, 22);
		((Control)cboRateOpen).TabIndex = 1144;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(445, 280);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(119, 20);
		((Control)Label7).TabIndex = 1143;
		Label7.Text = "Daily Rate Open";
		Label7.TextAlign = (ContentAlignment)64;
		((QControl)BtnOpDhrn).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOpDhrn).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnOpDhrn).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnOpDhrn).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnOpDhrn.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOpDhrn.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOpDhrn.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOpDhrn.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOpDhrn.Image = null;
		((QControl)BtnOpDhrn).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnOpDhrn).Location = new Point(684, 364);
		((Control)BtnOpDhrn).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnOpDhrn).Name = "BtnOpDhrn";
		((Control)BtnOpDhrn).Size = new Size(121, 32);
		((Control)BtnOpDhrn).TabIndex = 1151;
		BtnOpDhrn.Text = "Dhiran Set";
		cboOpDhrn.AutoCompleteMode = (AutoCompleteMode)2;
		cboOpDhrn.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOpDhrn).Font = new Font("Tahoma", 9f);
		((ListControl)cboOpDhrn).FormattingEnabled = true;
		((Control)cboOpDhrn).Location = new Point(570, 370);
		cboOpDhrn.MaxLength = 25;
		((Control)cboOpDhrn).Name = "cboOpDhrn";
		((Control)cboOpDhrn).Size = new Size(106, 22);
		((Control)cboOpDhrn).TabIndex = 1150;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(445, 372);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(119, 20);
		((Control)Label9).TabIndex = 1149;
		Label9.Text = "Opening Dhiran";
		Label9.TextAlign = (ContentAlignment)64;
		((QControl)btnDhrnType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDhrnType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDhrnType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDhrnType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDhrnType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDhrnType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDhrnType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDhrnType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDhrnType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDhrnType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDhrnType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDhrnType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDhrnType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDhrnType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDhrnType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnType.Image = null;
		((QControl)btnDhrnType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDhrnType).Location = new Point(684, 404);
		((Control)btnDhrnType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDhrnType).Name = "btnDhrnType";
		((Control)btnDhrnType).Size = new Size(121, 32);
		((Control)btnDhrnType).TabIndex = 1154;
		btnDhrnType.Text = "Dhrn Type Set";
		cboDhrnType.AutoCompleteMode = (AutoCompleteMode)2;
		cboDhrnType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDhrnType).Font = new Font("Tahoma", 9f);
		((ListControl)cboDhrnType).FormattingEnabled = true;
		((Control)cboDhrnType).Location = new Point(570, 410);
		cboDhrnType.MaxLength = 25;
		((Control)cboDhrnType).Name = "cboDhrnType";
		((Control)cboDhrnType).Size = new Size(106, 22);
		((Control)cboDhrnType).TabIndex = 1153;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(445, 412);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(119, 20);
		((Control)Label10).TabIndex = 1152;
		Label10.Text = "Dhrn Intrest Type";
		Label10.TextAlign = (ContentAlignment)64;
		((QControl)btnHelpSearch).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnHelpSearch).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnHelpSearch).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnHelpSearch).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnHelpSearch).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnHelpSearch).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnHelpSearch).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnHelpSearch).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnHelpSearch).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnHelpSearch).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnHelpSearch).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnHelpSearch).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnHelpSearch).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnHelpSearch).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnHelpSearch.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpSearch.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpSearch.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpSearch.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpSearch.Image = null;
		((QControl)btnHelpSearch).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnHelpSearch).Location = new Point(1044, 58);
		((Control)btnHelpSearch).Margin = new Padding(3, 6, 3, 6);
		((Control)btnHelpSearch).Name = "btnHelpSearch";
		((Control)btnHelpSearch).Size = new Size(121, 32);
		((Control)btnHelpSearch).TabIndex = 1157;
		btnHelpSearch.Text = "Help  Set";
		cboHelpSearch.AutoCompleteMode = (AutoCompleteMode)2;
		cboHelpSearch.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboHelpSearch).Font = new Font("Tahoma", 9f);
		((ListControl)cboHelpSearch).FormattingEnabled = true;
		((Control)cboHelpSearch).Location = new Point(932, 64);
		cboHelpSearch.MaxLength = 25;
		((Control)cboHelpSearch).Name = "cboHelpSearch";
		((Control)cboHelpSearch).Size = new Size(106, 22);
		((Control)cboHelpSearch).TabIndex = 1156;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(827, 64);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(96, 20);
		((Control)Label11).TabIndex = 1155;
		Label11.Text = "Help Search";
		Label11.TextAlign = (ContentAlignment)64;
		((QControl)btnLdrSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLdrSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLdrSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLdrSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLdrSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLdrSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLdrSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLdrSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLdrSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLdrSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLdrSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLdrSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLdrSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrSumm.Image = null;
		((QControl)btnLdrSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLdrSumm).Location = new Point(1044, 102);
		((Control)btnLdrSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLdrSumm).Name = "btnLdrSumm";
		((Control)btnLdrSumm).Size = new Size(121, 32);
		((Control)btnLdrSumm).TabIndex = 1160;
		btnLdrSumm.Text = "Ledger Set";
		cboLdrSumm.AutoCompleteMode = (AutoCompleteMode)2;
		cboLdrSumm.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboLdrSumm).Font = new Font("Tahoma", 9f);
		((ListControl)cboLdrSumm).FormattingEnabled = true;
		((Control)cboLdrSumm).Location = new Point(932, 107);
		cboLdrSumm.MaxLength = 25;
		((Control)cboLdrSumm).Name = "cboLdrSumm";
		((Control)cboLdrSumm).Size = new Size(106, 22);
		((Control)cboLdrSumm).TabIndex = 1159;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(827, 107);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(96, 20);
		((Control)Label12).TabIndex = 1158;
		Label12.Text = "Ledr Summ";
		Label12.TextAlign = (ContentAlignment)64;
		((QControl)btnReminder).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnReminder).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnReminder).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnReminder).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnReminder).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnReminder).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnReminder).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnReminder).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnReminder).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnReminder).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnReminder).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnReminder).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnReminder).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnReminder).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnReminder.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnReminder.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnReminder.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnReminder.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnReminder.Image = null;
		((QControl)btnReminder).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnReminder).Location = new Point(684, 321);
		((Control)btnReminder).Margin = new Padding(3, 6, 3, 6);
		((Control)btnReminder).Name = "btnReminder";
		((Control)btnReminder).Size = new Size(121, 32);
		((Control)btnReminder).TabIndex = 1163;
		btnReminder.Text = "Reminder Set";
		cboReminder.AutoCompleteMode = (AutoCompleteMode)2;
		cboReminder.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboReminder).Font = new Font("Tahoma", 9f);
		((ListControl)cboReminder).FormattingEnabled = true;
		((Control)cboReminder).Location = new Point(570, 325);
		cboReminder.MaxLength = 25;
		((Control)cboReminder).Name = "cboReminder";
		((Control)cboReminder).Size = new Size(106, 22);
		((Control)cboReminder).TabIndex = 1162;
		((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(445, 324);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(119, 20);
		((Control)Label13).TabIndex = 1161;
		Label13.Text = "Reminder Open";
		Label13.TextAlign = (ContentAlignment)64;
		((QControl)btnLbrRof).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLbrRof).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLbrRof).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLbrRof).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLbrRof).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLbrRof).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLbrRof).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLbrRof).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLbrRof).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLbrRof).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLbrRof).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLbrRof).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLbrRof).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLbrRof).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLbrRof.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrRof.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrRof.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrRof.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrRof.Image = null;
		((QControl)btnLbrRof).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLbrRof).Location = new Point(1044, 233);
		((Control)btnLbrRof).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLbrRof).Name = "btnLbrRof";
		((Control)btnLbrRof).Size = new Size(121, 32);
		((Control)btnLbrRof).TabIndex = 1166;
		btnLbrRof.Text = "Lbr Rof Set";
		cbolbrrof.AutoCompleteMode = (AutoCompleteMode)2;
		cbolbrrof.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cbolbrrof).Font = new Font("Tahoma", 9f);
		((ListControl)cbolbrrof).FormattingEnabled = true;
		((Control)cbolbrrof).Location = new Point(932, 239);
		cbolbrrof.MaxLength = 25;
		((Control)cbolbrrof).Name = "cbolbrrof";
		((Control)cbolbrrof).Size = new Size(106, 22);
		((Control)cbolbrrof).TabIndex = 1165;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(805, 241);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(119, 20);
		((Control)Label14).TabIndex = 1164;
		Label14.Text = "Sales Lbr Rof";
		Label14.TextAlign = (ContentAlignment)64;
		((QControl)btnSlRateRof).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlRateRof).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlRateRof).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlRateRof).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlRateRof).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlRateRof).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlRateRof).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlRateRof).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlRateRof).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlRateRof).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlRateRof).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlRateRof).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlRateRof).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlRateRof).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlRateRof.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateRof.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateRof.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateRof.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateRof.Image = null;
		((QControl)btnSlRateRof).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlRateRof).Location = new Point(1044, 189);
		((Control)btnSlRateRof).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlRateRof).Name = "btnSlRateRof";
		((Control)btnSlRateRof).Size = new Size(121, 32);
		((Control)btnSlRateRof).TabIndex = 1169;
		btnSlRateRof.Text = "Rate Rof Set";
		cboSlRateRof.AutoCompleteMode = (AutoCompleteMode)2;
		cboSlRateRof.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSlRateRof).Font = new Font("Tahoma", 9f);
		((ListControl)cboSlRateRof).FormattingEnabled = true;
		((Control)cboSlRateRof).Location = new Point(932, 194);
		cboSlRateRof.MaxLength = 25;
		((Control)cboSlRateRof).Name = "cboSlRateRof";
		((Control)cboSlRateRof).Size = new Size(106, 22);
		((Control)cboSlRateRof).TabIndex = 1168;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(812, 195);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(111, 20);
		((Control)Label15).TabIndex = 1167;
		Label15.Text = "Sales Rate Rof";
		Label15.TextAlign = (ContentAlignment)64;
		((QControl)btnPurcLbr).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurcLbr).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcLbr).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurcLbr).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurcLbr).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurcLbr).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcLbr).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPurcLbr).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurcLbr).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurcLbr).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurcLbr).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcLbr).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurcLbr).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurcLbr).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurcLbr.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLbr.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLbr.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLbr.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLbr.Image = null;
		((QControl)btnPurcLbr).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurcLbr).Location = new Point(684, 146);
		((Control)btnPurcLbr).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurcLbr).Name = "btnPurcLbr";
		((Control)btnPurcLbr).Size = new Size(121, 32);
		((Control)btnPurcLbr).TabIndex = 1178;
		btnPurcLbr.Text = "Purc + Lbr Set";
		cboPurcLbr.AutoCompleteMode = (AutoCompleteMode)2;
		cboPurcLbr.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPurcLbr).Font = new Font("Tahoma", 9f);
		((ListControl)cboPurcLbr).FormattingEnabled = true;
		((Control)cboPurcLbr).Location = new Point(570, 149);
		cboPurcLbr.MaxLength = 25;
		((Control)cboPurcLbr).Name = "cboPurcLbr";
		((Control)cboPurcLbr).Size = new Size(106, 22);
		((Control)cboPurcLbr).TabIndex = 1177;
		((Control)Label18).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(447, 151);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(115, 20);
		((Control)Label18).TabIndex = 1176;
		Label18.Text = "Purc With  Lbr";
		Label18.TextAlign = (ContentAlignment)64;
		((QControl)BtnRptType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnRptType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnRptType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnRptType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnRptType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnRptType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnRptType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnRptType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnRptType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnRptType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnRptType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnRptType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnRptType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnRptType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnRptType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRptType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRptType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRptType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnRptType.Image = null;
		((QControl)BtnRptType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnRptType).Location = new Point(1044, 144);
		((Control)BtnRptType).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnRptType).Name = "BtnRptType";
		((Control)BtnRptType).Size = new Size(121, 32);
		((Control)BtnRptType).TabIndex = 1181;
		BtnRptType.Text = "Stk Rpt Set";
		cboStkRptType.AutoCompleteMode = (AutoCompleteMode)2;
		cboStkRptType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboStkRptType).Font = new Font("Tahoma", 9f);
		((ListControl)cboStkRptType).FormattingEnabled = true;
		((Control)cboStkRptType).Location = new Point(932, 149);
		cboStkRptType.MaxLength = 25;
		((Control)cboStkRptType).Name = "cboStkRptType";
		((Control)cboStkRptType).Size = new Size(106, 22);
		((Control)cboStkRptType).TabIndex = 1180;
		((Control)Label19).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(811, 149);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(114, 20);
		((Control)Label19).TabIndex = 1179;
		Label19.Text = "Stk Rpt G/N";
		Label19.TextAlign = (ContentAlignment)64;
		((QControl)btnWhTch).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhTch).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhTch).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhTch).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhTch).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhTch).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhTch).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWhTch).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhTch).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhTch).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhTch).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhTch).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhTch).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhTch).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhTch.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhTch.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhTch.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhTch.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhTch.Image = null;
		((QControl)btnWhTch).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhTch).Location = new Point(1044, 320);
		((Control)btnWhTch).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhTch).Name = "btnWhTch";
		((Control)btnWhTch).Size = new Size(121, 32);
		((Control)btnWhTch).TabIndex = 1184;
		btnWhTch.Text = "Auto Tch Set";
		cboWhTch.AutoCompleteMode = (AutoCompleteMode)2;
		cboWhTch.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboWhTch).Font = new Font("Tahoma", 9f);
		((ListControl)cboWhTch).FormattingEnabled = true;
		((Control)cboWhTch).Location = new Point(932, 325);
		cboWhTch.MaxLength = 25;
		((Control)cboWhTch).Name = "cboWhTch";
		((Control)cboWhTch).Size = new Size(106, 22);
		((Control)cboWhTch).TabIndex = 1183;
		((Control)Label20).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label20).ForeColor = Color.Black;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(811, 325);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(114, 20);
		((Control)Label20).TabIndex = 1182;
		Label20.Text = "Wh Touh Save";
		Label20.TextAlign = (ContentAlignment)64;
		((QControl)btnPanCardVal).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPanCardVal).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPanCardVal).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPanCardVal).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPanCardVal).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPanCardVal).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPanCardVal).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPanCardVal).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPanCardVal).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPanCardVal).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPanCardVal).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPanCardVal).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPanCardVal).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPanCardVal).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPanCardVal.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPanCardVal.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPanCardVal.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPanCardVal.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPanCardVal.Image = null;
		((QControl)btnPanCardVal).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPanCardVal).Location = new Point(1044, 362);
		((Control)btnPanCardVal).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPanCardVal).Name = "btnPanCardVal";
		((Control)btnPanCardVal).Size = new Size(121, 32);
		((Control)btnPanCardVal).TabIndex = 1187;
		btnPanCardVal.Text = "Sale Pan Value";
		cboPanCardVal.AutoCompleteMode = (AutoCompleteMode)2;
		cboPanCardVal.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPanCardVal).Font = new Font("Tahoma", 9f);
		((ListControl)cboPanCardVal).FormattingEnabled = true;
		((Control)cboPanCardVal).Location = new Point(932, 367);
		cboPanCardVal.MaxLength = 25;
		((Control)cboPanCardVal).Name = "cboPanCardVal";
		((Control)cboPanCardVal).Size = new Size(106, 22);
		((Control)cboPanCardVal).TabIndex = 1186;
		((Control)Label21).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label21).ForeColor = Color.Black;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(811, 367);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(114, 20);
		((Control)Label21).TabIndex = 1185;
		Label21.Text = "PanCard Value";
		Label21.TextAlign = (ContentAlignment)64;
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDhrnIntPrc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDhrnIntPrc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDhrnIntPrc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDhrnIntPrc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnIntPrc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnIntPrc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnIntPrc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnIntPrc.Image = null;
		((QControl)btnDhrnIntPrc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDhrnIntPrc).Location = new Point(684, 445);
		((Control)btnDhrnIntPrc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDhrnIntPrc).Name = "btnDhrnIntPrc";
		((Control)btnDhrnIntPrc).Size = new Size(121, 32);
		((Control)btnDhrnIntPrc).TabIndex = 1190;
		btnDhrnIntPrc.Text = "Dhrn Int % Set";
		cboDhrnIntPrc.AutoCompleteMode = (AutoCompleteMode)2;
		cboDhrnIntPrc.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDhrnIntPrc).Font = new Font("Tahoma", 9f);
		((ListControl)cboDhrnIntPrc).FormattingEnabled = true;
		((Control)cboDhrnIntPrc).Location = new Point(570, 450);
		cboDhrnIntPrc.MaxLength = 25;
		((Control)cboDhrnIntPrc).Name = "cboDhrnIntPrc";
		((Control)cboDhrnIntPrc).Size = new Size(106, 22);
		((Control)cboDhrnIntPrc).TabIndex = 1189;
		((Control)Label22).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(451, 450);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(114, 20);
		((Control)Label22).TabIndex = 1188;
		Label22.Text = "Dhiran Int %";
		Label22.TextAlign = (ContentAlignment)64;
		((QControl)BtnDupPrint).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDupPrint).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDupPrint).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDupPrint).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDupPrint).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDupPrint).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDupPrint).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnDupPrint).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDupPrint).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDupPrint).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDupPrint).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDupPrint).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDupPrint).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDupPrint).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDupPrint.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDupPrint.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDupPrint.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDupPrint.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDupPrint.Image = null;
		((QControl)BtnDupPrint).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDupPrint).Location = new Point(1044, 404);
		((Control)BtnDupPrint).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDupPrint).Name = "BtnDupPrint";
		((Control)BtnDupPrint).Size = new Size(121, 32);
		((Control)BtnDupPrint).TabIndex = 1193;
		BtnDupPrint.Text = "Duplicate Print";
		cboDupPrint.AutoCompleteMode = (AutoCompleteMode)2;
		cboDupPrint.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDupPrint).Font = new Font("Tahoma", 9f);
		((ListControl)cboDupPrint).FormattingEnabled = true;
		((Control)cboDupPrint).Location = new Point(932, 409);
		cboDupPrint.MaxLength = 25;
		((Control)cboDupPrint).Name = "cboDupPrint";
		((Control)cboDupPrint).Size = new Size(106, 22);
		((Control)cboDupPrint).TabIndex = 1192;
		((Control)Label23).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label23).ForeColor = Color.Black;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(811, 409);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(114, 20);
		((Control)Label23).TabIndex = 1191;
		Label23.Text = "Duplicat Print";
		Label23.TextAlign = (ContentAlignment)64;
		((QControl)btnCashPurcAc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCashPurcAc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCashPurcAc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCashPurcAc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCashPurcAc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPurcAc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPurcAc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPurcAc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPurcAc.Image = null;
		((QControl)btnCashPurcAc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCashPurcAc).Location = new Point(1044, 445);
		((Control)btnCashPurcAc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCashPurcAc).Name = "btnCashPurcAc";
		((Control)btnCashPurcAc).Size = new Size(121, 32);
		((Control)btnCashPurcAc).TabIndex = 1196;
		btnCashPurcAc.Text = "Purc Ac Set";
		((QControl)btnCashPurcAc).ToolTipText = "Purchase Form Default Cash Purc Ac";
		cboPurcAc.AutoCompleteMode = (AutoCompleteMode)2;
		cboPurcAc.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPurcAc).Font = new Font("Tahoma", 9f);
		((ListControl)cboPurcAc).FormattingEnabled = true;
		((Control)cboPurcAc).Location = new Point(932, 450);
		cboPurcAc.MaxLength = 25;
		((Control)cboPurcAc).Name = "cboPurcAc";
		((Control)cboPurcAc).Size = new Size(106, 22);
		((Control)cboPurcAc).TabIndex = 1195;
		((Control)Label16).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(811, 450);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(114, 20);
		((Control)Label16).TabIndex = 1194;
		Label16.Text = "Cash Purc Ac";
		Label16.TextAlign = (ContentAlignment)64;
		((QControl)btnLoanSet).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLoanSet).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLoanSet).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLoanSet).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLoanSet).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLoanSet).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLoanSet).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLoanSet).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLoanSet).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLoanSet).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLoanSet).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLoanSet).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLoanSet).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLoanSet).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLoanSet.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanSet.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanSet.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanSet.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanSet.Image = null;
		((QControl)btnLoanSet).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLoanSet).Location = new Point(684, 486);
		((Control)btnLoanSet).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLoanSet).Name = "btnLoanSet";
		((Control)btnLoanSet).Size = new Size(121, 32);
		((Control)btnLoanSet).TabIndex = 1199;
		btnLoanSet.Text = "Loan Set";
		cboOpLoan.AutoCompleteMode = (AutoCompleteMode)2;
		cboOpLoan.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOpLoan).Font = new Font("Tahoma", 9f);
		((ListControl)cboOpLoan).FormattingEnabled = true;
		((Control)cboOpLoan).Location = new Point(570, 493);
		cboOpLoan.MaxLength = 25;
		((Control)cboOpLoan).Name = "cboOpLoan";
		((Control)cboOpLoan).Size = new Size(106, 22);
		((Control)cboOpLoan).TabIndex = 1198;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(445, 495);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(119, 20);
		((Control)Label17).TabIndex = 1197;
		Label17.Text = "Opening Loan";
		Label17.TextAlign = (ContentAlignment)64;
		((Control)pnlUAE).Controls.Add((Control)(object)btnOzConv);
		((Control)pnlUAE).Controls.Add((Control)(object)cboOzCon);
		((Control)pnlUAE).Controls.Add((Control)(object)Label25);
		((Control)pnlUAE).Controls.Add((Control)(object)btnFxRate);
		((Control)pnlUAE).Controls.Add((Control)(object)cboFxRate);
		((Control)pnlUAE).Controls.Add((Control)(object)Label24);
		((Control)pnlUAE).Controls.Add((Control)(object)btnFxCode);
		((Control)pnlUAE).Controls.Add((Control)(object)cboFxCode);
		((Control)pnlUAE).Controls.Add((Control)(object)Label8);
		((Control)pnlUAE).Location = new Point(1171, 41);
		((Control)pnlUAE).Name = "pnlUAE";
		((Control)pnlUAE).Size = new Size(791, 506);
		((Control)pnlUAE).TabIndex = 1200;
		((Control)pnlUAE).Visible = false;
		((QControl)btnOzConv).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOzConv).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOzConv).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOzConv).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOzConv).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOzConv).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOzConv).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOzConv).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOzConv).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOzConv).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOzConv).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOzConv).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOzConv).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOzConv).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOzConv.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOzConv.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOzConv.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOzConv.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOzConv.Image = null;
		((QControl)btnOzConv).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOzConv).Location = new Point(251, 104);
		((Control)btnOzConv).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOzConv).Name = "btnOzConv";
		((Control)btnOzConv).Size = new Size(121, 32);
		((Control)btnOzConv).TabIndex = 1199;
		btnOzConv.Text = "Oz Conv Set";
		cboOzCon.AutoCompleteMode = (AutoCompleteMode)2;
		cboOzCon.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOzCon).Font = new Font("Tahoma", 9f);
		((ListControl)cboOzCon).FormattingEnabled = true;
		((Control)cboOzCon).Location = new Point(137, 109);
		cboOzCon.MaxLength = 25;
		((Control)cboOzCon).Name = "cboOzCon";
		((Control)cboOzCon).Size = new Size(106, 22);
		((Control)cboOzCon).TabIndex = 1198;
		((Control)Label25).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label25).ForeColor = Color.Black;
		Label25.ImeMode = (ImeMode)0;
		((Control)Label25).Location = new Point(18, 109);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(114, 20);
		((Control)Label25).TabIndex = 1197;
		Label25.Text = "Oz To Gm Cover";
		Label25.TextAlign = (ContentAlignment)64;
		((QControl)btnFxRate).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFxRate).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFxRate).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFxRate).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFxRate).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFxRate).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFxRate).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFxRate).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFxRate).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFxRate).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFxRate).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFxRate).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFxRate).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFxRate).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFxRate.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxRate.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxRate.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxRate.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxRate.Image = null;
		((QControl)btnFxRate).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFxRate).Location = new Point(251, 61);
		((Control)btnFxRate).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFxRate).Name = "btnFxRate";
		((Control)btnFxRate).Size = new Size(121, 32);
		((Control)btnFxRate).TabIndex = 1196;
		btnFxRate.Text = "Fx Rate Set";
		cboFxRate.AutoCompleteMode = (AutoCompleteMode)2;
		cboFxRate.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboFxRate).Font = new Font("Tahoma", 9f);
		((ListControl)cboFxRate).FormattingEnabled = true;
		((Control)cboFxRate).Location = new Point(137, 66);
		cboFxRate.MaxLength = 25;
		((Control)cboFxRate).Name = "cboFxRate";
		((Control)cboFxRate).Size = new Size(106, 22);
		((Control)cboFxRate).TabIndex = 1195;
		((Control)Label24).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label24).ForeColor = Color.Black;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(18, 66);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(114, 20);
		((Control)Label24).TabIndex = 1194;
		Label24.Text = "Forex Rate";
		Label24.TextAlign = (ContentAlignment)64;
		((QControl)btnFxCode).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFxCode).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFxCode).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFxCode).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFxCode).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFxCode).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFxCode).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFxCode).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFxCode).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFxCode).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFxCode).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFxCode).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFxCode).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFxCode).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFxCode.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxCode.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxCode.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxCode.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFxCode.Image = null;
		((QControl)btnFxCode).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFxCode).Location = new Point(251, 18);
		((Control)btnFxCode).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFxCode).Name = "btnFxCode";
		((Control)btnFxCode).Size = new Size(121, 32);
		((Control)btnFxCode).TabIndex = 1193;
		btnFxCode.Text = "Fx Code Set";
		cboFxCode.AutoCompleteMode = (AutoCompleteMode)2;
		cboFxCode.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboFxCode).Font = new Font("Tahoma", 9f);
		((ListControl)cboFxCode).FormattingEnabled = true;
		((Control)cboFxCode).Location = new Point(137, 23);
		cboFxCode.MaxLength = 25;
		((Control)cboFxCode).Name = "cboFxCode";
		((Control)cboFxCode).Size = new Size(106, 22);
		((Control)cboFxCode).TabIndex = 1192;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(18, 23);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(114, 20);
		((Control)Label8).TabIndex = 1191;
		Label8.Text = "Forex Code";
		Label8.TextAlign = (ContentAlignment)64;
		((QControl)btnPrintZoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPrintZoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrintZoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPrintZoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPrintZoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPrintZoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrintZoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPrintZoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPrintZoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPrintZoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPrintZoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPrintZoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPrintZoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPrintZoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPrintZoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintZoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintZoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintZoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintZoom.Image = null;
		((QControl)btnPrintZoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPrintZoom).Location = new Point(1044, 487);
		((Control)btnPrintZoom).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPrintZoom).Name = "btnPrintZoom";
		((Control)btnPrintZoom).Size = new Size(121, 32);
		((Control)btnPrintZoom).TabIndex = 1203;
		btnPrintZoom.Text = "Print Zoom Set";
		((QControl)btnPrintZoom).ToolTipText = "Purchase Form Default Cash Purc Ac";
		cboPrintZoom.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintZoom.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPrintZoom).Font = new Font("Tahoma", 9f);
		((ListControl)cboPrintZoom).FormattingEnabled = true;
		((Control)cboPrintZoom).Location = new Point(932, 492);
		cboPrintZoom.MaxLength = 25;
		((Control)cboPrintZoom).Name = "cboPrintZoom";
		((Control)cboPrintZoom).Size = new Size(106, 22);
		((Control)cboPrintZoom).TabIndex = 1202;
		((Control)Label26).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label26).ForeColor = Color.Black;
		Label26.ImeMode = (ImeMode)0;
		((Control)Label26).Location = new Point(783, 492);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(142, 20);
		((Control)Label26).TabIndex = 1201;
		Label26.Text = "Print View Zoom";
		Label26.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnLoanSet);
		((Control)this).Controls.Add((Control)(object)btnPrintZoom);
		((Control)this).Controls.Add((Control)(object)cboPrintZoom);
		((Control)this).Controls.Add((Control)(object)Label26);
		((Control)this).Controls.Add((Control)(object)pnlUAE);
		((Control)this).Controls.Add((Control)(object)cboOpLoan);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)btnCashPurcAc);
		((Control)this).Controls.Add((Control)(object)cboPurcAc);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)BtnDupPrint);
		((Control)this).Controls.Add((Control)(object)cboDupPrint);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)btnDhrnIntPrc);
		((Control)this).Controls.Add((Control)(object)cboDhrnIntPrc);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)btnPanCardVal);
		((Control)this).Controls.Add((Control)(object)cboPanCardVal);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)btnWhTch);
		((Control)this).Controls.Add((Control)(object)cboWhTch);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)BtnRptType);
		((Control)this).Controls.Add((Control)(object)cboStkRptType);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)btnPurcLbr);
		((Control)this).Controls.Add((Control)(object)cboPurcLbr);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)btnSlRateRof);
		((Control)this).Controls.Add((Control)(object)cboSlRateRof);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)btnLbrRof);
		((Control)this).Controls.Add((Control)(object)cbolbrrof);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)btnReminder);
		((Control)this).Controls.Add((Control)(object)cboReminder);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)btnLdrSumm);
		((Control)this).Controls.Add((Control)(object)cboLdrSumm);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)btnHelpSearch);
		((Control)this).Controls.Add((Control)(object)cboHelpSearch);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)btnDhrnType);
		((Control)this).Controls.Add((Control)(object)cboDhrnType);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)BtnOpDhrn);
		((Control)this).Controls.Add((Control)(object)cboOpDhrn);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)BtnRateOpn);
		((Control)this).Controls.Add((Control)(object)cboRateOpen);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)BtnLbrGen);
		((Control)this).Controls.Add((Control)(object)cbolbrRateGen);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)BtnTagRowChange);
		((Control)this).Controls.Add((Control)(object)cboTagRowChange);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)BtnTaxRof);
		((Control)this).Controls.Add((Control)(object)cboTaxRof);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)BtnRateType);
		((Control)this).Controls.Add((Control)(object)cboRateType);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)btnLbrType);
		((Control)this).Controls.Add((Control)(object)cboLbrType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)BtnColumnSet);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)cboColSet);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_SETTING";
		((Form)this).Text = "Company Setting";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)pnlUAE).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void UT_SETTING_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Expected O, but got Unknown
		//IL_0aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab5: Expected O, but got Unknown
		//IL_0b02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b09: Expected O, but got Unknown
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Expected O, but got Unknown
		//IL_0c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Expected O, but got Unknown
		//IL_0cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)pnlUAE).Controls)
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
				num3 = (int)Math.Ceiling((double)((Control)Label11).Font.Size * (1.0 + num2));
				Font font = ((Control)Label11).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is SimpleButton || val3 is MaskedTextBox || val3 is QButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0)))
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
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
			}
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT BOOK_NAME FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY BOOK_NAME ORDER BY BOOK_NAME ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			cboColSet.Items.Clear();
			cboColSet.Items.Add((object)"");
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboColSet.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
					DC_Main.X++;
				}
			}
			cboLbrType.Items.Add((object)"Gorss Wise");
			cboLbrType.Items.Add((object)"Net Wise");
			cboLbrType.Items.Add((object)"Kg Wise");
			cboLbrType.Items.Add((object)"Pcs Wise");
			cboRateType.Items.Add((object)"G Gram Wise");
			cboRateType.Items.Add((object)"T 10gm Wise");
			cboRateType.Items.Add((object)"K Kg Wise");
			cboTaxRof.Items.Add((object)"0");
			cboTaxRof.Items.Add((object)"1");
			cboTaxRof.Items.Add((object)"2");
			cboTagRowChange.Items.Add((object)"No");
			cboTagRowChange.Items.Add((object)"Yes");
			cbolbrRateGen.Items.Add((object)"No");
			cbolbrRateGen.Items.Add((object)"Yes");
			cboRateOpen.Items.Add((object)"No");
			cboRateOpen.Items.Add((object)"Yes");
			cboOpDhrn.Items.Add((object)"No");
			cboOpDhrn.Items.Add((object)"Yes");
			cboDhrnType.Items.Add((object)"Month Wise");
			cboDhrnType.Items.Add((object)"Day Wise");
			cboHelpSearch.Items.Add((object)"Selected Col");
			cboHelpSearch.Items.Add((object)"Mobile Mathod");
			cboHelpSearch.Items.Add((object)"Whout Row Short");
			cboHelpSearch.Items.Add((object)"All Column");
			cboLdrSumm.Items.Add((object)"No");
			cboLdrSumm.Items.Add((object)"Yes");
			cboReminder.Items.Add((object)"No");
			cboReminder.Items.Add((object)"Yes");
			cbolbrrof.Items.Add((object)"0");
			cbolbrrof.Items.Add((object)"1");
			cbolbrrof.Items.Add((object)"2");
			cbolbrrof.Items.Add((object)"3");
			cboSlRateRof.Items.Add((object)"0");
			cboSlRateRof.Items.Add((object)"1");
			cboSlRateRof.Items.Add((object)"2");
			cboSlRateRof.Items.Add((object)"3");
			cboPurcLbr.Items.Add((object)"No");
			cboPurcLbr.Items.Add((object)"Yes");
			cboStkRptType.Items.Add((object)"Gross Wise");
			cboStkRptType.Items.Add((object)"Net Wise");
			cboWhTch.Items.Add((object)"No");
			cboWhTch.Items.Add((object)"Yes");
			cboDupPrint.Items.Add((object)"No");
			cboDupPrint.Items.Add((object)"Yes");
			cboPurcAc.Items.Add((object)"No");
			cboPurcAc.Items.Add((object)"Yes");
			cboOpLoan.Items.Add((object)"No");
			cboOpLoan.Items.Add((object)"Yes");
			cboPanCardVal.Items.Add((object)"100000");
			cboPanCardVal.Items.Add((object)"200000");
			cboPrintZoom.Items.Add((object)"110");
			cboPrintZoom.Items.Add((object)"120");
			cboPrintZoom.Items.Add((object)"130");
			cboPrintZoom.Items.Add((object)"140");
			cboPrintZoom.Items.Add((object)"150");
			cboDhrnIntPrc.Items.Add((object)"1.00");
			cboDhrnIntPrc.Items.Add((object)"1.25");
			cboDhrnIntPrc.Items.Add((object)"1.50");
			cboDhrnIntPrc.Items.Add((object)"1.75");
			cboDhrnIntPrc.Items.Add((object)"2.00");
			cboDhrnIntPrc.Items.Add((object)"2.25");
			cboDhrnIntPrc.Items.Add((object)"2.50");
			cboDhrnIntPrc.Items.Add((object)"3.00");
			DC_Main.RsQry = "SELECT * From CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"P", false))
				{
					cboLbrType.SelectedIndex = 3;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"K", false))
				{
					cboLbrType.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"N", false))
				{
					cboLbrType.SelectedIndex = 1;
				}
				else
				{
					cboLbrType.SelectedIndex = 0;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_PAR"], (object)""), (object)"K", false))
				{
					cboRateType.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_PAR"], (object)""), (object)"T", false))
				{
					cboRateType.SelectedIndex = 1;
				}
				else
				{
					cboRateType.SelectedIndex = 0;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HELP_SERCH"], (object)""), (object)"A", false))
				{
					cboHelpSearch.SelectedIndex = 3;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HELP_SERCH"], (object)""), (object)"W", false))
				{
					cboHelpSearch.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HELP_SERCH"], (object)""), (object)"M", false))
				{
					cboHelpSearch.SelectedIndex = 1;
				}
				else
				{
					cboHelpSearch.SelectedIndex = 0;
				}
				ComboBox obj21 = cboTaxRof;
				DataRow dataRow;
				object obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["TAX_ROF"]);
				double num5 = DC_Main.Fnv(ref obj);
				dataRow["TAX_ROF"] = RuntimeHelpers.GetObjectValue(obj);
				obj21.Text = Conversions.ToString(num5);
				cboTagRowChange.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_ROW_CHANGE"], (object)""));
				cbolbrRateGen.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_RATE_GEN"], (object)""));
				cboRateOpen.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_MAST_OPEN"], (object)""));
				cboFxCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FX_CODE"], (object)""));
				ComboBox obj22 = cboFxRate;
				obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["FX_RATE"]);
				double num6 = DC_Main.Fnv(ref obj);
				dataRow["FX_RATE"] = RuntimeHelpers.GetObjectValue(obj);
				obj22.Text = Strings.Format((object)num6, "0.000");
				ComboBox obj23 = cboOzCon;
				obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["OZ_CON_VAL"]);
				double num7 = DC_Main.Fnv(ref obj);
				dataRow["OZ_CON_VAL"] = RuntimeHelpers.GetObjectValue(obj);
				obj23.Text = Strings.Format((object)num7, "0.0000");
				cboOpDhrn.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["OP_DHRN"], (object)"Y", false), (object)"Yes", (object)"No"));
				cboDhrnType.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["DHRN_INT_TYPE"], (object)"D", false), (object)"Day Wise", (object)"Month Wise"));
				cboLdrSumm.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["LDR_SUMM"], (object)"N", false), (object)"No", (object)"Yes"));
				cboReminder.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["REMINDER_OPEN"], (object)"N", false), (object)"No", (object)"Yes"));
				ComboBox obj24 = cbolbrrof;
				obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["LBR_ROF"]);
				double num8 = DC_Main.Fnv(ref obj);
				dataRow["LBR_ROF"] = RuntimeHelpers.GetObjectValue(obj);
				obj24.Text = Conversions.ToString(num8);
				ComboBox obj25 = cboSlRateRof;
				obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["ITM_RATE_ROF"]);
				double num9 = DC_Main.Fnv(ref obj);
				dataRow["ITM_RATE_ROF"] = RuntimeHelpers.GetObjectValue(obj);
				obj25.Text = Conversions.ToString(num9);
				cboPurcLbr.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["PURC_WITH_LBR"], (object)"N", false), (object)"No", (object)"Yes"));
				cboStkRptType.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["STK_RPT_TYPE"], (object)"G", false), (object)"Gross Wise", (object)"Net Wise"));
				cboWhTch.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["TOUCH_AUTO_SAVE"], (object)"Y", false), (object)"Yes", (object)"No"));
				ComboBox obj26 = cboPanCardVal;
				obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["PAN_CARD_VAL"]);
				double num10 = DC_Main.Fnv(ref obj);
				dataRow["PAN_CARD_VAL"] = RuntimeHelpers.GetObjectValue(obj);
				obj26.Text = Conversions.ToString(num10);
				ComboBox obj27 = cboDhrnIntPrc;
				obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DHRN_PRC"]);
				double num11 = DC_Main.Fnv(ref obj);
				dataRow["DHRN_PRC"] = RuntimeHelpers.GetObjectValue(obj);
				obj27.Text = Strings.Format((object)num11, "0.00");
				cboDupPrint.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["DUP_PRINT"], (object)"Y", false), (object)"Yes", (object)"No"));
				cboPurcAc.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["CASH_PURC_AC"], (object)"Y", false), (object)"Yes", (object)"No"));
				cboOpLoan.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["OP_LOAN"], (object)"Y", false), (object)"Yes", (object)"No"));
			}
			DC_Main.RsQry = "SELECT * From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				ComboBox obj28 = cboPrintZoom;
				DataRow dataRow;
				object obj = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["PRINT_ZOOM"]);
				double num12 = DC_Main.Fnv(ref obj);
				dataRow["PRINT_ZOOM"] = RuntimeHelpers.GetObjectValue(obj);
				obj28.Text = Strings.Format((object)num12, "0");
			}
			((Control)pnlUAE).Left = ((Control)Label1).Left;
			EntryMode = "A";
			CurActCtrl = (Control)(object)cboColSet;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 6;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1700.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "ColName";
			mSG[2] = (int)Math.Round(1700.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ColNewName";
			mSG[3] = (int)Math.Round(950.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "RptCol";
			mSG[4] = (int)Math.Round(950.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "ShowCol";
			mSG[5] = (int)Math.Round(0.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "BookName";
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

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MsgOldRow != MSG.Row)
		{
			MsgOldRow = MSG.Row;
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
				case 3:
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
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
			case 5:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 3:
			case 4:
				MSG[mSG.Row, mSG.Col] = Strings.UCase(TEXT_ENTRY.Text);
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

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected I4, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
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
						Msgleft = true;
						UpDown = true;
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
				switch (mSG.Col)
				{
				case 2:
					if (mSG.Row == mSG.Rows - 1)
					{
						mSG.Row = 1;
						mSG.Col = 3;
						return;
					}
					mSG.Row += 1;
					mSG.Col = mSG.Col;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
					return;
				case 3:
					TEXT_ENTRY.Text = Strings.UCase(TEXT_ENTRY.Text);
					if ((Operators.CompareString(TEXT_ENTRY.Text, "N", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) != 0))
					{
						Interaction.MsgBox((object)"Please insert N OR Y And Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
					if (mSG.Row == mSG.Rows - 1)
					{
						mSG.Row = 1;
						mSG.Col = 4;
						return;
					}
					mSG.Row += 1;
					mSG.Col = mSG.Col;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
					return;
				case 4:
					TEXT_ENTRY.Text = Strings.UCase(TEXT_ENTRY.Text);
					if ((Operators.CompareString(TEXT_ENTRY.Text, "N", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) != 0))
					{
						Interaction.MsgBox((object)"Please insert N OR Y And Try...", (MsgBoxStyle)0, (object)null);
					}
					else if (mSG.Row == mSG.Rows - 1)
					{
						mSG[mSG.Row, 4] = TEXT_ENTRY.Text;
						((Control)TEXT_ENTRY).Visible = false;
						((Control)BtnColumnSet).Enabled = true;
						((Control)BtnColumnSet).Focus();
					}
					else
					{
						mSG.Row += 1;
						mSG.Col = mSG.Col;
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

	private void UT_SETTING_Activated(object sender, EventArgs e)
	{
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
		MSG_CLEAR();
		CommPassAdd();
		EntryMode = "A";
		((Control)cboColSet).Focus();
	}

	private void DISPLAY_DATA()
	{
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void UT_SETTING_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_SETTING_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void UT_SETTING_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)TEXT_ENTRY).Visible)
		{
			MSG_LeaveCell(MSG, new EventArgs());
			MSG.Row = checked(MSG.Rows - 1);
			MSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			((Control)BtnColumnSet).Focus();
		}
		if ((e.KeyCode & 0xFFFF) == 69 && (int)e.Modifiers == 262144)
		{
			BtnExit_Click(BtnExit, new EventArgs());
		}
		else if ((e.KeyCode & 0xFFFF) == 67 && (int)e.Modifiers == 262144)
		{
			BtnCancel_Click(BtnCancel, new EventArgs());
		}
	}

	private void UT_SETTING_KeyUp(object sender, KeyEventArgs e)
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

	private void cboColSet_Click(object sender, EventArgs e)
	{
		MSG_CLEAR();
	}

	private void cboColSet_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MSG_CLEAR();
		if (cboColSet.SelectedIndex == 0)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0)
		{
			if (Operators.CompareString(cboColSet.Text, "TAG_IDTL", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = '" + cboColSet.Text + "' AND COL_NAME NOT IN ('DmCode','DmName','DmColor','DmSize','DmOrigin','DmRemark')";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = '" + cboColSet.Text + "'";
			}
		}
		else
		{
			DC_Main.RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = '" + cboColSet.Text + "'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					MSG[DC_Main.X + 1, 0] = Conversions.ToString(DC_Main.X + 1);
					MSG[DC_Main.X + 1, 1] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.X]["COL_NAME"]);
					MSG[DC_Main.X + 1, 2] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.X]["COL_NEW_NAME"]);
					MSG[DC_Main.X + 1, 3] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.X]["COL_RPT"]);
					MSG[DC_Main.X + 1, 4] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.X]["YES_NO"]);
					MSG[DC_Main.X + 1, 5] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"]);
					MSG.Rows += 1;
					DC_Main.X++;
				}
				MSG.Rows -= 1;
				MSG.Row = 1;
				MSG.Col = 2;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void BtnColumnSet_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(UserEdit, "Y", false) != 0)
			{
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			}
			else if (cboColSet.SelectedIndex != 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = "UPDATE COL_MAST SET COL_NEW_NAME = '" + MSG[DC_Main.X, 2] + "',  COL_RPT = '" + Strings.UCase(MSG[DC_Main.X, 3]) + "',  YES_NO = '" + Strings.UCase(MSG[DC_Main.X, 4]) + "'  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = '" + MSG[DC_Main.X, 5] + "'  AND COL_NAME = '" + MSG[DC_Main.X, 1] + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.X++;
				}
				DC_Main.OpenTable_ColMast();
				MSG_CLEAR();
				cboColSet.SelectedIndex = 0;
				((Control)cboColSet).Focus();
				Interaction.MsgBox((object)"Column is Set", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void btnLbrType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET LBR_TYPE = '" + Strings.Mid(cboLbrType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLbrType = Strings.Mid(cboLbrType.Text, 1, 1);
		Interaction.MsgBox((object)"Labour Type Is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnRateType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET RATE_PAR = '" + Strings.Mid(cboRateType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsRatePar = Strings.Mid(cboRateType.Text, 1, 1);
		Interaction.MsgBox((object)"WhSales Rate Cut Item Rate Type Is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void UT_SETTING_Closed(object sender, EventArgs e)
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

	private void BtnTaxRof_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET TAX_ROF = " + Conversions.ToString(Conversion.Val(cboTaxRof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTaxRof = checked((int)Math.Round(Conversion.Val(cboTaxRof.Text)));
		Interaction.MsgBox((object)"Gst Tax Roundof Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnTagRowChange_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET SL_ROW_CHANGE = '" + Strings.Mid(cboTagRowChange.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlRowChange = Strings.Mid(cboTagRowChange.Text, 1, 1);
		Interaction.MsgBox((object)"Sale Tag Row Change....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnLbrGen_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET LBR_RATE_GEN = '" + Strings.Mid(cbolbrRateGen.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLbrGen = Strings.Mid(cbolbrRateGen.Text, 1, 1);
		Interaction.MsgBox((object)"Sale Labour Rate Genrate....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnRateOpn_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET RATE_MAST_OPEN = '" + Strings.Mid(cboRateOpen.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsRateMastOpen = Strings.Mid(cboRateOpen.Text, 1, 1);
		Interaction.MsgBox((object)"Daily Rate Open Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnOpDhrn_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET OP_DHRN = '" + Strings.Mid(cboOpDhrn.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOpDhiran = Strings.Mid(cboOpDhrn.Text, 1, 1);
		Interaction.MsgBox((object)"Opening Dhiran Is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnDhrnType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET DHRN_INT_TYPE = '" + Strings.Mid(cboDhrnType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsDhrnIntType = Strings.Mid(cboDhrnType.Text, 1, 1);
		Interaction.MsgBox((object)"Dhiran Intrest Type Is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnHelpSearch_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET HELP_SERCH = '" + Strings.Mid(cboHelpSearch.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsHelpSearch = Strings.Mid(cboHelpSearch.Text, 1, 1);
		Interaction.MsgBox((object)"Help Search Type is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnLdrSumm_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET LDR_SUMM = '" + Strings.Mid(cboLdrSumm.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLdrSumm = Strings.Mid(cboLdrSumm.Text, 1, 1);
		Interaction.MsgBox((object)"Ledger Wise Summery Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnReminder_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET REMINDER_OPEN = '" + Strings.Mid(cboReminder.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsReminderOpen = Strings.Mid(cboReminder.Text, 1, 1);
		Interaction.MsgBox((object)"Reminder Open Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnLbrRof_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET LBR_ROF = " + Conversions.ToString(Conversion.Val(cbolbrrof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLbrRof = checked((int)Math.Round(Conversion.Val(cbolbrrof.Text)));
		Interaction.MsgBox((object)"Sales Labour Roundof Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnSlRateRof_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET ITM_RATE_ROF = " + Conversions.ToString(Conversion.Val(cboSlRateRof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsItmRateRof = checked((int)Math.Round(Conversion.Val(cboSlRateRof.Text)));
		Interaction.MsgBox((object)"Sales Item Rate Roundof Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnPurcLbr_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET PURC_WITH_LBR = '" + Strings.Mid(cboPurcLbr.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPurcWithLbr = Strings.Mid(cboPurcLbr.Text, 1, 1);
		Interaction.MsgBox((object)"Purchase account with labour set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnRptType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET STK_RPT_TYPE = '" + Strings.Mid(cboStkRptType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsStkRptType = Strings.Mid(cboStkRptType.Text, 1, 1);
		Interaction.MsgBox((object)"Stock Report Default Open Gorss or Net Wise Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnWhTch_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET TOUCH_AUTO_SAVE = '" + Strings.Mid(cboWhTch.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTchAutoSave = Strings.Mid(cboWhTch.Text, 1, 1);
		Interaction.MsgBox((object)"Wh Sales Touch and West Auto Save set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnPanCardVal_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET PAN_CARD_VAL = " + Conversions.ToString(Conversion.Val(cboPanCardVal.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPanCardVal = Conversion.Val(cboPanCardVal.Text);
		Interaction.MsgBox((object)"Sales With Pancard Value set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnDhrnIntPrc_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET DHRN_PRC = " + Conversions.ToString(Conversion.Val(cboDhrnIntPrc.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsDhrnPrc = Conversion.Val(cboDhrnIntPrc.Text);
		Interaction.MsgBox((object)"Dhiran intrest Prc Default Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnDupPrint_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET DUP_PRINT = '" + Strings.Mid(cboDupPrint.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlDupPrint = Strings.Mid(cboDupPrint.Text, 1, 1);
		Interaction.MsgBox((object)"Sales Bill Duplicate Print Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnCashPurcAc_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET CASH_PURC_AC = '" + Strings.Mid(cboPurcAc.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCashPurcAc = Strings.Mid(cboPurcAc.Text, 1, 1);
		Interaction.MsgBox((object)"Purchase Form Default Cash Purchase Ac Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnLoanSet_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET OP_LOAN = '" + Strings.Mid(cboOpLoan.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOpLoan = Strings.Mid(cboOpLoan.Text, 1, 1);
		Interaction.MsgBox((object)"Opning Loane Ledr Posting Set....", (MsgBoxStyle)0, (object)null);
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		if (!((Control)pnlUAE).Visible)
		{
			((Control)pnlUAE).Visible = true;
		}
		else
		{
			((Control)pnlUAE).Visible = false;
		}
	}

	private void btnFxRate_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET FX_RATE = " + Conversions.ToString(Conversion.Val(cboFxRate.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFxRate = Conversion.Val(cboFxRate.Text);
		Interaction.MsgBox((object)"Forex Rate is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnOzConv_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET OZ_CON_VAL = " + Conversions.ToString(Conversion.Val(cboOzCon.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlPrOzConv = Conversion.Val(cboOzCon.Text);
		Interaction.MsgBox((object)"Oz Convert Value Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnFxCode_Click(object sender, EventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET FX_CODE = '" + cboOzCon.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFxCode = cboOzCon.Text;
		Interaction.MsgBox((object)"Forex Code Is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnPrintZoom_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET PRINT_ZOOM = " + Conversions.ToString(Conversion.Val(cboPrintZoom.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPrintZoom = checked((int)Math.Round(Conversion.Val(cboPrintZoom.Text)));
		Interaction.MsgBox((object)"Print View Zooming Set....", (MsgBoxStyle)0, (object)null);
	}
}
