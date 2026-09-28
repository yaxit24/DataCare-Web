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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_OS : Form
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
	[AccessedThroughProperty("mToDt")]
	private DateEdit _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private DateEdit _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

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
	[AccessedThroughProperty("tAcGroup")]
	private TextBox _tAcGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDistrict")]
	private ComboBox _cboDistrict;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGroupWise")]
	private QButton _BtnGroupWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWithRef")]
	private QButton _btnWithRef;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAreaWise")]
	private QButton _btnAreaWise;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCrList")]
	private QButton _BtnCrList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDrList")]
	private QButton _BtnDrList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLedrSum")]
	private QButton _btnLedrSum;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLdrDetl")]
	private QButton _btnLdrDetl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLdrWeight")]
	private QButton _btnLdrWeight;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSilver")]
	private QButton _BtnSilver;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnGold")]
	private QButton _btnGold;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkAcSelect")]
	private CheckBox _chkAcSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkAcGroup")]
	private CheckBox _chkAcGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ChkCity")]
	private CheckBox _ChkCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIntRpt")]
	private QButton _btnIntRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPayIntPrc")]
	private TextBox _nPayIntPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nRecIntPrc")]
	private TextBox _nRecIntPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRptType")]
	private ComboBox _cboRptType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntDays")]
	private TextBox _nIntDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillOs")]
	private QButton _btnBillOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMainAc")]
	private QButton _btnMainAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkGoldInt")]
	private CheckBox _chkGoldInt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkSilver")]
	private CheckBox _chkSilver;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string ScelectAc;

	private string SelectGr;

	private string SelectCity;

	private string MainAcCode;

	private DataTable RsLdr;

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

	internal virtual DateEdit mToDt
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
			DateEdit val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mToDt = value;
			val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual DateEdit mFromDt
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
			DateEdit val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tRefAc
	{
		[CompilerGenerated]
		get
		{
			return _tRefAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRefAc_KeyDown);
			TextBox val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRefAc = value;
			val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefName")]
	private virtual TextBox _tRefName;

	internal virtual TextBox tRefName
	{
		get
		{
			return _tRefName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRefName = value;
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

	internal virtual TextBox tAcGroup
	{
		[CompilerGenerated]
		get
		{
			return _tAcGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcGroup_KeyDown);
			TextBox val2 = _tAcGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcGroup = value;
			val2 = _tAcGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcGrName")]
	private virtual TextBox _tAcGrName;

	internal virtual TextBox tAcGrName
	{
		get
		{
			return _tAcGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcGrName = value;
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

	internal virtual ComboBox cboDistrict
	{
		[CompilerGenerated]
		get
		{
			return _cboDistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboDistrict_KeyDown);
			ComboBox val2 = _cboDistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboDistrict = value;
			val2 = _cboDistrict;
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

	internal virtual QButton BtnGroupWise
	{
		[CompilerGenerated]
		get
		{
			return _BtnGroupWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGroupWise_Click;
			QButton val = _BtnGroupWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGroupWise = value;
			val = _BtnGroupWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnWithRef
	{
		[CompilerGenerated]
		get
		{
			return _btnWithRef;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnWithRef_Click;
			QButton val = _btnWithRef;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWithRef = value;
			val = _btnWithRef;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnAreaWise
	{
		[CompilerGenerated]
		get
		{
			return _btnAreaWise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAreaWise_Click;
			QButton val = _btnAreaWise;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAreaWise = value;
			val = _btnAreaWise;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAmount")]
	private virtual TextBox _nAmount;

	internal virtual TextBox nAmount
	{
		get
		{
			return _nAmount;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAmount = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBigAmt")]
	private virtual TextBox _nBigAmt;

	internal virtual TextBox nBigAmt
	{
		get
		{
			return _nBigAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBigAmt = value;
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

	internal virtual QButton BtnCrList
	{
		[CompilerGenerated]
		get
		{
			return _BtnCrList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCrList_Click;
			QButton val = _BtnCrList;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCrList = value;
			val = _BtnCrList;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnDrList
	{
		[CompilerGenerated]
		get
		{
			return _BtnDrList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDrList_Click;
			QButton val = _BtnDrList;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDrList = value;
			val = _BtnDrList;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnLedrSum
	{
		[CompilerGenerated]
		get
		{
			return _btnLedrSum;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLedrSum_Click;
			QButton val = _btnLedrSum;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLedrSum = value;
			val = _btnLedrSum;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnLdrDetl
	{
		[CompilerGenerated]
		get
		{
			return _btnLdrDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLdrDetl_Click;
			QButton val = _btnLdrDetl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLdrDetl = value;
			val = _btnLdrDetl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnLdrWeight
	{
		[CompilerGenerated]
		get
		{
			return _btnLdrWeight;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLdrWeight_Click;
			QButton val = _btnLdrWeight;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLdrWeight = value;
			val = _btnLdrWeight;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnSilver
	{
		[CompilerGenerated]
		get
		{
			return _BtnSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSilver_Click;
			QButton val = _BtnSilver;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSilver = value;
			val = _BtnSilver;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnGold
	{
		[CompilerGenerated]
		get
		{
			return _btnGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGold_Click;
			QButton val = _btnGold;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnGold = value;
			val = _btnGold;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkAcSelect
	{
		[CompilerGenerated]
		get
		{
			return _chkAcSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkAcSelect_CheckedChanged;
			CheckBox val = _chkAcSelect;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkAcSelect = value;
			val = _chkAcSelect;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlAc")]
	private virtual Panel _PnlAc;

	internal virtual Panel PnlAc
	{
		get
		{
			return _PnlAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlAc = value;
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
	[AccessedThroughProperty("DGV")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
	{
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV = value;
		}
	}

	internal virtual CheckBox chkAcGroup
	{
		[CompilerGenerated]
		get
		{
			return _chkAcGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkAcGroup_CheckedChanged;
			CheckBox val = _chkAcGroup;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkAcGroup = value;
			val = _chkAcGroup;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox ChkCity
	{
		[CompilerGenerated]
		get
		{
			return _ChkCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkCity_CheckedChanged;
			CheckBox val = _ChkCity;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_ChkCity = value;
			val = _ChkCity;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
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

	internal virtual QButton btnIntRpt
	{
		[CompilerGenerated]
		get
		{
			return _btnIntRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIntRpt_Click;
			QButton val = _btnIntRpt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIntRpt = value;
			val = _btnIntRpt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox nPayIntPrc
	{
		[CompilerGenerated]
		get
		{
			return _nPayIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPayIntPrc_KeyDown);
			TextBox val2 = _nPayIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPayIntPrc = value;
			val2 = _nPayIntPrc;
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

	internal virtual TextBox nRecIntPrc
	{
		[CompilerGenerated]
		get
		{
			return _nRecIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nRecIntPrc_KeyDown);
			TextBox val2 = _nRecIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nRecIntPrc = value;
			val2 = _nRecIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual ComboBox cboRptType
	{
		[CompilerGenerated]
		get
		{
			return _cboRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboRptType_KeyDown);
			ComboBox val2 = _cboRptType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboRptType = value;
			val2 = _cboRptType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nIntDays
	{
		[CompilerGenerated]
		get
		{
			return _nIntDays;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntDays_KeyDown);
			TextBox val2 = _nIntDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntDays = value;
			val2 = _nIntDays;
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

	internal virtual QButton btnBillOs
	{
		[CompilerGenerated]
		get
		{
			return _btnBillOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBillOs_Click;
			QButton val = _btnBillOs;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillOs = value;
			val = _btnBillOs;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnMainAc
	{
		[CompilerGenerated]
		get
		{
			return _btnMainAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMainAc_Click;
			QButton val = _btnMainAc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMainAc = value;
			val = _btnMainAc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkGoldInt
	{
		[CompilerGenerated]
		get
		{
			return _chkGoldInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkGoldInt_Click;
			CheckBox val = _chkGoldInt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkGoldInt = value;
			val = _chkGoldInt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkSilver
	{
		[CompilerGenerated]
		get
		{
			return _chkSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkSilver_Click;
			CheckBox val = _chkSilver;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkSilver = value;
			val = _chkSilver;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public RP_OS()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += RP_OS_Load;
		((Form)this).Deactivate += RP_OS_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_OS_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_OS_KeyDown);
		((Form)this).Closed += RP_OS_Closed;
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
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Expected O, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected O, but got Unknown
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Expected O, but got Unknown
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Expected O, but got Unknown
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Expected O, but got Unknown
		//IL_09fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Expected O, but got Unknown
		//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Expected O, but got Unknown
		//IL_0b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c76: Expected O, but got Unknown
		//IL_0cdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce1: Expected O, but got Unknown
		//IL_0d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0c: Expected O, but got Unknown
		//IL_0db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Expected O, but got Unknown
		//IL_0e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e26: Expected O, but got Unknown
		//IL_0e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e51: Expected O, but got Unknown
		//IL_0e9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea7: Expected O, but got Unknown
		//IL_0f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f31: Expected O, but got Unknown
		//IL_0fb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc2: Expected O, but got Unknown
		//IL_1076: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Expected O, but got Unknown
		//IL_1131: Unknown result type (might be due to invalid IL or missing references)
		//IL_113b: Expected O, but got Unknown
		//IL_11b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c2: Expected O, but got Unknown
		//IL_1247: Unknown result type (might be due to invalid IL or missing references)
		//IL_1251: Expected O, but got Unknown
		//IL_132c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1336: Expected O, but got Unknown
		//IL_13b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c0: Expected O, but got Unknown
		//IL_149e: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a8: Expected O, but got Unknown
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_1532: Expected O, but got Unknown
		//IL_15e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f0: Expected O, but got Unknown
		//IL_1670: Unknown result type (might be due to invalid IL or missing references)
		//IL_167a: Expected O, but got Unknown
		//IL_1701: Unknown result type (might be due to invalid IL or missing references)
		//IL_170b: Expected O, but got Unknown
		//IL_17cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d5: Expected O, but got Unknown
		//IL_1844: Unknown result type (might be due to invalid IL or missing references)
		//IL_184e: Expected O, but got Unknown
		//IL_1902: Unknown result type (might be due to invalid IL or missing references)
		//IL_190c: Expected O, but got Unknown
		//IL_1989: Unknown result type (might be due to invalid IL or missing references)
		//IL_1993: Expected O, but got Unknown
		//IL_1a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a21: Expected O, but got Unknown
		//IL_1e3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edb: Expected O, but got Unknown
		//IL_1f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_2176: Unknown result type (might be due to invalid IL or missing references)
		//IL_219a: Unknown result type (might be due to invalid IL or missing references)
		//IL_21be: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_220b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2215: Expected O, but got Unknown
		//IL_2238: Unknown result type (might be due to invalid IL or missing references)
		//IL_249c: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2508: Unknown result type (might be due to invalid IL or missing references)
		//IL_2531: Unknown result type (might be due to invalid IL or missing references)
		//IL_253b: Expected O, but got Unknown
		//IL_2561: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_280d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2831: Unknown result type (might be due to invalid IL or missing references)
		//IL_285a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2864: Expected O, but got Unknown
		//IL_2887: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b89: Expected O, but got Unknown
		//IL_2bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eae: Expected O, but got Unknown
		//IL_2ed1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3134: Unknown result type (might be due to invalid IL or missing references)
		//IL_3158: Unknown result type (might be due to invalid IL or missing references)
		//IL_317c: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d3: Expected O, but got Unknown
		//IL_31f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3456: Unknown result type (might be due to invalid IL or missing references)
		//IL_347a: Unknown result type (might be due to invalid IL or missing references)
		//IL_349e: Unknown result type (might be due to invalid IL or missing references)
		//IL_34c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_34eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_34f5: Expected O, but got Unknown
		//IL_3518: Unknown result type (might be due to invalid IL or missing references)
		//IL_377b: Unknown result type (might be due to invalid IL or missing references)
		//IL_379f: Unknown result type (might be due to invalid IL or missing references)
		//IL_37c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_37e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3810: Unknown result type (might be due to invalid IL or missing references)
		//IL_381a: Expected O, but got Unknown
		//IL_383a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b3c: Expected O, but got Unknown
		//IL_3b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_3de3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e07: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e54: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e5e: Expected O, but got Unknown
		//IL_3e81: Unknown result type (might be due to invalid IL or missing references)
		//IL_40e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4108: Unknown result type (might be due to invalid IL or missing references)
		//IL_412c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4150: Unknown result type (might be due to invalid IL or missing references)
		//IL_4179: Unknown result type (might be due to invalid IL or missing references)
		//IL_4183: Expected O, but got Unknown
		//IL_41a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4219: Unknown result type (might be due to invalid IL or missing references)
		//IL_4223: Expected O, but got Unknown
		//IL_42b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_42bc: Expected O, but got Unknown
		//IL_433a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4344: Expected O, but got Unknown
		//IL_43e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_43ee: Expected O, but got Unknown
		//IL_44a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ac: Expected O, but got Unknown
		//IL_47fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_481e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4842: Unknown result type (might be due to invalid IL or missing references)
		//IL_4866: Unknown result type (might be due to invalid IL or missing references)
		//IL_488f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4899: Expected O, but got Unknown
		//IL_48bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_4956: Unknown result type (might be due to invalid IL or missing references)
		//IL_4960: Expected O, but got Unknown
		//IL_49f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_49ff: Expected O, but got Unknown
		//IL_4a7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a87: Expected O, but got Unknown
		//IL_4b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b66: Expected O, but got Unknown
		//IL_4bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bd9: Expected O, but got Unknown
		//IL_4c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c96: Expected O, but got Unknown
		//IL_4d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d56: Expected O, but got Unknown
		//IL_4f72: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f7c: Expected O, but got Unknown
		//IL_5053: Unknown result type (might be due to invalid IL or missing references)
		//IL_505d: Expected O, but got Unknown
		//IL_50db: Unknown result type (might be due to invalid IL or missing references)
		//IL_50e5: Expected O, but got Unknown
		//IL_5193: Unknown result type (might be due to invalid IL or missing references)
		//IL_519d: Expected O, but got Unknown
		//IL_5211: Unknown result type (might be due to invalid IL or missing references)
		//IL_521b: Expected O, but got Unknown
		//IL_52c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_52cd: Expected O, but got Unknown
		//IL_5341: Unknown result type (might be due to invalid IL or missing references)
		//IL_534b: Expected O, but got Unknown
		//IL_53f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_53fd: Expected O, but got Unknown
		//IL_5471: Unknown result type (might be due to invalid IL or missing references)
		//IL_547b: Expected O, but got Unknown
		//IL_5713: Unknown result type (might be due to invalid IL or missing references)
		//IL_5737: Unknown result type (might be due to invalid IL or missing references)
		//IL_575b: Unknown result type (might be due to invalid IL or missing references)
		//IL_577f: Unknown result type (might be due to invalid IL or missing references)
		//IL_57a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_57b2: Expected O, but got Unknown
		//IL_57d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_584b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5855: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_OS));
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
		mToDt = new DateEdit();
		mFromDt = new DateEdit();
		tRefAc = new TextBox();
		tRefName = new TextBox();
		Label1 = new Label();
		Label2 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label3 = new Label();
		cboCity = new ComboBox();
		lblCity = new Label();
		cboArea = new ComboBox();
		Label17 = new Label();
		tAcGroup = new TextBox();
		tAcGrName = new TextBox();
		Label4 = new Label();
		cboDistrict = new ComboBox();
		Label5 = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		PanelOrder = new Panel();
		btnMainAc = new QButton();
		btnBillOs = new QButton();
		BtnSilver = new QButton();
		btnGold = new QButton();
		btnLdrWeight = new QButton();
		btnLdrDetl = new QButton();
		btnLedrSum = new QButton();
		BtnCrList = new QButton();
		BtnDrList = new QButton();
		BtnGroupWise = new QButton();
		btnWithRef = new QButton();
		btnAreaWise = new QButton();
		nAmount = new TextBox();
		nBigAmt = new TextBox();
		Label7 = new Label();
		Label8 = new Label();
		chkAcSelect = new CheckBox();
		PnlAc = new Panel();
		btnOk = new QButton();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		chkAcGroup = new CheckBox();
		ChkCity = new CheckBox();
		Panel1 = new Panel();
		chkGoldInt = new CheckBox();
		cboRptType = new ComboBox();
		Label12 = new Label();
		nIntDays = new TextBox();
		Label10 = new Label();
		nPayIntPrc = new TextBox();
		Label11 = new Label();
		nRecIntPrc = new TextBox();
		Label9 = new Label();
		btnIntRpt = new QButton();
		chkSilver = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mToDt.Properties).BeginInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mFromDt.Properties).BeginInit();
		((Control)PanelOrder).SuspendLayout();
		((Control)PnlAc).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)Panel1).SuspendLayout();
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
		((Control)PnlBotam).TabIndex = 5;
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
		((Control)lblBook).TabIndex = 6;
		lblBook.Text = "Party Account Report";
		lblBook.TextAlign = (ContentAlignment)32;
		mToDt.EditValue = null;
		((Control)mToDt).Location = new Point(587, 55);
		((Control)mToDt).Name = "mToDt";
		((RepositoryItem)mToDt.Properties).Appearance.BackColor = Color.FromArgb(255, 224, 192);
		((RepositoryItem)mToDt.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)mToDt.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)mToDt.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)mToDt.Properties).BorderStyle = (BorderStyles)1;
		((RepositoryItemButtonEdit)mToDt.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemButtonEdit)mToDt.Properties.CalendarTimeProperties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((Control)mToDt).Size = new Size(105, 22);
		((Control)mToDt).TabIndex = 1;
		mFromDt.EditValue = null;
		((Control)mFromDt).Location = new Point(475, 55);
		((Control)mFromDt).Name = "mFromDt";
		((RepositoryItem)mFromDt.Properties).Appearance.BackColor = Color.FromArgb(255, 224, 192);
		((RepositoryItem)mFromDt.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)mFromDt.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)mFromDt.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)mFromDt.Properties).BorderStyle = (BorderStyles)1;
		((RepositoryItemButtonEdit)mFromDt.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemButtonEdit)mFromDt.Properties.CalendarTimeProperties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((Control)mFromDt).Size = new Size(105, 22);
		((Control)mFromDt).TabIndex = 0;
		((TextBoxBase)tRefAc).BackColor = Color.White;
		((Control)tRefAc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefAc).Location = new Point(475, 141);
		((TextBoxBase)tRefAc).MaxLength = 8;
		((Control)tRefAc).Name = "tRefAc";
		((Control)tRefAc).Size = new Size(76, 23);
		((Control)tRefAc).TabIndex = 4;
		((TextBoxBase)tRefName).BackColor = Color.White;
		((Control)tRefName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefName).Location = new Point(557, 140);
		((TextBoxBase)tRefName).MaxLength = 8;
		((Control)tRefName).Name = "tRefName";
		((Control)tRefName).Size = new Size(282, 23);
		((Control)tRefName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(408, 142);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Ref Ac";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(367, 55);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "From / To Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(475, 112);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 4;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(557, 112);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(393, 112);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(75, 20);
		((Control)Label3).TabIndex = 1165;
		Label3.Text = "Party Code";
		Label3.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(475, 199);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(180, 22);
		((Control)cboCity).TabIndex = 6;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(409, 198);
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
		((Control)cboArea).Location = new Point(475, 227);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(180, 22);
		((Control)cboArea).TabIndex = 7;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(420, 228);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(47, 19);
		((Control)Label17).TabIndex = 1168;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcGroup).BackColor = Color.White;
		((Control)tAcGroup).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcGroup).Location = new Point(475, 170);
		((TextBoxBase)tAcGroup).MaxLength = 8;
		((Control)tAcGroup).Name = "tAcGroup";
		((Control)tAcGroup).Size = new Size(76, 23);
		((Control)tAcGroup).TabIndex = 5;
		((TextBoxBase)tAcGrName).BackColor = Color.White;
		((Control)tAcGrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcGrName).Location = new Point(557, 170);
		((TextBoxBase)tAcGrName).MaxLength = 8;
		((Control)tAcGrName).Name = "tAcGrName";
		((Control)tAcGrName).Size = new Size(282, 23);
		((Control)tAcGrName).TabIndex = 1172;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(384, 169);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(84, 20);
		((Control)Label4).TabIndex = 1171;
		Label4.Text = "Ac Group";
		Label4.TextAlign = (ContentAlignment)64;
		cboDistrict.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboDistrict).Font = new Font("Tahoma", 9f);
		((ListControl)cboDistrict).FormattingEnabled = true;
		((Control)cboDistrict).Location = new Point(475, 255);
		((Control)cboDistrict).Name = "cboDistrict";
		((Control)cboDistrict).Size = new Size(180, 22);
		((Control)cboDistrict).TabIndex = 8;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(370, 258);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(99, 20);
		((Control)Label5).TabIndex = 1174;
		Label5.Text = "Item Type";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(475, 84);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(76, 23);
		((Control)tLcCode).TabIndex = 2;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(557, 83);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(282, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(408, 84);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "Lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)PanelOrder).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelOrder).Controls.Add((Control)(object)btnMainAc);
		((Control)PanelOrder).Controls.Add((Control)(object)btnBillOs);
		((Control)PanelOrder).Controls.Add((Control)(object)BtnSilver);
		((Control)PanelOrder).Controls.Add((Control)(object)btnGold);
		((Control)PanelOrder).Controls.Add((Control)(object)btnLdrWeight);
		((Control)PanelOrder).Controls.Add((Control)(object)btnLdrDetl);
		((Control)PanelOrder).Controls.Add((Control)(object)btnLedrSum);
		((Control)PanelOrder).Controls.Add((Control)(object)BtnCrList);
		((Control)PanelOrder).Controls.Add((Control)(object)BtnDrList);
		((Control)PanelOrder).Controls.Add((Control)(object)BtnGroupWise);
		((Control)PanelOrder).Controls.Add((Control)(object)btnWithRef);
		((Control)PanelOrder).Controls.Add((Control)(object)btnAreaWise);
		((Control)PanelOrder).Location = new Point(293, 318);
		((Control)PanelOrder).Name = "PanelOrder";
		((Control)PanelOrder).Size = new Size(574, 216);
		((Control)PanelOrder).TabIndex = 1180;
		((QControl)btnMainAc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnMainAc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnMainAc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnMainAc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnMainAc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnMainAc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnMainAc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnMainAc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnMainAc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnMainAc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnMainAc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnMainAc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnMainAc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnMainAc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnMainAc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainAc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainAc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainAc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainAc.Image = null;
		((QControl)btnMainAc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnMainAc).Location = new Point(399, 161);
		((Control)btnMainAc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnMainAc).Name = "btnMainAc";
		((Control)btnMainAc).Size = new Size(143, 37);
		((Control)btnMainAc).TabIndex = 11;
		btnMainAc.Text = "With Main Ac";
		((QControl)btnMainAc).ToolTipText = "Ledger Group With Main Ac";
		((QControl)btnBillOs).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBillOs).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBillOs).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBillOs).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBillOs).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBillOs).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBillOs).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnBillOs).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBillOs).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBillOs).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBillOs).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBillOs).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBillOs).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBillOs).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBillOs.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillOs.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillOs.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillOs.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillOs.Image = null;
		((QControl)btnBillOs).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBillOs).Location = new Point(214, 61);
		((Control)btnBillOs).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBillOs).Name = "btnBillOs";
		((Control)btnBillOs).Size = new Size(143, 37);
		((Control)btnBillOs).TabIndex = 10;
		btnBillOs.Text = "Bill Wise Rec";
		((QControl)BtnSilver).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSilver).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSilver).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSilver).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSilver).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSilver).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSilver).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnSilver).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSilver).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSilver).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSilver).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSilver).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSilver).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSilver).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSilver.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Image = null;
		((QControl)BtnSilver).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSilver).Location = new Point(214, 161);
		((Control)BtnSilver).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSilver).Name = "BtnSilver";
		((Control)BtnSilver).Size = new Size(143, 37);
		((Control)BtnSilver).TabIndex = 9;
		BtnSilver.Text = "Silver Fine";
		((QControl)btnGold).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnGold).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGold).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnGold).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnGold).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnGold).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGold).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnGold).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnGold).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnGold).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnGold).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGold).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnGold).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnGold).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnGold.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGold.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGold.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGold.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGold.Image = null;
		((QControl)btnGold).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnGold).Location = new Point(31, 161);
		((Control)btnGold).Margin = new Padding(3, 6, 3, 6);
		((Control)btnGold).Name = "btnGold";
		((Control)btnGold).Size = new Size(143, 37);
		((Control)btnGold).TabIndex = 8;
		btnGold.Text = "Gold Fine";
		((QControl)btnLdrWeight).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLdrWeight).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLdrWeight).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLdrWeight).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLdrWeight).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLdrWeight.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrWeight.Image = null;
		((QControl)btnLdrWeight).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLdrWeight).Location = new Point(399, 112);
		((Control)btnLdrWeight).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLdrWeight).Name = "btnLdrWeight";
		((Control)btnLdrWeight).Size = new Size(143, 37);
		((Control)btnLdrWeight).TabIndex = 7;
		btnLdrWeight.Text = "Ledger Weight";
		((QControl)btnLdrDetl).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLdrDetl).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrDetl).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLdrDetl).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLdrDetl).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLdrDetl).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLdrDetl).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLdrDetl).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLdrDetl).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLdrDetl).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLdrDetl).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLdrDetl).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLdrDetl).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLdrDetl).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLdrDetl.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrDetl.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrDetl.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrDetl.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLdrDetl.Image = null;
		((QControl)btnLdrDetl).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLdrDetl).Location = new Point(214, 112);
		((Control)btnLdrDetl).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLdrDetl).Name = "btnLdrDetl";
		((Control)btnLdrDetl).Size = new Size(143, 37);
		((Control)btnLdrDetl).TabIndex = 6;
		btnLdrDetl.Text = "Ledger Detail";
		((QControl)btnLedrSum).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLedrSum).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLedrSum).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLedrSum).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLedrSum).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLedrSum).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLedrSum).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLedrSum).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLedrSum).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLedrSum).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLedrSum).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLedrSum).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLedrSum).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLedrSum).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLedrSum.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLedrSum.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLedrSum.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLedrSum.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLedrSum.Image = null;
		((QControl)btnLedrSum).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLedrSum).Location = new Point(31, 112);
		((Control)btnLedrSum).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLedrSum).Name = "btnLedrSum";
		((Control)btnLedrSum).Size = new Size(143, 37);
		((Control)btnLedrSum).TabIndex = 5;
		btnLedrSum.Text = "Ledger Summ";
		((QControl)BtnCrList).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnCrList).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnCrList).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnCrList).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnCrList).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnCrList).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnCrList).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnCrList).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnCrList).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnCrList).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnCrList).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnCrList).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnCrList).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnCrList).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnCrList.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCrList.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCrList.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCrList.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCrList.Image = null;
		((QControl)BtnCrList).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnCrList).Location = new Point(398, 61);
		((Control)BtnCrList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnCrList).Name = "BtnCrList";
		((Control)BtnCrList).Size = new Size(143, 37);
		((Control)BtnCrList).TabIndex = 4;
		BtnCrList.Text = "Cr Ac List";
		((QControl)BtnDrList).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDrList).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDrList).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDrList).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDrList).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDrList).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDrList).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnDrList).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDrList).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDrList).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDrList).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDrList).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDrList).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDrList).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDrList.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDrList.Image = null;
		((QControl)BtnDrList).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDrList).Location = new Point(33, 63);
		((Control)BtnDrList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDrList).Name = "BtnDrList";
		((Control)BtnDrList).Size = new Size(143, 37);
		((Control)BtnDrList).TabIndex = 3;
		BtnDrList.Text = "Dr Ac List";
		((QControl)BtnGroupWise).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGroupWise).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGroupWise).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGroupWise).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGroupWise).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGroupWise.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroupWise.Image = null;
		((QControl)BtnGroupWise).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGroupWise).Location = new Point(31, 14);
		((Control)BtnGroupWise).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroupWise).Name = "BtnGroupWise";
		((Control)BtnGroupWise).Size = new Size(143, 37);
		((Control)BtnGroupWise).TabIndex = 0;
		BtnGroupWise.Text = "Group Wise";
		((QControl)btnWithRef).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWithRef).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWithRef).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWithRef).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWithRef).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWithRef).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWithRef).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWithRef).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWithRef).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWithRef).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWithRef).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWithRef).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWithRef).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWithRef).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWithRef.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWithRef.Image = null;
		((QControl)btnWithRef).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWithRef).Location = new Point(214, 14);
		((Control)btnWithRef).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWithRef).Name = "btnWithRef";
		((Control)btnWithRef).Size = new Size(143, 37);
		((Control)btnWithRef).TabIndex = 1;
		btnWithRef.Text = "Os With Ref Ac";
		((QControl)btnAreaWise).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAreaWise).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAreaWise).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAreaWise).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAreaWise).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAreaWise).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAreaWise).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAreaWise).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAreaWise).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAreaWise).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAreaWise).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAreaWise.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAreaWise.Image = null;
		((QControl)btnAreaWise).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAreaWise).Location = new Point(398, 14);
		((Control)btnAreaWise).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAreaWise).Name = "btnAreaWise";
		((Control)btnAreaWise).Size = new Size(143, 37);
		((Control)btnAreaWise).TabIndex = 2;
		btnAreaWise.Text = "Area Wise Sum";
		((TextBoxBase)nAmount).BackColor = Color.White;
		((Control)nAmount).Font = new Font("Tahoma", 9f);
		((Control)nAmount).Location = new Point(475, 283);
		((TextBoxBase)nAmount).MaxLength = 10;
		((Control)nAmount).Name = "nAmount";
		((Control)nAmount).Size = new Size(90, 22);
		((Control)nAmount).TabIndex = 1181;
		nAmount.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nBigAmt).BackColor = Color.White;
		((Control)nBigAmt).Font = new Font("Tahoma", 9f);
		((Control)nBigAmt).Location = new Point(658, 283);
		((TextBoxBase)nBigAmt).MaxLength = 10;
		((Control)nBigAmt).Name = "nBigAmt";
		((Control)nBigAmt).Size = new Size(90, 22);
		((Control)nBigAmt).TabIndex = 1182;
		nBigAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(369, 285);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(99, 20);
		((Control)Label7).TabIndex = 1183;
		Label7.Text = "Amount >=";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(573, 284);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(83, 20);
		((Control)Label8).TabIndex = 1184;
		Label8.Text = "Amount <=";
		Label8.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkAcSelect).BackColor = Color.Transparent;
		((Control)chkAcSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkAcSelect).ForeColor = Color.Black;
		((Control)chkAcSelect).Location = new Point(862, 114);
		((Control)chkAcSelect).Name = "chkAcSelect";
		((Control)chkAcSelect).RightToLeft = (RightToLeft)0;
		((Control)chkAcSelect).Size = new Size(141, 19);
		((Control)chkAcSelect).TabIndex = 1204;
		((ButtonBase)chkAcSelect).Text = "Select Ac";
		((ButtonBase)chkAcSelect).UseVisualStyleBackColor = false;
		((Control)PnlAc).BackColor = Color.LavenderBlush;
		PnlAc.BorderStyle = (BorderStyle)1;
		((Control)PnlAc).Controls.Add((Control)(object)btnOk);
		((Control)PnlAc).Controls.Add((Control)(object)DGV);
		((Control)PnlAc).Location = new Point(245, 116);
		((Control)PnlAc).Name = "PnlAc";
		((Control)PnlAc).Size = new Size(713, 299);
		((Control)PnlAc).TabIndex = 1205;
		((Control)PnlAc).Visible = false;
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
		((Control)btnOk).Location = new Point(278, 249);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(159, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(11, 11);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV).ScrollBars = (ScrollBars)2;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(688, 229);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1156;
		((ButtonBase)chkAcGroup).BackColor = Color.Transparent;
		((Control)chkAcGroup).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkAcGroup).ForeColor = Color.Black;
		((Control)chkAcGroup).Location = new Point(862, 143);
		((Control)chkAcGroup).Name = "chkAcGroup";
		((Control)chkAcGroup).RightToLeft = (RightToLeft)0;
		((Control)chkAcGroup).Size = new Size(141, 19);
		((Control)chkAcGroup).TabIndex = 1206;
		((ButtonBase)chkAcGroup).Text = "Select Ac Group";
		((ButtonBase)chkAcGroup).UseVisualStyleBackColor = false;
		((ButtonBase)ChkCity).BackColor = Color.Transparent;
		((Control)ChkCity).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ChkCity).ForeColor = Color.Black;
		((Control)ChkCity).Location = new Point(862, 174);
		((Control)ChkCity).Name = "ChkCity";
		((Control)ChkCity).RightToLeft = (RightToLeft)0;
		((Control)ChkCity).Size = new Size(141, 19);
		((Control)ChkCity).TabIndex = 1207;
		((ButtonBase)ChkCity).Text = "Select City";
		((ButtonBase)ChkCity).UseVisualStyleBackColor = false;
		((Control)Panel1).BackColor = SystemColors.ButtonHighlight;
		((Control)Panel1).Controls.Add((Control)(object)chkSilver);
		((Control)Panel1).Controls.Add((Control)(object)chkGoldInt);
		((Control)Panel1).Controls.Add((Control)(object)cboRptType);
		((Control)Panel1).Controls.Add((Control)(object)Label12);
		((Control)Panel1).Controls.Add((Control)(object)nIntDays);
		((Control)Panel1).Controls.Add((Control)(object)Label10);
		((Control)Panel1).Controls.Add((Control)(object)nPayIntPrc);
		((Control)Panel1).Controls.Add((Control)(object)Label11);
		((Control)Panel1).Controls.Add((Control)(object)nRecIntPrc);
		((Control)Panel1).Controls.Add((Control)(object)Label9);
		((Control)Panel1).Controls.Add((Control)(object)btnIntRpt);
		((Control)Panel1).Location = new Point(871, 285);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(248, 249);
		((Control)Panel1).TabIndex = 1208;
		((ButtonBase)chkGoldInt).BackColor = Color.Transparent;
		((Control)chkGoldInt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkGoldInt).ForeColor = Color.Black;
		((Control)chkGoldInt).Location = new Point(107, 37);
		((Control)chkGoldInt).Name = "chkGoldInt";
		((Control)chkGoldInt).RightToLeft = (RightToLeft)0;
		((Control)chkGoldInt).Size = new Size(115, 19);
		((Control)chkGoldInt).TabIndex = 1208;
		((ButtonBase)chkGoldInt).Text = "Gold Intrest";
		((ButtonBase)chkGoldInt).UseVisualStyleBackColor = false;
		cboRptType.AutoCompleteMode = (AutoCompleteMode)3;
		cboRptType.AutoCompleteSource = (AutoCompleteSource)256;
		cboRptType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboRptType).Font = new Font("Tahoma", 9f);
		((ListControl)cboRptType).FormattingEnabled = true;
		((Control)cboRptType).Location = new Point(107, 152);
		((Control)cboRptType).Name = "cboRptType";
		((Control)cboRptType).Size = new Size(90, 22);
		((Control)cboRptType).TabIndex = 1167;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(17, 152);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(77, 19);
		((Control)Label12).TabIndex = 1168;
		Label12.Text = "Rpt Type";
		Label12.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nIntDays).BackColor = Color.White;
		((Control)nIntDays).Font = new Font("Tahoma", 9f);
		((Control)nIntDays).Location = new Point(107, 121);
		((TextBoxBase)nIntDays).MaxLength = 6;
		((Control)nIntDays).Name = "nIntDays";
		((Control)nIntDays).Size = new Size(90, 22);
		((Control)nIntDays).TabIndex = 32;
		nIntDays.TextAlign = (HorizontalAlignment)2;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(17, 121);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(77, 20);
		((Control)Label10).TabIndex = 33;
		Label10.Text = "Int Days";
		Label10.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nPayIntPrc).BackColor = Color.White;
		((Control)nPayIntPrc).Font = new Font("Tahoma", 9f);
		((Control)nPayIntPrc).Location = new Point(107, 93);
		((TextBoxBase)nPayIntPrc).MaxLength = 6;
		((Control)nPayIntPrc).Name = "nPayIntPrc";
		((Control)nPayIntPrc).Size = new Size(90, 22);
		((Control)nPayIntPrc).TabIndex = 29;
		nPayIntPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(17, 93);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(77, 20);
		((Control)Label11).TabIndex = 31;
		Label11.Text = "Pay Int %";
		Label11.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nRecIntPrc).BackColor = Color.White;
		((Control)nRecIntPrc).Font = new Font("Tahoma", 9f);
		((Control)nRecIntPrc).Location = new Point(107, 64);
		((TextBoxBase)nRecIntPrc).MaxLength = 6;
		((Control)nRecIntPrc).Name = "nRecIntPrc";
		((Control)nRecIntPrc).Size = new Size(90, 22);
		((Control)nRecIntPrc).TabIndex = 28;
		nRecIntPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(17, 66);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(77, 20);
		((Control)Label9).TabIndex = 30;
		Label9.Text = "Rec Int %";
		Label9.TextAlign = (ContentAlignment)16;
		((QControl)btnIntRpt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnIntRpt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnIntRpt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnIntRpt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnIntRpt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnIntRpt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnIntRpt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnIntRpt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnIntRpt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnIntRpt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnIntRpt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnIntRpt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnIntRpt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnIntRpt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnIntRpt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnIntRpt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnIntRpt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnIntRpt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnIntRpt.Image = null;
		((QControl)btnIntRpt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnIntRpt).Location = new Point(54, 193);
		((Control)btnIntRpt).Margin = new Padding(3, 6, 3, 6);
		((Control)btnIntRpt).Name = "btnIntRpt";
		((Control)btnIntRpt).Size = new Size(143, 37);
		((Control)btnIntRpt).TabIndex = 8;
		btnIntRpt.Text = "Intrest Rpt";
		((ButtonBase)chkSilver).BackColor = Color.Transparent;
		((Control)chkSilver).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkSilver).ForeColor = Color.Black;
		((Control)chkSilver).Location = new Point(107, 12);
		((Control)chkSilver).Name = "chkSilver";
		((Control)chkSilver).RightToLeft = (RightToLeft)0;
		((Control)chkSilver).Size = new Size(115, 19);
		((Control)chkSilver).TabIndex = 1209;
		((ButtonBase)chkSilver).Text = "Silver Intrest";
		((ButtonBase)chkSilver).UseVisualStyleBackColor = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlAc);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)ChkCity);
		((Control)this).Controls.Add((Control)(object)chkAcGroup);
		((Control)this).Controls.Add((Control)(object)chkAcSelect);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)nBigAmt);
		((Control)this).Controls.Add((Control)(object)nAmount);
		((Control)this).Controls.Add((Control)(object)PanelOrder);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboDistrict);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tAcGroup);
		((Control)this).Controls.Add((Control)(object)tAcGrName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)cboCity);
		((Control)this).Controls.Add((Control)(object)lblCity);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tRefAc);
		((Control)this).Controls.Add((Control)(object)tRefName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_OS";
		((Form)this).Text = "Party Account Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mToDt.Properties).EndInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mFromDt.Properties).EndInit();
		((Control)PanelOrder).ResumeLayout(false);
		((Control)PnlAc).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_OS_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea6: Expected O, but got Unknown
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f30: Expected O, but got Unknown
		//IL_0fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0feb: Expected O, but got Unknown
		//IL_1059: Unknown result type (might be due to invalid IL or missing references)
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Expected O, but got Unknown
		//IL_10ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fb: Expected O, but got Unknown
		//IL_116d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1172: Unknown result type (might be due to invalid IL or missing references)
		//IL_1178: Expected O, but got Unknown
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_122f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected O, but got Unknown
		//IL_1258: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1267: Expected O, but got Unknown
		//IL_1286: Unknown result type (might be due to invalid IL or missing references)
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1295: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)PanelOrder).Controls)
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
			foreach (object control4 in ((Control)PnlAc).Controls)
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
			foreach (object control5 in ((Control)Panel1).Controls)
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
				((Control)Panel1).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((Control)PanelOrder).BackColor = Color.Silver;
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((ButtonBase)chkAcSelect).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				Panel panel = Panel1;
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panel).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelOrder = PanelOrder;
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelOrder).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj11 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				CheckBox obj13 = chkAcSelect;
				object? obj14 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj13).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)PnlAc).BackColor = Color.LightSlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj15 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				Panel panel2 = Panel1;
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				Panel panelOrder2 = PanelOrder;
				object? obj20 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelOrder2).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				CheckBox obj21 = chkAcSelect;
				object? obj22 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj21).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj23 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj24 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				Panel pnlAc = PnlAc;
				object? obj25 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlAc).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tLcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tLcCode).Font;
				try
				{
					foreach (Control control6 in ((Control)this).Controls)
					{
						Control val3 = control6;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is DateEdit || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)nRecIntPrc).Font.Size * (1.0 + num2));
				Font font2 = ((Control)nRecIntPrc).Font;
				try
				{
					foreach (object control7 in ((Control)PnlAc).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control8 in ((Control)Panel1).Controls)
					{
						object objectValue6 = RuntimeHelpers.GetObjectValue(control8);
						NewLateBinding.LateSet(objectValue6, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control9 in ((Control)PnlBotam).Controls)
					{
						object objectValue7 = RuntimeHelpers.GetObjectValue(control9);
						NewLateBinding.LateSet(objectValue7, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
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
				}
			}
			cboRptType.Items.Add((object)"Report");
			cboRptType.Items.Add((object)"Summ");
			cboRptType.SelectedIndex = 0;
			((Control)PnlAc).Top = ((Control)cboArea).Top;
			((Control)PnlAc).Left = ((Control)cboArea).Left - 200;
			nIntDays.Text = Conversions.ToString(DC_Main.MsIntYearDays);
			DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
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
			DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				cboArea.Items.Add((object)"");
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num5)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_DISTRICT FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_DISTRICT ORDER BY AC_DISTRICT ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboDistrict.Items.Clear();
				int num6 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num6)
				{
					cboDistrict.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_DISTRICT"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboDistrict.Items.Add((object)"");
			}
			mFromDt.EditValue = DC_Main.MOp_dt;
			mToDt.EditValue = DC_Main.MsSysDate;
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
		cboArea.SelectedIndex = 0;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_OS_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_OS_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_OS_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_OS_Closed(object sender, EventArgs e)
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
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.MAIN_AC_CODE As MainAcL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.LC_CODE,A.AC_NAME";
				}
				else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL,C.MAIN_AC_CODE As MainAcL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.MAIN_AC_CODE As MainAcL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.MAIN_AC_CODE As MainAcL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[9];
				DC_Main.ColWidth[0] = 270.0;
				DC_Main.ColWidth[1] = 80.0;
				DC_Main.ColWidth[2] = 170.0;
				DC_Main.ColWidth[3] = 180.0;
				DC_Main.ColWidth[4] = 220.0;
				DC_Main.ColWidth[5] = 160.0;
				DC_Main.ColWidth[6] = 110.0;
				DC_Main.ColWidth[7] = 110.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
						MainAcCode = DC_Main.ColValue[7];
					}
					else
					{
						MainAcCode = "";
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				MainAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			if (Operators.CompareString(tAcCode.Text, "", false) == 0)
			{
				MainAcCode = "";
			}
			SendKeys.Send("{tab}");
		}
	}

	private void tAcGroup_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_GR = '" + tAcGroup.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_GR As CodeL,AC_GR_NAME as NameL FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY AC_GR";
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
						tAcGroup.Text = DC_Main.ColValue[0];
						tAcGrName.Text = DC_Main.ColValue[1];
					}
					((Control)tAcGroup).Focus();
				}
			}
			else
			{
				tAcGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GR_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mFromDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
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

	private void cboDistrict_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
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

	private void BtnGroupWise_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcGroupRpt.RPT";
		}
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsRptTitelStr = "'Ac Group Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcGroupRpt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Ac Group Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnWithRef_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcOsWithAdd.RPT";
		}
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsRptTitelStr = "'Ac Group Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "ZeroPrint";
			DC_Main.MsCrForStr1 = "'No'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcOsWithAdd";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Ac Os Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "ZeroPrint = 'No'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnAreaWise_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcOsArea.RPT";
		}
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsRptTitelStr = "'Ac Group Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "ZeroPrint";
			DC_Main.MsCrForStr1 = "'No'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcOsArea";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Ac With Aria Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "ZeroPrint = 'No'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnDrList_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcDrList.RPT";
		}
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,SUM(DR_AMT-CR_AMT) AS DrAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tAcGroup.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGroup.Text + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.AC_CODE HAVING SUM(DR_AMT-CR_AMT) > 0 ORDER BY A.AC_CODE "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,A.DATA_TYPE,SUM(DR_AMT-CR_AMT) AS DrAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tAcGroup.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGroup.Text + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.AC_CODE,A.DATA_TYPE HAVING SUM(DR_AMT-CR_AMT) > 0 ORDER BY A.AC_CODE "));
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','',null,'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["DrAmt"]), "0.00")), (object)",0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(SelectGr, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
			}
			if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
			{
				CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.AC_CODE} in [" + ScelectAc + "]";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(SelectCity, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Conversion.Val(nAmount.Text) != 0.0)
			{
				CurFormula = (CurFormula + "AND {LEDR_AC_DATA.DR_AMT} >= " + Conversions.ToString(Conversion.Val(nAmount.Text))) ?? "";
			}
			if (Conversion.Val(nBigAmt.Text) != 0.0)
			{
				CurFormula = (CurFormula + "AND {LEDR_AC_DATA.DR_AMT} <= " + Conversions.ToString(Conversion.Val(nBigAmt.Text))) ?? "";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'ACCOUNT DEBIT AMOUNT REPORT AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "ZeroPrint";
				DC_Main.MsCrForStr1 = "'No'";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "AcDrList";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'ACCOUNT DEBIT AMOUNT REPORT AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				Cr[(short)1] = "ZeroPrint = 'No'";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void BtnCrList_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcCrList.RPT";
		}
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,SUM(CR_AMT-DR_AMT) AS CrAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tAcGroup.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGroup.Text + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.AC_CODE HAVING SUM(CR_AMT-DR_AMT) > 0 ORDER BY A.AC_CODE "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,A.DATA_TYPE,SUM(CR_AMT-DR_AMT) AS CrAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tAcGroup.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGroup.Text + "'"))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.AC_CODE,A.DATA_TYPE HAVING SUM(CR_AMT-DR_AMT) > 0 ORDER BY A.AC_CODE "));
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','',null,'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["CrAmt"]), "0.00")), (object)",0,0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.AC_CODE} in [" + ScelectAc + "]";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(SelectCity, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
			}
			if (Operators.CompareString(SelectGr, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
			}
			if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
			{
				CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Conversion.Val(nAmount.Text) != 0.0)
			{
				CurFormula = (CurFormula + "AND {LEDR_AC_DATA.DR_AMT} >= " + Conversions.ToString(Conversion.Val(nAmount.Text))) ?? "";
			}
			if (Conversion.Val(nBigAmt.Text) != 0.0)
			{
				CurFormula = (CurFormula + "AND {LEDR_AC_DATA.DR_AMT} <= " + Conversions.ToString(Conversion.Val(nBigAmt.Text))) ?? "";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'ACCOUNT CREADIT AMOUNT REPORT AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "ZeroPrint";
				DC_Main.MsCrForStr1 = "'No'";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "AcCrList";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'ACCOUNT CREADIT AMOUNT REPORT AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				Cr[(short)1] = "ZeroPrint = 'No'";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void btnLedrSum_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcSumm.RPT";
		}
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsRptTitelStr = "'ACCOUNT WITH WEIGHT SUMMARY REPORT AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "ZeroPrint";
			DC_Main.MsCrForStr1 = "'No'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcSumm";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'ACCOUNT WITH WEIGHT SUMMARY REPORT AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "ZeroPrint = 'No'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnLdrDetl_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcLedgerSelected.RPT";
		}
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_CODE,'A' As DATA_TYPE,SUM(CR_AMT-DR_AMT) AS CrDrAmt FROM AC_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tAcCode.Text + "'"))), (object)"  GROUP BY AC_CODE  ORDER BY AC_CODE "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_CODE,DATA_TYPE,SUM(CR_AMT-DR_AMT) AS CrDrAmt FROM AC_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tAcCode.Text + "'"))), (object)"  GROUP BY AC_CODE,DATA_TYPE  ORDER BY AC_CODE "));
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[DC_Main.X]["CrDrAmt"], (object)0, false))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','',null,'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',"), dataTable.Rows[DC_Main.X]["CrDrAmt"]), (object)",0,0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else if (Operators.ConditionalCompareObjectLess(dataTable.Rows[DC_Main.X]["CrDrAmt"], (object)0, false))
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','',null,'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,");
					Type? typeFromHandle = typeof(Math);
					DataRow dataRow;
					object[] obj2 = new object[1] { (dataRow = dataTable.Rows[DC_Main.X])["CrDrAmt"] };
					object[] array = obj2;
					bool[] obj3 = new bool[1] { true };
					bool[] array2 = obj3;
					object obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj2, (string[])null, (Type[])null, obj3);
					if (array2[0])
					{
						dataRow["CrDrAmt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, obj4), (object)",0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','',null,'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,0,0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DateTime.Compare(Conversions.ToDate(mFromDt.Text), DC_Main.MOp_dt) == 0)
			{
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(SelectCity, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
			}
			if (Operators.CompareString(SelectGr, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
			}
			if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
			{
				CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
				DC_Main.MsRptTitelStr = "'PARTY WISE LEDGER REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "ZeroPrint";
				DC_Main.MsCrForStr1 = "'No'";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "AcLedgerSelected";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'PARTY WISE LEDGER REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				Cr[(short)1] = "ZeroPrint = 'No'";
				Cr[(short)2] = "OpDate = Date(" + Conversions.ToString(DateAndTime.Year(DC_Main.MOp_dt)) + "," + Conversions.ToString(DateAndTime.Month(DC_Main.MOp_dt.AddDays(-1.0))) + "," + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd") + ") ";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void btnLdrWeight_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcWithWt.RPT";
		}
		if (DateTime.Compare(Conversions.ToDate(mFromDt.Text), DC_Main.MOp_dt) == 0)
		{
			CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		}
		else
		{
			CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsRptTitelStr = "'ACCOUNT WITH WEIGHT REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "ZeroPrint";
			DC_Main.MsCrForStr1 = "'No'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "AcWithWt";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'ACCOUNT WITH WEIGHT REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "ZeroPrint = 'No'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void ChkAcSelect_CheckedChanged(object sender, EventArgs e)
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ScelectAc = "";
		if (chkAcSelect.Checked)
		{
			((Control)PnlAc).Visible = true;
			PatyMast();
		}
		else
		{
			((Control)PnlAc).Visible = false;
		}
	}

	private void PatyMast()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CODE > '00100' ORDER BY A.AC_NAME ";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LEN(A.AC_CODE) <> 5 ORDER BY A.AC_NAME ";
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * DC_Main.ScreenHight);
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(250.0 * DC_Main.ScreenHight);
				((DataGridView)dGV).Columns.Add("", "AcCode");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(80.0 * DC_Main.ScreenHight);
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(130.0 * DC_Main.ScreenHight);
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * DC_Main.ScreenHight);
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
					((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void BtnGold_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcFineGold.RPT";
		}
		double num = 0.0;
		double num2 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,round(SUM(CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END),3) as GoldWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE  = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  and VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(ScelectAc, "", false) == 0, (object)"", (object)("AND A.AC_CODE IN (" + ScelectAc + ")"))), Interaction.IIf(Operators.CompareString(SelectGr, "", false) == 0, (object)"", (object)("AND B.AC_GR IN (" + SelectGr + ")"))), Interaction.IIf(Operators.CompareString(SelectCity, "", false) == 0, (object)"", (object)("AND B.AC_CITY IN (" + SelectCity + ")"))), Interaction.IIf(Operators.CompareString(tAcGroup.Text, "", false) == 0, (object)"", (object)(" AND B.AC_GR = '" + tAcGroup.Text + "'"))), (object)"  and A.IT_TYPE = 'G' AND A.FINE_WT <> 0 and A.AC_CODE <> '00045' AND A.AC_CODE <> '00050' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.AC_CODE HAVING ROUND(SUM(CASE WHEN A.SIGN='+' THEN A.FINE_WT ELSE -A.FINE_WT END),3) <> 0 "));
		RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < RsLdr.Rows.Count)
			{
				object Value = Operators.ConcatenateObject(RsLdr.Rows[DC_Main.M]["GoldWt"], (object)"");
				if (DC_Main.Fnv(ref Value) < 0.0)
				{
					double num3 = num;
					Type? typeFromHandle = typeof(Math);
					DataRow dataRow;
					object[] obj = new object[1] { (dataRow = RsLdr.Rows[DC_Main.M])["GoldWt"] };
					object[] array = obj;
					bool[] obj2 = new bool[1] { true };
					bool[] array2 = obj2;
					object obj3 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj, (string[])null, (Type[])null, obj2);
					if (array2[0])
					{
						dataRow["GoldWt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
					}
					num = num3 + Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(obj3), "0.000"));
				}
				else
				{
					num2 += Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsLdr.Rows[DC_Main.M]["GoldWt"]), "0.000"));
				}
				DC_Main.M++;
			}
			if (DateTime.Compare(Conversions.ToDate(mFromDt.Text), DC_Main.MOp_dt) == 0)
			{
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(SelectCity, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
			}
			if (Operators.CompareString(SelectGr, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
			}
			if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
			{
				CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
				DC_Main.MsRptTitelStr = "'GOLD FINE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "DrWt";
				DC_Main.MsCrForVal1 = Strings.Format((object)num, "0.000");
				DC_Main.MsCrForName2 = "CrWt";
				DC_Main.MsCrForVal2 = Strings.Format((object)num2, "0.000");
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "AcFineGold";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'GOLD FINE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				Cr[(short)1] = ("DrWt = " + Strings.Format((object)num, "0.000")) ?? "";
				Cr[(short)2] = ("CrWt = " + Strings.Format((object)num2, "0.000")) ?? "";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void BtnSilver_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AcFineSilver.RPT";
		}
		double num = 0.0;
		double num2 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,SUM(CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE  = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  and VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(ScelectAc, "", false) == 0, (object)"", (object)("AND A.AC_CODE IN (" + ScelectAc + ")"))), Interaction.IIf(Operators.CompareString(SelectGr, "", false) == 0, (object)"", (object)("AND B.AC_GR IN (" + SelectGr + ")"))), Interaction.IIf(Operators.CompareString(SelectCity, "", false) == 0, (object)"", (object)("AND B.AC_CITY IN (" + SelectCity + ")"))), Interaction.IIf(Operators.CompareString(tAcGroup.Text, "", false) == 0, (object)"", (object)(" AND B.AC_GR = '" + tAcGroup.Text + "'"))), (object)"  and A.IT_TYPE = 'S' AND A.FINE_WT <> 0 and A.AC_CODE <> '00045' AND A.AC_CODE <> '00050' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.AC_CODE HAVING SUM(iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT)) <> 0 "));
		RsLdr = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < RsLdr.Rows.Count)
			{
				object Value = Operators.ConcatenateObject(RsLdr.Rows[DC_Main.M]["SilverWt"], (object)"");
				if (DC_Main.Fnv(ref Value) < 0.0)
				{
					double num3 = num;
					Type? typeFromHandle = typeof(Math);
					DataRow dataRow;
					object[] obj = new object[1] { (dataRow = RsLdr.Rows[DC_Main.M])["SilverWt"] };
					object[] array = obj;
					bool[] obj2 = new bool[1] { true };
					bool[] array2 = obj2;
					object obj3 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj, (string[])null, (Type[])null, obj2);
					if (array2[0])
					{
						dataRow["SilverWt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
					}
					num = num3 + Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(obj3), "0.000"));
				}
				else
				{
					num2 += Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsLdr.Rows[DC_Main.M]["SilverWt"]), "0.000"));
				}
				DC_Main.M++;
			}
			if (DateTime.Compare(Conversions.ToDate(mFromDt.Text), DC_Main.MOp_dt) == 0)
			{
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			}
			else
			{
				CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(SelectCity, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
			}
			if (Operators.CompareString(SelectGr, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
			}
			if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
			{
				CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
				DC_Main.MsRptTitelStr = "'SILVER FINE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "DrWt";
				DC_Main.MsCrForVal1 = Strings.Format((object)num, "0.000");
				DC_Main.MsCrForName2 = "CrWt";
				DC_Main.MsCrForVal2 = Strings.Format((object)num2, "0.000");
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "AcFineSilver";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'SILVER FINE REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				Cr[(short)1] = ("DrWt = " + Strings.Format((object)num, "0.000")) ?? "";
				Cr[(short)2] = ("CrWt = " + Strings.Format((object)num2, "0.000")) ?? "";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void ChkAcGroup_CheckedChanged(object sender, EventArgs e)
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		SelectGr = "";
		if (chkAcGroup.Checked)
		{
			((Control)PnlAc).Visible = true;
			GroupMast();
		}
		else
		{
			((Control)PnlAc).Visible = false;
		}
	}

	private void GroupMast()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.AC_GR,A.AC_GR_NAME FROM AC_GROUP AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.AC_GR";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "GrCode");
				((DataGridView)dGV).Columns[1].Width = 80;
				((DataGridView)dGV).Columns.Add("", "GrName");
				((DataGridView)dGV).Columns[2].Width = 250;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_GR"]);
					((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_GR_NAME"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (chkAcSelect.Checked)
			{
				ScelectAc = "";
				int num = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false) && chkAcSelect.Checked)
					{
						ScelectAc = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(ScelectAc + "'"), ((DataGridView)DGV).Rows[DC_Main.M].Cells[3].Value), (object)"',"));
					}
					DC_Main.M++;
				}
				if (chkAcSelect.Checked)
				{
					if (Operators.CompareString(ScelectAc, "", false) == 0)
					{
						Interaction.MsgBox((object)"Party Selection Not Done...", (MsgBoxStyle)0, (object)null);
						((Control)PnlAc).Visible = false;
					}
					else
					{
						ScelectAc = Strings.Mid(ScelectAc, 1, Strings.Len(ScelectAc) - 1);
						Interaction.MsgBox((object)"Party Selection is Ok...", (MsgBoxStyle)0, (object)null);
						((Control)PnlAc).Visible = false;
					}
				}
			}
			if (chkAcGroup.Checked)
			{
				SelectGr = "";
				int num2 = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false) && chkAcGroup.Checked)
					{
						SelectGr = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(SelectGr + "'"), ((DataGridView)DGV).Rows[DC_Main.M].Cells[1].Value), (object)"',"));
					}
					DC_Main.M++;
				}
				if (chkAcGroup.Checked)
				{
					if (Operators.CompareString(SelectGr, "", false) == 0)
					{
						Interaction.MsgBox((object)"Group Selection Not Done...", (MsgBoxStyle)0, (object)null);
						((Control)PnlAc).Visible = false;
					}
					else
					{
						SelectGr = Strings.Mid(SelectGr, 1, Strings.Len(SelectGr) - 1);
						Interaction.MsgBox((object)"Group Selection is Ok...", (MsgBoxStyle)0, (object)null);
						((Control)PnlAc).Visible = false;
					}
				}
			}
			if (!ChkCity.Checked)
			{
				return;
			}
			SelectCity = "";
			int num3 = ((DataGridView)DGV).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num3)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false) && ChkCity.Checked)
				{
					SelectCity = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(SelectCity + "'"), ((DataGridView)DGV).Rows[DC_Main.M].Cells[1].Value), (object)"',"));
				}
				DC_Main.M++;
			}
			if (ChkCity.Checked)
			{
				if (Operators.CompareString(SelectCity, "", false) == 0)
				{
					Interaction.MsgBox((object)"City Selection Not Done...", (MsgBoxStyle)0, (object)null);
					((Control)PnlAc).Visible = false;
				}
				else
				{
					SelectCity = Strings.Mid(SelectCity, 1, Strings.Len(SelectCity) - 1);
					Interaction.MsgBox((object)"City Selection is Ok...", (MsgBoxStyle)0, (object)null);
					((Control)PnlAc).Visible = false;
				}
			}
		}
	}

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select B.AC_NAME,A.AC_REF_CODE From AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.AC_REF_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.AC_REF_CODE = '" + tRefAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.AC_REF_CODE As AcCodeL,B.AC_CITY AS CityL,B.AC_ADD1 As AddressL,B.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.AC_REF_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_REF_CODE <> '' GROUP BY B.AC_NAME,A.AC_REF_CODE,B.AC_CITY,B.AC_ADD1,B.AC_MOBILE ORDER BY B.AC_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[7];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 220.0;
				DC_Main.ColWidth[3] = 280.0;
				DC_Main.ColWidth[4] = 120.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
						tRefName.Text = DC_Main.ColValue[0];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				tRefName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void ChkCity_CheckedChanged(object sender, EventArgs e)
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		SelectCity = "";
		if (ChkCity.Checked)
		{
			((Control)PnlAc).Visible = true;
			CityMast();
		}
		else
		{
			((Control)PnlAc).Visible = false;
		}
	}

	private void CityMast()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.AC_CITY FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.AC_CITY ORDER BY A.AC_CITY";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[1].Width = 250;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void nRecIntPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nRecIntPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nRecIntPrc.Text)), "0.00");
			((Control)nPayIntPrc).Focus();
		}
	}

	private void nPayIntPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPayIntPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPayIntPrc.Text)), "0.00");
			((Control)nIntDays).Focus();
		}
	}

	private void nIntDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntDays.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntDays.Text)), "0");
			((Control)cboRptType).Focus();
		}
	}

	private void cboRptType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btnIntRpt).Focus();
		}
	}

	private void BtnIntRpt_Click(object sender, EventArgs e)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if ((Conversion.Val(nRecIntPrc.Text) == 0.0) & (Conversion.Val(nPayIntPrc.Text) == 0.0))
		{
			Interaction.MsgBox((object)"Please Insert Intrest Prc Then Try...", (MsgBoxStyle)0, (object)null);
			((Control)nRecIntPrc).Focus();
			return;
		}
		DateTime now = DateAndTime.Now;
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
			if (chkGoldInt.Checked)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\GoldInterest.RPT";
				Cr[(short)0] = "RptTitel = 'Gold INTEREST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else if (chkSilver.Checked)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\GoldInterest.RPT";
				Cr[(short)0] = "RptTitel = 'Silver INTEREST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else if (cboRptType.SelectedIndex == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PartyInterest.RPT";
				Cr[(short)0] = "RptTitel = 'INTEREST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PartyIntSumm.RPT";
				Cr[(short)0] = "RptTitel = 'INTEREST SUMMARY FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
		}
		CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
		if (chkGoldInt.Checked)
		{
			CurFormula += " And {AC_DATA.IT_TYPE} = 'G'";
		}
		if (chkSilver.Checked)
		{
			CurFormula += " And {AC_DATA.IT_TYPE} = 'S'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsWappPrintType = "All";
			if (chkGoldInt.Checked)
			{
				DC_Main.RptName = "GoldInterest";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Gold INTEREST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else if (chkSilver.Checked)
			{
				DC_Main.RptName = "GoldInterest";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Silver INTEREST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else if (cboRptType.SelectedIndex == 0)
			{
				DC_Main.RptName = "PartyInterest";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'INTEREST REPORT FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else
			{
				DC_Main.RptName = "PartyIntSumm";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'INTEREST SUMMARY FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			if (Operators.CompareString(Strings.Mid(Conversions.ToString(mFromDt.EditValue), 1, 5), "01/04", false) == 0)
			{
				DC_Main.MsCrForName1 = "FromDate";
				DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.EditValue))) + ",03,31)";
			}
			else
			{
				DC_Main.MsCrForName1 = "FromDate";
				DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.EditValue))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.EditValue))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd") + ")";
			}
			DC_Main.MsCrForName2 = "ToDate";
			DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.EditValue))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.EditValue))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd") + ")";
			DC_Main.MsCrForName3 = "AcPayInt";
			DC_Main.MsCrForVal3 = Conversions.ToString(Conversion.Val(nPayIntPrc.Text));
			DC_Main.MsCrForName4 = "AcRecInt";
			DC_Main.MsCrForVal4 = Conversions.ToString(Conversion.Val(nRecIntPrc.Text));
			DC_Main.MsCrForName5 = "DIVIDER";
			DC_Main.MsCrForVal5 = Conversions.ToString(Conversion.Val(nIntDays.Text));
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			if (Operators.CompareString(Strings.Mid(Conversions.ToString(mFromDt.EditValue), 1, 5), "01/04", false) == 0)
			{
				Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.EditValue))) + ",03,31) ";
			}
			else
			{
				Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.EditValue))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.EditValue))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd") + ") ";
			}
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.EditValue))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.EditValue))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd") + ") ";
			Cr[(short)3] = ("AcPayInt =" + Conversions.ToString(Conversion.Val(nPayIntPrc.Text))) ?? "";
			Cr[(short)4] = ("AcRecInt =" + Conversions.ToString(Conversion.Val(nRecIntPrc.Text))) ?? "";
			Cr[(short)5] = ("DIVIDER = " + Conversions.ToString(Conversion.Val(nIntDays.Text))) ?? "";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void btnBillOs_Click(object sender, EventArgs e)
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
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BillWiseOs.RPT";
		}
		string text = Interaction.InputBox("If Filter Book Then Insert Book Code ex.. 026", "DataCare Input Box", "", 500, 200);
		CurFormula = "{BILL_OS_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {BILL_OS_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {BILL_OS_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BILL_OS_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BILL_OS_DATA.CO_BOOK} = '" + text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(ScelectAc, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BILL_OS_DATA.AC_CODE} in [" + ScelectAc + "]";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {BILL_OS_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(SelectCity, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
		}
		if (Operators.CompareString(SelectGr, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
		}
		if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
		{
			CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
		}
		if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
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
			DC_Main.MsRptTitelStr = "'Ac Os Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "BillWiseOs";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'Ac Os Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			CurFormula = "";
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnMainAc_Click(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND B.MAIN_AC_CODE <> '' and A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(tRefAc.Text, "", false) == 0, (object)"", (object)("AND B.AC_REF_CODE = '" + tRefAc.Text + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + tLcCode.Text + "','" + DC_Main.MCo_year + "','000','" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "','00000','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',"), dataTable.Rows[DC_Main.X]["CrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["DrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["CrGold"]), (object)","), dataTable.Rows[DC_Main.X]["DrGold"]), (object)","), dataTable.Rows[DC_Main.X]["CrSilver"]), (object)","), dataTable.Rows[DC_Main.X]["DrSilver"]), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' ";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(SelectGr, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} in [" + SelectGr + "]";
			}
			if ((Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0) & (Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) != 0))
			{
				CurFormula = CurFormula + " And Not({AC_MAST.AC_GR} in [" + DC_Main.MsUserNotShowGr + "])";
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_GR} = '" + tAcGroup.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				CurFormula = CurFormula + " And {LEDR_AC_DATA.AC_CODE} in [" + ScelectAc + "]";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.MAIN_AC_CODE} = '" + MainAcCode + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(SelectCity, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_CITY} in [" + SelectCity + "]";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboDistrict.Text, "", false) != 0)
			{
				CurFormula = CurFormula + " And {AC_MAST.AC_DISTRICT} = '" + cboDistrict.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Conversion.Val(nAmount.Text) != 0.0)
			{
				CurFormula = (CurFormula + "AND {LEDR_AC_DATA.DR_AMT} >= " + Conversions.ToString(Conversion.Val(nAmount.Text))) ?? "";
			}
			if (Conversion.Val(nBigAmt.Text) != 0.0)
			{
				CurFormula = (CurFormula + "AND {LEDR_AC_DATA.DR_AMT} <= " + Conversions.ToString(Conversion.Val(nBigAmt.Text))) ?? "";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'MAIN ACCOUNT WISE SUMMERY AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = "MainAcSumm";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MainAcSumm.RPT";
				Cr[(short)0] = "RptTitel = 'MAIN ACCOUNT WISE SUMMERY AS ON  " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				CurFormula = "";
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void chkGoldInt_Click(object sender, EventArgs e)
	{
		if (chkGoldInt.Checked)
		{
			chkSilver.Checked = false;
		}
	}

	private void chkSilver_Click(object sender, EventArgs e)
	{
		if (chkSilver.Checked)
		{
			chkGoldInt.Checked = false;
		}
	}
}
