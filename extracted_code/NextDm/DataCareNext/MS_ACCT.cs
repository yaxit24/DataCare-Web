using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class MS_ACCT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tdistrict")]
	private TextBox _tdistrict;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TState")]
	private TextBox _TState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCountry")]
	private TextBox _tCountry;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankArea")]
	private TextBox _tBankArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankAcNo")]
	private TextBox _tBankAcNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRtgsNo")]
	private TextBox _tRtgsNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDay")]
	private TextBox _nCrDay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDpcPrc")]
	private TextBox _nDpcPrc;

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
	[AccessedThroughProperty("tAcShort")]
	private TextBox _tAcShort;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboState")]
	private ComboBox _cboState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDistrict")]
	private ComboBox _cboDistrict;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConParcon")]
	private TextBox _tConParcon;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcGrCode")]
	private TextBox _tAcGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone")]
	private TextBox _tPhone;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress3")]
	private TextBox _tAddress3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress2")]
	private TextBox _tAddress2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress1")]
	private TextBox _tAddress1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPinCode")]
	private TextBox _tPinCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgC")]
	private SimpleButton _BtnImgC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgS")]
	private SimpleButton _BtnImgS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgD")]
	private SimpleButton _BtnImgD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSilver")]
	private ComboBox _cboSilver;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOpSilverFine")]
	private TextBox _nOpSilverFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboGold")]
	private ComboBox _cboGold;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOpGoldFine")]
	private TextBox _nOpGoldFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAmt")]
	private ComboBox _cboAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOpAmt")]
	private TextBox _nOpAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPanNo")]
	private TextBox _tPanNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGstNo")]
	private TextBox _tGstNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile2")]
	private TextBox _tMobile2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone2")]
	private TextBox _tPhone2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboGstType")]
	private ComboBox _cboGstType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkHoAcct")]
	private CheckBox _chkHoAcct;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mLastVisit")]
	private MaskedTextBox _mLastVisit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKhataNo")]
	private TextBox _tKhataNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mLdrDate")]
	private MaskedTextBox _mLdrDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMemb")]
	private SimpleButton _btnMemb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAdd")]
	private SimpleButton _BtnAdd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdharNo")]
	private TextBox _tAdharNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExcel")]
	private SimpleButton _btnExcel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOldYearAcImprt")]
	private SimpleButton _btnOldYearAcImprt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAcimp")]
	private SimpleButton _btnAcimp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineIntPrc")]
	private TextBox _nFineIntPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCountry")]
	private ComboBox _cboCountry;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAdminSet")]
	private SimpleButton _btnAdminSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnClear")]
	private QButton _btnClear;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUpdate")]
	private QButton _btnUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPartyGroup")]
	private TextBox _tPartyGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DgvAc")]
	private DataGridViewX _DgvAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAcType")]
	private ComboBox _cboAcType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mBhlDate")]
	private MaskedTextBox _mBhlDate;

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
	[AccessedThroughProperty("tEmail")]
	private TextBox _tEmail;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMainAcCode")]
	private TextBox _tMainAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPassportNo")]
	private TextBox _tPassportNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mCustIdDt")]
	private MaskedTextBox _mCustIdDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mtrnIdDt")]
	private MaskedTextBox _mtrnIdDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcsNo")]
	private TextBox _tLcsNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private SqlTransaction Tran;

	private double ColCon;

	private bool DletHoAc;

	private bool AcUpdate;

	private bool NewAcCrat;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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

	public virtual TextBox Text1
	{
		[CompilerGenerated]
		get
		{
			return _Text1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl2")]
	private virtual Panel _Pnl2;

	internal virtual Panel Pnl2
	{
		get
		{
			return _Pnl2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl3")]
	private virtual Panel _Pnl3;

	internal virtual Panel Pnl3
	{
		get
		{
			return _Pnl3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl3 = value;
		}
	}

	internal virtual TextBox tdistrict
	{
		[CompilerGenerated]
		get
		{
			return _tdistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tJudrection_KeyDown);
			TextBox val2 = _tdistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tdistrict = value;
			val2 = _tdistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox TState
	{
		[CompilerGenerated]
		get
		{
			return _TState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TState_KeyDown);
			TextBox val2 = _TState;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TState = value;
			val2 = _TState;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tCountry
	{
		[CompilerGenerated]
		get
		{
			return _tCountry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCountry_KeyDown);
			TextBox val2 = _tCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCountry = value;
			val2 = _tCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tBankName
	{
		[CompilerGenerated]
		get
		{
			return _tBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankName_KeyDown);
			TextBox val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankName = value;
			val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankArea
	{
		[CompilerGenerated]
		get
		{
			return _tBankArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankArea_KeyDown);
			TextBox val2 = _tBankArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankArea = value;
			val2 = _tBankArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankAcNo
	{
		[CompilerGenerated]
		get
		{
			return _tBankAcNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankAcNo_KeyDown);
			TextBox val2 = _tBankAcNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankAcNo = value;
			val2 = _tBankAcNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tRtgsNo
	{
		[CompilerGenerated]
		get
		{
			return _tRtgsNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRtgsNo_KeyDown);
			TextBox val2 = _tRtgsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRtgsNo = value;
			val2 = _tRtgsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nCrDay
	{
		[CompilerGenerated]
		get
		{
			return _nCrDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCrDay_KeyDown);
			TextBox val2 = _nCrDay;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrDay = value;
			val2 = _nCrDay;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCrDay")]
	private virtual Label _lblCrDay;

	internal virtual Label lblCrDay
	{
		get
		{
			return _lblCrDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCrDay = value;
		}
	}

	internal virtual TextBox nDpcPrc
	{
		[CompilerGenerated]
		get
		{
			return _nDpcPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDpcPrc_KeyDown);
			TextBox val2 = _nDpcPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDpcPrc = value;
			val2 = _nDpcPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblDpc")]
	private virtual Label _lblDpc;

	internal virtual Label lblDpc
	{
		get
		{
			return _lblDpc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDpc = value;
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
	[AccessedThroughProperty("Pnl1")]
	private virtual Panel _Pnl1;

	internal virtual Panel Pnl1
	{
		get
		{
			return _Pnl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl1 = value;
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

	internal virtual TextBox tAcShort
	{
		[CompilerGenerated]
		get
		{
			return _tAcShort;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcShort_KeyDown);
			EventHandler eventHandler = tAcShort_TextChanged;
			TextBox val2 = _tAcShort;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tAcShort = value;
			val2 = _tAcShort;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
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

	internal virtual ComboBox cboState
	{
		[CompilerGenerated]
		get
		{
			return _cboState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboState_KeyDown);
			ComboBox val2 = _cboState;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboState = value;
			val2 = _cboState;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("tAcMainGr")]
	private virtual TextBox _tAcMainGr;

	internal virtual TextBox tAcMainGr
	{
		get
		{
			return _tAcMainGr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcMainGr = value;
		}
	}

	internal virtual TextBox tConParcon
	{
		[CompilerGenerated]
		get
		{
			return _tConParcon;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tConParcon_KeyDown);
			TextBox val2 = _tConParcon;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tConParcon = value;
			val2 = _tConParcon;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tAcGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcGrCode_KeyDown);
			TextBox val2 = _tAcGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcGrCode = value;
			val2 = _tAcGrCode;
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

	internal virtual TextBox tPhone
	{
		[CompilerGenerated]
		get
		{
			return _tPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPhone_KeyDown);
			TextBox val2 = _tPhone;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPhone = value;
			val2 = _tPhone;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress3
	{
		[CompilerGenerated]
		get
		{
			return _tAddress3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress3_KeyDown);
			TextBox val2 = _tAddress3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress3 = value;
			val2 = _tAddress3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress2
	{
		[CompilerGenerated]
		get
		{
			return _tAddress2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress2_KeyDown);
			TextBox val2 = _tAddress2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress2 = value;
			val2 = _tAddress2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress1
	{
		[CompilerGenerated]
		get
		{
			return _tAddress1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress1_KeyDown);
			TextBox val2 = _tAddress1;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress1 = value;
			val2 = _tAddress1;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPinCode
	{
		[CompilerGenerated]
		get
		{
			return _tPinCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPinCode_KeyDown);
			TextBox val2 = _tPinCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPinCode = value;
			val2 = _tPinCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd3")]
	private virtual Label _lblAdd3;

	internal virtual Label lblAdd3
	{
		get
		{
			return _lblAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd2")]
	private virtual Label _lblAdd2;

	internal virtual Label lblAdd2
	{
		get
		{
			return _lblAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd2 = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBookCo")]
	private virtual Label _lblBookCo;

	internal virtual Label lblBookCo
	{
		get
		{
			return _lblBookCo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBookCo = value;
		}
	}

	internal virtual PictureBox PicImage
	{
		[CompilerGenerated]
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicImage_DoubleClick;
			PictureBox val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicImage = value;
			val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgC
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgC_Click;
			SimpleButton val = _BtnImgC;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgC = value;
			val = _BtnImgC;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgS
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgS_Click;
			SimpleButton val = _BtnImgS;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgS = value;
			val = _BtnImgS;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgD
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgD_Click;
			SimpleButton val = _BtnImgD;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgD = value;
			val = _BtnImgD;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private virtual GroupBox _GroupBox1;

	internal virtual GroupBox GroupBox1
	{
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_GroupBox1 = value;
		}
	}

	internal virtual ComboBox cboSilver
	{
		[CompilerGenerated]
		get
		{
			return _cboSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = CboSilver_SelectedIndexChanged;
			KeyEventHandler val = new KeyEventHandler(cboSilver_KeyDown);
			ComboBox val2 = _cboSilver;
			if (val2 != null)
			{
				val2.SelectedIndexChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_cboSilver = value;
			val2 = _cboSilver;
			if (val2 != null)
			{
				val2.SelectedIndexChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nOpSilverFine
	{
		[CompilerGenerated]
		get
		{
			return _nOpSilverFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = NOpSilverFine_TextChanged;
			KeyEventHandler val = new KeyEventHandler(nOpSilverFine_KeyDown);
			TextBox val2 = _nOpSilverFine;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_nOpSilverFine = value;
			val2 = _nOpSilverFine;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboGold
	{
		[CompilerGenerated]
		get
		{
			return _cboGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = CboGold_SelectedIndexChanged;
			KeyEventHandler val = new KeyEventHandler(cboGold_KeyDown);
			ComboBox val2 = _cboGold;
			if (val2 != null)
			{
				val2.SelectedIndexChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_cboGold = value;
			val2 = _cboGold;
			if (val2 != null)
			{
				val2.SelectedIndexChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nOpGoldFine
	{
		[CompilerGenerated]
		get
		{
			return _nOpGoldFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOpGoldFine_KeyDown);
			TextBox val2 = _nOpGoldFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nOpGoldFine = value;
			val2 = _nOpGoldFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboAmt
	{
		[CompilerGenerated]
		get
		{
			return _cboAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboAmt_KeyDown);
			ComboBox val2 = _cboAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboAmt = value;
			val2 = _cboAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nOpAmt
	{
		[CompilerGenerated]
		get
		{
			return _nOpAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = NOpAmt_TextChanged;
			KeyEventHandler val = new KeyEventHandler(nOpAmt_KeyDown);
			TextBox val2 = _nOpAmt;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_nOpAmt = value;
			val2 = _nOpAmt;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tAcName
	{
		[CompilerGenerated]
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			EventHandler eventHandler = tAcName_TextChanged;
			KeyEventHandler val2 = new KeyEventHandler(tAcName_KeyUp);
			CancelEventHandler cancelEventHandler = tAcName_Validating;
			TextBox val3 = _tAcName;
			if (val3 != null)
			{
				((Control)val3).KeyDown -= val;
				((Control)val3).TextChanged -= eventHandler;
				((Control)val3).KeyUp -= val2;
				((Control)val3).Validating -= cancelEventHandler;
			}
			_tAcName = value;
			val3 = _tAcName;
			if (val3 != null)
			{
				((Control)val3).KeyDown += val;
				((Control)val3).TextChanged += eventHandler;
				((Control)val3).KeyUp += val2;
				((Control)val3).Validating += cancelEventHandler;
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
	[AccessedThroughProperty("tCustDetl")]
	private virtual TextBox _tCustDetl;

	public virtual TextBox tCustDetl
	{
		get
		{
			return _tCustDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCustDetl = value;
		}
	}

	internal virtual TextBox tPanNo
	{
		[CompilerGenerated]
		get
		{
			return _tPanNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPanNo_KeyDown);
			TextBox val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPanNo = value;
			val2 = _tPanNo;
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

	internal virtual TextBox tGstNo
	{
		[CompilerGenerated]
		get
		{
			return _tGstNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGstNo_KeyDown);
			EventHandler eventHandler = tGstNo_TextChanged;
			TextBox val2 = _tGstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tGstNo = value;
			val2 = _tGstNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMoNo2")]
	private virtual Label _lblMoNo2;

	internal virtual Label lblMoNo2
	{
		get
		{
			return _lblMoNo2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMoNo2 = value;
		}
	}

	internal virtual TextBox tMobile
	{
		[CompilerGenerated]
		get
		{
			return _tMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tmobile_KeyDown);
			TextBox val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile = value;
			val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tMobile2
	{
		[CompilerGenerated]
		get
		{
			return _tMobile2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMobile2_KeyDown);
			TextBox val2 = _tMobile2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile2 = value;
			val2 = _tMobile2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tPhone2
	{
		[CompilerGenerated]
		get
		{
			return _tPhone2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPhone2_KeyDown);
			TextBox val2 = _tPhone2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPhone2 = value;
			val2 = _tPhone2;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpen")]
	private virtual OpenFileDialog _DlgOpen;

	internal virtual OpenFileDialog DlgOpen
	{
		get
		{
			return _DlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpen = value;
		}
	}

	internal virtual ComboBox cboGstType
	{
		[CompilerGenerated]
		get
		{
			return _cboGstType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboGstType_KeyDown);
			ComboBox val2 = _cboGstType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboGstType = value;
			val2 = _cboGstType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual PictureBox PicZoom
	{
		[CompilerGenerated]
		get
		{
			return _PicZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicZoom_DoubleClick;
			PictureBox val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicZoom = value;
			val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkHoAcct
	{
		[CompilerGenerated]
		get
		{
			return _chkHoAcct;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkHoAcct_CheckedChanged;
			CheckBox val = _chkHoAcct;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkHoAcct = value;
			val = _chkHoAcct;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mLastVisit
	{
		[CompilerGenerated]
		get
		{
			return _mLastVisit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mLastVisit_KeyDown);
			EventHandler eventHandler = mLastVisit_GotFocus;
			MaskedTextBox val2 = _mLastVisit;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mLastVisit = value;
			val2 = _mLastVisit;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual TextBox tKhataNo
	{
		[CompilerGenerated]
		get
		{
			return _tKhataNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tKhataNo_KeyDown);
			TextBox val2 = _tKhataNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tKhataNo = value;
			val2 = _tKhataNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual MaskedTextBox mLdrDate
	{
		[CompilerGenerated]
		get
		{
			return _mLdrDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(MLdrDate_KeyDown);
			EventHandler eventHandler = MLdrDate_GotFocus;
			MaskedTextBox val2 = _mLdrDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mLdrDate = value;
			val2 = _mLdrDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
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

	internal virtual SimpleButton btnMemb
	{
		[CompilerGenerated]
		get
		{
			return _btnMemb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMemb_Click;
			SimpleButton val = _btnMemb;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMemb = value;
			val = _btnMemb;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnAdd
	{
		[CompilerGenerated]
		get
		{
			return _BtnAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAdd_Click;
			SimpleButton val = _BtnAdd;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAdd = value;
			val = _BtnAdd;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tAdharNo
	{
		[CompilerGenerated]
		get
		{
			return _tAdharNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdharNo_KeyDown);
			TextBox val2 = _tAdharNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdharNo = value;
			val2 = _tAdharNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdhar")]
	private virtual Label _lblAdhar;

	internal virtual Label lblAdhar
	{
		get
		{
			return _lblAdhar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdhar = value;
		}
	}

	internal virtual SimpleButton btnExcel
	{
		[CompilerGenerated]
		get
		{
			return _btnExcel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnExcel_Click;
			SimpleButton val = _btnExcel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExcel = value;
			val = _btnExcel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnOldYearAcImprt
	{
		[CompilerGenerated]
		get
		{
			return _btnOldYearAcImprt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOldYearAcImprt_Click;
			SimpleButton val = _btnOldYearAcImprt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOldYearAcImprt = value;
			val = _btnOldYearAcImprt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabMenu")]
	private virtual SuperTabControl _TabMenu;

	private virtual SuperTabControl TabMenu
	{
		get
		{
			return _TabMenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabMenu = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel1")]
	private virtual SuperTabControlPanel _TabPanel1;

	private virtual SuperTabControlPanel TabPanel1
	{
		get
		{
			return _TabPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab1")]
	private virtual SuperTabItem _Tab1;

	private virtual SuperTabItem Tab1
	{
		get
		{
			return _Tab1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel3")]
	private virtual SuperTabControlPanel _TabPanel3;

	private virtual SuperTabControlPanel TabPanel3
	{
		get
		{
			return _TabPanel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab3")]
	private virtual SuperTabItem _Tab3;

	private virtual SuperTabItem Tab3
	{
		get
		{
			return _Tab3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel2")]
	private virtual SuperTabControlPanel _TabPanel2;

	private virtual SuperTabControlPanel TabPanel2
	{
		get
		{
			return _TabPanel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab2")]
	private virtual SuperTabItem _Tab2;

	private virtual SuperTabItem Tab2
	{
		get
		{
			return _Tab2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab2 = value;
		}
	}

	internal virtual SimpleButton btnAcimp
	{
		[CompilerGenerated]
		get
		{
			return _btnAcimp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAcimp_Click;
			SimpleButton val = _btnAcimp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAcimp = value;
			val = _btnAcimp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox nFineIntPrc
	{
		[CompilerGenerated]
		get
		{
			return _nFineIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineIntPrc_KeyDown);
			TextBox val2 = _nFineIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineIntPrc = value;
			val2 = _nFineIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblFineIntPrc")]
	private virtual Label _lblFineIntPrc;

	internal virtual Label lblFineIntPrc
	{
		get
		{
			return _lblFineIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblFineIntPrc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAcName")]
	private virtual TextBox _tRefAcName;

	internal virtual TextBox tRefAcName
	{
		get
		{
			return _tRefAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRefAcName = value;
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

	internal virtual ComboBox cboCountry
	{
		[CompilerGenerated]
		get
		{
			return _cboCountry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCountry_KeyDown);
			ComboBox val2 = _cboCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCountry = value;
			val2 = _cboCountry;
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

	internal virtual SimpleButton btnAdminSet
	{
		[CompilerGenerated]
		get
		{
			return _btnAdminSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAdminSet_Click;
			SimpleButton val = _btnAdminSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAdminSet = value;
			val = _btnAdminSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlAdminSet")]
	private virtual Panel _PnlAdminSet;

	internal virtual Panel PnlAdminSet
	{
		get
		{
			return _PnlAdminSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlAdminSet = value;
		}
	}

	internal virtual QButton btnClear
	{
		[CompilerGenerated]
		get
		{
			return _btnClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnClear_Click;
			QButton val = _btnClear;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnClear = value;
			val = _btnClear;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnUpdate_Click;
			QButton val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUpdate = value;
			val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tPartyGroup
	{
		[CompilerGenerated]
		get
		{
			return _tPartyGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPartyGroup_KeyDown);
			TextBox val2 = _tPartyGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPartyGroup = value;
			val2 = _tPartyGroup;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual DataGridViewX DgvAc
	{
		[CompilerGenerated]
		get
		{
			return _DgvAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DgvAc_CellFormatting);
			DataGridViewX val2 = _DgvAc;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
			}
			_DgvAc = value;
			val2 = _DgvAc;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkDefaulter")]
	private virtual CheckBox _chkDefaulter;

	internal virtual CheckBox chkDefaulter
	{
		get
		{
			return _chkDefaulter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkDefaulter = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcAmtLimit")]
	private virtual TextBox _nAcAmtLimit;

	internal virtual TextBox nAcAmtLimit
	{
		get
		{
			return _nAcAmtLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAcAmtLimit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAcAmtLimit")]
	private virtual Label _lblAcAmtLimit;

	internal virtual Label lblAcAmtLimit
	{
		get
		{
			return _lblAcAmtLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAcAmtLimit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcSilverLimit")]
	private virtual TextBox _nAcSilverLimit;

	internal virtual TextBox nAcSilverLimit
	{
		get
		{
			return _nAcSilverLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAcSilverLimit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblSilverLimit")]
	private virtual Label _lblSilverLimit;

	internal virtual Label lblSilverLimit
	{
		get
		{
			return _lblSilverLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblSilverLimit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcGoldLimit")]
	private virtual TextBox _nAcGoldLimit;

	internal virtual TextBox nAcGoldLimit
	{
		get
		{
			return _nAcGoldLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAcGoldLimit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblGoldLimit")]
	private virtual Label _lblGoldLimit;

	internal virtual Label lblGoldLimit
	{
		get
		{
			return _lblGoldLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblGoldLimit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWithTdsTax")]
	private virtual CheckBox _chkWithTdsTax;

	internal virtual CheckBox chkWithTdsTax
	{
		get
		{
			return _chkWithTdsTax;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkWithTdsTax = value;
		}
	}

	internal virtual ComboBox cboAcType
	{
		[CompilerGenerated]
		get
		{
			return _cboAcType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboAcType_KeyDown);
			ComboBox val2 = _cboAcType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboAcType = value;
			val2 = _cboAcType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mBhlDate
	{
		[CompilerGenerated]
		get
		{
			return _mBhlDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mBhlDate_KeyDown);
			MaskedTextBox val2 = _mBhlDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mBhlDate = value;
			val2 = _mBhlDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLBDate")]
	private virtual Label _lblLBDate;

	internal virtual Label lblLBDate
	{
		get
		{
			return _lblLBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLBDate = value;
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
	[AccessedThroughProperty("lblAnvDate")]
	private virtual Label _lblAnvDate;

	internal virtual Label lblAnvDate
	{
		get
		{
			return _lblAnvDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAnvDate = value;
		}
	}

	internal virtual TextBox tEmail
	{
		[CompilerGenerated]
		get
		{
			return _tEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmail_KeyDown);
			TextBox val2 = _tEmail;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmail = value;
			val2 = _tEmail;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblEmail")]
	private virtual Label _lblEmail;

	internal virtual Label lblEmail
	{
		get
		{
			return _lblEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblEmail = value;
		}
	}

	internal virtual TextBox tMainAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tMainAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TMainAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tMainAcCode_KeyDown);
			TextBox val2 = _tMainAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tMainAcCode = value;
			val2 = _tMainAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tPassportNo
	{
		[CompilerGenerated]
		get
		{
			return _tPassportNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPassportNo_KeyDown);
			TextBox val2 = _tPassportNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPassportNo = value;
			val2 = _tPassportNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label27")]
	private virtual Label _Label27;

	internal virtual Label Label27
	{
		get
		{
			return _Label27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label27 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCustIdExpdt")]
	private virtual Label _lblCustIdExpdt;

	internal virtual Label lblCustIdExpdt
	{
		get
		{
			return _lblCustIdExpdt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCustIdExpdt = value;
		}
	}

	internal virtual MaskedTextBox mCustIdDt
	{
		[CompilerGenerated]
		get
		{
			return _mCustIdDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mCustIdDt_KeyDown);
			MaskedTextBox val2 = _mCustIdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mCustIdDt = value;
			val2 = _mCustIdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblTranDt")]
	private virtual Label _LblTranDt;

	internal virtual Label LblTranDt
	{
		get
		{
			return _LblTranDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblTranDt = value;
		}
	}

	internal virtual MaskedTextBox mtrnIdDt
	{
		[CompilerGenerated]
		get
		{
			return _mtrnIdDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mtrnIdDt_KeyDown);
			MaskedTextBox val2 = _mtrnIdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mtrnIdDt = value;
			val2 = _mtrnIdDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkAcMemb")]
	private virtual CheckBox _chkAcMemb;

	internal virtual CheckBox chkAcMemb
	{
		get
		{
			return _chkAcMemb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkAcMemb = value;
		}
	}

	internal virtual TextBox tLcsNo
	{
		[CompilerGenerated]
		get
		{
			return _tLcsNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLcsNo_KeyDown);
			TextBox val2 = _tLcsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tLcsNo = value;
			val2 = _tLcsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
			EventHandler eventHandler = cboCity_SelectedIndexChanged;
			ComboBox val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboCity = value;
			val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLcsNo")]
	private virtual Label _lblLcsNo;

	internal virtual Label lblLcsNo
	{
		get
		{
			return _lblLcsNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLcsNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkShareHolder")]
	private virtual CheckBox _chkShareHolder;

	internal virtual CheckBox chkShareHolder
	{
		get
		{
			return _chkShareHolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkShareHolder = value;
		}
	}

	public int newindex { get; set; }

	public MS_ACCT()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		((Form)this).Load += MS_ACCT_Load;
		((Form)this).Activated += MS_ACCT_Activated;
		((Form)this).Deactivate += MS_ACCT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_ACCT_KeyPress);
		((Control)this).Validating += tAcCode_Validating;
		((Control)this).KeyDown += new KeyEventHandler(MS_ACCT_KeyDown);
		((Form)this).Closed += MS_ACCT_Closed;
		DletHoAc = false;
		AcUpdate = false;
		NewAcCrat = false;
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
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Expected O, but got Unknown
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Expected O, but got Unknown
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Expected O, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Expected O, but got Unknown
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Expected O, but got Unknown
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected O, but got Unknown
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Expected O, but got Unknown
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Expected O, but got Unknown
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e7: Expected O, but got Unknown
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Expected O, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Expected O, but got Unknown
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Expected O, but got Unknown
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Expected O, but got Unknown
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected O, but got Unknown
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_063b: Expected O, but got Unknown
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected O, but got Unknown
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_065f: Expected O, but got Unknown
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Expected O, but got Unknown
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Expected O, but got Unknown
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Expected O, but got Unknown
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Expected O, but got Unknown
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Expected O, but got Unknown
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Expected O, but got Unknown
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Expected O, but got Unknown
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Expected O, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Expected O, but got Unknown
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected O, but got Unknown
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Expected O, but got Unknown
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Expected O, but got Unknown
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Expected O, but got Unknown
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_0713: Expected O, but got Unknown
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071f: Expected O, but got Unknown
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Expected O, but got Unknown
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected O, but got Unknown
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Expected O, but got Unknown
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Expected O, but got Unknown
		//IL_147e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1488: Expected O, but got Unknown
		//IL_156d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1577: Expected O, but got Unknown
		//IL_1620: Unknown result type (might be due to invalid IL or missing references)
		//IL_162a: Expected O, but got Unknown
		//IL_1743: Unknown result type (might be due to invalid IL or missing references)
		//IL_174d: Expected O, but got Unknown
		//IL_1832: Unknown result type (might be due to invalid IL or missing references)
		//IL_183c: Expected O, but got Unknown
		//IL_18e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ef: Expected O, but got Unknown
		//IL_19d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19de: Expected O, but got Unknown
		//IL_1ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acd: Expected O, but got Unknown
		//IL_1b76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b80: Expected O, but got Unknown
		//IL_1e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1f: Expected O, but got Unknown
		//IL_1f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0e: Expected O, but got Unknown
		//IL_1fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc1: Expected O, but got Unknown
		//IL_3642: Unknown result type (might be due to invalid IL or missing references)
		//IL_364c: Expected O, but got Unknown
		//IL_36af: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b9: Expected O, but got Unknown
		//IL_3728: Unknown result type (might be due to invalid IL or missing references)
		//IL_3732: Expected O, but got Unknown
		//IL_3795: Unknown result type (might be due to invalid IL or missing references)
		//IL_379f: Expected O, but got Unknown
		//IL_380e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3818: Expected O, but got Unknown
		//IL_388d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3897: Expected O, but got Unknown
		//IL_3906: Unknown result type (might be due to invalid IL or missing references)
		//IL_3910: Expected O, but got Unknown
		//IL_3973: Unknown result type (might be due to invalid IL or missing references)
		//IL_397d: Expected O, but got Unknown
		//IL_39ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_39f6: Expected O, but got Unknown
		//IL_3a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a63: Expected O, but got Unknown
		//IL_3ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3adc: Expected O, but got Unknown
		//IL_3b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ba1: Expected O, but got Unknown
		//IL_3c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c66: Expected O, but got Unknown
		//IL_3d97: Unknown result type (might be due to invalid IL or missing references)
		//IL_3da1: Expected O, but got Unknown
		//IL_3e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1f: Expected O, but got Unknown
		//IL_3e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e9d: Expected O, but got Unknown
		//IL_42ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_4309: Expected O, but got Unknown
		//IL_439e: Unknown result type (might be due to invalid IL or missing references)
		//IL_43a8: Expected O, but got Unknown
		//IL_442a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4434: Expected O, but got Unknown
		//IL_4501: Unknown result type (might be due to invalid IL or missing references)
		//IL_450b: Expected O, but got Unknown
		//IL_4566: Unknown result type (might be due to invalid IL or missing references)
		//IL_4570: Expected O, but got Unknown
		//IL_47d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_47db: Expected O, but got Unknown
		//IL_4877: Unknown result type (might be due to invalid IL or missing references)
		//IL_4881: Expected O, but got Unknown
		//IL_490b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4915: Expected O, but got Unknown
		//IL_49da: Unknown result type (might be due to invalid IL or missing references)
		//IL_49e4: Expected O, but got Unknown
		//IL_4a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a49: Expected O, but got Unknown
		//IL_4d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4da2: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_5054: Unknown result type (might be due to invalid IL or missing references)
		//IL_5078: Unknown result type (might be due to invalid IL or missing references)
		//IL_509c: Unknown result type (might be due to invalid IL or missing references)
		//IL_50c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_515d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5167: Expected O, but got Unknown
		//IL_51d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_51d9: Expected O, but got Unknown
		//IL_51db: Unknown result type (might be due to invalid IL or missing references)
		//IL_51e1: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_ACCT));
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
		lblBook = new Label();
		Text1 = new TextBox();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		tLcsNo = new TextBox();
		mCustIdDt = new MaskedTextBox();
		LblTranDt = new Label();
		mtrnIdDt = new MaskedTextBox();
		tConParcon = new TextBox();
		tPhone = new TextBox();
		tMainAcCode = new TextBox();
		cboDistrict = new ComboBox();
		Label26 = new Label();
		mBhlDate = new MaskedTextBox();
		lblLBDate = new Label();
		mAnDate = new MaskedTextBox();
		mBhDate = new MaskedTextBox();
		lblBDate = new Label();
		lblAnvDate = new Label();
		cboAcType = new ComboBox();
		tRefAcName = new TextBox();
		tRefAc = new TextBox();
		btnAcimp = new SimpleButton();
		Label20 = new Label();
		btnMemb = new SimpleButton();
		BtnAdd = new SimpleButton();
		chkHoAcct = new CheckBox();
		cboGstType = new ComboBox();
		tPanNo = new TextBox();
		Label9 = new Label();
		tGstNo = new TextBox();
		lblMoNo2 = new Label();
		tMobile = new TextBox();
		lblMoNo = new Label();
		BtnF1 = new SimpleButton();
		Label18 = new Label();
		tAcShort = new TextBox();
		cboArea = new ComboBox();
		Label17 = new Label();
		cboState = new ComboBox();
		tAcMainGr = new TextBox();
		Label16 = new Label();
		cboCity = new ComboBox();
		tAcGrName = new TextBox();
		tAcGrCode = new TextBox();
		lblBookCo = new Label();
		Label15 = new Label();
		lblCity = new Label();
		Label7 = new Label();
		tPinCode = new TextBox();
		Label4 = new Label();
		tAddress3 = new TextBox();
		tAddress2 = new TextBox();
		tAddress1 = new TextBox();
		lblPhone = new Label();
		lblAdd3 = new Label();
		lblAdd2 = new Label();
		lblAdd1 = new Label();
		tAcName = new TextBox();
		tAcCode = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		lblCustIdExpdt = new Label();
		lblLcsNo = new Label();
		Tab1 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		chkShareHolder = new CheckBox();
		chkAcMemb = new CheckBox();
		tPassportNo = new TextBox();
		Label27 = new Label();
		tEmail = new TextBox();
		lblEmail = new Label();
		chkWithTdsTax = new CheckBox();
		nAcSilverLimit = new TextBox();
		lblSilverLimit = new Label();
		nAcGoldLimit = new TextBox();
		lblGoldLimit = new Label();
		nAcAmtLimit = new TextBox();
		lblAcAmtLimit = new Label();
		chkDefaulter = new CheckBox();
		cboCountry = new ComboBox();
		Label3 = new Label();
		nFineIntPrc = new TextBox();
		lblFineIntPrc = new Label();
		tAdharNo = new TextBox();
		lblAdhar = new Label();
		tKhataNo = new TextBox();
		Label22 = new Label();
		tMobile2 = new TextBox();
		Label6 = new Label();
		tPhone2 = new TextBox();
		Label5 = new Label();
		nDpcPrc = new TextBox();
		lblDpc = new Label();
		nCrDay = new TextBox();
		lblCrDay = new Label();
		tRtgsNo = new TextBox();
		tBankAcNo = new TextBox();
		tBankArea = new TextBox();
		tBankName = new TextBox();
		Label11 = new Label();
		Label12 = new Label();
		Label13 = new Label();
		Label14 = new Label();
		Tab2 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		Tab3 = new SuperTabItem();
		tdistrict = new TextBox();
		TState = new TextBox();
		tCountry = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnExcel = new SimpleButton();
		btnOldYearAcImprt = new SimpleButton();
		btnAdminSet = new SimpleButton();
		PicImage = new PictureBox();
		BtnImgC = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgD = new SimpleButton();
		GroupBox1 = new GroupBox();
		cboSilver = new ComboBox();
		nOpSilverFine = new TextBox();
		cboGold = new ComboBox();
		nOpGoldFine = new TextBox();
		cboAmt = new ComboBox();
		nOpAmt = new TextBox();
		Label21 = new Label();
		Label19 = new Label();
		Label10 = new Label();
		tCustDetl = new TextBox();
		DlgOpen = new OpenFileDialog();
		DGV = new DataGridViewX();
		PicZoom = new PictureBox();
		mLastVisit = new MaskedTextBox();
		Label8 = new Label();
		mLdrDate = new MaskedTextBox();
		Label23 = new Label();
		PnlAdminSet = new Panel();
		DgvAc = new DataGridViewX();
		tPartyGroup = new TextBox();
		Label25 = new Label();
		btnClear = new QButton();
		btnUpdate = new QButton();
		tSerchAll = new SearchControl();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)Pnl2).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((Control)GroupBox1).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((Control)PnlAdminSet).SuspendLayout();
		((ISupportInitialize)DgvAc).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
		((BaseItem)TabMenu.ControlBox.CloseBox).Name = "";
		((BaseItem)TabMenu.ControlBox.MenuBox).Name = "";
		((BaseItem)TabMenu.ControlBox).Name = "";
		((BaseItem)TabMenu.ControlBox).SubItems.AddRange((BaseItem[])(object)new BaseItem[2]
		{
			(BaseItem)TabMenu.ControlBox.MenuBox,
			(BaseItem)TabMenu.ControlBox.CloseBox
		});
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel1);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel2);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel3);
		componentResourceManager.ApplyResources(TabMenu, "TabMenu");
		((Control)TabMenu).Name = "TabMenu";
		TabMenu.ReorderTabsEnabled = true;
		TabMenu.SelectedTabIndex = 0;
		TabMenu.ShowFocusRectangle = true;
		TabMenu.TabAlignment = (eTabStripAlignment)3;
		TabMenu.TabLayoutType = (eSuperTabLayoutType)1;
		TabMenu.Tabs.AddRange((BaseItem[])(object)new BaseItem[3]
		{
			(BaseItem)Tab1,
			(BaseItem)Tab2,
			(BaseItem)Tab3
		});
		TabMenu.TabStyle = (eSuperTabStyle)1;
		((PanelControl)TabPanel1).CanvasColor = Color.Black;
		((Control)TabPanel1).Controls.Add((Control)(object)Pnl1);
		componentResourceManager.ApplyResources(TabPanel1, "TabPanel1");
		((Control)TabPanel1).Name = "TabPanel1";
		TabPanel1.TabItem = Tab1;
		((Control)Pnl1).Controls.Add((Control)(object)tLcsNo);
		((Control)Pnl1).Controls.Add((Control)(object)mCustIdDt);
		((Control)Pnl1).Controls.Add((Control)(object)LblTranDt);
		((Control)Pnl1).Controls.Add((Control)(object)mtrnIdDt);
		((Control)Pnl1).Controls.Add((Control)(object)tConParcon);
		((Control)Pnl1).Controls.Add((Control)(object)tPhone);
		((Control)Pnl1).Controls.Add((Control)(object)tMainAcCode);
		((Control)Pnl1).Controls.Add((Control)(object)cboDistrict);
		((Control)Pnl1).Controls.Add((Control)(object)Label26);
		((Control)Pnl1).Controls.Add((Control)(object)mBhlDate);
		((Control)Pnl1).Controls.Add((Control)(object)lblLBDate);
		((Control)Pnl1).Controls.Add((Control)(object)mAnDate);
		((Control)Pnl1).Controls.Add((Control)(object)mBhDate);
		((Control)Pnl1).Controls.Add((Control)(object)lblBDate);
		((Control)Pnl1).Controls.Add((Control)(object)lblAnvDate);
		((Control)Pnl1).Controls.Add((Control)(object)cboAcType);
		((Control)Pnl1).Controls.Add((Control)(object)tRefAcName);
		((Control)Pnl1).Controls.Add((Control)(object)tRefAc);
		((Control)Pnl1).Controls.Add((Control)(object)btnAcimp);
		((Control)Pnl1).Controls.Add((Control)(object)Label20);
		((Control)Pnl1).Controls.Add((Control)(object)btnMemb);
		((Control)Pnl1).Controls.Add((Control)(object)BtnAdd);
		((Control)Pnl1).Controls.Add((Control)(object)chkHoAcct);
		((Control)Pnl1).Controls.Add((Control)(object)cboGstType);
		((Control)Pnl1).Controls.Add((Control)(object)tPanNo);
		((Control)Pnl1).Controls.Add((Control)(object)Label9);
		((Control)Pnl1).Controls.Add((Control)(object)tGstNo);
		((Control)Pnl1).Controls.Add((Control)(object)lblMoNo2);
		((Control)Pnl1).Controls.Add((Control)(object)tMobile);
		((Control)Pnl1).Controls.Add((Control)(object)lblMoNo);
		((Control)Pnl1).Controls.Add((Control)(object)BtnF1);
		((Control)Pnl1).Controls.Add((Control)(object)Label18);
		((Control)Pnl1).Controls.Add((Control)(object)tAcShort);
		((Control)Pnl1).Controls.Add((Control)(object)cboArea);
		((Control)Pnl1).Controls.Add((Control)(object)Label17);
		((Control)Pnl1).Controls.Add((Control)(object)cboState);
		((Control)Pnl1).Controls.Add((Control)(object)tAcMainGr);
		((Control)Pnl1).Controls.Add((Control)(object)Label16);
		((Control)Pnl1).Controls.Add((Control)(object)cboCity);
		((Control)Pnl1).Controls.Add((Control)(object)tAcGrName);
		((Control)Pnl1).Controls.Add((Control)(object)tAcGrCode);
		((Control)Pnl1).Controls.Add((Control)(object)lblBookCo);
		((Control)Pnl1).Controls.Add((Control)(object)Label15);
		((Control)Pnl1).Controls.Add((Control)(object)lblCity);
		((Control)Pnl1).Controls.Add((Control)(object)Label7);
		((Control)Pnl1).Controls.Add((Control)(object)tPinCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label4);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress3);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress2);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress1);
		((Control)Pnl1).Controls.Add((Control)(object)lblPhone);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd3);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd2);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd1);
		((Control)Pnl1).Controls.Add((Control)(object)tAcName);
		((Control)Pnl1).Controls.Add((Control)(object)tAcCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label2);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		((Control)Pnl1).Controls.Add((Control)(object)lblCustIdExpdt);
		((Control)Pnl1).Controls.Add((Control)(object)lblLcsNo);
		componentResourceManager.ApplyResources(Pnl1, "Pnl1");
		((Control)Pnl1).Name = "Pnl1";
		componentResourceManager.ApplyResources(tLcsNo, "tLcsNo");
		((Control)tLcsNo).Name = "tLcsNo";
		componentResourceManager.ApplyResources(mCustIdDt, "mCustIdDt");
		((Control)mCustIdDt).Name = "mCustIdDt";
		mCustIdDt.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(LblTranDt, "LblTranDt");
		((Control)LblTranDt).ForeColor = Color.Black;
		((Control)LblTranDt).Name = "LblTranDt";
		componentResourceManager.ApplyResources(mtrnIdDt, "mtrnIdDt");
		((Control)mtrnIdDt).Name = "mtrnIdDt";
		mtrnIdDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)tConParcon).BackColor = Color.White;
		componentResourceManager.ApplyResources(tConParcon, "tConParcon");
		((Control)tConParcon).Name = "tConParcon";
		((TextBoxBase)tPhone).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPhone, "tPhone");
		((Control)tPhone).Name = "tPhone";
		((TextBoxBase)tMainAcCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMainAcCode, "tMainAcCode");
		((Control)tMainAcCode).Name = "tMainAcCode";
		cboDistrict.AutoCompleteMode = (AutoCompleteMode)2;
		cboDistrict.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboDistrict, "cboDistrict");
		((ListControl)cboDistrict).FormattingEnabled = true;
		((Control)cboDistrict).Name = "cboDistrict";
		((Control)Label26).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label26, "Label26");
		((Control)Label26).ForeColor = Color.Black;
		((Control)Label26).Name = "Label26";
		componentResourceManager.ApplyResources(mBhlDate, "mBhlDate");
		((Control)mBhlDate).Name = "mBhlDate";
		mBhlDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(lblLBDate, "lblLBDate");
		((Control)lblLBDate).ForeColor = Color.Black;
		((Control)lblLBDate).Name = "lblLBDate";
		componentResourceManager.ApplyResources(mAnDate, "mAnDate");
		((Control)mAnDate).Name = "mAnDate";
		mAnDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(mBhDate, "mBhDate");
		((Control)mBhDate).Name = "mBhDate";
		mBhDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(lblBDate, "lblBDate");
		((Control)lblBDate).ForeColor = Color.Black;
		((Control)lblBDate).Name = "lblBDate";
		componentResourceManager.ApplyResources(lblAnvDate, "lblAnvDate");
		((Control)lblAnvDate).ForeColor = Color.Black;
		((Control)lblAnvDate).Name = "lblAnvDate";
		cboAcType.DropDownStyle = (ComboBoxStyle)2;
		componentResourceManager.ApplyResources(cboAcType, "cboAcType");
		((ListControl)cboAcType).FormattingEnabled = true;
		((Control)cboAcType).Name = "cboAcType";
		((TextBoxBase)tRefAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRefAcName, "tRefAcName");
		((Control)tRefAcName).Name = "tRefAcName";
		((TextBoxBase)tRefAc).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRefAc, "tRefAc");
		((Control)tRefAc).Name = "tRefAc";
		((BaseStyleControl)btnAcimp).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnAcimp).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnAcimp).Appearance.Font = (Font)componentResourceManager.GetObject("btnAcimp.Appearance.Font");
		((BaseStyleControl)btnAcimp).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnAcimp).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnAcimp.Appearance.GradientMode"));
		((BaseStyleControl)btnAcimp).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnAcimp).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnAcimp).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnAcimp).Appearance.Options.UseForeColor = true;
		((BaseButton)btnAcimp).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnAcimp).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnAcimp).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("btnAcimp.AppearanceHovered.Font");
		((BaseButton)btnAcimp).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnAcimp.AppearanceHovered.GradientMode"));
		((BaseButton)btnAcimp).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnAcimp).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnAcimp).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnAcimp).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnAcimp).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnAcimp).AppearancePressed.Font = (Font)componentResourceManager.GetObject("btnAcimp.AppearancePressed.Font");
		((BaseButton)btnAcimp).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnAcimp).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnAcimp).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(btnAcimp, "btnAcimp");
		((BaseControl)btnAcimp).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnAcimp).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnAcimp).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnAcimp).Name = "btnAcimp";
		componentResourceManager.ApplyResources(Label20, "Label20");
		((Control)Label20).ForeColor = Color.Black;
		((Control)Label20).Name = "Label20";
		((BaseStyleControl)btnMemb).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnMemb).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnMemb).Appearance.Font = (Font)componentResourceManager.GetObject("btnMemb.Appearance.Font");
		((BaseStyleControl)btnMemb).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnMemb).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnMemb.Appearance.GradientMode"));
		((BaseStyleControl)btnMemb).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnMemb).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnMemb).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMemb).Appearance.Options.UseForeColor = true;
		((BaseButton)btnMemb).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnMemb).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnMemb).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("btnMemb.AppearanceHovered.Font");
		((BaseButton)btnMemb).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnMemb.AppearanceHovered.GradientMode"));
		((BaseButton)btnMemb).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnMemb).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnMemb).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnMemb).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnMemb).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnMemb).AppearancePressed.Font = (Font)componentResourceManager.GetObject("btnMemb.AppearancePressed.Font");
		((BaseButton)btnMemb).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnMemb).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnMemb).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(btnMemb, "btnMemb");
		((BaseControl)btnMemb).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnMemb).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnMemb).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMemb).Name = "btnMemb";
		((BaseStyleControl)BtnAdd).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAdd).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAdd).Appearance.Font = (Font)componentResourceManager.GetObject("BtnAdd.Appearance.Font");
		((BaseStyleControl)BtnAdd).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAdd).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnAdd.Appearance.GradientMode"));
		((BaseStyleControl)BtnAdd).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAdd).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAdd).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAdd).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAdd).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAdd).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAdd).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("BtnAdd.AppearanceHovered.Font");
		((BaseButton)BtnAdd).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnAdd.AppearanceHovered.GradientMode"));
		((BaseButton)BtnAdd).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAdd).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAdd).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAdd).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAdd).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAdd).AppearancePressed.Font = (Font)componentResourceManager.GetObject("BtnAdd.AppearancePressed.Font");
		((BaseButton)BtnAdd).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAdd).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAdd).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(BtnAdd, "BtnAdd");
		((BaseControl)BtnAdd).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAdd).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAdd).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAdd).Name = "BtnAdd";
		((ButtonBase)chkHoAcct).BackColor = SystemColors.ButtonHighlight;
		componentResourceManager.ApplyResources(chkHoAcct, "chkHoAcct");
		((Control)chkHoAcct).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkHoAcct).Name = "chkHoAcct";
		((ButtonBase)chkHoAcct).UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(cboGstType, "cboGstType");
		((ListControl)cboGstType).FormattingEnabled = true;
		((Control)cboGstType).Name = "cboGstType";
		componentResourceManager.ApplyResources(tPanNo, "tPanNo");
		((Control)tPanNo).Name = "tPanNo";
		componentResourceManager.ApplyResources(Label9, "Label9");
		((Control)Label9).ForeColor = Color.Black;
		((Control)Label9).Name = "Label9";
		componentResourceManager.ApplyResources(tGstNo, "tGstNo");
		((Control)tGstNo).Name = "tGstNo";
		componentResourceManager.ApplyResources(lblMoNo2, "lblMoNo2");
		((Control)lblMoNo2).ForeColor = Color.Black;
		((Control)lblMoNo2).Name = "lblMoNo2";
		((TextBoxBase)tMobile).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMobile, "tMobile");
		((Control)tMobile).Name = "tMobile";
		((Control)lblMoNo).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblMoNo, "lblMoNo");
		((Control)lblMoNo).ForeColor = Color.Black;
		((Control)lblMoNo).Name = "lblMoNo";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = (Font)componentResourceManager.GetObject("BtnF1.Appearance.Font");
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnF1.Appearance.GradientMode"));
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("BtnF1.AppearanceHovered.Font");
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnF1.AppearanceHovered.GradientMode"));
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = (Font)componentResourceManager.GetObject("BtnF1.AppearancePressed.Font");
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(BtnF1, "BtnF1");
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)Label18).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label18, "Label18");
		((Control)Label18).ForeColor = Color.Black;
		((Control)Label18).Name = "Label18";
		((TextBoxBase)tAcShort).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcShort, "tAcShort");
		((Control)tAcShort).Name = "tAcShort";
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboArea, "cboArea");
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Name = "cboArea";
		((Control)Label17).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label17, "Label17");
		((Control)Label17).ForeColor = Color.Black;
		((Control)Label17).Name = "Label17";
		cboState.AutoCompleteMode = (AutoCompleteMode)2;
		cboState.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboState, "cboState");
		((ListControl)cboState).FormattingEnabled = true;
		((Control)cboState).Name = "cboState";
		((TextBoxBase)tAcMainGr).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcMainGr, "tAcMainGr");
		((Control)tAcMainGr).Name = "tAcMainGr";
		((Control)Label16).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label16, "Label16");
		((Control)Label16).ForeColor = Color.Black;
		((Control)Label16).Name = "Label16";
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboCity, "cboCity");
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Name = "cboCity";
		((TextBoxBase)tAcGrName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tAcGrName, "tAcGrName");
		((Control)tAcGrName).Name = "tAcGrName";
		((TextBoxBase)tAcGrCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcGrCode, "tAcGrCode");
		((Control)tAcGrCode).Name = "tAcGrCode";
		((Control)lblBookCo).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblBookCo, "lblBookCo");
		((Control)lblBookCo).ForeColor = Color.Black;
		((Control)lblBookCo).Name = "lblBookCo";
		componentResourceManager.ApplyResources(Label15, "Label15");
		((Control)Label15).ForeColor = Color.Black;
		((Control)Label15).Name = "Label15";
		((Control)lblCity).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblCity, "lblCity");
		((Control)lblCity).ForeColor = Color.Black;
		((Control)lblCity).Name = "lblCity";
		((Control)Label7).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label7, "Label7");
		((Control)Label7).ForeColor = Color.Black;
		((Control)Label7).Name = "Label7";
		((TextBoxBase)tPinCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPinCode, "tPinCode");
		((Control)tPinCode).Name = "tPinCode";
		((Control)Label4).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		((TextBoxBase)tAddress3).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress3, "tAddress3");
		((Control)tAddress3).Name = "tAddress3";
		((TextBoxBase)tAddress2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress2, "tAddress2");
		((Control)tAddress2).Name = "tAddress2";
		((TextBoxBase)tAddress1).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress1, "tAddress1");
		((Control)tAddress1).Name = "tAddress1";
		((Control)lblPhone).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblPhone, "lblPhone");
		((Control)lblPhone).ForeColor = Color.Black;
		((Control)lblPhone).Name = "lblPhone";
		((Control)lblAdd3).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd3, "lblAdd3");
		((Control)lblAdd3).ForeColor = Color.Black;
		((Control)lblAdd3).Name = "lblAdd3";
		((Control)lblAdd2).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd2, "lblAdd2");
		((Control)lblAdd2).ForeColor = Color.Black;
		((Control)lblAdd2).Name = "lblAdd2";
		((Control)lblAdd1).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd1, "lblAdd1");
		((Control)lblAdd1).ForeColor = Color.Black;
		((Control)lblAdd1).Name = "lblAdd1";
		((TextBoxBase)tAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcName, "tAcName");
		((Control)tAcName).Name = "tAcName";
		((TextBoxBase)tAcCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcCode, "tAcCode");
		((Control)tAcCode).Name = "tAcCode";
		((TextBoxBase)tAcCode).ReadOnly = true;
		((Control)Label2).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		((Control)Label1).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		componentResourceManager.ApplyResources(lblCustIdExpdt, "lblCustIdExpdt");
		((Control)lblCustIdExpdt).ForeColor = Color.Black;
		((Control)lblCustIdExpdt).Name = "lblCustIdExpdt";
		componentResourceManager.ApplyResources(lblLcsNo, "lblLcsNo");
		((Control)lblLcsNo).ForeColor = Color.Black;
		((Control)lblLcsNo).Name = "lblLcsNo";
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		componentResourceManager.ApplyResources(Tab1, "Tab1");
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		componentResourceManager.ApplyResources(TabPanel2, "TabPanel2");
		((Control)TabPanel2).Name = "TabPanel2";
		TabPanel2.TabItem = Tab2;
		((Control)Pnl2).Controls.Add((Control)(object)chkShareHolder);
		((Control)Pnl2).Controls.Add((Control)(object)chkAcMemb);
		((Control)Pnl2).Controls.Add((Control)(object)tPassportNo);
		((Control)Pnl2).Controls.Add((Control)(object)Label27);
		((Control)Pnl2).Controls.Add((Control)(object)tEmail);
		((Control)Pnl2).Controls.Add((Control)(object)lblEmail);
		((Control)Pnl2).Controls.Add((Control)(object)chkWithTdsTax);
		((Control)Pnl2).Controls.Add((Control)(object)nAcSilverLimit);
		((Control)Pnl2).Controls.Add((Control)(object)lblSilverLimit);
		((Control)Pnl2).Controls.Add((Control)(object)nAcGoldLimit);
		((Control)Pnl2).Controls.Add((Control)(object)lblGoldLimit);
		((Control)Pnl2).Controls.Add((Control)(object)nAcAmtLimit);
		((Control)Pnl2).Controls.Add((Control)(object)lblAcAmtLimit);
		((Control)Pnl2).Controls.Add((Control)(object)chkDefaulter);
		((Control)Pnl2).Controls.Add((Control)(object)cboCountry);
		((Control)Pnl2).Controls.Add((Control)(object)Label3);
		((Control)Pnl2).Controls.Add((Control)(object)nFineIntPrc);
		((Control)Pnl2).Controls.Add((Control)(object)lblFineIntPrc);
		((Control)Pnl2).Controls.Add((Control)(object)tAdharNo);
		((Control)Pnl2).Controls.Add((Control)(object)lblAdhar);
		((Control)Pnl2).Controls.Add((Control)(object)tKhataNo);
		((Control)Pnl2).Controls.Add((Control)(object)Label22);
		((Control)Pnl2).Controls.Add((Control)(object)tMobile2);
		((Control)Pnl2).Controls.Add((Control)(object)Label6);
		((Control)Pnl2).Controls.Add((Control)(object)tPhone2);
		((Control)Pnl2).Controls.Add((Control)(object)Label5);
		((Control)Pnl2).Controls.Add((Control)(object)nDpcPrc);
		((Control)Pnl2).Controls.Add((Control)(object)lblDpc);
		((Control)Pnl2).Controls.Add((Control)(object)nCrDay);
		((Control)Pnl2).Controls.Add((Control)(object)lblCrDay);
		((Control)Pnl2).Controls.Add((Control)(object)tRtgsNo);
		((Control)Pnl2).Controls.Add((Control)(object)tBankAcNo);
		((Control)Pnl2).Controls.Add((Control)(object)tBankArea);
		((Control)Pnl2).Controls.Add((Control)(object)tBankName);
		((Control)Pnl2).Controls.Add((Control)(object)Label11);
		((Control)Pnl2).Controls.Add((Control)(object)Label12);
		((Control)Pnl2).Controls.Add((Control)(object)Label13);
		((Control)Pnl2).Controls.Add((Control)(object)Label14);
		componentResourceManager.ApplyResources(Pnl2, "Pnl2");
		((Control)Pnl2).Name = "Pnl2";
		((ButtonBase)chkShareHolder).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkShareHolder, "chkShareHolder");
		((Control)chkShareHolder).ForeColor = Color.Black;
		((Control)chkShareHolder).Name = "chkShareHolder";
		((ButtonBase)chkShareHolder).UseVisualStyleBackColor = false;
		((ButtonBase)chkAcMemb).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkAcMemb, "chkAcMemb");
		((Control)chkAcMemb).ForeColor = Color.Black;
		((Control)chkAcMemb).Name = "chkAcMemb";
		((ButtonBase)chkAcMemb).UseVisualStyleBackColor = false;
		((TextBoxBase)tPassportNo).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPassportNo, "tPassportNo");
		((Control)tPassportNo).Name = "tPassportNo";
		((Control)Label27).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label27, "Label27");
		((Control)Label27).ForeColor = Color.Black;
		((Control)Label27).Name = "Label27";
		((TextBoxBase)tEmail).BackColor = Color.White;
		tEmail.CharacterCasing = (CharacterCasing)2;
		componentResourceManager.ApplyResources(tEmail, "tEmail");
		((Control)tEmail).Name = "tEmail";
		((Control)lblEmail).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblEmail, "lblEmail");
		((Control)lblEmail).ForeColor = Color.Black;
		((Control)lblEmail).Name = "lblEmail";
		((ButtonBase)chkWithTdsTax).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkWithTdsTax, "chkWithTdsTax");
		((Control)chkWithTdsTax).ForeColor = Color.Black;
		((Control)chkWithTdsTax).Name = "chkWithTdsTax";
		((ButtonBase)chkWithTdsTax).UseVisualStyleBackColor = false;
		componentResourceManager.ApplyResources(nAcSilverLimit, "nAcSilverLimit");
		((Control)nAcSilverLimit).Name = "nAcSilverLimit";
		componentResourceManager.ApplyResources(lblSilverLimit, "lblSilverLimit");
		((Control)lblSilverLimit).ForeColor = Color.Black;
		((Control)lblSilverLimit).Name = "lblSilverLimit";
		componentResourceManager.ApplyResources(nAcGoldLimit, "nAcGoldLimit");
		((Control)nAcGoldLimit).Name = "nAcGoldLimit";
		componentResourceManager.ApplyResources(lblGoldLimit, "lblGoldLimit");
		((Control)lblGoldLimit).ForeColor = Color.Black;
		((Control)lblGoldLimit).Name = "lblGoldLimit";
		componentResourceManager.ApplyResources(nAcAmtLimit, "nAcAmtLimit");
		((Control)nAcAmtLimit).Name = "nAcAmtLimit";
		componentResourceManager.ApplyResources(lblAcAmtLimit, "lblAcAmtLimit");
		((Control)lblAcAmtLimit).ForeColor = Color.Black;
		((Control)lblAcAmtLimit).Name = "lblAcAmtLimit";
		((ButtonBase)chkDefaulter).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(chkDefaulter, "chkDefaulter");
		((Control)chkDefaulter).ForeColor = Color.Black;
		((Control)chkDefaulter).Name = "chkDefaulter";
		((ButtonBase)chkDefaulter).UseVisualStyleBackColor = false;
		cboCountry.AutoCompleteMode = (AutoCompleteMode)2;
		cboCountry.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboCountry, "cboCountry");
		((ListControl)cboCountry).FormattingEnabled = true;
		((Control)cboCountry).Name = "cboCountry";
		((Control)Label3).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		componentResourceManager.ApplyResources(nFineIntPrc, "nFineIntPrc");
		((Control)nFineIntPrc).Name = "nFineIntPrc";
		componentResourceManager.ApplyResources(lblFineIntPrc, "lblFineIntPrc");
		((Control)lblFineIntPrc).ForeColor = Color.Black;
		((Control)lblFineIntPrc).Name = "lblFineIntPrc";
		componentResourceManager.ApplyResources(tAdharNo, "tAdharNo");
		((Control)tAdharNo).Name = "tAdharNo";
		componentResourceManager.ApplyResources(lblAdhar, "lblAdhar");
		((Control)lblAdhar).ForeColor = Color.Black;
		((Control)lblAdhar).Name = "lblAdhar";
		componentResourceManager.ApplyResources(tKhataNo, "tKhataNo");
		((Control)tKhataNo).Name = "tKhataNo";
		componentResourceManager.ApplyResources(Label22, "Label22");
		((Control)Label22).ForeColor = Color.Black;
		((Control)Label22).Name = "Label22";
		((TextBoxBase)tMobile2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMobile2, "tMobile2");
		((Control)tMobile2).Name = "tMobile2";
		((Control)Label6).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		((TextBoxBase)tPhone2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPhone2, "tPhone2");
		((Control)tPhone2).Name = "tPhone2";
		((Control)Label5).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label5, "Label5");
		((Control)Label5).ForeColor = Color.Black;
		((Control)Label5).Name = "Label5";
		componentResourceManager.ApplyResources(nDpcPrc, "nDpcPrc");
		((Control)nDpcPrc).Name = "nDpcPrc";
		componentResourceManager.ApplyResources(lblDpc, "lblDpc");
		((Control)lblDpc).ForeColor = Color.Black;
		((Control)lblDpc).Name = "lblDpc";
		componentResourceManager.ApplyResources(nCrDay, "nCrDay");
		((Control)nCrDay).Name = "nCrDay";
		componentResourceManager.ApplyResources(lblCrDay, "lblCrDay");
		((Control)lblCrDay).ForeColor = Color.Black;
		((Control)lblCrDay).Name = "lblCrDay";
		componentResourceManager.ApplyResources(tRtgsNo, "tRtgsNo");
		((Control)tRtgsNo).Name = "tRtgsNo";
		componentResourceManager.ApplyResources(tBankAcNo, "tBankAcNo");
		((Control)tBankAcNo).Name = "tBankAcNo";
		componentResourceManager.ApplyResources(tBankArea, "tBankArea");
		((Control)tBankArea).Name = "tBankArea";
		componentResourceManager.ApplyResources(tBankName, "tBankName");
		((Control)tBankName).Name = "tBankName";
		componentResourceManager.ApplyResources(Label11, "Label11");
		((Control)Label11).ForeColor = Color.Black;
		((Control)Label11).Name = "Label11";
		componentResourceManager.ApplyResources(Label12, "Label12");
		((Control)Label12).ForeColor = Color.Black;
		((Control)Label12).Name = "Label12";
		componentResourceManager.ApplyResources(Label13, "Label13");
		((Control)Label13).ForeColor = Color.Black;
		((Control)Label13).Name = "Label13";
		componentResourceManager.ApplyResources(Label14, "Label14");
		((Control)Label14).ForeColor = Color.Black;
		((Control)Label14).Name = "Label14";
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		componentResourceManager.ApplyResources(Tab2, "Tab2");
		Tab2.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		componentResourceManager.ApplyResources(TabPanel3, "TabPanel3");
		((Control)TabPanel3).Name = "TabPanel3";
		TabPanel3.TabItem = Tab3;
		componentResourceManager.ApplyResources(Pnl3, "Pnl3");
		((Control)Pnl3).Name = "Pnl3";
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		componentResourceManager.ApplyResources(Tab3, "Tab3");
		Tab3.TextAlignment = (eItemAlignment)2;
		((TextBoxBase)tdistrict).BackColor = Color.White;
		componentResourceManager.ApplyResources(tdistrict, "tdistrict");
		((Control)tdistrict).Name = "tdistrict";
		((TextBoxBase)TState).BackColor = Color.White;
		componentResourceManager.ApplyResources(TState, "TState");
		((Control)TState).Name = "TState";
		((TextBoxBase)tCountry).BackColor = Color.White;
		componentResourceManager.ApplyResources(tCountry, "tCountry");
		((Control)tCountry).Name = "tCountry";
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnExcel);
		((Control)PnlBotam).Controls.Add((Control)(object)btnOldYearAcImprt);
		((Control)PnlBotam).Controls.Add((Control)(object)btnAdminSet);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
		((BaseStyleControl)BtnExit).Appearance.Font = (Font)componentResourceManager.GetObject("BtnExit.Appearance.Font");
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnExit, "BtnExit");
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = (Font)componentResourceManager.GetObject("BtnDelete.Appearance.Font");
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnDelete.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnDelete, "BtnDelete");
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = (Font)componentResourceManager.GetObject("BtnCancel.Appearance.Font");
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnCancel.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = (Font)componentResourceManager.GetObject("BtnSave.Appearance.Font");
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnSave, "BtnSave");
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = (Font)componentResourceManager.GetObject("BtnPrint.Appearance.Font");
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnPrint, "BtnPrint");
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnExcel).Appearance.Font = (Font)componentResourceManager.GetObject("btnExcel.Appearance.Font");
		((BaseStyleControl)btnExcel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExcel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExcel).Appearance.Options.UseForeColor = true;
		componentResourceManager.ApplyResources(btnExcel, "btnExcel");
		((BaseControl)btnExcel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExcel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExcel).Name = "btnExcel";
		((BaseButton)btnExcel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnOldYearAcImprt).Appearance.Font = (Font)componentResourceManager.GetObject("btnOldYearAcImprt.Appearance.Font");
		((BaseStyleControl)btnOldYearAcImprt).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnOldYearAcImprt).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnOldYearAcImprt).Appearance.Options.UseForeColor = true;
		componentResourceManager.ApplyResources(btnOldYearAcImprt, "btnOldYearAcImprt");
		((BaseControl)btnOldYearAcImprt).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnOldYearAcImprt).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnOldYearAcImprt).Name = "btnOldYearAcImprt";
		((BaseButton)btnOldYearAcImprt).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnAdminSet).Appearance.Font = (Font)componentResourceManager.GetObject("btnAdminSet.Appearance.Font");
		((BaseStyleControl)btnAdminSet).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnAdminSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnAdminSet).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnAdminSet.ImageOptions).SvgImage = Resources.itemtypestandard;
		componentResourceManager.ApplyResources(btnAdminSet, "btnAdminSet");
		((BaseControl)btnAdminSet).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnAdminSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnAdminSet).Name = "btnAdminSet";
		((BaseButton)btnAdminSet).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		componentResourceManager.ApplyResources(PicImage, "PicImage");
		((Control)PicImage).Name = "PicImage";
		PicImage.TabStop = false;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgC, "BtnImgC");
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgS, "BtnImgS");
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgD, "BtnImgD");
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)GroupBox1).BackColor = Color.Transparent;
		((Control)GroupBox1).Controls.Add((Control)(object)cboSilver);
		((Control)GroupBox1).Controls.Add((Control)(object)nOpSilverFine);
		((Control)GroupBox1).Controls.Add((Control)(object)cboGold);
		((Control)GroupBox1).Controls.Add((Control)(object)nOpGoldFine);
		((Control)GroupBox1).Controls.Add((Control)(object)cboAmt);
		((Control)GroupBox1).Controls.Add((Control)(object)nOpAmt);
		((Control)GroupBox1).Controls.Add((Control)(object)Label21);
		((Control)GroupBox1).Controls.Add((Control)(object)Label19);
		((Control)GroupBox1).Controls.Add((Control)(object)Label10);
		componentResourceManager.ApplyResources(GroupBox1, "GroupBox1");
		((Control)GroupBox1).ForeColor = Color.Maroon;
		((Control)GroupBox1).Name = "GroupBox1";
		GroupBox1.TabStop = false;
		cboSilver.DropDownStyle = (ComboBoxStyle)2;
		componentResourceManager.ApplyResources(cboSilver, "cboSilver");
		((ListControl)cboSilver).FormattingEnabled = true;
		((Control)cboSilver).Name = "cboSilver";
		((TextBoxBase)nOpSilverFine).BackColor = Color.White;
		componentResourceManager.ApplyResources(nOpSilverFine, "nOpSilverFine");
		((Control)nOpSilverFine).Name = "nOpSilverFine";
		cboGold.DropDownStyle = (ComboBoxStyle)2;
		componentResourceManager.ApplyResources(cboGold, "cboGold");
		((ListControl)cboGold).FormattingEnabled = true;
		((Control)cboGold).Name = "cboGold";
		((TextBoxBase)nOpGoldFine).BackColor = Color.White;
		componentResourceManager.ApplyResources(nOpGoldFine, "nOpGoldFine");
		((Control)nOpGoldFine).Name = "nOpGoldFine";
		cboAmt.BackColor = SystemColors.Window;
		cboAmt.DropDownStyle = (ComboBoxStyle)2;
		componentResourceManager.ApplyResources(cboAmt, "cboAmt");
		((ListControl)cboAmt).FormattingEnabled = true;
		((Control)cboAmt).Name = "cboAmt";
		((TextBoxBase)nOpAmt).BackColor = Color.White;
		componentResourceManager.ApplyResources(nOpAmt, "nOpAmt");
		((Control)nOpAmt).Name = "nOpAmt";
		((Control)Label21).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label21, "Label21");
		((Control)Label21).ForeColor = Color.Black;
		((Control)Label21).Name = "Label21";
		((Control)Label19).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label19, "Label19");
		((Control)Label19).ForeColor = Color.Black;
		((Control)Label19).Name = "Label19";
		((Control)Label10).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label10, "Label10");
		((Control)Label10).ForeColor = Color.Black;
		((Control)Label10).Name = "Label10";
		tCustDetl.AcceptsReturn = true;
		((TextBoxBase)tCustDetl).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tCustDetl).BorderStyle = (BorderStyle)0;
		((Control)tCustDetl).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(tCustDetl, "tCustDetl");
		((TextBoxBase)tCustDetl).ForeColor = Color.Navy;
		((Control)tCustDetl).Name = "tCustDetl";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
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
		componentResourceManager.ApplyResources(DGV, "DGV");
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
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DGV).StandardTab = true;
		((Control)PicZoom).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(PicZoom, "PicZoom");
		((Control)PicZoom).Name = "PicZoom";
		PicZoom.TabStop = false;
		componentResourceManager.ApplyResources(mLastVisit, "mLastVisit");
		((Control)mLastVisit).Name = "mLastVisit";
		mLastVisit.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(Label8, "Label8");
		((Control)Label8).ForeColor = Color.Black;
		((Control)Label8).Name = "Label8";
		componentResourceManager.ApplyResources(mLdrDate, "mLdrDate");
		((Control)mLdrDate).Name = "mLdrDate";
		mLdrDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(Label23, "Label23");
		((Control)Label23).ForeColor = Color.Black;
		((Control)Label23).Name = "Label23";
		componentResourceManager.ApplyResources(PnlAdminSet, "PnlAdminSet");
		((Control)PnlAdminSet).Controls.Add((Control)(object)DgvAc);
		((Control)PnlAdminSet).Controls.Add((Control)(object)tPartyGroup);
		((Control)PnlAdminSet).Controls.Add((Control)(object)Label25);
		((Control)PnlAdminSet).Controls.Add((Control)(object)btnClear);
		((Control)PnlAdminSet).Controls.Add((Control)(object)btnUpdate);
		((Control)PnlAdminSet).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAdminSet).Name = "PnlAdminSet";
		((DataGridView)DgvAc).AllowUserToAddRows = false;
		((DataGridView)DgvAc).AllowUserToDeleteRows = false;
		((DataGridView)DgvAc).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DgvAc).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DgvAc).BackgroundColor = Color.Snow;
		((DataGridView)DgvAc).BorderStyle = (BorderStyle)2;
		((DataGridView)DgvAc).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DgvAc).ColumnHeadersDefaultCellStyle = val7;
		componentResourceManager.ApplyResources(DgvAc, "DgvAc");
		((DataGridView)DgvAc).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DgvAc).DefaultCellStyle = val8;
		((DataGridView)DgvAc).EnableHeadersVisualStyles = false;
		((DataGridView)DgvAc).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DgvAc).Name = "DgvAc";
		DgvAc.PaintEnhancedSelection = false;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DgvAc).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DgvAc).RowHeadersVisible = false;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DgvAc).RowsDefaultCellStyle = val10;
		DgvAc.ScrollBarAppearance = (eScrollBarAppearance)0;
		DgvAc.SelectAllSignVisible = false;
		((DataGridView)DgvAc).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DgvAc).StandardTab = true;
		((TextBoxBase)tPartyGroup).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPartyGroup, "tPartyGroup");
		((Control)tPartyGroup).Name = "tPartyGroup";
		componentResourceManager.ApplyResources(Label25, "Label25");
		((Control)Label25).ForeColor = Color.Black;
		((Control)Label25).Name = "Label25";
		((QControl)btnClear).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnClear).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnClear).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnClear).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnClear).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnClear).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnClear).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnClear).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnClear).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)btnClear).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnClear).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnClear).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnClear).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)btnClear).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)btnClear).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnClear).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnClear.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Image = null;
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		((Control)btnClear).Name = "btnClear";
		((QControl)btnUpdate).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnUpdate).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnUpdate).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnUpdate).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnUpdate).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnUpdate).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnUpdate).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnUpdate).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnUpdate).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)btnUpdate).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnUpdate).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnUpdate).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnUpdate).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)btnUpdate).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)btnUpdate).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnUpdate).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnUpdate.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnUpdate.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnUpdate.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnUpdate.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnUpdate.Image = null;
		componentResourceManager.ApplyResources(btnUpdate, "btnUpdate");
		((Control)btnUpdate).Name = "btnUpdate";
		componentResourceManager.ApplyResources(tSerchAll, "tSerchAll");
		((Control)tSerchAll).Name = "tSerchAll";
		tSerchAll.Properties.AllowAutoApply = false;
		((RepositoryItemPopupBase)tSerchAll.Properties).AllowDropDownWhenReadOnly = (DefaultBoolean)1;
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = (Font)componentResourceManager.GetObject("tSerchAll.Properties.Appearance.Font");
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = componentResourceManager.GetString("tSerchAll.Properties.NullValuePrompt");
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)PnlAdminSet);
		((Control)this).Controls.Add((Control)(object)mLdrDate);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)mLastVisit);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tCustDetl);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)tdistrict);
		((Control)this).Controls.Add((Control)(object)TState);
		((Control)this).Controls.Add((Control)(object)tCountry);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_ACCT";
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)Pnl1).PerformLayout();
		((Control)TabPanel2).ResumeLayout(false);
		((Control)Pnl2).ResumeLayout(false);
		((Control)Pnl2).PerformLayout();
		((Control)TabPanel3).ResumeLayout(false);
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((Control)PnlAdminSet).ResumeLayout(false);
		((Control)PnlAdminSet).PerformLayout();
		((ISupportInitialize)DgvAc).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_ACCT_Load(object sender, EventArgs e)
	{
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_185a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1861: Expected O, but got Unknown
		//IL_18d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e0: Expected O, but got Unknown
		//IL_194e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1953: Unknown result type (might be due to invalid IL or missing references)
		//IL_1959: Expected O, but got Unknown
		//IL_19c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d2: Expected O, but got Unknown
		//IL_1a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4b: Expected O, but got Unknown
		//IL_1ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac4: Expected O, but got Unknown
		//IL_1b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3d: Expected O, but got Unknown
		//IL_1bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb6: Expected O, but got Unknown
		//IL_1db7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc6: Expected O, but got Unknown
		//IL_1c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c77: Expected O, but got Unknown
		//IL_1c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca5: Expected O, but got Unknown
		//IL_1cc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd3: Expected O, but got Unknown
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4e: Expected O, but got Unknown
		//IL_1d61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6b: Expected O, but got Unknown
		//IL_1e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e43: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = 'Party' ";
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
			Panel pnl;
			((Control)(pnl = Pnl1)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl1).Width * num);
			((Control)(pnl = Pnl1)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl1).Height * num2);
			((Control)(pnl = Pnl1)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl1).Left * num);
			((Control)(pnl = Pnl1)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl1).Top * num2);
			((Control)(pnl = Pnl2)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl2).Width * num);
			((Control)(pnl = Pnl2)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl2).Height * num2);
			((Control)(pnl = Pnl2)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl2).Left * num);
			((Control)(pnl = Pnl2)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl2).Top * num2);
			((Control)(pnl = Pnl3)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl3).Width * num);
			((Control)(pnl = Pnl3)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl3).Height * num2);
			((Control)(pnl = Pnl3)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl3).Left * num);
			((Control)(pnl = Pnl3)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl3).Top * num2);
			foreach (object control3 in ((Control)Pnl1).Controls)
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
			foreach (object control4 in ((Control)Pnl2).Controls)
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
			foreach (object control5 in ((Control)Pnl3).Controls)
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
			foreach (object control6 in ((Control)TabMenu).Controls)
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
			foreach (object control7 in ((Control)GroupBox1).Controls)
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
			foreach (object control8 in ((Control)PnlAdminSet).Controls)
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
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				TextBox obj8 = tAcGrName;
				object? obj9 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				TextBox obj14 = tAcGrName;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj20 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj21 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				((TextBoxBase)tAcGrName).BackColor = Color.Cornsilk;
			}
			((Control)(pnl = PnlAdminSet)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)PnlAdminSet).Width * num);
			((Control)(pnl = PnlAdminSet)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)PnlAdminSet).Height * num2);
			((Control)(pnl = PnlAdminSet)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)PnlAdminSet).Left * num);
			((Control)(pnl = PnlAdminSet)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl3).Top * num2);
			foreach (object control9 in ((Control)PnlAdminSet).Controls)
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
			((Control)PnlAdminSet).Top = ((Control)lblBook).Top + ((Control)lblBook).Height;
			((Control)PnlAdminSet).Left = ((Control)this).Left;
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcName).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcName).Font;
				try
				{
					foreach (Control control10 in ((Control)this).Controls)
					{
						Control val3 = control10;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is CheckBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control11 in ((Control)Pnl1).Controls)
					{
						object objectValue9 = RuntimeHelpers.GetObjectValue(control11);
						NewLateBinding.LateSet(objectValue9, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control12 in ((Control)Pnl2).Controls)
					{
						object objectValue10 = RuntimeHelpers.GetObjectValue(control12);
						NewLateBinding.LateSet(objectValue10, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control13 in ((Control)Pnl3).Controls)
					{
						object objectValue11 = RuntimeHelpers.GetObjectValue(control13);
						NewLateBinding.LateSet(objectValue11, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control14 in ((Control)TabMenu).Controls)
					{
						object objectValue12 = RuntimeHelpers.GetObjectValue(control14);
						NewLateBinding.LateSet(objectValue12, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control15 in ((Control)GroupBox1).Controls)
					{
						object objectValue13 = RuntimeHelpers.GetObjectValue(control15);
						NewLateBinding.LateSet(objectValue13, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control16 in ((Control)PnlAdminSet).Controls)
					{
						object objectValue14 = RuntimeHelpers.GetObjectValue(control16);
						NewLateBinding.LateSet(objectValue14, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
					TabMenu.SelectedTabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
					TabMenu.TabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control17 in ((Control)PnlBotam).Controls)
					{
						object objectValue15 = RuntimeHelpers.GetObjectValue(control17);
						NewLateBinding.LateSet(objectValue15, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
			}
			cboAmt.Items.Add((object)"Cr");
			cboAmt.Items.Add((object)"Dr");
			cboAmt.SelectedIndex = 0;
			cboGold.Items.Add((object)"Cr");
			cboGold.Items.Add((object)"Dr");
			cboGold.SelectedIndex = 0;
			cboSilver.Items.Add((object)"Cr");
			cboSilver.Items.Add((object)"Dr");
			cboSilver.SelectedIndex = 0;
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				cboGstType.Items.Add((object)"Local");
				cboGstType.Items.Add((object)"Import Supplier");
				cboGstType.Items.Add((object)"Export Customer");
				cboGstType.SelectedIndex = 0;
			}
			else
			{
				cboGstType.Items.Add((object)"Local");
				cboGstType.Items.Add((object)"Inter state");
				cboGstType.SelectedIndex = 0;
			}
			cboAcType.Items.Add((object)"A");
			cboAcType.Items.Add((object)"B");
			cboAcType.Items.Add((object)"C");
			cboAcType.Items.Add((object)"D");
			cboAcType.Items.Add((object)"E");
			cboAcType.SelectedIndex = 0;
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_MOBILE FROM AC_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE,AC_CODE ";
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_CODE,C.AC_NAME,C.AC_MOBILE FROM AC_MAST AS C WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_CODE,A.AC_NAME,A.AC_MOBILE FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_CODE ";
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_MOBILE FROM AC_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY SUBSTRING(AC_CODE,1,2), LEN(AC_CODE),AC_CODE  ";
			}
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			AddCboItem();
			CLEAR_DATA();
			if (Operators.CompareString(DC_Main.MsGrCode, "", false) != 0)
			{
				tAcGrCode.Text = DC_Main.MsGrCode;
				DC_Main.MsGrCode = "";
			}
			if (Operators.CompareString(DC_Main.MsMobileSearchNo, "", false) != 0)
			{
				tMobile.Text = DC_Main.MsMobileSearchNo;
				DC_Main.MsMobileSearchNo = "";
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0))
			{
				((Control)btnAdminSet).Visible = true;
				((Control)chkDefaulter).Visible = true;
				((Control)lblAcAmtLimit).Visible = true;
				((Control)lblGoldLimit).Visible = true;
				((Control)lblSilverLimit).Visible = true;
				((Control)nAcAmtLimit).Visible = true;
				((Control)nAcGoldLimit).Visible = true;
				((Control)nAcSilverLimit).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				lblBookCo.Text = "Po-Box";
				lblMoNo2.Text = "TRN No";
				Label11.Text = "I BAN No";
				Label4.Text = "Contry";
				((Control)Label7).Visible = false;
				((Control)cboDistrict).Visible = false;
				lblAdhar.Text = "Civil Id";
				((Control)LblTranDt).Visible = true;
				((Control)LblTranDt).Top = ((Control)Label7).Top;
				((Control)LblTranDt).Left = ((Control)Label7).Left;
				((Control)mtrnIdDt).Visible = true;
				((Control)mtrnIdDt).Top = ((Control)cboDistrict).Top;
				((Control)mtrnIdDt).Left = ((Control)cboDistrict).Left;
				((Control)lblCustIdExpdt).Visible = true;
				((Control)lblCustIdExpdt).Top = ((Control)cboDistrict).Top;
				((Control)lblCustIdExpdt).Left = ((Control)lblAnvDate).Left;
				((Control)mCustIdDt).Visible = true;
				((Control)mCustIdDt).Top = ((Control)cboDistrict).Top;
				((Control)mCustIdDt).Left = ((Control)cboDistrict).Left + ((Control)mtrnIdDt).Width + ((Control)lblCustIdExpdt).Width;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
			{
				Label16.Text = "eMail";
				((TextBoxBase)tConParcon).MaxLength = 50;
				tConParcon.CharacterCasing = (CharacterCasing)2;
			}
			if (DC_Main.MsHoAcCreat)
			{
				DC_Main.MsHoAcCreat = false;
				((Control)chkHoAcct).Visible = true;
				chkHoAcct.Checked = true;
				((Control)chkHoAcct).Enabled = false;
				DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 5 ORDER BY AC_CODE DESC ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "00101";
				}
				else
				{
					tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
				}
				tAcCode.Text = Strings.Right(tAcCode.Text, 5);
			}
			EntryMode = "A";
			CurActCtrl = (Control)(object)tAcName;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MS_ACCT_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			PicImage.Image = null;
		}
		if (Operators.CompareString(DC_Main.MsAcUpdate, "", false) != 0)
		{
			tAcCode.Text = DC_Main.MsAcUpdate;
			DISPLAY_DATA();
			DC_Main.MsAcUpdate = "";
			AcUpdate = true;
			((Control)tAcName).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.LdrAcMastCode, "", false) != 0)
		{
			tAcCode.Text = DC_Main.LdrAcMastCode;
			DISPLAY_DATA();
			DC_Main.LdrAcMastCode = "";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
			{
				((Control)tAddress1).Focus();
			}
			else
			{
				if (!Information.IsDate((object)mLdrDate.Text))
				{
					mLdrDate.Text = Conversions.ToString(DC_Main.MsSysDate);
				}
				((Control)mLdrDate).Focus();
			}
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((Control)DGV).Refresh();
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsMast);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).MultiSelect = false;
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV).ColumnCount = 3;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(65.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "AC_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(260.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "AC_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				((DataGridView)DGV).Columns[2].Width = (int)Math.Round(95.0 * ColCon);
				((DataGridView)DGV).Columns[2].DataPropertyName = "AC_MOBILE";
				((DataGridView)DGV).Columns[2].HeaderText = "Mobile";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
		}
		MainUser = DC_Main.MCo_User;
		foreach (object control2 in ((Control)Pnl1).Controls)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(control2);
			if ((object)objectValue.GetType() == typeof(TextBox))
			{
				TextBox val2 = (TextBox)objectValue;
				val2.Text = "";
			}
			else if ((object)objectValue.GetType() == typeof(ComboBox))
			{
				ComboBox val3 = (ComboBox)objectValue;
				val3.Text = "";
			}
		}
		foreach (object control3 in ((Control)Pnl2).Controls)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
			if ((object)objectValue2.GetType() == typeof(TextBox))
			{
				TextBox val4 = (TextBox)objectValue2;
				val4.Text = "";
			}
			if ((object)objectValue2.GetType() == typeof(MaskedTextBox))
			{
				MaskedTextBox val5 = (MaskedTextBox)objectValue2;
				val5.Text = "";
			}
		}
		foreach (object control4 in ((Control)Pnl3).Controls)
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
			if ((object)objectValue3.GetType() == typeof(TextBox))
			{
				TextBox val6 = (TextBox)objectValue3;
				val6.Text = "";
			}
		}
		nOpAmt.Text = "";
		nOpGoldFine.Text = "";
		nOpSilverFine.Text = "";
		cboAmt.SelectedIndex = 0;
		cboGold.SelectedIndex = 0;
		cboSilver.SelectedIndex = 0;
		TabMenu.SelectedTab = Tab1;
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		mLastVisit.Text = Conversions.ToString(DateAndTime.Now);
		cboState.Text = DC_Main.MCo_State;
		cboGstType.SelectedIndex = 0;
		cboGstType.SelectedText = "Local";
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK195NEPH", false) == 0)
			{
				Label9.Text = "Cust Id";
			}
			else
			{
				Label9.Text = "ID Number";
			}
		}
		mLdrDate.Text = DC_Main.MMask;
		((DataGridView)DgvAc).DataSource = null;
		((DataGridView)DgvAc).Columns.Clear();
		((DataGridView)DgvAc).Rows.Clear();
		((Control)DgvAc).Refresh();
		((Control)PnlAdminSet).Visible = false;
		chkDefaulter.Checked = false;
		chkAcMemb.Checked = false;
		chkShareHolder.Checked = false;
		EntryMode = "A";
		DC_Main.MsImagePath = "";
		AcUpdate = false;
		((TextBoxBase)nOpAmt).ReadOnly = false;
		((TextBoxBase)nOpGoldFine).ReadOnly = false;
		((TextBoxBase)nOpSilverFine).ReadOnly = false;
		cboAcType.SelectedIndex = 0;
		mBhDate.Text = DC_Main.MMask;
		mAnDate.Text = DC_Main.MMask;
		mBhlDate.Text = DC_Main.MMask;
		mtrnIdDt.Text = DC_Main.MMask;
		mCustIdDt.Text = DC_Main.MMask;
		DGV_CLEAR();
		DGV_FILL();
		Text1.Text = "SEARCH  NAME - MOBILE";
		((TextBoxBase)tAcCode).MaxLength = 8;
		if (chkHoAcct.Checked | (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0))
		{
			if ((Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0) | ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & !chkHoAcct.Checked))
			{
				DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 5  AND RIGHT(AC_CODE,5) > 80000 ORDER BY AC_CODE DESC ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					tAcCode.Text = "80001";
				}
				else
				{
					tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
				}
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 ORDER BY AC_CODE DESC ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "00201";
				}
				else
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[0]["CoCode"]), 2, 5)) + 1.0), "00000");
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 5 AND RIGHT(AC_CODE,5) < 80000 ORDER BY AC_CODE DESC ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					tAcCode.Text = "00101";
				}
				else
				{
					tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
				}
			}
		}
		else if (Conversions.ToDouble(DC_Main.AcLcCodeLen) == 1.0)
		{
			if ((Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0) | (Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0))
			{
				DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 AND RIGHT(AC_CODE,5) > 80000 ORDER BY AC_CODE DESC ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "80001";
				}
				else
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
				}
			}
			else
			{
				if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 AND SUBSTRING(AC_CODE,2,5) < 80000  ORDER BY SUBSTRING(AC_CODE,2,5) DESC ";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 AND SUBSTRING(AC_CODE,2,5) < 80000 ORDER BY SUBSTRING(AC_CODE,2,5) DESC ";
				}
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "00201";
				}
				else
				{
					tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[0]["CoCode"]), 2, 5)) + 1.0), "00000");
				}
			}
		}
		else if ((Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0) | (Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0))
		{
			DC_Main.RsQry = "SELECT AC_CODE As CoCode  From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 7 AND RIGHT(AC_CODE,5) > 80000 ORDER BY AC_CODE DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tAcCode.Text = DC_Main.MLc_code + "80001";
			}
			else
			{
				tAcCode.Text = DC_Main.MLc_code + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "000000");
			}
		}
		else
		{
			DC_Main.RsQry = "SELECT AC_CODE As CoCode  From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 7 AND RIGHT(AC_CODE,5) < 80000 ORDER BY AC_CODE DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tAcCode.Text = DC_Main.MLc_code + "00201";
			}
			else
			{
				tAcCode.Text = DC_Main.MLc_code + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "000000");
			}
		}
		EntryMode = "A";
		if (chkHoAcct.Checked && Operators.CompareString(EntryMode, "A", false) == 0)
		{
			tAcCode.Text = Strings.Right(tAcCode.Text, 5);
		}
		((Control)tAcName).Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT * from AC_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
		}
		else
		{
			DC_Main.RsQry = "SELECT * from AC_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DataTable rshlp = DC_Main.Rshlp;
			if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(rshlp.Rows[0]["LC_CODE"], (object)""), (object)DC_Main.MLc_code, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Ac Code Is Branch With : ", rshlp.Rows[0]["LC_CODE"]), (object)" You Cant Change..."), (MsgBoxStyle)0, (object)null);
				return;
			}
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CODE"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_NAME"], (object)""));
			tAcGrCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_GR"], (object)""));
			DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT * FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_GR = '" + tAcGrCode.Text + "'");
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tAcGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GR_NAME"], (object)""));
			}
			tAcMainGr.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MAIN_GR"], (object)""));
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
			{
				tConParcon.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_EMAIL"], (object)""));
			}
			else
			{
				tConParcon.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PERSON"], (object)""));
			}
			tAcShort.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_SHORT"], (object)""));
			tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD1"], (object)""));
			tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD2"], (object)""));
			tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD3"], (object)""));
			cboCountry.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_COUNTRY"], (object)""));
			cboState.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_STATE"], (object)""));
			cboDistrict.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_DISTRICT"], (object)""));
			cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CITY"], (object)""));
			cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_AREA"], (object)""));
			tPinCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PIN"], (object)""));
			tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PHONE"], (object)""));
			tPhone2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PHONE2"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MOBILE"], (object)""));
			tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MOBILE2"], (object)""));
			tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_EMAIL"], (object)""));
			tGstNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_GSTNO"], (object)""));
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["AC_GST_TYPE"], (object)""), (object)"E", false))
				{
					cboGstType.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["AC_GST_TYPE"], (object)""), (object)"I", false))
				{
					cboGstType.SelectedIndex = 1;
				}
				else
				{
					cboGstType.SelectedIndex = 0;
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["AC_GST_TYPE"], (object)""), (object)"I", false))
			{
				cboGstType.SelectedIndex = 1;
			}
			else
			{
				cboGstType.SelectedIndex = 0;
			}
			tPanNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PANNO"], (object)""));
			tAdharNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADHAR_NO"], (object)""));
			tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_NAME"], (object)""));
			tBankArea.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_AREA"], (object)""));
			tBankAcNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_AC_NO"], (object)""));
			tRtgsNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_RTGS_NO"], (object)""));
			tRefAc.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_REF_CODE"], (object)""));
			tRefAcName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_REF_NAME"], (object)""));
			DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tRefAc.Text + "'");
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tRefAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			}
			mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BR_DATE"], (object)""));
			mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AN_DATE"], (object)""));
			mBhlDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["L_BR_DATE"], (object)""));
			mLastVisit.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LAST_VISIT"], (object)""));
			mLdrDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LAST_DATE"], (object)""));
			mtrnIdDt.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["TRN_DATE"], (object)""));
			mCustIdDt.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["CUST_ID_DATE"], (object)""));
			nCrDay.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CR_DAYS"], (object)""));
			TextBox obj = nDpcPrc;
			DataRow dataRow;
			object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[0])["DPC_PRC"]);
			double num = DC_Main.Fnv(ref Value);
			dataRow["DPC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			obj.Text = Strings.Format((object)num, "0.00");
			TextBox obj2 = nFineIntPrc;
			Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[0])["AC_INT_PRC"]);
			double num2 = DC_Main.Fnv(ref Value);
			dataRow["AC_INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
			obj2.Text = Strings.Format((object)num2, "0.00");
			tKhataNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_KHATA_NO"], (object)""));
			tLcsNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["LCS_NO"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIN_USER"], (object)""));
			tPassportNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["PASSPORT_NO"], (object)""));
			cboAcType.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_TYPE"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["DEFAULTER_AC"], (object)""), (object)"Y", false))
			{
				chkDefaulter.Checked = true;
			}
			else
			{
				chkDefaulter.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["WITH_TDS_TAX"], (object)""), (object)"Y", false))
			{
				chkWithTdsTax.Checked = true;
			}
			else
			{
				chkWithTdsTax.Checked = false;
			}
			TextBox obj3 = nAcAmtLimit;
			Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[0])["AMT_LIMIT"]);
			double num3 = DC_Main.Fnv(ref Value);
			dataRow["AMT_LIMIT"] = RuntimeHelpers.GetObjectValue(Value);
			obj3.Text = Strings.Format((object)num3, "0.00");
			TextBox obj4 = nAcGoldLimit;
			Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[0])["GOLD_LIMIT"]);
			double num4 = DC_Main.Fnv(ref Value);
			dataRow["GOLD_LIMIT"] = RuntimeHelpers.GetObjectValue(Value);
			obj4.Text = Strings.Format((object)num4, "0.000");
			TextBox obj5 = nAcSilverLimit;
			Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[0])["SILVER_LIMIT"]);
			double num5 = DC_Main.Fnv(ref Value);
			dataRow["SILVER_LIMIT"] = RuntimeHelpers.GetObjectValue(Value);
			obj5.Text = Strings.Format((object)num5, "0.000");
			tMainAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIN_AC_CODE"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["AC_WITH_MEMB_COM"], (object)""), (object)"Y", false))
			{
				chkAcMemb.Checked = true;
			}
			else
			{
				chkAcMemb.Checked = false;
			}
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[0]["AC_SHARE_HOLDER_COM"], (object)""), (object)"Y", false))
			{
				chkShareHolder.Checked = true;
			}
			else
			{
				chkShareHolder.Checked = false;
			}
			rshlp = null;
			DC_Main.Rshlp.Clear();
			EntryMode = "E";
			((TextBoxBase)tAcCode).ReadOnly = true;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE='" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  ORDER BY AC_CODE "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DataTable rshlp2 = DC_Main.Rshlp;
			nOpAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[0]["OP_AMT"]), "0.00");
			if (Operators.ConditionalCompareObjectEqual(rshlp2.Rows[0]["OP_SIGN"], (object)"C", false))
			{
				cboAmt.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(rshlp2.Rows[0]["OP_SIGN"], (object)"D", false))
			{
				cboAmt.SelectedIndex = 1;
			}
			nOpGoldFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[0]["FINE_BAL"]), "0.000");
			if (Operators.ConditionalCompareObjectEqual(rshlp2.Rows[0]["FINE_SIGN"], (object)"C", false))
			{
				cboGold.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(rshlp2.Rows[0]["FINE_SIGN"], (object)"D", false))
			{
				cboGold.SelectedIndex = 1;
			}
			nOpSilverFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[0]["SL_FINE_BAL"]), "0.000");
			if (Operators.ConditionalCompareObjectEqual(rshlp2.Rows[0]["SL_FINE_SIGN"], (object)"C", false))
			{
				cboSilver.SelectedIndex = 0;
			}
			else if (Operators.ConditionalCompareObjectEqual(rshlp2.Rows[0]["SL_FINE_SIGN"], (object)"D", false))
			{
				cboSilver.SelectedIndex = 1;
			}
			rshlp2 = null;
			((TextBoxBase)nOpAmt).ReadOnly = true;
			((TextBoxBase)nOpGoldFine).ReadOnly = true;
			((TextBoxBase)nOpSilverFine).ReadOnly = true;
			DC_Main.Rshlp.Clear();
		}
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + tAcCode.Text;
			}
			else
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
			}
		}
		else
		{
			DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
		}
		DC_Main.MsImageType = "AcImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			PicImage.Image = null;
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

	private void MS_ACCT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_ACCT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void tAcCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tAcName.Text, "", false) == 0)
		{
			return;
		}
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " AC_CODE = '" + tAcCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["AC_NAME"], (object)tAcName.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Ac Code already Exist in  '", dataView[0]["AC_NAME"]), (object)"'  Party Name...Please Change Party Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tAcCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		if (NewAcCrat)
		{
			return;
		}
		checked
		{
			if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH  NAME - MOBILE", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH  NAME - MOBILE", false) != 0))
			{
				DGV_CLEAR();
				((DataGridView)DGV).ColumnCount = 3;
				DataView dataView = new DataView(RsMast);
				dataView.RowFilter = "AC_NAME Like  '" + Text1.Text + "%' OR AC_MOBILE Like  '" + Text1.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).AutoGenerateColumns = false;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(65.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = "AC_CODE";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(260.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "AC_NAME";
					((DataGridView)DGV).Columns[2].Width = (int)Math.Round(95.0 * ColCon);
					((DataGridView)DGV).Columns[2].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH  NAME - MOBILE", false) == 0)
		{
			Text1.Text = "";
			NewAcCrat = false;
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
		DC_Main.RptName = "AcMast";
		DC_Main.MsCustWappNo = "919879966455";
		UT_REPORT uT_REPORT = new UT_REPORT();
		((Control)uT_REPORT).Show();
		((Control)uT_REPORT).Focus();
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13)
		{
			tAcCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tAcName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tAcCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tAcName).Focus();
	}

	private void MS_ACCT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Invalid comparison between Unknown and I4
		if (((int)e.KeyCode == 69) & e.Control)
		{
			((TextBoxBase)tAcCode).ReadOnly = false;
			((Control)tAcCode).Enabled = true;
			((TextBoxBase)tAcCode).BackColor = Color.MistyRose;
			((Control)tAcCode).Focus();
		}
		if (((int)e.KeyCode == 79) & e.Control)
		{
			((Control)btnExcel).Visible = true;
		}
		if (((int)e.KeyCode == 89) & e.Control)
		{
			((Control)btnOldYearAcImprt).Visible = true;
		}
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
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
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
				}
				DISPLAY_DATA();
				EntryMode = "E";
				((Control)tAcName).Focus();
			}
		}
		else if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tAcName.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Party Name ...", (MsgBoxStyle)0, (object)null);
				((Control)tAcName).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void tAddress1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAddress2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAddress3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tCountry_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void TState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPinCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPhone_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tConParcon).Focus();
		}
	}

	private void tPhone2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tmobile_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tMobile.Text, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT AC_NAME,LC_CODE,AC_CODE FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_MOBILE = '" + tMobile.Text + "' AND AC_CODE <> '" + tAcCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Mobile No With = ", DC_Main.Rshlp.Rows[0]["AC_NAME"]), (object)" Party Name  And AcCode = "), DC_Main.Rshlp.Rows[0]["AC_CODE"]), (object)"  Branch With  "), DC_Main.Rshlp.Rows[0]["LC_CODE"]), (object)"  Branch ..."), (MsgBoxStyle)0, (object)null);
					tMobile.Text = "";
					return;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_MOBILE = '" + tMobile.Text + "' AND AC_CODE <> '" + tAcCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Mobile No = ", DC_Main.Rshlp.Rows[0]["AC_NAME"]), (object)" "), (object)" With this Account ....."), (MsgBoxStyle)0, (object)null);
					return;
				}
			}
		}
		SendKeys.Send("{tab}");
	}

	private void tMobile2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tMobile2.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE <> '" + tAcCode.Text + "' AND (AC_MOBILE2 = '" + tMobile2.Text + "' or AC_MOBILE = '" + tMobile2.Text + "') AND (AC_MOBILE2 <> '' OR AC_MOBILE <> '')";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Short Name = ", DC_Main.Rshlp.Rows[0]["AC_NAME"]), (object)" "), (object)" With this Account ....."), (MsgBoxStyle)0, (object)null);
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tEmail_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tJudrection_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tGstNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tGstNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT * FROM STATE_MAST WHERE STATE_CODE = '" + Strings.Mid(tGstNo.Text, 1, 2) + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboState.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STATE_NAME"], (object)""));
				DC_Main.RsQry = "SELECT CO_STATE_CODE FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual((object)Strings.Mid(tGstNo.Text, 1, 2), Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_STATE_CODE"], (object)""), false))
					{
						cboGstType.SelectedIndex = 0;
					}
					else
					{
						cboGstType.SelectedIndex = 1;
					}
				}
			}
		}
		else
		{
			DC_Main.RsQry = "SELECT CO_STATE FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboState.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_STATE"], (object)""));
			}
		}
		SendKeys.Send("{tab}");
	}

	private void tPanNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_GR = '" + tAcGrCode.Text + "'";
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
					tAcGrCode.Text = DC_Main.ColValue[0];
					tAcGrName.Text = DC_Main.ColValue[1];
					tAcMainGr.Text = DC_Main.ColValue[3];
				}
				((Control)tAcGrCode).Focus();
			}
		}
		else
		{
			tAcGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GR_NAME"], (object)""));
			tAcMainGr.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MAIN_GR"], (object)""));
			((Control)cboAcType).Focus();
		}
	}

	private void tConParcon_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void AddCboItem()
	{
		DC_Main.RsQry = "SELECT AC_COUNTRY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_COUNTRY ORDER BY AC_COUNTRY ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCountry.Items.Clear();
				int count = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count)
				{
					cboCountry.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_COUNTRY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCountry.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_STATE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_STATE <> '' GROUP BY AC_STATE   UNION ALL SELECT STATE_NAME as AC_STATE FROM STATE_MAST GROUP BY STATE_NAME ORDER BY AC_STATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboState.Items.Clear();
				int count2 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count2)
				{
					cboState.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_STATE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboState.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_DISTRICT FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_DISTRICT <> '' GROUP BY AC_DISTRICT ORDER BY AC_DISTRICT ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboDistrict.Items.Clear();
				int count3 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count3)
				{
					cboDistrict.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_DISTRICT"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboDistrict.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int count4 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count4)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_CITY"], (object)""));
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
				int count5 = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count5)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
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

	private void cboCountry_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)mtrnIdDt).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
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

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcShort_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Invalid comparison between Unknown and I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112 && Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT AC_SHORT As ShortL,AC_NAME As AcNameL,AC_ADD1 As AddressL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_SHORT <> '' ORDER BY AC_SHORT";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[9];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				((Control)tAcShort).Focus();
			}
		}
		else
		{
			if ((int)e.KeyCode != 13)
			{
				return;
			}
			if (Operators.CompareString(tAcShort.Text, "", false) != 0)
			{
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE <> '" + tAcCode.Text + "' AND AC_SHORT = '" + tAcShort.Text + "' AND AC_SHORT <> ''";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Short Name = ", DC_Main.Rshlp.Rows[0]["AC_NAME"]), (object)" "), (object)" With this Account ....."), (MsgBoxStyle)0, (object)null);
				}
				else
				{
					SendKeys.Send("{tab}");
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void tAcName_TextChanged(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataView dataView = default(DataView);
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
						tCustDetl.Text = tAcCode.Text + " - " + tAcName.Text + "  ( Mo - " + tMobile.Text + " )";
						goto IL_005d;
					case 715:
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
								goto IL_005d;
							case 3:
								goto IL_007a;
							case 4:
								goto IL_0083;
							case 5:
								goto IL_00a4;
							case 7:
							case 8:
								goto IL_00b4;
							case 9:
								goto IL_00bd;
							case 10:
								goto IL_00e2;
							case 11:
								goto IL_00ec;
							case 12:
								goto IL_00fc;
							case 13:
								goto IL_0121;
							case 14:
								goto IL_0137;
							case 15:
								goto IL_0147;
							case 16:
								goto IL_0177;
							case 17:
								goto IL_0196;
							case 18:
								goto IL_01c6;
							case 19:
								goto IL_01e5;
							case 20:
								goto IL_0215;
							case 21:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 6:
							case 22:
							case 23:
							case 24:
							case 25:
							case 26:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_01c6:
						num2 = 18;
						((DataGridView)DGV).Columns[1].DataPropertyName = "AC_NAME";
						goto IL_01e5;
						IL_01e5:
						num2 = 19;
						((DataGridView)DGV).Columns[2].Width = (int)Math.Round(95.0 * ColCon);
						goto IL_0215;
						IL_0196:
						num2 = 17;
						((DataGridView)DGV).Columns[1].Width = (int)Math.Round(260.0 * ColCon);
						goto IL_01c6;
						IL_0215:
						num2 = 20;
						((DataGridView)DGV).Columns[2].DataPropertyName = "AC_MOBILE";
						break;
						IL_005d:
						num2 = 2;
						if (Operators.CompareString(EntryMode, "A", false) != 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_007a;
						IL_007a:
						num2 = 3;
						NewAcCrat = true;
						goto IL_0083;
						IL_0083:
						num2 = 4;
						if (Operators.CompareString(tAcName.Text, "", false) == 0)
						{
							goto IL_00a4;
						}
						goto IL_00b4;
						IL_00a4:
						num2 = 5;
						DGV_FILL();
						goto end_IL_0001_3;
						IL_00b4:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00bd;
						IL_00bd:
						num2 = 9;
						if (Operators.CompareString(tAcName.Text, "", false) == 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_00e2;
						IL_00e2:
						num2 = 10;
						DGV_CLEAR();
						goto IL_00ec;
						IL_00ec:
						num2 = 11;
						dataView = new DataView(RsMast);
						goto IL_00fc;
						IL_00fc:
						num2 = 12;
						dataView.RowFilter = "AC_NAME Like  '" + tAcName.Text + "%' ";
						goto IL_0121;
						IL_0121:
						num2 = 13;
						if (dataView.Count <= 0)
						{
							goto end_IL_0001_3;
						}
						goto IL_0137;
						IL_0137:
						num2 = 14;
						((DataGridView)DGV).AutoGenerateColumns = false;
						goto IL_0147;
						IL_0147:
						num2 = 15;
						((DataGridView)DGV).Columns[0].Width = (int)Math.Round(65.0 * ColCon);
						goto IL_0177;
						IL_0177:
						num2 = 16;
						((DataGridView)DGV).Columns[0].DataPropertyName = "AC_CODE";
						goto IL_0196;
						end_IL_0001_2:
						break;
					}
					num2 = 21;
					((DataGridView)DGV).DataSource = dataView;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 715;
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

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tRefAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
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
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
						tRefAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				tRefAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				((Control)nOpAmt).Focus();
			}
		}
		else
		{
			((Control)nOpAmt).Focus();
		}
	}

	private void tAcName_KeyUp(object sender, KeyEventArgs e)
	{
	}

	private void mBhDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mAnDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mBhlDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tCrDay_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nDpcPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDpcPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDpcPrc.Text)), "0.00");
			SendKeys.Send("{tab}");
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankAcNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRtgsNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_Validating(object sender, CancelEventArgs e)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK081NSVK", false) == 0)
		{
			return;
		}
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " AC_NAME = '" + tAcName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["AC_CODE"], (object)tAcCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Ac Name already Exist in  '", dataView[0]["AC_CODE"]), (object)"'  Ac Code... Please Change Account Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tAcName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_132b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_149f: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0 && Operators.CompareString(cboCity.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert City Then Try....", (MsgBoxStyle)0, (object)null);
			((Control)cboCity).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0 && Operators.CompareString(tMobile.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Mobile No Because This Ac With Multi Branch Acconut so Mobile No Is Mandatory....", (MsgBoxStyle)0, (object)null);
			((Control)tMobile).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM037NEKU", false) == 0 && ((Operators.CompareString(cboCity.Text, "", false) == 0) | (Operators.CompareString(tMobile.Text, "", false) == 0)))
		{
			Interaction.MsgBox((object)"Please Insert City and Mobile no Then Try....", (MsgBoxStyle)0, (object)null);
			((Control)tMobile).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM425NEKU", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				if ((Conversion.Val(tAcCode.Text) < 100.0) & !DletHoAc)
				{
					Interaction.MsgBox((object)" You Change Software Default Account With Main Location....", (MsgBoxStyle)0, (object)null);
					return;
				}
			}
			else
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ007NPKJ", false) != 0 && ((Strings.Len(tAcCode.Text) == 5) & (((TextBoxBase)tAcCode).BackColor != Color.MistyRose)) && !DletHoAc)
				{
					Interaction.MsgBox((object)" You Can't Change Software Default Account....", (MsgBoxStyle)0, (object)null);
					return;
				}
				if (((Strings.Len(tAcCode.Text) == 5) & (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)) && !DletHoAc)
				{
					Interaction.MsgBox((object)" You Change Software Default Account With Main Location....", (MsgBoxStyle)0, (object)null);
					return;
				}
			}
		}
		if ((Operators.CompareString(tAcCode.Text, "", false) == 0) | (Operators.CompareString(tAcName.Text, "", false) == 0) | (Operators.CompareString(tAcGrCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Enter Party Name and Account group Detail", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)tAcName).Focus();
			return;
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM AC_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 5 AND RIGHT(AC_CODE,5) < 80000 ORDER BY AC_CODE DESC ";
				}
				else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 ORDER BY AC_CODE DESC ";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 AND RIGHT(AC_CODE,5) < 80000 ORDER BY AC_CODE DESC ";
				}
				DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
					}
					else if (Conversions.ToDouble(DC_Main.AcLcCodeLen) == 1.0)
					{
						tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
					}
					else
					{
						tAcCode.Text = DC_Main.MLc_code + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
					}
				}
			}
		}
		Tran = null;
		try
		{
			if (DC_Main.Dc.State != ConnectionState.Open)
			{
				DC_Main.Dc.Open();
			}
			Tran = DC_Main.Dc.BeginTransaction();
			DC_Main.RsQry = "DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
			Module_Save.ExeQuteDcSave(DC_Main.RsQry, Tran);
			DC_Main.RsQry = "SELECT * FROM AC_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DataTable dataTable = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Tran);
			Module_Save.MsInsertDataSave(Tran);
			DataRow dataRow = dataTable.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["AC_CODE"] = tAcCode.Text;
			dataRow["AC_NAME"] = tAcName.Text;
			dataRow["AC_GR"] = tAcGrCode.Text;
			dataRow["AC_MAIN_GR"] = tAcMainGr.Text;
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
			{
				dataRow["AC_EMAIL"] = tConParcon.Text;
				dataRow["AC_PERSON"] = "";
			}
			else
			{
				dataRow["AC_PERSON"] = tConParcon.Text;
			}
			dataRow["AC_SHORT"] = tAcShort.Text;
			dataRow["AC_ADD1"] = tAddress1.Text;
			dataRow["AC_ADD2"] = tAddress2.Text;
			dataRow["AC_ADD3"] = tAddress3.Text;
			dataRow["AC_COUNTRY"] = cboCountry.Text;
			dataRow["AC_STATE"] = cboState.Text;
			dataRow["AC_DISTRICT"] = cboDistrict.Text;
			dataRow["AC_CITY"] = cboCity.Text;
			dataRow["AC_PIN"] = tPinCode.Text;
			dataRow["AC_AREA"] = cboArea.Text;
			dataRow["AC_ADHAR_NO"] = tAdharNo.Text;
			dataRow["AC_PHONE"] = tPhone.Text;
			dataRow["AC_PHONE2"] = tPhone2.Text;
			dataRow["AC_MOBILE"] = tMobile.Text;
			dataRow["AC_MOBILE2"] = tMobile2.Text;
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) != 0)
			{
				dataRow["AC_EMAIL"] = tEmail.Text;
			}
			dataRow["AC_GSTNO"] = tGstNo.Text;
			if (cboGstType.SelectedIndex == 1)
			{
				dataRow["AC_GST_TYPE"] = "I";
			}
			else
			{
				dataRow["AC_GST_TYPE"] = "L";
			}
			dataRow["AC_PANNO"] = tPanNo.Text;
			dataRow["BANK_NAME"] = tBankName.Text;
			dataRow["BANK_AREA"] = tBankArea.Text;
			dataRow["BANK_AC_NO"] = tBankAcNo.Text;
			dataRow["BANK_RTGS_NO"] = tRtgsNo.Text;
			dataRow["AC_REF_CODE"] = tRefAc.Text;
			dataRow["AC_REF_NAME"] = tRefAcName.Text;
			dataRow["BR_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mBhDate.Text), (object)DBNull.Value, (object)mBhDate.Text));
			dataRow["AN_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mAnDate.Text), (object)DBNull.Value, (object)mAnDate.Text));
			dataRow["L_BR_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mBhlDate.Text), (object)DBNull.Value, (object)mBhlDate.Text));
			dataRow["LAST_VISIT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mLastVisit.Text), (object)DBNull.Value, (object)mLastVisit.Text));
			dataRow["LAST_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mLdrDate.Text), (object)DBNull.Value, (object)mLdrDate.Text));
			dataRow["AC_CR_DAYS"] = Conversion.Val(nCrDay.Text);
			dataRow["DPC_PRC"] = Conversion.Val(nDpcPrc.Text);
			dataRow["AC_INT_PRC"] = Conversion.Val(nFineIntPrc.Text);
			dataRow["AC_KHATA_NO"] = tKhataNo.Text;
			dataRow["LCS_NO"] = tLcsNo.Text;
			dataRow["MAIN_USER"] = MainUser;
			dataRow["DATA_TRFR"] = "N";
			dataRow["AC_TYPE"] = Strings.Mid(cboAcType.Text, 1, 1);
			dataRow["VISIT_TRAN"] = "AC";
			dataRow["MAIN_AC_CODE"] = tMainAcCode.Text;
			dataRow["DEFAULTER_AC"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkDefaulter.Checked, (object)"Y", (object)"N"));
			dataRow["WITH_TDS_TAX"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkWithTdsTax.Checked, (object)"Y", (object)"N"));
			dataRow["PASSPORT_NO"] = tPassportNo.Text;
			dataRow["TRN_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mtrnIdDt.Text), (object)DBNull.Value, (object)mtrnIdDt.Text));
			dataRow["CUST_ID_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mCustIdDt.Text), (object)DBNull.Value, (object)mCustIdDt.Text));
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK065NEVK", false) == 0))
			{
				if ((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(tAcGrCode.Text, "20", false) == 0))
				{
					dataRow["AMT_LIMIT"] = 10;
				}
				else
				{
					dataRow["AMT_LIMIT"] = Conversion.Val(nAcAmtLimit.Text);
				}
			}
			else
			{
				dataRow["AMT_LIMIT"] = Conversion.Val(nAcAmtLimit.Text);
			}
			dataRow["GOLD_LIMIT"] = Conversion.Val(nAcGoldLimit.Text);
			dataRow["SILVER_LIMIT"] = Conversion.Val(nAcSilverLimit.Text);
			dataRow["AC_WITH_MEMB_COM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkAcMemb.Checked, (object)"Y", (object)"N"));
			dataRow["AC_SHARE_HOLDER_COM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkShareHolder.Checked, (object)"Y", (object)"N"));
			dataTable.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
			dataTable.Clear();
			Tran.Commit();
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				string text = ((Operators.CompareString(DC_Main.MsDataType, "C", false) != 0) ? DC_Main.MsDataType : "A");
				if (Conversion.Val(nOpAmt.Text) + Conversion.Val(nOpGoldFine.Text) + Conversion.Val(nOpSilverFine.Text) != 0.0)
				{
					DC_Main.RsQry = "DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + text + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM OP_DATA  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + text + "' ";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow2 = dataTable2.NewRow();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["CO_YEAR"] = DC_Main.MCo_year;
					dataRow2["CO_BOOK"] = "000";
					dataRow2["VCH_NO"] = "00000";
					dataRow2["AC_CODE"] = tAcCode.Text;
					dataRow2["OP_AMT"] = Conversion.Val(nOpAmt.Text);
					dataRow2["OP_SIGN"] = Strings.Mid(cboAmt.Text, 1, 1);
					dataRow2["FINE_BAL"] = Conversion.Val(nOpGoldFine.Text);
					dataRow2["FINE_SIGN"] = Strings.Mid(cboGold.Text, 1, 1);
					dataRow2["SL_FINE_BAL"] = Conversion.Val(nOpSilverFine.Text);
					dataRow2["SL_FINE_SIGN"] = Strings.Mid(cboSilver.Text, 1, 1);
					dataRow2["DATA_TYPE"] = text;
					dataRow2["DATA_TRFR"] = "Y";
					dataRow2["MAIN_USER"] = MainUser;
					dataTable2.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
					dataTable2.Clear();
					DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = '" + DC_Main.MsDataType + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Ac_Ledr.AcOp_Ledr(tAcCode.Text, text);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			try
			{
				Tran.Rollback();
				Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
				ProjectData.ClearProjectError();
				return;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Interaction.MsgBox((object)("Rollback Failed: " + ex4.Message), (MsgBoxStyle)0, (object)null);
				ProjectData.ClearProjectError();
				return;
			}
		}
		DC_Main.RsQry = "DELETE FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
		DC_Main.ExeQuteMc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM AC_MAST_SRNO  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' ";
		DataTable dataTable3 = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow3 = dataTable3.NewRow();
		dataRow3["CO_CODE"] = DC_Main.MCo_code;
		dataRow3["LC_CODE"] = DC_Main.MLc_code;
		dataRow3["AC_CODE"] = tAcCode.Text;
		dataRow3["AC_NAME"] = tAcName.Text;
		dataRow3["AC_GR"] = tAcGrCode.Text;
		dataRow3["MAIN_USER"] = MainUser;
		dataTable3.Rows.Add(dataRow3);
		((DbDataAdapter)(object)DC_Main.Da).Update(dataTable3);
		dataTable3.Clear();
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCode = tAcCode.Text;
			DC_Main.MsName = tAcName.Text;
			((Form)this).Close();
			return;
		}
		if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_MOBILE FROM AC_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE,AC_CODE ";
		}
		else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
		{
			DC_Main.RsQry = "SELECT C.AC_CODE,C.AC_NAME,C.AC_MOBILE FROM AC_MAST AS C WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_CODE,A.AC_NAME,A.AC_MOBILE FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_CODE ";
		}
		else
		{
			DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_MOBILE FROM AC_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY SUBSTRING(AC_CODE,1,2), LEN(AC_CODE),AC_CODE  ";
		}
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (AcUpdate)
		{
			AcUpdate = false;
			((Form)this).Close();
		}
		else
		{
			CLEAR_DATA();
			DGV_FILL();
			AddCboItem();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Invalid comparison between Unknown and I4
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select AcCode For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_NO <> '00000' AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Can't Delete Record This Party Code Use in Transection....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			if ((Conversion.Val(tAcCode.Text) < 100.0) & !DletHoAc)
			{
				Interaction.MsgBox((object)" You Cant Delete Default Account ....", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		else if ((Strings.Len(tAcCode.Text) == 5) & (((TextBoxBase)tAcCode).BackColor != Color.MistyRose))
		{
			Interaction.MsgBox((object)" You Can't Delete Software Default Account....", (MsgBoxStyle)0, (object)null);
		}
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Account now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM AC_MAST_SRNO WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM AC_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND AC_CODE = '" + tAcCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_CODE,C.AC_NAME,C.AC_MOBILE  FROM AC_MAST AS C WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_CODE,A.AC_NAME,A.AC_MOBILE FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_CODE ";
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_MOBILE FROM AC_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY SUBSTRING(AC_CODE,1,2), LEN(AC_CODE),AC_CODE  ";
			}
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void MS_ACCT_Closed(object sender, EventArgs e)
	{
		DC_Main.MsImagePath = "";
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL,", Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0, (object)"AC_SHORT", (object)"''")), (object)" As ShortL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL,MAIN_USER As UserL FROM AC_MAST WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' ORDER BY AC_NAME"));
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 75.0;
		DC_Main.ColWidth[4] = 300.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 110.0;
		DC_Main.ColWidth[7] = 120.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
			}
			DISPLAY_DATA();
			EntryMode = "E";
			((Control)tAcName).Focus();
		}
	}

	private void NOpAmt_TextChanged(object sender, EventArgs e)
	{
	}

	private void nOpAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nOpAmt.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nOpAmt.Text = Strings.Format((object)Convert.ToDouble(nOpAmt.Text), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void cboAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nOpGoldFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nOpGoldFine.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nOpGoldFine.Text = Strings.Format((object)Convert.ToDouble(nOpGoldFine.Text), "0.000");
			SendKeys.Send("{TAB}");
		}
	}

	private void CboGold_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void cboGold_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void NOpSilverFine_TextChanged(object sender, EventArgs e)
	{
	}

	private void nOpSilverFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nOpSilverFine.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nOpSilverFine.Text = Strings.Format((object)Convert.ToDouble(nOpSilverFine.Text), "0.000");
			SendKeys.Send("{TAB}");
		}
	}

	private void CboSilver_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void cboSilver_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			TabMenu.SelectNextTab();
			((Control)tMobile2).Focus();
		}
	}

	private void PicImage_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicImage.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void PicZoom_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = null;
		((Control)PicZoom).Dock = (DockStyle)0;
		((Control)PicZoom).Visible = false;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
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
					((FileDialog)DlgOpen).Filter = "JPEG (*.jpg)|*.jpg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
					{
						goto end_IL_0001;
					}
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + tAcCode.Text;
						}
						else
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
						}
					}
					else
					{
						DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
					}
					DC_Main.MsImageType = "AcImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0 && Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						Image image;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						PicImage.Image = image;
						((Control)PicImage).Refresh();
						GC.Collect();
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
					PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
					goto end_IL_0001;
				case 556:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)"Please Check Len Connection...You Cant Save Image...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 556;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
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
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + tAcCode.Text;
						}
						else
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
						}
					}
					else
					{
						DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
					}
					DC_Main.MsImageType = "AcImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image.Dispose();
						PicImage.Image = null;
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				case 374:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)"Please Check Len Connection...You Cant Save Image...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 374;
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

	private void cboGstType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)chkHoAcct).Visible = true;
		DletHoAc = true;
	}

	private void chkHoAcct_CheckedChanged(object sender, EventArgs e)
	{
		if (chkHoAcct.Checked && Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT AC_CODE As CoCode From AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 5 ORDER BY AC_CODE DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "00101";
			}
			else
			{
				tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
			}
			tAcCode.Text = Strings.Right(tAcCode.Text, 5);
		}
	}

	private void mLastVisit_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mLastVisit;
			DC_Main.SetDate(ref MsDate);
			mLastVisit = MsDate;
			if (!DC_Main.RongDate)
			{
				((Control)BtnSave).Focus();
			}
		}
	}

	private void mLastVisit_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mLastVisit).SelectionStart = 0;
		((TextBoxBase)mLastVisit).SelectionLength = Strings.Len(mLastVisit.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
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
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
					{
						goto end_IL_0001;
					}
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + tAcCode.Text;
						}
						else
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
						}
					}
					else
					{
						DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
					}
					DC_Main.MsImageType = "AcImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image.Dispose();
						PicImage.Image = null;
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					goto end_IL_0001;
				case 375:
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
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 375;
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

	private void tKhataNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void MLdrDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mLdrDate;
			DC_Main.SetDate(ref MsDate);
			mLdrDate = MsDate;
			if (!DC_Main.RongDate)
			{
				((Control)BtnSave).Focus();
			}
		}
	}

	private void MLdrDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mLdrDate).SelectionStart = 0;
		((TextBoxBase)mLdrDate).SelectionLength = Strings.Len(mLdrDate.Text);
	}

	private void BtnAdd_Click(object sender, EventArgs e)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_AREA AS AreaL,AC_ADD1 AS AddressL,AC_CITY AS CityL FROM ADD_MAST   WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY AC_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 200.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			DC_Main.RsQry = "select * from ADD_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND  AC_CODE = '" + DC_Main.ColValue[1] + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_AREA"], (object)""));
				tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)""));
				tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD2"], (object)""));
				tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD3"], (object)""));
				cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)""));
				tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_PHONE"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE2"], (object)""));
				tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_EMAIL"], (object)""));
				mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BR_DATE"], (object)""));
				mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AN_DATE"], (object)""));
				((Control)tAcName).Focus();
			}
		}
	}

	private void BtnMemb_Click(object sender, EventArgs e)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT MEMB_NAME As AcNameL,MEMB_CODE as MembCodeL, SCHM_CODE AS SchmCodeL,AC_ADD1 AS AddressL,AC_CITY AS CityL FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY MEMB_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 275.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			DC_Main.RsQry = "select * from AD_MEMB where CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND MEMB_CODE = '" + DC_Main.ColValue[1] + "' AND SCHM_CODE = '" + DC_Main.ColValue[2] + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MEMB_NAME"], (object)""));
				cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_AREA"], (object)""));
				tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)""));
				tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD2"], (object)""));
				tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD3"], (object)""));
				cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)""));
				tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_PHONE"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE2"], (object)""));
				tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_EMAIL"], (object)""));
				mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BIRTH_DATE"], (object)""));
				mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ANV_DATE"], (object)""));
				((Control)tAcName).Focus();
			}
		}
	}

	private void tRefAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)mBhDate).Focus();
		}
	}

	private void tAdharNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private static DataTable ImportExceltoDatatable(string filepath)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		DataTable result;
		try
		{
			DataSet dataSet = new DataSet();
			string text = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
			OleDbConnection val = new OleDbConnection(text ?? "");
			val.Open();
			object objectValue = RuntimeHelpers.GetObjectValue(val.GetSchema("Tables").Rows[0]["TABLE_NAME"]);
			string text2 = $"SELECT * FROM [{RuntimeHelpers.GetObjectValue(objectValue)}]";
			OleDbDataAdapter val2 = new OleDbDataAdapter(text2, val);
			((DbDataAdapter)(object)val2).Fill(dataSet);
			dataTable = dataSet.Tables[0];
			result = dataTable;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)Information.Err().Description, (MsgBoxStyle)16, (object)null);
			result = dataTable;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void btnExcel_Click(object sender, EventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		string text = default(string);
		string text2 = default(string);
		int num5 = default(int);
		string text3 = default(string);
		string text4 = default(string);
		string text5 = default(string);
		string text6 = default(string);
		string text7 = default(string);
		string text8 = default(string);
		string text9 = default(string);
		string text10 = default(string);
		string text11 = default(string);
		string text12 = default(string);
		string text13 = default(string);
		string text14 = default(string);
		string text15 = default(string);
		string text16 = default(string);
		string text17 = default(string);
		string text18 = default(string);
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
						if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Import Old Software Data In Next Software ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							goto end_IL_0001;
						}
						goto IL_001e;
					case 1850:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001_2;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_001e;
							case 3:
								goto IL_0031;
							case 4:
								goto IL_0044;
							case 5:
								goto IL_005d;
							case 6:
								goto IL_0074;
							case 7:
								goto IL_007d;
							case 8:
								goto IL_008c;
							case 9:
								goto IL_00ac;
							case 10:
								goto IL_00e7;
							case 11:
								goto IL_00f7;
							case 12:
								goto IL_0157;
							case 13:
								goto IL_0196;
							case 14:
								goto IL_01ce;
							case 15:
								goto IL_01e0;
							case 16:
								goto IL_01fe;
							case 17:
								goto IL_0208;
							case 18:
								goto IL_0212;
							case 19:
								goto IL_021c;
							case 20:
								goto IL_0260;
							case 21:
								goto IL_02a4;
							case 22:
								goto IL_02e8;
							case 23:
								goto IL_032c;
							case 24:
								goto IL_0370;
							case 25:
								goto IL_03b3;
							case 26:
								goto IL_03bd;
							case 27:
								goto IL_03c7;
							case 28:
								goto IL_03d1;
							case 29:
								goto IL_03db;
							case 30:
								goto IL_03e5;
							case 31:
								goto IL_053d;
							case 32:
								goto IL_054b;
							case 33:
								goto IL_0567;
							case 35:
								goto IL_0593;
							case 36:
								goto IL_05b1;
							case 38:
								goto IL_05eb;
							case 34:
							case 37:
							case 39:
							case 40:
							case 41:
							case 42:
							case 43:
								goto IL_0620;
							case 44:
								goto IL_063b;
							case 45:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 46:
							case 47:
							case 48:
							case 49:
							case 50:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_032c:
						num2 = 23;
						text = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][6], (object)"")), 1, 30) ?? "");
						goto IL_0370;
						IL_05b1:
						num2 = 36;
						text2 = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(text2) + 1.0), "00000");
						goto IL_0620;
						IL_054b:
						num2 = 32;
						if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
						{
							goto IL_0567;
						}
						goto IL_0593;
						IL_0593:
						num2 = 35;
						if (Conversions.ToDouble(DC_Main.AcLcCodeLen) == 1.0)
						{
							goto IL_05b1;
						}
						goto IL_05eb;
						IL_001e:
						num2 = 2;
						((FileDialog)DlgOpen).Filter = "Excel files |*.xls;*.xlsx";
						goto IL_0031;
						IL_0031:
						num2 = 3;
						((FileDialog)DlgOpen).Title = "Open File";
						goto IL_0044;
						IL_0044:
						num2 = 4;
						if (unchecked((int)((CommonDialog)DlgOpen).ShowDialog()) != 1)
						{
							goto end_IL_0001;
						}
						goto IL_005d;
						IL_005d:
						num2 = 5;
						DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpen).FileName);
						goto IL_0074;
						IL_0074:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_007d;
						IL_007d:
						num2 = 7;
						text2 = tAcCode.Text;
						goto IL_008c;
						IL_008c:
						num2 = 8;
						num5 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.i = 0;
						goto IL_062f;
						IL_062f:
						if (DC_Main.i <= num5)
						{
							goto IL_00ac;
						}
						goto IL_063b;
						IL_063b:
						num2 = 44;
						Interaction.MsgBox((object)"Data is Import Ok....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00ac:
						num2 = 9;
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][1], (object)""), (object)"", false))
						{
							goto IL_00e7;
						}
						goto IL_0620;
						IL_00e7:
						num2 = 10;
						text3 = tAcCode.Text;
						goto IL_00f7;
						IL_00f7:
						num2 = 11;
						text4 = Strings.Mid(Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][0], (object)"") }, (string[])null, (Type[])null, (bool[])null)), 1, 50) ?? "";
						goto IL_0157;
						IL_0620:
						num2 = 43;
						DC_Main.i++;
						goto IL_062f;
						IL_0370:
						num2 = 24;
						text5 = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][7], (object)"")), 1, 8) ?? "");
						goto IL_03b3;
						IL_0157:
						num2 = 12;
						text6 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][1], (object)"")), 1, 12) ?? "";
						goto IL_0196;
						IL_03b3:
						num2 = 25;
						text7 = "L";
						goto IL_03bd;
						IL_05eb:
						num2 = 38;
						text2 = DC_Main.MLc_code + Strings.Format((object)(Conversion.Val(text2) + 1.0), "000000");
						goto IL_0620;
						IL_0196:
						num2 = 13;
						DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_NAME = '" + text4 + "'";
						goto IL_01ce;
						IL_01ce:
						num2 = 14;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_01e0;
						IL_01e0:
						num2 = 15;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_01fe;
						}
						goto IL_0620;
						IL_01fe:
						num2 = 16;
						text8 = "";
						goto IL_0208;
						IL_0208:
						num2 = 17;
						text9 = "20";
						goto IL_0212;
						IL_0212:
						num2 = 18;
						text10 = "2";
						goto IL_021c;
						IL_021c:
						num2 = 19;
						text11 = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][2], (object)"")), 1, 50) ?? "");
						goto IL_0260;
						IL_03c7:
						num2 = 27;
						text12 = "";
						goto IL_03d1;
						IL_03bd:
						num2 = 26;
						text13 = "";
						goto IL_03c7;
						IL_0260:
						num2 = 20;
						text14 = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][3], (object)"")), 1, 50) ?? "");
						goto IL_02a4;
						IL_03db:
						num2 = 29;
						text15 = "";
						goto IL_03e5;
						IL_03d1:
						num2 = 28;
						text16 = "";
						goto IL_03db;
						IL_02a4:
						num2 = 21;
						text17 = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][4], (object)"")), 1, 50) ?? "");
						goto IL_02e8;
						IL_053d:
						num2 = 31;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_054b;
						IL_03e5:
						num2 = 30;
						DC_Main.RsQry = "INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,  AC_PERSON,AC_ADD1,AC_ADD2,AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,  AC_PIN,AC_PHONE,AC_PHONE2,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_GSTNO,AC_GST_TYPE,  AC_PANNO,AC_REF_CODE,AC_KHATA_NO,BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,  DPC_PRC,BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,  DATA_TRFR,MAIN_USER,LAST_VISIT,VISIT_TRAN,APP_TRFR,AC_REF_NAME,AC_ADHAR_NO)  VALUES  ('" + DC_Main.MCo_code + "','" + text2 + "','" + DC_Main.MLc_code + "','" + text4 + "','','" + text10 + "','" + text9 + "',  '" + text8 + "','" + text11 + "','" + text14 + "','" + text17 + "','INDIA','" + text18 + "','" + text15 + "','" + text + "','',  '" + text5 + "','','','" + text6 + "','" + text13 + "','','" + text12 + "','" + text7 + "',  '" + text16 + "','','" + text3 + "',NULL,NULL,NULL,0,0,  0,'','','','','','',NULL,  'N','" + DC_Main.MCo_User + "',NULL,'','N','','')";
						goto IL_053d;
						IL_02e8:
						num2 = 22;
						text18 = Strings.UCase(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][5], (object)"")), 1, 30) ?? "");
						goto IL_032c;
						IL_0567:
						num2 = 33;
						text2 = Strings.Format((object)(Conversion.Val(text2) + 1.0), "00000");
						goto IL_0620;
						end_IL_0001_3:
						break;
					}
					num2 = 45;
					Application.Exit();
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1850;
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

	private void btnOldYearAcImprt_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Import Old year Party in Current Year....?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_GR FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY AC_CODE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.M = 0;
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_CODE,AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_GR,AC_GST_TYPE,AC_TYPE) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', '00','"), DC_Main.Rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), (object)Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.M]["AC_GR"]), 1, 2)), (object)"','L','A') "));
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					DC_Main.M++;
				}
			}
			DC_Main.ExeQuteDc("UPDATE AC_MAST SET AC_MAIN_GR = B.AC_MAIN_GR FROM AC_MAST,AC_GROUP AS B WHERE AC_MAST.CO_CODE = B.CO_CODE AND AC_MAST.AC_GR = B.AC_GR AND AC_MAST.CO_CODE = '" + DC_Main.MCo_code + "'");
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_CODE,C.AC_NAME,C.AC_MOBILE FROM AC_MAST AS C WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_CODE,A.AC_NAME,A.AC_MOBILE FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_CODE ";
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_CODE,AC_NAME,AC_MOBILE FROM AC_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_CODE ";
			}
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Ac Mast is Import Ok....", (MsgBoxStyle)0, (object)null);
			((Control)btnOldYearAcImprt).Visible = false;
		}
	}

	private void BtnAcimp_Click(object sender, EventArgs e)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_AREA AS AreaL,AC_ADD1 AS AddressL,AC_CITY AS CityL FROM AC_MAST   WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(AC_CODE AS INT) > 99 ORDER BY AC_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 200.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			DC_Main.RsQry = "select * from AC_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND  AC_CODE = '" + DC_Main.ColValue[1] + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_AREA"], (object)""));
				tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)""));
				tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD2"], (object)""));
				tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD3"], (object)""));
				cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)""));
				tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_PHONE"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE2"], (object)""));
				tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_EMAIL"], (object)""));
				((Control)tAcName).Focus();
			}
		}
	}

	private void nFineIntPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineIntPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineIntPrc.Text)), "0.00");
			SendKeys.Send("{tab}");
		}
	}

	private void BtnClear_Click(object sender, EventArgs e)
	{
		((DataGridView)DgvAc).DataSource = null;
		((DataGridView)DgvAc).Columns.Clear();
		((DataGridView)DgvAc).Rows.Clear();
		((Control)DgvAc).Refresh();
		((Control)PnlAdminSet).Visible = false;
	}

	private void BtnAdminSet_Click(object sender, EventArgs e)
	{
		tPartyGroup.Text = "20";
		PatyMast();
		((Control)PnlAdminSet).Visible = true;
		((Control)tSerchAll).Focus();
	}

	private void tPartyGroup_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tPartyGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_GR = '" + tPartyGroup.Text + "'";
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
						tPartyGroup.Text = DC_Main.ColValue[0];
					}
					PatyMast();
					((Control)tPartyGroup).Focus();
				}
			}
			else
			{
				PatyMast();
			}
		}
		else
		{
			Interaction.MsgBox((object)"Please Select Group First And try...", (MsgBoxStyle)0, (object)null);
			((Control)tPartyGroup).Focus();
		}
	}

	private void PatyMast()
	{
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2,A.DEFAULTER_AC,A.AC_CR_DAYS,A.AMT_LIMIT,A.GOLD_LIMIT,A.SILVER_LIMIT FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tPartyGroup.Text, "", false) == 0, (object)"", (object)("AND A.AC_GR = '" + tPartyGroup.Text + "'"))), (object)" AND A.AC_CODE > '00100' ORDER BY A.AC_NAME "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2,A.DEFAULTER_AC,A.AC_CR_DAYS,A.AMT_LIMIT,A.GOLD_LIMIT,A.SILVER_LIMIT FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tPartyGroup.Text, "", false) == 0, (object)"", (object)("AND A.AC_GR = '" + tPartyGroup.Text + "'"))), (object)" AND LEN(A.AC_CODE) <> 5 ORDER BY A.AC_NAME "));
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DgvAc).DataSource = null;
		((DataGridView)DgvAc).Columns.Clear();
		((DataGridView)DgvAc).Rows.Clear();
		((Control)DgvAc).Refresh();
		if (DC_Main.Tbl.Rows.Count <= 0)
		{
			return;
		}
		DataGridViewX dgvAc = DgvAc;
		((DataGridView)dgvAc).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DgvAc).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DgvAc).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DgvAc).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DgvAc).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dgvAc).AutoGenerateColumns = false;
		((DataGridView)dgvAc).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dgvAc).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dgvAc).Columns.Add("", "AcName");
			((DataGridView)dgvAc).Columns[1].Width = (int)Math.Round(250.0 * ColCon);
			((DataGridView)dgvAc).Columns.Add("", "Address");
			((DataGridView)dgvAc).Columns[2].Width = (int)Math.Round(150.0 * ColCon);
			DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
			((DataGridView)dgvAc).Columns.Add((DataGridViewColumn)(object)val);
			((DataGridView)dgvAc).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridViewColumn)val).Name = "Defaulter";
			((DataGridView)dgvAc).Columns.Add("", "CrDays");
			((DataGridView)dgvAc).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dgvAc).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dgvAc).Columns.Add("", "AmtLimit");
			((DataGridView)dgvAc).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dgvAc).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dgvAc).Columns.Add("", "GlFileLmt");
			((DataGridView)dgvAc).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dgvAc).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dgvAc).Columns.Add("", "SlFineLmt");
			((DataGridView)dgvAc).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dgvAc).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dgvAc).Columns.Add("", "City");
			((DataGridView)dgvAc).Columns[8].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)dgvAc).Columns.Add("", "Mobile");
			((DataGridView)dgvAc).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dgvAc).Columns.Add("", "AcCode");
			((DataGridView)dgvAc).Columns[10].Visible = false;
			((DataGridView)dgvAc).Columns.Add("", "OldDefaulter");
			((DataGridView)dgvAc).Columns[11].Visible = false;
			((DataGridView)dgvAc).Columns.Add("", "OldTotVal");
			((DataGridView)dgvAc).Columns[12].Visible = false;
			if (DC_Main.PcH > 780.0)
			{
				((Control)DgvAc).Height = 630;
				((Control)btnUpdate).Top = ((Control)DgvAc).Top + 650;
				((Control)btnUpdate).Left = ((Control)DgvAc).Left + 700;
				((Control)btnClear).Top = ((Control)DgvAc).Top + 650;
				((Control)btnClear).Left = ((Control)btnUpdate).Left + 300;
			}
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				((DataGridView)dgvAc).Rows.Add();
				((DataGridView)dgvAc)[0, DC_Main.i].Value = DC_Main.i + 1;
				((DataGridView)dgvAc)[1, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				((DataGridView)dgvAc)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
				if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.i]["DEFAULTER_AC"], (object)"Y", false))
				{
					((DataGridView)dgvAc)[3, DC_Main.i].Value = true;
				}
				else
				{
					((DataGridView)dgvAc)[3, DC_Main.i].Value = false;
				}
				((DataGridView)dgvAc)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CR_DAYS"]);
				((DataGridView)dgvAc)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AMT_LIMIT"]);
				((DataGridView)dgvAc)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["GOLD_LIMIT"]);
				((DataGridView)dgvAc)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["SILVER_LIMIT"]);
				((DataGridView)dgvAc)[8, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
				((DataGridView)dgvAc)[9, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
				((DataGridView)dgvAc)[10, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
				((DataGridView)dgvAc)[11, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[3, DC_Main.i].Value);
				((DataGridView)dgvAc)[12, DC_Main.i].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[4, DC_Main.i].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[5, DC_Main.i].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[6, DC_Main.i].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[7, DC_Main.i].Value));
				DC_Main.i++;
			}
			dgvAc = null;
		}
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		checked
		{
			if ((Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0) | (Strings.Len(((TextEdit)tSerchAll).Text) > 1))
			{
				ColorConverter colorConverter = new ColorConverter();
				if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2,A.DEFAULTER_AC,A.AC_CR_DAYS,A.AMT_LIMIT,A.GOLD_LIMIT,A.SILVER_LIMIT FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE > '00100' AND A.AC_NAME Like  '" + ((TextEdit)tSerchAll).Text + "%' "), Interaction.IIf(Operators.CompareString(tPartyGroup.Text, "", false) == 0, (object)"", (object)("AND A.AC_GR = '" + tPartyGroup.Text + "'"))), (object)"  ORDER BY A.AC_NAME "));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2,A.DEFAULTER_AC,A.AC_CR_DAYS,A.AMT_LIMIT,A.GOLD_LIMIT,A.SILVER_LIMIT FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(A.AC_CODE) <> 5 AND A.AC_NAME Like  '" + ((TextEdit)tSerchAll).Text + "%' "), Interaction.IIf(Operators.CompareString(tPartyGroup.Text, "", false) == 0, (object)"", (object)("AND A.AC_GR = '" + tPartyGroup.Text + "'"))), (object)" ORDER BY A.AC_NAME "));
				}
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				((DataGridView)DgvAc).DataSource = null;
				((DataGridView)DgvAc).Columns.Clear();
				((DataGridView)DgvAc).Rows.Clear();
				((Control)DgvAc).Refresh();
				if (DC_Main.Tbl.Rows.Count <= 0)
				{
					return;
				}
				DataGridViewX dgvAc = DgvAc;
				((DataGridView)dgvAc).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DgvAc).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DgvAc).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DgvAc).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DgvAc).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dgvAc).AutoGenerateColumns = false;
				((DataGridView)dgvAc).Columns.Add("", "SrNo");
				((DataGridView)dgvAc).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dgvAc).Columns.Add("", "AcName");
				((DataGridView)dgvAc).Columns[1].Width = (int)Math.Round(250.0 * ColCon);
				((DataGridView)dgvAc).Columns.Add("", "Address");
				((DataGridView)dgvAc).Columns[2].Width = (int)Math.Round(150.0 * ColCon);
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dgvAc).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dgvAc).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridViewColumn)val).Name = "Defaulter";
				((DataGridView)dgvAc).Columns.Add("", "CrDays");
				((DataGridView)dgvAc).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)dgvAc).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dgvAc).Columns.Add("", "AmtLimit");
				((DataGridView)dgvAc).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dgvAc).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dgvAc).Columns.Add("", "GlFileLmt");
				((DataGridView)dgvAc).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)dgvAc).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dgvAc).Columns.Add("", "SlFineLmt");
				((DataGridView)dgvAc).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)dgvAc).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dgvAc).Columns.Add("", "City");
				((DataGridView)dgvAc).Columns[8].Width = (int)Math.Round(130.0 * ColCon);
				((DataGridView)dgvAc).Columns.Add("", "Mobile");
				((DataGridView)dgvAc).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dgvAc).Columns.Add("", "AcCode");
				((DataGridView)dgvAc).Columns[10].Visible = false;
				((DataGridView)dgvAc).Columns.Add("", "OldDefaulter");
				((DataGridView)dgvAc).Columns[11].Visible = false;
				((DataGridView)dgvAc).Columns.Add("", "OldTotVal");
				((DataGridView)dgvAc).Columns[12].Visible = false;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dgvAc).Rows.Add();
					((DataGridView)dgvAc)[0, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dgvAc)[1, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					((DataGridView)dgvAc)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.i]["DEFAULTER_AC"], (object)"Y", false))
					{
						((DataGridView)dgvAc)[3, DC_Main.i].Value = true;
					}
					else
					{
						((DataGridView)dgvAc)[3, DC_Main.i].Value = false;
					}
					((DataGridView)dgvAc)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CR_DAYS"]);
					((DataGridView)dgvAc)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AMT_LIMIT"]);
					((DataGridView)dgvAc)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["GOLD_LIMIT"]);
					((DataGridView)dgvAc)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["SILVER_LIMIT"]);
					((DataGridView)dgvAc)[8, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dgvAc)[9, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					((DataGridView)dgvAc)[10, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
					((DataGridView)dgvAc)[11, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[3, DC_Main.i].Value);
					((DataGridView)dgvAc)[12, DC_Main.i].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[4, DC_Main.i].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[5, DC_Main.i].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[6, DC_Main.i].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dgvAc)[7, DC_Main.i].Value));
					DC_Main.i++;
				}
				dgvAc = null;
			}
			else
			{
				PatyMast();
			}
		}
	}

	private void DgvAc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 4) <= 3u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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

	private void BtnUpdate_Click(object sender, EventArgs e)
	{
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		int num5 = default(int);
		int num6 = default(int);
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
				case 987:
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
							goto IL_0028;
						case 4:
							goto IL_019f;
						case 5:
							goto IL_0373;
						case 6:
						case 7:
							goto IL_0382;
						case 8:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 9:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_019f:
					num2 = 4;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AC_MAST SET AC_CR_DAYS = " + Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[4].Value, (object)""))) + ",  AMT_LIMIT = " + Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[5].Value, (object)""))) + ",  GOLD_LIMIT = " + Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[6].Value, (object)""))) + ",  SILVER_LIMIT = " + Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[7].Value, (object)""))) + ",  DEFAULTER_AC = "), Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[3].Value, (object)""), (object)true, false), (object)"'Y'", (object)"'N'")), (object)" "), (object)" WHERE CO_CODE  = '"), (object)DC_Main.MCo_code), (object)"' AND AC_CODE = '"), ((DataGridView)DgvAc).Rows[num5].Cells[10].Value), (object)""), (object)"'"));
					goto IL_0373;
					IL_0373:
					num2 = 5;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0382;
					IL_0028:
					num2 = 3;
					if (Conversions.ToBoolean(Operators.OrObject((object)(Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[4].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[5].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[6].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[7].Value, (object)"")) != Conversion.Val(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[12].Value, (object)""))), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[3].Value, (object)""), Operators.ConcatenateObject(((DataGridView)DgvAc).Rows[num5].Cells[11].Value, (object)""), false))))
					{
						goto IL_019f;
					}
					goto IL_0382;
					IL_0382:
					num2 = 7;
					num5 = checked(num5 + 1);
					goto IL_038a;
					IL_000b:
					num2 = 2;
					num6 = checked(((DataGridView)DgvAc).Rows.Count - 1);
					num5 = 0;
					goto IL_038a;
					IL_038a:
					if (num5 > num6)
					{
						break;
					}
					goto IL_0028;
					end_IL_0001_2:
					break;
				}
				num2 = 8;
				Interaction.MsgBox((object)"Data Are Update.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 987;
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

	private void cboAcType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void TMainAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tMainAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tMainAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tMainAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.LC_CODE,A.AC_NAME";
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
						tMainAcCode.Text = DC_Main.ColValue[1];
					}
					((Control)tMainAcCode).Focus();
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPassportNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mtrnIdDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)mCustIdDt).Focus();
		}
	}

	private void mCustIdDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)mBhDate).Focus();
		}
	}

	private void tLcsNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void tGstNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcShort_TextChanged(object sender, EventArgs e)
	{
	}
}
