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
public class RP_ALL : Form
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
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSlRpt")]
	private QButton _BtnSlRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSalesReg")]
	private QButton _BtnSalesReg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSalesItem")]
	private QButton _BtnSalesItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcRpt")]
	private QButton _btnPurcRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcReg")]
	private QButton _btnPurcReg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcItem")]
	private QButton _btnPurcItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAprRpt")]
	private QButton _btnAprRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAprInOut")]
	private QButton _btnAprInOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAprPanding")]
	private QButton _BtnAprPanding;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdRpt")]
	private QButton _btnOrdRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdAdvance")]
	private QButton _btnOrdAdvance;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdAdj")]
	private QButton _btnOrdAdj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmBonus")]
	private QButton _btnSchmBonus;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmMothRec")]
	private QButton _btnSchmMothRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmDetail")]
	private QButton _btnSchmDetail;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmWithAdd")]
	private QButton _btnSchmWithAdd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmSumm")]
	private QButton _btnSchmSumm;

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
	[AccessedThroughProperty("btnWhSales")]
	private QButton _btnWhSales;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSalesBill")]
	private QButton _btnSalesBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEmpRpt")]
	private QButton _btnEmpRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnInOutSumm")]
	private QButton _BtnInOutSumm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BrnItmInWord")]
	private QButton _BrnItmInWord;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItmInOut")]
	private QButton _BtnItmInOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItmOutWord")]
	private QButton _BtnItmOutWord;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcBill")]
	private QButton _btnPurcBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCustName")]
	private TextBox _tCustName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdWithBill")]
	private QButton _btnOrdWithBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCashBank")]
	private QButton _btnCashBank;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrRepIsu")]
	private QButton _btnKrRepIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRepRec")]
	private QButton _btnRepRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRepIsu")]
	private QButton _btnRepIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrRepRec")]
	private QButton _btnKrRepRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrIsu")]
	private QButton _btnKrIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrRec")]
	private QButton _btnKrRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnVpPan")]
	private QButton _btnVpPan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAngIsu")]
	private QButton _btnAngIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAngPan")]
	private QButton _btnAngPan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAngAdj")]
	private QButton _btnAngAdj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnVpIsu")]
	private QButton _btnVpIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnVpAdj")]
	private QButton _btnVpAdj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBusSlPanding")]
	private QButton _btnBusSlPanding;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPrBook")]
	private QButton _btnPrBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnBulPrPanding")]
	private QButton _brnBulPrPanding;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnBulPrAdj")]
	private QButton _brnBulPrAdj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlBook")]
	private QButton _btnSlBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnBulSlAdj")]
	private QButton _brnBulSlAdj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrRepPan")]
	private QButton _btnKrRepPan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCustRepPan")]
	private QButton _btnCustRepPan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCustRepIsuPan")]
	private QButton _btnCustRepIsuPan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdMakePan")]
	private QButton _btnOrdMakePan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWhSumm")]
	private QButton _btnWhSumm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAcPurc")]
	private QButton _btnAcPurc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWhEmpSale")]
	private QButton _btnWhEmpSale;

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
	[AccessedThroughProperty("chkBookSelect")]
	private CheckBox _chkBookSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmOpen")]
	private QButton _btnSchmOpen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchmRec")]
	private QButton _btnSchmRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCntrTrfr")]
	private QButton _BtnCntrTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlWithOrder")]
	private QButton _btnSlWithOrder;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCounterSale")]
	private QButton _btnCounterSale;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDesignSumm")]
	private QButton _btnDesignSumm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlGroup")]
	private QButton _btnSlGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLabourRpt")]
	private QButton _btnLabourRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnGroupPurc")]
	private QButton _btnGroupPurc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnb2bSl")]
	private QButton _btnb2bSl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItmSl")]
	private QButton _btnItmSl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnParyPurcSumm")]
	private QButton _btnParyPurcSumm;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string BulRptType;

	private string RepringType;

	private string SchmType;

	private string ScelectBook;

	private string CurFormula;

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
	[AccessedThroughProperty("PanelSale")]
	private virtual Panel _PanelSale;

	internal virtual Panel PanelSale
	{
		get
		{
			return _PanelSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelSale = value;
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
			EventHandler eventHandler = tBookCode_TextChanged;
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tBookCode = value;
			val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox tItCode
	{
		[CompilerGenerated]
		get
		{
			return _tItCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			EventHandler eventHandler = tItCode_TextChanged;
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tItCode = value;
			val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItName")]
	private virtual TextBox _tItName;

	internal virtual TextBox tItName
	{
		get
		{
			return _tItName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItName = value;
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

	internal virtual ComboBox cboItemTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
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

	internal virtual QButton BtnSlRpt
	{
		[CompilerGenerated]
		get
		{
			return _BtnSlRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSlRpt_Click;
			QButton val = _BtnSlRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSlRpt = value;
			val = _BtnSlRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnSalesReg
	{
		[CompilerGenerated]
		get
		{
			return _BtnSalesReg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSalesReg_Click;
			QButton val = _BtnSalesReg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSalesReg = value;
			val = _BtnSalesReg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnSalesItem
	{
		[CompilerGenerated]
		get
		{
			return _BtnSalesItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSalesItem_Click;
			QButton val = _BtnSalesItem;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSalesItem = value;
			val = _BtnSalesItem;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelPurc")]
	private virtual Panel _PanelPurc;

	internal virtual Panel PanelPurc
	{
		get
		{
			return _PanelPurc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelPurc = value;
		}
	}

	internal virtual QButton btnPurcRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurcRpt_Click;
			QButton val = _btnPurcRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcRpt = value;
			val = _btnPurcRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnPurcReg
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcReg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurcReg_Click;
			QButton val = _btnPurcReg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcReg = value;
			val = _btnPurcReg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnPurcItem
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurcItem_Click;
			QButton val = _btnPurcItem;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcItem = value;
			val = _btnPurcItem;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelApr")]
	private virtual Panel _PanelApr;

	internal virtual Panel PanelApr
	{
		get
		{
			return _PanelApr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelApr = value;
		}
	}

	internal virtual QButton btnAprRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnAprRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAprRpt_Click;
			QButton val = _btnAprRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAprRpt = value;
			val = _btnAprRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAprInOut
	{
		[CompilerGenerated]
		get
		{
			return _btnAprInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAprInOut_Click;
			QButton val = _btnAprInOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAprInOut = value;
			val = _btnAprInOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnAprPanding
	{
		[CompilerGenerated]
		get
		{
			return _BtnAprPanding;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAprPanding_Click;
			QButton val = _BtnAprPanding;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAprPanding = value;
			val = _BtnAprPanding;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelOrder")]
	private virtual Panel _PanelOrder;

	internal virtual Panel PanelOrder
	{
		get
		{
			return _PanelOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelOrder = value;
		}
	}

	internal virtual QButton btnOrdRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOrdRpt_Click;
			QButton val = _btnOrdRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdRpt = value;
			val = _btnOrdRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOrdAdvance
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdAdvance;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOrdAdvance_Click;
			QButton val = _btnOrdAdvance;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdAdvance = value;
			val = _btnOrdAdvance;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOrdAdj
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdAdj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOrdAdj_Click;
			QButton val = _btnOrdAdj;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdAdj = value;
			val = _btnOrdAdj;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelSchm")]
	private virtual Panel _PanelSchm;

	internal virtual Panel PanelSchm
	{
		get
		{
			return _PanelSchm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelSchm = value;
		}
	}

	internal virtual QButton btnSchmBonus
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmBonus;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmBonus_Click;
			QButton val = _btnSchmBonus;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmBonus = value;
			val = _btnSchmBonus;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSchmMothRec
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmMothRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmMothRec_Click;
			QButton val = _btnSchmMothRec;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmMothRec = value;
			val = _btnSchmMothRec;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSchmDetail
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmDetail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmDetail_Click;
			QButton val = _btnSchmDetail;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmDetail = value;
			val = _btnSchmDetail;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSchmWithAdd
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmWithAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmWithAdd_Click;
			QButton val = _btnSchmWithAdd;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmWithAdd = value;
			val = _btnSchmWithAdd;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSchmSumm
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmSumm_Click;
			QButton val = _btnSchmSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmSumm = value;
			val = _btnSchmSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFromDt_KeyDown);
			EventHandler eventHandler = mFromDt_GotFocus;
			MaskInputRejectedEventHandler val2 = new MaskInputRejectedEventHandler(mFromDt_MaskInputRejected);
			MaskedTextBox val3 = _mFromDt;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).GotFocus -= eventHandler;
				val3.MaskInputRejected -= val2;
			}
			_mFromDt = value;
			val3 = _mFromDt;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).GotFocus += eventHandler;
				val3.MaskInputRejected += val2;
			}
		}
	}

	internal virtual QButton btnWhSales
	{
		[CompilerGenerated]
		get
		{
			return _btnWhSales;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhSales_Click;
			QButton val = _btnWhSales;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhSales = value;
			val = _btnWhSales;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSalesBill
	{
		[CompilerGenerated]
		get
		{
			return _btnSalesBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSalesBill_Click;
			QButton val = _btnSalesBill;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSalesBill = value;
			val = _btnSalesBill;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnEmpRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnEmpRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnEmpRpt_Click;
			QButton val = _btnEmpRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEmpRpt = value;
			val = _btnEmpRpt;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrName")]
	private virtual TextBox _tGrName;

	internal virtual TextBox tGrName
	{
		get
		{
			return _tGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tGrName = value;
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
	[AccessedThroughProperty("PanelInOut")]
	private virtual Panel _PanelInOut;

	internal virtual Panel PanelInOut
	{
		get
		{
			return _PanelInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelInOut = value;
		}
	}

	internal virtual QButton BtnInOutSumm
	{
		[CompilerGenerated]
		get
		{
			return _BtnInOutSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnInOutSumm_Click;
			QButton val = _BtnInOutSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnInOutSumm = value;
			val = _BtnInOutSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BrnItmInWord
	{
		[CompilerGenerated]
		get
		{
			return _BrnItmInWord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnItmInWord_Click;
			QButton val = _BrnItmInWord;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BrnItmInWord = value;
			val = _BrnItmInWord;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnItmInOut
	{
		[CompilerGenerated]
		get
		{
			return _BtnItmInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItmInOut_Click;
			QButton val = _BtnItmInOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItmInOut = value;
			val = _BtnItmInOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnItmOutWord
	{
		[CompilerGenerated]
		get
		{
			return _BtnItmOutWord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItmOutWord_Click;
			QButton val = _BtnItmOutWord;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItmOutWord = value;
			val = _BtnItmOutWord;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnPurcBill
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurcBill_Click;
			QButton val = _btnPurcBill;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcBill = value;
			val = _btnPurcBill;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tCustName
	{
		[CompilerGenerated]
		get
		{
			return _tCustName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCustName_KeyDown);
			TextBox val2 = _tCustName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCustName = value;
			val2 = _tCustName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual QButton btnOrdWithBill
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdWithBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOrdWithBill_Click;
			QButton val = _btnOrdWithBill;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdWithBill = value;
			val = _btnOrdWithBill;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnCashBank
	{
		[CompilerGenerated]
		get
		{
			return _btnCashBank;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCashBank_Click;
			QButton val = _btnCashBank;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCashBank = value;
			val = _btnCashBank;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlKr")]
	private virtual Panel _PnlKr;

	internal virtual Panel PnlKr
	{
		get
		{
			return _PnlKr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlKr = value;
		}
	}

	internal virtual QButton btnKrRepIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnKrRepIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnKrRepIsu_Click;
			QButton val = _btnKrRepIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrRepIsu = value;
			val = _btnKrRepIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnRepRec
	{
		[CompilerGenerated]
		get
		{
			return _btnRepRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRepRec_Click;
			QButton val = _btnRepRec;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRepRec = value;
			val = _btnRepRec;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnRepIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnRepIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRepIsu_Click;
			QButton val = _btnRepIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRepIsu = value;
			val = _btnRepIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrRepRec
	{
		[CompilerGenerated]
		get
		{
			return _btnKrRepRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnKrRepRec_Click;
			QButton val = _btnKrRepRec;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrRepRec = value;
			val = _btnKrRepRec;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnKrIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnKrIsu_Click;
			QButton val = _btnKrIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrIsu = value;
			val = _btnKrIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrRec
	{
		[CompilerGenerated]
		get
		{
			return _btnKrRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnKrRec_Click;
			QButton val = _btnKrRec;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrRec = value;
			val = _btnKrRec;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlVp")]
	private virtual Panel _pnlVp;

	internal virtual Panel pnlVp
	{
		get
		{
			return _pnlVp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlVp = value;
		}
	}

	internal virtual QButton btnVpPan
	{
		[CompilerGenerated]
		get
		{
			return _btnVpPan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnVpPan_Click;
			QButton val = _btnVpPan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnVpPan = value;
			val = _btnVpPan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAngIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnAngIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAngIsu_Click;
			QButton val = _btnAngIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAngIsu = value;
			val = _btnAngIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAngPan
	{
		[CompilerGenerated]
		get
		{
			return _btnAngPan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAngPan_Click;
			QButton val = _btnAngPan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAngPan = value;
			val = _btnAngPan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAngAdj
	{
		[CompilerGenerated]
		get
		{
			return _btnAngAdj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAngAdj_Click;
			QButton val = _btnAngAdj;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAngAdj = value;
			val = _btnAngAdj;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnVpIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnVpIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnVpIsu_Click;
			QButton val = _btnVpIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnVpIsu = value;
			val = _btnVpIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnVpAdj
	{
		[CompilerGenerated]
		get
		{
			return _btnVpAdj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnVpAdj_Click;
			QButton val = _btnVpAdj;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnVpAdj = value;
			val = _btnVpAdj;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelBul")]
	private virtual Panel _PanelBul;

	internal virtual Panel PanelBul
	{
		get
		{
			return _PanelBul;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelBul = value;
		}
	}

	internal virtual QButton btnBusSlPanding
	{
		[CompilerGenerated]
		get
		{
			return _btnBusSlPanding;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBusSlPanding_Click;
			QButton val = _btnBusSlPanding;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBusSlPanding = value;
			val = _btnBusSlPanding;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnPrBook
	{
		[CompilerGenerated]
		get
		{
			return _btnPrBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPrBook_Click;
			QButton val = _btnPrBook;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPrBook = value;
			val = _btnPrBook;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton brnBulPrPanding
	{
		[CompilerGenerated]
		get
		{
			return _brnBulPrPanding;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnBulPrPanding_Click;
			QButton val = _brnBulPrPanding;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnBulPrPanding = value;
			val = _brnBulPrPanding;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton brnBulPrAdj
	{
		[CompilerGenerated]
		get
		{
			return _brnBulPrAdj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnBulPrAdj_Click;
			QButton val = _brnBulPrAdj;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnBulPrAdj = value;
			val = _brnBulPrAdj;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSlBook
	{
		[CompilerGenerated]
		get
		{
			return _btnSlBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSlBook_Click;
			QButton val = _btnSlBook;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlBook = value;
			val = _btnSlBook;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton brnBulSlAdj
	{
		[CompilerGenerated]
		get
		{
			return _brnBulSlAdj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnBulSlAdj_Click;
			QButton val = _brnBulSlAdj;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnBulSlAdj = value;
			val = _brnBulSlAdj;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnKrRepPan
	{
		[CompilerGenerated]
		get
		{
			return _btnKrRepPan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnKrRepPan_Click;
			QButton val = _btnKrRepPan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrRepPan = value;
			val = _btnKrRepPan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnCustRepPan
	{
		[CompilerGenerated]
		get
		{
			return _btnCustRepPan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCustRepPan_Click;
			QButton val = _btnCustRepPan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCustRepPan = value;
			val = _btnCustRepPan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnCustRepIsuPan
	{
		[CompilerGenerated]
		get
		{
			return _btnCustRepIsuPan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCustRepIsuPan_Click;
			QButton val = _btnCustRepIsuPan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCustRepIsuPan = value;
			val = _btnCustRepIsuPan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOrdMakePan
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdMakePan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOrdMakePan_Click;
			QButton val = _btnOrdMakePan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdMakePan = value;
			val = _btnOrdMakePan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnWhSumm
	{
		[CompilerGenerated]
		get
		{
			return _btnWhSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhSumm_Click;
			QButton val = _btnWhSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhSumm = value;
			val = _btnWhSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAcPurc
	{
		[CompilerGenerated]
		get
		{
			return _btnAcPurc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAcPurc_Click;
			QButton val = _btnAcPurc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAcPurc = value;
			val = _btnAcPurc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEmploy")]
	private virtual ComboBox _cboEmploy;

	internal virtual ComboBox cboEmploy
	{
		get
		{
			return _cboEmploy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboEmploy = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblemp")]
	private virtual Label _lblemp;

	internal virtual Label lblemp
	{
		get
		{
			return _lblemp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblemp = value;
		}
	}

	internal virtual QButton btnWhEmpSale
	{
		[CompilerGenerated]
		get
		{
			return _btnWhEmpSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhEmpSale_Click;
			QButton val = _btnWhEmpSale;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhEmpSale = value;
			val = _btnWhEmpSale;
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

	internal virtual QButton btnSchmOpen
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmOpen_Click;
			QButton val = _btnSchmOpen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmOpen = value;
			val = _btnSchmOpen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboState")]
	private virtual ComboBox _cboState;

	internal virtual ComboBox cboState
	{
		get
		{
			return _cboState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboState = value;
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

	internal virtual QButton btnSchmRec
	{
		[CompilerGenerated]
		get
		{
			return _btnSchmRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSchmRec_Click;
			QButton val = _btnSchmRec;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchmRec = value;
			val = _btnSchmRec;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnCntrTrfr
	{
		[CompilerGenerated]
		get
		{
			return _BtnCntrTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCntrTrfr_Click;
			QButton val = _BtnCntrTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCntrTrfr = value;
			val = _BtnCntrTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSlWithOrder
	{
		[CompilerGenerated]
		get
		{
			return _btnSlWithOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlWithOrder_Click;
			QButton val = _btnSlWithOrder;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlWithOrder = value;
			val = _btnSlWithOrder;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnCounterSale
	{
		[CompilerGenerated]
		get
		{
			return _btnCounterSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCounterSale_Click;
			QButton val = _btnCounterSale;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCounterSale = value;
			val = _btnCounterSale;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnDesignSumm
	{
		[CompilerGenerated]
		get
		{
			return _btnDesignSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnDesignSumm_Click;
			QButton val = _btnDesignSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDesignSumm = value;
			val = _btnDesignSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnSlGroup
	{
		[CompilerGenerated]
		get
		{
			return _btnSlGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlGroup_Click;
			QButton val = _btnSlGroup;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlGroup = value;
			val = _btnSlGroup;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnLabourRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnLabourRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLabourRpt_Click;
			QButton val = _btnLabourRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLabourRpt = value;
			val = _btnLabourRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnGroupPurc
	{
		[CompilerGenerated]
		get
		{
			return _btnGroupPurc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnGroupPurc_Click;
			QButton val = _btnGroupPurc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnGroupPurc = value;
			val = _btnGroupPurc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnb2bSl
	{
		[CompilerGenerated]
		get
		{
			return _btnb2bSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnb2bSl_Click;
			QButton val = _btnb2bSl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnb2bSl = value;
			val = _btnb2bSl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnItmSl
	{
		[CompilerGenerated]
		get
		{
			return _btnItmSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnItmSl_Click;
			QButton val = _btnItmSl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItmSl = value;
			val = _btnItmSl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnParyPurcSumm
	{
		[CompilerGenerated]
		get
		{
			return _btnParyPurcSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnParyPurcSumm_Click;
			QButton val = _btnParyPurcSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnParyPurcSumm = value;
			val = _btnParyPurcSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public RP_ALL()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += RP_ALL_Load;
		((Form)this).Deactivate += RP_ALL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_ALL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_ALL_KeyDown);
		((Form)this).Closed += RP_ALL_Closed;
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
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected O, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected O, but got Unknown
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Expected O, but got Unknown
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Expected O, but got Unknown
		//IL_07de: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e8: Expected O, but got Unknown
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Expected O, but got Unknown
		//IL_08ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Expected O, but got Unknown
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bd: Expected O, but got Unknown
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected O, but got Unknown
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Expected O, but got Unknown
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5d: Expected O, but got Unknown
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c11: Expected O, but got Unknown
		//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7e: Expected O, but got Unknown
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d60: Expected O, but got Unknown
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Expected O, but got Unknown
		//IL_1244: Unknown result type (might be due to invalid IL or missing references)
		//IL_1268: Unknown result type (might be due to invalid IL or missing references)
		//IL_128c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e3: Expected O, but got Unknown
		//IL_1309: Unknown result type (might be due to invalid IL or missing references)
		//IL_157a: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_160f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1619: Expected O, but got Unknown
		//IL_163c: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1919: Unknown result type (might be due to invalid IL or missing references)
		//IL_1942: Unknown result type (might be due to invalid IL or missing references)
		//IL_194c: Expected O, but got Unknown
		//IL_1972: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c75: Expected O, but got Unknown
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9e: Expected O, but got Unknown
		//IL_1fc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2228: Unknown result type (might be due to invalid IL or missing references)
		//IL_224c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2270: Unknown result type (might be due to invalid IL or missing references)
		//IL_2294: Unknown result type (might be due to invalid IL or missing references)
		//IL_22bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c7: Expected O, but got Unknown
		//IL_22ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_254e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2572: Unknown result type (might be due to invalid IL or missing references)
		//IL_2596: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ed: Expected O, but got Unknown
		//IL_260d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2870: Unknown result type (might be due to invalid IL or missing references)
		//IL_2894: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_28dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2905: Unknown result type (might be due to invalid IL or missing references)
		//IL_290f: Expected O, but got Unknown
		//IL_2932: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c01: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c34: Expected O, but got Unknown
		//IL_2c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ede: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f26: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f59: Expected O, but got Unknown
		//IL_2f79: Unknown result type (might be due to invalid IL or missing references)
		//IL_31dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3200: Unknown result type (might be due to invalid IL or missing references)
		//IL_3224: Unknown result type (might be due to invalid IL or missing references)
		//IL_3248: Unknown result type (might be due to invalid IL or missing references)
		//IL_3271: Unknown result type (might be due to invalid IL or missing references)
		//IL_327b: Expected O, but got Unknown
		//IL_329e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3501: Unknown result type (might be due to invalid IL or missing references)
		//IL_3525: Unknown result type (might be due to invalid IL or missing references)
		//IL_3549: Unknown result type (might be due to invalid IL or missing references)
		//IL_356d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3596: Unknown result type (might be due to invalid IL or missing references)
		//IL_35a0: Expected O, but got Unknown
		//IL_35c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3826: Unknown result type (might be due to invalid IL or missing references)
		//IL_384a: Unknown result type (might be due to invalid IL or missing references)
		//IL_386e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3892: Unknown result type (might be due to invalid IL or missing references)
		//IL_38bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_38c5: Expected O, but got Unknown
		//IL_38e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b90: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3be7: Expected O, but got Unknown
		//IL_3c0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f02: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f0c: Expected O, but got Unknown
		//IL_3f2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3faf: Expected O, but got Unknown
		//IL_402c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4036: Expected O, but got Unknown
		//IL_40ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_40c4: Expected O, but got Unknown
		//IL_4175: Unknown result type (might be due to invalid IL or missing references)
		//IL_417f: Expected O, but got Unknown
		//IL_4230: Unknown result type (might be due to invalid IL or missing references)
		//IL_423a: Expected O, but got Unknown
		//IL_42ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_42c4: Expected O, but got Unknown
		//IL_434c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4356: Expected O, but got Unknown
		//IL_4434: Unknown result type (might be due to invalid IL or missing references)
		//IL_443e: Expected O, but got Unknown
		//IL_44be: Unknown result type (might be due to invalid IL or missing references)
		//IL_44c8: Expected O, but got Unknown
		//IL_45a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b0: Expected O, but got Unknown
		//IL_4631: Unknown result type (might be due to invalid IL or missing references)
		//IL_463b: Expected O, but got Unknown
		//IL_46ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_46f9: Expected O, but got Unknown
		//IL_4779: Unknown result type (might be due to invalid IL or missing references)
		//IL_4783: Expected O, but got Unknown
		//IL_480a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4814: Expected O, but got Unknown
		//IL_48d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_48de: Expected O, but got Unknown
		//IL_494e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4958: Expected O, but got Unknown
		//IL_4a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a16: Expected O, but got Unknown
		//IL_4a93: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a9d: Expected O, but got Unknown
		//IL_4b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b2b: Expected O, but got Unknown
		//IL_4edd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f49: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f72: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f7c: Expected O, but got Unknown
		//IL_4fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_5206: Unknown result type (might be due to invalid IL or missing references)
		//IL_522a: Unknown result type (might be due to invalid IL or missing references)
		//IL_524e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5272: Unknown result type (might be due to invalid IL or missing references)
		//IL_529b: Unknown result type (might be due to invalid IL or missing references)
		//IL_52a5: Expected O, but got Unknown
		//IL_52c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5528: Unknown result type (might be due to invalid IL or missing references)
		//IL_554c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5570: Unknown result type (might be due to invalid IL or missing references)
		//IL_5594: Unknown result type (might be due to invalid IL or missing references)
		//IL_55bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_55c7: Expected O, but got Unknown
		//IL_55ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_584d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5871: Unknown result type (might be due to invalid IL or missing references)
		//IL_5895: Unknown result type (might be due to invalid IL or missing references)
		//IL_58b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_58e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_58ec: Expected O, but got Unknown
		//IL_590c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c0e: Expected O, but got Unknown
		//IL_5c31: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_5eb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5edc: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f33: Expected O, but got Unknown
		//IL_5f56: Unknown result type (might be due to invalid IL or missing references)
		//IL_6271: Unknown result type (might be due to invalid IL or missing references)
		//IL_6295: Unknown result type (might be due to invalid IL or missing references)
		//IL_62b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_62dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6306: Unknown result type (might be due to invalid IL or missing references)
		//IL_6310: Expected O, but got Unknown
		//IL_6330: Unknown result type (might be due to invalid IL or missing references)
		//IL_6593: Unknown result type (might be due to invalid IL or missing references)
		//IL_65b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_65db: Unknown result type (might be due to invalid IL or missing references)
		//IL_65ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_6628: Unknown result type (might be due to invalid IL or missing references)
		//IL_6632: Expected O, but got Unknown
		//IL_6655: Unknown result type (might be due to invalid IL or missing references)
		//IL_68b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_68dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_6900: Unknown result type (might be due to invalid IL or missing references)
		//IL_6924: Unknown result type (might be due to invalid IL or missing references)
		//IL_694d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6957: Expected O, but got Unknown
		//IL_697a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d25: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d7c: Expected O, but got Unknown
		//IL_6da2: Unknown result type (might be due to invalid IL or missing references)
		//IL_7005: Unknown result type (might be due to invalid IL or missing references)
		//IL_7029: Unknown result type (might be due to invalid IL or missing references)
		//IL_704d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7071: Unknown result type (might be due to invalid IL or missing references)
		//IL_709a: Unknown result type (might be due to invalid IL or missing references)
		//IL_70a4: Expected O, but got Unknown
		//IL_70c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_732a: Unknown result type (might be due to invalid IL or missing references)
		//IL_734e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7372: Unknown result type (might be due to invalid IL or missing references)
		//IL_7396: Unknown result type (might be due to invalid IL or missing references)
		//IL_73bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_73c9: Expected O, but got Unknown
		//IL_73ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_764f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7673: Unknown result type (might be due to invalid IL or missing references)
		//IL_7697: Unknown result type (might be due to invalid IL or missing references)
		//IL_76bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_76e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_76ee: Expected O, but got Unknown
		//IL_770e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7971: Unknown result type (might be due to invalid IL or missing references)
		//IL_7995: Unknown result type (might be due to invalid IL or missing references)
		//IL_79b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_79dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a10: Expected O, but got Unknown
		//IL_7a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_7cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_7cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d35: Expected O, but got Unknown
		//IL_7d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_80cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_80f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_8117: Unknown result type (might be due to invalid IL or missing references)
		//IL_813b: Unknown result type (might be due to invalid IL or missing references)
		//IL_8164: Unknown result type (might be due to invalid IL or missing references)
		//IL_816e: Expected O, but got Unknown
		//IL_8194: Unknown result type (might be due to invalid IL or missing references)
		//IL_83f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_841b: Unknown result type (might be due to invalid IL or missing references)
		//IL_843f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8463: Unknown result type (might be due to invalid IL or missing references)
		//IL_848c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8496: Expected O, but got Unknown
		//IL_84b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_871c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8740: Unknown result type (might be due to invalid IL or missing references)
		//IL_8764: Unknown result type (might be due to invalid IL or missing references)
		//IL_8788: Unknown result type (might be due to invalid IL or missing references)
		//IL_87b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_87bb: Expected O, but got Unknown
		//IL_87de: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_8aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ad6: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ae0: Expected O, but got Unknown
		//IL_8b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_8d87: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dab: Unknown result type (might be due to invalid IL or missing references)
		//IL_8dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_8df8: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e02: Expected O, but got Unknown
		//IL_8e22: Unknown result type (might be due to invalid IL or missing references)
		//IL_9085: Unknown result type (might be due to invalid IL or missing references)
		//IL_90a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_90cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_90f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_911a: Unknown result type (might be due to invalid IL or missing references)
		//IL_9124: Expected O, but got Unknown
		//IL_9147: Unknown result type (might be due to invalid IL or missing references)
		//IL_93aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_93ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_93f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_9416: Unknown result type (might be due to invalid IL or missing references)
		//IL_943f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9449: Expected O, but got Unknown
		//IL_946c: Unknown result type (might be due to invalid IL or missing references)
		//IL_94e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_94ec: Expected O, but got Unknown
		//IL_9583: Unknown result type (might be due to invalid IL or missing references)
		//IL_958d: Expected O, but got Unknown
		//IL_9624: Unknown result type (might be due to invalid IL or missing references)
		//IL_962e: Expected O, but got Unknown
		//IL_96ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_96b8: Expected O, but got Unknown
		//IL_973f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9749: Expected O, but got Unknown
		//IL_9ad3: Unknown result type (might be due to invalid IL or missing references)
		//IL_9af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_9b72: Expected O, but got Unknown
		//IL_9b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_9df8: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e40: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e64: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_9e97: Expected O, but got Unknown
		//IL_9eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_a11d: Unknown result type (might be due to invalid IL or missing references)
		//IL_a141: Unknown result type (might be due to invalid IL or missing references)
		//IL_a165: Unknown result type (might be due to invalid IL or missing references)
		//IL_a189: Unknown result type (might be due to invalid IL or missing references)
		//IL_a1b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_a1bc: Expected O, but got Unknown
		//IL_a1dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_a43f: Unknown result type (might be due to invalid IL or missing references)
		//IL_a463: Unknown result type (might be due to invalid IL or missing references)
		//IL_a487: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4de: Expected O, but got Unknown
		//IL_a501: Unknown result type (might be due to invalid IL or missing references)
		//IL_a764: Unknown result type (might be due to invalid IL or missing references)
		//IL_a788: Unknown result type (might be due to invalid IL or missing references)
		//IL_a7ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_a7d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_a7f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_a803: Expected O, but got Unknown
		//IL_a826: Unknown result type (might be due to invalid IL or missing references)
		//IL_a89c: Unknown result type (might be due to invalid IL or missing references)
		//IL_a8a6: Expected O, but got Unknown
		//IL_a92a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a934: Expected O, but got Unknown
		//IL_ad1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad62: Unknown result type (might be due to invalid IL or missing references)
		//IL_ad86: Unknown result type (might be due to invalid IL or missing references)
		//IL_adaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_adb9: Expected O, but got Unknown
		//IL_addf: Unknown result type (might be due to invalid IL or missing references)
		//IL_b043: Unknown result type (might be due to invalid IL or missing references)
		//IL_b067: Unknown result type (might be due to invalid IL or missing references)
		//IL_b08b: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0af: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_b0e2: Expected O, but got Unknown
		//IL_b105: Unknown result type (might be due to invalid IL or missing references)
		//IL_b368: Unknown result type (might be due to invalid IL or missing references)
		//IL_b38c: Unknown result type (might be due to invalid IL or missing references)
		//IL_b3b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_b3d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_b3fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_b407: Expected O, but got Unknown
		//IL_b42d: Unknown result type (might be due to invalid IL or missing references)
		//IL_b690: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_b725: Unknown result type (might be due to invalid IL or missing references)
		//IL_b72f: Expected O, but got Unknown
		//IL_b74f: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_b9fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba47: Unknown result type (might be due to invalid IL or missing references)
		//IL_ba51: Expected O, but got Unknown
		//IL_ba74: Unknown result type (might be due to invalid IL or missing references)
		//IL_bcd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_bcfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd43: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd76: Expected O, but got Unknown
		//IL_bd99: Unknown result type (might be due to invalid IL or missing references)
		//IL_bffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_c020: Unknown result type (might be due to invalid IL or missing references)
		//IL_c044: Unknown result type (might be due to invalid IL or missing references)
		//IL_c068: Unknown result type (might be due to invalid IL or missing references)
		//IL_c091: Unknown result type (might be due to invalid IL or missing references)
		//IL_c09b: Expected O, but got Unknown
		//IL_c0be: Unknown result type (might be due to invalid IL or missing references)
		//IL_c321: Unknown result type (might be due to invalid IL or missing references)
		//IL_c345: Unknown result type (might be due to invalid IL or missing references)
		//IL_c369: Unknown result type (might be due to invalid IL or missing references)
		//IL_c38d: Unknown result type (might be due to invalid IL or missing references)
		//IL_c3b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_c3c0: Expected O, but got Unknown
		//IL_c3e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_c646: Unknown result type (might be due to invalid IL or missing references)
		//IL_c66a: Unknown result type (might be due to invalid IL or missing references)
		//IL_c68e: Unknown result type (might be due to invalid IL or missing references)
		//IL_c6b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_c6db: Unknown result type (might be due to invalid IL or missing references)
		//IL_c6e5: Expected O, but got Unknown
		//IL_c708: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_cab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_cad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb00: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb0a: Expected O, but got Unknown
		//IL_cb2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_cd90: Unknown result type (might be due to invalid IL or missing references)
		//IL_cdb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_cdd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_cdfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce25: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce2f: Expected O, but got Unknown
		//IL_ce4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_d0fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_d11e: Unknown result type (might be due to invalid IL or missing references)
		//IL_d147: Unknown result type (might be due to invalid IL or missing references)
		//IL_d151: Expected O, but got Unknown
		//IL_d174: Unknown result type (might be due to invalid IL or missing references)
		//IL_d3d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_d3fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_d41f: Unknown result type (might be due to invalid IL or missing references)
		//IL_d443: Unknown result type (might be due to invalid IL or missing references)
		//IL_d46c: Unknown result type (might be due to invalid IL or missing references)
		//IL_d476: Expected O, but got Unknown
		//IL_d499: Unknown result type (might be due to invalid IL or missing references)
		//IL_d6fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_d720: Unknown result type (might be due to invalid IL or missing references)
		//IL_d744: Unknown result type (might be due to invalid IL or missing references)
		//IL_d768: Unknown result type (might be due to invalid IL or missing references)
		//IL_d791: Unknown result type (might be due to invalid IL or missing references)
		//IL_d79b: Expected O, but got Unknown
		//IL_d7bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_da1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_da42: Unknown result type (might be due to invalid IL or missing references)
		//IL_da66: Unknown result type (might be due to invalid IL or missing references)
		//IL_da8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_dab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_dabd: Expected O, but got Unknown
		//IL_dae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_de43: Unknown result type (might be due to invalid IL or missing references)
		//IL_de67: Unknown result type (might be due to invalid IL or missing references)
		//IL_de8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_deaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_ded8: Unknown result type (might be due to invalid IL or missing references)
		//IL_dee2: Expected O, but got Unknown
		//IL_df05: Unknown result type (might be due to invalid IL or missing references)
		//IL_e168: Unknown result type (might be due to invalid IL or missing references)
		//IL_e18c: Unknown result type (might be due to invalid IL or missing references)
		//IL_e1b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_e1d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_e1fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_e207: Expected O, but got Unknown
		//IL_e227: Unknown result type (might be due to invalid IL or missing references)
		//IL_e48a: Unknown result type (might be due to invalid IL or missing references)
		//IL_e4ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_e4d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_e4f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_e51f: Unknown result type (might be due to invalid IL or missing references)
		//IL_e529: Expected O, but got Unknown
		//IL_e54c: Unknown result type (might be due to invalid IL or missing references)
		//IL_e7af: Unknown result type (might be due to invalid IL or missing references)
		//IL_e7d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_e7f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_e81b: Unknown result type (might be due to invalid IL or missing references)
		//IL_e844: Unknown result type (might be due to invalid IL or missing references)
		//IL_e84e: Expected O, but got Unknown
		//IL_e871: Unknown result type (might be due to invalid IL or missing references)
		//IL_ead4: Unknown result type (might be due to invalid IL or missing references)
		//IL_eaf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_eb1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_eb40: Unknown result type (might be due to invalid IL or missing references)
		//IL_eb69: Unknown result type (might be due to invalid IL or missing references)
		//IL_eb73: Expected O, but got Unknown
		//IL_eb93: Unknown result type (might be due to invalid IL or missing references)
		//IL_edf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee62: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee95: Expected O, but got Unknown
		//IL_eeb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_ef58: Unknown result type (might be due to invalid IL or missing references)
		//IL_ef62: Expected O, but got Unknown
		//IL_eff3: Unknown result type (might be due to invalid IL or missing references)
		//IL_effd: Expected O, but got Unknown
		//IL_f370: Unknown result type (might be due to invalid IL or missing references)
		//IL_f394: Unknown result type (might be due to invalid IL or missing references)
		//IL_f3b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_f3dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_f405: Unknown result type (might be due to invalid IL or missing references)
		//IL_f40f: Expected O, but got Unknown
		//IL_f435: Unknown result type (might be due to invalid IL or missing references)
		//IL_f699: Unknown result type (might be due to invalid IL or missing references)
		//IL_f6bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_f6e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_f705: Unknown result type (might be due to invalid IL or missing references)
		//IL_f72e: Unknown result type (might be due to invalid IL or missing references)
		//IL_f738: Expected O, but got Unknown
		//IL_f75b: Unknown result type (might be due to invalid IL or missing references)
		//IL_f7ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_f7f9: Expected O, but got Unknown
		//IL_f88e: Unknown result type (might be due to invalid IL or missing references)
		//IL_f898: Expected O, but got Unknown
		//IL_f916: Unknown result type (might be due to invalid IL or missing references)
		//IL_f920: Expected O, but got Unknown
		//IL_f9f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_f9ff: Expected O, but got Unknown
		//IL_fa68: Unknown result type (might be due to invalid IL or missing references)
		//IL_fa72: Expected O, but got Unknown
		//IL_fb25: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb2f: Expected O, but got Unknown
		//IL_fc19: Unknown result type (might be due to invalid IL or missing references)
		//IL_fc23: Expected O, but got Unknown
		//IL_fcb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_fcbb: Expected O, but got Unknown
		//IL_ff66: Unknown result type (might be due to invalid IL or missing references)
		//IL_ff8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ffae: Unknown result type (might be due to invalid IL or missing references)
		//IL_ffd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_fffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10005: Expected O, but got Unknown
		//IL_10028: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_ALL));
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
		Cr = new AxCrystalReport();
		lblBook = new Label();
		PanelSale = new Panel();
		btnb2bSl = new QButton();
		btnItmSl = new QButton();
		btnLabourRpt = new QButton();
		btnSlGroup = new QButton();
		btnSlWithOrder = new QButton();
		btnCounterSale = new QButton();
		btnWhEmpSale = new QButton();
		btnWhSumm = new QButton();
		btnCashBank = new QButton();
		btnEmpRpt = new QButton();
		btnWhSales = new QButton();
		btnSalesBill = new QButton();
		BtnSlRpt = new QButton();
		BtnSalesReg = new QButton();
		BtnSalesItem = new QButton();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label1 = new Label();
		Label2 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label3 = new Label();
		cboCity = new ComboBox();
		lblCity = new Label();
		cboArea = new ComboBox();
		Label17 = new Label();
		tItCode = new TextBox();
		tItName = new TextBox();
		Label4 = new Label();
		cboItemTyp = new ComboBox();
		Label5 = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		PanelPurc = new Panel();
		btnGroupPurc = new QButton();
		btnAcPurc = new QButton();
		btnPurcBill = new QButton();
		btnPurcRpt = new QButton();
		btnPurcReg = new QButton();
		btnPurcItem = new QButton();
		PanelApr = new Panel();
		btnAprRpt = new QButton();
		btnAprInOut = new QButton();
		BtnAprPanding = new QButton();
		PanelOrder = new Panel();
		btnDesignSumm = new QButton();
		btnOrdMakePan = new QButton();
		btnOrdWithBill = new QButton();
		btnOrdRpt = new QButton();
		btnOrdAdvance = new QButton();
		btnOrdAdj = new QButton();
		PanelSchm = new Panel();
		btnSchmRec = new QButton();
		btnSchmOpen = new QButton();
		btnSchmBonus = new QButton();
		btnSchmMothRec = new QButton();
		btnSchmDetail = new QButton();
		btnSchmWithAdd = new QButton();
		btnSchmSumm = new QButton();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		tGrCode = new TextBox();
		tGrName = new TextBox();
		Label7 = new Label();
		PanelInOut = new Panel();
		BtnCntrTrfr = new QButton();
		BtnInOutSumm = new QButton();
		BrnItmInWord = new QButton();
		BtnItmInOut = new QButton();
		BtnItmOutWord = new QButton();
		tCustName = new TextBox();
		Label8 = new Label();
		PnlKr = new Panel();
		btnCustRepIsuPan = new QButton();
		btnKrRepPan = new QButton();
		btnCustRepPan = new QButton();
		btnKrRepIsu = new QButton();
		btnRepRec = new QButton();
		btnRepIsu = new QButton();
		btnKrRepRec = new QButton();
		btnKrIsu = new QButton();
		btnKrRec = new QButton();
		pnlVp = new Panel();
		btnVpPan = new QButton();
		btnAngIsu = new QButton();
		btnAngPan = new QButton();
		btnAngAdj = new QButton();
		btnVpIsu = new QButton();
		btnVpAdj = new QButton();
		PanelBul = new Panel();
		btnBusSlPanding = new QButton();
		btnPrBook = new QButton();
		brnBulPrPanding = new QButton();
		brnBulPrAdj = new QButton();
		btnSlBook = new QButton();
		brnBulSlAdj = new QButton();
		cboEmploy = new ComboBox();
		lblemp = new Label();
		PnlIt = new Panel();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DataGridViewX();
		chkBookSelect = new CheckBox();
		cboState = new ComboBox();
		Label9 = new Label();
		btnParyPurcSumm = new QButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)PanelSale).SuspendLayout();
		((Control)PanelPurc).SuspendLayout();
		((Control)PanelApr).SuspendLayout();
		((Control)PanelOrder).SuspendLayout();
		((Control)PanelSchm).SuspendLayout();
		((Control)PanelInOut).SuspendLayout();
		((Control)PnlKr).SuspendLayout();
		((Control)pnlVp).SuspendLayout();
		((Control)PanelBul).SuspendLayout();
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
		((Control)BtnExit).TabIndex = 25;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnDelete.ImageOptions.SvgImage");
		((Control)BtnDelete).Location = new Point(1118, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 24;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnCancel.ImageOptions.SvgImage");
		((Control)BtnCancel).Location = new Point(1021, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 23;
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
		((Control)BtnSave).TabIndex = 22;
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
		((Control)lblBook).TabIndex = 11;
		lblBook.Text = "Report All";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)PanelSale).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelSale).Controls.Add((Control)(object)btnb2bSl);
		((Control)PanelSale).Controls.Add((Control)(object)btnItmSl);
		((Control)PanelSale).Controls.Add((Control)(object)btnLabourRpt);
		((Control)PanelSale).Controls.Add((Control)(object)btnSlGroup);
		((Control)PanelSale).Controls.Add((Control)(object)btnSlWithOrder);
		((Control)PanelSale).Controls.Add((Control)(object)btnCounterSale);
		((Control)PanelSale).Controls.Add((Control)(object)btnWhEmpSale);
		((Control)PanelSale).Controls.Add((Control)(object)btnWhSumm);
		((Control)PanelSale).Controls.Add((Control)(object)btnCashBank);
		((Control)PanelSale).Controls.Add((Control)(object)btnEmpRpt);
		((Control)PanelSale).Controls.Add((Control)(object)btnWhSales);
		((Control)PanelSale).Controls.Add((Control)(object)btnSalesBill);
		((Control)PanelSale).Controls.Add((Control)(object)BtnSlRpt);
		((Control)PanelSale).Controls.Add((Control)(object)BtnSalesReg);
		((Control)PanelSale).Controls.Add((Control)(object)BtnSalesItem);
		((Control)PanelSale).Location = new Point(239, 308);
		((Control)PanelSale).Name = "PanelSale";
		((Control)PanelSale).Size = new Size(712, 252);
		((Control)PanelSale).TabIndex = 9;
		((Control)PanelSale).Visible = false;
		((QControl)btnb2bSl).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnb2bSl).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnb2bSl).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnb2bSl).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnb2bSl).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnb2bSl).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnb2bSl).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnb2bSl).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnb2bSl).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnb2bSl).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnb2bSl).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnb2bSl).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnb2bSl).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnb2bSl).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnb2bSl.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnb2bSl.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnb2bSl.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnb2bSl.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnb2bSl.Image = null;
		((QControl)btnb2bSl).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnb2bSl).Location = new Point(471, 206);
		((Control)btnb2bSl).Margin = new Padding(3, 6, 3, 6);
		((Control)btnb2bSl).Name = "btnb2bSl";
		((Control)btnb2bSl).Size = new Size(143, 37);
		((Control)btnb2bSl).TabIndex = 14;
		btnb2bSl.Text = "&B2B Bill";
		((Control)btnb2bSl).Visible = false;
		((QControl)btnItmSl).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItmSl).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItmSl).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItmSl).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItmSl).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItmSl).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItmSl).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnItmSl).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItmSl).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItmSl).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItmSl).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItmSl).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItmSl).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItmSl).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItmSl.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmSl.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmSl.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmSl.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmSl.Image = null;
		((QControl)btnItmSl).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItmSl).Location = new Point(102, 206);
		((Control)btnItmSl).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItmSl).Name = "btnItmSl";
		((Control)btnItmSl).Size = new Size(143, 37);
		((Control)btnItmSl).TabIndex = 13;
		btnItmSl.Text = "&Item Bill";
		((Control)btnItmSl).Visible = false;
		((QControl)btnLabourRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLabourRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLabourRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLabourRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLabourRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLabourRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLabourRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLabourRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLabourRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLabourRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLabourRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLabourRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLabourRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLabourRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLabourRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLabourRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLabourRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLabourRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLabourRpt.Image = null;
		((QControl)btnLabourRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLabourRpt).Location = new Point(285, 206);
		((Control)btnLabourRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLabourRpt).Name = "btnLabourRpt";
		((Control)btnLabourRpt).Size = new Size(143, 37);
		((Control)btnLabourRpt).TabIndex = 12;
		btnLabourRpt.Text = "&Labour Work";
		((QControl)btnSlGroup).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlGroup).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlGroup).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlGroup).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlGroup).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlGroup).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlGroup).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlGroup).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlGroup).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlGroup).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlGroup).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlGroup).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlGroup).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlGroup).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlGroup.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlGroup.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlGroup.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlGroup.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlGroup.Image = null;
		((QControl)btnSlGroup).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlGroup).Location = new Point(285, 158);
		((Control)btnSlGroup).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlGroup).Name = "btnSlGroup";
		((Control)btnSlGroup).Size = new Size(143, 37);
		((Control)btnSlGroup).TabIndex = 11;
		btnSlGroup.Text = "&Group Sales";
		((QControl)btnSlWithOrder).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlWithOrder).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlWithOrder).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlWithOrder).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlWithOrder.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithOrder.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithOrder.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithOrder.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithOrder.Image = null;
		((QControl)btnSlWithOrder).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlWithOrder).Location = new Point(471, 158);
		((Control)btnSlWithOrder).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlWithOrder).Name = "btnSlWithOrder";
		((Control)btnSlWithOrder).Size = new Size(143, 37);
		((Control)btnSlWithOrder).TabIndex = 10;
		btnSlWithOrder.Text = "&Sale With Order";
		((QControl)btnCounterSale).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCounterSale).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCounterSale).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCounterSale).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCounterSale).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCounterSale).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCounterSale).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCounterSale).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCounterSale).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCounterSale).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCounterSale).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCounterSale).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCounterSale).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCounterSale).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCounterSale.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterSale.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterSale.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterSale.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterSale.Image = null;
		((QControl)btnCounterSale).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCounterSale).Location = new Point(102, 158);
		((Control)btnCounterSale).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCounterSale).Name = "btnCounterSale";
		((Control)btnCounterSale).Size = new Size(143, 37);
		((Control)btnCounterSale).TabIndex = 9;
		btnCounterSale.Text = "&Counter Sales";
		((QControl)btnWhEmpSale).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhEmpSale).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhEmpSale).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhEmpSale).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhEmpSale.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhEmpSale.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhEmpSale.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhEmpSale.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhEmpSale.Image = null;
		((QControl)btnWhEmpSale).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhEmpSale).Location = new Point(102, 110);
		((Control)btnWhEmpSale).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhEmpSale).Name = "btnWhEmpSale";
		((Control)btnWhEmpSale).Size = new Size(143, 37);
		((Control)btnWhEmpSale).TabIndex = 8;
		btnWhEmpSale.Text = "Emp  WhSales";
		((QControl)btnWhSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWhSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSumm.Image = null;
		((QControl)btnWhSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhSumm).Location = new Point(471, 110);
		((Control)btnWhSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhSumm).Name = "btnWhSumm";
		((Control)btnWhSumm).Size = new Size(143, 37);
		((Control)btnWhSumm).TabIndex = 7;
		btnWhSumm.Text = "&Wh Summ";
		((QControl)btnCashBank).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCashBank).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCashBank).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCashBank).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCashBank).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCashBank).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCashBank).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCashBank).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCashBank).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCashBank).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCashBank).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCashBank).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCashBank).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCashBank).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCashBank.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashBank.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashBank.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashBank.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashBank.Image = null;
		((QControl)btnCashBank).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCashBank).Location = new Point(471, 62);
		((Control)btnCashBank).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCashBank).Name = "btnCashBank";
		((Control)btnCashBank).Size = new Size(143, 37);
		((Control)btnCashBank).TabIndex = 6;
		btnCashBank.Text = "&Cash/Bank Bill";
		((QControl)btnEmpRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnEmpRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEmpRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnEmpRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnEmpRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnEmpRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEmpRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnEmpRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnEmpRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnEmpRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnEmpRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnEmpRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnEmpRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnEmpRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnEmpRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpRpt.Image = null;
		((QControl)btnEmpRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnEmpRpt).Location = new Point(102, 62);
		((Control)btnEmpRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)btnEmpRpt).Name = "btnEmpRpt";
		((Control)btnEmpRpt).Size = new Size(143, 37);
		((Control)btnEmpRpt).TabIndex = 5;
		btnEmpRpt.Text = "Employ  Sales";
		((QControl)btnWhSales).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhSales).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSales).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhSales).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhSales).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhSales).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSales).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWhSales).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhSales).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhSales).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhSales).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhSales).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhSales).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhSales).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhSales.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSales.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSales.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSales.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSales.Image = null;
		((QControl)btnWhSales).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhSales).Location = new Point(285, 110);
		((Control)btnWhSales).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhSales).Name = "btnWhSales";
		((Control)btnWhSales).Size = new Size(143, 37);
		((Control)btnWhSales).TabIndex = 4;
		btnWhSales.Text = "&Wh Sales";
		((QControl)btnSalesBill).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSalesBill).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSalesBill).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSalesBill).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSalesBill).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSalesBill).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSalesBill).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSalesBill).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSalesBill).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSalesBill).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSalesBill).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSalesBill).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSalesBill).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSalesBill).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSalesBill.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSalesBill.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSalesBill.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSalesBill.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSalesBill.Image = null;
		((QControl)btnSalesBill).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSalesBill).Location = new Point(285, 62);
		((Control)btnSalesBill).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSalesBill).Name = "btnSalesBill";
		((Control)btnSalesBill).Size = new Size(143, 37);
		((Control)btnSalesBill).TabIndex = 3;
		btnSalesBill.Text = "&Sales Bill";
		((QControl)BtnSlRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSlRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSlRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSlRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSlRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSlRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSlRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnSlRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSlRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSlRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSlRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSlRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSlRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSlRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSlRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSlRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSlRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSlRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSlRpt.Image = null;
		((QControl)BtnSlRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSlRpt).Location = new Point(102, 13);
		((Control)BtnSlRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSlRpt).Name = "BtnSlRpt";
		((Control)BtnSlRpt).Size = new Size(143, 37);
		((Control)BtnSlRpt).TabIndex = 0;
		BtnSlRpt.Text = "&Sales Report";
		((QControl)BtnSalesReg).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSalesReg).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSalesReg).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSalesReg).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSalesReg).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSalesReg).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSalesReg).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSalesReg).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSalesReg).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSalesReg).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSalesReg).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSalesReg).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSalesReg).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSalesReg).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSalesReg.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesReg.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesReg.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesReg.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesReg.Image = null;
		((QControl)BtnSalesReg).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSalesReg).Location = new Point(285, 13);
		((Control)BtnSalesReg).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSalesReg).Name = "BtnSalesReg";
		((Control)BtnSalesReg).Size = new Size(143, 37);
		((Control)BtnSalesReg).TabIndex = 1;
		BtnSalesReg.Text = "&Sales Reg";
		((QControl)BtnSalesItem).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSalesItem).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSalesItem).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSalesItem).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSalesItem).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSalesItem).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSalesItem).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSalesItem).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSalesItem).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSalesItem).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSalesItem).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSalesItem).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSalesItem).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSalesItem).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSalesItem.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesItem.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesItem.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesItem.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSalesItem.Image = null;
		((QControl)BtnSalesItem).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSalesItem).Location = new Point(471, 13);
		((Control)BtnSalesItem).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSalesItem).Name = "BtnSalesItem";
		((Control)BtnSalesItem).Size = new Size(143, 37);
		((Control)BtnSalesItem).TabIndex = 2;
		BtnSalesItem.Text = "&Item Wise";
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(475, 107);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(76, 23);
		((Control)tBookCode).TabIndex = 3;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(557, 106);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(282, 23);
		((Control)tBookName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(370, 107);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(97, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Book";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(367, 47);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "From / To Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(475, 193);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 6;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(557, 193);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(382, 191);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(85, 20);
		((Control)Label3).TabIndex = 1165;
		Label3.Text = "Party Code";
		Label3.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(475, 251);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(148, 22);
		((Control)cboCity).TabIndex = 8;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(407, 252);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(58, 19);
		((Control)lblCity).TabIndex = 1166;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(692, 252);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(147, 22);
		((Control)cboArea).TabIndex = 9;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(638, 253);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(47, 19);
		((Control)Label17).TabIndex = 1168;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItCode).Location = new Point(475, 135);
		((TextBoxBase)tItCode).MaxLength = 8;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(76, 23);
		((Control)tItCode).TabIndex = 4;
		((TextBoxBase)tItName).BackColor = Color.White;
		((Control)tItName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItName).Location = new Point(557, 135);
		((TextBoxBase)tItName).MaxLength = 8;
		((Control)tItName).Name = "tItName";
		((Control)tItName).Size = new Size(282, 23);
		((Control)tItName).TabIndex = 1172;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(395, 134);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(72, 20);
		((Control)Label4).TabIndex = 1171;
		Label4.Text = "Pr Code";
		Label4.TextAlign = (ContentAlignment)64;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(475, 279);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(148, 22);
		((Control)cboItemTyp).TabIndex = 10;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(370, 281);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(99, 20);
		((Control)Label5).TabIndex = 1174;
		Label5.Text = "Item Type";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(475, 77);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(76, 23);
		((Control)tLcCode).TabIndex = 2;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(557, 76);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(282, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(408, 77);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)PanelPurc).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelPurc).Controls.Add((Control)(object)btnParyPurcSumm);
		((Control)PanelPurc).Controls.Add((Control)(object)btnGroupPurc);
		((Control)PanelPurc).Controls.Add((Control)(object)btnAcPurc);
		((Control)PanelPurc).Controls.Add((Control)(object)btnPurcBill);
		((Control)PanelPurc).Controls.Add((Control)(object)btnPurcRpt);
		((Control)PanelPurc).Controls.Add((Control)(object)btnPurcReg);
		((Control)PanelPurc).Controls.Add((Control)(object)btnPurcItem);
		((Control)PanelPurc).Location = new Point(775, 53);
		((Control)PanelPurc).Name = "PanelPurc";
		((Control)PanelPurc).Size = new Size(712, 185);
		((Control)PanelPurc).TabIndex = 1178;
		((Control)PanelPurc).Visible = false;
		((QControl)btnGroupPurc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnGroupPurc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGroupPurc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnGroupPurc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnGroupPurc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnGroupPurc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGroupPurc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGroupPurc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnGroupPurc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnGroupPurc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnGroupPurc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGroupPurc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnGroupPurc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnGroupPurc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnGroupPurc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGroupPurc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGroupPurc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGroupPurc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGroupPurc.Image = null;
		((QControl)btnGroupPurc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnGroupPurc).Location = new Point(285, 128);
		((Control)btnGroupPurc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnGroupPurc).Name = "btnGroupPurc";
		((Control)btnGroupPurc).Size = new Size(143, 37);
		((Control)btnGroupPurc).TabIndex = 12;
		btnGroupPurc.Text = "&Group Purc";
		((QControl)btnAcPurc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAcPurc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAcPurc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAcPurc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAcPurc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAcPurc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAcPurc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAcPurc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAcPurc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAcPurc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAcPurc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAcPurc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAcPurc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAcPurc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAcPurc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcPurc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcPurc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcPurc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcPurc.Image = null;
		((QControl)btnAcPurc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAcPurc).Location = new Point(102, 76);
		((Control)btnAcPurc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAcPurc).Name = "btnAcPurc";
		((Control)btnAcPurc).Size = new Size(143, 37);
		((Control)btnAcPurc).TabIndex = 5;
		btnAcPurc.Text = "&Party Purc";
		((QControl)btnPurcBill).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurcBill).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcBill).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurcBill).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurcBill).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurcBill).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcBill).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPurcBill).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurcBill).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurcBill).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurcBill).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcBill).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurcBill).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurcBill).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurcBill.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcBill.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcBill.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcBill.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcBill.Image = null;
		((QControl)btnPurcBill).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurcBill).Location = new Point(471, 76);
		((Control)btnPurcBill).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurcBill).Name = "btnPurcBill";
		((Control)btnPurcBill).Size = new Size(143, 37);
		((Control)btnPurcBill).TabIndex = 4;
		btnPurcBill.Text = "&Purchase Bill";
		((QControl)btnPurcRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurcRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurcRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurcRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurcRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPurcRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurcRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurcRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurcRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurcRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurcRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurcRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcRpt.Image = null;
		((QControl)btnPurcRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurcRpt).Location = new Point(102, 24);
		((Control)btnPurcRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurcRpt).Name = "btnPurcRpt";
		((Control)btnPurcRpt).Size = new Size(143, 37);
		((Control)btnPurcRpt).TabIndex = 0;
		btnPurcRpt.Text = "&Purc Report";
		((QControl)btnPurcReg).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurcReg).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcReg).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurcReg).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurcReg).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurcReg).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcReg).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcReg).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurcReg).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurcReg).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurcReg).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcReg).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurcReg).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurcReg).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurcReg.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcReg.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcReg.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcReg.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcReg.Image = null;
		((QControl)btnPurcReg).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurcReg).Location = new Point(285, 24);
		((Control)btnPurcReg).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurcReg).Name = "btnPurcReg";
		((Control)btnPurcReg).Size = new Size(143, 37);
		((Control)btnPurcReg).TabIndex = 1;
		btnPurcReg.Text = "&Purc Reg";
		((QControl)btnPurcItem).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurcItem).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcItem).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurcItem).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurcItem).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurcItem).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcItem).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcItem).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurcItem).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurcItem).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurcItem).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcItem).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurcItem).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurcItem).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurcItem.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcItem.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcItem.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcItem.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcItem.Image = null;
		((QControl)btnPurcItem).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurcItem).Location = new Point(471, 24);
		((Control)btnPurcItem).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurcItem).Name = "btnPurcItem";
		((Control)btnPurcItem).Size = new Size(143, 37);
		((Control)btnPurcItem).TabIndex = 2;
		btnPurcItem.Text = "&Item Wise";
		((Control)PanelApr).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelApr).Controls.Add((Control)(object)btnAprRpt);
		((Control)PanelApr).Controls.Add((Control)(object)btnAprInOut);
		((Control)PanelApr).Controls.Add((Control)(object)BtnAprPanding);
		((Control)PanelApr).Location = new Point(963, 404);
		((Control)PanelApr).Name = "PanelApr";
		((Control)PanelApr).Size = new Size(712, 116);
		((Control)PanelApr).TabIndex = 1179;
		((Control)PanelApr).Visible = false;
		((QControl)btnAprRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAprRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAprRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAprRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAprRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAprRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAprRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAprRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAprRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAprRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAprRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAprRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAprRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAprRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAprRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprRpt.Image = null;
		((QControl)btnAprRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAprRpt).Location = new Point(102, 24);
		((Control)btnAprRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAprRpt).Name = "btnAprRpt";
		((Control)btnAprRpt).Size = new Size(143, 37);
		((Control)btnAprRpt).TabIndex = 0;
		btnAprRpt.Text = "&Approval Isu";
		((QControl)btnAprInOut).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAprInOut).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAprInOut).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAprInOut).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAprInOut).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAprInOut).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAprInOut).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAprInOut).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAprInOut).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAprInOut).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAprInOut).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAprInOut).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAprInOut).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAprInOut).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAprInOut.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprInOut.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprInOut.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprInOut.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprInOut.Image = null;
		((QControl)btnAprInOut).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAprInOut).Location = new Point(285, 24);
		((Control)btnAprInOut).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAprInOut).Name = "btnAprInOut";
		((Control)btnAprInOut).Size = new Size(143, 37);
		((Control)btnAprInOut).TabIndex = 1;
		btnAprInOut.Text = "&Approval InOut";
		((QControl)BtnAprPanding).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnAprPanding).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAprPanding).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnAprPanding).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnAprPanding).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnAprPanding).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAprPanding).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAprPanding).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnAprPanding).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnAprPanding).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnAprPanding).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAprPanding).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnAprPanding).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnAprPanding).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnAprPanding.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAprPanding.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAprPanding.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAprPanding.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAprPanding.Image = null;
		((QControl)BtnAprPanding).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnAprPanding).Location = new Point(471, 24);
		((Control)BtnAprPanding).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnAprPanding).Name = "BtnAprPanding";
		((Control)BtnAprPanding).Size = new Size(143, 37);
		((Control)BtnAprPanding).TabIndex = 2;
		BtnAprPanding.Text = "&Approval Panding";
		((Control)PanelOrder).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelOrder).Controls.Add((Control)(object)btnDesignSumm);
		((Control)PanelOrder).Controls.Add((Control)(object)btnOrdMakePan);
		((Control)PanelOrder).Controls.Add((Control)(object)btnOrdWithBill);
		((Control)PanelOrder).Controls.Add((Control)(object)btnOrdRpt);
		((Control)PanelOrder).Controls.Add((Control)(object)btnOrdAdvance);
		((Control)PanelOrder).Controls.Add((Control)(object)btnOrdAdj);
		((Control)PanelOrder).Location = new Point(957, 217);
		((Control)PanelOrder).Name = "PanelOrder";
		((Control)PanelOrder).Size = new Size(705, 181);
		((Control)PanelOrder).TabIndex = 1180;
		((Control)PanelOrder).Visible = false;
		((QControl)btnDesignSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDesignSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDesignSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDesignSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDesignSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDesignSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDesignSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDesignSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDesignSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDesignSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDesignSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDesignSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDesignSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDesignSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDesignSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignSumm.Image = null;
		((QControl)btnDesignSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDesignSumm).Location = new Point(285, 132);
		((Control)btnDesignSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDesignSumm).Name = "btnDesignSumm";
		((Control)btnDesignSumm).Size = new Size(143, 37);
		((Control)btnDesignSumm).TabIndex = 5;
		btnDesignSumm.Text = "& Making Summ";
		((QControl)btnOrdMakePan).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdMakePan).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdMakePan).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdMakePan).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdMakePan.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdMakePan.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdMakePan.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdMakePan.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdMakePan.Image = null;
		((QControl)btnOrdMakePan).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdMakePan).Location = new Point(378, 79);
		((Control)btnOrdMakePan).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdMakePan).Name = "btnOrdMakePan";
		((Control)btnOrdMakePan).Size = new Size(143, 37);
		((Control)btnOrdMakePan).TabIndex = 4;
		btnOrdMakePan.Text = "&Making Panding";
		((QControl)btnOrdWithBill).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdWithBill).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdWithBill).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdWithBill).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdWithBill.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdWithBill.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdWithBill.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdWithBill.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdWithBill.Image = null;
		((QControl)btnOrdWithBill).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdWithBill).Location = new Point(193, 79);
		((Control)btnOrdWithBill).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdWithBill).Name = "btnOrdWithBill";
		((Control)btnOrdWithBill).Size = new Size(143, 37);
		((Control)btnOrdWithBill).TabIndex = 3;
		btnOrdWithBill.Text = "&Bill Wise Adjust";
		((QControl)btnOrdRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOrdRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdRpt.Image = null;
		((QControl)btnOrdRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdRpt).Location = new Point(102, 24);
		((Control)btnOrdRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdRpt).Name = "btnOrdRpt";
		((Control)btnOrdRpt).Size = new Size(143, 37);
		((Control)btnOrdRpt).TabIndex = 0;
		btnOrdRpt.Text = "&Order Report";
		((QControl)btnOrdAdvance).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdAdvance).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdAdvance).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdAdvance).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdAdvance.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdvance.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdvance.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdvance.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdvance.Image = null;
		((QControl)btnOrdAdvance).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdAdvance).Location = new Point(285, 24);
		((Control)btnOrdAdvance).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdAdvance).Name = "btnOrdAdvance";
		((Control)btnOrdAdvance).Size = new Size(143, 37);
		((Control)btnOrdAdvance).TabIndex = 1;
		btnOrdAdvance.Text = "&Order Advance";
		((QControl)btnOrdAdj).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdAdj).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdAdj).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdAdj).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdAdj).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdAdj).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdAdj).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdAdj).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdAdj).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdAdj).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdAdj).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdAdj).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdAdj).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdAdj).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdAdj.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdj.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdj.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdj.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdAdj.Image = null;
		((QControl)btnOrdAdj).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdAdj).Location = new Point(471, 24);
		((Control)btnOrdAdj).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdAdj).Name = "btnOrdAdj";
		((Control)btnOrdAdj).Size = new Size(143, 37);
		((Control)btnOrdAdj).TabIndex = 2;
		btnOrdAdj.Text = "&Order Adjust";
		((Control)PanelSchm).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmRec);
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmOpen);
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmBonus);
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmMothRec);
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmDetail);
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmWithAdd);
		((Control)PanelSchm).Controls.Add((Control)(object)btnSchmSumm);
		((Control)PanelSchm).Location = new Point(-348, 42);
		((Control)PanelSchm).Name = "PanelSchm";
		((Control)PanelSchm).Size = new Size(712, 205);
		((Control)PanelSchm).TabIndex = 1181;
		((Control)PanelSchm).Visible = false;
		((QControl)btnSchmRec).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmRec).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmRec).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmRec).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmRec).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmRec).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmRec).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSchmRec).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmRec).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmRec).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmRec).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmRec).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmRec).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmRec).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmRec.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmRec.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmRec.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmRec.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmRec.Image = null;
		((QControl)btnSchmRec).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmRec).Location = new Point(285, 144);
		((Control)btnSchmRec).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmRec).Name = "btnSchmRec";
		((Control)btnSchmRec).Size = new Size(143, 37);
		((Control)btnSchmRec).TabIndex = 6;
		btnSchmRec.Text = "Schm Daily Rec";
		((QControl)btnSchmOpen).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmOpen).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmOpen).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmOpen).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmOpen).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmOpen).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmOpen).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSchmOpen).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmOpen).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmOpen).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmOpen).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmOpen).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmOpen).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmOpen).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmOpen.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmOpen.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmOpen.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmOpen.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmOpen.Image = null;
		((QControl)btnSchmOpen).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmOpen).Location = new Point(471, 87);
		((Control)btnSchmOpen).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmOpen).Name = "btnSchmOpen";
		((Control)btnSchmOpen).Size = new Size(143, 37);
		((Control)btnSchmOpen).TabIndex = 5;
		btnSchmOpen.Text = "Memb With Emp";
		((QControl)btnSchmBonus).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmBonus).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmBonus).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmBonus).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmBonus).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmBonus).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmBonus).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSchmBonus).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmBonus).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmBonus).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmBonus).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmBonus).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmBonus).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmBonus).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmBonus.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmBonus.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmBonus.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmBonus.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmBonus.Image = null;
		((QControl)btnSchmBonus).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmBonus).Location = new Point(285, 87);
		((Control)btnSchmBonus).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmBonus).Name = "btnSchmBonus";
		((Control)btnSchmBonus).Size = new Size(143, 37);
		((Control)btnSchmBonus).TabIndex = 4;
		btnSchmBonus.Text = "Scheme Bonus";
		((QControl)btnSchmMothRec).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmMothRec).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmMothRec).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmMothRec).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmMothRec.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmMothRec.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmMothRec.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmMothRec.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmMothRec.Image = null;
		((QControl)btnSchmMothRec).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmMothRec).Location = new Point(101, 87);
		((Control)btnSchmMothRec).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmMothRec).Name = "btnSchmMothRec";
		((Control)btnSchmMothRec).Size = new Size(143, 37);
		((Control)btnSchmMothRec).TabIndex = 3;
		btnSchmMothRec.Text = "Monthly Rec";
		((QControl)btnSchmDetail).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmDetail).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmDetail).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmDetail).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmDetail).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmDetail).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmDetail).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSchmDetail).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmDetail).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmDetail).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmDetail).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmDetail).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmDetail).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmDetail).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmDetail.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmDetail.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmDetail.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmDetail.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmDetail.Image = null;
		((QControl)btnSchmDetail).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmDetail).Location = new Point(102, 24);
		((Control)btnSchmDetail).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmDetail).Name = "btnSchmDetail";
		((Control)btnSchmDetail).Size = new Size(143, 37);
		((Control)btnSchmDetail).TabIndex = 0;
		btnSchmDetail.Text = "Detail Report";
		((QControl)btnSchmWithAdd).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmWithAdd).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmWithAdd).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmWithAdd).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmWithAdd.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmWithAdd.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmWithAdd.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmWithAdd.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmWithAdd.Image = null;
		((QControl)btnSchmWithAdd).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmWithAdd).Location = new Point(285, 24);
		((Control)btnSchmWithAdd).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmWithAdd).Name = "btnSchmWithAdd";
		((Control)btnSchmWithAdd).Size = new Size(143, 37);
		((Control)btnSchmWithAdd).TabIndex = 1;
		btnSchmWithAdd.Text = "Detail With Add";
		((QControl)btnSchmSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSchmSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSchmSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSchmSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSchmSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSchmSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSchmSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSchmSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSchmSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSchmSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSchmSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSchmSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSchmSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSchmSumm.Image = null;
		((QControl)btnSchmSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSchmSumm).Location = new Point(471, 24);
		((Control)btnSchmSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSchmSumm).Name = "btnSchmSumm";
		((Control)btnSchmSumm).Size = new Size(143, 37);
		((Control)btnSchmSumm).TabIndex = 2;
		btnSchmSumm.Text = "Summ Report";
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(557, 46);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(475, 46);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrCode).Location = new Point(475, 164);
		((TextBoxBase)tGrCode).MaxLength = 8;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(76, 23);
		((Control)tGrCode).TabIndex = 5;
		((TextBoxBase)tGrName).BackColor = Color.White;
		((Control)tGrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tGrName).Location = new Point(557, 164);
		((TextBoxBase)tGrName).MaxLength = 8;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(282, 23);
		((Control)tGrName).TabIndex = 1184;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(395, 163);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(72, 20);
		((Control)Label7).TabIndex = 1183;
		Label7.Text = "Gr Code";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)PanelInOut).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelInOut).Controls.Add((Control)(object)BtnCntrTrfr);
		((Control)PanelInOut).Controls.Add((Control)(object)BtnInOutSumm);
		((Control)PanelInOut).Controls.Add((Control)(object)BrnItmInWord);
		((Control)PanelInOut).Controls.Add((Control)(object)BtnItmInOut);
		((Control)PanelInOut).Controls.Add((Control)(object)BtnItmOutWord);
		((Control)PanelInOut).Location = new Point(-332, 207);
		((Control)PanelInOut).Name = "PanelInOut";
		((Control)PanelInOut).Size = new Size(712, 138);
		((Control)PanelInOut).TabIndex = 1185;
		((Control)PanelInOut).Visible = false;
		((QControl)BtnCntrTrfr).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnCntrTrfr).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnCntrTrfr).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnCntrTrfr).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnCntrTrfr.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCntrTrfr.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCntrTrfr.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCntrTrfr.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCntrTrfr.Image = null;
		((QControl)BtnCntrTrfr).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnCntrTrfr).Location = new Point(371, 84);
		((Control)BtnCntrTrfr).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnCntrTrfr).Name = "BtnCntrTrfr";
		((Control)BtnCntrTrfr).Size = new Size(143, 37);
		((Control)BtnCntrTrfr).TabIndex = 4;
		BtnCntrTrfr.Text = "Counter Trfr";
		((QControl)BtnInOutSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnInOutSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnInOutSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnInOutSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnInOutSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnInOutSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnInOutSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnInOutSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnInOutSumm.Image = null;
		((QControl)BtnInOutSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnInOutSumm).Location = new Point(184, 84);
		((Control)BtnInOutSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnInOutSumm).Name = "BtnInOutSumm";
		((Control)BtnInOutSumm).Size = new Size(143, 37);
		((Control)BtnInOutSumm).TabIndex = 3;
		BtnInOutSumm.Text = "Item Summ";
		((QControl)BrnItmInWord).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BrnItmInWord).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BrnItmInWord).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BrnItmInWord).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BrnItmInWord).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BrnItmInWord.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BrnItmInWord.Image = null;
		((QControl)BrnItmInWord).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BrnItmInWord).Location = new Point(102, 24);
		((Control)BrnItmInWord).Margin = new Padding(3, 6, 3, 6);
		((Control)BrnItmInWord).Name = "BrnItmInWord";
		((Control)BrnItmInWord).Size = new Size(143, 37);
		((Control)BrnItmInWord).TabIndex = 0;
		BrnItmInWord.Text = "Item In";
		((QControl)BtnItmInOut).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnItmInOut).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmInOut).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnItmInOut).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnItmInOut).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnItmInOut.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmInOut.Image = null;
		((QControl)BtnItmInOut).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnItmInOut).Location = new Point(285, 24);
		((Control)BtnItmInOut).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItmInOut).Name = "BtnItmInOut";
		((Control)BtnItmInOut).Size = new Size(143, 37);
		((Control)BtnItmInOut).TabIndex = 1;
		BtnItmInOut.Text = "Item In Out";
		((QControl)BtnItmOutWord).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItmOutWord).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnItmOutWord).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnItmOutWord).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnItmOutWord.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItmOutWord.Image = null;
		((QControl)BtnItmOutWord).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnItmOutWord).Location = new Point(471, 24);
		((Control)BtnItmOutWord).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItmOutWord).Name = "BtnItmOutWord";
		((Control)BtnItmOutWord).Size = new Size(143, 37);
		((Control)BtnItmOutWord).TabIndex = 2;
		BtnItmOutWord.Text = "Item Out";
		((TextBoxBase)tCustName).BackColor = Color.White;
		((Control)tCustName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCustName).Location = new Point(475, 222);
		((TextBoxBase)tCustName).MaxLength = 50;
		((Control)tCustName).Name = "tCustName";
		((Control)tCustName).Size = new Size(364, 23);
		((Control)tCustName).TabIndex = 7;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(380, 223);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(87, 20);
		((Control)Label8).TabIndex = 1187;
		Label8.Text = "Cust Name";
		Label8.TextAlign = (ContentAlignment)64;
		((Control)PnlKr).BackColor = SystemColors.ButtonHighlight;
		((Control)PnlKr).Controls.Add((Control)(object)btnCustRepIsuPan);
		((Control)PnlKr).Controls.Add((Control)(object)btnKrRepPan);
		((Control)PnlKr).Controls.Add((Control)(object)btnCustRepPan);
		((Control)PnlKr).Controls.Add((Control)(object)btnKrRepIsu);
		((Control)PnlKr).Controls.Add((Control)(object)btnRepRec);
		((Control)PnlKr).Controls.Add((Control)(object)btnRepIsu);
		((Control)PnlKr).Controls.Add((Control)(object)btnKrRepRec);
		((Control)PnlKr).Controls.Add((Control)(object)btnKrIsu);
		((Control)PnlKr).Controls.Add((Control)(object)btnKrRec);
		((Control)PnlKr).Location = new Point(-434, 280);
		((Control)PnlKr).Name = "PnlKr";
		((Control)PnlKr).Size = new Size(712, 219);
		((Control)PnlKr).TabIndex = 1188;
		((Control)PnlKr).Visible = false;
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCustRepIsuPan).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCustRepIsuPan).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCustRepIsuPan).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCustRepIsuPan.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepIsuPan.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepIsuPan.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepIsuPan.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepIsuPan.Image = null;
		((QControl)btnCustRepIsuPan).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCustRepIsuPan).Location = new Point(183, 170);
		((Control)btnCustRepIsuPan).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCustRepIsuPan).Name = "btnCustRepIsuPan";
		((Control)btnCustRepIsuPan).Size = new Size(143, 37);
		((Control)btnCustRepIsuPan).TabIndex = 9;
		btnCustRepIsuPan.Text = "Cust Isu Pan";
		((QControl)btnKrRepPan).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrRepPan).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRepPan).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrRepPan).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrRepPan).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrRepPan).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRepPan).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrRepPan).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrRepPan).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrRepPan).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrRepPan).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrRepPan).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrRepPan).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrRepPan).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrRepPan.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepPan.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepPan.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepPan.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepPan.Image = null;
		((QControl)btnKrRepPan).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrRepPan).Location = new Point(279, 118);
		((Control)btnKrRepPan).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrRepPan).Name = "btnKrRepPan";
		((Control)btnKrRepPan).Size = new Size(143, 37);
		((Control)btnKrRepPan).TabIndex = 8;
		btnKrRepPan.Text = "Kr Rec Panding";
		((QControl)btnCustRepPan).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCustRepPan).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustRepPan).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCustRepPan).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCustRepPan).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCustRepPan).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustRepPan).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCustRepPan).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCustRepPan).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCustRepPan).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCustRepPan).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCustRepPan).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCustRepPan).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCustRepPan).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCustRepPan.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepPan.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepPan.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepPan.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustRepPan.Image = null;
		((QControl)btnCustRepPan).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCustRepPan).Location = new Point(374, 170);
		((Control)btnCustRepPan).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCustRepPan).Name = "btnCustRepPan";
		((Control)btnCustRepPan).Size = new Size(143, 37);
		((Control)btnCustRepPan).TabIndex = 7;
		btnCustRepPan.Text = "Cust Issue";
		((QControl)btnKrRepIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrRepIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrRepIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrRepIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrRepIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepIsu.Image = null;
		((QControl)btnKrRepIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrRepIsu).Location = new Point(99, 118);
		((Control)btnKrRepIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrRepIsu).Name = "btnKrRepIsu";
		((Control)btnKrRepIsu).Size = new Size(143, 37);
		((Control)btnKrRepIsu).TabIndex = 6;
		btnKrRepIsu.Text = "Kr Rep Isu";
		((QControl)btnRepRec).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnRepRec).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRepRec).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnRepRec).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnRepRec).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRepRec).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRepRec).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnRepRec).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnRepRec).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnRepRec).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnRepRec).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRepRec).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnRepRec).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnRepRec).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnRepRec.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepRec.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepRec.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepRec.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepRec.Image = null;
		((QControl)btnRepRec).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnRepRec).Location = new Point(183, 65);
		((Control)btnRepRec).Margin = new Padding(3, 6, 3, 6);
		((Control)btnRepRec).Name = "btnRepRec";
		((Control)btnRepRec).Size = new Size(143, 37);
		((Control)btnRepRec).TabIndex = 5;
		btnRepRec.Text = "Cust Received";
		((QControl)btnRepIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnRepIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRepIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnRepIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnRepIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRepIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRepIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnRepIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnRepIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnRepIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnRepIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRepIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnRepIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnRepIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnRepIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRepIsu.Image = null;
		((QControl)btnRepIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnRepIsu).Location = new Point(374, 65);
		((Control)btnRepIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnRepIsu).Name = "btnRepIsu";
		((Control)btnRepIsu).Size = new Size(143, 37);
		((Control)btnRepIsu).TabIndex = 4;
		btnRepIsu.Text = "Kr Isu Panding";
		((QControl)btnKrRepRec).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrRepRec).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRepRec).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrRepRec).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrRepRec).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrRepRec).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRepRec).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrRepRec).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrRepRec).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrRepRec).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrRepRec).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrRepRec).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrRepRec).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrRepRec).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrRepRec.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepRec.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepRec.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepRec.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRepRec.Image = null;
		((QControl)btnKrRepRec).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrRepRec).Location = new Point(459, 118);
		((Control)btnKrRepRec).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrRepRec).Name = "btnKrRepRec";
		((Control)btnKrRepRec).Size = new Size(143, 37);
		((Control)btnKrRepRec).TabIndex = 3;
		btnKrRepRec.Text = "Kr Rep Rec";
		((QControl)btnKrIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrIsu.Image = null;
		((QControl)btnKrIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrIsu).Location = new Point(183, 16);
		((Control)btnKrIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrIsu).Name = "btnKrIsu";
		((Control)btnKrIsu).Size = new Size(143, 37);
		((Control)btnKrIsu).TabIndex = 0;
		btnKrIsu.Text = "&Kr Isu Report";
		((QControl)btnKrRec).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrRec).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRec).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrRec).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrRec).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrRec).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrRec).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrRec).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrRec).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrRec).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrRec).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrRec).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrRec).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrRec).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrRec.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRec.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRec.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRec.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrRec.Image = null;
		((QControl)btnKrRec).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrRec).Location = new Point(374, 16);
		((Control)btnKrRec).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrRec).Name = "btnKrRec";
		((Control)btnKrRec).Size = new Size(143, 37);
		((Control)btnKrRec).TabIndex = 2;
		btnKrRec.Text = "&Kr Rec Report";
		((Control)pnlVp).BackColor = SystemColors.ButtonHighlight;
		((Control)pnlVp).Controls.Add((Control)(object)btnVpPan);
		((Control)pnlVp).Controls.Add((Control)(object)btnAngIsu);
		((Control)pnlVp).Controls.Add((Control)(object)btnAngPan);
		((Control)pnlVp).Controls.Add((Control)(object)btnAngAdj);
		((Control)pnlVp).Controls.Add((Control)(object)btnVpIsu);
		((Control)pnlVp).Controls.Add((Control)(object)btnVpAdj);
		((Control)pnlVp).Location = new Point(865, 163);
		((Control)pnlVp).Name = "pnlVp";
		((Control)pnlVp).Size = new Size(715, 134);
		((Control)pnlVp).TabIndex = 1189;
		((Control)pnlVp).Visible = false;
		((QControl)btnVpPan).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnVpPan).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnVpPan).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnVpPan).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnVpPan).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnVpPan).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnVpPan).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnVpPan).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnVpPan).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnVpPan).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnVpPan).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnVpPan).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnVpPan).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnVpPan).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnVpPan.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpPan.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpPan.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpPan.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpPan.Image = null;
		((QControl)btnVpPan).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnVpPan).Location = new Point(471, 24);
		((Control)btnVpPan).Margin = new Padding(3, 6, 3, 6);
		((Control)btnVpPan).Name = "btnVpPan";
		((Control)btnVpPan).Size = new Size(143, 37);
		((Control)btnVpPan).TabIndex = 7;
		btnVpPan.Text = "&Vp Panding";
		((QControl)btnAngIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAngIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAngIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAngIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAngIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAngIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAngIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAngIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAngIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAngIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAngIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAngIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAngIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAngIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAngIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngIsu.Image = null;
		((QControl)btnAngIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAngIsu).Location = new Point(102, 84);
		((Control)btnAngIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAngIsu).Name = "btnAngIsu";
		((Control)btnAngIsu).Size = new Size(143, 37);
		((Control)btnAngIsu).TabIndex = 5;
		btnAngIsu.Text = "Angdiya Issue";
		((QControl)btnAngPan).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAngPan).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAngPan).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAngPan).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAngPan).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAngPan).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAngPan).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAngPan).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAngPan).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAngPan).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAngPan).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAngPan).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAngPan).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAngPan).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAngPan.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngPan.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngPan.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngPan.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngPan.Image = null;
		((QControl)btnAngPan).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAngPan).Location = new Point(471, 84);
		((Control)btnAngPan).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAngPan).Name = "btnAngPan";
		((Control)btnAngPan).Size = new Size(143, 37);
		((Control)btnAngPan).TabIndex = 4;
		btnAngPan.Text = "Angdiya Panding";
		((QControl)btnAngAdj).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAngAdj).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAngAdj).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAngAdj).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAngAdj).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAngAdj).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAngAdj).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAngAdj).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAngAdj).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAngAdj).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAngAdj).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAngAdj).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAngAdj).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAngAdj).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAngAdj.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngAdj.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngAdj.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngAdj.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAngAdj.Image = null;
		((QControl)btnAngAdj).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAngAdj).Location = new Point(285, 84);
		((Control)btnAngAdj).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAngAdj).Name = "btnAngAdj";
		((Control)btnAngAdj).Size = new Size(143, 37);
		((Control)btnAngAdj).TabIndex = 3;
		btnAngAdj.Text = "Angdiya Adjust";
		((QControl)btnVpIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnVpIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnVpIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnVpIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnVpIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnVpIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnVpIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnVpIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnVpIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnVpIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnVpIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnVpIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnVpIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnVpIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnVpIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpIsu.Image = null;
		((QControl)btnVpIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnVpIsu).Location = new Point(102, 24);
		((Control)btnVpIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnVpIsu).Name = "btnVpIsu";
		((Control)btnVpIsu).Size = new Size(143, 37);
		((Control)btnVpIsu).TabIndex = 0;
		btnVpIsu.Text = "&Vp Issue";
		((QControl)btnVpAdj).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnVpAdj).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnVpAdj).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnVpAdj).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnVpAdj).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnVpAdj).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnVpAdj).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnVpAdj).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnVpAdj).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnVpAdj).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnVpAdj).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnVpAdj).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnVpAdj).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnVpAdj).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnVpAdj.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpAdj.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpAdj.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpAdj.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnVpAdj.Image = null;
		((QControl)btnVpAdj).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnVpAdj).Location = new Point(285, 24);
		((Control)btnVpAdj).Margin = new Padding(3, 6, 3, 6);
		((Control)btnVpAdj).Name = "btnVpAdj";
		((Control)btnVpAdj).Size = new Size(143, 37);
		((Control)btnVpAdj).TabIndex = 2;
		btnVpAdj.Text = "&Vp Adjust";
		((Control)PanelBul).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelBul).Controls.Add((Control)(object)btnBusSlPanding);
		((Control)PanelBul).Controls.Add((Control)(object)btnPrBook);
		((Control)PanelBul).Controls.Add((Control)(object)brnBulPrPanding);
		((Control)PanelBul).Controls.Add((Control)(object)brnBulPrAdj);
		((Control)PanelBul).Controls.Add((Control)(object)btnSlBook);
		((Control)PanelBul).Controls.Add((Control)(object)brnBulSlAdj);
		((Control)PanelBul).Location = new Point(966, 470);
		((Control)PanelBul).Name = "PanelBul";
		((Control)PanelBul).Size = new Size(712, 156);
		((Control)PanelBul).TabIndex = 1190;
		((Control)PanelBul).Visible = false;
		((QControl)btnBusSlPanding).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBusSlPanding).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBusSlPanding).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBusSlPanding).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBusSlPanding.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBusSlPanding.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBusSlPanding.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBusSlPanding.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBusSlPanding.Image = null;
		((QControl)btnBusSlPanding).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBusSlPanding).Location = new Point(471, 24);
		((Control)btnBusSlPanding).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBusSlPanding).Name = "btnBusSlPanding";
		((Control)btnBusSlPanding).Size = new Size(143, 37);
		((Control)btnBusSlPanding).TabIndex = 7;
		btnBusSlPanding.Text = "&Sl Panding";
		((QControl)btnPrBook).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPrBook).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrBook).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPrBook).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPrBook).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPrBook).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrBook).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPrBook).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPrBook).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPrBook).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPrBook).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPrBook).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPrBook).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPrBook).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPrBook.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrBook.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrBook.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrBook.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrBook.Image = null;
		((QControl)btnPrBook).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPrBook).Location = new Point(102, 84);
		((Control)btnPrBook).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPrBook).Name = "btnPrBook";
		((Control)btnPrBook).Size = new Size(143, 37);
		((Control)btnPrBook).TabIndex = 5;
		btnPrBook.Text = "Bul Purc Book";
		((QControl)brnBulPrPanding).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnBulPrPanding).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)brnBulPrPanding).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)brnBulPrPanding).ColorScheme).InheritCurrentThemeFromGlobal = false;
		brnBulPrPanding.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrPanding.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrPanding.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrPanding.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrPanding.Image = null;
		((QControl)brnBulPrPanding).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)brnBulPrPanding).Location = new Point(471, 84);
		((Control)brnBulPrPanding).Margin = new Padding(3, 6, 3, 6);
		((Control)brnBulPrPanding).Name = "brnBulPrPanding";
		((Control)brnBulPrPanding).Size = new Size(143, 37);
		((Control)brnBulPrPanding).TabIndex = 4;
		brnBulPrPanding.Text = "Pr Panding";
		((QControl)brnBulPrAdj).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnBulPrAdj).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)brnBulPrAdj).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)brnBulPrAdj).ColorScheme).InheritCurrentThemeFromGlobal = false;
		brnBulPrAdj.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrAdj.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrAdj.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrAdj.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulPrAdj.Image = null;
		((QControl)brnBulPrAdj).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)brnBulPrAdj).Location = new Point(285, 84);
		((Control)brnBulPrAdj).Margin = new Padding(3, 6, 3, 6);
		((Control)brnBulPrAdj).Name = "brnBulPrAdj";
		((Control)brnBulPrAdj).Size = new Size(143, 37);
		((Control)brnBulPrAdj).TabIndex = 3;
		brnBulPrAdj.Text = "Bul Pr Adjust";
		((QControl)btnSlBook).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlBook).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlBook).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlBook).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlBook).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlBook).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlBook).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlBook).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlBook).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlBook).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlBook).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlBook).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlBook).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlBook).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlBook.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlBook.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlBook.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlBook.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlBook.Image = null;
		((QControl)btnSlBook).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlBook).Location = new Point(104, 24);
		((Control)btnSlBook).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlBook).Name = "btnSlBook";
		((Control)btnSlBook).Size = new Size(143, 37);
		((Control)btnSlBook).TabIndex = 0;
		btnSlBook.Text = "&Bul Sale Book";
		((QControl)brnBulSlAdj).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnBulSlAdj).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)brnBulSlAdj).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)brnBulSlAdj).ColorScheme).InheritCurrentThemeFromGlobal = false;
		brnBulSlAdj.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulSlAdj.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulSlAdj.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulSlAdj.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnBulSlAdj.Image = null;
		((QControl)brnBulSlAdj).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)brnBulSlAdj).Location = new Point(285, 24);
		((Control)brnBulSlAdj).Margin = new Padding(3, 6, 3, 6);
		((Control)brnBulSlAdj).Name = "brnBulSlAdj";
		((Control)brnBulSlAdj).Size = new Size(143, 37);
		((Control)brnBulSlAdj).TabIndex = 2;
		brnBulSlAdj.Text = "Bul Sl Adjust";
		cboEmploy.AutoCompleteMode = (AutoCompleteMode)3;
		cboEmploy.AutoCompleteSource = (AutoCompleteSource)256;
		cboEmploy.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboEmploy).Font = new Font("Tahoma", 9f);
		((ListControl)cboEmploy).FormattingEnabled = true;
		((Control)cboEmploy).Location = new Point(692, 281);
		((Control)cboEmploy).Name = "cboEmploy";
		((Control)cboEmploy).Size = new Size(148, 22);
		((Control)cboEmploy).TabIndex = 1191;
		((Control)cboEmploy).Visible = false;
		((Control)lblemp).BackColor = Color.Transparent;
		((Control)lblemp).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblemp).ForeColor = Color.Black;
		lblemp.ImeMode = (ImeMode)0;
		((Control)lblemp).Location = new Point(626, 282);
		((Control)lblemp).Name = "lblemp";
		((Control)lblemp).Size = new Size(57, 19);
		((Control)lblemp).TabIndex = 1192;
		lblemp.Text = "Employ";
		lblemp.TextAlign = (ContentAlignment)64;
		((Control)lblemp).Visible = false;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(384, 77);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1207;
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
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val3;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val5;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((ButtonBase)chkBookSelect).BackColor = Color.Transparent;
		((Control)chkBookSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBookSelect).ForeColor = Color.Black;
		((Control)chkBookSelect).Location = new Point(859, 109);
		((Control)chkBookSelect).Name = "chkBookSelect";
		((Control)chkBookSelect).RightToLeft = (RightToLeft)0;
		((Control)chkBookSelect).Size = new Size(141, 19);
		((Control)chkBookSelect).TabIndex = 1208;
		((ButtonBase)chkBookSelect).Text = "Select Book";
		((ButtonBase)chkBookSelect).UseVisualStyleBackColor = false;
		((Control)chkBookSelect).Visible = false;
		cboState.AutoCompleteMode = (AutoCompleteMode)3;
		cboState.AutoCompleteSource = (AutoCompleteSource)256;
		cboState.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboState).Font = new Font("Tahoma", 9f);
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Location = new Point(692, 46);
		((Control)cboState).Name = "cboState";
		((Control)cboState).Size = new Size(148, 22);
		((Control)cboState).TabIndex = 1209;
		((Control)cboState).Visible = false;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(627, 47);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(58, 19);
		((Control)Label9).TabIndex = 1210;
		Label9.Text = "State";
		Label9.TextAlign = (ContentAlignment)64;
		((Control)Label9).Visible = false;
		((QControl)btnParyPurcSumm).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnParyPurcSumm).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnParyPurcSumm).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnParyPurcSumm).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnParyPurcSumm.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParyPurcSumm.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParyPurcSumm.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParyPurcSumm.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnParyPurcSumm.Image = null;
		((QControl)btnParyPurcSumm).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnParyPurcSumm).Location = new Point(285, 75);
		((Control)btnParyPurcSumm).Margin = new Padding(3, 6, 3, 6);
		((Control)btnParyPurcSumm).Name = "btnParyPurcSumm";
		((Control)btnParyPurcSumm).Size = new Size(143, 37);
		((Control)btnParyPurcSumm).TabIndex = 13;
		btnParyPurcSumm.Text = "&Party Summ";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PanelInOut);
		((Control)this).Controls.Add((Control)(object)PanelSchm);
		((Control)this).Controls.Add((Control)(object)PnlIt);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)cboState);
		((Control)this).Controls.Add((Control)(object)PanelPurc);
		((Control)this).Controls.Add((Control)(object)PanelApr);
		((Control)this).Controls.Add((Control)(object)PanelBul);
		((Control)this).Controls.Add((Control)(object)pnlVp);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)chkBookSelect);
		((Control)this).Controls.Add((Control)(object)PanelOrder);
		((Control)this).Controls.Add((Control)(object)PnlKr);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tCustName);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)PanelSale);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)tItName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)cboCity);
		((Control)this).Controls.Add((Control)(object)lblCity);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)cboEmploy);
		((Control)this).Controls.Add((Control)(object)lblemp);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_ALL";
		((Form)this).Text = "Report All";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)PanelSale).ResumeLayout(false);
		((Control)PanelPurc).ResumeLayout(false);
		((Control)PanelApr).ResumeLayout(false);
		((Control)PanelOrder).ResumeLayout(false);
		((Control)PanelSchm).ResumeLayout(false);
		((Control)PanelInOut).ResumeLayout(false);
		((Control)PnlKr).ResumeLayout(false);
		((Control)pnlVp).ResumeLayout(false);
		((Control)PanelBul).ResumeLayout(false);
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_ALL_Load(object sender, EventArgs e)
	{
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Expected O, but got Unknown
		//IL_22c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cb: Expected O, but got Unknown
		//IL_2346: Unknown result type (might be due to invalid IL or missing references)
		//IL_234b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2355: Expected O, but got Unknown
		//IL_2405: Unknown result type (might be due to invalid IL or missing references)
		//IL_240a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2410: Expected O, but got Unknown
		//IL_2498: Unknown result type (might be due to invalid IL or missing references)
		//IL_249d: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a7: Expected O, but got Unknown
		//IL_2519: Unknown result type (might be due to invalid IL or missing references)
		//IL_251e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2524: Expected O, but got Unknown
		//IL_25d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25db: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e5: Expected O, but got Unknown
		//IL_2604: Unknown result type (might be due to invalid IL or missing references)
		//IL_2609: Unknown result type (might be due to invalid IL or missing references)
		//IL_2613: Expected O, but got Unknown
		//IL_2632: Unknown result type (might be due to invalid IL or missing references)
		//IL_2637: Unknown result type (might be due to invalid IL or missing references)
		//IL_2641: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
		if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
		{
			tLcCode.Text = DC_Main.MLc_code;
			tLcName.Text = DC_Main.MLc_Name;
			((Control)tLcCode).Enabled = false;
			((Control)tLcName).Enabled = false;
		}
		else
		{
			tLcCode.Text = DC_Main.MLc_code;
			tLcName.Text = DC_Main.MLc_Name;
		}
		((Control)PnlIt).Left = ((Control)tGrCode).Left;
		((Control)PnlIt).Top = ((Control)tGrCode).Top;
		checked
		{
			if (Operators.CompareString(CurRpt, "Sales Report", false) == 0)
			{
				((Control)PanelSale).Visible = true;
				((Control)lblemp).Visible = true;
				((Control)cboEmploy).Visible = true;
				((Control)chkBookSelect).Visible = true;
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					((Control)btnItmSl).Visible = true;
					((Control)btnb2bSl).Visible = true;
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					((Control)btnItmSl).Visible = true;
					((Control)btnb2bSl).Visible = true;
					btnItmSl.Text = "Memb Comm";
					btnb2bSl.Text = "ShrHold Com";
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM019NEDM", false) == 0)
				{
					((Control)Label9).Visible = true;
					((Control)cboState).Visible = true;
				}
				BookMast();
			}
			else if (Operators.CompareString(CurRpt, "Purchase Rpt", false) == 0)
			{
				((Control)PanelPurc).Visible = true;
				((Control)PanelPurc).Top = ((Control)PanelSale).Top;
				((Control)PanelPurc).Left = ((Control)PanelSale).Left;
			}
			else if (Operators.CompareString(CurRpt, "Approval Rpt", false) == 0)
			{
				((Control)PanelApr).Visible = true;
				((Control)PanelApr).Top = ((Control)PanelSale).Top;
				((Control)PanelApr).Left = ((Control)PanelSale).Left;
			}
			else if (Operators.CompareString(CurRpt, "Order Report", false) == 0)
			{
				((Control)PanelOrder).Visible = true;
				((Control)PanelOrder).Top = ((Control)PanelSale).Top;
				((Control)PanelOrder).Left = ((Control)PanelSale).Left;
			}
			else if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				Label4.Text = "Schm Code";
				Label3.Text = "Memb Code";
				((Control)PanelSchm).Visible = true;
				((Control)PanelSchm).Top = ((Control)cboItemTyp).Top + 25;
				((Control)PanelSchm).Left = ((Control)PanelSale).Left;
				Label5.Text = "With Bonus";
				((Control)lblemp).Visible = true;
				((Control)cboEmploy).Visible = true;
			}
			else if (Operators.CompareString(CurRpt, "Item InOut", false) == 0)
			{
				((Control)PanelInOut).Visible = true;
				((Control)PanelInOut).Top = ((Control)PanelSale).Top;
				((Control)PanelInOut).Left = ((Control)PanelSale).Left;
				BookMast();
				((Control)chkBookSelect).Visible = true;
			}
			else if (Operators.CompareString(CurRpt, "Kr Report", false) == 0)
			{
				((Control)PnlKr).Visible = true;
				((Control)PnlKr).Top = ((Control)PanelSale).Top;
				((Control)PnlKr).Left = ((Control)PanelSale).Left;
				((Control)btnRepRec).Visible = false;
				((Control)btnRepIsu).Visible = false;
				((Control)btnCustRepPan).Visible = false;
				((Control)btnKrRepIsu).Visible = false;
				((Control)btnKrRepRec).Visible = false;
				((Control)btnKrRepPan).Visible = false;
				((Control)btnCustRepIsuPan).Visible = false;
			}
			else if (Operators.CompareString(CurRpt, "Reparing Rpt", false) == 0)
			{
				((Control)PnlKr).Visible = true;
				((Control)PnlKr).Top = ((Control)PanelSale).Top;
				((Control)PnlKr).Left = ((Control)PanelSale).Left;
				((Control)btnKrIsu).Visible = false;
				((Control)btnKrRec).Visible = false;
			}
			else if (Operators.CompareString(CurRpt, "Vp Report", false) == 0)
			{
				((Control)pnlVp).Visible = true;
				((Control)pnlVp).Top = ((Control)PanelSale).Top;
				((Control)pnlVp).Left = ((Control)PanelSale).Left;
				Label7.Text = "Angdiya Ac";
			}
			else if (Operators.CompareString(CurRpt, "Bul Report", false) == 0)
			{
				((Control)PanelBul).Visible = true;
				((Control)PanelBul).Top = ((Control)PanelSale).Top;
				((Control)PanelBul).Left = ((Control)PanelSale).Left;
			}
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
			foreach (object control3 in ((Control)PanelSale).Controls)
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
			foreach (object control4 in ((Control)PanelPurc).Controls)
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
			foreach (object control5 in ((Control)PanelApr).Controls)
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
			foreach (object control6 in ((Control)PanelOrder).Controls)
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(control6);
				object obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control7 in ((Control)PnlIt).Controls)
			{
				object objectValue6 = RuntimeHelpers.GetObjectValue(control7);
				object obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control8 in ((Control)PanelBul).Controls)
			{
				object objectValue7 = RuntimeHelpers.GetObjectValue(control8);
				object obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control9 in ((Control)PanelSchm).Controls)
			{
				object objectValue8 = RuntimeHelpers.GetObjectValue(control9);
				object obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control10 in ((Control)PanelInOut).Controls)
			{
				object objectValue9 = RuntimeHelpers.GetObjectValue(control10);
				object obj = objectValue9;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue9, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue9;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue9, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue9;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue9, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue9;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue9, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control11 in ((Control)PnlKr).Controls)
			{
				object objectValue10 = RuntimeHelpers.GetObjectValue(control11);
				object obj = objectValue10;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue10, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue10;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue10, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue10;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue10, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue10;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue10, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control12 in ((Control)pnlVp).Controls)
			{
				object objectValue11 = RuntimeHelpers.GetObjectValue(control12);
				object obj = objectValue11;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue11, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue11;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue11, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue11;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue11, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue11;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue11, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
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
				((Control)PanelSale).BackColor = Color.Silver;
				((Control)PanelPurc).BackColor = Color.Silver;
				((Control)PanelApr).BackColor = Color.Silver;
				((Control)PanelOrder).BackColor = Color.Silver;
				((Control)PanelInOut).BackColor = Color.Silver;
				((Control)PnlKr).BackColor = Color.Silver;
				((Control)pnlVp).BackColor = Color.Silver;
				((Control)PanelBul).BackColor = Color.Silver;
				((Control)PanelSchm).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelSale = PanelSale;
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelSale).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				Panel panelPurc = PanelPurc;
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelPurc).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				Panel panelApr = PanelApr;
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelApr).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				Panel panelOrder = PanelOrder;
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelOrder).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				Panel panelInOut = PanelInOut;
				object? obj12 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelInOut).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				Panel pnlKr = PnlKr;
				object? obj13 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)pnlKr).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				Panel obj14 = pnlVp;
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				Panel panelBul = PanelBul;
				object? obj16 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelBul).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				Panel panelSchm = PanelSchm;
				object? obj17 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelSchm).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj18 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj19 = lblBook;
				object? obj20 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj19).ForeColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj21 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				Panel panelSale2 = PanelSale;
				object? obj22 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelSale2).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				Panel panelPurc2 = PanelPurc;
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelPurc2).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				Panel panelApr2 = PanelApr;
				object? obj24 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelApr2).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				Panel panelOrder2 = PanelOrder;
				object? obj25 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelOrder2).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				Panel panelInOut2 = PanelInOut;
				object? obj26 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelInOut2).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				Panel pnlKr2 = PnlKr;
				object? obj27 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)pnlKr2).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				Panel obj28 = pnlVp;
				object? obj29 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)obj28).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				Panel panelBul2 = PanelBul;
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelBul2).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				Panel panelSchm2 = PanelSchm;
				object? obj31 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelSchm2).BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
				try
				{
					foreach (Control control13 in ((Control)this).Controls)
					{
						Control val3 = control13;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is SearchControl || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tGrCode).Font;
				try
				{
					foreach (object control14 in ((Control)PnlIt).Controls)
					{
						object objectValue12 = RuntimeHelpers.GetObjectValue(control14);
						NewLateBinding.LateSet(objectValue12, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control15 in ((Control)PnlBotam).Controls)
					{
						object objectValue13 = RuntimeHelpers.GetObjectValue(control15);
						NewLateBinding.LateSet(objectValue13, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_ITM).Font.Style);
					((DataGridView)DGV_ITM).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_ITM).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_ITM).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_ITM).RowTemplate.Height * (1.0 + num2));
				}
			}
			DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_CITY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCity.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_STATE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_STATE ORDER BY AC_STATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboState.Items.Clear();
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
				{
					cboState.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_STATE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboState.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				int num6 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num6)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT EMP_CODE,EMP_NAME FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY EMP_CODE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboEmploy.Items.Clear();
				cboEmploy.Items.Add((object)"");
				int num7 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num7)
				{
					cboEmploy.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["EMP_CODE"], (object)""), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.X]["EMP_NAME"]), (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboEmploy.Items.Add((object)"");
			}
			cboEmploy.SelectedIndex = 0;
			if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				cboItemTyp.Items.Add((object)"No");
				cboItemTyp.Items.Add((object)"Yes");
				cboItemTyp.SelectedIndex = 0;
			}
			else
			{
				cboItemTyp.Items.Add((object)"");
				cboItemTyp.Items.Add((object)"Gold");
				cboItemTyp.Items.Add((object)"Silver");
				cboItemTyp.Items.Add((object)"Diamond");
				cboItemTyp.Items.Add((object)"Real Stone");
				cboItemTyp.Items.Add((object)"Emitation");
				cboItemTyp.Items.Add((object)"Other");
				cboItemTyp.Items.Add((object)"Platinum");
				cboItemTyp.SelectedIndex = 0;
			}
			if (Operators.CompareString(CurRpt, "Order Report", false) == 0)
			{
				mFromDt.Text = "01/01/2010";
			}
			else if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				mFromDt.Text = "01/01/2010";
			}
			else if (Operators.CompareString(CurRpt, "Approval Rpt", false) == 0)
			{
				mFromDt.Text = "01/01/2010";
			}
			else if (Operators.CompareString(CurRpt, "Item InOut", false) == 0)
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			else if (Operators.CompareString(CurRpt, "Vp Report", false) == 0)
			{
				mFromDt.Text = "01/01/2020";
			}
			else if (Operators.CompareString(CurRpt, "Sales Report", false) == 0)
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			else
			{
				mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			}
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
		SchmType = "";
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_ALL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_ALL_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_ALL_KeyDown(object sender, KeyEventArgs e)
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
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_ALL_Closed(object sender, EventArgs e)
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
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_CODE,A.MEMB_NAME,A.SCHM_CODE FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"", (object)("AND A.SCHM_CODE = '" + tItCode.Text + "'"))), (object)" AND A.MEMB_CODE = '"), (object)tAcCode.Text), (object)"'"));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_CODE as MembNoL,A.MEMB_NAME As MembNameL,A.AC_MOBILE AS MobileL,A.SCHM_CODE AS SchemeL ,A.MEMB_AMT AS SchmAmtR,FORMAT(SUM(IIF(SIGN = '+',B.ADJ_AMT,- B.ADJ_AMT)),'0.00') AS MembBalR  FROM AD_MEMB AS A LEFT JOIN AD_OS AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"", (object)("AND A.SCHM_CODE = '" + tItCode.Text + "'"))), (object)"  GROUP BY A.MEMB_CODE,A.MEMB_NAME,A.SCHM_CODE,A.MEMB_AMT,A.AC_MOBILE ORDER BY A.SCHM_CODE,A.MEMB_CODE"));
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
							tAcCode.Text = DC_Main.ColValue[0];
							tAcName.Text = DC_Main.ColValue[1];
						}
						((Control)tAcCode).Focus();
					}
				}
				else
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)""));
					SendKeys.Send("{tab}");
				}
				return;
			}
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
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				DC_Main.RsQry = "Select * From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tItCode.Text + "'";
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
							tItCode.Text = DC_Main.ColValue[0];
							tItName.Text = DC_Main.ColValue[1];
							SchmType = DC_Main.ColValue[3];
						}
						((Control)tItCode).Focus();
					}
				}
				else
				{
					tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_NAME"], (object)""));
					SchmType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_TYPE"], (object)""));
					SendKeys.Send("{tab}");
				}
				return;
			}
			DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + tItCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.PR_NAME As ProdNameL,A.PR_CODE As CodeL FROM PRODUCT_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.PR_CODE";
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
						tItCode.Text = DC_Main.ColValue[1];
						tItName.Text = DC_Main.ColValue[0];
					}
					((Control)tItCode).Focus();
				}
			}
			else
			{
				tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			((Control)cboCity).Focus();
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

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnSlRpt_Click(object sender, EventArgs e)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		if ((int)Interaction.MsgBox((object)"Sales Return (Creditnote) Report", (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SaleRtnReport.RPT";
				Cr[(short)0] = "RptTitel = 'Sales Return Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "SaleRtnReport";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Sales Return Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.RTN_NET_AMT} <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SaleReport.RPT";
				Cr[(short)0] = "RptTitel = 'Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "SaleReport";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND ({SL_DATA.NET_AMT}+{SL_DATA.TOT_TAX_FREE_AMT}) <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.NET_AMT} <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			return;
		}
		Cr.SelectionFormula = CurFormula;
		Cr.Destination = (DestinationConstants)0;
		CurFormula = "";
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
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
			}
			else
			{
				tLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnSalesReg_Click(object sender, EventArgs e)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		if ((int)Interaction.MsgBox((object)"Sales Return (Creditnote) Report", (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesRtnSumm.RPT";
				Cr[(short)0] = "RptTitel = 'Sales Return Register Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "SalesRtnSumm";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Sales Return Register Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.RTN_NET_AMT} <> 0  AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesSumm.RPT";
				Cr[(short)0] = "RptTitel = 'Sales Register Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "SalesSumm";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Sales Register Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND ({SL_DATA.NET_AMT}+{SL_DATA.TOT_TAX_FREE_AMT}) <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.NET_AMT} <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			return;
		}
		Cr.SelectionFormula = CurFormula;
		Cr.Destination = (DestinationConstants)0;
		CurFormula = "";
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnSalesItem_Click(object sender, EventArgs e)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		if ((int)Interaction.MsgBox((object)"Sales Return (Creditnote) Report", (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesRtnItem.RPT";
				Cr[(short)0] = "RptTitel = 'Item Wise Sales Return Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "SalesRtnItem";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Item Wise Sales Return Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.RTN_NET_AMT} <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesItem.RPT";
				Cr[(short)0] = "RptTitel = 'Item Wise Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "SalesItem";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Item Wise Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND ({SL_DATA.NET_AMT}+{SL_DATA.TOT_TAX_FREE_AMT}) <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.NET_AMT} <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			}
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			return;
		}
		Cr.SelectionFormula = CurFormula;
		Cr.Destination = (DestinationConstants)0;
		CurFormula = "";
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void tItCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnPurcRpt_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcReport.RPT";
		}
		CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "PurcReport";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnPurcReg_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcSumm.RPT";
		}
		CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Purchase Register From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "PurcSumm";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Purchase Register From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnPurcItem_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcItem.RPT";
		}
		CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Item Wise Purchase Register From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "PurcItem";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Item Wise Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnAprRpt_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprPartyWise.RPT";
		}
		CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AprPartyWise";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnAprInOut_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprInOut.RPT";
		}
		CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Approval In Out Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AprInOut";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Approval In Out Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnAprPanding_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprPan.RPT";
		}
		CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.ISU_REC} = 'N' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {APR_DETL.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Panding Approval Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AprPan";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Panding Approval Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnOrdRpt_Click(object sender, EventArgs e)
	{
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdDetlRpt.RPT";
		}
		CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(tCustName.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Order Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "OrdDetlRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Order Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnOrdAdvance_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdAdvRpt.RPT";
		}
		CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(tCustName.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Order Advance Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "OrdAdvRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Order Advance Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnOrdAdj_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdAdvAdj.RPT";
		}
		CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(tCustName.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Order Adjust Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "OrdAdvAdj";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Order Adjust Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSchmDetail_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			if (Operators.CompareString(SchmType, "G", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembGoldRpt.RPT";
			}
			else if (Operators.CompareString(SchmType, "S", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembGoldRpt.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembRpt.RPT";
			}
		}
		CurFormula = "{AD_OS.CO_CODE} = '" + DC_Main.MCo_code + "'  AND {AD_OS.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_OS.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "No", false) == 0)
		{
			CurFormula += " And {AD_OS.OS_TYPE} <> 'B'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			if (Operators.CompareString(SchmType, "G", false) == 0)
			{
				DC_Main.RptName = "MembGoldRpt";
			}
			else
			{
				DC_Main.RptName = "MembRpt";
			}
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSchmWithAdd_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			if (Operators.CompareString(SchmType, "G", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembGoldRpt.RPT";
			}
			else if (Operators.CompareString(SchmType, "S", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembGoldRpt.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembRpt.RPT";
			}
		}
		CurFormula = "{AD_OS.CO_CODE} = '" + DC_Main.MCo_code + "'  AND {AD_OS.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_OS.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "No", false) == 0)
		{
			CurFormula += " And {AD_OS.OS_TYPE} <> 'B'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			if (Operators.CompareString(SchmType, "G", false) == 0)
			{
				DC_Main.RptName = "MembGoldRpt";
			}
			else
			{
				DC_Main.RptName = "MembRpt";
			}
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSchmSumm_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			if (Operators.CompareString(SchmType, "G", false) != 0 && Operators.CompareString(SchmType, "S", false) != 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembSumm.RPT";
			}
		}
		CurFormula = "{AD_OS.CO_CODE} = '" + DC_Main.MCo_code + "'  AND {AD_OS.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_OS.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Summ Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			if (Operators.CompareString(SchmType, "G", false) == 0)
			{
				DC_Main.RptName = "MembSumm";
			}
			else
			{
				DC_Main.RptName = "MembSumm";
			}
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Summ Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSchmMothRec_Click(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Scheme Code and Try", (MsgBoxStyle)0, (object)null);
			((Control)tItCode).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SchmMonthRpt.RPT";
		}
		CurFormula = "{AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "SchmMonthRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSchmBonus_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembSumm.RPT";
		}
		CurFormula = "{AD_OS.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_OS.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_OS.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_OS.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Summ Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "MembSumm";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Scheme Summ Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnWhSales_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesIsuRec.RPT";
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE  FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE  FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		CurFormula = "{RATE_CUT_ISU_REC.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_ISU_REC.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Wh Sales IsuRec Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "WhSalesIsuRec";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Wh Sales IsuRec Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnSalesBill_Click(object sender, EventArgs e)
	{
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		string text = "";
		DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PRINT_TYPE = 'SALES' AND BOOK_TYPE = 'T'  ORDER BY PRINT_FILE";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '01'  AND PRINT_TYPE = 'SALES' AND BOOK_TYPE = 'T'  ORDER BY PRINT_FILE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num2 = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num2)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						}
						DC_Main.X++;
					}
				}
			}
			if (unchecked((int)Interaction.MsgBox((object)"Sales Return (Creditnote) Report", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
			{
				DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE) Select A.CO_CODE,A.LC_CODE,CO_YEAR,A.CO_BOOK,VCH_NO,A.OLD_SRNO,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE  FROM SL_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = 'SALES RETURNE' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE) Select A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,A.SR_NO,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,0,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE  FROM SL_DETL_RTN AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = 'SALES RETURNE' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesRtnA4Print.RPT";
				}
				else
				{
					DC_Main.RptName = "SalesRtnA4Print";
				}
			}
			else if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";
			}
			else
			{
				DC_Main.RptName = text;
			}
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboState.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
			}
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.MsPrintType = "InVoiceType";
				DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
			}
			else
			{
				Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void btnEmpRpt_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\EmpSaleReport.RPT";
		}
		CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Salesman Wise Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "EmpSaleReport";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Salesman Wise Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Vp Report", false) == 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tGrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.AC_NAME";
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
						tGrCode.Text = DC_Main.ColValue[1];
						tGrName.Text = DC_Main.ColValue[0];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			if (Operators.CompareString(CurRpt, "Scheme Report", false) == 0)
			{
				return;
			}
			DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
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
						tGrName.Text = DC_Main.ColValue[0];
					}
					((TextBoxBase)tGrCode).SelectAll();
				}
			}
			else
			{
				tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
	}

	private void BrnItmInWord_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItemInword.RPT";
		}
		CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.ITM_SIGN} = '+' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Item Inword Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "ItemInword";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Item Inword Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnItmInOut_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItemInword.RPT";
		}
		CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Day Wise Item InOut Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "ItemInword";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Day Wise Item InOut Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnItmOutWord_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItemInword.RPT";
		}
		CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.ITM_SIGN} = '-' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Item OutWord Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "ItemInword";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Item OutWord Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void BtnInOutSumm_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ItemInOutSumm.RPT";
		}
		CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Item InOut Summ Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "ItemInOutSumm";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Item InOut Summ Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectAll();
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectAll();
	}

	private void btnPurcBill_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBillA4Gst.RPT";
		}
		CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.MsPrintType = "InVoiceType";
			DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
			DC_Main.RptName = "PurcBillA4Gst";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void tCustName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tCustName.Text, "", false) != 0)
		{
			if (Operators.CompareString(CurRpt, "Order Report", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME FROM SL_ORD_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_NAME = '" + tCustName.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As CustomerNameL,A.AC_CODE AS AcCodel FROM SL_ORD_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.AC_NAME,A.AC_CODE ORDER BY A.AC_NAME";
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
							tCustName.Text = DC_Main.ColValue[0];
						}
						((Control)tCustName).Focus();
					}
				}
				else
				{
					tCustName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
					((Control)cboCity).Focus();
				}
			}
			else
			{
				tCustName.Text = "";
				((Control)cboCity).Focus();
			}
		}
		else
		{
			((Control)cboCity).Focus();
		}
	}

	private void btnOrdWithBill_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdAdjBillWise.RPT";
		}
		CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(tCustName.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Bill Wise Order Adjust Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "OrdAdjBillWise";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Bill Wise Order Adjust Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void tBookCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnCashBank_Click(object sender, EventArgs e)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Book Code First And Try...", (MsgBoxStyle)0, (object)null);
			((Control)tBookCode).Focus();
			return;
		}
		string text = "";
		DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BOOK_TYPE"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			if (Operators.CompareString(text, "T", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CashBankBillAc.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CashBankBill.RPT";
			}
		}
		else if (Operators.CompareString(text, "T", false) == 0)
		{
			DC_Main.RptName = "CashBankBillAc";
		}
		else
		{
			DC_Main.RptName = "CashBankBill";
		}
		CurFormula = "{CASH_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {CASH_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {CASH_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {CASH_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {CASH_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {CASH_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {CASH_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {CASH_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.MsPrintType = "InVoiceType";
			DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnKrIsu_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrIsuReport.RPT";
		}
		CurFormula = "{KR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {KR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {KR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {KR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {KR_DETL.BOOK_NAME} = 'KARIGAR ISSUE'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {KR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {KR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {KR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Karigar Item Issue Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "KrIsuReport";
			DC_Main.RptFormula = CurFormula;
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Karigar Item Issue Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnKrRec_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRecReport.RPT";
		}
		CurFormula = "{KR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {KR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {KR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {KR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {KR_DETL.BOOK_NAME} = 'KARIGAR RECEIPT'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {KR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {KR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {KR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Karigar Item Issue Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "KrRecReport";
			DC_Main.RptFormula = CurFormula;
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Karigar Item Received Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnVpIsu_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\VpIsuRpt.RPT";
		}
		CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {RATE_CUT_DATA.CO_BOOK} = '215'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_ANGDIYA} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'VP ISSUE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "VpIsuRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'VP ISSUE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnVpAdj_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\VpIsuRpt.RPT";
		}
		CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {RATE_CUT_DATA.CO_BOOK} = '215' AND {RATE_CUT_DATA.VP_AMT}- {RATE_CUT_DATA.VP_ADJ_AMT} = 0";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_ANGDIYA} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'VP ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "VpIsuRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'VP ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnVpPan_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\VpIsuRpt.RPT";
		}
		CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {RATE_CUT_DATA.CO_BOOK} = '215' AND {RATE_CUT_DATA.VP_AMT}- {RATE_CUT_DATA.VP_ADJ_AMT} <> 0";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_ANGDIYA} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'VP PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "VpIsuRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'VP PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnAngIsu_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AngdiyaIsuRpt.RPT";
		}
		CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {RATE_CUT_DATA.CO_BOOK} = '215'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_ANGDIYA} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'ANGDIYA ISSUE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "VpIsuRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'ANGDIYA ISSUE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnAngAdj_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AngdiyaIsuRpt.RPT";
		}
		CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {RATE_CUT_DATA.CO_BOOK} = '215' AND {RATE_CUT_DATA.VP_AMT}- {RATE_CUT_DATA.VP_ADJ_AMT} = 0";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_ANGDIYA} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'ANGDIYA ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AngdiyaIsuRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'ANGDIYA ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnAngPan_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AngdiyaIsuRpt.RPT";
		}
		CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {RATE_CUT_DATA.CO_BOOK} = '215' AND {RATE_CUT_DATA.VP_AMT}- {RATE_CUT_DATA.VP_ADJ_AMT} <> 0";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_ANGDIYA} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'ANGDIYA PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AngdiyaIsuRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'ANGDIYA PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnSlBook_Click(object sender, EventArgs e)
	{
		BulRptType = "BUL SL BOOKING";
		BulSlRpt();
	}

	private void BtnPrBook_Click(object sender, EventArgs e)
	{
		BulRptType = "BUL PR BOOKING";
		BulSlRpt();
	}

	private void BrnBulSlAdj_Click(object sender, EventArgs e)
	{
		BulRptType = "BUL SL ADJ";
		BulSlRpt();
	}

	private void BrnBulPrAdj_Click(object sender, EventArgs e)
	{
		BulRptType = "BUL PR ADJ";
		BulSlRpt();
	}

	private void BtnBusSlPanding_Click(object sender, EventArgs e)
	{
		BulRptType = "BUL SL PANDING";
		BulSlRpt();
	}

	private void BrnBulPrPanding_Click(object sender, EventArgs e)
	{
		BulRptType = "BUL PR PANDING";
		BulSlRpt();
	}

	private void BulSlRpt()
	{
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
		CurFormula = "{BUL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {BUL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {BUL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			if (Operators.CompareString(BulRptType, "BUL SL BOOKING", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BulCustBooking.RPT";
				CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'O' AND {BUL_DATA.BOOK_NAME} = 'BUL SALE' ";
				Cr[(short)0] = "RptTitel = 'SALES BOOKING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else if (Operators.CompareString(BulRptType, "BUL PR BOOKING", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BulCustBooking.RPT";
				CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'I'";
				Cr[(short)0] = "RptTitel = 'PURCHASE BOOKING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else if (Operators.CompareString(BulRptType, "BUL SL ADJ", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BulCustAdjust.RPT";
				CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'O' AND {BUL_DATA.BOOK_NAME} = 'BUL SALE'";
				Cr[(short)0] = "RptTitel = 'SALES BOOKING ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else if (Operators.CompareString(BulRptType, "BUL PR ADJ", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BulCustAdjust.RPT";
				CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'I'";
				Cr[(short)0] = "RptTitel = 'PURCHASE BOOKING ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else if (Operators.CompareString(BulRptType, "BUL SL PANDING", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BulCustAdjust.RPT";
				CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'O' AND {BUL_DATA.BOOK_NAME} = 'BUL SALE'";
				CurFormula += " And ({BUL_DATA.ITM_GWT} - {BUL_DATA.ADJ_WT}) > 0";
				Cr[(short)0] = "RptTitel = 'SALES BOOKING PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			else if (Operators.CompareString(BulRptType, "BUL PR PANDING", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BulCustAdjust.RPT";
				CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'I'";
				CurFormula += " And ({BUL_DATA.ITM_GWT} - {BUL_DATA.ADJ_WT}) > 0";
				Cr[(short)0] = "RptTitel = 'SALES BOOKING PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
		}
		else if (Operators.CompareString(BulRptType, "BUL SL BOOKING", false) == 0)
		{
			DC_Main.RptName = "BulCustBooking";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'SALES BOOKING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'O' AND {BUL_DATA.BOOK_NAME} = 'BUL SALE' ";
		}
		else if (Operators.CompareString(BulRptType, "BUL PR BOOKING", false) == 0)
		{
			DC_Main.RptName = "BulCustBooking";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'PURCHASE BOOKING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'I'";
		}
		else if (Operators.CompareString(BulRptType, "BUL SL ADJ", false) == 0)
		{
			DC_Main.RptName = "BulCustAdjust";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'SALES BOOKING ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'O' AND {BUL_DATA.BOOK_NAME} = 'BUL SALE'";
		}
		else if (Operators.CompareString(BulRptType, "BUL PR ADJ", false) == 0)
		{
			DC_Main.RptName = "BulCustAdjust";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'PURCHASE BOOKING ADJUST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'I'";
		}
		else if (Operators.CompareString(BulRptType, "BUL SL PANDING", false) == 0)
		{
			DC_Main.RptName = "BulCustAdjust";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'SALES BOOKING PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'O' AND {BUL_DATA.BOOK_NAME} = 'BUL SALE'";
			CurFormula += " And ({BUL_DATA.ITM_GWT} - {BUL_DATA.ADJ_WT}) > 0";
		}
		else if (Operators.CompareString(BulRptType, "BUL PR PANDING", false) == 0)
		{
			DC_Main.RptName = "BulCustAdjust";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'SALES BOOKING PANDING REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			CurFormula += " And {BUL_DATA.INOUT_TYPE} = 'I'";
			CurFormula += " And ({BUL_DATA.ITM_GWT} - {BUL_DATA.ADJ_WT}) > 0";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BUL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BUL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BUL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BUL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BUL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void ReparingRpt()
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
		}
		CurFormula = "{REP_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REP_DETL.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {REP_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {REP_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		switch (RepringType)
		{
		case "CUST REC":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Customer Reparing Received Item Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "CustRepRec";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CustRepRec.RPT";
				Cr[(short)0] = "RptTitel = 'Customer Reparing Received Item Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'CUSTREP RECEIPT'";
			break;
		case "KR ISU PANDING":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Reparing Item Isu Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "CustRepRec";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CustRepRec.RPT";
				Cr[(short)0] = "RptTitel = 'Reparing Item Isu Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'CUSTREP RECEIPT'";
			CurFormula += " And {REP_DETL.ISU_ADJ} = 'N'";
			break;
		case "KR REP ISU":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Reparing Isu To Karigar Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "CustRepRec";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CustRepRec.RPT";
				Cr[(short)0] = "RptTitel = 'Reparing Isu To Karigar Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'KRREP ISSUE'";
			break;
		case "KR REC PANDING":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Karigar Reparing Rec Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "CustRepRec";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CustRepRec.RPT";
				Cr[(short)0] = "RptTitel = 'Karigar Reparing Rec Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'KRREP ISSUE'";
			CurFormula += " And {REP_DETL.ISU_ADJ} = 'N'";
			break;
		case "KR REP REC":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Karigar Reparing Rec Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "KrRepRec";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRepRec.RPT";
				Cr[(short)0] = "RptTitel = 'Karigar Reparing Rec Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'KRREP RECEIPT'";
			break;
		case "CUST REP ISU":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Customer Reparing Isu Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "CustRepIsu";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CustRepIsu.RPT";
				Cr[(short)0] = "RptTitel = 'Customer Reparing Isu Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'CUSTREP ISSUE'";
			break;
		case "CUST ISU PAN":
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Customer Reparing Isu Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.RptName = "KrRepRec";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRepRec.RPT";
				Cr[(short)0] = "RptTitel = 'Customer Reparing Isu Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			}
			CurFormula += " And {REP_DETL.BOOK_NAME} = 'KRREP RECEIPT'";
			CurFormula += " And {REP_DETL.ISU_ADJ} = 'N'";
			break;
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {REP_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {REP_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {REP_DETL.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnRepRec_Click(object sender, EventArgs e)
	{
		RepringType = "CUST REC";
		ReparingRpt();
	}

	private void BtnRepIsu_Click(object sender, EventArgs e)
	{
		RepringType = "KR ISU PANDING";
		ReparingRpt();
	}

	private void BtnKrRepIsu_Click(object sender, EventArgs e)
	{
		RepringType = "KR REP ISU";
		ReparingRpt();
	}

	private void BtnKrRepPan_Click(object sender, EventArgs e)
	{
		RepringType = "KR REC PANDING";
		ReparingRpt();
	}

	private void BtnKrRepRec_Click(object sender, EventArgs e)
	{
		RepringType = "KR REP REC";
		ReparingRpt();
	}

	private void BtnCustRepPan_Click(object sender, EventArgs e)
	{
		RepringType = "CUST REP ISU";
		ReparingRpt();
	}

	private void BtnCustRepIsuPan_Click(object sender, EventArgs e)
	{
		RepringType = "CUST ISU PAN";
		ReparingRpt();
	}

	private void BtnOrdMakePan_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdDetlPanding.RPT";
		}
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM310NEPK", false) == 0)
			{
				DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA As A LEFT JOIN SL_ORD_ADJ As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"' "));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DETL.DESIGN_ISU} = 'N' ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(tCustName.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "OrdDetlPanding";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr.SelectionFormula = CurFormula;
				Cr[(short)0] = "RptTitel = 'Order Design Issue Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void BtnWhSumm_Click(object sender, EventArgs e)
	{
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Invalid comparison between Unknown and I4
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE  FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE  FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (unchecked((int)Interaction.MsgBox((object)"Wh Sales Bill Print", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)0] = "";
					Cr[(short)1] = "";
					Cr[(short)2] = "";
					Cr[(short)3] = "";
					Cr[(short)4] = "";
				}
				string text = "";
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PRINT_TYPE = 'WH SALES'  ORDER BY PRINT_FILE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						}
						DC_Main.X++;
					}
				}
				else
				{
					DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '01'  AND PRINT_TYPE = 'WH SALES'  ORDER BY PRINT_FILE";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						int num2 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.X = 0;
						while (DC_Main.X <= num2)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
							{
								text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
							}
							DC_Main.X++;
						}
					}
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";
				}
				else
				{
					DC_Main.RptName = text;
				}
				CurFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {RATE_CUT_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {RATE_CUT_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(tBookCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_DATA.AC_CODE} = '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
				}
				if (Operators.CompareString(ScelectBook, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_DATA.CO_BOOK} in [" + ScelectBook + "]";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsWappPrintType = "All";
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
				}
				else
				{
					Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
			}
			else
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr[(short)0] = "";
					Cr[(short)1] = "";
					Cr[(short)2] = "";
					Cr[(short)3] = "";
					Cr[(short)4] = "";
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesSumm.RPT";
				}
				CurFormula = "{RATE_CUT_ISU_REC.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_ISU_REC.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(tItCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
				}
				if (Operators.CompareString(tBookCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} = '" + tBookCode.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.AC_CODE} = '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
				}
				if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
				}
				if (Operators.CompareString(tGrCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
				}
				if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
				}
				if (Operators.CompareString(ScelectBook, "", false) != 0)
				{
					CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} in [" + ScelectBook + "]";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Wh Sales Summ Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptName = "WhSalesSumm";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr[(short)0] = "RptTitel = 'Wh Sales Summ Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
			}
		}
	}

	private void btnAcPurc_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcPurcRpt.RPT";
		}
		CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcPurcRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnWhEmpSale_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesEmp.RPT";
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE  FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		CurFormula = "{RATE_CUT_ISU_REC.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_ISU_REC.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Emp Wise Wh Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "WhSalesEmp";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Emp Wise Wh Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
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
		DC_Main.RsQry = "SELECT A.CO_BOOK,A.BOOK_NAME FROM BOOK_DATA  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.CO_BOOK ";
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
				((DataGridView)dGV_ITM).Columns[0].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "CO_BOOK");
				((DataGridView)dGV_ITM).Columns[1].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridView)dGV_ITM).Columns.Add("", "BOOK_NAME");
				((DataGridView)dGV_ITM).Columns[2].Width = (int)Math.Round(250.0 * DC_Main.ScreenHight);
				((DataGridView)DGV_ITM).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_ITM).RowTemplate.Height * DC_Main.ScreenHight);
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

	private void BtnItCancel_Click(object sender, EventArgs e)
	{
		((Control)PnlIt).Visible = false;
		ScelectBook = "";
	}

	private void btnSchmOpen_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembOpenNew.RPT";
		}
		CurFormula = "{AD_MEMB.CO_CODE} = '" + DC_Main.MCo_code + "'  AND {AD_MEMB.JOIN_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_MEMB.JOIN_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Member Join Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "MembOpenNew";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Member Join Report From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSchmRec_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembDailyRecRpt.RPT";
		}
		CurFormula = "{AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.MEMB_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_DATA.SCHM_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AD_MEMB.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Member Daily Received From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "MembDailyRecRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"RptTitel = '", Interaction.IIf(Operators.CompareString(tItCode.Text, "", false) == 0, (object)"All", (object)tItCode.Text)), (object)" Member Daily Received From "), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy")), (object)" To "), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy")), (object)"'"));
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnCntrTrfr_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CounterTrfr.RPT";
		}
		CurFormula = "{BAR_CAN_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {BAR_CAN_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {BAR_CAN_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'COUNTER TRFR'";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BAR_CAN_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BAR_CAN_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BAR_CAN_DETL.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "CounterTrfr";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Party Wise Approval Issue From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnCounterSale_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\CounterSale.RPT";
		}
		CurFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.TR_TYPE} = 'S' AND {MAIN_STOCK.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {MAIN_STOCK.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Counter Wise Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "CounterSale";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Counter Wise Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnSlWithOrder_Click(object sender, EventArgs e)
	{
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesWithOrder.RPT";
		}
		CurFormula = "{SL_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DETL.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if ((int)Interaction.MsgBox((object)"Only Item Sales With Order", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			CurFormula += " And {SL_DETL.ORD_NO} <> ''";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DETL.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DETL.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DETL.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DETL.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Sales With Order Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "SalesWithOrder";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Sales With Order Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnDesignSumm_Click(object sender, EventArgs e)
	{
		//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Invalid comparison between Unknown and I4
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdDesignSumm.RPT";
		}
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM310NEPK", false) == 0)
			{
				DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO FROM SL_ORD_DATA As A LEFT JOIN SL_ORD_ADJ As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  = 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DETL SET DESIGN_ISU = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"' "));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT TOP(5) * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			CurFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# AND {SL_ORD_DETL.DESIGN_ISU} = 'N' ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(tCustName.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_ORD_DATA.AC_NAME} = '" + tCustName.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Order Design Issue Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			if ((int)Interaction.MsgBox((object)"Only Design Summery Report..", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.MsCrForName1 = "OnlySumm";
				DC_Main.MsCrForStr1 = "'Y'";
			}
			else
			{
				DC_Main.MsCrForName1 = "OnlySumm";
				DC_Main.MsCrForStr1 = "'N'";
			}
			DC_Main.RptName = "OrdDesignSumm";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Only Design Summery Report..", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				Cr[(short)1] = "OnlySumm = 'Y'";
			}
			else
			{
				Cr[(short)1] = "OnlySumm = 'N'";
			}
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Order Design Issue Panding Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void mFromDt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
	{
	}

	private void btnSlGroup_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesGroupWise.RPT";
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND ({SL_DATA.NET_AMT}+{SL_DATA.TOT_TAX_FREE_AMT}) <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		else
		{
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.NET_AMT} <> 0 AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Item Group Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "SalesGroupWise";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Item Group Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnLabourRpt_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LbrWorkRpt.RPT";
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,0,0,''  FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,EMP_CODE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP, ISNULL(NET_AMT,0),RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,0,0,''  FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		CurFormula = "{RATE_CUT_ISU_REC.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_ISU_REC.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {RATE_CUT_ISU_REC.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Labour Work Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "LbrWorkRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Labour Work Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnGroupPurc_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcGroupWise.RPT";
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND ({PR_DATA.NET_AMT}+{PR_DATA.TOT_TAX_FREE_AMT}) <> 0 AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		else
		{
			CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.NET_AMT} <> 0 AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboState.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboEmploy.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.EMP_CODE} = '" + Strings.Mid(cboEmploy.Text, 1, 3) + "'";
		}
		if (Operators.CompareString(ScelectBook, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} in [" + ScelectBook + "]";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Item Group Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "PurcGroupWise";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Item Group Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnItmSl_Click(object sender, EventArgs e)
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
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembCommRpt.RPT";
				}
				CurFormula = "{COMM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {COMM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {COMM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				CurFormula += " And {AC_MAST.AC_WITH_MEMB_COM} = 'Y'";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {COMM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(tBookCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {COMM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {COMM_DATA.MEMB_AC_CODE} = '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(tItCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
				}
				if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
				}
				if (Operators.CompareString(tGrCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Membar Wise Commition Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptName = "MembCommRpt";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr[(short)0] = "RptTitel = 'Membar Wise Commition Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
				return;
			}
			string text = "";
			DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PRINT_TYPE = 'ITEM SALES'  ORDER BY PRINT_FILE";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '01'  AND PRINT_TYPE = 'ITEM SALES'  ORDER BY PRINT_FILE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num2 = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num2)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						}
						DC_Main.X++;
					}
				}
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text + ".RPT";
			}
			else
			{
				DC_Main.RptName = text;
			}
			CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboState.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
			}
			if (Operators.CompareString(ScelectBook, "", false) != 0)
			{
				CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.MsPrintType = "InVoiceType";
				DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
			}
			else
			{
				Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void btnb2bSl_Click(object sender, EventArgs e)
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
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembCommRpt.RPT";
				}
				CurFormula = "{COMM_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {COMM_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {COMM_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				CurFormula += " And {AC_MAST.AC_SHARE_HOLDER_COM} = 'Y'";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {COMM_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(tBookCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {COMM_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {COMM_DATA.MEMB_AC_CODE} = '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(tItCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.PR_CODE} = '" + tItCode.Text + "'";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
				}
				if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
				}
				if (Operators.CompareString(tGrCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {ITEM_MAST.GR_CODE} = '" + tGrCode.Text + "'";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsRptTitel = "RptTitel";
					DC_Main.MsRptTitelStr = "'Membar Wise Commition Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					DC_Main.MsWappPrintType = "All";
					DC_Main.RptName = "MembCommRpt";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
					CurFormula = "";
				}
				else
				{
					Cr.SelectionFormula = CurFormula;
					Cr[(short)0] = "RptTitel = 'Membar Wise Commition Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
			}
			else
			{
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\B2BSaleBillA4Tax.RPT";
				}
				else
				{
					DC_Main.RptName = "B2BSaleBillA4Tax";
				}
				CurFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {SL_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(tLcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";
				}
				if (Operators.CompareString(tBookCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
				}
				if (Operators.CompareString(tAcCode.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {SL_DATA.AC_CODE} = '" + tAcCode.Text + "'";
				}
				if (Operators.CompareString(cboCity.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
				}
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
				}
				if (Operators.CompareString(cboState.Text, "", false) != 0)
				{
					CurFormula = CurFormula + " And {AC_MAST.AC_STATE} = '" + cboState.Text + "'";
				}
				if (Operators.CompareString(ScelectBook, "", false) != 0)
				{
					CurFormula = CurFormula + " And {SL_DATA.CO_BOOK} in [" + ScelectBook + "]";
				}
				if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
				{
					CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
				{
					DC_Main.MsWappPrintType = "All";
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
					DC_Main.RptFormula = CurFormula;
					Module_Save.ShowReportPreview();
				}
				else
				{
					Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
					Cr.SelectionFormula = CurFormula;
					Cr.Destination = (DestinationConstants)0;
					CurFormula = "";
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
			}
		}
	}

	private void btnParyPurcSumm_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcPurcSummRpt.RPT";
		}
		CurFormula = "{PR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {PR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {PR_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {PR_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.CO_BOOK} = '" + tBookCode.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {PR_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			CurFormula = CurFormula + " and {BOOK_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcPurcRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Party Purchase Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}
}
