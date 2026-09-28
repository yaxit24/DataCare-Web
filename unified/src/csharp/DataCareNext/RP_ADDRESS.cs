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
public class RP_ADDRESS : Form
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
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcGroup")]
	private TextBox _tAcGroup;

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
	[AccessedThroughProperty("Btn2Add")]
	private QButton _Btn2Add;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPhBook")]
	private QButton _BtnPhBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Btn3Add")]
	private QButton _Btn3Add;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CboAddType")]
	private ComboBox _CboAddType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkAcSelect")]
	private CheckBox _chkAcSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mAnDate")]
	private MaskedTextBox _mAnDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mBhDate")]
	private MaskedTextBox _mBhDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToBDate")]
	private MaskedTextBox _mToBDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearchText")]
	private TextBox _tSearchText;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string TblData;

	private string ScelectAc;

	private int ColNumber;

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
			EventHandler eventHandler = TAcGroup_TextChanged;
			TextBox val2 = _tAcGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tAcGroup = value;
			val2 = _tAcGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual QButton Btn2Add
	{
		[CompilerGenerated]
		get
		{
			return _Btn2Add;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Btn2Add_Click;
			QButton val = _Btn2Add;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Btn2Add = value;
			val = _Btn2Add;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnPhBook
	{
		[CompilerGenerated]
		get
		{
			return _BtnPhBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPhBook_Click;
			QButton val = _BtnPhBook;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPhBook = value;
			val = _BtnPhBook;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton Btn3Add
	{
		[CompilerGenerated]
		get
		{
			return _Btn3Add;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Btn3Add_Click;
			QButton val = _Btn3Add;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Btn3Add = value;
			val = _Btn3Add;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual ComboBox CboAddType
	{
		[CompilerGenerated]
		get
		{
			return _CboAddType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CboAddType_SelectedIndexChanged;
			ComboBox val = _CboAddType;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_CboAddType = value;
			val = _CboAddType;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
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
	[AccessedThroughProperty("cboDistrict")]
	private virtual ComboBox _cboDistrict;

	internal virtual ComboBox cboDistrict
	{
		get
		{
			return _cboDistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDistrict = value;
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
	[AccessedThroughProperty("cboAdd1")]
	private virtual ComboBox _cboAdd1;

	internal virtual ComboBox cboAdd1
	{
		get
		{
			return _cboAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAdd1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboA")]
	private virtual Label _cboA;

	internal virtual Label cboA
	{
		get
		{
			return _cboA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboA = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAdd3")]
	private virtual ComboBox _cboAdd3;

	internal virtual ComboBox cboAdd3
	{
		get
		{
			return _cboAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAdd3 = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private virtual TextBox _tMobile;

	internal virtual TextBox tMobile
	{
		get
		{
			return _tMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMoNo")]
	private virtual Label _lblMoNo;

	internal virtual Label lblMoNo
	{
		get
		{
			return _lblMoNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMoNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone")]
	private virtual TextBox _tPhone;

	internal virtual TextBox tPhone
	{
		get
		{
			return _tPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPhone = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPhone")]
	private virtual Label _lblPhone;

	internal virtual Label lblPhone
	{
		get
		{
			return _lblPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPhone = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSkipLbl")]
	private virtual TextBox _nSkipLbl;

	internal virtual TextBox nSkipLbl
	{
		get
		{
			return _nSkipLbl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nSkipLbl = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCustGroup")]
	private virtual ComboBox _cboCustGroup;

	internal virtual ComboBox cboCustGroup
	{
		get
		{
			return _cboCustGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCustGroup = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPartyName")]
	private virtual ComboBox _cboPartyName;

	internal virtual ComboBox cboPartyName
	{
		get
		{
			return _cboPartyName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPartyName = value;
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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
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
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual MaskedTextBox mAnDate
	{
		[CompilerGenerated]
		get
		{
			return _mAnDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mAnDate_KeyDown);
			MaskedTextBox val2 = _mAnDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mAnDate = value;
			val2 = _mAnDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mBhDate
	{
		[CompilerGenerated]
		get
		{
			return _mBhDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mBhDate_KeyDown);
			MaskedTextBox val2 = _mBhDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mBhDate = value;
			val2 = _mBhDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mToBDate
	{
		[CompilerGenerated]
		get
		{
			return _mToBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mToBDate_KeyDown);
			EventHandler eventHandler = mToBDate_GotFocus;
			MaskedTextBox val2 = _mToBDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mToBDate = value;
			val2 = _mToBDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
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

	internal virtual TextBox tSearchText
	{
		[CompilerGenerated]
		get
		{
			return _tSearchText;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TSearchText_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tSearchText_KeyDown);
			TextBox val2 = _tSearchText;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tSearchText = value;
			val2 = _tSearchText;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAcType")]
	private virtual ComboBox _cboAcType;

	internal virtual ComboBox cboAcType
	{
		get
		{
			return _cboAcType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAcType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAcType")]
	private virtual Label _lblAcType;

	internal virtual Label lblAcType
	{
		get
		{
			return _lblAcType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAcType = value;
		}
	}

	public RP_ADDRESS()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_ADDRESS_Load;
		((Form)this).Deactivate += RP_ADDRESS_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_ADDRESS_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_ADDRESS_KeyDown);
		((Form)this).Closed += RP_ADDRESS_Closed;
		ColNumber = 0;
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
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Expected O, but got Unknown
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Expected O, but got Unknown
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected O, but got Unknown
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_094c: Expected O, but got Unknown
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Expected O, but got Unknown
		//IL_0a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Expected O, but got Unknown
		//IL_0b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0beb: Expected O, but got Unknown
		//IL_0c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7c: Expected O, but got Unknown
		//IL_0d30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3a: Expected O, but got Unknown
		//IL_0dee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df8: Expected O, but got Unknown
		//IL_0e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7f: Expected O, but got Unknown
		//IL_0f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0e: Expected O, but got Unknown
		//IL_0fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe4: Expected O, but got Unknown
		//IL_1072: Unknown result type (might be due to invalid IL or missing references)
		//IL_107c: Expected O, but got Unknown
		//IL_114b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1155: Expected O, but got Unknown
		//IL_11e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Expected O, but got Unknown
		//IL_12a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Expected O, but got Unknown
		//IL_1329: Unknown result type (might be due to invalid IL or missing references)
		//IL_1333: Expected O, but got Unknown
		//IL_13b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c1: Expected O, but got Unknown
		//IL_1707: Unknown result type (might be due to invalid IL or missing references)
		//IL_172b: Unknown result type (might be due to invalid IL or missing references)
		//IL_174f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1773: Unknown result type (might be due to invalid IL or missing references)
		//IL_179c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a6: Expected O, but got Unknown
		//IL_17c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac7: Expected O, but got Unknown
		//IL_1ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1deb: Expected O, but got Unknown
		//IL_1e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb7: Expected O, but got Unknown
		//IL_1f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3e: Expected O, but got Unknown
		//IL_1fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff9: Expected O, but got Unknown
		//IL_20b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c1: Expected O, but got Unknown
		//IL_2150: Unknown result type (might be due to invalid IL or missing references)
		//IL_215a: Expected O, but got Unknown
		//IL_2218: Unknown result type (might be due to invalid IL or missing references)
		//IL_2222: Expected O, but got Unknown
		//IL_22b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ba: Expected O, but got Unknown
		//IL_2378: Unknown result type (might be due to invalid IL or missing references)
		//IL_2382: Expected O, but got Unknown
		//IL_2411: Unknown result type (might be due to invalid IL or missing references)
		//IL_241b: Expected O, but got Unknown
		//IL_24d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e3: Expected O, but got Unknown
		//IL_2572: Unknown result type (might be due to invalid IL or missing references)
		//IL_257c: Expected O, but got Unknown
		//IL_262d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2637: Expected O, but got Unknown
		//IL_265a: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d5: Expected O, but got Unknown
		//IL_2786: Unknown result type (might be due to invalid IL or missing references)
		//IL_2790: Expected O, but got Unknown
		//IL_27b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2824: Unknown result type (might be due to invalid IL or missing references)
		//IL_282e: Expected O, but got Unknown
		//IL_28df: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e9: Expected O, but got Unknown
		//IL_290c: Unknown result type (might be due to invalid IL or missing references)
		//IL_298a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2994: Expected O, but got Unknown
		//IL_2a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a5c: Expected O, but got Unknown
		//IL_2aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af5: Expected O, but got Unknown
		//IL_2bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bbd: Expected O, but got Unknown
		//IL_2c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c56: Expected O, but got Unknown
		//IL_2d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d14: Expected O, but got Unknown
		//IL_2ea6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb0: Expected O, but got Unknown
		//IL_3125: Unknown result type (might be due to invalid IL or missing references)
		//IL_3149: Unknown result type (might be due to invalid IL or missing references)
		//IL_316d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3191: Unknown result type (might be due to invalid IL or missing references)
		//IL_31ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c4: Expected O, but got Unknown
		//IL_31ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_3281: Unknown result type (might be due to invalid IL or missing references)
		//IL_328b: Expected O, but got Unknown
		//IL_3320: Unknown result type (might be due to invalid IL or missing references)
		//IL_332a: Expected O, but got Unknown
		//IL_33a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_33b2: Expected O, but got Unknown
		//IL_3487: Unknown result type (might be due to invalid IL or missing references)
		//IL_3491: Expected O, but got Unknown
		//IL_34fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3504: Expected O, but got Unknown
		//IL_35b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c1: Expected O, but got Unknown
		//IL_365b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3665: Expected O, but got Unknown
		//IL_36ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3709: Expected O, but got Unknown
		//IL_37a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ad: Expected O, but got Unknown
		//IL_388b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3895: Expected O, but got Unknown
		//IL_3913: Unknown result type (might be due to invalid IL or missing references)
		//IL_391d: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_ADDRESS));
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
		tAcGroup = new TextBox();
		tAcGrName = new TextBox();
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
		Btn2Add = new QButton();
		BtnPhBook = new QButton();
		Btn3Add = new QButton();
		CboAddType = new ComboBox();
		Label4 = new Label();
		Label7 = new Label();
		cboState = new ComboBox();
		Label5 = new Label();
		cboDistrict = new ComboBox();
		Label8 = new Label();
		cboAdd1 = new ComboBox();
		cboA = new Label();
		cboAdd3 = new ComboBox();
		Label10 = new Label();
		tMobile = new TextBox();
		lblMoNo = new Label();
		tPhone = new TextBox();
		lblPhone = new Label();
		nSkipLbl = new TextBox();
		Label9 = new Label();
		cboCustGroup = new ComboBox();
		Label11 = new Label();
		cboPartyName = new ComboBox();
		Label12 = new Label();
		chkAcSelect = new CheckBox();
		PnlAc = new Panel();
		tSearchText = new TextBox();
		btnOk = new QButton();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		mAnDate = new MaskedTextBox();
		mBhDate = new MaskedTextBox();
		mToBDate = new MaskedTextBox();
		Label13 = new Label();
		cboAcType = new ComboBox();
		lblAcType = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)PanelDhrn).SuspendLayout();
		((Control)PnlAc).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
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
		((Control)PnlBotam).TabIndex = 15;
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
		((Control)BtnCancel).TabIndex = 0;
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
		((Control)BtnPrint).TabIndex = 2;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(793, 3);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 5;
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(192, 0, 0);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 16;
		lblBook.Text = "Address Print";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcGroup).BackColor = Color.White;
		((Control)tAcGroup).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcGroup).Location = new Point(475, 134);
		((TextBoxBase)tAcGroup).MaxLength = 8;
		((Control)tAcGroup).Name = "tAcGroup";
		((Control)tAcGroup).Size = new Size(76, 23);
		((Control)tAcGroup).TabIndex = 3;
		((TextBoxBase)tAcGrName).BackColor = Color.White;
		((Control)tAcGrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcGrName).Location = new Point(557, 135);
		((TextBoxBase)tAcGrName).MaxLength = 8;
		((Control)tAcGrName).Name = "tAcGrName";
		((Control)tAcGrName).Size = new Size(282, 23);
		((Control)tAcGrName).TabIndex = 1161;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(349, 136);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(119, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Ac Group";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(364, 166);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "Birth Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(475, 106);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(557, 106);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1164;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(377, 106);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(91, 20);
		((Control)Label3).TabIndex = 1165;
		Label3.Text = "Party Code";
		Label3.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = SystemColors.Window;
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(475, 220);
		cboCity.MaxLength = 30;
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(270, 22);
		((Control)cboCity).TabIndex = 8;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(409, 219);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(58, 19);
		((Control)lblCity).TabIndex = 1166;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = SystemColors.Window;
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(475, 248);
		cboArea.MaxLength = 30;
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(270, 22);
		((Control)cboArea).TabIndex = 9;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(420, 249);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(47, 19);
		((Control)Label17).TabIndex = 1168;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(475, 78);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(76, 23);
		((Control)tLcCode).TabIndex = 1;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(557, 77);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(282, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(408, 78);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "Lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)PanelDhrn).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelDhrn).Controls.Add((Control)(object)Btn2Add);
		((Control)PanelDhrn).Controls.Add((Control)(object)BtnPhBook);
		((Control)PanelDhrn).Controls.Add((Control)(object)Btn3Add);
		((Control)PanelDhrn).Location = new Point(300, 473);
		((Control)PanelDhrn).Name = "PanelDhrn";
		((Control)PanelDhrn).Size = new Size(568, 49);
		((Control)PanelDhrn).TabIndex = 17;
		((QControl)Btn2Add).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)Btn2Add).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)Btn2Add).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)Btn2Add).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)Btn2Add).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)Btn2Add).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)Btn2Add).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)Btn2Add).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)Btn2Add).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)Btn2Add).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)Btn2Add).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)Btn2Add).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)Btn2Add).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)Btn2Add).ColorScheme).InheritCurrentThemeFromGlobal = false;
		Btn2Add.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn2Add.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn2Add.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn2Add.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn2Add.Image = null;
		((QControl)Btn2Add).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)Btn2Add).Location = new Point(30, 6);
		((Control)Btn2Add).Margin = new Padding(3, 6, 3, 6);
		((Control)Btn2Add).Name = "Btn2Add";
		((Control)Btn2Add).Size = new Size(143, 37);
		((Control)Btn2Add).TabIndex = 0;
		Btn2Add.Text = "2 Address";
		((QControl)BtnPhBook).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnPhBook).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnPhBook).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnPhBook).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnPhBook).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnPhBook).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnPhBook).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnPhBook).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnPhBook).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnPhBook).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnPhBook).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnPhBook).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnPhBook).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnPhBook).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnPhBook.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPhBook.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPhBook.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPhBook.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPhBook.Image = null;
		((QControl)BtnPhBook).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnPhBook).Location = new Point(213, 6);
		((Control)BtnPhBook).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnPhBook).Name = "BtnPhBook";
		((Control)BtnPhBook).Size = new Size(143, 37);
		((Control)BtnPhBook).TabIndex = 1;
		BtnPhBook.Text = "Phone Book";
		((QControl)Btn3Add).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)Btn3Add).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)Btn3Add).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)Btn3Add).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)Btn3Add).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)Btn3Add).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)Btn3Add).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)Btn3Add).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)Btn3Add).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)Btn3Add).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)Btn3Add).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)Btn3Add).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)Btn3Add).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)Btn3Add).ColorScheme).InheritCurrentThemeFromGlobal = false;
		Btn3Add.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn3Add.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn3Add.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn3Add.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btn3Add.Image = null;
		((QControl)Btn3Add).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)Btn3Add).Location = new Point(397, 6);
		((Control)Btn3Add).Margin = new Padding(3, 6, 3, 6);
		((Control)Btn3Add).Name = "Btn3Add";
		((Control)Btn3Add).Size = new Size(143, 37);
		((Control)Btn3Add).TabIndex = 2;
		Btn3Add.Text = "3 Address";
		CboAddType.AutoCompleteMode = (AutoCompleteMode)3;
		CboAddType.AutoCompleteSource = (AutoCompleteSource)256;
		CboAddType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)CboAddType).Font = new Font("Tahoma", 9f);
		((ListControl)CboAddType).FormattingEnabled = true;
		((Control)CboAddType).Location = new Point(474, 50);
		((Control)CboAddType).Name = "CboAddType";
		((Control)CboAddType).Size = new Size(159, 22);
		((Control)CboAddType).TabIndex = 0;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(365, 49);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(101, 19);
		((Control)Label4).TabIndex = 1182;
		Label4.Text = "Address Type";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(689, 165);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(65, 20);
		((Control)Label7).TabIndex = 1184;
		Label7.Text = "Anv Date";
		Label7.TextAlign = (ContentAlignment)64;
		cboState.AutoCompleteMode = (AutoCompleteMode)3;
		cboState.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboState).Font = new Font("Tahoma", 9f);
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Location = new Point(475, 276);
		cboState.MaxLength = 30;
		((Control)cboState).Name = "cboState";
		((Control)cboState).Size = new Size(270, 22);
		((Control)cboState).TabIndex = 10;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(376, 277);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(92, 19);
		((Control)Label5).TabIndex = 1186;
		Label5.Text = "State";
		Label5.TextAlign = (ContentAlignment)64;
		cboDistrict.AutoCompleteMode = (AutoCompleteMode)3;
		cboDistrict.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDistrict).Font = new Font("Tahoma", 9f);
		((ListControl)cboDistrict).FormattingEnabled = true;
		((Control)cboDistrict).Location = new Point(474, 192);
		cboDistrict.MaxLength = 30;
		((Control)cboDistrict).Name = "cboDistrict";
		((Control)cboDistrict).Size = new Size(271, 22);
		((Control)cboDistrict).TabIndex = 7;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(374, 193);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(92, 19);
		((Control)Label8).TabIndex = 1188;
		Label8.Text = "District";
		Label8.TextAlign = (ContentAlignment)64;
		cboAdd1.AutoCompleteMode = (AutoCompleteMode)3;
		cboAdd1.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboAdd1).Font = new Font("Tahoma", 9f);
		((ListControl)cboAdd1).FormattingEnabled = true;
		((Control)cboAdd1).Location = new Point(475, 304);
		cboAdd1.MaxLength = 50;
		((Control)cboAdd1).Name = "cboAdd1";
		((Control)cboAdd1).Size = new Size(270, 22);
		((Control)cboAdd1).TabIndex = 11;
		((Control)cboA).BackColor = Color.Transparent;
		((Control)cboA).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)cboA).ForeColor = Color.Black;
		cboA.ImeMode = (ImeMode)0;
		((Control)cboA).Location = new Point(376, 305);
		((Control)cboA).Name = "cboA";
		((Control)cboA).Size = new Size(92, 19);
		((Control)cboA).TabIndex = 1190;
		cboA.Text = "Address 1";
		cboA.TextAlign = (ContentAlignment)64;
		cboAdd3.AutoCompleteMode = (AutoCompleteMode)3;
		cboAdd3.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboAdd3).Font = new Font("Tahoma", 9f);
		((ListControl)cboAdd3).FormattingEnabled = true;
		((Control)cboAdd3).Location = new Point(475, 332);
		cboAdd3.MaxLength = 50;
		((Control)cboAdd3).Name = "cboAdd3";
		((Control)cboAdd3).Size = new Size(270, 22);
		((Control)cboAdd3).TabIndex = 12;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(376, 333);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(92, 19);
		((Control)Label10).TabIndex = 1192;
		Label10.Text = "Address 3";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobile).BackColor = Color.White;
		((Control)tMobile).Font = new Font("Tahoma", 9f);
		((Control)tMobile).Location = new Point(475, 414);
		((Control)tMobile).Margin = new Padding(2);
		((TextBoxBase)tMobile).MaxLength = 15;
		((Control)tMobile).Name = "tMobile";
		((Control)tMobile).Size = new Size(158, 22);
		((Control)tMobile).TabIndex = 15;
		((Control)lblMoNo).BackColor = Color.Transparent;
		((Control)lblMoNo).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblMoNo).ForeColor = Color.Black;
		lblMoNo.ImeMode = (ImeMode)0;
		((Control)lblMoNo).Location = new Point(376, 413);
		((Control)lblMoNo).Name = "lblMoNo";
		((Control)lblMoNo).Size = new Size(92, 19);
		((Control)lblMoNo).TabIndex = 1196;
		lblMoNo.Text = "Mobile No";
		lblMoNo.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPhone).BackColor = Color.White;
		((Control)tPhone).Font = new Font("Tahoma", 9f);
		((Control)tPhone).Location = new Point(475, 441);
		((Control)tPhone).Margin = new Padding(2);
		((TextBoxBase)tPhone).MaxLength = 15;
		((Control)tPhone).Name = "tPhone";
		((Control)tPhone).Size = new Size(158, 22);
		((Control)tPhone).TabIndex = 16;
		((Control)lblPhone).BackColor = Color.Transparent;
		((Control)lblPhone).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblPhone).ForeColor = Color.Black;
		lblPhone.ImeMode = (ImeMode)0;
		((Control)lblPhone).Location = new Point(390, 439);
		((Control)lblPhone).Name = "lblPhone";
		((Control)lblPhone).Size = new Size(77, 19);
		((Control)lblPhone).TabIndex = 1195;
		lblPhone.Text = "Phone No";
		lblPhone.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nSkipLbl).BackColor = Color.White;
		((Control)nSkipLbl).Font = new Font("Tahoma", 9f);
		((Control)nSkipLbl).Location = new Point(706, 442);
		((Control)nSkipLbl).Margin = new Padding(2);
		((TextBoxBase)nSkipLbl).MaxLength = 15;
		((Control)nSkipLbl).Name = "nSkipLbl";
		((Control)nSkipLbl).Size = new Size(39, 22);
		((Control)nSkipLbl).TabIndex = 1197;
		nSkipLbl.TextAlign = (HorizontalAlignment)2;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(638, 442);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(63, 19);
		((Control)Label9).TabIndex = 1198;
		Label9.Text = "Skip Lbl";
		Label9.TextAlign = (ContentAlignment)64;
		cboCustGroup.AutoCompleteMode = (AutoCompleteMode)3;
		cboCustGroup.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCustGroup).Font = new Font("Tahoma", 9f);
		((ListControl)cboCustGroup).FormattingEnabled = true;
		((Control)cboCustGroup).Location = new Point(475, 360);
		cboCustGroup.MaxLength = 20;
		((Control)cboCustGroup).Name = "cboCustGroup";
		((Control)cboCustGroup).Size = new Size(270, 22);
		((Control)cboCustGroup).TabIndex = 13;
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(376, 361);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(92, 19);
		((Control)Label11).TabIndex = 1200;
		Label11.Text = "Cust Group";
		Label11.TextAlign = (ContentAlignment)64;
		cboPartyName.AutoCompleteMode = (AutoCompleteMode)3;
		cboPartyName.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPartyName).Font = new Font("Tahoma", 9f);
		((ListControl)cboPartyName).FormattingEnabled = true;
		((Control)cboPartyName).Location = new Point(475, 387);
		cboPartyName.MaxLength = 50;
		((Control)cboPartyName).Name = "cboPartyName";
		((Control)cboPartyName).Size = new Size(270, 22);
		((Control)cboPartyName).TabIndex = 14;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(376, 388);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(92, 19);
		((Control)Label12).TabIndex = 1202;
		Label12.Text = "Ref By";
		Label12.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkAcSelect).BackColor = Color.Transparent;
		((Control)chkAcSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkAcSelect).ForeColor = Color.Black;
		((Control)chkAcSelect).Location = new Point(845, 106);
		((Control)chkAcSelect).Name = "chkAcSelect";
		((Control)chkAcSelect).RightToLeft = (RightToLeft)0;
		((Control)chkAcSelect).Size = new Size(141, 19);
		((Control)chkAcSelect).TabIndex = 18;
		((ButtonBase)chkAcSelect).Text = "Select Ac";
		((ButtonBase)chkAcSelect).UseVisualStyleBackColor = false;
		((Control)PnlAc).BackColor = Color.LavenderBlush;
		PnlAc.BorderStyle = (BorderStyle)1;
		((Control)PnlAc).Controls.Add((Control)(object)tSearchText);
		((Control)PnlAc).Controls.Add((Control)(object)btnOk);
		((Control)PnlAc).Controls.Add((Control)(object)DGV);
		((Control)PnlAc).Location = new Point(890, 205);
		((Control)PnlAc).Name = "PnlAc";
		((Control)PnlAc).Size = new Size(713, 302);
		((Control)PnlAc).TabIndex = 1204;
		((Control)PnlAc).Visible = false;
		((TextBoxBase)tSearchText).BackColor = Color.SeaShell;
		((TextBoxBase)tSearchText).BorderStyle = (BorderStyle)0;
		tSearchText.CharacterCasing = (CharacterCasing)1;
		((Control)tSearchText).Font = new Font("Verdana", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSearchText).ForeColor = Color.Maroon;
		((Control)tSearchText).Location = new Point(11, 252);
		((Control)tSearchText).Name = "tSearchText";
		((Control)tSearchText).Size = new Size(172, 19);
		((Control)tSearchText).TabIndex = 1158;
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
		((Control)btnOk).Location = new Point(270, 252);
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
		((TextBoxBase)mAnDate).BackColor = Color.White;
		((Control)mAnDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mAnDate).Location = new Point(763, 163);
		mAnDate.Mask = "00/00/0000";
		((Control)mAnDate).Name = "mAnDate";
		((Control)mAnDate).Size = new Size(76, 23);
		((Control)mAnDate).TabIndex = 6;
		mAnDate.ValidatingType = typeof(DateTime);
		((TextBoxBase)mBhDate).BackColor = Color.White;
		((Control)mBhDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mBhDate).Location = new Point(475, 163);
		mBhDate.Mask = "00/00/0000";
		((Control)mBhDate).Name = "mBhDate";
		((Control)mBhDate).Size = new Size(76, 23);
		((Control)mBhDate).TabIndex = 4;
		mBhDate.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToBDate).BackColor = Color.White;
		((Control)mToBDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToBDate).Location = new Point(607, 164);
		mToBDate.Mask = "00/00/0000";
		((Control)mToBDate).Name = "mToBDate";
		((Control)mToBDate).Size = new Size(76, 23);
		((Control)mToBDate).TabIndex = 5;
		mToBDate.ValidatingType = typeof(DateTime);
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(557, 166);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(44, 20);
		((Control)Label13).TabIndex = 1206;
		Label13.Text = "To Bd";
		Label13.TextAlign = (ContentAlignment)64;
		cboAcType.AutoCompleteMode = (AutoCompleteMode)3;
		cboAcType.AutoCompleteSource = (AutoCompleteSource)256;
		cboAcType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboAcType).Font = new Font("Tahoma", 9f);
		((ListControl)cboAcType).FormattingEnabled = true;
		((Control)cboAcType).Location = new Point(747, 50);
		((Control)cboAcType).Name = "cboAcType";
		((Control)cboAcType).Size = new Size(93, 22);
		((Control)cboAcType).TabIndex = 1207;
		((Control)lblAcType).BackColor = Color.Transparent;
		((Control)lblAcType).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblAcType).ForeColor = Color.Black;
		lblAcType.ImeMode = (ImeMode)0;
		((Control)lblAcType).Location = new Point(642, 49);
		((Control)lblAcType).Name = "lblAcType";
		((Control)lblAcType).Size = new Size(97, 19);
		((Control)lblAcType).TabIndex = 1208;
		lblAcType.Text = "Ac Type";
		lblAcType.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)cboAcType);
		((Control)this).Controls.Add((Control)(object)lblAcType);
		((Control)this).Controls.Add((Control)(object)PnlAc);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)mToBDate);
		((Control)this).Controls.Add((Control)(object)mAnDate);
		((Control)this).Controls.Add((Control)(object)mBhDate);
		((Control)this).Controls.Add((Control)(object)chkAcSelect);
		((Control)this).Controls.Add((Control)(object)cboPartyName);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)cboCustGroup);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nSkipLbl);
		((Control)this).Controls.Add((Control)(object)tMobile);
		((Control)this).Controls.Add((Control)(object)lblMoNo);
		((Control)this).Controls.Add((Control)(object)tPhone);
		((Control)this).Controls.Add((Control)(object)lblPhone);
		((Control)this).Controls.Add((Control)(object)cboAdd3);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)cboAdd1);
		((Control)this).Controls.Add((Control)(object)cboA);
		((Control)this).Controls.Add((Control)(object)cboDistrict);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)cboState);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)CboAddType);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)PanelDhrn);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)cboCity);
		((Control)this).Controls.Add((Control)(object)lblCity);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tAcGroup);
		((Control)this).Controls.Add((Control)(object)tAcGrName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_ADDRESS";
		((Form)this).Text = "Address Print";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)PanelDhrn).ResumeLayout(false);
		((Control)PnlAc).ResumeLayout(false);
		((Control)PnlAc).PerformLayout();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_ADDRESS_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb9: Expected O, but got Unknown
		//IL_0d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d43: Expected O, but got Unknown
		//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfe: Expected O, but got Unknown
		//IL_0e86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e95: Expected O, but got Unknown
		//IL_0f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Expected O, but got Unknown
		//IL_0fc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Expected O, but got Unknown
		//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1001: Expected O, but got Unknown
		//IL_1020: Unknown result type (might be due to invalid IL or missing references)
		//IL_1025: Unknown result type (might be due to invalid IL or missing references)
		//IL_102f: Expected O, but got Unknown
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
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelDhrn = PanelDhrn;
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelDhrn).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj10 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				ComboBox cboAddType = CboAddType;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				cboAddType.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				CheckBox obj13 = chkAcSelect;
				object? obj14 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj13).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)PnlAc).BackColor = Color.LightSlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj15 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj16 = lblBook;
				object? obj17 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj16).ForeColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj18 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				Panel panelDhrn2 = PanelDhrn;
				object? obj19 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelDhrn2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				ComboBox cboAddType2 = CboAddType;
				object? obj22 = colorConverter.ConvertFromString("Cornsilk");
				cboAddType2.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				CheckBox obj23 = chkAcSelect;
				object? obj24 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj23).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				Panel pnlAc = PnlAc;
				object? obj25 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlAc).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcCode).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
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
				num3 = (int)Math.Ceiling((double)((Control)tAcCode).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tAcCode).Font;
				try
				{
					foreach (object control6 in ((Control)PnlAc).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control7 in ((Control)PnlBotam).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
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
			((Control)PnlAc).Left = ((Control)PanelDhrn).Left;
			((Control)PnlAc).Top = ((Control)mBhDate).Top;
			if (CboAddType.SelectedIndex == 2)
			{
				Label3.Text = "Memb Code";
				Label1.Text = "Schm Code";
			}
			else
			{
				Label3.Text = "Party Code";
				Label1.Text = "Ac Group";
			}
			cboAcType.Items.Add((object)"");
			cboAcType.Items.Add((object)"A");
			cboAcType.Items.Add((object)"B");
			cboAcType.Items.Add((object)"C");
			cboAcType.Items.Add((object)"D");
			cboAcType.Items.Add((object)"E");
			cboAcType.SelectedIndex = 0;
			CboAddType.Items.Add((object)"Accounts");
			CboAddType.Items.Add((object)"Address");
			CboAddType.Items.Add((object)"Scheme");
			CboAddType.SelectedIndex = 0;
			AddCboItem();
			mBhDate.Text = DC_Main.MMask;
			mBhDate.Text = DC_Main.MMask;
			CurActCtrl = (Control)(object)CboAddType;
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
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_ADDRESS_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_ADDRESS_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_ADDRESS_KeyDown(object sender, KeyEventArgs e)
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

	private void RP_ADDRESS_Closed(object sender, EventArgs e)
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
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (CboAddType.SelectedIndex == 2)
		{
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				if (Operators.CompareString(tAcGroup.Text, "", false) == 0)
				{
					Interaction.MsgBox((object)"Please Select Scheme Code First And Try...", (MsgBoxStyle)0, (object)null);
					((Control)tAcGroup).Focus();
					return;
				}
				DC_Main.RsQry = "Select * From AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tAcGroup.Text + "' AND MEMB_CODE = '" + tAcCode.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT A.MEMB_NAME As MembNameL,A.MEMB_CODE As MembCodeL,A.SCHM_CODE AS SchemeL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AD_MEMB AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tAcGroup.Text + "' ORDER BY MEMB_NAME";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[6];
					DC_Main.ColWidth[0] = 300.0;
					DC_Main.ColWidth[1] = 100.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 280.0;
					DC_Main.ColWidth[4] = 120.0;
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
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)""));
					SendKeys.Send("{tab}");
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.LC_CODE,AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
				}
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

	private void tAcGroup_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (CboAddType.SelectedIndex == 2)
		{
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = "Select * From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SCHM_CODE = '" + tAcGroup.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT SCHM_CODE as SchmCodeL,SCHM_NAME As SchamNameL,SCHM_AMT As AmountR FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY SCHM_CODE";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[4];
					DC_Main.ColWidth[0] = 100.0;
					DC_Main.ColWidth[1] = 300.0;
					DC_Main.ColWidth[2] = 150.0;
					DC_Main.ColWidth[3] = 0.0;
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
					tAcGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_NAME"], (object)""));
					SendKeys.Send("{tab}");
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_GR = '" + tAcGroup.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_GR as GrCode,AC_GR_NAME As AcGroupL,AC_SUB_GR AS MainGroupL,AC_MAIN_GR As GrL FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY AC_GR";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 300.0;
				DC_Main.ColWidth[2] = 300.0;
				DC_Main.ColWidth[3] = 0.0;
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

	private void AddCboItem()
	{
		if (CboAddType.SelectedIndex == 0)
		{
			TblData = "AC_MAST";
		}
		else if (CboAddType.SelectedIndex == 1)
		{
			TblData = "ADD_MAST";
		}
		else if (CboAddType.SelectedIndex == 2)
		{
			TblData = "AD_MEMB";
		}
		else
		{
			TblData = "AC_MAST";
		}
		Cursor.Current = Cursors.WaitCursor;
		DC_Main.RsQry = "SELECT AC_ADD1 FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_ADD1 <> '' GROUP BY AC_ADD1 ORDER BY AC_ADD1 ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboAdd1.Items.Clear();
				cboAdd1.Items.Add((object)"");
				int count = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count)
				{
					cboAdd1.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_ADD1"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboAdd1.Items.Clear();
				cboAdd1.Items.Add((object)"");
				cboAdd1.Text = "";
			}
			DC_Main.RsQry = "SELECT AC_ADD3 FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_ADD3 <> '' GROUP BY AC_ADD3 ORDER BY AC_ADD3 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboAdd3.Items.Clear();
				cboAdd3.Items.Add((object)"");
				int count2 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count2)
				{
					cboAdd3.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_ADD3"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboAdd3.Items.Clear();
				cboAdd3.Items.Add((object)"");
				cboAdd3.Text = "";
			}
			if (CboAddType.SelectedIndex == 2)
			{
				cboState.Items.Clear();
				cboState.Items.Add((object)"");
				cboState.Text = "";
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_STATE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_STATE <> '' GROUP BY AC_STATE ORDER BY AC_STATE ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboState.Items.Clear();
					cboState.Items.Add((object)"");
					int count3 = DC_Main.Rshlp.Rows.Count;
					DC_Main.X = 1;
					while (DC_Main.X <= count3)
					{
						cboState.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_STATE"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboState.Items.Clear();
					cboState.Items.Add((object)"");
					cboState.Text = "";
				}
			}
			DC_Main.RsQry = "SELECT AC_DISTRICT FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_DISTRICT ORDER BY AC_DISTRICT ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboDistrict.Items.Clear();
				cboDistrict.Items.Add((object)"");
				int count4 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count4)
				{
					cboDistrict.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_DISTRICT"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboDistrict.Items.Clear();
				cboDistrict.Items.Add((object)"");
				cboDistrict.Text = "";
			}
			DC_Main.RsQry = "SELECT AC_CITY FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CITY <> '' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				cboCity.Items.Add((object)"");
				int count5 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count5)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_CITY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCity.Items.Clear();
				cboCity.Items.Add((object)"");
				cboCity.Text = "";
			}
			DC_Main.RsQry = "SELECT AC_AREA FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_AREA <> '' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				cboArea.Items.Add((object)"");
				int count6 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count6)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Clear();
				cboArea.Items.Add((object)"");
				cboArea.Text = "";
			}
			if (CboAddType.SelectedIndex == 0)
			{
				DC_Main.RsQry = "SELECT AC_REF_NAME FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_REF_NAME <> '' GROUP BY AC_REF_NAME ORDER BY AC_REF_NAME ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboPartyName.Items.Clear();
					cboPartyName.Items.Add((object)"");
					int count7 = DC_Main.Rshlp.Rows.Count;
					DC_Main.X = 1;
					while (DC_Main.X <= count7)
					{
						cboPartyName.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_REF_NAME"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboPartyName.Items.Add((object)"");
				}
			}
			else
			{
				cboPartyName.Items.Clear();
				cboPartyName.Items.Add((object)"");
				cboPartyName.Text = "";
			}
			if (CboAddType.SelectedIndex == 2)
			{
				cboCustGroup.Items.Clear();
				cboCustGroup.Items.Add((object)"");
				cboCustGroup.Text = "";
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_GR FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_GR ORDER BY AC_GR ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboCustGroup.Items.Clear();
					cboCustGroup.Items.Add((object)"");
					int count8 = DC_Main.Rshlp.Rows.Count;
					DC_Main.X = 1;
					while (DC_Main.X <= count8)
					{
						cboCustGroup.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_GR"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboCustGroup.Items.Clear();
					cboCustGroup.Items.Add((object)"");
					cboCustGroup.Text = "";
				}
			}
			Cursor.Current = Cursors.Default;
		}
	}

	private void CboAddType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (CboAddType.SelectedIndex != 0)
		{
			((Control)lblAcType).Visible = false;
			((Control)cboAcType).Visible = false;
		}
		else
		{
			((Control)lblAcType).Visible = true;
			((Control)cboAcType).Visible = true;
		}
	}

	private void Btn2Add_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TempAdd2.RPT";
		}
		else
		{
			DC_Main.RptName = "TempAdd2";
		}
		if (CboAddType.SelectedIndex == 0)
		{
			AccountPrint();
		}
		else if (CboAddType.SelectedIndex == 1)
		{
			AccountPrint();
		}
		else if (CboAddType.SelectedIndex == 2)
		{
			AccountPrint();
		}
	}

	private void AccountPrint()
	{
		if (CboAddType.SelectedIndex == 0)
		{
			TblData = "AC_MAST";
		}
		else if (CboAddType.SelectedIndex == 1)
		{
			TblData = "ADD_MAST";
		}
		else if (CboAddType.SelectedIndex == 2)
		{
			TblData = "AD_MEMB";
		}
		DC_Main.ExeQuteDc("DELETE FROM TEMP_ADD");
		checked
		{
			int num = (int)Math.Round(Conversion.Val(nSkipLbl.Text));
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "INSERT INTO TEMP_ADD (CO_CODE,AC_CODE,AC_NAME) VALUES('" + DC_Main.MCo_code + "','000','.')";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.i++;
			}
			if (CboAddType.SelectedIndex == 2)
			{
				DC_Main.RsQry = "INSERT INTO TEMP_ADD (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,  AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_PARSON,AC_AREA) SELECT CO_CODE,LC_CODE,MEMB_CODE,MEMB_NAME,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,  AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_REF_CODE,AC_AREA FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
			}
			else if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "INSERT INTO TEMP_ADD (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,  AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_PARSON,AC_AREA) SELECT CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,  AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_PERSON,AC_AREA FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			}
			else
			{
				DC_Main.RsQry = "INSERT INTO TEMP_ADD (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,  AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_PARSON,AC_AREA) SELECT CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,  AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_PERSON,AC_AREA FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
			}
			if (cboAcType.SelectedIndex != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_TYPE = '" + cboAcType.Text + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_AREA = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(tAcCode.Text, "", false) != 0)
			{
				if (CboAddType.SelectedIndex == 2)
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND MEMB_CODE = '" + tAcCode.Text + "'";
				}
				else
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND AC_CODE = '" + tAcCode.Text + "'";
				}
			}
			if (Operators.CompareString(tAcGroup.Text, "", false) != 0)
			{
				if (CboAddType.SelectedIndex == 2)
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND SCHM_CODE = '" + tAcGroup.Text + "'";
				}
				else
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND AC_GR = '" + tAcGroup.Text + "'";
				}
			}
			if (Operators.CompareString(cboCity.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_CITY = '" + cboCity.Text + "'";
			}
			if (Operators.CompareString(cboState.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_STATE = '" + cboState.Text + "'";
			}
			if (Operators.CompareString(cboAdd1.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_ADD1 = '" + cboAdd1.Text + "'";
			}
			if (Operators.CompareString(cboAdd3.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_ADD3 = '" + cboAdd3.Text + "'";
			}
			if (Operators.CompareString(tMobile.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_MOBILE = '" + tMobile.Text + "'";
			}
			if (Operators.CompareString(tPhone.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_PHONE = '" + tPhone.Text + "'";
			}
			if (Operators.CompareString(cboCustGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_GR = '" + cboCustGroup.Text + "'";
			}
			if (Operators.CompareString(cboPartyName.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_REF_NAME = '" + cboPartyName.Text + "'";
			}
			if (Operators.CompareString(ScelectAc, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND AC_CODE in (" + ScelectAc + ")";
			}
			if (Operators.CompareString(mToBDate.Text, "  /  /", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND (DAY(BR_DATE) >= '" + Strings.Mid(mBhDate.Text, 1, 2) + "' AND MONTH(BR_DATE) >= '" + Strings.Mid(mBhDate.Text, 4, 2) + "')";
				DC_Main.RsQry = DC_Main.RsQry + " AND (DAY(BR_DATE) <= '" + Strings.Mid(mToBDate.Text, 1, 2) + "' AND MONTH(BR_DATE) <= '" + Strings.Mid(mToBDate.Text, 4, 2) + "')";
			}
			if (Operators.CompareString(mAnDate.Text, "  /  /", false) != 0)
			{
				if (Operators.CompareString(mBhDate.Text, "  /  /", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + " OR DAY(AN_DATE) = '" + Strings.Mid(mAnDate.Text, 1, 2) + "' AND MONTH(AN_DATE) = '" + Strings.Mid(mAnDate.Text, 4, 2) + "'";
				}
				else
				{
					DC_Main.RsQry = DC_Main.RsQry + " AND DAY(AN_DATE) = '" + Strings.Mid(mAnDate.Text, 1, 2) + "' AND MONTH(AN_DATE) = '" + Strings.Mid(mAnDate.Text, 4, 2) + "'";
				}
			}
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM TEMP_ADD";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = "";
				Module_Save.ShowReportPreview();
			}
			else
			{
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
		}
	}

	private void BtnPhBook_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TempPhone.RPT";
		}
		else
		{
			DC_Main.RptName = "TempPhone";
		}
		if (CboAddType.SelectedIndex == 0)
		{
			AccountPrint();
		}
		else if (CboAddType.SelectedIndex == 1)
		{
			AccountPrint();
		}
		else if (CboAddType.SelectedIndex == 2)
		{
			AccountPrint();
		}
	}

	private void Btn3Add_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TempAdd3.RPT";
		}
		else
		{
			DC_Main.RptName = "TempAdd3";
		}
		if (CboAddType.SelectedIndex == 0)
		{
			AccountPrint();
		}
		else if (CboAddType.SelectedIndex == 1)
		{
			AccountPrint();
		}
		else if (CboAddType.SelectedIndex == 2)
		{
			AccountPrint();
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
			if (CboAddType.SelectedIndex == 0)
			{
				PatyMast();
			}
			((Control)tSearchText).Focus();
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

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		ScelectAc = "";
		checked
		{
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
	}

	private void mBhDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mBhDate;
			DC_Main.SetDate(ref MsDate);
			mBhDate = MsDate;
			if (!DC_Main.RongDate)
			{
				mToBDate.Text = mBhDate.Text;
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mAnDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mAnDate;
			DC_Main.SetDate(ref MsDate);
			mAnDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToBDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToBDate;
			DC_Main.SetDate(ref MsDate);
			mToBDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToBDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToBDate).SelectionStart = 0;
		((TextBoxBase)mToBDate).SelectionLength = Strings.Len(mToBDate.Text);
	}

	private void TSearchText_TextChanged(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
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
				case 452:
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
							goto IL_000f;
						case 4:
							goto IL_002d;
						case 5:
						case 6:
							goto IL_0042;
						case 7:
							goto IL_0066;
						case 8:
							goto IL_0084;
						case 9:
							goto IL_00be;
						case 10:
							goto IL_00ea;
						case 12:
						case 13:
							goto IL_010a;
						case 15:
							goto IL_0120;
						case 16:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 11:
						case 14:
						case 17:
						case 18:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00ea:
					num2 = 10;
					((DataGridView)DGV).Rows[num5].Selected = true;
					goto end_IL_0001_3;
					IL_010a:
					num2 = 13;
					num5 = checked(num5 + 1);
					goto IL_0113;
					IL_00be:
					num2 = 9;
					((DataGridView)DGV).CurrentCell = ((DataGridView)DGV).Rows[num5].Cells[num6];
					goto IL_00ea;
					IL_0120:
					num2 = 15;
					((DataGridView)DGV).CurrentCell = ((DataGridView)DGV).Rows[1].Cells[num6];
					break;
					IL_000b:
					num2 = 2;
					num6 = 2;
					goto IL_000f;
					IL_000f:
					num2 = 3;
					if (((DataGridView)DGV).CurrentCell.ColumnIndex >= 2)
					{
						goto IL_002d;
					}
					goto IL_0042;
					IL_002d:
					num2 = 4;
					num6 = ((DataGridView)DGV).CurrentCell.ColumnIndex;
					goto IL_0042;
					IL_0042:
					num2 = 6;
					if (Operators.CompareString(tSearchText.Text, "", false) != 0)
					{
						goto IL_0066;
					}
					goto IL_0120;
					IL_0066:
					num2 = 7;
					num7 = checked(((DataGridView)DGV).Rows.Count - 1);
					num5 = 0;
					goto IL_0113;
					IL_0113:
					if (num5 > num7)
					{
						goto end_IL_0001_3;
					}
					goto IL_0084;
					IL_0084:
					num2 = 8;
					if (((DataGridView)DGV)[num6, num5].Value.ToString().ToLower().StartsWith(tSearchText.Text.ToLower()))
					{
						goto IL_00be;
					}
					goto IL_010a;
					end_IL_0001_2:
					break;
				}
				num2 = 16;
				((DataGridView)DGV).Rows[1].Selected = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 452;
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

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tSearchText).Focus();
		}
		if ((int)e.KeyCode == 8 && Strings.Len(tSearchText.Text) > 0)
		{
			tSearchText.Text = Strings.Mid(tSearchText.Text, 1, checked(Strings.Len(tSearchText.Text) - 1));
		}
		if ((int)e.KeyCode == 112)
		{
			((Control)tSearchText).Focus();
		}
	}

	private void tSearchText_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 40)
		{
			((Control)DGV).Focus();
		}
	}

	private void TAcGroup_TextChanged(object sender, EventArgs e)
	{
	}
}
