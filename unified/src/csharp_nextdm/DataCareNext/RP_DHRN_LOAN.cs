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
public class RP_DHRN_LOAN : Form
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
	[AccessedThroughProperty("cboPacket")]
	private ComboBox _cboPacket;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefNo")]
	private TextBox _tRefNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCustName")]
	private TextBox _tCustName;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tRefAc_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tRefAc_KeyDown);
			TextBox val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tRefAc = value;
			val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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
	[AccessedThroughProperty("PanelDhrn")]
	private virtual Panel _PanelDhrn;

	internal virtual Panel PanelDhrn
	{
		get
		{
			return _PanelDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelDhrn = value;
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

	internal virtual ComboBox cboPacket
	{
		[CompilerGenerated]
		get
		{
			return _cboPacket;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboPacket_KeyDown);
			KeyEventHandler val2 = new KeyEventHandler(cboPacket_KeyDown);
			ComboBox val3 = _cboPacket;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyDown -= val2;
			}
			_cboPacket = value;
			val3 = _cboPacket;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).KeyDown += val2;
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

	internal virtual TextBox tRefNo
	{
		[CompilerGenerated]
		get
		{
			return _tRefNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRefNo_KeyDown);
			TextBox val2 = _tRefNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRefNo = value;
			val2 = _tRefNo;
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

	public RP_DHRN_LOAN()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += RP_DHRN_LOAN_Load;
		((Form)this).Deactivate += RP_DHRN_LOAN_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_DHRN_LOAN_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_DHRN_LOAN_KeyDown);
		((Form)this).Closed += RP_DHRN_LOAN_Closed;
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
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected O, but got Unknown
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Expected O, but got Unknown
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected O, but got Unknown
		//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ff: Expected O, but got Unknown
		//IL_0b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b14: Expected O, but got Unknown
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7f: Expected O, but got Unknown
		//IL_0ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Expected O, but got Unknown
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected O, but got Unknown
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc4: Expected O, but got Unknown
		//IL_0ce9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Expected O, but got Unknown
		//IL_0d3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d45: Expected O, but got Unknown
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcf: Expected O, but got Unknown
		//IL_0e56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e60: Expected O, but got Unknown
		//IL_0f14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1e: Expected O, but got Unknown
		//IL_0fcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd9: Expected O, but got Unknown
		//IL_1056: Unknown result type (might be due to invalid IL or missing references)
		//IL_1060: Expected O, but got Unknown
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ef: Expected O, but got Unknown
		//IL_11ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d4: Expected O, but got Unknown
		//IL_1254: Unknown result type (might be due to invalid IL or missing references)
		//IL_125e: Expected O, but got Unknown
		//IL_133c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1346: Expected O, but got Unknown
		//IL_13c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d0: Expected O, but got Unknown
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_148e: Expected O, but got Unknown
		//IL_150b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1515: Expected O, but got Unknown
		//IL_1599: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a3: Expected O, but got Unknown
		//IL_1990: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a2f: Expected O, but got Unknown
		//IL_1a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d58: Expected O, but got Unknown
		//IL_1d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2005: Unknown result type (might be due to invalid IL or missing references)
		//IL_2029: Unknown result type (might be due to invalid IL or missing references)
		//IL_204d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2076: Unknown result type (might be due to invalid IL or missing references)
		//IL_2080: Expected O, but got Unknown
		//IL_20a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2306: Unknown result type (might be due to invalid IL or missing references)
		//IL_232a: Unknown result type (might be due to invalid IL or missing references)
		//IL_234e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2372: Unknown result type (might be due to invalid IL or missing references)
		//IL_239b: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a5: Expected O, but got Unknown
		//IL_23c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_262b: Unknown result type (might be due to invalid IL or missing references)
		//IL_264f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2673: Unknown result type (might be due to invalid IL or missing references)
		//IL_2697: Unknown result type (might be due to invalid IL or missing references)
		//IL_26c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ca: Expected O, but got Unknown
		//IL_26ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_294d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2971: Unknown result type (might be due to invalid IL or missing references)
		//IL_2995: Unknown result type (might be due to invalid IL or missing references)
		//IL_29b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ec: Expected O, but got Unknown
		//IL_2a0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d11: Expected O, but got Unknown
		//IL_2d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_3003: Unknown result type (might be due to invalid IL or missing references)
		//IL_302c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3036: Expected O, but got Unknown
		//IL_3059: Unknown result type (might be due to invalid IL or missing references)
		//IL_32bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_32e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3304: Unknown result type (might be due to invalid IL or missing references)
		//IL_3328: Unknown result type (might be due to invalid IL or missing references)
		//IL_3351: Unknown result type (might be due to invalid IL or missing references)
		//IL_335b: Expected O, but got Unknown
		//IL_337b: Unknown result type (might be due to invalid IL or missing references)
		//IL_35de: Unknown result type (might be due to invalid IL or missing references)
		//IL_3602: Unknown result type (might be due to invalid IL or missing references)
		//IL_3626: Unknown result type (might be due to invalid IL or missing references)
		//IL_364a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3673: Unknown result type (might be due to invalid IL or missing references)
		//IL_367d: Expected O, but got Unknown
		//IL_36a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3722: Unknown result type (might be due to invalid IL or missing references)
		//IL_372c: Expected O, but got Unknown
		//IL_379b: Unknown result type (might be due to invalid IL or missing references)
		//IL_37a5: Expected O, but got Unknown
		//IL_3865: Unknown result type (might be due to invalid IL or missing references)
		//IL_386f: Expected O, but got Unknown
		//IL_38e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ef: Expected O, but got Unknown
		//IL_39a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_39ad: Expected O, but got Unknown
		//IL_3a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a3b: Expected O, but got Unknown
		//IL_3aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_3af9: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_DHRN_LOAN));
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
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		PanelDhrn = new Panel();
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
		cboPacket = new ComboBox();
		Label5 = new Label();
		cboLoanType = new ComboBox();
		lblLoanType = new Label();
		tRefNo = new TextBox();
		Label4 = new Label();
		tCustName = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mToDt.Properties).BeginInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mFromDt.Properties).BeginInit();
		((Control)PanelDhrn).SuspendLayout();
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
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
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
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
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
		lblBook.Text = "Dhiran Report";
		lblBook.TextAlign = (ContentAlignment)32;
		mToDt.EditValue = null;
		((Control)mToDt).Location = new Point(587, 67);
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
		((Control)mFromDt).Location = new Point(475, 67);
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
		((Control)tRefAc).Location = new Point(475, 154);
		((TextBoxBase)tRefAc).MaxLength = 8;
		((Control)tRefAc).Name = "tRefAc";
		((Control)tRefAc).Size = new Size(76, 23);
		((Control)tRefAc).TabIndex = 3;
		((TextBoxBase)tRefName).BackColor = Color.White;
		((Control)tRefName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefName).Location = new Point(557, 153);
		((TextBoxBase)tRefName).MaxLength = 8;
		((Control)tRefName).Name = "tRefName";
		((Control)tRefName).Size = new Size(282, 23);
		((Control)tRefName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(408, 154);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Ref Ac";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(367, 67);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "From / To Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(475, 124);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 4;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(557, 124);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(393, 124);
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
		((Control)cboCity).Location = new Point(475, 183);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(180, 22);
		((Control)cboCity).TabIndex = 6;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(409, 182);
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
		((Control)cboArea).Location = new Point(475, 211);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(180, 22);
		((Control)cboArea).TabIndex = 7;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(420, 212);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(47, 19);
		((Control)Label17).TabIndex = 1168;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(475, 96);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(76, 23);
		((Control)tLcCode).TabIndex = 2;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(557, 95);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(282, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(408, 96);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "Lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)PanelDhrn).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnSilver);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnGold);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnLdrWeight);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnLdrDetl);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnLedrSum);
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnCrList);
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnDrList);
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnGroupWise);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnWithRef);
		((Control)PanelDhrn).Controls.Add((Control)(object)btnAreaWise);
		((Control)PanelDhrn).Location = new Point(226, 298);
		((Control)PanelDhrn).Name = "PanelDhrn";
		((Control)PanelDhrn).Size = new Size(712, 222);
		((Control)PanelDhrn).TabIndex = 1180;
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
		((Control)BtnSilver).Location = new Point(344, 165);
		((Control)BtnSilver).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSilver).Name = "BtnSilver";
		((Control)BtnSilver).Size = new Size(143, 37);
		((Control)BtnSilver).TabIndex = 9;
		BtnSilver.Text = "Silver Stock";
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
		((Control)btnGold).Location = new Point(182, 165);
		((Control)btnGold).Margin = new Padding(3, 6, 3, 6);
		((Control)btnGold).Name = "btnGold";
		((Control)btnGold).Size = new Size(143, 37);
		((Control)btnGold).TabIndex = 8;
		btnGold.Text = "Gold Stock";
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
		((Control)btnLdrWeight).Location = new Point(434, 11);
		((Control)btnLdrWeight).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLdrWeight).Name = "btnLdrWeight";
		((Control)btnLdrWeight).Size = new Size(143, 37);
		((Control)btnLdrWeight).TabIndex = 7;
		btnLdrWeight.Text = "Multi Time Issue";
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
		((Control)btnLdrDetl).Location = new Point(266, 113);
		((Control)btnLdrDetl).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLdrDetl).Name = "btnLdrDetl";
		((Control)btnLdrDetl).Size = new Size(143, 37);
		((Control)btnLdrDetl).TabIndex = 6;
		btnLdrDetl.Text = "Dhran Isu Rec";
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
		((Control)btnLedrSum).Location = new Point(100, 113);
		((Control)btnLedrSum).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLedrSum).Name = "btnLedrSum";
		((Control)btnLedrSum).Size = new Size(143, 37);
		((Control)btnLedrSum).TabIndex = 5;
		btnLedrSum.Text = "Rec Dhiran";
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
		((Control)BtnCrList).Location = new Point(434, 113);
		((Control)BtnCrList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnCrList).Name = "BtnCrList";
		((Control)BtnCrList).Size = new Size(143, 37);
		((Control)BtnCrList).TabIndex = 4;
		BtnCrList.Text = "Panding Dhiran";
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
		((Control)BtnDrList).Location = new Point(344, 60);
		((Control)BtnDrList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDrList).Name = "BtnDrList";
		((Control)BtnDrList).Size = new Size(143, 37);
		((Control)BtnDrList).TabIndex = 3;
		BtnDrList.Text = "Dhiran Reg";
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
		((Control)BtnGroupWise).Location = new Point(182, 60);
		((Control)BtnGroupWise).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroupWise).Name = "BtnGroupWise";
		((Control)BtnGroupWise).Size = new Size(143, 37);
		((Control)BtnGroupWise).TabIndex = 0;
		BtnGroupWise.Text = "Khatavahi";
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
		((Control)btnWithRef).Location = new Point(102, 11);
		((Control)btnWithRef).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWithRef).Name = "btnWithRef";
		((Control)btnWithRef).Size = new Size(143, 37);
		((Control)btnWithRef).TabIndex = 1;
		btnWithRef.Text = "Form - 8";
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
		((Control)btnAreaWise).Location = new Point(266, 11);
		((Control)btnAreaWise).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAreaWise).Name = "btnAreaWise";
		((Control)btnAreaWise).Size = new Size(143, 37);
		((Control)btnAreaWise).TabIndex = 2;
		btnAreaWise.Text = "Form - 12";
		cboPacket.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboPacket).Font = new Font("Tahoma", 9f);
		((ListControl)cboPacket).FormattingEnabled = true;
		((Control)cboPacket).Location = new Point(475, 239);
		((Control)cboPacket).Name = "cboPacket";
		((Control)cboPacket).Size = new Size(180, 22);
		((Control)cboPacket).TabIndex = 8;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(370, 240);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(99, 20);
		((Control)Label5).TabIndex = 1174;
		Label5.Text = "Packet No";
		Label5.TextAlign = (ContentAlignment)64;
		cboLoanType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboLoanType).Font = new Font("Tahoma", 9f);
		((ListControl)cboLoanType).FormattingEnabled = true;
		((Control)cboLoanType).Location = new Point(475, 267);
		((Control)cboLoanType).Name = "cboLoanType";
		((Control)cboLoanType).Size = new Size(180, 22);
		((Control)cboLoanType).TabIndex = 1282;
		((Control)lblLoanType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLoanType).ForeColor = Color.Black;
		lblLoanType.ImeMode = (ImeMode)0;
		((Control)lblLoanType).Location = new Point(401, 268);
		((Control)lblLoanType).Name = "lblLoanType";
		((Control)lblLoanType).Size = new Size(70, 20);
		((Control)lblLoanType).TabIndex = 1283;
		lblLoanType.Text = "Loan Type";
		lblLoanType.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tRefNo).BackColor = Color.White;
		((Control)tRefNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefNo).Location = new Point(727, 212);
		((TextBoxBase)tRefNo).MaxLength = 8;
		((Control)tRefNo).Name = "tRefNo";
		((Control)tRefNo).Size = new Size(112, 23);
		((Control)tRefNo).TabIndex = 1284;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(661, 213);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(60, 20);
		((Control)Label4).TabIndex = 1285;
		Label4.Text = "Ref No";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tCustName).BackColor = Color.White;
		((Control)tCustName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCustName).Location = new Point(661, 241);
		((TextBoxBase)tCustName).MaxLength = 50;
		((Control)tCustName).Name = "tCustName";
		((Control)tCustName).Size = new Size(178, 23);
		((Control)tCustName).TabIndex = 1286;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tCustName);
		((Control)this).Controls.Add((Control)(object)tRefNo);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)cboLoanType);
		((Control)this).Controls.Add((Control)(object)lblLoanType);
		((Control)this).Controls.Add((Control)(object)PanelDhrn);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboPacket);
		((Control)this).Controls.Add((Control)(object)Label5);
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
		((Control)this).Name = "RP_DHRN_LOAN";
		((Form)this).Text = "Dhiran Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mToDt.Properties).EndInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mFromDt.Properties).EndInit();
		((Control)PanelDhrn).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_DHRN_LOAN_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Expected O, but got Unknown
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Expected O, but got Unknown
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_0a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)PanelDhrn).Controls)
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
				((Control)PanelDhrn).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelDhrn = PanelDhrn;
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelDhrn).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj9 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj10 = lblBook;
				object? obj11 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj10).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				Panel panelDhrn2 = PanelDhrn;
				object? obj13 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelDhrn2).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tLcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tLcCode).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is SearchControl || val3 is DateEdit || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
			DC_Main.RsQry = "SELECT PACKET_NO FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY PACKET_NO ORDER BY PACKET_NO ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboPacket.Items.Clear();
				cboPacket.Items.Add((object)"");
				int num6 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num6)
				{
					cboPacket.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PACKET_NO"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboPacket.Items.Add((object)"");
			}
			if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
			{
				BtnDrList.Text = "Loan Reg";
				BtnCrList.Text = "Panding Loan";
				btnLedrSum.Text = "Loan Isue";
				btnLdrDetl.Text = "Party Packet";
				((Control)btnWithRef).Visible = false;
				((Control)btnAreaWise).Visible = false;
				((Control)btnLdrWeight).Visible = false;
			}
			else
			{
				((Control)tCustName).Visible = false;
				lblLoanType.Text = "Dhrn Type";
			}
			DC_Main.RsQry = "UPDATE A SET A.DHRN_REC_AMT = B.DhrnRec, A.UNCHAK_DHRN_REC = B.UnchakRec FROM DHRN_ISU_DATA AS A  INNER JOIN(Select CO_CODE, ISU_LC, ISU_YRCD, ISU_DBCD, ISU_NO, SUM(DHRN_REC_AMT) As DhrnRec, SUM(UNCHAK_DHRN_REC) As UnchakRec  FROM DHRN_DATA GROUP BY CO_CODE, ISU_LC, ISU_YRCD, ISU_DBCD, ISU_NO) As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ISU_LC  And A.CO_YEAR = B.ISU_YRCD And A.CO_BOOK = B.ISU_DBCD And A.VCH_NO = B.ISU_NO And A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			cboLoanType.Items.Add((object)"Amount");
			cboLoanType.Items.Add((object)"Gold");
			cboLoanType.Items.Add((object)"Silver");
			cboLoanType.SelectedIndex = 0;
			mFromDt.EditValue = "01/04/2010";
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
		cboLoanType.SelectedIndex = 0;
		MainUser = DC_Main.MCo_User;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_DHRN_LOAN_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_DHRN_LOAN_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_DHRN_LOAN_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_DHRN_LOAN_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_BOOK = '999'");
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

	private void cboPacket_KeyDown(object sender, KeyEventArgs e)
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
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhrnKhataVahi.RPT";
		Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr[(short)0] = "RptTitel = 'LOAN KHATAVAHI REPORT FROM DATE " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'DHIRAN KHATAVAHI REPORT FROM DATE " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		}
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void tRefAc_TextChanged(object sender, EventArgs e)
	{
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
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
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

	private void btnWithRef_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\Form8.RPT";
		Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_ISU_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_ISU_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnAreaWise_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\Form12.RPT";
		Cr.SelectionFormula = "{DHRN_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnDrList_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhiranReg.RPT";
		Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_ISU_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_ISU_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnCrList_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhrnKhataVahiSumm.RPT";
		Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "'  AND {DHRN_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr[(short)0] = "RptTitel = 'PANDING LOAN REPORT AS ON DATE " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		}
		else
		{
			Cr[(short)0] = "RptTitel = 'PANDING DHIRAN REPORT AS ON DATE " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		}
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnLedrSum_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		string text = "D";
		text = ((Operators.CompareString(CurRpt, "Loan Report", false) != 0) ? "D" : "L");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_BOOK = '999'");
		DC_Main.RsQry = "SELECT * FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.DHRN_AMT,A.VCH_DATE,A.AC_CODE,SUM(B.DHRN_REC_AMT) As DhrnRec,SUM(B.INT_AMT) As IntAmt,SUM(B.INT_REC_AMT) As IntRec,A.LOAN_TYPE FROM DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON  A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ENTRY_TYPE = '" + text + "' GROUP BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.DHRN_AMT,A.VCH_DATE,A.AC_CODE,A.LOAN_TYPE  HAVING SUM(B.DHRN_REC_AMT) <> 0 ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 1;
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_DATE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.X]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"]), (object)"' ORDER BY VCH_DATE DESC"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DateTime dateTime = ((dataTable.Rows.Count <= 0) ? Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]) : Conversions.ToDate(dataTable.Rows[0]["VCH_DATE"]));
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,AC_CODE,DHRN_AMT,DHRN_REC_AMT,INT_AMT,INT_REC_AMT,REC_DATE,LOAN_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), DC_Main.Rshlp.Rows[DC_Main.X]["CO_YEAR"]), (object)"','999','"), DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"]), (object)"',"), (object)DC_Main.X), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "MM/dd/yyyy")), (object)"',"), (object)" '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"',"), DC_Main.Rshlp.Rows[DC_Main.X]["DHRN_AMT"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.X]["DhrnRec"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.X]["IntAmt"]), (object)","), DC_Main.Rshlp.Rows[DC_Main.X]["IntRec"]), (object)",'"), (object)Strings.Format((object)dateTime, "MM/dd/yyyy")), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.X]["LOAN_TYPE"]), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhrnReceivedSumm.RPT";
			Cr.SelectionFormula = "{DHRN_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_DATA.CO_BOOK} = '999' AND {DHRN_DATA.REC_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_DATA.REC_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboPacket.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
			}
			if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
			{
				Cr[(short)0] = "RptTitel = 'LOAN RECEIVED SUMMARY REPORT AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'DHIRAN RECEIVED SUMMARY REPORT AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void btnLdrDetl_Click(object sender, EventArgs e)
	{
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Invalid comparison between Unknown and I4
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Invalid comparison between Unknown and I4
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LoanWisePacket.RPT";
			Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "'  AND {DHRN_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
			DialogResult val = MessageBox.Show("Only Panding Packet Display = Yes Only Isu Packet = No Or All Packet = Cancel", "caption", (MessageBoxButtons)3);
			if ((int)val == 6)
			{
				Cr[(short)1] = "IsuRec = 'N'";
			}
			else if ((int)val == 7)
			{
				Cr[(short)1] = "IsuRec = 'Y'";
			}
			else
			{
				Cr[(short)1] = "IsuRec = ''";
			}
			if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
			{
				Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'L'";
			}
			else
			{
				Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'D'";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(tRefNo.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
			}
			if (Operators.CompareString(tCustName.Text, "", false) != 0)
			{
				Cr[(short)2] = "CustName = '" + tCustName.Text + "'";
			}
			Cr[(short)0] = "RptTitel = 'LOAN WISE CUSTOMER PACKET REPORT FROM DATE " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhiranIssuRec.RPT";
			Cr.SelectionFormula = "{DHRN_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
			if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
			{
				Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'L'";
			}
			else
			{
				Cr.SelectionFormula += " And {DHRN_DATA.ENTRY_TYPE} = 'D'";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboPacket.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
			}
			Cr[(short)0] = "RptTitel = 'DHIRAN ISSUE RECEIPET REPORT FROM DATE " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		}
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void btnLdrWeight_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		DC_Main.ExeQuteDc("UPDATE DHRN_ISU_DATA SET  DHRN_REC_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
		DC_Main.RsQry = "SELECT A.CO_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO ,SUM(A.DHRN_REC_AMT) AS DhrnRec FROM DHRN_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.CO_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO ORDER BY A.CO_CODE,A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE DHRN_ISU_DATA SET  DHRN_REC_AMT = DHRN_REC_AMT + ", DC_Main.Rshlp.Rows[DC_Main.X]["DhrnRec"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.X]["ISU_YRCD"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.X]["ISU_DBCD"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.X]["ISU_NO"]), (object)"' ")));
				DC_Main.X++;
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhiranitemRpt.RPT";
			Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_ISU_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_ISU_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
			if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
			{
				Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'L'";
			}
			else
			{
				Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'D'";
			}
			if (Operators.CompareString(tLcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
			}
			if (Operators.CompareString(tRefAc.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(cboPacket.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
			}
			if (Operators.CompareString(tRefNo.Text, "", false) != 0)
			{
				Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
			}
			if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
			{
				Cr[(short)0] = "RptTitel = 'MULTI TIME LOAN REC FROM DATE " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			else
			{
				Cr[(short)0] = "RptTitel = 'MULTI TIME DHRN ISU FROM DATE " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			}
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
		}
	}

	private void BtnGold_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LoanStock.RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhiranStock.RPT";
		}
		Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_ISU_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_ISU_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# and {ITEM_MAST.IT_TYPE} = 'G' AND  ({DHRN_ISU_DATA.DHRN_AMT}-{DHRN_ISU_DATA.DHRN_REC_AMT}) > 0 ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'DHIRAN GOLD STOCK FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnSilver_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LoanStock.RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhiranStock.RPT";
		}
		Cr.SelectionFormula = "{DHRN_ISU_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_ISU_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "# AND {DHRN_ISU_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# and {ITEM_MAST.IT_TYPE} = 'S' AND  ({DHRN_ISU_DATA.DHRN_AMT}-{DHRN_ISU_DATA.DHRN_REC_AMT}) > 0 ";
		Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LOAN_TYPE} = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'";
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'L'";
		}
		else
		{
			Cr.SelectionFormula += " And {DHRN_ISU_DATA.ENTRY_TYPE} = 'D'";
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_REF_CODE} = '" + tRefAc.Text + "'";
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.AC_CODE} = '" + tAcCode.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_CITY} = '" + cboCity.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {AC_MAST.AC_AREA} = '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboPacket.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.PACKET_NO} = '" + cboPacket.Text + "'";
		}
		if (Operators.CompareString(tRefNo.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {DHRN_ISU_DATA.DHRN_BILL} = '" + tRefNo.Text + "'";
		}
		Cr[(short)0] = "RptTitel = 'DHIRAN SILVER STOCK FROM " + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void tRefNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.DHRN_BILL As RefNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.VCH_NO As VchNoL,B.AC_NAME As PartyNameL,A.AC_NAME As VchNameL FROM DHRN_ISU_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' and A.DHRN_BILL <> '' AND A.ENTRY_TYPE = 'L' GROUP BY A.DHRN_BILL,A.VCH_DATE,A.VCH_NO,B.AC_NAME,A.AC_NAME ORDER BY A.VCH_DATE,A.VCH_NO";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.DHRN_BILL As RefNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.VCH_NO As VchNoL,B.AC_NAME As PartyNameL,A.AC_NAME As VchNameL FROM DHRN_ISU_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' and A.DHRN_BILL <> '' AND A.ENTRY_TYPE = 'D' GROUP BY A.DHRN_BILL,A.VCH_DATE,A.VCH_NO,B.AC_NAME,A.AC_NAME ORDER BY A.VCH_DATE,A.VCH_NO";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 250.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tRefNo.Text = DC_Main.ColValue[0];
				((Control)tRefNo).Focus();
			}
			else
			{
				((Control)tRefNo).Focus();
			}
		}
	}

	private void tCustName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Loan Report", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.CUST_NAME As CustNameL,A.PACKET_NO As PacketNoL,B.AC_NAME As PartyNameL,A.VCH_NO As LoanNoL FROM DHRN_ISU_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ENTRY_TYPE = 'L' GROUP BY A.CUST_NAME,A.PACKET_NO,B.AC_NAME,A.VCH_NO ORDER BY A.CUST_NAME,B.AC_NAME";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 250.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tCustName.Text = DC_Main.ColValue[0];
				((Control)tCustName).Focus();
			}
			else
			{
				((Control)tCustName).Focus();
			}
		}
	}
}
