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
public class UT_SETTING_MAIN : Form
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
	[AccessedThroughProperty("btnQrcode")]
	private QButton _btnQrcode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCustOsSms")]
	private QButton _btnCustOsSms;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLoanIntDay")]
	private QButton _btnLoanIntDay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlImgPrint")]
	private QButton _btnSlImgPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTotFineStkType")]
	private QButton _btnTotFineStkType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBalSheetType")]
	private QButton _btnBalSheetType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPrRateRof")]
	private QButton _btnPrRateRof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAdminSms")]
	private QButton _btnAdminSms;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCustSms")]
	private QButton _btnCustSms;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCountryId")]
	private QButton _btnCountryId;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWappSlprint")]
	private QButton _btnWappSlprint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDesignGen")]
	private QButton _btnDesignGen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdImage")]
	private QButton _btnOrdImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrnaIsu")]
	private QButton _btnOrnaIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMobileSearch")]
	private QButton _btnMobileSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPrintFormSet")]
	private QButton _btnPrintFormSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEmpMandotry")]
	private QButton _btnEmpMandotry;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFontStyle")]
	private QButton _btnFontStyle;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFontName")]
	private QButton _btnFontName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFontSize")]
	private QButton _btnFontSize;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFontChang")]
	private QButton _btnFontChang;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnGridRowHeightSet")]
	private QButton _btnGridRowHeightSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPreviousLock")]
	private QButton _btnPreviousLock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCashLimit")]
	private QButton _BtnCashLimit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDcMemb")]
	private QButton _btnDcMemb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDcPwd")]
	private TextBox _tDcPwd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillTitRof")]
	private QButton _btnBillTitRof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnScrolbar")]
	private QButton _btnScrolbar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnStkRptType")]
	private QButton _btnStkRptType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSlWtDiff")]
	private QButton _btnTagSlWtDiff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEstmatTax")]
	private QButton _btnEstmatTax;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagRowSave")]
	private QButton _btnTagRowSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagRowPrint")]
	private QButton _btnTagRowPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSchmWapp")]
	private QButton _BtnSchmWapp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDhrnWapp")]
	private QButton _btnDhrnWapp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRptTotShow")]
	private QButton _btnRptTotShow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnReminderType")]
	private QButton _brnReminderType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnHelpLent")]
	private QButton _btnHelpLent;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrdTagStkLess")]
	private QButton _btnOrdTagStkLess;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAllBranchAcShow")]
	private QButton _btnAllBranchAcShow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEmpAsUser")]
	private QButton _btnEmpAsUser;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnImgWithWt")]
	private QButton _brnImgWithWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDhrnImgPrint")]
	private QButton _BtnDhrnImgPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLbrWithGht")]
	private QButton _btnLbrWithGht;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAprlImg")]
	private QButton _btnAprlImg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOthItmWtRemove")]
	private QButton _btnOthItmWtRemove;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSilverWt3digit")]
	private QButton _btnSilverWt3digit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWhSaleImg")]
	private QButton _btnWhSaleImg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItmLotStk")]
	private QButton _btnItmLotStk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFineStkType")]
	private QButton _btnFineStkType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnRefresh")]
	private QButton _brnRefresh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMainFontChange")]
	private QButton _btnMainFontChange;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurRateWith")]
	private QButton _btnPurRateWith;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlRateWith")]
	private QButton _btnSlRateWith;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCrystalRptType")]
	private QButton _btnCrystalRptType;

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

	internal virtual QButton btnQrcode
	{
		[CompilerGenerated]
		get
		{
			return _btnQrcode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnQrcode_Click;
			QButton val = _btnQrcode;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnQrcode = value;
			val = _btnQrcode;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboQrCode")]
	private virtual ComboBox _cboQrCode;

	internal virtual ComboBox cboQrCode
	{
		get
		{
			return _cboQrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboQrCode = value;
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

	internal virtual QButton btnCustOsSms
	{
		[CompilerGenerated]
		get
		{
			return _btnCustOsSms;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCustOsSms_Click;
			QButton val = _btnCustOsSms;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCustOsSms = value;
			val = _btnCustOsSms;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCustOsSms")]
	private virtual ComboBox _cboCustOsSms;

	internal virtual ComboBox cboCustOsSms
	{
		get
		{
			return _cboCustOsSms;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCustOsSms = value;
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

	internal virtual QButton btnLoanIntDay
	{
		[CompilerGenerated]
		get
		{
			return _btnLoanIntDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLoanIntDay_Click;
			QButton val = _btnLoanIntDay;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLoanIntDay = value;
			val = _btnLoanIntDay;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLoanIntType")]
	private virtual ComboBox _cboLoanIntType;

	internal virtual ComboBox cboLoanIntType
	{
		get
		{
			return _cboLoanIntType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboLoanIntType = value;
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

	internal virtual QButton btnSlImgPrint
	{
		[CompilerGenerated]
		get
		{
			return _btnSlImgPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlImgPrint_Click;
			QButton val = _btnSlImgPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlImgPrint = value;
			val = _btnSlImgPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSalesImagPrint")]
	private virtual ComboBox _cboSalesImagPrint;

	internal virtual ComboBox cboSalesImagPrint
	{
		get
		{
			return _cboSalesImagPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSalesImagPrint = value;
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

	internal virtual QButton btnTotFineStkType
	{
		[CompilerGenerated]
		get
		{
			return _btnTotFineStkType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTotFineStkType_Click;
			QButton val = _btnTotFineStkType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTotFineStkType = value;
			val = _btnTotFineStkType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTotFineStkType")]
	private virtual ComboBox _cboTotFineStkType;

	internal virtual ComboBox cboTotFineStkType
	{
		get
		{
			return _cboTotFineStkType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTotFineStkType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblTotFineStk")]
	private virtual Label _lblTotFineStk;

	internal virtual Label lblTotFineStk
	{
		get
		{
			return _lblTotFineStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblTotFineStk = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabMenu")]
	private virtual SuperTabControl _TabMenu;

	internal virtual SuperTabControl TabMenu
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
	[AccessedThroughProperty("TabPanel3")]
	private virtual SuperTabControlPanel _TabPanel3;

	internal virtual SuperTabControlPanel TabPanel3
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

	internal virtual SuperTabItem Tab3
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

	internal virtual SuperTabControlPanel TabPanel2
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

	internal virtual SuperTabItem Tab2
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel1")]
	private virtual SuperTabControlPanel _TabPanel1;

	internal virtual SuperTabControlPanel TabPanel1
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

	internal virtual SuperTabItem Tab1
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

	internal virtual QButton btnBalSheetType
	{
		[CompilerGenerated]
		get
		{
			return _btnBalSheetType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBalSheetType_Click;
			QButton val = _btnBalSheetType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBalSheetType = value;
			val = _btnBalSheetType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboBalSheetType")]
	private virtual ComboBox _cboBalSheetType;

	internal virtual ComboBox cboBalSheetType
	{
		get
		{
			return _cboBalSheetType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboBalSheetType = value;
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

	internal virtual QButton btnPrRateRof
	{
		[CompilerGenerated]
		get
		{
			return _btnPrRateRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPrRateRof_Click;
			QButton val = _btnPrRateRof;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPrRateRof = value;
			val = _btnPrRateRof;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrRateRof")]
	private virtual ComboBox _cboPrRateRof;

	internal virtual ComboBox cboPrRateRof
	{
		get
		{
			return _cboPrRateRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrRateRof = value;
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

	internal virtual QButton btnAdminSms
	{
		[CompilerGenerated]
		get
		{
			return _btnAdminSms;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAdminSms_Click;
			QButton val = _btnAdminSms;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAdminSms = value;
			val = _btnAdminSms;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAdminSms")]
	private virtual ComboBox _cboAdminSms;

	internal virtual ComboBox cboAdminSms
	{
		get
		{
			return _cboAdminSms;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAdminSms = value;
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

	internal virtual QButton btnCustSms
	{
		[CompilerGenerated]
		get
		{
			return _btnCustSms;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCustSms_Click;
			QButton val = _btnCustSms;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCustSms = value;
			val = _btnCustSms;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCustSms")]
	private virtual ComboBox _cboCustSms;

	internal virtual ComboBox cboCustSms
	{
		get
		{
			return _cboCustSms;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCustSms = value;
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

	internal virtual QButton btnCountryId
	{
		[CompilerGenerated]
		get
		{
			return _btnCountryId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCountryId_Click;
			QButton val = _btnCountryId;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCountryId = value;
			val = _btnCountryId;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCountryid")]
	private virtual ComboBox _cboCountryid;

	internal virtual ComboBox cboCountryid
	{
		get
		{
			return _cboCountryid;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCountryid = value;
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

	internal virtual QButton btnWappSlprint
	{
		[CompilerGenerated]
		get
		{
			return _btnWappSlprint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWappSlprint_Click;
			QButton val = _btnWappSlprint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWappSlprint = value;
			val = _btnWappSlprint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboWappSlPrint")]
	private virtual ComboBox _cboWappSlPrint;

	internal virtual ComboBox cboWappSlPrint
	{
		get
		{
			return _cboWappSlPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboWappSlPrint = value;
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

	internal virtual QButton btnDesignGen
	{
		[CompilerGenerated]
		get
		{
			return _btnDesignGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDesignGen_Click;
			QButton val = _btnDesignGen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDesignGen = value;
			val = _btnDesignGen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDesignGen")]
	private virtual ComboBox _cboDesignGen;

	internal virtual ComboBox cboDesignGen
	{
		get
		{
			return _cboDesignGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDesignGen = value;
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

	internal virtual QButton btnOrdImage
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOrdImage_Click;
			QButton val = _btnOrdImage;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdImage = value;
			val = _btnOrdImage;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOrdImage")]
	private virtual ComboBox _cboOrdImage;

	internal virtual ComboBox cboOrdImage
	{
		get
		{
			return _cboOrdImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOrdImage = value;
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

	internal virtual QButton btnOrnaIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnOrnaIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOrnaIsu_Click;
			QButton val = _btnOrnaIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrnaIsu = value;
			val = _btnOrnaIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOrnaIsu")]
	private virtual ComboBox _cboOrnaIsu;

	internal virtual ComboBox cboOrnaIsu
	{
		get
		{
			return _cboOrnaIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOrnaIsu = value;
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

	internal virtual QButton btnMobileSearch
	{
		[CompilerGenerated]
		get
		{
			return _btnMobileSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMobileSearch_Click;
			QButton val = _btnMobileSearch;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMobileSearch = value;
			val = _btnMobileSearch;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboMobileSearch")]
	private virtual ComboBox _cboMobileSearch;

	internal virtual ComboBox cboMobileSearch
	{
		get
		{
			return _cboMobileSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboMobileSearch = value;
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

	internal virtual QButton btnPrintFormSet
	{
		[CompilerGenerated]
		get
		{
			return _btnPrintFormSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPrintFormSet_Click;
			QButton val = _btnPrintFormSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPrintFormSet = value;
			val = _btnPrintFormSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintFormSet")]
	private virtual ComboBox _cboPrintFormSet;

	internal virtual ComboBox cboPrintFormSet
	{
		get
		{
			return _cboPrintFormSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintFormSet = value;
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

	internal virtual QButton btnEmpMandotry
	{
		[CompilerGenerated]
		get
		{
			return _btnEmpMandotry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEmpMandotry_Click;
			QButton val = _btnEmpMandotry;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEmpMandotry = value;
			val = _btnEmpMandotry;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEmpMandatory")]
	private virtual ComboBox _cboEmpMandatory;

	internal virtual ComboBox cboEmpMandatory
	{
		get
		{
			return _cboEmpMandatory;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboEmpMandatory = value;
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

	internal virtual QButton btnFontStyle
	{
		[CompilerGenerated]
		get
		{
			return _btnFontStyle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFontStyle_Click;
			QButton val = _btnFontStyle;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFontStyle = value;
			val = _btnFontStyle;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboFontStyle")]
	private virtual ComboBox _cboFontStyle;

	internal virtual ComboBox cboFontStyle
	{
		get
		{
			return _cboFontStyle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFontStyle = value;
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

	internal virtual QButton btnFontName
	{
		[CompilerGenerated]
		get
		{
			return _btnFontName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFontName_Click;
			QButton val = _btnFontName;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFontName = value;
			val = _btnFontName;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CboFontName")]
	private virtual ComboBox _CboFontName;

	internal virtual ComboBox CboFontName
	{
		get
		{
			return _CboFontName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_CboFontName = value;
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

	internal virtual QButton btnFontSize
	{
		[CompilerGenerated]
		get
		{
			return _btnFontSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFontSize_Click;
			QButton val = _btnFontSize;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFontSize = value;
			val = _btnFontSize;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboFontSize")]
	private virtual ComboBox _cboFontSize;

	internal virtual ComboBox cboFontSize
	{
		get
		{
			return _cboFontSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFontSize = value;
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

	internal virtual QButton btnFontChang
	{
		[CompilerGenerated]
		get
		{
			return _btnFontChang;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFontChang_Click;
			QButton val = _btnFontChang;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFontChang = value;
			val = _btnFontChang;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboFontChange")]
	private virtual ComboBox _cboFontChange;

	internal virtual ComboBox cboFontChange
	{
		get
		{
			return _cboFontChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFontChange = value;
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

	internal virtual QButton btnGridRowHeightSet
	{
		[CompilerGenerated]
		get
		{
			return _btnGridRowHeightSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGridRowHeightSet_Click;
			QButton val = _btnGridRowHeightSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnGridRowHeightSet = value;
			val = _btnGridRowHeightSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboGridRowHeight")]
	private virtual ComboBox _cboGridRowHeight;

	internal virtual ComboBox cboGridRowHeight
	{
		get
		{
			return _cboGridRowHeight;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboGridRowHeight = value;
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

	internal virtual QButton btnPreviousLock
	{
		[CompilerGenerated]
		get
		{
			return _btnPreviousLock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPreviousLock_Click;
			QButton val = _btnPreviousLock;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPreviousLock = value;
			val = _btnPreviousLock;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPreviousLock")]
	private virtual ComboBox _cboPreviousLock;

	internal virtual ComboBox cboPreviousLock
	{
		get
		{
			return _cboPreviousLock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPreviousLock = value;
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

	internal virtual QButton BtnCashLimit
	{
		[CompilerGenerated]
		get
		{
			return _BtnCashLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCashLimit_Click;
			QButton val = _BtnCashLimit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCashLimit = value;
			val = _BtnCashLimit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCashLimit")]
	private virtual ComboBox _cboCashLimit;

	internal virtual ComboBox cboCashLimit
	{
		get
		{
			return _cboCashLimit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCashLimit = value;
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

	internal virtual QButton btnDcMemb
	{
		[CompilerGenerated]
		get
		{
			return _btnDcMemb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDcMemb_Click;
			QButton val = _btnDcMemb;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDcMemb = value;
			val = _btnDcMemb;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tDcPwd
	{
		[CompilerGenerated]
		get
		{
			return _tDcPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tDcPwd_KeyDown);
			TextBox val2 = _tDcPwd;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tDcPwd = value;
			val2 = _tDcPwd;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual QButton btnBillTitRof
	{
		[CompilerGenerated]
		get
		{
			return _btnBillTitRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBillTitRof_Click;
			QButton val = _btnBillTitRof;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillTitRof = value;
			val = _btnBillTitRof;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboBilTotRof")]
	private virtual ComboBox _cboBilTotRof;

	internal virtual ComboBox cboBilTotRof
	{
		get
		{
			return _cboBilTotRof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboBilTotRof = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label28")]
	private virtual Label _Label28;

	internal virtual Label Label28
	{
		get
		{
			return _Label28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label28 = value;
		}
	}

	internal virtual QButton btnScrolbar
	{
		[CompilerGenerated]
		get
		{
			return _btnScrolbar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnScrolbar_Click;
			QButton val = _btnScrolbar;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnScrolbar = value;
			val = _btnScrolbar;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboScorlbar")]
	private virtual ComboBox _cboScorlbar;

	internal virtual ComboBox cboScorlbar
	{
		get
		{
			return _cboScorlbar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboScorlbar = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label29")]
	private virtual Label _Label29;

	internal virtual Label Label29
	{
		get
		{
			return _Label29;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label29 = value;
		}
	}

	internal virtual QButton btnStkRptType
	{
		[CompilerGenerated]
		get
		{
			return _btnStkRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnStkRptType_Click;
			QButton val = _btnStkRptType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnStkRptType = value;
			val = _btnStkRptType;
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
	[AccessedThroughProperty("Label30")]
	private virtual Label _Label30;

	internal virtual Label Label30
	{
		get
		{
			return _Label30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label30 = value;
		}
	}

	internal virtual QButton btnTagSlWtDiff
	{
		[CompilerGenerated]
		get
		{
			return _btnTagSlWtDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagSlWtDiff_Click;
			QButton val = _btnTagSlWtDiff;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagSlWtDiff = value;
			val = _btnTagSlWtDiff;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTagSaleWtDiff")]
	private virtual ComboBox _cboTagSaleWtDiff;

	internal virtual ComboBox cboTagSaleWtDiff
	{
		get
		{
			return _cboTagSaleWtDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTagSaleWtDiff = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label31")]
	private virtual Label _Label31;

	internal virtual Label Label31
	{
		get
		{
			return _Label31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label31 = value;
		}
	}

	internal virtual QButton btnEstmatTax
	{
		[CompilerGenerated]
		get
		{
			return _btnEstmatTax;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEstmatTax_Click;
			QButton val = _btnEstmatTax;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEstmatTax = value;
			val = _btnEstmatTax;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEstmateWithTax")]
	private virtual ComboBox _cboEstmateWithTax;

	internal virtual ComboBox cboEstmateWithTax
	{
		get
		{
			return _cboEstmateWithTax;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboEstmateWithTax = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label32")]
	private virtual Label _Label32;

	internal virtual Label Label32
	{
		get
		{
			return _Label32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label32 = value;
		}
	}

	internal virtual QButton btnTagRowSave
	{
		[CompilerGenerated]
		get
		{
			return _btnTagRowSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagRowSave_Click;
			QButton val = _btnTagRowSave;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagRowSave = value;
			val = _btnTagRowSave;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTagRowSave")]
	private virtual ComboBox _cboTagRowSave;

	internal virtual ComboBox cboTagRowSave
	{
		get
		{
			return _cboTagRowSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTagRowSave = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label33")]
	private virtual Label _Label33;

	internal virtual Label Label33
	{
		get
		{
			return _Label33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label33 = value;
		}
	}

	internal virtual QButton btnTagRowPrint
	{
		[CompilerGenerated]
		get
		{
			return _btnTagRowPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagRowPrint_Click;
			QButton val = _btnTagRowPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagRowPrint = value;
			val = _btnTagRowPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTagRowPrint")]
	private virtual ComboBox _cboTagRowPrint;

	internal virtual ComboBox cboTagRowPrint
	{
		get
		{
			return _cboTagRowPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTagRowPrint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label34")]
	private virtual Label _Label34;

	internal virtual Label Label34
	{
		get
		{
			return _Label34;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label34 = value;
		}
	}

	internal virtual QButton BtnSchmWapp
	{
		[CompilerGenerated]
		get
		{
			return _BtnSchmWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSchmWapp_Click;
			QButton val = _BtnSchmWapp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSchmWapp = value;
			val = _BtnSchmWapp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSchmWapp")]
	private virtual ComboBox _cboSchmWapp;

	internal virtual ComboBox cboSchmWapp
	{
		get
		{
			return _cboSchmWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSchmWapp = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label36")]
	private virtual Label _Label36;

	internal virtual Label Label36
	{
		get
		{
			return _Label36;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label36 = value;
		}
	}

	internal virtual QButton btnDhrnWapp
	{
		[CompilerGenerated]
		get
		{
			return _btnDhrnWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDhrnWapp_Click;
			QButton val = _btnDhrnWapp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDhrnWapp = value;
			val = _btnDhrnWapp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDhrnWapp")]
	private virtual ComboBox _cboDhrnWapp;

	internal virtual ComboBox cboDhrnWapp
	{
		get
		{
			return _cboDhrnWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDhrnWapp = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label35")]
	private virtual Label _Label35;

	internal virtual Label Label35
	{
		get
		{
			return _Label35;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label35 = value;
		}
	}

	internal virtual QButton btnRptTotShow
	{
		[CompilerGenerated]
		get
		{
			return _btnRptTotShow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRptTotShow_Click;
			QButton val = _btnRptTotShow;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRptTotShow = value;
			val = _btnRptTotShow;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboRptTotShow")]
	private virtual ComboBox _cboRptTotShow;

	internal virtual ComboBox cboRptTotShow
	{
		get
		{
			return _cboRptTotShow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboRptTotShow = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label37")]
	private virtual Label _Label37;

	internal virtual Label Label37
	{
		get
		{
			return _Label37;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label37 = value;
		}
	}

	internal virtual QButton brnReminderType
	{
		[CompilerGenerated]
		get
		{
			return _brnReminderType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnReminderType_Click;
			QButton val = _brnReminderType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnReminderType = value;
			val = _brnReminderType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboReminderType")]
	private virtual ComboBox _cboReminderType;

	internal virtual ComboBox cboReminderType
	{
		get
		{
			return _cboReminderType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboReminderType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label38")]
	private virtual Label _Label38;

	internal virtual Label Label38
	{
		get
		{
			return _Label38;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label38 = value;
		}
	}

	internal virtual QButton btnHelpLent
	{
		[CompilerGenerated]
		get
		{
			return _btnHelpLent;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnHelpLent_Click;
			QButton val = _btnHelpLent;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnHelpLent = value;
			val = _btnHelpLent;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboHelpLent")]
	private virtual ComboBox _cboHelpLent;

	internal virtual ComboBox cboHelpLent
	{
		get
		{
			return _cboHelpLent;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboHelpLent = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label39")]
	private virtual Label _Label39;

	internal virtual Label Label39
	{
		get
		{
			return _Label39;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label39 = value;
		}
	}

	internal virtual QButton btnOrdTagStkLess
	{
		[CompilerGenerated]
		get
		{
			return _btnOrdTagStkLess;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOrdTagStkLess_Click;
			QButton val = _btnOrdTagStkLess;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrdTagStkLess = value;
			val = _btnOrdTagStkLess;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOrdTagStkLess")]
	private virtual ComboBox _cboOrdTagStkLess;

	internal virtual ComboBox cboOrdTagStkLess
	{
		get
		{
			return _cboOrdTagStkLess;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOrdTagStkLess = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label40")]
	private virtual Label _Label40;

	internal virtual Label Label40
	{
		get
		{
			return _Label40;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label40 = value;
		}
	}

	internal virtual QButton btnAllBranchAcShow
	{
		[CompilerGenerated]
		get
		{
			return _btnAllBranchAcShow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAllBranchAcShow_Click;
			QButton val = _btnAllBranchAcShow;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAllBranchAcShow = value;
			val = _btnAllBranchAcShow;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAllBrancAcShow")]
	private virtual ComboBox _cboAllBrancAcShow;

	internal virtual ComboBox cboAllBrancAcShow
	{
		get
		{
			return _cboAllBrancAcShow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAllBrancAcShow = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label41")]
	private virtual Label _Label41;

	internal virtual Label Label41
	{
		get
		{
			return _Label41;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label41 = value;
		}
	}

	internal virtual QButton btnEmpAsUser
	{
		[CompilerGenerated]
		get
		{
			return _btnEmpAsUser;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEmpAsUser_Click;
			QButton val = _btnEmpAsUser;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEmpAsUser = value;
			val = _btnEmpAsUser;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEmpAsUser")]
	private virtual ComboBox _cboEmpAsUser;

	internal virtual ComboBox cboEmpAsUser
	{
		get
		{
			return _cboEmpAsUser;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboEmpAsUser = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label42")]
	private virtual Label _Label42;

	internal virtual Label Label42
	{
		get
		{
			return _Label42;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label42 = value;
		}
	}

	internal virtual QButton brnImgWithWt
	{
		[CompilerGenerated]
		get
		{
			return _brnImgWithWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = brnImgWithWt_Click;
			QButton val = _brnImgWithWt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnImgWithWt = value;
			val = _brnImgWithWt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboImgWithWt")]
	private virtual ComboBox _cboImgWithWt;

	internal virtual ComboBox cboImgWithWt
	{
		get
		{
			return _cboImgWithWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboImgWithWt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label43")]
	private virtual Label _Label43;

	internal virtual Label Label43
	{
		get
		{
			return _Label43;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label43 = value;
		}
	}

	internal virtual QButton BtnDhrnImgPrint
	{
		[CompilerGenerated]
		get
		{
			return _BtnDhrnImgPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDhrnImgPrint_Click;
			QButton val = _BtnDhrnImgPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDhrnImgPrint = value;
			val = _BtnDhrnImgPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDhrnImgPrint")]
	private virtual ComboBox _cboDhrnImgPrint;

	internal virtual ComboBox cboDhrnImgPrint
	{
		get
		{
			return _cboDhrnImgPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboDhrnImgPrint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label44")]
	private virtual Label _Label44;

	internal virtual Label Label44
	{
		get
		{
			return _Label44;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label44 = value;
		}
	}

	internal virtual QButton btnLbrWithGht
	{
		[CompilerGenerated]
		get
		{
			return _btnLbrWithGht;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLbrWithGht_Click;
			QButton val = _btnLbrWithGht;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLbrWithGht = value;
			val = _btnLbrWithGht;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLbrWitGht")]
	private virtual ComboBox _cboLbrWitGht;

	internal virtual ComboBox cboLbrWitGht
	{
		get
		{
			return _cboLbrWitGht;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboLbrWitGht = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label45")]
	private virtual Label _Label45;

	internal virtual Label Label45
	{
		get
		{
			return _Label45;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label45 = value;
		}
	}

	internal virtual QButton btnAprlImg
	{
		[CompilerGenerated]
		get
		{
			return _btnAprlImg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAprlImg_Click;
			QButton val = _btnAprlImg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAprlImg = value;
			val = _btnAprlImg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAprlImg")]
	private virtual ComboBox _cboAprlImg;

	internal virtual ComboBox cboAprlImg
	{
		get
		{
			return _cboAprlImg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAprlImg = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label46")]
	private virtual Label _Label46;

	internal virtual Label Label46
	{
		get
		{
			return _Label46;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label46 = value;
		}
	}

	internal virtual QButton btnOthItmWtRemove
	{
		[CompilerGenerated]
		get
		{
			return _btnOthItmWtRemove;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOthItmWtRemove_Click;
			QButton val = _btnOthItmWtRemove;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOthItmWtRemove = value;
			val = _btnOthItmWtRemove;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOthItmWtRemove")]
	private virtual ComboBox _cboOthItmWtRemove;

	internal virtual ComboBox cboOthItmWtRemove
	{
		get
		{
			return _cboOthItmWtRemove;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOthItmWtRemove = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label47")]
	private virtual Label _Label47;

	internal virtual Label Label47
	{
		get
		{
			return _Label47;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label47 = value;
		}
	}

	internal virtual QButton btnSilverWt3digit
	{
		[CompilerGenerated]
		get
		{
			return _btnSilverWt3digit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSilverWt3digit_Click;
			QButton val = _btnSilverWt3digit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSilverWt3digit = value;
			val = _btnSilverWt3digit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSilverLedr3digit")]
	private virtual ComboBox _cboSilverLedr3digit;

	internal virtual ComboBox cboSilverLedr3digit
	{
		get
		{
			return _cboSilverLedr3digit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSilverLedr3digit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label48")]
	private virtual Label _Label48;

	internal virtual Label Label48
	{
		get
		{
			return _Label48;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label48 = value;
		}
	}

	internal virtual QButton btnWhSaleImg
	{
		[CompilerGenerated]
		get
		{
			return _btnWhSaleImg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhSaleImg_Click;
			QButton val = _btnWhSaleImg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhSaleImg = value;
			val = _btnWhSaleImg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboWhSaleImg")]
	private virtual ComboBox _cboWhSaleImg;

	internal virtual ComboBox cboWhSaleImg
	{
		get
		{
			return _cboWhSaleImg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboWhSaleImg = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label49")]
	private virtual Label _Label49;

	internal virtual Label Label49
	{
		get
		{
			return _Label49;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label49 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlSet")]
	private virtual Panel _pnlSet;

	internal virtual Panel pnlSet
	{
		get
		{
			return _pnlSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlSet = value;
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
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_CellContentClick);
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellContentClick -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellContentClick += val;
			}
		}
	}

	internal virtual QButton btnItmLotStk
	{
		[CompilerGenerated]
		get
		{
			return _btnItmLotStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnItmLotStk_Click;
			QButton val = _btnItmLotStk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItmLotStk = value;
			val = _btnItmLotStk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboitmWithLotStk")]
	private virtual ComboBox _cboitmWithLotStk;

	internal virtual ComboBox cboitmWithLotStk
	{
		get
		{
			return _cboitmWithLotStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboitmWithLotStk = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label50")]
	private virtual Label _Label50;

	internal virtual Label Label50
	{
		get
		{
			return _Label50;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label50 = value;
		}
	}

	internal virtual QButton btnFineStkType
	{
		[CompilerGenerated]
		get
		{
			return _btnFineStkType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnFineStkType_Click;
			QButton val = _btnFineStkType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFineStkType = value;
			val = _btnFineStkType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboFineStkType")]
	private virtual ComboBox _cboFineStkType;

	internal virtual ComboBox cboFineStkType
	{
		get
		{
			return _cboFineStkType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboFineStkType = value;
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

	internal virtual QButton brnRefresh
	{
		[CompilerGenerated]
		get
		{
			return _brnRefresh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = brnRefresh_Click;
			QButton val = _brnRefresh;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnRefresh = value;
			val = _brnRefresh;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboStkRefresh")]
	private virtual ComboBox _cboStkRefresh;

	internal virtual ComboBox cboStkRefresh
	{
		get
		{
			return _cboStkRefresh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboStkRefresh = value;
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

	internal virtual QButton btnMainFontChange
	{
		[CompilerGenerated]
		get
		{
			return _btnMainFontChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnMainFontChange_Click;
			QButton val = _btnMainFontChange;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMainFontChange = value;
			val = _btnMainFontChange;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboMainFontChange")]
	private virtual ComboBox _cboMainFontChange;

	internal virtual ComboBox cboMainFontChange
	{
		get
		{
			return _cboMainFontChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboMainFontChange = value;
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

	internal virtual QButton btnPurRateWith
	{
		[CompilerGenerated]
		get
		{
			return _btnPurRateWith;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurRateWith_Click;
			QButton val = _btnPurRateWith;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurRateWith = value;
			val = _btnPurRateWith;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPurRateWith")]
	private virtual ComboBox _cboPurRateWith;

	internal virtual ComboBox cboPurRateWith
	{
		get
		{
			return _cboPurRateWith;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPurRateWith = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label52")]
	private virtual Label _Label52;

	internal virtual Label Label52
	{
		get
		{
			return _Label52;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label52 = value;
		}
	}

	internal virtual QButton btnSlRateWith
	{
		[CompilerGenerated]
		get
		{
			return _btnSlRateWith;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlRateWith_Click;
			QButton val = _btnSlRateWith;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlRateWith = value;
			val = _btnSlRateWith;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSlRateWith")]
	private virtual ComboBox _cboSlRateWith;

	internal virtual ComboBox cboSlRateWith
	{
		get
		{
			return _cboSlRateWith;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSlRateWith = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label51")]
	private virtual Label _Label51;

	internal virtual Label Label51
	{
		get
		{
			return _Label51;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label51 = value;
		}
	}

	internal virtual QButton btnCrystalRptType
	{
		[CompilerGenerated]
		get
		{
			return _btnCrystalRptType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCrystalRptType_Click;
			QButton val = _btnCrystalRptType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCrystalRptType = value;
			val = _btnCrystalRptType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCrystalViewType")]
	private virtual ComboBox _cboCrystalViewType;

	internal virtual ComboBox cboCrystalViewType
	{
		get
		{
			return _cboCrystalViewType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCrystalViewType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label53")]
	private virtual Label _Label53;

	internal virtual Label Label53
	{
		get
		{
			return _Label53;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label53 = value;
		}
	}

	public UT_SETTING_MAIN()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += UT_SETTING_MAIN_Load;
		((Form)this).Activated += UT_SETTING_MAIN_Activated;
		((Form)this).Deactivate += UT_SETTING_MAIN_Deactivate;
		((Control)this).KeyDown += new KeyEventHandler(UT_SETTING_MAIN_KeyDown);
		((Form)this).Closed += UT_SETTING_MAIN_Closed;
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
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected O, but got Unknown
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Expected O, but got Unknown
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected O, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Expected O, but got Unknown
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Expected O, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Expected O, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Expected O, but got Unknown
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Expected O, but got Unknown
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Expected O, but got Unknown
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected O, but got Unknown
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected O, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected O, but got Unknown
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Expected O, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Expected O, but got Unknown
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0708: Expected O, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected O, but got Unknown
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Expected O, but got Unknown
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Expected O, but got Unknown
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected O, but got Unknown
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Expected O, but got Unknown
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Expected O, but got Unknown
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Expected O, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Expected O, but got Unknown
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected O, but got Unknown
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Expected O, but got Unknown
		//IL_078e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0798: Expected O, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a4: Expected O, but got Unknown
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b0: Expected O, but got Unknown
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Expected O, but got Unknown
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Expected O, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Expected O, but got Unknown
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected O, but got Unknown
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_0812: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Expected O, but got Unknown
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Expected O, but got Unknown
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Expected O, but got Unknown
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_084c: Expected O, but got Unknown
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected O, but got Unknown
		//IL_0866: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Expected O, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Expected O, but got Unknown
		//IL_088a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Expected O, but got Unknown
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ac: Expected O, but got Unknown
		//IL_0982: Unknown result type (might be due to invalid IL or missing references)
		//IL_098c: Expected O, but got Unknown
		//IL_0ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba9: Expected O, but got Unknown
		//IL_0c51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Expected O, but got Unknown
		//IL_0d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6f: Expected O, but got Unknown
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e95: Expected O, but got Unknown
		//IL_0ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f02: Expected O, but got Unknown
		//IL_0faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Expected O, but got Unknown
		//IL_1017: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Expected O, but got Unknown
		//IL_11d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11df: Expected O, but got Unknown
		//IL_1225: Unknown result type (might be due to invalid IL or missing references)
		//IL_122f: Expected O, but got Unknown
		//IL_1f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc0: Expected O, but got Unknown
		//IL_1fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2067: Unknown result type (might be due to invalid IL or missing references)
		//IL_2071: Expected O, but got Unknown
		//IL_20f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fc: Expected O, but got Unknown
		//IL_2248: Unknown result type (might be due to invalid IL or missing references)
		//IL_2252: Expected O, but got Unknown
		//IL_22e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f1: Expected O, but got Unknown
		//IL_236f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2379: Expected O, but got Unknown
		//IL_244e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2458: Expected O, but got Unknown
		//IL_24c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_24cb: Expected O, but got Unknown
		//IL_276b: Unknown result type (might be due to invalid IL or missing references)
		//IL_278f: Unknown result type (might be due to invalid IL or missing references)
		//IL_27b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2800: Unknown result type (might be due to invalid IL or missing references)
		//IL_280a: Expected O, but got Unknown
		//IL_2830: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_28bb: Expected O, but got Unknown
		//IL_2939: Unknown result type (might be due to invalid IL or missing references)
		//IL_2943: Expected O, but got Unknown
		//IL_2be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c86: Expected O, but got Unknown
		//IL_2cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d37: Expected O, but got Unknown
		//IL_2db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc2: Expected O, but got Unknown
		//IL_3062: Unknown result type (might be due to invalid IL or missing references)
		//IL_3086: Unknown result type (might be due to invalid IL or missing references)
		//IL_30aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_30ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3101: Expected O, but got Unknown
		//IL_3127: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_31b2: Expected O, but got Unknown
		//IL_3233: Unknown result type (might be due to invalid IL or missing references)
		//IL_323d: Expected O, but got Unknown
		//IL_34dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3501: Unknown result type (might be due to invalid IL or missing references)
		//IL_3525: Unknown result type (might be due to invalid IL or missing references)
		//IL_3549: Unknown result type (might be due to invalid IL or missing references)
		//IL_3572: Unknown result type (might be due to invalid IL or missing references)
		//IL_357c: Expected O, but got Unknown
		//IL_35a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3623: Unknown result type (might be due to invalid IL or missing references)
		//IL_362d: Expected O, but got Unknown
		//IL_36ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b8: Expected O, but got Unknown
		//IL_3958: Unknown result type (might be due to invalid IL or missing references)
		//IL_397c: Unknown result type (might be due to invalid IL or missing references)
		//IL_39a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_39c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_39ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_39f7: Expected O, but got Unknown
		//IL_3a1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aa8: Expected O, but got Unknown
		//IL_3b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b33: Expected O, but got Unknown
		//IL_3dd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3df7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e72: Expected O, but got Unknown
		//IL_3e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f19: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f23: Expected O, but got Unknown
		//IL_3fa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fae: Expected O, but got Unknown
		//IL_4252: Unknown result type (might be due to invalid IL or missing references)
		//IL_4276: Unknown result type (might be due to invalid IL or missing references)
		//IL_429a: Unknown result type (might be due to invalid IL or missing references)
		//IL_42be: Unknown result type (might be due to invalid IL or missing references)
		//IL_42e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_42f1: Expected O, but got Unknown
		//IL_4314: Unknown result type (might be due to invalid IL or missing references)
		//IL_4395: Unknown result type (might be due to invalid IL or missing references)
		//IL_439f: Expected O, but got Unknown
		//IL_441d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4427: Expected O, but got Unknown
		//IL_46c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_46ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_4710: Unknown result type (might be due to invalid IL or missing references)
		//IL_4734: Unknown result type (might be due to invalid IL or missing references)
		//IL_475d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4767: Expected O, but got Unknown
		//IL_478a: Unknown result type (might be due to invalid IL or missing references)
		//IL_480b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4815: Expected O, but got Unknown
		//IL_4893: Unknown result type (might be due to invalid IL or missing references)
		//IL_489d: Expected O, but got Unknown
		//IL_4b3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ba7: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bda: Expected O, but got Unknown
		//IL_4c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c8b: Expected O, but got Unknown
		//IL_4d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d15: Expected O, but got Unknown
		//IL_4fb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_5001: Unknown result type (might be due to invalid IL or missing references)
		//IL_5025: Unknown result type (might be due to invalid IL or missing references)
		//IL_504e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5058: Expected O, but got Unknown
		//IL_507e: Unknown result type (might be due to invalid IL or missing references)
		//IL_50ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_5109: Expected O, but got Unknown
		//IL_5189: Unknown result type (might be due to invalid IL or missing references)
		//IL_5193: Expected O, but got Unknown
		//IL_5437: Unknown result type (might be due to invalid IL or missing references)
		//IL_545b: Unknown result type (might be due to invalid IL or missing references)
		//IL_547f: Unknown result type (might be due to invalid IL or missing references)
		//IL_54a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_54cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_54d6: Expected O, but got Unknown
		//IL_54fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_557d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5587: Expected O, but got Unknown
		//IL_5608: Unknown result type (might be due to invalid IL or missing references)
		//IL_5612: Expected O, but got Unknown
		//IL_58b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_58d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_58fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_591f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5948: Unknown result type (might be due to invalid IL or missing references)
		//IL_5952: Expected O, but got Unknown
		//IL_5978: Unknown result type (might be due to invalid IL or missing references)
		//IL_59de: Unknown result type (might be due to invalid IL or missing references)
		//IL_59e8: Expected O, but got Unknown
		//IL_5a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5aa6: Expected O, but got Unknown
		//IL_5d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5dc5: Expected O, but got Unknown
		//IL_5de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e73: Expected O, but got Unknown
		//IL_5ef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_5efb: Expected O, but got Unknown
		//IL_619c: Unknown result type (might be due to invalid IL or missing references)
		//IL_61c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_61e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_6208: Unknown result type (might be due to invalid IL or missing references)
		//IL_6231: Unknown result type (might be due to invalid IL or missing references)
		//IL_623b: Expected O, but got Unknown
		//IL_6261: Unknown result type (might be due to invalid IL or missing references)
		//IL_62e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_62ec: Expected O, but got Unknown
		//IL_636d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6377: Expected O, but got Unknown
		//IL_6618: Unknown result type (might be due to invalid IL or missing references)
		//IL_663c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6660: Unknown result type (might be due to invalid IL or missing references)
		//IL_6684: Unknown result type (might be due to invalid IL or missing references)
		//IL_66ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_66b7: Expected O, but got Unknown
		//IL_66dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_675e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6768: Expected O, but got Unknown
		//IL_67e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_67f3: Expected O, but got Unknown
		//IL_6a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_6adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b33: Expected O, but got Unknown
		//IL_6b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_6bda: Unknown result type (might be due to invalid IL or missing references)
		//IL_6be4: Expected O, but got Unknown
		//IL_6c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c6f: Expected O, but got Unknown
		//IL_6f10: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6fa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_6faf: Expected O, but got Unknown
		//IL_6fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_7056: Unknown result type (might be due to invalid IL or missing references)
		//IL_7060: Expected O, but got Unknown
		//IL_70e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_70eb: Expected O, but got Unknown
		//IL_738c: Unknown result type (might be due to invalid IL or missing references)
		//IL_73b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_73d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_73f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_7421: Unknown result type (might be due to invalid IL or missing references)
		//IL_742b: Expected O, but got Unknown
		//IL_7451: Unknown result type (might be due to invalid IL or missing references)
		//IL_74d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_74dc: Expected O, but got Unknown
		//IL_755d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7567: Expected O, but got Unknown
		//IL_7808: Unknown result type (might be due to invalid IL or missing references)
		//IL_782c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7850: Unknown result type (might be due to invalid IL or missing references)
		//IL_7874: Unknown result type (might be due to invalid IL or missing references)
		//IL_789d: Unknown result type (might be due to invalid IL or missing references)
		//IL_78a7: Expected O, but got Unknown
		//IL_78cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_794e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7958: Expected O, but got Unknown
		//IL_79d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_79e3: Expected O, but got Unknown
		//IL_7c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_7cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_7cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d26: Expected O, but got Unknown
		//IL_7d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_7dd7: Expected O, but got Unknown
		//IL_7e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e62: Expected O, but got Unknown
		//IL_8103: Unknown result type (might be due to invalid IL or missing references)
		//IL_8127: Unknown result type (might be due to invalid IL or missing references)
		//IL_814b: Unknown result type (might be due to invalid IL or missing references)
		//IL_816f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8198: Unknown result type (might be due to invalid IL or missing references)
		//IL_81a2: Expected O, but got Unknown
		//IL_81c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_8249: Unknown result type (might be due to invalid IL or missing references)
		//IL_8253: Expected O, but got Unknown
		//IL_82d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_82de: Expected O, but got Unknown
		//IL_857e: Unknown result type (might be due to invalid IL or missing references)
		//IL_85a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_85c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_85ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_8613: Unknown result type (might be due to invalid IL or missing references)
		//IL_861d: Expected O, but got Unknown
		//IL_8640: Unknown result type (might be due to invalid IL or missing references)
		//IL_86c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_86cb: Expected O, but got Unknown
		//IL_8749: Unknown result type (might be due to invalid IL or missing references)
		//IL_8753: Expected O, but got Unknown
		//IL_89f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a8f: Expected O, but got Unknown
		//IL_8ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b36: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b40: Expected O, but got Unknown
		//IL_8bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_8bcb: Expected O, but got Unknown
		//IL_8e6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_8eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ed8: Unknown result type (might be due to invalid IL or missing references)
		//IL_8f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_8f0b: Expected O, but got Unknown
		//IL_8f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_8fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_8fbc: Expected O, but got Unknown
		//IL_903c: Unknown result type (might be due to invalid IL or missing references)
		//IL_9046: Expected O, but got Unknown
		//IL_92ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_930e: Unknown result type (might be due to invalid IL or missing references)
		//IL_9332: Unknown result type (might be due to invalid IL or missing references)
		//IL_9356: Unknown result type (might be due to invalid IL or missing references)
		//IL_937f: Unknown result type (might be due to invalid IL or missing references)
		//IL_9389: Expected O, but got Unknown
		//IL_93af: Unknown result type (might be due to invalid IL or missing references)
		//IL_9430: Unknown result type (might be due to invalid IL or missing references)
		//IL_943a: Expected O, but got Unknown
		//IL_94ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_94c4: Expected O, but got Unknown
		//IL_9768: Unknown result type (might be due to invalid IL or missing references)
		//IL_978c: Unknown result type (might be due to invalid IL or missing references)
		//IL_97b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_97d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_97fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_9807: Expected O, but got Unknown
		//IL_982a: Unknown result type (might be due to invalid IL or missing references)
		//IL_98ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_98b5: Expected O, but got Unknown
		//IL_9933: Unknown result type (might be due to invalid IL or missing references)
		//IL_993d: Expected O, but got Unknown
		//IL_9bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_9c7d: Expected O, but got Unknown
		//IL_9ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_9d21: Unknown result type (might be due to invalid IL or missing references)
		//IL_9d2b: Expected O, but got Unknown
		//IL_9da9: Unknown result type (might be due to invalid IL or missing references)
		//IL_9db3: Expected O, but got Unknown
		//IL_a054: Unknown result type (might be due to invalid IL or missing references)
		//IL_a078: Unknown result type (might be due to invalid IL or missing references)
		//IL_a09c: Unknown result type (might be due to invalid IL or missing references)
		//IL_a0c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_a0e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_a0f3: Expected O, but got Unknown
		//IL_a119: Unknown result type (might be due to invalid IL or missing references)
		//IL_a19a: Unknown result type (might be due to invalid IL or missing references)
		//IL_a1a4: Expected O, but got Unknown
		//IL_a225: Unknown result type (might be due to invalid IL or missing references)
		//IL_a22f: Expected O, but got Unknown
		//IL_a4d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_a4f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_a518: Unknown result type (might be due to invalid IL or missing references)
		//IL_a53c: Unknown result type (might be due to invalid IL or missing references)
		//IL_a565: Unknown result type (might be due to invalid IL or missing references)
		//IL_a56f: Expected O, but got Unknown
		//IL_a595: Unknown result type (might be due to invalid IL or missing references)
		//IL_a616: Unknown result type (might be due to invalid IL or missing references)
		//IL_a620: Expected O, but got Unknown
		//IL_a6a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_a6ab: Expected O, but got Unknown
		//IL_a94f: Unknown result type (might be due to invalid IL or missing references)
		//IL_a973: Unknown result type (might be due to invalid IL or missing references)
		//IL_a997: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_a9ee: Expected O, but got Unknown
		//IL_aa14: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa95: Unknown result type (might be due to invalid IL or missing references)
		//IL_aa9f: Expected O, but got Unknown
		//IL_ab20: Unknown result type (might be due to invalid IL or missing references)
		//IL_ab2a: Expected O, but got Unknown
		//IL_adce: Unknown result type (might be due to invalid IL or missing references)
		//IL_adf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae16: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae63: Unknown result type (might be due to invalid IL or missing references)
		//IL_ae6d: Expected O, but got Unknown
		//IL_ae90: Unknown result type (might be due to invalid IL or missing references)
		//IL_af11: Unknown result type (might be due to invalid IL or missing references)
		//IL_af1b: Expected O, but got Unknown
		//IL_af99: Unknown result type (might be due to invalid IL or missing references)
		//IL_afa3: Expected O, but got Unknown
		//IL_b240: Unknown result type (might be due to invalid IL or missing references)
		//IL_b264: Unknown result type (might be due to invalid IL or missing references)
		//IL_b288: Unknown result type (might be due to invalid IL or missing references)
		//IL_b2ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_b2d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_b2df: Expected O, but got Unknown
		//IL_b305: Unknown result type (might be due to invalid IL or missing references)
		//IL_b386: Unknown result type (might be due to invalid IL or missing references)
		//IL_b390: Expected O, but got Unknown
		//IL_b411: Unknown result type (might be due to invalid IL or missing references)
		//IL_b41b: Expected O, but got Unknown
		//IL_b6bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_b6e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_b707: Unknown result type (might be due to invalid IL or missing references)
		//IL_b72b: Unknown result type (might be due to invalid IL or missing references)
		//IL_b754: Unknown result type (might be due to invalid IL or missing references)
		//IL_b75e: Expected O, but got Unknown
		//IL_b781: Unknown result type (might be due to invalid IL or missing references)
		//IL_b802: Unknown result type (might be due to invalid IL or missing references)
		//IL_b80c: Expected O, but got Unknown
		//IL_b88a: Unknown result type (might be due to invalid IL or missing references)
		//IL_b894: Expected O, but got Unknown
		//IL_bb35: Unknown result type (might be due to invalid IL or missing references)
		//IL_bb59: Unknown result type (might be due to invalid IL or missing references)
		//IL_bb7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_bba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbca: Unknown result type (might be due to invalid IL or missing references)
		//IL_bbd4: Expected O, but got Unknown
		//IL_bbf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc78: Unknown result type (might be due to invalid IL or missing references)
		//IL_bc82: Expected O, but got Unknown
		//IL_bd00: Unknown result type (might be due to invalid IL or missing references)
		//IL_bd0a: Expected O, but got Unknown
		//IL_c4ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_c512: Unknown result type (might be due to invalid IL or missing references)
		//IL_c536: Unknown result type (might be due to invalid IL or missing references)
		//IL_c55a: Unknown result type (might be due to invalid IL or missing references)
		//IL_c583: Unknown result type (might be due to invalid IL or missing references)
		//IL_c58d: Expected O, but got Unknown
		//IL_c5b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_c645: Unknown result type (might be due to invalid IL or missing references)
		//IL_c64f: Expected O, but got Unknown
		//IL_c6d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_c6da: Expected O, but got Unknown
		//IL_c97e: Unknown result type (might be due to invalid IL or missing references)
		//IL_c9a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_c9c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_c9ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca13: Unknown result type (might be due to invalid IL or missing references)
		//IL_ca1d: Expected O, but got Unknown
		//IL_ca40: Unknown result type (might be due to invalid IL or missing references)
		//IL_cad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_cadc: Expected O, but got Unknown
		//IL_cb5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_cb64: Expected O, but got Unknown
		//IL_ce05: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce29: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce71: Unknown result type (might be due to invalid IL or missing references)
		//IL_ce9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_cea4: Expected O, but got Unknown
		//IL_cec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_d14e: Unknown result type (might be due to invalid IL or missing references)
		//IL_d172: Unknown result type (might be due to invalid IL or missing references)
		//IL_d196: Unknown result type (might be due to invalid IL or missing references)
		//IL_d1ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_d1e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_d1ed: Expected O, but got Unknown
		//IL_d210: Unknown result type (might be due to invalid IL or missing references)
		//IL_d2a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_d2ac: Expected O, but got Unknown
		//IL_d32a: Unknown result type (might be due to invalid IL or missing references)
		//IL_d334: Expected O, but got Unknown
		//IL_d5d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_d5f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_d61d: Unknown result type (might be due to invalid IL or missing references)
		//IL_d641: Unknown result type (might be due to invalid IL or missing references)
		//IL_d66a: Unknown result type (might be due to invalid IL or missing references)
		//IL_d674: Expected O, but got Unknown
		//IL_d697: Unknown result type (might be due to invalid IL or missing references)
		//IL_d729: Unknown result type (might be due to invalid IL or missing references)
		//IL_d733: Expected O, but got Unknown
		//IL_d7b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_d7bb: Expected O, but got Unknown
		//IL_da5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_da80: Unknown result type (might be due to invalid IL or missing references)
		//IL_daa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_dac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_daf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_dafd: Expected O, but got Unknown
		//IL_db23: Unknown result type (might be due to invalid IL or missing references)
		//IL_dbc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_dbd1: Expected O, but got Unknown
		//IL_dc52: Unknown result type (might be due to invalid IL or missing references)
		//IL_dc5c: Expected O, but got Unknown
		//IL_defc: Unknown result type (might be due to invalid IL or missing references)
		//IL_df20: Unknown result type (might be due to invalid IL or missing references)
		//IL_df44: Unknown result type (might be due to invalid IL or missing references)
		//IL_df68: Unknown result type (might be due to invalid IL or missing references)
		//IL_df93: Unknown result type (might be due to invalid IL or missing references)
		//IL_df9d: Expected O, but got Unknown
		//IL_dfc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_e067: Unknown result type (might be due to invalid IL or missing references)
		//IL_e071: Expected O, but got Unknown
		//IL_e0f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_e0fc: Expected O, but got Unknown
		//IL_e39c: Unknown result type (might be due to invalid IL or missing references)
		//IL_e3c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_e3e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_e408: Unknown result type (might be due to invalid IL or missing references)
		//IL_e431: Unknown result type (might be due to invalid IL or missing references)
		//IL_e43b: Expected O, but got Unknown
		//IL_e461: Unknown result type (might be due to invalid IL or missing references)
		//IL_e505: Unknown result type (might be due to invalid IL or missing references)
		//IL_e50f: Expected O, but got Unknown
		//IL_e590: Unknown result type (might be due to invalid IL or missing references)
		//IL_e59a: Expected O, but got Unknown
		//IL_e83a: Unknown result type (might be due to invalid IL or missing references)
		//IL_e85e: Unknown result type (might be due to invalid IL or missing references)
		//IL_e882: Unknown result type (might be due to invalid IL or missing references)
		//IL_e8a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_e8cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_e8d9: Expected O, but got Unknown
		//IL_e8ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_e9a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_e9ad: Expected O, but got Unknown
		//IL_ea2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ea38: Expected O, but got Unknown
		//IL_ecd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_ecfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed21: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed45: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ed78: Expected O, but got Unknown
		//IL_ed9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee42: Unknown result type (might be due to invalid IL or missing references)
		//IL_ee4c: Expected O, but got Unknown
		//IL_eecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_eed7: Expected O, but got Unknown
		//IL_f178: Unknown result type (might be due to invalid IL or missing references)
		//IL_f19c: Unknown result type (might be due to invalid IL or missing references)
		//IL_f1c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_f1e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_f20d: Unknown result type (might be due to invalid IL or missing references)
		//IL_f217: Expected O, but got Unknown
		//IL_f23d: Unknown result type (might be due to invalid IL or missing references)
		//IL_f2e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_f2eb: Expected O, but got Unknown
		//IL_f36c: Unknown result type (might be due to invalid IL or missing references)
		//IL_f376: Expected O, but got Unknown
		//IL_f616: Unknown result type (might be due to invalid IL or missing references)
		//IL_f63a: Unknown result type (might be due to invalid IL or missing references)
		//IL_f65e: Unknown result type (might be due to invalid IL or missing references)
		//IL_f682: Unknown result type (might be due to invalid IL or missing references)
		//IL_f6ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_f6b5: Expected O, but got Unknown
		//IL_f6db: Unknown result type (might be due to invalid IL or missing references)
		//IL_f77f: Unknown result type (might be due to invalid IL or missing references)
		//IL_f789: Expected O, but got Unknown
		//IL_f80a: Unknown result type (might be due to invalid IL or missing references)
		//IL_f814: Expected O, but got Unknown
		//IL_fab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_fad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_fafd: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb21: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_fb54: Expected O, but got Unknown
		//IL_fb77: Unknown result type (might be due to invalid IL or missing references)
		//IL_fc1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_fc25: Expected O, but got Unknown
		//IL_fca3: Unknown result type (might be due to invalid IL or missing references)
		//IL_fcad: Expected O, but got Unknown
		//IL_fd68: Unknown result type (might be due to invalid IL or missing references)
		//IL_fd72: Expected O, but got Unknown
		//IL_fdf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_fdfa: Expected O, but got Unknown
		//IL_10098: Unknown result type (might be due to invalid IL or missing references)
		//IL_100bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_100e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10104: Unknown result type (might be due to invalid IL or missing references)
		//IL_1012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10137: Expected O, but got Unknown
		//IL_1015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_101ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f6: Expected O, but got Unknown
		//IL_10274: Unknown result type (might be due to invalid IL or missing references)
		//IL_1027e: Expected O, but got Unknown
		//IL_1076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_107b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10800: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080a: Expected O, but got Unknown
		//IL_10830: Unknown result type (might be due to invalid IL or missing references)
		//IL_108b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_108bb: Expected O, but got Unknown
		//IL_10939: Unknown result type (might be due to invalid IL or missing references)
		//IL_10943: Expected O, but got Unknown
		//IL_10be3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c82: Expected O, but got Unknown
		//IL_10ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d30: Expected O, but got Unknown
		//IL_10dab: Unknown result type (might be due to invalid IL or missing references)
		//IL_10db5: Expected O, but got Unknown
		//IL_11053: Unknown result type (might be due to invalid IL or missing references)
		//IL_11077: Unknown result type (might be due to invalid IL or missing references)
		//IL_1109b: Unknown result type (might be due to invalid IL or missing references)
		//IL_110bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_110e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_110f2: Expected O, but got Unknown
		//IL_11115: Unknown result type (might be due to invalid IL or missing references)
		//IL_11196: Unknown result type (might be due to invalid IL or missing references)
		//IL_111a0: Expected O, but got Unknown
		//IL_1121b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11225: Expected O, but got Unknown
		//IL_114c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_114e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1150b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1152f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11558: Unknown result type (might be due to invalid IL or missing references)
		//IL_11562: Expected O, but got Unknown
		//IL_11585: Unknown result type (might be due to invalid IL or missing references)
		//IL_11606: Unknown result type (might be due to invalid IL or missing references)
		//IL_11610: Expected O, but got Unknown
		//IL_1168b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11695: Expected O, but got Unknown
		//IL_11986: Unknown result type (might be due to invalid IL or missing references)
		//IL_119aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_119ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_119f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a25: Expected O, but got Unknown
		//IL_11a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11add: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ae7: Expected O, but got Unknown
		//IL_11b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b72: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_SETTING_MAIN));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		btnMainFontChange = new QButton();
		cboMainFontChange = new ComboBox();
		Label7 = new Label();
		pnlSet = new Panel();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		btnFineStkType = new QButton();
		cboFineStkType = new ComboBox();
		Label8 = new Label();
		btnWhSaleImg = new QButton();
		cboWhSaleImg = new ComboBox();
		Label49 = new Label();
		btnAprlImg = new QButton();
		cboAprlImg = new ComboBox();
		Label46 = new Label();
		BtnDhrnImgPrint = new QButton();
		cboDhrnImgPrint = new ComboBox();
		Label44 = new Label();
		brnImgWithWt = new QButton();
		cboImgWithWt = new ComboBox();
		Label43 = new Label();
		btnOrdTagStkLess = new QButton();
		cboOrdTagStkLess = new ComboBox();
		Label40 = new Label();
		brnReminderType = new QButton();
		cboReminderType = new ComboBox();
		Label38 = new Label();
		btnRptTotShow = new QButton();
		cboRptTotShow = new ComboBox();
		Label37 = new Label();
		BtnSchmWapp = new QButton();
		cboSchmWapp = new ComboBox();
		Label36 = new Label();
		btnDhrnWapp = new QButton();
		cboDhrnWapp = new ComboBox();
		Label35 = new Label();
		btnEstmatTax = new QButton();
		cboEstmateWithTax = new ComboBox();
		Label32 = new Label();
		btnDcMemb = new QButton();
		Label27 = new Label();
		tDcPwd = new TextBox();
		BtnCashLimit = new QButton();
		cboCashLimit = new ComboBox();
		Label26 = new Label();
		btnPreviousLock = new QButton();
		cboPreviousLock = new ComboBox();
		Label25 = new Label();
		btnGridRowHeightSet = new QButton();
		cboGridRowHeight = new ComboBox();
		Label24 = new Label();
		btnFontStyle = new QButton();
		cboFontStyle = new ComboBox();
		Label23 = new Label();
		btnFontName = new QButton();
		CboFontName = new ComboBox();
		Label22 = new Label();
		btnFontSize = new QButton();
		cboFontSize = new ComboBox();
		Label21 = new Label();
		btnFontChang = new QButton();
		cboFontChange = new ComboBox();
		Label20 = new Label();
		btnEmpMandotry = new QButton();
		cboEmpMandatory = new ComboBox();
		Label19 = new Label();
		btnPrintFormSet = new QButton();
		cboPrintFormSet = new ComboBox();
		Label18 = new Label();
		btnOrdImage = new QButton();
		cboOrdImage = new ComboBox();
		Label12 = new Label();
		btnDesignGen = new QButton();
		cboDesignGen = new ComboBox();
		Label11 = new Label();
		btnWappSlprint = new QButton();
		cboWappSlPrint = new ComboBox();
		Label10 = new Label();
		btnCountryId = new QButton();
		cboCountryid = new ComboBox();
		Label9 = new Label();
		btnCustSms = new QButton();
		cboCustSms = new ComboBox();
		Label17 = new Label();
		btnAdminSms = new QButton();
		cboAdminSms = new ComboBox();
		Label16 = new Label();
		btnPrRateRof = new QButton();
		cboPrRateRof = new ComboBox();
		Label15 = new Label();
		btnBalSheetType = new QButton();
		cboBalSheetType = new ComboBox();
		Label4 = new Label();
		btnTotFineStkType = new QButton();
		cboTotFineStkType = new ComboBox();
		lblTotFineStk = new Label();
		btnSlImgPrint = new QButton();
		cboSalesImagPrint = new ComboBox();
		Label3 = new Label();
		btnLoanIntDay = new QButton();
		cboLoanIntType = new ComboBox();
		Label6 = new Label();
		btnCustOsSms = new QButton();
		cboCustOsSms = new ComboBox();
		Label2 = new Label();
		btnQrcode = new QButton();
		cboQrCode = new ComboBox();
		Label1 = new Label();
		Tab1 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		btnPurRateWith = new QButton();
		cboPurRateWith = new ComboBox();
		Label52 = new Label();
		btnSlRateWith = new QButton();
		cboSlRateWith = new ComboBox();
		Label51 = new Label();
		btnScrolbar = new QButton();
		brnRefresh = new QButton();
		cboStkRefresh = new ComboBox();
		Label5 = new Label();
		btnItmLotStk = new QButton();
		cboitmWithLotStk = new ComboBox();
		Label50 = new Label();
		btnSilverWt3digit = new QButton();
		cboSilverLedr3digit = new ComboBox();
		Label48 = new Label();
		btnOthItmWtRemove = new QButton();
		cboOthItmWtRemove = new ComboBox();
		Label47 = new Label();
		btnLbrWithGht = new QButton();
		cboLbrWitGht = new ComboBox();
		Label45 = new Label();
		btnAllBranchAcShow = new QButton();
		cboAllBrancAcShow = new ComboBox();
		Label41 = new Label();
		btnTagRowPrint = new QButton();
		cboTagRowPrint = new ComboBox();
		Label34 = new Label();
		btnTagRowSave = new QButton();
		cboTagRowSave = new ComboBox();
		Label33 = new Label();
		btnTagSlWtDiff = new QButton();
		cboTagSaleWtDiff = new ComboBox();
		Label31 = new Label();
		btnStkRptType = new QButton();
		cboStkRptType = new ComboBox();
		Label30 = new Label();
		cboScorlbar = new ComboBox();
		Label29 = new Label();
		btnBillTitRof = new QButton();
		cboBilTotRof = new ComboBox();
		Label28 = new Label();
		Tab3 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		btnEmpAsUser = new QButton();
		cboEmpAsUser = new ComboBox();
		Label42 = new Label();
		btnHelpLent = new QButton();
		cboHelpLent = new ComboBox();
		Label39 = new Label();
		btnMobileSearch = new QButton();
		cboMobileSearch = new ComboBox();
		Label14 = new Label();
		btnOrnaIsu = new QButton();
		cboOrnaIsu = new ComboBox();
		Label13 = new Label();
		Tab2 = new SuperTabItem();
		btnCrystalRptType = new QButton();
		cboCrystalViewType = new ComboBox();
		Label53 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)pnlSet).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)TabPanel3).SuspendLayout();
		((Control)Pnl3).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)Pnl2).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(192, 0, 0);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Setting Main";
		lblBook.TextAlign = (ContentAlignment)32;
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
		((BaseItem)TabMenu.ControlBox.CloseBox).Name = "";
		((BaseItem)TabMenu.ControlBox.MenuBox).Name = "";
		((BaseItem)TabMenu.ControlBox).Name = "";
		((BaseItem)TabMenu.ControlBox).SubItems.AddRange((BaseItem[])(object)new BaseItem[2]
		{
			(BaseItem)TabMenu.ControlBox.MenuBox,
			(BaseItem)TabMenu.ControlBox.CloseBox
		});
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel1);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel3);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel2);
		((Control)TabMenu).Dock = (DockStyle)5;
		((Control)TabMenu).Location = new Point(0, 32);
		((Control)TabMenu).Name = "TabMenu";
		TabMenu.ReorderTabsEnabled = true;
		TabMenu.SelectedTabFont = new Font("Microsoft Sans Serif", 11.25f);
		TabMenu.SelectedTabIndex = 0;
		((Control)TabMenu).Size = new Size(1309, 534);
		TabMenu.TabAlignment = (eTabStripAlignment)3;
		TabMenu.TabFont = new Font("Microsoft Sans Serif", 11.25f);
		((Control)TabMenu).TabIndex = 1127;
		TabMenu.TabLayoutType = (eSuperTabLayoutType)1;
		TabMenu.Tabs.AddRange((BaseItem[])(object)new BaseItem[3]
		{
			(BaseItem)Tab1,
			(BaseItem)Tab2,
			(BaseItem)Tab3
		});
		TabMenu.TabStyle = (eSuperTabStyle)1;
		((Control)TabMenu).Text = "SuperTabControl1";
		((PanelControl)TabPanel1).CanvasColor = Color.Black;
		((Control)TabPanel1).Controls.Add((Control)(object)Pnl1);
		TabPanel1.Dock = (DockStyle)5;
		((Control)TabPanel1).Location = new Point(0, 0);
		((Control)TabPanel1).Name = "TabPanel1";
		((Control)TabPanel1).Size = new Size(1309, 507);
		((Control)TabPanel1).TabIndex = 0;
		TabPanel1.TabItem = Tab1;
		((Control)Pnl1).Controls.Add((Control)(object)btnMainFontChange);
		((Control)Pnl1).Controls.Add((Control)(object)cboMainFontChange);
		((Control)Pnl1).Controls.Add((Control)(object)Label7);
		((Control)Pnl1).Controls.Add((Control)(object)pnlSet);
		((Control)Pnl1).Controls.Add((Control)(object)btnFineStkType);
		((Control)Pnl1).Controls.Add((Control)(object)cboFineStkType);
		((Control)Pnl1).Controls.Add((Control)(object)Label8);
		((Control)Pnl1).Controls.Add((Control)(object)btnWhSaleImg);
		((Control)Pnl1).Controls.Add((Control)(object)cboWhSaleImg);
		((Control)Pnl1).Controls.Add((Control)(object)Label49);
		((Control)Pnl1).Controls.Add((Control)(object)btnAprlImg);
		((Control)Pnl1).Controls.Add((Control)(object)cboAprlImg);
		((Control)Pnl1).Controls.Add((Control)(object)Label46);
		((Control)Pnl1).Controls.Add((Control)(object)BtnDhrnImgPrint);
		((Control)Pnl1).Controls.Add((Control)(object)cboDhrnImgPrint);
		((Control)Pnl1).Controls.Add((Control)(object)Label44);
		((Control)Pnl1).Controls.Add((Control)(object)brnImgWithWt);
		((Control)Pnl1).Controls.Add((Control)(object)cboImgWithWt);
		((Control)Pnl1).Controls.Add((Control)(object)Label43);
		((Control)Pnl1).Controls.Add((Control)(object)btnOrdTagStkLess);
		((Control)Pnl1).Controls.Add((Control)(object)cboOrdTagStkLess);
		((Control)Pnl1).Controls.Add((Control)(object)Label40);
		((Control)Pnl1).Controls.Add((Control)(object)brnReminderType);
		((Control)Pnl1).Controls.Add((Control)(object)cboReminderType);
		((Control)Pnl1).Controls.Add((Control)(object)Label38);
		((Control)Pnl1).Controls.Add((Control)(object)btnRptTotShow);
		((Control)Pnl1).Controls.Add((Control)(object)cboRptTotShow);
		((Control)Pnl1).Controls.Add((Control)(object)Label37);
		((Control)Pnl1).Controls.Add((Control)(object)BtnSchmWapp);
		((Control)Pnl1).Controls.Add((Control)(object)cboSchmWapp);
		((Control)Pnl1).Controls.Add((Control)(object)Label36);
		((Control)Pnl1).Controls.Add((Control)(object)btnDhrnWapp);
		((Control)Pnl1).Controls.Add((Control)(object)cboDhrnWapp);
		((Control)Pnl1).Controls.Add((Control)(object)Label35);
		((Control)Pnl1).Controls.Add((Control)(object)btnEstmatTax);
		((Control)Pnl1).Controls.Add((Control)(object)cboEstmateWithTax);
		((Control)Pnl1).Controls.Add((Control)(object)Label32);
		((Control)Pnl1).Controls.Add((Control)(object)btnDcMemb);
		((Control)Pnl1).Controls.Add((Control)(object)Label27);
		((Control)Pnl1).Controls.Add((Control)(object)tDcPwd);
		((Control)Pnl1).Controls.Add((Control)(object)BtnCashLimit);
		((Control)Pnl1).Controls.Add((Control)(object)cboCashLimit);
		((Control)Pnl1).Controls.Add((Control)(object)Label26);
		((Control)Pnl1).Controls.Add((Control)(object)btnPreviousLock);
		((Control)Pnl1).Controls.Add((Control)(object)cboPreviousLock);
		((Control)Pnl1).Controls.Add((Control)(object)Label25);
		((Control)Pnl1).Controls.Add((Control)(object)btnGridRowHeightSet);
		((Control)Pnl1).Controls.Add((Control)(object)cboGridRowHeight);
		((Control)Pnl1).Controls.Add((Control)(object)Label24);
		((Control)Pnl1).Controls.Add((Control)(object)btnFontStyle);
		((Control)Pnl1).Controls.Add((Control)(object)cboFontStyle);
		((Control)Pnl1).Controls.Add((Control)(object)Label23);
		((Control)Pnl1).Controls.Add((Control)(object)btnFontName);
		((Control)Pnl1).Controls.Add((Control)(object)CboFontName);
		((Control)Pnl1).Controls.Add((Control)(object)Label22);
		((Control)Pnl1).Controls.Add((Control)(object)btnFontSize);
		((Control)Pnl1).Controls.Add((Control)(object)cboFontSize);
		((Control)Pnl1).Controls.Add((Control)(object)Label21);
		((Control)Pnl1).Controls.Add((Control)(object)btnFontChang);
		((Control)Pnl1).Controls.Add((Control)(object)cboFontChange);
		((Control)Pnl1).Controls.Add((Control)(object)Label20);
		((Control)Pnl1).Controls.Add((Control)(object)btnEmpMandotry);
		((Control)Pnl1).Controls.Add((Control)(object)cboEmpMandatory);
		((Control)Pnl1).Controls.Add((Control)(object)Label19);
		((Control)Pnl1).Controls.Add((Control)(object)btnPrintFormSet);
		((Control)Pnl1).Controls.Add((Control)(object)cboPrintFormSet);
		((Control)Pnl1).Controls.Add((Control)(object)Label18);
		((Control)Pnl1).Controls.Add((Control)(object)btnOrdImage);
		((Control)Pnl1).Controls.Add((Control)(object)cboOrdImage);
		((Control)Pnl1).Controls.Add((Control)(object)Label12);
		((Control)Pnl1).Controls.Add((Control)(object)btnDesignGen);
		((Control)Pnl1).Controls.Add((Control)(object)cboDesignGen);
		((Control)Pnl1).Controls.Add((Control)(object)Label11);
		((Control)Pnl1).Controls.Add((Control)(object)btnWappSlprint);
		((Control)Pnl1).Controls.Add((Control)(object)cboWappSlPrint);
		((Control)Pnl1).Controls.Add((Control)(object)Label10);
		((Control)Pnl1).Controls.Add((Control)(object)btnCountryId);
		((Control)Pnl1).Controls.Add((Control)(object)cboCountryid);
		((Control)Pnl1).Controls.Add((Control)(object)Label9);
		((Control)Pnl1).Controls.Add((Control)(object)btnCustSms);
		((Control)Pnl1).Controls.Add((Control)(object)cboCustSms);
		((Control)Pnl1).Controls.Add((Control)(object)Label17);
		((Control)Pnl1).Controls.Add((Control)(object)btnAdminSms);
		((Control)Pnl1).Controls.Add((Control)(object)cboAdminSms);
		((Control)Pnl1).Controls.Add((Control)(object)Label16);
		((Control)Pnl1).Controls.Add((Control)(object)btnPrRateRof);
		((Control)Pnl1).Controls.Add((Control)(object)cboPrRateRof);
		((Control)Pnl1).Controls.Add((Control)(object)Label15);
		((Control)Pnl1).Controls.Add((Control)(object)btnBalSheetType);
		((Control)Pnl1).Controls.Add((Control)(object)cboBalSheetType);
		((Control)Pnl1).Controls.Add((Control)(object)Label4);
		((Control)Pnl1).Controls.Add((Control)(object)btnTotFineStkType);
		((Control)Pnl1).Controls.Add((Control)(object)cboTotFineStkType);
		((Control)Pnl1).Controls.Add((Control)(object)lblTotFineStk);
		((Control)Pnl1).Controls.Add((Control)(object)btnSlImgPrint);
		((Control)Pnl1).Controls.Add((Control)(object)cboSalesImagPrint);
		((Control)Pnl1).Controls.Add((Control)(object)Label3);
		((Control)Pnl1).Controls.Add((Control)(object)btnLoanIntDay);
		((Control)Pnl1).Controls.Add((Control)(object)cboLoanIntType);
		((Control)Pnl1).Controls.Add((Control)(object)Label6);
		((Control)Pnl1).Controls.Add((Control)(object)btnCustOsSms);
		((Control)Pnl1).Controls.Add((Control)(object)cboCustOsSms);
		((Control)Pnl1).Controls.Add((Control)(object)Label2);
		((Control)Pnl1).Controls.Add((Control)(object)btnQrcode);
		((Control)Pnl1).Controls.Add((Control)(object)cboQrCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		((Control)Pnl1).Dock = (DockStyle)5;
		((Control)Pnl1).Location = new Point(0, 0);
		((Control)Pnl1).Name = "Pnl1";
		((Control)Pnl1).Size = new Size(1309, 507);
		((Control)Pnl1).TabIndex = 0;
		((QControl)btnMainFontChange).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnMainFontChange).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnMainFontChange).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnMainFontChange).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnMainFontChange).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnMainFontChange).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnMainFontChange).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnMainFontChange).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnMainFontChange).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnMainFontChange).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnMainFontChange).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnMainFontChange).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnMainFontChange).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnMainFontChange).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnMainFontChange.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainFontChange.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainFontChange.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainFontChange.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMainFontChange.Image = null;
		((QControl)btnMainFontChange).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnMainFontChange).Location = new Point(1054, 372);
		((Control)btnMainFontChange).Margin = new Padding(3, 6, 3, 6);
		((Control)btnMainFontChange).Name = "btnMainFontChange";
		((Control)btnMainFontChange).Size = new Size(121, 32);
		((Control)btnMainFontChange).TabIndex = 1281;
		btnMainFontChange.Text = "Main F-Change";
		cboMainFontChange.AutoCompleteMode = (AutoCompleteMode)2;
		cboMainFontChange.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboMainFontChange).Font = new Font("Tahoma", 9f);
		((ListControl)cboMainFontChange).FormattingEnabled = true;
		((Control)cboMainFontChange).Location = new Point(950, 376);
		cboMainFontChange.MaxLength = 25;
		((Control)cboMainFontChange).Name = "cboMainFontChange";
		((Control)cboMainFontChange).Size = new Size(96, 22);
		((Control)cboMainFontChange).TabIndex = 1280;
		((Control)Label7).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(801, 373);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(142, 20);
		((Control)Label7).TabIndex = 1279;
		Label7.Text = "Main Font Change";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)pnlSet).Controls.Add((Control)(object)DGV);
		((Control)pnlSet).Location = new Point(1187, 4);
		((Control)pnlSet).Name = "pnlSet";
		((Control)pnlSet).Size = new Size(779, 501);
		((Control)pnlSet).TabIndex = 1275;
		((Control)pnlSet).Visible = false;
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
		((Control)DGV).Location = new Point(12, 11);
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
		((Control)DGV).Size = new Size(750, 478);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1246;
		((QControl)btnFineStkType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFineStkType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFineStkType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFineStkType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFineStkType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFineStkType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFineStkType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFineStkType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFineStkType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFineStkType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFineStkType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFineStkType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFineStkType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFineStkType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFineStkType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFineStkType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFineStkType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFineStkType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFineStkType.Image = null;
		((QControl)btnFineStkType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFineStkType).Location = new Point(1054, 289);
		((Control)btnFineStkType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFineStkType).Name = "btnFineStkType";
		((Control)btnFineStkType).Size = new Size(121, 32);
		((Control)btnFineStkType).TabIndex = 1278;
		btnFineStkType.Text = "Rpt Type Set";
		cboFineStkType.AutoCompleteMode = (AutoCompleteMode)2;
		cboFineStkType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboFineStkType).Font = new Font("Tahoma", 9f);
		((ListControl)cboFineStkType).FormattingEnabled = true;
		((Control)cboFineStkType).Location = new Point(950, 295);
		cboFineStkType.MaxLength = 25;
		((Control)cboFineStkType).Name = "cboFineStkType";
		((Control)cboFineStkType).Size = new Size(95, 22);
		((Control)cboFineStkType).TabIndex = 1277;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(785, 295);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(157, 20);
		((Control)Label8).TabIndex = 1276;
		Label8.Text = "Bal Sheet Rpt Type";
		Label8.TextAlign = (ContentAlignment)64;
		((QControl)btnWhSaleImg).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhSaleImg).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhSaleImg).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhSaleImg).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhSaleImg.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSaleImg.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSaleImg.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSaleImg.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSaleImg.Image = null;
		((QControl)btnWhSaleImg).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhSaleImg).Location = new Point(261, 207);
		((Control)btnWhSaleImg).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhSaleImg).Name = "btnWhSaleImg";
		((Control)btnWhSaleImg).Size = new Size(121, 32);
		((Control)btnWhSaleImg).TabIndex = 1274;
		btnWhSaleImg.Text = "Wh Img Print";
		cboWhSaleImg.AutoCompleteMode = (AutoCompleteMode)2;
		cboWhSaleImg.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboWhSaleImg).Font = new Font("Tahoma", 9f);
		((ListControl)cboWhSaleImg).FormattingEnabled = true;
		((Control)cboWhSaleImg).Location = new Point(160, 213);
		cboWhSaleImg.MaxLength = 25;
		((Control)cboWhSaleImg).Name = "cboWhSaleImg";
		((Control)cboWhSaleImg).Size = new Size(91, 22);
		((Control)cboWhSaleImg).TabIndex = 1273;
		((Control)Label49).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label49).ForeColor = Color.Black;
		Label49.ImeMode = (ImeMode)0;
		((Control)Label49).Location = new Point(5, 212);
		((Control)Label49).Name = "Label49";
		((Control)Label49).Size = new Size(151, 20);
		((Control)Label49).TabIndex = 1272;
		Label49.Text = "Wh Sale Img Print";
		Label49.TextAlign = (ContentAlignment)64;
		((QControl)btnAprlImg).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAprlImg).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAprlImg).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAprlImg).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAprlImg).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAprlImg).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAprlImg).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAprlImg).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAprlImg).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAprlImg).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAprlImg).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAprlImg).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAprlImg).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAprlImg).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAprlImg.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprlImg.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprlImg.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprlImg.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAprlImg.Image = null;
		((QControl)btnAprlImg).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAprlImg).Location = new Point(261, 131);
		((Control)btnAprlImg).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAprlImg).Name = "btnAprlImg";
		((Control)btnAprlImg).Size = new Size(121, 32);
		((Control)btnAprlImg).TabIndex = 1271;
		btnAprlImg.Text = "Aprl Img Print";
		cboAprlImg.AutoCompleteMode = (AutoCompleteMode)2;
		cboAprlImg.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboAprlImg).Font = new Font("Tahoma", 9f);
		((ListControl)cboAprlImg).FormattingEnabled = true;
		((Control)cboAprlImg).Location = new Point(160, 136);
		cboAprlImg.MaxLength = 25;
		((Control)cboAprlImg).Name = "cboAprlImg";
		((Control)cboAprlImg).Size = new Size(91, 22);
		((Control)cboAprlImg).TabIndex = 1270;
		((Control)Label46).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label46).ForeColor = Color.Black;
		Label46.ImeMode = (ImeMode)0;
		((Control)Label46).Location = new Point(5, 135);
		((Control)Label46).Name = "Label46";
		((Control)Label46).Size = new Size(151, 20);
		((Control)Label46).TabIndex = 1269;
		Label46.Text = "Aprl Itm Img Print";
		Label46.TextAlign = (ContentAlignment)64;
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDhrnImgPrint).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDhrnImgPrint).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDhrnImgPrint).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDhrnImgPrint.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDhrnImgPrint.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDhrnImgPrint.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDhrnImgPrint.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDhrnImgPrint.Image = null;
		((QControl)BtnDhrnImgPrint).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDhrnImgPrint).Location = new Point(261, 170);
		((Control)BtnDhrnImgPrint).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDhrnImgPrint).Name = "BtnDhrnImgPrint";
		((Control)BtnDhrnImgPrint).Size = new Size(121, 32);
		((Control)BtnDhrnImgPrint).TabIndex = 1268;
		BtnDhrnImgPrint.Text = "Dhrn Img Print";
		cboDhrnImgPrint.AutoCompleteMode = (AutoCompleteMode)2;
		cboDhrnImgPrint.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDhrnImgPrint).Font = new Font("Tahoma", 9f);
		((ListControl)cboDhrnImgPrint).FormattingEnabled = true;
		((Control)cboDhrnImgPrint).Location = new Point(160, 176);
		cboDhrnImgPrint.MaxLength = 25;
		((Control)cboDhrnImgPrint).Name = "cboDhrnImgPrint";
		((Control)cboDhrnImgPrint).Size = new Size(91, 22);
		((Control)cboDhrnImgPrint).TabIndex = 1267;
		((Control)Label44).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label44).ForeColor = Color.Black;
		Label44.ImeMode = (ImeMode)0;
		((Control)Label44).Location = new Point(5, 175);
		((Control)Label44).Name = "Label44";
		((Control)Label44).Size = new Size(151, 20);
		((Control)Label44).TabIndex = 1266;
		Label44.Text = "Dhrn Itm Img Print";
		Label44.TextAlign = (ContentAlignment)64;
		((QControl)brnImgWithWt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)brnImgWithWt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnImgWithWt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)brnImgWithWt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)brnImgWithWt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)brnImgWithWt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnImgWithWt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)brnImgWithWt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)brnImgWithWt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)brnImgWithWt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)brnImgWithWt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnImgWithWt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)brnImgWithWt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)brnImgWithWt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		brnImgWithWt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnImgWithWt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnImgWithWt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnImgWithWt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnImgWithWt.Image = null;
		((QControl)brnImgWithWt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)brnImgWithWt).Location = new Point(261, 246);
		((Control)brnImgWithWt).Margin = new Padding(3, 6, 3, 6);
		((Control)brnImgWithWt).Name = "brnImgWithWt";
		((Control)brnImgWithWt).Size = new Size(121, 32);
		((Control)brnImgWithWt).TabIndex = 1265;
		brnImgWithWt.Text = "Img Wt Set";
		cboImgWithWt.AutoCompleteMode = (AutoCompleteMode)2;
		cboImgWithWt.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboImgWithWt).Font = new Font("Tahoma", 9f);
		((ListControl)cboImgWithWt).FormattingEnabled = true;
		((Control)cboImgWithWt).Location = new Point(160, 253);
		cboImgWithWt.MaxLength = 25;
		((Control)cboImgWithWt).Name = "cboImgWithWt";
		((Control)cboImgWithWt).Size = new Size(91, 22);
		((Control)cboImgWithWt).TabIndex = 1264;
		((Control)Label43).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label43).ForeColor = Color.Black;
		Label43.ImeMode = (ImeMode)0;
		((Control)Label43).Location = new Point(5, 252);
		((Control)Label43).Name = "Label43";
		((Control)Label43).Size = new Size(151, 20);
		((Control)Label43).TabIndex = 1263;
		Label43.Text = "Whatsapp Img  With Wt";
		Label43.TextAlign = (ContentAlignment)64;
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdTagStkLess).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdTagStkLess).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdTagStkLess).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdTagStkLess.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdTagStkLess.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdTagStkLess.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdTagStkLess.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdTagStkLess.Image = null;
		((QControl)btnOrdTagStkLess).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdTagStkLess).Location = new Point(1054, 131);
		((Control)btnOrdTagStkLess).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdTagStkLess).Name = "btnOrdTagStkLess";
		((Control)btnOrdTagStkLess).Size = new Size(121, 32);
		((Control)btnOrdTagStkLess).TabIndex = 1262;
		btnOrdTagStkLess.Text = "Ord Tag Less";
		cboOrdTagStkLess.AutoCompleteMode = (AutoCompleteMode)2;
		cboOrdTagStkLess.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOrdTagStkLess).Font = new Font("Tahoma", 9f);
		((ListControl)cboOrdTagStkLess).FormattingEnabled = true;
		((Control)cboOrdTagStkLess).Location = new Point(950, 139);
		cboOrdTagStkLess.MaxLength = 25;
		((Control)cboOrdTagStkLess).Name = "cboOrdTagStkLess";
		((Control)cboOrdTagStkLess).Size = new Size(95, 22);
		((Control)cboOrdTagStkLess).TabIndex = 1261;
		((Control)Label40).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label40).ForeColor = Color.Black;
		Label40.ImeMode = (ImeMode)0;
		((Control)Label40).Location = new Point(810, 138);
		((Control)Label40).Name = "Label40";
		((Control)Label40).Size = new Size(132, 20);
		((Control)Label40).TabIndex = 1260;
		Label40.Text = "Ord Tag Stock Less";
		Label40.TextAlign = (ContentAlignment)64;
		((QControl)brnReminderType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)brnReminderType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnReminderType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)brnReminderType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)brnReminderType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)brnReminderType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnReminderType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)brnReminderType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)brnReminderType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)brnReminderType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)brnReminderType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnReminderType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)brnReminderType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)brnReminderType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		brnReminderType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnReminderType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnReminderType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnReminderType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnReminderType.Image = null;
		((QControl)brnReminderType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)brnReminderType).Location = new Point(1054, 93);
		((Control)brnReminderType).Margin = new Padding(3, 6, 3, 6);
		((Control)brnReminderType).Name = "brnReminderType";
		((Control)brnReminderType).Size = new Size(121, 32);
		((Control)brnReminderType).TabIndex = 1259;
		brnReminderType.Text = "Rem Type Set";
		cboReminderType.AutoCompleteMode = (AutoCompleteMode)2;
		cboReminderType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboReminderType).Font = new Font("Tahoma", 9f);
		((ListControl)cboReminderType).FormattingEnabled = true;
		((Control)cboReminderType).Location = new Point(950, 102);
		cboReminderType.MaxLength = 25;
		((Control)cboReminderType).Name = "cboReminderType";
		((Control)cboReminderType).Size = new Size(95, 22);
		((Control)cboReminderType).TabIndex = 1258;
		((Control)Label38).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label38).ForeColor = Color.Black;
		Label38.ImeMode = (ImeMode)0;
		((Control)Label38).Location = new Point(796, 103);
		((Control)Label38).Name = "Label38";
		((Control)Label38).Size = new Size(146, 20);
		((Control)Label38).TabIndex = 1257;
		Label38.Text = "Home Reminder Type";
		Label38.TextAlign = (ContentAlignment)64;
		((QControl)btnRptTotShow).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnRptTotShow).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRptTotShow).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnRptTotShow).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnRptTotShow).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnRptTotShow).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnRptTotShow).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnRptTotShow).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnRptTotShow).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnRptTotShow).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnRptTotShow).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnRptTotShow).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnRptTotShow).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnRptTotShow).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnRptTotShow.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRptTotShow.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRptTotShow.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRptTotShow.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnRptTotShow.Image = null;
		((QControl)btnRptTotShow).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnRptTotShow).Location = new Point(1054, 55);
		((Control)btnRptTotShow).Margin = new Padding(3, 6, 3, 6);
		((Control)btnRptTotShow).Name = "btnRptTotShow";
		((Control)btnRptTotShow).Size = new Size(121, 32);
		((Control)btnRptTotShow).TabIndex = 1256;
		btnRptTotShow.Text = "Footer Show ";
		cboRptTotShow.AutoCompleteMode = (AutoCompleteMode)2;
		cboRptTotShow.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboRptTotShow).Font = new Font("Tahoma", 9f);
		((ListControl)cboRptTotShow).FormattingEnabled = true;
		((Control)cboRptTotShow).Location = new Point(950, 63);
		cboRptTotShow.MaxLength = 25;
		((Control)cboRptTotShow).Name = "cboRptTotShow";
		((Control)cboRptTotShow).Size = new Size(95, 22);
		((Control)cboRptTotShow).TabIndex = 1255;
		((Control)Label37).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label37).ForeColor = Color.Black;
		Label37.ImeMode = (ImeMode)0;
		((Control)Label37).Location = new Point(818, 62);
		((Control)Label37).Name = "Label37";
		((Control)Label37).Size = new Size(124, 20);
		((Control)Label37).TabIndex = 1254;
		Label37.Text = "Report Totel Show";
		Label37.TextAlign = (ContentAlignment)64;
		((QControl)BtnSchmWapp).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSchmWapp).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSchmWapp).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSchmWapp).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSchmWapp.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSchmWapp.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSchmWapp.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSchmWapp.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSchmWapp.Image = null;
		((QControl)BtnSchmWapp).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSchmWapp).Location = new Point(656, 245);
		((Control)BtnSchmWapp).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSchmWapp).Name = "BtnSchmWapp";
		((Control)BtnSchmWapp).Size = new Size(121, 32);
		((Control)BtnSchmWapp).TabIndex = 1253;
		BtnSchmWapp.Text = "Schm Wapp ";
		cboSchmWapp.AutoCompleteMode = (AutoCompleteMode)2;
		cboSchmWapp.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSchmWapp).Font = new Font("Tahoma", 9f);
		((ListControl)cboSchmWapp).FormattingEnabled = true;
		((Control)cboSchmWapp).Location = new Point(555, 248);
		cboSchmWapp.MaxLength = 3;
		((Control)cboSchmWapp).Name = "cboSchmWapp";
		((Control)cboSchmWapp).Size = new Size(91, 22);
		((Control)cboSchmWapp).TabIndex = 1252;
		((Control)Label36).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label36).ForeColor = Color.Black;
		Label36.ImeMode = (ImeMode)0;
		((Control)Label36).Location = new Point(391, 248);
		((Control)Label36).Name = "Label36";
		((Control)Label36).Size = new Size(159, 20);
		((Control)Label36).TabIndex = 1251;
		Label36.Text = "Schem Whatsapp";
		Label36.TextAlign = (ContentAlignment)64;
		((QControl)btnDhrnWapp).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDhrnWapp).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDhrnWapp).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDhrnWapp).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDhrnWapp.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnWapp.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnWapp.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnWapp.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDhrnWapp.Image = null;
		((QControl)btnDhrnWapp).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDhrnWapp).Location = new Point(656, 206);
		((Control)btnDhrnWapp).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDhrnWapp).Name = "btnDhrnWapp";
		((Control)btnDhrnWapp).Size = new Size(121, 32);
		((Control)btnDhrnWapp).TabIndex = 1250;
		btnDhrnWapp.Text = "Dhrn Wapp";
		cboDhrnWapp.AutoCompleteMode = (AutoCompleteMode)2;
		cboDhrnWapp.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDhrnWapp).Font = new Font("Tahoma", 9f);
		((ListControl)cboDhrnWapp).FormattingEnabled = true;
		((Control)cboDhrnWapp).Location = new Point(555, 209);
		cboDhrnWapp.MaxLength = 3;
		((Control)cboDhrnWapp).Name = "cboDhrnWapp";
		((Control)cboDhrnWapp).Size = new Size(91, 22);
		((Control)cboDhrnWapp).TabIndex = 1249;
		((Control)Label35).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label35).ForeColor = Color.Black;
		Label35.ImeMode = (ImeMode)0;
		((Control)Label35).Location = new Point(391, 209);
		((Control)Label35).Name = "Label35";
		((Control)Label35).Size = new Size(159, 20);
		((Control)Label35).TabIndex = 1248;
		Label35.Text = "Dhrn Whatsapp";
		Label35.TextAlign = (ContentAlignment)64;
		((QControl)btnEstmatTax).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnEstmatTax).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEstmatTax).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnEstmatTax).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnEstmatTax).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnEstmatTax).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEstmatTax).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnEstmatTax).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnEstmatTax).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnEstmatTax).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnEstmatTax).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnEstmatTax).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnEstmatTax).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnEstmatTax).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnEstmatTax.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmatTax.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmatTax.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmatTax.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmatTax.Image = null;
		((QControl)btnEstmatTax).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnEstmatTax).Location = new Point(261, 361);
		((Control)btnEstmatTax).Margin = new Padding(3, 6, 3, 6);
		((Control)btnEstmatTax).Name = "btnEstmatTax";
		((Control)btnEstmatTax).Size = new Size(121, 32);
		((Control)btnEstmatTax).TabIndex = 1247;
		btnEstmatTax.Text = "Estmt Tax Set";
		cboEstmateWithTax.AutoCompleteMode = (AutoCompleteMode)2;
		cboEstmateWithTax.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboEstmateWithTax).Font = new Font("Tahoma", 9f);
		((ListControl)cboEstmateWithTax).FormattingEnabled = true;
		((Control)cboEstmateWithTax).Location = new Point(161, 366);
		cboEstmateWithTax.MaxLength = 25;
		((Control)cboEstmateWithTax).Name = "cboEstmateWithTax";
		((Control)cboEstmateWithTax).Size = new Size(91, 22);
		((Control)cboEstmateWithTax).TabIndex = 1246;
		((Control)Label32).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label32).ForeColor = Color.Black;
		Label32.ImeMode = (ImeMode)0;
		((Control)Label32).Location = new Point(19, 368);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(135, 20);
		((Control)Label32).TabIndex = 1245;
		Label32.Text = "Estmate With Tax";
		Label32.TextAlign = (ContentAlignment)64;
		((QControl)btnDcMemb).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDcMemb).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDcMemb).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDcMemb).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDcMemb).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDcMemb).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDcMemb).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDcMemb).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDcMemb).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDcMemb).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDcMemb).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDcMemb).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDcMemb).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDcMemb).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDcMemb.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDcMemb.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDcMemb.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDcMemb.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDcMemb.Image = null;
		((QControl)btnDcMemb).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDcMemb).Location = new Point(1054, 416);
		((Control)btnDcMemb).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDcMemb).Name = "btnDcMemb";
		((Control)btnDcMemb).Size = new Size(121, 32);
		((Control)btnDcMemb).TabIndex = 1244;
		btnDcMemb.Text = "DataCare Pwd";
		((Control)Label27).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label27).ForeColor = Color.Black;
		Label27.ImeMode = (ImeMode)0;
		((Control)Label27).Location = new Point(808, 423);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(134, 20);
		((Control)Label27).TabIndex = 1243;
		Label27.Text = "Dc Memb Pwd";
		Label27.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tDcPwd).BackColor = Color.White;
		((Control)tDcPwd).Font = new Font("Tahoma", 9f);
		((Control)tDcPwd).Location = new Point(950, 421);
		((TextBoxBase)tDcPwd).MaxLength = 10;
		((Control)tDcPwd).Name = "tDcPwd";
		tDcPwd.PasswordChar = '*';
		((Control)tDcPwd).Size = new Size(94, 22);
		((Control)tDcPwd).TabIndex = 1242;
		((QControl)BtnCashLimit).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnCashLimit).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnCashLimit).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnCashLimit).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnCashLimit).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnCashLimit).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnCashLimit).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnCashLimit).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnCashLimit).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnCashLimit).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnCashLimit).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnCashLimit).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnCashLimit).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnCashLimit).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnCashLimit.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCashLimit.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCashLimit.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCashLimit.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnCashLimit.Image = null;
		((QControl)BtnCashLimit).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnCashLimit).Location = new Point(1054, 16);
		((Control)BtnCashLimit).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnCashLimit).Name = "BtnCashLimit";
		((Control)BtnCashLimit).Size = new Size(121, 32);
		((Control)BtnCashLimit).TabIndex = 1241;
		BtnCashLimit.Text = "Cash Limit Set";
		cboCashLimit.AutoCompleteMode = (AutoCompleteMode)2;
		cboCashLimit.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCashLimit).Font = new Font("Tahoma", 9f);
		((ListControl)cboCashLimit).FormattingEnabled = true;
		((Control)cboCashLimit).Location = new Point(950, 21);
		cboCashLimit.MaxLength = 25;
		((Control)cboCashLimit).Name = "cboCashLimit";
		((Control)cboCashLimit).Size = new Size(95, 22);
		((Control)cboCashLimit).TabIndex = 1240;
		((Control)Label26).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label26).ForeColor = Color.Black;
		Label26.ImeMode = (ImeMode)0;
		((Control)Label26).Location = new Point(805, 21);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(137, 20);
		((Control)Label26).TabIndex = 1239;
		Label26.Text = "Party Cash Limit Set";
		Label26.TextAlign = (ContentAlignment)64;
		((QControl)btnPreviousLock).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPreviousLock).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPreviousLock).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPreviousLock).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPreviousLock).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPreviousLock).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPreviousLock).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPreviousLock).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPreviousLock).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPreviousLock).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPreviousLock).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPreviousLock).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPreviousLock).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPreviousLock).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPreviousLock.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPreviousLock.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPreviousLock.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPreviousLock.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPreviousLock.Image = null;
		((QControl)btnPreviousLock).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPreviousLock).Location = new Point(261, 399);
		((Control)btnPreviousLock).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPreviousLock).Name = "btnPreviousLock";
		((Control)btnPreviousLock).Size = new Size(121, 32);
		((Control)btnPreviousLock).TabIndex = 1238;
		btnPreviousLock.Text = "Lock Date Set";
		cboPreviousLock.AutoCompleteMode = (AutoCompleteMode)2;
		cboPreviousLock.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPreviousLock).Font = new Font("Tahoma", 9f);
		((ListControl)cboPreviousLock).FormattingEnabled = true;
		((Control)cboPreviousLock).Location = new Point(161, 402);
		cboPreviousLock.MaxLength = 25;
		((Control)cboPreviousLock).Name = "cboPreviousLock";
		((Control)cboPreviousLock).Size = new Size(91, 22);
		((Control)cboPreviousLock).TabIndex = 1237;
		((Control)Label25).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label25).ForeColor = Color.Black;
		Label25.ImeMode = (ImeMode)0;
		((Control)Label25).Location = new Point(12, 402);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(143, 20);
		((Control)Label25).TabIndex = 1236;
		Label25.Text = "Pre Day Entry Lock";
		Label25.TextAlign = (ContentAlignment)64;
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGridRowHeightSet).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnGridRowHeightSet).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnGridRowHeightSet).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnGridRowHeightSet.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGridRowHeightSet.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGridRowHeightSet.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGridRowHeightSet.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGridRowHeightSet.Image = null;
		((QControl)btnGridRowHeightSet).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnGridRowHeightSet).Location = new Point(656, 436);
		((Control)btnGridRowHeightSet).Margin = new Padding(3, 6, 3, 6);
		((Control)btnGridRowHeightSet).Name = "btnGridRowHeightSet";
		((Control)btnGridRowHeightSet).Size = new Size(121, 32);
		((Control)btnGridRowHeightSet).TabIndex = 1235;
		btnGridRowHeightSet.Text = "Gird Row Set";
		cboGridRowHeight.AutoCompleteMode = (AutoCompleteMode)2;
		cboGridRowHeight.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboGridRowHeight).Font = new Font("Tahoma", 9f);
		((ListControl)cboGridRowHeight).FormattingEnabled = true;
		((Control)cboGridRowHeight).Location = new Point(555, 441);
		cboGridRowHeight.MaxLength = 25;
		((Control)cboGridRowHeight).Name = "cboGridRowHeight";
		((Control)cboGridRowHeight).Size = new Size(91, 22);
		((Control)cboGridRowHeight).TabIndex = 1234;
		((Control)Label24).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label24).ForeColor = Color.Black;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(453, 441);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(97, 20);
		((Control)Label24).TabIndex = 1233;
		Label24.Text = "Grid Row Height";
		Label24.TextAlign = (ContentAlignment)64;
		((QControl)btnFontStyle).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFontStyle).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontStyle).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFontStyle).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFontStyle).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFontStyle).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontStyle).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFontStyle).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFontStyle).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFontStyle).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFontStyle).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFontStyle).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFontStyle).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFontStyle).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFontStyle.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontStyle.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontStyle.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontStyle.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontStyle.Image = null;
		((QControl)btnFontStyle).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFontStyle).Location = new Point(656, 398);
		((Control)btnFontStyle).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFontStyle).Name = "btnFontStyle";
		((Control)btnFontStyle).Size = new Size(121, 32);
		((Control)btnFontStyle).TabIndex = 1232;
		btnFontStyle.Text = "Font Style";
		cboFontStyle.AutoCompleteMode = (AutoCompleteMode)2;
		cboFontStyle.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboFontStyle).Font = new Font("Tahoma", 9f);
		((ListControl)cboFontStyle).FormattingEnabled = true;
		((Control)cboFontStyle).Location = new Point(555, 403);
		cboFontStyle.MaxLength = 25;
		((Control)cboFontStyle).Name = "cboFontStyle";
		((Control)cboFontStyle).Size = new Size(91, 22);
		((Control)cboFontStyle).TabIndex = 1231;
		((Control)Label23).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Black;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(453, 403);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(97, 20);
		((Control)Label23).TabIndex = 1230;
		Label23.Text = "Font Style";
		Label23.TextAlign = (ContentAlignment)64;
		((QControl)btnFontName).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFontName).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontName).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFontName).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFontName).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFontName).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontName).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFontName).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFontName).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFontName).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFontName).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFontName).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFontName).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFontName).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFontName.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontName.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontName.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontName.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontName.Image = null;
		((QControl)btnFontName).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFontName).Location = new Point(656, 360);
		((Control)btnFontName).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFontName).Name = "btnFontName";
		((Control)btnFontName).Size = new Size(121, 32);
		((Control)btnFontName).TabIndex = 1229;
		btnFontName.Text = "Font Name";
		CboFontName.AutoCompleteMode = (AutoCompleteMode)2;
		CboFontName.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)CboFontName).Font = new Font("Tahoma", 9f);
		((ListControl)CboFontName).FormattingEnabled = true;
		((Control)CboFontName).Location = new Point(555, 365);
		CboFontName.MaxLength = 25;
		((Control)CboFontName).Name = "CboFontName";
		((Control)CboFontName).Size = new Size(91, 22);
		((Control)CboFontName).TabIndex = 1228;
		((Control)Label22).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(453, 365);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(97, 20);
		((Control)Label22).TabIndex = 1227;
		Label22.Text = "Font Name";
		Label22.TextAlign = (ContentAlignment)64;
		((QControl)btnFontSize).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFontSize).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontSize).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFontSize).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFontSize).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFontSize).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontSize).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFontSize).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFontSize).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFontSize).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFontSize).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFontSize).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFontSize).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFontSize).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFontSize.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontSize.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontSize.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontSize.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontSize.Image = null;
		((QControl)btnFontSize).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFontSize).Location = new Point(656, 321);
		((Control)btnFontSize).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFontSize).Name = "btnFontSize";
		((Control)btnFontSize).Size = new Size(121, 32);
		((Control)btnFontSize).TabIndex = 1226;
		btnFontSize.Text = "Font Size";
		cboFontSize.AutoCompleteMode = (AutoCompleteMode)2;
		cboFontSize.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboFontSize).Font = new Font("Tahoma", 9f);
		((ListControl)cboFontSize).FormattingEnabled = true;
		((Control)cboFontSize).Location = new Point(555, 325);
		cboFontSize.MaxLength = 25;
		((Control)cboFontSize).Name = "cboFontSize";
		((Control)cboFontSize).Size = new Size(91, 22);
		((Control)cboFontSize).TabIndex = 1225;
		((Control)Label21).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.Black;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(453, 325);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(97, 20);
		((Control)Label21).TabIndex = 1224;
		Label21.Text = "Font Size";
		Label21.TextAlign = (ContentAlignment)64;
		((QControl)btnFontChang).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFontChang).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontChang).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFontChang).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFontChang).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFontChang).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFontChang).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFontChang).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFontChang).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFontChang).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFontChang).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFontChang).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFontChang).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFontChang).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFontChang.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontChang.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontChang.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontChang.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFontChang.Image = null;
		((QControl)btnFontChang).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFontChang).Location = new Point(656, 283);
		((Control)btnFontChang).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFontChang).Name = "btnFontChang";
		((Control)btnFontChang).Size = new Size(121, 32);
		((Control)btnFontChang).TabIndex = 1223;
		btnFontChang.Text = "Font Change";
		cboFontChange.AutoCompleteMode = (AutoCompleteMode)2;
		cboFontChange.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboFontChange).Font = new Font("Tahoma", 9f);
		((ListControl)cboFontChange).FormattingEnabled = true;
		((Control)cboFontChange).Location = new Point(555, 287);
		cboFontChange.MaxLength = 25;
		((Control)cboFontChange).Name = "cboFontChange";
		((Control)cboFontChange).Size = new Size(91, 22);
		((Control)cboFontChange).TabIndex = 1222;
		((Control)Label20).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Black;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(408, 289);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(142, 20);
		((Control)Label20).TabIndex = 1221;
		Label20.Text = "Report Font Change";
		Label20.TextAlign = (ContentAlignment)64;
		((QControl)btnEmpMandotry).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnEmpMandotry).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnEmpMandotry).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnEmpMandotry).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnEmpMandotry.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpMandotry.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpMandotry.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpMandotry.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpMandotry.Image = null;
		((QControl)btnEmpMandotry).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnEmpMandotry).Location = new Point(261, 323);
		((Control)btnEmpMandotry).Margin = new Padding(3, 6, 3, 6);
		((Control)btnEmpMandotry).Name = "btnEmpMandotry";
		((Control)btnEmpMandotry).Size = new Size(121, 32);
		((Control)btnEmpMandotry).TabIndex = 1208;
		btnEmpMandotry.Text = "Sale Emp Set";
		cboEmpMandatory.AutoCompleteMode = (AutoCompleteMode)2;
		cboEmpMandatory.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboEmpMandatory).Font = new Font("Tahoma", 9f);
		((ListControl)cboEmpMandatory).FormattingEnabled = true;
		((Control)cboEmpMandatory).Location = new Point(160, 331);
		cboEmpMandatory.MaxLength = 25;
		((Control)cboEmpMandatory).Name = "cboEmpMandatory";
		((Control)cboEmpMandatory).Size = new Size(91, 22);
		((Control)cboEmpMandatory).TabIndex = 1207;
		((Control)Label19).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(13, 333);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(143, 20);
		((Control)Label19).TabIndex = 1206;
		Label19.Text = "Emp Mandatory in SL";
		Label19.TextAlign = (ContentAlignment)64;
		((QControl)btnPrintFormSet).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPrintFormSet).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPrintFormSet).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPrintFormSet).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPrintFormSet.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintFormSet.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintFormSet.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintFormSet.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrintFormSet.Image = null;
		((QControl)btnPrintFormSet).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPrintFormSet).Location = new Point(261, 437);
		((Control)btnPrintFormSet).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPrintFormSet).Name = "btnPrintFormSet";
		((Control)btnPrintFormSet).Size = new Size(121, 32);
		((Control)btnPrintFormSet).TabIndex = 1205;
		btnPrintFormSet.Text = "Print Btn Set";
		cboPrintFormSet.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintFormSet.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPrintFormSet).Font = new Font("Tahoma", 9f);
		((ListControl)cboPrintFormSet).FormattingEnabled = true;
		((Control)cboPrintFormSet).Location = new Point(160, 442);
		cboPrintFormSet.MaxLength = 25;
		((Control)cboPrintFormSet).Name = "cboPrintFormSet";
		((Control)cboPrintFormSet).Size = new Size(91, 22);
		((Control)cboPrintFormSet).TabIndex = 1204;
		((Control)Label18).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(6, 442);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(148, 20);
		((Control)Label18).TabIndex = 1203;
		Label18.Text = "Print Form Default Btn Set";
		Label18.TextAlign = (ContentAlignment)64;
		((QControl)btnOrdImage).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrdImage).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdImage).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrdImage).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrdImage).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrdImage).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrdImage).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOrdImage).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrdImage).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrdImage).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrdImage).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrdImage).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrdImage).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrdImage).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrdImage.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdImage.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdImage.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdImage.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrdImage.Image = null;
		((QControl)btnOrdImage).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrdImage).Location = new Point(261, 92);
		((Control)btnOrdImage).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrdImage).Name = "btnOrdImage";
		((Control)btnOrdImage).Size = new Size(121, 32);
		((Control)btnOrdImage).TabIndex = 1202;
		btnOrdImage.Text = "Ord Img Print";
		cboOrdImage.AutoCompleteMode = (AutoCompleteMode)2;
		cboOrdImage.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOrdImage).Font = new Font("Tahoma", 9f);
		((ListControl)cboOrdImage).FormattingEnabled = true;
		((Control)cboOrdImage).Location = new Point(160, 98);
		cboOrdImage.MaxLength = 25;
		((Control)cboOrdImage).Name = "cboOrdImage";
		((Control)cboOrdImage).Size = new Size(91, 22);
		((Control)cboOrdImage).TabIndex = 1201;
		((Control)Label12).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(6, 98);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(148, 20);
		((Control)Label12).TabIndex = 1200;
		Label12.Text = "Sales Order Image Print";
		Label12.TextAlign = (ContentAlignment)64;
		((QControl)btnDesignGen).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDesignGen).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDesignGen).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDesignGen).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDesignGen).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDesignGen).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDesignGen).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDesignGen).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDesignGen).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDesignGen).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDesignGen).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDesignGen).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDesignGen).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDesignGen).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDesignGen.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignGen.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignGen.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignGen.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDesignGen.Image = null;
		((QControl)btnDesignGen).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDesignGen).Location = new Point(261, 285);
		((Control)btnDesignGen).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDesignGen).Name = "btnDesignGen";
		((Control)btnDesignGen).Size = new Size(121, 32);
		((Control)btnDesignGen).TabIndex = 1199;
		btnDesignGen.Text = "Design Gen Set";
		cboDesignGen.AutoCompleteMode = (AutoCompleteMode)2;
		cboDesignGen.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboDesignGen).Font = new Font("Tahoma", 9f);
		((ListControl)cboDesignGen).FormattingEnabled = true;
		((Control)cboDesignGen).Location = new Point(160, 292);
		cboDesignGen.MaxLength = 25;
		((Control)cboDesignGen).Name = "cboDesignGen";
		((Control)cboDesignGen).Size = new Size(91, 22);
		((Control)cboDesignGen).TabIndex = 1198;
		((Control)Label11).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(10, 292);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(146, 20);
		((Control)Label11).TabIndex = 1197;
		Label11.Text = "Tag Entry Design Gen";
		Label11.TextAlign = (ContentAlignment)64;
		((QControl)btnWappSlprint).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWappSlprint).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWappSlprint).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWappSlprint).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWappSlprint).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWappSlprint).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWappSlprint).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWappSlprint).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWappSlprint).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWappSlprint).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWappSlprint).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWappSlprint).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWappSlprint).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWappSlprint).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWappSlprint.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappSlprint.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappSlprint.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappSlprint.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappSlprint.Image = null;
		((QControl)btnWappSlprint).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWappSlprint).Location = new Point(656, 167);
		((Control)btnWappSlprint).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWappSlprint).Name = "btnWappSlprint";
		((Control)btnWappSlprint).Size = new Size(121, 32);
		((Control)btnWappSlprint).TabIndex = 1193;
		btnWappSlprint.Text = "Wapp Print Set";
		cboWappSlPrint.AutoCompleteMode = (AutoCompleteMode)2;
		cboWappSlPrint.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboWappSlPrint).Font = new Font("Tahoma", 9f);
		((ListControl)cboWappSlPrint).FormattingEnabled = true;
		((Control)cboWappSlPrint).Location = new Point(555, 170);
		cboWappSlPrint.MaxLength = 3;
		((Control)cboWappSlPrint).Name = "cboWappSlPrint";
		((Control)cboWappSlPrint).Size = new Size(91, 22);
		((Control)cboWappSlPrint).TabIndex = 1192;
		((Control)Label10).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(391, 170);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(159, 20);
		((Control)Label10).TabIndex = 1191;
		Label10.Text = "Wapp Sl Default Print";
		Label10.TextAlign = (ContentAlignment)64;
		((QControl)btnCountryId).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCountryId).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCountryId).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCountryId).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCountryId).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCountryId).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCountryId).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCountryId).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCountryId).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCountryId).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCountryId).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCountryId).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCountryId).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCountryId).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCountryId.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCountryId.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCountryId.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCountryId.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCountryId.Image = null;
		((QControl)btnCountryId).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCountryId).Location = new Point(656, 129);
		((Control)btnCountryId).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCountryId).Name = "btnCountryId";
		((Control)btnCountryId).Size = new Size(121, 32);
		((Control)btnCountryId).TabIndex = 1190;
		btnCountryId.Text = "Country Id Set";
		cboCountryid.AutoCompleteMode = (AutoCompleteMode)2;
		cboCountryid.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCountryid).Font = new Font("Tahoma", 9f);
		((ListControl)cboCountryid).FormattingEnabled = true;
		((Control)cboCountryid).Location = new Point(555, 131);
		cboCountryid.MaxLength = 3;
		((Control)cboCountryid).Name = "cboCountryid";
		((Control)cboCountryid).Size = new Size(91, 22);
		((Control)cboCountryid).TabIndex = 1189;
		((Control)Label9).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(388, 130);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(162, 20);
		((Control)Label9).TabIndex = 1188;
		Label9.Text = "Whatsapp Country Code";
		Label9.TextAlign = (ContentAlignment)64;
		((QControl)btnCustSms).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCustSms).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustSms).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCustSms).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCustSms).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCustSms).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustSms).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCustSms).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCustSms).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCustSms).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCustSms).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCustSms).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCustSms).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCustSms).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCustSms.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustSms.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustSms.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustSms.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustSms.Image = null;
		((QControl)btnCustSms).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCustSms).Location = new Point(656, 91);
		((Control)btnCustSms).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCustSms).Name = "btnCustSms";
		((Control)btnCustSms).Size = new Size(121, 32);
		((Control)btnCustSms).TabIndex = 1187;
		btnCustSms.Text = "Cust Sms Set";
		cboCustSms.AutoCompleteMode = (AutoCompleteMode)2;
		cboCustSms.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCustSms).Font = new Font("Tahoma", 9f);
		((ListControl)cboCustSms).FormattingEnabled = true;
		((Control)cboCustSms).Location = new Point(555, 94);
		cboCustSms.MaxLength = 25;
		((Control)cboCustSms).Name = "cboCustSms";
		((Control)cboCustSms).Size = new Size(91, 22);
		((Control)cboCustSms).TabIndex = 1186;
		((Control)Label17).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(394, 93);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(155, 20);
		((Control)Label17).TabIndex = 1185;
		Label17.Text = "Customer Whatsapp";
		Label17.TextAlign = (ContentAlignment)64;
		((QControl)btnAdminSms).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAdminSms).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAdminSms).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAdminSms).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAdminSms).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAdminSms).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAdminSms).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAdminSms).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAdminSms).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAdminSms).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAdminSms).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAdminSms).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAdminSms).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAdminSms).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAdminSms.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAdminSms.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAdminSms.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAdminSms.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAdminSms.Image = null;
		((QControl)btnAdminSms).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAdminSms).Location = new Point(656, 53);
		((Control)btnAdminSms).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAdminSms).Name = "btnAdminSms";
		((Control)btnAdminSms).Size = new Size(121, 32);
		((Control)btnAdminSms).TabIndex = 1184;
		btnAdminSms.Text = "Admin Sms Set";
		cboAdminSms.AutoCompleteMode = (AutoCompleteMode)2;
		cboAdminSms.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboAdminSms).Font = new Font("Tahoma", 9f);
		((ListControl)cboAdminSms).FormattingEnabled = true;
		((Control)cboAdminSms).Location = new Point(555, 57);
		cboAdminSms.MaxLength = 25;
		((Control)cboAdminSms).Name = "cboAdminSms";
		((Control)cboAdminSms).Size = new Size(91, 22);
		((Control)cboAdminSms).TabIndex = 1183;
		((Control)Label16).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(391, 57);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(159, 20);
		((Control)Label16).TabIndex = 1182;
		Label16.Text = "Admin Whsatsapp";
		Label16.TextAlign = (ContentAlignment)64;
		((QControl)btnPrRateRof).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPrRateRof).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrRateRof).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPrRateRof).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPrRateRof).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPrRateRof).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPrRateRof).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPrRateRof).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPrRateRof).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPrRateRof).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPrRateRof).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPrRateRof).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPrRateRof).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPrRateRof).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPrRateRof.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrRateRof.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrRateRof.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrRateRof.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPrRateRof.Image = null;
		((QControl)btnPrRateRof).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPrRateRof).Location = new Point(1054, 169);
		((Control)btnPrRateRof).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPrRateRof).Name = "btnPrRateRof";
		((Control)btnPrRateRof).Size = new Size(121, 32);
		((Control)btnPrRateRof).TabIndex = 1172;
		btnPrRateRof.Text = "Rate Rof Set";
		cboPrRateRof.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrRateRof.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPrRateRof).Font = new Font("Tahoma", 9f);
		((ListControl)cboPrRateRof).FormattingEnabled = true;
		((Control)cboPrRateRof).Location = new Point(950, 174);
		cboPrRateRof.MaxLength = 25;
		((Control)cboPrRateRof).Name = "cboPrRateRof";
		((Control)cboPrRateRof).Size = new Size(95, 22);
		((Control)cboPrRateRof).TabIndex = 1171;
		((Control)Label15).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(819, 172);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(123, 20);
		((Control)Label15).TabIndex = 1170;
		Label15.Text = "Purc Rate Rof";
		Label15.TextAlign = (ContentAlignment)64;
		((QControl)btnBalSheetType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBalSheetType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBalSheetType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBalSheetType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBalSheetType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBalSheetType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBalSheetType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnBalSheetType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBalSheetType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBalSheetType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBalSheetType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBalSheetType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBalSheetType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBalSheetType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBalSheetType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBalSheetType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBalSheetType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBalSheetType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBalSheetType.Image = null;
		((QControl)btnBalSheetType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBalSheetType).Location = new Point(1054, 248);
		((Control)btnBalSheetType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBalSheetType).Name = "btnBalSheetType";
		((Control)btnBalSheetType).Size = new Size(121, 32);
		((Control)btnBalSheetType).TabIndex = 1157;
		btnBalSheetType.Text = "Bal Sheet Set";
		cboBalSheetType.AutoCompleteMode = (AutoCompleteMode)2;
		cboBalSheetType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboBalSheetType).Font = new Font("Tahoma", 9f);
		((ListControl)cboBalSheetType).FormattingEnabled = true;
		((Control)cboBalSheetType).Location = new Point(950, 253);
		cboBalSheetType.MaxLength = 25;
		((Control)cboBalSheetType).Name = "cboBalSheetType";
		((Control)cboBalSheetType).Size = new Size(95, 22);
		((Control)cboBalSheetType).TabIndex = 1156;
		((Control)Label4).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(797, 252);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(145, 20);
		((Control)Label4).TabIndex = 1155;
		Label4.Text = "Balance Sheet Type";
		Label4.TextAlign = (ContentAlignment)64;
		((QControl)btnTotFineStkType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTotFineStkType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnTotFineStkType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnTotFineStkType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnTotFineStkType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTotFineStkType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTotFineStkType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTotFineStkType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTotFineStkType.Image = null;
		((QControl)btnTotFineStkType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnTotFineStkType).Location = new Point(1054, 331);
		((Control)btnTotFineStkType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnTotFineStkType).Name = "btnTotFineStkType";
		((Control)btnTotFineStkType).Size = new Size(121, 32);
		((Control)btnTotFineStkType).TabIndex = 1154;
		btnTotFineStkType.Text = "Stk Type Set";
		cboTotFineStkType.AutoCompleteMode = (AutoCompleteMode)2;
		cboTotFineStkType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTotFineStkType).Font = new Font("Tahoma", 9f);
		((ListControl)cboTotFineStkType).FormattingEnabled = true;
		((Control)cboTotFineStkType).Location = new Point(950, 336);
		cboTotFineStkType.MaxLength = 25;
		((Control)cboTotFineStkType).Name = "cboTotFineStkType";
		((Control)cboTotFineStkType).Size = new Size(95, 22);
		((Control)cboTotFineStkType).TabIndex = 1153;
		((Control)lblTotFineStk).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblTotFineStk).ForeColor = Color.Black;
		lblTotFineStk.ImeMode = (ImeMode)0;
		((Control)lblTotFineStk).Location = new Point(786, 336);
		((Control)lblTotFineStk).Name = "lblTotFineStk";
		((Control)lblTotFineStk).Size = new Size(156, 20);
		((Control)lblTotFineStk).TabIndex = 1152;
		lblTotFineStk.Text = "Total Fine Report Stock Type";
		lblTotFineStk.TextAlign = (ContentAlignment)64;
		((QControl)btnSlImgPrint).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlImgPrint).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlImgPrint).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlImgPrint).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlImgPrint.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlImgPrint.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlImgPrint.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlImgPrint.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlImgPrint.Image = null;
		((QControl)btnSlImgPrint).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlImgPrint).Location = new Point(261, 53);
		((Control)btnSlImgPrint).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlImgPrint).Name = "btnSlImgPrint";
		((Control)btnSlImgPrint).Size = new Size(121, 32);
		((Control)btnSlImgPrint).TabIndex = 1151;
		btnSlImgPrint.Text = "Img Print Set";
		cboSalesImagPrint.AutoCompleteMode = (AutoCompleteMode)2;
		cboSalesImagPrint.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSalesImagPrint).Font = new Font("Tahoma", 9f);
		((ListControl)cboSalesImagPrint).FormattingEnabled = true;
		((Control)cboSalesImagPrint).Location = new Point(160, 59);
		cboSalesImagPrint.MaxLength = 25;
		((Control)cboSalesImagPrint).Name = "cboSalesImagPrint";
		((Control)cboSalesImagPrint).Size = new Size(91, 22);
		((Control)cboSalesImagPrint).TabIndex = 1150;
		((Control)Label3).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(6, 59);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(148, 20);
		((Control)Label3).TabIndex = 1149;
		Label3.Text = "Sales Bill Image Print";
		Label3.TextAlign = (ContentAlignment)64;
		((QControl)btnLoanIntDay).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLoanIntDay).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLoanIntDay).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLoanIntDay).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLoanIntDay.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanIntDay.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanIntDay.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanIntDay.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLoanIntDay.Image = null;
		((QControl)btnLoanIntDay).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLoanIntDay).Location = new Point(1054, 207);
		((Control)btnLoanIntDay).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLoanIntDay).Name = "btnLoanIntDay";
		((Control)btnLoanIntDay).Size = new Size(121, 32);
		((Control)btnLoanIntDay).TabIndex = 1148;
		btnLoanIntDay.Text = "Loan Int Set";
		cboLoanIntType.AutoCompleteMode = (AutoCompleteMode)2;
		cboLoanIntType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboLoanIntType).Font = new Font("Tahoma", 9f);
		((ListControl)cboLoanIntType).FormattingEnabled = true;
		((Control)cboLoanIntType).Location = new Point(950, 212);
		cboLoanIntType.MaxLength = 25;
		((Control)cboLoanIntType).Name = "cboLoanIntType";
		((Control)cboLoanIntType).Size = new Size(95, 22);
		((Control)cboLoanIntType).TabIndex = 1147;
		((Control)Label6).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(791, 212);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(151, 20);
		((Control)Label6).TabIndex = 1146;
		Label6.Text = "Loan Int  Day / Month";
		Label6.TextAlign = (ContentAlignment)64;
		((QControl)btnCustOsSms).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCustOsSms).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustOsSms).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCustOsSms).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCustOsSms).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCustOsSms).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCustOsSms).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCustOsSms).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCustOsSms).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCustOsSms).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCustOsSms).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCustOsSms).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCustOsSms).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCustOsSms).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCustOsSms.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustOsSms.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustOsSms.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustOsSms.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCustOsSms.Image = null;
		((QControl)btnCustOsSms).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCustOsSms).Location = new Point(656, 16);
		((Control)btnCustOsSms).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCustOsSms).Name = "btnCustOsSms";
		((Control)btnCustOsSms).Size = new Size(121, 32);
		((Control)btnCustOsSms).TabIndex = 1136;
		btnCustOsSms.Text = "Bill Os Sms Set";
		cboCustOsSms.AutoCompleteMode = (AutoCompleteMode)2;
		cboCustOsSms.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCustOsSms).Font = new Font("Tahoma", 9f);
		((ListControl)cboCustOsSms).FormattingEnabled = true;
		((Control)cboCustOsSms).Location = new Point(555, 20);
		cboCustOsSms.MaxLength = 25;
		((Control)cboCustOsSms).Name = "cboCustOsSms";
		((Control)cboCustOsSms).Size = new Size(91, 22);
		((Control)cboCustOsSms).TabIndex = 1135;
		((Control)Label2).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(388, 20);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(165, 20);
		((Control)Label2).TabIndex = 1134;
		Label2.Text = "Cust Bill Wapp With Os";
		Label2.TextAlign = (ContentAlignment)64;
		((QControl)btnQrcode).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnQrcode).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnQrcode).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnQrcode).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnQrcode).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnQrcode).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnQrcode).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnQrcode).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnQrcode).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnQrcode).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnQrcode).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnQrcode).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnQrcode).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnQrcode).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnQrcode.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQrcode.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQrcode.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQrcode.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQrcode.Image = null;
		((QControl)btnQrcode).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnQrcode).Location = new Point(261, 15);
		((Control)btnQrcode).Margin = new Padding(3, 6, 3, 6);
		((Control)btnQrcode).Name = "btnQrcode";
		((Control)btnQrcode).Size = new Size(121, 32);
		((Control)btnQrcode).TabIndex = 1133;
		btnQrcode.Text = "Tag Qr Set";
		cboQrCode.AutoCompleteMode = (AutoCompleteMode)2;
		cboQrCode.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboQrCode).Font = new Font("Tahoma", 9f);
		((ListControl)cboQrCode).FormattingEnabled = true;
		((Control)cboQrCode).Location = new Point(160, 21);
		cboQrCode.MaxLength = 25;
		((Control)cboQrCode).Name = "cboQrCode";
		((Control)cboQrCode).Size = new Size(91, 22);
		((Control)cboQrCode).TabIndex = 1132;
		((Control)Label1).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(-4, 21);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(158, 20);
		((Control)Label1).TabIndex = 1131;
		Label1.Text = "Tag Qr Code Generate";
		Label1.TextAlign = (ContentAlignment)64;
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		Tab1.Text = "Setting1";
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		TabPanel3.Dock = (DockStyle)5;
		((Control)TabPanel3).Location = new Point(0, 0);
		((Control)TabPanel3).Name = "TabPanel3";
		((Control)TabPanel3).Size = new Size(1309, 507);
		((Control)TabPanel3).TabIndex = 0;
		TabPanel3.TabItem = Tab3;
		((Control)TabPanel3).Visible = false;
		((Control)Pnl3).Controls.Add((Control)(object)btnCrystalRptType);
		((Control)Pnl3).Controls.Add((Control)(object)cboCrystalViewType);
		((Control)Pnl3).Controls.Add((Control)(object)Label53);
		((Control)Pnl3).Controls.Add((Control)(object)btnPurRateWith);
		((Control)Pnl3).Controls.Add((Control)(object)cboPurRateWith);
		((Control)Pnl3).Controls.Add((Control)(object)Label52);
		((Control)Pnl3).Controls.Add((Control)(object)btnSlRateWith);
		((Control)Pnl3).Controls.Add((Control)(object)cboSlRateWith);
		((Control)Pnl3).Controls.Add((Control)(object)Label51);
		((Control)Pnl3).Controls.Add((Control)(object)btnScrolbar);
		((Control)Pnl3).Controls.Add((Control)(object)brnRefresh);
		((Control)Pnl3).Controls.Add((Control)(object)cboStkRefresh);
		((Control)Pnl3).Controls.Add((Control)(object)Label5);
		((Control)Pnl3).Controls.Add((Control)(object)btnItmLotStk);
		((Control)Pnl3).Controls.Add((Control)(object)cboitmWithLotStk);
		((Control)Pnl3).Controls.Add((Control)(object)Label50);
		((Control)Pnl3).Controls.Add((Control)(object)btnSilverWt3digit);
		((Control)Pnl3).Controls.Add((Control)(object)cboSilverLedr3digit);
		((Control)Pnl3).Controls.Add((Control)(object)Label48);
		((Control)Pnl3).Controls.Add((Control)(object)btnOthItmWtRemove);
		((Control)Pnl3).Controls.Add((Control)(object)cboOthItmWtRemove);
		((Control)Pnl3).Controls.Add((Control)(object)Label47);
		((Control)Pnl3).Controls.Add((Control)(object)btnLbrWithGht);
		((Control)Pnl3).Controls.Add((Control)(object)cboLbrWitGht);
		((Control)Pnl3).Controls.Add((Control)(object)Label45);
		((Control)Pnl3).Controls.Add((Control)(object)btnAllBranchAcShow);
		((Control)Pnl3).Controls.Add((Control)(object)cboAllBrancAcShow);
		((Control)Pnl3).Controls.Add((Control)(object)Label41);
		((Control)Pnl3).Controls.Add((Control)(object)btnTagRowPrint);
		((Control)Pnl3).Controls.Add((Control)(object)cboTagRowPrint);
		((Control)Pnl3).Controls.Add((Control)(object)Label34);
		((Control)Pnl3).Controls.Add((Control)(object)btnTagRowSave);
		((Control)Pnl3).Controls.Add((Control)(object)cboTagRowSave);
		((Control)Pnl3).Controls.Add((Control)(object)Label33);
		((Control)Pnl3).Controls.Add((Control)(object)btnTagSlWtDiff);
		((Control)Pnl3).Controls.Add((Control)(object)cboTagSaleWtDiff);
		((Control)Pnl3).Controls.Add((Control)(object)Label31);
		((Control)Pnl3).Controls.Add((Control)(object)btnStkRptType);
		((Control)Pnl3).Controls.Add((Control)(object)cboStkRptType);
		((Control)Pnl3).Controls.Add((Control)(object)Label30);
		((Control)Pnl3).Controls.Add((Control)(object)cboScorlbar);
		((Control)Pnl3).Controls.Add((Control)(object)Label29);
		((Control)Pnl3).Controls.Add((Control)(object)btnBillTitRof);
		((Control)Pnl3).Controls.Add((Control)(object)cboBilTotRof);
		((Control)Pnl3).Controls.Add((Control)(object)Label28);
		((Control)Pnl3).Dock = (DockStyle)5;
		((Control)Pnl3).Location = new Point(0, 0);
		((Control)Pnl3).Name = "Pnl3";
		((Control)Pnl3).Size = new Size(1309, 507);
		((Control)Pnl3).TabIndex = 1;
		((QControl)btnPurRateWith).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurRateWith).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurRateWith).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurRateWith).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurRateWith).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurRateWith).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurRateWith).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPurRateWith).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurRateWith).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurRateWith).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurRateWith).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurRateWith).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurRateWith).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurRateWith).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurRateWith.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurRateWith.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurRateWith.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurRateWith.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurRateWith.Image = null;
		((QControl)btnPurRateWith).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurRateWith).Location = new Point(734, 162);
		((Control)btnPurRateWith).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurRateWith).Name = "btnPurRateWith";
		((Control)btnPurRateWith).Size = new Size(121, 32);
		((Control)btnPurRateWith).TabIndex = 1283;
		btnPurRateWith.Text = "Pr Rat Calc Set";
		((QControl)btnPurRateWith).ToolTipText = "";
		cboPurRateWith.AutoCompleteMode = (AutoCompleteMode)2;
		cboPurRateWith.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPurRateWith).Font = new Font("Tahoma", 9f);
		((ListControl)cboPurRateWith).FormattingEnabled = true;
		((Control)cboPurRateWith).Location = new Point(628, 166);
		cboPurRateWith.MaxLength = 25;
		((Control)cboPurRateWith).Name = "cboPurRateWith";
		((Control)cboPurRateWith).Size = new Size(91, 22);
		((Control)cboPurRateWith).TabIndex = 1282;
		((Control)Label52).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label52).ForeColor = Color.Black;
		Label52.ImeMode = (ImeMode)0;
		((Control)Label52).Location = new Point(444, 164);
		((Control)Label52).Name = "Label52";
		((Control)Label52).Size = new Size(175, 20);
		((Control)Label52).TabIndex = 1281;
		Label52.Text = "Purc Rate Calc With";
		Label52.TextAlign = (ContentAlignment)64;
		((QControl)btnSlRateWith).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlRateWith).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlRateWith).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlRateWith).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlRateWith).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlRateWith).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlRateWith).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlRateWith).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlRateWith).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlRateWith).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlRateWith).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlRateWith).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlRateWith).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlRateWith).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlRateWith.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateWith.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateWith.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateWith.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlRateWith.Image = null;
		((QControl)btnSlRateWith).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlRateWith).Location = new Point(734, 118);
		((Control)btnSlRateWith).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlRateWith).Name = "btnSlRateWith";
		((Control)btnSlRateWith).Size = new Size(121, 32);
		((Control)btnSlRateWith).TabIndex = 1280;
		btnSlRateWith.Text = "Sl Rat Calc Set";
		((QControl)btnSlRateWith).ToolTipText = "";
		cboSlRateWith.AutoCompleteMode = (AutoCompleteMode)2;
		cboSlRateWith.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSlRateWith).Font = new Font("Tahoma", 9f);
		((ListControl)cboSlRateWith).FormattingEnabled = true;
		((Control)cboSlRateWith).Location = new Point(628, 122);
		cboSlRateWith.MaxLength = 25;
		((Control)cboSlRateWith).Name = "cboSlRateWith";
		((Control)cboSlRateWith).Size = new Size(91, 22);
		((Control)cboSlRateWith).TabIndex = 1279;
		((Control)Label51).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label51).ForeColor = Color.Black;
		Label51.ImeMode = (ImeMode)0;
		((Control)Label51).Location = new Point(444, 120);
		((Control)Label51).Name = "Label51";
		((Control)Label51).Size = new Size(175, 20);
		((Control)Label51).TabIndex = 1278;
		Label51.Text = "Sales Rate Calc With";
		Label51.TextAlign = (ContentAlignment)64;
		((QControl)btnScrolbar).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnScrolbar).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnScrolbar).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnScrolbar).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnScrolbar).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnScrolbar).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnScrolbar).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnScrolbar).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnScrolbar).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnScrolbar).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnScrolbar).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnScrolbar).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnScrolbar).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnScrolbar).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnScrolbar.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnScrolbar.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnScrolbar.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnScrolbar.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnScrolbar.Image = null;
		((QControl)btnScrolbar).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnScrolbar).Location = new Point(317, 69);
		((Control)btnScrolbar).Margin = new Padding(3, 6, 3, 6);
		((Control)btnScrolbar).Name = "btnScrolbar";
		((Control)btnScrolbar).Size = new Size(121, 32);
		((Control)btnScrolbar).TabIndex = 1247;
		btnScrolbar.Text = "Scrollbar Set";
		((QBalloonConfiguration)((QControl)btnScrolbar).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnScrolbar).ToolTipText = "";
		((QControl)brnRefresh).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)brnRefresh).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnRefresh).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)brnRefresh).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)brnRefresh).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)brnRefresh).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)brnRefresh).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)brnRefresh).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)brnRefresh).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)brnRefresh).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)brnRefresh).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)brnRefresh).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)brnRefresh).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)brnRefresh).ColorScheme).InheritCurrentThemeFromGlobal = false;
		brnRefresh.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnRefresh.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnRefresh.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnRefresh.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		brnRefresh.Image = null;
		((QControl)brnRefresh).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)brnRefresh).Location = new Point(734, 74);
		((Control)brnRefresh).Margin = new Padding(3, 6, 3, 6);
		((Control)brnRefresh).Name = "brnRefresh";
		((Control)brnRefresh).Size = new Size(121, 32);
		((Control)brnRefresh).TabIndex = 1277;
		brnRefresh.Text = "Stk Refresh Set";
		((QControl)brnRefresh).ToolTipText = "";
		cboStkRefresh.AutoCompleteMode = (AutoCompleteMode)2;
		cboStkRefresh.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboStkRefresh).Font = new Font("Tahoma", 9f);
		((ListControl)cboStkRefresh).FormattingEnabled = true;
		((Control)cboStkRefresh).Location = new Point(628, 78);
		cboStkRefresh.MaxLength = 25;
		((Control)cboStkRefresh).Name = "cboStkRefresh";
		((Control)cboStkRefresh).Size = new Size(91, 22);
		((Control)cboStkRefresh).TabIndex = 1276;
		((Control)Label5).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(432, 76);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(187, 20);
		((Control)Label5).TabIndex = 1275;
		Label5.Text = "Curent Day Stock Refresh";
		Label5.TextAlign = (ContentAlignment)64;
		((QControl)btnItmLotStk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItmLotStk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItmLotStk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItmLotStk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItmLotStk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItmLotStk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItmLotStk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnItmLotStk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItmLotStk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItmLotStk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItmLotStk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItmLotStk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItmLotStk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItmLotStk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItmLotStk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmLotStk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmLotStk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmLotStk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItmLotStk.Image = null;
		((QControl)btnItmLotStk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItmLotStk).Location = new Point(734, 25);
		((Control)btnItmLotStk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItmLotStk).Name = "btnItmLotStk";
		((Control)btnItmLotStk).Size = new Size(121, 32);
		((Control)btnItmLotStk).TabIndex = 1274;
		btnItmLotStk.Text = "Itm Lot Stk Set";
		((QControl)btnItmLotStk).ToolTipText = "";
		cboitmWithLotStk.AutoCompleteMode = (AutoCompleteMode)2;
		cboitmWithLotStk.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboitmWithLotStk).Font = new Font("Tahoma", 9f);
		((ListControl)cboitmWithLotStk).FormattingEnabled = true;
		((Control)cboitmWithLotStk).Location = new Point(628, 30);
		cboitmWithLotStk.MaxLength = 25;
		((Control)cboitmWithLotStk).Name = "cboitmWithLotStk";
		((Control)cboitmWithLotStk).Size = new Size(91, 22);
		((Control)cboitmWithLotStk).TabIndex = 1273;
		((Control)Label50).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label50).ForeColor = Color.Black;
		Label50.ImeMode = (ImeMode)0;
		((Control)Label50).Location = new Point(467, 30);
		((Control)Label50).Name = "Label50";
		((Control)Label50).Size = new Size(152, 20);
		((Control)Label50).TabIndex = 1272;
		Label50.Text = "Item With Lot Stock";
		Label50.TextAlign = (ContentAlignment)64;
		((QControl)btnSilverWt3digit).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSilverWt3digit).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSilverWt3digit).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSilverWt3digit).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSilverWt3digit.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSilverWt3digit.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSilverWt3digit.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSilverWt3digit.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSilverWt3digit.Image = null;
		((QControl)btnSilverWt3digit).LocalFont = new Font("Segoe UI", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnSilverWt3digit).Location = new Point(317, 421);
		((Control)btnSilverWt3digit).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSilverWt3digit).Name = "btnSilverWt3digit";
		((Control)btnSilverWt3digit).Size = new Size(121, 32);
		((Control)btnSilverWt3digit).TabIndex = 1271;
		btnSilverWt3digit.Text = "Silver Ldr Set";
		((QBalloonConfiguration)((QControl)btnSilverWt3digit).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnSilverWt3digit).ToolTipText = "Oth Itm Wt Remove In Wh Sale Bill";
		cboSilverLedr3digit.AutoCompleteMode = (AutoCompleteMode)2;
		cboSilverLedr3digit.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSilverLedr3digit).Font = new Font("Tahoma", 9f);
		((ListControl)cboSilverLedr3digit).FormattingEnabled = true;
		((Control)cboSilverLedr3digit).Location = new Point(211, 426);
		cboSilverLedr3digit.MaxLength = 25;
		((Control)cboSilverLedr3digit).Name = "cboSilverLedr3digit";
		((Control)cboSilverLedr3digit).Size = new Size(91, 22);
		((Control)cboSilverLedr3digit).TabIndex = 1270;
		((Control)Label48).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label48).ForeColor = Color.Black;
		Label48.ImeMode = (ImeMode)0;
		((Control)Label48).Location = new Point(0, 426);
		((Control)Label48).Name = "Label48";
		((Control)Label48).Size = new Size(202, 20);
		((Control)Label48).TabIndex = 1269;
		Label48.Text = "Silver Ledger With 3 Digit";
		Label48.TextAlign = (ContentAlignment)64;
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOthItmWtRemove).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOthItmWtRemove).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOthItmWtRemove).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOthItmWtRemove.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOthItmWtRemove.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOthItmWtRemove.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOthItmWtRemove.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOthItmWtRemove.Image = null;
		((QControl)btnOthItmWtRemove).LocalFont = new Font("Segoe UI", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)btnOthItmWtRemove).Location = new Point(317, 377);
		((Control)btnOthItmWtRemove).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOthItmWtRemove).Name = "btnOthItmWtRemove";
		((Control)btnOthItmWtRemove).Size = new Size(121, 32);
		((Control)btnOthItmWtRemove).TabIndex = 1268;
		btnOthItmWtRemove.Text = "Oth Wt Remov";
		((QBalloonConfiguration)((QControl)btnOthItmWtRemove).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnOthItmWtRemove).ToolTipText = "Oth Itm Wt Remove In Wh Sale Bill";
		cboOthItmWtRemove.AutoCompleteMode = (AutoCompleteMode)2;
		cboOthItmWtRemove.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOthItmWtRemove).Font = new Font("Tahoma", 9f);
		((ListControl)cboOthItmWtRemove).FormattingEnabled = true;
		((Control)cboOthItmWtRemove).Location = new Point(211, 382);
		cboOthItmWtRemove.MaxLength = 25;
		((Control)cboOthItmWtRemove).Name = "cboOthItmWtRemove";
		((Control)cboOthItmWtRemove).Size = new Size(91, 22);
		((Control)cboOthItmWtRemove).TabIndex = 1267;
		((Control)Label47).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label47).ForeColor = Color.Black;
		Label47.ImeMode = (ImeMode)0;
		((Control)Label47).Location = new Point(0, 382);
		((Control)Label47).Name = "Label47";
		((Control)Label47).Size = new Size(202, 20);
		((Control)Label47).TabIndex = 1266;
		Label47.Text = "Oth Itm Wt Remove In Wh Sale";
		Label47.TextAlign = (ContentAlignment)64;
		((QControl)btnLbrWithGht).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnLbrWithGht).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnLbrWithGht).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnLbrWithGht).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnLbrWithGht.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrWithGht.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrWithGht.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrWithGht.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnLbrWithGht.Image = null;
		((QControl)btnLbrWithGht).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnLbrWithGht).Location = new Point(317, 333);
		((Control)btnLbrWithGht).Margin = new Padding(3, 6, 3, 6);
		((Control)btnLbrWithGht).Name = "btnLbrWithGht";
		((Control)btnLbrWithGht).Size = new Size(121, 32);
		((Control)btnLbrWithGht).TabIndex = 1265;
		btnLbrWithGht.Text = "Lbr Ght Set";
		((QBalloonConfiguration)((QControl)btnLbrWithGht).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnLbrWithGht).ToolTipText = "Sales Ma Tag Weight Change kare to Posting ma Tag no Weight j Less Krva mate";
		cboLbrWitGht.AutoCompleteMode = (AutoCompleteMode)2;
		cboLbrWitGht.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboLbrWitGht).Font = new Font("Tahoma", 9f);
		((ListControl)cboLbrWitGht).FormattingEnabled = true;
		((Control)cboLbrWitGht).Location = new Point(211, 338);
		cboLbrWitGht.MaxLength = 25;
		((Control)cboLbrWitGht).Name = "cboLbrWitGht";
		((Control)cboLbrWitGht).Size = new Size(91, 22);
		((Control)cboLbrWitGht).TabIndex = 1264;
		((Control)Label45).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label45).ForeColor = Color.Black;
		Label45.ImeMode = (ImeMode)0;
		((Control)Label45).Location = new Point(0, 338);
		((Control)Label45).Name = "Label45";
		((Control)Label45).Size = new Size(202, 20);
		((Control)Label45).TabIndex = 1263;
		Label45.Text = "LAmt = GhtWt + NetWt * LRate";
		Label45.TextAlign = (ContentAlignment)64;
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAllBranchAcShow).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAllBranchAcShow).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAllBranchAcShow).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAllBranchAcShow.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAllBranchAcShow.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAllBranchAcShow.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAllBranchAcShow.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAllBranchAcShow.Image = null;
		((QControl)btnAllBranchAcShow).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAllBranchAcShow).Location = new Point(317, 245);
		((Control)btnAllBranchAcShow).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAllBranchAcShow).Name = "btnAllBranchAcShow";
		((Control)btnAllBranchAcShow).Size = new Size(121, 32);
		((Control)btnAllBranchAcShow).TabIndex = 1262;
		btnAllBranchAcShow.Text = "Loct Ac Show";
		((QBalloonConfiguration)((QControl)btnAllBranchAcShow).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnAllBranchAcShow).ToolTipText = "";
		cboAllBrancAcShow.AutoCompleteMode = (AutoCompleteMode)2;
		cboAllBrancAcShow.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboAllBrancAcShow).Font = new Font("Tahoma", 9f);
		((ListControl)cboAllBrancAcShow).FormattingEnabled = true;
		((Control)cboAllBrancAcShow).Location = new Point(211, 250);
		cboAllBrancAcShow.MaxLength = 25;
		((Control)cboAllBrancAcShow).Name = "cboAllBrancAcShow";
		((Control)cboAllBrancAcShow).Size = new Size(91, 22);
		((Control)cboAllBrancAcShow).TabIndex = 1261;
		((Control)Label41).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label41).ForeColor = Color.Black;
		Label41.ImeMode = (ImeMode)0;
		((Control)Label41).Location = new Point(12, 250);
		((Control)Label41).Name = "Label41";
		((Control)Label41).Size = new Size(188, 20);
		((Control)Label41).TabIndex = 1260;
		Label41.Text = "All Branch Ac Show";
		Label41.TextAlign = (ContentAlignment)64;
		((QControl)btnTagRowPrint).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTagRowPrint).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnTagRowPrint).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnTagRowPrint).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnTagRowPrint.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowPrint.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowPrint.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowPrint.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowPrint.Image = null;
		((QControl)btnTagRowPrint).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnTagRowPrint).Location = new Point(317, 201);
		((Control)btnTagRowPrint).Margin = new Padding(3, 6, 3, 6);
		((Control)btnTagRowPrint).Name = "btnTagRowPrint";
		((Control)btnTagRowPrint).Size = new Size(121, 32);
		((Control)btnTagRowPrint).TabIndex = 1259;
		btnTagRowPrint.Text = "Tag Row Print";
		((QBalloonConfiguration)((QControl)btnTagRowPrint).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnTagRowPrint).ToolTipText = "";
		cboTagRowPrint.AutoCompleteMode = (AutoCompleteMode)2;
		cboTagRowPrint.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTagRowPrint).Font = new Font("Tahoma", 9f);
		((ListControl)cboTagRowPrint).FormattingEnabled = true;
		((Control)cboTagRowPrint).Location = new Point(211, 206);
		cboTagRowPrint.MaxLength = 25;
		((Control)cboTagRowPrint).Name = "cboTagRowPrint";
		((Control)cboTagRowPrint).Size = new Size(91, 22);
		((Control)cboTagRowPrint).TabIndex = 1258;
		((Control)Label34).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label34).ForeColor = Color.Black;
		Label34.ImeMode = (ImeMode)0;
		((Control)Label34).Location = new Point(12, 206);
		((Control)Label34).Name = "Label34";
		((Control)Label34).Size = new Size(188, 20);
		((Control)Label34).TabIndex = 1257;
		Label34.Text = "Tag Entry Row wise Print";
		Label34.TextAlign = (ContentAlignment)64;
		((QControl)btnTagRowSave).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnTagRowSave).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagRowSave).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnTagRowSave).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnTagRowSave).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnTagRowSave).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagRowSave).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnTagRowSave).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnTagRowSave).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnTagRowSave).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnTagRowSave).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTagRowSave).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnTagRowSave).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnTagRowSave).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnTagRowSave.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowSave.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowSave.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowSave.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagRowSave.Image = null;
		((QControl)btnTagRowSave).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnTagRowSave).Location = new Point(317, 157);
		((Control)btnTagRowSave).Margin = new Padding(3, 6, 3, 6);
		((Control)btnTagRowSave).Name = "btnTagRowSave";
		((Control)btnTagRowSave).Size = new Size(121, 32);
		((Control)btnTagRowSave).TabIndex = 1256;
		btnTagRowSave.Text = "Tag Row Save";
		((QBalloonConfiguration)((QControl)btnTagRowSave).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnTagRowSave).ToolTipText = "";
		cboTagRowSave.AutoCompleteMode = (AutoCompleteMode)2;
		cboTagRowSave.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTagRowSave).Font = new Font("Tahoma", 9f);
		((ListControl)cboTagRowSave).FormattingEnabled = true;
		((Control)cboTagRowSave).Location = new Point(211, 162);
		cboTagRowSave.MaxLength = 25;
		((Control)cboTagRowSave).Name = "cboTagRowSave";
		((Control)cboTagRowSave).Size = new Size(91, 22);
		((Control)cboTagRowSave).TabIndex = 1255;
		((Control)Label33).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label33).ForeColor = Color.Black;
		Label33.ImeMode = (ImeMode)0;
		((Control)Label33).Location = new Point(3, 162);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(197, 20);
		((Control)Label33).TabIndex = 1254;
		Label33.Text = "Tag Entry Row wise Auto  Save";
		Label33.TextAlign = (ContentAlignment)64;
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTagSlWtDiff).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnTagSlWtDiff).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnTagSlWtDiff).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnTagSlWtDiff.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagSlWtDiff.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagSlWtDiff.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagSlWtDiff.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagSlWtDiff.Image = null;
		((QControl)btnTagSlWtDiff).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnTagSlWtDiff).Location = new Point(317, 289);
		((Control)btnTagSlWtDiff).Margin = new Padding(3, 6, 3, 6);
		((Control)btnTagSlWtDiff).Name = "btnTagSlWtDiff";
		((Control)btnTagSlWtDiff).Size = new Size(121, 32);
		((Control)btnTagSlWtDiff).TabIndex = 1253;
		btnTagSlWtDiff.Text = "Wt Same Set";
		((QBalloonConfiguration)((QControl)btnTagSlWtDiff).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnTagSlWtDiff).ToolTipText = "Sales Ma Tag Weight Change kare to Posting ma Tag no Weight j Less Krva mate";
		cboTagSaleWtDiff.AutoCompleteMode = (AutoCompleteMode)2;
		cboTagSaleWtDiff.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTagSaleWtDiff).Font = new Font("Tahoma", 9f);
		((ListControl)cboTagSaleWtDiff).FormattingEnabled = true;
		((Control)cboTagSaleWtDiff).Location = new Point(211, 294);
		cboTagSaleWtDiff.MaxLength = 25;
		((Control)cboTagSaleWtDiff).Name = "cboTagSaleWtDiff";
		((Control)cboTagSaleWtDiff).Size = new Size(91, 22);
		((Control)cboTagSaleWtDiff).TabIndex = 1252;
		((Control)Label31).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label31).ForeColor = Color.Black;
		Label31.ImeMode = (ImeMode)0;
		((Control)Label31).Location = new Point(43, 294);
		((Control)Label31).Name = "Label31";
		((Control)Label31).Size = new Size(159, 20);
		((Control)Label31).TabIndex = 1251;
		Label31.Text = "Tag Wt and Sl Wt  Same";
		Label31.TextAlign = (ContentAlignment)64;
		((QControl)btnStkRptType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnStkRptType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnStkRptType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnStkRptType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnStkRptType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnStkRptType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnStkRptType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnStkRptType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnStkRptType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnStkRptType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnStkRptType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnStkRptType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnStkRptType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnStkRptType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnStkRptType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnStkRptType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnStkRptType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnStkRptType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnStkRptType.Image = null;
		((QControl)btnStkRptType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnStkRptType).Location = new Point(317, 113);
		((Control)btnStkRptType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnStkRptType).Name = "btnStkRptType";
		((Control)btnStkRptType).Size = new Size(121, 32);
		((Control)btnStkRptType).TabIndex = 1250;
		btnStkRptType.Text = "Stk Rpt Set";
		((QBalloonConfiguration)((QControl)btnStkRptType).ToolTipConfiguration).ShowOnFocus = true;
		((QControl)btnStkRptType).ToolTipText = "";
		cboStkRptType.AutoCompleteMode = (AutoCompleteMode)2;
		cboStkRptType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboStkRptType).Font = new Font("Tahoma", 9f);
		((ListControl)cboStkRptType).FormattingEnabled = true;
		((Control)cboStkRptType).Location = new Point(211, 118);
		cboStkRptType.MaxLength = 25;
		((Control)cboStkRptType).Name = "cboStkRptType";
		((Control)cboStkRptType).Size = new Size(91, 22);
		((Control)cboStkRptType).TabIndex = 1249;
		((Control)Label30).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label30).ForeColor = Color.Black;
		Label30.ImeMode = (ImeMode)0;
		((Control)Label30).Location = new Point(50, 118);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(152, 20);
		((Control)Label30).TabIndex = 1248;
		Label30.Text = "Stock F3 Report Type";
		Label30.TextAlign = (ContentAlignment)64;
		cboScorlbar.AutoCompleteMode = (AutoCompleteMode)2;
		cboScorlbar.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboScorlbar).Font = new Font("Tahoma", 9f);
		((ListControl)cboScorlbar).FormattingEnabled = true;
		((Control)cboScorlbar).Location = new Point(211, 74);
		cboScorlbar.MaxLength = 25;
		((Control)cboScorlbar).Name = "cboScorlbar";
		((Control)cboScorlbar).Size = new Size(91, 22);
		((Control)cboScorlbar).TabIndex = 1246;
		((Control)Label29).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label29).ForeColor = Color.Black;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(50, 74);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(152, 20);
		((Control)Label29).TabIndex = 1245;
		Label29.Text = "Item Tot Grid Scorllbar";
		Label29.TextAlign = (ContentAlignment)64;
		((QControl)btnBillTitRof).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBillTitRof).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBillTitRof).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBillTitRof).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBillTitRof).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBillTitRof).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBillTitRof).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnBillTitRof).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBillTitRof).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBillTitRof).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBillTitRof).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBillTitRof).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBillTitRof).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBillTitRof).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBillTitRof.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillTitRof.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillTitRof.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillTitRof.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBillTitRof.Image = null;
		((QControl)btnBillTitRof).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBillTitRof).Location = new Point(317, 25);
		((Control)btnBillTitRof).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBillTitRof).Name = "btnBillTitRof";
		((Control)btnBillTitRof).Size = new Size(121, 32);
		((Control)btnBillTitRof).TabIndex = 1244;
		btnBillTitRof.Text = "Bill Tot Rof Set";
		((QControl)btnBillTitRof).ToolTipText = "";
		cboBilTotRof.AutoCompleteMode = (AutoCompleteMode)2;
		cboBilTotRof.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboBilTotRof).Font = new Font("Tahoma", 9f);
		((ListControl)cboBilTotRof).FormattingEnabled = true;
		((Control)cboBilTotRof).Location = new Point(211, 30);
		cboBilTotRof.MaxLength = 25;
		((Control)cboBilTotRof).Name = "cboBilTotRof";
		((Control)cboBilTotRof).Size = new Size(91, 22);
		((Control)cboBilTotRof).TabIndex = 1243;
		((Control)Label28).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label28).ForeColor = Color.Black;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(50, 30);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(152, 20);
		((Control)Label28).TabIndex = 1242;
		Label28.Text = "Bill Tot Amt Round of";
		Label28.TextAlign = (ContentAlignment)64;
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		Tab3.Text = "Setting3";
		Tab3.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		TabPanel2.Dock = (DockStyle)5;
		((Control)TabPanel2).Location = new Point(0, 0);
		((Control)TabPanel2).Name = "TabPanel2";
		((Control)TabPanel2).Size = new Size(1309, 507);
		((Control)TabPanel2).TabIndex = 0;
		TabPanel2.TabItem = Tab2;
		((Control)TabPanel2).Visible = false;
		((Control)Pnl2).Controls.Add((Control)(object)btnEmpAsUser);
		((Control)Pnl2).Controls.Add((Control)(object)cboEmpAsUser);
		((Control)Pnl2).Controls.Add((Control)(object)Label42);
		((Control)Pnl2).Controls.Add((Control)(object)btnHelpLent);
		((Control)Pnl2).Controls.Add((Control)(object)cboHelpLent);
		((Control)Pnl2).Controls.Add((Control)(object)Label39);
		((Control)Pnl2).Controls.Add((Control)(object)btnMobileSearch);
		((Control)Pnl2).Controls.Add((Control)(object)cboMobileSearch);
		((Control)Pnl2).Controls.Add((Control)(object)Label14);
		((Control)Pnl2).Controls.Add((Control)(object)btnOrnaIsu);
		((Control)Pnl2).Controls.Add((Control)(object)cboOrnaIsu);
		((Control)Pnl2).Controls.Add((Control)(object)Label13);
		((Control)Pnl2).Dock = (DockStyle)5;
		((Control)Pnl2).Location = new Point(0, 0);
		((Control)Pnl2).Name = "Pnl2";
		((Control)Pnl2).Size = new Size(1309, 507);
		((Control)Pnl2).TabIndex = 0;
		((QControl)btnEmpAsUser).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnEmpAsUser).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnEmpAsUser).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnEmpAsUser).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnEmpAsUser.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpAsUser.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpAsUser.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpAsUser.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEmpAsUser.Image = null;
		((QControl)btnEmpAsUser).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnEmpAsUser).Location = new Point(408, 151);
		((Control)btnEmpAsUser).Margin = new Padding(3, 6, 3, 6);
		((Control)btnEmpAsUser).Name = "btnEmpAsUser";
		((Control)btnEmpAsUser).Size = new Size(121, 32);
		((Control)btnEmpAsUser).TabIndex = 1214;
		btnEmpAsUser.Text = "Emp As User";
		cboEmpAsUser.AutoCompleteMode = (AutoCompleteMode)2;
		cboEmpAsUser.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboEmpAsUser).Font = new Font("Tahoma", 9f);
		((ListControl)cboEmpAsUser).FormattingEnabled = true;
		((Control)cboEmpAsUser).Location = new Point(294, 157);
		cboEmpAsUser.MaxLength = 25;
		((Control)cboEmpAsUser).Name = "cboEmpAsUser";
		((Control)cboEmpAsUser).Size = new Size(106, 22);
		((Control)cboEmpAsUser).TabIndex = 1213;
		((Control)Label42).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label42).ForeColor = Color.Black;
		Label42.ImeMode = (ImeMode)0;
		((Control)Label42).Location = new Point(3, 157);
		((Control)Label42).Name = "Label42";
		((Control)Label42).Size = new Size(280, 20);
		((Control)Label42).TabIndex = 1212;
		Label42.Text = "User Wise Emp Set  In All Transection";
		Label42.TextAlign = (ContentAlignment)64;
		((QControl)btnHelpLent).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnHelpLent).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnHelpLent).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnHelpLent).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnHelpLent).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnHelpLent).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnHelpLent).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnHelpLent).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnHelpLent).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnHelpLent).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnHelpLent).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnHelpLent).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnHelpLent).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnHelpLent).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnHelpLent.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpLent.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpLent.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpLent.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnHelpLent.Image = null;
		((QControl)btnHelpLent).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnHelpLent).Location = new Point(408, 107);
		((Control)btnHelpLent).Margin = new Padding(3, 6, 3, 6);
		((Control)btnHelpLent).Name = "btnHelpLent";
		((Control)btnHelpLent).Size = new Size(121, 32);
		((Control)btnHelpLent).TabIndex = 1211;
		btnHelpLent.Text = "Help Lnth Set";
		cboHelpLent.AutoCompleteMode = (AutoCompleteMode)2;
		cboHelpLent.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboHelpLent).Font = new Font("Tahoma", 9f);
		((ListControl)cboHelpLent).FormattingEnabled = true;
		((Control)cboHelpLent).Location = new Point(294, 113);
		cboHelpLent.MaxLength = 25;
		((Control)cboHelpLent).Name = "cboHelpLent";
		((Control)cboHelpLent).Size = new Size(106, 22);
		((Control)cboHelpLent).TabIndex = 1210;
		((Control)Label39).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label39).ForeColor = Color.Black;
		Label39.ImeMode = (ImeMode)0;
		((Control)Label39).Location = new Point(12, 113);
		((Control)Label39).Name = "Label39";
		((Control)Label39).Size = new Size(271, 20);
		((Control)Label39).TabIndex = 1209;
		Label39.Text = "All Form Vch Desc Help Length Set";
		Label39.TextAlign = (ContentAlignment)64;
		((QControl)btnMobileSearch).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnMobileSearch).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnMobileSearch).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnMobileSearch).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnMobileSearch).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnMobileSearch).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnMobileSearch).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnMobileSearch).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnMobileSearch).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnMobileSearch).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnMobileSearch).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnMobileSearch).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnMobileSearch).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnMobileSearch).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnMobileSearch.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMobileSearch.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMobileSearch.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMobileSearch.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnMobileSearch.Image = null;
		((QControl)btnMobileSearch).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnMobileSearch).Location = new Point(408, 63);
		((Control)btnMobileSearch).Margin = new Padding(3, 6, 3, 6);
		((Control)btnMobileSearch).Name = "btnMobileSearch";
		((Control)btnMobileSearch).Size = new Size(121, 32);
		((Control)btnMobileSearch).TabIndex = 1208;
		btnMobileSearch.Text = "Mo No Help Set";
		cboMobileSearch.AutoCompleteMode = (AutoCompleteMode)2;
		cboMobileSearch.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboMobileSearch).Font = new Font("Tahoma", 9f);
		((ListControl)cboMobileSearch).FormattingEnabled = true;
		((Control)cboMobileSearch).Location = new Point(294, 69);
		cboMobileSearch.MaxLength = 25;
		((Control)cboMobileSearch).Name = "cboMobileSearch";
		((Control)cboMobileSearch).Size = new Size(106, 22);
		((Control)cboMobileSearch).TabIndex = 1207;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(74, 69);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(212, 20);
		((Control)Label14).TabIndex = 1206;
		Label14.Text = "Party Help Serch With Mobile";
		Label14.TextAlign = (ContentAlignment)64;
		((QControl)btnOrnaIsu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOrnaIsu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOrnaIsu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOrnaIsu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOrnaIsu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrnaIsu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrnaIsu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrnaIsu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOrnaIsu.Image = null;
		((QControl)btnOrnaIsu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOrnaIsu).Location = new Point(408, 19);
		((Control)btnOrnaIsu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOrnaIsu).Name = "btnOrnaIsu";
		((Control)btnOrnaIsu).Size = new Size(121, 32);
		((Control)btnOrnaIsu).TabIndex = 1205;
		btnOrnaIsu.Text = "Orna Isu Set";
		cboOrnaIsu.AutoCompleteMode = (AutoCompleteMode)2;
		cboOrnaIsu.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOrnaIsu).Font = new Font("Tahoma", 9f);
		((ListControl)cboOrnaIsu).FormattingEnabled = true;
		((Control)cboOrnaIsu).Location = new Point(294, 25);
		cboOrnaIsu.MaxLength = 25;
		((Control)cboOrnaIsu).Name = "cboOrnaIsu";
		((Control)cboOrnaIsu).Size = new Size(106, 22);
		((Control)cboOrnaIsu).TabIndex = 1204;
		((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(85, 25);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(201, 20);
		((Control)Label13).TabIndex = 1203;
		Label13.Text = "Bill Os Then Ornament  isu";
		Label13.TextAlign = (ContentAlignment)64;
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		Tab2.Text = "Advance Cantrol";
		Tab2.TextAlignment = (eItemAlignment)2;
		((QControl)btnCrystalRptType).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCrystalRptType).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCrystalRptType).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCrystalRptType).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCrystalRptType.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCrystalRptType.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCrystalRptType.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCrystalRptType.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCrystalRptType.Image = null;
		((QControl)btnCrystalRptType).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCrystalRptType).Location = new Point(734, 206);
		((Control)btnCrystalRptType).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCrystalRptType).Name = "btnCrystalRptType";
		((Control)btnCrystalRptType).Size = new Size(121, 32);
		((Control)btnCrystalRptType).TabIndex = 1286;
		btnCrystalRptType.Text = "Crystal Rpt Set";
		((QControl)btnCrystalRptType).ToolTipText = "";
		cboCrystalViewType.AutoCompleteMode = (AutoCompleteMode)2;
		cboCrystalViewType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCrystalViewType).Font = new Font("Tahoma", 9f);
		((ListControl)cboCrystalViewType).FormattingEnabled = true;
		((Control)cboCrystalViewType).Location = new Point(628, 210);
		cboCrystalViewType.MaxLength = 25;
		((Control)cboCrystalViewType).Name = "cboCrystalViewType";
		((Control)cboCrystalViewType).Size = new Size(91, 22);
		((Control)cboCrystalViewType).TabIndex = 1285;
		((Control)Label53).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label53).ForeColor = Color.Black;
		Label53.ImeMode = (ImeMode)0;
		((Control)Label53).Location = new Point(444, 208);
		((Control)Label53).Name = "Label53";
		((Control)Label53).Size = new Size(175, 20);
		((Control)Label53).TabIndex = 1284;
		Label53.Text = "Crystal Report View Type";
		Label53.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_SETTING_MAIN";
		((Form)this).Text = "Setting Main";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)Pnl1).PerformLayout();
		((Control)pnlSet).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)TabPanel3).ResumeLayout(false);
		((Control)Pnl3).ResumeLayout(false);
		((Control)TabPanel2).ResumeLayout(false);
		((Control)Pnl2).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void UT_SETTING_MAIN_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec6: Expected O, but got Unknown
		//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f40: Expected O, but got Unknown
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb7: Expected O, but got Unknown
		//IL_1025: Unknown result type (might be due to invalid IL or missing references)
		//IL_102a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1030: Expected O, but got Unknown
		//IL_109e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a9: Expected O, but got Unknown
		//IL_1117: Unknown result type (might be due to invalid IL or missing references)
		//IL_111c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1122: Expected O, but got Unknown
		//IL_11aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_11af: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b9: Expected O, but got Unknown
		//IL_122b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1230: Unknown result type (might be due to invalid IL or missing references)
		//IL_1236: Expected O, but got Unknown
		//IL_1287: Unknown result type (might be due to invalid IL or missing references)
		//IL_1291: Expected O, but got Unknown
		//IL_12a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ae: Expected O, but got Unknown
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
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((Control)pnlSet).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				Panel obj8 = pnlSet;
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj10 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				Panel obj11 = pnlSet;
				object? obj12 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)obj11).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj13 = lblBook;
				object? obj14 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj13).ForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj15 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)Label1).Font.Size * (1.0 + num2));
				Font font = ((Control)Label1).Font;
				try
				{
					foreach (Control control7 in ((Control)this).Controls)
					{
						Control val3 = control7;
						if (unchecked((Operators.CompareString(val3.Name, "lblBook", false) != 0 && val3 is TextBox) || val3 is Label || val3 is ComboBox || val3 is SimpleButton || val3 is MaskedTextBox || val3 is QButton))
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control8 in ((Control)Pnl1).Controls)
					{
						object objectValue6 = RuntimeHelpers.GetObjectValue(control8);
						NewLateBinding.LateSet(objectValue6, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control9 in ((Control)Pnl2).Controls)
					{
						object objectValue7 = RuntimeHelpers.GetObjectValue(control9);
						NewLateBinding.LateSet(objectValue7, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control10 in ((Control)Pnl3).Controls)
					{
						object objectValue8 = RuntimeHelpers.GetObjectValue(control10);
						NewLateBinding.LateSet(objectValue8, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control11 in ((Control)TabMenu).Controls)
					{
						object objectValue9 = RuntimeHelpers.GetObjectValue(control11);
						NewLateBinding.LateSet(objectValue9, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
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
					foreach (object control12 in ((Control)PnlBotam).Controls)
					{
						object objectValue10 = RuntimeHelpers.GetObjectValue(control12);
						NewLateBinding.LateSet(objectValue10, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				TabMenu.SelectedTabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				TabMenu.TabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			CLEAR_DATA();
			cboQrCode.Items.Add((object)"No");
			cboQrCode.Items.Add((object)"Yes");
			cboCustOsSms.Items.Add((object)"No");
			cboCustOsSms.Items.Add((object)"Yes");
			cboLoanIntType.Items.Add((object)"Month Wise");
			cboLoanIntType.Items.Add((object)"Day Wise");
			cboSalesImagPrint.Items.Add((object)"No");
			cboSalesImagPrint.Items.Add((object)"Yes");
			cboTotFineStkType.Items.Add((object)"Item Wise");
			cboTotFineStkType.Items.Add((object)"Group Wise");
			cboTotFineStkType.Items.Add((object)"Trading Wise");
			cboPrRateRof.Items.Add((object)"0");
			cboPrRateRof.Items.Add((object)"1");
			cboPrRateRof.Items.Add((object)"2");
			cboPrRateRof.Items.Add((object)"3");
			cboAdminSms.Items.Add((object)"No");
			cboAdminSms.Items.Add((object)"Yes");
			cboCustSms.Items.Add((object)"No");
			cboCustSms.Items.Add((object)"Yes");
			cboWappSlPrint.Items.Add((object)"No");
			cboWappSlPrint.Items.Add((object)"Yes");
			cboDesignGen.Items.Add((object)"No");
			cboDesignGen.Items.Add((object)"Yes");
			cboOrdImage.Items.Add((object)"No");
			cboOrdImage.Items.Add((object)"Yes");
			cboOrnaIsu.Items.Add((object)"Yes");
			cboOrnaIsu.Items.Add((object)"No");
			cboMobileSearch.Items.Add((object)"Yes");
			cboMobileSearch.Items.Add((object)"No");
			cboEmpMandatory.Items.Add((object)"No");
			cboEmpMandatory.Items.Add((object)"Yes");
			cboFontChange.Items.Add((object)"No");
			cboFontChange.Items.Add((object)"Yes");
			cboPreviousLock.Items.Add((object)"No");
			cboPreviousLock.Items.Add((object)"Yes");
			cboFontSize.Items.Add((object)"8");
			cboFontSize.Items.Add((object)"9");
			cboFontSize.Items.Add((object)"10");
			cboFontSize.Items.Add((object)"11");
			cboFontSize.Items.Add((object)"12");
			cboFontSize.Items.Add((object)"13");
			cboFontSize.Items.Add((object)"14");
			cboFontSize.Items.Add((object)"15");
			CboFontName.Items.Add((object)"Calibri");
			CboFontName.Items.Add((object)"Tahoma");
			CboFontName.Items.Add((object)"Arial");
			CboFontName.Items.Add((object)"Nirmala UI");
			CboFontName.Items.Add((object)"Segoe UI Semibold");
			cboFontStyle.Items.Add((object)"0 - Regular");
			cboFontStyle.Items.Add((object)"1 - Bold");
			cboPrintFormSet.Items.Add((object)"Exit");
			cboPrintFormSet.Items.Add((object)"Print");
			cboPrintFormSet.Items.Add((object)"View");
			cboGridRowHeight.Items.Add((object)"20");
			cboGridRowHeight.Items.Add((object)"21");
			cboGridRowHeight.Items.Add((object)"22");
			cboGridRowHeight.Items.Add((object)"23");
			cboGridRowHeight.Items.Add((object)"24");
			cboGridRowHeight.Items.Add((object)"25");
			cboGridRowHeight.Items.Add((object)"26");
			cboGridRowHeight.Items.Add((object)"27");
			cboGridRowHeight.Items.Add((object)"28");
			cboGridRowHeight.Items.Add((object)"29");
			cboGridRowHeight.Items.Add((object)"30");
			cboGridRowHeight.Items.Add((object)"33");
			cboGridRowHeight.Items.Add((object)"35");
			cboGridRowHeight.Items.Add((object)"37");
			cboGridRowHeight.Items.Add((object)"40");
			cboBilTotRof.Items.Add((object)"0");
			cboBilTotRof.Items.Add((object)"1");
			cboBilTotRof.Items.Add((object)"2");
			cboScorlbar.Items.Add((object)"Yes");
			cboScorlbar.Items.Add((object)"No");
			cboStkRptType.Items.Add((object)"OLD");
			cboStkRptType.Items.Add((object)"NEW");
			cboTagSaleWtDiff.Items.Add((object)"No");
			cboTagSaleWtDiff.Items.Add((object)"Yes");
			cboEstmateWithTax.Items.Add((object)"No");
			cboEstmateWithTax.Items.Add((object)"Yes");
			cboTagRowSave.Items.Add((object)"No");
			cboTagRowSave.Items.Add((object)"Yes");
			cboTagRowPrint.Items.Add((object)"No");
			cboTagRowPrint.Items.Add((object)"Yes");
			cboDhrnWapp.Items.Add((object)"No");
			cboDhrnWapp.Items.Add((object)"Yes");
			cboSchmWapp.Items.Add((object)"No");
			cboSchmWapp.Items.Add((object)"Yes");
			cboRptTotShow.Items.Add((object)"No");
			cboRptTotShow.Items.Add((object)"Yes");
			cboReminderType.Items.Add((object)"Reminder");
			cboReminderType.Items.Add((object)"Birthday");
			cboReminderType.Items.Add((object)"Order");
			cboReminderType.Items.Add((object)"Sales");
			cboReminderType.Items.Add((object)"Wh Sales");
			cboReminderType.Items.Add((object)"Dhiran");
			cboReminderType.Items.Add((object)"Member");
			cboHelpLent.Items.Add((object)"10");
			cboHelpLent.Items.Add((object)"15");
			cboHelpLent.Items.Add((object)"25");
			cboHelpLent.Items.Add((object)"50");
			cboOrdTagStkLess.Items.Add((object)"No");
			cboOrdTagStkLess.Items.Add((object)"Yes");
			cboAllBrancAcShow.Items.Add((object)"No");
			cboAllBrancAcShow.Items.Add((object)"Yes");
			cboEmpAsUser.Items.Add((object)"No");
			cboEmpAsUser.Items.Add((object)"Yes");
			cboImgWithWt.Items.Add((object)"Yes");
			cboImgWithWt.Items.Add((object)"No");
			cboDhrnImgPrint.Items.Add((object)"Yes");
			cboDhrnImgPrint.Items.Add((object)"No");
			cboLbrWitGht.Items.Add((object)"Yes");
			cboLbrWitGht.Items.Add((object)"No");
			cboAprlImg.Items.Add((object)"Yes");
			cboAprlImg.Items.Add((object)"No");
			cboOthItmWtRemove.Items.Add((object)"No");
			cboOthItmWtRemove.Items.Add((object)"Yes");
			cboSilverLedr3digit.Items.Add((object)"No");
			cboSilverLedr3digit.Items.Add((object)"Yes");
			cboWhSaleImg.Items.Add((object)"No");
			cboWhSaleImg.Items.Add((object)"Yes");
			cboitmWithLotStk.Items.Add((object)"No");
			cboitmWithLotStk.Items.Add((object)"Yes");
			cboBalSheetType.Items.Add((object)"Fine Wise");
			cboBalSheetType.Items.Add((object)"Amount Wise");
			cboFineStkType.Items.Add((object)"Average Wise");
			cboFineStkType.Items.Add((object)"Gr Touch Wise");
			cboFineStkType.Items.Add((object)"Net Wt Wise");
			cboStkRefresh.Items.Add((object)"No");
			cboStkRefresh.Items.Add((object)"Yes");
			cboMainFontChange.Items.Add((object)"No");
			cboMainFontChange.Items.Add((object)"Yes");
			cboSlRateWith.Items.Add((object)"Net Wise");
			cboSlRateWith.Items.Add((object)"Gorss Wise");
			cboSlRateWith.Items.Add((object)"Fine Wise");
			cboSlRateWith.Items.Add((object)"Pcs Wise");
			cboPurRateWith.Items.Add((object)"Net Wise");
			cboPurRateWith.Items.Add((object)"Gorss Wise");
			cboPurRateWith.Items.Add((object)"Fine Wise");
			cboPurRateWith.Items.Add((object)"Pcs Wise");
			cboStkRefresh.Items.Add((object)"No");
			cboStkRefresh.Items.Add((object)"Yes");
			cboCrystalViewType.Items.Add((object)"Old");
			cboCrystalViewType.Items.Add((object)"New");
			DC_Main.RsQry = "SELECT * From CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboLoanIntType.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["LOAN_INT_TYPE"], (object)"D", false), (object)"Day Wise", (object)"Month Wise"));
				cboAdminSms.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["ADMIN_SMS"], (object)"N", false), (object)"No", (object)"Yes"));
				cboCustSms.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["CUST_SMS"], (object)"N", false), (object)"No", (object)"Yes"));
				cboEmpMandatory.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["EMP_CODE_MANDATORY"], (object)"N", false), (object)"No", (object)"Yes"));
				cboPreviousLock.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["LAST_DAY_LOCK"], (object)"N", false), (object)"No", (object)"Yes"));
				ComboBox obj16 = cboCashLimit;
				object obj = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CASH_LIMIT"], (object)"");
				obj16.Text = Conversions.ToString(DC_Main.Fnv(ref obj));
				cboScorlbar.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["GRID_SCROLL"], (object)"N", false), (object)"No", (object)"Yes"));
				cboStkRptType.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["STOCK_RPT_TYPE"], (object)"OLD", false), (object)"OLD", (object)"NEW"));
				cboDhrnWapp.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["DHRN_WAPP"], (object)"Y", false), (object)"Yes", (object)"No"));
				cboSchmWapp.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[0]["SCHM_WAPP"], (object)"Y", false), (object)"Yes", (object)"No"));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FINE_STK_TYPE"], (object)""), (object)"N", false))
				{
					cboFineStkType.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FINE_STK_TYPE"], (object)""), (object)"G", false))
				{
					cboFineStkType.SelectedIndex = 1;
				}
				else
				{
					cboFineStkType.SelectedIndex = 0;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_AMT_TYPE"], (object)""), (object)"N", false))
				{
					cboSlRateWith.SelectedIndex = 0;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_AMT_TYPE"], (object)""), (object)"G", false))
				{
					cboSlRateWith.SelectedIndex = 1;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_AMT_TYPE"], (object)""), (object)"F", false))
				{
					cboSlRateWith.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_AMT_TYPE"], (object)""), (object)"P", false))
				{
					cboSlRateWith.SelectedIndex = 3;
				}
				else
				{
					cboSlRateWith.SelectedIndex = 0;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_AMT_TYPE"], (object)""), (object)"N", false))
				{
					cboPurRateWith.SelectedIndex = 0;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_AMT_TYPE"], (object)""), (object)"G", false))
				{
					cboPurRateWith.SelectedIndex = 1;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_AMT_TYPE"], (object)""), (object)"F", false))
				{
					cboPurRateWith.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_AMT_TYPE"], (object)""), (object)"P", false))
				{
					cboPurRateWith.SelectedIndex = 3;
				}
				else
				{
					cboPurRateWith.SelectedIndex = 2;
				}
			}
			DC_Main.RsQry = "SELECT * From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboBalSheetType.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PROFIT_RPT_TYPE"], (object)""), (object)"A", false), (object)"Amount", (object)"Fine"));
				cboQrCode.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["QR_CODE_GEN"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboCustOsSms.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OS_BILL_SMS"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboSalesImagPrint.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_BILL_IMG"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				ComboBox obj17 = cboPrRateRof;
				object obj = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_RATE_ROF"], (object)"");
				obj17.Text = Conversions.ToString(DC_Main.Fnv(ref obj));
				cboCountryid.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["COUNTRY_ID"], (object)""));
				cboWappSlPrint.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_SL_PRINT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboDesignGen.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_ENTRY_DESIGN_GEN"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboOrnaIsu.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OS_BILL_ORNA_ISU"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboMobileSearch.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MOBILE_HELP"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboTagSaleWtDiff.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_TAG_WT_DIFF"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboEstmateWithTax.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ESTMATE_TAX"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboTagRowSave.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_VCH_AUTO_SAVE"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboTagRowPrint.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_AUTO_PRINT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboFontChange.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_CHANGE"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboRptTotShow.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RPT_TOT_SHOW"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboOrdTagStkLess.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_TAG_STK_LESS"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboImgWithWt.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_IMG_GWT"], (object)""), (object)"N", false), (object)"No", (object)"Yes"));
				cboDhrnImgPrint.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHRN_IMG_PRINT"], (object)""), (object)"N", false), (object)"No", (object)"Yes"));
				cboStkRefresh.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CUR_DAY_POSTING"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""), (object)"R", false))
				{
					cboReminderType.SelectedIndex = 0;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""), (object)"B", false))
				{
					cboReminderType.SelectedIndex = 1;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""), (object)"O", false))
				{
					cboReminderType.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""), (object)"S", false))
				{
					cboReminderType.SelectedIndex = 3;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""), (object)"W", false))
				{
					cboReminderType.SelectedIndex = 4;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""), (object)"D", false))
				{
					cboReminderType.SelectedIndex = 5;
				}
				else
				{
					cboReminderType.SelectedIndex = 6;
				}
				cboFontSize.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_SIZE"], (object)""));
				CboFontName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_NAME"], (object)""));
				cboFontStyle.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_STYLE_TYPE"], (object)""));
				cboGridRowHeight.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GRID_ROW_HIGHT"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOT_FINE_STK_TYPE"], (object)""), (object)"T", false))
				{
					cboTotFineStkType.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOT_FINE_STK_TYPE"], (object)""), (object)"G", false))
				{
					cboTotFineStkType.SelectedIndex = 1;
				}
				else
				{
					cboTotFineStkType.SelectedIndex = 0;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PRINT_FORM_BTN"], (object)""), (object)"P", false))
				{
					cboPrintFormSet.SelectedIndex = 1;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PRINT_FORM_BTN"], (object)""), (object)"V", false))
				{
					cboPrintFormSet.SelectedIndex = 2;
				}
				else
				{
					cboPrintFormSet.SelectedIndex = 0;
				}
				cboOrdImage.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_IMG_PRINT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboBilTotRof.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOT_AMT_ROF"], (object)""));
				cboHelpLent.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_DESC_HELP_LENT"], (object)""));
				cboAllBrancAcShow.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BRANCH_ALL_AC_SHOW"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboEmpAsUser.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_AS_USER"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboLbrWitGht.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_WITH_GHT"], (object)""), (object)"N", false), (object)"No", (object)"Yes"));
				cboAprlImg.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["APR_IMG_PRINT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboOthItmWtRemove.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OTH_ITM_WT_REMOVE"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboSilverLedr3digit.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SILVER_THREE_DIGIT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboWhSaleImg.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WH_BILL_IMG"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboitmWithLotStk.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_WITH_LOT_STK"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboMainFontChange.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_FONT_CHANGE"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboCrystalViewType.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CRYSTAL_RPT"], (object)""), (object)"N", false), (object)"New", (object)"Old"));
			}
			EntryMode = "A";
			if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0))
			{
				((Control)Pnl2).Visible = false;
			}
			((Control)Pnl3).Visible = false;
			DgvFill();
		}
	}

	private void DgvFill()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Expected O, but got Unknown
		DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		((DataGridView)dGV).RowsDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)0);
		((DataGridView)dGV).AlternatingRowsDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)0);
		((DataGridView)DGV).RowTemplate.Height = 24;
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
		((DataGridView)dGV).Columns[0].Width = 90;
		((DataGridViewColumn)val).Name = "Box";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		((DataGridView)dGV).Columns[1].Width = 70;
		((DataGridView)dGV).Columns.Add("", "Setting Type");
		((DataGridView)dGV).Columns[2].Width = 270;
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 0].Value = 1;
		((DataGridView)dGV)[2, 0].Value = "Ledger Report Bill Column Show";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT LEDR_BILL_COL FROM CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["LEDR_BILL_COL"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 0].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 1].Value = 2;
		((DataGridView)dGV)[2, 1].Value = "All Calculation Roundoff Remove";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT ALL_ROF_REMOVE FROM CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["ALL_ROF_REMOVE"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 1].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 2].Value = 3;
		((DataGridView)dGV)[2, 2].Value = "Kr Design Isu Print With Image";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT KR_DESIGN_IMG_PRINT FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["KR_DESIGN_IMG_PRINT"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 2].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 3].Value = 4;
		((DataGridView)dGV)[2, 3].Value = "Sales Bill With Hallmark Tax";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT SALES_WITH_HMTAX FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["SALES_WITH_HMTAX"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 3].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 4].Value = 5;
		((DataGridView)dGV)[2, 4].Value = "Purchase Bill With Hallmark Tax";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT PURC_WITH_HMTAX FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PURC_WITH_HMTAX"], (object)""), (object)"Y", false))
		{
			((DataGridView)DGV)[0, 4].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 5].Value = 6;
		((DataGridView)dGV)[2, 5].Value = "Sales Bill With Tds Tax";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT SL_TDS_TAX FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["SL_TDS_TAX"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 5].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 6].Value = 7;
		((DataGridView)dGV)[2, 6].Value = "Purchase Bill With Tds Tax";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT PR_TDS_TAX FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["PR_TDS_TAX"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 6].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 7].Value = 8;
		((DataGridView)dGV)[2, 7].Value = "Design Wise Help Set";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT DESIGN_HELP FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["DESIGN_HELP"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 7].Value = true;
		}
		((DataGridView)dGV).Rows.Add();
		((DataGridView)dGV)[1, 8].Value = 9;
		((DataGridView)dGV)[2, 8].Value = "WhSales and Purc Fine Column Lock";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc("SELECT ITM_FINE_LOCK FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		if (DC_Main.Tbl.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["ITM_FINE_LOCK"], (object)"Y", false))
		{
			((DataGridView)DGV)[0, 8].Value = true;
		}
		DataGridViewButtonColumn val2 = new DataGridViewButtonColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val2);
		((DataGridViewColumn)val2).HeaderText = "Update";
		val2.Text = "OK";
		((DataGridViewColumn)val2).Name = "btn";
		val2.UseColumnTextForButtonValue = true;
		dGV = null;
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		string name = ((DataGridView)DGV).Columns[e.ColumnIndex].Name;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		if (Operators.CompareString(name, "btn", false) != 0)
		{
			return;
		}
		switch (index)
		{
		case 0:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET SET LEDR_BILL_COL = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsLedrBillColShow = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Ledger Report Zoom Then Bill Column Show Set...", (MsgBoxStyle)0, (object)null);
			break;
		case 1:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET SET ALL_ROF_REMOVE = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsAllRofRemove = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
			{
				DC_Main.MsItmRateRof = 2;
				DC_Main.MsLbrRof = 2;
				DC_Main.MsItmRateRof = 2;
				DC_Main.MsTotAmtRof = 2;
				DC_Main.MsTaxRof = 2;
			}
			Interaction.MsgBox((object)"All Form LbrRate - LbrAmt - Oth Amt - Itmrate - itm Amt Rof Set Plese ReOpen Software ...", (MsgBoxStyle)0, (object)null);
			Application.Exit();
			break;
		case 2:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET KR_DESIGN_IMG_PRINT = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsKrDesignImgPrint = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Karigar Design Isu Image Print Set...", (MsgBoxStyle)0, (object)null);
			break;
		case 3:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET SALES_WITH_HMTAX = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsSalesWithHmTax = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Sales Bill With Hm Tax Set ....", (MsgBoxStyle)0, (object)null);
			break;
		case 4:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET PURC_WITH_HMTAX = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsPurcWithHmTax = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Purchase Bill With Hm Tax Set ....", (MsgBoxStyle)0, (object)null);
			break;
		case 5:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET SL_TDS_TAX = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsSlTdsTax = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Sales Bill With Tds Tax Set ....", (MsgBoxStyle)0, (object)null);
			break;
		case 6:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET PR_TDS_TAX = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsPrTdsTax = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Purchase Bill With Tds Tax Set ....", (MsgBoxStyle)0, (object)null);
			break;
		case 7:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET DESIGN_HELP = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsDesignHelp = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"Design Wise Tag Help Set ....", (MsgBoxStyle)0, (object)null);
			break;
		case 8:
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CO_SET_NEW SET ITM_FINE_LOCK = ", Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"'Y'", (object)"'N'")), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"'"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.MsItmFineLock = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(((DataGridView)DGV)[0, index].Value, (object)true, false), (object)"Y", (object)"N"));
			Interaction.MsgBox((object)"WhSale and Purchase Item Fine Columan Lock ....", (MsgBoxStyle)0, (object)null);
			break;
		}
	}

	private void UT_SETTING_MAIN_Activated(object sender, EventArgs e)
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
		EntryMode = "A";
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

	private void UT_SETTING_MAIN_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_SETTING_MAIN_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
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

	private void UT_SETTING_MAIN_Closed(object sender, EventArgs e)
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

	private void btnQrcode_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET QR_CODE_GEN = '" + Strings.Mid(cboQrCode.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsQrCodeGen = Strings.Mid(cboQrCode.Text, 1, 1);
		Interaction.MsgBox((object)"Tag Qr Code Generate....Set", (MsgBoxStyle)0, (object)null);
	}

	private void btnCustOsSms_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET OS_BILL_SMS = '" + Strings.Mid(cboCustOsSms.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOsBillSms = Strings.Mid(cboCustOsSms.Text, 1, 1);
		Interaction.MsgBox((object)"Sales bill Sms And Whatsapp With Os Amount is...Set", (MsgBoxStyle)0, (object)null);
	}

	private void btnLoanIntDay_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET LOAN_INT_TYPE = '" + Strings.Mid(cboLoanIntType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLoanIntType = Strings.Mid(cboLoanIntType.Text, 1, 1);
		Interaction.MsgBox((object)"Loan Intrest Type Is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnSlImgPrint_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET SL_BILL_IMG = '" + Strings.Mid(cboSalesImagPrint.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlBillImg = Strings.Mid(cboSalesImagPrint.Text, 1, 1);
		Interaction.MsgBox((object)"Sales Bill Image Print is Set Please Image Set In Bill....", (MsgBoxStyle)0, (object)null);
	}

	private void btnTotFineStkType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET TOT_FINE_STK_TYPE = '" + Strings.Mid(cboTotFineStkType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTotFineStkType = Strings.Mid(cboTotFineStkType.Text, 1, 1);
		Interaction.MsgBox((object)"Total Fine Report Stock Type is Set ....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnPrRateRof_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET PR_RATE_ROF = " + Conversions.ToString(Conversion.Val(cboPrRateRof.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPrRateRof = checked((int)Math.Round(Conversion.Val(cboPrRateRof.Text)));
		Interaction.MsgBox((object)"Purchase Item Rate Roundof Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnAdminSms_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET ADMIN_SMS = '" + Strings.Mid(cboAdminSms.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsAdminSms = Strings.Mid(cboAdminSms.Text, 1, 1);
		Interaction.MsgBox((object)"Admin Sms And Whatsapp Send is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void btnCustSms_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET CUST_SMS = '" + Strings.Mid(cboCustSms.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCustSms = Strings.Mid(cboCustSms.Text, 1, 1);
		Interaction.MsgBox((object)"Customer Sms And Whatsapp Send is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnCountryId_Click(object sender, EventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET COUNTRY_ID = '" + cboCountryid.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCountryId = cboCountryid.Text;
		Interaction.MsgBox((object)"Whatsapp Country Id is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnWappSlprint_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET WAPP_SL_PRINT = '" + Strings.Mid(cboWappSlPrint.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsWappSlPrint = Strings.Mid(cboWappSlPrint.Text, 1, 1);
		Interaction.MsgBox((object)"Whatsapp Sales bill Print is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnDesignGen_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET TAG_ENTRY_DESIGN_GEN = '" + Strings.Mid(cboDesignGen.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsDesignMastHelp = Strings.Mid(cboDesignGen.Text, 1, 1);
		Interaction.MsgBox((object)"Tag Entry Design Generat is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnOrdImage_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET ORD_IMG_PRINT = '" + Strings.Mid(cboOrdImage.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOrdImgPrint = Strings.Mid(cboOrdImage.Text, 1, 1);
		Interaction.MsgBox((object)"Order Image Print is Set Please Image Set In Sales Order Voucher....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnOrnaIsu_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET OS_BILL_ORNA_ISU = '" + Strings.Mid(cboOrnaIsu.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOsBillOrnaIsu = Strings.Mid(cboOrnaIsu.Text, 1, 1);
		Interaction.MsgBox((object)"Sales bill Os Then Ornament isu Panding set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnMobileSearch_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET MOBILE_HELP = '" + Strings.Mid(cboMobileSearch.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsMobileHelp = Strings.Mid(cboMobileSearch.Text, 1, 1);
		Interaction.MsgBox((object)"Party Help Serarch With Mobile No Set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnPrintFormSet_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET PRINT_FORM_BTN = '" + Strings.Mid(cboPrintFormSet.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPrintFormBtn = Strings.Mid(cboPrintFormSet.Text, 1, 1);
		Interaction.MsgBox((object)"Print Form Default Butten Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnEmpMandotry_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET EMP_CODE_MANDATORY = '" + Strings.Mid(cboEmpMandatory.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsEmpCodeMendetry = Strings.Mid(cboEmpMandatory.Text, 1, 1);
		Interaction.MsgBox((object)"In Sales Bill Employee Code Is Mandatory Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnFontChang_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET FONT_CHANGE = '" + Strings.Mid(cboFontChange.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFontChange = Strings.Mid(cboFontChange.Text, 1, 1);
		Interaction.MsgBox((object)"Report Font Change Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnFontSize_Click(object sender, EventArgs e)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET FONT_SIZE = " + Conversions.ToString(Conversion.Val(cboFontSize.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFontSize = (float)Conversion.Val(cboFontSize.Text);
		Interaction.MsgBox((object)"Font Size Change Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnFontName_Click(object sender, EventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET FONT_NAME = '" + CboFontName.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFontName = CboFontName.Text;
		Interaction.MsgBox((object)"Font Name Change Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnFontStyle_Click(object sender, EventArgs e)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET FONT_STYLE_TYPE = '" + Strings.Mid(cboFontStyle.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFontStyle = (FontStyle)Conversions.ToInteger(Strings.Mid(cboFontStyle.Text, 1, 1));
		Interaction.MsgBox((object)"Font Style Change Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnGridRowHeightSet_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET GRID_ROW_HIGHT = " + Conversions.ToString(Conversion.Val(cboGridRowHeight.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsGridRowHeight = checked((int)Math.Round(Conversion.Val(cboGridRowHeight.Text)));
		Interaction.MsgBox((object)"Report Grid Row Height set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnPreviousLock_Click(object sender, EventArgs e)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET LAST_DAY_LOCK = '" + Strings.Mid(cboPreviousLock.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLastDayLock = Strings.Mid(cboPreviousLock.Text, 1, 1);
		if (Operators.CompareString(DC_Main.MsLastDayLock, "Y", false) == 0)
		{
			DC_Main.ExeQuteDc("UPDATE CO_SET SET LOCK_DATE = '" + Strings.Format((object)DC_Main.MsSysDate.AddDays(-1.0), "MM/dd/yyyy") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.MsLockDt = Conversions.ToDate(Strings.Format((object)DC_Main.MsSysDate.AddDays(-1.0), "dd/MM/yyyy"));
		}
		Interaction.MsgBox((object)"Previous Day Entry Auto Lock is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnCashLimit_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET CASH_LIMIT = " + Conversions.ToString(Conversion.Val(cboCashLimit.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCashLimit = Conversion.Val(cboCashLimit.Text);
		Interaction.MsgBox((object)"Party Cash Amount Receved Limit Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnDcMemb_Click(object sender, EventArgs e)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(Strings.UCase(tDcPwd.Text), "GJ11DC", false) == 0)
		{
			((Control)Pnl3).Visible = true;
			Interaction.MsgBox((object)"Now Open Member Setting Tab No 3...", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			((Control)Pnl3).Visible = false;
			Interaction.MsgBox((object)"Passward Is Rong...", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnBillTitRof_Click(object sender, EventArgs e)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET TOT_AMT_ROF = '" + Strings.Mid(cboBilTotRof.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTotAmtRof = Conversions.ToInteger(Strings.Mid(cboBilTotRof.Text, 1, 1));
		Interaction.MsgBox((object)"Voucher Net And Total Amount Round of Set", (MsgBoxStyle)0, (object)null);
		DC_Main.RsQry = "UPDATE CO_SET SET ITM_RATE_ROF = '" + Strings.Mid(cboBilTotRof.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsItmRateRof = 2;
		Interaction.MsgBox((object)"Sales Item Rate Roundof is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnScrolbar_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET GRID_SCROLL = '" + Strings.Mid(cboScorlbar.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsGridScroll = Strings.Mid(cboScorlbar.Text, 1, 1);
		Interaction.MsgBox((object)"All Voucher Grid Total Scollbar Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnStkRptType_Click(object sender, EventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET STOCK_RPT_TYPE = '" + cboStkRptType.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsStockRptView = cboStkRptType.Text;
		Interaction.MsgBox((object)"Stock Report Type F3 and F12 is Same Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnTagSlWtDiff_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET SL_TAG_WT_DIFF = '" + Strings.Mid(cboTagSaleWtDiff.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlAndTagWtDiff = Strings.Mid(cboTagSaleWtDiff.Text, 1, 1);
		Interaction.MsgBox((object)"Sales Whight Chang Then Tag and Sl Wt Diff Posting Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnEstmatTax_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET ESTMATE_TAX = '" + Strings.Mid(cboEstmateWithTax.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTaxWithEstmate = Strings.Mid(cboEstmateWithTax.Text, 1, 1);
		Interaction.MsgBox((object)"Sales Estmate With Tax Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnTagRowSave_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET TAG_VCH_AUTO_SAVE = '" + Strings.Mid(cboTagRowSave.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTagVchAutoSave = Strings.Mid(cboTagRowSave.Text, 1, 1);
		Interaction.MsgBox((object)"Tag Entry Last Row Auto Save is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnTagRowPrint_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET TAG_AUTO_PRINT = '" + Strings.Mid(cboTagRowPrint.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTagRowAutoPrint = Strings.Mid(cboTagRowPrint.Text, 1, 1);
		Interaction.MsgBox((object)"Tag Entry Last Row Auto Print is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnDhrnWapp_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET DHRN_WAPP = '" + Strings.Mid(cboDhrnWapp.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsDhrnWapp = Strings.Mid(cboDhrnWapp.Text, 1, 1);
		Interaction.MsgBox((object)"Dhrn Whatsapp Send is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnSchmWapp_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET SCHM_WAPP = '" + Strings.Mid(cboSchmWapp.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSchmWapp = Strings.Mid(cboSchmWapp.Text, 1, 1);
		Interaction.MsgBox((object)"Scheme Whatsapp Send is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnRptTotShow_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET RPT_TOT_SHOW = '" + Strings.Mid(cboRptTotShow.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsRptTotShow = Strings.Mid(cboRptTotShow.Text, 1, 1);
		Interaction.MsgBox((object)"Ledger Or Stock Grid Report Total (Footer Last Row) Show Set ....", (MsgBoxStyle)0, (object)null);
	}

	private void BrnReminderType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET DEFAULT_REMINDER = '" + Strings.Mid(cboReminderType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsDefaultReminder = Strings.Mid(cboReminderType.Text, 1, 1);
		Interaction.MsgBox((object)"Home Page Default Reminder Menu Set ....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnHelpLent_Click(object sender, EventArgs e)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET VCH_DESC_HELP_LENT = " + Conversions.ToString(Conversion.Val(cboHelpLent.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsVchDescHelpLenth = checked((int)Math.Round(Conversion.Val(cboHelpLent.Text)));
		Interaction.MsgBox((object)"All Entry Voucher VchDesc Help Lenth Set..", (MsgBoxStyle)0, (object)null);
	}

	private void BtnOrdTagStkLess_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET ORD_TAG_STK_LESS = '" + Strings.Mid(cboOrdTagStkLess.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOrdTagLessInStk = Strings.Mid(cboOrdTagStkLess.Text, 1, 1);
		Interaction.MsgBox((object)"Order Tag Then Stock less..Set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnAllBranchAcShow_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET BRANCH_ALL_AC_SHOW = '" + Strings.Mid(cboAllBrancAcShow.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsAllBranchAcShow = Strings.Mid(cboAllBrancAcShow.Text, 1, 1);
		Interaction.MsgBox((object)"All Branch Party Ac Show In Other Branch Set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnEmpAsUser_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET EMP_AS_USER = '" + Strings.Mid(cboEmpAsUser.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsEmpAsUser = Strings.Mid(cboEmpAsUser.Text, 1, 1);
		Interaction.MsgBox((object)"All Transection Default Employee Code As Par User Set ...", (MsgBoxStyle)0, (object)null);
	}

	private void brnImgWithWt_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET WAPP_IMG_GWT = '" + Strings.Mid(cboImgWithWt.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsWappImgGwt = Strings.Mid(cboImgWithWt.Text, 1, 1);
		Interaction.MsgBox((object)"Whatsapp Image Send With Tag Weight Set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnDhrnImgPrint_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET DHRN_IMG_PRINT = '" + Strings.Mid(cboDhrnImgPrint.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsDhrnImgPrint = Strings.Mid(cboDhrnImgPrint.Text, 1, 1);
		Interaction.MsgBox((object)"Dhran Isu Item Print With Images...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnLbrWithGht_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET LBR_WITH_GHT = '" + Strings.Mid(cboLbrWitGht.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsLbrWithGht = Strings.Mid(cboLbrWitGht.Text, 1, 1);
		Interaction.MsgBox((object)"Sales Whight Chang Then Tag and Sl Wt Diff Posting Set....", (MsgBoxStyle)0, (object)null);
	}

	private void BtnAprlImg_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET APR_IMG_PRINT = '" + Strings.Mid(cboAprlImg.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsAprImgPrint = Strings.Mid(cboAprlImg.Text, 1, 1);
		Interaction.MsgBox((object)"Approval Isu Item Print With Images...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnOthItmWtRemove_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET OTH_ITM_WT_REMOVE = '" + Strings.Mid(cboOthItmWtRemove.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOthItmWtRemove = Strings.Mid(cboOthItmWtRemove.Text, 1, 1);
		Interaction.MsgBox((object)"Other Item Weight Remove In WhSales bill With Tag Item...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnSilverWt3digit_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET SILVER_THREE_DIGIT = '" + Strings.Mid(cboSilverLedr3digit.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSilverWt3Digit = Strings.Mid(cboSilverLedr3digit.Text, 1, 1);
		Interaction.MsgBox((object)"Ledger Or All Transection Silver Formate 3 Digit set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnWhSaleImg_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET WH_BILL_IMG = '" + Strings.Mid(cboWhSaleImg.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsWhBillImg = Strings.Mid(cboWhSaleImg.Text, 1, 1);
		Interaction.MsgBox((object)"Wh Sales Bill Print With Images...", (MsgBoxStyle)0, (object)null);
	}

	private void tDcPwd_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)pnlSet).Left = ((Control)this).Left;
			((Control)pnlSet).Top = ((Control)this).Top;
			if (!((Control)pnlSet).Visible)
			{
				((Control)pnlSet).Visible = true;
			}
			else
			{
				((Control)pnlSet).Visible = false;
			}
		}
	}

	private void btnItmLotStk_Click(object sender, EventArgs e)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET ITM_WITH_LOT_STK = '" + Strings.Mid(cboitmWithLotStk.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsItmWitLotStk = Strings.Mid(cboitmWithLotStk.Text, 1, 1);
		if (Operators.CompareString(Strings.Mid(cboitmWithLotStk.Text, 1, 1), "Y", false) == 0)
		{
			DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_VIEW = 'Y' WHERE MAIN_SRNO = '02' AND  SM_MAIN_CODE = '12' AND SM_MAIN_NAME = 'Lot Opening'");
		}
		else
		{
			DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_CODE = 'N' WHERE MAIN_SRNO = '02' AND SM_MAIN_CODE = '12' AND SM_MAIN_NAME = 'Lot Opening'");
		}
		Interaction.MsgBox((object)"Item With Lot Stock Is Set...In Item Master...Please Re Open Software...", (MsgBoxStyle)0, (object)null);
		Application.Exit();
	}

	private void btnBalSheetType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET PROFIT_RPT_TYPE = '" + Strings.Mid(cboBalSheetType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsBalanceSheetType = Strings.Mid(cboBalSheetType.Text, 1, 1);
		Interaction.MsgBox((object)"Balance Sheet Type Is Set ....", (MsgBoxStyle)0, (object)null);
	}

	private void btnFineStkType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET FINE_STK_TYPE = '" + Strings.Mid(cboFineStkType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsFineStkType = Strings.Mid(cboFineStkType.Text, 1, 1);
		Interaction.MsgBox((object)"Balance Sheet Report Type Set....", (MsgBoxStyle)0, (object)null);
	}

	private void brnRefresh_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET CUR_DAY_POSTING = '" + Strings.Mid(cboStkRefresh.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCurDayPosting = Strings.Mid(cboStkRefresh.Text, 1, 1);
		Interaction.MsgBox((object)"Only Curent Day Stock Posting Is Set...", (MsgBoxStyle)0, (object)null);
	}

	private void btnMainFontChange_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET MAIN_FONT_CHANGE = '" + Strings.Mid(cboMainFontChange.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsMainFontChange = Strings.Mid(cboMainFontChange.Text, 1, 1);
		Interaction.MsgBox((object)"Main Entry Grid Font Change Set...", (MsgBoxStyle)0, (object)null);
	}

	private void btnSlRateWith_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET SL_AMT_TYPE = '" + Strings.Mid(cboSlRateWith.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlAmtType = Strings.Mid(cboSlRateWith.Text, 1, 1);
		Interaction.MsgBox((object)"Sales Rate Calc With Net or gross or fine Set...", (MsgBoxStyle)0, (object)null);
	}

	private void btnPurRateWith_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET SET PR_AMT_TYPE = '" + Strings.Mid(cboPurRateWith.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPrAmtType = Strings.Mid(cboPurRateWith.Text, 1, 1);
		Interaction.MsgBox((object)"Purchase Rate Calc With Net or gross or fine Set...", (MsgBoxStyle)0, (object)null);
	}

	private void btnCrystalRptType_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET CRYSTAL_RPT = '" + Strings.Mid(cboCrystalViewType.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCrystalRptType = Strings.Mid(cboCrystalViewType.Text, 1, 1);
		Interaction.MsgBox((object)"Crystal Report View Type Set...", (MsgBoxStyle)0, (object)null);
	}
}
